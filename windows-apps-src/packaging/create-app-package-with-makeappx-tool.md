---
author: laurenhughes
title: MakeAppx.exe ツールを使ったアプリ パッケージの作成
description: MakeAppx.exe は、アプリ パッケージとバンドルからのファイルの作成、暗号化、暗号化解除、抽出を行います。
ms.author: lahugh
ms.date: 06/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, パッケージ化
ms.assetid: 7c1c3355-8bf7-4c9f-b13b-2b9874b7c63c
ms.localizationpriority: medium
ms.openlocfilehash: dbde8f2f11276ded6ad0994a1cd52f7f12de229e
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4616727"
---
# <a name="create-an-app-package-with-the-makeappxexe-tool"></a><span data-ttu-id="d9894-104">MakeAppx.exe ツールを使ったアプリ パッケージの作成</span><span class="sxs-lookup"><span data-stu-id="d9894-104">Create an app package with the MakeAppx.exe tool</span></span>


<span data-ttu-id="d9894-105">**MakeAppx.exe** は、アプリ パッケージとアプリ パッケージ バンドルの両方を作成できます。</span><span class="sxs-lookup"><span data-stu-id="d9894-105">**MakeAppx.exe** creates both app packages and app package bundles.</span></span> <span data-ttu-id="d9894-106">**MakeAppx.exe**はまた、アプリ パッケージまたはバンドルからのファイルの抽出や、アプリ パッケージとバンドルの暗号化または暗号化解除を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d9894-106">**MakeAppx.exe** also extracts files from an app package or bundle and encrypts or decrypts app packages and bundles.</span></span> <span data-ttu-id="d9894-107">このツールは、Windows 10 SDK に含まれており、コマンド プロンプトまたはスクリプト ファイルから使用できます。</span><span class="sxs-lookup"><span data-stu-id="d9894-107">This tool is included in the Windows 10 SDK and can be used from a command prompt or a script file.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="d9894-108">Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d9894-108">If you used Visual Studio to develop your app, it's recommended that you use the Visual Studio wizard to create your app package.</span></span> <span data-ttu-id="d9894-109">詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9894-109">For more information, see [Package a UWP app with Visual Studio](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

<span data-ttu-id="d9894-110">**MakeAppx.exe** では .appxupload ファイルを作成できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d9894-110">Note that **MakeAppx.exe** does not create an .appxupload file.</span></span> <span data-ttu-id="d9894-111">.Appxupload ファイルは、Visual Studio のパッケージ化プロセスの一部として作成され、その他の 2 つのファイルが含まれています: .msix または .appx と .appxsym します。</span><span class="sxs-lookup"><span data-stu-id="d9894-111">The .appxupload file is created as part of the Visual Studio packaging process and contains two other files: .msix or .appx and .appxsym.</span></span> <span data-ttu-id="d9894-112">.appxsym ファイルは、アプリのパブリック シンボルが格納された圧縮 .pdb ファイルです。これらのパブリック シンボルは、Windows デベロッパー センターでの[クラッシュ分析](https://blogs.windows.com/buildingapps/2015/07/13/crash-analysis-in-the-unified-dev-center/)に使われます。</span><span class="sxs-lookup"><span data-stu-id="d9894-112">The .appxsym file is a compressed .pdb file containing public symbols of your app used for [crash analytics](https://blogs.windows.com/buildingapps/2015/07/13/crash-analysis-in-the-unified-dev-center/) in the Windows Dev Center.</span></span> <span data-ttu-id="d9894-113">通常の .appx ファイルもストアに提出できますが、クラッシュ分析やデバッグ情報を行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="d9894-113">A regular .appx file can be submitted as well, but there will be no crash analytic or debugging information available.</span></span> <span data-ttu-id="d9894-114">ストアにパッケージを提出する方法について詳しくは、「[アプリ パッケージのアップロード](https://msdn.microsoft.com/windows/uwp/publish/upload-app-packages)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9894-114">For more information on submitting packages to the store, see [Upload app packages](https://msdn.microsoft.com/windows/uwp/publish/upload-app-packages).</span></span> 

 <span data-ttu-id="d9894-115">最新バージョンの Windows 10 では、このツールの更新プログラムでは、.appx パッケージの使用量は影響しません。</span><span class="sxs-lookup"><span data-stu-id="d9894-115">Updates to this tool in the most recent version of Windows 10 do not affect .appx package usage.</span></span> <span data-ttu-id="d9894-116">.Appx パッケージでは、このツールの使用を続行したり、以下のように .msix パッケージのサポートとツールを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d9894-116">You can continue using this tool with .appx packages, or use the tool with support for .msix packages as described below.</span></span>

<span data-ttu-id="d9894-117">.appxupload ファイルを手動で作成するには:</span><span class="sxs-lookup"><span data-stu-id="d9894-117">To manually create an .appxupload file:</span></span>
- <span data-ttu-id="d9894-118">フォルダーで、.msix と .appxsym を配置します。</span><span class="sxs-lookup"><span data-stu-id="d9894-118">Place the .msix and the .appxsym in a folder</span></span>
- <span data-ttu-id="d9894-119">ファイルが入ったフォルダーを zip 圧縮する</span><span class="sxs-lookup"><span data-stu-id="d9894-119">Zip the folder</span></span>
- <span data-ttu-id="d9894-120">zip 圧縮したフォルダーの拡張指名を .zip から .appxupload に変更する</span><span class="sxs-lookup"><span data-stu-id="d9894-120">Change the zipped folder extension name from .zip to .appxupload</span></span>

## <a name="using-makeappxexe"></a><span data-ttu-id="d9894-121">MakeAppx.exe の使用</span><span class="sxs-lookup"><span data-stu-id="d9894-121">Using MakeAppx.exe</span></span>

<span data-ttu-id="d9894-122">SDK のインストール パスに基づき、**MakeAppx.exe** は Windows 10 PC の以下の場所にあります。</span><span class="sxs-lookup"><span data-stu-id="d9894-122">Based on your installation path of the SDK, this is where **MakeAppx.exe** is on your Windows 10 PC:</span></span>
- <span data-ttu-id="d9894-123">x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\makeappx.exe</span><span class="sxs-lookup"><span data-stu-id="d9894-123">x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\makeappx.exe</span></span>
- <span data-ttu-id="d9894-124">x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\makeappx.exe</span><span class="sxs-lookup"><span data-stu-id="d9894-124">x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\makeappx.exe</span></span>

<span data-ttu-id="d9894-125">このツールの ARM バージョンはありません。</span><span class="sxs-lookup"><span data-stu-id="d9894-125">There is no ARM version of this tool.</span></span>

### <a name="makeappxexe-syntax-and-options"></a><span data-ttu-id="d9894-126">MakeAppx.exe の構文とオプション</span><span class="sxs-lookup"><span data-stu-id="d9894-126">MakeAppx.exe syntax and options</span></span>

<span data-ttu-id="d9894-127">一般的な **MakeAppx.exe** の構文:</span><span class="sxs-lookup"><span data-stu-id="d9894-127">General **MakeAppx.exe** syntax:</span></span>

``` Usage
MakeAppx <command> [options]      
```

<span data-ttu-id="d9894-128">次の表では、**MakeAppx.exe** のコマンドについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d9894-128">The following table describes the commands for **MakeAppx.exe**.</span></span>

| **<span data-ttu-id="d9894-129">コマンド</span><span class="sxs-lookup"><span data-stu-id="d9894-129">Command</span></span>**   | **<span data-ttu-id="d9894-130">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-130">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="d9894-131">pack</span><span class="sxs-lookup"><span data-stu-id="d9894-131">pack</span></span>          | <span data-ttu-id="d9894-132">パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="d9894-132">Creates a package.</span></span>                    |
| <span data-ttu-id="d9894-133">unpack</span><span class="sxs-lookup"><span data-stu-id="d9894-133">unpack</span></span>        | <span data-ttu-id="d9894-134">指定されたパッケージ内のすべてのファイルを、指定された出力ディレクトリに抽出します。</span><span class="sxs-lookup"><span data-stu-id="d9894-134">Extracts all files in the specified package to the specified output directory.</span></span> |
| <span data-ttu-id="d9894-135">bundle</span><span class="sxs-lookup"><span data-stu-id="d9894-135">bundle</span></span>        | <span data-ttu-id="d9894-136">バンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="d9894-136">Creates a bundle.</span></span>                     |
| <span data-ttu-id="d9894-137">unbundle</span><span class="sxs-lookup"><span data-stu-id="d9894-137">unbundle</span></span>      | <span data-ttu-id="d9894-138">指定された出力パスの下に、バンドルの完全な名前に基づく名前のサブディレクトリを作成し、すべてのパッケージをそのディレクトリにアンパックします。</span><span class="sxs-lookup"><span data-stu-id="d9894-138">Unpacks all packages to a subdirectory under the specified output path named after the bundle full name.</span></span> |
| <span data-ttu-id="d9894-139">encrypt</span><span class="sxs-lookup"><span data-stu-id="d9894-139">encrypt</span></span>       | <span data-ttu-id="d9894-140">入力パッケージ/バンドルから、暗号化されたアプリ パッケージやバンドルを作成し、指定された出力パッケージ/バンドルとして保存します。</span><span class="sxs-lookup"><span data-stu-id="d9894-140">Creates an encrypted app package or bundle from the input package/bundle at the specified output package/bundle.</span></span> |
| <span data-ttu-id="d9894-141">decrypt</span><span class="sxs-lookup"><span data-stu-id="d9894-141">decrypt</span></span>       | <span data-ttu-id="d9894-142">入力アプリ パッケージ/バンドルから、暗号化解除されたアプリ パッケージやバンドルを作成し、指定された出力パッケージ/バンドルとして保存します。</span><span class="sxs-lookup"><span data-stu-id="d9894-142">Creates an decrypted app package or bundle from the input app package/bundle at the specified output package/bundle.</span></span> |


<span data-ttu-id="d9894-143">このオプションの一覧は、すべてのコマンドに適用されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-143">This list of options applies to all commands:</span></span>

| **<span data-ttu-id="d9894-144">オプション</span><span class="sxs-lookup"><span data-stu-id="d9894-144">Option</span></span>**    | **<span data-ttu-id="d9894-145">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-145">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="d9894-146">/d</span><span class="sxs-lookup"><span data-stu-id="d9894-146">/d</span></span>            | <span data-ttu-id="d9894-147">入力ディレクトリ、出力ディレクトリ、またはコンテンツ ディレクトリを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-147">Specifies the input, output, or content directory.</span></span> |
| <span data-ttu-id="d9894-148">/l</span><span class="sxs-lookup"><span data-stu-id="d9894-148">/l</span></span>            | <span data-ttu-id="d9894-149">ローカライズされたパッケージに対して使用されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-149">Used for localized packages.</span></span> <span data-ttu-id="d9894-150">既定の検証が、ローカライズされたパッケージで無効になります。</span><span class="sxs-lookup"><span data-stu-id="d9894-150">The default validation trips on localized packages.</span></span> <span data-ttu-id="d9894-151">このオプションを使用すると、すべての検証を無効にすることなく、その特定の検証のみが無効になります。</span><span class="sxs-lookup"><span data-stu-id="d9894-151">This options disables only that specific validation, without requiring that all validation be disabled.</span></span> |
| <span data-ttu-id="d9894-152">/kf</span><span class="sxs-lookup"><span data-stu-id="d9894-152">/kf</span></span>           | <span data-ttu-id="d9894-153">指定したキー ファイルのキーを使って、パッケージやバンドルを暗号化または暗号化解除します。</span><span class="sxs-lookup"><span data-stu-id="d9894-153">Encrypts or decrypts the package or bundle using the key from the specified key file.</span></span> <span data-ttu-id="d9894-154">このオプションは、/kt と一緒に使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="d9894-154">This can't be used with /kt.</span></span> |
| <span data-ttu-id="d9894-155">/kt</span><span class="sxs-lookup"><span data-stu-id="d9894-155">/kt</span></span>           | <span data-ttu-id="d9894-156">グローバル テスト キーを使ってパッケージやバンドルを暗号化または暗号化解除します。</span><span class="sxs-lookup"><span data-stu-id="d9894-156">Encrypts the or decrypts package or bundle using the global test key.</span></span> <span data-ttu-id="d9894-157">これは、/kf と一緒に使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="d9894-157">This can't be used with /kf.</span></span> |
| <span data-ttu-id="d9894-158">/no</span><span class="sxs-lookup"><span data-stu-id="d9894-158">/no</span></span>           | <span data-ttu-id="d9894-159">出力ファイルが存在する場合に、出力ファイルを上書きしません。</span><span class="sxs-lookup"><span data-stu-id="d9894-159">Prevents an overwrite of the output file if it exists.</span></span> <span data-ttu-id="d9894-160">このオプションか /o オプションのいずれも指定しない場合は、ファイルを上書きするかどうかを尋ねるメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-160">If you don't specify this option or the /o option, the user is asked whether they want to overwrite the file.</span></span> |
| <span data-ttu-id="d9894-161">/nv</span><span class="sxs-lookup"><span data-stu-id="d9894-161">/nv</span></span>           | <span data-ttu-id="d9894-162">セマンティクス検証をスキップします。</span><span class="sxs-lookup"><span data-stu-id="d9894-162">Skips semantic validation.</span></span> <span data-ttu-id="d9894-163">このオプションを指定しない場合、パッケージの完全な検証が実行されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-163">If you don't specify this option, the tool performs a full validation of the package.</span></span> |
| <span data-ttu-id="d9894-164">/o</span><span class="sxs-lookup"><span data-stu-id="d9894-164">/o</span></span>            | <span data-ttu-id="d9894-165">存在する場合は、出力ファイルを上書きします。</span><span class="sxs-lookup"><span data-stu-id="d9894-165">Overwrites the output file if it exists.</span></span> <span data-ttu-id="d9894-166">このオプションも /no オプションも指定しない場合は、ファイルを上書きするかどうかを尋ねるメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-166">If you don't specify this option or the /no option, the user is asked whether they want to overwrite the file.</span></span> |
| <span data-ttu-id="d9894-167">/p</span><span class="sxs-lookup"><span data-stu-id="d9894-167">/p</span></span>            | <span data-ttu-id="d9894-168">アプリ パッケージまたはバンドルを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-168">Specifies the app package or bundle.</span></span>  |
| <span data-ttu-id="d9894-169">/v</span><span class="sxs-lookup"><span data-stu-id="d9894-169">/v</span></span>            | <span data-ttu-id="d9894-170">コンソールへの詳細なログ出力を有効にします。</span><span class="sxs-lookup"><span data-stu-id="d9894-170">Enables verbose logging output to the console.</span></span> |
| <span data-ttu-id="d9894-171">/?</span><span class="sxs-lookup"><span data-stu-id="d9894-171">/?</span></span>            | <span data-ttu-id="d9894-172">ヘルプ テキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-172">Displays help text.</span></span>                   |


<span data-ttu-id="d9894-173">次の一覧では、使用可能な引数を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-173">The following list contains possible arguments:</span></span>

| **<span data-ttu-id="d9894-174">引数</span><span class="sxs-lookup"><span data-stu-id="d9894-174">Argument</span></span>**                          | **<span data-ttu-id="d9894-175">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-175">Description</span></span>**                       |
|---------------------------------------|---------------------------------------|
| <span data-ttu-id="d9894-176">&lt;出力パッケージの名前&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-176">&lt;output package name&gt;</span></span>           | <span data-ttu-id="d9894-177">作成されるパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-177">The name of the package created.</span></span> <span data-ttu-id="d9894-178">これは、末尾に .msix または .appx ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-178">This is the file name appended with .msix or .appx.</span></span> |
| <span data-ttu-id="d9894-179">&lt;暗号化された出力パッケージの名前&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-179">&lt;encrypted output package name&gt;</span></span> | <span data-ttu-id="d9894-180">作成される暗号化されたパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-180">The name of the encrypted package created.</span></span> <span data-ttu-id="d9894-181">これは、末尾に .emsix または .eappx ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-181">This is the file name appended with .emsix or .eappx.</span></span> |
| <span data-ttu-id="d9894-182">&lt;入力パッケージ名&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-182">&lt;input package name&gt;</span></span>            | <span data-ttu-id="d9894-183">パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-183">The name of the package.</span></span> <span data-ttu-id="d9894-184">これは、末尾に .msix または .appx ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-184">This is the file name appended with .msix or .appx.</span></span> |
| <span data-ttu-id="d9894-185">&lt;暗号化された入力パッケージ名&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-185">&lt;encrypted input package name&gt;</span></span>  | <span data-ttu-id="d9894-186">暗号化されたパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-186">The name of the encrypted package.</span></span> <span data-ttu-id="d9894-187">これは、末尾に .emsix または .eappx ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-187">This is the file name appended with .emsix or .eappx.</span></span> |
| <span data-ttu-id="d9894-188">&lt;出力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-188">&lt;output bundle name&gt;</span></span>            | <span data-ttu-id="d9894-189">作成されるバンドルの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-189">The name of the bundle created.</span></span> <span data-ttu-id="d9894-190">これは、末尾に .msixbundle または .appxbundle ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-190">This is the file name appended with .msixbundle or .appxbundle.</span></span> |
| <span data-ttu-id="d9894-191">&lt;暗号化された出力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-191">&lt;encrypted output bundle name&gt;</span></span>  | <span data-ttu-id="d9894-192">作成される暗号化されたバンドルの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-192">The name of the encrypted bundle created.</span></span> <span data-ttu-id="d9894-193">これは、末尾に .emsixbundle または .eappxbundle ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-193">This is the file name appended with .emsixbundle or .eappxbundle.</span></span> |
| <span data-ttu-id="d9894-194">&lt;入力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-194">&lt;input bundle name&gt;</span></span>             | <span data-ttu-id="d9894-195">バンドルの名前。</span><span class="sxs-lookup"><span data-stu-id="d9894-195">The name of the bundle.</span></span> <span data-ttu-id="d9894-196">これは、末尾に .msixbundle または .appxbundle ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-196">This is the file name appended with .msixbundle or .appxbundle.</span></span> |
| <span data-ttu-id="d9894-197">&lt;暗号化された入力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-197">&lt;encrypted input bundle name&gt;</span></span>   | <span data-ttu-id="d9894-198">暗号化されたバンドルの名前です。</span><span class="sxs-lookup"><span data-stu-id="d9894-198">The name of the encrypted bundle.</span></span> <span data-ttu-id="d9894-199">これは、末尾に .emsixbundle または .eappxbundle ファイル名です。</span><span class="sxs-lookup"><span data-stu-id="d9894-199">This is the file name appended with .emsixbundle or .eappxbundle.</span></span> |
| <span data-ttu-id="d9894-200">&lt;コンテンツ ディレクトリ&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-200">&lt;content directory&gt;</span></span>             | <span data-ttu-id="d9894-201">アプリ パッケージまたはバンドルのコンテンツのパス。</span><span class="sxs-lookup"><span data-stu-id="d9894-201">Path for the app package or bundle content.</span></span> |
| <span data-ttu-id="d9894-202">&lt;マッピング ファイル&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-202">&lt;mapping file&gt;</span></span>                  | <span data-ttu-id="d9894-203">パッケージのソースとターゲットを指定するファイル名。</span><span class="sxs-lookup"><span data-stu-id="d9894-203">File name that specifies the package source and destination.</span></span> |
| <span data-ttu-id="d9894-204">&lt;出力ディレクトリ&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-204">&lt;output directory&gt;</span></span>              | <span data-ttu-id="d9894-205">出力パッケージとバンドルのディレクトリへのパス。</span><span class="sxs-lookup"><span data-stu-id="d9894-205">Path to the directory for output packages and bundles.</span></span> |
| <span data-ttu-id="d9894-206">&lt;キー ファイル&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-206">&lt;key file&gt;</span></span>                      | <span data-ttu-id="d9894-207">暗号化キーまたは暗号化解除キーが含まれているファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="d9894-207">Name of the file containing a key for encryption or decryption.</span></span> |
| <span data-ttu-id="d9894-208">&lt;アルゴリズム ID&gt;</span><span class="sxs-lookup"><span data-stu-id="d9894-208">&lt;algorithm ID&gt;</span></span>                  | <span data-ttu-id="d9894-209">ブロック マップの作成時に使用されるアルゴリズム。</span><span class="sxs-lookup"><span data-stu-id="d9894-209">Algorithms used when creating a block map.</span></span> <span data-ttu-id="d9894-210">有効なアルゴリズムには、SHA256 (既定)、SHA384、SHA512 があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-210">Valid algorithms include: SHA256 (default), SHA384, SHA512.</span></span> |


### <a name="create-an-app-package"></a><span data-ttu-id="d9894-211">アプリ パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="d9894-211">Create an app package</span></span>

<span data-ttu-id="d9894-212">アプリ パッケージは、.msix または .appx パッケージ ファイルにパッケージ化されたアプリのファイルの完全なセットです。</span><span class="sxs-lookup"><span data-stu-id="d9894-212">An app package is a complete set of the app's files packaged in to a .msix or .appx package file.</span></span> <span data-ttu-id="d9894-213">**pack** コマンドを使ってアプリ パッケージを作成するには、パッケージの保存場所としてコンテンツ ディレクトリまたはマッピング ファイルを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-213">To create an app package using the **pack** command, you must provide either a content directory or a mapping file for the location of the package.</span></span> <span data-ttu-id="d9894-214">また作成時にパッケージを暗号化することもできます。</span><span class="sxs-lookup"><span data-stu-id="d9894-214">You can also encrypt a package while creating it.</span></span> <span data-ttu-id="d9894-215">パッケージを暗号化する場合は、/ep を使って、キー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-215">If you want to encrypt the package, you must use /ep and specify if you are using a key file (/kf) or the global test key (/kt).</span></span> <span data-ttu-id="d9894-216">暗号化されたパッケージを作成する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9894-216">For more information on creating an encrypted package, see [Encrypt or decrypt a package or bundle](#encrypt-or-decrypt-a-package-or-bundle).</span></span>

<span data-ttu-id="d9894-217">**pack** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="d9894-217">Options specific to the **pack** command:</span></span>

| **<span data-ttu-id="d9894-218">オプション</span><span class="sxs-lookup"><span data-stu-id="d9894-218">Option</span></span>**    | **<span data-ttu-id="d9894-219">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-219">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="d9894-220">/f</span><span class="sxs-lookup"><span data-stu-id="d9894-220">/f</span></span>            | <span data-ttu-id="d9894-221">マッピング ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-221">Specifies the mapping file.</span></span>           |
| <span data-ttu-id="d9894-222">/h</span><span class="sxs-lookup"><span data-stu-id="d9894-222">/h</span></span>            | <span data-ttu-id="d9894-223">ブロック マップを作成するときに使うハッシュ アルゴリズムを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-223">Specifies the hash algorithm to use when creating the block map.</span></span> <span data-ttu-id="d9894-224">これは、pack コマンドでのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="d9894-224">This can only be used with the pack command.</span></span> <span data-ttu-id="d9894-225">有効なアルゴリズムには、SHA256 (既定)、SHA384、SHA512 があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-225">Valid algorithms include: SHA256 (default), SHA384, SHA512.</span></span> |
| <span data-ttu-id="d9894-226">/m</span><span class="sxs-lookup"><span data-stu-id="d9894-226">/m</span></span>            | <span data-ttu-id="d9894-227">入力アプリ マニフェストへのパスを指定します。出力アプリ パッケージまたはリソース パッケージのマニフェストは、このパスに基づいて生成されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-227">Specifies the path to an input app manifest which will be used as the basis for generating the output app package or resource package's manifest.</span></span>  <span data-ttu-id="d9894-228">このオプションを使用するときには、/f を一緒に使用すると共にマッピング ファイルに [ResourceMetadata] セクションを追加し、生成されるマニフェストに含まれるリソースの次元を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-228">When you use this option, you must also use /f and include a [ResourceMetadata] section in the mapping file to specify the resource dimensions to be included in the generated manifest.</span></span>|
| <span data-ttu-id="d9894-229">/nc</span><span class="sxs-lookup"><span data-stu-id="d9894-229">/nc</span></span>           | <span data-ttu-id="d9894-230">パッケージ ファイルを圧縮しないことを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-230">Prevents compression of the package files.</span></span> <span data-ttu-id="d9894-231">既定では、検出されたファイルの種類に基づいてファイルが圧縮されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-231">By default, files are compressed based on detected file type.</span></span> |
| <span data-ttu-id="d9894-232">/r</span><span class="sxs-lookup"><span data-stu-id="d9894-232">/r</span></span>            | <span data-ttu-id="d9894-233">リソース パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="d9894-233">Builds a resource package.</span></span> <span data-ttu-id="d9894-234">これは /m と共に使う必要があり、/l オプションを使用することを意味します。</span><span class="sxs-lookup"><span data-stu-id="d9894-234">This must be used with /m and implies the use of the /l option.</span></span> |  


<span data-ttu-id="d9894-235">以下では、**pack**コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-235">The following usage examples show some possible syntax options for the **pack** command:</span></span>

``` syntax 
MakeAppx pack [options] /d <content directory> /p <output package name>
MakeAppx pack [options] /f <mapping file> /p <output package name>
MakeAppx pack [options] /m <app package manifest> /f <mapping file> /p <output package name>
MakeAppx pack [options] /r /m <app package manifest> /f <mapping file> /p <output package name>
MakeAppx pack [options] /d <content directory> /ep <encrypted output package name> /kf <key file>
MakeAppx pack [options] /d <content directory> /ep <encrypted output package name> /kt

```
<span data-ttu-id="d9894-236">以下では、**pack** コマンドのコマンド ラインの例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-236">The following shows command line examples for the **pack** command:</span></span>

``` examples
MakeAppx pack /v /h SHA256 /d "C:\My Files" /p MyPackage.msix
MakeAppx pack /v /o /f MyMapping.txt /p MyPackage.msix
MakeAppx pack /m "MyApp\AppxManifest.xml" /f MyMapping.txt /p AppPackage.msix
MakeAppx pack /r /m "MyApp\AppxManifest.xml" /f MyMapping.txt /p ResourcePackage.msix
MakeAppx pack /v /h SHA256 /d "C:\My Files" /ep MyPackage.emsix /kf MyKeyFile.txt
MakeAppx pack /v /h SHA256 /d "C:\My Files" /ep MyPackage.emsix /kt
```

### <a name="create-an-app-bundle"></a><span data-ttu-id="d9894-237">アプリ バンドルを作成する</span><span class="sxs-lookup"><span data-stu-id="d9894-237">Create an app bundle</span></span>

<span data-ttu-id="d9894-238">アプリ バンドルはアプリ パッケージに似ていますが、バンドルではユーザーがダウンロードするアプリのサイズを小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="d9894-238">An app bundle is similar to an app package, but a bundle can reduce the size of the app that users download.</span></span> <span data-ttu-id="d9894-239">たとえば、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースが含まれる場合などは、アプリ バンドルを使うと便利です。</span><span class="sxs-lookup"><span data-stu-id="d9894-239">App bundles are helpful for language-specific assets, varying image-scale assets, or resources that apply to specific versions of Microsoft DirectX, for example.</span></span> <span data-ttu-id="d9894-240">アプリ パッケージが作成時に暗号化できるのと同様、アプリ バンドルもバンドル時に暗号化できます。</span><span class="sxs-lookup"><span data-stu-id="d9894-240">Similar to creating an encrypted app package, you can also encrypt the app bundle while bundling it.</span></span> <span data-ttu-id="d9894-241">アプリ バンドルを暗号化するには、/ep オプションを使って、キー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-241">To encrypt the app bundle, use the /ep option and specify if you are using a key file (/kf) or the global test key (/kt).</span></span> <span data-ttu-id="d9894-242">暗号化されたバンドルを作成する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9894-242">For more information on creating an encrypted bundle, see [Encrypt or decrypt a package or bundle](#encrypt-or-decrypt-a-package-or-bundle).</span></span>

<span data-ttu-id="d9894-243">**bundle** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="d9894-243">Options specific to the **bundle** command:</span></span>

| **<span data-ttu-id="d9894-244">オプション</span><span class="sxs-lookup"><span data-stu-id="d9894-244">Option</span></span>**    | **<span data-ttu-id="d9894-245">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-245">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="d9894-246">/bv</span><span class="sxs-lookup"><span data-stu-id="d9894-246">/bv</span></span>           | <span data-ttu-id="d9894-247">バンドルのバージョン番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-247">Specifies the version number of the bundle.</span></span> <span data-ttu-id="d9894-248">バージョン番号は、4 つの部分をピリオドで区切って、&lt;メジャー番号&gt;.&lt;マイナー番号&gt;.&lt;ビルド&gt;.&lt;リビジョン&gt; の形式で指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-248">The version number must be in four parts separated by periods in the form: &lt;Major&gt;.&lt;Minor&gt;.&lt;Build&gt;.&lt;Revision&gt;.</span></span> |
| <span data-ttu-id="d9894-249">/f</span><span class="sxs-lookup"><span data-stu-id="d9894-249">/f</span></span>            | <span data-ttu-id="d9894-250">マッピング ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-250">Specifies the mapping file.</span></span>           |

<span data-ttu-id="d9894-251">バンドルのバージョンが指定されていないか、"0.0.0.0" に設定されている場合は、現在の日付と時刻を使用してバンドルが作成されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d9894-251">Note that if the bundle version is not specified or if it is set to "0.0.0.0" the bundle is created using the current date-time.</span></span>

<span data-ttu-id="d9894-252">以下では、**bundle**コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-252">The following usage examples show some possible syntax options for the **bundle** command:</span></span>

``` syntax
MakeAppx bundle [options] /d <content directory> /p <output bundle name>
MakeAppx bundle [options] /f <mapping file> /p <output bundle name>
MakeAppx bundle [options] /d <content directory> /ep <encrypted output bundle name> /kf MyKeyFile.txt
MakeAppx bundle [options] /f <mapping file> /ep <encrypted output bundle name> /kt
```
<span data-ttu-id="d9894-253">以下のブロックでは、**bundle** コマンドの例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-253">The following block contains examples for the **bundle** command:</span></span>

``` examples
MakeAppx bundle /v /d "C:\My Files" /p MyBundle.msixbundle
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /p MyBundle.msixbundle
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /ep MyBundle.emsixbundle /kf MyKeyFile.txt
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /ep MyBundle.emsixbundle /kt
```

### <a name="extract-files-from-a-package-or-bundle"></a><span data-ttu-id="d9894-254">パッケージまたはバンドルからファイルを抽出する</span><span class="sxs-lookup"><span data-stu-id="d9894-254">Extract files from a package or bundle</span></span>

<span data-ttu-id="d9894-255">**MakeAppx.exe** はアプリのパッケージとバンドルだけでなく、既存のパッケージのアンパックやアンバンドルに使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d9894-255">In addition to packaging and bundling apps, **MakeAppx.exe** can also unpack or unbundle existing packages.</span></span> <span data-ttu-id="d9894-256">展開されたファイルの保存先としてコンテンツ ディレクトリを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-256">You must provide the content directory as a destination for the extracted files.</span></span> <span data-ttu-id="d9894-257">暗号化されたパッケージまたはバンドルからファイルを抽出する場合は、/ep オプションを使って、暗号化解除にキー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定することで、ファイルの暗号化解除と抽出を同時に実行できます。</span><span class="sxs-lookup"><span data-stu-id="d9894-257">If you are trying to extract files from an encrypted package or bundle, you can decrypt and extract the files at the same time using the /ep option and specifying whether it should be decrypted using a key file (/kf) or the global test key (/kt).</span></span> <span data-ttu-id="d9894-258">パッケージまたはバンドルを暗号化解除する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9894-258">For more information on decrypting a package or bundle, see [Encrypt or decrypt a package or bundle](#encrypt-or-decrypt-a-package-or-bundle).</span></span>

<span data-ttu-id="d9894-259">**unpack** コマンドと **unbundle** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="d9894-259">Options specific to **unpack** and **unbundle** commands:</span></span>

| **<span data-ttu-id="d9894-260">オプション</span><span class="sxs-lookup"><span data-stu-id="d9894-260">Option</span></span>**    | **<span data-ttu-id="d9894-261">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-261">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="d9894-262">/nd</span><span class="sxs-lookup"><span data-stu-id="d9894-262">/nd</span></span>           | <span data-ttu-id="d9894-263">パッケージやバンドルをアンパックまたはアンバンドルするときに、暗号化解除を行いません。</span><span class="sxs-lookup"><span data-stu-id="d9894-263">Does not perform decryption when unpacking or unbundling the package/bundle.</span></span> |
| <span data-ttu-id="d9894-264">/pfn</span><span class="sxs-lookup"><span data-stu-id="d9894-264">/pfn</span></span>          | <span data-ttu-id="d9894-265">指定した出力パスの下に、パッケージまたはバンドルの完全な名前に基づく名前のサブディレクトリが作成され、アンパックまたはアンバンドルしたすべてのファイルが保存されます。</span><span class="sxs-lookup"><span data-stu-id="d9894-265">Unpacks/unbundles all files to a subdirectory under the specified output path, named after the package or bundle full name</span></span> |

<span data-ttu-id="d9894-266">以下では、**unpack** コマンドと **unbundle** コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-266">The following usage examples show some possible syntax options for the **unpack** and **unbundle** commands:</span></span>

``` syntax
MakeAppx unpack [options] /p <input package name> /d <output directory>
MakeAppx unpack [options] /ep <encrypted input package name> /d <output directory> /kf <key file>
MakeAppx unpack [options] /ep <encrypted input package name> /d <output directory> /kt

MakeAppx unbundle [options] /p <input bundle name> /d <output directory>
MakeAppx unbundle [options] /ep <encrypted input bundle name> /d <output directory> /kf <key file>
MakeAppx unbundle [options] /ep <encrypted input bundle name> /d <output directory> /kt
```

<span data-ttu-id="d9894-267">以下のブロックでは、**unpack** コマンドと **unbundle** コマンドの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-267">The following block contains examples for using the **unpack** and **unbundle** commands:</span></span>

``` examples
MakeAppx unpack /v /p MyPackage.msix /d "C:\My Files"
MakeAppx unpack /v /ep MyPackage.emsix /d "C:\My Files" /kf MyKeyFile.txt
MakeAppx unpack /v /ep MyPackage.emsix /d "C:\My Files" /kt

MakeAppx unbundle /v /p MyBundle.msixbundle /d "C:\My Files"
MakeAppx unbundle /v /ep MyBundle.emsixbundle /d "C:\My Files" /kf MyKeyFile.txt
MakeAppx unbundle /v /ep MyBundle.emsixbundle /d "C:\My Files" /kt
```

### <a name="encrypt-or-decrypt-a-package-or-bundle"></a><span data-ttu-id="d9894-268">パッケージまたはバンドルを暗号化または暗号化解除する</span><span class="sxs-lookup"><span data-stu-id="d9894-268">Encrypt or decrypt a package or bundle</span></span>

<span data-ttu-id="d9894-269">**MakeAppx.exe**ツールでは、既存のパッケージやバンドルの暗号化や暗号化解除を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d9894-269">The **MakeAppx.exe** tool can also encrypt or decrypt an existing package or bundle.</span></span> <span data-ttu-id="d9894-270">これには、パッケージ名と出力パッケージ名に加え、暗号化や暗号化解除にキー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使用するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-270">You must simply provide the package name, the output package name, and whether encryption or decryption should use a key file (/kf) or the global test key (/kt).</span></span>

<span data-ttu-id="d9894-271">暗号化と暗号化解除は、Visual Studio パッケージ ウィザードでは実行できません。</span><span class="sxs-lookup"><span data-stu-id="d9894-271">Encryption and decryption are not available through the Visual Studio packaging wizard.</span></span> 

<span data-ttu-id="d9894-272"> *\*encrypt** コマンドと *\*decrypt** コマンド固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="d9894-272">Options specific to **encrypt** and **decrypt** commands:</span></span>

| **<span data-ttu-id="d9894-273">オプション</span><span class="sxs-lookup"><span data-stu-id="d9894-273">Option</span></span>**    | **<span data-ttu-id="d9894-274">説明</span><span class="sxs-lookup"><span data-stu-id="d9894-274">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="d9894-275">/ep</span><span class="sxs-lookup"><span data-stu-id="d9894-275">/ep</span></span>           | <span data-ttu-id="d9894-276">暗号化されたアプリ パッケージまたはバンドルを指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-276">Specifies an encrypted app package or bundle.</span></span> |

<span data-ttu-id="d9894-277">以下では、**encrypt** コマンドと **decrypt** コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-277">The following usage examples show some possible syntax options for the **encrypt** and **decrypt** commands:</span></span>

``` syntax
MakeAppx encrypt [options] /p <package name> /ep <output package name> /kf <key file>
MakeAppx encrypt [options] /p <package name> /ep <output package name> /kt

MakeAppx decrypt [options] /ep <package name> /p <output package name> /kf <key file>
MakeAppx decrypt [options] /ep <package name> /p <output package name> /kt
```

<span data-ttu-id="d9894-278">以下のブロックでは、**encrypt** コマンドと **decrypt** コマンドの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="d9894-278">The following block contains examples for using the **encrypt** and **decrypt** commands:</span></span>

``` examples
MakeAppx.exe encrypt /p MyPackage.msix /ep MyEncryptedPackage.emsix /kt
MakeAppx.exe encrypt /p MyPackage.msix /ep MyEncryptedPackage.emsix /kf MyKeyFile.txt

MakeAppx.exe decrypt /p MyPackage.msix /ep MyEncryptedPackage.emsix /kt
MakeAppx.exe decrypt p MyPackage.msix /ep MyEncryptedPackage.emsix /kf MyKeyFile.txt
```

## <a name="key-files"></a><span data-ttu-id="d9894-279">キー ファイル</span><span class="sxs-lookup"><span data-stu-id="d9894-279">Key files</span></span>

<span data-ttu-id="d9894-280">キー ファイルは、1 行目で文字列 "[Keys]" を指定し、2 行目以降で各パッケージを暗号化するキーを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-280">Key files must begin with a line containing the string "[Keys]" followed by lines describing the keys to encrypt each package with.</span></span> <span data-ttu-id="d9894-281">各キーは、それぞれが引用符で囲まれた文字列を 2 つ 1 組として空白またはタブで区切って表します。</span><span class="sxs-lookup"><span data-stu-id="d9894-281">Each key is represented by a pair of strings in quotation marks, separated by either spaces or tabs.</span></span> <span data-ttu-id="d9894-282">最初の文字列は base64 でエンコードされた 32 バイトのキー ID を表し、2 番目の文字列は base64 でエンコードされた 32 バイトの暗号化キーを表します。</span><span class="sxs-lookup"><span data-stu-id="d9894-282">The first string represents the base64 encoded 32-byte key ID and the second represents the base64 encoded 32-byte encryption key.</span></span> <span data-ttu-id="d9894-283">キー ファイルには、単純なテキスト ファイルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-283">A key file should be a simple text file.</span></span>

<span data-ttu-id="d9894-284">キー ファイルの例</span><span class="sxs-lookup"><span data-stu-id="d9894-284">Example of a key file:</span></span>

``` Example
[Keys]
"OWVwSzliRGY1VWt1ODk4N1Q4R2Vqc04zMzIzNnlUREU="    "MjNFTlFhZGRGZEY2YnVxMTBocjd6THdOdk9pZkpvelc="
```

## <a name="mapping-files"></a><span data-ttu-id="d9894-285">マッピング ファイル</span><span class="sxs-lookup"><span data-stu-id="d9894-285">Mapping files</span></span>
<span data-ttu-id="d9894-286">マッピング ファイルでは、1 行目に文字列 "[Files]" を指定し、2 行目以降で各パッケージに追加するファイルを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-286">Mapping files must begin with a line containing the string "[Files]" followed by lines describing the files to add to the package.</span></span> <span data-ttu-id="d9894-287">各ファイルは、それぞれが引用符で囲まれたパスを 2 つ 1 組として空白またはタブで区切って表します。</span><span class="sxs-lookup"><span data-stu-id="d9894-287">Each file is described by a pair of paths in quotation marks, separated by either spaces or tabs.</span></span> <span data-ttu-id="d9894-288">各ファイルは、ソース (ディスク上) とターゲット (パッケージ内) を表します。</span><span class="sxs-lookup"><span data-stu-id="d9894-288">Each file represents its source (on disk) and destination (in the package).</span></span> <span data-ttu-id="d9894-289">マッピング ファイルには、単純なテキスト ファイルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9894-289">A mapping file should be a simple text file.</span></span>

<span data-ttu-id="d9894-290">マッピング ファイルの例 (/m オプションを使用しない場合)</span><span class="sxs-lookup"><span data-stu-id="d9894-290">Example of a mapping file (without the /m option):</span></span>

``` Example
[Files]
"C:\MyApp\StartPage.html"               "default.html"
"C:\Program Files (x86)\example.txt"    "misc\example.txt"
"\\MyServer\path\icon.png"              "icon.png"
"my app files\readme.txt"               "my app files\readme.txt"
"CustomManifest.xml"                    "AppxManifest.xml"
``` 

<span data-ttu-id="d9894-291">マッピング ファイルを使用する場合は、/m オプションを使用するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="d9894-291">When using a mapping file, you can choose whether you would like to use the /m option.</span></span> <span data-ttu-id="d9894-292">/m オプションを使うと、マッピング ファイル内のリソースのメタデータを生成されたマニフェストに含めるように指定できます。</span><span class="sxs-lookup"><span data-stu-id="d9894-292">The /m option allows the user to specify the resource metadata in the mapping file to be included in the generated manifest.</span></span> <span data-ttu-id="d9894-293">/m オプションを使う場合、マッピング ファイル内にそれに対応するセクションを設ける必要があります。このセクションは 1 行目に "[ResourceMetadata]" と指定し、それに続く行で "ResourceDimensions" と "ResourceId" を指定します。</span><span class="sxs-lookup"><span data-stu-id="d9894-293">If you use the /m option, the mapping file must contain a section that begins with the line "[ResourceMetadata]", followed by lines that specify "ResourceDimensions" and "ResourceId."</span></span> <span data-ttu-id="d9894-294">アプリ パッケージには複数の "ResourceDimensions" を含めることができますが、"ResourceId" は 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="d9894-294">It is possible for an app package to contain multiple "ResourceDimensions", but there can only ever be one "ResourceId."</span></span>

<span data-ttu-id="d9894-295">マッピング ファイルの例 (/m オプションを使用する場合)</span><span class="sxs-lookup"><span data-stu-id="d9894-295">Example of a mapping file (with the /m option):</span></span>

``` Example
[ResourceMetadata]
"ResourceDimensions"                    "language-en-us"
"ResourceId"                            "English"

[Files]
"images\en-us\logo.png"                 "en-us\logo.png"
"en-us.pri"                             "resources.pri"
```

## <a name="semantic-validation-performed-by-makeappxexe"></a><span data-ttu-id="d9894-296">MakeAppx.exe が実行するセマンティックの検証</span><span class="sxs-lookup"><span data-stu-id="d9894-296">Semantic validation performed by MakeAppx.exe</span></span>

<span data-ttu-id="d9894-297">**MakeAppx.exe** では、限定的なセマンティックの検証機能により、一般的な展開エラーを検出し、アプリ パッケージの有効性を確認します。</span><span class="sxs-lookup"><span data-stu-id="d9894-297">**MakeAppx.exe** performs limited sematic validation that is designed to catch the most common deployment errors and help ensure that the app package is valid.</span></span> <span data-ttu-id="d9894-298">**MakeAppx.exe** を使うときに検証をスキップする場合は、/nv オプションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9894-298">See the /nv option if you want to skip validation while using **MakeAppx.exe**.</span></span> 

<span data-ttu-id="d9894-299">この検証では、次の点を確認します。</span><span class="sxs-lookup"><span data-stu-id="d9894-299">This validation ensures that:</span></span>
- <span data-ttu-id="d9894-300">パッケージ マニフェストで参照されているすべてのファイルがアプリ パッケージに含まれていること。</span><span class="sxs-lookup"><span data-stu-id="d9894-300">All files referenced in the package manifest are included in the app package.</span></span>
- <span data-ttu-id="d9894-301">アプリケーションに、同一の 2 つのキーが存在しないこと。</span><span class="sxs-lookup"><span data-stu-id="d9894-301">An application does not have two identical keys.</span></span>
- <span data-ttu-id="d9894-302">アプリケーションが、SMB、FILE、MS-WWA-WEB、MS-WWA のリストに記載された禁止プロトコルを登録していないこと。</span><span class="sxs-lookup"><span data-stu-id="d9894-302">An application does not register for a forbidden protocol from this list: SMB, FILE, MS-WWA-WEB, MS-WWA.</span></span> 

<span data-ttu-id="d9894-303">これは一般的なエラーのみをチェックするように設計された機能であり、完全なセマンティックの検証ではありません。</span><span class="sxs-lookup"><span data-stu-id="d9894-303">This is not a complete semantic validation as it is only designed to catch common errors.</span></span> <span data-ttu-id="d9894-304">**MakeAppx.exe** によって作成されたパッケージのインストール可能性については保証されていません。</span><span class="sxs-lookup"><span data-stu-id="d9894-304">Packages built by **MakeAppx.exe** are not guaranteed to be installable.</span></span>