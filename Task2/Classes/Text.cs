using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        // All sentences given text in ascending order of the number of words in each of them
        public List<Sentence> SentancesOrderedByWordCount
        {
             get
             {
                 return Content.OrderBy(x => x.WordCount).ToList();
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
            get
            {
                StringBuilder sb = new StringBuilder();
                 foreach (var s in _content)
                 {
                     sb.Append(s.Chars);
                 }
                 return sb.ToString();
            }
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

        public void AddRows(Sentence sentence)
        {
            _content.Add(sentence);
        }

        public bool RemoveRows(Sentence sentence)
        {
         return  _content.Remove(sentence);
        }
 //all words ?interrogative sentence in the word
        public List<Word> InterrogativeSentancesWords()
        {
            return InterrogativeSentances
                     .SelectMany(x => x.Words)
                     .OrderBy(word => word.Chars)
                     .ToList();
        }
 
        public List<Word> InterrogativeSentancesWordsDistinct()
        {
            return InterrogativeSentancesWords()
                     .GroupBy(o => o.Chars, StringComparer.InvariantCultureIgnoreCase)
                     .Select(o => o.FirstOrDefault())
                     .ToList();
        }
        //all ?interrogative sentence in the word length
        public List<Word> InterrogativeSentancesWords(int length)
        {
            return InterrogativeSentancesWords()
                .FindAll(x => x.Length == length);
        }

        public List<Word> InterrogativeSentancesWordsDistinct(int length)
        {
            return InterrogativeSentancesWordsDistinct()
                     .FindAll(x => x.Length == length);
        }

        // delete words specifite length and start from simbol
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

        // delete Consonant words
        public void RemoveConsonantWords(int length)
        {
             foreach (var sentence in Content)
             {
                 var words = sentence.Words.FindAll(x => !x[0].IsVowel && x.Length == length);
                 foreach (var w in words)
                 {
                     sentence.Remove(w);
                 }
             }
         }

        public ICollection<Word> Words
         {
             get
             {
                 return Content
                    .SelectMany(s => s.Words)
                    .OrderBy(word => word.Chars)
                    .ToList();
             }
         }
 
         public ICollection<Word> WordsDistinct
         {
             get
             {
                 return Words
                         .GroupBy(o => o.Chars, StringComparer.InvariantCultureIgnoreCase)
                         .Select(o => o.FirstOrDefault())
                         .ToList();
             }
         }

        public IDictionary<string, int[][]> Concordances
         {
             get
             {
                 int[] amount;
                 int[] row;
 
                 var d = new Dictionary<string, int[][]>();
                 var words = this.WordsDistinct;
                 foreach(var word in words)
                 {

                     var wordOccurrences = Content.SelectMany(s => s.Words).ToList().FindAll(w => w.Chars == word.Chars);
                     amount = new int[] {wordOccurrences.Count()};
                     row = wordOccurrences.Select(s => s.Row).Distinct().ToArray();
                     
                     try
                     {
                         d.Add(word.Chars, new int[2][] { amount, row });
                     }
                     catch (ArgumentException)
                     {
                         Console.WriteLine("An element already exists.");
                     }
                 }
                 return d;
             }
         }

        public void PrintConcordances()
        {
             var currentChar = Char.ToUpper( Concordances.First().Key[0] );
             Console.WriteLine(currentChar);
             foreach (var c in Concordances)
             {
                 var tempChar = Char.ToUpper( c.Key[0] );
                 if (currentChar != tempChar)
                 {
                     currentChar = tempChar;
                     Console.WriteLine(currentChar);
                 }
                 Console.Write("{0,15} | {1,3} | ",c.Key ,c.Value[0][0]);
                 foreach (var i in c.Value[1])
                 {
                     Console.Write("{0} ",i);
                 }
                 Console.Write("\n");
             }
        }

        public void ToFile(string path)
        {
             using (StreamWriter file = new StreamWriter(path))
             {
                 file.WriteLine(this.Chars);
             }
        }

}
}
