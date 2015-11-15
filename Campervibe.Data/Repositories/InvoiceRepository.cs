using Campervibe.Data.Common;
using Campervibe.Domain.Entities;
using Campervibe.Domain.RepositoryContracts;
using System;

namespace Campervibe.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice, Guid>, IInvoiceRepository
    {
        public InvoiceRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
