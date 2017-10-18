using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
    class VegetativeCarrot: VegetativeVegetableCrops
    {
        public VegetativeCarrot()
        {
            VegetableName = "Carrot";
            VegetableWeight = 150;
            VegetableCaloricity = 60;
            Culture = "Root Crops";
        }
    }
}
