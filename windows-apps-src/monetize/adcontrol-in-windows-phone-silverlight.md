---
author: mcleanbyron
ms.assetid: c0450f7b-5c81-4d8c-92ef-2b1190d18af7
description: "Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。"
title: "Windows Phone Silverlight の AdControl"
ms.author: mcleans
ms.date: 07/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、宣伝、AdControl、Silverlight、Windows Phone"
ms.openlocfilehash: f1582639757abfb6de156bf88ce8af71ba3eaacd
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="adcontrol-in-windows-phone-silverlight"></a>Windows Phone Silverlight の AdControl

このチュートリアルでは、Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/hh524191.aspx) クラスを使ってバナー広告を表示する方法について説明します。

<span id="silverlight_support"/>
## <a name="advertising-support-for-windows-phone-8x-silverlight-projects"></a>Windows Phone 8.x Silverlight プロジェクト用の広告のサポート

Windows Phone 8.x Silverlight プロジェクトでのいくつかの開発者シナリオは、サポートされません。 詳しくは、次の表をご覧ください。

|  プラットフォームのバージョン  |  既存のプロジェクト    |   新しいプロジェクト  |
|-----------------|----------------|--------------|
| Windows Phone 8.0 Silverlight     |  Microsoft ユニバーサル広告クライアント SDK または Microsoft Advertising SDK の以前のリリースの **AdControl** または **AdMediatorControl** を使用している既存の Windows Phone 8.0 Silverlight プロジェクトがあり、アプリが既に Windows ストアで公開されている場合、プロジェクトの変更とリビルドを行い、デバイスで変更のデバッグまたはテストを行うことができます。 エミュレーターでのプロジェクトのデバッグまたはテストはサポートされません。  |  サポートされません。  |
| Windows Phone 8.1 Silverlight    |  以前の SDK の **AdControl** または **AdMediatorControl** を使用している既存の Windows Phone 8.1 Silverlight プロジェクトがある場合、プロジェクトの変更とリビルドを行うことができます。 ただし、アプリをテストまたはデバッグするには、エミュレーターでアプリを実行し、アプリケーション ID と広告ユニット ID に[テスト モードの値](test-mode-values.md)を使用する必要があります。 デバイス上でのアプリのデバッグやテストはサポートされません。  |   新しい Windows Phone 8.1 Silverlight プロジェクトに **AdControl** または **AdMediatorControl** を追加することができます。 ただし、アプリをテストまたはデバッグするには、エミュレーターでアプリを実行し、アプリケーション ID と広告ユニット ID に[テスト モードの値](test-mode-values.md)を使用する必要があります。 デバイス上でのアプリのデバッグやテストはサポートされません。 |

## <a name="add-the-advertising-assemblies-to-your-project"></a>Advertising アセンブリをプロジェクトに追加する

まず、Windows Phone Silverlight 用の Microsoft Advertising アセンブリを含む NuGet パッケージをプロジェクトにダウンロードしてインストールします。

1.  Visual Studio でプロジェクトを開きます。

2.  **[ツール]** をクリックし、**[NuGet パッケージ マネージャー]** をポイントして **[パッケージ マネージャー コンソール]** をクリックします。

3.  **パッケージ マネージャー コンソール** ウィンドウで、以下のいずれかのコマンドを入力します。

  * プロジェクトが Windows Phone 8.0 をターゲットとする場合は、以下のコマンドを入力します。

      ```syntax
      Install-Package Microsoft.Advertising.WindowsPhone.SL80 -Version 6.2.40501.1
      ```

  * プロジェクトが Windows Phone 8.1 をターゲットとする場合は、以下のコマンドを入力します。

      ```syntax
      Install-Package Microsoft.Advertising.WindowsPhone.SL81 -Version 8.1.50112
      ```

    コマンドを入力すると、必要なすべての Silverlight 用 Microsoft Advertising アセンブリが NuGet パッケージとしてローカルのプロジェクトにダウンロードされ、それらのアセンブリへの参照が自動的にプロジェクトに追加されます。

## <a name="code-your-app"></a>アプリのコードを記述する


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

  ``` xml
  xmlns:UI="clr-namespace:Microsoft.Advertising.Mobile.UI;assembly=Microsoft.Advertising.Mobile.UI"
  ```

  ページのヘッダーのコードが次のようになります。

  ``` xml
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
  xmlns:UI="clr-namespace:Microsoft.Advertising.Mobile.UI;assembly=Microsoft.Advertising.Mobile.UI"
  x:Class="PhoneApp1.MainPage"
  ```

6.  **Grid** タグに、以下に示す **AdControl** のコードを追加します。 **ApplicationId** プロパティと **AdUnitId** プロパティに、「[Test mode values (テスト モードの値)](test-mode-values.md)」に示されているテスト値を割り当てて、**Height** プロパティと **Width** プロパティを、[バナー広告でサポートされている広告サイズ](supported-ad-sizes-for-banner-ads.md)のいずれかに合わせて調整します。

  >               **注**&nbsp;&nbsp;**ApplicationId** と **AdUnitId** のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。

  ``` xml
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

## <a name="release-your-app-with-live-ads-using-dev-center"></a>デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする

1.  デベロッパー センターのダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページに移動し、[スタンドアロン広告ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

3.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。


 
