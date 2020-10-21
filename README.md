# PH.Disposable [![NuGet Badge](https://buildstats.info/nuget/PH.Disposable)](https://www.nuget.org/packages/PH.Disposable/)
c# Disposable base class



## Code Examples

**implements a CoreDisposable class**
```csharp

//install package PH.Disposable

public class MyCoreDisposable : CoreDisposable
{
    
    protected override void Dispose(bool disposing)
    {
        //implements 
    }

    protected override ValueTask DisposeAsync(bool disposing)
    {
        //implements 
    }
}
//thats all!
```

# PH.Disposable.LoggingExtensions [![NuGet Badge](https://buildstats.info/nuget/PH.Disposable.LoggingExtensions)](https://www.nuget.org/packages/PH.Disposable.LoggingExtensions/)

```csharp

//assume logger is ILogger ot ILogger<T>
var scope = logger.BeginTraceCoreScope("SCOPE");
//thats all!
```