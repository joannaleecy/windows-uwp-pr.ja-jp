---
title: PlayerAuthentication プレハブを使用してサインイン
description: Unity のプラグイン PlayerAuthentication プレハブの概要
ms.date: 05/08/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity
ms.openlocfilehash: ea161ff801e2004569d88d53c78ae963e91b4ce6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605737"
---
# <a name="easy-sign-in-with-the-playerauthentication-prefab"></a><span data-ttu-id="a64e5-104">PlayerAuthentication プレハブを使用して簡単なサインイン</span><span class="sxs-lookup"><span data-stu-id="a64e5-104">Easy Sign-In with the PlayerAuthentication Prefab</span></span>

<span data-ttu-id="a64e5-105">PlayerAuthentication プレハブは、Xbox Live の認証、タイトルを追加する最も簡単な方法です。</span><span class="sxs-lookup"><span data-stu-id="a64e5-105">The PlayerAuthentication prefab is the easiest way to add Xbox Live Authentication to your title.</span></span> <span data-ttu-id="a64e5-106">サインイン ページに新しいシーンから移動する 3 つの簡単な手順だけかかります。</span><span class="sxs-lookup"><span data-stu-id="a64e5-106">It only takes three easy steps to go from a new scene to a sign-in page.</span></span>

1. <span data-ttu-id="a64e5-107">PlayerAuthentication プレハブをシーンにドラッグします。</span><span class="sxs-lookup"><span data-stu-id="a64e5-107">Drag the PlayerAuthentication prefab onto the scene</span></span>
2. <span data-ttu-id="a64e5-108">XboxLiveServices プレハブをシーンにドラッグします。</span><span class="sxs-lookup"><span data-stu-id="a64e5-108">Drag an XboxLiveServices prefab onto the scene</span></span>
3. <span data-ttu-id="a64e5-109">EventSystem、シーンを追加 (PlayerAuthentication 技術的には作成されますが、EventSystem が存在しないが、推奨は、追加する場合。)</span><span class="sxs-lookup"><span data-stu-id="a64e5-109">Add an EventSystem to the scene (Technically the PlayerAuthentication will create one for you if an EventSystem is not present, but adding it is a good habit.)</span></span>

<span data-ttu-id="a64e5-110">これで完了です。</span><span class="sxs-lookup"><span data-stu-id="a64e5-110">And that's it.</span></span> <span data-ttu-id="a64e5-111">シーンに PlayerAuthentication プレハブをクリックして XboxLive に、タイトルのプレーヤーを署名することができますようになりました。</span><span class="sxs-lookup"><span data-stu-id="a64e5-111">You can now sign a player into XboxLive in your title by clicking on the PlayerAuthentication prefab in your scene.</span></span> <span data-ttu-id="a64e5-112">Unity で再生 ボタンをクリックして、シーンをテストする、プレハブ仮のデータを生成すると、これは、Unity プレーヤーが Xbox Live サービスに接続できないためです。</span><span class="sxs-lookup"><span data-stu-id="a64e5-112">Testing your scene in Unity by clicking the play button will cause your prefab to generate fake data, this is because the Unity player cannot connect to the Xbox Live service.</span></span> <span data-ttu-id="a64e5-113">実際のサインインを確認するためには、Visual Studio でローカルで実行するプロジェクトをビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a64e5-113">In order to see a real sign-in you will need to build your project to run locally in Visual Studio.</span></span> <span data-ttu-id="a64e5-114">タイトルが構成されている場合、パートナー センターとお客様が、タイトルにサインインする Microsoft アカウント/ゲーマータグを承認し、サインイン、Visual Studio のビルドで、承認されたアカウントのいずれかのことができます。</span><span class="sxs-lookup"><span data-stu-id="a64e5-114">If your title has been configured in Partner Center and you have authorized a Microsoft account/gamertag to sign in to your title then you will be able to sign-in one of your authorized accounts in a Visual Studio build.</span></span>

<span data-ttu-id="a64e5-115">PlayerAuthentication プレハブのスクリプトでは、インスペクターでは、そのビューから操作できるいくつかの設定があります。</span><span class="sxs-lookup"><span data-stu-id="a64e5-115">The PlayerAuthentication prefab's script has a few settings that you can manipulate from its view in the inspector.</span></span>

![PlayerAuthentication インスペクターのスクリーン ショット](../images/unity/playerauthentication_prefab_inspector.JPG)

* <span data-ttu-id="a64e5-117">プレーヤー数 - サインイン パネルにリンクされているプレーヤーを決定します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-117">Player Number - Dictates the player that is linked to the sign-in panel</span></span>
* <span data-ttu-id="a64e5-118">テーマ - がの場合、ユーザー サインインまたはサインアウトのサインインがパネルの配色を変更します。この設定は、明るいまたは暗いオプションです。</span><span class="sxs-lookup"><span data-stu-id="a64e5-118">Theme - Changes the color scheme for the sign-in panel for when a user is signed-in or signed out. This setting has a light or dark option.</span></span>
* <span data-ttu-id="a64e5-119">有効にするコント ローラーからの入力がプレーヤーでは、このチェック ボックスをサインインおよびサインアウト PlayerAuthentication プレハブを使用して、Xbox コント ローラーを使用します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-119">Enable Controller Input - This checkbox allows for players to use an Xbox controller to sign-in and sign-out using the PlayerAuthentication prefab.</span></span>
* <span data-ttu-id="a64e5-120">ジョイスティック数 - コント ローラーがサインインできるこの出力を決定する、プレハブを使用します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-120">Joystick Number - Dictates the controller which can sign-in our out using the prefab.</span></span>
* <span data-ttu-id="a64e5-121">ボタン - ユーザーのサインイン Xbox コント ローラーでは、どのボタンを選択することができるドロップダウンにサインインします。</span><span class="sxs-lookup"><span data-stu-id="a64e5-121">Sign In Button - A drop down which allows you to choose which button on an Xbox controller signs in a user.</span></span>
* <span data-ttu-id="a64e5-122">ボタン - ユーザーをサインアウト Xbox コント ローラーでは、どのボタンを選択することができますをドロップダウンからサインアウトします。</span><span class="sxs-lookup"><span data-stu-id="a64e5-122">Sign Out Button - A drop down which allows you to choose which button on an Xbox controller signs out a user.</span></span>

## <a name="multiplayer-scenario"></a><span data-ttu-id="a64e5-123">マルチ プレーヤー シナリオ</span><span class="sxs-lookup"><span data-stu-id="a64e5-123">Multiplayer scenario</span></span>

<span data-ttu-id="a64e5-124">サインインの 1 つのプレーヤーだけでなく Xbox One のコンソールのタイトルにローカルのマルチ プレーヤーを実装するために複数の PlayerAuthentication プレハブを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="a64e5-124">In addition to single player sign-in, you can also use multiple PlayerAuthentication prefabs to implement local multiplayer on Xbox One console titles.</span></span> <span data-ttu-id="a64e5-125">プレハブの複数のインスタンスを追加し、それぞれのプレーヤー数の属性を変更して、タイトルに複数のユーザーにサインインすることができます。</span><span class="sxs-lookup"><span data-stu-id="a64e5-125">By adding multiple instances of the prefab and changing the Player Number attribute of each, you can sign in multiple users to your title.</span></span>

> [!WARNING]
> <span data-ttu-id="a64e5-126">署名で複数のゲーマータグは Windows 10 Pc では許可されません。</span><span class="sxs-lookup"><span data-stu-id="a64e5-126">Signing-in multiple gamertags is not allowed on Windows 10 PCs.</span></span> <span data-ttu-id="a64e5-127">複数のユーザーにサインインするためには、Xbox 1 つのコンソール ゲームをテストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a64e5-127">In order to sign in multiple users you will need to test your game on an Xbox One Console.</span></span>

<span data-ttu-id="a64e5-128">マルチ プレーヤーを許可するシーンを作成するでは、多少困難 PlayerAuthentication プレハブを使用してのみです。</span><span class="sxs-lookup"><span data-stu-id="a64e5-128">Creating a scene that allows multiplayer is only marginally more difficult using the PlayerAuthentication prefab.</span></span>

1. <span data-ttu-id="a64e5-129">PlayerAuthentication プレハブのインスタンスをシーンにドラッグします。</span><span class="sxs-lookup"><span data-stu-id="a64e5-129">Drag an instance of the PlayerAuthentication prefab onto the scene</span></span>
2. <span data-ttu-id="a64e5-130">チェック、**コント ローラーの入力を有効にする**プレハブのインスペクターのボックスです。</span><span class="sxs-lookup"><span data-stu-id="a64e5-130">Check the **Enable Controller Input** box in the prefab's inspector.</span></span>
3. <span data-ttu-id="a64e5-131">確認、**プレーヤー数**と**ジョイスティック数**1 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="a64e5-131">Make sure that the **Player Number** and **Joystick Number** are set to 1.</span></span>
4. <span data-ttu-id="a64e5-132">割り当てる、**記号のボタン**ドロップ ダウン メニューから。</span><span class="sxs-lookup"><span data-stu-id="a64e5-132">Assign the **Sign In Button** from the drop down menu.</span></span>
5. <span data-ttu-id="a64e5-133">割り当てる、**サインイン ボタンをクリック**ドロップ ダウン メニューから。</span><span class="sxs-lookup"><span data-stu-id="a64e5-133">Assign the **Sign Out Button** from the drop down menu.</span></span>
6. <span data-ttu-id="a64e5-134">ドラッグ、 *2 番目*シーンに PlayerAuthentication プレハブのインスタンス。</span><span class="sxs-lookup"><span data-stu-id="a64e5-134">Drag a *second* instance of the PlayerAuthentication prefab onto the scene.</span></span>
7. <span data-ttu-id="a64e5-135">チェック、**コント ローラーの入力を有効にする**プレハブのインスペクターのボックスです。</span><span class="sxs-lookup"><span data-stu-id="a64e5-135">Check the **Enable Controller Input** box in the prefab's inspector.</span></span>
8. <span data-ttu-id="a64e5-136">確認、**プレーヤー数**と**ジョイスティック数**2 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="a64e5-136">Make sure that the **Player Number** and **Joystick Number** are set to 2.</span></span>
9. <span data-ttu-id="a64e5-137">割り当てる、**記号のボタン**ドロップ ダウン メニューから。</span><span class="sxs-lookup"><span data-stu-id="a64e5-137">Assign the **Sign In Button** from the drop down menu.</span></span>
10. <span data-ttu-id="a64e5-138">割り当てる、**サインイン ボタンをクリック**ドロップ ダウン メニューから。</span><span class="sxs-lookup"><span data-stu-id="a64e5-138">Assign the **Sign Out Button** from the drop down menu.</span></span>
11. <span data-ttu-id="a64e5-139">XboxLiveServices プレハブをシーンにドラッグします。</span><span class="sxs-lookup"><span data-stu-id="a64e5-139">Drag an XboxLiveServices prefab onto the scene</span></span>
12. <span data-ttu-id="a64e5-140">EventSystem をシーンに追加します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-140">Add an EventSystem to the scene</span></span>

<span data-ttu-id="a64e5-141">プレハブを Unity プレーヤーで再生のキーを押してして正常に動作し、プレハブをクリックするとことを確認します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-141">Check that the prefabs are working correctly by pressing play in the Unity Player and clicking the prefabs.</span></span> <span data-ttu-id="a64e5-142">これらは、Unity プレーヤーが Xbox Live に接続できないように予定されている仮のデータを返します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-142">They will return fake data which is expected as the Unity Player cannot connect to Xbox Live.</span></span> <span data-ttu-id="a64e5-143">さまざまなプレイヤーと、Visual Studio でゲームをビルドする準備が整ったらジョイスティックするように構成 PlayerAuthentication プレハブの 2 つのインスタンスが適切でテストできます、Xbox コンソール。</span><span class="sxs-lookup"><span data-stu-id="a64e5-143">With two instances of the PlayerAuthentication prefab configured to different players and joysticks you are ready to build your game in Visual Studio so it can be properly tested on an Xbox Console.</span></span> <span data-ttu-id="a64e5-144">ゲームの構築後は、ゲームのマルチ ユーザー サポートを有効にする必要がありますが、Visual Studio でソリューション ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="a64e5-144">Once your game is built, open the solution file in Visual Studio you will need to enable multi user support for your game.</span></span>
<span data-ttu-id="a64e5-145">これには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-145">To do this:</span></span>

1. <span data-ttu-id="a64e5-146">Package.appxmanifest.xml ファイルの ソリューション エクスプ ローラーを検索します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-146">Search the Solution Explorer for the package.appxmanifest.xml file</span></span>
2. <span data-ttu-id="a64e5-147">ファイルを右クリックし、コードの表示</span><span class="sxs-lookup"><span data-stu-id="a64e5-147">Right click the file and choose View Code</span></span>
3. <span data-ttu-id="a64e5-148">で、`<Properties><\/Properties>`セクションで、次の行を追加します: ' < uap:SupportedUsers > 複数 <\/uap:SupportedUsers >。</span><span class="sxs-lookup"><span data-stu-id="a64e5-148">Under the `<Properties><\/Properties>` section, add the following line: \`<uap:SupportedUsers>multiple<\/uap:SupportedUsers>.</span></span>
4. <span data-ttu-id="a64e5-149">お使いの Xbox にゲームを Visual Studio からリモートのデバッグ ビルドを開始して展開します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-149">Deploy the game to your Xbox by starting a remote debugging build from Visual Studio.</span></span> <span data-ttu-id="a64e5-150">Xbox、タイトルを設定する命令を見つけることができます、 [Xbox 開発環境で、UWP 設定](../../xbox-apps/development-environment-setup.md)記事。</span><span class="sxs-lookup"><span data-stu-id="a64e5-150">You can find instruction to set up your title on an Xbox in the [Set up your UWP on Xbox development environment](../../xbox-apps/development-environment-setup.md) article.</span></span>

> [!NOTE]
> <span data-ttu-id="a64e5-151">構成の変更の一部は、マルチ プレーヤーは有効にするが、1 つのプレーヤーのシナリオで、ゲームを実行する必要がように見える場合があります。</span><span class="sxs-lookup"><span data-stu-id="a64e5-151">The piece of configuration changed may look like it is enabling multi-player but it is still necessary to run your game in single player scenarios.</span></span>

<span data-ttu-id="a64e5-152">動作がアーティクルと共にスクリプトのサインインの詳細を学べるようになったら、PlayerAuthentication prefab [Unity でのサインイン マネージャーを使用してサインイン](sign-in-manager.md)します。</span><span class="sxs-lookup"><span data-stu-id="a64e5-152">Once you've got the PlayerAuthentication prefab working you can learn more about scripting sign-in with the article [Sign-In with the Sign-In manager in Unity](sign-in-manager.md).</span></span>