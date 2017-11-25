using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Bylling
{
   public class ReportShow
    {
        public ReportShow()
        {

        }
        public void Show(Report report)
        {
            foreach(var callRecords in report.GetCallRecords())
            {
                Console.WriteLine("Call: {0} ,  Date: {1},  Duration: {2},  Price: {3},  Telephone Number: {4}", 
                    callRecords.CallType, callRecords.Date, callRecords.Time.ToString("mm:ss"), callRecords.Price, callRecords.Number);
            }
        }
    }
}
