using System;

namespace Jaguar.Data
{
    public abstract class DbConnection : IDisposable
    {
        public abstract void Dispose();
    }
}
