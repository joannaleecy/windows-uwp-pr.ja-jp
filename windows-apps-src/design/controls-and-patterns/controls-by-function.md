---
author: Jwmsft
Description: Provides a list by function of some of the controls that you can use in your apps.
title: 機能別コントロール
ms.assetid: 8DB4347B-91D6-4659-91F2-80ECF7BBB596
label: Controls by function
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0840bab2e039ec55ea4070f8dad39c0ae4e74bbc
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4091290"
---
# <a name="controls-by-function"></a><span data-ttu-id="760c0-103">機能別コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-103">Controls by function</span></span>

<span data-ttu-id="760c0-104">Windows の XAML UI フレームワークには、UI 開発をサポートする多くのコントロールのライブラリが用意されています。</span><span class="sxs-lookup"><span data-stu-id="760c0-104">The XAML UI framework for Windows provides an extensive library of controls that support UI development.</span></span> <span data-ttu-id="760c0-105">これらのコントロールの一部は視覚的に表示されますが、それ以外のコントロールは他のコントロールまたはコンテンツ (画像やメディアなど) のコンテナーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="760c0-105">Some of these controls have a visual representation; others function as the containers for other controls or content, such as images and media.</span></span> 

<span data-ttu-id="760c0-106">[XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992)をダウンロードすると、Windows UI コントロールの多くを実際に見ることができます。</span><span class="sxs-lookup"><span data-stu-id="760c0-106">You can see many of the Windows UI controls in action by downloading the [XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?LinkId=619992).</span></span>

<table>
<th align="left"><span data-ttu-id="760c0-107">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="760c0-107">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="760c0-108"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされている場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">、アプリを開き NavigationView の動作をご覧ください。</a></span><span class="sxs-lookup"><span data-stu-id="760c0-108">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/NavigationView">open the app and see the NavigationView in action</a></span></span> </p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="760c0-109">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="760c0-109">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="760c0-110">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="760c0-110">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>


<span data-ttu-id="760c0-111">アプリで使うことができる一般的な XAML コントロールの機能別の一覧を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="760c0-111">Here's a list by function of the common XAML controls you can use in your app.</span></span>

## <a name="appbars-and-commands"></a><span data-ttu-id="760c0-112">アプリ バーとコマンド</span><span class="sxs-lookup"><span data-stu-id="760c0-112">Appbars and commands</span></span>

### <a name="app-bar"></a><span data-ttu-id="760c0-113">アプリ バー</span><span class="sxs-lookup"><span data-stu-id="760c0-113">App bar</span></span>
<span data-ttu-id="760c0-114">アプリ特有のコマンドを表示するツール バー。</span><span class="sxs-lookup"><span data-stu-id="760c0-114">A toolbar for displaying application-specific commands.</span></span> <span data-ttu-id="760c0-115">「コマンド バー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-115">See Command bar.</span></span>

<span data-ttu-id="760c0-116">リファレンス: [AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-116">Reference: [AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx)</span></span> 

### <a name="app-bar-button"></a><span data-ttu-id="760c0-117">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-117">App bar button</span></span>
<span data-ttu-id="760c0-118">アプリ バー スタイルを使ってコマンドを表示するボタン。</span><span class="sxs-lookup"><span data-stu-id="760c0-118">A button for showing commands using app bar styling.</span></span>

![アプリ バーのボタン アイコン](images/controls/app-bar-buttons.png) 

<span data-ttu-id="760c0-120">リファレンス: [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx)、[BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx)、[FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx)、[PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-120">Reference: [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx), [BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx), [FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx), [PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx)</span></span> 

<span data-ttu-id="760c0-121">デザインと使い方: [アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-121">Design and how-to: [App bar and command bar control guide](app-bars.md)</span></span> 

<span data-ttu-id="760c0-122">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="760c0-122">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="app-bar-separator"></a><span data-ttu-id="760c0-123">アプリ バーの区分線</span><span class="sxs-lookup"><span data-stu-id="760c0-123">App bar separator</span></span>
<span data-ttu-id="760c0-124">コマンド バーのコマンドのグループを視覚的に区切ります。</span><span class="sxs-lookup"><span data-stu-id="760c0-124">Visually separates groups of commands in a command bar.</span></span>

<span data-ttu-id="760c0-125">リファレンス: [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-125">Reference: [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)</span></span> 

<span data-ttu-id="760c0-126">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="760c0-126">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="app-bar-toggle-button"></a><span data-ttu-id="760c0-127">アプリ バーのトグル ボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-127">App bar toggle button</span></span>
<span data-ttu-id="760c0-128">コマンド バーでコマンドを切り替えるボタン。</span><span class="sxs-lookup"><span data-stu-id="760c0-128">A button for toggling commands in a command bar.</span></span>

<span data-ttu-id="760c0-129">リファレンス: [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-129">Reference: [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)</span></span> 

<span data-ttu-id="760c0-130">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="760c0-130">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="command-bar"></a><span data-ttu-id="760c0-131">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="760c0-131">Command bar</span></span>
<span data-ttu-id="760c0-132">アプリ バーのボタン要素のサイズ変更を処理する専用のアプリ バー。</span><span class="sxs-lookup"><span data-stu-id="760c0-132">A specialized app bar that handles the resizing of app bar button elements.</span></span>

![コマンド バー コントロール](images/command-bar-compact.png)

```xaml
<CommandBar>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
</CommandBar>
```
<span data-ttu-id="760c0-134">リファレンス: [CommandBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-134">Reference: [CommandBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx)</span></span> 

<span data-ttu-id="760c0-135">デザインと使い方: [アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-135">Design and how-to: [App bar and command bar control guide](app-bars.md)</span></span>

<span data-ttu-id="760c0-136">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="760c0-136">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

## <a name="buttons"></a><span data-ttu-id="760c0-137">ボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-137">Buttons</span></span>

### <a name="button"></a><span data-ttu-id="760c0-138">ボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-138">Button</span></span>
<span data-ttu-id="760c0-139">ユーザーの入力に応答して **Click** イベントを発生させるコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-139">A control that responds to user input and raises a **Click** event.</span></span>

![標準的なボタン](images/controls/button.png)

```xaml
<Button x:Name="button1" Content="Button" 
        Click="Button_Click" />
```

<span data-ttu-id="760c0-141">リファレンス: [Button](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-141">Reference: [Button](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx)</span></span> 

<span data-ttu-id="760c0-142">デザインと使い方: [ボタン コントロールのガイド](buttons.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-142">Design and how-to: [Buttons control guide](buttons.md)</span></span> 

### <a name="hyperlink"></a><span data-ttu-id="760c0-143">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="760c0-143">Hyperlink</span></span>
<span data-ttu-id="760c0-144">「ハイパーリンク ボタン」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-144">See Hyperlink button.</span></span>

### <a name="hyperlink-button"></a><span data-ttu-id="760c0-145">ハイパーリンク ボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-145">Hyperlink button</span></span>
<span data-ttu-id="760c0-146">ブラウザーでマークアップ テキストとして表示され、指定された URI を開くボタンです。</span><span class="sxs-lookup"><span data-stu-id="760c0-146">A button that appears as marked up text and opens the specified URI in a browser.</span></span>

![ハイパーリンク ボタン](images/controls/hyperlink-button.png)

```xaml
<HyperlinkButton Content="www.microsoft.com" 
                 NavigateUri="http://www.microsoft.com"/>
```

<span data-ttu-id="760c0-148">リファレンス: [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-148">Reference: [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx)</span></span> 

<span data-ttu-id="760c0-149">デザインと使い方: [ハイパーリンク コントロールのガイド](hyperlinks.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-149">Design and how-to: [Hyperlinks control guide](hyperlinks.md)</span></span>

### <a name="repeat-button"></a><span data-ttu-id="760c0-150">繰り返しボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-150">Repeat button</span></span>
<span data-ttu-id="760c0-151">押されたときから離されるまでの間、繰り返し **Click** イベントを発生させるボタン。</span><span class="sxs-lookup"><span data-stu-id="760c0-151">A button that raises its **Click** event repeatedly from the time it's pressed until it's released.</span></span> 

![繰り返しボタン コントロール](images/controls/repeat-button.png) 

```xaml
<RepeatButton x:Name="repeatButton1" Content="Repeat Button" 
              Click="RepeatButton_Click" />
```

<span data-ttu-id="760c0-153">リファレンス: [RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-153">Reference: [RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</span></span> 

<span data-ttu-id="760c0-154">デザインと使い方: [ボタン コントロールのガイド](buttons.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-154">Design and how-to: [Buttons control guide](buttons.md)</span></span> 

## <a name="collectiondata-controls"></a><span data-ttu-id="760c0-155">コレクション コントロールとデータ コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-155">Collection/data controls</span></span>

### <a name="flip-view"></a><span data-ttu-id="760c0-156">FlipView</span><span class="sxs-lookup"><span data-stu-id="760c0-156">Flip view</span></span>
<span data-ttu-id="760c0-157">ユーザーが 1 つずつめくって表示することができる項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-157">A control that presents a collection of items that the user can flip through, one item at a time.</span></span>

```xaml
<FlipView x:Name="flipView1" SelectionChanged="FlipView_SelectionChanged">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

<span data-ttu-id="760c0-158">リファレンス: [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-158">Reference: [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)</span></span> 

<span data-ttu-id="760c0-159">デザインと使い方: [FlipView コントロールのガイド](flipview.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-159">Design and how-to: [Flip view control guide](flipview.md)</span></span> 

### <a name="grid-view"></a><span data-ttu-id="760c0-160">グリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="760c0-160">Grid view</span></span>
<span data-ttu-id="760c0-161">縦方向にスクロールできる複数行と複数列で項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-161">A control that presents a collection of items in rows and columns that can scroll vertically.</span></span>

```xaml
<GridView x:Name="gridView1" SelectionChanged="GridView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</GridView>
```

<span data-ttu-id="760c0-162">リファレンス: [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-162">Reference: [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span></span> 

<span data-ttu-id="760c0-163">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-163">Design and how-to: [Lists](lists.md)</span></span> 

<span data-ttu-id="760c0-164">サンプル コード: [ListView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span><span class="sxs-lookup"><span data-stu-id="760c0-164">Sample code: [ListView sample](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span></span>

### <a name="items-control"></a><span data-ttu-id="760c0-165">項目コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-165">Items control</span></span>
<span data-ttu-id="760c0-166">データ テンプレートで指定された UI にある項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-166">A control that presents a collection of items in a UI specified by a data template.</span></span> 

```xaml
<ItemsControl/>
```

<span data-ttu-id="760c0-167">リファレンス: [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-167">Reference: [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx)</span></span> 

### <a name="list-view"></a><span data-ttu-id="760c0-168">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="760c0-168">List view</span></span>
<span data-ttu-id="760c0-169">縦方向にスクロールできるリストで項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-169">A control that presents a collection of items in a list that can scroll vertically.</span></span>

```xaml
<ListView x:Name="listView1" SelectionChanged="ListView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</ListView>
```

<span data-ttu-id="760c0-170">リファレンス: [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-170">Reference: [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)</span></span> 

<span data-ttu-id="760c0-171">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-171">Design and how-to: [Lists](lists.md)</span></span> 

<span data-ttu-id="760c0-172">サンプル コード: [ListView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span><span class="sxs-lookup"><span data-stu-id="760c0-172">Sample code: [ListView sample](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span></span>

## <a name="date-and-time-controls"></a><span data-ttu-id="760c0-173">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-173">Date and time controls</span></span>

### <a name="calendar-date-picker"></a><span data-ttu-id="760c0-174">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-174">Calendar date picker</span></span>
<span data-ttu-id="760c0-175">ドロップダウン カレンダー表示を使って、ユーザーが日付を選択できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-175">A control that lets a user select a date using a drop-down calendar display.</span></span>

![カレンダー ビューが開いたカレンダーの日付の選択コントロール](images/controls/calendar-date-picker-open.png)

```xaml
<CalendarDatePicker/>
```

<span data-ttu-id="760c0-177">リファレンス: [CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-177">Reference: [CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)</span></span> 

<span data-ttu-id="760c0-178">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-178">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>
 
### <a name="calendar-view"></a><span data-ttu-id="760c0-179">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="760c0-179">Calendar view</span></span>
<span data-ttu-id="760c0-180">ユーザーが 1 つまたは複数の日付を選択できる、構成可能なカレンダー表示。</span><span class="sxs-lookup"><span data-stu-id="760c0-180">A configurable calendar display that lets a user select single or multiple dates.</span></span>

```xaml
<CalendarView/>
```

<span data-ttu-id="760c0-181">リファレンス: [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-181">Reference: [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)</span></span> 

<span data-ttu-id="760c0-182">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-182">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span> 

### <a name="date-picker"></a><span data-ttu-id="760c0-183">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-183">Date picker</span></span>
<span data-ttu-id="760c0-184">ユーザーが日付を選択できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-184">A control that lets a user select a date.</span></span>

![日付の選択コントロール](images/controls/date-picker.png)

```xaml
<DatePicker Header="Arrival Date"/>
```

<span data-ttu-id="760c0-186">リファレンス: [DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-186">Reference: [DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)</span></span> 

<span data-ttu-id="760c0-187">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-187">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>
 
### <a name="time-picker"></a><span data-ttu-id="760c0-188">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-188">Time picker</span></span>
<span data-ttu-id="760c0-189">ユーザーが時間値を設定できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-189">A control that lets a user set a time value.</span></span>

![TimePicker コントロール](images/controls/time-picker.png) 

```xaml
<TimePicker Header="Arrival Time"/>
```

<span data-ttu-id="760c0-191">リファレンス: [TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-191">Reference: [TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span></span> 

<span data-ttu-id="760c0-192">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-192">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>

## <a name="flyouts"></a><span data-ttu-id="760c0-193">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="760c0-193">Flyouts</span></span>

### <a name="context-menu"></a><span data-ttu-id="760c0-194">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="760c0-194">Context menu</span></span>
<span data-ttu-id="760c0-195">「メニュー ポップアップ」および「ポップアップ メニュー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-195">See Menu flyout and Popup menu.</span></span>

### <a name="flyout"></a><span data-ttu-id="760c0-196">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="760c0-196">Flyout</span></span>
<span data-ttu-id="760c0-197">ユーザーの操作が必要であることを示すメッセージを表示します</span><span class="sxs-lookup"><span data-stu-id="760c0-197">Displays a message that requires user interaction.</span></span> <span data-ttu-id="760c0-198">(ダイアログでは他のユーザー操作がブロックされますが、ポップアップでは別のウィンドウが作成されず、操作もブロックされません)。</span><span class="sxs-lookup"><span data-stu-id="760c0-198">(Unlike a dialog, a flyout does not create a separate window, and does not block other user interaction.)</span></span>

![ポップアップ コントロール](images/controls/flyout.png)

```xaml
<Flyout>
    <StackPanel>
        <TextBlock Text="All items will be removed. Do you want to continue?"/>
        <Button Click="DeleteConfirmation_Click" Content="Yes, empty my cart"/>
    </StackPanel>
</Flyout>
```

<span data-ttu-id="760c0-200">リファレンス: [Flyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-200">Reference: [Flyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx)</span></span> 

<span data-ttu-id="760c0-201">デザインと使い方:[ポップアップ](dialogs-and-flyouts/flyouts.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-201">Design and how-to: [Flyouts](dialogs-and-flyouts/flyouts.md)</span></span> 

### <a name="menu-flyout"></a><span data-ttu-id="760c0-202">メニュー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="760c0-202">Menu flyout</span></span>
<span data-ttu-id="760c0-203">ユーザーが現在行っている内容に関連するコマンドまたはオプションの一覧を一時的に表示します。</span><span class="sxs-lookup"><span data-stu-id="760c0-203">Temporarily displays a list of commands or options related to what the user is currently doing.</span></span>

![メニュー ポップアップ コントロール](images/controls/menu-flyout.png) 

```xaml
<MenuFlyout>
    <MenuFlyoutItem Text="Reset" Click="Reset_Click"/>
    <MenuFlyoutSeparator/>
    <ToggleMenuFlyoutItem Text="Shuffle" 
                          IsChecked="{Binding IsShuffleEnabled, Mode=TwoWay}"/>
    <ToggleMenuFlyoutItem Text="Repeat" 
                          IsChecked="{Binding IsRepeatEnabled, Mode=TwoWay}"/>
</MenuFlyout>
```

<span data-ttu-id="760c0-205">リファレンス: [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx)、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-205">Reference: [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx), [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx), [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx), [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)</span></span> 

<span data-ttu-id="760c0-206">デザインと使い方:[メニューとコンテキスト メニュー](menus.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-206">Design and how-to: [Menus and context menus](menus.md)</span></span> 

<span data-ttu-id="760c0-207">サンプル コード: [XAML ショートカット メニューのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620021)</span><span class="sxs-lookup"><span data-stu-id="760c0-207">Sample code: [XAML Context Menu sample](http://go.microsoft.com/fwlink/p/?LinkId=620021)</span></span>

### <a name="popup-menu"></a><span data-ttu-id="760c0-208">ポップアップ メニュー</span><span class="sxs-lookup"><span data-stu-id="760c0-208">Popup menu</span></span>
<span data-ttu-id="760c0-209">指定したコマンドを表示するためのカスタム メニュー。</span><span class="sxs-lookup"><span data-stu-id="760c0-209">A custom menu that presents commands that you specify.</span></span>

<span data-ttu-id="760c0-210">リファレンス: [PopupMenu](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-210">Reference: [PopupMenu](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx)</span></span> 

<span data-ttu-id="760c0-211">デザインと使い方:[ダイアログ](dialogs-and-flyouts/dialogs.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-211">Design and how-to: [Dialogs](dialogs-and-flyouts/dialogs.md)</span></span> 

### <a name="tooltip"></a><span data-ttu-id="760c0-212">ヒント</span><span class="sxs-lookup"><span data-stu-id="760c0-212">Tooltip</span></span>
<span data-ttu-id="760c0-213">要素についての情報を表示するポップアップ ウィンドウ。</span><span class="sxs-lookup"><span data-stu-id="760c0-213">A pop-up window that displays information for an element.</span></span> 
 
![ヒント コントロール](images/controls/tool-tip.png)

```xaml
<Button Content="Button" Click="Button_Click" 
        ToolTipService.ToolTip="Click to perform action" />
```

<span data-ttu-id="760c0-215">リファレンス: [ToolTip](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx)、[ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-215">Reference: [ToolTip](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx), [ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx)</span></span> 

<span data-ttu-id="760c0-216">デザインと使い方: ヒントのガイドライン</span><span class="sxs-lookup"><span data-stu-id="760c0-216">Design and how-to: Guidelines for tooltips</span></span> 

## <a name="images"></a><span data-ttu-id="760c0-217">画像</span><span class="sxs-lookup"><span data-stu-id="760c0-217">Images</span></span>

### <a name="image"></a><span data-ttu-id="760c0-218">画像</span><span class="sxs-lookup"><span data-stu-id="760c0-218">Image</span></span>
<span data-ttu-id="760c0-219">画像を表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-219">A control that presents an image.</span></span>

```xaml
<Image Source="Assets/Logo.png" />
```

<span data-ttu-id="760c0-220">リファレンス: [Image](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-220">Reference: [Image](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)</span></span> 

<span data-ttu-id="760c0-221">デザインと使い方: [Image と ImageBrush](images-imagebrushes.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-221">Design and how-to: [Image and ImageBrush](images-imagebrushes.md)</span></span> 

<span data-ttu-id="760c0-222">サンプル コード: [XAML 画像のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226867)</span><span class="sxs-lookup"><span data-stu-id="760c0-222">Sample code: [XAML images sample](http://go.microsoft.com/fwlink/p/?linkid=226867)</span></span>

## <a name="graphics-and-ink"></a><span data-ttu-id="760c0-223">グラフィックスとインク</span><span class="sxs-lookup"><span data-stu-id="760c0-223">Graphics and ink</span></span>

### <a name="inkcanvas"></a><span data-ttu-id="760c0-224">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="760c0-224">InkCanvas</span></span>
<span data-ttu-id="760c0-225">インク ストロークを受信し、表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-225">A control that receives and displays ink strokes.</span></span>

```xaml
<InkCanvas/>
```

<span data-ttu-id="760c0-226">リファレンス: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-226">Reference: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx)</span></span> 

### <a name="shapes"></a><span data-ttu-id="760c0-227">図形</span><span class="sxs-lookup"><span data-stu-id="760c0-227">Shapes</span></span>
<span data-ttu-id="760c0-228">楕円形、四角形、直線、ベジエ パスなどのように表示できる、保持モードの各種グラフィック オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="760c0-228">Various retained mode graphical objects that can be presented like ellipses, rectangles, lines, Bezier paths, etc.</span></span>

![<span data-ttu-id="760c0-229">多角形](images/controls/shapes-polygon.png) 
![パス</span><span class="sxs-lookup"><span data-stu-id="760c0-229">A polygon](images/controls/shapes-polygon.png) 
![A path</span></span>](images/controls/shapes-path.png) 

```xaml
<Ellipse/>
<Path/>
<Rectangle/>
```

<span data-ttu-id="760c0-230">リファレンス: [Shapes](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-230">Reference: [Shapes](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx)</span></span> 

<span data-ttu-id="760c0-231">操作方法: [図形の描画](../../graphics/drawing-shapes.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-231">How to: [Drawing shapes](../../graphics/drawing-shapes.md)</span></span> 

<span data-ttu-id="760c0-232">サンプル コード: [XAML ベクターベース描画のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226866)</span><span class="sxs-lookup"><span data-stu-id="760c0-232">Sample code: [XAML vector-based drawing sample](http://go.microsoft.com/fwlink/p/?linkid=226866)</span></span>

## <a name="layout-controls"></a><span data-ttu-id="760c0-233">レイアウト コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-233">Layout controls</span></span>

### <a name="border"></a><span data-ttu-id="760c0-234">境界線</span><span class="sxs-lookup"><span data-stu-id="760c0-234">Border</span></span>
<span data-ttu-id="760c0-235">境界線、背景、またはこの両方を他のオブジェクトの周囲に描画するコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-235">A container control that draws a border, background, or both, around another object.</span></span>

![2 つの四角形の周囲の境界線](images/controls/border.png) 

```xaml
<Border BorderBrush="Blue" BorderThickness="4" 
        Height="108" Width="64" 
        Padding="8" CornerRadius="4">
    <Canvas>
        <Rectangle Fill="Orange"/>
        <Rectangle Fill="Green" Margin="0,44"/>
    </Canvas>
</Border>
```

<span data-ttu-id="760c0-237">リファレンス: [Border](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-237">Reference: [Border](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)</span></span>

### <a name="canvas"></a><span data-ttu-id="760c0-238">キャンバス</span><span class="sxs-lookup"><span data-stu-id="760c0-238">Canvas</span></span>
<span data-ttu-id="760c0-239">キャンバスの左上隅を基準とする子要素の絶対配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="760c0-239">A layout panel that supports the absolute positioning of child elements relative to the top left corner of the canvas.</span></span>
 
![キャンバス レイアウト パネル](images/controls/canvas.png) 

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Orange" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```

<span data-ttu-id="760c0-241">リファレンス: [Canvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-241">Reference: [Canvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)</span></span>
 
### <a name="grid"></a><span data-ttu-id="760c0-242">グリッド</span><span class="sxs-lookup"><span data-stu-id="760c0-242">Grid</span></span>
<span data-ttu-id="760c0-243">複数行と複数列での子要素の配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="760c0-243">A layout panel that supports the arranging of child elements in rows and columns.</span></span>

![グリッド レイアウト パネル](images/controls/grid.png) 

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="50"/>
        <RowDefinition Height="50"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="50"/>
        <ColumnDefinition Width="50"/>
    </Grid.ColumnDefinitions>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Grid.Row="1"/>
    <Rectangle Fill="Green" Grid.Column="1"/>
    <Rectangle Fill="Orange" Grid.Row="1" Grid.Column="1"/>
</Grid>
```

<span data-ttu-id="760c0-245">リファレンス: [Grid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-245">Reference: [Grid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)</span></span>
 
### <a name="panning-scroll-viewer"></a><span data-ttu-id="760c0-246">パン スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="760c0-246">Panning scroll viewer</span></span>
<span data-ttu-id="760c0-247">「スクロール ビューアー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-247">See Scroll viewer.</span></span>

### <a name="relativepanel"></a><span data-ttu-id="760c0-248">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="760c0-248">RelativePanel</span></span>
<span data-ttu-id="760c0-249">互いまたは親パネルを基準にして、子オブジェクトの位置を決定し、調整できるパネル。</span><span class="sxs-lookup"><span data-stu-id="760c0-249">A panel that lets you position and align child objects in relation to each other or the parent panel.</span></span>

![RelativePanel レイアウト パネル](images/controls/relative-panel.png) 

```xaml
<RelativePanel>
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

<span data-ttu-id="760c0-251">リファレンス: [RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-251">Reference: [RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)</span></span>

### <a name="scroll-bar"></a><span data-ttu-id="760c0-252">スクロール バー</span><span class="sxs-lookup"><span data-stu-id="760c0-252">Scroll bar</span></span>
<span data-ttu-id="760c0-253">「スクロール ビューアー」をご覧ください </span><span class="sxs-lookup"><span data-stu-id="760c0-253">See scroll viewer.</span></span> <span data-ttu-id="760c0-254">(ScrollBar は ScrollViewer の要素です。</span><span class="sxs-lookup"><span data-stu-id="760c0-254">(ScrollBar is an element of ScrollViewer.</span></span> <span data-ttu-id="760c0-255">通常、スタンドアロン コントロールとしては使用しません)。</span><span class="sxs-lookup"><span data-stu-id="760c0-255">You don't typically use it as a stand-alone control.)</span></span>

<span data-ttu-id="760c0-256">リファレンス: [ScrollBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-256">Reference: [ScrollBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span></span>
 
### <a name="scroll-viewer"></a><span data-ttu-id="760c0-257">スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="760c0-257">Scroll viewer</span></span>
<span data-ttu-id="760c0-258">ユーザーが、コンテンツのパンとズームを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-258">A container control that lets the user pan and zoom its content.</span></span>

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10" 
              HorizontalScrollMode="Enabled" 
              HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

<span data-ttu-id="760c0-259">リファレンス: [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-259">Reference: [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)</span></span>

<span data-ttu-id="760c0-260">デザインと使い方: [スクロールとパンのコントロールのガイド](scroll-controls.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-260">Design and how-to: [Scroll and panning controls guide](scroll-controls.md)</span></span> 

<span data-ttu-id="760c0-261">サンプル コード: [XAML のスクロール、パン、ズームのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238577)</span><span class="sxs-lookup"><span data-stu-id="760c0-261">Sample code: [XAML scrolling, panning and zooming sample](http://go.microsoft.com/fwlink/p/?linkid=238577)</span></span>

### <a name="stack-panel"></a><span data-ttu-id="760c0-262">スタック パネル</span><span class="sxs-lookup"><span data-stu-id="760c0-262">Stack panel</span></span>
<span data-ttu-id="760c0-263">子要素を水平方向または垂直方向の単一行に配置するレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="760c0-263">A layout panel that arranges child elements into a single line that can be oriented horizontally or vertically.</span></span>

![スタック パネル レイアウト コントロール](images/controls/stack-panel.png) 

```xaml
<StackPanel>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue"/>
    <Rectangle Fill="Green"/>
    <Rectangle Fill="Orange"/>
</StackPanel>
```

<span data-ttu-id="760c0-265">リファレンス: [StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-265">Reference: [StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)</span></span>
 
### <a name="variablesizedwrapgrid"></a><span data-ttu-id="760c0-266">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="760c0-266">VariableSizedWrapGrid</span></span>
<span data-ttu-id="760c0-267">複数行と複数列での子要素の配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="760c0-267">A layout panel that supports the arranging of child elements in rows and columns.</span></span> <span data-ttu-id="760c0-268">各子要素を、複数の行と列に配置できます。</span><span class="sxs-lookup"><span data-stu-id="760c0-268">Each child element can span multiple rows and columns.</span></span>

![可変サイズ折り返しグリッド レイアウト パネル](images/controls/variable-sized-wrap-grid.png) 

```xaml
<VariableSizedWrapGrid MaximumRowsOrColumns="3" ItemHeight="44" ItemWidth="44">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Height="80" 
               VariableSizedWrapGrid.RowSpan="2"/>
    <Rectangle Fill="Green" Width="80" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
    <Rectangle Fill="Orange" Height="80" Width="80" 
               VariableSizedWrapGrid.RowSpan="2" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
</VariableSizedWrapGrid>
```

<span data-ttu-id="760c0-270">リファレンス: [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-270">Reference: [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)</span></span>

### <a name="viewbox"></a><span data-ttu-id="760c0-271">Viewbox</span><span class="sxs-lookup"><span data-stu-id="760c0-271">Viewbox</span></span>
<span data-ttu-id="760c0-272">コンテンツを指定されたサイズに拡大縮小するコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-272">A container control that scales its content to a specified size.</span></span>

![Viewbox コントロール](images/controls/view-box.png) 

```xaml
<Viewbox MaxWidth="25" MaxHeight="25">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
<Viewbox MaxWidth="75" MaxHeight="75">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
<Viewbox MaxWidth="150" MaxHeight="150">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
```

<span data-ttu-id="760c0-274">リファレンス: [Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-274">Reference: [Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)</span></span>
 
### <a name="zooming-scroll-viewer"></a><span data-ttu-id="760c0-275">ズーム スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="760c0-275">Zooming scroll viewer</span></span>
<span data-ttu-id="760c0-276">「スクロール ビューアー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-276">See Scroll viewer.</span></span>

## <a name="media-controls"></a><span data-ttu-id="760c0-277">メディア コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-277">Media controls</span></span>

### <a name="audio"></a><span data-ttu-id="760c0-278">オーディオ</span><span class="sxs-lookup"><span data-stu-id="760c0-278">Audio</span></span>
<span data-ttu-id="760c0-279">「メディア要素」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-279">See Media element.</span></span>

### <a name="media-element"></a><span data-ttu-id="760c0-280">メディア要素</span><span class="sxs-lookup"><span data-stu-id="760c0-280">Media element</span></span>
<span data-ttu-id="760c0-281">オーディオとビデオのコンテンツを再生するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-281">A control that plays audio and video content.</span></span>

```xaml
<MediaElement x:Name="myMediaElement"/>
```

<span data-ttu-id="760c0-282">リファレンス: [MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-282">Reference: [MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx)</span></span> 

<span data-ttu-id="760c0-283">デザインと使い方: [メディア要素コントロールのガイド](media-playback.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-283">Design and how-to: [Media element control guide](media-playback.md)</span></span>

### <a name="mediatransportcontrols"></a><span data-ttu-id="760c0-284">MediaTransportControls</span><span class="sxs-lookup"><span data-stu-id="760c0-284">MediaTransportControls</span></span>
<span data-ttu-id="760c0-285">MediaElement の再生コントロールを提供するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-285">A control that provides playback controls for a MediaElement.</span></span>

![トランスポート コントロールを含むメディア要素](images/controls/media-transport-controls.png) 

```xaml
<MediaTransportControls MediaElement="myMediaElement"/>
```

<span data-ttu-id="760c0-287">リファレンス: [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-287">Reference: [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx)</span></span> 

<span data-ttu-id="760c0-288">デザインと使い方: [メディア要素コントロールのガイド](media-playback.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-288">Design and how-to: [Media element control guide](media-playback.md)</span></span> 

<span data-ttu-id="760c0-289">サンプル コード: [メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)</span><span class="sxs-lookup"><span data-stu-id="760c0-289">Sample code: [Media Transport Controls sample](http://go.microsoft.com/fwlink/p/?LinkId=620023)</span></span>

### <a name="video"></a><span data-ttu-id="760c0-290">ビデオ</span><span class="sxs-lookup"><span data-stu-id="760c0-290">Video</span></span>
<span data-ttu-id="760c0-291">「メディア要素」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-291">See Media element.</span></span>

## <a name="navigation"></a><span data-ttu-id="760c0-292">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="760c0-292">Navigation</span></span>

### <a name="navigationview"></a><span data-ttu-id="760c0-293">NavigationView</span><span class="sxs-lookup"><span data-stu-id="760c0-293">NavigationView</span></span>

<span data-ttu-id="760c0-294">適応コンテナーと、左側のナビゲーション ウィンドウで、上部のナビゲーションとタブ パターンを実装する柔軟なナビゲーション モデルの場合。</span><span class="sxs-lookup"><span data-stu-id="760c0-294">An adaptable container and flexible navigation model that implements the left navigation pane, top navigation and tabs pattern.</span></span>

<span data-ttu-id="760c0-295">リファレンス: [NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="760c0-295">Reference: [NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)</span></span>

<span data-ttu-id="760c0-296">デザインと使い方: [NavigationView コントロールのガイド](navigationview.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-296">Design and how-to: [NavigationView control guide](navigationview.md)</span></span>

### <a name="splitview"></a><span data-ttu-id="760c0-297">SplitView</span><span class="sxs-lookup"><span data-stu-id="760c0-297">SplitView</span></span>

<span data-ttu-id="760c0-298">2 つのビューを持つコンテナー コントロール。1 つはメイン コンテンツ用で、もう 1 つは、通常、ナビゲーション メニューに使います。</span><span class="sxs-lookup"><span data-stu-id="760c0-298">A container control with two views; one view for the main content and another view that is typically used for a navigation menu.</span></span>

![分割ビュー コントロール](images/controls/split-view.png) 

```xaml
<SplitView>
    <SplitView.Pane>
        <!-- Menu content -->
    </SplitView.Pane>
    <SplitView.Content>
        <!-- Main content -->
    </SplitView.Content>
</SplitView>
```

<span data-ttu-id="760c0-300">リファレンス: [SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-300">Reference: [SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx)</span></span> 

<span data-ttu-id="760c0-301">デザインと使い方: [分割ビュー コントロールのガイド](split-view.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-301">Design and how-to: [Split view control guide](split-view.md)</span></span>

### <a name="web-view"></a><span data-ttu-id="760c0-302">Web ビュー</span><span class="sxs-lookup"><span data-stu-id="760c0-302">Web view</span></span>

<span data-ttu-id="760c0-303">Web コンテンツをホストするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-303">A container control that hosts web content.</span></span>

```xaml
<WebView x:Name="webView1" Source="http://dev.windows.com" 
         Height="400" Width="800"/>
```

<span data-ttu-id="760c0-304">リファレンス: [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-304">Reference: [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx)</span></span> 

<span data-ttu-id="760c0-305">デザインと使い方: Web ビューのガイドライン</span><span class="sxs-lookup"><span data-stu-id="760c0-305">Design and how-to: Guidelines for Web views</span></span> 

<span data-ttu-id="760c0-306">サンプル コード: [XAML WebView コントロールのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238582)</span><span class="sxs-lookup"><span data-stu-id="760c0-306">Sample code: [XAML WebView control sample](http://go.microsoft.com/fwlink/p/?linkid=238582)</span></span>

### <a name="semantic-zoom"></a><span data-ttu-id="760c0-307">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="760c0-307">Semantic zoom</span></span>

<span data-ttu-id="760c0-308">ユーザーが、項目のコレクションの 2 つの異なる表示の間でズームを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-308">A container control that lets the user zoom between two views of a collection of items.</span></span>

```xaml
<SemanticZoom>
    <ZoomedInView>
        <GridView></GridView>
    </ZoomedInView>
    <ZoomedOutView>
        <GridView></GridView>
    </ZoomedOutView>
</SemanticZoom>
```

<span data-ttu-id="760c0-309">リファレンス: [SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-309">Reference: [SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx)</span></span> 

<span data-ttu-id="760c0-310">デザインと使い方: [セマンティック ズーム コントロールのガイド](semantic-zoom.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-310">Design and how-to: [Semantic zoom control guide](semantic-zoom.md)</span></span>

<span data-ttu-id="760c0-311">サンプル コード: [XAML GridView のグループ化と SemanticZoom のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226564)</span><span class="sxs-lookup"><span data-stu-id="760c0-311">Sample code: [XAML GridView grouping and SemanticZoom sample](http://go.microsoft.com/fwlink/p/?linkid=226564)</span></span>

## <a name="progress-controls"></a><span data-ttu-id="760c0-312">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-312">Progress controls</span></span>

### <a name="progress-bar"></a><span data-ttu-id="760c0-313">進行状況バー</span><span class="sxs-lookup"><span data-stu-id="760c0-313">Progress bar</span></span>
<span data-ttu-id="760c0-314">バーを表示して進行状況を示すコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-314">A control that indicates progress by displaying a bar.</span></span>

![進行状況バー コントロール](images/controls/progress-bar-determinate.png)

<span data-ttu-id="760c0-316">特定の値を表示する進行状況バー。</span><span class="sxs-lookup"><span data-stu-id="760c0-316">A progress bar that shows a specific value.</span></span>

```xaml
<ProgressBar x:Name="progressBar1" Value="50" Width="100"/>
```

![進行状況不定バー コントロール](images/controls/progress-bar-indeterminate.png)

<span data-ttu-id="760c0-318">進行状況が不定であることを表す進行状況バー。</span><span class="sxs-lookup"><span data-stu-id="760c0-318">A progress bar that shows indeterminate progress.</span></span>

```xaml
<ProgressBar x:Name="indeterminateProgressBar1" IsIndeterminate="True" Width="100"/>
```

<span data-ttu-id="760c0-319">リファレンス: [ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-319">Reference: [ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)</span></span> 

<span data-ttu-id="760c0-320">デザインと使い方: [プログレス コントロールのガイド](progress-controls.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-320">Design and how-to: [Progress controls guide](progress-controls.md)</span></span> 

### <a name="progress-ring"></a><span data-ttu-id="760c0-321">進行状況リング</span><span class="sxs-lookup"><span data-stu-id="760c0-321">Progress ring</span></span>
<span data-ttu-id="760c0-322">リングを表示して進行状況が不定であることを示すコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-322">A control that indicates indeterminate progress by displaying a ring.</span></span> 

![進行状況リング コントロール](images/controls/progress-ring.png) 

```xaml
<ProgressRing x:Name="progressRing1" IsActive="True"/>
```

<span data-ttu-id="760c0-324">リファレンス: [ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-324">Reference: [ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)</span></span> 

<span data-ttu-id="760c0-325">デザインと使い方: [プログレス コントロールのガイド](progress-controls.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-325">Design and how-to: [Progress controls guide](progress-controls.md)</span></span> 

## <a name="text-controls"></a><span data-ttu-id="760c0-326">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-326">Text controls</span></span>

### <a name="auto-suggest-box"></a><span data-ttu-id="760c0-327">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-327">Auto suggest box</span></span>
<span data-ttu-id="760c0-328">ユーザーが入力するときに、候補のテキストを表示するテキスト入力ボックスです。</span><span class="sxs-lookup"><span data-stu-id="760c0-328">A text input box that provides suggested text as the user types.</span></span>

![検索の自動提案ボックス](images/controls/auto-suggest-box.png) 

<span data-ttu-id="760c0-330">リファレンス: [AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-330">Reference: [AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)</span></span>

<span data-ttu-id="760c0-331">デザインと使い方: [テキスト コントロール](text-controls.md)、[自動提案ボックス コントロールのガイド](auto-suggest-box.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-331">Design and how-to: [Text controls](text-controls.md), [Auto suggest box control guide](auto-suggest-box.md)</span></span>

<span data-ttu-id="760c0-332">サンプル コード: [AutoSuggestBox の移行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619996)</span><span class="sxs-lookup"><span data-stu-id="760c0-332">Sample code: [AutoSuggestBox migration sample](http://go.microsoft.com/fwlink/p/?LinkId=619996)</span></span>

### <a name="multi-line-text-box"></a><span data-ttu-id="760c0-333">複数行テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-333">Multi-line text box</span></span>
<span data-ttu-id="760c0-334">「テキスト ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-334">See Text box.</span></span>

### <a name="password-box"></a><span data-ttu-id="760c0-335">パスワード ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-335">Password box</span></span>
<span data-ttu-id="760c0-336">パスワードを入力するためのコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-336">A control for entering passwords.</span></span>

 ![パスワード ボックス](images/controls/password-box.png)

```xaml
<PasswordBox x:Name="passwordBox1" 
             PasswordChanged="PasswordBox_PasswordChanged" />
```

<span data-ttu-id="760c0-338">リファレンス: [PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-338">Reference: [PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span></span> 

<span data-ttu-id="760c0-339">デザインと使い方: [テキスト コントロール](text-controls.md)、[パスワード ボックス コントロールのガイド](password-box.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-339">Design and how-to: [Text controls](text-controls.md), [Password box control guide](password-box.md)</span></span> 

<span data-ttu-id="760c0-340">サンプル コード: [XAML テキスト表示のサンプル](http://go.microsoft.com/fwlink/p/?linkid=238579)、[XAML テキスト編集のサンプル](http://go.microsoft.com/fwlink/p/?linkid=251417)</span><span class="sxs-lookup"><span data-stu-id="760c0-340">Sample code: [XAML text display sample](http://go.microsoft.com/fwlink/p/?linkid=238579), [XAML text editing sample](http://go.microsoft.com/fwlink/p/?linkid=251417)</span></span>

### <a name="rich-edit-box"></a><span data-ttu-id="760c0-341">リッチ エディット ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-341">Rich edit box</span></span>
<span data-ttu-id="760c0-342">書式付きテキスト、ハイパーリンク、イメージなどを含んだリッチ テキスト ドキュメントを編集できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-342">A control that lets a user edit rich text documents with content like formatted text, hyperlinks, and images.</span></span>

```xaml
<RichEditBox />
```

<span data-ttu-id="760c0-343">リファレンス: [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-343">Reference: [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)</span></span> 

<span data-ttu-id="760c0-344">デザインと使い方: [テキスト コントロール](text-controls.md)、[リッチ エディット ボックス コントロールのガイド](rich-edit-box.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-344">Design and how-to: [Text controls](text-controls.md), [Rich edit box control guide](rich-edit-box.md)</span></span>

<span data-ttu-id="760c0-345">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="760c0-345">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

### <a name="search-box"></a><span data-ttu-id="760c0-346">検索ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-346">Search box</span></span>
<span data-ttu-id="760c0-347">「自動提案ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-347">See Auto suggest box.</span></span>

### <a name="single-line-text-box"></a><span data-ttu-id="760c0-348">単一行テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-348">Single-line text box</span></span>
<span data-ttu-id="760c0-349">「テキスト ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-349">See Text box.</span></span>

### <a name="static-textparagraph"></a><span data-ttu-id="760c0-350">静的テキスト/段落</span><span class="sxs-lookup"><span data-stu-id="760c0-350">Static text/paragraph</span></span>
<span data-ttu-id="760c0-351">「テキスト ブロック」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="760c0-351">See Text block.</span></span>

### <a name="text-block"></a><span data-ttu-id="760c0-352">テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="760c0-352">Text block</span></span>
<span data-ttu-id="760c0-353">テキストを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-353">A control that displays text.</span></span>

![テキスト ブロック コントロール](images/controls/text-block.png) 

```xaml
<TextBlock x:Name="textBlock1" Text="I am a TextBlock"/>
```

<span data-ttu-id="760c0-355">リファレンス: [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、[RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-355">Reference: [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)</span></span> 

<span data-ttu-id="760c0-356">デザインと使い方: [テキスト コントロール](text-controls.md)、[テキスト ブロック コントロールのガイド](text-block.md)、[リッチ テキスト ブロック コントロールのガイド](rich-text-block.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-356">Design and how-to: [Text controls](text-controls.md), [Text block control guide](text-block.md), [Rich text block control guide](rich-text-block.md)</span></span>

<span data-ttu-id="760c0-357">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="760c0-357">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

### <a name="text-box"></a><span data-ttu-id="760c0-358">テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-358">Text box</span></span>
<span data-ttu-id="760c0-359">1 行または複数行のプレーンテキスト フィールド。</span><span class="sxs-lookup"><span data-stu-id="760c0-359">A single-line or multi-line plain text field.</span></span>

![テキスト ボックス コントロール](images/controls/text-box.png) 

```xaml
<TextBox x:Name="textBox1" Text="I am a TextBox" 
         TextChanged="TextBox_TextChanged"/>
```

<span data-ttu-id="760c0-361">リファレンス: [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-361">Reference: [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)</span></span> 

<span data-ttu-id="760c0-362">デザインと使い方: [テキスト コントロール](text-controls.md)、[テキスト ボックス コントロールのガイド](text-box.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-362">Design and how-to: [Text controls](text-controls.md), [Text box control guide](text-box.md)</span></span> 

<span data-ttu-id="760c0-363">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="760c0-363">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

## <a name="selection-controls"></a><span data-ttu-id="760c0-364">選択コントロール</span><span class="sxs-lookup"><span data-stu-id="760c0-364">Selection controls</span></span>

### <a name="check-box"></a><span data-ttu-id="760c0-365">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-365">Check box</span></span>
<span data-ttu-id="760c0-366">ユーザーがオンまたはオフにできるコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-366">A control that a user can select or clear.</span></span>

![チェック ボックスの 3 状態](images/templates-checkbox-states-default.png)

```xaml
<CheckBox x:Name="checkbox1" Content="CheckBox" 
          Checked="CheckBox_Checked"/>
```

<span data-ttu-id="760c0-368">リファレンス: [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-368">Reference: [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx)</span></span> 

<span data-ttu-id="760c0-369">デザインと使い方: [チェック ボックス コントロールのガイド](checkbox.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-369">Design and how-to: [Check box control guide](checkbox.md)</span></span> 

### <a name="combo-box"></a><span data-ttu-id="760c0-370">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-370">Combo box</span></span>
<span data-ttu-id="760c0-371">ユーザーが選択できる項目のドロップダウン リスト。</span><span class="sxs-lookup"><span data-stu-id="760c0-371">A drop-down list of items a user can select from.</span></span>

![開かれた状態のコンボ ボックス](images/controls/combo-box-open.png) 

```xaml
<ComboBox x:Name="comboBox1" Width="100"
          SelectionChanged="ComboBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ComboBox>
```

<span data-ttu-id="760c0-373">リファレンス: [ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-373">Reference: [ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx)</span></span> 

<span data-ttu-id="760c0-374">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-374">Design and how-to: [Lists](lists.md)</span></span> 

### <a name="list-box"></a><span data-ttu-id="760c0-375">リスト ボックス</span><span class="sxs-lookup"><span data-stu-id="760c0-375">List box</span></span>
<span data-ttu-id="760c0-376">ユーザーが選択できる項目のインライン リストを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-376">A control that presents an inline list of items that the user can select from.</span></span> 

![リスト ボックス コントロール](images/controls/list-box.png)

```xaml
<ListBox x:Name="listBox1" Width="100"
         SelectionChanged="ListBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ListBox>
```

<span data-ttu-id="760c0-378">リファレンス: [ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-378">Reference: [ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx)</span></span> 

<span data-ttu-id="760c0-379">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-379">Design and how-to: [Lists](lists.md)</span></span> 

### <a name="radio-button"></a><span data-ttu-id="760c0-380">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-380">Radio button</span></span>
<span data-ttu-id="760c0-381">ユーザーがオプションのグループから 1 つのオプションを選択できるようにするコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-381">A control that allows a user to select a single option from a group of options.</span></span> <span data-ttu-id="760c0-382">グループ化されたラジオ ボタンは、それぞれ相互に排他的です。</span><span class="sxs-lookup"><span data-stu-id="760c0-382">When radio buttons are grouped together, they are mutually exclusive.</span></span>

![ラジオ ボタン コントロール](images/controls/radio-button.png)

```xaml
<RadioButton x:Name="radioButton1" Content="RadioButton 1" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
<RadioButton x:Name="radioButton2" Content="RadioButton 2" GroupName="Group1" 
             Checked="RadioButton_Checked" IsChecked="True"/>
<RadioButton x:Name="radioButton3" Content="RadioButton 3" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
```

<span data-ttu-id="760c0-384">リファレンス: [RadioButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-384">Reference: [RadioButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx)</span></span> 

<span data-ttu-id="760c0-385">デザインと使い方: [ラジオ ボタン コントロールのガイド](radio-button.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-385">Design and how-to: [Radio button control guide](radio-button.md)</span></span>
 
### <a name="slider"></a><span data-ttu-id="760c0-386">スライダー</span><span class="sxs-lookup"><span data-stu-id="760c0-386">Slider</span></span>
<span data-ttu-id="760c0-387">ユーザーがトラックに沿って Thumb コントロールを動かすことで値の範囲から選択できるようにするコントロール。</span><span class="sxs-lookup"><span data-stu-id="760c0-387">A control that lets the user select from a range of values by moving a Thumb control along a track.</span></span>

![スライダー コントロール](images/controls/slider.png)

```xaml
<Slider x:Name="slider1" Width="100" ValueChanged="Slider_ValueChanged" />
```

<span data-ttu-id="760c0-389">リファレンス: [Slider](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-389">Reference: [Slider](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx)</span></span> 

<span data-ttu-id="760c0-390">デザインと使い方: [スライダー コントロールのガイド](slider.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-390">Design and how-to: [Slider control guide](slider.md)</span></span> 

### <a name="toggle-button"></a><span data-ttu-id="760c0-391">トグル ボタン</span><span class="sxs-lookup"><span data-stu-id="760c0-391">Toggle button</span></span>
<span data-ttu-id="760c0-392">2 つの状態を切り替えることができるボタン。</span><span class="sxs-lookup"><span data-stu-id="760c0-392">A button that can be toggled between 2 states.</span></span>

```xaml
<ToggleButton x:Name="toggleButton1" Content="Button" 
              Checked="ToggleButton_Checked"/>
```

<span data-ttu-id="760c0-393">リファレンス: [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-393">Reference: [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)</span></span>

<span data-ttu-id="760c0-394">デザインと使い方: [トグル コントロールのガイド](toggles.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-394">Design and how-to: [Toggle control guide](toggles.md)</span></span> 

### <a name="toggle-switch"></a><span data-ttu-id="760c0-395">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="760c0-395">Toggle switch</span></span>
<span data-ttu-id="760c0-396">2 つの状態を切り替えることができるスイッチ。</span><span class="sxs-lookup"><span data-stu-id="760c0-396">A switch that can be toggled between 2 states.</span></span>

![トグル スイッチ コントロール](images/controls/toggle-switch.png) 

```xaml
<ToggleSwitch x:Name="toggleSwitch1" Header="ToggleSwitch" 
              OnContent="On" OffContent="Off" 
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="760c0-398">リファレンス: [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx)</span><span class="sxs-lookup"><span data-stu-id="760c0-398">Reference: [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx)</span></span> 

<span data-ttu-id="760c0-399">デザインと使い方: [トグル コントロールのガイド](toggles.md)</span><span class="sxs-lookup"><span data-stu-id="760c0-399">Design and how-to: [Toggle control guide](toggles.md)</span></span> 
