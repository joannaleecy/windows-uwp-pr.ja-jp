---
ms.assetid: 76776b0f-3163-48c9-835b-3f4213968079
title: データ アクセス
description: このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。
ms.date: 11/13/2017
ms.topic: article
keywords: Windows 10, UWP, データ, データベース, リレーショナル, テーブル, sqlite
ms.localizationpriority: medium
ms.openlocfilehash: eb5adbdd3ae12d039d934e8d0cbe468ae5c1187c
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8466781"
---
# <a name="data-access"></a>データ アクセス

SQLite データベースを使用して、ユーザーのデバイスでデータを格納することができます。 あらゆる種類のサービスのレイヤーを使用することがなくアプリを SQL Server データベースに直接接続することもことができます。

| トピック | 説明|
|-------|------------|
| [UWP アプリでの SQLite データベースの使用](sqlite-databases.md) | SQLite を使用して格納し、ユーザー デバイス上の軽量なデータベースにデータを取得する方法を示します。 SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 |
| [UWP アプリで、SQL server データベースを使用します。](sql-server-databases.md) | SQL Server データベースに直接接続し、保存し、および[System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx)名前空間のクラスを使用してデータを取得する方法を示しています。 必要なサービス レイヤーはありません。 |

## <a name="related-topics"></a>関連トピック

* [顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
