using DB;

namespace UI;

public class leafVillage
{
    private readonly DBRepository ___repo;

    public leafVillage(DBRepository __repo)
    {
        ___repo = __repo;
    }
    public void Start()
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
                switch(item)
                {
                    case 1:
                            int number = ___repo.getLeafProduct(item);
                            Console.WriteLine(number);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
            else if(Char.ToUpper(answerC) == 'N')
            {
                
            }

        }


    }


}