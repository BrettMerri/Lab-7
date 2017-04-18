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
            //Adding default color values for the console
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            //Change console title to Lab 7
            Console.Title = "Lab 7";

            //2-dimensional array
            string[,] Students = new string[,] {

                //Names
                { "Anthony", "Bob", "Carl", "Darrell", "Edward", "Frank", "Gary", "Harold",
                "Irene", "Jennifer", "Kelly", "Lisa", "Mary", "Nancy", "Oscar", "Peter", "Qunicy",
                "Ronald", "Steve", "Terry", "Ursula", "Vince", "Winston", "Xavier", "Yusuf", "Zack" },
                
                //Age
                { "21", "24", "35", "32", "45", "28", "18", "35",
                "56", "32", "24", "27", "32", "19", "30", "28", "39",
                "20", "25", "34", "31", "32", "22", "21", "31", "36" },

                //Favorite food
                { "Pizza", "Bacon", "Steak", "Chicken", "Chocolate", "Ice Cream", "Sushi", "Pasta",
                "French Fries", "Macaroni and Cheese", "Hotdogs", "Sausages", "Hamburgers", "Doughnuts", "Ribs", "Popcorn", "Tacos",
                "Lasagna", "Noodles", "Cake", "Pancakes", "Garlic Bread", "Cheesecake", "Buffalo Wings", "Brownies", "Shrimp" }

            };

            bool loop = true; //Declare loop variable

            while (loop) //Loop main
            {
                int AmountOfStudents = Students.GetLength(1); //AmountOfStudents = the length of columns in the array
                Menu(Students); //Creates list of names for the user to choose from
                Console.Write($"Enter a number between 1 and {AmountOfStudents}: "); //Enter a number between 1 and the total amount of students
                int StudentInput = GetValidInteger(AmountOfStudents) - 1; //Gets a valid integer between 1 and total amount of students. I subtract 1 so the input matches the index of the name the user is choosing in the array
                AgeOrFood(Students, StudentInput); //Prompts user if they want to learn about the student's age or favorite food
                if (!ContinueApp()) //Prompts user if they would like to continue. If they do not want to continue, set loop to false and the app will not loop
                    loop = false;
            }
        }
        public static void Menu(string[,] Students)
        {
            for (int i = 0; i < Students.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}: {Students[0,i]}"); //Creates list of names for the user to choose from. I added 1 to i so the list starts counting from 1 instead of 0.
            }
        }
        public static int GetValidInteger(int Max)
        {
            int IntegerInput;
            while (true) //Loop GetValidInteger in case of error
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out IntegerInput)) //Validates if user input is an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not a number."); //Prompts error if input is not an integer
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Try again: ");
                    continue;
                }
                if (IntegerInput < 1 || IntegerInput > Max) //Validates if user input is between 1 and the total amount of students
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Input not between 1 and {Max}."); //Prompts error if input is not between 1 and the total amount of students
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Try again: ");
                    continue;
                }
                return IntegerInput;
            }
        }
        public static void AgeOrFood(string[,] Students, int StudentInput)
        {
            Console.Write($"What would you like to know about {Students[0, StudentInput]}? "); //Prompts user if he wants to know about the student's age or favorite food
            if (GetValidString() == "age") //GetValidString validates that the user types in "age" or "favorite food"
            {
                Console.WriteLine($"{Students[0, StudentInput]}'s age is {Students[1, StudentInput]}.");
            }
            else //If user types "favorite food"
            {
                Console.WriteLine($"{Students[0, StudentInput]}'s favorite food is {Students[2, StudentInput]}.");
            }
        }
        public static string GetValidString()
        {
            while (true) //Loop GetValidString in case of error
            {
                Console.Write("(Enter \"Age\" or \"Favorite food\"): "); //Prompts user to type in "age" or "favorite food"
                string input = Console.ReadLine().ToLower();
                if (input == "age" || input == "favorite food") //Return input if user types in "age" or "favorite food"
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error. Invalid input.\n"); //Prompts error if input is not "age" or "favorite food"
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        public static bool ContinueApp()
        {
            while (true) //Loop ContinueApp in case of error
            {
                Console.Write("Would you like to know more about another student? (y/n): "); //Prompts user if they want to lean about another student
                string input = Console.ReadLine().ToLower();
                if (input == "y") //If user wants to continue the app
                {
                    Console.WriteLine();
                    return true;
                }
                else if (input == "n") //If user wants to exit the app
                {
                    Console.WriteLine("\nByebye!");
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not y or n.\n"); //Prompts error if input is not "y" or "n"
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
