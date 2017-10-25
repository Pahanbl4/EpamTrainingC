using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interface;

namespace Task1.Classes
{
    class VegetativeVegetableCrops:BasicVegetable, IVegetativeVegetableCrops
    {
        public VegetativeVegetableCrops()
        {
        }
        public VegetativeVegetableCrops(string name, double weight, double caloricity, string culture)
        {
            VegetableName = name;
            VegetableWeight = weight;
            VegetableCaloricity = caloricity;
            Culture = culture;
        }
        public string Culture { get; set; }
    }
}
