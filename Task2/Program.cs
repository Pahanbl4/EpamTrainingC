using System;
using System.Collections.Generic;
using System.IO;
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
            TextReader textReader = new StreamReader("../../test.txt");
            SeparatorContainer sp = new SeparatorContainer();
            Parser parser = new Parser(sp);
            Text text = parser.Parse(textReader);
            Console.WriteLine(text.ToString());                    
        }
    }
}
