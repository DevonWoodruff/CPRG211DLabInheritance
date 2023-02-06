using CPRG211DLabInheritance.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211DLabInheritance
{
    /// <summary>
    /// CPRG211 - Lab Inheritance
    /// </summary>
    /// <remarks>Author: Devon Woodruff</remarks>
    /// <remarks>Date: Feb 5th 2023</remarks>
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                string firstDigit = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstDigit);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    //salaried
                    string salary = cells[7];

                    double salaryDouble = double.Parse(salary);

                    Salaried salaried = new Salaried(id, name, address, salaryDouble);
                    employees.Add(salaried);
                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    //wage
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Wages wages = new Wages(id, name, address, rateDouble, hoursDouble);
                    employees.Add(wages);
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    //part-time

                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    PartTime partTime = new PartTime(id, name, address, rateDouble, hoursDouble);
                    employees.Add(partTime);
                }


            }

            double wageSum = 0;

            foreach (Employee employee in employees) 
            {
                
                if (employee.GetType() == typeof(Wages))
                {
                    double rate = (employee as Wages).Rate;

                    double hours = (employee as Wages).Hours;

                    if (hours > 40)
                    {
                        double regularPay = 40 * rate;

                        double overTimeHours = hours - 40;

                        double overTimeHoursPay = rate * overTimeHours * 1.5;

                        wageSum = wageSum + overTimeHoursPay + regularPay;
                    }

                    else 
                    {
                        double wagePay = rate * hours;

                        wageSum = wageSum + wagePay;
                    }


                }

                else if (employee.GetType() == typeof(PartTime)) 
                {
                    double rate = (employee as PartTime).Rate;

                    double hours = (employee as PartTime).Hours;

                    double partTimePay = rate * hours;

                    wageSum = wageSum + partTimePay;

                }

                else if (employee.GetType() == typeof(Salaried))
                {
                    double salaryPay = (employee as Salaried).Salary;

                    wageSum = wageSum + salaryPay;
                }

            }

            Console.WriteLine("Average weekly pay: " + wageSum / employees.Count);
            
        }
    }
}