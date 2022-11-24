namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        public class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                this.Element = item;
            }
        }

        private Node head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this.head;
            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = oldHead.Next;
            this.Count--;

            return oldHead.Element;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                this.head = new Node(item);
            }

            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new Node(item);
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}