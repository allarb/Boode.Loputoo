using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Tee valik");
        Console.WriteLine("1. GroupBy");
        Console.WriteLine("2. FirstOrDefault");
        Console.WriteLine("3. IFjaElse");
        Console.WriteLine("4. Püramiid");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                GroupBy();
                break;
            case "2":
                FirstOrDefault();
                break;
            case "3":
                IFjaElse();
                break;
            case "4":
                Pyramid();
                break;
            default:
                Console.WriteLine("Vale valik");
                break;
        }
    }

  
    public static void GroupBy()
    {
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Robert", Age = 30 },
            new Person { Name = "Alice", Age = 35 }
        };

        var grouped = people.GroupBy(person => person.Name);

        Console.WriteLine("\nGrouped by nime järgi:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"Nimi: {group.Key}");
            foreach (var person in group)
            {
                Console.WriteLine($"  Vanus: {person.Age}");
            }
        }
    }

   
    public static void FirstOrDefault()
    {
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Robert", Age = 30 },
            new Person { Name = "Alice", Age = 35 }
        };

        Console.WriteLine("\nSisesta nimi mida otsid:");
        string searchName = Console.ReadLine();

        var result = people.FirstOrDefault(person => person.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (result != null)
        {
            Console.WriteLine($"Leitud inimene: {result.Name}, Vanus: {result.Age}");
        }
        else
        {
            Console.WriteLine("Inimest ei leitud.");
        }
    }

   
    public static void IFjaElse()
    {
        Console.WriteLine("\nSisesta tekst mida soovid salvestada:");
        string userInput = Console.ReadLine();

        Console.WriteLine("Sisesta faili tee kuhu soovid salvestada:");
        string filePath = Console.ReadLine();

        try
        {
            File.WriteAllText(filePath, userInput);
            Console.WriteLine("Fail on edukalt salvestatud.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Esines viga: {ex.Message}");
        }
    }

    
    public static void Pyramid()
    {
        Console.WriteLine("\nSisesta püramiidi kõrgus:");
        if (int.TryParse(Console.ReadLine(), out int rows) && rows > 0)
        {
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Vale sisend, proovi uuesti.");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}