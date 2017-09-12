---
author: normesta
Description: "このガイドでは、デスクトップ ブリッジに関して、デスクトップ アプリを編集、デバッグ、パッケージ化するために Visual Studio ソリューションを構成する方法について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "Visual Studio を使ったアプリのパッケージ化 (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 07/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
ms.openlocfilehash: d8919448b965f18ff7f8fdaeda325889e495ef85
ms.sourcegitcommit: f6dd9568eafa10ee5cb2b849c0d82d84a1c5fb93
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/02/2017
---
# <a name="package-an-app-by-using-visual-studio-desktop-bridge"></a><span data-ttu-id="7b9ab-104">Visual Studio を使ったアプリのパッケージ化 (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="7b9ab-104">Package an app by using Visual Studio (Desktop Bridge)</span></span>

<span data-ttu-id="7b9ab-105">Visual Studio を使用して、デスクトップ アプリのパッケージを生成できます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-105">You can use Visual Studio to generate a package for your desktop app.</span></span> <span data-ttu-id="7b9ab-106">その後、そのパッケージを Windows ストアに公開したり、1 台以上の PC にサイドローディングしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-106">Then, you can publish that package to the Windows store or sideload it onto one or more PCs.</span></span>

<span data-ttu-id="7b9ab-107">このガイドでは、ソリューションをセットアップして、デスクトップ アプリケーションのパッケージを生成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-107">This guide shows you how to set up your solution and then generate a package for your desktop application.</span></span>

## <a name="first-consider-how-youll-distribute-your-app"></a><span data-ttu-id="7b9ab-108">まず、アプリの配布方法を検討する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-108">First, consider how you'll distribute your app</span></span>

<span data-ttu-id="7b9ab-109">アプリを [Windows ストア](https://www.microsoft.com/store/apps)に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-109">If you plan to publish your app to the [Windows Store](https://www.microsoft.com/store/apps), start by filling out [this form](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge).</span></span> <span data-ttu-id="7b9ab-110">Microsoft から、オンボード プロセスを開始するための連絡があります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-110">Microsoft will contact you to start the onboarding process.</span></span> <span data-ttu-id="7b9ab-111">このプロセスでは、ストア内の名前を予約し、アプリをパッケージ化するための情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-111">As part of this process, you'll reserve a name in the store, and obtain information that you'll need to package your app.</span></span>

## <a name="add-a-packaging-project-to-your-solution"></a><span data-ttu-id="7b9ab-112">パッケージ プロジェクトをソリューションに追加する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-112">Add a packaging project to your solution</span></span>

1. <span data-ttu-id="7b9ab-113">Visual Studio で、デスクトップ アプリケーション プロジェクトが含まれたソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-113">In Visual Studio, open the solution that contains your desktop application project.</span></span>

2. <span data-ttu-id="7b9ab-114">ソリューションに JavaScript の **[空白のアプリ (ユニバーサル Windows)]** プロジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-114">Add a JavaScript **Blank App (Universal Windows)** project to your solution.</span></span>

   <span data-ttu-id="7b9ab-115">コードを追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-115">You won't have to add any code to it.</span></span> <span data-ttu-id="7b9ab-116">プロジェクトを追加したのは単にパッケージを生成するためです。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-116">It's just there to generate a package for you.</span></span> <span data-ttu-id="7b9ab-117">このプロジェクトを "パッケージ プロジェクト" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-117">We'll refer to this project as the "packaging project".</span></span>

   ![JavaScript の UWP プロジェクト](images/desktop-to-uwp/javascript-uwp-project.png)

   >[!IMPORTANT]
   ><span data-ttu-id="7b9ab-119">通常、このプロジェクトには JavaScript バージョンを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-119">In general, you should use the JavaScript version of this project.</span></span>  <span data-ttu-id="7b9ab-120">C#、VB.NET、および C++ バージョンにはいくつかの問題があります。これらを使用する場合は、作業を行う前に[既知の問題](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-known-issues#known-issues-anchor)のガイドをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-120">The C#, VB.NET, and C++ versions have a few issues but if you want to use of those, see the [Known Issues](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-known-issues#known-issues-anchor) guide before you do.</span></span>

## <a name="add-the-desktop-application-binaries-to-the-packaging-project"></a><span data-ttu-id="7b9ab-121">デスクトップ アプリケーション バイナリをパッケージ プロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-121">Add the desktop application binaries to the packaging project</span></span>

<span data-ttu-id="7b9ab-122">パッケージ プロジェクトにバイナリを直接追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-122">Add the binaries directly to the packaging project.</span></span>

1. <span data-ttu-id="7b9ab-123">**ソリューション エクスプローラー**で、パッケージ プロジェクト フォルダーを展開し、サブフォルダーを作成して、任意の名前 (**win32** など) を付けます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-123">In **Solution Explorer**, expand the packaging project folder, create a subfolder, and name it whatever you want (For example: **win32**).</span></span>

2. <span data-ttu-id="7b9ab-124">サブフォルダーを右クリックし、**[既存項目の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-124">Right-click the subfolder, and then choose **Add Existing Item**.</span></span>

3. <span data-ttu-id="7b9ab-125">**[既存項目の追加]** ダイアログ ボックスで、デスクトップ アプリケーションの出力フォルダーのファイルを見つけて、追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-125">In the **Add Existing Item** dialog box, locate and then add the files from your desktop application's output folder.</span></span> <span data-ttu-id="7b9ab-126">これには、実行可能ファイルだけでなく、そのフォルダー内にある dll ファイルや .config ファイルも含まれます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-126">This includes not just the executable files, but any dlls or .config files that are located in that folder.</span></span>

   ![実行可能ファイルの参照](images/desktop-to-uwp/cpp-exe-reference.png)

   <span data-ttu-id="7b9ab-128">デスクトップ アプリケーション プロジェクトに変更を加えるたびに、これらのファイルの新しいバージョンをパッケージ プロジェクトにコピーする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-128">Every time you make a change to your desktop application project, you'll have to copy a new version of those files to the packaging project.</span></span> <span data-ttu-id="7b9ab-129">この作業を自動化するには、パッケージ プロジェクトのプロジェクト ファイルにビルド後のイベントを追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-129">You can automate this by adding a post-build event to the project file of the packaging project.</span></span> <span data-ttu-id="7b9ab-130">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-130">Here's an example.</span></span>

   ```XML
   <Target Name="PostBuildEvent">
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyWindowsFormsApplication.exe"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyWindowsFormsApplication.exe.config"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyWindowsFormsApplication.pdb"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyBusinessLogicLibrary.dll"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyBusinessLogicLibrary.pdb"
       DestinationFolder="win32" />
   </Target>
   ```

## <a name="modify-the-package-manifest"></a><span data-ttu-id="7b9ab-131">パッケージ マニフェストの変更</span><span class="sxs-lookup"><span data-stu-id="7b9ab-131">Modify the package manifest</span></span>

<span data-ttu-id="7b9ab-132">パッケージ プロジェクトには、パッケージの設定を記述したファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-132">The packaging project contains a file that describes the settings of your package.</span></span> <span data-ttu-id="7b9ab-133">既定では、このファイルには UWP アプリが記述されています。そのため、完全信頼で実行されるデスクトップ アプリケーションがパッケージに含まれていることをシステムで認識するように、このファイルを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-133">By default, this file describes a UWP app, so you'll have to modify it so that the system understands that your package includes a desktop application that runs in full trust.</span></span>  

1. <span data-ttu-id="7b9ab-134">**ソリューション エクスプ ローラー**で、パッケージ プロジェクトを展開し、**package.appxmanifest** ファイルを右クリックして、**[コードの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-134">In **Solution Explorer**, expand the packaging project, right-click the **package.appxmanifest** file, and then choose **View Code**.</span></span>

   ![.NET プロジェクトの参照](images/desktop-to-uwp/reference-dotnet-project.png)

2. <span data-ttu-id="7b9ab-136">次の名前空間をファイルの先頭に追加してから、``IgnorableNamespaces`` のリストに名前空間のプレフィックスを追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-136">Add this namespace to the top of the file, and add the namespace prefix to the list of ``IgnorableNamespaces``.</span></span>

   ```XML
   xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
   ```
   <span data-ttu-id="7b9ab-137">作業が完了すると、名前空間の宣言は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-137">When you're done, your namespace declarations will look something like this:</span></span>

   ```XML
   <Package
     xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
     xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
     xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
     xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
     IgnorableNamespaces="uap mp rescap">
   ```

3. <span data-ttu-id="7b9ab-138">``TargetDeviceFamily`` 要素を見つけて、``Name`` 属性を **Windows.Desktop** に、``MinVersion`` 属性をパッケージ プロジェクトの最小バージョンに、``MaxVersionTested`` をパッケージ プロジェクトのターゲット バージョンにそれぞれ設定します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-138">Find the ``TargetDeviceFamily`` element, and set the ``Name`` attribute to **Windows.Desktop**, the ``MinVersion`` attribute to the minimum version of the packaging project, and the ``MaxVersionTested`` to the target version of the packaging project.</span></span>

   ```XML
   <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.10586.0" MaxVersionTested="10.0.15063.0" />
   ```

   <span data-ttu-id="7b9ab-139">最小バージョンとターゲット バージョンは、パッケージ プロジェクトのプロパティ ページで確認できます。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-139">You can find the minimum version and target version in the property pages of the packaging project.</span></span>

   ![最小バージョンとターゲット バージョンの設定](images/desktop-to-uwp/min-target-version-settings.png)


4. <span data-ttu-id="7b9ab-141">``Application`` 要素から ``StartPage`` 属性を削除します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-141">Remove the ``StartPage`` attribute from the ``Application`` element.</span></span> <span data-ttu-id="7b9ab-142">次に、``Executable`` 属性と ``EntryPoint`` 属性を追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-142">Then, add the``Executable`` and ``EntryPoint`` attributes.</span></span>

   <span data-ttu-id="7b9ab-143">``Application`` 要素は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-143">The ``Application`` element will look like this.</span></span>

   ```XML
   <Application Id="App"  Executable=" " EntryPoint=" ">
   ```

5. <span data-ttu-id="7b9ab-144">``Executable`` 属性を、デスクトップ アプリケーションの実行可能ファイルの名前に設定します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-144">Set the ``Executable`` attribute to the name of your desktop application's executable file.</span></span> <span data-ttu-id="7b9ab-145">次に、``EntryPoint`` 属性を **Windows.FullTrustApplication** に設定します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-145">Then, set the ``EntryPoint`` attribute to **Windows.FullTrustApplication**.</span></span>

   <span data-ttu-id="7b9ab-146">``Application`` 要素は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-146">The ``Application`` element will look similar to this.</span></span>

   ```XML
   <Application Id="App"  Executable="win32\MyWindowsFormsApplication.exe" EntryPoint="Windows.FullTrustApplication">
   ```
6. <span data-ttu-id="7b9ab-147">``runFullTrust`` 機能を ``Capabilities`` 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-147">Add the ``runFullTrust`` capability to the ``Capabilities`` element.</span></span>

   ```XML
     <rescap:Capability Name="runFullTrust"/>
   ```
   <span data-ttu-id="7b9ab-148">この宣言の下に青い波線マークが表示される可能性がありますが、これは無視して問題ありません。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-148">Blue squiggly marks might appear beneath this declaration, but you can safely ignore them.</span></span>

   >[!IMPORTANT]
   <span data-ttu-id="7b9ab-149">C++ デスクトップ アプリケーションのパッケージを作成する場合は、アプリと共に Visual C++ ランタイムを展開できるように、マニフェスト ファイルにいくつか追加の変更を加えることが必要になります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-149">If your creating a package for a C++ desktop application, you'll have to make a few extra changes to your manifest file so that you can deploy the Visual C++ runtimes along with your app.</span></span> <span data-ttu-id="7b9ab-150">[デスクトップ ブリッジ プロジェクトでの Visual C++ ランタイムの使用に関するページ](https://blogs.msdn.microsoft.com/vcblog/2016/07/07/using-visual-c-runtime-in-centennial-project/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-150">See [Using Visual C++ runtimes in a desktop bridge project](https://blogs.msdn.microsoft.com/vcblog/2016/07/07/using-visual-c-runtime-in-centennial-project/).</span></span>

7. <span data-ttu-id="7b9ab-151">パッケージ プロジェクトをビルドし、エラーが表示されないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-151">Build the packaging project to ensure that no errors appear.</span></span>

8. <span data-ttu-id="7b9ab-152">パッケージをテストする場合は、「[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-152">If you want to test your package, see [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md).</span></span>

   <span data-ttu-id="7b9ab-153">その後、このガイドに戻ったら、次のセクションを確認してパッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-153">Then, return to this guide, and see the next section to generate your package.</span></span>

## <a name="generate-a-package"></a><span data-ttu-id="7b9ab-154">パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="7b9ab-154">Generate a package</span></span>

<span data-ttu-id="7b9ab-155">アプリのパッケージを生成する方法については、「[UWP アプリのパッケージ化](..\packaging\packaging-uwp-apps.md)」のトピックのガイダンスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-155">To generate a package your app, follow the guidance described in this topic: [Packaging UWP Apps](..\packaging\packaging-uwp-apps.md).</span></span>

<span data-ttu-id="7b9ab-156">**[パッケージの選択と構成]** 画面が表示されたら、いずれかのチェック ボックスを選択する前に、パッケージに含まれているバイナリの種類について少し考える必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-156">When you reach the **Select and Configure Packages** screen, Take a moment to consider what sorts of binaries you're including in your package before you select any of the checkboxes.</span></span>

* <span data-ttu-id="7b9ab-157">C#、C++、または VB.NET ベースのユニバーサル Windows プラットフォーム プロジェクトをソリューションに追加してデスクトップ アプリケーションを[拡張](desktop-to-uwp-extend.md)している場合は、**[x86]** および **[x64]** のチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-157">If you've [extended](desktop-to-uwp-extend.md) your desktop application by adding a adding a C#, C++, or VB.NET-based Universal Windows Platform project to your solution, select the **x86** and **x64** checkboxes.</span></span>  

* <span data-ttu-id="7b9ab-158">それ以外の場合は、**[ニュートラル]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-158">Otherwise, choose the **Neutral** checkbox.</span></span>

>[!NOTE]
<span data-ttu-id="7b9ab-159">サポート対象の各プラットフォームを明示的に選択することが必要になるのは、拡張したソリューションに、UWP プロジェクト用とデスクトップ プロジェクト用という、2 種類のバイナリが含まれているためです。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-159">The reason that you'd have to explicitly choose each supported platform is because an solution that you've extended contains two types of binaries; one for the UWP project and one for the desktop project.</span></span> <span data-ttu-id="7b9ab-160">これらはバイナリの種類が異なるため、.NET Native ではプラットフォームごとにネイティブ バイナリを明示的に生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-160">Because these are different types of binaries, .NET Native needs to explicitly produce native binaries for each platform.</span></span>

<span data-ttu-id="7b9ab-161">パッケージを生成しようとするとエラーが表示される場合は、[既知の問題](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-known-issues#known-issues-anchor)のガイドをご覧ください。発生している問題がリスト内に見つからない場合は、その問題について[こちら](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)でお知らせください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-161">If you receive errors when you attempt to generate your package, see the [Known Issues](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-known-issues#known-issues-anchor) guide and if your issue does not appear in that list, please share the issue with us [here](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

## <a name="next-steps"></a><span data-ttu-id="7b9ab-162">次のステップ</span><span class="sxs-lookup"><span data-stu-id="7b9ab-162">Next steps</span></span>

**<span data-ttu-id="7b9ab-163">アプリを実行する/問題を検出して修正する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-163">Run your app / find and fix issues</span></span>**

<span data-ttu-id="7b9ab-164">「[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-164">See [Run, debug, and test a packaged desktop app (Desktop Bridge)](desktop-to-uwp-debug.md)</span></span>

**<span data-ttu-id="7b9ab-165">UWP API を追加してデスクトップ アプリを強化する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-165">Enhance your desktop app by adding UWP APIs</span></span>**

<span data-ttu-id="7b9ab-166">「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-166">See [Enhance your desktop application for Windows 10](desktop-to-uwp-enhance.md)</span></span>

**<span data-ttu-id="7b9ab-167">UWP コンポーネントを追加してデスクトップ アプリを拡張する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-167">Extend your desktop app by adding UWP components</span></span>**

<span data-ttu-id="7b9ab-168">「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-168">See [Extend your desktop application with modern UWP components](desktop-to-uwp-extend.md).</span></span>

**<span data-ttu-id="7b9ab-169">アプリを配布する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-169">Distribute your app</span></span>**

<span data-ttu-id="7b9ab-170">「[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-170">See [Distribute a packaged desktop app (Desktop Bridge)](desktop-to-uwp-distribute.md)</span></span>

**<span data-ttu-id="7b9ab-171">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="7b9ab-171">Find answers to specific questions</span></span>**

<span data-ttu-id="7b9ab-172">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-172">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="7b9ab-173">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="7b9ab-173">Give feedback about this article</span></span>**

<span data-ttu-id="7b9ab-174">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="7b9ab-174">Use the comments section below.</span></span>
