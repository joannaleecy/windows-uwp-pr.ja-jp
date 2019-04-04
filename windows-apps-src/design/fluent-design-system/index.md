---
description: Fluent Design とアプリに組み込む方法について学習します。
title: Windows 用の Fluent Design System
keywords: UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス, Fluent Design System
ms.date: 03/07/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: e8a650fcb1edfcd937ed6e42dacc4473627d853f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583378"
---
# <a name="the-fluent-design-system-for-windows-app-creators"></a>Windows アプリ作成者用の Fluent Design System

![Fluent Design のヘッダー](images/fluentdesign-app-header.jpg)

## <a name="introduction"></a>概要

Fluent Design System は、順応性が高く、親近感があり、美しいユーザー インターフェイスを作成するためのシステムです。

## <a name="principles"></a>原則

**順応性:各デバイスで自然な Fluent エクスペリエンスを得られる**

Fluent エクスペリエンスは環境に適応します。 タブレット、デスクトップ PC、Xbox で軽快な Fluent エクスペリエンスを得られます。Mixed Reality ヘッドセットでの動作も優れています。 PC の追加モニターなど、多くのハードウェアを追加しても、Fluent エクスペリエンスでそれらを活用できます。

**親近感:Fluent エクスペリエンスは直感的で、強力である**

Fluent エクスペリエンスは動作と意図を読み取ります。すなわち、必要なものを把握および予想します。 ユーザーとアイデアが物理的に離れているかどうかに関係なく、それらを統合します。

**美しさ:Fluent エクスペリエンスは魅力的で、臨場感がある**

現実世界の要素を組み込むことで、Fluent エクスペリエンスでは基本的な機能を活用できます。 直感的かつ本能的に情報を整理できるように、ライト、影、モーション、深度、テクスチャを使用します。


## <a name="applying-fluent-design-to-your-app-with-uwp"></a>UWP によるアプリへの Fluent Design の適用

![Fluent Design のロゴ](images/fluentdesign_header.png)

設計ガイドラインでは、アプリに Fluent Design の原則を適用する方法について説明します。 どのような種類のアプリでしょうか。 ガイドラインの多くはあらゆるプラットフォームに適用できますが、Fluent Design をサポートするための UWP (ユニバーサル Windows プラットフォーム) を作成しました。

Fluent Design 機能は UWP に組み込まれています。 これらの機能のいくつか (有効ピクセルやユニバーサル入力システムなど) は、自動的に取り込まれます。 これらの機能を利用するために追加のコードを記述する必要はありません。 他の機能 (アクリル効果など) はオプションであり、それらの機能をアプリに取り込むには、機能を追加するためのコードを記述します。

> Fluent Design 機能を使用して既存の WPF または Windows アプリケーションの外観や機能を高めることができるように、UWP コントロールをデスクトップに追加しています。 詳細については、[WPF および Windows フォーム アプリケーションでの UWP コントロールのホスト](/windows/uwp/xaml-platform/xaml-host-controls)に関するページを参照してください。

<!-- To apply Fluent Design to your app, follow our guidelines and use UWP (Universal Windows Platform) you can use UWP UI features combined with best practices for creating apps that perform beautifully on all types of Windows-powered devices. -->

設計ガイダンスに加え、Fluent Design の記事では、設計を実現させるコードの記述方法も示されています。 UWP では、マークアップベースの言語である XAML が使用されます。これにより、ユーザー インターフェイスが作成しやすくなります。 次に例を示します。

```xaml
<Grid BorderBrush="Blue" BorderThickness="4">
    <TextBox Text="Design with XAML" Margin="20" Padding="16,24"/>
</Grid>
```

![](images/xaml-example.png)


> UWP を初めて開発する場合は、[UWP の概要に関するページ](https://developer.microsoft.com/windows/apps/getstarted)を参照してください。

## <a name="find-a-natural-fit"></a>最適なデザインを見つける

さまざまなデバイスでアプリを自然に操作してもらうにはどのようにすればいいですか? それぞれのデバイスに合わせて設計されたように感じさせることです。 無駄な領域がなく (密集しない)、異なる画面サイズに対応する UI レイアウトでは、使用するデバイス用に設計されたかのような自然な使用感を得られます。

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-size-classes.jpg)
    :::column-end:::
    :::column span="2":::
        **Design for the right breakpoints**

        Instead of designing for every individual screen size, focusing on a few key widths (also called "breakpoints") can greatly simplify your designs and code while still making your app look great on small to large screens.

        [Learn about screen sizes and breakpoints](/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/rspd-resize.gif)
    :::column-end:::
    :::column span="2":::
        **Create a responsive layout**

        For an app to feel natural, it should adapt its layout to different screen sizes and devices. You can use automatic sizing, layout panels, visual states, and even separate UI definitions in XAML to create a responsive UI.

        [Learn about responsive design](/windows/uwp/design/layout/responsive-design)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/devices.jpg)
    :::column-end:::
    :::column span="2":::
        **Design for a spectrum of devices**

        UWP apps can run on a wide variety of Windows-powered devices. It's helpful to understand which devices are available, what they're made for, and how users interact with them.

        [Learn about UWP devices](/windows/uwp/design/devices/)
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/keyboard-shortcuts.jpg)
    :::column-end:::
    :::column span="2":::
        **Optimize for the right input**

        UWP apps automatically support common mouse, keyboard, pen, and touch interactions&mdash;there's nothing extra you have to do. But you can enhance your app with optimized support for specific inputs, like pen and the Surface Dial.

        [Learn about inputs and interactions](/windows/uwp/design/input/input-primer)
:::row-end:::

## <a name="make-it-intuitive"></a>直感的なものにする

ユーザーの想像のとおりに動作するため、直観的に操作できます。 アクセシビリティとグローバリゼーションを実現するためにコントロールとパターンを確立し、プラットフォーム サポートを活用することで、操作の手間が省け、生産性が向上します。

共感を得るには、適切なタイミングで適切な処理を行います。

Fluent エクスペリエンスは一貫性のあるコントロールとパターンを使用するため、ユーザーが学習したとおりに動作します。 Fluent エクスペリエンスでは幅広い物理的な機能を使用してユーザーにアクセスします。グローバリゼーション機能が組み込まれているため、世界中のユーザーが使用することができます。

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-navview.png)
    :::column-end:::
    :::column span="2":::
        **Provide the right navigation**

        Create an effortless experience by using the right app structure and navigation components.

        [Learn about navigation](/windows/uwp/design/basics/navigation-basics/)
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-commanding.png)
    :::column-end:::
    :::column span="2":::
        **Be interactive**

        Buttons, command bars, keyboard shortcuts, and context menus enable users to interact with your app; they're the tools that change a static experience into something dynamic.

        [Learn about commanding](/windows/uwp/design/basics/commanding-basics/)
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-controls-2.jpg)
    :::column-end:::
    :::column span="2":::
        **Use the right control for the job**

        Controls are the building blocks of the user interface; using the right control helps you create a user interface that behaves the way users expect it to.  UWP provides more than 45 controls,ranging from simple buttons to powerful data controls.

        [Learn about UWP controls](/windows/uwp/design/controls-and-patterns/)
:::row-end:::

:::row:::
    :::column:::
        ![inclusive image](images/thumbnail-inclusive.png)
    :::column-end:::
    :::column span="2":::
        **Be inclusive**
        A well-design app is accessible to people with disabilities. With some extra coding, you can share your app with people around the world.

        [Learn about Usability](/windows/uwp/design/usability/)
:::row-end:::

## <a name="be-engaging-and-immersive"></a>魅力と臨場感を実現する

Fluent Design に派手な効果はありません。 脳で効率的に処理するようにプログラムされたエクスペリエンスをエミュレートするため、ユーザー エクスペリエンスを拡張する物理的な効果が組み込まれています。

## <a name="use-light"></a>ライトの使用

ライトは、関心を集めるための方法です。 ライトによって、使用する場所の雰囲気や特徴が作り出されます。ライトは、情報に焦点を当てるための実用的なツールです。

UWP アプリにライトを追加する

:::row:::
    :::column:::
        ![fpo image](../style/images/Nav_Reveal_Animation.gif)
    :::column-end:::
    :::column span="2":::
        **Reveal highlight**

        [Reveal highlight](../style/reveal.md) uses light to make interactive elements stand out. Light illuminates the elements the user can interact with, revealing hidden borders. Reveal is automatically enabled on some controls, such as list view and grid view. You can enable it on other controls by applying our predefined Reveal highlight styles.
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](../style/images/traveling-focus-fullscreen-light-rf.gif)
    :::column-end:::
    :::column span="2":::
        **Reveal focus**

        [Reveal focus](../style/reveal-focus.md) uses light to call attention to the element that currently has input focus.
:::row-end:::

## <a name="create-a-sense-of-depth"></a>奥行きの作成

私たちは、3 次元の世界で暮らしています。 奥行きを UI に意図的に組み込むと、視覚的な階層が作成され、フラットな 2-D インターフェイスを、より効果的に情報と概念を提示するインターフェイスに変換することができます。 奥行きは、階層化された物理環境では、物事が相互にどのように関連するかを再構成します。

UWP アプリに奥行きを追加する

:::row:::
    :::column:::
        ![fpo image](../motion/images/_parallax_v2.gif)
    :::column-end:::
    :::column span="2":::
        **Parallax**

        [Parallax](../motion/parallax.md) creates the illusion of depth by making items in the foreground appear to move more quickly than items in the background.
:::row-end:::

## <a name="incorporate-motion"></a>モーションの組み込み

モーションのデザインは映画のようなものと考えてください。 シームレスな切り替えによって、ユーザーをストーリーに注目させておき、優れたエクスペリエンスを実現することができます。 モーションのデザインにそのような感覚を取り込むことで、あるタスクから別のタスクへ映画のようにスムーズにユーザーを移行させることができます。

UWP アプリにモーションを追加する

:::row:::
    :::column:::
        ![continuity gif](images/continuityXbox.gif)
    :::column-end:::
    :::column span="2":::
        **Connected animations**

        [Connected animations](../motion/connected-animation.md) help the user maintain context by creating a seamless transition between scenes.
:::row-end:::

## <a name="build-it-with-the-right-material"></a>適切な素材を使用して作成する

現実の世界で私たちの周囲にあるものは、ある種の感覚と刺激を与えます。 そういったものは、折れ曲がったり、伸びたり、弾んだり、砕かれたり、滑らかに動いたりします。 こうした素材の質感をデジタル環境に取り込むことで、ユーザーが利用したいと思うようなデザインを実現できます。

UWP アプリに素材を追加する

:::row:::
    :::column:::
        ![fpo image](../style/images/acrylic_lighttheme_base.png)
    :::column-end:::
    :::column span="2":::
        **Acrylic**

        [Acrylic](../style/acrylic.md) is a translucent material that lets the user see layers of content, establishing a hierarchy of UI elements.
:::row-end:::

## <a name="design-toolkits-and-code-samples"></a>設計ツールキットとコード サンプル

Fluent Design で独自アプリの作成を始めてみませんか。 Adobe XD、Adobe Illustrator、Adobe Photoshop、Framer、Sketch 用のツールキットを使用すると、設計をすぐに始められます。また、サンプルを使用すると、コーディングの時間が短縮されます。

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-toolkits.jpg)
    :::column-end:::
    :::column span="2":::
        **Design toolkits and samples page**

        Check out our [Design toolkits and samples page](/windows/uwp/design/downloads/)
:::row-end:::









