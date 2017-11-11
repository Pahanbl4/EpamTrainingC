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
          // Text text = new Text(str);
            Row row1 = new Row(1);
            
            row1.Add(new Word("Aaa"));
            row1.Add(new Symbol(" "));
            row1.Add(new Word("bbb"));

            Row row2 = new Row(2);

            row2.Add(new Word("Ccc"));
            row2.Add(new Symbol(" "));
            row2.Add(new Word("ddd"));
            row2.Add(new Symbol("."));

            Row row3 = new Row(3);
            
            row3.Add(new Word("Eee"));
            row3.Add(new Symbol(" "));
            row3.Add(new Word("fff"));
            row3.Add(new Symbol("."));

            Text txt = new Text();

            txt.AddRows(row1);
            txt.AddRows(row2);
            txt.AddRows(row3);
            
            Console.WriteLine(txt);
            Console.WriteLine(txt.Length);
            
            txt.RemoveRows(2);
            
            Console.WriteLine(txt);
            Console.WriteLine(txt.Length);

            //  Console.WriteLine(row.Content);
            // Console.WriteLine(row.Length);
            // Console.WriteLine(text);
        }
    }
}
