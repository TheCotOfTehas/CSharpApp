using CSharpApp;
using Microsoft.Data.SqlClient;
using System.Text;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;

internal class Starter4 
{
    //SqlConnection sqlConnection;

    //public Starter4(SqlConnection sqlConnection)
    //{
    //    this.sqlConnection = sqlConnection;
    //}

    //public override void Run()
    //{
    //    Console.WriteLine("Запуск добавления в таблицу значений");
    //    Console.WriteLine("Буду использовать готовую бд и на её осное создам новую");
    //    var arraySqlCommandString = GetListCommandInsert("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\foreign_names.sql");
    //    //CreateNeedMyTables("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\mssql_create_tables.sql");
    //    //AddToTableforeign_names(arraySqlCommandString);
    //    GetListCommand("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\mssql_create_tables.sql");
    //}


    //public static IEnumerable<string> GetListCommandInsert(string fileName)
    //{
    //    using (FileStream stream = File.OpenRead(fileName))
    //    {
    //        byte[] buffer = new byte[stream.Length];
    //        stream.Read(buffer, 0, buffer.Length);
    //        string textFromFile = Encoding.Default.GetString(buffer);
    //        var arrayCommandSql = textFromFile.Split(';');
    //        foreach (string oneCommand in arrayCommandSql)
    //        {
    //            var formatedOneCommand = GetFormatCommand(oneCommand);
    //            if (formatedOneCommand.Length > 0 && formatedOneCommand.StartsWith("INSERT") && formatedOneCommand[^1] == ')')
    //                yield return formatedOneCommand;
    //        }
    //    }
    //}
    //public void GetListCommand(string fileName)
    //{
    //    using (FileStream stream = File.OpenRead(fileName))
    //    {
    //        byte[] buffer = new byte[stream.Length];
    //        stream.Read(buffer, 0, buffer.Length);
    //        string textFromFile = Encoding.Default.GetString(buffer);
    //        var arrayCommandSql = textFromFile.Split(';');
    //        sqlConnection.Open();
    //        SqlCommand sqlCommand = new(textFromFile, sqlConnection);
    //        Console.WriteLine($"Создана {sqlCommand.ExecuteNonQuery()} таблица");
    //        sqlConnection.Close();
            
    //        //foreach (string oneCommand in arrayCommandSql)
    //        //{
    //        //    yield return oneCommand;
    //        //}
    //    }
    //}

    ////public void CreateNeedMyTables(string fileName)
    ////{
    ////    var commands = GetListCommand(fileName);
    ////    sqlConnection.Open();
    ////    foreach (var command in commands)
    ////    {
    ////        Console.WriteLine(command);
    ////        SqlCommand sqlCommand = new(command, sqlConnection);
    ////        Console.WriteLine($"Создана таблица {sqlCommand.ExecuteNonQuery()}");
    ////    }
    ////    sqlConnection.Close();
    ////}

    //public void AddToTableforeign_names(IEnumerable<string> arraySqlCommandString)
    //{
    //    sqlConnection.Open();
    //    Console.WriteLine($"{arraySqlCommandString.Count()}   Количество записей для добовления");
    //    int countAdd = 0;
    //    foreach (string sqlCommandString in arraySqlCommandString)
    //    {
    //        SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConnection);
    //        //var d = "insert [foreign_names] ([id],[name],[meaning],[gender],[origin],[peoplescount],[whenpeoplescount],[source]) values (43310,n'kody',n'\"assistant, a cushion, possessions.\"',n'male',n'celtic',14000,cast(n'2016-07-07 07:43:52' as datetime),n'mydata.biz')";
    //        try
    //        {
    //            Console.WriteLine($"Добавлено {sqlCommand.ExecuteNonQuery()}");
    //            countAdd++;
    //        }
    //        catch
    //        {
    //            //Тут дабавить в лог ошибок
    //            //Console.WriteLine($"Error command {sqlCommandString}");
    //        }
    //    }
    //    Console.WriteLine($"{arraySqlCommandString.Count()}   Добавлено в итоге");

    //    sqlConnection.Close();
    //}

    //private static string GetFormatCommand(string stringCommand)
    //{
    //    //Нужно убрать не корректные команды
    //    return stringCommand.Trim();
    //}
}