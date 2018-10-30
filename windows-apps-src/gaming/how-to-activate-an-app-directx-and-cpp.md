---
author: mtoepke
title: アプリをアクティブ化する方法 (DirectX と C++)
description: ここでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリのアクティブ化エクスペリエンスを定義する方法について説明します。
ms.assetid: b07c7da1-8a5e-5b57-6f77-6439bf653a53
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX, アクティブ化
ms.localizationpriority: medium
ms.openlocfilehash: b7f700ab97566ad9ec03d0595c55721dd9a9be98
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5836275"
---
# <a name="how-to-activate-an-app-directx-and-c"></a>アプリをアクティブ化する方法 (DirectX と C++)



ここでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリのアクティブ化エクスペリエンスを定義する方法について説明します。

## <a name="register-the-app-activation-event-handler"></a>アプリのアクティブ化イベント ハンドラーを登録する


まず、[**CoreApplicationView::Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを処理するための登録を行います。このイベントは、アプリが開始され、オペレーティング システムによって初期化されるときに発生します。

次のコードをビュー プロバイダー (この例では **MyViewProvider** という名前) の [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドの実装に追加します。

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

## <a name="activate-the-corewindow-instance-for-the-app"></a>アプリの CoreWindow インスタンスをアクティブ化する


アプリの起動時に、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) への参照を取得する必要があります。 **CoreWindow** には、アプリがウィンドウ イベントの処理に使うウィンドウ イベント メッセージ ディスパッチャーが含まれています。 アプリのアクティブ化イベントのコールバックで、[**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出して、この参照を取得します。 この参照を取得したら、[**CoreWindow::Activate**](https://msdn.microsoft.com/library/windows/apps/br208254) を呼び出して、メイン アプリ ウィンドウをアクティブ化します。

```cpp
void App::OnActivated(CoreApplicationView^ applicationView, IActivatedEventArgs^ args)
{
    // Run() won't start until the CoreWindow is activated.
    CoreWindow::GetForCurrentThread()->Activate();
}
```

## <a name="start-processing-event-message-for-the-main-app-window"></a>メイン アプリ ウィンドウのイベント メッセージの処理の開始


作成したコールバックは、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) によって処理されるイベント メッセージとして発生します。 このコールバックは、アプリのメイン ループ (ビュー プロバイダーの [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実装) から [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出さない場合は呼び出されません。

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

## <a name="related-topics"></a>関連トピック


* [アプリを一時停止する方法 (DirectX と C++)](how-to-suspend-an-app-directx-and-cpp.md)
* [アプリを再開する方法 (DirectX と C++)](how-to-resume-an-app-directx-and-cpp.md)

 

 




