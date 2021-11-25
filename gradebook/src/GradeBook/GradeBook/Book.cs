using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStats();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                GradeAdded?.Invoke(this, EventArgs.Empty);
            }
        }

        public override Statistics GetStats()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    public class InMemoryBook : Book
    {
        private List<double> grades;
        private string name;
        
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            this.name = name;
        }
        
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        
        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStats()
        {
            Statistics result = new Statistics();

            foreach (double grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

        private readonly string category = "Science";

        // public void ShowStats()
        // {
        //     Console.WriteLine($"test {grades.Sum() / grades.Count:N1}");
        //     Console.WriteLine($"Highest {result.High}");
        //     Console.WriteLine($"Lowest {res}");
        // }
    }
}