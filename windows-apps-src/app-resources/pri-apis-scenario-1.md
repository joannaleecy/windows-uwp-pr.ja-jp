---
Description: このシナリオでは、カスタム ビルド システムを表す新しいアプリを作成します。 リソース インデクサーを作成し、文字列とその他の種類のリソースを追加します。 次に、PRI ファイルを生成してダンプします。
title: シナリオ 1 文字列リソースとアセット ファイルから PRI ファイルを生成する
template: detail.hbs
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 0ccb9447e9594f71907f0da5d0e15f9c6c65bb6b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622757"
---
# <a name="scenario-1-generate-a-pri-file-from-string-resources-and-asset-files"></a><span data-ttu-id="27dba-106">シナリオ 1:文字列リソースと資産ファイルからの PRI ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-106">Scenario 1: Generate a PRI file from string resources and asset files</span></span>
<span data-ttu-id="27dba-107">このシナリオでは、[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用してカスタム ビルド システムを表す新しいアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-107">In this scenario, we'll use the [package resource indexing (PRI) APIs](https://msdn.microsoft.com/library/windows/desktop/mt845690) to make a new app to represent our custom build system.</span></span> <span data-ttu-id="27dba-108">このカスタム ビルド システムの目的は、対象の UWP アプリの PRI ファイルを作成することです。</span><span class="sxs-lookup"><span data-stu-id="27dba-108">The purpose of this custom build system, remember, is to create PRI files for a target UWP app.</span></span> <span data-ttu-id="27dba-109">そのため、このチュートリアルの一部として、その対象とする UWP アプリのリソースを表す、(文字列、およびその他の種類のリソースを含む) サンプルのリソース ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-109">So, as part of this walkthrough, we'll create some sample resource files (containing strings, and other kinds of resources) to represent that target UWP app's resources.</span></span>

## <a name="new-project"></a><span data-ttu-id="27dba-110">新しいプロジェクト</span><span class="sxs-lookup"><span data-stu-id="27dba-110">New project</span></span>
<span data-ttu-id="27dba-111">まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-111">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="27dba-112">**Visual C++ Windows コンソール アプリケーション** プロジェクトを作成し、*CBSConsoleApp* ("カスタム ビルド システムのコンソール アプリ" を表す) という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="27dba-112">Create a **Visual C++ Windows Console Application** project, and name it *CBSConsoleApp* (for "custom build system console app").</span></span>

<span data-ttu-id="27dba-113">**[ソリューション プラットフォーム]** ドロップダウンから *[x64]* を選択します。</span><span class="sxs-lookup"><span data-stu-id="27dba-113">Choose *x64* from the **Solution Platforms** drop-down.</span></span>

## <a name="headers-static-library-and-dll"></a><span data-ttu-id="27dba-114">ヘッダー、静的ライブラリ、dll</span><span class="sxs-lookup"><span data-stu-id="27dba-114">Headers, static library, and dll</span></span>
<span data-ttu-id="27dba-115">PRI API は、MrmResourceIndexer.h ヘッダー ファイル (`%ProgramFiles(x86)%\Windows Kits\10\Include\<WindowsTargetPlatformVersion>\um\` にインストールされます) で宣言されています。</span><span class="sxs-lookup"><span data-stu-id="27dba-115">The PRI APIs are declared in the MrmResourceIndexer.h header file (which is installed to `%ProgramFiles(x86)%\Windows Kits\10\Include\<WindowsTargetPlatformVersion>\um\`).</span></span> <span data-ttu-id="27dba-116">ファイル `CBSConsoleApp.cpp` を開き、そのヘッダーと、その他の必要になるいくつかのヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="27dba-116">Open the file `CBSConsoleApp.cpp` and include the header along with some other headers that you'll need.</span></span>

```cppwinrt
#include <string>
#include <windows.h>
#include <MrmResourceIndexer.h>
```

<span data-ttu-id="27dba-117">API は MrmSupport.dll に実装されています。MrmSupport.dll には、静的ライブラリ MrmSupport.lib にリンクすることでアクセスします。</span><span class="sxs-lookup"><span data-stu-id="27dba-117">The APIs are implemented in MrmSupport.dll, which you access by linking to the static library MrmSupport.lib.</span></span> <span data-ttu-id="27dba-118">プロジェクトの **[プロパティ]** を開き、**[リンカー]** > **[入力]** の順にクリックし、**AdditionalDependencies** を編集して `MrmSupport.lib` を追加します。</span><span class="sxs-lookup"><span data-stu-id="27dba-118">Open your project's **Properties**, click **Linker** > **Input**, edit **AdditionalDependencies** and add `MrmSupport.lib`.</span></span>

<span data-ttu-id="27dba-119">ソリューションをビルドし、`MrmSupport.dll` を `C:\Program Files (x86)\Windows Kits\10\bin\<WindowsTargetPlatformVersion>\x64\` からビルドの出力フォルダー (`C:\Users\%USERNAME%\source\repos\CBSConsoleApp\x64\Debug\` など) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="27dba-119">Build the Solution, and then copy `MrmSupport.dll` from `C:\Program Files (x86)\Windows Kits\10\bin\<WindowsTargetPlatformVersion>\x64\` to your build output folder (probably `C:\Users\%USERNAME%\source\repos\CBSConsoleApp\x64\Debug\`).</span></span>

<span data-ttu-id="27dba-120">次のヘルパー関数が必要になるため、`CBSConsoleApp.cpp` に追加します。</span><span class="sxs-lookup"><span data-stu-id="27dba-120">Add the following helper function to `CBSConsoleApp.cpp`, since we'll be needing it.</span></span>

```cppwinrt
inline void ThrowIfFailed(HRESULT hr)
{
    if (FAILED(hr))
    {
        // Set a breakpoint on this line to catch Win32 API errors.
        throw new std::exception();
    }
}
```

<span data-ttu-id="27dba-121">`main()` 関数で、呼び出しを追加し、COM の初期化と初期化解除を行います。</span><span class="sxs-lookup"><span data-stu-id="27dba-121">In the `main()` function, add calls to initialize and uninitialize COM.</span></span>

```cppwinrt
int main()
{
    ::ThrowIfFailed(::CoInitializeEx(nullptr, COINIT_MULTITHREADED));
    
    // More code will go here.
    
    ::CoUninitialize();
}
```

## <a name="resource-files-belonging-to-the-target-uwp-app"></a><span data-ttu-id="27dba-122">対象の UWP アプリに属するリソース ファイル</span><span class="sxs-lookup"><span data-stu-id="27dba-122">Resource files belonging to the target UWP app</span></span>
<span data-ttu-id="27dba-123">ここでは、その対象とする UWP アプリのリソースを表す、(文字列、およびその他の種類のリソースを含む) サンプルのリソース ファイルが必要になります。</span><span class="sxs-lookup"><span data-stu-id="27dba-123">Now we'll need some sample resource files (containing strings, and other kinds of resources) to represent the target UWP app's resources.</span></span> <span data-ttu-id="27dba-124">これらは、もちろん、ファイル システム上の任意の場所に配置することができます。</span><span class="sxs-lookup"><span data-stu-id="27dba-124">These, of course, can be located anywhere on your file system.</span></span> <span data-ttu-id="27dba-125">ただし、このチュートリアルでは、すべてを 1 か所にまとめるために、CBSConsoleApp のプロジェクト フォルダーにそれらのファイルを配置すると便利です。</span><span class="sxs-lookup"><span data-stu-id="27dba-125">But for this walkthrough it'll be convenient to put them in the project folder of CBSConsoleApp so that everything is in one place.</span></span> <span data-ttu-id="27dba-126">それらのリソース ファイルをファイル システムに追加するだけです。CBSConsoleApp プロジェクトには追加しません。</span><span class="sxs-lookup"><span data-stu-id="27dba-126">You only need to add these resource files to the file system; don't add them to the CBSConsoleApp project.</span></span>

<span data-ttu-id="27dba-127">`CBSConsoleApp.vcxproj` を含む同じフォルダー内には、`UWPAppProjectRootFolder` という名前の新しいサブフォルダーを追加します。</span><span class="sxs-lookup"><span data-stu-id="27dba-127">Inside the same folder that contains `CBSConsoleApp.vcxproj`, add a new subfolder named `UWPAppProjectRootFolder`.</span></span> <span data-ttu-id="27dba-128">新しいサブフォルダー内には、次のサンプル リソース ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-128">Inside that new subfolder, create these sample resource files.</span></span>

### <a name="uwpappprojectrootfoldersample-imagepng"></a><span data-ttu-id="27dba-129">\UWPAppProjectRootFolder\sample-image.png</span><span class="sxs-lookup"><span data-stu-id="27dba-129">\UWPAppProjectRootFolder\sample-image.png</span></span>
<span data-ttu-id="27dba-130">このファイルには、任意の PNG 画像を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="27dba-130">This file can contain any PNG image.</span></span>

### <a name="uwpappprojectrootfolderresourcesresw"></a><span data-ttu-id="27dba-131">\UWPAppProjectRootFolder\resources.resw</span><span class="sxs-lookup"><span data-stu-id="27dba-131">\UWPAppProjectRootFolder\resources.resw</span></span>
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString1">
        <value>LocalizedString1-neutral</value>
    </data>
    <data name="LocalizedString2">
        <value>LocalizedString2-neutral</value>
    </data>
    <data name="NeutralOnlyString">
        <value>NeutralOnlyString-neutral</value>
    </data>
</root>
```

### <a name="uwpappprojectrootfolderde-deresourcesresw"></a><span data-ttu-id="27dba-132">\UWPAppProjectRootFolder\de-DE\resources.resw</span><span class="sxs-lookup"><span data-stu-id="27dba-132">\UWPAppProjectRootFolder\de-DE\resources.resw</span></span>
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString2">
        <value>LocalizedString2-de-DE</value>
    </data>
</root>
```

### <a name="uwpappprojectrootfolderen-usresourcesresw"></a><span data-ttu-id="27dba-133">\UWPAppProjectRootFolder\en-US\resources.resw</span><span class="sxs-lookup"><span data-stu-id="27dba-133">\UWPAppProjectRootFolder\en-US\resources.resw</span></span>
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString1">
        <value>LocalizedString1-en-US</value>
    </data>
    <data name="EnOnlyString">
        <value>EnOnlyString-en-US</value>
    </data>
</root>
```

## <a name="index-the-resources-and-create-a-pri-file"></a><span data-ttu-id="27dba-134">リソースにインデックスを付け、PRI ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="27dba-134">Index the resources, and create a PRI file</span></span>
<span data-ttu-id="27dba-135">`main()` 関数で、COM を初期化するための呼び出しの前に、必要となるいくつかの文字列を宣言します。また、PRI ファイルを生成する出力フォルダーも作成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-135">In the `main()` function, before the call to initialize COM, declare some strings that we'll need, and also create the output folder in which we'll be generating our PRI file.</span></span>

```cppwinrt
std::wstring projectRootFolderUWPApp{ L"UWPAppProjectRootFolder" };
std::wstring generatedPRIsFolder{ projectRootFolderUWPApp + L"\\Generated PRIs" };
std::wstring filePathPRI{ generatedPRIsFolder + L"\\resources.pri" };
std::wstring filePathPRIDumpBasic{ generatedPRIsFolder + L"\\resources-pri-dump-basic.xml" };

::CreateDirectory(generatedPRIsFolder.c_str(), nullptr);
```

<span data-ttu-id="27dba-136">COM を初期化するための呼び出しの直後に、リソース インデクサー ハンドルを宣言し、[**MrmCreateResourceIndexer**](/windows/desktop/menurc/mrmcreateresourceindexer) を呼び出してリソース インデクサーを作成します。</span><span class="sxs-lookup"><span data-stu-id="27dba-136">Immediately after the call to Initialize COM, declare a resource indexer handle and then call [**MrmCreateResourceIndexer**](/windows/desktop/menurc/mrmcreateresourceindexer) to create a resource indexer.</span></span>

```cppwinrt
MrmResourceIndexerHandle indexer;
::ThrowIfFailed(::MrmCreateResourceIndexer(
    L"OurUWPApp",
    projectRootFolderUWPApp.c_str(),
    MrmPlatformVersion::MrmPlatformVersion_Windows10_0_0_0,
    L"language-en_scale-100_contrast-standard",
    &indexer));
```

<span data-ttu-id="27dba-137">**MrmCreateResourceIndexer** に渡される引数について、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="27dba-137">Here's an explanation of the arguments being passed to **MrmCreateResourceIndexer**.</span></span>

- <span data-ttu-id="27dba-138">後でこのリソース インデクサーから PRI ファイルを生成したときにリソース マップ名として使用する、対象の UWP アプリのパッケージ ファミリ名です。</span><span class="sxs-lookup"><span data-stu-id="27dba-138">The package family name of our target UWP app, which will be used as the resource map name when we later generate a PRI file from this resource indexer.</span></span>
- <span data-ttu-id="27dba-139">対象の UWP アプリのプロジェクト ルートです。</span><span class="sxs-lookup"><span data-stu-id="27dba-139">The project root of our target UWP app.</span></span> <span data-ttu-id="27dba-140">つまり、リソース ファイルのパスです。</span><span class="sxs-lookup"><span data-stu-id="27dba-140">In other words, the path to our resource files.</span></span> <span data-ttu-id="27dba-141">これは、同じリソース インデクサーへの以降の API 呼び出しでそのルートの相対パスを指定できるようにするために指定します。</span><span class="sxs-lookup"><span data-stu-id="27dba-141">We specify this so that we can then specify paths relative to that root in subsequent API calls to the same resource indexer.</span></span>
- <span data-ttu-id="27dba-142">対象にする Windows のバージョンです。</span><span class="sxs-lookup"><span data-stu-id="27dba-142">The version of Windows that we want to target.</span></span>
- <span data-ttu-id="27dba-143">既定のリソース修飾子の一覧です。</span><span class="sxs-lookup"><span data-stu-id="27dba-143">A list of default resource qualifiers.</span></span>
- <span data-ttu-id="27dba-144">関数で設定できるようにするための、リソース インデクサー ハンドルへのポインターです。</span><span class="sxs-lookup"><span data-stu-id="27dba-144">A pointer to our resource indexer handle so that the function can set it.</span></span>

<span data-ttu-id="27dba-145">次の手順では、先ほど作成したリソース インデクサーにリソースを追加します。</span><span class="sxs-lookup"><span data-stu-id="27dba-145">The next step is to add our resources to the resource indexer that we just created.</span></span> <span data-ttu-id="27dba-146">`resources.resw` ターゲットの UWP アプリのニュートラル文字列を含むリソース ファイル (.resw) です。</span><span class="sxs-lookup"><span data-stu-id="27dba-146">`resources.resw` is a Resources File (.resw) that contains the neutral strings for our target UWP app.</span></span> <span data-ttu-id="27dba-147">その内容を表示する場合は、(このトピック内で) 上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="27dba-147">Scroll up (in this topic) if you want to see its contents.</span></span> <span data-ttu-id="27dba-148">`de-DE\resources.resw` ドイツ語の文字列を格納および`en-US\resources.resw`英語の文字列。</span><span class="sxs-lookup"><span data-stu-id="27dba-148">`de-DE\resources.resw` contains our German strings, and `en-US\resources.resw` our English strings.</span></span> <span data-ttu-id="27dba-149">リソース ファイル内の文字列リソースをリソース インデクサーに追加するには、[**MrmIndexResourceContainerAutoQualifiers**](/windows/desktop/menurc/mrmindexresourcecontainerautoqualifiers) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="27dba-149">To add the string resources inside a Resources File to a resource indexer, you call [**MrmIndexResourceContainerAutoQualifiers**](/windows/desktop/menurc/mrmindexresourcecontainerautoqualifiers).</span></span> <span data-ttu-id="27dba-150">3 番目に、[**MrmIndexFile**](/windows/desktop/menurc/mrmindexfile) 関数を呼び出して、中立的なイメージ リソースを含むファイルをリソース インデクサーに追加します。</span><span class="sxs-lookup"><span data-stu-id="27dba-150">Thirdly, we call the [**MrmIndexFile**](/windows/desktop/menurc/mrmindexfile) function to a file containing a neutral image resource to the resource indexer.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"resources.resw"));
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"de-DE\\resources.resw"));
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"en-US\\resources.resw"));
::ThrowIfFailed(::MrmIndexFile(indexer, L"ms-resource:///Files/sample-image.png", L"sample-image.png", L""));
```

<span data-ttu-id="27dba-151">**MrmIndexFile** の呼び出しで、値 L"ms-resource:///Files/sample-image.png" はリソース uri です。</span><span class="sxs-lookup"><span data-stu-id="27dba-151">In the call to **MrmIndexFile**, the value L"ms-resource:///Files/sample-image.png" is the resource uri.</span></span> <span data-ttu-id="27dba-152">最初のパス セグメントは "Files" で、これが後でこのリソース インデクサーから PRI ファイルを生成したときにリソース マップのサブツリー名として使用されます。</span><span class="sxs-lookup"><span data-stu-id="27dba-152">The first path segment is "Files", and that's what will be used as the resource map subtree name when we later generate a PRI file from this resource indexer.</span></span>

<span data-ttu-id="27dba-153">リソース ファイルに関するリソース インデクサーの概要を説明したので、[**MrmCreateResourceFile**](/windows/desktop/menurc/mrmcreateresourcefile) 関数を呼び出してディスクに PRI ファイルを自動的に生成できるようにしましょう。</span><span class="sxs-lookup"><span data-stu-id="27dba-153">Having briefed the resource indexer about our resource files, it's time to have it generate us a PRI file on disk by calling the [**MrmCreateResourceFile**](/windows/desktop/menurc/mrmcreateresourcefile) function.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmCreateResourceFile(indexer, MrmPackagingModeStandaloneFile, MrmPackagingOptionsNone, generatedPRIsFolder.c_str()));
```

<span data-ttu-id="27dba-154">この時点で、`resources.pri` という名前の PRI ファイルが `Generated PRIs` という名前のフォルダー内に作成されました。</span><span class="sxs-lookup"><span data-stu-id="27dba-154">At this point, a PRI file named `resources.pri` has been created inside a folder named `Generated PRIs`.</span></span> <span data-ttu-id="27dba-155">これで、リソース インデクサーの作業が完了したので、[**MrmDestroyIndexerAndMessages**](/windows/desktop/menurc/mrmdestroyindexerandmessages) を呼び出して、そのハンドルを破棄し、割り当てられたマシン リソースをリリースします。</span><span class="sxs-lookup"><span data-stu-id="27dba-155">Now that we're done with the resource indexer, we call [**MrmDestroyIndexerAndMessages**](/windows/desktop/menurc/mrmdestroyindexerandmessages) to destroy its handle and release any machine resources that it allocated.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmDestroyIndexerAndMessages(indexer));
```

<span data-ttu-id="27dba-156">PRI ファイルはバイナリであるため、バイナリ PRI ファイルをそれに対応する XML にダンプすると、先ほど生成したものを表示するのが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="27dba-156">Since a PRI file is binary, it's going to be easier to view what we've just generated if we dump the binary PRI file to its XML equivalent.</span></span> <span data-ttu-id="27dba-157">呼び出し[ **MrmDumpPriFile** ](/windows/desktop/menurc/mrmdumpprifile)のみを実行します。</span><span class="sxs-lookup"><span data-stu-id="27dba-157">A call to [**MrmDumpPriFile**](/windows/desktop/menurc/mrmdumpprifile) does just that.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmDumpPriFile(filePathPRI.c_str(), nullptr, MrmDumpType::MrmDumpType_Basic, filePathPRIDumpBasic.c_str()));
```

<span data-ttu-id="27dba-158">**MrmDumpPriFile** に渡される引数について、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="27dba-158">Here's an explanation of the arguments being passed to **MrmDumpPriFile**.</span></span>

- <span data-ttu-id="27dba-159">ダンプする PRI ファイルのパス。</span><span class="sxs-lookup"><span data-stu-id="27dba-159">The path to the PRI file to dump.</span></span> <span data-ttu-id="27dba-160">この呼び出しでリソース インデクサーは使用しません (先ほどそれを破棄しました)。そのため完全なファイル パスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="27dba-160">We're not using the resource indexer in this call (we just destroyed it), so we need to specify a full file path.</span></span>
- <span data-ttu-id="27dba-161">スキーマ ファイルはありません。</span><span class="sxs-lookup"><span data-stu-id="27dba-161">No schema file.</span></span> <span data-ttu-id="27dba-162">スキーマの概要については、後のトピックで説明します。</span><span class="sxs-lookup"><span data-stu-id="27dba-162">We'll discuss what a schema is later in the topic.</span></span>
- <span data-ttu-id="27dba-163">単なる基本情報です。</span><span class="sxs-lookup"><span data-stu-id="27dba-163">Just the basic info.</span></span>
- <span data-ttu-id="27dba-164">作成する XML ファイルのパスです。</span><span class="sxs-lookup"><span data-stu-id="27dba-164">The path of an XML file to create.</span></span>

<span data-ttu-id="27dba-165">これは、ここで XML にダンプされる PRI ファイルに含まれる内容です。</span><span class="sxs-lookup"><span data-stu-id="27dba-165">This is what the PRI file, dumped to XML here, contains.</span></span>

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<PriInfo>
    <ResourceMap name="OurUWPApp" version="1.0" primary="true">
        <Qualifiers>
            <Language>en-US,de-DE</Language>
        </Qualifiers>
        <ResourceMapSubtree name="Files">
            <NamedResource name="sample-image.png" uri="ms-resource://OurUWPApp/Files/sample-image.png">
                <Candidate type="Path">
                    <Value>sample-image.png</Value>
                </Candidate>
            </NamedResource>
        </ResourceMapSubtree>
        <ResourceMapSubtree name="resources">
            <NamedResource name="EnOnlyString" uri="ms-resource://OurUWPApp/resources/EnOnlyString">
                <Candidate qualifiers="Language-en-US" isDefault="true" type="String">
                    <Value>EnOnlyString-en-US</Value>
                </Candidate>
            </NamedResource>
            <NamedResource name="LocalizedString1" uri="ms-resource://OurUWPApp/resources/LocalizedString1">
                <Candidate qualifiers="Language-en-US" isDefault="true" type="String">
                    <Value>LocalizedString1-en-US</Value>
                </Candidate>
                <Candidate type="String">
                    <Value>LocalizedString1-neutral</Value>
                </Candidate>
            </NamedResource>
            <NamedResource name="LocalizedString2" uri="ms-resource://OurUWPApp/resources/LocalizedString2">
                <Candidate qualifiers="Language-de-DE" type="String">
                    <Value>LocalizedString2-de-DE</Value>
                </Candidate>
                <Candidate type="String">
                    <Value>LocalizedString2-neutral</Value>
                </Candidate>
            </NamedResource>
            <NamedResource name="NeutralOnlyString" uri="ms-resource://OurUWPApp/resources/NeutralOnlyString">
                <Candidate type="String">
                    <Value>NeutralOnlyString-neutral</Value>
                </Candidate>
            </NamedResource>
        </ResourceMapSubtree>
    </ResourceMap>
</PriInfo>
```

<span data-ttu-id="27dba-166">情報は、対象の UWP アプリのパッケージ ファミリ名が付いたリソース マップから始まります。</span><span class="sxs-lookup"><span data-stu-id="27dba-166">The info begins with a resource map, which is named with the package family name of our target UWP app.</span></span> <span data-ttu-id="27dba-167">リソース マップで囲まれているのは 2 つのリソース マップ サブツリーです。1 つはインデックスを作成したファイル リソース用で、もう 1 つは文字列リソース用です。</span><span class="sxs-lookup"><span data-stu-id="27dba-167">Enclosed by the resource map are two resource map subtrees: one for the file resources that we indexed, and another for our string resources.</span></span> <span data-ttu-id="27dba-168">パッケージ ファミリ名がすべてのリソース URI に挿入されているのがわかります。</span><span class="sxs-lookup"><span data-stu-id="27dba-168">Notice how the package family name has been inserted into all of the resource URIs.</span></span>

<span data-ttu-id="27dba-169">最初の文字列リソースは、`en-US\resources.resw` の *EnOnlyString* で候補が 1 つだけあります (その候補は *language-en-US* 修飾子に一致します)。</span><span class="sxs-lookup"><span data-stu-id="27dba-169">The first string resource is *EnOnlyString* from `en-US\resources.resw`, and it has just one candidate (which matches the *language-en-US* qualifier).</span></span> <span data-ttu-id="27dba-170">次のリソースは、`resources.resw` および `en-US\resources.resw` の *LocalizedString1* です。</span><span class="sxs-lookup"><span data-stu-id="27dba-170">Next comes *LocalizedString1* from both `resources.resw` and `en-US\resources.resw`.</span></span> <span data-ttu-id="27dba-171">そのため、*language-en-US* に一致する候補と、任意のコンテキストに一致するフォールバックの中立の候補の 2 つの候補があります。</span><span class="sxs-lookup"><span data-stu-id="27dba-171">Consequently, it has two candidates: one matching *language-en-US*, and a fallback neutral candidate that matches any context.</span></span> <span data-ttu-id="27dba-172">同様に、*LocalizedString2* には、*language-de-DE* と中立の 2 つの候補があります。</span><span class="sxs-lookup"><span data-stu-id="27dba-172">Similarly, *LocalizedString2* has two candidates: *language-de-DE*, and neutral.</span></span> <span data-ttu-id="27dba-173">最後に、*NeutralOnlyString* は中立の形式だけに存在します。</span><span class="sxs-lookup"><span data-stu-id="27dba-173">And, finally, *NeutralOnlyString* only exists in neutral form.</span></span> <span data-ttu-id="27dba-174">その名前を指定して、そのリソースがローカライズされるものではないということを明確にしています。</span><span class="sxs-lookup"><span data-stu-id="27dba-174">I gave it that name to make it clear that it's not meant to be localized.</span></span>

## <a name="summary"></a><span data-ttu-id="27dba-175">概要</span><span class="sxs-lookup"><span data-stu-id="27dba-175">Summary</span></span>
<span data-ttu-id="27dba-176">このシナリオでは、[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用してリソース インデクサーを作成する方法を示しました。</span><span class="sxs-lookup"><span data-stu-id="27dba-176">In this scenario, we showed how to use the [package resource indexing (PRI) APIs](https://msdn.microsoft.com/library/windows/desktop/mt845690) to create a resource indexer.</span></span> <span data-ttu-id="27dba-177">文字列リソースとアセット ファイルをリソース インデクサーに追加しました。</span><span class="sxs-lookup"><span data-stu-id="27dba-177">We added string resources and asset files to the resource indexer.</span></span> <span data-ttu-id="27dba-178">次に、リソース インデクサーを使用して、バイナリ PRI ファイルを生成しました。</span><span class="sxs-lookup"><span data-stu-id="27dba-178">Then, we used the resource indexer to generated a binary PRI file.</span></span> <span data-ttu-id="27dba-179">最後に、期待した情報が含まれていることを確認できるように、XML の形式でバイナリ PRI ファイルをダンプしました。</span><span class="sxs-lookup"><span data-stu-id="27dba-179">And finally we dumped the binary PRI file in the form of XML so that we could confirm that it contains the info we expected.</span></span>

## <a name="important-apis"></a><span data-ttu-id="27dba-180">重要な API</span><span class="sxs-lookup"><span data-stu-id="27dba-180">Important APIs</span></span>
* [<span data-ttu-id="27dba-181">パッケージのリソース インデックス (PRI) の参照</span><span class="sxs-lookup"><span data-stu-id="27dba-181">Package resource indexing (PRI) reference</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt845690)

## <a name="related-topics"></a><span data-ttu-id="27dba-182">関連トピック</span><span class="sxs-lookup"><span data-stu-id="27dba-182">Related topics</span></span>
* [<span data-ttu-id="27dba-183">システムを構築するインデックス (PRI) Api とカスタム パッケージ リソース</span><span class="sxs-lookup"><span data-stu-id="27dba-183">Package resource indexing (PRI) APIs and custom build systems</span></span>](pri-apis-custom-build-systems.md)
