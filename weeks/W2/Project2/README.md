### [⬅️ Go Back](../../../README.md)

# C# TODO Board - Project #2

Assignment Link: [Patika.Dev C# Project #2](https://app.patika.dev/courses/csharp-101/20-proje-2), My Patika Profile Link: [Kaolin](https://app.patika.dev/kaolin)

## ❓Question 1 :

In a console application, write a TODO application that has three swimlanes. (TODO, INPROGRESS, DONE)

- Add Card
- Update Card
- Remove Card
- Move Card
- List Board

## ✏️Answer 1 :

To view the full code please reference to current directory. You can find the source files here.

**Program Class**

```c#
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
```

**Card Impact Enum**

```c#
namespace Project_2
{
    enum CardImpact
    {
        XS = 1,
        S,
        M,
        L,
        XL
    }
}
```

**Card State Enum**

```c#
namespace Project_2
{
    enum CardState
    {
        TODO = 1,
        IN_PROGRESS,
        DONE
    }
}
```

**Card Class**

```c#
namespace Project_2
{
    class Card
    {
        public static List<Card> cards;
        string _title;
        string _description;
        Int32 _assignedTo;
        CardImpact _impact;
        CardState _state;

        // Constructor
        static Card()
        {
            cards = new List<Card>();
        }

        public Card(string title, string description, int assignedTo, CardImpact impact)
        {
            _title = title;
            _description = description;
            _assignedTo = assignedTo;
            _impact = impact;
            _state = CardState.TODO;
            cards.Add(this);
        }

        // Print Individual Card
        public void Print()
        {
            Console.WriteLine("Title".PadRight(12) + ": " + _title);
            Console.WriteLine("Description".PadRight(12) + ": " + _description);
            Console.WriteLine("Assigned To".PadRight(12) + ": " + Company.getEmployeeById(_assignedTo));
            Console.WriteLine("Impact".PadRight(12) + ": " + _impact);
            Console.WriteLine("-");
        }

        public static void printCards()
        {
            foreach (CardState state in CardState.GetValues(typeof(CardState)))
            {
                int counter = 0;
                Console.WriteLine("\n");
                Console.WriteLine(state.ToString() + " Line");
                Console.WriteLine("***************************");
                foreach (Card card in cards)
                {
                    if (card._state == state)
                    {
                        card.Print();
                        counter++;
                    }
                }
                Console.WriteLine("~ {0} ~", counter == 0 ? "Empty" : counter + " Cards");
            }
        }

        public static void printImpactTypes()
        {
            int count = 1;
            foreach (CardImpact impact in CardImpact.GetValues(typeof(CardImpact)))
            {
                Console.Write("\n -> {0}({1})", impact, count);
                count++;
            }
            Console.WriteLine();
        }

        public static void printStateTypes()
        {
            int count = 1;
            foreach (CardState state in CardState.GetValues(typeof(CardState)))
            {
                Console.Write("\n -> {0}({1})", state, count);
                count++;
            }
            Console.WriteLine();
        }

        public static Card searchByTitle(string title)
        {
            return cards.Find(c => c._title == title);
        }

        public void MoveState(CardState state)
        {
            _state = state;
        }
    }
}
```

**Company Class**

```c#
namespace Project_2
{
    class Company
    {
        public static List<Employee> employees;

        static Company()
        {
            employees = new List<Employee>();
        }

        public static string getEmployeeById(int id)
        {
            Employee? e1 = employees.Find(e => e.id == id);
            if (e1 == null)
            {
                throw new Exception("Employee not found!");
            }
            return e1.name;
        }

        // Print all employees
        public static void printEmployees()
        {
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.name);
            }
        }

        // Print all employees in one line
        public static void printEmployeesOneLine()
        {
            int count = 1;
            foreach (Employee e in employees)
            {
                Console.Write("\n -> {0}-{1} ({2})", e.id, e.name, count);
                count++;
            }
            Console.WriteLine();
        }
    }

    class Employee : Company
    {
        public int id;
        public string name;

        public Employee(int id, string name)
        {
            this.id = id;
            this.name = name;
            Company.employees.Add(this);
        }
    }
}
```

**Menu Class**

```c#
namespace Project_2
{
    static class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("Please select an option :)");
            Console.WriteLine("(1) List Board");
            Console.WriteLine("(2) Add Card to Board");
            Console.WriteLine("(3) Remove Card");
            Console.WriteLine("(4) Move Card");

            // Read key and switch
            char key = Console.ReadKey().KeyChar;
            switch (key)
            {
                case '1':
                    ListBoard();
                    break;
                case '2':
                    AddCard();
                    break;
                case '3':
                    RemoveCard();
                    break;
                case '4':
                    MoveCard();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public static void ListBoard()
        {
            Card.printCards();
            Console.WriteLine("\nPress any key to return to main menu");
            Console.ReadKey();
            MainMenu();
        }

        public static void AddCard()
        {
            try
            {
                Console.Write("\nPlease enter the title of the card".PadRight(41) + ": ");
                string title = Console.ReadLine();

                Console.Write("\nPlease enter the description of the card".PadRight(41) + ": ");
                string description = Console.ReadLine();

                Console.Write("\nPlease enter the employee of the card".PadRight(41) + ": ");
                Company.printEmployeesOneLine();
                int employeeSelection = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                int assignedTo = Company.employees[employeeSelection - 1].id;

                Console.Write("\nPlease enter the impact number".PadRight(41) + ": ");
                Card.printImpactTypes();
                int impactNumber = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                if (Enum.GetValues(typeof(CardImpact)).Length < impactNumber || impactNumber < 1)
                    throw new Exception("Invalid impact number");
                CardImpact impact = (CardImpact)impactNumber;
                Card card = new Card(title, description, assignedTo, impact);

                Console.Write("\nSuccess! Card added. ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                MainMenu();
            }
        }

        public static void RemoveCard()
        {
            try
            {
                Console.Write("\nPlease enter the title of the card".PadRight(50) + ": ");
                string title = Console.ReadLine();

                Card card = Card.searchByTitle(title);
                if (card == null)
                {
                    if (BoolChoice("Back to main menu", "Try again"))
                        MainMenu();
                    else
                        RemoveCard();
                    return;
                }

                Console.WriteLine("Card found: ");
                Console.WriteLine("***************************");
                card.Print();
                if (BoolChoice("Remove card - " + title, "Back to main menu"))
                {
                    Card.cards.Remove(card);
                    Console.Write("\nSuccess! Card removed. ");
                }
                else
                {
                    MainMenu();
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                MainMenu();
            }
        }

        public static void MoveCard()
        {
            try
            {
                Console.Write("\nPlease enter the title of the card".PadRight(50) + ": ");
                string title = Console.ReadLine();
                Card card = Card.searchByTitle(title);
                if (card == null)
                {
                    if (BoolChoice("Back to main menu", "Try again"))
                        MainMenu();
                    else
                        MoveCard();
                    return;
                }

                Console.WriteLine("Card found: ");
                Console.WriteLine("***************************");
                card.Print();
                if (BoolChoice("Move card - " + title, "Back to main menu"))
                {
                    Console.Write("\nPlease enter the new state number".PadRight(50) + ": ");
                    Card.printStateTypes();
                    int stateNumber = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                    if (Enum.GetValues(typeof(CardState)).Length < stateNumber || stateNumber < 1)
                        throw new Exception("Invalid column number");
                    CardState state = (CardState)stateNumber;
                    card.MoveState(state);
                    Console.Write("\nSuccess! Card moved.");
                }
                else
                {
                    MainMenu();
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                MainMenu();
            }
        }

        public static bool BoolChoice(string choice1, string choice2)
        {
            int padLen = Math.Max(choice1.Length, choice2.Length);
            Console.WriteLine("* " + choice1.PadRight(padLen) + ": (1)");
            Console.WriteLine("* " + choice2.PadRight(padLen) + ": (2)");

            int selection = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
            if (selection == 1)
            {
                return true;
            }
            else if (selection == 2)
            {
                return false;
            }
            else
            {
                throw new Exception("Invalid input");
            }
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
