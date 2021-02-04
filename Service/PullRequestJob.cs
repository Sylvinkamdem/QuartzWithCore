using Microsoft.Extensions.Configuration;
using Quartz;
using QuartzWithCore.Models;
using System;
using System.Threading.Tasks;

namespace QuartzWithCore.Service
{
    public class PullRequestJob : IJob
    {
        private readonly IConfiguration _confign;

        public PullRequestJob(IConfiguration configuration)
        {
            _confign = configuration;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Common.Logs($"\t-Yet Annother Job to Execute Accessing AppSettings : PcSylvin={_confign.GetConnectionString("OtherConString")}", $"PullRequestJob{DateTime.Now:ddMMyyyy}");
            return Task.CompletedTask;
        }
    }
}
