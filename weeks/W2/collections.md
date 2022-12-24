### [⬅️ Go Back](../../README.md)

# C# Generic Collections Assignment

Assignment Link: [Patika.Dev C# Assignment #16](https://app.patika.dev/courses/csharp-101/2-generic-koleksiyonlar)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        // List<T> class
        // System.Collections.Generic
        // T -> Object Type

        List<int> numbers = new List<int>();
        numbers.Add(23);
        numbers.Add(10);
        numbers.Add(5);
        numbers.Add(4);
        numbers.Add(92);
        numbers.Add(34);

        List<string> colorList = new List<string>();
        colorList.Add("Red");
        colorList.Add("Blue");
        colorList.Add("Orange");
        colorList.Add("Yellow");
        colorList.Add("Green");

        // Count
        Console.WriteLine("Count: " + numbers.Count);
        Console.WriteLine("Count: " + colorList.Count);

        // Access to members of list
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        foreach (string color in colorList)
        {
            Console.WriteLine(color);
        }

        numbers.ForEach(num => Console.WriteLine(num));
        colorList.ForEach(color => Console.WriteLine(color));

        // Remove
        numbers.Remove(4);
        colorList.Remove("Green");

        numbers.RemoveAt(0);
        colorList.RemoveAt(1);

        numbers.ForEach(num => Console.WriteLine(num));
        colorList.ForEach(color => Console.WriteLine(color));

        // Search in a list
        if (numbers.Contains(10))
        {
            Console.WriteLine("10 is in the list");
        }

        Console.WriteLine("Index of 92: " + numbers.IndexOf(92));
        Console.WriteLine("Index of Orange: " + colorList.BinarySearch("Orange"));

        // Convert array to list
        string[] animals = { "Cat", "Dog", "Bird" };
        List<string> animalList = new List<string>(animals);

        // Add objects to list
        List<User> userList = new List<User>();

        userList.Add(new User { Name = "John", Surname = "Doe", Age = 25 });

        User user2 = new User();
        user2.Name = "Jane";
        user2.Surname = "Doe";
        user2.Age = 22;
        userList.Add(user2);

        foreach (User user in userList)
        {
            Console.WriteLine(user.Name + " " + user.Surname + " " + user.Age);
        }
    }

    class User
    {
        string name;
        string surname;
        int age;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
