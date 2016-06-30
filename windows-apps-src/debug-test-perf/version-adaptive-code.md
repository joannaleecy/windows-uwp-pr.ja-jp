---
author: jwmsft
title: "バージョン アダプティブ コード"
description: "以前のバージョンとの互換性を維持しつつ、新しい API を利用する方法について説明します"
translationtype: Human Translation
ms.sourcegitcommit: 3f81d80cef0fef6d24cad1b42ce9726b03857b5a
ms.openlocfilehash: db6b9c83d36ac876661197dce81e5724e44bb640

---

# バージョン アダプティブ コード: 以前のバージョンとの互換性を維持しつつ新しい API を使う

Windows 10 SDK の各リリースには、ユーザーが利用したくなるような魅力的な新機能が追加されています。 ただし、すべてのユーザーがデバイスを最新バージョンの Windows 10 に同時に更新するわけではないため、できるだけ幅広いデバイスでアプリが動作するようにする必要があります。 ここでは、アプリが以前のバージョンの Windows 10 で動作するだけでなく、最新の更新プログラムがインストールされたデバイスでアプリを実行したときに新機能を利用できるように、アプリを設計する方法について説明します。

アプリができるだけ幅広い Windows 10 デバイスをサポートするようにするには、2 つの手順を実行します。 まず、最新の API を対象とするように Visual Studio プロジェクトを構成します。 これは、アプリをコンパイルするときの処理に影響します。 次に、ランタイム チェックを実行して、アプリが実行されているデバイスに存在する API のみを呼び出すことを確認します。

> [!NOTE] 
> この記事では、Windows 10 バージョン 1607 (Anniversary Update) 用 Windows Insider Preview SDK の例を使います。 Preview SDK はプレリリース版なので、運用環境では使うことができません。 SDK をインストールするのは、テスト コンピューターのみにしてください。 Preview SDK には API サーフェス領域に対するバグ修正と開発過程での変更点が含まれています。 ストアに提出する必要があるアプリケーションに取り組んでいる場合は、プレビュー版をインストールしないでください。

## Visual Studio プロジェクトを構成する

複数の Windows 10 バージョンをサポートするための最初の手順は、Visual Studio プロジェクトで、サポートされる*ターゲット*と*最小*の OS/SDK バージョンを指定することです。
- *ターゲット*: Visual Studio がアプリ コードをコンパイルし、すべてのツールを実行する際に対象となる SDK バージョン。 この SDK バージョンに含まれているすべての API とリソースは、コンパイル時にアプリ コードで使うことができます。
- *最小*: アプリを実行できる (ストアからの展開先となる) 以前の OS バージョンと、Visual Studio がアプリ マークアップ コードをコンパイルする際に対象となるバージョンをサポートする SDK バージョン。 

実行時には展開先の OS バージョンに対してアプリが実行されるため、そのバージョンで利用できないリソースを使ったり、そのような API を呼び出したりすると、アプリによって例外がスローされます。 ランタイム チェックを使って適切な API を呼び出す方法については、この記事の後半で説明します。

ターゲットと最小の設定では、OS/SDK バージョンの範囲の両端を指定します。 ただし、最小バージョンでアプリをテストした場合、最小とターゲット間のすべてのバージョンでアプリが実行されるようになります。

> [!TIP]
> Visual Studio では API の互換性についての警告は表示されません。 ご自身の責任で最小とターゲットの間にあるすべての OS バージョン (最小とターゲットのバージョンを含む) でアプリが期待どおりに実行されることをテストし、確認してください。

Visual Studio 2015 Update 2 以降で新しいプロジェクトを作成すると、アプリがサポートしているターゲット バージョンと最小バージョンを設定するように求められます。 既定では、ターゲット バージョンはインストール済みの SDK の中で最も高いバージョンで、最小バージョンはインストール済みの SDK バージョンの中で最も低いバージョンです。 コンピューターにインストールされている SDK バージョンからのみ、ターゲットと最小を選ぶことができます。 

![Visual Studio でターゲット SDK を設定する](images/vs-target-sdk-1.png)

通常、既定値のままにすることをお勧めします。 ただし、SDK のプレビュー版をインストールしていて、運用コードを記述している場合、ターゲット バージョンを Preview SDK から最新の公式の SDK バージョンに変更する必要があります。 

Visual Studio で既に作成済みのプロジェクトの最小バージョンとターゲット バージョンを変更するには、[プロジェクト]、[プロパティ]、[アプリケーション] タブ、[ターゲット] の順に移動します。

![Visual Studio でターゲット SDK を変更する](images/vs-target-sdk-2.png) 

参考までに、各 SDK には次のようにビルド番号があります:
- Windows 10 バージョン 1506: SDK バージョン 10240
- Windows 10 バージョン 1511 (11 月の更新プログラム): SDK バージョン 10586
- Windows 10 バージョン 1607 Insider Preview (Anniversary Update): 現時点では、[最新の Insider Preview SDK バージョンは 14332](https://blogs.windows.com/buildingapps/2016/04/28/windows-10-anniversary-sdk-preview-build-14332-released/) です。

SDK のすべてのリリース版は、「[Windows SDK とエミュレーターのアーカイブ](https://developer.microsoft.com/downloads/sdk-archive)」からダウンロードできます。 最新の Windows Insider Preview SDK は、[Windows Insider](https://insider.windows.com/) サイトの「開発者向け」セクションからダウンロードできます。

## アダプティブ コードを記述する

アダプティブ コードの記述については、[アダプティブ UI の作成](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml)についての考え方と同じように考えることができます。 最小画面で実行するように基本 UI を設計し、より大きな画面でアプリが実行されていることを検出したときに要素を移動または追加できます。 アダプティブ コードの場合、最小の OS バージョンで実行するように基本コードを記述し、新機能が提供されているより高いバージョンでアプリが実行されていることを検出したときに、機能を手動で選んで追加できます。

### ランタイム API チェック

呼び出す API が存在するかどうかをテストするために、コードの条件で [Windows.Foundation.Metadata.ApiInformation](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.aspx) クラスを使います。 このテストの条件は、アプリの実行時に必ず評価されますが、API が存在するデバイスに対してのみ **true** と評価され、呼び出しが可能になります。 そのため、特定の OS バージョンでのみ利用できる API を使うアプリを作成するには、バージョン アダプティブ コードを記述できます。

ここでは、Windows Insider Preview の新機能を対象にするための具体的な例を示します。 **ApiInformation** を使う場合の一般的な概要については、[UWP アプリのガイド](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)と [API コントラクトを使った機能の動的な検出に関するブログの投稿](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)をご覧ください。

> [!TIP]
> さまざまなランタイム API チェックが、アプリのパフォーマンスに影響する可能性があります。 それらの例では、チェックをインラインで示します。 運用コードでは、チェックを一度実行してから結果をキャッシュし、キャッシュされた結果をアプリ全体で使う必要があります。 

### サポートされていないシナリオ

ほとんどの場合、アプリの最小バージョンを SDK バージョン 10240 に設定したままにし、アプリがそれより新しいバージョンで実行されたときに、ランタイム チェックを使って新しい API を有効にすることができます。 ただし、新機能を使うためにアプリの最小バージョンを上げることが必要になる場合もあります。

アプリの最小バージョンを上げる必要があるのは、以下を使う場合です。
- 以前のバージョンでは使うことができない機能を必要とする新しい API。 サポートされる最小バージョンを、その機能が含まれているバージョンに上げる必要があります。 詳しくは、「[アプリ機能の宣言](../packaging/app-capability-declarations.md)」をご覧ください。
- generic.xaml に追加された新しいリソース キーのうち、以前のバージョンでは使うことができないリソース キー。 実行時に使われる generic.xaml のバージョンは、デバイスで実行されている OS バージョンによって決まります。 ランタイム API チェックを使って XAML リソースの有無を確認することはできません。 そのため、アプリがサポートする最小バージョンで利用できるリソース キーのみを使う必要があります。そうしないと、[XAMLParseException](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.markup.xamlparseexception.aspx) が原因で実行時にアプリがクラッシュします。

### アダプティブ コードのオプション

アダプティブ コードを作成するには 2 つの方法があります。 ほとんどの場合、アプリのマークアップを最小バージョンで実行するように記述してから、アプリ コードを使ってより新しい OS 機能 (存在する場合) を活用します。 ただし、表示状態でプロパティを更新する必要があり、OS バージョン間でプロパティ値と列挙値の変更のみがある場合、API の存在に基づいてアクティブ化される拡張可能な状態トリガーを作成できます。

ここで、以下のオプションを比較します。

**アプリケーション コード**

使う状況:
- すべてのアダプティブ コード シナリオにお勧めします。ただし、拡張可能なトリガー用に以下に定義されている特定のケースは除きます。

利点:
- API の相違をマークアップに結び付ける際の開発者のオーバーヘッドや複雑さを回避できます。

欠点:
- デザイナーがサポートされていません。

**状態トリガー**

使う状況:
- OS バージョン間で、ロジックを変更する必要のない、表示状態に関連付けられているプロパティまたは列挙値のみに変更がある場合に使います。

利点:
- API の存在に基づいてトリガーされる特定の表示状態を作成できます。
- 一部のデザイナー サポートを利用できます。

欠点:
- カスタム トリガーの使用は表示状態に限定されるため、複雑なアダプティブ レイアウトには適していません。
- セッターを使って値の変更を指定する必要があるため、単純な変更だけを行うことができます。
- カスタム状態トリガーを設定して使うには、非常に細かい設定が必要です。

## アダプティブ コードの例

このセクションでは、Windows 10 バージョン 1607 (Windows Insider Preview) で新しく追加された API を使うアダプティブ コードの例をいくつか示します。

### 例 1: 新しい列挙値

Windows 10 バージョン 1607 では、[InputScopeNameValue](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.inputscopenamevalue.aspx) 列挙体に新しい値 **ChatWithoutEmoji** が追加されています。 この新しい入力スコープの入力動作は、**Chat** 入力スコープ (スペルチェック、オートコンプリート、大文字の自動設定) と同じですが、絵文字ボタンのないタッチ キーボードにマップされます。 これは、独自の絵文字ピッカーを作成し、タッチ キーボードに組み込まれている絵文字ボタンを無効にする場合に便利です。 

次の例は、**ChatWithoutEmoji** 列挙値が存在するかどうかを確認し、存在する場合は **TextBox** の [InputScope](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを設定する方法を示しています。 アプリが実行されているシステムにこの列挙値が存在しない場合、**InputScope** は **Chat** に設定されます。 ここに示されているコードは、Page コンストラクターまたは Page.Loaded イベント ハンドラーに配置できます。

> [!TIP]
> API をチェックするときは、.NET 言語機能を使うのではなく静的な文字列を使います。そうしないと、アプリは定義されていない型にアクセスしようとして、実行時にクラッシュすることがあります。

**C#**
```csharp
// Create a TextBox control for sending messages 
// and initialize an InputScope object.
TextBox messageBox = new TextBox();
messageBox.AcceptsReturn = true;
messageBox.TextWrapping = TextWrapping.Wrap;
InputScope scope = new InputScope();
InputScopeName scopeName = new InputScopeName();

// Check that the ChatWithEmoji value is present.
// (It's present starting with Windows 10, version 1607,
//  the Target version for the app. This check returns false on earlier versions.)         
if (ApiInformation.IsEnumNamedValuePresent("Windows.UI.Xaml.Input.InputScopeNameValue", "ChatWithoutEmoji"))
{
    // Set new ChatWithoutEmoji InputScope if present.
    scopeName.NameValue = InputScopeNameValue.ChatWithoutEmoji;
}
else
{
    // Fall back to Chat InputScope.
    scopeName.NameValue = InputScopeNameValue.Chat;
}

// Set InputScope on messaging TextBox.
scope.Names.Add(scopeName);
messageBox.InputScope = scope;

// For this example, set the TextBox text to show the selected InputScope.
messageBox.Text = messageBox.InputScope.Names[0].NameValue.ToString();

// Add the TextBox to the XAML visual tree (rootGrid is defined in XAML).
rootGrid.Children.Add(messageBox);
```

前の例では、TextBox が作成され、コードにすべてのプロパティが設定されています。 ただし、既存の XAML があり、新しい値がサポートされているシステムで InputScope プロパティのみを変更する必要がある場合、次に示すように、XAML を変更せずにその操作を実行できます。 XAML で既定値を **Chat** に設定しますが、**ChatWithoutEmoji** 値が存在する場合はコードでそれをオーバーライドします。

**XAML**
```xaml
<TextBox x:Name="messageBox"
         AcceptsReturn="True" TextWrapping="Wrap"
         InputScope="Chat"
         Loaded="messageBox_Loaded"/>
```

**C#**
```csharp
private void messageBox_Loaded(object sender, RoutedEventArgs e)
{
    if (ApiInformation.IsEnumNamedValuePresent("Windows.UI.Xaml.Input.InputScopeNameValue", "ChatWithoutEmoji"))
    {
        // Check that the ChatWithEmoji value is present.
        // (It's present starting with Windows 10, version 1607,
        //  the Target version for the app. This code is skipped on earlier versions.)
        InputScope scope = new InputScope();
        InputScopeName scopeName = new InputScopeName();
        scopeName.NameValue = InputScopeNameValue.ChatWithoutEmoji;
        // Set InputScope on messaging TextBox.
        scope.Names.Add(scopeName);
        messageBox.InputScope = scope;
    }

    // For this example, set the TextBox text to show the selected InputScope.
    // This is outside of the API check, so it will happen on all OS versions.
    messageBox.Text = messageBox.InputScope.Names[0].NameValue.ToString();
}
```

既に具体例があるので、ターゲット バージョンと最小バージョンの設定がどのように適用されるのかを見てみましょう。

これらの例では、XAML またはチェックを含まないコードで Chat 列挙値を使うことができます。これは、Chat 列挙値がサポートされる最小の OS バージョンに存在するためです。 

XAML またはチェックを含まないコードで ChatWithoutEmoji 値を使うと、ChatWithoutEmoji 値がターゲットの OS バージョンに存在するためエラーなしでコンパイルされます。 また、ターゲットの OS バージョンが含まれたシステムで、エラーなしで実行されます。 ただし、アプリが最小バージョンを使っている OS を含むシステムで実行されると、ChatWithoutEmoji 列挙値が存在しないため実行時にクラッシュします。 そのため、コードでのみこの値を使って、この値が現在のシステムでサポートされている場合だけ呼び出されるように、ランタイム API チェックにラップする必要があります。

### 例 2: 新しいコントロール

通常、新しいバージョンの Windows では、プラットフォームに新機能をもたらす新しいコントロールが UWP API サーフェスに追加されています。 新しいコントロールを活用するには、[ApiInformation.IsTypePresent](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) メソッドを使います。

Windows 10 バージョン 1607 には、[**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) と呼ばれる新しいメディア コントロールが導入されています。 このコントロールは、[MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) クラスに基づいて作成されているため、バックグラウンド オーディオに簡単に結び付けることができるような機能が追加され、メディア スタックの向上したアーキテクチャを活用しています。

ただし、アプリが Windows 10 バージョン 1607 より古いバージョンを実行しているデバイスで実行される場合、新しい **MediaPlayerElement** コントロールではなく、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaelement.aspx) コントロールを使う必要があります。 [
            **ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) メソッドを使って実行時に MediaPlayerElement コントロールが存在するかどうかをチェックし、アプリが実行されているシステムに適しているコントロールを読み込むことができます。

この例は、新しい MediaPlayerElement または古い MediaElement を使うアプリを作成する方法を示しています。どちらを使うかは、MediaPlayerElement 型が存在するかどうかによって異なります。 このコードでは、[UserControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol.aspx) クラスを使って、コントロール、およびそれに関連する UI とコードをコンポーネント化し、OS バージョンに基づいて切り替えることができるようにしています。 また、このシンプルな例に必要なものよりも機能的でカスタムの動作を提供するカスタム コントロールを使うこともできます。
 
**MediaPlayerUserControl** 

`MediaPlayerUserControl` は、**MediaPlayerElement** と、フレーム単位でメディアを飛ばすために使われるいくつかのボタンをカプセル化します。 UserControl を使うと、これらのコントロールを単一のエンティティとして扱って、以前のシステムの MediaElement と簡単に切り替えることができます。 このユーザー コントロールは、MediaPlayerElement が存在するシステムでのみ使う必要があるため、このユーザー コントロール内のコードでは ApiInformation チェックを使いません。

> [!NOTE]
> この例をシンプルなままにし、集中して取り組むために、フレーム ステップ ボタンはメディア プレーヤーの外部に配置されています。 ユーザー エクスペリエンスを向上するためには、MediaTransportControls をカスタマイズしてカスタム ボタンを含める必要があります。 詳しくは、「[カスタム トランスポート コントロールを作成する](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/custom-transport-controls)」をご覧ください。 

**XAML**
```xaml
<UserControl
    x:Class="MediaApp.MediaPlayerUserControl"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MediaApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="300"
    d:DesignWidth="400">

    <Grid x:Name="MPE_grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <StackPanel Orientation="Horizontal" 
                    HorizontalAlignment="Center" Grid.Row="1">
            <RepeatButton Click="StepBack_Click" Content="Step Back"/>
            <RepeatButton Click="StepForward_Click" Content="Step Forward"/>
        </StackPanel>
    </Grid>
</UserControl>
```

**C#**
```csharp
using System;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MediaApp
{
    public sealed partial class MediaPlayerUserControl : UserControl
    {
        public MediaPlayerUserControl()
        {
            this.InitializeComponent();
            
            // The markup code compiler runs against the Minimum OS version so MediaPlayerElement must be created in app code
            MPE = new MediaPlayerElement();
            Uri videoSource = new Uri("ms-appx:///Assets/UWPDesign.mp4");
            MPE.Source = MediaSource.CreateFromUri(videoSource);
            MPE.AreTransportControlsEnabled = true;
            MPE.MediaPlayer.AutoPlay = true;

            // Add MediaPlayerElement to the Grid
            MPE_grid.Children.Add(MPE);

        }

        private void StepForward_Click(object sender, RoutedEventArgs e)
        {
            // Step forward one frame, only available using MediaPlayerElement.
            MPE.MediaPlayer.StepForwardOneFrame();
        }

        private void StepBack_Click(object sender, RoutedEventArgs e)
        {
            // Step forward one frame, only available using MediaPlayerElement.
            MPE.MediaPlayer.StepForwardOneFrame();
        }
    }
}
```

**MediaElementUserControl**
 
`MediaElementUserControl` は **MediaElement** コントロールをカプセル化します。

**XAML**
```xaml
<UserControl
    x:Class="MediaApp.MediaElementUserControl"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MediaApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="300"
    d:DesignWidth="400">

    <Grid>
        <MediaElement AreTransportControlsEnabled="True" 
                      Source="Assets/UWPDesign.mp4"/>
    </Grid>
</UserControl>
```

> [!NOTE]
> `MediaElementUserControl` のコード ページには、生成されたコードのみが含まれているため、ここでは示しません。

**IsTypePresent に基づいてコントロールを初期化する**

実行時に、**ApiInformation.IsTypePresent** を呼び出して、MediaPlayerElement の有無を確認します。 MediaPlayerElement が存在する場合は `MediaPlayerUserControl` を読み込み、存在しない場合は `MediaElementUserControl` を読み込みます。

**C#**
```csharp
public MainPage()
{
    this.InitializeComponent();

    UserControl mediaControl;

    // Check for presence of type MediaPlayerElement.
    if (ApiInformation.IsTypePresent("Windows.UI.Xaml.Controls.MediaPlayerElement"))
    {
        mediaControl = new MediaPlayerUserControl();
    }
    else
    {
        mediaControl = new MediaElementUserControl();
    }

    // Add mediaControl to XAML visual tree (rootGrid is defined in XAML).
    rootGrid.Children.Add(mediaControl);
}
```

> [!IMPORTANT]
> このチェックでは `mediaControl` オブジェクトを `MediaPlayerUserControl` または `MediaElementUserControl` に設定するだけです。 コード内の MediaPlayerElement API と MediaElement API のどちらを使うのかを判断する必要がある他の場所でこれらの条件付きチェックを実行する必要があります。 チェックを一度実行してから結果をキャッシュし、キャッシュされた結果をアプリ全体で使う必要があります。

## 状態トリガーの例

拡張可能な状態トリガーでは、マークアップとコードを一緒に使って、コードでチェックする条件 (ここでは、特定の API が存在するかどうか) に基づいて表示状態の変更をトリガーできます。 関係するオーバーヘッドと、表示状態のみへの制限があるため、一般的なアダプティブ コード シナリオで状態トリガーを使うことはお勧めしません。 

コントロール上のプロパティ値や列挙値の変更など、残りの UI に影響しない、異なる OS バージョン間での小さな UI の変更がある場合のみ、アダプティブ コードに状態トリガーを使ってください。

### 例 1: 新しいプロパティ

拡張可能な状態トリガーを設定する最初の手順は、[StateTriggerBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.statetriggerbase.aspx) クラスのサブクラスを作成して、API の有無に基づいてアクティブになるカスタム トリガーを作成することです。 この例は、プロパティの有無が XAML に設定されている `_isPresent` 変数に一致する場合にアクティブ化されるトリガーを示しています。

**C#**
```csharp
class IsPropertyPresentTrigger : StateTriggerBase
{
    public string TypeName { get; set; }
    public string PropertyName { get; set; }

    private Boolean _isPresent;
    private bool? _isPropertyPresent = null;

    public Boolean IsPresent
    {
        get { return _isPresent; }
        set
        {
            _isPresent = value;
            if (_isPropertyPresent == null)
            {
                // Call into ApiInformation method to determine if property is present.
                _isPropertyPresent =
                ApiInformation.IsPropertyPresent(TypeName, PropertyName);
            }

            // If the property presence matches _isPresent then the trigger will be activated;
            SetActive(_isPresent == _isPropertyPresent);
        }
    }
}
```

次の手順は、XAML で表示状態トリガーを設定して、2 つの異なる表示状態が API の有無に基づいた結果になるようにします。 

Windows 10 バージョン 1607 では、ユーザーがコントロールを操作するときにそのコントロールがフォーカスを取得するかどうかを判断する [AllowFocusOnInteraction](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.allowfocusoninteraction.aspx) と呼ばれる [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) クラスに新しいプロパティが導入されています。 これは、ユーザーがボタンをクリックしたときに、データ入力用のテキスト ボックスにフォーカスを保持する (タッチ キーボードを表示したままにする) のに役立ちます。

この例のトリガーは、プロパティが存在するかどうかをチェックします。 プロパティが存在する場合、Button の **AllowFocusOnInteraction** プロパティが **false** に設定されます。プロパティが存在しない場合は、Button はその元の状態を保持します。 TextBox は、コードの実行時にこのプロパティの影響をわかりやすくするために含まれています。

**XAML**
```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <StackPanel>
        <TextBox Width="300" Height="36"/>
        <!-- Button to set the new property on. -->
        <Button x:Name="testButton" Content="Test" Margin="12"/>
    </StackPanel>

    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="propertyPresentStateGroup">
            <VisualState>
                <VisualState.StateTriggers>
                    <!--Trigger will activate if the AllowFocusOnInteraction property is present-->
                    <local:IsPropertyPresentTrigger 
                        TypeName="Windows.UI.Xaml.FrameworkElement" 
                        PropertyName="AllowFocusOnInteraction" IsPresent="True"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="testButton.AllowFocusOnInteraction" 
                            Value="False"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>
```

### 例 2: 新しい列挙値

次の例は、値が存在するかどうかに基づいてさまざまな列挙値を設定する方法を示しています。 カスタム状態トリガーを使って、前のチャットの例と同じ結果を実現します。 この例では、デバイスが Windows 10 バージョン 1607 を実行している場合に、新しい ChatWithoutEmoji 入力スコープを使います。それ以外の場合、**Chat** 入力スコープが使われます。 このトリガーを使う表示状態は、新しい列挙値の有無に基づいて入力スコープが選択される *if-else* スタイルで設定されます。

**C#**
```csharp
class IsEnumPresentTrigger : StateTriggerBase
{
    public string EnumTypeName { get; set; }
    public string EnumValueName { get; set; }

    private Boolean _isPresent;
    private bool? _isEnumValuePresent = null;

    public Boolean IsPresent
    {
        get { return _isPresent; }
        set
        {
            _isPresent = value;

            if (_isEnumValuePresent == null)
            {
                // Call into ApiInformation method to determine if value is present.
                _isEnumValuePresent =
                ApiInformation.IsEnumNamedValuePresent(EnumTypeName, EnumValueName);
            }

            // If the property presence matches _isPresent then the trigger will be activated;
            SetActive(_isPresent == _isEnumValuePresent);
        }
    }
}
```

**XAML**
```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <TextBox x:Name="messageBox"
     AcceptsReturn="True" TextWrapping="Wrap"/>


    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="EnumPresentStates">
            <!--if-->
            <VisualState x:Name="isPresent">
                <VisualState.StateTriggers>
                    <local:IsEnumPresentTrigger 
                        EnumTypeName="Windows.UI.Xaml.Input.InputScopeNameValue" 
                        EnumValueName="ChatWithoutEmoji" IsPresent="True"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="messageBox.InputScope" Value="ChatWithoutEmoji"/>
                </VisualState.Setters>
            </VisualState>
            <!--else-->
            <VisualState x:Name="isNotPresent">
                <VisualState.StateTriggers>
                    <local:IsEnumPresentTrigger 
                        EnumTypeName="Windows.UI.Xaml.Input.InputScopeNameValue" 
                        EnumValueName="ChatWithoutEmoji" IsPresent="False"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="messageBox.InputScope" Value="Chat"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>
```
## 関連記事

- [UWP アプリ ガイド](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)
- [API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)



<!--HONumber=Jun16_HO4-->


