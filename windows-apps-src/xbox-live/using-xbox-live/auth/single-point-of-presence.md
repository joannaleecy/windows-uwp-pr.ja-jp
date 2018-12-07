---
title: Single Point of Presence (SPOP)
description: Xbox Live Single Point of Presence (SPOP) を使ってタイトルが一度に 1 台のデバイスでのみ再生されるようにする方法について説明します。
ms.assetid: 40f19319-9ccc-4d35-85eb-4749c2cf5ef8
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, spop, single point of presence
ms.localizationpriority: medium
ms.openlocfilehash: f1503a6168a50175e861e17027e8b642d1b7834d
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8739494"
---
# <a name="single-point-of-presence-spop"></a><span data-ttu-id="cb96b-104">Single Point of Presence (SPOP)</span><span class="sxs-lookup"><span data-stu-id="cb96b-104">Single Point of Presence (SPOP)</span></span>

## <a name="overview"></a><span data-ttu-id="cb96b-105">概要</span><span class="sxs-lookup"><span data-stu-id="cb96b-105">Overview</span></span>
<span data-ttu-id="cb96b-106">Single Point of Presence (SPOP) は、一度に 1 つのデバイスでのみタイトルを再生できるように、Xbox Live が適用する状態です。</span><span class="sxs-lookup"><span data-stu-id="cb96b-106">Single Point of Presence (SPOP), is an Xbox Live enforced condition where a title can only be played on one device at a time.</span></span> <span data-ttu-id="cb96b-107">これは、任意のデバイス上の Xbox One XDK および UWP タイトルに適用されます。</span><span class="sxs-lookup"><span data-stu-id="cb96b-107">This is enforced for Xbox One XDK and UWP titles on any device.</span></span>
<span data-ttu-id="cb96b-108">Xbox Live タイトルは、デバイスに関係なく、別の Xbox One または Windows 10 デバイス上のタイトルにサインインしているユーザーをキックできます。</span><span class="sxs-lookup"><span data-stu-id="cb96b-108">An Xbox Live title, regardless of the device it is on, can kick a user who is signed into a title on another Xbox One or Windows 10 device.</span></span>

## <a name="how-to-handle-spop"></a><span data-ttu-id="cb96b-109">SPOP を処理する方法</span><span class="sxs-lookup"><span data-stu-id="cb96b-109">How to handle SPOP</span></span>
<span data-ttu-id="cb96b-110">SPOP は、他の種類のサインアウト イベントと同じ方法でタイトルによって処理されるはずです。</span><span class="sxs-lookup"><span data-stu-id="cb96b-110">SPOP should be handled by the title the same way as any other type of sign out event.</span></span> <span data-ttu-id="cb96b-111">ユーザーは、SPOP を開始するアクションを行うときは常に、タイトルが他のデバイスで切断されることを望んでいることを確認するように UI から通知されます。</span><span class="sxs-lookup"><span data-stu-id="cb96b-111">The user will always be notified via UI when they do an action that would initiate an SPOP to verify that they would like to cause the title to be disconnected on the other device.</span></span>

* <span data-ttu-id="cb96b-112">XDK タイトルでは、これが発生するときに `User::SignOutCompleted` イベントがトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="cb96b-112">For XDK titles, the `User::SignOutCompleted` event will trigger when this occurs.</span></span>
* <span data-ttu-id="cb96b-113">UWP タイトルでは、`xbox_live_user` クラスから `sign_out_complete` ハンドラーによってサインアウトが通知されます。</span><span class="sxs-lookup"><span data-stu-id="cb96b-113">For UWP titles, they will be notified of the sign out through the `sign_out_complete` handler from the `xbox_live_user` class.</span></span> <span data-ttu-id="cb96b-114">詳細については、「[UWP プロジェクトの認証](authentication-for-UWP-projects.md)」を参照してください</span><span class="sxs-lookup"><span data-stu-id="cb96b-114">See [Authentication for UWP projects](authentication-for-UWP-projects.md) for more detail</span></span>
