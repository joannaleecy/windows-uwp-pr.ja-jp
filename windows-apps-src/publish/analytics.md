---
Description: パートナー センターで、またはその他のメソッドを使用して、Windows アプリの詳細な分析を取得します。
title: アプリのパフォーマンスの分析
ms.assetid: 3A3C6F10-0DB1-416D-B632-CD388EA66759
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10、uwp、分析、レポート、ダッシュ ボード、アプリ、データ、メトリック
ms.localizationpriority: medium
ms.openlocfilehash: 6f76b1f897c345fb71beec8e37e592165922b2ed
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625447"
---
# <a name="analyze-app-performance"></a>アプリのパフォーマンスの分析

詳細な分析を表示するには、アプリで[パートナー センター](https://partner.microsoft.com/dashboard)します。 統計情報とチャートでは、アプリの状況 (獲得したユーザーから、ユーザーによるアプリの使い方、ユーザーによるアプリの評判まで) を知ることができます。 アプリの正常性、広告の使用状況などに関するメトリックも確認できます。

分析レポートを表示するパートナー センターで直接または[必要があるレポートのダウンロード](download-analytic-reports.md)オフライン データを分析します。 ためのいくつかの方法も提供[パートナー センターの外部での分析データにアクセス](#outside)します。

## <a name="view-key-analytics-for-all-your-apps"></a>すべてのアプリについての主要な分析を表示する

最もダウンロードされたアプリについての主要な分析を表示するには、**[分析]** を展開し、**[概要]** を選びます。 既定では、概要ページには、有効期間内の取得数が最も多い 5 つのアプリに関する情報が表示されます。 別の発行済みのアプリを選んで表示するには、**[フィルター]** を選びます。

## <a name="view-individual-reports-for-each-app"></a>アプリごとに個別レポートを表示する

ここでは、次の各レポートに表示される情報の詳細情報を示します。

-   [取得レポート](acquisitions-report.md)
-   [アドオン取得レポート](add-on-acquisitions-report.md)
-   [利用状況レポート](usage-report.md)
-   [正常性レポート](health-report.md)
-   [評価レポート](ratings-report.md)
-   [レビュー レポート](reviews-report.md)
-   [フィードバック レポート](feedback-report.md)
-   [Xbox の分析レポート](xbox-analytics-report.md)
-   [Insights のレポート](insights-report.md)
-   [広告パフォーマンス レポート](advertising-performance-report.md)
-   [広告キャンペーン レポート](promote-your-app-report.md)


> [!NOTE]
> アプリの実際の機能や実装によっては、これらのレポートの一部にデータが含まれていないことがあります。

<span id="outside"/>

## <a name="access-analytics-data-outside-of-partner-center"></a>パートナー センターの外部で分析データにアクセス

パートナー センターでレポートを表示する以外には、他の方法でアプリの分析を利用できます。

### <a name="microsoft-store-analytics-api"></a>Microsoft Store 分析 API

[Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md) を使うと、アプリの分析データをプログラムで取得できます。 この REST API では、アプリおよびアドオンの入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

### <a name="windows-dev-center-content-pack-for-power-bi"></a>Power BI 用 Windows デベロッパー センター コンテンツ パック

使用して、 [Power BI 用 Windows デベロッパー センター コンテンツ パック](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)に探索、Power BI では、パートナー センター アナリティクスのデータを監視します。 Power BI とは、ビジネス データの 1 つのビューを提供するクラウド ベースのビジネス分析サービスです。

Power BI を使って分析データにアクセスするには、まず、次のリソースをご覧ください。

* [Power BI にサインアップします。](https://powerbi.microsoft.com/documentation/powerbi-service-self-service-signup-for-power-bi/)
* [Power BI を使用する方法について説明します](https://powerbi.microsoft.com/guided-learning/)
* [Power BI 用 Windows デベロッパー センター コンテンツ パックを使用して、分析データに接続する方法について説明します](https://powerbi.microsoft.com/documentation/powerbi-content-pack-windows-dev-center/)

> [!NOTE]
> Power BI 用 Windows デベロッパー センター コンテンツ パックに接続する場合、パートナー センター アカウントに関連付けられている Azure AD ディレクトリからの資格情報を指定することをお勧めします。 Microsoft アカウントの資格情報を使う場合は、Power BI の分析データが自動的に更新されないため、Power BI にサインインしてデータを更新する必要があります。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、[こちらから無料で入手](https://go.microsoft.com/fwlink/p/?LinkId=703757)できます。 アソシエーションの設定に関する詳細については、次を参照してください。[関連付ける Azure Active Directory と、パートナー センター アカウント](associate-azure-ad-with-dev-center.md)します。
