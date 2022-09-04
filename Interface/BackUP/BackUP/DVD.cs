using System;
namespace BackUP
{
    public class DVD: Storage
    {

        public bool isTwoSide { get; set; }

        public int Speed { get; set; }

        public int Volume { get; private set; }

        public override void PrintDeviceInfo()
        {
            base.PrintDeviceInfo();
            Console.WriteLine($"Speed: {Speed}mb/s\nVolume: {Volume} MB,\nIs two side: {isTwoSide}");
        }

        public override void Copy(int dataVolume) //Data volume should be in MB
        {
            double quantity = Convert.ToDouble(dataVolume) / Volume;
            if (quantity - (int)quantity != 0)
                quantity += 1;
            int time = dataVolume / Speed;
            int hour = time / 3600;
            int min = (time - (hour * 3600)) / 60;
            int sec = time - (min * 60 + hour * 3600);
            Console.WriteLine($"Time it takes to write all file: {hour} hour, {min} min,{sec} sec");
            Console.WriteLine($"Amount of DVD needed: {((int)quantity)}");
        }

        public DVD(bool isTwoSide, int speed, string model) : base(model, "DVD")
        {
            this.isTwoSide = isTwoSide;
            Speed = speed;
            if (isTwoSide)
                Volume = 9000;
            else
                Volume = 4700;
        }
    }
}
