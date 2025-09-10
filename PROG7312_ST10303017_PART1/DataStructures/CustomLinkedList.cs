using System.Collections;
using System.Collections.Generic;

namespace PROG7312_ST10303017_PART1.DataStructures
{
    // A simple custom linked list implementation
    public class CustomLinkedList<T> : IEnumerable<T>
    {

        // Node class representing each element in the linked list
        private class Node<TNode>
        {
            public TNode Data { get; set; }
            public Node<TNode> Next { get; set; }

            public Node(TNode data)
            {
                this.Data = data;
                this.Next = null;
            }
        }

        // Head and tail references for the linked list
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { get; private set; }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            Count++;
        }

        // Enumerator to allow iteration over the linked list
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}