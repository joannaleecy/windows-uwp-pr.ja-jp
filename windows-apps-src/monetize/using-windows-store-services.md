---
author: mcleanbyron
ms.assetid: 9FCBAF2E-5419-4169-A17C-9C4058DCF909
description: Microsoft ストアに公開する、または自分の組織に登録されているアプリのデータの特定の種類にアクセスする REST Api を使って呼び出すことができるいくつかのサービス ' s Windows デベロッパー センター アカウント。
title: Microsoft Store サービス
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ストア サービス
ms.localizationpriority: medium
ms.openlocfilehash: b42a968bd6aff3acfffda180a45c8bcc15a564dc
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "565553"
---
# <a name="microsoft-store-services"></a>Microsoft Store サービス

Microsoft ストアは、特定の種類のまたは組織の Windows デベロッパー センターのアカウントに登録されているアプリのデータにアクセスする REST Api を使って呼び出すことができるいくつかのサービスを公開します。

## <a name="in-this-section"></a>このセクションの内容


| トピック            | 説明                 |
|------------------|-----------------------------|
| [分析データへのアクセス](access-analytics-data-using-windows-store-services.md) | プログラムを使用して、アプリのデータを分析を取得するのにには、 *Microsoft ストア分析 API*を使用します。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、アプリのエラー、アプリの評価とレビューに関するデータや、アプリ内広告とプロモーション用広告キャンペーンに関するパフォーマンス データを取得できます。 |
| [レビューへの返信](respond-to-reviews-using-windows-store-services.md) | Store のアプリのレビューにプログラムで返信するには、*Microsoft Store レビュー API* を使います。 この API は、Windows デベロッパー センター ダッシュボードを使わずに、多数のレビューに対して開発者がまとめて返信する場合に特に便利です。  |
| [広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md) | プログラムを使用してアプリの広告のプロモーション キャンペーンを管理するのにには、 *Microsoft ストア プロモーション API*を使用します。 この API では、キャンペーンとその他の関連アセット (ターゲット設定やクリエイティブなど) を作成、更新、監視できます。 この API は、大量のキャンペーンを作成する開発者や、Windows デベロッパー センター ダッシュボードを使わずにキャンペーンを作成する必要がある開発者に特に便利です。 |
| [申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md) | *Microsoft Store 申請 API* を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに対して、アプリ、アドオン、パッケージ フライトの申請をプログラムで照会したり作成したりできます。 この API は、アカウントで多数のアプリやアドオンを管理しており、こうしたアセットの申請プロセスを自動化および最適化する場合に便利です。 |
| [対象のプランを管理する ](manage-targeted-offers-using-windows-store-services.md) | プログラムを使用して、アプリのアドオンの購入の成功に関連付けられているプランを対象となるを要求の*対象となる Microsoft ストアは、API*を使用します。 |
| [サービスから製品の権利を管理する](view-and-grant-products-from-a-service.md)  | ストアのアプリとアドオンのカタログをした場合は、 *Microsoft ストア コレクション API*および使用*Microsoft ストア購入 API*所有権情報にアクセスしてこれらの製品、サービスから、満たさ消耗品のレポートユーザーと、利用資格の無料の製品をユーザーに許可を付与します。  |
| [広告ネットワーク用のアプリのメタデータ API](app-metadata-api-for-advertising-networks.md)  | ネットワークの広告プログラムを使用して、説明と、ストア一覧については、アプリ、および [13 の子にアプリを対象とするかどうかのカテゴリなどの詳細を含む、Microsoft ストア内のアプリに関するメタデータを取得するのにこの API を使用できます。 この API へのアクセスは、現在、Microsoft によってアクセス許可が付与されている開発者に制限されています。  |
