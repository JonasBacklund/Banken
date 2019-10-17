using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Banken
{
    class Program
    {

        static List<Customer> customerList = new List<Customer>();
        static int id = 0;
        static int amount = 0;
        static int choice = 0;
        


        static void InputInt(string dataType)
        {
            if (dataType == "amount")
            {
                bool inputBool = int.TryParse(Console.ReadLine(), out amount);
                while (!inputBool)
                {
                    if (!inputBool)
                    {
                        Console.WriteLine("Ogiltiga tecken, Försök igen med siffror:");
                        inputBool = int.TryParse(Console.ReadLine(), out amount);
                    }
                }

            }
            else if (dataType == "id")
            {
                bool inputBool = int.TryParse(Console.ReadLine(), out id);
                while (!inputBool)
                {
                    if (!inputBool)
                    {
                        Console.WriteLine("Ogiltiga tecken, Försök igen med siffror:");
                        inputBool = int.TryParse(Console.ReadLine(), out id);
                    }
                }
            }
        }
        static void AddCustomer()
        {
            Customer user = new Customer();
            Console.WriteLine("Lägga till en användare");
            Console.Write("Ange Namn: ");
            user.Name = Console.ReadLine();
            Console.Write("Ange pengar summa: ");
            InputInt("amount");
            user.Balance = amount;
            customerList.Add(user);
    
        }
        static void DeleteCustomer()
        {
            Console.WriteLine("Ange ID på kontot du vill radera: ");
            ShowAllCustomers();
            InputInt("id");
            customerList.RemoveAt(id);
        }
        static void ShowAllCustomers()
        {
            int n = 0;
            Console.WriteLine("------------------------------");
            Console.WriteLine("ID        Namn");
            customerList.ForEach(i => Console.WriteLine(n++ +".        "+ i.ShowCustomerName()));
            Console.WriteLine("------------------------------");

        }
        static void DisplayBalance()
        {
            ShowAllCustomers();
            Console.WriteLine("Ange ID på kontot");
            InputInt("id");
            Console.WriteLine(customerList[id].ShowCustomerBalance());
        }
        static void Deposit()
        {
            ShowAllCustomers();
            Console.WriteLine("Ange ID på insättnings kontot");
            InputInt("id");
            Console.WriteLine("Ange insättningsbelopp");
            InputInt("amount");
            customerList[id].Balance += amount;
            Console.WriteLine("Ditt nya belopp är " + customerList[id].ShowCustomerBalance());

        }
        static void Withdrawal()
        {

            ShowAllCustomers();
            Console.WriteLine("Ange ID på kontot");
            InputInt("id");
            Console.WriteLine("Ange uttagningsbelopp");
            InputInt("amount");
            customerList[id].Balance += amount * -1;
            Console.WriteLine("Ditt nya belopp är " + customerList[id].ShowCustomerBalance());

        }


        static void Menu()
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
            bool inputBool = int.TryParse(Console.ReadLine(), out choice);
            while (!inputBool)
            {
                if (!inputBool)
                {
                    Console.WriteLine("Ogiltiga tecken, Försök igen med siffror:");
                    inputBool = int.TryParse(Console.ReadLine(), out choice);
                }
            }
        }
        
        static void Main(string[] args)
        {
            string dir = @"save\";
            string file = "details.txt";
            string dirFile = dir + file;
            try
            {
                if (File.Exists(dirFile))
                {
                    string JsonText = File.ReadAllText(dirFile);
                    customerList = JsonConvert.DeserializeObject<List<Customer>>(JsonText);
                }
            }
            catch (JsonSerializationException)
            {
                Console.WriteLine("Felaktigt format i datafil");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            while (true)
            {
                Menu();
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
                        if (Directory.Exists(dir) == false)
                        {
                            Directory.CreateDirectory(dir);
                        }
                        if (File.Exists(dirFile) == false)
                        {
                            var tempFile = File.Create(dirFile);
                            tempFile.Close();
                            
                        }
                        string json = JsonConvert.SerializeObject(customerList);
                        File.WriteAllText(dirFile, json);
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Ange siffran som korresponderar med ditt önskade alternativ");
                        break;
                }
                Console.WriteLine("------------------------------");
            }

        }
    }
}
