using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        // C:/Liste Cec/mun Chisinau/sector Botanica/****.pdf
        static void Main(string[] args)
        {
            var getCircumscriptionsUrl = "http://liste.cec.md/app/api/data/GetCircumscriptions";
            var webClient = new WebClient();
            var circuscriptionsJson = webClient.DownloadString(getCircumscriptionsUrl);
            var circumscriptionsList = JsonConvert.DeserializeObject<List<Circumscription>>(circuscriptionsJson);
          
            foreach (var circumscription in circumscriptionsList)
            {
                var getCircumscriptionRegionsUrl = $"http://liste.cec.md/app/api/data/GetRegions?circumscriptionId={circumscription.Key}";
                var circuscriptionRegionsJson = webClient.DownloadString(getCircumscriptionRegionsUrl);
                var circumscriptionRegionsList = JsonConvert.DeserializeObject<List<CircumscriptionRegion>>(circuscriptionRegionsJson);
               
                foreach (var circumscriptionRegion in circumscriptionRegionsList)
                {
                    var getPollingStationsUrl = $"http://liste.cec.md/app/api/data/GetPollingStations?regionId={circumscriptionRegion.Key}";
                    var poolingStationsJson = webClient.DownloadString(getPollingStationsUrl);
                    var poolingStationsList = JsonConvert.DeserializeObject<List<PoolingStation>>(poolingStationsJson);
                    var regionDirectory = Directory.CreateDirectory($"c:\\Liste\\{circumscription.Value}\\{circumscriptionRegion.Value}");

                    foreach (var poolStation in poolingStationsList)
                    {
                        var poolStattionDownloadUrl = $"http://liste.cec.md/app/api/data/getfile?regionId={circumscriptionRegion.Parameter}&pollingstationId={poolStation.Id}";
                        var poolingStation = new PoolingStation();
                        var adjustedName = poolingStation.AdjustName(poolStation.Name);
                        var filePath = $"{regionDirectory}\\{adjustedName}.pdf";
                        try
                        {
                            webClient.DownloadFile(poolStattionDownloadUrl, filePath);
                        }catch
                        {
                            Console.WriteLine("Wrong file name"+ filePath);
                        }
                        
                    }
                }
            }
            Console.ReadLine();
        }
    }
    public class Circumscription
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class CircumscriptionRegion: Circumscription
    {
        public string Parameter { get; set; }
       
    }
    public class PoolingStation
    {
        public string Number { get; set; }
        public string RegionId { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string AdjustName(string name)
        {
            return name.Replace("\"", "").Replace("\\", "_").Replace("/", "_").Replace(":", "").Replace("*", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("?", "");

        }
    }
}
