// See https://aka.ms/new-console-template for more information
using DB; 
using UI;

string connectionString = File.ReadAllText("./connectionString.txt");


DBRepository repo = new DBRepository(connectionString);

// List<Customer> customer =repo.GetUsername();
// foreach(Customer c in customer )
// {
//     Console.WriteLine(c);
// }
var mainMenu = new mainMenu(repo);
mainMenu.start();

