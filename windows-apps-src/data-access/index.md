---
author: normesta
ms.assetid: 76776b0f-3163-48c9-835b-3f4213968079
title: データ アクセス
description: このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。
ms.author: normesta
ms.date: 11/13/2017
ms.topic: article
keywords: Windows 10, UWP, データ, データベース, リレーショナル, テーブル, sqlite
ms.localizationpriority: medium
ms.openlocfilehash: beca20d358430ecd82cd1bc57459a6f6af36be77
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7128633"
---
# <a name="data-access"></a>データ アクセス

SQLite データベースを使用してユーザーのデバイスでデータを格納することができます。 あらゆる種類のサービスのレイヤーを使用することがなく SQL Server データベースに直接アプリを接続することもできます。

| トピック | 説明|
|-------|------------|
| [UWP アプリでの SQLite データベースの使用](sqlite-databases.md) | SQLite を使用して格納し、ユーザー デバイス上の軽量なデータベースにデータを取得する方法を示します。 SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 |
| [UWP アプリで、SQL server データベースを使用します。](sql-server-databases.md) | SQL Server データベースに直接接続し、保存し、および[System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx)名前空間のクラスを使用してデータを取得する方法を示しています。 必要なサービス レイヤーはありません。 |

## <a name="related-topics"></a>関連トピック

* [顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
