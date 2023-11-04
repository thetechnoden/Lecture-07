using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    public class Repository<T>
    {
        private List<T> data = new List<T>();

        public void Add(T item)
        {
            data.Add(item);
        }

        public List<T> Find(Criteria<T> criteria)
        {
            List<T> result = new List<T>();

            foreach (T item in data)
            {
                if (criteria(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

    public delegate bool Criteria<T>(T item);
}
