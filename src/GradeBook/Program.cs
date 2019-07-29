using System;
using System.Collections.Generic;
using System.Threading;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to GradeBook!");
            Console.WriteLine($"The new, cutting edge application that will calculate your grade statistics. GAAS (Grading as a service)");
            Console.WriteLine($"Please enter a grade between 1-100 to add to the gradebook. Enter Q to quit.");
            bool keepGrading = true;
            var book = new Book("The Grades");
            book.GradeAdded += OnGradeAdded;

            while (keepGrading) {
                var input = Console.ReadLine();
                double number;
                if (Double.TryParse(input, out number)) 
                {
                    try {
                        book.AddGrade(number);
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine($"{e.Message}. Please try again.");
                    }
                }
                else if (input == "Q" || input =="q" || input == "quit" || input == "Quit")
                {
                    keepGrading = false;
                }
                else 
                {
                    Console.WriteLine($"I don't know what {input} is. Please try again or type Q to quit.");
                }
            }
            var results = book.GetStatistics();


            for (var i = 0; i < 7; i++)
            {
                Console.Clear();
                Console.WriteLine($"Calculating{new String('.', i+1)}");
                Thread.Sleep(100);
            }
            Console.Clear();
            Console.WriteLine($"Here are your results:");
            Console.WriteLine($"Here are the grades entered: {results.GradeString}");
            Console.WriteLine($"The high grade is {results.High}");
            Console.WriteLine($"The low grade is {results.Low}");
            Console.WriteLine($"The average grade is {results.Average}, which is a {results.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e) 
        {
            Console.WriteLine($"Grade succesfully added to gradebook."); 
        }
    }
}
