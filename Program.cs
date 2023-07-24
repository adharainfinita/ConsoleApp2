Console.WriteLine("Write your first name: \t");
string firstName = Console.ReadLine()!;
Console.WriteLine("Hi, " +  firstName + "! \n♥♥♥♥♥");

DateTime time = DateTime.Now;
Console.WriteLine("\nInicializated on " + time);

Console.WriteLine("\nNow, What's your last Name?: \t");
string lastName  = Console.ReadLine()!;
Console.WriteLine("How old are you?: \t");
string age = Console.ReadLine()!;
Console.Write("Do you know programming?"); 
Console.WriteLine("Type Yes/No");
string develop = Console.ReadLine()!;

Console.WriteLine($"\nYour information:");
Console.WriteLine($"\tFirst Name: {firstName}\n\tLast Name: {lastName}\n\tAge: {age}\n\tDevelop: {(develop == "Yes" || develop == "yes")}");


