using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Parser
    {
        private SeparatorContainer _separatorContainer;
        private ISentenceItemFactory _wordFactory;
        private ISentenceItemFactory _punctuationFactory;

        protected SeparatorContainer SeparatorContainer
        {
            get { return _separatorContainer; }
            set { _separatorContainer = value; }
        }
        protected ISentenceItemFactory WordFactory
        {
            get { return _wordFactory; }
            set { _wordFactory = value; }
        }

        protected ISentenceItemFactory PunctuationFactory
        {
            get { return _punctuationFactory; }
            set { _punctuationFactory = value; }
        }

        public Text Parse(TextReader reader)
        {
            var orderedSentenceSeparators = SeparatorContainer.SentenceSeparators().OrderByDescending(x => x.Length);
            int bufferlength = 1000;
            Text textResult = new Text();
            StringBuilder buffer = new StringBuilder();

            buffer.Clear();
            string currentString = reader.ReadLine();
             while (currentString != null)
             {
                 int firstSentenceSeparatorOccurence = -1;
                 Symbol firstSentenceSeparator = orderedSentenceSeparators.FirstOrDefault(
                     x =>
                     {
                         firstSentenceSeparatorOccurence = currentString.IndexOf(x.Content);
                         return firstSentenceSeparatorOccurence >= 0;
                     });
                 if (firstSentenceSeparator != null)
                 {
                     buffer.Append(currentString.Substring(0, firstSentenceSeparatorOccurence + firstSentenceSeparator.Length));
                     buffer.Clear();
                     buffer.Append(currentString.Substring(firstSentenceSeparatorOccurence + firstSentenceSeparator.Length + 1, currentString.Length));
                 }
                 else
                 {
                     buffer.Append(" ");
                     buffer.Append(currentString);
                 }
                 currentString = reader.ReadLine();
             }
             return textResult;
         }
 
         
 
         public Parser(SeparatorContainer separatorContainer)
         {
             this.SeparatorContainer = separatorContainer;
             this.WordFactory = new WordFactory();
             this.PunctuationFactory = new PunctuationFactory(SeparatorContainer);
         }
     
        
    }
}
