---
author: muhsinking
Description: The time picker gives you a standardized way to let users pick a time value using touch, mouse, or keyboard input.
title: 時刻の選択
ms.assetid: 5124ecda-09e6-449e-9d4a-d969dca46aa3
label: Time picker
template: detail.hbs
ms.author: mukin
ms.date: 05/08/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: c30b310deb509b9abfcd49531f85ea109cb12864
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7553111"
---
# <a name="time-picker"></a><span data-ttu-id="d4d19-103">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="d4d19-103">Time picker</span></span>
 

<span data-ttu-id="d4d19-104">時刻の選択は、ユーザーがタッチ、マウス、またはキーボード入力を使って時刻値を選択できる標準化された方法です。</span><span class="sxs-lookup"><span data-stu-id="d4d19-104">The time picker gives you a standardized way to let users pick a time value using touch, mouse, or keyboard input.</span></span> 

> <span data-ttu-id="d4d19-105">**重要な API**: [TimePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)、[Time プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)</span><span class="sxs-lookup"><span data-stu-id="d4d19-105">**Important APIs**: [TimePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx), [Time property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="d4d19-106">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="d4d19-106">Is this the right control?</span></span>
<span data-ttu-id="d4d19-107">時刻の選択コントロールを使って、ユーザーが単一の時刻値を選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="d4d19-107">Use a time picker to let a user pick a single time value.</span></span>

<span data-ttu-id="d4d19-108">適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4d19-108">For more info about choosing the right control, see the [Date and time controls](date-and-time.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="d4d19-109">例</span><span class="sxs-lookup"><span data-stu-id="d4d19-109">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="d4d19-110">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="d4d19-110">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="d4d19-111"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/TimePicker">アプリを開き、TimePicker の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="d4d19-111">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/TimePicker">open the app and see the TimePicker in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="d4d19-112">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="d4d19-112">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="d4d19-113">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="d4d19-113">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="d4d19-114">エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、時刻を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="d4d19-114">The entry point displays the chosen time, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="d4d19-115">時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="d4d19-115">The time picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した時刻の選択コントロールの例](images/controls_timepicker_expand.png)

## <a name="create-a-time-picker"></a><span data-ttu-id="d4d19-117">時刻の選択コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="d4d19-117">Create a time picker</span></span>

<span data-ttu-id="d4d19-118">次の例は、ヘッダーを含むシンプルな時刻の選択コントロールを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d4d19-118">This example shows how to create a simple time picker with a header.</span></span>

```xaml
<TimePicker x:Name=arrivalTimePicker Header="Arrival time"/>
```

```csharp
TimePicker arrivalTimePicker = new TimePicker();
arrivalTimePicker.Header = "Arrival time";
```

<span data-ttu-id="d4d19-119">結果として、時刻の選択コントロールは、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4d19-119">The resulting time picker looks like this:</span></span>

![時刻の選択コントロールの例](images/time-picker-closed.png)

> [!NOTE]
> <span data-ttu-id="d4d19-121">日付と時刻の値の重要な情報については、「*日付と時刻コントロール*」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4d19-121">For important info about date and time values, see [DateTime and Calendar values](date-and-time.md#datetime-and-calendar-values) in the *Date and time controls* article.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="d4d19-122">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="d4d19-122">Get the sample code</span></span>

- <span data-ttu-id="d4d19-123">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="d4d19-123">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="d4d19-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d4d19-124">Related topics</span></span>

- [<span data-ttu-id="d4d19-125">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="d4d19-125">Date and time controls</span></span>](date-and-time.md)
- [<span data-ttu-id="d4d19-126">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="d4d19-126">Calendar date picker</span></span>](calendar-date-picker.md)
- [<span data-ttu-id="d4d19-127">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="d4d19-127">Calendar view</span></span>](calendar-view.md)
- [<span data-ttu-id="d4d19-128">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="d4d19-128">Date picker</span></span>](date-picker.md)
