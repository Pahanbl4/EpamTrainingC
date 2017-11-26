using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Bylling;

namespace Task3.Interfaces
{
   public interface IBillingSystem
    {
        Report GetReport(int telephoneNumber);

    }
}
