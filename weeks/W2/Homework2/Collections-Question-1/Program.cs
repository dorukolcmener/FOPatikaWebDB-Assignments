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
