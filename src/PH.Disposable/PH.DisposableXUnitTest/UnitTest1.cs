using System;
using PH.Disposable;
using Xunit;

namespace PH.DisposableXUnitTest
{
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

            bool calledDisposeAction = false;
            using (var sc = CoreDisposable.InitScope())
            {
                

                sc.SetDisposeAction(() => calledDisposeAction = MethodToTestVoid());

                using (var inst = new TestCoreDisposable())
                {
                    
                }
            }

            Exception ex                  = null;
            bool      calledDisposeAction2 = false;
            try
            {
                var c = CoreDisposable.InitScope(() => calledDisposeAction2 = MethodToTestVoidThrow());
                c.Dispose();

            }
            catch (Exception e)
            {
                ex = e;
            }


            Assert.Equal("test", scope.Name);
            Assert.True(scope.Disposed);
            Assert.False(notDisposedInstance);
            Assert.True(calledDisposeAction);
            Assert.False(calledDisposeAction2);
            Assert.Null(ex);
        }

        [Fact]
        public void TestDispose()
        {
            MethodWithDisposable();

        }

        [Fact]
        public void UnamangedDispose()
        {
            bool disposeInternal = false;
            using (var res = new UnmanagedTestCoreDisposable())
            {
                disposeInternal = res.Disposed;
            }
            
            Assert.False(disposeInternal);
        }

        private void MethodWithDisposable()
        {
            var d = new TestCoreDisposable();
            var m = new UnmanagedTestCoreDisposable();
            var b = d.Disposed;


        }



        public bool MethodToTestVoid()
        {
            //do noting
            return true;
        }
        public bool MethodToTestVoidThrow()
        {
            //do noting
            throw new Exception();
        }
    }
}
