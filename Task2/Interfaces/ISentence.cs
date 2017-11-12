using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
   public interface ISentence :ITextItem, IEnumerable<ITextItem>
    {
        void Add(ITextItem item);
        bool Remove(ITextItem item);
        int Count { get; }
        int WordCount { get; }
    }
}
