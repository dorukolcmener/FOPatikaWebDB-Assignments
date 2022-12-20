### [⬅️ Go Back](../../README.md)

# C# Switch Case Assignment

Assignment Link: [Patika.Dev C# Assignment #6](https://app.patika.dev/courses/csharp-101/2-switch-case)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace switchcase;
class Program
{
    static void Main(string[] args)
    {
        int month = DateTime.Now.Month;

        switch (month)
        {
            case 1:
                Console.WriteLine("You are in January.");
                break;
            case 2:
                Console.WriteLine("You are in February.");
                break;
            case 3:
                Console.WriteLine("You are in March.");
                break;
            case 4:
                Console.WriteLine("You are in April.");
                break;
            case 5:
                Console.WriteLine("You are in May.");
                break;
            default: // default case
                Console.WriteLine("You are in another month.");
                break;
        }

        switch (month)
        {
            case 12:
            case 1:
            case 2:
                Console.WriteLine("Winter");
                break;
            case 3:
            case 4:
            case 5:
                Console.WriteLine("Spring");
                break;
            case 6:
            case 7:
            case 8:
                Console.WriteLine("Summer");
                break;
            case 9:
            case 10:
            case 11:
                Console.WriteLine("Autumn");
                break;
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
