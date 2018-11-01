---
author: mtoepke
title: アプリを一時停止する方法 (DirectX と C++)
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリをシステムが一時停止するときに重要なシステム状態とアプリ データを保存する方法について説明します。
ms.assetid: 5dd435e5-ec7e-9445-fed4-9c0d872a239e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 一時停止, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 204d61430f59c820e9ef9ef36832cd1c24ee7f9c
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5887210"
---
# <a name="how-to-suspend-an-app-directx-and-c"></a>アプリを一時停止する方法 (DirectX と C++)



このトピックでは、ユニバーサル Windows プラットフォーム (UWP) DirectX アプリをシステムが一時停止するときに重要なシステム状態とアプリ データを保存する方法について説明します。

## <a name="register-the-suspending-event-handler"></a>suspending イベント ハンドラーに登録する


まず、[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントを処理するための登録を行います。このイベントは、ユーザーまたはシステムの動作によってアプリが一時停止の状態に移ったときに発生します。

このコードをビュー プロバイダーの [**IFrameworkView::Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドの実装に追加します。

```cpp
void App::Initialize(CoreApplicationView^ applicationView)
{
  //...
  
    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

  //...
}
```

## <a name="save-any-app-data-before-suspending"></a>一時停止の前に任意のアプリ データを保存する


アプリでは、[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントを処理する時点で、ハンドラー関数で重要なアプリケーション データを保存できます。 アプリで [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) Storage API を使って、シンプルなアプリケーション データを同期的に保存する必要があります。 ゲームを開発している場合は、重要なゲームの状態の情報を保存します。 オーディオ処理の一時停止も忘れずに行います。

ここで、コールバックを実装します。 アプリのデータはこのメソッドで保存します。

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

コールバックは 5 秒で完了する必要があります。 このコールバック中に、[**SuspendingOperation::GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) を呼び出して、保留を要求します。これによって、カウントダウンが開始されます。 アプリが保存操作を完了したら、[**SuspendingDeferral::Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) を呼び出して、アプリを一時停止する準備ができたことをシステムに通知します。 保留を要求しないか、アプリがデータの保存に 5 秒より長くかかった場合、アプリは自動的に一時停止されます。

このコールバックは、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225). の [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) によって処理されるイベント メッセージとして発生します。 このコールバックは、アプリのメイン ループ (ビュー プロバイダーの [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実装) から [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出さない場合は呼び出されません。

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

## <a name="call-trim"></a>Trim() を呼び出す


以降 Windows8.1 では、すべての DirectX UWP アプリ呼び出す必要があります[**idxgidevice 3::trim**](https://msdn.microsoft.com/library/windows/desktop/dn280346)中断時にします。 この呼び出しは、アプリに割り当てた一時バッファーをすべて解放するようにグラフィックス ドライバーに対して指示するものであり、アプリが中断状態にある間に終了してメモリ リソースが再利用される可能性を低く抑えることができます。 これは、Windows8.1 の認定要件です。

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

## <a name="release-any-exclusive-resources-and-file-handles"></a>任意の排他リソースとファイル ハンドルを解放する


アプリでは、[**CoreApplication::Suspending**](https://msdn.microsoft.com/library/windows/apps/br205860) イベントを処理する時点で、排他リソースとファイル ハンドルを解放することもできます。 排他リソースとファイル ハンドルを明示的に解放すると、自分のアプリが使っていないときに他のアプリが排他リソースとファイル ハンドルにアクセスできるようになります。 アプリが終了後にアクティブ化されるときに、排他リソースとファイル ハンドルを開く必要があります。

## <a name="remarks"></a>注釈


ユーザーが別のアプリまたはデスクトップに切り替えると、システムはアプリを中断します。 ユーザーが元のアプリに戻すと、システムはアプリを再開します。 システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。 システムはアプリを厳密に一時停止前の状態に復元するので、ユーザーからはアプリがバックグラウンドで実行していたように見えます。

システムは、アプリの一時停止中、アプリとそのデータをメモリに保持するよう試みます。 ただし、アプリをメモリに保持するためのリソースがシステムにない場合、システムはアプリを終了します。 一時停止されてから終了されたアプリにユーザーが戻るときに、システムは [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントを送って、**CoreApplicationView::Activated** イベントのハンドラーでアプリケーション データを復元する必要があります。

アプリが終了されるときは、システムはアプリに通知を送らないので、アプリは中断されたときにアプリケーション データを保存し、排他リソースとファイル ハンドルを解放して、アプリが終了後アクティブ化されるときにそれらを復元する必要があります。

## <a name="related-topics"></a>関連トピック

* [アプリを再開する方法 (DirectX と C++)](how-to-resume-an-app-directx-and-cpp.md)
* [アプリをアクティブ化する方法 (DirectX と C++)](how-to-activate-an-app-directx-and-cpp.md)

 

 




