---
Description: このガイドラインは、アプリの効果的なヘルプ コンテンツの設計方法を説明しています。
title: アプリのヘルプのガイドライン
label: Guidelines for app help
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: c3e73f9b-4839-4804-b379-c95b0ca4fbe8
ms.localizationpriority: medium
ms.openlocfilehash: bd2174c6bbfb84a3ea6c6956e1d0b02ed5c9be33
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57621367"
---
# <a name="guidelines-for-app-help"></a><span data-ttu-id="2b30e-104">アプリのヘルプのガイドライン</span><span class="sxs-lookup"><span data-stu-id="2b30e-104">Guidelines for App Help</span></span>



<span data-ttu-id="2b30e-105">アプリケーションが複雑な場合には、ユーザーに効果的なヘルプを提供することにより、ユーザー エクスペリエンスを大幅に改善できます。</span><span class="sxs-lookup"><span data-stu-id="2b30e-105">Applications can be complex, and providing effective help for your users can greatly improve their experience.</span></span> <span data-ttu-id="2b30e-106">すべてのアプリケーションがユーザーにヘルプを提供する必要があるとは限らず、また提供する必要のあるヘルプの種類もアプリケーションによって大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-106">Not all applications need to provide help for their users, and what sort of help should be provided can vary greatly, depending on the application.</span></span>

<span data-ttu-id="2b30e-107">ヘルプを提供する場合には、その作成時に次のガイドラインに従います。</span><span class="sxs-lookup"><span data-stu-id="2b30e-107">If you decide to provide help, follow these guidelines when creating it.</span></span> <span data-ttu-id="2b30e-108">有用でないヘルプを提供するくらいなら、ヘルプを提供しないほうがましであるという場合もあります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-108">Help that isn't helpful can be worse than no help at all.</span></span>

## <a name="intuitive-design"></a><span data-ttu-id="2b30e-109">直感的なデザイン</span><span class="sxs-lookup"><span data-stu-id="2b30e-109">Intuitive Design</span></span>

<span data-ttu-id="2b30e-110">ヘルプのコンテンツをどれだけ充実させたとしても、アプリがユーザーに優れたエクスペリエンスを提供するには、ヘルプに依存することはできません。</span><span class="sxs-lookup"><span data-stu-id="2b30e-110">As useful as help content can be, your app cannot rely on it to provide a good experience for the user.</span></span> <span data-ttu-id="2b30e-111">ユーザーは、アプリの重要な機能がすぐに見つからずに使えない場合には、アプリの使用をやめてしまいます。</span><span class="sxs-lookup"><span data-stu-id="2b30e-111">If the user is unable to immediately discover and use the critical functions of your app, the user will not use your app.</span></span> <span data-ttu-id="2b30e-112">ヘルプの質と量がどれだけ優れていても、第一印象を変えることはできません。</span><span class="sxs-lookup"><span data-stu-id="2b30e-112">No amount or quality help will change that first impression.</span></span>

<span data-ttu-id="2b30e-113">直感的でわかりやすいデザインは、有用なヘルプを作成するための最初の手順です。</span><span class="sxs-lookup"><span data-stu-id="2b30e-113">An intuitive and user-friendly design is the first step to writing useful help.</span></span> <span data-ttu-id="2b30e-114">ユーザーが関心を持ち続けて、やがてより高度な機能を使うようになるだけではありません。アプリの主要機能の知識を提供することにより、アプリを使用してその習得を継続するにつれて、知識が蓄積されていきます。</span><span class="sxs-lookup"><span data-stu-id="2b30e-114">Not only does it keep the user engaged for long enough for them to use more advanced features, but it also provides them with knowledge of an app's core functions, which they can build upon as they continue to use the app and learn.</span></span>

## <a name="general-instructions"></a><span data-ttu-id="2b30e-115">一般的な手順</span><span class="sxs-lookup"><span data-stu-id="2b30e-115">General instructions</span></span>

<span data-ttu-id="2b30e-116">ユーザーは問題が発生していない場合には、ヘルプ コンテンツを探すことはありません。ヘルプは問題に対する回答をすばやく効果的に提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-116">A user will not look for help content unless they already have a problem, so help needs to provide a quick and effective answer to that problem.</span></span> <span data-ttu-id="2b30e-117">ヘルプが即座に有用でない場合や、ヘルプが複雑すぎる場合は、ユーザーはそれを無視する可能性が高くなります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-117">If help is not immediately useful, or if help is too complicated, then users are more likely to ignore it.</span></span>

<span data-ttu-id="2b30e-118">あらゆるヘルプは、次の原則に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-118">All help, no matter what kind, should follow these principles:</span></span>

-   <span data-ttu-id="2b30e-119">**簡単に理解できます。** ユーザーの混乱を招くヘルプはすべてのヘルプはありませんよりも悪いされます。</span><span class="sxs-lookup"><span data-stu-id="2b30e-119">**Easy to understand:** Help that confuses the user is worse than no help at all.</span></span>

-   <span data-ttu-id="2b30e-120">**簡単です。** 探しているユーザーは、回答がそれらに直接提示を消去するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2b30e-120">**Straightforward:** Users looking for help want clear answers presented directly to them.</span></span>

-   <span data-ttu-id="2b30e-121">**関連。** ユーザーは、その特定の問題を検索する必要がありますしません。</span><span class="sxs-lookup"><span data-stu-id="2b30e-121">**Relevant:** Users do not want to have to search for their specific issue.</span></span> <span data-ttu-id="2b30e-122">ユーザーはその場面に最も関連があって適切なヘルプ (コンテキスト ヘルプと呼ばれます) がすぐに表示されることを求めています。または容易なナビゲーションのためのインターフェイスが必要です。</span><span class="sxs-lookup"><span data-stu-id="2b30e-122">They want the most relevant help presented straight to them (this is called "Contextual Help"), or they want an easily navigated interface.</span></span>

-   <span data-ttu-id="2b30e-123">**直接。** ユーザーは、ヘルプを検索するときに表示するヘルプ。</span><span class="sxs-lookup"><span data-stu-id="2b30e-123">**Direct:** When a user looks for help, they want to see help.</span></span> <span data-ttu-id="2b30e-124">アプリのヘルプの中に、バグの報告、フィードバックの送信、サービス規定の表示などの機能へのリンクが含まれていてもかまいませんが、</span><span class="sxs-lookup"><span data-stu-id="2b30e-124">If your app includes pages for reporting bugs, giving feedback, viewing term of service, or similar functions, it is fine if your help links to those pages.</span></span> <span data-ttu-id="2b30e-125">それらはメインのヘルプ ページの補足として含むものであり、メインのヘルプのコンテンツとなるものではありません。</span><span class="sxs-lookup"><span data-stu-id="2b30e-125">But they should be included as an afterthought on the main help page, and not as items of equal or greater importance.</span></span>

-   <span data-ttu-id="2b30e-126">**一貫性のあります。** 種類に関係なくヘルプは、アプリの一部ではまだと UI の他の部分として扱う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-126">**Consistent:** No matter the type, help is still a part of your app, and should be treated as any other part of the UI.</span></span> <span data-ttu-id="2b30e-127">アプリの他の部分と同じ設計原則による、操作性、アクセシビリティ、スタイルが、ヘルプでも採用されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-127">The same design principles of usability, accessibility, and style which are used throughout the rest of your app should also be present in the help you offer.</span></span>

## <a name="types-of-help"></a><span data-ttu-id="2b30e-128">ヘルプの種類</span><span class="sxs-lookup"><span data-stu-id="2b30e-128">Types of help</span></span>

<span data-ttu-id="2b30e-129">ヘルプ コンテンツには 3 つの主要なカテゴリがあり、それぞれにメリットと適性があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-129">There are three primary categories of help content, each with varying strengths and suitable for different purposes.</span></span> <span data-ttu-id="2b30e-130">アプリの必要に応じて、これらを組み合わせて使用します。</span><span class="sxs-lookup"><span data-stu-id="2b30e-130">Use any combination of them in your app, depending on your needs.</span></span>

#### <a name="instructional-ui"></a><span data-ttu-id="2b30e-131">説明 UI</span><span class="sxs-lookup"><span data-stu-id="2b30e-131">Instructional UI</span></span>

<span data-ttu-id="2b30e-132">通常の場合、ユーザーはアプリの主要な機能のすべてを、操作手順を読まなくても使える必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-132">Normally, users should be able to use all the core functions of your app without instruction.</span></span> <span data-ttu-id="2b30e-133">場合によっては、アプリが特定のジェスチャの使用に依存していたり、すぐには自明ではない別の機能がある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-133">But sometimes, your app will depend on use of a specific gesture, or there may be secondary features of your app which are not immediately obvious.</span></span> <span data-ttu-id="2b30e-134">そのような場合には、説明 UI によってユーザーに特定のタスクの使い方を教えることができます。</span><span class="sxs-lookup"><span data-stu-id="2b30e-134">In this case, instructional UI should be used to educate users with instructions on how to perform specific tasks.</span></span>

[<span data-ttu-id="2b30e-135">説明用の UI のガイドラインを参照してください。</span><span class="sxs-lookup"><span data-stu-id="2b30e-135">See guidelines for instructional UI</span></span>](instructional-ui.md)

#### <a name="in-app-help"></a><span data-ttu-id="2b30e-136">アプリ内ヘルプ</span><span class="sxs-lookup"><span data-stu-id="2b30e-136">In-app help</span></span>

<span data-ttu-id="2b30e-137">ヘルプを表示する標準的な方法では、ユーザーの要求に応じて、アプリケーション内で表示します。</span><span class="sxs-lookup"><span data-stu-id="2b30e-137">The standard method of presenting help is to display it within the application at the user's request.</span></span> <span data-ttu-id="2b30e-138">これを実装するにはいくつかの方法があります。たとえば、ヘルプ ページや、情報の説明などの方法があります。</span><span class="sxs-lookup"><span data-stu-id="2b30e-138">There are several ways in which this can be implemented, such as in help pages or informative descriptions.</span></span> <span data-ttu-id="2b30e-139">この方法は、複雑でないユーザーの質問に直接回答する、一般的なヘルプに適しています。</span><span class="sxs-lookup"><span data-stu-id="2b30e-139">This method is ideal for general-purpose help, that directly answers a user's questions without complexity.</span></span>

[<span data-ttu-id="2b30e-140">アプリ内のヘルプに関するガイドラインを参照してください。</span><span class="sxs-lookup"><span data-stu-id="2b30e-140">See guidelines for in-app help</span></span>](in-app-help.md)

#### <a name="external-help"></a><span data-ttu-id="2b30e-141">外部のヘルプ</span><span class="sxs-lookup"><span data-stu-id="2b30e-141">External help</span></span>

<span data-ttu-id="2b30e-142">詳細なチュートリアル、高度な機能、ヘルプ トピックのライブラリなど、アプリケーション内に収めるには大きすぎるコンテンツは、外部の Web ページへのリンクとすることが適切です。</span><span class="sxs-lookup"><span data-stu-id="2b30e-142">For detailed tutorials, advanced functions, or libraries of help topics too large to fit within your application, links to external web pages are ideal.</span></span> <span data-ttu-id="2b30e-143">これらのリンクは、ユーザーをアプリケーションから切り離すため、できる限り慎重に使用します。</span><span class="sxs-lookup"><span data-stu-id="2b30e-143">These links should be used sparingly if possible, as they remove the user from the application experience.</span></span>

[<span data-ttu-id="2b30e-144">外部ヘルプに関するガイドラインを参照してください。</span><span class="sxs-lookup"><span data-stu-id="2b30e-144">See guidelines for external help</span></span>](external-help.md)


