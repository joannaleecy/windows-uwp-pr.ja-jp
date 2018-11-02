---
author: jwmsft
title: バージョン アダプティブ コード
description: ApiInformation を使って、以前のバージョンとの互換性を保ちながら新しい API を利用します
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 3293e91e-6888-4cc3-bad3-61e5a7a7ab4e
ms.localizationpriority: medium
ms.openlocfilehash: e25a3bd447519ce344a95a1c335451f731552487
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5971156"
---
# <a name="version-adaptive-code"></a>バージョン アダプティブ コード

アダプティブ コードの記述については、[アダプティブ UI の作成](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml)と同じように考えることができます。 最小画面で実行するように基本 UI を設計し、より大きな画面でアプリが実行されていることを検出したときに要素を移動または追加できます。 アダプティブ コードの場合、最小の OS バージョンで実行するように基本コードを記述し、新機能が提供されているより高いバージョンでアプリが実行されていることを検出したときに、機能を手動で選んで追加できます。

ApiInformation に関する重要な背景情報、API コントラクト、Visual Studio の構成については、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。

### <a name="runtime-api-checks"></a>ランタイム API チェック

呼び出す API が存在するかどうかをテストするために、コードの条件で [Windows.Foundation.Metadata.ApiInformation](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.aspx) クラスを使います。 このテストの条件は、アプリの実行時に必ず評価されますが、API が存在するデバイスに対してのみ **true** と評価され、呼び出しが可能になります。 これにより、特定の OS バージョンでのみ利用できる API を使うアプリを作成するためのバージョン アダプティブ コードを記述できます。

ここでは、Windows Insider Preview の新機能をターゲットにするための具体的な例を示します。 **ApiInformation** を使う場合の一般的な概要については、[デバイス ファミリの概要に関する記事](https://docs.microsoft.com/en-us/uwp/extension-sdks/device-families-overview#writing-code)と [API コントラクトを使った機能の動的な検出に関するブログの投稿](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)をご覧ください。

> [!TIP]
> さまざまなランタイム API チェックが、アプリのパフォーマンスに影響する可能性があります。 それらの例では、チェックをインラインで示します。 運用コードでは、チェックを一度実行してから結果をキャッシュし、キャッシュされた結果をアプリ全体で使う必要があります。 

### <a name="unsupported-scenarios"></a>サポートされていないシナリオ

ほとんどの場合、アプリの最小バージョンを SDK バージョン 10240 に設定したままにし、アプリがそれより新しいバージョンで実行されたときに、ランタイム チェックを使って新しい API を有効にすることができます。 ただし、新機能を使うためにアプリの最小バージョンを上げることが必要になる場合もあります。

アプリの最小バージョンを上げる必要があるのは、以下を使う場合です。
- 以前のバージョンでは使うことができない機能を必要とする新しい API。 サポートされる最小バージョンを、その機能が含まれているバージョンに上げる必要があります。 詳しくは、「[アプリ機能の宣言](../packaging/app-capability-declarations.md)」をご覧ください。
- generic.xaml に追加された新しいリソース キーのうち、以前のバージョンでは使うことができないリソース キー。 実行時に使われる generic.xaml のバージョンは、デバイスで実行されている OS バージョンによって決まります。 ランタイム API チェックを使って XAML リソースの有無を確認することはできません。 そのため、アプリがサポートする最小バージョンで利用できるリソース キーのみを使う必要があります。そうしないと、[XAMLParseException](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.markup.xamlparseexception.aspx) が原因で実行時にアプリがクラッシュします。

### <a name="adaptive-code-options"></a>アダプティブ コードのオプション

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

## <a name="adaptive-code-examples"></a>アダプティブ コードの例

このセクションでは、Windows 10 バージョン 1607 (Windows Insider Preview) で新しく追加された API を使うアダプティブ コードの例をいくつか示します。

### <a name="example-1-new-enum-value"></a>例 1: 新しい列挙値

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

### <a name="example-2-new-control"></a>例 2: 新しいコントロール

通常、新しいバージョンの Windows では、プラットフォームに新機能をもたらす新しいコントロールが UWP API サーフェスに追加されています。 新しいコントロールを活用するには、[ApiInformation.IsTypePresent](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) メソッドを使います。

Windows 10 バージョン 1607 には、[**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) と呼ばれる新しいメディア コントロールが導入されています。 このコントロールは、[MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) クラスに基づいて作成されているため、バックグラウンド オーディオに簡単に結び付けることができるような機能が追加され、メディア スタックの向上したアーキテクチャを活用しています。

ただし、アプリが Windows 10 バージョン 1607 より古いバージョンを実行しているデバイスで実行される場合、新しい **MediaPlayerElement** コントロールではなく、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaelement.aspx) コントロールを使う必要があります。 [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) メソッドを使って実行時に MediaPlayerElement コントロールが存在するかどうかをチェックし、アプリが実行されているシステムに適しているコントロールを読み込むことができます。

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

## <a name="state-trigger-examples"></a>状態トリガーの例

拡張可能な状態トリガーでは、マークアップとコードを一緒に使って、コードでチェックする条件 (ここでは、特定の API が存在するかどうか) に基づいて表示状態の変更をトリガーできます。 関係するオーバーヘッドと、表示状態のみへの制限があるため、一般的なアダプティブ コード シナリオで状態トリガーを使うことはお勧めしません。 

コントロール上のプロパティ値や列挙値の変更など、残りの UI に影響しない、異なる OS バージョン間での小さな UI の変更がある場合のみ、アダプティブ コードに状態トリガーを使ってください。

### <a name="example-1-new-property"></a>例 1: 新しいプロパティ

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

### <a name="example-2-new-enum-value"></a>例 2: 新しい列挙値

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

## <a name="related-articles"></a>関連記事

- [デバイス ファミリの概要](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)
- [API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)
