---
author: martinekuan
ms.assetid: 03A74239-D4B6-4E41-B2FA-6C04F225B844
title: "Hello, world アプリを作成する (XAML)"
description: "このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な Hello, world アプリを Extensible Application Markup Language (XAML) を使って C# で作る方法について説明します。"
translationtype: Human Translation
ms.sourcegitcommit: 3de603aec1dd4d4e716acbbb3daa52a306dfa403
ms.openlocfilehash: 0a524d51f713c37ce2069b4e750bf3ed20fe19ab

---

# Hello, world アプリを作成する (XAML)

このチュートリアルでは、Windows 10 のユニバーサル Windows プラットフォーム (UWP) を対象にした単純な Hello, world アプリを Extensible Application Markup Language (XAML) を使って C# で作る方法について説明します。 Microsoft Visual Studio の 1 つのプロジェクトを使って、Windows 10 のすべてのデバイスで実行されるアプリを構築できます。 ここでは、デスクトップとモバイル デバイスで同じように適切に実行されるアプリを作ることに焦点を合わせます。


              **重要:** このチュートリアルは、Microsoft Visual Studio 2015 と Windows 10 で使うためのものです。 それ以前のバージョンでは正しく動作しません。

ここでは、次の方法について説明します。

-   Windows 10 と UWP を対象とする新しい Visual Studio プロジェクトを作る。
-   スタート ページに XAML コンテンツを追加する。
-   タッチ、ペン、マウス入力を処理する。
-   Visual Studio のローカル デスクトップと電話エミュレーターでプロジェクトを実行します。
-   さまざまなサイズの画面に UI を対応させます。

## はじめに...


-   このチュートリアルでは、簡単なユニバーサル アプリを作る手順だけを説明します。 そのため、このチュートリアルを始める前に、「[Windows 10 の開発者向け最新情報](https://dev.windows.com/whats-new-windows-10-dev-preview)」と「[ユニバーサル Windows アプリとは?](whats-a-uwp.md)」で概要について読み、理解しておくことを強くお勧めします。
-   このチュートリアルを行うには、Windows 10 と Visual Studio 2015 が必要です。 詳しくは、「[準備](get-set-up.md)」をご覧ください。
-   このトピックは、XAML と「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/Mt185595)」で説明されている概念について基本的な知識があることを前提としています。
-   また、Visual Studio の既定のウィンドウ レイアウトを使用することを前提としています。 既定のレイアウトを変更した場合は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** を使って、レイアウトをリセットできます。

##   手順 1: Visual Studio で新しいプロジェクトを作る


1.  Visual Studio 2015 を起動します。

   Visual Studio 2015 のスタート画面が表示されます。 (以下、Visual Studio 2015 を単に Visual Studio と表記します。)

2.  **[ファイル]** メニューの **[新規作成]** > **[プロジェクト]** の順にクリックします。

   **[新しいプロジェクト]** ダイアログ ボックスが表示されます。 ダイアログの左側のウィンドウで、表示するテンプレートの種類を選択できます。

3.  左側のウィンドウで、**[インストール済み]、[テンプレート]、[Visual C#]、[Windows]** の順に展開した後、**[ユニバーサル]** テンプレート グループを選びます。 ユニバーサル Windows プラットフォーム (UWP) アプリで使うことができるプロジェクト テンプレートの一覧がダイアログの中央のウィンドウに表示されます。

   ![[新しいプロジェクト] ウィンドウ ](images/newproject-cs.png)
   
   これらのオプションが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。 詳しくは、「[準備](get-set-up.md)」をご覧ください。

4.  中央のウィンドウで、**[空白のアプリ (ユニバーサル Windows)]** プロジェクト テンプレートを選びます。

   **[空白のアプリ]** テンプレートは、コンパイルして実行できる最小限の UWP アプリを作成しますが、ユーザー インターフェイス コントロールやデータは含まれていません。 コントロールは、このチュートリアルの途中でアプリに追加します。

5.  **[名前]** ボックスに「HelloWorld」と入力します。
6.  **[OK]** をクリックしてプロジェクトを作ります。

   Visual Studio によってプロジェクトが作られ、**ソリューション エクスプローラー**に表示されます。

   ![Visual Studio のソリューション エクスプローラーの HelloWorld プロジェクト](images/solutionexplorer-cs.png)

**[空白のアプリ]** は最小限のテンプレートですが、次の複数のファイルが含まれています。

-   アプリ (アプリの名前、説明、タイル、開始ページなど) を説明し、アプリに含まれるファイルを一覧表示するマニフェスト ファイル (Package.appxmanifest)。
-   スタート メニューに表示するロゴ イメージ (Assets/Square150x150Logo.scale-200.png、Assets/Square44x44Logo.scale-200.png、および Assets/Wide310x150Logo.scale-200.png) のセット。
-   Windows ストアに表示するアプリの画像 (Assets/StoreLogo.png)。
-   アプリが起動したときに表示するスプラッシュ画面 (Assets/SplashScreen.scale-200.png)。
-   アプリの XAML ファイルとコード ファイル (App.xaml と App.xaml.cs).
-   スタート ページ (MainPage.xaml) とそれに付随する、アプリの起動時に実行されるコード ファイル (MainPage.xaml.cs)。

これらのファイルは、C# を使うすべての UWP アプリに必要です。 Visual Studio で作るすべてのプロジェクトには、これらのファイルが必ず含まれます。

## 手順 2: スタート ページの変更


### ファイルの内容

プロジェクトのファイルを表示して編集するには、**ソリューション エクスプローラー**でファイルをダブルクリックします。 既定では、フォルダーと同様、XAML ファイルは展開して関連するコード ファイルを表示することができます。 XAML ファイルは、デザイン サーフェスと XAML エディターの両方を表示する分割ビューで開きます。

このチュートリアルでは、前に示した複数のファイルの一部 (App.xaml、MainPage.xaml、および MainPage.xaml.cs) のみを操作します。

### App.xaml と App.xaml.cs

App.xaml は、アプリ全体で使われるリソースを宣言するファイルです。 App.xaml.cs は、App.xaml のコード ビハインド ファイルです。 コード ビハインドは、XAML ページの部分クラスと結合されるコードです。 XAML とコード ビハインドがまとまって、完全なクラスが作成されます。 App.xaml.cs は、アプリのエントリ ポイントです。 すべてのコード ビハインド ページと同じように、`InitializeComponent` メソッドを呼び出すコンストラクターが含まれています。 `InitializeComponent` メソッドは自分で記述する必要はありません。 Visual Studio によって生成されるこのメソッドの主な目的は、XAML ファイルに宣言された要素を初期化することです。 App.xaml.cs には、アプリのアクティブ化と中断を処理するためのメソッドも含まれています。

### MainPage.xaml

MainPage.xaml には、アプリの UI を定義します。 要素の追加は、XAML マークアップを使って直接行うことも、Visual Studio のデザイン ツールを使って行うこともできます。 MainPage.xaml.cs は、MainPage.xaml のコード ビハインド ページです。 ここには、アプリのロジックとイベント ハンドラーを追加します。

これら 2 つのファイルで、[**Page**](https://msdn.microsoft.com/library/windows/apps/BR227503) から継承される `MainPage` という新しいクラスを `HelloWorld` 名前空間に定義します。

MainPage.xaml

```xml
    <Page
    x:Class="HelloWorld.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:HelloWorld"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    </Grid>
</Page>
```

MainPage.xaml.cs

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
```

### スタート ページの変更

次に、アプリにコンテンツを追加しましょう。

**スタート ページを変更するには**

1.  **ソリューション エクスプローラー**で、MainPage.xaml をダブルクリックして開きます。
2.  XAML エディターで、UI のコントロールを追加します。

   この XAML をルート [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) に追加します。 この XAML には、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) というタイトルを持つ [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635)、ユーザーの名前をたずねる **TextBlock**、ユーザーの名前を受け取る [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) 要素、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265)、あいさつを表示するもう 1 つの **TextBlock** が含まれます。 コード内で後から参照できるように、これらのコントロールのいくつかには名前が付いています。

```xml    
    <StackPanel x:Name="contentPanel" Margin="8,32,0,0">
        <TextBlock Text="Hello, world!" Margin="0,0,0,40"/>
        <TextBlock Text="What' s your name?"/>
        <StackPanel x:Name="inputPanel" Orientation="Horizontal" Margin="0,20,0,20">
            <TextBox x:Name="nameInput" Width="280" HorizontalAlignment="Left"/>
            <Button x:Name="inputButton" Content="Say &quot;Hello&quot;"/>
        </StackPanel>
        <TextBlock x:Name="greetingOutput"/>
    </StackPanel>
```    

    The controls that you added in the XAML editor show up in the design view.

## 手順 3: アプリを起動する


ここまでの操作で、非常に単純なアプリが作成されました。 ここで、アプリをビルド、デプロイ、起動してどうなるかを見てみましょう。 アプリは、ローカル コンピューター、シミュレーターかエミュレーター、またはリモート デバイスでデバッグできます。 Visual Studio の [ターゲット デバイス] メニューを示します。

![アプリをデバッグするデバイス ターゲットのドロップダウン リスト](images/uap-debug.png)

### デスクトップ デバイスでアプリを起動する

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

![アプリの初期画面](images/helloworld-1-cs.png)

Windows キーを押して **[スタート]** メニューを開き、すべてのアプリを表示します。 ローカルにデプロイしたアプリのタイルが **[スタート]** メニューに追加されています。 次にアプリを実行するときは (デバッグ モード以外で)、**[スタート]** メニューでこのタイルをタップまたはクリックします。

お疲れさまでした。これで、初めての UWP アプリの作成は完了です。

**デバッグを停止するには**

-   ツール バーの **[デバッグの停止]** ボタン (![[デバッグの停止] ボタン](images/stopdebug.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの停止]** をクリックします。

   または

   アプリ ウィンドウを閉じます。

### モバイル デバイス エミュレーターでアプリを起動する

アプリは、すべての Windows 10 デバイスで実行できます。Windows Phone ではどのようになるかを見てみましょう。

Visual Studio では、デスクトップ デバイスでデバッグするオプションに加えて、コンピューターに接続された物理的なモバイル デバイスにアプリをデプロイしてデバッグするか、モバイル デバイス エミュレーターでアプリをデプロイしてデバッグするオプションが用意されています。 メモリとディスプレイの構成がさまざまなデバイスのエミュレーターの中から選ぶことができます。

-   **デバイス**
-   **Emulator <SDK version> WVGA 4 inch 512MB**
-   **Emulator <SDK version> WVGA 4 inch 1GB**
-   その他... (他の構成のさまざまなエミュレーター)

エミュレーターが見つからない場合は、ユニバーサル Windows アプリ開発ツールがインストールされていることを確認します。 詳しくは、「[準備](get-set-up.md)」をご覧ください。

画面が小さくメモリが限られているデバイスでアプリをテストすることをお勧めします。そのためには、**[Emulator 10.0.10240.0 WVGA 4 inch 512MB]** オプションを使用します。
**モバイル デバイス エミュレーターでデバッグを開始するには**

1.  **[標準]** ツール バーの [ターゲット デバイス] メニュー (![[デバッグの開始] メニュー](images/startdebug-full.png)) で、**[Emulator 10.0.10240.0 WVGA 4 inch 512MB]** を選びます。
2.  ツール バーの **[デバッグの開始]** ボタン (![[デバッグの開始] ボタン](images/startdebug-sm.png)) をクリックします。

   または

   **[デバッグ]** メニューの **[デバッグの開始]** をクリックします。

   または

   F5 キーを押します。

Visual Studio で、選択したエミュレーターが起動し、アプリが展開されて起動されます。 モバイル デバイス エミュレーターでは、アプリは次のように表示されます。

![モバイル デバイスでのアプリの初期画面](images/helloworld-1-cs-phone.png)

最初に気付くことは、モバイル デバイスの小さい画面からボタンがはみ出していることです。 このチュートリアルの後半では、アプリを常に適切に表示するために、UI をさまざまな画面サイズに合わせて調整する方法を説明します。

また、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) に入力できていましたが、この時点では [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) をクリックまたはタップしても何も起こりません。 次の手順で、ユーザーに合わせたあいさつを表示する、ボタンの [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベント用のイベント ハンドラーを作成します。 イベント ハンドラーのコードは MainPage.xaml.cs ファイルに追加します。

## 手順 4: イベント ハンドラーの作成


XAML 要素は、特定のイベントが発生したときにメッセージを送信できます。 これらのイベント メッセージにより、イベントに応答してアクションを実行できます。 イベントに応答するためのコードをイベント ハンドラー メソッドに配置します。 多くのアプリに共通するイベントの 1 つは、ユーザーが [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) をクリックすることです。

ボタンの [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベント用のイベント ハンドラーを作成しましょう。 このイベント ハンドラーは、`nameInput`[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) コントロールからユーザー名を取得し、それを使ってあいさつを `greetingOutput`[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) に出力します。

### タッチ、マウス、ペン入力で動作するイベントの使用

処理する必要があるイベントは何でしょう。 Windows ストア アプリはさまざまなデバイスで実行される可能性があるため、タッチ入力を念頭に置いてアプリをデザインします。 アプリは、マウスまたはスタイラスからの入力も処理できる必要があります。 幸いなことに、[**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) や [**DoubleTapped**](https://msdn.microsoft.com/library/windows/apps/BR208922) などのイベントは、デバイスに依存しません。 Microsoft .NET プログラミングの知識がある場合は、マウス入力、タッチ入力、スタイラス入力用のイベント (**MouseMove**、**TouchMove**、**StylusMove** など) を見たことがある方がいると思います。 Windows ストア アプリでは、これらの個々のイベントは、タッチ入力、マウス入力、スタイラス入力のどれに対しても同じように機能する単一の [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/BR208970) イベントに置き換えられています。

**イベント ハンドラーを追加するには**

1.  XAML ビューまたはデザイン ビューで、MainPage.xaml に追加した "Say Hello" [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) を選びます。
2.  **プロパティ ウィンドウ**の [イベント] ボタン (![[イベント] ボタン](images/eventsbutton.png)) をクリックします。
3.  イベントの一覧の先頭にある [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベントを探します。 このイベントのテキスト ボックスに、**Click** イベントを処理する関数の名前を入力します。 この例では、「Button\_Click」と入力します。

   ![プロパティ ウィンドウのイベントの一覧](images/xaml-hw-event.png)

4.  Enter キーを押します。 イベント ハンドラー メソッドが作成され、イベントの発生時に実行されるコードを追加できるように、コード エディターに表示されます。

    XAML エディターでは、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) の XAML が更新されて、次のように [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) イベント ハンドラーが宣言されます。

```xml   
   <Button x:Name="inputButton" Content="Say &quot;Hello&quot;" Click="Button_Click"/>
```    

5.  コード ビハインド ページに作成したイベント ハンドラーにコードを追加します。 イベント ハンドラーで、`nameInput` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) コントロールからユーザー名を取得し、それを使ってあいさつを作ります。 `greetingOutput`[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) を使って結果を表示します。
    
```csharp    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        greetingOutput.Text = "Hello, " + nameInput.Text + "!";
    }
```    

6.  ローカル コンピューターでアプリをデバッグします。 テキスト ボックスに名前を入力してボタンをクリックすると、ユーザーに合わせたあいさつが表示されます。

## 手順 5: 異なるウィンドウ サイズに合わせて UI を調整する


次に、モバイル デバイスで適切に表示されるように、さまざまな画面サイズに合わせて UI を調整します。 これを行うには、[**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) を追加して、さまざまな表示状態に適用されるプロパティを設定します。

**UI レイアウトを調整するには**

1.  XAML エディターで、ルートの [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) 要素の開始タグの後に、この XAML ブロックを追加します。

```xml    
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState x:Name="wideState">
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="641" />
                </VisualState.StateTriggers>
            </VisualState>
            <VisualState x:Name="narrowState">
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="0" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="inputPanel.Orientation" Value="Vertical"/>
                    <Setter Target="inputButton.Margin" Value="0,4,0,0"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
```    

2.  ローカル コンピューターでアプリをデバッグします。 UI は、ウィンドウが 641 ピクセルより狭くならない限り、前と同じように表示されることに注意してください。
3.  モバイル デバイス エミュレーターでアプリをデバッグします。 `narrowState` で定義したプロパティが UI に使用され、小さい画面で適切に表示されていることに注意してください。

![モバイル アプリ画面](images/helloworld-2-cs-phone.png)

以前のバージョンの XAML で [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) を使ったことがある場合は、この XAML では簡素化された構文が使用されていることに気付くかもしれません。

`wideState` という名前の [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007) で、[**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) の [**MinWindowWidth**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) プロパティが 641 に設定されています。 これは、ウィンドウの幅が 641 ピクセルという最小値以上である場合に限って、状態が適用されることを意味します。 この状態には [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) オブジェクトを定義していないため、XAML でページのコンテンツに対して定義したレイアウト プロパティが使用されます。

2 つ目の [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007) である `narrowState` で、[**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) の [**MinWindowWidth**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) プロパティが 0 に設定されています。 この状態は、ウィンドウの幅が 0 より大きく 641 ピクセルより小さい場合に適用されます (641 ピクセルでは、`wideState` が適用されます)。この状態では、いくつかの [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) オブジェクトを設定して、UI のコントロールのレイアウト プロパティを変更します。

-   `inputPanel` 要素の [**Orientation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.orientation) を **Horizontal** から **Vertical** に変更します。
-   上余白 4 を `inputButton` 要素に追加します。

## 要約


これで、Windows 10 と UWP 用の初めてのアプリを作成しました。



<!--HONumber=Jul16_HO2-->


