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
            Employee myEmployee = new Employee();
            myEmployee.FirstName = "Patrick";
            myEmployee.LastName = "Lankford";
            myEmployee.WeeklySalary = 2010.56m;

            Console.WriteLine(myEmployee.FirstName);
            Console.WriteLine(myEmployee);

            //Create the array
            Employee[] employees = new Employee[10];

            //Add the employee to the array
            employees[0] = new Employee("James", "Kirk", 453.00m);
            employees[1] = new Employee("Alice", "Cooper", 290.00m);
            employees[2] = new Employee("Tonya", "Harding", 800.00m);
            employees[3] = new Employee("Tony", "Danza", 750.00m);
            employees[4] = new Employee("Leroy", "Jenkins", 320.00m);

            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }           
            }
        }
    }
}
