using CSharpApp;
using Microsoft.Data.SqlClient;

internal class Starter2 : StqrterAbstract
{
    public Starter2(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public override void Introduction()
    {
        Console.WriteLine("Это программа для внесения данных в уже созданную!!! таблицу");
        Console.WriteLine("Задание 2. Создание записи. Использовать следующий формат:\r\nmyApp 2 ФИО ДатаРождения Пол");
    }

    public override void LocalWork(SqlCommand sqlCommand)
    {
        Console.WriteLine($"Создана  {sqlCommand.ExecuteNonQuery()} запись");
    }

    public override string GetCommand()
    {
        var nameTable = GetConsole("Введите название таблици");

        var name = GetConsole("Введите Имя");
        var surname = GetConsole("Введите Фамилию");
        var patronymic = GetConsole("Введите Отчество");
        var gender = GetConsole("Введите Пол");
        var dateBirth = GetConsole("Введите дату в формате гггг-мм-дд");

        string command = $"INSERT [{nameTable}] ([Name], [Surname], [Patronymic], [Gender], [DateBirth])\r\n" +
                         $"VALUES (N'{name}',N'{surname}', N'{patronymic}',N'{gender}', CAST(N'{dateBirth}' AS DateTime))";

        return command;
    }
}