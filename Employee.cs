using System;
using System.Text.RegularExpressions;

public abstract class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    private string _phonenumber; 
        public string phonenumber
    {
        get => _phonenumber;

        set
        {
            if (!Regex.IsMatch(value, @"^\+?[1-9]\d{1,14}$")) // E.164 validation
                throw new ArgumentException("Invalid phone number format.");

            _phonenumber = value;
        }

    }
    public bool IsMarried { get; set; }
    public double BaseSalary { get; set; }

    private string _nationalCode;

    public string NationalCode
    {
        get => _nationalCode;
        init
        {
            if (!Regex.IsMatch(value, @"^\d{10}$"))
                throw new ArgumentException("National Code must be a 10-digit number.");
            _nationalCode = value;
        }
    }

    public Employee(string nationalCode)
    {
        NationalCode = nationalCode;

    }
    public virtual double CalculateSalary(int numberOfWorkingDays, int overtimeHours, double familySalary)
    {
        int workingHoursPerDay = 8; // Assuming 8 working hours per day
        double employeeRate = GetEmployeeRate(); // Each derived class will define its rate
        return (numberOfWorkingDays * workingHoursPerDay * BaseSalary) +
               (IsMarried ? familySalary : 0) +
               (overtimeHours * BaseSalary * employeeRate);
    }

    // Abstract Method for Role Explanation
    public abstract string ExplainRole();

    // Method to Get Employee Rate (to be overridden in derived classes)
    protected abstract double GetEmployeeRate();

    // ToString Override
    public override string ToString()
    {
        return $"Name: {FullName}, National Code: {NationalCode}, Phone: {phonenumber}, " +
               $"Married: {IsMarried}, Base Salary: {BaseSalary}";
    }
}
public class SimpleEmployee : Employee
{
    public SimpleEmployee(string nationalCode) : base(nationalCode) { }

    protected override double GetEmployeeRate()
    {
        return 1.1; // Example rate for simple employees
    }

    public override string ExplainRole()
    {
        return "A Simple Employee handles routine tasks in the company.";
    }
}
public class ServiceEmployee : Employee
{
    public ServiceEmployee(string nationalCode) : base(nationalCode) { }

    protected override double GetEmployeeRate()
    {
        return 1.3; // Example rate for service employees
    }

    public override string ExplainRole()
    {
        return "A Service Employee provides support and services.";
    }
}
public class ManagerEmployee : Employee
{
    public ManagerEmployee(string nationalCode) : base(nationalCode) { }

    protected override double GetEmployeeRate()
    {
        return 1.5; // Example rate for managers
    }

    public override string ExplainRole()
    {
        return "A Manager supervises teams and oversees projects.";
    }
}
public class CEOEmployee : Employee
{
    public CEOEmployee(string nationalCode) : base(nationalCode) { }

    protected override double GetEmployeeRate()
    {
        return 2.0; // Example rate for CEOs
    }

    public override string ExplainRole()
    {
        return "The CEO makes strategic decisions for the organization.";
    }
}


