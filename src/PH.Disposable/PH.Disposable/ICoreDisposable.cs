using System;

namespace PH.Disposable
{
    /// <summary>
    /// Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IBaseDisposable : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        bool Disposed { get;  }

        /// <summary>Throws <see cref="ObjectDisposedException">ObjectDisposedException</see> if <see cref="Disposed">disposed</see>.</summary>
        /// <param name="message">The additional message for exception.</param>
        /// <exception cref="ObjectDisposedException">
        /// </exception>
        void ThrowIfDisposed(string message = "");
        
    }




    /// <summary>
    /// Core Disposable Interface: Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="PH.Disposable.IBaseDisposable" />
    public interface ICoreDisposable : IBaseDisposable 
    {
        
    }
    /// <summary>
    /// Core Disposable Async Interface: Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="PH.Disposable.IBaseDisposable" />
    /// <seealso cref="System.IAsyncDisposable" />
    public interface ICoreAsyncDisposable : IBaseDisposable, IAsyncDisposable
    {

    }
}
