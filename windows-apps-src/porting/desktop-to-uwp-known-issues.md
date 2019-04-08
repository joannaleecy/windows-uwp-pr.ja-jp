---
Description: この記事では、デスクトップ ブリッジに関する既知の問題について説明します。
Search.Product: eADQiWindows 10XVcnh
title: 既知の問題 (デスクトップ ブリッジ)
ms.date: 06/20/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 71f8ffcb-8a99-4214-ae83-2d4b718a750e
ms.localizationpriority: medium
ms.openlocfilehash: 9c437e30db7007a6889a822d7d2219f1647bb3d8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637097"
---
# <a name="known-issues-with-packaged-desktop-applications"></a><span data-ttu-id="28d56-104">パッケージのデスクトップ アプリケーションに関する既知の問題</span><span class="sxs-lookup"><span data-stu-id="28d56-104">Known Issues with packaged desktop applications</span></span>

<span data-ttu-id="28d56-105">この記事には、お客様のデスクトップ アプリケーションの Windows アプリ パッケージを作成するときに発生する可能性がある既知の問題が含まれています。</span><span class="sxs-lookup"><span data-stu-id="28d56-105">This article contains known issues that can occur when you create a Windows app package for your desktop application.</span></span>

<a id="app-converter" />

## <a name="known-issues-with-the-desktop-app-converter"></a><span data-ttu-id="28d56-106">Desktop App Converter の既知の問題</span><span class="sxs-lookup"><span data-stu-id="28d56-106">Known Issues with the Desktop App Converter</span></span>

### <a name="ecreatingisolatedenvfailed-an-estartingisolatedenvfailed-errors"></a><span data-ttu-id="28d56-107">E_CREATING_ISOLATED_ENV_FAILED エラーと E_STARTING_ISOLATED_ENV_FAILED エラー</span><span class="sxs-lookup"><span data-stu-id="28d56-107">E_CREATING_ISOLATED_ENV_FAILED an E_STARTING_ISOLATED_ENV_FAILED errors</span></span>    

<span data-ttu-id="28d56-108">これらのエラーのうちいずれかが発生した場合は、[ダウンロード センター](https://aka.ms/converterimages)から取得した有効な基本イメージを使用しているか確認してください。</span><span class="sxs-lookup"><span data-stu-id="28d56-108">If you receive either of these errors, make sure that you're using a valid base image from the [download center](https://aka.ms/converterimages).</span></span>
<span data-ttu-id="28d56-109">有効な基本イメージを使っている場合は、コマンドに ``-Cleanup All`` を含めてみてください。</span><span class="sxs-lookup"><span data-stu-id="28d56-109">If you’re using a valid base image, try using ``-Cleanup All`` in your command.</span></span>
<span data-ttu-id="28d56-110">それでも問題が解決しない場合は、調査用としてログを converter@microsoft.com にお送りください。</span><span class="sxs-lookup"><span data-stu-id="28d56-110">If that does not work, please send us your logs at converter@microsoft.com to help us investigate.</span></span>

### <a name="new-containernetwork-the-object-already-exists-error"></a><span data-ttu-id="28d56-111">New-containernetwork:オブジェクトは既にエラー</span><span class="sxs-lookup"><span data-stu-id="28d56-111">New-ContainerNetwork: The object already exists error</span></span>

<span data-ttu-id="28d56-112">新しい基本イメージをセットアップするときは、このエラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="28d56-112">You might receive this error when you setup a new base image.</span></span> <span data-ttu-id="28d56-113">Desktop App Converter が先にインストールされた開発用コンピューターに Windows Insider フライトがある場合に、このエラーが発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="28d56-113">This can happen if you have a Windows Insider flight on a developer machine that previously had the Desktop App Converter installed.</span></span>

<span data-ttu-id="28d56-114">この問題を解決するには、管理者特権で開いたコマンド プロンプトで `Netsh int ipv4 reset` コマンドを実行して、コンピューターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="28d56-114">To resolve this issue, try running the command `Netsh int ipv4 reset` from an elevated command prompt, and then reboot your machine.</span></span>

### <a name="your-net-application-is-compiled-with-the-anycpu-build-option-and-fails-to-install"></a><span data-ttu-id="28d56-115">.NET アプリケーションは、"AnyCPU"ビルド オプションを使用してコンパイルされ、インストールに失敗します。</span><span class="sxs-lookup"><span data-stu-id="28d56-115">Your .NET application is compiled with the "AnyCPU" build option and fails to install</span></span>

<span data-ttu-id="28d56-116">この問題は、メインの実行可能ファイルまたは何らかの依存ファイルが、**Program Files** または **Windows\System32** のフォルダー階層に配置された場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="28d56-116">This can happen if the main executable or any of the dependencies were placed anywhere in the **Program Files** or **Windows\System32** folder hierarchy.</span></span>

<span data-ttu-id="28d56-117">この問題を解決するには、アーキテクチャ固有のデスクトップ インストーラー (32 ビットまたは 64 ビット) を使って Windowsアプリ パッケージを生成してみてください。</span><span class="sxs-lookup"><span data-stu-id="28d56-117">To resolve this issue, try using your architecture-specific desktop installer (32 bit or 64 bit) to generate a Windows app package.</span></span>

### <a name="publishing-public-side-by-side-fusion-assemblies-wont-work"></a><span data-ttu-id="28d56-118">パブリック side-by-side Fusion アセンブリの公開が機能しない</span><span class="sxs-lookup"><span data-stu-id="28d56-118">Publishing public side-by-side Fusion assemblies won't work</span></span>

 <span data-ttu-id="28d56-119">アプリケーションは、インストール中にパブリック side-by-side Fusion アセンブリを公開して、他のプロセスからアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="28d56-119">During install, an application can publish public side-by-side Fusion assemblies, accessible to any other process.</span></span> <span data-ttu-id="28d56-120">これらのアセンブリは、プロセスのアクティブ化コンテキストの作成中に、CSRSS.exe という名前のシステム プロセスによって取得されます。</span><span class="sxs-lookup"><span data-stu-id="28d56-120">During process activation context creation, these assemblies are retrieved by a system process named CSRSS.exe.</span></span> <span data-ttu-id="28d56-121">変換プロセスでこれが行われると、アクティブ化コンテキスト作成とこれらのアセンブリのモジュール読み込みは失敗します。</span><span class="sxs-lookup"><span data-stu-id="28d56-121">When this is done for a converted process, activation context creation and module loading of these assemblies will fail.</span></span> <span data-ttu-id="28d56-122">side-by-side Fusion アセンブリは、次の場所に登録されています。</span><span class="sxs-lookup"><span data-stu-id="28d56-122">The side-by-side Fusion assemblies are registered in the following locations:</span></span>
  + <span data-ttu-id="28d56-123">レジストリ: `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`</span><span class="sxs-lookup"><span data-stu-id="28d56-123">Registry: `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SideBySide\Winners`</span></span>
  + <span data-ttu-id="28d56-124">ファイル システム: %windir%\\SideBySide</span><span class="sxs-lookup"><span data-stu-id="28d56-124">File System: %windir%\\SideBySide</span></span>

<span data-ttu-id="28d56-125">これは、既知の制限であり、今のところ回避策はありません。</span><span class="sxs-lookup"><span data-stu-id="28d56-125">This is a known limitation and no workaround currently exists.</span></span> <span data-ttu-id="28d56-126">ただし、ComCtl などの受信トレイ アセンブリは OS に同梱されているため、これらのアセンブリに依存していても安全です。</span><span class="sxs-lookup"><span data-stu-id="28d56-126">That said, Inbox assemblies, like ComCtl, are shipped with the OS, so taking a dependency on them is safe.</span></span>

### <a name="error-found-in-xml-the-executable-attribute-is-invalid---the-value-myappexe-is-invalid-according-to-its-datatype"></a><span data-ttu-id="28d56-127">XML にエラーが見つかり、</span><span class="sxs-lookup"><span data-stu-id="28d56-127">Error found in XML.</span></span> <span data-ttu-id="28d56-128">'Executable' 属性が無効 - 'MyApp.EXE' の値がデータ型に対して無効</span><span class="sxs-lookup"><span data-stu-id="28d56-128">The 'Executable' attribute is invalid - The value 'MyApp.EXE' is invalid according to its datatype</span></span>

<span data-ttu-id="28d56-129">この問題は、アプリケーションに含まれる実行可能ファイルの **.EXE** 拡張子が大文字になっている場合に発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="28d56-129">This can happen if the executables in your application have a capitalized **.EXE** extension.</span></span> <span data-ttu-id="28d56-130">ただし、この拡張機能の大文字小文字の区別は、アプリケーションを実行しているかどうかに影響しません、このエラーを生成する DAC ができます。</span><span class="sxs-lookup"><span data-stu-id="28d56-130">Although, the casing of this extension shouldn't affect whether your application runs, this can cause the DAC to generate this error.</span></span>

<span data-ttu-id="28d56-131">この問題を解決するを指定してください、 **- AppExecutable**フラグをパッケージ化、小文字、メインの実行可能ファイルの拡張子として".exe"を使用すると (例。MYAPP.exe)。</span><span class="sxs-lookup"><span data-stu-id="28d56-131">To resolve this issue, try specifying the **-AppExecutable** flag when you package, and use the lower case ".exe" as the extension of your main executable (For example: MYAPP.exe).</span></span>    <span data-ttu-id="28d56-132">大文字を小文字から、アプリケーションで実行可能ファイルのすべての大文字と小文字を変更する代わりに (例: から。Exe を使用して .exe)。</span><span class="sxs-lookup"><span data-stu-id="28d56-132">Alternately you can change the casing for all executables in your application from lowercase to uppercase (For example: from .EXE to .exe).</span></span>

### <a name="corrupted-or-malformed-authenticode-signatures"></a><span data-ttu-id="28d56-133">Authenticode 署名が破損しているか、形式が正しくない</span><span class="sxs-lookup"><span data-stu-id="28d56-133">Corrupted or malformed Authenticode signatures</span></span>

<span data-ttu-id="28d56-134">このセクションでは、Windows アプリ パッケージ内の移植可能な実行可能ファイル (PE) で、Authenticode 署名が破損しているかまたは形式が正しくない問題を特定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="28d56-134">This section contains details on how to identify issues with Portable Executable (PE) files in your Windows app package that may contain corrupted or malformed Authenticode signatures.</span></span> <span data-ttu-id="28d56-135">任意のバイナリ形式 (.exe、.dll、.chm など) の PE ファイルに対する無効な Authenticode 署名によって、パッケージが正しく署名されない場合や、Windows アプリ パッケージから展開できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="28d56-135">Invalid Authenticode signatures on your PE files, which may be in any binary format (e.g. .exe, .dll, .chm, etc.), will prevent your package from being signed properly, and thus prevent it from being deployable from an Windows app package.</span></span>

<span data-ttu-id="28d56-136">PE ファイルの Authenticode 署名の場所は、Optional Header Data Directories の Certificate Table エントリおよび関連付けられている Attribute Certificate Table で指定されます。</span><span class="sxs-lookup"><span data-stu-id="28d56-136">The location of the Authenticode signature of a PE file is specified by the Certificate Table entry in the Optional Header Data Directories and the associated Attribute Certificate Table.</span></span> <span data-ttu-id="28d56-137">署名を検証する場合、これらの構造体で指定されている情報を使用して、PE ファイルの署名を検出します。</span><span class="sxs-lookup"><span data-stu-id="28d56-137">During signature verification, the information specified in these structures is used to locate the signature on a PE file.</span></span> <span data-ttu-id="28d56-138">これらの値が壊れている場合、ファイルの署名が無効であるように見える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="28d56-138">If these values get corrupted then it is possible for a file to appear to be invalidly signed.</span></span>

<span data-ttu-id="28d56-139">Authenticode 署名が正しいと見なされるには、Authenticode 署名が次の条件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="28d56-139">For the Authenticode signature to be correct, the following must be true of the Authenticode signature:</span></span>

- <span data-ttu-id="28d56-140">PE ファイル内の **WIN_CERTIFICATE** エントリの先頭は、実行可能ファイルの終わりを超えて拡張できない</span><span class="sxs-lookup"><span data-stu-id="28d56-140">The start of the **WIN_CERTIFICATE** entry in the PE file cannot extend past the end of the executable</span></span>
- <span data-ttu-id="28d56-141">**WIN_CERTIFCATE** エントリは、イメージの最後に置かれている必要がある</span><span class="sxs-lookup"><span data-stu-id="28d56-141">The **WIN_CERTIFCATE** entry should be located at the end of the image</span></span>
- <span data-ttu-id="28d56-142">**WIN_CERTIFICATE** エントリのサイズは正の値である必要がある</span><span class="sxs-lookup"><span data-stu-id="28d56-142">The size of the **WIN_CERTIFICATE** entry must be positive</span></span>
- <span data-ttu-id="28d56-143">**WIN_CERTIFICATE** エントリは、32 ビット実行可能ファイルの場合は **IMAGE_NT_HEADERS32** 構造体より後、64 ビット実行可能ファイルの場合は IMAGE_NT_HEADERS64 構造体より後に開始する必要がある</span><span class="sxs-lookup"><span data-stu-id="28d56-143">The **WIN_CERTIFICATE**entry must start after the **IMAGE_NT_HEADERS32** structure for 32-bit executables and IMAGE_NT_HEADERS64 structure for 64-bit executables</span></span>

<span data-ttu-id="28d56-144">詳しくは、[移植可能な実行可能ファイルの Authenticode 署名の仕様に関するドキュメント](https://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx)と [PE ファイル形式の仕様に関するページ](https://msdn.microsoft.com/windows/hardware/gg463119.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28d56-144">For more details, please refer to the [Authenticode Portal Executable specification](https://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx) and the [PE file format specification](https://msdn.microsoft.com/windows/hardware/gg463119.aspx).</span></span>

<span data-ttu-id="28d56-145">Windows アプリ パッケージに署名するときに、SignTool.exe で、壊れているバイナリや形式が正しくないバイナリの一覧を出力できます。</span><span class="sxs-lookup"><span data-stu-id="28d56-145">Note that SignTool.exe can output a list of the corrupted or malformed binaries when attempting to sign an Windows app package.</span></span> <span data-ttu-id="28d56-146">これを行うには、環境変数 APPXSIP_LOG を 1 に設定して (例: ```set APPXSIP_LOG=1```) 詳細なログを有効にし、SignTool.exe を再度実行します。</span><span class="sxs-lookup"><span data-stu-id="28d56-146">To do this, enable verbose logging by setting the environment variable APPXSIP_LOG to 1 (e.g., ```set APPXSIP_LOG=1``` ) and re-run SignTool.exe.</span></span>

<span data-ttu-id="28d56-147">これらの形式が正しくないバイナリを修正するには、上記の要件に準拠していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="28d56-147">To fix these malformed binaries, ensure they conform to the requirements above.</span></span>

## <a name="you-receive-the-error----msb4018-the-generateresource-task-failed-unexpectedly"></a><span data-ttu-id="28d56-148">次のエラーが表示されます。MSB4018: "GenerateResource" タスクが予期せずに失敗しました</span><span class="sxs-lookup"><span data-stu-id="28d56-148">You receive the error    MSB4018 The "GenerateResource" task failed unexpectedly</span></span>

<span data-ttu-id="28d56-149">これは、サテライト アセンブリをパッケージ リソース インデックス (PRI) ファイルに変換しようとすると発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="28d56-149">This can happen when trying to convert satellite assemblies to Package Resource Index (PRI) files.</span></span>

<span data-ttu-id="28d56-150">Microsoft ではこの問題を把握しており、より長期的な解決策に取り組んでいるところです。</span><span class="sxs-lookup"><span data-stu-id="28d56-150">We are aware of this issue and are working on a more long term solution.</span></span> <span data-ttu-id="28d56-151">一時的な回避策として、次の XML 行をホスティング プロジェクト ファイルの最初の PropertyGroup 要素に追加することで、リソース ジェネレータを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="28d56-151">As a temporary workaround, you can disable the resource generator by adding this line of XML to the first PropertyGroup element in hosting project file:</span></span>

``<AppxGeneratePrisForPortableLibrariesEnabled>false</AppxGeneratePrisForPortableLibrariesEnabled>``

## <a name="blue-screen-with-error-code-0x139-kernelsecuritycheckfailure"></a><span data-ttu-id="28d56-152">エラー コード 0x139 のブルー スクリーン (KERNEL_SECURITY_CHECK_FAILURE)</span><span class="sxs-lookup"><span data-stu-id="28d56-152">Blue screen with error code 0x139 (KERNEL_SECURITY_CHECK_FAILURE)</span></span>

<span data-ttu-id="28d56-153">インストールや、Microsoft Store からの特定のアプリの起動後、コンピューターは、エラーで突然再起動します。**0x139 (カーネル\_セキュリティ\_確認\_障害)** します。</span><span class="sxs-lookup"><span data-stu-id="28d56-153">After installing or launching certain apps from the Microsoft Store, your machine may unexpectedly reboot with the error: **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)**.</span></span>

<span data-ttu-id="28d56-154">影響を受けることがわかっているアプリには、Kodi、JT2Go、Ear Trumpet、Teslagrad などがあります。</span><span class="sxs-lookup"><span data-stu-id="28d56-154">Known affected apps include Kodi, JT2Go, Ear Trumpet, Teslagrad, and others.</span></span>

<span data-ttu-id="28d56-155">この問題に対処するための重要な修正プログラムが含まれた [Windows 更新プログラム (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) が 2016 年 10 月 27 日にリリースされました。</span><span class="sxs-lookup"><span data-stu-id="28d56-155">A [Windows update (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) was released on 10/27/16 that includes important fixes that address this issue.</span></span> <span data-ttu-id="28d56-156">この問題が発生した場合は、コンピューターを更新してください。</span><span class="sxs-lookup"><span data-stu-id="28d56-156">If you encounter this problem, update your machine.</span></span> <span data-ttu-id="28d56-157">ログインする前にコンピューターが再起動されるため PC を更新できない場合は、システムの復元を使用して、影響を受けたアプリをインストールする前の状態にシステムを回復する必要があります。</span><span class="sxs-lookup"><span data-stu-id="28d56-157">If you are not able to update your PC because your machine restarts before you can log in, you should use system restore to recover your system to a point earlier than when you installed one of the affected apps.</span></span> <span data-ttu-id="28d56-158">システムを復元する方法について詳しくは、「[Windows 10 の回復オプション](https://support.microsoft.com/help/12415/windows-10-recovery-options)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28d56-158">For information on how to use system restore, see [Recovery options in Windows 10](https://support.microsoft.com/help/12415/windows-10-recovery-options).</span></span>

<span data-ttu-id="28d56-159">更新しても問題が解決しない場合や、PC を回復する方法がわからない場合は、[Microsoft サポート](https://support.microsoft.com/contactus/)にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="28d56-159">If updating does not fix the problem or you aren't sure how to recover your PC, please contact [Microsoft Support](https://support.microsoft.com/contactus/).</span></span>

<span data-ttu-id="28d56-160">開発者様には、この更新プログラムが含まれていないバージョンの Windows にパッケージ化されたアプリケーションをインストールしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="28d56-160">If you are a developer, you may want to prevent the installation of your packaged application on versions of Windows that do not include this update.</span></span> <span data-ttu-id="28d56-161">これを行うと、アプリケーションでは、更新プログラムをインストールしていないユーザーには使用できませんに注意してください。</span><span class="sxs-lookup"><span data-stu-id="28d56-161">Note that by doing this your application will not be available to users that have not yet installed the update.</span></span> <span data-ttu-id="28d56-162">この更新プログラムがインストールされているユーザーにアプリケーションの可用性を制限するには、よう、AppxManifest.xml ファイルに変更します。</span><span class="sxs-lookup"><span data-stu-id="28d56-162">To limit the availability of your application to users that have installed this update, modify your AppxManifest.xml file as follows:</span></span>

```<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.351" MaxVersionTested="10.0.14393.351"/>```

<span data-ttu-id="28d56-163">Windows 更新プログラムについて詳しくは、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28d56-163">Details regarding the Windows Update can be found at:</span></span>
* https://support.microsoft.com/kb/3197954
* https://support.microsoft.com/help/12387/windows-10-update-history

## <a name="common-errors-that-can-appear-when-you-sign-your-app"></a><span data-ttu-id="28d56-164">アプリへのサインインの際に表示される可能性のある一般的なエラー</span><span class="sxs-lookup"><span data-stu-id="28d56-164">Common errors that can appear when you sign your app</span></span>

### <a name="publisher-and-cert-mismatch-causes-signtool-error-error-signersign-failed--21470248850x8007000b"></a><span data-ttu-id="28d56-165">発行者と証明書の不一致により Signtool エラー"エラー。SignerSign() に失敗しました"(-2147024885/0x8007000b)</span><span class="sxs-lookup"><span data-stu-id="28d56-165">Publisher and cert mismatch causes Signtool error "Error: SignerSign() Failed" (-2147024885/0x8007000b)</span></span>

<span data-ttu-id="28d56-166">Windows アプリ パッケージ マニフェストの発行元エントリは、署名に使用する証明書のサブジェクトと一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="28d56-166">The Publisher entry in the Windows app package manifest must match the Subject of the certificate you are signing with.</span></span>  <span data-ttu-id="28d56-167">次の方法のいずれかを使用して、証明書のサブジェクトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="28d56-167">You can use any of the following methods to view the subject of the cert.</span></span>

<span data-ttu-id="28d56-168">**オプション 1:Powershell**</span><span class="sxs-lookup"><span data-stu-id="28d56-168">**Option 1: Powershell**</span></span>

<span data-ttu-id="28d56-169">次の PowerShell コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="28d56-169">Run the following PowerShell command.</span></span> <span data-ttu-id="28d56-170">同じ発行元情報を持つ .cer または .pfx のいずれかを証明書ファイルとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="28d56-170">Either .cer or .pfx can be used as the certificate file, as they have the same publisher information.</span></span>

```ps
(Get-PfxCertificate <cert_file>).Subject
```

<span data-ttu-id="28d56-171">**オプション 2:ファイル エクスプ ローラー**</span><span class="sxs-lookup"><span data-stu-id="28d56-171">**Option 2: File Explorer**</span></span>

<span data-ttu-id="28d56-172">エクスプローラーで証明書をダブルクリックし、*[詳細]* タブを選び、一覧の *[サブジェクト]* フィールドを選びます。</span><span class="sxs-lookup"><span data-stu-id="28d56-172">Double-click the certificate in File Explorer, select the *Details* tab, and then the *Subject* field in the list.</span></span> <span data-ttu-id="28d56-173">内容をコピーすることができます。</span><span class="sxs-lookup"><span data-stu-id="28d56-173">You can then copy the contents.</span></span>

<span data-ttu-id="28d56-174">**オプション 3:CertUtil**</span><span class="sxs-lookup"><span data-stu-id="28d56-174">**Option 3: CertUtil**</span></span>

<span data-ttu-id="28d56-175">実行**certutil** PFX ファイルとコピーをコマンドラインから、*サブジェクト*フィールドを出力します。</span><span class="sxs-lookup"><span data-stu-id="28d56-175">Run **certutil** from the command line on the PFX file and copy the *Subject* field from the output.</span></span>

```cmd
certutil -dump <cert_file.pfx>
```

<a id="bad-pe-cert" />

### <a name="bad-pe-certificate-0x800700c1"></a><span data-ttu-id="28d56-176">無効な PE 証明書 (番号: 0x800700C1)</span><span class="sxs-lookup"><span data-stu-id="28d56-176">Bad PE certificate (0x800700C1)</span></span>

<span data-ttu-id="28d56-177">これは、パッケージには、破損した証明書を持つバイナリが含まれている場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="28d56-177">This can happen when your package contains a binary that has a corrupted certificate.</span></span> <span data-ttu-id="28d56-178">これがなぜ発生できる理由の一部を次に示します。</span><span class="sxs-lookup"><span data-stu-id="28d56-178">Here's some of the reasons why this can happen:</span></span>

* <span data-ttu-id="28d56-179">証明書の開始は、イメージの末尾ではありません。</span><span class="sxs-lookup"><span data-stu-id="28d56-179">The start of the certificate is not at the end of an image.</span></span>  

* <span data-ttu-id="28d56-180">証明書のサイズは正の値はありません。</span><span class="sxs-lookup"><span data-stu-id="28d56-180">The size of the certificate isn't positive.</span></span>

* <span data-ttu-id="28d56-181">証明書の開始がした後はありません、`IMAGE_NT_HEADERS32`または後に 32 ビット実行可能ファイルの構造、 `IMAGE_NT_HEADERS64` 64 ビット実行可能ファイルの構造体。</span><span class="sxs-lookup"><span data-stu-id="28d56-181">The certificate start isn't after the `IMAGE_NT_HEADERS32` structure for a 32-bit executable or after the `IMAGE_NT_HEADERS64` structure for a 64-bit executable.</span></span>

* <span data-ttu-id="28d56-182">証明書のポインターがない WIN_CERTIFICATE 構造正しく調整します。</span><span class="sxs-lookup"><span data-stu-id="28d56-182">The certificate pointer isn't properly aligned for a WIN_CERTIFICATE structure.</span></span>

<span data-ttu-id="28d56-183">無効な PE 証明書が含まれているファイルを検索するには、開く、**コマンド プロンプト**、という名前の環境変数を設定および`APPXSIP_LOG`値の 1 にします。</span><span class="sxs-lookup"><span data-stu-id="28d56-183">To find files that contain a bad PE cert, open a **Command Prompt**, and set the environment variable named `APPXSIP_LOG` to a value of 1.</span></span>

```
set APPXSIP_LOG=1
```

<span data-ttu-id="28d56-184">その後から、**コマンド プロンプト**、再度アプリケーションへの署名します。</span><span class="sxs-lookup"><span data-stu-id="28d56-184">Then, from the **Command Prompt**, sign your application again.</span></span> <span data-ttu-id="28d56-185">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="28d56-185">For example:</span></span>

```
signtool.exe sign /a /v /fd SHA256 /f APPX_TEST_0.pfx C:\Users\Contoso\Desktop\pe\VLC.appx
```

<span data-ttu-id="28d56-186">無効な PE 証明書が含まれているファイルに関する情報が表示されます、**コンソール ウィンドウ**します。</span><span class="sxs-lookup"><span data-stu-id="28d56-186">Information about files that contain a bad PE cert will appear in the **Console Window**.</span></span> <span data-ttu-id="28d56-187">例:</span><span class="sxs-lookup"><span data-stu-id="28d56-187">For example:</span></span>

```
...

ERROR: [AppxSipCustomLoggerCallback] File has malformed certificate: uninstall.exe

...   
```
## <a name="next-steps"></a><span data-ttu-id="28d56-188">次の手順</span><span class="sxs-lookup"><span data-stu-id="28d56-188">Next Steps</span></span>

<span data-ttu-id="28d56-189">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="28d56-189">**Find answers to your questions**</span></span>

<span data-ttu-id="28d56-190">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="28d56-190">Have questions?</span></span> <span data-ttu-id="28d56-191">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="28d56-191">Ask us on Stack Overflow.</span></span> <span data-ttu-id="28d56-192">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="28d56-192">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="28d56-193">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="28d56-193">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="28d56-194">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="28d56-194">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="28d56-195">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="28d56-195">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
