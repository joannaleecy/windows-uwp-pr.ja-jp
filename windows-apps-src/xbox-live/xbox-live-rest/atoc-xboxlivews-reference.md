---
title: Xbox Live サービス RESTful リファレンス
assetID: 527db3b0-5ebd-eeca-4330-2074199c82ff
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference.html
author: KevinAsgari
description: " Xbox Live サービス RESTful リファレンス"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a6d5460d4021de8daa6af344e2da920e55dbba5
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4126270"
---
# <a name="xbox-live-services-restful-reference"></a><span data-ttu-id="0bca1-104">Xbox Live サービス RESTful リファレンス</span><span class="sxs-lookup"><span data-stu-id="0bca1-104">Xbox Live Services RESTful Reference</span></span>

<span data-ttu-id="0bca1-105">Xbox Live サービスでは、一連のゲームとプレイヤーの情報を管理するためのサービスです。</span><span class="sxs-lookup"><span data-stu-id="0bca1-105">Xbox Live Services is a set of services for managing games and player information.</span></span> <span data-ttu-id="0bca1-106">これらのサービスをサポートして**Xbox.Services** API 可能であればために使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bca1-106">These services support the **Xbox.Services** API which should be used whenever possible.</span></span> <span data-ttu-id="0bca1-107">まだ**Xbox.Services**に追加していない新しい方法は、このセクションで説明されている RESTful インターフェイスを使用します。</span><span class="sxs-lookup"><span data-stu-id="0bca1-107">Use the RESTful interface described in this section for newer methods that have not be added to **Xbox.Services** yet.</span></span>

<a id="ID4E5"></a>


## <a name="in-this-section"></a><span data-ttu-id="0bca1-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="0bca1-108">In this section</span></span>

[<span data-ttu-id="0bca1-109">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="0bca1-109">Universal Resource Identifier (URI) Reference</span></span>](uri/atoc-xboxlivews-reference-uris.md)

<span data-ttu-id="0bca1-110">&nbsp;&nbsp;リソースと Xbox Live サービスで使用できるメソッドのリファレンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="0bca1-110">&nbsp;&nbsp;Provides reference material for the resources and methods that can be used with Xbox Live Services.</span></span>

[<span data-ttu-id="0bca1-111">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="0bca1-111">JavaScript Object Notation (JSON) Object Reference</span></span>](json/atoc-xboxlivews-reference-json.md)

<span data-ttu-id="0bca1-112">&nbsp;&nbsp;Xbox Live サービスで使われる JavaScript Object Notation (JSON) オブジェクトのリファレンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="0bca1-112">&nbsp;&nbsp;Provides reference material for the JavaScript Object Notation (JSON) objects used with Xbox Live Services.</span></span>

[<span data-ttu-id="0bca1-113">JavaScript Object Notation (JSON) オブジェクトで使用される列挙型</span><span class="sxs-lookup"><span data-stu-id="0bca1-113">Enumerations Used In JavaScript Object Notation (JSON) Objects</span></span>](enums/atoc-xboxlivews-reference-enums.md)

<span data-ttu-id="0bca1-114">&nbsp;&nbsp;Xbox Live サービスで使われる JavaScript Object Notation (JSON) オブジェクトで使用する列挙体に関するリファレンス情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="0bca1-114">&nbsp;&nbsp;Provides reference material for the enumerations used in JavaScript Object Notation (JSON) objects used with Xbox Live Services.</span></span>

[<span data-ttu-id="0bca1-115">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="0bca1-115">Additional Reference</span></span>](additional/atoc-xboxlivews-reference-additional.md)

<span data-ttu-id="0bca1-116">&nbsp;&nbsp;Xbox Live サービスの補助リファレンスです。</span><span class="sxs-lookup"><span data-stu-id="0bca1-116">&nbsp;&nbsp;Supplementary reference material for Xbox Live Services.</span></span> <span data-ttu-id="0bca1-117">これには、認証の種類、データ型、標準の HTTP ステータス コードとヘッダー、ページング パラメーターには、エンターテインメント探索サービス (EDS) に関する情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0bca1-117">This includes information about authorization types, data types, standard HTTP status codes and headers, paging parameters, and Entertainment Discovery Services (EDS).</span></span>
