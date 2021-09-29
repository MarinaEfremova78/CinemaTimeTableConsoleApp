using System;
public class Film
{
    public static double TotalShowTime { get; set; }
    public string Title { get; set; }
    public double Duration { get; set; }
    public int DailyAmount { get; set; }

    public Film(string title, double duration, int dailyAmount)
    {
        Title = title;
        Duration = duration;
        DailyAmount = dailyAmount;
        TotalShowTime += DailyAmount;
    }
    public override string ToString()
    {
        return $"{Title} {Duration}";
    }
}

namespace CinemaTimeTableConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
