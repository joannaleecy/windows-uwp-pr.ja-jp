---
xx.xxxxxxx: XYXYYYYX-YYYY-YYXX-XXYX-XYXYXYXYYXXX
xxxxx: Xxxxxx x xxxx xxxx xx xxx xxxxxx xxxx
xxxxxxxxxxx: Xxxxx xxx xx xx xxxx xx x xxxxxxxx xxxxxx xx xxxxxxxxxx x xxxx xxxx xx xxx xxxxxx xxxx.
---
# Xxxxxx x xxxx xxxx xx xxx xxxxxx xxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230593)
-   [**XXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206580)

Xxxxx xxx xx xx xxxx xx x xxxxxxxx xxxxxx xx xxxxxxxxxx x xxxx xxxx xx xxx xxxxxx xxxx. Xxx xxxx xx xxxxxxxx x xxxxxxxxxx XX xxxxx xxxxx xxxxxxxxxx xxxx xxxx xxxxx x xxxxxxxxxx xxxxxx xx xxxx, xxx xxx xx xx xxxxxxxx xxxxxxxx xxxxx xx xxxxxxxx.

## Xxxxxx xxx xxxxxx xxx xxxx xxxx

Xxxxxx x xxxx xxxx xx xxxxxxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230593). Xxxxxx x xxxxxxxx xx xx xxx xxxx (xxx xxx xxx x xxxxxx, xx x xxxxxxxx xxxxxxxx). Xxxx xxxx **XxxXxxxx** xxxxxxx xx [**XXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206580) xxxxxx; xxxxx xxxx xxxxxx xxx xxx xx xxx xxxx xxxx.

Xxxxx xxxxxxxx xx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230593) xxx xxxxxxxxx xx xxxx xxx xxx xxxxxxxxxx xxxxxxx xxx xxxxxxxx xx xxx xxxx xxxx, xxx xxxxxxx xxxxxxx xx xxxx xxxxxxxxxxxx xxxx xxxxx xxxx xxxxx.

**Xxxx**  Xxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh750317) xx xxxxxx xxx XX xxxxxx xxx xxxx xxxxxxxx xxxx xxx xxxx xxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx x xxxx xxxx xxx xxxxxxxx x xxxxxx xx xx xxx xxxx:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
``` cpp
// The nth prime number to find.
const unsigned int n = 9999;

// A shared pointer to the result.
// We use a shared pointer to keep the result alive until the 
// thread is done.
std::shared_ptr&lt;unsigned long&gt; nthPrime = make_shared&lt;unsigned long int&gt;(0);

// Simulates work by searching for the nth prime number. Uses a
// naive algorithm and counts 2 as the first prime number.
auto workItem = ref new WorkItemHandler(
    \[this, n, nthPrime](IAsyncAction^ workItem)
{
    unsigned int progress = 0; // For progress reporting.
    unsigned int primes = 0;   // Number of primes found so far.
    unsigned long int i = 2;   // Number iterator.

    if ((n &gt;= 0) &amp;&amp; (n &lt;= 2))
    {
        *nthPrime = n;
        return;
    }

    while (primes &lt; (n - 1))
    {
        if (workItem-&gt;Status == AsyncStatus::Canceled)
        {
            break;
        }

        // Go to the next number.
        i++;

        // Check for prime.
        bool prime = true;
        for (unsigned int j = 2; j &lt; i; ++j)
        {
            if ((i % j) == 0)
            {
                prime = false;
                break;
            }
        };

        if (prime)
        {
            // Found another prime number.
            primes++;

            // Report progress at every 10 percent.
            unsigned int temp = progress;
            progress = static_cast&lt;unsigned int&gt;(10.f*primes / n);

            if (progress != temp)
            {
                String^ updateString;
                updateString = "Progress to " + n + "th prime: "
                    + (10 * progress).ToString() + "%\n";

                // Update the UI thread with the CoreDispatcher.
                CoreApplication::MainView-&gt;CoreWindow-&gt;Dispatcher-&gt;RunAsync(
                    CoreDispatcherPriority::High,
                    ref new DispatchedHandler([this, updateString]()
                {
                    UpdateUI(updateString);
                }));
            }
        }
    }

    // Return the nth prime number.
    *nthPrime = i;
});

auto asyncAction = ThreadPool::RunAsync(workItem);

// A reference to the work item is cached so that we can trigger a 
// cancellation when the user presses the Cancel button.
m_workItem = asyncAction;
```
``` csharp
// The nth prime number to find.
const uint n = 9999;

// A shared pointer to the result.
// We use a shared pointer to keep the result alive until the 
// thread is done.
ulong nthPrime = 0;

// Simulates work by searching for the nth prime number. Uses a
// naive algorithm and counts 2 as the first prime number.
IAsyncAction asyncAction = Windows.System.Threading.ThreadPool.RunAsync(
    (workItem) =&gt;
{
    uint  progress = 0; // For progress reporting.
    uint  primes = 0;   // Number of primes found so far.
    ulong i = 2;        // Number iterator.

    if ((n &gt;= 0) &amp;&amp; (n &lt;= 2))
    {
        nthPrime = n;
        return;
    }

    while (primes &lt; (n - 1))
    {
        if (workItem.Status == AsyncStatus.Canceled)
        {
            break;
        }

        // Go to the next number.
        i++;

        // Check for prime.
        bool prime = true;
        for (uint j = 2; j &lt; i; ++j)
        {
            if ((i % j) == 0)
            {
                prime = false;
                break;
            }
        };

        if (prime)
        {
            // Found another prime number.
            primes++;

            // Report progress at every 10 percent.
            uint temp = progress;
            progress = (uint)(10.0*primes/n);

            if (progress != temp)
            {
                String updateString;
                updateString = "Progress to " + n + "th prime: "
                    + (10 * progress) + "%\n";

                // Update the UI thread with the CoreDispatcher.
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.High,
                    new DispatchedHandler(() =&gt;
                {
                    UpdateUI(updateString);
                }));
            }
        }
    }

    // Return the nth prime number.
    nthPrime = i;
});

// A reference to the work item is cached so that we can trigger a
// cancellation when the user presses the Cancel button.
m_workItem = asyncAction;
```

Xxxxxxxxx xxx xxxx xx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR230593), xxx xxxx xxxx xx xxxxxx xx xxx xxxxxx xxxx xxx xxxx xxxx x xxxxxx xxxxxxx xxxxxxxxx. Xxxxxx xxxx xxxx xxxxx xxx xxxxxxxxxxxxxx xxx xxxx xxx xxx xx xxx xxxxx, xx xxxx xxxx xxxx xxxx xxxxx xxxxxxxx xxxxxxxxxxxxx.

Xxxx xxxx xxx xxxx xxxx xxxxxx xxx [**XXxxxxXxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206593) xxxxxxxx, xxx xxxxx xx xxx xxxx xxxx xx xxxxxxxxx.

## Xxxxxx xxxx xxxx xxxxxxxxxx

Xxxxxxx x xxxxxxxxxx xxxxxxx xx xxxxxxx xxx [**XXxxxxXxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.foundation.iasyncaction.completed.aspx) xxxxxxxx xx xxx xxxx xxxx. Xxxxxx x xxxxxxxx (xxx xxx xxx x xxxxxx xx x xxxxxxxx xxxxxxxx) xx xxxxxx xxxx xxxx xxxxxxxxxx. Xxx xxxxxxx, xxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh750317) xx xxxxxx xxx XX xxxxxx xxx xxxx xxx xxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx xxx XX xxxx xxx xxxxxx xx xxx xxxx xxxx xxxxxxxxx xx xxxx Y:

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
``` cpp
asyncAction-&gt;Completed = ref new AsyncActionCompletedHandler(
    \[this, n, nthPrime](IAsyncAction^ asyncInfo, AsyncStatus asyncStatus)
{
    if (asyncStatus == AsyncStatus::Canceled)
    {
        return;
    }
    
    String^ updateString;
    updateString = "\n" + "The " + n + "th prime number is " 
        + (*nthPrime).ToString() + ".\n";

    // Update the UI thread with the CoreDispatcher.
    CoreApplication::MainView-&gt;CoreWindow-&gt;Dispatcher-&gt;RunAsync(
        CoreDispatcherPriority::High,
        ref new DispatchedHandler([this, updateString]()
    {
        UpdateUI(updateString);
    }));
});
```
``` csharp
asyncAction.Completed = new AsyncActionCompletedHandler(
    (IAsyncAction asyncInfo, AsyncStatus asyncStatus) =&gt;
{
    if (asyncStatus == AsyncStatus.Canceled)
    {
        return;
    }

    String updateString;
    updateString = "\n" + "The " + n + "th prime number is " 
        + nthPrime + ".\n";

    // Update the UI thread with the CoreDispatcher.
    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
        CoreDispatcherPriority.High,
        new DispatchedHandler(()=&gt;
    {
        UpdateUI(updateString);
    }));
});
```

Xxxx xxxx xxx xxxxxxxxxx xxxxxxx xxxxxx xxxxxxx xxx xxxx xxxx xxx xxxxxxxxx xxxxxx xxxxxxxxxxx x XX xxxxxx.

## Xxxxxxx xxx xxxx xxxxx

Xxx xxx xxxxx xxxx xx xxxxxxxxxxx xxx xxxx xxxx xxxx xxxxxxxxxx xx xxx [Xxxxxxxx x XxxxxxXxxx xxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=328569) xxxxxxx xxx Xxxxxxx Y.Y, xxx xx-xxxxx xxx xxxxxx xxxx xx x xxx\_xxxx Xxxxxxx YY xxx.

## Xxxxxxx xxxxxx

* [Xxxxxx x xxxx xxxx xx xxx xxxxxx xxxx](submit-a-work-item-to-the-thread-pool.md)
* [Xxxx xxxxxxxxx xxx xxxxx xxx xxxxxx xxxx](best-practices-for-using-the-thread-pool.md)
* [Xxx x xxxxx xx xxxxxx x xxxx xxxx](use-a-timer-to-submit-a-work-item.md)
 

<!--HONumber=Mar16_HO1-->
