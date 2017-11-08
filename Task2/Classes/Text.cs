using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Text
    {
        public List<ISentenceItem> Rows { get; private set; }

        public Text(List<ISentenceItem> rows)
        {    
         Rows = rows;
        }

        public Text()
        {
            Rows = new List<ISentenceItem>();
        }

        public void AddRows(Row row)
        {
            Rows.Add(row);
        }
    }
}
