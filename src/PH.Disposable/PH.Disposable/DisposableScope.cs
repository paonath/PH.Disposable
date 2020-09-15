using System;
using JetBrains.Annotations;

namespace PH.Disposable
{
    public class DisposableScope : CoreDisposable
    {
        private Action _disposeAction;
        internal DisposableScope([CanBeNull] Action disposeAction = null)
            :this(string.Empty, disposeAction)
        {
            
        }

        public void SetDisposeAction(Action actionToPerformOnDispose)
        {
            _disposeAction = actionToPerformOnDispose;
        }

        internal DisposableScope(string name, [CanBeNull] Action disposeAction = null)
        {
            Name = name;
            SetDisposeAction(disposeAction);
        }

        public string Name { get; }


        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected sealed override void Dispose(bool disposing)
        {
            
            GC.Collect();
            if (null != _disposeAction)
            {
                try
                {
                    _disposeAction();
                }
                catch
                {
                    //
                }
                finally{}
            }

        }

        
    }
}