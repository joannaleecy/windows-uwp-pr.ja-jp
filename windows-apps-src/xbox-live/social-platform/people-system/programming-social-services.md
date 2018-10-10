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
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4498363"
---
# <a name="programming-social-services"></a>ソーシャル サービスのプログラミング

> [!NOTE]
> この記事では、API の高度な使用方法を示します。  まず最初に、開発が大幅に簡素化される [Social Manager API の概要](../intro-to-social-manager.md)を参照してください。  Social Manager でサポートされていないシナリオが見つかった場合は、担当の DAM までご連絡ください。

次のコード例では、Xbox Live とのソーシャル関係を取得する方法を示します。 コード例は、システム上のすべてのユーザーのリストを生成し、最初のものを取得します。 次に、ユーザーのソーシャル関係のすべてを取得します。 最後に、これらの各関係のパブリック プロパティを表示します。

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
