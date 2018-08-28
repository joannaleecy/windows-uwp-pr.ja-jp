---
author: Jwmsft
Description: You create the UI for your app by using controls such as buttons, text boxes, and combo boxes to display data and get user input. Here, we show you how to add controls to your app.
title: コントロールとパターンの概要
ms.assetid: 64740BF2-CAA1-419E-85D1-42EE7E15F1A5
label: Intro to controls and patterns
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6f8f86a6988e68e3ff8d2dfef32512633b3761fd
ms.sourcegitcommit: 9a17266f208ec415fc718e5254d5b4c08835150c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2018
ms.locfileid: "2882575"
---
# <a name="intro-to-controls-and-patterns"></a>コントロールとパターンの概要

UWP アプリ開発では、*コントロール*は、コンテンツを表示したり、操作を有効にしたりする UI 要素です。 ボタン、テキスト ボックス、コンボ ボックスなどのコントロールを使って、データを表示し、ユーザー入力を取得するためのアプリの UI を作ります。

> **重要な API**: [Windows.UI.Xaml.Controls 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.aspx)

*パターン*とは、コントロールを変更するか、いくつかのコントロールを組み合わせて、新しいものを作成するためのレシピです。 たとえば、[マスター/詳細](master-details.md)パターンは、アプリのナビゲーションの[SplitView](split-view.md)コントロールを使用するには、方法です。 同様に、タブの [パターンを実装する[NavigationView](navigationview.md)コントロールのテンプレートをカスタマイズすることができます。

多くの場合、コントロールはそのまま使用できます。 ただし、XAML コントロールでは、機能が構造や外観とは分離されているため、ニーズに合わせてさまざまなレベルで変更することができます。 [XAML スタイル](xaml-styles.md)と[コントロール テンプレート](control-templates.md)を使用してコントロールを変更する方法については、「[スタイル](../style/index.md)」セクションをご覧ください。

このセクションでは、アプリ UI の構築に使用できる各 XAML コントロールに関するガイダンスを提供します。 まず、この記事では、アプリにコントロールを追加する方法について説明します。 アプリでコントロールを使用するには、次の 3 つの重要な手順があります。

- アプリの UI にコントロールを追加します。
- 幅、高さ、前景色など、コントロールのプロパティを設定します。
- 動作を行うためのコードをコントロールに追加します。 

## <a name="add-a-control"></a>コントロールの追加
アプリにコントロールを追加するには、いくつかの方法があります。
 
- Blend for Visual Studio や Microsoft Visual Studio Extensible Application Markup Language (XAML) デザイナーなどのデザイン ツールを使用する。 
- Visual Studio XAML エディターで XAML マークアップにコントロールを追加する。 
- コードでコントロールを追加する。 コードで追加するコントロールは、アプリを実行するときには表示されますが、Visual Studio XAML デザイナーでは表示されません。

Visual Studio でアプリにコントロールを追加して操作するときには、[ツールボックス]、XAML デザイナー、XAML エディター、[プロパティ] ウィンドウなど、Visual Studio の多くの機能を利用できます。 

Visual Studio の [ツールボックス] には、アプリで使用できる多くのコントロールが表示されます。 コントロールをアプリに追加するには、[ツールボックス] でそのコントロールをダブルクリックします。 たとえば、TextBox コントロールをダブルクリックすると、この XAML が [XAML] ビューに追加されます。 

```xaml
<TextBox HorizontalAlignment="Left" Text="TextBox" VerticalAlignment="Top"/>
```

また、コントロールを [ツールボックス] から XAML デザイナーにドラッグすることもできます。

## <a name="set-the-name-of-a-control"></a>コントロールの名前の設定

コントロールをコードで操作する場合は、コントロールの [x:Name](../../xaml-platform/x-name-attribute.md) 属性を設定し、コードでは名前でコントロールを参照します。 名前は、Visual Studio の [プロパティ] ウィンドウまたは XAML で設定できます。 以下では、[プロパティ] ウィンドウの上部にある [名前] ボックスを使って、現在選択されているコントロールの名前を設定する方法を示しています。

コントロールに名前を付けるには
1. 名前を付ける要素を選びます。
2. [プロパティ] パネルで、[名前] ボックスに名前を入力します。
3. Enter キーを押して、名前をコミットします。

![Visual Studio デザイナーでの Name プロパティ](images/add-controls-control-name-designer.png)

XAML エディターで x:Name 属性を追加してコントロールの名前を設定する方法を示します。

```xaml
<Button x:Name="Button1" Content="Button"/>
```

## <a name="set-the-control-properties"></a>コントロールのプロパティの設定 

プロパティを使って、コントロールの外観、内容、その他の属性を指定します。 デザイン ツールを使ってコントロールを追加すると、Visual Studio によってサイズ、位置、コンテンツを制御するプロパティが設定されることがあります。 Width、Height、Margin など、いくつかのプロパティは、[デザイン] ビューでコントロールを選んで操作することで変更できます。 次の図は、[デザイン] ビューで使用できるサイズ変更ツールの一部を示しています。 

![Visual Studio デザイナーでのサイズ変更ツール](images/add-controls-resizing-designer.png)

コントロールのサイズと位置が自動的に調整されることが望ましいということも考えられます。 この場合、Visual Studio によって設定されるサイズと位置に関するプロパティをリセットできます。

プロパティをリセットするには
1. [プロパティ] パネルで、プロパティ値の横のプロパティ マーカーをクリックします。 プロパティ メニューが開きます。
2. プロパティ メニューで、[リセット] をクリックします。

![Visual Studio のプロパティ メニューのリセット オプション](images/add-controls-property-reset.png)

コントロールのプロパティは、[プロパティ] ウィンドウ、XAML、またはコードで設定できます。 たとえば、Button の前景色を変更するには、コントロールの Foreground プロパティを設定します。 次の図は、[プロパティ] ウィンドウのカラー ピッカーを使って Foreground プロパティを設定する方法を示しています。 

![Visual Studio デザイナーでのカラー ピッカー](images/add-controls-foreground-designer.png)

次に、XAML エディターの Foreground プロパティを設定する方法を示します。 構文の入力を簡単にするために、Visual Studio の IntelliSense ウィンドウが開いています。 

![XAML での Intellisense パート 1](images/add-controls-foreground-xaml.png)

![XAML での Intellisense パート 2](images/add-controls-foreground-xaml-2.png)

Foreground プロパティを設定した後の結果の XAML を次に示します。 

```xaml
<Button x:Name="Button1" Content="Button" 
        HorizontalAlignment="Left" VerticalAlignment="Top"
        Foreground="Beige"/>
```

次に、Foreground プロパティをコードで設定する方法を示します。 

```csharp
Button1.Foreground = new SolidColorBrush(Windows.UI.Colors.Beige);
```

## <a name="create-an-event-handler"></a>イベント ハンドラーの作成 

各コントロールには、ユーザーの操作またはアプリ内での他の変更に対して応答するためのイベントが用意されています。 たとえば、Button コントロールには、ユーザーがボタンをクリックしたときに発生する Click イベントがあります。 イベントを処理するために、イベント ハンドラーと呼ばれるメソッドを作成します。 [プロパティ] ウィンドウでは、XAML またはコードでイベント ハンドラー メソッドとコントロールのイベントを関連付けることができます。 イベントについて詳しくは、「[イベントとルーティング イベントの概要](../../xaml-platform/events-and-routed-events-overview.md)」をご覧ください。

イベント ハンドラーを作成するには、コントロールを選んだ後、[プロパティ] ウィンドウの上部にある [イベント] タブをクリックします。 [プロパティ] ウィンドウに、そのコントロールに対して利用可能なすべてのイベントの一覧が表示されます。 Button のイベントの一部を次に示します。

![Visual Studio のイベント一覧](images/add-controls-add-event-designer.png)

イベント ハンドラーを既定の名前で作成するには、[プロパティ] ウィンドウ内でイベント名の横にあるテキスト ボックスをダブルクリックします。 イベント ハンドラーをカスタム名で作成するには、テキスト ボックスに名前を入力して Enter キーを押します。 イベント ハンドラーが作成され、コード ビハインド ファイルがコード エディターで開きます。 イベント ハンドラーのメソッドには、パラメーターが 2 つあります。 1 つが `sender` です。これは、ハンドラーがアタッチされているオブジェクトへの参照です。 `sender` パラメーターは **Object** 型です。 `sender` オブジェクト自体で状態を確認または変更する必要がある場合には、通常、`sender` をもっと正確な型にキャストします。 それぞれのアプリ設計に基づき、`sender` のキャスト先として安全な型をハンドラーのアタッチ先を基に把握する必要があります。 2 つ目の値はイベント データです。これは通常、`e` パラメーターまたは `args` パラメーターとしてシグネチャに表示されます。

`Button1` という名前が付いた Button の Click イベントを処理するコードを以下に示します。 ボタンをクリックすると、クリックした Button の Foreground プロパティが青色に設定されます。 

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    Button b = (Button)sender;
    b.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);
}
```

また、イベント ハンドラーを XAML で関連付けることもできます。 XAML エディターで、処理するイベント名を入力します。 入力を始めると、Visual Studio に IntelliSense ウィンドウが表示されます。 イベントを指定した後は、IntelliSense ウィンドウで `<New Event Handler>` をダブルクリックして新しいイベント ハンドラーを既定の名前で作成するか、一覧から既にあるイベント ハンドラーを選びます。 

表示される IntelliSense ウィンドウを次に示します。 IntelliSense ウィンドウは、新しいイベント ハンドラーを作成したり、既存のイベント ハンドラーを選択するのに役立ちます。

![クリック イベント用の Intellisense](images/add-controls-add-event-xaml.png)

次の例では、XAML で Click イベントを Button_Click という名前のイベント ハンドラーと関連付ける方法を示しています。 

```xaml
<Button Name="Button1" Content="Button" Click="Button_Click"/>
```

イベントは、コード ビハインド内でイベント ハンドラーに関連付けることもできます。 イベント ハンドラーをコードで関連付ける方法を次に示します。

```csharp
Button1.Click += new RoutedEventHandler(Button_Click);
```

## <a name="related-topics"></a>関連トピック

-   [機能別コントロールのインデックス](controls-by-function.md)
-   [Windows.UI.Xaml.Controls 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.aspx)
-   [レイアウト](../layout/index.md)
-   [スタイル](../style/index.md)
-   [ユーザビリティ](../usability/index.md)
