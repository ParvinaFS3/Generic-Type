using System;
using System.Collections.Generic;

class Person
{
    private static int idCounter = 1;

    public int Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public Person(string name, string surname, int age)
    {
        Id = idCounter++;
        Name = name;
        Surname = surname;
        Age = age;
    }
}

class Employee : Person
{
    public decimal Salary { get; set; }

    public Employee(string name, string surname, int age, decimal salary) : base(name, surname, age)
    {
        Salary = salary;
    }
}

class CustomCollection
{
    private List<Person> people = new List<Person>();

    public void AddPerson(Person person)
    {
        people.Add(person);
    }

    public void FindEmployeeById(int id)
    {
        Person person = people.Find(p => p is Employee && p.Id == id);

        if (person != null)
        {
            Employee employee = (Employee)person;
            Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Surname: {employee.Surname}, Age: {employee.Age}, Salary: {employee.Salary}");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public void DisplayAllEmployees()
    {
        foreach (Person person in people)
        {
            if (person is Employee)
            {
                Employee employee = (Employee)person;
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Surname: {employee.Surname}, Age: {employee.Age}, Salary: {employee.Salary}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        CustomCollection customCollection = new CustomCollection();

        while (true)
        {
            Console.WriteLine("1) Add an employee\n2) Find employee by id\n3) Find all employee");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your name.: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter your surname.: ");
                    string surname = Console.ReadLine();
                    Console.Write("Enter your age.: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter your salary.: ");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());

                    Employee employee = new Employee(name, surname, age, salary);
                    customCollection.AddPerson(employee);
                    break;

                case "2":
                    Console.Write("Enter the employee id to search for.: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine());
                    customCollection.FindEmployeeById(employeeId);
                    break;

                case "3":
                    customCollection.DisplayAllEmployees();
                    break;

                default:
                    Console.WriteLine("Wrong choice. Please make the right choice.");
                    break;
            }

            Console.Write("Dou you want to continue? (yes/no): ");
            string continueChoice = Console.ReadLine();

            if (continueChoice.ToLower() != "yes")
            {
                break;
            }
        }
    }
}
