#include <Adafruit_BMP280.h>
#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <Wire.h>
#include <DHT.h>

#define DHTTYPE DHT22

#define allData 0
#define dhtCelsius 1
#define dhtFahrenheit 2
#define dhtHumidity 3
#define dhtCelsiusHeatIndex 4
#define dhtFahrenheitHeatIndex 5
#define bmpCelsius 6
#define bmpPressure 7
#define bmpAltitude 8

const char* ssid = "xxxcccmmm";
const char* password = "23091994";
ESP8266WebServer server(80);

const int DHTPin = 13;

DHT dht(DHTPin, DHTTYPE);
Adafruit_BMP280 bmp; // I2C

static char celsiusWeb[7];
static char fahrenheitWeb[7];
static char humidityWeb[7];
static char celsiusHeatIndexWeb[8];
static char fahrenheitHeatIndexWeb[8];
static char pressureHgWeb[10];
static char altitudeWeb[10];
static char celsiusWebBMP[7];

void setup() 
{
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

  setUpEndpoints();

  server.begin();
  Serial.println("Web server running. Waiting for the ESP IP...");
  delay(2000);

  Serial.println(WiFi.localIP());
}

void loop(void) 
{
  server.handleClient();
}

void setUpEndpoints() 
{
  server.on("/", [](){
    String webPageValue = WebBuild(0);
    server.send(200, "text/html", webPageValue);
  });
  
  server.on("/dhtCelsius", [](){
    String webPageValue = WebBuild(1);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/dhtFahrenheit", [](){
    String webPageValue = WebBuild(2);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/dhtHumidity", [](){
    String webPageValue = WebBuild(3);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/dhtCelsiusHeatIndex", [](){
    String webPageValue = WebBuild(4);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/dhtFahrenheitHeatIndex", [](){
    String webPageValue = WebBuild(5);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/bmpCelsius", [](){
    String webPageValue = WebBuild(6);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/bmpPressure", [](){
    String webPageValue = WebBuild(7);
    server.send(200, "text/html", webPageValue);
  });

  server.on("/bmpAltitude", [](){
    String webPageValue = WebBuild(8);
    server.send(200, "text/html", webPageValue);
  });
}

String WebBuild(int endpointNumber) 
{
  float humidityValue = dht.readHumidity();
  float celsiusValue = dht.readTemperature();
  // считываем температуру в Фаренгейтах (isFahrenheit = true):
  float fahrenheitValue = dht.readTemperature(true);
  float celsiusHeatIndexValue = dht.computeHeatIndex(celsiusValue, humidityValue, false);
  float fahrenheitHeatIndexValue = dht.computeHeatIndex(fahrenheitValue, humidityValue);

  float pressureValue = bmp.readPressure() / 133.33;
  float altitudeValue = bmp.readAltitude(1013.25);
  float celsiusValueBMP280 = bmp.readTemperature();

  bool temp;
  String webPageValue = "";
  switch(endpointNumber) 
  {
    case dhtCelsius:
      temp = isnan(celsiusValue) ? strcpy(celsiusWeb, "Failed") : dtostrf(celsiusValue, 6, 2, celsiusWeb);
      webPageValue = setWebPageData("DHT22 Temperature in Celsius: ", celsiusWeb, false);
      break;
    case dhtFahrenheit:
      temp = isnan(fahrenheitValue) ? strcpy(fahrenheitWeb, "Failed") : dtostrf(fahrenheitValue, 6, 2, fahrenheitWeb);
      webPageValue = setWebPageData("DHT22 Temperature in Fahrenheit: ", fahrenheitWeb, false);
      break;
    case dhtHumidity:
      temp = isnan(humidityValue) ? strcpy(celsiusWeb, "Failed") : dtostrf(humidityValue, 6, 2, humidityWeb);
      webPageValue = setWebPageData("DHT22 Humidity: ", humidityWeb, false);
      break;
    case dhtCelsiusHeatIndex:
      temp = isnan(celsiusHeatIndexValue) ? strcpy(celsiusHeatIndexWeb, "Failed") : dtostrf(celsiusHeatIndexValue, 6, 2, celsiusHeatIndexWeb);
      webPageValue = setWebPageData("DHT22 Celsius Heat Index: ", celsiusHeatIndexWeb, false);
      break;
    case dhtFahrenheitHeatIndex:
      temp = isnan(fahrenheitHeatIndexValue) ? strcpy(fahrenheitHeatIndexWeb, "Failed") : dtostrf(fahrenheitHeatIndexValue, 6, 2, fahrenheitHeatIndexWeb);
      webPageValue = setWebPageData("DHT22 Fahrenheit Heat Index: ", fahrenheitHeatIndexWeb, false);
      break;
    case bmpPressure:
      temp = isnan(pressureValue) ? strcpy(pressureHgWeb, "Failed") : dtostrf(pressureValue, 6, 2, pressureHgWeb);
      webPageValue = setWebPageData("BMP280 Pressure in mm HG: ", pressureHgWeb, false);
      break;
    case bmpAltitude:
      temp = isnan(altitudeValue) ? strcpy(altitudeWeb, "Failed") : dtostrf(altitudeValue, 6, 2, altitudeWeb);
      webPageValue = setWebPageData("BMP280 Altitude: ", altitudeWeb, false);
      break;
    case bmpCelsius:
      temp = isnan(celsiusValueBMP280) ? strcpy(celsiusWebBMP, "Failed") : dtostrf(celsiusValueBMP280, 6, 2, celsiusWebBMP);
      webPageValue = setWebPageData("BMP280 Temperature in Celsius: ", celsiusWebBMP, false);
      break;
    case allData:
      temp = isnan(celsiusValue) ? strcpy(celsiusWeb, "Failed") : dtostrf(celsiusValue, 6, 2, celsiusWeb);
      temp = isnan(fahrenheitValue) ? strcpy(fahrenheitWeb, "Failed") : dtostrf(fahrenheitValue, 6, 2, fahrenheitWeb);
      temp = isnan(humidityValue) ? strcpy(celsiusWeb, "Failed") : dtostrf(humidityValue, 6, 2, humidityWeb);
      temp = isnan(celsiusHeatIndexValue) ? strcpy(celsiusHeatIndexWeb, "Failed") : dtostrf(celsiusHeatIndexValue, 6, 2, celsiusHeatIndexWeb);
      temp = isnan(fahrenheitHeatIndexValue) ? strcpy(fahrenheitHeatIndexWeb, "Failed") : dtostrf(fahrenheitHeatIndexValue, 6, 2, fahrenheitHeatIndexWeb);
      temp = isnan(pressureValue) ? strcpy(pressureHgWeb, "Failed") : dtostrf(pressureValue, 6, 2, pressureHgWeb);
      temp = isnan(altitudeValue) ? strcpy(altitudeWeb, "Failed") : dtostrf(altitudeValue, 6, 2, altitudeWeb);
      temp = isnan(celsiusValueBMP280) ? strcpy(celsiusWebBMP, "Failed") : dtostrf(celsiusValueBMP280, 6, 2, celsiusWebBMP);
      webPageValue += setWebPageData("DHT22 Temperature in Celsius: ", celsiusWeb, true);
      webPageValue += setWebPageData("DHT22 Temperature in Fahrenheit: ", fahrenheitWeb, true);
      webPageValue += setWebPageData("DHT22 Humidity: ", humidityWeb, true);
      webPageValue += setWebPageData("DHT22 Celsius Heat Index: ", celsiusHeatIndexWeb, true);
      webPageValue += setWebPageData("DHT22 Fahrenheit Heat Index: ", fahrenheitHeatIndexWeb, true);
      webPageValue += setWebPageData("BMP280 Pressure in mm HG: ", pressureHgWeb, true);
      webPageValue += setWebPageData("BMP280 Altitude: ", altitudeWeb, true);
      webPageValue += setWebPageData("BMP280 Temperature in Celsius: ", celsiusWebBMP, true);
      break;
  }
  
  displayOnPortMonitor(celsiusValue, fahrenheitValue, humidityValue, celsiusHeatIndexValue, fahrenheitHeatIndexValue, pressureValue, altitudeValue, celsiusValueBMP280);
  return webPageValue;
}



void displayOnPortMonitor(float celsius, float fahrenheit, float humidity, float celsiusHeatIndex, float fahrenheitHeatIndex, float pressureHg, float altitude, float celsiusBMP280) 
{
  Serial.println("DHT22:");
  Serial.println("  Humidity: " + String(humidity) + "%");
  Serial.println("  Temperature:");
  Serial.println("    Celsius: " + String(celsius) + "*C");
  Serial.println("    Fahrenheit: " + String(fahrenheit) + "*F");
  Serial.println("  Heat Index:");
  Serial.println("    Celsius: " + String(celsiusHeatIndex) + "*C");
  Serial.println("    Fahrenheit: " + String(fahrenheitHeatIndex) + "*F");

  Serial.println("BMP280:");
  Serial.println("  Pressure: " + String(pressureHg) + "mm Hg");
  Serial.println("  Altitude: " + String(altitude) + "m");
  Serial.println("  Celsius: " + String(celsiusBMP280) + "*C");
  Serial.println("---------------------------------");
}

String setWebPageData(String description, char* sensorData, bool isNewLine) 
{
  return isNewLine ? description + String(sensorData) + "</br>" : description + String(sensorData);
}
