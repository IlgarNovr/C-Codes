using System;

namespace Calculator
{
    class Program
    {
        static void Add(in int x, in int y,out float z){
            z = x + y;
            Console.WriteLine(x + " + " + y + " = " + z);
        }

        static void Subtract(in int x, in int y, out float z ){
            z = x - y;
            Console.WriteLine(x + " - " + y + " = " + z);
        }

        static void Multiply(in int x, in int y, out float z){
            z = x * y;
            Console.WriteLine(x + " * " + y + " = " + z);
        }

        static void Divide(in int x, in int y, out float z){
            z = (float)x / y;
            if (x == 0){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("# x must be different from zero.");
            }
            else
            {
                Console.WriteLine(x + " / " + y + " = " + z);
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("   /~-~-~-~-~-~-~-~-~\\");
                Console.WriteLine("     < CALCULATOR. >");
                Console.WriteLine("   \\~-~-~-~-~-~-~-~-~/\n");
                Console.Write("Input first number:: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input second number:: ");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("1.Add\n2.Subtract\n3.Multiply\n4.Divide");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nInput command:: ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nResult:: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                float z;
                switch (count)
                {
                    case 1:
                        {
                            Add(x, y, out z);
                            break;
                        }
                    case 2:
                        {
                            Subtract(x, y, out z);
                            break;
                        }
                    case 3:
                        {
                            Multiply(x, y, out z);
                            break;
                        }
                    case 4:
                        {
                            Divide(x, y, out z);
                            break;
                        }
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect count!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}