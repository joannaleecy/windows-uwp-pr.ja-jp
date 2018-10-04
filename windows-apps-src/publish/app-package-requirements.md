---
author: jnHs
Description: Follow these guidelines to prepare your app's packages for submission to the Microsoft Store.
title: アプリ パッケージの要件
ms.assetid: 651B82BA-9D0C-45AC-8997-88CD93DC903C
ms.author: wdg-dev-content
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, パッケージ要件, パッケージ, パッケージ形式, サポートされているバージョン, 提出
ms.localizationpriority: medium
ms.openlocfilehash: f3e294fdf5a9b2d98f09d839fa62499b556de3a5
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4355757"
---
# <a name="app-package-requirements"></a><span data-ttu-id="9a3ac-103">アプリ パッケージの要件</span><span class="sxs-lookup"><span data-stu-id="9a3ac-103">App package requirements</span></span>

<span data-ttu-id="9a3ac-104">Microsoft Store に申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-104">Follow these guidelines to prepare your app's packages for submission to the Microsoft Store.</span></span>

## <a name="before-you-build-your-apps-package-for-the-microsoft-store"></a><span data-ttu-id="9a3ac-105">Microsoft Store に向けてアプリのパッケージを構築する前に</span><span class="sxs-lookup"><span data-stu-id="9a3ac-105">Before you build your app's package for the Microsoft Store</span></span>

<span data-ttu-id="9a3ac-106">[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md)したことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-106">Make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md).</span></span> <span data-ttu-id="9a3ac-107">また、さまざまな種類のハードウェアでアプリをテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-107">We also recommend that you test your app on different types of hardware.</span></span> <span data-ttu-id="9a3ac-108">アプリが認定され、Microsoft Store から入手できるようになるまでの間、アプリをインストールして実行できるのは、開発者用ライセンスを持つコンピューター上のみになります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-108">Note that until we certify your app and make it available from the Microsoft Store, it can only be installed and run on computers that have developer licenses.</span></span>

## <a name="building-the-app-package-using-microsoft-visual-studio"></a><span data-ttu-id="9a3ac-109">Microsoft Visual Studio を使ったアプリ パッケージのビルド</span><span class="sxs-lookup"><span data-stu-id="9a3ac-109">Building the app package using Microsoft Visual Studio</span></span>

<span data-ttu-id="9a3ac-110">開発環境として Microsoft Visual Studio を使っている場合は、アプリ パッケージを迅速かつ簡単に作成するための組み込みツールが既に用意されています。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-110">If you're using Microsoft Visual Studio as your development environment, you already have built-in tools that make creating an app package a quick and easy process.</span></span> <span data-ttu-id="9a3ac-111">詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-111">For more info, see [Packaging apps](../packaging/index.md).</span></span>

> [!NOTE]
> <span data-ttu-id="9a3ac-112">すべてのファイル名に ANSI を使っていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-112">Be sure that all your filenames use ANSI.</span></span> 

<span data-ttu-id="9a3ac-113">Visual Studio でパッケージを作るときは、必ず、開発者アカウントに関連付けられている同じアカウントでサインインしてください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-113">When you create your package in Visual Studio, make sure you are signed in with the same account associated with your developer account.</span></span> <span data-ttu-id="9a3ac-114">パッケージ マニフェストの一部には、お使いのアカウントに関連する固有の詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-114">Some parts of the package manifest have specific details related to your account.</span></span> <span data-ttu-id="9a3ac-115">この情報は自動的に検出されて追加されます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-115">This info is detected and added automatically.</span></span> <span data-ttu-id="9a3ac-116">マニフェストにこの追加情報が追加されていない場合、パッケージのアップロードでエラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-116">Without the additional information added to the manifest, you may encounter package upload failures.</span></span> 

<span data-ttu-id="9a3ac-117">アプリの UWP パッケージを作成する場合、Visual Studio は、.msix または appx ファイル、または .msixupload または .appxupload ファイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-117">When you build your app's UWP packages, Visual Studio can create an .msix or appx file, or a .msixupload or .appxupload file.</span></span> <span data-ttu-id="9a3ac-118">UWP アプリでは、常に[[パッケージ](upload-app-packages.md)] ページで、.msixupload または .appxupload ファイルをアップロードすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-118">For UWP apps, we recommend that you always upload the .msixupload or .appxupload file in the [Packages](upload-app-packages.md) page.</span></span> <span data-ttu-id="9a3ac-119">Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[Visual Studio での UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-119">For more info about packaging UWP apps for the Store, see [Package a UWP app with Visual Studio](../packaging/packaging-uwp-apps.md).</span></span>

<span data-ttu-id="9a3ac-120">アプリのパッケージに、信頼された証明機関が発行する証明書で署名する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-120">Your app's packages don't have to be signed with a certificate rooted in a trusted certificate authority.</span></span>


### <a name="app-bundles"></a><span data-ttu-id="9a3ac-121">アプリ バンドル</span><span class="sxs-lookup"><span data-stu-id="9a3ac-121">App bundles</span></span>

<span data-ttu-id="9a3ac-122">UWP アプリでは、Visual Studio は、アプリ バンドル (.msixbundle または .appxbundle)、ユーザーがダウンロードするアプリのサイズを小さくを生成できます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-122">For UWP apps, Visual Studio can generate an app bundle (.msixbundle or .appxbundle) to reduce the size of the app that users download.</span></span> <span data-ttu-id="9a3ac-123">その利便性が発揮されるのは、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースを定義した場合などです。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-123">This can be helpful if you've defined language-specific assets, a variety of image-scale assets, or resources that apply to specific versions of Microsoft DirectX.</span></span>

> [!NOTE]
> <span data-ttu-id="9a3ac-124">1 つのアプリ バンドルには、すべてのアーキテクチャ用のパッケージを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-124">One app bundle can contain your packages for all architectures.</span></span>

<span data-ttu-id="9a3ac-125">アプリ バンドルが使われている場合、ユーザーは、自分に関係したファイルだけをダウンロードすればよく、すべてのリソースをダウンロードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-125">With an app bundle, a user will only download the relevant files, rather than all possible resources.</span></span> <span data-ttu-id="9a3ac-126">アプリ バンドルについて詳しくは、「[アプリのパッケージ化](../packaging/index.md)」と「[Visual Studio で UWP アプリをパッケージ化する](../packaging/packaging-uwp-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-126">For more info about app bundles, see [Packaging apps](../packaging/index.md) and [Package a UWP app with Visual Studio](../packaging/packaging-uwp-apps.md).</span></span>


## <a name="building-the-app-package-manually"></a><span data-ttu-id="9a3ac-127">手動によるアプリ パッケージのビルド</span><span class="sxs-lookup"><span data-stu-id="9a3ac-127">Building the app package manually</span></span>

<span data-ttu-id="9a3ac-128">パッケージの作成に Visual Studio を使わない場合は、[パッケージ マニフェストを手動で作成](https://docs.microsoft.com/uwp/schemas/appxpackage/how-to-create-a-package-manifest-manually) する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-128">If you don't use Visual Studio to create your package, you must [create your package manifest manually](https://docs.microsoft.com/uwp/schemas/appxpackage/how-to-create-a-package-manifest-manually).</span></span>

<span data-ttu-id="9a3ac-129">マニフェストの詳細や要件については、[アプリ パッケージ マニフェスト](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest) に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-129">Be sure to review the [App package manifest](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest) documentation for complete manifest details and requirements.</span></span> <span data-ttu-id="9a3ac-130">認定に合格するには、マニフェストがパッケージ マニフェスト スキーマに従っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-130">Your manifest must follow the package manifest schema in order to pass certification.</span></span>

<span data-ttu-id="9a3ac-131">マニフェストには、アカウントとアプリに関するいくらかの具体的な情報を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-131">Your manifest must include some specific info about your account and your app.</span></span> <span data-ttu-id="9a3ac-132">この情報は、ダッシュボードにあるアプリの概要ページの [**アプリの管理**] セクションで [アプリの ID の詳細情報を表示する](view-app-identity-details.md) ことで確認できます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-132">You can find this info by looking at [View app identity details](view-app-identity-details.md) in the **App management** section of your app's overview page in the dashboard.</span></span>

> [!NOTE]
> <span data-ttu-id="9a3ac-133">マニフェスト内の値は、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-133">Values in the manifest are case-sensitive.</span></span> <span data-ttu-id="9a3ac-134">スペースや句読点なども一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-134">Spaces and other punctuation must also match.</span></span> <span data-ttu-id="9a3ac-135">注意して入力し、間違いがないか確認してください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-135">Enter the values carefully and review them to ensure that they are correct.</span></span>


<span data-ttu-id="9a3ac-136">アプリ バンドル (.msixbundle または .appxbundle) は、さまざまなマニフェストを使用します。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-136">App bundles (.msixbundle or .appxbundle) use a different manifest.</span></span> <span data-ttu-id="9a3ac-137">アプリ バンドル マニフェストの詳細や要件については、[バンドル マニフェスト](https://docs.microsoft.com/uwp/schemas/bundlemanifestschema/bundle-manifest) に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-137">Review the [Bundle manifest](https://docs.microsoft.com/uwp/schemas/bundlemanifestschema/bundle-manifest) documentation for the details and requirements for app bundle manifests.</span></span> <span data-ttu-id="9a3ac-138">注 .msixbundle または .appxbundle では、それぞれのマニフェスト含まれているパッケージには、同じ[Id](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity)要素の**ProcessorArchitecture**属性を除くの属性と要素を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-138">Note that in a .msixbundle or .appxbundle, the manifest of each included package must use the same elements and attributes, except for the **ProcessorArchitecture** attribute of the [Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) element.</span></span>

> [!TIP]
> <span data-ttu-id="9a3ac-139">必ず、[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)を実行してから、パッケージを提出してください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-139">Be sure to run the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit your packages.</span></span> <span data-ttu-id="9a3ac-140">これによって、認定や提出の失敗の原因となる可能性がある問題がマニフェストに含まれているかどうかを判断できます。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-140">This can you help determine if your manifest has any problems that might cause certification or submission failures.</span></span>


## <a name="package-format-requirements"></a><span data-ttu-id="9a3ac-141">パッケージの形式の要件</span><span class="sxs-lookup"><span data-stu-id="9a3ac-141">Package format requirements</span></span>

<span data-ttu-id="9a3ac-142">アプリのパッケージは、次の要件に準拠している必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-142">Your app’s packages must comply with these requirements.</span></span>

| <span data-ttu-id="9a3ac-143">アプリ パッケージの性質</span><span class="sxs-lookup"><span data-stu-id="9a3ac-143">App package property</span></span> | <span data-ttu-id="9a3ac-144">要件</span><span class="sxs-lookup"><span data-stu-id="9a3ac-144">Requirement</span></span>                                                          |
|----------------------|----------------------------------------------------------------------|
| <span data-ttu-id="9a3ac-145">パッケージのサイズ</span><span class="sxs-lookup"><span data-stu-id="9a3ac-145">Package size</span></span>         | <span data-ttu-id="9a3ac-146">.msixbundle または .appxbundle: バンドルあたり最大 25 GB</span><span class="sxs-lookup"><span data-stu-id="9a3ac-146">.msixbundle or .appxbundle: 25 GB maximum per bundle</span></span> <br><span data-ttu-id="9a3ac-147">Windows 10時 25分を対象とするパッケージを .msix または .appx パッケージあたり最大 GB</span><span class="sxs-lookup"><span data-stu-id="9a3ac-147">.msix or .appx packages targeting Windows 10: 25 GB maximum per package</span></span><br><span data-ttu-id="9a3ac-148">Windows 8.1 を対象とする .appx パッケージ: パッケージあたり最大 8 GB</span><span class="sxs-lookup"><span data-stu-id="9a3ac-148">.appx packages targeting Windows 8.1: 8 GB maximum per package</span></span> <br> <span data-ttu-id="9a3ac-149">Windows 8 を対象とする .appx パッケージ: パッケージあたり最大 2 GB</span><span class="sxs-lookup"><span data-stu-id="9a3ac-149">.appx packages targeting Windows 8: 2 GB maximum per package</span></span> <br> <span data-ttu-id="9a3ac-150">Windows Phone 8.1 を対象とする .appx パッケージ: パッケージあたり最大 4 GB</span><span class="sxs-lookup"><span data-stu-id="9a3ac-150">.appx packages targeting Windows Phone 8.1: 4 GB maximum per package</span></span> <br> <span data-ttu-id="9a3ac-151">.xap パッケージ: パッケージあたり最大 1 GB</span><span class="sxs-lookup"><span data-stu-id="9a3ac-151">.xap packages: 1 GB maximum per package</span></span>                                                                           |
| <span data-ttu-id="9a3ac-152">ブロック マップ ハッシュ</span><span class="sxs-lookup"><span data-stu-id="9a3ac-152">Block map hashes</span></span>     | <span data-ttu-id="9a3ac-153">SHA2-256 アルゴリズム</span><span class="sxs-lookup"><span data-stu-id="9a3ac-153">SHA2-256 algorithm</span></span>                                                   |


## <a name="supported-versions"></a><span data-ttu-id="9a3ac-154">サポートされているバージョン</span><span class="sxs-lookup"><span data-stu-id="9a3ac-154">Supported versions</span></span>

<span data-ttu-id="9a3ac-155">UWP アプリの場合、すべてのパッケージは Microsoft Store によりサポートされている Windows 10 のバージョンをターゲットとする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-155">For UWP apps, all packages must target a version of Windows 10 supported by the Store.</span></span> <span data-ttu-id="9a3ac-156">パッケージがサポートするバージョンは、アプリ マニフェストの [TargetDeviceFamily](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-targetdevicefamily) 要素の **MinVersion** 属性と **MaxVersionTested** 属性で指定されています。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-156">The versions your package supports must be indicated in the **MinVersion** and **MaxVersionTested** attributes of the [TargetDeviceFamily](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-targetdevicefamily) element of the app manifest.</span></span>

<span data-ttu-id="9a3ac-157">現時点でサポートされているバージョンの範囲は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-157">The versions currently supported range from:</span></span> 
- <span data-ttu-id="9a3ac-158">最小: 10.0.10240.0</span><span class="sxs-lookup"><span data-stu-id="9a3ac-158">Minimum: 10.0.10240.0</span></span>
- <span data-ttu-id="9a3ac-159">最大: 10.0.17763.1</span><span class="sxs-lookup"><span data-stu-id="9a3ac-159">Maximum: 10.0.17763.1</span></span>


## <a name="storemanifest-xml-file"></a><span data-ttu-id="9a3ac-160">StoreManifest XML ファイル</span><span class="sxs-lookup"><span data-stu-id="9a3ac-160">StoreManifest XML file</span></span>

<span data-ttu-id="9a3ac-161">StoreManifest.xml は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-161">StoreManifest.xml is an optional configuration file that may be included in app packages.</span></span> <span data-ttu-id="9a3ac-162">その目的は、Microsoft Store デバイス アプリとしてアプリを宣言する機能や、パッケージ マニフェストの対象外となるデバイスに適用される要件を宣言する機能などを有効にすることです。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-162">Its purpose is to enable features, such as declaring your app as a Microsoft Store device app or declaring requirements that a package depends on to be applicable to a device, that the package manifest does not cover.</span></span> <span data-ttu-id="9a3ac-163">使用する場合、StoreManifest.xml はアプリ パッケージを使って送信され、アプリのメイン プロジェクトのルート フォルダーにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-163">If used, StoreManifest.xml is submitted with the app package and must be in the root folder of your app's main project.</span></span> <span data-ttu-id="9a3ac-164">詳しくは、「[StoreManifest スキーマ](https://docs.microsoft.com/uwp/schemas/storemanifest/store-manifest-schema-portal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9a3ac-164">For more info, see [StoreManifest schema](https://docs.microsoft.com/uwp/schemas/storemanifest/store-manifest-schema-portal).</span></span>

 

 




