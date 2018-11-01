---
author: KarlErickson
title: データ バインディングを作成する
description: この記事では、XAML でのデータ バインディングの基礎について説明します。
keywords: XAML, UWP, 概要
ms.author: karler
ms.date: 08/30/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 8000d9105481bc177eb2fc64646aec009fd80d36
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5876326"
---
# <a name="create-data-bindings"></a>データ バインディングを作成する

見栄えの良い UI をデザインして実装するとしましょう。その場合はまず、プレースホルダー イメージやダミーのボイラープレート テキスト、まだ何も動作しないコントロールを配置します。 次に、実際のデータに接続し、設計プロトタイプからライブ アプリに変換します。 

このチュートリアルでは、ボイラープレートをデータ バインディングに置き換え、UI とデータの間で直接リンクを作成する方法を学習します。 また、データを表示用に書式化または変換し、UI とデータの同期を維持する方法についても学習します。このチュートリアルを完了すると、XAML および C# コードのわかりやすさと構造を改善し、保守や拡張が容易なコードを作成できるようになります。

まず、PhotoLab サンプルの簡易バージョンから開始します。 このスターター バージョンには、完全なデータ レイヤーと基本的な XAML ページ レイアウトが含まれています。ただしこのバージョンでは、コードを見やすくするために多くの機能が除外されています。 このチュートリアルで完全なアプリは作成されません。必ず最終バージョンでカスタム アニメーションやスマートフォン サポートなどの機能を確認してください。 最終バージョンは、[Windows-appsample-photo-lab](https://github.com/Microsoft/Windows-appsample-photo-lab) リポジトリのルート フォルダーにあります。 

## <a name="prerequisites"></a>前提条件

* [Visual Studio 2017 と Windows 10 SDK の最新バージョン](https://developer.microsoft.com/windows/downloads)。

## <a name="part-0-get-the-code"></a>パート 0: コードを入手する
この演習の開始点は、PhotoLab サンプル リポジトリ ([xaml-basics-starting-points/data-binding](https://github.com/Microsoft/Windows-appsample-photo-lab/tree/master/xaml-basics-starting-points/data-binding) フォルダー) です。 このリポジトリを複製またはダウンロードした後、Visual Studio 2017 で PhotoLab.sln を開くことによって、プロジェクトを編集できます。

PhotoLab アプリには、次の 2 つのプライマリ ページがあります。

**MainPage.xaml:** フォト ギャラリー ビューが各イメージ ファイルに関する情報と共に表示されます。
![MainPage](../design/basics/images/xaml-basics/mainpage.png)

**DetailPage.xaml:** 選択された単一の写真が表示されます。 ポップアップの編集メニューにより、写真の編集、名前変更、保存を行うことができます。
![DetailPage](../design/basics/images/xaml-basics/detailpage.png)

## <a name="part-1-replace-the-placeholders"></a>パート 1: プレースホルダーを置き換える

ここでは、データ テンプレートの XAML で 1 回限りのバインディングを作成し、プレースホルダー コンテンツの代わりに実際のイメージとイメージ メタデータを表示します。 

1 回限りのバインディングは読み取り専用の不変データです。したがって、これらは高パフォーマンスで簡単に作成でき、大きなデータ セットも **GridView** コントロールおよび **ListView** コントロールに表示できます。 

**プレースホルダーを 1 回限りのバインディングに置き換える**

1. xaml-basics-starting-points\data-binding フォルダーを開き、PhotoLab.sln ファイルを起動します。 

2. ソリューション プラットフォームを必ず x86 または x64 (ARM は不可) に設定して、アプリを実行します。 これにより、バインドを追加する前の、UI プレースホルダーがある状態のアプリが表示されます。 

    ![実行中のアプリにプレースホルダー イメージとテキストが表示された状態](../design/basics/images/xaml-basics/gallery-with-placeholder-templates.png)

3. MainPage.xaml を開き、**ImageGridView_DefaultItemTemplate** という名前の **DataTemplate** を探します。 データ バインディングを使用するには、このテンプレートを更新します。 

    **変更前:**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate">
    ```

    **x:Key**値は、データ オブジェクトの表示用にこのテンプレートを選択するために **ImageGridView** によって使用されます。 

4. テンプレートに **x:DataType** 値を追加します。 

    **変更後:**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
    ```

    **x:DataType** は、このテンプレートが対応する型を示します。 この場合、このテンプレートが対応する型は **ImageFileInfo** クラスです ("local:" は local 名前空間を示します。これは、ファイルの先頭近くの xmlns 宣言で定義されています)。
    
    次に示すように、データ テンプレートで **x:Bind** 式を使用する場合には **x:DataType** が必要です。 

5. **DataTemplate** で、**ItemImage** という名前の **Image** 要素を探し、**Source** 値を次のように置き換えます。 

    **変更前:**
    ```xaml
    <Image x:Name="ItemImage" 
           Source="/Assets/StoreLogo.png" 
           Stretch="Uniform" />
    ```
    
    **変更後:**
    ```xaml
    <Image x:Name="ItemImage" 
           Source="{x:Bind ImageSource}" 
           Stretch="Uniform" />
    ```
    
    **x:Name** は XAML 要素を表し、XAML およびコード ビハインド内の任意の場所から参照できます。 

    **x:Bind** 式は、**data-object** プロパティから値を取得して UI プロパティに値を提供します。 テンプレート内で示されているプロパティは、**x:DataType** が設定されている対象のプロパティです。 この場合は、**ImageFileInfo.ImageSource** プロパティがデータ ソースです。 
    
    > [!NOTE] 
    > **x:Bind** 値によってデータ型がエディターに通知されるため、**x:Bind** 式にプロパティ名を入力する代わりに IntelliSense を使用することもできます。 先ほど貼り付けたコードで試すこともでき、**x:Bind** の直後にカーソルを置いて Space キーを押すと、バインド可能なプロパティの一覧が表示されます。

6. 他の UI コントロールの値も、同じ方法で置き換えます。 コピー/貼り付けではなく、IntelliSense を使ってみてください。

    **変更前:**
    ```xaml
    <TextBlock Text="Placeholder" ... />
    <StackPanel ... >
        <TextBlock Text="PNG file" ... />
        <TextBlock Text="50 x 50" ... />
    </StackPanel>
    <telerikInput:RadRating Value="3" ... />
    ```
    
    **変更後:**
    ```xaml
    <TextBlock Text="{x:Bind ImageTitle}" ... />
    <StackPanel ... >
        <TextBlock Text="{x:Bind ImageFileType}" ... />
        <TextBlock Text="{x:Bind ImageDimensions}" ... />
    </StackPanel>
    <telerikInput:RadRating Value="{x:Bind ImageRating}" ... />
    ```

アプリを実行して、ここまでの結果を確認します。 空のプレース ホルダーがなくなっています。 快調なスタートですね。 

![実行中のアプリで、プレース ホルダーの代わりに実際のイメージとテキストが表示されている](../design/basics/images/xaml-basics/gallery-with-populated-templates.png)

> [!Note]
> もっと試してみたい場合は、新しい TextBlock をデータ テンプレートに追加し、x:Bind で IntelliSense を使用して、表示するプロパティを見つけてください。 

## <a name="part-2-use-binding-to-connect-the-gallery-ui-to-the-images"></a>パート 2: バインディングを使用してギャラリー UI をイメージに接続する

ここでは、ページ XAML に 1 回限りのバインディングを作成してギャラリー ビューをイメージ コレクションに接続し、分離コードでこの操作を行う既存の手続き型コードを置き換えます。 また、イメージをコレクションから削除した場合にギャラリー ビューがどのように変化するかを見るために、**[Delete]** ボタンを作成します。 同時に、従来のイベント ハンドラーより柔軟性を高めるためにイベントをイベント ハンドラーにバインドする方法についても学習します。 

ここまでに説明したすべてのバインディングはデータ テンプレート内にあり、**x:DataType** 値で示されたクラスのプロパティを指しています。 では、ページ内の残りの部分の XAML を見てみましょう。 

データ テンプレート外の **x:Bind** 式は常にページ自体にバインドされます。 つまり、配置したものは分離コードで参照することも XAML で宣言することもできます。これには、ページ内の他の UI コントロール (**x:Name** 値が必要) のプロパティやカスタム プロパティも含まれます。 

PhotoLab サンプルでは、メインの **GridView** コントロールをイメージのコレクションに直接接続するために、(分離コード内で行う代わりに) このようなバインドが使用されています。 後でその他の例も確認します。 

**メイン GridView コントロールをイメージのコレクションにバインドする**

1. MainPage.xaml.cs で、**OnNavigatedTo** メソッドを見つけ、**ItemsSource** を設定するコードを削除します。

    **変更前:**
    ```c#
    ImageGridView.ItemsSource = Images;
    ```

    **変更後:**
    ```c#
    // Replaced with XAML binding:
    // ImageGridView.ItemsSource = Images;
    ```

2. MainPage.xaml で、**ImageGridView** という名前の **GridView** を探し、**ItemsSource** 属性を追加します。 値には、分離コードに実装されている **Images** プロパティを参照する **x:Bind** 式を使用します。 

    **変更前:**
    ```xaml
    <GridView x:Name="ImageGridView" 
    ```

    **変更後:**
    ```xaml
    <GridView x:Name="ImageGridView" 
              ItemsSource="{x:Bind Images}" 
    ```

    **Images** プロパティの型は **ObservableCollection\<ImageFileInfo\>** であるため、**GridView** に表示される個々の項目の型は **ImageFileInfo** になります。 これは、パート 1 で説明した **x:DataType** 値に一致します。 

ここまでで説明したすべてのバインディングは、1 回限りの読み取り専用バインディングですが、これは単純な **x:Bind** 式の既定動作です。 データは初期化の際にのみ読み込まれるため、バインディングのパフォーマンスが高くなります。これは、大きなデータ セットの複雑な複数ビューのサポートに最適です。 

先ほど追加した **ItemsSource** というバインディングも、不変プロパティ値に対する 1 回限りの読み取り専用バインディングですが、ここには重要な相違点があります。 **Images** プロパティの不変値は、コレクションの単一な特定インスタンスであり、ここに示されているように初期化されます。

```Csharp
private ObservableCollection<ImageFileInfo> Images { get; }
    = new ObservableCollection<ImageFileInfo>();
```

**Images** プロパティ値は変化しませんが、プロパティの型は **ObservableCollection\<T\>** であるため、コレクションの*コンテンツ*は変化することがあります。バインディングは自動的に変更を通知し、UI を更新します。 

これをテストするために、現在選択されているイメージを削除するボタンを一時的に追加します。 イメージを選択すると詳細ページに移動するため、このボタンは最終バージョンではありません。 ただし、XAML はページ コンストラクター内で (**InitializeComponent** メソッド呼び出しを介して) 初期化されるため、最終的な PhotoLab サンプルの中では、やはり **ObservableCollection\<T\>** の動作が重要になりますが、**Images** コレクションのデータは後で **OnNavigatedTo** メソッド内で設定されます。 

**削除ボタンを追加する**

1. MainPage.xaml で、**MainCommandBar** という名前の **CommandBar** を見つけ、新しいボタンを拡大ボタンより前に追加します。 (拡大コントロールは、まだ機能しません。 これらは、チュートリアルの次の部分で組み込みます。)

    ```xaml
    <AppBarButton Icon="Delete"
                  Label="Delete selected image"
                  Click="{x:Bind DeleteSelectedImage}" />
    ```

    既に XAML を使い慣れていれば、**Click** 値が通常とは異なることがわかるはずです。 以前のバージョンの XAML では、特定イベント ハンドラーのシグネチャ (多くの場合、イベント送信元を示すパラメーターやイベント固有の引数オブジェクトなど) を持つメソッドに設定する必要がありました。 この手法はイベント引数が必要な場合にも使用できますが、x:Bind では、他のメソッドにも接続できます。 たとえば、イベント データが必要でなければ、この場合のように、パラメーターを持たないメソッドに接続できます。

    <!-- TODO add doc links about event binding - and doc links in general? -->

2. MainPage.xaml.cs に、**DeleteSelectedImage** メソッドを追加します。

    ```c#
    private void DeleteSelectedImage() =>
        Images.Remove(ImageGridView.SelectedItem as ImageFileInfo);
    ```

    このメソッドは、単純に、**Images** コレクションから選択されたイメージを削除します。 

それではアプリを実行し、ボタンを使用して、イメージをいくつか削除しましょう。 おわかりのように、データ バインディングと **ObservableCollection\<T\>** 型を使用しているため、UI が自動的に更新されます。 

> [!Note]
> チャレンジとして、選択されたイメージを一覧内で上下に移動する 2 つのボタンを追加し、これらのボタンの Click イベントを (DeleteSelectedImage のような) 2 つの新しいメソッドに x:Bind でバインドしてみてください。
 
## <a name="part-3-set-up-the-zoom-slider"></a>パート 3: ズーム スライダーをセットアップする 

このパートでは、データ テンプレート内のコントロールから、テンプレート外にあるズーム スライダーへの一方向のバインディングを作成します。 データ バインディングを **TextBlock.Text** や **Image.Source** などの明白なもの以外に多数のコントロール プロパティと組み合わせて使用する方法についても学習します。 

**イメージ データ テンプレートをズーム スライダーにバインドする**

* **ImageGridView_DefaultItemTemplate** という名前の **DataTemplate** を見つけ、テンプレートの先頭にある **Grid** コントロールの **Height** 値と **Width** 値を置き換えます。

    **変更前**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="200"
              Width="200"
              Margin="{StaticResource LargeItemMargin}">
    ```
    
    **変更後**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="{Binding Value, ElementName=ZoomSlider}"
              Width="{Binding Value, ElementName=ZoomSlider}"
              Margin="{StaticResource LargeItemMargin}">
    ```
    
    <!-- TODO talk about dependency properties --> 
    
    これらは **x:Bind** 式ではなく **Binding** 式であることにお気づきですか?  これは、データ バインディングの従来の方法であり、現在はほとんど使用されていません。 **x:Bind** では、**Binding** で行われるほとんどすべての処理と、それ以上のことが行われます。 ただし、データ テンプレートで **x:Bind** を使用した場合は、**x:DataType** 値で宣言されている型にバインドされます。 では、テンプレート内の項目をページ XAML 内または分離コード内の項目にバインドするには、どのようにすればよいでしょうか?  この場合は、従来のスタイルの **Binding** 式を使用する必要があります。 
    
    **Binding** 式では **x:DataType** 値が認識されませんが、**Binding** 式には、同様の役割を果たす **ElementName** 値があります。 これらの値は、**Binding Value** はページ上にある指定された要素 (つまり、**x:Name** 値を持つ要素) の **Value** プロパティに対するバインディングであることをバインディング エンジンに伝えます。 分離コード内のプロパティにバインドする場合は、```{Binding MyCodeBehindProperty, ElementName=page}``` のようになります (**page** は、XAML の **Page** 要素で設定されている **x:Name** 値)。 
    
    > [!NOTE]
    > 既定では、**Binding** 式は*一方向*です。つまり、バインドされたプロパティ値が変化すると、UI が自動的に更新されます。 
    > 
    > これに対し、**x:Bind** は既定で *1 回限り*です。つまり、バインドされたプロパティへの変更は無視されます。 これは最もパフォーマンスの高いオプションであり、ほとんどのバインディング先は静的な読み取り専用データであるため、既定の動作として設定されています。 
    >
    > 値が変化するプロパティと共に **x:Bind** を使用する場合は、必ず ```Mode=OneWay``` または ```Mode=TwoWay``` を追加してください。 この例は、次のセクションで確認できます。

アプリを実行し、スライダーを使用してイメージ テンプレートのサイズを変更します。 ご覧のように、それほどコードを必要とせず、強力な効果を得ることができます。 

![実行中のアプリにズーム スライダーが表示されている](../design/basics/images/xaml-basics/gallery-with-zoom-control.png)

> [!NOTE]
> チャレンジとして、他の UI プロパティをズーム スライダーの **Value** プロパティか、ズーム スライダーの後に追加する他のスライダーにバインドしてみてください。 たとえば、**TitleTextBlock** の **FontSize** プロパティを新しいスライダーに、既定値の **24** でバインドすることができます。 適切な最小値と最大値を必ず設定してください。

## <a name="part-4-improve-the-zoom-experience"></a>手順 4: ズーム エクスペリエンスを改善する 

このパートでは、カスタムの **ItemSize** プロパティを分離コードに追加し、イメージ テンプレートから新しいプロパティへの一方向のバインディングを作成します。 **ItemSize** 値は、快適なエクスペリエンスのために、ズーム スライダーのほか、**[Fit to screen]** スイッチやウィンドウ サイズなどの要因によって更新されます。 

組み込みコントロールのプロパティとは異なり、カスタム プロパティでは、一方向または双方向のバインディングが設定されていても UI が自動更新されません。 カスタム プロパティには **1 回限り**のバインディングを設定できますが、プロパティを変更して実際の UI に反映させるには、多少の作業が必要になります。 

**UI を更新できるように ItemSize プロパティを作成する**

1. MainPage.xaml.cs で、**INotifyPropertyChanged** インターフェイスが実装されるように **MainPage** クラスのシグネチャを変更します。

    **変更前:**
    ```c#
    public sealed partial class MainPage : Page
    ```

    **変更後:**
    ```c#
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    ```

    これにより、MainPage に PropertyChanged イベント (以下で追加) があり、UI を更新するためにバインディングでリッスンできることがバインディング システムに通知されます。 

2. **MainPage** クラスに **PropertyChanged** イベントを追加します。

    ```c#
    public event PropertyChangedEventHandler PropertyChanged;
    ```

    このイベントは、**INotifyPropertyChanged** インターフェイスに必要な完全な実装を提供します。 ただし効力を持たせるには、カスタム プロパティでこのイベントを明示的に発生させる必要があります。 

3. **ItemSize** プロパティを追加し、setter 内で **PropertyChanged** イベントを発生させます。

    ```c#
    public double ItemSize
    {
        get => _itemSize;
        set
        {
            if (_itemSize != value)
            {
                _itemSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemSize)));
            }
        }
    }
    private double _itemSize;
    ```

    **ItemSize** プロパティは、プライベートの **_itemSize** フィールドの値を公開します。 このようなバッキング フィールドを使用すると、不要の可能性がある **PropertyChanged** イベントを発生させる前に、プロパティの新しい値が元の値と同じかどうかを確認することができます。

    イベント自体は **Invoke** メソッドによって発生します。 疑問符を指定すると、**PropertyChanged** イベントが null かどうか、つまり何らかのイベント ハンドラーが追加済みかどうかの確認が行われます。 一方向または双方向のすべてのバインディングでは、イベント ハンドラーが自動的に追加されますが、リッスンされていなければ、それ以上何も起こりません。 ただし **PropertyChanged** が null でなければ、イベント ソースへの参照 (ページ自体を **this** キーワードで表す) および **event-args** オブジェクト (プロパティの名前を示す) を指定して **Invoke** が呼び出されます。 変更があれば、バインドされている UI を更新できるように、この情報によって **ItemSize** プロパティに対する一方向または双方向のバインディングに通知されます。 

4. MainPage.xaml で、**ImageGridView_DefaultItemTemplate** という名前の **DataTemplate** を見つけ、テンプレートの先頭にある **Grid** コントロールの **Height** 値と **Width** 値を置き換えます。 (このチュートリアルの前のパートでコントロール間のバインディングを行った場合は、**Value** を **ItemSize** に、**ZoomSlider** を **page** に置き換えるだけです。 これを Height と Width の両方に行ってください。)

    **変更前**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="{Binding Value, ElementName=ZoomSlider}"
            Width="{Binding Value, ElementName=ZoomSlider}"
            Margin="{StaticResource LargeItemMargin}">
    ```
    
    **変更後**
    ```xaml
    <DataTemplate x:Key="ImageGridView_DefaultItemTemplate" 
                  x:DataType="local:ImageFileInfo">
        <Grid Height="{Binding ItemSize, ElementName=page}"
              Width="{Binding ItemSize, ElementName=page}"
              Margin="{StaticResource LargeItemMargin}">
    ```

UI が **ItemSize** の変化に対応できるようになったため、実際に変更を行ってみましょう。 前に説明したように、**ItemSize** 値はさまざまな UI コントロールの現在の状態から計算しますが、コントロールの状態が変化するたびにこの計算を実行する必要があります。 これを行うには、UI の変更によっては **ItemSize** を更新するためのヘルパー メソッドが呼び出されるように、イベント バインディングを使用します。 

**ItemSize プロパティ値を更新する**

1. MainPage.xaml.cs に、**DetermineItemSize** メソッドを追加します。

    ```c#
    private void DetermineItemSize()
    {
        if (FitScreenToggle != null
            && FitScreenToggle.IsOn == true
            && ImageGridView != null
            && ZoomSlider != null)
        {
            // The 'margins' value represents the total of the margins around the
            // image in the grid item. 8 from the ItemTemplate root grid + 8 from
            // the ItemContainerStyle * (Right + Left). If those values change, 
            // this value needs to be updated to match.
            int margins = (int)this.Resources["LargeItemMarginValue"] * 4;
            double gridWidth = ImageGridView.ActualWidth -
                (int)this.Resources["DesktopWindowSidePaddingValue"];
    
            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile" &&
                UIViewSettings.GetForCurrentView().UserInteractionMode ==
                    UserInteractionMode.Touch)
            {
                margins = (int)this.Resources["SmallItemMarginValue"] * 4;
                gridWidth = ImageGridView.ActualWidth -
                    (int)this.Resources["MobileWindowSidePaddingValue"];
            }
    
            double ItemWidth = ZoomSlider.Value + margins;
            // We need at least 1 column.
            int columns = (int)Math.Max(gridWidth / ItemWidth, 1);
    
            // Adjust the available grid width to account for margins around each item.
            double adjustedGridWidth = gridWidth - (columns * margins);
    
            ItemSize = (adjustedGridWidth / columns);
        }
        else
        {
            ItemSize = ZoomSlider.Value;
        }
    }
    ```

2. MainPage.xaml でファイルの先頭に移動し、**Page** 要素に **SizeChanged** イベント バインディングを追加します。

    **変更前:**
    ```xaml
    <Page x:Name="page"  
    ```

    **変更後:**
    ```xaml
    <Page x:Name="page" 
          SizeChanged="{x:Bind DetermineItemSize}"
    ```

3. **ZoomSlider** という名前の **Slider** を見つけ、**ValueChanged** イベント バインディングを追加します。

    **変更前:**
    ```xaml
    <Slider x:Name="ZoomSlider"
    ```

    **変更後:**
    ```xaml
    <Slider x:Name="ZoomSlider"
            ValueChanged="{x:Bind DetermineItemSize}"
    ```

4. **FitScreenToggle** という名前の **ToggleSwitch** を見つけ、**Toggled** イベント バインディングを追加します。

    **変更前:**
    ```xaml
    <ToggleSwitch x:Name="FitScreenToggle"
    ```

    **変更後:**
    ```xaml
    <ToggleSwitch x:Name="FitScreenToggle"
                  Toggled="{x:Bind DetermineItemSize}"
    ```

アプリを実行し、ズーム スライダーと **[Fit to screen]** スイッチを使用して、イメージ テンプレートのサイズを変更します。 ご覧のように、最新の変更内容では、コードを適切な構造に維持しつつ、ズーム/サイズ変更のエクスペリエンスがさらに調整されています。 

![実行中のアプリで画面に合わせるスイッチがオンになっている](../design/basics/images/xaml-basics/gallery-with-fit-to-screen.png)

> [!NOTE]
> チャレンジとして、**ZoomSlider** の後に **TextBlock** を追加し、**Text** プロパティを **ItemSize** プロパティにバインドしてみてください。 これはデータ テンプレートではないため、前の **ItemSize** バインディングのように、**Binding** の代わりに **x:Bind** を使用できます。  
}

## <a name="part-5-enable-user-edits"></a>パート 5: ユーザー編集を有効にする

ここでは、イメージ タイトル、評価、さまざまな視覚効果などの値をユーザーが更新できるように、双方向のバインディングを作成します。 

これを実現するには、単一イメージ ビューアー、ズーム コントロール、UI 編集を提供する、既存の **DetailPage** を更新します。  

ただし、まず **DetailPage** (ギャラリー ビューでユーザーによってイメージがクリックされたときにアプリが移動する先) をアタッチする必要があります。

**DetailPage をアタッチする**

1. MainPage.xaml で、**ImageGridView** という名前の **GridView** を探し、**ItemClick** 値を追加します。 

    > [!TIP] 
    > コピー/貼り付けの代わりに以下の変更を入力すると、IntelliSense ポップアップに "\<New Event Handler\>" と表示されます。 Tab キーを押すと、既定のメソッド ハンドラー名を使用して値が指定され、メソッドが自動的にスタブアウトされます (次の手順を参照)。 F12 キーを押すと、分離コード内にある、このメソッドに移動できます。 

    **変更前:**
    ```xaml
    <GridView x:Name="ImageGridView"
    ```

    **変更後:**
    ```xaml
    <GridView x:Name="ImageGridView"
              ItemClick="ImageGridView_ItemClick"
    ```

    > [!NOTE] 
    > ここでは、x:Bind 式ではなく従来のイベント ハンドラーを使用します。 これは、次に示すようにイベント データを参照する必要があるためです。 

2. MainPage.xaml.cs で、イベント ハンドラーを追加 (前の手順のヒントを使用した場合は、指定) します。

    ```c#
    private void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        this.Frame.Navigate(typeof(DetailPage), e.ClickedItem);
    }
    ```

    このメソッドは、単純に詳細ページに移動するだけです。このとき、クリックされた項目 (**DetailPage.OnNavigatedTo** でページの初期化に使用された **ImageFileInfo** オブジェクト) が渡されます。 このチュートリアルで、このメソッドを実装する必要はありませんが、コードで動作の内容を確認してください。 
    
3. (オプション) ここまでのプレイ ポイントで追加した、現在選択されているイメージと連携するコントロールを削除またはコメントアウトします。 これらを残しても問題はありませんが、詳細ページに移動せずにイメージを選択することがずっと困難になっています。 

2 つのページを接続したので、アプリを実行して結果を確認しましょう。 すべて想定どおりに動作しますが、編集ペインのコントロールだけは、値を変更しようとしても応答しません。 

ご覧のように、タイトル テキスト ボックスではタイトルが表示され、変更を入力できます。 変更をコミットするには別のコントロールにフォーカスを移動する必要がありますが、画面の左上にあるタイトルは、まだ更新されません。 

コントロールはすべて、パート 1 で説明した単純な **x:Bind** 式を使用して既にバインドされています。 つまり、これらはすべて 1 回限りのバインディングであり、値への変更が登録されていないのはそのためです。 これを修正するために必要な操作は、双方向のバインディングに変換することです。 

**編集コントロールを対話型に変換する**

1. DetailPage.xaml で、**TitleTextBlock** という名前の **TextBlock** と、その後の **RadRating** コントロールを見つけ、それぞれの **x:Bind** 式に **Mode=TwoWay** を追加します。

    **変更前:**
    ```xaml
    <TextBlock x:Name="TitleTextBlock"
               Text="{x:Bind item.ImageTitle}"
               ... >
    <telerikInput:RadRating Value="{x:Bind item.ImageRating}"
                            ... >
    ```

    **変更後:**
    ```xaml
    <TextBlock x:Name="TitleTextBlock" 
               Text="{x:Bind item.ImageTitle, Mode=TwoWay}" 
               ... >
    <telerikInput:RadRating Value="{x:Bind item.ImageRating, Mode=TwoWay}" 
                            ... >
    ```

2. 評価コントロールの後のすべてのエフェクト スライダーにも、同じ操作を行います。

    ```xaml
    <Slider Header="Exposure"    ... Value="{x:Bind item.Exposure, Mode=TwoWay}" ...
    <Slider Header="Temperature" ... Value="{x:Bind item.Temperature, Mode=TwoWay}" ... 
    <Slider Header="Tint"        ... Value="{x:Bind item.Tint, Mode=TwoWay}" ... 
    <Slider Header="Contrast"    ... Value="{x:Bind item.Contrast, Mode=TwoWay}" ... 
    <Slider Header="Saturation"  ... Value="{x:Bind item.Saturation, Mode=TwoWay}" ...
    <Slider Header="Blur"        ... Value="{x:Bind item.Blur, Mode=TwoWay}" ... 
    ```

双方向モードとは、その名前が示すように、いずれかの側で変更が発生するたびにデータが双方向に移動することを意味します。 

前に説明した一方向のバインディングのように、これらの双方向バインディングでも、**ImageFileInfo** クラスの **INotifyPropertyChanged** 実装により、バインドされたプロパティが変化するたびに UI が更新されるようになります。 ただし、双方向バインディングでは、ユーザーがコントロールを操作するたびに、UI からバインド先プロパティにも値が移動します。 これで、XAML 側への作業は完了しました。 

アプリを実行し、編集コントロールを試してください。 変更を行うと、イメージの値に影響するようになっています。また、メイン ページに戻っても、これらの変更はそのままです。 

## <a name="part-6-format-values-through-function-binding"></a>パート 6: 関数バインディングを介して値を書式化する

最後に問題が 1 つ残っています。 エフェクト スライダーを動かしても、横にあるラベルが変化しません。 

![既定のラベル値が表示されたエフェクト スライダー](../design/basics/images/xaml-basics/effect-sliders-before-label-fix.png)

このチュートリアルの最後のパートでは、表示用にスライダーの値を書式化するバインディングを追加します。

**エフェクト スライダーのラベルをバインドし、表示用に値を書式化する**

1. **Exposure** スライダーの後の **TextBlock** を見つけ、**Text** 値を下のバインディング式に置き換えます。

    **変更前:**
    ```xaml
    <Slider Header="Exposure" ... />
    <TextBlock ... Text="0.00" />
    ```

    **変更後:**
    ```xaml
    <Slider Header="Exposure" ... />
    <TextBlock ... Text="{x:Bind item.Exposure.ToString('N', culture), Mode=OneWay}" />
    ```

    これは、メソッドの戻り値へのバインドであるため、関数バインディングと呼ばれます。 メソッドには、ページの分離コードまたは **x:DataType** 型 (データ テンプレートの使用時) を介してアクセスできるようにする必要があります。 この場合のメソッドは、.NET でよく使用される **ToString** メソッドです。ページの item プロパティでアクセスし、さらに item の **Exposure** プロパティでアクセスしています。 (これは、何重もの接続構造に深く入れ子状態になっているメソッドやプロパティをバインドする方法を示しています。)

    関数バインディングは、他のバインディング ソースをメソッドの引数として渡すことができるため、値を表示用に書式化する場合に最も望ましい方法です。バインディング式は、これらの値の変化を一方向モードでリッスンします。 この例の **culture** 引数は、分離コードに実装されている不変フィールドへの参照ですが、**PropertyChanged** イベントを発生させるプロパティにすることも簡単にできます。 その場合は、プロパティ値に変化が発生すると、**x:Bind** 式が新しい値を使用して **ToString** を呼び出し、その結果で UI を更新します。 

2. 他のエフェクト スライダーにラベル付けする **TextBlocks** に対しても、同じ操作を行います。

    ```xaml
    <Slider Header="Temperature" ... />
    <TextBlock ... Text="{x:Bind item.Temperature.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Tint" ... />
    <TextBlock ... Text="{x:Bind item.Tint.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Contrast" ... />
    <TextBlock ... Text="{x:Bind item.Contrast.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Saturation" ... />
    <TextBlock ... Text="{x:Bind item.Saturation.ToString('N', culture), Mode=OneWay}" />

    <Slider Header="Blur" ... />
    <TextBlock ... Text="{x:Bind item.Blur.ToString('N', culture), Mode=OneWay}" />
    ```

これで、アプリを実行すると、スライダーのラベルを含めてすべてが正常に動作します。 

![ラベルが機能するエフェクト スライダー](../design/basics/images/xaml-basics/effect-sliders-after-label-fix.png)

> [!NOTE]
> 前のプレイ ポイントで説明した **TextBlock** に関数バインディングを使用し、**ItemSize** 値が渡されると "000 x 000" 形式の文字列を返す新しいメソッドにバインドしてみてください。


## <a name="conclusion"></a>まとめ

このチュートリアルでは、データ バインディングの基本を紹介し、いくつかの機能を見ていただきました。 終わる前に、1 つ注意しておきたいのは、すべてがバインド可能ではないということです。また、接続しようとする対象の値に、バインドしようとするプロパティとの互換性がない場合もあります。 バインディングには高い柔軟性がありますが、あらゆる状況に対応できるわけではありません。

バインディングで対処できない問題の一例は、詳細ページのズーム機能と同様、コントロールをバインドできる適切なプロパティがない場合です。 このズーム スライダーは、イメージを表示する **ScrollViewer** と連携する必要がありますが、**ScrollViewer** を更新できるのは、自身の **ChangeView** メソッドのみです。 この場合は、従来のイベント ハンドラーを使用して、**ScrollViewer** とズーム スライダーの同期を維持します。詳しくは、**DetailPage** の **ZoomSlider_ValueChanged** メソッドと **MainImageScroll_ViewChanged** メソッドを参照してください。

とはいえ、コードを簡素化してデータ ロジックから UI のロジックを分離するための強力で柔軟な方法として、バインディングは有用です。 このように分離することで、どちらの側に対しても調整が容易になり、相手側にバグが入り込むリスクを軽減できます。 

**ImageFileInfo.ImageTitle** プロパティは、UI とデータを分離のしている例の 1 つです。 このプロパティ (および **ImageRating** プロパティ) は、パート 4 で作成した **ItemSize** と少し異なっており、フィールドではなくファイル メタデータ (**ImageProperties** 型によって公開) に値が格納されます。 また、ファイルのメタデータにタイトルがない場合は、**ImageTitle** によって **ImageName** 値 (ファイル名として設定) が返されます。 

```c#
public string ImageTitle
{
    get => String.IsNullOrEmpty(ImageProperties.Title) ? ImageName : ImageProperties.Title;
    set
    {
        if (ImageProperties.Title != value)
        {
            ImageProperties.Title = value;
            var ignoreResult = ImageProperties.SavePropertiesAsync();
            OnPropertyChanged();
        }
    }
}
```

ご覧のように、setter が **ImageProperties.Title** プロパティを更新してから、新しい値をファイルに書き込むために **SavePropertiesAsync** を呼び出しています  (これは非同期のメソッドですが、プロパティに **await** キーワードを使うことはできません。プロパティの getter と setter を直ちに完了する必要があるため、このキーワードの使用は不適切です。 代わりに、メソッドを呼び出して、返される **Task** オブジェクトを無視します)。 

<!-- TODO more screenshots? -->

## <a name="going-further"></a>追加情報

これで、この演習は終わりです。自身で問題に取り組むために必要な、バインディングに関する知識を身につけることができました。

お気付きのように、詳細ページでズーム レベルを変更しても、前に戻って同じイメージをもう一度選択すると、ズーム レベルが自動的にリセットされます。 各イメージのズーム レベルを保存して個別に復元する方法はわかりますか?  幸運をお祈りします!
    
必要な情報はすべてこのチュートリアルにありますが、さらにガイダンスが必要な場合は、データ バインディングに関するドキュメントをご覧ください。 以下のリンクから参照できます。

+ [{x:Bind} マークアップ拡張](https://docs.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension)
+ [データ バインディングの詳細](https://docs.microsoft.com/windows/uwp/data-binding/data-binding-in-depth)