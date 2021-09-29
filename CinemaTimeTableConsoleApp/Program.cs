using System;
using System.Collections;
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

public class RoomStorage : IEnumerable<Room>
{
    private readonly List<Room> rooms = new List<Room>()
{
new Room(1),
new Room(2),
new Room(3),
new Room(4),
new Room(5),
new Room(6),
};

    public void Append(Room room)
    {
        rooms.Add(room);
    }

    IEnumerator<Room> IEnumerable<Room>.GetEnumerator()
    {
        return new RoomStorageEnumerator(rooms);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new RoomStorageEnumerator(rooms);
    }
}

public class RoomStorageEnumerator : IEnumerator<Room>
{
    private readonly List<Room> rooms;
    private int currentIndex = -1;

    public RoomStorageEnumerator(List<Room> rooms)
    {
        this.rooms = rooms;
    }

    public Room Current => rooms[currentIndex];
    object IEnumerator.Current => rooms[currentIndex];

    public bool MoveNext()
    {
        currentIndex++;
        if (currentIndex >= rooms.Count)
        {
            return false;
        }
        return true;
    }

    public void Reset()
    {
        currentIndex = -1;
    }
    public void Dispose()
    { }
}

public class FilmStorage : IEnumerable<Film>
{
    private readonly List<Film> films = new List<Film>();


    public void Append(Film film)
    {
        films.Add(film);
    }

    IEnumerator<Film> IEnumerable<Film>.GetEnumerator()
    {
        return new FilmStorageEnumerator(films);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new FilmStorageEnumerator(films);
    }
}

public class FilmStorageEnumerator : IEnumerator<Film>
{
    private readonly List<Film> films;
    private int currentIndex = -1;

    public FilmStorageEnumerator(List<Film> films)
    {
        this.films = films;
    }

    public Film Current => films[currentIndex];
    object IEnumerator.Current => films[currentIndex];

    public bool MoveNext()
    {
        currentIndex++;
        if (currentIndex >= films.Count)
        {
            return false;
        }
        return true;
    }

    public void Reset()
    {
        currentIndex = -1;
    }

    public void Dispose()
    { }
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
