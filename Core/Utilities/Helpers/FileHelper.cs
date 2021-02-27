using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                { 
                    file.CopyTo(stream); 
                }
            }
            var result = NewPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string result = $@"{Environment.CurrentDirectory + @"\Images\Cars"}\{Guid.NewGuid().ToString() + fileExtension}";
            return result;
        }
        public static string NewPath()
        {
            string result = $@"{Environment.CurrentDirectory + @"\Images\Cars"}\{"logo.png"}";
            return result;
        }
    }
}
