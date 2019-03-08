---
ms.assetid: A5320094-DF53-42FC-A6BA-A958F8E9210B
title: Visual Studio を使った Surface Hub アプリのテスト
description: Visual Studio シミュレーターは、UWP アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Surface Hub 用に作成されたアプリを含みます。
ms.date: 10/26/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: db481fac1bdcb9e79762f52aee48574e987c4cbb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601017"
---
# <a name="test-surface-hub-apps-using-visual-studio"></a><span data-ttu-id="2d9cc-104">Visual Studio を使った Surface Hub アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="2d9cc-104">Test Surface Hub apps using Visual Studio</span></span>
<span data-ttu-id="2d9cc-105">Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-105">The Visual Studio simulator provides an environment where you can design, develop, debug, and test Universal Windows Platform (UWP) apps, including apps that you have built for Microsoft Surface Hub.</span></span> <span data-ttu-id="2d9cc-106">シミュレーターが Surface Hub、として、同じユーザー インターフェイスを使用しないが、アプリの外観し、動作、Surface Hub の画面サイズと解像度をテストするために便利です。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-106">The simulator does not use the same user interface as Surface Hub, but it is useful for testing how your app looks and behaves with the Surface Hub's screen size and resolution.</span></span>

<span data-ttu-id="2d9cc-107">シミュレーターのツールの詳細については一般に、表示[シミュレーターでアプリの実行の UWP](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator)します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-107">For more information on the simulator tool in general, see [Run UWP apps in the simulator](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator).</span></span>

## <a name="add-surface-hub-resolutions-to-the-simulator"></a><span data-ttu-id="2d9cc-108">Surface Hub の解像度をシミュレーターに追加する</span><span class="sxs-lookup"><span data-stu-id="2d9cc-108">Add Surface Hub resolutions to the simulator</span></span>
<span data-ttu-id="2d9cc-109">Surface Hub の解像度をシミュレーターに追加するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-109">To add Surface Hub resolutions to the simulator:</span></span>

1. <span data-ttu-id="2d9cc-110">55"の構成の作成という名前のファイルに次の XML コードを保存することによって、Surface Hub *HardwareConfigurations SurfaceHub55.xml*します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-110">Create a configuration for the 55" Surface Hub by saving the following XML code into a file named *HardwareConfigurations-SurfaceHub55.xml*.</span></span>  

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

2. <span data-ttu-id="2d9cc-111">84"の構成の作成という名前のファイルに次の XML コードを保存することによって、Surface Hub *HardwareConfigurations SurfaceHub84.xml*します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-111">Create a configuration for the 84" Surface Hub by saving the following XML code into a file named  *HardwareConfigurations-SurfaceHub84.xml*.</span></span>

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

3. <span data-ttu-id="2d9cc-112">2 つの XML ファイルをコピー *C:\Program Files (x86) \common Shared\Windows シミュレーター\\&lt;バージョン番号&gt;\HardwareConfigurations*します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-112">Copy the two XML files into *C:\Program Files (x86)\Common Files\Microsoft Shared\Windows Simulator\\&lt;version number&gt;\HardwareConfigurations*.</span></span>

   > [!NOTE]
   > <span data-ttu-id="2d9cc-113">このフォルダーにファイルを保存するのには、管理者特権が必要です。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-113">Administrative privileges are required to save files into this folder.</span></span>

4. <span data-ttu-id="2d9cc-114">Visual Studio シミュレーターでアプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-114">Run your app in the Visual Studio simulator.</span></span> <span data-ttu-id="2d9cc-115">パレットの **[解像度の変更]** をクリックし、一覧から Surface Hub の構成を選択します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-115">Click the **Change Resolution** button on the palette and select a Surface Hub configuration from the list.</span></span>

    ![Visual Studio シミュレーターの解像度](images/vs-simulator-resolutions.png)

   > [!TIP]
   > <span data-ttu-id="2d9cc-117">[タブレット モードを有効に](https://windows.microsoft.com/windows-10/getstarted-like-a-tablet)Surface Hub のエクスペリエンスをより正確にシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-117">[Turn on Tablet mode](https://windows.microsoft.com/windows-10/getstarted-like-a-tablet) to better simulate the experience of a Surface Hub.</span></span>

## <a name="deploy-apps-to-a-surface-hub-device-from-visual-studio"></a><span data-ttu-id="2d9cc-118">Visual Studio から Surface Hub のデバイスにアプリをデプロイします。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-118">Deploy apps to a Surface Hub device from Visual Studio</span></span>
<span data-ttu-id="2d9cc-119">Surface hub アプリの手動展開は、単純なプロセスです。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-119">Manually deploying an app to a Surface Hub is a simple process.</span></span>

### <a name="enable-developer-mode"></a><span data-ttu-id="2d9cc-120">開発者モードを有効にする</span><span class="sxs-lookup"><span data-stu-id="2d9cc-120">Enable developer mode</span></span>
<span data-ttu-id="2d9cc-121">既定では、Surface Hub はのみ Microsoft Store からアプリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-121">By default, Surface Hub only installs apps from the Microsoft Store.</span></span> <span data-ttu-id="2d9cc-122">他のソースによって署名されたアプリをインストールするには、開発者モードを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-122">To install apps signed by other sources, you must enable developer mode.</span></span>

> [!NOTE]
> <span data-ttu-id="2d9cc-123">開発者モードが有効にすると、再度無効にする場合は、Surface Hub をリセットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-123">After developer mode has been enabled, you will need to reset the Surface Hub if you wish to disable it again.</span></span> <span data-ttu-id="2d9cc-124">デバイスをリセットすると、すべてのローカル ユーザーのファイルと構成が削除され、Windows が再インストールされます。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-124">Resetting the device removes all local user files and configurations and then reinstalls Windows.</span></span>

1. <span data-ttu-id="2d9cc-125">Surface Hub の**スタート** メニューから設定アプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-125">From the Surface Hub's **Start** menu, open the Settings app.</span></span>

   > [!NOTE]
   > <span data-ttu-id="2d9cc-126">Surface Hub で [設定] アプリへのアクセスには、管理者特権が必要です。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-126">Administrative privileges are required to access the Settings app on Surface Hub.</span></span>

2. <span data-ttu-id="2d9cc-127">移動します**更新とセキュリティ\>開発者向け**します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-127">Navigate to **Update & security \> For developers**.</span></span>

3. <span data-ttu-id="2d9cc-128">**[開発者モード]** を選択し、警告メッセージに同意します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-128">Choose **Developer mode** and accept the warning prompt.</span></span>

### <a name="deploy-your-app-from-visual-studio"></a><span data-ttu-id="2d9cc-129">Visual Studio からアプリを展開する</span><span class="sxs-lookup"><span data-stu-id="2d9cc-129">Deploy your app from Visual Studio</span></span>
<span data-ttu-id="2d9cc-130">一般に、表示、展開プロセスの詳細については[の展開と UWP アプリのデバッグ](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps)します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-130">For more information on the deployment process in general, see [Deploying and debugging UWP apps](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps).</span></span>

   > [!NOTE]
   > <span data-ttu-id="2d9cc-131">この機能では、最新の最新バージョンの Visual Studio を使用することをお勧めします。 ただし、Visual Studio 2015 Update 1 以降が必要です。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-131">This feature requires Visual Studio 2015 Update 1 or later, however we recommend that you use the latest most up to date version of Visual Studio.</span></span> <span data-ttu-id="2d9cc-132">最新の Visual Studio インスタンスには、する最新のすべての開発とセキュリティ更新プログラムを gibe は。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-132">An up to date Visual Studio instance will gibe you all the latest development and security updates.</span></span>

1. <span data-ttu-id="2d9cc-133">**[デバッグの開始]** ボタンの横にあるデバッグ ターゲットのドロップダウンに移動し、**[リモート コンピューター]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-133">Navigate to the debug target dropdown next to the **Start Debugging** button and select **Remote Machine**.</span></span>

    <!--lcap: in your screenshot, you have local machine selected-->

   ![Visual Studio のデバッグ ターゲットのドロップダウン](images/vs-debug-target.png)

2. <span data-ttu-id="2d9cc-135">Surface Hub ハブの IP アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-135">Enter the Surface Hub's IP address.</span></span> <span data-ttu-id="2d9cc-136">**[ユニバーサル]** 認証モードが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-136">Ensure that the **Universal** authentication mode is selected.</span></span>

   > [!TIP] 
   > <span data-ttu-id="2d9cc-137">開発者モードを有効にした後は、[ようこそ] 画面 Surface Hub の IP アドレスが見つかります。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-137">After you have enabled developer mode, you can find the Surface Hub's IP address on the welcome screen.</span></span>

3. <span data-ttu-id="2d9cc-138">選択**デバッグ (F5) で開始**を展開し、Surface Hub でアプリをデバッグまたは単にアプリをデプロイするには、Ctrl + F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-138">Select **Start Debugging (F5)** to deploy and debug your app on the Surface Hub, or press Ctrl+F5 to just deploy your app.</span></span>

   > [!TIP]
   > <span data-ttu-id="2d9cc-139">Surface Hub は、ようこそ画面を表示している場合は、いずれかのボタンを選択して閉じます。</span><span class="sxs-lookup"><span data-stu-id="2d9cc-139">If the Surface Hub is displaying the welcome screen, dismiss it by choosing any button.</span></span>
