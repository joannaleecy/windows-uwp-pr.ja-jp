---
author: normesta
Description: "この記事では、デスクトップ ブリッジに関する既知の問題について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "既知の問題 (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 07/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 71f8ffcb-8a99-4214-ae83-2d4b718a750e
ms.openlocfilehash: bf0e81d4a6ff7bd091f25963b1cf26cdecc93636
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="known-issues-desktop-bridge"></a><span data-ttu-id="3387c-104">既知の問題 (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="3387c-104">Known Issues (Desktop Bridge)</span></span>

<span data-ttu-id="3387c-105">この記事では、デスクトップ ブリッジに関する既知の問題について説明します。</span><span class="sxs-lookup"><span data-stu-id="3387c-105">This article contains known issues with the Desktop Bridge.</span></span>

## <a name="blue-screen-with-error-code-0x139-kernelsecuritycheckfailure"></a><span data-ttu-id="3387c-106">エラー コード 0x139 のブルー スクリーン (KERNEL_SECURITY_CHECK_FAILURE)</span><span class="sxs-lookup"><span data-stu-id="3387c-106">Blue screen with error code 0x139 (KERNEL_SECURITY_CHECK_FAILURE)</span></span>

<span data-ttu-id="3387c-107">Windows ストアのアプリをインストールまたは起動した後、予期せず **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)** というエラーでコンピューターの再起動が発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="3387c-107">After installing or launching certain apps from the Windows Store, your machine may unexpectedly reboot with the error: **0x139 (KERNEL\_SECURITY\_CHECK\_ FAILURE)**.</span></span>

<span data-ttu-id="3387c-108">影響を受けることがわかっているアプリには、Kodi、JT2Go、Ear Trumpet、Teslagrad などがあります。</span><span class="sxs-lookup"><span data-stu-id="3387c-108">Known affected apps include Kodi, JT2Go, Ear Trumpet, Teslagrad, and others.</span></span>

<span data-ttu-id="3387c-109">この問題に対処するための重要な修正プログラムが含まれた [Windows 更新プログラム (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) が 2016 年 10 月 27 日にリリースされました。</span><span class="sxs-lookup"><span data-stu-id="3387c-109">A [Windows update (Version 14393.351 - KB3197954)](https://support.microsoft.com/kb/3197954) was released on 10/27/16 that includes important fixes that address this issue.</span></span> <span data-ttu-id="3387c-110">この問題が発生した場合は、コンピューターを更新してください。</span><span class="sxs-lookup"><span data-stu-id="3387c-110">If you encounter this problem, update your machine.</span></span> <span data-ttu-id="3387c-111">ログインする前にコンピューターが再起動されるため PC を更新できない場合は、システムの復元を使用して、影響を受けたアプリをインストールする前の状態にシステムを回復する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3387c-111">If you are not able to update your PC because your machine restarts before you can log in, you should use system restore to recover your system to a point earlier than when you installed one of the affected apps.</span></span> <span data-ttu-id="3387c-112">システムを復元する方法について詳しくは、「[Windows 10 の回復オプション](https://support.microsoft.com/help/12415/windows-10-recovery-options)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3387c-112">For information on how to use system restore, see [Recovery options in Windows 10](https://support.microsoft.com/help/12415/windows-10-recovery-options).</span></span>

<span data-ttu-id="3387c-113">更新しても問題が解決しない場合や、PC を回復する方法がわからない場合は、[Microsoft サポート](https://support.microsoft.com/contactus/)にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="3387c-113">If updating does not fix the problem or you aren't sure how to recover your PC, please contact [Microsoft Support](https://support.microsoft.com/contactus/).</span></span>

<span data-ttu-id="3387c-114">開発者様には、この更新プログラムが含まれていないバージョンの Windows に Desktop Bridge アプリをインストールしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3387c-114">If you are a developer, you may want to prevent the installation of your Desktop Bridge apps on versions of Windows that do not include this update.</span></span> <span data-ttu-id="3387c-115">その場合、更新プログラムをインストールしていないユーザーはアプリを利用できません。</span><span class="sxs-lookup"><span data-stu-id="3387c-115">Note that by doing this your app will not be available to users that have not yet installed the update.</span></span> <span data-ttu-id="3387c-116">この更新プログラムをインストールしたユーザーだけがアプリを使用できるようにするには、AppxManifest.xml ファイルを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="3387c-116">To limit the availability of your app to users that have installed this update, modify your AppxManifest.xml file as follows:</span></span>

```<TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.351" MaxVersionTested="10.0.14393.351"/>```

<span data-ttu-id="3387c-117">Windows 更新プログラムについて詳しくは、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3387c-117">Details regarding the Windows Update can be found at:</span></span>
* <span data-ttu-id="3387c-118">https://support.microsoft.com/kb/3197954</span><span class="sxs-lookup"><span data-stu-id="3387c-118">https://support.microsoft.com/kb/3197954</span></span>
* <span data-ttu-id="3387c-119">https://support.microsoft.com/help/12387/windows-10-update-history</span><span class="sxs-lookup"><span data-stu-id="3387c-119">https://support.microsoft.com/help/12387/windows-10-update-history</span></span>

## <a name="common-errors-that-can-appear-when-you-sign-your-app"></a><span data-ttu-id="3387c-120">アプリへのサインインの際に表示される可能性のある一般的なエラー</span><span class="sxs-lookup"><span data-stu-id="3387c-120">Common errors that can appear when you sign your app</span></span>

### <a name="publisher-and-cert-mismatch-causes-signtool-error-error-signersign-failed--21470248850x8007000b"></a><span data-ttu-id="3387c-121">発行元と証明書の不一致により、Signtool で「エラー: SignerSign() が失敗しました」(-2147024885/0x8007000b) というエラーが発生する</span><span class="sxs-lookup"><span data-stu-id="3387c-121">Publisher and cert mismatch causes Signtool error "Error: SignerSign() Failed" (-2147024885/0x8007000b)</span></span>

<span data-ttu-id="3387c-122">Windows アプリ パッケージ マニフェストの発行元エントリは、署名に使用する証明書のサブジェクトと一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3387c-122">The Publisher entry in the Windows app package manifest must match the Subject of the certificate you are signing with.</span></span>  <span data-ttu-id="3387c-123">次の方法のいずれかを使用して、証明書のサブジェクトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="3387c-123">You can use any of the following methods to view the subject of the cert.</span></span>

**<span data-ttu-id="3387c-124">オプション1: Powershell</span><span class="sxs-lookup"><span data-stu-id="3387c-124">Option 1: Powershell</span></span>**

<span data-ttu-id="3387c-125">次の PowerShell コマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="3387c-125">Run the following PowerShell command.</span></span> <span data-ttu-id="3387c-126">同じ発行元情報を持つ .cer または .pfx のいずれかを証明書ファイルとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="3387c-126">Either .cer or .pfx can be used as the certificate file, as they have the same publisher information.</span></span>

```ps
(Get-PfxCertificate <cert_file>).Subject
```

**<span data-ttu-id="3387c-127">オプション2: エクスプローラー</span><span class="sxs-lookup"><span data-stu-id="3387c-127">Option 2: File Explorer</span></span>**

<span data-ttu-id="3387c-128">エクスプローラーで証明書をダブルクリックし、*[詳細]* タブを選び、一覧の *[サブジェクト]*フィールドを選びます。</span><span class="sxs-lookup"><span data-stu-id="3387c-128">Double-click the certificate in File Explorer, select the *Details* tab, and then the *Subject* field in the list.</span></span> <span data-ttu-id="3387c-129">内容をコピーすることができます。</span><span class="sxs-lookup"><span data-stu-id="3387c-129">You can then copy the contents.</span></span>

**<span data-ttu-id="3387c-130">オプション3: CertUtil</span><span class="sxs-lookup"><span data-stu-id="3387c-130">Option 3: CertUtil</span></span>**

<span data-ttu-id="3387c-131">コマンドラインから PFX ファイルに **certutil** を実行し、出力から *[サブジェクト]* フィールドをコピーします。</span><span class="sxs-lookup"><span data-stu-id="3387c-131">Run **certutil** from the the command line on the PFX file and copy the *Subject* field from the output.</span></span>

```cmd
certutil -dump <cert_file.pfx>
```

### <a name="corrupted-or-malformed-authenticode-signatures"></a><span data-ttu-id="3387c-132">Authenticode 署名が破損しているか、形式が正しくない</span><span class="sxs-lookup"><span data-stu-id="3387c-132">Corrupted or malformed Authenticode signatures</span></span>

<span data-ttu-id="3387c-133">このセクションでは、Windows アプリ パッケージ内の移植可能な実行可能ファイル (PE) で、Authenticode 署名が破損しているかまたは形式が正しくない問題を特定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3387c-133">This section contains details on how to identify issues with Portable Executable (PE) files in your Windows app package that may contain corrupted or malformed Authenticode signatures.</span></span> <span data-ttu-id="3387c-134">任意のバイナリ形式 (.exe、.dll、.chm など) の PE ファイルに対する無効な Authenticode 署名によって、パッケージが正しく署名されない場合や、Windows アプリ パッケージから展開できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="3387c-134">Invalid Authenticode signatures on your PE files, which may be in any binary format (e.g. .exe, .dll, .chm, etc.), will prevent your package from being signed properly, and thus prevent it from being deployable from an Windows app package.</span></span>

<span data-ttu-id="3387c-135">PE ファイルの Authenticode 署名の場所は、Optional Header Data Directories の Certificate Table エントリおよび関連付けられている Attribute Certificate Table で指定されます。</span><span class="sxs-lookup"><span data-stu-id="3387c-135">The location of the Authenticode signature of a PE file is specified by the Certificate Table entry in the Optional Header Data Directories and the associated Attribute Certificate Table.</span></span> <span data-ttu-id="3387c-136">署名を検証する場合、これらの構造体で指定されている情報を使用して、PE ファイルの署名を検出します。</span><span class="sxs-lookup"><span data-stu-id="3387c-136">During signature verification, the information specified in these structures is used to locate the signature on a PE file.</span></span> <span data-ttu-id="3387c-137">これらの値が壊れている場合、ファイルの署名が無効であるように見える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3387c-137">If these values get corrupted then it is possible for a file to appear to be invalidly signed.</span></span>

<span data-ttu-id="3387c-138">Authenticode 署名が正しいと見なされるには、Authenticode 署名が次の条件を満たしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3387c-138">For the Authenticode signature to be correct, the following must be true of the Authenticode signature:</span></span>

- <span data-ttu-id="3387c-139">PE ファイル内の **WIN_CERTIFICATE** エントリの先頭は、実行可能ファイルの終わりを超えて拡張できない</span><span class="sxs-lookup"><span data-stu-id="3387c-139">The start of the **WIN_CERTIFICATE** entry in the PE file cannot extend past the end of the executable</span></span>
- <span data-ttu-id="3387c-140">**WIN_CERTIFCATE** エントリは、イメージの最後に置かれている必要がある</span><span class="sxs-lookup"><span data-stu-id="3387c-140">The **WIN_CERTIFCATE** entry should be located at the end of the image</span></span>
- <span data-ttu-id="3387c-141">**WIN_CERTIFICATE** エントリのサイズは正の値である必要がある</span><span class="sxs-lookup"><span data-stu-id="3387c-141">The size of the **WIN_CERTIFICATE** entry must be positive</span></span>
- <span data-ttu-id="3387c-142">**WIN_CERTIFICATE** エントリは、32 ビット実行可能ファイルの場合は **IMAGE_NT_HEADERS32** 構造体より後、64 ビット実行可能ファイルの場合は IMAGE_NT_HEADERS64 構造体より後に開始する必要がある</span><span class="sxs-lookup"><span data-stu-id="3387c-142">The **WIN_CERTIFICATE**entry must start after the **IMAGE_NT_HEADERS32** structure for 32-bit executables and IMAGE_NT_HEADERS64 structure for 64-bit executables</span></span>

<span data-ttu-id="3387c-143">詳しくは、[移植可能な実行可能ファイルの Authenticode 署名の仕様に関するドキュメント](http://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx)と [PE ファイル形式の仕様に関するページ](https://msdn.microsoft.com/windows/hardware/gg463119.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3387c-143">For more details, please refer to the [Authenticode Portal Executable specification](http://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx) and the [PE file format specification](https://msdn.microsoft.com/windows/hardware/gg463119.aspx).</span></span>

<span data-ttu-id="3387c-144">Windows アプリ パッケージに署名するときに、SignTool.exe で、壊れているバイナリや形式が正しくないバイナリの一覧を出力できます。</span><span class="sxs-lookup"><span data-stu-id="3387c-144">Note that SignTool.exe can output a list of the corrupted or malformed binaries when attempting to sign an Windows app package.</span></span> <span data-ttu-id="3387c-145">これを行うには、環境変数 APPXSIP_LOG を 1 に設定して (例: ```set APPXSIP_LOG=1```) 詳細なログを有効にし、SignTool.exe を再度実行します。</span><span class="sxs-lookup"><span data-stu-id="3387c-145">To do this, enable verbose logging by setting the environment variable APPXSIP_LOG to 1 (e.g., ```set APPXSIP_LOG=1``` ) and re-run SignTool.exe.</span></span>

<span data-ttu-id="3387c-146">これらの形式が正しくないバイナリを修正するには、上記の要件に準拠していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3387c-146">To fix these malformed binaries, ensure they conform to the requirements above.</span></span>

<span id="known-issues-anchor" />
## <a name="known-issues-with-cvbnet-and-c-uwp-projects"></a><span data-ttu-id="3387c-147">C#/VB.NET と C++ UWP プロジェクトの既知の問題</span><span class="sxs-lookup"><span data-stu-id="3387c-147">Known issues with C#/VB.NET and C++ UWP projects</span></span>

<span data-ttu-id="3387c-148">C# プロジェクトを使用してアプリをパッケージ化する場合は、以下の既知の問題について理解しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="3387c-148">If you prefer to use a C# project to package your app, you need to be aware of the following known issues.</span></span>

- <span data-ttu-id="3387c-149">Debug モードでアプリをビルドすると、次のようなエラーが出力されます。_Microsoft.Net.CoreRuntime.targets(235,5): エラー: カスタム エントリ ポイントを持つアプリケーションの実行可能ファイルはサポートされていません。パッケージ マニフェストでの Application 要素の Executable 属性を確認してください。_</span><span class="sxs-lookup"><span data-stu-id="3387c-149">Building the app in Debug mode results in the error: _Microsoft.Net.CoreRuntime.targets(235,5): error : Applications with custom entry point executables are not supported. Check Executable attribute of the Application element in the package manifest._</span></span>

  <span data-ttu-id="3387c-150">この問題を解決するには、代わりに Release モードを使用します。</span><span class="sxs-lookup"><span data-stu-id="3387c-150">To resolve this issue, use Release mode instead.</span></span>

- <span data-ttu-id="3387c-151">UWP プロジェクトのルート フォルダーに格納されている Win32 バイナリは、Release では削除されます。</span><span class="sxs-lookup"><span data-stu-id="3387c-151">Win32 Binaries stored in the root folder of the UWP project are removed in Release.</span></span> <span data-ttu-id="3387c-152">.NET Native コンパイラは最終的なパッケージからそれらのバイナリを削除します。これにより、実行可能ファイルのエントリ ポイントが見つからないため、マニフェストの検証エラーが出力されます。</span><span class="sxs-lookup"><span data-stu-id="3387c-152">The .NET Native compiler will remove those from the final package, resulting in a manifest validation error since the executable entry point can't be found.</span></span>

  <span data-ttu-id="3387c-153">この問題を解決するには、Win32 バイナリを保存するプロジェクトのサブフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="3387c-153">To resolve this issue, create a subfolder in your project to store win32 binaries.</span></span>


## <a name="you-receive-the-error----msb4018-the-generateresource-task-failed-unexpectedly"></a><span data-ttu-id="3387c-154">次のエラーが表示されます。MSB4018: "GenerateResource" タスクが予期せずに失敗しました</span><span class="sxs-lookup"><span data-stu-id="3387c-154">You receive the error    MSB4018 The "GenerateResource" task failed unexpectedly</span></span>

<span data-ttu-id="3387c-155">これは、サテライト アセンブリをパッケージ リソース インデックス (PRI) ファイルに変換しようとすると発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="3387c-155">This can happen when trying to convert satellite assemblies to Package Resource Index (PRI) files.</span></span>

<span data-ttu-id="3387c-156">Microsoft ではこの問題を把握しており、より長期的な解決策に取り組んでいるところです。</span><span class="sxs-lookup"><span data-stu-id="3387c-156">We are aware of this issue and are working on a more long term solution.</span></span> <span data-ttu-id="3387c-157">一時的な回避策として、次の XML 行をホスティング プロジェクト ファイルの最初の PropertyGroup 要素に追加することで、リソース ジェネレータを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="3387c-157">As a temporary workaround, you can disable the resource generator by adding this line of XML to the first PropertyGroup element in hosting project file:</span></span>

``<AppxGeneratePrisForPortableLibrariesEnabled>false</AppxGeneratePrisForPortableLibrariesEnabled>``
