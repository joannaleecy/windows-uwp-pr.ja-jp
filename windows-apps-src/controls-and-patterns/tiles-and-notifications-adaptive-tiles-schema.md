---
author: mijacobs
Description: "アダプティブ タイルの作成に使う要素と属性を次に示します。"
title: "アダプティブ タイル スキーマとテンプレート"
ms.assetid: 858FB05E-87A2-49CF-BE48-570980AD36C8
label: Adaptive tile schema and templates
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: eb6744968a4bf06a3766c45b73b428ad690edc06
ms.openlocfilehash: 08bdb46dba6fc93ada20b3fc585d3e24e29023a0

---
# アダプティブ タイル テンプレート: スキーマとガイダンス

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

アダプティブ タイルの作成に使う要素と属性を次に示します。 手順と例については、「[アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)」をご覧ください。

## tile 要素


``` xml
<tile>
  
  <!-- Child elements -->
  visual
  
</tile>
```

## visual 要素


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

## binding 要素


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

## image 要素


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

## text 要素


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

textStyle の値: caption captionSubtle body bodySubtle base baseSubtle subtitle subtitleSubtle title titleSubtle titleNumeral subheader subheaderSubtle subheaderNumeral header headerSubtle headerNumber

## group 要素


``` xml
<group>

  <!-- Child elements -->
  subgroup+

</group>
```

## subgroup 要素


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

## 関連トピック


* [アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)
 

 







<!--HONumber=Aug16_HO3-->


