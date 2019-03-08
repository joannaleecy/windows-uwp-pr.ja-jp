---
description: フォーカスがあるユーザーがそれらにゲームパッドまたはキーボード フォーカスを移動すると、フォーカスを設定できる要素の境界線をアニメーション化する照明効果を表示します。
title: フォーカスを表示します。
template: detail.hbs
ms.date: 03/01/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: chphilip
design-contact: ''
dev-contact: stevenki
ms.localizationpriority: medium
ms.openlocfilehash: 7bcceb8d44b6d92cab05a9c077531b3fe1b05c79
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651757"
---
# <a name="reveal-focus"></a>フォーカスを表示します。

![ヒーロー イメージ](images/header-reveal-focus.svg)

表示のフォーカスがあるの照明効果を[10 フィート エクスペリエンス](/windows/uwp/design/devices/designing-for-tv)、Xbox One やテレビ画面など。 ユーザーがゲームパッドやキーボードのフォーカスをボタンなどのフォーカス可能な要素に移動したときに、その要素の境界線がアニメーション化されます。 表示フォーカスは既定で無効になっていますが、簡単に有効にできます。 

(強調表示効果、対話型の要素を強調表示する照明に影響を参照してください、[強調表示の記事](/windows/uwp/design/style/reveal))。


> **重要な Api**:[Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind)、 [FocusVisualKind enum](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind)、 [Control.UseSystemFocusVisuals プロパティ](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)

## <a name="how-it-works"></a>方法
フォーカスされた要素に絞る呼び出しを明らかには、要素の境界線のアニメーションの光彩の追加。

![表示のビジュアル効果](images/traveling-focus-fullscreen-light-rf.gif)

これは、場所、ユーザーことがある注意を怠る完全なテレビ画面全体を 10-foot シナリオで特に役立ちます。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/RevealFocus">アプリを開き、操作の表示のフォーカスを参照してください</a>します。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="how-to-use-it"></a>使用方法

明らかにフォーカスが既定ではオフです。 有効にするには、次の手順を実行します。
1. アプリのコンストラクターで、[AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo.DeviceFamily) プロパティを呼び出し、現在のデバイス ファミリが `Windows.Xbox` かどうかを調べます。
2. デバイス ファミリが `Windows.Xbox` である場合は、[Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application.FocusVisualKind) プロパティを `FocusVisualKind.Reveal` に設定します。 

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

設定した後、 **FocusVisualKind**プロパティ、システムは自動的に表示フォーカス効果を適用のすべてのコントロール[UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)プロパティに設定されて**True**(ほとんどのコントロールの既定値)。 

## <a name="why-isnt-reveal-focus-on-by-default"></a>既定でフォーカスの表示にできない理由ですか。 
ご覧のとおり、Xbox で実行されているアプリが検出したときに表示フォーカスをオンにすることは簡単です。 それでは、システムによって自動的に有効にならないのはなぜでしょうか。 フォーカスの表示には、フォーカスのビジュアルのサイズが増加するため、UI レイアウトの問題が発生する可能性があります。 場合によっては、アプリ用に最適化する表示のフォーカスの効果をカスタマイズするします。

## <a name="customizing-reveal-focus"></a>表示フォーカスをカスタマイズします。

各コントロールのフォーカス ビジュアルのプロパティを変更することで、フォーカスの表示の効果をカスタマイズできます。[FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness)、 [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)、および[FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)します。 これらのプロパティでは、フォーカスの四角形の色と太さをカスタマイズできます。 (これらは、[視認性の高いフォーカスの視覚効果](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals)を作成する場合と同じプロパティです。) 

カスタマイズを開始する前に、それをお勧め表示フォーカスを構成するコンポーネントについて少し詳しく知る。

既定の表示のフォーカス ビジュアルに 3 つの部分があります。 プライマリの枠線、セカンダリの境界線およびグロー表示します。 プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。 セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。 表示フォーカス光彩がプライマリの境界線の太さに比例した幅と実行、*外*のプライマリの境界線。

表示のフォーカスのビジュアル機能だけでなく、静的な要素の pulsates に置いたときに、フォーカスを移動するときに、フォーカスの方向に移動するアニメーションの光。

![フォーカスのレイヤーを表示します。](images/reveal-breakdown.svg)

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

表示のフォーカス ビジュアルの色を変更するには、使用、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)と[FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)プロパティ。

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

フォーカスの表示をカスタマイズするもう 1 つの方法は、独自のビジュアル状態を使用して描画することによって、システム指定のフォーカスのビジュアルをオプトアウトします。 詳しくは、「[フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)」をご覧ください。


## <a name="reveal-focus-and-the-fluent-design-system"></a>フォーカスと Fluent デザイン システムを表示します。

フォーカスがあるアプリに光を追加する Fluent Design System コンポーネントを表示します。 Fluent Design System およびその他のコンポーネントについて詳しくは、[UWP 用の Fluent Design の概要](../fluent-design-system/index.md)をご覧ください。

## <a name="related-articles"></a>関連記事

- [強調表示を表示します。](https://docs.microsoft.com/windows/uwp/design/style/reveal)
- [Xbox およびテレビ向け設計](/windows/uwp/design/devices/designing-for-tv)
- [ゲームパッドとリモート制御の相互作用](https://docs.microsoft.com/windows/uwp/design/input/gamepad-and-remote-interactions)
- [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)
- [合成効果](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [システムで科学:Fluent デザインと深さ](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [システムで科学:Fluent デザインおよびライト](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
