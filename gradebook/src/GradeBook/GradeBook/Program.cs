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
            InMemoryBook inMemoryBook = new InMemoryBook("test");
            inMemoryBook.GradeAdded += OnGradeAdded;
            
            inMemoryBook.AddGrade(3.4);
            inMemoryBook.AddGrade(5.5);
            inMemoryBook.AddGrade(6.7);
            inMemoryBook.AddGrade(8.9);
            inMemoryBook.AddGrade(9);
            inMemoryBook.AddGrade(0.9);

            EnterGrades(inMemoryBook);

            var stats = inMemoryBook.GetStats();
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook inMemoryBook)
        {
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
                            inMemoryBook.AddGrade(double.Parse(input));
                        }
                        else
                        {
                            if (new List<char> { 'A', 'B', 'C', 'D', 'F' }.Contains(char.Parse(input)))
                            {
                                inMemoryBook.AddGrade(char.Parse(input));
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
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}