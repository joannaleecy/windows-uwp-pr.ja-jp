---
title: データ型の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
description: " データ型の概要"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 62932a921d51a988a5533d7ee08f4968bb67a29d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659657"
---
# <a name="data-type-overview"></a><span data-ttu-id="30f50-104">データ型の概要</span><span class="sxs-lookup"><span data-stu-id="30f50-104">Data Type Overview</span></span>
 
<span data-ttu-id="30f50-105">Xbox Live サービスには、さまざまな id と認証に関連するデータ型が使用されます。</span><span class="sxs-lookup"><span data-stu-id="30f50-105">Xbox Live Services uses a variety of data types related to identity and authentication.</span></span> <span data-ttu-id="30f50-106">このトピックでは、これらの種類の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="30f50-106">This topic provides an overview of those types.</span></span>
 
| <span data-ttu-id="30f50-107">種類</span><span class="sxs-lookup"><span data-stu-id="30f50-107">Type</span></span>| <span data-ttu-id="30f50-108">説明</span><span class="sxs-lookup"><span data-stu-id="30f50-108">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="30f50-109">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="30f50-109">gamertag</span></span>| <span data-ttu-id="30f50-110">ユーザーの一意な人間が判読できる画面名。</span><span class="sxs-lookup"><span data-stu-id="30f50-110">A unique, human-readable screen name for the user.</span></span>| 
| <span data-ttu-id="30f50-111">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="30f50-111">Player</span></span>| <span data-ttu-id="30f50-112">ユーザーの XUID とゲーマータグ、だけでなく、プレイヤーのインデックス、セッション (または「座席」) で、プレーヤーが、セッション、およびカスタム データの小さな blob にまだ参加しているかどうかを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="30f50-112">A JSON object containing the user's XUID and gamertag, as well the player's index in the session (or "seat"), whether the player is still participating in the session, and a small blob of custom data.</span></span>| 
| <span data-ttu-id="30f50-113">プロファイル</span><span class="sxs-lookup"><span data-stu-id="30f50-113">profile</span></span>| <span data-ttu-id="30f50-114">ユーザーはプロファイルの URI アドレスと、ユーザーのユーザーは、通常の HTTP メソッドを使用してアクセス ゲーマー、ゲーマータグ、XUID、具合のもおそらくなどに関する情報。</span><span class="sxs-lookup"><span data-stu-id="30f50-114">Information about the user accessed through profile URI addresses and HTTP methods, usually the user's UserSettings, but also possibly including gamercard, gamertag, XUID, and so on.</span></span>| 
| <span data-ttu-id="30f50-115">設定</span><span class="sxs-lookup"><span data-stu-id="30f50-115">setting</span></span>| <span data-ttu-id="30f50-116">UserSettings オブジェクトのタイトルに固有の設定の 1 つ。</span><span class="sxs-lookup"><span data-stu-id="30f50-116">One of the title-specific settings in a UserSettings object.</span></span>| 
| <span data-ttu-id="30f50-117">UserClaims</span><span class="sxs-lookup"><span data-stu-id="30f50-117">UserClaims</span></span>| <span data-ttu-id="30f50-118">ユーザーの XUID とゲーマータグを含む単純な JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="30f50-118">A simple JSON object containing the user's XUID and gamertag.</span></span>| 
| <span data-ttu-id="30f50-119">UserSettings</span><span class="sxs-lookup"><span data-stu-id="30f50-119">UserSettings</span></span>| <span data-ttu-id="30f50-120">タイトルに固有の設定や現在の認証済みユーザーの設定のコレクションを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="30f50-120">A JSON object containing a collection of title-specific settings or preferences for the current authenticated user.</span></span> <span data-ttu-id="30f50-121">ユーザーは、ゲーム内のアクティビティに関連する可能性がある任意のデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="30f50-121">UserSettings can contain arbitrary data, possibly related to in-game activity.</span></span>| 
| <span data-ttu-id="30f50-122">XUID</span><span class="sxs-lookup"><span data-stu-id="30f50-122">XUID</span></span>| <span data-ttu-id="30f50-123">ユーザーの Xbox ユーザー ID、一意の符号なし long 整数。</span><span class="sxs-lookup"><span data-stu-id="30f50-123">The user's Xbox User ID, a unique unsigned long integer.</span></span> <span data-ttu-id="30f50-124">人間が判読できるものではありません。</span><span class="sxs-lookup"><span data-stu-id="30f50-124">Not meant to be human-readable.</span></span>| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a><span data-ttu-id="30f50-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="30f50-125">See also</span></span>
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a><span data-ttu-id="30f50-126">Parent</span><span class="sxs-lookup"><span data-stu-id="30f50-126">Parent</span></span>  

[<span data-ttu-id="30f50-127">その他の参照</span><span class="sxs-lookup"><span data-stu-id="30f50-127">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a><span data-ttu-id="30f50-128">参照[Player (JSON)](../json/json-player.md)</span><span class="sxs-lookup"><span data-stu-id="30f50-128">Reference  [Player (JSON)](../json/json-player.md)</span></span>

 [<span data-ttu-id="30f50-129">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="30f50-129">UserClaims (JSON)</span></span>](../json/json-userclaims.md)

 [<span data-ttu-id="30f50-130">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="30f50-130">UserSettings (JSON)</span></span>](../json/json-usersettings.md)

   