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
        public ICollection<IBasicSalad> Items { get; protected set; }
        public string Name { get; protected set; }

        public Salad(string name,ICollection<IBasicSalad> items)
        {
            Name = name;
            Items = items;
        }

        public void SortByWeight()
        {
            var result = Items.OrderBy(items => items.Weight).Select(items => items);
            foreach (var u in result) { u.ToString(); }
        }
    }
}
