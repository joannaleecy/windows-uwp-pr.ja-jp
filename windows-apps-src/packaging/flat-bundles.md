---
author: laurenhughes
title: フラット バンドル アプリ パッケージ
description: フラット バンドルを作成してアプリ パッケージへの参照を持つアプリの .appx パッケージ ファイルをバンドルする方法について説明します。
ms.author: lahugh
ms.date: 04/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, パッケージ化, パッケージ構成, フラット バンドル
ms.localizationpriority: medium
ms.openlocfilehash: 757f95a5f46bad6dbe650b4b552f3de486d84e1b
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1818435"
---
# <a name="flat-bundle-app-packages"></a><span data-ttu-id="4a4e2-104">フラット バンドル アプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="4a4e2-104">Flat bundle app packages</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="4a4e2-105">Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してフレット バンドルを使う承認を得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-105">If you intend to submit your app to the Store, you need to contact [Windows developer support](https://developer.microsoft.com/windows/support) for approval to use flat bundles.</span></span>

<span data-ttu-id="4a4e2-106">フラット バンドルは、アプリの .appx パッケージ ファイルをバンドルする改善された方法です。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-106">Flat bundles are an improved way to bundle your app’s .appx package files.</span></span> <span data-ttu-id="4a4e2-107">一般的な .appxbundle ファイルでは複数レベルのパッケージ構造が使用されるため、.appx パッケージ ファイルをバンドル内に含める必要がありますが、フラット バンドルではアプリ バンドルの外部に配置できるため、.appx パッケージ ファイルを参照するだけでこの必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-107">A typical .appxbundle file uses a multi-level packaging structure in which the .appx package files need to be contained within the bundle, flat bundles remove this need by only referencing the .appx package files, allowing them to be outside of the app bundle.</span></span> <span data-ttu-id="4a4e2-108">.appx パッケージ ファイルがバンドルに含まれなくなるため、並列処理できます。その結果、アップロード時間と公開にかかる時間が短縮され (各 .appx パッケージ ファイルを同時に処理できるため)、最終的に開発サイクルを早めることができます。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-108">Since the .appx package files are no longer contained in the bundle, they can be parallel processed, which results in reduced uploading time, faster publishing (since each .appx package file can be processed at the same time), and ultimately faster development iterations.</span></span>

![フラット バンドルの図](images/bundle-combined.png)

<span data-ttu-id="4a4e2-110">フラット バンドルの別の利点は、作成する必要があるパッケージが減ることです。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-110">Another benefit of flat bundles is the need to create less packages.</span></span> <span data-ttu-id="4a4e2-111">.appx パッケージ ファイルは参照されるだけのため、2 つのバージョン間でパッケージが変更されなかった場合、2 つのバージョンのアプリが同じパッケージ ファイルを参照できます。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-111">Since .appx package files are only referenced, two versions of the app can reference the same package file if the package did not change across the two versions.</span></span> <span data-ttu-id="4a4e2-112">この結果、次のバージョンのアプリのパッケージをビルドするとき、変更されたアプリ パッケージを作成するだけでよくなります。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-112">This allows you to have to create only the app packages that have changed when building the packages for the next version of your app.</span></span>
<span data-ttu-id="4a4e2-113">既定では、フラット バンドルはそれ自体と同じフォルダー内の .appx パッケージ ファイルを参照します。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-113">By default, the flat bundles will reference .appx package files within the same folder as itself.</span></span> <span data-ttu-id="4a4e2-114">ただし、この参照は他のパス (相対パス、ネットワーク共有、および http の場所) に変更できます。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-114">However, this reference can be changed to other paths (relative paths, network shares, and http locations).</span></span> <span data-ttu-id="4a4e2-115">これを行うには、フラット バンドルの作成時に **BundleManifest** を直接指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-115">To do this, you must directly provide a **BundleManifest** during the flat bundle creation.</span></span> 

## <a name="how-to-create-a-flat-bundle"></a><span data-ttu-id="4a4e2-116">フラット バンドルを作成する方法</span><span class="sxs-lookup"><span data-stu-id="4a4e2-116">How to create a flat bundle</span></span>

<span data-ttu-id="4a4e2-117">フラット バンドルは、MakeAppx.exe ツールを使うか、パッケージ レイアウトを使ってバンドルの構造を定義することにより作成できます。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-117">A flat bundle can be created using the MakeAppx.exe tool, or by using the packaging layout to define the structure of your bundle.</span></span>

### <a name="using-makeappxexe"></a><span data-ttu-id="4a4e2-118">MakeAppx.exe の使用</span><span class="sxs-lookup"><span data-stu-id="4a4e2-118">Using MakeAppx.exe</span></span>
<span data-ttu-id="4a4e2-119">MakeAppx.exe を使ってフラット バンドルを作成するには、通常どおり "MakeAppx.exe bundle" コマンドを使いますが、/fb スイッチを指定してフラットな .appxbundle ファイルを生成します (.appx パッケージのみを参照し、実際のペイロードは含まれないため、非常に小さくなります)。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-119">To create a flat bundle using MakeAppx.exe, use the “MakeAppx.exe bundle” command as usual but with the /fb switch to generate the flat .appxbundle file (which will be extremely small since it only references the .appx packages and does not contain any actual payloads).</span></span> 

<span data-ttu-id="4a4e2-120">コマンド構文の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-120">Here's an example of the command syntax:</span></span>

```syntax
MakeAppx bundle [options] /d <content directory> /fb <output flat bundle name>
```

<span data-ttu-id="4a4e2-121">MakeAppx.exe について詳しくは、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-121">For more information on using MakeAppx.exe, see [Create an app package with the MakeAppx.exe tool](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool).</span></span>

### <a name="using-packaging-layout"></a><span data-ttu-id="4a4e2-122">パッケージ レイアウトの使用</span><span class="sxs-lookup"><span data-stu-id="4a4e2-122">Using packaging layout</span></span>
<span data-ttu-id="4a4e2-123">または、パッキング レイアウトを使ってフラット バンドルを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-123">Alternatively, you can create a flat bundle using the packing layout.</span></span> <span data-ttu-id="4a4e2-124">これを行うには、アプリ バンドル マニフェストの **PackageFamily** 要素で **FlatBundle** 属性を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-124">To do this, set the **FlatBundle** attribute to **true** in the **PackageFamily** element of your app bundle manifest.</span></span> <span data-ttu-id="4a4e2-125">パッケージ レイアウトについて詳しくは、「[パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-125">To learn more about the packaging layout, see [Package creation with the packaging layout](packaging-layout.md).</span></span>

## <a name="how-to-deploy-a-flat-bundle"></a><span data-ttu-id="4a4e2-126">フラット バンドルを展開する方法</span><span class="sxs-lookup"><span data-stu-id="4a4e2-126">How to deploy a flat bundle</span></span> 
<span data-ttu-id="4a4e2-127">フラット バンドルを展開する前に、(アプリ バンドルに加えて) 各アプリ パッケージに同じ証明書で署名する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-127">Before a flat bundle can be deployed, each of the app packages (in addition to the app bundle) will need to be signed with the same certificate.</span></span> <span data-ttu-id="4a4e2-128">これは、アプリ パッケージ ファイル (.appx) がすべて独立したファイルになり、アプリ バンドル (.appxbundle) ファイルに含まれなくなったためです。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-128">This is because all of the app package files (.appx) are now independent files and are not contained within the app bundle (.appxbundle) file anymore.</span></span> <span data-ttu-id="4a4e2-129">パッケージが署名されたら、PowerShell で [Add-AppxPackage コマンドレット](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps)を使って .appxbundle ファイルをポイントし、アプリを展開します (アプリ バンドルが期待する場所にアプリ パッケージがあることを想定しています)。</span><span class="sxs-lookup"><span data-stu-id="4a4e2-129">Once the packages are signed, use the [Add-AppxPackage cmdlet](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) in PowerShell to point to the .appxbundle file and deploy the app (assuming app packages are where the app bundle expects them to be).</span></span> 