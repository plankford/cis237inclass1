using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Declaring a variable of type Employee (which is a class) and instanciating
             *a new instance of Employee and assigning it to the variable using
             * the NEW keyword means that memory will get allocated on the Heap for that class
             * */
            Employee myEmployee = new Employee();

            /*use the properties to assign values.
             * */
            myEmployee.FirstName = "Patrick";
            myEmployee.LastName = "Lankford";
            myEmployee.WeeklySalary = 2010.56m;

            //Output the first name of the employee using the property
            Console.WriteLine(myEmployee.FirstName);

            //Output the entire employee, which will call the ToString method implicitly
            //This would work even without overriding the ToString method in the Employee class
            //however it would spit out the namespace and the name of the class instead of something useful.
            Console.WriteLine(myEmployee);

            //Create the array of type Employee to hold a bunch of employees
            Employee[] employees = new Employee[10];

            //Assign values to the array. Each spot needs to contain an instance of an Employee
            employees[0] = new Employee("James", "Kirk", 453.00m);
            employees[1] = new Employee("Alice", "Cooper", 290.00m);
            employees[2] = new Employee("Tonya", "Harding", 800.00m);
            employees[3] = new Employee("Tony", "Danza", 750.00m);
            employees[4] = new Employee("Leroy", "Jenkins", 320.00m);

            /*A Foreach loop. It is useful for doing a collection of object
             * Each object in the array 'employees' will get assigned to the local
             * variable 'employee' inside the loop.
             * */
            foreach (Employee employee in employees)
            {
                // Run a check to make sure the spot in the arrau is not empty
                if (employee != null)
                {
                    //Print the employee
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }           
            }

            //Instantiate a new UI class
            UserInterface ui = new UserInterface();

            //Get the user input from the UI class
            int choice = ui.GetUserInput();

            //While the choice the user entered is not 2, we will loop to continue
            //to get the next choice of what they want to do
            while (choice != 2)
            {
                //If the choice they made is 1, (which for us is the only choice)
                if (choice == 1)
                {
                    //Create a string to concatinate the output
                    string allOutput = "";

                    //Loop through all of the employees just like above only instead of
                    //writing out the employees we are concating them together
                    foreach (Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            //Create the string for printing the output
                            allOutput += employee.ToString() + " " + employee.YearlySalary() + Environment.NewLine;
                        }
                    }
                    //Send the string over to the UI class to print the output
                    ui.PrintAllOutput(allOutput);
                }
                //Get the input choice from the user
                choice = ui.GetUserInput();

            }

        }
    }
}
