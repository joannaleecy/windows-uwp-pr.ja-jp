---
xxxxxxxxxxx: Xxx xxx xxx xxxx Xxxxxxx.Xxxxxxxxxx.Xxxxxxx xxx Xxxxxxx xx xxxxxxxxxxx xxxx xxxxx xxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxxxx.
xxxxx: Xxxxxxx
xx.xxxxxxx: YYXYYXYX-XYYX-YXXY-YYXX-YXXXYYYYYYXY
---

# Xxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.Xxxxxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226960)
-   [Xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms740673)

Xxx xxx xxx xxxx [**Xxxxxxx.Xxxxxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226960) xxx [Xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms737523) xx xxxxxxxxxxx xxxx xxxxx xxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxxxx. Xxxx xxxxx xxxxxxxx xx-xxxxx xxxxxxxx xx xxxxx xxx **Xxxxxxx.Xxxxxxxxxx.Xxxxxxx** xxxxxxxxx xx xxxxxxx xxxxxxxxxx xxxxxxxxxx.

## Xxxxx XXX xxxxxx xxxxxxxxxx

X XXX xxxxxx xxxxxxxx xxx-xxxxx xxxxxxx xxxx xxxxxxxxx xx xxxxxx xxxxxxxxx xxx xxxx-xxxxx xxxxxxxxxxx. XXX xxxxxxx xxx xxx xxxxxxxxxx xxxxxxx xxxx xx xxxx xx xxx xxxxxxx xxxxxxxxx xxxx xx xxx Xxxxxxxx. Xxxx xxxxxxx xxxxx xxx xx xxxxxx x XXX xxx xx xxxx xxx xxxxxxx xxxx xxxx x XXX xxxxxx xxxxxx xxxxx xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882) xxx [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906) xxxxxxx xx xxxx xx xxx [**Xxxxxxx.Xxxxxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226960) xxxxxxxxx. Xxx xxxx xxxxxxx, xx xxxx xx xxxxxxxx x xxxx xxxxxx xxx xxxx xxxx xxxxxxxx xx xx xxxx xxxxxx xxx xxxxxx xx xxxxxxxxxxx xxxxx XXX xxxxxxxxxx.

**Xxxxxxxx x XXX xxxx xxxxxx**

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xxx xx xxxxxx x [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906) xxxxxx xxx xxxxx xxxxxxxxx xxx xxxxxxxx XXX xxxxxxxxxxx.

```csharp
try
{
    //Create a StreamSocketListener to start listening for TCP connections.
    Windows.Networking.Sockets.StreamSocketListener socketListener = new Windows.Networking.Sockets.StreamSocketListener();

    //Hook up an event handler to call when connections are received.
    socketListener.ConnectionReceived += SocketListener_ConnectionReceived;

    //Start listening for incoming TCP connections on the specified port. You can specify any port that' s not currently in use.
    await socketListener.BindServiceNameAsync("1337");
}
catch (Exception e)
{
    //Handle exception.
}
```

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxx xxx XxxxxxXxxxxxxx\_XxxxxxxxxxXxxxxxxx xxxxx xxxxxxx xxxx xxx xxxxxxxx xx xxx [**XxxxxxXxxxxxXxxxxxxx.XxxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701494) xxxxx xx xxx xxxxx xxxxxxx. Xxxx xxxxx xxxxxxx xx xxxxxx xx xxx [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906) xxxxx xxxxx xxxx x xxxxxx xxxxxx xxx xxxxxxxxxxx x xxxxxxxxxx xxxx xxx xxxx xxxxxx.

```csharp
private async void SocketListener_ConnectionReceived(Windows.Networking.Sockets.StreamSocketListener sender, 
    Windows.Networking.Sockets.StreamSocketListenerConnectionReceivedEventArgs args)
{
    //Read line from the remote client.
    Stream inStream = args.Socket.InputStream.AsStreamForRead();
    StreamReader reader = new StreamReader(inStream);
    string request = await reader.ReadLineAsync();
    
    //Send the line back to the remote client.
    Stream outStream = args.Socket.OutputStream.AsStreamForWrite();
    StreamWriter writer = new StreamWriter(outStream);
    await writer.WriteLineAsync(request);
    await writer.FlushAsync();
}
```

**Xxxxxxxx x XXX xxxx xxxxxx**

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xxx xx xxxxxx x [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882) xxxxxx, xxxxxxxxx x xxxxxxxxxx xx xxx xxxxxx xxxxxx, xxxx x xxxxxxx, xxx xxxxxxx x xxxxxxxx.

```csharp
try
{
    //Create the StreamSocket and establish a connection to the echo server.
    Windows.Networking.Sockets.StreamSocket socket = new Windows.Networking.Sockets.StreamSocket();
    
    //The server hostname that we will be establishing a connection to. We will be running the server and client locally,
    //so we will use localhost as the hostname.
    Windows.Networking.HostName serverHost = new Windows.Networking.HostName("localhost");
    
    //Every protocol typically has a standard port number. For example HTTP is typically 80, FTP is 20 and 21, etc.
    //For the echo server/client application we will use a random port 1337.
    string serverPort = "1337";
    await socket.ConnectAsync(serverHost, serverPort);

    //Write data to the echo server.
    Stream streamOut = socket.OutputStream.AsStreamForWrite();
    StreamWriter writer = new StreamWriter(streamOut);
    string request = "test";
    await writer.WriteLineAsync(request);
    await writer.FlushAsync();

    //Read data from the echo server.
    Stream streamIn = socket.InputStream.AsStreamForRead();
    StreamReader reader = new StreamReader(streamIn);
    string response = await reader.ReadLineAsync();
}
catch (Exception e)
{
    //Handle exception here.            
}
```

## Xxxxx XXX xxxxxx xxxxxxxxxx

X XXX xxxxxx xxxxxxxx xxx-xxxxx xxxxxxx xxxx xxxxxxxxx xx xxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxxxxxx xxxx xxxx xxx xxxxxxx xx xxxxxxxxxxx xxxxxxxxxx. Xxxxxxx XXX xxxxxxx xx xxx xxxxxxxx xxxxxxxxxx xx xxxx xxxxxxxxx xxxx xxxxxxx xxxx xxx xxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxx xxxxxx xxxxxxxx. Xxxxxxx, XXX xxxxxxx xx xxx xxxxxx xxxxxxxxx xx xxx xxxxxxx xxxxxxx xx xxxxxxx xxxx xxxx xx xx xxx xxxxxx xxxxxxxxxxx xx xxx. Xxxx xxxxxxxx xx xxxxxxxxxxxx xxxx xxx XXX xxxxxxx xxx xxxxx xxxxxxx xxxxxxxxx xxx xxxxx xxxx xxxxxxx. Xxxx xxxxxxx xxxxxxxxxxxx xxx xxx xx xxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319) xxxxx xx xxxxxxx xxx xxxxxxxxx XXX xxxxxxxx xx xxxxxxxx x xxxxxx xxxx xxxxxx xxx xxxxxx.

**Xxxxxxxx x XXX xxxx xxxxxx**

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xxx xx xxxxxx x [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319) xxxxxx xxx xxxx xx xx x xxxxxxxx xxxx xx xxxx xxx xxx xxxxxx xxx xxxxxxxx XXX xxxxxxxx.

```csharp
Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

socket.MessageReceived += Socket_MessageReceived;

//You can use any port that is not currently in use already on the machine.
string serverPort = "1337";

//Bind the socket to the serverPort so that we can start listening for UDP messages from the UDP echo client.
await socket.BindServiceNameAsync(serverPort);
```

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxx xxx **Xxxxxx\_XxxxxxxXxxxxxxx** xxxxx xxxxxxx xx xxxx x xxxxxxx xxxx xxx xxxxxxxx xxxx x xxxxxx xxx xxxx xxx xxxx xxxxxxx xxxx.

```csharp
private async void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender, Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
{
    //Read the message that was received from the UDP echo client.
    Stream streamIn = args.GetDataStream().AsStreamForRead();
    StreamReader reader = new StreamReader(streamIn);
    string message = await reader.ReadLineAsync();

    //Create a new socket to send the same message back to the UDP echo client.
    Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();
    
    //Use a separate port number for the UDP echo client because both will be unning on the same machine.
    string clientPort = "1338"
    Stream streamOut = (await socket.GetOutputStreamAsync(args.RemoteAddress, clientPort)).AsStreamForWrite();
    StreamWriter writer = new StreamWriter(streamOut);
    await writer.WriteLineAsync(message);
    await writer.FlushAsync();
}
```

**Xxxxxxxx x XXX xxxx xxxxxx**

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xxx xx xxxxxx x [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319) xxxxxx xxx xxxx xx xx x xxxxxxxx xxxx xx xxxx xxx xxx xxxxxx xxx xxxxxxxx XXX xxxxxxxx xxx xxxx x XXX xxxxxxx xx xxx XXX xxxx xxxxxx.

```csharp
private async void testUdpSocketServer()
{
    Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();
    
    socket.MessageReceived += Socket_MessageReceived;
    
    //You can use any port that is not currently in use already on the machine. We will be using two separate and random 
    //ports for the client and server because both the will be running on the same machine.
    string serverPort = "1337";
    string clientPort = "1338";
    
    //Because we will be running the client and server on the same machine, we will use localhost as the hostname.
    Windows.Networking.HostName serverHost = new Windows.Networking.HostName("localhost");
    
    //Bind the socket to the clientPort so that we can start listening for UDP messages from the UDP echo server.
    await socket.BindServiceNameAsync(clientPort);
                
    //Write a message to the UDP echo server.
    Stream streamOut = (await socket.GetOutputStreamAsync(serverHost, serverPort)).AsStreamForWrite();
    StreamWriter writer = new StreamWriter(streamOut);
    string message = "Hello, world!";
    await writer.WriteLineAsync(message);
    await writer.FlushAsync();
}
```

Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxx xxx **Xxxxxx\_XxxxxxxXxxxxxxx** xxxxx xxxxxxx xx xxxx x xxxxxxx xxxx xxx xxxxxxxx xxxx xxx XXX xxxx xxxxxx.

```csharp
private async void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender, 
    Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
{
    //Read the message that was received from the UDP echo server.
    Stream streamIn = args.GetDataStream().AsStreamForRead();
    StreamReader reader = new StreamReader(streamIn);
    string message = await reader.ReadLineAsync();
}
```

## Xxxxxxxxxx xxxxxxxxxx xxx xxx xxxxxx xxxxxx

Xx xxxx xxx xxxxxxxx xxxxxxxxxxx xx xxxx xx xxxxxxx, xxxx xxx xxxx xx xxxxxxxx xx xxxxxxx xxxxx xxxxxxxxxx xxxxxxxx xxxxx xxxx xxx xx xxx xx xxx xxxxxxxxxx. Xx xx xx, xxx xxx xxx xxxxxx xxxxxx. Xxx xxxx xxxxxxxxxxx xx xxx xx xxx xxx xxxxxx xxxxxx, xxx [Xxxxxxx xxxxxxxxxxxxxx xx xxx xxxxxxxxxx](network-communications-in-the-background.md).

## Xxxxxxx xxxxx

Xxxxxxxx xxxx Xxxxxxx YY, Xxxxxxx.Xxxxxxxxxx.Xxxxxxx xxxxxxxx xxxxxxx xxxxx, x xxx xxx xxx xx xxxx xxxxxxxx xxxxxxx xx xxxx xxxxxxxx xxxx xxxx xxxxx xxxxxxx-xxxxxxxxx xxxxxxxx xxxx xx xxx xxxx xxxx xx xxx xxxxxxx xxxxxxxxxx. Xxxx xx xxxxxxxxxx xxxxxx xx xxxx xxx xx xxxxx XxXX, XXX, xx xxxxx xxxxx xxxxx xxxxxxx xxxxxx x xxx xx xxxx xx xxxxxxxxxxx xx xxxxxxxx.

Xxxx xxxx xx XxxxxXxxxx xx x xxxxxx xxxxxxxx x xxxxxx xxxxxxxxxx xx xxxxx xxx xxxxxxx xxxxx. Xxxx xx xxx xxxxxx xxxx xxxxxxx xx x xxxx, xxxx xxxxx xxxxxx x xxxxxxxx xxxxxx xxxxxxxxxx, xxx xxxx xxxxxxx xxxxxxxxxxx xxxxxxxx. Xxx xxx xxxxxxx xxxxx xxxxxxx xxxxxxxxx xxx xxxxxxxxx xx xxxxxx xxxxxxxxxxx. Xxxx xxxxxxxxxxxxx xx xxxxxxxxx xxxxxxx xx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882) xxx xxxxxxxxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319) xxxxxxxxx.

Xxxx xx xx xxxxxxx xx xxx xx xxx xxxxx xxxx x xxxxx xxxxxx xx xxxxxxx xx x xxx-xxxxxxx xxx.

```csharp
// Send a set of packets inefficiently, one packet at a time.
// This is not recommended if you have many packets to send
IList<IBuffer> packetsToSend = PreparePackets();
var outputStream = stream.OutputStream;

foreach (IBuffer packet in packetsToSend)
{
    // Incurs kernel transition overhead for each packet
    await outputStream.WriteAsync(packet);
}
```

Xxxx xxxxxxx xxxxx x xxxx xxxxxxxxx xxx xx xxxx x xxxxx xxxxxx xx xxxxxxx. Xxxxxxx xxxx xxxxxxxxx xxxx xxxxxxxx xxxxxx xx xxx X# xxxxxxxx, xx xx xxxx xxxxxxxxx xx X# xxxxxxxxxxx. Xx xxxxxxx xxxxxxxx xxxxxxx xx x xxxx, xxxx xxxxxxx xxxxxxx xxx xxxxxx xx xxxxx xxxxx, xxx xxxx xxxxxxxx xxxxxx xxxxxxxxxxx xxx xxxxxxxx xxxxxxxxxxx.

```csharp
// More efficient way to send packets.
// This way enables the system to do batched sends
IList<IBuffer> packetsToSend = PreparePackets();
var outputStream = stream.OutputStream;

int i = 0;
Task[] pendingTasks = new Tast[packetsToSend.Count];
foreach (IBuffer packet in packetsToSend)
{
    // track all pending writes as tasks, but do not wait on one before peforming the next
    pendingTasks[i++] = outputStream.WriteAsync(packet).AsTask();
    // Do not modify any buffer' s contents until the pending writes are complete.
}
// Now, wait for all of the pending writes to complete
await Task.WaitAll(pendingTasks);
```

Xxxx xxxxxxx xxxxx xxxxxxx xxx xx xxxx x xxxxx xxxxxx xx xxxxxxx xx x xxx xxxx'x xxxxxxxxxx xxxx xxxxxxx xxxxx. Xxx xxxxx xx xxxxx'x xxx xxx X#-xxxxxxxx xxxxxxxx, xx xx xxxxxxxxxx xxx xxx xxxxxxxxx (xxxxxx xx xx xxxxxxxxxxxx xxxx xx X#). Xxxxxxx, xx xxxx xxxxxxx xxxxxxxx xx xxx **XxxxxxXxxxxx** xxxxxx xx xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882) xxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319) xxxxxxx xxxx xx xxx xx Xxxxxxx YY.

```csharp
// More efficient way to send packets in Windows 10, using the new behavior of OutputStream.FlushAsync().
int i = 0;
IList<IBuffer> packetsToSend = PreparePackets();
var outputStream = socket.OutputStream;

var pendingWrites = new IAsyncOperationWithProgress<uint,uint> [packetsToSend.Count];

foreach (IBuffer packet in packetsToSend)
{
    pendingWrites[i++] = outputStream.WriteAsync(packet);
    // Do not modify any buffer' s contents until the pending writes are complete.
}

// Wait for all pending writes to complete. This step enables batched sends on the output stream.
await outputStream.FlushAsync();
```

Xx xxxxxxx xxxxxxxx xx Xxxxxxx, **XxxxxXxxxx** xxxxxxxx xxxxxxxxxxx, xxx xxx xxx xxxxxxxxx xxxx xxx xxxxxxxxxx xx xxx xxxxxx xxx xxxxxxxxx xxx. Xx Xxxxxxx YY, xxx xxxxxxxx xxx xxxxxxx. **XxxxxXxxxx** xx xxx xxxxxxxxxx xx xxxxxx xxxxx xxx xxxxxxxxxx xx xxx xxxxxx xxxxxx xxxx xxxxxxxxx.

Xxxxx xxx xxxx xxxxxxxxx xxxxxxxxxxx xxxxxxx xx xxxxx xxxxxxx xxxxxx xx xxxx xxxx.

-   Xxx xxxxxx xxxxxx xxx xxxxxxxx xx xxx **XXxxxxx** xxxxxxxxx xxxxx xxxxxxx xxxxx xxx xxxxxxxxxxxx xxxxx xx xxxxxxxx.
-   Xxx **XxxxxXxxxx** xxxxxxx xxxx xxxxx xx **XxxxxxXxxxxx.XxxxxxXxxxxx** xxx **XxxxxxxxXxxxxx.XxxxxxXxxxxx**.
-   Xxx **XxxxxXxxxx** xxxxxxx xxxx xxxxx xx Xxxxxxx YY xxx xxxxxx.
-   Xx xxxxx xxxxx, xxx **Xxxx.XxxxXxx** xxxxxxx xx xxx **XxxxxXxxxx** xxxxxxx.

## Xxxx xxxxxxx xxx XxxxxxxxXxxxxx

Xxxxxxx YY xxxxxxxxxx x xxx [**XxxxxxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701190) xxxxxxxx, [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn895368), xxxxx xxxxxxx xxx xx xxxxxxx xxxx xxx **XxxxxxxxXxxxxx** xx xxxxxxxx xx xxxx xx xxxxxxx xxxx xxxxx XxxYY xx XxxXX xxxxxxxxx xxxxxxx xxxxx xx xxx xxxx xxxxxxx/xxxx.

## Xxxxxxxxx x xxxxxx xxxxxxxxxxx xxxx xxx XxxxxxXxxxxx xxxxx

Xxx [**Xxxxxxx.Xxxxxxxxxx.XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882) xxxxx xxxxxxxx xxxxx XXX/XXX xx xxxxxxxxxxxx xxx xxxxxx xxx xxx xx xxxxxxx xx. Xx xxxxxxx xxxxx, xxx xxx xxxx xxxxx xx xxxxxxxxxxxx xxxxxx xx xxx xxxxxx xxxxx x XXX xxxxxx xxxxxxxxxxx. Xx Xxxxxxx YY, xxx xxx xxxxxxx x xxxxxx xxxxxxxxxxx xx xxx [**XxxxxxXxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226893) xxxxxx (xxxx xxxx xx xxx xxxxxx xxx XXX xxxxxxxxx xx xxxxxxx). Xx xxx xxxxxx xxxxxxxx xxx xxxxxx xxxxxxxxxxx, Xxxxxxx xxxx xxxxxxx xxxx xxx xxxxxxxxxxx xxxxxxxx.

Xxxx xx x xxxx xxxxxxx xxxxxxx xxx xx xxxxxxxxx xxxx:

```csharp
var socket = new StreamSocket();
Windows.Security.Cryptography.Certificates.Certificate certificate = await GetClientCert();
socket.Control.ClientCertificate = certificate;
await socket.ConnectAsync(destination, SocketProtectionLevel.Tls12);
```

## Xxxxxxxxxx xx Xxxxxxx.Xxxxxxxxxx.Xxxxxxx

Xxx xxxxxxxxxxx xxx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207113) xxxxx xxxx xxxx xxxxxxx xxx xxxxx xx xxxxxxxxx xx xxx xxxxxx xxxxxx xx xxx x xxxxx xxxxxxxx (xxxxxxxx xxxxxxxxxx xxxx xxx xxx xxxxxxx xx x xxxx xxxx). Xx xx xxx xxxx xxxxx xxxx xxx xxxx xxx xxx **XxxxXxxx**, xxx xxxxxxxxxxx xxxxxx xx xx x xxx/xxxxx xxxxx. Xx xx xxxxxxxxx xx xxxxxx, xxx xxx xxx xxxxxx xxx xxxx xxx xxxxxxx x xxx xxxxxxxx.

Xxx [**Xxxxxxx.Xxxxxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226960) xxxxxxxxx xxx xxxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxxxxxxx xxx xxxxxxxx xxxxxx xxxx xxxxx xxxxxxx xxx XxxXxxxxxx. Xxxx xxx xx xxxxxx xxx xxxxxxxx xxxxxxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx xx xxxx xxx.

Xx xxxxx xxxxxxxxxxx xx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241319), [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226882), xx [**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226906) xxxxxxxxx xx xxxxxxxx xx xx **XXXXXXX** xxxxx. Xxx [**XxxxxxXxxxx.XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701462) xxxxxx xx xxxx xx xxxxxxx x xxxxxxx xxxxx xxxx x xxxxxx xxxxxxxxx xx x [**XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701457) xxxxxxxxxxx xxxxx. Xxxx xx xxx **XxxxxxXxxxxXxxxxx** xxxxxxxxxxx xxxxxx xxxxxxxxxx xx xx xxxxx xxxxxxxx xx xxx xxxxxx Xxxxxxx xxxxxxx xxxxxxxxx. Xx xxx xxx xxxxxx xx xxxxxxxx **XxxxxxXxxxxXxxxxx** xxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxx xx xxx xxxxxxxxx.

Xx xxxxx xxxxxxxxxxx xx x [**XxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226842) xx [**XxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br226923) xxxxxxxxx xx xxxxxxxx xx xx **XXXXXXX** xxxxx. Xxx [**XxxXxxxxxXxxxx.XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701529) xxxxxx xx xxxx xx xxxxxxx x xxxxxxx xxxxx xxxx x XxxXxxxxx xxxxxxxxx xx x [**XxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh747818) xxxxxxxxxxx xxxxx. Xxxx xx xxx **XxxXxxxxXxxxxx** xxxxxxxxxxx xxxxxx xxxxxxxxxx xx xx xxxxx xxxxxxxx xx xxx xxxxxx XXXX xxxxxx xxxxxxxxx. Xx xxx xxx xxxxxx xx xxxxxxxx **XxxXxxxxXxxxxx** xxxxxxxxxxx xxxxxx xx xxxxxx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxx xx xxx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxxxxxx xxxxxx, xx xxx xxx xxxx xxx xxx **XXXXXXX** xxxx xxx xxxxxxxxx xx xxxxx xxxx xxxxxxxx xxxxxxxxxxx xx xxx xxxxx xxxx xxxxxx xxx xxxxxxxxx. Xxxxxxxx **XXXXXXX** xxxxxx xxx xxxxxx xx xxx *Xxxxxxxx.x* xxxxxx xxxx. Xxx xxxx xxxxxxxxx xxxxxxxxxx xxxxxx, xxx **XXXXXXX** xxxxxxxx xx **X\_XXXXXXXXXX**.

## Xxx Xxxxxxx XXX

Xxx xxx xxx [Xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms740673) xx xxxx XXX xxx, xx xxxx. Xxx xxxxxxxxx Xxxxxxx XXX xx xxxxx xx xxxx xx Xxxxxxx Xxxxx Y.YXxxxxxxxx Xxxxxxxxxxx xxx xxxxxxxxx xx xxxxxxx xxxx xx xxx xxxxx, xxxxxxxxxx xxx xxxxxxx (xxxx XXXx xxxx xxx xxxxxxxxxx xxxxxxxx xxxx xxxx xxxxxxx). Xxx xxx xxxx xxxx xxxxxxxxxxx xx Xxxxxxx xxxxxxxxxxx [xxxx](https://msdn.microsoft.com/library/windows/desktop/ms740673).


<!--HONumber=Mar16_HO1-->
