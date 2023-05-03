using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB5_18_one
{
    internal class HoneyPot
    {
        private const int MaxCapacity = 5;
        private readonly Queue<int> _portions = new Queue<int>();

        public void AddPortion(int id)
        {
            Console.WriteLine("Bee {0} added a portion of honey", id);
            _portions.Enqueue(id);
        }

        public void GetPortion()
        {
            if (_portions.Count == 0)
            {
                Console.WriteLine("No honey in the pot, the bear is waiting...");
            }
            else
            {
                int portion = _portions.Dequeue();
                Console.WriteLine("Bear got a portion of honey from bee {0}", portion);
            }
        }

        public void Refill()
        {
            Console.WriteLine("Bear refilled the pot with a portion of honey");
            _portions.Enqueue(-1); // Добавление фиктивной порции меда для продолжения работы пчел
        }

        public bool IsFull()
        {
            return _portions.Count >= MaxCapacity;
        }

        public void Empty()
        {
            _portions.Clear();
            Console.WriteLine("Honey pot is empty");
        }

        public void WakeUpBear()
        {
            Console.WriteLine("Wake up, bear!");
        }
    }

}

