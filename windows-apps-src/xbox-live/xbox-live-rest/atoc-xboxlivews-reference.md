---
title: Xbox Live サービス RESTful リファレンス
assetID: 527db3b0-5ebd-eeca-4330-2074199c82ff
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference.html
author: KevinAsgari
description: " Xbox Live サービス RESTful リファレンス"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1f58c9028d506b6f2773529e3c1e8f8fdfbff4d6
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5867627"
---
# <a name="xbox-live-services-restful-reference"></a><span data-ttu-id="c63f8-104">Xbox Live サービス RESTful リファレンス</span><span class="sxs-lookup"><span data-stu-id="c63f8-104">Xbox Live Services RESTful Reference</span></span>

<span data-ttu-id="c63f8-105">Xbox Live サービスでは、一連のゲームとプレイヤーの情報を管理するためのサービスです。</span><span class="sxs-lookup"><span data-stu-id="c63f8-105">Xbox Live Services is a set of services for managing games and player information.</span></span> <span data-ttu-id="c63f8-106">これらのサービスをサポートして**Xbox.Services** API 可能であればために使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c63f8-106">These services support the **Xbox.Services** API which should be used whenever possible.</span></span> <span data-ttu-id="c63f8-107">まだ**Xbox.Services**に追加していない新しい方法は、このセクションで説明されている RESTful インターフェイスを使用します。</span><span class="sxs-lookup"><span data-stu-id="c63f8-107">Use the RESTful interface described in this section for newer methods that have not be added to **Xbox.Services** yet.</span></span>

<a id="ID4E5"></a>


## <a name="in-this-section"></a><span data-ttu-id="c63f8-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="c63f8-108">In this section</span></span>

[<span data-ttu-id="c63f8-109">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="c63f8-109">Universal Resource Identifier (URI) Reference</span></span>](uri/atoc-xboxlivews-reference-uris.md)

<span data-ttu-id="c63f8-110">&nbsp;&nbsp;リソースと Xbox Live サービスで使用できるメソッドのリファレンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c63f8-110">&nbsp;&nbsp;Provides reference material for the resources and methods that can be used with Xbox Live Services.</span></span>

[<span data-ttu-id="c63f8-111">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c63f8-111">JavaScript Object Notation (JSON) Object Reference</span></span>](json/atoc-xboxlivews-reference-json.md)

<span data-ttu-id="c63f8-112">&nbsp;&nbsp;Xbox Live サービスを使用する JavaScript Object Notation (JSON) オブジェクトのリファレンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c63f8-112">&nbsp;&nbsp;Provides reference material for the JavaScript Object Notation (JSON) objects used with Xbox Live Services.</span></span>

[<span data-ttu-id="c63f8-113">JavaScript Object Notation (JSON) オブジェクトで使用される列挙型</span><span class="sxs-lookup"><span data-stu-id="c63f8-113">Enumerations Used In JavaScript Object Notation (JSON) Objects</span></span>](enums/atoc-xboxlivews-reference-enums.md)

<span data-ttu-id="c63f8-114">&nbsp;&nbsp;Xbox Live サービスで使われる JavaScript Object Notation (JSON) オブジェクトで使用する列挙体に関するリファレンス情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="c63f8-114">&nbsp;&nbsp;Provides reference material for the enumerations used in JavaScript Object Notation (JSON) objects used with Xbox Live Services.</span></span>

[<span data-ttu-id="c63f8-115">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="c63f8-115">Additional Reference</span></span>](additional/atoc-xboxlivews-reference-additional.md)

<span data-ttu-id="c63f8-116">&nbsp;&nbsp;Xbox Live サービスの補助リファレンスです。</span><span class="sxs-lookup"><span data-stu-id="c63f8-116">&nbsp;&nbsp;Supplementary reference material for Xbox Live Services.</span></span> <span data-ttu-id="c63f8-117">これには、承認のタイプ、データ型、標準の HTTP ステータス コードとヘッダー、ページング パラメーター、およびエンターテイメント探索サービス (EDS) に関する情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c63f8-117">This includes information about authorization types, data types, standard HTTP status codes and headers, paging parameters, and Entertainment Discovery Services (EDS).</span></span>
