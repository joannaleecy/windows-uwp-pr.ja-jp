---
author: mcleanbyron
ms.assetid: 9621641A-7462-425D-84CC-101877A738DA
description: "UWP アプリで AdMediatorControl を AdControl に移行する方法について説明します。"
title: "UWP アプリ用 AdMediatorControl から AdControl への移行"
translationtype: Human Translation
ms.sourcegitcommit: 07baa54990ec31dc0cb9c289f9f0222754da9d7c
ms.openlocfilehash: 3abef943530cc756de117edccc5ab16e5f178604

---

# UWP アプリ用 AdMediatorControl から AdControl への移行

以前の Microsoft の広告 SDK リリースでは、**AdMediatorControl** クラスを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリにバナー広告を表示させることができました。開発者はこのクラスを使用して Microsoft のパートナー ネットワーク (AOL や AppNexus) および AdDuplex からバナーを表示することで、広告の収益を最適化することができました。 [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) では、**AdMediatorControl** クラスはサポートされません。 以前の SDK の **AdMediatorControl** クラスを使う既存のアプリがあり、そのアプリを [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) を使用する UWP アプリに移行しようと考えている場合は、この記事の指示に従って、**AdMediatorControl** クラスの代わりに **AdControl** クラスを使用するように、コードを更新してください。 必要に応じて、加重または順位付けしたアプローチを使って、AdDuplex によって広告を仲介するようにアプリを構成できます。

>**注**&nbsp;&nbsp;この記事のコード例は説明のみを目的としています。 アプリ内で動作させるには、コード例を調整することが必要になる場合があります。

## 前提条件

* 現在 AdMediatorControl を使用し、Windows ストアで公開されている UWP アプリ。
* Visual Studio 2015 と [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストール済みの開発用コンピューター。
* AdDuplex で広告を仲介する場合は、[AdDuplex Windows 10 SDK](https://visualstudiogallery.msdn.microsoft.com/6930860a-e64b-4b46-9d72-62d7fddda077) も開発用コンピューターにインストールする必要があります。

  >**注**&nbsp;&nbsp;上記のリンクから AdDuplex SDK のインストーラーを実行する代わりに、Visual Studio 2015 で UWP アプリ プロジェクト用に AdDuplex ライブラリをインストールできます。 Visual Studio 2015 で UWP アプリ プロジェクトを開き、**[プロジェクト]**、**[NuGet パッケージの管理]** の順にクリックし、**AdDuplexWin10** という名前の NuGet パッケージを検索してインストールします。

## 手順 1: アプリケーション ID と広告ユニット ID を取得する

**AdControl** クラスを使用するようにコードを移行するとき、アプリケーション ID と広告ユニット ID を把握しておく必要があります。 最新の ID を取得するための最善の方法は、メディエーション構成ファイルから ID を取得することです。

1. Windows デベロッパー センターのダッシュボードにサインインし、現在 **AdMediatorControl** を使っているアプリをクリックします。
2. **[収益化]** をクリックし、**[広告で収入を増やす]** をクリックします。
3. **[Windows 広告仲介]** セクションで、**[メディエーション構成のダウンロード]** リンクをクリックして、メモ帳などのテキスト エディターで AdMediator.config ファイルを開きます。
4. ファイルで、```<Name>MicrosoftAdvertising</Name>``` 子要素を持つ ```<AdAdapterInfo>``` 要素を見つけます。 このセクションには、Microsoft の有料広告用の構成が含まれています。
5. この ```<AdAdapterInfo>``` 要素で、**WApplicationId** 値および **WAdUnitId** 値を持つ ```<Key>``` 要素を含む ```<Property>``` 要素を見つけます。 次の例では、```<Value>``` 要素の値の例を示します。

  ```xml
  <Metadata>
      <Property>
          <Key>WApplicationId</Key>
          <Value>364d4938-c0f5-4c3d-8aae-090206211dc9</Value>
      </Property>
      <Property>
          <Key>WAdUnitId</Key>
          <Value>301568</Value>
      </Property>
  </Metadata>
  ```
6. 後で使用するため、これらの ```<Value>``` 要素の値を両方ともコピーします。 これらの値には、Microsoft 有料広告用のモバイル以外の広告ユニットのアプリケーション ID と広告ユニット ID が含まれます。
5. 同じ ```<AdAdapterInfo>``` 要素で、**MApplicationId** 値および **MAdUnitId** 値を持つ ```<Key>``` 要素を含む ```<Property>``` 要素を見つけます。 次の例では、```<Value>``` 要素の値の例を示します。

  ```xml
  <Metadata>
      <Property>
          <Key>MApplicationId</Key>
          <Value>e2cf8388-7018-4a11-8ab0de90f2a7a401</Value>
      </Property>
      <Property>
          <Key>MAdUnitId</Key>
          <Value>301056</Value>
      </Property>
  </Metadata>
  ```
6. 後で使用するため、```<Value>``` 要素の値を両方ともコピーします。 これらの値には、Microsoft 有料広告用のモバイル広告ユニットのアプリケーション ID と広告ユニット ID が含まれます。
7. [自社広告](../publish/about-house-ads.md)を使う場合は、```<Name>MicrosoftAdvertisingHouse</Name>``` 子要素を持つ ```<AdAdapterInfo>``` 要素を見つけます。 この要素で、**MAdUnitId** 値および **WAdUnitId** 値を持つ ```<Key>``` 要素を見つけ、後で使用するため、対応する ```<Value>``` 要素の値を保存します。 これらは、それぞれ Microsoft の自社広告用のモバイル広告ユニット ID とモバイル以外の広告ユニット ID です。
8. AdDuplex を使用する場合は、```<Name>AdDuplex</Name>``` 子要素を持つ ```<AdAdapterInfo>``` 要素を見つけます。 この要素で、**AppKey** 値および **AdUnitId** 値を持つ ```<Key>``` 要素を見つけ、後で使用するため、対応する ```<Value>``` 要素の値を保存します。 これは、それぞれ AdDuplex アプリのキーと広告ユニット ID です。

## 手順 2: アプリのコードを更新する

アプリケーション ID と広告ユニット ID を用意できたため、**AdMediatorControl** の代わりに **AdControl** を使うようにアプリのコードを更新する準備ができました。

### Microsoft の有料広告のみ

広告メディエーション構成で Microsoft の有料広告のみを使用する場合は、次の手順に従います。

  >**注**&nbsp;&nbsp;次の手順では、広告を表示するアプリのページに **myAdGrid** という名前の空のグリッド (```<Grid x:Name="myAdGrid"/>``` など) が含まれていることを前提としています。 次の手順では、広告コントロールをすべて、XAML 内ではなくコード内で作成して構成します。

1. Visual Studio で、UWP アプリ プロジェクトを開きます。
2.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。
**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。
3. **[参照マネージャー]** で、[OK] をクリックします。
4. XAML から **AdMediatorControl** 宣言を削除し、この **AdMediatorControl** オブジェクトを使用するコードを、関連するイベント ハンドラーを含めすべて削除します。
5. 広告を表示するアプリの **Page** のコード ファイルを開きます。
6. まだ存在しない場合は、コード ファイルの先頭に次のステートメントを追加します。

  ```csharp
  using Microsoft.Advertising.WinRT.UI;
  using Windows.System.Profile;
  ```
7. **Page** クラスに次の定数宣言を追加します。

  ```csharp
  private const int AD_WIDTH = <tbd>;
  private const int AD_HEIGHT = <tbd>;
  private const string WAPPLICATIONID = "<tbd>";
  private const string WADUNITID = "<tbd>";
  private const string MAPPLICATIONID = "<tbd>";
  private const string MADUNITID = "<tbd>";
  ```
7. これらの定数宣言の ```<tbd>``` の値をそれぞれ置き換えます。
  * **AD_WIDTH** と **AD_HEIGHT**: これらを、[バナー広告でサポートされる広告サイズ]( https://msdn.microsoft.com/windows/uwp/monetize/supported-ad-sizes-for-banner-ads)のいずれかに割り当てます。
  * **WAPPLICATIONID** と **WADUNITID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **WApplicationId** 値と **WAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイル以外の広告ユニットで使います)。
  * **MAPPLICATIONID** と **MADUNITID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **MApplicationId** 値と **MAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイルの広告ユニットで使います)。

8. **Page** クラスに次の変数宣言を追加します。

  ```csharp
  // Declare an AdControl.
  private AdControl myAdControl = null;

  // Application ID and ad unit ID values for Microsoft advertising. By default,
  // assign these to non-mobile ad unit info.
  private string myAppId = WAPPLICATIONID;
  private string myAdUnitId = WADUNITID;
  ```
5. **InitializeComponent()** メソッドの呼び出しの後に、**Page** クラスのコンストラクターに次のコードを追加します。

  ```csharp
  myAdGrid.Width = AD_WIDTH;
  myAdGrid.Height = AD_HEIGHT;

  // For mobile device families, use the mobile ad unit info.
  if ("Windows.Mobile" == AnalyticsInfo.VersionInfo.DeviceFamily)
  {
      myAppId = MAPPLICATIONID;
      myAdUnitId = MADUNITID;
  }

  // Initialize the AdControl.
  myAdControl = new AdControl();
  myAdControl.ApplicationId = myAppId;
  myAdControl.AdUnitId = myAdUnitId;
  myAdControl.Width = AD_WIDTH;
  myAdControl.Height = AD_HEIGHT;
  myAdControl.IsAutoRefreshEnabled = true;

  myAdGrid.Children.Add(myAdControl);
  ```  

### Microsoft の有料広告、自社広告、AdDuplex

Microsoft の自社広告または AdDuplex に加えて Microsoft の有料広告を使用し、引き続き AdDuplex によって広告を仲介する場合は、このセクションの次の手順に従います。 コード例は、AdDuplex とマイクロソフトの自社広告の両方をサポートします。 AdDuplex を使っても Microsoft の自社広告は使わない (またはその逆) 場合は、シナリオに適していないコードを削除します。

  >**注**&nbsp;&nbsp;次の手順では、広告を表示するアプリのページに **myAdGrid** という名前の空のグリッド (```<Grid x:Name="myAdGrid"/>``` など) が含まれていることを前提としています。 次の手順では、広告コントロールをすべて、XAML 内ではなくコード内で作成して構成します。

1. Visual Studio で、UWP アプリ プロジェクトを開きます。
2.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。
**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。
3. **[参照マネージャー]** で、[OK] をクリックします。
4. XAML から **AdMediatorControl** 宣言を削除し、この **AdMediatorControl** オブジェクトを使用するコードを、関連するイベント ハンドラーを含めすべて削除します。
5. 広告を表示するアプリの **Page** のコード ファイルを開きます。
6. まだ存在しない場合は、コード ファイルの先頭に次のステートメントを追加します。

  ```csharp
  using Windows.System.UserProfile;
  using Microsoft.Advertising.WinRT.UI;
  using Windows.System.Profile;
  ```
7. **Page** クラスに次の定数宣言を追加します。

  ```csharp
  private const int AD_WIDTH = <tbd>;
  private const int AD_HEIGHT = <tbd>;
  private const int HOUSE_AD_WEIGHT = <tbd>;
  private const int AD_REFRESH_SECONDS = 35;
  private const int MAX_ERRORS_PER_REFRESH = 3;
  private const string WAPPLICATIONID = "<tbd>";
  private const string WADUNITID_PAID = "<tbd>";
  private const string WADUNITID_HOUSE = "<tbd>";
  private const string MAPPLICATIONID = "<tbd>";
  private const string MADUNITID_PAID = "<tbd>";
  private const string MADUNITID_HOUSE = "<tbd>";
  private const string ADDUPLEX_APPKEY = "<tbd>";
  private const string ADDUPLEX_ADUNIT = "<tbd>";
  ```
4. ```<tbd>``` に割り当てられている定数宣言に対して、```<tbd>``` をシナリオの実際の値でそれぞれ置き換えます。
  * **AD_WIDTH** と **AD_HEIGHT**: これらを、[バナー広告でサポートされる広告サイズ]( https://msdn.microsoft.com/windows/uwp/monetize/supported-ad-sizes-for-banner-ads)のいずれかに割り当てます。
  * **HOUSE_AD_WEIGHT**: これを、Microsoft の有料広告と比較した Microsoft の自社広告に適用する加重値を指定する 0 ～ 100 の整数に割り当てます (0 の場合は自社広告がまったく表示されず、100 の場合は常に自社広告が表示されます)。
  * **WAPPLICATIONID** と **WADUNITID_PAID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **WApplicationId** 値と **WAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイル以外の広告ユニットで使います)。
  * **WADUNITID_HOUSE**: これを、前にメディエーション構成ファイルから取得した Microsoft の自社広告の **WAdUnitId** 値に割り当てます (この値は、自社広告用のモバイル以外の広告ユニットで使います)。
  * **MAPPLICATIONID** と **MADUNITID_PAID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **MApplicationId** 値と **MAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイルの広告ユニットで使います)。
  * **MADUNITID_HOUSE**: これを、前にメディエーション構成ファイルから取得した Microsoft の自社広告の **MAdUnitId** 値に割り当てます (この値は、自社広告用のモバイルの広告ユニットで使います)。
  * **ADDUPLEX_APPKEY** と **ADDUPLEX_ADUNIT**: これらを、前にメディエーション構成ファイルから取得した AdDuplex アプリ キー値と広告ユニット ID 値に割り当てます。
5. **Page** クラスに次の変数宣言を追加します。
  ```csharp
  // Dispatch timer to fire at each ad refresh interval.
  private DispatcherTimer myAdRefreshTimer = new DispatcherTimer();

  // Global variables used for mediation decisions.
  private Random randomGenerator = new Random();
  private int errorCountCurrentRefresh = 0;  // Prevents infinite redirects.
  private int adDuplexWeight = 0;            // Will be set by GetAdDuplexWeight().

  // Microsoft and AdDuplex controls for banner ads.
  private AdControl myMicrosoftBanner = null;
  private AdDuplex.AdControl myAdDuplexBanner = null;

  // Application ID and ad unit ID values for Microsoft advertising. By default,
  // assign these to non-mobile ad unit info.
  private string myMicrosoftAppId = WAPPLICATIONID;
  private string myMicrosoftPaidUnitId = WADUNITID_PAID;
  private string myMicrosoftHouseUnitId = WADUNITID_HOUSE;
  ```
5. **InitializeComponent()** メソッドの呼び出しの後に、**Page** クラスのコンストラクターに次のコードを追加します。
  ```csharp
  myAdGrid.Width = AD_WIDTH;
  myAdGrid.Height = AD_HEIGHT;
  adDuplexWeight = GetAdDuplexWeight();
  RefreshBanner();

  // Start the timer to refresh the banner at the desired interval.
  myAdRefreshTimer.Interval = new TimeSpan(0, 0, AD_REFRESH_SECONDS);
  myAdRefreshTimer.Tick += myAdRefreshTimer_Tick;
  myAdRefreshTimer.Start();

  // For mobile device families, use the mobile ad unit info.
  if ("Windows.Mobile" == AnalyticsInfo.VersionInfo.DeviceFamily)
  {
      myMicrosoftAppId = MAPPLICATIONID;
      myMicrosoftPaidUnitId = MADUNITID_PAID;
      myMicrosoftHouseUnitId = MADUNITID_HOUSE;
  }
  ```
6. 最後に、**Page** クラスに次のメソッドを追加します。 これらのメソッドは Microsoft の **AdControl** オブジェクトと AdDuplex の **AdControl** オブジェクトをインスタンス化し、乱数ジェネレーターを与えられた加重値と共に使って、これらのコントロールのバナー広告を一定の時間間隔で更新します。
  ```csharp
  private int GetAdDuplexWeight()
  {
      // TODO: Change this logic to fit your needs.
      // This example uses Microsoft ads first in Canada and Mexico, then
      // AdDuplex as fallback. In France, AdDuplex is first. In other regions,
      // this example uses a weighted average approach, with 50% to AdDuplex.

      int returnValue = 0;
      switch (GlobalizationPreferences.HomeGeographicRegion)
      {
          case "CA":
          case "MX":
              returnValue = 0;
              break;
          case "FR":
              returnValue = 100;
              break;
          default:
              returnValue = 50;
              break;
      }
      return returnValue;
  }

  private void ActivateMicrosoftBanner()
  {
      // Return if you hit the error limit for this refresh interval.
      if (errorCountCurrentRefresh >= MAX_ERRORS_PER_REFRESH)
      {
          myAdGrid.Visibility = Visibility.Collapsed;
          return;
      }

      // Use random number generator and house ads weight to determine whether
      // to use paid ads or house ads. Paid is the default. You could alternatively
      // write a method similar to GetAdDuplexWeight and override by region.
      string myAdUnit = myMicrosoftPaidUnitId;
      int houseWeight = HOUSE_AD_WEIGHT;
      int randomInt = randomGenerator.Next(0, 100);
      if (randomInt < houseWeight)
      {
          myAdUnit = myMicrosoftHouseUnitId;
      }

      // Hide the AdDuplex control if it is showing.
      if (null != myAdDuplexBanner)
      {
          myAdDuplexBanner.Visibility = Visibility.Collapsed;
      }

      // Initialize or display the Microsoft control.
      if (null == myMicrosoftBanner)
      {
          myMicrosoftBanner = new AdControl();
          myMicrosoftBanner.ApplicationId = myMicrosoftAppId;
          myMicrosoftBanner.AdUnitId = myAdUnit;
          myMicrosoftBanner.Width = AD_WIDTH;
          myMicrosoftBanner.Height = AD_HEIGHT;
          myMicrosoftBanner.IsAutoRefreshEnabled = false;

          myMicrosoftBanner.AdRefreshed += myMicrosoftBanner_AdRefreshed;
          myMicrosoftBanner.ErrorOccurred += myMicrosoftBanner_ErrorOccurred;

          myAdGrid.Children.Add(myMicrosoftBanner);
      }
      else
      {
          myMicrosoftBanner.AdUnitId = myAdUnit;
          myMicrosoftBanner.Visibility = Visibility.Visible;
          myMicrosoftBanner.Refresh();
      }
  }

  private void ActivateAdDuplexBanner()
  {
      // Return if you hit the error limit for this refresh interval.
      if (errorCountCurrentRefresh >= MAX_ERRORS_PER_REFRESH)
      {
          myAdGrid.Visibility = Visibility.Collapsed;
          return;
      }

      // Hide the Microsoft control if it is showing.
      if (null != myMicrosoftBanner)
      {
          myMicrosoftBanner.Visibility = Visibility.Collapsed;
      }

      // Initialize or display the AdDuplex control.
      if (null == myAdDuplexBanner)
      {
          myAdDuplexBanner = new AdDuplex.AdControl();
          myAdDuplexBanner.AppKey = ADDUPLEX_APPKEY;
          myAdDuplexBanner.AdUnitId = ADDUPLEX_ADUNIT;
          myAdDuplexBanner.Width = AD_WIDTH;
          myAdDuplexBanner.Height = AD_HEIGHT;
          myAdDuplexBanner.RefreshInterval = AD_REFRESH_SECONDS;

          myAdDuplexBanner.AdLoaded += myAdDuplexBanner_AdLoaded;
          myAdDuplexBanner.AdCovered += myAdDuplexBanner_AdCovered;
          myAdDuplexBanner.AdLoadingError += myAdDuplexBanner_AdLoadingError;
          myAdDuplexBanner.NoAd += myAdDuplexBanner_NoAd;

          myAdGrid.Children.Add(myAdDuplexBanner);
      }
      myAdDuplexBanner.Visibility = Visibility.Visible;
  }

  private void myAdRefreshTimer_Tick(object sender, object e)
  {
      RefreshBanner();
  }

  private void RefreshBanner()
  {
      // Reset the error counter for this refresh interval and
      // make sure the ad grid is visible.
      errorCountCurrentRefresh = 0;
      myAdGrid.Visibility = Visibility.Visible;

      // Display ad from AdDuplex.
      if (100 == adDuplexWeight)
      {
          ActivateAdDuplexBanner();
      }
      // Display Microsoft ad.
      else if (0 == adDuplexWeight)
      {
          ActivateMicrosoftBanner();
      }
      // Use weighted approach.
      else
      {
          int randomInt = randomGenerator.Next(0, 100);
          if (randomInt < adDuplexWeight) ActivateAdDuplexBanner();
          else ActivateMicrosoftBanner();
      }
  }

  private void myMicrosoftBanner_AdRefreshed(object sender, RoutedEventArgs e)
  {
      // Add your code here as necessary.
  }

  private void myMicrosoftBanner_ErrorOccurred(object sender, AdErrorEventArgs e)
  {
      errorCountCurrentRefresh++;
      ActivateAdDuplexBanner();
  }

  private void myAdDuplexBanner_AdLoaded(object sender, AdDuplex.Banners.Models.BannerAdLoadedEventArgs e)
  {
      // Add your code here as necessary.
  }

  private void myAdDuplexBanner_NoAd(object sender, AdDuplex.Common.Models.NoAdEventArgs e)
  {
      errorCountCurrentRefresh++;
      ActivateMicrosoftBanner();
  }

  private void myAdDuplexBanner_AdLoadingError(object sender, AdDuplex.Common.Models.AdLoadingErrorEventArgs e)
  {
      errorCountCurrentRefresh++;
      ActivateMicrosoftBanner();
  }

  private void myAdDuplexBanner_AdCovered(object sender,   AdDuplex.Banners.Core.AdCoveredEventArgs e)
  {
      errorCountCurrentRefresh++;
      ActivateMicrosoftBanner();
  }
  ```



<!--HONumber=Sep16_HO1-->


