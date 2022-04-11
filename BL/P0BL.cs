namespace BL;

public class P0BL: IP0BL
{
    private readonly DBRepository _repo; 
    public P0BL(DBRepository repo)
    {
        _repo = repo;
    }

    public Customer CreateCustomer(Customer customerToCreate)
    {
        return _repo.CreateCustomer(customerToCreate);
    }
    public List<Product> GetInventory(int VillageID)
    {
        return _repo.GetInventory(VillageID);
    }

    public List<Customer> GetAllCustomers(string tablename)
    {
        return _repo.GetAllCustomers(tablename);
    }

    public int GetProduct(int item, int VillageID)
    {
        return _repo.GetProduct(item, VillageID);
    }

    public void UpdateInventory(int item, int remaining, int VillageID)
    {
        _repo.UpdateInventory(item, remaining, VillageID);
    }




}