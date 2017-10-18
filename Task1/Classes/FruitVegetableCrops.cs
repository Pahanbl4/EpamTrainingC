using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interface;

namespace Task1.Classes
{
    class FruitVegetableCrops:BasicVegetable,IFruitVegetableCrops
    {
        public FruitVegetableCrops()
        { }

        public FruitVegetableCrops(string name, double weight, double caloricity, string family)
        {
            VegetableName = name;
            VegetableWeight = weight;
            VegetableCaloricity = caloricity;
            Family = family;
        }

        public string Family { get; set; }
    }
}
