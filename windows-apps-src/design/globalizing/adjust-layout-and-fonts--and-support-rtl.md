---
Description: Design your app to support the layouts and fonts of multiple languages, including RTL (right-to-left) flow direction.
title: レイアウトやフォントの調整と RTL のサポート
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
ms.date: 05/11/2018
ms.topic: article
keywords: Windows 10, UWP, ローカライズの可否, ローカライズ, RTL, LTR
ms.localizationpriority: medium
ms.openlocfilehash: e428dd068337ecd79992e8e27cd193bed112d9c2
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8793479"
---
# <a name="adjust-layout-and-fonts-and-support-rtl"></a>レイアウトやフォントの調整と RTL のサポート
RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを設計します。 テキストの方向はスクリプトに書き込みが行われて表示される方向であり、ページの UI 要素は目で走査されます。

## <a name="layout-guidelines"></a>レイアウトのガイドライン
ドイツ語やフィンランド語などの言語は通常、英語より多くの文字を使用します。 極東地域のフォントは通常、高さが必要です。 アラビア語やヘブライ語などの言語では、レイアウト パネルとテキスト要素を読む方向に合わせて右から左 (RTL) に配置する必要があります。

翻訳済みのテキストのメトリックでのこれらのバリエーションのため、絶対配置、固定幅、固定高をユーザー インターフェイス (UI) に組み込まないことをお勧めします。 代わりに、Windows UI 要素に組み込まれている動的なレイアウト メカニズムを利用します。 たとえば、コンテンツ コントロール (ボタンなど)、アイテム コントロール (グリッド ビューやリスト ビューなど)、レイアウト パネル (グリッドや StackPanel など) は自動的にサイズ変更され、既定ではコンテンツに合わせて再配置されます。 アプリを擬似言語でローカライズすると、UI 要素がコンテンツに合わせて正しくサイズ変更されないという、問題のあるエッジ ケースが明らかになります。

動的レイアウトは推奨される手法で、ほとんどの場合に使用することができます。 あまり好ましくありませんが、UI マークアップにサイズを組み込むことより望ましい方法として、レイアウト値を言語の関数として設定します。 アプリ内に、ローカライズ担当者が言語ごとに適切に設定できるリソースとして Width プロパティを表示する例を次に示します。 最初に、アプリのリソース ファイル (.resw) で "TitleText.Width" という名前のプロパティ識別子を追加します ("TitleText" の代わりに任意の名前を使用できます)。 次に、**x:Uid** を使用して 1 つ以上の UI 要素をこのプロパティ識別子に関連付けます。

```xaml
<TextBlock x:Uid="TitleText">
```

リソース ファイル (.resw)、プロパティ識別子、**x:Uid** の詳細については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)」を参照してください。

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

## <a name="handling-right-to-left-rtl-languages"></a>右から左に書く (RTL) 言語の処理
右から左に書く (RTL) 言語用にアプリをローカライズする場合、[**FrameworkElement.FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを使用し、左右対称のパディングと余白を設定します。 [**Grid**](/uwp/api/Windows.UI.Xaml.Controls.Grid?branch=live) などのレイアウト パネルは、設定した **FlowDirection** の値を使って自動的に拡大縮小と反転を行います。

Page のルート レイアウト パネル (フレーム) または Page 自体で **FlowDirection** を設定します。 これにより、内部に含まれるすべてのコントロールがそのプロパティを継承します。

> [!IMPORTANT]
> ただし、**FlowDirection** は Windows 設定のユーザーが選択した表示言語に基づいて自動的に設定されるものでは*なく*、ユーザーの表示言語の切り替えに応じて動的に変更されるものでもありません。 たとえば、ユーザーが Windows 設定を英語からアラビア語に切り替えた場合、**FlowDirection** プロパティは (左から右) から (右から左) に自動的に変更*されません*。 アプリ開発者は、現在表示している言語に応じて **FlowDirection** を設定する必要があります。

プログラムによる手法は、ユーザーの優先される表示言語の `LayoutDirection` プロパティを使用して [**FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを設定することです (以下のコード例を参照)。 Windows に含まれているほとんどのコントロールでは、既に **FlowDirection** が使われています。 カスタム コントロールを実装する場合は、**FlowDirection** を使って RTL 言語と LTR 言語で適切なレイアウト変更を行う必要があります。

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

```cppwinrt
#include <winrt/Windows.ApplicationModel.Resources.Core.h>
#include <winrt/Windows.Globalization.h>
...

m_languageTag = Windows::Globalization::ApplicationLanguages::Languages().GetAt(0);

// For bidirectional languages, determine flow direction for the root layout panel, and all contained UI.

auto flowDirectionSetting = Windows::ApplicationModel::Resources::Core::ResourceContext::GetForCurrentView().QualifierValues().Lookup(L"LayoutDirection");
if (flowDirectionSetting == L"LTR")
{
    layoutRoot().FlowDirection(Windows::UI::Xaml::FlowDirection::LeftToRight);
}
else
{
    layoutRoot().FlowDirection(Windows::UI::Xaml::FlowDirection::RightToLeft);
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

前に示した手法により **FlowDirection** がユーザーの優先される表示言語の `LayoutDirection` プロパティの関数になります。 何らかの理由でそのロジックを使用しない場合は、アプリ内に、ローカライズ担当者が翻訳対象の各言語用に適切に設定できるリソースとして FlowDirection プロパティを表示できます。

最初に、アプリのリソース ファイルの (.resw) で "MainPage.FlowDirection" という名前のプロパティ識別子を追加します ("MainPage" の代わりに任意の名前を使用できます)。 次に、**x:Uid** を使用して主要な **Page** 要素 (またはそのルート レイアウト パネルかフレーム) をこのプロパティ識別子に関連付けます。

```xaml
<Page x:Uid="MainPage">
```

すべての言語で単一コード行を使用する代わりに、この手法は、翻訳者が翻訳される各言語用にこのプロパティ リソースを正しく "翻訳する" ことに依存します。そのため、この手法を使用する場合は、余分な人的ミスが生じることに注意してください。

## <a name="important-apis"></a>重要な API
* [FrameworkElement.FlowDirection](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection)
* [LanguageFont](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live)

## <a name="related-topics"></a>関連トピック
* [UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)
* [言語、スケール、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md)
* [ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)