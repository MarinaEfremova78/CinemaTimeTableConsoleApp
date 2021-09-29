using System;
namespace CinemaTimeTableConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomStorage rooms = new RoomStorage();
            FilmStorage films = new FilmStorage();
            while (true)
            {
                Console.WriteLine("Введите название фильма:");
                var title = Console.ReadLine();
                Console.WriteLine("Введите длительность фильма:");
                var duration = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите количество сеансов:");
                var showAmount = Convert.ToInt32(Console.ReadLine());
                Film film = new Film(title, duration, showAmount);
                films.Append(film);
                Console.WriteLine("Добавить ещё один фильм? Нажмите Y или N");
                var userAnswer = GetUserAnswer();
                Console.ReadKey();
                if(!userAnswer)
                {
                    break;
                }
            }

            while (Film.TotalShowAmount > 0)
            {
                foreach (var room in rooms)
                {
                    foreach(var film in films)
                    {
                        room.Append(film);
                    }
                }
            }

            foreach (var room in rooms)
            {
                Console.WriteLine(room);
            }
        }

        static bool GetUserAnswer()
        {
            var userAnswer = Console.ReadKey();
            if(userAnswer.Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }
    }
}
