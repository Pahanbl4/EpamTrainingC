using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Classes;
using Task1.Interface;

namespace Task1
{
    class ChiefCooker
    {
        static void Main(string[] args)
        {
            Salad Salad1 = new Salad("Vitamin", new List<IBasicVegetable>());


            var Vegetable1 = new FruitTomato();
            var Vegetable2 = new FruitCucumber();
            var Vegetable3 = new VegetativePekingCabbage();
            var Vegetable4 = new VegetativeCabbage();

            Salad1.AddVegetable(Vegetable1);
            Salad1.AddVegetable(Vegetable2);
            Salad1.AddVegetable(Vegetable3);
            Salad1.AddVegetable(Vegetable4);
            Salad1.DeleteVegetable(Vegetable4);
            Salad1.AddVegetable(Vegetable4);

         
            Salad1.SortByName();
            Salad1.SortByWeight();
            
            Console.WriteLine("\nSumma kalorij v salate1 = "+Salad1.CaloricitySumm);
            Salad1.CompareByCaloricity(36);
            Salad1.ShowAll();

        }
    }
}
