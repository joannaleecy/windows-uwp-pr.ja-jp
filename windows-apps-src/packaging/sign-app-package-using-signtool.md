---
author: laurenhughes
title: SignTool を使ってアプリ パッケージに署名する
description: SignTool を使って手動でアプリ パッケージに証明書による署名を行います。
ms.author: lahugh
ms.date: 09/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 171f332d-2a54-4c68-8aa0-52975d975fb1
ms.localizationpriority: medium
ms.openlocfilehash: c238855f4f018e8e3142509842221c6b9d97fae3
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4952487"
---
# <a name="sign-an-app-package-using-signtool"></a><span data-ttu-id="cf9d2-104">SignTool を使ってアプリ パッケージに署名する</span><span class="sxs-lookup"><span data-stu-id="cf9d2-104">Sign an app package using SignTool</span></span>


<span data-ttu-id="cf9d2-105">**SignTool** は、アプリ パッケージへのデジタル署名や証明書のバンドルに使用するコマンド ライン ツールです。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-105">**SignTool** is a command line tool used to digitally sign an app package or bundle with a certificate.</span></span> <span data-ttu-id="cf9d2-106">証明書は、(テスト目的で) ユーザーが作成することも、(配布目的で) 企業が作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-106">The certificate can either be created by the user (for testing purposes) or issued by a company (for distribution).</span></span> <span data-ttu-id="cf9d2-107">アプリ パッケージに署名すると、アプリのデータが署名後に変更されていないこと、また、アプリ パッケージに署名したユーザーまたは企業の ID が正しいことをユーザーに保証できます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-107">Signing an app package provides the user with verification that the app's data has not been modified after it was signed while also confirming the identity of the user or company that signed it.</span></span> <span data-ttu-id="cf9d2-108">**SignTool** では、暗号化されているかどうかを問わずアプリ パッケージとアプリ バンドルに署名できます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-108">**SignTool** can sign encrypted or unencrypted app packages and bundles.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="cf9d2-109">Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成し、署名することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-109">If you used Visual Studio to develop your app, it's recommended that you use the Visual Studio wizard to create and sign your app package.</span></span> <span data-ttu-id="cf9d2-110">詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-110">For more information, see [Package a UWP app with Visual Studio](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

<span data-ttu-id="cf9d2-111">コード署名と証明書について詳しくは、「[Introduction to Code Signing](https://msdn.microsoft.com/library/windows/desktop/aa380259.aspx#introduction_to_code_signing)」(コード署名の概要) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-111">For more information about code signing and certificates in general, see [Introduction to Code Signing](https://msdn.microsoft.com/library/windows/desktop/aa380259.aspx#introduction_to_code_signing).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="cf9d2-112">前提条件</span><span class="sxs-lookup"><span data-stu-id="cf9d2-112">Prerequisites</span></span>
- **<span data-ttu-id="cf9d2-113">パッケージ アプリ</span><span class="sxs-lookup"><span data-stu-id="cf9d2-113">A packaged app</span></span>**  
    <span data-ttu-id="cf9d2-114">手動でのアプリ パッケージの作成の詳細については、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-114">To learn more about manually creating an app package, see [Create an app package with the MakeAppx.exe tool](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool).</span></span> 

- **<span data-ttu-id="cf9d2-115">有効な署名証明書</span><span class="sxs-lookup"><span data-stu-id="cf9d2-115">A valid signing certificate</span></span>**  
    <span data-ttu-id="cf9d2-116">有効な署名証明書の作成またはインポートの詳細については、「[パッケージ署名用の証明書を作成する](https://msdn.microsoft.com/windows/uwp/packaging/create-certificate-package-signing)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-116">For more information about creating or importing a valid signing certificate, see [Create or import a certificate for package signing](https://msdn.microsoft.com/windows/uwp/packaging/create-certificate-package-signing).</span></span>

- **<span data-ttu-id="cf9d2-117">SignTool.exe</span><span class="sxs-lookup"><span data-stu-id="cf9d2-117">SignTool.exe</span></span>**  
    <span data-ttu-id="cf9d2-118">SDK のインストール パスに基づき、**SignTool** は Windows 10 PC の以下の場所にあります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-118">Based on your installation path of the SDK, this is where **SignTool** is on your Windows 10 PC:</span></span>
    - <span data-ttu-id="cf9d2-119">x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\SignTool.exe</span><span class="sxs-lookup"><span data-stu-id="cf9d2-119">x86: C:\Program Files (x86)\Windows Kits\10\bin\x86\SignTool.exe</span></span>
    - <span data-ttu-id="cf9d2-120">x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\SignTool.exe</span><span class="sxs-lookup"><span data-stu-id="cf9d2-120">x64: C:\Program Files (x86)\Windows Kits\10\bin\x64\SignTool.exe</span></span>

## <a name="using-signtool"></a><span data-ttu-id="cf9d2-121">SignTool の使用</span><span class="sxs-lookup"><span data-stu-id="cf9d2-121">Using SignTool</span></span>

<span data-ttu-id="cf9d2-122">**SignTool** は、ファイルの署名、署名やタイプスタンプの確認、署名の削除などに使用できます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-122">**SignTool** can be used to sign files, verify signatures or timestamps, remove signatures, and more.</span></span> <span data-ttu-id="cf9d2-123">ここでは、アプリ パッケージの署名に関連がある、**sign** コマンドについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-123">For the purpose of signing an app package, we will focus on the **sign** command.</span></span> <span data-ttu-id="cf9d2-124">**SignTool** の詳細については、[SignTool](https://msdn.microsoft.com/library/windows/desktop/aa387764.aspx) のリファレンス ページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-124">For full information on **SignTool**, see the [SignTool](https://msdn.microsoft.com/library/windows/desktop/aa387764.aspx) reference page.</span></span> 

### <a name="determine-the-hash-algorithm"></a><span data-ttu-id="cf9d2-125">ハッシュ アルゴリズムの特定</span><span class="sxs-lookup"><span data-stu-id="cf9d2-125">Determine the hash algorithm</span></span>
<span data-ttu-id="cf9d2-126">**SignTool** を使用してアプリ パッケージやアプリ バンドルを署名するときは、**SignTool** で使用するハッシュ アルゴリズムとアプリのパッケージ作成に使用したアルゴリズムは同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-126">When using **SignTool** to sign your app package or bundle, the hash algorithm used in **SignTool** must be the same algorithm you used to package your app.</span></span> <span data-ttu-id="cf9d2-127">たとえば、**MakeAppx.exe** を使用して既定の設定でアプリ パッケージを作成した場合、**SignTool** を使用するときは、**MakeAppx.exe** によって使用される既定のアルゴリズムである SHA256 を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-127">For example, if you used **MakeAppx.exe** to create your app package with the default settings, you must specify SHA256 when using **SignTool** since that's the default algorithm used by **MakeAppx.exe**.</span></span>

<span data-ttu-id="cf9d2-128">アプリのパッケージ作成時に使用したハッシュ アルゴリズムを確認するには、アプリ パッケージのコンテンツを抽出し、AppxBlockMap.xml ファイルを調べます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-128">To find out which hash algorithm was used while packaging your app, extract the contents of the app package and inspect the AppxBlockMap.xml file.</span></span> <span data-ttu-id="cf9d2-129">アプリ パッケージのアンパック方法や抽出方法については、「[パッケージまたはバンドルからファイルを抽出する](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool#extract-files-from-a-package-or-bundle)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-129">To learn how to unpack/extract an app package, see [Extract files from a package or bundle](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool#extract-files-from-a-package-or-bundle).</span></span> <span data-ttu-id="cf9d2-130">hash メソッドは BlockMap 要素に含まれ、形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-130">The hash method is in the BlockMap element and has this format:</span></span>
```
<BlockMap xmlns="http://schemas.microsoft.com/appx/2010/blockmap" 
HashMethod="http://www.w3.org/2001/04/xmlenc#sha256">
```

<span data-ttu-id="cf9d2-131">各 HashMethod の値とそれに対応するハッシュ アルゴリズムを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-131">This table shows each HashMethod value and its corresponding hash algorithm:</span></span>


| <span data-ttu-id="cf9d2-132">HashMethod 値</span><span class="sxs-lookup"><span data-stu-id="cf9d2-132">HashMethod value</span></span>                              | <span data-ttu-id="cf9d2-133">ハッシュ アルゴリズム</span><span class="sxs-lookup"><span data-stu-id="cf9d2-133">Hash Algorithm</span></span> |
|-----------------------------------------------|----------------|
| http://www.w3.org/2001/04/xmlenc#sha256       | <span data-ttu-id="cf9d2-134">SHA256</span><span class="sxs-lookup"><span data-stu-id="cf9d2-134">SHA256</span></span>         |
| http://www.w3.org/2001/04/xmldsig-more#sha384 | <span data-ttu-id="cf9d2-135">SHA384</span><span class="sxs-lookup"><span data-stu-id="cf9d2-135">SHA384</span></span>         |
| http://www.w3.org/2001/04/xmlenc#sha512       | <span data-ttu-id="cf9d2-136">SHA512</span><span class="sxs-lookup"><span data-stu-id="cf9d2-136">SHA512</span></span>         |

> [!NOTE]
> <span data-ttu-id="cf9d2-137">**SignTool** の既定のアルゴリズムは (**MakeAppx.exe** で使用できない) SHA1 であるため、**SignTool** を使用するときは、必ずハッシュ アルゴリズムを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-137">Since **SignTool**'s default algorithm is SHA1 (not available in **MakeAppx.exe**), you must always specify a hash algorithm when using **SignTool**.</span></span>

### <a name="sign-the-app-package"></a><span data-ttu-id="cf9d2-138">アプリ パッケージの署名</span><span class="sxs-lookup"><span data-stu-id="cf9d2-138">Sign the app package</span></span>

<span data-ttu-id="cf9d2-139">すべての前提条件が整い、アプリのパッケージの作成に使用したハッシュ アルゴリズムを特定できたら、アプリ パッケージに署名することができます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-139">Once you have all of the prerequisites and you've determined which hash algorithm was used to package your app, you're ready to sign it.</span></span> 

<span data-ttu-id="cf9d2-140">**SignTool** のパッケージ署名に通常使用するコマンド ライン構文は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-140">The general command line syntax for **SignTool** package signing is:</span></span>
```
SignTool sign [options] <filename(s)>
```

<span data-ttu-id="cf9d2-141">アプリの署名に使用する証明書は .pfx ファイルであるか、証明書ストアにインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-141">The certificate used to sign your app must be either a .pfx file or be installed in a certificate store.</span></span>

<span data-ttu-id="cf9d2-142">.pfx ファイルの証明書を使用してアプリ パッケージに署名するには、次の構文を使用します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-142">To sign your app package with a certificate from a .pfx file, use the following syntax:</span></span>
```
SignTool sign /fd <Hash Algorithm> /a /f <Path to Certificate>.pfx /p <Your Password> <File path>.appx
```
```
SignTool sign /fd <Hash Algorithm> /a /f <Path to Certificate>.pfx /p <Your Password> <File path>.msix
```
<span data-ttu-id="cf9d2-143">`/a` オプションを使用すると、**SignTool** によって自動的に最適な証明書が選択されます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-143">Note that the `/a` option allows **SignTool** to choose the best certificate automatically.</span></span>

<span data-ttu-id="cf9d2-144">.pfx ファイルの証明書ではない場合は、次の構文を使用します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-144">If your certificate is not a .pfx file, use the following syntax:</span></span>
```
SignTool sign /fd <Hash Algorithm> /n <Name of Certificate> <File Path>.appx
```
```
SignTool sign /fd <Hash Algorithm> /n <Name of Certificate> <File Path>.msix
```

<span data-ttu-id="cf9d2-145">または、次の構文を使用して、&lt;証明署名&gt; ではなく、使用する証明書の SHA1 ハッシュを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-145">Alternatively, you can specify the SHA1 hash of the desired certificate instead of &lt;Name of Certificate&gt; using this syntax:</span></span>
```
SignTool sign /fd <Hash Algorithm> /sha1 <SHA1 hash> <File Path>.appx
```
```
SignTool sign /fd <Hash Algorithm> /sha1 <SHA1 hash> <File Path>.msix
```

<span data-ttu-id="cf9d2-146">証明書の中には、パスワードを使用しないものもあります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-146">Note that some certificates do not use a password.</span></span> <span data-ttu-id="cf9d2-147">証明書がパスワードを使用していない場合は、サンプル コマンドの "/p &lt;パスワード&gt;" を省略してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-147">If your certificate does not have a password, omit "/p &lt;Your Password&gt;" from the sample commands.</span></span>

<span data-ttu-id="cf9d2-148">アプリ パッケージが有効な証明書で署名されると、パッケージをストアにアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-148">Once your app package is signed with a valid certificate, you're ready to upload your package to the Store.</span></span> <span data-ttu-id="cf9d2-149">ストアへのアプリのアップロードと申請の詳しいガイダンスについては、「[アプリの申請](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-149">For more guidance on uploading and submitting apps to the Store, see [App submissions](https://msdn.microsoft.com/windows/uwp/publish/app-submissions).</span></span>

## <a name="common-errors-and-troubleshooting"></a><span data-ttu-id="cf9d2-150">一般的なエラーとトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="cf9d2-150">Common errors and troubleshooting</span></span>
<span data-ttu-id="cf9d2-151">**SignTool** の使用時に発生する最も一般的なエラーは内部エラーで、代表的なエラーは次の通りです。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-151">The most common types of errors when using **SignTool** are internal and typically look something like this:</span></span>

```
SignTool Error: An unexpected internal error has occurred.
Error information: "Error: SignerSign() failed." (-2147024885 / 0x8007000B) 
```

<span data-ttu-id="cf9d2-152">0x80080206 (APPX_E_CORRUPT_CONTENT) など、エラー コードが 0x8008 で始まる場合、署名対象のパッケージは無効です。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-152">If the error code starts with 0x8008, such as 0x80080206 (APPX_E_CORRUPT_CONTENT), the package being signed is invalid.</span></span> <span data-ttu-id="cf9d2-153">このようなエラーが発生した場合は、パッケージをビルドし直し、**SignTool** をもう一度実行してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-153">If you get this type of error you must rebuild the package and run **SignTool** again.</span></span>

<span data-ttu-id="cf9d2-154">**SignTool** には、証明書のエラーとフィルタリングを表示できるデバッグ オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-154">**SignTool** has a debug option available to show certificate errors and filtering.</span></span> <span data-ttu-id="cf9d2-155">デバッグ機能を使用するには、`/debug` オプションを `sign` の直後に指定し、その後ろに完全な **SignTool** コマンドを指定します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-155">To use the debugging feature, place the `/debug` option directly after `sign`, followed by the full **SignTool** command.</span></span>
```
SignTool sign /debug [options]
``` 

<span data-ttu-id="cf9d2-156">さらに一般的なエラーとしては、0x8007000B があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-156">A more common error is 0x8007000B.</span></span> <span data-ttu-id="cf9d2-157">この種類のエラーについては、イベント ログで詳細を確認してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-157">For this type of error, you can find more information in the event log.</span></span>
 
<span data-ttu-id="cf9d2-158">イベント ログで詳細を参照するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-158">To find more information in the event log:</span></span>
- <span data-ttu-id="cf9d2-159">Eventvwr.msc を実行します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-159">Run Eventvwr.msc</span></span>
- <span data-ttu-id="cf9d2-160">イベント ログを開きます。[イベント ビューアー (ローカル)]、[アプリケーションとサービス ログ]、[Microsoft]、[Windows]、[AppxPackagingOM]、[Microsoft-Windows-AppxPackaging/稼働中] の順に展開します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-160">Open the event log: Event Viewer (Local) -> Applications and Services Logs -> Microsoft -> Windows -> AppxPackagingOM -> Microsoft-Windows-AppxPackaging/Operational</span></span>
- <span data-ttu-id="cf9d2-161">最新のエラー イベントを検索します。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-161">Find the most recent error event</span></span>

<span data-ttu-id="cf9d2-162">内部エラーの 0x8007000B は、通常、次のいずれかの値に対応しています。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-162">The internal error 0x8007000B usually corresponds to one of these values:</span></span>

| **<span data-ttu-id="cf9d2-163">イベント ID</span><span class="sxs-lookup"><span data-stu-id="cf9d2-163">Event ID</span></span>** | **<span data-ttu-id="cf9d2-164">イベント文字列の例</span><span class="sxs-lookup"><span data-stu-id="cf9d2-164">Example event string</span></span>** | **<span data-ttu-id="cf9d2-165">推奨事項</span><span class="sxs-lookup"><span data-stu-id="cf9d2-165">Suggestion</span></span>** |
|--------------|--------------------------|----------------|
| <span data-ttu-id="cf9d2-166">150</span><span class="sxs-lookup"><span data-stu-id="cf9d2-166">150</span></span>          | <span data-ttu-id="cf9d2-167">エラー 0x8007000B: アプリ マニフェストの発行元の名前 (CN=Contoso) は、署名証明書のサブジェクト名 (CN=Contoso, C=US) と同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-167">error 0x8007000B: The app manifest publisher name (CN=Contoso) must match the subject name of the signing certificate (CN=Contoso, C=US).</span></span> | <span data-ttu-id="cf9d2-168">アプリ マニフェストの発行元の名前は、署名のサブジェクト名と完全に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-168">The app manifest publisher name must exactly match the subject name of the signing.</span></span>               |
| <span data-ttu-id="cf9d2-169">151</span><span class="sxs-lookup"><span data-stu-id="cf9d2-169">151</span></span>          | <span data-ttu-id="cf9d2-170">エラー 0x8007000B: 指定されている署名ハッシュ方式 (SHA512) は、アプリ バンドルのブロック マップで使用されているハッシュ方式 (SHA256) と同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-170">error 0x8007000B: The signature hash method specified (SHA512) must match the hash method used in the app package block map (SHA256).</span></span>     | <span data-ttu-id="cf9d2-171">/fd パラメーターに指定されている hashAlgorithm が、正しくありません。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-171">The hashAlgorithm specified in the /fd parameter is incorrect.</span></span> <span data-ttu-id="cf9d2-172">(アプリ パッケージの作成に使用した) アプリ パッケージのブロック マップと一致する hashAlgorithm を使用して **SignTool** を再実行してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-172">Rerun **SignTool** using hashAlgorithm that matches the app package block map (used to create the app package)</span></span>  |
| <span data-ttu-id="cf9d2-173">152</span><span class="sxs-lookup"><span data-stu-id="cf9d2-173">152</span></span>          | <span data-ttu-id="cf9d2-174">エラー 0x8007000B: アプリ パッケージの内容は、そのブロック マップに対して検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-174">error 0x8007000B: The app package contents must validate against its block map.</span></span>                                                           | <span data-ttu-id="cf9d2-175">アプリ パッケージは破損しています。再ビルドして、新しいブロック マップを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-175">The app package is corrupt and needs to be rebuilt to generate a new block map.</span></span> <span data-ttu-id="cf9d2-176">アプリ パッケージの作成の詳細については、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cf9d2-176">For more about creating an app package, see [Create an app package with the MakeAppx.exe tool](https://msdn.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)</span></span> |