---
author: c-don
title: ルーズ ファイルの登録によるアプリの展開
description: このガイドでは、ルーズ ファイルのレイアウトの検証し、Windows 10 アプリをパッケージ化することがなく共有を使用する方法を示します。
ms.author: cdon
ms.date: 6/1/2018
ms.topic: article
keywords: windows 10, uwp, デバイス ポータル、アプリ マネージャー, 展開, sdk
ms.localizationpriority: medium
ms.openlocfilehash: 16dc7c3d8182e249134be941d466574cddc36157
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5743039"
---
# <a name="deploy-an-app-through-loose-file-registration"></a><span data-ttu-id="a8859-104">ルーズ ファイルの登録によるアプリの展開</span><span class="sxs-lookup"><span data-stu-id="a8859-104">Deploy an app through loose file registration</span></span> 

<span data-ttu-id="a8859-105">このガイドでは、ルーズ ファイルのレイアウトの検証し、Windows 10 アプリをパッケージ化することがなく共有を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a8859-105">This guide shows how to use the loose file layout to validate and share Windows 10 apps without needing to package them.</span></span> <span data-ttu-id="a8859-106">ルーズ ファイルのレイアウトを登録により、開発者を迅速にパッケージ化し、アプリをインストールすることがなく、アプリを検証します。</span><span class="sxs-lookup"><span data-stu-id="a8859-106">Registering loose file layouts allows developers to quickly validate their apps without the need to package and install the apps.</span></span> 

## <a name="what-is-a-loose-file-layout"></a><span data-ttu-id="a8859-107">ルーズ ファイル レイアウトとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="a8859-107">What is a loose file layout?</span></span>

<span data-ttu-id="a8859-108">ルーズ ファイルのレイアウトは、単にパッケージ化プロセスを通過するのではなく、フォルダー内のアプリの内容を配置します。</span><span class="sxs-lookup"><span data-stu-id="a8859-108">Loose file layout is simply the act of placing app contents in a folder instead of going through the packaging process.</span></span> <span data-ttu-id="a8859-109">パッケージの内容は「疎結合」フォルダーで利用可能なパッケージ化されません。 です。</span><span class="sxs-lookup"><span data-stu-id="a8859-109">The package contents are "loosely" available in a folder and not packaged.</span></span> 

> [!WARNING]
> <span data-ttu-id="a8859-110">ルーズ ファイルのレイアウトの登録はすぐにアクティブな開発中に、アプリを検証するには、開発者やデザイナーです。</span><span class="sxs-lookup"><span data-stu-id="a8859-110">Loose file layout registration is for developers and designers to quickly validate their apps during active development.</span></span> <span data-ttu-id="a8859-111">このアプローチは、「ドッグフード」するために使用または、アプリのフライトしないでください。</span><span class="sxs-lookup"><span data-stu-id="a8859-111">This approach shouldn't be used to "dogfood" or flight the app.</span></span> <span data-ttu-id="a8859-112">信頼された証明書によって署名されているパッケージ アプリで最終的な検証が実行されることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a8859-112">We recommend that the final validation be performed on a packaged app that is signed with a trusted certificate.</span></span> 

## <a name="advantages-of-loose-file-registration"></a><span data-ttu-id="a8859-113">ルーズ ファイルの登録の利点</span><span class="sxs-lookup"><span data-stu-id="a8859-113">Advantages of loose file registration</span></span>

- <span data-ttu-id="a8859-114">**クイック検証**- ユーザーをルーズ ファイルのレイアウトを登録してアプリを起動すばやくできますアプリ ファイルは、既に圧縮されたはであるためです。</span><span class="sxs-lookup"><span data-stu-id="a8859-114">**Quick validation** - Because the app files are already unpacked, users can quickly register the loose file layout and launch the app.</span></span> <span data-ttu-id="a8859-115">、通常のアプリと同様、ユーザーは設計されていることと、アプリを使用することになります。</span><span class="sxs-lookup"><span data-stu-id="a8859-115">Just like a regular app, the user will be able to use the app as it was designed.</span></span> 
- <span data-ttu-id="a8859-116">**簡単にネットワークで配布**- ルーズ ファイルがローカル ドライブではなく、ネットワーク共有にある場合、開発者を送信できるネットワーク共有上の場所、ネットワークへのアクセスを持つその他のユーザーと、ルーズ ファイル レイアウトを登録して、アプリを実行できます。</span><span class="sxs-lookup"><span data-stu-id="a8859-116">**Easy in-network distribution** - If the loose files are located in a network share instead of a local drive, developers can send the network share location to other users who have access to the network, and they can register the loose file layout and run the app.</span></span> <span data-ttu-id="a8859-117">これにより、複数のユーザーを同時に、アプリを検証できます。</span><span class="sxs-lookup"><span data-stu-id="a8859-117">This allows for multiple users to validate the app concurrently.</span></span> 
- <span data-ttu-id="a8859-118">**共同作業**- ルーズ ファイルの登録では、アプリが登録されているときにビジュアル資産操作を続行するには、開発者やデザイナーできます。</span><span class="sxs-lookup"><span data-stu-id="a8859-118">**Collaboration** - Loose file registration allows developers and designers to continue working on visual assets while the app is registered.</span></span> <span data-ttu-id="a8859-119">ユーザーは、アプリを起動するときにこれらの変更が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a8859-119">Users will see these changes when they launch the app.</span></span> <span data-ttu-id="a8859-120">この方法で静的なアセットをのみ変更できることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="a8859-120">Note that you can only change static assets in this manner.</span></span> <span data-ttu-id="a8859-121">コードまたは動的に作成されたコンテンツを変更する必要がある場合は、アプリを再コンパイルする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8859-121">If you need to modify any code or dynamically created content, you must re-compile the app.</span></span>

## <a name="how-to-register-a-loose-file-layout"></a><span data-ttu-id="a8859-122">ルーズ ファイルのレイアウトを登録する方法</span><span class="sxs-lookup"><span data-stu-id="a8859-122">How to register a loose file layout</span></span>

<span data-ttu-id="a8859-123">Windows では、ローカルとリモート デバイスでルーズ ファイルのレイアウトを登録する複数の開発者ツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="a8859-123">Windows provides multiple developer tools to register loose file layouts on local and remote devices.</span></span> <span data-ttu-id="a8859-124">選択できる`WinDeployAppCmd`(Windows SDK ツール)、Windows Device Portal、PowerShell、および[Visual Studio](https://docs.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#register-layout-from-network)します。</span><span class="sxs-lookup"><span data-stu-id="a8859-124">You can choose from `WinDeployAppCmd` (Windows SDK Tool), Windows Device Portal, PowerShell, and [Visual Studio](https://docs.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#register-layout-from-network).</span></span> <span data-ttu-id="a8859-125">以下はこれらのツールを使用して、ルーズ ファイルを登録する方法を経由します。</span><span class="sxs-lookup"><span data-stu-id="a8859-125">Below we will go over how to register loose files using these tools.</span></span> <span data-ttu-id="a8859-126">ただし、まず、次の設定があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a8859-126">But first, ensure that you have following setup:</span></span>

- <span data-ttu-id="a8859-127">デバイスは、Windows 10 Creators Update (ビルド 14965) 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8859-127">Your devices must be on the Windows 10 Creators Update (Build 14965) or later.</span></span>
- <span data-ttu-id="a8859-128">[開発者モード](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)とすべてのデバイスで[デバイスの検出](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#device-discovery)を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8859-128">You will need to enable [developer mode](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development) and [device discovery](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#device-discovery) on all devices.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a8859-129">ルーズ ファイルの登録は、ネットワーク共有 (SMB) プロトコルをサポートするデバイスで利用可能なのみ: デスクトップと Xbox します。</span><span class="sxs-lookup"><span data-stu-id="a8859-129">Loose file registration is only available on devices that support the Network Share (SMB) Protocol: Desktop and Xbox.</span></span> 

### <a name="register-with-windeployappcmd"></a><span data-ttu-id="a8859-130">WinDeployAppCmd と登録します。</span><span class="sxs-lookup"><span data-stu-id="a8859-130">Register with WinDeployAppCmd</span></span>

<span data-ttu-id="a8859-131">使用することができますまたは後で、Windows 10 Creators Update (ビルド 14965) に対応する SDK ツールを使用している場合、`WinDeployAppCmd`コマンド プロンプトでコマンド。</span><span class="sxs-lookup"><span data-stu-id="a8859-131">If you are using the SDK tools corresponding to the Windows 10 Creators Update (Build 14965) or later, you can use the `WinDeployAppCmd` command in a Command Prompt.</span></span>

```cmd
WinAppDeployCmd.exe registerfiles -remotedeploydir <Network Path> -ip <IP Address> -pin <target machine PIN>
```

<span data-ttu-id="a8859-132">**ネットワーク パス**– アプリの緩やかなファイルへのパス。</span><span class="sxs-lookup"><span data-stu-id="a8859-132">**Network Path** – the path to the app's loose files.</span></span>

<span data-ttu-id="a8859-133">**IP アドレス**– ターゲット コンピューターの IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="a8859-133">**IP Address** – the IP Address of the target machine.</span></span>

<span data-ttu-id="a8859-134">**ターゲット コンピューター暗証番号 (pin)** – A 暗証番号 (pin)、必要な場合、ターゲット デバイスに接続を確立します。</span><span class="sxs-lookup"><span data-stu-id="a8859-134">**target machine PIN** – A PIN, if required, to establish a connection with the target device.</span></span> <span data-ttu-id="a8859-135">指定して再試行を求め、`-pin`認証が必要な場合はオプションです。</span><span class="sxs-lookup"><span data-stu-id="a8859-135">You will be prompted to retry with the `-pin` option if authentication is required.</span></span> <span data-ttu-id="a8859-136">[デバイスの検出](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#device-discovery)暗証番号 (pin) を取得する方法について参照してください。</span><span class="sxs-lookup"><span data-stu-id="a8859-136">See [Device Discovery](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#device-discovery) to learn how to get a PIN.</span></span>

### <a name="windows-device-portal"></a><span data-ttu-id="a8859-137">Windows Device Portal</span><span class="sxs-lookup"><span data-stu-id="a8859-137">Windows Device Portal</span></span>

<span data-ttu-id="a8859-138">Windows Device Portal は、すべての Windows 10 デバイスで利用可能なをテストし、仕事用の検証に開発者が使用します。</span><span class="sxs-lookup"><span data-stu-id="a8859-138">Windows Device Portal is available on all Windows 10 devices and is used by developers to test and validate their work.</span></span> <span data-ttu-id="a8859-139">すべての REST エンドポイントと、ブラウザーの UX と開発者コミュニティの対象ユーザーに要求を満たします。</span><span class="sxs-lookup"><span data-stu-id="a8859-139">It caters to all audiences of the developer community with its browser UX and REST endpoints.</span></span> <span data-ttu-id="a8859-140">Device Portal について詳しくは、 [Windows Device Portal の概要](device-portal.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a8859-140">For more information on Device Portal, see the [Windows Device Portal overview](device-portal.md).</span></span>

<span data-ttu-id="a8859-141">Device portal をルーズ ファイルのレイアウトを登録するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="a8859-141">To register the loose file layout in Device Portal, follow these steps.</span></span>

1. <span data-ttu-id="a8859-142">[Windows Device Portal の概要](device-portal.md)の**セットアップ**」の手順に従って、Device Portal に接続します。</span><span class="sxs-lookup"><span data-stu-id="a8859-142">Connect to Device Portal by following the steps in the **Setup** section of the [Windows Device Portal overview](device-portal.md).</span></span>
1. <span data-ttu-id="a8859-143">アプリ マネージャー] タブで、**ネットワーク共有から登録**を選択します。</span><span class="sxs-lookup"><span data-stu-id="a8859-143">In the Apps Manager tab, select **Register from Network Share**.</span></span>
1. <span data-ttu-id="a8859-144">ルーズ ファイルのレイアウトをネットワーク共有のパスを入力します。</span><span class="sxs-lookup"><span data-stu-id="a8859-144">Enter the network share path to the loose file layout.</span></span> 
1. <span data-ttu-id="a8859-145">ホスト デバイスには、ネットワーク共有へのアクセスが割り当てられていない、必要な資格情報を入力するプロンプトがあります。</span><span class="sxs-lookup"><span data-stu-id="a8859-145">If the host device doesn't have access to the network share, there will be a prompt to enter the required credentials.</span></span>
1. <span data-ttu-id="a8859-146">登録が完了したら後のアプリを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="a8859-146">Once the registration is complete, you can launch the app.</span></span>

<span data-ttu-id="a8859-147">Device Portal のアプリ マネージャー] ページで、**オプション パッケージを指定する]** チェック ボックスを選択し、オプションのアプリのネットワーク共有パスを指定オプション ルーズ ファイルのレイアウト、メイン アプリの登録することもできます。</span><span class="sxs-lookup"><span data-stu-id="a8859-147">On the Device Portal's Apps Manager page, you can also register optional loose file layouts for your main app by selecting the **I want to specify optional packages** checkbox and then specifying the network share paths of the optional apps.</span></span> 

### <a name="powershell"></a><span data-ttu-id="a8859-148">PowerShell</span><span class="sxs-lookup"><span data-stu-id="a8859-148">PowerShell</span></span> 

<span data-ttu-id="a8859-149">Windows PowerShell を使用して、ローカル デバイスにのみ、ルーズ ファイルのレイアウトを登録することもできます。</span><span class="sxs-lookup"><span data-stu-id="a8859-149">Windows PowerShell also enables you to register loose file layouts, but only on the local device.</span></span> <span data-ttu-id="a8859-150">リモート デバイスにレイアウトを登録する必要がある場合は、他の方法のいずれかを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8859-150">If you need to register a layout to a remote device, you will need to use one of the other methods.</span></span> 

<span data-ttu-id="a8859-151">ルーズ ファイルのレイアウトを登録するには、PowerShell を起動し、以下を入力します。</span><span class="sxs-lookup"><span data-stu-id="a8859-151">To register the loose file layout, launch PowerShell and enter the following.</span></span>

```PowerShell
Add-AppxPackage -Register <path to manifest file>
```

## <a name="troubleshooting"></a><span data-ttu-id="a8859-152">トラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="a8859-152">Troubleshooting</span></span>

### <a name="mapped-network-drives"></a><span data-ttu-id="a8859-153">マップされたネットワーク ドライブ</span><span class="sxs-lookup"><span data-stu-id="a8859-153">Mapped network drives</span></span>
<span data-ttu-id="a8859-154">現時点では、ルーズ ファイルの登録のマップされたネットワーク ドライブがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a8859-154">Currently, mapped network drives aren't supported for loose file registrations.</span></span> <span data-ttu-id="a8859-155">ネットワーク共有のパスを完全にマッピングされたドライブをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a8859-155">Refer to the mapped drive with full the network share path.</span></span>

### <a name="registration-failure"></a><span data-ttu-id="a8859-156">登録に失敗しました</span><span class="sxs-lookup"><span data-stu-id="a8859-156">Registration failure</span></span>
<span data-ttu-id="a8859-157">デバイスの登録が行われるは、ファイルのレイアウトにアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8859-157">The device on which the registration is taking place will need to have access to the file layout.</span></span> <span data-ttu-id="a8859-158">ファイルのレイアウトは、ネットワーク共有でホストされているが場合、は、デバイスでアクセスできることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a8859-158">If the file layout is hosted on a network share, ensure that the device has access.</span></span> 

### <a name="modifications-to-visual-assets-arent-being-loaded-in-the-app"></a><span data-ttu-id="a8859-159">ビジュアル資産への変更は、アプリに読み込まれているいません。</span><span class="sxs-lookup"><span data-stu-id="a8859-159">Modifications to visual assets aren't being loaded in the app</span></span> 
<span data-ttu-id="a8859-160">アプリの起動時にそのビジュアル アセットが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="a8859-160">The app will load its visual assets at launch time.</span></span> <span data-ttu-id="a8859-161">アプリを起動した後はビジュアル資産に変更を行った場合再最新の変更を表示するアプリを起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a8859-161">If modifications were made to the visual assets after launching the app, you must re-launch the app to view the latest changes.</span></span>