using System;
using System.Threading.Tasks;
using PH.Disposable;

namespace PH.DisposableXUnitTest
{
    public class TestCoreDisposable : CoreDisposable
    {
        public DateTime Init { get; }
        public TestCoreDisposable()
        {
            Init = DateTime.UtcNow;
            
        }

        protected override void Dispose(bool disposing)
        {
            //
        }

        protected override ValueTask DisposeAsync(bool disposing)
        {
            //
            return new ValueTask(Task.CompletedTask);
        }
    }
}