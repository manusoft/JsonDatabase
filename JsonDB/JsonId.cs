namespace JsonDB;

public class JsonId
{
    public string _Id { get; set; }

    public JsonId()
    {
        _Id = Guid.NewGuid().ToString(); // Generate a new unique ID.
    }

    public JsonId(string value)
    {
        _Id = value;
    }

    public override string ToString()
    {
        return _Id;
    }
}

