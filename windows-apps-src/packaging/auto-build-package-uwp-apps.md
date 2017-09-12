---
author: laurenhughes
title: "UWP アプリの自動ビルドを設定する"
description: "サイドロード パッケージやストア パッケージを生成する自動ビルドを構成する方法について説明します。"
ms.author: lahugh
ms.date: 08/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.assetid: f9b0d6bd-af12-4237-bc66-0c218859d2fd
ms.openlocfilehash: c8c1765e2983484ddc57e47a995867aa3b401ad4
ms.sourcegitcommit: 63c815f8c6665872987b5410cabf324f2b7e3c7c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/10/2017
---
# <a name="set-up-automated-builds-for-your-uwp-app"></a><span data-ttu-id="2f96f-104">UWP アプリの自動ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="2f96f-104">Set up automated builds for your UWP app</span></span>

<span data-ttu-id="2f96f-105">Visual Studio Team Services (VSTS) を使用して、UWP プロジェクトの自動ビルドを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-105">You can use Visual Studio Team Services (VSTS) to create automated builds for UWP projects.</span></span> <span data-ttu-id="2f96f-106">この記事では、そのためのさまざまな方法について取り上げます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-106">In this article, we’ll look at different ways to do that.</span></span>  <span data-ttu-id="2f96f-107">また、AppVeyor などの他のビルド システムと統合できるようにコマンド ラインを使用してこれらのタスクを実行する方法も示します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-107">We’ll also show you how to perform these tasks by using the command line so that you can integrate with other build systems such as AppVeyor.</span></span> 

## <a name="select-the-right-type-of-build-agent"></a><span data-ttu-id="2f96f-108">適切な種類のビルド エージェントを選択する</span><span class="sxs-lookup"><span data-stu-id="2f96f-108">Select the right type of build agent</span></span>

<span data-ttu-id="2f96f-109">ビルド プロセスの実行時に VSTS で使用するビルド エージェントの種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-109">Choose the type of build agent that you want VSTS to use when it executes the build process.</span></span> <span data-ttu-id="2f96f-110">ホスト ビルド エージェントは、最も一般的なツールや SDK と共に展開され、ほとんどのシナリオで動作します ([ホスト ビルド サーバー上のソフトウェアに関する記事](https://www.visualstudio.com/docs/build/admin/agents/hosted-pool#software)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="2f96f-110">A hosted build agent is deployed with the most common tools and sdks, and it will work for most scenarios, see the [Software on the hosted build server](https://www.visualstudio.com/docs/build/admin/agents/hosted-pool#software) article.</span></span> <span data-ttu-id="2f96f-111">ただし、ビルド ステップをより細かく制御する必要がある場合は、カスタム ビルド エージェントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-111">However, you can create a custom build agent if you need more control over the build steps.</span></span> <span data-ttu-id="2f96f-112">次の表は、この意思決定を行うのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-112">You can use the following table to help you make that decision.</span></span>

|**<span data-ttu-id="2f96f-113">シナリオ</span><span class="sxs-lookup"><span data-stu-id="2f96f-113">Scenario</span></span>**|**<span data-ttu-id="2f96f-114">カスタム エージェント</span><span class="sxs-lookup"><span data-stu-id="2f96f-114">Custom Agent</span></span>**|**<span data-ttu-id="2f96f-115">ホスト ビルド エージェント</span><span class="sxs-lookup"><span data-stu-id="2f96f-115">Hosted Build Agent</span></span>**|
-------------|----------------|----------------------|
|<span data-ttu-id="2f96f-116">基本的な UWP ビルド (.NET Native を含む)</span><span class="sxs-lookup"><span data-stu-id="2f96f-116">Basic UWP build (including .NET native)</span></span>|<span data-ttu-id="2f96f-117">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-117">:white_check_mark:</span></span>|<span data-ttu-id="2f96f-118">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-118">:white_check_mark:</span></span>|
|<span data-ttu-id="2f96f-119">サイドロード用パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-119">Generate packages for Sideloading</span></span>|<span data-ttu-id="2f96f-120">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-120">:white_check_mark:</span></span>|<span data-ttu-id="2f96f-121">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-121">:white_check_mark:</span></span>|
|<span data-ttu-id="2f96f-122">ストア申請用パッケージを生成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-122">Generate packages for Store submission</span></span>|<span data-ttu-id="2f96f-123">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-123">:white_check_mark:</span></span>|<span data-ttu-id="2f96f-124">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-124">:white_check_mark:</span></span>|
|<span data-ttu-id="2f96f-125">カスタム証明書を使用する</span><span class="sxs-lookup"><span data-stu-id="2f96f-125">Use custom certificates</span></span>|<span data-ttu-id="2f96f-126">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-126">:white_check_mark:</span></span>||
|<span data-ttu-id="2f96f-127">カスタム Windows SDK を対象としてビルドする</span><span class="sxs-lookup"><span data-stu-id="2f96f-127">Build targeting a custom Windows SDK</span></span>|<span data-ttu-id="2f96f-128">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-128">:white_check_mark:</span></span>||
|<span data-ttu-id="2f96f-129">単体テストを実行する</span><span class="sxs-lookup"><span data-stu-id="2f96f-129">Run unit tests</span></span>|<span data-ttu-id="2f96f-130">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-130">:white_check_mark:</span></span>||
|<span data-ttu-id="2f96f-131">段階的なビルドを使用する</span><span class="sxs-lookup"><span data-stu-id="2f96f-131">Use incremental builds</span></span>|<span data-ttu-id="2f96f-132">:white_check_mark:</span><span class="sxs-lookup"><span data-stu-id="2f96f-132">:white_check_mark:</span></span>||

><span data-ttu-id="2f96f-133">注: Windows Anniversary Update SDK (ビルド14393) を対象とする場合、ホスト ビルド プールは SDK 10586 および 10240 のみをサポートするため、カスタム ビルド エージェントを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-133">Note: If you plan to target the Windows Anniversary Update SDK (Build 14393) you will need to set up your custom build agent, since the hosted build pool only supports SDK 10586 and 10240.</span></span> <span data-ttu-id="2f96f-134">詳しくは、「[UWP バージョンの選択](https://msdn.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-134">More information to [choose a UWP version](https://msdn.microsoft.com/windows/uwp/updates-and-versions/choose-a-uwp-version)</span></span>

#### <a name="create-a-custom-build-agent-optional"></a><span data-ttu-id="2f96f-135">カスタム ビルド エージェントを作成する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="2f96f-135">Create a custom build agent (optional)</span></span>

<span data-ttu-id="2f96f-136">カスタム ビルド エージェントを作成する場合は、ユニバーサル Windows プラットフォームのツールが必要です。</span><span class="sxs-lookup"><span data-stu-id="2f96f-136">If you choose to create a custom build agent, you’ll need the Universal Windows Platform tools.</span></span> <span data-ttu-id="2f96f-137">これらのツールは、Visual Studio に含まれています。</span><span class="sxs-lookup"><span data-stu-id="2f96f-137">These tools are part of Visual Studio.</span></span> <span data-ttu-id="2f96f-138">Visual Studio の Community Edition を使用できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-138">You can use the community edition of Visual Studio.</span></span>

<span data-ttu-id="2f96f-139">詳しくは、[Windows でのエージェントの展開に関するページ](https://www.visualstudio.com/docs/build/admin/agents/v2-windows)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-139">To learn more, see [Deploy an agent on Windows.](https://www.visualstudio.com/docs/build/admin/agents/v2-windows)</span></span> 

<span data-ttu-id="2f96f-140">UWP 単体テストを実行するには、以下の操作を実行する必要があります。 •   アプリを展開して起動します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-140">To run UWP unit tests, you’ll have to do these things: •   Deploy and start your app.</span></span> <span data-ttu-id="2f96f-141">•   対話モードで VSTS エージェントを実行します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-141">•   Run the VSTS agent in interactive mode.</span></span> <span data-ttu-id="2f96f-142">•   再起動後に自動ログオンするようにエージェントを構成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-142">•   Configure your agent to auto-logon after a reboot.</span></span>

<span data-ttu-id="2f96f-143">次に、自動ビルドを設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-143">Now we’ll talk about how to set up an automated build.</span></span>

## <a name="set-up-an-automated-build"></a><span data-ttu-id="2f96f-144">自動ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="2f96f-144">Set up an automated build</span></span>
<span data-ttu-id="2f96f-145">まず、VSTS で利用可能な既定の UWP ビルドの定義について説明し、さらに高度なビルド タスクを実行できるようにその定義を構成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-145">We’ll start with the default UWP build definition that’s available in VSTS and then show you how to configure that definition so that you can accomplish more advanced build tasks.</span></span>

**<span data-ttu-id="2f96f-146">ソース コード リポジトリにプロジェクトの証明書を追加する</span><span class="sxs-lookup"><span data-stu-id="2f96f-146">Add the certificate of your project to a source code repository</span></span>**

<span data-ttu-id="2f96f-147">VSTS は、TFS および GIT ベースのコード リポジトリと連携します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-147">VSTS works with both TFS and GIT based code repositories.</span></span>  
<span data-ttu-id="2f96f-148">Git リポジトリを使用する場合は、ビルド エージェントが appx パッケージに署名できるように、リポジトリにプロジェクトの証明書ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-148">If you use a Git repository, add the certificate file of your project to the repository so that the build agent can sign the appx package.</span></span> <span data-ttu-id="2f96f-149">これを行わない場合、Git リポジトリは証明書ファイルを無視します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-149">If you don’t do this, the Git repository will ignore the certificate file.</span></span> <span data-ttu-id="2f96f-150">リポジトリに証明書ファイルを追加するには、ソリューション エクスプローラーで証明書ファイルを右クリックし、ショートカット メニューで [無視されたファイルをソース管理に追加] を選択します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-150">To add the certificate file to your repository, right-click the certificate file in Solution Explorer, and then in the shortcut menu, choose the Add Ignored File to Source Control command.</span></span> 

![証明書を含める方法](images/building-screen1.png)

<span data-ttu-id="2f96f-152">[高度な証明書の管理](#certificates-best-practices)については、このガイドで後述します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-152">We’ll discuss [advanced certificate management](#certificates-best-practices) later in this guide.</span></span> 

<span data-ttu-id="2f96f-153">VSTS で最初のビルド定義を作成するには、[ビルド] タブに移動し、[+] ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-153">To create your first build definition in VSTS, navigate to the Builds tab, and then select the + button.</span></span>

![ビルド定義を作成する](images/building-screen2.png)

<span data-ttu-id="2f96f-155">ビルド定義テンプレートの一覧で、*[ユニバーサル Windows プラットフォーム]* テンプレートを選択します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-155">In the list of build definition templates, choose the *Universal Windows Platform* template.</span></span>

![UWP のビルドを選択する](images/building-screen3.png)

<span data-ttu-id="2f96f-157">このビルド定義には、次のビルド タスクが含まれています。</span><span class="sxs-lookup"><span data-stu-id="2f96f-157">This build definition contains the following build tasks:</span></span>

- <span data-ttu-id="2f96f-158">NuGet の復元 **\*.sln</span><span class="sxs-lookup"><span data-stu-id="2f96f-158">NuGet restore **\*.sln</span></span>
- <span data-ttu-id="2f96f-159">ソリューションのビルド **\*.sln</span><span class="sxs-lookup"><span data-stu-id="2f96f-159">Build solution **\*.sln</span></span>
- <span data-ttu-id="2f96f-160">シンボルの発行</span><span class="sxs-lookup"><span data-stu-id="2f96f-160">Publish Symbols</span></span>
- <span data-ttu-id="2f96f-161">成果物の公開: drop</span><span class="sxs-lookup"><span data-stu-id="2f96f-161">Publish Artifact: drop</span></span>

#### <a name="configure-the-nuget-restore-build-task"></a><span data-ttu-id="2f96f-162">NuGet の復元のビルド タスクを構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-162">Configure the NuGet restore build task</span></span>

<span data-ttu-id="2f96f-163">このタスクでは、プロジェクトで定義されている NuGet パッケージを復元します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-163">This task restores the NuGet Packages that are defined in your project.</span></span> <span data-ttu-id="2f96f-164">一部のパッケージには、NuGet.exe のカスタム バージョンが必要です。</span><span class="sxs-lookup"><span data-stu-id="2f96f-164">Some packages require a custom version of NuGet.exe.</span></span> <span data-ttu-id="2f96f-165">カスタム バージョンを必要とするパッケージを使っている場合、リポジトリでそのバージョンの NuGet.exe を参照し、詳細プロパティの *[NuGet.exe へのパス]* で指定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-165">If you’re using a package that requires one, refer to that version NuGet.exe in your repo and then reference it in the *Path to NuGet.exe* advanced property.</span></span>

![既定のビルド定義](images/building-screen4.png)

#### <a name="configure-the-build-solution-build-task"></a><span data-ttu-id="2f96f-167">ソリューションのビルドのビルド タスクを構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-167">Configure the Build solution build task</span></span>

<span data-ttu-id="2f96f-168">このタスクは、作業フォルダーにあるすべてのソリューションをバイナリにコンパイルし、出力 AppX ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-168">This task compiles any solution that’s in the working folder to binaries and produces the output AppX file.</span></span> <span data-ttu-id="2f96f-169">このタスクでは、MSBuild の引数を使用します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-169">This task uses MSbuild arguments.</span></span>  <span data-ttu-id="2f96f-170">これらの引数の値を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-170">You’ll have to specify the value of those arguments.</span></span> <span data-ttu-id="2f96f-171">次の表をガイドとして使用してください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-171">Use the following table as a guide.</span></span> 

|**<span data-ttu-id="2f96f-172">MSBuild の引数</span><span class="sxs-lookup"><span data-stu-id="2f96f-172">MSBuild Argument</span></span>**|**<span data-ttu-id="2f96f-173">値</span><span class="sxs-lookup"><span data-stu-id="2f96f-173">Value</span></span>**|**<span data-ttu-id="2f96f-174">説明</span><span class="sxs-lookup"><span data-stu-id="2f96f-174">Description</span></span>**|
|--------------------|---------|---------------|
|<span data-ttu-id="2f96f-175">AppxPackageDir</span><span class="sxs-lookup"><span data-stu-id="2f96f-175">AppxPackageDir</span></span>|<span data-ttu-id="2f96f-176">$(Build.ArtifactStagingDirectory)\AppxPackages</span><span class="sxs-lookup"><span data-stu-id="2f96f-176">$(Build.ArtifactStagingDirectory)\AppxPackages</span></span>|<span data-ttu-id="2f96f-177">生成された成果物を格納するフォルダーを定義します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-177">Defines the folder to store the generated artifacts.</span></span>|
|<span data-ttu-id="2f96f-178">AppxBundlePlatforms</span><span class="sxs-lookup"><span data-stu-id="2f96f-178">AppxBundlePlatforms</span></span>|<span data-ttu-id="2f96f-179">$(Build.BuildPlatform)</span><span class="sxs-lookup"><span data-stu-id="2f96f-179">$(Build.BuildPlatform)</span></span>|<span data-ttu-id="2f96f-180">バンドルに含めるプラットフォームを定義できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-180">Allows you to define the platforms to include in the bundle.</span></span>|
|<span data-ttu-id="2f96f-181">AppxBundle</span><span class="sxs-lookup"><span data-stu-id="2f96f-181">AppxBundle</span></span>|<span data-ttu-id="2f96f-182">Always</span><span class="sxs-lookup"><span data-stu-id="2f96f-182">Always</span></span>|<span data-ttu-id="2f96f-183">指定されているプラットフォームの appx ファイルを含む appxbundle を作成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-183">Creates an appxbundle with the appx files for the platform specified.</span></span>|
|**<span data-ttu-id="2f96f-184">UapAppxPackageBuildMode</span><span class="sxs-lookup"><span data-stu-id="2f96f-184">UapAppxPackageBuildMode</span></span>**|<span data-ttu-id="2f96f-185">StoreUpload</span><span class="sxs-lookup"><span data-stu-id="2f96f-185">StoreUpload</span></span>|<span data-ttu-id="2f96f-186">生成する appx パッケージの種類を定義します </span><span class="sxs-lookup"><span data-stu-id="2f96f-186">Defines the kind of appx package to generate.</span></span> <span data-ttu-id="2f96f-187">(既定では含まれません)。</span><span class="sxs-lookup"><span data-stu-id="2f96f-187">(Not included by default)</span></span>|


<span data-ttu-id="2f96f-188">コマンド ラインを使って、つまり他のビルド システムを使って、ソリューションをビルドする場合は、次の引数を指定して msbuild を実行します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-188">If you want to build your solution by using the command line, or by using any other build system, run msbuild with these arguments.</span></span>

```
/p:AppxPackageDir="$(Build.ArtifactStagingDirectory)\AppxPackages\\"  
/p:UapAppxPackageBuildMode=StoreUpload 
/p:AppxBundlePlatforms="$(Build.BuildPlatform)"
/p:AppxBundle=Always
```

<span data-ttu-id="2f96f-189">$() 構文で定義されたパラメーターは、ビルド定義で定義される変数で、他のビルド システムでは変更されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-189">The parameters defined with the $() syntax are variables defined in the build definition, and will change in other build systems.</span></span>

![既定の変数](images/building-screen5.png)

<span data-ttu-id="2f96f-191">すべての定義済みの変数を表示するには、[ビルド変数の使用に関するページ](https://www.visualstudio.com/docs/build/define/variables)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-191">To view all predefined variables, see [Use build variables.](https://www.visualstudio.com/docs/build/define/variables)</span></span>

#### <a name="configure-the-publish-artifact-build-task"></a><span data-ttu-id="2f96f-192">成果物の公開のビルド タスクを構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-192">Configure the Publish Artifact build task</span></span> 
<span data-ttu-id="2f96f-193">このタスクは、VSTS で生成される成果物を格納します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-193">This task stores the generated artifacts in VSTS.</span></span> <span data-ttu-id="2f96f-194">成果物は、ビルド結果ページの [成果物] タブで確認できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-194">You can see them in the Artifacts tab of the build results page.</span></span> <span data-ttu-id="2f96f-195">VSTS は、以前に定義した `$(Build.ArtifactStagingDirectory)\AppxPackages` フォルダーを使用します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-195">VSTS uses the `$(Build.ArtifactStagingDirectory)\AppxPackages` folder that we previously defined.</span></span>

![成果物](images/building-screen6.png)

<span data-ttu-id="2f96f-197">ここでは、`UapAppxPackageBuildMode` プロパティを `StoreUpload` に設定しているため、成果物フォルダーには、ストアへの提出に推奨されるパッケージ (.appxupload) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-197">Because we’ve set the `UapAppxPackageBuildMode` property to `StoreUpload`, the artifacts folder includes the package that recommended for submission to the Store (.appxupload).</span></span> <span data-ttu-id="2f96f-198">また、通常のアプリ パッケージ (.appx) や アプリ バンドル (.appxbundle) もストアに提出できることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-198">Note that you can also submit a regular app pacakge (.appx) or an app bundle (.appxbundle) to the Store.</span></span> <span data-ttu-id="2f96f-199">この資料の目的上、.appxupload ファイルを使います。</span><span class="sxs-lookup"><span data-stu-id="2f96f-199">For the purposes of this article, we'll use the .appxupload file.</span></span>


><span data-ttu-id="2f96f-200">注: 既定では、VSTS エージェントによって、生成された最新の appx が維持されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-200">Note: By default, the VSTS agent maintains the latest appx generated packages.</span></span> <span data-ttu-id="2f96f-201">現在のビルドの成果物のみを格納する場合は、バイナリ ディレクトリをクリーンアップするようにビルドを構成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-201">If you want to store only the artifacts of the current build, configure the build to clean the binaries directory.</span></span> <span data-ttu-id="2f96f-202">そのためには、`Build.Clean` という名前の変数を追加し、その変数の値を `all` に設定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-202">To do that, add a variable named `Build.Clean` and then set it to the value `all`.</span></span> <span data-ttu-id="2f96f-203">詳しくは、[リポジトリの指定に関するページ](https://www.visualstudio.com/docs/build/define/repository#how-can-i-clean-the-repository-in-a-different-way)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-203">To learn more, see [Specify the repository.](https://www.visualstudio.com/docs/build/define/repository#how-can-i-clean-the-repository-in-a-different-way)</span></span>

#### <a name="the-types-of-automated-builds"></a><span data-ttu-id="2f96f-204">自動ビルドの種類</span><span class="sxs-lookup"><span data-stu-id="2f96f-204">The types of automated builds</span></span>
<span data-ttu-id="2f96f-205">次に、ビルド定義を使って自動ビルドを作成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-205">Next, you’ll use your build definition to create an automated build.</span></span> <span data-ttu-id="2f96f-206">次の表では、作成できる自動ビルドの各種類について説明します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-206">The following table describes each type of automated build that you can create.</span></span> 

|**<span data-ttu-id="2f96f-207">ビルドの種類</span><span class="sxs-lookup"><span data-stu-id="2f96f-207">Type of Build</span></span>**|**<span data-ttu-id="2f96f-208">成果物</span><span class="sxs-lookup"><span data-stu-id="2f96f-208">Artifact</span></span>**|**<span data-ttu-id="2f96f-209">推奨される頻度</span><span class="sxs-lookup"><span data-stu-id="2f96f-209">Recommended Frequency</span></span>**|**<span data-ttu-id="2f96f-210">説明</span><span class="sxs-lookup"><span data-stu-id="2f96f-210">Description</span></span>**|
|-----------------|------------|-------------------------|---------------|
|<span data-ttu-id="2f96f-211">継続的インテグレーション</span><span class="sxs-lookup"><span data-stu-id="2f96f-211">Continuous Integration</span></span>|<span data-ttu-id="2f96f-212">ビルド ログ、テスト結果</span><span class="sxs-lookup"><span data-stu-id="2f96f-212">Build Log, Test Results</span></span>|<span data-ttu-id="2f96f-213">コミットごと</span><span class="sxs-lookup"><span data-stu-id="2f96f-213">Each commit</span></span>|<span data-ttu-id="2f96f-214">この種類のビルドは高速で、1 日に数回実行されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-214">This type of build is fast and run several times a day.</span></span>|
|<span data-ttu-id="2f96f-215">サイドロード用の継続的配置ビルド</span><span class="sxs-lookup"><span data-stu-id="2f96f-215">Continuous Deployment build for sideloading</span></span>|<span data-ttu-id="2f96f-216">配置パッケージ</span><span class="sxs-lookup"><span data-stu-id="2f96f-216">Deployment Packages</span></span>|<span data-ttu-id="2f96f-217">毎日</span><span class="sxs-lookup"><span data-stu-id="2f96f-217">Daily</span></span> |<span data-ttu-id="2f96f-218">この種類のビルドは、単体テストを含めることができますが、少し長くかかります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-218">This type of build can Include unit tests but it takes a bit longer.</span></span> <span data-ttu-id="2f96f-219">これにより、手動でテストでき、HockeyApp などの他のツールと統合できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-219">It allows manual testing and you can integrate it with other tools such as HockeyApp.</span></span>|
|<span data-ttu-id="2f96f-220">ストアにパッケージを提出する継続的配置ビルド</span><span class="sxs-lookup"><span data-stu-id="2f96f-220">Continuous Deployment build that submits a package to the Store</span></span>|<span data-ttu-id="2f96f-221">公開パッケージ</span><span class="sxs-lookup"><span data-stu-id="2f96f-221">Publishing Packages</span></span>|<span data-ttu-id="2f96f-222">オンデマンド</span><span class="sxs-lookup"><span data-stu-id="2f96f-222">On demand</span></span>|<span data-ttu-id="2f96f-223">この種類のビルドでは、ストアに公開できるパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-223">This type of build creates a package that you can publish to the Store.</span></span>|

<span data-ttu-id="2f96f-224">1 つずつを構成する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="2f96f-224">Let’s look at how to configure each one.</span></span>


## <a name="set-up-a-continuous-integration-ci-build"></a><span data-ttu-id="2f96f-225">継続的インテグレーション (CI) ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="2f96f-225">Set up a Continuous Integration (CI) build</span></span> 
<span data-ttu-id="2f96f-226">この種類のビルドは、すばやくコードに関連する問題を診断するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-226">This type of a build helps you to diagnose code related problems quickly.</span></span> <span data-ttu-id="2f96f-227">通常、1 つのプラットフォーム用にのみ実行され、.NETネイティブ ツール チェーンで処理する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2f96f-227">They’re typically executed for only one platform, and they don’t need to be processed by the .NET native toolchain.</span></span> <span data-ttu-id="2f96f-228">また、CI ビルドを使って、テスト結果のレポートを生成する単体テストを実行できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-228">Also, with CI builds, you can run unit tests that produce a test results report.</span></span>  

<span data-ttu-id="2f96f-229">CI ビルドの一環として UWP 単体テストを実行する場合、ホスト ビルド エージェントではなく、カスタム ビルド エージェントを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-229">If you want to run UWP unit tests as part of your CI build you’ll need to use a custom build agent instead of the hosted build agent.</span></span>

><span data-ttu-id="2f96f-230">注: 複数のアプリを同じソリューションにバンドルすると、エラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-230">Note: If you bundle more than one app in the same solution, you might receive an error.</span></span> <span data-ttu-id="2f96f-231">このようなエラーを解決する方法については、「[複数のアプリを同じソリューションにバンドルした場合に表示されるエラーを解決する](#bundle-errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-231">See the following topic for help resolving that error: [Address errors that appear when you bundle more than one app in the same solution.](#bundle-errors)</span></span> 


### <a name="configure-a-ci-build-definition"></a><span data-ttu-id="2f96f-232">CI ビルド定義を構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-232">Configure a CI build definition</span></span>
<span data-ttu-id="2f96f-233">既定の UWP テンプレートを使用して、ビルド定義を作成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-233">Use the default UWP template to create a build definition.</span></span> <span data-ttu-id="2f96f-234">次に、チェックインごとに実行するトリガーを構成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-234">Then, configure the Trigger to execute on each check in.</span></span>  

![CI トリガー](images/building-screen7.png)

<span data-ttu-id="2f96f-236">CI ビルドはユーザーに対して展開されないため、CD ビルドとの混同を避けるために、異なるバージョン番号によって管理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-236">Because the CI build won’t be deployed to users, it’s a good idea to maintain different versioning numbers to avoid confusion with the CD builds.</span></span> <span data-ttu-id="2f96f-237">たとえば、`$(BuildDefinitionName)_0.0.$(DayOfYear)$(Rev:.r)` のように指定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-237">For example: `$(BuildDefinitionName)_0.0.$(DayOfYear)$(Rev:.r)`.</span></span>


#### <a name="configure-a-custom-build-agent-for-unit-testing"></a><span data-ttu-id="2f96f-238">単体テスト用のカスタム ビルド エージェントを構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-238">Configure a custom build agent for unit testing</span></span>

<span data-ttu-id="2f96f-239">1. 最初に、お使いの PC で開発者モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-239">1.First, enable Developer Mode on your PC.</span></span> <span data-ttu-id="2f96f-240">デバイスを開発用に有効にする方法に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-240">See Enable your device for development.</span></span> <span data-ttu-id="2f96f-241">2. サービスを対話型プロセスとして実行できるように設定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-241">2.Enable the service to run as an interactive process.</span></span> <span data-ttu-id="2f96f-242">Windows でのエージェントの展開に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-242">See Deploy an agent on Windows.</span></span> <span data-ttu-id="2f96f-243">3. エージェントに署名証明書を展開します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-243">3.Deploy the signing certificate to the agent.</span></span>

<span data-ttu-id="2f96f-244">そのためには、.cer ファイルをダブルクリックし、[ローカル コンピューター] を選択して、信頼されたユーザーのストアを選択します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-244">To do that, double-click the .cer file, choose Local Machine, and then choose the Trusted People Store.</span></span>

<span id="uwp-unit-tests" />
### <a name="configure-the-build-definition-to-run-uwp-unit-tests"></a><span data-ttu-id="2f96f-245">UWP 単体テストを実行するようにビルド定義を構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-245">Configure the build definition to run UWP Unit Tests</span></span>
<span data-ttu-id="2f96f-246">単体テストを実行するには、Visual Studio テスト ビルド ステップを使用します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-246">To execute a unit test, use the Visual Studio Test build step.</span></span>


![単体テストを追加する](images/building-screen8.png)

<span data-ttu-id="2f96f-248">UWP 単体テストは特定の appx ファイルのコンテキストで実行されるため、生成されたバンドルを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="2f96f-248">UWP unit tests are executed in the context of a given appx file so you can’t use the generated bundle.</span></span> <span data-ttu-id="2f96f-249">また、具体的なプラットフォームの appx ファイルへのパスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-249">Also, you’ll have to specify the path to a concrete platform appx file.</span></span> <span data-ttu-id="2f96f-250">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-250">For example:</span></span>

```
$(Build.ArtifactStagingDirectory)\AppxPackages\MyUWPApp.UnitTest\x86\MyUWPApp.UnitTest_$(AppxVersion)_x86.appx
```

><span data-ttu-id="2f96f-251">注: コマンド ラインからローカルに単体テストを実行するには、次のコマンドを使います。</span><span class="sxs-lookup"><span data-stu-id="2f96f-251">Note: Use the following command to execute the unit tests locally from the command line:</span></span>
`"%ProgramFiles(x86)%\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"`

#### <a name="access-test-results"></a><span data-ttu-id="2f96f-252">テスト結果にアクセスする</span><span class="sxs-lookup"><span data-stu-id="2f96f-252">Access test results</span></span>
<span data-ttu-id="2f96f-253">VSTS では、ビルドの概要ページに、単体テストを実行する各ビルドのテスト結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-253">In VSTS, the build summary page shows the test results for each build that executes unit tests.</span></span>  <span data-ttu-id="2f96f-254">そこから、[テスト結果] ページを開いてテスト結果の詳細を確認できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-254">From there, you can open the Test Results page to see more detail about the test results.</span></span> 

![テスト結果](images/building-screen9.png)

#### <a name="improve-the-speed-of-a-ci-build"></a><span data-ttu-id="2f96f-256">CI ビルドの速度を向上させる</span><span class="sxs-lookup"><span data-stu-id="2f96f-256">Improve the speed of a CI build</span></span>
<span data-ttu-id="2f96f-257">チェックインの品質を監視する目的にのみ CI ビルドを使用する場合は、ビルド時間を短縮できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-257">If you want to use your CI build only to monitor the quality of your check-ins, you can reduce your build times.</span></span>

#### <a name="to-improve-the-speed-of-a-ci-build"></a><span data-ttu-id="2f96f-258">CI ビルドの速度を向上させるには</span><span class="sxs-lookup"><span data-stu-id="2f96f-258">To improve the speed of a CI build</span></span>
1.  <span data-ttu-id="2f96f-259">1 つのプラットフォーム向けにのみビルドします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-259">Build for only one platform.</span></span>
2.  <span data-ttu-id="2f96f-260">BuildPlatform 変数を編集して、x86 のみを使用します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-260">Edit the BuildPlatform variable to use only x86.</span></span> ![CI を構成する](images/building-screen10.png) 
3.  <span data-ttu-id="2f96f-262">ビルド ステップで、[MSBuild 引数] プロパティに「/p:AppxBundle=Never」を追加し、[プラットフォーム] プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-262">In the build step, add /p:AppxBundle=Never to the MSBuild Arguments property, and then set the Platform property.</span></span> ![プラットフォームを構成する](images/building-screen11.png)
4.  <span data-ttu-id="2f96f-264">単体テスト プロジェクトで、.NET Native を無効にします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-264">In the unit test project, disable .NET Native.</span></span> 

<span data-ttu-id="2f96f-265">そのためには、プロジェクト ファイルを開き、プロジェクトのプロパティで、`UseDotNetNativeToolchain` プロパティを `false` に設定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-265">To do that, open the project file, and in the project properties, set the `UseDotNetNativeToolchain` property to `false`.</span></span>

><span data-ttu-id="2f96f-266">注: </span><span class="sxs-lookup"><span data-stu-id="2f96f-266">Note.</span></span> <span data-ttu-id="2f96f-267">.NET Native ツール チェーンは依然としてワークフローの重要な部分であるため、リリース ビルドをテストするにはこのツール チェーンを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-267">Using the .NET native tool chain is still an important part of the workflow so you should still use it to test release builds.</span></span> 

<span id="bundle-errors" />
#### <a name="address-errors-that-appear-when-you-bundle-more-than-one-app-in-the-same-solution"></a><span data-ttu-id="2f96f-268">複数のアプリを同じソリューションにバンドルした場合に表示されるエラーを解決する</span><span class="sxs-lookup"><span data-stu-id="2f96f-268">Address errors that appear when you bundle more than one app in the same solution</span></span> 
<span data-ttu-id="2f96f-269">ソリューションに複数の UWP プロジェクトを追加し、バンドルを作成しようとすると、次のようなエラーが表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-269">If you add more than one UWP project to your solution, and then try to create a bundle, you might receive an error like this one:</span></span> 

```
MakeAppx(0,0): Error : Error info: error 80080204: The package with file name "AppOne.UnitTests_0.1.2595.0_x86.appx" and package full name "8ef641d1-4557-4e33-957f-6895b122f1e6_0.1.2595.0_x86__scrj5wvaadcy6" is not valid in the bundle because it has a different package family name than other packages in the bundle
```

<span data-ttu-id="2f96f-270">このエラーが表示されるのは、ソリューション レベルで、バンドルに含めるアプリが明確ではないためです。</span><span class="sxs-lookup"><span data-stu-id="2f96f-270">This error appears because at the solution level, it’s not clear which app should appear in the bundle.</span></span> <span data-ttu-id="2f96f-271">この問題を解決するには、各プロジェクト ファイルを開き、最初の `<PropertyGroup>` 要素の最後に以下のプロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-271">To resolve this issue, open each project file and add the following properties at the end of the first `<PropertyGroup>` element:</span></span>

|**<span data-ttu-id="2f96f-272">プロジェクト</span><span class="sxs-lookup"><span data-stu-id="2f96f-272">Project</span></span>**|**<span data-ttu-id="2f96f-273">プロパティ</span><span class="sxs-lookup"><span data-stu-id="2f96f-273">Properties</span></span>**|
|-------|----------|
|<span data-ttu-id="2f96f-274">App</span><span class="sxs-lookup"><span data-stu-id="2f96f-274">App</span></span>|`<AppxBundle>Always</AppxBundle>`|
|<span data-ttu-id="2f96f-275">UnitTests</span><span class="sxs-lookup"><span data-stu-id="2f96f-275">UnitTests</span></span>|`<AppxBundle>Never</AppxBundle>`|

<span data-ttu-id="2f96f-276">その後、ビルド ステップから MSBuild の `AppxBundle` 引数を削除します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-276">Then, remove the `AppxBundle` msbuild argument from the build step.</span></span>

## <a name="set-up-a-continuous-deployment-build-for-sideloading"></a><span data-ttu-id="2f96f-277">サイドロード用の継続的配置ビルドの設定</span><span class="sxs-lookup"><span data-stu-id="2f96f-277">Set up a continuous deployment build for sideloading</span></span>
<span data-ttu-id="2f96f-278">この種類のビルドが完了したら、ユーザーは、ビルド結果ページの [成果物] セクションから appxbundle ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-278">When this type of build completes, users can download the appxbundle file from the artifacts section of the build results page.</span></span> <span data-ttu-id="2f96f-279">より完全な配布を作成することでアプリのベータ テストを行う場合は、HockeyApp サービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-279">If you want to beta test the app by creating a more complete distribution, you can use the HockeyApp service.</span></span> <span data-ttu-id="2f96f-280">このサービスは、ベータ テスト、ユーザー分析、クラッシュ診断用の高度な機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-280">This service offers advanced capabilities for beta testing, user analytics and crash diagnostics.</span></span>


### <a name="applying-version-numbers-to-your-builds"></a><span data-ttu-id="2f96f-281">ビルドにバージョン番号を適用する</span><span class="sxs-lookup"><span data-stu-id="2f96f-281">Applying version numbers to your builds</span></span>

<span data-ttu-id="2f96f-282">マニフェスト ファイルには、アプリのバージョン番号が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2f96f-282">The manifest file contains the app version number.</span></span>  <span data-ttu-id="2f96f-283">バージョン番号を変更するには、ソース コントロール リポジトリ内のマニフェスト ファイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-283">Update the manifest file in your source control repository to change the version number.</span></span> <span data-ttu-id="2f96f-284">アプリのバージョン番号を更新するもう 1 つの方法は、VSTS によって生成されるビルド番号を使用し、アプリをコンパイルする直前にアプリ マニフェストを変更する方法です。</span><span class="sxs-lookup"><span data-stu-id="2f96f-284">Another way to update the version number of your app is to use the build number that is generated by VSTS, and then modify the app manifest just before you compile the app.</span></span> <span data-ttu-id="2f96f-285">ソース コード リポジトリにはこれらの変更をコミットしないでください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-285">Just don’t commit those changes to the source code repository.</span></span>

<span data-ttu-id="2f96f-286">ビルド定義でバージョン管理ビルド番号の形式を定義し、コンパイルする前に、結果のバージョン番号を使用して AppxManifest ファイルと、必要に応じて AssemblyInfo.cs ファイルを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-286">You’ll have to define your versioning build number format in the build definition, and then use the resulting version number to update the AppxManifest and optionally, the AssemblyInfo.cs files, before you compile.</span></span>

<span data-ttu-id="2f96f-287">ビルド定義の *[全般]* タブで、ビルド番号の形式を定義します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-287">Define the build number format in the *General* Tab of your build definition.:</span></span>

![ビルドのバージョン](images/building-screen12.png) 

<span data-ttu-id="2f96f-289">たとえば、ビルド番号の形式を次のように設定したとします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-289">For example, if you set the build number format to the following value:</span></span>  
``` 
$(BuildDefinitionName)_1.1.$(DayOfYear)$(Rev:r).0 
```

<span data-ttu-id="2f96f-290">VSTS では次のようなバージョン番号が生成されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-290">VSTS generates a version number like:</span></span>
```
CI_MyUWPApp_1.1.2501.0
```

><span data-ttu-id="2f96f-291">注: ストアでは、バージョンの最後の数字は 0 である必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-291">Note: The Store will require that the last number in the version to be 0.</span></span>

<span data-ttu-id="2f96f-292">バージョン番号を抽出し、マニフェストや `AssemblyInfo` ファイルに適用できるようにするには、カスタム PowerShell スクリプト ([ここ](https://go.microsoft.com/fwlink/?prd=12560&pver=14&plcid=0x409&clcid=0x9&ar=DevCenter&sar=docs)で入手可能) を使用します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-292">So that you can extract the version number and apply it to the manifest and/or `AssemblyInfo` files, use a custom PowerShell script (available [here](https://go.microsoft.com/fwlink/?prd=12560&pver=14&plcid=0x409&clcid=0x9&ar=DevCenter&sar=docs)).</span></span> <span data-ttu-id="2f96f-293">このスクリプトは、環境変数 `BUILD_BUILDNUMBER` からバージョン番号を読み取り、AssemblyInfo ファイルと AppxManifest ファイルを変更します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-293">That script reads the version number from the environment variable `BUILD_BUILDNUMBER`, and then modifies the AssemblyInfo and AppxManifest files.</span></span> <span data-ttu-id="2f96f-294">ソース リポジトリにこのスクリプトを追加したことを確認し、次のように PowerShell のビルド タスクを構成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-294">Make sure to add this script to your source repository, and then configure a PowerShell build task as shown here:</span></span>


![バージョンの更新](images/building-screen13.png) 

<span data-ttu-id="2f96f-296">`$(AppxVersion)` 変数にバージョン番号が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2f96f-296">The `$(AppxVersion)` variable contains the version number.</span></span> <span data-ttu-id="2f96f-297">この番号を他のビルド ステップで使用できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-297">You can use that number in other build steps.</span></span> 


#### <a name="optional-integrate-with-hockeyapp"></a><span data-ttu-id="2f96f-298">省略可能: HockeyApp と統合する</span><span class="sxs-lookup"><span data-stu-id="2f96f-298">Optional: Integrate with HockeyApp</span></span>
<span data-ttu-id="2f96f-299">まず、Visual Studio 拡張機能 [HockeyApp](https://marketplace.visualstudio.com/items?itemName=ms.hockeyapp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-299">First, install the [HockeyApp](https://marketplace.visualstudio.com/items?itemName=ms.hockeyapp) Visual Studio extension.</span></span> 

><span data-ttu-id="2f96f-300">注: VSTS 管理者としてこの拡張機能をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-300">Note: You’ll have to install this extension as a VSTS administrator.</span></span> 


![HockeyApp](images/building-screen14.png) 

<span data-ttu-id="2f96f-302">次に、HockeyApp の接続を構成します。手順については、[Visual Studio Team Services (VSTS) や Team Foundation Server (TFS) で HockeyApp を使用する方法に関するページ](https://support.hockeyapp.net/kb/third-party-bug-trackers-services-and-webhooks/how-to-use-hockeyapp-with-visual-studio-team-services-vsts-or-team-foundation-server-tfs)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-302">Next, configure the HockeyApp connection by using this guide: [How to use HockeyApp with Visual Studio Team Services (VSTS) or Team Foundation Server (TFS).](https://support.hockeyapp.net/kb/third-party-bug-trackers-services-and-webhooks/how-to-use-hockeyapp-with-visual-studio-team-services-vsts-or-team-foundation-server-tfs)</span></span> <span data-ttu-id="2f96f-303">HockeyApp アカウントを設定するには、Microsoft アカウント、ソーシャル メディア アカウント、または電子メール アドレスのみを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-303">You can use your Microsoft account, social media account or just an email address to set up your HockeyApp account.</span></span> <span data-ttu-id="2f96f-304">無料プランには、2 つのアプリ、1 人の所有者が含まれ、データ制限はありません。</span><span class="sxs-lookup"><span data-stu-id="2f96f-304">The free plan comes with two apps, one owner, and no data restrictions.</span></span>

<span data-ttu-id="2f96f-305">次に、手動で、つまり既存の appx パッケージ ファイルをアップロードすることで、HockeyApp アプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-305">Then, you can create a HockeyApp app manually, or by uploading an existing appx package file.</span></span> <span data-ttu-id="2f96f-306">詳しくは、[新しいアプリを作成する方法に関するページ](https://support.hockeyapp.net/kb/app-management-2/how-to-create-a-new-app)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-306">To learn more, see [How to create a new app.](https://support.hockeyapp.net/kb/app-management-2/how-to-create-a-new-app)</span></span>  

<span data-ttu-id="2f96f-307">既存の appx パッケージ ファイルを使用するには、ビルド ステップを追加し、ビルド ステップのバイナリ ファイルのパスのパラメーターを設定します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-307">To use an existing appx package file, add a build step, and set the Binary File Path parameter of the build step.</span></span> 

![HockeyApp を構成する](images/building-screen15.png) 

<span data-ttu-id="2f96f-309">このパラメーターを設定するには、次の例のように、アプリ名、AppxVersion 変数、サポートされているプラットフォームを組み合わせて 1 つの文字列にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-309">To set this parameter, combine the app name, the AppxVersion variable and the supported platforms together into one string such as this one:</span></span>

``` 
$(Build.ArtifactStagingDirectory)\AppxPackages\MyUWPApp_$(AppxVersion)_Test\MyUWPApp_$(AppxVersion)_x86_x64_ARM.appxbundle
```

><span data-ttu-id="2f96f-310">注: HockeyApp タスクでは、シンボル ファイルへのパスを指定することはできますが、バンドルと共にシンボル (appxsymファイル) を含めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-310">Note: Although the HockeyApp task allows you to specify the path to the symbols file, it’s a best practice to include the symbols (appxsym files) with the bundle.</span></span>

<span data-ttu-id="2f96f-311">サイドロードされたパッケージをインストールして実行する手順については、このガイドで[後述します](#sideloading-best-practices)。</span><span class="sxs-lookup"><span data-stu-id="2f96f-311">We’ll help you install and run a sideloaded package [later](#sideloading-best-practices) in this guide.</span></span> 

## <a name="set-up-a-continuous-deployment-build-that-submits-a-package-to-the-store"></a><span data-ttu-id="2f96f-312">ストアにパッケージを提出する継続的配置ビルドを設定する</span><span class="sxs-lookup"><span data-stu-id="2f96f-312">Set up a continuous deployment build that submits a package to the Store</span></span> 

<span data-ttu-id="2f96f-313">ストア提出パッケージを生成するには、Visual Studio のストア関連付けウィザードを使用してストアにアプリを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-313">To generate Store submission packages, associate your app with the Store by using the Store Association Wizard in Visual Studio.</span></span>

![ストアに関連付ける](images/building-screen16.png) 

><span data-ttu-id="2f96f-315">注: このウィザードでは、ストアの関連付けの情報が含まれる Package.StoreAssociation.xml という名前のファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-315">Note: This wizard generates a file named Package.StoreAssociation.xml that contains the Store association information.</span></span> <span data-ttu-id="2f96f-316">GitHub などのパブリック リポジトリでソース コードを保存する場合、このファイルには、そのアカウントのすべてのアプリの予約名が含まれます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-316">If you store your source code in a public repository such as GitHub, this file will contain all the app reserved names for that account.</span></span> <span data-ttu-id="2f96f-317">公開する前に、このファイルを除外または削除することができます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-317">You can exclude or delete this file before making it public.</span></span>

<span data-ttu-id="2f96f-318">アプリを公開するために使用したデベロッパー センター アカウントへのアクセス権がない場合は、[サード パーティ向けのアプリをビルドする場合に、ストア アプリをパッケージ化する方法に関するページ](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/#e35YzR5aRG6uaBqK.97)で説明されている手順に従ってください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-318">If you don’t have access to the DevCenter account that was used to publish the app, you can follow the instructions in this document: [Building an app for a 3rd party? How to package their Store app.](https://blogs.windows.com/buildingapps/2015/12/15/building-an-app-for-a-3rd-party-how-to-package-their-store-app/#e35YzR5aRG6uaBqK.97)</span></span> 

<span data-ttu-id="2f96f-319">次に、ビルド ステップに次のパラメーターが含まれていることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-319">Then you need to verify that the build step includes the following parameter:</span></span>

```
/p:UapAppxPackageBuildMode=StoreUpload 
```

<span data-ttu-id="2f96f-320">これにより、ストアに提出できる .appxupload ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-320">This will generate an .appxupload file that can be submitted to the Store.</span></span>


#### <a name="configure-automatic-store-submission"></a><span data-ttu-id="2f96f-321">ストアへの自動提出を構成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-321">Configure automatic Store submission</span></span>

<span data-ttu-id="2f96f-322">Visual Studio Team Services の Windows ストア用の拡張機能を使用してストア API と統合し、アプリ パッケージをストアに送信します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-322">Use the Visual Studio Team Services extension for the Windows Store to integrate with the Store API, and send your app package to the Store.</span></span>

<span data-ttu-id="2f96f-323">Azure Active Directory (AD) を使用してデベロッパー センター アカウントを接続し、AD で要求を認証するアプリを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-323">You need to connect your Dev Center account with Azure Active Directory (AD), and then create an app in your AD to authenticate the requests.</span></span> <span data-ttu-id="2f96f-324">これを実行するには、拡張機能のページのガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="2f96f-324">You can follow the guidance in the extension page to accomplish that.</span></span> 

<span data-ttu-id="2f96f-325">拡張機能を構成した後、ビルド タスクを追加し、アプリの ID と .appxupload ファイルの場所を使ってビルド タスクを構成できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-325">Once you’ve configured the extension, you can add the build task, and configure it with your app ID and the location of the .appxupload file.</span></span>

![デベロッパー センターを構成する](images/building-screen17.png) 

<span data-ttu-id="2f96f-327">`Package File` パラメーターの値は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-327">Where the value of the `Package File` paramter will be:</span></span>

```
$(Build.ArtifactStagingDirectory)\
AppxPackages\MyUWPApp__$(AppxVersion)_x86_x64_ARM_bundle.appxupload
```

><span data-ttu-id="2f96f-328">注: </span><span class="sxs-lookup"><span data-stu-id="2f96f-328">Note.</span></span> <span data-ttu-id="2f96f-329">このビルドは手動でアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-329">You have to manually activate this build.</span></span> <span data-ttu-id="2f96f-330">これを使用して既存のアプリを更新することはできますが、ストアへの最初の提出に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="2f96f-330">You can use it to update existing apps but you can’t use it to for your first submission to the Store.</span></span> <span data-ttu-id="2f96f-331">詳しくは、「[Windows ストア サービスを使用した申請の作成と管理](https://msdn.microsoft.com/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-331">For more information, see [Create and manage Store submissions by using Windows Store Services.](https://msdn.microsoft.com/windows/uwp/monetize/create-and-manage-submissions-using-windows-store-services)</span></span>

## <a name="best-practices"></a><span data-ttu-id="2f96f-332">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="2f96f-332">Best Practices</span></span>

<span id="sideloading-best-practices"/>
### <a name="best-practices-for-sideloading-apps"></a><span data-ttu-id="2f96f-333">アプリのサイドロードのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="2f96f-333">Best Practices for Sideloading apps</span></span>

<span data-ttu-id="2f96f-334">ストアに公開せずに、アプリを配布する場合は、直接デバイスにアプリをサイドロードできます。ただし、それらのデバイスは、アプリ パッケージの署名に使用された証明書を信頼している必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-334">If you want to distribute your app without publishing it to the Store, you can sideload your app directly to devices as long as those devices trust the certificate that was used to sign the app package.</span></span> 

<span data-ttu-id="2f96f-335">`Add-AppDevPackage.ps1` PowerShell スクリプトを使用してアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-335">Use the `Add-AppDevPackage.ps1` PowerShell script to install apps.</span></span> <span data-ttu-id="2f96f-336">このスクリプトは、ローカル コンピューターの信頼されたルート証明書セクションに証明書を追加し、appx ファイルをインストールまたは更新します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-336">This script will add the certificate to the Trusted Root Certification section for the local machine, and will then install or update the appx file.</span></span>

#### <a name="sideloading-your-app-with-the-windows-10-anniversary-update"></a><span data-ttu-id="2f96f-337">Windows 10 Anniversary Update でのアプリのサイドロード</span><span class="sxs-lookup"><span data-stu-id="2f96f-337">Sideloading your app with the Windows 10 Anniversary Update</span></span>
<span data-ttu-id="2f96f-338">Windows 10 Anniversary Update では、appxbundle ファイルをダブルクリックし、ダイアログ ボックスで [インストール] ボタンを選択してアプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-338">In the Windows 10 Anniversary Update, you can double-click the appxbundle file and install your app by choosing the Install button in a dialog box.</span></span> 


![rs1 でのサイドロード](images/building-screen18.png) 

><span data-ttu-id="2f96f-340">注: この方法では、証明書や関連付けられている依存関係はインストールされません。</span><span class="sxs-lookup"><span data-stu-id="2f96f-340">Note: This method doesn’t install the certificate or the associated dependencies.</span></span>

<span data-ttu-id="2f96f-341">VSTS や HockeyApp などの Web サイトから appx パッケージを配布する場合は、お使いのブラウザーで信頼済みサイトの一覧にそのサイトを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-341">If you want to distribute your appx packages from a website such as VSTS or HockeyApp, you’ll need to add that site to the list of trusted sites in your browser.</span></span> <span data-ttu-id="2f96f-342">そうしないと、Windows は、ファイルがロックされているものとしてマークします。</span><span class="sxs-lookup"><span data-stu-id="2f96f-342">Otherwise, Windows marks the file as locked.</span></span> 

<span id="certificates-best-practices"/>
### <a name="best-practices-for-signing-certificates"></a><span data-ttu-id="2f96f-343">署名証明書のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="2f96f-343">Best Practices for Signing Certificates</span></span> 
<span data-ttu-id="2f96f-344">Visual Studio では、各プロジェクト用の証明書が生成されます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-344">Visual Studio generates a certificate for each project.</span></span> <span data-ttu-id="2f96f-345">これにより、有効な証明書の整理された一覧を維持することは困難です。</span><span class="sxs-lookup"><span data-stu-id="2f96f-345">This makes it difficult to maintain a curated list of valid certificates.</span></span> <span data-ttu-id="2f96f-346">複数のアプリを作成することを計画している場合は、すべてのアプリに署名するための単一の証明書を作成できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-346">If you plan to create several apps, you can create a single certificate to sign all of your apps.</span></span> <span data-ttu-id="2f96f-347">その後、その証明書を信頼している各デバイスでは、別の証明書をインストールしなくても、アプリをサイドロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-347">Then, each device that trusts your certificate will be able to sideload any of your apps without installing another certificate.</span></span> <span data-ttu-id="2f96f-348">詳しくは、「[パッケージ署名用の証明書を作成する](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2f96f-348">To learn more, see [Create a certificate for package signing](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing).</span></span>


#### <a name="create-a-signing-certificate"></a><span data-ttu-id="2f96f-349">署名証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-349">Create a Signing Certificate</span></span>
<span data-ttu-id="2f96f-350">証明書を作成するには、[MakeCert.exe](https://msdn.microsoft.com/library/windows/desktop/ff548309.aspx) ツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-350">Use the [MakeCert.exe](https://msdn.microsoft.com/library/windows/desktop/ff548309.aspx)  tool to create a certificate.</span></span> <span data-ttu-id="2f96f-351">次の例では、MakeCert.exe ツールを使って証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-351">The following example, creates a certificate by using the MakeCert.exe tool.</span></span>

```
MakeCert /n publisherName /r /h 0 /eku "1.3.6.1.5.5.7.3.3,1.3.6.1.4.1.311.10.3.13" /e expirationDate /sv MyKey.pvk MyKey.cer
```

<span data-ttu-id="2f96f-352">次に、Pvk2Pfx ツールを使用して、パスワードで保護されている秘密キーを含む PFX ファイルを生成できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-352">Then you can use Pvk2Pfx tool to generate a PFX file that contains the private key protected with a password.</span></span>

<span data-ttu-id="2f96f-353">コンピューターの役割ごとに次の証明書を提供します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-353">Provide these certificates to each machine role:</span></span>

|**<span data-ttu-id="2f96f-354">コンピューター</span><span class="sxs-lookup"><span data-stu-id="2f96f-354">Machine</span></span>**|**<span data-ttu-id="2f96f-355">用途</span><span class="sxs-lookup"><span data-stu-id="2f96f-355">Usage</span></span>**|**<span data-ttu-id="2f96f-356">証明書</span><span class="sxs-lookup"><span data-stu-id="2f96f-356">Certificate</span></span>**|**<span data-ttu-id="2f96f-357">証明書ストア</span><span class="sxs-lookup"><span data-stu-id="2f96f-357">Certificate Store</span></span>**|
|-----------|---------|---------------|---------------------|
|<span data-ttu-id="2f96f-358">開発者/ビルド コンピューター</span><span class="sxs-lookup"><span data-stu-id="2f96f-358">Developer/Build Machine</span></span>|<span data-ttu-id="2f96f-359">ビルドの署名</span><span class="sxs-lookup"><span data-stu-id="2f96f-359">Sign Builds</span></span>|<span data-ttu-id="2f96f-360">MyCert.PFX</span><span class="sxs-lookup"><span data-stu-id="2f96f-360">MyCert.PFX</span></span>|<span data-ttu-id="2f96f-361">現在のユーザー/個人</span><span class="sxs-lookup"><span data-stu-id="2f96f-361">Current User/Personal</span></span>|
|<span data-ttu-id="2f96f-362">開発者/ビルド コンピューター</span><span class="sxs-lookup"><span data-stu-id="2f96f-362">Developer/Build Machine</span></span>|<span data-ttu-id="2f96f-363">実行</span><span class="sxs-lookup"><span data-stu-id="2f96f-363">Run</span></span>|<span data-ttu-id="2f96f-364">MyCert.cer</span><span class="sxs-lookup"><span data-stu-id="2f96f-364">MyCert.cer</span></span>|<span data-ttu-id="2f96f-365">ローカル コンピューター/信頼されたユーザー</span><span class="sxs-lookup"><span data-stu-id="2f96f-365">Local Machine/Trusted People</span></span>|
|<span data-ttu-id="2f96f-366">ユーザー</span><span class="sxs-lookup"><span data-stu-id="2f96f-366">User</span></span>|<span data-ttu-id="2f96f-367">実行</span><span class="sxs-lookup"><span data-stu-id="2f96f-367">Run</span></span>|<span data-ttu-id="2f96f-368">MyCert.cer</span><span class="sxs-lookup"><span data-stu-id="2f96f-368">MyCert.cer</span></span>|<span data-ttu-id="2f96f-369">ローカル コンピューター/信頼されたユーザー</span><span class="sxs-lookup"><span data-stu-id="2f96f-369">Local Machine/Trusted People</span></span>|

><span data-ttu-id="2f96f-370">注: ユーザーによって信頼済みのエンタープライズ証明書を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-370">Note: You can also use an enterprise certificate that is already trusted by your users.</span></span>

#### <a name="sign-your-uwp-app"></a><span data-ttu-id="2f96f-371">UWP アプリに署名する</span><span class="sxs-lookup"><span data-stu-id="2f96f-371">Sign your UWP app</span></span>
<span data-ttu-id="2f96f-372">Visual Studio と MSBuild は、アプリの署名に使う証明書を管理するためのさまざまなオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-372">Visual Studio and MSBuild offers different options to manage the certificate that you use to sign the app:</span></span>

<span data-ttu-id="2f96f-373">そのオプションの 1 つは、ソリューションに証明書と共に秘密キー (通常、.PFX ファイルの形式) を含めて、プロジェクト ファイルで pfx を参照することです。</span><span class="sxs-lookup"><span data-stu-id="2f96f-373">One option is to include the certificate with the private key (normally in the form of a .PFX file) in your solution, and then reference the pfx in the project file.</span></span> <span data-ttu-id="2f96f-374">マニフェスト エディターの [パッケージ] タブを使ってこれを管理できます。</span><span class="sxs-lookup"><span data-stu-id="2f96f-374">You can manage this by using the Package tab of the manifest editor.</span></span>


![証明書を作成する](images/building-screen19.png) 

<span data-ttu-id="2f96f-376">もう 1 つのオプションは、ビルド コンピューター (現在のユーザー/個人) に証明書をインストールし、[証明書ストアから選択] オプションを使用することです。</span><span class="sxs-lookup"><span data-stu-id="2f96f-376">Another option is to install the certificate onto the build machine (Current User/Personal), and then use the Pick from Certificate store option.</span></span> <span data-ttu-id="2f96f-377">これによって、プロジェクト ファイル内で証明書の拇印が指定されるため、プロジェクトのビルドに使用されるすべてのコンピューターに証明書をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-377">This specifies the Thumbprint of the certificate in the project file so that the certificate should be installed in all the machines that will be used to build the project.</span></span>

#### <a name="trust-the-signing-certificate-in-the-target-devices"></a><span data-ttu-id="2f96f-378">ターゲット デバイスで署名証明書を信頼する</span><span class="sxs-lookup"><span data-stu-id="2f96f-378">Trust the signing certificate in the target devices</span></span>
<span data-ttu-id="2f96f-379">ターゲット デバイスでは、アプリをインストールする前に、証明書を信頼する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f96f-379">A target device has to trust the certificate before the app can be installed on it.</span></span> 

<span data-ttu-id="2f96f-380">ローカル コンピューターの証明書ストアの信頼されたユーザーまたは信頼のルートの場所に証明書の公開キーを登録します。</span><span class="sxs-lookup"><span data-stu-id="2f96f-380">Register the public key of the certificate in the Trusted People or Trust Root location in the Local Machine certificate store.</span></span>

<span data-ttu-id="2f96f-381">証明書を登録する最も簡単な方法は、.cer ファイルをダブルクリックし、ウィザードの手順に従って、ローカル コンピューターの信頼されたユーザー ストアに証明書を保存することです。</span><span class="sxs-lookup"><span data-stu-id="2f96f-381">The easiest way to register the certificate is to double-click in the .cer file, and then follow the steps in the wizard to save the certificate in the Local Machine and Trusted People store.</span></span>

## <a name="related-topics"></a><span data-ttu-id="2f96f-382">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2f96f-382">Related Topics</span></span>
* [<span data-ttu-id="2f96f-383">Windows 用の .NET アプリを構築する</span><span class="sxs-lookup"><span data-stu-id="2f96f-383">Build your .NET app for Windows</span></span>](https://www.visualstudio.com/docs/build/get-started/dot-net) 
* [<span data-ttu-id="2f96f-384">UWP アプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="2f96f-384">Packaging UWP apps</span></span>](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)
* [<span data-ttu-id="2f96f-385">Windows 10 での LOB アプリのサイドローディング</span><span class="sxs-lookup"><span data-stu-id="2f96f-385">Sideload LOB apps in Windows 10</span></span>](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)
* [<span data-ttu-id="2f96f-386">パッケージ署名用の証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="2f96f-386">Create a certificate for package signing</span></span>](https://docs.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)
