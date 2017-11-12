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
         public string Content
         {
             get
             {
                 return _content.Content;
             }
             private set
             {
                 _content = new Symbol(value);
             }
         }
 
         public int Length
         {
             get
             {
                 return Content.Length;
             }
         }
 
         public int Row { get; private set; }
 
         public Symbol Value
         {
             get { return _content; }
         }
 
         public string Chars
         {
             get { return ToString(); }
         }
 
         public override string ToString()
         {
             return _content.ToString();
         }
 
         public Punctuation(Symbol content, int row)
         {
             _content = content;
             Row = row;
         }
    }
}
