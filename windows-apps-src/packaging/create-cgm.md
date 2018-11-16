---
author: laurenhughes
ms.assetid: ff2523cb-8109-42be-9dfc-cb5d09002574
title: ソース コンテンツ グループ マップの作成と変換
description: ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。 この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。
ms.author: lahugh
ms.date: 9/30/2018
ms.topic: article
keywords: Windows 10, UWP, コンテンツ グループ マップ, ストリーミング インストール, UWP アプリ ストリーミング インストール, ソース コンテンツ グループ マップ
ms.localizationpriority: medium
ms.openlocfilehash: 6a2922d6d3f54d693a9fe9c0982ea06cc5f2caae
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6832201"
---
# <a name="create-and-convert-a-source-content-group-map"></a><span data-ttu-id="be0fb-105">ソース コンテンツ グループ マップの作成と変換</span><span class="sxs-lookup"><span data-stu-id="be0fb-105">Create and convert a source content group map</span></span>

<span data-ttu-id="be0fb-106">ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-106">To get your Universal Windows Platform (UWP) app ready for UWP App Streaming Install, you'll need to create a content group map.</span></span> <span data-ttu-id="be0fb-107">この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-107">This article will help you with the specifics of creating and converting a content group map while providing some tips and tricks along the way.</span></span>

## <a name="creating-the-source-content-group-map"></a><span data-ttu-id="be0fb-108">ソース コンテンツ グループ マップを作成する</span><span class="sxs-lookup"><span data-stu-id="be0fb-108">Creating the source content group map</span></span>

<span data-ttu-id="be0fb-109">`SourceAppxContentGroupMap.xml` ファイルを作成してから、Visual Studio または **MakeAppx.exe** ツールを使用して、このファイルを最終的なバージョンである `AppxContentGroupMap.xml` に変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-109">You'll need to create a `SourceAppxContentGroupMap.xml` file, and then either use Visual Studio or the **MakeAppx.exe** tool to convert this file to the final version: `AppxContentGroupMap.xml`.</span></span> <span data-ttu-id="be0fb-110">`AppxContentGroupMap.xml` を 1 から作成すると、手順を 1 つ省くことができますが、`AppxContentGroupMap.xml` では (非常に便利な) ワイルドカードを使用できないため、`SourceAppxContentGroupMap.xml` を作成してから変換することをお勧めします (通常はこの方法を使う方が簡単です)。</span><span class="sxs-lookup"><span data-stu-id="be0fb-110">It's possible to skip a step by creating the `AppxContentGroupMap.xml` from scratch, but it's recommended (and generally easier) to create the `SourceAppxContentGroupMap.xml` and convert it, since wildcards are not allowed in the `AppxContentGroupMap.xml` (and they're really helpful).</span></span> 

<span data-ttu-id="be0fb-111">UWP アプリ ストリーミング インストールが適した簡単なシナリオを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="be0fb-111">Let's walk through a simple scenario where UWP App Streaming Install is beneficial.</span></span> 

<span data-ttu-id="be0fb-112">たとえば、作成した UWP ゲームの最終的なアプリのサイズが 100 GB を超えているとします。</span><span class="sxs-lookup"><span data-stu-id="be0fb-112">Say you've created a UWP game, but the size of your final app is over 100 GB.</span></span> <span data-ttu-id="be0fb-113">便利なことができる Microsoft Store からダウンロードに時間がかかるする予定です。</span><span class="sxs-lookup"><span data-stu-id="be0fb-113">That's going to take a long time to download from the Microsoft Store, which can be inconvenient.</span></span> <span data-ttu-id="be0fb-114">UWP アプリ ストリーミング インストールを使用する場合は、アプリのファイルがダウンロードされる順序を指定できます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-114">If you choose to use UWP App Streaming Install, you can specify the order in which your app's files are downloaded.</span></span> <span data-ttu-id="be0fb-115">必須ファイルから先にダウンロードされるようストアに指定しておくことで、ユーザーは必須ではないファイルをバックグラウンドでダウンロードしながらアプリの使用を早く開始できます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-115">By telling the Store to download essential files first, the user will be able to engage with your app sooner while other non-essential files are downloaded in the background.</span></span>

> [!NOTE]
> <span data-ttu-id="be0fb-116">UWP アプリ ストリーミング インストールの使用には、アプリのファイル構成が大きく影響します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-116">Using UWP App Streaming Install heavily relies on your app's file organization.</span></span> <span data-ttu-id="be0fb-117">アプリのファイル分割を容易にするには、UWP アプリ ストリーミング インストールに合わせてアプリのコンテンツ レイアウトをできるだけ早く検討するようお勧めします。</span><span class="sxs-lookup"><span data-stu-id="be0fb-117">It's recommended that you think about your app's content layout with respect to UWP App Streaming Install as soon as possible to make segmenting your app's files simpler.</span></span>

<span data-ttu-id="be0fb-118">まず、`SourceAppxContentGroupMap.xml` ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-118">First, we'll create a `SourceAppxContentGroupMap.xml` file.</span></span>

<span data-ttu-id="be0fb-119">詳しい説明の前に、まず完全な `SourceAppxContentGroupMap.xml` ファイルを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="be0fb-119">Before we get in to the details, here's an example of a simple, complete `SourceAppxContentGroupMap.xml` file:</span></span>

```xml
<?xml version="1.0" encoding="utf-8"?>  
<ContentGroupMap xmlns="http://schemas.microsoft.com/appx/2016/sourcecontentgroupmap" 
                 xmlns:s="http://schemas.microsoft.com/appx/2016/sourcecontentgroupmap"> 
    <Required>
        <ContentGroup Name="Required">
            <File Name="StreamingTestApp.exe"/>
        </ContentGroup>
    </Required>
    <Automatic>
        <ContentGroup Name="Level2">
            <File Name="Assets\Level2\*"/>
        </ContentGroup>
        <ContentGroup Name="Level3">
            <File Name="Assets\Level3\*"/>
        </ContentGroup>
    </Automatic>
</ContentGroupMap>
```

<span data-ttu-id="be0fb-120">コンテンツ グループ マップには、主要なコンポーネントが 2 つあります。1 つは、必須コンテンツ グループを格納する **Required** セクション、もう 1 つは、複数の自動コンテンツ グループを格納できる **Automatic** セクションです。</span><span class="sxs-lookup"><span data-stu-id="be0fb-120">There are two main components to a content group map: the **required** section, which contains the required content group, and the **automatic** section, which can contain multiple automatic content groups.</span></span>

### <a name="required-content-group"></a><span data-ttu-id="be0fb-121">必須コンテンツ グループ</span><span class="sxs-lookup"><span data-stu-id="be0fb-121">Required content group</span></span>

<span data-ttu-id="be0fb-122">必須コンテンツ グループは、`SourceAppxContentGroupMap.xml` の `<Required>` 要素に含まれる 1 つのコンテンツ グループです。</span><span class="sxs-lookup"><span data-stu-id="be0fb-122">The required content group is a single content group within the `<Required>` element of the `SourceAppxContentGroupMap.xml`.</span></span> <span data-ttu-id="be0fb-123">必須コンテンツ グループには、最小限のユーザー エクスペリエンスでアプリを起動するために必要となる重要なファイルをすべて含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-123">A required content group should contain all of the essential files necessary to launch the app with the minimal user experience.</span></span> <span data-ttu-id="be0fb-124">.NET Native のコンパイルに対応するには、すべてのコード (アプリケーションの実行可能ファイル) を必須グループに含めて、その他の資産やファイルは自動グループに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-124">Due to .NET Native compilation, all code (the application executable) must be part of the required group, leaving assets and other files for the automatic groups.</span></span>

<span data-ttu-id="be0fb-125">たとえば、アプリがゲームの場合は、ゲームのメイン メニューやホーム画面に使用するファイルを必須グループに含めます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-125">For example, if your app is a game, the required group may include files used in the main menu or game home screen.</span></span>

<span data-ttu-id="be0fb-126">さきほど例示した元の `SourceAppxContentGroupMap.xml` ファイルのスニペットを次に示します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-126">Here's the snippet from our original `SourceAppxContentGroupMap.xml` example file:</span></span> 
```xml
<Required>
    <ContentGroup Name="Required">
        <File Name="StreamingTestApp.exe"/>
    </ContentGroup>
</Required>
```

<span data-ttu-id="be0fb-127">いくつか重要な点があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-127">There are a few important things to notice here:</span></span>

- <span data-ttu-id="be0fb-128">`<Required>` 要素内の `<ContentGroup>` は、\*\*\*\*"Required" という名前にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-128">The `<ContentGroup>` within the `<Required>` element **must** be named "Required."</span></span> <span data-ttu-id="be0fb-129">この名前は、必須コンテンツ グループ用だけに使用するために予約されており、最終的なコンテンツ グループ マップに含まれる他の `<ContentGroup>` には使用できません。</span><span class="sxs-lookup"><span data-stu-id="be0fb-129">This name is reserved for the required content group only, and cannot be used with any other `<ContentGroup>` in the final content group map.</span></span>
- <span data-ttu-id="be0fb-130">ここにある `<ContentGroup>` は 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="be0fb-130">There's only one `<ContentGroup>`.</span></span> <span data-ttu-id="be0fb-131">必須ファイルのグループは 1 つだけにする必要があるため、これは意図どおりです。</span><span class="sxs-lookup"><span data-stu-id="be0fb-131">This is intentional, since there should be only one group of essential files.</span></span>
- <span data-ttu-id="be0fb-132">この例では、`.exe` ファイルは 1 つです。</span><span class="sxs-lookup"><span data-stu-id="be0fb-132">The file in this example is a single `.exe` file.</span></span> <span data-ttu-id="be0fb-133">必須コンテンツ グループは、1 つのファイルに限定せず、複数のファイルにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-133">A required content group isn't restricted to one file, there can be several.</span></span> 

<span data-ttu-id="be0fb-134">このファイルの記述を開始する簡単な方法の 1 つは、好みのテキスト エディターで新しいページを開き、ファイルを [名前を付けて保存] でアプリのプロジェクト フォルダーに保存して、新しく作成したファイルに `SourceAppxContentGroupMap.xml` という名前を付けることです。</span><span class="sxs-lookup"><span data-stu-id="be0fb-134">An easy way to get started writing this file is to open up a new page in your favorite text editor, do a quick "Save As" of your file to your app's project folder, and name your newly created file: `SourceAppxContentGroupMap.xml`.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="be0fb-135">C++ の UWP アプリを開発している場合は、`SourceAppxContentGroupMap.xml` のファイル プロパティを調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-135">If you are developing a C++ UWP app, you will need to adjust the file properties of your `SourceAppxContentGroupMap.xml`.</span></span> <span data-ttu-id="be0fb-136">`Content` プロパティを **true**、`File Type` プロパティを **XML File** に設定します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-136">Set the `Content` property to **true** and the `File Type` property to **XML File**.</span></span> 

<span data-ttu-id="be0fb-137">`SourceAppxContentGroupMap.xml` を作成する場合、ワイルドカードをファイル名に使用できることを利用すると便利です。詳しくは、「[ワイルドカードの使用のヒントとコツ](#wildcards)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be0fb-137">When you're creating the `SourceAppxContentGroupMap.xml`, it's helpful to take advantage of using wildcards in file names, for more info, see the [Tips and tricks for using wildcards](#wildcards) section.</span></span>

<span data-ttu-id="be0fb-138">Visual Studio でアプリを開発した場合は、必須コンテンツ グループに以下を含めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="be0fb-138">If you developed your app using Visual Studio, it's recommended that you include this in your required content group:</span></span>

```xml
<File Name="*"/>
<File Name="WinMetadata\*"/>
<File Name="Properties\*"/>
<File Name="Assets\*Logo*"/>
<File Name="Assets\*SplashScreen*"/>
```

<span data-ttu-id="be0fb-139">単一ワイルドカードのファイル名を追加すると、アプリの実行可能ファイルや DLL など、Visual Studio からプロジェクト ディレクトリに追加されたファイルが含められます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-139">Adding the single wildcard file name will include files added to the project directory from Visual Studio, such as the app executable or DLLs.</span></span> <span data-ttu-id="be0fb-140">WinMetadata フォルダーと Properties フォルダーには、Visual Studio によって生成された他のフォルダーが含められます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-140">The WinMetadata and Properties folders are to include the other folders Visual Studio generates.</span></span> <span data-ttu-id="be0fb-141">Assets のワイルドカードでは、アプリをインストールするために必要なロゴとスプラッシュ画面の画像が選択されます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-141">The Assets wildcards are to select the Logo and SplashScreen images that are necessary for the app to be installed.</span></span>

<span data-ttu-id="be0fb-142">ダブル ワイルドカード "\*\*" をファイル構造のルートに使用して、プロジェクト内のすべてのファイルを含めることはできません。`SourceAppxContentGroupMap.xml` を最終的な `AppxContentGroupMap.xml` に変換する際にエラーとなります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-142">Note that you cannot use the double wild card, "\*\*", at the root of the file structure to include every file in the project since this will fail when attempting to convert `SourceAppxContentGroupMap.xml` to the final `AppxContentGroupMap.xml`.</span></span>

<span data-ttu-id="be0fb-143">また、フットプリント ファイル (AppxManifest.xml、AppxSignature.p7x、resources.pri など) をコンテンツ グループ マップに含めることができない点にも注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-143">It's also important to note that footprint files (AppxManifest.xml, AppxSignature.p7x, resources.pri, etc.) should not be included in the content group map.</span></span> <span data-ttu-id="be0fb-144">指定したファイルドカード ファイル名のいずれかにフットプリント ファイルが含まれている場合、これらは無視されます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-144">If footprint files are included within one of the wildcard file names you specify, they will be ignored.</span></span>

### <a name="automatic-content-groups"></a><span data-ttu-id="be0fb-145">自動コンテンツ グループ</span><span class="sxs-lookup"><span data-stu-id="be0fb-145">Automatic content groups</span></span>

<span data-ttu-id="be0fb-146">自動コンテンツ グループは、ユーザーがダウンロード済みのコンテンツ グループを操作している間に、バックグラウンドでダウンロードされる資産です。</span><span class="sxs-lookup"><span data-stu-id="be0fb-146">Automatic content groups are the assets that are downloaded in the background while the user is interacting with the already downloaded content groups.</span></span> <span data-ttu-id="be0fb-147">自動コンテンツ グループには、アプリの起動に不可欠ではない追加のファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-147">These contain any additional files that are not essential to launching the app.</span></span> <span data-ttu-id="be0fb-148">たとえば、自動コンテンツ グループを複数のレベルに分割し、各レベルを個別のコンテンツ グループとして定義することができます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-148">For example, you could break up automatic content groups in to different levels, defining each level as a separate content group.</span></span> <span data-ttu-id="be0fb-149">必須コンテンツ グループのセクションでも説明したように、.NET Native のコンパイルに対応するには、すべてのコード (アプリケーションの実行可能ファイル) を必須グループに含めて、その他の資産やファイルは自動グループに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-149">As noted in the required content group section: due to .NET Native compilation, all code (the application executable) must be part of the required group, leaving assets and other files for the automatic groups.</span></span>

<span data-ttu-id="be0fb-150">`SourceAppxContentGroupMap.xml` の例で自動コンテンツ グループをもう少し詳しく見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="be0fb-150">Let's take a closer look at the automatic content group from our `SourceAppxContentGroupMap.xml` example:</span></span>
```xml
<Automatic>
    <ContentGroup Name="Level2">
        <File Name="Assets\Level2\*"/>
    </ContentGroup>
    <ContentGroup Name="Level3">
        <File Name="Assets\Level3\*"/>
    </ContentGroup>
</Automatic>
```

<span data-ttu-id="be0fb-151">自動グループのレイアウトは必須グループによく似ていますが、いくつか例外もあります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-151">The layout of the automatic group is pretty similar to the required group, with a few exceptions:</span></span>

- <span data-ttu-id="be0fb-152">複数のコンテンツ グループがあります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-152">There are multiple content groups.</span></span>
- <span data-ttu-id="be0fb-153">自動コンテンツ グループには一意の名前を指定できますが、必須コンテンツ グループ用に予約されている "Required" という名前は例外です。</span><span class="sxs-lookup"><span data-stu-id="be0fb-153">Automatic content groups can have unique names except for the name "Required" which is reserved for the required content group.</span></span>
- <span data-ttu-id="be0fb-154">自動コンテンツ グループに、必須コンテンツ グループのファイルを含めることはできません\*\*\*\*。</span><span class="sxs-lookup"><span data-stu-id="be0fb-154">Automatic content groups cannot contain **any** files from the required content group.</span></span> 
- <span data-ttu-id="be0fb-155">自動コンテンツ グループには、他の自動コンテンツ グループにも含まれているファイルを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-155">An automatic content group can contain files that are also in other automatic content groups.</span></span> <span data-ttu-id="be0fb-156">そのファイルは 1 回だけ、そのファイルを含む最初の自動コンテンツ グループと共にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-156">The files will be downloaded only once, and will be downloaded with the first automatic content group that contains them.</span></span>

#### <span data-ttu-id="be0fb-157">ワイルドカードの使用のヒントとコツ<a name="wildcards"></a></span><span class="sxs-lookup"><span data-stu-id="be0fb-157">Tips and tricks for using wildcards<a name="wildcards"></a></span></span>

<span data-ttu-id="be0fb-158">コンテンツ グループ マップのファイル レイアウトでは、常にプロジェクトのルート フォルダーが基準になります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-158">The file layout for content group maps is always relative to your project root folder.</span></span>

<span data-ttu-id="be0fb-159">ここで使用している例では、"Assets\Level2" または "Assets\Level3" のうちいずれかのファイル レベル内のファイルをすべて取得するために、両方の `<ContentGroup>` 要素内でワイルドカードが使用されています。</span><span class="sxs-lookup"><span data-stu-id="be0fb-159">In our example, wildcards are used within both `<ContentGroup>` elements to retrieve all files within one file level of "Assets\Level2" or "Assets\Level3."</span></span> <span data-ttu-id="be0fb-160">これより深いフォルダー構造を使っている場合は、次のようにダブル ワイルドカードを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-160">If you're using a deeper folder structure, you can use the double wildcard:</span></span>

```xml
<ContentGroup Name="Level2">
    <File Name="Assets\Level2\**"/>
</ContentGroup>
```

<span data-ttu-id="be0fb-161">ファイル名としてワイルドカードと共に文字列を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-161">You can also use wildcards with text for file names.</span></span> <span data-ttu-id="be0fb-162">たとえば、"Assets" 内でファイル名に "Level2" という文字列が含まれるすべてのファイルを含める場合は、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="be0fb-162">For example, if you want to include every file in your "Assets" folder with a file name that contains "Level2" you can use something like this:</span></span>

```xml
<ContentGroup Name="Level2">
    <File Name="Assets\*Level2*"/>
</ContentGroup>
```

## <a name="convert-sourceappxcontentgroupmapxml-to-appxcontentgroupmapxml"></a><span data-ttu-id="be0fb-163">SourceAppxContentGroupMap.xml を AppxContentGroupMap.xml に変換する</span><span class="sxs-lookup"><span data-stu-id="be0fb-163">Convert SourceAppxContentGroupMap.xml to AppxContentGroupMap.xml</span></span>

<span data-ttu-id="be0fb-164">`SourceAppxContentGroupMap.xml` を最終的なバージョンである `AppxContentGroupMap.xml` に変換するには、Visual Studio 2017 または **MakeAppx.exe** コマンド ライン ツールを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="be0fb-164">To convert the `SourceAppxContentGroupMap.xml` to the final version, `AppxContentGroupMap.xml`, you can use Visual Studio 2017 or the **MakeAppx.exe** command line tool.</span></span>

<span data-ttu-id="be0fb-165">Visual Studio を使ってコンテンツ グループのマップを変換するには:</span><span class="sxs-lookup"><span data-stu-id="be0fb-165">To use Visual Studio to convert your content group map:</span></span>
1. <span data-ttu-id="be0fb-166">`SourceAppxContentGroupMap.xml` をプロジェクト フォルダーに追加します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-166">Add the `SourceAppxContentGroupMap.xml` to your project folder</span></span>
2. <span data-ttu-id="be0fb-167">[プロパティ] ウィンドウで、`SourceAppxContentGroupMap.xml` のビルド アクションを "AppxSourceContentGroupMap" に変更します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-167">Change the Build Action of the `SourceAppxContentGroupMap.xml`to "AppxSourceContentGroupMap" in the Properties window</span></span>
2. <span data-ttu-id="be0fb-168">ソリューション エクスプローラーで、プロジェクトを右クリックします。</span><span class="sxs-lookup"><span data-stu-id="be0fb-168">Right click the project in the solution explorer</span></span>
3. <span data-ttu-id="be0fb-169">[ストア] ->[コンテンツ グループ マップ ファイルの変換] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-169">Navigate to Store -> Convert Content Group Map File</span></span>

<span data-ttu-id="be0fb-170">アプリの開発に Visual Studio を使用していない場合や、コマンドラインの使用が望ましい場合は、**MakeAppx.exe** ツールを使って `SourceAppxContentGroupMap.xml` を変換します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-170">If you didn't develop your app in Visual Studio, or if you just prefer using the command line, use the **MakeAppx.exe** tool to convert your `SourceAppxContentGroupMap.xml`.</span></span> 

<span data-ttu-id="be0fb-171">単純な **MakeAppx.exe** コマンドは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="be0fb-171">A simple **MakeAppx.exe** command might look something like this:</span></span>
```syntax
MakeAppx convertCGM /s MyApp\SourceAppxContentGroupMap.xml /f MyApp\AppxContentGroupMap.xml /d MyApp\
```

<span data-ttu-id="be0fb-172">/s オプションでは `SourceAppxContentGroupMap.xml` のパス、/f では `AppxContentGroupMap.xml` のパスを指定します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-172">The /s option specifies the path to the `SourceAppxContentGroupMap.xml`, and /f specifies the path to the `AppxContentGroupMap.xml`.</span></span> <span data-ttu-id="be0fb-173">最後の /d オプションは、ファイル名ワイルドカードの展開時に使用するディレクトリ (この場合はアプリのプロジェクト ディレクトリ) を指定します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-173">The final option, /d, specifies which directory should be used for expanding file name wildcards, in this case, its the app project directory.</span></span>

<span data-ttu-id="be0fb-174">**MakeAppx.exe** で使用できるオプションについて詳しくは、コマンド プロンプトを開き、**MakeAppx.exe** に移動して、次のように入力します。</span><span class="sxs-lookup"><span data-stu-id="be0fb-174">For more information about options you can use with **MakeAppx.exe**, open a command prompt, navigate to **MakeAppx.exe** and enter:</span></span>

```syntax
MakeAppx convertCGM /?
```

<span data-ttu-id="be0fb-175">これで、アプリ用に最終的な `AppxContentGroupMap.xml` を準備できました。</span><span class="sxs-lookup"><span data-stu-id="be0fb-175">That's all you'll need to get your final `AppxContentGroupMap.xml` ready for your app!</span></span> <span data-ttu-id="be0fb-176">ある引き続きを行う前に、アプリが Microsoft Store の準備が整います。</span><span class="sxs-lookup"><span data-stu-id="be0fb-176">There's still more to do before your app is fully ready for the Microsoft Store.</span></span> <span data-ttu-id="be0fb-177">UWP アプリ ストリーミング インストールをアプリに追加する完全なプロセスについては、[こちらのブログ記事](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="be0fb-177">For more information on the complete process of adding UWP App Streaming Install to your app, check out [this blog post](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/).</span></span>
