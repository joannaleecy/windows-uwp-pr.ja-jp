---
title: ゲーマーアイコン URI
assetID: 811ab696-c433-aa54-90d8-66614ad09901
permalink: en-us/docs/xboxlive/rest/atoc-reference-gamerpic.html
description: " ゲーマーアイコン URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a8ba79784ed73ae62e7fe8d65c626c3ebc6003a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618387"
---
# <a name="gamerpic-uris"></a><span data-ttu-id="31990-104">ゲーマーアイコン URI</span><span class="sxs-lookup"><span data-stu-id="31990-104">Gamerpic URIs</span></span>
 
<span data-ttu-id="31990-105">このセクションの Xbox Live サービスから Gamerpic Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供する*gamerpics*します。</span><span class="sxs-lookup"><span data-stu-id="31990-105">This section provides detail about the Gamerpic Universal Resource Identifier (URI) addresses and associated Hypertext Transport Protocol (HTTP) methods from Xbox Live Services for *gamerpics*.</span></span>
 
<span data-ttu-id="31990-106">これらの Uri のドメインが`gamerpics.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="31990-106">The domain for these URIs is `gamerpics.xboxlive.com`.</span></span>
 
<span data-ttu-id="31990-107">タイトルのゲームの文字の gamerpic を生成するユーザーを許可する権限を付与することより多くのパーソナル化オプションをユーザーに付与する Gamerpic サービスは設計されています (このシナリオでのゲームの文字を指す、ゲームの主役は、ユーザーがある可能性があります、自動車、宇宙船、またはその他のエンティティのタイトルにユーザーを制御する)。</span><span class="sxs-lookup"><span data-stu-id="31990-107">The Gamerpic Service has been designed to give users more personalization options, by granting a title the ability to allow the user to generate a gamerpic of their game character (a game character in this scenario refers to an in-game protagonist; it could be a person, a car, a spaceship, or any other entity that the user controls in the title).</span></span>
 
<span data-ttu-id="31990-108">タイトル gamerpic を生成する基本的な流れは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="31990-108">The basic flow of generating a title gamerpic is as follows:</span></span>
 
   * <span data-ttu-id="31990-109">タイトルは、ゲーム内の文字のイメージを作成することができます、ユーザーを提供します。</span><span class="sxs-lookup"><span data-stu-id="31990-109">The title provides the user with the ability to create an image of their in-game character.</span></span> 
     * <span data-ttu-id="31990-110">それ以外の場合は、ユーザーが適切な特権がありませんできますし、メッセージのタイトル。</span><span class="sxs-lookup"><span data-stu-id="31990-110">If not, the title can then message the user that they do not have the appropriate privilege.</span></span>
     * <span data-ttu-id="31990-111">場合は、ユーザーには、特権がある、ユーザーはその文字 gamerpic を作成するを続けることができます。</span><span class="sxs-lookup"><span data-stu-id="31990-111">If the user does have the privilege, the user can continue to create their character gamerpic.</span></span>
  
   * <span data-ttu-id="31990-112">ユーザーがイメージを作成し、タイトルが gamerpic サービスに 1080 x 1080 の .png ファイルを送信します。</span><span class="sxs-lookup"><span data-stu-id="31990-112">The user creates the image and the title sends the 1080x1080 .png file to the gamerpic service.</span></span>
   * <span data-ttu-id="31990-113">イメージが格納され、ユーザーの新しい gamerpic としてイメージを設定します。</span><span class="sxs-lookup"><span data-stu-id="31990-113">The service stores the image and sets the image as the user's new gamerpic.</span></span>
   * <span data-ttu-id="31990-114">更新されたイメージは、ユーザーの gamerpic の呼び出しのエクスペリエンスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="31990-114">Any experiences calling for the user's gamerpic will get the updated image.</span></span>
  
<span data-ttu-id="31990-115">タイトル gamerpic を設定する機能は、強制専用特権 (211) によって制御されます。</span><span class="sxs-lookup"><span data-stu-id="31990-115">The ability to set a title gamerpic is controlled by an enforcement-only privilege (211).</span></span> <span data-ttu-id="31990-116">強制では、権限を取り消します、ユーザーは、タイトル gamerpic を保存できませんし、サービスには、403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="31990-116">If enforcement revokes the privilege, the user will be prevented from saving a title gamerpic, and the service will return 403.</span></span> <span data-ttu-id="31990-117">タイトルは、コンテンツ (priv 211) を共有するユーザーが許可されていることを確認する CheckPrivilege を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="31990-117">Titles should call CheckPrivilege to verify that users are permitted to share content (priv 211).</span></span>
 
<span data-ttu-id="31990-118">現在、このサービスを使用するには、タイトルは、ホワイト リストに登録をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="31990-118">Presently, in order to use this service, your title must be whitelisted.</span></span> <span data-ttu-id="31990-119">承認を要求する電子メール`slsgamerpics@microsoft.com`します。</span><span class="sxs-lookup"><span data-stu-id="31990-119">To request approval, email `slsgamerpics@microsoft.com`.</span></span>
 
<a id="ID4EGC"></a>

 
## <a name="in-this-section"></a><span data-ttu-id="31990-120">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="31990-120">In this section</span></span>

[<span data-ttu-id="31990-121">/users/me/gamerpic</span><span class="sxs-lookup"><span data-stu-id="31990-121">/users/me/gamerpic</span></span>](uri-usersmegamerpic.md)

<span data-ttu-id="31990-122">&nbsp;&nbsp;1080 x 1080 gamerpic にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="31990-122">&nbsp;&nbsp;Accesses a 1080x1080 gamerpic.</span></span>
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a><span data-ttu-id="31990-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="31990-123">See also</span></span>
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a><span data-ttu-id="31990-124">Parent</span><span class="sxs-lookup"><span data-stu-id="31990-124">Parent</span></span> 

[<span data-ttu-id="31990-125">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="31990-125">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   