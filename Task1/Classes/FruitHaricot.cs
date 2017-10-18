using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
    class FruitHaricot: FruitVegetableCrops
    {
        public FruitHaricot()
        {
            VegetableName = "Haricot";
            VegetableWeight = 50;
            VegetableCaloricity = 46;
            Family = "Beans";
        }
    }
}
