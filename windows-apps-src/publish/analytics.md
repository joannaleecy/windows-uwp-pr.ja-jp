---
author: JnHs
Description: "Windows アプリについての詳しい分析をダッシュボードやその他の手段で確認しましょう。"
title: "アプリのパフォーマンスの分析"
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
ms.author: wdg-dev-content
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 分析, 報告, ダッシュ ボード, アプリ"
ms.openlocfilehash: 57e4a30258fa25411bb461cac56aa18d2f74981d
ms.sourcegitcommit: a93b1da07b386a682435de58a8129d7b4ee90c14
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/29/2017
---
# <a name="analyze-app-performance"></a>アプリのパフォーマンスの分析

アプリについての詳しい分析を Windows デベロッパー センター ダッシュボードで確認できます。 統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。 アプリの正常性、広告の使用状況などに関するメトリックも確認できます。

ダッシュボードで分析レポートを表示するか、[必要なレポートをダウンロード](download-analytic-reports.md)してデータをオフラインで分析できます。 [ダッシュボードを使わずに分析データにアクセスする](#no-dashboard)こともできます。

## <a name="view-key-analytics-for-all-your-apps"></a>すべてのアプリについての主要な分析を表示する

最もダウンロードされたアプリについての主要な分析を表示するには、**[分析]** を展開し、**[概要]** を選びます。 既定では、**[分析の概要]** ページには、有効期間内の取得数が最も多い 5 つのアプリに関する情報が表示されます。 別の発行済みのアプリを選んで表示するには、**[フィルター]** を選びます。

## <a name="view-individual-reports-for-each-app"></a>アプリごとに個別レポートを表示する

ここでは、次の各レポートに表示される情報の詳細情報を示します。

-   [[取得] レポート](acquisitions-report.md)
-   [[アドオン取得] レポート](add-on-acquisitions-report.md)
-   [[使用状況] レポート](usage-report.md)
-   [[安定性] レポート](health-report.md)
-   [[レビュー] レポート](reviews-report.md)
-   [[フィードバック] レポート](feedback-report.md)
-   [[広告パフォーマンス] レポート](advertising-performance-report.md)
-   [[広告キャンペーン] レポート](promote-your-app-report.md)

> [!NOTE]
> アプリの実際の機能や実装によっては、これらのレポートの一部にデータが含まれていないことがあります。

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

