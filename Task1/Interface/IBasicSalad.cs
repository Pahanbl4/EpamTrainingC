using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Interface
{
    interface IBasicSalad
    {
        string Name { get; }
        double Weight { get; }
        double Caloricity { get; }
    }
}
