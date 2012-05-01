#region Copyright
/**************************************
Copyright 2012 Mark Arnott

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
**************************************/
#endregion
using System;
using ExampleClient.MsdnDataBindingScenarioSampleClient;
using XslTransformMessageInspector;

namespace Example.Client
{
    class Program
    {
        private static WeatherServiceClient _client = new WeatherServiceClient();

        static void ShowWeatherData(WeatherServiceClient client, string[] localities)
        {
            WeatherData[] data = client.GetWeatherData(localities);

            foreach (WeatherData record in data)
            {
                Console.WriteLine("hi:{0}  lo:{1}  {2}", record.HighTemperature, record.LowTemperature, record.Locality);
            }
        }

        static void Main(string[] args)
        {
            string[] localities = { "Los Angeles", "Rio de Janeiro", "New York", "London" }; //, "Paris", "Rome", "Cairo", "Beijing" };


            Console.WriteLine("First Call - without Xsl Transformation\r\nTemperature in Farenheit : ");
            _client = new WeatherServiceClient();
            ShowWeatherData(_client, localities);


            Console.WriteLine("\r\n=====================\r\n");
            Console.WriteLine("Second Call - Xsl Transformation\r\nTemperature in Celsius : ");

            _client = new WeatherServiceClient();
            _client.Endpoint.Behaviors.Add(new XslTransformBehavior("ConvertToCelsius.xsl"));
            ShowWeatherData(_client, localities);

            Console.WriteLine("Done");
        }
    }
}
