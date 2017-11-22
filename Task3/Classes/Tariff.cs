using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
   public class Tariff
    {
        public readonly int PriceOfMonth;
        public readonly int PriceOfMinutes;
        public TariffTypes TariffType { get; private set; }

        public Tariff(TariffTypes type)
        {
            TariffType = type;
            switch(TariffType)
            {
                case TariffTypes.Elementary:
                    {
                        PriceOfMinutes = 1;
                        PriceOfMonth = 10;
                        break;
                    }
                case TariffTypes.Standart:
                    {
                        PriceOfMinutes = 1;
                        PriceOfMonth = 15;
                        break;
                    }
                case TariffTypes.Lux:
                    {
                        PriceOfMinutes = 2;
                        PriceOfMonth = 30;
                        break;
                    }
                default:
                    {
                        PriceOfMinutes = 0;
                        PriceOfMonth = 0;
                        break;
                    }
            }
        }
    }
}
