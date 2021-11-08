using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;
        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStats()
        {
            Statistics result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
            }

            result.Average = grades.Sum();
            result.Average /= grades.Count;

            return result;
        }

        // public void ShowStats()
        // {
        //     Console.WriteLine($"test {grades.Sum() / grades.Count:N1}");
        //     Console.WriteLine($"Highest {result.High}");
        //     Console.WriteLine($"Lowest {res}");
        // }
    }
}