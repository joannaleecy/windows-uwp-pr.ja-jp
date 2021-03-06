---
Description: 隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。 また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。
title: ラベル
ms.assetid: CFACCCD4-749F-43FB-947E-2591AE673804
label: Labels
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4345daf5b879fed7ba9805e4a448c473299031d7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654147"
---
# <a name="labels"></a>ラベル

 

ラベルは、コントロールまたは関連するコントロールのグループの名前やタイトルです。

> **重要な API**:ヘッダーのプロパティ、 [TextBlock クラス](https://msdn.microsoft.com/library/windows/apps/br209652)

XAML では、多くのコントロールに組み込みの Header プロパティがあり、これを使ってラベルを表示します。 Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) を使います。

![標準的なラベル コントロールを示すスクリーンショット](images/label-standard.png)

## <a name="recommendations"></a>推奨事項


-   隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。 また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。
-   コントロールにラベルを付ける場合、説明テキストの文ではなく、名詞や簡潔な名詞句のラベルを入力します。 コロン、その他の句読点は使わないでください。
-   ラベルに説明テキストを入力するときは、テキスト文字列を長くすることができ、句読点も使うことができます。


## <a name="get-the-sample-code"></a>サンプル コードを入手する
* [XAML UI の基本サンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)

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

 

 




