using CSharpApp;
using Microsoft.Data.SqlClient;
using System.Data;

internal class Starter3 : StqrterAbstract
{
    public Starter3(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public override void Introduction()
    {
        Console.WriteLine("Это программа для вывода данных в консоль из существующей!!! таблицы");
        Console.WriteLine("Мне хотелось бы чтоб для любой, но это для конкретной таблици Persons с созданными в ней полями");
        Console.WriteLine("Задание 3. Вывод всех строк с уникальным значением ФИО+дата, отсортированным по ФИО , вывести ФИО, Дату рождения, пол, кол-во полных лет." +
                "Пример запуска приложения: myApp 3");
    }

    public override void LocalWork(SqlCommand sqlCommand)
    {
        var sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            Console.WriteLine($" {sqlDataReader["Name"]} {sqlDataReader["Surname"]} " +
                $"{sqlDataReader["Patronymic"]} {sqlDataReader["DateBirth"]}");
            Console.WriteLine(new string('-', 100));
        }
    }

    public override IEnumerable<string> GetCommand()
    {
        var command = $"SELECT DISTINCT [Name], [Surname], [Patronymic], [DateBirth]\r\n" +
            $"FROM [Persons]\r\n" +
            $"ORDER BY [Name], [Surname], [Patronymic];";

        yield return command;
    }
}