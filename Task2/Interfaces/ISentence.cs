using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
   public interface ISentence :ISentenceItem, IEnumerable<ISentenceItem>
    {
        void Add(ISentenceItem item);
        bool Remove(ISentenceItem item);
        int Count { get; }
        int WordCount { get; }
    }
}
