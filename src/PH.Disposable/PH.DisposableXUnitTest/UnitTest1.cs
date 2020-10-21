using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PH.Disposable;
using PH.Disposable.LoggingExtensions;
using Xunit;

namespace PH.DisposableXUnitTest
{
    public class LoggingExtensionsTest
    {
        [Fact]
        public void TestLogScope()
        {
            LoggerFactory factory = new LoggerFactory();
            var logger = factory.CreateLogger("fake logger");
            

            var       scope      = logger.BeginCoreScope("SCOPE");
            var       isDisposed = scope.Disposed;
            Exception e0         = null;
            try
            {
                scope.ThrowIfDisposed();
            }
            catch (Exception e)
            {
                e0 = e;
            }
            scope.Dispose();

            Exception e1 = null;
            try
            {
                scope.ThrowIfDisposed();
            }
            catch (ObjectDisposedException e)
            {
                e1 = e;
            }

            Assert.NotNull(scope);
            Assert.False(isDisposed);
            Assert.True(scope.Disposed);
            Assert.Null(e0);
            Assert.NotNull(e1);

        }
        [Fact]
        public void TestTypedLogScope()
        {
            LoggerFactory factory = new LoggerFactory();
            var           logger  = factory.CreateLogger<LoggingExtensionsTest>();
            

            var       scope      = logger.BeginCoreScope("SCOPE");
            var       isDisposed = scope.Disposed;
            Exception e0         = null;
            try
            {
                scope.ThrowIfDisposed();
            }
            catch (Exception e)
            {
                e0 = e;
            }
            scope.Dispose();

            Exception e1 = null;
            try
            {
                scope.ThrowIfDisposed();
            }
            catch (ObjectDisposedException e)
            {
                e1 = e;
            }

            Assert.NotNull(scope);
            Assert.False(isDisposed);
            Assert.True(scope.Disposed);
            Assert.Null(e0);
            Assert.NotNull(e1);

        }
        [Fact]
        public async void TestTypedLogScopeAsync()
        {
            LoggerFactory factory = new LoggerFactory();
            var           logger  = factory.CreateLogger<LoggingExtensionsTest>();
            

            var       scope      = logger.BeginTraceCoreScope("SCOPE");
            var       isDisposed = scope.Disposed;
            Exception e0         = null;
            try
            {
                scope.ThrowIfDisposed();
            }
            catch (Exception e)
            {
                e0 = e;
            }

            await scope.DisposeAsync();


            Exception e1 = null;
            try
            {
                scope.ThrowIfDisposed();
            }
            catch (ObjectDisposedException e)
            {
                e1 = e;
            }


            var sync = logger.BeginTraceCoreScope("sync scope");
            sync.Dispose();

            Assert.True(sync.Disposed);
            Assert.NotNull(scope);
            Assert.False(isDisposed);
            Assert.True(scope.Disposed);
            Assert.Null(e0);
            Assert.NotNull(e1);

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
        public async ValueTask TestAsync()
        {
            var instance  = new TestCoreDisposable();
            var disposed1 = instance.Disposed;
            await  instance.DisposeAsync();
            
            Assert.False(disposed1);
            Assert.True(instance.Disposed);
        }

        [Fact]
        public void TestException()
        {
            var       instance = new TestCoreDisposable();
            Exception nullExc  = null;
            try
            {
                instance.ThrowIfDisposed("a test method");

            }
            catch (Exception e)
            {
                nullExc = e;
            }

            instance.Dispose();
            Exception exc0 = null;
            Exception exc1 = null;
            try
            {
                instance.ThrowIfDisposed("a test method");
            }
            catch (Exception e)
            {
                exc0 = e;
            }
            try
            {
                instance.ThrowIfDisposed();
            }
            catch (Exception e2)
            {
                exc1 = e2;
            }

            Assert.Null(nullExc);
            Assert.NotNull(exc0);
            Assert.NotNull(exc1);
            Assert.True(exc0 is ObjectDisposedException);
            Assert.True(exc1 is ObjectDisposedException);
        }
        

    }
}
