---
xx.xxxxxxx: YYXYYXYX-YYYY-YYXY-XYYX-YYYYXXYYYYYX
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxxx xxx xxxxxxxxxxx xxx xx xxxxxxx xxxxxxxxxxxx xxxxxxx xx Xxxxxx X++ xxxxxxxxx xxxxxxxxxx (X++/XX) xx xxxxx xxx xxxx xxxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxxx xx xxxxxxxx.x.
xxxxx: Xxxxxxxxxxxx xxxxxxxxxxx xx X++
---

# Xxxxxxxxxxxx xxxxxxxxxxx xx X++

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [xxxx xxxxx]
-   [**xxxxxxxxxxx xxxxxxxxx**][xxxxxxxxxxxXxxxxxxxx]
-   [**XXxxxxXxxxxxxxx**][XXxxxxXxxxxxxxx]

Xxxx xxxxxxx xxxxxxxxx xxx xxxxxxxxxxx xxx xx xxxxxxx xxxxxxxxxxxx xxxxxxx xx Xxxxxx X++ xxxxxxxxx xxxxxxxxxx (X++/XX) xx xxxxx xxx `task` xxxxx xxxx'x xxxxxxx xx xxx `concurrency` xxxxxxxxx xx xxxxxxxx.x.

## Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxxxxxxx xxxxx

Xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxxx x xxxx-xxxxxxx xxxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxx xxx xxxxxxxx xxx xxxxx xxxx xxx xxxx xx xxxxxxx xxxx xxxxxxx. Xx xxx xxx xxx xxxxxxxx xxxx xxx XXX xxxxxxxxxxxx xxxxx, xxxx [Xxxxxxxxxxxx Xxxxxxxxxxx][XxxxxXxxxxxxxxxx] xxxxxx xxx xxxx xxx xxxx xx xxxx xxxxxxx.

Xxxxxxxx xxx xxx xxxxxxx xxx xxxxxxxxxxxx XXX XXXx xxxxxxxx xx X++, xxx xxxxxxxxx xxxxxxxx xx xx xxx xxx [**xxxx xxxxx**][xxxx-xxxxx] xxx xxx xxxxxxx xxxxx xxx xxxxxxxxx, xxxxx xxx xxxxxxxxx xx xxx [**xxxxxxxxxxx**][xxxxxxxxxxxXxxxxxxxx] xxxxxxxxx xxx xxxxxxx xx `<ppltasks.h>`. Xxx **xxxxxxxxxxx::xxxx** xx x xxxxxxx-xxxxxxx xxxx, xxx xxxx xxx **/XX** xxxxxxxx xxxxxx—xxxxx xx xxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxxxxxxxxx—xx xxxx, xxx xxxx xxxxx xxxxxxxxxxxx xxx XXX xxxxxxxxxxxx xxxxx xx xxxx xx'x xxxxxx xx:

-   xxxxx xxxxxxxx xxxxxxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxxxxxx

-   xxxxxx xxxxxxxxxx xx xxxx xxxxxx

-   xxxxxxx xxxxxxxxxxxx xx xxxx xxxxxx

-   xxxxxx xxxx xxxxxxxxxx xxxxx xxx xx xxx xxxxxxxxxxx xxxxxx xxxxxxx xx xxxxxxxxx

Xxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxx xxxxx xxx xx xxx xxx **xxxx** xxxxx xxxx xxx XXX xxxxxxxxxxxx XXXx. Xxx xxxx xxxxxxxx xxxxxxxxxxxxx xxxxx **xxxx** xxx xxx xxxxxxx xxxxxxx xxxxxxxxx [**xxxxxx\_xxxx**][xxxxxxXxxx], xxx [Xxxx Xxxxxxxxxxx (Xxxxxxxxxxx Xxxxxxx)][xxxxXxxxxxxxxxx]. Xxx xxxx xxxxxxxxxxx xxxxx xxx xx xxxxxx xxxxxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxxxxxx xx XxxxXxxxxx xx xxxxx XXX-xxxxxxxxxx xxxxxxxxx, xxx [Xxxxxxxx Xxxxxxxxxxxx Xxxxxxxxxx xx X++ xxx Xxxxxxx Xxxxxxx xxxx][xxxxxxXxxxxXxx].

## Xxxxxxxxx xx xxxxx xxxxxxxxx xx xxxxx x xxxx

Xxx xxxxxxxxx xxxxxxx xxxxx xxx xx xxx xxx xxxx xxxxx xx xxxxxxx xx **xxxxx** xxxxxx xxxx xxxxxxx xx [**XXxxxxXxxxxxxxx**][XXxxxxXxxxxxxxx] xxxxxxxxx xxx xxxxx xxxxxxxxx xxxxxxxx x xxxxx. Xxxx xxx xxx xxxxx xxxxx:

1.  Xxxx xxx `create_task` xxxxxx xxx xxxx xx xxx **XXxxxxXxxxxxxxx^** xxxxxx.

2.  Xxxx xxx xxxxxx xxxxxxxx [**xxxx::xxxx**][xxxxXxxx] xx xxx xxxx xxx xxxxxx x xxxxxx xxxx xxxx xx xxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxxxxxxx.


``` cpp
#include <ppltasks.h>
using namespace concurrency;
using namespace Windows::Devices::Enumeration;
...
void App::TestAsync()
{    
    //Call the *Async method that starts the operation.
    IAsyncOperation<DeviceInformationCollection^>^ deviceOp =
        DeviceInformation::FindAllAsync();

    // Explicit construction. (Not recommended)
    // Pass the IAsyncOperation to a task constructor.
    // task<DeviceInformationCollection^> deviceEnumTask(deviceOp);

    // Recommended:
    auto deviceEnumTask = create_task(deviceOp);

    // Call the task’s .then member function, and provide
    // the lambda to be invoked when the async operation completes.
    deviceEnumTask.then( [this] (DeviceInformationCollection^ devices ) 
    {       
        for(int i = 0; i < devices->Size; i++)
        {
            DeviceInformation^ di = devices->GetAt(i);
            // Do something with di...          
        }       
    }); // end lambda
    // Continue doing work or return...
}
```

Xxx xxxx xxxx'x xxxxxxx xxx xxxxxxxx xx xxx [**xxxx::xxxx**][xxxxXxxx] xxxxxxxx xx xxxxx xx x *xxxxxxxxxxxx*. Xxx xxxxx xxxxxxxx (xx xxxx xxxx) xx xxx xxxx-xxxxxxxx xxxxxx xx xxx xxxxxx xxxx xxx xxxx xxxxxxxxx xxxxxxxx xxxx xx xxxxxxxxx. Xx'x xxx xxxx xxxxx xxxx xxxxx xx xxxxxxxxx xx xxxxxxx [**XXxxxxXxxxxxxxx::XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206600) xx xxx xxxx xxxxx xxx **XXxxxxXxxxxxxxx** xxxxxxxxx xxxxxxxx.

Xxx [**xxxx::xxxx**][xxxxXxxx] xxxxxx xxxxxxx xxxxxxxxxxx, xxx xxx xxxxxxxx xxxxx'x xxx xxxxx xxx xxxxxxxxxxxx xxxx xxxxxxxxx xxxxxxxxxxxx. Xx xxxx xxxxxxx, xx xxx xxxxxxxxxxxx xxxxxxxxx xxxxxx xx xxxxxxxxx xx xx xxxxxx, xx xxxx xx xxx xxxxxxxx xxxxx xx x xxxxxx xx x xxxxxxxxxxxx xxxxxxx, xxx xxxxxxxxxxxx xxxx xxxxx xxxxxxx. Xxxxx, xx’xx xxxxxxxx xxx xx xxxxx xxxxxxxxxxxxx xxxx xxxxxxx xxxx xx xxx xxxxxxxx xxxx xxx xxxxxxxxx xx xxxxxx.

Xxxxxxxx xxx xxxxxxx xxx xxxx xxxxxxxx xx xxx xxxxx xxxxx, xx xxxxxxx xxx xxxxxxxx xx xxxx xx xx xxx xxxxxxx xxxxx xxx xx xxx xxxxxxxxxx xxxxxxxx xxx xxx xxxxxxxxxx xx xx xx xxx xx xxxxx, xxxx xx xxx xxxxxx xxxxxxx xxxxxx xxx xxxxxxxxxx xxxxxxxx.

## Xxxxxxxx x xxxxx xx xxxxx

Xx xxxxxxxxxxxx xxxxxxxxxxx, xx'x xxxxxx xx xxxxxx x xxxxxxxx xx xxxxxxxxxx, xxxx xxxxx xx *xxxx xxxxxx*, xx xxxxx xxxx xxxxxxxxxxxx xxxxxxxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxxxx. Xx xxxx xxxxx, xxx xxxxxxxx (xx *xxxxxxxxxx*) xxxx xxxxxxxx x xxxxx xxxx xxx xxxxxxxxxxxx xxxxxxx xx xxxxx. Xx xxxxx xxx [**xxxx::xxxx**][xxxxXxxx] xxxxxx, xxx xxx xxxxxx xxxx xxxxxx xx xx xxxxxxxxx xxx xxxxxxxxxxxxxxx xxxxxx; xxx xxxxxx xxxxxxx x **xxxx<T>** xxxxx **X** xx xxx xxxxxx xxxx xx xxx xxxxxx xxxxxxxx. Xxx xxx xxxxxxx xxxxxxxx xxxxxxxxxxxxx xxxx x xxxx xxxxx: `myTask.then(…).then(…).then(…);`

Xxxx xxxxxx xxx xxxxxxxxxx xxxxxx xxxx x xxxxxxxxxxxx xxxxxxx x xxx xxxxxxxxxxxx xxxxxxxxx; xxxx x xxxx xx xxxxx xx xx xxxxxxxxxxxx xxxx. Xxx xxxxxxxxx xxxxxxx xxxxxxxxxxx x xxxx xxxxx xxxx xxx xxx xxxxxxxxxxxxx. Xxx xxxxxxx xxxx xxxxxxxx xxx xxxxxx xx xx xxxxxxxx xxxx, xxx xxxx xxxx xxxxxxxxx xxxxxxxxx, xxx xxxxx xxxxxxxxxxxx xxxxxx xx x xxx xxxxxxxxxxxx xxxxxxxxx xx xxxxxx xxx xxxx. Xxxx xxxx xxxxxxxxx xxxxxxxxx, xxx xxxxxx xxxxxxxxxxxx xxxx, xxx xxxxxxx x xxxxxxxxxxxx xxxxxxx.

``` cpp
#include <ppltasks.h>
using namespace concurrency;
...
void App::DeleteWithTasks(String^ fileName)
{    
    using namespace Windows::Storage;
    StorageFolder^ localFolder = ApplicationData::Current::LocalFolder;
    auto getFileTask = create_task(localFolder->GetFileAsync(fileName));

    getFileTask.then([](StorageFile^ storageFileSample) ->IAsyncAction^ {       
        return storageFileSample->DeleteAsync();
    }).then([](void) {
        OutputDebugString(L"File deleted.");
    });
}
```

Xxx xxxxxxxx xxxxxxx xxxxxxxxxxx xxxx xxxxxxxxx xxxxxx:

-   Xxx xxxxx xxxxxxxxxxxx xxxxxxxx xxx [**XXxxxxXxxxxx^**][XXxxxxXxxxxx] xxxxxx xx x **xxxx<void>** xxx xxxxxxx xxx **xxxx**.

-   Xxx xxxxxx xxxxxxxxxxxx xxxxxxxx xx xxxxx xxxxxxxx, xxx xxxxxxxxx xxxxx **xxxx** xxx xxx **xxxx<void>** xx xxxxx. Xx xx x xxxxx-xxxxx xxxxxxxxxxxx.

-   Xxx xxxxxx xxxxxxxxxxxx xxxxx'x xxxxxxx xxxxx xxx [**XxxxxxXxxxx**][xxxxxxXxxxx] xxxxxxxxx xxxxxxxxx.

-   Xxxxxxx xxx xxxxxx xxxxxxxxxxxx xx xxxxx-xxxxx, xx xxx xxxxxxxxx xxxx xxx xxxxxxx xx xxx xxxx xx [**XxxxxxXxxxx**][xxxxxxXxxxx] xxxxxx xx xxxxxxxxx, xxx xxxxxx xxxxxxxxxxxx xxxxx'x xxxxxxx xx xxx.

**Xxxx**  Xxxxxxxx x xxxx xxxxx xx xxxx xxx xx xxx xxxx xx xxx xxx **xxxx** xxxxx xx xxxxxxx xxxxxxxxxxxx xxxxxxxxxx. Xxx xxx xxxx xxxxxxx xxxxxxxxxx xx xxxxx xxxx xxx xxxxxx xxxxxxxxx **&&** xxx **||**. Xxx xxxx xxxxxxxxxxx, xxx [Xxxx Xxxxxxxxxxx (Xxxxxxxxxxx Xxxxxxx)][xxxxXxxxxxxxxxx].

## Xxxxxx xxxxxxxx xxxxxx xxxxx xxx xxxx xxxxxx xxxxx

Xx x xxxx xxxxxxxxxxxx, xxx xxxxxx xxxx xx xxx xxxxxx xxxxxxxx xx xxxxxxx xx x **xxxx** xxxxxx. Xx xxx xxxxxx xxxxxxx x **xxxxxx**, xxxx xxx xxxx xx xxx xxxxxxxxxxxx xxxx xx **xxxx<double>**. Xxxxxxx, xxx xxxx xxxxxx xx xxxxxxxx xx xxxx xx xxxxx'x xxxxxxx xxxxxxxxxx xxxxxx xxxxxx xxxxx. Xx x xxxxxx xxxxxxx xx **XXxxxxXxxxxxxxx<XxxxxxxxxxxXxxx^>^**, xxx xxxxxxxxxxxx xxxxxxx x **xxxx<XxxxxxxxxxxXxxx^>**, xxx x **xxxx<xxxx<XxxxxxxxxxxXxxx^>>** xx **xxxx<XXxxxxXxxxxxxxx<XxxxxxxxxxxXxxx^>^>^**. Xxxx xxxxxxx xx xxxxx xx *xxxxxxxxxxxx xxxxxxxxxx* xxx xx xxxx xxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxxxx xxx xxxx xxxxxxxxxxxx xx xxxxxxx.

Xx xxx xxxxxxxx xxxxxxx, xxxxxx xxxx xxx xxxx xxxxxxx x **xxxx<void>** xxxx xxxxxx xxx xxxxxx xxxxxxxx xx [**XXxxxxXxxx**][XXxxxxXxxx] xxxxxx. Xxx xxxxxxxxx xxxxx xxxxxxxxxx xxx xxxx xxxxxxxxxxx xxxx xxxxx xxxxxxx x xxxxxx xxxxxxxx xxx xxx xxxxxxxxx xxxx:

| | |
|--------------------------------------------------------|---------------------|
| xxxxxx xxxxxx xxxx                                     | `.then` xxxxxx xxxx |
| XXxxxxx                                                | xxxx<TResult> |
| XXxxxxXxxxxxxxx<TResult>^                        | xxxx<TResult> |
| XXxxxxXxxxxxxxxXxxxXxxxxxxx<XXxxxxx, XXxxxxxxx>^ | xxxx<TResult> |
|XXxxxxXxxxxx^                                           | xxxx<void>    |
| XXxxxxXxxxxxXxxxXxxxxxxx<TProgress>^             |xxxx<void>     |
| xxxx<TResult>                                    |xxxx<TResult>  |


## Xxxxxxxxx xxxxx

Xx xx xxxxx x xxxx xxxx xx xxxx xxx xxxx xxx xxxxxx xx xxxxxx xx xxxxxxxxxxxx xxxxxxxxx. Xxx xx xxxx xxxxx xxx xxxxx xxxx xx xxxxxx xx xxxxxxxxx xxxxxxxxxxxxxxxx xxxx xxxxxxx xxx xxxx xxxxx. Xxxxxxxx xxxx \***Xxxxx** xxxxxx xxxx xxx x [**Xxxxxx**][XXxxxxXxxxXxxxxx] xxxxxx xxxx xx xxxxxxxx xxxx [**XXxxxxXxxx**][XXxxxxXxxx], xx'x xxxxxxx xx xxxxxx xx xx xxxxxxx xxxxxxx. Xxx xxxxxxxxx xxx xx xxxxxxx xxxxxxxxxxxx xx x xxxx xxxxx xx xx xxx x [**xxxxxxxxxxxx\_xxxxx\_xxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh749985.aspx) xx xxxxxx x [**xxxxxxxxxxxx\_xxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh749975.aspx), xxx xxxx xxxx xxx xxxxx xx xxx xxxxxxxxxxx xx xxx xxxxxxx xxxx. Xx xx xxxxxxxxxxxx xxxx xx xxxxxxx xxxx x xxxxxxxxxxxx xxxxx, xxx [**xxxxxxxxxxxx\_xxxxx\_xxxxxx::xxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750076.aspx) xx xxxxxx, xxx xxxx xxxxxxxxxxxxx xxxxx **Xxxxxx** xx xxx **XXxxxx\*** xxxxxxxxx xxx xxxxxx xxx xxxxxxxxxxxx xxxxxxx xxxx xxx xxxxxxxxxxxx xxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxxxxxxxxxx xxx xxxxx xxxxxxxx.

``` cpp
//Class member:
cancellation_token_source m_fileTaskTokenSource;

// Cancel button event handler:
m_fileTaskTokenSource.cancel();

// task chain
auto getFileTask2 = create_task(documentsFolder->GetFileAsync(fileName), 
                                m_fileTaskTokenSource.get_token());
//getFileTask2.then ...
```

Xxxx x xxxx xx xxxxxxxx, x [**xxxx\_xxxxxxxx**][xxxxXxxxxxxx] xxxxxxxxx xx xxxxxxxxxx xxxx xxx xxxx xxxxx. Xxxxx-xxxxx xxxxxxxxxxxxx xxxx xxxxxx xxx xxxxxxx, xxx xxxx-xxxxx xxxxxxxxxxxxx xxxx xxxxx xxx xxxxxxxxx xx xx xxxxxx xxxx [**xxxx::xxx**][xxxxXxx] xx xxxxxx. Xx xxx xxxx xx xxxxx-xxxxxxxx xxxxxxxxxxxx, xxxx xxxx xxxx xx xxxxxxx xxx **xxxx\_xxxxxxxx** xxxxxxxxx xxxxxxxxxx. (Xxxx xxxxxxxxx xx xxx xxxxxxx xxxx [**Xxxxxxxx::Xxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh755825.aspx).)

Xxxxxxxxxxxx xx xxxxxxxxxxx. Xx xxxx xxxxxxxxxxxx xxxx xxxx xxxx-xxxxxxx xxxx xxxxxx xxxx xxxxxxxx x XXX xxxxxx, xxxx xx xx xxxx xxxxxxxxxxxxxx xx xxxxx xxx xxxxx xx xxx xxxxxxxxxxxx xxxxx xxxxxxxxxxxx xxx xxxx xxxxxxxxx xx xx xx xxxxxxxx. Xxxxx xxx xxxxx xx xxx xxxxxxxxx xxxx xxxx xxxxxxxxx xx xxx xxxxxxxxxxxx, xxxx [**xxxxxx\_xxxxxxx\_xxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh749945.aspx) xx xxxxxx xxxx xxxx xxx xxxxxxxxx xxx xxxxxxxxxxxx xxxx xx xxx xxxxx-xxxxx xxxxxxxxxxxxx xxxx xxxxxx xx. Xxxx'x xxxxxxx xxxxxxx: xxx xxx xxxxxx x xxxx xxxxx xxxx xxxxxxxxxx xxx xxxxxx xx x [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR207871) xxxxxxxxx. Xx xxx xxxx xxxxxxx xxx **Xxxxxx** xxxxxx, xxx [**XXxxxxXxxx::Xxxxxx**][XXxxxxXxxxXxxxxx] xxxxxx xx xxx xxxxxx. Xxxxxxx, xxx xxxxxxxxx xxxxxxxx xxx xxxxxxx **xxxxxxx**. Xxx xxxxxxxxxxxx xxx xxxx xxx xxxxx xxxxxxxxx xxx xxxx **xxxxxx\_xxxxxxx\_xxxx** xx xxx xxxxx xx **xxxxxxx**.

Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxxxxxx xx xxx XXX](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dd984117.aspx)

## Xxxxxxxx xxxxxx xx x xxxx xxxxx

Xx xxx xxxx x xxxxxxxxxxxx xx xxxxxxx xxxx xx xxx xxxxxxxxxx xxx xxxxxxxx xx xxxxx xx xxxxxxxxx, xxxx xxxx xxx xxxxxxxxxxxx x xxxx-xxxxx xxxxxxxxxxxx xx xxxxxxxxxx xxx xxxxx xx xxx xxxxxx xxxxxxxx xx x **xxxx<TResult>** xx **xxxx<void>** xx xxx xxxxxx xx xxx xxxxxxxxxx xxxx xxxxxxx xx [**XXxxxxXxxxxx^**][XXxxxxXxxxxx].

Xx xxxxxx xxxxxx xxx xxxxxxxxxxxx xx x xxxx xxxxx, xxx xxx'x xxxx xx xxxx xxxxx xxxxxxxxxxxx xxxx-xxxxx xx xxxxxxx xxxxx xxxxxxxxx xxxx xxxxx xxxxx xxxxxx x `try…catch` xxxxx. Xxxxxxx, xxx xxx xxx x xxxx-xxxxx xxxxxxxxxxxx xx xxx xxx xx xxx xxxxx xxx xxxxxx xxx xxxxxx xxxxx. Xxx xxxxxxxxx—xxxx xxxxxxxx x [**xxxx\_xxxxxxxx**][xxxxXxxxxxxx] xxxxxxxxx—xxxx xxxxxxxxx xxxx xxx xxxx xxxxx xxx xxxxxx xxx xxxxx-xxxxx xxxxxxxxxxxxx, xx xxxx xxx xxx xxxxxx xx xx xxx xxxxx-xxxxxxxx xxxx-xxxxx xxxxxxxxxxxx. Xx xxx xxxxxxx xxx xxxxxxxx xxxxxxx xx xxx xx xxxxx-xxxxxxxx xxxx-xxxxx xxxxxxxxxxxx:

``` cpp
#include <ppltasks.h>
void App::DeleteWithTasksHandleErrors(String^ fileName)
{    
    using namespace Windows::Storage;
    using namespace concurrency;

    StorageFolder^ documentsFolder = KnownFolders::DocumentsLibrary;
    auto getFileTask = create_task(documentsFolder->GetFileAsync(fileName));

    getFileTask.then([](StorageFile^ storageFileSample)
    {       
        return storageFileSample->DeleteAsync();
    })

    .then([](task<void> t) 
    {

        try
        {
            t.get();
            // .get() didn' t throw, so we succeeded.
            OutputDebugString(L"File deleted.");
        }
        catch (Platform::COMException^ e)
        {
            //Example output: The system cannot find the specified file.
            OutputDebugString(e->Message->Data());
        }

    });
}
```

Xx x xxxx-xxxxx xxxxxxxxxxxx, xx xxxx xxx xxxxxx xxxxxxxx [**xxxx::xxx**][xxxxXxx] xx xxx xxx xxxxxxx xx xxx xxxx. Xx xxxxx xxxx xx xxxx **xxxx::xxx** xxxx xx xxx xxxxxxxxx xxx xx [**XXxxxxXxxxxx**][XXxxxxXxxxxx] xxxx xxxxxxxx xx xxxxxx xxxxxxx **xxxx::xxx** xxxx xxxx xxx xxxxxxxxxx xxxx xxxx xxxx xxxxxxxxxxx xxxx xx xxx xxxx. Xx xxx xxxxx xxxx xx xxxxxxx xx xxxxxxxxx, xx xx xxxxxx xx xxx xxxx xx **xxxx::xxx**. Xx xxx xxx'x xxxx **xxxx::xxx**, xx xxx'x xxx x xxxx-xxxxx xxxxxxxxxxxx xx xxx xxx xx xxx xxxxx, xx xxx'x xxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxx, xxxx xx **xxxxxxxxxx\_xxxx\_xxxxxxxxx** xx xxxxxx xxxx xxx xxxxxxxxxx xx xxx xxxx xxxx xxxx xxxxxxx.

Xxxx xxxxx xxx xxxxxxxxxx xxxx xxx xxx xxxxxx. Xx xxxx xxx xxxxxxxxxx xx xxxxx xxxx xxx xxx'x xxxxxxx xxxx, xx'x xxxxxx xx xxx xxx xxx xxxxx xxxx xx xxx xx xxxxxxxx xx xxx xx xx xxxxxxx xxxxx. Xxxx, xx xxxxxxx, xxx'x xxxxxxx xx xxxxx xxx **xxxxxxxxxx\_xxxx\_xxxxxxxxx** xxxxxx. Xxxx xxxxxxxxx xx xxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxx. Xxxx **xxxxxxxxxx\_xxxx\_xxxxxxxxx** xx xxxxxx, xx xxxxxxx xxxxxxxxx x xxx xx xxx xxxx. Xxxxx xxx xxxxx xx xxxxxx xx xxxxxxxxx xxxx xxxxxx xx xxxxxxx, xx xx xxxxxxxxxxxxx xxxxxxxxx xxxx'x xxxxxx xx xxxx xxxxx xxxxx xx xxx xxxx.

## Xxxxxxxx xxx xxxxxx xxxxxxx

Xxx XX xx x XXX xxx xxxx xx x xxxxxx-xxxxxxxx xxxxxxxxx (XXX). X xxxx xxxxx xxxxxx xxxxxxx xxxxxx xx [**XXxxxxXxxxxx**][XXxxxxXxxxxx] xx [**XXxxxxXxxxxxxxx**][XXxxxxXxxxxxxxx] xx xxxxxxxxx-xxxxx. Xx xxx xxxx xx xxxxxxx xx xxx XXX, xxxx xxx xx xxx xxxxxxxxxxxxx xxxx xxx xxxx xxx xx xx xx xxxxxxx, xxxxxx xxx xxxxxxx xxxxxxxxx. Xx xxxxx xxxxx, xxx xxxxxx xxxx xxxxx xxxxxxxx xxxxxxxxx-xxxxxxxxx xxxx xxx xxxxxx xxxx. Xxxx xxxxxxxx xxxxx xxxxxxxx xxxxxxxxxxxx xxxx XX xxxxxxxx, xxxxx xxx xxxx xx xxxxxxxx xxxx xxx XXX.

Xxx xxxxxxx, xx x XXX xxx, xx xxx xxxxxx xxxxxxxx xx xxx xxxxx xxxx xxxxxxxxxx x XXXX xxxx, xxx xxx xxxxxxxx x [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/BR242868) xxxxxxx xxxx xxxxxx x [**xxxx::xxxx**][xxxxXxxx] xxxxxx xxxxxxx xxxxxx xx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208211) xxxxxx.

``` cpp
#include <ppltasks.h>
void App::SetFeedText()
{    
    using namespace Windows::Web::Syndication;
    using namespace concurrency;
    String^ url = "http://windowsteamblog.com/windows_phone/b/wmdev/atom.aspx";
    SyndicationClient^ client = ref new SyndicationClient();
    auto feedOp = client->RetrieveFeedAsync(ref new Uri(url));

    create_task(feedOp).then([this]  (SyndicationFeed^ feed) 
    {
        m_TextBlock1->Text = feed->Title->Text;
    });
}
```

Xx x xxxx xxxxx'x xxxxxx xx [**XXxxxxXxxxxx**][XXxxxxXxxxxx] xx [**XXxxxxXxxxxxxxx**][XXxxxxXxxxxxxxx], xxxx xx'x xxx xxxxxxxxx-xxxxx xxx, xx xxxxxxx, xxx xxxxxxxxxxxxx xxx xxx xx xxx xxxxx xxxxxxxxx xxxxxxxxxx xxxxxx.

Xxx xxx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxxx xxx xxxxxx xxxx xx xxxx xx xxxxx xxx xxxxxxxx xx [**xxxx::xxxx**][xxxxXxxx] xxxx xxxxx x [**xxxx\_xxxxxxxxxxxx\_xxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh749968.aspx). Xxx xxxxxxx, xx xxxx xxxxx, xx xxxxx xx xxxxxxxxx xx xxxxxxxx xxx xxxxxxxxxxxx xx xx xxxxxxxxx-xxxxx xxxx xx x xxxxxxxxxx xxxxxx. Xx xxxx x xxxx, xxx xxx xxxx [**xxxx\_xxxxxxxxxxxx\_xxxxxxx::xxx\_xxxxxxxxx**][xxxXxxxxxxxx] xx xxxxxxxx xxx xxxx’x xxxx xx xxx xxxx xxxxxxxxx xxxxxx xx x xxxxx-xxxxxxxx xxxxxxxxx. Xxxx xxx xxxxxxx xxx xxxxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxxx xxx xxxx xxxxx'x xxxx xx xx xxxxxxxxxxxx xxxx xxxxx xxxx xxxx'x xxxxxxxxx xx xxx XX xxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxxxxxxx xxxx xx'x xxxxxx xx xxxxxxx xxx [**xxxx\_xxxxxxxxxxxx\_xxxxxxx::xxx\_xxxxxxxxx**][xxxXxxxxxxxx] xxxxxx, xxx xx xxxx xxxxx xxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxx xx xxxxxx xxx xxxxxxxxxxxxx xxxxxxxxxx xxxxxxxxxx xx xxx-xxxxxx-xxxx xxxxxxxxxxx. Xx xxxx xxxx, xx xxxx xxxxxxx x xxxx xx XXXx xxx XXX xxxxx, xxx xxx xxxx XXX, xx xxxxx xx xx xxxxx xxxxxxxxx xx xxxxxxxx xxx xxxx xxxx. Xx xxx’x xxxxxxx xxx xxxxx xx xxxxx xxx xxxxx xxx xxxxxxxxx, xxx xx xxx'x xxxxxx xxxx. Xxxx xxxx [**XxxxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR210642) xxxxxxxxx xxxxxxxxx, xxx xxxxx xxxxxxxxxxxx xxxxxxx xxx [**XxxxxxxxxxxXxxx^**](https://msdn.microsoft.com/library/windows/apps/BR243485) xxxxxx xxx xxxx xx xx xxxxxxxxxx xx xxx-xxxxxxx `FeedData^` xxxxxx. Xxxxxxx xxxx xx xxxxx xxxxxxxxxx xx xxxxxxxxxxx xxxx xxx xxxxxx, xx xxx xxxxxxxxxxx xxxxx xxxxxx xx xx xxxxxxxxxx xxx **xxxx\_xxxxxxxxxxxx\_xxxxxxx::xxx\_xxxxxxxxx** xxxxxxxxxxxx xxxxxxx. Xxxxxxx, xxxxx xxxx `FeedData` xxxxxx xx xxxxxxxxxxx, xx xxxx xx xxx xx xx x [**Xxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh441570.aspx), xxxxx xx xxx x xxxxxx-xxxx xxxxxxxxxx. Xxxxxxxxx, xx xxxxxx x xxxxxxxxxxxx xxx xxxxxxx [**xxxx\_xxxxxxxxxxxx\_xxxxxxx::xxx\_xxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750085.aspx) xx xxxxxx xxxx xxx xxx xxxxx xx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206632) xxxxx xx xxx xxxx Xxxxxxxxxxx Xxxxxx-Xxxxxxxx Xxxxxxxxx (XXXX) xxxxxxx. Xxxxxxx [**xxxx\_xxxxxxxxxxxx\_xxxxxxx::xxx\_xxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750085.aspx) xx xxx xxxxxxx xxxxxxx, xx xxx’x xxxx xx xxxxxxx xx xxxxxxxxxx, xxx xx xx xx xxxx xxx xxx xxxx xx xxxxxxx.

``` cpp
#include <ppltasks.h>
void App::InitDataSource(Vector<Object^>^ feedList, vector<wstring> urls)
{
                using namespace concurrency;
    SyndicationClient^ client = ref new SyndicationClient();

    std::for_each(std::begin(urls), std::end(urls), [=,this] (std::wstring url)
    {
        // Create the async operation. feedOp is an 
        // IAsyncOperationWithProgress<SyndicationFeed^, RetrievalProgress>^
        // but we don’t handle progress in this example.

        auto feedUri = ref new Uri(ref new String(url.c_str()));
        auto feedOp = client->RetrieveFeedAsync(feedUri);

        // Create the task object and pass it the async operation.
        // SyndicationFeed^ is the type of the return value
        // that the feedOp operation will eventually produce.

        // Then, initialize a FeedData object by using the feed info. Each
        // operation is independent and does not have to happen on the
        // UI thread. Therefore, we specify use_arbitrary.
        create_task(feedOp).then([this]  (SyndicationFeed^ feed) -> FeedData^
        {
            return GetFeedData(feed);
        }, task_continuation_context::use_arbitrary())

        // Append the initialized FeedData object to the list
        // that is the data source for the items collection.
        // This all has to happen on the same thread.
        // By using the use_default context, we can append 
        // safely to the Vector without taking an explicit lock.
        .then([feedList] (FeedData^ fd)
        {
            feedList->Append(fd);
            OutputDebugString(fd->Title->Data());
        }, task_continuation_context::use_default())

        // The last continuation serves as an error handler. The
        // call to get() will surface any exceptions that were raised
        // at any point in the task chain.
        .then( [this] (task<void> t)
        {
            try
            {
                t.get();
            }
            catch(Platform::InvalidArgumentException^ e)
            {
                //TODO handle error.
                OutputDebugString(e->Message->Data());
            }
        }); //end task chain

    }); //end std::for_each
}
```

Xxxxxx xxxxx, xxxxx xxx xxx xxxxx xxxx xxx xxxxxxx xxxxxx x xxxxxxxxxxxx, xxx'x xxxxxxx xxxxxxxxx-xxxxxxxxx xx xxx xxxxxxx xxxx.

## Xxxxxxx xxxxxxxx xxxxxxx

Xxxxxxx xxxx xxxxxxx [**XXxxxxXxxxxxxxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206594) xx [**XXxxxxXxxxxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR206580withprogress_1) xxxxxxx xxxxxxxx xxxxxxx xxxxxxxxxxxx xxxxx xxx xxxxxxxxx xx xx xxxxxxxx, xxxxxx xx xxxxxxxxx. Xxxxxxxx xxxxxxxxx xx xxxxxxxxxxx xxxx xxx xxxxxx xx xxxxx xxx xxxxxxxxxxxxx. Xxx xxxx xxxxxx xxx xxxxxxxx xxx xxx xxxxxx’x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206594) xxxxxxxx. X xxxxxxx xxx xx xxx xxxxxxxx xx xx xxxxxx x xxxxxxxx xxx xx xxx XX.

## Xxxxxxx xxxxxx

* [Xxxxxxxx Xxxxxxxxxxxx Xxxxxxxxxx xx X++ xxx Xxxxxxx Xxxxx xxxx](createAsyncCpp)
* [Xxxxxx X++ Xxxxxxxx Xxxxxxxxx](http://msdn.microsoft.com/library/windows/apps/hh699871.aspx)
* [Xxxxxxxxxxxx Xxxxxxxxxxx](AsyncProgramming)
* [Xxxx Xxxxxxxxxxx (Xxxxxxxxxxx Xxxxxxx)](taskParallelism)
* [xxxx xxxxx](task-class)
 
<!-- LINKS -->
[AsyncProgramming]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh464924.aspx
[concurrencyNamespace]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dd492819.aspx
[createTask]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh913025.aspx
[createAsyncCpp]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750082.aspx
[deleteAsync]: https://msdn.microsoft.com/library/windows/apps/BR227199
[IAsyncAction]: https://msdn.microsoft.com/library/windows/apps/BR206580
[IAsyncOperation]: https://msdn.microsoft.com/library/windows/apps/BR206598
[IAsyncInfo]: https://msdn.microsoft.com/library/windows/apps/BR206587
[IAsyncInfoCancel]: https://msdn.microsoft.com/library/windows/apps/windows.foundation.iasyncinfo.cancel
[taskCanceled]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750106.aspx
[task-class]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750113.aspx
[taskGet]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750017.aspx
[taskParallelism]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dd492427.aspx
[taskThen]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750044.aspx
[useArbitrary]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh750036.aspx<!--HONumber=Mar16_HO1-->
