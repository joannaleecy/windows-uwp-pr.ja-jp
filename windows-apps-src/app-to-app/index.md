---
ms.assetid: E0728EB0-DFC3-4203-A367-8997B16E2328
description: "ここでは、共有コントラクトの使用、コピーと貼り付け、ドラッグ アンド ドロップなど、ユニバーサル Windows プラットフォーム (UWP) アプリ間でデータを共有する方法について説明します。"
title: "アプリ間通信"
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 938c2d20067dc99a84939c8501971a06fa702515
ms.sourcegitcommit: 23cda44f10059bcaef38ae73fd1d7c8b8330c95e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/19/2017
---
# <a name="app-to-app-communication"></a><span data-ttu-id="96adb-104">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="96adb-104">App-to-app communication</span></span>

<span data-ttu-id="96adb-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="96adb-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="96adb-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="96adb-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="96adb-107">ここでは、共有コントラクトの使用、コピーと貼り付け、ドラッグ アンド ドロップなど、ユニバーサル Windows プラットフォーム (UWP) アプリ間でデータを共有する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="96adb-107">This section explains how to share data between Universal Windows Platform (UWP) apps, including how to use the Share contract, copy and paste, and drag and drop.</span></span>

<span data-ttu-id="96adb-108">共有コントラクトを使うと、データをアプリ間ですばやく交換できます。</span><span class="sxs-lookup"><span data-stu-id="96adb-108">The Share contract is one way users can quickly exchange data between apps.</span></span> <span data-ttu-id="96adb-109">たとえば、ユーザーがソーシャル ネットワーキング アプリを使って友人と Web ページを共有する場合や、後で参照するためにリンクをメモ帳アプリで保存する場合があります。</span><span class="sxs-lookup"><span data-stu-id="96adb-109">For example, a user might want to share a webpage with their friends using a social networking app, or save a link in a notes app to refer to later.</span></span> <span data-ttu-id="96adb-110">別のアプリのコンテキストですばやくコンテンツを受け取ることができるようなシナリオを実現するには、共有コントラクトの利用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="96adb-110">Consider using a Share contract if your app receives content in scenarios that a user can quickly complete while in the context of another app.</span></span>

<span data-ttu-id="96adb-111">アプリで共有機能をサポートする方法は 2 種類あります。</span><span class="sxs-lookup"><span data-stu-id="96adb-111">An app can support the Share feature in two ways.</span></span> <span data-ttu-id="96adb-112">共有するコンテンツを提供する側のソース アプリにする方法と、</span><span class="sxs-lookup"><span data-stu-id="96adb-112">First, it can be a source app that provides content that the user wants to share.</span></span> <span data-ttu-id="96adb-113">共有コンテンツを受け取る側のターゲット アプリにする方法です </span><span class="sxs-lookup"><span data-stu-id="96adb-113">Second, the app can be a target app that the user selects as the destination for shared content.</span></span> <span data-ttu-id="96adb-114">(アプリはソース アプリにすることもターゲット アプリにすることもできます)。</span><span class="sxs-lookup"><span data-stu-id="96adb-114">An app can also be both a source app and a target app.</span></span> <span data-ttu-id="96adb-115">アプリをソース アプリにしてコンテンツを共有する場合は、アプリで提供できるデータ形式を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96adb-115">If you want your app to share content as a source app, you need to decide what data formats your app can provide.</span></span>

<span data-ttu-id="96adb-116">共有コントラクトに加えて、アプリは、ドラッグ アンド ドロップやコピーと貼り付けなど、データを転送するための従来の手法を統合することもできます。</span><span class="sxs-lookup"><span data-stu-id="96adb-116">In addition to the Share contract, apps can also integrate classic techniques for transferring data, such as dragging and dropping or copy and pasting.</span></span> <span data-ttu-id="96adb-117">UWP アプリ間の通信だけでなく、こうした手法はデスクトップ アプリケーション間の共有もサポートします。</span><span class="sxs-lookup"><span data-stu-id="96adb-117">In addition to communication between UWP apps, these methods also support sharing to and from desktop applications.</span></span>



## <a name="in-this-section"></a><span data-ttu-id="96adb-118">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="96adb-118">In this section</span></span>

| <span data-ttu-id="96adb-119">トピック</span><span class="sxs-lookup"><span data-stu-id="96adb-119">Topic</span></span> | <span data-ttu-id="96adb-120">説明</span><span class="sxs-lookup"><span data-stu-id="96adb-120">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="96adb-121">データの共有</span><span class="sxs-lookup"><span data-stu-id="96adb-121">Share data</span></span>](share-data.md) | <span data-ttu-id="96adb-122">この記事では、UWP アプリで共有コントラクトをサポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="96adb-122">This article explains how to support the Share contract in a UWP app.</span></span> <span data-ttu-id="96adb-123">共有コントラクトは、テキスト、リンク、写真、ビデオなどのデータをアプリ間ですばやく共有するための簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="96adb-123">The Share contract is an easy way to quickly share data, such as text, links, photos, and videos, between apps.</span></span> <span data-ttu-id="96adb-124">たとえば、ユーザーがソーシャル ネットワーキング アプリを使って友人と Web ページを共有する場合や、後で参照するためにリンクをメモ帳アプリで保存する場合があります。</span><span class="sxs-lookup"><span data-stu-id="96adb-124">For example, a user might want to share a webpage with their friends using a social networking app, or save a link in a notes app to refer to later.</span></span> |
| [<span data-ttu-id="96adb-125">データの受信</span><span class="sxs-lookup"><span data-stu-id="96adb-125">Receive data</span></span>](receive-data.md) | <span data-ttu-id="96adb-126">この記事では、UWP アプリで、共有コントラクトを使って別のアプリから共有されたコンテンツを受け取る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="96adb-126">This article explains how to receive content in your UWP app shared from another app using Share contract.</span></span> <span data-ttu-id="96adb-127">共有コントラクトを使うと、ユーザーが共有機能を呼び出したときに、アプリをオプションとして提示できます。</span><span class="sxs-lookup"><span data-stu-id="96adb-127">This Share contract allows your app to be presented as an option when the user invokes Share.</span></span> |
| [<span data-ttu-id="96adb-128">コピーと貼り付け</span><span class="sxs-lookup"><span data-stu-id="96adb-128">Copy and paste</span></span>](copy-and-paste.md) | <span data-ttu-id="96adb-129">この記事では、UWP アプリで、クリップボードを使ってコピーと貼り付けをサポートする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="96adb-129">This article explains how to support copy and paste in UWP apps using the clipboard.</span></span> <span data-ttu-id="96adb-130">コピーと貼り付けはアプリ間やアプリ内でデータを交換するための従来の方法であり、クリップボード操作はほとんどすべてのアプリである程度サポートできます。</span><span class="sxs-lookup"><span data-stu-id="96adb-130">Copy and paste is the classic way to exchange data either between apps, or within an app, and almost every app can support clipboard operations to some degree.</span></span> |
| [<span data-ttu-id="96adb-131">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="96adb-131">Drag and drop</span></span>](drag-and-drop.md) | <span data-ttu-id="96adb-132">この記事では、UWP アプリにドラッグ アンド ドロップを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="96adb-132">This article explains how to add dragging and dropping in your UWP app.</span></span> <span data-ttu-id="96adb-133">ドラッグ アンド ドロップは、画像やファイルなどのコンテンツを操作するための従来からある自然な方法です。</span><span class="sxs-lookup"><span data-stu-id="96adb-133">Drag and drop is a classic, natural way of interacting with content such as images and files.</span></span> <span data-ttu-id="96adb-134">ドラッグ アンド ドロップを実装すると、アプリからアプリ、アプリからデスクトップ、デスクトップからアプリなど、あらゆる方向でシームレスに機能します。</span><span class="sxs-lookup"><span data-stu-id="96adb-134">Once implemented, drag and drop works seamlessly in all directions, including app-to-app, app-to-desktop, and desktop-to app.</span></span> |

## <a name="see-also"></a><span data-ttu-id="96adb-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="96adb-135">See also</span></span>
- [<span data-ttu-id="96adb-136">UWP アプリの開発</span><span class="sxs-lookup"><span data-stu-id="96adb-136">Develop UWP apps</span></span>](https://developer.microsoft.com/windows/develop)
