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
        private List<ISentenceItem> _items;

        public List<ISentenceItem> Content
        {
            get { return _items; }
        }

        public Sentence()
        {
            _items = new List<ISentenceItem>();
        }

        public Sentence(List<ISentenceItem> source)
        {
            _items = source;

        }

        public string Chars
        {
            get
             {
                 StringBuilder sb = new StringBuilder();
                 foreach (var item in Content)
                 {
                     sb.Append(item.Chars);
                 }
                 return sb.ToString();
             }
          }
             
        public List<Word> Words
        {
            get { return Content.OfType<Word>().ToList(); }
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
             get { return Words.Count(); }
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
        public void Replace(int length, string subString)
        {
            SeparatorContainer sp = new SeparatorContainer();
             Parser parser = new Parser(sp);
 
             var words = Words.FindAll(w => w.Length == length);
             foreach (var word in words)
             {
                 var subSentence = parser.Parse(subString, word.Row);
                 var index = _items.IndexOf(word);
                 Remove(word);
                 _items.InsertRange(index, subSentence);
             }
         }

        public IEnumerator<ITextItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
