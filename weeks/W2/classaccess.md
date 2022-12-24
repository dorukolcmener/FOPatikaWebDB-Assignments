### [⬅️ Go Back](../../README.md)

# C# Classes & Access Modifiers Assignment

Assignment Link: [Patika.Dev C# Assignment #18](https://app.patika.dev/courses/csharp-101/1-sinif-field-metot-tanımlama-erişim-belirleyiciler)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        // class ClassName
        // {
        //     [Access Modifier] [Data Type] [Variable Name] = [Value];
        //     [Access Modifier] [Return Type] MethodName([Parameter List]) {
        //          [Method Body]
        //     }
        // }

        // Access Modifiers
        // public - accessible from anywhere
        // private - accessible only from within the class
        // protected - accessible only from within the class and its derived classes
        // internal - accessible only from within the current assembly
        // protected internal - accessible only from within the current assembly or from within a derived class in another assembly

        Employee employee1 = new Employee();
        employee1.Name = "John";
        employee1.Surname = "Doe";
        employee1.No = 23415634;
        employee1.Department = "Human Resources";
        employee1.PrintEmployee();

        Console.WriteLine("***");

        Employee employee2 = new Employee() { Name = "Jane", Surname = "Doe", No = 25646789, Department = "Purchasing" };
        employee2.PrintEmployee();
    }

    class Employee
    {
        public string Name;
        public string Surname;
        public int No;
        public string Department;

        public void PrintEmployee()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Surname: " + Surname);
            Console.WriteLine("No: " + No);
            Console.WriteLine("Department: " + Department);
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
