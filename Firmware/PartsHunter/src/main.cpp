//Arduino Libraries
#include <Arduino.h>

//External Libraries
#include <FastLED.h>
#include <Ticker.h>

//External Hardware Definitions
#define LED_CONTROL_PIN 2

//Application Definitions
#define DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL 150
#define TOTAL_NUMBER_LEDS_AT_SRIP 600
#define UART_BUFFER_SIZE 30

//Global Variables
String String_UART = "";
uint16_t LED_Position = 0;
char UART_Buffer[UART_BUFFER_SIZE + 1];
uint8_t Box_Number;
uint8_t Drawer_Number;
CRGB Color_HEX;
uint8_t Brightness_Level;
uint16_t Blinky_Time;
uint32_t Last_Time = 0;
bool Change_LED_State = true;
char array[30] = {0};

//Function Prototypes
char *Extract_Parameter_Value(String input, char separator, int index);
uint16_t Get_LED_Strip_Number(uint8_t box_number, uint8_t drawer_number);
void SETUP_ISR_Highlight(uint16_t led_position, uint8_t red_color, uint8_t green_color, uint8_t blue_color, uint8_t brightness_level, uint16_t blinky_time);
void ISR_Highlight_Drawer();
uint32_t Get_HEX_from_RGB(uint8_t red_color, uint8_t green_color, uint8_t blue_color);

//Global Objects
CRGB LED_Strip[TOTAL_NUMBER_LEDS_AT_SRIP];
Ticker timer1(ISR_Highlight_Drawer, 50); //50 mili-seconds overflow

void setup()
{
  FastLED.addLeds<WS2812B, LED_CONTROL_PIN, GRB>(LED_Strip, TOTAL_NUMBER_LEDS_AT_SRIP);
  FastLED.setBrightness(DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL);
  FastLED.clear();

  timer1.start();

  Serial.begin(115200);

  while (!Serial)
  {
    ;
  }

  Blinky_Time = 100;
  Last_Time = millis();
  Brightness_Level = 128;
}

void loop()
{
  timer1.update();

  uint8_t number_bytes_received = 0;

  while (Serial.available())
  {
    number_bytes_received = Serial.readBytes(UART_Buffer, UART_BUFFER_SIZE);
  }

  if (number_bytes_received > 0)
  {
    UART_Buffer[number_bytes_received] = 0;
    
    int16_t drawer_number = atoi(Extract_Parameter_Value(UART_Buffer, ',', 0));
    uint8_t red_color = atoi(Extract_Parameter_Value(UART_Buffer, ',', 1));
    uint8_t green_color = atoi(Extract_Parameter_Value(UART_Buffer, ',', 2));
    uint8_t blue_color = atoi(Extract_Parameter_Value(UART_Buffer, ',', 3));
    uint8_t brightness_level = atoi(Extract_Parameter_Value(UART_Buffer, ',', 4));
    uint16_t blinky_time = atoi(Extract_Parameter_Value(UART_Buffer, ',', 5));   

    if (drawer_number < 0) // Turn-off all LEDs
    {
      red_color = 0;
      green_color = 0;
      blue_color = 0;

      SETUP_ISR_Highlight(1, red_color, green_color, blue_color, brightness_level, blinky_time);
    }
    else if (
        (drawer_number >= 0) && (drawer_number <= TOTAL_NUMBER_LEDS_AT_SRIP) &&
        (red_color >= 0) && (red_color <= 255) &&
        (green_color >= 0) && (green_color <= 255) &&
        (blue_color >= 0) && (blue_color <= 255) &&
        (brightness_level >= 0) && (brightness_level <= 255) &&
        (blinky_time >= 100) && (blinky_time <= 1000))
    {
      uint16_t led_position = drawer_number;
      
      SETUP_ISR_Highlight(led_position, red_color, green_color, blue_color, brightness_level, blinky_time);
    }
  }
}

char *Extract_Parameter_Value(String input, char separator, int index)
{
  int found = 0;
  int strIndex[] = {0, -1};
  int maxIndex = input.length() - 1;
  char buf[50] = {0};
  char buf2[1] = {0};

  for (int i = 0; i <= maxIndex && found <= index; i++)
  {
    if (input.charAt(i) == separator || i == maxIndex)
    {
      found++;
      strIndex[0] = strIndex[1] + 1;
      strIndex[1] = (i == maxIndex) ? i + 1 : i;
    }
  }

  String s = input.substring(strIndex[0], strIndex[1]);
  s.toCharArray(buf, s.length() + 1);
  return (found > index) ? buf : buf2;
}

void SETUP_ISR_Highlight(uint16_t led_position, uint8_t red_color, uint8_t green_color, uint8_t blue_color, uint8_t brightness_level, uint16_t blinky_time)
{
  LED_Position = led_position;
  Color_HEX = CRGB(red_color, green_color, blue_color);
  Brightness_Level = brightness_level;
  Blinky_Time = blinky_time;
  FastLED.clear();
  FastLED.show();
  Last_Time = millis();
}

void ISR_Highlight_Drawer()
{
  if (Change_LED_State == true)
  {
    LED_Strip[LED_Position] = Color_HEX;
    FastLED.setBrightness(Brightness_Level);
    FastLED.show();
  }
  else
  {
    if (Blinky_Time >= 100)
    {
      FastLED.clear();
      FastLED.show();
    }
  }

  if ((millis() - Last_Time) >= Blinky_Time)
  {
    Last_Time = millis();

    if (Change_LED_State)
      Change_LED_State = false;
    else
      Change_LED_State = true;
  }
}