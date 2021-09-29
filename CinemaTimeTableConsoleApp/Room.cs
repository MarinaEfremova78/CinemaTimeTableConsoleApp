using System.Collections.Generic;

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
