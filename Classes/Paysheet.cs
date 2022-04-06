using System;

namespace Mac
{
    internal class Paysheet
    {
        public Schedule Scheduler { get; set; }

        public IRate Rate { get; set; }

        public Paysheet(Schedule scheduler, IRate rate)
        {
            Scheduler = scheduler;
            Rate = rate;
        }

        public int GetWorkHours(DateTime from, DateTime to)
        {
            int count = 0;

            while (from < to)
            {
                count += Scheduler.Days[((int)from.DayOfWeek)].GetWorksHours();
                from = from.AddDays(1);
            }

            return count;
        }

        public int GetFreeDays(DateTime from, DateTime to)
        {
            int count = 0;

            while (from < to)
            {
                if (Scheduler.Days[((int)from.DayOfWeek)].IsFreeDay())
                    count++;

                from = from.AddDays(1);
            }

            return count;
        }

        public double GetSalary(DateTime from, DateTime to)
        {
            return GetWorkHours(from, to) * Rate.GetRate();
        }
    }
}
