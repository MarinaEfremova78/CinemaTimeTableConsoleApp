using System;
namespace CinemaTimeTableConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Film film = new Film("Шурик", 1.50, 10);
            Film film1 = new Film("Чапаев", 2.00, 10);
            RoomStorage rooms = new RoomStorage();
            FilmStorage films = new FilmStorage();
            films.Append(film);
            films.Append(film1);
            while (Film.TotalShowTime > 0)
            {
                foreach (var room in rooms)
                {
                    room.Append(film);
                    room.Append(film1);
                }
            }
        }
    }
}
