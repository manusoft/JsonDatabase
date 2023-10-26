namespace JsonDB;

public class BaseModel
{
    [JsonId]
    public JsonId Id { get; set; }

    public void InitializeId()
    {
        Id = new JsonId();
    }
}
