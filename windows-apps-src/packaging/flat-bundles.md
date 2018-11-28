---
title: フラット バンドル アプリ パッケージ
description: フラット バンドルを作成してアプリ パッケージへの参照を持つアプリの .appx パッケージ ファイルをバンドルする方法について説明します。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10, パッケージ化, パッケージ構成, フラット バンドル
ms.localizationpriority: medium
ms.openlocfilehash: b7066b7f2e5bd72ebee3169e03c7940b6fef4dba
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7851153"
---
# <a name="flat-bundle-app-packages"></a><span data-ttu-id="78a1d-104">フラット バンドル アプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="78a1d-104">Flat bundle app packages</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="78a1d-105">Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してフレット バンドルを使う承認を得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="78a1d-105">If you intend to submit your app to the Store, you need to contact [Windows developer support](https://developer.microsoft.com/windows/support) for approval to use flat bundles.</span></span>

<span data-ttu-id="78a1d-106">フラット バンドルは、アプリのパッケージ ファイルをバンドルする改善された方法です。</span><span class="sxs-lookup"><span data-stu-id="78a1d-106">Flat bundles are an improved way to bundle your app’s package files.</span></span> <span data-ttu-id="78a1d-107">アプリ バンドル ファイルが、バンドル内に含めるアプリのパッケージ ファイルが必要な複数レベルのパッケージ構造を使用する一般的な Windows、フラット バンドルはアプリ バンドルの外部にできるように、アプリのパッケージ ファイルを参照するだけでこの必要性を削除します。</span><span class="sxs-lookup"><span data-stu-id="78a1d-107">A typical Windows app bundle file uses a multi-level packaging structure in which the app package files need to be contained within the bundle, flat bundles remove this need by only referencing the app package files, allowing them to be outside of the app bundle.</span></span> <span data-ttu-id="78a1d-108">アプリのパッケージ ファイルがバンドルには含まれなく、ためにできる並列処理され、その結果のアップロード時間、高速な公開 (各アプリのパッケージ ファイルは、同時に処理できることができます) ため、最終的に開発繰り返しできません。</span><span class="sxs-lookup"><span data-stu-id="78a1d-108">Since the app package files are no longer contained in the bundle, they can be parallel processed, which results in reduced uploading time, faster publishing (since each app package file can be processed at the same time), and ultimately faster development iterations.</span></span>

![フラット バンドルの図](images/bundle-combined.png)

<span data-ttu-id="78a1d-110">フラット バンドルの別の利点は、作成する必要があるパッケージが減ることです。</span><span class="sxs-lookup"><span data-stu-id="78a1d-110">Another benefit of flat bundles is the need to create less packages.</span></span> <span data-ttu-id="78a1d-111">アプリ パッケージ ファイルが参照されるだけのため、2 つのバージョンのアプリはパッケージが 2 つのバージョン間で変更されなかった場合、同じパッケージ ファイルを参照できます。</span><span class="sxs-lookup"><span data-stu-id="78a1d-111">Since app package files are only referenced, two versions of the app can reference the same package file if the package did not change across the two versions.</span></span> <span data-ttu-id="78a1d-112">この結果、次のバージョンのアプリのパッケージをビルドするとき、変更されたアプリ パッケージを作成するだけでよくなります。</span><span class="sxs-lookup"><span data-stu-id="78a1d-112">This allows you to have to create only the app packages that have changed when building the packages for the next version of your app.</span></span>
<span data-ttu-id="78a1d-113">既定では、フラット バンドルはそれ自体と同じフォルダー内のアプリ パッケージ ファイルを参照します。</span><span class="sxs-lookup"><span data-stu-id="78a1d-113">By default, the flat bundles will reference app package files within the same folder as itself.</span></span> <span data-ttu-id="78a1d-114">ただし、この参照は他のパス (相対パス、ネットワーク共有、および http の場所) に変更できます。</span><span class="sxs-lookup"><span data-stu-id="78a1d-114">However, this reference can be changed to other paths (relative paths, network shares, and http locations).</span></span> <span data-ttu-id="78a1d-115">これを行うには、フラット バンドルの作成時に **BundleManifest** を直接指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="78a1d-115">To do this, you must directly provide a **BundleManifest** during the flat bundle creation.</span></span> 

## <a name="how-to-create-a-flat-bundle"></a><span data-ttu-id="78a1d-116">フラット バンドルを作成する方法</span><span class="sxs-lookup"><span data-stu-id="78a1d-116">How to create a flat bundle</span></span>

<span data-ttu-id="78a1d-117">フラット バンドルは、MakeAppx.exe ツールを使うか、パッケージ レイアウトを使ってバンドルの構造を定義することにより作成できます。</span><span class="sxs-lookup"><span data-stu-id="78a1d-117">A flat bundle can be created using the MakeAppx.exe tool, or by using the packaging layout to define the structure of your bundle.</span></span>

### <a name="using-makeappxexe"></a><span data-ttu-id="78a1d-118">MakeAppx.exe の使用</span><span class="sxs-lookup"><span data-stu-id="78a1d-118">Using MakeAppx.exe</span></span>
<span data-ttu-id="78a1d-119">MakeAppx.exe を使ってフラット バンドルを作成するには、コマンドを使って"MakeAppx.exe bundle"通常どおりですが、/fb スイッチ、ファイルを生成、フラット アプリ バンドル (のみにアプリのパッケージ ファイルを参照し、実際のペイロードが含まれていないために、非常に小さくなります).</span><span class="sxs-lookup"><span data-stu-id="78a1d-119">To create a flat bundle using MakeAppx.exe, use the “MakeAppx.exe bundle” command as usual but with the /fb switch to generate the flat app bundle file (which will be extremely small since it only references the app package files and does not contain any actual payloads).</span></span> 

<span data-ttu-id="78a1d-120">コマンド構文の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="78a1d-120">Here's an example of the command syntax:</span></span>

```syntax
MakeAppx bundle [options] /d <content directory> /fb /p <output flat bundle name>
```

<span data-ttu-id="78a1d-121">MakeAppx.exe について詳しくは、「[MakeAppx.exe ツールを使ったアプリ パッケージの作成](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78a1d-121">For more information on using MakeAppx.exe, see [Create an app package with the MakeAppx.exe tool](https://docs.microsoft.com/windows/uwp/packaging/create-app-package-with-makeappx-tool).</span></span>

### <a name="using-packaging-layout"></a><span data-ttu-id="78a1d-122">パッケージ レイアウトの使用</span><span class="sxs-lookup"><span data-stu-id="78a1d-122">Using packaging layout</span></span>
<span data-ttu-id="78a1d-123">または、パッキング レイアウトを使ってフラット バンドルを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="78a1d-123">Alternatively, you can create a flat bundle using the packing layout.</span></span> <span data-ttu-id="78a1d-124">これを行うには、アプリ バンドル マニフェストの **PackageFamily** 要素で **FlatBundle** 属性を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="78a1d-124">To do this, set the **FlatBundle** attribute to **true** in the **PackageFamily** element of your app bundle manifest.</span></span> <span data-ttu-id="78a1d-125">パッケージ レイアウトについて詳しくは、「[パッケージ レイアウトを使ったパッケージの作成](packaging-layout.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78a1d-125">To learn more about the packaging layout, see [Package creation with the packaging layout](packaging-layout.md).</span></span>

## <a name="how-to-deploy-a-flat-bundle"></a><span data-ttu-id="78a1d-126">フラット バンドルを展開する方法</span><span class="sxs-lookup"><span data-stu-id="78a1d-126">How to deploy a flat bundle</span></span> 
<span data-ttu-id="78a1d-127">フラット バンドルを展開する前に、(アプリ バンドルに加えて) 各アプリ パッケージに同じ証明書で署名する必要があります。</span><span class="sxs-lookup"><span data-stu-id="78a1d-127">Before a flat bundle can be deployed, each of the app packages (in addition to the app bundle) will need to be signed with the same certificate.</span></span> <span data-ttu-id="78a1d-128">これは、すべてのアプリ パッケージ ファイル (.appx/.msix) が独立したファイルになりできなくなったアプリ バンドル (.appxbundle/.msixbundle) ファイルに含まれないためです。</span><span class="sxs-lookup"><span data-stu-id="78a1d-128">This is because all of the app package files (.appx/.msix) are now independent files and are not contained within the app bundle (.appxbundle/.msixbundle) file anymore.</span></span> <span data-ttu-id="78a1d-129">パッケージが署名されたら、アプリ バンドル ファイルをポイントし、アプリを展開します (アプリ パッケージには、アプリ バンドルを想定してそれらを想定) PowerShell の[Add-appxpackage コマンドレット](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps)を使用します。</span><span class="sxs-lookup"><span data-stu-id="78a1d-129">Once the packages are signed, use the [Add-AppxPackage cmdlet](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) in PowerShell to point to the app bundle file and deploy the app (assuming app packages are where the app bundle expects them to be).</span></span> 