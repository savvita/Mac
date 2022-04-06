using System;

namespace Mac
{
    internal class Task
    {
        public IGetTask WorkTask { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }

        public Task(TimeSpan from, TimeSpan to, IGetTask task)
        {
            From = from;
            To = to;
            WorkTask = task;
        }

        public override string ToString()
        {
            return String.Format("{0:d2}:00 - {1}:00 - {2}", From.Hours, To.Hours, WorkTask.GetTask());
        }
    }
}
