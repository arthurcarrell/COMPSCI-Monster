using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSPreALevelSkeleton
{
    public class Program
    {
        public const int NS = 4;
        public const int WE = 6;
        static void Main(string[] args)
        {
            int Choice = 0;
            while (Choice != 9)
            {
                DisplayMenu();
                Choice = GetMainMenuChoice();
                switch (Choice)
                {
                    case 1:
                        Game NewGame = new(false);
                        break;
                    case 2:
                        Game TrainingGame = new(true);
                        break;
                }
            }
        }        

        public static void DisplayMenu()
        {
            // clear the console and prompt the user to make a choice
            Console.Clear();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine();
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Play training game");
            Console.WriteLine("3. Quit");
            Console.WriteLine();
            Console.Write("Please enter your choice: ");
        }

        public static int GetMainMenuChoice()
        {
            int Choice;
            Choice = int.Parse(ReadLineSafely());
            Console.WriteLine();
            return Choice;
        }

        public static string ReadLineSafely() {
            // Console.ReadLine() but it does not return a null value

            // because Console.ReadLine() *could* return a nullable value output should be marked as nullable with a '?'
            string? output;

            // if Console.ReadLine() returns null; loop
            do {
                output = Console.ReadLine();
            } while (output == null);

            // return output
            return output;
        }
    }
}