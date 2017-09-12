---
author: mcleanbyron
ms.assetid: 14C23FE6-3EAF-445E-85C1-DF188A7822CA
description: "このセクションのコード例を使用して、Windows ストア申請 API を使用する方法をご確認ください。"
title: "申請 API 用のコード例"
ms.author: mcleans
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, コード例"
ms.openlocfilehash: c5344667922a7445ad7694f36a542b3ff35c4bdb
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="code-examples-for-the-submission-api"></a><span data-ttu-id="253c8-104">申請 API 用のコード例</span><span class="sxs-lookup"><span data-stu-id="253c8-104">Code examples for the submission API</span></span>

<span data-ttu-id="253c8-105">このセクションでは、さまざまなプログラミング言語で [Windows ストア申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用するためのコード例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="253c8-105">This section provides code examples for using the [Windows Store submission API](create-and-manage-submissions-using-windows-store-services.md) in several different programming languages.</span></span>

> [!NOTE]
> <span data-ttu-id="253c8-106">以下に示したコード例に加えて、Windows ストア申請 API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意しています。</span><span class="sxs-lookup"><span data-stu-id="253c8-106">In addition to the code examples listed below, we also provide an open-source PowerShell module which implements a command-line interface on top of the Windows Store submission API.</span></span> <span data-ttu-id="253c8-107">このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="253c8-107">This module is called [StoreBroker](https://aka.ms/storebroker).</span></span> <span data-ttu-id="253c8-108">このモジュールを使うと、Windows ストア申請 API を直接呼び出さずにコマンド ラインからアプリ、フライト、アドオンの申請を管理できます。または、ソースをそのまま参照して、この API を呼び出す方法の他の例を確認できます。</span><span class="sxs-lookup"><span data-stu-id="253c8-108">You can use this module to manage your app, flight, and add-on submissions from the command line instead of calling the Windows Store submission API directly, or you can simply browse the source to see more examples for how to call this API.</span></span> <span data-ttu-id="253c8-109">StoreBroker モジュールは、Microsoft 社内でも、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として積極的に使用されています。</span><span class="sxs-lookup"><span data-stu-id="253c8-109">The StoreBroker module is actively used within Microsoft as the primary way that many first-party applications are submitted to the Store.</span></span> <span data-ttu-id="253c8-110">詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="253c8-110">For more information, see our [StoreBroker page on GitHub](https://aka.ms/storebroker).</span></span>

## <a name="app-submissions-add-on-submissions-and-package-flight-submissions"></a><span data-ttu-id="253c8-111">アプリの申請、アドオンの申請、パッケージ フライトの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-111">App submissions, add-on submissions, and package flight submissions</span></span>

<span data-ttu-id="253c8-112">次の記事では、申請 API を使用してアプリの申請、アドオンの申請、およびパッケージ フライトの申請を作成するためのコード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="253c8-112">The following articles provide code examples for using the submission API to create app submissions, add-on submissions, and package flight submissions.</span></span>

* [<span data-ttu-id="253c8-113">C# のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-113">C# sample: submissions for apps, add-ons, and flights</span></span>](csharp-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="253c8-114">Java のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-114">Java sample: submissions for apps, add-ons, and flights</span></span>](java-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="253c8-115">Python のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-115">Python sample: submissions for apps, add-ons, and flights</span></span>](python-code-examples-for-the-windows-store-submission-api.md)

## <a name="game-options-and-trailers"></a><span data-ttu-id="253c8-116">ゲーム オプションとトレーラー</span><span class="sxs-lookup"><span data-stu-id="253c8-116">Game options and trailers</span></span>

<span data-ttu-id="253c8-117">次の記事では、申請 API を使用してゲーム固有のオプションを定義し、アプリのビデオ トレーラーを申請するためのコード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="253c8-117">The following articles provide code examples for using the submission API to define game-specific options and to submit video trailers for apps.</span></span>

* [<span data-ttu-id="253c8-118">C# のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-118">C# sample: app submission with game options and trailers</span></span>](csharp-code-examples-for-submissions-game-options-and-trailers.md)
* [<span data-ttu-id="253c8-119">Java のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-119">Java sample: app submission with game options and trailers</span></span>](java-code-examples-for-submissions-game-options-and-trailers.md)
* [<span data-ttu-id="253c8-120">Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="253c8-120">Python sample: app submission with game options and trailers</span></span>](python-code-examples-for-submissions-game-options-and-trailers.md)

## <a name="related-topics"></a><span data-ttu-id="253c8-121">関連トピック</span><span class="sxs-lookup"><span data-stu-id="253c8-121">Related topics</span></span>

* [<span data-ttu-id="253c8-122">Windows ストア サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="253c8-122">Create and manage submissions using Windows Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
