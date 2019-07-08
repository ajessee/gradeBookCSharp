using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name, string[] args = null)
        {
            Name = name;
            grades = new List<double>();
            if (args != null && args.Length > 0)
            {
                foreach (var grade in args)
                {
                    grades.Add(Convert.ToDouble(grade));
                }
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentOutOfRangeException("grade", "Grades must be between 0 - 100");
            }
        }

        public char GetLetterGrade(double grade)
        {
            var letter = new Char();
            switch (grade)
            {
                case var g when g >= 90.0:
                    letter = 'A';
                    break;
                case var g when g >= 80.0:
                    letter = 'B';
                    break;
                case var g when g >= 70.0:
                    letter = 'C';
                    break;
                case var g when g >= 60.0:
                    letter = 'D';
                    break;
                default:
                    letter = 'F';
                    break;
            }
            return letter;
        }

        public Statistics GetStatistics()
        {
            var results = new Statistics();

            foreach (var grade in grades)
            {
                results.Average += grade;
                results.Low = Math.Min(grade, results.Low);
                results.High = Math.Max(grade, results.High);
                results.GradeString = string.Join(", ", grades.ToArray());
            }

            results.Average = Math.Round(results.Average /= grades.Count, 1);
            results.Letter = GetLetterGrade(results.Average);


            return results;
        }

    }


}
