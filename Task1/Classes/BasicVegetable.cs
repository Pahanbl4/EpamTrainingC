using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interface;

namespace Task1.Classes
{
    class BasicVegetable : IBasicVegetable
    {
        public string VegetableName { get; protected set; }

        public double VegetableWeight { get; protected set; }

        public double VegetableCaloricity { get; protected set; }
    }
}
