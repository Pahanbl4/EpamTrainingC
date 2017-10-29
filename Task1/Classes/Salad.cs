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

        public IEnumerable<IBasicVegetable> SortByWeight
        {
           get
            {
                return Items.OrderBy(items => items.VegetableWeight).ToList();               
            }          
        }

        public IEnumerable<IBasicVegetable> SortByName
        {
         get
            {
                return Items.OrderBy(item => item.VegetableName).ToList();
            }  
        }

        public void AddVegetable(IBasicVegetable item)
        {
            Items.Add(item);
        }

        public void DeleteVegetable(IBasicVegetable item)
        {
            Items.Remove(item);
        }
        public IEnumerable<IBasicVegetable>  ShowAllVegetablesInSeled
        {
            get
            {
                return this.Items;
           }
        }

        public double WeightSumm
        {
            get { return Items.Sum(x => x.VegetableWeight); }
        }

        public double CaloricitySumm
        {
            get { return Items.Sum(x => x.VegetableCaloricity); }
        }
        public IEnumerable<IBasicVegetable> CompareByCaloricity(double min,double max)
        {
            var result = Items
                .Where(item => item.VegetableCaloricity >= min)
                .Where(item => item.VegetableCaloricity <= max)
              //  .Select(item => String.Format("{0} = {1} callories", item.VegetableName, item.VegetableCaloricity))
                .ToArray();
                
            return result;
        }

      

    }
}
