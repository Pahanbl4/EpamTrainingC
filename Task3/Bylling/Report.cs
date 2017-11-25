using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Bylling
{
   public class Report
    {
        private IList<CallRecords> _listRecords;

        public Report()
        {
            _listRecords = new List<CallRecords>();

        }

        public void AddRecord(CallRecords callRecords)
        {
            _listRecords.Add(callRecords);
        }

        public IList<CallRecords> GetCallRecords()
        {
            return _listRecords;
        }
    }
}
