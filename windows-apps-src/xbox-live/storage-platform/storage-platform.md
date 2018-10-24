---
title: Xbox Live ストレージ プラットフォーム
author: KevinAsgari
description: 接続ストレージとタイトル ストレージを含む、Xbox Live ストレージ プラットフォームについて説明します。
ms.assetid: 3c92549c-65fd-4d26-a693-3aded8bae498
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ecdf1bb3da9f2cd92e95976e07bbc2fd58a51800
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5439252"
---
# <a name="xbox-live-storage-platform---connected-storage-title-storage"></a><span data-ttu-id="bfcb0-104">Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ</span><span class="sxs-lookup"><span data-stu-id="bfcb0-104">Xbox Live Storage Platform - Connected Storage, Title Storage</span></span>

<span data-ttu-id="bfcb0-105">Xbox Live では、発行元がグローバル タイトル データとプレイヤー固有のデータをクラウドに保存できます。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-105">Xbox Live enables publishers to store global title data and player specific data in the cloud.</span></span>

## <a name="in-this-section"></a><span data-ttu-id="bfcb0-106">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="bfcb0-106">In this section</span></span>

<span data-ttu-id="bfcb0-107">[接続ストレージ](connected-storage/connected-storage-overview.md)ユーザーごとの接続ストレージ API を使用して格納されたデータは、ユーザー用に PC と複数の Xbox One 本体に自動的にローミングされ、オフラインでも使用できます。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-107">[Connected Storage](connected-storage/connected-storage-overview.md) Data stored by using the per-user Connected Storage API automatically roams for users across PC and multiple Xbox One consoles, and is also available for use offline.</span></span> <span data-ttu-id="bfcb0-108">このサービスを使用すると、デバイスを切り替えた後、タイトルを再起動するときにゲームプレイをスムーズに続行できます。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-108">Use this service to allow gameplay to continue smoothly when restarting a title after switching between devices.</span></span> <span data-ttu-id="bfcb0-109">接続ストレージ サービスを使用して、インベントリ、ゲームの状態、ゲーム内の現在位置などの進行状況のデータを頻繁に保存してください。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-109">You should use the Connected Storage service to frequently save progress data like inventory, game state, and current location in game.</span></span> <span data-ttu-id="bfcb0-110">接続ストレージ サービスは、よりフォールト トレラントなクラウド ストレージ サービスであり、ネットワークや電源障害の影響を受けにくくなっています。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-110">The Connected Storage service is the more fault tolerant cloud storage service, and is less susceptible to network and power failure.</span></span>

<span data-ttu-id="bfcb0-111">[Xbox Live タイトル ストレージ](xbox-live-title-storage/xbox-live-title-storage.md) Xbox Live タイトル ストレージ サービスでは、ゲーム データやタイトル アセットをクラウドに格納して共有できます。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-111">[Xbox Live Title Storage](xbox-live-title-storage/xbox-live-title-storage.md) The Xbox Live Title Storage service provides a way to store and share game data and title assets in the cloud.</span></span> <span data-ttu-id="bfcb0-112">どのプラットフォームで実行されるゲームでも、これをオンラインで使用できます。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-112">Games running on all platforms can use this online.</span></span> <span data-ttu-id="bfcb0-113">このサービスによって、コンシューマー用のデータの可視性をより細かく制御できるようになるだけでなく、ユーザーごとのデータに加えてタイトルごとのグローバル データの可視性も向上します。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-113">This service gives more control over data visibility for the consumer as well as global per title data in addition to per-user data.</span></span> <span data-ttu-id="bfcb0-114">タイトル ストレージは、プレイヤーの統計、プレイヤーのランキング、ロックできないアートワークなどのタイトル アセットを格納するのに便利です。</span><span class="sxs-lookup"><span data-stu-id="bfcb0-114">Title Storage is great for storing player statistics, player rankings and title assets like unlockable artwork, and new maps.</span></span>