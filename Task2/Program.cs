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
            TextReader textReader = new StreamReader("../../test_1.txt");
            SeparatorContainer sc = new SeparatorContainer();
            Parser parser = new Parser(sc);
            Text text = parser.Parse(textReader);

            // Отображать все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            text.SentancesOrderedByWordCount.ForEach(s =>
             {
                 Console.WriteLine(s.Chars);
                 Console.WriteLine("=={0}==----------------------------------", s.WordCount);
             });

           // Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            int length = 3;
            Console.WriteLine("In all interrogative sentences of the text print the word without repetition of a given length = {0}.", length);
             text.InterrogativeSentancesWordsDistinct(length).ForEach(w =>
           {
                Console.WriteLine(w.Chars);
            });

           //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            text.RemoveConsonantWords(3);
 
             Console.WriteLine("----------------------------");
 
             Console.WriteLine("In all interrogative sentences of the text print the word without repetition of a given length = {0}.", length);
             text.InterrogativeSentancesWordsDistinct(length).ForEach(w =>
             {
                 Console.WriteLine(w.Chars);
             });
 
             Console.WriteLine("----------------------------");

           //"В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова."
            text.Content[10].Replace(6, "YOYOYOYO, YOYOYOYO");

            var c = text.Concordances;
            text.PrintConcordances();

            text.ToFile("../../out.txt");

        }

    }
}
