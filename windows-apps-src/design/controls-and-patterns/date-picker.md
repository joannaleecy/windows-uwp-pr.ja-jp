---
Description: The date picker gives you a standardized way to let users pick a localized date value using touch, mouse, or keyboard input.
title: 日付の選択
ms.assetid: d4a01425-4dee-4de3-9a05-3e85c3fc03cb
isNew: true
label: Date picker
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 42b061c3c3836e69739c571f6ef47e05c286ea8e
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8731304"
---
# <a name="date-picker"></a><span data-ttu-id="3a17e-103">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="3a17e-103">Date picker</span></span>

 

<span data-ttu-id="3a17e-104">DatePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使ってローカライズされた日付値を選択できる標準化された方法です。</span><span class="sxs-lookup"><span data-stu-id="3a17e-104">The date picker gives you a standardized way to let users pick a localized date value using touch, mouse, or keyboard input.</span></span> 

> <span data-ttu-id="3a17e-105">**重要な API**: [DatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)、[Date プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.date.aspx)</span><span class="sxs-lookup"><span data-stu-id="3a17e-105">**Important APIs**: [DatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx), [Date property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.date.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="3a17e-106">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3a17e-106">Is this the right control?</span></span>
<span data-ttu-id="3a17e-107">日付の選択コントロールは、ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストが重要ではない日) を選べるようにする場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="3a17e-107">Use a date picker to let a user pick a known date, such as a date of birth, where the context of the calendar is not important.</span></span>

<span data-ttu-id="3a17e-108">適切な日付コントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a17e-108">For more info about choosing the right date control, see the [Date and time controls](date-and-time.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="3a17e-109">例</span><span class="sxs-lookup"><span data-stu-id="3a17e-109">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="3a17e-110">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="3a17e-110">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="3a17e-111"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/DatePicker">アプリを開き、DatePicker の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="3a17e-111">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/DatePicker">open the app and see the DatePicker in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="3a17e-112">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="3a17e-112">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="3a17e-113">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="3a17e-113">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="3a17e-114">エントリ ポイントには、選んだ日付が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="3a17e-114">The entry point displays the chosen date, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="3a17e-115">日付の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="3a17e-115">The date picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した日付の選択コントロールの例](images/controls_datepicker_expand.png)

## <a name="create-a-date-picker"></a><span data-ttu-id="3a17e-117">日付の選択コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="3a17e-117">Create a date picker</span></span>

<span data-ttu-id="3a17e-118">次の例は、ヘッダーを含むシンプルな日付の選択コントロールを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3a17e-118">This example shows how to create a simple date picker with a header.</span></span>

```xaml
<DatePicker x:Name=birthDatePicker Header="Date of birth"/>
```

```csharp
DatePicker birthDatePicker = new DatePicker();
birthDatePicker.Header = "Date of birth";
```

<span data-ttu-id="3a17e-119">結果として、日付の選択コントロールは、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a17e-119">The resulting date picker looks like this:</span></span>

![日付の選択コントロールの例](images/date-picker-closed.png)

> <span data-ttu-id="3a17e-121">**注:**&nbsp;&nbsp;日付値の重要な情報については、「日付と時刻コントロール」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a17e-121">**Note**&nbsp;&nbsp;For important info about date values, see [DateTime and Calendar values](date-and-time.md#datetime-and-calendar-values) in the Date and time controls article.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3a17e-122">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3a17e-122">Get the sample code</span></span>

- <span data-ttu-id="3a17e-123">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3a17e-123">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3a17e-124">関連記事</span><span class="sxs-lookup"><span data-stu-id="3a17e-124">Related articles</span></span>

- [<span data-ttu-id="3a17e-125">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="3a17e-125">Date and time controls</span></span>](date-and-time.md)
- [<span data-ttu-id="3a17e-126">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="3a17e-126">Calendar date picker</span></span>](calendar-date-picker.md)
- [<span data-ttu-id="3a17e-127">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="3a17e-127">Calendar view</span></span>](calendar-view.md)
- [<span data-ttu-id="3a17e-128">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="3a17e-128">Time picker</span></span>](time-picker.md)
