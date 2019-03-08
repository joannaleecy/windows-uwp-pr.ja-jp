---
Description: ユーザーが、UWP アプリを操作する方法について説明する説明のユーザー インターフェイス (UI) を設計します。
title: 説明 UI のデザインのガイドライン
label: Instructional UI
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: c87e2f06-339d-4413-b585-172752964f56
ms.localizationpriority: medium
ms.openlocfilehash: b39507fb1333fdb642601c6b4828c3d160c6ceb5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656437"
---
# <a name="instructional-ui-guidelines"></a><span data-ttu-id="2dc1c-104">説明 UI のガイドライン</span><span class="sxs-lookup"><span data-stu-id="2dc1c-104">Instructional UI guidelines</span></span>



<span data-ttu-id="2dc1c-105">アプリでの特定のタッチ操作など、ユーザーにとって自明ではない機能について、ユーザーに伝えると有用な場合があります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-105">In some circumstances it can be helpful to teach the user about functions in your app that might not be obvious to them, such as specific touch interactions.</span></span> <span data-ttu-id="2dc1c-106">このような場合は、ユーザーが気付かない場合もある機能について、ユーザー インターフェイス (UI) を使ってユーザーに指示を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-106">In these cases, you need to present instructions to the user through the user interface (UI), so that they can use those features they might have missed.</span></span>

## <a name="when-to-use-instructional-ui"></a><span data-ttu-id="2dc1c-107">説明 UI を使う状況</span><span class="sxs-lookup"><span data-stu-id="2dc1c-107">When to use instructional UI</span></span>

<span data-ttu-id="2dc1c-108">説明 UI は、慎重に使用します。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-108">Instructional UI has to be used carefully.</span></span> <span data-ttu-id="2dc1c-109">多用されると、煩わしく、無視されやすくなり、効果が低くなります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-109">When overused, it can be easily ignored or annoy the user, causing it to be ineffective.</span></span>

<span data-ttu-id="2dc1c-110">説明 UI は、タッチ ジェスチャや、ユーザーが関心を持つ設定など、重要だが自明でないアプリの機能をユーザーに示すために使用します。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-110">Instructional UI should be used to help the user discover important and non-obvious features of your app, such as touch gestures or settings they may be interested in.</span></span> <span data-ttu-id="2dc1c-111">アプリの新機能や変更点など、知らせない場合には見落とす可能性のある情報を、ユーザーに知らせるためにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-111">It can also be used to inform users about new features or changes in your app that they might have otherwise overlooked.</span></span>

<span data-ttu-id="2dc1c-112">アプリがタッチ ジェスチャに依存したものでない場合には、アプリの基本的な機能をユーザーに説明するために説明 UI を使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-112">Unless your app is dependent on touch gestures, instructional UI should not be used to teach users the fundamental features of your app.</span></span>

## <a name="principles-of-writing-instructional-ui"></a><span data-ttu-id="2dc1c-113">説明 UI の作成の原則</span><span class="sxs-lookup"><span data-stu-id="2dc1c-113">Principles of writing instructional UI</span></span>

<span data-ttu-id="2dc1c-114">ユーザーにとって適切で、ユーザーのためになるように、説明 UI を使うと、ユーザー エクスペリエンスを向上できます。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-114">Good instructional UI is relevant and educational to the user, and enhances the user experience.</span></span> <span data-ttu-id="2dc1c-115">良い説明 UI の原則を示します。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-115">It should be:</span></span>

-   <span data-ttu-id="2dc1c-116">**単純な。** ユーザーは、エクスペリエンスの中断は、複雑な情報を使用したくないです。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-116">**Simple:** Users don't want their experience to be interrupted with complicated information</span></span>
-   <span data-ttu-id="2dc1c-117">**覚えやすい。** ユーザーはしないように、わかりやすいものである必要がある手順については、タスクを試みるたびに同じ手順を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-117">**Memorable:** Users don't want to see the same instructions every time they attempt a task, so instructions need to be something they'll remember.</span></span>
-   <span data-ttu-id="2dc1c-118">**すぐに関連します。** 説明用の UI には、すぐにやりたいことについて、ユーザーは教えません、ことに注意を払うの理由ことがなくなります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-118">**Immediately relevant:** If the instructional UI doesn't teach a user about something that they immediately want to do, they won't have a reason to pay attention to it.</span></span>

<span data-ttu-id="2dc1c-119">説明 UI は多用せずに、適切なものに限るようにします。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-119">Avoid overusing instructional UI, and be sure to choose the right topics.</span></span> <span data-ttu-id="2dc1c-120">次のような内容を説明するために使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-120">Do not teach:</span></span>

-   <span data-ttu-id="2dc1c-121">**基本的な機能:** ユーザーにアプリを使用する手順が必要な場合より直感的なアプリの設計を行うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-121">**Fundamental features:** If a user needs instructions to use your app, consider making the app design more intuitive.</span></span>
-   <span data-ttu-id="2dc1c-122">**明瞭な特徴:** ユーザーは、命令せず独自の機能を理解できる、方法で説明用の UI は取得だけです。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-122">**Obvious features:** If a user can figure out a feature on their own without instruction, then the instructional UI will just get in the way.</span></span>
-   <span data-ttu-id="2dc1c-123">**複雑な機能:** UI の説明を簡潔でする必要があると、複雑な機能に興味のあるユーザーは、通常は積極的に命令を検討して、それらを指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-123">**Complex features:** Instructional UI needs to be concise, and users interested in complex features are usually willing to seek out instructions and don't need to be given them.</span></span>

<span data-ttu-id="2dc1c-124">説明 UI がユーザーの妨げにならないようにします。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-124">Avoid inconveniencing the user with your instructional UI.</span></span> <span data-ttu-id="2dc1c-125">次のことを避けるようにします。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-125">Do not:</span></span>

-   <span data-ttu-id="2dc1c-126">**あいまいな重要な情報:** 説明用の UI は、ことはありません、アプリの他の機能は邪魔する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-126">**Obscure important information:** Instructional UI should never get in the way of other features of your app.</span></span>
-   <span data-ttu-id="2dc1c-127">**ユーザーは強制的に参加:** ユーザーは、説明用の UI とも、アプリを使用して進行状況を無視できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-127">**Force users to participate:** Users should be able to ignore instructional UI and still progress through the app.</span></span>
-   <span data-ttu-id="2dc1c-128">**繰り返しの情報を表示するには。** 最初の時間を無視する場合でも、説明用の UI を使用したユーザーを見かけたはありません。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-128">**Displaying repeat information:** Don't harass the user with instructional UI, even if they ignore it the first time.</span></span> <span data-ttu-id="2dc1c-129">説明 UI の再表示を設定に追加するのは、優れたソリューションです。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-129">Adding an setting to display instructional UI again is a better solution.</span></span>

## <a name="examples-of-instructional-ui"></a><span data-ttu-id="2dc1c-130">説明 UI の例</span><span class="sxs-lookup"><span data-stu-id="2dc1c-130">Examples of instructional UI</span></span>

<span data-ttu-id="2dc1c-131">ここでは、説明 UI がユーザーの習得に役立ついくつかの例を示します。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-131">Here are a few instances in which instructional UI can help your users learn:</span></span>

-   <span data-ttu-id="2dc1c-132">**ユーザーがタッチ操作を検出可能になります。**</span><span class="sxs-lookup"><span data-stu-id="2dc1c-132">**Helping users discover touch interactions.**</span></span> <span data-ttu-id="2dc1c-133">次のスクリーン ショットには、Cut the Rope というゲーム内でタッチ ジェスチャを使う方法をプレイヤーに教える説明 UI が示されています。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-133">The following screen shot shows instructional UI teaching a player how to use touch gestures in the game, Cut the Rope.</span></span>

    ![説明 UI のメッセージ ("縄を切るには、縄を横切るようにスライド") が表示されているゲームのスクリーン ショット](images/in-game-controls-3.png)

-   <span data-ttu-id="2dc1c-135">**良い第一印象を作成します。**</span><span class="sxs-lookup"><span data-stu-id="2dc1c-135">**Making a great first impression.**</span></span> <span data-ttu-id="2dc1c-136">ムービー モーメントの初回起動時には、ユーザー エクスペリエンスが妨げられることなく、説明 UI で、ユーザーはビデオの作成を始めるように求められます。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-136">When Movie Moments launches for the first time, instructional UI prompts the user to begin creating movies without obstructing their experience.</span></span>

    ![ムービー モーメント アプリの起動面](images/instructional-ui-movie.png)

-   <span data-ttu-id="2dc1c-138">**複雑なタスクで、次の手順を実行するユーザーを誘導します。**</span><span class="sxs-lookup"><span data-stu-id="2dc1c-138">**Guiding users to take the next step in a complicated task.**</span></span> <span data-ttu-id="2dc1c-139">Windows メール アプリの受信トレイの下のヒントは、以前のメッセージにアクセスできるように、**[設定]** にユーザーを導きます。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-139">In the Windows Mail app, a hint at the bottom of the Inbox directs users to **Settings** to access older messages.</span></span>

    ![説明 UI のメッセージが表示された Windows メール アプリのスクリーン ショット (一部)](images/instructional-ui-mail-inbox.png)

    <span data-ttu-id="2dc1c-141">ユーザーがメッセージをクリックすると、アプリの**設定**ポップアップが画面の右側に表示され、ユーザーがタスクを実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-141">When the user clicks the message, the app's **Settings** flyout appears on the right side of the screen, allowing the user to complete the task.</span></span> <span data-ttu-id="2dc1c-142">次のスクリーン ショットは、ユーザーが説明 UI のメッセージをクリックする前後のメール アプリを示しています。</span><span class="sxs-lookup"><span data-stu-id="2dc1c-142">These screen shots show the Mail app before and after a user clicks the instructional UI message.</span></span>

    | <span data-ttu-id="2dc1c-143">変更前</span><span class="sxs-lookup"><span data-stu-id="2dc1c-143">Before</span></span>                                                               | <span data-ttu-id="2dc1c-144">クリック後</span><span class="sxs-lookup"><span data-stu-id="2dc1c-144">After</span></span>                                                                                                        |
    |----------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
    | ![Windows メール アプリのスクリーン ショット](images/instructional-ui-mail.png) | ![設定ポップアップが表示された Windows メール アプリのスクリーン ショット](images/instructional-ui-mail-flyout.png) |

## <a name="related-articles"></a><span data-ttu-id="2dc1c-147">関連記事</span><span class="sxs-lookup"><span data-stu-id="2dc1c-147">Related articles</span></span>

* [<span data-ttu-id="2dc1c-148">アプリのヘルプに関するガイドライン</span><span class="sxs-lookup"><span data-stu-id="2dc1c-148">Guidelines for app help</span></span>](guidelines-for-app-help.md)
