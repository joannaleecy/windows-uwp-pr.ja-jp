---
title: "マルチユーザー サポートを Unity ゲームに追加する"
author: KevinAsgari
description: "Xbox Live Unity プラグインを使用して、マルチユーザー サポートを Unity ゲームに追加する"
ms.assetid: 
ms.author: heba
ms.date: 07-14-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, マルチユーザー"
ms.openlocfilehash: 17366f0a2012140ba405a32c434ad2a9d99a9ac8
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="add-multi-user-support-to-your-unity-game"></a><span data-ttu-id="e2097-104">マルチユーザー サポートを Unity ゲームに追加する</span><span class="sxs-lookup"><span data-stu-id="e2097-104">Add multi-user support to your Unity Game</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e2097-105">マルチユーザー シナリオは、Xbox 本体でのみサポートされ、PC ではサポートされません。</span><span class="sxs-lookup"><span data-stu-id="e2097-105">Multi-User Scenarios are only supported on Xbox Consoles not PC.</span></span>

<span data-ttu-id="e2097-106">現在、マルチユーザー サポートは Xbox Live Unity プラグインによって利用することができ、複数のローカル プレイヤーが参加するシナリオに対応しています。</span><span class="sxs-lookup"><span data-stu-id="e2097-106">Multi-user support is now supported by the Xbox Live Unity Plugin for scenarios that involve multiple local players.</span></span> <span data-ttu-id="e2097-107">マルチユーザー サポートでは、各プレイヤーは、統計やサインインで自分の Xbox Live アカウントを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e2097-107">Each player can then use their own Xbox Live account for stats and sign-in.</span></span> <span data-ttu-id="e2097-108">また、ユーザーのゲストが Xbox Live アカウントを持っていない場合でも、ゲームをプレイすることができます。</span><span class="sxs-lookup"><span data-stu-id="e2097-108">Your game can also enable guests for users that do not have Xbox Live accounts to play.</span></span> <span data-ttu-id="e2097-109">この機能は、Xbox 本体でのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e2097-109">This feature is only supported on Xbox Consoles.</span></span>

<span data-ttu-id="e2097-110">このチュートリアルでは、マルチユーザー サポートをさまざまな Xbox Live プレハブに追加する方法について、順を追って説明します。</span><span class="sxs-lookup"><span data-stu-id="e2097-110">This tutorial will walk you through how to add multi-user support to the different Xbox Live Prefabs.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e2097-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="e2097-111">Prerequisites</span></span>
<span data-ttu-id="e2097-112">[作業を始める](configure-xbox-live-in-unity.md)ためのチュートリアルに従って、Xbox Live を有効にし、構成してください。</span><span class="sxs-lookup"><span data-stu-id="e2097-112">You will need to have followed the [Getting Started](configure-xbox-live-in-unity.md) tutorial to enable and configure Xbox Live.</span></span>

## <a name="adding-and-signing-in-multiple-xbox-live-users"></a><span data-ttu-id="e2097-113">複数の Xbox Live ユーザーの追加とサインイン</span><span class="sxs-lookup"><span data-stu-id="e2097-113">Adding and signing in multiple Xbox Live users</span></span>

1. <span data-ttu-id="e2097-114">`Assets > Xbox Live > Prefabs` フォルダーから、追加するプレイヤーの数と同じ数の `XboxLiveUser` プレハブ インスタンスをシーンにドラッグします。</span><span class="sxs-lookup"><span data-stu-id="e2097-114">From the `Assets > Xbox Live > Prefabs` folder, drag onto your scene as many `XboxLiveUser` prefab instances as there will be players.</span></span> <span data-ttu-id="e2097-115">このチュートリアルでは、2 人のプレイヤーを追加するので、2 つの `XboxLiveUser`インスタンスをシーンに追加します。</span><span class="sxs-lookup"><span data-stu-id="e2097-115">For this tutorial, there will be two players so two `XboxLiveUser`  instances will be added to the scene.</span></span> <span data-ttu-id="e2097-116">便宜上、これらのインスタンスを `XboxLiveUser` および `XboxLiveUser2` と表します。</span><span class="sxs-lookup"><span data-stu-id="e2097-116">We'll refer to them as `XboxLiveUser` and `XboxLiveUser2` for convenience.</span></span>

2. <span data-ttu-id="e2097-117">ユーザーの追加とサインインを適切に行うには、`UserProfile` プレハブの 2 つのインスタンスを、各 `XboxLiveUser` インスタンスに対応するように、シーンに追加します。</span><span class="sxs-lookup"><span data-stu-id="e2097-117">To properly add the users and sign them in, add two instances of the `UserProfile` prefab to the scene, one for each `XboxLiveUser`.</span></span> <span data-ttu-id="e2097-118">シーンに `XboxLiveServices` プレハブのインスタンスがあることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="e2097-118">Make sure you have an instance of the `XboxLiveServices` prefab on the scene.</span></span> <span data-ttu-id="e2097-119">また、2 つの `UserProfile` オブジェクトをシーン上で移動し、これらのオブジェクトが別のオブジェクトであることを示してください。</span><span class="sxs-lookup"><span data-stu-id="e2097-119">Also, make sure to move the two `UserProfile` objects apart on the scene to tell them apart.</span></span> <span data-ttu-id="e2097-120">これらのプレハブは Unity Eventsystem を使用するため、`EventSystem` のインスタンスがシーンにあることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="e2097-120">Since these prefabs use the Unity Eventsystem, please make sure that you have an instance of the `EventSystem` on the scene.</span></span>

    ![Xbox Live Unity プラグインでのマルチユーザー サポートの階層を示すチュートリアル プロジェクト](../images/unity/MUA-Tutorial-Hierarchy.png)

    ![Xbox Live Unity プラグインでのマルチユーザー サポートのゲーム シーンを示すチュートリアル プロジェクト](../images/unity/MUA-Tutorial-GameScene.png)

3. <span data-ttu-id="e2097-123">シーンにある `XboxLiveUser` プレハブの各インスタンスを、`UserProfile` オブジェクトのそれぞれに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="e2097-123">Assign one instance of the `XboxLiveUser` prefabs you have on the scene to each of the `UserProfile` objects.</span></span>

    ![マルチ ユーザー サポートでの UserProfile プレハブ](../images/unity/user-profile-for-mua.png)

4. <span data-ttu-id="e2097-125">マルチユーザー アプリケーションは Xbox One デバイスでのみサポートされるため、コントローラー サポートを `UserProfile` オブジェクトに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e2097-125">Since Multi-User applications are only supported on Xbox One devices, adding controller support to the `UserProfile` objects is required.</span></span> <span data-ttu-id="e2097-126">それぞれの `UserProfile` オブジェクトには、`InputControllerButton` という名前のフィールドがあります。このフィールドでは、各 `UserProfile` がリッスンするジョイスティックとボタン番号を指定できます。</span><span class="sxs-lookup"><span data-stu-id="e2097-126">On each `UserProfile` object, there is a field called `InputControllerButton` where you can specify the joystick and button numbers each `UserProfile` should listen to.</span></span>

<span data-ttu-id="e2097-127">このチュートリアルでは、プレイヤー 1 に割り当てられている `UserProfile` で `joystick 1 button 0` を使用し、プレイヤー 2 に割り当てられている 2 番目の `UserProfile` ゲーム オブジェクトでは `joystick 2 button 0` を使用します。</span><span class="sxs-lookup"><span data-stu-id="e2097-127">For this tutorial, we'll use `joystick 1 button 0` for the `UserProfile` that Player 1 is assigned to and `joystick 2 button 0` for Player 2 and the second `UserProfile` game object.</span></span> <span data-ttu-id="e2097-128">これにより、2 つのコントローラーの `A` ボタンが、`UserProfile` を操作するために割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="e2097-128">This will assign the `A` button for interacting with `UserProfile` for the two controllers.</span></span>

> [!Note]
> <span data-ttu-id="e2097-129">Xbox Live Unity プラグインでの Xbox コントローラー サポートについて詳しくは、「[コントローラー サポートを Xbox Live プレハブに追加する](add-controller-support-to-xbox-live-prefabs.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e2097-129">For more details about Xbox Controller Support in the Xbox Live Unity Plugin, please check out: [Add Controller Support to Xbox Live Prefabs](add-controller-support-to-xbox-live-prefabs.md)</span></span>

5. <span data-ttu-id="e2097-130">エディターでシーンを実行し、各ボタンを押してその実行状況を調べ、すべてが正しく構成されていること確認してください。</span><span class="sxs-lookup"><span data-stu-id="e2097-130">Run the scene in the editor and hit run on each of the buttons to make sure everything is configured correctly.</span></span>

    ![Unity エディターでのマルチ ユーザー サポートのテスト](../images/unity/run-example-mua.png)

## <a name="building-and-testing-the-uwp"></a><span data-ttu-id="e2097-132">UWP の構築とテスト</span><span class="sxs-lookup"><span data-stu-id="e2097-132">Building and Testing the UWP</span></span>

1. <span data-ttu-id="e2097-133">「[Unity を使用してクリエーターズ タイトルを開発する](configure-xbox-live-in-unity.md)」チュートリアルで説明した手順を実行した後で、エクスポートした UWP ソリューションを Visual Studio で開きます。</span><span class="sxs-lookup"><span data-stu-id="e2097-133">After following the steps outlined at the [Develop Creators Titles with Unity](configure-xbox-live-in-unity.md) tutorial, open the exported UWP solution in Visual Studio.</span></span>

2. <span data-ttu-id="e2097-134">ゲームの UWP プロジェクトで、`package.appxmanifest.xml` ファイルを右クリックし、[コードの表示] を選択します。</span><span class="sxs-lookup"><span data-stu-id="e2097-134">Under the UWP project of your game, right click on the `package.appxmanifest.xml` file and choose View Code.</span></span>

3. <span data-ttu-id="e2097-135">`<Properties></Properties>` セクションで、`<uap:SupportedUsers>multiple</uap:SupportedUsers>` を追加します。これにより、アプリでマルチユーザー入力が可能になります。</span><span class="sxs-lookup"><span data-stu-id="e2097-135">Under the `<Properties></Properties>` section, add the following which enables multi-user input for the app: `<uap:SupportedUsers>multiple</uap:SupportedUsers>`</span></span>

4. <span data-ttu-id="e2097-136">Xbox でテストするには、「[Xbox の開発環境に UWP を設定する](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/development-environment-setup)」チュートリアルの説明に従ってください。</span><span class="sxs-lookup"><span data-stu-id="e2097-136">To test on Xbox, follow the documentation at the [Set up your UWP on Xbox development environment](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/development-environment-setup) tutorial.</span></span>

## <a name="using-the-other-xbox-live-prefabs-with-multiple-users"></a><span data-ttu-id="e2097-137">他の Xbox Live プレハブを複数のユーザーで使用する</span><span class="sxs-lookup"><span data-stu-id="e2097-137">Using the other Xbox Live Prefabs with multiple Users</span></span>

<span data-ttu-id="e2097-138">プラグインの `Examples` フォルダーには、さまざまなプレハブで `XboxLiveUser` インスタンスを使用して、各ユーザーに固有の情報を表示する方法を示す、`MultiUserExample` シーンが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e2097-138">In the `Examples` folder of the plugin, there is a `MultiUserExample` scene that shows how the different prefabs can use the `XboxLiveUser` instances to display specific information for each user.</span></span>
