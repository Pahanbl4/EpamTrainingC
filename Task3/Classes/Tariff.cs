using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public class Tariff
    {
        public int PriceOfMonth { get; private set; }
        public int PriceOfCall { get; set; }
        public TariffTypes TariffType { get; private set; }
        public int LimitCallInMonth { get; private set; }

        public Tariff(TariffTypes type)
        {
            TariffType = type;
            switch(TariffType)
            {
                case TariffTypes.Elementary:
                    {
                        PriceOfCall = 1;
                        PriceOfMonth = 10;
                        LimitCallInMonth = 10;
                        break;
                    }
                case TariffTypes.Standart:
                    {
                        PriceOfCall = 2;
                        PriceOfMonth = 15;
                        LimitCallInMonth = 8;
                        break;
                    }
                case TariffTypes.Lux:
                    {
                        PriceOfCall = 3;
                        PriceOfMonth = 30;
                        LimitCallInMonth = 10;
                        break;
                    }
                default:
                    {
                        PriceOfCall = 0;
                        PriceOfMonth = 0;
                        break;
                    }
            }
        }
    }
}
