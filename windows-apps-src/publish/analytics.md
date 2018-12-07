---
Description: Get detailed analytics for your Windows apps, in Partner Center or via other methods.
title: アプリのパフォーマンスの分析
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10、uwp、分析、レポート、ダッシュ ボード、アプリ、データ、メトリック
ms.localizationpriority: medium
ms.openlocfilehash: f6a6d79745ec98af2c7f562297092eea3feda659
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8790344"
---
# <a name="analyze-app-performance"></a>アプリのパフォーマンスの分析

[パートナー センター](https://partner.microsoft.com/dashboard)で、アプリの詳細な分析を表示することができます。 統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。 アプリの正常性、広告の使用状況などに関するメトリックも確認できます。

分析レポートを表示するデータをオフラインで分析するパートナー センターまたは[必要なレポートのダウンロード](download-analytic-reports.md)で直接します。 用意していますいくつかの方法のパートナー センター外部にも、分析データに[アクセス](#outside)します。

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

<span id="outside"/>

## <a name="access-analytics-data-outside-of-partner-center"></a>パートナー センター外部分析データにアクセス

パートナー センターでレポートを表示する、だけでなく他の方法でアプリ分析にアクセスできます。

### <a name="microsoft-store-analytics-api"></a>Microsoft Store 分析 API

[Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md) を使うと、アプリの分析データをプログラムで取得できます。 この REST API では、アプリおよびアドオンの入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

### <a name="windows-dev-center-content-pack-for-power-bi"></a>Power BI 用 Windows デベロッパー センター コンテンツ パック

調査し、Power BI でパートナー センター分析データを監視するには、 [Power BI 用 Windows デベロッパー センター コンテンツ パック](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)を使用します。 Power BI とは、ビジネス データの 1 つのビューを提供するクラウド ベースのビジネス分析サービスです。

Power BI を使って分析データにアクセスするには、まず、次のリソースをご覧ください。

* [Power BI のサインアップ](https://powerbi.microsoft.com/documentation/powerbi-service-self-service-signup-for-power-bi/)
* [Power BI の使い方](https://powerbi.microsoft.com/guided-learning/)
* [Power BI 用 Windows デベロッパー センター コンテンツ パックを使って分析データに接続する方法](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)

> [!NOTE]
> Power BI 用 Windows デベロッパー センター コンテンツ パックに接続するには、パートナー センター アカウントに関連付けられている Azure AD ディレクトリからの資格情報を指定することお勧めします。 Microsoft アカウントの資格情報を使う場合は、Power BI の分析データが自動的に更新されないため、Power BI にサインインしてデータを更新する必要があります。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、[こちらから無料で入手](http://go.microsoft.com/fwlink/p/?LinkId=703757)できます。 関連付けをセットアップについて詳しくは、 [Azure Active Directory の関連付け](associate-azure-ad-with-dev-center.md)を参照してください。
