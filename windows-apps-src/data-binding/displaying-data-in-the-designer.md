---
author: mcleblanc
ms.assetid: 089660A2-7CAE-4911-9994-F619C5D22287
title: デザイン サーフェイス上のサンプル データとプロトタイプを作るためのサンプル データ
description: アプリで Microsoft Visual Studio や Blend for Visual Studio のデザイン サーフェイスにライブ データを表示できない場合や、プライバシーやパフォーマンスなどの理由で表示するのが望ましくない場合があります。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 269d51ec6005bcd61ac01a66d72c34bdb2901add
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5812114"
---
<a name="sample-data-on-the-design-surface-and-for-prototyping"></a>デザイン サーフェイス上のサンプル データとプロトタイプを作るためのサンプル データ
=============================================================================================



**注:** 度のサンプル データする必要があります: し、どの程度するに役立ちます-、バインディングが[{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)または[{X:bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)を使用するかどうかによって異なります。 ここで説明する手法は [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) の使用に基づいているため、この手法が適しているのは **{Binding}** のみですが、 **{x:Bind}** を使う場合は、バインドで少なくともプレースホルダー値がデザイン サーフェイスに表示されるため (項目コントロールの場合でも)、サンプル データの必要性は比較的低くなります。

アプリで Microsoft Visual Studio や Blend for Visual Studio のデザイン サーフェイスにライブ データを表示できない場合や、プライバシーやパフォーマンスなどの理由で表示するのが望ましくない場合に、 アプリのレイアウト、テンプレート、その他の視覚的なプロパティを操作するためにコントロールにデータを設定するには、さまざまな方法で設計時のサンプル データを使うことができます。 サンプル データは、スケッチ (プロトタイプ) アプリを開発する場合にも便利で、時間の節約になります。 スケッチやプロトタイプで実行時にサンプル データを使うと、実際のライブ データに接続しなくてもアイデアを実証できます。

**{Binding} の使い方を示すサンプル アプリ**

-   [Bookstore1](http://go.microsoft.com/fwlink/?linkid=532950) アプリのダウンロード。
-   [Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) アプリのダウンロード。

<a name="setting-datacontext-in-markup"></a>マークアップでの DataContext の設定
-----------------------------

命令型コードを (分離コードで) 使ってページやユーザー コントロールの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) をビュー モデル インスタンスに設定するのはごく一般的な開発手法です。

``` csharp
public MainPage()
{
    InitializeComponent();
    this.DataContext = new BookstoreViewModel();
}
```

しかし、この方法を使うとページの "デザイン性" が低下します。 これは、XAML ページを Visual Studio や Blend for Visual Studio で開いても、**DataContext** の値を割り当てる命令型コードは実行されないからです (分離コードは一切実行されません)。 もちろん、XAML ツールによってマークアップが解析され、宣言されているオブジェクトがインスタンス化されますが、ページの型そのものはインスタンス化されません。 その結果、コントロールや **[データ バインディングの作成]** ダイアログにデータが表示されず、ページのスタイルやレイアウトの設定が困難になります。

![デザイン性の乏しい UI。](images/displaying-data-in-the-designer-01.png)

この問題を解決するための最初の方法では、その **DataContext** の割り当てをコメント アウトして、代わりにページのマークアップで **DataContext** を設定します。 これにより、実行時だけでなく設計時にもライブ データが表示されるようになります。 これを行うには、まず、XAML ページを開きます。 次に、**[ドキュメント アウトライン]** ウィンドウでルート デザイン要素 (通常は **\[Page\]** というラベルが付いています) をクリックして選択します。 **[プロパティ]** ウィンドウで **[DataContext]** プロパティを見つけて ([共通] カテゴリにあります)、**[新規]** をクリックします。 **[オブジェクトの選択]** ダイアログ ボックスで目的のビュー モデルの種類をクリックし、**[OK]** をクリックします。

![DataContext を設定するための UI。](images/displaying-data-in-the-designer-02.png)

結果のマークアップは次のようになります。

``` xaml
<Page ... >
    <Page.DataContext>
        <local:BookstoreViewModel/>
    </Page.DataContext>
```

これでバインドが解決されるようになったため、デザイン サーフェイスが次のようになります。 **[データ バインディングの作成]** ダイアログの **[パス]** ボックスに値が設定されています。これらは、**DataContext** 型と、バインドできるプロパティに基づいています。

![デザイン性の高い UI。](images/displaying-data-in-the-designer-03.png)

**[データ バインディングの作成]** ダイアログに必要なのは基になる型だけですが、バインドではプロパティの値を初期化する必要があります。 パフォーマンス、データ転送費用、プライバシーなどの問題で設計時にクラウド サービスにアクセスしたくない場合は、アプリがデザイン ツール (Visual Studio、Blend for Visual Studio など) で実行されているかを初期化コードでチェックして、実行されている場合は設計時専用のサンプル データを読み込みます。

``` csharp
if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
{
    // Load design-time books.
}
else
{
    // Load books from a cloud service.
}
```

初期化コードにパラメーターを渡す必要がある場合は、ビュー モデル ロケーターを使うことができます。 ビュー モデル ロケーターとは、アプリ リソースに配置することができるクラスです。 このクラスにはビュー モデルを公開するプロパティがあるので、そのプロパティにページの **DataContext** をバインドします。 ロケーターやビュー モデルで使うことができるもう 1 つのパターンは依存関係挿入です。依存関係挿入では、設計時または実行時のデータ プロバイダーを必要に応じて作成できます (それぞれ共通のインターフェイスを実装します)。

<a name="sample-data-from-class-and-design-time-attributes"></a>"クラスからのサンプル データ" と設計時属性
---------------------------------------------------------------------------------------

なんらかの理由で前のセクションのいずれの方法でも問題を解決できない場合でも、XAML ツールの機能と設計時属性を使ってさまざまな方法で設計時のデータを利用できます。 その 1 つが、Blend for Visual Studio の **[クラスからのサンプル データの作成]** 機能です。 このコマンドのボタンは **[データ]** パネルの上部にあります。

必要な作業は、このコマンドで使うクラスを指定することだけです。 クラスを指定すると、重要なことが 2 つ行われます。 まず、選んだクラスのインスタンスとそのすべてのメンバーを再帰的にハイドレートするために適したサンプル データを含む XAML ファイルが生成されます (このツールは、XAML ファイルでも JSON ファイルでも適切に機能します)。 次に、選んだクラスのスキーマが **[データ]** パネルに設定されます。 これにより、**[データ]** パネルからデザイン サーフェイスにメンバーをドラッグしてさまざまなタスクを実行できるようになります。 何をどこにドラッグするかによって、既にあるコントロールにバインドを追加することも (**{Binding}** を使用)、新しいコントロールの作成とバインドを同時に行うこともできます。 どちらの場合も、ページのレイアウト ルートに設計時のデータ コンテキスト (**d:DataContext**) も設定されます (まだ設定されていない場合)。 その設計時のデータ コンテキストが、**d:DesignData** 属性を使って、生成された XAML ファイルからサンプル データを取得します (なお、その XAML ファイルをプロジェクト内で見つけて、必要なサンプル データを含むように編集することもできます)。

``` xaml
<Page ...
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">
    <Grid ... d:DataContext="{d:DesignData /SampleData/RecordingViewModelSampleData.xaml}"/>
        <ListView ItemsSource="{Binding Recordings}" ... />
        ...
    </Grid>
</Page>
```

さまざまな xmlns 宣言がありますが、これらは、**d:** プレフィックスの付いた属性は設計時にのみ解釈され、実行時には無視されることを表しています。 したがって、**d:DataContext** 属性が [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) プロパティの値に影響するのは設計時のみで、実行時には影響しません。 必要であれば、**d:DataContext** と **DataContext** の両方をマークアップで設定することもできます。 その場合、設計時には **d:DataContext** が優先され、実行時には **DataContext** が優先されます。 この規則は、すべての設計時属性と実行時属性に適用されます。

**d:DataContext** 属性およびその他のすべての設計時属性について詳しくは、[設計時の属性に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=272504)をご覧ください。このページは、ユニバーサル Windows プラットフォーム (UWP) アプリに対しても有効です。

[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) には **DataContext** プロパティはありませんが、**Source** プロパティがあります。 そのため、**CollectionViewSource** に設計時専用のサンプル データを設定するために使うことができる **d:Source** プロパティがあります。

``` xaml
    <Page.Resources>
        <CollectionViewSource x:Name="RecordingsCollection" Source="{Binding Recordings}"
            d:Source="{d:DesignData /SampleData/RecordingsSampleData.xaml}"/>
    </Page.Resources>

    ...

        <ListView ItemsSource="{Binding Source={StaticResource RecordingsCollection}}" ... />
    ...
```

このコードが機能するためには、`Recordings : ObservableCollection<Recording>` というクラスが必要です。また、サンプル データの XAML ファイルを編集して、**Recordings** オブジェクト (**Recording** オブジェクトを含む) のみが含まれるようにする必要があります。次に例を示します。

``` xml
<Quickstart:Recordings xmlns:Quickstart="using:Quickstart">
    <Quickstart:Recording ArtistName="Mollis massa" CompositionName="Cubilia metus"
        OneLineSummary="Morbi adipiscing sed" ReleaseDateTime="01/01/1800 15:53:17"/>
    <Quickstart:Recording ArtistName="Vulputate nunc" CompositionName="Parturient vestibulum"
        OneLineSummary="Dapibus praesent netus amet vestibulum" ReleaseDateTime="01/01/1800 15:53:17"/>
    <Quickstart:Recording ArtistName="Phasellus accumsan" CompositionName="Sit bibendum"
        OneLineSummary="Vestibulum egestas montes dictumst" ReleaseDateTime="01/01/1800 15:53:17"/>
</Quickstart:Recordings>
```

XAML ではなく JSON のサンプル データ ファイルを使う場合は、**Type** プロパティを設定する必要があります。

``` xaml
    d:Source="{d:DesignData /SampleData/RecordingsSampleData.json, Type=local:Recordings}"
```

これまでは、**d:DesignData** を使って設計時のサンプル データを XAML ファイルや JSON ファイルから読み込む方法を説明しました。 そのほかに、**d:DesignInstance** マークアップ拡張を使う方法もあります。このマークアップ拡張は、設計時ソースが **Type** プロパティによって指定されるクラスに基づくことを示します。 次に例を示します。

``` xaml
    <CollectionViewSource x:Name="RecordingsCollection" Source="{Binding Recordings}"
        d:Source="{d:DesignInstance Type=local:Recordings, IsDesignTimeCreatable=True}"/>
```

**IsDesignTimeCreatable** プロパティは、デザイン ツールがこのクラスのインタンスを実際に作成する必要があることを示します。したがって、このクラスにはパブリックの既定のコンストラクターがあり、そのコンストラクターにデータ (実際のデータかサンプル データ) が設定されることがわかります。 **IsDesignTimeCreatable** を設定しない場合 (または **False** に設定した場合) は、デザイン サーフェイスに表示されるサンプル データは取得されません。 デザイン ツールでは、その場合は、そのバインド可能なプロパティのクラスを解析し、**データ**パネルで、**データ バインディングの作成**] ダイアログ ボックスが表示することだけです。

<a name="sample-data-for-prototyping"></a>プロトタイプを作るためのサンプル データ
--------------------------------------------------------

プロトタイプを作るには、設計時と実行時の両方でサンプル データが必要です。 そのような場合のために、Blend for Visual Studio には **[新しいサンプル データ]** 機能が用意されています。 このコマンドのボタンは **[データ]** パネルの上部にあります。

クラスを指定する代わりに、**[データ]** パネルで直接サンプル データ ソースのスキーマを設計できます。 **[データ]** パネルでサンプル データの値を編集することもできます。ファイルを開いて編集する必要はありません (必要であればそうすることもできます)。

**[新しいサンプル データ]** 機能は、**d:DataContext** ではなく [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) を使うため、スケッチやプロトタイプの設計時だけでなく実行時にもサンプル データを使うことができます。 また、**[データ]** パネルにより、設計とバインドの作業が大幅に高速化されます。 たとえば、コレクション プロパティを **[データ]** パネルからデザイン サーフェイスにドラッグするだけで、データがバインドされた項目コントロールと必要なテンプレートが生成されて、すぐにビルドして実行できるようになります。

![プロトタイプを作るためのサンプル データ。](images/displaying-data-in-the-designer-04.png)
