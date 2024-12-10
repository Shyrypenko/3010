using System;

public class Employee
{
    private string fullName;
    private DateTime birthDate;
    private string phoneNumber;
    private string email;
    private string position;
    private string responsibilities;
    private decimal salary;

    public string FullName
    {
        get => fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be empty.");
            fullName = value;
        }
    }

    public decimal Salary
    {
        get => salary;
        set
        {
            if (value < 0)
                throw new ArgumentException("Salary cannot be negative.");
            salary = value;
        }
    }

    public Employee(string fullName, DateTime birthDate, decimal salary)
    {
        FullName = fullName;
        this.birthDate = birthDate;
        Salary = salary;
    }

    public static Employee operator +(Employee employee, decimal amount)
    {
        employee.Salary += amount;
        return employee;
    }

    public static Employee operator -(Employee employee, decimal amount)
    {
        employee.Salary -= amount;
        return employee;
    }

    public static bool operator ==(Employee emp1, Employee emp2) => emp1.Salary == emp2.Salary;
    public static bool operator !=(Employee emp1, Employee emp2) => emp1.Salary != emp2.Salary;
    public static bool operator <(Employee emp1, Employee emp2) => emp1.Salary < emp2.Salary;
    public static bool operator >(Employee emp1, Employee emp2) => emp1.Salary > emp2.Salary;

    public override bool Equals(object obj) => obj is Employee emp && this == emp;
    public override int GetHashCode() => Salary.GetHashCode();

    public override string ToString()
    {
        return $"Name: {FullName}, Salary: {Salary:C}";
    }
}