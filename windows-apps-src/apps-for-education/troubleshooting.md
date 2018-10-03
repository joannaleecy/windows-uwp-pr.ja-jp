---
Description: Troubleshoot Microsoft Take a Test events and errors with the event viewer.
title: イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。
author: PatrickFarley
ms.author: pafarley
ms.assetid: 9218e542-f520-4616-98fc-b113d5a08e0f
ms.date: 10/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: 3193525316d085e56244d6f03da99e3e07c6539f
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/02/2018
ms.locfileid: "4260207"
---
# <a name="troubleshoot-microsoft-take-a-test-with-the-event-viewer"></a><span data-ttu-id="7aef4-103">イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします</span><span class="sxs-lookup"><span data-stu-id="7aef4-103">Troubleshoot Microsoft Take a Test with the event viewer</span></span>

<span data-ttu-id="7aef4-104">イベント ビューアーを使用して、テストのイベントとエラーを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="7aef4-104">You can use the Event Viewer to view Take a Test events and errors.</span></span> <span data-ttu-id="7aef4-105">テストでは、ロックダウン要求を受け取ったとき、デバイスの登録が成功したとき、ロックダウン ポリシーが正常に適用されたときなどに、イベントがログに記録されます。</span><span class="sxs-lookup"><span data-stu-id="7aef4-105">Take a Test logs events when a lockdown request has been received, device enrollment has succeeded, lockdown policies were successfully applied, and more.</span></span>

<span data-ttu-id="7aef4-106">イベント ビューアーでイベントの表示を有効にするには:</span><span class="sxs-lookup"><span data-stu-id="7aef4-106">To enable viewing events in the Event Viewer:</span></span>
1. <span data-ttu-id="7aef4-107">次を開きます: </span><span class="sxs-lookup"><span data-stu-id="7aef4-107">Open the</span></span> `Event Viewer`
2. <span data-ttu-id="7aef4-108">次に移動します: </span><span class="sxs-lookup"><span data-stu-id="7aef4-108">Navigate to</span></span> `Applications and Services Logs > Microsoft > Windows > Management-SecureAssessment`
3. <span data-ttu-id="7aef4-109">`Operational` を右クリックして、次を選びます: </span><span class="sxs-lookup"><span data-stu-id="7aef4-109">Right-click `Operational` and select</span></span> `Enable Log`

<span data-ttu-id="7aef4-110">イベント ログを保存するには:</span><span class="sxs-lookup"><span data-stu-id="7aef4-110">To save the event logs:</span></span>
1. <span data-ttu-id="7aef4-111">次を右クリックします: </span><span class="sxs-lookup"><span data-stu-id="7aef4-111">Right-click</span></span> `Operational`
2. <span data-ttu-id="7aef4-112">次をクリックします: </span><span class="sxs-lookup"><span data-stu-id="7aef4-112">Click</span></span> `Save All Events As…`
