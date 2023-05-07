﻿//INSERT [foreign_names] ([id], [name],  [meaning], [gender], [origin],  [PeoplesCount],[WhenPeoplesCount],                        [Source])
//VALUES (                54173,N'Zurine',N'White', N'Female',N'Spanish', 693,           CAST(N'2016-07-08 10:51:03' AS DateTime),N'myData.biz')
//Console.WriteLine(s);
//Console.WriteLine(new string('-', 100));
//var r = Startup.GetListCommandInsert("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");
//Startup.Start("PersonDB", "C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");
//Starter.Start("PersonDB");
//Startup.ClearTable("PersonDB", "C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");


using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using CSharpApp;
using static Azure.Core.HttpHeader;

string connectionConfiguration = ConfigurationManager.ConnectionStrings["PersonDB"].ConnectionString;
SqlConnection sqlConnection = new SqlConnection(connectionConfiguration);

Console.WriteLine("Добро пожаловать, Вы  запустили консольное приложение для выполнения тестового задания");
//var myApp2 = new Starter2();
//var myApp3 = new Starter3();
//var myApp4 = new Starter4();
//var myApp5 = new Starter5();
//var myApp6 = new Starter6();

while (true)
{
    Console.WriteLine("Введите комманду запуска приложенния");
    Console.Write(", ");

    var command = Console.ReadLine();

    if (command.ToLower().Equals("exit"))
        break;

    switch (command.ToLower())
    {
        case "csharp myapp.cs 1":
            var myApp1 = new Starter1(sqlConnection);
            myApp1.Run();
            break;

        //case "CSharp myApp.cs 2":
        //    myApp2.Run();
        //    break;

        //case "CSharp myApp.cs 3":
        //    myApp3.Run();
        //    break;

        //case "CSharp myApp.cs 4":
        //    myApp4.Run();
        //    break;

        //case "CSharp myApp.cs 5":
        //    myApp5.Run();
        //    break;

        //case "CSharp myApp.cs 6":
        //    myApp6.Run();
        //    break;

        default:
            Console.WriteLine($"Комманада {command} была не корректной");
            break;
    }
}
