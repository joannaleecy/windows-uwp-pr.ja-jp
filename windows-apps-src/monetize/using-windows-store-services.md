---
ms.assetid: 9FCBAF2E-5419-4169-A17C-9C4058DCF909
description: Microsoft Store では、特定の種類のまたは組織のパートナー センター アカウントに登録されているアプリのデータをプログラムでアクセスする REST Api 経由で呼び出すことのできるいくつかのサービスを公開します。
title: Microsoft Store サービス
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ストア サービス
ms.localizationpriority: medium
ms.openlocfilehash: 0557120afc324986fcab4fbe8e75f8819be004b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661497"
---
# <a name="microsoft-store-services"></a>Microsoft Store サービス

Microsoft Store では、特定の種類のまたは組織のパートナー センター アカウントに登録されているアプリのデータをプログラムでアクセスする REST Api 経由で呼び出すことのできるいくつかのサービスを公開します。

## <a name="in-this-section"></a>このセクションの内容


| トピック            | 説明                 |
|------------------|-----------------------------|
| [分析データにアクセス](access-analytics-data-using-windows-store-services.md) | 使用して、 *Microsoft Store analytics API*をプログラムによって、アプリの分析データを取得します。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、アプリのエラー、アプリの評価とレビューに関するデータや、アプリ内広告とプロモーション用広告キャンペーンに関するパフォーマンス データを取得できます。 |
| [レビューへの返信](respond-to-reviews-using-windows-store-services.md) | Store のアプリのレビューにプログラムで返信するには、*Microsoft Store レビュー API* を使います。 この API は、パートナー センターを使用せず、一括を希望する開発者が多数のレビューに応答に特に便利です。  |
| [広告キャンペーンを実行します。](run-ad-campaigns-using-windows-store-services.md) | 使用して、 *Microsoft Store の上位変換 API*をプログラムで、アプリのプロモーションの広告キャンペーンを管理します。 この API を使用して、広告キャンペーンや、ターゲット設定、クリエイティブなど、その他の関連アセットを作成、更新、および監視できます。 この API は、膨大な量のキャンペーンの作成は誰とも、パートナー センター ダッシュ ボードを使用したい開発者にとって特に便利です。 |
| [作成し、送信の管理](create-and-manage-submissions-using-windows-store-services.md) | 使用して、 *Microsoft Store 送信 API*または組織のパートナー センター アカウントのフライトをプログラムによってクエリを実行し、アプリ、アドオン、およびパッケージのサブミッションを作成します。 この API は、アカウントで多数のアプリやアドオンを管理していて、それらのアセットの申請プロセスを自動化して最適化する必要がある場合に役立ちます。 |
| [対象となるプランを管理します。 ](manage-targeted-offers-using-windows-store-services.md) | 使用して、*対象となる Microsoft Store API を提供する*アドオンで、アプリの成功した発注に関連付けられている対象となるプランをプログラムで要求します。 |
| [サービスからの製品の利用資格を管理します。](view-and-grant-products-from-a-service.md)  | 使用することができます、ストアでアプリとアドオンのカタログをした場合、 *Microsoft Store コレクション API*と*Microsoft Store 購入 API*からこれらの製品の所有権情報にアクセスする、サービスでは、ユーザーを満たすよう消耗品を報告し、無料の製品の権利をユーザーに付与します。  |
| [ネットワークにアドバタイズするためのアプリ メタデータ API](app-metadata-api-for-advertising-networks.md)  | ネットワークにアドバタイズすると、プログラムでの説明と、アプリと子では、13 に、アプリが対象とするかどうかのストアの一覧のカテゴリなどの詳細を含む、Microsoft Store でのアプリに関するメタデータを取得するのにこの API が使用できます。 この API へのアクセスは、現在、Microsoft によってアクセス許可が付与されている開発者に制限されています。  |
