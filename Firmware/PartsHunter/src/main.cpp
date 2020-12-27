#include <Arduino.h>
#include <FastLED.h>

#define DATA_PIN 2
#define BRIGHTNESS 150
#define NUM_LEDS 384
#define NUM_LEDS_IN_BOX 24

#define SERVER_CONFIRMATION "OK\r\n"
#define SERVER_REQUEST "BOX?\r\n"

bool Server_Ready = false;
String String_UART = "";
String Server_Response = "";

char Number_Boxes_JSON_Array[80];

CRGB leds[NUM_LEDS];

void Highlight_Drawer(unsigned int box, unsigned int drawer);

void setup()
{
  FastLED.addLeds<WS2812B, DATA_PIN, RGB>(leds, NUM_LEDS);
  FastLED.setBrightness(BRIGHTNESS);

  FastLED.clear();
  FastLED.show();

  Serial.begin(9600);
  while (!Serial) {
    ;
  }
  
  
  
  sprintf(Number_Boxes_JSON_Array, "{\"Number Boxes\":\"%d\"}\r\n", (NUM_LEDS / NUM_LEDS_IN_BOX));
  Serial.println(Number_Boxes_JSON_Array);
}

void loop()
{
  
  while (Serial.available() > 0 ) {
    String_UART = Serial.readString(); Serial.println("Server: " + String_UART);

    if (String_UART.indexOf(SERVER_REQUEST) > -1) {
      Server_Ready = false;
      do {
        Serial.println(Number_Boxes_JSON_Array);
        while (Serial.available() > 0 ) {
           Server_Response = Serial.readString();
          if (Server_Response.indexOf(SERVER_CONFIRMATION) > -1)
            Server_Ready = true;
        }

      } while (!Server_Ready);
    }

    if(Server_Ready){      
      Highlight_Drawer(1, String_UART.toInt());
    }

  }
  
}

void Highlight_Drawer(unsigned int box, unsigned int drawer)
{
  FastLED.clear();

  if (drawer > 0)
  {
    leds[((box * NUM_LEDS_IN_BOX) - NUM_LEDS_IN_BOX) + drawer - 1] = CRGB::Red;
  }

  FastLED.show();
}