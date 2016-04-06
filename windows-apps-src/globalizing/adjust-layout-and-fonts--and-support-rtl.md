---
Description: description: RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。
title: title: レイアウトやフォントの調整と RTL のサポート
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
---

# ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3


label: レイアウトやフォントの調整と RTL のサポート template: detail.hbs


レイアウトやフォントの調整と RTL のサポート

## \[ Windows 10 の UWP アプリ向けに更新。


Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \] RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。 <span id="Layout_guidelines"></span><span id="layout_guidelines"></span><span id="LAYOUT_GUIDELINES"></span>レイアウトのガイドライン

ドイツ語やフィンランド語など、一部の言語ではテキストに英語より多くのスペースが必要です。 日本語などのいくつかの言語のフォントでは高さが必要です。

### アラビア語やヘブライ語などの一部の言語では、テキスト レイアウトとアプリ レイアウトを読む方向に合わせて右から左 (RTL) にする必要があります。

絶対配置、固定幅、固定高ではなく、可変レイアウト メカニズムを使ってください。

```XAML
<TextBlock x:Uid="Block1">
```

必要があれば、言語に応じて特定の UI 要素を調整できます。

<span id="XAML"></span><span id="xaml"></span>XAML

要素に **Uid** を指定します。 アプリの ResW ファイルには、ローカライズする言語ごとに設定できる Block1.Width のリソースを含めるようにします。

C++、C\#、または Visual Basic を使った Windows ストア アプリの場合、左右対称のパディング、余白と共に [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを使い、他のレイアウト方向のローカライズを有効にできます。

```XAML
<Page x:Uid="MainPage">
```

[
            **Grid**](https://msdn.microsoft.com/library/windows/apps/br242704) などの XAML レイアウト コントロールは、[**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを使って自動的に拡大縮小と反転を行います。

### アプリ内に、独自の **FlowDirection** プロパティをローカライズ担当者用のリソースとして表示します。

アプリのメイン ページには **Uid** を指定します。 アプリの **ResW** ファイルには、ローカライズする言語ごとに設定できる MainPage.FlowDirection のリソースを含めるようにします。

<span id="HTML"></span><span id="html"></span>HTML JavaScript を使った Windows ストア アプリの場合は、[-ms-grid](https://msdn.microsoft.com/library/ms531209) や [– ms-box](https://msdn.microsoft.com/en-us/library/windows/apps/hh465453.aspx#g_section) などの [カスケード スタイル シート (CSS)](https://msdn.microsoft.com/en-us/library/windows/apps/hh465453.aspx#f_section) レイアウト メカニズムを使ってください。

**さまざまなレイアウト方向のローカライズには、左右対称のパディングと余白を使います。**
```CSS
.item:-ms-lang(de, fi) { width: 350px; }
```

このほか、アプリの言語に応じて [**:-ms-lang()**](https://msdn.microsoft.com/library/cc848867) 擬似クラス セレクターを使って特定の要素の幅などの CSS プロパティを調整できます。 アプリ ホスティング プロセスは、これを有効にするためにルート要素の **lang** 属性をアプリ言語に設定します。

**CSS**
```CSS
body:-ms-lang(ar,he…) { direction: rtl;}
```

JavaScript を使った Windows ストア アプリで ui-light.css または ui-dark.css スタイル シートを使うと、アプリ言語に応じて本文レイアウトの方向が自動的に設定されます。

ui-light.css と ui-dark.css では次の CSS が用意されているため、開発者自身で記述する必要はありません。 CSS

つまり、システムで RTL (右から左) 言語が使われる場合、ほとんどのアプリ レイアウトは正しく設定されます。 [WinJS.UI](https://msdn.microsoft.com/library/windows/apps/br229782) コントロールと同様に、アプリで [**:-ms-lang()**](https://msdn.microsoft.com/library/cc848867) 擬似クラス セレクターを使って、**margin** や **padding** などの物理的な CSS プロパティを調整できます。

**after** や **before** などのキーワードを使う論理的な CSS プロパティを調整する必要はありません。

## HTML では **align** プロパティまたは属性を使わないでください。


### 代わりに、**direction** プロパティを使って個々のコンポーネントの配置を制御できます。

CSS での垂直テキスト レイアウトのサポートには、[**writing-mode**](https://msdn.microsoft.com/library/ms531187) プロパティを使ってください。

```XAML
<!-- en-US\localized.xaml -->
<Image ... FlowDirection="LeftToRight" />

<!-- ar-SA\localized.xaml -->
<Image ... FlowDirection="RightToLeft" />
```

### <span id="Mirroring_images"></span><span id="mirroring_images"></span><span id="MIRRORING_IMAGES"></span>画像の左右反転

<span id="XAML"></span><span id="xaml"></span>XAML

```CSS
.mirrorable { transform: scaleX(-1); }
```

RTL に対応するために左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合は、次のように [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを適用できます。 <span id="HTML"></span><span id="html"></span>HTML RTL に対応するため左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合には、レンダリング時に CSS 変換を使って要素に .mirrorable クラスを追加して、次の CSS クラスを追加することにより、画像の左右反転を行ってください。

## **XAML と HTML の両方:** 画像を正しく反転させるためにアプリで別の画像が必要な場合は、[layoutdir 修飾子](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324) を指定してリソース管理システムを使うことができます。


[アプリケーション言語](manage-language-and-region.md) が RTL 言語に設定されている場合、システムは file.layoutdir-rtl.png という名前が付いた画像を選びます。 画像の一部を反転させ、他の部分は反転させないという場合には、この方法が必要になることもあります。

### <span id="Fonts"></span><span id="fonts"></span><span id="FONTS"></span>フォント

**XAML と HTML の両方:** 特定言語の推奨フォント ファミリ、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[**LanguageFont**](https://msdn.microsoft.com/library/windows/apps/br206864) フォント マッピング API を使ってください。 **LanguageFont** オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。

<span id="HTML"></span><span id="html"></span>HTML JavaScript を使った Windows ストア アプリで ui-light.css または ui-dark.css スタイル シートを使うと、アプリ言語に応じてフォント セットが自動的に最も適切なフォントに設定されます。

 

 





<!--HONumber=Mar16_HO4-->


