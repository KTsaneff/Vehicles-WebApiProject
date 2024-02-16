namespace WebApiDemo.Models
{
    public struct MonthYear
    {
        public int Month { get; set; }
        public int Year { get; set; }

        public MonthYear(int month, int year)
        {
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Month}/{Year}";
        }
    }
}
