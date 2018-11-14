---
title: Xbox Live SDK の新規事項 - June 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - June 2016
ms.assetid: 306e7fa8-14f0-437f-a991-6693f5c0d6a8
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 1e6be7c4f42ebca395100cf5dac677797d936719
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6270838"
---
# <a name="whats-new-for-the-xbox-live-sdk---june-2016"></a><span data-ttu-id="8519f-104">Xbox Live SDK の新規事項 - June 2016</span><span class="sxs-lookup"><span data-stu-id="8519f-104">What's new for the Xbox Live SDK - June 2016</span></span>

<span data-ttu-id="8519f-105">April 2016 リリースで追加された内容については、「[新規事項 - April 2016](1604-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8519f-105">Please see the [What's New - April 2016](1604-whats-new.md) article for what was added in the April 2016 release.</span></span>

> <span data-ttu-id="8519f-106">**注:** Xbox 開発キット (XDK) を使用している場合、「*新規事項 - April 2016*」で、March XDK リリース以降に追加された新しい機能について説明しています。</span><span class="sxs-lookup"><span data-stu-id="8519f-106">**Note:** If you are using the Xbox Developers Kit (XDK), then the *What's New - April 2016* article covers additional new functionality that was added since the March XDK release.</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="8519f-107">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="8519f-107">OS and tool support</span></span>
<span data-ttu-id="8519f-108">Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="8519f-108">The Xbox Live SDK supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="contextual-search"></a><span data-ttu-id="8519f-109">コンテキスト検索</span><span class="sxs-lookup"><span data-stu-id="8519f-109">Contextual Search</span></span>
<span data-ttu-id="8519f-110">`contextual_search` API に、ゲーム クリップを取得するための新しいクラスが以下のとおり追加されました。</span><span class="sxs-lookup"><span data-stu-id="8519f-110">The following new classes have been added to the `contextual_search` API to retrieve game clips:</span></span>

* `contextual_search_game_clip`
* `contextual_search_game_clip_stat`
* `contextual_search_game_clip_thumbnail`
* `contextual_search_game_clip_uri_info`
* `contextual_search_game_clips_result`

<span data-ttu-id="8519f-111">詳細については、リファレンス ドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="8519f-111">See the reference documentation for more information.</span></span>

## <a name="networking"></a><span data-ttu-id="8519f-112">ネットワーキング</span><span class="sxs-lookup"><span data-stu-id="8519f-112">Networking</span></span>
<span data-ttu-id="8519f-113">単一のタイトル インスタンスでユーザーあたり 5 つ以上の WebSocket が作成された場合に、そのことを検出する新しいアサートが Xbox Live SDK に追加されました。</span><span class="sxs-lookup"><span data-stu-id="8519f-113">The Xbox Live SDK now includes a new assert that detects if 5 or more websockets are created per user in a single title instance.</span></span>

<span data-ttu-id="8519f-114">このアサートは、`disable_asserts_for_maximum_number_of_websockets_activated()` を呼び出すことによって無効化できます。</span><span class="sxs-lookup"><span data-stu-id="8519f-114">You can disable this assert by calling `disable_asserts_for_maximum_number_of_websockets_activated()`.</span></span>

> <span data-ttu-id="8519f-115">**注:** Social Manager および Multiplayer Manager では、タイトルでこれらの機能を使用する場合、単一の結合された WebSocket を使用します。</span><span class="sxs-lookup"><span data-stu-id="8519f-115">**Note:** Social Manager and Multiplayer Manager use a single combined websocket if you use these features in your title.</span></span>

## <a name="tools"></a><span data-ttu-id="8519f-116">ツール</span><span class="sxs-lookup"><span data-stu-id="8519f-116">Tools</span></span>
* <span data-ttu-id="8519f-117">Xbox Live Resiliency Plugin For Fiddler が Xbox Live SDK に含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="8519f-117">The Xbox Live Resiliency Plugin For Fiddler is now included in the Xbox Live SDK.</span></span>  
<span data-ttu-id="8519f-118">これは Fiddler のアドオンであり、デベロッパーが Xbox Live の呼び出しを選択的にブロックできるようにします。</span><span class="sxs-lookup"><span data-stu-id="8519f-118">It is an add-on to Fiddler that enables developers to selectively block calls to Xbox Live.</span></span>
<span data-ttu-id="8519f-119">デベロッパーはこのプラグインを使用して、ゲーム タイトルの部分的なサービス中断における回復性をテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="8519f-119">Using this plugin, developers can test resiliency across partial service disruptions in their game titles.</span></span>
<span data-ttu-id="8519f-120">ツールには、多数の Xbox Live サービス エンドポイントの組み込みと、テスト対象のさまざまなエラー タイプが含まれています。</span><span class="sxs-lookup"><span data-stu-id="8519f-120">The tool includes a number of Xbox Live service endpoints built-in and different error types to test against.</span></span>
<span data-ttu-id="8519f-121">すべての Xbox One および UWP タイトルがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="8519f-121">All Xbox One and UWP titles are supported.</span></span>
