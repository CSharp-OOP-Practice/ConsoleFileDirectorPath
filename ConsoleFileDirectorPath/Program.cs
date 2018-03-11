using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleFileDirectorPath
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileExample();
            //DirectoryExample();
            //PathExample();

            RayExample();
        }

        /// <summary>
        /// 確認Z槽照片檔名不重複
        /// </summary>
        private static void RayExample()
        {
            var files = Directory.GetFiles(@"Z:\Desktop\run3 (41)", "*.JPG", SearchOption.TopDirectoryOnly);
            var data = new List<string>();
            foreach (var file in files)
            {
                var texts = Path.GetFileNameWithoutExtension(file).Split('-', '_');
                data.Add(texts[1]);
            }

            CheakNumberRepeat(data);
        }

        /// <summary>
        /// 絕對路徑的操作
        /// </summary>
        private static void PathExample()
        {
            var path = @"E:\C#\ConsoleFileDirectorPath\ConsoleFileDirectorPath.sln";
            //取得副檔名
            Console.WriteLine("Extension: " + Path.GetExtension(path));
            //取得檔名+副檔名
            Console.WriteLine("File name: " + Path.GetFileName(path));
            //取得檔名
            Console.WriteLine("File name without extension: " + Path.GetFileNameWithoutExtension(path));
            //取得目錄名稱
            Console.WriteLine("Directory name: " + Path.GetDirectoryName(path));
        }

        /// <summary>
        /// 目錄操作範例
        /// </summary>
        private static void DirectoryExample()
        {
            Directory.CreateDirectory(@"C:\Users\Administrator\Desktop\Example");

            GetFilePath();

            //取得路徑
            var directories = Directory.GetDirectories(@"Z:\Desktop\", "*.*", SearchOption.AllDirectories);
            foreach (var directory in directories)
                Console.WriteLine(directory);

            Directory.Exists("...");

            var directoryInfo = new DirectoryInfo(@"C:\Users\Administrator\Desktop\Example");
            directoryInfo.GetFiles();
            directoryInfo.GetDirectories();
        }

        private static void GetFilePath()
        {
            //取得路徑+檔名
            var files = Directory.GetFiles(@"Z:\Desktop\run3 (41)", "*.jpg", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
                Console.WriteLine(file);
        }

        /// <summary>
        /// File 範例：Delete 檔案是永遠刪除
        /// </summary>
        private static void FileExample()
        {
            var path = @"C:\Users\Administrator\Desktop\新文字文件.txt";

            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                //檢查檔案數字是否重複
                //CheakNumberRepeat(content.Split(','));

                //File.Copy(path, @"C:\Users\Administrator\Desktop\新文字文件2.txt", true);
                //File.Delete(path);
            }

            var fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(@"C:\Users\Administrator\Desktop\新文字文件2.txt");
                fileInfo.Delete();
                
            }
            
        }

        /// <summary>
        /// 檢查字串數字是否重複
        /// </summary>
        /// <param name="data">字串數字</param>
        private static void CheakNumberRepeat(string[] data)
        {
            var numbers = new List<int>();
            foreach (var number in data)
            {
                if (numbers.Contains(Convert.ToInt32(number)))
                {
                    Console.WriteLine("Stop! Number repeat: " + number);
                    return;
                }
                else
                    Console.WriteLine("Number unique: " + number);
            }
        }

        private static void CheakNumberRepeat(List<string> data)
        {
            var numbers = new List<int>();
            foreach (var number in data)
            {
                if (numbers.Contains(Convert.ToInt32(number)))
                {
                    Console.WriteLine("Stop! Number repeat: " + number);
                    return;
                }
                else
                    Console.WriteLine("Number unique: " + number);
            }
        }
    }
}
