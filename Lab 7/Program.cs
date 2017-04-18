using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "Lab 7";

            string[,] Students = new string[,] {
                //Names
                { "Anthony", "Bob", "Carl", "Darrell", "Edward", "Frank", "Gary",
                "Harold", "Irene", "Jennifer", "Kelly", "Lisa", "Mary", "Nancy", "Oscar", "Peter", "Qunicy",
                "Ronald", "Steve", "Terry", "Ursula", "Vince", "Winston", "Xavier", "Yusuf", "Zack" },
                
                //Age
                { "21", "24", "35","32", "45", "28", "18",
                "35", "56", "32", "24", "27", "32", "19", "30", "28", "39",
                "20", "25", "34", "31", "32", "22", "21", "31", "36" },

                //Favorite food
                { "Pizza", "Bacon", "Steak", "Chicken", "Chocolate", "Ice Cream", "Sushi",
                "Pasta", "French Fries", "Macaroni and Cheese", "Hotdogs", "Sausages", "Hamburgers", "Doughnuts", "Ribs", "Popcorn", "Tacos",
                "Lasagna", "Noodles", "Cake", "Pancakes", "Garlic Bread", "Cheesecake", "Buffalo Wings", "Brownies", "Shrimp" }
            };

            bool loop = true;

            while (loop)
            {
                int AmountOfStudents = Students.GetLength(1);
                Menu(Students); //Creates list of names for the user to choose from.
                Console.Write($"Enter a number between 1 and {AmountOfStudents}: ");
                int StudentInput = GetValidInteger(AmountOfStudents) - 1;
                AgeOrFood(Students, StudentInput);
                if (!ContinueApp())
                    loop = false;
            }
        }
        public static void Menu(string[,] Students)
        {
            for (int i = 0; i < Students.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}: {Students[0,i]}"); //Creates list of names for the user to choose from
            }
        }
        public static int GetValidInteger(int Max)
        {
            int IntegerInput;
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out IntegerInput)) //Validates if user input is an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not a number."); //Prompts error if input is not a number
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Try again: ");
                    continue;
                }
                if (IntegerInput < 1 || IntegerInput > Max) //Validates if user input is between Min and Max
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Input not between 1 and {Max}."); //Prompts error if input is not between Min and Max
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Try again: ");
                    continue;
                }
                return IntegerInput;
            }
        }
        public static void AgeOrFood(string[,] Students, int StudentInput)
        {
            Console.Write($"What would you like to know about {Students[0, StudentInput]}? ");
            if (GetValidString() == "age")
            {
                Console.WriteLine($"{Students[0, StudentInput]}'s age is {Students[1, StudentInput]}.");
            }
            else
            {
                Console.WriteLine($"{Students[0, StudentInput]}'s favorite food is {Students[2, StudentInput]}.");
            }
        }
        public static string GetValidString()
        {
            while (true)
            {
                Console.Write("(Enter \"Age\" or \"Favorite food\"): ");
                string input = Console.ReadLine().ToLower();
                if (input == "age" || input == "favorite food")
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. Invalid input.\n"); //Prompts error if input is not a number
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        public static bool ContinueApp()
        {
            while (true)
            {
                Console.Write("Would you like to know more about another student? (y/n): ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine();
                    return true;
                }
                else if (input == "n")
                {
                    Console.WriteLine("\nByebye!");
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not y or n.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
