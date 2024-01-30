using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineTask
{
    public class BitrateCalculatorService
    {
        private const int PollingRate = 2;

        public void CalculateBitrates(NICData nicData)
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
