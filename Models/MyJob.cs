using System;

namespace QuartzWithCore.Models
{
    public class MyJob
    {
        public MyJob(Type type, string expression)
        {
            Common.Logs($"Create {type.Name} at {DateTime.Now:dd-MM-yyyy HH:mm:ss}",$"MyJob{DateTime.Now:ddMMyyyy}");
            Type = type;
            Expression = expression;
        }
        public Type Type { get; set; }
        public string Expression { get; }
    }
}
