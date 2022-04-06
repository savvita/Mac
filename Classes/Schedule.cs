using System;

namespace Mac
{
    internal class Schedule
    {
        private const int dayAWeek = 7;

        public DayTask[] Days { get; private set; }

        public int Breaks { get; private set; }

        private readonly TimeSpan startFirstChange = TimeSpan.FromHours(7);
        private readonly TimeSpan endFirstChange = TimeSpan.FromHours(12);
        private readonly TimeSpan startSecondChange = TimeSpan.FromHours(12);
        private readonly TimeSpan endSecondChange = TimeSpan.FromHours(21);

        public Schedule()
        {
            Days = new DayTask[dayAWeek];

            for (int i = 0; i < dayAWeek; i++)
            {
                Days[i] = new DayTask(Change.GetFreeChange(startFirstChange, endFirstChange), Change.GetFreeChange(startSecondChange, endSecondChange));
            }

            Breaks = 0;
        }

        public void SetDayTask(DayOfWeek day, IGetTask firstChange, IGetTask secondChange)
        {
            this[day].FirstChange.tasks[startFirstChange] = new Task(startFirstChange, endFirstChange, firstChange);
            this[day].SecondChange.tasks[startSecondChange] = new Task(startSecondChange, endSecondChange, secondChange);
        }

        public void AddBreak(DayOfWeek day, TimeSpan from)
        {
            if(from > startFirstChange && from < endFirstChange && this[day].FirstChange.tasks[startFirstChange].WorkTask.GetType().Name != "FreeTime")
            {
                this[day].FirstChange = new ChangeWithBreak(startFirstChange, endFirstChange, this[day].FirstChange.GetFirstTask(), from);
                Breaks++;
            }
            else if (from > startSecondChange && from < endSecondChange && this[day].SecondChange.tasks[startSecondChange].WorkTask.GetType().Name != "FreeTime")
            {
                this[day].SecondChange = new ChangeWithBreak(startSecondChange, endSecondChange, this[day].SecondChange.GetFirstTask(), from);
                Breaks++;
            }
        }

        public DayTask GetDayTask(DayOfWeek day)
        {
            return Days[((int)day)];
        }

        public DayTask this[DayOfWeek day]
        {
            get
            {
                return Days[((int)day)];
            }
            set
            {
                Days[((int)day)] = value;
            }
        }

        public DayTask GetTodayTask()
        {
            return GetDayTask(DateTime.Now.DayOfWeek);
        }

        public DayTask GetTomorrowTask()
        {
            return GetDayTask(DateTime.Now.AddDays(1).DayOfWeek);
        }

        public string GetTodayTaskString()
        {
            return $"Today:\n{GetTodayTask()}";
        }

        public string GetTomorrowTaskString()
        {
            return $"{DateTime.Now.AddDays(1).DayOfWeek}:\n{GetTomorrowTask()}";
        }
    }
}
