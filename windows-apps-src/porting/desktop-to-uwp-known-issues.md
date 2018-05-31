---
author: normesta
Description: This article contains known issues with the Desktop Bridge.
Search.Product: eADQiWindows 10XVcnh
title: 既知の問題 (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 07/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 71f8ffcb-8a99-4214-ae83-2d4b718a750e
ms.localizationpriority: medium
ms.openlocfilehash: 78e5ffddfa1c5005bb640baeafed7023ebdd74a3
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662852"
---
# <a name="known-issues-desktop-bridge"></a><span data-ttu-id="7c2a5-103">既知の問題 (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="7c2a5-103">Known Issues (Desktop Bridge)</span></span>

<span data-ttu-id="7c2a5-104">この記事では、デスクトップ ブリッジに関する既知の問題について説明します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-104">This article contains known issues with the Desktop Bridge.</span></span>

<a id="app-converter" />

## <a name="known-issues-with-the-desktop-app-converter"></a><span data-ttu-id="7c2a5-105">Desktop App Converter の既知の問題</span><span class="sxs-lookup"><span data-stu-id="7c2a5-105">Known Issues with the Desktop App Converter</span></span>

### <a name="ecreatingisolatedenvfailed-an-estartingisolatedenvfailed-errors"></a><span data-ttu-id="7c2a5-106">E_CREATING_ISOLATED_ENV_FAILED エラーと E_STARTING_ISOLATED_ENV_FAILED エラー</span><span class="sxs-lookup"><span data-stu-id="7c2a5-106">E_CREATING_ISOLATED_ENV_FAILED an E_STARTING_ISOLATED_ENV_FAILED errors</span></span>    

<span data-ttu-id="7c2a5-107">これらのエラーのうちいずれかが発生した場合は、[ダウンロード センター](https://aka.ms/converterimages)から取得した有効な基本イメージを使用しているか確認してください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-107">If you receive either of these errors, make sure that you're using a valid base image from the [download center](https://aka.ms/converterimages).</span></span>
<span data-ttu-id="7c2a5-108">有効な基本イメージを使っている場合は、コマンドに ``-Cleanup All`` を含めてみてください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-108">If you’re using a valid base image, try using ``-Cleanup All`` in your command.</span></span>
<span data-ttu-id="7c2a5-109">それでも問題が解決しない場合は、調査用としてログを converter@microsoft.com にお送りください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-109">If that does not work, please send us your logs at converter@microsoft.com to help us investigate.</span></span>

### <a name="new-containernetwork-the-object-already-exists-error"></a><span data-ttu-id="7c2a5-110">"New-ContainerNetwork: オブジェクトは既に存在します" エラー</span><span class="sxs-lookup"><span data-stu-id="7c2a5-110">New-ContainerNetwork: The object already exists error</span></span>

<span data-ttu-id="7c2a5-111">新しい基本イメージをセットアップするときは、このエラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-111">You might receive this error when you setup a new base image.</span></span> <span data-ttu-id="7c2a5-112">Desktop App Converter が先にインストールされた開発用コンピューターに Windows Insider フライトがある場合に、このエラーが発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-112">This can happen if you have a Windows Insider flight on a developer machine that previously had the Desktop App Converter installed.</span></span>

<span data-ttu-id="7c2a5-113">この問題を解決するには、管理者特権で開いたコマンド プロンプトで `Netsh int ipv4 reset` コマンドを実行して、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-113">To resolve this issue, try running the command `Netsh int ipv4 reset` from an elevated command prompt, and then reboot your machine.</span></span>

### <a name="your-net-app-is-compiled-with-the-anycpu-build-option-and-fails-to-install"></a><span data-ttu-id="7c2a5-114">.NET アプリが "AnyCPU" ビルド オプションでコンパイルされ、インストールに失敗する</span><span class="sxs-lookup"><span data-stu-id="7c2a5-114">Your .NET app is compiled with the "AnyCPU" build option and fails to install</span></span>

<span data-ttu-id="7c2a5-115">この問題は、メインの実行可能ファイルまたは何らかの依存ファイルが、**Program Files** または **Windows\System32** のフォルダー階層に配置された場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-115">This can happen if the main executable or any of the dependencies were placed anywhere in the **Program Files** or **Windows\System32** folder hierarchy.</span></span>

<span data-ttu-id="7c2a5-116">この問題を解決するには、アーキテクチャ固有のデスクトップ インストーラー (32 ビットまたは 64 ビット) を使って Windowsアプリ パッケージを生成してみてください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-116">To resolve this issue, try using your architecture-specific desktop installer (32 bit or 64 bit) to generate a Windows app package.</span></span>

### <a name="publishing-public-side-by-side-fusion-assemblies-wont-work"></a><span data-ttu-id="7c2a5-117">パブリック side-by-side Fusion アセンブリの公開が機能しない</span><span class="sxs-lookup"><span data-stu-id="7c2a5-117">Publishing public side-by-side Fusion assemblies won't work</span></span>

 <span data-ttu-id="7c2a5-118">アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-118">During install, an application can publish public side-by-side Fusion assemblies, accessible to any other process.</span></span> <span data-ttu-id="7c2a5-119">これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-119">During process activation context creation, these assemblies are retrieved by a system process named CSRSS.exe.</span></span> <span data-ttu-id="7c2a5-120">変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-120">When this is done for a converted process, activation context creation and module loading of these assemblies will fail.</span></span> <span data-ttu-id="7c2a5-121">side-by-side Fusion アセンブリは、次の場所に登録されています。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-121">The side-by-side Fusion assemblies are registered in the following locations:</span></span>
  + <span data-ttu-id="7c2a5-122">レジストリ:</span><span class="sxs-lookup"><span data-stu-id="7c2a5-122">Registry:</span></span> `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`
  + <span data-ttu-id="7c2a5-123">ファイル システム: %windir%\\SideBySide</span><span class="sxs-lookup"><span data-stu-id="7c2a5-123">File System: %windir%\\SideBySide</span></span>

<span data-ttu-id="7c2a5-124">これは、既知の制限であり、今のところ回避策はありません。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-124">This is a known limitation and no workaround currently exists.</span></span> <span data-ttu-id="7c2a5-125">ただし、ComCtl などの受信トレイ アセンブリは OS に同梱されているため、これらのアセンブリに依存していても安全です。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-125">That said, Inbox assemblies, like ComCtl, are shipped with the OS, so taking a dependency on them is safe.</span></span>

### <a name="error-found-in-xml-the-executable-attribute-is-invalid---the-value-myappexe-is-invalid-according-to-its-datatype"></a><span data-ttu-id="7c2a5-126">XML にエラーが見つかり、</span><span class="sxs-lookup"><span data-stu-id="7c2a5-126">Error found in XML.</span></span> <span data-ttu-id="7c2a5-127">'Executable' 属性が無効 - 'MyApp.EXE' の値がデータ型に対して無効</span><span class="sxs-lookup"><span data-stu-id="7c2a5-127">The 'Executable' attribute is invalid - The value 'MyApp.EXE' is invalid according to its datatype</span></span>

<span data-ttu-id="7c2a5-128">この問題は、アプリケーションに含まれる実行可能ファイルの **.EXE** 拡張子が大文字になっている場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-128">This can happen if the executables in your application have a capitalized **.EXE** extension.</span></span> <span data-ttu-id="7c2a5-129">この拡張子が大文字であってもアプリの実行には影響しませんが、DAC ではこのエラーが発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-129">Although, the casing of this extension shouldn't affect whether your app runs, this can cause the DAC to generate this error.</span></span>

<span data-ttu-id="7c2a5-130">この問題を解決するには、パッケージ化を行うときに **-AppExecutable** フラグを指定し、メインの実行可能ファイルの拡張子として小文字の ".exe" を使用してみてください (例: MYAPP.exe)。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-130">To resolve this issue, try specifying the **-AppExecutable** flag when you package, and use the lower case ".exe" as the extension of your main executable (For example: MYAPP.exe).</span></span>    <span data-ttu-id="7c2a5-131">または、アプリに含まれるすべての実行可能ファイルについて、小文字を大文字に変更することもできます (例: .EXE を .exe に変更する)。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-131">Alternately you can change the casing for all executables in your app from lowercase to uppercase (For example: from .EXE to .exe).</span></span>

### <a name="corrupted-or-malformed-authenticode-signatures"></a><span data-ttu-id="7c2a5-132">Authenticode 署名が破損しているか、形式が正しくない</span><span class="sxs-lookup"><span data-stu-id="7c2a5-132">Corrupted or malformed Authenticode signatures</span></span>

<span data-ttu-id="7c2a5-133">このセクションでは、Windows アプリ パッケージ内の移植可能な実行可能ファイル (PE) で、Authenticode 署名が破損しているかまたは形式が正しくない問題を特定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-133">This section contains details on how to identify issues with Portable Executable (PE) files in your Windows app package that may contain corrupted or malformed Authenticode signatures.</span></span> <span data-ttu-id="7c2a5-134">任意のバイナリ形式 (.exe、.dll、.chm など) の PE ファイルに対する無効な Authenticode 署名によって、パッケージが正しく署名されない場合や、Windows アプリ パッケージから展開できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-134">Invalid Authenticode signatures on your PE files, which may be in any binary format (e.g. .exe, .dll, .chm, etc.), will prevent your package from being signed properly, and thus prevent it from being deployable from an Windows app package.</span></span>

<span data-ttu-id="7c2a5-135">PE ファイルの Authenticode 署名の場所は、Optional Header Data Directories の Certificate Table エントリおよび関連付けられている Attribute Certificate Table で指定されます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-135">The location of the Authenticode signature of a PE file is specified by the Certificate Table entry in the Optional Header Data Directories and the associated Attribute Certificate Table.</span></span> <span data-ttu-id="7c2a5-136">署名を検証する場合、これらの構造体で指定されている情報を使用して、PE ファイルの署名を検出します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-136">During signature verification, the information specified in these structures is used to locate the signature on a PE file.</span></span> <span data-ttu-id="7c2a5-137">これらの値が壊れている場合、ファイルの署名が無効であるように見える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-137">If these values get corrupted then it is possible for a file to appear to be invalidly signed.</span></span>

<span data-ttu-id="7c2a5-138">Authenticode 署名が正しいと見なされるには、Authenticode 署名が次の条件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-138">For the Authenticode signature to be correct, the following must be true of the Authenticode signature:</span></span>

- <span data-ttu-id="7c2a5-139">PE ファイル内の **WIN_CERTIFICATE** エントリの先頭は、実行可能ファイルの終わりを超えて拡張できない</span><span class="sxs-lookup"><span data-stu-id="7c2a5-139">The start of the **WIN_CERTIFICATE** entry in the PE file cannot extend past the end of the executable</span></span>
- <span data-ttu-id="7c2a5-140">**WIN_CERTIFCATE** エントリは、イメージの最後に置かれている必要がある</span><span class="sxs-lookup"><span data-stu-id="7c2a5-140">The **WIN_CERTIFCATE** entry should be located at the end of the image</span></span>
- <span data-ttu-id="7c2a5-141">**WIN_CERTIFICATE** エントリのサイズは正の値である必要がある</span><span class="sxs-lookup"><span data-stu-id="7c2a5-141">The size of the **WIN_CERTIFICATE** entry must be positive</span></span>
- <span data-ttu-id="7c2a5-142">**WIN_CERTIFICATE** エントリは、32 ビット実行可能ファイルの場合は **IMAGE_NT_HEADERS32** 構造体より後、64 ビット実行可能ファイルの場合は IMAGE_NT_HEADERS64 構造体より後に開始する必要がある</span><span class="sxs-lookup"><span data-stu-id="7c2a5-142">The **WIN_CERTIFICATE**entry must start after the **IMAGE_NT_HEADERS32** structure for 32-bit executables and IMAGE_NT_HEADERS64 structure for 64-bit executables</span></span>

<span data-ttu-id="7c2a5-143">詳しくは、[移植可能な実行可能ファイルの Authenticode 署名の仕様に関するドキュメント](http://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx)と [PE ファイル形式の仕様に関するページ](https://msdn.microsoft.com/windows/hardware/gg463119.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-143">For more details, please refer to the [Authenticode Portal Executable specification](http://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx) and the [PE file format specification](https://msdn.microsoft.com/windows/hardware/gg463119.aspx).</span></span>

<span data-ttu-id="7c2a5-144">Windows アプリ パッケージに署名するときに、SignTool.exe で、壊れているバイナリや形式が正しくないバイナリの一覧を出力できます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-144">Note that SignTool.exe can output a list of the corrupted or malformed binaries when attempting to sign an Windows app package.</span></span> <span data-ttu-id="7c2a5-145">これを行うには、環境変数 APPXSIP_LOG を 1 に設定して (例: ```set APPXSIP_LOG=1```) 詳細なログを有効にし、SignTool.exe を再度実行します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-145">To do this, enable verbose logging by setting the environment variable APPXSIP_LOG to 1 (e.g., ```set APPXSIP_LOG=1``` ) and re-run SignTool.exe.</span></span>

<span data-ttu-id="7c2a5-146">これらの形式が正しくないバイナリを修正するには、上記の要件に準拠していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-146">To fix these malformed binaries, ensure they conform to the requirements above.</span></span>

## <a name="you-receive-the-error----msb4018-the-generateresource-task-failed-unexpectedly"></a><span data-ttu-id="7c2a5-147">次のエラーが表示されます。MSB4018: "GenerateResource" タスクが予期せずに失敗しました</span><span class="sxs-lookup"><span data-stu-id="7c2a5-147">You receive the error    MSB4018 The "GenerateResource" task failed unexpectedly</span></span>

<span data-ttu-id="7c2a5-148">これは、サテライト アセンブリをパッケージ リソース インデックス (PRI) ファイルに変換しようとすると発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-148">This can happen when trying to convert satellite assemblies to Package Resource Index (PRI) files.</span></span>

<span data-ttu-id="7c2a5-149">Microsoft ではこの問題を把握しており、より長期的な解決策に取り組んでいるところです。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-149">We are aware of this issue and are working on a more long term solution.</span></span> <span data-ttu-id="7c2a5-150">一時的な回避策として、次の XML 行をホスティング プロジェクト ファイルの最初の PropertyGroup 要素に追加することで、リソース ジェネレータを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-150">As a temporary workaround, you can disable the resource generator by adding this line of XML to the first PropertyGroup element in hosting project file:</span></span>

``<AppxGeneratePrisForPortableLibrariesEnabled>false</AppxGeneratePrisForPortableLibrariesEnabled>``

## <a name="blue-screen-with-error-code-0x139-kernelsecuritycheckfailure"></a><span data-ttu-id="7c2a5-151">エラー コード 0x139 のブルー スクリーン (KERNEL_SECURITY_CHECK_FAILURE)</span><span class="sxs-lookup"><span data-stu-id="7c2a5-151">Blue screen with error code 0x139 (KERNEL_SECURITY_CHECK_FAILURE)</span></span>

<span data-ttu-id="7c2a5-152">Microsoft Store のアプリをインストールまたは起動した後、予期せず **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)** というエラーでコンピューターの再起動が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-152">After installing or launching certain apps from the Microsoft Store, your machine may unexpectedly reboot with the error: **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)**.</span></span>

<span data-ttu-id="7c2a5-153">影響を受けることがわかっているアプリには、Kodi、JT2Go、Ear Trumpet、Teslagrad などがあります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-153">Known affected apps include Kodi, JT2Go, Ear Trumpet, Teslagrad, and others.</span></span>

<span data-ttu-id="7c2a5-154">この問題に対処するための重要な修正プログラムが含まれた [Windows 更新プログラム (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) が 2016 年 10 月 27 日にリリースされました。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-154">A [Windows update (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) was released on 10/27/16 that includes important fixes that address this issue.</span></span> <span data-ttu-id="7c2a5-155">この問題が発生した場合は、コンピューターを更新してください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-155">If you encounter this problem, update your machine.</span></span> <span data-ttu-id="7c2a5-156">ログインする前にコンピューターが再起動されるため PC を更新できない場合は、システムの復元を使用して、影響を受けたアプリをインストールする前の状態にシステムを回復する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-156">If you are not able to update your PC because your machine restarts before you can log in, you should use system restore to recover your system to a point earlier than when you installed one of the affected apps.</span></span> <span data-ttu-id="7c2a5-157">システムを復元する方法について詳しくは、「[Windows 10 の回復オプション](https://support.microsoft.com/help/12415/windows-10-recovery-options)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-157">For information on how to use system restore, see [Recovery options in Windows 10](https://support.microsoft.com/help/12415/windows-10-recovery-options).</span></span>

<span data-ttu-id="7c2a5-158">更新しても問題が解決しない場合や、PC を回復する方法がわからない場合は、[Microsoft サポート](https://support.microsoft.com/contactus/)にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-158">If updating does not fix the problem or you aren't sure how to recover your PC, please contact [Microsoft Support](https://support.microsoft.com/contactus/).</span></span>

<span data-ttu-id="7c2a5-159">開発者様には、この更新プログラムが含まれていないバージョンの Windows に Desktop Bridge アプリをインストールしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-159">If you are a developer, you may want to prevent the installation of your Desktop Bridge apps on versions of Windows that do not include this update.</span></span> <span data-ttu-id="7c2a5-160">その場合、更新プログラムをインストールしていないユーザーはアプリを利用できません。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-160">Note that by doing this your app will not be available to users that have not yet installed the update.</span></span> <span data-ttu-id="7c2a5-161">この更新プログラムをインストールしたユーザーだけがアプリを使用できるようにするには、AppxManifest.xml ファイルを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-161">To limit the availability of your app to users that have installed this update, modify your AppxManifest.xml file as follows:</span></span>

```<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.351" MaxVersionTested="10.0.14393.351"/>```

<span data-ttu-id="7c2a5-162">Windows Update について詳しくは、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-162">Details regarding the Windows Update can be found at:</span></span>
* https://support.microsoft.com/kb/3197954
* https://support.microsoft.com/help/12387/windows-10-update-history

## <a name="common-errors-that-can-appear-when-you-sign-your-app"></a><span data-ttu-id="7c2a5-163">アプリへのサインインの際に表示される可能性のある一般的なエラー</span><span class="sxs-lookup"><span data-stu-id="7c2a5-163">Common errors that can appear when you sign your app</span></span>

### <a name="publisher-and-cert-mismatch-causes-signtool-error-error-signersign-failed--21470248850x8007000b"></a><span data-ttu-id="7c2a5-164">発行元と証明書の不一致により、Signtool で「エラー: SignerSign() が失敗しました」(-2147024885/0x8007000b) というエラーが発生する</span><span class="sxs-lookup"><span data-stu-id="7c2a5-164">Publisher and cert mismatch causes Signtool error "Error: SignerSign() Failed" (-2147024885/0x8007000b)</span></span>

<span data-ttu-id="7c2a5-165">Windows アプリ パッケージ マニフェストの発行元エントリは、署名に使用する証明書のサブジェクトと一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-165">The Publisher entry in the Windows app package manifest must match the Subject of the certificate you are signing with.</span></span>  <span data-ttu-id="7c2a5-166">次の方法のいずれかを使用して、証明書のサブジェクトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-166">You can use any of the following methods to view the subject of the cert.</span></span>

**<span data-ttu-id="7c2a5-167">オプション1: Powershell</span><span class="sxs-lookup"><span data-stu-id="7c2a5-167">Option 1: Powershell</span></span>**

<span data-ttu-id="7c2a5-168">次の PowerShell コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-168">Run the following PowerShell command.</span></span> <span data-ttu-id="7c2a5-169">同じ発行元情報を持つ .cer または .pfx のいずれかを証明書ファイルとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-169">Either .cer or .pfx can be used as the certificate file, as they have the same publisher information.</span></span>

```ps
(Get-PfxCertificate <cert_file>).Subject
```

**<span data-ttu-id="7c2a5-170">オプション2: エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="7c2a5-170">Option 2: File Explorer</span></span>**

<span data-ttu-id="7c2a5-171">エクスプローラーで証明書をダブルクリックし、*[詳細]* タブを選び、一覧の *[サブジェクト]* フィールドを選びます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-171">Double-click the certificate in File Explorer, select the *Details* tab, and then the *Subject* field in the list.</span></span> <span data-ttu-id="7c2a5-172">内容をコピーすることができます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-172">You can then copy the contents.</span></span>

**<span data-ttu-id="7c2a5-173">オプション3: CertUtil</span><span class="sxs-lookup"><span data-stu-id="7c2a5-173">Option 3: CertUtil</span></span>**

<span data-ttu-id="7c2a5-174">コマンドラインから PFX ファイルに **certutil** を実行し、出力から *[サブジェクト]* フィールドをコピーします。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-174">Run **certutil** from the the command line on the PFX file and copy the *Subject* field from the output.</span></span>

```cmd
certutil -dump <cert_file.pfx>
```

## <a name="next-steps"></a><span data-ttu-id="7c2a5-175">次のステップ</span><span class="sxs-lookup"><span data-stu-id="7c2a5-175">Next Steps</span></span>

**<span data-ttu-id="7c2a5-176">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="7c2a5-176">Find answers to your questions</span></span>**

<span data-ttu-id="7c2a5-177">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="7c2a5-177">Have questions?</span></span> <span data-ttu-id="7c2a5-178">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-178">Ask us on Stack Overflow.</span></span> <span data-ttu-id="7c2a5-179">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-179">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="7c2a5-180">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-180">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="7c2a5-181">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="7c2a5-181">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="7c2a5-182">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c2a5-182">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
