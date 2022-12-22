### [⬅️ Go Back](../../README.md)

# C# Method Overloading Assignment

Assignment Link: [Patika.Dev C# Assignment #12](https://app.patika.dev/courses/csharp-101/2-metot-overload-nedir-ve-out-kullanimi)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace methods;
class Program
{
    static void Main(string[] args)
    {
        // Out parameters
        string num = "9999";
        bool res = int.TryParse(num, out int outNum);
        if (res)
        {
            Console.WriteLine("Success!");
            Console.WriteLine(outNum);
        }
        else Console.WriteLine("Failed!");

        var method = new Method();
        method.Sum(4, 5, out int sum);
        Console.WriteLine(sum);

        // Method overloading
        int expression = 999;
        method.PrinttoScreen(expression);

        // Method signature
        // Method name + parameters
        method.PrinttoScreen("Hello ", "World!");
    }
}

class Method
{
    public void Sum(int a, int b, out int sum)
    {
        sum = a + b;
    }

    public void PrinttoScreen(string data)
    {
        Console.WriteLine(data);
    }
    public void PrinttoScreen(int data)
    {
        Console.WriteLine(data);
    }
    public void PrinttoScreen(string data1, string data2)
    {
        Console.WriteLine(data1 + data2);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
