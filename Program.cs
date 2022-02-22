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
                    TimeSpan timeDifference = DateTime.Now - dir.LastWriteTime;
                    if (timeDifference > TimeSpan.FromMinutes(30))
                    {
                        try
                        {
                            Console.WriteLine("Подкаталог:");
                            Console.WriteLine(dir.FullName);
                            Console.WriteLine("Время в течении которого каталог не использовался {0:f0} минут.",
                                              timeDifference.TotalMinutes);
                            dir.Delete(true);
                            Console.WriteLine($"Подкаталог удален...{Environment.NewLine}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Ошибка: {e.Message}{Environment.NewLine}");
                        }
                        continue;
                    }
                }

                Console.WriteLine();
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    TimeSpan timeDifference = DateTime.Now - file.LastWriteTime;
                    if (timeDifference > TimeSpan.FromMinutes(30))
                    {
                        try
                        {
                            Console.WriteLine("Файл:");
                            Console.WriteLine(file.FullName);
                            Console.WriteLine("Время в течении которого файл не использовался {0:f0} минут.",
                                              timeDifference.TotalMinutes);
                            file.Delete();
                            Console.WriteLine($"Файл удален...{Environment.NewLine}");
                        }
                        catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}{Environment.NewLine}"); }
                        continue;
                    }
                }
            }
            Console.WriteLine($"{Environment.NewLine}Все доступные файлы и подкаталоги, не используемые в течении 30 минут," +
                              $" удалены из каталога \"TEMP\"...");

            Console.ReadKey();            
        }
    }
}
