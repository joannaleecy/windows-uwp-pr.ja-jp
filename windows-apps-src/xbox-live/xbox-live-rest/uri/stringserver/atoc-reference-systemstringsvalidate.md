---
title: システム文字列の検証 URI
assetID: b9a54456-7b4a-f6d8-16b9-5b6c3bd9813e
permalink: en-us/docs/xboxlive/rest/atoc-reference-systemstringsvalidate.html
description: " システム文字列の検証 URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2eaad3791830086d6b086ac0026523d28d596d1a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593847"
---
# <a name="system-strings-validatation-uris"></a><span data-ttu-id="c5530-104">システム文字列の検証 URI</span><span class="sxs-lookup"><span data-stu-id="c5530-104">System Strings Validatation URIs</span></span>
 
<span data-ttu-id="c5530-105">このセクションでは、Universal Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト転送プロトコル (HTTP) のメソッドに関する詳細情報を提供の Xbox Live サービスから*システム文字列検証*です。</span><span class="sxs-lookup"><span data-stu-id="c5530-105">This section provides detail about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *system strings validation*.</span></span>
 
<span data-ttu-id="c5530-106">永続的な文字列データをアップロードする前に、コードの実行または使用条件に違反していないことを確認する検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5530-106">Before uploading persistent string data to , it should be validated to ensure it doesn't violate the Code of Conduct or Terms of Use.</span></span> <span data-ttu-id="c5530-107">この REST リソースは、文字列の配列を受け取り、1 は、許容されるかどうか、および問題のある用語を含む文字列を示す結果コードを返します。</span><span class="sxs-lookup"><span data-stu-id="c5530-107">This REST resource takes an array of strings and returns a result code for each one, indicating whether or not it is acceptable on , and a string containing the offending term.</span></span>
 
<span data-ttu-id="c5530-108">これらの Uri のドメインとは、クライアント strings.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="c5530-108">The domain for these URIs is client-strings.xboxlive.com.</span></span>
 
<a id="ID4EQB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="c5530-109">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="c5530-109">In this section</span></span>

[<span data-ttu-id="c5530-110">/system/strings/validate</span><span class="sxs-lookup"><span data-stu-id="c5530-110">/system/strings/validate</span></span>](uri-systemstringsvalidate.md)

<span data-ttu-id="c5530-111">&nbsp;&nbsp;検証のための文字列の配列にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="c5530-111">&nbsp;&nbsp;Accesses an array of strings for validation.</span></span>
 
<a id="ID4EWB"></a>

 
## <a name="see-also"></a><span data-ttu-id="c5530-112">関連項目</span><span class="sxs-lookup"><span data-stu-id="c5530-112">See also</span></span>
 
<a id="ID4EYB"></a>

 
##### <a name="parent"></a><span data-ttu-id="c5530-113">Parent</span><span class="sxs-lookup"><span data-stu-id="c5530-113">Parent</span></span> 

[<span data-ttu-id="c5530-114">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="c5530-114">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   