using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace PH.Disposable.LoggingExtensions
{
    public static class Extension
    {
        /// <summary>Begins a logical operation <see cref="CoreDisposableScope{TState}">scope</see> .</summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="logger">The logger.</param>
        /// <param name="state">The state.</param>
        /// <returns>An <see cref="ICoreAsyncDisposable">IDisposable</see>  that ends the logical operation scope on dispose.</returns>
        public static ICoreAsyncDisposable BeginCoreScope<TState>([NotNull] this ILogger logger, TState state)
        {
            return new CoreDisposableScope<TState>(logger, state);
        }

        /// <summary>Begins a logical operation <see cref="CoreDisposableScope{TState}">scope</see> that write a LogTrace with begin and end of current scope .</summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="logger">The logger.</param>
        /// <param name="state">The state.</param>
        /// <returns>An <see cref="ICoreAsyncDisposable">IDisposable</see>  that ends the logical operation scope on dispose.</returns>
        public static ICoreAsyncDisposable BeginTraceCoreScope<TState>([NotNull] this ILogger logger, TState state)
        {
            return new TraceCoreDisposableScope<TState>(logger, state);
        }
    }
}