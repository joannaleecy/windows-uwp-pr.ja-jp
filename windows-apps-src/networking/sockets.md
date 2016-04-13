---
description: ユニバーサル Windows プラットフォーム (UWP) アプリ開発者として、Windows.Networking.Sockets と Winsock の両方を使って、他のデバイスと通信できます。
title: ソケット
ms.assetid: 23B10A3C-E33F-4CD6-92CB-0FFB491472D6
---

# ソケット

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

**重要な API**

-   [**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960)
-   [Winsock](https://msdn.microsoft.com/library/windows/desktop/ms740673)

ユニバーサル Windows プラットフォーム (UWP) アプリ開発者として、[**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) と [Winsock](https://msdn.microsoft.com/library/windows/desktop/ms737523) の両方を使って、他のデバイスと通信できます。 このトピックでは、**Windows.Networking.Sockets** 名前空間を使ってネットワーク操作を実行する方法の詳しいガイダンスを示します。

## 基本的な TCP ソケット操作

TCP ソケットは、有効期間が長い接続用にどちらの方向にも下位レベルのネットワーク データ転送機能を提供します。 TCP ソケットは、インターネットで使われるほとんどのネットワーク プロトコルのベースとなる機能です。 このセクションでは、UWP アプリで [**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間の一部として [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスと [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) クラスを使って TCP ストリーム ソケットでデータを送受信する方法について説明します。 このセクションでは、基本的な TCP 操作を示すためにエコー サーバーおよびクライアントとして機能する非常にシンプルなアプリを作成します。

**TCP エコー サーバーの作成**

次のコード例は、[**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) オブジェクトを作成し、着信 TCP 接続のリッスンを開始する方法を示しています。

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

次のコード例では、上の例で [**StreamSocketListener.ConnectionReceived**](https://msdn.microsoft.com/library/windows/apps/hh701494) イベントにアタッチされている SocketListener\_ConnectionReceived イベント ハンドラーが実装されています。 このイベント ハンドラーは、リモート クライアントがエコ サーバーとの接続を確立するたびに [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) クラスにより呼び出されます。

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

**TCP エコー クライアントの作成**

次のコード例は、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) オブジェクトの作成、リモート サーバーへの接続の確立、要求の送信、および応答の受信の方法を示しています。

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

## 基本的な UDP ソケット操作

UDP ソケットは、確立された接続が必要なネットワーク通信用にどちらの方向にも下位レベルのネットワーク データ転送機能を提供します。 UDP ソケットはどちらのエンドポイントでも接続を保持しないため、リモート コンピューター間のネットワークに高速でシンプルなソリューションを提供します。 ただし、UDP ソケットは、ネットワーク パケットの整合性や、リモートの宛先に到達するかどうかをまったく保証しません。 UDP ソケットを使うアプリケーションの例には、ローカル ネットワーク探索やローカル チャット クライアントなどがあります。 このセクションでは、[**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) クラスを使って、シンプルなエコ サーバーおよびクライアントを作成することで UDP メッセージを送受信する方法を示します。

**UDP エコー サーバーの作成**

次のコード例は、[**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) オブジェクトを作成し、着信 UDP メッセージをリッスンできるように特定のポートにバインドする方法を示しています。

```csharp
Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

socket.MessageReceived += Socket_MessageReceived;

//You can use any port that is not currently in use already on the machine.
string serverPort = "1337";

//Bind the socket to the serverPort so that we can start listening for UDP messages from the UDP echo client.
await socket.BindServiceNameAsync(serverPort);
```

次のコード例では、クライアントから受信したメッセージを読み取り、同じメッセージを返送する **Socket\_MessageReceived** イベント ハンドラーが実装されています。

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

**UDP エコー クライアントの作成**

次のコード例は、[**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) オブジェクトを作成し、着信 UDP メッセージをリッスンして UDP エコ サーバーに UDP メッセージを送信できるように特定のポートにバインドする方法を示しています。

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

次のコード例では、UDP エコ サーバーから受信したメッセージを読み取る **Socket\_MessageReceived** イベント ハンドラーが実装されています。

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

## バック グラウンド操作とソケット ブローカー

アプリがソケットで接続またはデータを受信する場合は、アプリがフォアグラウンドにないときにこれらの操作が正しく実行されるように準備する必要があります。 そのために、ソケット ブローカーを使います。 ソケット ブローカーの使い方について詳しくは、「[バックグラウンドでのネットワーク通信](network-communications-in-the-background.md)」をご覧ください。

## バッチ送信

Windows 10 以降、Windows.Networking.Sockets はバッチ送信をサポートします。これは、データの複数のバッファーをまとめて送信することで、各バッファーを別々に送信する場合に比べ、コンテキスト切り替えのオーバーヘッドを非常に少なくする方法です。 これは、多くのデータをできるだけ効率的に移動させる必要がある VoIP、VPN、またはその他のタスクをアプリで実行する場合に特に便利です。

ソケットで WriteAsync が呼び出されるたびに、ネットワーク スタックに到達するためにカーネルの遷移がトリガーされます。 アプリが一度に多数のバッファーを書き込むと、書き込みごとに別のカーネルの遷移が発生し、これによって大量のオーバーヘッドが発生します。 新しいバッチ送信パターンは、カーネルの遷移の発生頻度を最適化します。 この機能は、現時点では [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) インスタンスと、接続された [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) インスタンスに限定されます。

次に示すのは、多数のバッファーを最適化されない方法で送信するアプリの例です。

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

次の例は、多数のバッファーを送信するための効率的な方法を示しています。 この手法は C# 言語固有の機能を使っているため、C# プログラマだけが利用できます。 この例では、一度に複数のパケットを送信することでシステムが送信をバッチ処理できるようにし、それによってカーネルの遷移が最適化され、パフォーマンスが向上しています。

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

次の例は、バッチ送信と互換性がある方法で、多数のバッファーを送信する別の方法を示しています。 ここでは C# 固有の機能は使われていないため、すべての言語に適用できます (ここでは C# を使っています)。 代わりに、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスと [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) クラスの **OutputStream** メンバーの変更された動作を使っています。これは Windows 10 で新しく導入された動作です。

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

これまでのバージョンの Windows では、**FlushAsync** はすぐに返り、ストリームに対するすべての動作が完了しているかどうかは保証されませんでした。 Windows 10 では、この動作が変更されています。 **FlushAsync** は、出力ストリームに対するすべての操作が完了した後で返ることが保証されるようになりました。

コードでバッチ処理される書き込みを使うことで課せられているいくつかの重要な制限があります。

-   書き込まれる **IBuffer** インスタンスの内容は、非同期書き込みが完了するまで変更できません。
-   **FlushAsync**パターンは、**StreamSocket.OutputStream** と **DatagramSocket.OutputStream** のみで機能します。
-   **FlushAsync** パターンは、Windows 10 以降でのみ機能します。
-   状況によっては、**FlushAsync** パターンの代わりに **Task.WaitAll** を使います。

## DatagramSocket でのポートの共有

Windows 10 では、[**MulticastOnly**](https://msdn.microsoft.com/library/windows/apps/dn895368) という新しい [**DatagramSocketControl**](https://msdn.microsoft.com/library/windows/apps/hh701190) プロパティが導入されています。このプロパティを使って、対象の **DatagramSocket** を、同じアドレス/ポートにバインドされた他の Win32 または WinRT マルチキャスト ソケットと共存させることができます。

## StreamSocket クラスによるクライアント証明書の提供

[
            **Windows.Networking.StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスは、SSL/TLS を使ったアプリの接続先サーバーの認証をサポートします。 場合によっては、アプリは、TLS クライアント証明書を使って自身をサーバーに対して認証する必要があります。 Windows 10 では、クライアント証明書を [**StreamSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226893) オブジェクトに提供できます (これは TLS ハンドシェイクが開始される前に設定する必要があります)。 サーバーがクライアント証明書を要求した場合、Windows が提供された証明書を使って応答します。

これを実装する方法を示すコード スニペットを次に示します。

```csharp
var socket = new StreamSocket();
Windows.Security.Cryptography.Certificates.Certificate certificate = await GetClientCert();
socket.Control.ClientCertificate = certificate;
await socket.ConnectAsync(destination, SocketProtectionLevel.Tls12);
```

## Windows.Networking.Sockets の例外

ソケットと共に使われる [**HostName**](https://msdn.microsoft.com/library/windows/apps/br207113) クラスのコンストラクターは、有効なホスト名ではない (ホスト名に使うことができない文字が含まれている) 文字列が渡された場合に例外をスローすることができます。 アプリがユーザーから **HostName** の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。 例外がスローされた場合、アプリは、ユーザーに通知し、新しいホスト名を要求することができます。

[
            **Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間には、ソケットと WebSocket を使う場合のエラーの処理に便利なヘルパー メソッドと列挙があります。 これは、アプリで特定のネットワーク例外を異なる方法で処理する場合に役立つことがあります。

[
            **DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)、[**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) 操作で発生したエラーは、**HRESULT** 値として返されます。 [
            **SocketError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701462) メソッドは、ネットワーク エラーをソケット操作から [**SocketErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh701457) 列挙値に変換するために使われます。 ほとんどの **SocketErrorStatus** 列挙値は、ネイティブ Windows ソケット操作から返されるエラーに対応しています。 アプリは特定の **SocketErrorStatus** 列挙値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。

[
            **MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) 操作で発生したエラーは **HRESULT** 値として返されます。 ネットワーク エラーを WebSocket 操作から [**WebErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh747818) 列挙値に変換するには、[**WebSocketError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701529) メソッドを使います。 **WebErrorStatus** 列挙値のほとんどは、ネイティブ HTTP クライアント操作から返されるエラーに対応しています。 アプリは特定の **WebErrorStatus** 列挙値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。

パラメーター検証エラーの場合は、例外の **HRESULT** を使って、その例外の原因となったエラーの詳細情報を確認することもできます。 使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。 ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。

## Winsock API

[Winsock](https://msdn.microsoft.com/library/windows/desktop/ms740673) は、UWP アプリでも同じように使うことができます。 サポートされる Winsock API は Windows Phone 8.1 Microsoft Silverlight に基づいており、ほとんどの型、プロパティ、メソッドが引き続きサポートされます (互換性のために残されていたいくつかの API は削除されます)。 Winsock プログラミングについて詳しくは、[こちら](https://msdn.microsoft.com/library/windows/desktop/ms740673)をご覧ください。




<!--HONumber=Mar16_HO1-->


