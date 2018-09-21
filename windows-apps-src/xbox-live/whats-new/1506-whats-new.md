---
title: Xbox Live SDK の新規事項 - June 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - June 2015
ms.assetid: 354bcd47-2564-4dd5-89e3-242bca462b35
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 29e31363a1afb0d01d24112a4fa8dd69f4f87bff
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4111059"
---
# <a name="whats-new-for-the-xbox-live-sdk---june-2015"></a><span data-ttu-id="2e54a-104">Xbox Live SDK の新規事項 - June 2015</span><span class="sxs-lookup"><span data-stu-id="2e54a-104">What's new for the Xbox Live SDK - June 2015</span></span>

<span data-ttu-id="2e54a-105">Xbox Live SDK の June リリースには、次の更新が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2e54a-105">The June release of the Xbox Live SDK includes the following updates:</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="2e54a-106">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="2e54a-106">OS and tool support</span></span> ##
<span data-ttu-id="2e54a-107">Xbox Live SDK で、Windows 10 と Visual Studio 2015 RC の最新の Insider ビルドがサポートされるようになりました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-107">The Xbox Live SDK now supports the latest Insider build of Windows 10 and Visual Studio 2015 RC.</span></span>

## <a name="title-callable-ui-apis"></a><span data-ttu-id="2e54a-108">Title Callable UI API</span><span class="sxs-lookup"><span data-stu-id="2e54a-108">Title Callable UI APIs</span></span>

| <span data-ttu-id="2e54a-109">注</span><span class="sxs-lookup"><span data-stu-id="2e54a-109">Note</span></span> |
|------|
| <span data-ttu-id="2e54a-110">このセクションは、UWP タイトルにのみ適用されます。XDK タイトルは、TCUI の Windows.Xbox.UI.SystemUI クラスを参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e54a-110">This section only applies to UWP titles, XDK titles should refer to the Windows.Xbox.UI.SystemUI class for TCUI</span></span>  |

<span data-ttu-id="2e54a-111">Xbox Live SDK に、Windows 10 PC/Mobile デバイスでストップ UI を表示するための Title Callable UI (TCUI) をサポートするラッパー API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-111">The Xbox Live SDK now contains wrapper APIs that support Title Callable UI (TCUI) for displaying stock UI on a Windows 10 PC/Mobile device.</span></span>

<span data-ttu-id="2e54a-112">これらの API は UWP アプリでのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="2e54a-112">These APIs are only available for UWP apps.</span></span>

<span data-ttu-id="2e54a-113">TCUI ラッパーは、TitleCallableUI (WinRT) クラスと title_callable_ui (C++) クラスから呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="2e54a-113">You can call the TCUI wrappers from the TitleCallableUI (WinRT) and title_callable_ui (C++) classes.</span></span>

<span data-ttu-id="2e54a-114">ストック UI には次のものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="2e54a-114">The stock UIs include:</span></span>
* <span data-ttu-id="2e54a-115">プレーヤー ピッカー UI</span><span class="sxs-lookup"><span data-stu-id="2e54a-115">A player picker UI</span></span>
* <span data-ttu-id="2e54a-116">ゲームへの招待ピッカー UI</span><span class="sxs-lookup"><span data-stu-id="2e54a-116">A game invite picker UI</span></span>
* <span data-ttu-id="2e54a-117">プレーヤー プロフィール カード UI</span><span class="sxs-lookup"><span data-stu-id="2e54a-117">A player profile card UI</span></span>
* <span data-ttu-id="2e54a-118">フレンドの追加/削除 UI</span><span class="sxs-lookup"><span data-stu-id="2e54a-118">An add/remove friend UI</span></span>
* <span data-ttu-id="2e54a-119">ゲーム タイトルの実績の表示 UI</span><span class="sxs-lookup"><span data-stu-id="2e54a-119">A show game title achievements UI</span></span>

<span data-ttu-id="2e54a-120">新しい API の使用例については、新しい *TCUI* サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2e54a-120">See the new *TCUI* sample for example usage of the new APIs.</span></span> <span data-ttu-id="2e54a-121">サンプルは、{*SDK ソースのルート*}\Samples\TCUI にあります。</span><span class="sxs-lookup"><span data-stu-id="2e54a-121">You can find the sample under {*SDK source root*}\Samples\TCUI.</span></span>

## <a name="new-authentication-model-for-uwp-apps"></a><span data-ttu-id="2e54a-122">UWP アプリの新しい認証モデル</span><span class="sxs-lookup"><span data-stu-id="2e54a-122">New authentication model for UWP apps</span></span>
<span data-ttu-id="2e54a-123">Xbox Live SDK に、Windows 10 PC/Mobile デバイスでストップ UI を表示するための Title Callable UI (TCUI) をサポートするラッパー API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-123">The Xbox Live SDK now supports using a Microsoft Account (MSA) for identifying the Xbox Live player on a Windows 10 PC/Mobile device.</span></span>

<span data-ttu-id="2e54a-124">XboxLiveUser (WinRT) クラスと xbox_live_user (C++) クラスを使ってユーザーをサインインできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-124">You can now sign in a user by using the XboxLiveUser (WinRT) and xbox_live_user (C++) classes.</span></span>

## <a name="new-api-for-writing-events-in-uwp-apps"></a><span data-ttu-id="2e54a-125">UWP アプリでイベントを書き込むための新しい API</span><span class="sxs-lookup"><span data-stu-id="2e54a-125">New API for writing events in UWP apps</span></span>

| <span data-ttu-id="2e54a-126">注</span><span class="sxs-lookup"><span data-stu-id="2e54a-126">Note</span></span> |
|------|
| <span data-ttu-id="2e54a-127">このセクションは、UWP タイトルにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="2e54a-127">This section only applies to UWP titles.</span></span>  <span data-ttu-id="2e54a-128">XDK 開発者の方は、[ゲーム イベント](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/game-events)に関する記事で XDK 固有の詳細をご覧ください</span><span class="sxs-lookup"><span data-stu-id="2e54a-128">XDK developers should refer to the [Game Events](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/game-events) article for XDK specific information</span></span>  |

<span data-ttu-id="2e54a-129">新しい EventsService (WinRT) クラスと events_service (C++) クラスを使うと、ユーザーの統計情報、実績、ランキングなどを更新できるゲーム内イベントを書き込むことができます。これらの新しいクラスは UWP アプリでのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="2e54a-129">The new EventsService (WinRT) and events_service (C++) classes let you write in-game events that can update user stats, achievements, leaderboards, etc. These new classes are for UWP apps only.</span></span>

## <a name="breaking-change-to-event-handlers"></a><span data-ttu-id="2e54a-130">イベント ハンドラーの重要な変更</span><span class="sxs-lookup"><span data-stu-id="2e54a-130">Breaking change to event handlers</span></span> ##
<span data-ttu-id="2e54a-131">C++ SDK のすべてのイベント ハンドラーが単一の `void set_*_handler()` メソッドから `function_context add_*_handler()` メソッドと `void remove_*_handler(function_context context)` メソッドのペアに変更されました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-131">All event handlers in the C++ SDK have been changed from a single `void set_*_handler()` method to a pair of `function_context add_*_handler()` and `void remove_*_handler(function_context context)` methods.</span></span>

<span data-ttu-id="2e54a-132">各 `add_*_handler()` メソッドが `function_context` オブジェクトを返すようになりました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-132">Each `add_*_handler()` method now returns a `function_context` object.</span></span> <span data-ttu-id="2e54a-133">イベント ハンドラーを削除した場合、`function_context` オブジェクトを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e54a-133">When you remove the event handler, you must pass in the `function_context` object.</span></span>

<span data-ttu-id="2e54a-134">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="2e54a-134">For example:</span></span>
```
function_context subscriptionLostContext = xbox_live_context()->multiplayer_service().add_multiplayer_subscription_lost_handler(...);

localUser->xbox_live_context()->multiplayer_service().remove_multiplayer_subscription_lost_handler(subscriptionLostContext);
```

## <a name="new-apis-for-managing-multiplayer-scenarios"></a><span data-ttu-id="2e54a-135">マルチプレイヤー シナリオを管理するための新しい API</span><span class="sxs-lookup"><span data-stu-id="2e54a-135">New APIs for managing multiplayer scenarios</span></span>
<span data-ttu-id="2e54a-136">Xbox Live SDK に、一般的なマルチプレイヤー シナリオを管理するための C++ API のセットが追加されました。</span><span class="sxs-lookup"><span data-stu-id="2e54a-136">The Xbox Live SDK now includes a set of C++ APIs for managing common multiplayer scenarios.</span></span> <span data-ttu-id="2e54a-137">これらの API は、xbox.services.experimental.multiplayer 名前空間に含まれています。</span><span class="sxs-lookup"><span data-stu-id="2e54a-137">The APIs are included in the xbox.services.experimental.multiplayer namespace.</span></span>

<span data-ttu-id="2e54a-138">これらの API は、試験的な名前空間に含まれているため、フィードバックに応じて変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2e54a-138">These APIs are in the experimental namespace which means that they are likely to change based on feedback.</span></span>  <span data-ttu-id="2e54a-139">開発者の皆さんからのフィードバックをお待ちしています。</span><span class="sxs-lookup"><span data-stu-id="2e54a-139">We encourage developers to use them and provide feedback.</span></span>

<span data-ttu-id="2e54a-140">これらの新しい API の使用例については、新しい *MultiplayerManager* サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2e54a-140">See the new *MultiplayerManager* sample for example usage of these new APIs.</span></span> <span data-ttu-id="2e54a-141">サンプルは、{*SDK ソースのルート*}\Samples\MultiplayerManager にあります。</span><span class="sxs-lookup"><span data-stu-id="2e54a-141">You can find the sample under {*SDK source root*}\Samples\MultiplayerManager.</span></span>
