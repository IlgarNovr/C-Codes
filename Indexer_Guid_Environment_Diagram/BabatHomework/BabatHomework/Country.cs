//Develop an application, which compares population of three capitals of different countries.
//Moreover, a country should be defined as a namespace, and a city — as a class in this space.



//using System;
//using Countrie;
//using USA;
//using Sweden;
//using Japan;


//namespace Countrie{
//    class Capital
//    {
//        private int population;
//        public int Population
//        {
//            get => population;
//            set
//            {
//                if(value < 1)
//                {
//                    throw new ArgumentException();
//                }
//                population = value;
//            }
//        }

//        public string CityName { get; set; }
//        public string GovernorFullName { get; set; }


//        public override bool Equals(object obj)
//        {
//            return obj is Capital capital &&
//                   Population == capital.Population;
//        }

//        public void Compare(Capital capital)
//        {
//            if(Population > capital.Population)
//                Console.WriteLine($"{CityName} has more population than {capital.CityName}");
//            else
//                Console.WriteLine($"{capital.CityName} has more populatioon than {CityName}");
//        }

//        public Capital() { }

//        public Capital(int population, string cityName, string governorFullName)
//        {
//            Population = population;
//            CityName = cityName;
//            GovernorFullName = governorFullName;
//        }
//    }
//}
//namespace USA
//{
//    class WashingtonDC: Capital
//    {
//        public WashingtonDC(int population, string governorFullName):
//            base( population, "Washington D.C", governorFullName) { }
//    }
//}

//namespace Japan
//{
//    class Tokyo: Capital
//    {
//        public Tokyo(int population, string governorFullName) :
//            base(population, "Tokyo", governorFullName)
//        { }
//    }
//}

//namespace Sweden
//{
//    class Stockholm: Capital
//    {
//        public Stockholm(int population, string governorFullName) :
//            base(population, "Stockholm", governorFullName)
//        { }
//    }
//}


//namespace Babat_HW
//{

//    class Program
//    {
//        public static void Main(string[] args)
//        {
//            WashingtonDC washington = new WashingtonDC(5_378_000, "Jay Inslee");
//            Stockholm stockholm = new Stockholm(975_551, "Sven-Erik Österberg");
//            Tokyo tokyo = new Tokyo(13_096_000, "Yuriko Koike");
//            Console.WriteLine(Object.Equals(washington, tokyo));
//            Console.WriteLine(stockholm.Equals(washington));
//            Console.WriteLine();
//            washington.Compare(stockholm);
//            tokyo.Compare(washington);
//            stockholm.Compare(tokyo);

//        }
//    }
//}
