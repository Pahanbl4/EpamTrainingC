using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
    public class Sentence : ISentence
    {
        private ICollection<ISentenceItem> _items;

        public string Chars
         {
             get { return ToString(); }
         }

        public Sentence()
        {
            _items = new List<ISentenceItem>();
        }

        public Sentence(ICollection<ISentenceItem> source)
        {
            _items = source;

        }       
        public ICollection<ISentenceItem> Content
        {
             get { return _items; }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public int[] Rows
         {
             get
             {
                 int rowStart = _items.OfType<Word>().First().Row;
                 int rowStop = _items.OfType<Word>().Last().Row;
                 return new[] {rowStart, rowStop};
             }
         }
        public int RowsCount
         {
             get { return Rows[1] - Rows[0] + 1; }
         }

        public int WordCount
         {
             get { return _items.OfType<Word>().Count(); }
         }

        public int Length
         {
             get { return Chars.Length; }
         }

        public void Add(ISentenceItem item)
        {
            if (item != null)
            {
                _items.Add(item);
            }
            else
            {
                throw new NullReferenceException("");
            }
        }       

        public bool Remove(ISentenceItem item)
        {
            if(item!=null)
            {
              return  _items.Remove(item);
            }
            else
            {
                throw new NullReferenceException("");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in _items)
            {
                sb.Append(s.Chars);
            }
            return sb.ToString();
        }

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
