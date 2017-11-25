using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;
using Task3.Classes;

namespace Task3.Bylling
{
   public class BillingSystem
    {
        private IRepository<InformationCall> _repository;

        public BillingSystem(IRepository<InformationCall> repository)
        {
            _repository = repository;
        }

        public Report GetReport(int telephoneNumber)
        {
            var calls = _repository.GetInfoList().
                Where(x => x.MyNumber == telephoneNumber || x.ObjectNumber == telephoneNumber).ToList();
            var report = new Report();

            foreach(var call in calls)
            {
                CallTypes callType;
                int number;
                if(call.MyNumber == telephoneNumber)
                {
                    callType = CallTypes.OutgoingCall;
                    number = call.ObjectNumber;
                }
                else
                {
                    callType = CallTypes.IncomingCall;
                    number = call.MyNumber;
                }
                var entry = new CallRecords(callType, number, call.BeginCall, new DateTime((call.EndCall - call.BeginCall).Ticks), call.Price);
                report.AddRecord(entry);
            }
            return report;
        }
    }
}
