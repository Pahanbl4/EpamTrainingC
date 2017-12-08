using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
   public class Parser
    {
        public Parser()
        {
        }
        public IList<InfoList> ParseData(string path)
        {
            string managerName;
            string[] param;
            managerName = Path.GetFileName(path).Split('_').First();
            IList<InfoList> records = new List<InfoList>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    param = sr.ReadLine().Split(',');
                    records.Add(new InfoList(managerName, param[0], param[1], param[2], param[3]));
                }
            }
            return records;
        }
    }
}
