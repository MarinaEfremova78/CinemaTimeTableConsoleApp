using System.Collections;
using System.Collections.Generic;

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
