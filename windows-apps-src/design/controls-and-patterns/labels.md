---
author: Jwmsft
Description: Use a label to indicate to the user what they should enter into an adjacent control. You can also label a group of related controls, or display instructional text near a group of related controls.
title: ラベル
ms.assetid: CFACCCD4-749F-43FB-947E-2591AE673804
label: Labels
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: c17b2a539a01572bed984b86f72f5439896fac87
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6204777"
---
# <a name="labels"></a><span data-ttu-id="74543-103">ラベル</span><span class="sxs-lookup"><span data-stu-id="74543-103">Labels</span></span>

 

<span data-ttu-id="74543-104">ラベルは、コントロールまたは関連するコントロールのグループの名前やタイトルです。</span><span class="sxs-lookup"><span data-stu-id="74543-104">A label is the name or title of a control or a group of related controls.</span></span>

> <span data-ttu-id="74543-105">**重要な API**: Header プロパティ、[TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/br209652)</span><span class="sxs-lookup"><span data-stu-id="74543-105">**Important APIs**: Header property, [TextBlock class](https://msdn.microsoft.com/library/windows/apps/br209652)</span></span>

<span data-ttu-id="74543-106">XAML では、多くのコントロールに組み込みの Header プロパティがあり、これを使ってラベルを表示します。</span><span class="sxs-lookup"><span data-stu-id="74543-106">In XAML, many controls have a built-in Header property that you use to display the label.</span></span> <span data-ttu-id="74543-107">Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) を使います。</span><span class="sxs-lookup"><span data-stu-id="74543-107">For controls that don't have a Header property, or to label groups of controls, you can use a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) instead.</span></span>

![標準的なラベル コントロールを示すスクリーンショット](images/label-standard.png)

## <a name="recommendations"></a><span data-ttu-id="74543-109">推奨事項</span><span class="sxs-lookup"><span data-stu-id="74543-109">Recommendations</span></span>


-   <span data-ttu-id="74543-110">隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="74543-110">Use a label to indicate to the user what they should enter into an adjacent control.</span></span> <span data-ttu-id="74543-111">また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="74543-111">You can also label a group of related controls, or display instructional text near a group of related controls.</span></span>
-   <span data-ttu-id="74543-112">コントロールにラベルを付ける場合、説明テキストの文ではなく、名詞や簡潔な名詞句のラベルを入力します。</span><span class="sxs-lookup"><span data-stu-id="74543-112">When labeling controls, write the label as a noun or a concise noun phrase, not as a sentence, and not as instructional text.</span></span> <span data-ttu-id="74543-113">コロン、その他の句読点は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="74543-113">Avoid colons or other punctuation.</span></span>
-   <span data-ttu-id="74543-114">ラベルに説明テキストを入力するときは、テキスト文字列を長くすることができ、句読点も使うことができます。</span><span class="sxs-lookup"><span data-stu-id="74543-114">When you do have instructional text in a label, you can be more generous with text-string length and also use punctuation.</span></span>


## <a name="get-the-sample-code"></a><span data-ttu-id="74543-115">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="74543-115">Get the sample code</span></span>
* [<span data-ttu-id="74543-116">XAML UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="74543-116">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)

## <a name="related-topics"></a><span data-ttu-id="74543-117">関連トピック</span><span class="sxs-lookup"><span data-stu-id="74543-117">Related topics</span></span>
* [<span data-ttu-id="74543-118">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="74543-118">Text controls</span></span>](text-controls.md)
* [<span data-ttu-id="74543-119">TextBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-119">TextBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252861)
* [<span data-ttu-id="74543-120">PasswordBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-120">PasswordBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299051)
* [<span data-ttu-id="74543-121">ToggleSwitch.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-121">ToggleSwitch.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/br209713)
* [<span data-ttu-id="74543-122">DatePicker.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-122">DatePicker.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279460)
* [<span data-ttu-id="74543-123">TimePicker.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-123">TimePicker.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299286)
* [<span data-ttu-id="74543-124">Slider.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-124">Slider.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252829)
* [<span data-ttu-id="74543-125">ComboBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-125">ComboBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn279416)
* [<span data-ttu-id="74543-126">RichEditBox.Header プロパティ</span><span class="sxs-lookup"><span data-stu-id="74543-126">RichEditBox.Header property</span></span>](https://msdn.microsoft.com/library/windows/apps/dn252726)
* [<span data-ttu-id="74543-127">TextBlock クラス</span><span class="sxs-lookup"><span data-stu-id="74543-127">TextBlock class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209652)

 

 




