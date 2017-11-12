using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
    public class SentenceItemFactory : ISentenceItemFactory
    {

        private ISentenceItemFactory _punctuationFactory;
        private ISentenceItemFactory _wordFactory;


        public ISentenceItem Create(string chars)
        {
            ISentenceItem result = _punctuationFactory.Create(chars);
              if (result == null)
              {
               result = _wordFactory.Create(chars);
              }
              return result;
        }

        public SentenceItemFactory(ISentenceItemFactory punctuationFactory, ISentenceItemFactory wordFactory)
        {
            _punctuationFactory = punctuationFactory;
            _wordFactory = wordFactory;
        }
    }
}
