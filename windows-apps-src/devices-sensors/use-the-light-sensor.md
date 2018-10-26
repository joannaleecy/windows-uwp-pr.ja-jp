---
author: muhsinking
ms.assetid: 15BAB25C-DA8C-4F13-9B8F-EA9E4270BCE9
title: 光センサーの使用
description: 環境光センサーを使って環境光の変化を検出する方法を説明します。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e6f7f838e5640f873593ac2e08c6a9b30f5258e5
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5568421"
---
# <a name="use-the-light-sensor"></a>光センサーの使用


**重要な API**

-   [**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**LightSensor**](https://msdn.microsoft.com/library/windows/apps/BR225790)

**サンプル**

-   より完全な実装については、[光センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LightSensor)をご覧ください。

環境光センサーを使って環境光の変化を検出する方法を説明します。

ユーザーの環境の変化に反応するアプリを作成するための環境センサーは各種存在しますが、環境光センサーはその中の 1 つです。

## <a name="prerequisites"></a>前提条件

Extensible Application Markup Language (XAML)、Microsoft VisualC \#、およびイベントを理解する必要があります。

使うデバイスやエミュレーターが環境光センサーをサポートしている必要があります。

## <a name="create-a-simple-light-sensor-app"></a>シンプルな光センサー アプリを作成する

このセクションは、次の 2 つのサブセクションに分かれています。 最初のサブセクションでは、シンプルな光センサー アプリケーションを最初から作成するために必要な手順を示します。 次のサブセクションでは、作成したアプリについて説明します。

###  <a name="instructions"></a>手順

-   **[Visual C#]** プロジェクト テンプレートから **[空白のアプリ (ユニバーサル Windows]** を選んで、新しいプロジェクトを作成します。

-   プロジェクトの BlankPage.xaml.cs ファイルを開き、記載されているコードを次のコードで置き換えます。

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

    using Windows.UI.Core; // Required to access the core dispatcher object
    using Windows.Devices.Sensors; // Required to access the sensor platform and the ALS

    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/p/?linkid=234238

    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class BlankPage : Page
        {
            private LightSensor _lightsensor; // Our app' s lightsensor object

            // This event handler writes the current light-sensor reading to
            // the textbox named "txtLUX" on the app' s main page.

            private void ReadingChanged(object sender, LightSensorReadingChangedEventArgs e)
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, (s, a) =>
                {
                    LightSensorReading reading = (a.Context as LightSensorReadingChangedEventArgs).Reading;
                    txtLuxValue.Text = String.Format("{0,5:0.00}", reading.IlluminanceInLux);
                });
            }

            public BlankPage()
            {
                InitializeComponent();
                _lightsensor = LightSensor.GetDefault(); // Get the default light sensor object

                // Assign an event handler for the ALS reading-changed event
                if (_lightsensor != null)
                {
                    // Establish the report interval for all scenarios
                    uint minReportInterval = _lightsensor.MinimumReportInterval;
                    uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
                    _lightsensor.ReportInterval = reportInterval;

                    // Establish the even thandler
                    _lightsensor.ReadingChanged += new TypedEventHandler<LightSensor, LightSensorReadingChangedEventArgs>(ReadingChanged);
                }

            }

        }
    }
```

元のスニペットの名前空間の名前を、自分のプロジェクトに指定した名前に変更する必要があります。 たとえば、作成したプロジェクトの名前が **LightingCS** だとすると、`namespace App1` を `namespace LightingCS` に置き換えます。

-   MainPage.xaml ファイルを開き、元の内容を次の XML に置き換えます。

```xml
    <Page
        x:Class="App1.BlankPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App1"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">

        <Grid x:Name="LayoutRoot" Background="Black">
            <TextBlock HorizontalAlignment="Left" Height="44" Margin="52,38,0,0" TextWrapping="Wrap" Text="LUX Reading" VerticalAlignment="Top" Width="150"/>
            <TextBlock x:Name="txtLuxValue" HorizontalAlignment="Left" Height="44" Margin="224,38,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="217"/>


        </Grid>

    </Page>
```

元のスニペットのクラス名の最初の部分を、自分のアプリの名前空間に置き換える必要があります。 たとえば、作成したプロジェクトの名前が **LightingCS** だとすると、`x:Class="App1.MainPage"` を `x:Class="LightingCS.MainPage"` に置き換えます。 また、`xmlns:local="using:App1"` を `xmlns:local="using:LightingCS"` に置き換える必要があります。

-   アプリをビルド、展開、実行するには、F5 キーを押すか、**[デバッグ]**、**[デバッグの開始]** の順にクリックします。

アプリを実行した後、センサーに当てる光を変更するか、エミュレーター ツールを使うことによって、光センサーの値を変更できます。

-   アプリを停止するには、Visual Studio に戻り、Shift キーを押しながら F5 キーを押すか、**[デバッグ]**、**[デバッグの停止]** の順にクリックします。

###  <a name="explanation"></a>説明

上に示した例では、ごく短いコードを作成するだけで、光センサー入力をアプリに組み込むことができることがわかります。

このアプリでは、**BlankPage** メソッドで、既定のセンサーとの接続を確立しています。

```csharp
_lightsensor = LightSensor.GetDefault(); // Get the default light sensor object
```

このアプリでは、**BlankPage** メソッドで、レポート間隔を設定しています。 次のコードは、デバイスでサポートされる最小の間隔を取得し、要求される 16 ミリ秒の間隔 (約 60 Hz のリフレッシュ レート) と比較します。 サポートされる最小の間隔が要求される間隔よりも大きい場合は、値を最小値に設定します。 それ以外の場合は、値を要求される間隔に設定します。

```csharp
uint minReportInterval = _lightsensor.MinimumReportInterval;
uint reportInterval = minReportInterval > 16 ? minReportInterval : 16;
_lightsensor.ReportInterval = reportInterval;
```
**ReadingChanged** メソッドで、新しい光センサー データをキャプチャしています。 センサーのドライバーは、センサーから新しいデータを受け取るたびに、このイベント ハンドラーを使ってアプリに値を渡します。 このアプリの場合、このイベント ハンドラーが次の行で登録されています。

```csharp
_lightsensor.ReadingChanged += new TypedEventHandler<LightSensor,
LightSensorReadingChangedEventArgs>(ReadingChanged);
```

プロジェクトの XAML 内にある TextBlock に、以下の新しい値が書き込まれます。

```xml
<TextBlock HorizontalAlignment="Left" Height="44" Margin="52,38,0,0" TextWrapping="Wrap" Text="LUX Reading" VerticalAlignment="Top" Width="150"/>
 <TextBlock x:Name="txtLuxValue" HorizontalAlignment="Left" Height="44" Margin="224,38,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="217"/>
```