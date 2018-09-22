---
title: タイトル ストレージ URI
assetID: 32bba1e4-0980-785e-c098-a96cd88a8e5f
permalink: en-us/docs/xboxlive/rest/atoc-reference-storagev2.html
author: KevinAsgari
description: " タイトル ストレージ URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5a188c3406ad0ca3bfca78d6b45c548c72bf791e
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4122362"
---
# <a name="title-storage-uris"></a><span data-ttu-id="0cf93-104">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="0cf93-104">Title Storage URIs</span></span>
 
<span data-ttu-id="0cf93-105">このセクションでは、*タイトル ストレージ*用の Xbox Live サービスからの詳細については、ユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) メソッドを提供します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-105">This section provides details about Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *title storage*.</span></span>
 
<span data-ttu-id="0cf93-106">どのプラットフォームで実行されるゲームでも、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0cf93-106">Games running on all platforms can use this service.</span></span>
 
<span data-ttu-id="0cf93-107">これらの Uri のドメインは、titlestorage.xboxlive.com です。</span><span class="sxs-lookup"><span data-stu-id="0cf93-107">The domain for these URIs is titlestorage.xboxlive.com.</span></span>
 
<a id="ID4EFB"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="0cf93-108">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="0cf93-108">In this section</span></span>

[<span data-ttu-id="0cf93-109">/global/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="0cf93-109">/global/scids/{scid}</span></span>](uri-globalscidsscid.md)

<span data-ttu-id="0cf93-110">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-110">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="0cf93-111">/global/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="0cf93-111">/global/scids/{scid}/data/{path}</span></span>](uri-globalscidssciddatapath.md)

<span data-ttu-id="0cf93-112">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-112">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="0cf93-113">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0cf93-113">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-globalscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-114">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="0cf93-114">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="0cf93-115">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="0cf93-115">/json/users/batch/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersbatchscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-116">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="0cf93-116">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>

[<span data-ttu-id="0cf93-117">/json/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="0cf93-117">/json/users/xuid({xuid})/scids/{scid}</span></span>](uri-jsonusersxuidscidsscid.md)

<span data-ttu-id="0cf93-118">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-118">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="0cf93-119">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="0cf93-119">/json/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-jsonusersxuidscidssciddatapath.md)

<span data-ttu-id="0cf93-120">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-120">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="0cf93-121">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="0cf93-121">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-122">&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-122">&nbsp;&nbsp;Downloads, uploads, or deletes a file.</span></span>

[<span data-ttu-id="0cf93-123">/sessions/{sessionId}/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="0cf93-123">/sessions/{sessionId}/scids/{scid}</span></span>](uri-sessionssessionidscidsscid.md)

<span data-ttu-id="0cf93-124">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-124">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="0cf93-125">/sessions/{sessionId}/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="0cf93-125">/sessions/{sessionId}/scids/{scid}/data/{path}</span></span>](uri-sessionssessionidscidssciddatapath.md)

<span data-ttu-id="0cf93-126">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-126">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="0cf93-127">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0cf93-127">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-128">&nbsp;&nbsp;ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="0cf93-128">&nbsp;&nbsp;Downloads a file.</span></span>

[<span data-ttu-id="0cf93-129">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0cf93-129">/trustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersbatchscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-130">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="0cf93-130">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>

[<span data-ttu-id="0cf93-131">/trustedplatform/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="0cf93-131">/trustedplatform/users/xuid({xuid})/scids/{scid}</span></span>](uri-trustedplatformusersxuidscidsscid.md)

<span data-ttu-id="0cf93-132">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-132">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="0cf93-133">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="0cf93-133">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-trustedplatformusersxuidscidssciddatapath.md)

<span data-ttu-id="0cf93-134">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-134">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="0cf93-135">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0cf93-135">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-136">&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-136">&nbsp;&nbsp;Downloads, uploads, or deletes a file.</span></span>

[<span data-ttu-id="0cf93-137">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0cf93-137">/untrustedplatform/users/batch/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-138">&nbsp;&nbsp;同じファイル名を持つ複数のユーザーから複数のファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="0cf93-138">&nbsp;&nbsp;Downloads multiple files from multiple users with the same filename.</span></span>

[<span data-ttu-id="0cf93-139">/untrustedplatform/users/xuid({xuid})/scids/{scid}</span><span class="sxs-lookup"><span data-stu-id="0cf93-139">/untrustedplatform/users/xuid({xuid})/scids/{scid}</span></span>](uri-untrustedplatformusersxuidscidsscid.md)

<span data-ttu-id="0cf93-140">&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-140">&nbsp;&nbsp;Retrieves quota information for this storage type.</span></span>

[<span data-ttu-id="0cf93-141">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span><span class="sxs-lookup"><span data-stu-id="0cf93-141">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}</span></span>](uri-untrustedplatformusersxuidscidssciddatapath.md)

<span data-ttu-id="0cf93-142">&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-142">&nbsp;&nbsp;Lists file information at a specified path.</span></span> 

[<span data-ttu-id="0cf93-143">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0cf93-143">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

<span data-ttu-id="0cf93-144">&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="0cf93-144">&nbsp;&nbsp;Downloads, uploads, or deletes a file.</span></span>
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a><span data-ttu-id="0cf93-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="0cf93-145">See also</span></span>
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a><span data-ttu-id="0cf93-146">Parent</span><span class="sxs-lookup"><span data-stu-id="0cf93-146">Parent</span></span> 

[<span data-ttu-id="0cf93-147">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="0cf93-147">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   