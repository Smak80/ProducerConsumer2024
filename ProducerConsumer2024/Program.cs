using ProducerConsumer2024;

Storage data = new();
var producers = new List<Producer> { new(0, data), new(1, data), new(2, data) };
producers.ForEach(p => p.Start());
var consumer = new Consumer(data);
consumer.Start();