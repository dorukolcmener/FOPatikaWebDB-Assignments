### [⬅️ Go Back](../../README.md)

# C# ArrayList Assignment

Assignment Link: [Patika.Dev C# Assignment #17](https://app.patika.dev/courses/csharp-101/3-arraylist-nedir)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        // System.Collections namespace

        ArrayList arrayList = new ArrayList();
        arrayList.Add("John");
        arrayList.Add(2);
        arrayList.Add(true);
        arrayList.Add('A');

        Console.WriteLine(arrayList[1]);
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        // AddRange
        Console.WriteLine("*** AddRange ***");
        string[] colors = { "Red", "Green", "Blue" };
        List<int> numbers = new List<int>() { 1, 8, 3, 7, 9, 92, 5 };
        arrayList.AddRange(colors);
        arrayList.AddRange(numbers);

        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        // Sort
        Console.WriteLine("*** Sort ***");
        // arrayList.Sort(); // Error

        ArrayList arrayList2 = new ArrayList();
        arrayList2.AddRange(numbers);
        arrayList2.Sort();

        foreach (var item in arrayList2)
        {
            Console.WriteLine(item);
        }

        // BinarySearch
        Console.WriteLine("*** BinarySearch ***");
        Console.WriteLine(arrayList2.BinarySearch(9));

        // Reverse
        Console.WriteLine("*** Reverse ***");
        arrayList2.Reverse();
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
