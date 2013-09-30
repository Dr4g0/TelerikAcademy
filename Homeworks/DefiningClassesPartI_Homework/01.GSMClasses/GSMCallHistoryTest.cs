using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmInfo
{
    class GSMCallHistoryTest
    {
        public static void TestCallHistory()
        {
            GSM myGSM = new GSM("Galaxy SII","Samsung");
            myGSM.AddCall(new Call(new DateTime(2013,9,23,15,15,0),"0888 888 888",120));
            myGSM.AddCall(new Call(new DateTime(2013,9,24,16,16,20),"0898999999",215));
            myGSM.AddCall(new Call(new DateTime(2013,9,25,17,17,30),"0878777777",144));
            PrintTheCallInfo(myGSM);
            PrintTotalPrice(myGSM);
            Call longestCall=myGSM.CallHistory.OrderByDescending(call=>call.Duration).FirstOrDefault();
            myGSM.RemoveCall(longestCall);
            PrintTotalPrice(myGSM);
            PrintTheCallInfo(myGSM);
            myGSM.ClearCallHistory();
        }

        private static void PrintTotalPrice(GSM myGsm)
        {
            Console.WriteLine("The total price of the calls is {0}",myGsm.CalculateTotalPrice(0.37m));
            Console.WriteLine();
        }

        private static void PrintTheCallInfo(GSM myGsm)
        {
            Console.WriteLine();
            Console.WriteLine("History of the calls:");
            Console.WriteLine();
            Console.WriteLine(string.Format("{0,15}{1,25}{2,22}{3,16}","Date","Time","Dialed Phone","Duration(sec.)"));
            Console.WriteLine(new string('=', 78));
            foreach (var call in myGsm.CallHistory)
            {
                Console.WriteLine(string.Format("{0,-35:D}{1,-15:T}{2,-15}{3,6}", call.Date, call.Date, call.DialedPhone, call.Duration));
            }
            Console.WriteLine();
        }
        
    }
}
