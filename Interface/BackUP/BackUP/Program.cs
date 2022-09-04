using System;

namespace BackUP
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //
            Storage[] storages = new Storage[3]
            {
                new DVD(true,2,"Sony"),
                new Flash(85,8000,"SanDisk"),
                new HDD(22,500_000,"Kingston")
            };

            foreach (var storage in storages)
            {
                storage.PrintDeviceInfo();
                storage.Copy(565_000);
                Console.WriteLine("______________________________________________________");
            }
        }
    }
}
