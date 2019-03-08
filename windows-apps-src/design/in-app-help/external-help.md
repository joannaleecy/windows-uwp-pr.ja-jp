---
Description: アプリに関する詳細な説明やアドバイスのための、外部ヘルプ ページを設計します。
title: 外部ヘルプ ページを設計するためのガイドライン
label: External help
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 56afd553-c520-4a28-b63d-2e1b3c1d3606
ms.localizationpriority: medium
ms.openlocfilehash: eaca2af3a497de75beaffe5d3af4a261b24d8ba4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617177"
---
# <a name="external-help-pages"></a><span data-ttu-id="82189-104">外部ヘルプ ページ</span><span class="sxs-lookup"><span data-stu-id="82189-104">External help pages</span></span>



<span data-ttu-id="82189-105">アプリが、複雑なコンテンツを使った詳細なヘルプを必要とする場合は、それらの説明を Web ページでホストすることを検討します。</span><span class="sxs-lookup"><span data-stu-id="82189-105">If your app requires detailed help for complex content, consider hosting these instructions on a web page.</span></span>

## <a name="when-to-use-external-help-pages"></a><span data-ttu-id="82189-106">外部ヘルプ ページを使用する状況</span><span class="sxs-lookup"><span data-stu-id="82189-106">When to use external help pages</span></span>

<span data-ttu-id="82189-107">外部ヘルプ ページは、一般的な用途やクイック リファレンスとしては利便性が劣ります。</span><span class="sxs-lookup"><span data-stu-id="82189-107">External help pages are less convenient for general use or quick reference.</span></span> <span data-ttu-id="82189-108">これはアプリ自体に組み込むには大きすぎるヘルプ コンテンツに適しています。またチュートリアルや、一般のユーザーにはあまり使われないアプリの高度な機能の説明などにも適しています。</span><span class="sxs-lookup"><span data-stu-id="82189-108">They are suitable for help content that is too extensive to be incorporated into the app itself, as well as for tutorials and instructions for advanced functions of an app that won't be used by its general audience.</span></span>

<span data-ttu-id="82189-109">ヘルプ コンテンツが簡潔な場合、またアプリ内の特定の場合に表示するのが望ましい場合には、アプリ内のヘルプを使います。</span><span class="sxs-lookup"><span data-stu-id="82189-109">If your help content is brief or specific enough to be displayed in-app, you should do so.</span></span> <span data-ttu-id="82189-110">必要のない限り、ヘルプのためにユーザーをアプリの外部に誘導しないようにします。</span><span class="sxs-lookup"><span data-stu-id="82189-110">Do not direct users outside of the app for help unless it is necessary.</span></span>

## <a name="navigating-external-help-pages"></a><span data-ttu-id="82189-111">外部ヘルプ ページのナビゲーション</span><span class="sxs-lookup"><span data-stu-id="82189-111">Navigating external help pages</span></span>

<span data-ttu-id="82189-112">ユーザーを外部ヘルプ ページに転送する場合は、次の 2 つのシナリオのいずれかを使用します。</span><span class="sxs-lookup"><span data-stu-id="82189-112">When a user is directed to an external help page, follow one of two scenarios:</span></span>
-   <span data-ttu-id="82189-113">既知の問題に対応するページに直接リンクします。</span><span class="sxs-lookup"><span data-stu-id="82189-113">They are linked directly to the page that corresponds with their known issue.</span></span> <span data-ttu-id="82189-114">これはコンテキスト ヘルプであり、可能な場合には使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="82189-114">This is contextual help, and should be used when possible.</span></span>
-   <span data-ttu-id="82189-115">選択するカテゴリとサブカテゴリが明確に表示されている、一般的なヘルプページにリンクします。</span><span class="sxs-lookup"><span data-stu-id="82189-115">They are linked to a general help page, with a clear display of categories and subcategories to choose from.</span></span>

<span data-ttu-id="82189-116">ユーザーがヘルプを検索できるようにすることは有用ですが、検索がヘルプ操作の唯一の方法とならないようにします。</span><span class="sxs-lookup"><span data-stu-id="82189-116">Providing users with a way to search your help can be useful, but do not make this search the only way of navigating your help.</span></span> <span data-ttu-id="82189-117">ユーザーが問題を記述しにくいこともあり、その場合には検索が困難になります。</span><span class="sxs-lookup"><span data-stu-id="82189-117">It can sometimes be difficult for users to describe their problems, which can make searching difficult.</span></span> <span data-ttu-id="82189-118">ユーザーが検索をしなくても、問題に関連のあるページをすぐに見つけられるようにします。</span><span class="sxs-lookup"><span data-stu-id="82189-118">Users should be able to quickly find pages relevant to their problems without needing to search.</span></span>

## <a name="tutorials-and-detailed-walkthroughs"></a><span data-ttu-id="82189-119">チュートリアルと詳細なウォークスルー</span><span class="sxs-lookup"><span data-stu-id="82189-119">Tutorials and detailed walkthroughs</span></span>

<span data-ttu-id="82189-120">外部ヘルプ ページは、ビデオやテキストを使って、ユーザーにチュートリアルや詳細なウォークスルーを提供するのに最適です。</span><span class="sxs-lookup"><span data-stu-id="82189-120">External help pages are the ideal place to provide users with tutorials and walkthroughs, whether video or textual.</span></span>
-   <span data-ttu-id="82189-121">チュートリアルでは、より複雑な用途や高度な機能に焦点を当てます。</span><span class="sxs-lookup"><span data-stu-id="82189-121">Tutorials should focus on more complicated ideas and advanced functions.</span></span> <span data-ttu-id="82189-122">ユーザーがアプリを使うためには、チュートリアルを必要としないようにします。</span><span class="sxs-lookup"><span data-stu-id="82189-122">Users shouldn't need a tutorial to use your app.</span></span>
-   <span data-ttu-id="82189-123">チュートリアルは標準のヘルプとは異なる方法で表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="82189-123">Make sure that these tutorials are displayed differently from standard help instructions.</span></span> <span data-ttu-id="82189-124">高度な使い方を求めているユーザーは、問題に対する直接の解決策を求めるユーザーよりも、より進んで検索を行います。</span><span class="sxs-lookup"><span data-stu-id="82189-124">Users who are looking for advanced instructions are more eager to search for them than users who want straightforward solutions to their problems.</span></span>
-   <span data-ttu-id="82189-125">ディレクトリと各チュートリアルに対応する個々のヘルプ ページの両方から、チュートリアルへのリンクを行うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="82189-125">Consider linking to tutorials from both a directory and from individual help pages that correspond to each tutorial.</span></span>

## <a name="related-articles"></a><span data-ttu-id="82189-126">関連記事</span><span class="sxs-lookup"><span data-stu-id="82189-126">Related articles</span></span>

* [<span data-ttu-id="82189-127">アプリのヘルプに関するガイドライン</span><span class="sxs-lookup"><span data-stu-id="82189-127">Guidelines for app help</span></span>](guidelines-for-app-help.md)
