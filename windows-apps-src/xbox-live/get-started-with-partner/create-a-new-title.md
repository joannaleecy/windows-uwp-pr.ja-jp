---
title: 新しいタイトルを作成する
description: パートナー センターを使用して、Xbox Live の新しいタイトルを作成する方法について説明します。
ms.assetid: b8bd69e6-887a-4b1f-a42d-8affdbec0234
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1aa2447a2044bec9b2013b30c05e45342b763fc3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656567"
---
# <a name="create-a-new-title-for-xbox-live"></a><span data-ttu-id="90fbe-104">Xbox Live 用の新しいタイトルを作成する</span><span class="sxs-lookup"><span data-stu-id="90fbe-104">Create a new title for Xbox Live</span></span>

## <a name="introduction"></a><span data-ttu-id="90fbe-105">概要</span><span class="sxs-lookup"><span data-stu-id="90fbe-105">Introduction</span></span>

<span data-ttu-id="90fbe-106">コードを記述する前に、サービス構成ポータルで、新しいタイトルをセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-106">Before writing any code, you must setup a new title on your service configuration portal.</span></span>  <span data-ttu-id="90fbe-107">サービス構成について詳しくは、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="90fbe-107">You can learn more about service configuration in [Xbox Live Service Configuration](../xbox-live-service-configuration.md)</span></span>

<span data-ttu-id="90fbe-108">この記事では、新しいタイトルをセットアップする手順について説明します。前提条件は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="90fbe-108">This article will walk you through this process with the following assumptions</span></span>

1. <span data-ttu-id="90fbe-109">ユニバーサル Windows プラットフォーム (UWP) のタイトルを開発している。</span><span class="sxs-lookup"><span data-stu-id="90fbe-109">You are developing a Universal Windows Platform (UWP) title.</span></span>  <span data-ttu-id="90fbe-110">UWP タイトルは、Xbox One、Windows 10 デスクトップ PC、およびモバイルで動作するタイトルです。</span><span class="sxs-lookup"><span data-stu-id="90fbe-110">UWP titles run on Xbox One, Windows 10 desktop PCs, and mobile</span></span>
2. <span data-ttu-id="90fbe-111">タイトルを構成している[パートナー センター](https://partner.microsoft.com/dashboard)します。</span><span class="sxs-lookup"><span data-stu-id="90fbe-111">You are configuring your title in [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
3. <span data-ttu-id="90fbe-112">カスタム ゲーム エンジンを備えた Visual Studio、または Unity のいずれかを使用している。</span><span class="sxs-lookup"><span data-stu-id="90fbe-112">You are using either Visual Studio with a custom game engine, or Unity.</span></span>
4. <span data-ttu-id="90fbe-113">開発用コンピュータは Windows 10 を実行している。</span><span class="sxs-lookup"><span data-stu-id="90fbe-113">Your development machine is running Windows 10.</span></span>

<span data-ttu-id="90fbe-114">上記に該当することは、この記事の残りの部分をパートナー センター、新しいプロジェクトの作成、および Xbox Live サインイン コード記述され、テストで構成されているタイトルを取得するために必要なすべて説明します。</span><span class="sxs-lookup"><span data-stu-id="90fbe-114">Provided that the above are true, the remainder of this article will walk through everything required to get a title configured in Partner Center, a new project created, and Xbox Live sign-in code written and tested.</span></span>

> [!NOTE]
> <span data-ttu-id="90fbe-115">Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。</span><span class="sxs-lookup"><span data-stu-id="90fbe-115">If you are part of the Xbox Live Creators Program, the above assumptions apply to you and you should follow along with this article.</span></span>

## <a name="partner-center-setup"></a><span data-ttu-id="90fbe-116">パートナー センターのセットアップ</span><span class="sxs-lookup"><span data-stu-id="90fbe-116">Partner Center Setup</span></span>

<span data-ttu-id="90fbe-117">Xbox Live、有効になっているタイトルで作成する必要がある[パートナー センター](https://partner.microsoft.com/dashboard) Xbox Live 機能のすべての作業に前提条件として。</span><span class="sxs-lookup"><span data-stu-id="90fbe-117">You need an Xbox Live enabled title created in [Partner Center](https://partner.microsoft.com/dashboard) as a pre-requisite to any Xbox Live functionality working.</span></span>

### <a name="create-a-microsoft-account"></a><span data-ttu-id="90fbe-118">Microsoft アカウントを作成する</span><span class="sxs-lookup"><span data-stu-id="90fbe-118">Create a Microsoft account</span></span>
<span data-ttu-id="90fbe-119">Microsoft アカウント (MSA) を持っていない場合は、最初に 1 つを作成する必要があります。 [ https://go.microsoft.com/fwlink/p/?LinkID=254486](https://go.microsoft.com/fwlink/p/?LinkID=254486)します。</span><span class="sxs-lookup"><span data-stu-id="90fbe-119">If you don't have a Microsoft Account (also known as an MSA), you will need to first create one at [https://go.microsoft.com/fwlink/p/?LinkID=254486](https://go.microsoft.com/fwlink/p/?LinkID=254486).</span></span>  <span data-ttu-id="90fbe-120">Office 365 アカウントをお持ちの場合は、Outlook.com を使用してください。または Xbox Live アカウントをお持ちの場合は、既に MSA を持っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-120">If you have an Office 365 account, use Outlook.com, or have an Xbox Live account - you probably already have an MSA.</span></span>

### <a name="register-as-an-app-developer"></a><span data-ttu-id="90fbe-121">アプリ開発者として登録する</span><span class="sxs-lookup"><span data-stu-id="90fbe-121">Register as an App Developer</span></span>
<span data-ttu-id="90fbe-122">パートナー センターで、新しいタイトルを作成する前に、アプリ開発者として登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-122">You will need to register as an App Developer before you are allowed to create a new title in Partner Center.</span></span>

<span data-ttu-id="90fbe-123">Go を登録する https://developer.microsoft.com/en-us/store/registerしサインアップのプロセスに従います。</span><span class="sxs-lookup"><span data-stu-id="90fbe-123">To register go to https://developer.microsoft.com/en-us/store/register and follow the sign-up process.</span></span>

### <a name="create-a-new-uwp-title"></a><span data-ttu-id="90fbe-124">新しい UWP タイトルを作成する</span><span class="sxs-lookup"><span data-stu-id="90fbe-124">Create a new UWP title</span></span>
<span data-ttu-id="90fbe-125">次に、UWP のタイトルがパートナー センターで定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-125">Next, you need a UWP title defined in Partner Center.</span></span>  <span data-ttu-id="90fbe-126">これを実行するには、まずダッシュ ボードに移動します</span><span class="sxs-lookup"><span data-stu-id="90fbe-126">You do that by first going to the Dashboard</span></span>

![](../images/getting_started/first_xbltitle_dashboard.png)

<p>
</p>
<br>
<p>
</p>

<span data-ttu-id="90fbe-127">次に、新しいタイトルを作成します。</span><span class="sxs-lookup"><span data-stu-id="90fbe-127">Then, create a new title.</span></span>  <span data-ttu-id="90fbe-128">名前を予約する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-128">You'll need to reserve a name.</span></span>

![](../images/getting_started/first_xbltitle_newapp.png)

<span data-ttu-id="90fbe-129">次に、アプリに関する *[アプリの概要]* ページが表示されます。</span><span class="sxs-lookup"><span data-stu-id="90fbe-129">You'll then be taken to the *App Overview* page for your app.</span></span>  <span data-ttu-id="90fbe-130">Xbox Live を構成するための主要なページは、以下に示すように [サービス] -> [Xbox Live] メニューにあります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-130">The primary page where you'll be configuring Xbox Live is under the Services -> Xbox Live menu shown below.</span></span>

![](../images/getting_started/first_xbltitle_leftnav.png)

<div id="createxblaccount"></div>

## <a name="create-an-xbox-live-account"></a><span data-ttu-id="90fbe-131">Xbox Live アカウントを作成する</span><span class="sxs-lookup"><span data-stu-id="90fbe-131">Create an Xbox Live Account</span></span>
<span data-ttu-id="90fbe-132">Xbox Live にサインインするには、Xbox Live アカウントが必要です。</span><span class="sxs-lookup"><span data-stu-id="90fbe-132">You will need an Xbox Live Account to sign-in to Xbox Live.</span></span>  <span data-ttu-id="90fbe-133">既にアカウントをお持ちで、Xbox One 本体、または Windows 10 の Xbox アプリへのサインインに使用している場合は、そのアカウントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="90fbe-133">If you already have one that you use to sign-in on your Xbox One console, or in the Xbox App on Windows 10, then you can use that one.</span></span>

<span data-ttu-id="90fbe-134">それ以外の場合は、PC で Xbox アプリを開いて、Microsoft アカウントでサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-134">Otherwise you should open the Xbox App on your PC and sign-in with your Microsoft Account.</span></span>  <span data-ttu-id="90fbe-135">これで、Xbox Live で使用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="90fbe-135">It will then be enabled for use with Xbox Live.</span></span>

<span data-ttu-id="90fbe-136">以下に示すように、*[スタート] メニュー*に移動して、「Xbox」と入力すると Xbox アプリを検索できます。</span><span class="sxs-lookup"><span data-stu-id="90fbe-136">You can find the Xbox App by going into the *Start Menu* and typing in "Xbox" as shown below.</span></span>

![](../images/getting_started/first_xbltitle_xboxapp.png)

## <a name="next-steps"></a><span data-ttu-id="90fbe-137">次のステップ</span><span class="sxs-lookup"><span data-stu-id="90fbe-137">Next Steps</span></span>
<span data-ttu-id="90fbe-138">これで新しいタイトルが作成されたので、次はゲーム エンジン、Visual Studio、任意のビルド環境で Xbox Live 対応のタイトルをセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="90fbe-138">Now that you have a new title created, you can now setup an Xbox Live enabled title in your Game Engine, Visual Studio or build environment of choice.</span></span>

<span data-ttu-id="90fbe-139">「[Xbox Live を統合するためのステップ バイ ステップ ガイド](partners-step-by-step-guide.md)」をご覧ください</span><span class="sxs-lookup"><span data-stu-id="90fbe-139">See [Step by step guide to integrate Xbox Live](partners-step-by-step-guide.md)</span></span>
