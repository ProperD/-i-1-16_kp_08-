using System.Data.SqlClient;

public class ConnectBD
{
    public SqlConnection GetSqlConnection(string dataSource, string initialCatalog, string userID, string password, bool checkSecurity)
    {
        string connectSql = $"Data Source = {dataSource}; Initial Catalog = {initialCatalog};" +
            $"Persist Security Info = {checkSecurity}; User ID = {userID}; password = {password}";
        SqlConnection connect = new SqlConnection(connectSql);
        return connect;
    }
}
