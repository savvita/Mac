namespace Mac
{
    internal class DayTask
    {
        public Change FirstChange { get; set; }
        public Change SecondChange { get; set; }

        public DayTask(Change firstChange, Change secondChange)
        {
            FirstChange = firstChange;
            SecondChange = secondChange;
        }

        public override string ToString()
        {
            return $"{FirstChange}{SecondChange}";
        }

        public int GetWorksHours()
        {
            return FirstChange.GetWorkHours() + SecondChange.GetWorkHours();
        }

        public bool IsFreeDay()
        {
            return FirstChange.IsFreeChange() && SecondChange.IsFreeChange();
        }
    }
}
