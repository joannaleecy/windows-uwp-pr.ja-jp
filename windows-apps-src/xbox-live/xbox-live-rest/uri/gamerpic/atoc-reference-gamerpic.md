---
title: ゲーマーアイコン URI
assetID: 811ab696-c433-aa54-90d8-66614ad09901
permalink: en-us/docs/xboxlive/rest/atoc-reference-gamerpic.html
author: KevinAsgari
description: " ゲーマーアイコン URI"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b45f4556628b64726b96b47b373b3408cf6ddf3
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5942711"
---
# <a name="gamerpic-uris"></a><span data-ttu-id="9c962-104">ゲーマーアイコン URI</span><span class="sxs-lookup"><span data-stu-id="9c962-104">Gamerpic URIs</span></span>
 
<span data-ttu-id="9c962-105">このセクションでは、*人々*用の Xbox Live サービスから、ゲーマー アイコン ユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="9c962-105">This section provides detail about the Gamerpic Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *gamerpics*.</span></span>
 
<span data-ttu-id="9c962-106">これらの Uri のドメインが`gamerpics.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9c962-106">The domain for these URIs is `gamerpics.xboxlive.com`.</span></span>
 
<span data-ttu-id="9c962-107">ゲーマー アイコン サービスは、ユーザーが、ゲーム キャラクターのゲーマー アイコンを生成できるようにする機能をタイトルに付与することによって、その他の [パーソナル設定] オプションをユーザーに提供する設計されています (このシナリオでゲームの文字は、ゲーム内の主役は、ユーザーがある可能性があります、自動車、宇宙船、またはタイトルでユーザーを制御するその他のエンティティ)。</span><span class="sxs-lookup"><span data-stu-id="9c962-107">The Gamerpic Service has been designed to give users more personalization options, by granting a title the ability to allow the user to generate a gamerpic of their game character (a game character in this scenario refers to an in-game protagonist; it could be a person, a car, a spaceship, or any other entity that the user controls in the title).</span></span>
 
<span data-ttu-id="9c962-108">ゲーマー アイコンがタイトルを生成する基本的なフローは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9c962-108">The basic flow of generating a title gamerpic is as follows:</span></span>
 
   * <span data-ttu-id="9c962-109">タイトルは、ゲーム内の文字のイメージを作成することで、ユーザーを提供します。</span><span class="sxs-lookup"><span data-stu-id="9c962-109">The title provides the user with the ability to create an image of their in-game character.</span></span> 
     * <span data-ttu-id="9c962-110">必要でない場合は、タイトルでは適切な特権がないユーザーがメッセージしことができます。</span><span class="sxs-lookup"><span data-stu-id="9c962-110">If not, the title can then message the user that they do not have the appropriate privilege.</span></span>
     * <span data-ttu-id="9c962-111">ユーザー特権がある場合、は、ユーザーが、文字ゲーマー アイコンを作成する続けることができます。</span><span class="sxs-lookup"><span data-stu-id="9c962-111">If the user does have the privilege, the user can continue to create their character gamerpic.</span></span>
  
   * <span data-ttu-id="9c962-112">ユーザーは、イメージを作成し、タイトルは、ゲーマー アイコン サービスに 1080 x 1080 の .png ファイルを送信します。</span><span class="sxs-lookup"><span data-stu-id="9c962-112">The user creates the image and the title sends the 1080x1080 .png file to the gamerpic service.</span></span>
   * <span data-ttu-id="9c962-113">サービスは、画像を保存し、ユーザーの新しいゲーマー アイコンとして、イメージを設定します。</span><span class="sxs-lookup"><span data-stu-id="9c962-113">The service stores the image and sets the image as the user's new gamerpic.</span></span>
   * <span data-ttu-id="9c962-114">ユーザーのゲーマー アイコンの呼び出しのエクスペリエンスでは、更新後の画像を取得します。</span><span class="sxs-lookup"><span data-stu-id="9c962-114">Any experiences calling for the user's gamerpic will get the updated image.</span></span>
  
<span data-ttu-id="9c962-115">ゲーマー アイコンがタイトルを設定する機能は、実施専用特権 (211) によって制御されます。</span><span class="sxs-lookup"><span data-stu-id="9c962-115">The ability to set a title gamerpic is controlled by an enforcement-only privilege (211).</span></span> <span data-ttu-id="9c962-116">強制では、特権を取り消します、ユーザーがされなくなりますタイトルのゲーマー アイコンを保存し、サービスには、403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="9c962-116">If enforcement revokes the privilege, the user will be prevented from saving a title gamerpic, and the service will return 403.</span></span> <span data-ttu-id="9c962-117">タイトルは、コンテンツ (priv 211) を共有するユーザーが許可されていることを確認する CheckPrivilege を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c962-117">Titles should call CheckPrivilege to verify that users are permitted to share content (priv 211).</span></span>
 
<span data-ttu-id="9c962-118">現在、このサービスを使用するために、タイトルではホワイト リスト化される必要があります。</span><span class="sxs-lookup"><span data-stu-id="9c962-118">Presently, in order to use this service, your title must be whitelisted.</span></span> <span data-ttu-id="9c962-119">承認を要求するには、メール`slsgamerpics@microsoft.com`します。</span><span class="sxs-lookup"><span data-stu-id="9c962-119">To request approval, email `slsgamerpics@microsoft.com`.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="9c962-120">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="9c962-120">In this section</span></span>

[<span data-ttu-id="9c962-121">/users/me/gamerpic</span><span class="sxs-lookup"><span data-stu-id="9c962-121">/users/me/gamerpic</span></span>](uri-usersmegamerpic.md)

<span data-ttu-id="9c962-122">&nbsp;&nbsp;1080 x 1080 ゲーマー アイコンにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="9c962-122">&nbsp;&nbsp;Accesses a 1080x1080 gamerpic.</span></span>
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9c962-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="9c962-123">See also</span></span>
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9c962-124">Parent</span><span class="sxs-lookup"><span data-stu-id="9c962-124">Parent</span></span> 

[<span data-ttu-id="9c962-125">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="9c962-125">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   