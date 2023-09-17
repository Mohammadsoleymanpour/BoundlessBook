using System.Data;
using Microsoft.Data.SqlClient;

namespace BoundlessBook.Infrastructure.Dapper.Persistent;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }


    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);


    public string Inventories = "[seller].Inventories";
    public string OrderItems = "[order].OrderItems";
    public string Sellers = "[seller].Sellers";
    public string Products = "[product].Products";
    public string UserAddresses = "[user].Addresses";
    public string UserTokens => "[user].Tokens";
}