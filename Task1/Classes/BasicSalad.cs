using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interface;

namespace Task1.Classes
{
    class BasicSalad :KindsVegitables, IBasicSalad
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public double Caloricity { get; set; }
    }
}
