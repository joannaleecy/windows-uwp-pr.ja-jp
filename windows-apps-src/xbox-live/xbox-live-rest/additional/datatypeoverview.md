---
title: データの種類の概要
assetID: c154a6fa-e7b2-4652-f6fc-f946f74480e9
permalink: en-us/docs/xboxlive/rest/datatypeoverview.html
author: KevinAsgari
description: " データの種類の概要"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9340f4adb83932ef2c48aba271367e7faab645c3
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3934272"
---
# <a name="data-type-overview"></a><span data-ttu-id="8adc2-104">データの種類の概要</span><span class="sxs-lookup"><span data-stu-id="8adc2-104">Data Type Overview</span></span>
 
<span data-ttu-id="8adc2-105">Xbox Live サービスは、さまざまな id と認証に関連するデータ型を使用します。</span><span class="sxs-lookup"><span data-stu-id="8adc2-105">Xbox Live Services uses a variety of data types related to identity and authentication.</span></span> <span data-ttu-id="8adc2-106">このトピックでは、それらの型の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="8adc2-106">This topic provides an overview of those types.</span></span>
 
| <span data-ttu-id="8adc2-107">種類</span><span class="sxs-lookup"><span data-stu-id="8adc2-107">Type</span></span>| <span data-ttu-id="8adc2-108">説明</span><span class="sxs-lookup"><span data-stu-id="8adc2-108">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="8adc2-109">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="8adc2-109">gamertag</span></span>| <span data-ttu-id="8adc2-110">ユーザーの人間が判読できる一意の画面の名前。</span><span class="sxs-lookup"><span data-stu-id="8adc2-110">A unique, human-readable screen name for the user.</span></span>| 
| <span data-ttu-id="8adc2-111">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="8adc2-111">Player</span></span>| <span data-ttu-id="8adc2-112">ユーザーの XUID と、プレイヤーがまだセッションとカスタム データの小さな blob に参加しているかどうか、セッション (または「シート」)、プレイヤーのインデックスを適切にゲーマータグを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="8adc2-112">A JSON object containing the user's XUID and gamertag, as well the player's index in the session (or "seat"), whether the player is still participating in the session, and a small blob of custom data.</span></span>| 
| <span data-ttu-id="8adc2-113">profile</span><span class="sxs-lookup"><span data-stu-id="8adc2-113">profile</span></span>| <span data-ttu-id="8adc2-114">ユーザー プロファイルの URI アドレスと、ユーザーのユーザーでは通常の HTTP メソッドを使用してアクセスが、ゲーマー カード、ゲーマータグ、XUID などの可能性もなどについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8adc2-114">Information about the user accessed through profile URI addresses and HTTP methods, usually the user's UserSettings, but also possibly including gamercard, gamertag, XUID, and so on.</span></span>| 
| <span data-ttu-id="8adc2-115">設定</span><span class="sxs-lookup"><span data-stu-id="8adc2-115">setting</span></span>| <span data-ttu-id="8adc2-116">ユーザー オブジェクトのタイトルに固有の設定のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="8adc2-116">One of the title-specific settings in a UserSettings object.</span></span>| 
| <span data-ttu-id="8adc2-117">UserClaims</span><span class="sxs-lookup"><span data-stu-id="8adc2-117">UserClaims</span></span>| <span data-ttu-id="8adc2-118">ユーザーの XUID とゲーマータグを含むシンプルな JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="8adc2-118">A simple JSON object containing the user's XUID and gamertag.</span></span>| 
| <span data-ttu-id="8adc2-119">ユーザー</span><span class="sxs-lookup"><span data-stu-id="8adc2-119">UserSettings</span></span>| <span data-ttu-id="8adc2-120">タイトルに固有の設定、または現在の認証されたユーザーの基本設定のコレクションを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="8adc2-120">A JSON object containing a collection of title-specific settings or preferences for the current authenticated user.</span></span> <span data-ttu-id="8adc2-121">ユーザーは、ゲーム内のアクティビティに関連する可能性があります、任意のデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="8adc2-121">UserSettings can contain arbitrary data, possibly related to in-game activity.</span></span>| 
| <span data-ttu-id="8adc2-122">XUID</span><span class="sxs-lookup"><span data-stu-id="8adc2-122">XUID</span></span>| <span data-ttu-id="8adc2-123">ユーザーの Xbox ユーザー ID、一意の長い符号なし整数。</span><span class="sxs-lookup"><span data-stu-id="8adc2-123">The user's Xbox User ID, a unique unsigned long integer.</span></span> <span data-ttu-id="8adc2-124">判読するものではありません。</span><span class="sxs-lookup"><span data-stu-id="8adc2-124">Not meant to be human-readable.</span></span>| 
 
<a id="ID4E6D"></a>

 
## <a name="see-also"></a><span data-ttu-id="8adc2-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="8adc2-125">See also</span></span>
 
<a id="ID4EBE"></a>

 
##### <a name="parent"></a><span data-ttu-id="8adc2-126">Parent</span><span class="sxs-lookup"><span data-stu-id="8adc2-126">Parent</span></span>  

[<span data-ttu-id="8adc2-127">その他の参照</span><span class="sxs-lookup"><span data-stu-id="8adc2-127">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ENE"></a>

 
##### <a name="reference--player-jsonjsonjson-playermd"></a><span data-ttu-id="8adc2-128">参照[プレイヤー (JSON)](../json/json-player.md)</span><span class="sxs-lookup"><span data-stu-id="8adc2-128">Reference  [Player (JSON)](../json/json-player.md)</span></span>

 [<span data-ttu-id="8adc2-129">UserClaims (JSON)</span><span class="sxs-lookup"><span data-stu-id="8adc2-129">UserClaims (JSON)</span></span>](../json/json-userclaims.md)

 [<span data-ttu-id="8adc2-130">ユーザー (JSON)</span><span class="sxs-lookup"><span data-stu-id="8adc2-130">UserSettings (JSON)</span></span>](../json/json-usersettings.md)

   