---
author: Jwmsft
Description: "隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。 また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。"
title: "ラベル"
ms.assetid: CFACCCD4-749F-43FB-947E-2591AE673804
label: Labels
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: 6757e612d5a04db52222cfb73c855a0a4f615bf6

---
# <a name="labels"></a>ラベル

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

ラベルは、コントロールまたは関連するコントロールのグループの名前やタイトルです。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>Header プロパティ</li>
<li>[**TextBlock クラス**](https://msdn.microsoft.com/library/windows/apps/br209652)</li>
</ul>
</div>


XAML では、多くのコントロールに組み込みの Header プロパティがあり、これを使ってラベルを表示します。 Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) を使います。


## <a name="example"></a>例


![標準的なラベル コントロールを示すスクリーンショット](images/label-standard.png)

## <a name="recommendations"></a>推奨事項


-   隣接するコントロールに入力する必要がある内容をユーザーに説明するためにラベルを使います。 また、関連するコントロールのグループにラベルを付けることや、関連するコントロールのグループの近くに説明テキストを表示することができます。
-   コントロールにラベルを付ける場合、説明テキストの文ではなく、名詞や簡潔な名詞句のラベルを入力します。 コロン、その他の句読点は使わないでください。
-   ラベルに説明テキストを入力するときは、テキスト文字列を長くすることができ、句読点も使うことができます。


## <a name="get-the-sample-code"></a>サンプル コードを入手する
* [XAML UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)

## <a name="related-topics"></a>関連トピック
* [テキスト コントロール](text-controls.md)

**開発者向け**
* [**TextBox.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn252861)
* [**PasswordBox.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn299051)
* [**ToggleSwitch.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/br209713)
* [**DatePicker.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn279460)
* [**TimePicker.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn299286)
* [**Slider.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn252829)
* [**ComboBox.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn279416)
* [**RichEditBox.Header プロパティ**](https://msdn.microsoft.com/library/windows/apps/dn252726)
* [**TextBlock クラス**](https://msdn.microsoft.com/library/windows/apps/br209652)

 

 







<!--HONumber=Dec16_HO2-->


