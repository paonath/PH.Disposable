using System;

namespace PH.Disposable
{
    /// <summary>
    /// Core Disposable Abstract class: Provides a mechanism for releasing unmanaged resources.
    /// </summary>
    /// <seealso cref="PH.Disposable.ICoreDisposable" />
    public abstract class CoreDisposable : ICoreDisposable
    {
        protected CoreDisposable()
        {
            Disposed = false;
            
        }

        

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            InternalDispose(true);
        }

        internal virtual void InternalDispose(bool disposing)
        {
            if (!Disposed)
            {
                Dispose(disposing);
                Disposed = true;
            }
            
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            
        }

        ~CoreDisposable()
        {
            InternalDispose(false);
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CoreDisposable"/> is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        public bool Disposed { get; protected set; }

        /// <summary>Initializes the scope.</summary>
        /// <returns></returns>
        public static DisposableScope InitScope() => new DisposableScope();

        public static DisposableScope InitScope(Action disposeAction)
            => new DisposableScope(disposeAction);  
        
        public static DisposableScope InitScope(string name)
            => new DisposableScope(name);

        public static DisposableScope InitScope(string name,Action disposeAction)
            => new DisposableScope(name,disposeAction);





        /// <summary>Initializes the named scope.</summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static DisposableScope InitNamedScope(string name) => new DisposableScope(name);
    }
}