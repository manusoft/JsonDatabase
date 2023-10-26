using System.Text.Json;

namespace JsonDB;

public class JsonDB
{
    private string _databaseFile;
    private List<DocumentInfo> _documents;

    public JsonDB(string databaseFile)
    {
        _databaseFile = $"{databaseFile}.jdb";
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        if (File.Exists(_databaseFile))
        {
            string jsonData = File.ReadAllText(_databaseFile);
            _documents = JsonSerializer.Deserialize<List<DocumentInfo>>(jsonData);
        }
        else
        {
            _documents = new List<DocumentInfo>();
            SaveChanges();
        }
    }

    public JsonDocument<T> Document<T>(string documentName)
    {
        var existingDoc = _documents.FirstOrDefault(doc => doc.Name == documentName);
        if (existingDoc != null)
        {
            return new JsonDocument<T>(existingDoc, documentName);
        }
        else
        {
            var newDocInfo = new DocumentInfo
            {
                Id = Guid.NewGuid().ToString(),
                Name = documentName,
                FilePath = $"{documentName}.jdoc"
            };
            _documents.Add(newDocInfo);
            SaveChanges();
            return new JsonDocument<T>(newDocInfo, documentName);
        }
    }

    public void SaveChanges()
    {
        string jsonData = JsonSerializer.Serialize(_documents);
        File.WriteAllText(_databaseFile, jsonData);
    }
}

public class DocumentInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string FilePath { get; set; }
}
