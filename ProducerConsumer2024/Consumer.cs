using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer2024
{
    public class Consumer(Storage commonData)
    {
        public bool IsAlive { get; private set; }
        public void Start()
        {
            if (IsAlive) return;
            IsAlive = true;
            new Thread(_ =>
            {
                while (IsAlive)
                {
                    var lst = commonData.Get();
                    Thread.Sleep(2000);
                    var result = lst.Average();
                    Console.WriteLine("({0}, {1}, {2}) -> {3}", lst[0], lst[1], lst[2], result);
                }
            }).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }
    }
}
