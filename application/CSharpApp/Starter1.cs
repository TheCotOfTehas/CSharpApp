using Azure.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace CSharpApp
{
    public class Starter1 : StqrterAbstract
    {
        public Starter1(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }

        public override void Introduction() 
        {
            Console.WriteLine("Это прога для содания таблици с полями для задания");
            Console.WriteLine("Задание 1. Создание таблицы с полями представляющими ФИО, дату рождения, пол.");
        }

        public override void LocalWork(SqlCommand sqlCommand)
        {
            Console.WriteLine($"Создана  {sqlCommand.ExecuteNonQuery()} таблица");
        }

        public override IEnumerable< string> GetCommand()
        {
            Console.WriteLine("Введите название таблици");
            Console.Write(", ");
            string nameTable = Console.ReadLine();
            //Тут добавить проверку о её  наличии

            string command = $"CREATE TABLE [dbo].[{nameTable}] (\r\n" +
                "[Id] INT IDENTITY (1, 1) NOT NULL,\r\n" +
                "[Name] NCHAR (30) NULL,\r\n" +
                "[Surname] NCHAR (30) NULL,\r\n" +
                "[Patronymic] NCHAR (30) NULL,\r\n" +
                "[Gender] NCHAR (30) NULL,\r\n" +
                "[DateBirth]  DATE       NULL,\r\n" +
                "PRIMARY KEY CLUSTERED ([Id] ASC)\r\n);";

             yield return command;
        }
    }
}
