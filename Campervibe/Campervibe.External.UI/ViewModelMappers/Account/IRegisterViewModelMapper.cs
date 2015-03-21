using System;
using Campervibe.Domain.Requests;
using Campervibe.External.UI.ViewModels.Account;

namespace Campervibe.External.UI.ViewModelMappers.Account
{
    public interface IRegisterViewModelMapper
    {
        RegisterCustomerRequest Map(RegisterViewModel viewModel);
    }
}
