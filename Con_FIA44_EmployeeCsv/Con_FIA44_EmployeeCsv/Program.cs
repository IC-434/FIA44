using System.Text;

namespace Con_FIA44_EmployeeCsv
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            //Datei einlesen
            if (!File.Exists("Employee.csv"))
            {
                return;
            }

            Employee employee = new Employee();
            List<Employee> employees = employee.ReadAllEmployeesfromCsv("Employee.csv");

            employee.DisplayAllEmployees(employees);

            Console.WriteLine();

            employee = employee.GetEmployeeMaxAmount(employees);
            Console.WriteLine($"The Employee with the highest salary is {employee.Firstname} {employee.Lastname} and earns {employee.Salary:C2}");

            employee = employee.OldestEmployee(employees);
            Console.WriteLine($"The oldest employee is {employee.Firstname} {employee.Lastname} he is {(int)(DateTime.Now - employee.Birthdate).TotalDays / 365} years old.");

            Console.WriteLine($"The average age is {employee.EmployeeAverageAge(employees):F2}");
        }
    }
}
