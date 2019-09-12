using System;
using System.Collections.Generic;

namespace Banken
{
    class Program
    {
        static List<Customer> customerList = new List<Customer>();
        static void AddCustomer()
        {
            Customer user = new Customer();
            Console.WriteLine("Lägga till en användare");
            Console.Write("Ange Namn: ");
            user.Name = Console.ReadLine();
            Console.Write("Ange pengar summa: ");
            user.Balance = int.Parse(Console.ReadLine());
            customerList.Add(user);
        }
        static void ShowCustomers()
        {
            Console.Write(customerList);
           
        }

    
        static int Menu()
        {
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine("");
            Console.WriteLine("Ange vilket av följande alternativ du önskar att göra");
            Console.WriteLine("");
            Console.WriteLine("1 : Lägga till en användare");
            Console.WriteLine("2 : Ta bort en användare");
            Console.WriteLine("3 : Visa alla befintliga användare");
            Console.WriteLine("4 : Visa saldo för en användare");
            Console.WriteLine("5 : Gör en insättning för en användare");
            Console.WriteLine("6 : Gör ett uttag för en användare");
            Console.WriteLine("7 : Avsluta programmet");
            Console.WriteLine("");
            Console.Write("Skriv in ditt val: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = Menu();

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        break;
                    case 3:
                        ShowCustomers();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }
            }

        }
    }
}
