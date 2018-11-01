---
author: laurenhughes
title: 実行可能コードを使用したオプション パッケージ
description: Visual Studio を使用して、実行可能コードでオプション パッケージを作成する方法について説明します。
ms.author: lahugh
ms.date: 9/30/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 8f454c7e7386ba829cf6c99edc0b5b8f2d831f00
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5920315"
---
# <a name="optional-packages-with-executable-code"></a><span data-ttu-id="732d1-104">実行可能コードを使用したオプション パッケージ</span><span class="sxs-lookup"><span data-stu-id="732d1-104">Optional packages with executable code</span></span>
 
<span data-ttu-id="732d1-105">実行可能コードを使用したオプション パッケージは、大規模または複雑なアプリを分割したり、既に公開されたアプリに追加するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="732d1-105">Optional packages with executable code are useful for dividing a large or complex app, or for adding on to an app that's already been published.</span></span> <span data-ttu-id="732d1-106">Visual Studio 2017 Version 15.7 および .NET Native 2.1 では、C++ および C# のオプション パッケージから実行可能コードを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="732d1-106">With Visual Studio 2017, version 15.7 and .NET Native 2.1, you can load executable code from both C++ and C# optional packages.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="732d1-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="732d1-107">Prerequisites</span></span>
- <span data-ttu-id="732d1-108">Visual Studio 2017 Version 15.7</span><span class="sxs-lookup"><span data-stu-id="732d1-108">Visual Studio 2017, version 15.7</span></span>
- <span data-ttu-id="732d1-109">Windows 10 Version 1709</span><span class="sxs-lookup"><span data-stu-id="732d1-109">Windows 10, version 1709</span></span>
- <span data-ttu-id="732d1-110">Windows 10 Version 1709 SDK</span><span class="sxs-lookup"><span data-stu-id="732d1-110">Windows 10, version 1709 SDK</span></span>

<span data-ttu-id="732d1-111">最新の開発ツールを取得する方法については、「[Windows 10 用のダウンロードとツール](https://developer.microsoft.com/windows/downloads)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="732d1-111">To get the latest development tools, see [Downloads and tools for Windows 10](https://developer.microsoft.com/windows/downloads).</span></span> 

> [!NOTE]
> <span data-ttu-id="732d1-112">オプション パッケージや関連セットを使用するアプリを Microsoft Store に提出するには、許可が必要です。</span><span class="sxs-lookup"><span data-stu-id="732d1-112">To submit an app that uses optional packages and/or related sets to the Store, you will need permission.</span></span> <span data-ttu-id="732d1-113">Microsoft Store に提出しない場合は、デベロッパー センターから許可を受けずにオプション パッケージや関連セットを基幹業務 (LOB) アプリやエンタープライズ アプリに使用できます。</span><span class="sxs-lookup"><span data-stu-id="732d1-113">Optional packages and related sets can be used for Line of Business (LOB) or enterprise apps without Dev Center permission if they are not submitted to the Store.</span></span> <span data-ttu-id="732d1-114">オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="732d1-114">See [Windows developer support](https://developer.microsoft.com/windows/support) to get permission to submit an app that uses optional packages and related sets.</span></span>

## <a name="c-optional-packages-with-executable-code"></a><span data-ttu-id="732d1-115">実行可能コードを使用した C++ オプション パッケージ</span><span class="sxs-lookup"><span data-stu-id="732d1-115">C++ Optional packages with executable code</span></span>

<span data-ttu-id="732d1-116">C++オプション パッケージからコードを読み込むには、GitHub で [OptionalPackageSample](https://github.com/AppInstaller/OptionalPackageSample) リポジトリを参照してください。</span><span class="sxs-lookup"><span data-stu-id="732d1-116">To load code from a C++ optional package, see the [OptionalPackageSample](https://github.com/AppInstaller/OptionalPackageSample) repository on GitHub.</span></span> <span data-ttu-id="732d1-117">[OptionalPackageDLL](https://github.com/AppInstaller/OptionalPackageSample/tree/master/OptionalPackageDLL) では、メイン パッケージから実行可能なコードを使用してプロジェクトを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="732d1-117">The [OptionalPackageDLL](https://github.com/AppInstaller/OptionalPackageSample/tree/master/OptionalPackageDLL) shows how to create a project with code that can be executed from the main package.</span></span> <span data-ttu-id="732d1-118">MyMainApp プロジェクトでは、OptionalPackageDLL.dll ファイルから[コードを読み込む](https://github.com/AppInstaller/OptionalPackageSample/blob/bf6b4915ff1f3b8abfdaacb1ad9e77184c49fe18/MyMainApp/MainPage.xaml.cpp#L182)方法を示します。</span><span class="sxs-lookup"><span data-stu-id="732d1-118">The MyMainApp project demonstrates how to [load code](https://github.com/AppInstaller/OptionalPackageSample/blob/bf6b4915ff1f3b8abfdaacb1ad9e77184c49fe18/MyMainApp/MainPage.xaml.cpp#L182) from the OptionalPackageDLL.dll file.</span></span>

## <a name="c-optional-packages-with-executable-code"></a><span data-ttu-id="732d1-119">実行可能コードを使用した C# オプション パッケージ</span><span class="sxs-lookup"><span data-stu-id="732d1-119">C# Optional packages with executable code</span></span>

<span data-ttu-id="732d1-120">C# でオプションのコード パッケージの作成を開始するには、次の手順に従い、ソリューションを構成してください。</span><span class="sxs-lookup"><span data-stu-id="732d1-120">To get started building an optional code package in C#, follow the below steps to configure your solution:</span></span>

1. <span data-ttu-id="732d1-121">最小バージョンを Windows 10 Fall Creators Update SDK (ビルド 16299) 以上に設定して新しい UWP アプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="732d1-121">Create a new UWP application with the minimum version set to the Windows 10 Fall Creators Update SDK (Build 16299) or higher.</span></span>

2. <span data-ttu-id="732d1-122">新しい**オプションのコード パッケージ (ユニバーサル Windows)** プロジェクトをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="732d1-122">Add a new **Optional Code Package (Universal Windows)** project to the solution.</span></span> <span data-ttu-id="732d1-123">**[最小バージョン]** と **[ターゲット バージョン]** がメイン アプリのバージョンに一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="732d1-123">Ensure the **Minimum Version** and **Target Version** match that of your main app.</span></span>

3. <span data-ttu-id="732d1-124">アプリを Microsoft Store に申請する予定である場合は、両方のプロジェクトを右クリックして、**[Microsoft Store] -> [アプリケーションをストアと関連付ける]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="732d1-124">If you plan to submit your apps to the Store, right click on both projects and select **Store -> Associate App with the Store...**</span></span>

4. <span data-ttu-id="732d1-125">メイン アプリの `Package.appxmanifest` ファイルを開き、`Identity Name` 値を見つけます。</span><span class="sxs-lookup"><span data-stu-id="732d1-125">Open the `Package.appxmanifest` file of the main app and find the `Identity Name` value.</span></span> <span data-ttu-id="732d1-126">次の手順のためにこの値を書き留めます。</span><span class="sxs-lookup"><span data-stu-id="732d1-126">Make a note of this value for the next step.</span></span>

5. <span data-ttu-id="732d1-127">オプションのアプリ パッケージの `Package.appxmanifest` ファイルを開き、`uap3:MainAppPackageDependency Name` 値を見つけます。</span><span class="sxs-lookup"><span data-stu-id="732d1-127">Open the optional app package's `Package.appxmanifest` file and find the `uap3:MainAppPackageDependency Name` value.</span></span> <span data-ttu-id="732d1-128">`uap3:MainAppPackageDependency Name` 値を更新し、前の手順のメイン アプリ パッケージの `Identity Name` 値と一致するようにします。</span><span class="sxs-lookup"><span data-stu-id="732d1-128">Update the `uap3:MainAppPackageDependency Name` value to match the `Identity Name` value of the main app package from the previous step.</span></span> 

    <span data-ttu-id="732d1-129">メイン アプリの `Package.appxmanifest` からの `Identity` の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="732d1-129">Here's an example of the `Identity` from the main app's `Package.appxmanifest`.</span></span>
    ```XML
    <Identity Name="12345.MainAppProject" Publisher="CN=PublisherName" Version="1.0.0.0" />
    ```

    <span data-ttu-id="732d1-130">オプションのアプリ ペッケージの `uap3:MainPackageDependency` は、メイン アプリの `Identity` に一致するように更新される必要があります。</span><span class="sxs-lookup"><span data-stu-id="732d1-130">The optional app package's `uap3:MainPackageDependency` needs to be updated to match the main app's `Identity`.</span></span>
    ```XML
    <uap3:MainPackageDependency Name="12345.MainAppProjectTest" />
    ```

6. <span data-ttu-id="732d1-131">`Bundle.mapping.txt` ファイルをメイン アプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="732d1-131">Add a `Bundle.mapping.txt` file to the main app.</span></span> <span data-ttu-id="732d1-132">「[関連セット](https://docs.microsoft.com/windows/uwp/packaging/optional-packages#related-sets)」セクションの手順に従い、両方のアプリを含む関連セットを作成します。</span><span class="sxs-lookup"><span data-stu-id="732d1-132">Follow the steps in this [Related sets](https://docs.microsoft.com/windows/uwp/packaging/optional-packages#related-sets) section to create a related set containing both apps.</span></span> 

7. <span data-ttu-id="732d1-133">オプション パッケージ プロジェクトをビルドし、`..\[PathToOptionalPackageProject]\bin\[architecture]\[configuration]\Reference` にあるビルドの出力の Reference パッケージ フォルダーに移動します。</span><span class="sxs-lookup"><span data-stu-id="732d1-133">Build the optional package project and then navigate to the package Reference folder in the output from the build found at `..\[PathToOptionalPackageProject]\bin\[architecture]\[configuration]\Reference`.</span></span> <span data-ttu-id="732d1-134">`.winmd` ファイル (手順 8) はアーキテクチャに依存しないため、Reference フォルダーへのパスで任意のアーキテクチャを選択できる点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="732d1-134">Note that you can choose any architecture in the path to the Reference folder since the `.winmd` file (step 8) is architecture independent.</span></span>

8. <span data-ttu-id="732d1-135">メイン アプリ プロジェクトからの参照を、このフォルダーにある `.winmd` ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="732d1-135">Add a reference from the main app project to the `.winmd` file found in this folder.</span></span> <span data-ttu-id="732d1-136">オプション パッケージ プロジェクトで API サーフェイス領域を変更するたびに、この `.winmd` ファイルを更新する**必要があります**。</span><span class="sxs-lookup"><span data-stu-id="732d1-136">Every time you change the API surface area in the optional package project, this `.winmd` file **must** be updated.</span></span> <span data-ttu-id="732d1-137">このリファレンスでは、コンパイルするために必要な情報を含むメイン アプリ プロジェクトが提供されます。</span><span class="sxs-lookup"><span data-stu-id="732d1-137">This reference provides the main app project with the necessary information to compile.</span></span>

9. <span data-ttu-id="732d1-138">メイン アプリ プロジェクトで、プロジェクト ビルドのプロパティに移動し、**[.NET ネイティブ ツール チェーンでコンパイルする]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="732d1-138">In the main app project, navigate to the project build properties and select **Compile with .NET Native tool chain**.</span></span> <span data-ttu-id="732d1-139">現在、C# でのオプションのコード パッケージの作成では .NET Native でのデバッグのみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="732d1-139">Currently, only debugging in .NET Native is supported for optional code package creation in C#.</span></span> <span data-ttu-id="732d1-140">プロジェクトのデバッグ プロパティに移動し、**[オプションのパッケージの配置]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="732d1-140">Go to the project debug properties and select **Deploy optional packages**.</span></span> <span data-ttu-id="732d1-141">これにより、メイン アプリ プロジェクトを配置する場合は、両方のパッケージが同期されるようになります。</span><span class="sxs-lookup"><span data-stu-id="732d1-141">This will ensure that both packages are in sync whenever you deploy the main app project.</span></span>

<span data-ttu-id="732d1-142">これらの手順が完了したら、WinRT コンポーネント マネージ プロジェクトであるかのように、オプション パッケージ プロジェクトにコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="732d1-142">Once you're finished with these steps, you can add code to the optional package project as if it were a managed WinRT Component project.</span></span> <span data-ttu-id="732d1-143">メイン アプリ プロジェクト内のコードにアクセスするには、オプション パッケージ プロジェクトで公開されたパブリック メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="732d1-143">To access the code in the main app project, call the public methods exposed in the optional package project.</span></span>