using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Classes;

namespace Task2.Interfaces
{
    interface IWord:ISentenceItem,IEnumerable<Symbol>
    {
        Symbol this[int index] { get; }
        int Length { get; }
    }
}
