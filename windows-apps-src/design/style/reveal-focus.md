---
author: cphilippona
description: フォーカスがあるユーザーにゲーム パッドまたはキーボードのフォーカスを移動すると、フォーカスを設定できる要素の枠線のアニメーション効果を照明を表示します。
title: フォーカスを表示します。
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
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2813964"
---
# <a name="reveal-focus"></a>フォーカスを表示します。

![ヒーロー イメージ](images/header-reveal-focus.svg)

フォーカスがある[環境を 10 フィート](/windows/uwp/design/devices/designing-for-tv)、Xbox 1 およびテレビ画面などの光の効果を表示します。 ユーザーがゲームパッドやキーボードのフォーカスをボタンなどのフォーカス可能な要素に移動したときに、その要素の境界線がアニメーション化されます。 表示フォーカスは既定で無効になっていますが、簡単に有効にできます。 

(、強調表示効果で対話型の要素を強調表示する照明影響[出現を強調表示する記事](/windows/uwp/design/style/reveal)を参照してください)。


> **重要な API**: [Application.FocusVisualKind プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.FocusVisualKind)、[FocusVisualKind 列挙](https://docs.microsoft.com/uwp/api/windows.ui.xaml.focusvisualkind)、[Control.UseSystemFocusVisuals プロパティ](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)

## <a name="how-it-works"></a>動作の仕組み
要素の境界線のアニメーション効果の光彩を追加して通話フォーカスのある要素に注意を表示します。

![表示のビジュアル効果](images/traveling-focus-fullscreen-light-rf.gif)

これは、場所、ユーザー可能性がありますいないは完全に注意を払い TV の画面全体の 10 フィート シナリオで特に便利です。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされている場合は、ここをクリックして<a href="xamlcontrolsgallery:/item/RevealFocus">アプリを開きアクションの表示のフォーカスを参照してください</a>。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="how-to-use-it"></a>使用方法

明らかにフォーカスが既定では無効です。 有効にするには、次の手順を実行します。
1. アプリのコンストラクターで、[AnalyticsInfo.VersionInfo.DeviceFamily](/uwp/api/windows.system.profile.analyticsversioninfo.DeviceFamily) プロパティを呼び出し、現在のデバイス ファミリが `Windows.Xbox` かどうかを調べます。
2. デバイス ファミリが `Windows.Xbox` である場合は、[Application.FocusVisualKind](/uwp/api/windows.ui.xaml.application.FocusVisualKind) プロパティを `FocusVisualKind.Reveal` に設定します。 

```csharp
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Xbox")
    {
        this.FocusVisualKind = FocusVisualKind.Reveal;
    }
```

**FocusVisualKind**プロパティを設定した後は、 [UseSystemFocusVisuals](/uwp/api/Windows.UI.Xaml.Controls.Control.UseSystemFocusVisuals)プロパティ設定されている**場合は True** (ほとんどのコントロールの既定値) をすべてのコントロールにフォーカスを明示できるように効果が自動的に適用します。 

## <a name="why-isnt-reveal-focus-on-by-default"></a>なぜ出現フォーカスに既定でですか。 
わかるように、アプリが Xbox で実行していることを検出した場合は、フォーカスの表示を有効にするのには簡単です。 それでは、システムによって自動的に有効にならないのはなぜでしょうか。 明らかにフォーカスがフォーカスの外観のサイズを向上するため、UI レイアウトで問題が発生する可能性があります。 場合によっては、アプリ用に最適化する出現フォーカス効果をカスタマイズするされます。

## <a name="customizing-reveal-focus"></a>フォーカスの表示をカスタマイズします。

フォーカスを明らかに効果をカスタマイズするには、各コントロールのフォーカスの視覚的なプロパティを変更する: [FocusVisualPrimaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryThickness)、 [FocusVisualSecondaryThickness](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryThickness)、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)、および[FocusVisualSecondaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)します。 これらのプロパティでは、フォーカスの四角形の色と太さをカスタマイズできます。 (これらは、[視認性の高いフォーカスの視覚効果](https://docs.microsoft.com/windows/uwp/design/input/guidelines-for-visualfeedback#high-visibility-focus-visuals)を作成する場合と同じプロパティです。) 

Customzing を開始する前に、それは明らかにフォーカスを移動するコンポーネントについては、もう少し知っておくと便利です。

既定の表示フォーカス ビジュアルに 3 つの部分があります: プライマリの枠線、第 2 の枠線と光彩表示します。 プライマリ境界線は、**2 px** の幅があり、セカンダリ境界線の*外側*に描画されます。 セカンダリ境界線は、**1 px** の幅があり、プライマリ境界線の*内側*に描画されます。 フォーカスの表示] の光彩では、主な枠線の太さに比例太さが設定されてされ、*外*の主な枠線を実行します。

に加えて、静的な要素出現フォーカス ビジュアル機能は、アニメーション効果のある light pulsates に置いたときに、フォーカスを移動するときのフォーカスの方向に移動します。

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

表示フォーカスの外観の色を変更するには、 [FocusVisualPrimaryBrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualPrimaryBrush)と[FocusVisualSecondaryBrush](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.FocusVisualSecondaryBrush)プロパティを使用します。

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

フォーカスの表示をカスタマイズするのには、別の方法では、システムで用意したフォーカス ビジュアルで独自の視覚的な状態を使用して図面を停止します。 詳しくは、「[フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)」をご覧ください。


## <a name="reveal-focus-and-the-fluent-design-system"></a>フォーカスと Fluent デザイン システムを表示します。

フォーカスがある light をアプリに追加する Fluent デザイン システム コンポーネントを表示します。 Fluent Design System およびその他のコンポーネントについて詳しくは、[UWP 用の Fluent Design の概要](../fluent-design-system/index.md)をご覧ください。

## <a name="related-articles"></a>関連記事

- [強調表示を表示します。](https://docs.microsoft.com/windows/uwp/design/style/reveal)
- [Xbox およびテレビ向け設計](/windows/uwp/design/devices/designing-for-tv)
- [ゲームパッドとリモコンの操作](https://docs.microsoft.com/windows/uwp/design/input/gamepad-and-remote-interactions)
- [フォーカスの視覚効果のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619895)
- [コンポジションの効果](https://msdn.microsoft.com/windows/uwp/graphics/composition-effects)
- [システムの科学: Fluent Design と奥行き](https://medium.com/microsoft-design/science-in-the-system-fluent-design-and-depth-fb6d0f23a53f)
- [システムの科学: Fluent Design と明るさ](https://medium.com/microsoft-design/the-science-in-the-system-fluent-design-and-light-94a17e0b3a4f)
