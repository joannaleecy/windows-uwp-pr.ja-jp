---
Description: '[スタート] メニューのアプリ タイル、タスク バー、Microsoft Store、および複数のアプリを表すアプリ アイコン/ロゴを作成する方法。'
title: アプリのアイコンとロゴ
template: detail.hbs
ms.date: 04/17/2018
ms.topic: article
keywords: windows 10, uwp
design-contact: Judysa
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: b755e8d165d58ce4303d9fefe6d051abce6c9765
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622457"
---
# <a name="app-icons-and-logos"></a>アプリのアイコンとロゴ 

すべてのアプリは、それを表す、アイコンやロゴを備え、Windows シェルで複数の場所にそのアイコンが表示されます。 

:::row:::
    :::column:::
        * アプリのウィンドウのタイトル バー
        * [スタート] メニューで、アプリの一覧
        * タスク バーと タスク マネージャー
        * アプリのタイル
        * アプリのスプラッシュ スクリーン
        * Microsoft Store で
    :::column-end:::
    :::column:::
        ![windows 10 start and tiles](images/assetguidance01.jpg)
    :::column-end:::
:::row-end:::

この記事には、アプリのアイコンの作成の基礎に必要となる Visual Studio をそれらを管理し、それらを手動で管理する方法を使用する方法。
 
(この記事はアイコンが、アプリ自体を表す一般的なアイコンのガイダンスについては、具体的には、[アイコン](icons.md)記事を参照してください。)。

## <a name="icon-types-locations-and-scale-factors"></a>アイコンの種類、場所、およびスケール ファクター

既定では、Visual Studio は、資産のサブディレクトリに、アイコンのアセットを格納します。 アイコン、表示される場所などと呼ばれるさまざまな種類の一覧を示します。 

| アイコン名 | 表示されます。 | 資産ファイルの名前 |
| ---      | ---        | --- |
| 小さなタイル | スタート メニュー |  SmallTile.png  |
| 中規模のタイル |[スタート] メニューには、Microsoft Store の一覧\*  |  Square150x150Logo.png |
| ワイド タイル  | スタート メニュー   | Wide310x150Logo.png |
| 大きいタイル   | [スタート] メニューには、Microsoft Store の一覧\* |  LargeTile.png  |
| アプリ アイコン | [スタート] メニューのタスク バー、タスク マネージャーでのアプリの一覧 | Square44x44Logo.png |
| スプラッシュ画面 | アプリのスプラッシュ スクリーン | SplashScreen.png  |
| バッジ ロゴ | アプリのタイル | BadgeLogo.png  |
| パッケージ ロゴ/ストア ロゴ | アプリのインストーラー、パートナー センターで、ストアでは、ストア内の「レビューを書く」オプションで「レポート、アプリ」のオプション | StoreLogo.png  |

\* 使用を選択しない限り[表示は、ストア内のイメージのみアップロード](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store)します。 

これらのアイコンがすべての画面に鮮明させるには、別のディスプレイのスケール ファクターの同じアイコンの複数のバージョンを作成できます。 

スケール ファクターは、テキストなどの UI 要素のサイズを決定します。 スケールは、100% ~ 400% の範囲を考慮します。 大きな値は、高解像度ディスプレイに表示しやすくより大きなの UI 要素を作成します。 

:::row:::
    :::column:::
        Windows automatically sets the scale factor for each display based on its DPI (dots-per-inch) and the viewing distance of the device. 

        (Users can override the default value by going to the **Settings &gt; Display &gt; Scale and layout** page.)
    :::column-end:::
    :::column:::
        ![](images/icons/display-settings-screen.png)
    :::column-end:::
:::row-end:::  


アプリ アイコンのアセットはビットマップ ビットマップは適切にスケーリングしないため、各スケール ファクターのバージョンを各アイコンの資産を提供するをお勧めします。100%、125%、150%、200%、400% です。 多くのアイコンです。 さいわい、Visual Studio は、簡単に生成し、これらのアイコンの更新ツールを提供します。 

## <a name="microsoft-store-listing-image"></a>Microsoft Store の一覧の画像

「の指定方法を自分のアプリの一覧については、イメージ、Microsoft Store ででしょうか。」

既定では、使用して、パッケージからのイメージの一部、ストア内のこのページの上部にある表に示す (とその他の[送信処理中に指定したイメージ](https://docs.microsoft.com/en-us/windows/uwp/publish/app-screenshots-and-images))。 ただし、ストアが (Xbox を含む)、Windows 10 でのお客様に、一覧を表示するときに、アプリのパッケージでロゴのイメージを使用するを防ぐを代わりに、ストアにアップロードするイメージのみを使用して、オプションがあります。 これにより、ストアのさまざまな画面でアプリがどのように表示されるかをさらに細かく制御できます。 (注ことのある製品は、以前の OS バージョンをサポートする場合顧客もについて、パッケージからのイメージ場合でも、このオプションを使用する)これを行う、**ロゴを格納**のセクション、**ストア一覧**送信処理の手順。

![アプリの提出プロセス中にストア ロゴを指定します。](images/app-icons/storelogodisplay.png)

このボックスをオンにすると、新しいセクションと呼ばれる**ストア イメージを表示**が表示されます。 ここでは、アプリのパッケージからロゴのイメージの代わりに、ストアが使用する 3 つのイメージ サイズをアップロードできます。300 x 300、150 x 150、および 71 x 71 ピクセルです。 すべての 3 つのサイズを提供することをお勧めします。 300 x 300 サイズのみが必要です。

詳細については、[表示は、ストア ロゴのイメージのみアップロード](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store)を参照してください。

<!-- ### Fallback images for the Store

The simplest way to control the Store listing image is to specify it during the app submission process. If you don't provide these images during the app submission process, the Store will use a tile image:

1. Large tile
2. Medium tile

If these images aren't provided, the Store will search all matching images of the same image type with a square aspect ratio, preferable with a height greated than the scaled requested height (scaled height is the machine's resolution scale factor * display height). If none of the images meet this criteria, the Store will ignore the scale factor and select an image based on height.  -->

<!-- You can provide screenshots, logos, and other art assets (such as trailers and promotional images to include in your app's Microsoft Store listing. Some of these are required, and some are optional (although some of the optional images are important to include for the best Store display).

The Store may also use your app's tile and other images that you include in your app's package. 

For more information, see [App screenshots, images, and trailers in the Microsoft Store](/windows/uwp/publish/app-screenshots-and-images). -->


## <a name="managing-app-icons-with-the-visual-studio-manifest-designer"></a>Visual Studio のマニフェスト デザイナーでのアプリ アイコンの管理

Visual Studio と呼ばれる、アプリ アイコンの管理に非常に便利なツールを提供します、**マニフェスト デザイナー**します。 

> まだ Visual Studio 2017 を持っていない場合、いくつかのバージョンがあるなどの無料バージョンである (Visual Studio 2017 Community Edition) と他のバージョンは、無料試用版を提供します。 ここでダウンロードすることができます。 [https://developer.microsoft.com/windows/downloads](https://developer.microsoft.com/windows/downloads)


マニフェスト デザイナーを起動するには。
<!-- 1. Use Visual Studio to open a UWP project.
2. In the **Solution Explorer**, double-click the package.appmanifest file. 

    ![The Visual Studio 2017 Solution Explorer](images/icons/vs-solution-explorer.png)

    Visual Studio displays the manifest designer.

    ![The Visual Studio 2017 manifest designer](images/icons/vs-manfiest-designer.png)
3. Click the **Visual Assets** tab.

    ![The Visual Assets tab](images/icons/vs-manfiest-designer-visual-assets.png) -->


:::row:::
    :::column:::
        1. Visual Studio を使用して、UWP プロジェクトを開きます。
    :::column-end:::
    :::column:::
        
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        2. **ソリューション エクスプ ローラー**、Package.appmxanifest ファイルをダブルクリックします。
    :::column-end:::
    :::column:::
        ![The Visual Studio 2017 Manifest Designer](images/icons/vs-solution-explorer.png)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
            Visual Studio displays the Manifest Designer.
    :::column-end:::
    :::column:::
            ![The Visual Assets tab](images/icons/vs-manfiest-designer.png)
    :::column-end:::
:::row-end:::    
:::row:::
    :::column:::
        3. をクリックして、**のビジュアル アセット**タブ。
    :::column-end:::
    :::column:::
        ![The Visual Assets tab](images/icons/vs-manfiest-designer-visual-assets.png)
    :::column-end:::
:::row-end:::        

## <a name="generating-all-assets-at-once"></a>すべての資産を一度に作成します。

内の最初のメニュー項目、**のビジュアル アセット** タブで、**すべてのビジュアル資産**は正確にその名前のとおり: ボタンを押すと、アプリが必要なすべてのビジュアル資産が生成されます。

![Visual Studio ですべてのビジュアル資産を生成します。](images/app-icons/all-visual-assets.png)

1 つのイメージを指定が行う必要があるすべてと、Visual Studio は小さなタイル、中」のタイル、大、ワイド タイル、大規模なタイル、アプリ アイコン、スプラッシュ スクリーンを生成し、すべてのスケール ファクターのロゴの資産をパッケージ化します。

すべての資産を一度に生成。
1. をクリックして、 **.** 横に、**ソース**フィールドし、使用するイメージを選択します。 ビットマップ イメージを使用している場合は、シャープな結果を取得することが 400 ピクセルの 400 以上を確認します。 ベクター ベースのイメージが最適です。Visual Studio を使用して、AI (Adobe Illustrator) や PDF ファイルを使用できます。 
2. (省略可能)**表示設定**セクションで、これらのオプションを構成します。

    a.   **短い名前**:アプリの短い名前を指定します。

    b.   **名前を表示する**:短い名前を中、または大規模なタイルに表示するかどうかを示します。 

    c. **タイルのバック グラウンド**:16 進数の値またはタイルの背景色を色の名前を指定します。 たとえば、`#464646` と記述します。 既定値は、`transparent` です。

    d. **スプラッシュ画面の背景**:スプラッシュ画面の背景色の 16 進値または色の名前を指定します。 

3. クリックして**生成**します。 

Visual Studio は、イメージ ファイルを生成し、プロジェクトに追加します。 資産を変更する場合は、プロセスを繰り返します。 

アイコンがスケーリングされた資産は、このファイルの名前付け規則に従います。

*filename*-scale-*scale factor*.png

以下に例を示します。

Square150x150Logo-scale-100.png, Square150x150Logo-scale-200.png, Square150x150Logo-scale-400.png

Visual Studio が既定でバッジ ロゴを生成しないことに注意してください。 バッジ ロゴは一意であり、その他のアプリ アイコンが一致しないためにです。 詳細については、、 [UWP アプリのアーティクルの通知のバッジ](/windows/uwp/design/shell/tiles-and-notifications/badges)を参照してください。 


## <a name="more-about-app-icon-assets"></a>アプリ アイコンの資産の詳細情報
Visual Studio プロジェクトで必要なすべてのアプリ アイコンのアセットが生成されますが、その他のアプリの資産から相違を理解することによってそれらをカスタマイズしたい場合。 

アプリ アイコンの資産がさまざまな場所に表示されます。 Windows タスク バー、タスクの表示、ALT + TAB キー、およびスタート タイルの右上隅にあります。 いくつか追加のサイズとオプションがないその他の資産を plating がアプリ アイコンの資産は、非常に多くの場所に表示される、ため: 資産の「ターゲット サイズ」と「プレートなし」の資産。 

### <a name="target-size-app-icon-assets"></a>ターゲット サイズのアプリ アイコンの資産
標準的なスケール要素サイズ ("Square44x44Logo.scale 400.png") だけでなくもをお勧め「ターゲット サイズ」の資産を作成します。 400 などの特定のスケール ファクターではなく、16 ピクセルなどの特定のサイズを対象にできるので、これらの資産ターゲットのサイズを呼んでいます。 ターゲット サイズの資産は、スケーリングの頭打ちシステムを使用していないサーフェスのことです。

* スタート画面のジャンプ リスト (デスクトップ)
* スタート画面のタイルの下隅 (デスクトップ)
* ショートカット (デスクトップ)
* コントロール パネル (デスクトップ)

ターゲット サイズの資産の一覧を次に示します。


| アセットのサイズ | ファイル名の例                  |
|------------|------------------------------------|
| 16 x 16\*    | Square44x44Logo.targetsize-16.png  |
| 24 x 24\*    | Square44x44Logo.targetsize-24.png  |
| 32x32\*    | Square44x44Logo.targetsize-32.png  |
| 48 x 48\*    | Square44x44Logo.targetsize-48.png  |
| 256x256\*  | Square44x44Logo.targetsize-256.png |
| 20 x 20      | Square44x44Logo.targetsize-20.png  |
| 30 x 30      | Square44x44Logo.targetsize-30.png  |
| 36 x 36      | Square44x44Logo.targetsize-36.png  |
| 40 x 40      | Square44x44Logo.targetsize-40.png  |
| 60 x 60      | Square44x44Logo.targetsize-60.png  |
| 64 x 64      | Square44x44Logo.targetsize-64.png  |
| 72 x 72      | Square44x44Logo.targetsize-72.png  |
| 80 x 80      | Square44x44Logo.targetsize-80.png  |
| 96 x 96      | Square44x44Logo.targetsize-96.png  |

\* 少なくとも、これらのサイズを提供することをお勧めします。 

これらのアセットにパディングを追加する必要はありません。パディングは、必要に応じて Windows によって追加されます。 これらのアセットは、16 ピクセルの最小面積を占めている必要があります。 

Windows タスク バーのアイコンに表示される、このようなアセットの例を以下に示します。

![Windows タスク バーのアセット](images/assetguidance21.png)

### <a name="unplated-assets"></a>プレートなしの資産
既定では、Windows は、既定で色付き backplate 上にターゲット ベースの資産を使用します。 する場合は、ターゲットのプレートなし資産を行うことができます。 資産が透明な背景に表示されます「プレートなし」を意味します。 これらの資産は、さまざまな背景の色で表示されることに留意してください。 

![プレートなしのアセットとプレート付きのアセット](images/assetguidance22.png)

プレートなしのアプリ アイコンのアセットを使用する画面を次に示します。
* タスク バーとタスク バー サムネイル (デスクトップ)
* タスク バーのジャンプ リスト
* タスク ビュー
* Alt + Tab キー


### <a name="target-and-unplated-sizing"></a>ターゲットおよびプレートなしのサイズ変更

100% スケールで、ターゲット ベースの資産のサイズの推奨事項を次に示します。

![100% の倍率でのターゲット ベースのアセットのサイズ調整](images/assetguidance23.png)


## <a name="more-about-splash-screen-assets"></a>スプラッシュ画面の資産の詳細情報
スプラッシュ スクリーンの詳細については、、 [UWP スプラッシュ画面記事](/windows/uwp/launch-resume/splash-screens)を参照してください。

## <a name="more-about-badge-logo-assets"></a>バッジ ロゴの資産の詳細情報

なぜバッジ ロゴが既定で生成されない理由がある必要があるすべての資産を生成する資産ジェネレーターを使用する場合: その他のアプリの資産から非常に異なる場合します。 バッジ ロゴは、通知とアプリのタイルに表示される状態のイメージです。 

詳細については、、 [UWP アプリのアーティクルの通知のバッジ](/windows/uwp/design/shell/tiles-and-notifications/badges)を参照してください。


## <a name="customizing-asset-padding"></a>資産の余白をカスタマイズします。

既定では、Visual Studio 資産ジェネレーターには、どのようなイメージに推奨される埋め込みが適用されます。 イメージの余白では、既にまたは、フルブリード イメージ タイルの末尾に拡張する場合場合、オフにできますこの機能をオフにして、**パディングをお勧めします。 適用**チェック ボックスをオンします。 

### <a name="tile-padding-recommendations"></a>タイルの埋め込みに関する推奨事項
独自の埋め込みを指定する場合は、タイルの推奨事項を示します。 

4 つのタイル サイズがある: small (71 x 71)、medium (150 x 150)、ワイド (150 x 310)、大規模な (310 x 310)。 

各タイル アセットは、配置されるタイルと同じサイズです。

![タイルが表示されたフルブリード](images/app-icons/tile-assets1.png)

タイルのエッジに拡張する、アイコンをしたくない場合は、パディングの作成に、資産の透明なピクセルを使用できます。 

![タイルとバック プレート](images/assetguidance05.png)

小さいタイルでは、アイコンの幅と高さをタイル サイズの 66% に制限します。

![小さいタイルのサイズの比率](images/assetguidance09.png)

普通サイズのタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。 これによって、ブランド バー内の要素と重ならないようにします。

![普通サイズのタイルのサイズの比率](images/assetguidance10.png)

ワイド タイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。 これによって、ブランド バー内の要素と重ならないようにします。

![ワイド タイルのサイズの比率](images/assetguidance11.png)

大きいタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。

![大きいタイルのサイズの比率](images/assetguidance12.png)

水平方向または垂直方向にデザインされたアイコンがある一方で、ターゲット サイズの正方形に収まらない、より複雑な形状のアイコンもあります。 中央に配置されるアイコンの一方の辺に重みを付けることができます。 この場合、アイコンの視覚的な重みが正方形に収まるアイコンと同じであれば、アイコンの一部が推奨される面積の外側にはみ出していてもかまいません。

![中央に配置された 3 つのアイコン](images/assetguidance13.png)

フルブリード アセットでは、要素が余白およびタイルの端の内側に接するように考慮します。 タイルの高さまたは幅の 16% 以上の余白を維持します。 この割合は、最小タイル サイズでの余白の幅の 2 倍を表しています。

![余白のあるフルブリード タイル](images/assetguidance14.png)

次の例では、余白が狭すぎます。

![余白が小さすぎるフルブリード タイル](images/assetguidance15.png)









