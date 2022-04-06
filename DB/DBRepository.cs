using Microsoft.Data.SqlClient;

namespace DB;
public class DBRepository
{
    private readonly string? _connectionString;
    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Customer> GetAllCustomers()
    {
            List<Customer> allCustomers = new List<Customer>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int id = reader.GetInt32(0);
                string username = reader.GetString(1);
                int balance = reader.GetInt32(2);

                Customer profile = new Customer{
                        Id = id,
                        Username = username,
                        Balance = balance
                };
                allCustomers.Add(profile);
            }
            reader.Close();
            connection.Close();

            return allCustomers;
    }

    public Customer CreateCustomer(Customer customerToCreate)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("INSERT INTO Users(Username, Balance) OUTPUT INSERTED.Id Values (@Username,@Balance)", connection);

        cmd.Parameters.AddWithValue("@Username", customerToCreate.Username);
        cmd.Parameters.AddWithValue("@Balance", customerToCreate.Balance);

        customerToCreate.Id = (int) cmd.ExecuteScalar();

        // using SqlCommand cmd = new SqlCommand($"INSERT INTO Users(Id,Username, Balance) VALUES ({customerToCreate.Id}{customerToCreate.Username}, {customerToCreate.Balance})", connection);

        connection.Close();

        return customerToCreate;
    }

    public void UpdateInventory(int item, int remaining)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE LeafInventory SET Quantity=@remaining  WHERE ProductId=@item", connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }

    public List<Product> GetAllLeafProducts()
    {
        List<Product> allProducts = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM LeafInventory", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int price = reader.GetInt32(2);
                int quantity = reader.GetInt32(3);

                Product item = new Product{
                        Id = id,
                        Name = name,
                        Price = price,
                        Quantity = quantity
                };
                allProducts.Add(item);
            }

            reader.Close();
            connection.Close();
            return allProducts;
    }

    public int getLeafProduct(int item)
    {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Quantity FROM LeafInventory WHERE ProductID= @item", connection);

            cmd.Parameters.AddWithValue("@item", item);
            int quantity = (int) cmd.ExecuteScalar();

            connection.Close();
            return quantity;
    }

}
