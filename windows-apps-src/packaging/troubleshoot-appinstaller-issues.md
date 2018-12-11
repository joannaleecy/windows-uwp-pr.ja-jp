---
title: アプリ インストーラー ファイルを使ったインストールに関する問題のトラブルシューティング
description: アプリ インストーラー ファイルを使ってアプリケーションをサイドローディングするときの一般的な問題。
ms.date: 5/2/2018
ms.topic: article
keywords: Windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング
ms.localizationpriority: medium
ms.openlocfilehash: d4c3aa690dd45a50e6f33d664fbc6cc4503e93f8
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8879685"
---
# <a name="troubleshoot-installation-issues-with-the-app-installer-file"></a><span data-ttu-id="c2d99-104">アプリ インストーラー ファイルを使ったインストールに関する問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="c2d99-104">Troubleshoot installation issues with the App Installer file</span></span>

<span data-ttu-id="c2d99-105">アプリ インストーラー ファイルからアプリケーションをインストールするときに問題が発生した場合、このトピックで示されているトラブルシューティングのガイダンスが役立つことがあります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-105">If you find any issues when installing an application from the App Installer file, this topic will provide some troubleshooting guidance that may help.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c2d99-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="c2d99-106">Prerequisites</span></span>

<span data-ttu-id="c2d99-107">Windows 10 でアプリをサイドローディングできるようにするには、ユーザーのデバイスが以下の要件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-107">To be able to sideload apps in Windows 10, the user device must satisfy the next requirements:</span></span>

- <span data-ttu-id="c2d99-108">デバイスで開発者モードまたはサイドローディング アプリが有効になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-108">The device must be enabled for Developer Mode or Sideloading apps.</span></span> <span data-ttu-id="c2d99-109">詳しくは、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)」ご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2d99-109">See [Enable your device for development](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development) to learn more.</span></span>
- <span data-ttu-id="c2d99-110">パッケージの署名に使う証明書がデバイスによって信頼されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-110">The certificate used to sign the package must be trusted by the device.</span></span> <span data-ttu-id="c2d99-111">詳しくは、後述の「**信頼できる証明書**」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2d99-111">See the **Trusted certificates** section below for more details.</span></span>
- <span data-ttu-id="c2d99-112">Windows 10 のバージョンで `.appinstaller` ファイル スキーマと配布プロトコルがサポートされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-112">The Windows 10 version must support the `.appinstaller` file schema and the distribution protocol.</span></span>

## <a name="common-issues"></a><span data-ttu-id="c2d99-113">一般的な問題</span><span class="sxs-lookup"><span data-stu-id="c2d99-113">Common issues</span></span>

<span data-ttu-id="c2d99-114">ユーザーのコンピューターで初めてアプリケーションをサイドローディングするときにいくつかの問題がよく発生します。</span><span class="sxs-lookup"><span data-stu-id="c2d99-114">There are some common issues when sideloading an application for first time in the user machine.</span></span> <span data-ttu-id="c2d99-115">以降のセクションでは、最も一般的な問題とその解決策について説明します。</span><span class="sxs-lookup"><span data-stu-id="c2d99-115">The next few sections describe the most frequent issues and their solutions.</span></span>

### <a name="windows-version"></a><span data-ttu-id="c2d99-116">Windows のバージョン</span><span class="sxs-lookup"><span data-stu-id="c2d99-116">Windows version</span></span>

<span data-ttu-id="c2d99-117">Windows 10 の各リリースでは、サイドローディング エクスペリエンスが強化されています。次の表に、各メジャー リリースで利用可能な機能を示します。</span><span class="sxs-lookup"><span data-stu-id="c2d99-117">Each Windows 10 release improves on the sideloading experience, in the table below you will find which features are available in each major release.</span></span> <span data-ttu-id="c2d99-118">お使いのバージョンの Windows 10 でサポートされていない方法を使ってアプリをサイドローディングしようとすると、展開エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="c2d99-118">If you try to sideload an app using a method not supported in your version of Windows 10, you will get a deployment error.</span></span>

| <span data-ttu-id="c2d99-119">バージョン</span><span class="sxs-lookup"><span data-stu-id="c2d99-119">Version</span></span> | <span data-ttu-id="c2d99-120">サイドローディングの注意事項</span><span class="sxs-lookup"><span data-stu-id="c2d99-120">Sideload Notes</span></span> |
|---------|----------------|
| <span data-ttu-id="c2d99-121">ビルド 17134 (2018 年 4 月の更新プログラム バージョン 1804)</span><span class="sxs-lookup"><span data-stu-id="c2d99-121">Build 17134 (April 2018 Update, version 1804)</span></span>    | <span data-ttu-id="c2d99-122">`.appinstaller` ファイルには、UNC/共有フォルダー経由でアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-122">The `.appinstaller` file can be accessed over UNC/Share folders.</span></span> <span data-ttu-id="c2d99-123">構成可能な更新プログラムのチェックも使用できます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-123">Configurable update checks are also available.</span></span> |
| <span data-ttu-id="c2d99-124">ビルド 16299 (Fall Creators Update バージョン 1709)</span><span class="sxs-lookup"><span data-stu-id="c2d99-124">Build 16299 (Fall Creators Update, version 1709)</span></span> | <span data-ttu-id="c2d99-125">アプリを自動更新するため、`.appinstaller` ファイルが導入されました。</span><span class="sxs-lookup"><span data-stu-id="c2d99-125">Introduced the `.appinstaller` file to provide automatic updates to your app.</span></span> <span data-ttu-id="c2d99-126">このバージョンでは、HTTP エンドポイントのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-126">This version only supports HTTP endpoints.</span></span> <span data-ttu-id="c2d99-127">更新プログラムのチェックは構成できません。24 時間おきに行われます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-127">Update checks are not configurable and happens each 24 hours.</span></span> |
| <span data-ttu-id="c2d99-128">ビルド 15063 (Creators Update バージョン 1703)</span><span class="sxs-lookup"><span data-stu-id="c2d99-128">Build 15063 (Creators Update, version 1703)</span></span>      | <span data-ttu-id="c2d99-129">アプリ インストーラー アプリは、Microsoft Store からアプリの依存関係をダウンロードできます (リリース モードでのみ)。</span><span class="sxs-lookup"><span data-stu-id="c2d99-129">The App Installer app is able to download app dependencies (only in release mode) from the Store.</span></span> |
| <span data-ttu-id="c2d99-130">ビルド 14393 (Anniversary Update バージョン 1607)</span><span class="sxs-lookup"><span data-stu-id="c2d99-130">Build 14393 (Anniversary Update, version 1607)</span></span>   | <span data-ttu-id="c2d99-131">.appx ファイルと .appxbundle ファイルをインストールするため、アプリ インストーラー アプリが導入されました。.appinstaller ファイルはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="c2d99-131">Introduced the App Installer app to install .appx and .appxbundle files, .appinstaller file is not supported.</span></span> |
| <span data-ttu-id="c2d99-132">ビルド 10586 (November Update バージョン 1511)</span><span class="sxs-lookup"><span data-stu-id="c2d99-132">Build 10586 (November Update, version 1511)</span></span>      | <span data-ttu-id="c2d99-133">サイドローディングは、PowerShell で [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) コマンドを使う場合のみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-133">Sideload is only available through PowerShell using the [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) command.</span></span> |
| <span data-ttu-id="c2d99-134">ビルド 10240 (Windows 10 バージョン 1507)</span><span class="sxs-lookup"><span data-stu-id="c2d99-134">Build 10240 (Windows 10, version 1507)</span></span>           | <span data-ttu-id="c2d99-135">サイドローディングは、PowerShell で [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) コマンドを使う場合のみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-135">Sideload is only available through PowerShell using the [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) command.</span></span> |

### <a name="trusted-certificates"></a><span data-ttu-id="c2d99-136">信頼できる証明書</span><span class="sxs-lookup"><span data-stu-id="c2d99-136">Trusted certificates</span></span>

<span data-ttu-id="c2d99-137">アプリ パッケージは、デバイスで信頼されている証明書を使って署名されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-137">The app package must be signed with a certificate that is trusted by the device.</span></span> <span data-ttu-id="c2d99-138">共通の証明機関によって提供される証明書は、Windows オペレーティング システムで既定で信頼されますが、証明書が信頼されていない場合、アプリをインストールする**前に**デバイスにインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-138">Certificates provided by common Certificate Authorities are trusted by default in the Windows operating system, however if the certificate is not trusted, it must be installed in the device **before** installing the app.</span></span> <span data-ttu-id="c2d99-139">証明書を信頼するには、証明書がデバイス上の次のいずれかのローカル コンピューター証明書ストアに存在している必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-139">To trust the certificate, the certificate must be present in one of the following local machine certificate stores on your device:</span></span>

- <span data-ttu-id="c2d99-140">信頼される発行者</span><span class="sxs-lookup"><span data-stu-id="c2d99-140">Trusted Publishers</span></span>
- <span data-ttu-id="c2d99-141">信頼されたユーザー</span><span class="sxs-lookup"><span data-stu-id="c2d99-141">Trusted People</span></span>
- <span data-ttu-id="c2d99-142">信頼されたルート機関 (非推奨)</span><span class="sxs-lookup"><span data-stu-id="c2d99-142">Trusted Root Authorities (not recommended)</span></span>

 >[!IMPORTANT]
 > <span data-ttu-id="c2d99-143">ローカル コンピューター ストアに証明書をインストールするには、管理アクセス権が必要です。</span><span class="sxs-lookup"><span data-stu-id="c2d99-143">Installing a certificate in the Local Machine store requires administrative access.</span></span>

### <a name="dependencies-not-installed"></a><span data-ttu-id="c2d99-144">依存関係はインストールされない</span><span class="sxs-lookup"><span data-stu-id="c2d99-144">Dependencies not installed</span></span> 

<span data-ttu-id="c2d99-145">UWP アプリケーションには、アプリの生成に使用されるアプリケーション プラットフォームに基づいてフレームワークの依存関係を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-145">UWP applications can have framework dependencies based on the application platform used to generate the app.</span></span> <span data-ttu-id="c2d99-146">C# や VB を使っている場合、アプリには .NET Runtime と .NET Framework パッケージが必要になります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-146">If you are using C# or VB, the app will require the .NET Runtime and .NET framework packages.</span></span> <span data-ttu-id="c2d99-147">C++ アプリケーションには VCLibs が必要です。</span><span class="sxs-lookup"><span data-stu-id="c2d99-147">C++ applications require the VCLibs.</span></span>

>[!IMPORTANT] 
> <span data-ttu-id="c2d99-148">アプリ パッケージがリリース モード構成でビルドされた場合、フレームワークの依存関係は Microsoft Store から取得されます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-148">If the app package is built in Release mode configuration, the framework dependencies will be obtained from the Microsoft Store.</span></span> <span data-ttu-id="c2d99-149">ただし、アプリがデバッグ モード構成でビルドされた場合、依存関係は `.appinstaller` ファイルで指定された場所から取得されます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-149">However, if the app is built in Debug mode configuration, the dependencies will be obtained from the location specified in the `.appinstaller` file.</span></span>

### <a name="files-not-accessible"></a><span data-ttu-id="c2d99-150">ファイルにアクセスできない</span><span class="sxs-lookup"><span data-stu-id="c2d99-150">Files not accessible</span></span>

<span data-ttu-id="c2d99-151">HTTP エンドポイントからインストールする場合、すべてのファイルに正しい MIME タイプを使ってアクセスできることを確認することが重要です。</span><span class="sxs-lookup"><span data-stu-id="c2d99-151">When installing from an HTTP endpoint, it is important to verify that all files are accessible with the correct MIME type.</span></span> <span data-ttu-id="c2d99-152">これらのファイルを確認する最も簡単な方法として、Visual Studio によって生成された HTML ページにあるリンクに移動できます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-152">The easiest method to verify these files is by following the links provided in the HTML page generated by Visual Studio.</span></span> <span data-ttu-id="c2d99-153">以下のファイルを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-153">You must check these files:</span></span>

- `.appinstaller` <span data-ttu-id="c2d99-154">ファイル。使用可能: </span><span class="sxs-lookup"><span data-stu-id="c2d99-154">file, available as an</span></span> `application/xml`
- `.appx` <span data-ttu-id="c2d99-155">`.appxbundle` ファイル。使用可能: </span><span class="sxs-lookup"><span data-stu-id="c2d99-155">and `.appxbundle` files, available as</span></span> `application/vns.ms-appx`

## <a name="isolate-app-installer-app-issues"></a><span data-ttu-id="c2d99-156">アプリ インストーラー アプリの問題の切り分け</span><span class="sxs-lookup"><span data-stu-id="c2d99-156">Isolate App Installer app issues</span></span>

<span data-ttu-id="c2d99-157">アプリ インストーラー アプリがアプリをインストールできない場合、次の手順でインストールの問題を識別できます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-157">If the App Installer app cannot install the app, these steps will help identify the installation issue.</span></span>

### <a name="verify-app-package-file-installation"></a><span data-ttu-id="c2d99-158">アプリ パッケージ ファイルのインストールを確認します。</span><span class="sxs-lookup"><span data-stu-id="c2d99-158">Verify app package file installation</span></span>

- <span data-ttu-id="c2d99-159">アプリのパッケージ ファイルをローカル フォルダーにダウンロードし、 [Add-appxpackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) PowerShell コマンドを使用してインストールしてみます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-159">Download the app package file to a local folder and try to install it using the [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) PowerShell command.</span></span>

- <span data-ttu-id="c2d99-160">`.appinstaller` ファイルをローカル フォルダーにダウンロードし、`Add-AppxPackage -Appinstaller` PowerShell コマンドを使ってインストールしてみます。</span><span class="sxs-lookup"><span data-stu-id="c2d99-160">Download the `.appinstaller` file to a local folder and try to install it using the `Add-AppxPackage -Appinstaller` PowerShell command.</span></span>

## <a name="related-logs"></a><span data-ttu-id="c2d99-161">関連するログ</span><span class="sxs-lookup"><span data-stu-id="c2d99-161">Related Logs</span></span>

<span data-ttu-id="c2d99-162">アプリ展開インフラストラクチャには、Windows イベント ビューアーでデバッグするためのログが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c2d99-162">The app deployment infrastructure provides logs for debugging in the Windows Event Viewer.</span></span> <span data-ttu-id="c2d99-163">これらのログは以下の場所にあります。</span><span class="sxs-lookup"><span data-stu-id="c2d99-163">These logs are found here:</span></span> `Application and Services Logs->Microsoft->Windows->AppxDeployment-Server`



