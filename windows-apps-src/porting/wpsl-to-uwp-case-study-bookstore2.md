---
author: stevewhims
ms.assetid: 333f67f5-f012-4981-917f-c6fd271267c6
description: このケース スタディ、Bookstore で情報に基づいて、グループ化されたデータを LongListSelector を表示する WindowsPhone Silverlight アプリから始まります。
title: WindowsPhone Silverlight から UWP ケース スタディ-Bookstore2
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8e518439ddd4e131c2d045f4467670b42a392fca
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7442186"
---
# <a name="windowsphone-silverlight-to-uwp-case-study-bookstore2"></a>WindowsPhone Silverlight から UWP へのケース スタディ: Bookstore2


このケース スタディ- [bookstore1](wpsl-to-uwp-case-study-bookstore1.md)情報に基づいて、グループ化された**LongListSelector**内のデータを表示する WindowsPhone Silverlight アプリから始まります。 ビュー モデルでは、**Author** クラスの各インスタンスは、該当する著者によって書かれた書籍のグループを表します。**LongListSelector** では、著者ごとにグループ化された書籍の一覧を表示したり、縮小して著者のジャンプ リストを表示したりすることができます。 ジャンプ リストを使うと、書籍の一覧をスクロールするよりもすばやく移動することができます。 Windows10Universal Windows プラットフォーム (UWP) アプリにアプリを移植する手順について説明します。

**注:** と Visual Studio で bookstore2universal \_10 を開く「Visual Studio 更新プログラムが必要」、メッセージを表示し、手順[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)でターゲット プラットフォームのバージョンを設定するためです。

## <a name="downloads"></a>ダウンロード

[ダウンロード、Bookstore2WPSL8 WindowsPhone Silverlight アプリ](http://go.microsoft.com/fwlink/p/?linkid=522601)です。

[Windows 10 アプリをダウンロード、bookstore2universal \_10](http://go.microsoft.com/fwlink/?linkid=532952)します。

##  <a name="the-windowsphone-silverlight-app"></a>WindowsPhone Silverlight アプリ

下の図は、ここで移植するアプリ Bookstore2WPSL8 の外観を示しています。 このアプリでは、著者ごとにグループ化された書籍の **LongListSelector** を縦方向にスクロールします。 このリストを縮小してジャンプ リストを表示し、そこから任意のグループに移動できます。 このアプリには 2 つの重要な機能があります。それらは、グループ化されたデータ ソースを提供するビュー モデルと、そのビュー モデルにバインドされるユーザー インターフェイスです。 思いますが、これらの要素を WindowsPhone Silverlight テクノロジから簡単に移植できますユニバーサル Windows プラットフォーム (UWP)。

![Bookstore2WPSL8 の外観](images/wpsl-to-uwp-case-studies/c02-01-wpsl-how-the-app-looks.png)

##  <a name="porting-to-a-windows10-project"></a>Windows 10 プロジェクトへの移植

Visual Studio で新しいプロジェクトを作成し、そこへ Bookstore2WPSL8 からファイルをコピーし、コピーしたファイルを新しいプロジェクトに含めるというタスクは、短時間で実行できます。 最初に、"新しいアプリケーション (Windows ユニバーサル)" プロジェクトを新規作成します。 そして、"Bookstore2Universal\_10" という名前を付けます。 Bookstore2WPSL8 から Bookstore2Universal\_10 にコピーするファイルを、以下に示します。

-   ブック カバーの画像の PNG ファイルを含むフォルダー (フォルダーは \\Assets\\CoverImages) をコピーします。 フォルダーをコピーしたら、**ソリューション エクスプローラー**で **[すべてのファイルを表示]** がオンであることを確認します。 コピーしたフォルダーを右クリックし、**[プロジェクトに含める]** をクリックします。 このコマンドは、ファイルまたはフォルダーをプロジェクトに "含める" ことを意味します。 ファイルやフォルダーをコピーするたびに、**ソリューション エクスプローラー**で **[更新]** をクリックしてから、ファイルまたはフォルダーをプロジェクトに含めます。 コピー先で置き換えるファイルについては、この手順を実行する必要はありません。
-   ビュー モデル ソース ファイルを含むフォルダー (フォルダーは \\ViewModel) をコピーします。
-   MainPage.xaml をコピーして、コピー先のファイルを置き換えます。

App.xaml と App.xaml.cs Visual Studio によって生成された windows 10 プロジェクトを保持できます。

コピーしたソース コードとマークアップ ファイルを編集し、Bookstore2WPSL8 名前空間への参照をすべて、Bookstore2Universal\_10 に変更します。 これをすばやく行うには、**[フォルダーを指定して置換]** 機能を使います。 ビュー モデルのソース ファイルに含まれている命令型コードでは、移植作業のために次の変更を行う必要があります。

-   `System.ComponentModel.DesignerProperties` を `DesignMode` に変更した後、これに対して **[解決]** コマンドを使います。 `IsInDesignTool` プロパティを削除し、IntelliSense を使って適切なプロパティ名 (`DesignModeEnabled`) を追加します。
-   `ImageSource` に対して **[解決]** コマンドを使います。
-   `BitmapImage` に対して **[解決]** コマンドを使います。
-   `using System.Windows.Media;` と `using System.Windows.Media.Imaging;` を削除します。
-   **Bookstore2Universal\_10.BookstoreViewModel.AppName** プロパティによって返された値を "BOOKSTORE2WPSL8" から "BOOKSTORE2UNIVERSAL" に変更します。
-   「[Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)」の場合と同じように、**BookSku.CoverImage** プロパティの実装を更新します (「[ビュー モデルへの画像のバインド](wpsl-to-uwp-case-study-bookstore1.md)」をご覧ください)。

MainPage.xaml では、初期の移植作業のために次の変更を行う必要があります。

-   `phone:PhoneApplicationPage` を `Page` に変更します (プロパティ要素構文での出現箇所を含みます)。
-   `phone` と `shell` の名前空間のプレフィックス宣言を削除します。
-   その他の名前空間のプレフィックス宣言で、"clr-namespace" を "using" に変更します。
-   `SupportedOrientations="Portrait"` と `Orientation="Portrait"` を削除し、新しいプロジェクトのアプリ パッケージ マニフェストで**縦方向**を構成します。
-   `shell:SystemTray.IsVisible="True"` を削除します。
-   ジャンプ リスト項目コンバーター (マークアップ内にリソースとして含まれています) の種類は、[**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) 名前空間に移動しています。 そのため、名前空間のプレフィックス宣言 Windows\_UI\_Xaml\_Controls\_Primitives を追加し、これを **Windows.UI.Xaml.Controls.Primitives** にマップします。 ジャンプ リスト項目コンバーターのリソースで、プレフィックスを `phone:` から `Windows_UI_Xaml_Controls_Primitives:` に変更します。
-   「[Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)」の場合と同じように、`PhoneTextExtraLargeStyle` **TextBlock** スタイルに対するすべての参照を `SubtitleTextBlockStyle` に対する参照に置き換えます。また、`PhoneTextSubtleStyle` を `SubtitleTextBlockStyle` に、`PhoneTextNormalStyle` を `CaptionTextBlockStyle` に、`PhoneTextTitle1Style` を `HeaderTextBlockStyle` に置き換えます。
-   `BookTemplate` には例外が 1 つあります。 2 番目の **TextBlock** のスタイルは、`CaptionTextBlockStyle` を参照している必要があります。
-   `AuthorGroupHeaderTemplate` の内部の **TextBlock** から FontFamily 属性を削除し、**Border** の Background が `PhoneAccentBrush` の代わりに `SystemControlBackgroundAccentBrush` を参照するように設定します。
-   [表示ピクセルに関連する変更](wpsl-to-uwp-porting-xaml-and-ui.md)のため、マークアップ全体を調べて、すべての固定サイズの寸法 (余白、幅、高さなど) を 0.8 倍にする必要があります。

## <a name="replacing-the-longlistselector"></a>LongListSelector の置き換え


**LongListSelector** を [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) コントロールに置き換えるには、いくつかの手順があります。この手順を始めましょう。 **LongListSelector** はグループ化されたデータ ソースに直接バインドされますが、**SemanticZoom** には [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) コントロールや [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) コントロールが含まれており、これらのコントロールは [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/br209833) アダプターを経由してデータに間接的にバインドされます。 **CollectionViewSource** はマークアップ内にリソースとして含まれている必要があります。そのため、最初にこの項目を MainPage.xaml の `<Page.Resources>` 内にあるマークアップに追加します。

```xml
    <CollectionViewSource
        x:Name="AuthorHasACollectionOfBookSku"
        Source="{Binding Authors}"
        IsSourceGrouped="true"/>
```

**LongListSelector.ItemsSource** のバインディングは **CollectionViewSource.Source** の値になり、**LongListSelector.IsGroupingEnabled** は **CollectionViewSource.IsSourceGrouped** になることに注意してください。 **CollectionViewSource** には名前 (キーではないので注意してください) があるので、この名前に対してバインドすることができます。

次に、`phone:LongListSelector` をこのマークアップに置き換えます。これにより、暫定的な **SemanticZoom** が機能します。

```xml
    <SemanticZoom>
        <SemanticZoom.ZoomedInView>
            <ListView
                ItemsSource="{Binding Source={StaticResource AuthorHasACollectionOfBookSku}}"
                ItemTemplate="{StaticResource BookTemplate}">
                <ListView.GroupStyle>
                    <GroupStyle
                        HeaderTemplate="{StaticResource AuthorGroupHeaderTemplate}"
                        HidesIfEmpty="True"/>
                </ListView.GroupStyle>
            </ListView>
        </SemanticZoom.ZoomedInView>
        <SemanticZoom.ZoomedOutView>
            <ListView
                ItemsSource="{Binding CollectionGroups, Source={StaticResource AuthorHasACollectionOfBookSku}}"
                ItemTemplate="{StaticResource ZoomedOutAuthorTemplate}"/>
        </SemanticZoom.ZoomedOutView>
    </SemanticZoom>
```

**LongListSelector** でのフラット リスト モードとジャンプ リスト モードに関する概念は、**SemanticZoom** での拡大表示と縮小表示に関する概念にそれぞれ対応しています。 拡大表示はプロパティであり、そのプロパティを **ListView** のインスタンスに設定します。 この場合、縮小表示も **ListView** に設定され、両方の **ListView** コントロールが **CollectionViewSource** にバインドされます。 拡大表示では、**LongListSelector** のフラット リストで使われているものと同じ項目テンプレート、グループ ヘッダー テンプレート、および **HideEmptyGroups** 設定 (現在は **HidesIfEmpty** という名前) が使われます。 縮小表示では、**LongListSelector** のジャンプ リストのスタイル (`AuthorNameJumpListStyle`) に含まれているものと類似した項目テンプレートが使われます。 また、縮小表示は **CollectionViewSource** の特殊なプロパティ (**CollectionGroups**) にバインドされていることにも注意してください。このプロパティは、項目ではなくグループを含んでいるコレクションを表しています。

`AuthorNameJumpListStyle` は不要になりました (ただしすべてが不要になったわけではありません)。 縮小表示ビューで必要となるのは、グループ (このアプリでは著者) のデータ テンプレートだけです。 ここでは、`AuthorNameJumpListStyle` スタイルを削除し、このスタイルを次のデータ テンプレートに置き換えます。

```xml
   <DataTemplate x:Key="ZoomedOutAuthorTemplate">
        <Border Margin="9.6,0.8" Background="{Binding Converter={StaticResource JumpListItemBackgroundConverter}}">
            <TextBlock Margin="9.6,0,9.6,4.8" Text="{Binding Group.Name}" Style="{StaticResource SubtitleTextBlockStyle}"
            Foreground="{Binding Converter={StaticResource JumpListItemForegroundConverter}}" VerticalAlignment="Bottom"/>
        </Border>
    </DataTemplate>
```

このデータ テンプレートのデータ コンテキストは、項目ではなくグループであるため、**Group** という名前の特殊なプロパティにバインドすることに注意してください。

これで、アプリをビルドして実行できるようになりました。 モバイル エミュレーターでは次のように表示されます。

![最初のソース コードの変更を加えたモバイルの UWP アプリ](images/wpsl-to-uwp-case-studies/c02-02-mob10-initial-source-code-changes.png)

ビュー モデル、拡大表示、縮小表示は適切に連携しますが、スタイル設定やテンプレート化の作業を必要とする問題があります。 たとえば、適切なスタイルとブラシがまだ使われていない、テキストが縮小表示のためにクリックできるグループ ヘッダーに表示されないようにします。デスクトップ デバイスでアプリを実行すると、アプリがまだ対応していないこと、最適なエクスペリエンスと、windows できる可能性のあるモバイル デバイスの画面よりもずっとサイズが大きい大型デバイス上の領域を使用するためのユーザー インターフェイスは、2 つ目の問題が表示されます。 次のセクション (「[最初のスタイル設定とテンプレート化](#initial-styling-and-templating)」、「[アダプティブ UI](#adaptive-ui)」、「[最終的なスタイル設定](#final-styling)」) では、これらの問題に対処します。

## <a name="initial-styling-and-templating"></a>最初のスタイル設定とテンプレート化

適切な間隔でグループ ヘッダーを配置するには、`AuthorGroupHeaderTemplate` を編集し、**Border** で **Margin** を `"0,0,0,9.6"` に設定します。

適切な間隔で書籍項目を配置するには、`BookTemplate` を編集し、両方の **TextBlock** で **Margin** を `"9.6,0"` に設定します。

アプリ名とページ タイトルのレイアウトを向上させるには、`TitlePanel` 内で、2 番目の **TextBlock** の上余白を削除します。そのためには、**Margin** の値を `"7.2,0,0,0"` に設定します。 また、`TitlePanel` 自体で、余白を `0` (または適切な外観になる任意の値) に設定します。

`LayoutRoot` の Background を `"{ThemeResource ApplicationPageBackgroundThemeBrush}"` に変更します。

## <a name="adaptive-ui"></a>アダプティブ UI

Phone アプリを基にして作業を開始したため、この段階のプロセスでは、移植したアプリの UI レイアウトが小型のデバイスや狭いウィンドウにのみ適したレイアウトになっているのは当然です。 実現しようとしている UI レイアウトは、アプリを幅の広いウィンドウで実行しているとき (大型画面を備えたデバイスの場合) には自動的に調整して広い領域を活用し、アプリのウィンドウが狭い場合 (小型のデバイスが該当しますが、大型のデバイスの場合もあります) は現在の UI のみを使うレイアウトです。

これを実現するために、アダプティブな Visual State Manager 機能を使うことができます。 現在使っているテンプレートを利用して、既定で UI が幅の狭い状態でレイアウトされるように、視覚要素のプロパティを設定します。 その後で、アプリのウィンドウ幅が特定のサイズ以上になる状況を確認します (このサイズは[有効ピクセル](wpsl-to-uwp-porting-xaml-and-ui.md)の単位で測定します)。また、より大きなレイアウトやより幅の広いレイアウトを実現できるように、視覚要素のプロパティを変更します。 これらのプロパティの変更を表示状態として設定し、アダプティブなトリガーを使って、有効ピクセル単位のウィンドウ幅に応じて、その表示状態を適用するかどうかを継続的に監視し判断します。 この場合はウィンドウの幅でトリガーしていますが、ウィンドウの高さでトリガーすることもできます。

この使用事例では、ウィンドウの最小幅は 548 epx が適しています。これは、最も小型のデバイスで幅の広いレイアウトを表示する際に適したサイズであるためです。 通常、電話は 548 epx よりも小さいため、電話のような小型のデバイスでは既定の幅の狭いレイアウトをそのまま使います。 PC の既定では、ワイド状態への切り替えをトリガーできる十分な幅でウィンドウが開き、250 x 250 サイズの項目が表示されます。 この状態でウィンドウをドラッグして、250 x 250 サイズの項目を最低 2 列分は表示できる幅の狭いウィンドウにすることができます。 これよりも幅を狭くすると、トリガーが非アクティブ化されます。これにより、幅の広い表示状態が削除され、既定の幅の狭いレイアウトが有効になります。

アダプティブな Visual State Manager で作業する前に、まずワイド状態を設計する必要があります。つまり、マークアップに新しい視覚要素とテンプレートを追加することを意味します。 次の手順でその方法を説明します。 視覚要素およびテンプレートの命名規則として、ワイド状態用のすべての要素やテンプレートには、"wide" という単語を含めます。 要素またはテンプレートの名前に "wide" という単語が含まれていない場合、狭い状態の要素やテンプレートであると見なすことができます。これは、既定の状態であり、そのプロパティ値はページ内の視覚要素のローカル値として設定されます。 ワイド状態のプロパティ値のみが、マークアップ内の実際の表示状態によって設定されます。

-   マークアップ内の [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) コントロールのコピーを作成し、そのコピーで `x:Name="narrowSeZo"` を設定します。 元のコントロールでは、`x:Name="wideSeZo"` を設定し、既定ではワイド状態が表示されないように `Visibility="Collapsed"` も設定します。
-   `wideSeZo` で、拡大表示と縮小表示の両方の **ListView** を **GridView** に変更します。
-   3 つのリソース `AuthorGroupHeaderTemplate`、`ZoomedOutAuthorTemplate`、`BookTemplate` のコピーを作成し、コピーのキーに `Wide` という単語を追加します。 また、これらの新しいリソースのキーを参照するように、`wideSeZo` を更新します。
-   `AuthorGroupHeaderTemplateWide` の内容を `<TextBlock Style="{StaticResource SubheaderTextBlockStyle}" Text="{Binding Name}"/>` に置き換えます。
-   `ZoomedOutAuthorTemplateWide` の内容を次のように置き換えます。

```xml
    <Grid HorizontalAlignment="Left" Width="250" Height="250" >
        <Border Background="{StaticResource ListViewItemPlaceholderBackgroundThemeBrush}"/>
        <StackPanel VerticalAlignment="Bottom" Background="{StaticResource ListViewItemOverlayBackgroundThemeBrush}">
          <TextBlock Foreground="{StaticResource ListViewItemOverlayForegroundThemeBrush}"
              Style="{StaticResource SubtitleTextBlockStyle}"
            Height="80" Margin="15,0" Text="{Binding Group.Name}"/>
        </StackPanel>
    </Grid>
```

-   `BookTemplateWide` の内容を次のように置き換えます。

```xml
    <Grid HorizontalAlignment="Left" Width="250" Height="250">
        <Border Background="{StaticResource ListViewItemPlaceholderBackgroundThemeBrush}"/>
        <Image Source="{Binding CoverImage}" Stretch="UniformToFill"/>
        <StackPanel VerticalAlignment="Bottom" Background="{StaticResource ListViewItemOverlayBackgroundThemeBrush}">
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}"
                Foreground="{StaticResource ListViewItemOverlaySecondaryForegroundThemeBrush}"
                TextWrapping="NoWrap" TextTrimming="CharacterEllipsis"
                Margin="12,0,24,0" Text="{Binding Title}"/>
            <TextBlock Style="{StaticResource CaptionTextBlockStyle}" Text="{Binding Author.Name}"
                Foreground="{StaticResource ListViewItemOverlaySecondaryForegroundThemeBrush}" TextWrapping="NoWrap"
                TextTrimming="CharacterEllipsis" Margin="12,0,12,12"/>
        </StackPanel>
    </Grid>
```

-   ワイド状態では、拡大表示のグループ間の垂直方向の間隔を大きくする必要があります。 項目パネル テンプレートを作成し参照することで、必要な結果を得ることができます。 マークアップは次のようになります。

```xml
   <ItemsPanelTemplate x:Key="ZoomedInItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal" GroupPadding="0,0,0,20"/>
    </ItemsPanelTemplate>
    ...

    <SemanticZoom x:Name="wideSeZo" ... >
        <SemanticZoom.ZoomedInView>
            <GridView
            ...
            ItemsPanel="{StaticResource ZoomedInItemsPanelTemplate}">
            ...
```

-   最後に、適切な Visual State Manager のマークアップを `LayoutRoot` の最初の子として追加します。

```xml
    <Grid x:Name="LayoutRoot" ... >
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState x:Name="WideState">
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="548"/>
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="wideSeZo.Visibility" Value="Visible"/>
                        <Setter Target="narrowSeZo.Visibility" Value="Collapsed"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

    ...
```

## <a name="final-styling"></a>最終的なスタイル設定

残りの作業は、スタイルの最終的な調整です。

-   `AuthorGroupHeaderTemplate` で、**TextBlock** に対して `Foreground="White"` を設定します。これにより、モバイル デバイス ファミリで実行したときに適切に表示されます。
-   `AuthorGroupHeaderTemplate` と `ZoomedOutAuthorTemplate` の両方で、**TextBlock** に `FontWeight="SemiBold"` を追加します。
-   `narrowSeZo`で、縮小表示ビューでのグループ ヘッダーと著者は、伸縮表示ではなく左揃えで表示されます。ここではその設定を行います。 [**HorizontalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/br209417) を `Stretch` に設定して、拡大表示ビュー用の [**HeaderContainerStyle**](https://msdn.microsoft.com/library/windows/apps/dn251841) を作成します。 次に、同じ [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) を含む、縮小表示ビュー用の [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/br242817) を作成します。 結果は次のようになります。

```xml
   <Style x:Key="AuthorGroupHeaderContainerStyle" TargetType="ListViewHeaderItem">
        <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
    </Style>

    <Style x:Key="ZoomedOutAuthorItemContainerStyle" TargetType="ListViewItem">
        <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
    </Style>

    ...

    <SemanticZoom x:Name="narrowSeZo" ... >
        <SemanticZoom.ZoomedInView>
            <ListView
            ...
                <ListView.GroupStyle>
                    <GroupStyle
                    ...
                    HeaderContainerStyle="{StaticResource AuthorGroupHeaderContainerStyle}"
                    ...
        <SemanticZoom.ZoomedOutView>
            <ListView
                ...
                ItemContainerStyle="{StaticResource ZoomedOutAuthorItemContainerStyle}"
                ...
```

スタイル設定操作の最後のシーケンスで、アプリの外観は次のようになります。

![デスクトップ デバイスで動作中の、移植された Windows 10 アプリ (2 つのサイズのウィンドウによる拡大表示)](images/w8x-to-uwp-case-studies/c02-07-desk10-zi-ported.png)

デスクトップ デバイス、拡大表示ビュー、2 つのサイズのウィンドウで実行されている、移植された windows 10 アプリ 
![デスクトップ デバイス、縮小表示ビュー、2 つのサイズのウィンドウで実行されている、移植された windows 10 アプリ](images/w8x-to-uwp-case-studies/c02-08-desk10-zo-ported.png)

デスクトップ デバイス、縮小表示ビュー、2 つのサイズのウィンドウで実行されている、移植された windows 10 アプリ

![モバイル デバイスで動作中の、移植された Windows 10 アプリ (拡大表示)](images/w8x-to-uwp-case-studies/c02-09-mob10-zi-ported.png)

拡大表示ビューのモバイル デバイスで実行されている、移植された windows 10 アプリ

![モバイル デバイスで動作中の、移植された Windows 10 アプリ (縮小表示)](images/w8x-to-uwp-case-studies/c02-10-mob10-zo-ported.png)

縮小表示のモバイル デバイスで実行されている、移植された windows 10 アプリ

## <a name="making-the-view-model-more-flexible"></a>ビュー モデルの柔軟性の向上

このセクションでは、UWP を使うようにアプリを移行することによって利用可能になる機能の例を紹介します。 ここでは、**CollectionViewSource** を使ってアクセスするときにビュー モデルの柔軟性を向上させるために実行できるオプションの手順について説明します。 ビュー モデル (ソース ファイルは ViewModel\\BookstoreViewModel.cs) から派生した Author という名前のクラスを含む WindowsPhone Silverlight アプリ Bookstore2WPSL8 からに移植します**一覧&lt;T&gt;**、 **T**は BookSku します。 これは、Author クラスが BookSku の*グループである*ことを意味します。

**CollectionViewSource.Source** を Authors にバインドするとき、Authors 内の各 Author が*何か*のグループであるということを伝える必要があります。 このケース スタディでは、**CollectionViewSource** に依存して、Author が BookSku のグループであることを特定しています。 この設定でも機能しますが、柔軟性はありません。 Author が BookSku のグループ*および*著者の住所のグループの*両方*を表す必要がある場合は、どうしたらよいでしょうか。 Author を、これらの両方のグループにすることは*できません*。 ただし、Author に任意の数のグループを*保持させる*ことはできます。 これが解決策となります。つまり、現在使っている "*グループである*" というパターンの代わりに、またはこのパターンに加えて、"*グループを保持する*" というパターンを使います。 以下にその方法を示します。

-   Author が **List&lt;T&gt;** から派生しないように変更します。
-   次のフィールドを Author に追加します: `private ObservableCollection<BookSku> bookSkus = new ObservableCollection<BookSku>();`。
-   次のプロパティを Author に追加します: `public ObservableCollection<BookSku> BookSkus { get { return this.bookSkus; } }`。
-   当然ですが、上の 2 つの手順を繰り返して、必要な数のグループを Author に追加できます。
-   AddBookSku メソッドの実装を `this.BookSkus.Add(bookSku);` に変更します。
-   これで、Author は少なくとも 1 つのグループを*保持する*ようになりました。また、**CollectionViewSource** に対して、どのグループを使うかを伝える必要があります。 そのためには、**CollectionViewSource** に次のプロパティを追加します。 `ItemsPath="BookSkus"`

これらの変更を行っても、このアプリの機能は変更されません。ここでは、必要に応じて Author と **CollectionViewSource** を拡張する方法を理解してください。 Author に対して最後の変更を加えましょう。この変更により、**CollectionViewSource.ItemsPath** を指定*しないで* Author を使う場合に、選んだ既定のグループが使われるようになります。

```csharp
    public class Author : IEnumerable<BookSku>
    {
        ...

        public IEnumerator<BookSku> GetEnumerator()
        {
            return this.BookSkus.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.BookSkus.GetEnumerator();
        }
    }
```

これで、アプリが同じように動作を続ける場合は、必要に応じて `ItemsPath="BookSkus"` を削除できます。

## <a name="conclusion"></a>まとめ

このケース スタディには、前のケース スタディよりも複雑なユーザー インターフェイスが関連しています。 すべての機能と WindowsPhone Silverlight の **LongListSelector**の概念- 度を高める- **SemanticZoom**、 **ListView**、 **GridView**、および**CollectionViewSource**の形式での UWP アプリを利用できることが検出されました。 UWP アプリで命令型コードやマークアップの両方を再利用 (コピーと編集) して、最小および最大の Windows デバイスのフォーム ファクターや、その中間のあらゆるサイズに合わせて調整された機能、UI、および操作を実現する方法について説明しました。
