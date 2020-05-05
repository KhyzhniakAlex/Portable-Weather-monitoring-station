#include <ArduinoJson.h>
#include <Adafruit_BMP280.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <DHT.h>

#define DHTTYPE DHT22

const char* ssid = "xxxcccmmm";
const char* password = "23091994";
const char* post_url = "http://weatheranalyzertelegrambotserver.azurewebsites.net/api/sensorData";

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

  WiFi.mode(WIFI_OFF);
  delay(1000);
  WiFi.mode(WIFI_STA);
  Serial.print("\nConnecting to " + String(ssid));
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  
  Serial.println("\nWiFi connected");
  Serial.print("\nESP IP = ");
  Serial.print(WiFi.localIP());
  Serial.println();
}

void loop(void)
{
  HTTPClient http;
  while(!http.begin(post_url))
  {
    Serial.println("Could connect to backend server");
    delay(2500);
  }
  http.addHeader("Content-Type", "application/json");

  JSONBuild();
  String json;
  serializeJsonPretty(doc, json);
  int httpCode = http.POST(json);
  String payload = http.getString();
  
  Serial.println("httpCode = " + String(httpCode));
  Serial.println("---------------------------------");

  http.end();

  delay(10000);
}

void JSONBuild()
{
  float temperature = dht.readTemperature();
  float humidity = dht.readHumidity();
  float heatIndex = dht.computeHeatIndex(temperature, humidity, false);
  float pressure = bmp.readPressure() / 133.33;
  float temperatureBMP280 = bmp.readTemperature();

  setJsonObject(temperature, humidity, heatIndex, pressure, temperatureBMP280);
  displayOnPortMonitor(temperature, humidity, heatIndex, pressure, temperatureBMP280);
}



void displayOnPortMonitor(float temperatureDHT, float humidity, float heatIndex, float pressure, float temperatureBMP)
{
  Serial.println("DHT22:");
  Serial.println("  Temperature: " + String(temperatureDHT) + "*C");
  Serial.println("  Humidity: " + String(humidity) + "%");
  Serial.println("  Heat Index: " + String(heatIndex) + "*C");

  Serial.println("BMP280:");
  Serial.println("  Pressure: " + String(pressure) + "mm Hg");
  Serial.println("  Temperature: " + String(temperatureBMP) + "*C");
  Serial.println("---------------------------------");
}

void setJsonObject(float temperatureDHT, float humidity, float heatIndex, float pressure, float temperatureBMP) {
  doc["temperatureDHT"] = temperatureDHT;
  doc["humidity"] = humidity;
  doc["heatIndex"] = heatIndex;
  doc["pressure"] = pressure;
  doc["temperatureBMP"] = temperatureBMP;
}
