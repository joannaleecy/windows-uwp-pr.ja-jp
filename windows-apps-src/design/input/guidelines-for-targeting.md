---
Description: このトピックでは、タッチ補正のための接触形状の使用について説明し、Windows ランタイム アプリでのターゲット設定のベスト プラクティスを紹介します。
title: ターゲット設定
ms.assetid: 93ad2232-97f3-42f5-9e45-3fc2143ac4d2
label: Targeting
template: detail.hbs
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 5c05b6686d31606a9510b1433339dc8829a52893
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59247180"
---
# <a name="guidelines-for-touch-targets"></a>タッチの対象とするためのガイドライン

ユニバーサル Windows プラットフォーム (UWP) アプリケーション内のすべての対話型 UI 要素を正確にアクセスして、デバイスの種類や入力方法に関係なく、使用するユーザーに十分な大きさにする必要があります。

タッチ デジタイザーによって報告される入力データの大規模でより複雑なセットが決定に使用されるため、ターゲットのサイズとコントロールのレイアウトに関するさらに最適化を必要とタッチ入力 (およびタッチの連絡先情報 領域の比較的不正確な性質) をサポートしている、ユーザーの目的 (または最も可能性の高い) のターゲット。

UWP コントロールのすべてでは、タッチの既定のターゲット サイズとは、快適な使いやすく、視覚的にバランスの取れたで魅力的なもののアプリを構築するためのレイアウトを設計し、信頼してもらいます。

このトピックでプラットフォーム コントロールとカスタム コントロールの両方を使用して (必要があります、アプリに) 最大の使いやすさのアプリを設計するためにこれらの既定の動作を説明します。

> **重要な API**:[**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)、 [ **Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、 [ **Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)

## <a name="fluent-standard-sizing"></a>標準の Fluent のサイズ変更

*標準のサイズ変更の Fluent*情報密度とユーザーの快適性のバランスを提供するが作成されました。 実際には、画面上のすべての項目は、UI 要素をグリッドに合わせるし、適切にスケーリングできますが、システム レベルのスケールに基づいて、40 x 40 有効ピクセル (epx) のターゲットに揃えます。

> [!NOTE]
>有効ピクセルとスケーリングの詳細については、次を参照してください[UWP アプリのデザインの概要。](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)
>
> システム レベルのスケーリングの詳細については、次を参照してください。[配置、余白、パディング](../layout/alignment-margin-padding.md)します。

## <a name="fluent-compact-sizing"></a>Fluent のコンパクト サイズ変更

アプリケーションの情報密度の高いレベルを表示できる*Fluent コンパクト サイズ変更*します。 Compact のサイズ変更は、厳密なグリッド システム レベルのスケールに基づいて、適切なスケールを整列する UI 要素を 32 x 32 epx ターゲットへの UI 要素を配置します。

### <a name="examples"></a>例

Compact のサイズ変更は、ページまたはグリッド レベルで適用できます。

### <a name="page-level"></a>ページレベルのロック

```xaml
<Page.Resources>
    <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
</Page.Resources>
```

### <a name="grid-level"></a>グリッド レベル

```xaml
<Grid>
    <Grid.Resources>
        <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
    </Grid.Resources>
</Grid>
```

## <a name="target-size"></a>ターゲット サイズ

一般に、タッチ、ターゲットのサイズを 7.5 mm 正方形の範囲 (x 頭打ちのスケーリングの 1.0 135 PPI ディスプレイで 40 x 40 ピクセル) に設定します。 通常、UWP コントロールの連携 7.5 mm タッチのターゲット (特定のコントロールと、一般的な使用パターンに基づいてこの異なることができます)。 参照してください[サイズおよび密度の制御](../style/spacing.md)詳細。

表に示したターゲット サイズの推奨サイズは、個々のシナリオの必要に応じて調整できます。 考慮事項を次に示します。

- 繰り返しまたはよく押されている最小のサイズを超えるターゲット仕上げ - の頻度を検討しています。
- エラー結果 - エラーの場合、重大な影響を及ぼすターゲットで大きい余白、コンテンツ エリアの端からかけ離れたものに配置します。 特に当てはまるのは頻繁にタッチされるターゲットです。
- コンテンツ領域内の位置。
- 要素や画面サイズを形成します。
- 本の指の状態。
- 視覚エフェクトをタッチします。

## <a name="related-articles"></a>関連記事

- [UWP アプリ設計の概要](../basics/design-and-ui-intro.md)
- [コントロールのサイズおよび密度](../style/spacing.md)
- [配置、余白、パディング](../layout/alignment-margin-padding.md)

### <a name="samples"></a>サンプル

- [基本的な入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)
- [待機時間が短い入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620304)
- [ユーザー操作モードのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619894)
- [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)

### <a name="archive-samples"></a>サンプルのアーカイブ

- [入力:XAML ユーザー入力イベントのサンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)
- [入力:デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)
- [入力:タッチ ヒット テストのサンプル](https://go.microsoft.com/fwlink/p/?linkid=231590)
- [XAML のスクロール、パン、ズームのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?linkid=251717)
- [入力:簡略化されたインクのサンプル](https://go.microsoft.com/fwlink/p/?linkid=246570)
- [入力:Windows 8 のジェスチャのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=264995)
- [入力:操作とジェスチャ (C++) のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231605)
- [DirectX タッチ入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=231627)
