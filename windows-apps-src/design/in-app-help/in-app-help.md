---
author: QuinnRadich
Description: Design effective help to be displayed reactively inside your app.
title: アプリ内ヘルプの設計のためのガイドライン。
label: In-app help
template: detail.hbs
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 6208b71b-37a7-40f5-91b0-19b665e7458a
ms.localizationpriority: medium
ms.openlocfilehash: 089b71464234abe21d7dc8613d46ef6778f0f5a6
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5768978"
---
# <a name="in-app-help-pages"></a><span data-ttu-id="87798-103">アプリ内ヘルプのページ</span><span class="sxs-lookup"><span data-stu-id="87798-103">In-app help pages</span></span>

<span data-ttu-id="87798-104">多くの場合、ヘルプはアプリケーション内でユーザーがヘルプの表示を選択したときに表示されることが望ましい方法です。</span><span class="sxs-lookup"><span data-stu-id="87798-104">Most of the time, it is best that help be displayed within the application and when the user chooses to view it.</span></span>

## <a name="when-to-use-in-app-help-pages"></a><span data-ttu-id="87798-105">アプリ内ヘルプのページを使用する状況</span><span class="sxs-lookup"><span data-stu-id="87798-105">When to use in-app help pages</span></span>

<span data-ttu-id="87798-106">アプリ内ヘルプは、ユーザーにヘルプを表示する既定の方法として使用します。</span><span class="sxs-lookup"><span data-stu-id="87798-106">In-app help should be the default method of displaying help for the user.</span></span> <span data-ttu-id="87798-107">これはすべてのヘルプで使用し、シンプルで単純にして、ユーザーに未知のコンテンツを表示しないようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-107">It should be used for any help which is simple, straightforward, and does not introduce new content to the user.</span></span> <span data-ttu-id="87798-108">使用方法、アドバイス、ヒントやコツなどはすべて、アプリ内ヘルプに適しています。</span><span class="sxs-lookup"><span data-stu-id="87798-108">Instructions, advice, and tips & tricks are all suitable for in-app help.</span></span>

<span data-ttu-id="87798-109">複雑な使用方法やチュートリアルはすばやい参照には適しておらず、また大量の領域を占有します。</span><span class="sxs-lookup"><span data-stu-id="87798-109">Complex instructions or tutorials are not easy to reference quickly, and they take up large amounts of space.</span></span> <span data-ttu-id="87798-110">そのため、それらはアプリ自体には組み込まず、外部で提供するようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-110">Therefore, they should be hosted externally, and not incorporated into the app itself.</span></span>

<span data-ttu-id="87798-111">Users should not have to seek out help for basic instructions or to discover new features.</span><span class="sxs-lookup"><span data-stu-id="87798-111">Users should not have to seek out help for basic instructions or to discover new features.</span></span> <span data-ttu-id="87798-112">ユーザーのためになる情報を提供する場合には、説明 UI を使用します。</span><span class="sxs-lookup"><span data-stu-id="87798-112">If you need to have help that educates users, use instructional UI.</span></span>

## <a name="types-of-in-app-help"></a><span data-ttu-id="87798-113">アプリ内ヘルプの種類</span><span class="sxs-lookup"><span data-stu-id="87798-113">Types of In-app help</span></span>

<span data-ttu-id="87798-114">アプリ内ヘルプにはいくつかの形式がありますが、それらはすべて同じ設計と操作性の原則に従っています。</span><span class="sxs-lookup"><span data-stu-id="87798-114">In-app help can come in several forms, though they all follow the same general principles of design and usability.</span></span>

#### <a name="help-pages"></a><span data-ttu-id="87798-115">ヘルプ ページ</span><span class="sxs-lookup"><span data-stu-id="87798-115">Help Pages</span></span>

<span data-ttu-id="87798-116">アプリ内に別のヘルプ ページを作成することは、役に立つ使用方法を表示するための、すばやく手軽な方法です。</span><span class="sxs-lookup"><span data-stu-id="87798-116">Having a separate page or pages of help within your app is a quick and easy way of displaying useful instructions.</span></span>

-   <span data-ttu-id="87798-117">**簡潔にする:** 大規模なライブラリのヘルプ トピックは扱いにくく、アプリ内ヘルプに適しません。</span><span class="sxs-lookup"><span data-stu-id="87798-117">**Be concise:** A large library of help topics is unwieldy and unsuited for in-app help.</span></span>
-   <span data-ttu-id="87798-118">**一貫性を持たせる:** アプリ内のどこからでも、同じ方法でヘルプ ページを表示できるようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-118">**Be consistent:** Make sure that users can reach your help pages the same way from any part of your app.</span></span> <span data-ttu-id="87798-119">ユーザーがヘルプを探し回る必要がないようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-119">They should never have to search for it.</span></span>
-   <span data-ttu-id="87798-120">**ユーザーはざっと読むが、熟読はしない:** ユーザーが求めている情報がページ上にある場合でも、他の情報と紛れてしまう場合があります。ユーザーが必要な情報を、容易に見つけられるようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-120">**Users scan, not read:** Because the help a user is looking for might be on the same page as other help topics, make sure they can easily tell which one they need to focus on.</span></span>


#### <a name="popups"></a><span data-ttu-id="87798-121">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="87798-121">Popups</span></span>

<span data-ttu-id="87798-122">ポップアップを使うと、高度なコンテキスト ヘルプを実現でき、ユーザーが実行している具体的なタスクに直接役立つ手順やアドバイスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="87798-122">Popups allow for highly contexual help, displaying instructions and advice that is relevant to the specific task that the user is attempting.</span></span>

-   <span data-ttu-id="87798-123">**1 つの問題に集中する:** ポップアップではヘルプ ページよりも、スペースがさらに制限されます。</span><span class="sxs-lookup"><span data-stu-id="87798-123">**Focus on one issue:** Space is even more restricted in a popup than a help page.</span></span> <span data-ttu-id="87798-124">ヘルプ ポップアップを効果的にするには、1 つの具体的なタスクのみに関して説明するようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-124">Help popups needs to refer specifically a single task to be effective.</span></span>
-   <span data-ttu-id="87798-125">**可視性が重要:** ヘルプ ポップアップは 1 つの場所からのみ表示できるため、妨げになることなく、ユーザーに明確に見えるようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-125">**Visibility is important:** Because help popups can only be viewed from one location, make sure that they're clearly visible to the user without being obstructive.</span></span> <span data-ttu-id="87798-126">If the user misses it, they might move away from the popup in search of a help page.</span><span class="sxs-lookup"><span data-stu-id="87798-126">If the user misses it, they might move away from the popup in search of a help page.</span></span>
-   <span data-ttu-id="87798-127">**多くのリソースを使用しない:** ヘルプが遅延を生じたり、読み込みに時間がかからないようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-127">**Don't use too many resources:** Help shouldn't lag or be slow-loading.</span></span> <span data-ttu-id="87798-128">Using videos or audio files or high resolution images in popups is more likely to frustrate the user than it is to help them.</span><span class="sxs-lookup"><span data-stu-id="87798-128">Using videos or audio files or high resolution images in popups is more likely to frustrate the user than it is to help them.</span></span>

#### <a name="descriptions"></a><span data-ttu-id="87798-129">説明</span><span class="sxs-lookup"><span data-stu-id="87798-129">Descriptions</span></span>

<span data-ttu-id="87798-130">Sometimes, it can be useful to provide more information about a feature when a user inspects it.</span><span class="sxs-lookup"><span data-stu-id="87798-130">Sometimes, it can be useful to provide more information about a feature when a user inspects it.</span></span> <span data-ttu-id="87798-131">説明は、説明 UI に似ていますが、説明 UI はユーザーが知らない機能についてユーザーに教えようとするものであり、詳細な説明はユーザーが既に関心を持っているアプリの機能についてのユーザーの理解を深めるためのものであることが、主な相違点です。</span><span class="sxs-lookup"><span data-stu-id="87798-131">Descriptions are similar to instructive UI, but the key difference is that instructional UI attempts to teach and educate the user about features that they don't know about, whereas detailed descriptions enhance a user's understanding of app features that they're already interested in.</span></span>

-   <span data-ttu-id="87798-132">**ユーザーに基本事項を教えない:** ユーザーは、説明されている項目の基本的な使い方についてはわかっていることを前提にします。</span><span class="sxs-lookup"><span data-stu-id="87798-132">**Don't teach the basics:** Assume that the user already knows the fundamentals of how to use the item being described.</span></span> <span data-ttu-id="87798-133">Clarifying or offering further information is useful.</span><span class="sxs-lookup"><span data-stu-id="87798-133">Clarifying or offering further information is useful.</span></span> <span data-ttu-id="87798-134">Telling them what they already know is not.</span><span class="sxs-lookup"><span data-stu-id="87798-134">Telling them what they already know is not.</span></span>
-   <span data-ttu-id="87798-135">**興味を引く操作について説明する:** 説明の最適な使用方法の 1 つは、ユーザーが既に知っている機能の操作の方法を説明することです。</span><span class="sxs-lookup"><span data-stu-id="87798-135">**Describe interesting interactions:** One of the best uses for descriptions is to educate the user on how a features that they already know about can interact.</span></span> <span data-ttu-id="87798-136">This helps users learn more about things they already like to use.</span><span class="sxs-lookup"><span data-stu-id="87798-136">This helps users learn more about things they already like to use.</span></span>
-   <span data-ttu-id="87798-137">**ユーザーを妨げない:** 説明 UI の場合と同様に、説明はユーザーのアプリの使用を妨げないようにします。</span><span class="sxs-lookup"><span data-stu-id="87798-137">**Stay out of the way:** Much like instructional UI, descriptions need to avoid interfering with a user's enjoyment of the app.</span></span>

## <a name="related-articles"></a><span data-ttu-id="87798-138">関連記事</span><span class="sxs-lookup"><span data-stu-id="87798-138">Related articles</span></span>

* [<span data-ttu-id="87798-139">アプリのヘルプのガイドライン</span><span class="sxs-lookup"><span data-stu-id="87798-139">Guidelines for app help</span></span>](guidelines-for-app-help.md)
