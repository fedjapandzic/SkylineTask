﻿using System;
using Newtonsoft.Json;

namespace SkylineTask
{
    class Program
    {
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
                var bitrateCalculator = new BitrateCalculatorService();

                foreach(NICData data in aristaDevice.NIC)
                {
                    Console.WriteLine($"Rx/Tx bitrate for {data.Description}");
                    bitrateCalculator.CalculateBitrates(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
