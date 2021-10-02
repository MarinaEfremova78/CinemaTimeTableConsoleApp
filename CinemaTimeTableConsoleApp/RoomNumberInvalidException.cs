using System;
using System.Runtime.Serialization;

[Serializable]
internal class RoomNumberInvalidException : Exception
{
    public RoomNumberInvalidException()
    {
    }

    public RoomNumberInvalidException(string message) : base(message)
    {
    }

    public RoomNumberInvalidException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected RoomNumberInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}