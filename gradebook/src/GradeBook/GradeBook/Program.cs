using System;
using System.Collections.Generic;
using System.Configuration;
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

            var looping = true;

            while (looping)
            {
                Console.Write("New Grade: ");
                var input = Console.ReadLine();

                try
                {
                    if (input != null)
                    {
                        double number1;
                        if (double.TryParse(input, out number1))
                        {
                            book.AddGrade(double.Parse(input));
                        }
                        else
                        {
                            if (new List<char> { 'A', 'B', 'C', 'D', 'F' }.Contains(char.Parse(input)))
                            {
                                book.AddLetterGrade(char.Parse(input));
                            }
                            else
                            {
                                looping = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            var stats = book.GetStats();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}