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