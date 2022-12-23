### [⬅️ Go Back](../../README.md)

# C# String Methods Assignment

Assignment Link: [Patika.Dev C# Assignment #14](https://app.patika.dev/courses/csharp-101/1-string-metotlar)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        string var = "Welcome to C# class";
        string var2 = "C# class";

        // Length
        Console.WriteLine(var.Length);

        // ToUpper, ToLower
        Console.WriteLine(var.ToUpper());
        Console.WriteLine(var.ToLower());

        // Concat
        Console.WriteLine(var.Concat(" Hi!"));

        // Compare, CompareTo
        Console.WriteLine(var.CompareTo(var2));
        Console.WriteLine(String.Compare(var, var2, true));
        Console.WriteLine(String.Compare(var, var2, false));

        // Contains
        Console.WriteLine(var.Contains(var2));
        Console.WriteLine(var.StartsWith("Welcome"));
        Console.WriteLine(var.EndsWith("class"));

        // IndexOf
        Console.WriteLine(var.IndexOf("C#"));
        Console.WriteLine(var.LastIndexOf("JohnDoe"));

        // Insert
        Console.WriteLine(var.Insert(0, "Hello! "));
        Console.WriteLine(var.LastIndexOf("as"));

        // PadLeft, PadRight
        Console.WriteLine(var.PadLeft(30));
        Console.WriteLine(var.PadRight(30, '*'));

        // Remove
        Console.WriteLine(var.Remove(0, 7));
        Console.WriteLine(var.Remove(5));

        // Replace
        Console.WriteLine(var.Replace("C#", "Java"));
        Console.WriteLine(var.Replace(" ", "*"));

        // Split
        Console.WriteLine(var.Split(' ')[0]);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
