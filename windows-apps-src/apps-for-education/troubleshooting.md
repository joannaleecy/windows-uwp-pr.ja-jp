---
Description: Troubleshoot Microsoft Take a Test events and errors with the event viewer.
title: イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。
author: PatrickFarley
ms.author: pafarley
ms.assetid: 9218e542-f520-4616-98fc-b113d5a08e0f
ms.date: 10/06/2017
ms.topic: article
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: eaf4c8e2641359e6d9a92444f66a1b6d4e5e5881
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7563438"
---
# <a name="troubleshoot-microsoft-take-a-test-with-the-event-viewer"></a><span data-ttu-id="70211-103">イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします</span><span class="sxs-lookup"><span data-stu-id="70211-103">Troubleshoot Microsoft Take a Test with the event viewer</span></span>

<span data-ttu-id="70211-104">イベント ビューアーを使用して、テストのイベントとエラーを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="70211-104">You can use the Event Viewer to view Take a Test events and errors.</span></span> <span data-ttu-id="70211-105">テストでは、ロックダウン要求を受け取ったとき、デバイスの登録が成功したとき、ロックダウン ポリシーが正常に適用されたときなどに、イベントがログに記録されます。</span><span class="sxs-lookup"><span data-stu-id="70211-105">Take a Test logs events when a lockdown request has been received, device enrollment has succeeded, lockdown policies were successfully applied, and more.</span></span>

<span data-ttu-id="70211-106">イベント ビューアーでイベントの表示を有効にするには:</span><span class="sxs-lookup"><span data-stu-id="70211-106">To enable viewing events in the Event Viewer:</span></span>
1. <span data-ttu-id="70211-107">次を開きます: </span><span class="sxs-lookup"><span data-stu-id="70211-107">Open the</span></span> `Event Viewer`
2. <span data-ttu-id="70211-108">次に移動します: </span><span class="sxs-lookup"><span data-stu-id="70211-108">Navigate to</span></span> `Applications and Services Logs > Microsoft > Windows > Management-SecureAssessment`
3. <span data-ttu-id="70211-109">`Operational` を右クリックして、次を選びます: </span><span class="sxs-lookup"><span data-stu-id="70211-109">Right-click `Operational` and select</span></span> `Enable Log`

<span data-ttu-id="70211-110">イベント ログを保存するには:</span><span class="sxs-lookup"><span data-stu-id="70211-110">To save the event logs:</span></span>
1. <span data-ttu-id="70211-111">次を右クリックします: </span><span class="sxs-lookup"><span data-stu-id="70211-111">Right-click</span></span> `Operational`
2. <span data-ttu-id="70211-112">次をクリックします: </span><span class="sxs-lookup"><span data-stu-id="70211-112">Click</span></span> `Save All Events As…`
