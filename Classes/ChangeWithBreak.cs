using System;
using System.Text;
using System.Collections.Generic;

namespace Mac
{
    internal class ChangeWithBreak: Change
    {
        public ChangeWithBreak(TimeSpan from, TimeSpan to, IGetTask task, TimeSpan breakFrom) : base(from, to)
        {
            tasks[from] = new Task(from, breakFrom, task);
            tasks[breakFrom] = new Task(breakFrom, TimeSpan.FromHours(breakFrom.Hours + 1), new FreeTime());
            tasks[TimeSpan.FromHours(breakFrom.Hours + 1)] = new Task(TimeSpan.FromHours(breakFrom.Hours + 1), to, task);
        }
    }
}
