using System;

using Queues.Models;
namespace Queues
{
    internal class Program
    {

     
        static void Main(string[] args)
        {
            Queue<int> q1= new Queue<int>();    
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(4);
            q1.Insert(5);
            Console.WriteLine(q1);
            Console.WriteLine(QueueHelper.Count(q1));
            Console.WriteLine(QueueHelper.IsAsc(q1));
            Console.WriteLine(QueueHelper.MinVal(q1));
        }
    }
}