using System.Collections;
using System.Collections.Generic;

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
