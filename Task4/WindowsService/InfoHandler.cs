using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
   public class InfoHandler
    {
        private HandlerDB _dbHandler;
        private Parser _parser;
        public InfoHandler()
        {
            _dbHandler = new HandlerDB();
            _parser = new Parser();
        }
        public void SaveRecords(string path)
        {
            var records = _parser.ParseData(path);
            foreach (var infolist in records)
            {
                _dbHandler.AddToDatabase(infolist);
            }
        }
    }
}
