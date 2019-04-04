---
ms.assetid: 76776b0f-3163-48c9-835b-3f4213968079
title: データ アクセス
description: このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。
ms.date: 11/13/2017
ms.topic: article
keywords: Windows 10, UWP, データ, データベース, リレーショナル, テーブル, sqlite
ms.localizationpriority: medium
ms.openlocfilehash: eb5adbdd3ae12d039d934e8d0cbe468ae5c1187c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583307"
---
# <a name="data-access"></a><span data-ttu-id="d6ae4-104">データ アクセス</span><span class="sxs-lookup"><span data-stu-id="d6ae4-104">Data access</span></span>

<span data-ttu-id="d6ae4-105">SQLite データベースを使用することで、ユーザーのデバイスにデータを格納できます。</span><span class="sxs-lookup"><span data-stu-id="d6ae4-105">You can store data on the user's device by using a SQLite database.</span></span> <span data-ttu-id="d6ae4-106">また、いずれのサービス レイヤーを使用しなくても、SQL Server データベースにアプリを直接接続できます。</span><span class="sxs-lookup"><span data-stu-id="d6ae4-106">You can also connect your app directly to a SQL Server database without having to use any sort of service layer.</span></span>

| <span data-ttu-id="d6ae4-107">トピック</span><span class="sxs-lookup"><span data-stu-id="d6ae4-107">Topic</span></span> | <span data-ttu-id="d6ae4-108">説明</span><span class="sxs-lookup"><span data-stu-id="d6ae4-108">Description</span></span>|
|-------|------------|
| [<span data-ttu-id="d6ae4-109">UWP アプリでの SQLite データベースの使用</span><span class="sxs-lookup"><span data-stu-id="d6ae4-109">Use a SQLite database in a UWP app</span></span>](sqlite-databases.md) | <span data-ttu-id="d6ae4-110">SQLite を使用して、ユーザー デバイス上の軽量なデータベースにデータを保存し、取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d6ae4-110">Shows you how to use SQLite to store and retrieve data in a light-weight database on the users device.</span></span> <span data-ttu-id="d6ae4-111">SQLite は、サーバーを使わない埋め込みデータベース エンジンです。</span><span class="sxs-lookup"><span data-stu-id="d6ae4-111">SQLite is a server-less, embedded database engine.</span></span> |
| [<span data-ttu-id="d6ae4-112">UWP アプリでの SQL Server データベースの使用</span><span class="sxs-lookup"><span data-stu-id="d6ae4-112">Use a SQL server database in a UWP app</span></span>](sql-server-databases.md) | <span data-ttu-id="d6ae4-113">[System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) 名前空間のクラスを使用して、SQL Server データベースに直接接続し、データを保存および取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d6ae4-113">Shows you how to connect directly to a SQL Server database and then store and retrieve data by using classes in the [System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) namespace.</span></span> <span data-ttu-id="d6ae4-114">必要なサービス レイヤーはありません。</span><span class="sxs-lookup"><span data-stu-id="d6ae4-114">No service layer required.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="d6ae4-115">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d6ae4-115">Related topics</span></span>

* [<span data-ttu-id="d6ae4-116">顧客注文データベースのサンプル</span><span class="sxs-lookup"><span data-stu-id="d6ae4-116">Customer Orders Database sample</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
