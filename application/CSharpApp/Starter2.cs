using Microsoft.Data.SqlClient;

internal class Starter2
{
    SqlConnection sqlConnection;
    public Starter2(SqlConnection sqlConnection)
    {
        this.sqlConnection = sqlConnection;
    }
    public void Run()
    {
        var nameTable = GetConsole("Введите название таблици");

        var name = GetConsole("Введите Имя");
        var surname = GetConsole("Введите Фамилию");
        var patronymic = GetConsole("Введите Отчество");
        var gender = GetConsole("Введите Пол");
        var dateBirth = GetConsole("Введите дату в формате гггг-мм-дд");

        string addEntryCommand = $"INSERT [{nameTable}] ([Name], [Surname], [Patronymic], [Gender], [DateBirth])\r\n" +
                         $"VALUES (N'{name}',N'{surname}', N'{patronymic}',N'{gender}', CAST(N'{dateBirth}' AS DateTime))";

        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand(addEntryCommand, sqlConnection);
        Console.WriteLine($"Создана  {sqlCommand.ExecuteNonQuery()} запись");
        sqlConnection.Close();
    }

    private string GetConsole(string request)
    {
        Console.WriteLine(request);
        Console.Write(", ");
        return Console.ReadLine();
    }
}