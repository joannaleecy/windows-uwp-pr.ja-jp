---
author: stevewhims
description: WebSocket は、クライアントとサーバー間の高速で安全な双方向通信を、HTTP(S) を使った Web 経由で実現するメカニズムを提供し、UTF-8 メッセージとバイナリ メッセージの両方をサポートします。
title: WebSocket
ms.assetid: EAA9CB3E-6A3A-4C13-9636-CCD3DE46E7E2
ms.author: stwhi
ms.date: 06/04/2018
ms.topic: article
keywords: windows 10, uwp, ネットワーク, websocket, messagewebsocket, streamwebsocket
ms.localizationpriority: medium
ms.openlocfilehash: eaba8d7b87d9e2762d13bd86629ee4a996e2d5e8
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7568523"
---
# <a name="websockets"></a><span data-ttu-id="be2c9-104">WebSocket</span><span class="sxs-lookup"><span data-stu-id="be2c9-104">WebSockets</span></span>
<span data-ttu-id="be2c9-105">WebSocket は、クライアントとサーバー間の高速で安全な双方向通信を、HTTP(S) を使った Web 経由で実現するメカニズムを提供し、UTF-8 メッセージとバイナリ メッセージの両方をサポートします。</span><span class="sxs-lookup"><span data-stu-id="be2c9-105">WebSockets provide a mechanism for fast, secure, two-way communication between a client and a server over the web using HTTP(S), and supporting both UTF-8 and binary messages.</span></span>

<span data-ttu-id="be2c9-106">[WebSocket プロトコル](http://tools.ietf.org/html/rfc6455)では、データはすぐに、全二重の 1 つのソケット接続によって転送され、両方のエンドポイント間のメッセージの送受信をリアルタイムで実行できます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-106">Under the [WebSocket Protocol](http://tools.ietf.org/html/rfc6455), data is transferred immediately over a full-duplex single socket connection, allowing messages to be sent and received from both endpoints in real time.</span></span> <span data-ttu-id="be2c9-107">WebSocket はマルチプレイヤー ゲーム (リアルタイムとターン制のどちらも)、ソーシャル ネットワークのインスタント通知、株価や天気予報のリアルタイム表示、セキュリティや高速なデータ転送を必要とするアプリなど、Microsoft Store アプリでの使用に適しています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-107">WebSockets are ideal for use in multiplayer gaming (both real-time and turn-based), instant social network notifications, up-to-date displays of stock or weather information, and other apps requiring secure and fast data transfer.</span></span>

<span data-ttu-id="be2c9-108">WebSocket 接続を確立するには、クライアントとサーバー間で専用の HTTP ベースのハンドシェークをやり取りします。</span><span class="sxs-lookup"><span data-stu-id="be2c9-108">To establish a WebSocket connection, a specific, HTTP-based handshake is exchanged between the client and the server.</span></span> <span data-ttu-id="be2c9-109">成功した場合、直前に確立された TCP 接続を使って、アプリケーション レイヤー プロトコルが HTTP から WebSocket に "アップグレード" されます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-109">If successful, the application-layer protocol is "upgraded" from HTTP to WebSockets, using the previously established TCP connection.</span></span> <span data-ttu-id="be2c9-110">この時点で、HTTP は完全に不要となります。WebSocket 接続が閉じるまで、データの送受信は、両方のエンドポイントから WebSocket プロトコルを使って行うことができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-110">Once this occurs, HTTP is completely out of the picture; data can be sent or received using the WebSocket protocol by both endpoints, until the WebSocket connection is closed.</span></span>

<span data-ttu-id="be2c9-111">**注** クライアントとサーバーの両方が WebSocket プロトコルを使っていないと、クライアントは WebSocket を使ってデータを転送することはできません。</span><span class="sxs-lookup"><span data-stu-id="be2c9-111">**Note** A client cannot use WebSockets to transfer data unless the server also uses the WebSocket protocol.</span></span> <span data-ttu-id="be2c9-112">サーバーが WebSocket をサポートしていない場合は、別の方法でデータ転送を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-112">If the server does not support WebSockets, then you must use another method of data transfer.</span></span>

<span data-ttu-id="be2c9-113">ユニバーサル Windows プラットフォーム (UWP) は、クライアントとサーバーの両方について、WebSocket の使用をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-113">The Universal Windows Platform (UWP) provides support for both client and server use of WebSockets.</span></span> <span data-ttu-id="be2c9-114">[**Windows.Networking.Sockets**](/uwp/api/windows.networking.sockets) 名前空間には、クライアントが使うことのできる 2 つの WebSocket クラスが定義されています。それらは、&mdash;[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) と [**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) です。</span><span class="sxs-lookup"><span data-stu-id="be2c9-114">The [**Windows.Networking.Sockets**](/uwp/api/windows.networking.sockets) namespace defines two WebSocket classes for use by clients&mdash;[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket), and [**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket).</span></span> <span data-ttu-id="be2c9-115">これら 2 つの WebSocket クラスの比較を次に示します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-115">Here's a comparison of these two WebSocket classes.</span></span>

| [<span data-ttu-id="be2c9-116">MessageWebSocket</span><span class="sxs-lookup"><span data-stu-id="be2c9-116">MessageWebSocket</span></span>](/uwp/api/windows.networking.sockets.messagewebsocket) | [<span data-ttu-id="be2c9-117">StreamWebSocket</span><span class="sxs-lookup"><span data-stu-id="be2c9-117">StreamWebSocket</span></span>](/uwp/api/windows.networking.sockets.streamwebsocket) |
| - | - |
| <span data-ttu-id="be2c9-118">WebSocket メッセージ全体の読み取りや書き込みが 1 回の操作で行われます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-118">An entire WebSocket message is read/written in a single operation.</span></span> | <span data-ttu-id="be2c9-119">メッセージのセクションを、何回かに分けて読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-119">Sections of a message can be read with each read operation.</span></span> |
| <span data-ttu-id="be2c9-120">メッセージがあまり大きくない場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-120">Suitable when messages are not very large.</span></span> | <span data-ttu-id="be2c9-121">かなり大きなファイル (写真やビデオなど) を転送する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-121">Suitable when very large files (such as photos or videos) are being transferred.</span></span> |
| <span data-ttu-id="be2c9-122">UTF-8 とバイナリの両方のメッセージがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-122">Supports both UTF-8 and binary messages.</span></span> | <span data-ttu-id="be2c9-123">バイナリ メッセージのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-123">Supports only binary messages.</span></span> |
| <span data-ttu-id="be2c9-124">[UDP またはデータグラム ソケット](sockets.md#build-a-basic-udp-socket-client-and-server)に似ていますが (頻繁に送信される小さいメッセージに使用されるという意味で)、TCP の信頼性、パケット順序の保証、輻輳制御が提供されます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-124">Similar to a [UDP or datagram socket](sockets.md#build-a-basic-udp-socket-client-and-server) (in the sense of being intended for frequent, small messages), but with TCP's reliability, packet order guarantees, and congestion control.</span></span> | <span data-ttu-id="be2c9-125">[TCP またはストリーム ソケット](sockets.md#build-a-basic-tcp-socket-client-and-server)に似ています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-125">Similar to a [TCP or stream socket](sockets.md#build-a-basic-tcp-socket-client-and-server).</span></span> |

## <a name="secure-your-connection-with-tlsssl"></a><span data-ttu-id="be2c9-126">TLS/SSL による接続の保護</span><span class="sxs-lookup"><span data-stu-id="be2c9-126">Secure your connection with TLS/SSL</span></span>
<span data-ttu-id="be2c9-127">ほとんどの場合、セキュリティ保護された WebSocket 接続を使って、送受信するデータを暗号化できます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-127">In most cases, you'll want to  use a secure WebSocket connection so that the data you send and receive is encrypted.</span></span> <span data-ttu-id="be2c9-128">ファイアウォールやプロキシなどの多くの中継点は、暗号化されていない WebSocket 接続を拒否するため、接続の成功率も高くなります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-128">This will also increase the chances that your connection will succeed, because many intermediaries such as firewalls and proxies reject unencrypted WebSocket connections.</span></span> <span data-ttu-id="be2c9-129">[WebSocket プロトコル](https://tools.ietf.org/html/rfc6455#section-3)には、以下の 2 つの URI スキームが定義されています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-129">The [WebSocket protocol](https://tools.ietf.org/html/rfc6455#section-3) defines these two URI schemes.</span></span>

| <span data-ttu-id="be2c9-130">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="be2c9-130">URI scheme</span></span> | <span data-ttu-id="be2c9-131">目的</span><span class="sxs-lookup"><span data-stu-id="be2c9-131">Purpose</span></span> |
| - | - |
| <span data-ttu-id="be2c9-132">wss:</span><span class="sxs-lookup"><span data-stu-id="be2c9-132">wss:</span></span> | <span data-ttu-id="be2c9-133">セキュリティ保護された、暗号化を必要とする接続に使われます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-133">Use for secure connections that should be encrypted.</span></span> |
| <span data-ttu-id="be2c9-134">ws:</span><span class="sxs-lookup"><span data-stu-id="be2c9-134">ws:</span></span> | <span data-ttu-id="be2c9-135">暗号化されていない接続に使われます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-135">Use for unencrypted connections.</span></span> |

<span data-ttu-id="be2c9-136">WebSocket 接続を暗号化するには、`wss:` URI スキームを使います。</span><span class="sxs-lookup"><span data-stu-id="be2c9-136">To encrypt your WebSocket connection, use the `wss:` URI scheme.</span></span> <span data-ttu-id="be2c9-137">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-137">Here's an example.</span></span>

```csharp
protected override async void OnNavigatedTo(NavigationEventArgs e)
{
    var webSocket = new Windows.Networking.Sockets.MessageWebSocket();
    await webSocket.ConnectAsync(new Uri("wss://www.contoso.com/mywebservice"));
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml::Navigation;
...
IAsyncAction OnNavigatedTo(NavigationEventArgs /* e */)
{
    Windows::Networking::Sockets::MessageWebSocket webSocket;
    co_await webSocket.ConnectAsync(Uri{ L"wss://www.contoso.com/mywebservice" });
}
```

## <a name="use-messagewebsocket-to-connect"></a><span data-ttu-id="be2c9-138">MessageWebSocket を使用した接続</span><span class="sxs-lookup"><span data-stu-id="be2c9-138">Use MessageWebSocket to connect</span></span>
<span data-ttu-id="be2c9-139">[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) を使うと、WebSocket メッセージ全体の読み取りや書き込みを 1 回の操作で行うことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-139">[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) allows an entire WebSocket message to be read/written in a single operation.</span></span> <span data-ttu-id="be2c9-140">したがって、メッセージがあまり大きくない場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-140">Consequently, it's suitable when messages are not very large.</span></span> <span data-ttu-id="be2c9-141">このクラスでは、UTF-8 とバイナリの両方のメッセージがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-141">The class supports both UTF-8 and binary messages.</span></span>

<span data-ttu-id="be2c9-142">以下のコード例では、送信されたメッセージを送信元にエコー バックするサービス、WebSocket.org エコー サーバーを使っています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-142">The example code below uses the WebSocket.org echo server&mdash;a service that echoes back to the sender any message sent to it.</span></span>

```csharp
private Windows.Networking.Sockets.MessageWebSocket messageWebSocket;

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    this.messageWebSocket = new Windows.Networking.Sockets.MessageWebSocket();

    // In this example, we send/receive a string, so we need to set the MessageType to Utf8.
    this.messageWebSocket.Control.MessageType = Windows.Networking.Sockets.SocketMessageType.Utf8;

    this.messageWebSocket.MessageReceived += WebSocket_MessageReceived;
    this.messageWebSocket.Closed += WebSocket_Closed;

    try
    {
        Task connectTask = this.messageWebSocket.ConnectAsync(new Uri("wss://echo.websocket.org")).AsTask();
        connectTask.ContinueWith(_ => this.SendMessageUsingMessageWebSocketAsync("Hello, World!"));
    }
    catch (Exception ex)
    {
        Windows.Web.WebErrorStatus webErrorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.GetBaseException().HResult);
        // Add additional code here to handle exceptions.
    }
}

private async Task SendMessageUsingMessageWebSocketAsync(string message)
{
    using (var dataWriter = new DataWriter(this.messageWebSocket.OutputStream))
    {
        dataWriter.WriteString(message);
        await dataWriter.StoreAsync();
        dataWriter.DetachStream();
    }
    Debug.WriteLine("Sending message using MessageWebSocket: " + message);
}

private void WebSocket_MessageReceived(Windows.Networking.Sockets.MessageWebSocket sender, Windows.Networking.Sockets.MessageWebSocketMessageReceivedEventArgs args)
{
    try
    {
        using (DataReader dataReader = args.GetDataReader())
        {
            dataReader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            string message = dataReader.ReadString(dataReader.UnconsumedBufferLength);
            Debug.WriteLine("Message received from MessageWebSocket: " + message);
            this.messageWebSocket.Dispose();
        }
    }
    catch (Exception ex)
    {
        Windows.Web.WebErrorStatus webErrorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.GetBaseException().HResult);
        // Add additional code here to handle exceptions.
    }
}

private void WebSocket_Closed(Windows.Networking.Sockets.IWebSocket sender, Windows.Networking.Sockets.WebSocketClosedEventArgs args)
{
    Debug.WriteLine("WebSocket_Closed; Code: " + args.Code + ", Reason: \"" + args.Reason + "\"");
    // Add additional code here to handle the WebSocket being closed.
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::MessageWebSocket m_messageWebSocket;
    winrt::event_token m_messageReceivedEventToken;
    winrt::event_token m_closedEventToken;

public:
    IAsyncAction OnNavigatedTo(NavigationEventArgs /* e */)
    {
        // In this example, we send/receive a string, so we need to set the MessageType to Utf8.
        m_messageWebSocket.Control().MessageType(Windows::Networking::Sockets::SocketMessageType::Utf8);

        m_messageReceivedEventToken = m_messageWebSocket.MessageReceived({ this, &MessageWebSocketPage::OnWebSocketMessageReceived });
        m_closedEventToken = m_messageWebSocket.Closed({ this, &MessageWebSocketPage::OnWebSocketClosed });

        try
        {
            co_await m_messageWebSocket.ConnectAsync(Uri{ L"wss://echo.websocket.org" });
            SendMessageUsingMessageWebSocketAsync(L"Hello, World!");
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus{ Windows::Networking::Sockets::WebSocketError::GetStatus(ex.to_abi()) };
            // Add additional code here to handle exceptions.
        }
    }

private:
    IAsyncAction SendMessageUsingMessageWebSocketAsync(std::wstring message)
    {
        DataWriter dataWriter{ m_messageWebSocket.OutputStream() };
        dataWriter.WriteString(message);

        co_await dataWriter.StoreAsync();
        dataWriter.DetachStream();
        std::wstringstream wstringstream;
        wstringstream << L"Sending message using MessageWebSocket: " << message.c_str() << std::endl;
        ::OutputDebugString(wstringstream.str().c_str());
    }

    void OnWebSocketMessageReceived(Windows::Networking::Sockets::MessageWebSocket const& /* sender */, Windows::Networking::Sockets::MessageWebSocketMessageReceivedEventArgs const& args)
    {
        try
        {
            DataReader dataReader{ args.GetDataReader() };

            dataReader.UnicodeEncoding(Windows::Storage::Streams::UnicodeEncoding::Utf8);
            auto message = dataReader.ReadString(dataReader.UnconsumedBufferLength());
            std::wstringstream wstringstream;
            wstringstream << L"Message received from MessageWebSocket: " << message.c_str() << std::endl;
            ::OutputDebugString(wstringstream.str().c_str());
            m_messageWebSocket.Close(1000, L"");
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus{ Windows::Networking::Sockets::WebSocketError::GetStatus(ex.to_abi()) };
            // Add additional code here to handle exceptions.
        }
    }

    void OnWebSocketClosed(Windows::Networking::Sockets::IWebSocket const& /* sender */, Windows::Networking::Sockets::WebSocketClosedEventArgs const& args)
    {
        std::wstringstream wstringstream;
        wstringstream << L"WebSocket_Closed; Code: " << args.Code() << ", Reason: \"" << args.Reason().c_str() << "\"" << std::endl;
        ::OutputDebugString(wstringstream.str().c_str());
        // Add additional code here to handle the WebSocket being closed.
    }
```

```cpp
#include <ppltasks.h>
#include <sstream>
...
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::MessageWebSocket^ messageWebSocket;

protected:
    virtual void OnNavigatedTo(NavigationEventArgs^ e) override
    {
        this->messageWebSocket = ref new Windows::Networking::Sockets::MessageWebSocket();

        // In this example, we send/receive a string, so we need to set the MessageType to Utf8.
        this->messageWebSocket->Control->MessageType = Windows::Networking::Sockets::SocketMessageType::Utf8;

        this->messageWebSocket->MessageReceived += ref new TypedEventHandler<Windows::Networking::Sockets::MessageWebSocket^, Windows::Networking::Sockets::MessageWebSocketMessageReceivedEventArgs^>(this, &MessageWebSocketPage::WebSocket_MessageReceived);
        this->messageWebSocket->Closed += ref new TypedEventHandler<Windows::Networking::Sockets::IWebSocket^, Windows::Networking::Sockets::WebSocketClosedEventArgs^>(this, &MessageWebSocketPage::WebSocket_Closed);

        try
        {
            auto connectTask = Concurrency::create_task(this->messageWebSocket->ConnectAsync(ref new Uri(L"wss://echo.websocket.org")));
            connectTask.then([this] { this->SendMessageUsingMessageWebSocketAsync(L"Hello, World!"); });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus = Windows::Networking::Sockets::WebSocketError::GetStatus(ex->HResult);
            // Add additional code here to handle exceptions.
        }
    }

private:
    void SendMessageUsingMessageWebSocketAsync(Platform::String^ message)
    {
        auto dataWriter = ref new DataWriter(this->messageWebSocket->OutputStream);
        dataWriter->WriteString(message);

        Concurrency::create_task(dataWriter->StoreAsync()).then(
            [=](unsigned int)
        {
            dataWriter->DetachStream();
            std::wstringstream wstringstream;
            wstringstream << L"Sending message using MessageWebSocket: " << message->Data() << std::endl;
            ::OutputDebugString(wstringstream.str().c_str());
        });
    }

    void WebSocket_MessageReceived(Windows::Networking::Sockets::MessageWebSocket^ sender, Windows::Networking::Sockets::MessageWebSocketMessageReceivedEventArgs^ args)
    {
        try
        {
            DataReader^ dataReader = args->GetDataReader();

            dataReader->UnicodeEncoding = Windows::Storage::Streams::UnicodeEncoding::Utf8;
            Platform::String^ message = dataReader->ReadString(dataReader->UnconsumedBufferLength);
            std::wstringstream wstringstream;
            wstringstream << L"Message received from MessageWebSocket: " << message->Data() << std::endl;
            ::OutputDebugString(wstringstream.str().c_str());
            this->messageWebSocket->Close(1000, L"");
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus = Windows::Networking::Sockets::WebSocketError::GetStatus(ex->HResult);
            // Add additional code here to handle exceptions.
        }
    }

    void WebSocket_Closed(Windows::Networking::Sockets::IWebSocket^ sender, Windows::Networking::Sockets::WebSocketClosedEventArgs^ args)
    {
        std::wstringstream wstringstream;
        wstringstream << L"WebSocket_Closed; Code: " << args->Code << ", Reason: \"" << args->Reason->Data() << "\"" << std::endl;
        ::OutputDebugString(wstringstream.str().c_str());
        // Add additional code here to handle the WebSocket being closed.
    }
```

### <a name="handle-the-messagewebsocketmessagereceived-and-messagewebsocketclosed-events"></a><span data-ttu-id="be2c9-143">MessageWebSocket.MessageReceived イベントと MessageWebSocket.Closed イベントの処理</span><span class="sxs-lookup"><span data-stu-id="be2c9-143">Handle the MessageWebSocket.MessageReceived and MessageWebSocket.Closed events</span></span>
<span data-ttu-id="be2c9-144">上の例のように、**MessageWebSocket** を使って接続を確立してデータを送信する前に、[**MessageWebSocket.MessageReceived**](/uwp/api/windows.networking.sockets.messagewebsocket.MessageReceived) イベントと [**MessageWebSocket.Closed**](/uwp/api/windows.networking.sockets.messagewebsocket.Closed) イベントにサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-144">As shown in the example above, before establishing a connection and sending data with a **MessageWebSocket**, you should subscribe to the [**MessageWebSocket.MessageReceived**](/uwp/api/windows.networking.sockets.messagewebsocket.MessageReceived) and  [**MessageWebSocket.Closed**](/uwp/api/windows.networking.sockets.messagewebsocket.Closed) events.</span></span>
 
<span data-ttu-id="be2c9-145">データを受信すると **MessageReceived** が発生します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-145">**MessageReceived** is raised when data is received.</span></span> <span data-ttu-id="be2c9-146">データには、[**MessageWebSocketMessageReceivedEventArgs**](/uwp/api/windows.networking.sockets.messagewebsocketmessagereceivedeventargs) 経由でアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-146">The data can be accessed via [**MessageWebSocketMessageReceivedEventArgs**](/uwp/api/windows.networking.sockets.messagewebsocketmessagereceivedeventargs).</span></span> <span data-ttu-id="be2c9-147">クライアントまたはサーバーがソケットを閉じると **Closed** が発生します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-147">**Closed** is raised when the client or the server closes the socket.</span></span>
 
### <a name="send-data-on-a-messagewebsocket"></a><span data-ttu-id="be2c9-148">MessageWebSocket でのデータの送信</span><span class="sxs-lookup"><span data-stu-id="be2c9-148">Send data on a MessageWebSocket</span></span>
<span data-ttu-id="be2c9-149">接続が確立されたら、サーバーにデータを送信できます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-149">Once a connection is established, you can send data to the server.</span></span> <span data-ttu-id="be2c9-150">これを行うには、[**MessageWebSocket.OutputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.MessageWebSocket.OutputStream) プロパティと [**DataWriter**](/uwp/api/windows.storage.streams.datawriter) を使って、データを書き込みます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-150">You do this by using the [**MessageWebSocket.OutputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.MessageWebSocket.OutputStream) property, and a [**DataWriter**](/uwp/api/windows.storage.streams.datawriter), to write the data.</span></span> 

<span data-ttu-id="be2c9-151">**注:** **DataWriter** が出力ストリームの所有権を取得します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-151">**Note** The **DataWriter** takes ownership of the output stream.</span></span> <span data-ttu-id="be2c9-152">**DataWriter** がスコープ外になると、出力ストリームがそれにアタッチされている場合は **DataWriter** は出力ストリームの割り当てを解除します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-152">When the **DataWriter** goes out of scope, if the output stream is attached to it, the **DataWriter** deallocates the output stream.</span></span> <span data-ttu-id="be2c9-153">その後、出力ストリームを使おうとすると、HRESULT 値 0x80000013 のエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-153">After that, subsequent attempts to use the output stream fail with an HRESULT value of 0x80000013.</span></span> <span data-ttu-id="be2c9-154">ただし、[**DataWriter.DetachStream**](/uwp/api/windows.storage.streams.datawriter.DetachStream) を呼び出して **DataWriter** から出力ストリームをデタッチし、ストリームの所有権を **MessageWebSocket** に返すことができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-154">But you can call [**DataWriter.DetachStream**](/uwp/api/windows.storage.streams.datawriter.DetachStream) to detach the output stream from the **DataWriter** and return ownership of the stream to the **MessageWebSocket**.</span></span>

## <a name="use-streamwebsocket-to-connect"></a><span data-ttu-id="be2c9-155">StreamWebSocket を使用した接続</span><span class="sxs-lookup"><span data-stu-id="be2c9-155">Use StreamWebSocket to connect</span></span>
<span data-ttu-id="be2c9-156">[**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) を使うと、メッセージを分割し、何回かに分けて読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-156">[**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) allows sections of a message to be read with each read operation.</span></span> <span data-ttu-id="be2c9-157">したがって、かなり大きなファイル (写真やビデオなど) を転送する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-157">Consequently, it's suitable when very large files (such as photos or videos) are being transferred.</span></span> <span data-ttu-id="be2c9-158">このクラスでは、バイナリ メッセージのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-158">The class supports only binary messages.</span></span>

<span data-ttu-id="be2c9-159">以下のコード例では、送信されたメッセージを送信元にエコー バックするサービス、WebSocket.org エコー サーバーを使っています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-159">The example code below uses the WebSocket.org echo server&mdash;a service that echoes back to the sender any message sent to it.</span></span>

```csharp
private Windows.Networking.Sockets.StreamWebSocket streamWebSocket;

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    this.streamWebSocket = new Windows.Networking.Sockets.StreamWebSocket();

    this.streamWebSocket.Closed += WebSocket_Closed;

    try
    {
        Task connectTask = this.streamWebSocket.ConnectAsync(new Uri("wss://echo.websocket.org")).AsTask();

        connectTask.ContinueWith(_ =>
        {
            Task.Run(() => this.ReceiveMessageUsingStreamWebSocket());
            Task.Run(() => this.SendMessageUsingStreamWebSocket(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 }));
        });
    }
    catch (Exception ex)
    {
        Windows.Web.WebErrorStatus webErrorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.GetBaseException().HResult);
        // Add code here to handle exceptions.
    }
}

private async void ReceiveMessageUsingStreamWebSocket()
{
    try
    {
        using (var dataReader = new DataReader(this.streamWebSocket.InputStream))
        {
            dataReader.InputStreamOptions = InputStreamOptions.Partial;
            await dataReader.LoadAsync(256);
            byte[] message = new byte[dataReader.UnconsumedBufferLength];
            dataReader.ReadBytes(message);
            Debug.WriteLine("Data received from StreamWebSocket: " + message.Length + " bytes");
        }
        this.streamWebSocket.Dispose();
    }
    catch (Exception ex)
    {
        Windows.Web.WebErrorStatus webErrorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.GetBaseException().HResult);
        // Add code here to handle exceptions.
    }
}

private async void SendMessageUsingStreamWebSocket(byte[] message)
{
    try
    {
        using (var dataWriter = new DataWriter(this.streamWebSocket.OutputStream))
        {
            dataWriter.WriteBytes(message);
            await dataWriter.StoreAsync();
            dataWriter.DetachStream();
        }
        Debug.WriteLine("Sending data using StreamWebSocket: " + message.Length.ToString() + " bytes");
    }
    catch (Exception ex)
    {
        Windows.Web.WebErrorStatus webErrorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.GetBaseException().HResult);
        // Add code here to handle exceptions.
    }
}

private void WebSocket_Closed(Windows.Networking.Sockets.IWebSocket sender, Windows.Networking.Sockets.WebSocketClosedEventArgs args)
{
    Debug.WriteLine("WebSocket_Closed; Code: " + args.Code + ", Reason: \"" + args.Reason + "\"");
    // Add additional code here to handle the WebSocket being closed.
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::StreamWebSocket m_streamWebSocket;
    winrt::event_token m_closedEventToken;

public:
    IAsyncAction OnNavigatedTo(NavigationEventArgs /* e */)
    {
        m_closedEventToken = m_streamWebSocket.Closed({ this, &StreamWebSocketPage::OnWebSocketClosed });

        try
        {
            co_await m_streamWebSocket.ConnectAsync(Uri{ L"wss://echo.websocket.org" });
            ReceiveMessageUsingStreamWebSocket();
            SendMessageUsingStreamWebSocket({ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 });
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus{ Windows::Networking::Sockets::WebSocketError::GetStatus(ex.to_abi()) };
            // Add additional code here to handle exceptions.
        }
    }

private:
    IAsyncAction SendMessageUsingStreamWebSocket(std::vector< byte > message)
    {
        try
        {
            DataWriter dataWriter{ m_streamWebSocket.OutputStream() };
            dataWriter.WriteBytes(message);

            co_await dataWriter.StoreAsync();
            dataWriter.DetachStream();
            std::wstringstream wstringstream;
            wstringstream << L"Sending data using StreamWebSocket: " << message.size() << L" bytes" << std::endl;
            ::OutputDebugString(wstringstream.str().c_str());
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus{ Windows::Networking::Sockets::WebSocketError::GetStatus(ex.to_abi()) };
            // Add additional code here to handle exceptions.
        }
    }

    IAsyncAction ReceiveMessageUsingStreamWebSocket()
    {
        try
        {
            DataReader dataReader{ m_streamWebSocket.InputStream() };
            dataReader.InputStreamOptions(InputStreamOptions::Partial);

            unsigned int bytesLoaded = co_await dataReader.LoadAsync(256);
            std::vector< byte > message(bytesLoaded);
            dataReader.ReadBytes(message);
            std::wstringstream wstringstream;
            wstringstream << L"Data received from StreamWebSocket: " << message.size() << " bytes" << std::endl;
            ::OutputDebugString(wstringstream.str().c_str());
            m_streamWebSocket.Close(1000, L"");
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus{ Windows::Networking::Sockets::WebSocketError::GetStatus(ex.to_abi()) };
            // Add additional code here to handle exceptions.
        }
    }

    void OnWebSocketClosed(Windows::Networking::Sockets::IWebSocket const&, Windows::Networking::Sockets::WebSocketClosedEventArgs const& args)
    {
        std::wstringstream wstringstream;
        wstringstream << L"WebSocket_Closed; Code: " << args.Code() << ", Reason: \"" << args.Reason().c_str() << "\"" << std::endl;
        ::OutputDebugString(wstringstream.str().c_str());
        // Add additional code here to handle the WebSocket being closed.
    }
```

```cpp
#include <ppltasks.h>
#include <sstream>
...
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::StreamWebSocket^ streamWebSocket;

protected:
    virtual void OnNavigatedTo(NavigationEventArgs^ e) override
    {
        this->streamWebSocket = ref new Windows::Networking::Sockets::StreamWebSocket();

        this->streamWebSocket->Closed += ref new TypedEventHandler<Windows::Networking::Sockets::IWebSocket^, Windows::Networking::Sockets::WebSocketClosedEventArgs^>(this, &StreamWebSocketPage::WebSocket_Closed);

        try
        {
            auto connectTask = Concurrency::create_task(this->streamWebSocket->ConnectAsync(ref new Uri(L"wss://echo.websocket.org")));

            connectTask.then(
                [=]
            {
                this->ReceiveMessageUsingStreamWebSocket();
                this->SendMessageUsingStreamWebSocket(ref new Platform::Array< byte >{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 });
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus = Windows::Networking::Sockets::WebSocketError::GetStatus(ex->HResult);
            // Add additional code here to handle exceptions.
        }
    }

private:
    void SendMessageUsingStreamWebSocket(const Platform::Array< byte >^ message)
    {
        try
        {
            auto dataWriter = ref new DataWriter(this->streamWebSocket->OutputStream);
            dataWriter->WriteBytes(message);

            Concurrency::create_task(dataWriter->StoreAsync()).then(
                [=](Concurrency::task< unsigned int >) // task< unsigned int > instead of unsigned int in order to handle any exceptions thrown in StoreAsync().
            {
                dataWriter->DetachStream();
                std::wstringstream wstringstream;
                wstringstream << L"Sending data using StreamWebSocket: " << message->Length << L" bytes" << std::endl;
                ::OutputDebugString(wstringstream.str().c_str());
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus = Windows::Networking::Sockets::WebSocketError::GetStatus(ex->HResult);
            // Add additional code here to handle exceptions.
        }
    }

    void ReceiveMessageUsingStreamWebSocket()
    {
        try
        {
            DataReader^ dataReader = ref new DataReader(this->streamWebSocket->InputStream);
            dataReader->InputStreamOptions = InputStreamOptions::Partial;

            Concurrency::create_task(dataReader->LoadAsync(256)).then(
                [=](unsigned int bytesLoaded)
            {
                auto message = ref new Platform::Array< byte >(bytesLoaded);
                dataReader->ReadBytes(message);
                std::wstringstream wstringstream;
                wstringstream << L"Data received from StreamWebSocket: " << message->Length << " bytes" << std::endl;
                ::OutputDebugString(wstringstream.str().c_str());
                this->streamWebSocket->Close(1000, L"");
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus = Windows::Networking::Sockets::WebSocketError::GetStatus(ex->HResult);
            // Add additional code here to handle exceptions.
        }
    }

    void WebSocket_Closed(Windows::Networking::Sockets::IWebSocket^ sender, Windows::Networking::Sockets::WebSocketClosedEventArgs^ args)
    {
        std::wstringstream wstringstream;
        wstringstream << L"WebSocket_Closed; Code: " << args->Code << ", Reason: \"" << args->Reason->Data() << "\"" << std::endl;
        ::OutputDebugString(wstringstream.str().c_str());
        // Add additional code here to handle the WebSocket being closed.
    }
```

### <a name="handle-the-streamwebsocketclosed-event"></a><span data-ttu-id="be2c9-160">StreamWebSocket.Closed イベントの処理</span><span class="sxs-lookup"><span data-stu-id="be2c9-160">Handle the StreamWebSocket.Closed event</span></span>
<span data-ttu-id="be2c9-161">**StreamWebSocket** を使って接続を確立してデータを送信する前に、[**StreamWebSocket.Closed**](/uwp/api/windows.networking.sockets.streamwebsocket.Closed) イベントにサブスクライブしてください。</span><span class="sxs-lookup"><span data-stu-id="be2c9-161">Before establishing a connection and sending data with a **StreamWebSocket**, you should subscribe to the [**StreamWebSocket.Closed**](/uwp/api/windows.networking.sockets.streamwebsocket.Closed) event.</span></span> <span data-ttu-id="be2c9-162">クライアントまたはサーバーがソケットを閉じると **Closed** が発生します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-162">**Closed** is raised when the client or the server closes the socket.</span></span>
 
### <a name="send-data-on-a-streamwebsocket"></a><span data-ttu-id="be2c9-163">StreamWebSocket でのデータの送信</span><span class="sxs-lookup"><span data-stu-id="be2c9-163">Send data on a StreamWebSocket</span></span>
<span data-ttu-id="be2c9-164">接続が確立されたら、サーバーにデータを送信できます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-164">Once a connection is established, you can send data to the server.</span></span> <span data-ttu-id="be2c9-165">これを行うには、[**StreamWebSocket.OutputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.OutputStream) プロパティと [**DataWriter**](/uwp/api/windows.storage.streams.datawriter) を使って、データを書き込みます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-165">You do this by using the [**StreamWebSocket.OutputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.OutputStream) property, and a [**DataWriter**](/uwp/api/windows.storage.streams.datawriter), to write the data.</span></span>

<span data-ttu-id="be2c9-166">**注** 同じソケットにさらにデータを書き込む場合、**DataWriter** がスコープ外になる前に、必ず [**DataWriter.DetachStream**](/uwp/api/windows.storage.streams.datawriter.DetachStream) を呼び出して **DataWriter** から出力ストリームをデタッチしてください。</span><span class="sxs-lookup"><span data-stu-id="be2c9-166">**Note** If you want to write more data on the same socket, then be sure to call [**DataWriter.DetachStream**](/uwp/api/windows.storage.streams.datawriter.DetachStream) to detach the output stream from the **DataWriter** before the **DataWriter** goes out of scope.</span></span> <span data-ttu-id="be2c9-167">これにより、ストリームの所有権が **MessageWebSocket** に返されます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-167">This returns ownership of the stream to the **MessageWebSocket**.</span></span>

### <a name="receive-data-on-a-streamwebsocket"></a><span data-ttu-id="be2c9-168">StreamWebSocket でのデータの受信</span><span class="sxs-lookup"><span data-stu-id="be2c9-168">Receive data on a StreamWebSocket</span></span>
<span data-ttu-id="be2c9-169">[**StreamWebSocket.InputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.InputStream) プロパティと [**DataReader**](/uwp/api/windows.storage.streams.datareader) を使って、データを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-169">Use the [**StreamWebSocket.InputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.InputStream) property, and a [**DataReader**](/uwp/api/windows.storage.streams.datareader), to read the data.</span></span>

## <a name="advanced-options-for-messagewebsocket-and-streamwebsocket"></a><span data-ttu-id="be2c9-170">MessageWebSocket と StreamWebSocket の高度なオプション</span><span class="sxs-lookup"><span data-stu-id="be2c9-170">Advanced options for MessageWebSocket and StreamWebSocket</span></span>
<span data-ttu-id="be2c9-171">接続を確立する前に、[**MessageWebSocketControl**](/uwp/api/windows.networking.sockets.messagewebsocketcontrol) または [**StreamWebSocketControl**](/uwp/api/windows.networking.sockets.streamwebsocketcontrol) でプロパティを設定して、ソケットで高度なオプションを設定できます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-171">Before establishing a connection, you can set advanced options on a socket by setting properties on either [**MessageWebSocketControl**](/uwp/api/windows.networking.sockets.messagewebsocketcontrol) or [**StreamWebSocketControl**](/uwp/api/windows.networking.sockets.streamwebsocketcontrol).</span></span> <span data-ttu-id="be2c9-172">必要に応じて [**MessageWebSocket.Control**](/uwp/api/windows.networking.sockets.messagewebsocket.control) プロパティまたは [**StreamWebSocket.Control**](/uwp/api/windows.networking.sockets.streamwebsocket.control) プロパティを使って、ソケット オブジェクト自体からそれらのクラスのインスタンスにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-172">You access an instance of those classes from the socket object itself either via its [**MessageWebSocket.Control**](/uwp/api/windows.networking.sockets.messagewebsocket.control) property or its [**StreamWebSocket.Control**](/uwp/api/windows.networking.sockets.streamwebsocket.control) property, as appropriate.</span></span>

<span data-ttu-id="be2c9-173">**StreamWebSocket** の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-173">Here's an example using **StreamWebSocket**.</span></span> <span data-ttu-id="be2c9-174">同じパターンが **MessageWebSocket** に適用されます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-174">The same pattern applies to **MessageWebSocket**.</span></span>

```csharp
var streamWebSocket = new Windows.Networking.Sockets.StreamWebSocket();

// By default, the Nagle algorithm is not used. This overrides that, and causes it to be used.
streamWebSocket.Control.NoDelay = false;

await streamWebSocket.ConnectAsync(new Uri("wss://echo.websocket.org"));
```

```cppwinrt
Windows::Networking::Sockets::StreamWebSocket streamWebSocket;

// By default, the Nagle algorithm is not used. This overrides that, and causes it to be used.
streamWebSocket.Control().NoDelay(false);

auto connectAsyncAction = streamWebSocket.ConnectAsync(Uri{ L"wss://echo.websocket.org" });
```

```cpp
auto streamWebSocket = ref new Windows::Networking::Sockets::StreamWebSocket();

// By default, the Nagle algorithm is not used. This overrides that, and causes it to be used.
streamWebSocket->Control->NoDelay = false;

auto connectTask = Concurrency::create_task(streamWebSocket->ConnectAsync(ref new Uri(L"wss://echo.websocket.org")));
```

<span data-ttu-id="be2c9-175">**注** **ConnectAsync** を呼び出した*後*に、コントロール プロパティを変更しようとしないでください。</span><span class="sxs-lookup"><span data-stu-id="be2c9-175">**Note** Don't try to change a control property *after* you've called **ConnectAsync**.</span></span> <span data-ttu-id="be2c9-176">ルールの唯一の例外は [MessageWebSocketControl.MessageType](/uwp/api/windows.networking.sockets.messagewebsocketcontrol.MessageType) です。</span><span class="sxs-lookup"><span data-stu-id="be2c9-176">The only exception to that rule is [MessageWebSocketControl.MessageType](/uwp/api/windows.networking.sockets.messagewebsocketcontrol.MessageType).</span></span>

## <a name="websocket-information-classes"></a><span data-ttu-id="be2c9-177">WebSocket の情報クラス</span><span class="sxs-lookup"><span data-stu-id="be2c9-177">WebSocket information classes</span></span>
<span data-ttu-id="be2c9-178">[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) と [**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) には、オブジェクトについての追加情報を提供するクラスがそれぞれあります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-178">[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) and [**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) each have a corresponding class that provides additional information about the object.</span></span>

<span data-ttu-id="be2c9-179">[**MessageWebSocketInformation**](/uwp/api/windows.networking.sockets.messagewebsocketinformation) は、**MessageWebSocket** についての情報を提供します。情報クラスのインスタンスは、[**MessageWebSocket.Information**](/uwp/api/windows.networking.sockets.messagewebsocket.Information) プロパティを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-179">[**MessageWebSocketInformation**](/uwp/api/windows.networking.sockets.messagewebsocketinformation) provides information about a **MessageWebSocket**, and you retrieve an instance of it using the [**MessageWebSocket.Information**](/uwp/api/windows.networking.sockets.messagewebsocket.Information) property.</span></span>

<span data-ttu-id="be2c9-180">[**StreamWebSocketInformation**](/uwp/api/Windows.Networking.Sockets.StreamWebSocketInformation) は、**StreamWebSocket** についての情報を提供します。情報クラスのインスタンスは、[**StreamWebSocket.Information**](/uwp/api/Windows.Networking.Sockets.StreamWebSocket.Information) プロパティを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-180">[**StreamWebSocketInformation**](/uwp/api/Windows.Networking.Sockets.StreamWebSocketInformation) provides information about a **StreamWebSocket**, and you retrieve an instance of it using the [**StreamWebSocket.Information**](/uwp/api/Windows.Networking.Sockets.StreamWebSocket.Information) property.</span></span>

<span data-ttu-id="be2c9-181">これらの情報クラスのプロパティは読み取り専用ですが、WebSocket オブジェクトの有効期間中はいつでも現在の情報を取得するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-181">Note that the properties on these information classes are read-only, but you can use them to retrieve information at any time during the lifetime of a web socket object.</span></span>

## <a name="handling-exceptions"></a><span data-ttu-id="be2c9-182">例外処理</span><span class="sxs-lookup"><span data-stu-id="be2c9-182">Handling exceptions</span></span>
<span data-ttu-id="be2c9-183">[**MessageWebSocket**](/uwp/api/Windows.Networking.Sockets.MessageWebSocket) または [**StreamWebSocket**](/uwp/api/Windows.Networking.Sockets.StreamWebSocket) 操作で発生したエラーは **HRESULT** 値として返されます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-183">An error encountered on a [**MessageWebSocket**](/uwp/api/Windows.Networking.Sockets.MessageWebSocket) or [**StreamWebSocket**](/uwp/api/Windows.Networking.Sockets.StreamWebSocket) operation is returned as an **HRESULT** value.</span></span> <span data-ttu-id="be2c9-184">その **HRESULT** 値を [**WebSocketError.GetStatus**](/uwp/api/windows.networking.sockets.websocketerror.getstatus) メソッドに渡し、[**WebErrorStatus**](/uwp/api/Windows.Web.WebErrorStatus) 列挙値に変換することができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-184">You can pass that **HRESULT** value to the [**WebSocketError.GetStatus**](/uwp/api/windows.networking.sockets.websocketerror.getstatus) method to convert it into a [**WebErrorStatus**](/uwp/api/Windows.Web.WebErrorStatus) enumeration value.</span></span>

<span data-ttu-id="be2c9-185">**WebErrorStatus** 列挙値のほとんどは、ネイティブ HTTP クライアント操作から返されるエラーに対応しています。</span><span class="sxs-lookup"><span data-stu-id="be2c9-185">Most **WebErrorStatus** enumeration values correspond to an error returned by the native HTTP client operation.</span></span> <span data-ttu-id="be2c9-186">アプリは **WebErrorStatus** 列挙値で切り替えを行い、例外の原因に応じてアプリの動作を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-186">Your app can switch on **WebErrorStatus** enumeration values to modify app behavior depending on the cause of the exception.</span></span>

<span data-ttu-id="be2c9-187">パラメーター検証エラーの場合、例外からの **HRESULT** を使ってエラーの詳細情報を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-187">For parameter validation errors, you can use the **HRESULT** from the exception to learn more detailed information about the error.</span></span> <span data-ttu-id="be2c9-188">考えられる **HRESULT** 値は、SDK インストールに含まれる `Winerror.h` に一覧表示されています (たとえば、`C:\Program Files (x86)\Windows Kits\10\Include\<VERSION>\shared` フォルダーにあります)。</span><span class="sxs-lookup"><span data-stu-id="be2c9-188">Possible **HRESULT** values are listed in `Winerror.h`, which can be found in your SDK installation (for example, in the folder `C:\Program Files (x86)\Windows Kits\10\Include\<VERSION>\shared`).</span></span> <span data-ttu-id="be2c9-189">ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E_INVALIDARG** です。</span><span class="sxs-lookup"><span data-stu-id="be2c9-189">For most parameter validation errors, the **HRESULT** returned is **E_INVALIDARG**.</span></span>

## <a name="setting-timeouts-on-websocket-operations"></a><span data-ttu-id="be2c9-190">WebSocket の操作に対してタイムアウトを設定する</span><span class="sxs-lookup"><span data-stu-id="be2c9-190">Setting timeouts on WebSocket operations</span></span>
<span data-ttu-id="be2c9-191">**MessageWebSocket** クラスと **StreamWebSocket** は、内部システム サービスを使って WebSocket クライアントに要求を送信し、サーバーからの応答を受信します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-191">**MessageWebSocket** and **StreamWebSocket** use an internal system service to send WebSocket client requests, and to receive responses from a server.</span></span> <span data-ttu-id="be2c9-192">WebSocket の接続操作で既定されているタイムアウト値は 60 秒です。</span><span class="sxs-lookup"><span data-stu-id="be2c9-192">The default timeout value used for a WebSocket connect operation is 60 seconds.</span></span> <span data-ttu-id="be2c9-193">WebSocket をサポートする HTTP サーバーが、WebSocket の接続要求に応答できない場合 (一時的にダウンするか、ネットワーク停止によってブロックされる) は、内部システム サービスは 60 秒待った後でエラーを返します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-193">If the HTTP server that supports WebSockets doesn't or can't respond to the WebSocket connection request (it's temporarily down, or blocked by a network outage), then the internal system service waits the default 60 seconds before it returns an error.</span></span> <span data-ttu-id="be2c9-194">このエラーによって、WebSocket の **ConnectAsync** メソッドに例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="be2c9-194">That error causes an exception to be thrown on the WebSocket **ConnectAsync** method.</span></span> <span data-ttu-id="be2c9-195">WebSocket 接続確立後の送受信操作では、既定のタイムアウト値は 30 秒です。</span><span class="sxs-lookup"><span data-stu-id="be2c9-195">For send and receive operations after a WebSocket connection has been established, the default timeout is 30 seconds.</span></span>

<span data-ttu-id="be2c9-196">URI 内の HTTP サーバー名に対する名前クエリで複数の IP アドレスが返されると、内部システム サービスは最大で 5 つのサイトの IP アドレスに接続を試みます (各アドレスについて既定のタイムアウト時間である 60 秒待ちます)。</span><span class="sxs-lookup"><span data-stu-id="be2c9-196">If the name query for an HTTP server name in the URI returns multiple IP addresses for the name, then the internal system service tries up to 5 IP addresses for the site (each with a default timeout of 60 seconds) before it fails.</span></span> <span data-ttu-id="be2c9-197">したがって、アプリは例外を処理する前に複数の IP アドレスへの接続を数分間待機する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-197">Consequently, your app could wait several minutes trying to connect to multiple IP addresses before it handles an exception.</span></span> <span data-ttu-id="be2c9-198">この動作は、ユーザーからはアプリが停止しているかのように見えることがあります。</span><span class="sxs-lookup"><span data-stu-id="be2c9-198">This behavior might appear to the user like the app has stopped working.</span></span> 

<span data-ttu-id="be2c9-199">アプリの応答性を高めてこれらの問題を最小限に抑えるには、接続要求に短いタイムアウトを設定します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-199">To make your app more responsive and minimize these issues, you can set a shorter timeout on connection requests.</span></span> <span data-ttu-id="be2c9-200">**MessageWebSocket** と **StreamWebSocket** の両方でタイムアウトを同じように設定します。</span><span class="sxs-lookup"><span data-stu-id="be2c9-200">You set a timeout in a similar way for both **MessageWebSocket** and **StreamWebSocket**.</span></span>

```csharp
private Windows.Networking.Sockets.MessageWebSocket messageWebSocket;

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    this.messageWebSocket = new Windows.Networking.Sockets.MessageWebSocket();

    try
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var connectTask = this.messageWebSocket.ConnectAsync(new Uri("wss://echo.websocket.org")).AsTask(cancellationTokenSource.Token);

        // Cancel connectTask after 5 seconds.
        cancellationTokenSource.CancelAfter(TimeSpan.FromMilliseconds(5000));

        connectTask.ContinueWith((antecedent) =>
        {
            if (antecedent.Status == TaskStatus.RanToCompletion)
            {
                // connectTask ran to completion, so we know that the MessageWebSocket is connected.
                // Add additional code here to use the MessageWebSocket.
            }
            else
            {
                // connectTask timed out, or faulted.
            }
        });
    }
    catch (Exception ex)
    {
        Windows.Web.WebErrorStatus webErrorStatus = Windows.Networking.Sockets.WebSocketError.GetStatus(ex.GetBaseException().HResult);
        // Add additional code here to handle exceptions.
    }
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::MessageWebSocket m_messageWebSocket;

    IAsyncAction TimeoutAsync()
    {
        // Return control to the caller, and resume again to complete the async action after the timeout period.
        // 5 seconds, in this example.
        co_await(std::chrono::seconds{ 5 });
    }

public:
    IAsyncAction OnNavigatedTo(NavigationEventArgs /* e */)
    {
        try
        {
            // Return control to the caller, and then immediately resume on a thread pool thread.
            co_await winrt::resume_background();

            auto connectAsyncAction = m_messageWebSocket.ConnectAsync(Uri{ L"wss://echo.websocket.org" });

            TimeoutAsync().Completed([connectAsyncAction](IAsyncAction const& sender, AsyncStatus const)
            {
                // TimeoutAsync completes after the timeout period. After that period, it's safe
                // to cancel the ConnectAsync action even if it has already completed.
                connectAsyncAction.Cancel();
            });

            try
            {
                // Block until the ConnectAsync action completes or is canceled.
                connectAsyncAction.get();
            }
            catch (winrt::hresult_error const& ex)
            {
                std::wstringstream wstringstream;
                wstringstream << L"ConnectAsync threw an exception: " << ex.message().c_str() << std::endl;
                ::OutputDebugString(wstringstream.str().c_str());
            }

            if (connectAsyncAction.Status() == AsyncStatus::Completed)
            {
                // connectTask ran to completion, so we know that the MessageWebSocket is connected.
                // Add additional code here to use the MessageWebSocket.
            }
            else
            {
                // connectTask did not run to completion.
            }
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus{ Windows::Networking::Sockets::WebSocketError::GetStatus(ex.to_abi()) };
            // Add additional code here to handle exceptions.
        }
    }
```

```cpp
#include <agents.h>
#include <ppltasks.h>
#include <sstream>
...
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::MessageWebSocket^ messageWebSocket;

protected:
    virtual void OnNavigatedTo(NavigationEventArgs^ e) override
    {
        this->messageWebSocket = ref new Windows::Networking::Sockets::MessageWebSocket();

        try
        {
            Concurrency::cancellation_token_source cancellationTokenSource;
            Concurrency::cancellation_token cancellationToken = cancellationTokenSource.get_token();

            auto connectTask = Concurrency::create_task(this->messageWebSocket->ConnectAsync(ref new Uri(L"wss://echo.websocket.org")), cancellationToken);

            // This continuation task returns true should connectTask run to completion.
            Concurrency::task< bool > taskRanToCompletion = connectTask.then([](void)
            {
                return true;
            });

            // This task returns false after the specified timeout. 5 seconds, in this example.
            Concurrency::task< bool > taskTimedout = Concurrency::create_task([]() -> bool
            {
                Concurrency::task_completion_event< void > taskCompletionEvent;

                // A call object that sets the task completion event.
                auto call = std::make_shared< Concurrency::call< int > >([taskCompletionEvent](int)
                {
                    taskCompletionEvent.set();
                });

                // A non-repeating timer that calls the call object when the timer fires.
                auto nonRepeatingTimer = std::make_shared< Concurrency::timer < int > >(5000, 0, call.get(), false);
                nonRepeatingTimer->start();

                // A task that completes after the completion event is set.
                Concurrency::task< void > taskWaitForCompletionEvent(taskCompletionEvent);

                return taskWaitForCompletionEvent.then([]() {return false; }).get();
            });

            (taskRanToCompletion || taskTimedout).then([this, cancellationTokenSource](bool connectTaskRanToCompletion)
            {
                if (connectTaskRanToCompletion)
                {
                    // connectTask ran to completion, so we know that the MessageWebSocket is connected.
                    // Add additional code here to use the MessageWebSocket.
                }
                else
                {
                    // taskTimedout ran to completion, so we should cancel connectTask via the cancellation_token_source.
                    cancellationTokenSource.cancel();
                }
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Web::WebErrorStatus webErrorStatus = Windows::Networking::Sockets::WebSocketError::GetStatus(ex->HResult);
            // Add additional code here to handle exceptions.
        }
    }
```

## <a name="important-apis"></a><span data-ttu-id="be2c9-201">重要な API</span><span class="sxs-lookup"><span data-stu-id="be2c9-201">Important APIs</span></span>
* [<span data-ttu-id="be2c9-202">DataReader</span><span class="sxs-lookup"><span data-stu-id="be2c9-202">DataReader</span></span>](/uwp/api/Windows.Storage.Streams.DataReader)
* [<span data-ttu-id="be2c9-203">DataWriter</span><span class="sxs-lookup"><span data-stu-id="be2c9-203">DataWriter</span></span>](/uwp/api/Windows.Storage.Streams.DataWriter)
* [<span data-ttu-id="be2c9-204">DataWriter.DetachStream</span><span class="sxs-lookup"><span data-stu-id="be2c9-204">DataWriter.DetachStream</span></span>](/uwp/api/windows.storage.streams.datawriter.DetachStream)
* [<span data-ttu-id="be2c9-205">MessageWebSocket</span><span class="sxs-lookup"><span data-stu-id="be2c9-205">MessageWebSocket</span></span>](/uwp/api/windows.networking.sockets.messagewebsocket)
* [<span data-ttu-id="be2c9-206">MessageWebSocket.Closed</span><span class="sxs-lookup"><span data-stu-id="be2c9-206">MessageWebSocket.Closed</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocket.Closed)
* [<span data-ttu-id="be2c9-207">MessageWebSocket.ConnectAsync</span><span class="sxs-lookup"><span data-stu-id="be2c9-207">MessageWebSocket.ConnectAsync</span></span>](/uwp/api/windows.networking.sockets.messagewebsocket.connectasync)
* [<span data-ttu-id="be2c9-208">MessageWebSocket.Control</span><span class="sxs-lookup"><span data-stu-id="be2c9-208">MessageWebSocket.Control</span></span>](/uwp/api/windows.networking.sockets.messagewebsocket.control)
* [<span data-ttu-id="be2c9-209">MessageWebSocket.Information</span><span class="sxs-lookup"><span data-stu-id="be2c9-209">MessageWebSocket.Information</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocket.Information)
* [<span data-ttu-id="be2c9-210">MessageWebSocket.MessageReceived</span><span class="sxs-lookup"><span data-stu-id="be2c9-210">MessageWebSocket.MessageReceived</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocket.MessageReceived)
* [<span data-ttu-id="be2c9-211">MessageWebSocket.OutputStream</span><span class="sxs-lookup"><span data-stu-id="be2c9-211">MessageWebSocket.OutputStream</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.MessageWebSocket.OutputStream)
* [<span data-ttu-id="be2c9-212">MessageWebSocketControl</span><span class="sxs-lookup"><span data-stu-id="be2c9-212">MessageWebSocketControl</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocketControl)
* [<span data-ttu-id="be2c9-213">MessageWebSocketControl.MessageType</span><span class="sxs-lookup"><span data-stu-id="be2c9-213">MessageWebSocketControl.MessageType</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocketControl.MessageType)
* [<span data-ttu-id="be2c9-214">MessageWebSocketInformation</span><span class="sxs-lookup"><span data-stu-id="be2c9-214">MessageWebSocketInformation</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocketInformation)
* [<span data-ttu-id="be2c9-215">MessageWebSocketMessageReceivedEventArgs</span><span class="sxs-lookup"><span data-stu-id="be2c9-215">MessageWebSocketMessageReceivedEventArgs</span></span>](/uwp/api/Windows.Networking.Sockets.MessageWebSocketMessageReceivedEventArgs)
* [<span data-ttu-id="be2c9-216">SocketMessageType</span><span class="sxs-lookup"><span data-stu-id="be2c9-216">SocketMessageType</span></span>](/uwp/api/windows.networking.sockets.socketmessagetype)
* [<span data-ttu-id="be2c9-217">StreamWebSocket</span><span class="sxs-lookup"><span data-stu-id="be2c9-217">StreamWebSocket</span></span>](/uwp/api/Windows.Networking.Sockets.StreamWebSocket)
* [<span data-ttu-id="be2c9-218">StreamWebSocket.Closed</span><span class="sxs-lookup"><span data-stu-id="be2c9-218">StreamWebSocket.Closed</span></span>](/uwp/api/Windows.Networking.Sockets.StreamWebSocket.Closed)
* [<span data-ttu-id="be2c9-219">StreamSocket.ConnectAsync</span><span class="sxs-lookup"><span data-stu-id="be2c9-219">StreamSocket.ConnectAsync</span></span>](/uwp/api/windows.networking.sockets.streamsocket.connectasync)
* [<span data-ttu-id="be2c9-220">StreamWebSocket.Control</span><span class="sxs-lookup"><span data-stu-id="be2c9-220">StreamWebSocket.Control</span></span>](/uwp/api/windows.networking.sockets.streamwebsocket.control)
* [<span data-ttu-id="be2c9-221">StreamWebSocket.Information</span><span class="sxs-lookup"><span data-stu-id="be2c9-221">StreamWebSocket.Information</span></span>](/uwp/api/windows.networking.sockets.streamwebsocket.Information)
* [<span data-ttu-id="be2c9-222">StreamWebSocket.InputStream</span><span class="sxs-lookup"><span data-stu-id="be2c9-222">StreamWebSocket.InputStream</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.InputStream)
* [<span data-ttu-id="be2c9-223">StreamWebSocket.OutputStream</span><span class="sxs-lookup"><span data-stu-id="be2c9-223">StreamWebSocket.OutputStream</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.OutputStream)
* [<span data-ttu-id="be2c9-224">StreamWebSocketControl</span><span class="sxs-lookup"><span data-stu-id="be2c9-224">StreamWebSocketControl</span></span>](/uwp/api/Windows.Networking.Sockets.StreamWebSocketControl)
* [<span data-ttu-id="be2c9-225">StreamWebSocketInformation</span><span class="sxs-lookup"><span data-stu-id="be2c9-225">StreamWebSocketInformation</span></span>](/uwp/api/Windows.Networking.Sockets.StreamWebSocketInformation)
* [<span data-ttu-id="be2c9-226">WebErrorStatus</span><span class="sxs-lookup"><span data-stu-id="be2c9-226">WebErrorStatus</span></span>](/uwp/api/Windows.Web.WebErrorStatus) 
* [<span data-ttu-id="be2c9-227">WebSocketError.GetStatus</span><span class="sxs-lookup"><span data-stu-id="be2c9-227">WebSocketError.GetStatus</span></span>](/uwp/api/windows.networking.sockets.websocketerror.getstatus)
* [<span data-ttu-id="be2c9-228">Windows.Networking.Sockets</span><span class="sxs-lookup"><span data-stu-id="be2c9-228">Windows.Networking.Sockets</span></span>](/uwp/api/Windows.Networking.Sockets)

## <a name="related-topics"></a><span data-ttu-id="be2c9-229">関連トピック</span><span class="sxs-lookup"><span data-stu-id="be2c9-229">Related topics</span></span>
* [<span data-ttu-id="be2c9-230">WebSocket プロトコル</span><span class="sxs-lookup"><span data-stu-id="be2c9-230">WebSocket Protocol</span></span>](http://tools.ietf.org/html/rfc6455)
* [<span data-ttu-id="be2c9-231">ソケット</span><span class="sxs-lookup"><span data-stu-id="be2c9-231">Sockets</span></span>](sockets.md)

## <a name="samples"></a><span data-ttu-id="be2c9-232">サンプル</span><span class="sxs-lookup"><span data-stu-id="be2c9-232">Samples</span></span>
* [<span data-ttu-id="be2c9-233">WebSocket のサンプル</span><span class="sxs-lookup"><span data-stu-id="be2c9-233">WebSocket sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620623)
