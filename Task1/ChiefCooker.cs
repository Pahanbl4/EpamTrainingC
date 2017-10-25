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

         
           
            Print(Salad1,20,100);

        }

        static void Print(Salad salad,double min,double max)
        {
            
            Console.WriteLine("\n\tSalad Name {0}",salad.Name);
            Console.WriteLine("\nAll vegetables in this Salad:");
            foreach(var str in salad.ShowAllVegetablesInSeled)
            {
                Console.WriteLine(str.VegetableName);
            }
           

            Console.WriteLine("\n\tSort by Name:");
            foreach (var str in salad.SortByName)
            {
                Console.WriteLine(str.VegetableName);
            }

            Console.WriteLine("\n\tSort by Weight:");
            foreach (var str in salad.SortByWeight)
            {
                Console.WriteLine("{0} = {1} gramm", str.VegetableName, str.VegetableWeight);
            }

            Console.WriteLine("\n\tSearch by calories from {0} to {1}", min, max);
            salad.CompareByCaloricity(min, max);
            Console.WriteLine("\nSum of calories in {1} salad = {0} callories", salad.CaloricitySumm, salad.Name);

        }
    }
}
