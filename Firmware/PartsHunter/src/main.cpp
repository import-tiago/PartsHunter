#include <Arduino.h>
#include <FastLED.h>

#define BRIGHTNESS 150
#define NUM_LEDS 24
#define DATA_PIN 2

#define NUM_LEDS_IN_BOX 24

CRGB leds[NUM_LEDS];

void Highlight_Drawer(unsigned int box, unsigned int drawer);

void setup()
{
	FastLED.addLeds<WS2812B, DATA_PIN, RGB>(leds, NUM_LEDS);
	FastLED.setBrightness(BRIGHTNESS);

	FastLED.clear();
	FastLED.show();

	Serial.begin(115200);
}

void loop()
{
	if (Serial.available() > 0)
	{
		unsigned int uart = Serial.parseInt();

		Serial.println(uart);

		Highlight_Drawer(1, uart);
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
