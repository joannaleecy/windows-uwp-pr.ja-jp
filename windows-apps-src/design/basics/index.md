---
description: さまざまなデバイスや画面サイズで、ナビゲーションがわかりやすく見た目にも優れた UWP アプリを設計およびコーディングする方法について説明します。
title: 設計の基本
author: mijacobs
keywords: UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス
ms.author: mijacobs
ms.date: 3/7/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 22ab5ad60ed397092e61f2c43cde4eb2e0c86c4f
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7553749"
---
# <a name="design-basics-for-uwp-apps"></a><span data-ttu-id="0a26e-104">UWP アプリの設計の基本</span><span class="sxs-lookup"><span data-stu-id="0a26e-104">Design basics for UWP apps</span></span>

![ヒーロー イメージ](images/header-design-basics.svg)

<span data-ttu-id="0a26e-106">ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。</span><span class="sxs-lookup"><span data-stu-id="0a26e-106">The Universal Windows Platform (UWP) design guidance is a resource to help you design and build beautiful, polished apps.</span></span> <span data-ttu-id="0a26e-107">これは規範的な規則の一覧ではなく、進化する Fluent Design System、およびアプリ構築コミュニティのニーズに適応するように設計された生きたドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="0a26e-107">It's not a list of prescriptive rules - it's a living document, designed to adapt to our evolving Fluent Design System as well as the needs of our app-building community.</span></span> 

## <a name="overview"></a><span data-ttu-id="0a26e-108">概要</span><span class="sxs-lookup"><span data-stu-id="0a26e-108">Overview</span></span>

[**<span data-ttu-id="0a26e-109">UWP アプリ設計の概要</span><span class="sxs-lookup"><span data-stu-id="0a26e-109">Introduction to UWP app design</span></span>**](design-and-ui-intro.md)

<span data-ttu-id="0a26e-110">すべての種類の Windows デバイスで適切に対応するアプリを作成するためのベスト プラクティスと組み合わされた、UWP 機能の概要です。</span><span class="sxs-lookup"><span data-stu-id="0a26e-110">An introduction to UWP features combined with best practices for creating apps that scale beautifully on all types of Windows-powered devices.</span></span>

[**<span data-ttu-id="0a26e-111">Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="0a26e-111">Fluent Design System</span></span>**](../fluent-design-system/index.md)

<span data-ttu-id="0a26e-112">Fluent Design System では、順応性が高く、親近感があり、優れた美しさを持つユーザー インターフェイスを作成するための目標や原則を示します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-112">The Fluent Design System presents our goals and principles for creating adaptive, empathetic, and beautiful user interfaces.</span></span>

## <a name="basics"></a><span data-ttu-id="0a26e-113">基本</span><span class="sxs-lookup"><span data-stu-id="0a26e-113">Basics</span></span>

[**<span data-ttu-id="0a26e-114">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="0a26e-114">Navigation basics</span></span>**](navigation-basics.md)

<span data-ttu-id="0a26e-115">UWP アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。</span><span class="sxs-lookup"><span data-stu-id="0a26e-115">Navigation in UWP apps is based on a flexible model of navigation structures, navigation elements, and system-level features.</span></span> <span data-ttu-id="0a26e-116">この記事では、これらの構成要素を紹介します。また、これらの構成要素を組み合わせて使い、優れたナビゲーション エクスペリエンスを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-116">This article introduces you to these components and shows you how to use them together to create a good navigation experience.</span></span>

[**<span data-ttu-id="0a26e-117">コマンドの基本</span><span class="sxs-lookup"><span data-stu-id="0a26e-117">Command basics</span></span>**](commanding-basics.md)

<span data-ttu-id="0a26e-118">コマンド要素は、ユーザーがメール送信、項目の削除、フォームの送信などの操作を実行できる対話型の UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="0a26e-118">Command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.</span></span> <span data-ttu-id="0a26e-119">この記事では、ボタンやチェック ボックスなどのコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするコマンド サーフェス (コマンド バーやショートカット メニューなど) について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-119">This article describes the command elements, such as buttons and check boxes, the interactions they support, and the command surfaces (such as command bars and context menus) for hosting them.</span></span>

[**<span data-ttu-id="0a26e-120">コンテンツの基本</span><span class="sxs-lookup"><span data-stu-id="0a26e-120">Content basics</span></span>**](content-basics.md)

<span data-ttu-id="0a26e-121">どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="0a26e-121">The main purpose of any app is to provide access to content: in a photo-editing app, the photo is the content; in a travel app, maps and info about travel destinations is the content; and so on.</span></span> <span data-ttu-id="0a26e-122">この記事では、3 つのコンテンツ シナリオ (使用、作成、対話式操作) でのコンテンツの設計に関する推奨事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-122">This article provides content design recommendations for the three content scenarios: consumption, creation, and interaction.</span></span>

## <a name="tutorials"></a><span data-ttu-id="0a26e-123">チュートリアル</span><span class="sxs-lookup"><span data-stu-id="0a26e-123">Tutorials</span></span>

<span data-ttu-id="0a26e-124">XAML と C# で基本的な写真編集アプリケーションを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-124">Learn how to create a basic photo-editing application in XAML and C#.</span></span>
<!-- <img src="images/landing-page/photolab-50.png" style="{height: 339px}" alt=" " /> -->

[**<span data-ttu-id="0a26e-125">1. 基本的な UI を作成する</span><span class="sxs-lookup"><span data-stu-id="0a26e-125">1. Create a basic UI</span></span>**](xaml-basics-ui.md)

<span data-ttu-id="0a26e-126">XAML を使用して基本的なユーザー インターフェイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-126">Use XAML to create a basic user interface.</span></span>

[**<span data-ttu-id="0a26e-127">2. アダプティブ レイアウトを作成する</span><span class="sxs-lookup"><span data-stu-id="0a26e-127">2. Create an adaptive layout</span></span>**](xaml-basics-adaptive-layout.md)

<span data-ttu-id="0a26e-128">写真編集アプリケーションにアダプティブ レイアウトを提供します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-128">Give the photo-editing application an adaptive layout.</span></span>

[**<span data-ttu-id="0a26e-129">3. カスタム スタイルを作成する</span><span class="sxs-lookup"><span data-stu-id="0a26e-129">3. Create custom styles</span></span>**](xaml-basics-style.md)

<span data-ttu-id="0a26e-130">カスタム スタイルを作成することで、UWP コントロールに独自の外観を提供します。</span><span class="sxs-lookup"><span data-stu-id="0a26e-130">Give our UWP controls your own look and feel by creating custom styles.</span></span>