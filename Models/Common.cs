using System.IO;

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
            
            Restart:
            try
            {
                using FileStream stream = new FileStream(path, FileMode.Append);
                using TextWriter tw = new StreamWriter(stream);
                tw.WriteLine(message);
                tw.Close();
                stream.Close();
            }
            catch (System.Exception)
            {

                goto Restart;
            }
        }
    }
}
