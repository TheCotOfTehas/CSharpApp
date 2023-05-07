//INSERT [foreign_names] ([id], [name],  [meaning], [gender], [origin],  [PeoplesCount],[WhenPeoplesCount],                        [Source])
//VALUES (                54173,N'Zurine',N'White', N'Female',N'Spanish', 693,           CAST(N'2016-07-08 10:51:03' AS DateTime),N'myData.biz')
//Console.WriteLine(s);
//Console.WriteLine(new string('-', 100));

using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using CSharpApp;

var r = Startup.GetListCommandInsert("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");
//Startup.Start("PersonDB", "C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");
//Starter.Start("PersonDB");
//Startup.ClearTable("PersonDB", "C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\foreign_names.sql");
foreach (var item in r)
{
    Console.WriteLine(item);
}
