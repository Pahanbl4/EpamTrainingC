using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
    class VegetativeCabbage: VegetativeVegetableCrops
    {
        public VegetativeCabbage()
        {
            VegetableName = "Cabbage";
            VegetableWeight = 300;
            VegetableCaloricity = 81;
            Culture = "Leaf-Stalks";
        }
    }
}
