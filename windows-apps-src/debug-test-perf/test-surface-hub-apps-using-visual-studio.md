---
ms.assetid: A5320094-DF53-42FC-A6BA-A958F8E9210B
title: Visual Studio を使った Surface Hub アプリのテスト
description: Visual Studio シミュレーターは、UWP アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Surface Hub 用に作成されたアプリを含みます。
ms.date: 10/26/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: db481fac1bdcb9e79762f52aee48574e987c4cbb
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9048885"
---
# <a name="test-surface-hub-apps-using-visual-studio"></a><span data-ttu-id="39485-104">Visual Studio を使った Surface Hub アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="39485-104">Test Surface Hub apps using Visual Studio</span></span>
<span data-ttu-id="39485-105">Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。</span><span class="sxs-lookup"><span data-stu-id="39485-105">The Visual Studio simulator provides an environment where you can design, develop, debug, and test Universal Windows Platform (UWP) apps, including apps that you have built for Microsoft Surface Hub.</span></span> <span data-ttu-id="39485-106">シミュレーターは、Surface Hub と同じユーザー インターフェイスを使用できませんが、アプリの外観し、Surface Hub の画面サイズと解像度で動作をテストするために便利です。</span><span class="sxs-lookup"><span data-stu-id="39485-106">The simulator does not use the same user interface as Surface Hub, but it is useful for testing how your app looks and behaves with the Surface Hub's screen size and resolution.</span></span>

<span data-ttu-id="39485-107">シミュレーター ツールについて詳しくは一般に、 [UWP アプリの実行、シミュレーターで](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="39485-107">For more information on the simulator tool in general, see [Run UWP apps in the simulator](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator).</span></span>

## <a name="add-surface-hub-resolutions-to-the-simulator"></a><span data-ttu-id="39485-108">Surface Hub の解像度をシミュレーターに追加する</span><span class="sxs-lookup"><span data-stu-id="39485-108">Add Surface Hub resolutions to the simulator</span></span>
<span data-ttu-id="39485-109">Surface Hub の解像度をシミュレーターに追加するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="39485-109">To add Surface Hub resolutions to the simulator:</span></span>

1. <span data-ttu-id="39485-110">55 インチ用の構成を作成*hardwareconfigurations SurfaceHub55.xml*という名前のファイルを次の XML コードを保存して Surface Hub します。</span><span class="sxs-lookup"><span data-stu-id="39485-110">Create a configuration for the 55" Surface Hub by saving the following XML code into a file named *HardwareConfigurations-SurfaceHub55.xml*.</span></span>  

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

2. <span data-ttu-id="39485-111">84 インチ用の構成を作成*hardwareconfigurations SurfaceHub84.xml*という名前のファイルを次の XML コードを保存して Surface Hub します。</span><span class="sxs-lookup"><span data-stu-id="39485-111">Create a configuration for the 84" Surface Hub by saving the following XML code into a file named  *HardwareConfigurations-SurfaceHub84.xml*.</span></span>

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

3. <span data-ttu-id="39485-112">この 2 つの XML ファイルを *C:\Program Files (x86) \Common Files\Microsoft Shared\Windows Simulator\\&lt;バージョン番号&gt;\HardwareConfigurations* にコピーします。</span><span class="sxs-lookup"><span data-stu-id="39485-112">Copy the two XML files into *C:\Program Files (x86)\Common Files\Microsoft Shared\Windows Simulator\\&lt;version number&gt;\HardwareConfigurations*.</span></span>

   > [!NOTE]
   > <span data-ttu-id="39485-113">このフォルダーにファイルを保存するには、管理者特権が必要です。</span><span class="sxs-lookup"><span data-stu-id="39485-113">Administrative privileges are required to save files into this folder.</span></span>

4. <span data-ttu-id="39485-114">Visual Studio シミュレーターでアプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="39485-114">Run your app in the Visual Studio simulator.</span></span> <span data-ttu-id="39485-115">パレットの **[解像度の変更]** をクリックし、一覧から Surface Hub の構成を選択します。</span><span class="sxs-lookup"><span data-stu-id="39485-115">Click the **Change Resolution** button on the palette and select a Surface Hub configuration from the list.</span></span>

    ![Visual Studio シミュレーターの解像度](images/vs-simulator-resolutions.png)

   > [!TIP]
   > <span data-ttu-id="39485-117">Surface Hub のエクスペリエンスをシミュレート[タブレット モードを有効に](https://windows.microsoft.com/windows-10/getstarted-like-a-tablet)向上します。</span><span class="sxs-lookup"><span data-stu-id="39485-117">[Turn on Tablet mode](https://windows.microsoft.com/windows-10/getstarted-like-a-tablet) to better simulate the experience of a Surface Hub.</span></span>

## <a name="deploy-apps-to-a-surface-hub-device-from-visual-studio"></a><span data-ttu-id="39485-118">Visual Studio からアプリを Surface Hub デバイスに展開します。</span><span class="sxs-lookup"><span data-stu-id="39485-118">Deploy apps to a Surface Hub device from Visual Studio</span></span>
<span data-ttu-id="39485-119">Surface Hub にアプリを手動で展開は、単純なプロセスです。</span><span class="sxs-lookup"><span data-stu-id="39485-119">Manually deploying an app to a Surface Hub is a simple process.</span></span>

### <a name="enable-developer-mode"></a><span data-ttu-id="39485-120">開発者モードを有効にする</span><span class="sxs-lookup"><span data-stu-id="39485-120">Enable developer mode</span></span>
<span data-ttu-id="39485-121">既定では、Surface Hub はアプリを Microsoft Store からのみインストールします。</span><span class="sxs-lookup"><span data-stu-id="39485-121">By default, Surface Hub only installs apps from the Microsoft Store.</span></span> <span data-ttu-id="39485-122">他のソースによって署名されたアプリをインストールするには、開発者モードを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="39485-122">To install apps signed by other sources, you must enable developer mode.</span></span>

> [!NOTE]
> <span data-ttu-id="39485-123">開発者モードが有効にすると、もう一度これを無効にする場合に、Surface Hub をリセットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="39485-123">After developer mode has been enabled, you will need to reset the Surface Hub if you wish to disable it again.</span></span> <span data-ttu-id="39485-124">デバイスをリセットすると、すべてのローカル ユーザーのファイルと構成が削除され、Windows が再インストールされます。</span><span class="sxs-lookup"><span data-stu-id="39485-124">Resetting the device removes all local user files and configurations and then reinstalls Windows.</span></span>

1. <span data-ttu-id="39485-125">Surface Hub の**スタート** メニューから設定アプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="39485-125">From the Surface Hub's **Start** menu, open the Settings app.</span></span>

   > [!NOTE]
   > <span data-ttu-id="39485-126">Surface Hub で設定アプリにアクセスするには、管理者特権が必要です。</span><span class="sxs-lookup"><span data-stu-id="39485-126">Administrative privileges are required to access the Settings app on Surface Hub.</span></span>

2. <span data-ttu-id="39485-127">**開発者向け & セキュリティ \> の更新**に移動します。</span><span class="sxs-lookup"><span data-stu-id="39485-127">Navigate to **Update & security \> For developers**.</span></span>

3. <span data-ttu-id="39485-128">**[開発者モード]** を選択し、警告メッセージに同意します。</span><span class="sxs-lookup"><span data-stu-id="39485-128">Choose **Developer mode** and accept the warning prompt.</span></span>

### <a name="deploy-your-app-from-visual-studio"></a><span data-ttu-id="39485-129">Visual Studio からアプリを展開する</span><span class="sxs-lookup"><span data-stu-id="39485-129">Deploy your app from Visual Studio</span></span>
<span data-ttu-id="39485-130">展開プロセスの詳細については一般に、参照してください[の展開と UWP アプリをデバッグ](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps)します。</span><span class="sxs-lookup"><span data-stu-id="39485-130">For more information on the deployment process in general, see [Deploying and debugging UWP apps](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps).</span></span>

   > [!NOTE]
   > <span data-ttu-id="39485-131">この機能では、最新の最新バージョンの Visual Studio を使用することをお勧めしますが、Visual Studio 2015 Update 1 以降が必要です。</span><span class="sxs-lookup"><span data-stu-id="39485-131">This feature requires Visual Studio 2015 Update 1 or later, however we recommend that you use the latest most up to date version of Visual Studio.</span></span> <span data-ttu-id="39485-132">最新の Visual Studio インスタンスは、セキュリティ更新プログラムとするすべての最新の開発 gibe されます。</span><span class="sxs-lookup"><span data-stu-id="39485-132">An up to date Visual Studio instance will gibe you all the latest development and security updates.</span></span>

1. <span data-ttu-id="39485-133">**[デバッグの開始]** ボタンの横にあるデバッグ ターゲットのドロップダウンに移動し、**[リモート コンピューター]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="39485-133">Navigate to the debug target dropdown next to the **Start Debugging** button and select **Remote Machine**.</span></span>

    <!--lcap: in your screenshot, you have local machine selected-->

   ![Visual Studio のデバッグ ターゲットのドロップダウン](images/vs-debug-target.png)

2. <span data-ttu-id="39485-135">Surface Hub ハブの IP アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="39485-135">Enter the Surface Hub's IP address.</span></span> <span data-ttu-id="39485-136">**[ユニバーサル]** 認証モードが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="39485-136">Ensure that the **Universal** authentication mode is selected.</span></span>

   > [!TIP] 
   > <span data-ttu-id="39485-137">開発者モードを有効にした後、ようこそ画面に、Surface Hub の IP アドレスを見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="39485-137">After you have enabled developer mode, you can find the Surface Hub's IP address on the welcome screen.</span></span>

3. <span data-ttu-id="39485-138">**デバッグの開始 (F5)** を展開して、Surface Hub にアプリをデバッグする] を選択または Ctrl + f5 キーを押してだけアプリを展開します。</span><span class="sxs-lookup"><span data-stu-id="39485-138">Select **Start Debugging (F5)** to deploy and debug your app on the Surface Hub, or press Ctrl+F5 to just deploy your app.</span></span>

   > [!TIP]
   > <span data-ttu-id="39485-139">Surface Hub がようこそ画面を表示している場合は、いずれかのボタンを選択して簡易非表示します。</span><span class="sxs-lookup"><span data-stu-id="39485-139">If the Surface Hub is displaying the welcome screen, dismiss it by choosing any button.</span></span>
