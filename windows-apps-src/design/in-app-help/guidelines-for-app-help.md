---
author: QuinnRadich
Description: These guidelines describe how to design effective Help content for your app.
title: アプリのヘルプのガイドライン
label: Guidelines for app help
template: detail.hbs
ms.author: quradic
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: c3e73f9b-4839-4804-b379-c95b0ca4fbe8
ms.localizationpriority: medium
ms.openlocfilehash: 6e4cb60526fda9495249cd310ad434878941a97d
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7297594"
---
# <a name="guidelines-for-app-help"></a><span data-ttu-id="a922f-103">アプリのヘルプのガイドライン</span><span class="sxs-lookup"><span data-stu-id="a922f-103">Guidelines for App Help</span></span>



<span data-ttu-id="a922f-104">アプリケーションが複雑な場合には、ユーザーに効果的なヘルプを提供することにより、ユーザー エクスペリエンスを大幅に改善できます。</span><span class="sxs-lookup"><span data-stu-id="a922f-104">Applications can be complex, and providing effective help for your users can greatly improve their experience.</span></span> <span data-ttu-id="a922f-105">すべてのアプリケーションがユーザーにヘルプを提供する必要があるとは限らず、また提供する必要のあるヘルプの種類もアプリケーションによって大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="a922f-105">Not all applications need to provide help for their users, and what sort of help should be provided can vary greatly, depending on the application.</span></span>

<span data-ttu-id="a922f-106">ヘルプを提供する場合には、その作成時に次のガイドラインに従います。</span><span class="sxs-lookup"><span data-stu-id="a922f-106">If you decide to provide help, follow these guidelines when creating it.</span></span> <span data-ttu-id="a922f-107">有用でないヘルプを提供するくらいなら、ヘルプを提供しないほうがましであるという場合もあります。</span><span class="sxs-lookup"><span data-stu-id="a922f-107">Help that isn't helpful can be worse than no help at all.</span></span>

## <a name="intuitive-design"></a><span data-ttu-id="a922f-108">直感的なデザイン</span><span class="sxs-lookup"><span data-stu-id="a922f-108">Intuitive Design</span></span>

<span data-ttu-id="a922f-109">ヘルプのコンテンツをどれだけ充実させたとしても、アプリがユーザーに優れたエクスペリエンスを提供するには、ヘルプに依存することはできません。</span><span class="sxs-lookup"><span data-stu-id="a922f-109">As useful as help content can be, your app cannot rely on it to provide a good experience for the user.</span></span> <span data-ttu-id="a922f-110">ユーザーは、アプリの重要な機能がすぐに見つからずに使えない場合には、アプリの使用をやめてしまいます。</span><span class="sxs-lookup"><span data-stu-id="a922f-110">If the user is unable to immediately discover and use the critical functions of your app, the user will not use your app.</span></span> <span data-ttu-id="a922f-111">ヘルプの質と量がどれだけ優れていても、第一印象を変えることはできません。</span><span class="sxs-lookup"><span data-stu-id="a922f-111">No amount or quality help will change that first impression.</span></span>

<span data-ttu-id="a922f-112">直感的でわかりやすいデザインは、有用なヘルプを作成するための最初の手順です。</span><span class="sxs-lookup"><span data-stu-id="a922f-112">An intuitive and user-friendly design is the first step to writing useful help.</span></span> <span data-ttu-id="a922f-113">ユーザーが関心を持ち続けて、やがてより高度な機能を使うようになるだけではありません。アプリの主要機能の知識を提供することにより、アプリを使用してその習得を継続するにつれて、知識が蓄積されていきます。</span><span class="sxs-lookup"><span data-stu-id="a922f-113">Not only does it keep the user engaged for long enough for them to use more advanced features, but it also provides them with knowledge of an app's core functions, which they can build upon as they continue to use the app and learn.</span></span>

## <a name="general-instructions"></a><span data-ttu-id="a922f-114">一般的な手順</span><span class="sxs-lookup"><span data-stu-id="a922f-114">General instructions</span></span>

<span data-ttu-id="a922f-115">ユーザーは問題が発生していない場合には、ヘルプ コンテンツを探すことはありません。ヘルプは問題に対する回答をすばやく効果的に提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-115">A user will not look for help content unless they already have a problem, so help needs to provide a quick and effective answer to that problem.</span></span> <span data-ttu-id="a922f-116">ヘルプが即座に有用でない場合や、ヘルプが複雑すぎる場合は、ユーザーはそれを無視する可能性が高くなります。</span><span class="sxs-lookup"><span data-stu-id="a922f-116">If help is not immediately useful, or if help is too complicated, then users are more likely to ignore it.</span></span>

<span data-ttu-id="a922f-117">あらゆるヘルプは、次の原則に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-117">All help, no matter what kind, should follow these principles:</span></span>

-   <span data-ttu-id="a922f-118">**わかりやすい:** ユーザーを混乱させるヘルプなら、ヘルプがないほうがまだ良いでしょう。</span><span class="sxs-lookup"><span data-stu-id="a922f-118">**Easy to understand:** Help that confuses the user is worse than no help at all.</span></span>

-   <span data-ttu-id="a922f-119">**単純:** ヘルプを探しているユーザーは、直接的で明確な回答を求めています。</span><span class="sxs-lookup"><span data-stu-id="a922f-119">**Straightforward:** Users looking for help want clear answers presented directly to them.</span></span>

-   <span data-ttu-id="a922f-120">**関連性:** ユーザーが直面している問題について、検索する必要がないようにします。</span><span class="sxs-lookup"><span data-stu-id="a922f-120">**Relevant:** Users do not want to have to search for their specific issue.</span></span> <span data-ttu-id="a922f-121">ユーザーはその場面に最も関連があって適切なヘルプ (コンテキスト ヘルプと呼ばれます) がすぐに表示されることを求めています。または容易なナビゲーションのためのインターフェイスが必要です。</span><span class="sxs-lookup"><span data-stu-id="a922f-121">They want the most relevant help presented straight to them (this is called "Contextual Help"), or they want an easily navigated interface.</span></span>

-   <span data-ttu-id="a922f-122">**直接的:** ユーザーはヘルプを探すときには、ヘルプを見ることを希望します。</span><span class="sxs-lookup"><span data-stu-id="a922f-122">**Direct:** When a user looks for help, they want to see help.</span></span> <span data-ttu-id="a922f-123">アプリのヘルプの中に、バグの報告、フィードバックの送信、サービス規定の表示などの機能へのリンクが含まれていてもかまいませんが、</span><span class="sxs-lookup"><span data-stu-id="a922f-123">If your app includes pages for reporting bugs, giving feedback, viewing term of service, or similar functions, it is fine if your help links to those pages.</span></span> <span data-ttu-id="a922f-124">それらはメインのヘルプ ページの補足として含むものであり、メインのヘルプのコンテンツとなるものではありません。</span><span class="sxs-lookup"><span data-stu-id="a922f-124">But they should be included as an afterthought on the main help page, and not as items of equal or greater importance.</span></span>

-   <span data-ttu-id="a922f-125">**一貫性:** どのような種類のヘルプでも、ヘルプはアプリの一部です。UI の他の部分と同様に扱う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-125">**Consistent:** No matter the type, help is still a part of your app, and should be treated as any other part of the UI.</span></span> <span data-ttu-id="a922f-126">アプリの他の部分と同じ設計原則による、操作性、アクセシビリティ、スタイルが、ヘルプでも採用されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-126">The same design principles of usability, accessibility, and style which are used throughout the rest of your app should also be present in the help you offer.</span></span>

## <a name="types-of-help"></a><span data-ttu-id="a922f-127">ヘルプの種類</span><span class="sxs-lookup"><span data-stu-id="a922f-127">Types of help</span></span>

<span data-ttu-id="a922f-128">ヘルプ コンテンツには 3 つの主要なカテゴリがあり、それぞれにメリットと適性があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-128">There are three primary categories of help content, each with varying strengths and suitable for different purposes.</span></span> <span data-ttu-id="a922f-129">アプリの必要に応じて、これらを組み合わせて使用します。</span><span class="sxs-lookup"><span data-stu-id="a922f-129">Use any combination of them in your app, depending on your needs.</span></span>

#### <a name="instructional-ui"></a><span data-ttu-id="a922f-130">説明 UI</span><span class="sxs-lookup"><span data-stu-id="a922f-130">Instructional UI</span></span>

<span data-ttu-id="a922f-131">通常の場合、ユーザーはアプリの主要な機能のすべてを、操作手順を読まなくても使える必要があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-131">Normally, users should be able to use all the core functions of your app without instruction.</span></span> <span data-ttu-id="a922f-132">場合によっては、アプリが特定のジェスチャの使用に依存していたり、すぐには自明ではない別の機能がある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="a922f-132">But sometimes, your app will depend on use of a specific gesture, or there may be secondary features of your app which are not immediately obvious.</span></span> <span data-ttu-id="a922f-133">そのような場合には、説明 UI によってユーザーに特定のタスクの使い方を教えることができます。</span><span class="sxs-lookup"><span data-stu-id="a922f-133">In this case, instructional UI should be used to educate users with instructions on how to perform specific tasks.</span></span>

[<span data-ttu-id="a922f-134">「説明 UI のガイドライン」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a922f-134">See guidelines for instructional UI</span></span>](instructional-ui.md)

#### <a name="in-app-help"></a><span data-ttu-id="a922f-135">アプリ内ヘルプ</span><span class="sxs-lookup"><span data-stu-id="a922f-135">In-app help</span></span>

<span data-ttu-id="a922f-136">ヘルプを表示する標準的な方法では、ユーザーの要求に応じて、アプリケーション内で表示します。</span><span class="sxs-lookup"><span data-stu-id="a922f-136">The standard method of presenting help is to display it within the application at the user's request.</span></span> <span data-ttu-id="a922f-137">これを実装するにはいくつかの方法があります。たとえば、ヘルプ ページや、情報の説明などの方法があります。</span><span class="sxs-lookup"><span data-stu-id="a922f-137">There are several ways in which this can be implemented, such as in help pages or informative descriptions.</span></span> <span data-ttu-id="a922f-138">この方法は、複雑でないユーザーの質問に直接回答する、一般的なヘルプに適しています。</span><span class="sxs-lookup"><span data-stu-id="a922f-138">This method is ideal for general-purpose help, that directly answers a user's questions without complexity.</span></span>

[<span data-ttu-id="a922f-139">「アプリ内ヘルプのガイドライン」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a922f-139">See guidelines for in-app help</span></span>](in-app-help.md)

#### <a name="external-help"></a><span data-ttu-id="a922f-140">外部のヘルプ</span><span class="sxs-lookup"><span data-stu-id="a922f-140">External help</span></span>

<span data-ttu-id="a922f-141">詳細なチュートリアル、高度な機能、ヘルプ トピックのライブラリなど、アプリケーション内に収めるには大きすぎるコンテンツは、外部の Web ページへのリンクとすることが適切です。</span><span class="sxs-lookup"><span data-stu-id="a922f-141">For detailed tutorials, advanced functions, or libraries of help topics too large to fit within your application, links to external web pages are ideal.</span></span> <span data-ttu-id="a922f-142">これらのリンクは、ユーザーをアプリケーションから切り離すため、できる限り慎重に使用します。</span><span class="sxs-lookup"><span data-stu-id="a922f-142">These links should be used sparingly if possible, as they remove the user from the application experience.</span></span>

[<span data-ttu-id="a922f-143">外部のヘルプに関するガイドラインをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a922f-143">See guidelines for external help</span></span>](external-help.md)


