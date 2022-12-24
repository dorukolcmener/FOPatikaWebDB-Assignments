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