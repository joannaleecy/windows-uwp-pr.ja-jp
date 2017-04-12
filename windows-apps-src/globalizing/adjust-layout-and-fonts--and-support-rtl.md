---
author: DelfCo
Description: "RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。"
title: "レイアウトやフォントの調整と RTL のサポート"
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
ms.author: bobdel
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 9c700928d2ec0da21b518528289034296637eeff
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="adjust-layout-and-fonts-and-support-rtl"></a>レイアウトやフォントの調整と RTL のサポート
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを開発します。

## <a name="layout-guidelines"></a>レイアウトのガイドライン


ドイツ語やフィンランド語など、一部の言語ではテキストに英語より多くのスペースが必要です。 日本語などのいくつかの言語のフォントでは高さが必要です。 アラビア語やヘブライ語などの一部の言語では、テキスト レイアウトとアプリ レイアウトを読む方向に合わせて右から左 (RTL) にする必要があります。

絶対配置、固定幅、固定高ではなく、可変レイアウト メカニズムを使ってください。 必要があれば、言語に応じて特定の UI 要素を調整できます。

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


## <a name="mirroring-images"></a>画像の左右反転

RTL に対応するために左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合は、次のように [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) プロパティを適用できます。

```XML
<!-- en-US\localized.xaml -->
<Image ... FlowDirection="LeftToRight" />

<!-- ar-SA\localized.xaml -->
<Image ... FlowDirection="RightToLeft" />
```


画像を正しく反転させるためにアプリで別の画像が必要な場合は、[layoutdir 修飾子](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)を指定してリソース管理システムを使うことができます。 [アプリケーション言語](manage-language-and-region.md) が RTL 言語に設定されている場合、システムは file.layoutdir-rtl.png という名前が付いた画像を選びます。 画像の一部を反転させ、他の部分は反転させないという場合には、この方法が必要になることもあります。

## <a name="fonts"></a>フォント

特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[**LanguageFont**](https://msdn.microsoft.com/library/windows/apps/br206864) フォント マッピング API を使ってください。 **LanguageFont** オブジェクトを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。

## <a name="best-practices-for-handling-right-to-left-rtl-languages"></a>右から左に書く (RTL) 言語を処理するためのベスト プラクティス

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
```
    // Get preferred app language
    m_language = Windows::Globalization::ApplicationLanguages::Languages->GetAt(0);
     
    // Set flow direction accordingly
    m_flowDirection = ResourceManager::Current->DefaultContext->QualifierValues->Lookup("LayoutDirection") != "LTR" ? 
       FlowDirection::RightToLeft : FlowDirection::LeftToRight;
```


### <a name="rtl-faq"></a>RTL に関するよくある質問 

<dl>
  <dt> <p><b>Q:</b> <b>FlowDirection</b> は、現在の言語の選択に基づいて自動的に設定されますか? たとえば、英語を選択すると左から右へ、アラビア語を選択すると右から左へ表示されますか?</p></dt>

  <dd><p><b>A:</b> <b>FlowDirection</b> には、言語によって動作を変える機能はありません。 開発者は、現在表示している言語に応じて <b>FlowDirection</b>を設定する必要があります。 上のサンプル コードをご覧ください</p></dd> 

  <dt> <p><b>Q:</b> ローカライズにあまり詳しくありません。 リソースには、テキストの方向があらかじめ含まれていますか? 現在の言語に基づいてテキストの方向を判断できますか?</p></dt>

  <dd> <p><b>A:</b> 現在のベスト プラクティスを使用している場合、リソースにはテキストの方向は含まれていません。 開発者は、現在の言語に応じてテキストの方向を決定する必要があります。 これには 2 つの方法があります。 </p>
   <p>推奨されるのは、最も優先順位が高い言語の LayoutDirection を使用して、RootFrame の FlowDirection プロパティを設定する方法です。 RootFrame のすべてのコントロールは、RootFrame から FlowDirection を継承します。</p>
   <p>もう 1 つは、ローカライズする RTL 言語の resw ファイルで FlowDirection を設定する方法です。 たとえば、アラビア語にはアラビア語の resw ファイル、ヘブライ語にはヘブライ語の resw ファイルがあります。 これらのファイルで、x:UID を使用して FlowDirection を設定できます。 ただし、この方法はプログラムによる方法よりもエラーが発生しやすくなります。</p></dd>
</dl>


## <a name="related-topics"></a>関連トピック
[FlowDirection](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.flowdirection.aspx)
