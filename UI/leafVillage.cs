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
        
    }

    private void Welcome()
    {
    List<Product> product =___repo.GetAllLeafProducts();
        foreach(Product p in product )
        {
            Console.WriteLine(p);
        }
    }


}