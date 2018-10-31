---
author: muhsinking
ms.assetid: 16AD53CA-1252-456C-8567-2263D3EC95F3
title: 傾斜計の使用
description: 傾斜計を使ってピッチ、ロール、ヨーを検出する方法を説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: dd335d56fb2a01ed1b9255f974bcaacd47f623f5
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5824224"
---
# <a name="use-the-inclinometer"></a>傾斜計の使用


**重要な API**

-   [**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**Inclinometer**](https://msdn.microsoft.com/library/windows/apps/BR225766)

**サンプル**

-   より完全な実装については、[傾斜計のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Inclinometer)をご覧ください。

傾斜計を使ってピッチ、ロール、ヨーを検出する方法を説明します。

一部の 3D ゲームでは、入力デバイスとして傾斜計が必要です。 よくある例としては、フライト シミュレーターがあります。傾斜計の 3 軸 (X、Y、Z) を、航空機のエレベーター、エルロン、ラダーの入力として割り当てます。

 ## <a name="prerequisites"></a>前提条件

Extensible Application Markup Language (XAML)、Microsoft VisualC \#、およびイベントを理解する必要があります。

使うデバイスやエミュレーターが傾斜計をサポートしている必要があります。

 ## <a name="create-a-simple-inclinometer-app"></a>シンプルな傾斜計アプリを作成する

このセクションは、次の 2 つのサブセクションに分かれています。 最初のサブセクションでは、シンプルな傾斜計アプリケーションを最初から作成するために必要な手順を示します。 次のサブセクションでは、作成したアプリについて説明します。

###  <a name="instructions"></a>手順

-   **[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。

-   プロジェクトの MainPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。

```csharp
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    using Windows.UI.Core;
    using Windows.Devices.Sensors;


    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private Inclinometer _inclinometer;

            // This event handler writes the current inclinometer reading to
            // the three text blocks on the app' s main page.

            private async void ReadingChanged(object sender, InclinometerReadingChangedEventArgs e)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    InclinometerReading reading = e.Reading;
                    txtPitch.Text = String.Format("{0,5:0.00}", reading.PitchDegrees);
                    txtRoll.Text = String.Format("{0,5:0.00}", reading.RollDegrees);
                    txtYaw.Text = String.Format("{0,5:0.00}", reading.YawDegrees);
                });
            }

            public MainPage()
            {
                this.InitializeComponent();
                _inclinometer = Inclinometer.GetDefault();


                if (_inclinometer != null)
                {
                    // Establish the report interval for all scenarios
                    uint minReportInterval = _inclinometer.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _inclinometer.ReportInterval = reportInterval;

                    // Establish the event handler
                    _inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer, InclinometerReadingChangedEventArgs>(ReadingChanged);
                }
            }
        }
    }
```

元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。 たとえば、作成したプロジェクトの名前が **InclinometerCS** だとすると、`namespace App1` を `namespace InclinometerCS` に置き換えます。

-   MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。

```xml
        <Page
        x:Class="App1.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">

        <Grid x:Name="LayoutRoot" Background="#FF0C0C0C">
            <TextBlock HorizontalAlignment="Left" Height="21" Margin="0,8,0,0" TextWrapping="Wrap" Text="Pitch: " VerticalAlignment="Top" Width="45" Foreground="#FFF9F4F4"/>
            <TextBlock x:Name="txtPitch" HorizontalAlignment="Left" Height="21" Margin="59,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="71" Foreground="#FFFDF9F9"/>
            <TextBlock HorizontalAlignment="Left" Height="23" Margin="0,29,0,0" TextWrapping="Wrap" Text="Roll:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F1F1"/>
            <TextBlock x:Name="txtRoll" HorizontalAlignment="Left" Height="23" Margin="59,29,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="50" Foreground="#FFFCF9F9"/>
            <TextBlock HorizontalAlignment="Left" Height="19" Margin="0,56,0,0" TextWrapping="Wrap" Text="Yaw:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F3F3"/>
            <TextBlock x:Name="txtYaw" HorizontalAlignment="Left" Height="19" Margin="55,56,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="54" Foreground="#FFF6F2F2"/>

        </Grid>
    </Page>
```

元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。 たとえば、作成したプロジェクトの名前が **InclinometerCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="InclinometerCS.MainPage"` に置き換えます。 また、`xmlns:local="using:App1"` を `xmlns:local="using:InclinometerCS"` に置き換える必要があります。

-   アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。

アプリを実行した後、デバイスを移動するか、エミュレーター ツールを使うことによって、傾斜計の値を変更できます。

-   アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。

###  <a name="explanation"></a>説明

上に示した例では、ごく短いコードを作成するだけで、傾斜計入力をアプリに組み込むことができることがわかります。

このアプリでは、**MainPage** メソッドで、既定の傾斜計との接続を確立しています。

```csharp
_inclinometer = Inclinometer.GetDefault();
```

このアプリでは、**MainPage** メソッドで、レポート間隔を設定しています。 次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。 サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。 それ以外の場合は、値を要求される間隔に設定します。

```csharp
uint minReportInterval = _inclinometer.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_inclinometer.ReportInterval = reportInterval;
```

**ReadingChanged** メソッドで、新しい傾斜計のデータをキャプチャしています。 センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。 このアプリの場合、このイベント ハンドラーが次の行で登録されています。

```csharp
_inclinometer.ReadingChanged += new TypedEventHandler<Inclinometer,
InclinometerReadingChangedEventArgs>(ReadingChanged);
```

プロジェクトの XAML 内にある TextBlock に、これらの新しい値が書き込まれます。

```xml
<TextBlock HorizontalAlignment="Left" Height="21" Margin="0,8,0,0" TextWrapping="Wrap" Text="Pitch: " VerticalAlignment="Top" Width="45" Foreground="#FFF9F4F4"/>
 <TextBlock x:Name="txtPitch" HorizontalAlignment="Left" Height="21" Margin="59,8,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="71" Foreground="#FFFDF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="23" Margin="0,29,0,0" TextWrapping="Wrap" Text="Roll:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F1F1"/>
 <TextBlock x:Name="txtRoll" HorizontalAlignment="Left" Height="23" Margin="59,29,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="50" Foreground="#FFFCF9F9"/>
 <TextBlock HorizontalAlignment="Left" Height="19" Margin="0,56,0,0" TextWrapping="Wrap" Text="Yaw:" VerticalAlignment="Top" Width="55" Foreground="#FFF7F3F3"/>
 <TextBlock x:Name="txtYaw" HorizontalAlignment="Left" Height="19" Margin="55,56,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="54" Foreground="#FFF6F2F2"/>
```

