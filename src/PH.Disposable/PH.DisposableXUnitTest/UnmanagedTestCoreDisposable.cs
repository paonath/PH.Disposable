namespace PH.DisposableXUnitTest
{
    public class UnmanagedTestCoreDisposable : PH.Disposable.CoreUnmanagedDisposable
    {
        private readonly TestCoreDisposable _coreDisposable;

        public UnmanagedTestCoreDisposable()
        {
            _coreDisposable = new TestCoreDisposable();
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            //throw new NotImplementedException();
        }

        protected override void ReleaseUnmanagedResources()
        {
            _coreDisposable.Dispose();
        }
    }
}