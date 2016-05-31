---
author: mcleanbyron
ms.assetid: c0450f7b-5c81-4d8c-92ef-2b1190d18af7
description: Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで AdControl クラスを使ってバナー広告を表示する方法について説明します。
title: Windows Phone Silverlight の AdControl

---

# Windows Phone Silverlight の AdControl


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

このチュートリアルでは、Windows Phone 8.1 用または Windows Phone 8.0 用の Silverlight アプリで [AdControl](https://msdn.microsoft.com/library/windows/apps/hh524191.aspx) クラスを使ってバナー広告を表示する方法について説明します。

## 前提条件

*  [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) を Visual Studio 2015 または Visual Studio 2013 と共にインストールします。


## Advertising アセンブリの参照を追加する

Windows Phone Silverlight プロジェクト用の Microsoft Advertising アセンブリは、Microsoft Store Engagement and Monetization SDK と共にローカルにインストールされません。 コードの更新を始める前に、まず、**接続済みサービス**と Microsoft Store Engagement and Monetization SDK の広告仲介サポートを使って、これらのアセンブリをダウンロードしてプロジェクトで参照する必要があります。

1.  Visual Studio で、**[プロジェクト]**、**[接続済みサービスの追加]** の順にクリックします。

2.  **[接続済みサービスの追加]** ダイアログ ボックスで、**[広告メディエーター]** をクリックし、**[構成]** をクリックします。

3.  **[広告ネットワークの選択]** をクリックし、**[Microsoft Advertising]** のみを選択します。

    この時点で、必要なすべての Silverlight 用 Microsoft Advertising アセンブリが NuGet パッケージとしてローカルのプロジェクトにダウンロードされ、それらのアセンブリへの参照が自動的にプロジェクトに追加されます。 広告仲介アセンブリへの参照もプロジェクトに追加されますが、 このシナリオには必要ないため、後の手順で削除します。

4.  **[広告ネットワークの選択]** ダイアログ ボックスで、**[OK]** をクリックします。 次の **[フェッチの状態]** 確認ページでもう一度 **[OK]** をクリックし、最後に **[追加]** をクリックして **[広告メディエーター]** ダイアログ ボックスを閉じます。

5.  **ソリューション エクスプローラー**で、**[参照設定]** ノードを展開します。 **[Microsoft.AdMediator.WindowsPhone81SL.MicrosoftAdvertising]** を右クリックし、**[削除]** をクリックします。 このアセンブリ参照は、このシナリオには必要ありません。

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

    > **注**  
    **ApplicationId** と **AdUnitId** のテスト値は、アプリを申請のために提出する前に実際の値に置き換えます。

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


1.  デベロッパー センターのダッシュボードで、アプリの **[貨幣化]**&gt;**[広告で収入を増やす]** ページに移動し、[スタンドアロン Microsoft Advertising ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[バナー]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、広告ユニットのテスト値 (**applicationId** と **adUnitId**) を、デベロッパー センターで生成した実際の値に置き換えます。

3.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを提出](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。


 


<!--HONumber=May16_HO2-->


