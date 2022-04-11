
namespace UI;
public class mainMenu
{
    protected readonly IP0BL _bl;
    public mainMenu(IP0BL bl)
    {
        _bl = bl;
    }
    public void start()
    {
        introduction();
        here:
        loginPage();
        loginPagePrompt();
        goto here;
    }   
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            All Methods           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
    private void introduction()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("| Welcome to the ninja hub! This is the  |");
        Console.WriteLine("| one stop shop for all ninja accesories |");
        Console.WriteLine("|             （ -.-）/ -=≡ +              |");
        Console.WriteLine("==========================================");
    }

    private void loginPage()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("|      Login        or       Sign-Up     |");
        Console.WriteLine("|       (L)                    (S)       |");
        Console.WriteLine("==========================================");
    }

    private void loginPagePrompt()
    {
        string? answer = Console.ReadLine();   
        if(answer != null)
        {
            char answerC = answer[0];

            if(Char.ToUpper(answerC)== 'L')
            {
                Console.WriteLine("Enter your username: ");
                string? uName = Console.ReadLine();
                if (uName != null)
                {
                    login(uName);
                    Console.WriteLine("Username does not exist. Try signing up!");
                    return;
                }
            }

            else if(Char.ToUpper(answerC) == 'S')
            {
                signUp();
                Console.WriteLine("Sign-Up Complete");
            }

            else
            {
                Console.WriteLine("Please type L or S to proceed");
                loginPagePrompt();
            }
        }
    }


    private void signUp()
    {
        Console.WriteLine("Creating Profile");
        Console.Write("Enter your Username: ");
        string? username= Console.ReadLine()?.ToLower();
        Console.Write("Enter your balance: ");
        string? b = Console.ReadLine();
        int balance = Convert.ToInt32(b);

        Customer customerToCreate = new Customer();

        customerToCreate.Username = username;
        Console.WriteLine("Your Username is: " + username);
        customerToCreate.Balance = balance;
        Console.WriteLine("Your balance is : " + balance);

        Customer createdCustomer = _bl.CreateCustomer(customerToCreate);

        if (createdCustomer != null)
        {
            Console.WriteLine("Customer sucessfully created!");
            Console.WriteLine(createdCustomer);
        }


        // List<Customer> customer =_repo.GetProfile();
        // foreach(Customer c in customer )
        // {
        //     Console.WriteLine(c);
        // }

    }

    public void login(string uName)
    {
        string tablename = "Users";
        Customer currentCustomer = new Customer();
        List<Customer> allCustomers =_bl.GetAllCustomers(tablename);
        foreach (Customer customer in allCustomers)
        {
            if (customer.Username == uName)
            {
                currentCustomer.Id = customer.Id;
                currentCustomer.Username = customer.Username;
                currentCustomer.Balance = customer.Balance;
                StoreFronts StoreFronts = new StoreFronts(_bl);
                StoreFronts.Start(currentCustomer);
            }
        }
        return;
    }
}

