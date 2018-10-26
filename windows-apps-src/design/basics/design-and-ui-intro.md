---
author: mijacobs
Description: The universal design features included in every UWP app help you build apps that scale beautifully across a range of devices.
title: ユニバーサル Windows プラットフォーム (UWP) アプリ設計の概要 (Windows アプリ)
ms.assetid: 50A5605E-3A91-41DB-800A-9180717C1E86
ms.author: mijacobs
ms.date: 05/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 422a6b40c86a84367054a20cabe1a0b0a32cb89d
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5560452"
---
# <a name="introduction-to-uwp-app-design"></a>UWP アプリ設計の概要

![サンプルの照明アプリ](images/introUWP-header.jpg)

ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。

これは規範的な規則の一覧ではなく、進化する [Fluent Design System](../fluent-design-system/index.md)、およびアプリ構築コミュニティのニーズに適応するように設計された生きたドキュメントです。

この記事では、あらゆる UWP アプリに含まれているユニバーサル デザイン機能の概要を説明します。これらの機能により、さまざまなデバイス間で美しくスケーリングされるユーザー インターフェイス (UI) を構築できます。

## <a name="effective-pixels-and-scaling"></a>有効ピクセルとスケーリング

UWP アプリでは、タブレット、PC、TV からすべての[Windows 10 デバイス](../devices/index.md)で実行します。 さまざまなデバイスや画面サイズで適切な外観の UI を設計するには、どのように行うかどうか。

![さまざまなデバイス上にある同じアプリ](images/universal-image-1.jpg)

UWP は、読みやすくしやすいですべてのデバイスや画面サイズとの対話になるように UI 要素を自動的に調整することで役立ちます。

デバイスでアプリを実行するとき、システムでは、UI 要素を画面に表示する方法を正規化するアルゴリズムを使います。 このスケーリング アルゴリズムでは、視聴距離と画面の密度 (ピクセル/インチ) を考慮して、体感的なサイズを最適化します (物理的なサイズではありません)。 スケーリング アルゴリズムによって、10 フィート離れた Surface Hub における 24 ピクセルのフォントが、数インチ離れた 5 インチ サイズの電話における 24 ピクセルのフォントと同じようにユーザーに読みやすい状態で表示されます。

![さまざまなデバイスの視聴距離](images/scaling-chart.png)

スケーリング システムのしくみのため、UWP アプリをデザインするときには、実際の物理ピクセルではなく、有効ピクセルでデザインすることになります。 有効ピクセル (epx) は仮想的な測定単位で、画面の密度とは無関係にレイアウトのサイズと間隔を表すために使用されます。 (ガイドラインでは、epx、ep、および px を区別しないで使用しています。)

設計時には、ピクセル密度と実際の画面解像度を無視できます。 その代わり、サイズ クラスの有効な解像度 (有効ピクセル単位の解像度) が向上するように設計します (詳しくは、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください)。

> [!TIP]
> イメージ編集プログラムで画面のモックアップを作成するときは、DPI を 72 に設定し、画像サイズを、対象のサイズ クラスで有効な解像度に設定します サイズ クラスと有効な解像度の一覧については、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」を参照してください。

### <a name="multiples-of-four"></a>4 の倍数

:::row:::
    :::column span:::
        The sizes, margins, and positions of UI elements should always be in **multiples of 4 epx** in your UWP apps.

        UWP scales across a range of devices with scaling plateaus of 100%, 125%, 150%, 175%, 200%, 225%, 250%, 300%, 350%, and 400%. The base unit is 4 because it's the only integer that can be scaled by non-whole numbers (e.g. 4*1.5 = 6). Using multiples of four aligns all UI elements with whole pixels and ensures UI elements have crisp, sharp edges. (Note that text doesn't have this requirement; text can have any size and position.)
    :::column-end:::
    :::column:::
        ![grid](images/4epx.svg)
    :::column-end:::
:::row-end:::

## <a name="layout"></a>レイアウト

UWP アプリは、すべてのデバイスに合わせて自動的に拡大縮小されるので、すべてのデバイスの UWP アプリの設計は同じ構造になっています。 UWP アプリの UI の最初から始めましょう。

### <a name="windows-frames-and-pages"></a>Windows、フレーム、ページ

:::row:::
    :::column:::
        When a UWP app is launched on any Windows 10 device, it launches in a [Window](/uwp/api/Windows.UI.Xaml.Controls.Window) with a [Frame](/uwp/api/Windows.UI.Xaml.Controls.Frame), which can navigate between [Page](/uwp/api/Windows.UI.Xaml.Controls.Page) instances.
    :::column-end:::
    :::column:::
        ![Frame](images/frame.svg)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        You can think of your app's UI as a collection of pages. It's up to you to decide what should go on each page, and the relationships between pages.

        To learn how you can organize your pages, see [Navigation basics](navigation-basics.md).
    :::column-end:::
    :::column:::
        ![Frame](images/collection-pages.svg)
    :::column-end:::
:::row-end:::

### <a name="page-layout"></a>ページのレイアウト

それらのページの外観はどのようになるでしょうか。 ほとんどのページでは一貫性を保つために一般的な構造に従うため、ユーザーはアプリのページ間およびページ内を簡単に移動できます。 通常、ページには次の 3 つの種類の UI 要素が含まれています。

- [ナビゲーション](navigation-basics.md)要素は、表示するコンテンツをユーザーが選択できるようにします。
- [コマンド](commanding-basics.md)要素は、操作、保存、コンテンツの共有などの操作を開始します。
- [コンテンツ](content-basics.md)要素は、アプリのコンテンツを表示します。

![一般的なレイアウト パターン](../layout/images/page-components.svg)

UWP アプリの一般的なパターンを実装する方法の詳細については、「[ページのレイアウト](../layout/page-layout.md)」を参照してください。

Visual Studio で [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio/tree/master) を使用してアプリのレイアウトを使い始めることもできます。

## <a name="controls"></a>コントロール

UWP の設計プラットフォームには、すべての Windows デバイスで適切に動作することが保証されている一連のコモン コントロールが用意されており、[Fluent Design System](../fluent-design-system/index.md) の原則に従っています。 これらのコントロールには、ボタンやテキスト要素などの単純なコントロールから、一連のデータとテンプレートからリストを生成する高度なコントロールまで、すべてのものが含まれます。

![UWP コントロール](../style/images/color/windows-controls.svg)

UWP コントロールとコントロールに基づいて作成できるパターンの全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」セクションを参照してください。

## <a name="style"></a>スタイル

一般的なコントロールは、システム テーマとアクセント カラーを自動的に反映し、すべての入力の種類に対応し、すべてのデバイスに合わせて拡大縮小されます。 このように、Fluent Design System を反映しているため、順応性が高く、親近感があり、優れた美しさを持っています。 一般的なコントロールでは、既定のスタイルでライト、モーション、深度を使用しているため、コントロールを使用することで、アプリに Fluent Design System を組み込んでいることになります。

一般的なコントロールは高度にカスタマイズでき、コントロールの前景色を変更することも、外観を完全にカスタマイズすることもできます。 コントロールの既定のスタイルを変更するには、[軽量なスタイル設定](../controls-and-patterns/xaml-styles.md#lightweight-styling)を使用するか、XAML で[カスタム コントロール](../controls-and-patterns/control-templates.md)を作成します。

![アクセント カラーの gif](images/intro-style.gif)

## <a name="shell"></a>Shell

:::row:::
    :::column:::
        Your UWP app will interact with the broader Windows experience with tiles and notifications in the Windows [Shell](../shell/tiles-and-notifications/creating-tiles.md).

        Tiles are displayed in the Start menu and when your app launches, and they provide a glimpse of what's going on in your app. Their power comes from the content behind them, and the intelligence and craft with which they're offered up.

        UWP apps have four tile sizes (small, medium, wide, and large) that can be customized with the app's icon and identity. For guidance on designing tiles for your UWP app, see [Guidelines for tile and icon assets](../shell/tiles-and-notifications/app-assets.md).
    :::column-end:::
    :::column:::
        ![tiles on start menu](images/shell.svg)
    :::column-end:::
:::row-end:::

## <a name="inputs"></a>入力

:::row:::
    :::column:::
        UWP apps rely on smart interactions. You can design around a click interaction without having to know or define whether the click comes from a mouse, a stylus, or a tap of a finger. However, you can also design your apps for [specific input modes](../input/input-primer.md).
    :::column-end:::
    :::column:::
        ![inputs](images/inputs.svg)
    :::column-end:::
:::row-end:::

## <a name="devices"></a>デバイス

![デバイス](../layout/images/size-classes.svg)

同様に、UWP では、さまざまなデバイスに合わせてアプリを自動的にスケーリングしますが、[特定のデバイス向けに UWP アプリを最適化](../devices/index.md)することもできます。

## <a name="usability"></a>使いやすさ

<img src="https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/REYaAb?ver=727c">

最後に重要な点として、ユーザビリティの目的は、アプリのエクスペリエンスをすべてのユーザーに開かれたものにすることです。 すべての人が、本当に包括的なユーザー エクスペリエンスの恩恵を受けます。すべてのユーザーに対してアプリを使いやすくする方法については、「[UWP アプリの操作性](../usability/index.md)」を参照してください。

国際的なユーザーを対象に設計している場合は、[グローバリゼーションとローカライズ](../globalizing/globalizing-portal.md)を確認することをお勧めします。

視覚障碍、聴覚障碍、運動障碍を持つユーザーに関して、「[アクセシビリティ機能](../accessibility/accessibility-overview.md)」も検討してください。 アクセシビリティが最初から設計に組み込まれている場合は、[アプリをアクセシビリティ対応にする](../accessibility/accessibility-in-the-store.md)ことにほとんど時間と労力がかかりません。

## <a name="tools-and-design-toolkits"></a>ツールと設計ツールキット

基本的な設計機能がわかったので、UWP アプリの設計を開始しましょう。

設計プロセスで役立つさまざまなツールが用意されています。

- [設計ツールキットのページ](../downloads/index.md)をご覧ください。XD、Illustrator、Photoshop、Framer、Sketch の各ツールキット、および追加の設計ツールやフォントのダウンロードが提供されています。

- コンピューターを設定して UWP アプリのコードを記述できるようにするには、「[作業の開始と準備](../../get-started/get-set-up.md)」の記事をご覧ください。

- UWP の UI を実装する方法については、エンド ツー エンドの「[サンプル UWP アプリ](https://developer.microsoft.com/windows/samples)」を参照してください。

## <a name="video-summary"></a>ビデオの概要

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Designing-Universal-Windows-Platform-apps/player]

## <a name="next-fluent-design-system"></a>次: Fluent Design System

Fluent Design (Microsoft のデザイン システム) の背後にある原則や、UWP アプリに組み込むことができる多くの機能について確認する場合は、引き続き「[Fluent Design System](../fluent-design-system/index.md)」を参照してください。

## <a name="related-articles"></a>関連記事

- [UWP アプリとは](../../get-started/universal-application-platform-guide.md)
- [Fluent Design System](../fluent-design-system/index.md)
- [XAML プラットフォームの概要](../../xaml-platform/index.md)
