---
author: Xansky
ms.assetid: 9FCBAF2E-5419-4169-A17C-9C4058DCF909
description: Microsoft ストアでは、特定の種類のデータを自分または自分の組織のパートナー センター アカウントに登録されているアプリをプログラムでアクセスする REST Api 経由で呼び出すことができるいくつかのサービスを公開します。
title: Microsoft Store サービス
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ストア サービス
ms.localizationpriority: medium
ms.openlocfilehash: 0d13c5c9428a38dd212e59688d2b4b5eae187ea4
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6143368"
---
# <a name="microsoft-store-services"></a>Microsoft Store サービス

Microsoft ストアでは、特定の種類のデータを自分または自分の組織のパートナー センター アカウントに登録されているアプリをプログラムでアクセスする REST Api 経由で呼び出すことができるいくつかのサービスを公開します。

## <a name="in-this-section"></a>このセクションの内容


| トピック            | 説明                 |
|------------------|-----------------------------|
| [分析データへのアクセス](access-analytics-data-using-windows-store-services.md) | プログラムによって、アプリの分析データを取得するのにには、 *Microsoft Store 分析 API*を使用します。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、アプリのエラー、アプリの評価とレビューに関するデータや、アプリ内広告とプロモーション用広告キャンペーンに関するパフォーマンス データを取得できます。 |
| [レビューへの返信](respond-to-reviews-using-windows-store-services.md) | Store のアプリのレビューにプログラムで返信するには、*Microsoft Store レビュー API* を使います。 この API は、パートナー センターを使用せず、多数のレビューに返信一括する必要がある開発者に特に便利です。  |
| [広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md) | *Microsoft Store プロモーション API*を使用して、アプリのプロモーション用の広告キャンペーンをプログラムで管理します。 この API では、キャンペーンとその他の関連アセット (ターゲット設定やクリエイティブなど) を作成、更新、監視できます。 この API は、大量のキャンペーンを作成していると、ユーザーを対象パートナー センター dhboard を使用せずに開発者に特に便利です。 |
| [申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md) | プログラムで照会したり、アプリ、アドオン、および、自分または自分の組織のパートナー センター アカウントのパッケージ フライトの申請を作成するには、 *Microsoft Store 申請 API*を使用します。 この API は、アカウントで多数のアプリやアドオンを管理しており、こうしたアセットの申請プロセスを自動化および最適化する場合に便利です。 |
| [対象のプランを管理する ](manage-targeted-offers-using-windows-store-services.md) | プログラムで成功した場合、アプリのアドオンの購入に関連付けられているターゲット オファーを要求するには、 *Microsoft Store ターゲット オファー API*を使用します。 |
| [サービスから製品の権利を管理する](view-and-grant-products-from-a-service.md)  | ストアでアプリとアドオンのカタログがある場合は、 *Microsoft Store コレクション API*と*Microsoft Store 購入 API*を使って所有権情報にアクセスこれらの製品、サービスから、コンシューマブルな製品をフルフィルメント完了として報告ユーザー、およびユーザーに無料の製品の権利を付与します。  |
| [広告ネットワーク用のアプリのメタデータ API](app-metadata-api-for-advertising-networks.md)  | 広告ネットワークはプログラムによって、説明やカテゴリなど、アプリおよび子 13 下に、アプリを対象とするかどうかのストア登録情報の詳細を含む、Microsoft ストアのアプリに関するメタデータを取得、この API を使用できます。 この API へのアクセスは、現在、Microsoft によってアクセス許可が付与されている開発者に制限されています。  |
