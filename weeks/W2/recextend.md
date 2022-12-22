### [⬅️ Go Back](../../README.md)

# C# Recursion & Extension Methods Assignment

Assignment Link: [Patika.Dev C# Assignment #13](https://app.patika.dev/courses/csharp-101/3-extension-recursive-metotlar)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace methods;
class Program
{
    static void Main(string[] args)
    {
        // Recursive Functions
        int result = 1;
        for (int i = 1; i <= 5; i++)
            result *= 3;
        Console.WriteLine(result);

        Method method = new Method();
        Console.WriteLine(method.Expo(3, 4));

        // Extension Methods
        string expression = "John Doe";
        bool res = expression.Checkspaces();
        Console.WriteLine(res);
        if (res) Console.WriteLine(expression.RemoveSpaces());
        Console.WriteLine(expression.MakeUpperCase());
        Console.WriteLine(expression.MakeLowerCase());

        int[] series = { 9, 3, 6, 2, 1, 5, 0 };
        series.SortArray();
        series.PrinttoScreen();

        int number = 5;
        Console.WriteLine(number.isEven());
        Console.WriteLine(expression.GetFirstCharacter());
    }
}

public class Method
{
    public int Expo(int num, int pow)
    {
        if (pow < 2) return num;
        return Expo(num, pow - 1) * num;
    }
}

public static class Extension
{
    public static bool Checkspaces(this string param)
    {
        return param.Contains(" ");
    }

    public static string RemoveSpaces(this string param)
    {
        string[] array = param.Split(" ");
        return string.Join("", array);
    }

    public static string MakeUpperCase(this string param)
    {
        return param.ToUpper();
    }

    public static string MakeLowerCase(this string param)
    {
        return param.ToLower();
    }

    public static int[] SortArray(this int[] param)
    {
        Array.Sort(param);
        return param;
    }

    public static void PrinttoScreen(this int[] param)
    {
        foreach (var item in param)
        {
            Console.WriteLine(item);
        }
    }

    public static bool isEven(this int param)
    {
        return param % 2 == 0;
    }

    public static string GetFirstCharacter(this string param)
    {
        return param.Substring(0, 1);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
