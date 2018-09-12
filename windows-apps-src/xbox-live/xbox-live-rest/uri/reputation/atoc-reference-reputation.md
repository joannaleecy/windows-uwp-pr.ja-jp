---
title: 評判 Uri
assetID: d1cb76c0-86a4-8c51-19f6-5f223b517d46
permalink: en-us/docs/xboxlive/rest/atoc-reference-reputation.html
author: KevinAsgari
description: " 評判 Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b869f87760498dc6a2224809a42380f1b8f5930b
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881649"
---
# <a name="reputation-uris"></a><span data-ttu-id="31ad3-104">評判 Uri</span><span class="sxs-lookup"><span data-stu-id="31ad3-104">Reputation URIs</span></span>
 
<span data-ttu-id="31ad3-105">このセクションでは、 **Microsoft.Xbox.Services.Social.ReputationService**用の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="31ad3-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for the **Microsoft.Xbox.Services.Social.ReputationService**.</span></span> <span data-ttu-id="31ad3-106">評判 Uri ドメインは、reputation.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="31ad3-106">The domain for the reputation URIs is reputation.xboxlive.com.</span></span> <span data-ttu-id="31ad3-107">一般的な URI 形式がありますhttps://reputation.xboxlive.com/users/xuid(2533274790412952)/feedbackします。</span><span class="sxs-lookup"><span data-stu-id="31ad3-107">A typical URI representation might be https://reputation.xboxlive.com/users/xuid(2533274790412952)/feedback.</span></span> 
 
<span data-ttu-id="31ad3-108">評判サービスを使用して、フィードバック[Feedback (JSON)](../../json/json-feedback.md)、評判スコアを計算します。</span><span class="sxs-lookup"><span data-stu-id="31ad3-108">The reputation service uses feedback, as described in [Feedback (JSON)](../../json/json-feedback.md), to calculate a reputation score.</span></span> <span data-ttu-id="31ad3-109">このスコアは、ReputationOverall キーの下で、ユーザーの統計情報の領域に保存されます。</span><span class="sxs-lookup"><span data-stu-id="31ad3-109">This score is saved in the statistics area for the user under the key ReputationOverall.</span></span> <span data-ttu-id="31ad3-110">ユーザーの統計情報の取得について詳しくは、以下を参照してください。[取得 (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md)します。</span><span class="sxs-lookup"><span data-stu-id="31ad3-110">For more information about retrieving user statistics, see [GET (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md).</span></span> 
 
<span data-ttu-id="31ad3-111">すべてのプラットフォームでのゲームでは、評判サービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="31ad3-111">Games on all platforms can use the reputation service.</span></span>
 
<a id="ID4EMB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="31ad3-112">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="31ad3-112">In this section</span></span>

[<span data-ttu-id="31ad3-113">/users/xuid({xuid})/feedback</span><span class="sxs-lookup"><span data-stu-id="31ad3-113">/users/xuid({xuid})/feedback</span></span>](uri-reputationusersxuidfeedback.md)

<span data-ttu-id="31ad3-114">&nbsp;&nbsp;シェルを使用してではなく、ゲームでフィードバック オプションを追加したい場合に、タイトルから使われます。</span><span class="sxs-lookup"><span data-stu-id="31ad3-114">&nbsp;&nbsp;Used from your title if you desire to add a feedback option in your game, as opposed to using the shell.</span></span>

[<span data-ttu-id="31ad3-115">ユーザー/batchfeedback</span><span class="sxs-lookup"><span data-stu-id="31ad3-115">/users/batchfeedback</span></span>](uri-reputationusersbatchfeedback.md)

<span data-ttu-id="31ad3-116">&nbsp;&nbsp;タイトルのインターフェイスの外部のバッチ形式でフィードバックを送信するタイトルのサービスによって使用されます。</span><span class="sxs-lookup"><span data-stu-id="31ad3-116">&nbsp;&nbsp;Used by your title's service to send feedback in batch form outside of your title's interface.</span></span>

[<span data-ttu-id="31ad3-117">/users/me/resetreputation</span><span class="sxs-lookup"><span data-stu-id="31ad3-117">/users/me/resetreputation</span></span>](uri-usersmeresetreputation.md)

<span data-ttu-id="31ad3-118">&nbsp;&nbsp;現在のユーザーの評判スコアにアクセスするに執行チームを使用できます。</span><span class="sxs-lookup"><span data-stu-id="31ad3-118">&nbsp;&nbsp;Enables the Enforcement team to access the current user's Reputation scores.</span></span>

[<span data-ttu-id="31ad3-119">/users/xuid({xuid})/deleteuserdata</span><span class="sxs-lookup"><span data-stu-id="31ad3-119">/users/xuid({xuid})/deleteuserdata</span></span>](uri-usersxuiddeleteuserdata.md)

<span data-ttu-id="31ad3-120">&nbsp;&nbsp;テスト ユーザーの評判のデータを完全にリセットします。</span><span class="sxs-lookup"><span data-stu-id="31ad3-120">&nbsp;&nbsp;Completely resets the reputation data for a test user.</span></span> <span data-ttu-id="31ad3-121">テストのみです。</span><span class="sxs-lookup"><span data-stu-id="31ad3-121">For testing only.</span></span>

[<span data-ttu-id="31ad3-122">/users/xuid({xuid})/resetreputation</span><span class="sxs-lookup"><span data-stu-id="31ad3-122">/users/xuid({xuid})/resetreputation</span></span>](uri-usersxuidresetreputation.md)

<span data-ttu-id="31ad3-123">&nbsp;&nbsp;指定したユーザーの評判スコアにアクセスするために執行チームを使用できます。</span><span class="sxs-lookup"><span data-stu-id="31ad3-123">&nbsp;&nbsp;Enables the Enforcement team to access the specified user's Reputation scores.</span></span>
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="31ad3-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="31ad3-124">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="31ad3-125">Parent</span><span class="sxs-lookup"><span data-stu-id="31ad3-125">Parent</span></span> 

[<span data-ttu-id="31ad3-126">ユニバーサル リソース識別子 (URI) の参照</span><span class="sxs-lookup"><span data-stu-id="31ad3-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   