using DB;

namespace UI;

public class leafVillage
{
    private readonly DBRepository ___repo;

    public leafVillage(DBRepository __repo)
    {
        ___repo = __repo;
    }
    public void Start(Customer currentCustomer)
    {
        Welcome();
        CartPrompt();
    }

    private void Welcome()
    {
    List<Product> product =___repo.GetAllLeafProducts();
        foreach(Product p in product )
        {
            Console.WriteLine(p);
        }
    }

    private void CartPrompt()
    {
        tryagain1:
        Console.WriteLine("Would you like to buy something [Y/N]");
        string? answer = Console.ReadLine();
        if(answer != null)
        {
            char answerC = answer[0];

            if(Char.ToUpper(answerC) == 'Y')
            {
                Console.WriteLine("Enter the product Id you'd like to purchase");
                string? i = Console.ReadLine();
                int item = Convert.ToInt32(i);

                int number = ___repo.getLeafProduct(item);

            tryagain:
                Console.WriteLine("How many would you like to buy?: ");
                string? b = Console.ReadLine();
                int buy = Convert.ToInt32(b);

                if (number>buy)
                {
                    int remaining = number - buy;
                    ___repo.UpdateInventory(item, remaining);
                }
                else if(number<buy)
                {
                    Console.WriteLine("There is not enough of that product to complete your purchase...");
                    goto tryagain;
                }
            }
            else if(Char.ToUpper(answerC) == 'N')
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input... Try again!");
                goto tryagain1;
            }
        }
    }
}