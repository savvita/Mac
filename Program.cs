using System;

namespace Mac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Schedule myShedule = new Schedule();
            myShedule.SetDayTask(DayOfWeek.Monday, new Fries(), new FreeTime());
            myShedule.SetDayTask(DayOfWeek.Tuesday, new Hamburger(), new IceCream());
            myShedule.SetDayTask(DayOfWeek.Wednesday, new Fries(), new Hamburger());
            myShedule.SetDayTask(DayOfWeek.Thursday, new Hamburger(), new IceCream());
            myShedule.SetDayTask(DayOfWeek.Friday, new FreeTime(), new Fries());
            myShedule.SetDayTask(DayOfWeek.Saturday, new FreeTime(), new FreeTime());
            myShedule.SetDayTask(DayOfWeek.Sunday, new FreeTime(), new FreeTime());


            myShedule.AddBreak(DayOfWeek.Tuesday, TimeSpan.FromHours(13));

            Console.WriteLine(myShedule.GetTodayTaskString());

            Console.WriteLine("==============================");
            Console.WriteLine(myShedule.GetTomorrowTaskString());

            Console.WriteLine("==============================");
            Paysheet pays = new Paysheet(myShedule, new Junior());

            DateTime start = new DateTime(2022, 4, 1);
            DateTime end = DateTime.Now;
            Console.WriteLine($"Work hours: {pays.GetWorkHours(start, end)}");
            Console.WriteLine($"Free Days: {pays.GetFreeDays(start, end)}");
            Console.WriteLine($"Breaks: {pays.Scheduler.Breaks}");
            Console.WriteLine($"Salary: {pays.GetSalary(start, end)}");
        }
    }
}
