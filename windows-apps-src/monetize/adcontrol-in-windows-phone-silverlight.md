---
author: mcleanbyron
ms.assetid: c0450f7b-5c81-4d8c-92ef-2b1190d18af7
description: "Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "Windows Phone Silverlight の AdControl"
translationtype: Human Translation
ms.sourcegitcommit: 3a09b37a5cae0acaaf97a543cae66e4de3eb3f60
ms.openlocfilehash: 40e68625ed666a9242ed83729b2f8113da363735


---

# Windows Phone Silverlight の AdControl




このチュートリアルでは、Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/hh524191.aspx) クラスを使ってバナー広告を表示する方法について説明します。

> **Windows Phone Silverlight 8.0 に関する注**&nbsp;&nbsp;以前のリリースの Universal Ad Client SDK または Microsoft Advertising SDK の **AdControl** を使用し、すでにストアで提供されている既存の Windows Phone 8.0 Silverlight アプリでは、バナー広告が引き続きサポートされます。 ただし、新しい Windows Phone 8.0 Silverlight プロジェクトではバナー広告がサポートされません。 さらに、Windows Phone 8.x Silverlight プロジェクトでは、一部のデバッグとテストのシナリオが制限されます。 詳しくは、「[アプリでの広告の表示](display-ads-in-your-app.md#silverlight_support)」をご覧ください。


## Advertising アセンブリをプロジェクトに追加する

まず、Windows Phone Silverlight 用の Microsoft Advertising アセンブリを含む NuGet パッケージをプロジェクトにダウンロードしてインストールします。

1.  Visual Studio でプロジェクトを開きます。

2.  **[ツール]** をクリックし、**[NuGet パッケージ マネージャー]** をポイントして **[パッケージ マネージャー コンソール]** をクリックします。

3.  **パッケージ マネージャー コンソール** ウィンドウで、以下のいずれかのコマンドを入力します。

  * プロジェクトが Windows Phone 8.0 をターゲットとする場合は、以下のコマンドを入力します。

      ```
      Install-Package Microsoft.Advertising.WindowsPhone.SL80 -Version 6.2.40501.1
      ```

  * プロジェクトが Windows Phone 8.1 をターゲットとする場合は、以下のコマンドを入力します。

      ```
      Install-Package Microsoft.Advertising.WindowsPhone.SL81 -Version 8.1.50112
      ```

    コマンドを入力すると、必要なすべての Silverlight 用 Microsoft Advertising アセンブリが NuGet パッケージとしてローカルのプロジェクトにダウンロードされ、それらのアセンブリへの参照が自動的にプロジェクトに追加されます。

## アプリのコードを記述する


1.  WMAppManifest.xml ファイルの **Capabilities** ノードに次の機能を追加します。

    ``` syntax
    <Capability Name="ID_CAP_IDENTITY_USER"/>
    <Capability Name="ID_CAP_MEDIALIB_PHOTO"/>
    <Capability Name="ID_CAP_PHONEDIALER"/>
    ```

    この例では、**Capabilities** ノードが次のようになります。

    ``` syntax
        <Capabilities>
          <Capability Name="ID_CAP_NETWORKING"/>
          <Capability Name="ID_CAP_MEDIALIB_AUDIO"/>
          <Capability Name="ID_CAP_MEDIALIB_PLAYBACK"/>
          <Capability Name="ID_CAP_SENSORS"/>
          <Capability Name="ID_CAP_WEBBROWSERCOMPONENT"/>
          <Capability Name="ID_CAP_IDENTITY_USER"/>
          <Capability Name="ID_CAP_MEDIALIB_PHOTO"/>
          <Capability Name="ID_CAP_PHONEDIALER"/>
        </Capabilities>
    ```

2.  (省略可能) プロジェクトを保存します。 **[すべてを保存]** アイコンをクリックするか、**[ファイル]** メニューの **[すべてを保存]** をクリックします。

3.  プロジェクトの Package.appxmanifest ファイルに **[インターネット (クライアントとサーバー)]** 機能を追加します。 **ソリューション エクスプローラー**で、**[Package.appxmanifest]** をダブルクリックします。

    ![wp81silverlightmarkup\-solutionexplorer\-packageappxmanifest](images/13-b98c2a1a-69c3-4018-be0a-6ce010e703e7.jpg)

    **エディター**で、**[機能]** タブをクリックします。 **[インターネット (クライアントとサーバー)]** チェック ボックスをオンにします。

4.  (省略可能) プロジェクトを保存します。 **[すべてを保存]** アイコンをクリックするか、**[ファイル]** メニューの **[すべてを保存]** をクリックします。

5.  MainPage.xaml ファイルの Silverlight マークアップを変更して、**Microsoft.Advertising.Mobile.UI** 名前空間を追加します。

    ``` syntax
    xmlns:UI="clr-namespace:Microsoft.Advertising.Mobile.UI;assembly=Microsoft.Advertising.Mobile.UI"
    ```

    ページのヘッダーのコードが次のようになります。

    ``` syntax
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:UI="clr-namespace:Microsoft.Advertising.Mobile.UI;assembly=Microsoft.Advertising.Mobile.UI"
        x:Class="PhoneApp1.MainPage"
    ```

6.  **Grid** タグに、以下に示す **AdControl** のコードを追加します。 **ApplicationId** プロパティと **AdUnitId** プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てて、**Height** プロパティと **Width** プロパティを、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。

    >               **注**&nbsp;&nbsp;**ApplicationId** と **AdUnitId** のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。

    ``` syntax
    <Grid x:Name="ContentPanel" Grid.Row="1">

      <UI:AdControl
             ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
             AdUnitId="10865270"
             HorizontalAlignment="Left"
             Height="80"
             VerticalAlignment="Top"
             Width="480"/>

    </Grid>
    ```

7.  プロジェクトをビルドして実行します。 アプリに次のような広告が表示されることを確認します。

    ![wp81silverlight\-emulatorwithad](images/13-8db1492f-ae1d-439b-9b78-bed8e22fe996.jpg)

## デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする


1.  デベロッパー センターのダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページに移動し、[スタンドアロン Microsoft Advertising ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

3.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。


 



<!--HONumber=Sep16_HO2-->


