---
author: Karl-Bridge-Microsoft
Description: "Cortana の音声コマンド、音声認識、音声合成を使って、アプリに音声操作を組み込むことができます。"
title: "Surface Dial の操作"
label: Surface Dial interactions
template: detail.hbs
keywords: "Surface Dial, Windows ホイール, RadialController, ラジアル コントローラー, ユーザーの操作, 入力"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: eb86863d6ce2e545b3e534ef6cafb220904e3dc8
ms.openlocfilehash: 96b9a2e213c36b8f92664185e9cdcaea6d457368

---

# <a name="surface-dial-interactions"></a>Surface Dial の操作

![Surface Dial と Surface Studio の画像](images/windows-wheel/dial-pen-studio-600px.png)  
*Surface Dial と Surface Studio、Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacedial)で購入できます)。

## <a name="overview"></a>概要

Surface Dial などの Windows Wheel デバイスは、Windows や Windows アプリで魅力的でユニークなユーザー操作エクスペリエンスを実現する、新しいカテゴリの入力デバイスです。 

> [!IMPORTANT]
> このトピックでは、特に Surface Dial の操作について説明しますが、情報はすべての Windows Wheel デバイスに適用されます。

| ビデオ |   |
| --- | --- |
| <iframe width="300" height="200" src="https://www.youtube.com/embed/WMklcdzcNcU" frameborder="0" allowfullscreen></iframe> | <iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Programming-the-Microsoft-Surface-Dial/player" width="300" height="200" allowFullScreen frameBorder="0"></iframe> |
| *Surface Dial のアプリ パートナー* | *開発者向けの Surface Dial* |

*回転*動作 (またはジェスチャ) に基づくフォームファクタを持つ Surface Dial は、プライマリ デバイスからの入力を補完または変更する、セカンダリのマルチ モーダル入力デバイスとして設計されています。 このデバイスは多くの場合、ユーザーが利き手でタスクを実行している間に (たとえばペンでインク操作をするときなど)、利き手ではない手で操作されます。 高精度のポインター入力 (タッチ、ペン、マウスなど) 用に設計されていません。 

Surface Dial は、*長押し*アクションと*クリック*アクションもサポートしています。 長押しの機能は 1 つで、コマンドのメニューを表示します。 メニューがアクティブになっている場合、回転とクリックの入力はメニューによって処理されます。 それ以外の場合、入力は、処理のためにアプリに渡されます。 

**Windows の他の入力デバイスと同様に、アプリの機能に合わせて Surface Dial の操作エクスペリエンスをカスタマイズおよび調整できます。**

> [!TIP]
> Surface Dial と新しい Surface Studio を一緒に使うことによって、さらに独創的なユーザー エクスペリエンスを提供できます。  
>
>先ほど説明した既定の長押しメニューのエクスペリエンスに加えて、Surface Dial は Surface Studio の画面上に直接配置できます。 これにより、特殊な "オンスクリーン" メニューが実現されます。 
>
>Surface Dial の接触位置と境界の両方を検出することにより、システムはこの情報を使用してデバイスによるオクルージョンを処理し、Dial の外側を囲むように大きいバージョンのメニューを表示します。 この同じ情報をアプリで使用して、デバイスの存在とその予想される使用状況 (ユーザーの手や腕の配置など) の両方に合わせて UI を調整することもできます。

| Surface Dial のオフスクリーン メニュー | | Surface Dial のオンスクリーン メニュー |
| --- | --- | --- |
| ![Surface Dial のオフスクリーン メニュー](images/windows-wheel/surface-dial-menu-offscreen.png) | | ![Surface Dial のオンスクリーン メニュー](images/windows-wheel/surface-dial-menu-onscreen.png) |

## <a name="system-integration"></a>システム統合

Surface Dial は Windows と緊密に統合されており、システム ボリューム、スクロール、拡大/縮小、元に戻す/やり直しなど、一連の組み込みツールをメニューでサポートしています。

この組み込みツールのコレクションは、現在のシステム コンテキストに合わせて調整され、次のような機能が追加されます。
- ユーザーが Windows デスクトップ システムで作業する場合のシステムの明るさツール
- メディアの再生中の前または次のトラック ツール

この一般的なプラットフォームのサポートに加えて、Surface Dial は Windows Ink プラットフォームのコントロール ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) や [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar)) とも緊密に統合されています。

![Surface Dial と Surface ペン](images/windows-wheel/dial-and-pen-400px.png)  
*Surface Dial と Surface ペン*

Surface Dial と共に使用する場合、これらのコントロールで、インクの属性を変更したり、インク ツールバーのルーラー ステンシルを制御したりするための追加の機能が有効になります。

インク ツール バーを使用している手描き入力アプリケーションで、Surface Dial メニューを開くと、ペンの種類とブラシの太さを制御するためのツールがメニューに表示されます。 ルーラーが有効である場合、対応するツールがメニューに追加され、デバイスでルーラーの位置と角度を制御できます。

![Surface Dial メニューと Windows Ink ツール バーのペン選択ツール](images/windows-wheel/surface-dial-menu-inktoolbar-pen.png)  
*Surface Dial メニューと Windows Ink ツール バーのペン選択ツール*

![Surface Dial メニューと Windows Ink ツール バーのストローク サイズ ツール](images/windows-wheel/surface-dial-menu-inktoolbar-strokesize.png)  
*Surface Dial メニューと Windows Ink ツール バーのストローク サイズ ツール*

![Surface Dial メニューと Windows Ink ツール バーのルーラー ツール](images/windows-wheel/surface-dial-menu-inktoolbar-ruler.png)  
*Surface Dial メニューと Windows Ink ツール バーのルーラー ツール*

## <a name="user-customization"></a>ユーザーのカスタマイズ

ユーザーは、既定のフォント、バイブレーション (または触覚フィードバック)、利き手など、Dial のエクスペリエンスの一部を、**[Windows の設定] -> [デバイス] -> [ホイール]** ページでカスタマイズできます。 

Surface Dial ユーザー エクスペリエンスをカスタマイズする場合、特定の機能や動作が利用可能であり、ユーザーが有効にしていることを常に確認する必要があります。

## <a name="custom-tools"></a>カスタム ツール

ここでは、Surface Dial メニューで公開されるツールをカスタマイズするための UX と開発者の両方のガイダンスについて説明します。

### <a name="ux-guidance"></a>UX ガイダンス

**ツールを現在のコンテキストに確実に対応させる** ツールの目的や Surface Dial の操作方法を明確かつ直感的にしている場合、ユーザーは操作をすばやく習得し、作業に集中することができます。

**できるだけアプリ ツールの数を最小限に抑える**  
Surface Dial メニューの領域には、7 つの項目を表示できます。 8 個以上の項目がある場合、ユーザーは Dial を回してオーバーフロー ポップアップで利用可能なツールを確認する必要があります。このため、メニューのナビゲーションが難しくなり、ツールを見つけて選択することも困難になります。

アプリまたはアプリのコンテキストで、1 つのカスタム ツールを提供することをお勧めします。 こうすることで、ユーザーが行っている作業に基づいてツールを設定することができ、ユーザーは Surface Dial メニューをアクティブ化してツールを選択する必要がありません。 

**ツールのコレクションを動的に更新する**  
Surface Dial メニュー項目は無効な状態をサポートしていないため、ユーザーのコンテキスト (現在のビューやフォーカスのあるウィンドウ) に基づいて、動的にツール (組み込みの既定のツールを含む) を追加および削除する必要があります。 ツールが現在のアクティビティに関連していない場合や、重複している場合は、削除します。

> [!IMPORTANT]
> メニューに項目を追加する場合は、その項目がまだ存在していないことを確認します。

**組み込みのシステム ボリューム設定ツールを削除しない**  
通常、ユーザーは常にボリューム コントロールを必要とします。 ユーザーは、アプリを使用しながら音楽を聴くことがあるため、ボリュームと次のトラック ツールは、常に、Surface Dial メニューからアクセスできる必要があります  (次のトラック ツールは、メディアの再生中に自動的にメニューに追加されます)。

**メニュー編成の一貫性を保つ**  
これにより、ユーザーはアプリを使用するときに利用可能なツールを見つけて習得することが容易になり、ツールの切り替える際の効率を向上させることができます。

**組み込みのアイコンと一貫性のある高品質なアイコンを提供する**  
アイコンによってプロ意識と優秀さを伝え、ユーザーの信頼を呼び起こすことができます。
- 高品質な 64 x 64 ピクセルの PNG 画像を提供する (44 x 44 はサポートされている最小サイズ)
- 背景が透明であることを確認する
- アイコンは画像のほとんどの部分を占めている必要がある
- 白いアイコンは、ハイ コントラスト モードで表示できるように黒い枠が必要である

|   |   |   |
| --- | --- | --- |
| ![アルファによる背景付きのアイコン](images/windows-wheel/surface-dial-menu-icon1.png) | ![既定のテーマのアイコンでホイール メニューに表示されるアイコン](images/windows-wheel/surface-dial-menu-icon2.png) | ![Surface Dial のオンスクリーン メニュー](images/windows-wheel/surface-dial-menu-icon3.png) |
| *アルファによる背景付きのアイコン* | *既定のテーマでホイール メニューに表示されるアイコン* | *ハイコントラスト白のテーマでホイール メニューに表示されるアイコン* |

**簡潔でわかりやすい名前を使う**  
ツール名は、ツールのアイコンと共にツール メニューに表示され、スクリーン リーダーでも使用されます。 
- 名前は、ホイール メニューの中心の円内に収まるように短くする必要がある
- 名前は、プライマリ操作を明確に識別する (補完的な操作を暗示できる) 必要がある
  - スクロールは両方の回転方向の効果を示す
  - ([元に戻す] はプライマリ操作を指定するが、ユーザーは簡単に [やり直し)] （補完的なアクション） を推測して検出できる

### <a name="developer-guidance"></a>開発者向けガイダンス

包括的な一連の [Windows ランタイム API](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) を使用してアプリの機能を補完するために、Surface Dial エクスペリエンスをカスタマイズできます。 

前述のように、既定の Surface Dial メニューには、幅広い基本的なシステム機能 (システム ボリューム、システムの明るさ、スクロール、ズーム、取り消し、およびシステムで継続的なオーディオやビデオの再生が検出された場合のメディア コントロール) をカバーする組み込みツールのセットがあらかじめ含まれています。 ただし、これらの既定のツールでは、アプリに必要な機能が提供されない可能性があります。 

次のセクションでは、Surface Dial メニューにカスタム ツールを追加し、どの組み込みツールを公開するかを指定する方法について説明します。

**カスタム ツールを追加する**

この例では、回転イベントとクリック イベントの両方からの入力データを、いくつかの XAML UI コントロールに渡す基本的なカスタム ツールを追加します。

1. まず、XAMLで UI (スライダーとトグル ボタンのみ) を宣言します。

   ![サンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool1.png)  
   *サンプル アプリの UI*

    ```Xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
      </Grid.RowDefinitions>
      <StackPanel x:Name="HeaderPanel" 
        Orientation="Horizontal" 
        Grid.Row="0">
          <TextBlock x:Name="Header"
            Text="RadialController customization sample"
            VerticalAlignment="Center"
            Style="{ThemeResource HeaderTextBlockStyle}"
            Margin="10,0,0,0" />
      </StackPanel>
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center"
        Grid.Row="1">
          <!-- Slider for rotation input -->
          <Slider x:Name="RotationSlider"
            Width="300"
            HorizontalAlignment="Left"/>
          <!-- Switch for click input -->
          <ToggleSwitch x:Name="ButtonToggle"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    ```

2. その後、分離コードで、Surface Dial メニューにカスタム ツールを追加し、[**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) 入力ハンドラーを宣言します。 

   [**CreateForCurrentView**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.CreateForCurrentView) を呼び出すことによって、Surface Dial (myController) の [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) オブジェクトへの参照を取得します。

   次に [**RadialControllerMenuItem.CreateFromIcon**](https://msdn.microsoft.com/library/windows/apps/mt759255) を呼び出すことによって、[**RadialControllerMenuItem**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuItem) (myItem) のインスタンスを作成します。 

   次に、その項目をメニュー項目のコレクションに追加します。

   [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController)オブジェクトの入力イベント ハンドラー ([**ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) と [**RotationChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationChanged)) を宣言します。

   最後に、イベント ハンドラーを定義します。

    ```csharp
    public sealed partial class MainPage : Page
    {
        RadialController myController;

        public MainPage()
        {
            this.InitializeComponent();
            // Create a reference to the RadialController.
            myController = RadialController.CreateForCurrentView();

            // Create an icon for the custom tool.
            RandomAccessStreamReference icon =
              RandomAccessStreamReference.CreateFromUri(
                new Uri("ms-appx:///Assets/StoreLogo.png"));

            // Create a menu item for the custom tool.
            RadialControllerMenuItem myItem =
              RadialControllerMenuItem.CreateFromIcon("Sample", icon);

            // Add the custom tool to the RadialController menu.
            myController.Menu.Items.Add(myItem);

            // Declare input handlers for the RadialController.
            myController.ButtonClicked += MyController_ButtonClicked;
            myController.RotationChanged += MyController_RotationChanged;
        }

        // Handler for rotation input from the RadialController.
        private void MyController_RotationChanged(RadialController sender,
          RadialControllerRotationChangedEventArgs args)
        {
            if (RotationSlider.Value + args.RotationDeltaInDegrees > 100)
            {
                RotationSlider.Value = 100;
                return;
            }
            else if (RotationSlider.Value + args.RotationDeltaInDegrees < 0)
            {
                RotationSlider.Value = 0;
                return;
            }
            RotationSlider.Value += args.RotationDeltaInDegrees;
        }

        // Handler for click input from the RadialController.
        private void MyController_ButtonClicked(RadialController sender,
          RadialControllerButtonClickedEventArgs args)
        {
            ButtonToggle.IsOn = !ButtonToggle.IsOn;
        }
    }
    ```

アプリを実行するときに、Surface Dial を使用してアプリを操作します。 最初に、長押ししてメニューを開き、カスタム ツールを選択します。 カスタム ツールがアクティブ化されると、Dial を回転することでスライダー コントロールを調整でき、Dial をクリックしてスイッチを切り替えることができます。

![Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool2.png)  
*Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI*

**組み込みのツールを指定する**

[**RadialControllerConfiguration**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerConfiguration) クラスを使用して、アプリの組み込みのメニュー項目のコレクションをカスタマイズできます。

たとえば、アプリにスクロール領域やズーム領域がない場合や、元に戻す/やり直し機能が不要な場合は、これらのツールをメニューから削除できます。 これにより、メニューにアプリのカスタム ツールを追加するための空き領域ができます。 

> [!IMPORTANT] 
> Surface Dial メニューには、少なくとも 1 つのメニュー項目が必要です。 カスタム ツールの 1 つを追加する前に、すべての既定のツールを削除した場合、既定のツールは復元され、ツールは既定のコレクションに追加されます。

設計のガイドラインとして、ユーザーは他のタスクを実行しながら BGM を再生していることが多いため、メディア コントロール ツール (ボリュームおよび前/次のトラック) は削除しないことをお勧めします。

ここでは、ボリュームと次/前のトラックのメディア コントロールのみを含む Surface Dial メニューを構成する方法を示します。

```csharp
public MainPage()
{
  ...
  //Remove a subset of the default system tools
  RadialControllerConfiguration myConfiguration = 
  RadialControllerConfiguration.GetForCurrentView();
  myConfiguration.SetDefaultMenuItems(new[] 
  {
    RadialControllerSystemMenuItemKind.Volume,
      RadialControllerSystemMenuItemKind.NextPreviousTrack
  });
}
```

## <a name="custom-interactions"></a>カスタム操作

前述のように、Surface Dial は 3 つのジェスチャ (長押し、回転、クリック) をサポートしており、それぞれ既定の操作に対応します。 

これらのジェスチャに基づくカスタム操作は、選択したアクションやツールで意味があることを確認します。 

> [!NOTE]
> 操作エクスペリエンスは、Surface Dial メニューの状態に依存します。 メニューがアクティブな場合はメニューが入力を処理し、それ以外の場合はアプリが入力を処理します。

### <a name="press-and-hold"></a>長押し

このジェスチャは、Surface Dial メニューをアクティブにして表示します。このジェスチャに関連付けられているアプリの機能はありません。 

既定では、ユーザーの画面の中央にメニューが表示されます。 ただし、ユーザーはメニューをつかんで、選択した任意の場所に移動できます。

> [!NOTE]
> Surface Dial を Surface Studio の画面上に配置している場合、Surface Dial の画面上の位置を中心として表示されます。

### <a name="rotate"></a>回転

Surface Dial は、アナログ値やコントロールのスムーズな増分の調整に関連する操作のための回転をサポートすることを主な目的として設計されています。

このデバイスは、時計回りと反時計回りの両方向に回転させることができ、個々の間隔を示す触覚フィードバックを提供することもできます。

> [!NOTE]
> 触覚フィードバックは、ユーザーが **[Windows の設定] -> [デバイス] -> [ホイール]** ページで無効にすることができます。

#### <a name="ux-guidance"></a>UX ガイダンス

**連続的な高い回転感度のツールでは触覚フィードバックを無効にする**

触覚フィードバックは、アクティブなツールの回転感度と一致します。 ユーザー エクスペリエンスが快適ではなくなる可能性があるため、連続的な高い回転感度のツールでは、触覚フィードバックを無効にすることをお勧めします。 

**利き手が回転ベースの操作に影響しないようにする**

Surface Dial では使用されている手を検出できませんが、ユーザーは **[Windows の設定] -> [デバイス] -> [ペンと Windows Ink]** で利き手を設定できます。

**すべての回転操作でロケールを考慮する必要がある**

対話式操作をロケールおよび右から左のレイアウトに対応させて調整することにより、顧客満足度を最大化します。

Dial メニューの組み込みのツールとコマンドは、回転ベースの操作について以下のガイドラインに従っています。

|   |   |   |
| --- | --- | --- |
| 左<br/>上<br/>外 | ![Surface Dial の画像](images/windows-wheel/surface-dial-rotate.png) | 右<br/>下<br/>内 |
|   |   |   |

| 概念的な方向 | Surface Dial へのマッピング | 時計回りの回転 | 反時計回りの回転 |
| --- | --- | --- | --- |
| 横方向 | Surface Dial の上部に基づいて左右のマッピング | 右 | 左 |
| 縦方向 | Surface Dial の左側に基づいて上下のマッピング | 下 | 上 |
| Z 軸 | 内 (またはより近い) が上/右にマップ<br/>外 (またはより遠い) が下/左にマップ | 内 | 外 |

#### <a name="developer-guidance"></a>開発者向けガイダンス

ユーザーがデバイスを回転させると、[**RadialController.RotationChanged**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationChanged) イベントが、回転の方向を基準としたデルタ ([**RadialControllerRotationChangedEventArgs.RotationDeltaInDegrees**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerRotationChangedEventArgs.RotationDeltaInDegrees)) に基づいて発生します。 データの感度 (または解像度) は、[**RadialController.RotationResolutionInDegrees**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.RotationResolutionInDegrees) プロパティで設定できます。

> [!NOTE]
> 既定では、デバイスが最小値の 10 度回転された場合に、初めて回転入力イベントが [**RadialController**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController) オブジェクトに配信されます。 各入力イベントによって、デバイスのバイブレーションが発生します。

一般的に、回転解像度が 5 度未満に設定されている場合は、触覚フィードバックを無効にすることをお勧めします。 これにより、連続的な対話式操作でスムーズなエクスペリエンスを提供できます。 

カスタム ツールの触覚フィードバックを有効または無効にするには、[**RadialController.UseAutomaticHapticFeedback**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.UseAutomaticHapticFeedback) プロパティを使用します。

> [!NOTE]
> ボリューム コントロールなどのシステム ツールの触覚動作をオーバーライドすることはできません。 これらのツールについては、ユーザーが [ホイールの設定] ページからのみ触覚フィードバックを無効にすることができます。

回転のデータの解像度をカスタマイズし、触覚フィードバックを有効または無効にする方法の例を次に示します。

```csharp
private void MyController_ButtonClicked(RadialController sender, 
  RadialControllerButtonClickedEventArgs args)
{
  ButtonToggle.IsOn = !ButtonToggle.IsOn;

  if(ButtonToggle.IsOn)
  {
    //high resolution mode
    RotationSlider.LargeChange = 1;
    myController.UseAutomaticHapticFeedback = false;
    myController.RotationResolutionInDegrees = 1;
  }
  else
  {
    //low resolution mode
    RotationSlider.LargeChange = 10;
    myController.UseAutomaticHapticFeedback = true;
    myController.RotationResolutionInDegrees = 10;
  }
}
```

### <a name="click"></a>クリック

Surface Dial のクリックは、マウスの左ボタンのクリックと似ています (デバイスの回転状態は、この操作に影響しません)。

#### <a name="ux-guidance"></a>UX ガイダンス

**ユーザーが結果から簡単に回復できない場合は、このジェスチャに操作やコマンドをマップしない**

ユーザーによる Surface Dial のクリックに基づいてアプリが実行する操作は、元に戻すことができる必要があります。 常に、ユーザーが簡単にアプリのバック スタックを移動して、アプリの以前の状態を復元できるようにしてください。

ミュート/ミュート解除や表示/非表示などのバイナリ操作は、クリック ジェスチャによる優れたユーザー エクスペリエンスを提供します。

**Surface Dial のクリックによってモーダル ツールを有効または無効にしない**

一部のアプリ/ツールのモードは、回転に依存する操作と競合する、つまり無効にする場合があります。 Windows Ink ツール バーのルーラーなどのツールは、他の UI アフォーダンスでオンとオフを切り替える必要があります (Ink ツール バーには、組み込みの [**ToggleButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.Primitives.ToggleButton) コントロールがあります)。

モーダル ツールの場合、アクティブな Surface Dial メニュー項目を、ターゲット ツールまたは以前に選択したメニュー項目にマップします。

#### <a name="developer-guidance"></a>開発者向けガイダンス

Surface Dial がクリックされると、[**RadialController.ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) イベントが発生します。 [**RadialControllerButtonClickedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs) には、Surface Dial が Surface Studio の画面に接触している位置と境界領域を格納する [**Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs.Contact) プロパティが含まれています。 Surface Dial が画面に接触していない場合、このプロパティは null です。 

### <a name="on-screen"></a>オンスクリーン

前述のように、Surface Dial は Surface Studio と組み合わせて使用し、特殊なオンスクリーン モードで Surface Dial メニューを表示できます。 

このモードでは、Dial の操作エクスペリエンスとアプリをさらに統合してカスタマイズできます。 Surface Dial と Surface Studio の組み合わせでのみ実現できるユニークなエクスペリエンスの例を次に示します。
- Surface Dial の位置に基づいて、状況に応じたツール (カラー パレットなど) を表示し、ツールを簡単に見つけて使用できるようにする
- Surface Dial が配置されている UI に基づいて、アクティブなツールを設定する
- Surface Dial の位置に基づいて、画面領域を拡大する
- 画面の位置に基づくユニークなゲームの操作

#### <a name="ux-guidance"></a>UX ガイダンス

**画面上で Surface Dial が検出されたときにアプリが応答する必要がある**

視覚的なフィードバックは、アプリが Surface Studio の画面上のデバイスを検出したことをユーザーに知らせるのに役立ちます。

**デバイスの位置に基づいて Surface Dial 関連の UI を調整する**

ユーザーがデバイスを配置した場所によっては、デバイス (とユーザーの体) により重要な UI が見えなくなる場合があります。

**ユーザー操作に基づいて Surface Dial 関連の UI を調整する**

デバイスを使用するときに、ハードウェアに加えて、ユーザーの手や腕によって画面の一部が見えなくなることがあります。 

見えなくなる領域は、どちらの手でデバイスを使用しているかによって異なります。 Surface Dial は、主に利き手以外の手で使用するように設計されているため、Surface Dial 関連の UI はユーザーが指定した利き手 (**[Windowsの設定] > [デバイス] > [ペンと Windows Ink] > [利き手を選択してください]** の設定) に合わせて調整する必要があります。

**操作は Surface Dial の動きではなく位置に対応する必要がある**

このデバイスは高精度ポインティング デバイスではないため、スライドするのではなく、画面に張り付くように設計されています。 そのため、ユーザーは Surface Dial を画面上でドラッグするのではなく、持ち上げて配置する方が一般的であると想定しています。

**画面上の位置を使用してユーザーの意図を確認する**

UI コンテキスト (コントロール、キャンバス、ウィンドウとの近さなど) に基づいてアクティブなツールを設定すると、タスクを実行するために必要な手順が減ることにより、ユーザー エクスペリエンスを向上させることができます。

#### <a name="developer-guidance"></a>開発者向けガイダンス

Surface Dial が Surface Studio のデジタイザー サーフェス上に配置されると、[**RadialController.ScreenContactStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ScreenContactStarted) イベントが発生し、接触情報 ([**RadialControllerScreenContactStartedEventArgs.Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactStartedEventArgs.Contact)) がアプリに提供されます。

同様に、Surface Studio のデジタイザー サーフェスに接触しているときに、Surface Dial がクリックされた場合、[**RadialController.ButtonClicked**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController.ButtonClicked) イベントが発生し、接触情報 ([**RadialControllerButtonClickedEventArgs.Contact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs.Contact)) がアプリに提供されます。 

接触情報 ([**RadialControllerScreenContact**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact)) には、アプリの座標空間での Surface Dial の中心のX/Y座標 ([**RadialControllerScreenContact.Position**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact.Position)) と、デバイスに依存しないピクセル (DIP) での境界の四角形 ([**RadialControllerScreenContact.Bounds**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact.Bounds)) が含まれます。 この情報は、アクティブなツールにコンテキストを提供し、ユーザーにデバイスに関連する視覚的なフィードバックを提供する場合に、非常に便利です。

次の例では、それぞれが 1 つのスライダーと 1 つのトグル スイッチを含む、4 つの異なるセクションを持つ基本的なアプリを作成したしました。 Surface Dial の画面上の位置を使用して、Surface Dial で制御されるスライダーとトグル スイッチのセットを決定します。

1. 最初に、XAMLで UI (4つのセクションと、それぞれのスライダーとトグル ボタン) を宣言します。

   ![サンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool3.png)  
   *サンプル アプリの UI*

   ```xaml 
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
  <Grid.RowDefinitions>
    <RowDefinition Height="Auto"/>
    <RowDefinition Height="*"/>
  </Grid.RowDefinitions>
  <StackPanel x:Name="HeaderPanel" 
        Orientation="Horizontal" 
        Grid.Row="0">
    <TextBlock x:Name="Header"
      Text="RadialController customization sample"
      VerticalAlignment="Center"
      Style="{ThemeResource HeaderTextBlockStyle}"
      Margin="10,0,0,0" />
  </StackPanel>
  <Grid Grid.Row="1" x:Name="RootGrid">
    <Grid.RowDefinitions>
      <RowDefinition Height="*"/>
      <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="*"/>
      <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>
    <Grid x:Name="Grid0"
      Grid.Row="0"
      Grid.Column="0">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider0"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle0"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    <Grid x:Name="Grid1"
      Grid.Row="0"
      Grid.Column="1">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider1"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle1"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    <Grid x:Name="Grid2"
      Grid.Row="1"
      Grid.Column="0">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider2"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle2"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
    <Grid x:Name="Grid3"
      Grid.Row="1"
      Grid.Column="1">
      <StackPanel Orientation="Vertical" 
        VerticalAlignment="Center" 
        HorizontalAlignment="Center">
        <!-- Slider for rotational input -->
        <Slider x:Name="RotationSlider3"
          Width="300"
          HorizontalAlignment="Left"/>
        <!-- Switch for button input -->
        <ToggleSwitch x:Name="ButtonToggle3"
            HorizontalAlignment="Left"/>
      </StackPanel>
    </Grid>
  </Grid>
</Grid>
   ```

2. Surface Dial の画面上の位置に対して定義されているハンドラーを含む分離コードを次に示します。

```csharp
Slider ActiveSlider;
ToggleSwitch ActiveSwitch;
Grid ActiveGrid;

public MainPage()
{
  ...

  myController.ScreenContactStarted += 
    MyController_ScreenContactStarted;
  myController.ScreenContactContinued += 
    MyController_ScreenContactContinued;
  myController.ScreenContactEnded += 
    MyController_ScreenContactEnded;
  myController.ControlLost += MyController_ControlLost;

  //Set initial grid for Surface Dial input.
  ActiveGrid = Grid0;
  ActiveSlider = RotationSlider0;
  ActiveSwitch = ButtonToggle0;
}

private void MyController_ScreenContactStarted(RadialController sender, 
  RadialControllerScreenContactStartedEventArgs args)
{
  //find grid at contact location, update visuals, selection
  ActivateGridAtLocation(args.Contact.Position);
}

private void MyController_ScreenContactContinued(RadialController sender, 
  RadialControllerScreenContactContinuedEventArgs args)
{
  //if a new grid is under contact location, update visuals, selection
  if (!VisualTreeHelper.FindElementsInHostCoordinates(
    args.Contact.Position, RootGrid).Contains(ActiveGrid))
  {
    ActiveGrid.Background = new 
      SolidColorBrush(Windows.UI.Colors.White);
    ActivateGridAtLocation(args.Contact.Position);
  }
}

private void MyController_ScreenContactEnded(RadialController sender, object args)
{
  //return grid color to normal when contact leaves screen
  ActiveGrid.Background = new 
  SolidColorBrush(Windows.UI.Colors.White);
}

private void MyController_ControlLost(RadialController sender, object args)
{
  //return grid color to normal when focus lost
  ActiveGrid.Background = new 
    SolidColorBrush(Windows.UI.Colors.White);
}

private void ActivateGridAtLocation(Point Location)
{
  var elementsAtContactLocation = 
    VisualTreeHelper.FindElementsInHostCoordinates(Location, 
      RootGrid);

  foreach (UIElement element in elementsAtContactLocation)
  {
    if (element as Grid == Grid0)
    {
      ActiveSlider = RotationSlider0;
      ActiveSwitch = ButtonToggle0;
      ActiveGrid = Grid0;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
    else if (element as Grid == Grid1)
    {
      ActiveSlider = RotationSlider1;
      ActiveSwitch = ButtonToggle1;
      ActiveGrid = Grid1;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
    else if (element as Grid == Grid2)
    {
      ActiveSlider = RotationSlider2;
      ActiveSwitch = ButtonToggle2;
      ActiveGrid = Grid2;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
    else if (element as Grid == Grid3)
    {
      ActiveSlider = RotationSlider3;
      ActiveSwitch = ButtonToggle3;
      ActiveGrid = Grid3;
      ActiveGrid.Background = new SolidColorBrush( 
        Windows.UI.Colors.LightGoldenrodYellow);
      return;
    }
  }
}
```

アプリを実行するときに、Surface Dial を使用してアプリを操作します。 最初に、Surface Studio の画面にデバイスを配置します。アプリがデバイスを検出し、右下のセクションに関連付けます (画像を参照してください)。 次に Surface Dial を長押ししてメニューを開き、カスタム ツールを選択します。 カスタム ツールがアクティブ化されると、Surface Dial を回転することでスライダー コントロールを調整でき、Surface Dial をクリックしてスイッチを切り替えることができます。

![Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI の画像](images/windows-wheel/surface-dial-snippet-customtool4.png)  
*Surface Dial のカスタム ツールを使用してアクティブ化されたサンプル アプリの UI*

## <a name="summary"></a>まとめ

このトピックでは、Surface Studio 入力デバイスの概要を、UX および開発者向けのガイダンスと共に示し、オフスクリーンのシナリオおよび Surface Studio と共に使用する場合のオンスクリーンのシナリオでユーザー エクスペリエンスをカスタマイズする方法について説明しました。

## <a name="feedback"></a>フィードバック

質問、提案、フィードバックについては、[radialcontroller@microsoft.com](mailto:radialcontroller@microsoft.com) までお送りください。

## <a name="related-articles"></a>関連記事

### <a name="api-reference"></a>API リファレンス

- [**RadialController** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController)
- [**RadialControllerButtonClickedEventArgs** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerButtonClickedEventArgs)
- [**RadialControllerConfiguration** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerConfiguration) 
- [**RadialControllerControlAcquiredEventArgs** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerControlAcquiredEventArgs) 
- [**RadialControllerMenu** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenu) 
- [**RadialControllerMenuItem** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuItem) 
- [**RadialControllerRotationChangedEventArgs** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerRotationChangedEventArgs) 
- [**RadialControllerScreenContact** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContact) 
- [**RadialControllerScreenContactContinuedEventArgs** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactContinuedEventArgs) 
- [**RadialControllerScreenContactStartedEventArgs** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerScreenContactStartedEventArgs)
- [**RadialControllerMenuKnownIcon** 列挙型](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerMenuKnownIcon) 
- [**RadialControllerSystemMenuItemKind** 列挙型](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialControllerSystemMenuItemKind) 

### <a name="samples"></a>サンプル

[ユニバーサル Windows プラットフォーム のサンプル (C# と C++)](https://go.microsoft.com/fwlink/?linkid=832713)

[Windows の従来のデスクトップのサンプル](https://aka.ms/radialcontrollerclassicsample)


<!--HONumber=Dec16_HO3-->


