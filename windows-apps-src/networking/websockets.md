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
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5996266"
---
# <a name="websockets"></a>WebSocket
WebSocket は、クライアントとサーバー間の高速で安全な双方向通信を、HTTP(S) を使った Web 経由で実現するメカニズムを提供し、UTF-8 メッセージとバイナリ メッセージの両方をサポートします。

[WebSocket プロトコル](http://tools.ietf.org/html/rfc6455)では、データはすぐに、全二重の 1 つのソケット接続によって転送され、両方のエンドポイント間のメッセージの送受信をリアルタイムで実行できます。 WebSocket はマルチプレイヤー ゲーム (リアルタイムとターン制のどちらも)、ソーシャル ネットワークのインスタント通知、株価や天気予報のリアルタイム表示、セキュリティや高速なデータ転送を必要とするアプリなど、Microsoft Store アプリでの使用に適しています。

WebSocket 接続を確立するには、クライアントとサーバー間で専用の HTTP ベースのハンドシェークをやり取りします。 成功した場合、直前に確立された TCP 接続を使って、アプリケーション レイヤー プロトコルが HTTP から WebSocket に "アップグレード" されます。 この時点で、HTTP は完全に不要となります。WebSocket 接続が閉じるまで、データの送受信は、両方のエンドポイントから WebSocket プロトコルを使って行うことができます。

**注** クライアントとサーバーの両方が WebSocket プロトコルを使っていないと、クライアントは WebSocket を使ってデータを転送することはできません。 サーバーが WebSocket をサポートしていない場合は、別の方法でデータ転送を行う必要があります。

ユニバーサル Windows プラットフォーム (UWP) は、クライアントとサーバーの両方について、WebSocket の使用をサポートしています。 [**Windows.Networking.Sockets**](/uwp/api/windows.networking.sockets) 名前空間には、クライアントが使うことのできる 2 つの WebSocket クラスが定義されています。それらは、&mdash;[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) と [**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) です。 これら 2 つの WebSocket クラスの比較を次に示します。

| [MessageWebSocket](/uwp/api/windows.networking.sockets.messagewebsocket) | [StreamWebSocket](/uwp/api/windows.networking.sockets.streamwebsocket) |
| - | - |
| WebSocket メッセージ全体の読み取りや書き込みが 1 回の操作で行われます。 | メッセージのセクションを、何回かに分けて読み取ることができます。 |
| メッセージがあまり大きくない場合に適しています。 | かなり大きなファイル (写真やビデオなど) を転送する場合に適しています。 |
| UTF-8 とバイナリの両方のメッセージがサポートされます。 | バイナリ メッセージのみサポートされます。 |
| [UDP またはデータグラム ソケット](sockets.md#build-a-basic-udp-socket-client-and-server)に似ていますが (頻繁に送信される小さいメッセージに使用されるという意味で)、TCP の信頼性、パケット順序の保証、輻輳制御が提供されます。 | [TCP またはストリーム ソケット](sockets.md#build-a-basic-tcp-socket-client-and-server)に似ています。 |

## <a name="secure-your-connection-with-tlsssl"></a>TLS/SSL による接続の保護
ほとんどの場合、セキュリティ保護された WebSocket 接続を使って、送受信するデータを暗号化できます。 ファイアウォールやプロキシなどの多くの中継点は、暗号化されていない WebSocket 接続を拒否するため、接続の成功率も高くなります。 [WebSocket プロトコル](https://tools.ietf.org/html/rfc6455#section-3)には、以下の 2 つの URI スキームが定義されています。

| URI スキーム | 目的 |
| - | - |
| wss: | セキュリティ保護された、暗号化を必要とする接続に使われます。 |
| ws: | 暗号化されていない接続に使われます。 |

WebSocket 接続を暗号化するには、`wss:` URI スキームを使います。 次に例を示します。

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

## <a name="use-messagewebsocket-to-connect"></a>MessageWebSocket を使用した接続
[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) を使うと、WebSocket メッセージ全体の読み取りや書き込みを 1 回の操作で行うことができるようになります。 したがって、メッセージがあまり大きくない場合に適しています。 このクラスでは、UTF-8 とバイナリの両方のメッセージがサポートされます。

以下のコード例では、送信されたメッセージを送信元にエコー バックするサービス、WebSocket.org エコー サーバーを使っています。

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

### <a name="handle-the-messagewebsocketmessagereceived-and-messagewebsocketclosed-events"></a>MessageWebSocket.MessageReceived イベントと MessageWebSocket.Closed イベントの処理
上の例のように、**MessageWebSocket** を使って接続を確立してデータを送信する前に、[**MessageWebSocket.MessageReceived**](/uwp/api/windows.networking.sockets.messagewebsocket.MessageReceived) イベントと [**MessageWebSocket.Closed**](/uwp/api/windows.networking.sockets.messagewebsocket.Closed) イベントにサブスクライブする必要があります。
 
データを受信すると **MessageReceived** が発生します。 データには、[**MessageWebSocketMessageReceivedEventArgs**](/uwp/api/windows.networking.sockets.messagewebsocketmessagereceivedeventargs) 経由でアクセスできます。 クライアントまたはサーバーがソケットを閉じると **Closed** が発生します。
 
### <a name="send-data-on-a-messagewebsocket"></a>MessageWebSocket でのデータの送信
接続が確立されたら、サーバーにデータを送信できます。 これを行うには、[**MessageWebSocket.OutputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.MessageWebSocket.OutputStream) プロパティと [**DataWriter**](/uwp/api/windows.storage.streams.datawriter) を使って、データを書き込みます。 

**注:** **DataWriter** が出力ストリームの所有権を取得します。 **DataWriter** がスコープ外になると、出力ストリームがそれにアタッチされている場合は **DataWriter** は出力ストリームの割り当てを解除します。 その後、出力ストリームを使おうとすると、HRESULT 値 0x80000013 のエラーが発生します。 ただし、[**DataWriter.DetachStream**](/uwp/api/windows.storage.streams.datawriter.DetachStream) を呼び出して **DataWriter** から出力ストリームをデタッチし、ストリームの所有権を **MessageWebSocket** に返すことができます。

## <a name="use-streamwebsocket-to-connect"></a>StreamWebSocket を使用した接続
[**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) を使うと、メッセージを分割し、何回かに分けて読み取ることができます。 したがって、かなり大きなファイル (写真やビデオなど) を転送する場合に適しています。 このクラスでは、バイナリ メッセージのみサポートされます。

以下のコード例では、送信されたメッセージを送信元にエコー バックするサービス、WebSocket.org エコー サーバーを使っています。

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

### <a name="handle-the-streamwebsocketclosed-event"></a>StreamWebSocket.Closed イベントの処理
**StreamWebSocket** を使って接続を確立してデータを送信する前に、[**StreamWebSocket.Closed**](/uwp/api/windows.networking.sockets.streamwebsocket.Closed) イベントにサブスクライブしてください。 クライアントまたはサーバーがソケットを閉じると **Closed** が発生します。
 
### <a name="send-data-on-a-streamwebsocket"></a>StreamWebSocket でのデータの送信
接続が確立されたら、サーバーにデータを送信できます。 これを行うには、[**StreamWebSocket.OutputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.OutputStream) プロパティと [**DataWriter**](/uwp/api/windows.storage.streams.datawriter) を使って、データを書き込みます。

**注** 同じソケットにさらにデータを書き込む場合、**DataWriter** がスコープ外になる前に、必ず [**DataWriter.DetachStream**](/uwp/api/windows.storage.streams.datawriter.DetachStream) を呼び出して **DataWriter** から出力ストリームをデタッチしてください。 これにより、ストリームの所有権が **MessageWebSocket** に返されます。

### <a name="receive-data-on-a-streamwebsocket"></a>StreamWebSocket でのデータの受信
[**StreamWebSocket.InputStream**](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.InputStream) プロパティと [**DataReader**](/uwp/api/windows.storage.streams.datareader) を使って、データを読み取ります。

## <a name="advanced-options-for-messagewebsocket-and-streamwebsocket"></a>MessageWebSocket と StreamWebSocket の高度なオプション
接続を確立する前に、[**MessageWebSocketControl**](/uwp/api/windows.networking.sockets.messagewebsocketcontrol) または [**StreamWebSocketControl**](/uwp/api/windows.networking.sockets.streamwebsocketcontrol) でプロパティを設定して、ソケットで高度なオプションを設定できます。 必要に応じて [**MessageWebSocket.Control**](/uwp/api/windows.networking.sockets.messagewebsocket.control) プロパティまたは [**StreamWebSocket.Control**](/uwp/api/windows.networking.sockets.streamwebsocket.control) プロパティを使って、ソケット オブジェクト自体からそれらのクラスのインスタンスにアクセスできます。

**StreamWebSocket** の例を次に示します。 同じパターンが **MessageWebSocket** に適用されます。

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

**注** **ConnectAsync** を呼び出した*後*に、コントロール プロパティを変更しようとしないでください。 ルールの唯一の例外は [MessageWebSocketControl.MessageType](/uwp/api/windows.networking.sockets.messagewebsocketcontrol.MessageType) です。

## <a name="websocket-information-classes"></a>WebSocket の情報クラス
[**MessageWebSocket**](/uwp/api/windows.networking.sockets.messagewebsocket) と [**StreamWebSocket**](/uwp/api/windows.networking.sockets.streamwebsocket) には、オブジェクトについての追加情報を提供するクラスがそれぞれあります。

[**MessageWebSocketInformation**](/uwp/api/windows.networking.sockets.messagewebsocketinformation) は、**MessageWebSocket** についての情報を提供します。情報クラスのインスタンスは、[**MessageWebSocket.Information**](/uwp/api/windows.networking.sockets.messagewebsocket.Information) プロパティを使って取得します。

[**StreamWebSocketInformation**](/uwp/api/Windows.Networking.Sockets.StreamWebSocketInformation) は、**StreamWebSocket** についての情報を提供します。情報クラスのインスタンスは、[**StreamWebSocket.Information**](/uwp/api/Windows.Networking.Sockets.StreamWebSocket.Information) プロパティを使って取得します。

これらの情報クラスのプロパティは読み取り専用ですが、WebSocket オブジェクトの有効期間中はいつでも現在の情報を取得するために使うことができます。

## <a name="handling-exceptions"></a>例外処理
[**MessageWebSocket**](/uwp/api/Windows.Networking.Sockets.MessageWebSocket) または [**StreamWebSocket**](/uwp/api/Windows.Networking.Sockets.StreamWebSocket) 操作で発生したエラーは **HRESULT** 値として返されます。 その **HRESULT** 値を [**WebSocketError.GetStatus**](/uwp/api/windows.networking.sockets.websocketerror.getstatus) メソッドに渡し、[**WebErrorStatus**](/uwp/api/Windows.Web.WebErrorStatus) 列挙値に変換することができます。

**WebErrorStatus** 列挙値のほとんどは、ネイティブ HTTP クライアント操作から返されるエラーに対応しています。 アプリは **WebErrorStatus** 列挙値で切り替えを行い、例外の原因に応じてアプリの動作を変更することができます。

パラメーター検証エラーの場合、例外からの **HRESULT** を使ってエラーの詳細情報を確認することもできます。 考えられる **HRESULT** 値は、SDK インストールに含まれる `Winerror.h` に一覧表示されています (たとえば、`C:\Program Files (x86)\Windows Kits\10\Include\<VERSION>\shared` フォルダーにあります)。 ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E_INVALIDARG** です。

## <a name="setting-timeouts-on-websocket-operations"></a>WebSocket の操作に対してタイムアウトを設定する
**MessageWebSocket** クラスと **StreamWebSocket** は、内部システム サービスを使って WebSocket クライアントに要求を送信し、サーバーからの応答を受信します。 WebSocket の接続操作で既定されているタイムアウト値は 60 秒です。 WebSocket をサポートする HTTP サーバーが、WebSocket の接続要求に応答できない場合 (一時的にダウンするか、ネットワーク停止によってブロックされる) は、内部システム サービスは 60 秒待った後でエラーを返します。 このエラーによって、WebSocket の **ConnectAsync** メソッドに例外がスローされます。 WebSocket 接続確立後の送受信操作では、既定のタイムアウト値は 30 秒です。

URI 内の HTTP サーバー名に対する名前クエリで複数の IP アドレスが返されると、内部システム サービスは最大で 5 つのサイトの IP アドレスに接続を試みます (各アドレスについて既定のタイムアウト時間である 60 秒待ちます)。 したがって、アプリは例外を処理する前に複数の IP アドレスへの接続を数分間待機する可能性があります。 この動作は、ユーザーからはアプリが停止しているかのように見えることがあります。 

アプリの応答性を高めてこれらの問題を最小限に抑えるには、接続要求に短いタイムアウトを設定します。 **MessageWebSocket** と **StreamWebSocket** の両方でタイムアウトを同じように設定します。

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

## <a name="important-apis"></a>重要な API
* [DataReader](/uwp/api/Windows.Storage.Streams.DataReader)
* [DataWriter](/uwp/api/Windows.Storage.Streams.DataWriter)
* [DataWriter.DetachStream](/uwp/api/windows.storage.streams.datawriter.DetachStream)
* [MessageWebSocket](/uwp/api/windows.networking.sockets.messagewebsocket)
* [MessageWebSocket.Closed](/uwp/api/Windows.Networking.Sockets.MessageWebSocket.Closed)
* [MessageWebSocket.ConnectAsync](/uwp/api/windows.networking.sockets.messagewebsocket.connectasync)
* [MessageWebSocket.Control](/uwp/api/windows.networking.sockets.messagewebsocket.control)
* [MessageWebSocket.Information](/uwp/api/Windows.Networking.Sockets.MessageWebSocket.Information)
* [MessageWebSocket.MessageReceived](/uwp/api/Windows.Networking.Sockets.MessageWebSocket.MessageReceived)
* [MessageWebSocket.OutputStream](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.MessageWebSocket.OutputStream)
* [MessageWebSocketControl](/uwp/api/Windows.Networking.Sockets.MessageWebSocketControl)
* [MessageWebSocketControl.MessageType](/uwp/api/Windows.Networking.Sockets.MessageWebSocketControl.MessageType)
* [MessageWebSocketInformation](/uwp/api/Windows.Networking.Sockets.MessageWebSocketInformation)
* [MessageWebSocketMessageReceivedEventArgs](/uwp/api/Windows.Networking.Sockets.MessageWebSocketMessageReceivedEventArgs)
* [SocketMessageType](/uwp/api/windows.networking.sockets.socketmessagetype)
* [StreamWebSocket](/uwp/api/Windows.Networking.Sockets.StreamWebSocket)
* [StreamWebSocket.Closed](/uwp/api/Windows.Networking.Sockets.StreamWebSocket.Closed)
* [StreamSocket.ConnectAsync](/uwp/api/windows.networking.sockets.streamsocket.connectasync)
* [StreamWebSocket.Control](/uwp/api/windows.networking.sockets.streamwebsocket.control)
* [StreamWebSocket.Information](/uwp/api/windows.networking.sockets.streamwebsocket.Information)
* [StreamWebSocket.InputStream](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.InputStream)
* [StreamWebSocket.OutputStream](https://docs.microsoft.com/en-us/uwp/api/Windows.Networking.Sockets.StreamWebSocket.OutputStream)
* [StreamWebSocketControl](/uwp/api/Windows.Networking.Sockets.StreamWebSocketControl)
* [StreamWebSocketInformation](/uwp/api/Windows.Networking.Sockets.StreamWebSocketInformation)
* [WebErrorStatus](/uwp/api/Windows.Web.WebErrorStatus) 
* [WebSocketError.GetStatus](/uwp/api/windows.networking.sockets.websocketerror.getstatus)
* [Windows.Networking.Sockets](/uwp/api/Windows.Networking.Sockets)

## <a name="related-topics"></a>関連トピック
* [WebSocket プロトコル](http://tools.ietf.org/html/rfc6455)
* [ソケット](sockets.md)

## <a name="samples"></a>サンプル
* [WebSocket のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620623)
