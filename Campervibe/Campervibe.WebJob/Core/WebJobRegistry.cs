using Campervibe.WebJob.Common;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Conventions;

namespace Campervibe.WebJob.Core
{
    public class WebJobRegistry
    {
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind(c =>
            c.FromThisAssembly()
                .SelectAllClasses().InheritedFrom<IJob>()
                .BindAllInterfaces());
        }
    }
}
