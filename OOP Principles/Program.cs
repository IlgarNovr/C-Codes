using System;
using System.Threading;

namespace PetShop
{
    class Cat
    {
        public string nickname { get; set; }
        private int Age;

        public int age
        {
            get => Age;
            set
            {
                if (value >= 0)
                {
                    Age = value;
                }
                else Age = 0;
            }
        }

        public int energy { get; private set; }

        public double price { get; set; }

        public int mealQuantity { get; private set; }

        public void Eat()
        {
            if (energy == 10)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The cat is not hungry!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(700);
            }
            else
            {
                mealQuantity++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The amount of food the cat eats: {mealQuantity}");
                Console.ForegroundColor = ConsoleColor.White;
                energy += 1;
                price += 1;
            }
        }

        public void Sleep()
        {
            if (energy == 10)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The cat did not need sleep!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
            }
            else
            {
                int time = 10 - energy;
                while (energy < 10)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cat is Sleeping...(Please wait)");
                    Console.ForegroundColor = ConsoleColor.Red;
                    time--;
                    energy++;
                    Thread.Sleep(1000);
                }
            }
        }

        public void Play()
        {
            if (energy == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The cat is very tired!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
            }
            else
                energy--;
        }

        public Cat()
        {
            nickname = "unknown";
            energy = 10;
            price = 20;
            mealQuantity = 0;
            age = 0;
        }
    }

    class CatHouse
    {
        private Cat[] cats;

        public int catCount { get; private set; }

        public void AddCat(Cat cat)
        {
            Array.Resize<Cat>(ref cats, ++catCount);
            cats[catCount - 1] = cat;
        }

        public string catHouse { get; set; }
        public CatHouse()
        {
            cats = new Cat[0];
            catCount = 0;
            catHouse = "unknown";
        }

        public int ShowAllCats()
        {
            bool[] choose = new bool[catCount + 1];
            int index = 0;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("| Name     | Age | Energy | Price|");
                Console.WriteLine("!----------!-----!--------!------!");
                Console.ForegroundColor = ConsoleColor.White;
                int i = 0;
                foreach (var cat in cats)
                {
                    if (choose[i])
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("| {0,-12}", cat.nickname);
                    Console.Write("{0,-7}", cat.age);
                    Console.Write("{0,-7}", cat.energy);
                    Console.Write("{0,-3}", cat.price);
                    Console.Write("{0,-6}","  |");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    i++;
                }
                if (choose[i])
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t     ________");
                Console.WriteLine("\t     |_Back_|");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = catCount;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == catCount + 1)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return index;
                }
                for (int j = 0; j < catCount + 1; j++)
                {
                    choose[j] = false;
                }
                choose[index] = true;
            }
        }

        public Cat GetCat(int index)
        {
            if (index < catCount)
                return cats[index];
            else
                return cats[0];
        }
    }

    class PetShop
    {
        CatHouse[] catHouses;

        public int catHousesCount { get; set; }

        public void AddCatHouse(CatHouse catHouse)
        {
            Array.Resize<CatHouse>(ref catHouses, ++catHousesCount);
            catHouses[catHousesCount - 1] = catHouse;
        }

        public int ShowAllCatHouses()
        {
            bool[] isThisLine = new bool[catHousesCount + 1];
            int index = 0;
            while (true)
            {
                Console.Clear();
                int j = 0;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(" /___PETSHOP___\\");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var catHouse in catHouses)
                {
                    if (isThisLine[j])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("| "+ catHouse.catHouse+ "\t|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|---------------|");
                    j++;
                }

                if (isThisLine[j])
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("| Exit\t\t|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\\---------------/");
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = catHousesCount;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == catHousesCount + 1)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return index;
                }
                for (int i = 0; i < catHousesCount + 1; i++)
                {
                    isThisLine[i] = false;
                }
                isThisLine[index] = true;
            }
        }

        public CatHouse GetCatHouse(int index)
        {
            if (index < catHousesCount)
                return catHouses[index];
            else
                return catHouses[0];
        }

        public PetShop()
        {
            catHouses = new CatHouse[0];
            catHousesCount = 0;
        }
    }

    class Class
    {
        public static void Main(string[] args)
        {
            PetShop petShop = new PetShop();

            #region Choice
            static int choose(string[] items, int size)
            {
                bool[] isThisLine = new bool[size];
                int index = 0;
                while (true)
                {
                    Console.Clear();
                    int j = 0;
                    foreach (var item in items)
                    {
                        if (isThisLine[j])
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(item);
                        Console.ForegroundColor = ConsoleColor.White;
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
                        isThisLine[i] = false;
                    }
                    isThisLine[index] = true;

                }
            }
            #endregion
          
            #region CatsDATA
            Cat[] cats = new Cat[8];
            CatHouse[] catHouses = new CatHouse[2];

            cats[0] = new Cat();
            cats[0].age = 1;
            cats[0].price = 300;
            cats[0].nickname = "Pisik";

            cats[1] = new Cat();
            cats[1].age = 2;
            cats[1].price = 499;
            cats[1].nickname = "Sari";

            cats[2] = new Cat();
            cats[2].age = 1;
            cats[2].price = 109;
            cats[2].nickname = "Tom";

            cats[3] = new Cat();
            cats[3].age = 3;
            cats[3].price = 250;
            cats[3].nickname = "Jerry";

            catHouses[0] = new CatHouse();
            catHouses[0].catHouse = "Little cats";
            catHouses[0].AddCat(cats[0]);
            catHouses[0].AddCat(cats[1]);
            catHouses[0].AddCat(cats[2]);
            catHouses[0].AddCat(cats[3]);
            petShop.AddCatHouse(catHouses[0]);

            cats[4] = new Cat();
            cats[4].age = 8;
            cats[4].price = 200;
            cats[4].nickname = "Mestan";

            cats[5] = new Cat();
            cats[5].age = 5;
            cats[5].price = 350;
            cats[5].nickname = "Jessica";

            cats[6] = new Cat();
            cats[6].age = 9;
            cats[6].price = 148;
            cats[6].nickname = "Qabil";

            cats[7] = new Cat();
            cats[7].age = 7;
            cats[7].price = 321;
            cats[7].nickname = "Sican";

            catHouses[1] = new CatHouse();
            catHouses[1].catHouse = "Big cats";
            catHouses[1].AddCat(cats[4]);
            catHouses[1].AddCat(cats[5]);
            catHouses[1].AddCat(cats[6]);
            petShop.AddCatHouse(catHouses[1]);
            #endregion

            int menu1index = -1;//House menu
            int menu2index = -1; //Cats menu
            string[] items = new string[] { "Play", "Eat", "Sleep", "Back" };
            while (true)
            {
                Console.Clear();
                if (menu1index == -1)//Show CatHouse
                {
                    menu1index = petShop.ShowAllCatHouses();
                }
                Console.Clear();
                if (menu1index == petShop.catHousesCount)//Exit Program
                {
                    break;
                }
                else // Show Cats
                {
                    if (menu2index == -1) //Show All Cats
                    {
                        menu2index = petShop.GetCatHouse(menu1index).ShowAllCats();
                    }
                    Console.Clear();
                    if (menu2index == petShop.GetCatHouse(menu1index).catCount) //Back
                    {
                        menu2index = -1;
                        menu1index = -1;
                        continue;
                    }
                    else //Play, Eat, Sleep, Back
                    {
                        int catCommand = choose(items, 4);
                        Console.Clear();
                        if (catCommand == 0) //Play
                        {
                            Console.WriteLine("Cat is playing");
                            petShop.GetCatHouse(menu1index).GetCat(menu2index).Play();
                            Thread.Sleep(1000);
                        }
                        else if (catCommand == 1)//Eat
                        {
                            Console.WriteLine("Cat is Eating");
                            petShop.GetCatHouse(menu1index).GetCat(menu2index).Eat();
                            Thread.Sleep(1000);
                        }
                        else if (catCommand == 2)//Sleep
                        {
                            petShop.GetCatHouse(menu1index).GetCat(menu2index).Sleep();
                        }
                        else if (catCommand == 3)//Back
                        {
                            menu2index = -1;
                        }
                    }
                }
            }
        }
    }
}