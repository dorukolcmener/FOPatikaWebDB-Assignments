### [⬅️ Go Back](../../README.md)

# C# DateTime Methods Assignment

Assignment Link: [Patika.Dev C# Assignment #15](https://app.patika.dev/courses/csharp-101/2-datetime-metotlar)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTime.Now.Date);
        Console.WriteLine(DateTime.Now.Day);
        Console.WriteLine(DateTime.Now.Month);
        Console.WriteLine(DateTime.Now.Year);
        Console.WriteLine(DateTime.Now.Hour);
        Console.WriteLine(DateTime.Now.Minute);
        Console.WriteLine(DateTime.Now.Second);

        Console.WriteLine(DateTime.Now.DayOfWeek);
        Console.WriteLine(DateTime.Now.DayOfYear);

        Console.WriteLine(DateTime.Now.ToLongDateString());
        Console.WriteLine(DateTime.Now.ToShortDateString());
        Console.WriteLine(DateTime.Now.ToLongTimeString());
        Console.WriteLine(DateTime.Now.ToShortTimeString());

        Console.WriteLine(DateTime.Now.AddDays(2));
        Console.WriteLine(DateTime.Now.AddHours(3));
        Console.WriteLine(DateTime.Now.AddSeconds(30));
        Console.WriteLine(DateTime.Now.AddMonths(5));
        Console.WriteLine(DateTime.Now.AddYears(10));
        Console.WriteLine(DateTime.Now.AddMilliseconds(50));

        // DateTime Format
        Console.WriteLine(DateTime.Now.ToString("dd")); // 24
        Console.WriteLine(DateTime.Now.ToString("ddd")); // Sat
        Console.WriteLine(DateTime.Now.ToString("dddd")); // Saturday

        Console.WriteLine(DateTime.Now.ToString("MM")); // 04
        Console.WriteLine(DateTime.Now.ToString("MMM")); // Apr
        Console.WriteLine(DateTime.Now.ToString("MMMM")); // April

        Console.WriteLine(DateTime.Now.ToString("yy")); // 21
        Console.WriteLine(DateTime.Now.ToString("yyyy")); // 2021

        // Math Library
        Console.WriteLine(Math.Abs(-25)); // 25
        Console.WriteLine(Math.Sin(10)); // -0.5440211108893698
        Console.WriteLine(Math.Tan(10)); // 0.6483608274590866

        Console.WriteLine(Math.Ceiling(22.3)); // 23
        Console.WriteLine(Math.Floor(22.3)); // 22
        Console.WriteLine(Math.Round(22.3)); // 22

        Console.WriteLine(Math.Max(2, 6)); // 6
        Console.WriteLine(Math.Min(2, 6)); // 2

        Console.WriteLine(Math.Pow(3, 4)); // 81
        Console.WriteLine(Math.Sqrt(9)); // 3
        Console.WriteLine(Math.Log(9)); // 2.1972245773362196
        Console.WriteLine(Math.Exp(3)); // 20.085536923187668
        Console.WriteLine(Math.Log10(10)); // 1
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
