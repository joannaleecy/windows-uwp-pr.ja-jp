---
xxxxxxxxxxx: XxxXxxxxxx xxxxxxx x xxxxxxxxx xxx xxxx, xxxxxx xxx-xxx xxxxxxxxxxxxx xxxxxxx x xxxxxx xxx x xxxxxx xxxx xxx xxx xxxxx XXXX(X).
xxxxx: XxxXxxxxxx
xx.xxxxxxx: XXXYXXYX-YXYX-YXYY-YYYY-XXXYXXYYXYXY
---

# XxxXxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxxxx XXXx**

-   [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842)
-   [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923)

XxxXxxxxxx xxxxxxx x xxxxxxxxx xxx xxxx, xxxxxx xxx-xxx xxxxxxxxxxxxx xxxxxxx x xxxxxx xxx x xxxxxx xxxx xxx xxx xxxxx XXXX(X).

Xxxxx xxx [XxxXxxxxx Xxxxxxxx](http://tools.ietf.org/html/rfc6455), xxxx xx xxxxxxxxxxx xxxxxxxxxxx xxxx x xxxx-xxxxxx xxxxxx xxxxxx xxxxxxxxxx, xxxxxxxx xxxxxxxx xx xx xxxx xxx xxxxxxxx xxxx xxxx xxxxxxxxx xx xxxx xxxx. XxxXxxxxxx xxx xxxxx xxx xxx xx xxxx-xxxx xxxxxx xxxxx xxxxxxx xxxxxx xxxxxxx xxxxxxxxxxxxx xxx xx-xx-xxxx xxxxxxxx xx xxxxxxxxxxx (xxxx xxxxxxxxxx ) xxxx xx xx xxxxxx xxx xxx xxxx xxxx xxxxxxxx. Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxxxxx xxx xxx xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxxx xx xxxxxxx xxxx xxxxxxx xxxx xxxxxxx xxx Xxxxxxxxx xxxxxxxx.

| XxxxxxxXxxXxxxxx                                                         | XxxxxxXxxXxxxxx                                                                               |
|--------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| Xxxxxxxx xxx xxxxxxx xxxxxxxxx xxxxx xxxxxxxx xxx xxx xxxxxxxxx xxxxx.   | Xxxxxxxx xxx xxxxxxxxx xx xxxxx xxxxx xxxxx (xxxx xx xxxxxx xx xxxxxx) xxx xxxxx xxxxxxxxxxx. |
| Xxxxxxx xxxxxxxxxxxx xxxx xx xxxxxx XxxXxxxxx xxxxxxx xxx xxxx xxxxxxxx. | Xxxxxx xxxxxxxx xx x xxxxxxx xx xx xxxx xxxx xxxx xxxx xxxxxxxxx.                             |
| Xxxxxxxx xxxx XXX-Y xxx xxxxxx xxxxxxxx.                                 | Xxxxxxxx xxxx xxxxxx xxxxxxxx.                                                                |
| Xxxxxxx xx x XXX xx xxxxxxxx xxxxxx.                                     | Xxxxxxx xx x XXX xx xxxxxx xxxxxx.                                                            |

Xx xxxx xxxxx xxx'xx xxxx xx xxx x xxxxxx XxxXxxxxx xxxxxxxxxx xx xxxxxxx xxxx xxxx xxx xxxxxxxx. Xxxx xxxx xxxx xxxxxxxx xxx xxxxxxx xxxx xxxx xxxxxxxxxx xxxx xxxxxxx, xx xxxx xxxxxxx xxxx xxxxxx xxxxxxxxxxx XxxXxxxxx xxxxxxxxxxx. Xxx XxxXxxxxx xxxxxxxx xxxxxxx xxx xxxxxxxxx xxx XXX xxxxxxx.

-   xx: - xxx xxx xxxxxxxxxxx xxxxxxxxxxx.
-   xxx: - xxx xxx xxxxxx xxxxxxxxxxx xxxx xxxxxx xx xxxxxxxxx.

Xx xxxxxxx x XxxXxxxxx xxxxxxxxxx, xxx xxx xxx: XXX xxxxxx, xxx xxxxxxx, `wss://www.contoso.com/mywebservice`.

## Xxxxx XxxxxxxXxxXxxxxx

Xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxxxxx xxxxxxxx xx x xxxxxxx xx xx xxxx xxxx xxxx xxxx xxxxxxxxx. X **XxxxxxxXxxXxxxxx** xx xxxxxxxxx xxxx xx xxxxxxxxx xxxxx xxxxxxxx xxx xxx xxxxxxxxx xxxxx. Xxxx XXX-Y xxx xxxxxx xxxxx xxx xxxxxxxxx.

Xxx xxxx xx xxxx xxxxxxx xxxxxxx x xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842), xxxxxxxx xx x XxxXxxxxx xxxxxx, xxx xxxxx xxxx xx xxx xxxxxx. Xxxx x xxxxxxxxxx xxxxxxxxxx xx xxxxxxxxxxx, xxx xxx xxxxx xxx xxx [**XxxxxxxXxxXxxxxx.XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241358) xxxxx xx xx xxxxxxxxx, xxxxxxxxxx xxxx xxxx xxx xxxxxxxx.

Xxxx xxxxxx xxxx xxx XxxXxxxxx.xxx xxxx xxxxxx, x xxxxxxx xxxxx xxxxxx xxxxxx xxxx xx xxx xxxxxx xxx xxxxxx xxxx xx xx. Xx xxxxx xxx "xxx:" xxxxxxxx xxxxxxxxx, xxxx xxxxxx xxxx x xxxxxx xxxxxxxxxx xx xxxx xxx xxxxxxx xxxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cpp
> void Game::InitWebSockets()
> {
>     // Create a new web socket
>     m_messageWebSocket = ref new MessageWebSocket();
> 
>     // Set the message type to UTF-8
>     m_messageWebSocket->Control->MessageType = Windows::Networking::Sockets::SocketMessageType::Utf8;
> 
>     // Register callbacks for notifications of interest
>     m_messageWebSocket->MessageReceived += ref new TypedEventHandler<MessageWebSocket^, MessageWebSocketMessageReceivedEventArgs^>(this, &amp;Game:/:WebSocketMessageReceived);
>     m_messageWebSocket->Closed += ref new TypedEventHandler<IWebSocket^, WebSocketClosedEventArgs^>(this, &amp;Game::WebSocketClosed);
> 
>     // This test code uses the websocket.org echo service to illustrate sending a string and receiving the echoed string back
>     // Note that wss: makes this an encrypted connection.
>     m_serverUri = ref new Uri("wss://echo.websocket.org");
> 
>     // Establish the connection, and set m_socketConnected on success
>     create_task(m_messageWebSocket->ConnectAsync(m_serverUri)).then([this] (task<void> previousTask)
>     {
>         try
>         {
>             // Try getting all exceptions from the continuation chain above this point.
>             previousTask.get();
> 
>             // websocket connected. update state variable
>             m_socketConnected = true;
>             OutputDebugString(L"Successfully initialized websockets\n");
>         }
>         catch (Platform::COMException^ exception)
>         {
>             // Add code here to handle any exceptions
>             // HandleException(exception);
> 
>         }
>     });
> }
> ```
> ```cs
> MessageWebSocket webSock = new MessageWebSocket();
> 
> //In this case we will be sending/receiving a string so we need to set the MessageType to Utf8.
> webSock.Control.MessageType = SocketMessageType.Utf8;
> 
> //Add the MessageReceived event handler.
> webSock.MessageReceived += WebSock_MessageReceived;
> 
> //Add the Closed event handler.
> webSock.Closed += WebSock_Closed;
> 
> Uri serverUri = new Uri("wss://echo.websocket.org");
> 
> try
> {
>     //Connect to the server.
>     await webSock.ConnectAsync(serverUri);
> 
>     //Send a message to the server.
>     await WebSock_SendMessage(webSock, "Hello, world!");
> }
> catch (Exception ex)
> {
>     //Add code here to handle any exceptions
> }
> ```

Xxxx xxx xxxx xxxxxxxxxxx xxx XxxXxxxxx xxxxxxxxxx, xxxx xxxx xxxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx xx xxxxxxxx xxxx xxx xxxxxxx xxxx.

### Xxxxxxxxx x xxxxxxxx xxx xxx XxxxxxxXxxXxxxxx.XxxxxxxXxxxxxxx xxxxx

Xxxxxx xxxxxxxxxxxx x xxxxxxxxxx xxx xxxxxxx xxxx xxxx x XxxXxxxxx, xxxx xxx xxxxx xx xxxxxxxx xx xxxxx xxxxxxxx xx xxxxxxx xxxxxxxxxxxx xxxx xxxx xx xxxxxxxx. Xxxx xxx [**XxxxxxxXxxXxxxxx.XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241358) xxxxx xxxxxx, xxx xxxxxxxxxx xxxxxxxx xx xxxxxx xxx xxxxxxxx xxxx xxxx [**XxxxxxxXxxXxxxxxXxxxxxxXxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br226852). Xxxx xxxxxxx xx xxxxxxx xxxx xxx xxxxxxxxxx xxxx xxx xxxxxxxx xxxxx xxxx xxx xx XXX-Y xxxxxx.

Xxx xxxxxxxxx xxxxxx xxxxxxxx xxxxxxxx x xxxxxx xxxx x xxxxxxxxx XxxXxxxxx xxxxxx xxx xxxxxx xxx xxxxxx xx xxx xxxxxxxx xxxxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cpp
void Game::WebSocketMessageReceived(MessageWebSocket^ sender, MessageWebSocketMessageReceivedEventArgs^ args)
{
    DataReader^ messageReader = args->GetDataReader();
    messageReader->UnicodeEncoding = Windows::Storage::Streams::UnicodeEncoding::Utf8;

    String^ readString = messageReader->ReadString(messageReader->UnconsumedBufferLength);
    // Data has been read and is now available from the readString variable.
    swprintf(m_debugBuffer, 511, L"WebSocket Message received: %s\n", readString->Data());
    OutputDebugString(m_debugBuffer);
}
```
```csharp
//The MessageReceived event handler.
private void WebSock_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
{
    DataReader messageReader = args.GetDataReader();
    messageReader.UnicodeEncoding = UnicodeEncoding.Utf8;
    string messageString = messageReader.ReadString(messageReader.UnconsumedBufferLength);

    //Add code here to do something with the string that is received.
}
```

###  Xxxxxxxxx x xxxxxxxx xxx xxx XxxxxxxXxxXxxxxx.Xxxxxx xxxxx

Xxxxxx xxxxxxxxxxxx x xxxxxxxxxx xxx xxxxxxx xxxx xxxx x XxxXxxxxx, xxxx xxx xxxxx xx xxxxxxxx xx xxxxx xxxxxxxx xx xxxxxxx xxxxxxxxxxxx xxxx xxx XxxXxxxxx xx xxxxxx xx xxx XxxXxxxxx xxxxxx. Xxxx xxx [**XxxxxxxXxxXxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701364) xxxxx xxxxxx, xxx xxxxxxxxxx xxxxxxxx xx xxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxx xxxxxx xx xxx XxxXxxxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cpp
void Game::WebSocketClosed(IWebSocket^ sender, WebSocketClosedEventArgs^ args)
{
    // The method may be triggered remotely by the server sending unsolicited close frame or locally by Close()/delete operator.
    // This method assumes we saved the connected WebSocket to a variable called m_messageWebSocket
    if (m_messageWebSocket != nullptr)
    {
        delete m_messageWebSocket;
        m_messageWebSocket = nullptr;
        OutputDebugString(L"Socket was closed\n");
    }
    m_socketConnected = false;
 }
```
```csharp
//The Closed event handler
private void WebSock_Closed(IWebSocket sender, WebSocketClosedEventArgs args)
{
    //Add code here to do something when the connection is closed locally or by the server
}
```

###  Xxxx x xxxxxxx xx x XxxXxxxxx

Xxxx x xxxxxxxxxx xx xxxxxxxxxxx, xxx XxxXxxxxx xxxxxx xxx xxxx xxxx xx xxx xxxxxx. Xxx [**XxxxXxxxxx.XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208171) xxxxxx xxxxxxx x xxxxxxxxx xxxx xxxx xx xx xxxxxxxx xxx. Xxxx xxxxxxx xxx xx xxxxxx xxx xxxx xx xxxx xxx xxxxxxx xxxxxxxx xxxx xxx xxxx xx xxxx xxx xxxxxxxxxx.

**Xxxx**   Xxxx xxx xxxxxx x xxx XxxxXxxxxx xxxxxx xxxxx xxx XxxxxxxXxxXxxxxx'x XxxxxxXxxxxx, xxx XxxxXxxxxx xxxxx xxxxxxxxx xx xxx XxxxxxXxxxxx, xxx xxxx xxxxxxxxxx xxx Xxxxxxxxxxxx xxxx xxx XxxxXxxxxx xxxx xxx xx xxxxx. Xxxx xxxxxx xxx xxxxxxxxxx xxxxxxxx xx xxx xxx XxxxxxXxxxxx xx xxxx xxxx xx XXXXXXX xxxxx xx YxYYYYYYYY. Xx xxxxx xxxxxxxxxxxx xxx XxxxxxXxxxxx, xxxx xxxx xxxxx xxx XxxxXxxxxx'x XxxxxxXxxxxx xxxxxx, xxxxx xxxxxxx xxxxxxxxx xx xxx xxxxxx xx xxx XxxXxxxxx xxxxxx.

Xxx xxxxxxxxx xxxxxxxx xxxxx xxx xxxxx xxxxxx xx x xxxxxxxxx XxxXxxxxx, xxx xxxxxx x xxxxxxxxxxxx xxxxxxx xx xxx xxxxxxxx xxxxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cpp
void Game::SendWebSocketMessage(Windows::Networking::Sockets::MessageWebSocket^ sendingSocket, Platform::String^ message)
{
    if (m_socketConnected)
    {
        // WebSocket is connected, so send a message
        m_messageWriter = ref new DataWriter(sendingSocket->OutputStream);

        m_messageWriter->WriteString(message);

        // Send the data as one complete message
        create_task(m_messageWriter->StoreAsync()).then([this] (unsigned int)
        {
            // Send Completed
            m_messageWriter->DetachStream();    // give the stream back to m_messageWebSocket
            OutputDebugString(L"Sent websocket message\n");
        })
            .then([this] (task<void>> previousTask)
        {
            try
            {
                // Try getting all exceptions from the continuation chain above this point.
                previousTask.get();
            }
            catch (Platform::COMException ^ex)
            {
                // Add code to handle the exception
                // HandleException(exception);
            }
        });
    }
}
```
```csharp
//Send a message to the server.
private async Task WebSock_SendMessage(MessageWebSocket webSock, string message)
{
    DataWriter messageWriter = new DataWriter(webSock.OutputStream);
    messageWriter.WriteString(message);
    await messageWriter.StoreAsync();
}
```

## Xxxxx xxxxxxxx xxxxxxxx xxxx XxxXxxxxxx

[
            **XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxx xxxxxxxx. Xxxxxxxxxxxxx xxxx xxxx xx xxx xxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxxxx xx xxxxxx xxxxxxxx xxxxxxxx.

[
            **XxxxxxxXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226843) xxxxxxxx xxxxxx xxxxxxx xxxx xx x [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxxxxx.
[
            **XxxxxxXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226924) xxxxxxxx xxxxxx xxxxxxx xxxx xx x [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxx.
Xxx xxxxx xxxxx xx xxx xxxxxxxx xxxxxxxx xx xxx xxxx xxx xxxx xxxxx xx XxxXxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx xxxx x [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xx xx xxxxxxx, xxx xxx xxxx xxxxxxx xxx xx xxxx xxxx x [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842).

1.  Xxxxxx xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxx.
2.  Xxx xxx [**XxxxxxXxxXxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226934) xxxxxxxx xx xxxxxxxx xxx [**XxxxxxXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226924) xxxxxxxx xxxxxxxxxx xxxx xxxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxx.
3.  Xxx xx xxx xxxxxxxxxx xx xxx [**XxxxxxXxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226924) xxxxxxxx xx xxx xx xxx xxxxxxxx xxxxxxxx xxxxxxxx.

Xxxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxxxxx xxxxxxxxxxxx xx xxxx xxxxxxxx xxxxxxxx xxx xx xxx.

-   Xxx xxx xxxxxxxx xxxxxxxx xx xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923), xxx xxx xxxx xxxxxx xxx xxx xxxxxxxx xxxxxx xxxxxxx x Xxxxxxx xxxxxxxxx. Xxxxxxx xx xxxx xxxxxxxxxxx, xx xx xxxx xxxxxxxx xx xxx xxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx xxxxx xxxxxxxx xxx **XxxxxxXxxXxxxxx** xxxxxx. Xx xxx xxx xx xxx x xxxxxxx xxxxxxxx xxxxx xxx [**XxxxxxXxxXxxxxx.XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br226933) xxxxxx xxx xxxx xxxxxx.
-   Xxx xxx xx xxx xxxxxxxx xxxxxxxx xx xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxxxxx xxx xxxxxxx xxxx, xxx xxxx xxx xxx xxxxxxxx xxxxxx xxxxxxx x Xxxxxxx xxxxxxxxx. Xx xx xxxx xxxxxxxx xx xxx xxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx xxxxx xxxxxxxx xxx **XxxxxxxXxxXxxxxx** xxxxxx. Xxxxxx xxx xxx xxxxxxx xxxx, xx xxx xxxxxxx xx xxxxxx x xxxxxxx xxxxxxxx xxxxx [**XxxxxxxXxxXxxxxx.XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br226859) xxx xxxx xxxxxx.

## XxxXxxxxx xxxxxxxxxxx xxxxxxx

[
            **XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxx xxxx x xxxxxxxxxxxxx xxxxx xxxx xxxxxxxx xxxxxxxxxx xxxxxxxxxxx xxxxx x XxxXxxxxx xxxxxxxx.

[
            **XxxxxxxXxxXxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226849) xxxxxxxx xxxxxxxxxxx xxxxx x [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842), xxx xxx xxxxxxxx xx xxxxxxxx xx xxx xxxxxxxxxxx xxxxx xxxxx xxx [**XxxxxxxXxxXxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226861) xxxxxxxx.

[
            **XxxxxxXxxXxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226929) xxxxxxxx xxxxxxxxxxx xxxxx x [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923), xxx xxx xxxxxxxx xx xxxxxxxx xx xxx xxxxxxxxxxx xxxxx xxxxx xxx [**XxxxxxXxxXxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226935) xxxxxxxx.

Xxxx xxxx xxx xx xxx xxxxxxxxxx xx xxxx Xxxxxxxxxxx xxxxxxx xxx xxxx-xxxx, xxx xxxx xxx xxx xxxxxxxx xxxxxxx xxxxxxxxxxx xx xxx xxxx xxxxxx xxx xxxxxxxx xx x xxx xxxxxx xxxxxx.

## Xxxxxxxx xxxxxxx xxxxxxxxxx

Xx xxxxx xxxxxxxxxxx xx x [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxxxxx xx xxxxxxxx xx xx **XXXXXXX** xxxxx. Xxx [**XxxXxxxxxXxxxx.XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701529) xxxxxx xx xxxx xx xxxxxxx x xxxxxxx xxxxx xxxx x XxxXxxxxx xxxxxxxxx xx x [**XxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh747818) xxxxxxxxxxx xxxxx. Xxxx xx xxx **XxxXxxxxXxxxxx** xxxxxxxxxxx xxxxxx xxxxxxxxxx xx xx xxxxx xxxxxxxx xx xxx xxxxxx XXXX xxxxxx xxxxxxxxx. Xxxx xxx xxx xxxxxx xx xxxxxxxx **XxxXxxxxXxxxxx** xxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxx xx xxx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxxxxxx xxxxxx, xx xxx xxx xxxx xxx xxx **XXXXXXX** xxxx xxx xxxxxxxxx xx xxxxx xxxx xxxxxxxx xxxxxxxxxxx xx xxx xxxxx xxxx xxxxxx xxx xxxxxxxxx. Xxxxxxxx **XXXXXXX** xxxxxx xxx xxxxxx xx xxx *Xxxxxxxx.x* xxxxxx xxxx. Xxx xxxx xxxxxxxxx xxxxxxxxxx xxxxxx, xxx **XXXXXXX** xxxxxxxx xx **X\_XXXXXXXXXX**.

## Xxxxxxx xxxxxxxx xx XxxXxxxxx xxxxxxxxxx

Xxx XxxxxxxXxxXxxxxx xxx XxxxxxXxxXxxxxx xxxxxxx xxxx xx xxxxxxxx xxxxxx xxxxxxx xx xxxx XxxXxxxxx xxxxxx xxxxxxxx xxx xxxxxxx xxxxxxxxx xxxx x xxxxxx. Xxx xxxxxxx xxxxxxx xxxxx xxxx xxx x XxxXxxxxx xxxxxxx xxxxxxxxx xx YY xxxxxxx. Xx xxx XXXX xxxxxx xxxx xxxxxxxx XxxXxxxxxx xx xxxxxxxxxxx xxxx xx xxxxxxx xx x xxxxxxx xxxxxx xxx xxx xxxxxx xxxxx'x xx xxx'x xxxxxxx xx xxx XxxXxxxxx xxxxxxxxxx xxxxxxx, xxx xxxxxxxx xxxxxx xxxxxxx xxxxx xxx xxxxxxx YY xxxxxxx xxxxxx xx xxxxxxx xx xxxxx xxxxx xxxxxx xx xxxxxxxxx xx xx xxxxxx xx xxx XxxXxxxxx XxxxxxxXxxxx xxxxxx. Xx xxx xxxx xxxxx xxx xx XXXX xxxxxx xxxx xx xxx XXX xxxxxxx xxxxxxxx XX xxxxxxxxx xxx xxx xxxx, xxx xxxxxxxx xxxxxx xxxxxxx xxxxx xx xx Y XX xxxxxxxxx xxx xxx xxxx xxxx xxxx x xxxxxxx xxxxxxx xx YY xxxxxxx xxxxxx xx xxxxx. Xx xxx xxxxxx x XxxXxxxxx xxxxxxxxxx xxxxxxx xxxxx xxxx xxxxxxx xxxxxxx xxxxxx xx xxxxxxx xx xxxxxxxx XX xxxxxxxxx xxxxxx xx xxxxx xx xxxxxxxx xxx xx xxxxxxxxx xx xxxxxx. Xxxx xxxxxxxx xxxxx xxxxxx xx xxx xxxx xx xx xxx xxx xxxxxxx xxxxxxx. Xxx xxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxxxxx xxxxxxxxxx xxxxx x XxxXxxxxx xxxxxxxxxx xxx xxxx xxxxxxxxxxx xx YY xxxxxxx.

Xx xxxx xxxx xxx xxxx xxxxxxxxxx xxx xxxxxxxx xxxxx xxxxxx, xx xxx xxx x xxxxxxx xxxxxxx xx xxxxxxxxxx xxxxxxxx xx xxxx xxx xxxxxxxxx xxxxx xxx xx xxxxxxx xxxxxx xxxx xxxx xxx xxxxxxx xxxxxxxx.

Xxx xxx xxxxxxxx xxxxxxxxx xxx xxxx XxxxxxXxxXxxxxxx xxx XxxxxxxXxxXxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxxx xxx xx xxx x xxxxxxx xx XxxxxxXxxXxxxxx, xxx xxx xxxxxxx xx xxxxxxx xxx x XxxxxxxXxxXxxxxx.

1.  Xxxxxx x xxxx xxxx xxxxxxxxx xxxxx x xxxxxxxxx xxxxx xxxxx x xxxxx.
2.  Xxxxxx x xxxx xxx xxx XxxXxxxxx xxxxxxxxx xxxx x xxxxxxxxxxxx\_xxxxx\_xxxxxx xx xxxxxxx xxxxxxxxxxxx.
3.  Xx xxx xxxx xxxx xxx xxxxxxxxx xxxxxxx xxxxx xxxxxxxxx xxxxxx xxx XxxXxxxxx xxxxxxx xxxxxxxxx, xxxxxx xxx xxxx xxx xxx XxxXxxxxx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx xxx xxxx xxxx xxxxxxxxx xxxxx x xxxxxxxxx xxxxx, xxx xxxxxxx x xxxxxx xxxx xxxx xxxxxxx xxxxx x xxxxxxxxx xxxxx. Xxxxx xxxxxxx xxx xx xxxx xxxx XxxxxxXxxXxxxxx xxx XxxxxxxXxxXxxxxx xxxx xxxxxx xx xxxxxxxxx x xxxxxxxxxx xx xxx x xxxxxxxx xxxxxxx. Xx xxxxxxx xxxxx xxxxx xx xxxxxxx xxx XxxxxxXxxXxxxxx.XxxxxxxXxxxx xxxxxx xx x xxxx xxxx x xxxxxxxxxxxx\_xxxxx\_xxxxxx xxxx xxxxxxxx xxxxxxxxxxxx. Xx xxxxxxx xxxxxxxxx xxxxx, xxxx xxx xxxxxxxxxxxx\_xxxxx\_xxxxxx xx xxxx xx xxxxxx xxx xxxx xxx xxx XxxXxxxxx xxxxxxx xxxxxxxxx.

```cpp
    #include <agents.h>
    #include <ppl.h>
    #include <ppltasks.h>

    using namespace concurrency;
    using namespace std;

    // Creates a task that completes after the specified delay.
    task<void> complete_after(unsigned int timeout)
    {
        // A task completion event that is set when a timer fires.
        task_completion_event<void> tce;

        // Create a non-repeating timer.
        shared_ptr<timer<int>> fire_once(new timer<int>(timeout, 0, nullptr, false));
        
        // Create a call object that sets the completion event after the timer fires.
        shared_ptr<call<int>> callback(new call<int>([tce](int)
        {
            tce.set();
        }));

        // Connect the timer to the callback and start the timer.
        fire_once->link_target(callback.get());
        fire_once->start();

        // Create a task that completes after the completion event is set.
        task<void> event_set(tce);

        // Create a continuation task that cleans up resources and
        // and return that continuation task.
        return event_set.then([callback, fire_once]()
        {
        });
    }

    // Cancels the provided task after the specifed delay, if the task
    // did not complete.
    template<typename T>
    task<T> cancel_after_timeout(task<T> t, cancellation_token_source cts, unsigned int timeout)
    {
        // Create a task that returns true after the specified task completes.
        task<bool> success_task = t.then([](T)
        {
            return true;
        });
        // Create a task that returns false after the specified timeout.
        task<bool> failure_task = complete_after(timeout).then([]
        {
            return false;
        });

        // Create a continuation task that cancels the overall task  
        // if the timeout task finishes first. 
        return (failure_task || success_task).then([t, cts](bool success)
        {
            if (!success)
            {
                // Set the cancellation token. The task that is passed as the 
                // t parameter should respond to the cancellation and stop 
                // as soon as it can.
                cts.cancel();
            }
 
            // Return the original task.
            return t;
        });
    }
```

<!--HONumber=Mar16_HO1-->
