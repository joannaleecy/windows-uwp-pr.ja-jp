---
author: shawjohn
Description: "詳細な分析は、Windows デベロッパー センター ダッシュボードで表示できます。"
title: "分析"
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
ms.author: johnshaw
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、分析、報告、ダッシュ ボード、アプリ"
ms.openlocfilehash: 13a37a4ae2cea67fdce843ed4e6189797d85b93e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="analytics"></a>分析

詳細な分析は、Windows デベロッパー センター ダッシュボードで表示できます。 統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。 アプリの正常性、広告の使用状況などに関する情報も確認できます。 ダッシュボードでレポートを表示するか、[必要なレポートをダウンロード](download-analytic-reports.md)してデータをオフラインで分析します。 [ダッシュボードを使わずに分析データにアクセスする](#no-dashboard)こともできます。

> [!NOTE]
> ダッシュボードのレポートに加えて、[Windows ストア分析 REST API](../monetize/access-analytics-data-using-windows-store-services.md) を使ってプログラムでいくつかの分析データにアクセスできます。

## <a name="analytics-for-all-your-apps"></a>すべてのアプリの分析

上部のナビゲーション メニューで、最もダウンロードされたアプリについての主要な分析を表示するには、**[分析]** > **[概要]** の順に選択します。 既定では、**[分析の概要]** ページには、全期間の取得数が最も多い 5 つのアプリに関する情報が表示されます。 別のアプリを選択して表示するには、**[フィルターを変更します]** を選択します。

## <a name="available-reports-for-each-app"></a>各アプリで利用可能なレポート

ここでは、次の各レポートに表示される情報の詳細情報を示します。

-   [取得レポート](acquisitions-report.md)
-   [アドオン取得レポート](add-on-acquisitions-report.md)
-   [インストール レポート](installs-report.md)
-   [利用状況レポート](usage-report.md)
-   [状態レポート](health-report.md)
-   [評価レポート](ratings-report.md)
-   [レビュー レポート](reviews-report.md)
-   [フィードバック レポート](feedback-report.md)
-   [チャネルとコンバージョン レポート](channels-and-conversions-report.md)
-   [広告メディエーション レポート](ad-mediation-report.md)
-   [広告パフォーマンス レポート](advertising-performance-report.md)
-   [アフィリエイト パフォーマンス レポート](affiliates-performance-report.md)
-   [アプリの販売促進レポート](promote-your-app-report.md)

> [!NOTE]
> アプリの実際の機能や実装によっては、これらのレポートの一部にデータが含まれていないことがあります。

## <a name="page-and-section-filters"></a>ページ フィルターとセクション フィルター

各レポートには、データのドリルダウンに使うことができるフィルターが含まれています。 ページの上部付近には、**[フィルターの適用]** が表示されます。 これらフィルターを使うと、ページ上のすべてのチャートと情報の範囲を縮小または拡大することができます。

各チャート内には、個別のセクション フィルターも表示されることがあります。 このフィルターは、その特定のチャートについて表示されるデータを縮小できます。

実際のフィルターはレポートごとに異なります。 このセクションのトピックでは、利用可能なフィルターと、各レポートのページにあるその他のデータについて説明します。

<span id="no-dashboard"/>
## <a name="access-analytics-data-without-using-the-dev-center-dashboard"></a>デベロッパー センター ダッシュボードを使わずに分析データにアクセスする

分析データにアクセスするには、ダッシュボードの分析レポートのほかにもいくつかの方法があります。

### <a name="windows-store-analytics-api"></a>Windows ストア分析 API

[Windows ストア分析 API](../monetize/access-analytics-data-using-windows-store-services.md) を使うと、アプリの分析データをプログラムで取得できます。 この REST API では、アプリおよびアドオンの入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

### <a name="windows-dev-center-content-pack-for-power-bi"></a>Power BI 用 Windows デベロッパー センター コンテンツ パック

[Power BI 用 Windows デベロッパー センター コンテンツ パック](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)を使うと、デベロッパー センターの分析データを Power BI で確認および監視できます。 Power BI とは、ビジネス データの 1 つのビューを提供するクラウド ベースのビジネス分析サービスです。

Power BI を使って分析データにアクセスするには、まず、次のリソースをご覧ください。

* [Power BI のサインアップ](https://powerbi.microsoft.com/documentation/powerbi-service-self-service-signup-for-power-bi/)
* [Power BI の使い方](https://powerbi.microsoft.com/guided-learning/)
* [Power BI 用 Windows デベロッパー センター コンテンツ パックを使って分析データに接続する方法](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)

> [!NOTE]
> Power BI 用 Windows デベロッパー センター コンテンツ パックに接続する際には、デベロッパー センター アカウントに関連付けられた Azure AD ディレクトリの資格情報を指定することをお勧めします。 Microsoft アカウントの資格情報を使う場合は、Power BI の分析データが自動的に更新されないため、Power BI にサインインしてデータを更新する必要があります。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、[こちらから無料で入手](http://go.microsoft.com/fwlink/p/?LinkId=703757)できます。 デベロッパー センター アカウントを Azure AD に関連付ける方法について詳しくは、「[アカウント ユーザーの管理](manage-account-users.md)」をご覧ください。

### <a name="dev-center-app"></a>Dev Center アプリ

[Dev Center](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) アプリをインストールすると、すべての Windows 10 デバイスでアプリの正常性とパフォーマンスに関する詳細情報をすばやく確認できます。

## <a name="related-topics"></a>関連トピック
- [Windows アプリの公開](index.md)
