using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Text :IText
    {
        private List<Row> _content;

        public string Content
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var s in _content)
                {
                    sb.Append(s.Content);
                    sb.Append("\r\n");
                }
                return sb.ToString();

            }
        }

        public override string ToString()
        {
            return Content ;
        }

        public int Length
        {
            get
            { return (_content != null) ? Content.Length : 0; }
        }

        public Text(List<Row> rows)
        {    
         _content = rows;
        }

        public Text()
        {
            _content = new List<Row>();
        }

        public void AddRows(Row row)
        {
            _content.Add(row);
        }

        public void RemoveRows(Row row)
        {
            _content.Remove(row);
        }

        public void RemoveRows(int rowNumber)
        {
            RemoveRows(_content.Find(r=>r.RowNumber==rowNumber));
        }
    }
}
