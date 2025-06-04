using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using Serilog;
using System.ComponentModel;
using System.Net;

namespace SensorLib
{
    public class ConnectionManager
    {
        // async ... Damit du await benutzen kannst
        // Task: Gibt an, dass diese Methode asynchron ist (vergleichbar mit void, aber für async)
        // HttpClient ... Erstellt ein Objekt, um HTTP-Anfragen zu machen
        // GetAsync ... sendet die Anfrage(wie im Browser)
        // await ... wartet auf die Antwort
        // EnsureSuccessStatusCode() ... wirft einen Fehler, wenn der Server z.B. 404 zurückgibt

        public static async Task<SensorData?> Main(string ipAddress)                  
        {
          

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"http://{ipAddress}/getMeasurements";
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    // var data = JsonSerializer.Deserialize<MyData>(responseBody);
                    if (responseBody == null)
                        throw new Exception("Received data is null");
                    SensorData sensorData = JsonSerializer.Deserialize<SensorData>(responseBody);
                    return sensorData;
                }
                catch
                {
                    MessageBox.Show("Ein Fehler ist im Connection Manager aufgetreten. IP-Adresse falsch?");
                    Log.Logger.Error("IP-Adresse ist falsch.");
                }
                return null;
            }

        }
    }
}
