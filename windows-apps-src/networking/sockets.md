---
author: stevewhims
description: ソケットは、下位レベルのデータ転送テクノロジであり、多くのネットワーク プロトコルがこの上に実装されています。 UWP は、接続が長期間維持されるか、確立された接続が必要あるかどうかに関係なく、クライアント/サーバー アプリケーションまたは ピア ツー ピア アプリケーションの TCP および UDP ソケット クラスを提供します。
title: ソケット
ms.assetid: 23B10A3C-E33F-4CD6-92CB-0FFB491472D6
ms.author: stwhi
ms.date: 06/03/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9e0e73f4224b1577a5219d239f8c11bf5ecc0b73
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7279544"
---
# <a name="sockets"></a>ソケット
ソケットは、下位レベルのデータ転送テクノロジであり、多くのネットワーク プロトコルがこの上に実装されています。 UWP は、接続が長期間維持されるか、確立された接続が必要あるかどうかに関係なく、クライアント/サーバー アプリケーションまたは ピア ツー ピア アプリケーションの TCP および UDP ソケット クラスを提供します。

このトピックでは、[**Windows.Networking.Sockets**](/uwp/api/Windows.Networking.Sockets) 名前空間にあるユニバーサル Windows プラットフォーム (UWP) ソケット クラスを使う方法に焦点を当てます。 しかし、[Windows ソケット 2 (Winsock)](https://msdn.microsoft.com/library/windows/desktop/ms740673) を UWP アプリで使うこともできます。

> [!NOTE]
> [ネットワーク分離](https://msdn.microsoft.com/library/windows/apps/hh770532.aspx)の結果として、Windows では、同じコンピューターで実行される 2 つの UWP アプリ間での、ローカル ループバック アドレス (127.0.0.0) 経由であるか明示的なローカル IP アドレスの指定によるかに関係なく、ソケット接続 (Sockets または WinSock) の確立を禁止しています。 UWP アプリが別の UWP アプリとの通信に使うメカニズムについて詳しくは、「[アプリ間通信](/windows/uwp/app-to-app/index)」をご覧ください。

## <a name="build-a-basic-tcp-socket-client-and-server"></a>基本的な TCP ソケット クライアントおよびサーバーを構築する
TCP (伝送制御プロトコル) ソケットは、有効期間が長い接続用にどちらの方向にも下位レベルのネットワーク データ転送機能を提供します。 TCP ソケットは、インターネットで使われるほとんどのネットワーク プロトコルのベースとなる機能です。 基本的な TCP 操作の方法を示すため、以下のコード例では、TCP 経由でデータを送受信してエコー クライアントおよびサーバーを形成する [**StreamSocket**](/uwp/api/Windows.Networking.Sockets.StreamSocket) と [**StreamSocketListener**](/uwp/api/Windows.Networking.Sockets.StreamSocketListener) を示しています。

できる限り少ない可変要素から始めるため (さらに、今のところはネットワーク分離の問題を回避するため)、新しいプロジェクトを作成し、以下のクライアント コードとサーバー コードの両方を同じプロジェクトを配置します。

プロジェクトで[アプリの機能を宣言](../packaging/app-capability-declarations.md)する必要があります。 アプリ パッケージ マニフェストのソース ファイル (`Package.appxmanifest` ファイル) を開き、[機能] タブで **[プライベート ネットワーク (クライアントとサーバー)]** をオンにします。 `Package.appxmanifest` マークアップはこのようになります。

```xml
<Capability Name="privateNetworkClientServer" />
```

インターネット経由で接続する場合は、`privateNetworkClientServer` の代わりに `internetClientServer` を宣言できます。 **StreamSocket** と **StreamSocketListener** のどちらでも 1 つ以上のアプリ機能を宣言する必要があります。

### <a name="an-echo-client-and-server-using-tcp-sockets"></a>TCP ソケットを使ったエコー クライアントおよびサーバー
[**StreamSocketListener**](/uwp/api/Windows.Networking.Sockets.StreamSocketListener) を構築し、受信 TCP 接続のリッスンを開始します。 [**StreamSocketListener.ConnectionReceived**](/uwp/api/Windows.Networking.Sockets.StreamSocketListener.ConnectionReceived) イベントは、クライアントが **StreamSocketListener** との接続を確立するたびに発生します。

さらに、[**StreamSocket**](/uwp/api/Windows.Networking.Sockets.StreamSocket) を構築してサーバーへの接続を確立し、要求を送信して応答を受信します。

`StreamSocketAndListenerPage` という新しい **Page** を作成します。 `StreamSocketAndListenerPage.xaml` に XAML マークアップを置き、`StreamSocketAndListenerPage` クラス内に命令型コードを置きます。

```XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <StackPanel>
        <TextBlock Margin="9.6,0" Style="{StaticResource TitleTextBlockStyle}" Text="TCP socket example"/>
        <TextBlock Margin="7.2,0,0,0" Style="{StaticResource HeaderTextBlockStyle}" Text="StreamSocket &amp; StreamSocketListener"/>
    </StackPanel>

    <Grid Grid.Row="1">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <TextBlock Margin="9.6" Style="{StaticResource SubtitleTextBlockStyle}" Text="client"/>
        <ListBox x:Name="clientListBox" Grid.Row="1" Margin="9.6"/>
        <TextBlock Grid.Column="1" Margin="9.6" Style="{StaticResource SubtitleTextBlockStyle}" Text="server"/>
        <ListBox x:Name="serverListBox" Grid.Column="1" Grid.Row="1" Margin="9.6"/>
    </Grid>
</Grid>
```

```csharp
// Every protocol typically has a standard port number. For example, HTTP is typically 80, FTP is 20 and 21, etc.
// For this example, we'll choose an arbitrary port number.
static string PortNumber = "1337";

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    this.StartServer();
    this.StartClient();
}

private async void StartServer()
{
    try
    {
        var streamSocketListener = new Windows.Networking.Sockets.StreamSocketListener();

        // The ConnectionReceived event is raised when connections are received.
        streamSocketListener.ConnectionReceived += this.StreamSocketListener_ConnectionReceived;

        // Start listening for incoming TCP connections on the specified port. You can specify any port that's not currently in use.
        await streamSocketListener.BindServiceNameAsync(StreamSocketAndListenerPage.PortNumber);

        this.serverListBox.Items.Add("server is listening...");
    }
    catch (Exception ex)
    {
        Windows.Networking.Sockets.SocketErrorStatus webErrorStatus = Windows.Networking.Sockets.SocketError.GetStatus(ex.GetBaseException().HResult);
        this.serverListBox.Items.Add(webErrorStatus.ToString() != "Unknown" ? webErrorStatus.ToString() : ex.Message);
    }
}

private async void StreamSocketListener_ConnectionReceived(Windows.Networking.Sockets.StreamSocketListener sender, Windows.Networking.Sockets.StreamSocketListenerConnectionReceivedEventArgs args)
{
    string request;
    using (var streamReader = new StreamReader(args.Socket.InputStream.AsStreamForRead()))
    {
        request = await streamReader.ReadLineAsync();
    }

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.serverListBox.Items.Add(string.Format("server received the request: \"{0}\"", request)));

    // Echo the request back as the response.
    using (Stream outputStream = args.Socket.OutputStream.AsStreamForWrite())
    {
        using (var streamWriter = new StreamWriter(outputStream))
        {
            await streamWriter.WriteLineAsync(request);
            await streamWriter.FlushAsync();
        }
    }

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.serverListBox.Items.Add(string.Format("server sent back the response: \"{0}\"", request)));

    sender.Dispose();

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.serverListBox.Items.Add("server closed its socket"));
}

private async void StartClient()
{
    try
    {
        // Create the StreamSocket and establish a connection to the echo server.
        using (var streamSocket = new Windows.Networking.Sockets.StreamSocket())
        {
            // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
            var hostName = new Windows.Networking.HostName("localhost");

            this.clientListBox.Items.Add("client is trying to connect...");

            await streamSocket.ConnectAsync(hostName, StreamSocketAndListenerPage.PortNumber);

            this.clientListBox.Items.Add("client connected");

            // Send a request to the echo server.
            string request = "Hello, World!";
            using (Stream outputStream = streamSocket.OutputStream.AsStreamForWrite())
            {
                using (var streamWriter = new StreamWriter(outputStream))
                {
                    await streamWriter.WriteLineAsync(request);
                    await streamWriter.FlushAsync();
                }
            }

            this.clientListBox.Items.Add(string.Format("client sent the request: \"{0}\"", request));

            // Read data from the echo server.
            string response;
            using (Stream inputStream = streamSocket.InputStream.AsStreamForRead())
            {
                using (StreamReader streamReader = new StreamReader(inputStream))
                {
                    response = await streamReader.ReadLineAsync();
                }
            }

            this.clientListBox.Items.Add(string.Format("client received the response: \"{0}\" ", response));
        }

        this.clientListBox.Items.Add("client closed its socket");
    }
    catch (Exception ex)
    {
        Windows.Networking.Sockets.SocketErrorStatus webErrorStatus = Windows.Networking.Sockets.SocketError.GetStatus(ex.GetBaseException().HResult);
        this.clientListBox.Items.Add(webErrorStatus.ToString() != "Unknown" ? webErrorStatus.ToString() : ex.Message);
    }
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.UI.Core.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::StreamSocketListener m_streamSocketListener;
    Windows::Networking::Sockets::StreamSocket m_streamSocket;

public:
    void OnNavigatedTo(NavigationEventArgs const& /* e */)
    {
        StartServer();
        StartClient();
    }

private:
    IAsyncAction StartServer()
    {
        try
        {
            // The ConnectionReceived event is raised when connections are received.
            m_streamSocketListener.ConnectionReceived({ this, &StreamSocketAndListenerPage::OnConnectionReceived });

            // Start listening for incoming TCP connections on the specified port. You can specify any port that's not currently in use.
            // Every protocol typically has a standard port number. For example, HTTP is typically 80, FTP is 20 and 21, etc.
            // For this example, we'll choose an arbitrary port number.
            co_await m_streamSocketListener.BindServiceNameAsync(L"1337");
            serverListBox().Items().Append(winrt::box_value(L"server is listening..."));
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus{ Windows::Networking::Sockets::SocketError::GetStatus(ex.to_abi()) };
            serverListBox().Items().Append(webErrorStatus != Windows::Networking::Sockets::SocketErrorStatus::Unknown ? winrt::box_value(winrt::to_hstring((int32_t)webErrorStatus)) : winrt::box_value(winrt::to_hstring(ex.to_abi())));
        }
    }

    IAsyncAction OnConnectionReceived(Windows::Networking::Sockets::StreamSocketListener /* sender */, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs args)
    {
        try
        {
            auto socket{ args.Socket() }; // Keep the socket referenced, and alive.
            DataReader dataReader{ socket.InputStream() };

            unsigned int bytesLoaded = co_await dataReader.LoadAsync(sizeof(unsigned int));

            unsigned int stringLength = dataReader.ReadUInt32();
            bytesLoaded = co_await dataReader.LoadAsync(stringLength);
            winrt::hstring request = dataReader.ReadString(bytesLoaded);

            serverListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
            {
                std::wstringstream wstringstream;
                wstringstream << L"server received the request: \"" << request.c_str() << L"\"";
                serverListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));
            });

            // Echo the request back as the response.
            DataWriter dataWriter{ socket.OutputStream() };
            dataWriter.WriteUInt32(request.size());
            dataWriter.WriteString(request);
            co_await dataWriter.StoreAsync();
            dataWriter.DetachStream();

            serverListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
            {
                std::wstringstream wstringstream;
                wstringstream << L"server sent back the response: \"" << request.c_str() << L"\"";
                serverListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));
            });

            m_streamSocketListener = nullptr;

            serverListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
            {
                serverListBox().Items().Append(winrt::box_value(L"server closed its socket"));
            });
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus{ Windows::Networking::Sockets::SocketError::GetStatus(ex.to_abi()) };
            serverListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
            {
                serverListBox().Items().Append(webErrorStatus != Windows::Networking::Sockets::SocketErrorStatus::Unknown ? winrt::box_value(winrt::to_hstring((int32_t)webErrorStatus)) : winrt::box_value(winrt::to_hstring(ex.to_abi())));
            });
        }
    }

    IAsyncAction StartClient()
    {
        try
        {
            // Establish a connection to the echo server.

            // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
            Windows::Networking::HostName hostName{ L"localhost" };

            clientListBox().Items().Append(winrt::box_value(L"client is trying to connect..."));

            co_await m_streamSocket.ConnectAsync(hostName, L"1337");
            clientListBox().Items().Append(winrt::box_value(L"client connected"));

            // Send a request to the echo server.
            DataWriter dataWriter{ m_streamSocket.OutputStream() };
            winrt::hstring request{ L"Hello, World!" };
            dataWriter.WriteUInt32(request.size());
            dataWriter.WriteString(request);

            co_await dataWriter.StoreAsync();

            std::wstringstream wstringstream;
            wstringstream << L"client sent the request: \"" << request.c_str() << L"\"";
            clientListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));

            co_await dataWriter.FlushAsync();
            dataWriter.DetachStream();

            // Read data from the echo server.
            DataReader dataReader{ m_streamSocket.InputStream() };
            unsigned int bytesLoaded = co_await dataReader.LoadAsync(sizeof(unsigned int));
            unsigned int stringLength = dataReader.ReadUInt32();
            bytesLoaded = co_await dataReader.LoadAsync(stringLength);
            winrt::hstring response{ dataReader.ReadString(bytesLoaded) };

            wstringstream.str(L"");
            wstringstream << L"client received the response: \"" << response.c_str() << L"\"";
            clientListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));

            m_streamSocket = nullptr;

            clientListBox().Items().Append(winrt::box_value(L"client closed its socket"));
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus{ Windows::Networking::Sockets::SocketError::GetStatus(ex.to_abi()) };
            serverListBox().Items().Append(webErrorStatus != Windows::Networking::Sockets::SocketErrorStatus::Unknown ? winrt::box_value(winrt::to_hstring((int32_t)webErrorStatus)) : winrt::box_value(winrt::to_hstring(ex.to_abi())));
        }
    }
```

```cpp
#include <ppltasks.h>
#include <sstream>
...
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::StreamSocketListener^ streamSocketListener;
    Windows::Networking::Sockets::StreamSocket^ streamSocket;

protected:
    virtual void OnNavigatedTo(NavigationEventArgs^ e) override
    {
        this->StartServer();
        this->StartClient();
    }

private:
    void StartServer()
    {
        try
        {
            this->streamSocketListener = ref new Windows::Networking::Sockets::StreamSocketListener();

            // The ConnectionReceived event is raised when connections are received.
            streamSocketListener->ConnectionReceived += ref new TypedEventHandler<Windows::Networking::Sockets::StreamSocketListener^, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs^>(this, &StreamSocketAndListenerPage::StreamSocketListener_ConnectionReceived);

            // Start listening for incoming TCP connections on the specified port. You can specify any port that's not currently in use.
            // Every protocol typically has a standard port number. For example, HTTP is typically 80, FTP is 20 and 21, etc.
            // For this example, we'll choose an arbitrary port number.
            Concurrency::create_task(streamSocketListener->BindServiceNameAsync(L"1337")).then(
                [=]
            {
                this->serverListBox->Items->Append(L"server is listening...");
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus = Windows::Networking::Sockets::SocketError::GetStatus(ex->HResult);
            this->serverListBox->Items->Append(webErrorStatus.ToString() != L"Unknown" ? webErrorStatus.ToString() : ex->Message);
        }
    }

    void StreamSocketListener_ConnectionReceived(Windows::Networking::Sockets::StreamSocketListener^ sender, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs^ args)
    {
        try
        {
            auto dataReader = ref new DataReader(args->Socket->InputStream);

            Concurrency::create_task(dataReader->LoadAsync(sizeof(unsigned int))).then(
                [=](unsigned int bytesLoaded)
            {
                unsigned int stringLength = dataReader->ReadUInt32();
                Concurrency::create_task(dataReader->LoadAsync(stringLength)).then(
                    [=](unsigned int bytesLoaded)
                {
                    Platform::String^ request = dataReader->ReadString(bytesLoaded);
                    this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
                        [=]
                    {
                        std::wstringstream wstringstream;
                        wstringstream << L"server received the request: \"" << request->Data() << L"\"";
                        this->serverListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));
                    }));

                    // Echo the request back as the response.
                    auto dataWriter = ref new DataWriter(args->Socket->OutputStream);
                    dataWriter->WriteUInt32(request->Length());
                    dataWriter->WriteString(request);
                    Concurrency::create_task(dataWriter->StoreAsync()).then(
                        [=](unsigned int)
                    {
                        dataWriter->DetachStream();

                        this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
                            [=]()
                        {
                            std::wstringstream wstringstream;
                            wstringstream << L"server sent back the response: \"" << request->Data() << L"\"";
                            this->serverListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));
                        }));

                        delete this->streamSocketListener;
                        this->streamSocketListener = nullptr;

                        this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler([=]() {this->serverListBox->Items->Append(L"server closed its socket"); }));
                    });
                });
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus = Windows::Networking::Sockets::SocketError::GetStatus(ex->HResult);
            this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler([=]() {this->serverListBox->Items->Append(webErrorStatus.ToString() != L"Unknown" ? webErrorStatus.ToString() : ex->Message); }));
        }
    }

    void StartClient()
    {
        try
        {
            // Create the StreamSocket and establish a connection to the echo server.
            this->streamSocket = ref new Windows::Networking::Sockets::StreamSocket();

            // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
            auto hostName = ref new Windows::Networking::HostName(L"localhost");

            this->clientListBox->Items->Append(L"client is trying to connect...");

            Concurrency::create_task(this->streamSocket->ConnectAsync(hostName, L"1337")).then(
                [=](Concurrency::task< void >)
            {
                this->clientListBox->Items->Append(L"client connected");

                // Send a request to the echo server.
                auto dataWriter = ref new DataWriter(this->streamSocket->OutputStream);
                auto request = ref new Platform::String(L"Hello, World!");
                dataWriter->WriteUInt32(request->Length());
                dataWriter->WriteString(request);

                Concurrency::create_task(dataWriter->StoreAsync()).then(
                    [=](Concurrency::task< unsigned int >)
                {
                    std::wstringstream wstringstream;
                    wstringstream << L"client sent the request: \"" << request->Data() << L"\"";
                    this->clientListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));

                    Concurrency::create_task(dataWriter->FlushAsync()).then(
                        [=](Concurrency::task< bool >)
                    {
                        dataWriter->DetachStream();

                        // Read data from the echo server.
                        auto dataReader = ref new DataReader(this->streamSocket->InputStream);
                        Concurrency::create_task(dataReader->LoadAsync(sizeof(unsigned int))).then(
                            [=](unsigned int bytesLoaded)
                        {
                            unsigned int stringLength = dataReader->ReadUInt32();
                            Concurrency::create_task(dataReader->LoadAsync(stringLength)).then(
                                [=](unsigned int bytesLoaded)
                            {
                                Platform::String^ response = dataReader->ReadString(bytesLoaded);
                                this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
                                    [=]
                                {
                                    std::wstringstream wstringstream;
                                    wstringstream << L"client received the response: \"" << response->Data() << L"\"";
                                    this->clientListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));

                                    delete this->streamSocket;
                                    this->streamSocket = nullptr;

                                    this->clientListBox->Items->Append(L"client closed its socket");
                                }));
                            });
                        });
                    });
                });
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus = Windows::Networking::Sockets::SocketError::GetStatus(ex->HResult);
            this->serverListBox->Items->Append(webErrorStatus.ToString() != L"Unknown" ? webErrorStatus.ToString() : ex->Message);
        }
    }
```

## <a name="references-to-streamsockets-in-c-ppl-continuations-applies-to-ccx-primarily"></a>C++ PPL 継続での StreamSockets の参照 (主に C++/CX に該当)
> [!NOTE]
> C++/WinRT コルーチンを使用し、値によるパラメーターを渡す場合は、この問題は該当しません。 パラメーターの引き渡しに関する推奨事項については、「[C++/WinRT を使用した同時実行と非同期操作](/windows/uwp/cpp-and-winrt-apis/concurrency#parameter-passing)」を参照してください。

[**StreamSocket**](/uwp/api/Windows.Networking.Sockets.StreamSocket?branch=live) は、その入出力ストリームにアクティブな読み取り/書き込みがある限り存続します (たとえば、[**StreamSocketListener.ConnectionReceived**](/uwp/api/Windows.Networking.Sockets.StreamSocketListener.ConnectionReceived) イベント ハンドラー内でアクセス権を持つ [**StreamSocketListenerConnectionReceivedEventArgs.Socket**](/uwp/api/windows.networking.sockets.streamsocketlistenerconnectionreceivedeventargs.Socket) など)。 [**DataReader.LoadAsync**](/uwp/api/windows.storage.streams.datareader.loadasync) (または `ReadAsync/WriteAsync/StoreAsync`) を呼び出す場合、**LoadAsync** の **Completed** イベント ハンドラー (ある場合) が実行を完了するまでソケットへの参照を保持します (ソケットの入力ストリームを使用)。

並列パターン ライブラリ (PPL) は既定では継続タスクをインラインでスケジュールしません。 つまり、継続タスクを追加しても (`task::then()` を使用)、継続タスクが完了ハンドラーとしてインラインで実行されるとは限りません。

```cpp
void StreamSocketListener_ConnectionReceived(Windows::Networking::Sockets::StreamSocketListener^ sender, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs^ args)
{
    auto dataReader = ref new DataReader(args->Socket->InputStream);
    Concurrency::create_task(dataReader->LoadAsync(sizeof(unsigned int))).then(
        [=](unsigned int bytesLoaded)
    {
        // Work in here isn't guaranteed to execute inline as the completion handler of the LoadAsync.
    });
}
```

**StreamSocket** の観点では、完了ハンドラーは継続本文が実行される前に実行を完了します (およびソケットは破棄の対象となります)。 したがって、ソケットをその継続内で使用する場合はソケットが破棄されないようにするには、ソケットを直接参照 (ラムダ キャプチャを使用) して使うか、間接的に参照 (継続内の `args->Socket` にアクセスし続けることにより) するか、継続タスクを強制的にインラインにする必要があります。 [StreamSocket のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620609)では、最初の手法 (ラムダ キャプチャ) が実行される様子を確認できます。 上記の「[基本的な TCP ソケット クライアントおよびサーバーを構築する](#build-a-basic-tcp-socket-client-and-server)」の C++/CX コードでは、2 番目の手法を使っています。要求を応答としてエコーし、最も内側にあるいずれかの継続内から `args->Socket` にアクセスします。

3 番目の手法は、応答をエコーしない場合に適しています。 PPL が継続本文をインラインで実行すること強制するには、`task_continuation_context::use_synchronous_execution()` オプションを使います。 この方法を示すコード例を次に示します。

```cpp
void StreamSocketListener_ConnectionReceived(Windows::Networking::Sockets::StreamSocketListener^ sender, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs^ args)
{
    auto dataReader = ref new DataReader(args->Socket->InputStream);

    Concurrency::create_task(dataReader->LoadAsync(sizeof(unsigned int))).then(
        [=](unsigned int bytesLoaded)
    {
        unsigned int messageLength = dataReader->ReadUInt32();
        Concurrency::create_task(dataReader->LoadAsync(messageLength)).then(
            [=](unsigned int bytesLoaded)
        {
            Platform::String^ request = dataReader->ReadString(bytesLoaded);
            this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
                [=]
            {
                std::wstringstream wstringstream;
                wstringstream << L"server received the request: \"" << request->Data() << L"\"";
                this->serverListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));
            }));
        });
    }, Concurrency::task_continuation_context::use_synchronous_execution());
}
```

この動作は、[**Windows.Networking.Sockets**](/uwp/api/Windows.Networking.Sockets?branch=live) 名前空間内のすべてのソケットと Websocket クラスに適用されます。 ただし、クライアント側のシナリオは通常メンバー変数にソケットを格納するため、上の図に示すように、この問題は [**StreamSocketListener.ConnectionReceived**](/uwp/api/Windows.Networking.Sockets.StreamSocketListener.ConnectionReceived) シナリオに最もよく当てはまります。

## <a name="build-a-basic-udp-socket-client-and-server"></a>基本的な UDP ソケット クライアントおよびサーバーを構築する
UDP (ユーザー データグラム プロトコル) ソケットは、どちらの方向にも低レベルのネットワーク データ転送を提供する TCP ソケットに似ています。 ただし、TCP ソケットは有効期間が長い接続向けであり、UDP ソケットは確立された接続が必要ないアプリケーション向けです。 UDP ソケットはどちらのエンドポイントでも接続を保持しないため、リモート コンピューター間のネットワーク向けの高速でシンプルなソリューションです。 ただし、UDP ソケットは、ネットワーク パケットの整合性も、パケットがリモートの宛先に到達するかどうかもまったく保証しません。 したがって、アプリはそれを許容するように設計されている必要があります。 UDP ソケットを使うアプリケーションの例には、ローカル ネットワーク探索やローカル チャット クライアントなどがあります。

基本的な UDP 操作の方法を示すため、以下のコード例では、UDP 経由でデータを送受信してエコー クライアントおよびサーバーを形成するために使用される [**DatagramSocket**](/uwp/api/Windows.Networking.Sockets.DatagramSocket) クラスを示しています。 新しいプロジェクトを作成し、以下のクライアント コードとサーバー コードの両方を同じプロジェクトに配置します。 TCP ソケットの場合と同様、**[プライベート ネットワーク (クライアントとサーバー)]** アプリ機能を宣言する必要があります。

### <a name="an-echo-client-and-server-using-udp-sockets"></a>UDP ソケットを使ったエコー クライアントおよびサーバー
エコー サーバーの役割を果たす [**DatagramSocket**](/uwp/api/Windows.Networking.Sockets.DatagramSocket) を構築して特定のポート番号にバインドし、受信 UDP メッセージをリッスンしてエコーし直します。 [**DatagramSocket.MessageReceived**](/uwp/api/Windows.Networking.Sockets.DatagramSocket.MessageReceived) イベントは、メッセージがソケットで受信されたときに発生します。

エコー クライアントの役割を果たす別の **DatagramSocket** を構築して特定のポート番号にバインドし、UDP メッセージを送信して応答を受信します。

`DatagramSocketPage` という新しい **Page** を作成します。 `DatagramSocketPage.xaml` に XAML マークアップを置き、`DatagramSocketPage` クラス内に命令型コードを置きます。

```XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <StackPanel>
        <TextBlock Margin="9.6,0" Style="{StaticResource TitleTextBlockStyle}" Text="UDP socket example"/>
        <TextBlock Margin="7.2,0,0,0" Style="{StaticResource HeaderTextBlockStyle}" Text="DatagramSocket"/>
    </StackPanel>

    <Grid Grid.Row="1">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <TextBlock Margin="9.6" Style="{StaticResource SubtitleTextBlockStyle}" Text="client"/>
        <ListBox x:Name="clientListBox" Grid.Row="1" Margin="9.6"/>
        <TextBlock Grid.Column="1" Margin="9.6" Style="{StaticResource SubtitleTextBlockStyle}" Text="server"/>
        <ListBox x:Name="serverListBox" Grid.Column="1" Grid.Row="1" Margin="9.6"/>
    </Grid>
</Grid>
```

```csharp
// Every protocol typically has a standard port number. For example, HTTP is typically 80, FTP is 20 and 21, etc.
// For this example, we'll choose different arbitrary port numbers for client and server, since both will be running on the same machine.
static string ClientPortNumber = "1336";
static string ServerPortNumber = "1337";

protected override void OnNavigatedTo(NavigationEventArgs e)
{
    this.StartServer();
    this.StartClient();
}

private async void StartServer()
{
    try
    {
        var serverDatagramSocket = new Windows.Networking.Sockets.DatagramSocket();

        // The ConnectionReceived event is raised when connections are received.
        serverDatagramSocket.MessageReceived += ServerDatagramSocket_MessageReceived;

        this.serverListBox.Items.Add("server is about to bind...");

        // Start listening for incoming TCP connections on the specified port. You can specify any port that's not currently in use.
        await serverDatagramSocket.BindServiceNameAsync(DatagramSocketPage.ServerPortNumber);

        this.serverListBox.Items.Add(string.Format("server is bound to port number {0}", DatagramSocketPage.ServerPortNumber));
    }
    catch (Exception ex)
    {
        Windows.Networking.Sockets.SocketErrorStatus webErrorStatus = Windows.Networking.Sockets.SocketError.GetStatus(ex.GetBaseException().HResult);
        this.serverListBox.Items.Add(webErrorStatus.ToString() != "Unknown" ? webErrorStatus.ToString() : ex.Message);
    }
}

private async void ServerDatagramSocket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender, Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
{
    string request;
    using (DataReader dataReader = args.GetDataReader())
    {
        request = dataReader.ReadString(dataReader.UnconsumedBufferLength).Trim();
    }

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.serverListBox.Items.Add(string.Format("server received the request: \"{0}\"", request)));

    // Echo the request back as the response.
    using (Stream outputStream = (await sender.GetOutputStreamAsync(args.RemoteAddress, DatagramSocketPage.ClientPortNumber)).AsStreamForWrite())
    {
        using (var streamWriter = new StreamWriter(outputStream))
        {
            await streamWriter.WriteLineAsync(request);
            await streamWriter.FlushAsync();
        }
    }

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.serverListBox.Items.Add(string.Format("server sent back the response: \"{0}\"", request)));

    sender.Dispose();

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.serverListBox.Items.Add("server closed its socket"));
}

private async void StartClient()
{
    try
    {
        // Create the DatagramSocket and establish a connection to the echo server.
        var clientDatagramSocket = new Windows.Networking.Sockets.DatagramSocket();

        clientDatagramSocket.MessageReceived += ClientDatagramSocket_MessageReceived;

        // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
        var hostName = new Windows.Networking.HostName("localhost");

        this.clientListBox.Items.Add("client is about to bind...");

        await clientDatagramSocket.BindServiceNameAsync(DatagramSocketPage.ClientPortNumber);

        this.clientListBox.Items.Add(string.Format("client is bound to port number {0}", DatagramSocketPage.ClientPortNumber));

        // Send a request to the echo server.
        string request = "Hello, World!";
        using (var serverDatagramSocket = new Windows.Networking.Sockets.DatagramSocket())
        {
            using (Stream outputStream = (await serverDatagramSocket.GetOutputStreamAsync(hostName, DatagramSocketPage.ServerPortNumber)).AsStreamForWrite())
            {
                using (var streamWriter = new StreamWriter(outputStream))
                {
                    await streamWriter.WriteLineAsync(request);
                    await streamWriter.FlushAsync();
                }
            }
        }

        this.clientListBox.Items.Add(string.Format("client sent the request: \"{0}\"", request));
    }
    catch (Exception ex)
    {
        Windows.Networking.Sockets.SocketErrorStatus webErrorStatus = Windows.Networking.Sockets.SocketError.GetStatus(ex.GetBaseException().HResult);
        this.clientListBox.Items.Add(webErrorStatus.ToString() != "Unknown" ? webErrorStatus.ToString() : ex.Message);
    }
}

private async void ClientDatagramSocket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender, Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
{
    string response;
    using (DataReader dataReader = args.GetDataReader())
    {
        response = dataReader.ReadString(dataReader.UnconsumedBufferLength).Trim();
    }

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.clientListBox.Items.Add(string.Format("client received the response: \"{0}\"", response)));

    sender.Dispose();

    await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => this.clientListBox.Items.Add("client closed its socket"));
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.UI.Core.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::DatagramSocket m_clientDatagramSocket;
    Windows::Networking::Sockets::DatagramSocket m_serverDatagramSocket;

public:
    void OnNavigatedTo(NavigationEventArgs const& /* e */)
    {
        StartServer();
        StartClient();
    }

private:
    IAsyncAction StartServer()
    {
        try
        {
            // The ConnectionReceived event is raised when connections are received.
            m_serverDatagramSocket.MessageReceived({ this, &DatagramSocketPage::ServerDatagramSocket_MessageReceived });

            serverListBox().Items().Append(winrt::box_value(L"server is about to bind..."));

            // Start listening for incoming TCP connections on the specified port. You can specify any port that's not currently in use.
            co_await m_serverDatagramSocket.BindServiceNameAsync(L"1337");
            serverListBox().Items().Append(winrt::box_value(L"server is bound to port number 1337"));
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus{ Windows::Networking::Sockets::SocketError::GetStatus(ex.to_abi()) };
            serverListBox().Items().Append(webErrorStatus != Windows::Networking::Sockets::SocketErrorStatus::Unknown ? winrt::box_value(winrt::to_hstring((int32_t)webErrorStatus)) : winrt::box_value(winrt::to_hstring(ex.to_abi())));
        }
    }

    IAsyncAction ServerDatagramSocket_MessageReceived(Windows::Networking::Sockets::DatagramSocket sender, Windows::Networking::Sockets::DatagramSocketMessageReceivedEventArgs args)
    {
        DataReader dataReader{ args.GetDataReader() };
        winrt::hstring request{ dataReader.ReadString(dataReader.UnconsumedBufferLength()) };

        serverListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
        {
            std::wstringstream wstringstream;
            wstringstream << L"server received the request: \"" << request.c_str() << L"\"";
            serverListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));
        });

        // Echo the request back as the response.
        IOutputStream outputStream = co_await sender.GetOutputStreamAsync(args.RemoteAddress(), L"1336");
        DataWriter dataWriter{ outputStream };
        dataWriter.WriteString(request);

        co_await dataWriter.StoreAsync();
        dataWriter.DetachStream();

        serverListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
        {
            std::wstringstream wstringstream;
            wstringstream << L"server sent back the response: \"" << request.c_str() << L"\"";
            serverListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));

            m_serverDatagramSocket = nullptr;

            serverListBox().Items().Append(winrt::box_value(L"server closed its socket"));
        });
    }

    IAsyncAction StartClient()
    {
        try
        {
            m_clientDatagramSocket.MessageReceived({ this, &DatagramSocketPage::ClientDatagramSocket_MessageReceived });

            // Establish a connection to the echo server.
            // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
            Windows::Networking::HostName hostName{ L"localhost" };

            clientListBox().Items().Append(winrt::box_value(L"client is about to bind..."));

            co_await m_clientDatagramSocket.BindServiceNameAsync(L"1336");
            clientListBox().Items().Append(winrt::box_value(L"client is bound to port number 1336"));

            // Send a request to the echo server.
            Windows::Networking::Sockets::DatagramSocket serverDatagramSocket;
            IOutputStream outputStream = co_await m_serverDatagramSocket.GetOutputStreamAsync(hostName, L"1337");

            winrt::hstring request{ L"Hello, World!" };
            DataWriter dataWriter{ outputStream };
            dataWriter.WriteString(request);
            co_await dataWriter.StoreAsync();
            dataWriter.DetachStream();

            std::wstringstream wstringstream;
            wstringstream << L"client sent the request: \"" << request.c_str() << L"\"";
            clientListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));
        }
        catch (winrt::hresult_error const& ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus{ Windows::Networking::Sockets::SocketError::GetStatus(ex.to_abi()) };
            serverListBox().Items().Append(webErrorStatus != Windows::Networking::Sockets::SocketErrorStatus::Unknown ? winrt::box_value(winrt::to_hstring((int32_t)webErrorStatus)) : winrt::box_value(winrt::to_hstring(ex.to_abi())));
        }
    }

    void ClientDatagramSocket_MessageReceived(Windows::Networking::Sockets::DatagramSocket const& /* sender */, Windows::Networking::Sockets::DatagramSocketMessageReceivedEventArgs const& args)
    {
        DataReader dataReader{ args.GetDataReader() };
        winrt::hstring response{ dataReader.ReadString(dataReader.UnconsumedBufferLength()) };
        clientListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
        {
            std::wstringstream wstringstream;
            wstringstream << L"client received the response: \"" << response.c_str() << L"\"";
            clientListBox().Items().Append(winrt::box_value(wstringstream.str().c_str()));
        });

        m_clientDatagramSocket = nullptr;

        clientListBox().Dispatcher().RunAsync(CoreDispatcherPriority::Normal, [=]()
        {
            clientListBox().Items().Append(winrt::box_value(L"client closed its socket"));
        });
    }
```

```cpp
#include <ppltasks.h>
#include <sstream>
...
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::DatagramSocket^ clientDatagramSocket;
    Windows::Networking::Sockets::DatagramSocket^ serverDatagramSocket;

protected:
    virtual void OnNavigatedTo(NavigationEventArgs^ e) override
    {
        this->StartServer();
        this->StartClient();
    }

private:
    void StartServer()
    {
        try
        {
            this->serverDatagramSocket = ref new Windows::Networking::Sockets::DatagramSocket();

            // The ConnectionReceived event is raised when connections are received.
            this->serverDatagramSocket->MessageReceived += ref new TypedEventHandler<Windows::Networking::Sockets::DatagramSocket^, Windows::Networking::Sockets::DatagramSocketMessageReceivedEventArgs^>(this, &DatagramSocketPage::ServerDatagramSocket_MessageReceived);

            this->serverListBox->Items->Append(L"server is about to bind...");

            // Start listening for incoming TCP connections on the specified port. You can specify any port that's not currently in use.
            Concurrency::create_task(this->serverDatagramSocket->BindServiceNameAsync("1337")).then(
                [=]
            {
                this->serverListBox->Items->Append(L"server is bound to port number 1337");
            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus = Windows::Networking::Sockets::SocketError::GetStatus(ex->HResult);
            this->serverListBox->Items->Append(webErrorStatus.ToString() != L"Unknown" ? webErrorStatus.ToString() : ex->Message);
        }
    }

    void ServerDatagramSocket_MessageReceived(Windows::Networking::Sockets::DatagramSocket^ sender, Windows::Networking::Sockets::DatagramSocketMessageReceivedEventArgs^ args)
    {
        DataReader^ dataReader = args->GetDataReader();
        Platform::String^ request = dataReader->ReadString(dataReader->UnconsumedBufferLength);
        this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
            [=]
        {
            std::wstringstream wstringstream;
            wstringstream << L"server received the request: \"" << request->Data() << L"\"";
            this->serverListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));
        }));

        // Echo the request back as the response.
        Concurrency::create_task(sender->GetOutputStreamAsync(args->RemoteAddress, "1336")).then(
            [=](IOutputStream^ outputStream)
        {
            auto dataWriter = ref new DataWriter(outputStream);
            dataWriter->WriteString(request);
            Concurrency::create_task(dataWriter->StoreAsync()).then(
                [=](unsigned int)
            {
                dataWriter->DetachStream();

                this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
                    [=]()
                {
                    std::wstringstream wstringstream;
                    wstringstream << L"server sent back the response: \"" << request->Data() << L"\"";
                    this->serverListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));

                    delete this->serverDatagramSocket;
                    this->serverDatagramSocket = nullptr;

                    this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler([=]() {this->serverListBox->Items->Append(L"server closed its socket"); }));
                }));
            });
        });
    }

    void StartClient()
    {
        try
        {
            // Create the DatagramSocket and establish a connection to the echo server.
            this->clientDatagramSocket = ref new Windows::Networking::Sockets::DatagramSocket();

            this->clientDatagramSocket->MessageReceived += ref new TypedEventHandler<Windows::Networking::Sockets::DatagramSocket^, Windows::Networking::Sockets::DatagramSocketMessageReceivedEventArgs^>(this, &DatagramSocketPage::ClientDatagramSocket_MessageReceived);

            // The server hostname that we will be establishing a connection to. In this example, the server and client are in the same process.
            auto hostName = ref new Windows::Networking::HostName(L"localhost");

            this->clientListBox->Items->Append(L"client is about to bind...");

            Concurrency::create_task(this->clientDatagramSocket->BindServiceNameAsync("1336")).then(
                [=]
            {
                this->clientListBox->Items->Append(L"client is bound to port number 1336");
            });

            // Send a request to the echo server.
            auto serverDatagramSocket = ref new Windows::Networking::Sockets::DatagramSocket();
            Concurrency::create_task(serverDatagramSocket->GetOutputStreamAsync(hostName, "1337")).then(
                [=](IOutputStream^ outputStream)
            {
                auto request = ref new Platform::String(L"Hello, World!");
                auto dataWriter = ref new DataWriter(outputStream);
                dataWriter->WriteString(request);
                Concurrency::create_task(dataWriter->StoreAsync()).then(
                    [=](unsigned int)
                {
                    dataWriter->DetachStream();
                    std::wstringstream wstringstream;
                    wstringstream << L"client sent the request: \"" << request->Data() << L"\"";
                    this->clientListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));
                });

            });
        }
        catch (Platform::Exception^ ex)
        {
            Windows::Networking::Sockets::SocketErrorStatus webErrorStatus = Windows::Networking::Sockets::SocketError::GetStatus(ex->HResult);
            this->serverListBox->Items->Append(webErrorStatus.ToString() != L"Unknown" ? webErrorStatus.ToString() : ex->Message);
        }
    }

    void ClientDatagramSocket_MessageReceived(Windows::Networking::Sockets::DatagramSocket^ sender, Windows::Networking::Sockets::DatagramSocketMessageReceivedEventArgs^ args)
    {
        DataReader^ dataReader = args->GetDataReader();
        Platform::String^ response = dataReader->ReadString(dataReader->UnconsumedBufferLength);
        this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler(
            [=]
        {
            std::wstringstream wstringstream;
            wstringstream << L"client received the response: \"" << response->Data() << L"\"";
            this->clientListBox->Items->Append(ref new Platform::String(wstringstream.str().c_str()));
        }));

        delete this->clientDatagramSocket;
        this->clientDatagramSocket = nullptr;

        this->Dispatcher->RunAsync(CoreDispatcherPriority::Normal, ref new DispatchedHandler([=]() {this->clientListBox->Items->Append(L"client closed its socket"); }));
    }
```

## <a name="background-operations-and-the-socket-broker"></a>バックグラウンド操作とソケット ブローカー
ソケット ブローカーを使ってチャネル トリガーを制御すると、アプリがフォアグラウンドでないときもソケットで接続やデータを適切に受け取るようにすることができます。 詳しくは、「[バックグラウンドでのネットワーク通信](network-communications-in-the-background.md)」をご覧ください。

## <a name="batched-sends"></a>バッチ送信
ソケットに関連付けられているストリームを記述すると必ず、ユーザー モード (コード) からカーネル モード (ネットワーク スタックの存在する場所) への遷移が発生します。 一度に多くのバッファーを記述する場合、この遷移が繰り返されて大きいオーバーヘッドとなります。 1 つの方法として、送信をバッチ処理することにより、データの複数のバッファーを同時に送信してこのオーバーヘッドを回避できます。 これは、多くのデータをできるだけ効率的に移動させる必要がある VoIP、VPN、またはその他のタスクをアプリで実行する場合に特に便利です。

このセクションでは、[**StreamSocket**](/uwp/api/Windows.Networking.Sockets.StreamSocket) または接続された [**DatagramSocket**](/uwp/api/Windows.Networking.Sockets.DatagramSocket) で使うことができるいくつかのバッチ送信手法を示します。

基本を理解できるように、非効率的な方法で多数のバッファーを送信する方法を見てみましょう。 ここには、**StreamSocket** を使った最小限のデモがあります。

```csharp
protected override async void OnNavigatedTo(NavigationEventArgs e)
{
    var streamSocketListener = new Windows.Networking.Sockets.StreamSocketListener();
    streamSocketListener.ConnectionReceived += this.StreamSocketListener_ConnectionReceived;
    await streamSocketListener.BindServiceNameAsync("1337");

    var streamSocket = new Windows.Networking.Sockets.StreamSocket();
    await streamSocket.ConnectAsync(new Windows.Networking.HostName("localhost"), "1337");
    this.SendMultipleBuffersInefficiently(streamSocket, "Hello, World!");
    //this.BatchedSendsCSharpOnly(streamSocket, "Hello, World!");
    //this.BatchedSendsAnyUWPLanguage(streamSocket, "Hello, World!");
}

private async void StreamSocketListener_ConnectionReceived(Windows.Networking.Sockets.StreamSocketListener sender, Windows.Networking.Sockets.StreamSocketListenerConnectionReceivedEventArgs args)
{
    using (var dataReader = new DataReader(args.Socket.InputStream))
    {
        dataReader.InputStreamOptions = InputStreamOptions.Partial;
        while (true)
        {
            await dataReader.LoadAsync(256);
            if (dataReader.UnconsumedBufferLength == 0) break;
            IBuffer requestBuffer = dataReader.ReadBuffer(dataReader.UnconsumedBufferLength);
            string request = Windows.Security.Cryptography.CryptographicBuffer.ConvertBinaryToString(Windows.Security.Cryptography.BinaryStringEncoding.Utf8, requestBuffer);
            Debug.WriteLine(string.Format("server received the request: \"{0}\"", request));
        }
    }
}

// This implementation incurs kernel transition overhead for each packet written.
private async void SendMultipleBuffersInefficiently(Windows.Networking.Sockets.StreamSocket streamSocket, string message)
{
    var packetsToSend = new List<IBuffer>();
    for (int count = 0; count < 5; ++count) { packetsToSend.Add(Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(message, Windows.Security.Cryptography.BinaryStringEncoding.Utf8)); }

    foreach (IBuffer packet in packetsToSend)
    {
        await streamSocket.OutputStream.WriteAsync(packet);
    }
}
```

```cppwinrt
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Networking.Sockets.h>
#include <winrt/Windows.Security.Cryptography.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.UI.Core.h>
#include <winrt/Windows.UI.Xaml.Navigation.h>
#include <sstream>

using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::StreamSocketListener m_streamSocketListener;
    Windows::Networking::Sockets::StreamSocket m_streamSocket;

public:
    IAsyncAction OnNavigatedTo(NavigationEventArgs /* e */)
    {
        m_streamSocketListener.ConnectionReceived({ this, &BatchedSendsPage::OnConnectionReceived });
        co_await m_streamSocketListener.BindServiceNameAsync(L"1337");

        co_await m_streamSocket.ConnectAsync(Windows::Networking::HostName{ L"localhost" }, L"1337");
        SendMultipleBuffersInefficientlyAsync(L"Hello, World!");
        //BatchedSendsAnyUWPLanguageAsync(L"Hello, World!");
    }

private:
    IAsyncAction OnConnectionReceived(Windows::Networking::Sockets::StreamSocketListener const& /* sender */, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs const& args)
    {
        DataReader dataReader{ args.Socket().InputStream() };
        dataReader.InputStreamOptions(Windows::Storage::Streams::InputStreamOptions::Partial);

        while (true)
        {
            unsigned int bytesLoaded = co_await dataReader.LoadAsync(256);
            if (bytesLoaded == 0) break;
            winrt::hstring message{ dataReader.ReadString(bytesLoaded) };
            ::OutputDebugString(message.c_str());
        }
    }

    // This implementation incurs kernel transition overhead for each packet written.
    IAsyncAction SendMultipleBuffersInefficientlyAsync(winrt::hstring message)
    {
        co_await winrt::resume_background();

        std::vector< IBuffer > packetsToSend;
        for (unsigned int count = 0; count < 5; ++count)
        {
            packetsToSend.push_back(Windows::Security::Cryptography::CryptographicBuffer::ConvertStringToBinary(message, Windows::Security::Cryptography::BinaryStringEncoding::Utf8));
        }

        for (auto const& element : packetsToSend)
        {
            m_streamSocket.OutputStream().WriteAsync(element).get();
        }
    }
```

```cpp
#include <ppltasks.h>
#include <sstream>
...
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml::Navigation;
...
private:
    Windows::Networking::Sockets::StreamSocketListener^ streamSocketListener;
    Windows::Networking::Sockets::StreamSocket^ streamSocket;

protected:
    virtual void OnNavigatedTo(NavigationEventArgs^ e) override
    {
        this->streamSocketListener = ref new Windows::Networking::Sockets::StreamSocketListener();
        streamSocketListener->ConnectionReceived += ref new TypedEventHandler<Windows::Networking::Sockets::StreamSocketListener^, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs^>(this, &BatchedSendsPage::StreamSocketListener_ConnectionReceived);
        Concurrency::create_task(this->streamSocketListener->BindServiceNameAsync(L"1337")).then(
            [=]
        {
            this->streamSocket = ref new Windows::Networking::Sockets::StreamSocket();
            Concurrency::create_task(this->streamSocket->ConnectAsync(ref new Windows::Networking::HostName(L"localhost"), L"1337")).then(
                [=](Concurrency::task< void >)
            {
                this->SendMultipleBuffersInefficiently(L"Hello, World!");
                // this->BatchedSendsAnyUWPLanguage(L"Hello, World!");
            }, Concurrency::task_continuation_context::use_synchronous_execution());
        });
    }

private:
    void StreamSocketListener_ConnectionReceived(Windows::Networking::Sockets::StreamSocketListener^ sender, Windows::Networking::Sockets::StreamSocketListenerConnectionReceivedEventArgs^ args)
    {
        auto dataReader = ref new DataReader(args->Socket->InputStream);
        dataReader->InputStreamOptions = Windows::Storage::Streams::InputStreamOptions::Partial;
        this->ReceiveStringRecurse(dataReader, args->Socket);
    }

    void ReceiveStringRecurse(DataReader^ dataReader, Windows::Networking::Sockets::StreamSocket^ streamSocket)
    {
        Concurrency::create_task(dataReader->LoadAsync(256)).then(
            [this, dataReader, streamSocket](unsigned int bytesLoaded)
        {
            if (bytesLoaded == 0) return;
            Platform::String^ message = dataReader->ReadString(bytesLoaded);
            ::OutputDebugString(message->Data());
            this->ReceiveStringRecurse(dataReader, streamSocket);
        });
    }

    // This implementation incurs kernel transition overhead for each packet written.
    void SendMultipleBuffersInefficiently(Platform::String^ message)
    {
        std::vector< IBuffer^ > packetsToSend{};
        for (unsigned int count = 0; count < 5; ++count)
        {
            packetsToSend.push_back(Windows::Security::Cryptography::CryptographicBuffer::ConvertStringToBinary(message, Windows::Security::Cryptography::BinaryStringEncoding::Utf8));
        }

        for (auto element : packetsToSend)
        {
            Concurrency::create_task(this->streamSocket->OutputStream->WriteAsync(element)).wait();
        }
    }
```

効率的な手法の最初の例は、C# を使う場合にのみ当てはまります。 `SendMultipleBuffersInefficiently` または `SendMultipleBuffersInefficientlyAsync` ではなく、`BatchedSendsCSharpOnly` を呼び出すように `OnNavigatedTo` を変更します。

```csharp
// A C#-only technique for batched sends.
private async void BatchedSendsCSharpOnly(Windows.Networking.Sockets.StreamSocket streamSocket, string message)
{
    var packetsToSend = new List<IBuffer>();
    for (int count = 0; count < 5; ++count) { packetsToSend.Add(Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(message, Windows.Security.Cryptography.BinaryStringEncoding.Utf8)); }

    var pendingTasks = new System.Threading.Tasks.Task[packetsToSend.Count];

    for (int index = 0; index < packetsToSend.Count; ++index)
    {
        // track all pending writes as tasks, but don't wait on one before beginning the next.
        pendingTasks[index] = streamSocket.OutputStream.WriteAsync(packetsToSend[index]).AsTask();
        // Don't modify any buffer's contents until the pending writes are complete.
    }

    // Wait for all of the pending writes to complete.
    System.Threading.Tasks.Task.WaitAll(pendingTasks);
}
```

次の例は、C# の場合だけでなくあらゆる UWP 言語に当てはまります。 送信をまとめてバッチ処理する [**StreamSocket.OutputStream**](/uwp/api/windows.networking.sockets.streamsocket.OutputStream) と [**DatagramSocket.OutputStream**](/uwp/api/windows.networking.sockets.datagramsocket.OutputStream) での動作に依存しています。 手法では、その出力ストリームで、windows 10 の時点で、出力ストリームに対するすべての操作が完了した後にのみを返すことが保証[**FlushAsync**](/uwp/api/windows.storage.streams.ioutputstream.FlushAsync)を呼び出します。

```csharp
// An implementation of batched sends suitable for any UWP language.
private async void BatchedSendsAnyUWPLanguage(Windows.Networking.Sockets.StreamSocket streamSocket, string message)
{
    var packetsToSend = new List<IBuffer>();
    for (int count = 0; count < 5; ++count) { packetsToSend.Add(Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(message, Windows.Security.Cryptography.BinaryStringEncoding.Utf8)); }

    var pendingWrites = new IAsyncOperationWithProgress<uint, uint>[packetsToSend.Count];

    for (int index = 0; index < packetsToSend.Count; ++index)
    {
        // track all pending writes as tasks, but don't wait on one before beginning the next.
        pendingWrites[index] = streamSocket.OutputStream.WriteAsync(packetsToSend[index]);
        // Don't modify any buffer's contents until the pending writes are complete.
    }

    // Wait for all of the pending writes to complete. This step enables batched sends on the output stream.
    await streamSocket.OutputStream.FlushAsync();
}
```

```cppwinrt
// An implementation of batched sends suitable for any UWP language.
IAsyncAction BatchedSendsAnyUWPLanguageAsync(winrt::hstring message)
{
    std::vector< IBuffer > packetsToSend{};
    std::vector< IAsyncOperationWithProgress< unsigned int, unsigned int > > pendingWrites{};
    for (unsigned int count = 0; count < 5; ++count)
    {
        packetsToSend.push_back(Windows::Security::Cryptography::CryptographicBuffer::ConvertStringToBinary(message, Windows::Security::Cryptography::BinaryStringEncoding::Utf8));
    }

    for (auto const& element : packetsToSend)
    {
        // track all pending writes as tasks, but don't wait on one before beginning the next.
        pendingWrites.push_back(m_streamSocket.OutputStream().WriteAsync(element));
        // Don't modify any buffer's contents until the pending writes are complete.
    }

    // Wait for all of the pending writes to complete. This step enables batched sends on the output stream.
    co_await m_streamSocket.OutputStream().FlushAsync();
}
```

```cpp
private:
    // An implementation of batched sends suitable for any UWP language.
    void BatchedSendsAnyUWPLanguage(Platform::String^ message)
    {
        std::vector< IBuffer^ > packetsToSend{};
        std::vector< IAsyncOperationWithProgress< unsigned int, unsigned int >^ >pendingWrites{};
        for (unsigned int count = 0; count < 5; ++count)
        {
            packetsToSend.push_back(Windows::Security::Cryptography::CryptographicBuffer::ConvertStringToBinary(message, Windows::Security::Cryptography::BinaryStringEncoding::Utf8));
        }

        for (auto element : packetsToSend)
        {
            // track all pending writes as tasks, but don't wait on one before beginning the next.
            pendingWrites.push_back(this->streamSocket->OutputStream->WriteAsync(element));
            // Don't modify any buffer's contents until the pending writes are complete.
        }

        // Wait for all of the pending writes to complete. This step enables batched sends on the output stream.
        Concurrency::create_task(this->streamSocket->OutputStream->FlushAsync());
    }
```

コードでバッチ処理される送信を使うことで課せられているいくつかの重要な制限があります。

-   書き込まれる **IBuffer** インスタンスの内容は、非同期書き込みが完了するまで変更できません。
-   **FlushAsync**パターンは、**StreamSocket.OutputStream** と **DatagramSocket.OutputStream** のみで機能します。
-   **FlushAsync**パターンでは、windows 10 以降でのみ動作します。
-   状況によっては、**FlushAsync** パターンの代わりに [**Task.WaitAll**](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitall?view=netcore-2.0#System_Threading_Tasks_Task_WaitAll_System_Threading_Tasks_Task___) を使います。

## <a name="port-sharing-for-datagramsocket"></a>DatagramSocket でのポートの共有
同じアドレス/ポートにバインドされた他の Win32 または UWP マルチキャスト ソケットと共存するように [**DatagramSocket**](/uwp/api/Windows.Networking.Sockets.DatagramSocket) を構成することができます。 これを行うには、ソケットをバインドまたは接続する前に [**DatagramSocketControl.MulticastOnly**](/uwp/api/Windows.Networking.Sockets.DatagramSocketControl.MulticastOnly) を `true` に設定します。 [**DatagramSocket.Control**](/uwp/api/windows.networking.sockets.datagramsocket.Control) プロパティを通じて **DatagramSocket** オブジェクト自体から **DatagramSocketControl** のインスタンスにアクセスします。

## <a name="providing-a-client-certificate-with-the-streamsocket-class"></a>StreamSocket クラスによるクライアント証明書の提供
[**StreamSocket**](/uwp/api/Windows.Networking.Sockets.StreamSocket) は、SSL/TLS を使ったクライアント アプリの接続先サーバーの認証をサポートします。 場合によっては、クライアント アプリは、SSL/TLS クライアント証明書を使って自身をサーバーに対して認証する必要があります。 ソケットをバインドまたは接続する前に (SSL/TLS ハンドシェイクが始まる前に設定する必要があります) [**StreamSocketControl.ClientCertificate**](/uwp/api/windows.networking.sockets.streamsocketcontrol.ClientCertificate) プロパティを使ってクライアント証明書を提供できます。 [**StreamSocket.Control**](/uwp/api/windows.networking.sockets.streamsocket.Control) プロパティを通じて **StreamSocket** オブジェクト自体から **StreamSocketControl** のインスタンスにアクセスします。 サーバーがクライアント証明書を要求した場合、Windows が提供されたクライアント証明書を使って応答します。

この最小限のコード例に示すように、[**SocketProtectionLevel**](/uwp/api/windows.networking.sockets.socketprotectionlevel) を使う [**StreamSocket.ConnectAsync**](/uwp/api/windows.networking.sockets.streamsocket.connectasync) の上書きを使います。

> [!IMPORTANT]
> 次のコード例のコメントで示すとおり、コードが機能するようにプロジェクトで sharedUserCertificates アプリ機能を宣言する必要があります。

```csharp
// For this code to work, you need at least one certificate to be present in the user MY certificate store.
// Plugging a smartcard into a smartcard reader connected to your PC will achieve that.
// Also, your project needs to declare the sharedUserCertificates app capability.
var certificateQuery = new Windows.Security.Cryptography.Certificates.CertificateQuery();
certificateQuery.StoreName = "MY";
IReadOnlyList<Windows.Security.Cryptography.Certificates.Certificate> certificates = await Windows.Security.Cryptography.Certificates.CertificateStores.FindAllAsync(certificateQuery);
if (certificates.Count > 0)
{
    streamSocket.Control.ClientCertificate = certificates[0];
    await streamSocket.ConnectAsync(hostName, "1337", Windows.Networking.Sockets.SocketProtectionLevel.Tls12);
}
```

```cppwinrt
// For this code to work, you need at least one certificate to be present in the user MY certificate store.
// Plugging a smartcard into a smartcard reader connected to your PC will achieve that.
// Also, your project needs to declare the sharedUserCertificates app capability.
Windows::Security::Cryptography::Certificates::CertificateQuery certificateQuery;
certificateQuery.StoreName(L"MY");
IVectorView< Windows::Security::Cryptography::Certificates::Certificate > certificates = co_await Windows::Security::Cryptography::Certificates::CertificateStores::FindAllAsync(certificateQuery);

if (certificates.Size() > 0)
{
    m_streamSocket.Control().ClientCertificate(certificates.GetAt(0));
    co_await m_streamSocket.ConnectAsync(Windows::Networking::HostName{ L"localhost" }, L"1337", Windows::Networking::Sockets::SocketProtectionLevel::Tls12);
    ...
}
```

```cpp
// For this code to work, you need at least one certificate to be present in the user MY certificate store.
// Plugging a smartcard into a smartcard reader connected to your PC will achieve that.
// Also, your project needs to declare the sharedUserCertificates app capability.
auto certificateQuery = ref new Windows::Security::Cryptography::Certificates::CertificateQuery();
certificateQuery->StoreName = L"MY";
Concurrency::create_task(Windows::Security::Cryptography::Certificates::CertificateStores::FindAllAsync(certificateQuery)).then(
    [=](IVectorView< Windows::Security::Cryptography::Certificates::Certificate^ >^ certificates)
{
    if (certificates->Size > 0)
    {
        this->streamSocket->Control->ClientCertificate = certificates->GetAt(0);
        Concurrency::create_task(this->streamSocket->ConnectAsync(ref new Windows::Networking::HostName(L"localhost"), L"1337", Windows::Networking::Sockets::SocketProtectionLevel::Tls12)).then(
            [=]
        {
            ...
        });
    }
});
```

## <a name="handling-exceptions"></a>例外処理
[**DatagramSocket**](/uwp/api/Windows.Networking.Sockets.DatagramSocket)、[**StreamSocket**](/uwp/api/Windows.Networking.Sockets.StreamSocket)、[**StreamSocketListener**](/uwp/api/Windows.Networking.Sockets.StreamSocketListener) 操作で発生したエラーは、**HRESULT** 値として返されます。 その **HRESULT** 値を [**SocketError.GetStatus**](/uwp/api/windows.networking.sockets.socketerror.getstatus) メソッドに渡し、[**SocketErrorStatus**](/uwp/api/Windows.Networking.Sockets.SocketErrorStatus) 列挙値に変換することができます。

ほとんどの **SocketErrorStatus** 列挙値は、ネイティブ Windows ソケット操作から返されるエラーに対応しています。 アプリは **SocketErrorStatus** 列挙値をオンにし、例外の原因に応じてアプリの動作を変更することができます。

パラメーター検証エラーの場合、例外からの **HRESULT** を使ってエラーの詳細情報を確認することもできます。 考えられる **HRESULT** 値は、SDK インストールに含まれる `Winerror.h` に一覧表示されています (たとえば、`C:\Program Files (x86)\Windows Kits\10\Include\<VERSION>\shared` フォルダーにあります)。 ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E_INVALIDARG** です。

[**HostName**](/uwp/api/Windows.Networking.HostName) コンストラクターは、渡される文字列が有効なホスト名でない場合に例外をスローできます。 たとえば、ユーザーによってホスト名がアプリに入力される場合に使われる可能性が高い、許可されない文字が含まれています。 try/catch ブロック内に **HostName** を構築します。 そのようにして、例外がスローされた場合、アプリはユーザーに通知し、新しいホスト名を要求することができます。

## <a name="important-apis"></a>重要な API
* [CertificateQuery](/uwp/api/windows.security.cryptography.certificates.certificatequery)
* [CertificateStores.FindAllAsync](/uwp/api/windows.security.cryptography.certificates.certificatestores.findallasync)
* [DatagramSocket](/uwp/api/Windows.Networking.Sockets.DatagramSocket)
* [DatagramSocket.BindServiceNameAsync](/uwp/api/windows.networking.sockets.datagramsocket.bindservicenameasync)
* [DatagramSocket.Control](/uwp/api/windows.networking.sockets.datagramsocket.Control)
* [DatagramSocket.GetOutputStreamAsync](/uwp/api/windows.networking.sockets.datagramsocket.getoutputstreamasync)
* [DatagramSocket.MessageReceived](/uwp/api/Windows.Networking.Sockets.DatagramSocket.MessageReceived)
* [DatagramSocketControl.MulticastOnly](/uwp/api/Windows.Networking.Sockets.DatagramSocketControl.MulticastOnly)
* [DatagramSocketMessageReceivedEventArgs](/uwp/api/windows.networking.sockets.datagramsocketmessagereceivedeventargs)
* [DatagramSocketMessageReceivedEventArgs.GetDataReader](/uwp/api/windows.networking.sockets.datagramsocketmessagereceivedeventargs.GetDataReader)
* [DataReader.LoadAsync](/uwp/api/windows.storage.streams.datareader.loadasync)
* [IOutputStream.FlushAsync](/uwp/api/windows.storage.streams.ioutputstream.FlushAsync)
* [SocketError.GetStatus](/uwp/api/windows.networking.sockets.socketerror.getstatus)
* [SocketErrorStatus](/uwp/api/Windows.Networking.Sockets.SocketErrorStatus)
* [SocketProtectionLevel](/uwp/api/windows.networking.sockets.socketprotectionlevel)
* [StreamSocket](/uwp/api/Windows.Networking.Sockets.StreamSocket)
* [StreamSocketControl.ClientCertificate](/uwp/api/windows.networking.sockets.streamsocketcontrol.ClientCertificate)
* [StreamSocket.ConnectAsync](/uwp/api/windows.networking.sockets.streamsocket.connectasync)
* [StreamSocket.InputStream](/uwp/api/windows.networking.sockets.streamsocket.InputStream)
* [StreamSocket.OutputStream](/uwp/api/windows.networking.sockets.streamsocket.OutputStream)
* [StreamSocketListener](/uwp/api/Windows.Networking.Sockets.StreamSocketListener)
* [StreamSocketListener.BindServiceNameAsync](/uwp/api/windows.networking.sockets.streamsocketlistener.bindservicenameasync)
* [StreamSocketListener.ConnectionReceived](/uwp/api/Windows.Networking.Sockets.StreamSocketListener.ConnectionReceived)
* [StreamSocketListenerConnectionReceivedEventArgs](/uwp/api/windows.networking.sockets.streamsocketlistenerconnectionreceivedeventargs)
* [Windows.Networking.Sockets](/uwp/api/Windows.Networking.Sockets)

## <a name="related-topics"></a>関連トピック
* [アプリ間通信](/windows/uwp/app-to-app/index)
* [C++/WinRT を使用した同時実行操作と非同期操作](/windows/uwp/cpp-and-winrt-apis/concurrency)
* [ネットワーク機能を設定する方法](https://msdn.microsoft.com/library/windows/apps/hh770532.aspx)
* [Windows ソケット 2 (Winsock)](https://msdn.microsoft.com/library/windows/desktop/ms740673)

## <a name="samples"></a>サンプル
* [StreamSocket のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=620609)
