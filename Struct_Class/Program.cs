using System;

namespace ConsoleApp3__maxmin_
{
//___1
/*
    class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public void ShowData()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }

        Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
*/
//*************************************************
    class Program
    {
        class Counter
        {
            public int min { get; set; }

            public int max { get; set; }

            private int currentData;

            public void Increment()
            {
                currentData++;
                if (currentData > max)
                {
                    currentData = min;
                }
            }
            public void Decrement()
            {
                currentData--;
                if (currentData < min)
                {
                    currentData = max;
                }
            }
            public int GetCurrent() => currentData;
            public Counter()
            {
                min = 0;
                max = 0;
                currentData = 0;
            }
            public Counter(int min, int max)
            {
                this.min = min;
                this.max = max;
                currentData = 0;
            }
        }

        static void Main(string[] args)
        {
            Counter counter = new Counter(0, 100);
            Console.Write("Increment:: \n");
            for (int i = 0; i < 100; i++)
            {
                counter.Increment();
                Console.Write(counter.GetCurrent() + " ");
            }
            Console.Write("\nDecrement:: \n");
            for (int i = 0; i < 100; i++)
            {
                counter.Decrement();
                Console.Write(counter.GetCurrent() + " ");
            }
        }
    }
}