---
title: システムが Validatation Uri を示す文字列します。
assetID: b9a54456-7b4a-f6d8-16b9-5b6c3bd9813e
permalink: en-us/docs/xboxlive/rest/atoc-reference-systemstringsvalidate.html
author: KevinAsgari
description: " システムが Validatation Uri を示す文字列します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47b487a4708e42ee66f293bfa020ba51cfad82a9
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3955960"
---
# <a name="system-strings-validatation-uris"></a><span data-ttu-id="e31b1-104">システムが Validatation Uri を示す文字列します。</span><span class="sxs-lookup"><span data-stu-id="e31b1-104">System Strings Validatation URIs</span></span>
 
<span data-ttu-id="e31b1-105">このセクションでは、*システムの文字列の検証*用の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="e31b1-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *system strings validation*.</span></span>
 
<span data-ttu-id="e31b1-106">永続的な文字列データをアップロードする前に、倫理規定またはの使用条件に違反していないことを確認する検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e31b1-106">Before uploading persistent string data to , it should be validated to ensure it doesn't violate the Code of Conduct or Terms of Use.</span></span> <span data-ttu-id="e31b1-107">この REST リソースは、文字列の配列を取得し、それぞれには、許容できるかどうかと、問題のある語句を含む文字列を示す結果コードを返します。</span><span class="sxs-lookup"><span data-stu-id="e31b1-107">This REST resource takes an array of strings and returns a result code for each one, indicating whether or not it is acceptable on , and a string containing the offending term.</span></span>
 
<span data-ttu-id="e31b1-108">これらの Uri のドメインは、クライアント strings.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="e31b1-108">The domain for these URIs is client-strings.xboxlive.com.</span></span>
 
<a id="ID4EQB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="e31b1-109">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="e31b1-109">In this section</span></span>

[<span data-ttu-id="e31b1-110">/system/strings/validate</span><span class="sxs-lookup"><span data-stu-id="e31b1-110">/system/strings/validate</span></span>](uri-systemstringsvalidate.md)

<span data-ttu-id="e31b1-111">&nbsp;&nbsp;検証のための文字列の配列にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="e31b1-111">&nbsp;&nbsp;Accesses an array of strings for validation.</span></span>
 
<a id="ID4EWB"></a>

 
## <a name="see-also"></a><span data-ttu-id="e31b1-112">関連項目</span><span class="sxs-lookup"><span data-stu-id="e31b1-112">See also</span></span>
 
<a id="ID4EYB"></a>

 
##### <a name="parent"></a><span data-ttu-id="e31b1-113">Parent</span><span class="sxs-lookup"><span data-stu-id="e31b1-113">Parent</span></span> 

[<span data-ttu-id="e31b1-114">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="e31b1-114">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   