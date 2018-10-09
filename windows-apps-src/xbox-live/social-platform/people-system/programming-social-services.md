---
title: ソーシャル サービスのプログラミング
author: KevinAsgari
description: Xbox Live Social Manager API を使う方法のコード例を示します。
ms.assetid: 101d059a-e03f-472c-8300-800aa5730ee2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, social manager, 例
ms.localizationpriority: medium
ms.openlocfilehash: e20550e812cbd5d67c57381cde9c7910b20000e5
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4425223"
---
# <a name="programming-social-services"></a><span data-ttu-id="3c64e-104">ソーシャル サービスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="3c64e-104">Programming Social Services</span></span>

> [!NOTE]
> <span data-ttu-id="3c64e-105">この記事では、API の高度な使用方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3c64e-105">This article demonstrates advanced API usage.</span></span>  <span data-ttu-id="3c64e-106">まず最初に、開発が大幅に簡素化される [Social Manager API の概要](../intro-to-social-manager.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3c64e-106">As a starting point, please take a look at the [Introduction to the Social Manager API](../intro-to-social-manager.md) which significantly simplifies development.</span></span>  <span data-ttu-id="3c64e-107">Social Manager でサポートされていないシナリオが見つかった場合は、担当の DAM までご連絡ください。</span><span class="sxs-lookup"><span data-stu-id="3c64e-107">Please let your DAM know if you find an unsupported scenario in the Social Manager.</span></span>

<span data-ttu-id="3c64e-108">次のコード例では、Xbox Live とのソーシャル関係を取得する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3c64e-108">The following code example demonstrates how to retrieve a social relationship with Xbox Live.</span></span> <span data-ttu-id="3c64e-109">コード例は、システム上のすべてのユーザーのリストを生成し、最初のものを取得します。</span><span class="sxs-lookup"><span data-stu-id="3c64e-109">It generates a list of all users on the system and retrieves the first one.</span></span> <span data-ttu-id="3c64e-110">次に、ユーザーのソーシャル関係のすべてを取得します。</span><span class="sxs-lookup"><span data-stu-id="3c64e-110">Next, it retrieves all of that user's social relationships.</span></span> <span data-ttu-id="3c64e-111">最後に、これらの各関係のパブリック プロパティを表示します。</span><span class="sxs-lookup"><span data-stu-id="3c64e-111">Finally, it displays the public properties of each of those relationships.</span></span>

```cpp
XboxLiveContext^ xboxLiveContext = NULL;

// An XboxLiveContext for a user should be created only once, or you may encounter unpredictable behavior.
void OneTimeInit()
{
  // Get the XboxLiveContext.  This should only be done once per user after signing in.
  xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext(User::Users->GetAt(0));
}

void Example_SocialService_GetSocialRelationshipsAsync()
{
    // Generate a list of users on the system.
    // Create an XboxLiveContext from user 0 (the first one returned).
    // This user's authentication token will be used for service requests.
    XboxLiveContext^ xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext(User::Users->GetAt(0));

    // Asynchronously retrieve all social relationships from that context.
    auto asyncOp = xboxLiveContext->SocialService->GetSocialRelationshipsAsync();

    create_task( asyncOp )
    .then([](XboxSocialRelationshipResult^ result)
    {
        // For each social relationship of the specified user...
        for( XboxSocialRelationship^ xboxSocialRelationship : result->Items )
        {
            // ...display the public properties of the relationship.
            LogComment( xboxSocialRelationship->XboxUserId );
            LogComment( xboxSocialRelationship->IsFavorite.ToString() );
        }

    })
    .wait();
}
```
