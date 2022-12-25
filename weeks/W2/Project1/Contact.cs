namespace Project_1
{
    class Contact
    {
        static List<Contact> _contacts;
        string _name;
        string _surname;
        string _phone;

        public Contact(string name, string surname, string phone)
        {
            _name = name;
            _surname = surname;
            _phone = phone;
            _contacts.Add(this);
        }

        static Contact()
        {
            _contacts = new List<Contact>();
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("Please select the desired option :)");
            Console.WriteLine("***********************************");
            Console.WriteLine("(1) Add a new contact");
            Console.WriteLine("(2) Remove a contact");
            Console.WriteLine("(3) Edit a contact's number");
            Console.WriteLine("(4) Print all contacts");
            Console.WriteLine("(5) Search for a contact");

            char input = Console.ReadKey().KeyChar;
            Console.WriteLine("\n***********************************");
            switch (input)
            {
                case '1':
                    AddContact();
                    break;
                case '2':
                    RemoveContact();
                    break;
                case '3':
                    EditContact();
                    break;
                case '4':
                    PrintContacts();
                    break;
                case '5':
                    SearchContact();
                    break;
                default:
                    Console.WriteLine("Invalid input! Exiting the program...");
                    Environment.Exit(0);
                    break;
            }
        }

        public static void AddContact()
        {
            try
            {
                Console.WriteLine("Contact Adding Menu");
                Console.WriteLine("***********************************");

                Console.Write("\nPlease enter the name of the contact".PadRight(47) + ": ");
                string name = Console.ReadLine();
                Console.Write("\nPlease enter the surname of the contact".PadRight(47) + ": ");
                string surname = Console.ReadLine();
                Console.Write("\nPlease enter the phone number of the contact".PadRight(47) + ": ");
                string phone = Console.ReadLine();
                Contact contact = new Contact(name, surname, phone);

                Console.WriteLine("\nContact added successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to go to Main Menu...");
                Console.ReadKey();
                Contact.ShowMainMenu();
            }
        }

        public static void RemoveContact()
        {
            try
            {
                Console.WriteLine("Contact Remove Menu");
                Console.WriteLine("***********************************");

                Console.Write("\nPlease enter the name or the surname you want to remove: ");
                string nameInput = Console.ReadLine().Split(' ')[0].ToLower();

                bool success = false;
                foreach (Contact contact in _contacts)
                {
                    if (contact._name.ToLower() == nameInput || contact._surname.ToLower() == nameInput)
                    {
                        Console.WriteLine("{0} {1} - is going to be removed. Do you approve? (y/n)", contact._name, contact._surname);
                        char input = Console.ReadKey().KeyChar;
                        if (input != 'y')
                        {
                            Console.WriteLine("\nContact not removed!");
                            ShowMainMenu();
                            return;
                        }
                        else
                        {
                            _contacts.Remove(contact);
                            Console.WriteLine("\nContact removed successfully!");
                            success = true;
                            break;
                        }
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Contact not found! Please make a decision.");
                    Console.WriteLine("* To exit Remove Menu, and go to Main Menu".PadRight(50) + ": (1)");
                    Console.WriteLine("* To try again".PadRight(50) + ": (2)");
                    char input = Console.ReadKey().KeyChar;
                    if (input == '1')
                    {
                        ShowMainMenu();
                        return;
                    }
                    else if (input == '2')
                    {
                        RemoveContact();
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to go to Main Menu...");
                Console.ReadKey();
                Contact.ShowMainMenu();
            }
        }

        public static void EditContact()
        {
            try
            {
                Console.WriteLine("Contact Edit Menu");
                Console.WriteLine("***********************************");

                Console.Write("\nPlease enter the name or the surname you want to edit: ");
                string nameInput = Console.ReadLine().Split(' ')[0].ToLower();

                bool success = false;
                foreach (Contact contact in _contacts)
                {
                    if (contact._name.ToLower() == nameInput || contact._surname.ToLower() == nameInput)
                    {
                        Console.WriteLine("{0} {1} - is going to be edited. Do you approve? (y/n)", contact._name, contact._surname);
                        char input = Console.ReadKey().KeyChar;
                        if (input != 'y')
                        {
                            Console.WriteLine("\nContact not edited!");
                            ShowMainMenu();
                            return;
                        }
                        else
                        {
                            Console.Write("\nPlease enter the new phone number: ");
                            contact._phone = Console.ReadLine();
                            Console.WriteLine("\nContact edited successfully!");
                            success = true;
                            break;
                        }
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Contact not found! Please make a decision.");
                    Console.WriteLine("* To exit Edit Menu, and go to Main Menu".PadRight(50) + ": (1)");
                    Console.WriteLine("* To try again".PadRight(50) + ": (2)");
                    // Press 1 to go to main menu, press to 2 try again
                    char input = Console.ReadKey().KeyChar;
                    if (input == '1')
                    {
                        ShowMainMenu();
                    }
                    else if (input == '2')
                    {
                        EditContact();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Contact.ShowMainMenu();
            }
        }

        public static void PrintContacts()
        {
            try
            {
                Console.WriteLine("Decide List Order: ");
                Console.WriteLine("* Ascending (1) A-Z");
                Console.WriteLine("* Descending (2) Z-A");
                int decision = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                var sortedContacts = (decision == 1 ? _contacts.OrderBy(x => x._name).ToList() : _contacts.OrderByDescending(x => x._name).ToList());

                Console.WriteLine("Contact Book");
                Console.WriteLine("***********************************");

                foreach (Contact contact in sortedContacts)
                {
                    // Write name
                    Console.WriteLine("Name: " + contact._name);
                    // Write surname
                    Console.WriteLine("Surname: " + contact._surname);
                    // Write phone
                    Console.WriteLine("Phone: " + contact._phone);

                    Console.WriteLine("-");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to go to Main Menu");
                Console.ReadKey();
                Contact.ShowMainMenu();
            }
        }

        public static void SearchContact()
        {
            try
            {
                Console.WriteLine("Contact Search Menu");
                Console.WriteLine("***********************************");

                bool success = false;

                Console.Write("\nTo search by name or surname".PadRight(30) + ": (1)");
                Console.Write("\nTo search by phone number".PadRight(30) + ": (2)\n");

                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case '1':
                        {
                            Console.Write("\nPlease enter the name or the surname you want to search: ");
                            string nameInput = Console.ReadLine().Split(' ')[0].ToLower();
                            foreach (Contact contact in _contacts)
                            {
                                if (contact._name.ToLower() == nameInput || contact._surname.ToLower() == nameInput)
                                {
                                    Console.WriteLine("{0} {1} - is found.", contact._name, contact._surname);
                                    Console.WriteLine("Phone: " + contact._phone);
                                    Console.WriteLine("-");
                                    success = true;
                                }
                            }
                            break;
                        }
                    case '2':
                        {
                            Console.Write("\nPlease enter the phone number you want to search: ");
                            string phoneInput = Console.ReadLine();
                            foreach (Contact contact in _contacts)
                            {
                                if (contact._phone == phoneInput)
                                {
                                    Console.WriteLine("{0} {1} - is found.", contact._name, contact._surname);
                                    Console.WriteLine("Phone: " + contact._phone);
                                    Console.WriteLine("-");
                                    success = true;
                                }
                            }
                            break;
                        }
                }

                if (!success)
                {
                    Console.WriteLine("Contact not found! Please make a decision.");
                    Console.WriteLine("* To exit Search Menu, and go to Main Menu".PadRight(50) + ": (1)");
                    Console.WriteLine("* To try again".PadRight(50) + ": (2)");
                    // Press 1 to go to main menu, press to 2 try again
                    char decision = Console.ReadKey().KeyChar;
                    if (decision == '1')
                    {
                        ShowMainMenu();
                    }
                    else if (decision == '2')
                    {
                        SearchContact();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to go to Main Menu");
                Console.ReadKey();
                Contact.ShowMainMenu();
            }
        }
    }
}