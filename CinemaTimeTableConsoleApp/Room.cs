using System.Collections.Generic;

public class Room
{
    private int number;
    public double TotalTime { get; private set; }
    public List<Film> Shows = new List<Film>();

    public int Number
    {
        get => number;
        set
        {
            if(value < 0 || value > 6)
            {
                throw new RoomNumberInvalidException("Номер зала должен быть от 1 до 6!");
            }
            number = value;
        }
    }

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
            Film.TotalShowAmount--;
        }
    }

    public override string ToString()
    {
        string shows = "";
        foreach (var show in Shows)
        {
            shows += show + " ";
        }
        return $"{Number} {shows}";
    }
}
