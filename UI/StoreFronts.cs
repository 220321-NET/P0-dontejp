using DB;
using BL;
using Models;

namespace UI;

public class StoreFronts: mainMenu
{

public StoreFronts(IP0BL bl): base(bl)
{}
    public void Start(Customer currentCustomer)
    {
        Console.WriteLine("Welcome to the Ninja hub "+ currentCustomer.Username + "             Balance: $" + currentCustomer.Balance);
        WelcomePrompt();
    }

//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            All Methods           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--



    private void WelcomePrompt()
    {
    reset:
        Console.WriteLine("{1} Hidden Leaf Village");
        Console.WriteLine("{2} Hidden Cloud Village");
        Console.WriteLine("{3} Hidden Sand Village");
        Console.WriteLine("{4} Hidden Mist Village");
        Console.WriteLine("{5} Hidden Stone Vilage");
        Console.WriteLine("\nEnter a number!\n");
    reset1:
        Console.WriteLine("Which store would you like to enter?");
        string? a =Console.ReadLine();
        if(a != null)
        {
            switch(a)
            {
            case "1":
                    leafVillage leaf = new leafVillage(_bl);
                    leaf.Start();
                goto reset;
            case "2":
                    cloudVillage cloud = new cloudVillage(_bl);
                    cloud.Start();
                goto reset;
            case "3":
                    sandVillage sand = new sandVillage(_bl);
                    sand.Start();
                goto reset;
            case "4":
                    mistVillage mist = new mistVillage(_bl);
                    mist.Start();
                goto reset;
            case "5":
                    stoneVillage stone = new stoneVillage(_bl);
                    stone.Start();
                goto reset;
            default:
                    Console.WriteLine("The value you entered is not one of the stores... \nTry again!");
                goto reset1;
            }
        }
    }
}