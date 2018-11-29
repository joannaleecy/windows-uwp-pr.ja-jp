---
title: UWP アプリの自動ビルドを設定する
description: サイドロード パッケージやストア パッケージを生成する自動ビルドを構成する方法について説明します。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, UWP
ms.assetid: f9b0d6bd-af12-4237-bc66-0c218859d2fd
ms.localizationpriority: medium
ms.openlocfilehash: 4208fd56b16d5130f218492428eb459364b8ada9
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8194219"
---
# <a name="set-up-automated-builds-for-your-uwp-app"></a><span data-ttu-id="3082d-104">UWP アプリの自動ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="3082d-104">Set up automated builds for your UWP app</span></span>

<span data-ttu-id="3082d-105">Visual Studio Team Services (VSTS) を使用して、UWP プロジェクトの自動ビルドを作成できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-105">You can use Visual Studio Team Services (VSTS) to create automated builds for UWP projects.</span></span>
<span data-ttu-id="3082d-106">この記事では、そのためのさまざまな方法について取り上げます。</span><span class="sxs-lookup"><span data-stu-id="3082d-106">In this article, we’ll look at different ways to do that.</span></span>  <span data-ttu-id="3082d-107">また、AppVeyor などの他のビルド システムと統合できるようにコマンド ラインを使用してこれらのタスクを実行する方法も示します。</span><span class="sxs-lookup"><span data-stu-id="3082d-107">We’ll also show you how to perform these tasks by using the command line so that you can integrate with other build systems such as AppVeyor.</span></span>

## <a name="select-the-right-type-of-build-agent"></a><span data-ttu-id="3082d-108">適切な種類のビルド エージェントを選択する</span><span class="sxs-lookup"><span data-stu-id="3082d-108">Select the right type of build agent</span></span>

<span data-ttu-id="3082d-109">ビルド プロセスの実行時に VSTS で使用するビルド エージェントの種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="3082d-109">Choose the type of build agent that you want VSTS to use when it executes the build process.</span></span>
<span data-ttu-id="3082d-110">ホスト ビルド エージェントは、最も一般的なツールや SDK と共に展開され、ほとんどのシナリオで動作します ([ホスト ビルド サーバー上のソフトウェアに関する記事](https://www.visualstudio.com/docs/build/admin/agents/hosted-pool#software)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="3082d-110">A hosted build agent is deployed with the most common tools and sdks, and it will work for most scenarios, see the [Software on the hosted build server](https://www.visualstudio.com/docs/build/admin/agents/hosted-pool#software) article.</span></span> <span data-ttu-id="3082d-111">ただし、ビルド ステップをより細かく制御する必要がある場合は、カスタム ビルド エージェントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-111">However, you can create a custom build agent if you need more control over the build steps.</span></span> <span data-ttu-id="3082d-112">次の表は、この意思決定を行うのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3082d-112">You can use the following table to help you make that decision.</span></span>

| **<span data-ttu-id="3082d-113">シナリオ</span><span class="sxs-lookup"><span data-stu-id="3082d-113">Scenario</span></span>** | **<span data-ttu-id="3082d-114">カスタム エージェント</span><span class="sxs-lookup"><span data-stu-id="3082d-114">Custom Agent</span></span>** | **<span data-ttu-id="3082d-115">ホスト ビルド エージェント</span><span class="sxs-lookup"><span data-stu-id="3082d-115">Hosted Build Agent</span></span>** |
|-------------|----------------|----------------------|
| <span data-ttu-id="3082d-116">基本的な UWP ビルド (.NET Native を含む)</span><span class="sxs-lookup"><span data-stu-id="3082d-116">Basic UWP build (including .NET native)</span></span>| <span data-ttu-id="3082d-117">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-117">:white_check_mark:</span></span> | <span data-ttu-id="3082d-118">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-118">:white_check_mark:</span></span> |
| <span data-ttu-id="3082d-119">サイドロード用パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="3082d-119">Generate packages for Sideloading</span></span>| <span data-ttu-id="3082d-120">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-120">:white_check_mark:</span></span> | <span data-ttu-id="3082d-121">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-121">:white_check_mark:</span></span> |
| <span data-ttu-id="3082d-122">ストア申請用パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="3082d-122">Generate packages for Store submission</span></span>| <span data-ttu-id="3082d-123">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-123">:white_check_mark:</span></span> | <span data-ttu-id="3082d-124">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-124">:white_check_mark:</span></span> |
| <span data-ttu-id="3082d-125">カスタム証明書を使用する</span><span class="sxs-lookup"><span data-stu-id="3082d-125">Use custom certificates</span></span>| <span data-ttu-id="3082d-126">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-126">:white_check_mark:</span></span> | |
| <span data-ttu-id="3082d-127">カスタム Windows SDK を対象としてビルドする</span><span class="sxs-lookup"><span data-stu-id="3082d-127">Build targeting a custom Windows SDK</span></span>| <span data-ttu-id="3082d-128">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-128">:white_check_mark:</span></span> |  |
| <span data-ttu-id="3082d-129">単体テストを実行する</span><span class="sxs-lookup"><span data-stu-id="3082d-129">Run unit tests</span></span>| <span data-ttu-id="3082d-130">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-130">:white_check_mark:</span></span> |  |
| <span data-ttu-id="3082d-131">段階的なビルドを使用する</span><span class="sxs-lookup"><span data-stu-id="3082d-131">Use incremental builds</span></span>| <span data-ttu-id="3082d-132">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="3082d-132">:white_check_mark:</span></span> |  |

#### <a name="create-a-custom-build-agent-optional"></a><span data-ttu-id="3082d-133">カスタム ビルド エージェントを作成する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="3082d-133">Create a custom build agent (optional)</span></span>

<span data-ttu-id="3082d-134">カスタム ビルド エージェントを作成する場合は、ユニバーサル Windows プラットフォームのツールが必要です。</span><span class="sxs-lookup"><span data-stu-id="3082d-134">If you choose to create a custom build agent, you’ll need the Universal Windows Platform tools.</span></span> <span data-ttu-id="3082d-135">これらのツールは、Visual Studio に含まれています。</span><span class="sxs-lookup"><span data-stu-id="3082d-135">These tools are part of Visual Studio.</span></span> <span data-ttu-id="3082d-136">Visual Studio の Community Edition を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-136">You can use the community edition of Visual Studio.</span></span>

<span data-ttu-id="3082d-137">詳しくは、[Windows でのエージェントの展開に関するページ](https://www.visualstudio.com/docs/build/admin/agents/v2-windows)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-137">To learn more, see [Deploy an agent on Windows](https://www.visualstudio.com/docs/build/admin/agents/v2-windows).</span></span>

<span data-ttu-id="3082d-138">UWP 単体テストを実行するには、以下の操作を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-138">To run UWP unit tests, you’ll have to do these things:</span></span>

- <span data-ttu-id="3082d-139">アプリを展開および起動する</span><span class="sxs-lookup"><span data-stu-id="3082d-139">Deploy and start your app</span></span>
- <span data-ttu-id="3082d-140">対話モードで VSTS エージェントを実行する</span><span class="sxs-lookup"><span data-stu-id="3082d-140">Run the VSTS agent in interactive mode</span></span>
- <span data-ttu-id="3082d-141">再起動後に自動ログオンするようにエージェントを構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-141">Configure your agent to auto-logon after a reboot</span></span>

## <a name="set-up-an-automated-build"></a><span data-ttu-id="3082d-142">自動ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="3082d-142">Set up an automated build</span></span>

<span data-ttu-id="3082d-143">まず、VSTS で利用可能な既定の UWP ビルドの定義について説明し、さらに高度なビルド タスクを実行できるようにその定義を構成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3082d-143">We’ll start with the default UWP build definition that’s available in VSTS and then show you how to configure that definition so that you can accomplish more advanced build tasks.</span></span>

**<span data-ttu-id="3082d-144">ソース コード リポジトリにプロジェクトの証明書を追加する</span><span class="sxs-lookup"><span data-stu-id="3082d-144">Add the certificate of your project to a source code repository</span></span>**

<span data-ttu-id="3082d-145">VSTS は、TFS および GIT ベースのコード リポジトリと連携します。</span><span class="sxs-lookup"><span data-stu-id="3082d-145">VSTS works with both TFS and GIT based code repositories.</span></span>
<span data-ttu-id="3082d-146">Git リポジトリを使用する場合は、ビルド エージェントがアプリ パッケージに署名できるように、リポジトリにプロジェクトの証明書ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="3082d-146">If you use a Git repository, add the certificate file of your project to the repository so that the build agent can sign the app package.</span></span> <span data-ttu-id="3082d-147">これを行わない場合、Git リポジトリは証明書ファイルを無視します。</span><span class="sxs-lookup"><span data-stu-id="3082d-147">If you don’t do this, the Git repository will ignore the certificate file.</span></span>
<span data-ttu-id="3082d-148">リポジトリに証明書ファイルを追加するには、ソリューション エクスプローラーで証明書ファイルを右クリックし、ショートカット メニューで [無視されたファイルをソース管理に追加] を選択します。</span><span class="sxs-lookup"><span data-stu-id="3082d-148">To add the certificate file to your repository, right-click the certificate file in Solution Explorer, and then in the shortcut menu, choose the Add Ignored File to Source Control command.</span></span>

![証明書を含める方法](images/building-screen1.png)

<span data-ttu-id="3082d-150">[高度な証明書の管理](#certificates-best-practices)については、このガイドで後述します。</span><span class="sxs-lookup"><span data-stu-id="3082d-150">We’ll discuss [advanced certificate management](#certificates-best-practices) later in this guide.</span></span>

<span data-ttu-id="3082d-151">VSTS で最初のビルド定義を作成するには、[ビルド] タブに移動し、[+] ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="3082d-151">To create your first build definition in VSTS, navigate to the Builds tab, and then select the + button.</span></span>

![ビルド定義を作成する](images/building-screen2.png)

<span data-ttu-id="3082d-153">ビルド定義テンプレートの一覧で、*[ユニバーサル Windows プラットフォーム]* テンプレートを選択します。</span><span class="sxs-lookup"><span data-stu-id="3082d-153">In the list of build definition templates, choose the *Universal Windows Platform* template.</span></span>

![UWP のビルドを選択する](images/building-screen3.png)

<span data-ttu-id="3082d-155">このビルド定義には、次のビルド タスクが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3082d-155">This build definition contains the following build tasks:</span></span>

- <span data-ttu-id="3082d-156">NuGet の復元 \*\*\*.sln</span><span class="sxs-lookup"><span data-stu-id="3082d-156">NuGet restore \*\*\*.sln</span></span>
- <span data-ttu-id="3082d-157">ソリューションのビルド \*\*\*.sln</span><span class="sxs-lookup"><span data-stu-id="3082d-157">Build solution \*\*\*.sln</span></span>
- <span data-ttu-id="3082d-158">シンボルの発行</span><span class="sxs-lookup"><span data-stu-id="3082d-158">Publish Symbols</span></span>
- <span data-ttu-id="3082d-159">成果物の公開: drop</span><span class="sxs-lookup"><span data-stu-id="3082d-159">Publish Artifact: drop</span></span>

#### <a name="configure-the-nuget-restore-build-task"></a><span data-ttu-id="3082d-160">NuGet の復元のビルド タスクを構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-160">Configure the NuGet restore build task</span></span>

<span data-ttu-id="3082d-161">このタスクでは、プロジェクトで定義されている NuGet パッケージを復元します。</span><span class="sxs-lookup"><span data-stu-id="3082d-161">This task restores the NuGet Packages that are defined in your project.</span></span> <span data-ttu-id="3082d-162">一部のパッケージには、NuGet.exe のカスタム バージョンが必要です。</span><span class="sxs-lookup"><span data-stu-id="3082d-162">Some packages require a custom version of NuGet.exe.</span></span> <span data-ttu-id="3082d-163">カスタム バージョンを必要とするパッケージを使っている場合、リポジトリでそのバージョンの NuGet.exe を参照し、詳細プロパティの *[NuGet.exe へのパス]* で指定します。</span><span class="sxs-lookup"><span data-stu-id="3082d-163">If you’re using a package that requires one, refer to that version NuGet.exe in your repo and then reference it in the *Path to NuGet.exe* advanced property.</span></span>

![既定のビルド定義](images/building-screen4.png)

#### <a name="configure-the-build-solution-build-task"></a><span data-ttu-id="3082d-165">ソリューションのビルドのビルド タスクを構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-165">Configure the Build solution build task</span></span>

<span data-ttu-id="3082d-166">このタスクは、バイナリに作業フォルダー内では出力アプリ パッケージ ファイルを生成したすべてのソリューションをコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="3082d-166">This task compiles any solution that’s in the working folder to binaries and produces the output app package file.</span></span>
<span data-ttu-id="3082d-167">このタスクでは、MSBuild の引数を使用します。</span><span class="sxs-lookup"><span data-stu-id="3082d-167">This task uses MSbuild arguments.</span></span>  <span data-ttu-id="3082d-168">これらの引数の値を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-168">You’ll have to specify the value of those arguments.</span></span> <span data-ttu-id="3082d-169">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="3082d-169">Use the following table as a guide.</span></span>

|**<span data-ttu-id="3082d-170">MSBuild の引数</span><span class="sxs-lookup"><span data-stu-id="3082d-170">MSBuild Argument</span></span>**|**<span data-ttu-id="3082d-171">値</span><span class="sxs-lookup"><span data-stu-id="3082d-171">Value</span></span>**|**<span data-ttu-id="3082d-172">説明</span><span class="sxs-lookup"><span data-stu-id="3082d-172">Description</span></span>**|
|--------------------|---------|---------------|
|<span data-ttu-id="3082d-173">AppxPackageDir</span><span class="sxs-lookup"><span data-stu-id="3082d-173">AppxPackageDir</span></span>|<span data-ttu-id="3082d-174">$(Build.ArtifactStagingDirectory)\AppxPackages</span><span class="sxs-lookup"><span data-stu-id="3082d-174">$(Build.ArtifactStagingDirectory)\AppxPackages</span></span>|<span data-ttu-id="3082d-175">生成された成果物を格納するフォルダーを定義します。</span><span class="sxs-lookup"><span data-stu-id="3082d-175">Defines the folder to store the generated artifacts.</span></span>|
|<span data-ttu-id="3082d-176">AppxBundlePlatforms</span><span class="sxs-lookup"><span data-stu-id="3082d-176">AppxBundlePlatforms</span></span>|<span data-ttu-id="3082d-177">$(Build.BuildPlatform)</span><span class="sxs-lookup"><span data-stu-id="3082d-177">$(Build.BuildPlatform)</span></span>|<span data-ttu-id="3082d-178">バンドルに含めるプラットフォームを定義できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-178">Allows you to define the platforms to include in the bundle.</span></span>|
|<span data-ttu-id="3082d-179">AppxBundle</span><span class="sxs-lookup"><span data-stu-id="3082d-179">AppxBundle</span></span>|<span data-ttu-id="3082d-180">Always</span><span class="sxs-lookup"><span data-stu-id="3082d-180">Always</span></span>|<span data-ttu-id="3082d-181">指定されているプラットフォームの appx ファイルを含む appxbundle を作成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-181">Creates an appxbundle with the appx files for the platform specified.</span></span>|
|**<span data-ttu-id="3082d-182">UapAppxPackageBuildMode</span><span class="sxs-lookup"><span data-stu-id="3082d-182">UapAppxPackageBuildMode</span></span>**|<span data-ttu-id="3082d-183">StoreUpload</span><span class="sxs-lookup"><span data-stu-id="3082d-183">StoreUpload</span></span>|<span data-ttu-id="3082d-184">生成するアプリ パッケージの種類を定義します。</span><span class="sxs-lookup"><span data-stu-id="3082d-184">Defines the kind of app package to generate.</span></span> <span data-ttu-id="3082d-185">(既定では含まれません)。</span><span class="sxs-lookup"><span data-stu-id="3082d-185">(Not included by default)</span></span>|

<span data-ttu-id="3082d-186">コマンド ラインを使って、つまり他のビルド システムを使って、ソリューションをビルドする場合は、次の引数を指定して msbuild を実行します。</span><span class="sxs-lookup"><span data-stu-id="3082d-186">If you want to build your solution by using the command line, or by using any other build system, run msbuild with these arguments.</span></span>

```ps
/p:AppxPackageDir="$(Build.ArtifactStagingDirectory)\AppxPackages\\"
/p:UapAppxPackageBuildMode=StoreUpload
/p:AppxBundlePlatforms="$(Build.BuildPlatform)"
/p:AppxBundle=Always
```

<span data-ttu-id="3082d-187">$() 構文で定義されたパラメーターは、ビルド定義で定義される変数で、他のビルド システムでは変更されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-187">The parameters defined with the $() syntax are variables defined in the build definition, and will change in other build systems.</span></span>

![既定の変数](images/building-screen5.png)

<span data-ttu-id="3082d-189">すべての定義済みの変数を表示するには、[ビルド変数の使用に関するページ](https://www.visualstudio.com/docs/build/define/variables)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-189">To view all predefined variables, see [Use build variables.](https://www.visualstudio.com/docs/build/define/variables)</span></span>

#### <a name="configure-the-publish-artifact-build-task"></a><span data-ttu-id="3082d-190">成果物の公開のビルド タスクを構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-190">Configure the Publish Artifact build task</span></span>

<span data-ttu-id="3082d-191">このタスクは、VSTS で生成される成果物を格納します。</span><span class="sxs-lookup"><span data-stu-id="3082d-191">This task stores the generated artifacts in VSTS.</span></span> <span data-ttu-id="3082d-192">成果物は、ビルド結果ページの [成果物] タブで確認できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-192">You can see them in the Artifacts tab of the build results page.</span></span>
<span data-ttu-id="3082d-193">VSTS は、以前に定義した `$(Build.ArtifactStagingDirectory)\AppxPackages` フォルダーを使用します。</span><span class="sxs-lookup"><span data-stu-id="3082d-193">VSTS uses the `$(Build.ArtifactStagingDirectory)\AppxPackages` folder that we previously defined.</span></span>

![成果物](images/building-screen6.png)

<span data-ttu-id="3082d-195">ここでは、`UapAppxPackageBuildMode` プロパティを `StoreUpload` に設定しているため、成果物フォルダーには、ストアへの提出に推奨されるパッケージ (.appxupload) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3082d-195">Because we’ve set the `UapAppxPackageBuildMode` property to `StoreUpload`, the artifacts folder includes the package that recommended for submission to the Store (.appxupload).</span></span> <span data-ttu-id="3082d-196">提出できることも通常のアプリ パッケージ (.appx/.msix) またはアプリ バンドル (.appxbundle/.msixbundle) ストアに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3082d-196">Note that you can also submit a regular app pacakge (.appx/.msix) or an app bundle (.appxbundle/.msixbundle) to the Store.</span></span> <span data-ttu-id="3082d-197">この資料の目的上、.appxupload ファイルを使います。</span><span class="sxs-lookup"><span data-stu-id="3082d-197">For the purposes of this article, we'll use the .appxupload file.</span></span>

>[!NOTE]
> <span data-ttu-id="3082d-198">既定では、VSTS エージェントによって、生成された最新のアプリ パッケージが維持されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-198">By default, the VSTS agent maintains the latest generated app packages.</span></span> <span data-ttu-id="3082d-199">現在のビルドの成果物のみを格納する場合は、バイナリ ディレクトリをクリーンアップするようにビルドを構成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-199">If you want to store only the artifacts of the current build, configure the build to clean the binaries directory.</span></span> <span data-ttu-id="3082d-200">そのためには、`Build.Clean` という名前の変数を追加し、その変数の値を `all` に設定します。</span><span class="sxs-lookup"><span data-stu-id="3082d-200">To do that, add a variable named `Build.Clean` and then set it to the value `all`.</span></span> <span data-ttu-id="3082d-201">詳しくは、[リポジトリの指定に関するページ](https://www.visualstudio.com/docs/build/define/repository#how-can-i-clean-the-repository-in-a-different-way)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-201">To learn more, see [Specify the repository](https://www.visualstudio.com/docs/build/define/repository#how-can-i-clean-the-repository-in-a-different-way).</span></span>

#### <a name="the-types-of-automated-builds"></a><span data-ttu-id="3082d-202">自動ビルドの種類</span><span class="sxs-lookup"><span data-stu-id="3082d-202">The types of automated builds</span></span>

<span data-ttu-id="3082d-203">次に、ビルド定義を使って自動ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-203">Next, you’ll use your build definition to create an automated build.</span></span> <span data-ttu-id="3082d-204">次の表では、作成できる自動ビルドの各種類について説明します。</span><span class="sxs-lookup"><span data-stu-id="3082d-204">The following table describes each type of automated build that you can create.</span></span>

|**<span data-ttu-id="3082d-205">ビルドの種類</span><span class="sxs-lookup"><span data-stu-id="3082d-205">Type of Build</span></span>**|**<span data-ttu-id="3082d-206">成果物</span><span class="sxs-lookup"><span data-stu-id="3082d-206">Artifact</span></span>**|**<span data-ttu-id="3082d-207">推奨される頻度</span><span class="sxs-lookup"><span data-stu-id="3082d-207">Recommended Frequency</span></span>**|**<span data-ttu-id="3082d-208">説明</span><span class="sxs-lookup"><span data-stu-id="3082d-208">Description</span></span>**|
|-----------------|------------|-------------------------|---------------|
|<span data-ttu-id="3082d-209">継続的インテグレーション</span><span class="sxs-lookup"><span data-stu-id="3082d-209">Continuous Integration</span></span>|<span data-ttu-id="3082d-210">ビルド ログ、テスト結果</span><span class="sxs-lookup"><span data-stu-id="3082d-210">Build Log, Test Results</span></span>|<span data-ttu-id="3082d-211">コミットごと</span><span class="sxs-lookup"><span data-stu-id="3082d-211">Each commit</span></span>|<span data-ttu-id="3082d-212">この種類のビルドは高速で、1 日に数回実行されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-212">This type of build is fast and run several times a day.</span></span>|
|<span data-ttu-id="3082d-213">サイドロード用の継続的配置ビルド</span><span class="sxs-lookup"><span data-stu-id="3082d-213">Continuous Deployment build for sideloading</span></span>|<span data-ttu-id="3082d-214">配置パッケージ</span><span class="sxs-lookup"><span data-stu-id="3082d-214">Deployment Packages</span></span>|<span data-ttu-id="3082d-215">毎日</span><span class="sxs-lookup"><span data-stu-id="3082d-215">Daily</span></span> |<span data-ttu-id="3082d-216">この種類のビルドは、単体テストを含めることができますが、少し長くかかります。</span><span class="sxs-lookup"><span data-stu-id="3082d-216">This type of build can Include unit tests but it takes a bit longer.</span></span> <span data-ttu-id="3082d-217">これにより、手動でテストでき、HockeyApp などの他のツールと統合できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-217">It allows manual testing and you can integrate it with other tools such as HockeyApp.</span></span>|
|<span data-ttu-id="3082d-218">ストアにパッケージを提出する継続的配置ビルド</span><span class="sxs-lookup"><span data-stu-id="3082d-218">Continuous Deployment build that submits a package to the Store</span></span>|<span data-ttu-id="3082d-219">公開パッケージ</span><span class="sxs-lookup"><span data-stu-id="3082d-219">Publishing Packages</span></span>|<span data-ttu-id="3082d-220">オンデマンド</span><span class="sxs-lookup"><span data-stu-id="3082d-220">On demand</span></span>|<span data-ttu-id="3082d-221">この種類のビルドでは、ストアに公開できるパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-221">This type of build creates a package that you can publish to the Store.</span></span>|

<span data-ttu-id="3082d-222">1 つずつを構成する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="3082d-222">Let’s look at how to configure each one.</span></span>

## <a name="set-up-a-continuous-integration-ci-build"></a><span data-ttu-id="3082d-223">継続的インテグレーション (CI) ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="3082d-223">Set up a Continuous Integration (CI) build</span></span>

<span data-ttu-id="3082d-224">この種類のビルドは、すばやくコードに関連する問題を診断するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="3082d-224">This type of a build helps you to diagnose code related problems quickly.</span></span> <span data-ttu-id="3082d-225">通常、1 つのプラットフォーム用にのみ実行され、.NETネイティブ ツール チェーンで処理する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3082d-225">They’re typically executed for only one platform, and they don’t need to be processed by the .NET native toolchain.</span></span> <span data-ttu-id="3082d-226">また、CI ビルドを使って、テスト結果のレポートを生成する単体テストを実行できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-226">Also, with CI builds, you can run unit tests that produce a test results report.</span></span>

<span data-ttu-id="3082d-227">CI ビルドの一環として UWP 単体テストを実行する場合、ホスト ビルド エージェントではなく、カスタム ビルド エージェントを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-227">If you want to run UWP unit tests as part of your CI build you’ll need to use a custom build agent instead of the hosted build agent.</span></span>

>[!NOTE]
> <span data-ttu-id="3082d-228">複数のアプリを同じソリューションにバンドルすると、エラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-228">If you bundle more than one app in the same solution, you might receive an error.</span></span> <span data-ttu-id="3082d-229">このようなエラーを解決する方法については、「[複数のアプリを同じソリューションにバンドルした場合に表示されるエラーを解決する](#bundle-errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-229">See the following topic for help resolving that error: [Address errors that appear when you bundle more than one app in the same solution.](#bundle-errors)</span></span>

### <a name="configure-a-ci-build-definition"></a><span data-ttu-id="3082d-230">CI ビルド定義を構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-230">Configure a CI build definition</span></span>

<span data-ttu-id="3082d-231">既定の UWP テンプレートを使用して、ビルド定義を作成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-231">Use the default UWP template to create a build definition.</span></span> <span data-ttu-id="3082d-232">次に、チェックインごとに実行するトリガーを構成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-232">Then, configure the Trigger to execute on each check in.</span></span>

![CI トリガー](images/building-screen7.png)

<span data-ttu-id="3082d-234">CI ビルドはユーザーに対して展開されないため、CD ビルドとの混同を避けるために、異なるバージョン番号によって管理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3082d-234">Because the CI build won’t be deployed to users, it’s a good idea to maintain different versioning numbers to avoid confusion with the CD builds.</span></span> <span data-ttu-id="3082d-235">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="3082d-235">For example:</span></span>
`$(BuildDefinitionName)_0.0.$(DayOfYear)$(Rev:.r)`

#### <a name="configure-a-custom-build-agent-for-unit-testing"></a><span data-ttu-id="3082d-236">単体テスト用のカスタム ビルド エージェントを構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-236">Configure a custom build agent for unit testing</span></span>

1. <span data-ttu-id="3082d-237">お使いの PC で開発者モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="3082d-237">Enable Developer Mode on your PC.</span></span> <span data-ttu-id="3082d-238">詳しくは、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-238">See [Enable your device for development](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development) for more information.</span></span>
2. <span data-ttu-id="3082d-239">サービスを対話型プロセスとして実行できるように設定します。</span><span class="sxs-lookup"><span data-stu-id="3082d-239">Enable the service to run as an interactive process.</span></span> <span data-ttu-id="3082d-240">詳しくは、[Windows でのエージェントの展開に関するページ](https://docs.microsoft.com/vsts/build-release/actions/agents/v2-windows)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-240">To learn more, see [Deploy an agent on Windows](https://docs.microsoft.com/vsts/build-release/actions/agents/v2-windows).</span></span>
3. <span data-ttu-id="3082d-241">エージェントに署名証明書を展開します。</span><span class="sxs-lookup"><span data-stu-id="3082d-241">Deploy the signing certificate to the agent.</span></span>

<span data-ttu-id="3082d-242">署名証明書を展開するには、`.cer` ファイルをダブルクリックし、**[ローカル コンピューター]** を選択して、**信頼されたユーザーのストア**を選択します。</span><span class="sxs-lookup"><span data-stu-id="3082d-242">To deploy a signing certificate, double-click the `.cer` file, choose **Local Machine**, and then choose **Trusted People Store**.</span></span>

<span id="uwp-unit-tests" />

### <a name="configure-the-build-definition-to-run-uwp-unit-tests"></a><span data-ttu-id="3082d-243">UWP 単体テストを実行するようにビルド定義を構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-243">Configure the build definition to run UWP Unit Tests</span></span>

<span data-ttu-id="3082d-244">単体テストを実行するには、Visual Studio テスト ビルド ステップを使用します。</span><span class="sxs-lookup"><span data-stu-id="3082d-244">To execute a unit test, use the Visual Studio Test build step.</span></span>

![単体テストを追加する](images/building-screen8.png)

<span data-ttu-id="3082d-246">UWP 単体テストは特定の appxrecipe ファイルのコンテキストで実行されるため、生成されたバンドルを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="3082d-246">UWP unit tests are executed in the context of a given appxrecipe file so you can’t use the generated bundle.</span></span> <span data-ttu-id="3082d-247">また、具体的なプラットフォームの appxrecipe ファイルへのパスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-247">Also, you’ll have to specify the path to a concrete platform appxrecipe file.</span></span> <span data-ttu-id="3082d-248">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="3082d-248">For example:</span></span>

```ps
$(Build.ArtifactStagingDirectory)\AppxPackages\MyUWPApp.UnitTest\x86\MyUWPApp.UnitTest_$(AppxVersion)_x86.appxrecipe
```

<span data-ttu-id="3082d-249">テストを実行するには、コンソール パラメーターを vstest.console.exe に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-249">In order for the tests to run a console parameter will have to be added to vstest.console.exe.</span></span> <span data-ttu-id="3082d-250">このパラメーターは、**[実行オプション] => [Other console options] (その他のコンソール オプション)** から指定できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-250">This parameter can be provide through: **Execution Options => Other console options**.</span></span> <span data-ttu-id="3082d-251">次のパラメーターを追加してください。</span><span class="sxs-lookup"><span data-stu-id="3082d-251">Please add following parameter:</span></span>

```ps
/framework:FrameworkUap10
```

>[!NOTE]
> <span data-ttu-id="3082d-252">コマンド ラインからローカルに単体テストを実行するには、次のコマンドを使います。</span><span class="sxs-lookup"><span data-stu-id="3082d-252">Use the following command to execute the unit tests locally from the command line:</span></span>
`"%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"`

#### <a name="access-test-results"></a><span data-ttu-id="3082d-253">テスト結果にアクセスする</span><span class="sxs-lookup"><span data-stu-id="3082d-253">Access test results</span></span>

<span data-ttu-id="3082d-254">VSTS では、ビルドの概要ページに、単体テストを実行する各ビルドのテスト結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-254">In VSTS, the build summary page shows the test results for each build that executes unit tests.</span></span> <span data-ttu-id="3082d-255">そこから、**[テスト結果]** ページを開いてテスト結果の詳細を確認できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-255">From there, you can open the **Test Results** page to see more detail about the test results.</span></span>

![テスト結果](images/building-screen9.png)

#### <a name="improve-the-speed-of-a-ci-build"></a><span data-ttu-id="3082d-257">CI ビルドの速度を向上させる</span><span class="sxs-lookup"><span data-stu-id="3082d-257">Improve the speed of a CI build</span></span>

<span data-ttu-id="3082d-258">チェックインの品質を監視する目的にのみ CI ビルドを使用する場合は、ビルド時間を短縮できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-258">If you want to use your CI build only to monitor the quality of your check-ins, you can reduce your build times.</span></span>

#### <a name="to-improve-the-speed-of-a-ci-build"></a><span data-ttu-id="3082d-259">CI ビルドの速度を向上させるには</span><span class="sxs-lookup"><span data-stu-id="3082d-259">To improve the speed of a CI build</span></span>

1. <span data-ttu-id="3082d-260">1 つのプラットフォーム向けにのみビルドします。</span><span class="sxs-lookup"><span data-stu-id="3082d-260">Build for only one platform.</span></span>
2. <span data-ttu-id="3082d-261">BuildPlatform 変数を編集して、x86 のみを使用します。</span><span class="sxs-lookup"><span data-stu-id="3082d-261">Edit the BuildPlatform variable to use only x86.</span></span> ![CI を構成する](images/building-screen10.png)
3. <span data-ttu-id="3082d-263">ビルド ステップで、[MSBuild 引数] プロパティに「/p:AppxBundle=Never」を追加し、[プラットフォーム] プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3082d-263">In the build step, add /p:AppxBundle=Never to the MSBuild Arguments property, and then set the Platform property.</span></span> ![プラットフォームを構成する](images/building-screen11.png)
4. <span data-ttu-id="3082d-265">単体テスト プロジェクトで、.NET Native を無効にします。</span><span class="sxs-lookup"><span data-stu-id="3082d-265">In the unit test project, disable .NET Native.</span></span>

<span data-ttu-id="3082d-266">そのためには、プロジェクト ファイルを開き、プロジェクトのプロパティで、`UseDotNetNativeToolchain` プロパティを `false` に設定します。</span><span class="sxs-lookup"><span data-stu-id="3082d-266">To do that, open the project file, and in the project properties, set the `UseDotNetNativeToolchain` property to `false`.</span></span>

<span data-ttu-id="3082d-267">.NET Native ツール チェーンはワークフローの重要な部分であるため、リリース ビルドをテストするにはこのツール チェーンを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-267">Using the .NET native tool chain is an important part of the workflow and should still be used to test release builds.</span></span>

<span id="bundle-errors" />

#### <a name="address-errors-that-appear-when-you-bundle-more-than-one-app-in-the-same-solution"></a><span data-ttu-id="3082d-268">複数のアプリを同じソリューションにバンドルした場合に表示されるエラーを解決する</span><span class="sxs-lookup"><span data-stu-id="3082d-268">Address errors that appear when you bundle more than one app in the same solution</span></span>

<span data-ttu-id="3082d-269">ソリューションに複数の UWP プロジェクトを追加し、バンドルを作成しようとすると、次のようなエラーが表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-269">If you add more than one UWP project to your solution, and then try to create a bundle, you might receive an error like this one:</span></span>

```ps
MakeAppx(0,0): Error : Error info: error 80080204: The package with file name "AppOne.UnitTests_0.1.2595.0_x86.appx" and package full name "8ef641d1-4557-4e33-957f-6895b122f1e6_0.1.2595.0_x86__scrj5wvaadcy6" is not valid in the bundle because it has a different package family name than other packages in the bundle
```

<span data-ttu-id="3082d-270">このエラーが表示されるのは、ソリューション レベルで、バンドルに含めるアプリが明確ではないためです。</span><span class="sxs-lookup"><span data-stu-id="3082d-270">This error appears because at the solution level, it’s not clear which app should appear in the bundle.</span></span>
<span data-ttu-id="3082d-271">この問題を解決するには、各プロジェクト ファイルを開き、最初の `<PropertyGroup>` 要素の最後に以下のプロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="3082d-271">To resolve this issue, open each project file and add the following properties at the end of the first `<PropertyGroup>` element:</span></span>

|**<span data-ttu-id="3082d-272">プロジェクト</span><span class="sxs-lookup"><span data-stu-id="3082d-272">Project</span></span>**|**<span data-ttu-id="3082d-273">プロパティ</span><span class="sxs-lookup"><span data-stu-id="3082d-273">Properties</span></span>**|
|-------|----------|
|<span data-ttu-id="3082d-274">App</span><span class="sxs-lookup"><span data-stu-id="3082d-274">App</span></span>|`<AppxBundle>Always</AppxBundle>`|
|<span data-ttu-id="3082d-275">UnitTests</span><span class="sxs-lookup"><span data-stu-id="3082d-275">UnitTests</span></span>|`<AppxBundle>Never</AppxBundle>`|

<span data-ttu-id="3082d-276">その後、ビルド ステップから MSBuild の `AppxBundle` 引数を削除します。</span><span class="sxs-lookup"><span data-stu-id="3082d-276">Then, remove the `AppxBundle` msbuild argument from the build step.</span></span>

## <a name="set-up-a-continuous-deployment-build-for-sideloading"></a><span data-ttu-id="3082d-277">サイドロード用の継続的配置ビルドの設定</span><span class="sxs-lookup"><span data-stu-id="3082d-277">Set up a continuous deployment build for sideloading</span></span>

<span data-ttu-id="3082d-278">この種類のビルドが完了したら、ユーザーは、ビルド結果ページの [成果物] セクションから、アプリ バンドル ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="3082d-278">When this type of build completes, users can download the app bundle file from the artifacts section of the build results page.</span></span>
<span data-ttu-id="3082d-279">より完全な配布を作成することでアプリのベータ テストを行う場合は、HockeyApp サービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-279">If you want to beta test the app by creating a more complete distribution, you can use the HockeyApp service.</span></span> <span data-ttu-id="3082d-280">このサービスは、ベータ テスト、ユーザー分析、クラッシュ診断用の高度な機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="3082d-280">This service offers advanced capabilities for beta testing, user analytics and crash diagnostics.</span></span>

### <a name="applying-version-numbers-to-your-builds"></a><span data-ttu-id="3082d-281">ビルドにバージョン番号を適用する</span><span class="sxs-lookup"><span data-stu-id="3082d-281">Applying version numbers to your builds</span></span>

<span data-ttu-id="3082d-282">マニフェスト ファイルには、アプリのバージョン番号が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3082d-282">The manifest file contains the app version number.</span></span>  <span data-ttu-id="3082d-283">バージョン番号を変更するには、ソース コントロール リポジトリ内のマニフェスト ファイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="3082d-283">Update the manifest file in your source control repository to change the version number.</span></span>
<span data-ttu-id="3082d-284">アプリのバージョン番号を更新するもう 1 つの方法は、VSTS によって生成されるビルド番号を使用し、アプリをコンパイルする直前にアプリ マニフェストを変更する方法です。</span><span class="sxs-lookup"><span data-stu-id="3082d-284">Another way to update the version number of your app is to use the build number that is generated by VSTS, and then modify the app manifest just before you compile the app.</span></span> <span data-ttu-id="3082d-285">ソース コード リポジトリにはこれらの変更をコミットしないでください。</span><span class="sxs-lookup"><span data-stu-id="3082d-285">Just don’t commit those changes to the source code repository.</span></span>

<span data-ttu-id="3082d-286">ビルド定義でバージョン管理ビルド番号の形式を定義し、コンパイルする前に、結果のバージョン番号を使用して AppxManifest ファイルと、必要に応じて AssemblyInfo.cs ファイルを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-286">You’ll have to define your versioning build number format in the build definition, and then use the resulting version number to update the AppxManifest and optionally, the AssemblyInfo.cs files, before you compile.</span></span>

<span data-ttu-id="3082d-287">ビルド定義の *[全般]* タブで、ビルド番号の形式を定義します。</span><span class="sxs-lookup"><span data-stu-id="3082d-287">Define the build number format in the *General* tab of your build definition.</span></span>

![ビルドのバージョン](images/building-screen12.png)

<span data-ttu-id="3082d-289">たとえば、ビルド番号の形式を次のように設定したとします。</span><span class="sxs-lookup"><span data-stu-id="3082d-289">For example, if you set the build number format to the following value:</span></span>

```ps
$(BuildDefinitionName)_1.1.$(DayOfYear)$(Rev:r).0
```

<span data-ttu-id="3082d-290">VSTS では次のようなバージョン番号が生成されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-290">VSTS generates a version number like:</span></span>

```ps
CI_MyUWPApp_1.1.2501.0
```

>[!NOTE]
><span data-ttu-id="3082d-291">Microsoft Store では、バージョンの最後の数字は 0 である必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-291">The Store will require that the last number in the version to be 0.</span></span>

<span data-ttu-id="3082d-292">バージョン番号を抽出し、マニフェストや `AssemblyInfo` ファイルに適用できるようにするには、カスタム PowerShell スクリプト ([ここ](https://go.microsoft.com/fwlink/?prd=12560&pver=14&plcid=0x409&clcid=0x9&ar=DevCenter&sar=docs)で入手可能) を使用します。</span><span class="sxs-lookup"><span data-stu-id="3082d-292">So that you can extract the version number and apply it to the manifest and/or `AssemblyInfo` files, use a custom PowerShell script (available [here](https://go.microsoft.com/fwlink/?prd=12560&pver=14&plcid=0x409&clcid=0x9&ar=DevCenter&sar=docs)).</span></span> <span data-ttu-id="3082d-293">このスクリプトは、環境変数 `BUILD_BUILDNUMBER` からバージョン番号を読み取り、AssemblyInfo ファイルと AppxManifest ファイルを変更します。</span><span class="sxs-lookup"><span data-stu-id="3082d-293">That script reads the version number from the environment variable `BUILD_BUILDNUMBER`, and then modifies the AssemblyInfo and AppxManifest files.</span></span> <span data-ttu-id="3082d-294">ソース リポジトリにこのスクリプトを追加したことを確認し、次のように PowerShell のビルド タスクを構成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-294">Make sure to add this script to your source repository, and then configure a PowerShell build task as shown here:</span></span>

![バージョンの更新](images/building-screen13.png)

<span data-ttu-id="3082d-296">`$(AppxVersion)` 変数にバージョン番号が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3082d-296">The `$(AppxVersion)` variable contains the version number.</span></span> <span data-ttu-id="3082d-297">この番号を他のビルド ステップで使用できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-297">You can use that number in other build steps.</span></span>

#### <a name="optional-integrate-with-hockeyapp"></a><span data-ttu-id="3082d-298">省略可能: HockeyApp と統合する</span><span class="sxs-lookup"><span data-stu-id="3082d-298">Optional: Integrate with HockeyApp</span></span>

<span data-ttu-id="3082d-299">まず、Visual Studio 拡張機能 [HockeyApp](https://marketplace.visualstudio.com/items?itemName=ms.hockeyapp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="3082d-299">First, install the [HockeyApp](https://marketplace.visualstudio.com/items?itemName=ms.hockeyapp) Visual Studio extension.</span></span> <span data-ttu-id="3082d-300">VSTS 管理者としてこの拡張機能をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-300">You will need to install this extension as a VSTS administrator.</span></span>

![HockeyApp](images/building-screen14.png)

<span data-ttu-id="3082d-302">次に、HockeyApp の接続を構成します。手順については、[Visual Studio Team Services (VSTS) や Team Foundation Server (TFS) で HockeyApp を使用する方法に関するページ](https://support.hockeyapp.net/kb/third-party-bug-trackers-services-and-webhooks/how-to-use-hockeyapp-with-visual-studio-team-services-vsts-or-team-foundation-server-tfs)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-302">Next, configure the HockeyApp connection by using this guide: [How to use HockeyApp with Visual Studio Team Services (VSTS) or Team Foundation Server (TFS).](https://support.hockeyapp.net/kb/third-party-bug-trackers-services-and-webhooks/how-to-use-hockeyapp-with-visual-studio-team-services-vsts-or-team-foundation-server-tfs)</span></span>
<span data-ttu-id="3082d-303">HockeyApp アカウントを設定するには、Microsoft アカウント、ソーシャル メディア アカウント、または電子メール アドレスのみを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-303">You can use your Microsoft account, social media account or just an email address to set up your HockeyApp account.</span></span> <span data-ttu-id="3082d-304">無料プランには、2 つのアプリ、1 人の所有者が含まれ、データ制限はありません。</span><span class="sxs-lookup"><span data-stu-id="3082d-304">The free plan comes with two apps, one owner, and no data restrictions.</span></span>

<span data-ttu-id="3082d-305">次に、手動で、または既存のアプリ パッケージ ファイルをアップロードすることで、HockeyApp アプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-305">Then, you can create a HockeyApp app manually, or by uploading an existing app package file.</span></span> <span data-ttu-id="3082d-306">詳しくは、[新しいアプリを作成する方法に関するページ](https://support.hockeyapp.net/kb/app-management-2/how-to-create-a-new-app)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-306">To learn more, see [How to create a new app](https://support.hockeyapp.net/kb/app-management-2/how-to-create-a-new-app).</span></span>

<span data-ttu-id="3082d-307">既存のアプリ パッケージ ファイルを使用して、ビルド ステップを追加し、ビルド ステップのバイナリ ファイルのパスのパラメーターを設定します。</span><span class="sxs-lookup"><span data-stu-id="3082d-307">To use an existing app package file, add a build step, and set the Binary File Path parameter of the build step.</span></span>

![HockeyApp を構成する](images/building-screen15.png)

<span data-ttu-id="3082d-309">このパラメーターを設定するには、次の例のように、アプリ名、AppxVersion 変数、サポートされているプラットフォームを組み合わせて 1 つの文字列にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-309">To set this parameter, combine the app name, the AppxVersion variable and the supported platforms together into one string such as this one:</span></span>

```ps
$(Build.ArtifactStagingDirectory)\AppxPackages\MyUWPApp_$(AppxVersion)_Test\MyUWPApp_$(AppxVersion)_x86_x64_ARM.appxbundle
```

<span data-ttu-id="3082d-310">HockeyApp タスクには、シンボル ファイルへのパスを指定することができますが、お、バンドルと共にシンボルを含めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3082d-310">Although the HockeyApp task allows you to specify the path to the symbols file, it’s a best practice to include the symbols with the bundle.</span></span>

## <a name="set-up-a-continuous-deployment-build-that-submits-a-package-to-the-store"></a><span data-ttu-id="3082d-311">Microsoft Store にパッケージを提出する継続的配置ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="3082d-311">Set up a continuous deployment build that submits a package to the Store</span></span>

<span data-ttu-id="3082d-312">ストア提出パッケージを生成するには、Visual Studio のストア関連付けウィザードを使用してストアにアプリを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="3082d-312">To generate Store submission packages, associate your app with the Store by using the Store Association Wizard in Visual Studio.</span></span>

![Microsoft Store に関連付ける](images/building-screen16.png)

<span data-ttu-id="3082d-314">このウィザードでは、Microsoft Store の関連付けの情報が含まれる Package.StoreAssociation.xml という名前のファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-314">The Store Association Wizard generates a file named Package.StoreAssociation.xml that contains the Store association information.</span></span> <span data-ttu-id="3082d-315">GitHub などのパブリック リポジトリでソース コードを保存する場合、このファイルには、そのアカウントのすべてのアプリの予約名が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3082d-315">If you store your source code in a public repository such as GitHub, this file will contain all the app reserved names for that account.</span></span> <span data-ttu-id="3082d-316">公開する前に、このファイルを除外または削除することができます。</span><span class="sxs-lookup"><span data-stu-id="3082d-316">You can exclude or delete this file before making it public.</span></span>

<span data-ttu-id="3082d-317">アプリを公開するために使用したパートナー センター アカウントへのアクセスをお持ちでない場合、このドキュメントで手順に従ってできます:[サード パーティ製のアプリを構築するかどうか。ストア アプリをパッケージ化する方法](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/#e35YzR5aRG6uaBqK.97)します。</span><span class="sxs-lookup"><span data-stu-id="3082d-317">If you don’t have access to the Partner Center account that was used to publish the app, you can follow the instructions in this document: [Building an app for a 3rd party? How to package their Store app](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/#e35YzR5aRG6uaBqK.97).</span></span>

<span data-ttu-id="3082d-318">次に、ビルド ステップに次のパラメーターが含まれていることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-318">Then you need to verify that the build step includes the following parameter:</span></span>

```ps
/p:UapAppxPackageBuildMode=StoreUpload
```

<span data-ttu-id="3082d-319">これにより、ストアに提出できるファイルのアップロードが生成されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-319">This will generate an upload file that can be submitted to the Store.</span></span>

#### <a name="configure-automatic-store-submission"></a><span data-ttu-id="3082d-320">Microsoft Store への自動提出を構成する</span><span class="sxs-lookup"><span data-stu-id="3082d-320">Configure automatic Store submission</span></span>

<span data-ttu-id="3082d-321">Visual Studio Team Services の Microsoft Store 用の拡張機能を使用して Microsoft Store API と統合し、アプリ パッケージを Microsoft Store に送信します。</span><span class="sxs-lookup"><span data-stu-id="3082d-321">Use the Visual Studio Team Services extension for the Microsoft Store to integrate with the Store API, and send your app package to the Store.</span></span>

<span data-ttu-id="3082d-322">Azure Active Directory (AD)、パートナー センターのアカウントを接続し、要求を認証する広告にアプリを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-322">You need to connect your Partner Center account with Azure Active Directory (AD), and then create an app in your AD to authenticate the requests.</span></span> <span data-ttu-id="3082d-323">これを実行するには、拡張機能のページのガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="3082d-323">You can follow the guidance in the extension page to accomplish that.</span></span>

<span data-ttu-id="3082d-324">拡張機能を構成した後は、ビルド タスクを追加し、アプリの ID と、アップロード ファイルの場所を使用して構成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-324">Once you’ve configured the extension, you can add the build task, and configure it with your app ID and the location of the upload file.</span></span>

![パートナー センターを構成します。](images/building-screen17.png)

<span data-ttu-id="3082d-326">`Package File` パラメーターの値は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="3082d-326">Where the value of the `Package File` parameter will be:</span></span>

```ps
$(Build.ArtifactStagingDirectory)\
AppxPackages\MyUWPApp__$(AppxVersion)_x86_x64_ARM_bundle.appxupload
```

<span data-ttu-id="3082d-327">このビルドは手動でアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-327">You have to manually activate this build.</span></span> <span data-ttu-id="3082d-328">これを使用して既存のアプリを更新することはできますが、Microsoft Store への最初の提出に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="3082d-328">You can use it to update existing apps but you can’t use it to for your first submission to the Store.</span></span> <span data-ttu-id="3082d-329">詳しくは、「[Microsoft Store サービスを使用した申請の作成と管理](https://msdn.microsoft.com/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-329">For more information, see [Create and manage Store submissions by using Microsoft Store Services.](https://msdn.microsoft.com/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)</span></span>

## <a name="best-practices"></a><span data-ttu-id="3082d-330">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="3082d-330">Best Practices</span></span>

<span id="sideloading-best-practices"/>

### <a name="best-practices-for-sideloading-apps"></a><span data-ttu-id="3082d-331">アプリのサイドロードのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="3082d-331">Best Practices for Sideloading apps</span></span>

<span data-ttu-id="3082d-332">ストアに公開せずに、アプリを配布する場合は、直接デバイスにアプリをサイドロードできます。ただし、それらのデバイスは、アプリ パッケージの署名に使用された証明書を信頼している必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-332">If you want to distribute your app without publishing it to the Store, you can sideload your app directly to devices as long as those devices trust the certificate that was used to sign the app package.</span></span>

<span data-ttu-id="3082d-333">`Add-AppDevPackage.ps1` PowerShell スクリプトを使用してアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="3082d-333">Use the `Add-AppDevPackage.ps1` PowerShell script to install apps.</span></span> <span data-ttu-id="3082d-334">このスクリプトは、証明書を追加して、ローカル コンピューターの信頼されたルート証明セクションにをインストールするか、アプリ パッケージ ファイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="3082d-334">This script will add the certificate to the Trusted Root Certification section for the local machine, and will then install or update the app package file.</span></span>

#### <a name="sideloading-your-app-with-the-windows-10-anniversary-update"></a><span data-ttu-id="3082d-335">Windows 10 Anniversary Update でのアプリのサイドロード</span><span class="sxs-lookup"><span data-stu-id="3082d-335">Sideloading your app with the Windows 10 Anniversary Update</span></span>

<span data-ttu-id="3082d-336">Windows 10 Anniversary update では、アプリ パッケージ ファイルをダブルクリックし、ダイアログ ボックスで [インストール] ボタンを選択してアプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="3082d-336">In the Windows 10 Anniversary Update, you can double-click the app package file and install your app by choosing the Install button in a dialog box.</span></span>

![rs1 でのサイドロード](images/building-screen18.png)

>[!NOTE]
> <span data-ttu-id="3082d-338">この方法では、証明書や関連付けられている依存関係はインストールされません。</span><span class="sxs-lookup"><span data-stu-id="3082d-338">This method doesn’t install the certificate or the associated dependencies.</span></span>

<span data-ttu-id="3082d-339">VSTS や HockeyApp などの web サイトから Windows アプリ パッケージを配布する場合は、そのサイトをブラウザーで信頼済みサイトの一覧に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-339">If you want to distribute your Windows app packages from a website such as VSTS or HockeyApp, you’ll need to add that site to the list of trusted sites in your browser.</span></span> <span data-ttu-id="3082d-340">そうしないと、Windows は、ファイルがロックされているものとしてマークします。</span><span class="sxs-lookup"><span data-stu-id="3082d-340">Otherwise, Windows marks the file as locked.</span></span>

<span id="certificates-best-practices"/>

### <a name="best-practices-for-signing-certificates"></a><span data-ttu-id="3082d-341">署名証明書のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="3082d-341">Best Practices for Signing Certificates</span></span>

<span data-ttu-id="3082d-342">Visual Studio では、各プロジェクト用の証明書が生成されます。</span><span class="sxs-lookup"><span data-stu-id="3082d-342">Visual Studio generates a certificate for each project.</span></span> <span data-ttu-id="3082d-343">これにより、有効な証明書の整理された一覧を維持することは困難です。</span><span class="sxs-lookup"><span data-stu-id="3082d-343">This makes it difficult to maintain a curated list of valid certificates.</span></span> <span data-ttu-id="3082d-344">複数のアプリを作成することを計画している場合は、すべてのアプリに署名するための単一の証明書を作成できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-344">If you plan to create several apps, you can create a single certificate to sign all of your apps.</span></span> <span data-ttu-id="3082d-345">その後、その証明書を信頼している各デバイスでは、別の証明書をインストールしなくても、アプリをサイドロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="3082d-345">Then, each device that trusts your certificate will be able to sideload any of your apps without installing another certificate.</span></span> <span data-ttu-id="3082d-346">詳しくは、「[パッケージ署名用の証明書を作成する](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3082d-346">To learn more, see [Create a certificate for package signing](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing).</span></span>

#### <a name="create-a-signing-certificate"></a><span data-ttu-id="3082d-347">署名証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="3082d-347">Create a Signing Certificate</span></span>

<span data-ttu-id="3082d-348">証明書を作成するには、[MakeCert.exe](https://msdn.microsoft.com/library/windows/desktop/ff548309.aspx) ツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="3082d-348">Use the [MakeCert.exe](https://msdn.microsoft.com/library/windows/desktop/ff548309.aspx) tool to create a certificate.</span></span>

<span data-ttu-id="3082d-349">次の例では、MakeCert.exe ツールを使って証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="3082d-349">The following example creates a certificate by using the MakeCert.exe tool.</span></span>

```ps
MakeCert /n publisherName /r /h 0 /eku "1.3.6.1.5.5.7.3.3,1.3.6.1.4.1.311.10.3.13" /e expirationDate /sv MyKey.pvk MyKey.cer
```

<span data-ttu-id="3082d-350">次に、Pvk2Pfx ツールを使用して、パスワードで保護されている秘密キーを含む PFX ファイルを生成できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-350">Then you can use Pvk2Pfx tool to generate a PFX file that contains the private key protected with a password.</span></span>

<span data-ttu-id="3082d-351">コンピューターの役割ごとに次の証明書を提供します。</span><span class="sxs-lookup"><span data-stu-id="3082d-351">Provide these certificates to each machine role:</span></span>

|**<span data-ttu-id="3082d-352">コンピューター</span><span class="sxs-lookup"><span data-stu-id="3082d-352">Machine</span></span>**|**<span data-ttu-id="3082d-353">用途</span><span class="sxs-lookup"><span data-stu-id="3082d-353">Usage</span></span>**|**<span data-ttu-id="3082d-354">証明書</span><span class="sxs-lookup"><span data-stu-id="3082d-354">Certificate</span></span>**|**<span data-ttu-id="3082d-355">証明書ストア</span><span class="sxs-lookup"><span data-stu-id="3082d-355">Certificate Store</span></span>**|
|-----------|---------|---------------|---------------------|
|<span data-ttu-id="3082d-356">開発者/ビルド コンピューター</span><span class="sxs-lookup"><span data-stu-id="3082d-356">Developer/Build Machine</span></span>|<span data-ttu-id="3082d-357">ビルドの署名</span><span class="sxs-lookup"><span data-stu-id="3082d-357">Sign Builds</span></span>|<span data-ttu-id="3082d-358">MyCert.PFX</span><span class="sxs-lookup"><span data-stu-id="3082d-358">MyCert.PFX</span></span>|<span data-ttu-id="3082d-359">現在のユーザー/個人</span><span class="sxs-lookup"><span data-stu-id="3082d-359">Current User/Personal</span></span>|
|<span data-ttu-id="3082d-360">開発者/ビルド コンピューター</span><span class="sxs-lookup"><span data-stu-id="3082d-360">Developer/Build Machine</span></span>|<span data-ttu-id="3082d-361">実行</span><span class="sxs-lookup"><span data-stu-id="3082d-361">Run</span></span>|<span data-ttu-id="3082d-362">MyCert.cer</span><span class="sxs-lookup"><span data-stu-id="3082d-362">MyCert.cer</span></span>|<span data-ttu-id="3082d-363">ローカル コンピューター/信頼されたユーザー</span><span class="sxs-lookup"><span data-stu-id="3082d-363">Local Machine/Trusted People</span></span>|
|<span data-ttu-id="3082d-364">ユーザー</span><span class="sxs-lookup"><span data-stu-id="3082d-364">User</span></span>|<span data-ttu-id="3082d-365">実行</span><span class="sxs-lookup"><span data-stu-id="3082d-365">Run</span></span>|<span data-ttu-id="3082d-366">MyCert.cer</span><span class="sxs-lookup"><span data-stu-id="3082d-366">MyCert.cer</span></span>|<span data-ttu-id="3082d-367">ローカル コンピューター/信頼されたユーザー</span><span class="sxs-lookup"><span data-stu-id="3082d-367">Local Machine/Trusted People</span></span>|

><span data-ttu-id="3082d-368">注: ユーザーによって信頼済みのエンタープライズ証明書を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="3082d-368">Note: You can also use an enterprise certificate that is already trusted by your users.</span></span>

#### <a name="sign-your-uwp-app"></a><span data-ttu-id="3082d-369">UWP アプリに署名する</span><span class="sxs-lookup"><span data-stu-id="3082d-369">Sign your UWP app</span></span>

<span data-ttu-id="3082d-370">Visual Studio と MSBuild は、アプリの署名に使う証明書を管理するためのさまざまなオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="3082d-370">Visual Studio and MSBuild offers different options to manage the certificate that you use to sign the app:</span></span>

<span data-ttu-id="3082d-371">そのオプションの 1 つは、ソリューションに証明書と共に秘密キー (通常、.PFX ファイルの形式) を含めて、プロジェクト ファイルで pfx を参照することです。</span><span class="sxs-lookup"><span data-stu-id="3082d-371">One option is to include the certificate with the private key (normally in the form of a .PFX file) in your solution, and then reference the pfx in the project file.</span></span> <span data-ttu-id="3082d-372">マニフェスト エディターの [パッケージ] タブを使ってこれを管理できます。</span><span class="sxs-lookup"><span data-stu-id="3082d-372">You can manage this by using the Package tab of the manifest editor.</span></span>

![証明書を作成する](images/building-screen19.png)

<span data-ttu-id="3082d-374">もう 1 つのオプションは、ビルド コンピューター (現在のユーザー/個人) に証明書をインストールし、[証明書ストアから選択] オプションを使用することです。</span><span class="sxs-lookup"><span data-stu-id="3082d-374">Another option is to install the certificate onto the build machine (Current User/Personal), and then use the Pick from Certificate store option.</span></span> <span data-ttu-id="3082d-375">これによって、プロジェクト ファイル内で証明書の拇印が指定されるため、プロジェクトのビルドに使用されるすべてのコンピューターに証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-375">This specifies the Thumbprint of the certificate in the project file so that the certificate should be installed in all the machines that will be used to build the project.</span></span>

#### <a name="trust-the-signing-certificate-in-the-target-devices"></a><span data-ttu-id="3082d-376">ターゲット デバイスで署名証明書を信頼する</span><span class="sxs-lookup"><span data-stu-id="3082d-376">Trust the signing certificate in the target devices</span></span>

<span data-ttu-id="3082d-377">ターゲット デバイスでは、アプリをインストールする前に、証明書を信頼する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3082d-377">A target device has to trust the certificate before the app can be installed on it.</span></span>

<span data-ttu-id="3082d-378">ローカル コンピューターの証明書ストアの信頼されたユーザーまたは信頼のルートの場所に証明書の公開キーを登録します。</span><span class="sxs-lookup"><span data-stu-id="3082d-378">Register the public key of the certificate in the Trusted People or Trust Root location in the Local Machine certificate store.</span></span>

<span data-ttu-id="3082d-379">証明書を登録する最もすばやい方法は、.cer ファイルをダブルクリックし、ウィザードの手順に従って、**ローカル コンピューター**の**信頼されたユーザー** ストアに証明書を保存することです。</span><span class="sxs-lookup"><span data-stu-id="3082d-379">The quickest way to register the certificate is to double-click in the .cer file, and then follow the steps in the wizard to save the certificate in the **Local Machine** and **Trusted People** store.</span></span>

## <a name="related-topics"></a><span data-ttu-id="3082d-380">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3082d-380">Related Topics</span></span>

- [<span data-ttu-id="3082d-381">Windows 用の .NETアプリを構築する</span><span class="sxs-lookup"><span data-stu-id="3082d-381">Build your .NET app for Windows</span></span>](https://www.visualstudio.com/docs/build/get-started/dot-net)
- [<span data-ttu-id="3082d-382">UWP アプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="3082d-382">Packaging UWP apps</span></span>](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)
- [<span data-ttu-id="3082d-383">Windows 10 での LOB アプリのサイドローディング</span><span class="sxs-lookup"><span data-stu-id="3082d-383">Sideload LOB apps in Windows 10</span></span>](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)
- [<span data-ttu-id="3082d-384">パッケージ署名用の証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="3082d-384">Create a certificate for package signing</span></span>](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)
