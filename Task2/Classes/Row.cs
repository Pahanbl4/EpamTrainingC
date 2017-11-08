using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
    public class Row : IRow
    {
        public int RowNumber { get; private set; }
        public IList<ISentenceItem> _content;

        public string Content
        {
            get {
                StringBuilder sb = new StringBuilder();
                foreach(var s in _content)
                {
                    sb.Append(s.Content);
                }
                return sb.ToString();

            }
        }

        public int Length
        {
            get
               { return (_content != null) ? Content.Length : 0; }
        }

        public Row(int rowNumber)
        {
            RowNumber = rowNumber;
            _content = new List<ISentenceItem>();
        }

        public Row(int rowNumber,List<ISentenceItem> content)
        {
            RowNumber = rowNumber;
            _content = content;
        }
        public void Add(ISentenceItem item)
        {
            _content.Add(item);
        }
    }
}
