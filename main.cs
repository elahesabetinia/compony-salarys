using System;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        Employee employee = new ManagerEmployee("1234567890")
        {
            FirstName = "Abbass",
            LastName = "Boozar",
            phonenumber = "+1234567890",
            IsMarried = true,
            BaseSalary = 3000
        };

        Console.WriteLine(employee);
        Console.WriteLine("Role: " + employee.ExplainRole());

        double salary1 = employee.CalculateSalary(20, 10, 500);
        Console.WriteLine($"Calculated Salary: {salary1}");

        Employee CEO = new ManagerEmployee("1234567899") 
        {
            FirstName = "Elahe",
            LastName = "Sbetinia",
            phonenumber = "+9834567890",
            IsMarried = false,
            BaseSalary = 120000
        };
        Console.WriteLine(CEO);
        Console.WriteLine("Role: " + employee.ExplainRole());
        double salary2 = employee.CalculateSalary(20, 10, 120000);
        Console.WriteLine($"Calculated Salary: {salary2}");
    }


    
}
