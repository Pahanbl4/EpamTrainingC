using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Interface
{
    interface IBasicVegetable
    {
        string VegetableName { get; }
        double VegetableWeight { get; }
        double VegetableCaloricity { get; }
    }
}
