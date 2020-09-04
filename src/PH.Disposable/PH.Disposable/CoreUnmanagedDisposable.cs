using System;

namespace PH.Disposable
{
    /// <summary>
    ///  Core Disposable Abstract class with Unmanaged resources : Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="PH.Disposable.CoreDisposable" />
    public abstract class CoreUnmanagedDisposable : CoreDisposable
    {
        protected abstract void ReleaseUnmanagedResources();

        

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        internal override void InternalDispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            Dispose(disposing);
            Disposed = true;
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            
        }

        /// <summary>Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.</summary>
        ~CoreUnmanagedDisposable()
        {
            
            InternalDispose(false);
        }
    }
}