#include <Arduino.h>
#include <FastLED.h>
#include <Ticker.h> 

//External Hardware Definitions
#define LED_CONTROL_PIN 2

//Internal Periphals Hardware Definitions
#define UART_BUFFER_SIZE 20

//Application Definitions
#define DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL 150
#define TOTAL_NUMBER_LEDS_AT_SRIP 384
#define NUMBER_LED_Strip_PER_BOX 24


//Global Variables
String String_UART = "";
uint16_t LED_Position = 0;
char UART_Buffer[UART_BUFFER_SIZE + 1];

uint8_t Box_Number;
uint8_t Drawer_Number;
uint32_t Color_HEX;
uint8_t Brightness_Level;
uint16_t Blinky_Time;

uint32_t Initial_Time = 0;
uint32_t Last_Time = 0;
bool Change_LED_State = true;

//Function Prototypes
char* Extract_Parameter_Value(String input, char separator, int index);
uint16_t Get_LED_Strip_Number(uint8_t box_number, uint8_t drawer_number);
void SETUP_Highlight(uint16_t led_position, unsigned long hex_color, uint8_t brightness_level, uint16_t blinky_time);
void ISR_Highlight_Drawer();

//Global Objects
CRGB LED_Strip[TOTAL_NUMBER_LEDS_AT_SRIP];
Ticker timer1(ISR_Highlight_Drawer, 100);


 int number_bytes_received = 0;
char r[50] = {0};
void setup()
{
  FastLED.addLeds<WS2812B, LED_CONTROL_PIN, RGB>(LED_Strip, TOTAL_NUMBER_LEDS_AT_SRIP);
  FastLED.setBrightness(DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL);
  FastLED.clear();
  
  timer1.start();

  Serial.begin(115200);  

  while (!Serial)
  {
    ;
  }
  Blinky_Time = 100;
  Initial_Time = millis();
  Brightness_Level = 128;
}

void loop()
{
  timer1.update();
  
  while (Serial.available())
  {
     number_bytes_received = Serial.readBytes(UART_Buffer, UART_BUFFER_SIZE);
  }

  if (number_bytes_received > 0) {    

    static uint8_t box_number = atoi(Extract_Parameter_Value(UART_Buffer, ',', 0));
    static uint8_t drawer_number = atoi(Extract_Parameter_Value(UART_Buffer, ',', 1));
    static unsigned long hex_color = atol(Extract_Parameter_Value(UART_Buffer, ',', 2));
    static uint8_t brightness_level = atoi(Extract_Parameter_Value(UART_Buffer, ',', 3));
    static uint16_t blinky_time = atoi(Extract_Parameter_Value(UART_Buffer, ',', 4));
    
    uint16_t led = Get_LED_Strip_Number(box_number, drawer_number);
    SETUP_Highlight(led, hex_color, brightness_level, blinky_time);

     
    sprintf(r, "%d, %lu, %d, %d", led, hex_color, brightness_level, blinky_time) ;
    Serial.println(r);
  }
}

char* Extract_Parameter_Value(String input, char separator, int index)
{
  int found = 0;
  int strIndex[] = { 0, -1 };
  int maxIndex = input.length() - 1;
  char buf[50] = {0};
  char buf2[1] = {0};

  for (int i = 0; i <= maxIndex && found <= index; i++) {
    if (input.charAt(i) == separator || i == maxIndex) {
      found++;
      strIndex[0] = strIndex[1] + 1;
      strIndex[1] = (i == maxIndex) ? i + 1 : i;
    }
  }

  String s = input.substring(strIndex[0], strIndex[1]);
  s.toCharArray(buf, s.length()+1);
  return (found > index) ? buf : buf2;
}

uint16_t Get_LED_Strip_Number(uint8_t box_number, uint8_t drawer_number)
{
  if (drawer_number > 0)
    return ((box_number * NUMBER_LED_Strip_PER_BOX) - NUMBER_LED_Strip_PER_BOX) + drawer_number - 1;  
}

void SETUP_Highlight(uint16_t led_position, unsigned long hex_color, uint8_t brightness_level, uint16_t blinky_time)
{
  LED_Position = led_position;
  Color_HEX = hex_color;
  Brightness_Level = brightness_level;
  Blinky_Time = blinky_time;
  Initial_Time = millis();

 
}

void ISR_Highlight_Drawer()
{  
  if(Change_LED_State == true)
  {   
    LED_Strip[LED_Position] = CRGB::Red;//CRGB(Color_HEX);
    FastLED.setBrightness(Brightness_Level);
    FastLED.show();
  }
  else
  {  
    LED_Strip[LED_Position]  = CRGB::Black;
    FastLED.show();
  }

  if ( (millis() - Initial_Time) >= Blinky_Time)
  {     
  Initial_Time = millis();
  
  if(Change_LED_State)
    Change_LED_State = false;
  else
    Change_LED_State = true;      
  }
}