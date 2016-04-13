---
description: WebSocket は、クライアントとサーバー間の高速で安全な双方向通信を、HTTP(S) を使った Web 経由で実現するメカニズムを提供します。
title: WebSocket
ms.assetid: EAA9CB3E-6A3A-4C13-9636-CCD3DE46E7E2
---

# WebSocket

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

**重要な API**

-   [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842)
-   [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923)

WebSocket は、クライアントとサーバー間の高速で安全な双方向通信を、HTTP(S) を使った Web 経由で実現するメカニズムを提供します。

[WebSocket プロトコル](http://tools.ietf.org/html/rfc6455)では、データはすぐに、全二重の 1 つのソケット接続によって転送され、両方のエンドポイント間のメッセージの送受信をリアルタイムで実行できます。 WebSocket は、ソーシャル ネットワークでの即時の通知と最新情報 (ゲームの結果) の表示をセキュリティで保護すると同時に高速にデータ転送する必要があるリアルタイム ゲームでの使用に適しています。 ユニバーサル Windows プラットフォーム (UWP) の開発者は、 [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) クラスと [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) クラスを使うことで Websocket プロトコルをサポートするサーバーに接続できます。

| MessageWebSocket                                                         | StreamWebSocket                                                                               |
|--------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------|
| メッセージが極端に大きくない標準的なシナリオに適しています。   | 大きなファイル (写真やビデオなど) を転送するシナリオに適しています。 |
| WebSocket メッセージ全体の受信が完了したときに受け取る通知を有効にできます。 | メッセージを分割し、何回かに分けて読み取ることができます。                             |
| UTF-8 とバイナリの両方のメッセージがサポートされます。                                 | バイナリ メッセージのみサポートされます。                                                                |
| UDP またはデータグラム ソケットに似ています。                                     | TCP またはストリーム ソケットに似ています。                                                            |

ほとんどの場合、セキュリティ保護された WebSocket 接続を使って、送受信されるデータを暗号化できます。 多くのプロキシは、暗号化されていない WebSocket 接続を拒否するため、接続の成功率も高くなります。 WebSocket プロトコルには、次の 2 つの URI スキームが定義されています。

-   ws: - 暗号化されていない接続に使われます。
-   wss: - セキュリティ保護された、暗号化を必要とする接続に使われます。

WebSocket 接続を暗号化するには、たとえば `wss://www.contoso.com/mywebservice` といった wss: URI スキームを使います。

## MessageWebSocket を使う

[
            **MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) により、分割されたメッセージを何回かに分けて読み取ることができます。 **MessageWebSocket** は、メッセージがそれほど大きくないシナリオでよく使われます。 UTF-8 とバイナリ ファイルの両方がサポートされています。

このセクションのコードは、新しい [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) を作り、WebSocket サーバーに接続して、サーバーにデータを送ります。 接続が正常に確立されると、アプリは、データが受け取られたことを示す [**MessageWebSocket.MessageReceived**](https://msdn.microsoft.com/library/windows/apps/br241358) イベントがトリガーされるのを待ちます。

この例では、送信された文字列を単純に送信元にエコー バックするサービス、WebSocket.org エコー サーバーを使っています。 この例では、"wss:" プロトコル指定子を使うことで、メッセージの送受信においてセキュリティ保護された接続を行っています。

> [!div class="tabbedCodeSnippets"]
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
>     m_messageWebSocket->MessageReceived += 
>        ref new TypedEventHandler<MessageWebSocket^, MessageWebSocketMessageReceivedEventArgs^>(this, &Game::WebSocketMessageReceived);
>     m_messageWebSocket->Closed += ref new TypedEventHandler<IWebSocket^, WebSocketClosedEventArgs^>(this, &Game::WebSocketClosed);
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

WebSocket 接続を初期化した後、コードは、データを適切に送受信するために次のアクティビティを実行する必要があります。

### MessageWebSocket.MessageReceived イベント用のコールバックを実装する

接続を確立して WebSocket でデータを送信する前に、アプリは、データが受信されたときに通知を受け取るためのイベント コールバックを登録する必要があります。 [
            **MessageWebSocket.MessageReceived**](https://msdn.microsoft.com/library/windows/apps/br241358) イベントが発生すると、登録したコールバックが呼び出され、[**MessageWebSocketMessageReceivedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br226852) からデータを受け取ります。 次の例は、送信されるメッセージが UTF-8 形式であるという前提で記述されています。

次の例に示す関数は、接続された WebSocket サーバーから文字列を受信し、その文字列をデバッガーの出力ウィンドウに表示します。

> [!div class="tabbedCodeSnippets"]
>```cpp
>void Game::WebSocketMessageReceived(MessageWebSocket^ sender, MessageWebSocketMessageReceivedEventArgs^ args)
>{
>    DataReader^ messageReader = args->GetDataReader();
>    messageReader->UnicodeEncoding = Windows::Storage::Streams::UnicodeEncoding::Utf8;
>
>    String^ readString = messageReader->ReadString(messageReader->UnconsumedBufferLength);
>    // Data has been read and is now available from the readString variable.
>    swprintf(m_debugBuffer, 511, L"WebSocket Message received: %s\n", readString->Data());
>    OutputDebugString(m_debugBuffer);
>}
>```
>```csharp
>//The MessageReceived event handler.
>private void WebSock_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
>{
>    DataReader messageReader = args.GetDataReader();
>    messageReader.UnicodeEncoding = UnicodeEncoding.Utf8;
>    string messageString = messageReader.ReadString(messageReader.UnconsumedBufferLength);
>
>    //Add code here to do something with the string that is received.
>}
>```

###  MessageWebSocket.Closed イベント用のコールバックを実装する

接続を確立して WebSocket でデータを送信する前に、アプリは、WebSocket サーバーによって WebSocket が閉じられたときに通知を受け取るためのイベント コールバックを登録する必要があります。 [
            **MessageWebSocket.Closed**](https://msdn.microsoft.com/library/windows/apps/hh701364) イベントが発生すると、登録したコールバックが呼び出され、接続が WebSocket サーバーによって閉じられたことが伝えられます。

> [!div class="tabbedCodeSnippets"]
>```cpp
>void Game::WebSocketClosed(IWebSocket^ sender, WebSocketClosedEventArgs^ args)
>{
>    // The method may be triggered remotely by the server sending unsolicited close frame or locally by Close()/delete operator.
>    // This method assumes we saved the connected WebSocket to a variable called m_messageWebSocket
>    if (m_messageWebSocket != nullptr)
>    {
>        delete m_messageWebSocket;
>        m_messageWebSocket = nullptr;
>        OutputDebugString(L"Socket was closed\n");
>    }
>    m_socketConnected = false;
> }
>```
>```csharp
>//The Closed event handler
>private void WebSock_Closed(IWebSocket sender, WebSocketClosedEventArgs args)
>{
>    //Add code here to do something when the connection is closed locally or by the server
>}
>```

###  WebSocket でメッセージを送信する

接続が確立されたら、WebSocket クライアントはサーバーにデータを送信できます。 [
            **DataWriter.StoreAsync**](https://msdn.microsoft.com/library/windows/apps/br208171) メソッドは、符号なし整数にマッピングされるパラメーターを返します。 これにより、メッセージを送信するタスクの定義方法と、接続を行うタスクの定義方法とは異なるものになります。

**注**   MessageWebSocket の OutputStream を使って新しい DataWriter オブジェクトを作成すると、OutputStream の所有権が DataWriter に移り、DataWriter がスコープを外れると Outputstream の割り当てが解除されます。 このため、その後 OutputStream を使おうとすると、HRESULT 値 0x80000013 のエラーが発生します。 次のコードでは、OutputStream の割り当てが解除されないようにするため、DataWriter の DetachStream メソッドを呼び出し、ストリームの所有権を WebSocket オブジェクトに返しています。

次の例に示す関数は、接続された WebSocket サーバーに文字列を送信し、確認メッセージをデバッガーの出力ウィンドウに表示します。

> [!div class="tabbedCodeSnippets"]
>```cpp
>void Game::SendWebSocketMessage(Windows::Networking::Sockets::MessageWebSocket^ sendingSocket, Platform::String^ message)
>{
>    if (m_socketConnected)
>    {
>        // WebSocket is connected, so send a message
>        m_messageWriter = ref new DataWriter(sendingSocket->OutputStream);
>
>        m_messageWriter->WriteString(message);
>
>        // Send the data as one complete message
>        create_task(m_messageWriter->StoreAsync()).then([this] (unsigned int)
>        {
>            // Send Completed
>            m_messageWriter->DetachStream();    // give the stream back to m_messageWebSocket
>            OutputDebugString(L"Sent websocket message\n");
>        })
>            .then([this] (task<void>> previousTask)
>        {
>            try
>            {
>                // Try getting all exceptions from the continuation chain above this point.
>                previousTask.get();
>            }
>            catch (Platform::COMException ^ex)
>            {
>                // Add code to handle the exception
>                // HandleException(exception);
>            }
>        });
>    }
>}
>```
>```csharp
>//Send a message to the server.
>private async Task WebSock_SendMessage(MessageWebSocket webSock, string message)
>{
>    DataWriter messageWriter = new DataWriter(webSock.OutputStream);
>    messageWriter.WriteString(message);
>    await messageWriter.StoreAsync();
>}
>```

## WebSocket で高度なコントロールを使用する

[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) と [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) では、高度なコントロールの使い方に関して同じモデルが採用されています。 上記の主要なクラスには、それぞれに高度なコントロールにアクセスするための関連クラスがあります。

[**MessageWebSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226843) [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) オブジェクトに関するソケット制御データを提供します。
[**StreamWebSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226924) [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) オブジェクトに関するソケット制御データを提供します。
どちらのタイプの WebSocket も、高度なコントロールを行うための基本的なモデルは同じです。 以降の説明では [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) を例として使っていますが、[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) でもプロセスは同じです。

1.  [
            **StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) オブジェクトを作成します。
2.  [
            **StreamWebSocket.Control**](https://msdn.microsoft.com/library/windows/apps/br226934) プロパティを使って、この [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) オブジェクトに関連付けられている [**StreamWebSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226924) インスタンスを取得します。
3.  [
            **StreamWebSocketControl**](https://msdn.microsoft.com/library/windows/apps/br226924) インスタンスのプロパティを取得または設定することで、特定の高度なコントロールを取得または設定します。

[
            **StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) と [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) のどちらも、高度なコントロールを設定するときには要件があります。

-   [
            **StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) における高度なコントロールでは、アプリは常に、接続操作を発行する前にプロパティを設定しておく必要があります。 この要件を満たすため、コントロール プロパティは、**StreamWebSocket** オブジェクトを作成したらすぐに設定することをお勧めします。 [
            **StreamWebSocket.ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/br226933) メソッドが呼び出された後は、コントロール プロパティを設定しないでください。
-   メッセージ型以外の [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) に関する高度なコントロールでは常に、接続操作を発行する前にプロパティを設定しておく必要があります。 **MessageWebSocket** の作成したらすぐにすべてのコントロール プロパティを設定することをお勧めします。 メッセージ型以外については、[**MessageWebSocket.ConnectAsync**](https://msdn.microsoft.com/library/windows/apps/br226859) メソッドが呼び出された後は、コントロール プロパティを変更しないでください。

## WebSocket の情報クラス

[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) と [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) には、WebSocket インスタンスについての追加情報を提供するクラスがそれぞれあります。

[**MessageWebSocketInformation**](https://msdn.microsoft.com/library/windows/apps/br226849) は、[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) についての情報を提供します。情報クラスのインスタンスは、[**MessageWebSocket.Information**](https://msdn.microsoft.com/library/windows/apps/br226861) プロパティを使って取得します。

[**StreamWebSocketInformation**](https://msdn.microsoft.com/library/windows/apps/br226929) は、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) についての情報を提供します。情報クラスのインスタンスは、[**StreamWebSocket.Information**](https://msdn.microsoft.com/library/windows/apps/br226935) プロパティを使って取得します。

どちらの情報クラスについても、すべてのプロパティは読み取り専用であり、また WebSocket オブジェクトの有効期間中はいつでも現在の情報を取得できます。

## ネットワーク例外を処理する

[
            **MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) 操作で発生したエラーは **HRESULT** 値として返されます。 ネットワーク エラーを WebSocket 操作から [**WebErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh747818) 列挙値に変換するには、[**WebSocketError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701529) メソッドを使います。 **WebErrorStatus** 列挙値のほとんどは、ネイティブ HTTP クライアント操作から返されるエラーに対応しています。 アプリは特定の **WebErrorStatus** 列挙値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更することができます。

パラメーター検証エラーの場合は、例外の **HRESULT** を使って、その例外の原因となったエラーの詳細情報を確認することもできます。 使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。 パラメーター検証エラーではほとんどの場合、返される **HRESULT** は **E\_INVALIDARG** です。

## WebSocket の操作に対してタイムアウトを設定する

MessageWebSocket クラスと StreamWebSocket クラスは、内部システム サービスを使って WebSocket クライアントに要求を送信し、サーバーからの応答を受信します。 WebSocket の接続操作で既定されているタイムアウト値は 60 秒です。 WebSocket をサポートする HTTP サーバーが、ネットワーク停止によって一時的にダウンするかブロックされているために WebSocket の接続要求に応答できない場合は、内部システム サービスは 60 秒待った後でエラーを返し、それによって WebSocket の ConnectAsync メソッドに例外がスローされます。 URI 内の HTTP サーバー名に対する名前クエリで複数の IP アドレスが返されると、内部システム サービスは最大で 5 つのサイトの IP アドレスに接続を試みますが、その場合は各アドレスについて既定のタイムアウト時間である 60 秒待ちます。 すなわち、WebSocket 接続要求を行うアプリが複数の IP アドレスに接続を試みる場合は、エラーが返されて例外がスローされまで、数分間の待機が発生する可能性があります。 この動作は、ユーザーからはまるでアプリが停止しているかのように見えることがあります。 WebSocket 接続確立後の送受信操作における既定のタイムアウト値は 30 秒です。

アプリの応答性を高め、こうした問題を最小化するためには、接続操作のタイムアウトを既定よりも短く設定します。そうすることで、待機時間を短縮することができます。

タイムアウトは StreamWebSocket と MessageWebSocket の両方で同じように設定します。 次の例は、StreamWebSocket に対するタイムアウトの設定方法を示していますが、MessageWebSocket でもプロセスはほぼ同じです。

1.  タイマーを使って指定した遅延後に完了するタスクを作成します。
2.  取り消しに対応する cancellation\_token\_source を含む WebSocket 操作のタスクを作成します。
3.  タイムアウト遅延が指定されたタスクが、WebSocket 接続操作が完了する前に完了した場合は、WebSocket 操作のタスクを取り消します。

次の例では、指定した遅延後に完了する第 1 のタスクと、指定した遅延後に取り消す第 2 のタスクを作成しています。 これらのクラスは、特定のタイムアウトを設定して接続を確立するときに、StreamWebSocket と MessageWebSocket と使うことができます。 たとえば、タスクの取り消しに対応する cancellation\_token\_source を含むタスクで StreamWebSocket.ConnectAsync メソッドを呼び出すときなどに使えます。 タイムアウトが先に完了した場合は、cancellation\_token\_source により WebSocket の接続操作のタスクが取り消されます。

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



<!--HONumber=Mar16_HO3-->


