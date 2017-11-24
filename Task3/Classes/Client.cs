using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
   public class Client
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Money { get; private set; }

        public Client(string firstName,string lastName,int money)
        {
            FirstName = firstName;
            LastName = lastName;
            Money = money;
        }

        public void AddMoney(int money)
        {
            Money += money;
        }

        public void RemoveMoney(int money)
        {
            Money -= money;
        }

    }
}
