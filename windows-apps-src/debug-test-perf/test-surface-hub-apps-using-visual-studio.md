---
author: PatrickFarley
ms.assetid: A5320094-DF53-42FC-A6BA-A958F8E9210B
title: "Visual Studio を使った Surface Hub アプリのテスト"
description: "Visual Studio シミュレーターは、UWP アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Surface Hub 用に作成されたアプリを含みます。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 859c28d59e3c289ac3cb7151f0b9e396d52546c3
ms.sourcegitcommit: e8cc657d85566768a6efb7cd972ebf64c25e0628
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/26/2017
---
# <a name="test-surface-hub-apps-using-visual-studio"></a><span data-ttu-id="25472-104">Visual Studio を使った Surface Hub アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="25472-104">Test Surface Hub apps using Visual Studio</span></span>
<span data-ttu-id="25472-105">Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。</span><span class="sxs-lookup"><span data-stu-id="25472-105">The Visual Studio simulator provides an environment where you can design, develop, debug, and test Universal Windows Platform (UWP) apps, including apps that you have built for Microsoft Surface Hub.</span></span> <span data-ttu-id="25472-106">シミュレーターでは、Surface Hub と同じユーザー インターフェイスは使用できませんが、Surface Hub の画面サイズと解像度でのアプリの外観と動作をテストするために有用です。</span><span class="sxs-lookup"><span data-stu-id="25472-106">The simulator does not use the same user interface as Surface Hub, but it is useful for testing how your app looks and behaves at the Surface Hub's screen size and resolution.</span></span>

<span data-ttu-id="25472-107">詳しくは、「[シミュレーターでの Windows ストア アプリの実行](https://msdn.microsoft.com/library/hh441475.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25472-107">For more information, see [Run Windows Store apps in the simulator](https://msdn.microsoft.com/library/hh441475.aspx).</span></span>

## <a name="add-surface-hub-resolutions-to-the-simulator"></a><span data-ttu-id="25472-108">Surface Hub の解像度をシミュレーターに追加する</span><span class="sxs-lookup"><span data-stu-id="25472-108">Add Surface Hub resolutions to the simulator</span></span>
<span data-ttu-id="25472-109">Surface Hub の解像度をシミュレーターに追加するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="25472-109">To add Surface Hub resolutions to the simulator:</span></span>

1. <span data-ttu-id="25472-110">**HardwareConfigurations SurfaceHub55.xml** という名前のファイルに次の XML を保存して、55" Surface Hub 用の構成を作成します。</span><span class="sxs-lookup"><span data-stu-id="25472-110">Create a configuration for the 55" Surface Hub by saving the following XML into a file named **HardwareConfigurations-SurfaceHub55.xml**.</span></span>  

    ```xml
    <?xml version="1.0" encoding="UTF-8"?>
    <ArrayOfHardwareConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                                  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
        <HardwareConfiguration>
            <Name>SurfaceHub55</Name>
            <DisplayName>Surface Hub 55"</DisplayName>
            <Resolution>
                <Height>1080</Height>
                <Width>1920</Width>
            </Resolution>
            <DeviceSize>55</DeviceSize>
            <DeviceScaleFactor>100</DeviceScaleFactor>
        </HardwareConfiguration>
    </ArrayOfHardwareConfiguration>
    ```

2. <span data-ttu-id="25472-111">**HardwareConfigurations SurfaceHub84.xml** という名前のファイルに次の XML を保存して、84" Surface Hub 用の構成を作成します。</span><span class="sxs-lookup"><span data-stu-id="25472-111">Create a configuration for the 84" Surface Hub by saving the following XML into a file named  **HardwareConfigurations-SurfaceHub84.xml**.</span></span>

    ```xml
    <?xml version="1.0" encoding="UTF-8"?>
    <ArrayOfHardwareConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                                  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
        <HardwareConfiguration>
            <Name>SurfaceHub84</Name>
            <DisplayName>Surface Hub 84"</DisplayName>
            <Resolution>
                <Height>2160</Height>
                <Width>3840</Width>
            </Resolution>
            <DeviceSize>84</DeviceSize>
            <DeviceScaleFactor>150</DeviceScaleFactor>
        </HardwareConfiguration>
    </ArrayOfHardwareConfiguration>
    ```

3. <span data-ttu-id="25472-112">この 2 つの XML ファイルを **C:\Program Files (x86) \Common Files\Microsoft Shared\Windows Simulator\\&lt;バージョン番号&gt;\HardwareConfigurations** にコピーします。</span><span class="sxs-lookup"><span data-stu-id="25472-112">Copy the two XML files into **C:\Program Files (x86)\Common Files\Microsoft Shared\Windows Simulator\\&lt;version number&gt;\HardwareConfigurations**.</span></span>

   > <span data-ttu-id="25472-113">**注**&nbsp;&nbsp;このフォルダーにファイルを保存するには、管理者特権が必要です。</span><span class="sxs-lookup"><span data-stu-id="25472-113">**Note**&nbsp;&nbsp;Administrative privileges are required to save files into this folder.</span></span>

4. <span data-ttu-id="25472-114">Visual Studio シミュレーターでアプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="25472-114">Run your app in the Visual Studio simulator.</span></span> <span data-ttu-id="25472-115">パレットの **[解像度の変更]** をクリックし、一覧から Surface Hub の構成を選択します。</span><span class="sxs-lookup"><span data-stu-id="25472-115">Click the **Change Resolution** button on the palette and select a Surface Hub configuration from the list.</span></span>

    ![Visual Studio シミュレーターの解像度](images/vs-simulator-resolutions.png)

   > <span data-ttu-id="25472-117">**ヒント**&nbsp;&nbsp;Surface Hub でのエクスペリエンスをより適切にシミュレートするには、[タブレット モードを有効にします](http://windows.microsoft.com/windows-10/getstarted-like-a-tablet)。</span><span class="sxs-lookup"><span data-stu-id="25472-117">**Tip**&nbsp;&nbsp;[Turn on Tablet mode](http://windows.microsoft.com/windows-10/getstarted-like-a-tablet) to better simulate the experience on a Surface Hub.</span></span>

## <a name="deploy-apps-to-a-surface-hub-from-visual-studio"></a><span data-ttu-id="25472-118">Visual Studio から Surface Hub にアプリを展開する</span><span class="sxs-lookup"><span data-stu-id="25472-118">Deploy apps to a Surface Hub from Visual Studio</span></span>
<span data-ttu-id="25472-119">アプリを手動で展開することは単純なプロセスです。</span><span class="sxs-lookup"><span data-stu-id="25472-119">Manually deploying an app is a simple process.</span></span>

### <a name="enable-developer-mode"></a><span data-ttu-id="25472-120">開発者モードを有効にする</span><span class="sxs-lookup"><span data-stu-id="25472-120">Enable developer mode</span></span>
<span data-ttu-id="25472-121">既定では、Surface Hub はアプリを Windows ストアからのみインストールします。</span><span class="sxs-lookup"><span data-stu-id="25472-121">By default, Surface Hub only installs apps from the Windows Store.</span></span> <span data-ttu-id="25472-122">他のソースによって署名されたアプリをインストールするには、開発者モードを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="25472-122">To install apps signed by other sources, you must enable developer mode.</span></span>

> <span data-ttu-id="25472-123">**注**&nbsp;&nbsp;開発者モードを有効にした後、もう一度これを無効にするには、Surface Hub をリセットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="25472-123">**Note**&nbsp;&nbsp;After developer mode has been enabled, you will need to reset the Surface Hub to disable it again.</span></span> <span data-ttu-id="25472-124">デバイスをリセットすると、すべてのローカル ユーザーのファイルと構成が削除され、Windows が再インストールされます。</span><span class="sxs-lookup"><span data-stu-id="25472-124">Resetting the device removes all local user files and configurations and then reinstalls Windows.</span></span>

1. <span data-ttu-id="25472-125">Surface Hub の**スタート** メニューから設定アプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="25472-125">From the Surface Hub's **Start** menu, open the Settings app.</span></span>

   >  <span data-ttu-id="25472-126">**注**&nbsp;&nbsp;設定アプリにアクセスするには、管理者特権が必要です。</span><span class="sxs-lookup"><span data-stu-id="25472-126">**Note**&nbsp;&nbsp;Administrative privileges are required to access the Settings app.</span></span>

2. <span data-ttu-id="25472-127">**[更新プログラムとセキュリティ]**、[開発者向け] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="25472-127">Navigate to **Update & security > For developers**.</span></span>

3. <span data-ttu-id="25472-128">**[開発者モード]** を選択し、警告メッセージに同意します。</span><span class="sxs-lookup"><span data-stu-id="25472-128">Choose **Developer mode** and accept the warning prompt.</span></span>

### <a name="deploy-your-app-from-visual-studio"></a><span data-ttu-id="25472-129">Visual Studio からアプリを展開する</span><span class="sxs-lookup"><span data-stu-id="25472-129">Deploy your app from Visual Studio</span></span>
<span data-ttu-id="25472-130">詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリの展開とデバッグ](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="25472-130">For more information, see [Deploying and debugging Universal Windows Platform (UWP) apps](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps).</span></span>

   > <span data-ttu-id="25472-131">**注**&nbsp;&nbsp;この機能には、少なくとも **Visual Studio 2015 Update 1** が必要です。</span><span class="sxs-lookup"><span data-stu-id="25472-131">**Note**&nbsp;&nbsp;This feature requires at least **Visual Studio 2015 Update 1**.</span></span>

1. <span data-ttu-id="25472-132">**[デバッグの開始]**ボタンの横にあるデバッグ ターゲットのドロップダウンに移動し、**[リモート コンピューター]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="25472-132">Navigate to the debug target dropdown next to the **Start Debugging** button and select **Remote Machine**.</span></span>

    <!--lcap: in your screenshot, you have local machine selected-->

   ![Visual Studio のデバッグ ターゲットのドロップダウン](images/vs-debug-target.png)

2. <span data-ttu-id="25472-134">Surface Hub ハブの IP アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="25472-134">Enter the Surface Hub's IP address.</span></span> <span data-ttu-id="25472-135">**[ユニバーサル]** 認証モードが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="25472-135">Ensure that the **Universal** authentication mode is selected.</span></span>

   > <span data-ttu-id="25472-136">**ヒント**&nbsp;&nbsp;開発者モードを有効にした後、ようこそ画面で、Surface Hub の IP アドレスを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="25472-136">**Tip**&nbsp;&nbsp;After you have enabled developer mode, you can find the Surface Hub's IP address on the welcome screen.</span></span>

3. <span data-ttu-id="25472-137">**[デバッグの開始 (F5)]** を選択して、Surface Hub にアプリを展開してデバッグします。アプリの展開のみを行うには、Ctrl キーを押しながら F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="25472-137">Choose **Start Debugging (F5)** to deploy and debug your app on the Surface Hub, or press Ctrl+F5 to just deploy your app.</span></span>

   > <span data-ttu-id="25472-138">**ヒント**&nbsp;&nbsp;Surface Hub がようこそ画面に表示された場合は、いずれかのボタンを選んで無視します。</span><span class="sxs-lookup"><span data-stu-id="25472-138">**Tip**&nbsp;&nbsp;If the Surface Hub is on the welcome screen, dismiss it by choosing any button.</span></span>
