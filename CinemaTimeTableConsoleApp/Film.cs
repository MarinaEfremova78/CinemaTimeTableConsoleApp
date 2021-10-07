public class Film
{
    public static double TotalShowAmount { get; set; }
    public string Title { get; set; }
    public double Duration { get; set; }
    public int ShowAmount { get; set; }
    private int[] availableRooms;

    public int[] AvailableRooms
    {
        get => availableRooms;
        set
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] < 1 || value[i] > 6)
                {
                    TotalShowAmount = 0;
                    throw new RoomNumberInvalidException("Номер зала должен быть от 1 до 6");
                }
            }
            availableRooms = value;
        }
    }

    public Film(string title, double duration, int showAmount, int[] availableRooms)
    {
        Title = title;
        Duration = duration;
        ShowAmount = showAmount;
        TotalShowAmount += ShowAmount;
        AvailableRooms = availableRooms;
    }
    public override string ToString()
    {
        return string.Format("{0, -30}   |   {1, -30}", Title, Duration);
    }
}
