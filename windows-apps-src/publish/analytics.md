---
author: JnHs
Description: Get detailed analytics for your Windows apps, in the dashboard or via other methods.
title: アプリのパフォーマンスの分析
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
ms.author: wdg-dev-content
ms.date: 07/17/2018
ms.topic: article
keywords: windows 10、uwp、分析、レポート、ダッシュ ボード、アプリ、データ、メトリック
ms.localizationpriority: medium
ms.openlocfilehash: e31ae50a1895c5878a2183b7f63ce3080623f7e9
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5552135"
---
# <a name="analyze-app-performance"></a>アプリのパフォーマンスの分析

アプリについての詳しい分析を Windows デベロッパー センター ダッシュボードで確認できます。 統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。 アプリの正常性、広告の使用状況などに関するメトリックも確認できます。

ダッシュボードで分析レポートを表示するか、[必要なレポートをダウンロード](download-analytic-reports.md)してデータをオフラインで分析できます。 [ダッシュボードを使わずに分析データにアクセスする](#no-dashboard)こともできます。

## <a name="view-key-analytics-for-all-your-apps"></a>すべてのアプリについての主要な分析を表示する

最もダウンロードされたアプリについての主要な分析を表示するには、**[分析]** を展開し、**[概要]** を選びます。 既定では、概要ページには、有効期間内の取得数が最も多い 5 つのアプリに関する情報が表示されます。 別の発行済みのアプリを選んで表示するには、**[フィルター]** を選びます。

## <a name="view-individual-reports-for-each-app"></a>アプリごとに個別レポートを表示する

ここでは、次の各レポートに表示される情報の詳細情報を示します。

-   [取得レポート](acquisitions-report.md)
-   [[アドオン取得] レポート](add-on-acquisitions-report.md)
-   [[使用状況] レポート](usage-report.md)
-   [状態レポート](health-report.md)
-   [評価レポート](ratings-report.md)
-   [レビュー レポート](reviews-report.md)
-   [フィードバック レポート](feedback-report.md)
-   [Xbox 分析レポート](xbox-analytics-report.md)
-   [インサイト レポート](insights-report.md)
-   [広告パフォーマンス レポート](advertising-performance-report.md)
-   [[広告キャンペーン] レポート](promote-your-app-report.md)


> [!NOTE]
> アプリの実際の機能や実装によっては、これらのレポートの一部にデータが含まれていないことがあります。

<span id="no-dashboard"/>

## <a name="access-analytics-data-without-using-the-dev-center-dashboard"></a>デベロッパー センター ダッシュボードを使わずに分析データにアクセスする

ダッシュボードにレポートを表示するだけでなく、さまざまな方法でアプリ分析にアクセスできます。

### <a name="microsoft-store-analytics-api"></a>Microsoft Store 分析 API

[Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md) を使うと、アプリの分析データをプログラムで取得できます。 この REST API では、アプリおよびアドオンの入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

### <a name="windows-dev-center-content-pack-for-power-bi"></a>Power BI 用 Windows デベロッパー センター コンテンツ パック

[Power BI 用 Windows デベロッパー センター コンテンツ パック](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)を使うと、デベロッパー センターの分析データを Power BI で確認および監視できます。 Power BI とは、ビジネス データの 1 つのビューを提供するクラウド ベースのビジネス分析サービスです。

Power BI を使って分析データにアクセスするには、まず、次のリソースをご覧ください。

* [Power BI のサインアップ](https://powerbi.microsoft.com/documentation/powerbi-service-self-service-signup-for-power-bi/)
* [Power BI の使い方](https://powerbi.microsoft.com/guided-learning/)
* [Power BI 用 Windows デベロッパー センター コンテンツ パックを使って分析データに接続する方法](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)

> [!NOTE]
> Power BI 用 Windows デベロッパー センター コンテンツ パックに接続する際には、デベロッパー センター アカウントに関連付けられた Azure AD ディレクトリの資格情報を指定することをお勧めします。 Microsoft アカウントの資格情報を使う場合は、Power BI の分析データが自動的に更新されないため、Power BI にサインインしてデータを更新する必要があります。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、[こちらから無料で入手](http://go.microsoft.com/fwlink/p/?LinkId=703757)できます。 関連付けをセットアップする方法について詳しくは、「[Azure Active Directory とデベロッパー センター アカウントとの関連付け](associate-azure-ad-with-dev-center.md)」をご覧ください。

### <a name="dev-center-app"></a>Dev Center アプリ

[Dev Center](https://www.microsoft.com/store/apps/dev-center/9nblggh4r5ws) アプリをインストールすると、すべての Windows 10 デバイスでアプリの正常性とパフォーマンスに関する詳細情報をすばやく確認できます。

