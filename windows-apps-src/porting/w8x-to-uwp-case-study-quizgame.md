---
ms.assetid: 88e16ec8-deff-4a60-bda6-97c5dabc30b8
description: このトピックでは、機能しているピア ツー ピアのクイズ ゲーム WinRT 8.1 サンプル アプリを windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリを移植するケース スタディを示します。
title: Windows ランタイム 8.x から UWP へのケース スタディ、QuizGame ピア ツー ピアのサンプル アプリ
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d2d1b2b4e6875730d5a6bfa8dd711e11ac5d049c
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9049309"
---
# <a name="windows-runtime-8x-to-uwp-case-study-quizgame-sample-app"></a>Windows ランタイム 8.x から UWP へのケース スタディ: QuizGame サンプル アプリ




このトピックでは、機能しているピア ツー ピアのクイズ ゲーム WinRT 8.1 サンプル アプリを移植 Windows10Universal Windows プラットフォーム (UWP) アプリのケース スタディします。

ユニバーサル 8.1 アプリは、同じアプリの 2 つのバージョンをビルドする: windows 8.1、用の 1 つのアプリ パッケージと Windows Phone 8.1 用の別のアプリ パッケージです。 QuizGame の WinRT 8.1 バージョンは、ユニバーサル Windows アプリ プロジェクトの配置を使用して、別の方法がかかりますが、2 つのプラットフォームの機能的に異なるアプリをビルドします。 Windows 8.1 アプリ パッケージでは、クイズ ゲーム セッションのホストとして機能 Windows Phone 8.1 アプリ パッケージをホストするクライアントの役割の再生中にします。 クイズ ゲーム セッションの 2 つの要素は、ピア ツー ピア ネットワーク経由で通信します。

適切なセンサーは、それぞれに PC とスマート フォンで 2 つの要素を調整します。 ただし、できればより高い場合は、選択した場合のほぼ任意のデバイスで、ホストとクライアントの両方を実行する可能性がありますか。 ここでスタディでは、移植します位置はそれぞれを構築する際、多様なデバイスにインストールできる単一のアプリ パッケージに windows 10 の両方のアプリです。

アプリのビューを使用し、モデルの表示を構成するパターンを使用します。 このクリーンの分離した結果としてこのアプリの移植プロセスは非常に単純ですが表示されます。

**注:** このサンプルでは、カスタム UDP を送受信する、ネットワークが構成されていると想定しています (ほとんどのホーム ネットワークは、会社のネットワークができない可能性がありますが) マルチキャスト パケットをグループ化します。 このサンプルも送信し、TCP パケットを受信します。

 

**注:** とき、Visual Studio で QuizGame10 を開く「Visual Studio 更新プログラムが必要」、メッセージが表示し、手順に従います[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)します。

 

## <a name="downloads"></a>ダウンロード

[QuizGame ユニバーサル 8.1 アプリをダウンロード](https://go.microsoft.com/fwlink/?linkid=532953)します。 これは、移植する前に、アプリの初期状態です。 

[Windows 10 アプリをダウンロード、QuizGame10](https://go.microsoft.com/fwlink/?linkid=532954)します。 これは、移植の直後に、アプリの状態です。 

[このサンプル github の最新バージョンを参照してください](https://github.com/Microsoft/Windows-appsample-quizgame)。

## <a name="the-winrt-81-solution"></a>WinRT 8.1 ソリューション


ここではどのような QuizGame-ポートを行いましょうアプリ-ようになります。

![windows で実行されている quizgame ホスト アプリ](images/w8x-to-uwp-case-studies/c04-01-win81-how-the-host-app-looks.png)

Windows で実行されている QuizGame ホスト アプリ

 

![windows phone で実行されている quizgame クライアント アプリ](images/w8x-to-uwp-case-studies/c04-02-wp81-how-the-client-app-looks.png)

Windows Phone で実行されている QuizGame クライアント アプリ

## <a name="a-walkthrough-of-quizgame-in-use"></a>QuizGame の使用のチュートリアル

これは、使用中のアプリの短い仮定アカウントが、ワイヤレス ネットワーク経由で自分のアプリを試す便利な情報を提供します。

楽しいクイズ ゲームで行われてバー。 すべてのユーザーに表示されるバーには、大きなテレビがあります。 Quizmaster では、テレビでの出力が表示されている PC があります。 その PC では、「ホスト アプリ」ことで実行されているがあります。 スマート フォンやサーフェスに「クライアント アプリ」をインストールするすべてのユーザーに含まれているだけでテストする必要があります。

ホスト アプリ ロビー モードでは、大きなテレビでそれが広告クライアント アプリは接続の準備があります。 ジャンヌは、自分のモバイル デバイスで、クライアント アプリを起動します。 彼女は、**プレイヤーの名前**] ボックスに自分の名前を入力し、**ゲームへの参加**をタップします。 ホスト アプリでは、ジャンヌが自分の名前を表示することによって参加しているし、ジャンヌのクライアント アプリがゲームを開始するを待機していることを示すことを確認します。 次に、マックスウェルは自分のモバイル デバイスで同じ手順を通過します。

Quizmaster をクリックして**ゲームを開始**して、ホスト アプリは、質問と回答 (も示しますに参加しているプレイヤーの一覧で通常 fontweight、灰色で表示) を示しています。 同時に、回答が表示されるに参加しているクライアント デバイス上のボタンに表示します。 ジャンヌがれ、自分のすべてのボタンを無効になるとそれに対する応答「1975」ボタンをタップします。 ホスト アプリでジャンヌの名緑色に描画されます (および太字になります) で自分の応答の受領通知の受信確認します。 マックスウェル回答もします。 すべてのプレイヤーの名が、緑色であることが示されます、quizmaster では、**次の質問**をクリックします。

質問を続行し、この同じサイクルで応答します。 最後の質問は、ホスト アプリで表示されると、**結果の表示**は、ボタン、および**次の質問**ではないのコンテンツです。 **結果の表示**がクリックされると、結果が表示されます。 **ロビーに戻る**をクリックすると返しますに参加していることを除いて、ゲームのライフ サイクルの先頭にプレイヤーのままに参加しています。 ただし、新しいプレイヤーへの参加、さらに参加しているプレイヤー (ただしに参加しているプレイヤーを**ゲームのままに**タップすると、いつでもでもかまいません) のままにする便利な時間の機会が得られますロビーに戻っています。

## <a name="local-test-mode"></a>ローカル テスト モード

アプリと間で分散されたデバイスではなく 1 台の PC では、その操作を試して、ローカル テスト モードでホスト アプリをビルドすることができます。 このモードは、ネットワークの使用を完全にバイパスできます。 代わりに、ホスト アプリの UI は、ウィンドウの左側にホスト部分を表示し、クライアント アプリの UI の 2 つのコピーを縦に並んだ、右に (、このバージョンではローカル テスト モード UI が修正されたに注意してください。 PC の表示するために適応しない小型のデバイス)。 すべて、同じアプリで、UI のこれらのセグメントは、それ以外の場合のかかる場所、ネットワーク経由で操作をシミュレートするモック クライアント通信経由で相互に通信します。

ローカル テスト モードをアクティブ化するには、条件付きコンパイル シンボルとして**LOCALTESTMODEON** ([プロジェクトのプロパティ) を定義し、リビルドしてください。

## <a name="porting-to-a-windows10-project"></a>Windows 10 プロジェクトへの移植

QuizGame では、次の部分があります。

-   P2PHelper します。 これは、ピア ツー ピア ネットワーク ロジックが含まれているポータブル クラス ライブラリです。
-   QuizGame.Windows します。 これは、windows 8.1 を対象となるホスト アプリのアプリ パッケージを構築するプロジェクトです。
-   QuizGame.WindowsPhone します。 これは、Windows Phone 8.1 を対象となるクライアント アプリのアプリ パッケージを構築するプロジェクトです。
-   QuizGame.Shared します。 これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。

このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。

これらのオプションに基づき、QuizGameHost と呼ばれる新しい windows 10 プロジェクトを QuizGame.Windows を移植します。 また、QuizGame.WindowsPhone QuizGameClient と呼ばれる新しい windows 10 プロジェクトを移植します。 任意のデバイスで実行されるため、これらのプロジェクトは、ユニバーサル デバイス ファミリをターゲットします。 スクリプトを紹介する、QuizGame.Shared ソース ファイルなど、独自のフォルダーにし、2 つの新しいプロジェクトにそれらの共有ファイルにリンクします。 ようにする前に、スクリプトを紹介するすべての 1 つのソリューションでし、ここでは、名前 QuizGame10 だけです。

**QuizGame10 ソリューション**

-   新しいソリューションを作成 (**新しいプロジェクト** &gt; **その他のプロジェクトの種類** &gt; **Visual Studio ソリューション**) と QuizGame10 名前を付けます。

**P2PHelper**

-   ソリューションでは、新しい windows 10 クラス ライブラリ プロジェクトを作成します (**[新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **クラス ライブラリ (Windows ユニバーサル)**) と P2PHelper 名前を付けます。
-   新しいプロジェクトの Class1.cs を削除します。
-   P2PSession.cs、P2PSessionClient.cs、および P2PSessionHost.cs を新しいプロジェクトのフォルダーにコピーし、新しいプロジェクトにコピーしたファイルを含めます。
-   さらに変更を必要とせず、プロジェクトがビルドされます。

**共有ファイル**

-   \\QuizGame10\\ に \\QuizGame.Shared\\ から共通、モデル、ビュー、およびビューモデル フォルダーをコピーします。
-   、一般的なモデル、ビュー、およびビューモデルはあります意味ディスク上の共有フォルダーを参照します。

**QuizGameHost**

-   新しい windows 10 アプリ プロジェクトを作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**) と QuizGameHost 名前を付けます。
-   P2PHelper への参照を追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。
-   **ソリューション エクスプ ローラー**では、各ディスク上の共有フォルダーの新しいフォルダーを作成します。 次に、先ほど作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存項目**のフォルダーを移動します。 適切な共有フォルダーを開き、すべてのファイルを選択し、**追加のリンク**をクリックします。
-   \\QuizGameHost\\ に \\QuizGame.Windows\\ から MainPage.xaml をコピーし、名前空間を QuizGameHost に変更します。
-   App.xaml を \\QuizGame.Shared\\ から \\QuizGameHost\\ にコピーし、名前空間を QuizGameHost に変更します。
-   App.xaml.cs を上書きするのではなくしますを新しいプロジェクトのバージョンを保持し、ローカル テスト モードをサポートするために 1 つの対象となる変更を加えるだけです。 App.xaml.cs ファイルでは、次のコード行を置き換えます。

```CSharp
rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

こっちと：

```CSharp
#if LOCALTESTMODEON
    rootFrame.Navigate(typeof(TestView), e.Arguments);
#else
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
#endif
```

-   **プロパティ**で&gt;**ビルド** &gt; **条件付きコンパイル シンボル**が LOCALTESTMODEON を追加します。
-   App.xaml.cs に追加したコードに戻り、TestView 型を解決することがなります。
-   、Package.appxmanifest で機能名を internetClient から internetClientServer に変更します。

**QuizGameClient**

-   新しい windows 10 アプリ プロジェクトを作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**) と QuizGameClient 名前を付けます。
-   P2PHelper への参照を追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。
-   **ソリューション エクスプ ローラー**では、各ディスク上の共有フォルダーの新しいフォルダーを作成します。 次に、先ほど作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存項目**のフォルダーを移動します。 適切な共有フォルダーを開き、すべてのファイルを選択し、**追加のリンク**をクリックします。
-   \\QuizGameClient\\ に \\QuizGame.WindowsPhone\\ から MainPage.xaml をコピーし、名前空間を QuizGameClient に変更します。
-   App.xaml を \\QuizGame.Shared\\ から \\QuizGameClient\\ にコピーし、名前空間を QuizGameClient に変更します。
-   、Package.appxmanifest で機能名を internetClient から internetClientServer に変更します。

今すぐことができますをビルドして実行します。

## <a name="adaptive-ui"></a>アダプティブ UI

QuizGameHost windows 10 アプリ正常に見えること (これは、大規模なスクリーンを備えたデバイスでのみ) 幅の広いウィンドウで、アプリが実行されている場合。 とき、アプリのウィンドウが狭い場合は (小型のデバイスで行われます、大型のデバイスも発生することができます)、UI を読みやすくがないことずっと禁止されています。

説明した、これを修正するアダプティブな Visual State Manager 機能を使うできます[ケース スタディ: Bookstore2](w8x-to-uwp-case-study-bookstore2.md)します。 最初に、既定では、UI が幅の狭い状態でレイアウトされるような視覚要素のプロパティを設定します。 \\View\\HostView.xaml でこれらすべての変更が行われます。

-   メインの**グリッド**では、最初の**RowDefinition** 「140」から「自動」の**高さ**を変更します。
-   という名前**TextBlock**にはが含まれている**グリッド**で`pageTitle`設定`x:Name="pageTitleGrid"`と`Height="60"`します。 最初の 2 つの手順は表示状態での setter 経由でその**RowDefinition**の高さを効果的に制御できます。
-   `pageTitle`設定`Margin="-30,0,0,0"`します。
-   コメント、**グリッド**で`<!-- Content -->`設定`x:Name="contentGrid"`と`Margin="-18,12,0,0"`します。
-   コメントのすぐ上、 **TextBlock**で`<!-- Options -->`設定`Margin="0,0,0,24"`します。
-   既定の**TextBlock**スタイル (ファイルの最初のリソース) では、 **FontSize** setter の値を「15」に変更します。
-   `OptionContentControlStyle`、 **FontSize** setter の値を「20」に変更します。 この手順とは、前得るがすべてのデバイスで適切に動作する優れた書体見本できます。 これらは、windows 8.1 アプリで使っていた「30」より柔軟なサイズです。
-   最後に、ルート**グリッド**に適切な Visual State Manager のマークアップを追加します。

```xml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState x:Name="WideState">
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="548"/>
            </VisualState.StateTriggers>
            <VisualState.Setters>
                <Setter Target="pageTitleGrid.Height" Value="140"/>
                <Setter Target="pageTitle.Margin" Value="0,0,30,40"/>
                <Setter Target="contentGrid.Margin" Value="40,40,0,0"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
```

## <a name="universal-styling"></a>ユニバーサル スタイル設定


Windows 10 のボタンが、パディングのテンプレートでは、同じタッチ ターゲット必要がないということがわかります。 2 つの小規模な変更を修正します。 まず、app.xaml QuizGameHost と QuizGameClient の両方でをこのマークアップを追加します。

```xml
<Style TargetType="Button">
    <Setter Property="Margin" Value="12"/>
</Style>
```

次に、追加するには、この setter と`OptionButtonStyle`\\View\\ClientView.xaml にします。

```xml
<Setter Property="Margin" Value="6"/>
```

その最後の調整と、アプリの動作し、見て同じポートの前に、と、追加の値を持つことは、実行してすべての場所。

## <a name="conclusion"></a>まとめ

調査で移植ここではアプリでは、複数のプロジェクト、クラス ライブラリ、およびしばらくたちますが大量のコードとユーザー インターフェイスを含む比較的複雑なものでした。 それでも、ポートは、単純な作業でした。 一部の移植の容易さは、windows 10 開発者向けプラットフォームと windows 8.1 および Windows Phone 8.1 のプラットフォーム間の類似性に直接起因します。 いくつかが元のアプリが、モデル、ビュー モデル、ビューを別々 に保管するように設計された方法は、原因です。
