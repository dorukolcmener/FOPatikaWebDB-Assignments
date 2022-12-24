### [⬅️ Go Back](../../../README.md)

# C# Algorithm Questions - Homework #2

Assignment Link: [Patika.Dev C# Homework #2](https://app.patika.dev/courses/csharp-101/15-odev-2)

## ❓Question 1 :

In a console application, ask user to input 20 positive numbers, seperate the numbers into ArrayLists depending on if the number is prime or not.

- Prevent negative/non numeric input.
- Print the numbers in descending order of each ArrayList.
- Print average of each ArrayList.

## ✏️Answer 1 :

```c#
using System.Collections;

namespace Collections_Question_1;
class Program
{
    static void Main(string[] args)
    {
        // Prevent non numeric input
        try
        {
            int n = 20;
            ArrayList primeNumbers = new ArrayList();
            ArrayList nonPrimeNumbers = new ArrayList();

            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter positive numbers ({0}/{1}): ", i + 1, n);
                int inputNumber = int.Parse(Console.ReadLine());
                // Prevent negative numbers
                if (inputNumber < 0)
                {
                    throw new Exception("Number must be positive!");
                }
                int index = CalculationMethods.IsPrime(inputNumber) ? primeNumbers.Add(inputNumber) : nonPrimeNumbers.Add(inputNumber);
            }

            // Prime numbers
            if (primeNumbers.Count > 0)
            {
                Console.WriteLine("*** Prime Numbers ***");
                Console.WriteLine("Prime numbers Count: {0}, Average: {1}", primeNumbers.Count, CalculationMethods.Average(primeNumbers));
                primeNumbers.Sort();
                primeNumbers.Reverse();
                foreach (int prime in primeNumbers)
                {
                    Console.Write(prime.ToString() + ", ");
                }
            }

            // Non prime numbers
            if (nonPrimeNumbers.Count > 0)
            {
                Console.WriteLine("\n*** Non Prime Numbers ***");
                Console.WriteLine("Non prime numbers Count: {0}, Average: {1}", nonPrimeNumbers.Count, CalculationMethods.Average(nonPrimeNumbers));
                nonPrimeNumbers.Sort();
                nonPrimeNumbers.Reverse();
                foreach (int nonPrime in nonPrimeNumbers)
                {
                    Console.Write(nonPrime.ToString() + ", ");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

class CalculationMethods
{
    // Check if number is prime
    public static bool IsPrime(int number)
    {
        bool isPrime = true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        return isPrime;
    }

    // Calculate Average of ArrayList
    public static int Average(ArrayList numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
            sum += number;
        return sum / numbers.Count;
    }
}
```

## ❓Question 2 :

In a console application, ask user to enter n number of integers. Find smallest and largest 3 among them. Print averages of each group and then, sum of averages.

## ✏️Answer 2 :

```c#
namespace Collections_Question_2;
class Program
{
    static void Main(string[] args)
    {
        // Prevent non numeric input
        try
        {
            int n = 20;
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter numbers ({0}/{1}): ", i + 1, n);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // Sort the array
            Array.Sort(numbers);

            // Split the array into smallest 3 and largest 3
            int[] smallest = new int[3];
            int[] largest = new int[3];
            for (int i = 0; i < 3; i++)
            {
                smallest[i] = numbers[i];
                largest[i] = numbers[n - i - 1];
            }

            // Print each number and their average
            Console.WriteLine("Smallest numbers: {0}, {1}, {2} Their average: {3}", smallest[0], smallest[1], smallest[2], CalculationMethods.Average(smallest));
            Console.WriteLine("Largest numbers: {0}, {1}, {2} Their average: {3}", largest[0], largest[1], largest[2], CalculationMethods.Average(largest));
            Console.WriteLine("Sum of averages: {0}", CalculationMethods.Average(smallest) + CalculationMethods.Average(largest));
        }
        catch (Exception)
        {
            Console.WriteLine("Please enter a valid number.");
        }
        finally
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}

class CalculationMethods
{
    public static int Average(int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum / numbers.Length;
    }
}
```

## ❓Question 3 :

In a console application, ask user to enter a sentence. Store vowels in an array and then sort them.

## ✏️Answer 3 :

```c#
namespace Collections_Question_3;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Please enter a sentence: ");
            string sentence = Console.ReadLine();

            char[] letters = sentence.ToCharArray();
            Array.Sort(letters);

            // Find and store vovels in sentence to char array
            string vowels = "aeıioöuüAEIİOÖUÜ";
            char[] vowelsInSentence = letters.Where(c => vowels.Contains(c)).ToArray();

            Array.Sort(vowelsInSentence);
            Console.WriteLine("Vowels of sentence in order: " + string.Join("", vowelsInSentence));

            // Print unique vowels
            Console.WriteLine("Unique vowels of sentence: " + string.Join("", vowelsInSentence.Distinct()));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
