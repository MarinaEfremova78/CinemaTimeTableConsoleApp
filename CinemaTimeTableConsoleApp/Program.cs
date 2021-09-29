using System;
using System.Collections.Generic;
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

public class Room
{
    public int Number { get; set; }
    public double TotalTime { get; private set; }
    public List<Film> Shows = new List<Film>();

    public Room(int number)
    {
        Number = number;
        TotalTime = 14;
    }

    public void Append(Film film)
    {
        if (film.DailyAmount > 0)
        {
            Shows.Add(film);
            film.DailyAmount--;
            double middleBreak = 0.15;
            TotalTime = TotalTime - film.Duration - middleBreak;
            Film.TotalShowTime--;
        }
    }

    public override string ToString()
    {
        string shows = "";
        foreach (var show in Shows)
        {
            shows += show + " ";
        }
        return $"{Number} {shows} {TotalTime}";
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
