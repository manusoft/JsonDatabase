//// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

var myDb = new JsonDB.JsonDB("contactdb");

var personDoc = myDb.Document<Person>("person");

Person myPerson1 = new Person { Name = "Binojbabu", Phone = "1234567890" };
Person myPerson2 = new Person { Name = "John Doe", Phone = "9876543210" };

Console.WriteLine("CREATE-------------------------------------");

personDoc.Add(myPerson1);
personDoc.Add(myPerson2);

// Get all persons
List<Person> allPersons = personDoc.GetAll();
foreach (var person in allPersons)
{

    Console.WriteLine($"Name: {person.Name}, Phone: {person.Phone}");
}

// Update a person
Console.WriteLine("UPDATE-------------------------------------");

myPerson1.Phone = "5555555555";
personDoc.Update(myPerson1);

// Get all persons after update
allPersons = personDoc.GetAll();
foreach (var person in allPersons)
{
    Console.WriteLine($"Name: {person.Name}, Phone: {person.Phone}");
}

// Delete a person
Console.WriteLine("DELETE-------------------------------------");

personDoc.Delete(myPerson2);

// Get all persons after delete
allPersons = personDoc.GetAll();
foreach (var person in allPersons)
{
    Console.WriteLine($"Name: {person.Name}, Phone: {person.Phone}");
}

