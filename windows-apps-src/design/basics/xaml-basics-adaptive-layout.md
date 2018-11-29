---
title: アダプティブ レイアウトの作成のチュートリアル
description: この記事では、XAML のアダプティブ レイアウトの基本について説明します。
keywords: XAML、UWP、概要
ms.date: 08/30/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7b444a11ab032034976d2f1b269bd10a89bf339e
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8197957"
---
# <a name="tutorial-create-adaptive-layouts"></a>チュートリアル: アダプティブ レイアウトの作成

このチュートリアルでは、XAML のアダプティブなカスタム レイアウト機能の基本的な使い方について説明します。このレイアウト機能を使用すると、どのようなデバイスでもそのデバイス用に最適化されたアプリを作成できます。 新しい DataTemplate を作成する方法、ウィンドウ スナップ位置を追加する方法、VisualStateManager 要素および AdaptiveTrigger 要素を使用してアプリのレイアウトをカスタマイズする方法を学習します。 ここでは、これらのツールを使用して、より小さなデバイス画面向けにイメージ編集プログラムを最適化します。 

作業するイメージ編集プログラムには、次の 2 つのページ/画面があります。

**メイン ページ:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。

![MainPage](../basics/images/xaml-basics/mainpage.png)

**詳細ページ:** 選択された単一の写真が表示されます。 ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。

![DetailPage](../basics/images/xaml-basics/detailpage.png)

## <a name="prerequisites"></a>前提条件

* Visual Studio 2017: [Visual Studio 2017 Community (無料) のダウンロード](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15&campaign=WinDevCenter&ocid=wdgcx-windevcenter-community-download) 
* Windows 10 SDK (10.0.15063.468 以降): [最新の Windows SDK (無料) のダウンロード](https://developer.microsoft.com/windows/downloads/windows-10-sdk)
* Windows Mobile エミュレーター: [Windows 10 Mobile エミュレーター (無料) のダウンロード](https://developer.microsoft.com/en-us/windows/downloads/sdk-archive)

## <a name="part-0-get-the-starter-code-from-github"></a>パート 0: github からスタート コードを入手する

このチュートリアルでは、PhotoLab サンプルの簡易バージョンから開始します。 

1. 移動[https://github.com/Microsoft/Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab)します。 これで、サンプルの GitHub ページが表示されます。 
2. 次に、サンプルを複製またはダウンロードする必要があります。 **[Clone or download]** (複製またはダウンロード) ボタンをクリックします。 サブメニューが表示されます。
    <figure>
        <img src="../basics/images/xaml-basics/clone-repo.png" alt="The Clone or download menu on GitHub">
        <figcaption>PhotoLab サンプルの GitHub ページの <b>[Clone or download]</b> (複製またはダウンロード) メニュー。</figcaption>
    </figure>

    **GitHub に慣れていない場合:**
    
    a.  **[Download ZIP]** (ZIP をダウンロード) をクリックし、ファイルをローカルに保存します。 これで、必要なすべてのプロジェクト ファイルを含む .zip ファイルがダウンロードされます。
    b.  ファイルを展開します。 エクスプローラーを使用して、ダウンロードした .zip ファイルに移動し、ファイルを右クリックして **[すべて展開]** を選択します。c. サンプルのローカル コピーに移動し、`Windows-appsample-photo-lab-master\xaml-basics-starting-points\adaptive-layout` ディレクトリに移動します。    

    **GitHub に慣れている場合:**

    a.  リポジトリのマスター ブランチをローカルに複製します。
    b.  `Windows-appsample-photo-lab\xaml-basics-starting-points\adaptive-layout` ディレクトリに移動します。

3. `Photolab.sln` をクリックしてプロジェクトを開きます。

## <a name="part-1-run-the-mobile-emulator"></a>手順 1: モバイル エミュレーターを実行する

Visual Studio ツールバーで、ソリューション プラットフォームを必ず x86 または x64 (ARM は不可) に設定してから、ターゲット デバイスをローカル コンピューターから変更して、インストール済みのいずれかのモバイル エミュレーター (Mobile Emulator 10.0.15063 WVGA 5 inch 1GB など) に設定します。 **F5** を押して、選択したモバイル エミュレーターで Photo Gallery アプリを実行します。

アプリが開始すると、動作しているものの、このように小さなビューポートでは見栄えが良くないことに気付きます。 限られた画面領域への対応として、可変の Grid 要素により表示する列の数が減っていますが、レイアウトはこのように小さなビューポートに適合せず、見づらい状態です。

![モバイル レイアウト: 変更後](../basics/images/xaml-basics/adaptive-layout-mobile-before.png)

## <a name="part-2-build-a-tailored-mobile-layout"></a>パート 2: カスタムのモバイル レイアウトを作成する
より小さなデバイスでもこのアプリの見栄えを良くするには、モバイル デバイスが検出された場合にのみ使用される、別のスタイルを XAML ページに作成します。

### <a name="create-a-new-datatemplate"></a>新しい DataTemplate を作成する
イメージの新しい DataTemplate を作成することで、アプリケーションのギャラリー ビューをカスタマイズしましょう。 ソリューション エクスプ ローラーから MainPage.xaml を開き、**Page.Resources** タグ内に次のコードを追加します。

```XAML
<DataTemplate x:Key="ImageGridView_MobileItemTemplate"
              x:DataType="local:ImageFileInfo">

    <!-- Create image grid -->
    <Grid Height="{Binding ItemSize, ElementName=page}"
          Width="{Binding ItemSize, ElementName=page}">
        
        <!-- Place image in grid, stretching it to fill the pane-->
        <Image x:Name="ItemImage"
               Source="{x:Bind ImagePreview}"
               Stretch="UniformToFill">
        </Image>

    </Grid>
</DataTemplate>
```

このギャラリー テンプレートでは、イメージの境界線を排除し、各サムネイルの下にあるイメージのメタデータ (ファイル名、評価など) を非表示にすることによって、画面領域を節約しています。 代わりに、各サムネイルは単純な正方形で表示します。

### <a name="add-metadata-to-a-tooltip"></a>メタデータをヒントを追加する
ユーザーが各イメージのメタデータにアクセスできるように、各イメージ項目にヒントを追加します。 先ほど作成した DataTemplate の **Image** タグ内に、次のコードを追加します。

```XAML
<Image ...>

    <!-- Add a tooltip to the image that displays metadata -->
    <ToolTipService.ToolTip>
        <ToolTip x:Name="tooltip">

            <!-- Arrange tooltip elements vertically -->
            <StackPanel Orientation="Vertical"
                        Grid.Row="1">

                <!-- Image title -->
                <TextBlock Text="{x:Bind ImageTitle, Mode=OneWay}"
                           HorizontalAlignment="Center"
                           Style="{StaticResource SubtitleTextBlockStyle}" />

                <!-- Arrange elements horizontally -->
                <StackPanel Orientation="Horizontal"
                            HorizontalAlignment="Center">

                    <!-- Image file type -->
                    <TextBlock Text="{x:Bind ImageFileType}"
                               HorizontalAlignment="Center"
                               Style="{StaticResource CaptionTextBlockStyle}" />

                    <!-- Image dimensions -->
                    <TextBlock Text="{x:Bind ImageDimensions}"
                               HorizontalAlignment="Center"
                               Style="{StaticResource CaptionTextBlockStyle}"
                               Margin="8,0,0,0" />
                </StackPanel>
            </StackPanel>
        </ToolTip>
    </ToolTipService.ToolTip>
</Image>
```

これにより、サムネイルにマウスを重ねると (または、タッチ スクリーンを長押しすると)、イメージのタイトル、ファイルの種類、サイズが表示されるようになります。

### <a name="add-a-visualstatemanager-and-statetrigger"></a>VisualStateManager と StateTrigger を追加する

これで、新しいデータ レイアウトが作成されましたが、今のところ、どのようなときに既定のスタイルではなくこのレイアウトを使うのか、アプリに知らせる方法がありません。 これを解決するには、**VisualStateManager** を追加する必要があります。 ページのルート要素である **RelativePanel** に次のコードを追加します。

```XAML
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>

        <!-- Add a new VisualState for mobile devices -->
        <VisualState x:Key="Mobile">

            <!-- Trigger visualstate when a mobile device is detected -->
            <VisualState.StateTriggers>
                <local:MobileScreenTrigger InteractionMode="Touch" />
            </VisualState.StateTriggers>

        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

これにより、新しい **VisualState** および **StateTrigger** が追加されます。これらは、アプリがモバイル デバイス上で実行中であると検出されるとトリガーされます (この動作のロジックは、PhotoLab ディレクトリにある MobileScreenTrigger.cs で確認できます)。 **StateTrigger** が起動されると、アプリは、この **VisualState** に割り当てられているレイアウト属性を使用します。

### <a name="add-visualstate-setters"></a>VisualState の setter を追加する
次に、**VisualState** の setter を使用して、状態がトリガーされたときに適用する属性を **VisualStateManager** に伝えます。 各 setter は、特定の XAML 要素の 1 つのプロパティを対象とし、指定された値に設定します。 先ほど作成したモバイルの **VisualState** (**VisualState.StateTriggers** 要素の下) にこのコードを追加します。  

```XAML
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>

        <VisualState x:Key="Mobile">
            ...

            <!-- Add setters for mobile visualstate -->
            <VisualState.Setters>

                <!-- Move GridView about the command bar -->
                <Setter Target="ImageGridView.(RelativePanel.Above)"
                        Value="MainCommandBar" />

                <!-- Switch to mobile layout -->
                <Setter Target="ImageGridView.ItemTemplate"
                        Value="{StaticResource ImageGridView_MobileItemTemplate}" />

                <!-- Switch to mobile container styles -->
                <Setter Target="ImageGridView.ItemContainerStyle"
                        Value="{StaticResource ImageGridView_MobileItemContainerStyle}" />

                <!-- Move command bar to bottom of the screen -->
                <Setter Target="MainCommandBar.(RelativePanel.AlignBottomWithPanel)"
                        Value="True" />
                <Setter Target="MainCommandBar.(RelativePanel.AlignLeftWithPanel)"
                        Value="True" />
                <Setter Target="MainCommandBar.(RelativePanel.AlignRightWithPanel)"
                        Value="True" />

                <!-- Adjust the zoom slider to fit mobile screens -->
                <Setter Target="ZoomSlider.Minimum"
                        Value="80" />
                <Setter Target="ZoomSlider.Maximum"
                        Value="180" />
                <Setter Target="ZoomSlider.TickFrequency"
                        Value="20" />
                <Setter Target="ZoomSlider.Value"
                        Value="100" />
            </VisualState.Setters>

        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>

```

これらの setter は、イメージ ギャラリーの **ItemTemplate** を、先ほど作成した新しい **DataTemplate** に設定します。さらに、携帯電話の画面で親指によってアクセスしやすくなるように、コマンド バーとズーム スライダーを画面の下端に揃えます。

### <a name="run-the-app"></a>アプリを実行する
では、モバイル エミュレーターを使用してアプリを実行してみましょう。 新しいレイアウトは正しく表示されますか?  次のように、グリッド状に並んだ小さなサムネイルが表示されるはずです。 まだ以前のレイアウトが表示される場合は、**VisualStateManager** コードにスペルの間違いがないか確認してください。

![モバイル レイアウト: 変更後](../basics/images/xaml-basics/adaptive-layout-mobile-after.png)

## <a name="part-3-adapt-to-multiple-window-sizes-on-a-single-device"></a>パート 3: 単一デバイスのさまざまなウィンドウ サイズに対応する
新しいカスタム レイアウトを作成すると、モバイル デバイスのレスポンシブ デザインに関する問題が解決しますが、デスクトップとタブレットの場合はどうでしょうか?  アプリは、全画面では見栄え良く表示されても、ユーザーがウィンドウ サイズを縮小すると、インターフェイスが使いづらくなることがあります。 エンド ユーザーが常に適切な外観および操作性を得ることができるように、**VisualStateManager** を使用して、単一デバイスのさまざまなウィンドウサイズに対応することができます。

![小さなウィンドウ: 変更前](../basics/images/xaml-basics/adaptive-layout-small-before.png)

### <a name="add-window-snap-points"></a>ウィンドウ スナップ位置を追加する
最初のステップは、さまざまな **VisualStates** がトリガーされる "スナップ位置" を定義することです。 ソリューション エクスプ ローラーから App.xaml を開き、2 つの **Application** タグの間に次のコードを追加します。

```XAML
<Application.Resources>
    <!--  window width adaptive snap points  -->
    <x:Double x:Key="MinWindowSnapPoint">0</x:Double>
    <x:Double x:Key="MediumWindowSnapPoint">641</x:Double>
    <x:Double x:Key="LargeWindowSnapPoint">1008</x:Double>
</Application.Resources>
```

これにより 3 つのスナップ位置が追加され、3 種類のウィンドウ サイズ範囲に対する新しい **VisualStates** を作成できます。
+ 小 (0 ～ 640 ピクセル幅)
+ 中 (641 ～ 1007 ピクセル幅)
+ 大 (1008 ピクセル幅以上)

### <a name="create-new-visualstates-and-statetriggers"></a>新しい VisualStates と StateTriggers を作成する
次に、各スナップ位置に対応する **VisualStates** および **StateTriggers** を作成します。 MainPage.xaml.cpp の **VisualStateManager** (パート 2 で作成) に次のコードを追加します。

```XAML
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
    ...

        <!-- Large window VisualState -->
        <VisualState x:Key="LargeWindow">

            <!-- Large window trigger -->
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="{StaticResource LargeWindowSnapPoint}"/>
            </VisualState.StateTriggers>
     
        </VisualState>

        <!-- Medium window VisualState -->
        <VisualState x:Key="MediumWindow">

            <!-- Medium window trigger -->
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="{StaticResource MediumWindowSnapPoint}"/>
            </VisualState.StateTriggers>
        
        </VisualState>

        <!-- Small window VisualState -->
        <VisualState x:Key="SmallWindow">

            <!-- Small window trigger -->
            <VisualState.StateTriggers >
                <AdaptiveTrigger MinWindowWidth="{StaticResource MinWindowSnapPoint}"/>
            </VisualState.StateTriggers>

        </VisualState>

    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

### <a name="add-setters"></a>setter を追加する
最後に、これらの setter を **SmallWindow** の状態に追加します。

```XAML

<VisualState x:Key="SmallWindow">
    ...

    <!-- Small window setters -->
    <VisualState.Setters>

        <!-- Apply mobile itemtemplate and styles -->
        <Setter Target="ImageGridView.ItemTemplate"
                Value="{StaticResource ImageGridView_MobileItemTemplate}" />
        <Setter Target="ImageGridView.ItemContainerStyle"
                Value="{StaticResource ImageGridView_MobileItemContainerStyle}" />

        <!-- Adjust the zoom slider to fit small windows-->
        <Setter Target="ZoomSlider.Minimum"
                Value="80" />
        <Setter Target="ZoomSlider.Maximum"
                Value="180" />
        <Setter Target="ZoomSlider.TickFrequency"
                Value="20" />
        <Setter Target="ZoomSlider.Value"
                Value="100" />
    </VisualState.Setters>

</VisualState>

```

これらの setter では、ビューポートが 641 ピクセル幅を下回る場合に、モバイルの **DataTemplate** およびスタイルがデスクトップ アプリに適用されます。 また、小さい画面に合わせて、ズーム スライダーの調整も行われます。

### <a name="run-the-app"></a>アプリを実行する

Visual Studio ツール バーで、ターゲット デバイスを **Local Machine** に設定し、アプリを実行します。 アプリが読み込まれたら、ウィンドウのサイズを変更してみてください。 ウィンドウを小さなサイズに縮小すると、パート 2 で作成したモバイル レイアウトにアプリが切り替わることがわかります。

![小さなウィンドウ: 変更後](../basics/images/xaml-basics/adaptive-layout-small-after.png)

## <a name="going-further"></a>追加情報

これで、この演習は終わりです。自身でさらに試すために必要な、レイアウトに関する知識を身につけることができました。 以前に追加したモバイル専用のヒントに、評価コントロールを追加してみてください。 または、さらに大きな課題として、大きな画面サイズ用にレイアウトを最適化してみてください (テレビ画面や Surface Studio を想定)。

行き詰まった場合は、「[XAML を使ったページ レイアウトの定義](../layout/layouts-with-xaml.md)」の以下のセクションで、詳しいガイダンスを参照できます。

+ [表示状態と状態トリガー](https://docs.microsoft.com/en-us/windows/uwp/layout/layouts-with-xaml#visual-states-and-state-triggers)
+ [カスタマイズされたレイアウト](https://docs.microsoft.com/en-us/windows/uwp/layout/layouts-with-xaml#tailored-layouts)

当初の写真編集アプリの作成方法を学習するには、XAML の[ユーザー インターフェイス](../basics/xaml-basics-ui.md)と[データ バインディング](../../data-binding/xaml-basics-data-binding.md)に関するチュートリアルをご覧ください。

## <a name="get-the-final-version-of-the-photolab-sample"></a>PhotoLab サンプルの最終バージョンを入手する

このチュートリアルで完全な写真編集アプリは作成されません。必ず[最終バージョン](https://github.com/Microsoft/Windows-appsample-photo-lab)でカスタム アニメーションやスマートフォン サポートなど、他の機能を確認してください。