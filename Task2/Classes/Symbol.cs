using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Symbol
    {
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public string Chars
        {
            get { return _content; }
        }

        public int Length
        {
            get { return _content.Length; }
        }

        public Symbol(string Sourse)
        {
            _content = Sourse;
        }
        public Symbol(char Sourse)
        {
            _content = String.Format("{0}", Sourse);
        }

        public bool IsUppercase
        {
            get { return _content != null && _content.Length >= 1 && char.IsLetter(_content[0]) && char.IsUpper(_content[0]); }
        }

        public bool IsLowercase
        {
            get { return _content!=null && _content.Length >= 1 && char.IsLetter(_content[0]) && char.IsLower(_content[0]); }
        }

        public bool IsVowel 
        {
             get
             {
                 var rule = new Regex("[aeiou]", RegexOptions.IgnoreCase);
                 return rule.IsMatch(_content);
             }
        }

       
       
    }
}
