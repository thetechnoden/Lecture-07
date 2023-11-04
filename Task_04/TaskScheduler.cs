using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    class TaskScheduler<TTask, TPriority>
    {
        private readonly Queue<Tuple<TTask, TPriority>> taskQueue = new Queue<Tuple<TTask, TPriority>>();

        public delegate void TaskExecution(TTask task);

        public void AddTask(TTask task, TPriority priority)
        {
            taskQueue.Enqueue(Tuple.Create(task, priority));
        }

        public void ExecuteNext(TaskExecution executeTask)
        {
            if (taskQueue.Count == 0)
            {
                Console.WriteLine("The task queue is empty.");
                return;
            }

            Tuple<TTask, TPriority> nextTask = taskQueue.Dequeue();
            executeTask(nextTask.Item1);
        }

        public Tuple<TTask, TPriority> GetNextTask()
        {
            if (taskQueue.Count == 0)
            {
                Console.WriteLine("The task queue is empty.");
                return null!;
            }

            return taskQueue.Peek();
        }

        public void ReturnToPool(TTask task, TPriority priority)
        {
            taskQueue.Enqueue(Tuple.Create(task, priority));
        }
    }

}
