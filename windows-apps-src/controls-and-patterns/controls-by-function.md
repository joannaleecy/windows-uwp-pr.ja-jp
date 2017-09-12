---
author: Jwmsft
Description: "アプリで使うことができる一部のコントロールの機能別の一覧を示します。"
title: "機能別コントロール"
ms.assetid: 8DB4347B-91D6-4659-91F2-80ECF7BBB596
label: Controls by function
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 32e2ba7bc3aebf2d1fae80632f0ea663a203d73c
ms.sourcegitcommit: 00c3f5a1208bd0125f5b275f972cf2a82d8eb9b6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/13/2017
---
# <a name="controls-by-function"></a><span data-ttu-id="ab82c-104">機能別コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-104">Controls by function</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="ab82c-105">Windows の XAML UI フレームワークには、UI 開発をサポートする多くのコントロールのライブラリが用意されています。</span><span class="sxs-lookup"><span data-stu-id="ab82c-105">The XAML UI framework for Windows provides an extensive library of controls that support UI development.</span></span> <span data-ttu-id="ab82c-106">これらのコントロールの一部は視覚的に表示されますが、それ以外のコントロールは他のコントロールまたはコンテンツ (画像やメディアなど) のコンテナーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="ab82c-106">Some of these controls have a visual representation; others function as the containers for other controls or content, such as images and media.</span></span> 

<span data-ttu-id="ab82c-107">[XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992)をダウンロードすると、Windows UI コントロールの多くを実際に見ることができます。</span><span class="sxs-lookup"><span data-stu-id="ab82c-107">You can see many of the Windows UI controls in action by downloading the [XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?LinkId=619992).</span></span> 

<span data-ttu-id="ab82c-108">アプリで使うことができる一般的な XAML コントロールの機能別の一覧を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ab82c-108">Here's a list by function of the common XAML controls you can use in your app.</span></span> 

## <a name="appbars-and-commands"></a><span data-ttu-id="ab82c-109">アプリ バーとコマンド</span><span class="sxs-lookup"><span data-stu-id="ab82c-109">Appbars and commands</span></span>

### <a name="app-bar"></a><span data-ttu-id="ab82c-110">アプリ バー</span><span class="sxs-lookup"><span data-stu-id="ab82c-110">App bar</span></span>
<span data-ttu-id="ab82c-111">アプリ特有のコマンドを表示するツール バー。</span><span class="sxs-lookup"><span data-stu-id="ab82c-111">A toolbar for displaying application-specific commands.</span></span> <span data-ttu-id="ab82c-112">「コマンド バー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-112">See Command bar.</span></span>

<span data-ttu-id="ab82c-113">リファレンス: [AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-113">Reference: [AppBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx)</span></span> 

### <a name="app-bar-button"></a><span data-ttu-id="ab82c-114">アプリ バーのボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-114">App bar button</span></span>
<span data-ttu-id="ab82c-115">アプリ バー スタイルを使ってコマンドを表示するボタン。</span><span class="sxs-lookup"><span data-stu-id="ab82c-115">A button for showing commands using app bar styling.</span></span>

![アプリ バーのボタン アイコン](images/controls/app-bar-buttons.png) 

<span data-ttu-id="ab82c-117">リファレンス: [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx)、[SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx)、[BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx)、[FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx)、[PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-117">Reference: [AppBarButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [SymbolIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx), [BitmapIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx), [FontIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx), [PathIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx)</span></span> 

<span data-ttu-id="ab82c-118">デザインと使い方: [アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-118">Design and how-to: [App bar and command bar control guide](app-bars.md)</span></span> 

<span data-ttu-id="ab82c-119">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="ab82c-119">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="app-bar-separator"></a><span data-ttu-id="ab82c-120">アプリ バーの区分線</span><span class="sxs-lookup"><span data-stu-id="ab82c-120">App bar separator</span></span>
<span data-ttu-id="ab82c-121">コマンド バーのコマンドのグループを視覚的に区切ります。</span><span class="sxs-lookup"><span data-stu-id="ab82c-121">Visually separates groups of commands in a command bar.</span></span>

<span data-ttu-id="ab82c-122">リファレンス: [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-122">Reference: [AppBarSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx)</span></span> 

<span data-ttu-id="ab82c-123">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="ab82c-123">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="app-bar-toggle-button"></a><span data-ttu-id="ab82c-124">アプリ バーのトグル ボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-124">App bar toggle button</span></span>
<span data-ttu-id="ab82c-125">コマンド バーでコマンドを切り替えるボタン。</span><span class="sxs-lookup"><span data-stu-id="ab82c-125">A button for toggling commands in a command bar.</span></span>

<span data-ttu-id="ab82c-126">リファレンス: [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-126">Reference: [AppBarToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx)</span></span> 

<span data-ttu-id="ab82c-127">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="ab82c-127">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

### <a name="command-bar"></a><span data-ttu-id="ab82c-128">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="ab82c-128">Command bar</span></span>
<span data-ttu-id="ab82c-129">アプリ バーのボタン要素のサイズ変更を処理する専用のアプリ バー。</span><span class="sxs-lookup"><span data-stu-id="ab82c-129">A specialized app bar that handles the resizing of app bar button elements.</span></span>

![コマンド バー コントロール](images/command-bar-compact.png)

```xaml
<CommandBar>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
</CommandBar>
```
<span data-ttu-id="ab82c-131">リファレンス: [CommandBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-131">Reference: [CommandBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx)</span></span> 

<span data-ttu-id="ab82c-132">デザインと使い方: [アプリ バーとコマンド バーのコントロールのガイド](app-bars.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-132">Design and how-to: [App bar and command bar control guide](app-bars.md)</span></span>

<span data-ttu-id="ab82c-133">サンプル コード: [XAML コマンド実行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span><span class="sxs-lookup"><span data-stu-id="ab82c-133">Sample code: [XAML Commanding sample](http://go.microsoft.com/fwlink/p/?LinkId=620019)</span></span>

## <a name="buttons"></a><span data-ttu-id="ab82c-134">ボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-134">Buttons</span></span>

### <a name="button"></a><span data-ttu-id="ab82c-135">ボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-135">Button</span></span>
<span data-ttu-id="ab82c-136">ユーザーの入力に応答して **Click** イベントを発生させるコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-136">A control that responds to user input and raises a **Click** event.</span></span>

![標準的なボタン](images/controls/button.png)

```xaml
<Button x:Name="button1" Content="Button" 
        Click="Button_Click" />
```

<span data-ttu-id="ab82c-138">リファレンス: [Button](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-138">Reference: [Button](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx)</span></span> 

<span data-ttu-id="ab82c-139">デザインと使い方: [ボタン コントロールのガイド](buttons.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-139">Design and how-to: [Buttons control guide](buttons.md)</span></span> 

### <a name="hyperlink"></a><span data-ttu-id="ab82c-140">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="ab82c-140">Hyperlink</span></span>
<span data-ttu-id="ab82c-141">「ハイパーリンク ボタン」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-141">See Hyperlink button.</span></span>

### <a name="hyperlink-button"></a><span data-ttu-id="ab82c-142">ハイパーリンク ボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-142">Hyperlink button</span></span>
<span data-ttu-id="ab82c-143">ブラウザーでマークアップ テキストとして表示され、指定された URI を開くボタンです。</span><span class="sxs-lookup"><span data-stu-id="ab82c-143">A button that appears as marked up text and opens the specified URI in a browser.</span></span>

![ハイパーリンク ボタン](images/controls/hyperlink-button.png)

```xaml
<HyperlinkButton Content="www.microsoft.com" 
                 NavigateUri="http://www.microsoft.com"/>
```

<span data-ttu-id="ab82c-145">リファレンス: [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-145">Reference: [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx)</span></span> 

<span data-ttu-id="ab82c-146">デザインと使い方: [ハイパーリンク コントロールのガイド](hyperlinks.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-146">Design and how-to: [Hyperlinks control guide](hyperlinks.md)</span></span>

### <a name="repeat-button"></a><span data-ttu-id="ab82c-147">繰り返しボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-147">Repeat button</span></span>
<span data-ttu-id="ab82c-148">押されたときから離されるまでの間、繰り返し **Click** イベントを発生させるボタン。</span><span class="sxs-lookup"><span data-stu-id="ab82c-148">A button that raises its **Click** event repeatedly from the time it's pressed until it's released.</span></span> 

![繰り返しボタン コントロール](images/controls/repeat-button.png) 

```xaml
<RepeatButton x:Name="repeatButton1" Content="Repeat Button" 
              Click="RepeatButton_Click" />
```

<span data-ttu-id="ab82c-150">リファレンス: [RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-150">Reference: [RepeatButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx)</span></span> 

<span data-ttu-id="ab82c-151">デザインと使い方: [ボタン コントロールのガイド](buttons.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-151">Design and how-to: [Buttons control guide](buttons.md)</span></span> 

## <a name="collectiondata-controls"></a><span data-ttu-id="ab82c-152">コレクション コントロールとデータ コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-152">Collection/data controls</span></span>

### <a name="flip-view"></a><span data-ttu-id="ab82c-153">FlipView</span><span class="sxs-lookup"><span data-stu-id="ab82c-153">Flip view</span></span>
<span data-ttu-id="ab82c-154">ユーザーが 1 つずつめくって表示することができる項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-154">A control that presents a collection of items that the user can flip through, one item at a time.</span></span>

```xaml
<FlipView x:Name="flipView1" SelectionChanged="FlipView_SelectionChanged">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

<span data-ttu-id="ab82c-155">リファレンス: [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-155">Reference: [FlipView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx)</span></span> 

<span data-ttu-id="ab82c-156">デザインと使い方: [FlipView コントロールのガイド](flipview.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-156">Design and how-to: [Flip view control guide](flipview.md)</span></span> 

### <a name="grid-view"></a><span data-ttu-id="ab82c-157">グリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="ab82c-157">Grid view</span></span>
<span data-ttu-id="ab82c-158">縦方向にスクロールできる複数行と複数列で項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-158">A control that presents a collection of items in rows and columns that can scroll vertically.</span></span>

```xaml
<GridView x:Name="gridView1" SelectionChanged="GridView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</GridView>
```

<span data-ttu-id="ab82c-159">リファレンス: [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-159">Reference: [GridView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span></span> 

<span data-ttu-id="ab82c-160">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-160">Design and how-to: [Lists](lists.md)</span></span> 

<span data-ttu-id="ab82c-161">サンプル コード: [ListView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span><span class="sxs-lookup"><span data-stu-id="ab82c-161">Sample code: [ListView sample](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span></span>

### <a name="items-control"></a><span data-ttu-id="ab82c-162">項目コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-162">Items control</span></span>
<span data-ttu-id="ab82c-163">データ テンプレートで指定された UI にある項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-163">A control that presents a collection of items in a UI specified by a data template.</span></span> 

```xaml
<ItemsControl/>
```

<span data-ttu-id="ab82c-164">リファレンス: [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-164">Reference: [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx)</span></span> 

### <a name="list-view"></a><span data-ttu-id="ab82c-165">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="ab82c-165">List view</span></span>
<span data-ttu-id="ab82c-166">縦方向にスクロールできるリストで項目のコレクションを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-166">A control that presents a collection of items in a list that can scroll vertically.</span></span>

```xaml
<ListView x:Name="listView1" SelectionChanged="ListView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</ListView>
```

<span data-ttu-id="ab82c-167">リファレンス: [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-167">Reference: [ListView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)</span></span> 

<span data-ttu-id="ab82c-168">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-168">Design and how-to: [Lists](lists.md)</span></span> 

<span data-ttu-id="ab82c-169">サンプル コード: [ListView のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span><span class="sxs-lookup"><span data-stu-id="ab82c-169">Sample code: [ListView sample](http://go.microsoft.com/fwlink/p/?LinkId=619900)</span></span>

## <a name="date-and-time-controls"></a><span data-ttu-id="ab82c-170">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-170">Date and time controls</span></span>

### <a name="calendar-date-picker"></a><span data-ttu-id="ab82c-171">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-171">Calendar date picker</span></span>
<span data-ttu-id="ab82c-172">ドロップダウン カレンダー表示を使って、ユーザーが日付を選択できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-172">A control that lets a user select a date using a drop-down calendar display.</span></span>

![カレンダー ビューが開いたカレンダーの日付の選択コントロール](images/controls/calendar-date-picker-open.png)

```xaml
<CalendarDatePicker/>
```

<span data-ttu-id="ab82c-174">リファレンス: [CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-174">Reference: [CalendarDatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)</span></span> 

<span data-ttu-id="ab82c-175">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-175">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>
 
### <a name="calendar-view"></a><span data-ttu-id="ab82c-176">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="ab82c-176">Calendar view</span></span>
<span data-ttu-id="ab82c-177">ユーザーが 1 つまたは複数の日付を選択できる、構成可能なカレンダー表示。</span><span class="sxs-lookup"><span data-stu-id="ab82c-177">A configurable calendar display that lets a user select single or multiple dates.</span></span>

```xaml
<CalendarView/>
```

<span data-ttu-id="ab82c-178">リファレンス: [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-178">Reference: [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)</span></span> 

<span data-ttu-id="ab82c-179">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-179">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span> 

### <a name="date-picker"></a><span data-ttu-id="ab82c-180">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-180">Date picker</span></span>
<span data-ttu-id="ab82c-181">ユーザーが日付を選択できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-181">A control that lets a user select a date.</span></span>

![日付の選択コントロール](images/controls/date-picker.png)

```xaml
<DatePicker Header="Arrival Date"/>
```

<span data-ttu-id="ab82c-183">リファレンス: [DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-183">Reference: [DatePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)</span></span> 

<span data-ttu-id="ab82c-184">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-184">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>
 
### <a name="time-picker"></a><span data-ttu-id="ab82c-185">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-185">Time picker</span></span>
<span data-ttu-id="ab82c-186">ユーザーが時間値を設定できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-186">A control that lets a user set a time value.</span></span>

![TimePicker コントロール](images/controls/time-picker.png) 

```xaml
<TimePicker Header="Arrival Time"/>
```

<span data-ttu-id="ab82c-188">リファレンス: [TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-188">Reference: [TimePicker](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span></span> 

<span data-ttu-id="ab82c-189">デザインと使い方: [カレンダー、日付、時刻コントロール](date-and-time.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-189">Design and how-to: [Calendar, date, and time controls](date-and-time.md)</span></span>

## <a name="flyouts"></a><span data-ttu-id="ab82c-190">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="ab82c-190">Flyouts</span></span>

### <a name="context-menu"></a><span data-ttu-id="ab82c-191">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="ab82c-191">Context menu</span></span>
<span data-ttu-id="ab82c-192">「メニュー ポップアップ」および「ポップアップ メニュー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-192">See Menu flyout and Popup menu.</span></span>

### <a name="flyout"></a><span data-ttu-id="ab82c-193">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="ab82c-193">Flyout</span></span>
<span data-ttu-id="ab82c-194">ユーザーの操作が必要であることを示すメッセージを表示します</span><span class="sxs-lookup"><span data-stu-id="ab82c-194">Displays a message that requires user interaction.</span></span> <span data-ttu-id="ab82c-195">(ダイアログでは他のユーザー操作がブロックされますが、ポップアップでは別のウィンドウが作成されず、操作もブロックされません)。</span><span class="sxs-lookup"><span data-stu-id="ab82c-195">(Unlike a dialog, a flyout does not create a separate window, and does not block other user interaction.)</span></span>

![ポップアップ コントロール](images/controls/flyout.png)

```xaml
<Flyout>
    <StackPanel>
        <TextBlock Text="All items will be removed. Do you want to continue?"/>
        <Button Click="DeleteConfirmation_Click" Content="Yes, empty my cart"/>
    </StackPanel>
</Flyout>
```

<span data-ttu-id="ab82c-197">リファレンス: [Flyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-197">Reference: [Flyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx)</span></span> 

<span data-ttu-id="ab82c-198">デザインと使い方: [ショートカット メニューとダイアログ](dialogs-popups-menus.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-198">Design and how-to: [Context menus and dialogs](dialogs-popups-menus.md)</span></span> 

### <a name="menu-flyout"></a><span data-ttu-id="ab82c-199">メニュー ポップアップ</span><span class="sxs-lookup"><span data-stu-id="ab82c-199">Menu flyout</span></span>
<span data-ttu-id="ab82c-200">ユーザーが現在行っている内容に関連するコマンドまたはオプションの一覧を一時的に表示します。</span><span class="sxs-lookup"><span data-stu-id="ab82c-200">Temporarily displays a list of commands or options related to what the user is currently doing.</span></span>

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

<span data-ttu-id="ab82c-202">リファレンス: [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx)、[MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx)、[MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx)、[ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-202">Reference: [MenuFlyout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx), [MenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx), [MenuFlyoutSeparator](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx), [ToggleMenuFlyoutItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx)</span></span> 

<span data-ttu-id="ab82c-203">デザインと使い方: [ショートカット メニューとダイアログ](dialogs-popups-menus.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-203">Design and how-to: [Context menus and dialogs](dialogs-popups-menus.md)</span></span> 

<span data-ttu-id="ab82c-204">サンプル コード: [XAML ショートカット メニューのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620021)</span><span class="sxs-lookup"><span data-stu-id="ab82c-204">Sample code: [XAML Context Menu sample](http://go.microsoft.com/fwlink/p/?LinkId=620021)</span></span>

### <a name="popup-menu"></a><span data-ttu-id="ab82c-205">ポップアップ メニュー</span><span class="sxs-lookup"><span data-stu-id="ab82c-205">Popup menu</span></span>
<span data-ttu-id="ab82c-206">指定したコマンドを表示するためのカスタム メニュー。</span><span class="sxs-lookup"><span data-stu-id="ab82c-206">A custom menu that presents commands that you specify.</span></span>

<span data-ttu-id="ab82c-207">リファレンス: [PopupMenu](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-207">Reference: [PopupMenu](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx)</span></span> 

<span data-ttu-id="ab82c-208">デザインと使い方: [ショートカット メニューとダイアログ](dialogs-popups-menus.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-208">Design and how-to: [Context menus and dialogs](dialogs-popups-menus.md)</span></span> 

### <a name="tooltip"></a><span data-ttu-id="ab82c-209">ヒント</span><span class="sxs-lookup"><span data-stu-id="ab82c-209">Tooltip</span></span>
<span data-ttu-id="ab82c-210">要素についての情報を表示するポップアップ ウィンドウ。</span><span class="sxs-lookup"><span data-stu-id="ab82c-210">A pop-up window that displays information for an element.</span></span> 
 
![ヒント コントロール](images/controls/tool-tip.png)

```xaml
<Button Content="Button" Click="Button_Click" 
        ToolTipService.ToolTip="Click to perform action" />
```

<span data-ttu-id="ab82c-212">リファレンス: [ToolTip](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx)、[ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-212">Reference: [ToolTip](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx), [ToolTipService](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx)</span></span> 

<span data-ttu-id="ab82c-213">デザインと使い方: ヒントのガイドライン</span><span class="sxs-lookup"><span data-stu-id="ab82c-213">Design and how-to: Guidelines for tooltips</span></span> 

## <a name="images"></a><span data-ttu-id="ab82c-214">画像</span><span class="sxs-lookup"><span data-stu-id="ab82c-214">Images</span></span>

### <a name="image"></a><span data-ttu-id="ab82c-215">画像</span><span class="sxs-lookup"><span data-stu-id="ab82c-215">Image</span></span>
<span data-ttu-id="ab82c-216">画像を表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-216">A control that presents an image.</span></span>

```xaml
<Image Source="Assets/Logo.png" />
```

<span data-ttu-id="ab82c-217">リファレンス: [Image](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-217">Reference: [Image](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)</span></span> 

<span data-ttu-id="ab82c-218">デザインと使い方: [Image と ImageBrush](images-imagebrushes.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-218">Design and how-to: [Image and ImageBrush](images-imagebrushes.md)</span></span> 

<span data-ttu-id="ab82c-219">サンプル コード: [XAML 画像のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226867)</span><span class="sxs-lookup"><span data-stu-id="ab82c-219">Sample code: [XAML images sample](http://go.microsoft.com/fwlink/p/?linkid=226867)</span></span>

## <a name="graphics-and-ink"></a><span data-ttu-id="ab82c-220">グラフィックスとインク</span><span class="sxs-lookup"><span data-stu-id="ab82c-220">Graphics and ink</span></span>

### <a name="inkcanvas"></a><span data-ttu-id="ab82c-221">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="ab82c-221">InkCanvas</span></span>
<span data-ttu-id="ab82c-222">インク ストロークを受信し、表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-222">A control that receives and displays ink strokes.</span></span>

```xaml
<InkCanvas/>
```

<span data-ttu-id="ab82c-223">リファレンス: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-223">Reference: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx)</span></span> 

### <a name="shapes"></a><span data-ttu-id="ab82c-224">図形</span><span class="sxs-lookup"><span data-stu-id="ab82c-224">Shapes</span></span>
<span data-ttu-id="ab82c-225">楕円形、四角形、直線、ベジエ パスなどのように表示できる、保持モードの各種グラフィック オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ab82c-225">Various retained mode graphical objects that can be presented like ellipses, rectangles, lines, Bezier paths, etc.</span></span>

![<span data-ttu-id="ab82c-226">多角形](images/controls/shapes-polygon.png) 
![パス</span><span class="sxs-lookup"><span data-stu-id="ab82c-226">A polygon](images/controls/shapes-polygon.png) 
![A path</span></span>](images/controls/shapes-path.png) 

```xaml
<Ellipse/>
<Path/>
<Rectangle/>
```

<span data-ttu-id="ab82c-227">リファレンス: [Shapes](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-227">Reference: [Shapes](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx)</span></span> 

<span data-ttu-id="ab82c-228">操作方法: [図形の描画](../graphics/drawing-shapes.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-228">How to: [Drawing shapes](../graphics/drawing-shapes.md)</span></span> 

<span data-ttu-id="ab82c-229">サンプル コード: [XAML ベクターベース描画のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226866)</span><span class="sxs-lookup"><span data-stu-id="ab82c-229">Sample code: [XAML vector-based drawing sample](http://go.microsoft.com/fwlink/p/?linkid=226866)</span></span>

## <a name="layout-controls"></a><span data-ttu-id="ab82c-230">レイアウト コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-230">Layout controls</span></span>

### <a name="border"></a><span data-ttu-id="ab82c-231">境界線</span><span class="sxs-lookup"><span data-stu-id="ab82c-231">Border</span></span>
<span data-ttu-id="ab82c-232">境界線、背景、またはこの両方を他のオブジェクトの周囲に描画するコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-232">A container control that draws a border, background, or both, around another object.</span></span>

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

<span data-ttu-id="ab82c-234">リファレンス: [Border](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-234">Reference: [Border](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)</span></span>

### <a name="canvas"></a><span data-ttu-id="ab82c-235">キャンバス</span><span class="sxs-lookup"><span data-stu-id="ab82c-235">Canvas</span></span>
<span data-ttu-id="ab82c-236">キャンバスの左上隅を基準とする子要素の絶対配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="ab82c-236">A layout panel that supports the absolute positioning of child elements relative to the top left corner of the canvas.</span></span>
 
![キャンバス レイアウト パネル](images/controls/canvas.png) 

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Orange" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```

<span data-ttu-id="ab82c-238">リファレンス: [Canvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-238">Reference: [Canvas](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)</span></span>
 
### <a name="grid"></a><span data-ttu-id="ab82c-239">グリッド</span><span class="sxs-lookup"><span data-stu-id="ab82c-239">Grid</span></span>
<span data-ttu-id="ab82c-240">複数行と複数列での子要素の配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="ab82c-240">A layout panel that supports the arranging of child elements in rows and columns.</span></span>

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

<span data-ttu-id="ab82c-242">リファレンス: [Grid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-242">Reference: [Grid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)</span></span>
 
### <a name="panning-scroll-viewer"></a><span data-ttu-id="ab82c-243">パン スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="ab82c-243">Panning scroll viewer</span></span>
<span data-ttu-id="ab82c-244">「スクロール ビューアー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-244">See Scroll viewer.</span></span>

### <a name="relativepanel"></a><span data-ttu-id="ab82c-245">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="ab82c-245">RelativePanel</span></span>
<span data-ttu-id="ab82c-246">互いまたは親パネルを基準にして、子オブジェクトの位置を決定し、調整できるパネル。</span><span class="sxs-lookup"><span data-stu-id="ab82c-246">A panel that lets you position and align child objects in relation to each other or the parent panel.</span></span>

![RelativePanel レイアウト パネル](images/controls/relative-panel.png) 

```xaml
<RelativePanel>
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

<span data-ttu-id="ab82c-248">リファレンス: [RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-248">Reference: [RelativePanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)</span></span>

### <a name="scroll-bar"></a><span data-ttu-id="ab82c-249">スクロール バー</span><span class="sxs-lookup"><span data-stu-id="ab82c-249">Scroll bar</span></span>
<span data-ttu-id="ab82c-250">「スクロール ビューアー」をご覧ください </span><span class="sxs-lookup"><span data-stu-id="ab82c-250">See scroll viewer.</span></span> <span data-ttu-id="ab82c-251">(ScrollBar は ScrollViewer の要素です。</span><span class="sxs-lookup"><span data-stu-id="ab82c-251">(ScrollBar is an element of ScrollViewer.</span></span> <span data-ttu-id="ab82c-252">通常、スタンドアロン コントロールとしては使用しません)。</span><span class="sxs-lookup"><span data-stu-id="ab82c-252">You don't typically use it as a stand-alone control.)</span></span>

<span data-ttu-id="ab82c-253">リファレンス: [ScrollBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-253">Reference: [ScrollBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)</span></span>
 
### <a name="scroll-viewer"></a><span data-ttu-id="ab82c-254">スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="ab82c-254">Scroll viewer</span></span>
<span data-ttu-id="ab82c-255">ユーザーが、コンテンツのパンとズームを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-255">A container control that lets the user pan and zoom its content.</span></span>

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10" 
              HorizontalScrollMode="Enabled" 
              HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

<span data-ttu-id="ab82c-256">リファレンス: [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-256">Reference: [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)</span></span>

<span data-ttu-id="ab82c-257">デザインと使い方: [スクロールとパンのコントロールのガイド](scroll-controls.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-257">Design and how-to: [Scroll and panning controls guide](scroll-controls.md)</span></span> 

<span data-ttu-id="ab82c-258">サンプル コード: [XAML のスクロール、パン、ズームのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238577)</span><span class="sxs-lookup"><span data-stu-id="ab82c-258">Sample code: [XAML scrolling, panning and zooming sample](http://go.microsoft.com/fwlink/p/?linkid=238577)</span></span>

### <a name="stack-panel"></a><span data-ttu-id="ab82c-259">スタック パネル</span><span class="sxs-lookup"><span data-stu-id="ab82c-259">Stack panel</span></span>
<span data-ttu-id="ab82c-260">子要素を水平方向または垂直方向の単一行に配置するレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="ab82c-260">A layout panel that arranges child elements into a single line that can be oriented horizontally or vertically.</span></span>

![スタック パネル レイアウト コントロール](images/controls/stack-panel.png) 

```xaml
<StackPanel>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue"/>
    <Rectangle Fill="Green"/>
    <Rectangle Fill="Orange"/>
</StackPanel>
```

<span data-ttu-id="ab82c-262">リファレンス: [StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-262">Reference: [StackPanel](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)</span></span>
 
### <a name="variablesizedwrapgrid"></a><span data-ttu-id="ab82c-263">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="ab82c-263">VariableSizedWrapGrid</span></span>
<span data-ttu-id="ab82c-264">複数行と複数列での子要素の配置をサポートするレイアウト パネル。</span><span class="sxs-lookup"><span data-stu-id="ab82c-264">A layout panel that supports the arranging of child elements in rows and columns.</span></span> <span data-ttu-id="ab82c-265">各子要素を、複数の行と列に配置できます。</span><span class="sxs-lookup"><span data-stu-id="ab82c-265">Each child element can span multiple rows and columns.</span></span>

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

<span data-ttu-id="ab82c-267">リファレンス: [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-267">Reference: [VariableSizedWrapGrid](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)</span></span>

### <a name="viewbox"></a><span data-ttu-id="ab82c-268">Viewbox</span><span class="sxs-lookup"><span data-stu-id="ab82c-268">Viewbox</span></span>
<span data-ttu-id="ab82c-269">コンテンツを指定されたサイズに拡大縮小するコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-269">A container control that scales its content to a specified size.</span></span>

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

<span data-ttu-id="ab82c-271">リファレンス: [Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-271">Reference: [Viewbox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)</span></span>
 
### <a name="zooming-scroll-viewer"></a><span data-ttu-id="ab82c-272">ズーム スクロール ビューアー</span><span class="sxs-lookup"><span data-stu-id="ab82c-272">Zooming scroll viewer</span></span>
<span data-ttu-id="ab82c-273">「スクロール ビューアー」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-273">See Scroll viewer.</span></span>

## <a name="media-controls"></a><span data-ttu-id="ab82c-274">メディア コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-274">Media controls</span></span>

### <a name="audio"></a><span data-ttu-id="ab82c-275">オーディオ</span><span class="sxs-lookup"><span data-stu-id="ab82c-275">Audio</span></span>
<span data-ttu-id="ab82c-276">「メディア要素」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-276">See Media element.</span></span>

### <a name="media-element"></a><span data-ttu-id="ab82c-277">メディア要素</span><span class="sxs-lookup"><span data-stu-id="ab82c-277">Media element</span></span>
<span data-ttu-id="ab82c-278">オーディオとビデオのコンテンツを再生するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-278">A control that plays audio and video content.</span></span>

```xaml
<MediaElement x:Name="myMediaElement"/>
```

<span data-ttu-id="ab82c-279">リファレンス: [MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-279">Reference: [MediaElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx)</span></span> 

<span data-ttu-id="ab82c-280">デザインと使い方: [メディア要素コントロールのガイド](media-playback.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-280">Design and how-to: [Media element control guide](media-playback.md)</span></span>

### <a name="mediatransportcontrols"></a><span data-ttu-id="ab82c-281">MediaTransportControls</span><span class="sxs-lookup"><span data-stu-id="ab82c-281">MediaTransportControls</span></span>
<span data-ttu-id="ab82c-282">MediaElement の再生コントロールを提供するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-282">A control that provides playback controls for a MediaElement.</span></span>

![トランスポート コントロールを含むメディア要素](images/controls/media-transport-controls.png) 

```xaml
<MediaTransportControls MediaElement="myMediaElement"/>
```

<span data-ttu-id="ab82c-284">リファレンス: [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-284">Reference: [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx)</span></span> 

<span data-ttu-id="ab82c-285">デザインと使い方: [メディア要素コントロールのガイド](media-playback.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-285">Design and how-to: [Media element control guide](media-playback.md)</span></span> 

<span data-ttu-id="ab82c-286">サンプル コード: [メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)</span><span class="sxs-lookup"><span data-stu-id="ab82c-286">Sample code: [Media Transport Controls sample](http://go.microsoft.com/fwlink/p/?LinkId=620023)</span></span>

### <a name="video"></a><span data-ttu-id="ab82c-287">ビデオ</span><span class="sxs-lookup"><span data-stu-id="ab82c-287">Video</span></span>
<span data-ttu-id="ab82c-288">「メディア要素」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-288">See Media element.</span></span>

## <a name="navigation"></a><span data-ttu-id="ab82c-289">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="ab82c-289">Navigation</span></span>

### <a name="hub"></a><span data-ttu-id="ab82c-290">ハブ</span><span class="sxs-lookup"><span data-stu-id="ab82c-290">Hub</span></span>
<span data-ttu-id="ab82c-291">ユーザーが、コンテンツの異なるセクションの表示とナビゲートを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-291">A container control that lets the user view and navigate to different sections of content.</span></span>

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

<span data-ttu-id="ab82c-292">リファレンス: [Hub](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hub.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-292">Reference: [Hub](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hub.aspx)</span></span> 

<span data-ttu-id="ab82c-293">デザインと使い方: [ハブ コントロールのガイド](hub.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-293">Design and how-to: [Hub control guide](hub.md)</span></span> 

<span data-ttu-id="ab82c-294">サンプル コード: [XAML ハブ コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=309828)</span><span class="sxs-lookup"><span data-stu-id="ab82c-294">Sample code:[XAML Hub control sample](http://go.microsoft.com/fwlink/p/?LinkID=309828)</span></span>

### <a name="pivot"></a><span data-ttu-id="ab82c-295">ピボット</span><span class="sxs-lookup"><span data-stu-id="ab82c-295">Pivot</span></span>
<span data-ttu-id="ab82c-296">通常は同じデータ セット内の異なるピボット (ビューまたはフィルター) 間で、迅速な移動手段を提供する全画面表示のコンテナーおよびナビゲーション モデルです。</span><span class="sxs-lookup"><span data-stu-id="ab82c-296">A full-screen container and navigation model that also provides a quick way to move between different pivots (views or filters), typically in the same set of data.</span></span>

<span data-ttu-id="ab82c-297">Pivot コントロールに、"タブ" レイアウトを含むスタイルを適用できます。</span><span class="sxs-lookup"><span data-stu-id="ab82c-297">The Pivot control can be styled to have a "tab" layout.</span></span>

<span data-ttu-id="ab82c-298">リファレンス: [Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-298">Reference: [Pivot](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx)</span></span> 

<span data-ttu-id="ab82c-299">デザインと使い方: [タブとピボットのコントロールのガイド](tabs-pivot.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-299">Design and how-to: [Tabs and pivot control guide](tabs-pivot.md)</span></span> 

<span data-ttu-id="ab82c-300">サンプル コード: [Pivot のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619903&amp;clcid=0x409)</span><span class="sxs-lookup"><span data-stu-id="ab82c-300">Sample code: [Pivot sample](http://go.microsoft.com/fwlink/p/?LinkId=619903&amp;clcid=0x409)</span></span>

### <a name="semantic-zoom"></a><span data-ttu-id="ab82c-301">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="ab82c-301">Semantic zoom</span></span>
<span data-ttu-id="ab82c-302">ユーザーが、項目のコレクションの 2 つの異なる表示の間でズームを実行できるようにするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-302">A container control that lets the user zoom between two views of a collection of items.</span></span>

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

<span data-ttu-id="ab82c-303">リファレンス: [SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-303">Reference: [SemanticZoom](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx)</span></span> 

<span data-ttu-id="ab82c-304">デザインと使い方: [セマンティック ズーム コントロールのガイド](semantic-zoom.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-304">Design and how-to: [Semantic zoom control guide](semantic-zoom.md)</span></span> 

<span data-ttu-id="ab82c-305">サンプル コード: [XAML GridView のグループ化と SemanticZoom のサンプル](http://go.microsoft.com/fwlink/p/?linkid=226564)</span><span class="sxs-lookup"><span data-stu-id="ab82c-305">Sample code: [XAML GridView grouping and SemanticZoom sample](http://go.microsoft.com/fwlink/p/?linkid=226564)</span></span>

### <a name="splitview"></a><span data-ttu-id="ab82c-306">SplitView</span><span class="sxs-lookup"><span data-stu-id="ab82c-306">SplitView</span></span>
<span data-ttu-id="ab82c-307">2 つのビューを持つコンテナー コントロール。1 つはメイン コンテンツ用で、もう 1 つは、通常、ナビゲーション メニューに使います。</span><span class="sxs-lookup"><span data-stu-id="ab82c-307">A container control with two views; one view for the main content and another view that is typically used for a navigation menu.</span></span>

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

<span data-ttu-id="ab82c-309">リファレンス: [SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-309">Reference: [SplitView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx)</span></span> 

<span data-ttu-id="ab82c-310">デザインと使い方: [分割ビュー コントロールのガイド](split-view.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-310">Design and how-to: [Split view control guide](split-view.md)</span></span>

### <a name="web-view"></a><span data-ttu-id="ab82c-311">Web ビュー</span><span class="sxs-lookup"><span data-stu-id="ab82c-311">Web view</span></span>
<span data-ttu-id="ab82c-312">Web コンテンツをホストするコンテナー コントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-312">A container control that hosts web content.</span></span>

```xaml
<WebView x:Name="webView1" Source="http://dev.windows.com" 
         Height="400" Width="800"/>
```

<span data-ttu-id="ab82c-313">リファレンス: [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-313">Reference: [WebView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx)</span></span> 

<span data-ttu-id="ab82c-314">デザインと使い方: Web ビューのガイドライン</span><span class="sxs-lookup"><span data-stu-id="ab82c-314">Design and how-to: Guidelines for Web views</span></span> 

<span data-ttu-id="ab82c-315">サンプル コード: [XAML WebView コントロールのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238582)</span><span class="sxs-lookup"><span data-stu-id="ab82c-315">Sample code: [XAML WebView control sample](http://go.microsoft.com/fwlink/p/?linkid=238582)</span></span>

## <a name="progress-controls"></a><span data-ttu-id="ab82c-316">プログレス コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-316">Progress controls</span></span>

### <a name="progress-bar"></a><span data-ttu-id="ab82c-317">進行状況バー</span><span class="sxs-lookup"><span data-stu-id="ab82c-317">Progress bar</span></span>
<span data-ttu-id="ab82c-318">バーを表示して進行状況を示すコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-318">A control that indicates progress by displaying a bar.</span></span>

![進行状況バー コントロール](images/controls/progress-bar-determinate.png)

<span data-ttu-id="ab82c-320">特定の値を表示する進行状況バー。</span><span class="sxs-lookup"><span data-stu-id="ab82c-320">A progress bar that shows a specific value.</span></span>

```xaml
<ProgressBar x:Name="progressBar1" Value="50" Width="100"/>
```

![進行状況不定バー コントロール](images/controls/progress-bar-indeterminate.png)

<span data-ttu-id="ab82c-322">進行状況が不定であることを表す進行状況バー。</span><span class="sxs-lookup"><span data-stu-id="ab82c-322">A progress bar that shows indeterminate progress.</span></span>

```xaml
<ProgressBar x:Name="indeterminateProgressBar1" IsIndeterminate="True" Width="100"/>
```

<span data-ttu-id="ab82c-323">リファレンス: [ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-323">Reference: [ProgressBar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)</span></span> 

<span data-ttu-id="ab82c-324">デザインと使い方: [プログレス コントロールのガイド](progress-controls.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-324">Design and how-to: [Progress controls guide](progress-controls.md)</span></span> 

### <a name="progress-ring"></a><span data-ttu-id="ab82c-325">進行状況リング</span><span class="sxs-lookup"><span data-stu-id="ab82c-325">Progress ring</span></span>
<span data-ttu-id="ab82c-326">リングを表示して進行状況が不定であることを示すコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-326">A control that indicates indeterminate progress by displaying a ring.</span></span> 

![進行状況リング コントロール](images/controls/progress-ring.png) 

```xaml
<ProgressRing x:Name="progressRing1" IsActive="True"/>
```

<span data-ttu-id="ab82c-328">リファレンス: [ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-328">Reference: [ProgressRing](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)</span></span> 

<span data-ttu-id="ab82c-329">デザインと使い方: [プログレス コントロールのガイド](progress-controls.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-329">Design and how-to: [Progress controls guide](progress-controls.md)</span></span> 

## <a name="text-controls"></a><span data-ttu-id="ab82c-330">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-330">Text controls</span></span>

### <a name="auto-suggest-box"></a><span data-ttu-id="ab82c-331">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-331">Auto suggest box</span></span>
<span data-ttu-id="ab82c-332">ユーザーが入力するときに、候補のテキストを表示するテキスト入力ボックスです。</span><span class="sxs-lookup"><span data-stu-id="ab82c-332">A text input box that provides suggested text as the user types.</span></span>

![検索の自動提案ボックス](images/controls/auto-suggest-box.png) 

<span data-ttu-id="ab82c-334">リファレンス: [AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-334">Reference: [AutoSuggestBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)</span></span>

<span data-ttu-id="ab82c-335">デザインと使い方: [テキスト コントロール](text-controls.md)、[自動提案ボックス コントロールのガイド](auto-suggest-box.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-335">Design and how-to: [Text controls](text-controls.md), [Auto suggest box control guide](auto-suggest-box.md)</span></span>

<span data-ttu-id="ab82c-336">サンプル コード: [AutoSuggestBox の移行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619996)</span><span class="sxs-lookup"><span data-stu-id="ab82c-336">Sample code: [AutoSuggestBox migration sample](http://go.microsoft.com/fwlink/p/?LinkId=619996)</span></span>

### <a name="multi-line-text-box"></a><span data-ttu-id="ab82c-337">複数行テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-337">Multi-line text box</span></span>
<span data-ttu-id="ab82c-338">「テキスト ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-338">See Text box.</span></span>

### <a name="password-box"></a><span data-ttu-id="ab82c-339">パスワード ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-339">Password box</span></span>
<span data-ttu-id="ab82c-340">パスワードを入力するためのコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-340">A control for entering passwords.</span></span>

 ![パスワード ボックス](images/controls/password-box.png)

```xaml
<PasswordBox x:Name="passwordBox1" 
             PasswordChanged="PasswordBox_PasswordChanged" />
```

<span data-ttu-id="ab82c-342">リファレンス: [PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-342">Reference: [PasswordBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)</span></span> 

<span data-ttu-id="ab82c-343">デザインと使い方: [テキスト コントロール](text-controls.md)、[パスワード ボックス コントロールのガイド](password-box.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-343">Design and how-to: [Text controls](text-controls.md), [Password box control guide](password-box.md)</span></span> 

<span data-ttu-id="ab82c-344">サンプル コード: [XAML テキスト表示のサンプル](http://go.microsoft.com/fwlink/p/?linkid=238579)、[XAML テキスト編集のサンプル](http://go.microsoft.com/fwlink/p/?linkid=251417)</span><span class="sxs-lookup"><span data-stu-id="ab82c-344">Sample code: [XAML text display sample](http://go.microsoft.com/fwlink/p/?linkid=238579), [XAML text editing sample](http://go.microsoft.com/fwlink/p/?linkid=251417)</span></span>

### <a name="rich-edit-box"></a><span data-ttu-id="ab82c-345">リッチ エディット ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-345">Rich edit box</span></span>
<span data-ttu-id="ab82c-346">書式付きテキスト、ハイパーリンク、イメージなどを含んだリッチ テキスト ドキュメントを編集できるコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-346">A control that lets a user edit rich text documents with content like formatted text, hyperlinks, and images.</span></span>

```xaml
<RichEditBox />
```

<span data-ttu-id="ab82c-347">リファレンス: [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-347">Reference: [RichEditBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)</span></span> 

<span data-ttu-id="ab82c-348">デザインと使い方: [テキスト コントロール](text-controls.md)、[リッチ エディット ボックス コントロールのガイド](rich-edit-box.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-348">Design and how-to: [Text controls](text-controls.md), [Rich edit box control guide](rich-edit-box.md)</span></span>

<span data-ttu-id="ab82c-349">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="ab82c-349">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

### <a name="search-box"></a><span data-ttu-id="ab82c-350">検索ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-350">Search box</span></span>
<span data-ttu-id="ab82c-351">「自動提案ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-351">See Auto suggest box.</span></span>

### <a name="single-line-text-box"></a><span data-ttu-id="ab82c-352">単一行テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-352">Single-line text box</span></span>
<span data-ttu-id="ab82c-353">「テキスト ボックス」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-353">See Text box.</span></span>

### <a name="static-textparagraph"></a><span data-ttu-id="ab82c-354">静的テキスト/段落</span><span class="sxs-lookup"><span data-stu-id="ab82c-354">Static text/paragraph</span></span>
<span data-ttu-id="ab82c-355">「テキスト ブロック」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab82c-355">See Text block.</span></span>

### <a name="text-block"></a><span data-ttu-id="ab82c-356">テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="ab82c-356">Text block</span></span>
<span data-ttu-id="ab82c-357">テキストを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-357">A control that displays text.</span></span>

![テキスト ブロック コントロール](images/controls/text-block.png) 

```xaml
<TextBlock x:Name="textBlock1" Text="I am a TextBlock"/>
```

<span data-ttu-id="ab82c-359">リファレンス: [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、[RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-359">Reference: [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)</span></span> 

<span data-ttu-id="ab82c-360">デザインと使い方: [テキスト コントロール](text-controls.md)、[テキスト ブロック コントロールのガイド](text-block.md)、[リッチ テキスト ブロック コントロールのガイド](rich-text-block.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-360">Design and how-to: [Text controls](text-controls.md), [Text block control guide](text-block.md), [Rich text block control guide](rich-text-block.md)</span></span>

<span data-ttu-id="ab82c-361">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="ab82c-361">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

### <a name="text-box"></a><span data-ttu-id="ab82c-362">テキスト ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-362">Text box</span></span>
<span data-ttu-id="ab82c-363">1 行または複数行のプレーンテキスト フィールド。</span><span class="sxs-lookup"><span data-stu-id="ab82c-363">A single-line or multi-line plain text field.</span></span>

![テキスト ボックス コントロール](images/controls/text-box.png) 

```xaml
<TextBox x:Name="textBox1" Text="I am a TextBox" 
         TextChanged="TextBox_TextChanged"/>
```

<span data-ttu-id="ab82c-365">リファレンス: [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-365">Reference: [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)</span></span> 

<span data-ttu-id="ab82c-366">デザインと使い方: [テキスト コントロール](text-controls.md)、[テキスト ボックス コントロールのガイド](text-box.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-366">Design and how-to: [Text controls](text-controls.md), [Text box control guide](text-box.md)</span></span> 

<span data-ttu-id="ab82c-367">サンプル コード: [XAML テキストのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238578)</span><span class="sxs-lookup"><span data-stu-id="ab82c-367">Sample code: [XAML text sample](http://go.microsoft.com/fwlink/p/?linkid=238578)</span></span>

## <a name="selection-controls"></a><span data-ttu-id="ab82c-368">選択コントロール</span><span class="sxs-lookup"><span data-stu-id="ab82c-368">Selection controls</span></span>

### <a name="check-box"></a><span data-ttu-id="ab82c-369">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-369">Check box</span></span>
<span data-ttu-id="ab82c-370">ユーザーがオンまたはオフにできるコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-370">A control that a user can select or clear.</span></span>

![チェック ボックスの 3 状態](images/templates-checkbox-states-default.png)

```xaml
<CheckBox x:Name="checkbox1" Content="CheckBox" 
          Checked="CheckBox_Checked"/>
```

<span data-ttu-id="ab82c-372">リファレンス: [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-372">Reference: [CheckBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx)</span></span> 

<span data-ttu-id="ab82c-373">デザインと使い方: [チェック ボックス コントロールのガイド](checkbox.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-373">Design and how-to: [Check box control guide](checkbox.md)</span></span> 

### <a name="combo-box"></a><span data-ttu-id="ab82c-374">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-374">Combo box</span></span>
<span data-ttu-id="ab82c-375">ユーザーが選択できる項目のドロップダウン リスト。</span><span class="sxs-lookup"><span data-stu-id="ab82c-375">A drop-down list of items a user can select from.</span></span>

![開かれた状態のコンボ ボックス](images/controls/combo-box-open.png) 

```xaml
<ComboBox x:Name="comboBox1" Width="100"
          SelectionChanged="ComboBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ComboBox>
```

<span data-ttu-id="ab82c-377">リファレンス: [ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-377">Reference: [ComboBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx)</span></span> 

<span data-ttu-id="ab82c-378">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-378">Design and how-to: [Lists](lists.md)</span></span> 

### <a name="list-box"></a><span data-ttu-id="ab82c-379">リスト ボックス</span><span class="sxs-lookup"><span data-stu-id="ab82c-379">List box</span></span>
<span data-ttu-id="ab82c-380">ユーザーが選択できる項目のインライン リストを表示するコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-380">A control that presents an inline list of items that the user can select from.</span></span> 

![リスト ボックス コントロール](images/controls/list-box.png)

```xaml
<ListBox x:Name="listBox1" Width="100"
         SelectionChanged="ListBox_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ListBox>
```

<span data-ttu-id="ab82c-382">リファレンス: [ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-382">Reference: [ListBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx)</span></span> 

<span data-ttu-id="ab82c-383">デザインと使い方: [リスト](lists.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-383">Design and how-to: [Lists](lists.md)</span></span> 

### <a name="radio-button"></a><span data-ttu-id="ab82c-384">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-384">Radio button</span></span>
<span data-ttu-id="ab82c-385">ユーザーがオプションのグループから 1 つのオプションを選択できるようにするコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-385">A control that allows a user to select a single option from a group of options.</span></span> <span data-ttu-id="ab82c-386">グループ化されたラジオ ボタンは、それぞれ相互に排他的です。</span><span class="sxs-lookup"><span data-stu-id="ab82c-386">When radio buttons are grouped together, they are mutually exclusive.</span></span>

![ラジオ ボタン コントロール](images/controls/radio-button.png)

```xaml
<RadioButton x:Name="radioButton1" Content="RadioButton 1" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
<RadioButton x:Name="radioButton2" Content="RadioButton 2" GroupName="Group1" 
             Checked="RadioButton_Checked" IsChecked="True"/>
<RadioButton x:Name="radioButton3" Content="RadioButton 3" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
```

<span data-ttu-id="ab82c-388">リファレンス: [RadioButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-388">Reference: [RadioButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx)</span></span> 

<span data-ttu-id="ab82c-389">デザインと使い方: [ラジオ ボタン コントロールのガイド](radio-button.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-389">Design and how-to: [Radio button control guide](radio-button.md)</span></span>
 
### <a name="slider"></a><span data-ttu-id="ab82c-390">スライダー</span><span class="sxs-lookup"><span data-stu-id="ab82c-390">Slider</span></span>
<span data-ttu-id="ab82c-391">ユーザーがトラックに沿って Thumb コントロールを動かすことで値の範囲から選択できるようにするコントロール。</span><span class="sxs-lookup"><span data-stu-id="ab82c-391">A control that lets the user select from a range of values by moving a Thumb control along a track.</span></span>

![スライダー コントロール](images/controls/slider.png)

```xaml
<Slider x:Name="slider1" Width="100" ValueChanged="Slider_ValueChanged" />
```

<span data-ttu-id="ab82c-393">リファレンス: [Slider](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-393">Reference: [Slider](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx)</span></span> 

<span data-ttu-id="ab82c-394">デザインと使い方: [スライダー コントロールのガイド](slider.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-394">Design and how-to: [Slider control guide](slider.md)</span></span> 

### <a name="toggle-button"></a><span data-ttu-id="ab82c-395">トグル ボタン</span><span class="sxs-lookup"><span data-stu-id="ab82c-395">Toggle button</span></span>
<span data-ttu-id="ab82c-396">2 つの状態を切り替えることができるボタン。</span><span class="sxs-lookup"><span data-stu-id="ab82c-396">A button that can be toggled between 2 states.</span></span>

```xaml
<ToggleButton x:Name="toggleButton1" Content="Button" 
              Checked="ToggleButton_Checked"/>
```

<span data-ttu-id="ab82c-397">リファレンス: [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-397">Reference: [ToggleButton](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)</span></span>

<span data-ttu-id="ab82c-398">デザインと使い方: [トグル コントロールのガイド](toggles.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-398">Design and how-to: [Toggle control guide](toggles.md)</span></span> 

### <a name="toggle-switch"></a><span data-ttu-id="ab82c-399">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="ab82c-399">Toggle switch</span></span>
<span data-ttu-id="ab82c-400">2 つの状態を切り替えることができるスイッチ。</span><span class="sxs-lookup"><span data-stu-id="ab82c-400">A switch that can be toggled between 2 states.</span></span>

![トグル スイッチ コントロール](images/controls/toggle-switch.png) 

```xaml
<ToggleSwitch x:Name="toggleSwitch1" Header="ToggleSwitch" 
              OnContent="On" OffContent="Off" 
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="ab82c-402">リファレンス: [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx)</span><span class="sxs-lookup"><span data-stu-id="ab82c-402">Reference: [ToggleSwitch](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx)</span></span> 

<span data-ttu-id="ab82c-403">デザインと使い方: [トグル コントロールのガイド](toggles.md)</span><span class="sxs-lookup"><span data-stu-id="ab82c-403">Design and how-to: [Toggle control guide](toggles.md)</span></span> 
