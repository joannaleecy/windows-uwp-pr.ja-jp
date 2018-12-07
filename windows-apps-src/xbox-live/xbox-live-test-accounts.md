---
title: Xbox Live テスト アカウント
description: 開発中に Xbox Live 対応ゲームをテストするためのテスト アカウントを作成する方法について説明します。
ms.assetid: e8076233-c93c-4961-86ac-27ec74917ebc
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, テスト アカウント
ms.localizationpriority: medium
ms.openlocfilehash: 14313b6121cabf82762b5e3e862c73a9d3ec05cc
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8746840"
---
# <a name="xbox-live-test-accounts"></a><span data-ttu-id="bbb99-104">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="bbb99-104">Xbox Live test accounts</span></span>

<span data-ttu-id="bbb99-105">開発中にタイトルの機能をテストするときに、追加の Xbox Live アカウントを作成すると便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="bbb99-105">When testing functionality in your title during development, it can be helpful to create additional Xbox Live accounts.</span></span>  <span data-ttu-id="bbb99-106">たとえば、実績がまったくない新しいアカウントが必要な場合です。</span><span class="sxs-lookup"><span data-stu-id="bbb99-106">For example, you might want a fresh account with no achievements.</span></span>  <span data-ttu-id="bbb99-107">または、ソーシャル シナリオをテストするために、いくつかのアカウントを作り、お互いのフレンドにする必要がある場合です。</span><span class="sxs-lookup"><span data-stu-id="bbb99-107">Or you might want to make several accounts and make them friends of each other for testing Social scenarios.</span></span>

<span data-ttu-id="bbb99-108">複数の Microsoft アカウント (MSA) を作成するのは非常に時間がかかることがあるため、多数のテスト アカウントを一度に作成する簡単な方法が用意されています。</span><span class="sxs-lookup"><span data-stu-id="bbb99-108">It can be time consuming to create multiple Microsoft Accounts (MSA) so an easy way to create many test accounts at once is provided.</span></span>

<span data-ttu-id="bbb99-109">テスト アカウントには、他にもいくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="bbb99-109">Test accounts have some other benefits also.</span></span>  <span data-ttu-id="bbb99-110">通常の MSA ではセキュリティに関する制限によってサインインできない*開発サンドボックス*にサインインできます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-110">They can sign into your *Development Sandbox*, whereas a regular MSA cannot due to security restrictions.</span></span>  <span data-ttu-id="bbb99-111">*開発サンドボックス*を知らない場合は、「[Xbox Live のサンドボックス](xbox-live-sandboxes.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="bbb99-111">If you don't know what a *Development Sandbox* is, then please see [Xbox Live Sandboxes](xbox-live-sandboxes.md)</span></span>

## <a name="types-of-test-accounts"></a><span data-ttu-id="bbb99-112">テスト アカウントの種類</span><span class="sxs-lookup"><span data-stu-id="bbb99-112">Types of test accounts</span></span>

<span data-ttu-id="bbb99-113">テスト アカウントには 2 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="bbb99-113">There are two options of test accounts.</span></span>  <span data-ttu-id="bbb99-114">開発サンド ボックスで動作するようにプロビジョニングされている通常の MSA と、開発サンドボックスのみで動作するテスト アカウントです。</span><span class="sxs-lookup"><span data-stu-id="bbb99-114">Regular MSAs that are provisioned to work in your Development Sandbox, or test accounts that only work in a development sandbox.</span></span>

<span data-ttu-id="bbb99-115">Xbox Live クリエーターズ プログラムでタイトルを開発している場合、開発サンドボックス用にプロビジョニングされている通常の MSA しか使用できません。</span><span class="sxs-lookup"><span data-stu-id="bbb99-115">If you are developing a title with the Creators Program, you may only use Regular MSAs that are provisioned for your Development Sandbox.</span></span>

<span data-ttu-id="bbb99-116">以下で、両方の種類を作成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="bbb99-116">Below we will discuss how to create both types.</span></span>

## <a name="provisioning-regular-msas"></a><span data-ttu-id="bbb99-117">通常の MSA のプロビジョニング</span><span class="sxs-lookup"><span data-stu-id="bbb99-117">Provisioning Regular MSAs</span></span>

<span data-ttu-id="bbb99-118">既存の Xbox Live アカウントがある場合、それを開発サンドボックスで使用できるようにプロビジョニングするのがお勧めです。</span><span class="sxs-lookup"><span data-stu-id="bbb99-118">If you have a pre-existing Xbox Live Account, a good starting point would be to provision it for use with your Development Sandbox.</span></span>

<span data-ttu-id="bbb99-119">既存の Xbox Live アカウントを持っているまたは追加の Msa を必要としないの場合は、いくつかを作成[https://account.microsoft.com/account](https://account.microsoft.com/account)します。</span><span class="sxs-lookup"><span data-stu-id="bbb99-119">If you do not have an existing Xbox Live Account or require additional MSAs, you can create some at [https://account.microsoft.com/account](https://account.microsoft.com/account).</span></span>

## <a name="creating-test-accounts"></a><span data-ttu-id="bbb99-120">テスト アカウントの作成</span><span class="sxs-lookup"><span data-stu-id="bbb99-120">Creating Test Accounts</span></span>

<span data-ttu-id="bbb99-121">ID@Xbox 開発者である場合、開発サンドボックス専用のテスト アカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-121">If you are an ID@Xbox developer, then you may also create test accounts exclusively for use in your development sandboxes.</span></span>  <span data-ttu-id="bbb99-122">一度に複数のテスト アカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-122">You can also create multiple test accounts at once.</span></span>

<span data-ttu-id="bbb99-123">パートナー センターでテスト アカウント管理ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="bbb99-123">To go to the Test Account management page in Partner Center.</span></span>
1. <span data-ttu-id="bbb99-124">[パートナー センター](https://partner.microsoft.com/dashboard)に移動します</span><span class="sxs-lookup"><span data-stu-id="bbb99-124">Go to [Partner Center](https://partner.microsoft.com/dashboard)</span></span>
2. <span data-ttu-id="bbb99-125">右上隅のギア アイコンをクリックして、アカウント設定に進みます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-125">Click on the gear icon at the top right to go to account Settings</span></span>
3. <span data-ttu-id="bbb99-126">[テスト アカウント] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="bbb99-126">Click on "Test Accounts".</span></span>

<span data-ttu-id="bbb99-127">以下は、この場所を示すスクリーンショットです。</span><span class="sxs-lookup"><span data-stu-id="bbb99-127">See below for a screenshot showing where to find this</span></span>

![](images/getting_started/devcenter_testaccount_nav.png)

<span data-ttu-id="bbb99-128">[テスト アカウント] をクリックすると、既存のテスト アカウントがある場合はその概要が表示されます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-128">Once you click on "Test Accounts", you will see a summary of any existing test accounts if you have any.</span></span>  <span data-ttu-id="bbb99-129">新しいテスト アカウントを作成するオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="bbb99-129">You also have the option to create new test accounts.</span></span>

![](images/getting_started/devcenter_testaccount_summary.png)

<span data-ttu-id="bbb99-130">[新しいテスト アカウント] をクリックすると、テスト アカウントの作成に使用できるフォームが表示されます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-130">You can click on "New Test Account" and you will be presented with a form you can use to create test accounts.</span></span>

![](images/getting_started/devcenter_testaccount_new.png)

<span data-ttu-id="bbb99-131">作成したテスト アカウントはプレフィックスとして開発サンドボックスの名前が付けられ、自動的に開発サンドボックスへのアクセス権が付与されます。</span><span class="sxs-lookup"><span data-stu-id="bbb99-131">Any test accounts you create will be prefixed with the name of your development sandbox, and will automatically have access to your development sandbox.</span></span>
