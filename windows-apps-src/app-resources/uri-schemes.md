---
author: stevewhims
Description: "アプリのパッケージ、アプリのデータ フォルダー、またはクラウドからのファイルを参照するために使用できる URI (Uniform Resource Identifier) スキームはいくつかあります。 また、URI スキームを使用して、アプリのリソース ファイル (.resw) から読み込まれた文字列を参照することもできます。"
title: "URI スキーム"
template: detail.hbs
ms.author: stwhi
ms.date: 10/16/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子"
localizationpriority: medium
ms.openlocfilehash: 7cbd4a6fea3ca7d179eae9857c6e98010d11439e
ms.sourcegitcommit: d0c93d734639bd31f264424ae5b6fead903a951d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2017
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="uri-schemes"></a><span data-ttu-id="d80cc-105">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="d80cc-105">URI schemes</span></span>

<span data-ttu-id="d80cc-106">アプリのパッケージ、アプリのデータ フォルダー、またはクラウドからのファイルを参照するために使用できる URI (Uniform Resource Identifier) スキームはいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-106">There are several URI (Uniform Resource Identifier) schemes that you can use to refer to files that come from your app's package, your app's data folders, or the cloud.</span></span> <span data-ttu-id="d80cc-107">また、URI スキームを使用して、アプリのリソース ファイル (.resw) から読み込まれた文字列を参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-107">You can also use a URI scheme to refer to strings loaded from your app's Resources Files (.resw).</span></span> <span data-ttu-id="d80cc-108">これらの URI スキームは、コード、XAML マークアップ、アプリ パッケージ マニフェスト、またはタイル/トースト通知テンプレートで使用できます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-108">You can use these URI schemes in your code, in your XAML markup, in your app package manifest, or in your tile and toast notification templates.</span></span>

## <a name="common-features-of-the-uri-schemes"></a><span data-ttu-id="d80cc-109">URI スキームの一般的な機能</span><span class="sxs-lookup"><span data-stu-id="d80cc-109">Common features of the URI schemes</span></span>

<span data-ttu-id="d80cc-110">このトピックで説明しているスキームはすべて、正規化とリソース取得について一般的な URI スキーム規則に従っています。</span><span class="sxs-lookup"><span data-stu-id="d80cc-110">All of the schemes described in this topic follow typical URI scheme rules for normalization and resource retrieval.</span></span> <span data-ttu-id="d80cc-111">URI の一般的な構文については、[RFC 3986](http://go.microsoft.com/fwlink/p/?LinkId=263444) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d80cc-111">See [RFC 3986](http://go.microsoft.com/fwlink/p/?LinkId=263444) for the generic syntax of a URI.</span></span>

<span data-ttu-id="d80cc-112">すべての URI スキームでは [RFC 3986](http://go.microsoft.com/fwlink/p/?LinkId=263444) に従い、URI の機関コンポーネントおよびパス コンポーネントとして階層部分を定義しています。</span><span class="sxs-lookup"><span data-stu-id="d80cc-112">All of the URI schemes define the hierarchical part per [RFC 3986](http://go.microsoft.com/fwlink/p/?LinkId=263444) as the authority and path components of the URI.</span></span>

```
URI         = scheme ":" hier-part [ "?" query ] [ "#" fragment ]
hier-part   = "//" authority path-abempty
            / path-absolute
            / path-rootless
            / path-empty
```

<span data-ttu-id="d80cc-113">つまり、URI には原則として 3 つのコンポーネントがあります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-113">What this means is that there are essentially three components to a URI.</span></span> <span data-ttu-id="d80cc-114">URI *スキーム* には、2 つのスラッシュの直後に "*機関*" コンポーネントがあります (空白にすることも可能)。</span><span class="sxs-lookup"><span data-stu-id="d80cc-114">Immediately following the two forward slashes of the URI *scheme* is a component (which can be empty) called the *authority*.</span></span> <span data-ttu-id="d80cc-115">この直後にあるのが "*パス*" です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-115">And immediately following that is the *path*.</span></span> <span data-ttu-id="d80cc-116">例として URI `http://www.contoso.com/welcome.png` では、スキームが "`http://`"、機関が "`www.contoso.com`"、パスが "`/welcome.png`" です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-116">Taking the URI `http://www.contoso.com/welcome.png` as an example, the scheme is "`http://`", the authority is "`www.contoso.com`", and the path is "`/welcome.png`".</span></span> <span data-ttu-id="d80cc-117">別の例として、URI `ms-appx:///logo.png` では、機関コンポーネントが空であり、既定値が使用されています。</span><span class="sxs-lookup"><span data-stu-id="d80cc-117">Another example is the URI `ms-appx:///logo.png`, where the authority components is empty and takes a default value.</span></span>

<span data-ttu-id="d80cc-118">フラグメント コンポーネントは、このトピックで説明している URI のスキーム固有の処理では無視されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-118">The fragment component is ignored by the scheme-specific processing of the URIs mentioned in this topic.</span></span> <span data-ttu-id="d80cc-119">リソースの取得と比較の間、フラグメント コンポーネントは意味を持ちません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-119">During resource retrieval and comparison, the fragment component has no bearing.</span></span> <span data-ttu-id="d80cc-120">ただし、特定の実装上のレイヤーでは、フラグメントを解釈してセカンダリ リソースを取得することがあります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-120">However, layers above specific implementation may interpret the fragment to retrieve a secondary resource.</span></span>

<span data-ttu-id="d80cc-121">すべての IRI コンポーネントの正規化が終了すると、バイトごとの比較が行われます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-121">Comparison occurs byte for byte after normalization of all IRI components.</span></span>

## <a name="case-insensitivity-and-normalization"></a><span data-ttu-id="d80cc-122">大文字と小文字の区別と正規化</span><span class="sxs-lookup"><span data-stu-id="d80cc-122">Case-insensitivity and normalization</span></span>

<span data-ttu-id="d80cc-123">このトピックで説明している URI スキームはすべて、スキームの正規化とリソース取得について一般的な URI 規則 (RFC 3986) に従っています。</span><span class="sxs-lookup"><span data-stu-id="d80cc-123">All the URI schemes described in this topic follow typical URI rules (RFC 3986) for normalization and resource retrieval for schemes.</span></span> <span data-ttu-id="d80cc-124">正規化されたこれらの URI の形式は大文字と小文字を保持し、RFC 3986 の非予約文字をパーセントデコードします。</span><span class="sxs-lookup"><span data-stu-id="d80cc-124">The normalized form of these URIs maintains case and percent-decodes RFC 3986 unreserved characters.</span></span>

<span data-ttu-id="d80cc-125">このトピックで説明されているすべての URI スキームでは、標準では*スキーム*、*機関*、および*パス*の大文字と小文字が区別されません。それ以外でも、大文字と小文字を区別せずシステムによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-125">For all the URI schemes described in this topic, *scheme*, *authority*, and *path* are either case-insensitive by standard, or else are processed by the system in a case-insensitive way.</span></span> <span data-ttu-id="d80cc-126">**注** そのルールの唯一の例外は、`ms-resource` の*機関*で、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-126">**Note** The only exception to that rule is the *authority* of `ms-resource`, which is case-sensitive.</span></span>

## <a name="ms-appx-and-ms-appx-web"></a><span data-ttu-id="d80cc-127">ms-appx と ms-appx-web</span><span class="sxs-lookup"><span data-stu-id="d80cc-127">ms-appx and ms-appx-web</span></span>

<span data-ttu-id="d80cc-128">アプリのパッケージに含まれるファイルを参照するには、URI スキーム `ms-appx` または `ms-appx-web` を使用します (「[アプリのパッケージ化](../packaging/index.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="d80cc-128">Use the `ms-appx` or the `ms-appx-web` URI scheme to refer to a file that comes from your app's package (see [Packaging apps](../packaging/index.md)).</span></span> <span data-ttu-id="d80cc-129">アプリ パッケージ内のファイルは通常、静止画像ファイル、データ ファイル、コード ファイル、レイアウト ファイルです。</span><span class="sxs-lookup"><span data-stu-id="d80cc-129">Files in your app package are typically static images, data, code, and layout files.</span></span> <span data-ttu-id="d80cc-130">`ms-appx-web` スキームは、`ms-appx` と同じファイルにアクセスしますが、このファイルは Web コンパートメントにあります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-130">The `ms-appx-web` scheme accesses the same files as `ms-appx`, but in the web compartment.</span></span> <span data-ttu-id="d80cc-131">例や詳しい情報については、「[XAML マークアップとコードから画像やその他のアセットを参照する](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d80cc-131">For examples and more info, see [Reference an image or other asset from XAML markup and code](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code).</span></span>

### <a name="scheme-name-ms-appx-and-ms-appx-web"></a><span data-ttu-id="d80cc-132">スキーム名 (ms-appx と ms-appx-web)</span><span class="sxs-lookup"><span data-stu-id="d80cc-132">Scheme name (ms-appx and ms-appx-web)</span></span>

<span data-ttu-id="d80cc-133">URI スキーム名は、文字列 "ms-appx" または "ms-appx-web" です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-133">The URI scheme name is the string "ms-appx" or "ms-appx-web".</span></span>

```xml
ms-appx://
```

```xml
ms-appx-web://
```

### <a name="authority-ms-appx-and-ms-appx-web"></a><span data-ttu-id="d80cc-134">機関 (ms-appx と ms-appx-web)</span><span class="sxs-lookup"><span data-stu-id="d80cc-134">Authority (ms-appx and ms-appx-web)</span></span>

<span data-ttu-id="d80cc-135">機関は、パッケージ マニフェストで定義されているパッケージ ID 名です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-135">The authority is the package identity name that is defined in the package manifest.</span></span> <span data-ttu-id="d80cc-136">したがって、URI 形式と IRI (Internationalized Resource Identifier) 形式のどちらでも、パッケージ ID 名で許可されている文字のセットに制限されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-136">It is therefore limited in both the URI and IRI (Internationalized resource identifier) form to the set of characters allowed in a package identity name.</span></span> <span data-ttu-id="d80cc-137">パッケージ名は、現在動作しているアプリのパッケージ依存グラフ内のいずれかのパッケージの名前にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-137">The package name must be the name of one of the packages in the current running app's package dependency graph.</span></span>

```xml
ms-appx://Contoso.MyApp/
ms-appx-web://Contoso.MyApp/
```

<span data-ttu-id="d80cc-138">機関に他の文字が使用されると、取得と比較の処理に失敗します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-138">If any other character appears in the authority, then retrieval and comparison fail.</span></span> <span data-ttu-id="d80cc-139">機関の既定値は、現在実行中のアプリのパッケージです。</span><span class="sxs-lookup"><span data-stu-id="d80cc-139">The default value for the authority is the currently running app's package.</span></span>

```xml
ms-appx:///
ms-appx-web:///
```

### <a name="user-info-and-port-ms-appx-and-ms-appx-web"></a><span data-ttu-id="d80cc-140">ユーザー情報とポート (ms-appx と ms-appx-web)</span><span class="sxs-lookup"><span data-stu-id="d80cc-140">User info and port (ms-appx and ms-appx-web)</span></span>

<span data-ttu-id="d80cc-141">`ms-appx` スキームは、他の一般的なスキームとは異なり、ユーザー情報やポートのコンポーネントを定義しません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-141">The `ms-appx` scheme, unlike other popular schemes, does not define a user info or port component.</span></span> <span data-ttu-id="d80cc-142">"@" と ":" は機関の有効な値として許可されていないため、これらが含まれていると参照は失敗します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-142">Since "@" and ":" are not allowed as valid authority values, lookup will fail if they are included.</span></span> <span data-ttu-id="d80cc-143">以下の処理はそれぞれ失敗となります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-143">Each of the following fails.</span></span>

```xml
ms-appx://john@contoso.myapp/default.html
ms-appx://john:password@contoso.myapp/default.html
ms-appx://contoso.myapp:8080/default.html
ms-appx://john:password@contoso.myapp:8080/default.html
```

### <a name="path-ms-appx-and-ms-appx-web"></a><span data-ttu-id="d80cc-144">パス (ms-appx と ms-appx-web)</span><span class="sxs-lookup"><span data-stu-id="d80cc-144">Path (ms-appx and ms-appx-web)</span></span>

<span data-ttu-id="d80cc-145">パス コンポーネントは RFC 3986 の一般的な構文に一致し、IRI 内の非 ASCII 文字をサポートします。</span><span class="sxs-lookup"><span data-stu-id="d80cc-145">The path component matches the generic RFC 3986 syntax and supports non-ASCII characters in IRIs.</span></span> <span data-ttu-id="d80cc-146">パス コンポーネントは、ファイルの論理ファイル パスまたは物理ファイル パスを定義します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-146">The path component defines the logical or physical file path of a file.</span></span> <span data-ttu-id="d80cc-147">このファイルは、機関で指定されたアプリのアプリ パッケージのインストール先に関連付けられたフォルダー内にあります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-147">That file is in a folder associated with the installed location of the app package, for the app specified by the authority.</span></span>

<span data-ttu-id="d80cc-148">パスが物理パスとファイル名を指している場合は、物理ファイル資産が取得されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-148">If the path refers to a physical path and file name then that physical file asset is retrieved.</span></span> <span data-ttu-id="d80cc-149">ただし、このような物理ファイルが見つからなかった場合は、取得中に返される実際のリソースは、実行時のコンテンツ ネゴシエーションを使って決定されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-149">But if no such physical file is found then the actual resource returned during retrieval is determined by using content negotiation at runtime.</span></span> <span data-ttu-id="d80cc-150">この決定は、アプリ、OS、その他のユーザー設定 (言語、表示倍率、テーマ、ハイ コントラスト、その他の実行時コンテキスト) に基づいて行われます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-150">This determination is based on app, OS, and user settings such as language, display scale factor, theme, high contrast, and other runtime contexts.</span></span> <span data-ttu-id="d80cc-151">たとえば、取得される実際のリソース値を決定する際には、アプリの言語、システムのディスプレイ設定、ユーザーのハイ コントラスト設定の組み合わせが考慮されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-151">For example, a combination of the app's languages, the system's display settings, and the user's high contrast settings may be taken into account when determining the actual resource value to be retrieved.</span></span>

```xml
ms-appx:///images/logo.png
```

<span data-ttu-id="d80cc-152">上の URI では、実際には次の物理ファイル名を持つ現在のアプリ パッケージ内のファイルが取得されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-152">The URI above may actually retrieve a file within the current app's package with the following physical file name.</span></span>

```
\Images\fr-FR\logo.scale-100_contrast-white.png
```

<span data-ttu-id="d80cc-153">もちろん、完全名を直接参照することで、同じ物理ファイルを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-153">You could of course also retrieve that same physical file by referring to it directly by its full name.</span></span>

**<span data-ttu-id="d80cc-154">XAML</span><span class="sxs-lookup"><span data-stu-id="d80cc-154">XAML</span></span>**
```xml
<Image Source="ms-appx:///images/fr-FR/logo.scale-100_contrast-white.png"/>
```

<span data-ttu-id="d80cc-155">パス コンポーネント `ms-appx(-web)` では、一般的な URI と同様、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-155">The path component of `ms-appx(-web)` is, like generic URIs, case sensitive.</span></span> <span data-ttu-id="d80cc-156">ただし、リソースにアクセスする基になるファイル システムが大文字と小文字を区別しない場合 (NTFS など)、リソースの取得は大文字と小文字の区別なく実行されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-156">However, when the underlying file system by which the resource is accessed is case insensitive, such as for NTFS, the retrieval of the resource is done case-insensitively.</span></span>

<span data-ttu-id="d80cc-157">正規化された URI 形式では大文字と小文字が保持され、RFC 3986 の非予約文字がパーセントデコードされます ("%" 記号の後に 2 桁の 16 進数表現)。</span><span class="sxs-lookup"><span data-stu-id="d80cc-157">The normalized form of the URI maintains case, and percent-decodes (a "%" symbol followed by the two-digit hexadecimal representation) RFC 3986 unreserved characters.</span></span> <span data-ttu-id="d80cc-158">"?"、"#"、"/"、"*"、'”' (二重引用符) の各文字は、ファイル名やフォルダー名などのデータを示すパス内でパーセントエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-158">The characters "?", "#", "/", "*", and '”' (the double-quote character) must be percent-encoded in a path to represent data such as file or folder names.</span></span> <span data-ttu-id="d80cc-159">パーセントエンコードされたすべての文字は、取得前にデコードされます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-159">All percent-encoded characters are decoded before retrieval.</span></span> <span data-ttu-id="d80cc-160">したがって、Hello#World.html という名前のファイルを取得するには、この URI を使用します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-160">Thus, to retrieve a file named Hello#World.html, use this URI.</span></span>

```xml
ms-appx:///Hello%23World.html
```

### <a name="query-ms-appx-and-ms-appx-web"></a><span data-ttu-id="d80cc-161">クエリ (ms-appx と ms-appx-web)</span><span class="sxs-lookup"><span data-stu-id="d80cc-161">Query (ms-appx and ms-appx-web)</span></span>

<span data-ttu-id="d80cc-162">クエリ パラメーターは、リソースの取得時には無視されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-162">Query parameters are ignored during retrieval of resources.</span></span> <span data-ttu-id="d80cc-163">正規化されたクエリ パラメーターの形式では大文字と小文字が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-163">The normalized form of query parameters maintains case.</span></span> <span data-ttu-id="d80cc-164">クエリ パラメーターは、比較時には無視されません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-164">Query parameters are not ignored during comparison.</span></span>

## <a name="ms-appdata"></a><span data-ttu-id="d80cc-165">ms-appdata</span><span class="sxs-lookup"><span data-stu-id="d80cc-165">ms-appdata</span></span>

<span data-ttu-id="d80cc-166">アプリのローカル フォルダー、ローミング フォルダー、一時データ フォルダーのアプリ ファイルを参照するには、URI スキーム `ms-appdata` を使用します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-166">Use the `ms-appdata` URI scheme to refer to files that come from the app's local, roaming, and temporary data folders.</span></span> <span data-ttu-id="d80cc-167">アプリ データ フォルダーについて詳しくは、「[設定と他のアプリ データを保存して取得する](../app-settings/store-and-retrieve-app-data.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d80cc-167">For more info about these app data folders, see [Store and retrieve settings and other app data](../app-settings/store-and-retrieve-app-data.md).</span></span>

<span data-ttu-id="d80cc-168">URI スキーム `ms-appdata` では、[ms-appx と ms-appx-web](#ms-appx-and-ms-appx-web) で行われるような、実行時のコンテンツ ネゴシエーションは行われません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-168">The `ms-appdata` URI scheme does not perform the runtime content negotiation that [ms-appx and ms-appx-web](#ms-appx-and-ms-appx-web) do.</span></span> <span data-ttu-id="d80cc-169">ただし、URI 内で物理ファイルの完全名を使用すると、[ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) のコンテンツに応答し、アプリ データから適切なアセットを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-169">But you can respond to the contents of [ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) and load the appropriate assets from app data using their full physical file name in the URI.</span></span>

### <a name="scheme-name-ms-appdata"></a><span data-ttu-id="d80cc-170">スキーム名 (ms-appdata)</span><span class="sxs-lookup"><span data-stu-id="d80cc-170">Scheme name (ms-appdata)</span></span>

<span data-ttu-id="d80cc-171">URI スキーム名は、文字列 "ms-appdata" です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-171">The URI scheme name is the string "ms-appdata".</span></span>

```xml
ms-appdata://
```

### <a name="authority-ms-appdata"></a><span data-ttu-id="d80cc-172">機関 (ms-appdata)</span><span class="sxs-lookup"><span data-stu-id="d80cc-172">Authority (ms-appdata)</span></span>

<span data-ttu-id="d80cc-173">機関は、パッケージ マニフェストで定義されているパッケージ ID 名です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-173">The authority is the package identity name that is defined in the package manifest.</span></span> <span data-ttu-id="d80cc-174">したがって、URI 形式と IRI (Internationalized Resource Identifier) 形式のどちらでも、パッケージ ID 名で許可されている文字のセットに制限されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-174">It is therefore limited in both the URI and IRI (Internationalized resource identifier) form to the set of characters allowed in a package identity name.</span></span> <span data-ttu-id="d80cc-175">パッケージ名は、現在動作しているアプリ パッケージの名前にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-175">The package name must be the name of the current running app's package.</span></span>

```xml
ms-appdata://Contoso.MyApp/
```

<span data-ttu-id="d80cc-176">機関に他の文字が使用されると、取得と比較の処理に失敗します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-176">If any other character appears in the authority, then retrieval and comparison fail.</span></span> <span data-ttu-id="d80cc-177">機関の既定値は、現在実行中のアプリのパッケージです。</span><span class="sxs-lookup"><span data-stu-id="d80cc-177">The default value for the authority is the currently running app's package.</span></span>

```xml
ms-appdata:///
```

### <a name="user-info-and-port-ms-appdata"></a><span data-ttu-id="d80cc-178">ユーザー情報とポート (ms-appdata)</span><span class="sxs-lookup"><span data-stu-id="d80cc-178">User info and port (ms-appdata)</span></span>

<span data-ttu-id="d80cc-179">`ms-appdata` スキームは、他の一般的なスキームとは異なり、ユーザー情報やポートのコンポーネントを定義しません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-179">The `ms-appdata` scheme, unlike other popular schemes, does not define a user info or port component.</span></span> <span data-ttu-id="d80cc-180">"@" と ":" は機関の有効な値として許可されていないため、これらが含まれていると参照は失敗します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-180">Since "@" and ":" are not allowed as valid authority values, lookup will fail if they are included.</span></span> <span data-ttu-id="d80cc-181">以下の処理はそれぞれ失敗となります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-181">Each of the following fails.</span></span>

```xml
ms-appdata://john@contoso.myapp/local/data.xml
ms-appdata://john:password@contoso.myapp/local/data.xml
ms-appdata://contoso.myapp:8080/local/data.xml
ms-appdata://john:password@contoso.myapp:8080/local/data.xml
```

### <a name="path-ms-appdata"></a><span data-ttu-id="d80cc-182">パス (ms-appdata)</span><span class="sxs-lookup"><span data-stu-id="d80cc-182">Path (ms-appdata)</span></span>

<span data-ttu-id="d80cc-183">パス コンポーネントは RFC 3986 の一般的な構文に一致し、IRI 内の非 ASCII 文字をサポートします。</span><span class="sxs-lookup"><span data-stu-id="d80cc-183">The path component matches the generic RFC 3986 syntax and supports non-ASCII characters in IRIs.</span></span> <span data-ttu-id="d80cc-184">[Windows.Storage.ApplicationData](/uwp/api/Windows.Storage.ApplicationData?branch=live) の場所には、ローカル ストレージ、ローミング ストレージ、一時的状態のストレージの 3 つの予約済みフォルダーがあります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-184">Within the [Windows.Storage.ApplicationData](/uwp/api/Windows.Storage.ApplicationData?branch=live) location are three reserved folders for local, roaming, and temporary state storage.</span></span> <span data-ttu-id="d80cc-185">`ms-appdata` スキームを使用すると、これらの場所にあるファイルとフォルダーへのアクセスが可能になります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-185">The `ms-appdata` scheme allows access to files and folders in those locations.</span></span> <span data-ttu-id="d80cc-186">パス コンポーネントの最初のセグメントでは、次の方法で特定のフォルダーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-186">The first segment of the path component must specify the particular folder in the following fashion.</span></span> <span data-ttu-id="d80cc-187">したがって、"hier-part" の "path-empty" 形式は許可されません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-187">Thus the "path-empty" form of "hier-part" is not legal.</span></span>

<span data-ttu-id="d80cc-188">ローカル フォルダーの場合:</span><span class="sxs-lookup"><span data-stu-id="d80cc-188">Local folder.</span></span>

```xml
ms-appdata:///local/
```

<span data-ttu-id="d80cc-189">一時フォルダーの場合:</span><span class="sxs-lookup"><span data-stu-id="d80cc-189">Temporary folder.</span></span>

```xml
ms-appdata:///temp/
```

<span data-ttu-id="d80cc-190">ローミング フォルダーの場合:</span><span class="sxs-lookup"><span data-stu-id="d80cc-190">Roaming folder.</span></span>

```xml
ms-appdata:///roaming/
```

<span data-ttu-id="d80cc-191">パス コンポーネント `ms-appdata` では、一般的な URI と同様、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-191">The path component of `ms-appdata` is, like generic URIs, case sensitive.</span></span> <span data-ttu-id="d80cc-192">ただし、リソースにアクセスする基になるファイル システムが大文字と小文字を区別しない場合 (NTFS など)、リソースの取得は大文字と小文字の区別なく実行されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-192">However, when the underlying file system by which the resource is accessed is case insensitive, such as for NTFS, the retrieval of the resource is done case-insensitively.</span></span>

<span data-ttu-id="d80cc-193">正規化された URI 形式では大文字と小文字が保持され、RFC 3986 の非予約文字がパーセントデコードされます ("%" 記号の後に 2 桁の 16 進数表現)。</span><span class="sxs-lookup"><span data-stu-id="d80cc-193">The normalized form of the URI maintains case, and percent-decodes (a "%" symbol followed by the two-digit hexadecimal representation) RFC 3986 unreserved characters.</span></span> <span data-ttu-id="d80cc-194">"?"、"#"、"/"、"*"、'”' (二重引用符) の各文字は、ファイル名やフォルダー名などのデータを示すパス内でパーセントエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-194">The characters "?", "#", "/", "*", and '”' (the double-quote character) must be percent-encoded in a path to represent data such as file or folder names.</span></span> <span data-ttu-id="d80cc-195">パーセントエンコードされたすべての文字は、取得前にデコードされます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-195">All percent-encoded characters are decoded before retrieval.</span></span> <span data-ttu-id="d80cc-196">したがって、Hello#World.html という名前のローカル ファイルを取得するには、この URI を使用します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-196">Thus, to retrieve a local file named Hello#World.html, use this URI.</span></span>

```xml
ms-appdata://local/Hello%23World.html
```

<span data-ttu-id="d80cc-197">最上位のパス セグメントのリソースと ID の取得は、ドットの正規化の後に処理されます (".././b/c")。</span><span class="sxs-lookup"><span data-stu-id="d80cc-197">Retrieval of the resource, and identification of the top level path segment, are handled after normalization of dots (".././b/c").</span></span> <span data-ttu-id="d80cc-198">したがって、予約済みフォルダーの外側で URI にドットを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-198">Therefore, URIs cannot dot themselves out of one of the reserved folders.</span></span> <span data-ttu-id="d80cc-199">そのため、次の URI は許可されません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-199">Thus, the following URI is not allowed.</span></span>

```xml
ms-appdata:///local/../hello/logo.png
```

<span data-ttu-id="d80cc-200">この URI は (冗長ですが) 許可されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-200">But this URI is allowed (albeit redundant).</span></span>

```xml
ms-appdata:///local/../roaming/logo.png
```

### <a name="query-ms-appdata"></a><span data-ttu-id="d80cc-201">クエリ (ms-appdata)</span><span class="sxs-lookup"><span data-stu-id="d80cc-201">Query (ms-appdata)</span></span>

<span data-ttu-id="d80cc-202">クエリ パラメーターは、リソースの取得時には無視されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-202">Query parameters are ignored during retrieval of resources.</span></span> <span data-ttu-id="d80cc-203">正規化されたクエリ パラメーターの形式では大文字と小文字が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-203">The normalized form of query parameters maintains case.</span></span> <span data-ttu-id="d80cc-204">クエリ パラメーターは、比較時には無視されません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-204">Query parameters are not ignored during comparison.</span></span>

## <a name="ms-resource"></a><span data-ttu-id="d80cc-205">ms-resource</span><span class="sxs-lookup"><span data-stu-id="d80cc-205">ms-resource</span></span>

<span data-ttu-id="d80cc-206">アプリのリソース ファイル (.resw) から読み込まれた文字列を参照するには、URI スキーム `ms-resource` を使用します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-206">Use the `ms-resource` URI scheme to refer to strings loaded from your app's Resources Files (.resw).</span></span> <span data-ttu-id="d80cc-207">リソース ファイルの例と詳しい情報については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](localize-strings-ui-manifest.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d80cc-207">For examples and more info about Resources Files, see [Localize strings in your UI and app package manifest](localize-strings-ui-manifest.md).</span></span>

### <a name="scheme-name-ms-resource"></a><span data-ttu-id="d80cc-208">スキーム名 (ms-resource)</span><span class="sxs-lookup"><span data-stu-id="d80cc-208">Scheme name (ms-resource)</span></span>

<span data-ttu-id="d80cc-209">URI スキーム名は、文字列 "ms-resource" です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-209">The URI scheme name is the string "ms-resource".</span></span>

```xml
ms-resource://
```

### <a name="authority-ms-resource"></a><span data-ttu-id="d80cc-210">機関 (ms-resource)</span><span class="sxs-lookup"><span data-stu-id="d80cc-210">Authority (ms-resource)</span></span>

<span data-ttu-id="d80cc-211">機関は、パッケージ リソース インデックス (PRI) 内で定義された最上位のリソース マップで、通常はパッケージ マニフェストで定義されたパッケージ ID 名に対応しています。</span><span class="sxs-lookup"><span data-stu-id="d80cc-211">The authority is the top-level resource map defined in the Package Resource Index (PRI), which typically corresponds to the package identity name that is defined in the package manifest.</span></span> <span data-ttu-id="d80cc-212">「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d80cc-212">See [Packaging apps](../packaging/index.md)).</span></span> <span data-ttu-id="d80cc-213">したがって、URI 形式と IRI (Internationalized Resource Identifier) 形式のどちらでも、パッケージ ID 名で許可されている文字のセットに制限されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-213">It is therefore limited in both the URI and IRI (Internationalized resource identifier) form to the set of characters allowed in a package identity name.</span></span> <span data-ttu-id="d80cc-214">パッケージ名は、現在動作しているアプリのパッケージ依存グラフ内のいずれかのパッケージの名前にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-214">The package name must be the name of one of the packages in the current running app's package dependency graph.</span></span>

```xml
ms-resource://Contoso.MyApp/
ms-resource://Microsoft.WinJS.1.0/
```

<span data-ttu-id="d80cc-215">機関に他の文字が使用されると、取得と比較の処理に失敗します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-215">If any other character appears in the authority, then retrieval and comparison fail.</span></span> <span data-ttu-id="d80cc-216">機関の既定値は、現在実行中のアプリのパッケージ名 (大文字と小文字の区別あり) です。</span><span class="sxs-lookup"><span data-stu-id="d80cc-216">The default value for the authority is the case-sensitive package name of the currently running app.</span></span>

```xml
ms-resource:///
```

<span data-ttu-id="d80cc-217">機関では大文字と小文字が区別され、正規化された形式で大文字と小文字が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-217">The authority is case sensitive, and the normalized form maintains its case.</span></span> <span data-ttu-id="d80cc-218">ただし、リソースの参照では大文字と小文字が区別されません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-218">Lookup of a resource, however, happens case-insensitively.</span></span>

### <a name="user-info-and-port-ms-resource"></a><span data-ttu-id="d80cc-219">ユーザー情報とポート (ms-resource)</span><span class="sxs-lookup"><span data-stu-id="d80cc-219">User info and port (ms-resource)</span></span>

<span data-ttu-id="d80cc-220">`ms-resource` スキームは、他の一般的なスキームとは異なり、ユーザー情報やポートのコンポーネントを定義しません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-220">The `ms-resource` scheme, unlike other popular schemes, does not define a user info or port component.</span></span> <span data-ttu-id="d80cc-221">"@" と ":" は機関の有効な値として許可されていないため、これらが含まれていると参照は失敗します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-221">Since "@" and ":" are not allowed as valid authority values, lookup will fail if they are included.</span></span> <span data-ttu-id="d80cc-222">以下の処理はそれぞれ失敗となります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-222">Each of the following fails.</span></span>

```xml
ms-resource://john@contoso.myapp/Resources/String1
ms-resource://john:password@contoso.myapp/Resources/String1
ms-resource://contoso.myapp:8080/Resources/String1
ms-resource://john:password@contoso.myapp:8080/Resources/String1
```

### <a name="path-ms-resource"></a><span data-ttu-id="d80cc-223">パス (ms-resource)</span><span class="sxs-lookup"><span data-stu-id="d80cc-223">Path (ms-resource)</span></span>

<span data-ttu-id="d80cc-224">パスは、[ResourceMap](/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceMap?branch=live) サブツリーとサブツリー内の [NamedResource](/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResourcebranch=live) の階層の場所を特定します (「[リソース管理システム](https://msdn.microsoft.com/library/windows/apps/jj552947)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="d80cc-224">The path identifies the hierarchical location of the [ResourceMap](/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceMap?branch=live) subtree (see [Resource Management System](https://msdn.microsoft.com/library/windows/apps/jj552947)) and the [NamedResource](/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResourcebranch=live) within it.</span></span> <span data-ttu-id="d80cc-225">これは通常、リソース ファイル (.resw) のファイル名 (拡張子を除く) と、ファイル内の文字列リソースの識別子に対応しています。</span><span class="sxs-lookup"><span data-stu-id="d80cc-225">Typically, this corresponds to the filename (excluding extension) of a Resources Files (.resw) and the identifier of a string resource within it.</span></span>

<span data-ttu-id="d80cc-226">例と詳しい情報については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](localize-strings-ui-manifest.md)」と「[言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート](tile-toast-language-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d80cc-226">For examples and more info, see [Localize strings in your UI and app package manifest](localize-strings-ui-manifest.md) and [Tile and toast notification support for language, scale, and high contrast](tile-toast-language-scale-contrast.md).</span></span>

<span data-ttu-id="d80cc-227">パス コンポーネント `ms-resource` では、一般的な URI と同様、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-227">The path component of `ms-resource` is, like generic URIs, case sensitive.</span></span> <span data-ttu-id="d80cc-228">ただし、基本的な取得では、*ignoreCase* を `true` に設定して、[CompareStringOrdinal](https://msdn.microsoft.com/library/windows/apps/br224628) を実行します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-228">However, when the underlying retrieval.does a [CompareStringOrdinal](https://msdn.microsoft.com/library/windows/apps/br224628) with *ignoreCase* set to `true`.</span></span>

<span data-ttu-id="d80cc-229">正規化された URI 形式では大文字と小文字が保持され、RFC 3986 の非予約文字がパーセントデコード ("%" 記号の後に 2 桁の 16 進数表現) されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-229">The normalized form of the URI maintains case, and percent-decodes (a "%" symbol followed by the two-digit hexadecimal representation) RFC 3986 unreserved characters.</span></span> <span data-ttu-id="d80cc-230">"?"、"#"、"/"、"*"、'”' (二重引用符) の各文字は、ファイル名やフォルダー名などのデータを示すパス内でパーセントエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d80cc-230">The characters "?", "#", "/", "*", and '”' (the double-quote character) must be percent-encoded in a path to represent data such as file or folder names.</span></span> <span data-ttu-id="d80cc-231">パーセントエンコードされたすべての文字は、取得前にデコードされます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-231">All percent-encoded characters are decoded before retrieval.</span></span> <span data-ttu-id="d80cc-232">このため、Hello#World.resw という名前のリソース ファイルから文字列リソースを取得するには、次の URI を使用します。</span><span class="sxs-lookup"><span data-stu-id="d80cc-232">Thus, to retrieve a string resource from a Resources File named Hello#World.resw, use this URI.</span></span>

```xml
ms-resource:///Hello%23World/String1
```

### <a name="query-ms-resource"></a><span data-ttu-id="d80cc-233">クエリ (ms-resource)</span><span class="sxs-lookup"><span data-stu-id="d80cc-233">Query (ms-resource)</span></span>

<span data-ttu-id="d80cc-234">クエリ パラメーターは、リソースの取得時には無視されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-234">Query parameters are ignored during retrieval of resources.</span></span> <span data-ttu-id="d80cc-235">正規化されたクエリ パラメーターの形式では大文字と小文字が保持されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-235">The normalized form of query parameters maintains case.</span></span> <span data-ttu-id="d80cc-236">クエリ パラメーターは、比較時には無視されません。</span><span class="sxs-lookup"><span data-stu-id="d80cc-236">Query parameters are not ignored during comparison.</span></span> <span data-ttu-id="d80cc-237">クエリ パラメーターは、大文字と小文字を区別して比較されます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-237">Query parameters are compared case-sensitively.</span></span>

<span data-ttu-id="d80cc-238">この URI 解析の上にレイヤー化される特定のコンポーネントの開発者は、適切と思われるクエリ パラメーターを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="d80cc-238">Developers of particular components layered above this URI parsing may choose to use the query parameters as they see fit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="d80cc-239">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d80cc-239">Related topics</span></span>

* [<span data-ttu-id="d80cc-240">Uniform Resource Identifier (URI): 一般的な構文</span><span class="sxs-lookup"><span data-stu-id="d80cc-240">Uniform Resource Identifier (URI): Generic Syntax</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=263444)
* [<span data-ttu-id="d80cc-241">アプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="d80cc-241">Packaging apps</span></span>](../packaging/index.md)
* [<span data-ttu-id="d80cc-242">XAML マークアップとコードから画像やその他のアセットを参照する</span><span class="sxs-lookup"><span data-stu-id="d80cc-242">Reference an image or other asset from XAML markup and code</span></span>](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code)
* [<span data-ttu-id="d80cc-243">設定と他のアプリ データを保存して取得する</span><span class="sxs-lookup"><span data-stu-id="d80cc-243">Store and retrieve settings and other app data</span></span>](../app-settings/store-and-retrieve-app-data.md)
* [<span data-ttu-id="d80cc-244">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="d80cc-244">Localize strings in your UI and app package manifest</span></span>](localize-strings-ui-manifest.md)
* [<span data-ttu-id="d80cc-245">リソース管理システム</span><span class="sxs-lookup"><span data-stu-id="d80cc-245">Resource Management System</span></span>](https://msdn.microsoft.com/library/windows/apps/jj552947)
* [<span data-ttu-id="d80cc-246">言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート</span><span class="sxs-lookup"><span data-stu-id="d80cc-246">Tile and toast notification support for language, scale, and high contrast</span></span>](tile-toast-language-scale-contrast.md)