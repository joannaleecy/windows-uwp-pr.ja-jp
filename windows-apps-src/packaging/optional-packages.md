---
ms.assetid: 3a59ff5e-f491-491c-81b1-6aff15886aad
title: オプション パッケージと関連セットの作成
description: オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10、uwp、オプション パッケージ、関連セット, パッケージの拡張機能、visual studio
ms.localizationpriority: medium
ms.openlocfilehash: e19f9673090501d59e260a698f9968a8f98f1cd5
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8699044"
---
# <a name="optional-packages-and-related-set-authoring"></a><span data-ttu-id="21350-105">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="21350-105">Optional packages and related set authoring</span></span>
<span data-ttu-id="21350-106">オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。</span><span class="sxs-lookup"><span data-stu-id="21350-106">Optional packages contain content that can be integrated with a main package.</span></span> <span data-ttu-id="21350-107">これらは、ダウンロード可能なコンテンツ (DLC) のサイズ制限、大規模なアプリを分割するのに便利ですか、元のアプリから分離して追加コンテンツを出荷します。</span><span class="sxs-lookup"><span data-stu-id="21350-107">These are useful for downloadable content (DLC), dividing a large app for size restraints, or for shipping any additional content separate from your original app.</span></span>

<span data-ttu-id="21350-108">関連セットは省略可能なパッケージの拡張機能--メインおよびオプションのパッケージ間でのバージョンの厳密なセットを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="21350-108">Related sets are an extension of optional packages -- they allow you to enforce a strict set of versions across main and optional packages.</span></span> <span data-ttu-id="21350-109">オプション パッケージからネイティブ コード (C++) をロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="21350-109">They also let you load native code (C++) from optional packages.</span></span> 

## <a name="prerequisites"></a><span data-ttu-id="21350-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="21350-110">Prerequisites</span></span>

- <span data-ttu-id="21350-111">Visual Studio 2017 version 15.1</span><span class="sxs-lookup"><span data-stu-id="21350-111">Visual Studio 2017, version 15.1</span></span>
- <span data-ttu-id="21350-112">Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="21350-112">Windows 10, version 1703</span></span>
- <span data-ttu-id="21350-113">Windows 10 バージョン 1703 SDK</span><span class="sxs-lookup"><span data-stu-id="21350-113">Windows 10, version 1703 SDK</span></span>

<span data-ttu-id="21350-114">すべての最新の開発ツールを取得するのには、[ダウンロードと Windows 10 向けのツール](https://developer.microsoft.com/windows/downloads)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="21350-114">To get all of the latest development tools, see [Downloads and tools for Windows 10](https://developer.microsoft.com/windows/downloads).</span></span>

> [!NOTE]
> <span data-ttu-id="21350-115">オプション パッケージや関連セットを使用して、Microsoft Store アプリを送信するには、アクセス許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21350-115">To submit an app that uses optional packages and/or related sets to the Microsoft Store, you will need permission.</span></span> <span data-ttu-id="21350-116">オプション パッケージや関連セットは、ストアに提出しない場合に、パートナー センターのアクセス許可のない基幹業務 (LOB) や企業のアプリ使用できます。</span><span class="sxs-lookup"><span data-stu-id="21350-116">Optional packages and related sets can be used for Line of Business (LOB) or enterprise apps without Partner Center permission if they are not submitted to the Store.</span></span> <span data-ttu-id="21350-117">オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="21350-117">See [Windows developer support](https://developer.microsoft.com/windows/support) to get permission to submit an app that uses optional packages and related sets.</span></span>

### <a name="code-sample"></a><span data-ttu-id="21350-118">コード サンプル</span><span class="sxs-lookup"><span data-stu-id="21350-118">Code sample</span></span>
<span data-ttu-id="21350-119">この記事を表示しているときに、実践的な理解するにはどのオプション パッケージの GitHub で次の[オプション パッケージのコード サンプル](https://github.com/AppInstaller/OptionalPackageSample)と共にして関連の Visual Studio 内で作業を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="21350-119">While you're reading this article, it's recommended that you follow along with the [optional package code sample](https://github.com/AppInstaller/OptionalPackageSample) on GitHub for a hands-on understanding of how optional packages and related sets work within Visual Studio.</span></span>

## <a name="optional-packages"></a><span data-ttu-id="21350-120">オプション パッケージ</span><span class="sxs-lookup"><span data-stu-id="21350-120">Optional packages</span></span>
<span data-ttu-id="21350-121">Visual Studio でオプション パッケージを作成するには、する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21350-121">To create an optional package in Visual Studio, you'll need to:</span></span>
1. <span data-ttu-id="21350-122">確認にアプリの**ターゲット プラットフォームの最小バージョン**が設定されます: 10.0.15063.0 します。</span><span class="sxs-lookup"><span data-stu-id="21350-122">Make sure your app's **Target Platform Min Version** is set to: 10.0.15063.0.</span></span>
2. <span data-ttu-id="21350-123">**メイン パッケージ**プロジェクトを開き、`Package.appxmanifest`ファイル。</span><span class="sxs-lookup"><span data-stu-id="21350-123">From your **main package** project, open the `Package.appxmanifest` file.</span></span> <span data-ttu-id="21350-124">"Packaging"タブに移動し、「_」文字の前にすべてのものであることを**パッケージ ファミリ名**をメモします。</span><span class="sxs-lookup"><span data-stu-id="21350-124">Navigate to the "Packaging" tab and make a note of your **package family name**, which is everything before the "_" character.</span></span>
3. <span data-ttu-id="21350-125">**オプション パッケージ**プロジェクトを右クリックして、`Package.appxmanifest`選択**で開く > XML (テキスト) エディター**します。</span><span class="sxs-lookup"><span data-stu-id="21350-125">From your **optional package** project, right click the `Package.appxmanifest` and select **Open with > XML (Text) Editor**.</span></span>
4. <span data-ttu-id="21350-126">検索、`<Dependencies>`ファイル内の要素です。</span><span class="sxs-lookup"><span data-stu-id="21350-126">Locate the `<Dependencies>` element in the file.</span></span> <span data-ttu-id="21350-127">次に追加します。</span><span class="sxs-lookup"><span data-stu-id="21350-127">Add the following:</span></span>

```XML
<uap3:MainPackageDependency Name="[MainPackageDependency]"/>
```

<span data-ttu-id="21350-128">置換`[MainPackageDependency]`手順 2 から**パッケージ ファミリ名**。</span><span class="sxs-lookup"><span data-stu-id="21350-128">Replace `[MainPackageDependency]` with your **package family name** from Step 2.</span></span> <span data-ttu-id="21350-129">**オプション パッケージ**は、**メイン パッケージ**に依存するこれを指定します。</span><span class="sxs-lookup"><span data-stu-id="21350-129">This will specify that your **optional package** is dependent on your **main package**.</span></span>

<span data-ttu-id="21350-130">4 を通じて手順 1 からセットアップ、パッケージの依存関係を作成したらは、通常どおりに開発を続行することができます。</span><span class="sxs-lookup"><span data-stu-id="21350-130">Once you have your package dependencies set up from Steps 1 through 4, you can continue developing as you normally would.</span></span> <span data-ttu-id="21350-131">オプション パッケージからメイン パッケージにコードを読み込む場合は、関連セットをビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="21350-131">If you would like to load code from the optional package into the main package, you will need to build a related set.</span></span> <span data-ttu-id="21350-132">詳細については、[関連の設定](#related_sets)のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="21350-132">See the [Related sets](#related_sets) section for more details.</span></span>

<span data-ttu-id="21350-133">Visual Studio は、オプション パッケージを展開するたびに、メイン パッケージを再展開するように構成できます。</span><span class="sxs-lookup"><span data-stu-id="21350-133">Visual Studio can be configured to re-deploy your main package each time you deploy an optional package.</span></span> <span data-ttu-id="21350-134">Visual Studio でビルド依存関係を設定するには、次の必要があります。</span><span class="sxs-lookup"><span data-stu-id="21350-134">To set the build dependency in Visual Studio, you should:</span></span>

- <span data-ttu-id="21350-135">オプション パッケージ プロジェクトを右クリックし、選択**依存関係の構築 > プロジェクトの依存関係.**</span><span class="sxs-lookup"><span data-stu-id="21350-135">Right click the optional package project and select **Build Dependencies > Project Dependencies...**</span></span>
- <span data-ttu-id="21350-136">メイン パッケージ プロジェクトを確認し、[OK] を選択します。</span><span class="sxs-lookup"><span data-stu-id="21350-136">Check the main package project and select "OK".</span></span> 

<span data-ttu-id="21350-137">これで、f5 キーを入力またはオプション パッケージ プロジェクトをビルドするたびに Visual Studio プロジェクトをビルドしますメイン パッケージ最初にします。</span><span class="sxs-lookup"><span data-stu-id="21350-137">Now, every time you enter F5 or build an optional package project, Visual Studio will build the main package project first.</span></span> <span data-ttu-id="21350-138">これにより、メイン プロジェクトとオプションのプロジェクトが同期されます。</span><span class="sxs-lookup"><span data-stu-id="21350-138">This will ensure that your main project and optional projects are in sync.</span></span>

## <span data-ttu-id="21350-139">関連セット<a name="related_sets"></a></span><span class="sxs-lookup"><span data-stu-id="21350-139">Related sets<a name="related_sets"></a></span></span>

<span data-ttu-id="21350-140">オプション パッケージからメイン パッケージにコードを読み込む場合は、関連セットをビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="21350-140">If you want to load code from an optional package into the main package, you will need to build a related set.</span></span> <span data-ttu-id="21350-141">関連セットをビルドするには、メイン パッケージとオプション パッケージする必要があります密接な連携します。</span><span class="sxs-lookup"><span data-stu-id="21350-141">To build a related set, your main package and optional package must be tightly coupled.</span></span> <span data-ttu-id="21350-142">関連セットのメタデータは、メイン パッケージの .appxbundle または .msixbundle ファイルで指定されます。</span><span class="sxs-lookup"><span data-stu-id="21350-142">The metadata for related sets is specified in the .appxbundle or .msixbundle file of the main package.</span></span> <span data-ttu-id="21350-143">Visual Studio では、ファイル内で適切なメタデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="21350-143">Visual Studio helps you get the correct metadata in your files.</span></span> <span data-ttu-id="21350-144">関連セットのアプリのソリューションを構成するには、次の手順を使用します。</span><span class="sxs-lookup"><span data-stu-id="21350-144">To configure your app's solution for related sets, use the following steps:</span></span>

1. <span data-ttu-id="21350-145">メイン パッケージ プロジェクトを右クリックしてで、選択**追加 > 新しい項目]**</span><span class="sxs-lookup"><span data-stu-id="21350-145">Right click the main package project, select **Add > New Item...**</span></span>
2. <span data-ttu-id="21350-146">ウィンドウで、".txt"のインストールされたテンプレートを検索し、新しいテキスト ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="21350-146">From the window, search the Installed Templates for ".txt" and add a new text file.</span></span>
> [!IMPORTANT]
> <span data-ttu-id="21350-147">新しいテキスト ファイルの名前にする必要があります:`Bundle.Mapping.txt`します。</span><span class="sxs-lookup"><span data-stu-id="21350-147">The new text file must be named: `Bundle.Mapping.txt`.</span></span>
3. <span data-ttu-id="21350-148">`Bundle.Mapping.txt`ファイル、オプション パッケージ プロジェクトや外部パッケージへの相対パスを指定します。</span><span class="sxs-lookup"><span data-stu-id="21350-148">In the `Bundle.Mapping.txt` file you'll specify relative paths to any optional package projects or external packages.</span></span> <span data-ttu-id="21350-149">サンプル`Bundle.Mapping.txt`ファイルは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="21350-149">A sample `Bundle.Mapping.txt` file should look something like this:</span></span>

```syntax
[OptionalProjects]
"..\ActivatableOptionalPackage1\ActivatableOptionalPackage1.vcxproj"
"..\ActivatableOptionalPackage2\ActivatableOptionalPackage2.vcxproj"

[ExternalPackages]
"..\ActivatableOptionalPackage1\x86\Release\ActivatableOptionalPackage3_1.1.1.0\ ActivatableOptionalPackage3_1.1.1.0.appx"
```

<span data-ttu-id="21350-150">ソリューションにこのように構成されると、Visual Studio はすべての関連セットに必要なメタデータをメイン パッケージのバンドル マニフェストを作成します。</span><span class="sxs-lookup"><span data-stu-id="21350-150">When your solution is configured this way, Visual Studio will create a bundle manifest for the main package with all of the required metadata for related sets.</span></span> 

<span data-ttu-id="21350-151">などのオプション パッケージ、注意、`Bundle.Mapping.txt`関連セットのファイルは Windows 10 バージョン 1703 でのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="21350-151">Note that like optional packages, a `Bundle.Mapping.txt` file for related sets will only work on Windows 10, version 1703.</span></span> <span data-ttu-id="21350-152">さらに、アプリのターゲット プラットフォームの最小バージョンは、10.0.15063.0 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="21350-152">Additionally, your app's Target Platform Min Version should be set to 10.0.15063.0.</span></span>

## <span data-ttu-id="21350-153">既知の問題<a name="known_issues"></a></span><span class="sxs-lookup"><span data-stu-id="21350-153">Known issues<a name="known_issues"></a></span></span>

<span data-ttu-id="21350-154">関連セットの省略可能なプロジェクトのデバッグは現在サポートされていません Visual Studio でします。</span><span class="sxs-lookup"><span data-stu-id="21350-154">Debugging a related set optional project is not currently supported in Visual Studio.</span></span> <span data-ttu-id="21350-155">この問題を回避するには、展開し起動アクティブ化 (Ctrl + f5 キーを押します) して手動でのプロセスにデバッガーをアタッチできます。</span><span class="sxs-lookup"><span data-stu-id="21350-155">To work around this issue, you can deploy and launch the activation (Ctrl + F5) and manually attach the debugger to a process.</span></span> <span data-ttu-id="21350-156">デバッガーをアタッチするには、Visual Studio で"Debug"メニューに移動します] をクリックします"をアタッチするプロセスを**メイン アプリのプロセス**にデバッガーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="21350-156">To attach the debugger, go the "Debug" menu in Visual Studio, select "Attach to Process...", and attach the debugger to the **main app process**.</span></span>