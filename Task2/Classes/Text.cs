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

        public Text(List<Sentence> rows)
        {
            _content = rows;
        }

        public Text()
        {
            _content = new List<Sentence>();
        }

        public List<Sentence> SentancesOrderedDescend
        {
             get
             {
                 return Content.OrderByDescending(x => x.WordCount).ToList();
             }
        }

        public List<Sentence> InterrogativeSentances
        {
            get
            {
                return Content.FindAll(x => x.Content.Last().Chars.Contains("?")).ToList();
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

        public void AddRows(Sentence sentence)
        {
            _content.Add(sentence);
        }

        public bool RemoveRows(Sentence sentence)
        {
         return  _content.Remove(sentence);
        }
 
        public List<Word> InterrogativeSentancesWords()
        {
            return InterrogativeSentances.SelectMany(x => x.Words).ToList();
        }
 
        public List<Word> InterrogativeSentancesWordsDestinct()
        {
             return InterrogativeSentancesWords().Distinct().ToList();
        }

        public List<Word> InterrogativeSentancesWords(int length)
        {
             return InterrogativeSentancesWords().FindAll(x => x.Length == length).Distinct().ToList();
        }

        public List<Word> InterrogativeSentancesWordsDistinct(int length)
        {
             return InterrogativeSentancesWordsDestinct().FindAll(x => x.Length == length).ToList();
        }

        public void RemoveWords(int length, char startChar)
        {
            foreach (var sentence in Content)
             {
                 var words = sentence.Words.FindAll(x => x.Chars[0] == startChar && x.Length == length);
                 foreach (var w in words)
                 {
                     sentence.Remove(w);
                 }
             }
          }
        }


    
}
