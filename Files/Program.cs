namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\юзер\Downloads";
            
            string[] files = Directory.GetFiles(path);
            List<string> allExtentions = new List<string>();
            foreach (string file in files)
            {
                string extention = Path.GetExtension(file);

                allExtentions.Add(extention);

            }
            CreateFolders(allExtentions, path);

            foreach (string file in files) 
            {
                MoveToDirectories(file, path);
            }
            Console.WriteLine("All files moved");
            Console.ReadKey();
        }


        public static void CreateFolders(List<string> exsts, string path)
        {
            List<string> uniqExsts = exsts.Distinct().ToList();
            foreach (string exs in uniqExsts) {
                string newPath = Path.Combine(path, exs);
                Directory.CreateDirectory(newPath);
                Console.WriteLine($"Directory created at path: {newPath}");
            }
            Console.WriteLine("Created folders");
            
        }

        public static void MoveToDirectories(string file, string path)
        {
            string extention = Path.GetExtension(file);
            string fileName = Path.GetFileName(file);
            string[] param = {path, extention, fileName};
            string newPath = Path.Combine(param);
            File.Move(file, newPath);
        }
    }
}
