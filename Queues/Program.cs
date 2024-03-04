using System;
using System.ComponentModel;
using Queues.Models;
namespace Queues
{
    public class Program
    {
       


        static void Main(string[] args)
        {
            Queue<int> q1= new Queue<int>();    
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(4);
            q1.Insert(5);


            Queue<int> q2 = new Queue<int>();
            q2.Insert(4);
            q2.Insert(3);
            q2.Insert(5);
            q2.Insert(6);
            //Console.WriteLine(q1);
            //Console.WriteLine(QueueHelper.Count(q1));
            //Console.WriteLine(QueueHelper.IsAsc(q1));
            //Console.WriteLine(QueueHelper.MinVal(q1));
            QueueHelper.InsertToMiddle(q1,5);
            Console.WriteLine(q1);
            QueueHelper.MergeTorim(q1,q2);

        }
    }
}