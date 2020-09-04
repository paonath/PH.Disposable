using System;

namespace PH.Disposable
{
    /// <summary>
    /// Core Disposable Interface: Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="CoreDisposable"/>
    /// <seealso cref="CoreUnmanagedDisposable"/>
    public interface ICoreDisposable : IDisposable
    {
        bool Disposed { get;  }

    }
}
