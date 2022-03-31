// See https://aka.ms/new-console-template for more information

namespace P0
{
    internal class Store
    {
        //--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
        //--<>--<>--<>--<>--<>--<>--<>--<>--            All Methods           --<>--<>--<>--<>--<>--<>--<>--<>--
        //--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--

        public void introduction()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("| Welcome to the ninja hub! This is the  |");
            Console.WriteLine("| one stop shop for all ninja accesories |");
            Console.WriteLine("|             （ -.-）/ -=≡ +              |");
            Console.WriteLine("==========================================");
        }

        public void mainMenu()
        {
            // Prints The login Page
                
            Console.WriteLine("==========================================");
            Console.WriteLine("|      Login        or       Sign-Up     |");
            Console.WriteLine("|       (L)                    (S)       |");
            Console.WriteLine("==========================================");
                    //|x|Reading User Input
                        //|x| Account for L
                        //|x| Account for S
                        //|x| Account for else 
                        // search issues
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
                    signup();
                    Console.WriteLine("Sign-Up Complete");
                    
                    // Console.WriteLine("Username: "+ customer.Username);
                    // Console.WriteLine("Balance: "+ customer.Money);
                    
                }
                else
                {
                    Console.WriteLine("");
                    mainMenu();
                }
            }
        }


        //Login
            //|x|Reads user input 
            //| |Searches database for UserInfo
            //| |Grants Access
        private void login()
        {
            
        }
        //Sign-up
            //| |Prompts username
        private void signup()
        {
            // prompts to grab initial account info
            
            Console.Write("What is your Username: ");
            string? aUsername = Console.ReadLine()?.ToLower();
            Console.Write("\nHow much money would you like to add?: ");
            int aMoney = Convert.ToInt32(Console.ReadLine());
            if (aUsername != null)
            {
            //adds the new customer to the list of customers
                Storage.aCustomers.Add(new Customer
                {
                    Username = aUsername,
                    Money = aMoney
                });
                foreach(var customer in Storage.aCustomers)
                {
                    Console.WriteLine("New Username: " + customer.Username);
                    Console.WriteLine("Current Balance: "+ customer.Money);
                }
            }
        }
    }
}