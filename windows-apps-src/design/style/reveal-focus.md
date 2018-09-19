---
author: cphilippona
description: 表示フォーカスはそれらをユーザーがゲームパッドやキーボードのフォーカスを移動するときにフォーカス可能な要素の境界線をアニメーション化する発光効果。
title: 表示フォーカス
template: detail.hbs
ms.author: mijacobs
ms.date: 03/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: chphilip
design-contact: ''
dev-contact: stevenki
ms.localizationpriority: medium
ms.openlocfilehash: 7b5fa84efbe20368be55a50ce20c8e6e5d1fe439
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4059658"
---
# <a name="reveal-focus"></a>表示フォーカス

![ヒーロー イメージ](images/header-reveal-focus.svg)

表示フォーカスは[10 フィート エクスペリエンス](/windows/uwp/design/devices/designing-for-tv)を Xbox One やテレビ画面などの照明効果。 ユーザーがゲームパッドやキーボードのフォーカスをボタンなどのフォーカス可能な要素に移動したときに、その要素の境界線がアニメーション化されます。 表示フォーカスは既定で無効になっていますが、簡単に有効にできます。 

(表示ハイライト効果、対話型要素を発光[強調表示効果の記事](/windows/uwp/design/style/reveal)を参照してください)。


> **重要な API**: [Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind)、[FocusVisualKind 列挙](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind)、[Control.UseSystemFocusVisuals プロパティ](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)

## <a name="how-it-works"></a>動作の仕組み
フォーカスでは、フォーカスが置かれた要素に注意を表示するには、要素の境界線の周囲のアニメーション化されたグロー部分を追加します。

![表示のビジュアル効果](images/traveling-focus-fullscreen-light-rf.gif)

これは、場所ユーザー可能性がありますが払っていないテレビ画面全体を 10 フィート シナリオで特に便利です。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールした場合は、アプリを<a href="xamlcontrolsgallery:/item/RevealFocus">開き、表示効果のフォーカスの動作をご覧ください。</a>ここをクリックします。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="how-to-use-it"></a>使用方法

フォーカスは既定でオフを表示します。 有効にするには、次の手順を実行します。
1. アプリのコンストラクターで、[AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo.DeviceFamily) プロパティを呼び出し、現在のデバイス ファミリが `Windows.Xbox` かどうかを調べます。
2. デバイス ファミリが `Windows.Xbox` である場合は、[Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application.FocusVisualKind) プロパティを `FocusVisualKind.Reveal` に設定します。 

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

**FocusVisualKind**プロパティを設定した後、表示フォーカス効果は自動的に[UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)プロパティが**True** (ほとんどのコントロールの既定値) に設定されてすべてのコントロールに適用されます。 

## <a name="why-isnt-reveal-focus-on-by-default"></a>既定で表示フォーカスをできない理由かどうか。 
ご覧のように、Xbox で実行されているアプリを検出すると、フォーカスの表示をオンにする非常に簡単です。 それでは、システムによって自動的に有効にならないのはなぜでしょうか。 表示フォーカスには、フォーカス表示のサイズが増加するため、UI レイアウトに問題が発生する可能性があります。 場合によっては、アプリを最適化するために、表示フォーカス効果をカスタマイズするがあります。

## <a name="customizing-reveal-focus"></a>表示フォーカスのカスタマイズ

各コントロールのフォーカス視覚効果プロパティを変更することによって、表示フォーカス効果をカスタマイズすることができます: [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness)、 [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)、および[FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)します。 これらのプロパティでは、フォーカスの四角形の色と太さをカスタマイズできます。 (これらは、[視認性の高いフォーカスの視覚効果](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals)を作成する場合と同じプロパティです。) 

カスタマイズを開始する前に、そのことは、それについては、表示フォーカスを構成するコンポーネントについてもう少し詳しく知っておくと便利です。

既定の表示効果のフォーカス視覚効果は次の 3 つの部分で構成されて: プライマリ境界線、セカンダリ境界線およびグロー表示します。 プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。 セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。 表示フォーカスのグロー プライマリ境界線の太さに比例があり、*外部*プライマリ境界線の周囲を実行します。

だけでなく、静的な要素表示フォーカスの視覚効果機能は、アニメーション化された光を置いたときに停止中は鼓動し、フォーカスを移動するときに、フォーカスの方向に移動します。

![表示フォーカス レイヤー](images/reveal-breakdown.svg)

## <a name="customize-the-border-thickness"></a>境界線の幅のカスタマイズ

コントロールの境界線の種類ごとに幅を変更するには、以下のプロパティを使用します。

| 境界線の種類 | プロパティ |
| --- | --- |
| プライマリ、グロー   | [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness)<br/> (プライマリ境界線を変更すると、グロー部分の幅も比例して変化します。)   |
| セカンダリ   | [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)   |


この例では、ボタンのフォーカス視覚効果で、境界線の幅を変更しています。

```xaml
<Button FocusVisualPrimaryThickness="2" FocusVisualSecondaryThickness="1"/>
```

## <a name="customize-the-margin"></a>余白のカスタマイズ

余白は、コントロールの視覚的な境界線と、フォーカスの視覚効果で示されるセカンダリ境界線の開始点との間にあるスペースです。 既定の余白は、コントロールの境界線から 1 px の幅になります。 この余白は、[FocusVisualMargin](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualMargin) プロパティを変更することでコントロールごとに変更できます。

```xaml
<Button FocusVisualPrimaryThickness="2" FocusVisualSecondaryThickness="1" FocusVisualMargin="-3"/>
```

余白が負の値の場合は境界線がコントロールの中央から遠くなり、正の値の場合はコントロールの中央に近くなります。

## <a name="customize-the-color"></a>色のカスタマイズ

表示フォーカス表示の色を変更するには、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)と[FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)プロパティを使います。

| プロパティ | 既定のリソース | 既定のリソースの値 |
| ---- | ---- | --- | 
| [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush) | SystemControlRevealFocusVisualBrush  | SystemAccentColor |
| [FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)  | SystemControlFocusVisualSecondaryBrush  | SystemAltMediumColor |

(FocusPrimaryBrush プロパティに既定の **SystemControlRevealFocusVisualBrush** リソースが使用されるのは、**FocusVisualKind** が **Reveal** に設定されている場合のみです。 それ以外の場合は、**SystemControlFocusVisualPrimaryBrush** が使用されます。)


個々のコントロールのフォーカス視覚効果の色を変更するには、コントロールのプロパティを直接設定します。 次の例では、ボタンのフォーカス視覚効果の色を上書きしています。

```xaml

<!-- Specifying a color directly -->
<Button
    FocusVisualPrimaryBrush="DarkRed"
    FocusVisualSecondaryBrush="Pink"/>

<!-- Using theme resources -->
<Button
    FocusVisualPrimaryBrush="{ThemeResource SystemBaseHighColor}"
    FocusVisualSecondaryBrush="{ThemeResource SystemAccentColor}"/>    
```

アプリ全体ですべてのフォーカス視覚効果の色を変更するには、**SystemControlRevealFocusVisualBrush** リソースと **SystemControlFocusVisualSecondaryBrush** リソースを独自定義で上書きします。

```xaml
<!-- App.xaml -->
<Application.Resources>

    <!-- Override Reveal Focus default resources. -->
    <SolidColorBrush x:Key="SystemControlRevealFocusVisualBrush" Color="{ThemeResource SystemBaseHighColor}"/>
    <SolidColorBrush x:Key="SystemControlFocusVisualSecondaryBrush" Color="{ThemeResource SystemAccentColor}"/>
</Application.Resources>
```

フォーカス視覚効果の色の変更について詳しくは、「[色のブランド化とカスタマイズ](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#color-branding--customizing)」をご覧ください。


## <a name="show-just-the-glow"></a>グロー部分のみを表示する

プライマリまたはセカンダリのフォーカス視覚効果は使用せず、グローのみを使用する場合は、コントロールの [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush) プロパティを `Transparent` に設定し、[FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness) を `0` に設定します。 この場合は、グローにコントロールの背景色が使用され、境界線がない外観になります。 [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness) を使用して、グローの幅を変更することもできます。

```xaml

<!-- Show just the glow -->
<Button
    FocusVisualPrimaryBrush="Transparent"
    FocusVisualSecondaryThickness="0" />    
```


## <a name="use-your-own-focus-visuals"></a>独自のフォーカス視覚効果を使用する

独自の表示状態を使って描画することによって、システム提供のフォーカスの視覚効果をオプトアウトする別の方法で表示効果のフォーカスをカスタマイズすることです。 詳しくは、「[フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)」をご覧ください。


## <a name="reveal-focus-and-the-fluent-design-system"></a>表示フォーカスと Fluent Design System

表示フォーカスは、アプリに発光する Fluent Design System コンポーネント。 Fluent Design System およびその他のコンポーネントについて詳しくは、[UWP 用の Fluent Design の概要](../fluent-design-system/index.md)をご覧ください。

## <a name="related-articles"></a>関連記事

- [表示ハイライト](https://docs.microsoft.com/windows/uwp/design/style/reveal)
- [Xbox およびテレビ向け設計](/windows/uwp/design/devices/designing-for-tv)
- [ゲームパッドとリモコンの操作](https://docs.microsoft.com/windows/uwp/design/input/gamepad-and-remote-interactions)
- [フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)
- [コンポジションの効果](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [システムの科学: Fluent Design と奥行き](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [システムの科学: Fluent Design と明るさ](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
