using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer2024
{
    public class Producer(
        int id,
        Storage commonData)
    {
        private Random rnd = new Random();
        private bool IsAlive { get; set; }

        public void Start()
        {
            if (IsAlive) return;
            IsAlive = true;
            new Thread(_ =>
            {
                while (IsAlive)
                {
                    // Эмуляция выполнения продолжительной работы:
                    Thread.Sleep(rnd.Next(5000, 8001));
                    // Получение результата:
                    var result = rnd.Next(1000, 2001);
                    Console.WriteLine($"{id} produced: {result}");
                    commonData.Put(id, result);
                }
            }).Start();
        }

        public void Stop()
        {
            IsAlive = false;
        }
    }
}
