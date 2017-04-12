---
author: mcleanbyron
ms.assetid: 9FCBAF2E-5419-4169-A17C-9C4058DCF909
description: "Windows ストアでは、REST API を経由して呼び出すことができるいくつかのサービスを公開しています。これらのサービスを利用すると、お客様やお客様の組織の Windows デベロッパー センター アカウントに登録されているアプリの特定の種類のデータに、プログラムを使ってアクセスすることができます。"
title: "Windows ストア サービス"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス"
ms.openlocfilehash: 27e4084cc3ab168fcb68969f973ad21f040cec4f
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="windows-store-services"></a>Windows ストア サービス

Windows ストアでは、REST API を経由して呼び出すことができるいくつかのサービスを公開しています。これらのサービスを利用すると、お客様やお客様の組織の Windows デベロッパー センター アカウントに登録されているアプリの特定の種類のデータに、プログラムを使ってアクセスすることができます。

## <a name="in-this-section"></a>このセクションの内容


| トピック            | 説明                 |
|------------------|-----------------------------|
| [分析データへのアクセス](access-analytics-data-using-windows-store-services.md) | "Windows ストア分析 API"** を使うと、アプリの分析データをプログラムで取得できます。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、アプリのエラー、アプリの評価とレビューに関するデータや、アプリ内広告とプロモーション用広告キャンペーンに関するパフォーマンス データを取得できます。 |
| [レビューへの返信](respond-to-reviews-using-windows-store-services.md) | ストアのアプリのレビューにプログラムで返信するには、"Windows ストア レビュー API"** を使用します。 この API は、Windows デベロッパー センター ダッシュボードを使わずに、多数のレビューに対して開発者がまとめて返信する場合に特に便利です。  |
| [広告キャンペーンの実行](run-ad-campaigns-using-windows-store-services.md) | "Windows ストア プロモーション API"** を使うと、アプリのプロモーション用広告キャンペーンをプログラムで管理できます。 この API では、キャンペーンとその他の関連アセット (ターゲット設定やクリエイティブなど) を作成、更新、監視できます。 この API は、大量のキャンペーンを作成する開発者や、Windows デベロッパー センター ダッシュボードを使わずにキャンペーンを作成する必要がある開発者に特に便利です。 |
| [申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md) | "Windows ストア申請 API"** を使うと、自分または自分の組織の Windows デベロッパー センター アカウントに対して、アプリ、アドオン、パッケージ フライトの申請をプログラムで照会したり作成したりできます。 この API は、アカウントで多数のアプリやアドオンを管理していて、それらのアセットの申請プロセスを自動化して最適化する必要がある場合に役立ちます。 |
| [サービスによる製品の権利の管理](view-and-grant-products-from-a-service.md)  | ストアに登録されているアプリとアドオンのカタログがある場合は、"Windows ストア コレクション API"** と "Windows ストア購入 API"** を使って、サービスからこれらの製品の所有権情報にアクセスしたり、コンシューマブルな製品をユーザーに対してフルフィルメント完了として報告したり、無料の製品の権利をユーザーに付与したりできます。  |
| [広告ネットワーク用のアプリのメタデータ API](app-metadata-api-for-advertising-networks.md)  | 広告ネットワークでは、この API を使用してプログラムで Windows ストア内のアプリに関するメタデータを取得できます。これには、アプリのストア登録情報の説明とカテゴリ、アプリが 13 歳未満の子供を対象とするかどうかなどの詳細が含まれます。 この API へのアクセスは、現在、Microsoft によってアクセス許可が付与されている開発者に制限されています。  |
