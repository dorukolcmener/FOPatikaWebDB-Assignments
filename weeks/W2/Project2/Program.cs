namespace Project_2;
class Program
{
    static void Main(string[] args)
    {
        Employee employee_Sakura = new Employee(102905, "Sakura");
        Employee employee_Esdeath = new Employee(506493, "Esdeath");
        Employee employee_Shiki = new Employee(312531, "Shiki");

        Card card_Feature1 = new Card("Feature 1", "Description 1", employee_Sakura.id, CardImpact.S);
        Card card_Feature2 = new Card("Feature 2", "Description 2", employee_Esdeath.id, CardImpact.M);
        Card card_Feature3 = new Card("Feature 3", "Description 3", employee_Shiki.id, CardImpact.L);

        Menu.MainMenu();
    }
}