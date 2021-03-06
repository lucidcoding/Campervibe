﻿using Campervibe.Domain.Common;
using Campervibe.Domain.Entities;
using System;

namespace Campervibe.Domain.RepositoryContracts
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
    }
}
