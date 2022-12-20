### [⬅️ Go Back](../../README.md)

# C# Variables and Data Types Assignment#1

Assignment Link: [Patika.Dev C# Assignment #1](https://app.patika.dev/courses/csharp-101/4-degiskenler)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
using System;

namespace degisken {
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            value = 10;
            string Variable = " ";
            if(Variable == " ") Console.WriteLine("Variable empty");
            Console.WriteLine(value);

            byte b = 5; //  8 bit
            sbyte sb = 5; // 8 bit
            short s = 5; // 16 bit
            ushort us = 5; // 16 bit
            Int16 i16 = 2; // 16 bit
            int i = 2; // 32 bit
            Int32 i32 = 2; // 32 bit
            Int64 i64 = 2; // 64 bit
            uint ui = 2; // 32 bit
            long l = 4; // 64 bit
            ulong ul = 4; // 64 bit
            float f = 5; // 32 bit
            double d = 5; // 64 bit
            decimal de = 5; // 128 bit
            char c = '2'; // 16 bit
            string str = "2"; // infinite
            bool b1 = true; // 1 bit
            DateTime dt = DateTime.Now; // 64 bit
            Console.WriteLine(dt);

            object o1 = "x";
            object o2 = "y";
            object o3 = 4;
            object o4 = 4.3;

            string str1 = string.Empty;
            str1 = "John Doe";
            string fistname = "John";
            string surname = "Doe";
            string fullname = fistname + " " + surname;

            int integer1 = 5;
            int integer2 = 3;
            int integer3 = integer1 * integer2;

            // bool b1 = 10 < 2;

            string str20 = "20";
            int int20 = 20;
            string newstr20 = str20 + int20.ToString();
            Console.WriteLine(newstr20);

            int int21 = int20 + Convert.ToInt32(str20);

            int int22 = int20 + int.Parse(str20); // 40

            string datetime = DateTime.Now.ToString("dd.MM.yyyy");
            string datetime2 = DateTime.Now.ToString("dd/MM/yyyy");
            string hour = DateTime.Now.ToString("HH:mm");
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
