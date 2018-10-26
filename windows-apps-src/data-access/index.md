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
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5621678"
---
# <a name="data-access"></a><span data-ttu-id="34382-104">データ アクセス</span><span class="sxs-lookup"><span data-stu-id="34382-104">Data access</span></span>

<span data-ttu-id="34382-105">SQLite データベースを使用して、ユーザーのデバイスでデータを格納することができます。</span><span class="sxs-lookup"><span data-stu-id="34382-105">You can store data on the user's device by using a SQLite database.</span></span> <span data-ttu-id="34382-106">あらゆる種類のサービスのレイヤーを使用することがなく、アプリを SQL Server データベースに直接接続することもことができます。</span><span class="sxs-lookup"><span data-stu-id="34382-106">You can also connect your app directly to a SQL Server database without having to use any sort of service layer.</span></span>

| <span data-ttu-id="34382-107">トピック</span><span class="sxs-lookup"><span data-stu-id="34382-107">Topic</span></span> | <span data-ttu-id="34382-108">説明</span><span class="sxs-lookup"><span data-stu-id="34382-108">Description</span></span>|
|-------|------------|
| [<span data-ttu-id="34382-109">UWP アプリでの SQLite データベースの使用</span><span class="sxs-lookup"><span data-stu-id="34382-109">Use a SQLite database in a UWP app</span></span>](sqlite-databases.md) | <span data-ttu-id="34382-110">SQLite を使用して格納し、ユーザー デバイス上の軽量なデータベースにデータを取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="34382-110">Shows you how to use SQLite to store and retrieve data in a light-weight database on the users device.</span></span> <span data-ttu-id="34382-111">SQLite は、サーバーを使わない埋め込みデータベース エンジンです。</span><span class="sxs-lookup"><span data-stu-id="34382-111">SQLite is a server-less, embedded database engine.</span></span> |
| [<span data-ttu-id="34382-112">UWP アプリでの SQL server データベースを使用します。</span><span class="sxs-lookup"><span data-stu-id="34382-112">Use a SQL server database in a UWP app</span></span>](sql-server-databases.md) | <span data-ttu-id="34382-113">SQL Server データベースに直接接続し、保存し、および[System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx)名前空間のクラスを使用してデータを取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="34382-113">Shows you how to connect directly to a SQL Server database and then store and retrieve data by using classes in the [System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) namespace.</span></span> <span data-ttu-id="34382-114">必要なサービス レイヤーはありません。</span><span class="sxs-lookup"><span data-stu-id="34382-114">No service layer required.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="34382-115">関連トピック</span><span class="sxs-lookup"><span data-stu-id="34382-115">Related topics</span></span>

* [<span data-ttu-id="34382-116">顧客注文データベースのサンプル</span><span class="sxs-lookup"><span data-stu-id="34382-116">Customer Orders Database sample</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
