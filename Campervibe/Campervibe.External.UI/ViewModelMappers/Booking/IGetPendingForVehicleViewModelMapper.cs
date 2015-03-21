using System;
using System.Collections.Generic;
using Campervibe.External.UI.ViewModels.Booking;

namespace Campervibe.External.UI.ViewModelMappers.Booking
{
    public interface IGetPendingForVehicleViewModelMapper
    {
        IList<GetPendingForVehicleViewModel> Map(Guid vehicleId);
    }
}
