---
author: jwmsft
title: ユーザー インターフェイスの作成のチュートリアル
description: この記事では、XAML のユーザー インターフェイス作成の基本について説明します。
keywords: XAML, UWP, 概要
ms.author: jimwalk
ms.date: 08/30/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5d54df07cd5f2ccc32098b17fd7c656900cba978
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6023654"
---
# <a name="tutorial-create-a-user-interface"></a>チュートリアル: ユーザー インターフェイスの作成

このチュートリアルでは、イメージ編集プログラムの基本的な UI を作成する方法について説明します。 

+ Visual Studio の XAML ツール (XAML デザイナー、ツールボックス、XAML エディター、[プロパティ] パネル、ドキュメント アウトラインなど) を使用してコントロールやコンテンツを UI に追加する
+ 最も一般的な XAML レイアウト パネル (RelativePanel、Grid、StackPanel など) を利用する

イメージ編集プログラムには、次の 2 つのページ/画面があります。

**メイン ページ:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。

![MainPage](images/xaml-basics/mainpage.png)

**詳細ページ:** 選択された単一の写真が表示されます。 ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。

![DetailPage](images/xaml-basics/detailpage.png)


## <a name="prerequisites"></a>前提条件

* Visual Studio 2017: [Visual Studio 2017 Community (無料) のダウンロード](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15&campaign=WinDevCenter&ocid=wdgcx-windevcenter-community-download) 
* Windows 10 SDK (10.0.15063.468 以降): [最新の Windows SDK (無料) のダウンロード](https://developer.microsoft.com/windows/downloads/windows-10-sdk)

## <a name="part-0-get-the-starter-code-from-github"></a>パート 0: github からスタート コードを入手する

このチュートリアルでは、PhotoLab サンプルの簡易バージョンから開始します。 

1. 移動[https://github.com/Microsoft/Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab)します。 これで、サンプルの GitHub ページが表示されます。 
2. 次に、サンプルを複製またはダウンロードする必要があります。 **[Clone or download]** (複製またはダウンロード) ボタンをクリックします。 サブメニューが表示されます。
    <figure>
        <img src="images/xaml-basics/clone-repo.png" alt="The Clone or download menu on GitHub">
        <figcaption>PhotoLab サンプルの GitHub ページの <b>[Clone or download]</b> (複製またはダウンロード) メニュー。</figcaption>
    </figure>

    **GitHub に慣れていない場合:**
    
    a.  **[Download ZIP]** (ZIP をダウンロード) をクリックし、ファイルをローカルに保存します。 これで、必要なすべてのプロジェクト ファイルを含む .zip ファイルがダウンロードされます。
    b.  ファイルを展開します。 エクスプローラーを使用して、ダウンロードした .zip ファイルに移動し、ファイルを右クリックして **[すべて展開]** を選択します。c. サンプルのローカル コピーに移動し、`Windows-appsample-photo-lab-master\xaml-basics-starting-points\user-interface` ディレクトリに移動します。    

    **GitHub に慣れている場合:**

    a.  リポジトリのマスター ブランチをローカルに複製します。
    b.  `Windows-appsample-photo-lab\xaml-basics-starting-points\user-interface` ディレクトリに移動します。

3. `Photolab.sln` をクリックしてプロジェクトを開きます。

## <a name="part-1-add-a-textblock-using-xaml-designer"></a>パート 1: XAML デザイナーを使用して TextBlock を追加する

Visual Studio には、XAML UI を簡単に作成するためのツールがいくつか用意されています。 XAML デザイナーでは、コントロールをデザイン サーフェイスにドラッグして、アプリを実行する前に外観を確認できます。 [プロパティ] パネルでは、デザイナーでアクティブになっているコントロールのすべてのプロパティを表示および設定できます。 ドキュメント アウトラインには、UI の XAML ビジュアル ツリーの親子構造が表示されます。 XAML エディターでは、XAML マークアップを直接入力および変更できます。

次の図は、Visual Studio の UI の名前を示したものです。

![Visual Studio のレイアウト](images/xaml-basics/visual-studio-tools.png)

各ツールを使用すると UI の作成が容易になるため、このチュートリアルではこれらをすべて使います。 最初に、XAML デザイナーを使用してコントロールを追加しましょう。 

**XAML デザイナーを使用してコントロールを追加するには:**

1. ソリューション エクスプローラーで、**MainPage.xaml** をダブルクリックして開きます。 これにより、UI 要素が追加されていない状態で、アプリのメイン ページが表示されます。

2. 先へ進む前に、Visual Studio を調整する必要があります。

    - ソリューション プラットフォームを必ず x86 または x64 (ARM は不可) に設定します。
    - メイン ページの XAML デザイナーで、13.3 インチ デスクトップのプレビューが表示されるように設定します。

    次のように、どちらの設定もウィンドウの最上部近辺にあります。

    ![VS の設定](images/xaml-basics/layout-vs-settings.png)

    これで、アプリを実行できますが、ほとんど何も表示されません。 このままではつまらないので、いくつか UI 要素を追加してみましょう。

3. [ツールボックス] で **[コモン XAML コントロール]** を展開し、[TextBlock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock) コントロールを見つけます。 TextBlock をデザイン サーフェイスにドラッグし、ページの左上隅近辺にドロップします。

    TextBlock がページに追加され、レイアウトに基づいて最も適していると判断されたいくつかのプロパティが設定されます。 現在アクティブなオブジェクトであることを示すために、TextBlock の周りが青色で強調表示されます。 余白やその他の設定がデザイナーによって追加されます。 XAML は次のようになります。 次のコードとまったく同じでなくても心配はいりません。ここでは、見やすくするために省略したコードを掲載しています。

    ```xaml
    <TextBlock x:Name="textBlock"
               HorizontalAlignment="Left"
               Margin="351,44,0,0"
               TextWrapping="Wrap"
               Text="TextBlock"
               VerticalAlignment="Top"/>
    ```

    次の手順では、これらの値を更新します。

4. [プロパティ] パネルで、TextBlock の [名前] の値を **textBlock** から **TitleTextBlock** に変更します  (まだ TextBlock がアクティブなオブジェクトであることを確認してください)。

5. **[共通]** の下で、Text 値を **Collection** に変更します。

    ![TextBlock のプロパティ](images/xaml-basics/text-block-properties.png)

    XAML エディターに、次のような XAML が表示されます。

    ```xaml
    <TextBlock x:Name="TitleTextBlock"
               HorizontalAlignment="Left"
               Margin="351,44,0,0"
               TextWrapping="Wrap"
               Text="Collection"
               VerticalAlignment="Top"/>
    ```

6. TextBlock を配置するには、まず Visual Studio によって追加されたプロパティ値を削除する必要があります。 [ドキュメント アウトライン] で **[TitleTextBlock]** を右クリックして、**[レイアウト] > [すべてリセット]** を選択します。

![ドキュメント アウトライン](images/xaml-basics/doc-outline-reset.png)

7. [プロパティ] パネルの検索ボックスに「**margin**」と入力します。これにより、**Margin** プロパティを簡単に見つけることができます。 左と下の余白を 24 に設定します。

    ![TextBlock の余白](images/xaml-basics/margins.png)

    余白は、ページ上の要素の配置に関する最も基本的なプロパティです。 これらはレイアウトを微調整するために便利ですが、Visual Studio によって追加される値のような大きな余白値を使用すると、UI をさまざまな画面サイズに適応させることが難しくなるため、大きな値の使用は避けてください。

    詳しくは、「[配置、余白、パディング](../layout/alignment-margin-padding.md)」をご覧ください。

8. [ドキュメント アウトライン] パネルで **[TitleTextBlock]** を右クリックし、**[スタイルの編集]、[リソースの適用]、[TitleTextBlockStyle]** の順に選択します。 これにより、システム定義のスタイルがタイトル テキストに適用されます。

    ```xaml
    <TextBlock x:Name="TitleTextBlock"
               TextWrapping="Wrap"
               Text="Collection"
               Margin="24,0,0,24"
               Style="{StaticResource TitleTextBlockStyle}"/>
    ```

9. [プロパティ] パネルの検索ボックスに「**textwrapping**」と入力して、**TextWrapping** プロパティを見つけます。 **TextWrapping** プロパティの_プロパティ マーカー_をクリックして、メニューを開きます  (_プロパティ マーカー_は、各プロパティ値の右側に表示される小さな四角形のシンボルです。 _プロパティ マーカー_は、プロパティが既定値以外に設定されていることを示す黒色になっています)。**[プロパティ]** メニューの **[リセット]** を選択して TextWrapping プロパティをリセットします。

    Visual Studio によってこのプロパティが追加されますが、適用したスタイルに既に設定されているため、ここでは必要ありません。

これで、UI の最初の部分をアプリに追加できました!  では、アプリを実行して結果を確認しましょう。

XAML デザイナーでは黒色の背景に白色のテキストが表示されましたが、アプリを実行すると、白色の背景に黒色のテキストが表示されました。 これは、Windows に [黒] と [白] のテーマがあり、既定のテーマがデバイスによって異なるためです。 PC では、既定のテーマは [白] です。 XAML デザイナーの上部にある歯車アイコンをクリックして [デバイス プレビューの設定] を開き、テーマを [ライト] に変更すると、アプリが XAML デザイナーで PC と同じように表示されるようになります。

> [!NOTE]
> チュートリアルのこの部分では、ドラッグ アンド ドロップでコントロールを追加しました。 コントロールは、[ツールボックス] でそのコントロールをダブルクリックして追加することもできます。 この方法を試し、Visual Studio によって生成される XAML で違いを確認してください。

## <a name="part-2-add-a-gridview-control-using-the-xaml-editor"></a>パート 2: XAML エディターを使用して GridView コントロールを追加する

パート 1 では XAML の基本を紹介し、Visual Studio から提供される他のツールをいくつか見ていただきました。 ここでは、XAML エディターを使用して、XAML マークアップを直接操作します。 XAML に慣れると、この方法の方が効率的であると感じられるかもしれません。

まず、ルート レイアウトである [Grid](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid) を [**RelativePanel**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.relativepanel) に置き換えます。 RelativePanel を使うと、パネルや他の UI に対して UI を簡単に再配置できます。 その便利さは、[XAML アダプティブ レイアウト](xaml-basics-adaptive-layout.md)のチュートリアルで確認できます。 

次に、データを表示するための [GridView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.gridview) コントロールを追加します。

**XAML エディターを使用してコントロールを追加する**

1. XAML エディターで、ルートの **Grid** を **RelativePanel** に変更します。

    **変更前**
    ```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
          <TextBlock x:Name="TitleTextBlock"
                     Text="Collection"
                     Margin="24,0,0,24"
                     Style="{StaticResource TitleTextBlockStyle}"/>
    </Grid>
    ```

    **変更後**
    ```xaml
    <RelativePanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock x:Name="TitleTextBlock"
                   Text="Collection"
                   Margin="24,0,0,24"
                   Style="{StaticResource TitleTextBlockStyle}"/>
    </RelativePanel>
    ```

    **RelativePanel** を使用したレイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#relativepanel)」をご覧ください。

2. **TextBlock** 要素の下に、ImageGridView という名前の **GridView コントロール**を追加します。 **RelativePanel** の添付プロパティ__ を設定して、コントロールをタイトル テキストの下に配置し、画面の横幅一杯に表示します。

    **追加する XAML**

    ```xaml
    <GridView x:Name="ImageGridView"
              Margin="0,0,0,8"
              RelativePanel.AlignLeftWithPanel="True"
              RelativePanel.AlignRightWithPanel="True"
              RelativePanel.Below="TitleTextBlock"/>
    ```

    **追加先: TextBlock の後**
    ```xaml
    <RelativePanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock x:Name="TitleTextBlock"
                   Text="Collection"
                   Margin="24,0,0,24"
                   Style="{StaticResource TitleTextBlockStyle}"/>
        
        <!-- Add the GridView here. -->

    </RelativePanel>
    ```

    Panel 添付プロパティについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels)」をご覧ください。

3. **GridView** に何かを表示するには、表示するデータのコレクションを追加する必要があります。 MainPage.xaml.cs を開き、**GetItemsAsync** メソッドを見つけます。 このメソッドでは、MainPage に追加したプロパティである、Images と呼ばれるコレクションが設定されます。

    **GetItemsAsync** の **foreach** ループの後に、次のコードを追加します。

    ```csharp
    ImageGridView.ItemsSource = Images;
    ```

    これにより、GridView の **ItemsSource** プロパティがアプリの **Images** コレクションに設定され、**GridView** に表示できるようになります。

ここでアプリを実行して、すべてが適切に動作しているかどうかを確認しましょう。 結果は次のようになるはずです。

![アプリの UI チェックポイント 1](images/xaml-basics/layout-0.png)

アプリにはイメージがまだ表示されていません。 既定では、コレクション内にあるデータ型の ToString 値が表示されます。 次に、データ テンプレートを作成して、データの表示方法を定義します。

> [!NOTE]
> **RelativePanel** を使用したレイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#relativepanel)」をご覧ください。 その後で、**TextBlock** と **GridView** の RelativePanel 添付プロパティを設定することで、さまざまなレイアウトを試してください。

## <a name="part-3-add-a-datatemplate-to-display-your-data"></a>パート 3: データに DataTemplate を追加する

ここでは、データの表示方法を GridView に伝える [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate) を作成します。 データ テンプレートについて詳しくは、「[項目コンテナーやテンプレート](../controls-and-patterns/item-containers-templates.md)」をご覧ください。

ここでは、希望のレイアウトを作成するためのプレースホルダーのみを追加します。 [XAML データ バインディング](../../data-binding/xaml-basics-data-binding.md)に関するチュートリアルでは、これらのプレースホルダーを **ImageFileInfo** クラスの実際のデータに置き換えます。 データ オブジェクトがどのようになっているか確認するには、ここで ImageFileInfo.cs ファイルを開くこともできます。

**データ テンプレートをグリッド ビューに追加する**

1. MainPage.xaml を開きます。

2. 評価を表示するには、[Telerik UI for UWP](https://github.com/telerik/UI-For-UWP) という NuGet パッケージの **RadRating** コントロールを使用します。 Telerik コントロールの名前空間を指定する XAML 名前空間の参照を追加します。 これを **Page** の開始タグ内 (他の一連の xmlns: エントリの直後) に配置します。

    **追加する XAML**

    ```xaml
    xmlns:telerikInput="using:Telerik.UI.Xaml.Controls.Input"
    ```

    **追加先: 最後の xmlns: エントリの後**

    ```xaml
    <Page x:Name="page"
      x:Class="PhotoLab.MainPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:local="using:PhotoLab"
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
      xmlns:telerikInput="using:Telerik.UI.Xaml.Controls.Input"
      mc:Ignorable="d"
      NavigationCacheMode="Enabled">
    ```

    XAML 名前空間について詳しくは、「[XAML 名前空間と名前空間マッピング](https://docs.microsoft.com/windows/uwp/xaml-platform/xaml-namespaces-and-namespace-mapping)」をご覧ください。

3. ドキュメント アウトラインで、**ImageGridView** を右クリックします。 コンテキスト メニューで、**[追加テンプレートの編集] > [生成されたアイテムの編集 (ItemTemplate)] > [空アイテムの作成]** を選択します。**[リソースの作成]** ダイアログが開きます。

4. ダイアログで、[名前 (キー)] の値を **ImageGridView_DefaultItemTemplate** に変更し、**[OK]** をクリックします。

    **[OK]** をクリックすると、いくつかの処理が行われます。

    - MainPage.xaml の Page.Resources セクションに、**DataTemplate** が追加されます。

        ```xaml
        <Page.Resources>
            <DataTemplate x:Key="ImageGridView_DefaultItemTemplate">
                <Grid/>
            </DataTemplate>
        </Page.Resources>
        ```

    - [ドキュメント アウトライン] のスコープが、この **DataTemplate** に設定されます。

        データ テンプレートの作成を終了したら、[ドキュメント アウトライン] の左上隅にある上向き矢印をクリックすると、ページのスコープに戻ることができます。

    - GridView の **ItemTemplate** プロパティが **DataTemplate** リソースに設定されます。

    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"/>
    ```

5. **ImageGridView_DefaultItemTemplate** リソースで、ルートの **Grid** の Height と Width に **300**、Margin に **8** を割り当てます。 次に、2 つの行を追加し、2 番目の行の Height を **Auto** に設定します。

    **変更前**
    ```xaml
    <Grid/>
    ```

    **変更後**
    ```xaml
    <Grid Height="300"
          Width="300"
          Margin="8">
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
    </Grid>
    ```

    Grid レイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#grid)」をご覧ください。

6. Grid にコントロールを追加します。

    a.  最初のグリッド行に **Image** コントロールを追加します。 これはイメージを表示する場所ですが、この時点では、プレースホルダーとしてアプリのストアのロゴを使用します。

    b.  イメージの名前、ファイルの種類、サイズを表示する **TextBlock** コントロールを追加します。 これには、テキスト ブロックを配置するための **StackPanel** コントロールを使用します。

    **StackPanel** レイアウトについて詳しくは、「[レイアウト パネル](https://docs.microsoft.com/windows/uwp/layout/layout-panels#stackpanel)」をご覧ください。

    c.  外側 (垂直方向) の **StackPanel** に **RadRating** コントロールを追加します。 これは内側 (水平方向) の **StackPanel** の後に配置します。

    **最終的なテンプレート**

    ```xaml
    <Grid Height="300"
          Width="300"
          Margin="8">
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>

        <Image x:Name="ItemImage"
               Source="Assets/StoreLogo.png"
               Stretch="Uniform" />

        <StackPanel Orientation="Vertical"
                    Grid.Row="1">
            <TextBlock Text="ImageTitle"
                       HorizontalAlignment="Center"
                       Style="{StaticResource SubtitleTextBlockStyle}" />
            <StackPanel Orientation="Horizontal"
                        HorizontalAlignment="Center">
                <TextBlock Text="ImageFileType"
                           HorizontalAlignment="Center"
                           Style="{StaticResource CaptionTextBlockStyle}" />
                <TextBlock Text="ImageDimensions"
                           HorizontalAlignment="Center"
                           Style="{StaticResource CaptionTextBlockStyle}"
                           Margin="8,0,0,0" />
            </StackPanel>

            <telerikInput:RadRating Value="3"
                                    IsReadOnly="True">
                <telerikInput:RadRating.FilledIconContentTemplate>
                    <DataTemplate>
                        <SymbolIcon Symbol="SolidStar"
                                    Foreground="White" />
                    </DataTemplate>
                </telerikInput:RadRating.FilledIconContentTemplate>
                <telerikInput:RadRating.EmptyIconContentTemplate>
                    <DataTemplate>
                        <SymbolIcon Symbol="OutlineStar"
                                    Foreground="White" />
                    </DataTemplate>
                </telerikInput:RadRating.EmptyIconContentTemplate>
            </telerikInput:RadRating>

        </StackPanel>
    </Grid>
    ```

ここでアプリを実行し、作成した項目テンプレートで **GridView** を確認します。 評価コントロールは、白の背景と白い星であるため、見えない可能性があります。 次は、背景色を変更します。

![アプリの UI チェックポイント 2](images/xaml-basics/layout-1.png)

## <a name="part-4-modify-the-item-container-style"></a>パート 4: 項目コンテナーのスタイルを変更する

項目のコントロール テンプレートには、選択、ホバー、フォーカスなどの状態を表示する視覚効果が含まれています。 これらの視覚効果は、データ テンプレートの上または下にレンダリングされます。 ここでは、コントロール テンプレートの **Background** プロパティおよび **Margin** プロパティを変更して、**GridView** 項目の背景色を灰色にします。

**項目コンテナーを変更する**

1. ドキュメント アウトラインで、**ImageGridView** を右クリックします。 コンテキスト メニューで、**[追加テンプレートの編集] > [生成されたアイテム コンテナーの編集 (ItemContainerStyle)] > [コピーして編集]** を選択します。**[リソースの作成]** ダイアログが開きます。

2. ダイアログで、[名前 (キー)] の値を **ImageGridView_DefaultItemContainerStyle** に変更し、**[OK]** をクリックします。

    既定スタイルのコピーが XAML の **Page.Resources** セクションに追加されます。

    ```xaml
    <Style x:Key="ImageGridView_DefaultItemContainerStyle" TargetType="GridViewItem">
        <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
        <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}"/>
        <Setter Property="Background" Value="{ThemeResource GridViewItemBackground}"/>
        <Setter Property="Foreground" Value="{ThemeResource GridViewItemForeground}"/>
        <Setter Property="TabNavigation" Value="Local"/>
        <Setter Property="IsHoldingEnabled" Value="True"/>
        <Setter Property="HorizontalContentAlignment" Value="Center"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Margin" Value="0,0,4,4"/>
        <Setter Property="MinWidth" Value="{ThemeResource GridViewItemMinWidth}"/>
        <Setter Property="MinHeight" Value="{ThemeResource GridViewItemMinHeight}"/>
        <Setter Property="AllowDrop" Value="False"/>
        <Setter Property="UseSystemFocusVisuals" Value="True"/>
        <Setter Property="FocusVisualMargin" Value="-2"/>
        <Setter Property="FocusVisualPrimaryBrush" Value="{ThemeResource GridViewItemFocusVisualPrimaryBrush}"/>
        <Setter Property="FocusVisualPrimaryThickness" Value="2"/>
        <Setter Property="FocusVisualSecondaryBrush" Value="{ThemeResource GridViewItemFocusVisualSecondaryBrush}"/>
        <Setter Property="FocusVisualSecondaryThickness" Value="1"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="GridViewItem">
                <!-- XAML removed for clarity
                    <ListViewItemPresenter ... />
                -->   
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    ```

    **GridViewItem** 既定スタイルでは、多数のプロパティが設定されます。 常に既定のスタイルのコピーを作成し、必要なプロパティのみ変更することをお勧めします。 そうしないと、一部のプロパティを正しく設定していないことが原因で、視覚効果が期待どおりに表示されない可能性があります。

    また、前の手順と同様、GridView の **ItemContainerStyle** プロパティが新しい **Style** リソースに設定されます。

    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"
                  ItemContainerStyle="{StaticResource ImageGridView_DefaultItemContainerStyle}"/>
    ```

3. **Background** プロパティの値を **Gray** に変更します。

    **変更前**
    ```xaml
        <Setter Property="Background" Value="{ThemeResource GridViewItemBackground}"/>
    ```

    **変更後**
    ```xaml
        <Setter Property="Background" Value="Gray"/>
    ```

4. **Margin** プロパティの値を **8** に変更します。

    **変更前**
    ```xaml
        <Setter Property="Margin" Value="0,0,4,4"/>
    ```

    **変更後**
    ```xaml
        <Setter Property="Margin" Value="8"/>
    ```

アプリを実行して、この時点での結果を確認します。 アプリ ウィンドウのサイズを変更します。 イメージの再配置は **GridView** によって自動的に処理されますが、幅によっては、アプリ ウィンドウの右余白が大きくなりすぎることがあります。 このような場合は、イメージを中央に配置した方が見栄えが良くなります。 次は、この点に関する対応を行います。

![アプリの UI チェックポイント 3](images/xaml-basics/layout-2.png)

> [!Note]
> 時間に余裕があれば、Background プロパティと Margin プロパティをさまざまな値に設定して、その結果がどうなるか試してみてください。

## <a name="part-5-apply-some-final-adjustments-to-the-layout"></a>パート 5: レイアウトに最終調整を適用する

イメージをページの中央に配置するには、ページ内で Grid の配置を調整する必要があります。 それとも、**GridView** 内でイメージの配置を調整した方がよいでしょうか。 どちらでも同じでしょうか?  見てみましょう。

配置について詳しくは、「[配置、余白、パディング](../layout/alignment-margin-padding.md)」をご覧ください。

(この手順で、**GridView** の **Background** を好きな色に設定することもできます。 その方が、レイアウトの変化がわかりやすくなります。)

**イメージの配置を変更する**

1. **Gridview** で、**HorizontalAlignment** プロパティを **Center** に設定します。

    **変更前**
    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"
                  ItemContainerStyle="{StaticResource ImageGridView_DefaultItemContainerStyle}"/>
    ```

    **変更後**
    ```xaml
        <GridView x:Name="ImageGridView"
                  Margin="0,0,0,8"
                  RelativePanel.AlignLeftWithPanel="True"
                  RelativePanel.AlignRightWithPanel="True"
                  RelativePanel.Below="TitleTextBlock"
                  ItemTemplate="{StaticResource ImageGridView_DefaultItemTemplate}"
                  ItemContainerStyle="{StaticResource ImageGridView_DefaultItemContainerStyle}" 
                  HorizontalAlignment="Center"/>
    ```

2. アプリを実行し、ウィンドウのサイズを変更します。 下へスクロールして、さらに多くのイメージを表示します。

    イメージは中央揃えで表示され、見栄えが良くなっています。 ただし、スクロール バーがウィンドウの端ではなく **GridView** の端に位置合わせされています。 この問題を解決するには、ページ内で **GridView** を中央揃えにするのではなく、**GridView** 内でイメージを中央揃えにします。 少し手間がかかりますが、最終的な見栄えは良くなります。

3. 前の手順で使用した **HorizontalAlignment** 設定を削除します。

4. ドキュメント アウトラインで、**ImageGridView** を右クリックします。 コンテキスト メニューで、**[追加テンプレートの編集] > [アイテムのレイアウトの編集 (ItemsPanel)] > [コピーして編集]** を選択します。**[リソースの作成]** ダイアログが開きます。

5. ダイアログで、[名前 (キー)] の値を **ImageGridView_ItemsPanelTemplate** に変更し、**[OK]** をクリックします。

    既定の **ItemsPanelTemplate** のコピーが XAML の **Page.Resources** セクションに追加されます  (今回も、このリソースを参照するように **GridView** が更新されます)。

    ```xaml
    <ItemsPanelTemplate x:Key="ImageGridView_ItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal" />
    </ItemsPanelTemplate>
    ```

    アプリ内の各種コントロールをレイアウトするためにさまざまなパネルを使用してきましたが、**GridView** にも、項目のレイアウトを管理する内部パネルがあります。 このパネル (**ItemsWrapGrid**) にアクセスできるようになったため、パネルのプロパティを変更して、**GridView** 内にある項目のレイアウトを変更します。

6. **ItemsWrapGrid** で、**HorizontalAlignment** プロパティを **Center** に設定します。

    **変更前**
    ```xaml
    <ItemsPanelTemplate x:Key="ImageGridView_ItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal" />
    </ItemsPanelTemplate>
    ```

    **変更後**
    ```xaml
    <ItemsPanelTemplate x:Key="ImageGridView_ItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal"
                       HorizontalAlignment="Center"/>
    </ItemsPanelTemplate>
    ```

7. アプリを実行し、ウィンドウのサイズをもう一度変更します。 下へスクロールして、さらに多くのイメージを表示します。

![アプリの UI チェックポイント 4](images/xaml-basics/layout-3.png)

これで、スクロール バーがウィンドウの端に位置合わせされました。 おめでとうございます!  アプリの基本的な UI を作成できました。

## <a name="going-further"></a>追加情報

これで基本的な UI を作成できたため、やはり PhotoLab サンプルに基づいているその他のチュートリアルも確認してください。 

* 「[XAML データ バインディングのチュートリアル](../../data-binding/xaml-basics-data-binding.md)」では、実際のイメージとデータを追加します。
* 「[XAML アダプティブ レイアウトのチュートリアル](xaml-basics-adaptive-layout.md)」では、さまざまな画面サイズに合わせて UI を調整します。


## <a name="get-the-final-version-of-the-photolab-sample"></a>PhotoLab サンプルの最終バージョンを入手する

このチュートリアルで完全な写真編集アプリは作成されません。必ず[最終バージョン](https://github.com/Microsoft/Windows-appsample-photo-lab)でカスタム アニメーションやスマートフォン サポートなど、他の機能を確認してください。

