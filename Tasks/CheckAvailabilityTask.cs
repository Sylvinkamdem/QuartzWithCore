using System.Diagnostics;
using System.Threading.Tasks;
using Quartz;

namespace QuartzWithCore.Tasks
{
    public class CheckAvailabilityTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Debug.WriteLine("Tickets to the concert ar available");
            }
            catch (System.Exception ex)
            {
                
                System.Console.WriteLine( ex.Message);
            }
            return Task.FromResult(0);
        }
    }
}