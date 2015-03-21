using Campervibe.Data.Core;
using System;

namespace Campervibe.Data.Common
{
    public interface IContextProvider : IDisposable
    {
        Context GetContext();
        void SaveChanges();
    }
}
