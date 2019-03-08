---
ms.assetid: 1C77C50C-5DA4-4414-9316-6EEDD78629E2
title: ベータ テスト
description: ベータ テストを行うと、まだリリースされていないアプリをアプリ開発チームの外部の人に自分のデバイスで試してもらい、その人たちからのフィードバックに基づいてアプリを改善することができます。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 2eca388b37cc95803b7ecb94bc0b0b5b990f5de3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654107"
---
# <a name="beta-testing"></a><span data-ttu-id="656c5-104">ベータ テスト</span><span class="sxs-lookup"><span data-stu-id="656c5-104">Beta testing</span></span>



<span data-ttu-id="656c5-105">*ベータ テスト*を行うと、まだリリースされていないアプリをアプリ開発チームの外部の人に自分のデバイスで試してもらい、その人たちからのフィードバックに基づいてアプリを改善することができます。</span><span class="sxs-lookup"><span data-stu-id="656c5-105">*Beta testing* gives you the chance to improve your app based on feedback from individuals outside of your app-development team who try your unreleased app on their own devices.</span></span>

<span data-ttu-id="656c5-106">ここでは、ユニバーサル Windows アプリのベータ テストのオプションについて説明します。</span><span class="sxs-lookup"><span data-stu-id="656c5-106">This section describes your options for beta testing Universal Windows apps.</span></span>

## <a name="why-beta-test"></a><span data-ttu-id="656c5-107">ベータ テストを行う理由</span><span class="sxs-lookup"><span data-stu-id="656c5-107">Why beta test?</span></span>

<span data-ttu-id="656c5-108">アプリを徹底的にテストするには、できるだけ多くのデバイス構成とユーザー操作に対して試してみる必要があります。</span><span class="sxs-lookup"><span data-stu-id="656c5-108">To thoroughly test an app, you need to try it against as many device configurations and user interactions as possible.</span></span> <span data-ttu-id="656c5-109">そのテストのすべてを社内で行うのは、不可能ではないにしても容易なことではありません。</span><span class="sxs-lookup"><span data-stu-id="656c5-109">Doing all of that testing in-house is difficult if not impossible.</span></span>

<span data-ttu-id="656c5-110">ベータ テストを行うと、ユーザーはそれぞれのデバイスでアプリを試します。</span><span class="sxs-lookup"><span data-stu-id="656c5-110">With beta testing, users try your app on their own devices.</span></span> <span data-ttu-id="656c5-111">そして、テストの内容は決められていません。ユーザーは指定されたタスクを実行するのではなく、それぞれのアプリの使い方で自由に操作するため、開発者が予期していなかった問題を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="656c5-111">And it's unmoderated: instead of performing specified tasks, users have complete freedom in how they use an app, so they can find issues that you might never have expected.</span></span>

<span data-ttu-id="656c5-112">ベータ テストを行うと、次のことができます。</span><span class="sxs-lookup"><span data-stu-id="656c5-112">With beta testing, you can:</span></span>

-   <span data-ttu-id="656c5-113">さまざまなデバイスでアプリをテストできます。</span><span class="sxs-lookup"><span data-stu-id="656c5-113">Test your app on a variety of devices.</span></span>
-   <span data-ttu-id="656c5-114">他の方法では見つからないパフォーマンスの問題やその他のバグを特定できます。</span><span class="sxs-lookup"><span data-stu-id="656c5-114">Identify performance issues and other bugs that you might not have found otherwise.</span></span>
-   <span data-ttu-id="656c5-115">ユーザー エクスペリエンスの向上につながる実際の使用状況の情報が得られます。</span><span class="sxs-lookup"><span data-stu-id="656c5-115">Get real-world usage info that can be used improve the user experience.</span></span>
-   <span data-ttu-id="656c5-116">Microsoft Store でのパブリックの評価に影響を与えずにフィードバックを受信します。</span><span class="sxs-lookup"><span data-stu-id="656c5-116">Receive feedback without affecting public ratings in the Microsoft Store.</span></span>

## <a name="when-to-beta-test"></a><span data-ttu-id="656c5-117">ベータ テストを行う時期</span><span class="sxs-lookup"><span data-stu-id="656c5-117">When to beta test</span></span>

<span data-ttu-id="656c5-118">ベータ テストは、アプリをリリースする前のテストの最終段階として実施するのが最適です。</span><span class="sxs-lookup"><span data-stu-id="656c5-118">It's best to conduct beta testing as the final stage of testing before you release your app.</span></span> <span data-ttu-id="656c5-119">その時点では、自分たちでできるだけ徹底的にアプリをテストしていて、すべての明示的なユース ケースについてテストが終了しています。</span><span class="sxs-lookup"><span data-stu-id="656c5-119">At that point, you have tested the app as thoroughly as you can yourself, and you've covered all explicit use cases.</span></span> <span data-ttu-id="656c5-120">ベータ テストは、その他のテスト方法の代わりにはなりません。</span><span class="sxs-lookup"><span data-stu-id="656c5-120">Beta testing is not a substitute for other testing methods.</span></span> <span data-ttu-id="656c5-121">ベータ テストの内容は決められていないため、参加者がコード内のすべてのバグを発見できないこともあります。ベータ テスターは操作内容を自分で決めており、彼らがアプリのすべての機能を調べる可能性は高くないからです。</span><span class="sxs-lookup"><span data-stu-id="656c5-121">Since beta testing is unmoderated, participants may not catch all bugs in your code because every tester's experience is self-directed and it's unlikely that they'll explore all features of the app.</span></span> <span data-ttu-id="656c5-122">しかし、ベータ テストのフィードバックによって、実際の使用による最後のフィードバックが得られ、公開前に予測していなかった問題が明らかになります。</span><span class="sxs-lookup"><span data-stu-id="656c5-122">But beta-testing feedback can give you a final wave of real-world feedback that reveals issues that you might never have expected before you go live.</span></span>

## <a name="next-steps"></a><span data-ttu-id="656c5-123">次のステップ</span><span class="sxs-lookup"><span data-stu-id="656c5-123">Next steps</span></span>

<span data-ttu-id="656c5-124">[パートナー センター](https://partner.microsoft.com/dashboard)、ことを制限するアプリの配布のみ、テスト担当者に、どのオペレーティング システムに関係なく対象とするアプリです。</span><span class="sxs-lookup"><span data-stu-id="656c5-124">In [Partner Center](https://partner.microsoft.com/dashboard), you can limit distribution of your apps to only your testers, regardless of which operating systems your app targets.</span></span> <span data-ttu-id="656c5-125">別の名前やパッケージ ID を使って別バージョンのアプリを作る必要はありません。自身でテストを行い、アプリを公開する準備が整ったら新しい提出を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="656c5-125">There’s no need to create a separate version of your app with a separate name and package identity; you can do your testing, then create a new submission when you’re ready to make the app available to everyone.</span></span> <span data-ttu-id="656c5-126">(もちろん、必要であれば、テスト用に別のアプリを作ることもできます。</span><span class="sxs-lookup"><span data-stu-id="656c5-126">(Of course, you can create a separate app for testing only if you prefer.</span></span> <span data-ttu-id="656c5-127">作る場合、そのアプリには、最終的なパブリック アプリの名前とは違う名前を付ける必要があります。)</span><span class="sxs-lookup"><span data-stu-id="656c5-127">If you do, make sure to give it a different name from what you intend as the final, public app name.)</span></span>

<span data-ttu-id="656c5-128">ベータ テスト用にアプリをストアに提出する方法については、「[ベータ テストとターゲット配布](../publish/beta-testing-and-targeted-distribution.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="656c5-128">See [Beta testing and targeted distribution](../publish/beta-testing-and-targeted-distribution.md) to learn how to submit your app to the Store for beta testing.</span></span>

 

 




