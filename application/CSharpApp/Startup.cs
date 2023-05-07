using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    public static class Startup
    {
        public static async void Run(string fileName)
        {
            using (FileStream fstream = File.OpenRead(fileName))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                var r = textFromFile.Split(';');
                foreach (string s in r)
                {
                    var rr = s.Trim().ToLower();
                    if (rr.Length > 0 && rr[0] == 'i')
                    {
                        Console.WriteLine(s);
                    }

                    //Console.WriteLine(s);
                    //Console.WriteLine(new string('-', 100));
                }
            }
        }
    }
}
