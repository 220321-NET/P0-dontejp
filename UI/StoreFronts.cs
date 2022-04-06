using DB;
namespace UI;

public class StoreFronts
{
    private readonly DBRepository __repo;

    public StoreFronts(DBRepository _repo)
    {
        __repo = _repo;
    }
    public void Start(Customer currentCustomer)
    {
        Console.WriteLine("Welcome to the Ninja hub "+ currentCustomer.Username + "             Balance: $" + currentCustomer.Balance);
        WelcomePrompt(currentCustomer);
    }

//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            All Methods           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--



    private void WelcomePrompt(Customer currentCustomer)
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
                    leafVillage leaf = new leafVillage(__repo);
                    leaf.Start(currentCustomer);
                goto reset;
            case "2":
                    cloudVillage cloud = new cloudVillage(__repo);
                    cloud.Start(currentCustomer);
                goto reset;
            case "3":
                    sandVillage sand = new sandVillage(__repo);
                    sand.Start(currentCustomer);
                goto reset;
            case "4":
                    mistVillage mist = new mistVillage(__repo);
                    mist.Start(currentCustomer);
                goto reset;
            case "5":
                    stoneVillage stone = new stoneVillage(__repo);
                    stone.Start(currentCustomer);
                goto reset;
            default:
                    Console.WriteLine("The value you entered is not one of the stores... \nTry again!");
                goto reset1;
            }
        }
    }











}