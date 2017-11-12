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
        private List<Sentence> _content;

        public List<Sentence> Content
        {
            get { return _content; }
        }

        public string Chars
        {
            get { return ToString(); }
        }

        public int SentenceCount
         {
             get { return _content.Count; }
         }

        public int Length
        {
            get { return Chars.Length; }
        }

        public int RowCount
          {
             get
             {
                 return _content.LastOrDefault().Rows[1];
             }
         }
        public int WordCount
          {
              get
              {
                return _content.Sum(s => s.WordCount);
              }
          }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
             foreach (var s in _content)
             {
                 sb.Append(s.Chars);
             }
             return sb.ToString();
        }

       

        public Text(List<Sentence> rows)
        {    
         _content = rows;
        }

        public Text()
        {
            _content = new List<Sentence>();
        }

        public void AddRows(Sentence sentence)
        {
            _content.Add(sentence);
        }

        public bool RemoveRows(Sentence sentence)
        {
         return  _content.Remove(sentence);
        }

       
    }
}
