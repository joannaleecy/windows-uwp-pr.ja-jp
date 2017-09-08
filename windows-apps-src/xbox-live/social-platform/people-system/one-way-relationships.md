---
title: "一方向の関係"
author: KevinAsgari
description: "一方向の関係モデルが Xbox Live ソーシャル プラットフォームにどのように実装されているかについて説明します。"
ms.assetid: d5a1d311-6de3-4ccc-ab72-15b243e8c2ef
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ソーシャル プラットフォーム, 招待, フレンドの追加"
ms.openlocfilehash: 88b04e1ad45e3e597699104fdd932b48e6165c1d
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="one-way-relationships"></a><span data-ttu-id="80511-104">一方向の関係</span><span class="sxs-lookup"><span data-stu-id="80511-104">One Way Relationships</span></span>

<span data-ttu-id="80511-105">Xbox Live は一方向関係モデルに移行しました。</span><span class="sxs-lookup"><span data-stu-id="80511-105">Xbox Live has moved toward a one-way relationship model.</span></span> <span data-ttu-id="80511-106">ユーザーは、他のユーザーをフォローすることで、従来よりも容易に、そのユーザーが Xbox Live 上で何をしているかを確認したり、そのユーザーとコミュニケーションを図ったり、そのユーザーをパーティーに招待したりできます。</span><span class="sxs-lookup"><span data-stu-id="80511-106">A user can follow anyone to more easily see what they're up to on Xbox Live, communicate with them and invite them to parties.</span></span>

<span data-ttu-id="80511-107">このモデルでは、フレンド登録の依頼の確認を "相手" に要求して関係を作る代わりに、ユーザーが各自のソーシャル グラフをよりすばやく、容易に拡張できます。</span><span class="sxs-lookup"><span data-stu-id="80511-107">This model lets users grow their social graph more quickly and easily, instead of requiring the "other side" to confirm a friend request to establish a connection.</span></span>

-   [<span data-ttu-id="80511-108">ユーザーとユーザー リスト</span><span class="sxs-lookup"><span data-stu-id="80511-108">People and People List</span></span>](#people-and-people-list)
-   [<span data-ttu-id="80511-109">開発アカウントを使った Xbox People グラフの作成</span><span class="sxs-lookup"><span data-stu-id="80511-109">Build your Xbox People Graph with Dev Accounts</span></span>](#build-your-xbox-people-graph-with-dev-accounts)
-   [<span data-ttu-id="80511-110">他のユーザーのフォロー</span><span class="sxs-lookup"><span data-stu-id="80511-110">Following Other Users</span></span>](#following-other-users)
-   [<span data-ttu-id="80511-111">プライバシー</span><span class="sxs-lookup"><span data-stu-id="80511-111">Privacy</span></span>](#privacy)


## <a name="people-and-people-list"></a><span data-ttu-id="80511-112">ユーザーとユーザー リスト</span><span class="sxs-lookup"><span data-stu-id="80511-112">People and People List</span></span>

<span data-ttu-id="80511-113">Xbox One では、Xbox Live に "ユーザー" と "ユーザー リスト" が含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="80511-113">On Xbox One, Xbox Live now has "People" and a "People List".</span></span> <span data-ttu-id="80511-114">Xbox Live の People システムでは以前の 100 人という制限がなくなり、ユーザーは各自のリストに、事実上限度なく、必要な数のユーザーを追加できます (ただし、比較的大きいものの技術的な限度は確かに存在します)。</span><span class="sxs-lookup"><span data-stu-id="80511-114">The People system eliminates the previous 100 limit on Xbox Live; users can add as many people to their list as they want with no practical bound (though some relatively large technical bound certainly exists).</span></span> <span data-ttu-id="80511-115">People サービス内では、ユーザーが自分のリストに追加できるユーザー数に制限があります。正確な数は確定していませんが、おそらく数千の単位となります。</span><span class="sxs-lookup"><span data-stu-id="80511-115">Within the People service there is a limit to the number of People a user can have on their list; the exact number has not been established but it is likely in the thousands.</span></span> <span data-ttu-id="80511-116">この数はいつでも変更される可能性があり、Xbox 360 での 100 人のフレンドのように、"確固とした" 制限ではありません。</span><span class="sxs-lookup"><span data-stu-id="80511-116">Note that this number can change at any time, and is not a "firm" limit like the 100 friends in Xbox 360.</span></span> <span data-ttu-id="80511-117">外部システムでは、推測される最大数をハードコードしてはいけません。このため、現在の制限は明示的に定義されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="80511-117">No external system should hard code a maximum limit assumption, and because of this the current limit might never be explicitly defined.</span></span>

<span data-ttu-id="80511-118">People システムには、一方向の関係モデルも導入されます。ユーザーは自分のユーザー リストに任意のユーザーを追加でき、そのユーザーは、受け入れてもらう必要のある招待を送信することなく即座に追加されます。</span><span class="sxs-lookup"><span data-stu-id="80511-118">The People system also introduces a 1-way relationship model; a user can add anyone to their People list and that person is instantly added without sending an invite that must be accepted.</span></span> <span data-ttu-id="80511-119">一方向のモデルに移行する主な理由は、全体の簡素化です。フレンド登録の依頼は、ユーザーが管理する事柄を増やし、多くの場合、相手のユーザーがフレンド登録の依頼を見てそれを受け入れるまでに何日かの遅延が発生することになります。送信者はその後で、そうした状況が発生したことに気付く必要があります。</span><span class="sxs-lookup"><span data-stu-id="80511-119">The core reason for moving to a 1-way model is overall simplicity; friend requests present another layer of things for the user to manage and often resulted in a multi-day lag until the other person sees the friend request and accepts it, then the sender has to realize that this has happened.</span></span>


## <a name="build-your-xbox-people-graph-with-dev-accounts"></a><span data-ttu-id="80511-120">開発アカウントを使った Xbox People グラフの作成</span><span class="sxs-lookup"><span data-stu-id="80511-120">Build your Xbox People Graph with Dev Accounts</span></span>

<span data-ttu-id="80511-121">xbox.com を使用して、開発アカウントの Xbox People グラフをテスト用に作成できます。</span><span class="sxs-lookup"><span data-stu-id="80511-121">You can use xbox.com to build an Xbox People graph with your development accounts for testing purposes.</span></span>

<span data-ttu-id="80511-122">まず、DevAccountA からフレンド登録の依頼を送信します。</span><span class="sxs-lookup"><span data-stu-id="80511-122">First, send a friend request from DevAccountA:</span></span>

1.  <span data-ttu-id="80511-123">http://www.xbox.com にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="80511-123">Go to http://www.xbox.com</span></span>
2.  <span data-ttu-id="80511-124">[サインイン] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-124">Click Sign in.</span></span> <span data-ttu-id="80511-125">DevAccountA の資格情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="80511-125">Enter your credentials with DevAccountA.</span></span>
3.  <span data-ttu-id="80511-126">DevAccountA のプロフィール ページが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="80511-126">DevAccountA's profile page will load.</span></span> <span data-ttu-id="80511-127">緑色の [フレンド] タイルをクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-127">Click the green Friends tile.</span></span>
4.  <span data-ttu-id="80511-128">[ゲーマータグで検索] ボックスに、DevAccountB のゲーマータグを入力します。</span><span class="sxs-lookup"><span data-stu-id="80511-128">In the "Find by Gamertag" box, type the gamertag for DevAccountB.</span></span> <span data-ttu-id="80511-129">[検索] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-129">Click Find.</span></span>
5.  <span data-ttu-id="80511-130">左側の列の [フレンドを追加](+) ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-130">Click the Add Friend (+) button in the left column.</span></span>
6.  <span data-ttu-id="80511-131">確認メッセージが表示されたら [閉じる] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-131">Click Close on the confirmation message that appears.</span></span>

<span data-ttu-id="80511-132">次に、DevAccountB からのリクエストを受け入れます。</span><span class="sxs-lookup"><span data-stu-id="80511-132">Then, accept the request from DevAccountB:</span></span>

1.  <span data-ttu-id="80511-133">xbox.com からサインアウトし、再び [サインイン] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-133">Sign out of xbox.com and click Sign in again.</span></span> <span data-ttu-id="80511-134">DevAccountB の資格情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="80511-134">Enter the credentials for DevAccountB.</span></span>
2.  <span data-ttu-id="80511-135">DevAccountB のプロフィール ページが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="80511-135">DevAccountB's profile page will load.</span></span> <span data-ttu-id="80511-136">緑色の [メッセージ] タイルをクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-136">Click the green Messages tile.</span></span>
3.  <span data-ttu-id="80511-137">[フレンド登録の依頼] セクションで、[同意する] ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="80511-137">In the Friend Requests section, click the Accept button.</span></span>

<span data-ttu-id="80511-138">ここで、DevAccountA でサインインして ShowSendInvitesAsync() を呼び出すと、DevAccountB がリストに表示されます (逆も同様です)。</span><span class="sxs-lookup"><span data-stu-id="80511-138">Now when you sign in with DevAccountA and invoke ShowSendInvitesAsync(), DevAccountB will appear in the list (and vice versa).</span></span>

<span data-ttu-id="80511-139">あるいは、任意の XUID に対して **showProfileCardAsync()** を呼び出すサンプルの Xbox One アプリケーションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="80511-139">Alternatively, you can create a sample Xbox One application that calls **showProfileCardAsync()** for an arbitrary XUID.</span></span> <span data-ttu-id="80511-140">**showProfileCardAsync()** を呼び出したときに表示されるプロフィール カード上の [フォロー] ボタンをクリックすると、呼び出し元のユーザーは、XUID が指定されたユーザーをフォローします。</span><span class="sxs-lookup"><span data-stu-id="80511-140">Clicking the "Follow" button on the Profile Card that appears when **showProfileCardAsync()** is called will cause the calling user to following the user who's XUID was provided.</span></span>


## <a name="following-other-users"></a><span data-ttu-id="80511-141">他のユーザーのフォロー</span><span class="sxs-lookup"><span data-stu-id="80511-141">Following Other Users</span></span>

<span data-ttu-id="80511-142">一方向の関係モデルに移行する副次的メリットは、だれもが自分のユーザー リストに追加できる、Xbox Live 上の "有名人" を中心とした新しいシナリオが利用可能になる点です。</span><span class="sxs-lookup"><span data-stu-id="80511-142">A side-benefit of moving to the 1-way relationship model is that it opens up new scenarios around "celebrities" on Xbox Live that anyone can add to their People list.</span></span> <span data-ttu-id="80511-143">たとえば、多くのユーザーが自分のリストに有名なレーシング ゲーム プレイヤーを追加することができます。そのようにすると、より簡単に有名プレイヤーとトラック タイムを競い、そうしたプレイヤーのランキングが上がったときの更新を表示したり、彼らが新しいトラックを作成したときに通知を受け取るようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="80511-143">For example, a lot of users might add a well-known racing game player to their list so that they can more easily race against them on track times, see updates from that player as they climb leaderboards, or get notified when they create new tracks.</span></span> <span data-ttu-id="80511-144">また、一方向のモデルでは、ユーザーが、音楽の好みが似通っている可能性があることに気付いた知らないユーザーの再生リストなどのコンテンツをサブスクライブする、"フォロー" 型の関係をサポートすることが容易になっています。</span><span class="sxs-lookup"><span data-stu-id="80511-144">The 1-way model also makes it easy to support "follow" type relationships where users subscribe to content such as music playlists from unknown people they discover who might have well-aligned music tastes.</span></span>


## <a name="privacy"></a><span data-ttu-id="80511-145">プライバシー</span><span class="sxs-lookup"><span data-stu-id="80511-145">Privacy</span></span>

<span data-ttu-id="80511-146">新しい一方向の関係モデルのコンテキストでは、多くの場合、まず初めにプライバシーの懸念が発生します。つまり、だれかが自分をリストに追加して、知らぬ間に自分が "ストーキング" されるようなことがあれば、自分に関するどんな情報が見られてしまうのか、という懸念です。</span><span class="sxs-lookup"><span data-stu-id="80511-146">Privacy concerns are often initially raised in the context of the new 1-way relationship model, if anyone can add me to their list then "stalk" me without me knowing, what can they see about me?</span></span> <span data-ttu-id="80511-147">このような場合、このモデルは以前の Xbox Live での場合と違いはありません。最新のプレイヤー リストを利用したり、Xbox.com にランダムなゲーマータグを入力するだけで、ユーザーが Xbox Live プライバシー設定で "すべての人" に表示を許可した情報を、だれでも参照することができます。</span><span class="sxs-lookup"><span data-stu-id="80511-147">The model here turns out to be no different than previously on Xbox Live; through the recent players list or simply typing a random Gamertag into Xbox.com anyone can see the information a user allows to be seen by "everyone" in the Xbox Live privacy settings.</span></span> <span data-ttu-id="80511-148">一方向の関係モデルでは、プライバシー設定で公開範囲が "すべての人" になっているすべての情報が、そのユーザーを自分のリストに追加したユーザー (追加されたユーザーは追加したユーザーを自分のリストに追加していない) によって取得されます。</span><span class="sxs-lookup"><span data-stu-id="80511-148">In the 1-way model, whatever information is scoped to "everyone" through privacy settings is what people get who add someone to their list that hasn't added them back.</span></span>
