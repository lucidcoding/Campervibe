using Campervibe.WebJob.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campervibe.WebJob
{
    public class TestJob : IJob
    {
        public void Run()
        {
            Console.WriteLine("This is from test job");
        }
    }
}
