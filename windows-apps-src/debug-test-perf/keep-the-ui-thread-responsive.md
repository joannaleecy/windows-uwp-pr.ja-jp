---
xx.xxxxxxx: XXYYYYYX-XXYY-YXXX-YYYY-YXXYXXXYYYYY
xxxxx: Xxxx xxx XX xxxxxx xxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxxxxx xx xxx xx xxxxxx xxxxxxxxxx xxxxx xx xxxx xxxxxxxxxxx, xxxxxxxxxx xx xxx xxxx xx xxxxxxx.
---
# Xxxx xxx XX xxxxxx xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxxxxx xx xxx xx xxxxxx xxxxxxxxxx xxxxx xx xxxx xxxxxxxxxxx, xxxxxxxxxx xx xxx xxxx xx xxxxxxx. Xxxx xxxxx xxxxxxxxx xxxxxx xxx xxxxxxxxx xxxx. Xxx xxxx, xxxx xxxxxxxxxx xx xxxxxxxxx xxxx xxxxxxxxx xxxxxxx, xxxxxxx xxxx xxxx xxxx xx xxx xxx xxxxxx, xxxxxxx xxxxxxxxxx xxxxxxx xxxxxx xxx xxxxxxxxxx xxxxxxx xxxxx, xxxxxxx xxxxxxxxxx xx x xxxx, xx xxxxxxx xxxxxxxxxx xxxx. Xxxxxxxxxx xx xxx xxxx xx xxxxxxxxxxx, xxxxx xxxx xxxxx xxx xx xxx xx xxxxx xxxxx xxx xxxxxxxxx xxxxxxxxx xxxxx xx xxxxxxx xxxxxxxxxxxx xxxxx xx "xxxxxx".

Xxxx xxx xx xxxxx-xxxxxx, xxxxx xxxxx xxxx xxxx xxxx xxxxxxxx xxxx xx xxxxxxxx xx xx xxxxx xxx xxxx xx xxxx xxxx xxxxx xxx xxxx. Xxxxxxxx xxxx xxx XX (xxxxxx, xxxxx, xxxxxxx xxxxxx, xxx.) xxx xxxx xxx’x xxxx xxx XX xxx xxx xxxxxxxx xx xxx xxxx XX xxxxxx. Xxxx xxx xxxxxxxxxxx xxx xxxxxxx xx xxxx xxxxxx xx x xxxx xx xx xxxx xxx xxxx xxxxx xxx xxxx xx xxxxxxx xx xxxxx xxxx xxx xxxxxxxxx xxx’x xxx xxxxxx xx xxxxx xxx xxxxxx xxxxxxxxxxxx xxxx xxxxxxxxxxx. Xxx xxxxxxxxxxxxxx xx xxxx xxx xx xxxxxxx xx xxx xxxxxxxxxxxx xx xxx XX xxxxxx xx xxxxxxx xxxx.

Xxx xxxx xx xxx xxx XX xxxxxx xx xxxx xxxxxx xxx xxxxxxx xx xxx XX xxxxxx, xxxxxxxxx xxxxxxxx XX xxxxx xxx xxxxxxxxx xxxxx xxxxxxx. Xxx xxx'x xxxxxx xxx XX xxxx x xxxxxxxxxx xxxxxx xxx xxx xxx xxxx x xxxxxxx xx xx xxxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh750317) xx xxxxx xxxx xx xx xxx xxxxx.

> **Xxxx**  Xxx xxx xxxxxxxxx xx xxxx xxxxx'x x xxxxxxxx xxxxxx xxxxxx xxxx xxx xxxxx XX xxxxxxx xxxx xxx'x xxxxxx xxx xxxxx xx xxxxxxx xx xxx xxxxx xxxxxx. Xxx xxxxxxx xxxx xxxxxxxxxx xxx xxxxxxxxxxx xxxx xxx’x xxxxxx xxxxxx xxx xxx xx xxxx xxxxxx xxxxxx.

## Xxxxx xxxxxxx xxxxxxxxxxxxx

Xxxx xx xxx xxxxxxx xxxxxx xx xx xxx xxx xxxxxxx xxxxxxx, xxx xxxxxxxxx xxxxx. Xxx'x xx xxxx xxxx xxxx xxxxxxxxx xx xxxxx xx xxx XX xxxx xxx xxxx xxxx xxxxxxxxx. Xxx xxxxxxx, xxx'x xxxxxx xxx XX xxx xxxxxxxxxxxxx-xxxxxxxxx XX xxx xxx xxxxxxxx xx xxxxxx.

-   Xxx [x:XxxxxXxxxXxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt204785) xx xxxxx-xxxxxxxxxxx xxxxxxxx.
-   Xxxxxxxxxxxxxxxx xxxxxx xxxxxxxx xxxx xxx xxxx xx-xxxxxx.

[
            **XxxxXxxxxxxxxx.XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967918) xxxxxx xxxx xxx xxx XX xxxxxx xx xxxxxxx xxxx xx'x xxx xxxx.

## Xxx xxxxxxxxxxxx XXXx

Xx xxxx xxxx xxxx xxx xxxxxxxxxx, xxx xxxxxxxx xxxxxxxx xxxxxxxxxxxx xxxxxxxx xx xxxx xx xxx XXXx. Xx xxxxxxxxxxxx XXX xxxxxxx xxxx xxxx xxxxxx xxxxxxxxx xxxxxx xxxxx xxxxxx xxx x xxxxxxxxxxx xxxxxx xx xxxx. Xxxx xxx xxxx xx XXX xxxx xxx XX xxxxxx, xxx xxx xxxxxxxxxxxx xxxxxxx xx xx'x xxxxxxxxx. Xxx xxxx xxxx xxxxx xxxxxxxxxxx xxxx **xxxxx** xxxxxxxx, xxx [Xxxxxxxxxxxx xxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt187335) xx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/Mt187337).

## Xxxxxxx xxxx xx xxxxxxxxxx xxxxxxx

Xxxxx xxxxx xxxxxxxx xx xxxxxx xxxxxxx. Xx xxxxx xxxxx x xxx-xxxxxxx xxxxxx xx xxxx xxxxx xx xx xxxxxxxxx, xxxxxxxx xx xx x xxxxxxxxxx xxxxxx xxx xxxxxx.

Xxx xxx xxxxxxxx xxxx xxxxxxxxxxxxxx xx xxxxx xxx **xxxxx** xxxxxxxx xx X#, xxx **Xxxxx** xxxxxxxx xx Xxxxxx Xxxxx, xx xxxxxxxxx xx X++. Xxx xxxx xxxxx'x xxxxxxxxx xxxx xxx xxxx xxx xxxxxxxx xxxx xxx xx x xxxxxxxxxx xxxxxx. Xxxx xx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XXXx xxxxxxxx xxxx xx xxx xxxxxxxxxx xxxxxx xxx xxx, xxx xx xxx xxxx xxxx xxx xxxx xx xxxxx xxxx **xxxxx** xx x xxxxxxxx, xxx xxx xxxx xxxxxxxx xx xxxxxx xx xxx XX xxxxxx. Xxx xxxx xx xxxxxxxxxx xxx xxxx xxx xxxx xx xxx xxxx xxx xxxx xx x xxxxxxxxxx xxxxxx. Xx X#X# xxx Xxxxxx Xxxxx xxx xxx xxxxxxxxxx xxxx xx xxxxxxx xxxx xx [**Xxxx.Xxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/system.threading.tasks.task.run.aspx).

Xxxxxxxx xxxx XX xxxxxxxx xxx xxxx xx xxxxxxxx xxxx xxx XX xxxxxx. Xxx xxx XX xxxxxx xx xxxxxx XX xxxxxxxx xxxxxx xxxxxxxxx xxx xxxxxxxxxx xxxx xxx/xx xxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh750317) xx [**XxxxXxxxxxxxxx.XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh967918) xx xxx xxxxxxxxxx xxxxxx.

Xx xxxxxxx xx xxxx xxxx xxx xx xxxxxxxxx xx x xxxxxxxxxx xxxxxx xx xxx xxxxxxxxxxx xx xxxxxxxx XX xx x xxxx. Xxx xxxx xxxx xxxxxxxxxx xxx xxxxxxxx'x xxxx xxxx xxx xxxx x xxx xx xxxx xx xxxxxxx.

```csharp
public class AsyncExample
{
    private async void NextMove-Click(object sender, RoutedEventArgs e)
    {
        // The await causes the handler to return immediately.
        await System.Threading.Tasks.Task.Run(() => ComputeNextMove());
        // Now update the UI with the results.
        // ...
    }

    private async System.Threading.Tasks.Task ComputeNextMove()
    {
        // Perform background work here.
        // Don't directly access UI elements from this method.
    }
}
```

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```csharp
public class Example
{
    // ...
    private async void NextMove-Click(object sender, RoutedEventArgs e)
    {
        await Task.Run(() => ComputeNextMove());
        // Update the UI with results
    }

    private async Task ComputeNextMove()
    {
        // ...
    }
    // ...
}
```
```vb
Public Class Example
    ' ...
    Private Async Sub NextMove-Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Await Task.Run(Function() ComputeNextMove())
        ' update the UI with results
    End Sub

    Private Async Function ComputeNextMove() As Task
        ' ...
    End Function
    ' ...
End Class
```

Xx xxxx xxxxxxx, xxx `NextMove-Click` xxxxxxx xxxxxxx xx xxx **xxxxx** xx xxxxx xx xxxx xxx XX xxxxxx xxxxxxxxxx. Xxx xxxxxxxxx xxxxx xx xx xxxx xxxxxxx xxxxx xxxxx `ComputeNextMove` (xxxxx xxxxxxxx xx x xxxxxxxxxx xxxxxx) xxxxxxxxx. Xxx xxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxx xxx XX xxxx xxx xxxxxxx.

> **Xxxx**  Xxxxx'x xxxx x [**XxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR229621) xxx [**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR229621timer) XXX xxx xxx XXX, xxxxx xxx xx xxxx xxx xxxxxxx xxxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxx xxx xxxxx xxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt187340).

## Xxxxxxx xxxxxx

* [Xxxxxx xxxx xxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt185599)

<!--HONumber=Mar16_HO1-->
