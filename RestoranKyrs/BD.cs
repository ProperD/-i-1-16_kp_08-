using System.Data;
using System.Data.SqlClient;

public class BD
{
    private const string dataSource = @"DESKTOP-QGKOCIM\ILYA",  //Имя сервера
                     initialCatalog = "Restoran",   //Имя базы данных
                     userID = "sa",         //Имя входа
                     password = "1234"; //Пароль входа
    private const bool checkSecurity = true; //Проверка подлинности SQl

    public SqlConnection DatabaseSQL()
    {
        SqlConnection sqlConnection = new SqlConnection($"Data Source = {dataSource}; Initial Catalog = {initialCatalog};" +
        $"Persist Security Info = {checkSecurity}; User ID = {userID}; password = \"{password}\"");
        return sqlConnection;
    }

    public DataSet TableFill(string query, SqlConnection sql)
    {
        SqlDataAdapter adapter = new SqlDataAdapter(query, sql);
        DataSet dataSet = new DataSet();
        dataSet.Clear();
        adapter.Fill(dataSet);
        return dataSet;
    }
}

