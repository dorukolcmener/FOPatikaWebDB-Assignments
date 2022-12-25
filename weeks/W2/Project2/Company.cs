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