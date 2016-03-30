---
xxxxxxxxxxx: Xxxx xxx xxxxxxxxxx xxxxx xxx xxx xxxx xxxxxxxxxx xx xxxxxxxx xxxxxxxxxxxxxx xxxx xxxx xxx xxx xx xxx xxxxxxxxxx.
xxxxx: Xxxxxxx xxxxxxxxxxxxxx xx xxx xxxxxxxxxx
xx.xxxxxxx: YYYXYXYY-YYYY-YYYX-YYXY-YYXYYYYXYXXY
---

# Xxxxxxx xxxxxxxxxxxxxx xx xxx xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn806009)
-   [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032)

Xxxx xxx xxxxxxxxxx xxxxx xxx xxx xxxx xxxxxxxxxx xx xxxxxxxx xxxxxxxxxxxxxx xxxx xxxx xxx xxx xx xxx xxxxxxxxxx: Xxx xxxxxx xxxxxx, xxx xxxxxxx xxxxxxx xxxxxxxx. Xxxx xxxx xxx xxxxxxx xxx xxxxxxxx xxxxxxxxx xx x xxxxxx xx x xxxxxx xxxxxx xxxxxx xxxx xxxx xxxxx xxx xxxxxxxxxx. Xxx xxxxxx xxxx xxxxxxxxx xxx xxx xxxx xxxxxxx xxxxxxx xx xxx xxxxxx, xxxxxxxxx xxxxxxxxx xxxx xx xxx xxx, xxx xxx xxx xxxxxxxxx xxx xxxxxxxx xxxxxxx.

## Xxxxxx xxxxxx xxx xxx XxxxxxXxxxxxxxXxxxxxx

Xx xxxx xxx xxxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319), [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882), xx [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906) xxxxxxxxxxx, xxxx xxx xxxxxx xxx [**XxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn806009) xxx xxx xxxxxx xxxxxx xx xx xxxxxxxx xxxx xxxxxxx xxxxxxx xxx xxxx xxx xxxxx xx'x xxx xx xxx xxxxxxxxxx.

Xx xxxxx xxx xxxx xxx xx xxxxxxx xxx xxxxxxx xxxx xxxxxxxx xx x xxxxxx xxxx xxxx xxx xx xxx xxxxxx, xxxx xxx xxxx xxxxxxx xxxx xxx-xxxx xxxxx xx xxxxxxx, xxx xxxx xxxxxxxx xxxxxx xxxxxxxxx xx xxx xxxxxx xxxxxx xxxx xx xx xxxxxxxxxxxxx xx x xxxxx xxxxx xx xx xxx xxxxxx.

-   Xxx xxx-xxxx xxxxx xxxxx xxx:

    -   Xxxxxx x XxxxxxXxxxxxxxXxxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx xxx xxx xxxxxxx xxxx xxx XxxxXxxxxXxxxx xxxxxxxxx xxx xx xxxx xxxx xxx xxxxxxxxxx x xxxxxxxx xxxxxx.

```csharp
            var socketTaskBuilder = new BackgroundTaskBuilder(); 
            socketTaskBuilder.Name = _backgroundTaskName; 
            socketTaskBuilder.TaskEntryPoint = _backgroundTaskEntryPoint; 
            var trigger = new SocketActivityTrigger(); 
            socketTaskBuilder.SetTrigger(trigger); 
            _task = socketTaskBuilder.Register(); 
```

    -   Call EnableTransferOwnership on the socket, before you bind the socket.


```csharp
           _tcpListener = new StreamSocketListener(); 
          
           // Note that EnableTransferOwnership() should be called before bind, 
           // so that tcpip keeps required state for the socket to enable connected 
           // standby action. Background task Id is taken as a parameter to tie wake pattern 
           // to a specific background task.  
           _tcpListener. EnableTransferOwnership(_task,SocketActivityConnectedStandbyAction.Wake); 
           _tcpListener.ConnectionReceived += OnConnectionReceived; 
           await _tcpListener.BindServiceNameAsync("my-service-name"); 
```

-   Xxx xxxxxx xx xxxx xx xxxxxxx xx:

    Xxxx xxxx xxx xx xxxxx xx xxxxxxx, xxxx **XxxxxxxxXxxxxxxxx** xx xxx xxxxxx xx xxxxxxxx xx xx x xxxxxx xxxxxx. Xxx xxxxxx xxxxxxxx xxx xxxxxx xxx xxxxxxxxx xxxx xxxxxxxxxx xxxx xxxx xxxx xx xxxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxxxxxx x xxxxxxx **XxxxxxxxXxxxxxxxx** xxxxxxxx xx xxxxxxx xxx xxxxxxxx xxx **XxxxxxXxxxxxXxxxxxxx** xxxxxxx. (Xxxx xxxx xxx xxxxxxxxx xxxxx xx xxxxxxx xxxx xxxx xxxxx xxx **XxxxxxxxXxxxxxxxx** xxxxxx, xx xxx xxxx xxxx xxx xxxxxx xxxxxxxxxxx xxx xxx xxxxxx xxxxx xxxxxxxxx xxx xxx xxxxxxxxxxxx. Xxxx xxxx xxxxx xxxxxxxx xxxxxxx xx xxxxxxxxxx **XxxxxxxxXxxxxxxxx** xxxxxx xxxx xxx xxxxxxxxxxxxxx xxx xxxx xxxxxx xxxx xxx xxx, xx xxxx xxx **XxXxxxxxxxxx** xxxx xxxxxxx xxxx xx xxxx.)

    Xx xxx xxxxxxxxx xxxxxxxxx xx x xxxxxx xx x xxxxxx xxxxxx xxx xxxxxx xxx XX xxx xxx xxxxxxxxxx xxxx xxxxx xxx xxxxxxxxxxx xxx xx xxx xxxxxxxxx xxxxxxx:

    -   Xxx xx xxx [**XxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn804256) xxxxxxx xx x [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319).
    -   Xxx xx xxx [**XxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn781433) xxxxxxx xx x [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882).
    -   Xxx xx xxx [**XxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn804407) xxxxxxx xx x [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906).

```csharp
    private void TransferOwnership(StreamSocketListener tcpListener) 
    { 
        await tcpListener.CancelIOAsync(); 

        var dataWriter = new DataWriter(); 
        _transferOwnershipCount++; 
        dataWriter.WriteInt32(transferOwnershipCount); 
        var context = new SocketActivityContext(dataWriter.DetachBuffer()); 
        tcpListener.TransferOwnership(_socketId, context); 
    } 
    
    private void OnSuspending(object sender, SuspendingEventArgs e) 
    { 
        var deferral = e.SuspendingOperation.GetDeferral(); 

        TransferOwnership(_tcpListener); 
        deferral.Complete(); 
    } 
```

-  Xx xxxx xxxxxxxxxx xxxx'x xxxxx xxxxxxx:

   -  Xxxxx, xxx x xxxxxxxxxx xxxx xxxxxxxx xx xxxx xxx xxx xxxxxx xxx xxxxx xxxxx xxxxxxxxxxxx xxxxxxx.

```csharp
var deferral = taskInstance.GetDeferral();
```

   -  Xxxx, xxxxxxx xxx XxxxxxXxxxxxxxXxxxxxxXxxxxxx xxxx xxx xxxxx xxxxxxxxx, xxx xxxx xxx xxxxxx xxxx xxx xxxxx xxx xxxxxx:

```csharp
var details = taskInstance.TriggerDetails as SocketActivityTriggerDetails; 
    var socketInformation = details.SocketInformation; 
    switch (details.Reason) 
```

    -   If the event was raised because of socket activity, create a DataReader on the socket, load the reader asynchronously, and then use the data according to your app's design. Note that you must return ownership of the socket back to the socket broker, in order to be notified of further socket activity again.

        In the following example, the text received on the socket is displayed in a toast.

```csharp
case SocketActivityTriggerReason.SocketActivity: 
            var socket = socketInformation.StreamSocket; 
            DataReader reader = new DataReader(socket.InputStream); 
            reader.InputStreamOptions = InputStreamOptions.Partial; 
            await reader.LoadAsync(250); 
            var dataString = reader.ReadString(reader.UnconsumedBufferLength); 
            ShowToast(dataString); 
            socket.TransferOwnership(socketInformation.Id); /* Important! */
            break; 
```

    -   If the event was raised because a keep alive timer expired, then your code should send some data over the socket in order to keep the socket alive and restart the keep alive timer. Again, it is important to return ownership of the socket back to the socket broker in order to receive further event notifications:

```csharp
case SocketActivityTriggerReason.KeepAliveTimerExpired: 
            socket = socketInformation.StreamSocket; 
            DataWriter writer = new DataWriter(socket.OutputStream); 
            writer.WriteBytes(Encoding.UTF8.GetBytes("Keep alive")); 
            await writer.StoreAsync(); 
            writer.DetachStream(); 
            writer.Dispose(); 
            socket.TransferOwnership(socketInformation.Id); /* Important! */
            break; 
```

    -   If the event was raised because the socket was closed, re-establish the socket, making sure that after you create the new socket, you transfer ownership of it to the socket broker. In this sample, the hostname and port are stored in local settings so that they can be used to establish a new socket connection:

```csharp
case SocketActivityTriggerReason.SocketClosed: 
            socket = new StreamSocket(); 
            socket.EnableTransferOwnership(taskInstance.Task.TaskId, SocketActivityConnectedStandbyAction.Wake); 
            if (ApplicationData.Current.LocalSettings.Values["hostname"] == null) 
            { 
                break; 
            } 
            var hostname = (String)ApplicationData.Current.LocalSettings.Values["hostname"]; 
            var port = (String)ApplicationData.Current.LocalSettings.Values["port"]; 
            await socket.ConnectAsync(new HostName(hostname), port); 
            socket.TransferOwnership(socketId); 
            break; 
```

-   Xxx'x xxxxxx xx Xxxxxxxx xxxx xxxxxxxx, xxxx xxx xxxx xxxxxxxx xxxxxxxxxx xxx xxxxx xxxxxxxxxxxx:

```csharp
  deferral.Complete();
```

Xxx x xxxxxxxx xxxxxx xxxxxxxxxxxxx xxx xxx xx xxx [**XxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn806009) xxx xxxxxx xxxxxx, xxx xxx [XxxxxxXxxxxxxxXxxxxxXxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620606). Xxx xxxxxxxxxxxxxx xx xxx xxxxxx xx xxxxxxxxx xx XxxxxxxxY\_Xxxxxxx.xxxx.xx, xxx xxx xxxxxxxxxx xxxx xxxxxxxxxxxxxx xx xx XxxxxxXxxxxxxxXxxx.xx.

Xxx xxxx xxxxxxxx xxxxxx xxxx xxx xxxxxx xxxxx **XxxxxxxxXxxxxxxxx** xx xxxx xx xx xxxxxxx x xxx xxxxxx xx xxxxxxxx xx xxxxxxxx xxxxxx, xxxxxx xxxx xxxxx xxx **XxXxxxxxxxxx** xxxx xxxxxxx xx xx xx xx xxxxxxxxx xx xxxx xxxxx. Xxxx xx xxxxxxx xxx xxxxxx xxxxxxx xx xxxxxxxxxxxxx xxx [**XxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn806009), xxx xxxxx'x xxx xxx xxxxxx xxx xxx xxxxx xxxxxxxx xxxxx xx xx xxxxxxx. Xxxx xxx xxxx xxxxxxxx xx xxxx xxxxxxx, xxx xxxxxx xxx **XxXxxxxxxxxx** xx xxxxxxxxx xxxx xx xxxx **XxxxxxxxXxxxxxxxx**.

## Xxxxxxx xxxxxxx xxxxxxxx

Xxxxx, xxxxxx xxxx xxx'xx xxxxx xxxxxxx xxxxxxx xxxxxxxx (XXXx) xxxxxxxxxxxxx. Xx xxx'xx xxxxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319), [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882), xx [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906) xxxxxxxxxxx, xx xxxxxxxxx xxx xxx [**XxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn806009). Xxx xxx xxx XXXx xxx **XxxxxxXxxxxx**, xxx xxxx xxx xxxx xxxxxxxxx xxx xxxxx xxx xxxx xx Xxxxxxxxx Xxxxxxx xxxx.

Xx xxx xxx xxxxx XxxXxxxxxx, [**XXXXXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh831151), [**Xxxxxx.Xxx.Xxxx.XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298639) xx **Xxxxxxx.Xxx.Xxxx.XxxxXxxxxx**, xxx xxxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032).

## XxxxxxxXxxxxxxXxxxxxx xxxx XxxXxxxxxx

Xxxx xxxxxxx xxxxxxxxxxxxxx xxxxx xxxx xxxxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032). Xxxxx xxx xxxx xxxxxxxxx-xxxxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxxx xx xxxxxxxx xxxx xxxxx x **XxxxxxxXxxXxxxxx** xx **XxxxxxXxxXxxxxx** xxxx **XxxxxxxXxxxxxxXxxxxxx**. Xx xxxxxxxx, xxxxx xxxxxxxxxxxxxx xxxxxx xxx xxx xxxx xxxxxxxx xx xxxxxxx xxxxxxx xx xxx **XxxxxxXxxXxxxxx** xxx xxxxxxx. Xxxxxxxx xx xxxxxxx xxxxxxx xx xxx **XxxxxxxXxxXxxxxx** xxx xxx xxxxxxxx.

Xxx xxxxxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxxxxx xxxxxx xx xxxxxxxx xxxx xxxxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032):

-   Xx xxxxxxxxxxx xxxxxx xxxxxxx xxxx xx xxxx xxxxxx xx xxx xxxxx. Xxxx xx xxxxxxxx xx xxxxx xxx xxxx xxxxxxxxxxxx xxxxx xx xxxxx.
-   Xxx XxxXxxxxx xxxxxxxx xxxxxxx x xxxxxxxx xxxxx xxx xxxx-xxxxx xxxxxxxx. Xxx [**XxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701531) xxxxx xxx xxxx xxxxxx-xxxxxxxxx XxxXxxxxx xxxxxxxx xxxx-xxxxx xxxxxxxx xx xxx xxxxxx. Xxx **XxxXxxxxxXxxxXxxxx** xxxxx xxxxxx xx xxxxxxxxxx xx xxx XxxxXxxxxXxxxx xxx x XxxxXxxxxXxxxxxx xx xxx xxx.

Xxxx xxxxxxx xxxxxxxxxxxxxx xxxxxx xxx xxx xxxx xxxxxxxx xx xxxxxxx xxxxxxx xx xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxx xxxxxxx. Xx xxxxxxxxxx, xxxx xxxxx x **XxxxxxXxxXxxxxx** xxxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032), xxxx xxx xxxx xxx x xxx xxxxx xxxxxxx xxx xxxxxxxx xxxxx xxxxxxx xx xxx **xxxxx** xxxxx xx X# xxx XX.XXX xx Xxxxx xx X++. Xxx xxx xxxxx xxxxxxx xx xxxxxxxxxxx xx x xxxx xxxxxx xxxxx xx xxxx xxxxxxx.

Xxxxx xxx xxx xxxxx xxxxxxx xxxxxx Xxxxxxx xx xxxxxxxxxxx xxx [**XXxxxxxxxxxXxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/br224811) xxxxxx xx xxx xxxxxxxxxx xxxx xxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xxxx xxx xxxxxx xx xxx xxxxxxx xxxxxxxxxx xxxxxxxx. Xxx **Xxx** xxxxxx xx xxxxxxx xxxxx xxx xxxxxxxxxx xxxxxxxx xxxxxxx. Xxxx xxxxxxx xxxx xxx xxx xxx xxxxxxxx xxx xxxx/xxxxxx xxxxxx xxx **Xxx** xxxxxx xx xxxxxxx.

Xx xx xxxxxxxxx xx xxxx xxxx xxx xxx xxx xx xxxx xxxxxxx xxxx xxxxxx xx xxxxxxx xxxxxxx xxxx xxx xxxxxxxxxx xxxxxxxx. Xx xx xxxx xxxxxxxxx xx xxxx xxxx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208119) xxxxxx xx xxxxxxxx xxxx xxxx xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxxxxx xxxxx xxxx xxxxxx xxx xxxxxxxxxxxxxxx xxxxxxxxx xxxxx. Xx xx xxx xxxxxxxxx xx xxx xxx [**XxxxXxxxxx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208135) xxxxxx xxxxxxxx xx xxx xx xxx xxxxxxxxx. Xxxxxxx, xxx [**XXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241656) xxxxxxxx xx xxx [**XXxxxxXxxxxx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br241719) xxxxxx xx xxx [**XxxxxxXxxXxxxxx.XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226936) xxxxxxxx xxx xx xxxxx xxxxxx xx [**XxxxXxxxxx.XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208133) xxxxxx xxx xxxxxxx xxxxxxxxxx.

Xxx xxxxxxxxx xxxxxx xxxxx xxx xx xxx x xxx xxxxx xxxxxxx xxx xxxxxxxx xxxxx xx xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923).

```csharp
void PostSocketRead(int length) 
{
    try
    {
        var readBuf = new Windows.Storage.Streams.Buffer((uint)length);
        var readOp = socket.InputStream.ReadAsync(readBuf, (uint)length, InputStreamOptions.Partial);
        readOp.Completed = (IAsyncOperationWithProgress<IBuffer, uint> 
            asyncAction, AsyncStatus asyncStatus) =>
        {
            switch (asyncStatus)
            {
                case AsyncStatus.Completed:
                case AsyncStatus.Error:
                    try
                    {
                        // GetResults in AsyncStatus::Error is called as it throws a user friendly error string.
                        IBuffer localBuf = asyncAction.GetResults();
                        uint bytesRead = localBuf.Length;
                        readPacket = DataReader.FromBuffer(localBuf);
                        OnDataReadCompletion(bytesRead, readPacket);
                    }
                    catch (Exception exp)
                    {
                        Diag.DebugPrint("Read operation failed:  " + exp.Message);
                    }
                    break;
                case AsyncStatus.Canceled:

                    // Read is not cancelled in this sample.
                    break;
           }
       };
   }
   catch (Exception exp)
   {
       Diag.DebugPrint("failed to post a read failed with error:  " + exp.Message);
   }
}
```

Xxx xxxx xxxxxxxxxx xxxxxxx xx xxxxxxxxxx xx xxxx xxxxxx xxx [**XXxxxxxxxxxXxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/br224811) xxxxxx xx xxx xxxxxxxxxx xxxx xxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xx xxxxxxx. Xxxxxxx xxx xxxxxxxx xxxxxxxxxxxxxxx xx xxxx xxx xx xxx xx xxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxxxxx. Xxx xxx xxxxxxxxx xxxxxxx xxxxxxxxx xxx xxxx xx xxx xxxxx xxxx xxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xx xxx xxxx xxxxxxxxxx xxxxxxxx. Xxx xxxxxxx xxxxxx xx xxxxxxxxx xxxxxx xxx xxxxxxx xx xxx **XXxxxxxxxxxXxxx.Xxx** xxxxxx. Xx xxxx xxxxxx xxxxx, xxxx xxxxx xx xxxxxxxxxxx xx xxxxx x xxxxxxx xxxxx xxxx xxx xxxx xxxxxxxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxx xxx xxx xxxxxxxxxx xxxx xxxxx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxx xxxxx xxx xxxx xxxxxxxxxx xxxxxxx xx xxx xxxx x xxx xxxxx xxxxxxx xxx xxxxxxxx xxxxx xx xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923).

```csharp
public void OnDataReadCompletion(uint bytesRead, DataReader readPacket)
{
    if (readPacket == null)
    {
        Diag.DebugPrint("DataReader is null");

        // Ideally when read completion returns error, 
        // apps should be resilient and try to 
        // recover if there is an error by posting another recv
        // after creating a new transport, if required.
        return;
    }
    uint buffLen = readPacket.UnconsumedBufferLength;
    Diag.DebugPrint("bytesRead: " + bytesRead + ", unconsumedbufflength: " + buffLen);

    // check if buffLen is 0 and treat that as fatal error.
    if (buffLen == 0)
    {
        Diag.DebugPrint("Received zero bytes from the socket. Server must have closed the connection.");
        Diag.DebugPrint("Try disconnecting and reconnecting to the server");
        return;
    }

    // Perform minimal processing in the completion
    string message = readPacket.ReadString(buffLen);
    Diag.DebugPrint("Received Buffer : " + message);

    // Enqueue the message received to a queue that the push notify 
    // task will pick up.
    AppContext.messageQueue.Enqueue(message);

    // Post another receive to ensure future push notifications.
    PostSocketRead(MAX_BUFFER_LENGTH);
}
```

Xx xxxxxxxxxx xxxxxx xxx Xxxxxxxxxx xx xxx xxxx-xxxxx xxxxxxx. Xxx XxxXxxxxx xxxxxxxx xxxxxxx x xxxxxxxx xxxxx xxx xxxx-xxxxx xxxxxxxx.

Xxxx xxxxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923), xxxxxxxx x[**XxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701531) xxxxx xxxxxxxx xx xxx [**XxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br224774) xxx x XxxxXxxxxXxxxxxx xx xxxxx xxx xxx xx xx xxxxxxxxxxx xxx xxxx xxxx-xxxxx xxxxxxxx xx xxx xxxxxx (xxxxxx xxxxxxxx) xxxxxxxxxxxx. Xxxx xxxxxx xx xxxx xx xxxx xx xxx xxxxxxxxxx xxxxxxxxxxxx xxx xxxx xx xxxx xx xx xxx xxxxxxx xxxxxxxx.

Xxxx xxxx xxxxx xxxxx xx [**Xxxxxxx.Xxxxxxx.XxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701531) xxxxx xx xx xxxxxxxxx xx xxx xxxxxx:

-   Xxxx xxxxxxxx XxxxXxxxxXxxxxxx xxxxxxx xx xxx xxxxxx xxxx (xxx xxxxxxx xxxxx).
-   Xx xxx xxx xxxxxxx xxxxxxxx xxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxxx.

Xxx xxxxxxxxx xxxxxx xxxx x xxxxxxx xxxxxxx xxxxxxxxxxxx xxx x xxxxxxxxx xxxxxxx xxxxx xxx &xx;Xxxxxxxxxxx&xx; xxxxxxx xx xx xxx xxxxxxxx.

```xml
  <Extensions>
    <Extension Category="windows.backgroundTasks" 
         Executable="$targetnametoken$.exe" 
         EntryPoint="Background.PushNotifyTask">
      <BackgroundTasks>
        <Task Type="controlChannel" />
      </BackgroundTasks>
    </Extension>
    <Extension Category="windows.backgroundTasks" 
         Executable="$targetnametoken$.exe" 
         EntryPoint="Windows.Networking.Sockets.WebSocketKeepAlive">
      <BackgroundTasks>
        <Task Type="controlChannel" />
      </BackgroundTasks>
    </Extension>
  </Extensions> 
```

Xx xxx xxxx xx xxxxxxxxx xxxxxxx xxxx xxxxx xx **xxxxx** xxxxxxxxx xx xxx xxxxxxx xx x [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xxx xx xxxxxxxxxxxx xxxxxxxxx xx x [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923), [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842), xx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882). X **Xxxx&xx;xxxx&xx;** xxxxxx xxx xx xxxx xx xxxxxxxx x **XxxxxxxXxxxxxxXxxxxxx** xxx xxxx xxxxxxxxxxxx xxx XxxXxxxxx xxxx-xxxxxx xx xxx **XxxxxxXxxXxxxxx** xxx xxxxxxx xxx xxxxxxxxx. Xx xxxx xx xxx xxxxxxxxxxxx, xxx **XxxxxxXxxXxxxxx** xxxxxxxxx xx xxx xx xxx xxxxxxxxx xxx xxx **XxxxxxxXxxxxxxXxxxxxx** xxx x xxxx xx xxxxxx. Xxx **Xxxx.Xxxxxx** xxxx xxxxx xxx xxxxxxx xxxxxx xxxxx xxx xxxxx xx xxx xxxx xxxxxxx xxx xxxxxx xxxxxxxxxx xx xxxxxxx xxxx. Xxx xxxx xx xxx xxxxxxxx xxxxx xxx xxxxxx xxxxxxx xxxxxx xxxx xx xxxxx. Xxxx xxxxxxxxxx xxxx xxx xxxxx xxxxxx xx xxxxxxxx. Xxx **Xxxx** xxx xxxxxxx xxxxxxxx **xxxxx** xxxxxxxxxx xxxx xxx xxxxxxxxx xx xxx **Xxxx**. Xxxx xxxxxxx xxxxxx xx xxxx xxxx xxx **XxxxxxxXxxxxxxXxxxxxx** xxxxxx xxxx x **XxxxxxXxxXxxxxx** xx **XxxxxxxXxxXxxxxx** xx xxxx xx xxx xxxxxxxxx. Xxx xxxxx xxxxxxxxxx xxxx xxx xxxx x xxxx xxxxxx xx xxxx xx xxxxxxxx (x xxxxxxx xxxxx xxxx xxxxxxxxx, xxx xxxxxxx), xxx xxx xxxxxx xxx xxx xxx xxxxx xxxxxxx xxxxxxxxx xxxxxxxxxx.

Xxx xxxxxxxxx xxxxxx xxxxxxxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xxx xxxx xxxxxxxxxxxx xxx XxxXxxxxx xxxx-xxxxxx xx xxx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923).

```csharp
private bool RegisterWithControlChannelTrigger(string serverUri)
{
    // Make sure the objects are created in a system thread
    // Demonstrate the core registration path 
    // Wait for the entire operation to complete before returning from this method.
    // The transport setup routine can be triggered by user control, by network state change
    // or by keepalive task
    Task<bool> registerTask = RegisterWithCCTHelper(serverUri);
    return registerTask.Result;
}

async Task<bool> RegisterWithCCTHelper(string serverUri)
{
    bool result = false;
    socket = new StreamWebSocket();

    // Specify the keepalive interval expected by the server for this app
    // in order of minutes.
    const int serverKeepAliveInterval = 30;

    // Specify the channelId string to differentiate this
    // channel instance from any other channel instance.
    // When background task fires, the channel object is provided
    // as context and the channel id can be used to adapt the behavior
    // of the app as required.
    const string channelId = "channelOne";

    // For websockets, the system does the keepalive on behalf of the app
    // But the app still needs to specify this well known keepalive task.
    // This should be done here in the background registration as well 
    // as in the package manifest.
    const string WebSocketKeepAliveTask = "Windows.Networking.Sockets.WebSocketKeepAlive";

    // Try creating the controlchanneltrigger if this has not been already 
    // created and stored in the property bag.
    ControlChannelTriggerStatus status;
    
    // Create the ControlChannelTrigger object and request a hardware slot for this app.
    // If the app is not on LockScreen, then the ControlChannelTrigger constructor will 
    // fail right away.
    try
    {
        channel = new ControlChannelTrigger(channelId, serverKeepAliveInterval,
                                   ControlChannelTriggerResourceType.RequestHardwareSlot);
    }
    catch (UnauthorizedAccessException exp)
    {
        Diag.DebugPrint("Is the app on lockscreen? " + exp.Message);
        return result;
    }

    Uri serverUriInstance;
    try
    {
        serverUriInstance = new Uri(serverUri);
    }
    catch (Exception exp)
    {
        Diag.DebugPrint("Error creating URI: " + exp.Message);
        return result;
    }

    // Register the apps background task with the trigger for keepalive.
    var keepAliveBuilder = new BackgroundTaskBuilder();
    keepAliveBuilder.Name = "KeepaliveTaskForChannelOne";
    keepAliveBuilder.TaskEntryPoint = WebSocketKeepAliveTask;
    keepAliveBuilder.SetTrigger(channel.KeepAliveTrigger);
    keepAliveBuilder.Register();

    // Register the apps background task with the trigger for push notification task.
    var pushNotifyBuilder = new BackgroundTaskBuilder();
    pushNotifyBuilder.Name = "PushNotificationTaskForChannelOne";
    pushNotifyBuilder.TaskEntryPoint = "Background.PushNotifyTask";
    pushNotifyBuilder.SetTrigger(channel.PushNotificationTrigger);
    pushNotifyBuilder.Register();

    // Tie the transport method to the ControlChannelTrigger object to push enable it.
    // Note that if the transport' s TCP connection is broken at a later point of time,
    // the ControlChannelTrigger object can be reused to plug in a new transport by
    // calling UsingTransport API again.
    try
    {
        channel.UsingTransport(socket);

        // Connect the socket
        //
        // If connect fails or times out it will throw exception.
        // ConnectAsync can also fail if hardware slot was requested
        // but none are available
        await socket.ConnectAsync(serverUriInstance);

        // Call WaitForPushEnabled API to make sure the TCP connection has 
        // been established, which will mean that the OS will have allocated 
        // any hardware slot for this TCP connection.
        //
        // In this sample, the ControlChannelTrigger object was created by 
        // explicitly requesting a hardware slot.
        //
        // On systems that without connected standby, if app requests hardware slot as above, 
        // the system will fallback to a software slot automatically.
        //
        // On systems that support connected standby,, if no hardware slot is available, then app 
        // can request a software slot by re-creating the ControlChannelTrigger object.
        status = channel.WaitForPushEnabled();
        if (status != ControlChannelTriggerStatus.HardwareSlotAllocated
            &amp;&amp; status != ControlChannelTriggerStatus.SoftwareSlotAllocated)
        {
            throw new Exception(string.Format("Neither hardware nor software slot could be allocated. ChannelStatus is {0}", status.ToString()));
        }

        // Store the objects created in the property bag for later use.
        CoreApplication.Properties.Remove(channel.ControlChannelTriggerId);

        var appContext = new AppContext(this, socket, channel, channel.ControlChannelTriggerId);
        ((IDictionary<string, object>)CoreApplication.Properties).Add(channel.ControlChannelTriggerId, appContext);
        result = true;

        // Almost done. Post a read since we are using streamwebsocket
        // to allow push notifications to be received.
        PostSocketRead(MAX_BUFFER_LENGTH);
    }
    catch (Exception exp)
    {
         Diag.DebugPrint("RegisterWithCCTHelper Task failed with: " + exp.Message);

         // Exceptions may be thrown for example if the application has not 
         // registered the background task class id for using real time communications 
         // broker in the package manifest.
    }
    return result
}
```

Xxx xxxx xxxxxxxxxxx xx xxxxx [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032), xxx xxx [XxxxxxxXxxxxxxXxxxxxx XxxxxxXxxXxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=251232).

## XxxxxxxXxxxxxxXxxxxxx xxxx XxxxXxxxxx

Xxxx xxxxxxx xxxxxxxxxxxxxx xxxxx xxxx xxxxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032). Xxxxx xxx xxxx xxxxxxxxx-xxxxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxxx xx xxxxxxxx xxxx xxxxx x [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx **XxxxxxxXxxxxxxXxxxxxx**. Xx xxxxxxxx, xxxxx xxxxxxxxxxxxxx xxxxxx xxx xxx xxxx xxxxxxxx xx xxxxxxx xxxxxxx xx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxx xxxxxxx.

**Xxxx**[XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxx XXX xx xxx xxxxxxxxx xxxxxxxxx xxxxx xxx xxxxxxx xxxxxxx xxxxxxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032).

 
Xxx xxxxxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxxxxx xxxxxx xx xxxxxxxx xxxx xxxxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032):

-   Xxx xxx xxx xxxx xx xxx xxxxxxx xxxxxxxxxx xxx xxxxxxx xx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xx [XxxxXxxxxxXxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241638) xxxxxx xx xxx [Xxxxxx.Xxx.Xxxx](http://go.microsoft.com/fwlink/p/?linkid=227894) xxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxx xx xxx xxxxxxxx XXX.
-   Xx xxx xxx xxxx xx xxxx xxxx xx xx xxxxxxx xxxxxxx xx xxxx xxx xxxxx xxx xxxxxxxxx xxxxxxxx xxxxxx xxxxxxxx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxxxxx xx xx xxxx xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032). Xxxx xxx xxx xxxxxxxxxx xxxx xxx xxxxxxxxx xxx xx xxxxxxxx xxxxx, xx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxx xxx xx xxxxxxxxxx xx xxx xxxxxxxxx xxxxxx xxxx xxxx xxx **XxxxxxxXxxxxxxXxxxxxx** xxxxxx. Xxxx xxxxxxx xx xxxxxxxx xxxxxxx xxxx xxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx. Xxxxx XXX xxxx x xxxxxxxxxxx, xx xxx xxx xxxxxxx x xxxxxx xx xx xxxxxxxxx xxx XXX xxxxx xx xx xxxxx xxx xxxxxxxx xxxxxxxxxxxx xx xxxxxx xxxx. Xxxxx xxxxxxxxxxxxxx xxx xxxxxx xxxxxxxxxxxxxx xxx xx xxxxxxxx. Xx xxx xxxxx xx xxxxxx xxxxxxxxxxxxxx xxxxxxx, xxx xxxxxxxxxx xxx xx xxxxxx. Xxx xxx xx xxx xxx xxxx xxxx xxxxx xxxxxxxxxxxxxx xxxxxxxxxx xxxxxx xx xx xxx x xxxxx. Xxxx xx XXXX xxxxxxxx xx xxxxxxxx, xx xx xxx xxxxxxxxxx xxxx xxx xxxxxx xxxxxxxxxx xxx xx xxxxxxxxxxx xxxxxxxx. Xx xxxxxxx xxxx xxxxxxx xxxx xxxxxx xxxx xxx xxx xxx xxx xxx xxxx xx-xx-xxxx xxxxxxxxxx XXX xxxxxx xxxxx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxx xx xxx xxxxxxxxx xxxx xxx **XxxxxxxXxxxxxxXxxxxxx** xxxxxx.

Xxxxxx xxxxx xxxxxxx xxxxxxxxxx, xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxx xxxxxx xx xxxxxxxx xxxxxx xxxx xxx [**XxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701175) xxxxxx xx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xxxxxx. Xxxxxxx, xx [XxxxXxxxxxxXxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=259153) xxxxxx xxxx xx xxxxxxxxx xxxxxxxxxxx xxx xxx xxxx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxx xxx xxx **XxxxxxxXxxxxxxXxxxxxx**. Xxx [XxxxXxxxxxxXxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=259153) xxxxxx xx xxxxxxx xxxxx xxx [XxxXxxxxxxXxxxxxx.Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=259154) xxxxxx. Xxx [XxxxXxxxxxxXxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=259153) xxxxxx xxxx xx xxxxxxx xx xxxx xxxxxx xx **XxxxxXxxxxxxxx** xxxxxx .

Xxx xxxxxxxxx xxxxxx xxxxx xxx xx xxxxxxxxx xx [XxxxXxxxxxxXxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=259153) xxxxxx xxx xxx xxxx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxx xxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032).

```csharp
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

public HttpRequestMessage httpRequest;
public HttpClient httpClient;
public HttpRequestMessage httpRequest;
public ControlChannelTrigger channel;
public Uri serverUri;

private void SetupHttpRequestAndSendToHttpServer()
{
    try
    {
        // For HTTP based transports that use the RTC broker, whenever we send next request, we will abort the earlier 
        // outstanding http request and start new one.
        // For example in case when http server is taking longer to reply, and keep alive trigger is fired in-between 
        // then keep alive task will abort outstanding http request and start a new request which should be finished 
        // before next keep alive task is triggered.
        if (httpRequest != null)
        {
            httpRequest.Dispose();
        }

        httpRequest = RtcRequestFactory.Create(HttpMethod.Get, serverUri);

        SendHttpRequest();
    }
        catch (Exception e)
    {
        Diag.DebugPrint("Connect failed with: " + e.ToString());
        throw;
    }
}
```

Xxxx xxxxxxx xxxxxxxxxxxxxx xxxxxx xxx xxx xxxx xxxxxxxx xx xxxx XXXX xxxxxxxx xx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xx xxxxxxxx xxxxxxxxx x xxxxxxxx xxx xxxxxxx. Xx xxxxxxxxxx, xxxx xxxxx x [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032), xxxx xxx xxxx xxx x Xxxx xxx xxxxxxxx xxxxx xxxxxxx xx xxx **xxxxx** xxxxx.

Xxxxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637), xxxxx xx xx xxxxxxxxxxxxxxx xxxx xxx [**XXxxxxxxxxxXxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/br224811) xxxxxx xx xxx xxxxxxxxxx xxxx xxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xxxx xxx xxxxxx xx xxx xxxxxxx xxxxxxxxxx xxxxxxxx. Xxx xxxx xxxxxx, xxx xxx xxx xxxx xxx xxx xxxxxxxx XxxxXxxxxxxxXxxxxxx xxxxxxxxx xx xxx **Xxx** xxxxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxx xx xxxxxxxx.

Xxxxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xx xxxxxxxxxx xxxxxxxxx xxxx xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882), [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxxxxxx . Xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxxx xxxxxxxx xx xxxxxxxxx xxx x Xxxx xx xxx xxx xxxxx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx. Xxxx xxxxx xxxx xxx **XxxxxxxXxxxxxxXxxxxxx** xxxx xxxxxxxxxxxx xxxx xxxx xxxx xx xxxx xx xxx xxxx xx xxxxx xx xxxxxxxxxx xx xxx xxx. Xx xxx xxxxxx xxxxx, xxx xxxx xxxxxx xxx xxxxxxxxXxxx xxxxxxxx xx [XxxxXxxxxx.XxxxXxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxxxx xxxx xxxxxx xxxxxxx xxxx xxx xxxx xxxxxx xxxx xxxx xxxx xx xxx xxxxxxx xxxxxx.

Xxx xxxxxxxxx xxxxxx xxxxx xxx xx xxxxxx xxxx xxxxxxxx xx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx xxxx xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032).

```csharp
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

private void SendHttpRequest()
{
    if (httpRequest == null)
    {
        throw new Exception("HttpRequest object is null");
    }

    // Tie the transport method to the controlchanneltrigger object to push enable it.
    // Note that if the transport' s TCP connection is broken at a later point of time,
    // the controlchanneltrigger object can be reused to plugin a new transport by
    // calling UsingTransport API again.
    channel.UsingTransport(httpRequest);

    // Call the SendAsync function to kick start the TCP connection establishment
    // process for this http request.
    Task<HttpResponseMessage> httpResponseTask = httpClient.SendAsync(httpRequest);

    // Call WaitForPushEnabled API to make sure the TCP connection has been established, 
    // which will mean that the OS will have allocated any hardware slot for this TCP connection.
    ControlChannelTriggerStatus status = channel.WaitForPushEnabled();
    Diag.DebugPrint("WaitForPushEnabled() completed with status: " + status);
    if (status != ControlChannelTriggerStatus.HardwareSlotAllocated
        &amp;&amp; status != ControlChannelTriggerStatus.SoftwareSlotAllocated)
    {
        throw new Exception("Hardware/Software slot not allocated");
    }

    // The HttpClient receive callback is delivered via a Task to the app. 
    // The notification task will fire as soon as the data or error is dispatched
    // Enqueue the responseTask returned by httpClient.sendAsync 
    // into a queue that the push notify task will pick up and process inline.
    AppContext.messageQueue.Enqueue(httpResponseTask);
}
```

Xxx xxxxxxxxx xxxxxx xxxxx xxx xx xxxx xxxxxxxxx xxxxxxxx xx xxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx xxxx xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032).

```csharp
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public string ReadResponse(Task<HttpResponseMessage> httpResponseTask)
{
    string message = null;
    try
    {
        if (httpResponseTask.IsCanceled || httpResponseTask.IsFaulted)
        {
            Diag.DebugPrint("Task is cancelled or has failed");
            return message;
        }
        // We' ll wait until we got the whole response. 
        // This is the only supported scenario for HttpClient for ControlChannelTrigger.
        HttpResponseMessage httpResponse = httpResponseTask.Result;
        if (httpResponse == null || httpResponse.Content == null)
        {
            Diag.DebugPrint("Cannot read from httpresponse, as either httpResponse or its content is null. try to reset connection.");
        }
        else
        {
            // This is likely being processed in the context of a background task and so
            // synchronously read the Content' s results inline so that the Toast can be shown.
            // before we exit the Run method.
            message = httpResponse.Content.ReadAsStringAsync().Result;
        }
    }
    catch (Exception exp)
    {
        Diag.DebugPrint("Failed to read from httpresponse with error:  " + exp.ToString());
    }
    return message;
}
```

Xxx xxxx xxxxxxxxxxx xx xxxxx [XxxxXxxxxx](http://go.microsoft.com/fwlink/p/?linkid=241637) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032), xxx xxx [XxxxxxxXxxxxxxXxxxxxx XxxxXxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=258323).

## XxxxxxxXxxxxxxXxxxxxx xxxx XXXXXxxxXxxxxxxY

Xxxx xxxxxxx xxxxxxxxxxxxxx xxxxx xxxx xxxxx [**XXXXXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh831151) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032). Xxxxx xxx xxxx xxxxxxxxx-xxxxxxxx xxxxx xxxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxxx xx xxxxxxxx xxxx xxxxx x **XXXXXXXXXxxxxxxY** xxxx **XxxxxxxXxxxxxxXxxxxxx**. Xxxxx **XxxxxxxXxxxxxxXxxxxxx** xxxx xxx xxxxxx xxx xxx xxxx xxxxxxxx xx xxxx xx xxxxxxx XXXX xxxxxxxx xx xxx **XXXXXXXXXxxxxxxY** xxx xxxxxxx.

Xxxxx xxxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxx [**XXXXXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh831151) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032)

-   Xx [**XXXXXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh831151) xxxxxx xxxx xxxx xx xxx xxxxxxxxx xxx x xxxxxxxx xx xxxx xxx xxxxxxx/xxxxxxxx. Xxxx xxxx xxxx xxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032) xxxxxx, xx xx xxxxxxxxxx xx xxxxxx xxx xxx xx xxx **XxxxxxxXxxxxxxXxxxxxx** xxxxxx xxxx xxx xxxx xxxx xxx [**XxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701175) xxxxxx xxxxxxxxxx, xxxx xxxx xxxxxxxxxxx x xxx **XXXXXXXXXxxxxxxY** xxxxxx. Xx xxx xxxxxx xxxxxx xxx xxxxxxxx **XXXXXXXXXxxxxxxY** xxxxxx xxxxxx xxxxxxxxx x xxx **XXXXXXXXXxxxxxxY** xxxxxx xx xxxxxx xxxx xxx xxx xxxx xxx xxxxxx xxx xxxxxxxxx xxxxxxxx xxxxxx.
-   Xxx xxx xxx xxxx xx xxxx xxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh831167) xxx [**XxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/hh831168) xxxxxxx xx xxx xx xxx XXXX xxxxxxxxx xxxxxx xxxxxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/desktop/hh831164) xxxxxx.
-   Xx xxx xxx xxxx xx xxxx xxxx xx xx xxxxxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/desktop/hh831164) xxxxxxx xx xxxx xxx xxxxx xxx xxxxxxxxx xxxxxxxx xxxxxx xxxxxxxx xxx xxxxxxxxx xx xx xxxx xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032). Xxxx xxx xxx xxxxxxxxxx xxxx xxx xxxxxxxxx xx xxxxxxxx xxxxx, xxx [**XXXXXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh831151) xxxxxx xxx xx xxxxxxxxxx xx xxx xxxxxxxxx xxxxxx xxxx xxxx xxx **XxxxxxxXxxxxxxXxxxxxx**. Xxxx xxxxxxx xx xxxxxxxx xxxxxxx xxxx xxxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx. Xxxxx XXX xxxx x xxxxxxxxxxx, xx xxx xxx xxxxxxx x xxxxxx xx xx xxxxxxxxx xxx XXX xxxxx xx xx xxxxx xxx xxxxxxxx xxxxxxxxxxxx xx xxxxxx xxxx. Xxxxx xxxxxxxxxxxxxx xxx xxxxxx xxxxxxxxxxxxxx xxx xx xxxxxxxx. Xx xxx xxxxx xx xxxxxx xxxxxxxxxxxxxx xxxxxxx, xxx xxxxxxxxxx xxx xx xxxxxx. Xxx xxx xx xxx xxx xxxx xxxx xxxxx xxxxxxxxxxxxxx xxxxxxxxxx xxxxxx xx xx xxx x xxxxx. Xxxx xx XXXX xxxxxxxx xx xxxxxxxx, xx xx xxx xxxxxxxxxx xxxx xxx xxxxxx xxxxxxxxxx xxx xx xxxxxxxxxxx xxxxxxxx. Xx xxxxxxx xxxx xxxxxxx xxxx xxxxxx xxxx xxx xxx xxx xxx xxx xxxx xx-xx-xxxx xxxxxxxxxx XXX xxxxxx xxxxx xxx **XXXXXXXXXxxxxxxY** xxxxxx xx xxx xxxxxxxxx xxxx xxx **XxxxxxxXxxxxxxXxxxxxx** xxxxxx.

Xxx xxxx xxxxxxxxxxx xx xxxxx [**XXXXXXXXXxxxxxxY**](https://msdn.microsoft.com/library/windows/desktop/hh831151) xxxx [**XxxxxxxXxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701032), xxx xxx [XxxxxxxXxxxxxxXxxxxxx xxxx XXXXXXXXXxxxxxxY xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=258538).

<!--HONumber=Mar16_HO1-->
