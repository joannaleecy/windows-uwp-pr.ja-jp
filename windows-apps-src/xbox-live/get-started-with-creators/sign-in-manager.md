---
title: Unity で SignInManager でサインイン
description: Unity プラグイン サインイン Manager の概要
ms.date: 05/08/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity
ms.openlocfilehash: e6d066fe7792912f8918cb139d45ff05d105feaa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641727"
---
# <a name="scripting-sign-in"></a><span data-ttu-id="304b3-104">サインイン スクリプト</span><span class="sxs-lookup"><span data-stu-id="304b3-104">Scripting Sign-In</span></span>

<span data-ttu-id="304b3-105">GameObject にスクリプトを作成する必要がありますが、独自のカスタム ゲーム オブジェクトにサインインを追加するにはします。</span><span class="sxs-lookup"><span data-stu-id="304b3-105">In order to add sign-in to your own custom game objects you will need to script it into a GameObject.</span></span> <span data-ttu-id="304b3-106">系 PlayerAuthentication プレハブは、ゲームに一致しないこととする独自のサインイン パネルには、この記事で、タイトルにサインインしているロジックを追加する基本的な手順を実行するとします。</span><span class="sxs-lookup"><span data-stu-id="304b3-106">Let us say that the PlayerAuthentication prefab doesn't fit your game and you'd like to have your own sign-in panel, this article will take you through the basic steps of adding sign-in logic to your title.</span></span>

## <a name="sign-in-with-the-signinmanager"></a><span data-ttu-id="304b3-107">SignInManager を使用してサインインする</span><span class="sxs-lookup"><span data-stu-id="304b3-107">Sign in with the SignInManager</span></span>

<span data-ttu-id="304b3-108">プラグイン Xbox Live Unity にはスクリプトが含まれています、`SignInManager`ファイル パスの下**資産 >> XboxLive >> スクリプト >> SignInManager.cs**します。</span><span class="sxs-lookup"><span data-stu-id="304b3-108">The Xbox Live Unity plug-in contains a script for the `SignInManager` under the file path **Assets >> XboxLive >> Scripts >> SignInManager.cs**.</span></span> <span data-ttu-id="304b3-109">呼び出すことができるフォーム任意の場所、タイトルのタイトルを参照してシングルトン クラスは、マネージャーが*インスタンス*の`SignInManager`します。</span><span class="sxs-lookup"><span data-stu-id="304b3-109">The manager is a Singleton class which can be called form anywhere in your title by referring to the title's *Instance* of the `SignInManager`.</span></span> <span data-ttu-id="304b3-110">これは、*インスタンス*を初期化する必要としないことができますを使用して、it、ゲームを開始するとすぐにします。</span><span class="sxs-lookup"><span data-stu-id="304b3-110">This *Instance* does not need to be initialized and you can use the it as soon as your game begins.</span></span> <span data-ttu-id="304b3-111">すべてにアクセスすることができます、そのパブリック プロパティと関数を参照することで、*インスタンス*として`SignInManager.Instance`します。</span><span class="sxs-lookup"><span data-stu-id="304b3-111">You can access all of the its public properties and functions by referring to the *Instance* as `SignInManager.Instance`.</span></span>

<span data-ttu-id="304b3-112">`SignInManager`のタイトルの認証を管理するには、これは、サインイン、サインアウトに含まれます、どのプレーヤーとしてサインインするユーザーに関する情報の取得に必要なコードのすべてが含まれます。</span><span class="sxs-lookup"><span data-stu-id="304b3-112">The `SignInManager` contains all of the code necessary for managing authentication for your title, this includes sign-in, sign-out, and getting information about which users are signed in as which player.</span></span>

### <a name="calls-and-results"></a><span data-ttu-id="304b3-113">呼び出しと結果</span><span class="sxs-lookup"><span data-stu-id="304b3-113">Calls and Results</span></span>

<span data-ttu-id="304b3-114">`SignInManager`が 3 つの非同期共同ルーチン関数`SignInPlayer(int playerNumber)`、`SignOutPlayer(int playerNumber)`と`SwitchUser(int playerNumber)`、そのトリガー イベントの関数の呼び出しの結果を収集し、それに従って動作します。</span><span class="sxs-lookup"><span data-stu-id="304b3-114">The `SignInManager` has three async co-routine functions `SignInPlayer(int playerNumber)`, `SignOutPlayer(int playerNumber)`, and `SwitchUser(int playerNumber)`, that trigger event functions to collect the results of the call and act accordingly.</span></span> <span data-ttu-id="304b3-115">スクリプトに対応する関数を追加して割り当てるには`SignInManager.Instance`のコールバックの一覧。</span><span class="sxs-lookup"><span data-stu-id="304b3-115">You can add corresponding functions to your script and assign them to the `SignInManager.Instance`'s callback list.</span></span> <span data-ttu-id="304b3-116">イベントの関数は`OnPlayerSignIn(int playerNumber, UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`、 `OnPlayerSignOut(int playerNumber, UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`、 `OnAnyPlayerSignIn(UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`、および`OnAnyPlayerSignOut(UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`します。</span><span class="sxs-lookup"><span data-stu-id="304b3-116">The event functions are `OnPlayerSignIn(int playerNumber, UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`, `OnPlayerSignOut(int playerNumber, UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`, `OnAnyPlayerSignIn(UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`, and `OnAnyPlayerSignOut(UnityAction<XboxLiveUser, XboxLiveAuthStatus, string> callback)`.</span></span> <span data-ttu-id="304b3-117">イベント関数のそれぞれには、名前に記載されているイベントをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="304b3-117">Each on of the event functions listens for the event described in its name.</span></span> <span data-ttu-id="304b3-118">マネージャーのコールバックの一覧に、独自の関数を追加するにはタイトルの`Start()`関数を次のコード。</span><span class="sxs-lookup"><span data-stu-id="304b3-118">You can add your own functions to the manager's callback list in your title's `Start()` function with the following code.</span></span>

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;

void Start () {
    try
    {
        SignInManager.Instance.OnPlayerSignOut(this.playerNumber, this.OnPlayerSignOut);
        SignInManager.Instance.OnPlayerSignIn(this.playerNumber, this.OnPlayerSignIn);
    }
    catch (Exception ex)
    {
        Debug.LogWarning(ex.Message);
    }

}
```

<span data-ttu-id="304b3-119">このコード スニペットは、この GameObject の playerNumber に関連付けられているプレイヤーのサインインとサインアウトのリスナーを追加します。</span><span class="sxs-lookup"><span data-stu-id="304b3-119">This code snippet adds sign-in and sign-out listeners for the player associated with this GameObject's playerNumber.</span></span> <span data-ttu-id="304b3-120">この GameObject の`OnPlayerSignIn`ときに関数が呼び出されます、`SignInManager`サインイン試行が完了したかを検出し、その`OnPlayerSignOut`関数は、サインアウト、SignInManager を検出したときに呼び出されます。イベントの関数は、GameObject は、SignInManager によって呼び出される関数の型と一致させるには、戻り値の型とパラメーターが必要です。</span><span class="sxs-lookup"><span data-stu-id="304b3-120">This GameObject's `OnPlayerSignIn` function will be called when the `SignInManager` detects a sign-in attempt has completed and its `OnPlayerSignOut` function will be called when the SignInManager detects a sign-out. The event functions in your GameObject must have a return type and parameters to match the function type called by the SignInManager.</span></span> <span data-ttu-id="304b3-121">両方の`OnPlayerSignIn`と`OnPlayerSignOut`void 関数が必要とする、 `XboxLiveUser`、`XboxLiveAuthStatus`とそのパラメーターとして文字列。</span><span class="sxs-lookup"><span data-stu-id="304b3-121">Both the `OnPlayerSignIn` and `OnPlayerSignOut` are void functions which need an `XboxLiveUser`, `XboxLiveAuthStatus`, and a string as their parameters.</span></span> <span data-ttu-id="304b3-122">関数のシェルは、次のようになります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="304b3-122">The shell of your functions may look like the following:</span></span>

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;

private void OnPlayerSignIn(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
}

private void OnPlayerSignOut(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
}
```

<span data-ttu-id="304b3-123">両方の関数では、確認、`XboxLiveAuthStatus`ことを確認する呼び出し、`SignInManager.Instance`が成功しました。</span><span class="sxs-lookup"><span data-stu-id="304b3-123">In both functions check the `XboxLiveAuthStatus` to make sure that your call to the `SignInManager.Instance` was successful.</span></span> <span data-ttu-id="304b3-124">正常な呼び出しで、`XboxLiveUser`なります、`XboxLiveUser`でこの出力に署名する`SignInManager`します。</span><span class="sxs-lookup"><span data-stu-id="304b3-124">On a successful call the `XboxLiveUser` will be the `XboxLiveUser`, that was signed in our out by `SignInManager`.</span></span> <span data-ttu-id="304b3-125">呼び出しが成功した場合、`errorMessage`文字列には、失敗の理由の詳細についてにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="304b3-125">When the call is unsuccessful the `errorMessage` string will contain details on the reason for failure.</span></span>

<span data-ttu-id="304b3-126">呼び出しの成功を確認するコードの数行を追加すると、次のようなコードが生成。</span><span class="sxs-lookup"><span data-stu-id="304b3-126">Adding a few lines of code to check for a successful call would result in code like the following:</span></span>

```csharp
using Microsoft.Xbox.Services;
using Microsoft.Xbox.Services.Client;

private void OnPlayerSignIn(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
    if(authStatus == XboxLiveAuthStatus.Succeeded)
    {
        this.xboxLiveUser = xboxLiveUserParam; //store the xboxLiveUser SignedIn
        this.signedIn = true;
    }
    else
    {
        if (XboxLiveServicesSettings.Instance.DebugLogsOn)
        {
            Debug.LogError(errorMessage); //Log the error message in case of unsuccessful call. 
        }
    }
}

private void OnPlayerSignOut(XboxLiveUser xboxLiveUserParam, XboxLiveAuthStatus authStatus, string errorMessage)
{
    if (authStatus == XboxLiveAuthStatus.Succeeded)
    {
        this.xboxLiveUser = null;
        this.signedIn = false;
    }
    else
    {
        if (XboxLiveServicesSettings.Instance.DebugLogsOn)
        {
            Debug.LogError(errorMessage);
        }
    }
}
```

<span data-ttu-id="304b3-127">サインインを呼び出すと、結果を結果として得られるイベントのキャプチャ、タイトルのサインインとサインアウトを処理できます。</span><span class="sxs-lookup"><span data-stu-id="304b3-127">By calling sign-in and capturing the resulting event for the result, you can handle sign-in and sign-out for your title.</span></span>

## <a name="get-signed-in-player-information"></a><span data-ttu-id="304b3-128">プレーヤーの情報でサインインします。</span><span class="sxs-lookup"><span data-stu-id="304b3-128">Get Signed In Player Information</span></span>

<span data-ttu-id="304b3-129">サービスにプレーヤーの署名に加えて、SignInManager をサインインしているすべてのユーザーの追跡を保持します。</span><span class="sxs-lookup"><span data-stu-id="304b3-129">In addition to signing players into the service the SignInManager keeps track of all the signed in users.</span></span> <span data-ttu-id="304b3-130">PC でこの player で署名された、1 つに制限されています、Xbox では 16 に制限されます。</span><span class="sxs-lookup"><span data-stu-id="304b3-130">On PC this will be limited to a single signed in player, and on the Xbox it is limited to 16.</span></span> <span data-ttu-id="304b3-131">方法の結果を比較することによってがする制限に近づいてを確認できます`SignInManager.Instance.GetCurrentNumberOfPlayers()`の結果に`SignInManager.Instance.GetMaximumNumberOfPlayers()`します。</span><span class="sxs-lookup"><span data-stu-id="304b3-131">You can check how near the limit you are by comparing the result of `SignInManager.Instance.GetCurrentNumberOfPlayers()` to the result of `SignInManager.Instance.GetMaximumNumberOfPlayers()`.</span></span> <span data-ttu-id="304b3-132">SignInManager がサインインにプレーヤーによってそのプレイヤーのインデックス作成のディクショナリ*playerNumber*します。</span><span class="sxs-lookup"><span data-stu-id="304b3-132">The SignInManager has a dictionary of signed-in players indexed by that player's *playerNumber*.</span></span> <span data-ttu-id="304b3-133">これを使用するにはそれに関連付けられたからアクセス可能なプレーヤーに関する基本的な情報を取得する`XboxLiveUser`します。</span><span class="sxs-lookup"><span data-stu-id="304b3-133">You can use this to retrieve some basic information about the player accessible from their associated `XboxLiveUser`.</span></span>

```csharp
if (SignInManager.Instance.GetPlayer(this.playerNumber).IsSignedIn) // If there is a player signed in for this gameObjects player number
            {
                this.displayedGamertag = SignInManager.Instance.GetPlayer(this.playerNumber).Gamertag; // Set that users gamertag to the gamertag displayed
            }
```

<span data-ttu-id="304b3-134">この少しのコードでは、この GameObject のプレーヤー数スロットにサインインして、プレーヤーがあるかどうかを確認し、し署名されている場合に表示するには、そのユーザー ゲーマータグを格納します。</span><span class="sxs-lookup"><span data-stu-id="304b3-134">This little bit of code checks to see if there is a player signed in to the player number slot for this GameObject and then stores that users gamertag to be displayed if they are signed in.</span></span> <span data-ttu-id="304b3-135">中に、`XboxLiveUser`のように、サインインしているユーザー ゲーマータグ、Xbox ユーザー ID を他のサービスを呼び出す必要があります (xuid) でを含む、 `SocialManager` gamerpic やゲーマーのような情報にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="304b3-135">While the `XboxLiveUser` contains the signed in users gamertag and Xbox user ID (xuid) you will need to call other services like the `SocialManager` to access information like gamerpic and gamerscore.</span></span>

## <a name="destroying-your-sign-in-gameobject"></a><span data-ttu-id="304b3-136">破棄、サインインが GameObject</span><span class="sxs-lookup"><span data-stu-id="304b3-136">Destroying your sign-in GameObject</span></span>

<span data-ttu-id="304b3-137">などのプラグインの Xbox Live マネージャーのいずれかを使用するゲーム オブジェクトを破棄するときに、`SignInManager`または`SocialManager`、通常は、マネージャーのイベント リスナーのリストに追加されたすべての関数を削除する重要な新しいシーンを読み込むときにします。</span><span class="sxs-lookup"><span data-stu-id="304b3-137">When destroying a game object that uses one of the Xbox Live plugin managers like the `SignInManager` or the `SocialManager`, usually when loading a new scene, it is important to remove any functions added to the list of event listeners for the manager.</span></span> <span data-ttu-id="304b3-138">この記事のコード例では、サインインとサインアウトのイベント リスナーを追加しました関数を削除する必要があります。これらの関数から削除するところ、`SignInManager`で、 `OnDestroy()` GameObject の関数。</span><span class="sxs-lookup"><span data-stu-id="304b3-138">In the example code for this article we would need to remove the functions we added to the event listeners for sign-in and sign-out. We would remove these functions from the `SignInManager` in the `OnDestroy()` function of our GameObject.</span></span>

```csharp
private void OnDestroy()
{
    if (SignInManager.Instance != null)
    {
        SignInManager.Instance.RemoveCallbackFromPlayer(this.PlayerNumber, this.OnPlayerSignOut);
        SignInManager.Instance.RemoveCallbackFromPlayer(this.PlayerNumber, this.OnPlayerSignIn);
    }
```

<span data-ttu-id="304b3-139">このコードはこの GameObject に関連付けられているプレイヤーのサインインとサインアウトのコールバック関数を削除します。</span><span class="sxs-lookup"><span data-stu-id="304b3-139">This code will remove the sign-in and sign-out callback functions for the player associated with this GameObject.</span></span>

## <a name="testing-you-code-in-visual-studio"></a><span data-ttu-id="304b3-140">Visual Studio でコードをテストします。</span><span class="sxs-lookup"><span data-stu-id="304b3-140">Testing you code in Visual Studio</span></span>

<span data-ttu-id="304b3-141">加え、 [Visual Studio でゲームをビルドに必要な手順](configure-xbox-live-in-unity.md#build-and-test-the-project)に表示されている、 [for Unity、Xbox Live タイトルを構成する](configure-xbox-live-in-unity.md)に関する記事で、適切にゲームをテストするために必要な追加の手順がVisual Studio。</span><span class="sxs-lookup"><span data-stu-id="304b3-141">In addition to the [steps required to build your game in Visual Studio](configure-xbox-live-in-unity.md#build-and-test-the-project), listed in the [Configure your Xbox Live Title for Unity](configure-xbox-live-in-unity.md) article, there is an additional step required to test your game properly in Visual Studio.</span></span> <span data-ttu-id="304b3-142">Package.appxmanifest.xml ファイルのプロパティを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="304b3-142">You will need to update a property of the package.appxmanifest.xml file.</span></span> <span data-ttu-id="304b3-143">これには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="304b3-143">To do this:</span></span>

1. <span data-ttu-id="304b3-144">Package.appxmanifest.xml ファイルの ソリューション エクスプ ローラーを検索します。</span><span class="sxs-lookup"><span data-stu-id="304b3-144">Search the Solution Explorer for the package.appxmanifest.xml file</span></span>
2. <span data-ttu-id="304b3-145">ファイルを右クリックし、コードの表示</span><span class="sxs-lookup"><span data-stu-id="304b3-145">Right click the file and choose View Code</span></span>
3. <span data-ttu-id="304b3-146">で、`<Properties><\/Properties>`セクションで、次の行を追加します: ' < uap:SupportedUsers > 複数 <\/uap:SupportedUsers >。</span><span class="sxs-lookup"><span data-stu-id="304b3-146">Under the `<Properties><\/Properties>` section, add the following line: \`<uap:SupportedUsers>multiple<\/uap:SupportedUsers>.</span></span>
4. <span data-ttu-id="304b3-147">お使いの Xbox にゲームを Visual Studio からリモートのデバッグ ビルドを開始して展開します。</span><span class="sxs-lookup"><span data-stu-id="304b3-147">Deploy the game to your Xbox by starting a remote debugging build from Visual Studio.</span></span> <span data-ttu-id="304b3-148">Xbox、タイトルを設定する命令を見つけることができます、 [Xbox 開発環境で、UWP 設定](../../xbox-apps/development-environment-setup.md)記事。</span><span class="sxs-lookup"><span data-stu-id="304b3-148">You can find instruction to set up your title on an Xbox in the [Set up your UWP on Xbox development environment](../../xbox-apps/development-environment-setup.md) article.</span></span>

> [!NOTE]
> <span data-ttu-id="304b3-149">構成の変更の一部は、マルチ プレーヤーは有効にするが、1 つのプレーヤーのシナリオで、ゲームを実行する必要がように見える場合があります。</span><span class="sxs-lookup"><span data-stu-id="304b3-149">The piece of configuration changed may look like it is enabling multi-player but it is still necessary to run your game in single player scenarios.</span></span>

## <a name="policies-and-limitations"></a><span data-ttu-id="304b3-150">ポリシーと制限事項</span><span class="sxs-lookup"><span data-stu-id="304b3-150">Policies and Limitations</span></span>

<span data-ttu-id="304b3-151">いくつかのサインイン ポリシーと、タイトルのサインイン エクスペリエンスを開発する際に考慮が必要なの制限事項があります。</span><span class="sxs-lookup"><span data-stu-id="304b3-151">There are a few sign-in policies and limitations of the Title's that you may want to consider when developing your sign-in experience.</span></span>

- <span data-ttu-id="304b3-152">タイトルの初回サインイン後に、サインイン済みの少なくとも 1 つのプレーヤーを保持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="304b3-152">After your title's initial sign-in you must keep at least one player signed-in.</span></span> <span data-ttu-id="304b3-153">`SignInManager`はエラーをスローし、最後にサインインしているユーザーのサインアウトしようとした場合、呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="304b3-153">The `SignInManager` will throw an error and fail the call if you attempt to sign out the last signed in user.</span></span> <span data-ttu-id="304b3-154">呼び出すことはできないことに注意してください。`SignInManager.Instance.SwitchUser(int playerNumber)`の最後でサインインして player 新しいプレーヤーをサインインする前に、プレーヤーのサインアウトしようとします。</span><span class="sxs-lookup"><span data-stu-id="304b3-154">It is also important to note that you cannot call `SignInManager.Instance.SwitchUser(int playerNumber)`, on the last signed in player as it will attempt to sign out the player before signing in a new player.</span></span>

- <span data-ttu-id="304b3-155">PC は、コンソールは一度に最大 16 のプレーヤーで署名一度にのみサインインが 1 人のユーザーをできます。</span><span class="sxs-lookup"><span data-stu-id="304b3-155">PC can only sign-in one user at a time, Console may sign in up to 16 players at once.</span></span>

- <span data-ttu-id="304b3-156">タイトルは、実際には、プレーヤーを OS からサインアウトする権限がありません、ためこのサインアウトが正常に動作しません。</span><span class="sxs-lookup"><span data-stu-id="304b3-156">The title does not actually have permission to sign out a player from the OS, because of this SignOut may not work as expected.</span></span> <span data-ttu-id="304b3-157">SignInManager は in および out タイトルでは、ここにユーザーがサインインすることができますが、できないすべてのユーザーからサインアウトにタイトルが展開されているコンピューター。</span><span class="sxs-lookup"><span data-stu-id="304b3-157">The SignInManager can sign a user in and out where the title is concerned but cannot sign anyone out from the machine the title is deployed to.</span></span>

- <span data-ttu-id="304b3-158">複数のユーザー サインインが Xbox の 1 つのコンソールで使用できるのみです。</span><span class="sxs-lookup"><span data-stu-id="304b3-158">Multiple user sign-in is only available on the Xbox One Console.</span></span>

- <span data-ttu-id="304b3-159">ゲスト アカウントでは、Xbox Live クリエーターズ プログラムのタイトルに使用できません。</span><span class="sxs-lookup"><span data-stu-id="304b3-159">Guest accounts are not available to Xbox Live Creators Program titles.</span></span>