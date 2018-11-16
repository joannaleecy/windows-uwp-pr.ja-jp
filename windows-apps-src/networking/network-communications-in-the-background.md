---
author: stevewhims
description: バックグラウンドでないときにネットワーク通信を続けるため、アプリはバックグラウンド タスクを使うことができます。ソケット ブローカーまたはコントロール チャネルがトリガーされます。
title: バックグラウンドでのネットワーク通信
ms.assetid: 537F8E16-9972-435D-85A5-56D5764D3AC2
ms.author: stwhi
ms.date: 06/14/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 34fad804bb36ad1b4ce92a56772c33318e10faa8
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6968961"
---
# <a name="network-communications-in-the-background"></a><span data-ttu-id="46a3d-104">バックグラウンドでのネットワーク通信</span><span class="sxs-lookup"><span data-stu-id="46a3d-104">Network communications in the background</span></span>
<span data-ttu-id="46a3d-105">フォア グラウンドでないときにネットワーク通信を続行するには、アプリはバック グラウンド タスクとこれら 2 つのオプションのいずれかを使用できます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-105">To continue network communication while it's not in the foreground, your app can use background tasks and one of these two options.</span></span>
- <span data-ttu-id="46a3d-106">ソケット ブローカーします。</span><span class="sxs-lookup"><span data-stu-id="46a3d-106">Socket broker.</span></span> <span data-ttu-id="46a3d-107">アプリ ソケットを使用して長期的な接続し、フォア グラウンドを離れたとき場合、は、ソケットの所有権をシステムのソケット ブローカーに委任ができます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-107">If your app uses sockets for long-term connections then, when it leaves the foreground, it can delegate ownership of a socket to a system socket broker.</span></span> <span data-ttu-id="46a3d-108">その後、ブローカー:; ソケットでトラフィックが到着したときにアプリをアクティブ化所有権をアプリに転送します。アプリがし、着信トラフィックを処理します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-108">The broker then: activates your app when traffic arrives on the socket; transfers ownership back to your app; and your app then processes the arriving traffic.</span></span>
- <span data-ttu-id="46a3d-109">コントロール チャネル トリガーされます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-109">Control channel triggers.</span></span> 

## <a name="performing-network-operations-in-background-tasks"></a><span data-ttu-id="46a3d-110">バックグラウンド タスクでのネットワーク操作の実行</span><span class="sxs-lookup"><span data-stu-id="46a3d-110">Performing network operations in background tasks</span></span>
- <span data-ttu-id="46a3d-111">パケットを受信し、有効期間が短いタスクを実行する必要がある場合は、[SocketActivityTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.socketactivitytrigger) を使用して、バックグラウンド タスクをアクティブにします。</span><span class="sxs-lookup"><span data-stu-id="46a3d-111">Use a [SocketActivityTrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.socketactivitytrigger) to activate the background task when a packet is received and you need to perform a short-lived task.</span></span> <span data-ttu-id="46a3d-112">タスクを実行するには、バック グラウンド タスクが電力を節約するために終了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-112">After performing the task, the background task should terminate in order to save power.</span></span>
- <span data-ttu-id="46a3d-113">パケットを受信し、有効期間が長いタスクを実行する必要がある場合は、[ControlChannelTrigger](https://docs.microsoft.com/uwp/api/Windows.Networking.Sockets.ControlChannelTrigger) を使用して、バックグラウンド タスクをアクティブにします。</span><span class="sxs-lookup"><span data-stu-id="46a3d-113">Use a [ControlChannelTrigger](https://docs.microsoft.com/uwp/api/Windows.Networking.Sockets.ControlChannelTrigger) to activate the background task when a packet is received and you need to perform a long-lived task.</span></span>

**<span data-ttu-id="46a3d-114">ネットワーク関連の条件とフラグ</span><span class="sxs-lookup"><span data-stu-id="46a3d-114">Network-related conditions and flags</span></span>**

- <span data-ttu-id="46a3d-115">バックグラウンド タスク [BackgroundTaskBuilder.AddCondition](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskBuilder) に **InternetAvailable** 条件を追加して、ネットワーク スタックが実行されるまで、バックグラウンド タスクのトリガーを遅らせます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-115">Add the **InternetAvailable** condition to your background task [BackgroundTaskBuilder.AddCondition](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.BackgroundTaskBuilder) to delay triggering the background task until the network stack is running.</span></span> <span data-ttu-id="46a3d-116">この条件では、ネットワークが起動するまでバックグラウンド タスクが実行されないため、電力が節約されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-116">This condition saves power because the background task won't execute until the network is up.</span></span> <span data-ttu-id="46a3d-117">この条件では、リアルタイムのアクティブ化は行われません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-117">This condition does not provide real-time activation.</span></span>

<span data-ttu-id="46a3d-118">使用するトリガーに関係なく、バックグラウンド タスクで [IsNetworkRequested](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskbuilder) を設定すると、バックグラウンド タスクが実行されている間、ネットワークは稼働状態のままになります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-118">Regardless of the trigger you use, set [IsNetworkRequested](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundtaskbuilder) on your background task to ensure that the network stays up while the background task runs.</span></span> <span data-ttu-id="46a3d-119">これによって、デバイスがコネクト スタンバイ モードに入っている場合でも、タスクの実行中はネットワークを稼働状態に保つようにバックグラウンド タスク インフラストラクチャに指示されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-119">This tells the background task infrastructure to keep the network up while the task is executing, even if the device has entered Connected Standby mode.</span></span> <span data-ttu-id="46a3d-120">バック グラウンド タスクが**IsNetworkRequested**を使用していない場合、バック グラウンド タスクはコネクト スタンバイ モード (たとえば、電話の画面がになっているとき) にネットワークにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-120">If your background task does not use **IsNetworkRequested**, then your background task will not be able to access the network when in Connected Standby mode (for example, when a phone's screen is turned off).</span></span>

## <a name="socket-broker-and-the-socketactivitytrigger"></a><span data-ttu-id="46a3d-121">ソケット ブローカーと SocketActivityTrigger</span><span class="sxs-lookup"><span data-stu-id="46a3d-121">Socket broker and the SocketActivityTrigger</span></span>
<span data-ttu-id="46a3d-122">アプリが [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)、または [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) 接続を使う場合、[**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) とソケット ブローカーを使って、フォアグラウンドでないときにトラフィックがアプリに到着したという通知を受け取る必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-122">If your app uses [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319), [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882), or [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) connections, then you should use [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) and the socket broker to be notified when traffic arrives for your app while it's not in the foreground.</span></span>

<span data-ttu-id="46a3d-123">アプリがアクティブでないときにソケットでデータを受け取って処理するには、アプリは起動時に 1 回限りのセットアップをいくつか実行した後、アクティブでない状態に移行するときにソケットの所有権をソケット ブローカーに転送する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-123">In order for your app to receive and process data received on a socket when your app is not active, your app must perform some one-time setup at startup, and then transfer socket ownership to the socket broker when it is transitioning to a state where it is not active.</span></span>

<span data-ttu-id="46a3d-124">1 回限りのセットアップ手順では、次のようにトリガーを作成し、そのトリガーのバックグラウンド タスクを登録し、ソケット ブローカーのソケットを有効します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-124">The one-time setup steps are to create a trigger, to register a background task for the trigger, and to enable the socket for the socket broker:</span></span>
  - <span data-ttu-id="46a3d-125">**SocketActivityTrigger** を作成し、TaskEntryPoint パラメーターを受信パケットを処理するためのコードに設定してトリガーのバックグラウンド タスクを登録します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-125">Create a **SocketActivityTrigger** and register a background task for the trigger with the TaskEntryPoint parameter set to your code for processing a received packet.</span></span>
```csharp
            var socketTaskBuilder = new BackgroundTaskBuilder();
            socketTaskBuilder.Name = _backgroundTaskName;
            socketTaskBuilder.TaskEntryPoint = _backgroundTaskEntryPoint;
            var trigger = new SocketActivityTrigger();
            socketTaskBuilder.SetTrigger(trigger);
            _task = socketTaskBuilder.Register();
```
  - <span data-ttu-id="46a3d-126">ソケットをバインドする前に、ソケットで **EnableTransferOwnership** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-126">Call **EnableTransferOwnership** on the socket, before you bind the socket.</span></span>
```csharp
           _tcpListener = new StreamSocketListener();

           // Note that EnableTransferOwnership() should be called before bind,
           // so that tcpip keeps required state for the socket to enable connected
           // standby action. Background task Id is taken as a parameter to tie wake pattern
           // to a specific background task.  
           _tcpListener. EnableTransferOwnership(_task.TaskId,SocketActivityConnectedStandbyAction.Wake);
           _tcpListener.ConnectionReceived += OnConnectionReceived;
           await _tcpListener.BindServiceNameAsync("my-service-name");
```

<span data-ttu-id="46a3d-127">ソケットが正しくセットアップされたら、アプリが中断する直前に、ソケットで **TransferOwnership** を呼び出してソケット ブローカーに転送します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-127">Once your socket is properly set up, when your app is about to suspend, call **TransferOwnership** on the socket to transfer it to a socket broker.</span></span> <span data-ttu-id="46a3d-128">ブローカーはソケットを監視し、データが受信されたらバックグラウンド タスクをアクティブにします。</span><span class="sxs-lookup"><span data-stu-id="46a3d-128">The broker monitors the socket and activates your background task when data is received.</span></span> <span data-ttu-id="46a3d-129">次の例には、**StreamSocketListener** ソケットの転送を実行する **TransferOwnership** ユーティリティ関数が含まれています </span><span class="sxs-lookup"><span data-stu-id="46a3d-129">The following example includes a utility **TransferOwnership** function to perform the transfer for **StreamSocketListener** sockets.</span></span> <span data-ttu-id="46a3d-130">(さまざまな種類の各ソケットに独自の **TransferOwnership** メソッドがあるため、転送する所有権を持つソケットに適したメソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-130">(Note that the different types of sockets each have their own **TransferOwnership** method, so you must call the method appropriate for the socket whose ownership you are transferring.</span></span> <span data-ttu-id="46a3d-131">**OnSuspending** コードの読みやすさを維持するため、コードにはオーバーロードされた **TransferOwnership** ヘルパーを含め、使用するソケットの種類ごとに 1 つずつ実装することをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="46a3d-131">Your code would probably contain an overloaded **TransferOwnership** helper with one implementation for each socket type you use, so that the **OnSuspending** code remains easy to read.)</span></span>

<span data-ttu-id="46a3d-132">アプリは、次のうち適切なメソッドを使って、ソケットの所有権をソケット ブローカーに転送し、バックグラウンド タスクの ID を渡します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-132">An app transfers ownership of a socket to a socket broker and passes the ID for the background task using the appropriate one of the following methods:</span></span>
-   <span data-ttu-id="46a3d-133">[**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) の [**TransferOwnership**](https://msdn.microsoft.com/library/windows/apps/dn804256) メソッドのいずれか</span><span class="sxs-lookup"><span data-stu-id="46a3d-133">One of the [**TransferOwnership**](https://msdn.microsoft.com/library/windows/apps/dn804256) methods on a [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319).</span></span>
-   <span data-ttu-id="46a3d-134">[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) の [**TransferOwnership**](https://msdn.microsoft.com/library/windows/apps/dn781433) メソッドのいずれか</span><span class="sxs-lookup"><span data-stu-id="46a3d-134">One of the [**TransferOwnership**](https://msdn.microsoft.com/library/windows/apps/dn781433) methods on a [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882).</span></span>
-   <span data-ttu-id="46a3d-135">[**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) の [**TransferOwnership**](https://msdn.microsoft.com/library/windows/apps/dn804407) メソッドのいずれか</span><span class="sxs-lookup"><span data-stu-id="46a3d-135">One of the [**TransferOwnership**](https://msdn.microsoft.com/library/windows/apps/dn804407) methods on a [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906).</span></span>

```csharp

// declare int _transferOwnershipCount as a field.

private void TransferOwnership(StreamSocketListener tcpListener)
{
    await tcpListener.CancelIOAsync();

    var dataWriter = new DataWriter();
    ++_transferOwnershipCount;
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
<span data-ttu-id="46a3d-136">バックグラウンド タスクのイベント ハンドラーで、次の作業を行います。</span><span class="sxs-lookup"><span data-stu-id="46a3d-136">In your background task's event handler:</span></span>
   -  <span data-ttu-id="46a3d-137">まず、非同期メソッドを使ってイベントを処理できるように、バックグラウンド タスクの保留を取得します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-137">First, get a background task deferral so that you can handle the event using asynchronous methods.</span></span>
```csharp
var deferral = taskInstance.GetDeferral();
```
   -  <span data-ttu-id="46a3d-138">次に、イベント引数から SocketActivityTriggerDetails を抽出し、イベントが発生した理由を調べます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-138">Next, extract the SocketActivityTriggerDetails from the event arguments, and find the reason that the event was raised:</span></span>
```csharp
var details = taskInstance.TriggerDetails as SocketActivityTriggerDetails;
    var socketInformation = details.SocketInformation;
    switch (details.Reason)
```
   -   <span data-ttu-id="46a3d-139">ソケット アクティビティが原因でイベントが発生した場合、ソケットに DataReader を作成してリーダーを非同期で読み込み、アプリのデザインに従ってデータを使います。</span><span class="sxs-lookup"><span data-stu-id="46a3d-139">If the event was raised because of socket activity, create a DataReader on the socket, load the reader asynchronously, and then use the data according to your app's design.</span></span> <span data-ttu-id="46a3d-140">ソケット アクティビティの通知を再度受け取るには、ソケットの所有権をソケット ブローカーに戻す必要がある点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-140">Note that you must return ownership of the socket back to the socket broker, in order to be notified of further socket activity again.</span></span>

   <span data-ttu-id="46a3d-141">次の例では、ソケットで受け取ったテキストがトーストに表示されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-141">In the following example, the text received on the socket is displayed in a toast.</span></span>

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

   -   <span data-ttu-id="46a3d-142">キープアライブ タイマーの有効期限が切れたためにイベントが発生した場合、ソケットをライブに維持してキープアライブ タイマーを再開するには、コードがソケット経由でデータを送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-142">If the event was raised because a keep alive timer expired, then your code should send some data over the socket in order to keep the socket alive and restart the keep alive timer.</span></span> <span data-ttu-id="46a3d-143">繰り返しになりますが、イベント通知を今後も受け取るには、ソケットの所有権をソケット ブローカーに戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-143">Again, it is important to return ownership of the socket back to the socket broker in order to receive further event notifications:</span></span>

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

   -   <span data-ttu-id="46a3d-144">ソケットが閉じられたためにイベントが発生した場合、ソケットを再確立します。新しいソケットを作成した後、必ずその所有権をソケット ブローカーに転送します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-144">If the event was raised because the socket was closed, re-establish the socket, making sure that after you create the new socket, you transfer ownership of it to the socket broker.</span></span> <span data-ttu-id="46a3d-145">次のサンプルでは、新しいソケット接続の確立に使うことができるようにホスト名とポートがローカル設定に保存されています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-145">In this sample, the hostname and port are stored in local settings so that they can be used to establish a new socket connection:</span></span>

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

   -   <span data-ttu-id="46a3d-146">イベント通知の処理を完了したら、必ず保留を終了してください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-146">Don't forget to Complete your deferral, once you have finished processing the event notification:</span></span>

```csharp
  deferral.Complete();
```

<span data-ttu-id="46a3d-147">[**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) とソケット ブローカーの使い方を示す詳しいサンプルについては、[SocketActivityStreamSocket のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=620606)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-147">For a complete sample demonstrating the use of the [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) and socket broker, see the [SocketActivityStreamSocket sample](http://go.microsoft.com/fwlink/p/?LinkId=620606).</span></span> <span data-ttu-id="46a3d-148">Scenario1\_Connect.xaml.cs ではソケットの初期化が実行され、SocketActivityTask.cs ではバックグラウンド タスクが実装されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-148">The initialization of the socket is performed in Scenario1\_Connect.xaml.cs, and the background task implementation is in SocketActivityTask.cs.</span></span>

<span data-ttu-id="46a3d-149">サンプルを見ると、新しいソケットが作成されるか、既存のソケットが取得されると、すぐに **TransferOwnership** が呼び出されることがわかります。このトピックで説明したように **OnSuspending** イベント ハンドラーを使って行われるのではありません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-149">You will probably notice that the sample calls **TransferOwnership** as soon as it creates a new socket or acquires an existing socket, rather than using the **OnSuspending** even handler to do so as described in this topic.</span></span> <span data-ttu-id="46a3d-150">これは、このサンプルが [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009) の使い方を示すことに重点を置いており、実行中に他のアクティビティにソケットを使っていないためです。</span><span class="sxs-lookup"><span data-stu-id="46a3d-150">This is because the sample focuses on demonstrating the [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009), and doesn't use the socket for any other activity while it is running.</span></span> <span data-ttu-id="46a3d-151">実際のアプリはより複雑と思われるため、**OnSuspending** を使って **TransferOwnership** を呼び出すタイミングを判断してください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-151">Your app will probably be more complex, and should use **OnSuspending** to determine when to call **TransferOwnership**.</span></span>

## <a name="control-channel-triggers"></a><span data-ttu-id="46a3d-152">コントロール チャネル トリガー</span><span class="sxs-lookup"><span data-stu-id="46a3d-152">Control channel triggers</span></span>
<span data-ttu-id="46a3d-153">まず、コントロール チャネル トリガー (CCT) を適切に使っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-153">First, ensure that you're using control channel triggers (CCTs) appropriately.</span></span> <span data-ttu-id="46a3d-154">[**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)、 [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)、または[**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906)接続を使用している場合、お勧めします[**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009)を使用することです。</span><span class="sxs-lookup"><span data-stu-id="46a3d-154">If you're using [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319), [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882), or [**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) connections, then we recommend that you use [**SocketActivityTrigger**](https://msdn.microsoft.com/library/windows/apps/dn806009).</span></span> <span data-ttu-id="46a3d-155">**StreamSocket** には CCT を使うことができますが、リソースを多く使うため、コネクト スタンバイ モードでは動作しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-155">You can use CCTs for **StreamSocket**, but they use more resources and might not work in Connected Standby mode.</span></span>

<span data-ttu-id="46a3d-156">Websocket、 [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151)、 [**System.Net.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)、または[**Windows.Web.Http.HttpClient**](/uwp/api/windows.web.http.httpclient)を使用している場合は、 [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-156">If you are using WebSockets, [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151), [**System.Net.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639), or [**Windows.Web.Http.HttpClient**](/uwp/api/windows.web.http.httpclient), then you must use [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span>

## <a name="controlchanneltrigger-with-websockets"></a><span data-ttu-id="46a3d-157">ControlChannelTrigger と WebSocket</span><span class="sxs-lookup"><span data-stu-id="46a3d-157">ControlChannelTrigger with WebSockets</span></span>
<span data-ttu-id="46a3d-158">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) を使う場合は、特別な注意事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-158">Some special considerations apply when using [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span> <span data-ttu-id="46a3d-159">**ControlChannelTrigger** で **MessageWebSocket** または **StreamWebSocket** を使う際には、トランスポート固有の使用パターンとベスト プラクティスに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-159">There are some transport-specific usage patterns and best practices that should be followed when using a **MessageWebSocket** or **StreamWebSocket** with **ControlChannelTrigger**.</span></span> <span data-ttu-id="46a3d-160">また、**StreamWebSocket** でパケットを受け取る要求の処理方法にも、これらの注意事項が関係します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-160">In addition, these considerations affect the way that requests to receive packets on the **StreamWebSocket** are handled.</span></span> <span data-ttu-id="46a3d-161">**MessageWebSocket** でパケットを受け取るための要求には影響しません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-161">Requests to receive packets on the **MessageWebSocket** are not affected.</span></span>

<span data-ttu-id="46a3d-162">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) を使う際に従う必要のある使用パターンとベスト プラクティスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-162">The following usage patterns and best practices should be followed when using [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032):</span></span>

-   <span data-ttu-id="46a3d-163">未処理のソケット受信は、常にポストされ続ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-163">An outstanding socket receive must be kept posted at all times.</span></span> <span data-ttu-id="46a3d-164">これは、プッシュ通知タスクの実行を許可するために必要です。</span><span class="sxs-lookup"><span data-stu-id="46a3d-164">This is required to allow the push notification tasks to occur.</span></span>
-   <span data-ttu-id="46a3d-165">WebSocket プロトコルで、キープアライブ メッセージの標準モデルを定義します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-165">The WebSocket protocol defines a standard model for keep-alive messages.</span></span> <span data-ttu-id="46a3d-166">[**WebSocketKeepAlive**](https://msdn.microsoft.com/library/windows/apps/hh701531) クラスは、クライアント側から開始される WebSocket プロトコルのキープアライブ メッセージをサーバーに送信することができます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-166">The [**WebSocketKeepAlive**](https://msdn.microsoft.com/library/windows/apps/hh701531) class can send client-initiated WebSocket protocol keep-alive messages to the server.</span></span> <span data-ttu-id="46a3d-167">**WebSocketKeepAlive** クラスは、アプリによって KeepAliveTrigger の TaskEntryPoint として登録される必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-167">The **WebSocketKeepAlive** class should be registered as the TaskEntryPoint for a KeepAliveTrigger by the app.</span></span>

<span data-ttu-id="46a3d-168">いくつかの特別な注意事項は、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) でパケットを受け取る要求の処理方法にかかわってきます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-168">Some special considerations affect the way that requests to receive packets on the [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) are handled.</span></span> <span data-ttu-id="46a3d-169">特に、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で **StreamWebSocket** を使うアプリは、読み取り処理に、**await** モデル (C# と VB.NET) やタスク (C++) ではなく、生の非同期パターンを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-169">In particular, when using a **StreamWebSocket** with the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032), your app must use a raw async pattern for handling reads instead of the **await** model in C# and VB.NET or Tasks in C++.</span></span> <span data-ttu-id="46a3d-170">生の非同期パターンは、このセクションで後述するサンプル コードに示しています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-170">The raw async pattern is illustrated in a code sample later in this section.</span></span>

<span data-ttu-id="46a3d-171">生の非同期パターンを使うことによって、Windows は、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) のバックグラウンド タスクの [**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドを、受信完了コールバックの戻りと同期させることができます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-171">Using the raw async pattern allows Windows to synchronize the [**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method on the background task for the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) with the return of the receive completion callback.</span></span> <span data-ttu-id="46a3d-172">**Run** メソッドは、完了コールバックから制御が戻った後に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-172">The **Run** method is invoked after the completion callback returns.</span></span> <span data-ttu-id="46a3d-173">これによって、**Run** メソッドが呼び出される前に、アプリはデータ/エラーを確実に受け取ることができます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-173">This ensures that the app has received the data/errors before the **Run** method is invoked.</span></span>

<span data-ttu-id="46a3d-174">アプリは、完了コールバックから制御を戻す前に別の読み取りをポストしなければならない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-174">It is important to note that the app has to post another read before it returns control from the completion callback.</span></span> <span data-ttu-id="46a3d-175">また、[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) トランスポートで [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) を直接使うことはできません。上で説明した同期に支障をきたします。</span><span class="sxs-lookup"><span data-stu-id="46a3d-175">It is also important to note that the [**DataReader**](https://msdn.microsoft.com/library/windows/apps/br208119) cannot be directly used with the [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) transport since that breaks the synchronization described above.</span></span> <span data-ttu-id="46a3d-176">トランスポートで直接 [**DataReader.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/br208135) メソッドを使うことはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-176">It is not supported to use the [**DataReader.LoadAsync**](https://msdn.microsoft.com/library/windows/apps/br208135) method directly on top of the transport.</span></span> <span data-ttu-id="46a3d-177">別の方法として、[**StreamWebSocket.InputStream**](https://msdn.microsoft.com/library/windows/apps/br226936) プロパティの [**IInputStream.ReadAsync**](https://msdn.microsoft.com/library/windows/apps/br241719) メソッドから返された [**IBuffer**](https://msdn.microsoft.com/library/windows/apps/br241656) を後で [**DataReader.FromBuffer**](https://msdn.microsoft.com/library/windows/apps/br208133) メソッドに渡して処理することはできます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-177">Instead, the [**IBuffer**](https://msdn.microsoft.com/library/windows/apps/br241656) returned by the [**IInputStream.ReadAsync**](https://msdn.microsoft.com/library/windows/apps/br241719) method on the [**StreamWebSocket.InputStream**](https://msdn.microsoft.com/library/windows/apps/br226936) property can be later passed to [**DataReader.FromBuffer**](https://msdn.microsoft.com/library/windows/apps/br208133) method for further processing.</span></span>

<span data-ttu-id="46a3d-178">次のサンプルでは、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) の読み取りを生の非同期パターンを使って処理しています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-178">The following sample shows how to use a raw async pattern for handling reads on the [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923).</span></span>

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

<span data-ttu-id="46a3d-179">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) のバックグラウンド タスクの [**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドが呼び出される前に確実に読み取り完了ハンドラーが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-179">The read completion handler is guaranteed to fire before the [**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method on the background task for the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) is invoked.</span></span> <span data-ttu-id="46a3d-180">Windows は、読み取り完了コールバックからのアプリの復帰を待機する内部的な同期機構を備えています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-180">Windows has internal synchronization to wait for an app to return from the read completion callback.</span></span> <span data-ttu-id="46a3d-181">通常、アプリは、[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) からのデータやエラーを読み取り完了コールバックですぐに処理します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-181">The app typically quickly processes the data or the error from the [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) in the read completion callback.</span></span> <span data-ttu-id="46a3d-182">メッセージそのものは、**IBackgroundTask.Run** メソッドのコンテキスト内で処理されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-182">The message itself is processed within the context of the **IBackgroundTask.Run** method.</span></span> <span data-ttu-id="46a3d-183">以下のサンプルでは、この点をメッセージ キューを使って示しています。メッセージは、読み取り完了ハンドラーによってメッセージ キューに挿入され、バックグラウンド タスクによって後から処理されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-183">In this sample below, this point is illustrated by using a message queue that the read completion handler inserts the message into and the background task later processes.</span></span>

<span data-ttu-id="46a3d-184">次のサンプルは、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) の読み取りを処理するための生の非同期パターンで使う読み取り完了ハンドラーを示しています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-184">The following sample shows the read completion handler to use with a raw async pattern for handling reads on the [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923).</span></span>

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

<span data-ttu-id="46a3d-185">WebSocket に関連して、キープアライブ ハンドラーについても詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-185">An additional detail for Websockets is the keep-alive handler.</span></span> <span data-ttu-id="46a3d-186">WebSocket プロトコルで、キープアライブ メッセージの標準モデルを定義します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-186">The WebSocket protocol defines a standard model for keep-alive messages.</span></span>

<span data-ttu-id="46a3d-187">[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) を使う場合、アプリの中断状態を解除し、キープアライブ メッセージをサーバー (リモート エンドポイント) に定期的に送信するためには、[**WebSocketKeepAlive**](https://msdn.microsoft.com/library/windows/apps/hh701531) クラス インスタンスを KeepAliveTrigger の [**TaskEntryPoint**](https://msdn.microsoft.com/library/windows/apps/br224774) として登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-187">When using [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923), register a [**WebSocketKeepAlive**](https://msdn.microsoft.com/library/windows/apps/hh701531) class instance as the [**TaskEntryPoint**](https://msdn.microsoft.com/library/windows/apps/br224774) for a KeepAliveTrigger to allow the app to be unsuspended and send keep-alive messages to the server (remote endpoint) periodically.</span></span> <span data-ttu-id="46a3d-188">これは、アプリのバックグラウンド登録コードとパッケージ マニフェストで行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-188">This should be done as part of the background registration app code as well as in the package manifest.</span></span>

<span data-ttu-id="46a3d-189">[**Windows.Sockets.WebSocketKeepAlive**](https://msdn.microsoft.com/library/windows/apps/hh701531) のタスク エントリ ポイントは、次の 2 か所で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-189">This task entry point of [**Windows.Sockets.WebSocketKeepAlive**](https://msdn.microsoft.com/library/windows/apps/hh701531) needs to be specified in two places:</span></span>

-   <span data-ttu-id="46a3d-190">ソース コードで KeepAliveTrigger トリガーを作成する部分 (以下の例を参照)。</span><span class="sxs-lookup"><span data-stu-id="46a3d-190">When creating KeepAliveTrigger trigger in the source code (see example below).</span></span>
-   <span data-ttu-id="46a3d-191">キープアライブのバックグラウンド タスクが宣言されているアプリ パッケージ マニフェスト。</span><span class="sxs-lookup"><span data-stu-id="46a3d-191">In the app package manifest for the keepalive background task declaration.</span></span>

<span data-ttu-id="46a3d-192">次のサンプルでは、アプリ マニフェストの &lt;Application&gt; 要素の下に、ネットワーク トリガー通知とキープアライブ トリガーを追加しています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-192">The following sample adds a network trigger notification and a keepalive trigger under the &lt;Application&gt; element in an app manifest.</span></span>

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

<span data-ttu-id="46a3d-193">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) と [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923)、[**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842)、または [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) に対する非同期操作のコンテキストで **await** ステートメントを使う際には、特に注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-193">An app must be extremely careful when using an **await** statement in the context of a [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) and an asynchronous operation on a [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923), [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842), or [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882).</span></span> <span data-ttu-id="46a3d-194">Task**Task&lt;bool&gt;** オブジェクトを使うと、プッシュ通知と WebSocket キープアライブの **ControlChannelTrigger** を **StreamWebSocket** に対して登録し、このトランスポートを接続できます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-194">A **Task&lt;bool&gt;** object can be used to register a **ControlChannelTrigger** for push notification and WebSocket keep-alives on the **StreamWebSocket** and connect the transport.</span></span> <span data-ttu-id="46a3d-195">この登録の一環として、**StreamWebSocket** トランスポートが **ControlChannelTrigger** のトランスポートとして設定され、読み取りがポストされます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-195">As part of the registration, the **StreamWebSocket** transport is set as the transport for the **ControlChannelTrigger** and a read is posted.</span></span> <span data-ttu-id="46a3d-196">**Task.Result** は、タスクのすべてのステップが実行されてメッセージ本文でステートメントが返されるまで現在のスレッドをブロックします。</span><span class="sxs-lookup"><span data-stu-id="46a3d-196">The **Task.Result** will block the current thread until all steps in the task execute and return statements in message body.</span></span> <span data-ttu-id="46a3d-197">タスクは、このメソッドが true または false を返すまで解決されません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-197">The task is not resolved until the method returns either true or false.</span></span> <span data-ttu-id="46a3d-198">これにより、メソッド全体が実行されることが保証されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-198">This guarantees that the whole method is executed.</span></span> <span data-ttu-id="46a3d-199">**Task** には、**Task** によって保護される **await** ステートメントを複数含めることができます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-199">The **Task** can contain multiple **await** statements that are protected by the **Task**.</span></span> <span data-ttu-id="46a3d-200">**ControlChannelTrigger** オブジェクトで **StreamWebSocket** または **MessageWebSocket** をトランスポートとして使う場合はこのパターンを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-200">This pattern should be used with the **ControlChannelTrigger** object when a **StreamWebSocket** or **MessageWebSocket** is used as the transport.</span></span> <span data-ttu-id="46a3d-201">完了までに長時間かかる可能性がある操作 (一般的な非同期読み取り操作など) に対しては、既に説明した生の非同期パターンを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-201">For those operations that may take a long period of time to complete (a typical async read operation, for example), the app should use the raw async pattern discussed previously.</span></span>

<span data-ttu-id="46a3d-202">次のサンプルは、プッシュ通知と WebSocket キープアライブの [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) を [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) に対して登録します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-202">The following sample registers [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) for push notification and WebSocket keep-alives on the [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923).</span></span>

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
            && status != ControlChannelTriggerStatus.SoftwareSlotAllocated)
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

<span data-ttu-id="46a3d-203">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) または [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) を使う方法について詳しくは、[ControlChannelTrigger StreamWebSocket のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=251232)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-203">For more information on using [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032), see the [ControlChannelTrigger StreamWebSocket sample](http://go.microsoft.com/fwlink/p/?linkid=251232).</span></span>

## <a name="controlchanneltrigger-with-httpclient"></a><span data-ttu-id="46a3d-204">ControlChannelTrigger と HttpClient</span><span class="sxs-lookup"><span data-stu-id="46a3d-204">ControlChannelTrigger with HttpClient</span></span>
<span data-ttu-id="46a3d-205">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を使う場合は、特別な注意事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-205">Some special considerations apply when using [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span> <span data-ttu-id="46a3d-206">**ControlChannelTrigger** で [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を使う際には、トランスポート固有の使用パターンとベスト プラクティスに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-206">There are some transport-specific usage patterns and best practices that should be followed when using a [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) with **ControlChannelTrigger**.</span></span> <span data-ttu-id="46a3d-207">また、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) でパケットを受信する要求の処理方法にも、これらの注意事項が関係します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-207">In addition, these considerations affect the way that requests to receive packets on the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) are handled.</span></span>

<span data-ttu-id="46a3d-208">**注:** SSL を使用して[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637)では、ネットワーク トリガー機能と[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)を使ってを現在はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-208">**Note**[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) using SSL is not currently supported using the network trigger feature and [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span>
 
<span data-ttu-id="46a3d-209">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を使う際に従う必要のある使用パターンとベスト プラクティスを次に示します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-209">The following usage patterns and best practices should be followed when using [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032):</span></span>

-   <span data-ttu-id="46a3d-210">アプリで、特定の URI に要求を送る前に、[System.Net.Http](http://go.microsoft.com/fwlink/p/?linkid=227894) 名前空間の [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) オブジェクトまたは [HttpClientHandler](http://go.microsoft.com/fwlink/p/?linkid=241638) オブジェクトにさまざまなプロパティやヘッダーを設定する必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-210">The app may need to set various properties and headers on the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) or [HttpClientHandler](http://go.microsoft.com/fwlink/p/?linkid=241638) object in the [System.Net.Http](http://go.microsoft.com/fwlink/p/?linkid=227894) namespace before sending the request to the specific URI.</span></span>
-   <span data-ttu-id="46a3d-211">アプリには、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で使う [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) トランスポートを作る前に、トランスポートをテストし、正しく設定するための初期要求が必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-211">An app may need to make need to an initial request to test and setup the transport properly before creating the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) transport to be used with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span> <span data-ttu-id="46a3d-212">トランスポートを正しく設定できることがアプリによって確認されると、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) オブジェクトを **ControlChannelTrigger** オブジェクトで使うトランスポート オブジェクトとして構成できます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-212">Once the app determines that the transport can be properly setup, an [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) object can be configured as the transport object used with the **ControlChannelTrigger** object.</span></span> <span data-ttu-id="46a3d-213">このプロセスは、一部のシナリオでトランスポートを使って確立された接続が中断されないようにするためのものです。</span><span class="sxs-lookup"><span data-stu-id="46a3d-213">This process is designed prevent some scenarios from breaking the connection established over the transport.</span></span> <span data-ttu-id="46a3d-214">SSL と証明書を使う場合、アプリには、PIN 入力用、または選択する証明書が複数ある場合に表示されるダイアログが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-214">Using SSL with a certificate, an app may require a dialog to be displayed for PIN entry or if there are multiple certificates to choose from.</span></span> <span data-ttu-id="46a3d-215">プロキシ認証とサーバー認証が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-215">Proxy authentication and server authentication may be required.</span></span> <span data-ttu-id="46a3d-216">プロキシ認証またはサーバー認証の期限が切れると、接続が閉じる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-216">If the proxy or server authentication expires, the connection may be closed.</span></span> <span data-ttu-id="46a3d-217">これらの認証期限の問題に対処する 1 つの方法として、タイマーを設定できます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-217">One way an app can deal with these authentication expiration issues is to set a timer.</span></span> <span data-ttu-id="46a3d-218">HTTP リダイレクトが必要な場合、2 回目の接続は正しく確立できないことがあります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-218">When an HTTP redirect is required, it is not guaranteed that the second connection can be established reliably.</span></span> <span data-ttu-id="46a3d-219">初期テスト要求により、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) オブジェクトを **ControlChannelTrigger** オブジェクトでトランスポートとして使う前にアプリが最新のリダイレクト URL を使用できることが確認されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-219">An initial test request will ensure that the app can use the most up-to-date redirected URL before using the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) object as the transport with the **ControlChannelTrigger** object.</span></span>

<span data-ttu-id="46a3d-220">他のネットワーク トランスポートとは異なり、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) オブジェクトの [**UsingTransport**](https://msdn.microsoft.com/library/windows/apps/hh701175) メソッドに直接 [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) オブジェクトを渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-220">Unlike other network transports, the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) object cannot be directly passed into the [**UsingTransport**](https://msdn.microsoft.com/library/windows/apps/hh701175) method of the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) object.</span></span> <span data-ttu-id="46a3d-221">[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) オブジェクトと **ControlChannelTrigger** 用に特別な方法で [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) オブジェクトを構築する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-221">Instead, an [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) object must be specially constructed for use with the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) object and the **ControlChannelTrigger**.</span></span> <span data-ttu-id="46a3d-222">[HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) オブジェクトは、[RtcRequestFactory.Create](http://go.microsoft.com/fwlink/p/?linkid=259154) メソッドを使って作成します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-222">The [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) object is created using the [RtcRequestFactory.Create](http://go.microsoft.com/fwlink/p/?linkid=259154) method.</span></span> <span data-ttu-id="46a3d-223">そのうえで、作成した [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) オブジェクトを **UsingTransport** メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-223">The [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) object that is created is then passed to **UsingTransport** method.</span></span>

<span data-ttu-id="46a3d-224">次のサンプルでは、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) オブジェクトと [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で使う [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) オブジェクトを構築しています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-224">The following sample shows how to construct an [HttpRequestMessage](http://go.microsoft.com/fwlink/p/?linkid=259153) object for use with the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) object and the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span>

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

<span data-ttu-id="46a3d-225">いくつかの特別な注意事項は、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) で HTTP 要求を送信して応答の受け取りを開始するための要求の処理方法にかかわってきます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-225">Some special considerations affect the way that requests to send HTTP requests on the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) to initiate receiving a response are handled.</span></span> <span data-ttu-id="46a3d-226">特に、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を使うアプリは、送信処理に、**await** モデルではなく、Task を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-226">In particular, when using a [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) with the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032), your app must use a Task for handling sends instead of the **await** model.</span></span>

<span data-ttu-id="46a3d-227">[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を使った場合、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) のバックグラウンド タスクの [**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) メソッドと、受信完了コールバックの戻りとの同期が生じません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-227">Using [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637), there is no synchronization with the [**IBackgroundTask.Run**](https://msdn.microsoft.com/library/windows/apps/br224811) method on the background task for the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) with the return of the receive completion callback.</span></span> <span data-ttu-id="46a3d-228">したがって、アプリは、ブロックする HttpResponseMessage を **Run** メソッドで使い、応答全体を受け取るまで待機するしかありません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-228">For this reason, the app can only use the blocking HttpResponseMessage technique in the **Run** method and wait until the whole response is received.</span></span>

<span data-ttu-id="46a3d-229">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) での [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) の使用は、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) や [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842)、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) のトランスポートとは大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-229">Using [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) is noticeably different from the [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882), [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) or [**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) transports .</span></span> <span data-ttu-id="46a3d-230">[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) 受信コールバックは、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) コード以後、Task を介してアプリに送られます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-230">The [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) receive callback is delivered via a Task to the app since the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) code.</span></span> <span data-ttu-id="46a3d-231">つまり、データまたはエラーがアプリにディスパッチされるとすぐに **ControlChannelTrigger** プッシュ通知タスクが作動します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-231">This means that the **ControlChannelTrigger** push notification task will fire as soon as the data or error is dispatched to the app.</span></span> <span data-ttu-id="46a3d-232">以下のサンプル コードは、[HttpClient.SendAsync](http://go.microsoft.com/fwlink/p/?linkid=241637) メソッドから返された responseTask をグローバルなストレージに格納します。プッシュ通知タスクがそれを取り出し、インラインで処理します。</span><span class="sxs-lookup"><span data-stu-id="46a3d-232">In the sample below, the code stores the responseTask returned by [HttpClient.SendAsync](http://go.microsoft.com/fwlink/p/?linkid=241637) method into global storage that the push notify task will pick up and process inline.</span></span>

<span data-ttu-id="46a3d-233">次のサンプルは、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) と組み合わせて使い、送信要求を処理しています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-233">The following sample shows how to handle send requests on the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) when used with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span>

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
        && status != ControlChannelTriggerStatus.SoftwareSlotAllocated)
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

<span data-ttu-id="46a3d-234">次のサンプルは、[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) を [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) と組み合わせて使い、受け取った応答を読み取っています。</span><span class="sxs-lookup"><span data-stu-id="46a3d-234">The following sample shows how to read responses received on the [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) when used with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span>

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

<span data-ttu-id="46a3d-235">[HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) と [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) を使う方法について詳しくは、[ControlChannelTrigger HttpClient のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=258323)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-235">For more information on using [HttpClient](http://go.microsoft.com/fwlink/p/?linkid=241637) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032), see the [ControlChannelTrigger HttpClient sample](http://go.microsoft.com/fwlink/p/?linkid=258323).</span></span>

## <a name="controlchanneltrigger-with-ixmlhttprequest2"></a><span data-ttu-id="46a3d-236">ControlChannelTrigger と IXMLHttpRequest2</span><span class="sxs-lookup"><span data-stu-id="46a3d-236">ControlChannelTrigger with IXMLHttpRequest2</span></span>
<span data-ttu-id="46a3d-237">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) を使う場合は、特別な注意事項がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-237">Some special considerations apply when using [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span> <span data-ttu-id="46a3d-238">**ControlChannelTrigger** で **IXMLHTTPRequest2** を使う際には、トランスポート固有の使用パターンとベスト プラクティスに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-238">There are some transport-specific usage patterns and best practices that should be followed when using a **IXMLHTTPRequest2** with **ControlChannelTrigger**.</span></span> <span data-ttu-id="46a3d-239">**ControlChannelTrigger** の使用が、**IXMLHTTPRequest2** で HTTP 要求を送受信するための要求の処理方法に影響することはありません。</span><span class="sxs-lookup"><span data-stu-id="46a3d-239">Using **ControlChannelTrigger** does not affect the way that requests to send or receive HTTP requests on the **IXMLHTTPRequest2** are handled.</span></span>

<span data-ttu-id="46a3d-240">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) を使う際の使用パターンとベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="46a3d-240">Usage patterns and best practices when using [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)</span></span>

-   <span data-ttu-id="46a3d-241">トランスポートとして使われる [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) オブジェクトの有効期限は、1 つの要求/応答のみで構成されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-241">An [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) object when used as the transport has a lifetime of only one request/response.</span></span> <span data-ttu-id="46a3d-242">[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) オブジェクトと併用する場合は、**ControlChannelTrigger** オブジェクトを一度作って設定してから [**UsingTransport**](https://msdn.microsoft.com/library/windows/apps/hh701175) メソッドを繰り返し呼び出して、そのたびに新しい **IXMLHTTPRequest2** オブジェクトを関連付けると便利です。</span><span class="sxs-lookup"><span data-stu-id="46a3d-242">When used with the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) object, it is convenient to create and set up the **ControlChannelTrigger** object once and then call the [**UsingTransport**](https://msdn.microsoft.com/library/windows/apps/hh701175) method repeatedly, each time associating a new **IXMLHTTPRequest2** object.</span></span> <span data-ttu-id="46a3d-243">アプリは、新しい **IXMLHTTPRequest2** オブジェクトを提供する前に以前の **IXMLHTTPRequest2** オブジェクトを削除して、割り当てられたリソース制限を超えないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-243">An app should delete the previous **IXMLHTTPRequest2** object before supplying a new **IXMLHTTPRequest2** object to ensure that the app does not exceed the allocated resource limits.</span></span>
-   <span data-ttu-id="46a3d-244">アプリは、[**Send**](https://msdn.microsoft.com/library/windows/desktop/hh831164) メソッドを呼び出す前に、[**SetProperty**](https://msdn.microsoft.com/library/windows/desktop/hh831167) メソッドと [**SetRequestHeader**](https://msdn.microsoft.com/library/windows/desktop/hh831168) メソッドを呼び出して HTTP トランスポートを設定する必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-244">The app may need to call the [**SetProperty**](https://msdn.microsoft.com/library/windows/desktop/hh831167) and [**SetRequestHeader**](https://msdn.microsoft.com/library/windows/desktop/hh831168) methods to set up the HTTP transport before calling [**Send**](https://msdn.microsoft.com/library/windows/desktop/hh831164) method.</span></span>
-   <span data-ttu-id="46a3d-245">アプリには、[**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) で使うトランスポートを作る前に、トランスポートをテストし、正しく設定するための初期 [**Send**](https://msdn.microsoft.com/library/windows/desktop/hh831164) 要求が必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-245">An app may need to make need to an initial [**Send**](https://msdn.microsoft.com/library/windows/desktop/hh831164) request to test and setup the transport properly before creating the transport to be used with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032).</span></span> <span data-ttu-id="46a3d-246">アプリによってトランスポートが正しく設定されていることが確認されると、[**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) オブジェクトを **ControlChannelTrigger** で使うトランスポート オブジェクトとして構成できます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-246">Once the app determines that the transport is properly setup, the [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) object can be configured as the transport object used with the **ControlChannelTrigger**.</span></span> <span data-ttu-id="46a3d-247">このプロセスは、一部のシナリオでトランスポートを使って確立された接続が中断されないようにするためのものです。</span><span class="sxs-lookup"><span data-stu-id="46a3d-247">This process is designed prevent some scenarios from breaking the connection established over the transport.</span></span> <span data-ttu-id="46a3d-248">SSL と証明書を使う場合、アプリには、PIN 入力用、または選択する証明書が複数ある場合に表示されるダイアログが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-248">Using SSL with a certificate, an app may require a dialog to be displayed for PIN entry or if there are multiple certificates to choose from.</span></span> <span data-ttu-id="46a3d-249">プロキシ認証とサーバー認証が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-249">Proxy authentication and server authentication may be required.</span></span> <span data-ttu-id="46a3d-250">プロキシ認証またはサーバー認証の期限が切れると、接続が閉じる場合があります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-250">If the proxy or server authentication expires, the connection may be closed.</span></span> <span data-ttu-id="46a3d-251">これらの認証期限の問題に対処する 1 つの方法として、タイマーを設定できます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-251">One way an app can deal with these authentication expiration issues is to set a timer.</span></span> <span data-ttu-id="46a3d-252">HTTP リダイレクトが必要な場合、2 回目の接続は正しく確立できないことがあります。</span><span class="sxs-lookup"><span data-stu-id="46a3d-252">When an HTTP redirect is required, it is not guaranteed that the second connection can be established reliably.</span></span> <span data-ttu-id="46a3d-253">初期テスト要求により、**IXMLHTTPRequest2** オブジェクトを **ControlChannelTrigger** オブジェクトでトランスポートとして使う前にアプリが最新のリダイレクト URL を使用できることが確認されます。</span><span class="sxs-lookup"><span data-stu-id="46a3d-253">An initial test request will ensure that the app can use the most up-to-date redirected URL before using the **IXMLHTTPRequest2** object as the transport with the **ControlChannelTrigger** object.</span></span>

<span data-ttu-id="46a3d-254">[**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) と [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032) を使う方法について詳しくは、[ControlChannelTrigger と IXMLHTTPRequest2 のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=258538)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="46a3d-254">For more information on using [**IXMLHTTPRequest2**](https://msdn.microsoft.com/library/windows/desktop/hh831151) with [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032), see the [ControlChannelTrigger with IXMLHTTPRequest2 sample](http://go.microsoft.com/fwlink/p/?linkid=258538).</span></span>

## <a name="important-apis"></a><span data-ttu-id="46a3d-255">重要な API</span><span class="sxs-lookup"><span data-stu-id="46a3d-255">Important APIs</span></span>
* [<span data-ttu-id="46a3d-256">SocketActivityTrigger</span><span class="sxs-lookup"><span data-stu-id="46a3d-256">SocketActivityTrigger</span></span>](/uwp/api/Windows.ApplicationModel.Background.SocketActivityTrigger)
* [<span data-ttu-id="46a3d-257">ControlChannelTrigger</span><span class="sxs-lookup"><span data-stu-id="46a3d-257">ControlChannelTrigger</span></span>](/uwp/api/Windows.Networking.Sockets.ControlChannelTrigger)
