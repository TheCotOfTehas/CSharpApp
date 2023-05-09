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

        public override void Introduction() //возможно это должно быть 
        {
            Console.WriteLine("Это прога для содания таблици с полями для задания");
            Console.WriteLine("Задание 1. Создание таблицы с полями представляющими ФИО, дату рождения, пол.");
        }

        public override void LocalWork(SqlCommand sqlCommand)
        {
            Console.WriteLine($"Создана  {sqlCommand.ExecuteNonQuery()} таблица");
        }

        public override string GetCommand()
        {
            Console.WriteLine("Введите название таблици");
            Console.Write(", ");
            string nameTable = Console.ReadLine();
            //Тут добавить немного обработки на корректность

            string command = $"CREATE TABLE [dbo].[{nameTable}] (\r\n" +
                "[Id] INT IDENTITY (1, 1) NOT NULL,\r\n" +
                "[Name] NCHAR (20) NULL,\r\n" +
                "[Surname] NCHAR (20) NULL,\r\n" +
                "[Patronymic] NCHAR (20) NULL,\r\n" +
                "[Gender] NCHAR (20) NULL,\r\n" +
                "[DateBirth]  DATE       NULL,\r\n" +
                "PRIMARY KEY CLUSTERED ([Id] ASC)\r\n);";

            return command;
        }
    }
}
