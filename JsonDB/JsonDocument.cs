using System.Text.Json;
using System.Xml;

namespace JsonDB;

public class JsonDocument<T> : BaseModel
{
    private DocumentInfo _documentInfo;
    private string _documentName;

    public JsonDocument(DocumentInfo documentInfo, string documentName)
    {
        _documentInfo = documentInfo;
        _documentName = documentName;
    }

    public void Add(T item)
    {
        List<T> data;

        if (File.Exists(_documentInfo.FilePath))
        {
            string jsonData = File.ReadAllText(_documentInfo.FilePath);
            data = JsonSerializer.Deserialize<List<T>>(jsonData);
        }
        else
        {
            data = new List<T>();
        }

        data.Add(item);

        string updatedData = JsonSerializer.Serialize(data);
        File.WriteAllText(_documentInfo.FilePath, updatedData);
    }
}
