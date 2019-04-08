---
Description: ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。
title: ヒント
ms.assetid: A21BB12B-301E-40C9-B84B-C055FD43D307
label: Tooltips
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: kimsea
dev-contact: stpete
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 80591abb1e3130540ea94bc1f8d2602b90edc590
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613667"
---
# <a name="tooltips"></a>ヒント

ヒントは、他のコントロールまたはオブジェクトにリンクされた短い説明です。 ヒントを使うと、UI では直接説明されていない、なじみのないオブジェクトをユーザーが理解しやすくなります。 ヒントは、ユーザーがコントロールにフォーカスを移動する、コントロール上で長押しする、またはマウス ポインターをコントロール上にホバーすると、自動的に表示されます。 また、ヒントは数秒経過するか、ユーザーが指、ポインター、またはキーボード/ゲームパッドのフォーカスを移動すると消えます。

![ヒント](images/controls/tool-tip.png)

> **重要な API**:[ツールヒント クラス](/uwp/api/Windows.UI.Xaml.Controls.ToolTip)、 [ToolTipService クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.tooltipservice)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ユーザーに操作の実行を指示する前に、ヒントを使ってコントロールに関する詳しい情報を表示します。 ヒントは慎重に使い、タスクを完了しようとしているユーザーにとって明らかに重要である場合にのみ追加します。 1 つの目安は、情報が同じエクスペリエンスのどこかで入手できる場合、ヒントは必要ありません。 価値あるヒントによって、不明瞭な操作を明確にします。

ヒントはどのような場合に使えばよいでしょうか。 それを判断するには、以下の質問を考えます。

- **ポインターのポインターを合わせるとベースの情報が表示される必要がありますか。**
    そうでない場合は、別のコントロールを使います。 ヒントは、ユーザーの操作の結果としてのみ表示します。自動的には表示しません。

- **コントロールには、テキスト ラベルがありますか。**
    ない場合は、ヒントを使ってラベルを表示します。 UX の設計では、ほとんどのコントロールにインラインでラベルを付けることをお勧めします。それらのコントロールには、ヒントは必要ありません。 アイコンだけが表示されるツール バー コントロールとコマンド ボタンには、ヒントが必要です。

- **オブジェクトは、これ以上の情報の説明から特典教えてください。**
    そうであれば、ヒントを使います。 ただし、このテキストは、主要なタスクに必須なものではなく、補助的なものである必要があります。 必須なものであれば、直接 UI に配置して、ユーザーが探さなくても済むようにします。

- **補足情報と、エラー、警告、または状態は**
    その場合は、ポップアップなど、他の UI 要素を使います。

- **ユーザーは、チップと対話する必要がありますか。**
    その場合は、別のコントロールを使います。 ヒントはマウスを動かすと消えるため、ユーザーはヒントを操作できません。

- **ユーザーは、補足情報を印刷する必要がありますか。**
    その場合は、別のコントロールを使います。

- **ユーザーは増やしたり、いたずらのヒントを検索しますか。**
    その場合は、別の手段を使うことを検討します。何もしない、という選択肢もあります。 煩わしいと感じる可能性があってもヒントを使う場合は、ユーザーがヒントをオフにできるようにします。

## <a name="example"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/ToolTip">アプリを開き、ToolTip の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

Bing 地図アプリのヒントです。

![Bing Maps アプリのヒントです](images/control-examples/tool-tip-maps.png)

## <a name="create-a-tooltip"></a>ToolTip の作成

[ToolTip](/uwp/api/Windows.UI.Xaml.Controls.ToolTip) は、その所有者である別の UI 要素に割り当てる必要があります。 [ToolTipService](/uwp/api/windows.ui.xaml.controls.tooltipservice) クラスは静的メソッドを提供し、ToolTip を表示します。

XAML では、**ToolTipService.Tooltip** 添付プロパティを使用して ToolTip を所有者に割り当てます。

```xaml
<Button Content="Submit" ToolTipService.ToolTip="Click to submit"/>
```

コードで、[ToolTipService.SetToolTip](/uwp/api/windows.ui.xaml.controls.tooltipservice.settooltip) メソッドを使用して ToolTip を所有者に割り当てます。

```xaml
<Button x:Name="submitButton" Content="Submit"/>
```

```csharp
ToolTip toolTip = new ToolTip();
toolTip.Content = "Click to submit";
ToolTipService.SetToolTip(submitButton, toolTip);
```

### <a name="content"></a>Content

任意のオブジェクトを ToolTip の[コンテンツ](/uwp/api/windows.ui.xaml.controls.contentcontrol.content)として使用できます。 ToolTip で[イメージ](/uwp/api/windows.ui.xaml.controls.image)を使用する例を次に示します。

```xaml
<TextBlock Text="store logo">
    <ToolTipService.ToolTip>
        <Image Source="Assets/StoreLogo.png"/>
    </ToolTipService.ToolTip>
</TextBlock>
```

### <a name="placement"></a>配置

既定では、ToolTip はポインターの上部に中央揃えで表示されます。 配置はアプリ ウィンドウによって制約されていないため、ToolTip が部分的に表示されたり、完全にアプリ ウィンドウの境界の外部に表示されたりすることがあります。

広範な調整は、使用、[配置](/uwp/api/windows.ui.xaml.controls.tooltip.placement)プロパティまたは**ToolTipService.Placement**添付プロパティを上、左、下、またはポインターの右にツールヒントを描画する必要があるかどうかを指定します。 設定することができます、 [VerticalOffset](/uwp/api/windows.ui.xaml.controls.tooltip.verticaloffset)または[HorizontalOffset](/uwp/api/windows.ui.xaml.controls.tooltip.horizontaloffset)プロパティをポインターと、ツールヒントの間の距離を変更します。 2 つのオフセット値の 1 つだけ配置のままにすると配置は、上部または下部にある HorizontalOffset と verticaloffset があるか、右の最後の位置に影響します。

```xaml
<!-- An Image with an offset ToolTip. -->
<Image Source="Assets/StoreLogo.png">
    <ToolTipService.ToolTip>
        <ToolTip Content="Offset ToolTip."
                 Placement="Right"
                 HorizontalOffset="20"/>
    </ToolTipService.ToolTip>
</Image>
```

正確に新しいを使用して、配置を調整するには、ツールヒントを参照しているコンテンツが隠れる場合、 **PlacementRect**プロパティ。 PlacementRect は、ツールヒントの位置に固定し、この領域の外側にツールヒントを描画するための十分な画面領域が提供される、ツールヒントがありませんが、領域としても機能します。 ツールヒントの所有者、および高さの相対的な四角形の原点と、排他領域の幅を指定することができます。 [配置](/uwp/api/windows.ui.xaml.controls.tooltip.placement)プロパティは、上、左、下、または、PlacementRect の右にツールヒントが描画する場合を定義します。 

```xaml
<!-- An Image with a non-occluding ToolTip. -->
<Image Source="Assets/StoreLogo.png" Height="64" Width="96">
    <ToolTipService.ToolTip>
        <ToolTip Content="Non-occluding ToolTip."
                 PlacementRect="0,0,96,64"/>
    </ToolTipService.ToolTip>
</Image>
```

## <a name="recommendations"></a>推奨事項

- ヒントは慎重に使います (または使わない)。 ヒントは作業の中断になります。 ヒントはポップアップと同じように煩わしい場合があるため、大きな付加価値がない限り使わないでください。
- ヒントのテキストは簡潔なものにします。 ヒントは短い文やフレーズに適しています。 大きなテキストのまとまりは圧迫感を与えることがあり、ユーザーが読み終える前にヒントがタイムアウトする可能性があります。
- 役に立つ補足的なヒント テキストを作成します。 ヒントのテキストは、情報として役に立つ必要があります。 表示しなくても明らかな情報や、既に画面上に表示されている内容の繰り返しなどは避けます。 ヒントのテキストは常に表示されているわけではないため、ユーザーが必ずしも読まなくても問題がないような、補足的な情報である必要があります。 重要な情報は、名前から判別できるコントロール ラベルを使うか、補足的なテキストを適切な場所に配置することで伝えるようにします。
- 状況に応じて画像を使います。 ヒント内に画像を使うとよい場合もあります。 たとえば、ユーザーがハイパーリンクの上にカーソルを置いたときに、ヒントを使ってリンク先ページのプレビューを表示できます。
- 既に UI に表示されているテキストは、ヒントとして表示しないでください。 たとえば、ボタンと同じテキストを表示するヒントをボタンに表示しないでください。
- ヒント内に対話的なコントロールを配置しないでください。
- 対話的に見えるような画像をヒント内に配置しないでください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [ツールヒント クラス](https://msdn.microsoft.com/library/windows/apps/br227608)
