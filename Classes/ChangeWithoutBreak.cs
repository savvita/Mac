using System;
using System.Collections.Generic;

namespace Mac
{
    internal class ChangeWithoutBreak : Change
    {
        public ChangeWithoutBreak(TimeSpan from, TimeSpan to, IGetTask task) : base(from, to)
        {
            tasks[from] = new Task(from, to, task);
        }
    }
}
