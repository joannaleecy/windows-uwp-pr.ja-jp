---
author: laurenhughes
title: MakeAppx.exe ツールを使ったアプリ パッケージの作成
description: MakeAppx.exe は、アプリ パッケージとバンドルからのファイルの作成、暗号化、暗号化解除、抽出を行います。
ms.author: lahugh
ms.date: 03/07/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, パッケージ化
ms.assetid: 7c1c3355-8bf7-4c9f-b13b-2b9874b7c63c
ms.localizationpriority: medium
ms.openlocfilehash: 94972915e5fc80a477d8d647212ab3b91e0aa384
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817793"
---
# <a name="create-an-app-package-with-the-makeappxexe-tool"></a><span data-ttu-id="541e6-104">MakeAppx.exe ツールを使ったアプリ パッケージの作成</span><span class="sxs-lookup"><span data-stu-id="541e6-104">Create an app package with the MakeAppx.exe tool</span></span>


<span data-ttu-id="541e6-105">**MakeAppx.exe** は、アプリ パッケージとアプリ パッケージ バンドルの両方を作成できます。</span><span class="sxs-lookup"><span data-stu-id="541e6-105">**MakeAppx.exe** creates both app packages and app package bundles.</span></span> <span data-ttu-id="541e6-106">**MakeAppx.exe**はまた、アプリ パッケージまたはバンドルからのファイルの抽出や、アプリ パッケージとバンドルの暗号化または暗号化解除を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="541e6-106">**MakeAppx.exe** also extracts files from an app package or bundle and encrypts or decrypts app packages and bundles.</span></span> <span data-ttu-id="541e6-107">このツールは、Windows 10 SDK に含まれており、コマンド プロンプトまたはスクリプト ファイルから使用できます。</span><span class="sxs-lookup"><span data-stu-id="541e6-107">This tool is included in the Windows 10 SDK and can be used from a command prompt or a script file.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="541e6-108">Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="541e6-108">If you used Visual Studio to develop your app, it's recommended that you use the Visual Studio wizard to create your app package.</span></span> <span data-ttu-id="541e6-109">詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-109">For more information, see [Package a UWP app with Visual Studio](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

<span data-ttu-id="541e6-110">**MakeAppx.exe** では .appxupload ファイルを作成できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="541e6-110">Note that **MakeAppx.exe** does not create an .appxupload file.</span></span> <span data-ttu-id="541e6-111">.appxupload ファイルは、Visual Studio のパッケージ化プロセスの一環として作成され、.appx と .appxsym という他の 2 つのファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="541e6-111">The .appxupload file is created as part of the Visual Studio packaging process and contains two other files: .appx and .appxsym.</span></span> <span data-ttu-id="541e6-112">.appxsym ファイルは、アプリのパブリック シンボルが格納された圧縮 .pdb ファイルです。これらのパブリック シンボルは、Windows デベロッパー センターでの[クラッシュ分析](https://blogs.windows.com/buildingapps/2015/07/13/crash-analysis-in-the-unified-dev-center/)に使われます。</span><span class="sxs-lookup"><span data-stu-id="541e6-112">The .appxsym file is a compressed .pdb file containing public symbols of your app used for [crash analytics](https://blogs.windows.com/buildingapps/2015/07/13/crash-analysis-in-the-unified-dev-center/) in the Windows Dev Center.</span></span> <span data-ttu-id="541e6-113">通常の .appx ファイルもストアに提出できますが、クラッシュ分析やデバッグ情報を行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="541e6-113">A regular .appx file can be submitted as well, but there will be no crash analytic or debugging information available.</span></span> <span data-ttu-id="541e6-114">ストアにパッケージを提出する方法について詳しくは、「[アプリ パッケージのアップロード](https://msdn.microsoft.com/windows/uwp/publish/upload-app-packages)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-114">For more information on submitting packages to the store, see [Upload app packages](https://msdn.microsoft.com/windows/uwp/publish/upload-app-packages).</span></span> 

<span data-ttu-id="541e6-115">.appxupload ファイルを手動で作成するには:</span><span class="sxs-lookup"><span data-stu-id="541e6-115">To manually create an .appxupload file:</span></span>
- <span data-ttu-id="541e6-116">.appx と .appxsym を 1 つのフォルダーに格納する</span><span class="sxs-lookup"><span data-stu-id="541e6-116">Place the .appx and the .appxsym in a folder</span></span>
- <span data-ttu-id="541e6-117">ファイルが入ったフォルダーを zip 圧縮する</span><span class="sxs-lookup"><span data-stu-id="541e6-117">Zip the folder</span></span>
- <span data-ttu-id="541e6-118">zip 圧縮したフォルダーの拡張指名を .zip から .appxupload に変更する</span><span class="sxs-lookup"><span data-stu-id="541e6-118">Change the zipped folder extension name from .zip to .appxupload</span></span>

## <a name="using-makeappxexe"></a><span data-ttu-id="541e6-119">MakeAppx.exe の使用</span><span class="sxs-lookup"><span data-stu-id="541e6-119">Using MakeAppx.exe</span></span>

<span data-ttu-id="541e6-120">SDK のインストール パスに基づき、**MakeAppx.exe** は Windows 10 PC の以下の場所にあります。</span><span class="sxs-lookup"><span data-stu-id="541e6-120">Based on your installation path of the SDK, this is where **MakeAppx.exe** is on your Windows 10 PC:</span></span>
- <span data-ttu-id="541e6-121">x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\makeappx.exe</span><span class="sxs-lookup"><span data-stu-id="541e6-121">x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\makeappx.exe</span></span>
- <span data-ttu-id="541e6-122">x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\makeappx.exe</span><span class="sxs-lookup"><span data-stu-id="541e6-122">x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\makeappx.exe</span></span>

<span data-ttu-id="541e6-123">このツールの ARM バージョンはありません。</span><span class="sxs-lookup"><span data-stu-id="541e6-123">There is no ARM version of this tool.</span></span>

### <a name="makeappxexe-syntax-and-options"></a><span data-ttu-id="541e6-124">MakeAppx.exe の構文とオプション</span><span class="sxs-lookup"><span data-stu-id="541e6-124">MakeAppx.exe syntax and options</span></span>

<span data-ttu-id="541e6-125">一般的な **MakeAppx.exe** の構文:</span><span class="sxs-lookup"><span data-stu-id="541e6-125">General **MakeAppx.exe** syntax:</span></span>

``` Usage
MakeAppx <command> [options]      
```

<span data-ttu-id="541e6-126">次の表では、**MakeAppx.exe** のコマンドについて説明します。</span><span class="sxs-lookup"><span data-stu-id="541e6-126">The following table describes the commands for **MakeAppx.exe**.</span></span>

| **<span data-ttu-id="541e6-127">コマンド</span><span class="sxs-lookup"><span data-stu-id="541e6-127">Command</span></span>**   | **<span data-ttu-id="541e6-128">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-128">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-129">pack</span><span class="sxs-lookup"><span data-stu-id="541e6-129">pack</span></span>          | <span data-ttu-id="541e6-130">パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="541e6-130">Creates a package.</span></span>                    |
| <span data-ttu-id="541e6-131">unpack</span><span class="sxs-lookup"><span data-stu-id="541e6-131">unpack</span></span>        | <span data-ttu-id="541e6-132">指定されたパッケージ内のすべてのファイルを、指定された出力ディレクトリに抽出します。</span><span class="sxs-lookup"><span data-stu-id="541e6-132">Extracts all files in the specified package to the specified output directory.</span></span> |
| <span data-ttu-id="541e6-133">bundle</span><span class="sxs-lookup"><span data-stu-id="541e6-133">bundle</span></span>        | <span data-ttu-id="541e6-134">バンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="541e6-134">Creates a bundle.</span></span>                     |
| <span data-ttu-id="541e6-135">unbundle</span><span class="sxs-lookup"><span data-stu-id="541e6-135">unbundle</span></span>      | <span data-ttu-id="541e6-136">指定された出力パスの下に、バンドルの完全な名前に基づく名前のサブディレクトリを作成し、すべてのパッケージをそのディレクトリにアンパックします。</span><span class="sxs-lookup"><span data-stu-id="541e6-136">Unpacks all packages to a subdirectory under the specified output path named after the bundle full name.</span></span> |
| <span data-ttu-id="541e6-137">encrypt</span><span class="sxs-lookup"><span data-stu-id="541e6-137">encrypt</span></span>       | <span data-ttu-id="541e6-138">入力パッケージ/バンドルから、暗号化されたアプリ パッケージやバンドルを作成し、指定された出力パッケージ/バンドルとして保存します。</span><span class="sxs-lookup"><span data-stu-id="541e6-138">Creates an encrypted app package or bundle from the input package/bundle at the specified output package/bundle.</span></span> |
| <span data-ttu-id="541e6-139">decrypt</span><span class="sxs-lookup"><span data-stu-id="541e6-139">decrypt</span></span>       | <span data-ttu-id="541e6-140">入力アプリ パッケージ/バンドルから、暗号化解除されたアプリ パッケージやバンドルを作成し、指定された出力パッケージ/バンドルとして保存します。</span><span class="sxs-lookup"><span data-stu-id="541e6-140">Creates an decrypted app package or bundle from the input app package/bundle at the specified output package/bundle.</span></span> |
| <span data-ttu-id="541e6-141">ビルド</span><span class="sxs-lookup"><span data-stu-id="541e6-141">build</span></span>         |  |


<span data-ttu-id="541e6-142">このオプションの一覧は、すべてのコマンドに適用されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-142">This list of options applies to all commands:</span></span>

| **<span data-ttu-id="541e6-143">オプション</span><span class="sxs-lookup"><span data-stu-id="541e6-143">Option</span></span>**    | **<span data-ttu-id="541e6-144">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-144">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-145">/d</span><span class="sxs-lookup"><span data-stu-id="541e6-145">/d</span></span>            | <span data-ttu-id="541e6-146">入力ディレクトリ、出力ディレクトリ、またはコンテンツ ディレクトリを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-146">Specifies the input, output, or content directory.</span></span> |
| <span data-ttu-id="541e6-147">/l</span><span class="sxs-lookup"><span data-stu-id="541e6-147">/l</span></span>            | <span data-ttu-id="541e6-148">ローカライズされたパッケージに対して使用されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-148">Used for localized packages.</span></span> <span data-ttu-id="541e6-149">既定の検証が、ローカライズされたパッケージで無効になります。</span><span class="sxs-lookup"><span data-stu-id="541e6-149">The default validation trips on localized packages.</span></span> <span data-ttu-id="541e6-150">このオプションを使用すると、すべての検証を無効にすることなく、その特定の検証のみが無効になります。</span><span class="sxs-lookup"><span data-stu-id="541e6-150">This options disables only that specific validation, without requiring that all validation be disabled.</span></span> |
| <span data-ttu-id="541e6-151">/kf</span><span class="sxs-lookup"><span data-stu-id="541e6-151">/kf</span></span>           | <span data-ttu-id="541e6-152">指定したキー ファイルのキーを使って、パッケージやバンドルを暗号化または暗号化解除します。</span><span class="sxs-lookup"><span data-stu-id="541e6-152">Encrypts or decrypts the package or bundle using the key from the specified key file.</span></span> <span data-ttu-id="541e6-153">このオプションは、/kt と一緒に使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="541e6-153">This can't be used with /kt.</span></span> |
| <span data-ttu-id="541e6-154">/kt</span><span class="sxs-lookup"><span data-stu-id="541e6-154">/kt</span></span>           | <span data-ttu-id="541e6-155">グローバル テスト キーを使ってパッケージやバンドルを暗号化または暗号化解除します。</span><span class="sxs-lookup"><span data-stu-id="541e6-155">Encrypts the or decrypts package or bundle using the global test key.</span></span> <span data-ttu-id="541e6-156">これは、/kf と一緒に使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="541e6-156">This can't be used with /kf.</span></span> |
| <span data-ttu-id="541e6-157">/no</span><span class="sxs-lookup"><span data-stu-id="541e6-157">/no</span></span>           | <span data-ttu-id="541e6-158">出力ファイルが存在する場合に、出力ファイルを上書きしません。</span><span class="sxs-lookup"><span data-stu-id="541e6-158">Prevents an overwrite of the output file if it exists.</span></span> <span data-ttu-id="541e6-159">このオプションか /o オプションのいずれも指定しない場合は、ファイルを上書きするかどうかを尋ねるメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-159">If you don't specify this option or the /o option, the user is asked whether they want to overwrite the file.</span></span> |
| <span data-ttu-id="541e6-160">/nv</span><span class="sxs-lookup"><span data-stu-id="541e6-160">/nv</span></span>           | <span data-ttu-id="541e6-161">セマンティクス検証をスキップします。</span><span class="sxs-lookup"><span data-stu-id="541e6-161">Skips semantic validation.</span></span> <span data-ttu-id="541e6-162">このオプションを指定しない場合、パッケージの完全な検証が実行されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-162">If you don't specify this option, the tool performs a full validation of the package.</span></span> |
| <span data-ttu-id="541e6-163">/o</span><span class="sxs-lookup"><span data-stu-id="541e6-163">/o</span></span>            | <span data-ttu-id="541e6-164">存在する場合は、出力ファイルを上書きします。</span><span class="sxs-lookup"><span data-stu-id="541e6-164">Overwrites the output file if it exists.</span></span> <span data-ttu-id="541e6-165">このオプションも /no オプションも指定しない場合は、ファイルを上書きするかどうかを尋ねるメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-165">If you don't specify this option or the /no option, the user is asked whether they want to overwrite the file.</span></span> |
| <span data-ttu-id="541e6-166">/p</span><span class="sxs-lookup"><span data-stu-id="541e6-166">/p</span></span>            | <span data-ttu-id="541e6-167">アプリ パッケージまたはバンドルを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-167">Specifies the app package or bundle.</span></span>  |
| <span data-ttu-id="541e6-168">/v</span><span class="sxs-lookup"><span data-stu-id="541e6-168">/v</span></span>            | <span data-ttu-id="541e6-169">コンソールへの詳細なログ出力を有効にします。</span><span class="sxs-lookup"><span data-stu-id="541e6-169">Enables verbose logging output to the console.</span></span> |
| <span data-ttu-id="541e6-170">/?</span><span class="sxs-lookup"><span data-stu-id="541e6-170">/?</span></span>            | <span data-ttu-id="541e6-171">ヘルプ テキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-171">Displays help text.</span></span>                   |


<span data-ttu-id="541e6-172">次の一覧では、使用可能な引数を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-172">The following list contains possible arguments:</span></span>

| **<span data-ttu-id="541e6-173">引数</span><span class="sxs-lookup"><span data-stu-id="541e6-173">Argument</span></span>**                          | **<span data-ttu-id="541e6-174">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-174">Description</span></span>**                       |
|---------------------------------------|---------------------------------------|
| <span data-ttu-id="541e6-175">&lt;出力パッケージの名前&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-175">&lt;output package name&gt;</span></span>           | <span data-ttu-id="541e6-176">作成されるパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-176">The name of the package created.</span></span> <span data-ttu-id="541e6-177">ファイル名の末尾に .appx が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-177">This is the file name appended with .appx.</span></span> |
| <span data-ttu-id="541e6-178">&lt;暗号化された出力パッケージの名前&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-178">&lt;encrypted output package name&gt;</span></span> | <span data-ttu-id="541e6-179">作成される暗号化されたパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-179">The name of the encrypted package created.</span></span> <span data-ttu-id="541e6-180">ファイル名の末尾に .eappx が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-180">This is the file name appended with .eappx.</span></span> |
| <span data-ttu-id="541e6-181">&lt;入力パッケージ名&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-181">&lt;input package name&gt;</span></span>            | <span data-ttu-id="541e6-182">パッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-182">The name of the package.</span></span> <span data-ttu-id="541e6-183">ファイル名の末尾に .appx が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-183">This is the file name appended with .appx.</span></span> |
| <span data-ttu-id="541e6-184">&lt;暗号化された入力パッケージ名&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-184">&lt;encrypted input package name&gt;</span></span>  | <span data-ttu-id="541e6-185">暗号化されたパッケージの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-185">The name of the encrypted package.</span></span> <span data-ttu-id="541e6-186">ファイル名の末尾に .eappx が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-186">This is the file name appended with .eappx.</span></span> |
| <span data-ttu-id="541e6-187">&lt;出力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-187">&lt;output bundle name&gt;</span></span>            | <span data-ttu-id="541e6-188">作成されるバンドルの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-188">The name of the bundle created.</span></span> <span data-ttu-id="541e6-189">ファイル名の末尾に .appxbundle が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-189">This is the file name appended with .appxbundle.</span></span> |
| <span data-ttu-id="541e6-190">&lt;暗号化された出力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-190">&lt;encrypted output bundle name&gt;</span></span>  | <span data-ttu-id="541e6-191">作成される暗号化されたバンドルの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-191">The name of the encrypted bundle created.</span></span> <span data-ttu-id="541e6-192">ファイル名の末尾に .eappxbundle が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-192">This is the file name appended with .eappxbundle.</span></span> |
| <span data-ttu-id="541e6-193">&lt;入力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-193">&lt;input bundle name&gt;</span></span>             | <span data-ttu-id="541e6-194">バンドルの名前。</span><span class="sxs-lookup"><span data-stu-id="541e6-194">The name of the bundle.</span></span> <span data-ttu-id="541e6-195">ファイル名の末尾に .appxbundle が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-195">This is the file name appended with .appxbundle.</span></span> |
| <span data-ttu-id="541e6-196">&lt;暗号化された入力バンドル名&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-196">&lt;encrypted input bundle name&gt;</span></span>   | <span data-ttu-id="541e6-197">暗号化されたバンドルの名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-197">The name of the encrypted bundle.</span></span> <span data-ttu-id="541e6-198">ファイル名の末尾に .eappxbundle が追加された名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-198">This is the file name appended with .eappxbundle.</span></span> |
| <span data-ttu-id="541e6-199">&lt;コンテンツ ディレクトリ&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-199">&lt;content directory&gt;</span></span>             | <span data-ttu-id="541e6-200">アプリ パッケージまたはバンドルのコンテンツのパス。</span><span class="sxs-lookup"><span data-stu-id="541e6-200">Path for the app package or bundle content.</span></span> |
| <span data-ttu-id="541e6-201">&lt;マッピング ファイル&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-201">&lt;mapping file&gt;</span></span>                  | <span data-ttu-id="541e6-202">パッケージのソースとターゲットを指定するファイル名。</span><span class="sxs-lookup"><span data-stu-id="541e6-202">File name that specifies the package source and destination.</span></span> |
| <span data-ttu-id="541e6-203">&lt;出力ディレクトリ&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-203">&lt;output directory&gt;</span></span>              | <span data-ttu-id="541e6-204">出力パッケージとバンドルのディレクトリへのパス。</span><span class="sxs-lookup"><span data-stu-id="541e6-204">Path to the directory for output packages and bundles.</span></span> |
| <span data-ttu-id="541e6-205">&lt;キー ファイル&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-205">&lt;key file&gt;</span></span>                      | <span data-ttu-id="541e6-206">暗号化キーまたは暗号化解除キーが含まれているファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="541e6-206">Name of the file containing a key for encryption or decryption.</span></span> |
| <span data-ttu-id="541e6-207">&lt;アルゴリズム ID&gt;</span><span class="sxs-lookup"><span data-stu-id="541e6-207">&lt;algorithm ID&gt;</span></span>                  | <span data-ttu-id="541e6-208">ブロック マップの作成時に使用されるアルゴリズム。</span><span class="sxs-lookup"><span data-stu-id="541e6-208">Algorithms used when creating a block map.</span></span> <span data-ttu-id="541e6-209">有効なアルゴリズムには、SHA256 (既定)、SHA384、SHA512 があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-209">Valid algorithms include: SHA256 (default), SHA384, SHA512.</span></span> |


### <a name="create-an-app-package"></a><span data-ttu-id="541e6-210">アプリ パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="541e6-210">Create an app package</span></span>

<span data-ttu-id="541e6-211">アプリ パッケージは、.appx パッケージ ファイルにパッケージ化されたアプリ ファイルの完全なセットです。</span><span class="sxs-lookup"><span data-stu-id="541e6-211">An app package is a complete set of the app's files packaged in to an .appx package file.</span></span> <span data-ttu-id="541e6-212">**pack** コマンドを使ってアプリ パッケージを作成するには、パッケージの保存場所としてコンテンツ ディレクトリまたはマッピング ファイルを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-212">To create an app package using the **pack** command, you must provide either a content directory or a mapping file for the location of the package.</span></span> <span data-ttu-id="541e6-213">また作成時にパッケージを暗号化することもできます。</span><span class="sxs-lookup"><span data-stu-id="541e6-213">You can also encrypt a package while creating it.</span></span> <span data-ttu-id="541e6-214">パッケージを暗号化する場合は、/ep を使って、キー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-214">If you want to encrypt the package, you must use /ep and specify if you are using a key file (/kf) or the global test key (/kt).</span></span> <span data-ttu-id="541e6-215">暗号化されたパッケージを作成する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-215">For more information on creating an encrypted package, see [Encrypt or decrypt a package or bundle](#encrypt-or-decrypt-a-package-or-bundle).</span></span>

<span data-ttu-id="541e6-216">**pack** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="541e6-216">Options specific to the **pack** command:</span></span>

| **<span data-ttu-id="541e6-217">オプション</span><span class="sxs-lookup"><span data-stu-id="541e6-217">Option</span></span>**    | **<span data-ttu-id="541e6-218">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-218">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-219">/f</span><span class="sxs-lookup"><span data-stu-id="541e6-219">/f</span></span>            | <span data-ttu-id="541e6-220">マッピング ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-220">Specifies the mapping file.</span></span>           |
| <span data-ttu-id="541e6-221">/h</span><span class="sxs-lookup"><span data-stu-id="541e6-221">/h</span></span>            | <span data-ttu-id="541e6-222">ブロック マップを作成するときに使うハッシュ アルゴリズムを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-222">Specifies the hash algorithm to use when creating the block map.</span></span> <span data-ttu-id="541e6-223">これは、pack コマンドでのみ使うことができます。</span><span class="sxs-lookup"><span data-stu-id="541e6-223">This can only be used with the pack command.</span></span> <span data-ttu-id="541e6-224">有効なアルゴリズムには、SHA256 (既定)、SHA384、SHA512 があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-224">Valid algorithms include: SHA256 (default), SHA384, SHA512.</span></span> |
| <span data-ttu-id="541e6-225">/m</span><span class="sxs-lookup"><span data-stu-id="541e6-225">/m</span></span>            | <span data-ttu-id="541e6-226">入力アプリ マニフェストへのパスを指定します。出力アプリ パッケージまたはリソース パッケージのマニフェストは、このパスに基づいて生成されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-226">Specifies the path to an input app manifest which will be used as the basis for generating the output app package or resource package's manifest.</span></span>  <span data-ttu-id="541e6-227">このオプションを使用するときには、/f を一緒に使用すると共にマッピング ファイルに [ResourceMetadata] セクションを追加し、生成されるマニフェストに含まれるリソースの次元を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-227">When you use this option, you must also use /f and include a [ResourceMetadata] section in the mapping file to specify the resource dimensions to be included in the generated manifest.</span></span>|
| <span data-ttu-id="541e6-228">/nc</span><span class="sxs-lookup"><span data-stu-id="541e6-228">/nc</span></span>           | <span data-ttu-id="541e6-229">パッケージ ファイルを圧縮しないことを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-229">Prevents compression of the package files.</span></span> <span data-ttu-id="541e6-230">既定では、検出されたファイルの種類に基づいてファイルが圧縮されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-230">By default, files are compressed based on detected file type.</span></span> |
| <span data-ttu-id="541e6-231">/r</span><span class="sxs-lookup"><span data-stu-id="541e6-231">/r</span></span>            | <span data-ttu-id="541e6-232">リソース パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="541e6-232">Builds a resource package.</span></span> <span data-ttu-id="541e6-233">これは /m と共に使う必要があり、/l オプションを使用することを意味します。</span><span class="sxs-lookup"><span data-stu-id="541e6-233">This must be used with /m and implies the use of the /l option.</span></span> |  


<span data-ttu-id="541e6-234">以下では、**pack**コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-234">The following usage examples show some possible syntax options for the **pack** command:</span></span>

``` syntax 
MakeAppx pack [options] /d <content directory> /p <output package name>
MakeAppx pack [options] /f <mapping file> /p <output package name>
MakeAppx pack [options] /m <app package manifest> /f <mapping file> /p <output package name>
MakeAppx pack [options] /r /m <app package manifest> /f <mapping file> /p <output package name>
MakeAppx pack [options] /d <content directory> /ep <encrypted output package name> /kf <key file>
MakeAppx pack [options] /d <content directory> /ep <encrypted output package name> /kt

```
<span data-ttu-id="541e6-235">以下では、**pack** コマンドのコマンド ラインの例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-235">The following shows command line examples for the **pack** command:</span></span>

``` examples
MakeAppx pack /v /h SHA256 /d "C:\My Files" /p MyPackage.appx
MakeAppx pack /v /o /f MyMapping.txt /p MyPackage.appx
MakeAppx pack /m "MyApp\AppxManifest.xml" /f MyMapping.txt /p AppPackage.appx
MakeAppx pack /r /m "MyApp\AppxManifest.xml" /f MyMapping.txt /p ResourcePackage.appx
MakeAppx pack /v /h SHA256 /d "C:\My Files" /ep MyPackage.eappx /kf MyKeyFile.txt
MakeAppx pack /v /h SHA256 /d "C:\My Files" /ep MyPackage.eappx /kt
```

### <a name="create-an-app-bundle"></a><span data-ttu-id="541e6-236">アプリ バンドルを作成する</span><span class="sxs-lookup"><span data-stu-id="541e6-236">Create an app bundle</span></span>

<span data-ttu-id="541e6-237">アプリ バンドルはアプリ パッケージに似ていますが、バンドルではユーザーがダウンロードするアプリのサイズを小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="541e6-237">An app bundle is similar to an app package, but a bundle can reduce the size of the app that users download.</span></span> <span data-ttu-id="541e6-238">たとえば、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースが含まれる場合などは、アプリ バンドルを使うと便利です。</span><span class="sxs-lookup"><span data-stu-id="541e6-238">App bundles are helpful for language-specific assets, varying image-scale assets, or resources that apply to specific versions of Microsoft DirectX, for example.</span></span> <span data-ttu-id="541e6-239">アプリ パッケージが作成時に暗号化できるのと同様、アプリ バンドルもバンドル時に暗号化できます。</span><span class="sxs-lookup"><span data-stu-id="541e6-239">Similar to creating an encrypted app package, you can also encrypt the app bundle while bundling it.</span></span> <span data-ttu-id="541e6-240">アプリ バンドルを暗号化するには、/ep オプションを使って、キー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-240">To encrypt the app bundle, use the /ep option and specify if you are using a key file (/kf) or the global test key (/kt).</span></span> <span data-ttu-id="541e6-241">暗号化されたバンドルを作成する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-241">For more information on creating an encrypted bundle, see [Encrypt or decrypt a package or bundle](#encrypt-or-decrypt-a-package-or-bundle).</span></span>

<span data-ttu-id="541e6-242">**bundle** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="541e6-242">Options specific to the **bundle** command:</span></span>

| **<span data-ttu-id="541e6-243">オプション</span><span class="sxs-lookup"><span data-stu-id="541e6-243">Option</span></span>**    | **<span data-ttu-id="541e6-244">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-244">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-245">/bv</span><span class="sxs-lookup"><span data-stu-id="541e6-245">/bv</span></span>           | <span data-ttu-id="541e6-246">バンドルのバージョン番号を指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-246">Specifies the version number of the bundle.</span></span> <span data-ttu-id="541e6-247">バージョン番号は、4 つの部分をピリオドで区切って、&lt;メジャー番号&gt;.&lt;マイナー番号&gt;.&lt;ビルド&gt;.&lt;リビジョン&gt; の形式で指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-247">The version number must be in four parts separated by periods in the form: &lt;Major&gt;.&lt;Minor&gt;.&lt;Build&gt;.&lt;Revision&gt;.</span></span> |
| <span data-ttu-id="541e6-248">/f</span><span class="sxs-lookup"><span data-stu-id="541e6-248">/f</span></span>            | <span data-ttu-id="541e6-249">マッピング ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-249">Specifies the mapping file.</span></span>           |

<span data-ttu-id="541e6-250">バンドルのバージョンが指定されていないか、"0.0.0.0" に設定されている場合は、現在の日付と時刻を使用してバンドルが作成されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="541e6-250">Note that if the bundle version is not specified or if it is set to "0.0.0.0" the bundle is created using the current date-time.</span></span>

<span data-ttu-id="541e6-251">以下では、**bundle**コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-251">The following usage examples show some possible syntax options for the **bundle** command:</span></span>

``` syntax
MakeAppx bundle [options] /d <content directory> /p <output bundle name>
MakeAppx bundle [options] /f <mapping file> /p <output bundle name>
MakeAppx bundle [options] /d <content directory> /ep <encrypted output bundle name> /kf MyKeyFile.txt
MakeAppx bundle [options] /f <mapping file> /ep <encrypted output bundle name> /kt
```
<span data-ttu-id="541e6-252">以下のブロックでは、**bundle** コマンドの例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-252">The following block contains examples for the **bundle** command:</span></span>

``` examples
MakeAppx bundle /v /d "C:\My Files" /p MyBundle.appxbundle
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /p MyBundle.appxbundle
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /ep MyBundle.eappxbundle /kf MyKeyFile.txt
MakeAppx bundle /v /o /bv 1.0.1.2096 /f MyMapping.txt /ep MyBundle.eappxbundle /kt
```

### <a name="extract-files-from-a-package-or-bundle"></a><span data-ttu-id="541e6-253">パッケージまたはバンドルからファイルを抽出する</span><span class="sxs-lookup"><span data-stu-id="541e6-253">Extract files from a package or bundle</span></span>

<span data-ttu-id="541e6-254">**MakeAppx.exe** はアプリのパッケージとバンドルだけでなく、既存のパッケージのアンパックやアンバンドルに使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="541e6-254">In addition to packaging and bundling apps, **MakeAppx.exe** can also unpack or unbundle existing packages.</span></span> <span data-ttu-id="541e6-255">展開されたファイルの保存先としてコンテンツ ディレクトリを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-255">You must provide the content directory as a destination for the extracted files.</span></span> <span data-ttu-id="541e6-256">暗号化されたパッケージまたはバンドルからファイルを抽出する場合は、/ep オプションを使って、暗号化解除にキー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使うかを指定することで、ファイルの暗号化解除と抽出を同時に実行できます。</span><span class="sxs-lookup"><span data-stu-id="541e6-256">If you are trying to extract files from an encrypted package or bundle, you can decrypt and extract the files at the same time using the /ep option and specifying whether it should be decrypted using a key file (/kf) or the global test key (/kt).</span></span> <span data-ttu-id="541e6-257">パッケージまたはバンドルを暗号化解除する方法について詳しくは、「[パッケージまたはバンドルを暗号化または暗号化解除する](#encrypt-or-decrypt-a-package-or-bundle)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-257">For more information on decrypting a package or bundle, see [Encrypt or decrypt a package or bundle](#encrypt-or-decrypt-a-package-or-bundle).</span></span>

<span data-ttu-id="541e6-258">**unpack** コマンドと **unbundle** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="541e6-258">Options specific to **unpack** and **unbundle** commands:</span></span>

| **<span data-ttu-id="541e6-259">オプション</span><span class="sxs-lookup"><span data-stu-id="541e6-259">Option</span></span>**    | **<span data-ttu-id="541e6-260">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-260">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-261">/nd</span><span class="sxs-lookup"><span data-stu-id="541e6-261">/nd</span></span>           | <span data-ttu-id="541e6-262">パッケージやバンドルをアンパックまたはアンバンドルするときに、暗号化解除を行いません。</span><span class="sxs-lookup"><span data-stu-id="541e6-262">Does not perform decryption when unpacking or unbundling the package/bundle.</span></span> |
| <span data-ttu-id="541e6-263">/pfn</span><span class="sxs-lookup"><span data-stu-id="541e6-263">/pfn</span></span>          | <span data-ttu-id="541e6-264">指定した出力パスの下に、パッケージまたはバンドルの完全な名前に基づく名前のサブディレクトリが作成され、アンパックまたはアンバンドルしたすべてのファイルが保存されます。</span><span class="sxs-lookup"><span data-stu-id="541e6-264">Unpacks/unbundles all files to a subdirectory under the specified output path, named after the package or bundle full name</span></span> |

<span data-ttu-id="541e6-265">以下では、**unpack** コマンドと **unbundle** コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-265">The following usage examples show some possible syntax options for the **unpack** and **unbundle** commands:</span></span>

``` syntax
MakeAppx unpack [options] /p <input package name> /d <output directory>
MakeAppx unpack [options] /ep <encrypted input package name> /d <output directory> /kf <key file>
MakeAppx unpack [options] /ep <encrypted input package name> /d <output directory> /kt

MakeAppx unbundle [options] /p <input bundle name> /d <output directory>
MakeAppx unbundle [options] /ep <encrypted input bundle name> /d <output directory> /kf <key file>
MakeAppx unbundle [options] /ep <encrypted input bundle name> /d <output directory> /kt
```

<span data-ttu-id="541e6-266">以下のブロックでは、**unpack** コマンドと **unbundle** コマンドの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-266">The following block contains examples for using the **unpack** and **unbundle** commands:</span></span>

``` examples
MakeAppx unpack /v /p MyPackage.appx /d "C:\My Files"
MakeAppx unpack /v /ep MyPackage.eappx /d "C:\My Files" /kf MyKeyFile.txt
MakeAppx unpack /v /ep MyPackage.eappx /d "C:\My Files" /kt

MakeAppx unbundle /v /p MyBundle.appxbundle /d "C:\My Files"
MakeAppx unbundle /v /ep MyBundle.eappxbundle /d "C:\My Files" /kf MyKeyFile.txt
MakeAppx unbundle /v /ep MyBundle.eappxbundle /d "C:\My Files" /kt
```

### <a name="encrypt-or-decrypt-a-package-or-bundle"></a><span data-ttu-id="541e6-267">パッケージまたはバンドルを暗号化または暗号化解除する</span><span class="sxs-lookup"><span data-stu-id="541e6-267">Encrypt or decrypt a package or bundle</span></span>

<span data-ttu-id="541e6-268">**MakeAppx.exe**ツールでは、既存のパッケージやバンドルの暗号化や暗号化解除を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="541e6-268">The **MakeAppx.exe** tool can also encrypt or decrypt an existing package or bundle.</span></span> <span data-ttu-id="541e6-269">これには、パッケージ名と出力パッケージ名に加え、暗号化や暗号化解除にキー ファイル (/kf) とグローバル テスト キー (/kt) のいずれを使用するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-269">You must simply provide the package name, the output package name, and whether encryption or decryption should use a key file (/kf) or the global test key (/kt).</span></span>

<span data-ttu-id="541e6-270">暗号化と暗号化解除は、Visual Studio パッケージ ウィザードでは実行できません。</span><span class="sxs-lookup"><span data-stu-id="541e6-270">Encryption and decryption are not available through the Visual Studio packaging wizard.</span></span> 

<span data-ttu-id="541e6-271"> **encrypt** コマンドと **decrypt** コマンド固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="541e6-271">Options specific to **encrypt** and **decrypt** commands:</span></span>

| **<span data-ttu-id="541e6-272">オプション</span><span class="sxs-lookup"><span data-stu-id="541e6-272">Option</span></span>**    | **<span data-ttu-id="541e6-273">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-273">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-274">/ep</span><span class="sxs-lookup"><span data-stu-id="541e6-274">/ep</span></span>           | <span data-ttu-id="541e6-275">暗号化されたアプリ パッケージまたはバンドルを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-275">Specifies an encrypted app package or bundle.</span></span> |

<span data-ttu-id="541e6-276">以下では、**encrypt** コマンドと **decrypt** コマンドの構文オプションの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-276">The following usage examples show some possible syntax options for the **encrypt** and **decrypt** commands:</span></span>

``` syntax
MakeAppx encrypt [options] /p <package name> /ep <output package name> /kf <key file>
MakeAppx encrypt [options] /p <package name> /ep <output package name> /kt

MakeAppx decrypt [options] /ep <package name> /p <output package name> /kf <key file>
MakeAppx decrypt [options] /ep <package name> /p <output package name> /kt
```

<span data-ttu-id="541e6-277">以下のブロックでは、**encrypt** コマンドと **decrypt** コマンドの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-277">The following block contains examples for using the **encrypt** and **decrypt** commands:</span></span>

``` examples
MakeAppx.exe encrypt /p MyPackage.appx /ep MyEncryptedPackage.eappx /kt
MakeAppx.exe encrypt /p MyPackage.appx /ep MyEncryptedPackage.eappx /kf MyKeyFile.txt

MakeAppx.exe decrypt /p MyPackage.appx /ep MyEncryptedPackage.eappx /kt
MakeAppx.exe decrypt p MyPackage.appx /ep MyEncryptedPackage.eappx /kf MyKeyFile.txt
```

### <a name="build-an-app-package"></a><span data-ttu-id="541e6-278">アプリ パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="541e6-278">Build an app package</span></span> 

<span data-ttu-id="541e6-279">**MakeAppx.exe** は、アプリ パッケージ レイアウト ファイルに基づいてアプリをビルドできます。</span><span class="sxs-lookup"><span data-stu-id="541e6-279">**MakeAppx.exe** can build an app based on it's app package layout file.</span></span> <span data-ttu-id="541e6-280">パッケージ レイアウト ファイルを作成する方法と **MakeAppx.exe** を使ってビルドする方法については、「[パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-280">To learn how to create a package layout file and how to use **MakeAppx.exe** to build it, see [Package creation with the packaging layout](packaging-layout.md).</span></span>  

<span data-ttu-id="541e6-281">**build** コマンドに固有のオプション:</span><span class="sxs-lookup"><span data-stu-id="541e6-281">Options specific to the **build** command:</span></span>

| **<span data-ttu-id="541e6-282">オプション</span><span class="sxs-lookup"><span data-stu-id="541e6-282">Option</span></span>**    | **<span data-ttu-id="541e6-283">説明</span><span class="sxs-lookup"><span data-stu-id="541e6-283">Description</span></span>**                       |
|---------------|---------------------------------------|
| <span data-ttu-id="541e6-284">/bc</span><span class="sxs-lookup"><span data-stu-id="541e6-284">/bc</span></span>           | <span data-ttu-id="541e6-285">ビルドするパッケージ ファミリでサブパッケージを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-285">Specifies the sub-packages in a package family to be built.</span></span>  |
| <span data-ttu-id="541e6-286">/id</span><span class="sxs-lookup"><span data-stu-id="541e6-286">/id</span></span>           | <span data-ttu-id="541e6-287">パッケージ **ID** 属性に基づいてビルドするパッケージを選択するために使います。</span><span class="sxs-lookup"><span data-stu-id="541e6-287">Used to select packages to be built based on the package **ID** attribute.</span></span> |
| <span data-ttu-id="541e6-288">/ip</span><span class="sxs-lookup"><span data-stu-id="541e6-288">/ip</span></span>           | <span data-ttu-id="541e6-289">以前のバージョンのアプリ パッケージの場所を示します。</span><span class="sxs-lookup"><span data-stu-id="541e6-289">Indicates the location of previous versions of an app package.</span></span> |
| <span data-ttu-id="541e6-290">/iv</span><span class="sxs-lookup"><span data-stu-id="541e6-290">/iv</span></span>           | <span data-ttu-id="541e6-291">ビルドするパッケージのバージョンを自動的に増分します。</span><span class="sxs-lookup"><span data-stu-id="541e6-291">Automatically increments the version of the packages being built.</span></span> |
| <span data-ttu-id="541e6-292">/f</span><span class="sxs-lookup"><span data-stu-id="541e6-292">/f</span></span>            | <span data-ttu-id="541e6-293">パッケージ レイアウト ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-293">Specifies the packaging layout file.</span></span> |
| <span data-ttu-id="541e6-294">/nbp</span><span class="sxs-lookup"><span data-stu-id="541e6-294">/nbp</span></span>          | <span data-ttu-id="541e6-295">アプリ パッケージをビルドしないことを指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-295">Indicates that an app package should not be built.</span></span> |
| <span data-ttu-id="541e6-296">/op</span><span class="sxs-lookup"><span data-stu-id="541e6-296">/op</span></span>           | <span data-ttu-id="541e6-297">出力パッケージの移動先。</span><span class="sxs-lookup"><span data-stu-id="541e6-297">The output package destination.</span></span> |

## <a name="key-files"></a><span data-ttu-id="541e6-298">キー ファイル</span><span class="sxs-lookup"><span data-stu-id="541e6-298">Key files</span></span>

<span data-ttu-id="541e6-299">キー ファイルは、1 行目で文字列 "[Keys]" を指定し、2 行目以降で各パッケージを暗号化するキーを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-299">Key files must begin with a line containing the string "[Keys]" followed by lines describing the keys to encrypt each package with.</span></span> <span data-ttu-id="541e6-300">各キーは、それぞれが引用符で囲まれた文字列を 2 つ 1 組として空白またはタブで区切って表します。</span><span class="sxs-lookup"><span data-stu-id="541e6-300">Each key is represented by a pair of strings in quotation marks, separated by either spaces or tabs.</span></span> <span data-ttu-id="541e6-301">最初の文字列は base64 でエンコードされた 32 バイトのキー ID を表し、2 番目の文字列は base64 でエンコードされた 32 バイトの暗号化キーを表します。</span><span class="sxs-lookup"><span data-stu-id="541e6-301">The first string represents the base64 encoded 32-byte key ID and the second represents the base64 encoded 32-byte encryption key.</span></span> <span data-ttu-id="541e6-302">キー ファイルには、単純なテキスト ファイルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-302">A key file should be a simple text file.</span></span>

<span data-ttu-id="541e6-303">キー ファイルの例</span><span class="sxs-lookup"><span data-stu-id="541e6-303">Example of a key file:</span></span>

``` Example
[Keys]
"OWVwSzliRGY1VWt1ODk4N1Q4R2Vqc04zMzIzNnlUREU="    "MjNFTlFhZGRGZEY2YnVxMTBocjd6THdOdk9pZkpvelc="
```

## <a name="mapping-files"></a><span data-ttu-id="541e6-304">マッピング ファイル</span><span class="sxs-lookup"><span data-stu-id="541e6-304">Mapping files</span></span>
<span data-ttu-id="541e6-305">マッピング ファイルでは、1 行目に文字列 "[Files]" を指定し、2 行目以降で各パッケージに追加するファイルを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-305">Mapping files must begin with a line containing the string "[Files]" followed by lines describing the files to add to the package.</span></span> <span data-ttu-id="541e6-306">各ファイルは、それぞれが引用符で囲まれたパスを 2 つ 1 組として空白またはタブで区切って表します。</span><span class="sxs-lookup"><span data-stu-id="541e6-306">Each file is described by a pair of paths in quotation marks, separated by either spaces or tabs.</span></span> <span data-ttu-id="541e6-307">各ファイルは、ソース (ディスク上) とターゲット (パッケージ内) を表します。</span><span class="sxs-lookup"><span data-stu-id="541e6-307">Each file represents its source (on disk) and destination (in the package).</span></span> <span data-ttu-id="541e6-308">マッピング ファイルには、単純なテキスト ファイルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="541e6-308">A mapping file should be a simple text file.</span></span>

<span data-ttu-id="541e6-309">マッピング ファイルの例 (/m オプションを使用しない場合)</span><span class="sxs-lookup"><span data-stu-id="541e6-309">Example of a mapping file (without the /m option):</span></span>

``` Example
[Files]
"C:\MyApp\StartPage.html"               "default.html"
"C:\Program Files (x86)\example.txt"    "misc\example.txt"
"\\MyServer\path\icon.png"              "icon.png"
"my app files\readme.txt"               "my app files\readme.txt"
"CustomManifest.xml"                    "AppxManifest.xml"
``` 

<span data-ttu-id="541e6-310">マッピング ファイルを使用する場合は、/m オプションを使用するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="541e6-310">When using a mapping file, you can choose whether you would like to use the /m option.</span></span> <span data-ttu-id="541e6-311">/m オプションを使うと、マッピング ファイル内のリソースのメタデータを生成されたマニフェストに含めるように指定できます。</span><span class="sxs-lookup"><span data-stu-id="541e6-311">The /m option allows the user to specify the resource metadata in the mapping file to be included in the generated manifest.</span></span> <span data-ttu-id="541e6-312">/m オプションを使う場合、マッピング ファイル内にそれに対応するセクションを設ける必要があります。このセクションは 1 行目に "[ResourceMetadata]" と指定し、それに続く行で "ResourceDimensions" と "ResourceId" を指定します。</span><span class="sxs-lookup"><span data-stu-id="541e6-312">If you use the /m option, the mapping file must contain a section that begins with the line "[ResourceMetadata]", followed by lines that specify "ResourceDimensions" and "ResourceId."</span></span> <span data-ttu-id="541e6-313">アプリ パッケージには複数の "ResourceDimensions" を含めることができますが、"ResourceId" は 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="541e6-313">It is possible for an app package to contain multiple "ResourceDimensions", but there can only ever be one "ResourceId."</span></span>

<span data-ttu-id="541e6-314">マッピング ファイルの例 (/m オプションを使用する場合)</span><span class="sxs-lookup"><span data-stu-id="541e6-314">Example of a mapping file (with the /m option):</span></span>

``` Example
[ResourceMetadata]
"ResourceDimensions"                    "language-en-us"
"ResourceId"                            "English"

[Files]
"images\en-us\logo.png"                 "en-us\logo.png"
"en-us.pri"                             "resources.pri"
```

## <a name="semantic-validation-performed-by-makeappxexe"></a><span data-ttu-id="541e6-315">MakeAppx.exe が実行するセマンティックの検証</span><span class="sxs-lookup"><span data-stu-id="541e6-315">Semantic validation performed by MakeAppx.exe</span></span>

<span data-ttu-id="541e6-316">**MakeAppx.exe** では、限定的なセマンティックの検証機能により、一般的な展開エラーを検出し、アプリ パッケージの有効性を確認します。</span><span class="sxs-lookup"><span data-stu-id="541e6-316">**MakeAppx.exe** performs limited sematic validation that is designed to catch the most common deployment errors and help ensure that the app package is valid.</span></span> <span data-ttu-id="541e6-317">**MakeAppx.exe** を使うときに検証をスキップする場合は、/nv オプションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="541e6-317">See the /nv option if you want to skip validation while using **MakeAppx.exe**.</span></span> 

<span data-ttu-id="541e6-318">この検証では、次の点を確認します。</span><span class="sxs-lookup"><span data-stu-id="541e6-318">This validation ensures that:</span></span>
- <span data-ttu-id="541e6-319">パッケージ マニフェストで参照されているすべてのファイルがアプリ パッケージに含まれていること。</span><span class="sxs-lookup"><span data-stu-id="541e6-319">All files referenced in the package manifest are included in the app package.</span></span>
- <span data-ttu-id="541e6-320">アプリケーションに、同一の 2 つのキーが存在しないこと。</span><span class="sxs-lookup"><span data-stu-id="541e6-320">An application does not have two identical keys.</span></span>
- <span data-ttu-id="541e6-321">アプリケーションが、SMB、FILE、MS-WWA-WEB、MS-WWA のリストに記載された禁止プロトコルを登録していないこと。</span><span class="sxs-lookup"><span data-stu-id="541e6-321">An application does not register for a forbidden protocol from this list: SMB, FILE, MS-WWA-WEB, MS-WWA.</span></span> 

<span data-ttu-id="541e6-322">これは一般的なエラーのみをチェックするように設計された機能であり、完全なセマンティックの検証ではありません。</span><span class="sxs-lookup"><span data-stu-id="541e6-322">This is not a complete semantic validation as it is only designed to catch common errors.</span></span> <span data-ttu-id="541e6-323">**MakeAppx.exe** によって作成されたパッケージのインストール可能性については保証されていません。</span><span class="sxs-lookup"><span data-stu-id="541e6-323">Packages built by **MakeAppx.exe** are not guaranteed to be installable.</span></span>