using System;
using Campervibe.External.UI.ViewModels.Booking;
using Campervibe.Domain.Requests;

namespace Campervibe.External.UI.ViewModelMappers.Booking
{
    public interface IMakeViewModelMapper
    {
        void Hydrate(MakeViewModel viewModel);
        MakeViewModel New();
        MakeBookingRequest Map(MakeViewModel viewModel);
    }
}
