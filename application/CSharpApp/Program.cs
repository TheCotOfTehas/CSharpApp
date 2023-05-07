using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using CSharpApp;

Startup.Run("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");
string connectionConfiguration = ConfigurationManager.ConnectionStrings["PersonDB"].ConnectionString;
SqlConnection sqlConnection = null;
sqlConnection = new SqlConnection(connectionConfiguration);
sqlConnection.Open();
Console.WriteLine("Hello, World!");
SqlDataReader sqlDataReader = null;
string command = string.Empty;

while (true)
{
    Console.Write(", ");
    command = Console.ReadLine();

    if (command.ToLower().Equals("exit"))
    {
        if (sqlConnection.State == ConnectionState.Open || sqlDataReader != null)
            sqlConnection.Close();

        break;
    }

    SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

    //SELECT * FROM [Persons] WHERE Id = 1
    //INSERT INTO [Persons] (Name, Surname, Patronymic, Gender, DateBirth) values(N'Имя', N'Фамилия', N'Отчество', N'Пол', '2017-07-28')
    //DELETE FROM [Persons] WHERE Id = 1
    switch (command.Split(' ')[0].ToLower())
    {
        case "select":
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Console.WriteLine($"{sqlDataReader["Id"]} {sqlDataReader["Name"]} {sqlDataReader["Surname"]} " +
                    $"{sqlDataReader["Patronymic"]} {sqlDataReader["Gender"]} {sqlDataReader["DateOfBirth"]}");
                Console.WriteLine(new string('-', 30));
            }


            if (sqlDataReader != null)
            {
                sqlDataReader.Close();
            }

            break;
        case "insert":
            Console.WriteLine($"Добавлено {sqlCommand.ExecuteNonQuery()}");

            break;
        case "update":
            Console.WriteLine($"Обновлено {sqlCommand.ExecuteNonQuery()}");

            break;
        case "delete":
            Console.WriteLine($"Удалена {sqlCommand.ExecuteNonQuery()} строка");

            break;
        default:
            Console.WriteLine($"Комманада {command} была не корректной");
            break;
    }

    Console.WriteLine("Для продолжения нажмите любую клавишу");
    Console.ReadKey();
}