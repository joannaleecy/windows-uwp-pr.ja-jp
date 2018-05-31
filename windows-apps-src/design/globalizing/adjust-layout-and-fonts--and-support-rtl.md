---
author: stevewhims
Description: Design your app to support the layouts and fonts of multiple languages, including RTL (right-to-left) flow direction.
title: レイアウトやフォントの調整と RTL のサポート
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
ms.author: stwhi
ms.date: 11/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ローカライズの可否, ローカライズ, RTL, LTR
ms.localizationpriority: medium
ms.openlocfilehash: cf3a2d781dc916fbda9a9d6386dee4e2e6144873
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1673979"
---
# <a name="adjust-layout-and-fonts-and-support-rtl"></a>レイアウトやフォントの調整と RTL のサポート

RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを設計します。 テキストの方向はスクリプトに書き込みが行われて表示される方向であり、ページの UI 要素は目で走査されます。

## <a name="layout-guidelines"></a>レイアウトのガイドライン

ドイツ語やフィンランド語などの言語は通常、英語より多くの文字を使用します。 極東地域のフォントは通常、高さが必要です。 アラビア語やヘブライ語などの言語では、レイアウト パネルとテキスト要素を読む方向に合わせて右から左 (RTL) に配置する必要があります。

翻訳済みテキストの可変長のため、絶対配置、固定幅、固定高ではなく、動的な UI レイアウト メカニズムを使用する必要があります。 アプリを擬似言語でローカライズすると、UI 要素がコンテンツに合わせて正しくサイズ変更されないという、問題のあるエッジ ケースが明らかになります。

RTL 言語の場合、[**FrameworkElement.FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを使用し、左右対称のパディングと余白を設定します。 [**Grid**](/uwp/api/Windows.UI.Xaml.Controls.Grid?branch=live) などのレイアウト パネルは、設定した **FlowDirection** の値を使って自動的に拡大縮小と反転を行います。

アプリ内に、ローカライズ担当者が適切に設定できるリソースとして FlowDirection プロパティを表示する例を次に示します。

最初に、アプリのリソース ファイルの (.resw) で "MainPage.FlowDirection" という名前のプロパティ識別子を追加します ("MainPage" の代わりに任意の名前を使用できます)。

次に、**x:Uid** を使用して主要な **Page** 要素をこのプロパティ識別子に関連付けます。

```xaml
<Page x:Uid="MainPage">
```

リソース ファイル (.resw)、プロパティ識別子、**x:Uid** について詳しくは、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)」をご覧ください。

言語に基づいた UI 要素に絶対レイアウトの値を設定することは避ける必要があります。 ただし、どうしても避けることができない場合、フォーム "TitleText.Width" のプロパティ識別子を作成することができます。

```xaml
<TextBlock x:Uid="TitleText">
```

## <a name="fonts"></a>フォント

特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[**LanguageFont**](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live) フォント マッピング クラスを使ってください。 **LanguageFont** クラスを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。

## <a name="mirroring-images"></a>画像の左右反転

RTL に対応するために左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合は、**FlowDirection** を使用できます。

```xaml
<!-- en-US\localized.xaml -->
<Image ... FlowDirection="LeftToRight" />

<!-- ar-SA\localized.xaml -->
<Image ... FlowDirection="RightToLeft" />
```

画像を正しく反転させるためにアプリで別の画像が必要な場合は、`LayoutDirection` 修飾子 ([言語、スケール、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md#layoutdirection) の LayoutDirection セクションを参照) を指定してリソース管理システムを使用できます。 アプリのランタイム言語が RTL 言語に設定されている場合 (「[ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)」を参照)、システムは `file.layoutdir-rtl.png` という名前が付いたイメージを選びます。 画像の一部を反転させ、他の部分は反転させないという場合には、この方法が必要になることもあります。

## <a name="best-practices-for-handling-right-to-left-rtl-languages"></a>右から左に書く (RTL) 言語を処理するためのベスト プラクティス

アプリを右から左に書く (RTL) 言語にローカライズする場合、API を使用して Page のルート レイアウト パネルの既定のテキストの方向を設定します。 これにより、ルート パネルに含まれているすべてのコントロールが、既定のテキストの方向に適切に対応します。 複数の言語をサポートする場合は、最も優先順位が高いアプリの実行時の言語の `LayoutDirection` を使用して [**FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを設定します (以下のコード例を参照)。 Windows に含まれているほとんどのコントロールでは、既に **FlowDirection** が使われています。 カスタム コントロールを実装する場合は、**FlowDirection** を使って RTL 言語と LTR 言語で適切なレイアウト変更を行う必要があります。

```csharp    
this.languageTag = Windows.Globalization.ApplicationLanguages.Languages[0];

// For bidirectional languages, determine flow direction for the root layout panel, and all contained UI.

var flowDirectionSetting = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues["LayoutDirection"];
if (flowDirectionSetting == "LTR")
{
    this.layoutRoot.FlowDirection = Windows.UI.Xaml.FlowDirection.LeftToRight;
}
else
{
    this.layoutRoot.FlowDirection = Windows.UI.Xaml.FlowDirection.RightToLeft;
}
```

```cpp
this->languageTag = Windows::Globalization::ApplicationLanguages::Languages->GetAt(0);

// For bidirectional languages, determine flow direction for the root layout panel, and all contained UI.

auto flowDirectionSetting = Windows::ApplicationModel::Resources::Core::ResourceContext::GetForCurrentView()->QualifierValues->Lookup("LayoutDirection");
if (flowDirectionSetting == "LTR")
{
    this->layoutRoot->FlowDirection = Windows::UI::Xaml::FlowDirection::LeftToRight;
}
else
{
    this->layoutRoot->FlowDirection = Windows::UI::Xaml::FlowDirection::RightToLeft;
}
```

### <a name="rtl-faq"></a>RTL に関するよくある質問 

**Q:** **FlowDirection** は、現在の言語の選択に基づいて自動的に設定されますか? たとえば、英語を選択すると左から右へ、アラビア語を選択すると右から左へ表示されますか?

> **A:** **FlowDirection** には、言語によって動作を変える機能はありません。 開発者は、現在表示している言語に応じて **FlowDirection** を設定する必要があります。 上のサンプル コードを参照してください。

**Q:** ローカライズにあまり詳しくありません。 リソースには、テキストの方向があらかじめ含まれていますか? 現在の言語に基づいてテキストの方向を判断できますか?

> **A:** 現在のベスト プラクティスを使用している場合、リソースにはテキストの方向は含まれていません。 開発者は、現在の言語に応じてテキストの方向を決定する必要があります。 これには 2 つの方法があります。
> 
> 推奨されるのは、最も優先順位が高い言語の **LayoutDirection** を使用して、RootFrame の **FlowDirection** プロパティを設定する方法です。 RootFrame のすべてのコントロールは、RootFrame から FlowDirection を継承します。
> 
> もう 1 つは、ローカライズする RTL 言語の .resw ファイルで FlowDirection を設定する方法です。 たとえば、アラビア語にはアラビア語の resw ファイル、ヘブライ語にはヘブライ語の resw ファイルがあります。 これらのファイルで、x:UID を使用して FlowDirection を設定できます。 ただし、この方法はプログラムによる方法よりもエラーが発生しやすくなります。

## <a name="important-apis"></a>重要な API

* [FrameworkElement.FlowDirection](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection)
* [LanguageFont](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live)

## <a name="related-topics"></a>関連トピック

* [UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)
* [言語、スケール、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md)
* [ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)