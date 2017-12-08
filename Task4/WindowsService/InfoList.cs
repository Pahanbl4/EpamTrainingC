using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
   public class InfoList
    {
        public string ManagerName { get; private set; }
        public string SaleDate { get; private set; }
        public string ClientName { get; private set; }
        public string ProductName { get; private set; }
        public string ProductCost { get; private set; }

        public InfoList(string managerName, string saleDate, string clientName, string productName, string productCost)
        {
            ManagerName = managerName;
            SaleDate = saleDate;
            ClientName = clientName;
            ProductName = productName;
            ProductCost = productCost;
        }
    }
}
