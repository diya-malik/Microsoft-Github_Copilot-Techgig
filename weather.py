import requests
import json
import argparse

def get_weather(city):
    url = f"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=29b2b1560ddc82c9b42f5483d3b2a20d"
    response = requests.get(url)
    if response.status_code == 200:
        data = response.json()
        return data
    else:
        print("Error:", response.status_code)
        return None

def parse_weather_data(data):
    try:
        weather = data["weather"][0]["description"]
        temperature = data["main"]["temp"]
        humidity = data["main"]["humidity"]
        wind_speed = data["wind"]["speed"]
        return weather, temperature, humidity, wind_speed
    except (KeyError, IndexError):
        print("Error: Failed to parse weather data.")
        return None

def display_weather(city, weather_info):
    if weather_info is not None:
        weather, temperature, humidity, wind_speed = weather_info
        print(f"Weather in {city}: {weather}")
        print(f"Temperature: {temperature} K")
        print(f"Humidity: {humidity}%")
        print(f"Wind Speed: {wind_speed} m/s")
    else:
        print(f"Failed to retrieve weather data for {city}.")

def main():
    parser = argparse.ArgumentParser(description="Get the current weather forecast for a city.")
    parser.add_argument("city", help="City name")
    args = parser.parse_args()
    
    city = args.city

    weather_data = get_weather(city)
    if weather_data is not None:
        weather_info = parse_weather_data(weather_data)
        display_weather(city, weather_info)

if __name__ == "__main__":
    main()
