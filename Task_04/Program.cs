using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler<string, int> taskScheduler = new TaskScheduler<string, int>();
            taskScheduler.AddTask("Task 1", 3);
            taskScheduler.AddTask("Task 2", 2);
            taskScheduler.AddTask("Task 3", 1);

            Console.WriteLine("I perform tasks with the highest priority:");
            taskScheduler.ExecuteNext(task => Console.WriteLine(task));

            Console.WriteLine("The next task in the queue:");
            var nextTask = taskScheduler.GetNextTask();
            Console.WriteLine(nextTask != null ? nextTask.Item1 : "The queue is empty.");

            Console.WriteLine("I return the task back to the queue:");
            taskScheduler.ReturnToPool("Task 4", 4);

            Console.WriteLine("The next task in the queue after returning:");
            nextTask = taskScheduler.GetNextTask();
            Console.WriteLine(nextTask != null ? nextTask.Item1 : "The queue is empty.");
        }
    }
}