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

        /// <summary>Initializes the named scope.</summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static DisposableScope InitNamedScope(string name) => new DisposableScope(name);
    }

    public class DisposableScope : CoreDisposable
    {
        public DisposableScope():this(string.Empty)
        {
            
        }
        public DisposableScope(string name)
        {
            Name = name;
        }

        public string Name { get; }


        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            
            GC.Collect();
        }

        /// <summary>Releases resources performing provided <see cref="preDisposeAction">action</see></summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <param name="preDisposeAction">The pre dispose action.</param>
        public void Dispose(bool disposing, Action preDisposeAction)
        {
            GC.Collect();
            try
            {
                
                preDisposeAction.Invoke();
            }
            finally
            {
                base.InternalDispose(disposing);
                
            }
            

        }
    }
}