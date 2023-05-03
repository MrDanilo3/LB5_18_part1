using System;
using System.Threading;

namespace LB5_18_one
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо горщик і ведмедя
            HoneyPot pot = new HoneyPot();
            Bear bear = new Bear(pot);

            // Запускаємо ведмедя в окремому потоці
            Thread bearThread = new Thread(bear.Start);
            bearThread.Start();

            // Створюємо бджіл і запускаємо їх у окремих потоках
            int numBees = 5;
            for (int i = 1; i <= numBees; i++)
            {
                Bee bee = new Bee(i, pot);
                Thread beeThread = new Thread(bee.Start);
                beeThread.Start();
            }

            // Очікуємо на закінчення роботи усіх потоків
            bearThread.Join();
            Console.WriteLine("Bear thread finished");
            for (int i = 1; i <= numBees; i++)
            {
                string beeThreadName = string.Format("Bee {0} thread", i);
                Thread beeThread = Thread.CurrentThread.Name == beeThreadName ? Thread.CurrentThread : new Thread(() => { });
                beeThread.Join();
                Console.WriteLine(beeThreadName + " finished");
            }

            Console.WriteLine("All threads finished");
        }
    }
}