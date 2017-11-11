using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Interfaces
{
   public interface IPunctuation : ISentenceItem
    {
        Symbol Value { get; }
    }
}
