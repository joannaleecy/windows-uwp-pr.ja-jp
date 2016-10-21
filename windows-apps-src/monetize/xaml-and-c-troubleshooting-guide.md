---
author: mcleanbyron
ms.assetid: 141900dd-f1d3-4432-ac8b-b98eaa0b0da2
description: "XAML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策の詳細"
title: "XAML と C# のトラブルシューティング ガイド"
translationtype: Human Translation
ms.sourcegitcommit: 5bf07d3001e92ed16931be516fe059ad33c08bb9
ms.openlocfilehash: 0688ca6e0c88628803ad4e9a55b9285bd39351b4

---

# XAML と C# のトラブルシューティング ガイド



このトピックでは、XAML アプリの Microsoft Advertising ライブラリに関する、開発上の一般的な問題に対する解決策について説明します。

-   [XAML](#xaml)

    -   [AdControl が表示されない](#xaml-notappearing)

    -   [ブラック ボックスが点滅し、表示されなくなる](#xaml-blackboxblinksdisappears)

    -   [広告が更新されない](#xaml-adsnotrefreshing)

-   [C#](#csharp)

    -   [AdControl が表示されない](#csharp-adcontrolnotappearing)

    -   [ブラック ボックスが点滅し、表示されなくなる](#csharp-blackboxblinksdisappears)

    -   [広告が更新されない](#csharp-adsnotrefreshing)

<span id="xaml"/>
## XAML

<span id="xaml-notappearing"/>
### AdControl が表示されない

1.  Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。

2.  アプリケーション ID と広告ユニット ID を確認します。 これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。 詳しくは、「[アプリで広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

    ``` syntax
    <UI:AdControl AdUnitId="{AdUnitID}" ApplicationId="{ApplicationID}"
                  Width="728" Height="90" />
    ```

3.  **Height** プロパティと **Width** プロパティを確認します。 これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。

    ``` syntax
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90" />
    ```

4.  要素の配置を確認します。 [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) は表示可能領域の内部にある必要があります。

5.  **Visibility** プロパティを確認します。 省略可能な **Visibility** プロパティは collapsed または hidden に設定しないでください。 (次のように) インラインで設定できるほか、外部スタイル シートで設定できます。

    ``` syntax
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Visibility="Visible"
                  Width="728" Height="90" />
    ```

6.  **IsEnabled** プロパティを確認します。 省略可能な `IsEnabled` プロパティを `True` に設定する必要があります。

    ``` syntax
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  IsEnabled="True"
                  Width="728" Height="90" />
    ```

7.  **AdControl** の親を確認します。 **AdControl** 要素がある親要素の中にある場合、この親はアクティブで表示されている必要があります。

    ``` syntax
    <StackPanel>
        <UI:AdControl AdUnitId="{AdUnitID}"
                      ApplicationId="{ApplicationID}"
                      Width="728" Height="90" />
    </StackPanel>
    ```

8.  **AdControl** がビューポートから隠れていないことを確認します。 **AdControl** は、広告が正常に表示されるように、見える必要があります。

9.  **ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。 **AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても、「[Test mode values (テスト モードの値)](test-mode-values.md)」にあるテスト ID を使ってください。

<span id="xaml-blackboxblinksdisappears"/>
### ブラック ボックスが点滅し、表示されなくなる

1.  前の「[AdControl が表示されない](#xaml-notappearing)」セクションの手順をすべてもう一度確認します。

2.  **ErrorOccurred** イベントを処理します。エラーが発生したかどうかと、発生したエラーの種類を特定するイベント ハンドラーに渡されるメッセージを使います。 詳しくは、「[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。

    次の例は、**ErrorOccurred**イベント ハンドラーを示しています。 最初のスニペットは、XAML UI マークアップです。

    ``` syntax
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  ErrorOccurred="adControl_ErrorOccurred" />

    <TextBlock x:Name="TextBlock1" TextWrapping="Wrap" Width="500" Height="250" />
    ```

    次の例は、対応するコードを示しています。

    ``` syntax
    private void adControl_ErrorOccurred(object sender,               
        Microsoft.Advertising.WinRT.UI.AdErrorEventArgs e)
    {
        TextBlock1.Text = e.Error.Message;
    }
    ```

    ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。 このエラーは、要求から復帰する利用可能な広告がないことを意味します。

3.  [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) は正常に動作しています。

    既定では、**AdControl** は広告を表示できない場合に折りたたまれます。 他の要素が同じ親の子である場合、これらの他の要素は折りたたんだ **AdControl** の隙間を埋めるように移動し、次の要求がなされたときに展開することがあります。

<span id="xaml-adsnotrefreshing"/>
### 広告が更新されない

1.  [IsAutoRefreshEnabled](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.isautorefreshenabled.aspx) プロパティを確認します。 既定では、この省略可能なプロパティは **True** に設定されています。 **False** に設定すると、他の広告を取得するために [Refresh](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.refresh.aspx) メソッドを使う必要があります。

    ``` syntax
    <UI:AdControl AdUnitId="{AdUnitID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  IsAutoRefreshEnabled="True" />
    ```

2.  **Refresh** メソッドの呼び出しを確認します。 自動更新の場合、他の広告を取得するために **Refresh** を使うことはできません。 手動更新の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。

    次のコード スニペットは、**Refresh** メソッドを使う方法の例を示しています。 最初のスニペットは、XAML UI マークアップです。

    ``` syntax
    <UI:AdControl x:Name="adControl1"
                  AdUnitId="{AdUnit_ID}"
                  ApplicationId="{ApplicationID}"
                  Width="728" Height="90"
                  IsAutoRefreshEnabled="False" />
    ```

    次のコード スニペットは、C# コード ビハインドの UI マークアップの例を示しています。

    ``` syntax
    public Ads()
    {
        var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(60) };
        timer.Tick += (s, e) => adControl1.Refresh();
        timer.Start();
    }
    ```

3.  **AdControl** は正常に動作しています。 同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。

<span id="csharp"/>
## C\# #

<span id="csharp-adcontrolnotappearing"/>
### AdControl が表示されない

1.  Package.appxmanifest で **[インターネット (クライアント)]** 機能が選択されていることを確認します。

2.  **AdControl** がインスタンス化されていることを確認します。 **AdControl** がインスタンス化されない場合、利用できません。

    ``` syntax
    using Microsoft.Advertising.WinRT.UI;

    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            AdControl adControl;

            public MainPage()
            {
                this.InitializeComponent();

                adControl = new AdControl()
                {
                    ApplicationId = "{ApplicationID}",
                    AdUnitId = "{AdUnitID}",
                    Height = 90,
                    Width = 728
                };
            }
        }
    }
    ```

3.  アプリケーション ID と広告ユニット ID を確認します。 これらの ID は、Windows デベロッパー センターで取得したアプリケーション ID と広告ユニット ID に一致している必要があります。 詳しくは、「[アプリで広告ユニットをセットアップする](set-up-ad-units-in-your-app.md)」をご覧ください。

    ``` syntax
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    ```

4.  **Height** と **Width** パラメーターを確認します。 これらのプロパティは、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに設定する必要があります。

    ``` syntax
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;adControl.Width = 728;
    ```

5.  **AdControl** が親要素に追加されることを確認します。 表示するには、**AdControl** を親コントロールの子として追加する必要があります (たとえば、**StackPanel** または **Grid**)。

    ``` syntax
    ContentPanel.Children.Add(adControl);
    ```

6.  **Margin** パラメーターを確認します。 **AdControl** は表示可能領域の内部にある必要があります。

7.  **Visibility** プロパティを確認します。 省略可能な **Visibility** プロパティを **Visible** に設定する必要があります。

    ``` syntax
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    adControl.Visibility = System.Windows.Visibility.Visible;
    ```

8.  **IsEnabled** プロパティを確認します。 省略可能な **IsEnabled** プロパティを **True** に設定する必要があります。

    ``` syntax
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    adControl.IsEnabled = True;
    ```

9.  **AdControl** の親を確認します。 親はアクティブな状態で表示されている必要があります。

10. **ApplicationId** と **AdUnitId** の実際の値は、エミュレーターでのテストに使わないようにしてください。 **AdControl** が想定どおりに機能していることを確認するには、**ApplicationId** と **AdUnitId** のどちらについても、「[Test mode values (テスト モードの値)](test-mode-values.md)」にあるテスト ID を使ってください。

<span id="csharp-blackboxblinksdisappears"/>
### ブラック ボックスが点滅し、表示されなくなる

1.  上記の「[AdControl が表示されない](#csharp-adcontrolnotappearing)」セクションの手順をすべてもう一度確認します。

2.  **ErrorOccurred** イベントを処理します。エラーが発生したかどうかと、発生したエラーの種類を特定するイベント ハンドラーに渡されるメッセージを使います。 詳しくは、「[XAML/C# ウォークスルーでのエラー処理](error-handling-in-xamlc-walkthrough.md)」をご覧ください。

    次の例は、エラー呼び出しの実装に必要な基本的なコードを示しています。 この XAML コードは、エラー メッセージの表示に使う **TextBlock** を定義します。

    ``` syntax
    <TextBlock x:Name="TextBlock1" TextWrapping="Wrap" Width="500" Height="250" />
    ```

    この C# コードは、エラー メッセージを取得し、**TextBlock** に表示します。

    ``` syntax
    using Microsoft.Advertising.WinRT.UI;

    namespace App1
    {
        public partial class MainPage : Page
        {
            AdControl adControl;

            public MainPage()
            {
                this.InitializeComponent();

                adControl = new AdControl();
                adControl.ApplicationId = "{ApplicationID}";
                adControl.AdUnitId = "{AdUnitID}";
                adControl.Height = 90;
                adControl.Width = 728;
                adControl.ErrorOccurred += (s,e) =>
                {
                    TextBlock1.Text = e.Error.Message;
                };
            }
        }
    }
    ```

    ブラック ボックスの原因となる最も一般的なエラーは、"No ad available" です。 このエラーは、要求から復帰する利用可能な広告がないことを意味します。

3.  **AdControl** は正常に動作しています。 同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。

<span id="csharp-adsnotrefreshing"/>
### 広告が更新されない

1.  **IsAutoRefreshEnabled** プロパティを確認します。 既定では、この省略可能なプロパティは **True** に設定されています。 **False** に設定すると、他の広告を取得するために **Refresh** メソッドを使う必要があります。

    次の例は、**IsAutoRefreshEnabled** プロパティの使い方を示しています。

    ``` syntax
    adControl = new AdControl();
    adControl.ApplicationId = "{ApplicationID}";
    adControl.AdUnitId = "{AdUnitID}";
    adControl.Height = 90;
    adControl.Width = 728;
    adControl.IsAutoRefreshEnabled = true;
    ```

2.  **Refresh** メソッドの呼び出しを確認します。 自動更新の場合、他の広告を取得するために **Refresh** を使うことはできません。 手動更新の場合、デバイスの現在のデータ接続に応じて、少なくとも 30 秒から 60 秒経ってから **Refresh** を呼び出します。

    次の例は、**Refresh** メソッドを呼び出す方法を示しています。

    ``` syntax
    public MainPage()
    {
        InitializeComponent();

        adControl = new AdControl();
        adControl.ApplicationId = "{ApplicationID}";
        adControl.AdUnitId = "{AdUnitID}";
        adControl.Height = 90;
        adControl.Width = 728;
        adControl.IsAutoRefreshEnabled = false;

        ContentPanel.Children.Add(adControl);

        var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(60) };
        timer.Tick += (s, e) => adControl.Refresh();
        timer.Start();
    }
    ```

3.  **AdControl** は正常に動作しています。 同じ広告が何度も連続して表示される場合があります。このとき広告は更新されていないように見えます。

 

 



<!--HONumber=Aug16_HO3-->


