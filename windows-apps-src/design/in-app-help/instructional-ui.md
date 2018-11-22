---
author: QuinnRadich
Description: Design an instructional user interface (UI) that teaches users how to work with your UWP app.
title: 説明 UI を設計するためのガイドライン
label: Instructional UI
template: detail.hbs
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: c87e2f06-339d-4413-b585-172752964f56
ms.localizationpriority: medium
ms.openlocfilehash: 9c97b6b5eca82d309a4b65a914041adeb1e782db
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7581017"
---
# <a name="instructional-ui-guidelines"></a><span data-ttu-id="11a58-103">説明 UI のガイドライン</span><span class="sxs-lookup"><span data-stu-id="11a58-103">Instructional UI guidelines</span></span>



<span data-ttu-id="11a58-104">アプリでの特定のタッチ操作など、ユーザーにとって自明ではない機能について、ユーザーに伝えると有用な場合があります。</span><span class="sxs-lookup"><span data-stu-id="11a58-104">In some circumstances it can be helpful to teach the user about functions in your app that might not be obvious to them, such as specific touch interactions.</span></span> <span data-ttu-id="11a58-105">このような場合は、ユーザーが気付かない場合もある機能について、ユーザー インターフェイス (UI) を使ってユーザーに指示を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="11a58-105">In these cases, you need to present instructions to the user through the user interface (UI), so that they can use those features they might have missed.</span></span>

## <a name="when-to-use-instructional-ui"></a><span data-ttu-id="11a58-106">説明 UI を使う状況</span><span class="sxs-lookup"><span data-stu-id="11a58-106">When to use instructional UI</span></span>

<span data-ttu-id="11a58-107">説明 UI は、慎重に使用します。</span><span class="sxs-lookup"><span data-stu-id="11a58-107">Instructional UI has to be used carefully.</span></span> <span data-ttu-id="11a58-108">多用されると、煩わしく、無視されやすくなり、効果が低くなります。</span><span class="sxs-lookup"><span data-stu-id="11a58-108">When overused, it can be easily ignored or annoy the user, causing it to be ineffective.</span></span>

<span data-ttu-id="11a58-109">説明 UI は、タッチ ジェスチャや、ユーザーが関心を持つ設定など、重要だが自明でないアプリの機能をユーザーに示すために使用します。</span><span class="sxs-lookup"><span data-stu-id="11a58-109">Instructional UI should be used to help the user discover important and non-obvious features of your app, such as touch gestures or settings they may be interested in.</span></span> <span data-ttu-id="11a58-110">アプリの新機能や変更点など、知らせない場合には見落とす可能性のある情報を、ユーザーに知らせるためにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="11a58-110">It can also be used to inform users about new features or changes in your app that they might have otherwise overlooked.</span></span>

<span data-ttu-id="11a58-111">アプリがタッチ ジェスチャに依存したものでない場合には、アプリの基本的な機能をユーザーに説明するために説明 UI を使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-111">Unless your app is dependent on touch gestures, instructional UI should not be used to teach users the fundamental features of your app.</span></span>

## <a name="principles-of-writing-instructional-ui"></a><span data-ttu-id="11a58-112">説明 UI の作成の原則</span><span class="sxs-lookup"><span data-stu-id="11a58-112">Principles of writing instructional UI</span></span>

<span data-ttu-id="11a58-113">ユーザーにとって適切で、ユーザーのためになるように、説明 UI を使うと、ユーザー エクスペリエンスを向上できます。</span><span class="sxs-lookup"><span data-stu-id="11a58-113">Good instructional UI is relevant and educational to the user, and enhances the user experience.</span></span> <span data-ttu-id="11a58-114">良い説明 UI の原則を示します。</span><span class="sxs-lookup"><span data-stu-id="11a58-114">It should be:</span></span>

-   <span data-ttu-id="11a58-115">**シンプル:** 複雑な情報でユーザーのエクスペリエンスを中断しないようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-115">**Simple:** Users don't want their experience to be interrupted with complicated information</span></span>
-   <span data-ttu-id="11a58-116">**覚えやすい:** タスクを実行するたびに、ユーザーに毎回同じ説明をする必要がないように、説明を覚えやすいものにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-116">**Memorable:** Users don't want to see the same instructions every time they attempt a task, so instructions need to be something they'll remember.</span></span>
-   <span data-ttu-id="11a58-117">**その場に適切である:** 説明 UI が、ユーザーが今実行している操作に直接関連するものでない場合には、ユーザーにとって注意を払う必要性がありません。</span><span class="sxs-lookup"><span data-stu-id="11a58-117">**Immediately relevant:** If the instructional UI doesn't teach a user about something that they immediately want to do, they won't have a reason to pay attention to it.</span></span>

<span data-ttu-id="11a58-118">説明 UI は多用せずに、適切なものに限るようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-118">Avoid overusing instructional UI, and be sure to choose the right topics.</span></span> <span data-ttu-id="11a58-119">次のような内容を説明するために使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-119">Do not teach:</span></span>

-   <span data-ttu-id="11a58-120">**基本的な機能:** アプリを使うためにユーザーに説明を必要とする場合には、アプリの設計をより直感的なものにすることを検討します。</span><span class="sxs-lookup"><span data-stu-id="11a58-120">**Fundamental features:** If a user needs instructions to use your app, consider making the app design more intuitive.</span></span>
-   <span data-ttu-id="11a58-121">**自明な機能:** 説明なしでもユーザーが機能を理解できる場合には、説明 UI はユーザーの妨げになります。</span><span class="sxs-lookup"><span data-stu-id="11a58-121">**Obvious features:** If a user can figure out a feature on their own without instruction, then the instructional UI will just get in the way.</span></span>
-   <span data-ttu-id="11a58-122">**複雑な機能:** 説明 UI は簡潔である必要があります。複雑な機能に関心のあるユーザーは、通常、自分で情報を検索するので、表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="11a58-122">**Complex features:** Instructional UI needs to be concise, and users interested in complex features are usually willing to seek out instructions and don't need to be given them.</span></span>

<span data-ttu-id="11a58-123">説明 UI がユーザーの妨げにならないようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-123">Avoid inconveniencing the user with your instructional UI.</span></span> <span data-ttu-id="11a58-124">次のことを避けるようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-124">Do not:</span></span>

-   <span data-ttu-id="11a58-125">**重要な情報を見えなくする:** 説明 UI がアプリの他の機能の妨げにならないようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-125">**Obscure important information:** Instructional UI should never get in the way of other features of your app.</span></span>
-   <span data-ttu-id="11a58-126">**参加を強制する:** ユーザーが説明 UI を無視しても、アプリの操作を進められる必要があります。</span><span class="sxs-lookup"><span data-stu-id="11a58-126">**Force users to participate:** Users should be able to ignore instructional UI and still progress through the app.</span></span>
-   <span data-ttu-id="11a58-127">**情報を繰り返し表示:** ユーザーが最初に無視した場合、説明 UI はユーザーを何度もわずらわせないようにします。</span><span class="sxs-lookup"><span data-stu-id="11a58-127">**Displaying repeat information:** Don't harass the user with instructional UI, even if they ignore it the first time.</span></span> <span data-ttu-id="11a58-128">説明 UI の再表示を設定に追加するのは、優れたソリューションです。</span><span class="sxs-lookup"><span data-stu-id="11a58-128">Adding an setting to display instructional UI again is a better solution.</span></span>

## <a name="examples-of-instructional-ui"></a><span data-ttu-id="11a58-129">説明 UI の例</span><span class="sxs-lookup"><span data-stu-id="11a58-129">Examples of instructional UI</span></span>

<span data-ttu-id="11a58-130">ここでは、説明 UI がユーザーの習得に役立ついくつかの例を示します。</span><span class="sxs-lookup"><span data-stu-id="11a58-130">Here are a few instances in which instructional UI can help your users learn:</span></span>

-   **<span data-ttu-id="11a58-131">ユーザーがタッチ操作を見つけられるようにする。</span><span class="sxs-lookup"><span data-stu-id="11a58-131">Helping users discover touch interactions.</span></span>** <span data-ttu-id="11a58-132">次のスクリーン ショットには、Cut the Rope というゲーム内でタッチ ジェスチャを使う方法をプレイヤーに教える説明 UI が示されています。</span><span class="sxs-lookup"><span data-stu-id="11a58-132">The following screen shot shows instructional UI teaching a player how to use touch gestures in the game, Cut the Rope.</span></span>

    ![説明 UI のメッセージ ("縄を切るには、縄を横切るようにスライド") が表示されているゲームのスクリーン ショット](images/in-game-controls-3.png)

-   **<span data-ttu-id="11a58-134">第一印象を良くする。</span><span class="sxs-lookup"><span data-stu-id="11a58-134">Making a great first impression.</span></span>** <span data-ttu-id="11a58-135">ムービー モーメントの初回起動時には、ユーザー エクスペリエンスが妨げられることなく、説明 UI で、ユーザーはビデオの作成を始めるように求められます。</span><span class="sxs-lookup"><span data-stu-id="11a58-135">When Movie Moments launches for the first time, instructional UI prompts the user to begin creating movies without obstructing their experience.</span></span>

    ![ムービー モーメント アプリの起動面](images/instructional-ui-movie.png)

-   **<span data-ttu-id="11a58-137">複雑なタスクの次の手順にユーザーを導く。</span><span class="sxs-lookup"><span data-stu-id="11a58-137">Guiding users to take the next step in a complicated task.</span></span>** <span data-ttu-id="11a58-138">Windows メール アプリの受信トレイの下のヒントは、以前のメッセージにアクセスできるように、**[設定]** にユーザーを導きます。</span><span class="sxs-lookup"><span data-stu-id="11a58-138">In the Windows Mail app, a hint at the bottom of the Inbox directs users to **Settings** to access older messages.</span></span>

    ![説明 UI のメッセージが表示された Windows メール アプリのスクリーン ショット (一部)](images/instructional-ui-mail-inbox.png)

    <span data-ttu-id="11a58-140">ユーザーがメッセージをクリックすると、アプリの**設定**ポップアップが画面の右側に表示され、ユーザーがタスクを実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="11a58-140">When the user clicks the message, the app's **Settings** flyout appears on the right side of the screen, allowing the user to complete the task.</span></span> <span data-ttu-id="11a58-141">次のスクリーン ショットは、ユーザーが説明 UI のメッセージをクリックする前後のメール アプリを示しています。</span><span class="sxs-lookup"><span data-stu-id="11a58-141">These screen shots show the Mail app before and after a user clicks the instructional UI message.</span></span>

    | <span data-ttu-id="11a58-142">クリック前</span><span class="sxs-lookup"><span data-stu-id="11a58-142">Before</span></span>                                                               | <span data-ttu-id="11a58-143">クリック後</span><span class="sxs-lookup"><span data-stu-id="11a58-143">After</span></span>                                                                                                        |
    |----------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
    | ![Windows メール アプリのスクリーン ショット](images/instructional-ui-mail.png) | ![設定ポップアップが表示された Windows メール アプリのスクリーン ショット](images/instructional-ui-mail-flyout.png) |

## <a name="related-articles"></a><span data-ttu-id="11a58-146">関連記事</span><span class="sxs-lookup"><span data-stu-id="11a58-146">Related articles</span></span>

* [<span data-ttu-id="11a58-147">アプリのヘルプのガイドライン</span><span class="sxs-lookup"><span data-stu-id="11a58-147">Guidelines for app help</span></span>](guidelines-for-app-help.md)
