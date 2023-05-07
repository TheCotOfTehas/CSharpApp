using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    public class Starter
    {
        public static void Start(string nameDB)
        {
            string connectionConfiguration = ConfigurationManager.ConnectionStrings[nameDB].ConnectionString;
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
                            sqlDataReader.Close();
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
        }
    }
}
