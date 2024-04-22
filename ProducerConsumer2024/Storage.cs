using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer2024
{
    public class Storage
    {
        private List<int> _data = new (3);
        public Storage()
        {
            _data.Add(-1);
            _data.Add(-1);
            _data.Add(-1);
        }

        public void Put(int index, int value)
        {
            lock (_data)
            {
                _data[index] = value;
                Monitor.PulseAll(_data);
            }
        }

        public List<int> Get()
        {
            List<int> res;
            lock (_data)
            {
                while (_data.Contains(-1))
                {
                    Monitor.Wait(_data);
                }
                res = _data.ToList();
                _data[0] = _data[1] = _data[2] = -1;
            }
            return res;
        }
    }
}
