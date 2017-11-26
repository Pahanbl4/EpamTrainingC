using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Arguments;
using Task3.Classes;

namespace Task3.Bylling
{
    public class ReportShow
    {
        public ReportShow()
        {

        }
        public void Show(Report report)
        {
            foreach (var callRecords in report.GetCallRecords())
            {
                Console.WriteLine("Call: {0} ,  Date: {1},  Duration: {2},  Price: {3},  Telephone Number: {4}",
                    callRecords.CallType, callRecords.Date, callRecords.Time.ToString("mm:ss"), callRecords.Price, callRecords.Number);
            }


        }
        public IEnumerable<CallRecords> SortCalls(Report report, SortTypes sortType)
        {
            var reports = report.GetCallRecords();
            switch (sortType)
            {
                case SortTypes.SortByTypeCall:
                    return reports = reports.OrderBy(x => x.CallType).ToList();

                case SortTypes.SortByDate:
                    return reports = reports.OrderBy(x => x.Date).ToList();

                case SortTypes.SortByPrice:
                    return reports = reports.OrderBy(x => x.Price).ToList();

                case SortTypes.SortByNumber:
                    return reports = reports.OrderBy(x => x.Number).ToList();

                default:
                    return reports;
            }
        }
    }
}
