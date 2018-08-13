---
author: PatrickFarley
title: URI を使ったアプリの起動
description: このセクションでは、URI (Uniform Resource Identifier) を使って別のアプリからアプリを起動する方法について説明します。
ms.assetid: a40c4ce2-4f41-4a55-aeb3-1beb3e84e839
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7ba630de58e544a9bb84640ab743d1cf67b2fe74
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "299956"
---
# <a name="launch-an-app-with-a-uri"></a><span data-ttu-id="91745-104">URI を使ったアプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-104">Launch an app with a URI</span></span>

<span data-ttu-id="91745-105">このセクションでは、URI (Uniform Resource Identifier) を使って別のアプリから 1 つのアプリを起動し、複数のアプリを使ったシナリオを実現する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-105">This section describes how to use a Uniform Resource Identifier (URI) to launch one app from another app, enabling helpful app-to-app scenarios.</span></span>

| <span data-ttu-id="91745-106">トピック</span><span class="sxs-lookup"><span data-stu-id="91745-106">Topic</span></span> | <span data-ttu-id="91745-107">説明</span><span class="sxs-lookup"><span data-stu-id="91745-107">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="91745-108">URI に応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-108">Launch the default app for a URI</span></span>](launch-default-app.md) | <span data-ttu-id="91745-109">URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-109">Learn how to launch the default app for a Uniform Resource Identifier (URI).</span></span> <span data-ttu-id="91745-110">URI を使うと、別のアプリを起動して特定の作業を実行できます。</span><span class="sxs-lookup"><span data-stu-id="91745-110">URIs allow you to launch another app to perform a specific task.</span></span> <span data-ttu-id="91745-111">また、Windows に組み込まれている多くの URI スキームの概要についても説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-111">This topic also provides an overview of the many URI schemes built into Windows.</span></span> |
| [<span data-ttu-id="91745-112">URI のアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="91745-112">Handle URI activation</span></span>](handle-uri-activation.md) | <span data-ttu-id="91745-113">URI (Uniform Resource Identifier) スキーム名の既定のハンドラーとしてアプリを登録する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-113">Learn how to register an app to become the default handler for a Uniform Resource Identifier (URI) scheme name.</span></span> |
| [<span data-ttu-id="91745-114">結果を取得するためのアプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-114">Launch an app for results</span></span>](how-to-launch-an-app-for-results.md) | <span data-ttu-id="91745-115">別のアプリからアプリを起動し、2 つのアプリの間でデータを交換する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-115">Learn how to launch an app from another app and exchange data between the two.</span></span> <span data-ttu-id="91745-116">これは、"結果を取得するためのアプリの起動" と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="91745-116">This is called launching an app for results.</span></span> |
| [<span data-ttu-id="91745-117">ms-tonepicker URI スキームを使ったトーンの選択と保存</span><span class="sxs-lookup"><span data-stu-id="91745-117">Choose and save tones using the ms-tonepicker URI scheme</span></span>](launch-ringtone-picker.md) | <span data-ttu-id="91745-118">このトピックでは、ms-tonepicker URI スキームと、このスキームを使ってトーンの選択コントロールを表示し、トーンの選択、トーンの保存、トーンのフレンドリ名を取得する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-118">This topic describes the ms-tonepicker URI scheme and how to use it to display a tone picker to select a tone, save a tone, and get the friendly name for a tone.</span></span> |
| [<span data-ttu-id="91745-119">Windows 設定アプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-119">Launch the Windows Settings app</span></span>](launch-settings-app.md) | <span data-ttu-id="91745-120">アプリから Windows 設定アプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-120">Learn how to launch the Windows Settings app from your app.</span></span> <span data-ttu-id="91745-121">ここでは、ms-settings URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-121">This topic describes the ms-settings URI scheme.</span></span> <span data-ttu-id="91745-122">Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。</span><span class="sxs-lookup"><span data-stu-id="91745-122">Use this URI scheme to launch the Windows Settings app to specific settings pages.</span></span> |
| [<span data-ttu-id="91745-123">UWP アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="91745-123">Launch the UWP app</span></span>](launch-store-app.md) | <span data-ttu-id="91745-124">ここでは、ms-windows-store URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-124">This topic describes the ms-windows-store URI scheme.</span></span> <span data-ttu-id="91745-125">アプリでこの URI スキームを使って、UWP アプリを起動し、Store 内の特定のページを表示できます。</span><span class="sxs-lookup"><span data-stu-id="91745-125">Your app can use this URI scheme to launch the UWP app to specific pages in the Store.</span></span> |
| [<span data-ttu-id="91745-126">Windows マップ アプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-126">Launch the Windows Maps app</span></span>](launch-maps-app.md) | <span data-ttu-id="91745-127">アプリから Windows マップ アプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-127">Learn how to launch the Windows Maps app from your app.</span></span> |
| [<span data-ttu-id="91745-128">People アプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-128">Launch the People app</span></span>](launch-people-apps.md) | <span data-ttu-id="91745-129">ここでは、ms-people URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="91745-129">This topic describes the ms-people URI scheme.</span></span> <span data-ttu-id="91745-130">アプリでこの URI スキームを使って People アプリを起動し、特定のアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="91745-130">Your app can use this URI scheme to launch the People app for specific actions.</span></span> |
| [<span data-ttu-id="91745-131">アプリの URI ハンドラーを使用して web サイト用のアプリを有効にします。</span><span class="sxs-lookup"><span data-stu-id="91745-131">Enable apps for websites using app URI handlers</span></span>](web-to-app-linking.md) | <span data-ttu-id="91745-132">Web サイトの機能のアプリをサポートすることで、アプリでユーザーの活動をドライブします。</span><span class="sxs-lookup"><span data-stu-id="91745-132">Drive user engagement with your app by supporting the Apps for Websites feature.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="91745-133">関連トピック</span><span class="sxs-lookup"><span data-stu-id="91745-133">Related Topics</span></span>
* [<span data-ttu-id="91745-134">リモート デバイスでのアプリの起動</span><span class="sxs-lookup"><span data-stu-id="91745-134">Launch an app on a remote device</span></span>](launch-a-remote-app.md)