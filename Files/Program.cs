namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\юзер\Downloads";
            string logsPath = Path.Combine(path, "log");
            string pathToLogFile = Path.Combine(logsPath, "logs.txt");
            string[] files = Directory.GetFiles(path);
            List<string> allExtentions = new List<string>();


            if (!Directory.Exists(logsPath)) 
            {
                Directory.CreateDirectory(logsPath);
                File.Create(pathToLogFile).Close();
                File.WriteAllText(pathToLogFile, "Логи для приложения \n");
            }

            File.AppendAllText(pathToLogFile, $"Дата сканирования и перемещения файлов {DateTime.Now.ToString()} \n");
            
            
            foreach (string file in files)
            {
                string extention = Path.GetExtension(file);

                allExtentions.Add(extention);

            }
            CreateFolders(allExtentions, path, pathToLogFile);
            File.AppendAllText(pathToLogFile, "Пермещение файлов: \n");
            foreach (string file in files) 
            {
                MoveToDirectories(file, path, pathToLogFile);
            }
            Console.ReadKey();
        }


        public static void CreateFolders(List<string> exsts, string path, string loggerPath)
        {
            List<string> uniqExsts = exsts.Distinct().ToList();
            File.AppendAllText(loggerPath, "Созданные папки: \n");
            foreach (string exs in uniqExsts) {
                string newPath = Path.Combine(path, exs);
                Directory.CreateDirectory(newPath);
                File.AppendAllText(loggerPath, $"{newPath} \n");
            }
           
            
        }

        public static void MoveToDirectories(string file, string path, string loggerPath)
        {
            string extention = Path.GetExtension(file);
            string fileName = Path.GetFileName(file);
            string[] param = {path, extention, fileName};
            string newPath = Path.Combine(param);
            File.Move(file, newPath, true);
            File.AppendAllText(loggerPath, $"Файл {file} пермещен в папку {newPath} \n");
        }
    }
}
