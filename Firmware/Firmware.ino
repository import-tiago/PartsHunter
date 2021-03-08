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
char UART_Buffer[UART_BUFFER_SIZE + 1];
uint8_t Box_Number;
uint8_t Drawer_Number;
CRGB Color_HEX;
uint8_t Brightness_Level;
uint16_t Blinky_Time;
uint32_t Last_Time = 0;
bool Change_LED_State = true;
char array[30] = {0};
String Hardware_Device_String;
char Hardware_Device_Array[FIREBASE_MESSAGE_SIZE];


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

  Serial.begin(115200);
  
  while (!Serial) {
    ;
  }
  
  FastLED.addLeds<WS2812B, LED_CONTROL_PIN, GRB>(LED_Strip, TOTAL_NUMBER_LEDS_AT_SRIP);
  FastLED.setBrightness(DEFAULT_LED_STRIP_BRIGHTNESS_LEVEL);
  FastLED.clear();

  timer1.attach(0.05, ISR_Highlight_Drawer);  //50 mili-seconds overflow

  //WiFi_Connect(WIFI_SSID, WIFI_PASSWORD);
  WiFi_Connect("Tiago", "tiago1234");
  
  Firebase_Connect(FIREBASE_HOST, API_KEY, USER_EMAIL, USER_PASSWORD);
  
  Blinky_Time = 100;
  Last_Time = millis();
  Brightness_Level = 128;

  char* a = "a";
  String b = "b";
  char c[2] = {'c', '\0'} ;

/*
    Firebase.RTDB.setString(&fbdo, "/HardwareDevice", a);
    delay(2000);
    Firebase.RTDB.setString(&fbdo, "/HardwareDevice", b);
    delay(2000);
    Firebase.RTDB.setString(&fbdo, "/HardwareDevice", c);
    delay(2000);
    */
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
      
      SETUP_ISR_Highlight(led_position, red_color, green_color, blue_color, brightness_level, blinky_time);

      /////////////////////////////////////////////////////
      
      char teste[30] = {0};
      int len = strlen(UART_Buffer);
      int i=0;
      for(i = 0; i<len; i++){
        teste[i] = UART_Buffer[i];
      }

      // teste[++i] = '\0';
       
      
    
      Firebase.RTDB.setString(&fbdo, "/HardwareDevice", &teste);
      printResult(fbdo);

      //Serial.println(teste);
    }
  }
}

void Firebase_Commands_Monitor() {
  
  Hardware_Device_String = Get_Firebase_String_from("/HardwareDevice");
  
  Hardware_Device_String.toCharArray(Hardware_Device_Array, FIREBASE_MESSAGE_SIZE);
  
  int16_t drawer_number = atoi(Extract_Parameter_Value(Hardware_Device_Array, ',', 0));
  uint8_t red_color = atoi(Extract_Parameter_Value(Hardware_Device_Array, ',', 1));
  uint8_t green_color = atoi(Extract_Parameter_Value(Hardware_Device_Array, ',', 2));
  uint8_t blue_color = atoi(Extract_Parameter_Value(Hardware_Device_Array, ',', 3));
  uint8_t brightness_level = atoi(Extract_Parameter_Value(Hardware_Device_Array, ',', 4));
  uint16_t blinky_time = atoi(Extract_Parameter_Value(Hardware_Device_Array, ',', 5));
  
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
      
      SETUP_ISR_Highlight(led_position, red_color, green_color, blue_color, brightness_level, blinky_time);
    }
}

String WiFi_Connect(String SSID, String Password) {
  
  WiFi.begin(SSID, Password);
  
  Serial.println("WiFi Connecting");
  
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(300);
  }
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
















#if defined(ESP8266)
  //Set the size of WiFi rx/tx buffers in the case where we want to work with large data.
  fbdo.setBSSLBufferSize(1024, 1024);
#endif

  //Set the size of HTTP response buffers in the case where we want to work with large data.
  fbdo.setResponseSize(1024);

  //Set database read timeout to 1 minute (max 15 minutes)
  //Firebase.RTDB.setReadTimeout(&fbdo, 1000 * 60);
  //tiny, small, medium, large and unlimited.
  //Size and its write timeout e.g. tiny (1s), small (10s), medium (30s) and large (60s).
  //Firebase.RTDB.setwriteSizeLimit(&fbdo, "tiny");

  //optional, set the decimal places for float and double data to be stored in database
  //Firebase.setFloatDigits(2);
  //Firebase.setDoubleDigits(6);

  /*
  This option allows get and delete functions (PUT and DELETE HTTP requests) works for device connected behind the
  Firewall that allows only GET and POST requests.
  */
  //Firebase.enableClassicRequest(fbdo, true);
  




  
}

String Get_Firebase_String_from(char* Database_Path) {
  
  String result;
  
  if(Firebase.RTDB.getString(&fbdo, Database_Path))
    result = fbdo.stringData();  
  else
    result = fbdo.errorReason();  
  
  return result;
}

void Set_Firebase_String_at(char* Database_Path, String data) {

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

void printResult(FirebaseData &data)
{

  if (data.dataType() == "int")
    Serial.println(data.intData());
  else if (data.dataType() == "float")
    Serial.println(data.floatData(), 5);
  else if (data.dataType() == "double")
    printf("%.9lf\n", data.doubleData());
  else if (data.dataType() == "boolean")
    Serial.println(data.boolData() == 1 ? "true" : "false");
  else if (data.dataType() == "string")
    Serial.println(data.stringData());
  else if (data.dataType() == "json")
  {
    Serial.println();
    FirebaseJson &json = data.jsonObject();
    //Print all object data
    Serial.println("Pretty printed JSON data:");
    String jsonStr;
    json.toString(jsonStr, true);
    Serial.println(jsonStr);
    Serial.println();
    Serial.println("Iterate JSON data:");
    Serial.println();
    size_t len = json.iteratorBegin();
    String key, value = "";
    int type = 0;
    for (size_t i = 0; i < len; i++)
    {
      json.iteratorGet(i, type, key, value);
      Serial.print(i);
      Serial.print(", ");
      Serial.print("Type: ");
      Serial.print(type == FirebaseJson::JSON_OBJECT ? "object" : "array");
      if (type == FirebaseJson::JSON_OBJECT)
      {
        Serial.print(", Key: ");
        Serial.print(key);
      }
      Serial.print(", Value: ");
      Serial.println(value);
    }
    json.iteratorEnd();
  }
  else if (data.dataType() == "array")
  {
    Serial.println();
    //get array data from FirebaseData using FirebaseJsonArray object
    FirebaseJsonArray &arr = data.jsonArray();
    //Print all array values
    Serial.println("Pretty printed Array:");
    String arrStr;
    arr.toString(arrStr, true);
    Serial.println(arrStr);
    Serial.println();
    Serial.println("Iterate array values:");
    Serial.println();
    for (size_t i = 0; i < arr.size(); i++)
    {
      Serial.print(i);
      Serial.print(", Value: ");

      FirebaseJsonData &jsonData = data.jsonData();
      //Get the result data from FirebaseJsonArray object
      arr.get(jsonData, i);
      if (jsonData.typeNum == FirebaseJson::JSON_BOOL)
        Serial.println(jsonData.boolValue ? "true" : "false");
      else if (jsonData.typeNum == FirebaseJson::JSON_INT)
        Serial.println(jsonData.intValue);
      else if (jsonData.typeNum == FirebaseJson::JSON_FLOAT)
        Serial.println(jsonData.floatValue);
      else if (jsonData.typeNum == FirebaseJson::JSON_DOUBLE)
        printf("%.9lf\n", jsonData.doubleValue);
      else if (jsonData.typeNum == FirebaseJson::JSON_STRING ||
               jsonData.typeNum == FirebaseJson::JSON_NULL ||
               jsonData.typeNum == FirebaseJson::JSON_OBJECT ||
               jsonData.typeNum == FirebaseJson::JSON_ARRAY)
        Serial.println(jsonData.stringValue);
    }
  }
  else if (data.dataType() == "blob")
  {

    Serial.println();

    for (size_t i = 0; i < data.blobData().size(); i++)
    {
      if (i > 0 && i % 16 == 0)
        Serial.println();

      if (i < 16)
        Serial.print("0");

      Serial.print(data.blobData()[i], HEX);
      Serial.print(" ");
    }
    Serial.println();
  }
  else if (data.dataType() == "file")
  {

    Serial.println();

    File file = data.fileStream();
    int i = 0;

    while (file.available())
    {
      if (i > 0 && i % 16 == 0)
        Serial.println();

      int v = file.read();

      if (v < 16)
        Serial.print("0");

      Serial.print(v, HEX);
      Serial.print(" ");
      i++;
    }
    Serial.println();
    file.close();
  }
  else
  {
    Serial.println(data.payload());
  }
}
