using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzWithCore.Models
{
    public static class Common
    {
        public static void Logs(string message, string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MyLogs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, fileName);
            using FileStream stream = new FileStream(path, FileMode.Create);
            using TextWriter tw = new StreamWriter(stream);
            tw.WriteLine(message);
        }
    }
}
