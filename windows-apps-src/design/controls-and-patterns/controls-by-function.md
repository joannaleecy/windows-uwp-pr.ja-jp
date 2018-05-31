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
ms.openlocfilehash: 21539d625dc70ded7bec77b9916c7ea4bff72536
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
ms.locfileid: "1396811"
---
# <a name="controls-by-function"></a><span data-ttu-id="8e9ba-103">機能別コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-103">Controls by function</span></span>

 

<span data-ttu-id="8e9ba-104">Windows の XAML UI フレームワークには、UI 開発をサポートする多くのコントロールのライブラリが用意されています。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-104">The XAML UI framework for Windows provides an extensive library of controls that support UI development.</span></span> <span data-ttu-id="8e9ba-105">これらのコントロールの一部は視覚的に表示されますが、それ以外のコントロールは他のコントロールまたはコンテンツ (画像やメディアなど) のコンテナーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-105">Some of these controls have a visual representation; others function as the containers for other controls or content, such as images and media.</span></span> 

<span data-ttu-id="8e9ba-106">[XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992)をダウンロードすると、Windows UI コントロールの多くを実際に見ることができます。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-106">You can see many of the Windows UI controls in action by downloading the [XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?LinkId=619992).</span></span> 

<span data-ttu-id="8e9ba-107">アプリで使うことができる一般的な XAML コントロールの機能別の一覧を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-107">Here's a list by function of the common XAML controls you can use in your app.</span></span> 

## <a name="appbars-and-commands"></a><span data-ttu-id="8e9ba-108">アプリ バーとコマンド</span><span class="sxs-lookup"><span data-stu-id="8e9ba-108">Appbars and commands</span></span>

### <a name="app-bar"></a><span data-ttu-id="8e9ba-109">アプリ バー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-109">App bar</span></span>
<span data-ttu-id="8e9ba-110">アプリ特有のコマンドを表示するツール バー。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-110">A toolbar for displaying application-specific commands.</span></span> <span data-ttu-id="8e9ba-111">「コマンド バー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-111">See Command bar.</span></span>

<span data-ttu-id="8e9ba-112">リファレンス: [AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-112">Reference: [AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx)</span></span> 

### <a name="app-bar-button"></a><span data-ttu-id="8e9ba-113">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-113">App bar button</span></span>
<span data-ttu-id="8e9ba-114">アプリ バー スタイルを使ってコマンドを表示するボタン。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-114">A button for showing commands using app bar styling.</span></span>

![アプリ バーのボタン アイコン](images/controls/app-bar-buttons.png) 

<span data-ttu-id="8e9ba-116">リファレンス: [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx)、[BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx)、[FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx)、[PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-116">Reference: [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx), [BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx), [FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx), [PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx)</span></span> 

<span data-ttu-id="8e9ba-117">デザインと使い方: [アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-117">Design and how-to: [App bar and command bar control guide](app-bars.md)</span></span> 

<span data-ttu-id="8e9ba-118">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-118">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="app-bar-separator"></a><span data-ttu-id="8e9ba-119">アプリ バーの区分線</span><span class="sxs-lookup"><span data-stu-id="8e9ba-119">App bar separator</span></span>
<span data-ttu-id="8e9ba-120">コマンド バーのコマンドのグループを視覚的に区切ります。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-120">Visually separates groups of commands in a command bar.</span></span>

<span data-ttu-id="8e9ba-121">リファレンス: [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-121">Reference: [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)</span></span> 

<span data-ttu-id="8e9ba-122">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-122">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="app-bar-toggle-button"></a><span data-ttu-id="8e9ba-123">アプリ バーのトグル ボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-123">App bar toggle button</span></span>
<span data-ttu-id="8e9ba-124">コマンド バーでコマンドを切り替えるボタン。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-124">A button for toggling commands in a command bar.</span></span>

<span data-ttu-id="8e9ba-125">リファレンス: [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-125">Reference: [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)</span></span> 

<span data-ttu-id="8e9ba-126">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-126">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="command-bar"></a><span data-ttu-id="8e9ba-127">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-127">Command bar</span></span>
<span data-ttu-id="8e9ba-128">アプリ バーのボタン要素のサイズ変更を処理する専用のアプリ バー。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-128">A specialized app bar that handles the resizing of app bar button elements.</span></span>

![コマンド バー コントロール](images/command-bar-compact.png)

```xaml
<CommandBar>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
</CommandBar>
```
<span data-ttu-id="8e9ba-130">リファレンス: [CommandBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-130">Reference: [CommandBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx)</span></span> 

<span data-ttu-id="8e9ba-131">デザインと使い方: [アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-131">Design and how-to: [App bar and command bar control guide](app-bars.md)</span></span>

<span data-ttu-id="8e9ba-132">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-132">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

## <a name="buttons"></a><span data-ttu-id="8e9ba-133">ボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-133">Buttons</span></span>

### <a name="button"></a><span data-ttu-id="8e9ba-134">ボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-134">Button</span></span>
<span data-ttu-id="8e9ba-135">ユーザーの入力に応答して **Click** イベントを発生させるコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-135">A control that responds to user input and raises a **Click** event.</span></span>

![標準的なボタン](images/controls/button.png)

```xaml
<Button x:Name="button1" Content="Button" 
        Click="Button_Click" />
```

<span data-ttu-id="8e9ba-137">リファレンス: [Button](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-137">Reference: [Button](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx)</span></span> 

<span data-ttu-id="8e9ba-138">デザインと使い方: [ボタン コントロールのガイド](buttons.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-138">Design and how-to: [Buttons control guide](buttons.md)</span></span> 

### <a name="hyperlink"></a><span data-ttu-id="8e9ba-139">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="8e9ba-139">Hyperlink</span></span>
<span data-ttu-id="8e9ba-140">「ハイパーリンク ボタン」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-140">See Hyperlink button.</span></span>

### <a name="hyperlink-button"></a><span data-ttu-id="8e9ba-141">ハイパーリンク ボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-141">Hyperlink button</span></span>
<span data-ttu-id="8e9ba-142">ブラウザーでマークアップ テキストとして表示され、指定された URI を開くボタンです。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-142">A button that appears as marked up text and opens the specified URI in a browser.</span></span>

![ハイパーリンク ボタン](images/controls/hyperlink-button.png)

```xaml
<HyperlinkButton Content="www.microsoft.com" 
                 NavigateUri="http://www.microsoft.com"/>
```

<span data-ttu-id="8e9ba-144">リファレンス: [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-144">Reference: [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx)</span></span> 

<span data-ttu-id="8e9ba-145">デザインと使い方: [ハイパーリンク コントロールのガイド](hyperlinks.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-145">Design and how-to: [Hyperlinks control guide](hyperlinks.md)</span></span>

### <a name="repeat-button"></a><span data-ttu-id="8e9ba-146">繰り返しボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-146">Repeat button</span></span>
<span data-ttu-id="8e9ba-147">押されたときから離されるまでの間、繰り返し **Click** イベントを発生させるボタン。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-147">A button that raises its **Click** event repeatedly from the time it's pressed until it's released.</span></span> 

![繰り返しボタン コントロール](images/controls/repeat-button.png) 

```xaml
<RepeatButton x:Name="repeatButton1" Content="Repeat Button" 
              Click="RepeatButton_Click" />
```

<span data-ttu-id="8e9ba-149">リファレンス: [RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-149">Reference: [RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</span></span> 

<span data-ttu-id="8e9ba-150">デザインと使い方: [ボタン コントロールのガイド](buttons.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-150">Design and how-to: [Buttons control guide](buttons.md)</span></span> 

## <a name="collectiondata-controls"></a><span data-ttu-id="8e9ba-151">コレクション コントロールとデータ コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-151">Collection/data controls</span></span>

### <a name="flip-view"></a><span data-ttu-id="8e9ba-152">FlipView</span><span class="sxs-lookup"><span data-stu-id="8e9ba-152">Flip view</span></span>
<span data-ttu-id="8e9ba-153">ユーザーが 1 つずつめくって表示することができる項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-153">A control that presents a collection of items that the user can flip through, one item at a time.</span></span>

```xaml
<FlipView x:Name="flipView1" SelectionChanged="FlipView_SelectionChanged">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

<span data-ttu-id="8e9ba-154">リファレンス: [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-154">Reference: [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)</span></span> 

<span data-ttu-id="8e9ba-155">デザインと使い方: [FlipView コントロールのガイド](flipview.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-155">Design and how-to: [Flip view control guide](flipview.md)</span></span> 

### <a name="grid-view"></a><span data-ttu-id="8e9ba-156">グリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-156">Grid view</span></span>
<span data-ttu-id="8e9ba-157">縦方向にスクロールできる複数行と複数列で項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-157">A control that presents a collection of items in rows and columns that can scroll vertically.</span></span>

```xaml
<GridView x:Name="gridView1" SelectionChanged="GridView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</GridView>
```

<span data-ttu-id="8e9ba-158">リファレンス: [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-158">Reference: [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span></span> 

<span data-ttu-id="8e9ba-159">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-159">Design and how-to: [Lists](lists.md)</span></span> 

<span data-ttu-id="8e9ba-160">サンプル コード: [ListView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-160">Sample code: [ListView sample](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span></span>

### <a name="items-control"></a><span data-ttu-id="8e9ba-161">項目コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-161">Items control</span></span>
<span data-ttu-id="8e9ba-162">データ テンプレートで指定された UI にある項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-162">A control that presents a collection of items in a UI specified by a data template.</span></span> 

```xaml
<ItemsControl/>
```

<span data-ttu-id="8e9ba-163">リファレンス: [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-163">Reference: [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx)</span></span> 

### <a name="list-view"></a><span data-ttu-id="8e9ba-164">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-164">List view</span></span>
<span data-ttu-id="8e9ba-165">縦方向にスクロールできるリストで項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-165">A control that presents a collection of items in a list that can scroll vertically.</span></span>

```xaml
<ListView x:Name="listView1" SelectionChanged="ListView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</ListView>
```

<span data-ttu-id="8e9ba-166">リファレンス: [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-166">Reference: [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)</span></span> 

<span data-ttu-id="8e9ba-167">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-167">Design and how-to: [Lists](lists.md)</span></span> 

<span data-ttu-id="8e9ba-168">サンプル コード: [ListView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-168">Sample code: [ListView sample](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span></span>

## <a name="date-and-time-controls"></a><span data-ttu-id="8e9ba-169">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-169">Date and time controls</span></span>

### <a name="calendar-date-picker"></a><span data-ttu-id="8e9ba-170">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-170">Calendar date picker</span></span>
<span data-ttu-id="8e9ba-171">ドロップダウン カレンダー表示を使って、ユーザーが日付を選択できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-171">A control that lets a user select a date using a drop-down calendar display.</span></span>

![カレンダー ビューが開いたカレンダーの日付の選択コントロール](images/controls/calendar-date-picker-open.png)

```xaml
<CalendarDatePicker/>
```

<span data-ttu-id="8e9ba-173">リファレンス: [CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-173">Reference: [CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)</span></span> 

<span data-ttu-id="8e9ba-174">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-174">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>
 
### <a name="calendar-view"></a><span data-ttu-id="8e9ba-175">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-175">Calendar view</span></span>
<span data-ttu-id="8e9ba-176">ユーザーが 1 つまたは複数の日付を選択できる、構成可能なカレンダー表示。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-176">A configurable calendar display that lets a user select single or multiple dates.</span></span>

```xaml
<CalendarView/>
```

<span data-ttu-id="8e9ba-177">リファレンス: [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-177">Reference: [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)</span></span> 

<span data-ttu-id="8e9ba-178">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-178">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span> 

### <a name="date-picker"></a><span data-ttu-id="8e9ba-179">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-179">Date picker</span></span>
<span data-ttu-id="8e9ba-180">ユーザーが日付を選択できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-180">A control that lets a user select a date.</span></span>

![日付の選択コントロール](images/controls/date-picker.png)

```xaml
<DatePicker Header="Arrival Date"/>
```

<span data-ttu-id="8e9ba-182">リファレンス: [DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-182">Reference: [DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)</span></span> 

<span data-ttu-id="8e9ba-183">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-183">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>
 
### <a name="time-picker"></a><span data-ttu-id="8e9ba-184">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-184">Time picker</span></span>
<span data-ttu-id="8e9ba-185">ユーザーが時間値を設定できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-185">A control that lets a user set a time value.</span></span>

![TimePicker コントロール](images/controls/time-picker.png) 

```xaml
<TimePicker Header="Arrival Time"/>
```

<span data-ttu-id="8e9ba-187">リファレンス: [TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-187">Reference: [TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span></span> 

<span data-ttu-id="8e9ba-188">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-188">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>

## <a name="flyouts"></a><span data-ttu-id="8e9ba-189">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-189">Flyouts</span></span>

### <a name="context-menu"></a><span data-ttu-id="8e9ba-190">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-190">Context menu</span></span>
<span data-ttu-id="8e9ba-191">「メニュー ポップアップ」および「ポップアップ メニュー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-191">See Menu flyout and Popup menu.</span></span>

### <a name="flyout"></a><span data-ttu-id="8e9ba-192">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-192">Flyout</span></span>
<span data-ttu-id="8e9ba-193">ユーザーの操作が必要であることを示すメッセージを表示します</span><span class="sxs-lookup"><span data-stu-id="8e9ba-193">Displays a message that requires user interaction.</span></span> <span data-ttu-id="8e9ba-194">(ダイアログでは他のユーザー操作がブロックされますが、ポップアップでは別のウィンドウが作成されず、操作もブロックされません)。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-194">(Unlike a dialog, a flyout does not create a separate window, and does not block other user interaction.)</span></span>

![ポップアップ コントロール](images/controls/flyout.png)

```xaml
<Flyout>
    <StackPanel>
        <TextBlock Text="All items will be removed. Do you want to continue?"/>
        <Button Click="DeleteConfirmation_Click" Content="Yes, empty my cart"/>
    </StackPanel>
</Flyout>
```

<span data-ttu-id="8e9ba-196">リファレンス: [Flyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-196">Reference: [Flyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx)</span></span> 

<span data-ttu-id="8e9ba-197">デザインと使い方: [ショートカット メニューとダイアログ](dialogs.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-197">Design and how-to: [Context menus and dialogs](dialogs.md)</span></span> 

### <a name="menu-flyout"></a><span data-ttu-id="8e9ba-198">メニュー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-198">Menu flyout</span></span>
<span data-ttu-id="8e9ba-199">ユーザーが現在行っている内容に関連するコマンドまたはオプションの一覧を一時的に表示します。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-199">Temporarily displays a list of commands or options related to what the user is currently doing.</span></span>

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

<span data-ttu-id="8e9ba-201">リファレンス: [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx)、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-201">Reference: [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx), [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx), [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx), [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)</span></span> 

<span data-ttu-id="8e9ba-202">デザインと使い方: [ショートカット メニューとダイアログ](dialogs.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-202">Design and how-to: [Context menus and dialogs](dialogs.md)</span></span> 

<span data-ttu-id="8e9ba-203">サンプル コード: [XAML ショートカット メニューのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620021)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-203">Sample code: [XAML Context Menu sample](http://go.microsoft.com/fwlink/p/?LinkId=620021)</span></span>

### <a name="popup-menu"></a><span data-ttu-id="8e9ba-204">ポップアップ メニュー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-204">Popup menu</span></span>
<span data-ttu-id="8e9ba-205">指定したコマンドを表示するためのカスタム メニュー。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-205">A custom menu that presents commands that you specify.</span></span>

<span data-ttu-id="8e9ba-206">リファレンス: [PopupMenu](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-206">Reference: [PopupMenu](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx)</span></span> 

<span data-ttu-id="8e9ba-207">デザインと使い方: [ショートカット メニューとダイアログ](dialogs.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-207">Design and how-to: [Context menus and dialogs](dialogs.md)</span></span> 

### <a name="tooltip"></a><span data-ttu-id="8e9ba-208">ヒント</span><span class="sxs-lookup"><span data-stu-id="8e9ba-208">Tooltip</span></span>
<span data-ttu-id="8e9ba-209">要素についての情報を表示するポップアップ ウィンドウ。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-209">A pop-up window that displays information for an element.</span></span> 
 
![ヒント コントロール](images/controls/tool-tip.png)

```xaml
<Button Content="Button" Click="Button_Click" 
        ToolTipService.ToolTip="Click to perform action" />
```

<span data-ttu-id="8e9ba-211">リファレンス: [ToolTip](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx)、[ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-211">Reference: [ToolTip](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx), [ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx)</span></span> 

<span data-ttu-id="8e9ba-212">デザインと使い方: ヒントのガイドライン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-212">Design and how-to: Guidelines for tooltips</span></span> 

## <a name="images"></a><span data-ttu-id="8e9ba-213">画像</span><span class="sxs-lookup"><span data-stu-id="8e9ba-213">Images</span></span>

### <a name="image"></a><span data-ttu-id="8e9ba-214">画像</span><span class="sxs-lookup"><span data-stu-id="8e9ba-214">Image</span></span>
<span data-ttu-id="8e9ba-215">画像を表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-215">A control that presents an image.</span></span>

```xaml
<Image Source="Assets/Logo.png" />
```

<span data-ttu-id="8e9ba-216">リファレンス: [Image](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-216">Reference: [Image](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)</span></span> 

<span data-ttu-id="8e9ba-217">デザインと使い方: [Image と ImageBrush](images-imagebrushes.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-217">Design and how-to: [Image and ImageBrush](images-imagebrushes.md)</span></span> 

<span data-ttu-id="8e9ba-218">サンプル コード: [XAML 画像のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226867)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-218">Sample code: [XAML images sample](http://go.microsoft.com/fwlink/p/?linkid=226867)</span></span>

## <a name="graphics-and-ink"></a><span data-ttu-id="8e9ba-219">グラフィックスとインク</span><span class="sxs-lookup"><span data-stu-id="8e9ba-219">Graphics and ink</span></span>

### <a name="inkcanvas"></a><span data-ttu-id="8e9ba-220">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="8e9ba-220">InkCanvas</span></span>
<span data-ttu-id="8e9ba-221">インク ストロークを受信し、表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-221">A control that receives and displays ink strokes.</span></span>

```xaml
<InkCanvas/>
```

<span data-ttu-id="8e9ba-222">リファレンス: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-222">Reference: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx)</span></span> 

### <a name="shapes"></a><span data-ttu-id="8e9ba-223">図形</span><span class="sxs-lookup"><span data-stu-id="8e9ba-223">Shapes</span></span>
<span data-ttu-id="8e9ba-224">楕円形、四角形、直線、ベジエ パスなどのように表示できる、保持モードの各種グラフィック オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-224">Various retained mode graphical objects that can be presented like ellipses, rectangles, lines, Bezier paths, etc.</span></span>

![<span data-ttu-id="8e9ba-225">多角形](images/controls/shapes-polygon.png) 
![パス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-225">A polygon](images/controls/shapes-polygon.png) 
![A path</span></span>](images/controls/shapes-path.png) 

```xaml
<Ellipse/>
<Path/>
<Rectangle/>
```

<span data-ttu-id="8e9ba-226">リファレンス: [Shapes](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-226">Reference: [Shapes](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx)</span></span> 

<span data-ttu-id="8e9ba-227">操作方法: [図形の描画](../../graphics/drawing-shapes.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-227">How to: [Drawing shapes](../../graphics/drawing-shapes.md)</span></span> 

<span data-ttu-id="8e9ba-228">サンプル コード: [XAML ベクターベース描画のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226866)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-228">Sample code: [XAML vector-based drawing sample](http://go.microsoft.com/fwlink/p/?linkid=226866)</span></span>

## <a name="layout-controls"></a><span data-ttu-id="8e9ba-229">レイアウト コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-229">Layout controls</span></span>

### <a name="border"></a><span data-ttu-id="8e9ba-230">境界線</span><span class="sxs-lookup"><span data-stu-id="8e9ba-230">Border</span></span>
<span data-ttu-id="8e9ba-231">境界線、背景、またはこの両方を他のオブジェクトの周囲に描画するコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-231">A container control that draws a border, background, or both, around another object.</span></span>

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

<span data-ttu-id="8e9ba-233">リファレンス: [Border](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-233">Reference: [Border](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)</span></span>

### <a name="canvas"></a><span data-ttu-id="8e9ba-234">キャンバス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-234">Canvas</span></span>
<span data-ttu-id="8e9ba-235">キャンバスの左上隅を基準とする子要素の絶対配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-235">A layout panel that supports the absolute positioning of child elements relative to the top left corner of the canvas.</span></span>
 
![キャンバス レイアウト パネル](images/controls/canvas.png) 

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Orange" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```

<span data-ttu-id="8e9ba-237">リファレンス: [Canvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-237">Reference: [Canvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)</span></span>
 
### <a name="grid"></a><span data-ttu-id="8e9ba-238">グリッド</span><span class="sxs-lookup"><span data-stu-id="8e9ba-238">Grid</span></span>
<span data-ttu-id="8e9ba-239">複数行と複数列での子要素の配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-239">A layout panel that supports the arranging of child elements in rows and columns.</span></span>

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

<span data-ttu-id="8e9ba-241">リファレンス: [Grid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-241">Reference: [Grid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)</span></span>
 
### <a name="panning-scroll-viewer"></a><span data-ttu-id="8e9ba-242">パン スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-242">Panning scroll viewer</span></span>
<span data-ttu-id="8e9ba-243">「スクロール ビューアー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-243">See Scroll viewer.</span></span>

### <a name="relativepanel"></a><span data-ttu-id="8e9ba-244">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="8e9ba-244">RelativePanel</span></span>
<span data-ttu-id="8e9ba-245">互いまたは親パネルを基準にして、子オブジェクトの位置を決定し、調整できるパネル。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-245">A panel that lets you position and align child objects in relation to each other or the parent panel.</span></span>

![RelativePanel レイアウト パネル](images/controls/relative-panel.png) 

```xaml
<RelativePanel>
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

<span data-ttu-id="8e9ba-247">リファレンス: [RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-247">Reference: [RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)</span></span>

### <a name="scroll-bar"></a><span data-ttu-id="8e9ba-248">スクロール バー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-248">Scroll bar</span></span>
<span data-ttu-id="8e9ba-249">「スクロール ビューアー」をご覧ください </span><span class="sxs-lookup"><span data-stu-id="8e9ba-249">See scroll viewer.</span></span> <span data-ttu-id="8e9ba-250">(ScrollBar は ScrollViewer の要素です。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-250">(ScrollBar is an element of ScrollViewer.</span></span> <span data-ttu-id="8e9ba-251">通常、スタンドアロン コントロールとしては使用しません)。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-251">You don't typically use it as a stand-alone control.)</span></span>

<span data-ttu-id="8e9ba-252">リファレンス: [ScrollBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-252">Reference: [ScrollBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span></span>
 
### <a name="scroll-viewer"></a><span data-ttu-id="8e9ba-253">スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-253">Scroll viewer</span></span>
<span data-ttu-id="8e9ba-254">ユーザーが、コンテンツのパンとズームを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-254">A container control that lets the user pan and zoom its content.</span></span>

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10" 
              HorizontalScrollMode="Enabled" 
              HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

<span data-ttu-id="8e9ba-255">リファレンス: [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-255">Reference: [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)</span></span>

<span data-ttu-id="8e9ba-256">デザインと使い方: [スクロールとパンのコントロールのガイド](scroll-controls.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-256">Design and how-to: [Scroll and panning controls guide](scroll-controls.md)</span></span> 

<span data-ttu-id="8e9ba-257">サンプル コード: [XAML のスクロール、パン、ズームのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238577)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-257">Sample code: [XAML scrolling, panning and zooming sample](http://go.microsoft.com/fwlink/p/?linkid=238577)</span></span>

### <a name="stack-panel"></a><span data-ttu-id="8e9ba-258">スタック パネル</span><span class="sxs-lookup"><span data-stu-id="8e9ba-258">Stack panel</span></span>
<span data-ttu-id="8e9ba-259">子要素を水平方向または垂直方向の単一行に配置するレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-259">A layout panel that arranges child elements into a single line that can be oriented horizontally or vertically.</span></span>

![スタック パネル レイアウト コントロール](images/controls/stack-panel.png) 

```xaml
<StackPanel>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue"/>
    <Rectangle Fill="Green"/>
    <Rectangle Fill="Orange"/>
</StackPanel>
```

<span data-ttu-id="8e9ba-261">リファレンス: [StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-261">Reference: [StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)</span></span>
 
### <a name="variablesizedwrapgrid"></a><span data-ttu-id="8e9ba-262">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="8e9ba-262">VariableSizedWrapGrid</span></span>
<span data-ttu-id="8e9ba-263">複数行と複数列での子要素の配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-263">A layout panel that supports the arranging of child elements in rows and columns.</span></span> <span data-ttu-id="8e9ba-264">各子要素を、複数の行と列に配置できます。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-264">Each child element can span multiple rows and columns.</span></span>

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

<span data-ttu-id="8e9ba-266">リファレンス: [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-266">Reference: [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)</span></span>

### <a name="viewbox"></a><span data-ttu-id="8e9ba-267">Viewbox</span><span class="sxs-lookup"><span data-stu-id="8e9ba-267">Viewbox</span></span>
<span data-ttu-id="8e9ba-268">コンテンツを指定されたサイズに拡大縮小するコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-268">A container control that scales its content to a specified size.</span></span>

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

<span data-ttu-id="8e9ba-270">リファレンス: [Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-270">Reference: [Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)</span></span>
 
### <a name="zooming-scroll-viewer"></a><span data-ttu-id="8e9ba-271">ズーム スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-271">Zooming scroll viewer</span></span>
<span data-ttu-id="8e9ba-272">「スクロール ビューアー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-272">See Scroll viewer.</span></span>

## <a name="media-controls"></a><span data-ttu-id="8e9ba-273">メディア コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-273">Media controls</span></span>

### <a name="audio"></a><span data-ttu-id="8e9ba-274">オーディオ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-274">Audio</span></span>
<span data-ttu-id="8e9ba-275">「メディア要素」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-275">See Media element.</span></span>

### <a name="media-element"></a><span data-ttu-id="8e9ba-276">メディア要素</span><span class="sxs-lookup"><span data-stu-id="8e9ba-276">Media element</span></span>
<span data-ttu-id="8e9ba-277">オーディオとビデオのコンテンツを再生するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-277">A control that plays audio and video content.</span></span>

```xaml
<MediaElement x:Name="myMediaElement"/>
```

<span data-ttu-id="8e9ba-278">リファレンス: [MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-278">Reference: [MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx)</span></span> 

<span data-ttu-id="8e9ba-279">デザインと使い方: [メディア要素コントロールのガイド](media-playback.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-279">Design and how-to: [Media element control guide](media-playback.md)</span></span>

### <a name="mediatransportcontrols"></a><span data-ttu-id="8e9ba-280">MediaTransportControls</span><span class="sxs-lookup"><span data-stu-id="8e9ba-280">MediaTransportControls</span></span>
<span data-ttu-id="8e9ba-281">MediaElement の再生コントロールを提供するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-281">A control that provides playback controls for a MediaElement.</span></span>

![トランスポート コントロールを含むメディア要素](images/controls/media-transport-controls.png) 

```xaml
<MediaTransportControls MediaElement="myMediaElement"/>
```

<span data-ttu-id="8e9ba-283">リファレンス: [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-283">Reference: [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx)</span></span> 

<span data-ttu-id="8e9ba-284">デザインと使い方: [メディア要素コントロールのガイド](media-playback.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-284">Design and how-to: [Media element control guide](media-playback.md)</span></span> 

<span data-ttu-id="8e9ba-285">サンプル コード: [メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-285">Sample code: [Media Transport Controls sample](http://go.microsoft.com/fwlink/p/?LinkId=620023)</span></span>

### <a name="video"></a><span data-ttu-id="8e9ba-286">ビデオ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-286">Video</span></span>
<span data-ttu-id="8e9ba-287">「メディア要素」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-287">See Media element.</span></span>

## <a name="navigation"></a><span data-ttu-id="8e9ba-288">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="8e9ba-288">Navigation</span></span>

### <a name="hub"></a><span data-ttu-id="8e9ba-289">ハブ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-289">Hub</span></span>
<span data-ttu-id="8e9ba-290">ユーザーが、コンテンツの異なるセクションの表示とナビゲートを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-290">A container control that lets the user view and navigate to different sections of content.</span></span>

```xaml
<Hub>
    <HubSection>
        <!--- hub section content -->
    </HubSection>
    <HubSection>
        <!--- hub section content -->
    </HubSection>
</Hub>
```

<span data-ttu-id="8e9ba-291">リファレンス: [Hub](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hub.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-291">Reference: [Hub](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hub.aspx)</span></span> 

<span data-ttu-id="8e9ba-292">デザインと使い方: [ハブ コントロールのガイド](hub.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-292">Design and how-to: [Hub control guide](hub.md)</span></span> 

<span data-ttu-id="8e9ba-293">サンプル コード: [XAML ハブ コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=309828)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-293">Sample code:[XAML Hub control sample](http://go.microsoft.com/fwlink/p/?LinkID=309828)</span></span>

### <a name="pivot"></a><span data-ttu-id="8e9ba-294">ピボット</span><span class="sxs-lookup"><span data-stu-id="8e9ba-294">Pivot</span></span>
<span data-ttu-id="8e9ba-295">通常は同じデータ セット内の異なるピボット (ビューまたはフィルター) 間で、迅速な移動手段を提供する全画面表示のコンテナーおよびナビゲーション モデルです。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-295">A full-screen container and navigation model that also provides a quick way to move between different pivots (views or filters), typically in the same set of data.</span></span>

<span data-ttu-id="8e9ba-296">Pivot コントロールに、"タブ" レイアウトを含むスタイルを適用できます。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-296">The Pivot control can be styled to have a "tab" layout.</span></span>

<span data-ttu-id="8e9ba-297">リファレンス: [Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-297">Reference: [Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx)</span></span> 

<span data-ttu-id="8e9ba-298">デザインと使い方: [タブとピボットのコントロールのガイド](tabs-pivot.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-298">Design and how-to: [Tabs and pivot control guide](tabs-pivot.md)</span></span> 

<span data-ttu-id="8e9ba-299">サンプル コード: [Pivot のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903&amp;clcid=0x409)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-299">Sample code: [Pivot sample](http://go.microsoft.com/fwlink/p/?LinkId=619903&amp;clcid=0x409)</span></span>

### <a name="semantic-zoom"></a><span data-ttu-id="8e9ba-300">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="8e9ba-300">Semantic zoom</span></span>
<span data-ttu-id="8e9ba-301">ユーザーが、項目のコレクションの 2 つの異なる表示の間でズームを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-301">A container control that lets the user zoom between two views of a collection of items.</span></span>

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

<span data-ttu-id="8e9ba-302">リファレンス: [SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-302">Reference: [SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx)</span></span> 

<span data-ttu-id="8e9ba-303">デザインと使い方: [セマンティック ズーム コントロールのガイド](semantic-zoom.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-303">Design and how-to: [Semantic zoom control guide](semantic-zoom.md)</span></span> 

<span data-ttu-id="8e9ba-304">サンプル コード: [XAML GridView のグループ化と SemanticZoom のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226564)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-304">Sample code: [XAML GridView grouping and SemanticZoom sample](http://go.microsoft.com/fwlink/p/?linkid=226564)</span></span>

### <a name="splitview"></a><span data-ttu-id="8e9ba-305">SplitView</span><span class="sxs-lookup"><span data-stu-id="8e9ba-305">SplitView</span></span>
<span data-ttu-id="8e9ba-306">2 つのビューを持つコンテナー コントロール。1 つはメイン コンテンツ用で、もう 1 つは、通常、ナビゲーション メニューに使います。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-306">A container control with two views; one view for the main content and another view that is typically used for a navigation menu.</span></span>

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

<span data-ttu-id="8e9ba-308">リファレンス: [SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-308">Reference: [SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx)</span></span> 

<span data-ttu-id="8e9ba-309">デザインと使い方: [分割ビュー コントロールのガイド](split-view.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-309">Design and how-to: [Split view control guide](split-view.md)</span></span>

### <a name="web-view"></a><span data-ttu-id="8e9ba-310">Web ビュー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-310">Web view</span></span>
<span data-ttu-id="8e9ba-311">Web コンテンツをホストするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-311">A container control that hosts web content.</span></span>

```xaml
<WebView x:Name="webView1" Source="http://dev.windows.com" 
         Height="400" Width="800"/>
```

<span data-ttu-id="8e9ba-312">リファレンス: [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-312">Reference: [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx)</span></span> 

<span data-ttu-id="8e9ba-313">デザインと使い方: Web ビューのガイドライン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-313">Design and how-to: Guidelines for Web views</span></span> 

<span data-ttu-id="8e9ba-314">サンプル コード: [XAML WebView コントロールのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238582)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-314">Sample code: [XAML WebView control sample](http://go.microsoft.com/fwlink/p/?linkid=238582)</span></span>

## <a name="progress-controls"></a><span data-ttu-id="8e9ba-315">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-315">Progress controls</span></span>

### <a name="progress-bar"></a><span data-ttu-id="8e9ba-316">進行状況バー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-316">Progress bar</span></span>
<span data-ttu-id="8e9ba-317">バーを表示して進行状況を示すコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-317">A control that indicates progress by displaying a bar.</span></span>

![進行状況バー コントロール](images/controls/progress-bar-determinate.png)

<span data-ttu-id="8e9ba-319">特定の値を表示する進行状況バー。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-319">A progress bar that shows a specific value.</span></span>

```xaml
<ProgressBar x:Name="progressBar1" Value="50" Width="100"/>
```

![進行状況不定バー コントロール](images/controls/progress-bar-indeterminate.png)

<span data-ttu-id="8e9ba-321">進行状況が不定であることを表す進行状況バー。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-321">A progress bar that shows indeterminate progress.</span></span>

```xaml
<ProgressBar x:Name="indeterminateProgressBar1" IsIndeterminate="True" Width="100"/>
```

<span data-ttu-id="8e9ba-322">リファレンス: [ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-322">Reference: [ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)</span></span> 

<span data-ttu-id="8e9ba-323">デザインと使い方: [プログレス コントロールのガイド](progress-controls.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-323">Design and how-to: [Progress controls guide](progress-controls.md)</span></span> 

### <a name="progress-ring"></a><span data-ttu-id="8e9ba-324">進行状況リング</span><span class="sxs-lookup"><span data-stu-id="8e9ba-324">Progress ring</span></span>
<span data-ttu-id="8e9ba-325">リングを表示して進行状況が不定であることを示すコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-325">A control that indicates indeterminate progress by displaying a ring.</span></span> 

![進行状況リング コントロール](images/controls/progress-ring.png) 

```xaml
<ProgressRing x:Name="progressRing1" IsActive="True"/>
```

<span data-ttu-id="8e9ba-327">リファレンス: [ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-327">Reference: [ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)</span></span> 

<span data-ttu-id="8e9ba-328">デザインと使い方: [プログレス コントロールのガイド](progress-controls.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-328">Design and how-to: [Progress controls guide](progress-controls.md)</span></span> 

## <a name="text-controls"></a><span data-ttu-id="8e9ba-329">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-329">Text controls</span></span>

### <a name="auto-suggest-box"></a><span data-ttu-id="8e9ba-330">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-330">Auto suggest box</span></span>
<span data-ttu-id="8e9ba-331">ユーザーが入力するときに、候補のテキストを表示するテキスト入力ボックスです。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-331">A text input box that provides suggested text as the user types.</span></span>

![検索の自動提案ボックス](images/controls/auto-suggest-box.png) 

<span data-ttu-id="8e9ba-333">リファレンス: [AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-333">Reference: [AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)</span></span>

<span data-ttu-id="8e9ba-334">デザインと使い方: [テキスト コントロール](text-controls.md)、[自動提案ボックス コントロールのガイド](auto-suggest-box.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-334">Design and how-to: [Text controls](text-controls.md), [Auto suggest box control guide](auto-suggest-box.md)</span></span>

<span data-ttu-id="8e9ba-335">サンプル コード: [AutoSuggestBox の移行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619996)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-335">Sample code: [AutoSuggestBox migration sample](http://go.microsoft.com/fwlink/p/?LinkId=619996)</span></span>

### <a name="multi-line-text-box"></a><span data-ttu-id="8e9ba-336">複数行テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-336">Multi-line text box</span></span>
<span data-ttu-id="8e9ba-337">「テキスト ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-337">See Text box.</span></span>

### <a name="password-box"></a><span data-ttu-id="8e9ba-338">パスワード ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-338">Password box</span></span>
<span data-ttu-id="8e9ba-339">パスワードを入力するためのコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-339">A control for entering passwords.</span></span>

 ![パスワード ボックス](images/controls/password-box.png)

```xaml
<PasswordBox x:Name="passwordBox1" 
             PasswordChanged="PasswordBox_PasswordChanged" />
```

<span data-ttu-id="8e9ba-341">リファレンス: [PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-341">Reference: [PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span></span> 

<span data-ttu-id="8e9ba-342">デザインと使い方: [テキスト コントロール](text-controls.md)、[パスワード ボックス コントロールのガイド](password-box.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-342">Design and how-to: [Text controls](text-controls.md), [Password box control guide](password-box.md)</span></span> 

<span data-ttu-id="8e9ba-343">サンプル コード: [XAML テキスト表示のサンプル](http://go.microsoft.com/fwlink/p/?linkid=238579)、[XAML テキスト編集のサンプル](http://go.microsoft.com/fwlink/p/?linkid=251417)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-343">Sample code: [XAML text display sample](http://go.microsoft.com/fwlink/p/?linkid=238579), [XAML text editing sample](http://go.microsoft.com/fwlink/p/?linkid=251417)</span></span>

### <a name="rich-edit-box"></a><span data-ttu-id="8e9ba-344">リッチ エディット ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-344">Rich edit box</span></span>
<span data-ttu-id="8e9ba-345">書式付きテキスト、ハイパーリンク、イメージなどを含んだリッチ テキスト ドキュメントを編集できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-345">A control that lets a user edit rich text documents with content like formatted text, hyperlinks, and images.</span></span>

```xaml
<RichEditBox />
```

<span data-ttu-id="8e9ba-346">リファレンス: [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-346">Reference: [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)</span></span> 

<span data-ttu-id="8e9ba-347">デザインと使い方: [テキスト コントロール](text-controls.md)、[リッチ エディット ボックス コントロールのガイド](rich-edit-box.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-347">Design and how-to: [Text controls](text-controls.md), [Rich edit box control guide](rich-edit-box.md)</span></span>

<span data-ttu-id="8e9ba-348">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-348">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

### <a name="search-box"></a><span data-ttu-id="8e9ba-349">検索ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-349">Search box</span></span>
<span data-ttu-id="8e9ba-350">「自動提案ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-350">See Auto suggest box.</span></span>

### <a name="single-line-text-box"></a><span data-ttu-id="8e9ba-351">単一行テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-351">Single-line text box</span></span>
<span data-ttu-id="8e9ba-352">「テキスト ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-352">See Text box.</span></span>

### <a name="static-textparagraph"></a><span data-ttu-id="8e9ba-353">静的テキスト/段落</span><span class="sxs-lookup"><span data-stu-id="8e9ba-353">Static text/paragraph</span></span>
<span data-ttu-id="8e9ba-354">「テキスト ブロック」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-354">See Text block.</span></span>

### <a name="text-block"></a><span data-ttu-id="8e9ba-355">テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="8e9ba-355">Text block</span></span>
<span data-ttu-id="8e9ba-356">テキストを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-356">A control that displays text.</span></span>

![テキスト ブロック コントロール](images/controls/text-block.png) 

```xaml
<TextBlock x:Name="textBlock1" Text="I am a TextBlock"/>
```

<span data-ttu-id="8e9ba-358">リファレンス: [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、[RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-358">Reference: [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)</span></span> 

<span data-ttu-id="8e9ba-359">デザインと使い方: [テキスト コントロール](text-controls.md)、[テキスト ブロック コントロールのガイド](text-block.md)、[リッチ テキスト ブロック コントロールのガイド](rich-text-block.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-359">Design and how-to: [Text controls](text-controls.md), [Text block control guide](text-block.md), [Rich text block control guide](rich-text-block.md)</span></span>

<span data-ttu-id="8e9ba-360">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-360">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

### <a name="text-box"></a><span data-ttu-id="8e9ba-361">テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-361">Text box</span></span>
<span data-ttu-id="8e9ba-362">1 行または複数行のプレーンテキスト フィールド。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-362">A single-line or multi-line plain text field.</span></span>

![テキスト ボックス コントロール](images/controls/text-box.png) 

```xaml
<TextBox x:Name="textBox1" Text="I am a TextBox" 
         TextChanged="TextBox_TextChanged"/>
```

<span data-ttu-id="8e9ba-364">リファレンス: [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-364">Reference: [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)</span></span> 

<span data-ttu-id="8e9ba-365">デザインと使い方: [テキスト コントロール](text-controls.md)、[テキスト ボックス コントロールのガイド](text-box.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-365">Design and how-to: [Text controls](text-controls.md), [Text box control guide](text-box.md)</span></span> 

<span data-ttu-id="8e9ba-366">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-366">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

## <a name="selection-controls"></a><span data-ttu-id="8e9ba-367">選択コントロール</span><span class="sxs-lookup"><span data-stu-id="8e9ba-367">Selection controls</span></span>

### <a name="check-box"></a><span data-ttu-id="8e9ba-368">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-368">Check box</span></span>
<span data-ttu-id="8e9ba-369">ユーザーがオンまたはオフにできるコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-369">A control that a user can select or clear.</span></span>

![チェック ボックスの 3 状態](images/templates-checkbox-states-default.png)

```xaml
<CheckBox x:Name="checkbox1" Content="CheckBox" 
          Checked="CheckBox_Checked"/>
```

<span data-ttu-id="8e9ba-371">リファレンス: [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-371">Reference: [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx)</span></span> 

<span data-ttu-id="8e9ba-372">デザインと使い方: [チェック ボックス コントロールのガイド](checkbox.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-372">Design and how-to: [Check box control guide](checkbox.md)</span></span> 

### <a name="combo-box"></a><span data-ttu-id="8e9ba-373">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-373">Combo box</span></span>
<span data-ttu-id="8e9ba-374">ユーザーが選択できる項目のドロップダウン リスト。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-374">A drop-down list of items a user can select from.</span></span>

![開かれた状態のコンボ ボックス](images/controls/combo-box-open.png) 

```xaml
<ComboBox x:Name="comboBox1" Width="100"
          SelectionChanged="ComboBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ComboBox>
```

<span data-ttu-id="8e9ba-376">リファレンス: [ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-376">Reference: [ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx)</span></span> 

<span data-ttu-id="8e9ba-377">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-377">Design and how-to: [Lists](lists.md)</span></span> 

### <a name="list-box"></a><span data-ttu-id="8e9ba-378">リスト ボックス</span><span class="sxs-lookup"><span data-stu-id="8e9ba-378">List box</span></span>
<span data-ttu-id="8e9ba-379">ユーザーが選択できる項目のインライン リストを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-379">A control that presents an inline list of items that the user can select from.</span></span> 

![リスト ボックス コントロール](images/controls/list-box.png)

```xaml
<ListBox x:Name="listBox1" Width="100"
         SelectionChanged="ListBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ListBox>
```

<span data-ttu-id="8e9ba-381">リファレンス: [ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-381">Reference: [ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx)</span></span> 

<span data-ttu-id="8e9ba-382">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-382">Design and how-to: [Lists](lists.md)</span></span> 

### <a name="radio-button"></a><span data-ttu-id="8e9ba-383">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-383">Radio button</span></span>
<span data-ttu-id="8e9ba-384">ユーザーがオプションのグループから 1 つのオプションを選択できるようにするコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-384">A control that allows a user to select a single option from a group of options.</span></span> <span data-ttu-id="8e9ba-385">グループ化されたラジオ ボタンは、それぞれ相互に排他的です。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-385">When radio buttons are grouped together, they are mutually exclusive.</span></span>

![ラジオ ボタン コントロール](images/controls/radio-button.png)

```xaml
<RadioButton x:Name="radioButton1" Content="RadioButton 1" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
<RadioButton x:Name="radioButton2" Content="RadioButton 2" GroupName="Group1" 
             Checked="RadioButton_Checked" IsChecked="True"/>
<RadioButton x:Name="radioButton3" Content="RadioButton 3" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
```

<span data-ttu-id="8e9ba-387">リファレンス: [RadioButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-387">Reference: [RadioButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx)</span></span> 

<span data-ttu-id="8e9ba-388">デザインと使い方: [ラジオ ボタン コントロールのガイド](radio-button.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-388">Design and how-to: [Radio button control guide](radio-button.md)</span></span>
 
### <a name="slider"></a><span data-ttu-id="8e9ba-389">スライダー</span><span class="sxs-lookup"><span data-stu-id="8e9ba-389">Slider</span></span>
<span data-ttu-id="8e9ba-390">ユーザーがトラックに沿って Thumb コントロールを動かすことで値の範囲から選択できるようにするコントロール。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-390">A control that lets the user select from a range of values by moving a Thumb control along a track.</span></span>

![スライダー コントロール](images/controls/slider.png)

```xaml
<Slider x:Name="slider1" Width="100" ValueChanged="Slider_ValueChanged" />
```

<span data-ttu-id="8e9ba-392">リファレンス: [Slider](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-392">Reference: [Slider](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx)</span></span> 

<span data-ttu-id="8e9ba-393">デザインと使い方: [スライダー コントロールのガイド](slider.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-393">Design and how-to: [Slider control guide](slider.md)</span></span> 

### <a name="toggle-button"></a><span data-ttu-id="8e9ba-394">トグル ボタン</span><span class="sxs-lookup"><span data-stu-id="8e9ba-394">Toggle button</span></span>
<span data-ttu-id="8e9ba-395">2 つの状態を切り替えることができるボタン。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-395">A button that can be toggled between 2 states.</span></span>

```xaml
<ToggleButton x:Name="toggleButton1" Content="Button" 
              Checked="ToggleButton_Checked"/>
```

<span data-ttu-id="8e9ba-396">リファレンス: [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-396">Reference: [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)</span></span>

<span data-ttu-id="8e9ba-397">デザインと使い方: [トグル コントロールのガイド](toggles.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-397">Design and how-to: [Toggle control guide](toggles.md)</span></span> 

### <a name="toggle-switch"></a><span data-ttu-id="8e9ba-398">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="8e9ba-398">Toggle switch</span></span>
<span data-ttu-id="8e9ba-399">2 つの状態を切り替えることができるスイッチ。</span><span class="sxs-lookup"><span data-stu-id="8e9ba-399">A switch that can be toggled between 2 states.</span></span>

![トグル スイッチ コントロール](images/controls/toggle-switch.png) 

```xaml
<ToggleSwitch x:Name="toggleSwitch1" Header="ToggleSwitch" 
              OnContent="On" OffContent="Off" 
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="8e9ba-401">リファレンス: [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-401">Reference: [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx)</span></span> 

<span data-ttu-id="8e9ba-402">デザインと使い方: [トグル コントロールのガイド](toggles.md)</span><span class="sxs-lookup"><span data-stu-id="8e9ba-402">Design and how-to: [Toggle control guide](toggles.md)</span></span> 
