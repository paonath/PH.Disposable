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