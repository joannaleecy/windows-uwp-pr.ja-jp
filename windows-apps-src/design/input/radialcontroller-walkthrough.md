---
author: Karl-Bridge-Microsoft
ms.assetid: ''
title: UWP アプリで Surface Dial (およびその他のホイール デバイス) をサポートする
description: 作成した UWP アプリに Surface Dial (およびその他のホイール デバイス) のサポートを追加するための、ステップ バイ ステップ チュートリアルです。
keywords: ダイヤル, ラジアル, チュートリアル
ms.author: kbridge
ms.date: 01/25/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: c7dc6436e1a233a6b0a74a787b5c30de47899eff
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5443504"
---
# <a name="tutorial-support-the-surface-dial-and-other-wheel-devices-in-your-uwp-app"></a>チュートリアル: UWP アプリで Surface Dial (およびその他のホイール デバイス) をサポートする

![Surface Dial と Surface Studio の画像](images/radialcontroller/dial-pen-studio-600px.png)  
*Surface Dial と Surface Studio、Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacedial)で購入できます)。

このチュートリアルでは、Surface Dial などのホイール デバイスでサポートされている、ユーザー操作エクスペリエンスをカスタマイズする手順を示します。 使用するサンプル アプリは GitHub ([サンプル コード](#sample-code)) からダウンロードできます。このサンプル アプリのスニペットは、各手順でのさまざまな機能と関連する [**RadialController**](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) API の使い方を示します。

次の点を中心に説明します。
* [**RadialController**](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) メニューに表示される組み込みのツールを指定する
* メニューにカスタム ツールを追加する
* 触覚フィードバックを制御する
* クリック操作をカスタマイズする
* 回転操作をカスタマイズする

これらおよびその他の機能の実装について詳しくは、「[UWP アプリでの Surface Dial の操作](windows-wheel-interactions.md)」をご覧ください。

## <a name="introduction"></a>概要

Surface Dial は、ペン、タッチ、マウスなどの主要な入力デバイスと共に使ってユーザーの生産性を向上させるための、セカンダリ入力デバイスです。 Dial は、セカンダリ入力デバイスとして、通常は利き手以外の手で使用し、システム コマンドおよびその他のコンテキスト依存のツールや機能へのアクセスを提供します。 

Dial は、次の 3 つの基本的なジェスチャをサポートしています。 
- 長押しすると、組み込みのコマンド メニューを表示します。
- 回転させると、(メニューがアクティブな場合は) メニュー項目を強調表示します。(メニューがアクティブでない場合は) アプリの現在の動作を変更します。
- クリックすると、(メニューがアクティブな場合は) 強調表示されたメニュー項目を選択します。(メニューがアクティブでない場合は) アプリのコマンドを起動します。

## <a name="prerequisites"></a>前提条件

* Windows 10 Creators Update またはそれ以降を実行しているコンピューター (または、仮想マシン)
* [Visual Studio 2017 (10.0.15063.0)](https://developer.microsoft.com/windows/downloads)
* [Windows 10 SDK (10.0.15063.0)](https://developer.microsoft.com/windows/downloads/windows-10-sdk)
* ホイール デバイス (現時点では [Surface Dial](https://aka.ms/purchasesurfacedial) のみ)
* Visual Studio を使ってユニバーサル Windows プラットフォーム (UWP) アプリの開発を初めて行う場合は、このチュートリアルを開始する前に、次のトピックをご覧ください。  
    * [準備](https://docs.microsoft.com/windows/uwp/get-started/get-set-up)
    * ["Hello, world" アプリを作成する (XAML)](https://docs.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)

## <a name="set-up-your-devices"></a>デバイスをセットアップする

1. Windows デバイスがオンになっていることを確認します。
2. [**スタート**] に移動し、[**設定**] > [**デバイス]** > [**Bluetooth とその他のデバイス**] の順に選択して、[**Bluetooth**] をオンにします。
3. Surface Dial の下部のバッテリ収納部を開き、単 4 電池が 2 本入っていることを確認します。
4. Dial の底面にバッテリのタブが残っている場合には、それを取り外します。
5. バッテリの横にある小さな押しボタンを、Bluetooth のライトが点滅するまで長押しします。
6. Windows デバイスに戻り、[**Bluetooth またはその他のデバイスを追加する**] を選びます。
7. [**デバイスの追加**] ダイアログ ボックスで、[**Bluetooth**] > [**Surface Dial**] の順に選びます。 Surface Dial が接続されて、[**Bluetooth とその他のデバイス**] 設定ページの [**マウス、キーボード、ペン**] の下のデバイスの一覧に追加されます。
8. Dial を数秒ほど長押しして、組み込みのメニューが表示されるかどうかテストします。
9. (Dial ダイヤルはバイブレーションします)、画面にメニューが表示されない場合は、Bluetooth の設定に戻すには、デバイスを削除し、もう一度デバイスを接続してみてくださいを移動します。

> [!NOTE]
> ホイール デバイスは [**ホイール**] 設定から構成できます。
> 1. [**スタート**] メニューで [**設定**] を選びます。
> 2. [**デバイス**] > [**ホイール**] の順に選びます。    
> ![ホイール設定画面](images/radialcontroller/wheel-settings.png)

これでチュートリアルを開始する準備ができました。 

## <a name="sample-code"></a>サンプル コード
このチュートリアル全体で、1 つサンプル アプリを使って概念と機能を説明します。

この Visual Studio サンプルとソース コードは [GitHub](https://github.com/) の [windows-appsample-get-started-radialcontroller sample](https://aka.ms/appsample-radialcontroller) からダウンロードできます。

1. 緑の [**Clone or download**] (複製またはダウンロード) ボタンを選択します。  
![リポジトリを複製する](images/radialcontroller/wheel-clone.png)
2. GitHub のアカウントを使っている場合には、[**Open in Visual Studio**] (Visual Studio で開く) を選択して、リポジトリをローカル コンピューターに複製できます。 
3. GitHub アカウントを使っていない場合、またはプロジェクトのローカル コピーのみが必要な場合には、[**Download ZIP**] (ZIP をダウンロードする) を選択します (最新の更新をダウンロードするには、定期的に確認する必要があります)。

> [!IMPORTANT]
> サンプル コードのほとんどの部分はコメント アウトされています。このトピックの各手順を進めていく際に、コードの各セクションのコメントを解除します。 Visual Studio では、コードの行を強調表示して Ctrl + K キーを押して Ctrl + U キーを押します。

## <a name="components-that-support-wheel-functionality"></a>ホイール機能をサポートするコンポーネント

これらのオブジェクトは、UWP アプリにホイール デバイスのさまざまなエクスペリエンスを提供します。

| コンポーネント | 説明 |
| --- | --- |
| [**RadialController** クラス](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.RadialController)および関連 | Surface Dial などのホイール入力デバイスまたはアクセサリを表します。 |
| [**IRadialControllerConfigurationInterop**](https://msdn.microsoft.com/library/windows/desktop/mt790709) / [**IRadialControllerInterop**](https://msdn.microsoft.com/library/windows/desktop/mt790711)<br/>この機能はこのドキュメントの範囲外です。詳しくは、「[Windows クラシック デスクトップ サンプル](https://aka.ms/radialcontrollerclassicsample)」をご覧ください。 | UWP アプリとの相互運用性を提供します。 |

## <a name="step-1-run-the-sample"></a>手順 1: サンプルを実行する

RadialController サンプル アプリをダウンロードしたら、実行できることを確認します。
1. Visual Studio でサンプル プロジェクトを開きます。
2. [**ソリューション プラットフォーム**] のドロップダウンを ARM 以外の選択肢に設定します。
3. F5 キーを押して、コンパイル、展開、および実行します。 

> [!NOTE]
> または、[**デバッグ**] > [**デバッグの開始**] メニュー項目を選択するか、または [**ローカル コンピューター**] の実行ボタンを選択することもできます。![Visual Studio のプロジェクトのビルドのボタン](images/radialcontroller/wheel-vsrun.png)

アプリ ウィンドウが開き、スプラッシュ画面が数秒表示されて、次のような初期画面が表示されます。

![空のアプリ](images/radialcontroller/wheel-app-step1-empty.png)

これでチュートリアルの残りの部分で使う、基本的な UWP アプリの準備ができました。 これ以降の手順では、**RadialController** の機能を追加します。

## <a name="step-2-basic-radialcontroller-functionality"></a>手順 2: 基本的な RadialController 機能

アプリを実行して、フォア グラウンドで Surface Dial を長押しすると、**RadialController ** メニューが表示されます。

まだアプリ用のカスタマイズを行っていないため、メニューにはコンテキスト依存の既定のツールのセットが含まれています。 

次の画像は、既定のメニューの 2 つのバリエーションを示しています。 (既定のメニューは他にも多数あります。たとえば、Windows デスクトップがアクティブで、他にフォアグラウンドのアプリがない場合の基本的なシステム ツールのみのメニューや、InkToolbar が表示されているときに手描き入力ツールが追加されているメニューや、マップ アプリを使っているときのマッピング ツールなどがあります。)

| RadialController メニュー (既定)  | RadialController メニュー (メディアの再生時の既定)  |
|---|---|
| ![既定の RadialController メニュー](images/radialcontroller/wheel-app-step2-basic-default.png) | ![音楽再生時の既定の RadialController メニュー](images/radialcontroller/wheel-app-step2-basic-withmusic.png) |

これで基本的なカスタマイズを始める準備ができました。

## <a name="step-3-add-controls-for-wheel-input"></a>手順 3: ホイール入力のコントロールを追加する

まず、アプリの UI を追加します。

1. MainPage_Basic.xaml ファイルを開きます。
2. この手順のタイトル ("\<!-- Step 3: Add controls for wheel input -->") が付いているコードを見つけます。
3. 以下の行のコメントを解除します。

    ```xaml
    <Button x:Name="InitializeSampleButton" 
            HorizontalAlignment="Center" 
            Margin="10" 
            Content="Initialize sample" />
    <ToggleButton x:Name="AddRemoveToggleButton"
                    HorizontalAlignment="Center" 
                    Margin="10" 
                    Content="Remove Item"
                    IsChecked="True" 
                    IsEnabled="False"/>
    <Button x:Name="ResetControllerButton" 
            HorizontalAlignment="Center" 
            Margin="10" 
            Content="Reset RadialController menu" 
            IsEnabled="False"/>
    <Slider x:Name="RotationSlider" Minimum="0" Maximum="10"
            Width="300"
            HorizontalAlignment="Center"/>
    <TextBlock Text="{Binding ElementName=RotationSlider, Mode=OneWay, Path=Value}"
                Margin="0,0,0,20"
                HorizontalAlignment="Center"/>
    <ToggleSwitch x:Name="ClickToggle"
                    MinWidth="0" 
                    Margin="0,0,0,20"
                    HorizontalAlignment="center"/>
    ```
この時点では、[**Initialize sample**] (サンプルの初期化) ボタン、スライダー、トグル スイッチのみを有効にします。 他のボタンは後の手順で使用して、スライダーとトグル スイッチへのアクセスを提供する **RadialController** のメニュー項目の追加と削除を行います。

![基本的なサンプル アプリの UI](images/radialcontroller/wheel-app-step3-basicui.png)

## <a name="step-4-customize-the-basic-radialcontroller-menu"></a>手順 4: 基本的な RadialController メニューをカスタマイズする

**RadialController** のアクセスを有効にするために必要なコードをコントロールに追加します。

1. MainPage_Basic.xaml.cs ファイルを開きます。
2. この手順のタイトル ("// Step 4: Basic RadialController menu customization") が付いているコードを見つけます。
3. 以下の行のコメントを解除します。
    - [Windows.UI.Input](https://docs.microsoft.com/uwp/api/windows.ui.input) および [Windows.Storage.Streams](https://docs.microsoft.com/uwp/api/windows.storage.streams) 型参照は、以降の手順の機能に使用されます。  
    
        ```csharp
        // Using directives for RadialController functionality.
        using Windows.UI.Input;
        ```

    - 次のグローバル オブジェクト ([RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller)、[RadialControllerConfiguration](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration)、[RadialControllerMenuItem](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem)) はアプリ全体で使用されます。
    
        ```csharp
        private RadialController radialController;
        private RadialControllerConfiguration radialControllerConfig;
        private RadialControllerMenuItem radialControllerMenuItem;
        ```

    - ここでは、ボタンに **Click** ハンドラーを指定して、コントロールを有効化し、カスタムの **RadialController** メニュー項目を初期化します。

        ```csharp
        InitializeSampleButton.Click += (sender, args) =>
        { InitializeSample(sender, args); };
        ``` 

    - 次に、[RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) オブジェクトを初期化し、[RotationChanged](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationChanged) および [ButtonClicked](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ButtonClicked) イベントのハンドラーを設定します。

        ```csharp
        // Set up the app UI and RadialController.
        private void InitializeSample(object sender, RoutedEventArgs e)
        {
            ResetControllerButton.IsEnabled = true;
            AddRemoveToggleButton.IsEnabled = true;

            ResetControllerButton.Click += (resetsender, args) =>
            { ResetController(resetsender, args); };
            AddRemoveToggleButton.Click += (togglesender, args) =>
            { AddRemoveItem(togglesender, args); };

            InitializeController(sender, e);
        }
        ```

    - ここでは、カスタムの RadialController メニュー項目を初期化します。 [CreateForCurrentView](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.CreateForCurrentView) を使って [RadialController](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller) オブジェクトへの参照を取得します。[RotationResolutionInDegrees](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationResolutionInDegrees) プロパティを使って、回転の感度を "1" に設定します。次に [CreateFromFontGlyph](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem.CreateFromFontGlyph) を使って [RadialControllerMenuItem](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollermenuitem) を作成します。**RadialController** メニュー項目コレクションにメニュー項目を追加します。最後に、[SetDefaultMenuItems](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration.setdefaultmenuitems) を使って既定のメニュー項目をクリアして、カスタム ツールのみを残します。 

        ```csharp
        // Configure RadialController menu and custom tool.
        private void InitializeController(object sender, RoutedEventArgs args)
        {
            // Create a reference to the RadialController.
            radialController = RadialController.CreateForCurrentView();
            // Set rotation resolution to 1 degree of sensitivity.
            radialController.RotationResolutionInDegrees = 1;

            // Create the custom menu items.
            // Here, we use a font glyph for our custom tool.
            radialControllerMenuItem =
                RadialControllerMenuItem.CreateFromFontGlyph("SampleTool", "\xE1E3", "Segoe MDL2 Assets");

            // Add the item to the RadialController menu.
            radialController.Menu.Items.Add(radialControllerMenuItem);

            // Remove built-in tools to declutter the menu.
            // NOTE: The Surface Dial menu must have at least one menu item. 
            // If all built-in tools are removed before you add a custom 
            // tool, the default tools are restored and your tool is appended 
            // to the default collection.
            radialControllerConfig =
                RadialControllerConfiguration.GetForCurrentView();
            radialControllerConfig.SetDefaultMenuItems(
                new RadialControllerSystemMenuItemKind[] { });

            // Declare input handlers for the RadialController.
            // NOTE: These events are only fired when a custom tool is active.
            radialController.ButtonClicked += (clicksender, clickargs) =>
            { RadialController_ButtonClicked(clicksender, clickargs); };
            radialController.RotationChanged += (rotationsender, rotationargs) =>
            { RadialController_RotationChanged(rotationsender, rotationargs); };
        }

        // Connect wheel device rotation to slider control.
        private void RadialController_RotationChanged(
            object sender, RadialControllerRotationChangedEventArgs args)
        {
            if (RotationSlider.Value + args.RotationDeltaInDegrees >= RotationSlider.Maximum)
            {
                RotationSlider.Value = RotationSlider.Maximum;
            }
            else if (RotationSlider.Value + args.RotationDeltaInDegrees < RotationSlider.Minimum)
            {
                RotationSlider.Value = RotationSlider.Minimum;
            }
            else
            {
                RotationSlider.Value += args.RotationDeltaInDegrees;
            }
        }

        // Connect wheel device click to toggle switch control.
        private void RadialController_ButtonClicked(
            object sender, RadialControllerButtonClickedEventArgs args)
        {
            ClickToggle.IsOn = !ClickToggle.IsOn;
        }
        ```
4. では、アプリを再度実行します。
5. [**Initialize radial controller**] (リング コントローラーの初期化) ボタンを選択します。  
6. アプリをフォア グラウンドにして、Surface Dial を長押しすると、メニューが表示されます。 (**RadialControllerConfiguration.SetDefaultMenuItems** メソッドにより) すべての既定のツールが削除されていること、カスタム ツールのみが残っていることを確認します。 作成したカスタム ツールを含むメニューは次のようになります。 

| RadialController メニュー (カスタム)  | 
|---|
| ![カスタムの RadialController メニュー](images/radialcontroller/wheel-app-step3-custom.png) |

7. カスタム ツールを選択して、Surface Dial によってサポートされている操作を試します。
    * 回転操作によって、スライダーを移動します。 
    * クリックによって、オン/オフが切り替わります。

では、次にボタンを接続しましょう。

## <a name="step-5-configure-menu-at-runtime"></a>手順 5: 実行時にメニューを構成する

この手順では、[**Add/Remove item**] (項目の追加と削除) ボタンと [**Reset RadialController menu**] (RadialController メニューのリセット) ボタンを接続して、メニューを動的にカスタマイズする方法を説明します。

1. MainPage_Basic.xaml.cs ファイルを開きます。
2. この手順のタイトル ("// Step 5: Configure menu at runtime") が付いているコードを見つけます。
3. 次のメソッドのコードのコメントを解除し、アプリをもう一度実行します。ただし、どのボタンも選択しないでください (それは次の手順で行います)。  

    ``` csharp
    // Add or remove the custom tool.
    private void AddRemoveItem(object sender, RoutedEventArgs args)
    {
        if (AddRemoveToggleButton?.IsChecked == true)
        {
            AddRemoveToggleButton.Content = "Remove item";
            if (!radialController.Menu.Items.Contains(radialControllerMenuItem))
            {
                radialController.Menu.Items.Add(radialControllerMenuItem);
            }
        }
        else if (AddRemoveToggleButton?.IsChecked == false)
        {
            AddRemoveToggleButton.Content = "Add item";
            if (radialController.Menu.Items.Contains(radialControllerMenuItem))
            {
                radialController.Menu.Items.Remove(radialControllerMenuItem);
                // Attempts to select and activate the previously selected tool.
                // NOTE: Does not differentiate between built-in and custom tools.
                radialController.Menu.TrySelectPreviouslySelectedMenuItem();
            }
        }
    }

    // Reset the RadialController to initial state.
    private void ResetController(object sender, RoutedEventArgs arg)
    {
        if (!radialController.Menu.Items.Contains(radialControllerMenuItem))
        {
            radialController.Menu.Items.Add(radialControllerMenuItem);
        }
        AddRemoveToggleButton.Content = "Remove item";
        AddRemoveToggleButton.IsChecked = true;
        radialControllerConfig.SetDefaultMenuItems(
            new RadialControllerSystemMenuItemKind[] { });
    }
    ```
4. [**Remove item**] (項目を削除する) ボタンを選択し、次に Dial を長押しして、再度メニューを表示させます。

    メニューにツールの既定のコレクションが含まれていることを確認します。 手順 3 でカスタム メニューをセットアップしたときに、すべての既定のツールを削除して、カスタム ツールだけを追加したことを思い出してください。 さらに、メニューを空のコレクションに設定すると、現在のコンテキストに既定の項目が再配置されたことにも注意します。 (既定のツールを削除する前にカスタム ツールを追加しました。)

5. [**Add item**] (項目の追加) ボタンを選択して、次に Dial を長押しします。

    メニューに、既定のツールのコレクションと、カスタム ツールの両方が含まれていることを確認します。

6. [**Reset RadialController menu**] (RadialController メニューのリセット) ボタンを選択し、次に Dial を長押しします。

    メニューが元の状態に戻ったことを確認します。

## <a name="step-6-customize-the-device-haptics"></a>手順 6: デバイスのハプティクス (触覚) をカスタマイズする
Surface Dial およびその他のホイール デバイスは、現在の操作に対応する触覚フィードバック (クリックまたは回転のいずれかに基づく) をユーザーに提供できます。

この手順では、触覚フィードバックをカスタマイズする方法を説明します。ここでは、スライダーとトグル スイッチ コントロールを関連付け、それらを使って動的に触覚フィードバック動作を指定します。 この例では、フィードバックを有効にするには、トグル スイッチをオンにする必要があります。スライダーの値により、クリックのフィードバックの反復頻度を指定します。 

> [!NOTE]
> 触覚フィードバックは、ユーザーにより [**設定**] >  [**デバイス**] > [**ホイール**] ページで無効にすることができます。

1. App.xaml.cs ファイルを開きます。
2. この手順のタイトル ("Step 6: Customize the device haptics") が付いているコードを見つけます。
3. 1 行目と 3 行目 ("MainPage_Basic" と "MainPage") をコメントのままとして、2 行目 ("MainPage_Haptics") のコメントを解除します。  

    ``` csharp
    rootFrame.Navigate(typeof(MainPage_Basic), e.Arguments);
    rootFrame.Navigate(typeof(MainPage_Haptics), e.Arguments);
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
    ```
4. MainPage_Haptics.xaml ファイルを開きます。
5. この手順のタイトル ("\<!-- Step 6: Customize the device haptics -->") が付いているコードを見つけます。
6. 以下の行のコメントを解除します。 (この UI コードは、単に現在のデバイスでサポートされているハプティックス機能を示します。)    

    ```xaml
    <StackPanel x:Name="HapticsStack" 
                Orientation="Vertical" 
                HorizontalAlignment="Center" 
                BorderBrush="Gray" 
                BorderThickness="1">
        <TextBlock Padding="10" 
                    Text="Supported haptics properties:" />
        <CheckBox x:Name="CBDefault" 
                    Content="Default" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsChecked="True" />
        <CheckBox x:Name="CBIntensity" 
                    Content="Intensity" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBPlayCount" 
                    Content="Play count" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBPlayDuration" 
                    Content="Play duration" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBReplayPauseInterval" 
                    Content="Replay/pause interval" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBBuzzContinuous" 
                    Content="Buzz continuous" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBClick" 
                    Content="Click" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBPress" 
                    Content="Press" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBRelease" 
                    Content="Release" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
        <CheckBox x:Name="CBRumbleContinuous" 
                    Content="Rumble continuous" 
                    Padding="10" 
                    IsEnabled="False" 
                    IsThreeState="True" 
                    IsChecked="{x:Null}" />
    </StackPanel>
    ```
7. MainPage_Haptics.xaml.cs ファイルを開きます。
8. この手順のタイトル ("Step 6: Haptics customization") が付いているコードを見つけます。
9. 以下の行のコメントを解除します。  

    - [Windows.Devices.Haptics](https://docs.microsoft.com/uwp/api/windows.devices.haptics) 型参照は、以降の手順の機能に使用されます。  
    
        ```csharp
        using Windows.Devices.Haptics;
        ```

    - ここでは、[ControlAcquired](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ControlAcquired) イベントのハンドラーを指定します。これはカスタムの **RadialController** メニュー項目が選択されたときにトリガーされます。

        ```csharp
        radialController.ControlAcquired += (rc_sender, args) =>
        { RadialController_ControlAcquired(rc_sender, args); };
        ``` 

    - 次に、[ControlAcquired](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ControlAcquired) ハンドラーを定義します。ここでは、既定の触覚フィードバックを無効化して、ハプティクス UI を初期化します。

        ```csharp
        private void RadialController_ControlAcquired(
            RadialController rc_sender,
            RadialControllerControlAcquiredEventArgs args)
        {
            // Turn off default haptic feedback.
            radialController.UseAutomaticHapticFeedback = false;

            SimpleHapticsController hapticsController =
                args.SimpleHapticsController;

            // Enumerate haptic support.
            IReadOnlyCollection<SimpleHapticsControllerFeedback> supportedFeedback =
                hapticsController.SupportedFeedback;

            foreach (SimpleHapticsControllerFeedback feedback in supportedFeedback)
            {
                if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.BuzzContinuous)
                {
                    CBBuzzContinuous.IsEnabled = true;
                    CBBuzzContinuous.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.Click)
                {
                    CBClick.IsEnabled = true;
                    CBClick.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.Press)
                {
                    CBPress.IsEnabled = true;
                    CBPress.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.Release)
                {
                    CBRelease.IsEnabled = true;
                    CBRelease.IsChecked = true;
                }
                else if (feedback.Waveform == KnownSimpleHapticsControllerWaveforms.RumbleContinuous)
                {
                    CBRumbleContinuous.IsEnabled = true;
                    CBRumbleContinuous.IsChecked = true;
                }
            }

            if (hapticsController?.IsIntensitySupported == true)
            {
                CBIntensity.IsEnabled = true;
                CBIntensity.IsChecked = true;
            }
            if (hapticsController?.IsPlayCountSupported == true)
            {
                CBPlayCount.IsEnabled = true;
                CBPlayCount.IsChecked = true;
            }
            if (hapticsController?.IsPlayDurationSupported == true)
            {
                CBPlayDuration.IsEnabled = true;
                CBPlayDuration.IsChecked = true;
            }
            if (hapticsController?.IsReplayPauseIntervalSupported == true)
            {
                CBReplayPauseInterval.IsEnabled = true;
                CBReplayPauseInterval.IsChecked = true;
            }
        }
        ```

    - [RotationChanged](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.RotationChanged) および [ButtonClicked](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontroller.ButtonClicked) イベント ハンドラーで、対応するスライダーとトグル ボタン コントロールをカスタム ハプティクスに接続します。 

        ```csharp
        // Connect wheel device rotation to slider control.
        private void RadialController_RotationChanged(
            object sender, RadialControllerRotationChangedEventArgs args)
        {
            ...
            if (ClickToggle.IsOn && 
                (RotationSlider.Value > RotationSlider.Minimum) && 
                (RotationSlider.Value < RotationSlider.Maximum))
            {
                SimpleHapticsControllerFeedback waveform = 
                    FindWaveform(args.SimpleHapticsController, 
                    KnownSimpleHapticsControllerWaveforms.BuzzContinuous);
                if (waveform != null)
                {
                    args.SimpleHapticsController.SendHapticFeedback(waveform);
                }
            }
        }

        private void RadialController_ButtonClicked(
            object sender, RadialControllerButtonClickedEventArgs args)
        {
            ...

            if (RotationSlider?.Value > 0)
            {
                SimpleHapticsControllerFeedback waveform = 
                    FindWaveform(args.SimpleHapticsController, 
                    KnownSimpleHapticsControllerWaveforms.Click);

                if (waveform != null)
                {
                    args.SimpleHapticsController.SendHapticFeedbackForPlayCount(
                        waveform, 1.0, 
                        (int)RotationSlider.Value, 
                        TimeSpan.Parse("1"));
                }
            }
        }
        ```
    - 最後に、触覚フィードバックに要求した**[波形](https://docs.microsoft.com/uwp/api/windows.devices.haptics.simplehapticscontrollerfeedback.Waveform)** (サポートされている場合) を取得します。 

        ```csharp
        // Get the requested waveform.
        private SimpleHapticsControllerFeedback FindWaveform(
            SimpleHapticsController hapticsController,
            ushort waveform)
        {
            foreach (var hapticInfo in hapticsController.SupportedFeedback)
            {
                if (hapticInfo.Waveform == waveform)
                {
                    return hapticInfo;
                }
            }
            return null;
        }
        ```

アプリを再度実行し、スライダーの値とトグル スイッチの状態を変更して、カスタム ハプティクスを試します。

## <a name="step-7-define-on-screen-interactions-for-surface-studio-and-similar-devices"></a>手順 7: Surface Studio や類似のデバイスのオンスクリーンの操作を定義する
Surface Dial は Surface Studio と一緒に使うことによって、さらに独創的なユーザー エクスペリエンスを提供できます。 

先ほど説明した既定の長押しメニューのエクスペリエンスに加えて、Surface Dial は Surface Studio の画面上に直接配置できます。 これにより、特殊な "オンスクリーン" メニューが実現されます。 

Surface Dial の接触位置と境界の両方を検出することにより、システムはデバイスによるオクルージョンを処理し、Dial の外側を囲むように大きいバージョンのメニューを表示します。 この同じ情報をアプリで使用して、デバイスの存在とその予想される使用状況 (ユーザーの手や腕の配置など) の両方に合わせて UI を調整することもできます。 

このチュートリアルのサンプルには、これらの機能の一部を使った、より高度な例が含まれています。

この例を実行するには、次の手順を行います (Surface Studio が必要となります)。

1. (Visual Studio がインストールされている) Surface Studio デバイスで、サンプルをダウンロードします。
2. Visual Studio でサンプルを開きます
3. App.xaml.cs ファイルを開きます
4. この手順のタイトル  ("Step 7: Define on-screen interactions for Surface Studio and similar devices") が付いているコードを見つけます。
5. 1 行目と 2 行目 ("MainPage_Basic" と "MainPage_Haptics") をコメントのままとして、3 行目 ("MainPage") のコメントを解除します  

    ``` csharp
    rootFrame.Navigate(typeof(MainPage_Basic), e.Arguments);
    rootFrame.Navigate(typeof(MainPage_Haptics), e.Arguments);
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
    ```
6. アプリを実行し、2 つのコントロール領域に、交互に Surface Dial を配置します。    
![オンスクリーンの RadialController](images/radialcontroller/wheel-app-step5-onscreen2.png) 

    このサンプルの動作のビデオを次に示します。  

    <iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Programming-the-Microsoft-Surface-Dial/player" width="600" height="400" allowFullScreen frameBorder="0"></iframe>  

## <a name="summary"></a>まとめ

*入門チュートリアル: UWP アプリで Surface Dial (およびその他のホイール デバイス) をサポートする*はこれで完成です。 このチュートリアルでは、UWP アプリでホイール デバイスをサポートするために必要となる基本的なコードを示し、さらに **RadialController** API でサポートされる高度なユーザー エクスペリエンスを提供する方法について説明しました。
