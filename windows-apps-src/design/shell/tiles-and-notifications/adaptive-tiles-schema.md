---
Description: アダプティブ タイルの作成に使う要素と属性を次に示します。
title: アダプティブ タイル スキーマとテンプレート
ms.assetid: 858FB05E-87A2-49CF-BE48-570980AD36C8
label: Adaptive tile schema and templates
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: ed9124b0b66239c10b277f070ac2c9594c336fdd
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57611017"
---
# <a name="adaptive-tile-templates-schema-and-guidance"></a><span data-ttu-id="4af10-104">アダプティブ タイル テンプレート: スキーマとガイダンス</span><span class="sxs-lookup"><span data-stu-id="4af10-104">Adaptive tile templates: schema and guidance</span></span>

 

<span data-ttu-id="4af10-105">アダプティブ タイルの作成に使う要素と属性を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4af10-105">Here are the elements and attributes you use to create adaptive tiles.</span></span> <span data-ttu-id="4af10-106">手順と例については、「[アダプティブ タイルの作成](create-adaptive-tiles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4af10-106">For instructions and examples, see [Create adaptive tiles](create-adaptive-tiles.md).</span></span>

## <a name="tile-element"></a><span data-ttu-id="4af10-107">tile 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-107">tile element</span></span>


``` xml
<tile>
  
  <!-- Child elements -->
  visual
  
</tile>
```

## <a name="visual-element"></a><span data-ttu-id="4af10-108">visual 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-108">visual element</span></span>


``` xml
<visual
  version? = integer
  lang? = string
  baseUri? = anyURI
  branding? = "none" | "logo" | "name" | "nameAndLogo"
  addImageQuery? = boolean
  contentId? = string
  displayName? = string >
    
  <!-- Child elements -->
  binding+

</visual>
```

## <a name="binding-element"></a><span data-ttu-id="4af10-109">binding 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-109">binding element</span></span>


``` xml
<binding
  template = tileTemplateNameV3
  fallback? = tileTemplateNameV1
  lang? = string
  baseUri? = anyURI
  branding? = "none" | "logo" | "name" | "nameAndLogo"
  addImageQuery? = boolean
  contentId? = string
  displayName? = string
  hint-textStacking? = "top" | "center" | "bottom"
  hint-overlay? = [0-100] >

  <!-- Child elements -->
  ( image
  | text
  | group
  )*

</binding>
```

## <a name="image-element"></a><span data-ttu-id="4af10-110">image 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-110">image element</span></span>


``` xml
<image
  src = string
  placement? = "inline" | "background" | "peek"
  alt? = string
  addImageQuery? = boolean
  hint-crop? = "none" | "circle"
  hint-removeMargin? = boolean
  hint-align? = "stretch" | "left" | "center" | "right" />
```

## <a name="text-element"></a><span data-ttu-id="4af10-111">text 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-111">text element</span></span>


``` xml
<text
  lang? = string
  hint-style? = textStyle
  hint-wrap? = boolean
  hint-maxLines? = integer
  hint-minLines? = integer
  hint-align? = "left" | "center" | "right" >

  <!-- text goes here -->

</text>
```

<span data-ttu-id="4af10-112">textStyle の値: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumeral</span><span class="sxs-lookup"><span data-stu-id="4af10-112">textStyle values: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumeral</span></span>

## <a name="group-element"></a><span data-ttu-id="4af10-113">group 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-113">group element</span></span>


``` xml
<group>

  <!-- Child elements -->
  subgroup+

</group>
```

## <a name="subgroup-element"></a><span data-ttu-id="4af10-114">subgroup 要素</span><span class="sxs-lookup"><span data-stu-id="4af10-114">subgroup element</span></span>


``` xml
<subgroup
  hint-weight? = [0-100]
  hint-textStacking? = "top" | "center" | "bottom" >

  <!-- Child elements -->
  ( text
  | image
  )*

</subgroup>
```

## <a name="related-topics"></a><span data-ttu-id="4af10-115">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4af10-115">Related topics</span></span>


* [<span data-ttu-id="4af10-116">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="4af10-116">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
 

 




