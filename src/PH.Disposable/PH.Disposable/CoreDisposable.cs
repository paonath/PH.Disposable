using System;
using System.Threading.Tasks;

namespace PH.Disposable
{

    /// <summary>
    /// Core Disposable abstact class: Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="PH.Disposable.ICoreDisposable" />
    public abstract class CoreBaseDisposable : ICoreDisposable
    {
        protected CoreBaseDisposable()
        {
            Disposed = false;
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="ICoreDisposable"/> is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        public bool Disposed { get; protected set; }

        /// <summary>Throws <see cref="ObjectDisposedException">ObjectDisposedException</see> if <see cref="Disposed">disposed</see>.</summary>
        /// <param name="message">The additional message for exception.</param>
        /// <exception cref="ObjectDisposedException">
        /// </exception>
        public void ThrowIfDisposed(string message = "")
        {
            if (Disposed)
            {
                var    name = GetType().Name;

                if (!string.IsNullOrEmpty(message))
                {
                    throw new ObjectDisposedException(name,message);
                }
                else
                {
                    throw new ObjectDisposedException(name);
                }
                
            }
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);
        
        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            Disposed = true;
            GC.SuppressFinalize(this);
        }

        
    }

    public abstract class CoreDisposable : CoreBaseDisposable, ICoreAsyncDisposable
    {
        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <returns></returns>
        protected abstract ValueTask DisposeAsync(bool disposing);

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            Disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}