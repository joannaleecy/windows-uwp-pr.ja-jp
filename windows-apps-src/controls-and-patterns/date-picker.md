---
author: Jwmsft
Description: "DatePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使ってローカライズされた日付値を選択できる標準化された方法です。"
title: "日付の選択コントロール"
ms.assetid: d4a01425-4dee-4de3-9a05-3e85c3fc03cb
isNew: True
label: Date picker
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.openlocfilehash: 25c49681085946e145d4feb4c8f93d2908f7bcbd
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="date-picker"></a><span data-ttu-id="f0ff5-104">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="f0ff5-104">Date picker</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="f0ff5-105">DatePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使ってローカライズされた日付値を選択できる標準化された方法です。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-105">The date picker gives you a standardized way to let users pick a localized date value using touch, mouse, or keyboard input.</span></span> 

> <span data-ttu-id="f0ff5-106">**重要な API**: [DatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)、[Date プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.date.aspx)</span><span class="sxs-lookup"><span data-stu-id="f0ff5-106">**Important APIs**: [DatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx), [Date property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.date.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="f0ff5-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="f0ff5-107">Is this the right control?</span></span>
<span data-ttu-id="f0ff5-108">日付の選択コントロールは、ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストが重要ではない日) を選べるようにする場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-108">Use a date picker to let a user pick a known date, such as a date of birth, where the context of the calendar is not important.</span></span>

<span data-ttu-id="f0ff5-109">適切な日付コントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-109">For more info about choosing the right date control, see the [Date and time controls](date-and-time.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="f0ff5-110">例</span><span class="sxs-lookup"><span data-stu-id="f0ff5-110">Examples</span></span>

<span data-ttu-id="f0ff5-111">エントリ ポイントには、選んだ日付が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-111">The entry point displays the chosen date, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="f0ff5-112">日付の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-112">The date picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した日付の選択コントロールの例](images/controls_datepicker_expand.png)

## <a name="create-a-date-picker"></a><span data-ttu-id="f0ff5-114">日付の選択コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="f0ff5-114">Create a date picker</span></span>

<span data-ttu-id="f0ff5-115">次の例は、ヘッダーを含むシンプルな日付の選択コントロールを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-115">This example shows how to create a simple date picker with a header.</span></span>

```xaml
<DatePicker x:Name=birthDatePicker Header="Date of birth"/>
```

```csharp
DatePicker birthDatePicker = new DatePicker();
birthDatePicker.Header = "Date of birth";
```

<span data-ttu-id="f0ff5-116">結果として、日付の選択コントロールは、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-116">The resulting date picker looks like this:</span></span>

![日付の選択コントロールの例](images/date-picker-closed.png)

> <span data-ttu-id="f0ff5-118">**注:**&nbsp;&nbsp;日付値の重要な情報については、「日付と時刻コントロール」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f0ff5-118">**Note**&nbsp;&nbsp;For important info about date values, see [DateTime and Calendar values](date-and-time.md#datetime-and-calendar-values) in the Date and time controls article.</span></span>



## <a name="related-articles"></a><span data-ttu-id="f0ff5-119">関連記事</span><span class="sxs-lookup"><span data-stu-id="f0ff5-119">Related articles</span></span>

- [<span data-ttu-id="f0ff5-120">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="f0ff5-120">Date and time controls</span></span>](date-and-time.md)
- [<span data-ttu-id="f0ff5-121">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="f0ff5-121">Calendar date picker</span></span>](calendar-date-picker.md)
- [<span data-ttu-id="f0ff5-122">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="f0ff5-122">Calendar view</span></span>](calendar-view.md)
- [<span data-ttu-id="f0ff5-123">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="f0ff5-123">Time picker</span></span>](time-picker.md)
