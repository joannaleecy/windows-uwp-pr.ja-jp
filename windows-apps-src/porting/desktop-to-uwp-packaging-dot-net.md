---
author: normesta
Description: This guide explains how to configure your Visual Studio Solution to edit, debug, and package desktop app for the Desktop Bridge.
Search.Product: eADQiWindows 10XVcnh
title: Visual Studio を使ったアプリのパッケージ化 (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 08/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
ms.localizationpriority: medium
ms.openlocfilehash: d7ae77c499cb8398aa5557f0d422899fbe8b252d
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1816257"
---
# <a name="package-an-app-by-using-visual-studio-desktop-bridge"></a><span data-ttu-id="55299-103">Visual Studio を使ったアプリのパッケージ化 (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="55299-103">Package an app by using Visual Studio (Desktop Bridge)</span></span>

<span data-ttu-id="55299-104">Visual Studio を使用して、デスクトップ アプリのパッケージを生成できます。</span><span class="sxs-lookup"><span data-stu-id="55299-104">You can use Visual Studio to generate a package for your desktop app.</span></span> <span data-ttu-id="55299-105">その後、そのパッケージを Microsoft Store に公開したり、1 台以上の PC にサイドローディングしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="55299-105">Then, you can publish that package to the Windows store or sideload it onto one or more PCs.</span></span>

<span data-ttu-id="55299-106">最新バージョンの Visual Studio には、アプリのパッケージ化に必要であった手動ステップをすべてなくす新しいバージョンのパッケージ プロジェクトが用意されています。</span><span class="sxs-lookup"><span data-stu-id="55299-106">The latest version of Visual Studio provides a new version of the packaging project that eliminates all of the manual steps that used to be necessary to package your app.</span></span> <span data-ttu-id="55299-107">パッケージ プロジェクトを追加して、デスクトップ プロジェクトを参照し、F5 キーを押してアプリをデバッグするだけです。</span><span class="sxs-lookup"><span data-stu-id="55299-107">Just add a packaging project, reference your desktop project, and then press F5 to debug your app.</span></span> <span data-ttu-id="55299-108">手動で調整する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="55299-108">No manual tweaks necessary.</span></span> <span data-ttu-id="55299-109">この新しい効率化されたエクスペリエンスは、以前のバージョンの Visual Studio のエクスペリエンスから大幅に向上しています。</span><span class="sxs-lookup"><span data-stu-id="55299-109">This new streamlined experience is a vast improvement over the experience that was available in the previous version of Visual Studio.</span></span>

>[!IMPORTANT]
><span data-ttu-id="55299-110">デスクトップ ブリッジは、Windows 10 Version 1607 で導入されており、Windows 10 Anniversary Update (10.0、ビルド 14393) 以降のリリースをターゲットとする Visual Studio プロジェクトでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="55299-110">The Desktop Bridge was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

## <a name="first-consider-how-youll-distribute-your-app"></a><span data-ttu-id="55299-111">まず、アプリの配布方法を検討する</span><span class="sxs-lookup"><span data-stu-id="55299-111">First, consider how you'll distribute your app</span></span>

<span data-ttu-id="55299-112">アプリを [Microsoft Store](https://www.microsoft.com/store/apps) に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。</span><span class="sxs-lookup"><span data-stu-id="55299-112">If you plan to publish your app to the [Microsoft Store](https://www.microsoft.com/store/apps), start by filling out [this form](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge).</span></span> <span data-ttu-id="55299-113">Microsoft から、オンボード プロセスを開始するための連絡があります。</span><span class="sxs-lookup"><span data-stu-id="55299-113">Microsoft will contact you to start the onboarding process.</span></span> <span data-ttu-id="55299-114">このプロセスでは、Microsoft Store 内の名前を予約し、アプリをパッケージ化するための情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="55299-114">As part of this process, you'll reserve a name in the store, and obtain information that you'll need to package your app.</span></span>

<span data-ttu-id="55299-115">さらに、アプリケーションのパッケージの作成を開始する前に、必ず「[アプリのパッケージ化の準備 (デスクトップ ブリッジ)](desktop-to-uwp-prepare.md)」を確認してください。</span><span class="sxs-lookup"><span data-stu-id="55299-115">Also, make sure to review this guide before you begin creating a package for your application: [Prepare to package an app (Desktop Bridge)](desktop-to-uwp-prepare.md).</span></span>

<a id="new-packaging-project"/>

## <a name="create-a-package"></a><span data-ttu-id="55299-116">パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="55299-116">Create a package</span></span>

1. <span data-ttu-id="55299-117">Visual Studio で、デスクトップ アプリケーション プロジェクトが含まれたソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="55299-117">In Visual Studio, open the solution that contains your desktop application project.</span></span>

2. <span data-ttu-id="55299-118">ソリューションに **Windows アプリケーション パッケージ プロジェクト** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="55299-118">Add a **Windows Application Packaging Project** project to your solution.</span></span>

   <span data-ttu-id="55299-119">コードを追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="55299-119">You won't have to add any code to it.</span></span> <span data-ttu-id="55299-120">プロジェクトを追加したのは単にパッケージを生成するためです。</span><span class="sxs-lookup"><span data-stu-id="55299-120">It's just there to generate a package for you.</span></span> <span data-ttu-id="55299-121">このプロジェクトを "パッケージ プロジェクト" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="55299-121">We'll refer to this project as the "packaging project".</span></span>

   ![パッケージ プロジェクト](images/desktop-to-uwp/packaging-project.png)

   >[!NOTE]
   ><span data-ttu-id="55299-123">このプロジェクトは、Visual Studio 2017 バージョン 15.5 以降でのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="55299-123">This project appears only in Visual Studio 2017 version 15.5 or higher.</span></span>

3. <span data-ttu-id="55299-124">このプロジェクトの **[ターゲット バージョン]** を目的のバージョンに設定しますが、**[最小バージョン]** は必ず **[Windows 10 Anniversary Update]** に設定してください。</span><span class="sxs-lookup"><span data-stu-id="55299-124">Set the **Target Version** of this project to any version that you want, but make sure to set the **Minimum Version** to **Windows 10 Anniversary Update**.</span></span>

   ![パッケージ バージョンの選択ダイアログ ボックス](images/desktop-to-uwp/packaging-version.png)

4. <span data-ttu-id="55299-126">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="55299-126">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

   ![プロジェクト参照の追加](images/desktop-to-uwp/add-project-reference.png)

5. <span data-ttu-id="55299-128">デスクトップ アプリケーション プロジェクトを選択し、**[OK]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="55299-128">Choose your desktop application project, and then choose the **OK** button.</span></span>

   ![デスクトップ プロジェクト](images/desktop-to-uwp/reference-project.png)

   <span data-ttu-id="55299-130">パッケージには複数のデスクトップ アプリケーションを含めることができますが、ユーザーがアプリ タイルを選択したときに起動できるのは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="55299-130">You can include multiple desktop applications in your package, but only one of them can start when users choose your app tile.</span></span> <span data-ttu-id="55299-131">**[アプリケーション]** ノードで、ユーザーがアプリのタイルを選択したときに起動するアプリケーションを右クリックし、**[Set as Entry Point]** (エントリ ポイントとして設定) を選びます。</span><span class="sxs-lookup"><span data-stu-id="55299-131">In the **Applications** node, right-click the application that you want users to start when they choose the app's tile, and then choose **Set as Entry Point**.</span></span>

   ![エントリ ポイントの設定](images/desktop-to-uwp/entry-point-set.png)

6. <span data-ttu-id="55299-133">パッケージ プロジェクトをビルドし、エラーが表示されないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="55299-133">Build the packaging project to ensure that no errors appear.</span></span>

7. <span data-ttu-id="55299-134">[アプリ パッケージの作成](../packaging/packaging-uwp-apps.md)ウィザードを使って、appxupload ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="55299-134">Use the [Create App Packages](../packaging/packaging-uwp-apps.md) wizard to generate an appxupload file.</span></span>

   <span data-ttu-id="55299-135">そのファイルを Microsoft Store に直接アップロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="55299-135">You can upload that file directly to the store.</span></span>

**<span data-ttu-id="55299-136">ビデオ</span><span class="sxs-lookup"><span data-stu-id="55299-136">Video</span></span>**

<iframe src="https://www.youtube.com/embed/fJkbYPyd08w" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="next-steps"></a><span data-ttu-id="55299-137">次のステップ</span><span class="sxs-lookup"><span data-stu-id="55299-137">Next steps</span></span>

**<span data-ttu-id="55299-138">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="55299-138">Find answers to your questions</span></span>**

<span data-ttu-id="55299-139">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="55299-139">Have questions?</span></span> <span data-ttu-id="55299-140">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="55299-140">Ask us on Stack Overflow.</span></span> <span data-ttu-id="55299-141">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="55299-141">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="55299-142">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="55299-142">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="55299-143">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="55299-143">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="55299-144">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55299-144">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

**<span data-ttu-id="55299-145">アプリを実行、デバッグ、テストする</span><span class="sxs-lookup"><span data-stu-id="55299-145">Run, debug or test your app</span></span>**

<span data-ttu-id="55299-146">[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55299-146">See [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="55299-147">UWP API を追加してデスクトップ アプリを強化する</span><span class="sxs-lookup"><span data-stu-id="55299-147">Enhance your desktop app by adding UWP APIs</span></span>**

<span data-ttu-id="55299-148">「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55299-148">See [Enhance your desktop application for Windows 10](desktop-to-uwp-enhance.md)</span></span>

**<span data-ttu-id="55299-149">UWP プロジェクトと Windows ランタイム コンポーネントを追加することによってデスクトップ アプリを拡張する</span><span class="sxs-lookup"><span data-stu-id="55299-149">Extend your desktop app by adding UWP projects and Windows Runtime Components</span></span>**

<span data-ttu-id="55299-150">「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55299-150">See [Extend your desktop application with modern UWP components](desktop-to-uwp-extend.md).</span></span>

**<span data-ttu-id="55299-151">アプリを配布する</span><span class="sxs-lookup"><span data-stu-id="55299-151">Distribute your app</span></span>**

<span data-ttu-id="55299-152">[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="55299-152">See [Distribute a packaged desktop app (Desktop Bridge)](desktop-to-uwp-distribute.md)</span></span>
