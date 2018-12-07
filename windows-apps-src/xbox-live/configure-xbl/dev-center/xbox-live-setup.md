---
title: Xbox Live セットアップ構成
description: パートナー センターで Xbox Live のセットアップを構成する方法について説明します。
ms.assetid: ''
ms.date: 10/30/2017
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox live, Xbox, ゲーム, uwp, windows 10, Xbox one, パートナー センター, Xbox Live のセットアップ
ms.openlocfilehash: 9a846a4b7f0069216e92eb123b33d9fc0f7f67c9
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8751167"
---
# <a name="configure-xbox-live-setup-in-partner-center"></a><span data-ttu-id="abced-104">パートナー センターで Xbox Live のセットアップを構成します。</span><span class="sxs-lookup"><span data-stu-id="abced-104">Configure Xbox Live Setup in Partner Center</span></span>

<span data-ttu-id="abced-105">[パートナー センター](https://developer.microsoft.com/dashboard)を使用すると、ゲームに関連付けられている Xbox Live のプロパティの初期セットを構成します。</span><span class="sxs-lookup"><span data-stu-id="abced-105">You can use [Partner Center](https://developer.microsoft.com/dashboard) to configure the initial set of Xbox Live properties that are associated with your game.</span></span> <span data-ttu-id="abced-106">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="abced-106">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="abced-107">**[サービス]** > **[Xbox Live]** > **[Xbox Live Setup]** (Xbox Live セットアップ) の順に選択して、**[Xbox Live Setup]** (Xbox Live セットアップ) セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="abced-107">Navigate to the **Xbox Live Setup** section for your title, located under **Services** > **Xbox Live** > **Xbox Live Setup**.</span></span>
2. <span data-ttu-id="abced-108">このページでは、タイトル名、既定のロケール、製品の種類、デバイス ファミリ、公開開始日を設定できます。</span><span class="sxs-lookup"><span data-stu-id="abced-108">On this page, you can set the title names, default locale, product type, device families and the embargo date.</span></span> <span data-ttu-id="abced-109">構成の設定が完了したら、**[保存]** ボタンをクリックして変更を確定します。</span><span class="sxs-lookup"><span data-stu-id="abced-109">Once you are done setting your configuration, click the **Save** button to submit the changes.</span></span>

## <a name="title-names"></a><span data-ttu-id="abced-110">タイトル名</span><span class="sxs-lookup"><span data-stu-id="abced-110">Title names</span></span>
<span data-ttu-id="abced-111">**[Add localized title]** (ローカライズ タイトルの追加) をクリックすると、製品の名前を入力してローカライズする言語を選択することができます。</span><span class="sxs-lookup"><span data-stu-id="abced-111">By clicking on **Add localized title**, you can enter a name for your product and select a language to localize it to.</span></span> <span data-ttu-id="abced-112">ここでは、タイトル名が、申請のプロパティ ページで定義されているローカライズされた製品名にマッピングされることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="abced-112">Note here that the title name should map to the localized product names that you have defined on the properties page of the submission.</span></span> <span data-ttu-id="abced-113">既定値は英語 (en-US) です。</span><span class="sxs-lookup"><span data-stu-id="abced-113">Default is English (en-US).</span></span>

![パートナー センターで追加のローカライズされたタイトル ダイアログ ボックスの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-1.png)

## <a name="default-locale"></a><span data-ttu-id="abced-115">既定のロケール</span><span class="sxs-lookup"><span data-stu-id="abced-115">Default locale</span></span>
<span data-ttu-id="abced-116">このオプションでは、Xbox Live サービス構成のすべての文字列の構成に使用する既定の言語を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="abced-116">This option allows you to set the default language to be used to configure all your strings in the Xbox Live service configuration.</span></span> <span data-ttu-id="abced-117">たとえば、既定のロケールをスペイン語 (es-ES) に設定して実績を構成する場合、少なくとも、実績の名前と説明にスペイン語が必要です。</span><span class="sxs-lookup"><span data-stu-id="abced-117">For example, if you set the default locale to Spanish (es-ES) and you want to configure an achievement, then at a minimum, the achievement name and description would have to be in Spanish.</span></span> <span data-ttu-id="abced-118">言い換えると、実績情報が英語のみの場合、このオプションをスペイン語に設定することはできません。</span><span class="sxs-lookup"><span data-stu-id="abced-118">In other words, you cannot set this option to Spanish but only provide the achievement information in English.</span></span> <span data-ttu-id="abced-119">すべての Xbox Live サービス構成を、既定のロケールと同じバージョンで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="abced-119">All of your Xbox Live service configuration must be provided in the same version as that of the default locale.</span></span> <span data-ttu-id="abced-120">既定では、既定のロケールは英語 (en-US) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="abced-120">By default, the default locale is set to English (en-US).</span></span>
> [!NOTE]
> <span data-ttu-id="abced-121">さらに、[Localized strings] (ローカライズされた文字列) ページではすべての文字列をローカライズできます。</span><span class="sxs-lookup"><span data-stu-id="abced-121">Additionally, all strings can be localized in the Localized strings page.</span></span>  

![パートナー センターで既定のロケールを選択するドロップダウンの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-2.png)

## <a name="product-type"></a><span data-ttu-id="abced-123">製品の種類</span><span class="sxs-lookup"><span data-stu-id="abced-123">Product type</span></span>
<span data-ttu-id="abced-124">このドロップダウン メニューでは、製品の種類を変更できます。</span><span class="sxs-lookup"><span data-stu-id="abced-124">The drop-down menu allows you change the type of the product.</span></span> <span data-ttu-id="abced-125">既定値は、種類 **[ゲーム]** です。</span><span class="sxs-lookup"><span data-stu-id="abced-125">It defaults to the type **Game**.</span></span> <span data-ttu-id="abced-126">使用する XboxLivefeatures 選択内容に影響します。</span><span class="sxs-lookup"><span data-stu-id="abced-126">The choice you make will impact the XboxLivefeatures available to you.</span></span> <span data-ttu-id="abced-127">次の 3 つのオプションから選択できます。</span><span class="sxs-lookup"><span data-stu-id="abced-127">You have three options to choose from:</span></span>
1. <span data-ttu-id="abced-128">アプリ</span><span class="sxs-lookup"><span data-stu-id="abced-128">App</span></span> 
2. <span data-ttu-id="abced-129">ゲーム</span><span class="sxs-lookup"><span data-stu-id="abced-129">Game</span></span> 
3. <span data-ttu-id="abced-130">ゲームの体験版</span><span class="sxs-lookup"><span data-stu-id="abced-130">Game demo</span></span> 

![パートナー センターで製品の種類を選択するドロップダウンの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-3.png)

## <a name="device-families"></a><span data-ttu-id="abced-132">デバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="abced-132">Device families</span></span>
<span data-ttu-id="abced-133">この構成では、タイトルが Xbox Live にアクセスできるデバイスの種類を選択することができます。</span><span class="sxs-lookup"><span data-stu-id="abced-133">This configuration allows you to choose the type of devices on which your title can access Xbox Live.</span></span> <span data-ttu-id="abced-134">既定では、すべてのデバイス ファミリが有効です。</span><span class="sxs-lookup"><span data-stu-id="abced-134">By default, all device families are enabled.</span></span> <span data-ttu-id="abced-135">有効にするデバイスをオンにできます。</span><span class="sxs-lookup"><span data-stu-id="abced-135">You can check the devices to enable them.</span></span>

![パートナー センターでのデバイス ファミリを選択する選択チェック ボックスの画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-4.png)

## <a name="embargo-date"></a><span data-ttu-id="abced-137">公開開始日</span><span class="sxs-lookup"><span data-stu-id="abced-137">Embargo date</span></span>
<span data-ttu-id="abced-138">選択した日付によって、Xbox Live 構成がいつ公開されるかが決まります。</span><span class="sxs-lookup"><span data-stu-id="abced-138">The date you select will determine when your Xbox Live configuration goes live to the public.</span></span> <span data-ttu-id="abced-139">変更内容を RETAIL に公開した場合でも、公開開始日になっていなければ公開されません。</span><span class="sxs-lookup"><span data-stu-id="abced-139">It is important to note that even if you published your changes to RETAIL they will not go live unless the embargo date has been met.</span></span> <span data-ttu-id="abced-140">詳しい説明は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="abced-140">To explain further:</span></span>
1. <span data-ttu-id="abced-141">将来の日付を選択した場合、変更内容はその日に公開されます。</span><span class="sxs-lookup"><span data-stu-id="abced-141">If you select a date in the future, the changes will become available to the public on that date.</span></span>
2. <span data-ttu-id="abced-142">過去の日付を選択した場合、変更内容は RETAIL に公開するとすぐに一般公開されます。</span><span class="sxs-lookup"><span data-stu-id="abced-142">If you select a date in the past, the changes will become available to the public as soon as you publish your changes to RETAIL.</span></span>

<span data-ttu-id="abced-143">日付と時刻の選択コントロールをクリックすると展開され、正確な日付と時刻を選択できます。</span><span class="sxs-lookup"><span data-stu-id="abced-143">Click on the date-time picker and it will expand to allow you to select the precise date and time.</span></span> <span data-ttu-id="abced-144">**[OK]** をクリックすると、公開開始日が設定されます。</span><span class="sxs-lookup"><span data-stu-id="abced-144">Once you click **OK**, the embargo date will be set.</span></span>

![パートナー センターで、公開開始日の設定の画像](../../images/dev-center/xbox-live-setup/xbox-live-setup-5.png)

## <a name="advanced-settings"></a><span data-ttu-id="abced-146">詳細設定</span><span class="sxs-lookup"><span data-stu-id="abced-146">Advanced settings</span></span>

<span data-ttu-id="abced-147">**[オプションの表示]** をクリックすると、**[Multiple points of presence]** (複数のプレゼンス ポイント) を設定できます。</span><span class="sxs-lookup"><span data-stu-id="abced-147">You can click **Show options** to set the **Multiple points of presence**.</span></span> <span data-ttu-id="abced-148">複数のプレゼンス ポイントを設定すると、同じユーザーが複数のデバイスから同時に Xbox Live にサインインできます。</span><span class="sxs-lookup"><span data-stu-id="abced-148">Multiple points of presence allows the same user to sign in to Xbox Live from multiple devices at the same time.</span></span> <span data-ttu-id="abced-149">実績やマルチプレイヤーなどの Xbox Live の機能は、アクセスが制限されます。</span><span class="sxs-lookup"><span data-stu-id="abced-149">Xbox Live features such as, achievements and multiplayer will have limited access.</span></span> <span data-ttu-id="abced-150">このため、このオプションはゲームには推奨されません。</span><span class="sxs-lookup"><span data-stu-id="abced-150">Hence, this option is not recommended for games.</span></span> <span data-ttu-id="abced-151">このオプションを有効にするには、チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="abced-151">Enable this option by checking the box.</span></span>
