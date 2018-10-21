---
title: リッチ プレゼンスのプログラミング
author: KevinAsgari
description: Xbox Live メンバーのオンライン プレゼンス状態を設定するコード例について説明します。
ms.assetid: 7e6e7b69-d7c3-42fa-bcc4-6d68947f6fdb
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リッチ プレゼンス
ms.localizationpriority: medium
ms.openlocfilehash: bd39074e67c58e20154083be66211dbefc9f782d
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5163299"
---
# <a name="programming-rich-presence"></a><span data-ttu-id="9ec4d-104">リッチ プレゼンスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="9ec4d-104">Programming Rich Presence</span></span>

<span data-ttu-id="9ec4d-105">リッチ プレゼンスは、プレイヤーの現在のアクティビティを他のプレイヤーに通知するための機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="9ec4d-105">Rich presence provides features for advertising a player's current activity to other players.</span></span> <span data-ttu-id="9ec4d-106">詳細については、「[リッチ プレゼンス文字列 - 概要](rich-presence-strings-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9ec4d-106">For more information, see [Rich Presence Strings: Overview](rich-presence-strings-overview.md).</span></span>

```cpp

XboxLiveContext^ xboxLiveContext = NULL;

// Set the XboxLiveContext for a user *once* otherwise you may encounter unpredictable behavior.
void OneTimeInit()
{
  // Get the XboxLiveContext.  This should only be done once per user after signing in.
  xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext(User::Users->GetAt(0));
}

void Example_PresenceService_SetPresenceAsync()
{
    // The config ID below is an example.
    // The real ID to use is defined when you set up the game on Xbox Development Portal.
    String^ aServiceConfigurationId = "C1BA92A9-0000-0000-0000-000000000000";

    PresenceData^ presenceData = ref new PresenceData(
        aServiceConfigurationId,
        "mainMenuPresence"
        );

    IAsyncAction^ setPresenceAction = xboxLiveContext->PresenceService->SetPresenceAsync(
        xboxLiveContext->User->XboxLiveId,
        true, // isUserActive
        presenceData    // richPresenceData is optional
        );

    create_task( setPresenceAction )
    .then([] ()
    {
        LogComment( L"SetPresenceAsync Done" );
    })
    .wait();
}
```
