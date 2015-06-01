using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campervibe.External.UI.ServiceProxies.Vehicle
{
    public interface IVehicleServiceProxy
    {
        IList<VehicleServiceModel> GetAll();
    }
}
