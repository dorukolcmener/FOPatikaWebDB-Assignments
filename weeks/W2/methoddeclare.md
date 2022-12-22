### [⬅️ Go Back](../../README.md)

# C# Method Declaration Assignment

Assignment Link: [Patika.Dev C# Assignment #11](https://app.patika.dev/courses/csharp-101/1-metot-nedir)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace methods;
class Program
{
    static void Main(string[] args)
    {
        int a = 2;
        int b = 3;

        int res = Sum(a, b);
        Console.WriteLine(res);

        Methods method = new Methods();
        method.PrinttoScreen(res.ToString());

        int res2 = method.IncrementandSum(ref a, ref b);
    }

    static int Sum(int val1, int val2)
    {
        return val1 + val2;
    }
}

class Methods
{
    public void PrinttoScreen(string data)
    {
        Console.WriteLine(data);
    }

    public int IncrementandSum(ref int val1, ref int val2)
    {
        val1++;
        val2++;
        return val1 + val2;
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
