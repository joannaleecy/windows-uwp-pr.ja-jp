---
title: Achievements 2017
author: StaceyHaffner
description: "UDC で実績を構成してリワードを提供する方法について説明します。"
ms.assetid: 
ms.author: sthaff
ms.date: 07-11-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター"
ms.openlocfilehash: eef41656b76db57cf68b3247285ac7b875370778
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="configure-achievements-2017-on-dev-center"></a><span data-ttu-id="fe5c9-104">デベロッパー センターでの Achievements 2017 の構成</span><span class="sxs-lookup"><span data-stu-id="fe5c9-104">Configure Achievements 2017 on Dev Center</span></span>

> [!IMPORTANT]
> <span data-ttu-id="fe5c9-105">実績は、ID@Xbox または対象パートナーにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-105">Achievements are only applicable to ID@Xbox or Managed Partners.</span></span> <span data-ttu-id="fe5c9-106">Xbox Live クリエーターズ プログラムに参加しているゲームはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-106">Games participating in the Xbox Live Creators Program are not supported.</span></span>

<span data-ttu-id="fe5c9-107">ユニバーサル デベロッパー センター (UDC) を使用して、ゲームに関連付けられている [Achievements 2017](simplified-achievements.md) を構成することができます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-107">You can use Universal Dev Center (UDC) to configure the [Achievements 2017](simplified-achievements.md) that are associated with your game.</span></span> <span data-ttu-id="fe5c9-108">次の手順に従って新しい実績を追加します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-108">Add a new achievement by doing the following:</span></span>

1. <span data-ttu-id="fe5c9-109">[`Services`] -> [`Xbox Live`] -> [`Achievements`] の順に選択して、タイトルの実績セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-109">Navigate to the Achievements section for your title, located under `Services` -> `Xbox Live` -> `Achievements`.</span></span>
2. <span data-ttu-id="fe5c9-110">[`New Achievement`] ボタンをクリックし、フォームに記入します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-110">Click the `New Achievement` button and fill out the form.</span></span>  <span data-ttu-id="fe5c9-111">完了したら、[`Save`] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-111">Once completed, click `Save`.</span></span>

![](../images/udc/achievements_1.png)

## <a name="description"></a><span data-ttu-id="fe5c9-112">Description (説明)</span><span class="sxs-lookup"><span data-stu-id="fe5c9-112">Description</span></span>
<span data-ttu-id="fe5c9-113">説明セクションに、名前やロック状態/ロック解除状態での説明など、実績の基本情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-113">The description section is where you can enter the basics of your achievement, such as the name and locked/unlocked descriptions.</span></span> <span data-ttu-id="fe5c9-114">UDC で [`Localized Strings`] サービス構成セクションにアクセスして、実績にローカライゼーション サポートを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-114">You can add localization support to achievements by accessing the `Localized Strings` service configuration section in UDC.</span></span>

![](../images/udc/achievements_2.png)

<span data-ttu-id="fe5c9-115">[`Achievement Name`] フィールドには、実績の一般向けの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-115">The `Achievement Name` field is the public facing name of the achievement.</span></span>

<span data-ttu-id="fe5c9-116">[`Locked Description`] フィールドには、実績のロックを解除していないときにプレイヤーに表示される説明を入力します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-116">The `Locked Description` field is the description that players will see when they have not unlocked the achievement.</span></span> <span data-ttu-id="fe5c9-117">これには 100 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-117">It has a 100 character limit.</span></span>

<span data-ttu-id="fe5c9-118">[`Unlocked Description`] フィールドには、実績のロックを解除しているときにプレイヤーに表示される説明を入力します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-118">The `Unlocked Description` field is the description that players will see once they have unlocked the achievement.</span></span> <span data-ttu-id="fe5c9-119">これには 100 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-119">It has a 100 character limit.</span></span>

## <a name="details"></a><span data-ttu-id="fe5c9-120">Details (詳細)</span><span class="sxs-lookup"><span data-stu-id="fe5c9-120">Details</span></span>
<span data-ttu-id="fe5c9-121">詳細セクションは、イメージ、実績の種類、ゲーマー スコア リワード (ある場合)、ロックを解除するまで実績を非表示にするかどうかなどの重要な情報を関連付けるために使用します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-121">The details section is used to associate important information such as the image, the type of achievement, the Gamerscore reward (if any) and whether the achievement should be hidden until unlocked.</span></span>

![](../images/udc/achievements_3.png)

<span data-ttu-id="fe5c9-122">[`Image Icon`] フィールドでは、実績と一緒に表示されるイメージを指定します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-122">The `Image Icon` field is the image that will be displayed alongside the achievement.</span></span> <span data-ttu-id="fe5c9-123">これは、1920 x 1080 ピクセルの .png ファイルである必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-123">It must be a 1920 x 1080 png.</span></span>

`Base Achievements` <span data-ttu-id="fe5c9-124"> は、最初のゲームのリリース時にプレイヤーが使用できます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-124">are available to your players when the initial game has been released.</span></span> `Non-Base Achievements` <span data-ttu-id="fe5c9-125"> は、最初のゲームのリリース後に利用できます (新しい DLC コンテンツなどで)。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-125">are available after the initial game has released (such as with new DLC content).</span></span>

<span data-ttu-id="fe5c9-126">[`Gamerscore`] フィールドには、ロックが解除されたときに実績で提供されるゲーマースコア ポイント数を指定します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-126">The `Gamerscore` field is the amount of Gamerscore points that your achievement will award when unlocked.</span></span> <span data-ttu-id="fe5c9-127">各実績で 0 ～ 200 ポイントのリワードを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-127">Each achievement can reward between 0-200 points.</span></span>  

`Public` <span data-ttu-id="fe5c9-128"> 実績は、実績のロックを解除しているかどうかに関係なく、すべてのプレイヤーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-128">achievements are visible to all players, regardless of whether they have unlocked the achievement or not.</span></span> `Secret` <span data-ttu-id="fe5c9-129"> 実績は、ロックが解除されるまで表示されません。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-129">achievements are hidden until they have been unlocked.</span></span>

`Achievement deep link` <span data-ttu-id="fe5c9-130">は、実績から戻るパラメーターを取得するための方法です。これによって、実績を獲得できるゲーム内のスポットにリンクすることができます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-130">is a way for you to get a parameter back from the achievement that allows you to link to a spot in your game on where the achievement can be earned.</span></span> <span data-ttu-id="fe5c9-131">ディープ リンクは GET API の応答で返されます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-131">The deep link is returned in the GET API response.</span></span> <span data-ttu-id="fe5c9-132">指定する URL には、`ms-xbl-{titleID}://` プレフィックスを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-132">The URL specified must contain `ms-xbl-{titleID}://` prefix.</span></span>

> [!TIP]
> <span data-ttu-id="fe5c9-133">実績のディープ リンクには、ゲームの 16 進の TitleId が必要です。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-133">Achievement Deep links require the hexadecimal TitleId of your game.</span></span> <span data-ttu-id="fe5c9-134">これは UDC の [`Xbox Live Setup`] 画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-134">You can find it on `Xbox Live Setup` screen in UDC.</span></span> 

## <a name="additional-rewards"></a><span data-ttu-id="fe5c9-135">Additional Rewards (追加リワード)</span><span class="sxs-lookup"><span data-stu-id="fe5c9-135">Additional Rewards</span></span>
<span data-ttu-id="fe5c9-136">場合によっては、プレイヤーが実績のロックを解除したときに、ゲーム内リワードやアートワークを提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-136">In some cases, you might want to offer an in-game reward or artwork when a player unlocks an achievement.</span></span> <span data-ttu-id="fe5c9-137">[`Additional Rewards`] セクションで、実績に関連付けられたリワード (ある場合) を定義できます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-137">You can define the rewards (if any) that are associated with an achievement in the `Additional Rewards` section.</span></span> <span data-ttu-id="fe5c9-138">実績には 2 つの追加リワードを含めることができます (リワードの種類ごとに 1 つ)。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-138">An achievement can contain two additional rewards - one of each reward type.</span></span> <span data-ttu-id="fe5c9-139">詳しくは、「[実績のリワード](achievement-rewards.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-139">You can read more on the [Achievement Rewards](achievement-rewards.md) article.</span></span>

<span data-ttu-id="fe5c9-140">新しいリワードを作成するには、[`Additional Rewards`] セクションの [`Add Reward`] ボタンをクリックし、フォームに記入します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-140">To create a new reward, click the `Add Reward` button in the `Additional Rewards` section and fill out the form.</span></span>

![](../images/udc/achievements_4.png)

### <a name="reward-details"></a><span data-ttu-id="fe5c9-141">Reward Details (リワードの詳細)</span><span class="sxs-lookup"><span data-stu-id="fe5c9-141">Reward Details</span></span>
<span data-ttu-id="fe5c9-142">[Reward Details] に記入して、新しいリワードを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-142">Fill out the Reward Details to associate a new reward.</span></span> <span data-ttu-id="fe5c9-143">完了したら、[`Add`] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-143">Once completed, click `Add`.</span></span>

![](../images/udc/achievements_5.png)

<span data-ttu-id="fe5c9-144">作成できる実績のリワードには 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-144">There are two types of achievement rewards that can be created.</span></span> <span data-ttu-id="fe5c9-145">次の 2 つです。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-145">They are:</span></span> 

1. <span data-ttu-id="fe5c9-146">`Art` タイプは、高解像度のコンセプト アート、初期のデザイン画、特別に作成されたアート アセット、その他のデジタル アート アセットなどを使用するプレイヤーにリワードを提供する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-146">The `Art` type can be used if you want to reward the player with things such as high-resolution concept art, early design drawings, specially created art assets or other digital art.</span></span> <span data-ttu-id="fe5c9-147">アート アセットは、Xbox One ダッシュ ボード内に表示されます。実績サービスをクエリすることで、コンパニオン エクスペリエンスに表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-147">Art assets are displayed within the Xbox One Dashboard and can be also be displayed in companion experiences by querying the Achievements service.</span></span>
2. <span data-ttu-id="fe5c9-148">`In-Game` タイプは、タイトルを更新せずにカスタムのゲーム内リワードをプレイヤーに提供する場合に使用できます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-148">The `In-Game` type can be used if you want to reward the player with custom in-game rewards without updating your title.</span></span> <span data-ttu-id="fe5c9-149">考えられるシナリオには、特別なゲーム内通貨/ポイントや、特別なキャラクター、武器、マップの使用などがあります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-149">Some potential scenarios are extra in-game currency/points or access to special characters, weapons or maps.</span></span>

<span data-ttu-id="fe5c9-150">[`Display Name`] フィールドには、プレイヤーに表示されるリワードの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-150">The `Display Name` field is the name of the reward that players will see.</span></span> <span data-ttu-id="fe5c9-151">これには 57 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-151">It has a 57 character limit.</span></span>

<span data-ttu-id="fe5c9-152">[`Description`] フィールドには、プレイヤーに表示されるリワードの説明を入力します。説明には引き換え手順を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-152">The `Description` field is the description of the reward that players will see and must include any redemption instructions.</span></span> <span data-ttu-id="fe5c9-153">これには 90 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-153">It has a 90 character limit.</span></span>

<span data-ttu-id="fe5c9-154">[`Image`] または [`Art`] フィールドには、リワードに関連付けられるイメージを指定します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-154">The `Image` or `Art` field is the image associated with the reward.</span></span> <span data-ttu-id="fe5c9-155">種類が Art に設定されている場合、これはリワードの対象になるアートワークです。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-155">If the type is set to art, this will be the artwork that they will be rewarded.</span></span> <span data-ttu-id="fe5c9-156">そうでない場合、これはプレイヤーが受け取るゲーム内リワードを表します。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-156">Otherwise, it will represent the in-game reward that they will receive.</span></span> <span data-ttu-id="fe5c9-157">このイメージは、1920 x 1080 ピクセルの .png ファイルである必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-157">The image must be a 1920 x 1080 png.</span></span>

<span data-ttu-id="fe5c9-158">[`In-game value`] フィールドが表示されるは、リワードの種類として [`In-game`] を選択した場合のみです。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-158">The `In-game value` field is only visible if you select the reward type of `In-game`.</span></span> <span data-ttu-id="fe5c9-159">これは、ゲーム内リワードのロックを解除するために使用できるゲームのコードに渡される値を指定するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="fe5c9-159">It is used to specify the value that is passed to your game's code which can be used to unlock the in-game reward.</span></span>