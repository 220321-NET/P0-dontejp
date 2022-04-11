using DB;
using BL;
using Models;
namespace UI;

public class leafVillage: StoreFronts
{
    protected int VillageID;

    public leafVillage(IP0BL bl): base(bl)
    {

    }
    public virtual void Start()
    {
        VillageID = 1;
        Welcome();
        CartPrompt();
    }

    protected void Welcome()
    {
    
    List<Product> product =_bl.GetInventory(VillageID);
        foreach(Product p in product )
        {
            Console.WriteLine(p);
        }
    }

    protected void CartPrompt()
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

                int number = _bl.GetProduct(item,VillageID);

                Console.WriteLine("How many would you like to buy?: ");
                string? b = Console.ReadLine();
                int buy = Convert.ToInt32(b);

                if (number>=buy && buy >0)
                {
                    int remaining = number - buy;
                    _bl.UpdateInventory(item, remaining, VillageID);
                    Console.WriteLine(buy+ " items purchased "+remaining+ " remaining");
                }
                else if(number< buy)
                {
                    Console.WriteLine("There is not enough of that product to complete your purchase...");
                    goto tryagain1;
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