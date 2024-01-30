using System;
using Newtonsoft.Json;

namespace SkylineTask
{
    public class NICData
    {
        public string Description { get; set; }
        public string MAC { get; set; }
        public DateTime Timestamp { get; set; }
        public long Rx { get; set; }
        public long Tx { get; set; }
    }

    public class AristaDevice
    {
        public string Device { get; set; }
        public string Model { get; set; }
        public List<NICData> NIC { get; set; }
    }



    class Program
    {
        private const int PollingRate = 2;
        static void Main()
        {
            string jsonString = @"{
            ""Device"": ""Arista"",
            ""Model"": ""X-Video"",
            ""NIC"": [{
                ""Description"": ""Linksys ABR"",
                ""MAC"": ""14:91:82:3C:D6:7D"",
                ""Timestamp"": ""2020-03-23T18:25:43.511Z"",
                ""Rx"": ""3698574500"",
                ""Tx"": ""122558800""
            }]
        }";

            try
            {
                AristaDevice aristaDevice = JsonConvert.DeserializeObject<AristaDevice>(jsonString);
                for (int i = 0; i < aristaDevice.NIC.Count; i++)
                {
                    Console.WriteLine($"Rx/Tx bitrate for {aristaDevice.NIC[i].Description}");
                    CalculateBitrates(aristaDevice.NIC[i]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }



        }

        static void CalculateBitrates(NICData nicData)
        {


            try
            {
                long rxBits = nicData.Rx * 8;
                long txBits = nicData.Tx * 8;
                long rxBitrate = rxBits / PollingRate;
                long txBitrate = txBits / PollingRate;

                Console.WriteLine($"Rx Bitrate: {rxBitrate} bits/s");
                Console.WriteLine($"Tx Bitrate: {txBitrate} bits/s");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during bitrate calculation: {ex.Message}");
            }
        }
    }
}
