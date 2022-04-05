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
        Welcome();
        WelcomePrompt(currentCustomer);
    }

//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            All Methods           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--

    private void Welcome()
    {
        Console.WriteLine("{1} Hidden Leaf Village");
        Console.WriteLine("{2} Hidden Cloud Village");
        Console.WriteLine("{3} Hidden Sand Village");
        Console.WriteLine("{4} Hidden Mist Village");
        Console.WriteLine("{5} Hidden Stone Vilage");
    }

    private void WelcomePrompt(Customer currentCustomer)
    {
        Console.WriteLine("Which store would you like to enter?");
        string? a =Console.ReadLine();
        if(a != null)
        {
        int answer = Convert.ToInt32(a);
            switch(answer)
            {
            case 1:
                    leafVillage next = new leafVillage(__repo);
                    next.Start();
                break;
            case 2:
                    //Enter Hidden Cloud Village
                break;
            case 3:
                    //Enter Hidden Sand Village
                break;
            case 4:
                    //Enter Hidden Mist Village
                break;
            case 5:
                    //Enter Hidden Stone Vilage
                break;
            default:
                    Console.WriteLine("The value you entered is not one of the stores... \nTry again!");
                    WelcomePrompt(currentCustomer);
                break;
            }
        }
    }











}