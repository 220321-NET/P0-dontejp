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

}
