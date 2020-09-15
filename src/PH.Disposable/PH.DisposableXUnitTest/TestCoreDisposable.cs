using PH.Disposable;

namespace PH.DisposableXUnitTest
{
    public class TestCoreDisposable : CoreDisposable
    {
        public bool CalledDispose { get; set; }
        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            //
            CalledDispose = true;
        }
    }
}