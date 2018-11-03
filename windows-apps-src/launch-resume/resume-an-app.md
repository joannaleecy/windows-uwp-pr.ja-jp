---
author: TylerMSFT
title: アプリの再開の処理
description: システムがアプリを再開するときに表示されるコンテンツを更新する方法について説明します。
ms.assetid: DACCC556-B814-4600-A10A-90B82664EA15
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
ms.openlocfilehash: 717c819aaa732cf8d29e0a701a1fec81485f48ac
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5985745"
---
# <a name="handle-app-resume"></a><span data-ttu-id="64a37-104">アプリの再開の処理</span><span class="sxs-lookup"><span data-stu-id="64a37-104">Handle app resume</span></span>

**<span data-ttu-id="64a37-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="64a37-105">Important APIs</span></span>**

- [**<span data-ttu-id="64a37-106">Resuming</span><span class="sxs-lookup"><span data-stu-id="64a37-106">Resuming</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242339)

<span data-ttu-id="64a37-107">システムがアプリを再開するときに、どこで UI を更新するかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="64a37-107">Learn where to refresh your UI when the system resumes your app.</span></span> <span data-ttu-id="64a37-108">このトピックの例では、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントのイベント ハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="64a37-108">The example in this topic registers an event handler for the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event.</span></span>

## <a name="register-the-resuming-event-handler"></a><span data-ttu-id="64a37-109">Resuming イベント ハンドラーに登録する</span><span class="sxs-lookup"><span data-stu-id="64a37-109">Register the resuming event handler</span></span>

<span data-ttu-id="64a37-110">[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理するために登録します。このイベントは、ユーザーがアプリを切り替えてから、アプリに戻ったことを示します。</span><span class="sxs-lookup"><span data-stu-id="64a37-110">Register to handle the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event, which indicates that the user switched away from your app and then back to it.</span></span>

```csharp
partial class MainPage
{
   public MainPage()
   {
      InitializeComponent();
      Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
   }
}
```

```vb
Public NonInheritable Class MainPage

   Public Sub New()
      InitializeComponent()
      AddHandler Application.Current.Resuming, AddressOf App_Resuming
   End Sub

End Class
```

```cppwinrt
MainPage::MainPage()
{
    InitializeComponent();
    Windows::UI::Xaml::Application::Current().Resuming({ this, &MainPage::App_Resuming });
}
```

```cpp
MainPage::MainPage()
{
    InitializeComponent();
    Application::Current->Resuming +=
        ref new EventHandler<Platform::Object^>(this, &MainPage::App_Resuming);
}
```

## <a name="refresh-displayed-content-and-reacquire-resources"></a><span data-ttu-id="64a37-111">表示されているコンテンツの更新とリソースの再取得</span><span class="sxs-lookup"><span data-stu-id="64a37-111">Refresh displayed content and reacquire resources</span></span>

<span data-ttu-id="64a37-112">ユーザーが別のアプリまたはデスクトップに切り替えると、数秒後にシステムがアプリを中断します。</span><span class="sxs-lookup"><span data-stu-id="64a37-112">The system suspends your app a few seconds after the user switches to another app or to the desktop.</span></span> <span data-ttu-id="64a37-113">ユーザーが元のアプリに戻すと、システムはアプリを再開します。</span><span class="sxs-lookup"><span data-stu-id="64a37-113">The system resumes your app when the user switches back to it.</span></span> <span data-ttu-id="64a37-114">システムがアプリを再開した時点で、変数とデータ構造の内容は、システムがアプリを一時停止する前の状態と同じです。</span><span class="sxs-lookup"><span data-stu-id="64a37-114">When the system resumes your app, the content of your variables and data structures are the same as they were before the system suspended the app.</span></span> <span data-ttu-id="64a37-115">システムは、アプリを中断前の状態に復元します。</span><span class="sxs-lookup"><span data-stu-id="64a37-115">The system restores the app where it left off.</span></span> <span data-ttu-id="64a37-116">ユーザーには、アプリがバックグラウンドで実行されていたかのように見えます。</span><span class="sxs-lookup"><span data-stu-id="64a37-116">To the user, it appears as if the app has been running in the background.</span></span>

<span data-ttu-id="64a37-117">アプリが [ **Resuming** ](https://msdn.microsoft.com/library/windows/apps/br242339) イベントを処理した時点で、アプリの中断時間が数時間 (あるいは数日間) に及んでいる可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="64a37-117">When your app handles the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event, your app may be been suspended for hours or days.</span></span> <span data-ttu-id="64a37-118">アプリが中断されている間に古くなった可能性があるコンテンツは、すべて更新されます (ニュース フィードやユーザーの所在地など)。</span><span class="sxs-lookup"><span data-stu-id="64a37-118">It should refresh any content that might have become stale while the app was suspended, such as news feeds or the user's location.</span></span>

<span data-ttu-id="64a37-119">これは、アプリが中断されたときにリリースした排他リソース (ファイル ハンドル、カメラ、I/O デバイス、外部デバイス、およびネットワーク リソースなど) を復元する良い機会でもあります。</span><span class="sxs-lookup"><span data-stu-id="64a37-119">This is also a good time to restore any exclusive resources that you released when your app was suspended such as file handles, cameras, I/O devices, external devices, and network resources.</span></span>

```csharp
partial class MainPage
{
    private void App_Resuming(Object sender, Object e)
    {
        // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
    }
}
```

```vb
Public NonInheritable Class MainPage

    Private Sub App_Resuming(sender As Object, e As Object)
 
        ' TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.

    End Sub
>
End Class
```

```cppwinrt
void MainPage::App_Resuming(
    Windows::Foundation::IInspectable const& /* sender */,
    Windows::Foundation::IInspectable const& /* e */)
{
    // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
}
```

```cpp
void MainPage::App_Resuming(Object^ sender, Object^ e)
{
    // TODO: Refresh network data, perform UI updates, and reacquire resources like cameras, I/O devices, etc.
}
```

> [!NOTE]
> <span data-ttu-id="64a37-120">UI スレッドから、 [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339)イベントが発生しないため、ディスパッチャーを UI への呼び出しをディスパッチするハンドラーで使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="64a37-120">Because the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event is not raised from the UI thread, a dispatcher must be used in your handler to dispatch any calls to your UI.</span></span>

## <a name="remarks"></a><span data-ttu-id="64a37-121">注釈</span><span class="sxs-lookup"><span data-stu-id="64a37-121">Remarks</span></span>

<span data-ttu-id="64a37-122">アプリが Visual Studio のデバッガーにアタッチされている場合、アプリは中断されません。</span><span class="sxs-lookup"><span data-stu-id="64a37-122">When your app is attached to the Visual Studio debugger, it will not be suspended.</span></span> <span data-ttu-id="64a37-123">ただし、アプリをデバッガーから中断した後、アプリに **Resume** イベントを送信してコードをデバッグすることは可能です。</span><span class="sxs-lookup"><span data-stu-id="64a37-123">You can suspend it from the debugger, however, and then send it a **Resume** event so that you can debug your code.</span></span> <span data-ttu-id="64a37-124">**[デバッグの場所] ツール バー**が表示されていることを確認し、**[中断]** アイコンの横のドロップダウンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="64a37-124">Make sure the **Debug Location toolbar** is visible and click the drop-down next to the **Suspend** icon.</span></span> <span data-ttu-id="64a37-125">次に、**[再開]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="64a37-125">Then choose **Resume**.</span></span>

<span data-ttu-id="64a37-126">Windows Phone ストア アプリでは、アプリが現在一時停止中で、ユーザーがプライマリ タイルまたはアプリの一覧からアプリを再起動した場合でも、[**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) イベントの後に、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) イベントが常に発生します。</span><span class="sxs-lookup"><span data-stu-id="64a37-126">For Windows Phone Store apps, the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event is always followed by [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335), even when your app is currently suspended and the user re-launches your app from a primary tile or app list.</span></span> <span data-ttu-id="64a37-127">現在のウィンドウにコンテンツ セットが既にある場合、アプリは初期化をスキップすることがあります。</span><span class="sxs-lookup"><span data-stu-id="64a37-127">Apps can skip initialization if there is already content set on the current window.</span></span> <span data-ttu-id="64a37-128">[**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) プロパティをチェックすると、アプリがプライマリ タイルとセカンダリ タイルのどちらから起動されたかを調べ、その情報に基づいて新しいアプリ エクスペリエンスを表示するか、アプリ エクスペリエンスを再開するかを判断できます。</span><span class="sxs-lookup"><span data-stu-id="64a37-128">You can check the [**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) property to determine if the app was launched from a primary or a secondary tile and, based on that information, decide whether you should present a fresh or resume app experience.</span></span>

## <a name="related-topics"></a><span data-ttu-id="64a37-129">関連トピック</span><span class="sxs-lookup"><span data-stu-id="64a37-129">Related topics</span></span>

* [<span data-ttu-id="64a37-130">アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="64a37-130">App lifecycle</span></span>](app-lifecycle.md)
* [<span data-ttu-id="64a37-131">アプリのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="64a37-131">Handle app activation</span></span>](activate-an-app.md)
* [<span data-ttu-id="64a37-132">アプリの中断の処理</span><span class="sxs-lookup"><span data-stu-id="64a37-132">Handle app suspend</span></span>](suspend-an-app.md)
