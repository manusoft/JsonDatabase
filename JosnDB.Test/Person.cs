// See https://aka.ms/new-console-template for more information
using JsonDB;

public class Person
{
    public JsonId Id { get; set; } = new JsonId();
    public string Name { get; set; }
    public string Phone { get; set; }

}