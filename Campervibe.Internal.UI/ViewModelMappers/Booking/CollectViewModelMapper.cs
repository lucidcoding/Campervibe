﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Campervibe.Internal.UI.ViewModels.Booking;
using Campervibe.Domain.Requests;
using Campervibe.Internal.UI.Security;
using Campervibe.Domain.RepositoryContracts;

namespace Campervibe.Internal.UI.ViewModelMappers.Booking
{
    public class CollectViewModelMapper : ICollectViewModelMapper
    {
        private IUserRepository _userRepository;
        private IUserProvider _userProvider;

        public CollectViewModelMapper(
            IUserRepository userRepository,
            IUserProvider userProvider)
        {
            _userRepository = userRepository;
            _userProvider = userProvider;
        }

        public CollectViewModel New()
        {
            var viewModel = new CollectViewModel();
            return viewModel;
        }

        public CollectBookingRequest Map(CollectViewModel viewModel)
        {
            var request = new CollectBookingRequest();
            request.Mileage = viewModel.Mileage;
            var username = _userProvider.GetUsername();
            request.LoggedBy = _userRepository.GetByUsername(username);
            return request;
        }
    }
}