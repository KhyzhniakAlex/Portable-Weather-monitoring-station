#include <ArduinoJson.h>
#include <Adafruit_BMP280.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ESP8266WebServer.h>
#include <DHT.h>

#define DHTTYPE DHT22

const char* ssid = "xxxcccmmm";
const char* password = "23091994";
ESP8266WebServer server(80);
const char *post_url = "https://weatheranalyzertelegrambotserver.azurewebsites.net/getSensorsData";

const int DHTPin = 13;

DHT dht(DHTPin, DHTTYPE);
Adafruit_BMP280 bmp; // I2C

StaticJsonDocument<200> doc;

void setup()
{
  Serial.begin(115200);
  delay(10);

  dht.begin();
  while (!bmp.begin()) {
    Serial.println(F("Could not find a valid BMP280 sensor, check wiring!"));
    delay(3000);
  }

  Serial.print("\nConnecting to " + String(ssid));
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected");
  server.begin();

  Serial.print("\nESP IP = ");
  Serial.print(WiFi.localIP());
}

void loop(void)
{
  HTTPClient http;
  http.begin("http://192.168.0.110:9000/getSensorData");
  http.addHeader("Content-Type", "text/plain");
  
  JSONBuild();
  String json;
  serializeJsonPretty(doc, json);
  int httpCode = http.POST(json);
  String payload = http.getString();
  
  Serial.println("httpCode = " + String(httpCode));
  Serial.print("payload = " + String(payload));

  delay(15000);
}

void JSONBuild()
{
  float humidityValue = dht.readHumidity();
  float celsiusValue = dht.readTemperature();
  // считываем температуру в Фаренгейтах (isFahrenheit = true):
  float fahrenheitValue = dht.readTemperature(true);
  float celsiusHeatIndexValue = dht.computeHeatIndex(celsiusValue, humidityValue, false);
  float fahrenheitHeatIndexValue = dht.computeHeatIndex(fahrenheitValue, humidityValue);

  float pressureValue = bmp.readPressure() / 133.33;
  float celsiusValueBMP280 = bmp.readTemperature();

  setJsonObject(celsiusValue, fahrenheitValue, humidityValue, celsiusHeatIndexValue, fahrenheitHeatIndexValue, pressureValue, celsiusValueBMP280);
  displayOnPortMonitor(celsiusValue, fahrenheitValue, humidityValue, celsiusHeatIndexValue, fahrenheitHeatIndexValue, pressureValue, celsiusValueBMP280);
}



void displayOnPortMonitor(float celsiusDHT, float fahrenheit, float humidity, float celsiusHeatIndex, float fahrenheitHeatIndex, float pressure, float celsiusBMP280)
{
  Serial.println("DHT22:");
  Serial.println("  Humidity: " + String(humidity) + "%");
  Serial.println("  Temperature:");
  Serial.println("    Celsius: " + String(celsiusDHT) + "*C");
  Serial.println("    Fahrenheit: " + String(fahrenheit) + "*F");
  Serial.println("  Heat Index:");
  Serial.println("    Celsius: " + String(celsiusHeatIndex) + "*C");
  Serial.println("    Fahrenheit: " + String(fahrenheitHeatIndex) + "*F");

  Serial.println("BMP280:");
  Serial.println("  Pressure: " + String(pressure) + "mm Hg");
  Serial.println("  Celsius: " + String(celsiusBMP280) + "*C");
  Serial.println("---------------------------------");
}

void setJsonObject(float celsiusDHT, float fahrenheit, float humidity, float celsiusHeatIndex, float fahrenheitHeatIndex, float pressure, float celsiusBMP280) {
  doc["celsiusDHT"] = celsiusDHT;
  doc["fahrenheit"] = fahrenheit;
  doc["humidity"] = humidity;
  doc["celsiusHeatIndex"] = celsiusHeatIndex;
  doc["fahrenheitHeatIndex"] = fahrenheitHeatIndex;
  doc["pressure"] = pressure;
  doc["celsiusBMP280"] = celsiusBMP280;
}
