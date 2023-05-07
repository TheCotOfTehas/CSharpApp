using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSharpApp
{
    public class Starter1
    {
        SqlConnection sqlConnection;
        public Starter1(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public void Run()
        {
            Console.WriteLine("Введите название таблици");
            Console.Write(", ");
            string nameTable = Console.ReadLine();

            string command = $"CREATE TABLE [dbo].[{nameTable}] (\r\n" +
                            "[Id] INT IDENTITY (1, 1) NOT NULL,\r\n" +
                            "[Name] NCHAR (20) NULL,\r\n" +
                            "[Surname] NCHAR (20) NULL,\r\n" +
                            "[Patronymic] NCHAR (20) NULL,\r\n" +
                            "[Gender] NCHAR (20) NULL,\r\n" +
                            "[DateBirth]  DATE       NULL,\r\n" +
                            "PRIMARY KEY CLUSTERED ([Id] ASC)\r\n);";

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            Console.WriteLine($"Создана  {sqlCommand.ExecuteNonQuery()} таблица");
            sqlConnection.Close();
        }
    }
}
