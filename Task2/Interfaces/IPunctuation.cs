﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Classes;

namespace Task2.Interfaces
{
   public interface IPunctuation : ISentenceItem
    {
        Symbol Value { get; }
        int Row { get; }
    }
}
