---
author: stevewhims
ms.assetid: 88e16ec8-deff-4a60-bda6-97c5dabc30b8
description: このトピックでは機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 どこからでも Windows プラットフォーム (UWP) のアプリに移植のケース スタディが表示されます。
title: Windows の実行時に UWP のケース スタディ、QuizGame ピア ツー ピア サンプル アプリ 8.x
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5513a4536f4df77be93a099cf826d85212621622
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "303015"
---
# <a name="windows-runtime-8x-to-uwp-case-study-quizgame-sample-app"></a>Windows の実行時に UWP のケース スタディ 8.x: QuizGame サンプル アプリ




このトピックでは機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 どこからでも Windows プラットフォーム (UWP) のアプリに移植のケース スタディが表示されます。

ユニバーサル 8.1 のアプリが同じアプリの 2 つのバージョンを作成する: Windows 8.1 のいずれかのアプリのパッケージ化して Windows Phone 8.1 用の別のアプリ パッケージします。 QuizGame の WinRT 8.1 バージョンは、どこからでも Windows アプリ プロジェクトの配置を使用して、別の方法がかかり、2 つのプラットフォームの機能のアプリの作成します。 Windows 8.1 のアプリ パッケージとしてホスト クイズ ゲーム セッションは、Windows Phone 8.1 アプリ パッケージをホスト クライアントの役割の再生中にします。 クイズ ゲーム セッションの 2 つの要素は、ピア ツー ピア ネットワークを使って連絡します。

わかりやすくは、それぞれに、PC と電話番号、2 つの要素を調整します。 ほうも選択するには、ほとんどのデバイスでホストとクライアントの両方を実行する可能性のある場合ですか。 ここでは、調査場所は各構築にさまざまなデバイスにインストールできる 1 つのアプリ パッケージを Windows 10 に両方のアプリのポートはされます。

アプリでは、通話のビューを使用して、モデルを表示するパターンを使用します。 このを明確に分離、結果としてこのアプリの移植プロセスは非常に単純ですが表示されます。

**メモ** この例では送信または受信するユーザー設定の UDP にネットワークを構成する (ほとんどのホーム ネットワークには、社内ネットワークができないことがありますが) マルチ キャスト パケットをグループ化します。 また、サンプルは、送信し、TCP パケットを受け取ります。

 

**メモ**  「Visual Studio 更新が必要です」というメッセージが表示される場合は、Visual Studio で QuizGame10 を開く、ときに、次[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)」の手順を実行します。

 

## <a name="downloads"></a>ダウンロード

[QuizGame ユニバーサル 8.1 アプリをダウンロード](http://go.microsoft.com/fwlink/?linkid=532953)してください。 これは、アプリの移植よりも前の初期状態です。 

[Windows 10 アプリをダウンロード、QuizGame10](http://go.microsoft.com/fwlink/?linkid=532954)します。 移植した後に、このアプリの状態です。 

[このサンプル GitHub での最新バージョンを参照してください](https://github.com/Microsoft/Windows-appsample-quizgame)。

## <a name="the-winrt-81-solution"></a>WinRT 8.1 ソリューション


ここでは、どのような QuizGame などのアプリのポートを-ように表示されます。

![windows で実行されている quizgame ホストのアプリ](images/w8x-to-uwp-case-studies/c04-01-win81-how-the-host-app-looks.png)

Windows で実行されている QuizGame ホストのアプリ

 

![windows phone で実行されている quizgame クライアント アプリケーション](images/w8x-to-uwp-case-studies/c04-02-wp81-how-the-client-app-looks.png)

Windows Phone で実行されている QuizGame クライアント アプリケーション

## <a name="a-walkthrough-of-quizgame-in-use"></a>使用中の QuizGame のチュートリアル

これは、使用して、アプリの短い仮想的なアカウントが便利な情報を提供、ワイヤレス ネットワーク経由で自分用のアプリを試用する必要があります。

楽しいクイズ ゲームがバーで実行されています。 すべてのユーザーに表示されるバーには、大きな TV があります。 [Quizmaster TV の出力結果が表示されて、PC があります。 その PC"ホスト アプリをされて"が実行されています。 テストだけに参加する人は、アプリをインストール"クライアント"の電話または等高線グラフに必要があります。

ロビー モードでは、ホストのアプリと大きな TV のことが通知する準備ができましたクライアント アプリケーションを接続します。 ジャンヌは、自分のモバイル デバイスでクライアント アプリケーションを起動します。 アンナは [**プレーヤーの名前**] ボックスに自分の名前を入力して、**ゲームへの参加**をタップします。 ホストのアプリをジャンヌが自分の名前を表示することによってへの参加を示し、ジャンヌのクライアント アプリケーションを開始するゲームの待機していることを確認します。 次に、マックスウェルはモバイル デバイスでこれらの同じ手順を移動します。

[Quizmaster が**ゲームを開始**をクリックし、ホストのアプリは、質問と回答 (にも結合の選手の一覧に表示灰色での標準つ) が表示されます。 します。 同時に、回答が表示される結合のクライアント デバイス上のボタンに表示します。 ジャンヌに「1975」という解を] ボタンをタップしてされ、自分のすべてのボタンが無効になります。 ホスト アプリケーションでジャンヌの名緑色を描画 (および太字になります) で自分の応答の開封済みメッセージの受信を確認します。 マックスウェル回答もします。 全選手の名前は緑、ことを示す、quizmaster は、**次の質問**をクリックします。

質問は、送信され、この同じサイクルで応答するのに進みます。 ホスト アプリケーション最後の質問には、表示されているの場合は、ボタン、およびされない**次の質問**の内容は**結果を表示します**。 **結果の表示**をクリックすると、結果が表示されます。 **ロビーに戻る**] をクリックを返します。 参加していることを除いてゲーム ライフ サイクルの先頭にままプレーヤーに結合します。 しかし、ロビーに戻ってにより新しいプレイヤー結合の参加 (ただし、結合プレーヤーを**ゲームを終了**] をタップして、いつでもかまいません) のままにするための便利な時間、参加します。

## <a name="local-test-mode"></a>ローカル テスト モード

アプリと配分デバイスではなく 1 台の PC 上の相互作用には、ローカル テスト モードで、ホストのアプリを構築できます。 このモードは、ネットワークの使用を完全にバイパスします。 代わりに、ホストのアプリの UI のウィンドウの左側にホスト部分を表示して、クライアント アプリケーション UI の 2 つのコピーを縦に並んだ右側で、(メモ、このバージョンでは、ローカル テスト モード UI が固定 PC で表示します。 それに適応しない小型のデバイス)。 これらのセグメントを同じアプリ内のすべての UI のやり取りによる相互モック クライアント communicator、ネットワーク上の場所をそれ以外の場合の相互作用をシミュレートします。

ローカル テスト モードをアクティブに条件付きコンパイル記号として**LOCALTESTMODEON** (でプロジェクトのプロパティ) を定義し、[再構築します。

## <a name="porting-to-a-windows-10-project"></a>Windows 10 プロジェクトへの移植

QuizGame には、次の部分があります。

-   P2PHelper します。 これは、ピア ツー ピア ネットワーク ロジックを含むポータブル クラス ライブラリです。
-   QuizGame.Windows します。 これは、Windows 8.1 を対象にする、ホストのアプリのアプリ パッケージをビルドするプロジェクト。
-   QuizGame.WindowsPhone します。 これは、Windows Phone 8.1 を対象にする、クライアントのアプリのアプリ パッケージをビルドするプロジェクト。
-   QuizGame.Shared します。 これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。

このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。

これらのオプションに基づき、QuizGameHost と呼ばれる新しい Windows 10 プロジェクトに QuizGame.Windows をポートされます。 QuizGameClient と呼ばれる新しい Windows 10 プロジェクトに QuizGame.WindowsPhone をポートされます。 任意のデバイスで実行されるため、これらのプロジェクトは、どこからでもデバイス ファミリをターゲットします。 いきます、QuizGame.Shared ソース ファイルで独自のフォルダーと、2 つの新しいプロジェクトに共有ファイルにリンクしています。 前に、スクリプトを紹介するすべてのアイテムでは、1 つのソリューションという名前に QuizGame10 と同じようにします。

**QuizGame10 ソリューション**

-   新しいソリューションを作成する (**新しいプロジェクト** &gt; **その他のプロジェクトの種類** &gt; **Visual Studio ソリューション**)、QuizGame10 という名前を付けます。

**P2PHelper**

-   ソリューションでは、新しい Windows 10 のクラス ライブラリ プロジェクトを作成する (**新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **クラス ライブラリ (Windows ユニバーサル)**)、P2PHelper という名前を付けます。
-   新しいプロジェクト Class1.cs を削除します。
-   新しいプロジェクトのフォルダーに、P2PSession.cs、P2PSessionClient.cs、および P2PSessionHost.cs をコピーし、新しいプロジェクトにコピーしたファイルが含まれます。
-   プロジェクトをさらに変更がなくてもビルドします。

**共有ファイル**

-   一般的なモデル、ビュー、およびビューモデル フォルダーを \\QuizGame.Shared\\ から \\QuizGame10\\ にコピーします。
-   一般的な場合は、モデル、ビュー、およびビューモデルはされます意味上に共有フォルダーを参照します。

**QuizGameHost**

-   プロジェクトを作成する新しい Windows 10 アプリ (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**)、QuizGameHost という名前を付けます。
-   P2PHelper への参照を追加する (**[参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。
-   **ソリューション エクスプ ローラー**で各ディスク上の共有フォルダーの新しいフォルダーを作成します。 でき、作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存のアイテム**フォルダーを移動します。 適切な共有フォルダーを開き、すべてのファイルを選択し、[**リンクとして追加**] をクリックします。
-   \\QuizGame.Windows\\ から \\QuizGameHost\\ に MainPage.xaml をコピーし、QuizGameHost 名前空間に変更します。
-   \\QuizGame.Shared\\ から \\QuizGameHost\\ に App.xaml をコピーし、QuizGameHost 名前空間に変更します。
-   App.xaml.cs を上書きするには、代わりには、新しいプロジェクトでのバージョンを残すし、くださいローカル テスト モードをサポートするために 1 つの対象となる変更します。 App.xaml.cs] で、次のコード行を置き換えます。

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

-   **プロパティ**に&gt;**ビルド** &gt; **条件付きコンパイル記号と特殊文字**LOCALTESTMODEON を追加します。
-   App.xaml.cs に追加したコードに戻るし、TestView 型を解決できるようになりましたができます。
-   Package.appxmanifest] では、機能名を internetClient から internetClientServer に変更します。

**QuizGameClient**

-   プロジェクトを作成する新しい Windows 10 アプリ (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空のアプリケーション (Windows ユニバーサル)**)、QuizGameClient という名前を付けます。
-   P2PHelper への参照を追加する (**[参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**)。
-   **ソリューション エクスプ ローラー**で各ディスク上の共有フォルダーの新しいフォルダーを作成します。 でき、作成した各フォルダーを右クリックし、[**追加**] をクリックして&gt;**既存のアイテム**フォルダーを移動します。 適切な共有フォルダーを開き、すべてのファイルを選択し、[**リンクとして追加**] をクリックします。
-   \\QuizGame.WindowsPhone\\ から \\QuizGameClient\\ に MainPage.xaml をコピーし、QuizGameClient 名前空間に変更します。
-   \\QuizGame.Shared\\ から \\QuizGameClient\\ に App.xaml をコピーし、QuizGameClient 名前空間に変更します。
-   Package.appxmanifest] では、機能名を internetClient から internetClientServer に変更します。

今すぐことができますを作成して実行します。

## <a name="adaptive-ui"></a>アダプティブ UI

QuizGameHost Windows 10 アプリは、(これは大きなスクリーンを備えたデバイスでのみ)、ワイド ウィンドウで、アプリの実行時に問題が表示されます。 ときに、アプリのウィンドウ狭くが (する、小さなデバイスとも大きなデバイスで発生することができます)、UI を読みやすくがないことも禁止がします。

ここで説明するように、適応視覚的な状態マネージャー機能を使用して、、この問題を解決できますお[のケース スタディ: Bookstore2](w8x-to-uwp-case-study-bookstore2.md)します。 最初に、既定では、UI が狭い状態でレイアウトように、視覚的な要素のプロパティを設定します。 \\View\\HostView.xaml ですべての変更が行われます。

-   メイン]**グリッド**では、最初の**わかり**「140」から「自動」の**高さ**を変更します。
-   **TextBlock**が含まれている**グリッド**で、名前付き`pageTitle`、`x:Name="pageTitleGrid"`と`Height="60"`します。 最初の 2 つの手順を視覚的な状態の設定を使ってその**わかり**の高さを効率的に制御できます。
-   `pageTitle`、`Margin="-30,0,0,0"`します。
-   コメントで表示された**グリッド**上で`<!-- Content -->`、`x:Name="contentGrid"`と`Margin="-18,12,0,0"`します。
-   コメントのすぐ上の**TextBlock**で`<!-- Options -->`、`Margin="0,0,0,24"`します。
-   既定の**TextBlock**スタイル (ファイルの最初のリソース) には、「15」に**フォント サイズ**の設定の値を変更します。
-   `OptionContentControlStyle`、**フォント サイズ**の設定の値を「20」に変更します。 ここでは、前の 1 つはご意見ご感想のすべてのデバイスで動作する適切な型に傾斜します。 Windows 8.1 のアプリを使用していた「30」よりもより柔軟なサイズです。
-   最後に、**グリッド**のルートに適切な視覚的な状態マネージャー変更履歴とコメントを追加します。

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


Windows 10 の場合は、ボタンが、そのテンプレート内のスペース同じタッチ ターゲット必要がないことがわかります。 2 つの小さな変更を解決します。 まず、QuizGameHost と QuizGameClient の両方で app.xaml にこの変更履歴とコメントを追加します。

```xml
<Style TargetType="Button">
    <Setter Property="Margin" Value="12"/>
</Style>
```

次に、この設定を追加して`OptionButtonStyle`\\View\\ClientView.xaml にします。

```xml
<Setter Property="Margin" Value="6"/>
```

その最後の微調整にアプリの動作し、外観同じポートの前に、と、その他の値を持つことを実行場所でします。

## <a name="conclusion"></a>まとめ

事例で移植ここでは、アプリでは、複数のプロジェクト、クラス ライブラリ、および非常に大量のコードとユーザー インターフェイスを含む比較的複雑な 1 つをしました。 それでも、ポートの簡単なでした。 移植性の一部は直接 Windows 10 の開発プラットフォームおよび Windows 8.1 および Windows Phone 8.1 プラットフォーム間の類似性します。 一部が元のアプリケーションの設計されたモデル、モデルの表示、およびビューを別々 に保管する方法。
