---
title: /serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/servers/{サーバー名}
assetID: aed0764f-4e3d-e0b3-1ea0-543c32f3f822
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservername.html
author: KevinAsgari
description: " /serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/servers/{サーバー名}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b451d5aca9e855e204cb1178bf8ae30fb33ed015
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3930555"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatenamesessionssessionnameserversserver-name"></a><span data-ttu-id="de72b-104">/serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/servers/{サーバー名}</span><span class="sxs-lookup"><span data-stu-id="de72b-104">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name}</span></span>
<span data-ttu-id="de72b-105">セッションの指定されたサーバーを削除する削除操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="de72b-105">Supports a DELETE operation to remove the specified server of a session.</span></span>
<a id="ID4EO"></a>


## <a name="uri-parameters"></a><span data-ttu-id="de72b-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="de72b-106">URI parameters</span></span>

| <span data-ttu-id="de72b-107">パラメーター</span><span class="sxs-lookup"><span data-stu-id="de72b-107">Parameter</span></span>| <span data-ttu-id="de72b-108">型</span><span class="sxs-lookup"><span data-stu-id="de72b-108">Type</span></span>| <span data-ttu-id="de72b-109">説明</span><span class="sxs-lookup"><span data-stu-id="de72b-109">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="de72b-110">scid</span><span class="sxs-lookup"><span data-stu-id="de72b-110">scid</span></span>| <span data-ttu-id="de72b-111">GUID</span><span class="sxs-lookup"><span data-stu-id="de72b-111">GUID</span></span>| <span data-ttu-id="de72b-112">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="de72b-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="de72b-113">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="de72b-113">Part 1 of the session identifier.</span></span>|
| <span data-ttu-id="de72b-114">sessionTemplateName</span><span class="sxs-lookup"><span data-stu-id="de72b-114">sessionTemplateName</span></span>| <span data-ttu-id="de72b-115">string</span><span class="sxs-lookup"><span data-stu-id="de72b-115">string</span></span>| <span data-ttu-id="de72b-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="de72b-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="de72b-117">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="de72b-117">Part 2 of the session identifier.</span></span>|
| <span data-ttu-id="de72b-118">セッション名</span><span class="sxs-lookup"><span data-stu-id="de72b-118">sessionName</span></span>| <span data-ttu-id="de72b-119">GUID</span><span class="sxs-lookup"><span data-stu-id="de72b-119">GUID</span></span>| <span data-ttu-id="de72b-120">セッションの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="de72b-120">Unique ID of the session.</span></span> <span data-ttu-id="de72b-121">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="de72b-121">Part 3 of the session identifier.</span></span>| 

<a id="ID4E3B"></a>


## <a name="valid-methods"></a><span data-ttu-id="de72b-122">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="de72b-122">Valid methods</span></span>

[<span data-ttu-id="de72b-123">(/Serviceconfigs/{scid} {sessionTemplateName}/sessiontemplates//sessions/{セッション}/servers/{サーバー名}) を削除します。</span><span class="sxs-lookup"><span data-stu-id="de72b-123">DELETE (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions/{sessionName}/servers/{server-name})</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionnamemembersservernamedelete.md)

<span data-ttu-id="de72b-124">&nbsp;&nbsp;指定されたサーバーは、セッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="de72b-124">&nbsp;&nbsp;Removes the specified server from a session.</span></span>

<a id="ID4EGC"></a>


## <a name="see-also"></a><span data-ttu-id="de72b-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="de72b-125">See also</span></span>

<a id="ID4EIC"></a>


##### <a name="parent"></a><span data-ttu-id="de72b-126">Parent</span><span class="sxs-lookup"><span data-stu-id="de72b-126">Parent</span></span>

[<span data-ttu-id="de72b-127">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="de72b-127">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)
