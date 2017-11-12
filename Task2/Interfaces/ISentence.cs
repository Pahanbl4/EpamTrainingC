using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
   public interface ISentence :ITextItem, IEnumerable<ITextItem>
    {
        void Add(ISentenceItem item);
        bool Remove(ISentenceItem item);
        int Count { get; }
        int WordCount { get; }
    }
}
