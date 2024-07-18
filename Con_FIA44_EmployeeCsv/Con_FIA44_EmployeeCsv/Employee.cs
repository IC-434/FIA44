using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Con_FIA44_EmployeeCsv
{
    internal class Employee
    {
        public int Eid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Position { get; set; }
        public DateTime Bordingdate { get; set; }
        public decimal Salary { get; set; }

        public List<Employee> ReadAllEmployeesfromCsv(string path)
        {
            var employees = new List<Employee>();
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var employee = new Employee();
                var parts = line.Split(';');

                if (line.StartsWith("#") || line == "")
                {
                    continue;
                }

                employee.Eid = int.Parse(parts[0]);
                employee.Firstname = parts[1];
                employee.Lastname = parts[2];
                employee.Birthdate = DateTime.Parse(parts[3]);
                employee.Position = parts[4];
                employee.Bordingdate = DateTime.Parse(parts[5]);
                employee.Salary = decimal.Parse(parts[6]);

                employees.Add(employee);
            }

            return employees;
        }

        public void DisplayAllEmployees(List<Employee> employees)
        {

            // Create a table
            var table = new Table();
            //Set the table border
            table.Border(TableBorder.DoubleEdge);
            //Set the table color
            HasBorderExtensions.BorderColor(table, Color.Aqua);

            table.AddColumn("[red]Eid[/]").Centered();
            table.AddColumn(new TableColumn("[red]Firstname[/]").Centered());
            table.AddColumn(new TableColumn("[red]Lastname[/]").Centered());
            table.AddColumn(new TableColumn("[red]Birthdate[/]").Centered());
            table.AddColumn(new TableColumn("[red]Position[/]").Centered());
            table.AddColumn(new TableColumn("[red]Bordingdate[/]").Centered());
            table.AddColumn(new TableColumn("[red]Salary[/]").RightAligned());
            table.AddColumn(new TableColumn("[red]Full Paid Salary[/]").RightAligned());

            foreach (var employee in employees)
            {
                table.AddRow($"[blue]{employee.Eid}[/]", $"[green]{employee.Firstname}[/]", $"[yellow]{employee.Lastname}[/]", $"[lime]{employee.Birthdate.ToShortDateString()}[/]", $"[purple]{employee.Position}[/]", $"[fuchsia]{employee.Bordingdate.ToShortDateString()}[/]", $"[cyan]{employee.Salary:C2}[/]", $"[magenta]{employee.PaidSalaryOverWorkingPeriod(employee):C2}[/]");
            }
            AnsiConsole.Write(table);
        }

        public Employee GetEmployeeMaxAmount(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                return null;
            }

            Employee maxEmployee = employees[0];

            foreach (var emp in employees)
            {
                if (emp.Salary > maxEmployee.Salary)
                {
                    maxEmployee = emp;
                }
            }

            return maxEmployee;
        }

        public Employee OldestEmployee(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                return null;
            }

            Employee oldestEmployee = employees[0];

            foreach (var emp in employees)
            {
                if (emp.Birthdate < oldestEmployee.Birthdate)
                {
                    oldestEmployee = emp;
                }
            }

            return oldestEmployee;
        }

        public double EmployeeAverageAge(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                return 0;
            }

            double sum = 0;

            foreach (var emp in employees)
            {
                sum += (DateTime.Now - emp.Birthdate).TotalDays / 365;
            }

            return sum / employees.Count;
        }

        public decimal PaidSalaryOverWorkingPeriod(Employee employee)
        {
            decimal sum = 0;

            int workingPeriodMonths = TotalMonths(employee.Bordingdate, DateTime.Now);

            sum += employee.Salary * workingPeriodMonths;

            return sum;
        }

        public static int TotalMonths(DateTime startDate, DateTime endDate)
        {
            int yearDifference = endDate.Year - startDate.Year;
            int monthDifference = endDate.Month - startDate.Month;

            // Berechnung der Gesamtmonate
            int totalMonths = yearDifference * 12 + monthDifference;

            // Anpassung, wenn der Endtag vor dem Starttag liegt
            if (endDate.Day < startDate.Day)
            {
                totalMonths--;
            }

            return totalMonths;
        }
    }
}
