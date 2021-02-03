using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzWithCore.Models
{
    public class MyJob
    {
        public MyJob(Type type, string expression)
        {
            Common.Logs($"MyJob at {DateTime.Now:dd-MM-yyyy HH:mm:ss}",$"MyJob{DateTime.Now:hhmmss}");
            Type = type;
            Expression = expression;
        }
        public Type Type { get; set; }
        public string Expression { get; }
    }
}
