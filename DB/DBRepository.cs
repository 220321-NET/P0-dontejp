using Microsoft.Data.SqlClient;
using Models;


namespace DB;
public class DBRepository
{
    private readonly string? _connectionString;
    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Customer> GetAllCustomers(string tablename)
    {
            List<Customer> allCustomers = new List<Customer>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            string sql = String.Format("SELECT * FROM {0}", tablename);
            SqlCommand cmd = new SqlCommand(sql, connection);

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
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            Leaf Tables           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
    public void UpdateInventory(int item, int remaining, string tablename)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string sql = String.Format("Update {0} SET Quantity=@remaining WHERE ProductId=@item", tablename);

        using SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }

    public List<Product> GetAllLeafProducts()
    {
        List<Product> allLeafProducts = new List<Product>();

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
                allLeafProducts.Add(item);
            }

            reader.Close();
            connection.Close();
            return allLeafProducts;
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

//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            Cloud Tables          --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--

    public void UpdateCloudInventory(int item, int remaining)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE CloudInventory SET Quantity=@remaining  WHERE ProductId=@item", connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }

    public List<Product> GetAllCloudProducts()
    {
        List<Product> allLeafProducts = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM CloudInventory", connection);
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
                allLeafProducts.Add(item);
            }

            reader.Close();
            connection.Close();
            return allLeafProducts;
    }

    public int getCloudProduct(int item)
    {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Quantity FROM CloudInventory WHERE ProductID= @item", connection);

            cmd.Parameters.AddWithValue("@item", item);
            int quantity = (int) cmd.ExecuteScalar();

            connection.Close();
            return quantity;
    }
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            Sand Tables           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
public void UpdateSandInventory(int item, int remaining)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE SandInventory SET Quantity=@remaining  WHERE ProductId=@item", connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }

    public List<Product> GetAllSandProducts()
    {
        List<Product> allLeafProducts = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM SandInventory", connection);
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
                allLeafProducts.Add(item);
            }

            reader.Close();
            connection.Close();
            return allLeafProducts;
    }

    public int getSandProduct(int item)
    {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Quantity FROM SandInventory WHERE ProductID= @item", connection);

            cmd.Parameters.AddWithValue("@item", item);
            int quantity = (int) cmd.ExecuteScalar();

            connection.Close();
            return quantity;
    }

//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            Mist Tables           --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
public void UpdateMistInventory(int item, int remaining)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE MistInventory SET Quantity=@remaining  WHERE ProductId=@item", connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }

    public List<Product> GetAllMistProducts()
    {
        List<Product> allLeafProducts = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM MistInventory", connection);
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
                allLeafProducts.Add(item);
            }

            reader.Close();
            connection.Close();
            return allLeafProducts;
    }

    public int getMistProduct(int item)
    {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Quantity FROM MistInventory WHERE ProductID= @item", connection);

            cmd.Parameters.AddWithValue("@item", item);
            int quantity = (int) cmd.ExecuteScalar();

            connection.Close();
            return quantity;
    }
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>--            Stone Tables          --<>--<>--<>--<>--<>--<>--<>--<>--
//--<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>----<>--<>--<>--<>--<>--<>--<>--<>--

public void UpdateStoneInventory(int item, int remaining)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE StoneInventory SET Quantity=@remaining  WHERE ProductId=@item", connection);
        cmd.Parameters.AddWithValue("@item", item);
        cmd.Parameters.AddWithValue("@remaining", remaining);

        cmd.ExecuteScalar();

        connection.Close();
    }

    public List<Product> GetAllStoneProducts()
    {
        List<Product> allLeafProducts = new List<Product>();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM StoneInventory", connection);
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
                allLeafProducts.Add(item);
            }

            reader.Close();
            connection.Close();
            return allLeafProducts;
    }

    public int getStoneProduct(int item)
    {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Quantity FROM StoneInventory WHERE ProductID= @item", connection);

            cmd.Parameters.AddWithValue("@item", item);
            int quantity = (int) cmd.ExecuteScalar();

            connection.Close();
            return quantity;
    }
}

