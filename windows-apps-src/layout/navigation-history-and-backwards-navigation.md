---
author: mijacobs
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。"
title: "ナビゲーション履歴と前に戻る移動 (Windows アプリ)"
ms.assetid: e9876b4c-242d-402d-a8ef-3487398ed9b3
isNew: True
label: History and backwards navigation
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: cd3184ebe5e94c410d55a725129a38907aa6a01e
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
#  <a name="navigation-history-and-backwards-navigation-for-uwp-apps"></a><span data-ttu-id="4a5c4-104">UWP アプリのナビゲーション履歴と前に戻る移動</span><span class="sxs-lookup"><span data-stu-id="4a5c4-104">Navigation history and backwards navigation for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="4a5c4-105">Web の場合、個々の Web サイトには独自のナビゲーション システム (目次、ボタン、メニュー、リンクの簡単な一覧など) が用意されています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-105">On the Web, individual web sites provide their own navigation systems, such as tables of contents, buttons, menus, simple lists of links, and so on.</span></span> <span data-ttu-id="4a5c4-106">ナビゲーション エクスペリエンスは、Web サイトによっては大幅に異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-106">The navigation experience can vary wildly from website to website.</span></span> <span data-ttu-id="4a5c4-107">ただし、一貫して同じナビゲーション エクスペリエンスが 1 つあります。それは "戻る" 操作です。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-107">However, there is one consistent navigation experience: back.</span></span> <span data-ttu-id="4a5c4-108">ほとんどのブラウザーには、Web サイトに関係なく同じように動作する戻るボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-108">Most browsers provide a back button that behaves the same way regardless of the website.</span></span>

> <span data-ttu-id="4a5c4-109">**重要な API**: [SystemNavigationManager クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Core.SystemNavigationManager)、[BackRequested イベント](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Core.SystemNavigationManager#Windows_UI_Core_SystemNavigationManager_BackRequested), [OnNavigatedTo](https://msdn.microsoft.com/library/windows/apps/br227508)</span><span class="sxs-lookup"><span data-stu-id="4a5c4-109">**Important APIs**: [SystemNavigationManager class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Core.SystemNavigationManager), [BackRequested event](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Core.SystemNavigationManager#Windows_UI_Core_SystemNavigationManager_BackRequested), [OnNavigatedTo](https://msdn.microsoft.com/library/windows/apps/br227508)</span></span>

<span data-ttu-id="4a5c4-110">同様の理由から、ユニバーサル Windows プラットフォーム (UWP) では、アプリのユーザーのナビゲーションの履歴内の移動や、デバイスによってはアプリ間の移動について、一貫性のある "戻る" ナビゲーション システムを提供します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-110">For similar reasons, the Universal Windows Platform (UWP) provides a consistent back navigation system for traversing the user's navigation history within an app and, depending on the device, from app to app.</span></span>

<span data-ttu-id="4a5c4-111">システムの戻るボタンの UI は、フォーム ファクターや入力デバイスの種類ごとに最適化されますが、ナビゲーション エクスペリエンスはグローバルであり、デバイスや UWP アプリで一貫しています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-111">The UI for the system back button is optimized for each form factor and input device type, but the navigation experience is global and consistent across devices and UWP apps.</span></span>

<span data-ttu-id="4a5c4-112">主なフォーム ファクターでの戻るボタン UI を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-112">Here are the primary form factors with the back button UI:</span></span>


<table>
    <tr>
        <td colspan="2"><span data-ttu-id="4a5c4-113">デバイス</span><span class="sxs-lookup"><span data-stu-id="4a5c4-113">Devices</span></span></td>
        <td style="vertical-align:top;"><span data-ttu-id="4a5c4-114">戻るボタンの動作</span><span class="sxs-lookup"><span data-stu-id="4a5c4-114">Back button behavior</span></span></td>
     </tr>
    <tr>
        <td style="vertical-align:top;"><span data-ttu-id="4a5c4-115">電話</span><span class="sxs-lookup"><span data-stu-id="4a5c4-115">Phone</span></span></td>
        <td style="vertical-align:top;">![電話でのシステムの戻るボタン](images/back-systemback-phone.png)</td>
        <td style="vertical-align:top;">
        <ul>
<li><span data-ttu-id="4a5c4-117">常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-117">Always present.</span></span></li>
<li><span data-ttu-id="4a5c4-118">デバイスの下部にあるソフトウェアまたはハードウェア ボタン。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-118">A software or hardware button at the bottom of the device.</span></span></li>
<li><span data-ttu-id="4a5c4-119">アプリ内部やアプリ間で、グローバルな戻るナビゲーションを実現します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-119">Global back navigation within the app and between apps.</span></span></li>
</ul>
</td>
     </tr>
     <tr>
        <td style="vertical-align:top;"><span data-ttu-id="4a5c4-120">タブレット</span><span class="sxs-lookup"><span data-stu-id="4a5c4-120">Tablet</span></span></td>
        <td style="vertical-align:top;">![タブレットでのシステムの戻るボタン (タブレット モード)](images/back-systemback-tablet.png)</td>
        <td style="vertical-align:top;">
<ul>
<li><span data-ttu-id="4a5c4-122">タブレット モードでは、常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-122">Always present in Tablet mode.</span></span> <span data-ttu-id="4a5c4-123">デスクトップ モードでは利用できません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-123">Not available in Desktop mode.</span></span> <span data-ttu-id="4a5c4-124">代わりに、タイトル バーの戻るボタンを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-124">Title bar back button can be enabled, instead.</span></span> <span data-ttu-id="4a5c4-125">「[PC、ノート PC、タブレット](#PC)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-125">See [PC, Laptop, Tablet](#PC).</span></span>
<span data-ttu-id="4a5c4-126">ユーザーは、**[設定]、[システム]、[タブレット モード]** の順に選択し、**[デバイスをタブレットとして使用すると、Windows のタッチ機能がより使いやすくなります]** をオンまたはオフにすることによって、タブレット モードでの実行とデスクトップ モードでの実行を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-126">Users can switch between running in Tablet mode and Desktop mode by going to **Settings &gt; System &gt; Tablet mode** and setting **Make Windows more touch-friendly when using your device as a tablet**.</span></span></li>
<li> <span data-ttu-id="4a5c4-127">デバイスの下部のナビゲーション バーにあるソフトウェア ボタン。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-127">A software button in the navigation bar at the bottom of the device.</span></span></li>
<li><span data-ttu-id="4a5c4-128">アプリ内部やアプリ間で、グローバルな戻るナビゲーションを実現します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-128">Global back navigation within the app and between apps.</span></span></li></ul>        
        </td>
     </tr>
    <tr>
        <td style="vertical-align:top;"><span data-ttu-id="4a5c4-129">PC、ノート PC、タブレット</span><span class="sxs-lookup"><span data-stu-id="4a5c4-129">PC, Laptop, Tablet</span></span></td>
        <td style="vertical-align:top;">![PC やノート PC でのシステムの戻るボタン](images/back-systemback-pc.png)</td>
        <td style="vertical-align:top;">
<ul>
<li><span data-ttu-id="4a5c4-131">デスクトップ モードではオプションです。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-131">Optional in Desktop mode.</span></span> <span data-ttu-id="4a5c4-132">タブレット モードでは利用できません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-132">Not available in Tablet mode.</span></span> <span data-ttu-id="4a5c4-133">「[タブレット](#Tablet)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-133">See [Tablet](#Tablet).</span></span> <span data-ttu-id="4a5c4-134">既定では無効になっています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-134">Disabled by default.</span></span> <span data-ttu-id="4a5c4-135">有効にすることをオプトインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-135">Must opt in to enable it.</span></span>
<span data-ttu-id="4a5c4-136">ユーザーは、**[設定]、[システム]、[タブレット モード]** の順に選択し、**[デバイスをタブレットとして使用すると、Windows のタッチ機能がより使いやすくなります]** をオンまたはオフにすることによって、タブレット モードでの実行とデスクトップ モードでの実行を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-136">Users can switch between running in Tablet mode and Desktop mode by going to **Settings &gt; System &gt; Tablet mode** and setting **Make Windows more touch-friendly when using your device as a tablet**.</span></span></li>
<li><span data-ttu-id="4a5c4-137">アプリのタイトル バーにあるソフトウェア ボタン。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-137">A software button in the title bar of the app.</span></span></li>
<li><span data-ttu-id="4a5c4-138">アプリ内部のみでの戻るナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-138">Back navigation within the app only.</span></span> <span data-ttu-id="4a5c4-139">アプリ間のナビゲーションはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-139">Does not support app-to-app navigation.</span></span></li></ul>        
        </td>
     </tr>
    <tr>
        <td style="vertical-align:top;"><span data-ttu-id="4a5c4-140">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="4a5c4-140">Surface Hub</span></span></td>
        <td style="vertical-align:top;">![Surface Hub でのシステムの戻るボタン](images/nav/nav-back-surfacehub.png)</td>
        <td style="vertical-align:top;">
<ul>
<li><span data-ttu-id="4a5c4-142">省略可能。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-142">Optional.</span></span></li>
<li><span data-ttu-id="4a5c4-143">既定では無効になっています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-143">Disabled by default.</span></span> <span data-ttu-id="4a5c4-144">有効にすることをオプトインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-144">Must opt in to enable it.</span></span></li>
<li><span data-ttu-id="4a5c4-145">アプリのタイトル バーにあるソフトウェア ボタン。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-145">A software button in the title bar of the app.</span></span></li>
<li><span data-ttu-id="4a5c4-146">アプリ内部のみでの戻るナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-146">Back navigation within the app only.</span></span> <span data-ttu-id="4a5c4-147">アプリ間のナビゲーションはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-147">Does not support app-to-app navigation.</span></span></li></ul>        
        </td>
     </tr>     
<table>


<span data-ttu-id="4a5c4-148">ここでは、戻るボタンの UI に依存しないが、まったく同じ機能を提供する代替入力の種類をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-148">Here are some alternative input types that don't rely on a back button UI, but still provide the exact same functionality.</span></span>


<table>
<tr><td colspan="3"><span data-ttu-id="4a5c4-149">入力デバイス</span><span class="sxs-lookup"><span data-stu-id="4a5c4-149">Input devices</span></span></td></tr>
<tr><td style="vertical-align:top;"><span data-ttu-id="4a5c4-150">キーボード</span><span class="sxs-lookup"><span data-stu-id="4a5c4-150">Keyboard</span></span></td><td style="vertical-align:top;">![キーボード](images/keyboard-wireframe.png)</td><td style="vertical-align:top;"><span data-ttu-id="4a5c4-152">Windows キー + BackSpace</span><span class="sxs-lookup"><span data-stu-id="4a5c4-152">Windows key + Backspace</span></span></td></tr>
<tr><td style="vertical-align:top;"><span data-ttu-id="4a5c4-153">Cortana</span><span class="sxs-lookup"><span data-stu-id="4a5c4-153">Cortana</span></span></td><td style="vertical-align:top;">![音声認識](images/speech-wireframe.png)</td><td style="vertical-align:top;"><span data-ttu-id="4a5c4-155">「コルタナさん、戻る」と話す。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-155">Say, "Hey Cortana, go back"</span></span></td></tr>
</table>
 

<span data-ttu-id="4a5c4-156">アプリが電話、タブレット、PC、ノート PC で実行され、システムの戻るボタンが有効になっていると、戻るボタンが押されたときに、システムからアプリに通知されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-156">When your app runs on a phone, tablet, or on a PC or laptop that has system back enabled, the system notifies your app when the back button is pressed.</span></span> <span data-ttu-id="4a5c4-157">ユーザーは、戻るボタンによって、アプリのナビゲーション履歴における前の場所に戻ることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-157">The user expects the back button to navigate to the previous location in the app's navigation history.</span></span> <span data-ttu-id="4a5c4-158">ナビゲーション履歴に追加するナビゲーション操作の種類、および戻るボタンが押されたときの応答方法は、自由に決めることができます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-158">It's up to you to decide which navigation actions to add to the navigation history and how to respond to the back button press.</span></span>


## <a name="how-to-enable-system-back-navigation-support"></a><span data-ttu-id="4a5c4-159">システムの "戻る" ナビゲーションのサポートを有効にする方法</span><span class="sxs-lookup"><span data-stu-id="4a5c4-159">How to enable system back navigation support</span></span>


<span data-ttu-id="4a5c4-160">アプリは、すべてのハードウェアとソフトウェアによるシステムの戻るボタンの "戻る" ナビゲーションを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-160">Apps must enable back navigation for all hardware and software system back buttons.</span></span> <span data-ttu-id="4a5c4-161">これを行うには、[**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベントのリスナーを登録し、対応するハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-161">Do this by registering a listener for the [**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) event and defining a corresponding handler.</span></span>

<span data-ttu-id="4a5c4-162">ここでは、App.xaml 分離コード ファイルで、[**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベントのグローバル リスナーを登録しています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-162">Here we register a global listener for the [**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) event in the App.xaml code-behind file.</span></span> <span data-ttu-id="4a5c4-163">"戻る" ナビゲーションから特定のページを除外する場合や、ページを表示する前にページ レベルのコードを実行する場合は、各ページでこのイベントについて登録できます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-163">You can register for this event in each page if you want to exclude specific pages from back navigation, or you want to execute page-level code before displaying the page.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += 
    App_BackRequested;
```
```cpp
Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->
    BackRequested += ref new Windows::Foundation::EventHandler<
    Windows::UI::Core::BackRequestedEventArgs^>(
        this, &App::App_BackRequested);
```

<span data-ttu-id="4a5c4-164">対応する [**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベント ハンドラーを以下に示します。このイベント ハンドラーは、アプリのルート フレームで [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-164">Here's the corresponding [**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) event handler that calls [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568) on the root frame of the app.</span></span>

<span data-ttu-id="4a5c4-165">このハンドラーは、グローバルな戻るイベントで呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-165">This handler is invoked on a global back event.</span></span> <span data-ttu-id="4a5c4-166">アプリ内のバック スタックが空である場合、システムはアプリ スタック内の前のアプリまたはスタート画面にナビゲートする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-166">If the in-app back stack is empty, the system might navigate to the previous app in the app stack or to the Start screen.</span></span> <span data-ttu-id="4a5c4-167">デスクトップ モードにはアプリのバック スタックはなく、アプリ内のバック スタックが使い果たされている場合でも、ユーザーはアプリ内に留まります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-167">There is no app back stack in Desktop mode and the user stays in the app even when the in-app back stack is depleted.</span></span>

> [!div class="tabbedCodeSnippets"]
```csharp
>private void App_BackRequested(object sender, 
>    Windows.UI.Core.BackRequestedEventArgs e)
>{
>    Frame rootFrame = Window.Current.Content as Frame;
>    if (rootFrame == null)
>        return;
>
>    // Navigate back if possible, and if the event has not 
>    // already been handled .
>    if (rootFrame.CanGoBack && e.Handled == false)
>    {
>        e.Handled = true;
>        rootFrame.GoBack();
>    }
>}
```
```cpp
>void App::App_BackRequested(
>    Platform::Object^ sender, 
>    Windows::UI::Core::BackRequestedEventArgs^ e)
>{
>    Frame^ rootFrame = dynamic_cast<Frame^>(Window::Current->Content);
>    if (rootFrame == nullptr)
>        return;
>
>    // Navigate back if possible, and if the event has not
>    // already been handled.
>    if (rootFrame->CanGoBack && e->Handled == false)
>    {
>        e->Handled = true;
>        rootFrame->GoBack();
>    }
>}
```

## <a name="how-to-enable-the-title-bar-back-button"></a><span data-ttu-id="4a5c4-168">タイトル バーの戻るボタンを有効にする方法</span><span class="sxs-lookup"><span data-stu-id="4a5c4-168">How to enable the title bar back button</span></span>


<span data-ttu-id="4a5c4-169">デスクトップ モードをサポートするデバイス (通常は PC とノート PC、一部のタブレットも含む) で、設定を有効にしている (**[設定]、[システム]、[タブレット モード]** の順に選択) 場合、システムの戻るボタンを備えたグローバルなナビゲーションバーは提供されません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-169">Devices that support Desktop mode (typically PCs and laptops, but also some tablets) and have the setting enabled (**Settings &gt; System &gt; Tablet mode**), do not provide a global navigation bar with the system back button.</span></span>

<span data-ttu-id="4a5c4-170">デスクトップ モードでは、すべてのアプリは、タイトル バーのあるウィンドウで実行されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-170">In Desktop mode, every app runs in a window with a title bar.</span></span> <span data-ttu-id="4a5c4-171">このタイトル バーに表示される、代わりの戻るボタンをアプリに提供できます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-171">You can provide an alternative back button for your app that is displayed in this title bar.</span></span>

<span data-ttu-id="4a5c4-172">タイトル バーの戻るボタンは、デスクトップ モードのデバイスで実行されているアプリでのみ利用でき、アプリ内のナビゲーション履歴のみをサポートします。アプリ間のナビゲーション履歴はサポートされません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-172">The title bar back button is only available in apps running on devices in Desktop mode, and only supports in-app navigation history—it does not support app-to-app navigation history.</span></span>

<span data-ttu-id="4a5c4-173">**重要**  タイトル バーの戻るボタンは、既定では表示されません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-173">**Important**  The title bar back button is not displayed by default.</span></span> <span data-ttu-id="4a5c4-174">オプトインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-174">You must opt in.</span></span>

 

|                                                             |                                                        |
|-------------------------------------------------------------|--------------------------------------------------------|
| ![デスクトップ モードでシステムの戻るボタンがない場合](images/nav-noback-pc.png) | ![デスクトップ モードでのシステムの戻るボタン](images/nav-back-pc.png) |
| <span data-ttu-id="4a5c4-177">デスクトップ モード、"戻る" ナビゲーションがない場合</span><span class="sxs-lookup"><span data-stu-id="4a5c4-177">Desktop mode, no back navigation.</span></span>                           | <span data-ttu-id="4a5c4-178">デスクトップ モード、"戻る" ナビゲーションが有効な場合</span><span class="sxs-lookup"><span data-stu-id="4a5c4-178">Desktop mode, back navigation enabled.</span></span>                 |

 

<span data-ttu-id="4a5c4-179">タイトル バーの戻るボタンを有効にする各ページの分離コード ファイルで、[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) イベントをオーバーライドして [**AppViewBackButtonVisibility**](https://msdn.microsoft.com/library/windows/apps/dn986448) を [**Visible**](https://msdn.microsoft.com/library/windows/apps/dn986276) に設定します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-179">Override the [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) event and set [**AppViewBackButtonVisibility**](https://msdn.microsoft.com/library/windows/apps/dn986448) to [**Visible**](https://msdn.microsoft.com/library/windows/apps/dn986276) in the code-behind file for each page that you want to enable the title bar back button.</span></span>

<span data-ttu-id="4a5c4-180">この例では、フレームの [**CanGoBack**](https://msdn.microsoft.com/library/windows/apps/br242685) プロパティの値が **true** である場合に、バック スタック内の各ページの一覧を表示し、戻るボタンを有効にします。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-180">For this example, we list each page in the back stack and enable the back button if the [**CanGoBack**](https://msdn.microsoft.com/library/windows/apps/br242685) property of the frame has a value of **true**.</span></span>

> [!div class="tabbedCodeSnippets"]
>```csharp
>protected override void OnNavigatedTo(NavigationEventArgs e)
>{
>    Frame rootFrame = Window.Current.Content as Frame;
>
>    string myPages = "";
>    foreach (PageStackEntry page in rootFrame.BackStack)
>    {
>        myPages += page.SourcePageType.ToString() + "\n";
>    }
>    stackCount.Text = myPages;
>
>    if (rootFrame.CanGoBack)
>    {
>        // Show UI in title bar if opted-in and in-app backstack is not empty.
>        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
>            AppViewBackButtonVisibility.Visible;
>    }
>    else
>    {
>        // Remove the UI from the title bar if in-app back stack is empty.
>        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
>            AppViewBackButtonVisibility.Collapsed;
>    }
>}
>```
>```cpp
>void StartPage::OnNavigatedTo(NavigationEventArgs^ e)
>{
>    auto rootFrame = dynamic_cast<Windows::UI::Xaml::Controls::Frame^>(Window::Current->Content);
>
>    Platform::String^ myPages = "";
>
>    if (rootFrame == nullptr)
>        return;
>
>    for each (PageStackEntry^ page in rootFrame->BackStack)
>    {
>        myPages += page->SourcePageType.ToString() + "\n";
>    }
>    stackCount->Text = myPages;
>
>    if (rootFrame->CanGoBack)
>    {
>        // If we have pages in our in-app backstack and have opted in to showing back, do so
>        Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->AppViewBackButtonVisibility =
>            Windows::UI::Core::AppViewBackButtonVisibility::Visible;
>    }
>    else
>    {
>        // Remove the UI from the title bar if there are no pages in our in-app back stack
>        Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->AppViewBackButtonVisibility =
>            Windows::UI::Core::AppViewBackButtonVisibility::Collapsed;
>    }
>}
>```


### <a name="guidelines-for-custom-back-navigation-behavior"></a><span data-ttu-id="4a5c4-181">カスタムの "戻る" ナビゲーションの動作のガイドライン</span><span class="sxs-lookup"><span data-stu-id="4a5c4-181">Guidelines for custom back navigation behavior</span></span>

<span data-ttu-id="4a5c4-182">独自のバック スタック ナビゲーションを提供する場合、エクスペリエンスが他のアプリと一貫している必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-182">If you choose to provide your own back stack navigation, the experience should be consistent with other apps.</span></span> <span data-ttu-id="4a5c4-183">ナビゲーション操作では、次のパターンに従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-183">We recommend that you follow the following patterns for navigation actions:</span></span>

<table>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="4a5c4-184">ナビゲーション操作</span><span class="sxs-lookup"><span data-stu-id="4a5c4-184">Navigation action</span></span></th>
<th align="left"><span data-ttu-id="4a5c4-185">ナビゲーション履歴への追加</span><span class="sxs-lookup"><span data-stu-id="4a5c4-185">Add to navigation history?</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-186">ページ間、異なるピア グループ</span><span class="sxs-lookup"><span data-stu-id="4a5c4-186">Page to page, different peer groups</span></span></strong></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-187">○</span><span class="sxs-lookup"><span data-stu-id="4a5c4-187">Yes</span></span></strong>
<p><span data-ttu-id="4a5c4-188">この図では、ユーザーはピア グループを横断して、アプリのレベル 1 からレベル 2 に移動します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-188">In this illustration, the user navigates from level 1 of the app to level 2, crossing peer groups, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/nav/nav-pagetopage-diffpeers-imageonly1.png" alt="Navigation across peer groups" /></p>
<p><span data-ttu-id="4a5c4-189">次の図では、ユーザーは同じレベルにある 2 つのピア グループの間を移動し、この場合もピア グループを横断します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-189">In the next illustration, the user navigates between two peer groups at the same level, again crossing peer groups, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/nav/nav-pagetopage-diffpeers-imageonly2.png" alt="Navigation across peer groups" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-190">ページ間、同じピア グループ、ナビゲーション要素は画面上に表示されない</span><span class="sxs-lookup"><span data-stu-id="4a5c4-190">Page to page, same peer group, no on-screen navigation element</span></span></strong>
<p><span data-ttu-id="4a5c4-191">ユーザーは、同じピア グループでページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-191">The user navigates from one page to another with the same peer group.</span></span> <span data-ttu-id="4a5c4-192">両方のページを対象とした直接的なナビゲーションを実現するナビゲーション要素 (タブ/ピボットや、ドッキングされたナビゲーション ウィンドウなど) は画面に表示されません。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-192">There is no navigation element that is always present (such as tabs/pivots or a docked navigation pane) that provides direct navigation to both pages.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-193">○</span><span class="sxs-lookup"><span data-stu-id="4a5c4-193">Yes</span></span></strong>
<p><span data-ttu-id="4a5c4-194">次の図では、ユーザーは同じピア グループ内の 2 つのページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-194">In the following illustration, the user navigates between two pages in the same peer group.</span></span> <span data-ttu-id="4a5c4-195">ページでは、タブやドッキングされたナビゲーション ウィンドウは使われていません。そのため、このナビゲーションはナビゲーション履歴に追加されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-195">The pages don't use tabs or a docked navigation pane, so the navigation is added to the navigation history.</span></span></p>
<p><img src="images/nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-196">ページ間、同じピア グループ、画面上に表示されるナビゲーション要素を使う</span><span class="sxs-lookup"><span data-stu-id="4a5c4-196">Page to page, same peer group, with an on-screen navigation element</span></span></strong>
<p><span data-ttu-id="4a5c4-197">ユーザーは、同じピア グループ内のページ間を移動します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-197">The user navigates from one page to another in the same peer group.</span></span> <span data-ttu-id="4a5c4-198">両方のページは同じナビゲーション要素に表示されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-198">Both pages are shown in the same navigation element.</span></span> <span data-ttu-id="4a5c4-199">たとえば、両方のページで同じタブ/ピボット要素を使っていたり、両方のページがドッキングされたナビゲーション ウィンドウに表示されるとします。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-199">For example, both pages use the same tabs/pivots element, or both pages appear in a docked navigation pane.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-200">×</span><span class="sxs-lookup"><span data-stu-id="4a5c4-200">No</span></span></strong>
<p><span data-ttu-id="4a5c4-201">ユーザーが戻るボタンを押すと、現在のピア グループに移動する前に表示していた最後のページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-201">When the user presses back, go back to the last page before the user navigated to the current peer group.</span></span></p>
<p><img src="images/nav/nav-pagetopage-samepeer-yesosnavelement.png" alt="Navigation across peer groups when a navigation element is present" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-202">一時的な UI の表示</span><span class="sxs-lookup"><span data-stu-id="4a5c4-202">Show a transient UI</span></span></strong>
<p><span data-ttu-id="4a5c4-203">アプリは、ダイアログ、スプラッシュ画面、スクリーン キーボードなどのポップアップ ウィンドウや子ウィンドウを表示します。または、アプリが複数選択モードなどの特別なモードに移行します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-203">The app displays a pop-up or child window, such as a dialog, splash screen, or on-screen keyboard, or the app enters a special mode, such as multiple selection mode.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-204">×</span><span class="sxs-lookup"><span data-stu-id="4a5c4-204">No</span></span></strong>
<p><span data-ttu-id="4a5c4-205">ユーザーが戻るボタンを押すと、一時的な UI が閉じられ (スクリーン キーボードが非表示になる、ダイアログがキャンセルされるなど)、一時的な UI を生成したページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-205">When the user presses the back button, dismiss the transient UI (hide the on-screen keyboard, cancel the dialog, etc) and return to the page that spawned the transient UI.</span></span></p>
<p><img src="images/back-transui.png" alt="Showing a transient UI" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-206">項目の列挙</span><span class="sxs-lookup"><span data-stu-id="4a5c4-206">Enumerate items</span></span></strong>
<p><span data-ttu-id="4a5c4-207">アプリが、マスター/詳細リストで選んだ項目の詳細など、画面上の項目のコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-207">The app displays content for an on-screen item, such as the details for the selected item in master/details list.</span></span></p></td>
<td style="vertical-align:top;"><strong><span data-ttu-id="4a5c4-208">×</span><span class="sxs-lookup"><span data-stu-id="4a5c4-208">No</span></span></strong>
<p><span data-ttu-id="4a5c4-209">項目の列挙は、ピア グループ内の移動に似ています。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-209">Enumerating items is similar to navigating within a peer group.</span></span> <span data-ttu-id="4a5c4-210">ユーザーが戻るボタンを押すと、項目の列挙が表示されている現在のページの前のページに移動されます。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-210">When the user presses back, navigate to the page that preceded the current page that has the item enumeration.</span></span></p>
<img src="images/nav/nav-enumerate.png" alt="Iterm enumeration" /></td>
</tr>
</tbody>
</table>


### <a name="resuming"></a><span data-ttu-id="4a5c4-211">再開</span><span class="sxs-lookup"><span data-stu-id="4a5c4-211">Resuming</span></span>

<span data-ttu-id="4a5c4-212">ユーザーが別のアプリに切り替えた後で、元のアプリに戻った場合は、ナビゲーション履歴にある最後のページに戻すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-212">When the user switches to another app and returns to your app, we recommend returning to the last page in the navigation history.</span></span>


## <a name="get-the-samples"></a><span data-ttu-id="4a5c4-213">サンプルの入手</span><span class="sxs-lookup"><span data-stu-id="4a5c4-213">Get the samples</span></span>
*   [<span data-ttu-id="4a5c4-214">戻るボタンのサンプル</span><span class="sxs-lookup"><span data-stu-id="4a5c4-214">Back button sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackButton)<br/>
    <span data-ttu-id="4a5c4-215">戻るボタンのイベントのイベント ハンドラーを設定する方法、およびアプリがウィンドウ表示されたデスクトップ モードのときにタイトル バーの戻るボタンを有効にする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4a5c4-215">Shows how to set up an event handler for the back button event and how to enable the title bar back button for when the app is in windowed Desktop mode.</span></span>

## <a name="related-articles"></a><span data-ttu-id="4a5c4-216">関連記事</span><span class="sxs-lookup"><span data-stu-id="4a5c4-216">Related articles</span></span>
* [<span data-ttu-id="4a5c4-217">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="4a5c4-217">Navigation basics</span></span>](navigation-basics.md)

 




