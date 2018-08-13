---
author: laurenhughes
ms.assetid: 3a59ff5e-f491-491c-81b1-6aff15886aad
title: オプション パッケージと関連セットの作成
description: オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。
ms.author: lahugh
ms.date: 04/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、オプションのパッケージ、関連するセット、パッケージの拡張機能、visual studio
ms.localizationpriority: medium
ms.openlocfilehash: d66a511211396190393e31bfd553149a1e89fad0
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608857"
---
# <a name="optional-packages-and-related-set-authoring"></a><span data-ttu-id="ab876-105">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="ab876-105">Optional packages and related set authoring</span></span>
<span data-ttu-id="ab876-106">オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。</span><span class="sxs-lookup"><span data-stu-id="ab876-106">Optional packages contain content that can be integrated with a main package.</span></span> <span data-ttu-id="ab876-107">これらは、ダウンロード可能なコンテンツ (DLC)] を大きなサイズの制限] アプリを除算するのに便利ですか、送付追加コンテンツの元のアプリから分離します。</span><span class="sxs-lookup"><span data-stu-id="ab876-107">These are useful for downloadable content (DLC), dividing a large app for size restraints, or for shipping any additional content separate from your original app.</span></span>

<span data-ttu-id="ab876-108">関連のセットがオプションのパッケージの拡張--メインと省略可能なパッケージ全体のバージョンの厳格なセットを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="ab876-108">Related sets are an extension of optional packages -- they allow you to enforce a strict set of versions across main and optional packages.</span></span> <span data-ttu-id="ab876-109">また、オプションのパッケージからネイティブ コード (C++) をロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ab876-109">They also let you load native code (C++) from optional packages.</span></span> 

## <a name="prerequisites"></a><span data-ttu-id="ab876-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="ab876-110">Prerequisites</span></span>

- <span data-ttu-id="ab876-111">Visual Studio 2017、バージョン 15.1</span><span class="sxs-lookup"><span data-stu-id="ab876-111">Visual Studio 2017, version 15.1</span></span>
- <span data-ttu-id="ab876-112">Windows 10 バージョン 1703</span><span class="sxs-lookup"><span data-stu-id="ab876-112">Windows 10, version 1703</span></span>
- <span data-ttu-id="ab876-113">Windows 10、バージョン 1703 SDK</span><span class="sxs-lookup"><span data-stu-id="ab876-113">Windows 10, version 1703 SDK</span></span>

<span data-ttu-id="ab876-114">最新の開発ツールのすべてを移動するには、[ダウンロードと Windows 10 用のツール](https://developer.microsoft.com/windows/downloads)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab876-114">To get all of the latest development tools, see [Downloads and tools for Windows 10](https://developer.microsoft.com/windows/downloads).</span></span>

> [!NOTE]
> <span data-ttu-id="ab876-115">Microsoft ストアにオプションのパッケージや関連のセットを使用しているアプリを送信するには、アクセス許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-115">To submit an app that uses optional packages and/or related sets to the Microsoft Store, you will need permission.</span></span> <span data-ttu-id="ab876-116">Microsoft Store に提出しない場合は、デベロッパー センターから許可を受けずにオプション パッケージや関連セットを基幹業務 (LOB) アプリやエンタープライズ アプリに使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab876-116">Optional packages and related sets can be used for Line of Business (LOB) or enterprise apps without Dev Center permission if they are not submitted to the Store.</span></span> <span data-ttu-id="ab876-117">オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab876-117">See [Windows developer support](https://developer.microsoft.com/windows/support) to get permission to submit an app that uses optional packages and related sets.</span></span>

### <a name="code-sample"></a><span data-ttu-id="ab876-118">コード サンプル</span><span class="sxs-lookup"><span data-stu-id="ab876-118">Code sample</span></span>
<span data-ttu-id="ab876-119">この記事をご覧になっているときに、実践的な理解するにはどのようにオプションのパッケージの GitHub で次の[オプションのパッケージ コード サンプル](https://github.com/AppInstaller/OptionalPackageSample)と共にして Visual Studio 内の作業のセットに関連することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ab876-119">While you're reading this article, it's recommended that you follow along with the [optional package code sample](https://github.com/AppInstaller/OptionalPackageSample) on GitHub for a hands-on understanding of how optional packages and related sets work within Visual Studio.</span></span>

## <a name="optional-packages"></a><span data-ttu-id="ab876-120">オプションのパッケージ</span><span class="sxs-lookup"><span data-stu-id="ab876-120">Optional packages</span></span>
<span data-ttu-id="ab876-121">Visual Studio で (オプション) を作成するには、する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-121">To create an optional package in Visual Studio, you'll need to:</span></span>
1. <span data-ttu-id="ab876-122">確認にアプリの**ターゲット プラットフォームの最小バージョン**が設定されて: 10.0.15063.0 します。</span><span class="sxs-lookup"><span data-stu-id="ab876-122">Make sure your app's **Target Platform Min Version** is set to: 10.0.15063.0.</span></span>
2. <span data-ttu-id="ab876-123">**パッケージのメイン**プロジェクトから開く、`Package.appxmanifest`ファイル。</span><span class="sxs-lookup"><span data-stu-id="ab876-123">From your **main package** project, open the `Package.appxmanifest` file.</span></span> <span data-ttu-id="ab876-124">「パッケージ」] タブに移動して、「_」の文字の前にすべてのアイテムであることを**パッケージ ファミリ名**をメモします。</span><span class="sxs-lookup"><span data-stu-id="ab876-124">Navigate to the "Packaging" tab and make a note of your **package family name**, which is everything before the "_" character.</span></span>
3. <span data-ttu-id="ab876-125">**省略可能なパッケージ**プロジェクトを右クリックします。、`Package.appxmanifest`を選択して**ファイルを開く > (テキスト) の XML エディター**します。</span><span class="sxs-lookup"><span data-stu-id="ab876-125">From your **optional package** project, right click the `Package.appxmanifest` and select **Open with > XML (Text) Editor**.</span></span>
4. <span data-ttu-id="ab876-126">検索、`<Dependencies>`ファイル内の要素。</span><span class="sxs-lookup"><span data-stu-id="ab876-126">Locate the `<Dependencies>` element in the file.</span></span> <span data-ttu-id="ab876-127">次に追加します。</span><span class="sxs-lookup"><span data-stu-id="ab876-127">Add the following:</span></span>

```XML
<uap3:MainPackageDependency Name="[MainPackageDependency]"/>
```

<span data-ttu-id="ab876-128">置き換える`[MainPackageDependency]`ステップ 2 から**パッケージ家族の名前**をします。</span><span class="sxs-lookup"><span data-stu-id="ab876-128">Replace `[MainPackageDependency]` with your **package family name** from Step 2.</span></span> <span data-ttu-id="ab876-129">これは、**省略可能なパッケージ**が、**メインのパッケージ**に依存していることを指定します。</span><span class="sxs-lookup"><span data-stu-id="ab876-129">This will specify that your **optional package** is dependent on your **main package**.</span></span>

<span data-ttu-id="ab876-130">手順 1 から 4 までを設定するパッケージの依存関係を作成したらは、通常どおりに開発を続行することができます。</span><span class="sxs-lookup"><span data-stu-id="ab876-130">Once you have your package dependencies set up from Steps 1 through 4, you can continue developing as you normally would.</span></span> <span data-ttu-id="ab876-131">オプションのパッケージのメインのパッケージにコードを読み込む場合は、関連するセットを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-131">If you would like to load code from the optional package into the main package, you will need to build a related set.</span></span> <span data-ttu-id="ab876-132">詳細については、[関連の設定](#related_sets)] セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab876-132">See the [Related sets](#related_sets) section for more details.</span></span>

<span data-ttu-id="ab876-133">(オプション) を展開するたびに、メインのパッケージを再配置するのには、visual Studio を構成できます。</span><span class="sxs-lookup"><span data-stu-id="ab876-133">Visual Studio can be configured to re-deploy your main package each time you deploy an optional package.</span></span> <span data-ttu-id="ab876-134">Visual studio ビルド依存関係を設定するには、次の必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-134">To set the build dependency in Visual Studio, you should:</span></span>

- <span data-ttu-id="ab876-135">省略可能なパッケージ プロジェクトを右クリックし、選択**依存関係を構築 > プロジェクトの依存関係]**</span><span class="sxs-lookup"><span data-stu-id="ab876-135">Right click the optional package project and select **Build Dependencies > Project Dependencies...**</span></span>
- <span data-ttu-id="ab876-136">パッケージのメインのプロジェクトをチェックし、"OK"を選択します。</span><span class="sxs-lookup"><span data-stu-id="ab876-136">Check the main package project and select "OK".</span></span> 

<span data-ttu-id="ab876-137">これで、たびに、f5 キーを入力するか、省略可能なパッケージのプロジェクトを作成すると、Visual Studio プロジェクトをビルド パッケージのメイン最初します。</span><span class="sxs-lookup"><span data-stu-id="ab876-137">Now, every time you enter F5 or build an optional package project, Visual Studio will build the main package project first.</span></span> <span data-ttu-id="ab876-138">これにより、メインのプロジェクトと省略可能なプロジェクトとの同期があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-138">This will ensure that your main project and optional projects are in sync.</span></span>

## <span data-ttu-id="ab876-139">関連する設定<a name="related_sets"></a></span><span class="sxs-lookup"><span data-stu-id="ab876-139">Related sets<a name="related_sets"></a></span></span>

<span data-ttu-id="ab876-140">オプションのパッケージのメインのパッケージにコードを読み込む場合は、関連するセットを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-140">If you want to load code from an optional package into the main package, you will need to build a related set.</span></span> <span data-ttu-id="ab876-141">関連するセットを作成するには、省略可能なパッケージ、パッケージのメインする必要があります密に結合します。</span><span class="sxs-lookup"><span data-stu-id="ab876-141">To build a related set, your main package and optional package must be tightly coupled.</span></span> <span data-ttu-id="ab876-142">関連するセットのメタデータがで指定された、`.appxbundle`パッケージのメインのファイル。</span><span class="sxs-lookup"><span data-stu-id="ab876-142">The metadata for related sets is specified in the `.appxbundle` file of the main package.</span></span> <span data-ttu-id="ab876-143">Visual Studio では、ファイル内で正しいメタデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="ab876-143">Visual Studio helps you get the correct metadata in your files.</span></span> <span data-ttu-id="ab876-144">関連したアプリのソリューションを構成するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="ab876-144">To configure your app's solution for related sets, use the following steps:</span></span>

1. <span data-ttu-id="ab876-145">パッケージのメイン プロジェクトを右クリックしてで、選択**追加 > [新しいアイテム]**</span><span class="sxs-lookup"><span data-stu-id="ab876-145">Right click the main package project, select **Add > New Item...**</span></span>
2. <span data-ttu-id="ab876-146">ウィンドウでは、".txt"インストールされているテンプレートを検索し、新しいテキスト ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="ab876-146">From the window, search the Installed Templates for ".txt" and add a new text file.</span></span>
> [!IMPORTANT]
> <span data-ttu-id="ab876-147">新しいテキスト ファイルを付ける必要があります:`Bundle.Mapping.txt`します。</span><span class="sxs-lookup"><span data-stu-id="ab876-147">The new text file must be named: `Bundle.Mapping.txt`.</span></span>
3. <span data-ttu-id="ab876-148">`Bundle.Mapping.txt`ファイルの任意のオプションのパッケージのプロジェクトまたは外部パッケージへの相対パスを指定します。</span><span class="sxs-lookup"><span data-stu-id="ab876-148">In the `Bundle.Mapping.txt` file you'll specify relative paths to any optional package projects or external packages.</span></span> <span data-ttu-id="ab876-149">サンプル`Bundle.Mapping.txt`ファイルは次のように表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-149">A sample `Bundle.Mapping.txt` file should look something like this:</span></span>

```syntax
[OptionalProjects]
"..\ActivatableOptionalPackage1\ActivatableOptionalPackage1.vcxproj"
"..\ActivatableOptionalPackage2\ActivatableOptionalPackage2.vcxproj"

[ExternalPackages]
"..\ActivatableOptionalPackage1\x86\Release\ActivatableOptionalPackage3_1.1.1.0\ ActivatableOptionalPackage3_1.1.1.0.appx"
```

<span data-ttu-id="ab876-150">ソリューションが、このように構成されている、Visual Studio はすべての関連する設定に必要なメタデータ パッケージのメインのバンドル マニフェストに作成されます。</span><span class="sxs-lookup"><span data-stu-id="ab876-150">When your solution is configured this way, Visual Studio will create a bundle manifest for the main package with all of the required metadata for related sets.</span></span> 

<span data-ttu-id="ab876-151">オプションのパッケージのようなことに注意を`Bundle.Mapping.txt`関連したファイルは、Windows 10、1703 のバージョンでのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="ab876-151">Note that like optional packages, a `Bundle.Mapping.txt` file for related sets will only work on Windows 10, version 1703.</span></span> <span data-ttu-id="ab876-152">さらに、10.0.15063.0 するように、アプリのターゲット プラットフォームの最小バージョンを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab876-152">Additionally, your app's Target Platform Min Version should be set to 10.0.15063.0.</span></span>

## <span data-ttu-id="ab876-153">既知の問題<a name="known_issues"></a></span><span class="sxs-lookup"><span data-stu-id="ab876-153">Known issues<a name="known_issues"></a></span></span>

<span data-ttu-id="ab876-154">関連する設定オプションのプロジェクトをデバッグは現在サポートされていません Visual Studio でします。</span><span class="sxs-lookup"><span data-stu-id="ab876-154">Debugging a related set optional project is not currently supported in Visual Studio.</span></span> <span data-ttu-id="ab876-155">この問題を回避するには、展開し、(ctrl キーを押しながら f5 キーを押して) のライセンス認証を起動してプロセスにデバッガーを手動で追加できます。</span><span class="sxs-lookup"><span data-stu-id="ab876-155">To work around this issue, you can deploy and launch the activation (Ctrl + F5) and manually attach the debugger to a process.</span></span> <span data-ttu-id="ab876-156">デバッガーを添付するには、Visual Studio で"デバッグ] メニューを移動、「を添付するプロセス...」を選択し、**メインのアプリのプロセス**にデバッガーを追加します。</span><span class="sxs-lookup"><span data-stu-id="ab876-156">To attach the debugger, go the "Debug" menu in Visual Studio, select "Attach to Process...", and attach the debugger to the **main app process**.</span></span>