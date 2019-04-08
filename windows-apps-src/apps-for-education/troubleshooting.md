---
Description: イベント ビューアーを使用して、Microsoft テストのイベントとエラーをトラブルシューティングします。
title: イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします。
ms.assetid: 9218e542-f520-4616-98fc-b113d5a08e0f
ms.date: 10/06/2017
ms.topic: article
keywords: windows 10, uwp, 教育
ms.localizationpriority: medium
ms.openlocfilehash: 2f4bdcf45c7dd37dd540a666d99b5fa2fd2d49f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598477"
---
# <a name="troubleshoot-microsoft-take-a-test-with-the-event-viewer"></a><span data-ttu-id="9572d-104">イベント ビューアーを使用して、Microsoft テストをトラブルシューティングします</span><span class="sxs-lookup"><span data-stu-id="9572d-104">Troubleshoot Microsoft Take a Test with the event viewer</span></span>

<span data-ttu-id="9572d-105">イベント ビューアーを使用して、テストのイベントとエラーを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="9572d-105">You can use the Event Viewer to view Take a Test events and errors.</span></span> <span data-ttu-id="9572d-106">テストでは、ロックダウン要求を受け取ったとき、デバイスの登録が成功したとき、ロックダウン ポリシーが正常に適用されたときなどに、イベントがログに記録されます。</span><span class="sxs-lookup"><span data-stu-id="9572d-106">Take a Test logs events when a lockdown request has been received, device enrollment has succeeded, lockdown policies were successfully applied, and more.</span></span>

<span data-ttu-id="9572d-107">イベント ビューアーでイベントの表示を有効にするには:</span><span class="sxs-lookup"><span data-stu-id="9572d-107">To enable viewing events in the Event Viewer:</span></span>
1. <span data-ttu-id="9572d-108">開いている、 `Event Viewer`</span><span class="sxs-lookup"><span data-stu-id="9572d-108">Open the `Event Viewer`</span></span>
2. <span data-ttu-id="9572d-109">移動します `Applications and Services Logs > Microsoft > Windows > Management-SecureAssessment`</span><span class="sxs-lookup"><span data-stu-id="9572d-109">Navigate to `Applications and Services Logs > Microsoft > Windows > Management-SecureAssessment`</span></span>
3. <span data-ttu-id="9572d-110">右クリックして`Operational`し選択します `Enable Log`</span><span class="sxs-lookup"><span data-stu-id="9572d-110">Right-click `Operational` and select `Enable Log`</span></span>

<span data-ttu-id="9572d-111">イベント ログを保存するには:</span><span class="sxs-lookup"><span data-stu-id="9572d-111">To save the event logs:</span></span>
1. <span data-ttu-id="9572d-112">右クリックします。 `Operational`</span><span class="sxs-lookup"><span data-stu-id="9572d-112">Right-click `Operational`</span></span>
2. <span data-ttu-id="9572d-113">をクリックします。 `Save All Events As…`</span><span class="sxs-lookup"><span data-stu-id="9572d-113">Click `Save All Events As…`</span></span>
