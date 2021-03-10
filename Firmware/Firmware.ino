//Arduino Libraries
#include <Arduino.h>

//External Libraries
#include <FastLED.h>
#include <Ticker.h>
#include <ESP8266WiFi.h>
#include <Firebase_ESP_Client.h>


//Own Libraries
#include "Auth_Secrets.h"


//External Hardware Definitions
#define LED_CONTROL_PIN 2


//Application Definitions
#define DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL 150
#define TOTAL_NUMBER_LEDS_AT_SRIP 600
#define UART_BUFFER_SIZE 30
#define FIREBASE_MESSAGE_SIZE 30


//Function Prototypes
char *Extract_Parameter_Value(String input, char separator, int index);
void SETUP_ISR_Highlight(uint16_t led_position, uint8_t red_color, uint8_t green_color, uint8_t blue_color, uint8_t brightness_level, uint16_t blinky_time);
void ISR_Highlight_Drawer();
String WiFi_Connect(String SSID, String Password);
void Firebase_Connect(char* Database_URL, char* API_Key, char* Account_Email, char* Account_Password);
String Get_Firebase_String_from(char* Database_Path);
void _DEBUG(int16_t _drawer_number, uint8_t _red_color,  uint8_t _green_color,  uint8_t _blue_color,  uint8_t _brightness_level, uint16_t _blinky_time);
void Set_Firebase_String_at(char* Database_Path, String data);


//Global Variables
String String_UART = "";
uint16_t LED_Position = 0;
char Data_from_UART_Array[UART_BUFFER_SIZE + 1];
uint8_t Box_Number;
uint8_t Drawer_Number;
CRGB Color_HEX;
uint8_t Brightness_Level;
uint16_t Blinky_Time;
uint32_t Last_Time = 0;
bool Change_LED_State = true;
char array[30] = {0};
String Hardware_Device_String;
char Data_from_Firebase_Array[FIREBASE_MESSAGE_SIZE];
String Current_Adjusts = "";
String Last_Adjusts = "";
int error = 0;

//Global Objects
CRGB LED_Strip[TOTAL_NUMBER_LEDS_AT_SRIP];

Ticker timer1;

/* Define FirebaseESP8266 data object for data sending and receiving */
FirebaseData fbdo;

/* Define the FirebaseAuth data for authentication data */
FirebaseAuth auth;

/* Define the FirebaseConfig data for config data */
FirebaseConfig config;


void setup() {
  wdt_enable(WDTO_2S);

  Serial.begin(115200);

  while (!Serial) {
    ;
  }

  FastLED.addLeds<WS2812B, LED_CONTROL_PIN, GRB>(LED_Strip, TOTAL_NUMBER_LEDS_AT_SRIP);
  FastLED.setBrightness(DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL);
  FastLED.clear();

  timer1.attach(0.05, ISR_Highlight_Drawer);  //50 mili-seconds overflow

  WiFi_Connect(WIFI_SSID, WIFI_PASSWORD);
  //WiFi_Connect("Tiago", "tiago1234");

  Firebase_Connect(FIREBASE_HOST, API_KEY, USER_EMAIL, USER_PASSWORD);

  Blinky_Time = 100;
  Last_Time = millis();
  Brightness_Level = 128;
}


void loop() {

  UART_Commands_Monitor();

  Firebase_Commands_Monitor();
}

void _DEBUG(int16_t _drawer_number, uint8_t _red_color,  uint8_t _green_color,  uint8_t _blue_color,  uint8_t _brightness_level, uint16_t _blinky_time) {

  Serial.print("drawer_number     = ");
  Serial.println(_drawer_number);

  Serial.print("red_color         = ");
  Serial.println(_red_color);

  Serial.print("green_color       = ");
  Serial.println(_green_color);

  Serial.print("blue_color        = ");
  Serial.println(_blue_color);

  Serial.print("brightness_level  = ");
  Serial.println(_brightness_level);

  Serial.print("blinky_time       = ");
  Serial.println(_blinky_time);

  Serial.println();
  Serial.println();
  Serial.println("==============================================");
}

void UART_Commands_Monitor() {

  uint8_t number_bytes_received = 0;

  while (Serial.available())
  {
    number_bytes_received = Serial.readBytes(Data_from_UART_Array, UART_BUFFER_SIZE);
  }

  if (number_bytes_received > 0)
  {
    Data_from_UART_Array[number_bytes_received] = 0;

    int16_t drawer_number = atoi(Extract_Parameter_Value(Data_from_UART_Array, ',', 0));
    uint8_t red_color = atoi(Extract_Parameter_Value(Data_from_UART_Array, ',', 1));
    uint8_t green_color = atoi(Extract_Parameter_Value(Data_from_UART_Array, ',', 2));
    uint8_t blue_color = atoi(Extract_Parameter_Value(Data_from_UART_Array, ',', 3));
    uint8_t brightness_level = atoi(Extract_Parameter_Value(Data_from_UART_Array, ',', 4));
    uint16_t blinky_time = atoi(Extract_Parameter_Value(Data_from_UART_Array, ',', 5));

    _DEBUG(drawer_number, red_color, green_color, blue_color, brightness_level, blinky_time);

    if (drawer_number < 0) // Turn-off all LEDs
    {
      red_color = 0;
      green_color = 0;
      blue_color = 0;

      Set_Firebase_String_at("/HardwareDevice", "-1,0,0,0,0,0");

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
    
    Current_Adjusts = String(Data_from_UART_Array);
    
    Serial.println("Current_Adjusts");
    Serial.println(Current_Adjusts);

      Set_Firebase_String_at("/HardwareDevice", Data_from_UART_Array);
    
    if(Current_Adjusts != Last_Adjusts)
    SETUP_ISR_Highlight(led_position, red_color, green_color, blue_color, brightness_level, blinky_time);
  
    Last_Adjusts = Current_Adjusts;
    
    Serial.println("Last_Adjusts");
    Serial.println(Last_Adjusts);

    }
    Serial.flush();
  }
}

void Firebase_Commands_Monitor() {

  Hardware_Device_String = Get_Firebase_String_from("/HardwareDevice");

  Hardware_Device_String.toCharArray(Data_from_Firebase_Array, FIREBASE_MESSAGE_SIZE);

  int16_t drawer_number = atoi(Extract_Parameter_Value(Data_from_Firebase_Array, ',', 0));
  uint8_t red_color = atoi(Extract_Parameter_Value(Data_from_Firebase_Array, ',', 1));
  uint8_t green_color = atoi(Extract_Parameter_Value(Data_from_Firebase_Array, ',', 2));
  uint8_t blue_color = atoi(Extract_Parameter_Value(Data_from_Firebase_Array, ',', 3));
  uint8_t brightness_level = atoi(Extract_Parameter_Value(Data_from_Firebase_Array, ',', 4));
  uint16_t blinky_time = atoi(Extract_Parameter_Value(Data_from_Firebase_Array, ',', 5));

  if(!drawer_number && !red_color && !green_color && !blue_color && !brightness_level && !blinky_time)
    error++;

    if(error >= 5)
      ESP.restart();

  _DEBUG(drawer_number, red_color, green_color, blue_color, brightness_level, blinky_time);

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
  
    Current_Adjusts = String(Data_from_Firebase_Array);

  if(Current_Adjusts != Last_Adjusts)
    SETUP_ISR_Highlight(led_position, red_color, green_color, blue_color, brightness_level, blinky_time);
  
  Last_Adjusts = Current_Adjusts;
  }
}

String WiFi_Connect(String SSID, String Password) {

  WiFi.begin(SSID, Password);

  Serial.println("WiFi Connecting");

  pinMode(2, OUTPUT);
  
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    digitalWrite(2, !digitalRead(2));
    delay(300);
  }
  digitalWrite(2, 1);
  
  Serial.println();
  Serial.println(WiFi.localIP());
}

void Firebase_Connect(char* Database_URL, char* API_Key, char* Account_Email, char* Account_Password) {

  /* Assign the project host and api key */
  config.host = Database_URL;
  config.api_key = API_Key;

  /* Assign the user sign in credentials */
  auth.user.email = Account_Email;
  auth.user.password = Account_Password;

  /* Initialize the library with the autentication data */
  Firebase.begin(&config, &auth);

  /* Enable auto reconnect the WiFi when connection lost */
  Firebase.reconnectWiFi(true);
}

String Get_Firebase_String_from(char* Database_Path) {

  String result;

  if (Firebase.RTDB.getString(&fbdo, Database_Path))
    result = fbdo.stringData();
  else
    result = fbdo.errorReason();

  return result;
}

void Set_Firebase_String_at(char* Database_Path, char* data) {

  int len = strlen(data) - 2;

  data[len] = '\0';

  Firebase.RTDB.setString(&fbdo, Database_Path, data);
}

char *Extract_Parameter_Value(String input, char separator, int index) {
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

void SETUP_ISR_Highlight(uint16_t led_position, uint8_t red_color, uint8_t green_color, uint8_t blue_color, uint8_t brightness_level, uint16_t blinky_time) {
  LED_Position = led_position;
  Color_HEX = CRGB(red_color, green_color, blue_color);
  Brightness_Level = brightness_level;
  Blinky_Time = blinky_time;
  FastLED.clear();
  FastLED.show();
  Last_Time = millis();
}

void ISR_Highlight_Drawer() {
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
