#include <Adafruit_BMP280.h>
#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <Wire.h>
#include <DHT.h>

#define DHTTYPE DHT22

const char* ssid = "xxxcccmmm";
const char* password = "23091994";
ESP8266WebServer server(80);

const int DHTPin = 13;

DHT dht(DHTPin, DHTTYPE);
Adafruit_BMP280 bmp; // I2C

static char celsiusWeb[7];
static char fahrenheitWeb[7];
static char humidityWeb[7];
static char pressureHgWeb[10];
static char altitudeWeb[10];
static char celsiusWebBMP[7];

String webPage = "";

void setup() {
  Serial.begin(115200);
  delay(10);

  dht.begin();
  while (!bmp.begin()) {
    Serial.println(F("Could not find a valid BMP280 sensor, check wiring!"));
    delay(3000);
  }

  Serial.print("\nConnecting to ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected");
  
  server.on("/", [](){
    WebBuild();
    server.send(200, "text/html", webPage);
  });

  server.begin();
  Serial.println("Web server running. Waiting for the ESP IP...");
  delay(2000);

  Serial.println(WiFi.localIP());
}

void loop(void) {
  server.handleClient();
}

void WebBuild() {
  float humidityValue = dht.readHumidity();
  float celsiusValue = dht.readTemperature();
  // считываем температуру в Фаренгейтах (isFahrenheit = true):
  float fahrenheitValue = dht.readTemperature(true);

  float pressureValue = bmp.readPressure() / 133.33;
  float altitudeValue = bmp.readAltitude(1013.25);
  float celsiusValueBMP280 = bmp.readTemperature();

  bool temp;

  temp = isnan(humidityValue) ? strcpy(celsiusWeb, "Failed") : dtostrf(humidityValue, 6, 2, humidityWeb);
  temp = isnan(celsiusValue) ? strcpy(celsiusWeb, "Failed") : dtostrf(celsiusValue, 6, 2, celsiusWeb);
  temp = isnan(fahrenheitValue) ? strcpy(fahrenheitWeb, "Failed") : dtostrf(fahrenheitValue, 6, 2, fahrenheitWeb);
  temp = isnan(pressureValue) ? strcpy(pressureHgWeb, "Failed") : dtostrf(pressureValue, 6, 2, pressureHgWeb);
  temp = isnan(altitudeValue) ? strcpy(altitudeWeb, "Failed") : dtostrf(altitudeValue, 6, 2, altitudeWeb);
  temp = isnan(celsiusValueBMP280) ? strcpy(celsiusWebBMP, "Failed") : dtostrf(celsiusValueBMP280, 6, 2, celsiusWebBMP);
  
//  if (isnan(humidityValue) && isnan(celsiusValue) && isnan(fahrenheitValue)) {
//    strcpy(celsiusWeb, "Failed");
//    strcpy(fahrenheitWeb, "Failed");
//    strcpy(humidityWeb, "Failed");
//  }
//  else if (isnan(pressureValue) || isnan(altitudeValue) || isnan(celsiusValueBMP280)) {
//    strcpy(pressureHgWeb, "Failed");
//    strcpy(altitudeWeb, "Failed");
//    strcpy(celsiusWebBMP, "Failed");
//  }
//  else {
//    dtostrf(celsiusValue, 6, 2, celsiusWeb);
//    dtostrf(fahrenheitValue, 6, 2, fahrenheitWeb);
//    dtostrf(humidityValue, 6, 2, humidityWeb);
//
//    dtostrf(pressureValue, 6, 2, pressureHgWeb);
//    dtostrf(altitudeValue, 6, 2, altitudeWeb);
//    dtostrf(celsiusValueBMP280, 6, 2, celsiusWebBMP);
//
//    displayOnPortMonitor(celsiusValue, fahrenheitValue, humidityValue, pressureValue, altitudeValue, celsiusValueBMP280);
//  }
  displayOnPortMonitor(celsiusValue, fahrenheitValue, humidityValue, pressureValue, altitudeValue, celsiusValueBMP280);
  sendToServer(celsiusWeb, fahrenheitWeb, humidityWeb, pressureHgWeb, altitudeWeb, celsiusWebBMP);
}



void displayOnPortMonitor(float humidity, float celsius, float fahrenheit, float pressureHg, float altitude, float celsiusBMP280) {
  Serial.println(F("DHT22:"));

  Serial.print(F("  Humidity: "));
  Serial.print(humidity);
  Serial.println("%");

  Serial.println(F("  Temperature:"));
  Serial.print(F("    Celsius: "));
  Serial.print(celsius);
  Serial.println("*C");
  Serial.print(F("    Fahrenheit: "));
  Serial.print(fahrenheit);
  Serial.println("*F");

  Serial.println(F("BMP280:"));

  Serial.print(F("  Pressure: "));
  Serial.print(pressureHg);
  Serial.println("mm Hg");
  Serial.print(F("  Altitude: "));
  Serial.print(altitude);
  Serial.println("m");
  Serial.print(F("  Celsius: "));
  Serial.print(celsiusBMP280);
  Serial.println("*C");
  Serial.println("---------------------------------");
}



void sendToServer(char* celsius, char* fahrenheit, char* humidity, char* pressureHg, char* altitude, char* celsiusBMP) {
  webPage += "DHT22";
  webPage += "Temperature in Celsius: " + String(celsius);
  webPage += "Temperature in Fahrenheit: " + String(fahrenheit);
  webPage += "Humidity: " + String(humidity);
  webPage += "BMP280";
  webPage += "Temperature in Celsius: " + String(celsiusBMP);
  webPage += "Pressure: " + String(pressureHg);  
  webPage += "Altitude: " + String(altitude);  
}
