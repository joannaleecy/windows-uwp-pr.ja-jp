---
Description: Design external help pages for detailed instructions and advice about your app.
title: 外部ヘルプ ページを設計するためのガイドライン
label: External help
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 56afd553-c520-4a28-b63d-2e1b3c1d3606
ms.localizationpriority: medium
ms.openlocfilehash: eaca2af3a497de75beaffe5d3af4a261b24d8ba4
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8334332"
---
# <a name="external-help-pages"></a><span data-ttu-id="2789b-103">外部ヘルプ ページ</span><span class="sxs-lookup"><span data-stu-id="2789b-103">External help pages</span></span>



<span data-ttu-id="2789b-104">アプリが、複雑なコンテンツを使った詳細なヘルプを必要とする場合は、それらの説明を Web ページでホストすることを検討します。</span><span class="sxs-lookup"><span data-stu-id="2789b-104">If your app requires detailed help for complex content, consider hosting these instructions on a web page.</span></span>

## <a name="when-to-use-external-help-pages"></a><span data-ttu-id="2789b-105">外部ヘルプ ページを使用する状況</span><span class="sxs-lookup"><span data-stu-id="2789b-105">When to use external help pages</span></span>

<span data-ttu-id="2789b-106">外部ヘルプ ページは、一般的な用途やクイック リファレンスとしては利便性が劣ります。</span><span class="sxs-lookup"><span data-stu-id="2789b-106">External help pages are less convenient for general use or quick reference.</span></span> <span data-ttu-id="2789b-107">これはアプリ自体に組み込むには大きすぎるヘルプ コンテンツに適しています。またチュートリアルや、一般のユーザーにはあまり使われないアプリの高度な機能の説明などにも適しています。</span><span class="sxs-lookup"><span data-stu-id="2789b-107">They are suitable for help content that is too extensive to be incorporated into the app itself, as well as for tutorials and instructions for advanced functions of an app that won't be used by its general audience.</span></span>

<span data-ttu-id="2789b-108">ヘルプ コンテンツが簡潔な場合、またアプリ内の特定の場合に表示するのが望ましい場合には、アプリ内のヘルプを使います。</span><span class="sxs-lookup"><span data-stu-id="2789b-108">If your help content is brief or specific enough to be displayed in-app, you should do so.</span></span> <span data-ttu-id="2789b-109">必要のない限り、ヘルプのためにユーザーをアプリの外部に誘導しないようにします。</span><span class="sxs-lookup"><span data-stu-id="2789b-109">Do not direct users outside of the app for help unless it is necessary.</span></span>

## <a name="navigating-external-help-pages"></a><span data-ttu-id="2789b-110">外部ヘルプ ページのナビゲーション</span><span class="sxs-lookup"><span data-stu-id="2789b-110">Navigating external help pages</span></span>

<span data-ttu-id="2789b-111">ユーザーを外部ヘルプ ページに転送する場合は、次の 2 つのシナリオのいずれかを使用します。</span><span class="sxs-lookup"><span data-stu-id="2789b-111">When a user is directed to an external help page, follow one of two scenarios:</span></span>
-   <span data-ttu-id="2789b-112">既知の問題に対応するページに直接リンクします。</span><span class="sxs-lookup"><span data-stu-id="2789b-112">They are linked directly to the page that corresponds with their known issue.</span></span> <span data-ttu-id="2789b-113">これはコンテキスト ヘルプであり、可能な場合には使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2789b-113">This is contextual help, and should be used when possible.</span></span>
-   <span data-ttu-id="2789b-114">選択するカテゴリとサブカテゴリが明確に表示されている、一般的なヘルプページにリンクします。</span><span class="sxs-lookup"><span data-stu-id="2789b-114">They are linked to a general help page, with a clear display of categories and subcategories to choose from.</span></span>

<span data-ttu-id="2789b-115">ユーザーがヘルプを検索できるようにすることは有用ですが、検索がヘルプ操作の唯一の方法とならないようにします。</span><span class="sxs-lookup"><span data-stu-id="2789b-115">Providing users with a way to search your help can be useful, but do not make this search the only way of navigating your help.</span></span> <span data-ttu-id="2789b-116">ユーザーが問題を記述しにくいこともあり、その場合には検索が困難になります。</span><span class="sxs-lookup"><span data-stu-id="2789b-116">It can sometimes be difficult for users to describe their problems, which can make searching difficult.</span></span> <span data-ttu-id="2789b-117">ユーザーが検索をしなくても、問題に関連のあるページをすぐに見つけられるようにします。</span><span class="sxs-lookup"><span data-stu-id="2789b-117">Users should be able to quickly find pages relevant to their problems without needing to search.</span></span>

## <a name="tutorials-and-detailed-walkthroughs"></a><span data-ttu-id="2789b-118">チュートリアルと詳細なウォークスルー</span><span class="sxs-lookup"><span data-stu-id="2789b-118">Tutorials and detailed walkthroughs</span></span>

<span data-ttu-id="2789b-119">外部ヘルプ ページは、ビデオやテキストを使って、ユーザーにチュートリアルや詳細なウォークスルーを提供するのに最適です。</span><span class="sxs-lookup"><span data-stu-id="2789b-119">External help pages are the ideal place to provide users with tutorials and walkthroughs, whether video or textual.</span></span>
-   <span data-ttu-id="2789b-120">チュートリアルでは、より複雑な用途や高度な機能に焦点を当てます。</span><span class="sxs-lookup"><span data-stu-id="2789b-120">Tutorials should focus on more complicated ideas and advanced functions.</span></span> <span data-ttu-id="2789b-121">ユーザーがアプリを使うためには、チュートリアルを必要としないようにします。</span><span class="sxs-lookup"><span data-stu-id="2789b-121">Users shouldn't need a tutorial to use your app.</span></span>
-   <span data-ttu-id="2789b-122">チュートリアルは標準のヘルプとは異なる方法で表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="2789b-122">Make sure that these tutorials are displayed differently from standard help instructions.</span></span> <span data-ttu-id="2789b-123">高度な使い方を求めているユーザーは、問題に対する直接の解決策を求めるユーザーよりも、より進んで検索を行います。</span><span class="sxs-lookup"><span data-stu-id="2789b-123">Users who are looking for advanced instructions are more eager to search for them than users who want straightforward solutions to their problems.</span></span>
-   <span data-ttu-id="2789b-124">ディレクトリと各チュートリアルに対応する個々のヘルプ ページの両方から、チュートリアルへのリンクを行うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="2789b-124">Consider linking to tutorials from both a directory and from individual help pages that correspond to each tutorial.</span></span>

## <a name="related-articles"></a><span data-ttu-id="2789b-125">関連記事</span><span class="sxs-lookup"><span data-stu-id="2789b-125">Related articles</span></span>

* [<span data-ttu-id="2789b-126">アプリのヘルプのガイドライン</span><span class="sxs-lookup"><span data-stu-id="2789b-126">Guidelines for app help</span></span>](guidelines-for-app-help.md)
