using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace PH.Disposable.LoggingExtensions
{
    public class CoreDisposableScope<TState> : CoreDisposable
    {
        private IDisposable _scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreDisposableScope{TState}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="state">The state.</param>
        internal CoreDisposableScope([NotNull] ILogger logger, TState state)
        {
            _scope = logger?.BeginScope(state);
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _scope?.Dispose();
            //
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <returns></returns>
        protected override ValueTask DisposeAsync(bool disposing)
        {
            _scope?.Dispose();
            return new ValueTask(Task.CompletedTask);
        }
    }
}