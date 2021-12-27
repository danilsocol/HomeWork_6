using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test5
{
    class MyDictionary<T>
    {
        Cell<int, T>[] arr;
        public readonly uint size;
        int j;
        public int maxJ = 0;
        public MyDictionary(uint size)
        {
            arr = new Cell<int, T>[size];
            this.size = size;
        }

        public void Add(T value)
        {
            j = 1;
            int key = GetHashCode(value);
            while (true)
            {
                if (key > size)
                    key -= 10000;

                if (maxJ < j)
                    maxJ = j;

                try
                {
                    if (arr[key] != null)
                        throw new Exception("This key is already contained in the dictionary");

                    arr[key] = new Cell<int, T>(key, value);
                    Console.WriteLine(key);
                    return;
                }
                catch
                {
                    key = FindVoidCell(key);
                    j++;
                }
            }
           
        }
        
        public int FindVoidCell(int numCell)
        {
            Console.WriteLine("изменение ячейки");

            Console.WriteLine($"{numCell} + {(int)Math.Pow(j, 2)} = {numCell + (int)Math.Pow(j, 2)}");
            return numCell += (int)Math.Pow(j, 2);
        }

        public void Remove(int key)
        {
            Cell<int, T> cell = Search(key);
            cell = null;
        }

        public Cell<int,T> Search(int key)
        {
            foreach (var item in arr)
            {
                if (item.key.Equals(key))
                    return item;
            }
            throw new IndexOutOfRangeException("Incorrect Key");
        }

        private  int GetHashCode(T key)
        {
            double value = key is int key2 ? 0.59756416 * key2 : 0.59756416 * key.ToString()[0];
            var trunc = Math.Truncate(value);
            var hash = (int)(size * (value - trunc));
            return hash;
        }
    }
        internal class Cell<TKey, TValue>
        {
            internal TValue value;
            internal TKey key;
            internal Cell(TKey key, TValue value)
            {
                this.value = value;
                this.key = key;
            }
        }
}

