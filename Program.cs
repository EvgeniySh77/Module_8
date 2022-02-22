using System;
using System.IO;

namespace Module_8
{
    class FoldersAndFiles  
    {
        static void Main()
        {
            string path = @"c:\Temp\";
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
                Console.WriteLine($"По данному адресу {path}, папка {directory.Name} не существует .");
            else
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    try
                    {
                        Console.WriteLine("Подкаталог:");
                        Console.WriteLine(dir.FullName);
                        dir.Delete(true);
                        Console.WriteLine($"Подкаталог удален...{Environment.NewLine}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка: {0}", e.Message);
                    }
                    continue;
                }

                Console.WriteLine();
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    try
                    {
                        Console.WriteLine("Файл:");
                        Console.WriteLine(file.FullName);
                        file.Delete();
                        Console.WriteLine($"Файл удален...{Environment.NewLine}");
                    }
                    catch (Exception e) { Console.WriteLine("Ошибка: {0}", e.Message); }
                    continue;
                }
            }
            Console.WriteLine($"{Environment.NewLine}Все доступные файлы и подкаталоги удалены из каталога \"TEMP\"...");

            Console.ReadKey();            
        }
    }
}
