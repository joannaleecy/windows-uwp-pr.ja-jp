---
author: mcleanbyron
ms.assetid: 9621641A-7462-425D-84CC-101877A738DA
description: "UWP アプリで AdMediatorControl を AdControl に移行する方法について説明します。"
title: "AdMediatorControl から AdControl への移行"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, AdMediatorControl, AdControl, 移行"
ms.openlocfilehash: 71928b67d3c2799b3d8d3711f6f7e5a3610e9c76
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="migrate-from-admediatorcontrol-to-adcontrol"></a>AdMediatorControl から AdControl への移行

以前の Microsoft Advertising SDK のリリースでは、**AdMediatorControl** クラスを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリにバナー広告を表示させることができました。開発者はこのクラスを使用して Microsoft のパートナー ネットワーク (AOL や AppNexus) および AdDuplex からバナーを表示することで、広告の収益を最適化することができました。 [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) では、**AdMediatorControl** クラスはサポートされません。 以前の SDK の **AdMediatorControl** クラスを使う既存のアプリがあり、そのアプリを [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) を使用する UWP アプリに移行しようと考えている場合は、この記事の指示に従って、**AdMediatorControl** クラスの代わりに **AdControl** クラスを使用するように、コードを更新してください。 必要に応じて、加重または順位付けしたアプローチを使って、AdDuplex によって広告を仲介するようにアプリを構成できます。

>**注**&nbsp;&nbsp;この記事のコード例は説明のみを目的としています。 アプリ内で動作させるには、コード例を調整することが必要になる場合があります。

## <a name="prerequisites"></a>前提条件

* 現在 AdMediatorControl を使用し、Windows ストアで公開されている UWP アプリ。
* Visual Studio 2015 と [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストール済みの開発用コンピューター。
* AdDuplex で広告を仲介する場合は、[AdDuplex Windows 10 SDK](https://visualstudiogallery.msdn.microsoft.com/6930860a-e64b-4b46-9d72-62d7fddda077) も開発用コンピューターにインストールする必要があります。

  >**注**&nbsp;&nbsp;上記のリンクから AdDuplex SDK のインストーラーを実行する代わりに、Visual Studio 2015 で UWP アプリ プロジェクト用に AdDuplex ライブラリをインストールできます。 Visual Studio 2015 で UWP アプリ プロジェクトを開き、**[プロジェクト]**、**[NuGet パッケージの管理]** の順にクリックし、**AdDuplexWin10** という名前の NuGet パッケージを検索してインストールします。

## <a name="step-1-retrieve-your-application-ids-and-ad-unit-ids"></a>手順 1: アプリケーション ID と広告ユニット ID を取得する

**AdControl** クラスを使用するようにコードを移行するとき、アプリケーション ID と広告ユニット ID を把握しておく必要があります。 最新の ID を取得するための最善の方法は、メディエーション構成ファイルから ID を取得することです。

1. Windows デベロッパー センターのダッシュボードにサインインし、現在 **AdMediatorControl** を使っているアプリをクリックします。
2. **[収益化]** をクリックし、**[広告で収入を増やす]** をクリックします。
3. **[Windows 広告仲介]** セクションで、**[メディエーション構成のダウンロード]** リンクをクリックして、メモ帳などのテキスト エディターで AdMediator.config ファイルを開きます。
4. ファイルで、```<Name>MicrosoftAdvertising</Name>``` 子要素を持つ ```<AdAdapterInfo>``` 要素を見つけます。 このセクションには、Microsoft の有料広告用の構成が含まれています。
5. この ```<AdAdapterInfo>``` 要素で、**WApplicationId** 値および **WAdUnitId** 値を持つ ```<Key>``` 要素を含む ```<Property>``` 要素を見つけます。 次の例では、```<Value>``` 要素の値の例を示します。

  > [!div class="tabbedCodeSnippets"]
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

  > [!div class="tabbedCodeSnippets"]
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

## <a name="step-2-update-your-app-code"></a>手順 2: アプリのコードを更新する

アプリケーション ID と広告ユニット ID を用意できたため、**AdMediatorControl** の代わりに **AdControl** を使うようにアプリのコードを更新する準備ができました。

### <a name="microsoft-paid-ads-only"></a>Microsoft の有料広告のみ

広告メディエーション構成で Microsoft の有料広告のみを使用する場合は、次の手順に従います。

  >**注**&nbsp;&nbsp;次の手順では、広告を表示するアプリのページに **myAdGrid** という名前の空のグリッド (```<Grid x:Name="myAdGrid"/>``` など) が含まれていることを前提としています。 次の手順では、広告コントロールをすべて、XAML 内ではなくコード内で作成して構成します。

1. Visual Studio で、UWP アプリ プロジェクトを開きます。
2.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。
**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。
3. **[参照マネージャー]** で、[OK] をクリックします。
4. XAML から **AdMediatorControl** 宣言を削除し、この **AdMediatorControl** オブジェクトを使用するコードを、関連するイベント ハンドラーを含めすべて削除します。
5. 広告を表示するアプリの **Page** のコード ファイルを開きます。
6. まだ存在しない場合は、コード ファイルの先頭に次のステートメントを追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[TrialVersion](./code/AdvertisingSamples/MigrateToAdControl/cs/MainPage.xaml.cs#Snippet1)]

7. **Page** クラスに次の定数宣言を追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[TrialVersion](./code/AdvertisingSamples/MigrateToAdControl/cs/MainPage.xaml.cs#Snippet2)]

7. これらの定数宣言の値をそれぞれ以下のように置き換えます。

  * **AD_WIDTH** と **AD_HEIGHT**: これらを、[バナー広告でサポートされる広告サイズ]( https://msdn.microsoft.com/windows/uwp/monetize/supported-ad-sizes-for-banner-ads)のいずれかに割り当てます。
  * **WAPPLICATIONID** と **WADUNITID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **WApplicationId** 値と **WAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイル以外の広告ユニットで使います)。
  * **MAPPLICATIONID** と **MADUNITID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **MApplicationId** 値と **MAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイルの広告ユニットで使います)。

8. **Page** クラスに次の変数宣言を追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/MainPage.xaml.cs#Snippet3)]

5. **InitializeComponent()** メソッドの呼び出しの後に、**Page** クラスのコンストラクターに次のコードを追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/MainPage.xaml.cs#Snippet4)]

### <a name="microsoft-paid-ads-house-ads-and-adduplex"></a>Microsoft の有料広告、自社広告、AdDuplex

Microsoft の自社広告または AdDuplex に加えて Microsoft の有料広告を使用し、引き続き AdDuplex によって広告を仲介する場合は、このセクションの次の手順に従います。 コード例は、AdDuplex とマイクロソフトの自社広告の両方をサポートします。 AdDuplex を使っても Microsoft の自社広告は使わない (またはその逆) 場合は、シナリオに適していないコードを削除します。

  >**注**&nbsp;&nbsp;次の手順では、広告を表示するアプリのページに **myAdGrid** という名前の空のグリッド (```<Grid x:Name="myAdGrid"/>``` など) が含まれていることを前提としています。 次の手順では、広告コントロールをすべて、XAML 内ではなくコード内で作成して構成します。

1. Visual Studio で、UWP アプリ プロジェクトを開きます。
2.  **ソリューション エクスプローラー**のウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。
**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。
3. **[参照マネージャー]** で、[OK] をクリックします。
4. XAML から **AdMediatorControl** 宣言を削除し、この **AdMediatorControl** オブジェクトを使用するコードを、関連するイベント ハンドラーを含めすべて削除します。
5. 広告を表示するアプリの **Page** のコード ファイルを開きます。
6. まだ存在しない場合は、コード ファイルの先頭に次のステートメントを追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/ExamplePage1.xaml.cs#Snippet1)]

7. **Page** クラスに次の定数宣言を追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/ExamplePage1.xaml.cs#Snippet2)]

4. これらの定数宣言の値を以下のように置き換えます。

  * **AD_WIDTH** と **AD_HEIGHT**: これらを、[バナー広告でサポートされる広告サイズ]( https://msdn.microsoft.com/windows/uwp/monetize/supported-ad-sizes-for-banner-ads)のいずれかに割り当てます。
  * **HOUSE_AD_WEIGHT**: これを、Microsoft の有料広告と比較した Microsoft の自社広告に適用する加重値を指定する 0 ～ 100 の整数に割り当てます (0 の場合は自社広告がまったく表示されず、100 の場合は常に自社広告が表示されます)。
  * **WAPPLICATIONID** と **WADUNITID_PAID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **WApplicationId** 値と **WAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイル以外の広告ユニットで使います)。
  * **WADUNITID_HOUSE**: これを、前にメディエーション構成ファイルから取得した Microsoft の自社広告の **WAdUnitId** 値に割り当てます (この値は、自社広告用のモバイル以外の広告ユニットで使います)。
  * **MAPPLICATIONID** と **MADUNITID_PAID**: これらを、前にメディエーション構成ファイルから取得した Microsoft の有料広告の **MApplicationId** 値と **MAdUnitId** 値に割り当てます (これらの値は、有料広告用のモバイルの広告ユニットで使います)。
  * **MADUNITID_HOUSE**: これを、前にメディエーション構成ファイルから取得した Microsoft の自社広告の **MAdUnitId** 値に割り当てます (この値は、自社広告用のモバイルの広告ユニットで使います)。
  * **ADDUPLEX_APPKEY** と **ADDUPLEX_ADUNIT**: これらを、前にメディエーション構成ファイルから取得した AdDuplex アプリ キー値と広告ユニット ID 値に割り当てます。

  >**注**&nbsp;&nbsp;**前の例の AD_REFRESH_SECONDS** と **MAX_ERRORS_PER_REFRESH** の値は変更しないでください。

5. **Page** クラスに次の変数宣言を追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/ExamplePage1.xaml.cs#Snippet3)]

5. **InitializeComponent()** メソッドの呼び出しの後に、**Page** クラスのコンストラクターに次のコードを追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/ExamplePage1.xaml.cs#Snippet4)]

6. 最後に、**Page** クラスに次のメソッドを追加します。 これらのメソッドは Microsoft の **AdControl** オブジェクトと AdDuplex の **AdControl** オブジェクトをインスタンス化し、乱数ジェネレーターを与えられた加重値と共に使って、これらのコントロールのバナー広告を一定の時間間隔で更新します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[AdControl](./code/AdvertisingSamples/MigrateToAdControl/cs/ExamplePage1.xaml.cs#Snippet5)]
