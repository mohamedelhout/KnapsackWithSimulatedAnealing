using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulated_Anealing
{
    class EntryPoint
    {
        public static void Main()
        {
            int[] profitArr = new int[] { 20, 15, 10, 13, 17, 30, 33, 40, 52, 70 };
            int[] weightArr = new int[] { 10, 30, 15, 20, 35, 100, 110, 18, 45, 60 };
            SimulatedAnealing sa = new SimulatedAnealing(100000, 0.003, 50, 10, profitArr, weightArr);
            sa.Run();
            Console.ReadLine();
        }
    }
}
