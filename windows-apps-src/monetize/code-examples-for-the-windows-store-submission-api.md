---
author: Xansky
ms.assetid: 14C23FE6-3EAF-445E-85C1-DF188A7822CA
description: Microsoft Store 申請 API の使用について詳しくは、このセクションのコード例を使用します。
title: 申請 API 用のコード例
ms.author: mhopkins
ms.date: 07/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, Microsoft Store 申請 API, コード例
ms.localizationpriority: medium
ms.openlocfilehash: f728a17d98d53cf1783452ddfd543c1062156200
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5471441"
---
# <a name="code-examples-for-the-submission-api"></a><span data-ttu-id="b2fab-104">申請 API 用のコード例</span><span class="sxs-lookup"><span data-stu-id="b2fab-104">Code examples for the submission API</span></span>

<span data-ttu-id="b2fab-105">このセクションでは、さまざまなプログラミング言語で、 [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md)を使用するためのコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="b2fab-105">This section provides code examples for using the [Microsoft Store submission API](create-and-manage-submissions-using-windows-store-services.md) in several different programming languages.</span></span>

> [!NOTE]
> <span data-ttu-id="b2fab-106">以下に示したコード例、だけでなく、Microsoft Store 申請 API の上にコマンド ライン インターフェイスを実装するオープン ソースの PowerShell モジュールも提供します。</span><span class="sxs-lookup"><span data-stu-id="b2fab-106">In addition to the code examples listed below, we also provide an open-source PowerShell module which implements a command-line interface on top of the Microsoft Store submission API.</span></span> <span data-ttu-id="b2fab-107">このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="b2fab-107">This module is called [StoreBroker](https://aka.ms/storebroker).</span></span> <span data-ttu-id="b2fab-108">このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="b2fab-108">You can use this module to manage your app, flight, and add-on submissions from the command line instead of calling the Microsoft Store submission API directly, or you can simply browse the source to see more examples for how to call this API.</span></span> <span data-ttu-id="b2fab-109">StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。</span><span class="sxs-lookup"><span data-stu-id="b2fab-109">The StoreBroker module is actively used within Microsoft as the primary way that many first-party applications are submitted to the Store.</span></span> <span data-ttu-id="b2fab-110">詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b2fab-110">For more information, see our [StoreBroker page on GitHub](https://aka.ms/storebroker).</span></span>

## <a name="app-submissions-add-on-submissions-and-package-flight-submissions"></a><span data-ttu-id="b2fab-111">アプリの申請、アドオンの申請、パッケージ フライトの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-111">App submissions, add-on submissions, and package flight submissions</span></span>

<span data-ttu-id="b2fab-112">次の記事では、申請 API を使用してアプリの申請、アドオンの申請、およびパッケージ フライトの申請を作成するためのコード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="b2fab-112">The following articles provide code examples for using the submission API to create app submissions, add-on submissions, and package flight submissions.</span></span>

* [<span data-ttu-id="b2fab-113">C# のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-113">C# sample: submissions for apps, add-ons, and flights</span></span>](csharp-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="b2fab-114">Java のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-114">Java sample: submissions for apps, add-ons, and flights</span></span>](java-code-examples-for-the-windows-store-submission-api.md)
* [<span data-ttu-id="b2fab-115">Python のコード例: アプリ、アドオン、およびフライトの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-115">Python sample: submissions for apps, add-ons, and flights</span></span>](python-code-examples-for-the-windows-store-submission-api.md)

## <a name="game-options-and-trailers"></a><span data-ttu-id="b2fab-116">ゲーム オプションとトレーラー</span><span class="sxs-lookup"><span data-stu-id="b2fab-116">Game options and trailers</span></span>

<span data-ttu-id="b2fab-117">次の記事では、申請 API を使用してゲーム固有のオプションを定義し、アプリのビデオ トレーラーを申請するためのコード例を提供します。</span><span class="sxs-lookup"><span data-stu-id="b2fab-117">The following articles provide code examples for using the submission API to define game-specific options and to submit video trailers for apps.</span></span>

* [<span data-ttu-id="b2fab-118">C# のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-118">C# sample: app submission with game options and trailers</span></span>](csharp-code-examples-for-submissions-game-options-and-trailers.md)
* [<span data-ttu-id="b2fab-119">Java のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-119">Java sample: app submission with game options and trailers</span></span>](java-code-examples-for-submissions-game-options-and-trailers.md)
* [<span data-ttu-id="b2fab-120">Python のコード例: ゲーム オプションおよびトレーラーを含むアプリの申請</span><span class="sxs-lookup"><span data-stu-id="b2fab-120">Python sample: app submission with game options and trailers</span></span>](python-code-examples-for-submissions-game-options-and-trailers.md)

## <a name="related-topics"></a><span data-ttu-id="b2fab-121">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b2fab-121">Related topics</span></span>

* [<span data-ttu-id="b2fab-122">Microsoft Store サービスを使用した申請の作成と管理</span><span class="sxs-lookup"><span data-stu-id="b2fab-122">Create and manage submissions using Microsoft Store services</span></span>](create-and-manage-submissions-using-windows-store-services.md)
