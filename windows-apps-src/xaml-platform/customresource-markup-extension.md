---
description: カスタム リソース検索の実装から取得されたリソースの参照を評価して、任意の XAML 属性の値を提供します。 リソース検索は、CustomXamlResourceLoader クラスの実装によって実行されます。
title: CustomResource マークアップ拡張
ms.assetid: 3A59A8DE-E805-4F04-B9D9-A91E053F3642
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 7eabcb188aa1687d36d4b4e6f432783aa68969de
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613247"
---
# <a name="customresource-markup-extension"></a>{CustomResource} マークアップ拡張


カスタム リソース検索の実装から取得されたリソースの参照を評価して、任意の XAML 属性の値を提供します。 リソース検索は、[**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) クラスの実装によって実行されます。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object property="{CustomResource key}" .../>
```

## <a name="xaml-values"></a>XAML 値

| 用語 | 説明 |
|------|-------------|
| key | 要求されたリソースのキー。 キーが最初にどのように割り当てられるかは、現在使用が登録されている [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) クラスの実装に固有のものです。 |

## <a name="remarks"></a>注釈

**CustomResource** は、カスタム リソース リポジトリのどこかで定義されている値を取得するための手法です。 この手法は比較的高度なものであり、Windows ランタイム アプリのほとんどのシナリオでは使われていません。

**CustomResource** がどのようにリソース辞書に解決されるかについては、[**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) の実装方法によって異なるため、このトピックでは説明しません。

[  **CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) 実装の [**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) メソッドは、Windows ランタイム XAML パーサーがマークアップ内で `{CustomResource}` の使用を検出するたびに呼び出されます。 **GetResource** に渡される *resourceId* は *key* 引数から与えられ、他の入力パラメーターはコンテキスト (たとえば、使用が適用されたプロパティ) から与えられます。

`{CustomResource}` の使用は既定では機能しません ([**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) の基本実装が不完全です)。 `{CustomResource}` の有効な参照を行うには、次の各手順を実行する必要があります。

1.  [  **CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) からカスタム クラスを派生し、[**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) メソッドをオーバーライドします。 実装で基本メソッドを呼び出さないでください。
2.  初期化ロジックでクラスを参照するために [**CustomXamlResourceLoader.Current**](https://msdn.microsoft.com/library/windows/apps/br243328) を設定します。 これは、`{CustomResource}` 拡張の使用が含まれるページ レベルの XAML が読み込まれる前に行う必要があります。 **CustomXamlResourceLoader.Current** を設定する場所の 1 つは、App.xaml コード ビハインド テンプレートで生成される [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) サブクラス コンストラクター内です。
3.  これで、アプリでページとして読み込む XAML 内で、XAML リソース ディクショナリ内から、`{CustomResource}` 拡張を使うことができます。

**CustomResource** はマークアップ拡張です。 通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。 XAML の使用中のすべてのマークアップ拡張機能、"\{「と」\}"XAML プロセッサがマークアップ拡張機能が、属性を処理する必要がありますを認識する規則は、それぞれの属性構文内の文字。

## <a name="related-topics"></a>関連トピック

* [ResourceDictionary と XAML のリソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)
* [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327)
* [**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340)

