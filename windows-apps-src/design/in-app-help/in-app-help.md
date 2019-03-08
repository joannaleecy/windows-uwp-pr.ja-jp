---
Description: Design effective help to be displayed reactively inside your app.
title: アプリ内ヘルプの設計のためのガイドライン。
label: In-app help
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 6208b71b-37a7-40f5-91b0-19b665e7458a
ms.localizationpriority: medium
ms.openlocfilehash: 4783d28e4da6c06df0d0676f4a7d28ef3995481a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610057"
---
# <a name="in-app-help-pages"></a><span data-ttu-id="5ef30-104">アプリ内ヘルプのページ</span><span class="sxs-lookup"><span data-stu-id="5ef30-104">In-app help pages</span></span>

<span data-ttu-id="5ef30-105">多くの場合、ヘルプはアプリケーション内でユーザーがヘルプの表示を選択したときに表示されることが望ましい方法です。</span><span class="sxs-lookup"><span data-stu-id="5ef30-105">Most of the time, it is best that help be displayed within the application and when the user chooses to view it.</span></span>

## <a name="when-to-use-in-app-help-pages"></a><span data-ttu-id="5ef30-106">アプリ内ヘルプのページを使用する状況</span><span class="sxs-lookup"><span data-stu-id="5ef30-106">When to use in-app help pages</span></span>

<span data-ttu-id="5ef30-107">アプリ内ヘルプは、ユーザーにヘルプを表示する既定の方法として使用します。</span><span class="sxs-lookup"><span data-stu-id="5ef30-107">In-app help should be the default method of displaying help for the user.</span></span> <span data-ttu-id="5ef30-108">これはすべてのヘルプで使用し、シンプルで単純にして、ユーザーに未知のコンテンツを表示しないようにします。</span><span class="sxs-lookup"><span data-stu-id="5ef30-108">It should be used for any help which is simple, straightforward, and does not introduce new content to the user.</span></span> <span data-ttu-id="5ef30-109">使用方法、アドバイス、ヒントやコツなどはすべて、アプリ内ヘルプに適しています。</span><span class="sxs-lookup"><span data-stu-id="5ef30-109">Instructions, advice, and tips & tricks are all suitable for in-app help.</span></span>

<span data-ttu-id="5ef30-110">複雑な使用方法やチュートリアルはすばやい参照には適しておらず、また大量の領域を占有します。</span><span class="sxs-lookup"><span data-stu-id="5ef30-110">Complex instructions or tutorials are not easy to reference quickly, and they take up large amounts of space.</span></span> <span data-ttu-id="5ef30-111">そのため、それらはアプリ自体には組み込まず、外部で提供するようにします。</span><span class="sxs-lookup"><span data-stu-id="5ef30-111">Therefore, they should be hosted externally, and not incorporated into the app itself.</span></span>

<span data-ttu-id="5ef30-112">Users should not have to seek out help for basic instructions or to discover new features.</span><span class="sxs-lookup"><span data-stu-id="5ef30-112">Users should not have to seek out help for basic instructions or to discover new features.</span></span> <span data-ttu-id="5ef30-113">ユーザーのためになる情報を提供する場合には、説明 UI を使用します。</span><span class="sxs-lookup"><span data-stu-id="5ef30-113">If you need to have help that educates users, use instructional UI.</span></span>

## <a name="types-of-in-app-help"></a><span data-ttu-id="5ef30-114">アプリ内ヘルプの種類</span><span class="sxs-lookup"><span data-stu-id="5ef30-114">Types of In-app help</span></span>

<span data-ttu-id="5ef30-115">アプリ内ヘルプにはいくつかの形式がありますが、それらはすべて同じ設計と操作性の原則に従っています。</span><span class="sxs-lookup"><span data-stu-id="5ef30-115">In-app help can come in several forms, though they all follow the same general principles of design and usability.</span></span>

#### <a name="help-pages"></a><span data-ttu-id="5ef30-116">ヘルプ ページ</span><span class="sxs-lookup"><span data-stu-id="5ef30-116">Help Pages</span></span>

<span data-ttu-id="5ef30-117">アプリ内に別のヘルプ ページを作成することは、役に立つ使用方法を表示するための、すばやく手軽な方法です。</span><span class="sxs-lookup"><span data-stu-id="5ef30-117">Having a separate page or pages of help within your app is a quick and easy way of displaying useful instructions.</span></span>

-   <span data-ttu-id="5ef30-118">**簡潔になります。** ヘルプ トピックの大規模なライブラリとは、扱いにくいとアプリ内のヘルプの unsuited です。</span><span class="sxs-lookup"><span data-stu-id="5ef30-118">**Be concise:** A large library of help topics is unwieldy and unsuited for in-app help.</span></span>
-   <span data-ttu-id="5ef30-119">**一貫性のあるになります。** ユーザーに到達できること、ヘルプ ページ、アプリの任意の部分から同じ方法を確認します。</span><span class="sxs-lookup"><span data-stu-id="5ef30-119">**Be consistent:** Make sure that users can reach your help pages the same way from any part of your app.</span></span> <span data-ttu-id="5ef30-120">ユーザーがヘルプを探し回る必要がないようにします。</span><span class="sxs-lookup"><span data-stu-id="5ef30-120">They should never have to search for it.</span></span>
-   <span data-ttu-id="5ef30-121">**ユーザーをスキャンする、読み取ることができません。** 他のヘルプ トピックと同じページには、ユーザーが探してヘルプ可能性があります、ために注目する必要がある、1 つに簡単に通知できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="5ef30-121">**Users scan, not read:** Because the help a user is looking for might be on the same page as other help topics, make sure they can easily tell which one they need to focus on.</span></span>


#### <a name="popups"></a><span data-ttu-id="5ef30-122">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="5ef30-122">Popups</span></span>

<span data-ttu-id="5ef30-123">ポップアップを使うと、高度なコンテキスト ヘルプを実現でき、ユーザーが実行している具体的なタスクに直接役立つ手順やアドバイスを表示できます。</span><span class="sxs-lookup"><span data-stu-id="5ef30-123">Popups allow for highly contexual help, displaying instructions and advice that is relevant to the specific task that the user is attempting.</span></span>

-   <span data-ttu-id="5ef30-124">**1 つの問題に集中します。** 領域は、ヘルプ ページよりもポップアップより制限されます。</span><span class="sxs-lookup"><span data-stu-id="5ef30-124">**Focus on one issue:** Space is even more restricted in a popup than a help page.</span></span> <span data-ttu-id="5ef30-125">ヘルプ ポップアップを効果的にするには、1 つの具体的なタスクのみに関して説明するようにします。</span><span class="sxs-lookup"><span data-stu-id="5ef30-125">Help popups needs to refer specifically a single task to be effective.</span></span>
-   <span data-ttu-id="5ef30-126">**可視性が重要です。** ヘルプ ポップアップは、1 つの場所からのみ参照できます、ため obstructive でなくて、ユーザーに明確に表示される、いることを確認します。</span><span class="sxs-lookup"><span data-stu-id="5ef30-126">**Visibility is important:** Because help popups can only be viewed from one location, make sure that they're clearly visible to the user without being obstructive.</span></span> <span data-ttu-id="5ef30-127">If the user misses it, they might move away from the popup in search of a help page.</span><span class="sxs-lookup"><span data-stu-id="5ef30-127">If the user misses it, they might move away from the popup in search of a help page.</span></span>
-   <span data-ttu-id="5ef30-128">**多くのリソースを使用しないでください。** ヘルプ、ラグべきではないまたはがの読み込みが遅い。</span><span class="sxs-lookup"><span data-stu-id="5ef30-128">**Don't use too many resources:** Help shouldn't lag or be slow-loading.</span></span> <span data-ttu-id="5ef30-129">Using videos or audio files or high resolution images in popups is more likely to frustrate the user than it is to help them.</span><span class="sxs-lookup"><span data-stu-id="5ef30-129">Using videos or audio files or high resolution images in popups is more likely to frustrate the user than it is to help them.</span></span>

#### <a name="descriptions"></a><span data-ttu-id="5ef30-130">説明</span><span class="sxs-lookup"><span data-stu-id="5ef30-130">Descriptions</span></span>

<span data-ttu-id="5ef30-131">Sometimes, it can be useful to provide more information about a feature when a user inspects it.</span><span class="sxs-lookup"><span data-stu-id="5ef30-131">Sometimes, it can be useful to provide more information about a feature when a user inspects it.</span></span> <span data-ttu-id="5ef30-132">説明は、説明 UI に似ていますが、説明 UI はユーザーが知らない機能についてユーザーに教えようとするものであり、詳細な説明はユーザーが既に関心を持っているアプリの機能についてのユーザーの理解を深めるためのものであることが、主な相違点です。</span><span class="sxs-lookup"><span data-stu-id="5ef30-132">Descriptions are similar to instructive UI, but the key difference is that instructional UI attempts to teach and educate the user about features that they don't know about, whereas detailed descriptions enhance a user's understanding of app features that they're already interested in.</span></span>

-   <span data-ttu-id="5ef30-133">**基本は得られません。** ユーザーが記述されている項目を使用する方法の基礎を既に知っていることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="5ef30-133">**Don't teach the basics:** Assume that the user already knows the fundamentals of how to use the item being described.</span></span> <span data-ttu-id="5ef30-134">Clarifying or offering further information is useful.</span><span class="sxs-lookup"><span data-stu-id="5ef30-134">Clarifying or offering further information is useful.</span></span> <span data-ttu-id="5ef30-135">Telling them what they already know is not.</span><span class="sxs-lookup"><span data-stu-id="5ef30-135">Telling them what they already know is not.</span></span>
-   <span data-ttu-id="5ef30-136">**興味深い相互作用をについて説明します。** について既に理解している機能のやり取りの方法でユーザーを教育する説明については最適な使用方法の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="5ef30-136">**Describe interesting interactions:** One of the best uses for descriptions is to educate the user on how a features that they already know about can interact.</span></span> <span data-ttu-id="5ef30-137">This helps users learn more about things they already like to use.</span><span class="sxs-lookup"><span data-stu-id="5ef30-137">This helps users learn more about things they already like to use.</span></span>
-   <span data-ttu-id="5ef30-138">**邪魔を維持します。** UI の説明のように説明が、アプリのユーザーの本を邪魔しないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ef30-138">**Stay out of the way:** Much like instructional UI, descriptions need to avoid interfering with a user's enjoyment of the app.</span></span>

## <a name="related-articles"></a><span data-ttu-id="5ef30-139">関連記事</span><span class="sxs-lookup"><span data-stu-id="5ef30-139">Related articles</span></span>

* [<span data-ttu-id="5ef30-140">アプリのヘルプに関するガイドライン</span><span class="sxs-lookup"><span data-stu-id="5ef30-140">Guidelines for app help</span></span>](guidelines-for-app-help.md)
