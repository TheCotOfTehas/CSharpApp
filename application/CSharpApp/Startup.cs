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
    public static class Startup
    {
        public static IEnumerable<string> GetListCommandInsert(string fileName)
        {
            using (FileStream stream = File.OpenRead(fileName))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                var arrayCommandSql = textFromFile.Split(';');
                foreach (string oneCommand in arrayCommandSql)
                {
                    var formatedOneCommand = GetFormatCommand(oneCommand);
                    if (formatedOneCommand.Length > 0 && formatedOneCommand.StartsWith("insert") && formatedOneCommand[^1] == ')')
                        yield return formatedOneCommand;
                }
            }
        }

        private static string GetFormatCommand(string stringCommand)
        {
            //Нужно убрать не корректные команды
            return stringCommand.Trim().ToLower();
        }

        public static  void AddToTable(string nameDB, string fileName, IEnumerable<string> arraySqlCommandString)
        {
            string connectionConfiguration = ConfigurationManager.ConnectionStrings[nameDB].ConnectionString;
            SqlConnection sqlConnection = null;
            sqlConnection = new SqlConnection(connectionConfiguration);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;

            using (FileStream fstream = File.OpenRead(fileName))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                var r = textFromFile.Split(';');

                foreach (string sqlCommandString in arraySqlCommandString)
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    Console.WriteLine(sqlCommandString);
                    try
                    {
                        Console.WriteLine($"Добавлено {sqlCommand.ExecuteNonQuery()}");
                    }
                    catch 
                    {
                        //Тут дою\бавить в лог ошибок
                        Console.WriteLine($"Error command {sqlCommandString}");
                    }
                }
            }

            sqlConnection.Close();
        }

        public static void ClearTable(string nameDB, string fileName)
        {
            string connectionConfiguration = ConfigurationManager.ConnectionStrings[nameDB].ConnectionString;
            SqlConnection sqlConnection = null;
            sqlConnection = new SqlConnection(connectionConfiguration);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            var rr = $"DELETE FROM [{fileName}] WHERE Id > -1";
            SqlCommand sqlCommand = new SqlCommand(rr, sqlConnection);
            Console.WriteLine($"Удалено {sqlCommand.ExecuteNonQuery()}");
            sqlConnection.Close();
        }

    }
}