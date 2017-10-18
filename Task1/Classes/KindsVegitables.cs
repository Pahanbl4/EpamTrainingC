using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interface;

namespace Task1.Classes
{
    class KindsVegitables : IKindsCabbageType, IKindsPumpkinType, IKindsTomatoType
    {
        public int Сauliflower { get; set; }

        public int PekingCabbage { get; set; }

        public int WhiteCabbage { get; set; }

        public int Сucumber { get; set; }

        public int Zucchini { get; set; }

        public int Pumpkin { get; set; }

        public int Tomatoes { get; set; }

        public int Eggplant { get; set; }

        public int BellPeppers { get; set; }
    }
}
