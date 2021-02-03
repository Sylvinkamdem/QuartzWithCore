using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using QuartzWithCore.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzWithCore.Service
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<MyJob> _myJobs;

        public IScheduler Scheduler { get; set; }

        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobfactory, IEnumerable<MyJob> myJobs)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobfactory;
            _myJobs = myJobs;
        }


        public async Task StartAsync(CancellationToken cancelationToken)
        {
            Common.Logs($"Start Quartz Hosted service at {DateTime.Now:dd-MM-yyyy hh:mm:ss}", $"MyJob{DateTime.Now:ddMMyyyy}");

            Scheduler = await _schedulerFactory.GetScheduler(cancelationToken);
            Scheduler.JobFactory = _jobFactory;
            foreach (var myJob in _myJobs)
            {
                var job = CreateJob(myJob);
                var trigger = CreateTrigger(myJob);
                await Scheduler.ScheduleJob(job, trigger, cancelationToken);
            }
            await Scheduler.Start(cancelationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Common.Logs($"Stop Quartz Hosted service at {DateTime.Now:dd-MM-yyyy hh:mm:ss}", $"MyJob{DateTime.Now:ddMMyyyy}");

            await Scheduler?.Shutdown(cancellationToken);
        }

        private static IJobDetail CreateJob(MyJob myJob)
        {
            var type = myJob.Type;
            return JobBuilder.Create(type).WithIdentity(type.FullName).WithDescription(type.Name).Build();
        }

        private static ITrigger CreateTrigger(MyJob myJob)
        {
            return TriggerBuilder.Create()
                .WithIdentity($"{myJob.Type.FullName}.trigger")
                .WithCronSchedule(myJob.Expression)
                .WithDescription(myJob.Expression).Build();
        }
    }
}
