---
author: mtoepke
title: アプリを再開する方法 (DirectX と C++)
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリをシステムが再開するときに重要なアプリケーション データを復元する方法について説明します。
ms.assetid: 5e6bb673-6874-ace5-05eb-f88c045f2178
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 再開, DirectX
ms.openlocfilehash: 0ef4617417526cd2e39ce968e4d682b4015e22d3
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243142"
---
# <a name="how-to-resume-an-app-directx-and-c"></a><span data-ttu-id="9e579-104">アプリを再開する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="9e579-104">How to resume an app (DirectX and C++)</span></span>


<span data-ttu-id="9e579-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="9e579-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="9e579-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="9e579-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="9e579-107">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリをシステムが再開するときに重要なアプリケーション データを復元する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9e579-107">This topic shows how to restore important application data when the system resumes your Universal Windows Platform (UWP) DirectX app.</span></span>

## <a name="register-the-resuming-event-handler"></a><span data-ttu-id="9e579-108">resuming イベント ハンドラーに登録する</span><span class="sxs-lookup"><span data-stu-id="9e579-108">Register the resuming event handler</span></span>


<span data-ttu-id="9e579-109">[**CoreApplication::Resuming**](https://msdn.microsoft.com/library/windows/apps/br205859) イベントを処理するために登録します。このイベントは、ユーザーがアプリを切り替えてから、アプリに戻ったことを示します。</span><span class="sxs-lookup"><span data-stu-id="9e579-109">Register to handle the [**CoreApplication::Resuming**](https://msdn.microsoft.com/library/windows/apps/br205859) event, which indicates that the user switched away from your app and then back to it.</span></span>

<span data-ttu-id="9e579-110">このコードをビュー プロバイダーの [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドの実装に追加します。</span><span class="sxs-lookup"><span data-stu-id="9e579-110">Add this code to your implementation of the [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) method of your view provider:</span></span>

```cpp
// The first method is called when the IFrameworkView is being created.
void App::Initialize(CoreApplicationView^ applicationView)
{
  //...
  
    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);
    
  //...

}
```

## <a name="refresh-displayed-content-after-suspension"></a><span data-ttu-id="9e579-111">一時停止の後で表示されるコンテンツを更新する</span><span class="sxs-lookup"><span data-stu-id="9e579-111">Refresh displayed content after suspension</span></span>


<span data-ttu-id="9e579-112">アプリでは、Resuming イベントを処理する時点で、表示されているコンテンツを更新できます。</span><span class="sxs-lookup"><span data-stu-id="9e579-112">When your app handles the Resuming event, it has the opportunity to refresh its displayed content.</span></span> <span data-ttu-id="9e579-113">[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) のハンドラーで保存した任意のアプリを復元し、処理を再開します。</span><span class="sxs-lookup"><span data-stu-id="9e579-113">Restore any app you have saved with your handler for [**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860), and restart processing.</span></span> <span data-ttu-id="9e579-114">ゲーム開発の場合、オーディオ エンジンを一時停止していたら、ここで再開します。</span><span class="sxs-lookup"><span data-stu-id="9e579-114">Game devs: if you've suspended your audio engine, now's the time to restart it.</span></span>

```cpp
void App::OnResuming(Platform::Object^ sender, Platform::Object^ args)
{
    // Restore any data or state that was unloaded on suspend. By default, data
    // and state are persisted when resuming from suspend. Note that this event
    // does not occur if the app was previously terminated.

    // Insert your code here.
}
```

<span data-ttu-id="9e579-115">このコールバックは、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225). の [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) によって処理されるイベント メッセージとして発生します。</span><span class="sxs-lookup"><span data-stu-id="9e579-115">This callback occurs as an event message processed by the [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) for the app's [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225).</span></span> <span data-ttu-id="9e579-116">このコールバックは、アプリのメイン ループ (ビュー プロバイダーの [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実装) から [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出さない場合は呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="9e579-116">This callback will not be invoked if you do not call [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) from your app's main loop (implemented in the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method of your view provider).</span></span>

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

## <a name="remarks"></a><span data-ttu-id="9e579-117">注釈</span><span class="sxs-lookup"><span data-stu-id="9e579-117">Remarks</span></span>


<span data-ttu-id="9e579-118">ユーザーが別のアプリまたはデスクトップに切り替えると、システムはアプリを中断します。</span><span class="sxs-lookup"><span data-stu-id="9e579-118">The system suspends your app whenever the user switches to another app or to the desktop.</span></span> <span data-ttu-id="9e579-119">ユーザーが元のアプリに戻すと、システムはアプリを再開します。</span><span class="sxs-lookup"><span data-stu-id="9e579-119">The system resumes your app whenever the user switches back to it.</span></span> <span data-ttu-id="9e579-120">システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。</span><span class="sxs-lookup"><span data-stu-id="9e579-120">When the system resumes your app, the content of your variables and data structures is the same as it was before the system suspended the app.</span></span> <span data-ttu-id="9e579-121">システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。</span><span class="sxs-lookup"><span data-stu-id="9e579-121">The system restores the app exactly where it left off, so that it appears to the user as if it's been running in the background.</span></span> <span data-ttu-id="9e579-122">しかし、アプリは長時間一時停止している場合があるので、アプリが一時停止している間に変化した可能性のある表示コンテンツを更新し、レンダリングやオーディオ処理スレッドを再開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e579-122">However, the app may have been suspended for a significant amount of time, so it should refresh any displayed content that might have changed while the app was suspended, and restart any rendering or audio processing threads.</span></span> <span data-ttu-id="9e579-123">以前の一時中止イベント中にゲームの状態データを保存してある場合は、ここで復元します。</span><span class="sxs-lookup"><span data-stu-id="9e579-123">If you've saved any game state data during a previous suspend event, restore it now.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9e579-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9e579-124">Related topics</span></span>

* [<span data-ttu-id="9e579-125">アプリを一時停止する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="9e579-125">How to suspend an app (DirectX and C++)</span></span>](how-to-suspend-an-app-directx-and-cpp.md)
* [<span data-ttu-id="9e579-126">アプリをアクティブ化する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="9e579-126">How to activate an app (DirectX and C++)</span></span>](how-to-activate-an-app-directx-and-cpp.md)

 

 




