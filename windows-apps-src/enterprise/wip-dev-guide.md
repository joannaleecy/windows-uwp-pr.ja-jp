---
author: normesta
Description: "このガイドは、Windows 情報保護 (WIP) ポリシーによって管理される企業データ、および個人データを処理するように、アプリを対応させる場合に役立ちます。"
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "Windows 情報保護 (WIP) 開発者向けガイド"
ms.author: normesta
ms.date: 06/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, WIP, Windows 情報保護, 企業データ, エンタープライズ データ保護, EDP, 対応アプリ"
ms.assetid: 913ac957-ea49-43b0-91b3-e0f6ca01ef2c
ms.openlocfilehash: 23604e4ca549bbb11885e681500f4f41531c2b6f
ms.sourcegitcommit: 5ece992c31870df4c089360ef47501bd4ce14fa9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/22/2017
---
# <a name="windows-information-protection-wip-developer-guide"></a><span data-ttu-id="30eea-104">Windows 情報保護 (WIP) 開発者向けガイド</span><span class="sxs-lookup"><span data-stu-id="30eea-104">Windows Information Protection (WIP) developer guide</span></span>

<span data-ttu-id="30eea-105">*対応*アプリは企業データと個人データを区別し、管理者によって定義された Windows 情報保護 (WIP) ポリシーに基づいて、どちらを保護するかを判別します。</span><span class="sxs-lookup"><span data-stu-id="30eea-105">An *enlightened* app differentiates between corporate and personal data and knows which to protect based on Windows Information Protection (WIP) policies defined by the administrator.</span></span>

<span data-ttu-id="30eea-106">このガイドでは、こうしたアプリの作成方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="30eea-106">In this guide, we'll show you how to build one.</span></span> <span data-ttu-id="30eea-107">アプリの作成が完了すると、ポリシー管理者はこのようなアプリを信頼し、アプリによる組織のデータの利用を許可することができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-107">When you're done, policy administrators will be able to trust your app to consume their organization's data.</span></span> <span data-ttu-id="30eea-108">また、従業員からも、組織のモバイル デバイス管理 (MDM) から登録を解除した場合や、完全に組織を去ることになった場合でも、デバイス上の個人データをそのまま残す方法が望まれています。</span><span class="sxs-lookup"><span data-stu-id="30eea-108">And employees will love that you've kept their personal data intact on their device even if they un-enroll from the organization's mobile device management (MDM) or leave the organization entirely.</span></span>

<span data-ttu-id="30eea-109">__注__ このガイドは、UWP アプリを対応アプリにするのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="30eea-109">__Note__ This guide helps you enlighten a UWP app.</span></span> <span data-ttu-id="30eea-110">C++ Windowsデスクトップ アプリを対応アプリにする場合は、「[Windows 情報保護 (WIP) 開発者向けガイド (C++)](http://go.microsoft.com/fwlink/?LinkId=822192)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30eea-110">If you want to enlighten a C++ Windows desktop app, see [Windows Information Protection (WIP) developer guide (C++)](http://go.microsoft.com/fwlink/?LinkId=822192).</span></span>

<span data-ttu-id="30eea-111">WIP と対応アプリについて詳しくは、「[Windows 情報保護 (WIP)](wip-hub.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30eea-111">You can read more about WIP and enlightened apps here: [Windows Information Protection (WIP)](wip-hub.md).</span></span>

<span data-ttu-id="30eea-112">完全なサンプルは、[ここ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/EnterpriseDataProtection)にあります。</span><span class="sxs-lookup"><span data-stu-id="30eea-112">You can find a complete sample [here](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/EnterpriseDataProtection).</span></span>

<span data-ttu-id="30eea-113">各作業を実行する準備ができたら、始めましょう。</span><span class="sxs-lookup"><span data-stu-id="30eea-113">If you're ready to go through each task, let's start.</span></span>

## <a name="first-gather-what-you-need"></a><span data-ttu-id="30eea-114">最初に必要なものを収集する</span><span class="sxs-lookup"><span data-stu-id="30eea-114">First, gather what you need</span></span>

<span data-ttu-id="30eea-115">以下が必要となります。</span><span class="sxs-lookup"><span data-stu-id="30eea-115">You'll need these:</span></span>

* <span data-ttu-id="30eea-116">Windows 10 Version 1607 以上を実行するテスト仮想マシン (VM)。</span><span class="sxs-lookup"><span data-stu-id="30eea-116">A test Virtual Machine (VM) that runs Windows 10, version 1607 or higher.</span></span> <span data-ttu-id="30eea-117">このテスト VM でアプリをデバッグします。</span><span class="sxs-lookup"><span data-stu-id="30eea-117">You'll debug your app against this test VM.</span></span>

* <span data-ttu-id="30eea-118">Windows 10 Version 1607 以上を実行している開発コンピューター。</span><span class="sxs-lookup"><span data-stu-id="30eea-118">A development computer that runs Windows 10, version 1607 or higher.</span></span> <span data-ttu-id="30eea-119">Visual Studio をテスト VM にインストールしている場合は、テスト VM を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="30eea-119">This could be your test VM if you have Visual Studio installed on it.</span></span>

## <a name="setup-your-development-environment"></a><span data-ttu-id="30eea-120">開発環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="30eea-120">Setup your development environment</span></span>

<span data-ttu-id="30eea-121">以下の作業を行います。</span><span class="sxs-lookup"><span data-stu-id="30eea-121">You'll do these things:</span></span>

* [<span data-ttu-id="30eea-122">テスト VM に WIP Setup Developer Assistant をインストールする</span><span class="sxs-lookup"><span data-stu-id="30eea-122">Install the WIP Setup Developer Assistant onto your test VM</span></span>](#install-assistant)

* [<span data-ttu-id="30eea-123">WIP Setup Developer Assistant を使用して保護ポリシーを作成する</span><span class="sxs-lookup"><span data-stu-id="30eea-123">Create a protection policy by using the WIP Setup Developer Assistant</span></span>](#create-protection-policy)

* [<span data-ttu-id="30eea-124">Visual Studio プロジェクトをセットアップする</span><span class="sxs-lookup"><span data-stu-id="30eea-124">Setup a Visual Studio project</span></span>](#setup-vs-project)

* [<span data-ttu-id="30eea-125">リモート デバッグをセットアップする</span><span class="sxs-lookup"><span data-stu-id="30eea-125">Setup remote debugging</span></span>](#setup-remote-debugging)

* [<span data-ttu-id="30eea-126">名前空間をコード ファイルに追加する</span><span class="sxs-lookup"><span data-stu-id="30eea-126">Add namespaces to your code files</span></span>](#add-namespaces)

<span id="install-assistant" />
### <a name="install-the-wip-setup-developer-assistant-onto-your-test-vm"></a><span data-ttu-id="30eea-127">テスト VM に WIP Setup Developer Assistant をインストールする</span><span class="sxs-lookup"><span data-stu-id="30eea-127">Install the WIP Setup Developer Assistant onto your test VM</span></span>

 <span data-ttu-id="30eea-128">テスト VM で Windows 情報保護ポリシーを設定するには、このツールを使用します。</span><span class="sxs-lookup"><span data-stu-id="30eea-128">Use this tool to setup a Windows Information Protection policy on your test VM.</span></span>

 <span data-ttu-id="30eea-129">このツールは、[WIP Setup Developer Assistant に関するページ](https://www.microsoft.com/store/p/wip-setup-developer-assistant/9nblggh526jf)でダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="30eea-129">Download the tool here: [WIP Setup Developer Assistant](https://www.microsoft.com/store/p/wip-setup-developer-assistant/9nblggh526jf).</span></span>
<span id="create-protection-policy" />
### <a name="create-a-protection-policy"></a><span data-ttu-id="30eea-130">保護ポリシーを作成する</span><span class="sxs-lookup"><span data-stu-id="30eea-130">Create a protection policy</span></span>

<span data-ttu-id="30eea-131">WIP Setup Developer Assistant 内の各セクションに情報を追加することによって、ポリシーを定義します。</span><span class="sxs-lookup"><span data-stu-id="30eea-131">Define your policy by adding information to each section in the WIP setup developer assistant.</span></span> <span data-ttu-id="30eea-132">その使用方法について詳しくは、すべての設定の横にある [ヘルプ] アイコンを選択します。</span><span class="sxs-lookup"><span data-stu-id="30eea-132">Choose the help icon next to any setting to learn more about how to use it.</span></span>

<span data-ttu-id="30eea-133">このツールの使用方法に関する一般的なガイダンスについては、アプリのダウンロード ページで、バージョンに関する注意事項のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="30eea-133">For more general guidance about how to use this tool, see the Version notes section on the app download page.</span></span>
<span id="setup-vs-project" />
### <a name="setup-a-visual-studio-project"></a><span data-ttu-id="30eea-134">Visual Studio プロジェクトをセットアップする</span><span class="sxs-lookup"><span data-stu-id="30eea-134">Setup a Visual Studio project</span></span>

1. <span data-ttu-id="30eea-135">開発コンピューターで、プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="30eea-135">On your development computer, open your project.</span></span>

2. <span data-ttu-id="30eea-136">ユニバーサル Windows プラットフォーム (UWP) 用のデスクトップ拡張機能とモバイル拡張機能への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="30eea-136">Add a reference to the desktop and mobile extensions for Universal Windows Platform (UWP).</span></span>

    ![UWP 拡張機能の追加](images/extensions.png)

3. <span data-ttu-id="30eea-138">次の機能をパッケージ マニフェスト ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="30eea-138">Add this capability to your package manifest file:</span></span>

    ```xml
       <rescap:Capability Name="enterpriseDataPolicy"/>
    ```
   ><span data-ttu-id="30eea-139">*参考情報*: "rescap" プレフィックスは、*制限された機能* を意味しています。</span><span class="sxs-lookup"><span data-stu-id="30eea-139">*Optional Reading*: The "rescap" prefix means *Restricted Capability*.</span></span> <span data-ttu-id="30eea-140">「[特殊な用途および制限された用途に関する機能](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30eea-140">See [Special and restricted capabilities](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations).</span></span>

4. <span data-ttu-id="30eea-141">次の名前空間をパッケージ マニフェスト ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="30eea-141">Add this namespace to your package manifest file:</span></span>

    ```xml
      xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
    ```
5. <span data-ttu-id="30eea-142">名前空間のプレフィックスをパッケージ マニフェスト ファイルの ``<ignorableNamespaces>`` 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="30eea-142">Add the namespace prefix to the ``<ignorableNamespaces>`` element of your package manifest file.</span></span>

    ```xml
        <IgnorableNamespaces="uap mp rescap">
    ```

    <span data-ttu-id="30eea-143">このようにすることで、制限された機能をサポートしていないバージョンの Windows オペレーティング システムでアプリを実行した場合に、Windows は ``enterpriseDataPolicy`` 機能を無視します。</span><span class="sxs-lookup"><span data-stu-id="30eea-143">This way, if your app runs on a version of the Windows operating system that doesn't support restricted capabilities, Windows will ignore the ``enterpriseDataPolicy`` capability.</span></span>
<span id="setup-remote-debugging" />
### <a name="setup-remote-debugging"></a><span data-ttu-id="30eea-144">リモート デバッグをセットアップする</span><span class="sxs-lookup"><span data-stu-id="30eea-144">Setup remote debugging</span></span>

<span data-ttu-id="30eea-145">VM 以外のコンピューターでアプリを開発している場合にのみ、テスト VM に Visual Studio リモート ツールをインストールします。</span><span class="sxs-lookup"><span data-stu-id="30eea-145">Install Visual Studio Remote Tools on your test VM only if you are developing your app on a computer other than your VM.</span></span> <span data-ttu-id="30eea-146">次に、開発用コンピューターでリモート デバッガーを起動し、アプリがテスト VM で実行されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="30eea-146">Then, on your development computer start the remote debugger and see if your app runs on the test VM.</span></span>

<span data-ttu-id="30eea-147">「[リモート PC の手順](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#remote-pc-instructions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30eea-147">See [Remote PC instructions](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#remote-pc-instructions).</span></span>
<span id="add-namespaces" />
### <a name="add-these-namespaces-to-your-code-files"></a><span data-ttu-id="30eea-148">名前空間をコード ファイルに追加する</span><span class="sxs-lookup"><span data-stu-id="30eea-148">Add these namespaces to your code files</span></span>

<span data-ttu-id="30eea-149">以下の using ステートメントをコード ファイルの先頭に追加します (このガイドのスニペットでこれらのステートメントが使用されます)。</span><span class="sxs-lookup"><span data-stu-id="30eea-149">Add these using statements to the top of your code files(The snippets in this guide use them):</span></span>

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.EnterpriseData;
using Windows.Web.Http;
using Windows.Storage.Streams;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Activation;
using Windows.Web.Http.Filters;
using Windows.Storage;
using Windows.Data.Xml.Dom;
using Windows.Foundation.Metadata;
using Windows.Web.Http.Headers;
```

## <a name="determine-whether-to-use-wip-apis-in-your-app"></a><span data-ttu-id="30eea-150">アプリで WIP API を使用するかどうかを決定する</span><span class="sxs-lookup"><span data-stu-id="30eea-150">Determine whether to use WIP APIs in your app</span></span>

<span data-ttu-id="30eea-151">アプリを実行するオペレーティング システムが WIP をサポートしていることと、デバイスで WIP が有効になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="30eea-151">Ensure that the operating system that runs your app supports WIP and that WIP is enabled on the device.</span></span>

```csharp
bool use_WIP_APIs = false;

if ((ApiInformation.IsApiContractPresent
    ("Windows.Security.EnterpriseData.EnterpriseDataContract", 3)
    && ProtectionPolicyManager.IsProtectionEnabled))
{
    use_WIP_APIs = true;
}
else
{
    use_WIP_APIs = false;
}
```
<span data-ttu-id="30eea-152">オペレーティング システムが WIP をサポートしていない場合や、デバイスで WIP が有効になっていない場合は、WIP API を呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="30eea-152">Don't call WIP APIs if the operating system doesn't support WIP or WIP is not enabled on the device.</span></span>

## <a name="read-enterprise-data"></a><span data-ttu-id="30eea-153">企業データの読み取り</span><span class="sxs-lookup"><span data-stu-id="30eea-153">Read enterprise data</span></span>

<span data-ttu-id="30eea-154">保護されたファイル、ネットワーク エンドポイント、クリップボード データ、および共有コントラクトから受け取ったデータを読み取るには、アプリがアクセスを要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30eea-154">To read protected files, network endpoints, clipboard data and data that you accept from a Share contract, your app will have to request access.</span></span>

<span data-ttu-id="30eea-155">Windows 情報保護は、アプリが保護ポリシーの許可一覧にある場合、アプリにアクセス許可を付与します。</span><span class="sxs-lookup"><span data-stu-id="30eea-155">Windows Information Protection gives your app permission if your app is on the protection policy's allowed list.</span></span>

**<span data-ttu-id="30eea-156">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="30eea-156">In this section:</span></span>**

* [<span data-ttu-id="30eea-157">データをファイルから読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-157">Read data from a file</span></span>](#read-file)
* [<span data-ttu-id="30eea-158">データをネットワーク エンドポイントから読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-158">Read data from a network endpoint</span></span>](#read-network)
* [<span data-ttu-id="30eea-159">クリップボードからデータを読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-159">Read data from the clipboard</span></span>](#read-clipboard)
* [<span data-ttu-id="30eea-160">共有コントラクトからデータを読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-160">Read data from a Share contract</span></span>](#read-contract)

<span id="read-file" />
### <a name="read-data-from-a-file"></a><span data-ttu-id="30eea-161">データをファイルから読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-161">Read data from a file</span></span>

**<span data-ttu-id="30eea-162">手順 1: ファイル ハンドルを取得する</span><span class="sxs-lookup"><span data-stu-id="30eea-162">Step 1: Get the file handle</span></span>**

```csharp
    Windows.Storage.StorageFolder storageFolder =
        Windows.Storage.ApplicationData.Current.LocalFolder;

    Windows.Storage.StorageFile file =
        await storageFolder.GetFileAsync(fileName);
```

**<span data-ttu-id="30eea-163">手順 2: アプリでファイルを開くことができるかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="30eea-163">Step 2: Determine whether your app can open the file</span></span>**

<span data-ttu-id="30eea-164">[FileProtectionManager.GetProtectionInfoAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.getprotectioninfoasync.aspx) を呼び出して、アプリでファイルを開くことができるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="30eea-164">Call [FileProtectionManager.GetProtectionInfoAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.getprotectioninfoasync.aspx) to determine whether your app can open the file.</span></span>

```csharp
FileProtectionInfo protectionInfo = await FileProtectionManager.GetProtectionInfoAsync(file);

if ((protectionInfo.Status != FileProtectionStatus.Protected &&
    protectionInfo.Status != FileProtectionStatus.Unprotected))
{
    return false;
}
else if (protectionInfo.Status == FileProtectionStatus.Revoked)
{
    // Code goes here to handle this situation. Perhaps, show UI
    // saying that the user's data has been revoked.
}
```

<span data-ttu-id="30eea-165">[FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx) の値が **Protected** である場合、ファイルは保護されており、アプリがポリシーの許可リストに含まれているため、アプリでファイルを開くことができることを意味します。</span><span class="sxs-lookup"><span data-stu-id="30eea-165">A [FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx) value of **Protected** means that the file is protected and your app can open it because your app is on the policy's allowed list.</span></span>

<span data-ttu-id="30eea-166">[FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx) の値が **UnProtected** である場合、ファイルは保護されていないため、アプリがポリシーの許可リストになくても、アプリでファイルを開くことができることをいみします。</span><span class="sxs-lookup"><span data-stu-id="30eea-166">A [FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx) value of **UnProtected** means that the file is not protected and your app can open the file even your app is not on the policy's allowed list.</span></span>

> **<span data-ttu-id="30eea-167">API</span><span class="sxs-lookup"><span data-stu-id="30eea-167">APIs</span></span>** <br>
[<span data-ttu-id="30eea-168">FileProtectionManager.GetProtectionInfoAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-168">FileProtectionManager.GetProtectionInfoAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.getprotectioninfoasync.aspx)<br>
[<span data-ttu-id="30eea-169">FileProtectionInfo</span><span class="sxs-lookup"><span data-stu-id="30eea-169">FileProtectionInfo</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.aspx)<br>
[<span data-ttu-id="30eea-170">FileProtectionStatus</span><span class="sxs-lookup"><span data-stu-id="30eea-170">FileProtectionStatus</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>
[<span data-ttu-id="30eea-171">ProtectionPolicyManager.IsIdentityManaged</span><span class="sxs-lookup"><span data-stu-id="30eea-171">ProtectionPolicyManager.IsIdentityManaged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)

**<span data-ttu-id="30eea-172">手順 3: ファイルをストリームまたはバッファーに読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-172">Step 3: Read the file into a stream or buffer</span></span>**

*<span data-ttu-id="30eea-173">ファイルをストリームに読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-173">Read the file into a stream</span></span>*

```csharp
var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
```

*<span data-ttu-id="30eea-174">ファイルをバッファーに読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-174">Read the file into a buffer</span></span>*

```csharp
var buffer = await Windows.Storage.FileIO.ReadBufferAsync(file);
```
<span id="read-network" />
### <a name="read-data-from-a-network-endpoint"></a><span data-ttu-id="30eea-175">データをネットワーク エンドポイントから読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-175">Read data from a network endpoint</span></span>

<span data-ttu-id="30eea-176">企業のエンドポイントから読み取るように、保護されたスレッド コンテキストを作成します。</span><span class="sxs-lookup"><span data-stu-id="30eea-176">Create a protected thread context to read from an enterprise endpoint.</span></span>

**<span data-ttu-id="30eea-177">手順 1: ネットワーク エンドポイントの ID を取得する</span><span class="sxs-lookup"><span data-stu-id="30eea-177">Step 1: Get the identity of the network endpoint</span></span>**

```csharp
Uri resourceURI = new Uri("http://contoso.com/stockData.xml");

Windows.Networking.HostName hostName =
    new Windows.Networking.HostName(resourceURI.Host);

string identity = await ProtectionPolicyManager.
    GetPrimaryManagedIdentityForNetworkEndpointAsync(hostName);
```

<span data-ttu-id="30eea-178">エンドポイントがポリシーによって管理されていない場合、空の文字が返されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-178">If the endpoint isn't managed by policy, you'll get back an empty string.</span></span>

> **<span data-ttu-id="30eea-179">API</span><span class="sxs-lookup"><span data-stu-id="30eea-179">APIs</span></span>** <br>
[<span data-ttu-id="30eea-180">ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-180">ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getprimarymanagedidentityfornetworkendpointasync.aspx)


**<span data-ttu-id="30eea-181">手順 2: 保護されたスレッド コンテキストを作成する</span><span class="sxs-lookup"><span data-stu-id="30eea-181">Step 2: Create a protected thread context</span></span>**

<span data-ttu-id="30eea-182">エンドポイントがポリシーによって管理されている場合は、保護されたスレッド コンテキストを作成します。</span><span class="sxs-lookup"><span data-stu-id="30eea-182">If the endpoint is managed by policy, create a protected thread context.</span></span> <span data-ttu-id="30eea-183">これにより、同じスレッドで確立されるネットワーク接続が、ID にタグ付けされます。</span><span class="sxs-lookup"><span data-stu-id="30eea-183">This tags any network connections that you make on the same thread to the identity.</span></span>

<span data-ttu-id="30eea-184">また、そのポリシーによって管理されている企業のネットワーク リソースにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="30eea-184">It also gives you access to enterprise network resources that are managed by that policy.</span></span>

```csharp
if (!string.IsNullOrEmpty(identity))
{
    using (ThreadNetworkContext threadNetworkContext =
            ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
    {
        return await GetDataFromNetworkRedirectHelperMethod(resourceURI);
    }
}
else
{
    return await GetDataFromNetworkRedirectHelperMethod(resourceURI);
}
```
<span data-ttu-id="30eea-185">この例では、ソケット呼び出しが ``using`` ブロック内に指定されています。</span><span class="sxs-lookup"><span data-stu-id="30eea-185">This example encloses socket calls in a ``using`` block.</span></span> <span data-ttu-id="30eea-186">これを行わない場合は、リソースを取得した後で、スレッド コンテキストを必ず閉じてください。</span><span class="sxs-lookup"><span data-stu-id="30eea-186">If you don't do this, make sure that you close the thread context after you've retrieved your resource.</span></span> <span data-ttu-id="30eea-187">「[ThreadNetworkContext.Close](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.threadnetworkcontext.close.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30eea-187">See [ThreadNetworkContext.Close](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.threadnetworkcontext.close.aspx).</span></span>

<span data-ttu-id="30eea-188">この保護されたスレッド上には個人用ファイルを作成しないでください。それらのファイルは自動的に暗号化されるためです。</span><span class="sxs-lookup"><span data-stu-id="30eea-188">Don't create any personal files on that protected thread because those files will be automatically encrypted.</span></span>

<span data-ttu-id="30eea-189">[**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx) メソッドは、エンドポイントがポリシーによって管理されているかどうかに関係なく、[**ThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.threadnetworkcontext.aspx) オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="30eea-189">The [**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx) method returns a [**ThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.threadnetworkcontext.aspx) object whether or not the endpoint is being managed by policy.</span></span> <span data-ttu-id="30eea-190">アプリで個人のリソースと企業のリソースの両方を処理する場合は、すべての ID に対して [**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx) を呼び出してください。</span><span class="sxs-lookup"><span data-stu-id="30eea-190">If your app handles both personal and enterprise resources, call [**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx) for all identities.</span></span>  <span data-ttu-id="30eea-191">リソースを取得したら、ThreadNetworkContext を破棄して、現在のスレッドからすべての ID タグを消去します。</span><span class="sxs-lookup"><span data-stu-id="30eea-191">After you get the resource, dispose the ThreadNetworkContext to clear any identity tag from the current thread.</span></span>

> **<span data-ttu-id="30eea-192">API</span><span class="sxs-lookup"><span data-stu-id="30eea-192">APIs</span></span>** <br>
[<span data-ttu-id="30eea-193">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-193">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-194">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-194">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)<br>
[<span data-ttu-id="30eea-195">ProtectionPolicyManager.CreateCurrentThreadNetworkContext</span><span class="sxs-lookup"><span data-stu-id="30eea-195">ProtectionPolicyManager.CreateCurrentThreadNetworkContext</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx)

**<span data-ttu-id="30eea-196">手順 3: リソースをバッファーに読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-196">Step 3: Read the resource into a buffer</span></span>**

```csharp
private static async Task<IBuffer> GetDataFromNetworkHelperMethod(Uri resourceURI)
{
    HttpClient client;

    client = new HttpClient();

    try { return await client.GetBufferAsync(resourceURI); }

    catch (Exception) { return null; }
}
```

**<span data-ttu-id="30eea-197">(省略可能) 保護されたスレッド コンテキストを作成する代わりにヘッダー トークンを使用する</span><span class="sxs-lookup"><span data-stu-id="30eea-197">(Optional) Use a header token instead of creating a protected thread context</span></span>**

```csharp
public static async Task<IBuffer> GetDataFromNetworkbyUsingHeader(Uri resourceURI)
{
    HttpClient client;

    Windows.Networking.HostName hostName =
        new Windows.Networking.HostName(resourceURI.Host);

    string identity = await ProtectionPolicyManager.
        GetPrimaryManagedIdentityForNetworkEndpointAsync(hostName);

    if (!string.IsNullOrEmpty(identity))
    {
        client = new HttpClient();

        HttpRequestHeaderCollection headerCollection = client.DefaultRequestHeaders;

        headerCollection.Add("X-MS-Windows-HttpClient-EnterpriseId", identity);

        return await GetDataFromNetworkbyUsingHeaderHelperMethod(client, resourceURI);
    }
    else
    {
        client = new HttpClient();
        return await GetDataFromNetworkbyUsingHeaderHelperMethod(client, resourceURI);
    }

}

private static async Task<IBuffer> GetDataFromNetworkbyUsingHeaderHelperMethod(HttpClient client, Uri resourceURI)
{

    try { return await client.GetBufferAsync(resourceURI); }

    catch (Exception) { return null; }
}
```

**<span data-ttu-id="30eea-198">ページのリダイレクトを処理する</span><span class="sxs-lookup"><span data-stu-id="30eea-198">Handle page redirects</span></span>**

<span data-ttu-id="30eea-199">Web サーバーは、トラフィックをより最新バージョンのリソースにリダイレクトする場合があります。</span><span class="sxs-lookup"><span data-stu-id="30eea-199">Sometimes a web server will redirect traffic to a more current version of a resource.</span></span>

<span data-ttu-id="30eea-200">これを処理するには、要求の応答状態の値が **OK** になるまで要求を行います。</span><span class="sxs-lookup"><span data-stu-id="30eea-200">To handle this, make requests until the response status of your request has a value of **OK**.</span></span>

<span data-ttu-id="30eea-201">その後で、その応答の URI を使用して、エンドポイントの ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="30eea-201">Then use the URI of that response to get the identity of the endpoint.</span></span> <span data-ttu-id="30eea-202">その方法の 1 つを次に示します。</span><span class="sxs-lookup"><span data-stu-id="30eea-202">Here's one way to do this:</span></span>

```csharp
private static async Task<IBuffer> GetDataFromNetworkRedirectHelperMethod(Uri resourceURI)
{
    HttpClient client = null;

    HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
    filter.AllowAutoRedirect = false;

    client = new HttpClient(filter);

    HttpResponseMessage response = null;

        HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, resourceURI);
        response = await client.SendRequestAsync(message);

    if (response.StatusCode == HttpStatusCode.MultipleChoices ||
        response.StatusCode == HttpStatusCode.MovedPermanently ||
        response.StatusCode == HttpStatusCode.Found ||
        response.StatusCode == HttpStatusCode.SeeOther ||
        response.StatusCode == HttpStatusCode.NotModified ||
        response.StatusCode == HttpStatusCode.UseProxy ||
        response.StatusCode == HttpStatusCode.TemporaryRedirect ||
        response.StatusCode == HttpStatusCode.PermanentRedirect)
    {
        message = new HttpRequestMessage(HttpMethod.Get, message.RequestUri);
        response = await client.SendRequestAsync(message);

        try { return await response.Content.ReadAsBufferAsync(); }

        catch (Exception) { return null; }
    }
    else
    {
        try { return await response.Content.ReadAsBufferAsync(); }

        catch (Exception) { return null; }
    }
}

```

> **<span data-ttu-id="30eea-203">API</span><span class="sxs-lookup"><span data-stu-id="30eea-203">APIs</span></span>** <br>
[<span data-ttu-id="30eea-204">ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-204">ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getprimarymanagedidentityfornetworkendpointasync.aspx)<br>
[<span data-ttu-id="30eea-205">ProtectionPolicyManager.CreateCurrentThreadNetworkContext</span><span class="sxs-lookup"><span data-stu-id="30eea-205">ProtectionPolicyManager.CreateCurrentThreadNetworkContext</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx)<br>
[<span data-ttu-id="30eea-206">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-206">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-207">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-207">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

<span id="read-clipboard" />
### <a name="read-data-from-the-clipboard"></a><span data-ttu-id="30eea-208">クリップボードからデータを読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-208">Read data from the clipboard</span></span>

**<span data-ttu-id="30eea-209">クリップボードからのデータを使用するアクセス許可を取得する</span><span class="sxs-lookup"><span data-stu-id="30eea-209">Get permission to use data from the clipboard</span></span>**

<span data-ttu-id="30eea-210">クリップボードからデータを取得するには、アクセス許可を Windows に要求します。</span><span class="sxs-lookup"><span data-stu-id="30eea-210">To get data from the clipboard, ask Windows for permission.</span></span> <span data-ttu-id="30eea-211">そのためには、[**DataPackageView.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx) を使用します。</span><span class="sxs-lookup"><span data-stu-id="30eea-211">Use [**DataPackageView.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx) to do that.</span></span>

```csharp
public static async Task PasteText(TextBox textBox)
{
    DataPackageView dataPackageView = Clipboard.GetContent();

    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        ProtectionPolicyEvaluationResult result = await dataPackageView.RequestAccessAsync();

        if (result == ProtectionPolicyEvaluationResult..Allowed)
        {
            string contentsOfClipboard = await dataPackageView.GetTextAsync();
            textBox.Text = contentsOfClipboard;
        }
    }
}
```

> **<span data-ttu-id="30eea-212">API</span><span class="sxs-lookup"><span data-stu-id="30eea-212">APIs</span></span>** <br>
[<span data-ttu-id="30eea-213">DataPackageView.RequestAccessAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-213">DataPackageView.RequestAccessAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx)

**<span data-ttu-id="30eea-214">クリップボードのデータを使用する機能を非表示にするか、無効にする</span><span class="sxs-lookup"><span data-stu-id="30eea-214">Hide or disable features that use clipboard data</span></span>**

<span data-ttu-id="30eea-215">現在のビューにクリップボードのデータを取得するためのアクセス許可があるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="30eea-215">Determine whether current view has permission to get data that is on the clipboard.</span></span>

<span data-ttu-id="30eea-216">アクセス許可がない場合は、ユーザーがクリップボードから情報を貼り付けたり、クリップボードの内容をプレビューしたりするためのコントロールを無効または非表示にすることができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-216">If it doesn't, you can disable or hide controls that let users paste information from the clipboard or preview its contents.</span></span>

```csharp
private bool IsClipboardAllowedAsync()
{
    ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult = ProtectionPolicyEvaluationResult.Blocked;

    DataPackageView dataPackageView = Clipboard.GetContent();

    if (dataPackageView.Contains(StandardDataFormats.Text))

        protectionPolicyEvaluationResult =
            ProtectionPolicyManager.CheckAccess(dataPackageView.Properties.EnterpriseId,
                ProtectionPolicyManager.GetForCurrentView().Identity);

    return (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed |
        protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.ConsentRequired);
}
```

> **<span data-ttu-id="30eea-217">API</span><span class="sxs-lookup"><span data-stu-id="30eea-217">APIs</span></span>** <br>
[<span data-ttu-id="30eea-218">ProtectionPolicyEvaluationResult</span><span class="sxs-lookup"><span data-stu-id="30eea-218">ProtectionPolicyEvaluationResult</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicyevaluationresult.aspx)<br>
[<span data-ttu-id="30eea-219">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-219">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-220">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-220">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

**<span data-ttu-id="30eea-221">ユーザーに対して同意ダイアログ ボックスが表示されないようにする</span><span class="sxs-lookup"><span data-stu-id="30eea-221">Prevent users from being prompted with a consent dialog box</span></span>**

<span data-ttu-id="30eea-222">新しいドキュメントは、*個人用*でも*企業用*でもありません。</span><span class="sxs-lookup"><span data-stu-id="30eea-222">A new document isn't *personal* or *enterprise*.</span></span> <span data-ttu-id="30eea-223">そのドキュメントは、単なる新規のドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="30eea-223">It's just new.</span></span> <span data-ttu-id="30eea-224">ユーザーが企業データをそのドキュメントに貼り付ける場合、Windows によってポリシーが適用され、ユーザーに対して同意ダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-224">If a user pastes enterprise data into it, Windows enforces policy and the user is prompted with a consent dialog.</span></span> <span data-ttu-id="30eea-225">次のコードを使用すると、このような状況が発生しなくなります。</span><span class="sxs-lookup"><span data-stu-id="30eea-225">This code prevents that from happening.</span></span> <span data-ttu-id="30eea-226">このタスクは、データの保護に役立つものではありません。</span><span class="sxs-lookup"><span data-stu-id="30eea-226">This task is not about helping to protect data.</span></span> <span data-ttu-id="30eea-227">このタスクは、アプリで完全に新規の項目を作成する場合に、同意ダイアログ ボックスがユーザーに表示されなくするためのものです。</span><span class="sxs-lookup"><span data-stu-id="30eea-227">It's more about keeping users from receiving the consent dialog box in cases where your app creates a brand new item.</span></span>

```csharp
private async void PasteText(bool isNewEmptyDocument)
{
    DataPackageView dataPackageView = Clipboard.GetContent();

    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        if (!string.IsNullOrEmpty(dataPackageView.Properties.EnterpriseId))
        {
            if (isNewEmptyDocument)
            {
                ProtectionPolicyManager.TryApplyProcessUIPolicy(dataPackageView.Properties.EnterpriseId);
                string contentsOfClipboard = contentsOfClipboard = await dataPackageView.GetTextAsync();
                // add this string to the new item or document here.          

            }
            else
            {
                ProtectionPolicyEvaluationResult result = await dataPackageView.RequestAccessAsync();

                if (result == ProtectionPolicyEvaluationResult.Allowed)
                {
                    string contentsOfClipboard = contentsOfClipboard = await dataPackageView.GetTextAsync();
                    // add this string to the new item or document here.
                }
            }
        }
    }
}
```

> **<span data-ttu-id="30eea-228">API</span><span class="sxs-lookup"><span data-stu-id="30eea-228">APIs</span></span>** <br>
[<span data-ttu-id="30eea-229">DataPackageView.RequestAccessAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-229">DataPackageView.RequestAccessAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx)<br>
[<span data-ttu-id="30eea-230">ProtectionPolicyEvaluationResult</span><span class="sxs-lookup"><span data-stu-id="30eea-230">ProtectionPolicyEvaluationResult</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicyevaluationresult.aspx)<br>
[<span data-ttu-id="30eea-231">ProtectionPolicyManager.TryApplyProcessUIPolicy</span><span class="sxs-lookup"><span data-stu-id="30eea-231">ProtectionPolicyManager.TryApplyProcessUIPolicy</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.tryapplyprocessuipolicy.aspx)

<span id="read-share" />
### <a name="read-data-from-a-share-contract"></a><span data-ttu-id="30eea-232">共有コントラクトからデータを読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-232">Read data from a Share contract</span></span>

<span data-ttu-id="30eea-233">従業員がアプリで自分の情報を共有するように選んだ場合、アプリではその情報の内容を含んでいる新しい項目が開きます。</span><span class="sxs-lookup"><span data-stu-id="30eea-233">When employees choose your app to share their information, your app will open a new item that contains that content.</span></span>

<span data-ttu-id="30eea-234">前に説明したとおり、新しい項目は*個人用*でも*企業用*でもありません。</span><span class="sxs-lookup"><span data-stu-id="30eea-234">As we mentioned earlier, a new item isn't *personal* or *enterprise*.</span></span> <span data-ttu-id="30eea-235">単なる新規の項目です。</span><span class="sxs-lookup"><span data-stu-id="30eea-235">It's just new.</span></span> <span data-ttu-id="30eea-236">コードで企業のコンテンツを項目に追加する場合、Windows によってポリシーが適用され、ユーザーに対して同意ダイアログ ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-236">If your code adds enterprise content to the item, Windows enforces policy and the user is prompted with a consent dialog.</span></span> <span data-ttu-id="30eea-237">次のコードを使用すると、このような状況が発生しなくなります。</span><span class="sxs-lookup"><span data-stu-id="30eea-237">This code prevents that from happening.</span></span>

```csharp
protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    bool isNewEmptyDocument = true;
    string identity = "corp.microsoft.com";

    ShareOperation shareOperation = args.ShareOperation;
    if (shareOperation.Data.Contains(StandardDataFormats.Text))
    {
        if (!string.IsNullOrEmpty(shareOperation.Data.Properties.EnterpriseId))
        {
            if (isNewEmptyDocument)
                // If this is a new and empty document, and we're allowed to access
                // the data, then we can avoid popping the consent dialog
                ProtectionPolicyManager.TryApplyProcessUIPolicy(shareOperation.Data.Properties.EnterpriseId);
            else
            {
                // In this case, we can't optimize the workflow, so we just
                // request consent from the user in this case.

                ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult = await shareOperation.Data.RequestAccessAsync();

                if (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed)
                {
                    string text = await shareOperation.Data.GetTextAsync();

                    // Do something with that text.
                }
            }
        }
        else
        {
            // If the data has no enterprise identity, then we already have access.
            string text = await shareOperation.Data.GetTextAsync();

            // Do something with that text.
        }

    }

}
```

> **<span data-ttu-id="30eea-238">API</span><span class="sxs-lookup"><span data-stu-id="30eea-238">APIs</span></span>** <br>
[<span data-ttu-id="30eea-239">ProtectionPolicyManager.RequestAccessAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-239">ProtectionPolicyManager.RequestAccessAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/dn705789.aspx)<br>
[<span data-ttu-id="30eea-240">ProtectionPolicyEvaluationResult</span><span class="sxs-lookup"><span data-stu-id="30eea-240">ProtectionPolicyEvaluationResult</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicyevaluationresult.aspx)<br>
[<span data-ttu-id="30eea-241">ProtectionPolicyManager.TryApplyProcessUIPolicy</span><span class="sxs-lookup"><span data-stu-id="30eea-241">ProtectionPolicyManager.TryApplyProcessUIPolicy</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.tryapplyprocessuipolicy.aspx)

## <a name="protect-enterprise-data"></a><span data-ttu-id="30eea-242">企業データの保護</span><span class="sxs-lookup"><span data-stu-id="30eea-242">Protect enterprise data</span></span>

<span data-ttu-id="30eea-243">アプリの外部に送られる企業データを保護します。</span><span class="sxs-lookup"><span data-stu-id="30eea-243">Protect enterprise data that leaves your app.</span></span> <span data-ttu-id="30eea-244">データをページ内に表示するとき、データをファイルやネットワーク エンドポイントに保存するとき、または共有コントラクトを使用してデータを保存するときに、データはアプリの外部に送られます。</span><span class="sxs-lookup"><span data-stu-id="30eea-244">Data leaves your app when you show it in a page, save it to a file or network endpoint, or through a share contract.</span></span>

**<span data-ttu-id="30eea-245">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="30eea-245">In this section:</span></span>**

* [<span data-ttu-id="30eea-246">ページ内に表示されるデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-246">Protect data that appears in pages</span></span>](#protect-pages)
* [<span data-ttu-id="30eea-247">バック グラウンド プロセスとして、データをファイルで保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-247">Protect data to a file as a background process</span></span>](#protect-background)
* [<span data-ttu-id="30eea-248">ファイルの一部を保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-248">Protect part of a file</span></span>](#protect-part-file)
* [<span data-ttu-id="30eea-249">ファイルの保護されている部分を読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-249">Read the protected part of a file</span></span>](#read-protected)
* [<span data-ttu-id="30eea-250">フォルダーでデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-250">Protect data to a folder</span></span>](#protect-folder)
* [<span data-ttu-id="30eea-251">ネットワーク エンドポイントでデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-251">Protect data to a network end point</span></span>](#protect-network)
* [<span data-ttu-id="30eea-252">アプリが共有コントラクトを介して共有しているデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-252">Protect data that your app shares through a share contract</span></span>](#protect-share)
* [<span data-ttu-id="30eea-253">別の場所にコピーしたファイルを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-253">Protect files that you copy to another location</span></span>](#protect-other-location)
* [<span data-ttu-id="30eea-254">デバイスの画面がロックされているときに、企業データを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-254">Protect enterprise data when the screen of the device is locked</span></span>](#protect-locked)

<span id="protect-pages" />
### <a name="protect-data-that-appears-in-pages"></a><span data-ttu-id="30eea-255">ページ内に表示されるデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-255">Protect data that appears in pages</span></span>

<span data-ttu-id="30eea-256">データをページ内に表示するとき、Windows に対して、そのデータの種類 (個人用または企業用) を知らせます。</span><span class="sxs-lookup"><span data-stu-id="30eea-256">When you show data in a page, let Windows know what type of data it is (personal or enterprise).</span></span> <span data-ttu-id="30eea-257">そのためには、現在のアプリ ビューに*タグ*を付けるか、アプリのプロセス全体にタグを付けます。</span><span class="sxs-lookup"><span data-stu-id="30eea-257">To do that, *tag* the current app view or tag the entire app process.</span></span>

<span data-ttu-id="30eea-258">ビューまたはプロセスにタグを付けるとき、Windows によってポリシーが適用されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-258">When you tag the view or the process, Windows enforces policy on it.</span></span> <span data-ttu-id="30eea-259">これにより、アプリで制御できない操作に起因するデータ漏洩を防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-259">This helps prevent data leaks that result from actions that your app doesn't control.</span></span> <span data-ttu-id="30eea-260">たとえば、コンピューターでユーザーが Ctrl + V キーを使用して、ビューから企業の情報をコピーし、その情報を他のアプリに貼り付けるとします。</span><span class="sxs-lookup"><span data-stu-id="30eea-260">For example, on a computer, a user could use CTRL-V to copy enterprise information from a view and then paste that information to another app.</span></span> <span data-ttu-id="30eea-261">Windows では、この操作が行われるのを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="30eea-261">Windows protects against that.</span></span> <span data-ttu-id="30eea-262">また Windows は、共有コントラクトを適用する際にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="30eea-262">Windows also helps to enforce share contracts.</span></span>

**<span data-ttu-id="30eea-263">現在のアプリ ビューにタグを付ける</span><span class="sxs-lookup"><span data-stu-id="30eea-263">Tag the current app view</span></span>**

<span data-ttu-id="30eea-264">アプリに複数のビューがあり、一部のビューで企業データを扱い、一部のビューで個人データを扱う場合に、この操作を行います。</span><span class="sxs-lookup"><span data-stu-id="30eea-264">Do this if your app has multiple views where some views consume enterprise data and some consume personal data.</span></span>

```csharp

// tag as enterprise data. "identity" the string that contains the enterprise ID.
// You'd get that from a file, network endpoint, or clipboard data package.
ProtectionPolicyManager.GetForCurrentView().Identity = identity;

// tag as personal data.
ProtectionPolicyManager.GetForCurrentView().Identity = String.Empty();
```

> **<span data-ttu-id="30eea-265">API</span><span class="sxs-lookup"><span data-stu-id="30eea-265">APIs</span></span>** <br>
[<span data-ttu-id="30eea-266">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-266">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-267">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-267">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

**<span data-ttu-id="30eea-268">プロセスにタグを付ける</span><span class="sxs-lookup"><span data-stu-id="30eea-268">Tag the process</span></span>**

<span data-ttu-id="30eea-269">アプリ内のすべてのビューで 1 種類だけのデータ (個人データまたは企業データ) を扱う場合に、この操作を行います。</span><span class="sxs-lookup"><span data-stu-id="30eea-269">Do this if all views in your app will work with only one type of data (personal or enterprise).</span></span>

<span data-ttu-id="30eea-270">これによって、個別にタグ付けされたビューを管理する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="30eea-270">This prevents you from having to manage independently tagged views.</span></span>

```csharp


// tag as enterprise data. "identity" the string that contains the enterprise ID.
// You'd get that from a file, network endpoint, or clipboard data package.
bool result =
            ProtectionPolicyManager.TryApplyProcessUIPolicy(identity);

// tag as personal data.
bool result =
            ProtectionPolicyManager.TryApplyProcessUIPolicy(String.Empty());
```

> **<span data-ttu-id="30eea-271">API</span><span class="sxs-lookup"><span data-stu-id="30eea-271">APIs</span></span>** <br>
[<span data-ttu-id="30eea-272">ProtectionPolicyManager.TryApplyProcessUIPolicy</span><span class="sxs-lookup"><span data-stu-id="30eea-272">ProtectionPolicyManager.TryApplyProcessUIPolicy</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.tryapplyprocessuipolicy.aspx)

<span id="protect-file" />
### <a name="protect-data-to-a-file"></a><span data-ttu-id="30eea-273">ファイルでデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-273">Protect data to a file</span></span>

<span data-ttu-id="30eea-274">保護されたファイルを作成し、そのファイルに書き込みを行います。</span><span class="sxs-lookup"><span data-stu-id="30eea-274">Create a protected file and then write to it.</span></span>

**<span data-ttu-id="30eea-275">手順 1: アプリがエンタープライズ ファイルを作成できるかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="30eea-275">Step 1: Determine if your app can create an enterprise file</span></span>**

<span data-ttu-id="30eea-276">ID 文字列がポリシーによって管理されており、アプリがポリシーの許可リストに登録されている場合、アプリはエンタープライズ ファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="30eea-276">Your app can create an enterprise file if the identity string is managed by policy and your app is on the Allowed list of that policy.</span></span>

```csharp
  if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;
```

> **<span data-ttu-id="30eea-277">API</span><span class="sxs-lookup"><span data-stu-id="30eea-277">APIs</span></span>** <br>
[<span data-ttu-id="30eea-278">ProtectionPolicyManager.IsIdentityManaged</span><span class="sxs-lookup"><span data-stu-id="30eea-278">ProtectionPolicyManager.IsIdentityManaged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)


**<span data-ttu-id="30eea-279">手順 2: ファイルを作成し、ID で保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-279">Step 2: Create the file and protect it to the identity</span></span>**

```csharp
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
StorageFile storageFile = await storageFolder.CreateFileAsync("sample.txt",
    CreationCollisionOption.ReplaceExisting);

FileProtectionInfo fileProtectionInfo =
    await FileProtectionManager.ProtectAsync(storageFile, identity);
```

> **<span data-ttu-id="30eea-280">API</span><span class="sxs-lookup"><span data-stu-id="30eea-280">APIs</span></span>** <br>
[<span data-ttu-id="30eea-281">FileProtectionManager.ProtectAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-281">FileProtectionManager.ProtectAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.protectasync.aspx)

**<span data-ttu-id="30eea-282">手順 3: ストリームやバッファーをファイルに書き込む</span><span class="sxs-lookup"><span data-stu-id="30eea-282">Step 3: Write that stream or buffer to the file</span></span>**

*<span data-ttu-id="30eea-283">ストリームを書き込む</span><span class="sxs-lookup"><span data-stu-id="30eea-283">Write a stream</span></span>*

```csharp
    if (fileProtectionInfo.Status == FileProtectionStatus.Protected)
    {
        var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);

        using (var outputStream = stream.GetOutputStreamAt(0))
        {
            using (var dataWriter = new DataWriter(outputStream))
            {
                dataWriter.WriteString(enterpriseData);
            }
        }

    }
```

*<span data-ttu-id="30eea-284">バッファーを書き込む</span><span class="sxs-lookup"><span data-stu-id="30eea-284">Write a buffer</span></span>*

```csharp
     if (fileProtectionInfo.Status == FileProtectionStatus.Protected)
     {
         var buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
             enterpriseData, Windows.Security.Cryptography.BinaryStringEncoding.Utf8);

         await FileIO.WriteBufferAsync(storageFile, buffer);

      }
```

> **<span data-ttu-id="30eea-285">API</span><span class="sxs-lookup"><span data-stu-id="30eea-285">APIs</span></span>** <br>
[<span data-ttu-id="30eea-286">FileProtectionInfo</span><span class="sxs-lookup"><span data-stu-id="30eea-286">FileProtectionInfo</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.aspx)<br>
[<span data-ttu-id="30eea-287">FileProtectionStatus</span><span class="sxs-lookup"><span data-stu-id="30eea-287">FileProtectionStatus</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>

<span id="protect-background" />
### <a name="protect-data-to-a-file-as-a-background-process"></a><span data-ttu-id="30eea-288">バック グラウンド プロセスとして、データをファイルで保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-288">Protect data to a file as a background process</span></span>

<span data-ttu-id="30eea-289">このコードは、デバイスの画面がロックされている間に実行できます。</span><span class="sxs-lookup"><span data-stu-id="30eea-289">This code can run while the screen of the device is locked.</span></span> <span data-ttu-id="30eea-290">管理者が "ロックの背後でのデータ保護 (DPL)" という安全なポリシーを構成した場合、Windows によって、保護されたリソースへのアクセスに必要な暗号化キーがデバイスのメモリから削除されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-290">If the administrator configured a secure "Data protection under lock" (DPL) policy, Windows removes the encryption keys required to access protected resources from device memory.</span></span> <span data-ttu-id="30eea-291">これにより、デバイスを紛失した場合のデータ漏洩を防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-291">This prevents data leaks if the device is lost.</span></span> <span data-ttu-id="30eea-292">これと同じ機能によって、保護されたファイルのハンドルを閉じたときに、ファイルに関連付けられているキーも削除されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-292">This same feature also removes keys associated with protected files when their handles are closed.</span></span>

<span data-ttu-id="30eea-293">ファイルを作成するときに、ファイルのハンドルを開いたままにする方法を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30eea-293">You'll have to use an approach that keeps the file handle open when you create a file.</span></span>  

**<span data-ttu-id="30eea-294">手順 1: エンタープライズ ファイルを作成できるかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="30eea-294">Step 1: Determine if you can create an enterprise file</span></span>**

<span data-ttu-id="30eea-295">使用している ID がポリシーによって管理されており、アプリがポリシーの許可リストに登録されている場合、エンタープライズ ファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="30eea-295">You can create an enterprise file if the identity that you're using is managed by policy and your app is on the allowed list of that policy.</span></span>

```csharp
if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;
```

> **<span data-ttu-id="30eea-296">API</span><span class="sxs-lookup"><span data-stu-id="30eea-296">APIs</span></span>** <br>
[<span data-ttu-id="30eea-297">ProtectionPolicyManager.IsIdentityManaged</span><span class="sxs-lookup"><span data-stu-id="30eea-297">ProtectionPolicyManager.IsIdentityManaged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)

**<span data-ttu-id="30eea-298">手順 2: ファイルを作成し、ID で保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-298">Step 2: Create a file and protect it to the identity</span></span>**

<span data-ttu-id="30eea-299">[**FileProtectionManager.CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.createprotectedandopenasync.aspx) を使用して、保護されたファイルを作成し、そのファイルへの書き込み中はファイルのハンドルを開いたままにしておきます。</span><span class="sxs-lookup"><span data-stu-id="30eea-299">The [**FileProtectionManager.CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.createprotectedandopenasync.aspx) creates a protected file and keeps the file handle open while you write to it.</span></span>

```csharp
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

ProtectedFileCreateResult protectedFileCreateResult =
    await FileProtectionManager.CreateProtectedAndOpenAsync(storageFolder,
        "sample.txt", identity, CreationCollisionOption.ReplaceExisting);
```

> **<span data-ttu-id="30eea-300">API</span><span class="sxs-lookup"><span data-stu-id="30eea-300">APIs</span></span>** <br>
[<span data-ttu-id="30eea-301">FileProtectionManager.CreateProtectedAndOpenAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-301">FileProtectionManager.CreateProtectedAndOpenAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.createprotectedandopenasync.aspx)

**<span data-ttu-id="30eea-302">手順 3: ストリームやバッファーをファイルに書き込む</span><span class="sxs-lookup"><span data-stu-id="30eea-302">Step 3: Write a stream or buffer to the file</span></span>**

<span data-ttu-id="30eea-303">この例では、ストリームをファイルに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="30eea-303">This example writes a stream to a file.</span></span>

```csharp
if (protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.Protected)
{
    IOutputStream outputStream =
        protectedFileCreateResult.Stream.GetOutputStreamAt(0);

    using (DataWriter writer = new DataWriter(outputStream))
    {
        writer.WriteString(enterpriseData);
        await writer.StoreAsync();
        await writer.FlushAsync();
    }

    outputStream.Dispose();
}
else if (protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.AccessSuspended)
{
    // Perform any special processing for the access suspended case.
}

```

> **<span data-ttu-id="30eea-304">API</span><span class="sxs-lookup"><span data-stu-id="30eea-304">APIs</span></span>** <br>
[<span data-ttu-id="30eea-305">ProtectedFileCreateResult.ProtectionInfo</span><span class="sxs-lookup"><span data-stu-id="30eea-305">ProtectedFileCreateResult.ProtectionInfo</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedfilecreateresult.protectioninfo.aspx)<br>
[<span data-ttu-id="30eea-306">FileProtectionStatus</span><span class="sxs-lookup"><span data-stu-id="30eea-306">FileProtectionStatus</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>
[<span data-ttu-id="30eea-307">ProtectedFileCreateResult.Stream</span><span class="sxs-lookup"><span data-stu-id="30eea-307">ProtectedFileCreateResult.Stream</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedfilecreateresult.stream.aspx)<br>

<span id="protect-part-file" />
### <a name="protect-part-of-a-file"></a><span data-ttu-id="30eea-308">ファイルの一部を保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-308">Protect part of a file</span></span>

<span data-ttu-id="30eea-309">ほとんどの場合、企業データと個人データを別々に保管するとデータがよりわかりやすく整理されますが、必要に応じてこれらのデータを同じファイルに格納することもできます。</span><span class="sxs-lookup"><span data-stu-id="30eea-309">In most cases, it's cleaner to store enterprise and personal data separately but you can store them to the same file if you want.</span></span> <span data-ttu-id="30eea-310">たとえば、Microsoft Outlook では、個人用のメールと共に企業用のメールを 1 つのアーカイブ ファイルに保管できます。</span><span class="sxs-lookup"><span data-stu-id="30eea-310">For example, Microsoft Outlook can store enterprise mails alongside of personal mails in a single archive file.</span></span>

<span data-ttu-id="30eea-311">ファイル全体ではなく、企業データを暗号化します。</span><span class="sxs-lookup"><span data-stu-id="30eea-311">Encrypt the enterprise data but not the entire file.</span></span> <span data-ttu-id="30eea-312">これにより、MDM から登録解除したり、企業データのアクセス権が失効している場合でも、ユーザーはそのファイルを引き続き使用することができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-312">That way, users can continue using that file even if they un-enroll from MDM or their enterprise data access rights are revoked.</span></span> <span data-ttu-id="30eea-313">また、アプリでは、どのようなデータを暗号化するかを追跡する必要があります。これにより、アプリでファイルをメモリに読み取るときに、保護するデータを認識することができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-313">Also, your app should keep track of what data it encrypts so that it knows what data to protect when it reads the file back into memory.</span></span>

**<span data-ttu-id="30eea-314">手順 1: 企業データを暗号化されたストリームまたはバッファーに追加する</span><span class="sxs-lookup"><span data-stu-id="30eea-314">Step 1: Add enterprise data to an encrypted stream or buffer</span></span>**

```csharp
string enterpriseDataString = "<employees><employee><name>Bill</name><social>xxx-xxx-xxxx</social></employee></employees>";

var enterpriseData= Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
        enterpriseDataString, Windows.Security.Cryptography.BinaryStringEncoding.Utf8);

BufferProtectUnprotectResult result =
   await DataProtectionManager.ProtectAsync(enterpriseData, identity);

enterpriseData= result.Buffer;
```

> **<span data-ttu-id="30eea-315">API</span><span class="sxs-lookup"><span data-stu-id="30eea-315">APIs</span></span>** <br>
[<span data-ttu-id="30eea-316">DataProtectionManager.ProtectAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-316">DataProtectionManager.ProtectAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.protectasync.aspx)<br>
[<span data-ttu-id="30eea-317">BufferProtectUnprotectResult.buffer</span><span class="sxs-lookup"><span data-stu-id="30eea-317">BufferProtectUnprotectResult.buffer</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.bufferprotectunprotectresult.buffer.aspx)


**<span data-ttu-id="30eea-318">手順 2: 個人データを暗号化されていないストリームまたはバッファーに追加する</span><span class="sxs-lookup"><span data-stu-id="30eea-318">Step 2: Add personal data to an unencrypted stream or buffer</span></span>**

```csharp
string personalDataString = "<recipies><recipe><name>BillsCupCakes</name><cooktime>30</cooktime></recipe></recipies>";

var personalData = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
    personalDataString, Windows.Security.Cryptography.BinaryStringEncoding.Utf8);
```

**<span data-ttu-id="30eea-319">手順 3: ストリームやバッファーをファイルに書き込む</span><span class="sxs-lookup"><span data-stu-id="30eea-319">Step 3: Write both streams or buffers to a file</span></span>**

```csharp
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

StorageFile storageFile = await storageFolder.CreateFileAsync("data.xml",
    CreationCollisionOption.ReplaceExisting);

 // Write both buffers to the file and save the file.

var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);

using (var outputStream = stream.GetOutputStreamAt(0))
{
    using (var dataWriter = new DataWriter(outputStream))
    {
        dataWriter.WriteBuffer(enterpriseData);
        dataWriter.WriteBuffer(personalData);

        await dataWriter.StoreAsync();
        await outputStream.FlushAsync();
    }
}
```

**<span data-ttu-id="30eea-320">手順 4: ファイル内の企業データの位置を追跡する</span><span class="sxs-lookup"><span data-stu-id="30eea-320">Step 4: Keep track of the location of your enterprise data in the file</span></span>**

<span data-ttu-id="30eea-321">ファイル内にある企業が所有しているのデータの追跡は、アプリで実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30eea-321">It's the responsibility of your app to keep track of the data in that file that is enterprise owned.</span></span>

<span data-ttu-id="30eea-322">そのような情報は、ファイルに関連付けられているプロパティ、データベース、またはファイル内のヘッダー テキストに保存できます。</span><span class="sxs-lookup"><span data-stu-id="30eea-322">You can store that information in a property associated with the file, in a database, or in some header text in the file.</span></span>

<span data-ttu-id="30eea-323">次の例では、その情報を個別の XML ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="30eea-323">This example, saves that information to a separate XML file.</span></span>

```csharp
StorageFile metaDataFile = await storageFolder.CreateFileAsync("metadata.xml",
   CreationCollisionOption.ReplaceExisting);

await Windows.Storage.FileIO.WriteTextAsync
    (metaDataFile, "<EnterpriseDataMarker start='0' end='" + enterpriseData.Length.ToString() +
    "'></EnterpriseDataMarker>");
```
<span id="read-protected" />
### <a name="read-the-protected-part-of-a-file"></a><span data-ttu-id="30eea-324">ファイルの保護されている部分を読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-324">Read the protected part of a file</span></span>

<span data-ttu-id="30eea-325">ファイルから企業データを読み取る方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="30eea-325">Here's how you'd read the enterprise data out of that file.</span></span>

**<span data-ttu-id="30eea-326">手順 1: ファイル内の企業データの位置を取得する</span><span class="sxs-lookup"><span data-stu-id="30eea-326">Step 1: Get the position of your enterprise data in the file</span></span>**

```csharp
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;

 Windows.Storage.StorageFile metaDataFile =
   await storageFolder.GetFileAsync("metadata.xml");

string metaData = await Windows.Storage.FileIO.ReadTextAsync(metaDataFile);

XmlDocument doc = new XmlDocument();

doc.LoadXml(metaData);

uint startPosition =
    Convert.ToUInt16((doc.FirstChild.Attributes.GetNamedItem("start")).InnerText);

uint endPosition =
    Convert.ToUInt16((doc.FirstChild.Attributes.GetNamedItem("end")).InnerText);
```

**<span data-ttu-id="30eea-327">手順 2: データ ファイルを開き、保護されていないことを確認する</span><span class="sxs-lookup"><span data-stu-id="30eea-327">Step 2: Open the data file and make sure that it's not protected</span></span>**

```csharp
Windows.Storage.StorageFile dataFile =
    await storageFolder.GetFileAsync("data.xml");

FileProtectionInfo protectionInfo =
    await FileProtectionManager.GetProtectionInfoAsync(dataFile);

if (protectionInfo.Status == FileProtectionStatus.Protected)
    return false;
```

> **<span data-ttu-id="30eea-328">API</span><span class="sxs-lookup"><span data-stu-id="30eea-328">APIs</span></span>** <br>
[<span data-ttu-id="30eea-329">FileProtectionManager.GetProtectionInfoAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-329">FileProtectionManager.GetProtectionInfoAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.getprotectioninfoasync.aspx)<br>
[<span data-ttu-id="30eea-330">FileProtectionInfo</span><span class="sxs-lookup"><span data-stu-id="30eea-330">FileProtectionInfo</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.aspx)<br>
[<span data-ttu-id="30eea-331">FileProtectionStatus</span><span class="sxs-lookup"><span data-stu-id="30eea-331">FileProtectionStatus</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>

**<span data-ttu-id="30eea-332">手順 3: ファイルから企業データを読み取る</span><span class="sxs-lookup"><span data-stu-id="30eea-332">Step 3: Read the enterprise data from the file</span></span>**

```csharp
var stream = await dataFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

stream.Seek(startPosition);

Windows.Storage.Streams.Buffer tempBuffer = new Windows.Storage.Streams.Buffer(50000);

IBuffer enterpriseData = await stream.ReadAsync(tempBuffer, endPosition, InputStreamOptions.None);
```

**<span data-ttu-id="30eea-333">手順 4: 企業データを含んでいるバッファーの暗号化を解除する</span><span class="sxs-lookup"><span data-stu-id="30eea-333">Step 4: Decrypt the buffer that contains enterprise data</span></span>**

```csharp
DataProtectionInfo dataProtectionInfo =
   await DataProtectionManager.GetProtectionInfoAsync(enterpriseData);

if (dataProtectionInfo.Status == DataProtectionStatus.Protected)
{
    BufferProtectUnprotectResult result = await DataProtectionManager.UnprotectAsync(enterpriseData);
    enterpriseData = result.Buffer;
}
else if (dataProtectionInfo.Status == DataProtectionStatus.Revoked)
{
    // Code goes here to handle this situation. Perhaps, show UI
    // saying that the user's data has been revoked.
}

```

> **<span data-ttu-id="30eea-334">API</span><span class="sxs-lookup"><span data-stu-id="30eea-334">APIs</span></span>** <br>
[<span data-ttu-id="30eea-335">DataProtectionInfo</span><span class="sxs-lookup"><span data-stu-id="30eea-335">DataProtectionInfo</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectioninfo.aspx)<br>
[<span data-ttu-id="30eea-336">DataProtectionManager.GetProtectionInfoAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-336">DataProtectionManager.GetProtectionInfoAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.getstreamprotectioninfoasync.aspx)<br>

<span id="protect-folder" />
### <a name="protect-data-to-a-folder"></a><span data-ttu-id="30eea-337">フォルダーでデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-337">Protect data to a folder</span></span>

<span data-ttu-id="30eea-338">フォルダーを作成し、保護することができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-338">You can create a folder and protect it.</span></span> <span data-ttu-id="30eea-339">これにより、そのフォルダーに追加したすべての項目は自動的に保護されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-339">That way any items that you add to that folder are automatically protected.</span></span>

```csharp
private async Task<bool> CreateANewFolderAndProtectItAsync(string folderName, string identity)
{
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    StorageFolder newStorageFolder =
        await storageFolder.CreateFolderAsync(folderName);

    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.ProtectAsync(newStorageFolder, identity);

    if (fileProtectionInfo.Status != FileProtectionStatus.Protected)
    {
        // Protection failed.
        return false;
    }
    return true;
}
```

<span data-ttu-id="30eea-340">保護する前に、フォルダーが空であることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="30eea-340">Make sure that the folder is empty before you protect it.</span></span> <span data-ttu-id="30eea-341">項目が既に含まれているフォルダーを保護することはできません。</span><span class="sxs-lookup"><span data-stu-id="30eea-341">You can't protect a folder that already contains items.</span></span>

> **<span data-ttu-id="30eea-342">API</span><span class="sxs-lookup"><span data-stu-id="30eea-342">APIs</span></span>** <br>
[<span data-ttu-id="30eea-343">ProtectionPolicyManager.IsIdentityManaged</span><span class="sxs-lookup"><span data-stu-id="30eea-343">ProtectionPolicyManager.IsIdentityManaged</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)<br>
[<span data-ttu-id="30eea-344">FileProtectionManager.ProtectAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-344">FileProtectionManager.ProtectAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.protectasync.aspx)<br>
[<span data-ttu-id="30eea-345">FileProtectionInfo.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-345">FileProtectionInfo.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.identity.aspx)<br>
[<span data-ttu-id="30eea-346">FileProtectionInfo.Status</span><span class="sxs-lookup"><span data-stu-id="30eea-346">FileProtectionInfo.Status</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.status.aspx)

<span id="protect-network" />
### <a name="protect-data-to-a-network-end-point"></a><span data-ttu-id="30eea-347">ネットワーク エンドポイントでデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-347">Protect data to a network end point</span></span>

<span data-ttu-id="30eea-348">保護されたスレッド コンテキストを作成し、そのデータを企業のエンドポイントに送信します。</span><span class="sxs-lookup"><span data-stu-id="30eea-348">Create a protected thread context to send that data to an enterprise endpoint.</span></span>  

**<span data-ttu-id="30eea-349">手順 1: ネットワーク エンドポイントの ID を取得する</span><span class="sxs-lookup"><span data-stu-id="30eea-349">Step 1: Get the identity of the network endpoint</span></span>**

```csharp
Windows.Networking.HostName hostName =
    new Windows.Networking.HostName(resourceURI.Host);

string identity = await ProtectionPolicyManager.
    GetPrimaryManagedIdentityForNetworkEndpointAsync(hostName);
```

> **<span data-ttu-id="30eea-350">API</span><span class="sxs-lookup"><span data-stu-id="30eea-350">APIs</span></span>** <br>
[<span data-ttu-id="30eea-351">ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-351">ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getprimarymanagedidentityfornetworkendpointasync.aspx)

**<span data-ttu-id="30eea-352">手順 2: 保護されたスレッド コンテキストを作成し、ネットワーク エンドポイントにデータを送信する</span><span class="sxs-lookup"><span data-stu-id="30eea-352">Step 2: Create a protected thread context and send data to the network endpoint</span></span>**

```csharp
HttpClient client = null;

if (!string.IsNullOrEmpty(m_EnterpriseId))
{
    ProtectionPolicyManager.GetForCurrentView().Identity = identity;

    using (ThreadNetworkContext threadNetworkContext =
            ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
    {
        client = new HttpClient();
        HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, resourceURI);
        message.Content = new HttpStreamContent(dataToWrite);

        HttpResponseMessage response = await client.SendRequestAsync(message);

        if (response.StatusCode == HttpStatusCode.Ok)
            return true;
        else
            return false;
    }
}
else
{
    return false;
}
```

> **<span data-ttu-id="30eea-353">API</span><span class="sxs-lookup"><span data-stu-id="30eea-353">APIs</span></span>** <br>
[<span data-ttu-id="30eea-354">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-354">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-355">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-355">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)<br>
[<span data-ttu-id="30eea-356">ProtectionPolicyManager.CreateCurrentThreadNetworkContext</span><span class="sxs-lookup"><span data-stu-id="30eea-356">ProtectionPolicyManager.CreateCurrentThreadNetworkContext</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx)

<span id="protect-share" />
### <a name="protect-data-that-your-app-shares-through-a-share-contract"></a><span data-ttu-id="30eea-357">アプリが共有コントラクトを介して共有しているデータを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-357">Protect data that your app shares through a share contract</span></span>

<span data-ttu-id="30eea-358">ユーザーがアプリからコンテンツを共有できるようにする場合は、共有コントラクトを実装し、[**DataTransferManager.DataRequested**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested) イベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30eea-358">If you want users to share content from your app, you'll have to implement a share contract and handle the [**DataTransferManager.DataRequested**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested) event.</span></span>

<span data-ttu-id="30eea-359">イベント ハンドラーで、データ パッケージ内に企業の資格情報のコンテキストを設定します。</span><span class="sxs-lookup"><span data-stu-id="30eea-359">In your event handler, set the enterprise identity context in the data package.</span></span>

```csharp
private void OnShareSourceOperation(object sender, RoutedEventArgs e)
{
    // Register the current page as a share source (or you could do this earlier in your app).
    DataTransferManager.GetForCurrentView().DataRequested += OnDataRequested;
    DataTransferManager.ShowShareUI();
}

private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
{
    if (!string.IsNullOrEmpty(this.shareSourceContent))
    {
        var protectionPolicyManager = ProtectionPolicyManager.GetForCurrentView();
        DataPackage requestData = args.Request.Data;
        requestData.Properties.Title = this.shareSourceTitle;
        requestData.Properties.EnterpriseId = protectionPolicyManager.Identity;
        requestData.SetText(this.shareSourceContent);
    }
}
```

> **<span data-ttu-id="30eea-360">API</span><span class="sxs-lookup"><span data-stu-id="30eea-360">APIs</span></span>** <br>
[<span data-ttu-id="30eea-361">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-361">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-362">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-362">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

<span id="protect-other-location" />
### <a name="protect-files-that-you-copy-to-another-location"></a><span data-ttu-id="30eea-363">別の場所にコピーしたファイルを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-363">Protect files that you copy to another location</span></span>

```csharp
private async void CopyProtectionFromOneFileToAnother
    (StorageFile sourceStorageFile, StorageFile targetStorageFile)
{
    bool copyResult = await
        FileProtectionManager.CopyProtectionAsync(sourceStorageFile, targetStorageFile);

    if (!copyResult)
    {
        // Copying failed. To diagnose, you could check the file's status.
        // (call FileProtectionManager.GetProtectionInfoAsync and
        // check FileProtectionInfo.Status).
    }
}
```

> **<span data-ttu-id="30eea-364">API</span><span class="sxs-lookup"><span data-stu-id="30eea-364">APIs</span></span>** <br>
[<span data-ttu-id="30eea-365">FileProtectionManager.CopyProtectionAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-365">FileProtectionManager.CopyProtectionAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.copyprotectionasync.aspx)<br>

<span id="protect-locked" />
### <a name="protect-enterprise-data-when-the-screen-of-the-device-is-locked"></a><span data-ttu-id="30eea-366">デバイスの画面がロックされているときに、企業データを保護する</span><span class="sxs-lookup"><span data-stu-id="30eea-366">Protect enterprise data when the screen of the device is locked</span></span>

<span data-ttu-id="30eea-367">デバイスがロックされているときは、メモリ内の機密データをすべて削除します。</span><span class="sxs-lookup"><span data-stu-id="30eea-367">Remove all sensitive data in memory when the device is locked.</span></span> <span data-ttu-id="30eea-368">ユーザーがデバイスをロック解除したとき、アプリではデータを安全に元に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="30eea-368">When the user unlocks the device, your app can safely add that data back.</span></span>

<span data-ttu-id="30eea-369">画面がロックされていることをアプリで認識できるように、[**ProtectionPolicyManager.ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccesssuspending.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="30eea-369">Handle the [**ProtectionPolicyManager.ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccesssuspending.aspx) event so that your app knows when the screen is locked.</span></span> <span data-ttu-id="30eea-370">このイベントは、管理者がロック ポリシーに従って安全なデータ保護を構成している場合にのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="30eea-370">This event is raised only if the administrator configures a secure data protection under lock policy.</span></span> <span data-ttu-id="30eea-371">Windows では、デバイスにプロビジョニングされたデータ保護キーが一時的に削除されます。</span><span class="sxs-lookup"><span data-stu-id="30eea-371">Windows temporarily removes the data protection keys that are provisioned on the device.</span></span> <span data-ttu-id="30eea-372">Windows によってこれらのキーが削除されるため、デバイスがロックされている間 (デバイスが所有者の手元にない場合も考えられます)、暗号化されたデータに対して未承認のアクセスができなくなります。</span><span class="sxs-lookup"><span data-stu-id="30eea-372">Windows removes these keys to ensure that there is no unauthorized access to encrypted data while the device is locked and possibly not in possession of its owner.</span></span>  

<span data-ttu-id="30eea-373">画面がロック解除されていることをアプリで認識できるように、[**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="30eea-373">Handle the [**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx) event so that your app knows when the screen is unlocked.</span></span> <span data-ttu-id="30eea-374">このイベントは、管理者がロック ポリシーに従って安全なデータ保護を構成しているかどうかに関係なく発生します。</span><span class="sxs-lookup"><span data-stu-id="30eea-374">This event is raised regardless of whether the administrator configures a secure data protection under lock policy.</span></span>

#### <a name="remove-sensitive-data-in-memory-when-the-screen-is-locked"></a><span data-ttu-id="30eea-375">画面がロックされているときに、メモリの機密データを削除する</span><span class="sxs-lookup"><span data-stu-id="30eea-375">Remove sensitive data in memory when the screen is locked</span></span>

<span data-ttu-id="30eea-376">機密データを保護し、保護されたファイル上でアプリが開いていたすべてのファイル ストリームを閉じることによって、システムでは、機密データがメモリ内にキャッシュされなくなります。</span><span class="sxs-lookup"><span data-stu-id="30eea-376">Protect sensitive data, and close any file streams that your app has opened on protected files to help ensure that the system doesn't cache any sensitive data in memory.</span></span>

<span data-ttu-id="30eea-377">次の例では、テキストブロックのコンテンツを暗号化されたバッファーに保存し、そのテキストブロックからコンテンツを削除します。</span><span class="sxs-lookup"><span data-stu-id="30eea-377">This example saves content from a textblock to an encrypted buffer and removes the content from that textblock.</span></span>

```csharp
private async void ProtectionPolicyManager_ProtectedAccessSuspending(object sender, ProtectedAccessSuspendingEventArgs e)
{
    Deferral deferral = e.GetDeferral();

    if (ProtectionPolicyManager.GetForCurrentView().Identity != String.Empty)
    {
        IBuffer documentBodyBuffer = CryptographicBuffer.ConvertStringToBinary
           (documentTextBlock.Text, BinaryStringEncoding.Utf8);

        BufferProtectUnprotectResult result = await DataProtectionManager.ProtectAsync
            (documentBodyBuffer, ProtectionPolicyManager.GetForCurrentView().Identity);

        if (result.ProtectionInfo.Status == DataProtectionStatus.Protected)
        {
            this.protectedDocumentBuffer = result.Buffer;
            documentTextBlock.Text = null;
        }
    }

    // Close any open streams that you are actively working with
    // to make sure that we have no unprotected content in memory.

    // Optionally, code goes here to use e.Deadline to determine whether we have more
    // than 15 seconds left before the suspension deadline. If we do then process any
    // messages queued up for sending while we are still able to access them.

    deferral.Complete();
}
```

> **<span data-ttu-id="30eea-378">API</span><span class="sxs-lookup"><span data-stu-id="30eea-378">APIs</span></span>** <br>
[<span data-ttu-id="30eea-379">ProtectionPolicyManager.ProtectedAccessSuspending</span><span class="sxs-lookup"><span data-stu-id="30eea-379">ProtectionPolicyManager.ProtectedAccessSuspending</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccesssuspending.aspx)<br>
[<span data-ttu-id="30eea-380">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-380">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-381">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-381">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)</br>
[<span data-ttu-id="30eea-382">DataProtectionManager.ProtectAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-382">DataProtectionManager.ProtectAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.protectasync.aspx)<br>
[<span data-ttu-id="30eea-383">BufferProtectUnprotectResult.buffer</span><span class="sxs-lookup"><span data-stu-id="30eea-383">BufferProtectUnprotectResult.buffer</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.bufferprotectunprotectresult.buffer.aspx)<br>
[<span data-ttu-id="30eea-384">ProtectedAccessSuspendingEventArgs.GetDeferral</span><span class="sxs-lookup"><span data-stu-id="30eea-384">ProtectedAccessSuspendingEventArgs.GetDeferral</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedaccesssuspendingeventargs.getdeferral.aspx)<br>
[<span data-ttu-id="30eea-385">Deferral.Complete</span><span class="sxs-lookup"><span data-stu-id="30eea-385">Deferral.Complete</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.complete.aspx)<br>

#### <a name="add-back-sensitive-data-when-the-device-is-unlocked"></a><span data-ttu-id="30eea-386">デバイスがロック解除されたときに、機密データを元に戻す</span><span class="sxs-lookup"><span data-stu-id="30eea-386">Add back sensitive data when the device is unlocked</span></span>

<span data-ttu-id="30eea-387">[**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx) は、デバイスがロック解除され、キーがデバイスで再び利用可能になったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="30eea-387">[**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx) is raised when the device is unlocked and the keys are available on the device again.</span></span>

<span data-ttu-id="30eea-388">[**ProtectedAccessResumedEventArgs.Identities**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedaccessresumedeventargs.identities.aspx) は、管理者がロック ポリシーに従って安全なデータ保護を構成していない場合に、空のコレクションになります。</span><span class="sxs-lookup"><span data-stu-id="30eea-388">[**ProtectedAccessResumedEventArgs.Identities**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedaccessresumedeventargs.identities.aspx) is an empty collection if the administrator hasn't configured a secure data protection under lock policy.</span></span>

<span data-ttu-id="30eea-389">次の例では、前の例とは逆の処理を実行します。</span><span class="sxs-lookup"><span data-stu-id="30eea-389">This example does the reverse of the previous example.</span></span> <span data-ttu-id="30eea-390">バッファーの暗号化を解除し、そのバッファーからテキスト ボックスに情報を戻してから、バッファーを破棄します。</span><span class="sxs-lookup"><span data-stu-id="30eea-390">It decrypts the buffer, adds information from that buffer back to the textbox and then disposes of the buffer.</span></span>

```csharp
private async void ProtectionPolicyManager_ProtectedAccessResumed(object sender, ProtectedAccessResumedEventArgs e)
{
    if (ProtectionPolicyManager.GetForCurrentView().Identity != String.Empty)
    {
        BufferProtectUnprotectResult result = await DataProtectionManager.UnprotectAsync
            (this.protectedDocumentBuffer);

        if (result.ProtectionInfo.Status == DataProtectionStatus.Unprotected)
        {
            // Restore the unprotected version.
            documentTextBlock.Text = CryptographicBuffer.ConvertBinaryToString
                (BinaryStringEncoding.Utf8, result.Buffer);
            this.protectedDocumentBuffer = null;
        }
    }

}
```

> **<span data-ttu-id="30eea-391">API</span><span class="sxs-lookup"><span data-stu-id="30eea-391">APIs</span></span>** <br>
[<span data-ttu-id="30eea-392">ProtectionPolicyManager.ProtectedAccessResumed</span><span class="sxs-lookup"><span data-stu-id="30eea-392">ProtectionPolicyManager.ProtectedAccessResumed</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx)<br>
[<span data-ttu-id="30eea-393">ProtectionPolicyManager.GetForCurrentView</span><span class="sxs-lookup"><span data-stu-id="30eea-393">ProtectionPolicyManager.GetForCurrentView</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[<span data-ttu-id="30eea-394">ProtectionPolicyManager.Identity</span><span class="sxs-lookup"><span data-stu-id="30eea-394">ProtectionPolicyManager.Identity</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)</br>
[<span data-ttu-id="30eea-395">DataProtectionManager.UnprotectAsync</span><span class="sxs-lookup"><span data-stu-id="30eea-395">DataProtectionManager.UnprotectAsync</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.unprotectasync.aspx)<br>
[<span data-ttu-id="30eea-396">BufferProtectUnprotectResult.Status</span><span class="sxs-lookup"><span data-stu-id="30eea-396">BufferProtectUnprotectResult.Status</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.bufferprotectunprotectresult.aspx)<br>

## <a name="handle-enterprise-data-when-protected-content-is-revoked"></a><span data-ttu-id="30eea-397">保護されたコンテンツが無効になった場合の企業データの処理</span><span class="sxs-lookup"><span data-stu-id="30eea-397">Handle enterprise data when protected content is revoked</span></span>

<span data-ttu-id="30eea-398">デバイスが MDM から登録解除されたとき、またはポリシー管理者が企業データへのアクセスを明示的に無効にしたときに、アプリに通知する必要がある場合は、[**ProtectionPolicyManager_ProtectedContentRevoked**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedcontentrevoked.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="30eea-398">If you want your app to be notified when the device is un-enrolled from MDM or when the policy administrator explicitly revokes access to enterprise data, handle the [**ProtectionPolicyManager_ProtectedContentRevoked**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedcontentrevoked.aspx) event.</span></span>

<span data-ttu-id="30eea-399">次の例では、メール アプリ用の企業のメールボックス内にあるデータが無効になっているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="30eea-399">This example determines if the data in an enterprise mailbox for an email app has been revoked.</span></span>

```csharp
private string mailIdentity = "contoso.com";

void MailAppSetup()
{
    ProtectionPolicyManager.ProtectedContentRevoked += ProtectionPolicyManager_ProtectedContentRevoked;
    // Code goes here to set up mailbox for 'mailIdentity'.
}

private void ProtectionPolicyManager_ProtectedContentRevoked(object sender, ProtectedContentRevokedEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.mailIdentity))
    {
        // This event is not for our identity.
        return;
    }

    // Code goes here to delete any metadata associated with 'mailIdentity'.
}
```

> **<span data-ttu-id="30eea-400">API</span><span class="sxs-lookup"><span data-stu-id="30eea-400">APIs</span></span>** <br>
[<span data-ttu-id="30eea-401">ProtectionPolicyManager_ProtectedContentRevoked</span><span class="sxs-lookup"><span data-stu-id="30eea-401">ProtectionPolicyManager_ProtectedContentRevoked</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedcontentrevoked.aspx)<br>

## <a name="related-topics"></a><span data-ttu-id="30eea-402">関連トピック</span><span class="sxs-lookup"><span data-stu-id="30eea-402">Related topics</span></span>

[<span data-ttu-id="30eea-403">Windows 情報保護 (WIP) API のサンプル</span><span class="sxs-lookup"><span data-stu-id="30eea-403">Windows Information Protection (WIP) sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)
