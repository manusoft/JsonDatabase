using System.Text.Json;

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

        var _objectPath = $"{_documentInfo.Object}.json";//.jdoc";

        if (File.Exists(_objectPath))
        {
            string jsonData = File.ReadAllText(_objectPath);
            data = JsonSerializer.Deserialize<List<T>>(jsonData);
        }
        else
        {
            data = new List<T>();
        }

        // Check if the item has an Id property, and if it's null, initialize it.
        var idProperty = item.GetType().GetProperty("Id");
        if (idProperty != null && idProperty.GetValue(item) == null)
        {
            var idValue = new JsonId();
            idProperty.SetValue(item, idValue);
        }

        data.Add(item);

        string updatedData = JsonSerializer.Serialize(data);
        File.WriteAllText(_objectPath, updatedData);
    }

    public List<T> GetAll()
    {
        var _objectPath = $"{_documentInfo.Object}.json";

        if (File.Exists(_objectPath))
        {
            string jsonData = File.ReadAllText(_objectPath);
            return JsonSerializer.Deserialize<List<T>>(jsonData);
        }
        else
        {
            return new List<T>();
        }
    }

    public void Update(T item)
    {
        var _objectPath = $"{_documentInfo.Object}.json";

        if (File.Exists(_objectPath))
        {
            List<T> data = GetAll();

            // Find and update the item based on some identifier (e.g., Id)
            // You can define your own logic for updating items in the list.

            // For example, assuming there's an 'Id' property in T:
            var existingItem = data.Find(i => GetItemId(i) == GetItemId(item));

            if (existingItem != null)
            {
                // Replace the existing item with the updated item
                int index = data.IndexOf(existingItem);
                data[index] = item;

                string updatedData = JsonSerializer.Serialize(data);
                File.WriteAllText(_objectPath, updatedData);
            }
        }
    }

    public void Delete(T item)
    {
        var _objectPath = $"{_documentInfo.Object}.json";

        if (File.Exists(_objectPath))
        {
            List<T> data = GetAll();

            // Find and delete the item based on some identifier (e.g., Id)
            // You can define your own logic for deleting items from the list.

            // For example, assuming there's an 'Id' property in T:
            var itemToDelete = data.Find(i => GetItemId(i) == GetItemId(item));

            if (itemToDelete != null)
            {
                data.Remove(itemToDelete);

                string updatedData = JsonSerializer.Serialize(data);
                File.WriteAllText(_objectPath, updatedData);
            }
        }
    }

    // You can define a method to get the identifier from the item
    // For example, if 'Id' is the identifier:
    private string GetItemId(T item)
    {
        var property = item.GetType().GetProperty("Id");
        if (property != null)
        {
            return property.GetValue(item)?.ToString();
        }
        return null;
    }

}
