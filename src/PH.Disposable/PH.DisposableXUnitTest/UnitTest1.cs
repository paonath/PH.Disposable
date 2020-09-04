using System;
using PH.Disposable;
using Xunit;

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


    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var instance  = new TestCoreDisposable();
            var disposed1 = instance.Disposed;
            instance.Dispose();
            
            Assert.False(disposed1);
            Assert.True(instance.Disposed);
        }

        [Fact]
        public void TestScope()
        {
            var  scope               = CoreDisposable.InitNamedScope("test");
           
            bool               notDisposedInstance = true;

            using (scope)
            {
                var  instance            = new TestCoreDisposable();
                notDisposedInstance = instance.Disposed;

            }

            using (var sc = CoreDisposable.InitScope())
            {
                using (var inst = new TestCoreDisposable())
                {
                    
                }
            }

            
            Assert.Equal("test", scope.Name);
            Assert.True(scope.Disposed);
            Assert.False(notDisposedInstance);

        }

    }
}
