#include "MyAuthParameters.h"
#include <Adafruit_NeoPixel.h>
#include <Arduino.h>
#include <AsyncTCP.h>
#include <ESPAsyncWebServer.h>
#include <Preferences.h>
#include <WiFi.h>

#define LED_STRIP_PIN 13

AsyncWebServer server(80);
Adafruit_NeoPixel pixels(600, LED_STRIP_PIN, NEO_GRB + NEO_KHZ800);

uint32_t blink_interval;
std::vector<int16_t> active_slots;
uint8_t led_brightness;
uint8_t color_r, color_g, color_b;
Preferences NVS;

#define DEFAULT_BLINK_INTERVAL 800
#define DEFAULT_LED_BRIGHTNESS 50
#define DEFAULT_COLOR_R 0
#define DEFAULT_COLOR_G 150
#define DEFAULT_COLOR_B 0

void load_from_nvs() {

    blink_interval = NVS.getUInt("blink_interval", DEFAULT_BLINK_INTERVAL);
    led_brightness = NVS.getUChar("led_brightness", DEFAULT_LED_BRIGHTNESS);
    color_r = NVS.getUChar("color_r", DEFAULT_COLOR_R);
    color_g = NVS.getUChar("color_g", DEFAULT_COLOR_G);
    color_b = NVS.getUChar("color_b", DEFAULT_COLOR_B);
}

void store_in_nvs() {
    NVS.putUInt("blink_interval", blink_interval);
    NVS.putUChar("led_brightness", led_brightness);
    NVS.putUChar("color_r", color_r);
    NVS.putUChar("color_g", color_g);
    NVS.putUChar("color_b", color_b);
}

void restore_defaults() {
    blink_interval = DEFAULT_BLINK_INTERVAL;
    led_brightness = DEFAULT_LED_BRIGHTNESS;
    color_r = DEFAULT_COLOR_R;
    color_g = DEFAULT_COLOR_G;
    color_b = DEFAULT_COLOR_B;

    store_in_nvs();
}

void setup() {

    Serial.begin(115200);

    // ----- STEP 1

    NVS.begin("settings", false);
    load_from_nvs();

    // ----- STEP 2
    Serial.print("\r\nTrying Wi-Fi connection...");
    WiFi.disconnect(true, true);
    delay(1000);
    WiFi.setHostname("PartsHunter"); // needs to be called before WiFi.mode()
    WiFi.mode(WIFI_MODE_STA);
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
    WiFi.setSleep(false);
    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }
    Serial.println(" CONNECTED!");

    // ----- STEP 3
    IPAddress ip = INADDR_NONE;
    IPAddress gateway = INADDR_NONE;
    IPAddress subnet = INADDR_NONE;

    ip.fromString(STATIC_IP_ADDR);
    gateway.fromString(STATIC_GATEWAY_ADDR);
    subnet.fromString(STATIC_SUBNET_MASK_ADDR);

    if (!WiFi.config(ip, gateway, subnet)) {
        Serial.println("\r\nStatic IP fail to init");
        return;
    }

    Serial.printf("\r\nLocal IP address: %s\r\n", WiFi.localIP().toString().c_str());

    // ----- STEP 4
    pixels.begin();
    pixels.clear();
    pixels.show();
    pixels.setBrightness(led_brightness);

    // ----- STEP 5
    server.on("/slot", HTTP_POST, [](AsyncWebServerRequest* request) {
        if (request->hasParam("id")) {

            String query = request->getParam("id")->value();
            active_slots.clear();

            int16_t start_idx = 0;
            while (start_idx < query.length()) {

                int16_t comma_idx = query.indexOf(',', start_idx);
                if (comma_idx == -1)
                    comma_idx = query.length();

                int16_t new_slot = query.substring(start_idx, comma_idx).toInt();
                if (new_slot >= 0 && new_slot <= 599)
                    active_slots.push_back(new_slot);

                start_idx = comma_idx + 1;
            }

            request->send(200);
        }
        else {
            request->send(404); // 'id' parameter is missing
        }
    });

    server.on("/blink", HTTP_POST, [](AsyncWebServerRequest* request) {
        if (request->hasParam("interval")) {

            String query = request->getParam("interval")->value();
            uint16_t new_interval = query.toInt();

            if (new_interval >= 0 && new_interval <= 1000) {
                blink_interval = new_interval;
                store_in_nvs();
                request->send(200);
            }
            else
                request->send(400); // out of range (0-1000ms)
        }
        else
            request->send(404); // 'interval' parameter is missing
    });

    server.on("/brightness", HTTP_POST, [](AsyncWebServerRequest* request) {
        if (request->hasParam("level")) {

            String query = request->getParam("level")->value();
            uint16_t new_brightness = query.toInt();

            if (new_brightness >= 0 && new_brightness <= 255) {
                led_brightness = new_brightness;
                pixels.setBrightness(led_brightness);
                store_in_nvs();
                request->send(200);
            }

            request->send(200);
        }
        else {
            request->send(404); // 'id' parameter is missing
        }
    });

    server.on("/color", HTTP_POST, [](AsyncWebServerRequest* request) {
        if (request->hasParam("r") && request->hasParam("g") && request->hasParam("b")) {

            color_r = request->getParam("r")->value().toInt();
            color_g = request->getParam("g")->value().toInt();
            color_b = request->getParam("b")->value().toInt();
            store_in_nvs();
            request->send(200); // Success
        }
        else {
            request->send(404); // Missing color parameter
        }
    });

    server.on("/clear", HTTP_POST, [](AsyncWebServerRequest* request) {
        active_slots.clear();
        request->send(200);
    });

    server.on("/restore_defaults", HTTP_POST, [](AsyncWebServerRequest* request) {
        restore_defaults();
        pixels.setBrightness(led_brightness);
        request->send(200);
    });

    server.begin();
}

void loop() {

    if (!active_slots.empty()) {

        static uint32_t t0 = 0;
        static bool state = false;

        if (millis() - t0 > blink_interval) {

            if (state && blink_interval > 0)
                pixels.clear();

            else {
                for (int16_t slot : active_slots)
                    pixels.setPixelColor(slot, pixels.Color(color_r, color_g, color_b));
            }

            pixels.show();
            state = !state;

            t0 = millis();
        }
    }
    else {
        pixels.clear();
        pixels.show();
    }
}
