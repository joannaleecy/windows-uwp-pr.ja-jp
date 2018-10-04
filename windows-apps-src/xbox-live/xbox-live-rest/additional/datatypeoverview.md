---
title: データ型の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
author: KevinAsgari
description: " データ型の概要"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9340f4adb83932ef2c48aba271367e7faab645c3
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4353219"
---
# <a name="data-type-overview"></a><span data-ttu-id="19e4f-104">データ型の概要</span><span class="sxs-lookup"><span data-stu-id="19e4f-104">Data Type Overview</span></span>
 
<span data-ttu-id="19e4f-105">Xbox Live サービスは、さまざまな id と認証に関連するデータ型を使用します。</span><span class="sxs-lookup"><span data-stu-id="19e4f-105">Xbox Live Services uses a variety of data types related to identity and authentication.</span></span> <span data-ttu-id="19e4f-106">このトピックでは、それらの型の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="19e4f-106">This topic provides an overview of those types.</span></span>
 
| <span data-ttu-id="19e4f-107">種類</span><span class="sxs-lookup"><span data-stu-id="19e4f-107">Type</span></span>| <span data-ttu-id="19e4f-108">説明</span><span class="sxs-lookup"><span data-stu-id="19e4f-108">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="19e4f-109">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="19e4f-109">gamertag</span></span>| <span data-ttu-id="19e4f-110">ユーザーの人間が判読できる一意の画面の名前。</span><span class="sxs-lookup"><span data-stu-id="19e4f-110">A unique, human-readable screen name for the user.</span></span>| 
| <span data-ttu-id="19e4f-111">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="19e4f-111">Player</span></span>| <span data-ttu-id="19e4f-112">ユーザーの XUID と、プレイヤーが、セッションとカスタム データの小さな blob にまだ参加しているかどうか、セッション (または「シート」) に、プレイヤーのインデックスを適切にゲーマータグを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="19e4f-112">A JSON object containing the user's XUID and gamertag, as well the player's index in the session (or "seat"), whether the player is still participating in the session, and a small blob of custom data.</span></span>| 
| <span data-ttu-id="19e4f-113">profile</span><span class="sxs-lookup"><span data-stu-id="19e4f-113">profile</span></span>| <span data-ttu-id="19e4f-114">ユーザー プロファイルの URI アドレスと HTTP メソッドでは、通常、ユーザーの UserSettings、を通じてアクセスが、ゲーマー カード、ゲーマータグ、XUID などの可能性もなどについて説明します。</span><span class="sxs-lookup"><span data-stu-id="19e4f-114">Information about the user accessed through profile URI addresses and HTTP methods, usually the user's UserSettings, but also possibly including gamercard, gamertag, XUID, and so on.</span></span>| 
| <span data-ttu-id="19e4f-115">設定</span><span class="sxs-lookup"><span data-stu-id="19e4f-115">setting</span></span>| <span data-ttu-id="19e4f-116">UserSettings オブジェクトでタイトルに固有の設定のいずれか。</span><span class="sxs-lookup"><span data-stu-id="19e4f-116">One of the title-specific settings in a UserSettings object.</span></span>| 
| <span data-ttu-id="19e4f-117">UserClaims</span><span class="sxs-lookup"><span data-stu-id="19e4f-117">UserClaims</span></span>| <span data-ttu-id="19e4f-118">ユーザーの XUID とゲーマータグを含むシンプルな JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="19e4f-118">A simple JSON object containing the user's XUID and gamertag.</span></span>| 
| <span data-ttu-id="19e4f-119">UserSettings</span><span class="sxs-lookup"><span data-stu-id="19e4f-119">UserSettings</span></span>| <span data-ttu-id="19e4f-120">タイトルに固有の設定、または現在の認証されたユーザーの基本設定のコレクションを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="19e4f-120">A JSON object containing a collection of title-specific settings or preferences for the current authenticated user.</span></span> <span data-ttu-id="19e4f-121">UserSettings には、ゲーム内のアクティビティに関連する可能性があります、任意のデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="19e4f-121">UserSettings can contain arbitrary data, possibly related to in-game activity.</span></span>| 
| <span data-ttu-id="19e4f-122">XUID</span><span class="sxs-lookup"><span data-stu-id="19e4f-122">XUID</span></span>| <span data-ttu-id="19e4f-123">ユーザーの Xbox ユーザー ID、ユニークな署名されていない長の整数です。</span><span class="sxs-lookup"><span data-stu-id="19e4f-123">The user's Xbox User ID, a unique unsigned long integer.</span></span> <span data-ttu-id="19e4f-124">人間が判読できるものではありません。</span><span class="sxs-lookup"><span data-stu-id="19e4f-124">Not meant to be human-readable.</span></span>| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a><span data-ttu-id="19e4f-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="19e4f-125">See also</span></span>
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a><span data-ttu-id="19e4f-126">Parent</span><span class="sxs-lookup"><span data-stu-id="19e4f-126">Parent</span></span>  

[<span data-ttu-id="19e4f-127">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="19e4f-127">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a><span data-ttu-id="19e4f-128">参照[Player (JSON)](../json/json-player.md)</span><span class="sxs-lookup"><span data-stu-id="19e4f-128">Reference  [Player (JSON)](../json/json-player.md)</span></span>

 [<span data-ttu-id="19e4f-129">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="19e4f-129">UserClaims (JSON)</span></span>](../json/json-userclaims.md)

 [<span data-ttu-id="19e4f-130">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="19e4f-130">UserSettings (JSON)</span></span>](../json/json-usersettings.md)

   