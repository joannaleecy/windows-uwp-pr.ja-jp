---
author: mijacobs
Description: Good icons harmonize with typography and with the rest of the design language. They don’t mix metaphors, and they communicate only what’s needed, as speedily and simply as possible.
title: アイコン
ms.assetid: b90ac02d-5467-4304-99bd-292d6272a014
label: Icons
template: detail.hbs
ms.author: mijacobs
ms.date: 05/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
design-contact: Judysa
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 077967c37f76c8f1d0942f365344de65db13b041
ms.sourcegitcommit: ce45a2bc5ca6794e97d188166172f58590e2e434
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/06/2018
ms.locfileid: "1983575"
---
# <a name="icons-for-uwp-apps"></a>UWP アプリのアイコン

![アイコンのヘッダー画像](images/icons/header-icons.png)

アイコンは、アクション、概念、または製品の簡潔にした視覚表現を提供します。 シンボリック イメージに意味を凝縮することによって、アイコンは言語の壁を乗り越えることができ、非常に価値のあるリソースである画面領域を節約するのに役立ちます。 

アイコンはアプリ内、およびアプリの外部に表示されます。 

:::row::: :::column::: **アプリ内のアイコン**

        ![icons inside the app](images/icons/inside-icons.png)
        Inside your app, you use icons to represent an action, such as copying text or navigating to the settings page.
    :::column-end:::
    :::column:::
        **Icons outside the app**

        ![icons outside the app](images/icons/outside-icons.jpg)
         Outside your app, Windows uses an icon to represent your app in the start menu and in the taskbar. If the user chooses to pin your app to the start menu, your app's start tile can feature your app's icon. Your app's icon appears in the title bar and you can choose to create a splash screen with your app's logo.
    :::column-end:::
:::row-end:::

この記事では、アプリ内のアイコンについて説明します。 アプリの外部のアイコン (アプリ アイコン) の詳細については、「[アプリおよびタイル アイコンに関する記事](/windows/uwp/design/shell/tiles-and-notifications/app-assets)」を参照してください。

## <a name="when-to-use-icons"></a>アイコンを使う状況

アイコンは領域を節約できますが、アイコンをいつ使用する必要があるか説明します。 

:::row::: :::column::: ![適切](images/do.svg) ![標準イメージのアイコン](images/icons/icons-standard.svg)<br>

        Use an icon for actions, like cut, copy, paste, and save, or for navigation items in a navigation menu.
    :::column-end:::
    :::column:::
        ![don't](images/dont.svg)
        ![icons concept image](images/icons/icons-concept.svg)<br>

        Use an icon if one already exists for the concept you want to represent. (To see whether an icon exists, check the Segoe icon list.)
    :::column-end:::
:::row-end:::

:::row::: :::column::: ![適切](images/do.svg) ![ショッピング カート アイコン](images/icons/icon-shopping-cart.svg)<br>

        Use an icon if it's easy for the user to understand what the icon means and it's simple enough to be clear at small sizes.
    :::column-end:::
    :::column:::
        ![dont](images/dont.svg)
        ![icons concept image](images/icons/icon-bad-example.png)<br>

        Don't use an icon if its meaning isn't clear, or if making it clear requires a complex shape.
    :::column-end:::
:::row-end:::



## <a name="using-the-right-type-of-icon"></a>適切な種類のアイコンの使用

アイコンを作成する方法は数多くあります。 Segoe MDL2 アセットなどの記号フォントを使用できます。 独自のベクター ベースのイメージを作成できます。 ビットマップ画像も使用できますが、お勧めしません。 アプリにアイコンを追加するさまざまな方法の概要を次に示します。 

### <a name="use-a-predefined-icon"></a>定義済みのアイコンを使用します。
:::row::: :::column::: マイクロソフトは、Segoe MDL2 アセット フォントの形式で 1000 以上のアイコンを提供します。 フォントからアイコンを取得するのは直感的ではない可能性がありますが、マイクロソフトのフォントの表示テクノロジでは、これらのアイコンが任意のディスプレイ、解像度、サイズではっきりと鮮明に表示されます。 :::column-end::: :::column::: ![事前定義されたアイコンの画像](images/icons/predefined-icon.png) :::column-end::: :::row-end:::

### <a name="use-a-font"></a>フォントを使用します。
:::row::: :::column::: Segoe MDL2 アセット フォントを使用する必要はありません。Wingdings や Webdings など、ユーザーがシステムにインストールしている任意のフォントを使用できます。
:::column-end::: :::column::: ![Wingdings のイメージ](images/icons/wingdings.png) :::column-end::: :::row-end:::

### <a name="use-a-scalable-vector-graphics-svg-file"></a>スケーラブル ベクター グラフィックス (SVG) ファイルを使用します。
:::row::: :::column::: SVG リソースは、任意のサイズや解像度で常に鮮明に表示されるため、アイコンに最適です。 ほとんどの描画アプリケーションは、SVG にエクスポートできます。 :::column-end::: :::column::: ![SVG イメージ](images/icons/icon-scale.gif) :::column-end::: :::row-end:::

### <a name="use-geometry-objects"></a>ジオメトリ オブジェクトを使用します。
:::row::: :::column::: SVG ファイルのように、ジオメトリはベクター ベースのリソースであるため、常に鮮明に表示されます。 ただし、それぞれの点と曲線を個々に指定する必要があるため、ジオメトリの作成は複雑です。 実際にはアプリの実行中にアイコンを変更する必要がある場合のみ最適です (アプリをアニメーション化する場合など)。 手順については、「[ジオメトリのコマンドの移動と描画](../../xaml-platform/move-draw-commands-syntax.md)」を参照してください。 :::column-end::: :::column::: ![ジオメトリ オブジェクトのイメージ](images/icons/geometry-objects.png) :::column-end::: :::row-end:::

### <a name="you-can-also-use-a-bitmap-image-such-as-png-gif-or-jpeg-although-we-dont-recommend-it"></a>お勧めしませんが、PNG、GIF、JPEG などのビットマップ画像を使用することもできます。
:::row::: :::column::: ビットマップ画像は特定のサイズで作成されるため、希望するアイコンの大きさと画面の解像度に応じて拡大縮小する必要があります。 画像を縮小すると、ぼやけて見えることがあります。画像を拡大すると、むらのあるピクセル化された外観になることがあります。 ビットマップ画像を使用する必要がある場合は、JPEG ではなく PNG または GIF を使用することをお勧めします。 :::column-end::: :::column::: ![不適切](images/dont.svg) ![ビットマップ画像](images/icons/bitmap-image.png) :::column-end::: :::row-end:::

## <a name="make-the-icon-do-something"></a>アイコンで何かを行う

アイコンができたら、次の手順として、それをコマンドやナビゲーション操作に関連付けて、何かを行うようにすることです。 これを行う最も良い方法は、アイコンをボタンやコマンド バーに追加することです。 

![コマンド バーのイメージ](images/icons/app-bar-desktop.svg)

## <a name="create-an-icon-button"></a>アイコン ボタンの作成

アイコンは標準的なボタンに配置することができます。 ボタンは幅広い場所で使用できるため、アクション アイコンが表示される場所に関して、柔軟性がやや高くなります。 

ボタンにアイコンを追加する方法は次のようにいくつかあります。

:::row::: :::column span="2"::: <b>手順1</b><br>
        ボタンのフォント ファミリを `Segoe MDL2 Assets` に設定し、そのコンテンツ プロパティを使用するグリフの Unicode 値 に設定します。 :::column-end::: :::column::: ![アイコン ボタンの作成の手順 1](images/icons/create-icon-step-1.svg) :::column-end::: :::row-end:::

```xaml 
<Button FontFamily="Segoe MDL2 Assets" Content="&#xE102;" />
```

:::row::: :::column span="2"::: <b>手順 2</b><br>
        次のアイコンの要素オブジェクトのいずれかを使用します。[BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon)、[FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)、[PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon)、または [SymbolIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbolicon)。 これにより、選択するアイコンの種類が多くなり、必要に応じて、テキストなどのその他の種類のコンテンツとアイコンを組み合わせることができるようになります。 :::column-end::: :::column::: ![Create an icon button step 2](images/icons/icon-text-step-2.svg) :::column-end::: :::row-end:::

```xaml 
<Button>
    <StackPanel>
        <SymbolIcon Symbol="Play" />
        <TextBlock>Play the movie</TextBlock>
    </StackPanel>
</Button>
```

## <a name="create-a-series-of-icons-in-a-command-bar"></a>コマンド バーでの一連のアイコンの作成

:::row::: :::column span::: 切り取り/コピー/貼り付けや、写真編集プログラムの一連の描画コマンドなど、組み合わされる一連のコマンドがある場合は、それらを[コマンド バー](../controls-and-patterns/app-bars.md)にまとめます。 コマンド バーは、1 つ以上のアプリ バーのボタンまたはアプリ バーのトグル ボタンを取得します。それぞれのボタンはアクションを表します。 それぞれのボタンには、表示されるアイコンを制御するために使用する[アイコン](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.appbarbutton#Windows_UI_Xaml_Controls_AppBarButton_Icon) プロパティがあります。 アイコンを指定するには、さまざまな方法があります。 :::column-end::: :::column::: ![アイコンを含むコマンド バーの例](images/icons/create-icon-command-bar.svg) :::column-end::: :::row-end:::

最も簡単な方法は、指定した定義済みのアイコンの一覧を使用することです。"戻る" または "停止" などのアイコン名を指定するだけで、システムが描画します。 

``` xaml
<CommandBar>
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle" Click="AppBarButton_Click" />
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat" Click="AppBarButton_Click"/>
    <AppBarSeparator/>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Forward" Label="Forward" Click="AppBarButton_Click"/>
</CommandBar>

```
アイコン名の完全な一覧については、「[Symbol 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol)」を参照してください。 

コマンド バーにあるボタンにアイコンを指定する方法は他にもあります。

+ [FontIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) - アイコンは指定されたフォント ファミリのグリフに基づきます。
+ [BitmapIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapicon) - アイコンは指定された **URI** を持つビットマップ画像ファイルに基づきます。
+ [PathIcon](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathicon) - アイコンは [Path](/uwp/api/windows.ui.xaml.shapes.path) データに基づきます。

コマンド バーの詳細については、「[コマンド バーの記事](../controls-and-patterns/app-bars.md)」を参照してください。 



## <a name="related-articles"></a>関連記事

* [タイルとアイコン アセットのガイドライン](../shell/tiles-and-notifications/app-assets.md)
