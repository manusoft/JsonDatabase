using System.Text.Json.Serialization;

namespace JsonDB;

public class JsonId
{
    public string ObjectId { get; set; }

    public JsonId()
    {
        ObjectId = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}

