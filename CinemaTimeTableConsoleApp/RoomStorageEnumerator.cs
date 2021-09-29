using System.Collections;
using System.Collections.Generic;

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
