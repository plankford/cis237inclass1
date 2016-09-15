using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    //Add the static keyword to make this class static
    static class StaticUserInterface
    {

        // This method had to become static because the class is 
        public static int GetUserInput()
        {
            //Call the printMenu method and quialify it using the name of this
            //class instead of the keyword 'this'. It does the same thing as 'this'
            //but since 'this' for instances and statis c;asses cant have instances
            //we must use the class name
            StaticUserInterface.printMenu();

            //Get input from the console
            string input = Console.ReadLine();

            //Continue to loop while the input is not a valid choice
            while (input != "1" && input != "2")
            {
                //Since it is not valid, output a message saying so
                Console.WriteLine("That is not a valid entry");
                Console.WriteLine("Please make a valid choice");
                Console.WriteLine();

                //re-display the menu in case the user forgot what they could do
                StaticUserInterface.printMenu();

                //re-get the input from the user
                input = Console.ReadLine();
            }

            //At this point the input is valid, so we can return the parse of it
            return Int32.Parse(input);
        }

        public static void PrintAllOutput(string allOutput)
        {
            Console.WriteLine(allOutput);
        }


        private static void printMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Print List");
            Console.WriteLine("2. Exit");
        }
    }
}
