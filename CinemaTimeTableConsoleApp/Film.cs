public class Film
{
    public static double TotalShowAmount { get; set; }
    public string Title { get; set; }
    public double Duration { get; set; }
    public int DailyAmount { get; set; }

    public Film(string title, double duration, int dailyAmount)
    {
        Title = title;
        Duration = duration;
        DailyAmount = dailyAmount;
        TotalShowAmount += DailyAmount;
    }
    public override string ToString()
    {
        return $"{Title} {Duration}";
    }
}
