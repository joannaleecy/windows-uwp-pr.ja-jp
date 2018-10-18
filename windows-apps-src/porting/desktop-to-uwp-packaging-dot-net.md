---
author: normesta
Description: This guide explains how to configure your Visual Studio Solution to edit, debug, and package desktop application.
Search.Product: eADQiWindows 10XVcnh
title: Visual Studio を使ってデスクトップ アプリケーションをパッケージ化します。
ms.author: normesta
ms.date: 08/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
ms.localizationpriority: medium
ms.openlocfilehash: 2c9b7a30a50c26d2dbdaf6df04e85549addaf181
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2018
ms.locfileid: "4967564"
---
# <a name="package-a-desktop-application-by-using-visual-studio"></a><span data-ttu-id="e8001-103">Visual Studio を使ってデスクトップ アプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="e8001-103">Package a desktop application by using Visual Studio</span></span>

<span data-ttu-id="e8001-104">Visual Studio を使用して、デスクトップ アプリのパッケージを生成できます。</span><span class="sxs-lookup"><span data-stu-id="e8001-104">You can use Visual Studio to generate a package for your desktop app.</span></span> <span data-ttu-id="e8001-105">その後、そのパッケージを Microsoft Store に公開したり、1 台以上の PC にサイドローディングしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="e8001-105">Then, you can publish that package to the Windows store or sideload it onto one or more PCs.</span></span>

<span data-ttu-id="e8001-106">最新バージョンの Visual Studio には、アプリのパッケージ化に必要であった手動ステップをすべてなくす新しいバージョンのパッケージ プロジェクトが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e8001-106">The latest version of Visual Studio provides a new version of the packaging project that eliminates all of the manual steps that used to be necessary to package your app.</span></span> <span data-ttu-id="e8001-107">パッケージ プロジェクトを追加して、デスクトップ プロジェクトを参照し、F5 キーを押してアプリをデバッグするだけです。</span><span class="sxs-lookup"><span data-stu-id="e8001-107">Just add a packaging project, reference your desktop project, and then press F5 to debug your app.</span></span> <span data-ttu-id="e8001-108">手動で調整する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e8001-108">No manual tweaks necessary.</span></span> <span data-ttu-id="e8001-109">この新しい効率化されたエクスペリエンスは、以前のバージョンの Visual Studio のエクスペリエンスから大幅に向上しています。</span><span class="sxs-lookup"><span data-stu-id="e8001-109">This new streamlined experience is a vast improvement over the experience that was available in the previous version of Visual Studio.</span></span>

>[!IMPORTANT]
><span data-ttu-id="e8001-110">デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能 (デスクトップ ブリッジとも呼ばれるを Windows 10 バージョン 1607 で導入されたそれ以外の場合と、Windows 10 Anniversary Update (10.0; をターゲットとするプロジェクトでのみ使用できますビルド 14393) 以降の Visual Studio でリリースされます。</span><span class="sxs-lookup"><span data-stu-id="e8001-110">The ability to create a Windows app package for your desktop application (Otherwise known as the Desktop Bridge, was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

## <a name="first-prepare-your-application"></a><span data-ttu-id="e8001-111">まず、アプリケーションを準備します</span><span class="sxs-lookup"><span data-stu-id="e8001-111">First, prepare your application</span></span>

<span data-ttu-id="e8001-112">アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションのパッケージを準備](desktop-to-uwp-prepare.md)します。</span><span class="sxs-lookup"><span data-stu-id="e8001-112">Review this guide before you begin creating a package for your application: [Prepare to package a desktop application](desktop-to-uwp-prepare.md).</span></span>

<a id="new-packaging-project"/>

## <a name="create-a-package"></a><span data-ttu-id="e8001-113">パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="e8001-113">Create a package</span></span>

1. <span data-ttu-id="e8001-114">Visual Studio で、デスクトップ アプリケーション プロジェクトが含まれたソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="e8001-114">In Visual Studio, open the solution that contains your desktop application project.</span></span>

2. <span data-ttu-id="e8001-115">ソリューションに **Windows アプリケーション パッケージ プロジェクト** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="e8001-115">Add a **Windows Application Packaging Project** project to your solution.</span></span>

   <span data-ttu-id="e8001-116">コードを追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e8001-116">You won't have to add any code to it.</span></span> <span data-ttu-id="e8001-117">プロジェクトを追加したのは単にパッケージを生成するためです。</span><span class="sxs-lookup"><span data-stu-id="e8001-117">It's just there to generate a package for you.</span></span> <span data-ttu-id="e8001-118">このプロジェクトを "パッケージ プロジェクト" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="e8001-118">We'll refer to this project as the "packaging project".</span></span>

   ![パッケージ プロジェクト](images/desktop-to-uwp/packaging-project.png)

   >[!NOTE]
   ><span data-ttu-id="e8001-120">このプロジェクトは、Visual Studio 2017 バージョン 15.5 以降でのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="e8001-120">This project appears only in Visual Studio 2017 version 15.5 or higher.</span></span>

3. <span data-ttu-id="e8001-121">このプロジェクトの **[ターゲット バージョン]** を目的のバージョンに設定しますが、**[最小バージョン]** は必ず **[Windows 10 Anniversary Update]** に設定してください。</span><span class="sxs-lookup"><span data-stu-id="e8001-121">Set the **Target Version** of this project to any version that you want, but make sure to set the **Minimum Version** to **Windows 10 Anniversary Update**.</span></span>

   ![パッケージ バージョンの選択ダイアログ ボックス](images/desktop-to-uwp/packaging-version.png)

4. <span data-ttu-id="e8001-123">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="e8001-123">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

   ![プロジェクト参照の追加](images/desktop-to-uwp/add-project-reference.png)

5. <span data-ttu-id="e8001-125">デスクトップ アプリケーション プロジェクトを選択し、**[OK]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="e8001-125">Choose your desktop application project, and then choose the **OK** button.</span></span>

   ![デスクトップ プロジェクト](images/desktop-to-uwp/reference-project.png)

   <span data-ttu-id="e8001-127">パッケージには複数のデスクトップ アプリケーションを含めることができますが、ユーザーがアプリ タイルを選択したときに起動できるのは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="e8001-127">You can include multiple desktop applications in your package, but only one of them can start when users choose your app tile.</span></span> <span data-ttu-id="e8001-128">**[アプリケーション]** ノードで、ユーザーがアプリのタイルを選択したときに起動するアプリケーションを右クリックし、**[Set as Entry Point]** (エントリ ポイントとして設定) を選びます。</span><span class="sxs-lookup"><span data-stu-id="e8001-128">In the **Applications** node, right-click the application that you want users to start when they choose the app's tile, and then choose **Set as Entry Point**.</span></span>

   ![エントリ ポイントの設定](images/desktop-to-uwp/entry-point-set.png)

6. <span data-ttu-id="e8001-130">パッケージ プロジェクトをビルドし、エラーが表示されないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="e8001-130">Build the packaging project to ensure that no errors appear.</span></span>

7. <span data-ttu-id="e8001-131">[アプリ パッケージの作成](../packaging/packaging-uwp-apps.md)ウィザードを使って、appxupload ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="e8001-131">Use the [Create App Packages](../packaging/packaging-uwp-apps.md) wizard to generate an appxupload file.</span></span>

   <span data-ttu-id="e8001-132">そのファイルを Microsoft Store に直接アップロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="e8001-132">You can upload that file directly to the store.</span></span>

**<span data-ttu-id="e8001-133">ビデオ</span><span class="sxs-lookup"><span data-stu-id="e8001-133">Video</span></span>**

&nbsp;
> [!VIDEO https://www.youtube.com/embed/fJkbYPyd08w]

## <a name="next-steps"></a><span data-ttu-id="e8001-134">次のステップ</span><span class="sxs-lookup"><span data-stu-id="e8001-134">Next steps</span></span>

**<span data-ttu-id="e8001-135">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="e8001-135">Find answers to your questions</span></span>**

<span data-ttu-id="e8001-136">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="e8001-136">Have questions?</span></span> <span data-ttu-id="e8001-137">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="e8001-137">Ask us on Stack Overflow.</span></span> <span data-ttu-id="e8001-138">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="e8001-138">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="e8001-139">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="e8001-139">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="e8001-140">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="e8001-140">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="e8001-141">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e8001-141">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

**<span data-ttu-id="e8001-142">実行、デバッグ、デスクトップ アプリケーションのテスト</span><span class="sxs-lookup"><span data-stu-id="e8001-142">Run, debug or test your desktop application</span></span>**

<span data-ttu-id="e8001-143">[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e8001-143">See [Run, debug, and test a packaged desktop application](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="e8001-144">UWP Api を追加してデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="e8001-144">Enhance your desktop application by adding UWP APIs</span></span>**

<span data-ttu-id="e8001-145">「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e8001-145">See [Enhance your desktop application for Windows 10](desktop-to-uwp-enhance.md)</span></span>

**<span data-ttu-id="e8001-146">UWP プロジェクトと Windows ランタイム コンポーネントを追加してデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="e8001-146">Extend your desktop application by adding UWP projects and Windows Runtime Components</span></span>**

<span data-ttu-id="e8001-147">「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e8001-147">See [Extend your desktop application with modern UWP components](desktop-to-uwp-extend.md).</span></span>

**<span data-ttu-id="e8001-148">アプリを配布する</span><span class="sxs-lookup"><span data-stu-id="e8001-148">Distribute your app</span></span>**

<span data-ttu-id="e8001-149">[デスクトップ アプリケーションのパッケージの配布](desktop-to-uwp-distribute.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e8001-149">See [Distribute a packaged desktop application](desktop-to-uwp-distribute.md)</span></span>
