using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Campervibe.WebJob.Common;
using Ninject;
using Campervibe.WebJob.Core;

namespace Campervibe.WebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    public class Program
    {
        public static IKernel Kernel { get; set; }

        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            Kernel = new StandardKernel();
            new WebJobRegistry().RegisterServices(Kernel);

            //var config = new JobHostConfiguration
            //{
            //    TypeLocator = new CustomTypeLocator()
            //    //JobActivator = new MyActivator(myContainer)
            //};
            //var host = new JobHost(config);

            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            Console.WriteLine("starting...");
            host.Call(typeof(Program).GetMethod("RunOnce"));

            //host.RunAndBlock();
        }

        [NoAutomaticTrigger]
        public static void RunOnce()
        {
            Kernel.GetAll<IJob>().ToList().ForEach(job => job.Run());
        }
    }
}
