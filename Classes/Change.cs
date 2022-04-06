using System;
using System.Text;
using System.Collections.Generic;

namespace Mac
{
    internal abstract class Change
    {
        public Dictionary<TimeSpan, Task> tasks;
        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }

        public Change(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
            tasks = new Dictionary<TimeSpan, Task>();
        }

        public IGetTask GetFirstTask()
        {
            return tasks[Start].WorkTask;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in tasks)
                sb.AppendLine(s.Value.ToString());

            return sb.ToString();
        }

        public bool IsFreeChange()
        {
            foreach (var task in tasks)
            {
                if (task.Value.WorkTask.GetType().Name != "FreeTime")
                    return false;
            }

            return true;
        }

        public static ChangeWithoutBreak GetFreeChange(TimeSpan start, TimeSpan end)
        {
            return new ChangeWithoutBreak(start, end, new FreeTime());
        }

        public int GetWorkHours()
        {
            int count = 0;
            foreach (var task in tasks)
            {
                if (task.Value.WorkTask.GetType().Name != "FreeTime")
                    count += (task.Value.To - task.Value.From).Hours;
            }

            return count;
        }
    }
}
