using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Classes;

namespace Task2.Interfaces
{
   public interface IText:ITextItem
    {
         int SentenceCount { get; }
         int WordCount { get; }
         int RowCount { get; }
         void AddRows(Sentence item);
         bool RemoveRows(Sentence item);
 //       int Length { get; }

    }
}
