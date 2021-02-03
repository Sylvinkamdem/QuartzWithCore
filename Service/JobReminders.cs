using Quartz;
using QuartzWithCore.Models;
using System;
using System.Threading.Tasks;

namespace QuartzWithCore.Service
{
    public class JobReminders :IJob
    {
        public JobReminders()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {
            Common.Logs($"\t-My Job running at {DateTime.Now:dd-MM-yyyy HH:mm:ss}; Context:{context.JobDetail.JobType.FullName}", $"JobReminders{DateTime.Now:ddMMyyyy}");
            return Task.CompletedTask;

        }
    }
}
