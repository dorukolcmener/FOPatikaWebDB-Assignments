### [⬅️ Go Back](../../README.md)

# C# IF Else If Assignment

Assignment Link: [Patika.Dev C# Assignment #5](https://app.patika.dev/courses/csharp-101/1-if-else-yapisi-ve-ternary-if)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace ifelseif;
class Program
{
    static void Main(string[] args)
    {
        int time = DateTime.Now.Hour;
        if (time >= 6 && time < 11)
        {
            Console.WriteLine("Good Morning");
        }
        else if (time >= 11 && time < 18)
        {
            Console.WriteLine("Good Afternoon");
        }
        else
        {
            Console.WriteLine("Good Evening");
        }

        string result = time >= 6 && time < 11 ? "Good Morning" : time <= 18 ? "Good Afternoon" : "Good Evening";
        Console.WriteLine(result);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
