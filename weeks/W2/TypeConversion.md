### [⬅️ Go Back](../../README.md)

# C# Type Conversions Assignment

Assignment Link: [Patika.Dev C# Assignment #3](https://app.patika.dev/courses/csharp-101/6-tip-donusumleri)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
namespace type_conversions;
class Program
{
    static void Main(string[] args)
    {
        // Implicit conversion

        byte a = 5;
        sbyte b = 30;
        short c = 10;

        int d = a + b + c;
        Console.WriteLine(d);

        long h = d;
        Console.WriteLine(h);

        float i = h;
        Console.WriteLine(i);

        string e = "Test";
        char f = 'k';
        object g = e + f + d;
        Console.WriteLine(g);

        // Explicit Conversion

        Console.WriteLine("** Explicit Conversion **");
        int x = 4;
        byte y = (byte)x;
        Console.WriteLine(y);

        int z = 100;
        byte t = (byte)z;
        Console.WriteLine(t);

        float w = 10.3f;
        byte v = (byte)w;
        Console.WriteLine(v);

        // ToString Method

        Console.WriteLine("** ToString Method **");
        int xx = 6;
        string yy = xx.ToString();
        Console.WriteLine(yy);

        string zz = 12.5f.ToString();
        Console.WriteLine(zz);

        // System.Convert

        Console.WriteLine("** System.Convert **");
        string s1 = "10", s2 = "20";
        int num1, num2;
        int sum;

        num1 = Convert.ToInt32(s1);
        num2 = Convert.ToInt32(s2);
        sum = num1 + num2;

        // Parse

        Console.WriteLine("** Parse **");
        ParseMethod();
    }

    public static void ParseMethod()
    {
        string str1 = "10";
        string str2 = "10.25";
        int num1;
        double dub1;

        num1 = Int32.Parse(str1);
        dub1 = Double.Parse(str2);
        Console.WriteLine(num1);
        Console.WriteLine(dub1);
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
