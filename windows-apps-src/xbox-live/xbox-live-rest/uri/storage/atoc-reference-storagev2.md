---
title: タイトル ストレージ URI
assetID: 32bba1e4-0980-785e-c098-a96cd88a8e5f
permalink: en-us/docs/xboxlive/rest/atoc-reference-storagev2.html
author: KevinAsgari
description: " タイトル ストレージ URI"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e17bb64fd31c8a3cf86b57453e709e15b0cf7e6f
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6860891"
---
# <a name="title-storage-uris"></a><span data-ttu-id="536cb-104">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="536cb-104">Title Storage URIs</span></span>
 
<span data-ttu-id="536cb-105">このセクションでは、*タイトル ストレージ*用の Xbox Live サービスからユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) メソッドの詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="536cb-105">This section provides details about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *title storage*.</span></span>
 
<span data-ttu-id="536cb-106">どのプラットフォームで実行されるゲームでも、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="536cb-106">Games running on all platforms can use this service.</span></span>
 
<span data-ttu-id="536cb-107">これらの Uri のドメインは、titlestorage.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="536cb-107">The domain for these URIs is titlestorage.xboxlive.com.</span></span>
 
<a id="ID4EFB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="536cb-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="536cb-108">In this section</span></span>

[<span data-ttu-id="536cb-109">/global/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="536cb-109">/global/scids/{scid}</span></span>](uri-globalscidsscid.md)

<span data-ttu-id="536cb-110">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="536cb-110">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="536cb-111">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="536cb-111">/global/scids/{scid}/data/{path}</span></span>](uri-globalscidssciddatapath.md)

<span data-ttu-id="536cb-112">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="536cb-112">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="536cb-113">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="536cb-113">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-globalscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-114">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="536cb-114">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="536cb-115">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="536cb-115">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-116">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="536cb-116">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>

[<span data-ttu-id="536cb-117">/json/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="536cb-117">/json/users/xuid({xuid})/scids/{scid}</span></span>](uri-jsonusersxuidscidsscid.md)

<span data-ttu-id="536cb-118">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="536cb-118">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="536cb-119">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="536cb-119">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-jsonusersxuidscidssciddatapath.md)

<span data-ttu-id="536cb-120">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="536cb-120">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="536cb-121">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="536cb-121">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-122">&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="536cb-122">&nbsp;&nbsp;Downloads, uploads, or deletes a file.</span></span>

[<span data-ttu-id="536cb-123">/sessions/{sessionId}/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="536cb-123">/sessions/{sessionId}/scids/{scid}</span></span>](uri-sessionssessionidscidsscid.md)

<span data-ttu-id="536cb-124">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="536cb-124">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="536cb-125">/sessions/{sessionId}/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="536cb-125">/sessions/{sessionId}/scids/{scid}/data/{path}</span></span>](uri-sessionssessionidscidssciddatapath.md)

<span data-ttu-id="536cb-126">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="536cb-126">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="536cb-127">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="536cb-127">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-128">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="536cb-128">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="536cb-129">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="536cb-129">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersbatchscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-130">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="536cb-130">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>

[<span data-ttu-id="536cb-131">/trustedplatform/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="536cb-131">/trustedplatform/users/xuid({xuid})/scids/{scid}</span></span>](uri-trustedplatformusersxuidscidsscid.md)

<span data-ttu-id="536cb-132">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="536cb-132">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="536cb-133">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="536cb-133">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-trustedplatformusersxuidscidssciddatapath.md)

<span data-ttu-id="536cb-134">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="536cb-134">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="536cb-135">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="536cb-135">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-136">&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="536cb-136">&nbsp;&nbsp;Downloads, uploads, or deletes a file.</span></span>

[<span data-ttu-id="536cb-137">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="536cb-137">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-138">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="536cb-138">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>

[<span data-ttu-id="536cb-139">/untrustedplatform/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="536cb-139">/untrustedplatform/users/xuid({xuid})/scids/{scid}</span></span>](uri-untrustedplatformusersxuidscidsscid.md)

<span data-ttu-id="536cb-140">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="536cb-140">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="536cb-141">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="536cb-141">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-untrustedplatformusersxuidscidssciddatapath.md)

<span data-ttu-id="536cb-142">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="536cb-142">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="536cb-143">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="536cb-143">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

<span data-ttu-id="536cb-144">&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="536cb-144">&nbsp;&nbsp;Downloads, uploads, or deletes a file.</span></span>
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="536cb-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="536cb-145">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="536cb-146">Parent</span><span class="sxs-lookup"><span data-stu-id="536cb-146">Parent</span></span> 

[<span data-ttu-id="536cb-147">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="536cb-147">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   