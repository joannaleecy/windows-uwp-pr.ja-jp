---
ms.assetid: 86D9D3CF-8FDC-4B67-881B-DF33A1BEE8BF
description: 広告の仲介を使うには、アプリで使う各広告ネットワークにアカウントを設定する必要があります。
title: 広告ネットワークの選択と管理
---

# 広告ネットワークの選択と管理


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

広告の仲介を使うには、アプリで使う各広告ネットワークにアカウントを設定する必要があります。 広告メディエーター コントロールを Microsoft Visual Studio プロジェクトに追加する前に、これを行うことをお勧めします。 また、広告仲介のパフォーマンスを最適化する際に最大限の柔軟性が得られるように、できるだけ多くの広告ネットワークにアカウントを設定することをお勧めします。

## サポートされている広告ネットワークとプロジェクトの種類

現時点では、次の種類の広告ネットワークとプロジェクトで広告仲介がサポートされています。

|  広告ネットワーク    | C# または Visual Basic と XAML を使ったユニバーサル Windows プラットフォーム (UWP) アプリ | C# または Visual Basic と XAML を使った Windows 8.1 アプリ | C# または Visual Basic と XAML を使った Windows Phone 8.1 アプリ | Windows Phone 8.x Silverlight アプリ |               
|-------------------------------------------------------------------------|----------------------------------------------------|----------------------------------------------------------|-----------------------------------|---------------|
| [Microsoft](#microsoft)                         | **サポートされています**                                      | **サポートされています**                                            | **サポートされています**                     | **サポートされています** |
| [AdDuplex](#adduplex)                                                   | **サポートされています**                                      | **サポートされています**                                            | **サポートされています**                     | **サポートされています** |
| [Smaato](#smaato)                                                       | サポートされていません                                      | **サポートされています**                                            | **サポートされています**                     | **サポートされています** |
| [AdMob (Google)](#admob)                                                | サポートされていません                                      | サポートされていません                                            | サポートされていません                     | **サポートされています** |
| [Inneractive](#inneractive)                                             | サポートされていません                                      | サポートされていません                                            | サポートされていません                     | **サポートされています** |
| [Vserv VMAX](#vserv)                                                    | サポートされていません                                      | サポートされていません                                            | **サポートされています**                     | サポートされていません | 

C++ と XAML、JavaScript と HTML など、いくつかのプロジェクトの種類は、現時点では広告仲介でサポートされていません。 これらの種類のプロジェクトについては、広告仲介を使用せず、Microsoft から広告を表示できます。 詳しくは、[XAML および .NET の AdControl ](https://msdn.microsoft.com/library/mt313186.aspx) または [HTML 5 および JavaScript の AdControl](https://msdn.microsoft.com/library/mt313130.aspx) に関するページをご覧ください。

## 各ネットワーク固有のパラメーターと詳細


ここでは、アカウントの設定方法やアプリの登録方法など、各広告ネットワークに必要な具体的な詳細情報を示します。 また、[アプリの提出と広告仲介の構成](submit-your-app-and-configure-ad-mediation.md)を行うときに (または、[広告仲介の実装をテストする](test-your-ad-mediation-implementation.md)ために接続済みサービスで) 指定する必要がある必須のパラメーターも一覧に示しています。 特定の広告ネットワークの使い方について詳しくは、そのネットワークの Web サイトをご覧ください。

各広告ネットワークには、必須のパラメーターに加えて、アプリでのコードで追加設定できるオプション パラメーターもあります。 例については、このトピックの「[広告ネットワークのオプション パラメーター](#optionalparameters)」をご覧ください。 すべてのオプション パラメーターを網羅した一覧については、各広告ネットワークから提供されるドキュメントをご覧ください。 これらのパラメーターの一部は広告仲介によって無視または上書きされます (これらについては、以降のセクションで示します)。 たとえば、現在位置に関連するパラメーターは、アプリ内の位置情報機能によって決定される、ユーザーの位置に関する情報で通常は上書きされます。

[広告仲介コントロールを追加](add-and-use-the-ad-mediator-control.md)し、どの広告ネットワークを使うかを指定すると、Visual Studio では、広告ネットワーク用に必要なアセンブリの取得がプログラムによって試行されます。 自動的に取得できないアセンブリがある場合は、各広告ネットワークの下に表示されているリンクを使ってインストールできます。

### Microsoft

| Web サイト                        | 広告ネットワークのパラメーターを構成するには、[Windows デベロッパー センター ダッシュボード](https://dev.windows.com/overview)の [[広告で収入を増やす]](https://msdn.microsoft.com/library/windows/apps/mt170658) ページを使います。   |
|--------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK の場所                   | [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk)。                                                                                                                                                                                                                         |
| アプリの登録              | 広告の仲介コントロールをアプリに追加し、アプリを Windows デベロッパー センター ダッシュボードに提出します。                                                                                                                                                                                                            |
| 必須のパラメーター            | ApplicationId と AdUnitId: これらのパラメーターは、アプリ パッケージを提出するときに、アプリのコンテンツに基づいて自動的に入力されます。 ただし、[アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)を行うときに、これらのパラメーターを必要に応じて編集することができます。 <br> <br> Height と Width (Windows Phone 8 Silverlight と Windows Phone 8.1 Silverlight の場合にのみ必要)。                                                                                                                                                                                                           |
| 上書き/無視されるパラメーター | Latitude (上書きされます)  <br><br> Longitude (上書きされます) <br><br> AutoRefreshIntervalInSeconds (無視されます) <br><br> IsAutoRefreshEnabled (無視されます) <br><br> IsAutoCollapsedEnabled (無視されます) <br><br> IsEngaged (無視されます) <br><br> IsSuspended (無視されます) |

 

### AdDuplex

| Web サイト                        | [http://adduplex.com](http://go.microsoft.com/fwlink/p/?LinkId=518028)      |
|--------------------------------|-----------------------------------------------------------------------------|
| SDK の場所                   | まず、広告仲介コントロールで接続済みサービスからアセンブリの取得を試行してください。詳しくは、「[広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。 アセンブリを手動でダウンロードする必要がある場合は、AdDuplex の Web サイトで [[Getting started]](http://go.microsoft.com/fwlink/p/?LinkId=518029) (作業の開始) セクションに移動します。 |
| アプリの登録              | AdDuplex ポータルで新しいアプリを作成します。                                                                                                                                                                                                                                                                                                        |
| 必須のパラメーター            | AppKey <br><br> AdUnitId <br><br> Size (Windows 8.1 XAML でのみ必須)  |
| 上書き/無視されるパラメーター | Latitude (上書きされます) <br><br> Longitude (上書きされます) <br><br> AutoRefreshIntervalInSeconds (無視されます) <br><br> IsAutoRefreshEnabled (無視されます) <br><br> IsAutoCollapsedEnabled (無視されます) <br><br> IsEngaged (無視されます) <br><br> IsSuspended (無視されます) |
 

### Smaato

| Web サイト                        | [http://www.smaato.com/](http://go.microsoft.com/fwlink/p/?LinkId=518030)                                                                                                                                                                                                        |
|--------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK の場所                   | まず、広告仲介コントロールで接続済みサービスからアセンブリの取得を試行してください。詳しくは、「[広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。 手動でダウンロードする必要がある場合は、Smaato ポータルで [Downloads] (ダウンロード) タブに移動します。 |
| アプリの登録              | Smaato ポータルで、[My Spaces] (マイ スペース) に移動し、新しい Adspace (広告スペース) を生成します。                                                                                                                                                                                                                |
| 必須のパラメーター            | Pub <br> <br> Adspace <br> <br> Height、Width (Windows 8.1 XAML でのみ必須)  |
| 上書き/無視されるパラメーター | Gps (上書きされます)                                                                                                                                                                                                                                                                |

 

### AdMob (Google)

| Web サイト                        | [http://apps.admob.com](http://go.microsoft.com/fwlink/p/?LinkId=518031)                                               |
|--------------------------------|------------------------------------------------------------------------------------------------------------------------|
| SDK の場所                   | [Google Mobile Ads SDK の Web サイト](http://go.microsoft.com/fwlink/p/?LinkId=518032)から Windows Phone 8 SDK を入手します。 |
| アプリの登録              | AdMob ポータルで、[新しいアプリを収益化] を選びます。                                                                          |
| 必須のパラメーター            | AdUnitID <br> <br> 形式                                                                                              |
| 上書き/無視されるパラメーター | Location (上書きされます)  <br><br> ForceTesting (無視されます) <br><br> Refresh Rate (無視されます)                                |
 

### Inneractive

| Web サイト             | [http://inner-active.com](http://go.microsoft.com/fwlink/p/?LinkId=518035)                                                                                                                                                                                                                                                             |
|---------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK の場所        | まず、広告仲介コントロールで接続済みサービスからアセンブリの取得を試行してください。詳しくは、「[広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。 手動でダウンロードする必要がある場合は、アカウントにサインインし、ダッシュボードの [SDK] タブに移動して、Windows Phone 8 SDK をダウンロードします。 |
| アプリの登録   | Inneractive ポータルで新しいアプリを作成します。                                                                                                                                                                                                                                                                                           |
| 必須のパラメーター | AppID <br> <br> AdType (IaAdType_Banner または IaAdType_Text)                                                                               |
 

### Vserv VMAX

| Web サイト             | [http://www.vmax.com](http://www.vmax.com)                                                                                                                                                                                                                                                                         |
|---------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK の場所        | まず、広告仲介コントロールで接続済みサービスからアセンブリの取得を試行してください。詳しくは、「[広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)」をご覧ください。 アセンブリを手動でダウンロードする必要がある場合は、VMAX の Web サイトで [SDK](http://go.microsoft.com/fwlink/?LinkId=627078) セクションに移動します。 |
| アプリの登録   | VMAX の Web サイトから、アプリの Adspot ID を取得します (Adspot ID は、VMAX API では ZoneId と呼ばれています)。                                                                                                                                                                                                                     |
| 必須のパラメーター | ZoneId                                                                                                                                                                                                                                                                                                                         |12345

 

## 広告ネットワークのオプション パラメーター


各広告ネットワークには、必須のパラメーターに加えて、アプリでのコードで追加設定できるオプション パラメーターもあります。 すべてのオプション パラメーターを網羅した一覧については、各広告ネットワークから提供されるドキュメントをご覧ください。 コードでこれらのオプション パラメーターを設定するには、**AdMediatorControl** オブジェクトの **AdSdkOptionalParameters** プロパティを使用します。

次の例では、Microsoft advertising の **CountryOrRegion** パラメーターを設定する方法を示しています。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["CountryOrRegion"] = "IN";
```

次の例では、Smaato の **Width** パラメーターと **Height** パラメーターを設定する方法を示しています。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Width"] = 300;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Height"] = 250;
```

## 関連トピック

* [広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)
* [広告の仲介の実装のテスト](test-your-ad-mediation-implementation.md)
* [アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)
* [広告の仲介のトラブルシューティング](troubleshoot-ad-mediation.md)
 

 


<!--HONumber=Mar16_HO5-->


