### [⬅️ Go Back](../../README.md)

# C# Enums Assignment

Assignment Link: [Patika.Dev C# Assignment #22](https://app.patika.dev/courses/csharp-101/17-enum)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Days.Sun);
        Console.WriteLine((int)Days.Sun);

        int temp = 32;
        if (temp > (int)Temperature.Hot)
        {
            Console.WriteLine("It's hot");
        }
        else if (temp > (int)Temperature.Warm)
        {
            Console.WriteLine("It's warm");
        }
        else if (temp > (int)Temperature.Cool)
        {
            Console.WriteLine("It's cool");
        }
        else
        {
            Console.WriteLine("It's cold");
        }
    }
}

enum Days { Sun = 7, Mon = 1, Tue, Wed, Thu, Fri, Sat };

enum Temperature { Hot = 25, Warm = 20, Cool = 15, Cold = 10 };
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
