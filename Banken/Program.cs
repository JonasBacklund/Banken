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
        static void DeleteCustomer()
        {
            Console.WriteLine("Ange ID på kontot du vill radera: ");
            ShowAllCustomers();
            Console.WriteLine(customerList[(int.Parse(Console.ReadLine()))]);
            customerList.RemoveAt(int.Parse(Console.ReadLine()));
        }
        static void ShowAllCustomers()
        {
            int n = 0;
            Console.WriteLine("ID        Namn");
            customerList.ForEach(i => Console.WriteLine(n++ +".        "+ i.ShowCustomerName()));
           
        }
        static void DisplayBalance()
        {
            ShowAllCustomers();
            Console.WriteLine("Ange ID på kontot");
            int id = int.Parse(Console.ReadLine());
            int temp = customerList[id].ShowCustomerBalance();
            Console.WriteLine(temp);
        }
        static void Deposit()
        {
            ShowAllCustomers();
            Console.WriteLine("Ange ID på insättnings kontot");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ange insättningsbelopp");
            int deposit_amount = int.Parse(Console.ReadLine());
            customerList[id].Balance += deposit_amount;
            Console.WriteLine((customerList[id].ShowCustomerBalance()));

        }
        static void Withdrawal()
        {
            ShowAllCustomers();
            Console.WriteLine("Ange ID på kontot");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ange uttagningsbelopp");
            int withdrawal_amount = int.Parse(Console.ReadLine());
            customerList[id].Balance += withdrawal_amount;
            Console.WriteLine("Ditt nya belopp är " + customerList[id].ShowCustomerBalance());

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
            /*
            bool quit = false;
            while (quit == false)
            */
            while (true)
            {
                int choice = Menu();

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        DeleteCustomer();
                        break;
                    case 3:
                        ShowAllCustomers();
                        break;
                    case 4:
                        DisplayBalance();
                        break;
                    case 5:
                        Deposit();
                        break;
                    case 6:
                        Withdrawal();
                        break;
                    case 7:
                        System.Environment.Exit(1);
                        /* quit = true */
                        break;
                }
                Console.WriteLine("------------------------------");
            }

        }
    }
}
