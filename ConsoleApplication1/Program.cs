using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  FirstDuplicateOptimizex(new int[] { 2, 4, 3, 5, 1 });

            //MyArrayList<int> my = new MyArrayList<int>();

            //my.Add(3);
            //my.Add(4);
            //my.Add(5);
            //int x = my.Get(0);


            //MyStringBuilder sb = new MyStringBuilder();

            //sb.Append("Hello");

            //string sbString = sb.ToString();


            IsUniqByHashtable("aabcd");

            CheckPermutation2("dfd", "god");

            PalindromePermutation("abcab");

        }

        private static bool CheckPermutation2(string x, string y)
        {
            char[] letters = new char[128];

            for (int i = 0; i < x.Length; i++)
            {
                int charValue = x[i];
                letters[charValue]++;
            }

            for (int i = 0; i < y.Length; i++)
            {
                int charValue = y[i];

                letters[charValue]--;

                if (letters[charValue] < 0)
                    return false;
            }

            return true;

        }

        private static bool CheckPermutation(string x, string y)
        {
            if (x.Length != y.Length) return false;

            char[] sortedX = x.ToCharArray();
            Array.Sort(sortedX);

            char[] sortedy = y.ToCharArray();
            Array.Sort(sortedy);

            var res = (new string(sortedX) == new string(sortedy));

            return res;
        }

        static int FirstDuplicate(int[] a)
        {
            int smallestIndex = a.Length;

            for (int i = 0; i < a.Length; i++)
            {
                for (int x = i + 1; x < a.Length; x++)
                {
                    if (a[i] == a[x])
                    {
                        if (x < smallestIndex)
                            smallestIndex = x;
                    }
                }
            }

            if (smallestIndex < a.Length)
                return a[smallestIndex];

            return -1;
        }

        static int FirstDuplicateOptimizex(int[] a)
        {
            if (a == null || a.Length == 0)
                return -1;
            int currentIndex;

            for (int i = 0; i < a.Length; i++)
            {
                currentIndex = Math.Abs(a[i]) - 1;


                if (a[currentIndex] < 0)
                    return currentIndex + 1;
                else
                    a[currentIndex] *= -1;
            }

            return -1;
        }

        static bool IsUniq(string x)
        {
            bool[] letters = new bool[128];

            for (int i = 0; i < x.Length; i++)
            {
                int cha = x[i];
                if (letters[cha])
                {
                    return false;
                }

                letters[cha] = true;
            }

            return true;
        }

        static bool IsUniqByHashtable(string x)
        {
            Hashtable hash = new Hashtable();


            for (int i = 0; i < x.Length; i++)
            {
                int cha = x[i];
                if (hash.ContainsKey(cha))
                {
                    return false;
                }

                hash[cha] = cha;
            }

            return true;
        }

        static bool PalindromePermutation(string str1)
        {
            Hashtable counts = new Hashtable();
            for (int i = 0; i < str1.Length; i++)
            {
                int key = str1[i];

                if (counts.ContainsKey(key))
                {
                    counts[key] = (int) counts[key] + 1;
                }
                else
                {
                    counts[key] = 1;
                }
            }



            return true;
        }
    }

    class MyArrayList<T>
    {
        private const int DEFAULT_CAPACITY = 2;

        private T[] _items;

        private int _size = 0;

        public MyArrayList()
        {
            _items = new T[DEFAULT_CAPACITY];
        }
        public void Add(T item)
        {
            if (_items.Length == _size)
            {
                IncreaseCapacity();
            }

            _items[_size++] = item;
        }

        private void IncreaseCapacity()
        {
            int newSize = _items.Length * 2;

            T[] newArray = new T[newSize];
            Array.Copy(_items, newArray, _items.Length);

            _items = newArray;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _items.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return _items[index];
        }


    }

    class MyStringBuilder
    {
        public const int DEFAULT_CAPACITY = 2;

        private int _capacity;

        private char[] _items;

        private int _size = 0;

        public MyStringBuilder(int capacity)
        {
            _capacity = capacity;
            _items = new char[_capacity];
        }

        public MyStringBuilder() : this(DEFAULT_CAPACITY)
        {

        }
        public void Append(string str)
        {

            IncreaseCapacity(str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                _items[_size++] = str[i];
            }

        }

        public override string ToString()
        {
            return new string(_items);
        }

        private void IncreaseCapacity(int additionalLength)
        {
            while (_size + additionalLength > _capacity)
            {


                _capacity = _items.Length * 2;

                char[] newArray = new char[_capacity];

                Array.Copy(_items, newArray, _items.Length);

                _items = newArray;
            }
        }
    }
}
