using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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





            //Use the CSVProcessor method that we wrote into main to load the employees from the csv file
            //if it is not in the bin folder
            // "..//..//folder it is in"
            ImportCSV("employees.csv", employees);





            //Instantiate a new UI class
            UserInterface ui = new UserInterface();

            //StaticUserInterface.GetUserInput();

            //Get the user input from the UI class
            //int choice = ui.GetUserInput();
            //Could use the instance one above, but to demonstrate using a static class we are calling the static version
            //If you hate static classes and want to avoid them, feel free to comment the below line out and uncomment
            //line above
            int choice = StaticUserInterface.GetUserInput();

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

        static bool ImportCSV(string pathToCsvFile, Employee[] employees)
        {
            //Declare the streamreader and declare it to null so that is has a value
            StreamReader streamReader = null;

            //Start a try since the path to the file could be incorrect and thus
            //throw an exception
            try
            {
                //Declare a string for each line we will read in
                string line;

                //Instanciate the streamReader. If the path to the file is incorrect it will
                //throw an exception
                streamReader = new StreamReader(pathToCsvFile);

                //Setup a counter that we are not using yet
                int counter = 0;

                //While there is a line to read, read the line and pu it in the line variable
                while ((line = streamReader.ReadLine()) != null)
                {
                    //Process the line and send over the read line,
                    //the employees array (which is passed by ref automatically).
                    //and the counter, which will be used as the indes for the array.
                    //We are also incrementing the counter after we send it in with the ++ operator
                    processLine(line, employees, counter++);
                }
                //All the reads are successful return true
                return true;
            }
            catch (Exception e)
            {
                //Output the exception string and the stack trace
                //The stact trace is all of the method calls that lead to where
                //the exception occured
                Console.Write(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                //Return false, reading failed
                return false;
            }
            //Used to ensure that the code within it gets executed regardless of whether the try succeeds or the catch
            //gets executed
            finally
            {
                //Check to make sure that the streamReader is actually instanciated before trying to call a method
                if (streamReader != null)
                {
                    //Close the streamReader because it is the right thing to do
                    streamReader.Close();
                }
            }
        
        }

        static void processLine(string line, Employee[] employees, int index)
        {
            //Declare a string array and assign the split line to it
            string[] parts = line.Split(',');

            //Assign the parts to the local variables that mean something
            string firstName = parts[0];
            string lastName = parts[1];
            decimal salary = decimal.Parse(parts[2]);

            //Use the variable to instanciate a new Employee and assign it to 
            //the spot in the employees array indexed by the index that was passed in.
            employees[index] = new Employee(firstName, lastName, salary);
        }

    }
}
