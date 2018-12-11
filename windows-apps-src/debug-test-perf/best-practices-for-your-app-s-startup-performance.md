---
ms.assetid: 00ECF6C7-0970-4D5F-8055-47EA49F92C12
title: アプリ起動時のパフォーマンスのベスト プラクティス
description: 起動とアクティブ化を処理する方法を向上させることによって、最適な起動時間のユニバーサル Windows プラットフォーム (UWP) アプリを作成します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e9d0fdee4ba9f44f15c461e5a53dad28700023a4
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8827287"
---
# <a name="best-practices-for-your-apps-startup-performance"></a>アプリ起動時のパフォーマンスのベスト プラクティス


起動とアクティブ化を処理する方法を向上させることによって、最適な起動時間のユニバーサル Windows プラットフォーム (UWP) アプリを作成します。

## <a name="best-practices-for-your-apps-startup-performance"></a>アプリ起動時のパフォーマンスのベスト プラクティス

ユーザーがアプリを速いまたは遅いと判断する要因の 1 つとして、アプリの起動にかかる時間があります。 このトピックの目的上、アプリの起動時間は、ユーザーがアプリを開始した際に始まり、ユーザーがアプリに対して何らかの意図を持つ操作を開始できるようになった時点で終わるものとします。 このセクションでは、アプリ起動時のパフォーマンスを向上させるための推奨事項を紹介します。

### <a name="measuring-your-apps-startup-time"></a>アプリの起動時間の測定

アプリを数回起動してから、実際に起動時間を測定するようにしてください。 これによって測定のベースラインが確立され、起動時間を合理的に可能な限り短縮できます。

UWP アプリがユーザーのコンピューターに届くまで、アプリは .NET ネイティブ ツール チェーンを使ってコンパイルされてきました。 .NET ネイティブは、MSIL をネイティブに実行可能なマシン コードに変換する事前コンパイル テクノロジです。 .NET ネイティブ アプリは、MSIL アプリに比べて、すばやく起動し、メモリ使用量やバッテリ使用量は少なくなります。 .NET ネイティブを使ってビルドされたアプリケーションはカスタム ランタイムおよびあらゆるデバイスで実行できる新しい集約型の .NET Core にリンクされるため、インボックスの .NET の実装に依存しません。 開発コンピューターで、既定では、アプリを "リリース" モードでビルドしている場合、アプリは .NET ネイティブを使用し、"デバッグ" モードでビルドしている場合、アプリは CoreCLR を使用します。 Visual Studio では、[プロパティ] の [ビルド] ページ (C# の場合) または [マイ プロジェクト] の [コンパイル] -> [詳細設定] (VB の場合) でこれを構成できます。 [.NET ネイティブ ツール チェーンでコンパイルする] というチェック ボックスを探します。

当然、エンド ユーザーが一般的に経験する起動時間を測定する必要があります。 そのため、開発コンピューターでアプリをネイティブ コードにコンパイルしていることを確認していない場合は、起動時間を測定する前に、ネイティブ イメージ ジェネレーター (Ngen.exe) ツールを実行してアプリをプリコンパイルすることができます。

次の手順では、Ngen.exe を実行してアプリをプリコンパイルする方法について説明します。

**Ngen.exe を実行するには**

1.  少なくとも 1 回アプリを実行して、Ngen.exe にアプリを検出させます。
2.  次のいずれかの方法で**タスク スケジューラ**を開きます。
    -   スタート画面で「タスク スケジューラ」を検索します。
    -   taskschd.msc を実行します。
3.  **タスク スケジューラ**の左ウィンドウで **[タスク スケジューラ ライブラリ]** を展開します。
4.  **[Microsoft]** を展開します。
5.  **[Windows]** を展開します。
6.  **[.NET Framework]** を展開します。
7.  タスクの一覧から **[.NET Framework NGEN 4.x]** を選択します。

    64 ビット コンピューターを使っている場合は、**[.NET Framework NGEN v4.x 64]** も表示されます。 64 ビット アプリを開発している場合は、**[NET Framework NGEN v4.x 64]** を選択します。

8.  **[操作]** メニューの **[実行]** をクリックします。

Ngen.exe は、使用されたことがありネイティブ イメージを持たない、コンピューター上のすべてのアプリをプリコンパイルします。 プリコンパイルが必要なアプリが多い場合には時間がかかりますが、その後の実行時間が大幅に高速化されます。

アプリが再コンパイルされると、ネイティブ イメージは使われなくなります。 一方、アプリをジャスト イン タイムでコンパイルする場合は、アプリは実行時にコンパイルされます。 新しいネイティブ イメージを取得するためには Ngen.exe をもう一度実行する必要があります。

### <a name="defer-work-as-long-as-possible"></a>可能な限りの処理の遅延

アプリの起動時間を短縮するには、ユーザーがアプリの操作を開始するために絶対に必要な処理だけを実行します。 これが特に有効なのは、追加のアセンブリの読み込みを遅延できる場合です。 共通言語ランタイムを最初に使用する際に、アセンブリが読み込まれます。 ここで読み込まれるアセンブリの数を最小化できれば、アプリの起動時間とメモリ消費を改善できる場合があります。

### <a name="do-long-running-work-independently"></a>長時間の処理の個別実行

アプリが部分的に機能していない場合でも、アプリで操作を受け付けることができます。 たとえば、アプリが表示するデータの取得に時間がかかっている場合に、データを非同期で取得することによって、そのコードをアプリの起動コードとは別に実行できます。 データが利用できる状態であれば、アプリのユーザー インターフェイスにデータを表示することができます。

データを取得するユニバーサル Windows プラットフォーム (UWP) API の多くは非同期であるため、その状態でも、ほとんどの場合はデータが非同期で取得されます。 非同期 API について詳しくは、「[C# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/Mt187337)」をご覧ください。 非同期 API を使わない処理を実行する場合、Task クラスを使って長時間の処理を実行することで、ユーザーによるアプリの操作がブロックされないようにすることができます。 これによってデータの読み込み中もアプリの応答性が維持されます。

アプリによる UI の一部の読み込みで特に長い時間がかかっている場合、ユーザーにアプリが処理中であることを通知する "最新データの取得中" などの文字列を該当する領域に追加することを検討してください。

## <a name="minimize-startup-time"></a>起動時間の最小化

非常にシンプルなアプリを除くほとんどのアプリでは、アクティブ化の際に、リソースを読み込む、XAML を解析する、データ構造をセットアップする、ロジックを実行するという一連の処理に、ユーザーが気付くレベルの時間が必要です。 ここでは、アクティブ化のプロセスを 3 つのフェーズに分けて見ていきます。 また、各フェーズにかかる時間を短縮するためのヒントのほか、アプリの起動の各フェーズを調整し、ユーザーに受け入れられるようにする方法も紹介します。

アクティブ化期間とは、ユーザーがアプリを起動してからアプリが機能するまでの時間のことです。 これは、ユーザーがアプリから受ける第一印象となるため、重要な時間です。 ユーザーは、システムやアプリから途切れることなく即座にフィードバックが返ってくることを求めています。 アプリの起動が遅いと、システムやアプリが壊れているか、設計が不完全と受け取られます。 そのうえ、アプリのアクティブ化に時間がかかりすぎると、プロセス有効期間マネージャー (PLM) によってアプリが強制終了されることや、ユーザーがアプリをアンインストールすることさえあります。

### <a name="introduction-to-the-stages-of-startup"></a>起動の各段階の概要

起動には、多くの移動要素があり、最適なユーザー エクスペリエンスのためにそのすべてを正しく調整する必要があります。 次の手順は、ユーザーがアプリのタイルをクリックしてから、アプリケーションのコンテンツが表示されるまでの間に発生します。

-   Windows シェルがプロセスを開始し、Main が呼び出されます。
-   Application オブジェクトが作成されます。
    -   (プロジェクト テンプレート) コンストラクターが InitializeComponent を呼び出し、これにより App.xaml が解析され、オブジェクトが作成されます。
-   Application.OnLaunched イベントが発生します。
    -   (ProjectTemplate) アプリ コードがフレームを作成し、MainPage に移動します。
    -   (ProjectTemplate) メインページのコンストラクターが InitializeComponent を呼び出し、これにより MainPage.xaml が解析され、オブジェクトが作成されます。
    -   ProjectTemplate) Window.Current.Activate() が呼び出されます。
-   XAML プラットフォームが、測定と配置を含むレイアウト パスを実行します。
    -   ApplyTemplate によって、各コントロールについてコントロール テンプレートのコンテンツが作成されます。これは、通常、起動のレイアウトの時間の大部分を占めます。
-   Render が呼び出されて、すべてのウィンドウのコンテンツの視覚効果が作成されます。
-   デスクトップ ウィンドウ マネージャー (DWM) にフレームが表示されます。

### <a name="do-less-in-your-startup-path"></a>起動パスでの処理を少なくする

起動コード パスには、最初のフレームで不要なものは含めないでください。

-   最初のフレームで不要なコントロールが含まれているユーザー dll を使っている場合は、読み込みを遅らせることを検討します。
-   UI の一部をクラウドからデータに依存している場合は、その UI を分割します。 最初に、クラウド データに依存しない UI を表示し、非同期的にクラウドに依存する UI を表示します。 アプリケーションがオフラインで動作したり、低速ネットワーク接続に影響されないようにするために、データをローカルにキャッシュすることも検討します。
-   UI がデータを待機している場合は、進行状況 UI を表示します。
-   大量の構成ファイルの解析やコードにより動的に生成される UI が含まれているアプリの設計には注意してください。

### <a name="reduce-element-count"></a>要素数の削減

XAML アプリの起動時のパフォーマンスは、起動時に作成する要素の数に直接関連しています。 作成する要素が少ないほど、アプリの起動時間は短くなります。 大まかなベンチマークとしては、各要素の作成に 1 ミリ秒かかることを考慮します。

-   項目コントロールで使用されるテンプレートは、何度も繰り返されるため、最も大きな影響を受けます。 「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」をご覧ください。
-   UserControl とコントロール テンプレートが展開されるため、これらも考慮する必要があります。
-   画面に表示されない任意の XAML を作成する場合、XAML のそれらの部分を起動時に作成する必要があるかどうかを判断する必要があります。

[Visual Studio のライブ ビジュアル ツリー](http://blogs.msdn.com/b/visualstudio/archive/2015/02/24/introducing-the-ui-debugging-tools-for-xaml.aspx) には、ツリー内の各ノードの子要素数が示されます。

![ライブ ビジュアル ツリー。](images/live-visual-tree.png)

**延期を使用します**。 要素を折りたたむか、不透明度を 0 に設定すると、要素は作成されなくなります。 x:Load または x:DeferLoadStrategy を使って、UI の要素の読み込みを遅らせて、必要に応じて読み込むことができます。 これは、起動画面に表示されない UI の処理を遅延させ、必要に応じて読み込んだり、遅延させた一連のロジックの一部として読み込む場合に適した方法です。 読み込みをトリガーするために必要なことは、要素の FindName を呼び出すことだけです。 詳しい説明と例については、「[x:Load 属性](../xaml-platform/x-load-attribute.md)」と「[x:DeferLoadStrategy 属性](https://msdn.microsoft.com/library/windows/apps/Mt204785)」をご覧ください。

**仮想化**。 UI に一覧またはリピーター コンテンツがある場合、UI の仮想化を使うことを強くお勧めします。 一覧の UI が仮想化されていない場合、すべての要素を作成するコストを前払いすることになり、起動が遅くなる可能性があります。 「[ListView と GridView の UI の最適化](optimize-gridview-and-listview.md)」をご覧ください。

アプリケーションのパフォーマンスには、生のパフォーマンスだけでなく、印象も関連します。 視覚的側面が最初に実行されるように処理の順序を変更すると、ユーザーにアプリケーションが高速であるという印象を与えます。 ユーザーは、画面にコンテンツが表示されると、アプリケーションが読み込まれたと見なします。 一般的には、アプリケーションは起動処理の一環として複数の処理を実行する必要がありますが、そのすべてが UI を表示する必要はないため、そのような処理は遅延させたり、UI よりも優先順位を下げたりする必要があります。

このトピックでは、アニメーション/テレビに由来する "最初のフレーム" について説明します。これは、エンド ユーザーに対してコンテンツが表示されるまでの時間を測定する方法です。

### <a name="improve-startup-perception"></a>起動時の印象の改善

それでは、簡単なオンライン ゲームの例を使って、起動の各フェーズを示した後、プロセス全体を通じてユーザーにフィードバックを返すさまざまな手法を紹介します。 この例の場合、アクティブ化の最初のフェーズは、ユーザーがゲームのタイルをタップしてからゲームがコードの実行を開始するまでの時間になります。 この間、システムには、正しいゲームが起動したことを示すためにユーザーに表示するコンテンツがありません。 ただし、スプラッシュ画面を指定することによって、このコンテンツをシステムに提供できます。 次に、ゲームがコードの実行を開始すると、動かないスプラッシュ画面をアプリ独自の UI に置き換えて、アクティブ化の最初のフェーズが完了したことをユーザーに示します。

アクティブ化の 2 番目のフェーズでは、ゲームにとって重要な構造の作成と初期化を行います。 アクティブ化の最初のフェーズの後に、利用できるデータを使って最初の UI をすばやく作成できれば、2 番目のフェーズは短時間で終わり、UI をすぐに表示できます。 それができない場合は、初期化中に読み込みページを表示することをお勧めします。

読み込みページはどのようなものでもかまいません。単純に進行状況バーや進行状況リングを表示することもできます。 重要な点は、アプリがタスクを実行していて、まだ応答できないことを示すことです。 ゲームの場合は、初期画面を表示することがありますが、その UI のために画像やサウンドをディスクからメモリに読み込む必要があります。 これらのタスクには数秒かかるため、スプラッシュ画面を、ゲームのテーマに沿った簡単なアニメーションを表示する読み込みページに置き換えて、ユーザーにアプリの情報を提供し続けます。

読み込みページを置き換える対話型 UI を作成するための最小限の情報が準備できると、3 番目のフェーズが開始します。 この時点でオンライン ゲームが使うことができる情報は、ディスクからアプリに読み込まれているコンテンツだけです。 対話型 UI を作成できるだけの十分なコンテンツをゲームに組み込むこともできますが、これはオンライン ゲームであるため、インターネットに接続して追加情報をダウンロードするまで機能しません。 機能するために必要なすべての情報が準備できるまでの間、ユーザーは UI を操作できますが、Web からの追加データを必要とする機能については、コンテンツがまだ読み込み中であることを示すフィードバックを返す必要があります。 アプリが完全に機能するまでには、多少時間がかかる場合があります。そのため、できるだけ早く機能を使えるようにすることが重要です。

これでオンライン ゲームにおけるアクティブ化の 3 つのフェーズを特定できたので、次にそれらを実際のコードと結び付けて考えてみましょう。

### <a name="phase-1"></a>フェーズ 1

アプリが起動する前に、スプラッシュ画面として表示するものをシステムに通知する必要があります。 それには、例に示すように、アプリのマニフェストの SplashScreen 要素に画像と背景色を指定します。 アプリがアクティブ化を開始すると、それが Windows によって表示されます。

```xml
<Package ...>
  ...
  <Applications>
    <Application ...>
      <VisualElements ...>
        ...
        <SplashScreen Image="Images\splashscreen.png" BackgroundColor="#000000" />
        ...
      </VisualElements>
    </Application>
  </Applications>
</Package>
```

詳しくは、「[スプラッシュ画面の追加](https://msdn.microsoft.com/library/windows/apps/Mt187306)」をご覧ください。

アプリのコンストラクターを使って、アプリにとって重要なデータ構造だけを初期化します。 コンストラクターは、最初にアプリを実行したときにのみ呼び出されます。アプリがアクティブ化されるたびに必ず呼び出されるわけではありません。 たとえば、既に実行され、バックグラウンドで動いているアプリが検索コントラクトを介してアクティブ化された場合、コンストラクターは呼び出されません。

### <a name="phase-2"></a>フェーズ 2

アプリはさまざまな理由でアクティブ化され、それぞれの対応を変えることが必要になる場合があります。 [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/BR242330)、[**OnCachedFileUpdaterActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701797)、[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/BR242331)、[**OnFileOpenPickerActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701799)、[**OnFileSavePickerActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701801)、[**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/BR242335)、[**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/BR242336)、[**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/Hh701806) メソッドを上書きして、さまざまなアクティブ化の理由に対応することができます。 アプリがこれらのメソッドで実行する必要がある作業の 1 つが UI を作成して [**Window.Content**](https://msdn.microsoft.com/library/windows/apps/BR209051) に割り当て、[**Window.Activate**](https://msdn.microsoft.com/library/windows/apps/BR209046) を呼び出すことです。 この時点で、スプラッシュ画面が、アプリによって作成された UI に置き換えられます。 ここで表示するものは、読み込み画面でも、アクティブ化時に実際の UI を作成するための十分な情報を利用できる場合は、アプリの実際の UI でもかまいません。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> public partial class App : Application
> {
>     // A handler for regular activation.
>     async protected override void OnLaunched(LaunchActivatedEventArgs args)
>     {
>         base.OnLaunched(args);
> 
>         // Asynchronously restore state based on generic launch.
> 
>         // Create the ExtendedSplash screen which serves as a loading page while the
>         // reader downloads the section information.
>         ExtendedSplash eSplash = new ExtendedSplash();
> 
>         // Set the content of the window to the extended splash screen.
>         Window.Current.Content = eSplash;
> 
>         // Notify the Window that the process of activation is completed
>         Window.Current.Activate();
>     }
> 
>     // a different handler for activation via the search contract
>     async protected override void OnSearchActivated(SearchActivatedEventArgs args)
>     {
>         base.OnSearchActivated(args);
> 
>         // Do an asynchronous restore based on Search activation
> 
>         // the rest of the code is the same as the OnLaunched method
>     }
> }
> 
> partial class ExtendedSplash : Page
> {
>     // This is the UIELement that's the game's home page.
>     private GameHomePage homePage;
> 
>     public ExtendedSplash()
>     {
>         InitializeComponent();
>         homePage = new GameHomePage();
>     }
> 
>     // Shown for demonstration purposes only.
>     // This is typically autogenerated by Visual Studio.
>     private void InitializeComponent()
>     {
>     }
> }
> ```
> ```vb
>     Partial Public Class App
>     Inherits Application
> 
>     ' A handler for regular activation.
>     Protected Overrides Async Sub OnLaunched(ByVal args As LaunchActivatedEventArgs)
>         MyBase.OnLaunched(args)
> 
>         ' Asynchronously restore state based on generic launch.
> 
>         ' Create the ExtendedSplash screen which serves as a loading page while the
>         ' reader downloads the section information.
>         Dim eSplash As New ExtendedSplash()
> 
>         ' Set the content of the window to the extended splash screen.
>         Window.Current.Content = eSplash
> 
>         ' Notify the Window that the process of activation is completed
>         Window.Current.Activate()
>     End Sub
> 
>     ' a different handler for activation via the search contract
>     Protected Overrides Async Sub OnSearchActivated(ByVal args As SearchActivatedEventArgs)
>         MyBase.OnSearchActivated(args)
> 
>         ' Do an asynchronous restore based on Search activation
> 
>         ' the rest of the code is the same as the OnLaunched method
>     End Sub
> End Class
> 
> Partial Friend Class ExtendedSplash
>     Inherits Page
> 
>     Public Sub New()
>         InitializeComponent()
> 
>         ' Downloading the data necessary for 
>         ' initial UI on a background thread.
>         Task.Run(Sub() DownloadData())
>     End Sub
> 
>     Private Sub DownloadData()
>         ' Download data to populate the initial UI.
> 
>         ' Create the first page. 
>         Dim firstPage As New MainPage()
> 
>         ' Add the data just downloaded to the first page
> 
>         ' Replace the loading page, which is currently 
>         ' set as the window's content, with the initial UI for the app
>         Window.Current.Content = firstPage
>     End Sub
> 
>     ' Shown for demonstration purposes only.
>     ' This is typically autogenerated by Visual Studio.
>     Private Sub InitializeComponent()
>     End Sub
> End Class 
> ```

アクティブ化ハンドラーで読み込みページを表示するアプリは、バックグラウンドで UI の作成作業を開始します。 その要素が作成されると、[**FrameworkElement.Loaded**](https://msdn.microsoft.com/library/windows/apps/BR208723) イベントが発生します。 このイベント ハンドラーで、現在は読み込み画面になっているウィンドウのコンテンツを、新しく作成したホーム ページに置き換えます。

初期化時間が長いアプリの場合は読み込みページを表示することが重要です。 アクティブ化プロセスに関するユーザー フィードバックを返すこととは別に、アクティブ化プロセスの開始から 15 秒以内に [**Window.Activate**](https://msdn.microsoft.com/library/windows/apps/BR209046) が呼び出されないと、プロセスは終了されます。

> [!div class="tabbedCodeSnippets"]
> ```csharp
> partial class GameHomePage : Page
> {
>     public GameHomePage()
>     {
>         InitializeComponent();
> 
>         // add a handler to be called when the home page has been loaded
>         this.Loaded += ReaderHomePageLoaded;
> 
>         // load the minimal amount of image and sound data from disk necessary to create the home page.        
>     }
>     
>     void ReaderHomePageLoaded(object sender, RoutedEventArgs e)
>     {
>         // set the content of the window to the home page now that it's ready to be displayed.
>         Window.Current.Content = this;
>     }
> 
>     // Shown for demonstration purposes only.
>     // This is typically autogenerated by Visual Studio.
>     private void InitializeComponent()
>     {
>     }
> }
> ```
> ```vb
>     Partial Friend Class GameHomePage
>     Inherits Page
> 
>     Public Sub New()
>         InitializeComponent()
> 
>         ' add a handler to be called when the home page has been loaded
>         AddHandler Me.Loaded, AddressOf ReaderHomePageLoaded
> 
>         ' load the minimal amount of image and sound data from disk necessary to create the home page.        
>     End Sub
> 
>     Private Sub ReaderHomePageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
>         ' set the content of the window to the home page now that it's ready to be displayed.
>         Window.Current.Content = Me
>     End Sub
> 
>     ' Shown for demonstration purposes only.
>     ' This is typically autogenerated by Visual Studio.
>     Private Sub InitializeComponent()
>     End Sub
> End Class
> ```

追加スプラッシュ画面の使用例については、[スプラッシュ画面のサンプル](http://go.microsoft.com/fwlink/p/?linkid=234889)をご覧ください。

### <a name="phase-3"></a>フェーズ 3

アプリに UI が表示されたからといって、アプリが完全に使える状態になったわけではありません。 このゲームの場合は、インターネットからのデータを必要とする機能に対してプレースホルダーを使って UI を表示します。 この時点で、アプリが完全に機能するために必要な追加データがゲームにダウンロードされ、データを取得するたびに機能が段階的に有効になります。

アクティブ化に必要なコンテンツの多くがアプリにパッケージされている場合があります。 単純なゲームなどがそうです。 このようにすると、アクティブ化プロセスが非常に単純になります。 しかし、多くのプログラム (ニュース リーダー、フォト ビューアーなど) では、機能するために Web から情報を取得する必要があります。 こうしたデータは大きく、ダウンロードするのにかなりの時間がかかる場合があります。 アプリがアクティブ化プロセス中にこうしたデータを取得する方法によっては、アプリの体感的なパフォーマンスに大きく影響することがあります。

アクティブ化のフェーズ 1 または 2 で、機能するために必要なデータ セット全体をダウンロードしようとして、読み込みページ (さらに悪い場合は、スプラッシュ画面) を数分間表示すると、 アプリがハングしているように見えたり、システムによって終了されたりします。 フェーズ 2 ではプレースホルダー要素を使って対話型 UI を表示するための最小限のデータをダウンロードし、フェーズ 3 でプレースホルダー要素を置き換えるデータを段階的に読み込むことをお勧めします。 データの処理について詳しくは、「[ListView と GridView の最適化](optimize-gridview-and-listview.md)」をご覧ください。

起動の各フェーズにどれだけ厳密に対応するかはまったくの任意ですが、できるだけ多くのフィードバック (スプラッシュ画面、読み込み画面、データの読み込み中の UI) をユーザーに提供すると、ユーザーはアプリとシステム全体が軽快だと感じます。

### <a name="minimize-managed-assemblies-in-the-startup-path"></a>スタートアップ パス内のマネージ アセンブリを最小限に抑える

多くの場合、再利用可能なコードは、プロジェクトに含まれるモジュール (DLL) の形で提供されます。 こうしたモジュールを読み込むには、ディスクにアクセスする必要があります。それには、当然負荷が発生します。 これにより、コールド起動に大きな影響が及びますが、ウォーム起動にも影響が及ぶ場合があります。 C# と Visual Basic の場合、CLR はアセンブリをオンデマンドで読み込むことで、その負荷の発生をできるだけ遅らせようとします。 つまり、モジュールは実行されたメソッドによって参照されるまで読み込まれません。 そのため、CLR によって不要なモジュールが読み込まれないように、スタートアップ コードではアプリの起動に必要なアセンブリだけを参照するようにします。 スタートアップ パス内の使われないコード パスに不必要な参照が含まれている場合は、それらのコード パスを別のメソッドに移動すると、不必要な読み込みを回避できます。

また、アプリ モジュールを結合して、モジュールの読み込みを減らすこともできます。 一般的に、2 つの小さなアセンブリよりも、1 つの大きなアセンブリの方が短い時間で読み込むことができます。 常に短くなるわけではないため、開発者の生産性やコードの再利用性に実質的な違いがない場合にのみ、モジュールを結合してください。 [PerfView](http://go.microsoft.com/fwlink/p/?linkid=251609) や [Windows Performance Analyzer (WPA)](https://msdn.microsoft.com/library/windows/apps/xaml/ff191077.aspx) などのツールを使うと、起動時に読み込まれるモジュールを調べることができます。

### <a name="make-smart-web-requests"></a>効率的に Web 要求を行う

XAML や画像など、アプリに重要なファイルをローカルでパッケージ化することで、アプリの読み込み時間を大幅に短縮できます。 ネットワーク操作よりも、ディスク操作の方が処理が速くなります。 アプリの初期化時に特定のファイルが必要な場合は、ファイルをリモート サーバーから取得する代わりに、ディスクから読み取ることで起動時間全体を短縮できます。

## <a name="journal-and-cache-pages-efficiently"></a>効率的なジャーナルとページのキャッシュ

Frame コントロールには、ナビゲーション機能が用意されています。 このコントロールは、ページへのナビゲーション (Navigate メソッド)、ナビゲーションのジャーナル (BackStack/ForwardStack プロパティ、GoForward/GoBack メソッド)、ページのキャッシュ (Page.NavigationCacheMode)、およびシリアル化のサポート (GetNavigationState メソッド) を提供します。

フレームについて注意が必要なパフォーマンスは、主に、ジャーナルとページのキャッシュに関連するものです。

**フレーム ジャーナル**。 Frame.Navigate() を使ってページに移動すると、現在のページの PageStackEntry が Frame.BackStack コレクションに追加されます。 PageStackEntry は比較的小さいサイズですが、BackStack コレクションのサイズに組み込みの制限はありません。 ユーザーはループ内を移動することができ、このコレクションは無制限に増大する可能性があります。

PageStackEntry には、Frame.Navigate() メソッドに渡されたパラメーターも含まれます。 Frame.GetNavigationState() メソッドを使用するために、このパラメーターをシリアル化できるプリミティブ型 (int や string など) にすることをお勧めします。 ただし、このパラメーターは、大量のワーキング セットやその他のリソースの原因となるオブジェクトを参照している可能性があり、BackStack の各エントリのコストがそれだけ高くなります。 たとえば、パラメーターとして StorageFile を使用できますが、その結果、BackStack には開いた無数のファイルが保持されます。

したがって、ナビゲーション パラメーターを小さくし、BackStack のサイズを制限することが推奨されます。 BackStack は、標準ベクター (C# では IList、C++/CX では Platform::Vector) であるため、エントリを削除するだけでトリミングできます。

**ページのキャッシュ**。 既定では、Frame.Navigate メソッドを使ってページに移動すると、ページの新しいインスタンスがインスタンス化されます。 同様に、Frame.GoBack で前のページに戻ると、前のページの新しいインスタンスが割り当てられます。

ただし、Frame には、これらのインスタンス化を回避できる、オプションのページ キャッシュが用意されています。 ページをキャッシュに保存するには、Page.NavigationCacheMode プロパティを使います。 このモードを Required に設定するとページは強制的にキャッシュに保存され、Enabled に設定するとページのキャッシュへの保存が許可されます。 既定では、キャッシュのサイズは 10 ページですが、Frame.CacheSize プロパティを使ってオーバーライドすることができます。 Required ページはすべてキャッシュされ、Required ページが CacheSize よりも少ない場合は、Enabled ページもキャッシュすることができます。

ページをキャッシュすると、インスタンス化が回避され、ナビゲーションのパフォーマンスが向上することにより、パフォーマンス面のメリットとなる可能性があります。 ページのキャッシュが過剰になると、ワーキング セットに影響を及ぼすため、パフォーマンスが低下する可能性があります。

したがって、アプリケーションで適切なページのキャッシュを使用することをお勧めします。 たとえば、アプリがフレームに項目の一覧を表示する場合、項目をタップすると、アプリはフレームをその項目の詳細ページに移動します。 この一覧ページは、キャッシュするように設定することをお勧めします。 詳細ページがすべての項目で同じである場合、このページもキャッシュすることをお勧めします。 ただし、詳細ページの種類が異なる場合は、キャッシュを無効のままにしておくことをお勧めします。
