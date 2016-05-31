---
author: jnHs
Description: 詳細な分析は、Windows デベロッパー センター ダッシュボードで表示できます。
title: 分析
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
---

# 分析

詳細な分析は、Windows デベロッパー センター ダッシュボードで表示できます。 統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。 アプリの正常性、広告の使用状況などに関する情報も確認できます。 ダッシュボードでレポートを表示するか、[必要なレポートをダウンロード](download-analytic-reports.md)してデータをオフラインで分析します。 [ダッシュボードを使わずに分析データにアクセスする](#no-dashboard)こともできます。

> **注**
            &nbsp;&nbsp;ダッシュボードのレポートに加えて、[Windows ストア分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) を使ってプログラムでいくつかの分析データにアクセスできます。

## すべてのアプリの分析


ダッシュボードの概要ページには、すべてのアプリに関する詳細情報を集めたロールアップ ビューも含まれています。 概要ページに表示される統計情報は、アプリによって異なります。

[分析レポートをダウンロードする](download-analytic-reports.md) 場合、すべてのアプリについてのレポートをダウンロードすることもできます。 いずれかのアプリについて、**[分析]** セクションで **[レポートのダウンロード]** ページにアクセスする必要がありますが、選んだアプリ以外のレポートもダウンロードできます。

## 各アプリで利用可能なレポート


ここでは、次の各レポートに表示される情報の詳細情報を示します。

-   [取得レポート](acquisitions-report.md)
-   [状態レポート](health-report.md)
-   [レーティング レポート](ratings-report.md)
-   [レビュー レポート](reviews-report.md)
-   [フィードバック レポート](feedback-report.md)
-   [利用状況レポート](usage-report.md)
-   [IAP 取得レポート](iap-acquisitions-report.md)
-   [広告仲介レポート](ad-mediation-report.md)
-   [広告パフォーマンス レポート](advertising-performance-report.md)
-   [アプリのインストールの広告レポート](app-install-ads-reports.md)
-   [チャネルとコンバージョン レポート](channels-and-conversions-report.md)

> **注**
            &nbsp;&nbsp;アプリの実際の機能や実装によっては、これらのレポートの一部にデータが含まれていないことがあります。

## ページ フィルターとセクション フィルター

各レポートには、データのドリルダウンに使うことができるフィルターが含まれています。 ページの上部付近には、**[フィルターの適用]** が表示されます。 これらフィルターを使うと、ページ上のすべてのチャートと情報の範囲を縮小または拡大することができます。

各チャート内には、個別のセクション フィルターも表示されることがあります。 このフィルターは、その特定のチャートについて表示されるデータを縮小できます。

実際のフィルターはレポートごとに異なります。 このセクションのトピックでは、利用可能なフィルターと、各レポートのページにあるその他のデータについて説明します。

<span id="no-dashboard"/>
## デベロッパー センター ダッシュボードを使わずに分析データにアクセスする

分析データにアクセスするには、ダッシュボードの分析レポートのほかにもいくつかの方法があります。

### Windows ストア分析 API

[Windows ストア分析 API](../monetize/access-analytics-data-using-windows-store-services.md) を使うと、アプリの分析データをプログラムで取得できます。 この REST API では、アプリおよび IAP の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

### Power BI 用 Windows デベロッパー センター コンテンツ パック

[Power BI 用 Windows デベロッパー センター コンテンツ パック](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)を使うと、デベロッパー センターの分析データを Power BI で確認および監視できます。 Power BI とは、ビジネス データの 1 つのビューを提供するクラウド ベースのビジネス分析サービスです。

Power BI を使って分析データにアクセスするには、まず、次のリソースをご覧ください。

* [Power BI のサインアップ](https://powerbi.microsoft.com/documentation/powerbi-service-self-service-signup-for-power-bi/)
* [Power BI の使い方](https://powerbi.microsoft.com/guided-learning/)
* [Power BI 用 Windows デベロッパー センター コンテンツ パックを使って分析データに接続する方法](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)

> **注**
            &nbsp;&nbsp;Power BI 用 Windows デベロッパー センター コンテンツ パックに接続する際には、デベロッパー センター アカウントに関連付けられた Azure AD ディレクトリの資格情報を指定することをお勧めします。 Microsoft アカウントの資格情報を使う場合は、Power BI の分析データが自動的に更新されないため、Power BI にログインしてデータを更新する必要があります。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、[こちらから無料で入手](http://go.microsoft.com/fwlink/p/?LinkId=703757)できます。 デベロッパー センター アカウントを Azure AD に関連付ける方法について詳しくは、「[アカウント ユーザーの管理](manage-account-users.md)」をご覧ください。

### Dev Center アプリ

[Dev Center](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) アプリをインストールすると、すべての Windows 10 デバイスでアプリの正常性とパフォーマンスに関する詳細情報をすばやく確認できます。 


<!--HONumber=May16_HO2-->


