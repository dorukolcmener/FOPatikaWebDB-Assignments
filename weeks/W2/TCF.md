### [⬅️ Go Back](../../README.md)

# C# Try Catch Finally Assignment

Assignment Link: [Patika.Dev C# Assignment #4](https://app.patika.dev/courses/csharp-101/1-try-catch-finally-ve-mantiksal-hatalar)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace error_handling;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input number is: " + num);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        // finally
        // {
        //     Console.WriteLine("Finally block is always executed.");
        // }

        try
        {
            // int a = int.Parse(null);
            // int a = int.Parse("abc");
            int a = int.Parse("-2000000000000");
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: " + e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine("FormatException: " + e.Message);
        }
        catch (OverflowException e)
        {
            Console.WriteLine("OverflowException: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Finally block is always executed.");
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
