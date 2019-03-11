---
title: ルーズ ファイルの登録によるアプリの展開
description: このガイドでは、圧縮しないファイルのレイアウトを使用して検証し、パッケージ化することがなく、Windows 10 アプリを共有する方法を示します。
ms.date: 6/1/2018
ms.topic: article
keywords: windows 10、uwp、デバイスのポータル、apps manager、デプロイ、sdk
ms.localizationpriority: medium
ms.openlocfilehash: 928c07bd23228f0fefd78be6019a0d116b2e6e4b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635427"
---
# <a name="deploy-an-app-through-loose-file-registration"></a><span data-ttu-id="4374e-104">ルーズ ファイルの登録によるアプリの展開</span><span class="sxs-lookup"><span data-stu-id="4374e-104">Deploy an app through loose file registration</span></span> 

<span data-ttu-id="4374e-105">このガイドでは、圧縮しないファイルのレイアウトを使用して検証し、パッケージ化することがなく、Windows 10 アプリを共有する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="4374e-105">This guide shows how to use the loose file layout to validate and share Windows 10 apps without needing to package them.</span></span> <span data-ttu-id="4374e-106">圧縮しないファイルのレイアウトを登録すると、開発者をパッケージ化し、アプリをインストールする必要はありませんがアプリをすばやく検証ができます。</span><span class="sxs-lookup"><span data-stu-id="4374e-106">Registering loose file layouts allows developers to quickly validate their apps without the need to package and install the apps.</span></span> 

## <a name="what-is-a-loose-file-layout"></a><span data-ttu-id="4374e-107">圧縮しないファイルのレイアウトとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="4374e-107">What is a loose file layout?</span></span>

<span data-ttu-id="4374e-108">圧縮しないファイルのレイアウトは単に、アプリの内容をパッケージ化プロセスを通過するのではなくフォルダーに配置するのです。</span><span class="sxs-lookup"><span data-stu-id="4374e-108">Loose file layout is simply the act of placing app contents in a folder instead of going through the packaging process.</span></span> <span data-ttu-id="4374e-109">パッケージの内容は、「疎」フォルダーで使用可能なパッケージ化されません。 です。</span><span class="sxs-lookup"><span data-stu-id="4374e-109">The package contents are "loosely" available in a folder and not packaged.</span></span> 

> [!WARNING]
> <span data-ttu-id="4374e-110">圧縮しないファイル レイアウトの登録は、アクティブな開発中のアプリをすばやく検証するには、開発者および設計者です。</span><span class="sxs-lookup"><span data-stu-id="4374e-110">Loose file layout registration is for developers and designers to quickly validate their apps during active development.</span></span> <span data-ttu-id="4374e-111">このアプローチは、「ドッグフード」するために使用またはアプリのフライトしないでください。</span><span class="sxs-lookup"><span data-stu-id="4374e-111">This approach shouldn't be used to "dogfood" or flight the app.</span></span> <span data-ttu-id="4374e-112">信頼された証明書で署名されたパッケージのアプリで最終的な検証を実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4374e-112">We recommend that the final validation be performed on a packaged app that is signed with a trusted certificate.</span></span> 

## <a name="advantages-of-loose-file-registration"></a><span data-ttu-id="4374e-113">圧縮しないファイルの登録の利点</span><span class="sxs-lookup"><span data-stu-id="4374e-113">Advantages of loose file registration</span></span>

- <span data-ttu-id="4374e-114">**クイック検証**-ユーザーの圧縮しないファイルのレイアウトを登録し、アプリを起動できますすばやくアプリのファイルが既にアンパックしないため、します。</span><span class="sxs-lookup"><span data-stu-id="4374e-114">**Quick validation** - Because the app files are already unpacked, users can quickly register the loose file layout and launch the app.</span></span> <span data-ttu-id="4374e-115">通常、アプリと同様、ユーザーは設計されたとおりにアプリを使用することになります。</span><span class="sxs-lookup"><span data-stu-id="4374e-115">Just like a regular app, the user will be able to use the app as it was designed.</span></span> 
- <span data-ttu-id="4374e-116">**簡単にネットワークで配布**-圧縮しないファイルがローカル ドライブではなくネットワーク共有内にある、開発者は、ネットワークへのアクセスを持つその他のユーザーにネットワーク共有の場所を送信することができます、および圧縮しないファイルのレイアウトを登録して実行できる場合、アプリ。</span><span class="sxs-lookup"><span data-stu-id="4374e-116">**Easy in-network distribution** - If the loose files are located in a network share instead of a local drive, developers can send the network share location to other users who have access to the network, and they can register the loose file layout and run the app.</span></span> <span data-ttu-id="4374e-117">これにより、複数のユーザーに同時に、アプリを検証します。</span><span class="sxs-lookup"><span data-stu-id="4374e-117">This allows for multiple users to validate the app concurrently.</span></span> 
- <span data-ttu-id="4374e-118">**コラボレーション**-圧縮しないファイルの登録により、アプリを登録中に、ビジュアル アセットで作業を続行するには、開発者および設計者です。</span><span class="sxs-lookup"><span data-stu-id="4374e-118">**Collaboration** - Loose file registration allows developers and designers to continue working on visual assets while the app is registered.</span></span> <span data-ttu-id="4374e-119">アプリの起動時には、これらの変更が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4374e-119">Users will see these changes when they launch the app.</span></span> <span data-ttu-id="4374e-120">この方法で静的なアセットをのみ変更できることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4374e-120">Note that you can only change static assets in this manner.</span></span> <span data-ttu-id="4374e-121">任意のコードまたは動的に作成されたコンテンツを変更する必要がある場合は、アプリを再コンパイルする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4374e-121">If you need to modify any code or dynamically created content, you must re-compile the app.</span></span>

## <a name="how-to-register-a-loose-file-layout"></a><span data-ttu-id="4374e-122">圧縮しないファイルのレイアウトを登録する方法</span><span class="sxs-lookup"><span data-stu-id="4374e-122">How to register a loose file layout</span></span>

<span data-ttu-id="4374e-123">Windows には、ローカルおよびリモート デバイスで圧縮しないファイルのレイアウトを登録する複数の開発者ツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="4374e-123">Windows provides multiple developer tools to register loose file layouts on local and remote devices.</span></span> <span data-ttu-id="4374e-124">選択できます`WinDeployAppCmd`(Windows SDK ツール)、Windows Device Portal、PowerShell、および[Visual Studio](https://docs.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#register-layout-from-network)します。</span><span class="sxs-lookup"><span data-stu-id="4374e-124">You can choose from `WinDeployAppCmd` (Windows SDK Tool), Windows Device Portal, PowerShell, and [Visual Studio](https://docs.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#register-layout-from-network).</span></span> <span data-ttu-id="4374e-125">以下これらのツールを使用して圧縮しないファイルを登録する方法が変わります。</span><span class="sxs-lookup"><span data-stu-id="4374e-125">Below we will go over how to register loose files using these tools.</span></span> <span data-ttu-id="4374e-126">ただし、最初に、次のセットアップがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4374e-126">But first, ensure that you have following setup:</span></span>

- <span data-ttu-id="4374e-127">デバイスは、Windows 10 Creators Update (ビルド 14965) 以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="4374e-127">Your devices must be on the Windows 10 Creators Update (Build 14965) or later.</span></span>
- <span data-ttu-id="4374e-128">有効にする必要があります[開発者モード](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)と[デバイスの検出](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#device-discovery)すべてのデバイスでします。</span><span class="sxs-lookup"><span data-stu-id="4374e-128">You will need to enable [developer mode](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development) and [device discovery](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development#device-discovery) on all devices.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4374e-129">圧縮しないファイルの登録では、ネットワーク共有 (SMB) プロトコルをサポートするデバイスで使用可能なのみです。デスクトップ、Xbox。</span><span class="sxs-lookup"><span data-stu-id="4374e-129">Loose file registration is only available on devices that support the Network Share (SMB) Protocol: Desktop and Xbox.</span></span> 

### <a name="register-with-windeployappcmd"></a><span data-ttu-id="4374e-130">WinDeployAppCmd 登録します。</span><span class="sxs-lookup"><span data-stu-id="4374e-130">Register with WinDeployAppCmd</span></span>

<span data-ttu-id="4374e-131">以降、Windows 10 Creators Update (ビルド 14965) に対応する SDK ツールを使用している場合を使用できます、`WinDeployAppCmd`コマンド プロンプトでコマンド。</span><span class="sxs-lookup"><span data-stu-id="4374e-131">If you are using the SDK tools corresponding to the Windows 10 Creators Update (Build 14965) or later, you can use the `WinDeployAppCmd` command in a Command Prompt.</span></span>

```cmd
WinAppDeployCmd.exe registerfiles -remotedeploydir <Network Path> -ip <IP Address> -pin <target machine PIN>
```

<span data-ttu-id="4374e-132">**ネットワーク パス**– アプリのルーズ ファイルへのパス。</span><span class="sxs-lookup"><span data-stu-id="4374e-132">**Network Path** – the path to the app's loose files.</span></span>

<span data-ttu-id="4374e-133">**IP アドレス**– ターゲット マシンの IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="4374e-133">**IP Address** – the IP Address of the target machine.</span></span>

<span data-ttu-id="4374e-134">**ターゲット マシン PIN** – PIN、ターゲット デバイスとの接続を確立するために、必要な場合。</span><span class="sxs-lookup"><span data-stu-id="4374e-134">**target machine PIN** – A PIN, if required, to establish a connection with the target device.</span></span> <span data-ttu-id="4374e-135">再試行する求め、`-pin`認証が必要な場合はオプションです。</span><span class="sxs-lookup"><span data-stu-id="4374e-135">You will be prompted to retry with the `-pin` option if authentication is required.</span></span> <span data-ttu-id="4374e-136">参照してください[デバイスの検出](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#device-discovery)に PIN を取得する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4374e-136">See [Device Discovery](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#device-discovery) to learn how to get a PIN.</span></span>

### <a name="windows-device-portal"></a><span data-ttu-id="4374e-137">Windows Device Portal</span><span class="sxs-lookup"><span data-stu-id="4374e-137">Windows Device Portal</span></span>

<span data-ttu-id="4374e-138">Windows Device Portal では、すべての Windows 10 デバイスで利用し、テストおよび検証作業する開発者によって使用されます。</span><span class="sxs-lookup"><span data-stu-id="4374e-138">Windows Device Portal is available on all Windows 10 devices and is used by developers to test and validate their work.</span></span> <span data-ttu-id="4374e-139">すべての対象ユーザーとそのブラウザー UX 開発者コミュニティのおよび REST エンドポイントに対応します。</span><span class="sxs-lookup"><span data-stu-id="4374e-139">It caters to all audiences of the developer community with its browser UX and REST endpoints.</span></span> <span data-ttu-id="4374e-140">デバイスのポータルの詳細については、次を参照してください。、 [Windows Device Portal 概要](device-portal.md)します。</span><span class="sxs-lookup"><span data-stu-id="4374e-140">For more information on Device Portal, see the [Windows Device Portal overview](device-portal.md).</span></span>

<span data-ttu-id="4374e-141">デバイスのポータルで、圧縮しないファイルのレイアウトを登録するに次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="4374e-141">To register the loose file layout in Device Portal, follow these steps.</span></span>

1. <span data-ttu-id="4374e-142">次の手順に従って、デバイス ポータルへの接続、**セットアップ**のセクション、 [Windows Device Portal 概要](device-portal.md)。</span><span class="sxs-lookup"><span data-stu-id="4374e-142">Connect to Device Portal by following the steps in the **Setup** section of the [Windows Device Portal overview](device-portal.md).</span></span>
1. <span data-ttu-id="4374e-143">Apps Manager タブで、次のように選択します。**ネットワーク共有から登録**します。</span><span class="sxs-lookup"><span data-stu-id="4374e-143">In the Apps Manager tab, select **Register from Network Share**.</span></span>
1. <span data-ttu-id="4374e-144">圧縮しないファイルのレイアウトには、ネットワーク共有のパスを入力します。</span><span class="sxs-lookup"><span data-stu-id="4374e-144">Enter the network share path to the loose file layout.</span></span> 
1. <span data-ttu-id="4374e-145">ネットワーク共有へのアクセスがない場合、ホスト デバイスの場合は、必要な資格情報の入力を求めるメッセージがあります。</span><span class="sxs-lookup"><span data-stu-id="4374e-145">If the host device doesn't have access to the network share, there will be a prompt to enter the required credentials.</span></span>
1. <span data-ttu-id="4374e-146">登録が完了すると、アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="4374e-146">Once the registration is complete, you can launch the app.</span></span>

<span data-ttu-id="4374e-147">Apps Manager ページで、デバイス ポータルの登録することも省略可能な圧縮しないファイルのレイアウトをメイン アプリを選択して、**省略可能なパッケージを指定する**チェック ボックスをオンし、ネットワークを指定する省略可能なアプリのパスを共有します.</span><span class="sxs-lookup"><span data-stu-id="4374e-147">On the Device Portal's Apps Manager page, you can also register optional loose file layouts for your main app by selecting the **I want to specify optional packages** checkbox and then specifying the network share paths of the optional apps.</span></span> 

### <a name="powershell"></a><span data-ttu-id="4374e-148">PowerShell</span><span class="sxs-lookup"><span data-stu-id="4374e-148">PowerShell</span></span> 

<span data-ttu-id="4374e-149">Windows PowerShell を使用して、ローカルのデバイスだけに、ルース ファイル レイアウトを登録することもできます。</span><span class="sxs-lookup"><span data-stu-id="4374e-149">Windows PowerShell also enables you to register loose file layouts, but only on the local device.</span></span> <span data-ttu-id="4374e-150">リモート デバイスへのレイアウトを登録する必要がある場合は、その他の方法のいずれかを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4374e-150">If you need to register a layout to a remote device, you will need to use one of the other methods.</span></span> 

<span data-ttu-id="4374e-151">圧縮しないファイルのレイアウトを登録するには、PowerShell を起動し、次を入力します。</span><span class="sxs-lookup"><span data-stu-id="4374e-151">To register the loose file layout, launch PowerShell and enter the following.</span></span>

```PowerShell
Add-AppxPackage -Register <path to manifest file>
```

## <a name="troubleshooting"></a><span data-ttu-id="4374e-152">トラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="4374e-152">Troubleshooting</span></span>

### <a name="mapped-network-drives"></a><span data-ttu-id="4374e-153">マップ済みネットワーク ドライブ</span><span class="sxs-lookup"><span data-stu-id="4374e-153">Mapped network drives</span></span>
<span data-ttu-id="4374e-154">現時点では、マップ済みネットワーク ドライブを圧縮しないファイルの登録のサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="4374e-154">Currently, mapped network drives aren't supported for loose file registrations.</span></span> <span data-ttu-id="4374e-155">ネットワーク共有のパスの完全なマップされたドライブを参照してください。</span><span class="sxs-lookup"><span data-stu-id="4374e-155">Refer to the mapped drive with full the network share path.</span></span>

### <a name="registration-failure"></a><span data-ttu-id="4374e-156">登録に失敗しました</span><span class="sxs-lookup"><span data-stu-id="4374e-156">Registration failure</span></span>
<span data-ttu-id="4374e-157">登録が行われて、デバイスは、ファイルのレイアウトにアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4374e-157">The device on which the registration is taking place will need to have access to the file layout.</span></span> <span data-ttu-id="4374e-158">ファイル レイアウトは、ネットワーク共有でホストされているが場合、は、デバイスにアクセスがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4374e-158">If the file layout is hosted on a network share, ensure that the device has access.</span></span> 

### <a name="modifications-to-visual-assets-arent-being-loaded-in-the-app"></a><span data-ttu-id="4374e-159">ビジュアル資産に対する変更は、アプリで読み込まれているはありません。</span><span class="sxs-lookup"><span data-stu-id="4374e-159">Modifications to visual assets aren't being loaded in the app</span></span> 
<span data-ttu-id="4374e-160">アプリは、起動時にそのビジュアル アセットが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="4374e-160">The app will load its visual assets at launch time.</span></span> <span data-ttu-id="4374e-161">場合は、アプリを起動した後、ビジュアルの資産に変更が加えられた、最新の変更を表示するアプリを再起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4374e-161">If modifications were made to the visual assets after launching the app, you must re-launch the app to view the latest changes.</span></span>