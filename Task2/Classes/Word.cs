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
        public Symbol[] _content;
        public Word(IEnumerable<Symbol> source)
         {
             _content = source.ToArray();
         }
 
         public Word(string chars)
         {
             Content = chars;
         }
 
         public Symbol this[int index]
         {
             get { return _content[index]; }
         }
 
         public string Content
         {
             get
             {
                 StringBuilder sb = new StringBuilder();
                 foreach (var s in _content)
                 {
                     sb.Append(s.Content);
                 }
                return sb.ToString();
             }
             private set
             {
                 if (value != null)
                 {
                     _content = value.Select(x => new Symbol(x)).ToArray();
                 }
                 else
                 {
                     _content = null;
                 }
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
 
 
         public int Length
        {
             get { return (_content != null) ? _content.Length : 0; }
         }
     }
    }


