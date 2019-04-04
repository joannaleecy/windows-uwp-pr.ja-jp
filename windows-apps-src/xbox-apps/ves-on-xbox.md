---
title: 音声は、Xbox でシェル (VES) を有効になっています。
description: Xbox、UWP アプリに音声コントロールのサポートを追加する方法について説明します。
ms.date: 10/19/2017
ms.topic: article
keywords: windows 10、uwp、xbox、音声、音声が有効になっているシェル
ms.openlocfilehash: ea51216c804754e98c3bac459b79fb75dd9369cc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596057"
---
# <a name="using-speech-to-invoke-ui-elements"></a>音声認識を使用して、UI 要素を呼び出す

音声有効になっているシェル (VES) は、Windows 音声のプラットフォーム、アプリ内でファースト クラスの音声認識エクスペリエンスを実現する画面を起動するための音声認識を使用できるようにする拡張機能のコントロールとディクテーションを使用してテキストを挿入します。 VE では、すべての Windows シェルおよびデバイスでアプリ開発者のために必要な最小限の労力で一般的なエンド ツー エンドの「it say it エクスペリエンスを提供するよう努力しています。  これを実現するには、Microsoft の音声のプラットフォームと、UI オートメーション (UIA) フレームワークを活用します。

## <a name="user-experience-walkthrough"></a>ユーザー エクスペリエンスのチュートリアル ##
次にどのようなユーザーが発生した場合、Xbox で VE を使用する場合の概要と VES のしくみの詳細に入る前にコンテキストを設定するようにします。

- ユーザーが、Xbox コンソールをオンにし、関心のあるものを検索するには、そのアプリを参照します。

        User: "Hey Cortana, open My Games and Apps"

- ユーザーは左側のアクティブなリッスン モード (ALM)、つまり、コンソールがリッスンするいると言うことがなく、画面に表示されているコントロールの呼び出しをユーザーのコルタナさん」毎回です。  アプリとアプリの一覧をスクロールして表示するのには、ユーザーは切り替えることができますようになりました。

        User: "applications"

- ビューをスクロールするには、ユーザー可能だけです。

        User: "scroll down"

- アプリに関心が名前を忘れた場合、ボックス アートが表示されます。  音声ヒント ラベルに表示するユーザーを要求します。

        User: "show labels"

- これで明確に何を言おう、アプリを起動できます。

        User: "movies and TV"

- アクティブなリッスン モードを終了するには、ユーザーは、リッスンを停止する Xbox を指示します。

        User: "stop listening"

- 後で、新しいアクティブなリッスンしているセッションを開始できます。

        User: "Hey Cortana, make a selection" or "Hey Cortana, select"

## <a name="ui-automation-dependency"></a>UI オートメーションの依存関係 ##
VE、UI オートメーション クライアントであり、UI オートメーション プロバイダーを使用してアプリによって公開される情報に依存しています。 これは、Windows プラットフォームでのナレーター機能によって既に使用されている同じインフラストラクチャです。  UI オートメーションでは、コントロール、その型、およびどのようなコントロール パターン、実装の名前を含む、ユーザー インターフェイス要素にプログラムからアクセスできるようにします。  UI は、アプリの変更、VES は UIA 更新イベントに対応し、この情報を使用して、音声認識文法を作成する実行可能なすべての項目を検索する更新済みの UI オートメーション ツリーを再解析します。 

すべての UWP アプリでは、UI オートメーション フレームワークにアクセスし、(XAML、DirectX/Direct3D、Xamarin など) に基づいて構築されていますが、どのグラフィックス フレームワークに依存しない UI に関する情報を公開できます。  場合によっては、XAML などでは、面倒な作業のほとんどは、ナレーターおよび VES をサポートするために必要な作業を大幅に削減に、フレームワークによって行われます。

UI オートメーションの詳細についてを参照してください。 [UI オートメーションの基礎](https://msdn.microsoft.com/en-us/library/ms753107(v=vs.110).aspx "UI オートメーションの基礎")します。

## <a name="control-invocation-name"></a>コントロールの呼び出しの名前 ##
VE 何がコントロールの名前として「音声認識エンジンに登録する語句を決定するため次ヒューリスティックを採用しています (ie。 コントロールを呼び出す話す必要があるユーザー)。  これは、また、音声ヒント ラベルに表示される語句です。

優先順位の順序で名前のソース:

1. 要素の場合、 `LabeledBy` VES、添付プロパティを使用して、`AutomationProperties.Name`のこのテキスト ラベル。
2. `AutomationProperties.Name` 要素。  既定値として、コントロールのテキスト コンテンツを使用、XAML で`AutomationProperties.Name`します。
3. VE は有効な最初の子要素を探して、コントロールが ListItem またはボタンの場合は、`AutomationProperties.Name`します。

## <a name="actionable-controls"></a>実用的なコントロール ##
VE は、次のオートメーション コントロール パターンのいずれかを実装している場合に実行可能なコントロールを考慮します。

- **InvokePattern** (例。 ボタン) の開始または 1 つの明確なアクションを実行し、アクティブになったときの状態を保持しないコントロールを表します。

- **TogglePattern** (例。 チェック ボックスをオン) に、一連の状態の切り替え、一度設定した状態を維持できるコントロールを表します。

- **SelectionItemPattern** (例。 コンボ ボックス) には、選択可能な子項目のコレクションのコンテナーとして機能するコントロールを表します。

- **ExpandCollapsePattern** (例。 コンボ ボックス) - 視覚的に展開するコンテンツを表示し、コンテンツを非表示に折りたたみコントロールを表します。

- **ScrollPattern** (例。 リスト) の子要素のコレクションのスクロール可能なコンテナーとして機能するコントロールを表します。

## <a name="scrollable-containers"></a>スクロール可能なコンテナー ##
スクロール可能なコンテナーのサポートは、ScrollPattern、VES 音声をリッスンする「左右にスクロール」、「右にスクロールして」などのようなコマンドは、ユーザーがこれらのコマンドのいずれかをトリガーしたときに、適切なパラメーターを使用してスクロールを呼び出します。  値に基づくスクロール コマンドが挿入され、`HorizontalScrollPercent`と`VerticalScrollPercent`プロパティ。  たとえば場合、`HorizontalScrollPercent`は 100、「右にスクロール」を追加するよりも小さい場合、0 の場合、「スクロール左」が追加するよりも大きいためです。

## <a name="narrator-overlap"></a>ナレーターの重複 ##
ナレーター アプリケーションは、UI オートメーション クライアントでも、使用して、`AutomationProperties.Name`として現在選択されている UI 要素を読み取るテキストのソースのいずれかのプロパティ。  アクセシビリティのエクスペリエンスを向上させる多くのアプリを提供する開発者が再度並べ替えられたりオーバー ロード、`Name`詳細とナレーターで読み取られる場合のコンテキストを提供することで時間の長い説明のテキストを持つプロパティです。  ただし、これにより、2 つの機能間の競合です。VE では、短い語句と一致するかより適切なコンテキストを提供するフレーズを長くよりわかりやすいメリットは、ナレーターの中に、コントロールの表示テキストと厳密に一致する必要があります。

これを解決する、Windows 10 Creators Update 以降、ナレーターも見てに更新されました、`AutomationProperties.HelpText`プロパティ。  ナレーターがほかに、その内容を読み上げる場合、このプロパティが空でない`AutomationProperties.Name`します。  場合`HelpText`は空の場合、ナレーターはのみの内容を読み取る名。  これにより、必要に応じて、使用するわかりやすい文字列になったが短く、音声認識フレンドリ内の句を維持、`Name`プロパティ。

![](images/ves_narrator.jpg)

詳細については、[UI でのユーザー補助のサポートのオートメーション プロパティ](https://msdn.microsoft.com/en-us/library/ff400332(vs.95).aspx "UI でのユーザー補助のサポートのオートメーション プロパティ")を参照してください。

## <a name="active-listening-mode-alm"></a>アクティブなリッスン モード (ALM) ##
### <a name="entering-alm"></a>ALM を入力します。 ###
Xbox では、VES が音声入力の継続的にリッスンしていません。  ユーザーは、ことを示すアクティブなリッスン モードを明示的に入力する必要があります。

- "こんにちは Cortana、select"、または
- "こんにちは Cortana、選択する"

"Hey Cortana、サインイン"または」「コルタナさんホームに戻るなど、完了時アクティブにリッスンしているユーザーのままにもいくつかその他の Cortana コマンドもあります。 

ALM を入力すると、次の効果が完成します。

- Cortana のオーバーレイは、表示される内容とユーザーに求める上部右に表示されます。  ユーザーが言うと、中に音声認識エンジンによって認識される語句フラグメントはこの場所にも表示されます。
- VE は、UIA ツリーに解析、実行可能なすべてのコントロールを検索します、それぞれのテキストを音声認識文法の登録、および継続的なリッスンしているセッションを開始するを。

    ![](images/ves_overlay.png)

### <a name="exiting-alm"></a>既存の ALM ###
ユーザーが音声を使用して UI を使用した操作中に、システムは ALM に残ります。  ALM を終了する 2 つの方法はあります。

- ユーザーに明示的には、「リッスンを停止」または
- ALM を入力してから、または最後の正の認識以降 17 秒以内に正の認識がない場合、タイムアウトが発生します。

## <a name="invoking-controls"></a>コントロールの呼び出し ##
音声を使用して UI を使用したユーザーが操作できる ALM の場合にします。  UI が正しく (表示されるテキストに一致する名前プロパティ) で構成されている、音声を使用してアクションを実行する、シームレスで自然なの経験ことがあります。  ユーザーは、単に画面に表示できる必要があります。

## <a name="overlay-ui-on-xbox"></a>Xbox で UI をオーバーレイします。 ##
VES 名前は派生のコントロールが UI に表示される実際のテキストよりも異なる可能性があります。  期限を指定できます、`Name`プロパティまたは関連付けられているコントロールの`LabeledBy`要素の明示的に別の文字列に設定します。  または、コントロールに GUI テキスト、アイコンまたはイメージ要素のみがありません。

このような場合は、ユーザーには、このようなコントロールを呼び出すためには当てはまりませんが必要なものを表示する方法が必要があります。  そのため、1 回でアクティブなリッスンしている、音声のヒント表示できます「のラベルを表示する」と言って。  これにより、音声はヒント ラベルをすべて実行可能なコントロールの上に表示されます。

100 のラベルの制限がある場合は、アプリの UI がある 100 よりもより実施可能なコントロールがあるため一部の音声ヒント ラベルはありません。  ラベルが選択したこの例では非決定的、構造と、現在の UI の構成に依存している UIA ツリーに最初に列挙します。

音声ヒント ラベルを表示するには、非表示にするコマンドがないとは引き続き表示された、次のイベントのいずれかが発生するまで。

- ユーザーがコントロールを呼び出す
- ユーザーが現在のシーンから離れた
- 「リッスンを停止」、ユーザーを質問します。
- アクティブなリッスン モードをタイムアウトします。

## <a name="location-of-voice-tip-labels"></a>音声のヒントのラベルの場所 ##
音声ヒント ラベルは、コントロールの BoundingRectangle 内で水平方向および垂直方向に中央が。  ラベルができるコントロールが小さいと緊密にグループ化する場合、他のユーザーがはっきりと見えなく重複/なる、VES はこれらのラベル間隔にプッシュを別々 に表示されることを確認しようとしています。  ただし、これは保証されません 100% の時間を操作します。  可能性は非常に混雑した UI の場合、他のユーザーによって隠されている一部のラベルが発生します。 「ラベルを表示する」で、UI を確認してください音声ヒントの表示のための十分な余裕があることを確認します。

![](images/ves_labels.png)

## <a name="combo-boxes"></a>コンボ ボックス ##
コンボ ボックスは、コンボ ボックスの個々 の項目を展開するときに、独自の音声ヒント ラベルを取得し、ドロップダウン リストの背後にある既存のコントロールの上にこれらは多くの場合、します。  プレゼンテーションの乱雑および混乱ラベルの混同 (コンボ ボックス項目のラベルがコンボ ボックスの背後にあるコントロールのラベルを混在させるは) を回避するために子アイテムが表示されるため、コンボ ボックスのラベルのみを展開します。 その他のすべての音声ヒント ラベルは表示されません。  ユーザーか、ドロップダウン リストの項目のいずれかを選択したりできますコンボ ボックスの「閉じる」。

- 折りたたまれたコンボ ボックスのラベル。

    ![](images/ves_combo_closed.png)

- 拡張コンボ ボックスのラベル。

    ![](images/ves_combo_open.png)


## <a name="scrollable-controls"></a>スクロール可能なコントロール ##
スクロール可能なコントロールは、各コントロールの端でスクロール コマンドに対する音声ヒントが中央揃えにします。  音声のヒントは実用的なは、そのため、たとえば「上にスクロールする」と「スクロール」の垂直方向スクロールがない場合は表示されませんがスクロール方向のみ表示されます。  VE が序数を使用して区別する (例: スクロール可能な複数のリージョンが存在する場合 「スクロール権限 1」、「スクロール右側 2」など。)。

![](images/ves_scroll.png) 

## <a name="disambiguation"></a>不明瞭解消 ##
複数の UI 要素が同じ名前を持つか、音声認識エンジンが複数の候補を一致、VES は曖昧性除去モードを入力します。  このモードの音声のヒントにラベルを表示する要素の関連するユーザーが適切なものを選択できるようにします。 曖昧性除去モードを解除「キャンセル」を言うことにより、ユーザーをキャンセルできます。

次に、例を示します。

- 曖昧性除去; 前に、のアクティブなリッスン モードで「います I があいまいです」、ユーザーを質問します。

    ![](images/ves_disambig1.png) 

- 両方のボタンと一致します。曖昧性除去は、次の開始。

    ![](images/ves_disambig2.png) 

- 表示は、"Select 2"が選択されたときにアクションをクリックします。

    ![](images/ves_disambig3.png) 
 
## <a name="sample-ui"></a>サンプル UI ##
ここでは、XAML の例に基づく UI、さまざまな方法で AutomationProperties.Name を設定します。

    <Page
        x:Class="VESSampleCSharp.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:VESSampleCSharp"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Button x:Name="button1" Content="Hello World" HorizontalAlignment="Left" Margin="44,56,0,0" VerticalAlignment="Top"/>
            <Button x:Name="button2" AutomationProperties.Name="Launch Game" Content="Launch" HorizontalAlignment="Left" Margin="44,106,0,0" VerticalAlignment="Top" Width="99"/>
            <TextBlock AutomationProperties.Name="Day of Week" x:Name="label1" HorizontalAlignment="Left" Height="22" Margin="168,62,0,0" TextWrapping="Wrap" Text="Select Day of Week:" VerticalAlignment="Top" Width="137"/>
            <ComboBox AutomationProperties.LabeledBy="{Binding ElementName=label1}" x:Name="comboBox" HorizontalAlignment="Left" Margin="310,57,0,0" VerticalAlignment="Top" Width="120">
                <ComboBoxItem Content="Monday" IsSelected="True"/>
                <ComboBoxItem Content="Tuesday"/>
                <ComboBoxItem Content="Wednesday"/>
                <ComboBoxItem Content="Thursday"/>
                <ComboBoxItem Content="Friday"/>
                <ComboBoxItem Content="Saturday"/>
                <ComboBoxItem Content="Sunday"/>
            </ComboBox>
            <Button x:Name="button3" HorizontalAlignment="Left" Margin="44,156,0,0" VerticalAlignment="Top" Width="213">
                <Grid>
                    <TextBlock AutomationProperties.Name="Accept">Accept Offer</TextBlock>
                    <TextBlock Margin="0,25,0,0" Foreground="#FF5A5A5A">Exclusive offer just for you</TextBlock>
                </Grid>
            </Button>
        </Grid>
    </Page>


ここで、上記のサンプルを使用して、UI の外観と音声のヒントのラベルがない場合です。
 
- アクティブなリッスン モードで表示されるラベルがない場合。

    ![](images/ves_alm_nolabels.png) 

- アクティブなリッスン モードで、ユーザーの質問「ラベルを表示する」後。

    ![](images/ves_alm_labels.png) 

場合に`button1`、XAML 自動に設定します、`AutomationProperties.Name`プロパティ、コントロールの表示のテキスト コンテンツからテキストを使用します。  これは、明示的ながない場合でも、音声ヒント ラベルがある理由`AutomationProperties.Name`を設定します。

`button2`を明示的に設定、`AutomationProperties.Name`コントロールのテキスト以外のものにします。

`comboBox`を使用して、`LabeledBy`プロパティ参照を`label1`自動化のソースとして`Name`、し、`label1`を設定します、`AutomationProperties.Name`を画面にレンダリングされるコンテンツよりもより自然な語句 ("Day of Week"ではなく"Select 1 日に複数の曜日")。

最後に、 `button3`、VES を取得、`Name`から最初の子要素から`button3`自体はありません、`AutomationProperties.Name`を設定します。

## <a name="see-also"></a>関連項目
- [UI オートメーションの基礎](https://msdn.microsoft.com/en-us/library/ms753107(v=vs.110).aspx "UI オートメーションの基礎")
- [UI でのユーザー補助のサポートのオートメーション プロパティ](https://msdn.microsoft.com/en-us/library/ff400332(vs.95).aspx "UI でのユーザー補助のサポートのオートメーション プロパティ")
- [よく寄せられる質問](frequently-asked-questions.md)
- [Xbox One の UWP](index.md)
