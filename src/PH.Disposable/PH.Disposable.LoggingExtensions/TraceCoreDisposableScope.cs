using System.Dynamic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace PH.Disposable.LoggingExtensions
{
    public class TraceCoreDisposableScope<TState> : CoreDisposableScope<TState>
    {
        private readonly string _msg;
        private readonly ILogger _logger;


        internal TraceCoreDisposableScope([NotNull] ILogger logger, TState state) : base(logger, state)
        {
            _msg    = $"{state}";
            _logger = logger;
            logger?.LogTrace(GetBegin());
        }

        [NotNull]
        private string GetBegin() => $"----> {_msg}\t Begin Disposable Scope";
        [NotNull]
        private string GetEnd() => $"<---- {_msg}\t End Disposable Scope";

        
        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _logger?.LogTrace(GetEnd());
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <returns></returns>
        protected override async ValueTask DisposeAsync(bool disposing)
        {
            await base.DisposeAsync(disposing);
            _logger?.LogTrace(GetEnd());
        }
    }
}
