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
        public ATS Ats;

        public Terminal RegistrContract()
        {
            return Ats.GetNewTerminal(Number); 
        }

        public Contract(string name, int number, TariffTypes tariffType,ATS ats)
        {
            this.Name = name;
            this.Number = number;
            this.Tariff = new Tariff(tariffType);
            this.Ats = ats;
        }
    }
}
