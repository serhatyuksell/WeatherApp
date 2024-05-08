using System;
using System.Xml.Linq;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir şehir adı girin:");
            string city = Console.ReadLine();
            string api = "e1da852ecc5df05d42494b7973419edc";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument weather = XDocument.Load(connection);

            var temperature = weather.Descendants("temperature").FirstOrDefault()?.Attribute("value")?.Value;
            var weathercase = weather.Descendants("weather").FirstOrDefault()?.Attribute("value")?.Value;

            if (temperature != null && weathercase != null)
            {
                Console.WriteLine(city + " için sıcaklık: " + temperature + " Hava durumu: " + weathercase);
            }
            else
            {
                Console.WriteLine("Hava durumu bilgisi alınamadı.");
            }

            Console.ReadLine();
        }
    }
}
