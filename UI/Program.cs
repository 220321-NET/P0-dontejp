// See https://aka.ms/new-console-template for more information
using BL;
using DB; 
using UI;

string connectionString = File.ReadAllText("./connectionString.txt");


DBRepository repo = new DBRepository(connectionString);

// List<Customer> customer =repo.GetUsername();
// foreach(Customer c in customer )
// {
//     Console.WriteLine(c);
// }
IP0BL bl = new P0BL(repo);

var mainMenu = new mainMenu(bl);
mainMenu.start();

