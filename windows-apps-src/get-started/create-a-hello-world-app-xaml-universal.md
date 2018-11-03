---
author: GrantMeStrength
ms.assetid: 03A74239-D4B6-4E41-B2FA-6C04F225B844
title: "\"Hello, world\" アプリを作成する方法 (XAML)"
description: C# で Extensible Application Markup Language (XAML) を使用すると、windows 10 の対象とするユニバーサル Windows プラットフォーム (UWP) の単純なこんにちは, world アプリを作成できます。
ms.author: jken
ms.date: 03/06/2017
ms.topic: article
keywords: windows 10, uwp, 初めてのアプリ, hello world
ms.localizationpriority: medium
ms.openlocfilehash: d6fa9fa708df376edc94d34ea14d8dad4aed10df
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5990463"
---
# <a name="create-a-hello-world-app-xaml"></a>"Hello, world" アプリを作成する (XAML)

このチュートリアルは、XAML と c# を使って、シンプルなを作成する方法を教えて「こんにちは, world」アプリでは、windows 10 ユニバーサル Windows プラットフォーム (UWP) 用です。 Microsoft Visual Studio でプロジェクトを 1 つは、任意の windows 10 デバイスで実行されるアプリをビルドすることができます。

ここでは、次の方法について説明します。

-   **Windows 10**と**UWP**を対象とする新しい**Visual Studio 2017**プロジェクトを作成します。
-   スタート ページの UI を変更するように XAML を記述する。
-   Visual Studio のローカル デスクトップでプロジェクトを実行する。
-   SpeechSynthesizer を使って、ボタンが押されたときにアプリがコンテンツを読み上げるようにする。


## <a name="before-you-start"></a>はじめに...

-   [ユニバーサル Windows アプリとは?](universal-application-platform-guide.md)
-   [Visual Studio 2017 (および Windows 10) をダウンロードします](https://developer.microsoft.com/windows/downloads)。 サポートが必要な場合は、[セットアップする](get-set-up.md)方法をご覧ください。
-   また、Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。 既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。

> [!NOTE]
> このチュートリアルでは、Visual Studio Community 2017 を使います。 異なるバージョンの Visual Studio を使っている場合には、見た目が多少異なることがあります。

## <a name="video-summary"></a>ビデオの概要

<iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Writing-Your-First-Windows-10-App/player" width="640" height="360" allowFullScreen frameBorder="0"></iframe>



## <a name="step-1-create-a-new-project-in-visual-studio"></a>手順 1. Visual Studio で新しいプロジェクトを作る

1.  Visual Studio 2017 を起動します。

2.  **[ファイル**] メニューから選択**新規 > プロジェクト**を*新しいプロジェクト*] ダイアログを開きます。

3.  左側のテンプレートの一覧で、選択**インストール済み > Visual C#] > Windows ユニバーサル**UWP プロジェクト テンプレートの一覧を表示します。

    ユニバーサル テンプレートが表示されない場合は、UWP アプリを作成するためのコンポーネントがない可能性があります。 インストール プロセスを繰り返して UWP サポートを追加することもできます (*[新しいプロジェクト]* ダイアログで **[Visual Studio インストーラーを開く]** をクリック)。 参照[を取得する設定](get-set-up.md))。

    ![インストール プロセスを繰り返す方法](images/win10-cs-install.png)

4.  **[空白のアプリ (ユニバーサル Windows)]** テンプレートを選択し、**[名前]** に「HelloWorld」と入力します。 **[OK]** を選択します。

    ![[新しいプロジェクト] ウィンドウ](images/win10-cs-01.png)

> [!NOTE]
> Visual Studio を初めて使う場合は、[設定] ダイアログ ボックスが表示され、**開発者モード**を有効にするよう求められることがあります。 開発者モードは、アプリをストアからだけではなく、直接実行するためのアクセス許可など、特定の機能を有効にする特別な設定です。 詳しくは、「[デバイスを開発用に有効にする](enable-your-device-for-development.md)」をご覧ください。 先に進むには、**[開発者モード]** を選択し、**[はい]** をクリックしてダイアログ ボックスを閉じます。

 ![開発者モードのアクティブ化ダイアログ](images/win10-cs-00.png)

5.  ターゲット バージョンと最小バージョンのダイアログが表示されます。 このチュートリアルでは既定の設定で問題ないため、**[OK]** を選択してプロジェクトを作成します。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-02.png)

6.  新しいプロジェクトが開き、そのプロジェクトのファイルが右側の**ソリューション エクスプローラー**のウィンドウに表示されます。 場合によっては、ファイルを表示するために **[ソリューション エクスプローラー]** タブを選択する必要があります (**[プロパティ]** タブではありません)。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-03.png)

**[空白のアプリ (ユニバーサル Windows)]** は最小限のテンプレートですが、多くのファイルが含まれています。 これらのファイルは、C# を使うすべての UWP アプリに必要です。 Visual Studio で作るすべてのプロジェクトには、これらのファイルが必ず含まれます。


### <a name="whats-in-the-files"></a>ファイルの内容

プロジェクトのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。 フォルダーと同様、XAML ファイルを展開して、関連するコード ファイルを表示します。 XAML ファイルは、デザイン サーフェスと XAML エディターの両方を表示する分割ビューで開きます。
> [!NOTE]
> XAML とは Extensible Application Markup Language (XAML) は、アプリのユーザー インターフェイスを定義するための言語です。 XAML は、手動で入力することも、Visual Studio のデザイン ツールを使って作成することもできます。 .xaml ファイルには、ロジックが格納される .xaml.cs 分離コード ファイルがあります。 XAML と分離コードがまとまって、完全なクラスが作成されます。 詳しくは、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/Mt185595)」をご覧ください。

*App.xaml と App.xaml.cs*

-   App.xaml は、アプリ全体で使われるリソースを宣言するファイルです。
-   App.xaml.cs は、App.xaml の分離コード ファイルです。 すべての分離コード ページと同じように、`InitializeComponent` メソッドを呼び出すコンストラクターが含まれています。 `InitializeComponent` メソッドは自分で記述する必要はありません。 Visual Studio によって生成されるこのメソッドの主な目的は、XAML ファイルに宣言された要素を初期化することです。
-   App.xaml.cs は、アプリのエントリ ポイントです。
-   App.xaml.cs には、[アクティブ化](../launch-resume/activate-an-app.md)と、アプリの[中断](../launch-resume/suspend-an-app.md)を処理するメソッドも含まれています。

*MainPage.xaml*

-   MainPage.xaml は、アプリの UI を定義する場所です。 要素の追加は、XAML マークアップを使って直接行うことも、Visual Studio のデザイン ツールを使って行うこともできます。
-   MainPage.xaml.cs は、MainPage.xaml のコード ビハインド ページです。 ここには、アプリのロジックとイベント ハンドラーを追加します。
-   これら 2 つのファイルで、[**Page**](https://msdn.microsoft.com/library/windows/apps/BR227503) から継承される `MainPage` という新しいクラスを `HelloWorld` 名前空間に定義します。

*Package.appxmanifest*
-   名前、説明、タイル、開始ページなど、アプリを説明するマニフェスト ファイルです。
-   依存関係、リソースと、アプリが含まれているファイルの一覧が含まれます。

*一連のロゴ イメージ*
-   Assets/Square150x150Logo.scale-200.png と Wide310x150Logo.scale 200.png は、[スタート] メニューで、アプリ (中] または [ワイド サイズ) を表します。
-   Assets/Square44x44Logo.png は、[スタート] メニューのタスク バーとタスク マネージャーのアプリの一覧でアプリを表します。
-   Assets/StoreLogo.png は、Microsoft Store 内のアプリを表します。
-   Assets/SplashScreen.scale-200.png は、アプリが起動したときに表示するスプラッシュ画面です。
-   システムがロックされているときに、ロック画面上のアプリを表す Assets/LockScreenLogo.scale-200.png を使用できます。

## <a name="step-2-adding-a-button"></a>手順 2. ボタンを追加する

### <a name="using-the-designer-view"></a>デザイナー ビューの使用

ページにボタンを追加しましょう。 このチュートリアルでは、前に示した複数のファイルの一部 (App.xaml、MainPage.xaml、および MainPage.xaml.cs) のみを操作します。

1.  **MainPage.xaml** をダブルクリックしてデザイン ビューで開きます。

    画面の上部にグラフィック ビュー、その下部に XAML コード ビューがあります。 どちらのビューでも変更を加えることができますが、ここではグラフィック ビューを使います。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-04.png)

2.  左側の縦方向に配置された **[ツールボックス]** タブをクリックして UI コントロールの一覧を開きます  (タイトル バーのピン アイコンをクリックすると、このウィンドウを表示したままにすることができます)。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-05.png)

3.  **[コモン XAML コントロール]** を展開し、**Button** をドラッグしてデザイン キャンバスの中央に配置します。

    ![ソリューション エクスプローラーのウィンドウ](images/win10-cs-06.png)

    XAML コード ウィンドウを見ると、そこにも Button が追加されたことがわかります。

 ```XAML
<Button x:name="button" Content="Button" HorizontalAlignment="Left" Margin = "152,293,0,0" VerticalAlignment="Top"/>
 ```

4.  ボタンのテキストを変更します。

    XAML コード ビュー内をクリックし、Content の値を "Button" から "Hello, world!" に変更します。

```XAML
<Button x:name="button" Content="Hello, world!" HorizontalAlignment="Left" Margin = "152,293,0,0" VerticalAlignment="Top"/>
```

デザイン キャンバスに表示されたボタンが更新され、新しいテキストが表示されることがわかります。

![ソリューション エクスプローラーのウィンドウ](images/win10-cs-07.png)

## <a name="step-3-start-the-app"></a>手順 3. アプリを起動する


ここまでの操作で、非常に単純なアプリが作成されました。 ここで、アプリをビルド、デプロイ、起動してどうなるかを見てみましょう。 アプリは、ローカル コンピューター、シミュレーターかエミュレーター、またはリモート デバイスでデバッグできます。 Visual Studio の [ターゲット デバイス] メニューを示します。

![アプリをデバッグするデバイス ターゲットのドロップダウン リスト](images/uap-debug.png)

### <a name="start-the-app-on-a-desktop-device"></a>デスクトップ デバイスでアプリを起動する

既定では、アプリはローカル コンピューターで実行されます。 [ターゲット デバイス] メニューには、デスクトップ デバイス ファミリのデバイスでアプリをデバッグするためのいくつかのオプションが用意されています。

-   **シミュレーター**
-   **ローカル コンピューター**
-   **リモート コンピューター**

**ローカル コンピューターでデバッグを開始するには**

1.  **[標準]** ツール バーの [ターゲット デバイス] メニュー (![[デバッグの開始] メニュー](images/startdebug-full.png)) で、**[ローカル コンピューター]** が選択されていることを確認します  (既定で選択されています)。
2.  ツール バーの **[デバッグの開始]** ボタン (![[デバッグの開始] ボタン](images/startdebug-sm.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの開始]** をクリックします。

   または

   F5 キーを押します。

アプリがウィンドウで開かれ、最初に既定のスプラッシュ画面が表示されます。 スプラッシュ画面は、画像 (SplashScreen.png) と背景色によって定義されます (背景色はアプリのマニフェスト ファイルに指定します)。

スプラッシュ画面が消えた後、アプリが表示されます。 次のようになります。

![アプリの初期画面](images/win10-cs-08.png)

Windows キーを押して **[スタート]** メニューを開き、すべてのアプリを表示します。 ローカルに配置したアプリのタイルが **[スタート]** メニューに追加されています。 後でもう一度 (デバッグ モード以外で) アプリを実行するときは、**[スタート]** メニューでこのタイルをタップまたはクリックします。

お疲れさまでした。これで、初めての UWP アプリの作成は完了です。

**デバッグを停止するには**

   ツール バーの **[デバッグの停止]** ボタン (![[デバッグの停止] ボタン](images/stopdebug.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの停止]** をクリックします。

   - または -

   アプリ ウィンドウを閉じます。

## <a name="step-4-event-handlers"></a>手順 4. イベント ハンドラー

"イベント ハンドラー" は複雑なもののように聞こえますが、イベント (ユーザーによるボタンのクリックなど) が発生したときに呼び出されるコードの別名にすぎません。

1.  アプリの実行を停止します (まだ停止していない場合)。

2.  デザイン キャンバス上のボタン コントロールをダブルクリックします。Visual Studio によってボタンのイベント ハンドラーが作成されます。

  もちろん、すべてのコードを手動で作成することもできます。 または、ボタンをクリックして選択し、右下の **[プロパティ]** ウィンドウを確認します。 **[イベント]** (小さな稲妻) に切り替えると、イベント ハンドラーの名前を追加することができます。

3.  *MainPage.xaml.cs* (分離コード ページ) でイベント ハンドラーを編集します。 ここから面白くなります。 既定のイベント ハンドラーは次のようになります。

```C#
private void Button_Click(object sender, RoutedEventArgs e)
{

}
```

  これを変更して次のようにします。

```C#
private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello, World!");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
```

**async** キーワードも含めるようにしてください。そうしないと、アプリを実行しようとしたときにエラーが表示されます。

### <a name="what-did-we-just-do"></a>ここで実行したこと

このコードでは、いくつか Windows API を使用して音声合成オブジェクトを作成し、読み上げるテキストを指定します  (SpeechSynthesis の使い方について詳しくは、[SpeechSynthesis 名前空間](https://msdn.microsoft.com/library/windows/apps/windows.media.speechsynthesis.aspx)のドキュメントをご覧ください)。

アプリを実行し、ボタンをクリックすると、コンピューター (または電話) が "Hello, World!" を文字どおりにしゃべります。


## <a name="summary"></a>まとめ

これで、windows 10 と UWP の初めてのアプリを作成しました。

アプリで使うコントロールを XAML によってレイアウトする方法については、[グリッドに関するチュートリアル](../design/layout/grid-tutorial.md)で学習するか、直接[次のステップ](learn-more.md)に進んでください。

## <a name="see-also"></a>関連項目

* [初めてのアプリ](your-first-app.md)
* [UWP アプリを公開する](https://developer.microsoft.com/store/publish-apps)
* [UWP アプリの開発に関するハウツー記事](https://developer.microsoft.com/windows/apps/develop)
* [UWP 開発者向けコード サンプル](https://developer.microsoft.com/windows/samples)
* [ユニバーサル Windows アプリとは?](universal-application-platform-guide.md)
* [Windows アカウントのサインアップ](sign-up.md)
