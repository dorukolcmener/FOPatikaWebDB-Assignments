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