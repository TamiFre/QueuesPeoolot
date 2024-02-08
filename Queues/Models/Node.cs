using System;

namespace Queues.Models
{
    /* The class Node<T> **/
    public class Node<T>
    {
        private T value;                           // Node value
        private Node<T> next;               // next Node

        /* Constructor  - returns a Node with "value" as value and without successesor Node **/
        public Node(T value)
        {
            this.value = value;
            next = null;
        }

        /* Constructor  - returns a Node with "value" as value and its successesor is "next" **/
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        /* Returns the Node "value" **/
        public T GetValue()
        {
            return value;
        }

        /* Returns the Node "next" Node **/
        public Node<T> GetNext()
        {
            return next;
        }

        /* Return if the current Node Has successor **/
        public bool HasNext()
        {
            return next != null;
        }

        /* Set the value attribute to be "value" **/
        public void SetValue(T value)
        {
            this.value = value;
        }

        /* Set the next attribute to be "next" **/
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

        /* Returns a string that describes  the Node (and its' successesors **/
        public override string ToString()
        {
            if (next == null)
                return value.ToString() + " --> null";
            return value.ToString() + " --> " + next;
        }
    }
}
