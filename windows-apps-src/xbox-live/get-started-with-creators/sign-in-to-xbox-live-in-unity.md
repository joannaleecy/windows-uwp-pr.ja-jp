---
title: "Unity で Xbox Live にサインインする"
author: KevinAsgari
description: "Xbox Live プラグイン プレハブを使用して、Unity ゲームで Xbox Live アカウントにサインインする方法について説明します。"
ms.assetid: f5402d4c-894e-4879-969a-7e68699546c5
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター, サインイン"
ms.openlocfilehash: 8cfb9c7693c87fbd6df1766f9e16a1049f2c9320
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="sign-in-to-xbox-live-in-unity"></a><span data-ttu-id="4ee6b-104">Unity で Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="4ee6b-104">Sign in to Xbox Live in Unity</span></span>

> <span data-ttu-id="4ee6b-105">**注:** 現在、実績とマルチプレイヤーがサポートされていないため、Xbox Live Unity プラグインは [Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-105">**Note:** The Xbox Live Unity plugin is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members, since currently there is no support for achievements or multiplayer.</span></span>

<span data-ttu-id="4ee6b-106">Xbox Live Unity プラグインを使用すると、Unity プロジェクトで Xbox Live に簡単にサインインできます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-106">With the Xbox Live Unity plugin, you can easily sign in to Xbox Live in your Unity project.</span></span> <span data-ttu-id="4ee6b-107">付属のプレハブを使用したり、付属のスクリプトを独自のカスタム オブジェクトにアタッチしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-107">You can use the included prefab, or you can attach the included scripts to your own custom objects.</span></span>

> <span data-ttu-id="4ee6b-108">**注:** このトピックでは、Xbox Live プラグインが Unity プロジェクトで既にセットアップされていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-108">**Note:** This topic assumes that you have already set up the Xbox Live plugin in your Unity project.</span></span> <span data-ttu-id="4ee6b-109">その方法について詳しくは、「[Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-109">For information about how to do that, see [Configure Xbox Live in Unity](configure-xbox-live-in-unity.md).</span></span>

## <a name="using-the-prefab"></a><span data-ttu-id="4ee6b-110">プレハブの使用</span><span class="sxs-lookup"><span data-stu-id="4ee6b-110">Using the prefab</span></span>

<span data-ttu-id="4ee6b-111">**UserProfile** プレハブは最も重要な Xbox Live プレハブであり、**Xbox Live\Prefabs** にあります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-111">The **UserProfile** prefab is the most important Xbox Live prefab, and is located in **Xbox Live\Prefabs**.</span></span> <span data-ttu-id="4ee6b-112">このプレハブにより、ユーザーは Xbox Live にログインでき、ユーザーのログイン後にはゲーマータグ、ゲーマーアイコン、およびゲーマースコアが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-112">This prefab allows the user to log in to Xbox Live, and after the user is logged it, it will show their gamertag, gamerpic, and gamerscore.</span></span> <span data-ttu-id="4ee6b-113">通常、このプレハブは初期メニュー画面に表示するか、ゲームの起動時に自動的にトリガーされるようにします。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-113">Usually you would show this prefab on the initial menu screen, or automatically trigger it when the game launches.</span></span> <span data-ttu-id="4ee6b-114">その他の Xbox Live プレハブを使用するには、UserProfile プレハブを含めるか、手動でサインイン API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-114">In order to use any of the other Xbox Live prefabs, you must include a UserProfile prefab or manually invoke the sign-in API.</span></span> <span data-ttu-id="4ee6b-115">これを行う方法について詳しくは、**UserProfile.cs** スクリプトおよび以下のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-115">See the **UserProfile.cs** script and the section below for details on how to do this.</span></span>

<span data-ttu-id="4ee6b-116">シーンにプレハブをドラッグするだけで、設定はすべて完了します。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-116">Simply drag the prefab into a scene, and everything will be set up for you.</span></span>

![&lt;ゲーマータグ&gt; &lt;ゲーマースコア&gt;](../images/unity/unity-userprofile-prefab.PNG)

<span data-ttu-id="4ee6b-118">Xbox Live プレハブを使用するには、少なくとも最初のシーンには、**XboxLiveServices** プレハブのインスタンスをドラッグする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-118">To use any of the Xbox Live prefabs, you'll need to drag an instance of the **XboxLiveServices** prefabs to at least your initial scene.</span></span> <span data-ttu-id="4ee6b-119">このプレハブでは、デバッグを目的として、Unity パッケージに含まれるさまざまなプレハブからのログ記録をオンまたはオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-119">On that prefab, you can turn and turn off logs from the various prefabs in the unity package for debugging purposes.</span></span>

<span data-ttu-id="4ee6b-120">再生モードになると、ボタン名が **[Sign In]** (サインイン) に変わります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-120">If you enter play mode, the button will change to show **Sign In**.</span></span>

![サインイン](../images/unity/unity-sign-in.PNG)

<span data-ttu-id="4ee6b-122">ボタンをクリックすると、ユーザーのゲーマータグ、ゲーマーアイコン、およびゲーマースコアが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-122">If you click it, it will show the user's gamertag, gamerpic, and gamerscore.</span></span> <span data-ttu-id="4ee6b-123">エディターでは、これがプレースホルダー データになります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-123">In the editor, this will be placeholder data.</span></span>

![仮のユーザー 123456789](../images/unity/unity-game-fake-data.PNG)

<span data-ttu-id="4ee6b-125">実際の Xbox Live アカウントでログインするには、プロジェクトをビルドして Visual Studio から実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-125">You will need to build the project and run it from Visual Studio in order to sign in with a real Xbox Live account.</span></span> <span data-ttu-id="4ee6b-126">詳しくは、「[Unity で Xbox Live を構成する](configure-xbox-live-in-unity.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-126">See [Configure Xbox Live in Unity](configure-xbox-live-in-unity.md) for more information.</span></span>

## <a name="using-the-scripts"></a><span data-ttu-id="4ee6b-127">スクリプトの使用</span><span class="sxs-lookup"><span data-stu-id="4ee6b-127">Using the scripts</span></span>

<span data-ttu-id="4ee6b-128">Xbox Live にサインインするときにプレハブで使用されるスクリプトは、**Xbox Live\Scripts\UserProfile.cs** です。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-128">The script that the prefab uses to sign in to Xbox Live is **Xbox Live\Scripts\UserProfile.cs**.</span></span> <span data-ttu-id="4ee6b-129">ここで注意すべき主なメソッドは、`SignInAsync` です。このメソッドにより `XboxLive.Instance.SignInAsync` が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-129">The main method to be aware of here is `SignInAsync`, which calls `XboxLive.Instance.SignInAsync`.</span></span>

<span data-ttu-id="4ee6b-130">Unity のほとんどの Xbox Live 機能は、`XboxLive` スクリプト (**Xbox Live\Scripts\XboxLive.cs**) によって管理されます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-130">Most Xbox Live functionality in Unity is managed by the `XboxLive` script (**Xbox Live\Scripts\XboxLive.cs**).</span></span>  <span data-ttu-id="4ee6b-131">このオブジェクトは、Xbox Live 機能を使用するときにシーン内で自動的にインスタンス化され、`DontDestroyOnLoad` としてマークされることでゲームが動作している時間全体にわたって保持されます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-131">This object is automatically instantiated in your scene when you use any Xbox Live functionality and marked as `DontDestroyOnLoad` so that it lives for the entire duration of the game.</span></span>

<span data-ttu-id="4ee6b-132">Xbox Live API を呼び出す必要があるスクリプトは、`XboxLive.Instance` のさまざまなプロパティを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-132">Any of your scripts that need to make calls to Xbox Live APIs should use the various properties of `XboxLive.Instance`.</span></span>

* `Context` <span data-ttu-id="4ee6b-133">は、多くの Xbox Live サービスへのメイン エントリ ポイントを提供し、`SignInAsync` を使用してユーザーが認証された後に初期化されます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-133">provides the main entry point into many Xbox Live services and will be initialized after a user has been authenticated using `SignInAsync`.</span></span>  <span data-ttu-id="4ee6b-134">詳しくは、[Xbox Live API のドキュメント](http://github.com/Microsoft/xbox-live-api-csharp)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-134">See the [Xbox Live API documentation](http://github.com/Microsoft/xbox-live-api-csharp) for details.</span></span>

* `User` <span data-ttu-id="4ee6b-135">は、現在認証済みのユーザーへの参照を提供します。この参照は、さまざまなサービスを呼び出すときに使用できます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-135">provides a reference to the currently authenticated user which can be used when making calls to various services.</span></span>

<span data-ttu-id="4ee6b-136">ユーザーがサインインすると、そのユーザーに関する情報を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-136">Once the user has been signed in, you can get information about them.</span></span> <span data-ttu-id="4ee6b-137">`UserProfile` の `LoadProfileInfo` メソッドをご覧になると、スクリプトによってユーザーの ID、ゲーマーアイコン、およびその他の情報がどのように取得されるかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="4ee6b-137">You can look at `UserProfile`'s `LoadProfileInfo` method to see how the script gets the user's ID, gamerpic, and other information.</span></span>

## <a name="see-also"></a><span data-ttu-id="4ee6b-138">関連項目</span><span class="sxs-lookup"><span data-stu-id="4ee6b-138">See also</span></span>

* [<span data-ttu-id="4ee6b-139">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="4ee6b-139">Configure Xbox Live in Unity</span></span>](configure-xbox-live-in-unity.md)
