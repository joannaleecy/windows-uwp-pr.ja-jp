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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57614007"
---
# <a name="reputation-uris"></a><span data-ttu-id="90c23-104">評判 URI</span><span class="sxs-lookup"><span data-stu-id="90c23-104">Reputation URIs</span></span>
 
<span data-ttu-id="90c23-105">このセクションでは、Universal Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト転送プロトコル (HTTP) のメソッドに関する詳細情報を提供の Xbox Live サービスから、 **Microsoft.Xbox.Services.Social.ReputationService**.</span><span class="sxs-lookup"><span data-stu-id="90c23-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the **Microsoft.Xbox.Services.Social.ReputationService**.</span></span> <span data-ttu-id="90c23-106">Uri の評判のドメインとは、reputation.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="90c23-106">The domain for the reputation URIs is reputation.xboxlive.com.</span></span> <span data-ttu-id="90c23-107">一般的な URI 形式があります https://reputation.xboxlive.com/users/xuid(2533274790412952)/feedbackします。</span><span class="sxs-lookup"><span data-stu-id="90c23-107">A typical URI representation might be https://reputation.xboxlive.com/users/xuid(2533274790412952)/feedback.</span></span> 
 
<span data-ttu-id="90c23-108">」の説明に従って、reputation service は、フィードバックを使用して[フィードバック (JSON)](../../json/json-feedback.md)、評価スコアを計算します。</span><span class="sxs-lookup"><span data-stu-id="90c23-108">The reputation service uses feedback, as described in [Feedback (JSON)](../../json/json-feedback.md), to calculate a reputation score.</span></span> <span data-ttu-id="90c23-109">このスコアは、ReputationOverall キー下のユーザーの統計情報の領域に保存されます。</span><span class="sxs-lookup"><span data-stu-id="90c23-109">This score is saved in the statistics area for the user under the key ReputationOverall.</span></span> <span data-ttu-id="90c23-110">ユーザーの統計情報を取得する方法についての詳細については、次を参照してください。[取得 (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md)します。</span><span class="sxs-lookup"><span data-stu-id="90c23-110">For more information about retrieving user statistics, see [GET (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md).</span></span> 
 
<span data-ttu-id="90c23-111">すべてのプラットフォームでのゲームでは、評価サービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="90c23-111">Games on all platforms can use the reputation service.</span></span>
 
<a id="ID4EMB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="90c23-112">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="90c23-112">In this section</span></span>

[<span data-ttu-id="90c23-113">/users/xuid({xuid})/feedback</span><span class="sxs-lookup"><span data-stu-id="90c23-113">/users/xuid({xuid})/feedback</span></span>](uri-reputationusersxuidfeedback.md)

<span data-ttu-id="90c23-114">&nbsp;&nbsp;シェルを使用するのではなく、ゲームのフィードバックのオプションを追加したい場合、タイトルから使用されます。</span><span class="sxs-lookup"><span data-stu-id="90c23-114">&nbsp;&nbsp;Used from your title if you desire to add a feedback option in your game, as opposed to using the shell.</span></span>

[<span data-ttu-id="90c23-115">/users/batchfeedback</span><span class="sxs-lookup"><span data-stu-id="90c23-115">/users/batchfeedback</span></span>](uri-reputationusersbatchfeedback.md)

<span data-ttu-id="90c23-116">&nbsp;&nbsp;タイトルのインターフェイスの外部でのバッチの形式でフィードバックを送信するタイトルのサービスで使用します。</span><span class="sxs-lookup"><span data-stu-id="90c23-116">&nbsp;&nbsp;Used by your title's service to send feedback in batch form outside of your title's interface.</span></span>

[<span data-ttu-id="90c23-117">/users/me/resetreputation</span><span class="sxs-lookup"><span data-stu-id="90c23-117">/users/me/resetreputation</span></span>](uri-usersmeresetreputation.md)

<span data-ttu-id="90c23-118">&nbsp;&nbsp;現在のユーザーの評価スコアにアクセスする強制チームを有効にします。</span><span class="sxs-lookup"><span data-stu-id="90c23-118">&nbsp;&nbsp;Enables the Enforcement team to access the current user's Reputation scores.</span></span>

[<span data-ttu-id="90c23-119">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="90c23-119">/users/xuid({xuid})/deleteuserdata</span></span>](uri-usersxuiddeleteuserdata.md)

<span data-ttu-id="90c23-120">&nbsp;&nbsp;テスト ユーザーの評価データを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="90c23-120">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="90c23-121">テスト目的専用です。</span><span class="sxs-lookup"><span data-stu-id="90c23-121">For testing only.</span></span>

[<span data-ttu-id="90c23-122">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="90c23-122">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

<span data-ttu-id="90c23-123">&nbsp;&nbsp;指定したユーザーの評価スコアにアクセスする強制チームを有効にします。</span><span class="sxs-lookup"><span data-stu-id="90c23-123">&nbsp;&nbsp;Enables the Enforcement team to access the specified user's Reputation scores.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="90c23-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="90c23-124">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="90c23-125">Parent</span><span class="sxs-lookup"><span data-stu-id="90c23-125">Parent</span></span> 

[<span data-ttu-id="90c23-126">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="90c23-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   