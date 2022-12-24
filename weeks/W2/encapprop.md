### [⬅️ Go Back](../../README.md)

# C# Encapsulation & Property Assignment

Assignment Link: [Patika.Dev C# Assignment #20](https://app.patika.dev/courses/csharp-101/3-encapsulation-ve-property-kavrami)

## ❓Question 1 :

Please write down examples given in the course.

## ✏️Answer 1 :

```c#
class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("John", "Doe", 123, 1);
        Student student2 = new Student() { Name = "Jane", Surname = "Doe", No = 456, Year = 2 };
        student1.Print();
        student2.Print();

        Student student3 = new Student("Scott", "Doe", 789, 2);
        student3.Print();
        student3.LevelDown();
        student3.LevelDown();
        student3.Print();
    }

    class Student
    {
        private string name;
        private string surname;
        private int no;
        private int year;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int No { get => no; set => no = value; }
        public int Year
        {
            get => year;
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Year cannot be less than 1");
                    year = 1;
                    return;
                }
                else
                    year = value;
            }
        }

        public Student(string name, string surname, int no, int year)
        {
            Name = name;
            Surname = surname;
            No = no;
            Year = year;
        }
        public Student() { }

        public void Print()
        {
            Console.WriteLine("*** Student Info ***");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("No: " + no);
            Console.WriteLine("Year: " + year);
        }

        public void LevelUp()
        {
            Year++;
        }
        public void LevelDown()
        {
            Year--;
        }
    }
}
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../assets/newPatikaLogo.svg" width=200/></a>
