using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interface;

namespace Task1.Classes
{
    class Salad
    {
        public ICollection<IBasicVegetable> Items { get; protected set; }
        public string Name { get; protected set; }

        public Salad(string name,ICollection<IBasicVegetable> items)
        {
            Name = name;
            Items = items;
        }

        public void SortByWeight()
        {
            var result = Items.OrderBy(items => items.VegetableWeight).
                Select(items =>  items.VegetableName);
            Console.WriteLine("\nSortirovka po vessu:");
            foreach (var i in result)
            { 
                Console.WriteLine(i);
            }
        }
        public void SortByName()
        {
            var result = Items.OrderBy(item => item.VegetableName)
                .Select(item =>  item.VegetableName);
            Console.WriteLine("\nSortirovka po kalorijam:");
            foreach(var i in result)
            { Console.WriteLine(i); }
        }

        public void AddVegetable(IBasicVegetable item)
        {
            Items.Add(item);
        }

        public void DeleteVegetable(IBasicVegetable item)
        {
            Items.Remove(item);
        }
       public void ShowAll()
        {
            Console.WriteLine("\nVse ovoshi:");
            foreach (var item in this.Items)
                Console.WriteLine(item.VegetableName);
        }

        public double WeightSumm
        {
            get { return Items.Sum(x => x.VegetableWeight); }
        }

        public double CaloritySum
        {
            get { return Items.Sum(x => x.VegetableCaloricity); }
        }
        public void CompareByCaloricity(double AmountByCaloricity)
        {
            var result = Items.Where(item => item.VegetableCaloricity == AmountByCaloricity).
                Select(item => String.Format("\nTakaja kalorijnost v {0}", item.VegetableName));
            foreach(var i in result) {

                Console.WriteLine(i.ToString());
            }
        }

    }
}
