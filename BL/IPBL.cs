namespace BL;
public interface IP0BL
{
    public List<Product> GetInventory(int VillageID);

    public Customer CreateCustomer(Customer customerToCreate);

    public List<Customer> GetAllCustomers(string tablename);

    public void UpdateInventory(int item, int remaining, int VillageID);

    public int GetProduct(int item, int VillageID);



    
    //public void GetInventory();
    //public void GetUsers();
    //public void CreateCustomer();








}
