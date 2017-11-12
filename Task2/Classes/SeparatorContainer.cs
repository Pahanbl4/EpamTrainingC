﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Classes
{
  public  class SeparatorContainer
    {
        private Symbol[] sentenceSeparators = new Symbol[] { new Symbol("?"),
                                                             new Symbol("!"),
                                                             new Symbol("."),
                                                             new Symbol(".\r\n"),
                                                             new Symbol("..."),
                                                             new Symbol("?!")
                                                          };
        private Symbol[] wordSeparators = new Symbol[] { new Symbol(" "),
                                                         new Symbol(" - "),
                                                         new Symbol(", "),
                                                         new Symbol(",\r\n"),
                                                         new Symbol("; "),
                                                         new Symbol(";\r\n"),
                                                         new Symbol(": "),
                                                         new Symbol(":\n\r"),
                                                         new Symbol(":\r\n"),
                                                         new Symbol(":\n"),
                                                         new Symbol(") "),
                                                         new Symbol(" ("),
                                                         new Symbol("), "),
                                                         new Symbol("); "),
                                                         new Symbol("):"),
                                                         new Symbol("\""),
                                                         new Symbol("/"),
                                                         new Symbol("\r\n")
                                                          };

        public IEnumerable<Symbol> SentenceSeparators()
        {
            return sentenceSeparators.AsEnumerable();
        }

        public IEnumerable<Symbol> WordSeparators()
        {
            return wordSeparators.AsEnumerable();
        }
        public IEnumerable<Symbol> All()
        {
            return sentenceSeparators.Concat(WordSeparators());
        }
    }
}
