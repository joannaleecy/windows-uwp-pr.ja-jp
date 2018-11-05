---
author: TylerMSFT
title: アプリの中断の処理
description: システムがアプリを中断するときに重要なアプリケーション データを保存する方法を説明します。
ms.assetid: F84F1512-24B9-45EC-BF23-A09E0AC985B0
ms.author: twhitney
ms.date: 07/06/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: 7cb93c410f583884f75f21d9beda03db87c024f9
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6027802"
---
# <a name="handle-app-suspend"></a><span data-ttu-id="8b70c-104">アプリの中断の処理</span><span class="sxs-lookup"><span data-stu-id="8b70c-104">Handle app suspend</span></span>

**<span data-ttu-id="8b70c-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="8b70c-105">Important APIs</span></span>**

- [**<span data-ttu-id="8b70c-106">中断</span><span class="sxs-lookup"><span data-stu-id="8b70c-106">Suspending</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242341)

<span data-ttu-id="8b70c-107">システムがアプリを中断するときに重要なアプリケーション データを保存する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="8b70c-107">Learn how to save important application data when the system suspends your app.</span></span> <span data-ttu-id="8b70c-108">このトピックの例では、[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントのイベント ハンドラーを登録して文字列をファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="8b70c-108">The example registers an event handler for the [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event and saves a string to a file.</span></span>

## <a name="register-the-suspending-event-handler"></a><span data-ttu-id="8b70c-109">中断イベント ハンドラーを登録する</span><span class="sxs-lookup"><span data-stu-id="8b70c-109">Register the suspending event handler</span></span>

<span data-ttu-id="8b70c-110">[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを処理するために登録します。このイベントは、システムがアプリを中断する前にアプリでアプリケーション データを保存する必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="8b70c-110">Register to handle the [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event, which indicates that your app should save its application data before the system suspends it.</span></span>

```csharp
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

partial class MainPage
{
   public MainPage()
   {
      InitializeComponent();
      Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
   }
}
```

```vb
Public NotInheritable Class MainPage

   Public Sub New()
      InitializeComponent()
      AddHandler Application.Current.Suspending, AddressOf App_Suspending
   End Sub
   
End Class
```

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();
    Windows::UI::Xaml::Application::Current().Suspending({ this, &MainPage::App_Suspending });
}
```

```cpp
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace AppName;

MainPage::MainPage()
{
   InitializeComponent();
   Application::Current->Suspending +=
       ref new SuspendingEventHandler(this, &MainPage::App_Suspending);
}
```

## <a name="save-application-data-before-suspension"></a><span data-ttu-id="8b70c-111">中断の前にアプリケーション データを保存する</span><span class="sxs-lookup"><span data-stu-id="8b70c-111">Save application data before suspension</span></span>

<span data-ttu-id="8b70c-112">アプリでは、[**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) イベントを処理する時点で、ハンドラー関数で重要なアプリケーション データを保存できます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-112">When your app handles the [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event, it has the opportunity to save its important application data in the handler function.</span></span> <span data-ttu-id="8b70c-113">アプリで [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) Storage API を使って、シンプルなアプリケーション データを同期的に保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-113">The app should use the [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) storage API to save simple application data synchronously.</span></span>

```csharp
partial class MainPage
{
    async void App_Suspending(
        Object sender,
        Windows.ApplicationModel.SuspendingEventArgs e)
    {
        // TODO: This is the time to save app data in case the process is terminated.
    }
}
```

```vb
Public NonInheritable Class MainPage

    Private Sub App_Suspending(
        sender As Object,
        e As Windows.ApplicationModel.SuspendingEventArgs) Handles OnSuspendEvent.Suspending

        ' TODO: This is the time to save app data in case the process is terminated.
    End Sub

End Class
```

```cppwinrt
void MainPage::App_Suspending(
    Windows::Foundation::IInspectable const& /* sender */,
    Windows::ApplicationModel::SuspendingEventArgs const& /* e */)
{
    // TODO: This is the time to save app data in case the process is terminated.
}
```

```cpp
void MainPage::App_Suspending(Object^ sender, SuspendingEventArgs^ e)
{
    // TODO: This is the time to save app data in case the process is terminated.
}
```

## <a name="release-resources"></a><span data-ttu-id="8b70c-114">リソースの解放</span><span class="sxs-lookup"><span data-stu-id="8b70c-114">Release resources</span></span>

<span data-ttu-id="8b70c-115">また、排他リソースとファイル ハンドルを、自分のアプリが中断されているときに他のアプリがアクセスできるように解放することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8b70c-115">You should release exclusive resources and file handles so that other apps can access them while your app is suspended.</span></span> <span data-ttu-id="8b70c-116">排他リソースには、カメラ、I/O デバイス、外部デバイス、ネットワーク リソースなどがあります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-116">Examples of exclusive resources include cameras, I/O devices, external devices, and network resources.</span></span> <span data-ttu-id="8b70c-117">排他リソースとファイル ハンドルを明示的に解放すると、自分のアプリが中断されているときに他のアプリが排他リソースとファイル ハンドルにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-117">Explicitly releasing exclusive resources and file handles helps to ensure that other apps can access them while your app is suspended.</span></span> <span data-ttu-id="8b70c-118">アプリが再開されるときに、排他リソースとファイル ハンドルを再取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-118">When the app is resumed, it should reacquire  its exclusive resources and file handles.</span></span>

## <a name="remarks"></a><span data-ttu-id="8b70c-119">注釈</span><span class="sxs-lookup"><span data-stu-id="8b70c-119">Remarks</span></span>

<span data-ttu-id="8b70c-120">ユーザーが別のアプリや、デスクトップまたはスタート画面に切り替えると、システムはアプリを中断します。</span><span class="sxs-lookup"><span data-stu-id="8b70c-120">The system suspends your app whenever the user switches to another app or to the desktop or Start screen.</span></span> <span data-ttu-id="8b70c-121">ユーザーが元のアプリに戻すと、システムはアプリを再開します。</span><span class="sxs-lookup"><span data-stu-id="8b70c-121">The system resumes your app whenever the user switches back to it.</span></span> <span data-ttu-id="8b70c-122">システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。</span><span class="sxs-lookup"><span data-stu-id="8b70c-122">When the system resumes your app, the content of your variables and data structures is the same as it was before the system suspended the app.</span></span> <span data-ttu-id="8b70c-123">システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-123">The system restores the app exactly where it left off, so that it appears to the user as if it's been running in the background.</span></span>

<span data-ttu-id="8b70c-124">システムは、アプリの一時停止中、アプリとそのデータをメモリに保持するよう試みます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-124">The system attempts to keep your app and its data in memory while it's suspended.</span></span> <span data-ttu-id="8b70c-125">ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。</span><span class="sxs-lookup"><span data-stu-id="8b70c-125">However, if the system does not have the resources to keep your app in memory, the system will terminate your app.</span></span> <span data-ttu-id="8b70c-126">中断されてから終了されたアプリにユーザーが戻るときに、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送って、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) メソッドでアプリケーション データを復元する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-126">When the user switches back to a suspended app that has been terminated, the system sends an [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) event and should restore its application data in its [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method.</span></span>

<span data-ttu-id="8b70c-127">アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断されたときにアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-127">The system doesn't notify an app when it's terminated, so your app must save its application data and release exclusive resources and file handles when it's suspended, and restore them when the app is activated after termination.</span></span>

<span data-ttu-id="8b70c-128">ハンドラー内で非同期呼び出しを行う場合、制御はその非同期呼び出しからすぐに戻ります。</span><span class="sxs-lookup"><span data-stu-id="8b70c-128">If you make an asynchronous call within your handler, control returns immediately from that asynchronous call.</span></span> <span data-ttu-id="8b70c-129">つまり、非同期呼び出しがまだ完了していない場合でも、イベント ハンドラーから制御が戻り、アプリを次の状態に移行できます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-129">That means that execution can then return from your event handler and your app will move to the next state even though the asynchronous call hasn't completed yet.</span></span> <span data-ttu-id="8b70c-130">イベント ハンドラーに渡される [**EnteredBackgroundEventArgs**](http://aka.ms/Ag2yh4) オブジェクトの [**GetDeferral**](http://aka.ms/Kt66iv) メソッドを使用して、[**Windows.Foundation.Deferral**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) オブジェクトの [**Complete**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.complete.aspx) メソッドを呼び出した後まで中断を延期することができます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-130">Use the [**GetDeferral**](http://aka.ms/Kt66iv) method on the [**EnteredBackgroundEventArgs**](http://aka.ms/Ag2yh4) object that is passed to your event handler to delay suspension until after you call the [**Complete**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.complete.aspx) method on the returned [**Windows.Foundation.Deferral**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.aspx) object.</span></span>

<span data-ttu-id="8b70c-131">遅延では、アプリが終了する前に、実行する必要があるコードの量を増やす必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8b70c-131">A deferral doesn't increase the amount you have to run your code before your app is terminated.</span></span> <span data-ttu-id="8b70c-132">遅延の *Complete* メソッドが呼び出されるか、または期限になるか、*どちらか早い方*まで、終了が延期されるだけです。</span><span class="sxs-lookup"><span data-stu-id="8b70c-132">It only delays termination until either the deferral's *Complete* method is called, or the deadline passes-*whichever comes first*.</span></span> <span data-ttu-id="8b70c-133">Suspending 状態[**ExtendedExecutionSession**で時間を延長するには](run-minimized-with-extended-execution.md)</span><span class="sxs-lookup"><span data-stu-id="8b70c-133">To extend time in the Suspending state use [**ExtendedExecutionSession**](run-minimized-with-extended-execution.md)</span></span>

> [!NOTE]
> <span data-ttu-id="8b70c-134">Windows8.1 でシステムの応答性を高めるためには、アプリは中断後、リソースに優先順位の低いアクセスを与えられます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-134">To improve system responsiveness in Windows8.1, apps are given low priority access to resources after they are suspended.</span></span> <span data-ttu-id="8b70c-135">この新しい優先度をサポートするために、中断操作のタイムアウトが延長され、アプリには通常の優先度と同程度のタイムアウト (Windows では 5 秒、Windows Phone では 1 ～ 10 秒) が与えられます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-135">To support this new priority, the suspend operation timeout is extended so that the app has the equivalent of the 5-second timeout for normal priority on Windows or between 1 and 10 seconds on Windows Phone.</span></span> <span data-ttu-id="8b70c-136">このタイムアウトの時間枠を延長したり、変更したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="8b70c-136">You cannot extend or alter this timeout window.</span></span>

<span data-ttu-id="8b70c-137">**Visual Studio によるデバッグに関する注意事項:** Visual Studio は、Visual Studio デバッガーにアタッチされているアプリを Windows が中断するのを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-137">**A note about debugging using Visual Studio:** Visual Studio prevents Windows from suspending an app that is attached to the debugger.</span></span> <span data-ttu-id="8b70c-138">これは、アプリが実行されている間、ユーザーが Visual Studio デバッグの UI を確認できるようにするためです。</span><span class="sxs-lookup"><span data-stu-id="8b70c-138">This is to allow the user to view the Visual Studio debug UI while the app is running.</span></span> <span data-ttu-id="8b70c-139">アプリのデバッグ中は、Visual Studio を使ってそのアプリに中断イベントを送信できます。</span><span class="sxs-lookup"><span data-stu-id="8b70c-139">When you're debugging an app, you can send it a suspend event using Visual Studio.</span></span> <span data-ttu-id="8b70c-140">**[デバッグの場所]** ツール バーが表示されていることを確認し、**[中断]** アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="8b70c-140">Make sure the **Debug Location** toolbar is being shown, then click the **Suspend** icon.</span></span>

## <a name="related-topics"></a><span data-ttu-id="8b70c-141">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8b70c-141">Related topics</span></span>

* [<span data-ttu-id="8b70c-142">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="8b70c-142">App lifecycle</span></span>](app-lifecycle.md)
* [<span data-ttu-id="8b70c-143">アプリのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="8b70c-143">Handle app activation</span></span>](activate-an-app.md)
* [<span data-ttu-id="8b70c-144">アプリの再開の処理</span><span class="sxs-lookup"><span data-stu-id="8b70c-144">Handle app resume</span></span>](resume-an-app.md)
* [<span data-ttu-id="8b70c-145">起動、中断、再開の UX ガイドライン</span><span class="sxs-lookup"><span data-stu-id="8b70c-145">UX guidelines for launch, suspend, and resume</span></span>](https://msdn.microsoft.com/library/windows/apps/dn611862)
* [<span data-ttu-id="8b70c-146">延長実行</span><span class="sxs-lookup"><span data-stu-id="8b70c-146">Extended Execution</span></span>](run-minimized-with-extended-execution.md)

 

 
