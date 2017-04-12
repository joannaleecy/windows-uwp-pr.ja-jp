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
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: c2037c4b313b45309162ea4c0874418fe9463d17
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
#  <a name="navigation-history-and-backwards-navigation-for-uwp-apps"></a>UWP アプリのナビゲーション履歴と前に戻る移動

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

Web の場合、個々の Web サイトには独自のナビゲーション システム (目次、ボタン、メニュー、リンクの簡単な一覧など) が用意されています。 ナビゲーション エクスペリエンスは、Web サイトによっては大幅に異なる場合があります。 ただし、一貫して同じナビゲーション エクスペリエンスが 1 つあります。それは "戻る" 操作です。 ほとんどのブラウザーには、Web サイトに関係なく同じように動作する戻るボタンがあります。

同様の理由から、ユニバーサル Windows プラットフォーム (UWP) では、アプリのユーザーのナビゲーションの履歴内の移動や、デバイスによってはアプリ間の移動について、一貫性のある "戻る" ナビゲーション システムを提供します。

システムの戻るボタンの UI は、フォーム ファクターや入力デバイスの種類ごとに最適化されますが、ナビゲーション エクスペリエンスはグローバルであり、デバイスや UWP アプリで一貫しています。

主なフォーム ファクターでの戻るボタン UI を次に示します。


<table>
    <tr>
        <td colspan="2">デバイス</td>
        <td style="vertical-align:top;">戻るボタンの動作</td>
     </tr>
    <tr>
        <td style="vertical-align:top;">電話</td>
        <td style="vertical-align:top;">![電話でのシステムの戻るボタン](images/back-systemback-phone.png)</td>
        <td style="vertical-align:top;">
        <ul>
<li>常に表示されます。</li>
<li>デバイスの下部にあるソフトウェアまたはハードウェア ボタン。</li>
<li>アプリ内部やアプリ間で、グローバルな戻るナビゲーションを実現します。</li>
</ul>
</td>
     </tr>
     <tr>
        <td style="vertical-align:top;">タブレット</td>
        <td style="vertical-align:top;">![タブレットでのシステムの戻るボタン (タブレット モード)](images/back-systemback-tablet.png)</td>
        <td style="vertical-align:top;">
<ul>
<li>タブレット モードでは、常に表示されます。 デスクトップ モードでは利用できません。 代わりに、タイトル バーの戻るボタンを有効にすることができます。 「[PC、ノート PC、タブレット](#PC)」をご覧ください。
ユーザーは、**[設定]、[システム]、[タブレット モード]** の順に選択し、**[デバイスをタブレットとして使用すると、Windows のタッチ機能がより使いやすくなります]** をオンまたはオフにすることによって、タブレット モードでの実行とデスクトップ モードでの実行を切り替えることができます。</li>
<li> デバイスの下部のナビゲーション バーにあるソフトウェア ボタン。</li>
<li>アプリ内部やアプリ間で、グローバルな戻るナビゲーションを実現します。</li></ul>        
        </td>
     </tr>
    <tr>
        <td style="vertical-align:top;">PC、ノート PC、タブレット</td>
        <td style="vertical-align:top;">![PC やノート PC でのシステムの戻るボタン](images/back-systemback-pc.png)</td>
        <td style="vertical-align:top;">
<ul>
<li>デスクトップ モードではオプションです。 タブレット モードでは利用できません。 「[タブレット](#Tablet)」をご覧ください。 既定では無効になっています。 有効にすることをオプトインする必要があります。
ユーザーは、**[設定]、[システム]、[タブレット モード]** の順に選択し、**[デバイスをタブレットとして使用すると、Windows のタッチ機能がより使いやすくなります]** をオンまたはオフにすることによって、タブレット モードでの実行とデスクトップ モードでの実行を切り替えることができます。</li>
<li>アプリのタイトル バーにあるソフトウェア ボタン。</li>
<li>アプリ内部のみでの戻るナビゲーション。 アプリ間のナビゲーションはサポートされません。</li></ul>        
        </td>
     </tr>
    <tr>
        <td style="vertical-align:top;">Surface Hub</td>
        <td style="vertical-align:top;">![Surface Hub でのシステムの戻るボタン](images/nav/nav-back-surfacehub.png)</td>
        <td style="vertical-align:top;">
<ul>
<li>省略可能。</li>
<li>既定では無効になっています。 有効にすることをオプトインする必要があります。</li>
<li>アプリのタイトル バーにあるソフトウェア ボタン。</li>
<li>アプリ内部のみでの戻るナビゲーション。 アプリ間のナビゲーションはサポートされません。</li></ul>        
        </td>
     </tr>     
<table>


ここでは、戻るボタンの UI に依存しないが、まったく同じ機能を提供する代替入力の種類をいくつか示します。


<table>
<tr><td colspan="3">入力デバイス</td></tr>
<tr><td style="vertical-align:top;">キーボード</td><td style="vertical-align:top;">![キーボード](images/keyboard-wireframe.png)</td><td style="vertical-align:top;">Windows キー + BackSpace</td></tr>
<tr><td style="vertical-align:top;">Cortana</td><td style="vertical-align:top;">![音声認識](images/speech-wireframe.png)</td><td style="vertical-align:top;">「コルタナさん、戻る」と話す。</td></tr>
</table>
 

アプリが電話、タブレット、PC、ノート PC で実行され、システムの戻るボタンが有効になっていると、戻るボタンが押されたときに、システムからアプリに通知されます。 ユーザーは、戻るボタンによって、アプリのナビゲーション履歴における前の場所に戻ることを想定しています。 ナビゲーション履歴に追加するナビゲーション操作の種類、および戻るボタンが押されたときの応答方法は、自由に決めることができます。


## <a name="how-to-enable-system-back-navigation-support"></a>システムの "戻る" ナビゲーションのサポートを有効にする方法


アプリは、すべてのハードウェアとソフトウェアによるシステムの戻るボタンの "戻る" ナビゲーションを有効にする必要があります。 これを行うには、[**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベントのリスナーを登録し、対応するハンドラーを定義します。

ここでは、App.xaml 分離コード ファイルで、[**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベントのグローバル リスナーを登録しています。 "戻る" ナビゲーションから特定のページを除外する場合や、ページを表示する前にページ レベルのコードを実行する場合は、各ページでこのイベントについて登録できます。

> [!div class="tabbedCodeSnippets"]
```csharp
Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += 
    App_BackRequested;
```
```cpp
Windows::UI::Core::SystemNavigationManager::GetForCurrentView()->
    BackRequested += ref new Windows::Foundation::EventHandler<
    Windows::UI::Core::BackRequestedEventArgs^>(
        this, &amp;App::App_BackRequested);
```

対応する [**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベント ハンドラーを以下に示します。このイベント ハンドラーは、アプリのルート フレームで [**GoBack**](https://msdn.microsoft.com/library/windows/apps/dn996568) を呼び出します。

このハンドラーは、グローバルな戻るイベントで呼び出されます。 アプリ内のバック スタックが空である場合、システムはアプリ スタック内の前のアプリまたはスタート画面にナビゲートする可能性があります。 デスクトップ モードにはアプリのバック スタックはなく、アプリ内のバック スタックが使い果たされている場合でも、ユーザーはアプリ内に留まります。

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
>    if (rootFrame.CanGoBack &amp;&amp; e.Handled == false)
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

## <a name="how-to-enable-the-title-bar-back-button"></a>タイトル バーの戻るボタンを有効にする方法


デスクトップ モードをサポートするデバイス (通常は PC とノート PC、一部のタブレットも含む) で、設定を有効にしている (**[設定]、[システム]、[タブレット モード]** の順に選択) 場合、システムの戻るボタンを備えたグローバルなナビゲーションバーは提供されません。

デスクトップ モードでは、すべてのアプリは、タイトル バーのあるウィンドウで実行されます。 このタイトル バーに表示される、代わりの戻るボタンをアプリに提供できます。

タイトル バーの戻るボタンは、デスクトップ モードのデバイスで実行されているアプリでのみ利用でき、アプリ内のナビゲーション履歴のみをサポートします。アプリ間のナビゲーション履歴はサポートされません。

**重要**  タイトル バーの戻るボタンは、既定では表示されません。 オプトインする必要があります。

 

|                                                             |                                                        |
|-------------------------------------------------------------|--------------------------------------------------------|
| ![デスクトップ モードでシステムの戻るボタンがない場合](images/nav-noback-pc.png) | ![デスクトップ モードでのシステムの戻るボタン](images/nav-back-pc.png) |
| デスクトップ モード、"戻る" ナビゲーションがない場合                           | デスクトップ モード、"戻る" ナビゲーションが有効な場合                 |

 

タイトル バーの戻るボタンを有効にする各ページの分離コード ファイルで、[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) イベントをオーバーライドして [**AppViewBackButtonVisibility**](https://msdn.microsoft.com/library/windows/apps/dn986448) を [**Visible**](https://msdn.microsoft.com/library/windows/apps/dn986276) に設定します。

この例では、フレームの [**CanGoBack**](https://msdn.microsoft.com/library/windows/apps/br242685) プロパティの値が **true** である場合に、バック スタック内の各ページの一覧を表示し、戻るボタンを有効にします。

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


### <a name="guidelines-for-custom-back-navigation-behavior"></a>カスタムの "戻る" ナビゲーションの動作のガイドライン

独自のバック スタック ナビゲーションを提供する場合、エクスペリエンスが他のアプリと一貫している必要があります。 ナビゲーション操作では、次のパターンに従うことをお勧めします。

<table>
<thead>
<tr class="header">
<th align="left">ナビゲーション操作</th>
<th align="left">ナビゲーション履歴への追加</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td style="vertical-align:top;"><strong>ページ間、異なるピア グループ</strong></td>
<td style="vertical-align:top;"><strong>○</strong>
<p>この図では、ユーザーはピア グループを横断して、アプリのレベル 1 からレベル 2 に移動します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</p>
<p><img src="images/nav/nav-pagetopage-diffpeers-imageonly1.png" alt="Navigation across peer groups" /></p>
<p>次の図では、ユーザーは同じレベルにある 2 つのピア グループの間を移動し、この場合もピア グループを横断します。そのため、このナビゲーションはナビゲーション履歴に追加されます。</p>
<p><img src="images/nav/nav-pagetopage-diffpeers-imageonly2.png" alt="Navigation across peer groups" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong>ページ間、同じピア グループ、ナビゲーション要素は画面上に表示されない</strong>
<p>ユーザーは、同じピア グループでページ間を移動します。 両方のページを対象とした直接的なナビゲーションを実現するナビゲーション要素 (タブ/ピボットや、ドッキングされたナビゲーション ウィンドウなど) は画面に表示されません。</p></td>
<td style="vertical-align:top;"><strong>○</strong>
<p>次の図では、ユーザーは同じピア グループ内の 2 つのページ間を移動します。 ページでは、タブやドッキングされたナビゲーション ウィンドウは使われていません。そのため、このナビゲーションはナビゲーション履歴に追加されます。</p>
<p><img src="images/nav/nav-pagetopage-samepeer-noosnavelement.png" alt="Navigation within a peer group" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong>ページ間、同じピア グループ、画面上に表示されるナビゲーション要素を使う</strong>
<p>ユーザーは、同じピア グループ内のページ間を移動します。 両方のページは同じナビゲーション要素に表示されます。 たとえば、両方のページで同じタブ/ピボット要素を使っていたり、両方のページがドッキングされたナビゲーション ウィンドウに表示されるとします。</p></td>
<td style="vertical-align:top;"><strong>×</strong>
<p>ユーザーが戻るボタンを押すと、現在のピア グループに移動する前に表示していた最後のページに戻ります。</p>
<p><img src="images/nav/nav-pagetopage-samepeer-yesosnavelement.png" alt="Navigation across peer groups when a navigation element is present" /></p></td>
</tr>
<tr class="even">
<td style="vertical-align:top;"><strong>一時的な UI の表示</strong>
<p>アプリは、ダイアログ、スプラッシュ画面、スクリーン キーボードなどのポップアップ ウィンドウや子ウィンドウを表示します。または、アプリが複数選択モードなどの特別なモードに移行します。</p></td>
<td style="vertical-align:top;"><strong>×</strong>
<p>ユーザーが戻るボタンを押すと、一時的な UI が閉じられ (スクリーン キーボードが非表示になる、ダイアログがキャンセルされるなど)、一時的な UI を生成したページに戻ります。</p>
<p><img src="images/back-transui.png" alt="Showing a transient UI" /></p></td>
</tr>
<tr class="odd">
<td style="vertical-align:top;"><strong>項目の列挙</strong>
<p>アプリが、マスター/詳細リストで選んだ項目の詳細など、画面上の項目のコンテンツを表示します。</p></td>
<td style="vertical-align:top;"><strong>×</strong>
<p>項目の列挙は、ピア グループ内の移動に似ています。 ユーザーが戻るボタンを押すと、項目の列挙が表示されている現在のページの前のページに移動されます。</p>
<img src="images/nav/nav-enumerate.png" alt="Iterm enumeration" /></td>
</tr>
</tbody>
</table>


### <a name="resuming"></a>再開

ユーザーが別のアプリに切り替えた後で、元のアプリに戻った場合は、ナビゲーション履歴にある最後のページに戻すことをお勧めします。


## <a name="get-the-samples"></a>サンプルの入手
*   [戻るボタンのサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/BackButton)<br/>
    戻るボタンのイベントのイベント ハンドラーを設定する方法、およびアプリがウィンドウ表示されたデスクトップ モードのときにタイトル バーの戻るボタンを有効にする方法を示します。

## <a name="related-articles"></a>関連記事
* [ナビゲーションの基本](navigation-basics.md)

 




