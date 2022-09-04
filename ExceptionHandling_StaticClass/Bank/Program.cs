using System;
using System.Threading;

namespace BANK
{
    class MainClass
    {

        static void AddClients(Bank bank)
        {
            BankCard[] card = new BankCard[5];
            card[0] = new BankCard("Kapital Bank", "1234", 5023.26);
            card[1] = new BankCard("Rabite Bank", "4321", 1999.05);
            card[2] = new BankCard("Pasha Bank", "1000", 18032.56);
            Client[] clients = new Client[5];
            clients[0] = new Client("Qabil", "Memmedov", 45, 300, card[0]);
            clients[1] = new Client("Bayram", "Kurdexanli", 60, 10000, card[1]);
            clients[2] = new Client("Resad", "Dagli", 42, 2102, card[2]);

            for (int i = 0; i < 3; i++)
            {
                try { bank.AddClient(clients[i]); }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        public static int choose(string[] items, int size)
        {
            bool[] isChoosenLine = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                int j = 0;
                foreach (var item in items)
                {
                    if (isChoosenLine[j])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(item);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    j++;
                }
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return index;
                }
                for (int i = 0; i < size; i++)
                {
                    isChoosenLine[i] = false;
                }
                isChoosenLine[index] = true;

            }
        }

        public static void Main(string[] args)
        {

            Bank bank = new Bank();
            bank.BankName = "Kapital";
            AddClients(bank);

            Client client = new Client();
            int index = -1;
            string pin = "";

            string[] menu = new string[] { "Information", "Draw Money", "Exit" };
            string[] money = new string[] { "Add money", "Back" };
            while (true)
            {
                Console.Clear();
                if (index == -1) //enter pin
                {
                    Console.Write("PIN: ");
                    pin = Console.ReadLine();
                    Console.Clear();
                    try { client = bank.GetClientByPIN(pin); }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                        continue;
                    }
                }
                index = choose(menu, 3);
                Console.Clear();
                if (index == 0)//Info
                {
                    Console.WriteLine(client);
                    Console.WriteLine("\nPress Enter to return menu");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                }
                else if (index == 1)//Draw Money
                {
                    int amountOfMoney = 0;
                    index = choose(money, 6);
                    Console.Clear();
                    switch (index)
                    {
                        case 0:
                            { //Add money
                                Console.Write("Enter Amount: ");
                                if (int.TryParse(Console.ReadLine(), out int temp))
                                {
                                    amountOfMoney = temp;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Wrong Information");
                                    Thread.Sleep(1000);
                                    continue;
                                }
                            }
                            break;
                        case 5: continue;//Back
                    }
                    try { bank.DrawMoney(pin, amountOfMoney); }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                    }

                }
                else if (index == 2) { index = -1; } //Exit
            }

        }
    }
}