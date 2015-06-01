using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Campervibe.External.UI.ViewModels.Booking;
using Campervibe.Domain.RepositoryContracts;
using System.Web.Mvc;
using Campervibe.Domain.Requests;
using Campervibe.External.UI.Security;
using Campervibe.External.UI.Extensions;
using Campervibe.External.UI.ServiceProxies.Vehicle;

namespace Campervibe.External.UI.ViewModelMappers.Booking
{
    public class MakeViewModelMapper : IMakeViewModelMapper
    {
        //private IVehicleRepository _vehicleRepository;
        private IVehicleServiceProxy _vehicleServiceProxy;
        private ICustomerRepository _customerRepository;
        private IUserProvider _userProvider;
        private IGetPendingForVehicleViewModelMapper _getPendingForVehicleViewModelMapper;

        public MakeViewModelMapper(
            //IVehicleRepository vehicleRepository,
            IVehicleServiceProxy vehicleServiceProxy,
            ICustomerRepository customerRepository,
            IUserProvider userProvider,
            IGetPendingForVehicleViewModelMapper getPendingForVehicleViewModelMapper)
        {
            //_vehicleRepository = vehicleRepository;
            _vehicleServiceProxy = vehicleServiceProxy;
            _customerRepository = customerRepository;
            _userProvider = userProvider;
            _getPendingForVehicleViewModelMapper = getPendingForVehicleViewModelMapper;
        }

        public MakeViewModel New()
        {
            var viewModel = new MakeViewModel();
            viewModel.StartDate = DateTime.Now;
            viewModel.EndDate = DateTime.Now;
            Hydrate(viewModel);
            return viewModel;
        }

        public void Hydrate(MakeViewModel viewModel)
        {
            var vehicles = _vehicleServiceProxy.GetAll();

            viewModel.VehicleOptions = new SelectList(
                vehicles.Select(vehicle => new SelectListItem
                {
                    Text = vehicle.Name,
                    Value = vehicle.Id.ToString()
                }), "Value", "Text")
                .AddDefaultOption();

            if (viewModel.VehicleId.HasValue)
            {
                viewModel.PendingBookings = _getPendingForVehicleViewModelMapper.Map(viewModel.VehicleId.Value);
            }
            else
            {
                viewModel.PendingBookings = new List<GetPendingForVehicleViewModel>();
            }
        }

        public MakeBookingRequest Map(MakeViewModel viewModel)
        {
            var request = new MakeBookingRequest();
            request.StartDate = viewModel.StartDate;
            request.EndDate = viewModel.EndDate;
            //request.Vehicle = viewModel.VehicleId.HasValue ? _vehicleRepository.GetById(viewModel.VehicleId.Value) : null;
            var username = _userProvider.GetUsername();
            request.Customer = _customerRepository.GetByUsername(username);
            return request;
        }
    }
}