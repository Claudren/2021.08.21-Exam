using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2021._08._21_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите папку:");

            Dictionary dictionary = new Dictionary(Console.ReadLine());
            dictionary.CreateDictionary();
            dictionary.Sort();
            dictionary.Save("test.txt");

        }
    }
}
