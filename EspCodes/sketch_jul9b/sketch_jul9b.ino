#include <Arduino.h>
#if defined(ESP32)
  #include <WiFi.h>
#elif defined(ESP8266)
  #include <ESP8266WiFi.h>
#endif
#include <Firebase_ESP_Client.h>

//Provide the token generation process info.
#include "addons/TokenHelper.h"
//Provide the RTDB payload printing info and other helper functions.
#include "addons/RTDBHelper.h"

// Insert your network credentials
#define WIFI_SSID "INNO-FEIT"
#define WIFI_PASSWORD "innoFEIT"

// Insert Firebase project API Key
#define API_KEY "AIzaSyDmsozQVr5CAUeWKKsI-vE29ITnGVmrUuI"

// Insert RTDB URLefine the RTDB URL */
#define DATABASE_URL "https://espmodule-16619-default-rtdb.firebaseio.com/" 

//Define Firebase Data object
FirebaseData fbdo;

FirebaseAuth auth;
FirebaseConfig config;

unsigned long sendDataPrevMillis = 0;
int intValue;
float floatValue;
bool signupOK = false;
bool boolValue=false;

void setup() {
  Serial.begin(115200);
  pinMode(D1,OUTPUT);
  pinMode(D2,OUTPUT);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("Connecting to Wi-Fi");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(300);
  }
  Serial.println();
  Serial.print("Connected with IP: ");
  Serial.println(WiFi.localIP());
  Serial.println();

  /* Assign the api key (required) */
  config.api_key = API_KEY;

  /* Assign the RTDB URL (required) */
  config.database_url = DATABASE_URL;

  /* Sign up */
  if (Firebase.signUp(&config, &auth, "", "")) {
    Serial.println("ok");
    signupOK = true;
  }
  else {
    Serial.printf("%s\n", config.signer.signupError.message.c_str());
  }

  /* Assign the callback function for the long running token generation task */
  config.token_status_callback = tokenStatusCallback; //see addons/TokenHelper.h

  Firebase.begin(&config, &auth);
  Firebase.reconnectWiFi(true);
}

void loop() {
  //Serial.println("Start loop...");
  if (Firebase.ready() && signupOK && (millis() - sendDataPrevMillis > 3000 || sendDataPrevMillis == 0)) {
    sendDataPrevMillis = millis();
      Serial.println("Connected to firebase.. getting data...");
    if (Firebase.RTDB.getInt(&fbdo, "/EspTEST/-NAAMmUh8UnOICwGadBp/IsActive")) {
      if (fbdo.dataType() == "int") {
        intValue = fbdo.intData();
        Serial.println(intValue);
        if(intValue==1){
          digitalWrite(D1,LOW);
          Serial.println("D1:Has Light. ;)");
        }else if(intValue==0){
          digitalWrite(D1,HIGH);
          Serial.println("D1: to HIGH");
        }
        delay(30);
      }
    }

    if (Firebase.RTDB.getInt(&fbdo, "/EspTEST/-NAAYpABzsPP8XZAdMLE/IsActive")) {
      if (fbdo.dataType() == "int") {
        intValue = fbdo.intData();
        Serial.println(intValue);
        if(intValue==1){
          digitalWrite(D2,LOW);
          Serial.println("D2:Has Light. ;)");
        }else if(intValue==0){
          digitalWrite(D2,HIGH);
          Serial.println("D2: to HIGH");
        }
        delay(30);
      }
    }
    else {
      Serial.println(fbdo.errorReason());
    }
    
   if (Firebase.ready() && signupOK && (millis() - sendDataPrevMillis > 3000 || sendDataPrevMillis == 0)) {
    sendDataPrevMillis = millis();
      Serial.println("Connected to firebase.. getting data...");
    if (Firebase.RTDB.getInt(&fbdo, "/EspTEST/-NAAYpABzsPP8XZAdMLE/IsActive")) {
      if (fbdo.dataType() == "int") {
        intValue = fbdo.intData();
        Serial.println(intValue);
        if(intValue==1){
          digitalWrite(D2,LOW);
          Serial.println("D2:Has Light. ;)");
        }else if(intValue==0){
          digitalWrite(D2,HIGH);
          Serial.println("D2: to HIGH");
        }
        delay(30);
      }
    }
    else {
      Serial.println(fbdo.errorReason());
    }


   

   
  }
  //Serial.println("... end loop.");
}
}