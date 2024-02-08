using System;

namespace Queues.Models
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;


        public Queue()
        {
            first = null;
            last = null;
        }

        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (first == null)
                first = temp;
            else
                last.SetNext(temp);
            last = temp;
        }

        public T Remove()
        {
            T x = first.GetValue();
            first = first.GetNext();
            if (first == null)
                last = null;
            return x;
        }

        public T Head()
        {
            return first.GetValue();
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public override string ToString()
        {
            Node<T> current = first;
            string temp = "";
            while (current != null)
            {
                temp += current.GetValue() + " --> ";
                current = current.GetNext();
            }
            return "head -> " + temp + "end";
        }
    }
}
