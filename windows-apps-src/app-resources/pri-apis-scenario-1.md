---
author: stevewhims
Description: In this scenario, we'll make a new app to represent our custom build system. We'll create a resource indexer and add strings and other kinds of resources to it. Then we'll generate and dump a PRI file.
title: シナリオ 1 文字列リソースとアセット ファイルから PRI ファイルを生成する
template: detail.hbs
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 7555f4a61f7798fa32d137928cde8c042a7fcdfc
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6147513"
---
# <a name="scenario-1-generate-a-pri-file-from-string-resources-and-asset-files"></a><span data-ttu-id="b1033-103">シナリオ 1: 文字列リソースとアセット ファイルから PRI ファイルを生成する</span><span class="sxs-lookup"><span data-stu-id="b1033-103">Scenario 1: Generate a PRI file from string resources and asset files</span></span>
<span data-ttu-id="b1033-104">このシナリオでは、[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用してカスタム ビルド システムを表す新しいアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="b1033-104">In this scenario, we'll use the [package resource indexing (PRI) APIs](https://msdn.microsoft.com/library/windows/desktop/mt845690) to make a new app to represent our custom build system.</span></span> <span data-ttu-id="b1033-105">このカスタム ビルド システムの目的は、対象の UWP アプリの PRI ファイルを作成することです。</span><span class="sxs-lookup"><span data-stu-id="b1033-105">The purpose of this custom build system, remember, is to create PRI files for a target UWP app.</span></span> <span data-ttu-id="b1033-106">そのため、このチュートリアルの一部として、その対象とする UWP アプリのリソースを表す、(文字列、およびその他の種類のリソースを含む) サンプルのリソース ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="b1033-106">So, as part of this walkthrough, we'll create some sample resource files (containing strings, and other kinds of resources) to represent that target UWP app's resources.</span></span>

## <a name="new-project"></a><span data-ttu-id="b1033-107">新しいプロジェクト</span><span class="sxs-lookup"><span data-stu-id="b1033-107">New project</span></span>
<span data-ttu-id="b1033-108">まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="b1033-108">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="b1033-109">**Visual C++ Windows コンソール アプリケーション** プロジェクトを作成し、*CBSConsoleApp* ("カスタム ビルド システムのコンソール アプリ" を表す) という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b1033-109">Create a **Visual C++ Windows Console Application** project, and name it *CBSConsoleApp* (for "custom build system console app").</span></span>

<span data-ttu-id="b1033-110">**[ソリューション プラットフォーム]** ドロップダウンから *[x64]* を選択します。</span><span class="sxs-lookup"><span data-stu-id="b1033-110">Choose *x64* from the **Solution Platforms** drop-down.</span></span>

## <a name="headers-static-library-and-dll"></a><span data-ttu-id="b1033-111">ヘッダー、静的ライブラリ、dll</span><span class="sxs-lookup"><span data-stu-id="b1033-111">Headers, static library, and dll</span></span>
<span data-ttu-id="b1033-112">PRI API は、MrmResourceIndexer.h ヘッダー ファイル (`%ProgramFiles(x86)%\Windows Kits\10\Include\<WindowsTargetPlatformVersion>\um\` にインストールされます) で宣言されています。</span><span class="sxs-lookup"><span data-stu-id="b1033-112">The PRI APIs are declared in the MrmResourceIndexer.h header file (which is installed to `%ProgramFiles(x86)%\Windows Kits\10\Include\<WindowsTargetPlatformVersion>\um\`).</span></span> <span data-ttu-id="b1033-113">ファイル `CBSConsoleApp.cpp` を開き、そのヘッダーと、その他の必要になるいくつかのヘッダーを含めます。</span><span class="sxs-lookup"><span data-stu-id="b1033-113">Open the file `CBSConsoleApp.cpp` and include the header along with some other headers that you'll need.</span></span>

```cppwinrt
#include <string>
#include <windows.h>
#include <MrmResourceIndexer.h>
```

<span data-ttu-id="b1033-114">API は MrmSupport.dll に実装されています。MrmSupport.dll には、静的ライブラリ MrmSupport.lib にリンクすることでアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b1033-114">The APIs are implemented in MrmSupport.dll, which you access by linking to the static library MrmSupport.lib.</span></span> <span data-ttu-id="b1033-115">プロジェクトの **[プロパティ]** を開き、**[リンカー]** > **[入力]** の順にクリックし、**AdditionalDependencies** を編集して `MrmSupport.lib` を追加します。</span><span class="sxs-lookup"><span data-stu-id="b1033-115">Open your project's **Properties**, click **Linker** > **Input**, edit **AdditionalDependencies** and add `MrmSupport.lib`.</span></span>

<span data-ttu-id="b1033-116">ソリューションをビルドし、`MrmSupport.dll` を `C:\Program Files (x86)\Windows Kits\10\bin\<WindowsTargetPlatformVersion>\x64\` からビルドの出力フォルダー (`C:\Users\%USERNAME%\source\repos\CBSConsoleApp\x64\Debug\` など) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="b1033-116">Build the Solution, and then copy `MrmSupport.dll` from `C:\Program Files (x86)\Windows Kits\10\bin\<WindowsTargetPlatformVersion>\x64\` to your build output folder (probably `C:\Users\%USERNAME%\source\repos\CBSConsoleApp\x64\Debug\`).</span></span>

<span data-ttu-id="b1033-117">次のヘルパー関数が必要になるため、`CBSConsoleApp.cpp` に追加します。</span><span class="sxs-lookup"><span data-stu-id="b1033-117">Add the following helper function to `CBSConsoleApp.cpp`, since we'll be needing it.</span></span>

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

<span data-ttu-id="b1033-118">`main()` 関数で、呼び出しを追加し、COM の初期化と初期化解除を行います。</span><span class="sxs-lookup"><span data-stu-id="b1033-118">In the `main()` function, add calls to initialize and uninitialize COM.</span></span>

```cppwinrt
int main()
{
    ::ThrowIfFailed(::CoInitializeEx(nullptr, COINIT_MULTITHREADED));
    
    // More code will go here.
    
    ::CoUninitialize();
}
```

## <a name="resource-files-belonging-to-the-target-uwp-app"></a><span data-ttu-id="b1033-119">対象の UWP アプリに属するリソース ファイル</span><span class="sxs-lookup"><span data-stu-id="b1033-119">Resource files belonging to the target UWP app</span></span>
<span data-ttu-id="b1033-120">ここでは、その対象とする UWP アプリのリソースを表す、(文字列、およびその他の種類のリソースを含む) サンプルのリソース ファイルが必要になります。</span><span class="sxs-lookup"><span data-stu-id="b1033-120">Now we'll need some sample resource files (containing strings, and other kinds of resources) to represent the target UWP app's resources.</span></span> <span data-ttu-id="b1033-121">これらは、もちろん、ファイル システム上の任意の場所に配置することができます。</span><span class="sxs-lookup"><span data-stu-id="b1033-121">These, of course, can be located anywhere on your file system.</span></span> <span data-ttu-id="b1033-122">ただし、このチュートリアルでは、すべてを 1 か所にまとめるために、CBSConsoleApp のプロジェクト フォルダーにそれらのファイルを配置すると便利です。</span><span class="sxs-lookup"><span data-stu-id="b1033-122">But for this walkthrough it'll be convenient to put them in the project folder of CBSConsoleApp so that everything is in one place.</span></span> <span data-ttu-id="b1033-123">それらのリソース ファイルをファイル システムに追加するだけです。CBSConsoleApp プロジェクトには追加しません。</span><span class="sxs-lookup"><span data-stu-id="b1033-123">You only need to add these resource files to the file system; don't add them to the CBSConsoleApp project.</span></span>

<span data-ttu-id="b1033-124">`CBSConsoleApp.vcxproj` を含む同じフォルダー内には、`UWPAppProjectRootFolder` という名前の新しいサブフォルダーを追加します。</span><span class="sxs-lookup"><span data-stu-id="b1033-124">Inside the same folder that contains `CBSConsoleApp.vcxproj`, add a new subfolder named `UWPAppProjectRootFolder`.</span></span> <span data-ttu-id="b1033-125">新しいサブフォルダー内には、次のサンプル リソース ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="b1033-125">Inside that new subfolder, create these sample resource files.</span></span>

### <a name="uwpappprojectrootfoldersample-imagepng"></a><span data-ttu-id="b1033-126">\UWPAppProjectRootFolder\sample-image.png</span><span class="sxs-lookup"><span data-stu-id="b1033-126">\UWPAppProjectRootFolder\sample-image.png</span></span>
<span data-ttu-id="b1033-127">このファイルには、任意の PNG 画像を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="b1033-127">This file can contain any PNG image.</span></span>

### <a name="uwpappprojectrootfolderresourcesresw"></a><span data-ttu-id="b1033-128">\UWPAppProjectRootFolder\resources.resw</span><span class="sxs-lookup"><span data-stu-id="b1033-128">\UWPAppProjectRootFolder\resources.resw</span></span>
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

### <a name="uwpappprojectrootfolderde-deresourcesresw"></a><span data-ttu-id="b1033-129">\UWPAppProjectRootFolder\de-DE\resources.resw</span><span class="sxs-lookup"><span data-stu-id="b1033-129">\UWPAppProjectRootFolder\de-DE\resources.resw</span></span>
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString2">
        <value>LocalizedString2-de-DE</value>
    </data>
</root>
```

### <a name="uwpappprojectrootfolderen-usresourcesresw"></a><span data-ttu-id="b1033-130">\UWPAppProjectRootFolder\en-US\resources.resw</span><span class="sxs-lookup"><span data-stu-id="b1033-130">\UWPAppProjectRootFolder\en-US\resources.resw</span></span>
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

## <a name="index-the-resources-and-create-a-pri-file"></a><span data-ttu-id="b1033-131">リソースにインデックスを付け、PRI ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="b1033-131">Index the resources, and create a PRI file</span></span>
<span data-ttu-id="b1033-132">`main()` 関数で、COM を初期化するための呼び出しの前に、必要となるいくつかの文字列を宣言します。また、PRI ファイルを生成する出力フォルダーも作成します。</span><span class="sxs-lookup"><span data-stu-id="b1033-132">In the `main()` function, before the call to initialize COM, declare some strings that we'll need, and also create the output folder in which we'll be generating our PRI file.</span></span>

```cppwinrt
std::wstring projectRootFolderUWPApp{ L"UWPAppProjectRootFolder" };
std::wstring generatedPRIsFolder{ projectRootFolderUWPApp + L"\\Generated PRIs" };
std::wstring filePathPRI{ generatedPRIsFolder + L"\\resources.pri" };
std::wstring filePathPRIDumpBasic{ generatedPRIsFolder + L"\\resources-pri-dump-basic.xml" };

::CreateDirectory(generatedPRIsFolder.c_str(), nullptr);
```

<span data-ttu-id="b1033-133">COM を初期化するための呼び出しの直後に、リソース インデクサー ハンドルを宣言し、[**MrmCreateResourceIndexer**]() を呼び出してリソース インデクサーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b1033-133">Immediately after the call to Initialize COM, declare a resource indexer handle and then call [**MrmCreateResourceIndexer**]() to create a resource indexer.</span></span>

```cppwinrt
MrmResourceIndexerHandle indexer;
::ThrowIfFailed(::MrmCreateResourceIndexer(
    L"OurUWPApp",
    projectRootFolderUWPApp.c_str(),
    MrmPlatformVersion::MrmPlatformVersion_Windows10_0_0_0,
    L"language-en_scale-100_contrast-standard",
    &indexer));
```

<span data-ttu-id="b1033-134">**MrmCreateResourceIndexer** に渡される引数について、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b1033-134">Here's an explanation of the arguments being passed to **MrmCreateResourceIndexer**.</span></span>

- <span data-ttu-id="b1033-135">後でこのリソース インデクサーから PRI ファイルを生成したときにリソース マップ名として使用する、対象の UWP アプリのパッケージ ファミリ名です。</span><span class="sxs-lookup"><span data-stu-id="b1033-135">The package family name of our target UWP app, which will be used as the resource map name when we later generate a PRI file from this resource indexer.</span></span>
- <span data-ttu-id="b1033-136">対象の UWP アプリのプロジェクト ルートです。</span><span class="sxs-lookup"><span data-stu-id="b1033-136">The project root of our target UWP app.</span></span> <span data-ttu-id="b1033-137">つまり、リソース ファイルのパスです。</span><span class="sxs-lookup"><span data-stu-id="b1033-137">In other words, the path to our resource files.</span></span> <span data-ttu-id="b1033-138">これは、同じリソース インデクサーへの以降の API 呼び出しでそのルートの相対パスを指定できるようにするために指定します。</span><span class="sxs-lookup"><span data-stu-id="b1033-138">We specify this so that we can then specify paths relative to that root in subsequent API calls to the same resource indexer.</span></span>
- <span data-ttu-id="b1033-139">対象にする Windows のバージョンです。</span><span class="sxs-lookup"><span data-stu-id="b1033-139">The version of Windows that we want to target.</span></span>
- <span data-ttu-id="b1033-140">既定のリソース修飾子の一覧です。</span><span class="sxs-lookup"><span data-stu-id="b1033-140">A list of default resource qualifiers.</span></span>
- <span data-ttu-id="b1033-141">関数で設定できるようにするための、リソース インデクサー ハンドルへのポインターです。</span><span class="sxs-lookup"><span data-stu-id="b1033-141">A pointer to our resource indexer handle so that the function can set it.</span></span>

<span data-ttu-id="b1033-142">次の手順では、先ほど作成したリソース インデクサーにリソースを追加します。</span><span class="sxs-lookup"><span data-stu-id="b1033-142">The next step is to add our resources to the resource indexer that we just created.</span></span> `resources.resw` <span data-ttu-id="b1033-143"> は、対象の UWP アプリの中立的な文字列を含むリソース ファイル (.resw) です。</span><span class="sxs-lookup"><span data-stu-id="b1033-143">is a Resources File (.resw) that contains the neutral strings for our target UWP app.</span></span> <span data-ttu-id="b1033-144">その内容を表示する場合は、(このトピック内で) 上方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="b1033-144">Scroll up (in this topic) if you want to see its contents.</span></span> `de-DE\resources.resw` <span data-ttu-id="b1033-145"> にはドイツ語の文字列、`en-US\resources.resw` には英語の文字列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b1033-145">contains our German strings, and `en-US\resources.resw` our English strings.</span></span> <span data-ttu-id="b1033-146">リソース ファイル内の文字列リソースをリソース インデクサーに追加するには、[**MrmIndexResourceContainerAutoQualifiers**]() を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b1033-146">To add the string resources inside a Resources File to a resource indexer, you call [**MrmIndexResourceContainerAutoQualifiers**]().</span></span> <span data-ttu-id="b1033-147">3 番目に、[**MrmIndexFile**]() 関数を呼び出して、中立的なイメージ リソースを含むファイルをリソース インデクサーに追加します。</span><span class="sxs-lookup"><span data-stu-id="b1033-147">Thirdly, we call the [**MrmIndexFile**]() function to a file containing a neutral image resource to the resource indexer.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"resources.resw"));
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"de-DE\\resources.resw"));
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"en-US\\resources.resw"));
::ThrowIfFailed(::MrmIndexFile(indexer, L"ms-resource:///Files/sample-image.png", L"sample-image.png", L""));
```

<span data-ttu-id="b1033-148">**MrmIndexFile** の呼び出しで、値 L"ms-resource:///Files/sample-image.png" はリソース uri です。</span><span class="sxs-lookup"><span data-stu-id="b1033-148">In the call to **MrmIndexFile**, the value L"ms-resource:///Files/sample-image.png" is the resource uri.</span></span> <span data-ttu-id="b1033-149">最初のパス セグメントは "Files" で、これが後でこのリソース インデクサーから PRI ファイルを生成したときにリソース マップのサブツリー名として使用されます。</span><span class="sxs-lookup"><span data-stu-id="b1033-149">The first path segment is "Files", and that's what will be used as the resource map subtree name when we later generate a PRI file from this resource indexer.</span></span>

<span data-ttu-id="b1033-150">リソース ファイルに関するリソース インデクサーの概要を説明したので、[**MrmCreateResourceFile**]() 関数を呼び出してディスクに PRI ファイルを自動的に生成できるようにしましょう。</span><span class="sxs-lookup"><span data-stu-id="b1033-150">Having briefed the resource indexer about our resource files, it's time to have it generate us a PRI file on disk by calling the [**MrmCreateResourceFile**]() function.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmCreateResourceFile(indexer, MrmPackagingModeStandaloneFile, MrmPackagingOptionsNone, generatedPRIsFolder.c_str()));
```

<span data-ttu-id="b1033-151">この時点で、`resources.pri` という名前の PRI ファイルが `Generated PRIs` という名前のフォルダー内に作成されました。</span><span class="sxs-lookup"><span data-stu-id="b1033-151">At this point, a PRI file named `resources.pri` has been created inside a folder named `Generated PRIs`.</span></span> <span data-ttu-id="b1033-152">これで、リソース インデクサーの作業が完了したので、[**MrmDestroyIndexerAndMessages**]() を呼び出して、そのハンドルを破棄し、割り当てられたマシン リソースをリリースします。</span><span class="sxs-lookup"><span data-stu-id="b1033-152">Now that we're done with the resource indexer, we call [**MrmDestroyIndexerAndMessages**]() to destroy its handle and release any machine resources that it allocated.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmDestroyIndexerAndMessages(indexer));
```

<span data-ttu-id="b1033-153">PRI ファイルはバイナリであるため、バイナリ PRI ファイルをそれに対応する XML にダンプすると、先ほど生成したものを表示するのが簡単になります。</span><span class="sxs-lookup"><span data-stu-id="b1033-153">Since a PRI file is binary, it's going to be easier to view what we've just generated if we dump the binary PRI file to its XML equivalent.</span></span> <span data-ttu-id="b1033-154">[**MrmDumpPriFile**]() の呼び出しによりこれが行われます。</span><span class="sxs-lookup"><span data-stu-id="b1033-154">A call to [**MrmDumpPriFile**]()does just that.</span></span>

```cppwinrt
::ThrowIfFailed(::MrmDumpPriFile(filePathPRI.c_str(), nullptr, MrmDumpType::MrmDumpType_Basic, filePathPRIDumpBasic.c_str()));
```

<span data-ttu-id="b1033-155">**MrmDumpPriFile** に渡される引数について、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b1033-155">Here's an explanation of the arguments being passed to **MrmDumpPriFile**.</span></span>

- <span data-ttu-id="b1033-156">ダンプする PRI ファイルのパス。</span><span class="sxs-lookup"><span data-stu-id="b1033-156">The path to the PRI file to dump.</span></span> <span data-ttu-id="b1033-157">この呼び出しでリソース インデクサーは使用しません (先ほどそれを破棄しました)。そのため完全なファイル パスを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b1033-157">We're not using the resource indexer in this call (we just destroyed it), so we need to specify a full file path.</span></span>
- <span data-ttu-id="b1033-158">スキーマ ファイルはありません。</span><span class="sxs-lookup"><span data-stu-id="b1033-158">No schema file.</span></span> <span data-ttu-id="b1033-159">スキーマの概要については、後のトピックで説明します。</span><span class="sxs-lookup"><span data-stu-id="b1033-159">We'll discuss what a schema is later in the topic.</span></span>
- <span data-ttu-id="b1033-160">単なる基本情報です。</span><span class="sxs-lookup"><span data-stu-id="b1033-160">Just the basic info.</span></span>
- <span data-ttu-id="b1033-161">作成する XML ファイルのパスです。</span><span class="sxs-lookup"><span data-stu-id="b1033-161">The path of an XML file to create.</span></span>

<span data-ttu-id="b1033-162">これは、ここで XML にダンプされる PRI ファイルに含まれる内容です。</span><span class="sxs-lookup"><span data-stu-id="b1033-162">This is what the PRI file, dumped to XML here, contains.</span></span>

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

<span data-ttu-id="b1033-163">情報は、対象の UWP アプリのパッケージ ファミリ名が付いたリソース マップから始まります。</span><span class="sxs-lookup"><span data-stu-id="b1033-163">The info begins with a resource map, which is named with the package family name of our target UWP app.</span></span> <span data-ttu-id="b1033-164">リソース マップで囲まれているのは 2 つのリソース マップ サブツリーです。1 つはインデックスを作成したファイル リソース用で、もう 1 つは文字列リソース用です。</span><span class="sxs-lookup"><span data-stu-id="b1033-164">Enclosed by the resource map are two resource map subtrees: one for the file resources that we indexed, and another for our string resources.</span></span> <span data-ttu-id="b1033-165">パッケージ ファミリ名がすべてのリソース URI に挿入されているのがわかります。</span><span class="sxs-lookup"><span data-stu-id="b1033-165">Notice how the package family name has been inserted into all of the resource URIs.</span></span>

<span data-ttu-id="b1033-166">最初の文字列リソースは、`en-US\resources.resw` の *EnOnlyString* で候補が 1 つだけあります (その候補は *language-en-US* 修飾子に一致します)。</span><span class="sxs-lookup"><span data-stu-id="b1033-166">The first string resource is *EnOnlyString* from `en-US\resources.resw`, and it has just one candidate (which matches the *language-en-US* qualifier).</span></span> <span data-ttu-id="b1033-167">次のリソースは、`resources.resw` および `en-US\resources.resw` の *LocalizedString1* です。</span><span class="sxs-lookup"><span data-stu-id="b1033-167">Next comes *LocalizedString1* from both `resources.resw` and `en-US\resources.resw`.</span></span> <span data-ttu-id="b1033-168">そのため、*language-en-US* に一致する候補と、任意のコンテキストに一致するフォールバックの中立の候補の 2 つの候補があります。</span><span class="sxs-lookup"><span data-stu-id="b1033-168">Consequently, it has two candidates: one matching *language-en-US*, and a fallback neutral candidate that matches any context.</span></span> <span data-ttu-id="b1033-169">同様に、*LocalizedString2* には、*language-de-DE* と中立の 2 つの候補があります。</span><span class="sxs-lookup"><span data-stu-id="b1033-169">Similarly, *LocalizedString2* has two candidates: *language-de-DE*, and neutral.</span></span> <span data-ttu-id="b1033-170">最後に、*NeutralOnlyString* は中立の形式だけに存在します。</span><span class="sxs-lookup"><span data-stu-id="b1033-170">And, finally, *NeutralOnlyString* only exists in neutral form.</span></span> <span data-ttu-id="b1033-171">その名前を指定して、そのリソースがローカライズされるものではないということを明確にしています。</span><span class="sxs-lookup"><span data-stu-id="b1033-171">I gave it that name to make it clear that it's not meant to be localized.</span></span>

## <a name="summary"></a><span data-ttu-id="b1033-172">まとめ</span><span class="sxs-lookup"><span data-stu-id="b1033-172">Summary</span></span>
<span data-ttu-id="b1033-173">このシナリオでは、[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用してリソース インデクサーを作成する方法を示しました。</span><span class="sxs-lookup"><span data-stu-id="b1033-173">In this scenario, we showed how to use the [package resource indexing (PRI) APIs](https://msdn.microsoft.com/library/windows/desktop/mt845690) to create a resource indexer.</span></span> <span data-ttu-id="b1033-174">文字列リソースとアセット ファイルをリソース インデクサーに追加しました。</span><span class="sxs-lookup"><span data-stu-id="b1033-174">We added string resources and asset files to the resource indexer.</span></span> <span data-ttu-id="b1033-175">次に、リソース インデクサーを使用して、バイナリ PRI ファイルを生成しました。</span><span class="sxs-lookup"><span data-stu-id="b1033-175">Then, we used the resource indexer to generated a binary PRI file.</span></span> <span data-ttu-id="b1033-176">最後に、期待した情報が含まれていることを確認できるように、XML の形式でバイナリ PRI ファイルをダンプしました。</span><span class="sxs-lookup"><span data-stu-id="b1033-176">And finally we dumped the binary PRI file in the form of XML so that we could confirm that it contains the info we expected.</span></span>

## <a name="important-apis"></a><span data-ttu-id="b1033-177">重要な API</span><span class="sxs-lookup"><span data-stu-id="b1033-177">Important APIs</span></span>
* [<span data-ttu-id="b1033-178">パッケージ リソース インデックス (PRI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="b1033-178">Package resource indexing (PRI) reference</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt845690)

## <a name="related-topics"></a><span data-ttu-id="b1033-179">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b1033-179">Related topics</span></span>
* [<span data-ttu-id="b1033-180">パッケージ リソース インデックス (PRI) API とカスタム ビルド システム</span><span class="sxs-lookup"><span data-stu-id="b1033-180">Package resource indexing (PRI) APIs and custom build systems</span></span>](pri-apis-custom-build-systems.md)
