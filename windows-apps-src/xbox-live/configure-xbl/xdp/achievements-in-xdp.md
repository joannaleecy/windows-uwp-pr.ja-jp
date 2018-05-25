---
title: XDP での Achievements 2017
author: KevinAsgari
description: Achievements 2017
ms.assetid: d424db04-328d-470c-81d3-5d4b82cb792f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: 26155f83d567bda4c5472b7e262e888757bee87f
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="configure-achievements-2017-on-xdp"></a><span data-ttu-id="b7784-104">XDP での Achievements 2017 の構成</span><span class="sxs-lookup"><span data-stu-id="b7784-104">Configure Achievements 2017 on XDP</span></span>

<span data-ttu-id="b7784-105">Achievements 2017 システムで必要な構成は、名前、ロック/ロック解除の説明、表示イメージ、リワード情報だけです</span><span class="sxs-lookup"><span data-stu-id="b7784-105">In the Achievements 2017 system, the only configuration needs for an achievement are its name, locked & unlocked descriptions, display image, and reward information.</span></span> <span data-ttu-id="b7784-106">(注意: 有効な実績リワード: ゲーマースコア、アート リワード、ゲーム内リワード)。</span><span class="sxs-lookup"><span data-stu-id="b7784-106">(Note: Valid achievement rewards still include: Gamerscore, art rewards, and in-game rewards.)</span></span>

<span id="_Enable_Simplified_Achievements" class="anchor"></span>

## <a name="enable-achievements-2017"></a><span data-ttu-id="b7784-107">Achievements 2017 の有効化</span><span class="sxs-lookup"><span data-stu-id="b7784-107">Enable Achievements 2017</span></span>

<span data-ttu-id="b7784-108">タイトルで使用される実績システムは、製品レベルで管理されます。</span><span class="sxs-lookup"><span data-stu-id="b7784-108">The Achievements system used by your title is managed at the product level.</span></span>  

<span data-ttu-id="b7784-109">デベロッパーは、RETAIL に公開する前にいつでも、製品で簡易版実績システムとクラウド版実績システムのどちらを使うかを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="b7784-109">Developers may switch their products between Simplified and Cloud-Powered Achievements systems at any time prior to publishing into RETAIL.</span></span> <span data-ttu-id="b7784-110">いずれかの方向に実績システムを切り替えると、タイトルで構成および公開されているすべての実績 (および該当する場合はチャレンジ) が、すべてのサンドボックスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="b7784-110">Upon switching Achievements systems, in either direction, all of your title’s configured & published achievements (and challenges, if applicable) will be deleted from every sandbox.</span></span> 

<span data-ttu-id="b7784-111">タイトルのサービス構成を RETAIL に公開した後は、実績システムは永続的に設定され、変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="b7784-111">Once a title’s service configuration has been published to RETAIL, its Achievements system is permanently set and cannot be changed.</span></span> **<span data-ttu-id="b7784-112">例外を設けることはできません。</span><span class="sxs-lookup"><span data-stu-id="b7784-112">No exceptions can be made.</span></span> <span data-ttu-id="b7784-113">これは、技術とポリシーの両方の理由で必要です。</span><span class="sxs-lookup"><span data-stu-id="b7784-113">This is required for both technical & policy reasons.</span></span>**

1.  <span data-ttu-id="b7784-114">XDP でプロダクトのページから **[Product Setup]** に移動します。</span><span class="sxs-lookup"><span data-stu-id="b7784-114">From your product page in XDP, navigate to **Product Setup**.</span></span>
![XDP の製品ページのスクリーンショット](../../images/omega/simplified-achievements-1.png)

2.  <span data-ttu-id="b7784-116">**[Product Details]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="b7784-116">Select **Product Details**.</span></span>
![XDP の製品セットアップ ページのスクリーンショット](../../images/omega/simplified-achievements-2.png)

1.  <span data-ttu-id="b7784-118">**[Achievements configuration system]** トグルを *[Achievements 2017]* に切り替えます。
![Achievements 2017 と Achievements 2013 のトグルを示す製品詳細ページのスクリーンショット</span><span class="sxs-lookup"><span data-stu-id="b7784-118">Switch the **Achievements configuration system** toggle to *Achievements 2017.*
![Screenshot of the product details page showing the toggle between Achievements 2017 and Achievements 2013</span></span>](../../images/omega/simplified-achievements-3.png)

1.  <span data-ttu-id="b7784-119">すべてのサンドボックスでタイトルのすべての実績が削除されることを伝える警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7784-119">You will receive a warning that all of your title’s achievements will be deleted in all sandboxes.</span></span> <span data-ttu-id="b7784-120">すべてのサンドボックスの既存の実績が削除されても問題ない場合は、**[Save]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7784-120">If you are OK with the deletion of your existing achievements in all sandboxes, click **Save**.</span></span>
![警告を示すスクリーンショット](../../images/omega/simplified-achievements-4.png)

## <a name="configure-an-achievement"></a><span data-ttu-id="b7784-122">実績の構成</span><span class="sxs-lookup"><span data-stu-id="b7784-122">Configure an Achievement</span></span>

1.  <span data-ttu-id="b7784-123">タイトルに対して Achievements 2017 を有効にします。</span><span class="sxs-lookup"><span data-stu-id="b7784-123">Enable Achievements 2017 for your title.</span></span>

2.  <span data-ttu-id="b7784-124">**[Service Configuration]** に移動して **[Achievements]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="b7784-124">Navigate to **Service Configuration** and select **Achievements**.</span></span>
![XDP のサービス構成タスク ページのスクリーンショット](../../images/omega/simplified-achievements-5.png)

1.  <span data-ttu-id="b7784-126">実績表示の詳細を入力します。</span><span class="sxs-lookup"><span data-stu-id="b7784-126">Enter the achievement display details.</span></span>

    *<span data-ttu-id="b7784-127">注意: これらの文字列は XDP UI での表示に使用されます。</span><span class="sxs-lookup"><span data-stu-id="b7784-127">Note: These strings are used for display in the XDP UI.</span></span> <span data-ttu-id="b7784-128">ユーザーに対して表示される最終的な文字列は、[Localized Strings] サービス構成オプション (手順 5) で構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7784-128">The final strings that will be shown to users must be configured in the “Localized Strings” service configuration option (step 5).</span></span>*<br>
![XDP の [Add New Achievement] ダイアログ ボックスのスクリーンショット](../../images/omega/simplified-achievements-6.png)

1.  <span data-ttu-id="b7784-130">実績にゲーマースコア、アートワーク、アプリ内リワードを追加するには、**[Rewards]** セクションの **[New]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7784-130">To add Gamerscore, Artwork, or In-App reward onto the achievement, click **New** under the **Rewards** section.</span></span>
![XDP の [Edit Reward] ダイアログ ボックスのスクリーンショット](../../images/omega/simplified-achievements-7.png)

1.  <span data-ttu-id="b7784-132">実績の名前と説明にローカライズされた文字列を提供する場合は、**[Localized Strings]** に移動します。</span><span class="sxs-lookup"><span data-stu-id="b7784-132">If supplying localized strings for your achievement names & descriptions, navigate to **Localized Strings.**</span></span>

    *<span data-ttu-id="b7784-133">注意: 英語にローカライズした文字列を必ず定義してください。</span><span class="sxs-lookup"><span data-stu-id="b7784-133">Note: Don’t forget to define your English localized strings.</span></span> <span data-ttu-id="b7784-134">そうしないと、米国以外のユーザーが英語のテキストを選択したときに正しく表示されません。</span><span class="sxs-lookup"><span data-stu-id="b7784-134">Otherwise, your users in non-USA countries who prefer English text may not get the expected result.</span></span>*<br>
![XDP の [Localized Strings] ページのスクリーンショット](../../images/omega/simplified-achievements-8.png)

1.  <span data-ttu-id="b7784-136">最近行った変更を、現在公開されているサービス構成データと比較するには、**[Compare Data]** に移動し、比較対象のサンドボックスを選択します。</span><span class="sxs-lookup"><span data-stu-id="b7784-136">To compare your recent changes to the currently published service configuration data, navigate to **Compare Data** and select the desired sandboxes for comparison.</span></span>
![XDP の [Compare Data] ページのスクリーンショット](../../images/omega/simplified-achievements-9.png)

1.  <span data-ttu-id="b7784-138">開発サンドボックスでの公開とテストの準備ができたら、**[Service Configuration]** に戻って **[Publish]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7784-138">When ready to publish & test in your dev sandbox, return to **Service Configuration** and click the **Publish** button.</span></span>
![[発行] ボタンが表示された XDP の [Service Configuration Tasks] ページのスクリーンショット](../../images/omega/simplified-achievements-10.png)

1.  <span data-ttu-id="b7784-140">テスト対象のサンドボックスを選択します (通常は、実績のドラフトを作成したものと同じサンドボックス)。</span><span class="sxs-lookup"><span data-stu-id="b7784-140">Choose the destination sandbox where you want to test (likely the same sandbox where you drafted the achievements).</span></span>

    <span data-ttu-id="b7784-141">[Service Configuration] の *[Events, Stat Rules, Achievements…]* チェック ボックスを</span><span class="sxs-lookup"><span data-stu-id="b7784-141">Select the *Events, Stat Rules, Achievements…*</span></span> <span data-ttu-id="b7784-142">オンにします。</span><span class="sxs-lookup"><span data-stu-id="b7784-142">checkbox under Service Configuration.</span></span>

    <span data-ttu-id="b7784-143">**[Submit]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7784-143">Click **Submit.**</span></span>

![XDP の [Publishing Approval] ページのスクリーンショット](../../images/omega/simplified-achievements-11.png)
