---
author: DelfCo
Description: "RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。"
title: "レイアウトやフォントの調整と RTL のサポート"
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: 5255da14ccdd0aed3852c41fa662de63a7160fba
ms.openlocfilehash: b45029156a28afdb37d7ac1402d1e6ae845b0e63

---

# レイアウトやフォントの調整と RTL のサポート





RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。

## レイアウトのガイドライン


ドイツ語やフィンランド語など、一部の言語ではテキストに英語より多くのスペースが必要です。 日本語などのいくつかの言語のフォントでは高さが必要です。 アラビア語やヘブライ語などの一部の言語では、テキスト レイアウトとアプリ レイアウトを読む方向に合わせて右から左 (RTL) にする必要があります。

絶対配置、固定幅、固定高ではなく、可変レイアウト メカニズムを使ってください。 必要があれば、言語に応じて特定の UI 要素を調整できます。

### XAML

要素に **Uid** を指定します。

```XML
<TextBlock x:Uid="Block1">
```

アプリの ResW ファイルには、ローカライズする言語ごとに設定できる Block1.Width のリソースを含めるようにします。

C++、C\#、または Visual Basic を使った Windows ストア アプリの場合、左右対称のパディング、余白と共に [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを使い、他のレイアウト方向のローカライズを有効にできます。

[**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) などの XAML レイアウト コントロールは、[**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを使って自動的に拡大縮小と反転を行います。 アプリ内に、独自の **FlowDirection** プロパティをローカライズ担当者用のリソースとして表示します。

アプリのメイン ページには **Uid** を指定します。

```XML
<Page x:Uid="MainPage">
```

アプリの **ResW** ファイルには、ローカライズする言語ごとに設定できる MainPage.FlowDirection のリソースを含めるようにします。

### HTML

JavaScript を使った Windows ストア アプリの場合は、[-ms-grid](https://msdn.microsoft.com/library/ms531209) や [– ms-box](https://msdn.microsoft.com/en-us/library/windows/apps/hh465453.aspx#g_section) などの [カスケード スタイル シート (CSS)](https://msdn.microsoft.com/en-us/library/windows/apps/hh465453.aspx#f_section) レイアウト メカニズムを使ってください。 さまざまなレイアウト方向のローカライズには、左右対称のパディングと余白を使います。

このほか、アプリの言語に応じて [**:-ms-lang()**](https://msdn.microsoft.com/library/cc848867) 擬似クラス セレクターを使って特定の要素の幅などの CSS プロパティを調整できます。 アプリ ホスティング プロセスは、これを有効にするためにルート要素の **lang** 属性をアプリ言語に設定します。

**CSS**
```CSS
.item:-ms-lang(de, fi) { width: 350px; }
```

JavaScript を使った Windows ストア アプリで ui-light.css または ui-dark.css スタイル シートを使うと、アプリ言語に応じて本文レイアウトの方向が自動的に設定されます。 ui-light.css と ui-dark.css では次の CSS が用意されているため、開発者自身で記述する必要はありません。

**CSS**
```CSS
body:-ms-lang(ar,he…) { direction: rtl;}
```

つまり、システムで RTL (右から左) 言語が使われる場合、ほとんどのアプリ レイアウトは正しく設定されます。

[WinJS.UI](https://msdn.microsoft.com/library/windows/apps/br229782) コントロールと同様に、アプリで [**:-ms-lang()**](https://msdn.microsoft.com/library/cc848867) 擬似クラス セレクターを使って、**margin** や **padding** などの物理的な CSS プロパティを調整できます。 **after** や **before** などのキーワードを使う論理的な CSS プロパティを調整する必要はありません。

HTML では **align** プロパティまたは属性を使わないでください。 代わりに、**direction** プロパティを使って個々のコンポーネントの配置を制御できます。

CSS での垂直テキスト レイアウトのサポートには、[**writing-mode**](https://msdn.microsoft.com/library/ms531187) プロパティを使ってください。

## 画像の左右反転


### XAML

RTL に対応するために左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合は、次のように [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを適用できます。

```XML
<!-- en-US\localized.xaml -->
<Image ... FlowDirection="LeftToRight" />

<!-- ar-SA\localized.xaml -->
<Image ... FlowDirection="RightToLeft" />
```

### HTML

RTL に対応するため左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合には、レンダリング時に CSS 変換を使って要素に .mirrorable クラスを追加して、次の CSS クラスを追加することにより、画像の左右反転を行ってください。

```CSS
.mirrorable { transform: scaleX(-1); }
```

**XAML と HTML の両方:** 画像を正しく反転させるためにアプリで別の画像が必要な場合は、[layoutdir 修飾子](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)を指定してリソース管理システムを使うことができます。 [アプリケーション言語](manage-language-and-region.md) が RTL 言語に設定されている場合、システムは file.layoutdir-rtl.png という名前が付いた画像を選びます。 画像の一部を反転させ、他の部分は反転させないという場合には、この方法が必要になることもあります。

## フォント


**XAML と HTML の両方:** 特定言語の推奨フォント ファミリ、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[**LanguageFont**](https://msdn.microsoft.com/library/windows/apps/br206864) フォント マッピング API を使ってください。 **LanguageFont** オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。

### HTML

JavaScript を使った Windows ストア アプリで ui-light.css または ui-dark.css スタイル シートを使うと、アプリ言語に応じてフォント セットが自動的に最も適切なフォントに設定されます。 アプリ ホスティング プロセスは、ルート要素の **lang** 属性をアプリ言語に設定します。

単一のページに複数の言語を表示するアプリは、各言語のセクションに **lang** 属性を設定する必要があります。 [**:-ms-lang()**](https://msdn.microsoft.com/library/cc848867) 擬似クラス セレクターは、ページのセクションごとに正しいフォントを選びます。

## 右から左に書く (RTL) 言語を処理するためのベスト プラクティス

アプリを右から左に書く (RTL) 言語にローカライズする場合、API を使用して RootFrame の既定のテキストの方向を設定します。 これにより、RootFrame に含まれているすべてのコントロールが、既定のテキストの方向に適切に対応します。  複数の言語をサポートする場合は、最も優先順位が高い言語の LayoutDirection を使用して FlowDirection プロパティを設定します。 Windows に含まれているほとんどのコントロールでは、既に FlowDirection が使われています。 カスタム コントロールを実装する場合は、FlowDirection を使って RTL 言語と LTR 言語で適切なレイアウト変更を行う必要があります。

C#
```csharp    
// For bidirectional languages, determine flow direction for RootFrame and all derived UI.

    string resourceFlowDirection = ResourceContext.GetForCurrentView().QualifierValues["LayoutDirection"];
    if (resourceFlowDirection == "LTR")
    {
       RootFrame.FlowDirection = FlowDirection.LeftToRight;
    }
    else
    {
       RootFrame.FlowDirection = FlowDirection.RightToLeft;
    }
```
C++:
```cpp
    // Get preferred app language
    m_language = Windows::Globalization::ApplicationLanguages::Languages->GetAt(0);
     
    // Set flow direction accordingly
    m_flowDirection = ResourceManager::Current->DefaultContext->QualifierValues->Lookup("LayoutDirection") != "LTR" ? 
       FlowDirection::RightToLeft : FlowDirection::LeftToRight;
```


### RTL に関するよくある質問 

<dl>
  <dt> <p><b>Q:</b><b>FlowDirection</b> は、現在の言語の選択に基づいて自動的に設定されるのですか? たとえば、英語を選択すると左から右へ、アラビア語を選択すると右から左へ表示されますか?</p></dt>

  <dd><p><b>A:</b> <b>FlowDirection</b> には、言語によって動作を変える機能はありません。 開発者は、現在表示している言語に応じて <b>FlowDirection</b>を設定する必要があります。 上のサンプル コードをご覧ください</p></dd> 

  <dt> <p><b>Q:</b>ローカライズにあまり詳しくありません。 リソースには、テキストの方向があらかじめ含まれていますか? 現在の言語に基づいてテキストの方向を判断できますか?</p></dt>

  <dd> <p><b>A:</b> 現在のベスト プラクティスを使用している場合、リソースにはテキストの方向は含まれていません。 開発者は、現在の言語に応じてテキストの方向を決定する必要があります。 これには 2 つの方法があります。 </p>
   <p>推奨されるのは、最も優先順位が高い言語の LayoutDirection を使用して、RootFrame の FlowDirection プロパティを設定する方法です。 RootFrame のすべてのコントロールは、RootFrame から FlowDirection を継承します。</p>
   <p>もう 1 つは、ローカライズする RTL 言語の resw ファイルで FlowDirection を設定する方法です。 たとえば、アラビア語にはアラビア語の resw ファイル、ヘブライ語にはヘブライ語の resw ファイルがあります。 これらのファイルで、x:UID を使用して FlowDirection を設定できます。 ただし、この方法はプログラムによる方法よりもエラーが発生しやすくなります。</p></dd>
</dl>


## 関連トピック
[FlowDirection](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.flowdirection.aspx)



<!--HONumber=Aug16_HO3-->


