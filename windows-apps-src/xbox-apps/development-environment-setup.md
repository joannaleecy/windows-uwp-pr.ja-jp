---
author: Mtoepke
title: Xbox の開発環境に UWP を設定する
description: Xbox の開発環境に UWP を設定してテストする手順
ms.author: scotmi
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 8801c0d9-94a5-41a2-bec3-14f523d230df
ms.localizationpriority: medium
ms.openlocfilehash: f2b8792832bd4014732ee0535ccaa74b2a3e00d3
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1689868"
---
# <a name="set-up-your-uwp-on-xbox-development-environment"></a><span data-ttu-id="9de0f-104">Xbox の開発環境に UWP を設定する</span><span class="sxs-lookup"><span data-stu-id="9de0f-104">Set up your UWP on Xbox development environment</span></span>

<span data-ttu-id="9de0f-105">Xbox の開発環境のユニバーサル Windows プラットフォーム (UWP) は、ローカル ネットワークを介して Xbox One 本体に接続されている開発用 PC で構成されます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-105">The Universal Windows Platform (UWP) on Xbox development environment consists of a development PC connected to an Xbox One console through a local network.</span></span>
<span data-ttu-id="9de0f-106">開発用 PC には、Windows 10、Visual Studio 2017 または Visual Studio 2015 Update 3、Windows 10 SDK ビルド 14393 以降などの幅広いサポート ツールが必要です。</span><span class="sxs-lookup"><span data-stu-id="9de0f-106">The development PC requires Windows 10, Visual Studio 2017 or Visual Studio 2015 Update 3, the Windows 10 SDK build 14393 or later, and a range of supporting tools.</span></span>


<span data-ttu-id="9de0f-107">この記事では、開発環境を設定およびテストする手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-107">This article covers the steps to set up and test your development environment.</span></span>

## <a name="visual-studio-setup"></a><span data-ttu-id="9de0f-108">Visual Studio のセットアップ</span><span class="sxs-lookup"><span data-stu-id="9de0f-108">Visual Studio setup</span></span>

1. <span data-ttu-id="9de0f-109">Visual Studio 2017 または Visual Studio 2015 Update 3 をインストールします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-109">Install Visual Studio 2017 or Visual Studio 2015 Update 3.</span></span> <span data-ttu-id="9de0f-110">詳しい情報とインストール方法については、「[Windows 10 のダウンロードとツール](https://dev.windows.com/downloads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-110">For more information and to install, see [Downloads and tools for Windows 10](https://dev.windows.com/downloads).</span></span>

2. <span data-ttu-id="9de0f-111">Visual Studio 2017 をインストールする場合、必ず**ユニバーサル Windows プラットフォーム開発**ワークロードを選択してください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-111">If you're installing Visual Studio 2017, make sure that you choose the **Universal Windows Platform development** workload.</span></span> <span data-ttu-id="9de0f-112">C++ 開発者の場合、必ず **[ユニバーサル Windows プラットフォーム開発]** の右側にある **[概要]** ウィンドウで **[C++ ユニバーサル Windows プラットフォーム ツール]** チェック ボックスもオンにしてください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-112">If you're a C++ developer, make sure that you also select the **C++ Universal Windows Platform tools** checkbox in the **Summary** pane on the right, under **Universal Windows Platform development**.</span></span> <span data-ttu-id="9de0f-113">既定のインストールの一部ではありません。</span><span class="sxs-lookup"><span data-stu-id="9de0f-113">It's not part of the default installation.</span></span>

    ![Visual Studio 2017 のインストール](images/development-environment-setup-1.png)

    <span data-ttu-id="9de0f-115">Visual Studio 2015 Update 3 をインストールするときは、**[ユニバーサル Windows アプリ開発ツール]** チェック ボックスがオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-115">If you're installing Visual Studio 2015 Update 3, ensure that the **Universal Windows App Development Tools** check box is selected.</span></span>

    ![Visual Studio 2015 Update 2 をインストールする](images/vs_install_tools.png)

## <a name="windows-10-sdk-setup"></a><span data-ttu-id="9de0f-117">Windows 10 SDK のセットアップ</span><span class="sxs-lookup"><span data-stu-id="9de0f-117">Windows 10 SDK setup</span></span>

<span data-ttu-id="9de0f-118">最新の Windows 10 SDK をインストールします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-118">Install the latest Windows 10 SDK.</span></span> <span data-ttu-id="9de0f-119">これは、Visual Studio のインストールに付属していますが、別個にダウンロードする場合は「[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-119">This comes with your Visual Studio installation, but if you want to download it separately, see [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk).</span></span>


## <a name="enabling-developer-mode"></a><span data-ttu-id="9de0f-120">開発者モードを有効にする</span><span class="sxs-lookup"><span data-stu-id="9de0f-120">Enabling Developer Mode</span></span>

<span data-ttu-id="9de0f-121">開発用 PC からアプリを展開する前に、開発者モードを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9de0f-121">Before you can deploy apps from your development PC, you must enable Developer Mode.</span></span> <span data-ttu-id="9de0f-122">**設定**アプリで **[更新とセキュリティ]** / **[開発者向け]** に移動し、**[開発者向け機能を使う]** で **[開発者モード]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-122">In the **Settings** app, navigate to **Update & Security** / **For developers**, and under **Use developer features**, select **Developer mode**.</span></span>

## <a name="setting-up-your-xbox-one"></a><span data-ttu-id="9de0f-123">Xbox One の設定</span><span class="sxs-lookup"><span data-stu-id="9de0f-123">Setting up your Xbox One</span></span>

<span data-ttu-id="9de0f-124">Xbox One にアプリを展開する前に、ユーザーが本体にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9de0f-124">Before you can deploy an app to your Xbox One, you must have a user signed in on the console.</span></span> <span data-ttu-id="9de0f-125">既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-125">You can either use your existing Xbox Live account or create a new account for your console in Developer Mode.</span></span> 

## <a name="create-your-first-app"></a><span data-ttu-id="9de0f-126">初めてのアプリの作成</span><span class="sxs-lookup"><span data-stu-id="9de0f-126">Create your first app</span></span>

1. <span data-ttu-id="9de0f-127">開発用 PC がターゲットの Xbox One 本体と同じローカル ネットワーク上にあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-127">Make sure your development PC is on the same local network as the target Xbox One console.</span></span> <span data-ttu-id="9de0f-128">通常、これらは同じルーターを使用し、同じサブネット上にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="9de0f-128">Typically, this means they should use the same router and be on the same subnet.</span></span> <span data-ttu-id="9de0f-129">ワイヤード (有線) ネットワーク接続をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-129">A wired network connection is recommended.</span></span>

2. <span data-ttu-id="9de0f-130">Xbox One 本体が開発者モードになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-130">Ensure that your Xbox One console is in Developer Mode.</span></span>  <span data-ttu-id="9de0f-131">詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-131">For more information, see [Xbox One Developer Mode activation](devkit-activation.md).</span></span>

3. <span data-ttu-id="9de0f-132">UWP アプリに使用するプログラミング言語を決定します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-132">Decide the programming language that you want to use for your UWP app.</span></span>

4. <span data-ttu-id="9de0f-133">開発用 PC の Visual Studio で、**[新規]/[プロジェクト]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-133">On your development PC, in Visual Studio, select **New / Project**.</span></span>

5. <span data-ttu-id="9de0f-134">**[新しいプロジェクト]** ウィンドウで、**[Windows ユニバーサル]/[空のアプリ (Windows ユニバーサル)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-134">In the **New Project** window, select **Windows Universal / Blank App (Universal Windows)**.</span></span>

### <a name="starting-a-c-project"></a><span data-ttu-id="9de0f-135">C# プロジェクトの開始</span><span class="sxs-lookup"><span data-stu-id="9de0f-135">Starting a C# project</span></span>

  ![[新しいプロジェクト] ダイアログ ボックス](images/development-environment-setup-2.png)

1. <span data-ttu-id="9de0f-137">**[新しいユニバーサル Windows プロジェクト]** ダイアログ ボックスの **[最小バージョン]** ドロップダウンでビルド 14393 以降を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-137">In the **New Universal Windows Project** dialog, select build 14393 or later in the **Minimum Version** dropdown.</span></span> <span data-ttu-id="9de0f-138">**[ターゲット バージョン]** ドロップダウン リストで最新の SDK を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-138">Select the latest SDK in the **Target Version** dropdown.</span></span> <span data-ttu-id="9de0f-139">**[開発者モード]** ダイアログ ボックスが表示されたら、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-139">If the **Developer Mode** dialog appears, click **OK**.</span></span> <span data-ttu-id="9de0f-140">新しい空のアプリが作成されます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-140">A new blank app is created.</span></span>

2. <span data-ttu-id="9de0f-141">リモート デバッグの開発環境を構成します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-141">Configure your development environment for remote debugging:</span></span>

    <span data-ttu-id="9de0f-142">a.</span><span class="sxs-lookup"><span data-stu-id="9de0f-142">a.</span></span> <span data-ttu-id="9de0f-143">**[ソリューション エクスプローラー]** でプロジェクトを右クリックし、**[プロパティ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-143">Right-click the project in the **Solution Explorer**, and then select **Properties**.</span></span>

    <span data-ttu-id="9de0f-144">b.</span><span class="sxs-lookup"><span data-stu-id="9de0f-144">b.</span></span> <span data-ttu-id="9de0f-145">**[デバッグ]** タブで、**[プラットフォーム]** を **[x64]** に変更します </span><span class="sxs-lookup"><span data-stu-id="9de0f-145">On the **Debug** tab, change **Platform** to **x64**.</span></span> <span data-ttu-id="9de0f-146">(x86 プラットフォームは Xbox ではサポートされなくなりました)。</span><span class="sxs-lookup"><span data-stu-id="9de0f-146">(x86 is no longer a supported platform on Xbox.)</span></span>

    <span data-ttu-id="9de0f-147">c.</span><span class="sxs-lookup"><span data-stu-id="9de0f-147">c.</span></span> <span data-ttu-id="9de0f-148">**[起動オプション]** で、**[ターゲット デバイス]** を **[リモート コンピューター]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-148">Under **Start options**, change **Target device** to **Remote Machine**.</span></span>

    <span data-ttu-id="9de0f-149">d.</span><span class="sxs-lookup"><span data-stu-id="9de0f-149">d.</span></span> <span data-ttu-id="9de0f-150">**[リモート コンピューター]** で、システムの IP アドレスまたは Xbox One 本体のホスト名を入力します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-150">In **Remote machine**, enter the system IP address or hostname of the Xbox One console.</span></span> <span data-ttu-id="9de0f-151">IP アドレスまたはホスト名の取得について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-151">For information about obtaining the IP address or hostname, see [Introduction to Xbox One tools](introduction-to-xbox-tools.md).</span></span>

    <span data-ttu-id="9de0f-152">e.</span><span class="sxs-lookup"><span data-stu-id="9de0f-152">e.</span></span> <span data-ttu-id="9de0f-153">**[認証モード]** ドロップダウン リストで、**[ユニバーサル (暗号化されていないプロトコル)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-153">In the **Authentication Mode** drop-down list, select **Universal (Unencrypted Protocol)**.</span></span>

    ![C# BlankApp プロパティ ページ](images/vs_remote.jpg)

### <a name="starting-a-c-project"></a><span data-ttu-id="9de0f-155">C++ プロジェクトの開始</span><span class="sxs-lookup"><span data-stu-id="9de0f-155">Starting a C++ project</span></span>

  ![C++ プロジェクト](images/development-environment-setup-3.png)

1. <span data-ttu-id="9de0f-157">**[新しいユニバーサル Windows プロジェクト]** ダイアログ ボックスの **[最小バージョン]** ドロップダウンでビルド 14393 以降を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-157">In the **New Universal Windows Project** dialog, select build 14393 or later in the **Minimum Version** dropdown.</span></span> <span data-ttu-id="9de0f-158">**[ターゲット バージョン]** ドロップダウン リストで最新の SDK を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-158">Select the latest SDK in the **Target Version** dropdown.</span></span> <span data-ttu-id="9de0f-159">**[開発者モード]** ダイアログ ボックスが表示されたら、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-159">If the **Developer Mode** dialog appears, click **OK**.</span></span> <span data-ttu-id="9de0f-160">新しい空のアプリが作成されます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-160">A new blank app is created.</span></span>

2. <span data-ttu-id="9de0f-161">リモート デバッグの開発環境を構成します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-161">Configure your development environment for remote debugging:</span></span>

   <span data-ttu-id="9de0f-162">a.</span><span class="sxs-lookup"><span data-stu-id="9de0f-162">a.</span></span> <span data-ttu-id="9de0f-163">**[ソリューション エクスプローラー]** でプロジェクトを右クリックし、**[プロパティ]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-163">Right-click the project in the **Solution Explorer**, and then select **Properties**.</span></span>

   <span data-ttu-id="9de0f-164">b.</span><span class="sxs-lookup"><span data-stu-id="9de0f-164">b.</span></span> <span data-ttu-id="9de0f-165">**[デバッグ]** タブで、**[起動するデバッガー]** を **[リモート コンピューター]** に変更します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-165">On the **Debugging** tab, change **Debugger to launch** to **Remote Machine**.</span></span>

   <span data-ttu-id="9de0f-166">c.</span><span class="sxs-lookup"><span data-stu-id="9de0f-166">c.</span></span> <span data-ttu-id="9de0f-167">**[コンピューター名]** で、システムの IP アドレスまたは Xbox One 本体のホスト名を入力します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-167">In **Machine Name**, enter the system IP address or hostname of the Xbox One console.</span></span> <span data-ttu-id="9de0f-168">IP アドレスまたはホスト名の取得について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9de0f-168">For information about obtaining the IP address or hostname, see [Introduction to Xbox One tools](introduction-to-xbox-tools.md).</span></span>

   <span data-ttu-id="9de0f-169">d.</span><span class="sxs-lookup"><span data-stu-id="9de0f-169">d.</span></span> <span data-ttu-id="9de0f-170">**[認証の種類]** ドロップダウン リストで、**[ユニバーサル (暗号化されていないプロトコル)]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9de0f-170">In the **Authentication Type** drop-down list, select **Universal (Unencrypted Protocol)**.</span></span>

   <span data-ttu-id="9de0f-171">e.</span><span class="sxs-lookup"><span data-stu-id="9de0f-171">e.</span></span> <span data-ttu-id="9de0f-172">**[プラットフォーム]** ドロップダウンで、**[x64]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-172">In the **Platform** drop-down, select **x64**.</span></span>

    ![C++ BlankApp プロパティ ページ](images/development-environment-setup-4.png)

### <a name="pin-pair-your-device-with-visual-studio"></a><span data-ttu-id="9de0f-174">PIN を使用してデバイスと Visual Studio をペアリングする</span><span class="sxs-lookup"><span data-stu-id="9de0f-174">PIN-pair your device with Visual Studio</span></span>

1. <span data-ttu-id="9de0f-175">設定を保存し、Xbox One 本体が開発者モードになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-175">Save your settings, and make sure your Xbox One console is in Developer Mode.</span></span>

2. <span data-ttu-id="9de0f-176">Visual Studio でプロジェクトを開いたまま F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-176">With your project open in Visual Studio, press F5.</span></span>

3. <span data-ttu-id="9de0f-177">初めて展開する場合、Visual Studio に PIN を使用してデバイスとペアリングすることを求めるダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-177">If this is your first deployment, you will get a dialog from Visual Studio asking to PIN-pair your device.</span></span>

    <span data-ttu-id="9de0f-178">a.</span><span class="sxs-lookup"><span data-stu-id="9de0f-178">a.</span></span> <span data-ttu-id="9de0f-179">PIN を取得するには、Xbox One 本体のホーム画面から **[Dev Home]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-179">To obtain a PIN, open **Dev Home** from the Home screen on your Xbox One console.</span></span>

    <span data-ttu-id="9de0f-180">b.</span><span class="sxs-lookup"><span data-stu-id="9de0f-180">b.</span></span> <span data-ttu-id="9de0f-181">**[ホーム]** タブの **[クイック アクション]** で、**[Visual Studio PIN の表示]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-181">On the **Home** tab, under **Quick actions**, select **Show Visual Studio pin**.</span></span>
  
    ![[Pair with Visual Studio] ダイアログ ボックス](images/development-environment-setup-5.png)

    <span data-ttu-id="9de0f-183">c.</span><span class="sxs-lookup"><span data-stu-id="9de0f-183">c.</span></span> <span data-ttu-id="9de0f-184">**[Pair with Visual Studio]** ダイアログ ボックスに PIN を入力します。</span><span class="sxs-lookup"><span data-stu-id="9de0f-184">Enter your PIN into the **Pair with Visual Studio** dialog.</span></span> <span data-ttu-id="9de0f-185">次の PIN は単なる例であり、実際のものとは異なります。</span><span class="sxs-lookup"><span data-stu-id="9de0f-185">The following PIN is just an example; yours will differ.</span></span>

    ![[Pair with Visual Studio PIN] ダイアログ ボックス](images/devhome_pin.png)

    <span data-ttu-id="9de0f-187">d.</span><span class="sxs-lookup"><span data-stu-id="9de0f-187">d.</span></span> <span data-ttu-id="9de0f-188">展開エラーが発生した場合、**[出力]** ウィンドウに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9de0f-188">Deployment errors, if any, will appear in the **Output** window.</span></span>

<span data-ttu-id="9de0f-189">これで、Xbox に初めての UWP アプリが正しく作成および展開されました。</span><span class="sxs-lookup"><span data-stu-id="9de0f-189">Congratulations, you've successfully created and deployed your first UWP app on Xbox!</span></span>

## <a name="see-also"></a><span data-ttu-id="9de0f-190">関連項目</span><span class="sxs-lookup"><span data-stu-id="9de0f-190">See also</span></span>
- [<span data-ttu-id="9de0f-191">Xbox One 開発者モードのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="9de0f-191">Xbox One Developer Mode activation</span></span>](devkit-activation.md)  
- [<span data-ttu-id="9de0f-192">Windows 10 用のダウンロードとツール</span><span class="sxs-lookup"><span data-stu-id="9de0f-192">Downloads and tools for Windows 10</span></span>](https://dev.windows.com/downloads)  
- [<span data-ttu-id="9de0f-193">Windows Insider Program</span><span class="sxs-lookup"><span data-stu-id="9de0f-193">Windows Insider Program</span></span>](http://go.microsoft.com/fwlink/?LinkId=780552)  
- [<span data-ttu-id="9de0f-194">Xbox One ツールの概要</span><span class="sxs-lookup"><span data-stu-id="9de0f-194">Introduction to Xbox One tools</span></span>](introduction-to-xbox-tools.md) 
- [<span data-ttu-id="9de0f-195">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="9de0f-195">UWP on Xbox One</span></span>](index.md)