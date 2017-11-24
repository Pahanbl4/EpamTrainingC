using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
  public class Contract
    {
        public string Name { get; private set; }
        public int Number { get; private set; }
        public Tariff Tariff { get; set; }
        public Client Client { get; set; }
        private DateTime LastTariffUpdate;

        static Random random = new Random();

        public Contract(Client client ,TariffTypes tariffTypes)
        {
            LastTariffUpdate = DateTime.Now;
            Client = client;
            Number = random.Next(1000000, 9999999);
            Tariff = new Tariff(tariffTypes);
        }

        public bool TariffChange(TariffTypes tariffTypes)
        {
            if(DateTime.Now.AddMonths(-1)>=LastTariffUpdate)
            {
                LastTariffUpdate = DateTime.Now;
                Tariff = new Tariff(tariffTypes);
                return true;
            }
            return false;
        }


    }
}
