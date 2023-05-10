using Entities;
using Mamory;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;


namespace CSharpApp
{
    internal class Starter4
    {
        public SqlConnection sqlConnection;
        public Starter4(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Run()
        {
            Introduction();
            var nameTable = "Persons";
            string commandName = $"SELECT *\r\n" +
                             $"FROM [russian_names];";

            string commandSurnames = $"SELECT *\r\n" +
                             $"FROM [russian_surnames];";

            var listSurnam = GetSurname(commandSurnames);
            var listName = GetName(commandName);
            var listPerson = new List<Person>();
            for (int i = 0; i < listSurnam.Count && i < listName.Count; i++)
            {
                var person = new Person()
                {
                    Name = listName[i].Name_,
                    Surname = listSurnam[i].Surnam,
                    Gender = listSurnam[i].Sex == "Ж"? Gender.Woman : Gender.Man,
                    DateBirth = listName[i].WhenPeoplesCount,
                    Id = Guid.NewGuid(),
                    Patronymic = listSurnam[i].Surnam
                };

                listPerson.Add(person);
            }
            sqlConnection.Open();
            foreach (var person in listPerson)
            {
                string command = $"INSERT [{nameTable}] ([Name], [Surname], [Patronymic], [Gender], [DateBirth])\r\n" +
                $"VALUES (N'{person.Name}',N'{person.Surname}', N'{person.Patronymic}',N'{person.Gender}', CAST(N'{person.DateBirth.Year}-{person.DateBirth.Month}-{person.DateBirth.Day}' AS DateTime))";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                Console.WriteLine($"Создана  {sqlCommand.ExecuteNonQuery()} запись");
            }
            sqlConnection.Close();
        }

        public List<Surname> GetSurname(string command)
        {
            sqlConnection.Open();
            SqlCommand sqlComSurnames = new SqlCommand(command, sqlConnection);
            var sqlRussianSurnamesReader = sqlComSurnames.ExecuteReader();

            List<Surname> name = new List<Surname>();
            while (sqlRussianSurnamesReader.Read())
            {
                var person = new Surname()
                {
                    ID = (int)sqlRussianSurnamesReader["ID"],
                    Source = (string)sqlRussianSurnamesReader["Source"],
                    Surnam = (string)sqlRussianSurnamesReader["Surname"],
                    PeoplesCount = (int)sqlRussianSurnamesReader["PeoplesCount"],
                    WhenPeoplesCount = (DateTime)sqlRussianSurnamesReader["WhenPeoplesCount"]
                };
                name.Add(person);
            }
            sqlConnection.Close();

            return name;
        }

        public List<Name> GetName(string comcommand)
        {
            sqlConnection.Open();
            SqlCommand sqlComSurnames = new SqlCommand(comcommand, sqlConnection);
            var sqlRussianSurnamesReader = sqlComSurnames.ExecuteReader();

            List<Name> name = new List<Name>();
            while (sqlRussianSurnamesReader.Read())
            {
                var person = new Name()
                {
                    ID = (int)sqlRussianSurnamesReader["ID"],
                    Source = (string)sqlRussianSurnamesReader["Source"],
                    Name_ = (string)sqlRussianSurnamesReader["Name"],
                    PeoplesCount = (int)sqlRussianSurnamesReader["PeoplesCount"],
                    WhenPeoplesCount = (DateTime)sqlRussianSurnamesReader["WhenPeoplesCount"]
                };
                name.Add(person);
            }
            sqlConnection.Close();

            return name;
        }
        public void Introduction()
        {
            Console.WriteLine("Заполнение автоматически 1000000 строк. " +
                "Распределение пола в них должно быть относительно равномерным, начальной буквы ФИО также. " +
                "Заполнение автоматически 100 строк в которых пол мужской и ФИО начинается с \"F\".\r\nПример запуска приложения:\r\nmyApp 4");
        }
    }
}
