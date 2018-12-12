---
title: アプリを一時停止する方法 (DirectX と C++)
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリをシステムが一時停止するときに重要なシステム状態とアプリ データを保存する方法について説明します。
ms.assetid: 5dd435e5-ec7e-9445-fed4-9c0d872a239e
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 一時停止, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 0b588d6bf6e7cbf43651d94a7fd46e9a767c6f09
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8945714"
---
# <a name="how-to-suspend-an-app-directx-and-c"></a><span data-ttu-id="0acb8-104">アプリを一時停止する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="0acb8-104">How to suspend an app (DirectX and C++)</span></span>



<span data-ttu-id="0acb8-105">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリをシステムが一時停止するときに重要なシステム状態とアプリ データを保存する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-105">This topic shows how to save important system state and app data when the system suspends your Universal Windows Platform (UWP) DirectX app.</span></span>

## <a name="register-the-suspending-event-handler"></a><span data-ttu-id="0acb8-106">suspending イベント ハンドラーに登録する</span><span class="sxs-lookup"><span data-stu-id="0acb8-106">Register the suspending event handler</span></span>


<span data-ttu-id="0acb8-107">まず、[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントを処理するための登録を行います。このイベントは、ユーザーまたはシステムの動作によってアプリが一時停止の状態に移ったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-107">First, register to handle the [**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) event, which is raised when your app is moved to a suspended state by a user or system action.</span></span>

<span data-ttu-id="0acb8-108">このコードをビュー プロバイダーの [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドの実装に追加します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-108">Add this code to your implementation of the [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) method of your view provider:</span></span>

```cpp
void App::Initialize(CoreApplicationView^ applicationView)
{
  //...
  
    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

  //...
}
```

## <a name="save-any-app-data-before-suspending"></a><span data-ttu-id="0acb8-109">一時停止の前に任意のアプリ データを保存する</span><span class="sxs-lookup"><span data-stu-id="0acb8-109">Save any app data before suspending</span></span>


<span data-ttu-id="0acb8-110">アプリでは、[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントを処理する時点で、ハンドラー関数で重要なアプリケーション データを保存できます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-110">When your app handles the [**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) event, it has the opportunity to save its important application data in the handler function.</span></span> <span data-ttu-id="0acb8-111">アプリで [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) Storage API を使って、シンプルなアプリケーション データを同期的に保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0acb8-111">The app should use the [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) storage API to save simple application data synchronously.</span></span> <span data-ttu-id="0acb8-112">ゲームを開発している場合は、重要なゲームの状態の情報を保存します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-112">If you are developing a game, save any critical game state information.</span></span> <span data-ttu-id="0acb8-113">オーディオ処理の一時停止も忘れずに行います。</span><span class="sxs-lookup"><span data-stu-id="0acb8-113">Don't forget to suspend the audio processing!</span></span>

<span data-ttu-id="0acb8-114">ここで、コールバックを実装します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-114">Now, implement the callback.</span></span> <span data-ttu-id="0acb8-115">アプリのデータはこのメソッドで保存します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-115">Save the app data in this method.</span></span>

```cpp
void App::OnSuspending(Platform::Object^ sender, SuspendingEventArgs^ args)
{
    // Save app state asynchronously after requesting a deferral. Holding a deferral
    // indicates that the application is busy performing suspending operations. Be
    // aware that a deferral may not be held indefinitely. After about five seconds,
    // the app will be forced to exit.
    SuspendingDeferral^ deferral = args->SuspendingOperation->GetDeferral();

    create_task([this, deferral]()
    {
        m_deviceResources->Trim();

        // Insert your code here.

        deferral->Complete();
    });
}
```

<span data-ttu-id="0acb8-116">コールバックは 5 秒で完了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0acb8-116">This callback must complete with 5 seconds.</span></span> <span data-ttu-id="0acb8-117">このコールバック中に、[**SuspendingOperation::GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) を呼び出して、保留を要求します。これによって、カウントダウンが開始されます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-117">During this callback, you must request a deferral by calling [**SuspendingOperation::GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690), which starts the countdown.</span></span> <span data-ttu-id="0acb8-118">アプリが保存操作を完了したら、[**SuspendingDeferral::Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) を呼び出して、アプリを一時停止する準備ができたことをシステムに通知します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-118">When your app completes the save operation, call [**SuspendingDeferral::Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) to tell the system that your app is now ready to be suspended.</span></span> <span data-ttu-id="0acb8-119">保留を要求しないか、アプリがデータの保存に 5 秒より長くかかった場合、アプリは自動的に一時停止されます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-119">If you do not request a deferral, or if your app takes longer than 5 seconds to save the data, your app is automatically suspended.</span></span>

<span data-ttu-id="0acb8-120">このコールバックは、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225). の [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) によって処理されるイベント メッセージとして発生します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-120">This callback occurs as an event message processed by the [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) for the app's [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225).</span></span> <span data-ttu-id="0acb8-121">このコールバックは、アプリのメイン ループ (ビュー プロバイダーの [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実装) から [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出さない場合は呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="0acb8-121">This callback will not be invoked if you do not call [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) from your app's main loop (implemented in the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method of your view provider).</span></span>

``` syntax
// This method is called after the window becomes active.
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_main->Update();

            if (m_main->Render())
            {
                m_deviceResources->Present();
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
}
```

## <a name="call-trim"></a><span data-ttu-id="0acb8-122">Trim() を呼び出す</span><span class="sxs-lookup"><span data-stu-id="0acb8-122">Call Trim()</span></span>


<span data-ttu-id="0acb8-123">以降 Windows8.1 では、すべての DirectX UWP アプリ呼び出す必要があります[**idxgidevice 3::trim**](https://msdn.microsoft.com/library/windows/desktop/dn280346)中断時にします。</span><span class="sxs-lookup"><span data-stu-id="0acb8-123">Starting in Windows8.1, all DirectX UWP apps must call [**IDXGIDevice3::Trim**](https://msdn.microsoft.com/library/windows/desktop/dn280346) when suspending.</span></span> <span data-ttu-id="0acb8-124">この呼び出しは、アプリに割り当てた一時バッファーをすべて解放するようにグラフィックス ドライバーに対して指示するものであり、アプリが中断状態にある間に終了してメモリ リソースが再利用される可能性を低く抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-124">This call tells the graphics driver to release all temporary buffers allocated for the app, which reduces the chance that the app will be terminated to reclaim memory resources while in the suspend state.</span></span> <span data-ttu-id="0acb8-125">これは、Windows8.1 の認定要件です。</span><span class="sxs-lookup"><span data-stu-id="0acb8-125">This is a certification requirement for Windows8.1.</span></span>

```cpp
void App::OnSuspending(Platform::Object^ sender, SuspendingEventArgs^ args)
{
    // Save app state asynchronously after requesting a deferral. Holding a deferral
    // indicates that the application is busy performing suspending operations. Be
    // aware that a deferral may not be held indefinitely. After about five seconds,
    // the app will be forced to exit.
    SuspendingDeferral^ deferral = args->SuspendingOperation->GetDeferral();

    create_task([this, deferral]()
    {
        m_deviceResources->Trim();

        // Insert your code here.

        deferral->Complete();
    });
}

// Call this method when the app suspends. It provides a hint to the driver that the app 
// is entering an idle state and that temporary buffers can be reclaimed for use by other apps.
void DX::DeviceResources::Trim()
{
    ComPtr<IDXGIDevice3> dxgiDevice;
    m_d3dDevice.As(&dxgiDevice);

    dxgiDevice->Trim();
}
```

## <a name="release-any-exclusive-resources-and-file-handles"></a><span data-ttu-id="0acb8-126">任意の排他リソースとファイル ハンドルを解放する</span><span class="sxs-lookup"><span data-stu-id="0acb8-126">Release any exclusive resources and file handles</span></span>


<span data-ttu-id="0acb8-127">アプリでは、[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントを処理する時点で、排他リソースとファイル ハンドルを解放することもできます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-127">When your app handles the [**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) event, it also has the opportunity to release exclusive resources and file handles.</span></span> <span data-ttu-id="0acb8-128">排他リソースとファイル ハンドルを明示的に解放すると、自分のアプリが使っていないときに他のアプリが排他リソースとファイル ハンドルにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="0acb8-128">Explicitly releasing exclusive resources and file handles helps to ensure that other apps can access them while your app isn't using them.</span></span> <span data-ttu-id="0acb8-129">アプリが終了後にアクティブ化されるときに、排他リソースとファイル ハンドルを開く必要があります。</span><span class="sxs-lookup"><span data-stu-id="0acb8-129">When the app is activated after termination, it should open its exclusive resources and file handles.</span></span>

## <a name="remarks"></a><span data-ttu-id="0acb8-130">注釈</span><span class="sxs-lookup"><span data-stu-id="0acb8-130">Remarks</span></span>


<span data-ttu-id="0acb8-131">ユーザーが別のアプリまたはデスクトップに切り替えると、システムはアプリを中断します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-131">The system suspends your app whenever the user switches to another app or to the desktop.</span></span> <span data-ttu-id="0acb8-132">ユーザーが元のアプリに戻すと、システムはアプリを再開します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-132">The system resumes your app whenever the user switches back to it.</span></span> <span data-ttu-id="0acb8-133">システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。</span><span class="sxs-lookup"><span data-stu-id="0acb8-133">When the system resumes your app, the content of your variables and data structures is the same as it was before the system suspended the app.</span></span> <span data-ttu-id="0acb8-134">システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-134">The system restores the app exactly where it left off, so that it appears to the user as if it's been running in the background.</span></span>

<span data-ttu-id="0acb8-135">システムは、アプリの一時停止中、アプリとそのデータをメモリに保持するよう試みます。</span><span class="sxs-lookup"><span data-stu-id="0acb8-135">The system attempts to keep your app and its data in memory while it's suspended.</span></span> <span data-ttu-id="0acb8-136">ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。</span><span class="sxs-lookup"><span data-stu-id="0acb8-136">However, if the system does not have the resources to keep your app in memory, the system will terminate your app.</span></span> <span data-ttu-id="0acb8-137">一時停止されてから終了されたアプリにユーザーが戻るときに、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送って、**CoreApplicationView::Activated** イベントのハンドラーでアプリケーション データを復元する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0acb8-137">When the user switches back to a suspended app that has been terminated, the system sends an [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) event and should restore its application data in its handler for the **CoreApplicationView::Activated** event.</span></span>

<span data-ttu-id="0acb8-138">アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断されたときにアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0acb8-138">The system doesn't notify an app when it's terminated, so your app must save its application data and release exclusive resources and file handles when it's suspended, and restore them when the app is activated after termination.</span></span>

## <a name="related-topics"></a><span data-ttu-id="0acb8-139">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0acb8-139">Related topics</span></span>

* [<span data-ttu-id="0acb8-140">アプリを再開する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="0acb8-140">How to resume an app (DirectX and C++)</span></span>](how-to-resume-an-app-directx-and-cpp.md)
* [<span data-ttu-id="0acb8-141">アプリをアクティブ化する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="0acb8-141">How to activate an app (DirectX and C++)</span></span>](how-to-activate-an-app-directx-and-cpp.md)

 

 




