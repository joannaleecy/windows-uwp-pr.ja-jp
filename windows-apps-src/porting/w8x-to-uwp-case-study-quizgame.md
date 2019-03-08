---
ms.assetid: 88e16ec8-deff-4a60-bda6-97c5dabc30b8
description: このトピックでは、機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリへの移植のケース スタディを表示します。
title: Windows ランタイム 8.x から UWP へのケース スタディ - QuizGame ピア ツー ピアのサンプル アプリ
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d2d1b2b4e6875730d5a6bfa8dd711e11ac5d049c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642917"
---
# <a name="windows-runtime-8x-to-uwp-case-study-quizgame-sample-app"></a>Windows ランタイム 8.x UWP の事例に。QuizGame サンプル アプリ




このトピックでは、機能しているピア ツー ピア クイズ ゲーム WinRT 8.1 サンプル アプリを Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリへの移植のケース スタディを表示します。

8.1 ユニバーサル アプリは、同じアプリの 2 つのバージョンをビルドする 1 つ。 1 つのアプリ パッケージの Windows 8.1、および Windows Phone 8.1 用の別のアプリ パッケージ。 QuizGame の WinRT 8.1 バージョンでは、ユニバーサル Windows アプリ プロジェクトに用意されているデータを使いますが、独自の方法が採用されており、2 つのプラットフォームに対して機能的に異なるアプリがビルドされます。 Windows 8.1 アプリ パッケージでは、クイズ ゲーム セッションのホストとして機能、Windows Phone 8.1 アプリ パッケージをホストに、クライアントの役割の再生中にします。 クイズ ゲーム セッションの 2 つの要素は、ピア ツー ピア ネットワークを経由して通信します。

これら 2 つの要素を PC や電話向けにそれぞれ調整することで、適切なアプリを作ることができます。 また、必要となるほとんどのデバイスでホストとクライアントの両方を実行できたら、より便利ではないでしょうか。 ここで調査では、それらが各ビルド場所をユーザーがさまざまなデバイスにインストールできる 1 つのアプリ パッケージに Windows 10 に両方のアプリを移植します。

アプリでは、ビューとビュー モデルを使うパターンを採用します。 このパターンではビューとビュー モデルが明確に分離されているため、以下の説明をご覧になるとわかりますが、このアプリの移植プロセスは非常に簡単です。

**注**  このサンプルは、カスタムの UDP を送受信するネットワークが構成されている前提としています。 マルチキャスト パケット数 (ほとんどのホーム ネットワークは、職場のネットワークができない可能性がありますが) をグループ化します。 また、このサンプルでは TCP パケットを送受信します。

 

**注**  とき"Visual Studio の更新に必要な"メッセージを表示する場合は、Visual Studio で、QuizGame10 を開いてし、手順に従います[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)します。

 

## <a name="downloads"></a>ダウンロード

[QuizGame ユニバーサル 8.1 アプリをダウンロードします](https://go.microsoft.com/fwlink/?linkid=532953)。 これは、移植前の初期状態のアプリです。 

[Windows 10 アプリのダウンロード、QuizGame10](https://go.microsoft.com/fwlink/?linkid=532954)します。 これは、移植直後の状態のアプリです。 

[このサンプルの最新バージョンについては GitHub をご覧ください](https://github.com/Microsoft/Windows-appsample-quizgame)。

## <a name="the-winrt-81-solution"></a>WinRT 8.1 ソリューション


次に、ここで移植するアプリ QuizGame の外観を示します。

![Windows で実行されている QuizGame ホスト アプリ](images/w8x-to-uwp-case-studies/c04-01-win81-how-the-host-app-looks.png)

Windows で実行されている QuizGame ホスト アプリ

 

![Windows Phone で実行されている QuizGame クライアント アプリ](images/w8x-to-uwp-case-studies/c04-02-wp81-how-the-client-app-looks.png)

Windows Phone で実行されている QuizGame クライアント アプリ

## <a name="a-walkthrough-of-quizgame-in-use"></a>このケース スタディで使う QuizGame のチュートリアル

ここで使うアプリの簡単な説明を示します。これは架空のアプリの説明ですが、ワイヤレス ネットワークでアプリを使う場合に役立つ情報も記載されています。

楽しいクイズ ゲームがバーで行われています。 バーには大型テレビがあり、全員がそのテレビを見ることができます。 クイズ番組の司会者は PC を使っており、その出力画面が TV に映し出されています。 その PC では "ホスト アプリ" が実行されています。 クイズへの参加を希望する視聴者は、"クライアント アプリ" を自分の携帯電話や Surface にインストールするだけです。

ホスト アプリはロビー モードになっており、大型テレビでは、クライアント アプリ接続の準備ができていることを通知しています。 Joan は、モバイル デバイスでクライアント アプリを起動します。 彼女は、**[Player name] (プレーヤー名)** テキスト ボックスに自分の名前を入力してから **[Join game] (ゲームに参加)** をタップします。 ホスト アプリでは Joan の名前が表示され、彼女の参加が認識されました。また、Joan のクライアント アプリでは、ゲームの開始を待機していることが示されています。 次に、Maxwell が同じ手順を自分のモバイル デバイスで実行しました。

クイズ番組の司会者が **[Start game] (ゲームの開始)** をクリックすると、ホスト アプリには質問と正しいと思われる回答がいくつか表示されます (参加しているプレイヤーの一覧も表示されます。この一覧では、フォントの太さは通常、色は灰色で表示されます)。 同時に、参加しているクライアント デバイスでは、回答がボタンで表示されます。 Joan は "1975" と示されている回答のボタンをタップしました。するとすぐに、すべてのボタンが無効になりました。 ホスト アプリでは、Joan の名前が太字の緑色で表示され、彼女の回答が受信されたことが示されました。 Maxwell の回答しました。 クイズ番組の司会者はすべてプレーヤーの名前が緑色になったことを確認して、**[Next question] (次の質問)** をクリックしました。

引き続き、同じ手順で質問の表示と回答が繰り返されました。 最後の質問がホスト アプリに表示されると、ボタンの内容は **[Next question] (次の質問)** ではなく、**[Show results] (結果の表示)** となりました。 **[Show results] (結果の表示)** をクリックすると、結果が表示されました。 **[Return to lobby] (ロビーに戻る)** をクリックすると、ゲームのライフ サイクルの最初に戻りますが、プレイヤーは参加したままになります。 ただし、ロビーに戻ると、新しいプレイヤーが参加できるようになります。このとき、参加していたプレイヤーはゲームの参加をやめることができます (**[Leave game] (ゲームの参加をやめる)** をタップすることで、参加しているプレイヤーはいつでもゲームをやめることができます)。

## <a name="local-test-mode"></a>ローカル テスト モード

アプリとその操作を、(複数のデバイスに分散された状態ではなく) 1 台の PC でテストする場合は、ローカル テスト モードでホスト アプリをビルドできます。 このモードでは、ネットワークはまったく使われません。 代わりに、ホスト アプリの UI では、ウィンドウの左側にはホスト部分の画面が表示され、右側にはクライアント アプリの UI をコピーした 2 つの画面が上下に並べて表示されます (このバージョンでは、ローカル テスト モードの UI は PC のディスプレイ用に固定されており、小型のデバイスには対応していません)。 UI のこれらのセグメント (すべて同じアプリに属しています) は、モック クライアント コミュニケーターを経由して相互に通信します。このコミュニケーターは、ネットワークを通じて実行される操作をシミュレートします。

ローカル テスト モードを有効にするには、**LOCALTESTMODEON** (プロジェクトのプロパティ) を条件付きコンパイル シンボルとして定義して、リビルドします。

## <a name="porting-to-a-windows10-project"></a>Windows 10 プロジェクトへの移植

QuizGame には、次の要素が含まれています。

-   P2PHelper。 これは、ピア ツー ピアのネットワーク ロジックを含むポータブル クラス ライブラリです。
-   QuizGame.Windows。 これは、ホストのアプリでは、Windows 8.1 を対象とするアプリ パッケージをビルドするプロジェクトです。
-   QuizGame.WindowsPhone。 これは、Windows Phone 8.1 を対象とするクライアント アプリのアプリ パッケージをビルドするプロジェクトです。
-   QuizGame.Shared。 これは、他の 2 つのプロジェクトの両方で使われるソース コード、マークアップ ファイル、および他のアセットやリソースを含むプロジェクトです。

このケース スタディでは、サポートするデバイスに関して、「[ユニバーサル 8.1 アプリがある場合](w8x-to-uwp-root.md)」で説明した通常のオプションを使います。

これらのオプションに基づき、QuizGameHost と呼ばれる新しい Windows 10 プロジェクトへ QuizGame.Windows のポートがいます。 また、QuizGame.WindowsPhone QuizGameClient と呼ばれる新しい Windows 10 プロジェクトに移植しました。 これらのプロジェクトはユニバーサル デバイス ファミリを対象としているため、どのようなデバイスでも実行できます。 また、QuizGame.Shared ソース ファイルなどのファイルを独自のフォルダーに保存し、これらの共有ファイルを 2 つの新しいプロジェクトにリンクします。 これまでと同様に、すべてのデータを 1 つのソリューションに保存し、QuizGame10 という名前を付けます。

**QuizGame10 ソリューション**

-   新しいソリューションを作成 (**新しいプロジェクト** &gt; **その他のプロジェクトの種類** &gt; **Visual Studio ソリューション**) QuizGame10 名前を付けます。

**P2PHelper**

-   ソリューションでは、新しい Windows 10 クラス ライブラリ プロジェクトを作成します (**新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **クラス ライブラリ (Windows ユニバーサル)**) P2PHelper 名前を付けます。
-   新しいプロジェクトから Class1.cs を削除します。
-   P2PSession.cs、P2PSessionClient.cs、P2PSessionHost.cs を新しいプロジェクトのフォルダーにコピーし、コピーしたファイルを新しいプロジェクトに追加します。
-   プロジェクトをビルドします。その他の変更は必要ありません。

**共有ファイル**

-   一般的なモデル、ビュー、およびビューモデルからフォルダーをコピー \\QuizGame.Shared\\に\\QuizGame10\\します。
-   Common、Model、View、ViewModel は、ディスク上の共有フォルダーを参照するときに意味のある名前です。

**QuizGameHost**

-   新しい Windows 10 アプリ プロジェクトの作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空白アプリケーション (Windows ユニバーサル)**) QuizGameHost 名前を付けます。
-   P2PHelper への参照の追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**).
-   **ソリューション エクスプ ローラー**で、ディスク上の各共有フォルダー用に新しいフォルダーを作成します。 さらに、作成した各フォルダーを右クリックし、クリックして**追加** &gt; **既存項目の**フォルダーを移動します。 適切な共有フォルダーを開き、すべてのファイルを選んで、**[リンクとして追加]** をクリックします。
-   MainPage.xaml からコピー \\QuizGame.Windows\\に\\QuizGameHost\\ QuizGameHost を名前空間を変更します。
-   App.xaml からコピー \\QuizGame.Shared\\に\\QuizGameHost\\ QuizGameHost を名前空間を変更します。
-   app.xaml.cs を上書きせずに、このファイルのバージョンを新しいプロジェクトに保存しておきます。ローカル テスト モードをサポートするように、対象となる変更を 1 つだけそのファイルに加えます。 app.xaml.cs で、次のコード行を置き換えます。

```CSharp
rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

上のコード行を次のコード行と置き換えます。

```CSharp
#if LOCALTESTMODEON
    rootFrame.Navigate(typeof(TestView), e.Arguments);
#else
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
#endif
```

-   **プロパティ** &gt; **ビルド** &gt; **条件付きコンパイル シンボル**LOCALTESTMODEON を追加します。
-   これで、app.xaml.cs に追加したコードに戻り、TestView 型を解決できます。
-   package.appxmanifest で、機能名を internetClient から internetClientServer に変更します。

**QuizGameClient**

-   新しい Windows 10 アプリ プロジェクトの作成 (**追加** &gt; **新しいプロジェクト** &gt; **Windows ユニバーサル** &gt; **空白アプリケーション (Windows ユニバーサル)**) QuizGameClient 名前を付けます。
-   P2PHelper への参照の追加 (**参照の追加** &gt; **プロジェクト** &gt; **ソリューション** &gt; **P2PHelper**).
-   **ソリューション エクスプ ローラー**で、ディスク上の各共有フォルダー用に新しいフォルダーを作成します。 さらに、作成した各フォルダーを右クリックし、クリックして**追加** &gt; **既存項目の**フォルダーを移動します。 適切な共有フォルダーを開き、すべてのファイルを選んで、**[リンクとして追加]** をクリックします。
-   MainPage.xaml からコピー \\QuizGame.WindowsPhone\\に\\QuizGameClient\\ QuizGameClient を名前空間を変更します。
-   App.xaml からコピー \\QuizGame.Shared\\に\\QuizGameClient\\ QuizGameClient を名前空間を変更します。
-   package.appxmanifest で、機能名を internetClient から internetClientServer に変更します。

これで、ビルドして実行することができます。

## <a name="adaptive-ui"></a>アダプティブ UI

(これは、大画面のデバイスでのみ)、ワイド ウィンドウで、アプリが実行されているときに、QuizGameHost Windows 10 アプリは問題ないようです。 ただし、アプリのウィンドウが狭い場合は (小型のデバイスが該当しますが、大型のデバイスの場合もあり得ます)、UI がかなり縮小され、認識するのが難しくなります。

説明したように、これを修正するアダプティブ Visual State Manager 機能を使用しましたできます[ケース スタディ。Bookstore2](w8x-to-uwp-case-study-bookstore2.md)します。 最初に、既定で UI が幅の狭い状態でレイアウトされるように、視覚要素のプロパティを設定します。 これらすべての変更が行わ\\ビュー\\HostView.xaml します。

-   メインの **Grid** で、最初の **RowDefinition** の **Height** を、"140" から "Auto" に変更します。
-   `pageTitle` という名前の **TextBlock** を含んでいる **Grid** で、`x:Name="pageTitleGrid"` と `Height="60"` を設定します。 最初の 2 つの手順は、表示状態の setter を使って **RowDefinition** の高さを効果的に制御できるようにするための手順です。
-   `pageTitle` で、`Margin="-30,0,0,0"` を設定します。
-   コメント `<!-- Content -->` で示されている **Grid** で、`x:Name="contentGrid"` と `Margin="-18,12,0,0"` を設定します。
-   コメント `<!-- Options -->` のすぐ上にある **TextBlock** で、`Margin="0,0,0,24"` を設定します。
-   既定の **TextBlock** スタイル (ファイル内の最初のリソース) で、**FontSize** setter の値を "15" に変更します。
-   `OptionContentControlStyle` で、**FontSize** setter の値を "20" に変更します。 この手順と前の手順によって、すべてのデバイスで適切に動作する優れた書体見本を使うことができます。 これらは、Windows 8.1 アプリに使用した「30」よりもサイズが非常に優れた柔軟性です。
-   最後に、適切な Visual State Manager のマークアップをルートの **Grid** に追加します。

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


Windows 10 では、ボタンが、そのテンプレート内のスペース同じタッチ ターゲット必要がないことがわかります。 小規模な変更を 2 つ行うことによって、この問題が解決されます。 最初に、QuizGameHost と QuizGameClient の両方の app.xaml に、次のマークアップを追加します。

```xml
<Style TargetType="Button">
    <Setter Property="Margin" Value="12"/>
</Style>
```

第 2 に、このに set アクセス操作子を追加および`OptionButtonStyle`で\\ビュー\\ClientView.xaml します。

```xml
<Setter Property="Margin" Value="6"/>
```

上に示した最後の調整を行うことで、アプリの動作と外観が移植前と同じになります。また、アプリはどのデバイスでも実行できるという機能が追加されます。

## <a name="conclusion"></a>まとめ

このケース スタディで移植したアプリは、複数のプロジェクト、1 つのクラス ライブラリ、および多くのコードやユーザー インターフェイスを含んでいるため、比較的複雑なアプリになっています。 それでも、移植は非常に簡単に行われました。 移植の容易さの一部は、Windows 10 開発プラットフォームと Windows 8.1 および Windows Phone 8.1 プラットフォーム間の類似性に起因する直接します。 また、元のアプリがモデル、ビュー モデル、およびビューを別個に維持するように設計されていたことも、その原因の 1 つです。
