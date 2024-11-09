#include "MyAuthParameters.h"
#include <Arduino.h>
#include <WiFi.h>

void setup() {

    Serial.begin(115200);

    // ----- STEP 1
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

    // ----- STEP 2
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
}

void loop() {
}