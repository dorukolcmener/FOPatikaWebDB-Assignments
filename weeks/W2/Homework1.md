### [⬅️ Go Back](../../README.md)

# C# Algorithm Questions - Homework #1

Assignment Link: [Patika.Dev C# Homework #1](https://app.patika.dev/courses/csharp-101/12-odev-1)

## ❓Question 1 :

In a console application, ask user to input a positive number n. Then, prompt user to enter n number of positive numbers. Print even numbers among entered values.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        // C# HW1 Question 1 Answer
        try
        {
            Console.Write("Please enter a positive number: ");
            int number = int.Parse(Console.ReadLine());
            if (number > 0)
            {
                int[] numbers = new int[number];
                for (int i = 0; i < number; i++)
                {
                    Console.Write("Please enter positive numbers ({0}/{1}): ", i + 1, number);
                    numbers[i] = int.Parse(Console.ReadLine());
                    if (numbers[i] < 0)
                    {
                        throw new Exception("The number must be positive!");
                    }
                }
                Console.WriteLine("The even numbers are: ");
                for (int i = 0; i < number; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
            else throw new Exception("The number must be positive!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

## ❓Question 2 :

In a console application, ask user to input two positive numbers (n,m). Then, prompt user to enter n number of positive numbers. Print the ones that is either equal to m or can be divided by m.

## ✏️Answer 2 :

```c#
class Program
{
    static void Main(string[] args)
    {
        // C# HW1 Question 2 Answer
        try
        {
            Console.Write("Please enter two positive numbers seperated by comma (i.e 1,2): ");
            string[] input = Console.ReadLine().Split(",");
            if (input.Length != 2)
            {
                throw new Exception("You must enter two numbers seperated by comma.");
            }

            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter positive numbers ({0}/{1}): ", i + 1, n);
                numbers[i] = int.Parse(Console.ReadLine());
                if (numbers[i] < 0)
                {
                    throw new Exception("The number must be positive!");
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (numbers[i] == m || numbers[i] % m == 0)
                    Console.WriteLine(numbers[i]);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

## ❓Question 3 :

In a console application, ask user to enter a positive number n. Then, ask user to enter n number of words. Print words in reverse order.

## ✏️Answer 3 :

```c#
class Program
{
    static void Main(string[] args)
    {
        // C# HW1 Question 3 Answer
        try
        {
            Console.Write("Please enter a positive number: ");
            int number = int.Parse(Console.ReadLine());
            if (number > 0)
            {
                string[] words = new string[number];
                for (int i = 0; i < number; i++)
                {
                    Console.Write("Please enter a  word ({0}/{1}): ", i + 1, number);
                    words[i] = Console.ReadLine();
                }
                Console.WriteLine("Words in reverse order from last entered to first:");
                for (int i = number - 1; i >= 0; i--)
                {
                    Console.WriteLine(words[i]);
                }
            }
            else throw new Exception("The number must be positive!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

## ❓Question 4 :

In a console application, ask user to enter a sentence. Then, print total number of words and letters.

## ✏️Answer :

```c#
class Program
{
    static void Main(string[] args)
    {
        // C# HW1 Question 4 Answer
        try
        {
            Console.Write("Please enter a sentence: ");
            string sentence = Console.ReadLine();
            Console.WriteLine("Number of words: " + sentence.Split(" ").Length);
            Console.WriteLine("Number of letters: " + sentence.Replace(" ", "").Length);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
