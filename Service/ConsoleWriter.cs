using Quartz;
using QuartzWithCore.Models;
using System;
using System.Threading.Tasks;

namespace QuartzWithCore.Service
{
    public class ConsoleWriter : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Common.Logs($"\t-ConsoleWriter Running at{DateTime.Now:dd-MM-yyyy hh:mm:ss}", $"ConsoleWriter{DateTime.Now:ddMMyyyy}");
            return Task.CompletedTask;
        }
    }
}
