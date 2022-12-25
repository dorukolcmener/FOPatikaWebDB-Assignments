namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact person_Light = new Contact("Light", "Yagami", "+90(552)000-0004");
            Contact person_Touka = new Contact("Touka", "Kirishima", "+44(512)010-0002");
            Contact person_Naruto = new Contact("Naruto", "Uzumaki", "+1(532)200-0200");
            Contact person_Korra = new Contact("Korra", "Avatar", "+70(512)004-0001");
            Contact person_Akame = new Contact("Akame", "Ga Kill", "+80(512)050-0010");

            Contact.ShowMainMenu();
        }
    }
}
