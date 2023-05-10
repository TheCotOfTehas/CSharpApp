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
using System.Xml.Linq;

internal class Starter7 : StqrterAbstract
{
    public Starter7(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public override void Introduction()
    {
        Console.WriteLine("Запуск добавления в таблицу значений");
        Console.WriteLine("Здесь я содам таблици с данными и заполю их, они мне нужны для реализиации 4-го задания");
    }

    public override IEnumerable<string> GetCommand()
    {
        //Прошу прощения за эту конструкцию. Если мне повезёт я Вам постараюсь объяснить
        var tableOne = "foreign_names";
        var tableTwo = "russian_names";
        var tableЕhree = "russian_surnames";

        //Надо на каждую таблицу отдельную проверку  и саму проверку сделать, пока так пусть без реализации
        if (!ContainsTable(tableOne) && !ContainsTable(tableOne) && !ContainsTable(tableOne))
        {
            var commands = GetListCommand("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\mssql_create_tables.sql");
            var arraayTableCreate = commands.Split(";");
            foreach (var oneTableCreate in arraayTableCreate)
                yield return string.Concat(oneTableCreate.ToCharArray().Where(x => x != 65279).ToArray());
        }

        // заполнения этих таблиц 
        var commands2 = GetListCommand("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\foreign_names.sql");
        var commandsAdd1 = commands2.Split(";");
        foreach (var oneCommandAdd in commandsAdd1)
            yield return string.Concat(oneCommandAdd.ToCharArray().Where(x => x != 65279).ToArray());

        var commands3 = GetListCommand("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\russian_names.sql");
        var commandsAdd3 = commands3.Split(";");
        foreach (var oneCommandAdd in commandsAdd3)
           yield return string.Concat(oneCommandAdd.ToCharArray().Where(x => x != 65279).ToArray());

        string result4 = "";
        var commands4 = GetListCommand("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\russian_surnames.sql");
        var commandsAdd4 = commands4.Split(";");
        foreach (var oneCommandAdd in commandsAdd4)
            yield return string.Concat(oneCommandAdd.ToCharArray().Where(x => x != 65279).ToArray());
    }

    public override void LocalWork(SqlCommand sqlCommand)
    {
        try
        {
            Console.WriteLine($"Выполнена команда  {sqlCommand.ExecuteNonQuery()}");
        }
        catch
        {
            Console.WriteLine("Ошибка в команде -  " + sqlCommand.CommandText);
        }
    }

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
                if (formatedOneCommand.Length > 0 && formatedOneCommand.StartsWith("INSERT") && formatedOneCommand[^1] == ')')
                    yield return formatedOneCommand;
            }
        }
    }
    public string GetListCommand(string fileName)
    {
        using (FileStream stream = File.OpenRead(fileName))
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            string textFromFile = Encoding.Default.GetString(buffer);
            return textFromFile;
        }
    }

    private static string GetFormatCommand(string stringCommand)
    {
        //Нужно убрать не корректные команды по  ситуации
        return stringCommand.Trim();
    }
}