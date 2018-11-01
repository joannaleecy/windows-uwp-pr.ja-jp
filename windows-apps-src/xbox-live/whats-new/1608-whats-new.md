---
title: Xbox Live SDK の新規事項 - August 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - August 2016
ms.assetid: fa52e7bd-2c2c-4c25-94ab-761036a7ca79
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: fd78e2ff061f8cf1268a340ad63d954993f563fc
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5869893"
---
# <a name="whats-new-for-the-xbox-live-sdk---august-2016"></a><span data-ttu-id="62398-104">Xbox Live SDK の新規事項 - August 2016</span><span class="sxs-lookup"><span data-stu-id="62398-104">What's new for the Xbox Live SDK - August 2016</span></span>

<span data-ttu-id="62398-105">June 2016 リリースで追加された内容については、「[新規事項 - June 2016](1606-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62398-105">Please see the [What's New - June 2016](1606-whats-new.md) article for what was added in the June 2016 release.</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="62398-106">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="62398-106">OS and tool support</span></span>
<span data-ttu-id="62398-107">Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="62398-107">The Xbox Live SDK supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="documentation"></a><span data-ttu-id="62398-108">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="62398-108">Documentation</span></span>
- <span data-ttu-id="62398-109">UWP アプリケーションを作成していて、ゲームにユーザーを招待する機能を実装する場合は、「[マルチプレイヤー用に AppXManifest を構成する](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md)」に ```.appxmanifest``` で必要な変更についての説明があります。</span><span class="sxs-lookup"><span data-stu-id="62398-109">If you are writing a UWP application, and are implementing the ability to invite users to a game, there are instructions on the ```.appxmanifest``` changes necessary in [Configure Your AppXManifest For Multiplayer](../multiplayer/service-configuration/configure-your-appxmanifest-for-multiplayer.md).</span></span>  <span data-ttu-id="62398-110">これは、これまでに[フォーラム](https://forums.xboxlive.com)および記事「[ERA から UWP への Xbox Live コードの移植](../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」で解説されていたものです。</span><span class="sxs-lookup"><span data-stu-id="62398-110">this was previously discussed on the [forums](https://forums.xboxlive.com) and the [porting xbox live code from era to uwp](../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md) article</span></span>
- <span data-ttu-id="62398-111">記事「[Social Manager の概要](../social-platform/intro-to-social-manager.md)」が更新され、最新の API の変更が反映されて、一部の関数のリターン コードの詳細が提供されるようになりました。</span><span class="sxs-lookup"><span data-stu-id="62398-111">The [Introduction to Social Manager](../social-platform/intro-to-social-manager.md) article has been updated to reflect recent API changes, and provide more information about return codes for some of the functions.</span></span>

## <a name="unity-samples"></a><span data-ttu-id="62398-112">Unity のサンプル</span><span class="sxs-lookup"><span data-stu-id="62398-112">Unity Samples</span></span>
<span data-ttu-id="62398-113">UWP アプリケーションを作成する Unity デベロッパーのために、複数の新しいサンプルが追加されました。</span><span class="sxs-lookup"><span data-stu-id="62398-113">Some new samples have been added for Unity developers writing a UWP application.</span></span>
- <span data-ttu-id="62398-114">Social サンプルの Unity バージョンが Samples/Social/Unity ディレクトリにあります。</span><span class="sxs-lookup"><span data-stu-id="62398-114">There is now a Unity version of the Social sample, you can find this under the Samples/Social/Unity directory.</span></span>
- <span data-ttu-id="62398-115">また、接続ストレージの使用方法を説明するサンプルもあります。</span><span class="sxs-lookup"><span data-stu-id="62398-115">There is also a sample describing how to use Connected Storage.</span></span>  <span data-ttu-id="62398-116">サンプルについては、Samples/GameSave/Unity を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62398-116">Please see Samples/GameSave/Unity for the sample.</span></span>
<span data-ttu-id="62398-117">AchievementsLeaderboard の Unity バージョンが Samples/AchievementsLeaderboard/Unity にあります。</span><span class="sxs-lookup"><span data-stu-id="62398-117">There is a Unity version of AchievementsLeaderboard under Samples/AchievementsLeaderboard/Unity</span></span>

## <a name="social-manager"></a><span data-ttu-id="62398-118">Social Manager</span><span class="sxs-lookup"><span data-stu-id="62398-118">Social Manager</span></span>
<span data-ttu-id="62398-119">上で説明したドキュメントの更新に加えて、新しい API がいくつか追加されています。</span><span class="sxs-lookup"><span data-stu-id="62398-119">In addition to the documentation updates mentioned above, there are some new APIs that have been added.</span></span>  <span data-ttu-id="62398-120">以下ではそれについて説明します。詳細については social_manager.h を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62398-120">These are described below, and you can see more detail in social_manager.h</span></span>

- <span data-ttu-id="62398-121">再作成しなくてもソーシャル グループを更新できる新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="62398-121">Added new API that allows updating of social groups without recreation:</span></span>

```cpp
    _XSAPIIMP xbox_live_result<void> update_social_user_group(
        _In_ const std::shared_ptr<xbox_social_user_group>& group,
        _In_ const std::vector<string_t>& users
        );
```
- <span data-ttu-id="62398-122">ソーシャル グループの更新の完了は、```social_user_group_updated``` イベントにより示されます。</span><span class="sxs-lookup"><span data-stu-id="62398-122">A completed update of social group is indicated by the ```social_user_group_updated``` event</span></span>


## <a name="multiplayer"></a><span data-ttu-id="62398-123">マルチプレイヤー</span><span class="sxs-lookup"><span data-stu-id="62398-123">Multiplayer</span></span>
<span data-ttu-id="62398-124">セッションの参照が強化され、新しいマルチプレイヤー API を使用してそれを利用できます。</span><span class="sxs-lookup"><span data-stu-id="62398-124">Improved session browsing is now available and you can use new Multiplayer  APIs to utilize it.</span></span>

<span data-ttu-id="62398-125">新しい API を使用すると、タグ、文字列、その他の多くのデータでフィルター処理を行うことができ、ユーザーはプレイしたいセッションをより簡単に検索できます。</span><span class="sxs-lookup"><span data-stu-id="62398-125">Using the new APIs, you can filter on tags, strings, and other rich data to allow users to more easily find a session that they want to play.</span></span>

<span data-ttu-id="62398-126">数か月以内に詳細なドキュメントが公開されますが、簡単に説明しておくと、```set_search_handle``` を使用して "検索ハンドル" を MPSD セッションと関連付けることができるようになり、タイトルで呼び出すことでユーザーは堅牢なフィルタリング メカニズムを使用してセッションを検索できます。</span><span class="sxs-lookup"><span data-stu-id="62398-126">We will be posting more comprehensive documentation in the coming months, but briefly you can now associate a "search handle" with an MPSD Session using ```set_search_handle``` and then users can search for sessions using a robust filtering mechanism by your title calling</span></span> ```get_search_handles```

<span data-ttu-id="62398-127">新しい API は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="62398-127">The new APIs are listed below.</span></span>  <span data-ttu-id="62398-128">試してみて、問題がある場合は、[フォーラム](https://forums.xboxlive.com)でサポート スレッドを投稿するか、DAM に連絡してください。</span><span class="sxs-lookup"><span data-stu-id="62398-128">Please try them out, and if you encounter any issues, post a support thread in the [forums](https://forums.xboxlive.com) or reach out to your DAM.</span></span>  <span data-ttu-id="62398-129">これらの API の使用例を近日中に公開します。</span><span class="sxs-lookup"><span data-stu-id="62398-129">We will have examples of how to use these APIs soon.</span></span>

```cpp
_XSAPIIMP pplx::task<xbox_live_result<void>> set_search_handle(
    _In_ multiplayer_search_handle_request searchHandleRequest
    );
```

```cpp
_XSAPIIMP pplx::task<xbox_live_result<std::vector<multiplayer_search_handle_details>>> get_search_handles(
    _In_ const string_t& serviceConfigurationId,
    _In_ const string_t& sessionTemplateName,
    _In_ const string_t& orderBy,
    _In_ bool orderAscending,
    _In_ const string_t& searchQuery
    );
```

```cpp
_XSAPIIMP pplx::task<xbox_live_result<void>> clear_search_handle(_In_ const string_t& handleId);
```

### <a name="xbox-integrated-multiplayer"></a><span data-ttu-id="62398-130">Xbox Integrated Multiplayer</span><span class="sxs-lookup"><span data-stu-id="62398-130">Xbox Integrated Multiplayer</span></span>

<span data-ttu-id="62398-131">Xbox Integrated Multiplayer (XIM) API のドキュメントが追加されました。</span><span class="sxs-lookup"><span data-stu-id="62398-131">We have included documentation for the Xbox Integrated Multiplayer (XIM) API.</span></span>  <span data-ttu-id="62398-132">API 自体は Xbox Live SDK の今後のリリースで利用可能になりますが、ドキュメントとヘッダーはプレビュー用に利用できます。</span><span class="sxs-lookup"><span data-stu-id="62398-132">The API itself will be available in a subsequent release of the Xbox Live SDK, but the documentation and header are being made available for preview.</span></span>

<span data-ttu-id="62398-133">XIM は、Xbox Live サービスの機能を使用してマルチプレイヤー リアルタイム ネットワークおよびチャット コミュニケーションをゲームに簡単に追加できる自己完結型のインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="62398-133">XIM is a self-contained interface for easily adding multiplayer real-time networking and chat communication to your game through the power of Xbox Live services.</span></span>

<span data-ttu-id="62398-134">ユーザーのフィードバックと問い合わせを促進するため、この API のプレビュー ドキュメントが提供されています。</span><span class="sxs-lookup"><span data-stu-id="62398-134">This preview of the API’s documentation is shared here to encourage customer feedback and inquiry.</span></span> <span data-ttu-id="62398-135">Xfest 2016 では、前の手順では、この API を話しし、アーカイブ[対象パートナー開発者向けのサイトのプレゼンテーション資料](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2016.aspx)から、「有効にするキー Multiplayer Networking and Chat」の説明を確認できます。</span><span class="sxs-lookup"><span data-stu-id="62398-135">We talked about this API earlier at Xfest 2016, and you can see archived [presentation material on the managed partner developer site](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2016.aspx) from the “Turn-Key Multiplayer Networking and Chat” talk.</span></span> <span data-ttu-id="62398-136">このプレビュー ドキュメントは C++ API 用だけであることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="62398-136">Note that this preview documentation is only for the C++ API.</span></span> <span data-ttu-id="62398-137">C# と同等の WinRT および他の言語については今年後半にリリースされます。</span><span class="sxs-lookup"><span data-stu-id="62398-137">WinRT equivalents for C# and other languages will be released later in the year.</span></span>

<span data-ttu-id="62398-138">XIM の機能に関心がある場合、およびこのプロジェクトについてフィードバックまたは質問がある場合は、[Xbox デベロッパー フォーラム](https://forums.xboxlive.com/)に投稿するか、デベロッパー アカウント マネージャーにお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="62398-138">If you are interested in XIM’s capabilities, have feedback or other questions about this project, please feel free to post on the [Xbox Developer Forum](https://forums.xboxlive.com/) or reach out through your developer account manager.</span></span>

<span data-ttu-id="62398-139">この新しいドキュメントは、Xbox Live SDK の Docs ディレクトリの xbox_integrated_multiplayer.chm にあります。</span><span class="sxs-lookup"><span data-stu-id="62398-139">You can see this new documentation in xbox_integrated_multiplayer.chm in the Docs directory of the Xbox Live SDK.</span></span>  <span data-ttu-id="62398-140">プレビュー版のインクルード ファイルは、\include\xim\XboxIntegratedMultiplayer.h にあります。</span><span class="sxs-lookup"><span data-stu-id="62398-140">The include file is available as a preview in \include\xim\XboxIntegratedMultiplayer.h.</span></span>  
