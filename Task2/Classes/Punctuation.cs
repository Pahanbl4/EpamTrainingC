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
        private Symbol _value;

        public Symbol Value
        {
            get { return _value; }
        }
        public string Content
        {
            get { return Value.Content; }
        }
        public Punctuation(string content)
        {
            _value = new Symbol(content);
        }
        public Punctuation(Symbol content)
        {
            _value = content;
        }
    }
}
