// See https://aka.ms/new-console-template for more information
using JsonDB;

Console.WriteLine("Hello, World!");

var myDb = new JsonDB.JsonDB("contactdb");

var personDoc = myDb.Document<Person>("person");

Person myPerson = new Person() { Name="Manoj", Phone="1234567890" };

personDoc.Add(myPerson);
