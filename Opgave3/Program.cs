using System;
using System.Threading;

namespace Opgave3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool alive = true;
            Temperature temp = new Temperature();
            Thread t1 = new Thread(temp.GenerateTemp);
            t1.Start();
            while (alive)
            {
                Thread.Sleep(10000);
                if (!t1.IsAlive)
                {
                    alive = false;
                    Console.WriteLine("Alarm-tråd termineret!");
                }
            }
        }
    }
    class Temperature
    {
        public void GenerateTemp()
        {
            Random rnd = new Random();
            int temp;
            int alarms = 0;
            while (alarms < 3)
            {
                Thread.Sleep(200);
                temp = rnd.Next(-20, 120);
                PrintTemp(temp);
                if(temp<0 || temp > 100)
                {
                    PrintAlarm();
                    alarms++;
                }
            }
        }
        public void PrintTemp(int temp)
        {
            Console.WriteLine(temp);
        }
        public void PrintAlarm()
        {
            Console.WriteLine("Alarm");
        }
    }
}
