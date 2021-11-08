using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("test");
            book.AddGrade(3.4);
            book.AddGrade(5.5);
            book.AddGrade(6.7);
            book.AddGrade(8.9);
            book.AddGrade(9);
            book.AddGrade(0.9);

            // book.ShowStats();

            double[] numbers = { 1.2, 4.5, 5.5 };
            List<double> grades = new List<double> { 3.4, 5.5, 6.7, 8.9, 9, .9 };

            if (args.Length > 0)
            {
                Console.WriteLine("Hello Test!" + args[0] + "!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}