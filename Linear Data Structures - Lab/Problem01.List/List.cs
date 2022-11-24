namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List() : this(DEFAULT_CAPACITY) { }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.items[index];
            }
            set
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();

            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
           if (this.IndexOf(item) != -1)
            {
                return true;
            }
           else
            {
                return false;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            Grow();

            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }
          
            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.Count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == this.items.Length)
            {
                T[] itemsCopy = new T[this.items.Length * 2];

               Array.Copy(this.items, itemsCopy, this.Count);

                this.items = itemsCopy;
            }
        }

        private void ValidateIndex (int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid Index");
            }
        }
    }
}