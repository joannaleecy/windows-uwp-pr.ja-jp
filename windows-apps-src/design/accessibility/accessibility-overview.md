---
author: Xansky
Description: This article is an overview of the concepts and technologies related to accessibility scenarios for Universal Windows Platform (UWP) apps.
ms.assetid: AA053196-F331-4CBE-B032-4E9CBEAC699C
title: アクセシビリティの概要
label: Accessibility overview
template: detail.hbs
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e627cc4ad9918afeabfc61544872169425bd98a3
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5696883"
---
# <a name="accessibility-overview"></a>アクセシビリティの概要  




この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリのアクセシビリティ シナリオに関連する概念とテクノロジの概要を示します。

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Developing-Apps-for-Accessibility/player]

<span id="Accessibility_and_your_app"/>
<span id="accessibility_and_your_app"/>
<span id="ACCESSIBILITY_AND_YOUR_APP"/>

## <a name="accessibility-and-your-app"></a>アクセシビリティとアプリ  
障碍には、運動障碍、視覚障碍、色覚障碍、聴覚障碍、言語障碍、認知障碍、学習障碍など、さまざまな種類がありますが、 ここで紹介するガイドラインに従うことで、そのほとんどの要件に対処できます。 具体的には、次のものを提供します。

* キーボード操作とスクリーン リーダーのサポート
* フォント、ズーム設定 (拡大)、色、ハイ コントラスト設定など、ユーザーによるカスタマイズのサポート
* 一部の UI の代わりに利用できる手段やそれを補う手段

XAML 向けのコントロールには、キーボードのサポートと、スクリーン リーダーなどの支援技術のサポートが組み込まれています。これらのサポートでは、UWP アプリや HTML などの他の UI テクノロジが既にサポートされたアクセシビリティ フレームワークを利用します。 この組み込みのサポートを使えば、基本的なアクセシビリティをサポートし、いくつかのプロパティを設定するだけでカスタマイズできます。 また、独自のカスタム XAML コンポーネントやコントロールを作成している場合は、*オートメーション ピア*の概念を使って、同様のサポートをそれらのコントロールに追加することもできます。

さらに、データ バインディング、スタイル、テンプレートなどの機能を使うと、表示設定や代替 UI のテキストの動的な変更に簡単に対応できます。

<span id="UI_Automation"/>
<span id="ui_automation"/>
<span id="UI_AUTOMATION"/>

## <a name="ui-automation"></a>UI オートメーション  
アクセシビリティ サポートは主に、Microsoft UI オートメーション フレームワークの統合サポートに基づいています。 このようなサポートは、基底クラス、コントロール型に対するクラス実装の組み込み動作、UI オートメーション プロバイダー API のインターフェイス表現を通じて提供されます。 各コントロール クラスは、UI オートメーションの概念であるオートメーション ピアとオートメーション パターンを使って、コントロールの役割とコンテンツを UI オートメーション クライアントに報告します。 アプリは、UI オートメーションではトップレベル ウィンドウとして扱われ、UI オートメーション フレームワークを通じて、そのアプリ ウィンドウ内のすべてのアクセシビリティ関連のコンテンツが UI オートメーション クライアントに利用できるようになります。 UI オートメーションについて詳しくは、「[UI オートメーションの概要](https://msdn.microsoft.com/library/windows/desktop/Ee684076)」をご覧ください。

<span id="Assistive_technology"/>
<span id="assistive_technology"/>
<span id="ASSISTIVE_TECHNOLOGY"/>

## <a name="assistive-technology"></a>支援技術  
ユーザーが必要とするアクセシビリティの多くは、ユーザーがインストールする支援技術製品や、オペレーティング システムで提供されるツールと設定によって実現されます。 これには、スクリーン リーダー、画面拡大、ハイ コントラスト設定などの機能が含まれます。

支援技術製品には、さまざまなソフトウェアやハードウェアがあります。 これらの製品は、標準のキーボード インターフェイスと、UI のコンテンツと構造に関する情報をスクリーン リーダーなどの支援技術に報告するアクセシビリティ フレームワークで機能します。 支援技術製品にはたとえば次のようなものがあります。

* オンスクリーン キーボード。ユーザーはキーボードの代わりにポインターを使用してテキストを入力できます。
* 音声認識ソフトウェア。音声がテキストに変換されます。
* スクリーン リーダー。テキストが音声、ブライユ点字などの形式に変換されます。
* ナレーター スクリーン リーダー。Windows 特有の機能です。 ナレーターには、利用可能なキーボードがない場合を想定して、タッチ ジェスチャを処理することで画面を読み込むことができるタッチ モードがあります。
* ディスプレイまたはディスプレイの領域を調整するプログラムまたは設定 (ハイ コントラスト テーマなど)、ディスプレイの DPI (1 インチあたりのドット数) の設定、拡大鏡ツール。

アプリのキーボードとスクリーン リーダーのサポートが十分なものであれば、通常は各種の支援技術製品で適切に動作します。 多くの場合、UWP アプリは、情報や構造の追加変更なしでそれらの製品と連携できます。 ただし、最適なアクセシビリティ エクスペリエンスのためにいくつか設定を変更したり、追加のサポートを実装する場合もあります。

支援技術による基本的なアクセシビリティのシナリオをテストするために使用できるオプションについては、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。

<span id="Screen_reader_support_and_basic_accessibility_information"/>
<span id="screen_reader_support_and_basic_accessibility_information"/>
<span id="SCREEN_READER_SUPPORT_AND_BASIC_ACCESSIBILITY_INFORMATION"/>

## <a name="screen-reader-support-and-basic-accessibility-information"></a>スクリーン リーダーのサポートと基本的なアクセシビリティ情報  
スクリーン リーダーでは、音声やブライユ点字出力などの形式にレンダリングしてアプリのテキストを利用できるようにします。 スクリーン リーダーの実際の動作は、ソフトウェアやユーザーによるソフトウェアの構成によって異なります。

たとえば、一部のスクリーン リーダーでは、ユーザーが表示されているアプリを起動したり切り替えたりしたときに、アプリの UI 全体を読み取ります。この場合、ユーザーは、そのアプリへのナビゲーションを試みる前に利用可能な情報のコンテンツをすべて受け取ることができます。 また、タブ ナビゲーションで各コントロールにフォーカスが移ったときに、そのコントロールに関連付けられたテキストを読み取るスクリーン リーダーもあります。 この場合、ユーザーは、現在の位置を確認しながらアプリの入力コントロール間を移動することができます。 ナレーターは、ユーザーの選択に応じて両方の動作を提供するスクリーン リーダーの一例です。

スクリーン リーダーなどの支援技術において、ユーザーがアプリを理解またはナビゲートするのに役立つ最も重要な情報となるのが、アプリの要素パーツに対する*アクセシビリティ対応の名前*です。 多くの場合、コントロールや要素には、別途指定した他のプロパティ値から計算されるアクセシビリティ対応の名前が既に設定されています。 既に計算された名前を使うことができる最も一般的な例は、内部テキストのサポートと表示を行う要素です。 他の要素では、要素構造のベスト プラクティスに従って、アクセシビリティ対応の名前を他の方法で指定することが必要な場合があります。 また、アプリをアクセシビリティ対応にするために、アクセシビリティ対応の名前として使うことを目的とした名前の指定が必要な場合もあります。 一般的な UI 要素で使うことができるこれらの計算値の一覧や、一般的なアクセシビリティ対応の名前について詳しくは、「[基本的なアクセシビリティ情報](basic-accessibility-information.md)」をご覧ください。

オートメーションのプロパティは、他にも利用可能なものがいくつかあります (次のセクションで説明するキーボードのプロパティなど)。 ただし、すべてのスクリーン リーダーですべてのオートメーションのプロパティがサポートされるわけではありません。 一般に、該当するオートメーションのプロパティについてはすべて設定して、できるだけ多くのスクリーン リーダーに対応するようにテストする必要があります。

<span id="Keyboard_support"/>
<span id="keyboard_support"/>
<span id="KEYBOARD_SUPPORT"/>

## <a name="keyboard-support"></a>キーボードのサポート  
キーボードのサポートを十分なものにするには、アプリのすべての部分をキーボードで操作できるようにする必要があります。 アプリで使うコントロールのほとんどが標準のコントロールであり、カスタム コントロールを使っていない場合は、ほぼこれを実現できていると言えます。 基本的な XAML コントロール モデルには、タブ ナビゲーション、テキスト入力、コントロール固有のサポートなど、キーボードのサポートが組み込まれています。 レイアウト コンテナー (パネルなど) として機能する要素では、レイアウトの順序を使って、既定のタブの順序を設定します。 この順序は通常、UI をアクセシビリティ対応で表示するのに適したタブの順序です。 データの表示に使う [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロールと [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) コントロールには、方向キーのナビゲーションが組み込まれています。 また、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) コントロールを使う場合は、Space キーまたは Enter キーが自動で処理されてボタンがアクティブ化されます。

タブの順序やキー ベースのアクティブ化、ナビゲーションなど、キーボードのサポートのあらゆる側面について詳しくは、「[キーボードのアクセシビリティ](keyboard-accessibility.md)」をご覧ください。

<span id="Media_and_captioning"/>
<span id="media_and_captioning"/>
<span id="MEDIA_AND_CAPTIONING"/>

## <a name="media-and-captioning"></a>メディアと字幕  
通常、オーディオビジュアル メディアを表示するには、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/BR242926) オブジェクトを使います。 **MediaElement** API を使うとメディアの再生を制御できます。 アクセシビリティ対応にするには、ユーザーが必要に応じてメディアを再生、一時停止、停止できるコントロールを用意します。 メディアには、キャプションや、ナレーションによる説明が含まれている別のオーディオ トラックなど、アクセシビリティ用の追加コンポーネントが含まれている場合があります。

<span id="Accessible_text"/>
<span id="accessible_text"/>
<span id="ACCESSIBLE_TEXT"/>

## <a name="accessible-text"></a>アクセシビリティに対応したテキスト  
テキストの次の 3 つの主な側面がアクセシビリティに関連しています。

* ツールでは、テキストをタブ順のトラバーサルの一部として読み取るか、ドキュメント全体の表示の一部として読み取るかどうかを決める必要があります。 テキストの表示に適した要素を選ぶか、これらのテキスト要素のプロパティを調整することで、この決定の制御に役立てることができます。 各テキスト要素には、固有の目的があり、その目的には通常、対応する UI オートメーションの役割があります。 不適切な要素を使うと、誤った役割が UI オートメーションに報告され、支援技術を使うユーザーの混乱を招くことになります。
* 視覚に障碍があり、背景に対するコントラストが適切でないとテキストを読み取ることが困難なユーザーが多数います。 視覚に障碍がないアプリの開発者には、こうしたユーザーが受ける影響は直感的には理解できません。 たとえば、色覚に障碍がある場合、設計で不適切な色を選ぶと、テキストを読むことができないユーザーもいます。 当初は Web コンテンツ用に作成された、アクセシビリティに関する推奨事項には、これらの問題をアプリで回避するためのコントラストの基準も定義されています。 詳しくは、「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。
* テキストが単に小さすぎるために読むことが難しい場合もよくあります。 この問題は、アプリの UI のテキストを最初から適切な大きさにすることで防止できます。 ただし、大量のテキストを表示するアプリや、テキストと他の視覚要素が混在するアプリでは、こうした変更が難しい場合があります。 このような場合は、ディスプレイを拡大できるシステム機能とアプリが正しくやり取りできるようにすることで、アプリ内のテキストも拡大します  (一部のユーザーはアクセシビリティのオプションとして DPI の値を変更します。 このオプションは、**[コンピューターの簡単操作]** の **[画面上の項目を拡大します]** から利用できます。この操作は、**コントロール パネル**の UI の **[デスクトップのカスタマイズ]** / **[ディスプレイ]** にリダイレクトされます)。

<span id="Supporting_high-contrast_themes"/>
<span id="supporting_high-contrast_themes"/>
<span id="SUPPORTING_HIGH-CONTRAST_THEMES"/>

## <a name="supporting-high-contrast-themes"></a>ハイ コントラスト テーマのサポート  
UI コントロールでは、テーマの XAML リソース ディクショナリの一部として定義されている視覚的な表示を使います。 これらのテーマのうちの 1 つ以上は、システムがハイ コントラストに設定されている場合に使われます。 ユーザーが、リソース ディクショナリの適切なテーマを動的に参照してハイ コントラストに切り替えると、すべての UI コントロールも適切なハイ コントラスト テーマを使います。 明示的なスタイルの指定により、またはハイ コントラスト テーマが読み込まれてスタイルの変更をオーバーライドするのを防ぐ、別のスタイル指定方法を使うことにより、これらのテーマを無効にすることがないようにしてください。 詳しくは、「[ハイ コントラスト テーマ](high-contrast-themes.md)」をご覧ください。

<span id="Design_for_alternative_UI"/>
<span id="design_for_alternative_ui"/>
<span id="DESIGN_FOR_ALTERNATIVE_UI"/>

## <a name="design-for-alternative-ui"></a>別の UI を設計する  
アプリを設計するときは、運動障碍、視覚障碍、聴覚障碍を持つユーザーがどのようにして使うのか考えながら設計する必要があります。 支援技術製品は標準の UI を広く利用するため、アクセシビリティについてそれ以外は調整しない場合でも、キーボードとスクリーン リーダーのサポートについては十分に調整することが特に重要です。

多くの場合、幅広いユーザーが利用できるようにするために、重要な情報を複数の方法で伝えることができます。 たとえば、アイコンと色の両方を使って情報を目立つようにすると、色覚に障碍があるユーザーが確認しやすくなります。また、効果音と一緒に視覚的な警告も表示すると、聴覚障碍があるユーザーに便利です。

必要に応じて、不要な要素やアニメーションがまったくないアクセシビリティ対応のユーザー インターフェイス要素を代わりに使えるようにしたり、ユーザー操作が効率的になるように簡略化したりできます。 次のコード例は、1 つの [**UserControl**](https://msdn.microsoft.com/library/windows/apps/BR227647) インスタンスを表示して、ユーザー設定に応じて UserControl の別のインスタンスを表示する方法を示しています。

XAML
```xml
<StackPanel x:Name="LayoutRoot" Background="White">

  <CheckBox x:Name="ShowAccessibleUICheckBox" Click="ShowAccessibleUICheckBox_Click">
    Show Accessible UI
  </CheckBox>

  <UserControl x:Name="ContentBlock">
    <local:ContentPage/>
  </UserControl>

</StackPanel>
```

Visual Basic
```vb
Private Sub ShowAccessibleUICheckBox_Click(ByVal sender As Object,
    ByVal e As RoutedEventArgs)

    If (ShowAccessibleUICheckBox.IsChecked.Value) Then
        ContentBlock.Content = New AccessibleContentPage()
    Else
        ContentBlock.Content = New ContentPage()
    End If
End Sub
```

C#
```csharp
private void ShowAccessibleUICheckBox_Click(object sender, RoutedEventArgs e)
{
    if ((sender as CheckBox).IsChecked.Value)
    {
        ContentBlock.Content = new AccessibleContentPage();
    }
    else
    {
        ContentBlock.Content = new ContentPage();
    }
}
```

<span id="Verification_and_publishing"/>
<span id="verification_and_publishing"/>
<span id="VERIFICATION_AND_PUBLISHING"/>

## <a name="verification-and-publishing"></a>検証と公開  
アクセシビリティ対応と宣言してアプリを公開する方法については、「[ストア内のアクセシビリティ](accessibility-in-the-store.md)」をご覧ください。

> [!NOTE]
> アプリをアクセシビリティ対応として宣言する方法は、Microsoft Store にのみ適用されます。

<span id="Assistive_technology_support_in_custom_controls"/>
<span id="assistive_technology_support_in_custom_controls"/>
<span id="ASSISTIVE_TECHNOLOGY_SUPPORT_IN_CUSTOM_CONTROLS"/>

## <a name="assistive-technology-support-in-custom-controls"></a>カスタム コントロールでの支援技術のサポート  
カスタム コントロールを作るときは、1 つ以上の [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) サブクラスを実装または拡張してアクセシビリティをサポートすることをお勧めします。 基本コントロール クラスで使われていたのと同じピア クラスを使う場合は、派生クラスのオートメーション サポートは基本レベルで十分ですが、 そのことをテストする必要があります。また、そのような場合でも、新しいコントロール クラスのクラス名を正しく報告できるように、ピアを実装することをお勧めします。 カスタム オートメーション ピアを実装するにはいくつかの手順を実行する必要があります。 詳しくは、「[カスタム オートメーション ピア](custom-automation-peers.md)」をご覧ください。

<span id="Assistive_technology_support_in_apps_that_support_XAML___Microsoft_DirectX_interop"/>
<span id="assistive_technology_support_in_apps_that_support_xaml___microsoft_directx_interop"/>
<span id="ASSISTIVE_TECHNOLOGY_SUPPORT_IN_APPS_THAT_SUPPORT_XAML___MICROSOFT_DIRECTX_INTEROP"/>

## <a name="assistive-technology-support-in-apps-that-support-xaml--microsoft-directx-interop"></a>XAML/Microsoft DirectX の相互運用機能をサポートするアプリでの支援技術のサポート  
([**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/Dn252834) または [**SurfaceImageSource**](https://msdn.microsoft.com/library/windows/apps/Hh702041) を使って) XAML UI にホストされる Microsoft DirectX コンテンツには、既定ではアクセスできません。 ホストされた DirectX コンテンツの UI オートメーション ピアを作成する方法は、[XAML SwapChainPanel DirectX 相互運用性のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=309155) で確認できます。 この手法を利用すると、ホストされたコンテンツに UI オートメーションを通じてアクセスできるようになります。

## <a name="related-topics"></a>関連トピック  
* [**Windows.UI.Xaml.Automation**](https://msdn.microsoft.com/library/windows/apps/BR209179)
* [アクセシビリティのための設計](https://msdn.microsoft.com/library/windows/apps/Hh700407)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [アクセシビリティ](accessibility.md)
* [ナレーターの概要](https://support.microsoft.com/help/22798/windows-10-narrator-get-started)
