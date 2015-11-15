using Campervibe.Data.Core;

namespace Campervibe.Data.Common
{
    public class StubContextProvider : IContextProvider
    {
        public Context GetContext()
        {
            return null;
        }

        public void Dispose()
        {
        }

        public void SaveChanges()
        {
        }
    }
}
