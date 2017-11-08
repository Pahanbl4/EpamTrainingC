using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Classes;
using Task2.Interfaces;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

           //string str = "\tThis phone weri big : 12141349876   \t\tResource not available\r\nfor anonymous access.";
           //Text text = new Text(str);
            Row row = new Row(1);
            
            row.Add(new Word("Aaa"));
            row.Add(new Symbol(" "));
            row.Add(new Word("bbb"));
           
            Console.WriteLine(row.Content);
            Console.WriteLine(row.Length);
           // Console.WriteLine(text);
        }
    }
}
