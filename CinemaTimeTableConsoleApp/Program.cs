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
                Console.WriteLine("Введите через пробел залы, в которых будет идти фильм");
                var availableRooms = GetRoomNumber();
                try
                {
                    Film film = new Film(title, duration, showAmount, availableRooms);
                    films.Append(film);
                }
                catch (RoomNumberInvalidException e)
                {
                    Console.WriteLine("Фильм не добавлен!");
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Добавить ещё один фильм? Нажмите Y или N");
                var userAnswer = GetUserAnswer();
                Console.ReadKey();
                if (!userAnswer)
                {
                    break;
                }
            }

            while (Film.TotalShowAmount > 0)
            {
                foreach (var room in rooms)
                {
                    foreach (var film in films)
                    {
                        for (int i = 0; i < film.AvailableRooms.Length; i++)
                        {
                            if (film.AvailableRooms[i] == room.Number)
                            {
                                room.Append(film);
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0,-30}   |   {1,-30}", "Название фильма", "Длительность");
            for(int i = 0; i <=60; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            foreach (var room in rooms)
            {
                Console.WriteLine("Зал № " + room.Number);
                var allShows = room.GetAllFilmsInRoom();
                foreach(var show in allShows)
                {
                    Console.WriteLine(show);
                }
            }
        }

        static bool GetUserAnswer()
        {
            var userAnswer = Console.ReadKey();
            if (userAnswer.Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }

        static int[] GetRoomNumber()
        {
            var userRoom = Console.ReadLine().Split();
            var rooms = new int[userRoom.Length];
            for (int i = 0; i < userRoom.Length; i++)
            {
                rooms[i] = Convert.ToInt32(userRoom[i]);
            }
            return rooms;
        }
    }
}
