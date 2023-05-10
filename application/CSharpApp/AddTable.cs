using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    internal class AddTable : StqrterAbstract
    {
        public AddTable(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }

        public override IEnumerable<string> GetCommand()
        {
            string result4 = "";
            var commands4 = GetListCommand("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Новая папка (2)\\russian_surnames.sql");
            var commandsAdd4 = commands4.Split(";");
            foreach (var oneCommandAdd in commandsAdd4)
                yield return string.Concat(oneCommandAdd.ToCharArray().Where(x => x != 65279).ToArray());
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

        public override void Introduction()
        {
            Console.WriteLine("Добавляю таблицу");
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
            };
        }
    }
}
