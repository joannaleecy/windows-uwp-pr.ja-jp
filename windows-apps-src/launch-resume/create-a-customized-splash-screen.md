---
title: スプラッシュ スクリーンの表示時間の延長
description: アプリに追加スプラッシュ画面を作成すれば、より長い時間、スプラッシュ画面を表示することができます。 この追加画面は、アプリを起動したときに表示されるスプラッシュ画面に似ていますが、カスタマイズできます。
ms.assetid: CD3053EB-7F86-4D74-9C5A-950303791AE3
ms.date: 02/19/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: bed81def33eedb79619b49ff698a3f45f31bdb62
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57615897"
---
# <a name="display-a-splash-screen-for-more-time"></a>スプラッシュ スクリーンの表示時間の延長

**重要な API**

-   [SplashScreen クラス](https://msdn.microsoft.com/library/windows/apps/br224763)
-   [Window.SizeChanged イベント](https://msdn.microsoft.com/library/windows/apps/br209055)
-   [Application.OnLaunched メソッド](https://msdn.microsoft.com/library/windows/apps/br242335)

アプリに追加スプラッシュ画面を作成すれば、より長い時間、スプラッシュ画面を表示することができます。 この追加画面は、アプリを起動したときに表示されるスプラッシュ画面に似ていますが、カスタマイズできます。 読み込み状況をリアルタイムにユーザーに表示する場合や、アプリの最初の UI の準備に時間がかかる場合、追加スプラッシュ画面を使って起動時のエクスペリエンスを定義できます。

> [!NOTE]
> 語句"拡張スプラッシュ画面"では、このトピックでは、長期間の画面に保存されるスプラッシュ スクリーンを指します。 派生するサブクラスとは限りません、 [SplashScreen](https://msdn.microsoft.com/library/windows/apps/br224763)クラス。

追加スプラッシュ画面の外観は、次の推奨事項に従って、既定のスプラッシュ画面に厳密に似せるようにしてください。

-   この追加スプラッシュ画面ページでは、アプリ マニフェスト内でスプラッシュ画面に指定したイメージ (アプリのスプラッシュ画面のイメージ) と一致する 620 x 300 ピクセルのイメージを使います。 Microsoft Visual Studio 2015 では、スプラッシュ画面の設定が格納されている、**スプラッシュ スクリーン**のセクション、**ビジュアル資産** タブで、アプリ マニフェスト (Package.appxmanifest ファイル)。
-   追加スプラッシュ画面では、アプリ マニフェスト内でスプラッシュ画面に指定した背景色 (アプリのスプラッシュ画面の背景) と一致する背景色を使います。
-   コードを使用する必要があります、 [SplashScreen](https://msdn.microsoft.com/library/windows/apps/br224763)既定のスプラッシュ スクリーンとして同じ画面で、アプリのスプラッシュ スクリーン イメージを配置するクラスを調整します。
-   コードは、ウィンドウのサイズ変更イベントに応答する必要があります (画面の回転時など、アプリが移動され、画面上の別のアプリの横にある) を使用して、 [SplashScreen](https://msdn.microsoft.com/library/windows/apps/br224763)クラス拡張のスプラッシュ画面上のアイテムの位置を変更します。

次の手順を使うと、既定のスプラッシュ画面とよく似た追加スプラッシュ画面を作成できます。

## <a name="add-a-blank-page-item-to-your-existing-app"></a>**[空白のページ]** 項目を既にあるアプリに追加する


また、このトピックでは、C#、Visual Basic、C++ を使って、既にあるユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクト用の追加スプラッシュ画面を作成することを想定しています。

-   Visual Studio でアプリを開きます。
-   メニュー バーから **[プロジェクト]** を開き、**[新しい項目の追加]** をクリックします。 **[新しい項目の追加]** ダイアログ ボックスが表示されます。
-   このダイアログ ボックスから新しい**空白のページ**をアプリに追加します。 このトピックでは、追加スプラッシュ画面ページの名前を "ExtendedSplash" とします。

**[空白のページ]** 項目を追加すると、2 つのファイルが生成されます。1 つはマークアップ用 (ExtendedSplash.xaml)、もう 1 つはコード用 (ExtendedSplash.xaml.cs) です。

## <a name="essential-xaml-for-an-extended-splash-screen"></a>追加スプラッシュ画面の基本的な XAML


次の手順に従って、追加スプラッシュ画面にイメージやプログレス コントロールを追加します。

ExtendedSplash.xaml ファイルで次の操作を行います。

-   変更、[バック グラウンド](https://msdn.microsoft.com/library/windows/apps/br209396)プロパティの既定の[グリッド](https://msdn.microsoft.com/library/windows/apps/br242704)アプリケーション マニフェストでの設定、アプリのスプラッシュ スクリーンの背景色と一致する要素 (で、**ビジュアル アセット**、Package.appxmanifest ファイルのセクション)。 既定のスプラッシュ画面の色が薄い灰色 (16 進数の値\#464646)。 新しい**空白のページ**を作成すると、この **Grid** 要素が既定で使われることに注意してください。 必ずしも **Grid** を使う必要はありません。追加スプラッシュ画面を作り始めるときに便利なだけです。
-   追加、[キャンバス](https://msdn.microsoft.com/library/windows/apps/br209267)要素を[グリッド](https://msdn.microsoft.com/library/windows/apps/br242704)します。 この **Canvas** を使って追加スプラッシュ画面にイメージを配置します。
-   追加、[イメージ](https://msdn.microsoft.com/library/windows/apps/br242752)要素を[キャンバス](https://msdn.microsoft.com/library/windows/apps/br209267)します。 既定のスプラッシュ画面用に選んだ同じ 600 × 320 ピクセルの画像を追加スプラッシュ画面に使います。
-   (省略可能) アプリが読み込み中であることをユーザーに示すにはプログレス コントロールを追加します。 このトピックの追加、 [ProgressRing](https://msdn.microsoft.com/library/windows/apps/br227538)ではなく、不確定または中間の[ProgressBar](https://msdn.microsoft.com/library/windows/apps/br227529)します。

次の例で、[グリッド](https://msdn.microsoft.com/library/windows/apps/br242704)でこれらの追加および変更します。

```xaml
    <Grid Background="#464646">
        <Canvas>
            <Image x:Name="extendedSplashImage" Source="Assets/SplashScreen.png"/>
            <ProgressRing Name="splashProgressRing" IsActive="True" Width="20" HorizontalAlignment="Center"></ProgressRing>
        </Canvas>
    </Grid>
```

> [!NOTE]
> この例の幅の設定、 [ProgressRing](https://msdn.microsoft.com/library/windows/apps/br227538) 20 ピクセルにします。 この幅はアプリに合わせて手動で設定できますが、20 ピクセル未満の幅ではコントロールがレンダリングされません。

## <a name="essential-code-for-an-extended-splash-screen-class"></a>追加スプラッシュ画面クラスの基本的なコード


追加スプラッシュ画面はウィンドウのサイズ (Windows のみ) や向きの変更に応答する必要があります。 ウィンドウのサイズがどのように変更されても追加スプラッシュ画面が適切に表示されるように、使う画像の位置は更新される必要があります。

これらの手順を使って、追加スプラッシュ画面を正しく表示するためのメソッドを定義します。

1.  **必要な名前空間を追加します。**

    次の名前空間を追加する必要があります**ExtendedSplash.xaml.cs**にアクセスする、 [SplashScreen](https://msdn.microsoft.com/library/windows/apps/br224763)クラス、 [Rect](https://docs.microsoft.com/uwp/api/windows.foundation.rect)構造体、および[Window.SizeChanged](https://msdn.microsoft.com/library/windows/apps/br209055)イベント。

    ```cs
    using Windows.ApplicationModel.Activation;
    using Windows.Foundation;
    using Windows.UI.Core;
    ```

2.  **部分クラスを作成し、クラス変数の宣言**

    次のコードを ExtendedSplash.xaml.cs に挿入して、追加スプラッシュ画面を表す部分クラスを作成します。

    ```cs
    partial class ExtendedSplash : Page
    {
        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        private SplashScreen splash; // Variable to hold the splash screen object.
        internal bool dismissed = false; // Variable to track splash screen dismissal status.
        internal Frame rootFrame;

       // Define methods and constructor
    }
    ```

    これらのクラス変数は、複数のメソッドで使われます。 `splashImageRect` は、アプリのスプラッシュ画面のイメージが表示された座標を格納する変数です。 `splash`変数ストア、 [SplashScreen](https://msdn.microsoft.com/library/windows/apps/br224763)オブジェクト、および`dismissed`変数は、システムによって表示されるスプラッシュ スクリーンが消去されたかどうかを追跡します。

3.  **イメージの位置を正しく指定するクラスのコンス トラクターを定義します。**

    次のコードでは、ウィンドウ サイズ変更イベントをリッスンする追加スプラッシュ画面クラスのコンストラクターを定義し、追加スプラッシュ画面にイメージ (必要に応じてプログレス コントロール) を配置し、ナビゲーション用のフレームを作成し、保存済みのセッションを復元する非同期メソッドを呼び出しています。

    ```cs
    public ExtendedSplash(SplashScreen splashscreen, bool loadState)
    {
        InitializeComponent();

        // Listen for window resize events to reposition the extended splash screen image accordingly.
        // This ensures that the extended splash screen formats properly in response to window resizing.
        Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

        splash = splashscreen;
        if (splash != null)
        {
            // Register an event handler to be executed when the splash screen has been dismissed.
            splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);

            // Retrieve the window coordinates of the splash screen image.
            splashImageRect = splash.ImageLocation;
            PositionImage();

            // If applicable, include a method for positioning a progress control.
            PositionRing();
        }

        // Create a Frame to act as the navigation context
        rootFrame = new Frame();            
    }
    ```

    登録することを確認、 [Window.SizeChanged](https://msdn.microsoft.com/library/windows/apps/br209055)ハンドラー (`ExtendedSplash_OnResize`の例で)、クラス コンス トラクターで、アプリにイメージを配置正しく拡張スプラッシュ スクリーンでようにします。

4.  **拡張のスプラッシュ スクリーンにイメージを配置するメソッドをクラス定義します。**

    次のコードでは、`splashImageRect` クラス変数を使って追加スプラッシュ画面ページにイメージを配置する方法を示しています。

    ```cs
    void PositionImage()
    {
        extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X);
        extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y);
        extendedSplashImage.Height = splashImageRect.Height;
        extendedSplashImage.Width = splashImageRect.Width;
    }
    ```

5.  **(省略可能)拡張のスプラッシュ スクリーンで進行状況コントロールを配置するメソッドをクラス定義します。**

    追加した場合、 [ProgressRing](https://msdn.microsoft.com/library/windows/apps/br227538)拡張のスプラッシュ画面にスプラッシュ スクリーン イメージに対する相対位置します。 ExtendedSplash.xaml.cs で、**ProgressRing** をイメージの 32 ピクセル下の中央に配置する次のコードを追加します。

    ```cs
    void PositionRing()
    {
        splashProgressRing.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width*0.5) - (splashProgressRing.Width*0.5));
        splashProgressRing.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height*0.1));
    }
    ```

6.  **破棄イベントのハンドラーを定義、クラス内で**

    ExtendedSplash.xaml.cs、応答時に、 [SplashScreen.Dismissed](https://msdn.microsoft.com/library/windows/apps/br224764)を設定してイベントが発生した、`dismissed`クラス変数を true にします。 アプリにセットアップ操作がある場合は、それらの操作をこのイベント ハンドラーに追加します。

    ```cs
    // Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view).
    void DismissedEventHandler(SplashScreen sender, object e)
    {
        dismissed = true;

        // Complete app setup operations here...
    }
    ```

    アプリのセットアップが完了したら、追加スプラッシュ画面から移動するようにします。 次のコードでは、アプリの MainPage.xaml ファイルで定義されている `MainPage` に移動する `DismissExtendedSplash` というメソッドを定義しています。

    ```cs
    async void DismissExtendedSplash()
      {
         await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>            {
              rootFrame = new Frame();
              rootFrame.Content = new MainPage(); Window.Current.Content = rootFrame;
            });
      }
      ```

7.  **クラス内部 Window.SizeChanged イベントのハンドラーを定義します**

    ユーザーによってウィンドウのサイズが変更された場合にその要素を配置し直すように、追加スプラッシュ画面を準備します。 このコードは、応答時に、 [Window.SizeChanged](https://msdn.microsoft.com/library/windows/apps/br209055)新しい座標を取得し、イメージの位置を変更イベントが発生します。 追加スプラッシュ画面にプログレス コントロールを追加した場合は、同様に、このイベント ハンドラー内でそのコントロールを配置し直すようにします。

    ```cs
    void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
    {
        // Safely update the extended splash screen image coordinates. This function will be executed when a user resizes the window.
        if (splash != null)
        {
            // Update the coordinates of the splash screen image.
            splashImageRect = splash.ImageLocation;
            PositionImage();

            // If applicable, include a method for positioning a progress control.
            // PositionRing();
        }
    }
    ```

    > [!NOTE]
    > 前に取得しようとするイメージの場所を確認、クラス変数 (`splash`) を含む、有効な[SplashScreen](https://msdn.microsoft.com/library/windows/apps/br224763)オブジェクトの例で示すようにします。

     

8.  **(省略可能)保存されているセッション状態を復元するクラスのメソッドを追加します。**

    追加したコード、 [OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335)メソッドでは、手順 4。[起動アクティブ化のハンドラーを変更](#modify-the-launch-activation-handler)により、アプリを起動するときに、拡張のスプラッシュ スクリーンを表示します。 拡張のスプラッシュ画面クラスでのアプリの起動に関連するすべてのメソッドを統合するには、アプリの状態を復元する ExtendedSplash.xaml.cs ファイルにメソッドを追加することもできます。

    ```cs
    void RestoreState(bool loadState)
    {
        if (loadState)
        {
             // code to load your app's state here
        }
    }
    ```

    設定 App.xaml.cs で、起動アクティブ化のハンドラーを変更するときに`loadstate`場合に true に、以前[ApplicationExecutionState](https://msdn.microsoft.com/library/windows/apps/br224694) 、アプリが**Terminated**します。 その場合、`RestoreState` メソッドは、アプリを前の状態に復元します。 アプリの起動、中断、終了の概要については、「[アプリのライフサイクル](app-lifecycle.md)」をご覧ください。

## <a name="modify-the-launch-activation-handler"></a>起動アクティブ化ハンドラーの変更


アプリが起動されるとき、スプラッシュ画面の情報がアプリの起動アクティブ化イベント ハンドラーに渡されます。 この情報を使って、追加スプラッシュ画面ページにイメージを適切に配置できます。 取得できますこのスプラッシュ画面の情報、アクティブ化が渡されるイベント引数に、アプリの[OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335)ハンドラー (を参照してください、`args`次のコードに変数)。

既にオーバーライドされていない場合、 [OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335) 、アプリでは、ハンドラーを参照してください[アプリのライフ サイクル](app-lifecycle.md)をアクティブ化イベントを処理する方法について説明します。

App.xaml.cs ファイルで、追加スプラッシュ画面を作成して表示する次のコードを挿入します。

```cs
protected override void OnLaunched(LaunchActivatedEventArgs args)
{
    if (args.PreviousExecutionState != ApplicationExecutionState.Running)
    {
        bool loadState = (args.PreviousExecutionState == ApplicationExecutionState.Terminated);
        ExtendedSplash extendedSplash = new ExtendedSplash(args.SplashScreen, loadState);
        Window.Current.Content = extendedSplash;
    }

    Window.Current.Activate();
}
```

## <a name="complete-code"></a>コードを完成させる

次のコードは、少し前の手順で示すスニペットとは異なります。
-   ExtendedSplash.xaml には `DismissSplash` ボタンが含まれています。 このボタンがクリックされると、イベント ハンドラーである `DismissSplashButton_Click` が `DismissExtendedSplash` メソッドを呼び出します。 アプリで、リソースの読み込みまたは UI の初期化の完了時に `DismissExtendedSplash` を呼び出します。
-   このアプリを使用して、UWP のアプリのプロジェクト テンプレートを使用も[フレーム](https://msdn.microsoft.com/library/windows/apps/br242682)ナビゲーション。 App.xaml.cs 起動アクティブ化のハンドラーでその結果、([OnLaunched](https://msdn.microsoft.com/library/windows/apps/br242335)) を定義、`rootFrame`を使用して、アプリ ウィンドウのコンテンツを設定するとします。

### <a name="extendedsplashxaml"></a>ExtendedSplash.xaml

この例では、`DismissSplash`に読み込むアプリのリソースがないためにボタンをクリックします。 アプリでは、リソースの読み込みまたはその最初の UI の準備の完了時に追加スプラッシュ画面が自動的に閉じられます。

```xml
<Page
    x:Class="SplashScreenExample.ExtendedSplash"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:SplashScreenExample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="#464646">
        <Canvas>
            <Image x:Name="extendedSplashImage" Source="Assets/SplashScreen.png"/>
            <ProgressRing Name="splashProgressRing" IsActive="True" Width="20" HorizontalAlignment="Center"/>
        </Canvas>
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Bottom">
            <Button x:Name="DismissSplash" Content="Dismiss extended splash screen" HorizontalAlignment="Center" Click="DismissSplashButton_Click" />
        </StackPanel>
    </Grid>
</Page>
```

### <a name="extendedsplashxamlcs"></a>ExtendedSplash.xaml.cs

なお、`DismissExtendedSplash`のクリック イベント ハンドラーからメソッドが呼び出されます、`DismissSplash`ボタンをクリックします。 アプリでは、`DismissSplash` ボタンは不要です。 その代わりに、アプリがリソースの読み込みの完了時に `DismissExtendedSplash` を呼び出し、そのメイン ページに移動します。

```cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.ApplicationModel.Activation;
using SplashScreenExample.Common;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/p/?LinkID=234238

namespace SplashScreenExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    partial class ExtendedSplash : Page
    {
        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        private SplashScreen splash; // Variable to hold the splash screen object.
        internal bool dismissed = false; // Variable to track splash screen dismissal status.
        internal Frame rootFrame;

        public ExtendedSplash(SplashScreen splashscreen, bool loadState)
        {
            InitializeComponent();

            // Listen for window resize events to reposition the extended splash screen image accordingly.
            // This is important to ensure that the extended splash screen is formatted properly in response to snapping, unsnapping, rotation, etc...
            Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

            splash = splashscreen;

            if (splash != null)
            {
                // Register an event handler to be executed when the splash screen has been dismissed.
                splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);

                // Retrieve the window coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();

                // Optional: Add a progress ring to your splash screen to show users that content is loading
                PositionRing();
            }

            // Create a Frame to act as the navigation context
            rootFrame = new Frame();

            // Restore the saved session state if necessary
            RestoreState(loadState);
        }

        void RestoreState(bool loadState)
        {
            if (loadState)
            {
                // TODO: write code to load state
            }
        }

        // Position the extended splash screen image in the same location as the system splash screen image.
        void PositionImage()
        {
            extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X);
            extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y);
            extendedSplashImage.Height = splashImageRect.Height;
            extendedSplashImage.Width = splashImageRect.Width;

        }

        void PositionRing()
        {
            splashProgressRing.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width*0.5) - (splashProgressRing.Width*0.5));
            splashProgressRing.SetValue(Canvas.TopProperty, (splashImageRect.Y + splashImageRect.Height + splashImageRect.Height*0.1));
        }

        void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
        {
            // Safely update the extended splash screen image coordinates. This function will be fired in response to snapping, unsnapping, rotation, etc...
            if (splash != null)
            {
                // Update the coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();
                PositionRing();
            }
        }

        // Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view).
        void DismissedEventHandler(SplashScreen sender, object e)
        {
            dismissed = true;

            // Complete app setup operations here...
        }

        void DismissExtendedSplash()
        {
            // Navigate to mainpage
            rootFrame.Navigate(typeof(MainPage));
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        void DismissSplashButton_Click(object sender, RoutedEventArgs e)
        {
            DismissExtendedSplash();
        }
    }
}
```

### <a name="appxamlcs"></a>App.xaml.cs

このプロジェクトは、UWP アプリを使用して作成された**空白アプリ (XAML)** Visual Studio でプロジェクト テンプレート。 `OnNavigationFailed` と `OnSuspending` の両方のイベント ハンドラーは自動的に生成され、追加スプラッシュ画面を実装するために変更する必要はありません。 このトピックでは、`OnLaunched` のみを変更します。

アプリのプロジェクト テンプレートを使用していない場合は、手順 4. を参照してください。[起動アクティブ化のハンドラーを変更](#modify-the-launch-activation-handler)修正後の例については`OnLaunched`を使用しない[フレーム](https://msdn.microsoft.com/library/windows/apps/br242682)ナビゲーション。

```cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at https://go.microsoft.com/fwlink/p/?LinkID=234227

namespace SplashScreenExample
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
            Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
            Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                //  Display an extended splash screen if app was not previously running.
                if (e.PreviousExecutionState != ApplicationExecutionState.Running)
                {
                    bool loadState = (e.PreviousExecutionState == ApplicationExecutionState.Terminated);
                    ExtendedSplash extendedSplash = new ExtendedSplash(e.SplashScreen, loadState);
                    rootFrame.Content = extendedSplash;
                    Window.Current.Content = rootFrame;
                }
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // TODO: Save applicaiton state and stop any background activity
            deferral.Complete();
        }
    }
}
```

## <a name="related-topics"></a>関連トピック


* [アプリのライフサイクル](app-lifecycle.md)

**リファレンス**

* [Windows.ApplicationModel.Activation 名前空間](https://msdn.microsoft.com/library/windows/apps/br224766)
* [Windows.ApplicationModel.Activation.SplashScreen クラス](https://msdn.microsoft.com/library/windows/apps/br224763)
* [Windows.ApplicationModel.Activation.SplashScreen.ImageLocation プロパティ](https://msdn.microsoft.com/library/windows/apps/br224765)
* [Windows.ApplicationModel.Core.CoreApplicationView.Activated イベント](https://msdn.microsoft.com/library/windows/apps/br225018)

 

 
