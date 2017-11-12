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
        public Sentence()
        {
            _items = new List<ISentenceItem>();
        }

        public Sentence(ICollection<ISentenceItem> source)
        {
            _items = source;

        }

        private ICollection<ISentenceItem> _items;

        public int Count
        {
            get { return _items.Count; }
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

        public IEnumerator<ISentenceItem> GetEnumerator()
        {
            throw new NotImplementedException();
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

       

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
