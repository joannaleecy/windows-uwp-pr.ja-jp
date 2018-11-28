---
title: 学習トラック - フォームの作成と構成
description: アプリで堅牢なフォームを作成するために必要となることについて説明します。
ms.date: 05/07/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, レイアウト, フォーム
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0cb42552139fd706dd9e87d61c24f8fe2c2d51f7
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7964772"
---
# <a name="create-and-customize-a-form"></a>フォームを作成してカスタマイズする

ユーザーが大量の情報を入力する必要のあるアプリを作成している場合は、ユーザーが入力するフォームが必要になる可能性があります。この記事では、利便性と信頼性の高いフォームを作成するために知っておく必要のあることについて説明します。

これはチュートリアルではありません。 チュートリアルが必要な場合は、「[アダプティブ レイアウトのチュートリアル](../design/basics/xaml-basics-adaptive-layout.md)」を参照してください。このチュートリアルでは、手順を説明したガイド付きのエクスペリエンスが提供されます。

フォームに含める **XAML コントロール**、ページ上で XAML コントロールを最適に配置する方法、画面のサイズを変更するためにフォームを最適化する方法について説明します。 ただし、フォームは visual 要素の相対位置に関することなので、まず XAML を使ったページ レイアウトについて詳しく説明します。

## <a name="what-do-you-need-to-know"></a>理解しておく必要があること

UWP には、アプリに追加して構成することができる明示的なフォーム コントロールはありません。 代わりに、ページ上に UI 要素のコレクションを配置することによって、フォームを作成する必要があります。

そのためには、**レイアウト パネル**を理解する必要があります。 レイアウト パネルは、アプリの UI 要素を保持するコンテナーで、アプリの UI 要素を配置およびグループ化することができます。 レイアウト パネルを他のレイアウト パネル内に配置すると、相互の関連で項目の表示場所や表示方法を自由に制御できます。 また、これにより画面サイズ変更にアプリを対応させることがはるかに簡単になります。

[レイアウト パネルに関するこちらのドキュメント](../design/layout/layout-panels.md)をお読みください。 フォームは通常 1 つ以上の垂直列に表示されるため、類似した項目を **StackPanel** にまとめ、必要であれば **RelativePanel** 内に配置します。 それでは、一部のパネルの編成を開始してください。リファレンスが必要な場合は、2 列のフォームの基本的なレイアウト フレームワークが以下に用意されています。

```xaml
<RelativePanel>
    <StackPanel x:Name="Customer" Margin="20">
        <!--Content-->
    </StackPanel>
    <StackPanel x:Name="Associate" Margin="20" RelativePanel.RightOf="Customer">
        <!--Content-->
    </StackPanel>
    <StackPanel x:Name="Save" Orientation="Horizontal" RelativePanel.Below="Customer">
        <!--Save and Cancel buttons-->
    </StackPanel>
</RelativePanel>
```

## <a name="what-goes-in-a-form"></a>フォームに含めるもの

各種の [XAML コントロール](../design/controls-and-patterns/controls-and-events-intro.md) を使用してフォームに入力する必要があります。 XAML コントロールは使い慣れているかもしれませんが、思い出す必要がある場合は、自由に目を通してください。 特に、ユーザーがテキストを入力するか、または値の一覧から選択できるようにするコントロールが必要になります。 これは、追加のオプションの基本的なリスト – 外観やしくみを理解するために十分なに関するすべての情報を読み取る必要はありません。

* [TextBox](../design/controls-and-patterns/text-box.md)では、アプリにユーザーがテキストを入力できます。
* [ToggleSwitch](../design/controls-and-patterns/toggles.md) では、ユーザーが 2 つのオプションから選択できます。
* [DatePicker](../design/controls-and-patterns/date-picker.md) では、ユーザーが日付値を選択できます。
* [TimePicker](../design/controls-and-patterns/time-picker.md) では、ユーザーが時刻値を選択できます。
* [ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox) は、選択可能な項目の一覧を表示するために展開します。 これらの詳細については、[こちら](../design/controls-and-patterns/lists.md#drop-down-lists)を参照してください。

また、ユーザーが保存やキャンセルを行うことができるように、[ボタン](../design/controls-and-patterns/buttons.md)を追加することができます。

## <a name="format-controls-in-your-layout"></a>レイアウトでのコントロールの書式設定

レイアウト パネルを配置する方法を理解し、追加したい項目がありますが、どのように書式設定すればいいでしょうか。 [フォーム](../design/controls-and-patterns/forms.md) ページにはいくつかの詳しい設計ガイダンスが記載されています。 **フォームの種類**と**レイアウト**に関するセクションに目を通して役立つアドバイスを確認してください。 アクセシビリティと相対レイアウトについては簡単に説明します。

そのアドバイスに留意し、選択したコントロールをレイアウトに追加し始め、ラベルと行間が正しく指定されていることを確認します。 例として、上記のレイアウト、コントロール、設計ガイダンスを使用した単一ページ フォームの必要最小限の概要を次に示します。

```xaml
<RelativePanel>
    <StackPanel x:Name="Customer" Margin="20">
        <TextBox x:Name="CustomerName" Header= "Customer Name" Margin="0,24,0,0" HorizontalAlignment="Left" />
        <TextBox x:Name="Address" Header="Address" PlaceholderText="Address" Margin="0,24,0,0" HorizontalAlignment="Left" />
        <TextBox x:Name="Address2" Margin="0,24,0,0" PlaceholderText="Address 2" HorizontalAlignment="Left" />
            <RelativePanel>
                <TextBox x:Name="City" PlaceholderText="City" Margin="0,24,0,0" HorizontalAlignment="Left" />
                <ComboBox x:Name="State" PlaceholderText="State" Margin="24,24,0,0" RelativePanel.RightOf="City">
                    <!--List of valid states-->
                </ComboBox>
            </RelativePanel>
    </StackPanel>
    <StackPanel x:Name="Associate" Margin="20" RelativePanel.Below="Customer">
        <TextBox x:Name="AssociateName" Header= "Associate" Margin="0,24,0,0" HorizontalAlignment="Left" />
        <DatePicker x:Name="TargetInstallDate" Header="Target install Date" HorizontalAlignment="Left" Margin="0,24,0,0"></DatePicker>
        <TimePicker x:Name="InstallTime" Header="Install Time" HorizontalAlignment="Left" Margin="0,24,0,0"></TimePicker>
    </StackPanel>
    <StackPanel x:Name="Save" Orientation="Horizontal" RelativePanel.Below="Associate">
        <Button Content="Save" Margin="24" />
        <Button Content="Cancel" Margin="24" />
    </StackPanel>
</RelativePanel>
```

視覚エクスペリエンスを向上させるために、さらにプロパティを使って自由にコントロールをカスタマイズしてください。

## <a name="make-your-layout-responsive"></a>レイアウトの応答性を向上させる

ユーザーは、さまざまな画面幅の多様なデバイスで UI を表示する可能性があります。 画面に関係なく優れたエクスペリエンスを確実に提供するには、[レスポンシブ デザイン](../design/layout/responsive-design.md)を使用する必要があります。 そのページに目を通し、作業を進めるうえで留意する設計哲学に関する優れたアドバイスを確認してください。

[XAML でのレスポンシブ レイアウト](../design/layout/layouts-with-xaml.md)のページでは、この実装方法に関する詳細な概要について説明しています。 ここでは、**柔軟なレイアウト**と **XAML での表示状態**を中心に説明します。

用意されている基本的なフォームのアウトラインは、特定のピクセル サイズと位置を最小限にしか使用しないコントロールの相対位置にほぼ依存しているため、既に**柔軟なレイアウト**になっています。 ただし、今後作成する可能性がある追加の UI についてはこのガイダンスに留意してください。

レスポンシブ レイアウトでさらに重要なのは**表示状態**です。 表示状態は、特定の条件が該当する場合に指定された要素に適用されるプロパティ値を定義します。 [xaml でこれを行う方法について目を通し](../design/layout/layouts-with-xaml.md#set-visual-states-in-xaml-markup)、フォームに実装してください。 前のサンプルでの*非常に*基本的な例の外観を次に示します。

```xaml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState>
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="640" />
            </VisualState.StateTriggers>

            <VisualState.Setters>
                <Setter Target="Associate.(RelativePanel.RightOf)" Value="Customer"/>
                <Setter Target="Associate.(RelativePanel.Below)" Value=""/>
                <Setter Target="Save.(RelativePanel.Below)" Value="Customer"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>

<RelativePanel>
    <!--Previous 3 stack panels-->
</RelativePanel>
```

幅広い画面サイズに対応する表示状態を作成するのは実用的ではなく、アプリのユーザー エクスペリエンスに大きな影響を及ぼす可能性もそれほど高くはありません。 その代わり、いくつかの主要なブレークポイントを設計することをお勧めします。[こちらを参照](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)してください。

## <a name="add-accessibility-support"></a>アクセシビリティのサポートの追加

これで、画面サイズの変更に対応する、適切に構築されたレイアウトが用意できたので、最後にユーザー エクスペリエンスを向上させるために、[アプリをアクセシビリティ対応にする](../design/accessibility/accessibility-overview.md)ことができます。 詳しく説明できることはたくさんありますが、このようなフォームでは見た目よりも簡単です。 次の点を中心に説明します。

* キーボードのサポート - ユーザーが簡単にタブ移動できるように、UI パネルの要素の順序が、画面上に表示される方法と一致するようにします。
* スクリーン リーダーのサポート - すべてのコントロールにわかりやすい名前があることを確認します。

より多くの視覚要素を含む複雑なレイアウトを作成する場合は、詳細について、「[アクセシビリティのチェック リスト](../design/accessibility/accessibility-checklist.md)」を参照する必要があります。 結局のところ、アクセシビリティがアプリに必要なくても、アクセシビリティによってより多くの人にリーチして感心を高めることができます。

## <a name="going-further"></a>追加情報

ここではフォームを作成しましたが、レイアウトとコントロールの概念は、作成する可能性のあるすべての XAML UI で適用可能です。 自由に戻ってがある場合、新しい UI 機能を追加して、ユーザー エクスペリエンスを絞り込むフォームの実験し、リンクしたドキュメントです。 詳細なレイアウト機能を使ってステップ バイ ステップのガイダンスを設定する場合、[アダプティブ レイアウトのチュートリアル](../design/basics/xaml-basics-adaptive-layout.md)をご覧ください。

また、フォームは真空に存在する必要はありません。一歩進んで、自分のフォームを[マスター/詳細パターン](../design/controls-and-patterns/master-details.md)または[ピボット コントロール](../design/controls-and-patterns/tabs-pivot.md)に組み込むことができます。 または、自分のフォームで分離コードを使用する場合は、[イベントの概要](../xaml-platform/events-and-routed-events-overview.md)を参照して作業を開始することをお勧めします。

## <a name="useful-apis-and-docs"></a>便利な API とドキュメント

データ バインディングを操作するうえで役立つ API の簡単な概要とその他の役立つドキュメントを次に示します。

### <a name="useful-apis"></a>便利な API

| API | 説明 |
|------|---------------|
| [フォームに役立つコントロール](../design/controls-and-patterns/forms.md#input-controls) | フォームを作成するために役立つ入力コントロールの一覧と、それを使用する場所に関する基本的なガイダンスです。 |
| [グリッド](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Grid) | 複数行および段組レイアウトで要素を配置するためのパネルです。 |
| [RelativePanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RelativePanel) | その他の要素とパネルの境界を基準にして項目を配置するためのパネルです。 |
| [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) | 単一の水平線または垂直線に要素を配置するためのパネルです。 |
| [VisualState](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.VisualState) | UI 要素が特定の状態にあるときに要素の外観を設定できます。 |

### <a name="useful-docs"></a>役立つドキュメント

| トピック | 説明 |
|-------|----------------|
| [アクセシビリティの概要](../design/accessibility/accessibility-overview.md) | アプリでのアクセシビリティ オプションの広範囲にわたる概要です。 |
| [アクセシビリティのチェック リスト](../design/accessibility/accessibility-checklist.md) | アプリがアクセシビリティの基準を満たしていることを確認するための実用的なチェックリストです。 |
| [イベントの概要](../xaml-platform/events-and-routed-events-overview.md) | UI 操作を処理するイベントの追加と構築に関する詳細です。 |
| [フォーム](../design/controls-and-patterns/forms.md) | フォームを作成するための全体的なガイダンスです。 |
| [レイアウト パネル](../design/layout/layout-panels.md) | レイアウト パネルの種類とそれらを使用する場所に関する概要を示します。 |
| [マスター/詳細パターン](../design/controls-and-patterns/master-details.md) | 1 つまたは複数のフォームの周囲に実装できる設計パターンです。 |
| [ピボット コントロール](../design/controls-and-patterns/tabs-pivot.md) | 1 つまたは複数のフォームを含めることができるコントロールです。 |
| [レスポンシブ デザイン](../design/layout/responsive-design.md) | 大規模なレスポンシブ デザインの原則の概要です。 | 
| [XAML でのレスポンシブ レイアウト](../design/layout/layouts-with-xaml.md) | レスポンシブ デザインの表示状態とその他の実装に関する具体的な情報です。 |
| [レスポンシブ デザインの画面サイズ](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md) | レスポンシブ レイアウトの対象とする画面サイズに関するガイダンスです。 |

## <a name="useful-code-samples"></a>役立つコード サンプル

| コード サンプル | 説明 |
|-----------------|---------------|
| [アダプティブ レイアウトのチュートリアル](../design/basics/xaml-basics-adaptive-layout.md) | アダプティブ レイアウトやレスポンシブ デザインの手順を説明したガイド付きエクスペリエンスです。 | 
| [顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database) | マルチページのエンタープライズのサンプルで、レイアウトとフォームの動作を確認してください。 |
| [XAML コントロール ギャラリー](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) | 一部の XAML コントロール、およびそれらの実装方法を参照してください。 |
| [その他のコード サンプル](https://developer.microsoft.com//windows/samples) | [カテゴリ] ドロップダウン リストで **[コントロール、レイアウト、テキスト]** を選択し、関連するコード サンプルを参照してください。 |
