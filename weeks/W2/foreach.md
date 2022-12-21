### [⬅️ Go Back](../../README.md)

# C# ForEach Assignment

Assignment Link: [Patika.Dev C# Assignment #8](https://app.patika.dev/courses/csharp-101/2-while-foreach-donguleri)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace feach;
class Program
{
    static void Main(string[] args)
    {
        // Calculate average between 1 and console input with a while loop
        int i = 1;
        int sum = 0;
        Console.Write("Enter a number: ");
        int input = Convert.ToInt32(Console.ReadLine());
        while (i <= input)
        {
            sum += i;
            i++;
        }
        Console.WriteLine(sum / input);

        // Write all characters between a and z with a while loop
        char letter = 'a';
        while (letter <= 'z')
        {
            Console.Write(letter);
            letter++;
        }

        Console.WriteLine("** Foreach **");

        string[] cars = { "BMW", "Ford", "Toyota", "Nissan" };
        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
