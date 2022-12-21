### [⬅️ Go Back](../../README.md)

# C# Array Methods Assignment

Assignment Link: [Patika.Dev C# Assignment #10](https://app.patika.dev/courses/csharp-101/2-array-sinifi-ve-methodlari)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace arrays;
class Program
{
    static void Main(string[] args)
    {
        // Sort an array of numbers
        int[] numbers = { 23, 12, 4, 86, 72, 3, 11, 17 };
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
        Array.Sort(numbers);
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }

        // Clear an array
        Console.WriteLine("\n**** Array Clear ****");
        Array.Clear(numbers, 2, 2);
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }

        // Reverse an array
        Console.WriteLine("\n**** Array Reverse ****");
        Array.Reverse(numbers);
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }

        // IndexOf
        Console.WriteLine("\n**** Array IndexOf ****");
        Console.WriteLine(Array.IndexOf(numbers, 23));

        // Resize an array
        Console.WriteLine("\n**** Array Resize ****");
        Array.Resize<int>(ref numbers, 9);
        numbers[8] = 99;
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
