### [⬅️ Go Back](../../README.md)

# C# Static Class & Members Assignment

Assignment Link: [Patika.Dev C# Assignment #21](https://app.patika.dev/courses/csharp-101/4-static-sinif-ve-uyeler)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Employee Count: {0}", Employee.EmployeeCount);
        Employee employee1 = new Employee("John", "Doe", "IT");
        Console.WriteLine("Employee Count: {0}", Employee.EmployeeCount);

        Console.WriteLine("Add: {0}", Calculations.Add(5, 5));
        Console.WriteLine("Subtract: {0}", Calculations.Subtract(5, 5));
    }
}

class Employee
{
    private static int employeeCount;

    public static int EmployeeCount
    {
        get => employeeCount;
    }

    private string Name;
    private string Surname;
    private string Department;

    static Employee()
    {
        employeeCount = 0;
    }

    public Employee(string name, string surname, string department)
    {
        Name = name;
        Surname = surname;
        Department = department;
        employeeCount++;
    }
}

class Calculations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Subtract(int a, int b)
    {
        return a - b;
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
