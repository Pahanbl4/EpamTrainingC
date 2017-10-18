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
            var result = Items.OrderBy(items => items.VegetableWeight).Select(items => items);
            foreach (var i in result) { i.ToString(); }
        }
        public void SortByName()
        {
            var result = Items.OrderBy(item => item.VegetableName).Select(item => item);
            foreach(var i in result) { i.ToString(); }
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
            foreach (var item in this.Items)
                item.ToString();
        }

        public double WightSum
        {
            get { return Items.Sum(x => x.VegetableWeight); }
        }

        public double CaloritySum
        {
            get { return Items.Sum(x => x.VegetableCaloricity); }
        }

    }
}
