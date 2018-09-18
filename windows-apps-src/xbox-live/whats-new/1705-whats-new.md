---
title: Xbox Live API の新規事項 - May 2017
author: KevinAsgari
description: Xbox Live API の新規事項 - May 2017
ms.assetid: ''
ms.author: kevinasg
ms.date: 04/27/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 新規事項, may 2017
ms.localizationpriority: medium
ms.openlocfilehash: 97de20b2d4fb384139b606003c800516151502d3
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4016483"
---
# <a name="whats-new-for-the-xbox-live-apis---may-2017"></a><span data-ttu-id="de55e-104">Xbox Live API の新規事項 - May 2017</span><span class="sxs-lookup"><span data-stu-id="de55e-104">What's new for the Xbox Live APIs - May 2017</span></span>

<span data-ttu-id="de55e-105">April 2017 リリースで追加された内容については、「[新規事項 - April 2017](1704-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="de55e-105">Please see the [What's New - April 2017](1704-whats-new.md) article for what was added in the April 2017 release.</span></span>

<span data-ttu-id="de55e-106">[GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="de55e-106">You can also check the [GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) to see all of the recent code changes to the Xbox Live APIs.</span></span>

## <a name="xbox-services-apis"></a><span data-ttu-id="de55e-107">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="de55e-107">Xbox Services APIs</span></span>

### <a name="multiplayer"></a><span data-ttu-id="de55e-108">マルチプレイヤー</span><span class="sxs-lookup"><span data-stu-id="de55e-108">Multiplayer</span></span>

* <span data-ttu-id="de55e-109">アクティビティ ハンドルと検索ハンドルの照会の応答にカスタム セッション プロパティが含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="de55e-109">Querying activity handles and search handles now includes the custom session properties in the response.</span></span>

### <a name="bug-fixes"></a><span data-ttu-id="de55e-110">バグ修正</span><span class="sxs-lookup"><span data-stu-id="de55e-110">Bug fixes</span></span>

* <span data-ttu-id="de55e-111">有効な HTTP エラー コードではなく "bad json" が返されるバグを修正しました。</span><span class="sxs-lookup"><span data-stu-id="de55e-111">Fixed "bad json" being returned instead of a valid HTTP error code.</span></span>
