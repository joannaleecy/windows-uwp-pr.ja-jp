---
author: mtoepke
title: アプリをアクティブ化する方法 (DirectX と C++)
description: ここでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリのアクティブ化エクスペリエンスを定義する方法について説明します。
ms.assetid: b07c7da1-8a5e-5b57-6f77-6439bf653a53
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, DirectX, アクティブ化
ms.openlocfilehash: 4d3585e28ca4a3665a881df4f16a3cc3f82fcc52
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243140"
---
# <a name="how-to-activate-an-app-directx-and-c"></a><span data-ttu-id="aa4b5-104">アプリをアクティブ化する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="aa4b5-104">How to activate an app (DirectX and C++)</span></span>


<span data-ttu-id="aa4b5-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="aa4b5-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="aa4b5-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="aa4b5-107">ここでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリのアクティブ化エクスペリエンスを定義する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-107">This topic shows how to define the activation experience for a Universal Windows Platform (UWP) DirectX app.</span></span>

## <a name="register-the-app-activation-event-handler"></a><span data-ttu-id="aa4b5-108">アプリのアクティブ化イベント ハンドラーを登録する</span><span class="sxs-lookup"><span data-stu-id="aa4b5-108">Register the app activation event handler</span></span>


<span data-ttu-id="aa4b5-109">まず、[**CoreApplicationView::Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを処理するための登録を行います。このイベントは、アプリが開始され、オペレーティング システムによって初期化されるときに発生します。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-109">First, register to handle the [**CoreApplicationView::Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) event, which is raised when your app is started and initialized by the operating system.</span></span>

<span data-ttu-id="aa4b5-110">次のコードをビュー プロバイダー (この例では **MyViewProvider** という名前) の [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドの実装に追加します。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-110">Add this code to your implementation of the [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) method of your view provider (named **MyViewProvider** in the example):</span></span>

```cpp
void App::Initialize(CoreApplicationView^ applicationView)
{
    // Register event handlers for the app lifecycle. This example includes Activated, so that we
    // can make the CoreWindow active and start rendering on the window.
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);
  
  //...

}
```

## <a name="activate-the-corewindow-instance-for-the-app"></a><span data-ttu-id="aa4b5-111">アプリの CoreWindow インスタンスをアクティブ化する</span><span class="sxs-lookup"><span data-stu-id="aa4b5-111">Activate the CoreWindow instance for the app</span></span>


<span data-ttu-id="aa4b5-112">アプリの起動時に、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) への参照を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-112">When your app starts, you must obtain a reference to the [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) for your app.</span></span> <span data-ttu-id="aa4b5-113">**CoreWindow** には、アプリがウィンドウ イベントの処理に使うウィンドウ イベント メッセージ ディスパッチャーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-113">**CoreWindow** contains the window event message dispatcher that your app uses to process window events.</span></span> <span data-ttu-id="aa4b5-114">アプリのアクティブ化イベントのコールバックで、[**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出して、この参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-114">Obtain this reference in your callback for the app activation event by calling [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589).</span></span> <span data-ttu-id="aa4b5-115">この参照を取得したら、[**CoreWindow::Activate**](https://msdn.microsoft.com/library/windows/apps/br208254) を呼び出して、メイン アプリ ウィンドウをアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-115">Once you have obtained this reference, activate the main app window by calling [**CoreWindow::Activate**](https://msdn.microsoft.com/library/windows/apps/br208254).</span></span>

```cpp
void App::OnActivated(CoreApplicationView^ applicationView, IActivatedEventArgs^ args)
{
    // Run() won't start until the CoreWindow is activated.
    CoreWindow::GetForCurrentThread()->Activate();
}
```

## <a name="start-processing-event-message-for-the-main-app-window"></a><span data-ttu-id="aa4b5-116">メイン アプリ ウィンドウのイベント メッセージの処理の開始</span><span class="sxs-lookup"><span data-stu-id="aa4b5-116">Start processing event message for the main app window</span></span>


<span data-ttu-id="aa4b5-117">作成したコールバックは、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) によって処理されるイベント メッセージとして発生します。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-117">Your callbacks occur as event messages are processed by the [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) for the app's [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225).</span></span> <span data-ttu-id="aa4b5-118">このコールバックは、アプリのメイン ループ (ビュー プロバイダーの [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実装) から [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出さない場合は呼び出されません。</span><span class="sxs-lookup"><span data-stu-id="aa4b5-118">This callback will not be invoked if you do not call [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) from your app's main loop (implemented in the [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) method of your view provider).</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="aa4b5-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="aa4b5-119">Related topics</span></span>


* [<span data-ttu-id="aa4b5-120">アプリを一時停止する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="aa4b5-120">How to suspend an app (DirectX and C++)</span></span>](how-to-suspend-an-app-directx-and-cpp.md)
* [<span data-ttu-id="aa4b5-121">アプリを再開する方法 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="aa4b5-121">How to resume an app (DirectX and C++)</span></span>](how-to-resume-an-app-directx-and-cpp.md)

 

 




