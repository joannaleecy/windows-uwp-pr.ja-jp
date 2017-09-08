---
title: "Xbox Live のサンドボックス"
author: KevinAsgari
description: "Xbox Live のサンドボックスの概要"
ms.assetid: e7daf845-e6cb-4561-9dfa-7cfba882f494
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 808de5def8de7e871af9c4d575c005d65704a185
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="xbox-live-sandboxes-introduction"></a><span data-ttu-id="3a5e9-104">Xbox Live のサンドボックスの概要</span><span class="sxs-lookup"><span data-stu-id="3a5e9-104">Xbox Live sandboxes introduction</span></span>

<span data-ttu-id="3a5e9-105">「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」では、タイトルに関する情報をオンラインで構成する必要があることを説明しました (通常は [Windows デベロッパー センター](http://dev.windows.com)で構成する)。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-105">In [Xbox Live Service Configuration](../xbox-live-service-configuration.md), it was explained that you must configure information about your title online, usually on [Windows Dev Center](http://dev.windows.com).</span></span>  <span data-ttu-id="3a5e9-106">この情報には、タイトルで表示するランキングなどの項目、プレイヤーが解除できる実績、マッチメイキング構成などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-106">This information includes things like the leaderboards your title wants to display, achievements that players can unlock, matchmaking configuration, etc.</span></span>

<span data-ttu-id="3a5e9-107">サービス構成に変更を加える場合、それらの変更が Xbox Live の他の部分によって取得され、タイトルで表示されるようにするには、デベロッパー センターから変更を公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-107">When you make changes to your service configuration, these need to be published from Dev Center before the changes are picked up by the rest of Xbox Live and can be seen by your title.</span></span>

<span data-ttu-id="3a5e9-108">この公開先は、開発サンドボックスと呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-108">You publish to what is called a development sandbox.</span></span>  <span data-ttu-id="3a5e9-109">これらのサンドボックスにより、分離された環境でタイトルに対して変更を加えることができます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-109">These allow you to work on changes to your title in an isolated environment.</span></span>  <span data-ttu-id="3a5e9-110">サンドボックスには、以下のセクションで説明するようにいくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-110">These offer several benefits described in the below section.</span></span>

<span data-ttu-id="3a5e9-111">既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスに格納されます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-111">By default, Xbox One Consoles and Windows 10 PCs are in the RETAIL sandbox.</span></span>

## <a name="benefits"></a><span data-ttu-id="3a5e9-112">利点</span><span class="sxs-lookup"><span data-stu-id="3a5e9-112">Benefits</span></span>

<span data-ttu-id="3a5e9-113">開発サンドボックスには、いくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-113">Development sandboxes offer a few benefits:</span></span>


1. <span data-ttu-id="3a5e9-114">現在利用可能なバージョンに影響を与えずに、タイトルの更新への変更を反復処理できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-114">You can iterate on changes to an update for your title without affecting the currently available version.</span></span>
2. <span data-ttu-id="3a5e9-115">一部のツールは、セキュリティ上の理由から開発サンドボックス内でのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-115">Some tools only work in a development sandbox for security reasons.</span></span>
3. <span data-ttu-id="3a5e9-116">チーム内の一部の開発者は、開発中の主要なサービス構成に影響を与えずに、サービス構成の変更を "分岐" させてテストできます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-116">Some developers on your team may want to "branch" and test service config changes without affecting your primary in-development service configuration.</span></span>
4. <span data-ttu-id="3a5e9-117">他の公開元は、サンドボックスへのアクセス権が付与されない限り、その内部での作業内容を閲覧できません。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-117">Other publishers cannot see what you are working on without being granted access to your sandbox.</span></span>

<span data-ttu-id="3a5e9-118">**必要に応じて**テスト アカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-118">You can also **optionally** create test accounts.</span></span>  <span data-ttu-id="3a5e9-119">タイトルのテストに通常の Xbox Live アカウントを使用したくない場合や、ソーシャルな交流 (例: 友人の統計情報の表示) やマルチプレイヤーなどのシナリオをテストするために複数のアカウントが必要である場合に、テスト アカウントを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-119">You can use these if you don't want to use your regular Xbox Live account for testing your title, or you need several accounts to test scenarios such as social interaction (eg: view a friend's stats) or multiplayer.</span></span>

<span data-ttu-id="3a5e9-120">テスト アカウントは開発サンドボックスにのみログインできます。以下のセクションで詳細を説明します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-120">Test accounts can only sign-in to development sandboxes, and will be explained in a section below.</span></span>

## <a name="finding-out-about-your-sandbox"></a><span data-ttu-id="3a5e9-121">サンドボックスを調べる</span><span class="sxs-lookup"><span data-stu-id="3a5e9-121">Finding out about your sandbox</span></span>

<span data-ttu-id="3a5e9-122">開発者の大部分は、サンドボックスを 1 つだけ必要とします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-122">The vast majority of developers need only one sandbox.</span></span>  <span data-ttu-id="3a5e9-123">またサンドボックスは、タイトルの作成時に自動的に作られます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-123">Fortunately a sandbox is created for you when you create a title.</span></span>

1. <span data-ttu-id="3a5e9-124">サンドボックスについて調べるには、次に示されている、デベロッパー センター ダッシュボードに移動してください。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-124">You find out about your sandbox by going to the Dev Center dashboard here:</span></span>
![](../images/getting_started/first_xbltitle_dashboard.png)

1. <span data-ttu-id="3a5e9-125">次に、タイトルをクリックします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-125">Then click on your title:</span></span>
![](../images/getting_started/first_xbltitle_dashboard_overview.png)

1. <span data-ttu-id="3a5e9-126">最後に、左側のメニューで [サービス] -> [Xbox Live] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-126">Finally click on Services->Xbox Live in the left menu</span></span>
![](../images/getting_started/first_xbltitle_leftnav.png)

1. <span data-ttu-id="3a5e9-127">これにより、次のようにサンドボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-127">You can now see your sandbox listed as follows</span></span>
![](../images/getting_started/devcenter_sandbox_id.png)

## <a name="how-your-sandbox-impacts-your-workflow"></a><span data-ttu-id="3a5e9-128">サンドボックスがワークフローに与える影響</span><span class="sxs-lookup"><span data-stu-id="3a5e9-128">How your sandbox impacts your workflow</span></span>

<span data-ttu-id="3a5e9-129">通常、サンドボックスは次の方法で操作します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-129">Typically you work with sandboxes in the following ways:</span></span>

1. <span data-ttu-id="3a5e9-130">(1 回限り) PC または Xbox One を開発サンドボックスに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-130">(One-time) Switch your PC or Xbox One to your development sandbox.</span></span>
2. <span data-ttu-id="3a5e9-131">(複数回) サービス構成に変更を加えるときに、変更を開発サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-131">(Many-times) As you make changes to your service configuration, you will publish changes to your development sandbox.</span></span>  <span data-ttu-id="3a5e9-132">サービス構成の変更には、実績の定義、ランキングの追加、マルチプレイヤー セッション テンプレートの変更などがあります。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-132">Service configuration changes are things such as defining achievements, adding leaderboards, or modifying a Multiplayer Session Template.</span></span>
3. <span data-ttu-id="3a5e9-133">(2、3 回) 他のチーム メンバーと作業する場合は、それらのメンバーにサンドボックスへのアクセス権を付与します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-133">(A few times) If you are working with other team members, you can give them access to your sandbox</span></span>
4. <span data-ttu-id="3a5e9-134">(1 回限り) RETAIL で何かをテストする必要がある場合や、休憩を取ってお気に入りの Xbox ゲームをプレイする場合は、サンドボックスを元の RETAIL に切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-134">(One-time) If you need to test something in RETAIL, or want to take a break to play your favorite Xbox game, you will need to switch your sandbox back to RETAIL.</span></span>

<span data-ttu-id="3a5e9-135">これらのシナリオについて、以下で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-135">These scenarios will be described in more detail below.</span></span>  <span data-ttu-id="3a5e9-136">PC と本体で処理が一部異なるため、それぞれ個別のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-136">The process has some differences on PC and Console, so there are separate sections for each.</span></span>

## <a name="switch-your-pcs-development-sandbox"></a><span data-ttu-id="3a5e9-137">PC の開発サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="3a5e9-137">Switch your PC's development sandbox</span></span>

<span data-ttu-id="3a5e9-138">PC の開発サンドボックスを切り替える場合、推奨される方法は Windows Device Portal (WDP) を使用する方法です。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-138">If you want to switch your PC's development sandbox, the recommended way to do so is using Windows Device Portal (WDP).</span></span>  <span data-ttu-id="3a5e9-139">この操作をコマンド ラインで実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-139">You may also do so via the Command Line.</span></span>  <span data-ttu-id="3a5e9-140">両方の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-140">We will describe both ways.</span></span>

### <a name="windows-device-portal"></a><span data-ttu-id="3a5e9-141">Windows Device Portal</span><span class="sxs-lookup"><span data-stu-id="3a5e9-141">Windows Device Portal</span></span>

<span data-ttu-id="3a5e9-142">使用している PC で WDP を有効にしていない場合は、以下に示す手順に従って有効にしてください。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-142">If you have not already enabled WDP on your PC, please follow these instructions to do so.</span></span> [<span data-ttu-id="3a5e9-143">Windows デスクトップで Device Portal をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-143">Setup Device Portal on Windows Desktop</span></span>](https://msdn.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-desktop)

<span data-ttu-id="3a5e9-144">WDP を有効にしたら、上記の記事で説明したように Web ブラウザーで Windows Device Portal に接続してこのポータルを開きます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-144">Once you have done so, open Windows Dev Portal by connecting to it in your web browser as described in the above article.</span></span>

<span data-ttu-id="3a5e9-145">その後で、次に示すように [Xbox Live] をクリックして該当するセクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-145">Then you click on "Xbox Live" to go the appropriate section as shown below.</span></span>

![](../images/getting_started/wdp_switch_sandbox.png)

<span data-ttu-id="3a5e9-146">ここで、*「サンドボックスを調べる」*の手順で表示されたサンドボックスを入力し、[変更] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-146">Then you can enter your sandbox which you got via the steps in the *Finding Out Your Sandbox* and click "Change".</span></span>

<span data-ttu-id="3a5e9-147">RETAIL に戻るには、ここで「RETAIL」と入力します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-147">To switch back to RETAIL, you can enter RETAIL here.</span></span>

### <a name="command-line"></a><span data-ttu-id="3a5e9-148">コマンド ライン</span><span class="sxs-lookup"><span data-stu-id="3a5e9-148">Command Line</span></span>

<span data-ttu-id="3a5e9-149">[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) で Xbox Live ツール パッケージをダウンロードし、解凍します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-149">Download the Xbox Live Tools Package at [https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools) and unzip.</span></span>  <span data-ttu-id="3a5e9-150">ダウンロードしたファイルには、SwitchSandbox.cmd バッチ ファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-150">You will find a SwitchSandbox.cmd batch file within.</span></span>

<span data-ttu-id="3a5e9-151">サンドボックスを切り替えるには、管理者モードでこのバッチ ファイルを実行します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-151">Run this in Administrator mode to switch your sandbox.</span></span>  <span data-ttu-id="3a5e9-152">最初の引数がサンドボックスです。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-152">The first argument is the sandbox.</span></span>  <span data-ttu-id="3a5e9-153">たとえば、XDKS.1 サンドボックスに切り替える場合は、次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-153">For example if you are trying to switch to the XDKS.1 sandbox, you would do:</span></span>

```
SwitchSandbox.cmd XDKS.1
```

<span data-ttu-id="3a5e9-154">RETAIL に戻るには、2 番目の引数として RETAIL を指定するだけです。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-154">To switch back to RETAIL, you simply provide that as the second argument.</span></span>

```
SwitchSandbox.cmd RETAIL
```

## <a name="switch-your-xbox-one-console-development-sandbox"></a><span data-ttu-id="3a5e9-155">Xbox One 本体の開発サンドボックスを切り替える</span><span class="sxs-lookup"><span data-stu-id="3a5e9-155">Switch your Xbox One console development sandbox</span></span>

### <a name="using-windows-dev-portal"></a><span data-ttu-id="3a5e9-156">Windows Device Portal の使用</span><span class="sxs-lookup"><span data-stu-id="3a5e9-156">Using Windows Dev Portal</span></span>

<span data-ttu-id="3a5e9-157">Windows Device Portal を使用して、本体でサンドボックスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-157">You can use the Windows Dev Portal to change the sandbox on your console.</span></span>  <span data-ttu-id="3a5e9-158">これを行うには、使用している本体で [Dev Home] (デバイス ホーム) に移動して本体を有効にします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-158">To do this, go to "Dev Home" on your console and enable it.</span></span>

<span data-ttu-id="3a5e9-159">その後、PC の Web ブラウザーに IP アドレスを入力して、本体に接続できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-159">After that you can type in the IP address on the web browser on your PC to connect to your console.</span></span>  <span data-ttu-id="3a5e9-160">続いて [Xbox Live] をクリックし、そこにあるテキスト ボックスにサンドボックスを入力します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-160">You can then click on "Xbox Live" and enter the sandbox in the textbox there.</span></span>

### <a name="using-xbox-one-console-ui"></a><span data-ttu-id="3a5e9-161">Xbox One 本体の UI の使用</span><span class="sxs-lookup"><span data-stu-id="3a5e9-161">Using Xbox One console UI</span></span>

<span data-ttu-id="3a5e9-162">本体から直接、開発サンドボックスを変更する場合は、[設定] に移動します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-162">If you want to change your development sandbox right from your console, you can go to "Settings".</span></span>  <span data-ttu-id="3a5e9-163">続いて [開発者向け設定] に移動すると、サンドボックスを変更するオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-163">Then go to "Developer Settings" and you will see an option to change your sandbox.</span></span>

## <a name="sandbox-uses"></a><span data-ttu-id="3a5e9-164">サンドボックスの使用</span><span class="sxs-lookup"><span data-stu-id="3a5e9-164">Sandbox uses</span></span>

### <a name="data-that-is-sandboxed"></a><span data-ttu-id="3a5e9-165">サンドボックス化されるデータ</span><span class="sxs-lookup"><span data-stu-id="3a5e9-165">Data that is sandboxed</span></span>
<span data-ttu-id="3a5e9-166">サンドボックス機能を使用すると、開発プロセスで、チームに属する開発者間のアクセスを管理できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-166">You can use the sandbox features to manage access between developers on your team during the development process.</span></span>  <span data-ttu-id="3a5e9-167">たとえば、開発チームとテスト担当者の間でデータを分離できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-167">For example, you may want to isolate data between your development team and testers.</span></span>

<span data-ttu-id="3a5e9-168">サンドボックス化されるデータは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-168">Sandboxed data includes:</span></span>
- <span data-ttu-id="3a5e9-169">ユーザーの実績、ランキング、統計。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-169">Achievements, Leaderboards and Stats for a user.</span></span>  <span data-ttu-id="3a5e9-170">あるサンドボックス内で 1 人のユーザーに対して蓄積された実績は、別のサンドボックスには変換されません。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-170">Achievements accumulated for a user in one sandbox do not translate to another sandbox.</span></span>
- <span data-ttu-id="3a5e9-171">マルチプレイヤー、マッチメイキング。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-171">Multiplayer and Matchmaking.</span></span>  <span data-ttu-id="3a5e9-172">異なるサンドボックスに属するユーザーと一緒にマルチプレーヤー ゲームをプレイすることはできません。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-172">Users cannot play a multiplayer game with someone is a different sandbox.</span></span>
- <span data-ttu-id="3a5e9-173">サービス構成。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-173">Service configuration.</span></span>  <span data-ttu-id="3a5e9-174">あるサンドボックス内で新しい実績をタイトルに追加しても、異なるサンドボックス内では表示されません。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-174">If you add a new achievement to a title in one sandbox, it is not visible in a different sandbox.</span></span>  <span data-ttu-id="3a5e9-175">これは、すべてのサービス構成データに適用されます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-175">This applies to all service configuration data.</span></span>

<span data-ttu-id="3a5e9-176">サンドボックス化されないデータは、主にソーシャル情報です。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-176">Non-sandboxed data is predominantly social information.</span></span>  <span data-ttu-id="3a5e9-177">たとえば、ユーザーが別のユーザーをフォローする場合、その関係はサンドボックスに依存しません。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-177">So for example if a user follows another user, that relationship is sandbox agnostic.</span></span>

### <a name="examples"></a><span data-ttu-id="3a5e9-178">例</span><span class="sxs-lookup"><span data-stu-id="3a5e9-178">Examples</span></span>
<span data-ttu-id="3a5e9-179">以下に、複数のサンドボックスを使用する利点を理解するのに役立つ例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-179">Some examples will be provided below to help illustrate some of the benefits of why you might want to use multiple sandboxes.</span></span>

> <span data-ttu-id="3a5e9-180">**注**: Xbox クリエーターズ プログラムに参加している場合は、1 つのサンドボックスのみを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-180">**Note**: If you are in the Xbox Creators Program, you may only have one sandbox.</span></span>  <span data-ttu-id="3a5e9-181">複数のサンドボックスを作成する必要がある場合は、ID@Xbox プログラムにご登録ください。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-181">If you have need to create multiple sandboxes, please apply to the ID@Xbox program.</span></span>

#### <a name="service-config-isolation"></a><span data-ttu-id="3a5e9-182">サービス構成の分離</span><span class="sxs-lookup"><span data-stu-id="3a5e9-182">Service config isolation</span></span>
<span data-ttu-id="3a5e9-183">上で説明したように、サービス構成はサンドボックスに固有のものです。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-183">As mentioned above, service configuration is sandbox specific.</span></span>  <span data-ttu-id="3a5e9-184">そのため、たとえば*開発*サンドボックスと*テスト* サンドボックスを併用できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-184">So you might have a *Development* sandbox, and a *Testing* sandbox.</span></span>  <span data-ttu-id="3a5e9-185">タイトルのビルドをテスト担当者に提供する場合は、[サービス構成](../xbox-live-service-configuration.md)を*テスト* サンドボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-185">When you give a build of your title to your testers, you would publish your [service configuration](../xbox-live-service-configuration.md) to the *Testing* sandbox.</span></span>

<span data-ttu-id="3a5e9-186">その一方で、テスト担当者に対して表示されているサービス構成に影響を与えずに、実績や異なるマルチプレイヤー セッションの種類を*開発*サンドボックスに追加できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-186">Then in the meantime, you could add achievements, or different multiplayer session types to your *Development* sandbox without affecting the service configuration that your testers are seeing.</span></span>

#### <a name="multiplayer"></a><span data-ttu-id="3a5e9-187">マルチプレーヤー</span><span class="sxs-lookup"><span data-stu-id="3a5e9-187">Multiplayer</span></span>
<span data-ttu-id="3a5e9-188">上記の例のように、*開発*と*テスト*のサンドボックスを使用しているとします。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-188">Take the above example with a *Development* and *Testing* sandbox.</span></span>  <span data-ttu-id="3a5e9-189">サービス構成はどちらのサンドボックスも同じである可能性がありますが、開発者はマルチプレイヤー機能を作成しており、相互にマッチメイキングをテストしたいと考えています。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-189">Maybe your service configuration is the same between sandboxes, but your developers are creating multiplayer features and want to testing matchmaking with each other.</span></span>  <span data-ttu-id="3a5e9-190">テスト担当者もマルチプレイヤーをテストしています。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-190">Your testers are also testing multiplayer.</span></span>

<span data-ttu-id="3a5e9-191">このような場合、テスト担当者は個別に問題をデバッグしているため、開発者は Xbox Live マッチメイキング サービスでテスト担当者をマッチング対象にしたくないと考えている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-191">In a case like this, your developers might not want the Xbox Live Matchmaking service to match them with testers, because they are debugging issues separately.</span></span>  <span data-ttu-id="3a5e9-192">これを防止する効果的な方法として、開発者向けに*開発*サンドボックスを、テスト担当者向けに別個の*テスト* サンドボックスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-192">A good way to prevent this would be for your developers to be in the *Development* sandbox and testers to be in a separate *Testing* sandbox.</span></span>  <span data-ttu-id="3a5e9-193">これにより、両方のグループを分離します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-193">This keeps both groups isolated.</span></span>

## <a name="advanced"></a><span data-ttu-id="3a5e9-194">高度な設定</span><span class="sxs-lookup"><span data-stu-id="3a5e9-194">Advanced</span></span>

<span data-ttu-id="3a5e9-195">開発プロセスを簡素化するには、既定のサンドボックスで開発を始めて、新しいサンドボックスを慎重に追加します。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-195">To keep your development process simple, start off with your default sandbox and add new sandboxes judiciously.</span></span>

<span data-ttu-id="3a5e9-196">アクセス制御とデータ分離のニーズが高まっている場合は、「[高度な Xbox Live のサンドボックス](../advanced-xbox-live-sandboxes.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a5e9-196">Once you find your access control and data isolation needs growing, you can see [Advanced Xbox Live Sandboxes](../advanced-xbox-live-sandboxes.md) article.</span></span>  
