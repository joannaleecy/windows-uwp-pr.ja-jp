---
Description: Use a label to indicate to the user what they should enter into an adjacent control. You can also label a group of related controls, or display instructional text near a group of related controls.
title: ラベル
ms.assetid: CFACCCD4-749F-43FB-947E-2591AE673804
label: Labels
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4345daf5b879fed7ba9805e4a448c473299031d7
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7710943"
---
# <a name="labels"></a>ラベル

 

ラベルは、コントロールまたは関連するコントロールのグループの名前やタイトルです。

> **重要な API**: Header プロパティ、[TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/br209652)

XAML では、多くのコントロールに組み込みの Header プロパティがあり、これを使ってラベルを表示します。 Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) を使います。

![標準的なラベル コントロールを示すスクリーンショット](images/label-standard.png)

## <a name="recommendations"></a>推奨事項


-   隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。 また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。
-   コントロールにラベルを付ける場合、説明テキストの文ではなく、名詞や簡潔な名詞句のラベルを入力します。 コロン、その他の句読点は使わないでください。
-   ラベルに説明テキストを入力するときは、テキスト文字列を長くすることができ、句読点も使うことができます。


## <a name="get-the-sample-code"></a>サンプル コードを入手する
* [XAML UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)

## <a name="related-topics"></a>関連トピック
* [テキスト コントロール](text-controls.md)
* [TextBox.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn252861)
* [PasswordBox.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn299051)
* [ToggleSwitch.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/br209713)
* [DatePicker.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn279460)
* [TimePicker.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn299286)
* [Slider.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn252829)
* [ComboBox.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn279416)
* [RichEditBox.Header プロパティ](https://msdn.microsoft.com/library/windows/apps/dn252726)
* [TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/br209652)

 

 




