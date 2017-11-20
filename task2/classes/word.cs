using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Word:IWord
    {
        private Symbol[] _content;

        public int Row { get; private set; }

        public Symbol this[int index]
        {
            get { return _content[index]; }
        }

        public Symbol[] Content
         {
            get { return _content; }
            private set { _content = value; }
         }

        public Word(IEnumerable<Symbol> source, int row)
        {
            Row = row;
            Content = source.ToArray();
        }

        public Word(string chars, int row)
        {
            Content = chars.Select(x => new Symbol(x)).ToArray();
            Row = row;
        }

        public int Length
         {
            get { return (_content != null) ? _content.Length : 0; }
          
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

        public IEnumerator<Symbol> GetEnumerator()
         {
             return _content.AsEnumerable().GetEnumerator();
         }
 
         System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
         {
             return _content.GetEnumerator();
         }

     }
    }


