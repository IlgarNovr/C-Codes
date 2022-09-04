using System;
namespace BackUP
{
    public abstract class Storage
    {
        public string Model { get; set; }

        public string NameOfMedia { get; set; }

        public virtual void PrintDeviceInfo()
        {
            Console.WriteLine($"Model: {Model}\nType: {NameOfMedia}");
        }

        public abstract void Copy(int dataVolume);

        protected Storage(string model, string nameOfMedia)
        {
            Model = model;
            NameOfMedia = nameOfMedia;
        }

        public Storage()
        {
        }
    }
}
