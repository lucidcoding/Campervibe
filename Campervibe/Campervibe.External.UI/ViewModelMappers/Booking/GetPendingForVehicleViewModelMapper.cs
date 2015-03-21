using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Campervibe.Domain.RepositoryContracts;
using Campervibe.External.UI.ViewModels.Booking;

namespace Campervibe.External.UI.ViewModelMappers.Booking
{
    public class GetPendingForVehicleViewModelMapper : IGetPendingForVehicleViewModelMapper
    {
        public IBookingRepository _bookingRepository;

        public GetPendingForVehicleViewModelMapper(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IList<GetPendingForVehicleViewModel> Map(Guid vehicleId)
        {
            var bookings = _bookingRepository.GetPendingForVehicle(vehicleId);

            var viewModel = bookings.Select(booking => new GetPendingForVehicleViewModel()
                {
                    VehicleId = vehicleId,
                    BookingNumber = booking.BookingNumber,
                    CustomerName = booking.Customer.FamilyName + ", " + booking.Customer.GivenName,
                    StartDate = booking.StartDate,
                    EndDate = booking.EndDate
                }).ToList();

            return viewModel;
        }
    }
}