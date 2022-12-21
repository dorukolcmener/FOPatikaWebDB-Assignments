### [⬅️ Go Back](../../README.md)

# C# Loops Assignment

Assignment Link: [Patika.Dev C# Assignment #7](https://app.patika.dev/courses/csharp-101/1-for-dongusu-break-continue)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace loops;
class Program
{
    static void Main(string[] args)
    {
        // Prints all the odd numbers between 1 and 100, separated by a comma.
        Console.WriteLine("Please enter a number: ");
        int counter = int.Parse(Console.ReadLine());
        for (int i = 0; i < counter; i++)
        {
            if (i % 2 == 1)
                Console.WriteLine(i);
        }

        // Prints sum of all odd and even numbers between 1 and 1000.
        int sumOdd = 0;
        int sumEven = 0;
        for (int i = 0; i < 1000; i++)
        {
            if (i % 2 == 1)
                sumOdd += i;
            else
                sumEven += i;
        }

        // Break and Continue
        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
                break;
            Console.WriteLine(i);
        }

        for (int i = 1; i < 10; i++)
        {
            if (i == 4)
                continue;
            Console.WriteLine(i);
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
