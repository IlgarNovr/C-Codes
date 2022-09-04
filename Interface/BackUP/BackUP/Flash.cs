using System;
namespace BackUP
{
    public class Flash : Storage
    {
        public int Speed { get; set; }

        public int Volume { get; set; }

        public override void PrintDeviceInfo()
        {
            base.PrintDeviceInfo();
            Console.WriteLine($"Speed: {Speed}mb/s\nVolume: {Volume} MB");
        }

        public override void Copy(int dataVolume)
        {
            double quantity = Convert.ToDouble(dataVolume) / Volume;
            if (quantity - (int)quantity != 0)
                quantity += 1;
            int time = dataVolume / Speed;
            int hour = time / 3600;
            int min = (time - (hour * 3600)) / 60;
            int sec = time - (min * 60 + hour * 3600);
            Console.WriteLine($"Time it takes to write all file: {hour} hour, {min} min,{sec} sec");
            Console.WriteLine($"Amount of HDD needed: {((int)quantity)}");
        }

        public Flash(int speed, int volume, string model) : base(model, "Flash")
        {
            Speed = speed;
            Volume = volume;
        }  
    }
}
