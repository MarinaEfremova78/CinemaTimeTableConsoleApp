using System.Collections;
using System.Collections.Generic;

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
