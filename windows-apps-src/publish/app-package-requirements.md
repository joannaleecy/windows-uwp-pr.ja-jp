---
author: jnHs
Description: "Windows ストアに申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。"
title: "アプリ パッケージの要件"
ms.assetid: 651B82BA-9D0C-45AC-8997-88CD93DC903C
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 39926699a81ce6882a46f4ec89b863d6147717dd
ms.sourcegitcommit: bfa61aae632cca0c68dbfb0168424d38fd607f84
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/31/2017
---
# <a name="app-package-requirements"></a><span data-ttu-id="8b346-104">アプリ パッケージの要件</span><span class="sxs-lookup"><span data-stu-id="8b346-104">App package requirements</span></span>

<span data-ttu-id="8b346-105">Windows ストアに申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。</span><span class="sxs-lookup"><span data-stu-id="8b346-105">Follow these guidelines to prepare your app's packages for submission to the Windows Store.</span></span>

## <a name="before-you-build-your-apps-package-for-the-windows-store"></a><span data-ttu-id="8b346-106">Windows ストアに向けてアプリのパッケージを構築する前に</span><span class="sxs-lookup"><span data-stu-id="8b346-106">Before you build your app's package for the Windows Store</span></span>

<span data-ttu-id="8b346-107">[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md) したことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="8b346-107">Make sure to [test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md).</span></span> <span data-ttu-id="8b346-108">また、さまざまな種類のハードウェアでアプリをテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8b346-108">We also recommend that you test your app on different types of hardware.</span></span> <span data-ttu-id="8b346-109">アプリが認定され、Windows ストアから入手できるようになるまでの間、アプリをインストールして実行できるのは、開発者用ライセンスを持つコンピューター上のみになります。</span><span class="sxs-lookup"><span data-stu-id="8b346-109">Note that until we certify your app and make it available from the Windows Store, it can only be installed and run on computers that have developer licenses.</span></span>

## <a name="building-the-app-package-using-microsoft-visual-studio"></a><span data-ttu-id="8b346-110">Microsoft Visual Studio を使ったアプリ パッケージのビルド</span><span class="sxs-lookup"><span data-stu-id="8b346-110">Building the app package using Microsoft Visual Studio</span></span>

<span data-ttu-id="8b346-111">開発環境として Microsoft Visual Studio を使っている場合は、アプリ パッケージを迅速かつ簡単に作成するための組み込みツールが既に用意されています。</span><span class="sxs-lookup"><span data-stu-id="8b346-111">If you're using Microsoft Visual Studio as your development environment, you already have built-in tools that make creating an app package a quick and easy process.</span></span> <span data-ttu-id="8b346-112">詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b346-112">For more info, see [Packaging apps](../packaging/index.md).</span></span>

> [!NOTE]
> <span data-ttu-id="8b346-113">すべてのファイル名に ANSI を使っていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="8b346-113">Be sure that all your filenames use ANSI.</span></span> 

<span data-ttu-id="8b346-114">Visual Studio でパッケージを作るときは、必ず、開発者アカウントに関連付けられている同じアカウントでサインインしてください。</span><span class="sxs-lookup"><span data-stu-id="8b346-114">When you create your package in Visual Studio, make sure you are signed in with the same account associated with your developer account.</span></span> <span data-ttu-id="8b346-115">パッケージ マニフェストの一部には、お使いのアカウントに関連する固有の詳細情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="8b346-115">Some parts of the package manifest have specific details related to your account.</span></span> <span data-ttu-id="8b346-116">この情報は自動的に検出されて追加されます。</span><span class="sxs-lookup"><span data-stu-id="8b346-116">This info is detected and added automatically.</span></span> <span data-ttu-id="8b346-117">マニフェストにこの追加情報が追加されていない場合、パッケージのアップロードでエラーが発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-117">Without the additional information added to the manifest, you may encounter package upload failures.</span></span> 

<span data-ttu-id="8b346-118">アプリのパッケージをビルドする場合、Visual Studio では .appx ファイルまたは .appxupload ファイル (または、Windows Phone 8.1 以前の場合は .xap ファイル) を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="8b346-118">When you build your app's packages, Visual Studio can create an .appx file or an .appxupload file (or a .xap file for Windows Phone 8.1 and earlier).</span></span> <span data-ttu-id="8b346-119">Windows 10 を対象とするアプリの場合は、常に .appxupload ファイルを [パッケージ](upload-app-packages.md) ページにアップロードします。</span><span class="sxs-lookup"><span data-stu-id="8b346-119">For apps that target Windows 10, always upload the .appxupload file in the [Packages](upload-app-packages.md) page.</span></span> <span data-ttu-id="8b346-120">ストア用の UWP アプリのパッケージ化について詳しくは、「[Windows 10 用ユニバーサル Windows アプリのパッケージ化](http://go.microsoft.com/fwlink/p/?LinkId=620193 )」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b346-120">For more info about packaging UWP apps for the Store, see [Packaging Universal Windows apps for Windows 10](http://go.microsoft.com/fwlink/p/?LinkId=620193 ).</span></span>

<span data-ttu-id="8b346-121">アプリのパッケージに、信頼された証明機関が発行する証明書で署名する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8b346-121">Your app's packages don't have to be signed with a certificate rooted in a trusted certificate authority.</span></span>


### <a name="app-bundles"></a><span data-ttu-id="8b346-122">アプリ バンドル</span><span class="sxs-lookup"><span data-stu-id="8b346-122">App bundles</span></span>

<span data-ttu-id="8b346-123">アプリの対象が Windows 8.1、Windows Phone 8.1、およびそれ以降である場合は、Visual Studio でアプリ バンドル (.appxbundle) を生成することによって、ユーザーがダウンロードするアプリのサイズを小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="8b346-123">For apps that target Windows 8.1, Windows Phone 8.1, and later, Visual Studio can generate an app bundle (.appxbundle) to reduce the size of the app that users download.</span></span> <span data-ttu-id="8b346-124">その利便性が発揮されるのは、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースを定義した場合などです。</span><span class="sxs-lookup"><span data-stu-id="8b346-124">This can be helpful if you've defined language-specific assets, a variety of image-scale assets, or resources that apply to specific versions of Microsoft DirectX.</span></span>

> [!NOTE]
> <span data-ttu-id="8b346-125">1 つのアプリ バンドルには、すべてのアーキテクチャ用のパッケージを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="8b346-125">One app bundle can contain your packages for all architectures.</span></span> <span data-ttu-id="8b346-126">対象 OS ごとにバンドルを 1 つだけ申請する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-126">You should submit only one bundle for each targeted OS.</span></span>

<span data-ttu-id="8b346-127">アプリ バンドルが使われている場合、ユーザーは、自分に関係したファイルだけをダウンロードすればよく、すべてのリソースをダウンロードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8b346-127">With an app bundle, a user will only download the relevant files, rather than all possible resources.</span></span> <span data-ttu-id="8b346-128">アプリ バンドルについて詳しくは、「[アプリのパッケージ化](../packaging/index.md)」と「[Visual Studio で UWP アプリをパッケージ化する](../packaging/packaging-uwp-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b346-128">For more info about app bundles, see [Packaging apps](../packaging/index.md) and [Package a UWP app with Visual Studio](../packaging/packaging-uwp-apps.md).</span></span>


## <a name="building-the-app-package-manually"></a><span data-ttu-id="8b346-129">手動によるアプリ パッケージのビルド</span><span class="sxs-lookup"><span data-stu-id="8b346-129">Building the app package manually</span></span>

<span data-ttu-id="8b346-130">パッケージの作成に Visual Studio を使わない場合は、[パッケージ マニフェストを手動で作成](https://msdn.microsoft.com/library/windows/apps/br211476) する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-130">If you don't use Visual Studio to create your package, you must [create your package manifest manually](https://msdn.microsoft.com/library/windows/apps/br211476).</span></span>

<span data-ttu-id="8b346-131">マニフェストの詳細や要件については、[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474) に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b346-131">Be sure to review the [App package manifest](https://msdn.microsoft.com/library/windows/apps/br211474) documentation for complete manifest details and requirements.</span></span> <span data-ttu-id="8b346-132">認定に合格するには、マニフェストがパッケージ マニフェスト スキーマに従っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-132">Your manifest must follow the package manifest schema in order to pass certification.</span></span>

<span data-ttu-id="8b346-133">マニフェストには、アカウントとアプリに関するいくらかの具体的な情報を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-133">Your manifest must include some specific info about your account and your app.</span></span> <span data-ttu-id="8b346-134">この情報は、ダッシュボードにあるアプリの概要ページの [**アプリの管理**] セクションで[アプリの ID の詳細情報を表示する](view-app-identity-details.md)ことで確認できます。</span><span class="sxs-lookup"><span data-stu-id="8b346-134">You can find this info by looking at [View app identity details](view-app-identity-details.md) in the **App management** section of your app's overview page in the dashboard.</span></span>

> [!NOTE]
> <span data-ttu-id="8b346-135">マニフェスト内の値は、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="8b346-135">Values in the manifest are case-sensitive.</span></span> <span data-ttu-id="8b346-136">スペースや句読点なども一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-136">Spaces and other punctuation must also match.</span></span> <span data-ttu-id="8b346-137">注意して入力し、間違いがないか確認してください。</span><span class="sxs-lookup"><span data-stu-id="8b346-137">Enter the values carefully and review them to ensure that they are correct.</span></span>


<span data-ttu-id="8b346-138">アプリ バンドルには、特別なマニフェストが使われます。</span><span class="sxs-lookup"><span data-stu-id="8b346-138">App bundles use a different manifest.</span></span> <span data-ttu-id="8b346-139">アプリ バンドル マニフェストの詳細や要件については、[バンドル マニフェスト](https://docs.microsoft.com/uwp/schemas/bundlemanifestschema/bundle-manifest)に関するドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b346-139">Review the [Bundle manifest](https://docs.microsoft.com/uwp/schemas/bundlemanifestschema/bundle-manifest) documentation for the details and requirements for app bundle manifests.</span></span>

> [!TIP]
> <span data-ttu-id="8b346-140">必ず、[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)を実行してから、パッケージを提出してください。</span><span class="sxs-lookup"><span data-stu-id="8b346-140">Be sure to run the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit your packages.</span></span> <span data-ttu-id="8b346-141">これによって、認定や提出の失敗の原因となる可能性がある問題がマニフェストに含まれているかどうかを判断できます。</span><span class="sxs-lookup"><span data-stu-id="8b346-141">This can you help determine if your manifest has any problems that might cause certification or submission failures.</span></span>

<span data-ttu-id="8b346-142">アプリに複数のパッケージがある場合、以下のアプリ マニフェストの要素は各パッケージで (ターゲット OS ごとに) 同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-142">If your app has more than one package, these app manifest elements must be the same in each package (per targeted OS):</span></span>

-   [**<span data-ttu-id="8b346-143">Package/Capabilities</span><span class="sxs-lookup"><span data-stu-id="8b346-143">Package/Capabilities</span></span>**](https://msdn.microsoft.com/library/windows/apps/br211422)
-   [**<span data-ttu-id="8b346-144">Package/Dependencies</span><span class="sxs-lookup"><span data-stu-id="8b346-144">Package/Dependencies</span></span>**](https://msdn.microsoft.com/library/windows/apps/br211428)
-   [**<span data-ttu-id="8b346-145">Package/Resources</span><span class="sxs-lookup"><span data-stu-id="8b346-145">Package/Resources</span></span>**](https://msdn.microsoft.com/library/windows/apps/br211462)


## <a name="package-format-requirements"></a><span data-ttu-id="8b346-146">パッケージの形式の要件</span><span class="sxs-lookup"><span data-stu-id="8b346-146">Package format requirements</span></span>

<span data-ttu-id="8b346-147">アプリのパッケージは、次の要件に準拠している必要があります。</span><span class="sxs-lookup"><span data-stu-id="8b346-147">Your app’s packages must comply with these requirements.</span></span>

| <span data-ttu-id="8b346-148">アプリ パッケージの性質</span><span class="sxs-lookup"><span data-stu-id="8b346-148">App package property</span></span> | <span data-ttu-id="8b346-149">要件</span><span class="sxs-lookup"><span data-stu-id="8b346-149">Requirement</span></span>                                                          |
|----------------------|----------------------------------------------------------------------|
| <span data-ttu-id="8b346-150">パッケージのサイズ</span><span class="sxs-lookup"><span data-stu-id="8b346-150">Package size</span></span>         | <span data-ttu-id="8b346-151">.appxbundle: バンドルあたり最大 25 GB</span><span class="sxs-lookup"><span data-stu-id="8b346-151">.appxbundle: 25 GB maximum per bundle</span></span> <br><span data-ttu-id="8b346-152">Windows 10 を対象とする .appx パッケージ: パッケージあたり最大 25 GB</span><span class="sxs-lookup"><span data-stu-id="8b346-152">.appx packages targeting Windows 10: 25 GB maximum per package</span></span><br><span data-ttu-id="8b346-153">Windows 8.1 を対象とする .appx パッケージ: パッケージあたり最大 8 GB</span><span class="sxs-lookup"><span data-stu-id="8b346-153">.appx packages targeting Windows 8.1: 8 GB maximum per package</span></span> <br> <span data-ttu-id="8b346-154">Windows 8 を対象とする .appx パッケージ: パッケージあたり最大 2 GB</span><span class="sxs-lookup"><span data-stu-id="8b346-154">.appx packages targeting Windows 8: 2 GB maximum per package</span></span> <br> <span data-ttu-id="8b346-155">Windows Phone 8.1 を対象とする .appx パッケージ: パッケージあたり最大 4 GB</span><span class="sxs-lookup"><span data-stu-id="8b346-155">.appx packages targeting Windows Phone 8.1: 4 GB maximum per package</span></span> <br> <span data-ttu-id="8b346-156">.xap パッケージ: パッケージあたり最大 1 GB</span><span class="sxs-lookup"><span data-stu-id="8b346-156">.xap packages: 1 GB maximum per package</span></span>                                                                           |
| <span data-ttu-id="8b346-157">ブロック マップ ハッシュ</span><span class="sxs-lookup"><span data-stu-id="8b346-157">Block map hashes</span></span>     | <span data-ttu-id="8b346-158">SHA2-256 アルゴリズム</span><span class="sxs-lookup"><span data-stu-id="8b346-158">SHA2-256 algorithm</span></span>                                                   |
 

## <a name="storemanifest-xml-file"></a><span data-ttu-id="8b346-159">StoreManifest XML ファイル</span><span class="sxs-lookup"><span data-stu-id="8b346-159">StoreManifest XML file</span></span>

<span data-ttu-id="8b346-160">StoreManifest.xml は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。</span><span class="sxs-lookup"><span data-stu-id="8b346-160">StoreManifest.xml is an optional configuration file that may be included in app packages.</span></span> <span data-ttu-id="8b346-161">その目的は、Windows ストア デバイス アプリとしてアプリを宣言する機能や、パッケージ マニフェストの対象外となるデバイスに適用される要件を宣言する機能などを有効にすることです。</span><span class="sxs-lookup"><span data-stu-id="8b346-161">Its purpose is to enable features, such as declaring your app as a Windows Store device app or declaring requirements that a package depends on to be applicable to a device, that the package manifest does not cover.</span></span> <span data-ttu-id="8b346-162">StoreManifest.xml はアプリ パッケージと共に提出し、アプリのメイン プロジェクトのルート フォルダーにあることが必要です。</span><span class="sxs-lookup"><span data-stu-id="8b346-162">StoreManifest.xml is submitted with the app package and must be in the root folder of your app's main project.</span></span> <span data-ttu-id="8b346-163">詳しくは、「[StoreManifest スキーマ](https://docs.microsoft.com/uwp/schemas/storemanifest/store-manifest-schema-portal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8b346-163">For more info, see [StoreManifest schema](https://docs.microsoft.com/uwp/schemas/storemanifest/store-manifest-schema-portal).</span></span>

 

 




