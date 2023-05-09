using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    public abstract class StqrterAbstract
    {
        public SqlConnection sqlConnection;

        public StqrterAbstract(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public abstract void Introduction();
        public void Run()
        {
            Introduction();
            var command = GetCommand();
            DoWorkingDB(command);
        }

        public string GetConsole(string request)
        {
            Console.WriteLine(request);
            Console.Write(", ");
            return Console.ReadLine();
        }

        public abstract string GetCommand();

        public void DoWorkingDB(string command)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            LocalWork(sqlCommand);
            sqlConnection.Close();
        }

        public abstract void LocalWork(SqlCommand sqlCommand);
    }
}
