### [⬅️ Go Back](../../README.md)

# C# Array Decleration Access and Loops Assignment

Assignment Link: [Patika.Dev C# Assignment #9](https://app.patika.dev/courses/csharp-101/1-dizi-tanımlama-erişim-ve-döngülerle-kullanım)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace arrays;
class Program
{
    static void Main(string[] args)
    {
        // Define an array of colors
        string[] colors = new string[5];
        string[] animals = { "dog", "cat", "bird", "monkey" };

        int[] series;
        series = new int[5];

        // Assign values to the array
        colors[0] = "blue";
        series[3] = 10;

        Console.WriteLine(animals[1]);
        Console.WriteLine(series[3]);
        Console.WriteLine(colors[0]);

        // Loop through the array
        // Calculate average of n numbers entered by user in for loop
        int sum = 0;
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[arrLen];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("Enter a number: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
            sum += numbers[i];
        }

        Console.WriteLine("Average: " + sum / numbers.Length);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
