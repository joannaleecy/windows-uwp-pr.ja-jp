---
title: 空白文字とサイズ
description: 新しい Fluent 標準と Compact コントロールのスタイルは、デバイスと入力方法に関係なく快適なユーザー エクスペリエンスを確認します。
keywords: UWP、Windows 10、コントロール、サイズ、密度、standard、compact
ms.date: 4/4/2019
ms.topic: article
ms.localizationpriority: medium
ms.custom: 19H1
ms.openlocfilehash: 7b74e3dc2ad047d9e52509b71ef00b829ad63a0d
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59249454"
---
# <a name="control-size-and-density"></a>コントロールのサイズおよび密度

コントロールのサイズおよび密度の組み合わせを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリケーションを最適化し、アプリの機能との対話の要件について最適なユーザー エクスペリエンスを提供します。

既定では、UWP アプリをレンダリングする際、低密度 (または`Standard`) レイアウト。 ただし、以降、高密度、WinUI 2.1 で (または`Compact`) レイアウト オプションでは、情報豊富な UI と同様の特殊なシナリオもサポートされます。 これは基本的なスタイル リソースを使用して指定できます (次の例を参照してください)。

機能と動作が変更されていないと、2 つの間で一貫性が保た 14 px これら 2 つの密度のオプションをサポートするすべてのコントロールのサイズおよび密度のオプション、既定の本文フォント サイズが更新されました。 このフォント サイズはリージョンとデバイス間で機能し、により、アプリケーションはバランスの取れたとユーザーの満足します。

## <a name="fluent-standard-sizing"></a>標準の Fluent のサイズ変更

*標準のサイズ変更の Fluent*情報密度とユーザーの快適性のバランスを提供するが作成されました。 実際には、画面上のすべての項目は、UI 要素をグリッドに合わせるし、適切にスケーリングできますが、システム レベルのスケールに基づいて、40 x 40 有効ピクセル (epx) のターゲットに揃えます。

**標準のサイズは、タッチとポインター入力の両方に対応するために設計されています。**

> [!NOTE]
>有効ピクセルとスケーリングの詳細については、次を参照してください[UWP アプリのデザインの概要。](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)
>
> システム レベルのスケーリングの詳細については、次を参照してください。[配置、余白、パディング](../layout/alignment-margin-padding.md)します。

Windows 10 年 10 月のすべての使用状況シナリオの使いやすさを向上させる 2018 Update (バージョンは 1809)、standard、UWP コントロールのすべての既定のサイズが減少しました。

次の図は、コントロールのレイアウトの変更、Windows で導入された 10 年 2018年 10 月の更新します。 具体的には、ヘッダー コントロールの上端との間の余白に 8epx から 4epx に減少しましたし、44epx グリッドが 40epx グリッドに変更されました。

![標準コントロールのレイアウトの例](images/standarddensity.png)

*標準コントロールのレイアウトの例*

この次の画像は、Windows 用のサイズの制御に加えられた変更を示しています。 10 年 10 月 2018 の更新。 具体的には、40epx グリッドに配置します。

![標準のコマンド実行例](images/standarddensitycommanding.png)

## <a name="fluent-compact-sizing"></a>Fluent のコンパクト サイズ変更

Compact のサイズ変更は、コントロールの高密度、情報が豊富なグループを有効し、次のようにできます。

- 大量のコンテンツを参照します。
- ページに表示されるコンテンツの最大化します。
- 移動して、コントロールやコンテンツと対話します。

**Compact のサイズ変更は、ポインター入力の対応するために主に設計されています。**

### <a name="examples"></a>例

Compact のサイズ変更は、ページ レベルで、または特定のレイアウトで、アプリケーションで指定できる特殊なリソース ディクショナリを介して実装されます。 リソース ディクショナリがで使用できる、 [WinUI](https://docs.microsoft.com/en-us/uwp/toolkits/winui/) Nuget パッケージ。

次の例に示す方法、`Compact`ページと個々 のグリッド コントロールのスタイルを適用できます。

#### <a name="page-level"></a>ページレベルのロック

```xaml
<Page.Resources>
    <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
</Page.Resources>
```

#### <a name="grid-level"></a>グリッド レベル

```xaml
<Grid>
    <Grid.Resources>
        <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
    </Grid.Resources>
</Grid>
```

## <a name="related-articles"></a>関連記事

- [タッチの対象とするためのガイドライン](../input/guidelines-for-targeting.md)
- [ResourceDictionary と XAML リソースの参照](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/resourcedictionary-and-xaml-resource-references)
- [リソース ディクショナリ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.resourcedictionary)
- [XAML スタイル](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/xaml-styles) 
