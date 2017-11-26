﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;
using Task3.Bylling;

namespace Task3.Interfaces
{
    public interface IATS:IRepository<InformationCall>
    {

        Terminal GetNewTerminal(Contract contract);
        Contract RegisterContract(Client client, TariffTypes type);
        void CallingTo(object sender, ICallingArgsEvent even);

    }
}
