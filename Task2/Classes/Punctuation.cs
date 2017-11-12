using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Punctuation:IPunctuation
    {
        private Symbol _content;
        public int Row { get; private set; }

        public Symbol Content
         {
             get
             {
                 return _content;
             }
             private set
             {
                 _content = value;
             }
         }
 
         public int Length
         {
             get {return Content.Length;}
         }      
 
         public string Chars
         {
             get { return Content.Chars; }
         }
 
         public Punctuation(Symbol content, int row)
         {
             _content = content;
             Row = row;
         }
    }
}
