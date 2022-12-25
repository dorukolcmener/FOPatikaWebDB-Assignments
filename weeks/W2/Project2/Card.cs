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