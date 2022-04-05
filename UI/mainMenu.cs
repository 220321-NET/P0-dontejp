using DB;

namespace UI;
public class mainMenu
{
    private readonly DBRepository _repo;
    public mainMenu(DBRepository repo)
    {
        _repo = repo;
    }
    public void start()
    {
        introduction();
        loginPage();
        loginPagePrompt();
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
                    return;
                }
                Console.WriteLine("Invalid Username");
                loginPage();
                loginPagePrompt();
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

        Customer createdCustomer = _repo.CreateCustomer(customerToCreate);

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

    private void login(string uName)
    {
        Customer currentCustomer = new Customer();
        List<Customer> allCustomers =_repo.GetAllCustomers();
        foreach (Customer customer in allCustomers)
        {
            if (customer.Username == uName)
            {
                currentCustomer.Id = customer.Id;
                currentCustomer.Username = customer.Username;
                currentCustomer.Balance = customer.Balance;
                StoreFronts StoreFronts = new StoreFronts(_repo);
                StoreFronts.Start(currentCustomer);
            }
        }
    }
}

