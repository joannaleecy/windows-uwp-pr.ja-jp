---
title: Achievements 2017
author: PhillipLucas
description: Microsoft デベロッパー センターで実績を構成してリワードを提供する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 11/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター
ms.openlocfilehash: 108d022909afc9a118cc1f011acf100972576841
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4684847"
---
# <a name="configure-achievements-2017-on-dev-center"></a><span data-ttu-id="16c2d-104">デベロッパー センターでの Achievements 2017 の構成</span><span class="sxs-lookup"><span data-stu-id="16c2d-104">Configure Achievements 2017 on Dev Center</span></span>

> [!IMPORTANT]
> <span data-ttu-id="16c2d-105">実績は、ID@Xbox または対象パートナーにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-105">Achievements are only applicable to ID@Xbox or Managed Partners.</span></span> <span data-ttu-id="16c2d-106">Xbox Live クリエーターズ プログラムに参加しているゲームはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="16c2d-106">Games participating in the Xbox Live Creators Program are not supported.</span></span>

<span data-ttu-id="16c2d-107">[Microsoft デベロッパー センター](https://developer.microsoft.com/dashboard)を使用して、ゲームに関連付けられている [Achievements 2017](../../achievements-2017/simplified-achievements.md) を構成することができます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-107">You can use [Microsoft Dev Center](https://developer.microsoft.com/dashboard) to configure the [Achievements 2017](../../achievements-2017/simplified-achievements.md) that are associated with your game.</span></span> <span data-ttu-id="16c2d-108">次の手順に従って新しい実績を追加します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-108">Add a new achievement by doing the following:</span></span>

1. <span data-ttu-id="16c2d-109">**[Services]** > **Xbox Live** > **[Achievements]** の順に選択して、タイトルの実績セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-109">Navigate to the Achievements section for your title, located under **Services** > **Xbox Live** > **Achievements**.</span></span>
2. <span data-ttu-id="16c2d-110">**[New Achievement]** ボタンをクリックし、フォームに記入します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-110">Click the **New Achievement** button and fill out the form.</span></span>  <span data-ttu-id="16c2d-111">完了したら、**[Save]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="16c2d-111">Once completed, click **Save**.</span></span>

![Microsoft デベロッパー センターで新しい実績を作成するスクリーンショット](../../images/dev-center/achievements-1.png)

## <a name="description"></a><span data-ttu-id="16c2d-113">説明</span><span class="sxs-lookup"><span data-stu-id="16c2d-113">Description</span></span>
<span data-ttu-id="16c2d-114">説明セクションに、名前やロック状態/ロック解除状態での説明など、実績の基本情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-114">The description section is where you can enter the basics of your achievement, such as the name and locked/unlocked descriptions.</span></span> <span data-ttu-id="16c2d-115">[Microsoft デベロッパー センター](https://developer.microsoft.com/dashboard) で **[Localized strings]** サービス構成セクションにアクセスして、実績にローカライゼーション サポートを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-115">You can add localization support to achievements by accessing the **Localized strings** service configuration section in [Microsoft Dev Center](https://developer.microsoft.com/dashboard).</span></span>

![Microsoft デベロッパー センターで新しい実績を構成する場合の説明フィールドのスクリーンショット](../../images/dev-center/achievements-2.png)

<span data-ttu-id="16c2d-117">**[Achievement Name]** フィールドには、実績の一般向けの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-117">The **Achievement Name** field is the public facing name of the achievement.</span></span>

<span data-ttu-id="16c2d-118">**[Locked Description]** フィールドには、実績のロックを解除していないときにプレイヤーに表示される説明を入力します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-118">The **Locked Description** field is the description that players will see when they have not unlocked the achievement.</span></span> <span data-ttu-id="16c2d-119">これには 100 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-119">It has a 100 character limit.</span></span>

<span data-ttu-id="16c2d-120">**[Unlocked Description]** フィールドには、実績のロックを解除しているときにプレイヤーに表示される説明を入力します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-120">The **Unlocked Description** field is the description that players will see once they have unlocked the achievement.</span></span> <span data-ttu-id="16c2d-121">これには 100 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-121">It has a 100 character limit.</span></span>

## <a name="details"></a><span data-ttu-id="16c2d-122">Details (詳細)</span><span class="sxs-lookup"><span data-stu-id="16c2d-122">Details</span></span>
<span data-ttu-id="16c2d-123">詳細セクションは、イメージ、実績の種類、ゲーマー スコア リワード (ある場合)、ロックを解除するまで実績を非表示にするかどうかなどの重要な情報を関連付けるために使用します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-123">The details section is used to associate important information such as the image, the type of achievement, the Gamerscore reward (if any) and whether the achievement should be hidden until unlocked.</span></span>

![Microsoft デベロッパー センターで新しい実績を構成する場合の詳細フィールドのスクリーンショット](../../images/dev-center/achievements-3.png)

<span data-ttu-id="16c2d-125">**[Image Icon]** フィールドでは、実績と一緒に表示されるイメージを指定します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-125">The **Image Icon** field is the image that will be displayed alongside the achievement.</span></span> <span data-ttu-id="16c2d-126">これは、1920 x 1080 ピクセルの .png ファイルである必要があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-126">It must be a 1920 x 1080 png.</span></span>

<span data-ttu-id="16c2d-127">**[Base Achievements]** は、最初のゲームのリリース時にプレイヤーが使用できます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-127">**Base Achievements** are available to your players when the initial game has been released.</span></span> <span data-ttu-id="16c2d-128">**[Non-Base Achievements]** は、最初のゲームのリリース後に利用できます (新しい DLC コンテンツなどで)。</span><span class="sxs-lookup"><span data-stu-id="16c2d-128">**Non-Base Achievements** are available after the initial game has released (such as with new DLC content).</span></span>

<span data-ttu-id="16c2d-129">**[Gamerscore]** フィールドには、ロックが解除されたときに実績で提供されるゲーマースコア ポイント数を指定します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-129">The **Gamerscore** field is the amount of Gamerscore points that your achievement will award when unlocked.</span></span> <span data-ttu-id="16c2d-130">各実績で 0 ～ 200 ポイントのリワードを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-130">Each achievement can reward between 0-200 points.</span></span>  

<span data-ttu-id="16c2d-131">**[Public]** 実績は、実績のロックを解除しているかどうかに関係なく、すべてのプレイヤーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-131">**Public** achievements are visible to all players, regardless of whether they have unlocked the achievement or not.</span></span> <span data-ttu-id="16c2d-132">**[Secret]** 実績は、ロックが解除されるまで表示されません。</span><span class="sxs-lookup"><span data-stu-id="16c2d-132">**Secret** achievements are hidden until they have been unlocked.</span></span>

<span data-ttu-id="16c2d-133">**[Achievement deep link]** は、実績から戻るパラメーターを取得するための方法です。これによって、実績を獲得できるゲーム内のスポットにリンクすることができます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-133">**Achievement deep link** is a way for you to get a parameter back from the achievement that allows you to link to a spot in your game on where the achievement can be earned.</span></span> <span data-ttu-id="16c2d-134">ディープ リンクは GET API の応答で返されます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-134">The deep link is returned in the GET API response.</span></span> <span data-ttu-id="16c2d-135">指定する URL には、`ms-xbl-{titleID}://` プレフィックスを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-135">The URL specified must contain `ms-xbl-{titleID}://` prefix.</span></span>

> [!TIP]
> <span data-ttu-id="16c2d-136">実績のディープ リンクには、ゲームの 16 進の TitleId が必要です。</span><span class="sxs-lookup"><span data-stu-id="16c2d-136">Achievement Deep links require the hexadecimal TitleId of your game.</span></span> <span data-ttu-id="16c2d-137">これは、[Microsoft デベロッパー センター](https://developer.microsoft.com/dashboard)の [[Xbox Live Setup]](xbox-live-setup.md) (Xbox Live のセットアップ) 画面にあります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-137">You can find it on [Xbox Live Setup](xbox-live-setup.md) screen in [Microsoft Dev Center](https://developer.microsoft.com/dashboard).</span></span>

## <a name="additional-rewards"></a><span data-ttu-id="16c2d-138">Additional Rewards (追加リワード)</span><span class="sxs-lookup"><span data-stu-id="16c2d-138">Additional Rewards</span></span>
<span data-ttu-id="16c2d-139">場合によっては、プレイヤーが実績のロックを解除したときに、ゲーム内リワードやアートワークを提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-139">In some cases, you might want to offer an in-game reward or artwork when a player unlocks an achievement.</span></span> <span data-ttu-id="16c2d-140">**[Additional Rewards]** セクションで、実績に関連付けられたリワード (ある場合) を定義できます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-140">You can define the rewards (if any) that are associated with an achievement in the **Additional Rewards** section.</span></span> <span data-ttu-id="16c2d-141">実績には 2 つの追加リワードを含めることができます (リワードの種類ごとに 1 つ)。</span><span class="sxs-lookup"><span data-stu-id="16c2d-141">An achievement can contain two additional rewards - one of each reward type.</span></span> <span data-ttu-id="16c2d-142">詳しくは、「[実績のリワード](../../achievements-2017/achievement-rewards.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="16c2d-142">You can read more on the [Achievement Rewards](../../achievements-2017/achievement-rewards.md) article.</span></span>

<span data-ttu-id="16c2d-143">新しいリワードを作成するには、**[Additional Rewards]** セクションの **[Add Reward]** ボタンをクリックし、フォームに記入します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-143">To create a new reward, click the **Add Reward** button in the **Additional Rewards** section and fill out the form.</span></span>

![Microsoft デベロッパー センターで実績にリワードを追加するスクリーンショット](../../images/dev-center/achievements-4.png)

### <a name="reward-details"></a><span data-ttu-id="16c2d-145">Reward Details (リワードの詳細)</span><span class="sxs-lookup"><span data-stu-id="16c2d-145">Reward Details</span></span>
<span data-ttu-id="16c2d-146">[Reward Details] に記入して、新しいリワードを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-146">Fill out the Reward Details to associate a new reward.</span></span> <span data-ttu-id="16c2d-147">完了したら、**[Add]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="16c2d-147">Once completed, click **Add**.</span></span>

![Microsoft デベロッパー センターで実績のリワードの詳細を構成する場合のスクリーンショット](../../images/dev-center/achievements-5.png)

<span data-ttu-id="16c2d-149">作成できる実績のリワードには 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-149">There are two types of achievement rewards that can be created.</span></span> <span data-ttu-id="16c2d-150">以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="16c2d-150">They are:</span></span>

1. <span data-ttu-id="16c2d-151">**Art** タイプは、高解像度のコンセプト アート、初期のデザイン画、特別に作成されたアート アセット、その他のデジタル アート アセットなどを使用するプレイヤーにリワードを提供する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-151">The **Art** type can be used if you want to reward the player with things such as high-resolution concept art, early design drawings, specially created art assets or other digital art.</span></span> <span data-ttu-id="16c2d-152">アート アセットは、Xbox One ダッシュ ボード内に表示されます。実績サービスをクエリすることで、コンパニオン エクスペリエンスに表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-152">Art assets are displayed within the Xbox One Dashboard and can be also be displayed in companion experiences by querying the Achievements service.</span></span>
2. <span data-ttu-id="16c2d-153">**In-Game** タイプは、タイトルを更新せずにカスタムのゲーム内リワードをプレイヤーに提供する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-153">The **In-Game** type can be used if you want to reward the player with custom in-game rewards without updating your title.</span></span> <span data-ttu-id="16c2d-154">考えられるシナリオには、特別なゲーム内通貨/ポイントや、特別なキャラクター、武器、マップの使用などがあります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-154">Some potential scenarios are extra in-game currency/points or access to special characters, weapons or maps.</span></span>

<span data-ttu-id="16c2d-155">**[Display Name]** フィールドには、プレイヤーに表示されるリワードの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-155">The **Display Name** field is the name of the reward that players will see.</span></span> <span data-ttu-id="16c2d-156">これには 57 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-156">It has a 57 character limit.</span></span>

<span data-ttu-id="16c2d-157">**[Description]** フィールドには、プレイヤーに表示されるリワードの説明を入力します。説明には引き換え手順を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-157">The **Description** field is the description of the reward that players will see and must include any redemption instructions.</span></span> <span data-ttu-id="16c2d-158">これには 90 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-158">It has a 90 character limit.</span></span>

<span data-ttu-id="16c2d-159">**[Image]** または **[Art]** フィールドには、リワードに関連付けられるイメージを指定します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-159">The **Image** or **Art** field is the image associated with the reward.</span></span> <span data-ttu-id="16c2d-160">種類が Art に設定されている場合、これはリワードの対象になるアートワークです。</span><span class="sxs-lookup"><span data-stu-id="16c2d-160">If the type is set to art, this will be the artwork that they will be rewarded.</span></span> <span data-ttu-id="16c2d-161">そうでない場合、これはプレイヤーが受け取るゲーム内リワードを表します。</span><span class="sxs-lookup"><span data-stu-id="16c2d-161">Otherwise, it will represent the in-game reward that they will receive.</span></span> <span data-ttu-id="16c2d-162">このイメージは、1920 x 1080 ピクセルの .png ファイルである必要があります。</span><span class="sxs-lookup"><span data-stu-id="16c2d-162">The image must be a 1920 x 1080 png.</span></span>

<span data-ttu-id="16c2d-163">**[In-game value]** フィールドが表示されるは、リワードの種類として **[In-game]** を選択した場合のみです。</span><span class="sxs-lookup"><span data-stu-id="16c2d-163">The **In-game value** field is only visible if you select the reward type of **In-game**.</span></span> <span data-ttu-id="16c2d-164">これは、ゲーム内リワードのロックを解除するために使用できるゲームのコードに渡される値を指定するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="16c2d-164">It is used to specify the value that is passed to your game's code which can be used to unlock the in-game reward.</span></span>
