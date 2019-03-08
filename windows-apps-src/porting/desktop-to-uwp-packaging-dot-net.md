---
Description: このガイドでは、編集、デバッグ、およびデスクトップ アプリケーション パッケージを Visual Studio ソリューションを構成する方法について説明します。
Search.Product: eADQiWindows 10XVcnh
title: Visual Studio を使用して、デスクトップ アプリケーションをパッケージ化します。
ms.date: 08/30/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
ms.localizationpriority: medium
ms.openlocfilehash: 04a16b5e824621b0e7f32c8cb012db326f591d48
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655967"
---
# <a name="package-a-desktop-application-by-using-visual-studio"></a><span data-ttu-id="7219d-104">Visual Studio を使用して、デスクトップ アプリケーションをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="7219d-104">Package a desktop application by using Visual Studio</span></span>

<span data-ttu-id="7219d-105">Visual Studio を使用して、デスクトップ アプリのパッケージを生成できます。</span><span class="sxs-lookup"><span data-stu-id="7219d-105">You can use Visual Studio to generate a package for your desktop app.</span></span> <span data-ttu-id="7219d-106">次に、その 1 つまたは複数の Pc にサイドロード、Microsoft Store にパッケージを発行できます。</span><span class="sxs-lookup"><span data-stu-id="7219d-106">Then, you can publish that package to the Microsoft Store or sideload it onto one or more PCs.</span></span>

<span data-ttu-id="7219d-107">最新バージョンの Visual Studio には、アプリのパッケージ化に必要であった手動ステップをすべてなくす新しいバージョンのパッケージ プロジェクトが用意されています。</span><span class="sxs-lookup"><span data-stu-id="7219d-107">The latest version of Visual Studio provides a new version of the packaging project that eliminates all of the manual steps that used to be necessary to package your app.</span></span> <span data-ttu-id="7219d-108">パッケージ プロジェクトを追加して、デスクトップ プロジェクトを参照し、F5 キーを押してアプリをデバッグするだけです。</span><span class="sxs-lookup"><span data-stu-id="7219d-108">Just add a packaging project, reference your desktop project, and then press F5 to debug your app.</span></span> <span data-ttu-id="7219d-109">手動で調整する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7219d-109">No manual tweaks necessary.</span></span> <span data-ttu-id="7219d-110">この新しい効率化されたエクスペリエンスは、以前のバージョンの Visual Studio のエクスペリエンスから大幅に向上しています。</span><span class="sxs-lookup"><span data-stu-id="7219d-110">This new streamlined experience is a vast improvement over the experience that was available in the previous version of Visual Studio.</span></span>

>[!IMPORTANT]
><span data-ttu-id="7219d-111">(それ以外の場合は、デスクトップ ブリッジと呼ばれます) デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能は Windows 10 バージョン 1607 で導入され、Windows 10 Anniversary Update (10.0; を対象とするプロジェクトでのみ使用できます。ビルド 14393) または Visual Studio の今後のリリース。</span><span class="sxs-lookup"><span data-stu-id="7219d-111">The ability to create a Windows app package for your desktop application (otherwise known as the Desktop Bridge) was introduced in Windows 10, version 1607, and it can only be used in projects that target Windows 10 Anniversary Update (10.0; Build 14393) or a later release in Visual Studio.</span></span>

## <a name="first-prepare-your-application"></a><span data-ttu-id="7219d-112">まず、アプリケーションを準備します</span><span class="sxs-lookup"><span data-stu-id="7219d-112">First, prepare your application</span></span>

<span data-ttu-id="7219d-113">アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションをパッケージ化するための準備](desktop-to-uwp-prepare.md)します。</span><span class="sxs-lookup"><span data-stu-id="7219d-113">Review this guide before you begin creating a package for your application: [Prepare to package a desktop application](desktop-to-uwp-prepare.md).</span></span>

<a id="new-packaging-project"/>

## <a name="create-a-package"></a><span data-ttu-id="7219d-114">パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="7219d-114">Create a package</span></span>

1. <span data-ttu-id="7219d-115">Visual Studio で、デスクトップ アプリケーション プロジェクトが含まれたソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="7219d-115">In Visual Studio, open the solution that contains your desktop application project.</span></span>

2. <span data-ttu-id="7219d-116">ソリューションに **Windows アプリケーション パッケージ プロジェクト** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="7219d-116">Add a **Windows Application Packaging Project** project to your solution.</span></span>

   <span data-ttu-id="7219d-117">コードを追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7219d-117">You won't have to add any code to it.</span></span> <span data-ttu-id="7219d-118">プロジェクトを追加したのは単にパッケージを生成するためです。</span><span class="sxs-lookup"><span data-stu-id="7219d-118">It's just there to generate a package for you.</span></span> <span data-ttu-id="7219d-119">このプロジェクトを "パッケージ プロジェクト" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="7219d-119">We'll refer to this project as the "packaging project".</span></span>

   ![パッケージ プロジェクト](images/desktop-to-uwp/packaging-project.png)

   >[!NOTE]
   ><span data-ttu-id="7219d-121">このプロジェクトは、Visual Studio 2017 バージョン 15.5 以降でのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="7219d-121">This project appears only in Visual Studio 2017 version 15.5 or higher.</span></span>

3. <span data-ttu-id="7219d-122">このプロジェクトの **[ターゲット バージョン]** を目的のバージョンに設定しますが、**[最小バージョン]** は必ず **[Windows 10 Anniversary Update]** に設定してください。</span><span class="sxs-lookup"><span data-stu-id="7219d-122">Set the **Target Version** of this project to any version that you want, but make sure to set the **Minimum Version** to **Windows 10 Anniversary Update**.</span></span>

   ![パッケージ バージョンの選択ダイアログ ボックス](images/desktop-to-uwp/packaging-version.png)

4. <span data-ttu-id="7219d-124">パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7219d-124">In the packaging project, right-click the **Applications** folder, and then choose **Add Reference**.</span></span>

   ![プロジェクト参照の追加](images/desktop-to-uwp/add-project-reference.png)

5. <span data-ttu-id="7219d-126">デスクトップ アプリケーション プロジェクトを選択し、**[OK]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7219d-126">Choose your desktop application project, and then choose the **OK** button.</span></span>

   ![デスクトップ プロジェクト](images/desktop-to-uwp/reference-project.png)

   <span data-ttu-id="7219d-128">パッケージには複数のデスクトップ アプリケーションを含めることができますが、ユーザーがアプリ タイルを選択したときに起動できるのは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="7219d-128">You can include multiple desktop applications in your package, but only one of them can start when users choose your app tile.</span></span> <span data-ttu-id="7219d-129">**[アプリケーション]** ノードで、ユーザーがアプリのタイルを選択したときに起動するアプリケーションを右クリックし、**[Set as Entry Point]** (エントリ ポイントとして設定) を選びます。</span><span class="sxs-lookup"><span data-stu-id="7219d-129">In the **Applications** node, right-click the application that you want users to start when they choose the app's tile, and then choose **Set as Entry Point**.</span></span>

   ![エントリ ポイントの設定](images/desktop-to-uwp/entry-point-set.png)

6. <span data-ttu-id="7219d-131">パッケージ プロジェクトをビルドし、エラーが表示されないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="7219d-131">Build the packaging project to ensure that no errors appear.</span></span>  <span data-ttu-id="7219d-132">エラーが発生した場合は開きます**Configuration Manager**プロジェクトのターゲット プラットフォームが同じことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="7219d-132">If you receive errors, open **Configuration Manager** and ensure that your projects target the same platform.</span></span>

   ![構成マネージャー](images/desktop-to-uwp/config-manager.png)

7. <span data-ttu-id="7219d-134">[アプリ パッケージの作成](../packaging/packaging-uwp-apps.md)ウィザードを使って、appxupload ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="7219d-134">Use the [Create App Packages](../packaging/packaging-uwp-apps.md) wizard to generate an appxupload file.</span></span>

   <span data-ttu-id="7219d-135">ストアに直接、そのファイルをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="7219d-135">You can upload that file directly to the Store.</span></span>

<span data-ttu-id="7219d-136">**ビデオ**</span><span class="sxs-lookup"><span data-stu-id="7219d-136">**Video**</span></span>

&nbsp;
> [!VIDEO https://www.youtube-nocookie.com/embed/fJkbYPyd08w]

## <a name="next-steps"></a><span data-ttu-id="7219d-137">次のステップ</span><span class="sxs-lookup"><span data-stu-id="7219d-137">Next steps</span></span>

<span data-ttu-id="7219d-138">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="7219d-138">**Find answers to your questions**</span></span>

<span data-ttu-id="7219d-139">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="7219d-139">Have questions?</span></span> <span data-ttu-id="7219d-140">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="7219d-140">Ask us on Stack Overflow.</span></span> <span data-ttu-id="7219d-141">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="7219d-141">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="7219d-142">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="7219d-142">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="7219d-143">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="7219d-143">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="7219d-144">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7219d-144">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

<span data-ttu-id="7219d-145">**実行、デバッグまたはお客様のデスクトップ アプリケーションのテスト**</span><span class="sxs-lookup"><span data-stu-id="7219d-145">**Run, debug or test your desktop application**</span></span>

<span data-ttu-id="7219d-146">参照してください[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)</span><span class="sxs-lookup"><span data-stu-id="7219d-146">See [Run, debug, and test a packaged desktop application](desktop-to-uwp-debug.md)</span></span>

<span data-ttu-id="7219d-147">**UWP Api を追加することで、デスクトップ アプリケーションを強化します。**</span><span class="sxs-lookup"><span data-stu-id="7219d-147">**Enhance your desktop application by adding UWP APIs**</span></span>

<span data-ttu-id="7219d-148">「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7219d-148">See [Enhance your desktop application for Windows 10](desktop-to-uwp-enhance.md)</span></span>

<span data-ttu-id="7219d-149">**UWP プロジェクトと Windows ランタイム コンポーネントを追加することで、デスクトップ アプリケーションを拡張します。**</span><span class="sxs-lookup"><span data-stu-id="7219d-149">**Extend your desktop application by adding UWP projects and Windows Runtime Components**</span></span>

<span data-ttu-id="7219d-150">「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7219d-150">See [Extend your desktop application with modern UWP components](desktop-to-uwp-extend.md).</span></span>

<span data-ttu-id="7219d-151">**アプリを配布します。**</span><span class="sxs-lookup"><span data-stu-id="7219d-151">**Distribute your app**</span></span>

<span data-ttu-id="7219d-152">参照してください[パッケージ化されたデスクトップ アプリケーションの配布](desktop-to-uwp-distribute.md)</span><span class="sxs-lookup"><span data-stu-id="7219d-152">See [Distribute a packaged desktop application](desktop-to-uwp-distribute.md)</span></span>
