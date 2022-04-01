namespace UI;
public class mainMenu
{

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
                Console.WriteLine("Login");
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
        Console.Write("What is your Username: ");
        string? username= Console.ReadLine()?.ToLower();
        Console.WriteLine("Your Username is: " + username);
    }

    private void testing()
    {
        
    }


}

