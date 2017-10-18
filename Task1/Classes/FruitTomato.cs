using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes
{
    class FruitTomato: FruitVegetableCrops
    {
        public FruitTomato()
        {
            VegetableName = "Tomato";
            VegetableWeight = 200;
            VegetableCaloricity = 36;
            Family = "Nightshade";
        }
    }
}
