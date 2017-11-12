using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Interfaces;

namespace Task2.Classes
{
  public  class Text :IText
    {
        private List<Sentence> _content;

        public List<Sentence> Content
        {
            get { return _content; }
        }

        public ICollection<Sentence> SentancesOrderedDescend
        {
             get
             {
                 return Content.OrderByDescending(x => x.WordCount).ToList();
             }
        }

        public string Chars
        {
            get { return ToString(); }
        }

        public int SentenceCount
         {
             get { return _content.Count; }
         }

        public int Length
        {
            get { return Chars.Length; }
        }

        public int RowCount
          {
             get
             {
                 return _content.LastOrDefault().Rows[1];
             }
         }
        public int WordCount
          {
              get
              {
                return _content.Sum(s => s.WordCount);
              }
          }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
             foreach (var s in _content)
             {
                 sb.Append(s.Chars);
             }
             return sb.ToString();
        }      

        public Text(List<Sentence> rows)
        {    
         _content = rows;
        }

        public Text()
        {
            _content = new List<Sentence>();
        }

        public void AddRows(Sentence sentence)
        {
            _content.Add(sentence);
        }

        public bool RemoveRows(Sentence sentence)
        {
         return  _content.Remove(sentence);
        }

        public ICollection<Sentence> InterrogativeSentances
        {
             get
             {
               return Content.FindAll(x => x.Content.Last().Chars.Contains("?")).ToList();
             }
        }
 
        public List<string> InterrogativeSentancesWords()
        {
             List<Word> w = new List<Word>();
 
             foreach (var sentance in InterrogativeSentances)
             {
                 w.AddRange(sentance.Words);
             }
 
             return w.OrderBy(x => x.Chars).Select(i => i.Chars).Distinct().ToList();
        }
 
        public List<string> InterrogativeSentancesWords(int length)
        {
             var interrogativeWords = InterrogativeSentancesWords();
             var v =  interrogativeWords.FindAll(x => x.Length == length);
             return interrogativeWords.FindAll(x => x.Length == length);
        }
       
    }
}
