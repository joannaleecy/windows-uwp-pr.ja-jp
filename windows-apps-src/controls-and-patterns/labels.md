---
author: Jwmsft
Description: "隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。 また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。"
title: "ラベル"
ms.assetid: CFACCCD4-749F-43FB-947E-2591AE673804
label: Labels
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.openlocfilehash: 2a3f3d6795276df6e3436c5ae6eff42551d03478
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="labels"></a><span data-ttu-id="99bce-105">ラベル</span><span class="sxs-lookup"><span data-stu-id="99bce-105">Labels</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="99bce-106">ラベルは、コントロールまたは関連するコントロールのグループの名前やタイトルです。</span><span class="sxs-lookup"><span data-stu-id="99bce-106">A label is the name or title of a control or a group of related controls.</span></span>

> <span data-ttu-id="99bce-107">**重要な API**: Header プロパティ、[TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/br209652)</span><span class="sxs-lookup"><span data-stu-id="99bce-107">**Important APIs**: Header property, [TextBlock class](https://msdn.microsoft.com/library/windows/apps/br209652)</span></span>

<span data-ttu-id="99bce-108">XAML では、多くのコントロールに組み込みの Header プロパティがあり、これを使ってラベルを表示します。</span><span class="sxs-lookup"><span data-stu-id="99bce-108">In XAML, many controls have a built-in Header property that you use to display the label.</span></span> <span data-ttu-id="99bce-109">Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) を使います。</span><span class="sxs-lookup"><span data-stu-id="99bce-109">For controls that don't have a Header property, or to label groups of controls, you can use a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) instead.</span></span>

![標準的なラベル コントロールを示すスクリーンショット](images/label-standard.png)

## <a name="recommendations"></a><span data-ttu-id="99bce-111">推奨事項</span><span class="sxs-lookup"><span data-stu-id="99bce-111">Recommendations</span></span>


-   <span data-ttu-id="99bce-112">隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="99bce-112">Use a label to indicate to the user what they should enter into an adjacent control.</span></span> <span data-ttu-id="99bce-113">また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="99bce-113">You can also label a group of related controls, or display instructional text near a group of related controls.</span></span>
-   <span data-ttu-id="99bce-114">コントロールにラベルを付ける場合、説明テキストの文ではなく、名詞や簡潔な名詞句のラベルを入力します。</span><span class="sxs-lookup"><span data-stu-id="99bce-114">When labeling controls, write the label as a noun or a concise noun phrase, not as a sentence, and not as instructional text.</span></span> <span data-ttu-id="99bce-115">コロン、その他の句読点は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="99bce-115">Avoid colons or other punctuation.</span></span>
-   <span data-ttu-id="99bce-116">ラベルに説明テキストを入力するときは、テキスト文字列を長くすることができ、句読点も使うことができます。</span><span class="sxs-lookup"><span data-stu-id="99bce-116">When you do have instructional text in a label, you can be more generous with text-string length and also use punctuation.</span></span>


## <a name="get-the-sample-code"></a><span data-ttu-id="99bce-117">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="99bce-117">Get the sample code</span></span>
* [<span data-ttu-id="99bce-118">XAML UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="99bce-118">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)

## <a name="related-topics"></a><span data-ttu-id="99bce-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="99bce-119">Related topics</span></span>
* [<span data-ttu-id="99bce-120">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="99bce-120">Text controls</span></span>](text-controls.md)
* [<span data-ttu-id="99bce-121">TextBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-121">TextBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252861)
* [<span data-ttu-id="99bce-122">PasswordBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-122">PasswordBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299051)
* [<span data-ttu-id="99bce-123">ToggleSwitch.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-123">ToggleSwitch.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/br209713)
* [<span data-ttu-id="99bce-124">DatePicker.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-124">DatePicker.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279460)
* [<span data-ttu-id="99bce-125">TimePicker.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-125">TimePicker.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299286)
* [<span data-ttu-id="99bce-126">Slider.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-126">Slider.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252829)
* [<span data-ttu-id="99bce-127">ComboBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-127">ComboBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279416)
* [<span data-ttu-id="99bce-128">RichEditBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="99bce-128">RichEditBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252726)
* [<span data-ttu-id="99bce-129">TextBlock クラス</span><span class="sxs-lookup"><span data-stu-id="99bce-129">TextBlock class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209652)

 

 




