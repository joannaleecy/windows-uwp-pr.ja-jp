---
title: 評判 URI
assetID: d1cb76c0-86a4-8c51-19f6-5f223b517d46
permalink: en-us/docs/xboxlive/rest/atoc-reference-reputation.html
description: " 評判 URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 93d6d6e6acfd8fa39bd9d26c87ed99362d2c88d6
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8780891"
---
# <a name="reputation-uris"></a><span data-ttu-id="2a477-104">評判 URI</span><span class="sxs-lookup"><span data-stu-id="2a477-104">Reputation URIs</span></span>
 
<span data-ttu-id="2a477-105">このセクションでは、 **Microsoft.Xbox.Services.Social.ReputationService**用の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="2a477-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the **Microsoft.Xbox.Services.Social.ReputationService**.</span></span> <span data-ttu-id="2a477-106">評判 Uri ドメインは、reputation.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="2a477-106">The domain for the reputation URIs is reputation.xboxlive.com.</span></span> <span data-ttu-id="2a477-107">一般的な URI 形式がありますhttps://reputation.xboxlive.com/users/xuid(2533274790412952)/feedbackします。</span><span class="sxs-lookup"><span data-stu-id="2a477-107">A typical URI representation might be https://reputation.xboxlive.com/users/xuid(2533274790412952)/feedback.</span></span> 
 
<span data-ttu-id="2a477-108">評判サービスで使用してフィードバックを[フィードバック (JSON)](../../json/json-feedback.md)、評判スコアを計算します。</span><span class="sxs-lookup"><span data-stu-id="2a477-108">The reputation service uses feedback, as described in [Feedback (JSON)](../../json/json-feedback.md), to calculate a reputation score.</span></span> <span data-ttu-id="2a477-109">このスコアは、ReputationOverall キーの下で、ユーザーの統計情報の領域に保存されます。</span><span class="sxs-lookup"><span data-stu-id="2a477-109">This score is saved in the statistics area for the user under the key ReputationOverall.</span></span> <span data-ttu-id="2a477-110">ユーザーの統計情報の取得について詳しくは、以下を参照してください。[を取得する (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md)します。</span><span class="sxs-lookup"><span data-stu-id="2a477-110">For more information about retrieving user statistics, see [GET (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md).</span></span> 
 
<span data-ttu-id="2a477-111">すべてのプラットフォームでのゲームでは、評判サービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2a477-111">Games on all platforms can use the reputation service.</span></span>
 
<a id="ID4EMB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="2a477-112">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="2a477-112">In this section</span></span>

[<span data-ttu-id="2a477-113">/users/xuid({xuid})/feedback</span><span class="sxs-lookup"><span data-stu-id="2a477-113">/users/xuid({xuid})/feedback</span></span>](uri-reputationusersxuidfeedback.md)

<span data-ttu-id="2a477-114">&nbsp;&nbsp;シェルを使用するのではなく、ゲームでフィードバック オプションを追加したい場合は、タイトルから使用されます。</span><span class="sxs-lookup"><span data-stu-id="2a477-114">&nbsp;&nbsp;Used from your title if you desire to add a feedback option in your game, as opposed to using the shell.</span></span>

[<span data-ttu-id="2a477-115">/users/batchfeedback</span><span class="sxs-lookup"><span data-stu-id="2a477-115">/users/batchfeedback</span></span>](uri-reputationusersbatchfeedback.md)

<span data-ttu-id="2a477-116">&nbsp;&nbsp;タイトルのサービスによってタイトルのインターフェイスの外部のバッチ形式でフィードバックを送信するために使用します。</span><span class="sxs-lookup"><span data-stu-id="2a477-116">&nbsp;&nbsp;Used by your title's service to send feedback in batch form outside of your title's interface.</span></span>

[<span data-ttu-id="2a477-117">/users/me/resetreputation</span><span class="sxs-lookup"><span data-stu-id="2a477-117">/users/me/resetreputation</span></span>](uri-usersmeresetreputation.md)

<span data-ttu-id="2a477-118">&nbsp;&nbsp;現在のユーザーの評判スコアにアクセスするに執行チームを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2a477-118">&nbsp;&nbsp;Enables the Enforcement team to access the current user's Reputation scores.</span></span>

[<span data-ttu-id="2a477-119">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="2a477-119">/users/xuid({xuid})/deleteuserdata</span></span>](uri-usersxuiddeleteuserdata.md)

<span data-ttu-id="2a477-120">&nbsp;&nbsp;テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="2a477-120">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="2a477-121">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="2a477-121">For testing only.</span></span>

[<span data-ttu-id="2a477-122">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="2a477-122">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

<span data-ttu-id="2a477-123">&nbsp;&nbsp;指定したユーザーの評判スコアにアクセスするに執行チームを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2a477-123">&nbsp;&nbsp;Enables the Enforcement team to access the specified user's Reputation scores.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="2a477-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="2a477-124">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2a477-125">Parent</span><span class="sxs-lookup"><span data-stu-id="2a477-125">Parent</span></span> 

[<span data-ttu-id="2a477-126">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="2a477-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   