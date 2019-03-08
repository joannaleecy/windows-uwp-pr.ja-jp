---
ms.assetid: 3a59ff5e-f491-491c-81b1-6aff15886aad
title: オプション パッケージと関連セットの作成
description: オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, UWP, オプション パッケージ, 関連セット, パッケージ拡張機能, Visual Studio
ms.localizationpriority: medium
ms.openlocfilehash: f62d6c99acc75033403fac7a498308cea6f7d3f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594027"
---
# <a name="optional-packages-and-related-set-authoring"></a><span data-ttu-id="e5284-105">オプション パッケージと関連セットの作成</span><span class="sxs-lookup"><span data-stu-id="e5284-105">Optional packages and related set authoring</span></span>
<span data-ttu-id="e5284-106">オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。</span><span class="sxs-lookup"><span data-stu-id="e5284-106">Optional packages contain content that can be integrated with a main package.</span></span> <span data-ttu-id="e5284-107">オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="e5284-107">These are useful for downloadable content (DLC), dividing a large app for size restraints, or for shipping any additional content separate from your original app.</span></span>

<span data-ttu-id="e5284-108">関連セットとは、オプション パッケージの拡張機能です。これらを使用すると、メイン パッケージとオプション パッケージを通じて、厳密なバージョン セットを適用できます。</span><span class="sxs-lookup"><span data-stu-id="e5284-108">Related sets are an extension of optional packages -- they allow you to enforce a strict set of versions across main and optional packages.</span></span> <span data-ttu-id="e5284-109">また、オプション パッケージからネイティブ コード (C++) を読み込むこともできます。</span><span class="sxs-lookup"><span data-stu-id="e5284-109">They also let you load native code (C++) from optional packages.</span></span> 

## <a name="prerequisites"></a><span data-ttu-id="e5284-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="e5284-110">Prerequisites</span></span>

- <span data-ttu-id="e5284-111">Visual Studio 2017 Version 15.1</span><span class="sxs-lookup"><span data-stu-id="e5284-111">Visual Studio 2017, version 15.1</span></span>
- <span data-ttu-id="e5284-112">Windows 10 Version 1703</span><span class="sxs-lookup"><span data-stu-id="e5284-112">Windows 10, version 1703</span></span>
- <span data-ttu-id="e5284-113">Windows 10 Version 1703 SDK</span><span class="sxs-lookup"><span data-stu-id="e5284-113">Windows 10, version 1703 SDK</span></span>

<span data-ttu-id="e5284-114">最新の開発ツールをすべて取得する方法については、「[Windows 10 用のダウンロードとツール](https://developer.microsoft.com/windows/downloads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e5284-114">To get all of the latest development tools, see [Downloads and tools for Windows 10](https://developer.microsoft.com/windows/downloads).</span></span>

> [!NOTE]
> <span data-ttu-id="e5284-115">Microsoft Store に省略可能なパッケージや関連する設定を使用するアプリを送信するには、アクセス許可する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5284-115">To submit an app that uses optional packages and/or related sets to the Microsoft Store, you will need permission.</span></span> <span data-ttu-id="e5284-116">オプションのパッケージおよび関連する設定は、いないストアに送信する場合に、パートナー センターの許可なく基幹業務 (LOB) またはエンタープライズのアプリ使用できます。</span><span class="sxs-lookup"><span data-stu-id="e5284-116">Optional packages and related sets can be used for Line of Business (LOB) or enterprise apps without Partner Center permission if they are not submitted to the Store.</span></span> <span data-ttu-id="e5284-117">オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e5284-117">See [Windows developer support](https://developer.microsoft.com/windows/support) to get permission to submit an app that uses optional packages and related sets.</span></span>

### <a name="code-sample"></a><span data-ttu-id="e5284-118">コード サンプル</span><span class="sxs-lookup"><span data-stu-id="e5284-118">Code sample</span></span>
<span data-ttu-id="e5284-119">この記事を読みながら GitHub で[オプション パッケージのコード サンプル](https://github.com/AppInstaller/OptionalPackageSample)を参照し、Visual Studio でオプション パッケージと関連セットがどのように動作するかを実際に体験して理解することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e5284-119">While you're reading this article, it's recommended that you follow along with the [optional package code sample](https://github.com/AppInstaller/OptionalPackageSample) on GitHub for a hands-on understanding of how optional packages and related sets work within Visual Studio.</span></span>

## <a name="optional-packages"></a><span data-ttu-id="e5284-120">オプション パッケージ</span><span class="sxs-lookup"><span data-stu-id="e5284-120">Optional packages</span></span>
<span data-ttu-id="e5284-121">Visual Studio オプション パッケージを作成するには、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="e5284-121">To create an optional package in Visual Studio, you'll need to:</span></span>
1. <span data-ttu-id="e5284-122">アプリの確認**ターゲット プラットフォームの最小バージョン**に設定されます。10.0.15063.0 またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="e5284-122">Make sure your app's **Target Platform Min Version** is set to: 10.0.15063.0 or higher.</span></span>
2. <span data-ttu-id="e5284-123">**メイン パッケージ** プロジェクトから、`Package.appxmanifest` ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="e5284-123">From your **main package** project, open the `Package.appxmanifest` file.</span></span> <span data-ttu-id="e5284-124">[パッケージ化] タブに移動し、**[パッケージ ファミリ名]** ("_" 文字の前にある文字列すべて) を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="e5284-124">Navigate to the "Packaging" tab and make a note of your **package family name**, which is everything before the "_" character.</span></span>
3. <span data-ttu-id="e5284-125">**オプション パッケージ** プロジェクトから、`Package.appxmanifest` を右クリックして **[プログラムから開く] > [XML (テキスト) エディター]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e5284-125">From your **optional package** project, right click the `Package.appxmanifest` and select **Open with > XML (Text) Editor**.</span></span>
4. <span data-ttu-id="e5284-126">ファイル内の `<Dependencies>` 要素を見つけます。</span><span class="sxs-lookup"><span data-stu-id="e5284-126">Locate the `<Dependencies>` element in the file.</span></span> <span data-ttu-id="e5284-127">以下を追加します。</span><span class="sxs-lookup"><span data-stu-id="e5284-127">Add the following:</span></span>

```XML
<uap3:MainPackageDependency Name="[MainPackageDependency]"/>
```

<span data-ttu-id="e5284-128">`[MainPackageDependency]` は、手順 2. の **[パッケージ ファミリ名]** の値に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="e5284-128">Replace `[MainPackageDependency]` with your **package family name** from Step 2.</span></span> <span data-ttu-id="e5284-129">これにより、**オプション パッケージ**が**メイン パッケージ**に依存することを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e5284-129">This will specify that your **optional package** is dependent on your **main package**.</span></span>

<span data-ttu-id="e5284-130">手順 1 から 4 を実行してパッケージの依存関係を設定できたら、通常の開発作業に進むことができます。</span><span class="sxs-lookup"><span data-stu-id="e5284-130">Once you have your package dependencies set up from Steps 1 through 4, you can continue developing as you normally would.</span></span> <span data-ttu-id="e5284-131">オプション パッケージからメイン パッケージにコードを読み込むには、関連セットを構築する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5284-131">If you would like to load code from the optional package into the main package, you will need to build a related set.</span></span> <span data-ttu-id="e5284-132">詳しくは、「[関連セット](#related_sets)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e5284-132">See the [Related sets](#related_sets) section for more details.</span></span>

<span data-ttu-id="e5284-133">Visual Studio は、オプション パッケージを展開するたびにメイン パッケージが再展開されるように構成できます。</span><span class="sxs-lookup"><span data-stu-id="e5284-133">Visual Studio can be configured to re-deploy your main package each time you deploy an optional package.</span></span> <span data-ttu-id="e5284-134">Visual Studio でビルド依存関係を設定するには、以下の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5284-134">To set the build dependency in Visual Studio, you should:</span></span>

- <span data-ttu-id="e5284-135">オプション パッケージ プロジェクトを右クリックし、**[ビルド依存関係] > [プロジェクト依存関係]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e5284-135">Right click the optional package project and select **Build Dependencies > Project Dependencies...**</span></span>
- <span data-ttu-id="e5284-136">メイン パッケージ プロジェクトを確認し、[OK] を選択します。</span><span class="sxs-lookup"><span data-stu-id="e5284-136">Check the main package project and select "OK".</span></span> 

<span data-ttu-id="e5284-137">これで、F5 キーを押すか、オプション パッケージ プロジェクトのビルドを実行するたびに、Visual Studio によってメイン プロジェクトが先にビルドされるようになります。</span><span class="sxs-lookup"><span data-stu-id="e5284-137">Now, every time you enter F5 or build an optional package project, Visual Studio will build the main package project first.</span></span> <span data-ttu-id="e5284-138">これにより、メイン プロジェクトとオプション プロジェクトが確実に同期されます。</span><span class="sxs-lookup"><span data-stu-id="e5284-138">This will ensure that your main project and optional projects are in sync.</span></span>

## <span data-ttu-id="e5284-139">関連セット<a name="related_sets"></a></span><span class="sxs-lookup"><span data-stu-id="e5284-139">Related sets<a name="related_sets"></a></span></span>

<span data-ttu-id="e5284-140">オプション パッケージからメイン パッケージにコードを読み込むには、関連セットを構築する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5284-140">If you want to load code from an optional package into the main package, you will need to build a related set.</span></span> <span data-ttu-id="e5284-141">関連セットを構築するには、メイン パッケージとオプション パッケージを確実に組み合わせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5284-141">To build a related set, your main package and optional package must be tightly coupled.</span></span> <span data-ttu-id="e5284-142">関連する設定のメタデータは、メイン パッケージの .appxbundle または .msixbundle ファイルで指定されます。</span><span class="sxs-lookup"><span data-stu-id="e5284-142">The metadata for related sets is specified in the .appxbundle or .msixbundle file of the main package.</span></span> <span data-ttu-id="e5284-143">Visual Studio を使用すると、正しいメタデータをファイルに取得できます。</span><span class="sxs-lookup"><span data-stu-id="e5284-143">Visual Studio helps you get the correct metadata in your files.</span></span> <span data-ttu-id="e5284-144">関連セット用にアプリのソリューションを構成するには、次の手順を使用します。</span><span class="sxs-lookup"><span data-stu-id="e5284-144">To configure your app's solution for related sets, use the following steps:</span></span>

1. <span data-ttu-id="e5284-145">メイン パッケージ プロジェクトを右クリックして、**[追加] > [新しいアイテム]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e5284-145">Right click the main package project, select **Add > New Item...**</span></span>
2. <span data-ttu-id="e5284-146">そのウィンドウから、[インストールされたテンプレート] で ".txt" を検索し、新しいテキスト ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="e5284-146">From the window, search the Installed Templates for ".txt" and add a new text file.</span></span>
> [!IMPORTANT]
> <span data-ttu-id="e5284-147">新しいテキスト ファイルに `Bundle.Mapping.txt` という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="e5284-147">The new text file must be named: `Bundle.Mapping.txt`.</span></span>

3. <span data-ttu-id="e5284-148">`Bundle.Mapping.txt` ファイル内に、オプション パッケージ プロジェクトや外部パッケージの相対パスをすべて指定します。</span><span class="sxs-lookup"><span data-stu-id="e5284-148">In the `Bundle.Mapping.txt` file you'll specify relative paths to any optional package projects or external packages.</span></span> <span data-ttu-id="e5284-149">`Bundle.Mapping.txt` ファイルのサンプルを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e5284-149">A sample `Bundle.Mapping.txt` file should look something like this:</span></span>

```syntax
[OptionalProjects]
"..\ActivatableOptionalPackage1\ActivatableOptionalPackage1.vcxproj"
"..\ActivatableOptionalPackage2\ActivatableOptionalPackage2.vcxproj"

[ExternalPackages]
"..\ActivatableOptionalPackage1\x86\Release\ActivatableOptionalPackage3_1.1.1.0\ ActivatableOptionalPackage3_1.1.1.0.appx"
```

<span data-ttu-id="e5284-150">この方法でソリューションが構成されている場合、Visual Studio は関連セットの必要なメタデータをすべて含めて、メイン パッケージのバンドル マニフェストを作成します。</span><span class="sxs-lookup"><span data-stu-id="e5284-150">When your solution is configured this way, Visual Studio will create a bundle manifest for the main package with all of the required metadata for related sets.</span></span> 

<span data-ttu-id="e5284-151">などのオプションのパッケージに注意してください、`Bundle.Mapping.txt`の関連する設定ファイルは Windows 10 バージョン 1703 以降でのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="e5284-151">Note that like optional packages, a `Bundle.Mapping.txt` file for related sets will only work on Windows 10, version 1703 or higher.</span></span> <span data-ttu-id="e5284-152">さらに、アプリの対象プラットフォームの最小バージョンは、10.0.15063.0 以上に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e5284-152">Additionally, your app's Target Platform Min Version should be set to 10.0.15063.0 or higher.</span></span>

## <span data-ttu-id="e5284-153">既知の問題<a name="known_issues"></a></span><span class="sxs-lookup"><span data-stu-id="e5284-153">Known issues<a name="known_issues"></a></span></span>

<span data-ttu-id="e5284-154">現在、関連セット オプション プロジェクトのデバッグは Visual Studio でサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e5284-154">Debugging a related set optional project is not currently supported in Visual Studio.</span></span> <span data-ttu-id="e5284-155">この問題を回避するには、アクティブ化を展開および起動 (Ctrl + F5) して、プロセスにデバッガーを手動でアタッチします。</span><span class="sxs-lookup"><span data-stu-id="e5284-155">To work around this issue, you can deploy and launch the activation (Ctrl + F5) and manually attach the debugger to a process.</span></span> <span data-ttu-id="e5284-156">デバッガーをアタッチするには、Visual Studio の [デバッグ] メニューで [プロセスにアタッチ] を選択し、**メイン アプリ プロセス**にデバッガーをアタッチします。</span><span class="sxs-lookup"><span data-stu-id="e5284-156">To attach the debugger, go the "Debug" menu in Visual Studio, select "Attach to Process...", and attach the debugger to the **main app process**.</span></span>