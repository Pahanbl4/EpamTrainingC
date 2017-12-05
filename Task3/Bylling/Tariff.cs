using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Arguments;

namespace Task3.Bylling
{
    public class Tariff
    {
        public int PriceOfMonth { get; private set; }
        public int PriceOfCallPerMinute { get; private set; }
        public TariffTypes TariffType { get; private set; }
        public int LimitCallInMonth { get; private set; }

        public Tariff(TariffTypes type)
        {
            TariffType = type;
            switch(TariffType)
            {
                case TariffTypes.Elementary:
                    {
                        PriceOfCallPerMinute = 1;
                        PriceOfMonth = 10;
                        LimitCallInMonth = 10;
                        break;
                    }
                case TariffTypes.Standart:
                    {
                        PriceOfCallPerMinute = 2;
                        PriceOfMonth = 15;
                        LimitCallInMonth = 8;
                        break;
                    }
                case TariffTypes.Lux:
                    {
                        PriceOfCallPerMinute = 3;
                        PriceOfMonth = 30;
                        LimitCallInMonth = 10;
                        break;
                    }
                default:
                    {
                        PriceOfCallPerMinute = 0;
                        PriceOfMonth = 0;
                        break;
                    }
            }
        }
    }
}
