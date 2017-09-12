---
author: normesta
Description: "署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。 その後、ブレークポイントを設定し、コード全体をステップ実行します。 運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。"
Search.Product: eADQiWindows 10XVcnh
title: "パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 06/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.openlocfilehash: c160fecc530a6366de48f4f2ecc24df2463c0469
ms.sourcegitcommit: 77bbd060f9253f2b03f0b9d74954c187bceb4a30
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="run-debug-and-test-a-packaged-desktop-app-desktop-bridge"></a><span data-ttu-id="4985b-106">パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="4985b-106">Run, debug, and test a packaged desktop app (Desktop Bridge)</span></span>

<span data-ttu-id="4985b-107">署名せずにパッケージ アプリを実行し、その外観を確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="4985b-107">Run your packaged app and see how it looks without having to sign it.</span></span> <span data-ttu-id="4985b-108">その後、ブレークポイントを設定し、コード全体をステップ実行します。</span><span class="sxs-lookup"><span data-stu-id="4985b-108">Then, set breakpoints and step through code.</span></span> <span data-ttu-id="4985b-109">運用環境でアプリをテストする準備ができたら、アプリに署名してインストールします。</span><span class="sxs-lookup"><span data-stu-id="4985b-109">When you're ready to test your app in a production environment, sign your app and then install it.</span></span> <span data-ttu-id="4985b-110">このトピックでは、これらの作業を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="4985b-110">This topic shows you how to do each of these things.</span></span>

<span id="run-app" />
## <a name="run-your-app"></a><span data-ttu-id="4985b-111">アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="4985b-111">Run your app</span></span>

<span data-ttu-id="4985b-112">証明書を取得して署名する作業を行わなくても、アプリをローカルで実行およびテストできます。</span><span class="sxs-lookup"><span data-stu-id="4985b-112">You can run your app to test it out locally without having to obtain a certificate and sign it.</span></span>

<span data-ttu-id="4985b-113">Visual Studio の UWP プロジェクトを使用してパッケージを作成した場合、パッケージ プロジェクトをスタートアップ プロジェクトに設定するだけで、Ctrl キーを押しながら F5 キーを押すことでアプリが起動するようになります。</span><span class="sxs-lookup"><span data-stu-id="4985b-113">If you created your package by using a UWP project in Visual Studio, just set the packaging project as the startup project, and then press CTRL+F5 to start your app.</span></span>

<span data-ttu-id="4985b-114">Desktop App Converter を使用した場合やアプリを手動でパッケージ化した場合は、Windows PowerShell コマンド プロンプトを開き、出力フォルダーの **PacakgeFiles** サブフォルダーから次のコマンドレットを実行します。</span><span class="sxs-lookup"><span data-stu-id="4985b-114">If you used the Desktop App Converter or you package your app manually, open a Windows PowerShell command prompt, and from the **PacakgeFiles** subfolder of your output folder, run this cmdlet:</span></span>

```
Add-AppxPackage –Register AppxManifest.xml
```
<span data-ttu-id="4985b-115">アプリを起動するには、そのアプリを Windows スタート メニューで見つけます。</span><span class="sxs-lookup"><span data-stu-id="4985b-115">To start your app, find it in the Windows Start menu.</span></span>

![スタート メニューに表示されたパッケージ アプリ](images/desktop-to-uwp/converted-app-installed.png)

> [!NOTE]
> <span data-ttu-id="4985b-117">パッケージ アプリは、常に対話ユーザーとして実行されます。パッケージ アプリをインストールするドライブは、NTFS 形式にフォーマットされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985b-117">A packaged app always runs as an interactive user, and any drive that you install your packaged app on to must be formatted to NTFS format.</span></span>

## <a name="debug-your-app"></a><span data-ttu-id="4985b-118">アプリのデバッグ</span><span class="sxs-lookup"><span data-stu-id="4985b-118">Debug your app</span></span>

<span data-ttu-id="4985b-119">アプリをデバッグするたびにダイアログ ボックスでパッケージを選択するか、拡張機能をインストールして、セッションを開始するたびにパッケージを選ぶことなくアプリをデバッグできます。</span><span class="sxs-lookup"><span data-stu-id="4985b-119">Select your package in a dialog box each time that you debug your app or install an extension and debug your app without having to select your package each time that you start the session.</span></span>

### <a name="debug-your-app-by-selecting-the-package"></a><span data-ttu-id="4985b-120">パッケージを選択してアプリをデバッグする</span><span class="sxs-lookup"><span data-stu-id="4985b-120">Debug your app by selecting the package</span></span>

<span data-ttu-id="4985b-121">このオプションでは、セットアップの時間は最短ですが、デバッグ セッションを開始するたびに余分な手順が必要になります。</span><span class="sxs-lookup"><span data-stu-id="4985b-121">This option has the least amount of setup time, but requires you to perform an extra step each time you want to start the debug session.</span></span>


1. <span data-ttu-id="4985b-122">パッケージ アプリがローカル コンピューターにインストールされるように、必ず、パッケージ アプリを 1 回以上起動します。</span><span class="sxs-lookup"><span data-stu-id="4985b-122">Make sure that you start your packaged app at least one time so that it's installed on your local machine.</span></span>

   <span data-ttu-id="4985b-123">上の「[アプリを実行する](#run-app)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-123">See the [Run your app](#run-app) section above.</span></span>

2. <span data-ttu-id="4985b-124">Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="4985b-124">Start Visual Studio.</span></span>

   <span data-ttu-id="4985b-125">管理者特権でアプリをデバッグする場合は、**[管理者として実行]** オプションを使用して Visual Studio を起動します。</span><span class="sxs-lookup"><span data-stu-id="4985b-125">If you want to debug your app with elevated permissions, start Visual Studio by using the **Run as Administrator** option.</span></span>

3. <span data-ttu-id="4985b-126">Visual Studio で、**[デバッグ]**->**[その他のデバッグ ターゲット]**->**[インストールされているアプリケーション パッケージのデバッグ]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="4985b-126">In Visual Studio, choose **Debug**->**Other Debug Targets**->**Debug Installed App Package**.</span></span>

4. <span data-ttu-id="4985b-127">**[インストールされているアプリケーション パッケージのデバッグ]** リストで、目的のアプリ パッケージを選び、**[アタッチ]** ボタンを選択します。</span><span class="sxs-lookup"><span data-stu-id="4985b-127">In the **Installed App Packages** list, select your app package, and then choose the **Attach** button.</span></span>


### <a name="debug-your-app-without-having-to-select-the-package"></a><span data-ttu-id="4985b-128">パッケージを選択せずにアプリをデバッグする</span><span class="sxs-lookup"><span data-stu-id="4985b-128">Debug your app without having to select the package</span></span>

<span data-ttu-id="4985b-129">このオプションでは、セットアップの時間が最長になりますが、アプリを起動するたびにインストールされているパッケージを選択する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="4985b-129">This option has the most amount of setup time, but you won't have to select the installed package every time you start your app.</span></span> <span data-ttu-id="4985b-130">このアプローチを使用するには、[Visual Studio 2017](https://www.visualstudio.com/vs/whatsnew/) をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985b-130">You'll need to install [Visual Studio 2017](https://www.visualstudio.com/vs/whatsnew/) to use this approach.</span></span>

1. <span data-ttu-id="4985b-131">まず、[Desktop Bridge Debugging Project](http://go.microsoft.com/fwlink/?LinkId=797871)をインストールします。</span><span class="sxs-lookup"><span data-stu-id="4985b-131">First, install the [Desktop Bridge Debugging Project](http://go.microsoft.com/fwlink/?LinkId=797871).</span></span>

2. <span data-ttu-id="4985b-132">Visual Studio を起動し、デスクトップ アプリケーション プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="4985b-132">Start Visual Studio, and open the desktop application project.</span></span>

6. <span data-ttu-id="4985b-133">**Desktop Bridge Debugging Project** をソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="4985b-133">Add a **Desktop Bridge Debugging** project to your solution.</span></span>

   <span data-ttu-id="4985b-134">プロジェクトのテンプレートは、インストール済みテンプレートの **[その他のプロジェクトの種類]** グループにあります。</span><span class="sxs-lookup"><span data-stu-id="4985b-134">You can find the project template in the **Other Project Types** group of installed templates.</span></span>

    ![alt](images/desktop-to-uwp/debug-2.png)

    <span data-ttu-id="4985b-136">**Desktop Bridge Debugging Project** がソリューションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="4985b-136">The **Desktop Bridge Debugging** project will appear in your solution.</span></span>

    ![alt](images/desktop-to-uwp/debug-3.png)

7. <span data-ttu-id="4985b-138">**Desktop Bridge Debugging Project** のプロパティ ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="4985b-138">Open the property pages of the **Desktop Bridge Debugging** project.</span></span>

8. <span data-ttu-id="4985b-139">**[パッケージ レイアウト]** フィールドをパッケージ マニフェスト ファイル (AppxManifest.xml) の場所に設定し、**[スタート画面のタイル]** ドロップダウン リストからアプリの実行可能ファイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="4985b-139">Set the **Package Layout** field to the location of your package manifest file (AppxManifest.xml), and choose your app's executable file from the **Start Up Tile** drop-down list.</span></span>

     ![alt](images/desktop-to-uwp/debug-4.png)

8. <span data-ttu-id="4985b-141">コード エディターで、AppXPackageFileList.xml ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="4985b-141">Open the AppXPackageFileList.xml file in the code editor.</span></span>

9. <span data-ttu-id="4985b-142">以下の要素について、XML ブロックのコメントを解除し、値を追加します。</span><span class="sxs-lookup"><span data-stu-id="4985b-142">Uncomment the block of XML and add values for these elements:</span></span>

   <span data-ttu-id="4985b-143">**MyProjectOutputPath**: デスクトップ アプリケーションのデバッグ フォルダーの相対パス。</span><span class="sxs-lookup"><span data-stu-id="4985b-143">**MyProjectOutputPath**: The relative path to debug folder of your desktop application.</span></span>

   <span data-ttu-id="4985b-144">**LayoutFile**: デスクトップ アプリケーションのデバッグ フォルダーにある実行可能ファイル。</span><span class="sxs-lookup"><span data-stu-id="4985b-144">**LayoutFile**: The executable that is in the debug folder of your desktop application.</span></span>

   <span data-ttu-id="4985b-145">**PackagePath**: 変換プロセス中に Windows アプリ パッケージ フォルダーにコピーされた、デスクトップ アプリケーションの実行可能ファイルの完全修飾ファイル名。</span><span class="sxs-lookup"><span data-stu-id="4985b-145">**PackagePath**: The fully qualified file name of your desktop application's executable that was copied to your Windows app package folder during the conversion process.</span></span>

    <span data-ttu-id="4985b-146">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="4985b-146">Here's an example:</span></span>

    ```XML
  <?xml version="1.0" encoding="utf-8"?>
  <Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
     <MyProjectOutputPath>..\MyDesktopApp\bin\Debug</MyProjectOutputPath>
    </PropertyGroup>
    <ItemGroup>
      <LayoutFile Include="$(MyProjectOutputPath)\MyDesktopApp.exe">
        <PackagePath>$(PackageLayout)\MyDesktopApp.exe</PackagePath>
      </LayoutFile>
    </ItemGroup>
  </Project>
    ```

  <span data-ttu-id="4985b-147">ソリューション内の他のプロジェクトから生成された dll ファイルをアプリで使用する場合に、これらの DLL に含まれるコードにステップ インするには、各 dll ファイル用の **LayoutFile** 要素を含めます。</span><span class="sxs-lookup"><span data-stu-id="4985b-147">If your app consumes dll files that are generated from other projects in your solution, and you want to step into the code that is contained in those dlls, include a **LayoutFile** element for each of those dll files.</span></span>

  ```XML
  ...
      <LayoutFile Include="$(MyProjectOutputPath)\MyDesktopApp.Models.dll">
      <PackagePath>$(PackageLayout)\MyDesktopApp.Models.dll</PackagePath>
      </LayoutFile>
  ...
  ```

10. <span data-ttu-id="4985b-148">パッケージ プロジェクトをスタートアップ プロジェクトに設定します。</span><span class="sxs-lookup"><span data-stu-id="4985b-148">Set the packaging project the start-up project.</span></span>  

    ![alt](images/desktop-to-uwp/debug-5.png)

11. <span data-ttu-id="4985b-150">デスクトップ アプリケーション コードにブレークポイントを設定し、デバッガーを起動します。</span><span class="sxs-lookup"><span data-stu-id="4985b-150">Set breakpoints in your desktop application code, and then start the debugger.</span></span>

  ![デバッグ ボタン](images/desktop-to-uwp/debugger-button.png)

  <span data-ttu-id="4985b-152">Visual Studio は、XML ファイルで指定した実行可能ファイルと dll ファイルを Windows アプリ パッケージにコピーして、デバッガーを起動します。</span><span class="sxs-lookup"><span data-stu-id="4985b-152">Visual Studio copies the executables and dll files that you specified in the XML file to your Windows app package and then start the debugger.</span></span>

#### <a name="handle-multiple-build-configurations"></a><span data-ttu-id="4985b-153">複数のビルド構成を処理する</span><span class="sxs-lookup"><span data-stu-id="4985b-153">Handle multiple build configurations</span></span>

<span data-ttu-id="4985b-154">複数のビルド構成 (Release と Debug など) を定義した場合は、デバッガーの起動時に Visual Studio で選択されたビルド構成に一致するファイルのみがコピーされるように、AppXPackageFileList.xml ファイルを修正することができます。</span><span class="sxs-lookup"><span data-stu-id="4985b-154">If you've defined multiple build configurations (for example: Release and Debug), you can modify your AppXPackageFileList.xml file to copy only those files that match the build configuration that choose in Visual Studio when you start the debugger.</span></span>

<span data-ttu-id="4985b-155">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="4985b-155">Here's an example.</span></span>

```XML
<PropertyGroup>
    <MyProjectOutputPath Condition="$(Configuration) == 'Debug'">..\MyDesktopApp\bin\Debug</MyProjectOutputPath>
    <MyProjectOutputPath Condition="$(Configuration) == 'Release'"> ..\MyDesktopApp\bin\Release</MyProjectOutputPath>
</PropertyGroup>
```

#### <a name="debug-uwp-enhancements-to-your-app"></a><span data-ttu-id="4985b-156">アプリに対する UWP 機能強化についてデバッグする</span><span class="sxs-lookup"><span data-stu-id="4985b-156">Debug UWP enhancements to your app</span></span>

<span data-ttu-id="4985b-157">ライブ タイルなどの最新のエクスペリエンスでアプリの機能を強化することもできます。</span><span class="sxs-lookup"><span data-stu-id="4985b-157">You might want to enhance your app with modern experiences such as live tiles.</span></span> <span data-ttu-id="4985b-158">その場合は、条件付きコンパイルを使用して、指定されたビルド構成でコード パスを有効にします。</span><span class="sxs-lookup"><span data-stu-id="4985b-158">If you do, you can use conditional compilation to enable code paths with specific build configurations.</span></span>

1. <span data-ttu-id="4985b-159">まず、Visual Studio でビルド構成を定義し、「DesktopUWP」などの名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="4985b-159">First, in Visual Studio, define a build configuration and give it a name like "DesktopUWP".</span></span>

2. <span data-ttu-id="4985b-160">プロジェクトのプロジェクト プロパティの **[ビルド]** タブで、その名前を **[条件付きコンパイル シンボル]** フィールドに追加します。</span><span class="sxs-lookup"><span data-stu-id="4985b-160">In the **Build** tab of the project properties of your project, add that name in the **Conditional compilation symbols** field.</span></span>

     ![alt](images/desktop-to-uwp/debug-8.png)

3. <span data-ttu-id="4985b-162">条件付きコード ブロックを追加します。</span><span class="sxs-lookup"><span data-stu-id="4985b-162">Add conditional code blocks.</span></span> <span data-ttu-id="4985b-163">このコードは、**DesktopUWP** ビルド構成に対してのみコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="4985b-163">This code compiles only for the **DesktopUWP** build configuration.</span></span>

    ```csharp
    [Conditional("DesktopUWP")]
    private void showtile()
    {
        XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
        XmlNodeList textNodes = tileXml.GetElementsByTagName("text");
        textNodes[0].InnerText = string.Format("Welcome to DesktopUWP!");
        TileNotification tileNotification = new TileNotification(tileXml);
        TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
    }
    ```

### <a name="debug-the-entire-app-lifecycle"></a><span data-ttu-id="4985b-164">アプリ全体のライフ サイクルについてデバッグする</span><span class="sxs-lookup"><span data-stu-id="4985b-164">Debug the entire app lifecycle</span></span>

<span data-ttu-id="4985b-165">場合によっては、アプリを開始する前にデバッグを行うなど、デバッグ プロセスを細かく制御する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985b-165">In some cases, you might want finer-grained control over the debugging process, including the ability to debug your app before it starts.</span></span>

<span data-ttu-id="4985b-166">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) を使用すると、中断、再開、終了などを含むアプリのライフ サイクルについて、完全に制御できます。</span><span class="sxs-lookup"><span data-stu-id="4985b-166">You can use [PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) to get full control over app lifecycle including suspending, resuming, and termination.</span></span>

<span data-ttu-id="4985b-167">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) は Windows SDK に含まれています。</span><span class="sxs-lookup"><span data-stu-id="4985b-167">[PLMDebug](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) is included with the Windows SDK.</span></span>


### <a name="modify-your-app-in-between-debug-sessions"></a><span data-ttu-id="4985b-168">デバッグ セッションと次のデバッグ セッションの間にアプリを変更する</span><span class="sxs-lookup"><span data-stu-id="4985b-168">Modify your app in between debug sessions</span></span>

<span data-ttu-id="4985b-169">バグを修正するための変更をアプリに加えた場合は、MakeAppx ツールを使ってアプリを再パッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="4985b-169">If you make your changes to your app to fix bugs, repackage it by using the MakeAppx tool.</span></span> <span data-ttu-id="4985b-170">「[MakeAppx ツールを実行する](desktop-to-uwp-manual-conversion.md#make-appx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-170">See [Run the MakeAppx tool](desktop-to-uwp-manual-conversion.md#make-appx).</span></span>

## <a name="test-your-app"></a><span data-ttu-id="4985b-171">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="4985b-171">Test your app</span></span>

<span data-ttu-id="4985b-172">配布用の準備の一環として現実的な設定でアプリをテストするには、アプリに署名し、インストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4985b-172">To test your app in a realistic setting as you prepare for distribution, it's best to sign your app and then install it.</span></span>

<span data-ttu-id="4985b-173">Visual Studio を使ってアプリをパッケージ化した場合は、アプリに署名してインストールするスクリプトを実行できます。</span><span class="sxs-lookup"><span data-stu-id="4985b-173">If you packaged you app by using Visual Studio, you can run a script to sign your app and then install it.</span></span> <span data-ttu-id="4985b-174">「[アプリ パッケージをサイドローディングする](../packaging/packaging-uwp-apps.md#sideload-your-app-package)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-174">See [Sideload your package](../packaging/packaging-uwp-apps.md#sideload-your-app-package).</span></span>

<span data-ttu-id="4985b-175">Desktop App Converter を使用してアプリをパッケージ化する場合は、``sign`` パラメーターを使用し、生成された証明書を使って、アプリに自動的に署名します。</span><span class="sxs-lookup"><span data-stu-id="4985b-175">If you package your app by using the Desktop App Converter, you can use the ``sign`` parameter to automatically sign your app by using a generated certificate.</span></span> <span data-ttu-id="4985b-176">その証明書をインストールしてから、アプリをインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4985b-176">You'll have to install that certificate, and then install the app.</span></span> <span data-ttu-id="4985b-177">「[パッケージ アプリを実行する](desktop-to-uwp-run-desktop-app-converter.md#run-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-177">See [Run the packaged app](desktop-to-uwp-run-desktop-app-converter.md#run-app).</span></span>   

<span data-ttu-id="4985b-178">アプリには、手動で署名することもできます。</span><span class="sxs-lookup"><span data-stu-id="4985b-178">You can also sign your app manually.</span></span> <span data-ttu-id="4985b-179">その方法は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4985b-179">Here's how</span></span>

1. <span data-ttu-id="4985b-180">証明書を作成します。</span><span class="sxs-lookup"><span data-stu-id="4985b-180">Create a certificate.</span></span> <span data-ttu-id="4985b-181">「[証明書を作成する](../packaging/create-certificate-package-signing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-181">See [Create a certificate](../packaging/create-certificate-package-signing.md).</span></span>

2. <span data-ttu-id="4985b-182">その証明書をシステム上の証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールします。</span><span class="sxs-lookup"><span data-stu-id="4985b-182">Install that certificate into the **Trusted Root** or **Trusted People** certificate store on your system.</span></span>

3. <span data-ttu-id="4985b-183">その証明書を使ってアプリに署名します。「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-183">Sign your app by using that certificate, see [Sign an app package using SignTool](../packaging/sign-app-package-using-signtool.md).</span></span>

  > [!IMPORTANT]
  > <span data-ttu-id="4985b-184">証明書の発行元名がアプリの発行者名と一致することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4985b-184">Make sure that the publisher name on your certificate matches the publisher name of your app.</span></span>

### <a name="related-sample"></a><span data-ttu-id="4985b-185">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="4985b-185">Related sample</span></span>

[<span data-ttu-id="4985b-186">SigningCerts</span><span class="sxs-lookup"><span data-stu-id="4985b-186">SigningCerts</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SigningCerts)


### <a name="test-your-app-for-windows-10-s"></a><span data-ttu-id="4985b-187">アプリの Windows 10 S 対応をテストする</span><span class="sxs-lookup"><span data-stu-id="4985b-187">Test your app for Windows 10 S</span></span>

<span data-ttu-id="4985b-188">アプリを公開する前に、Windows 10 S を実行するデバイスでそのアプリが正しく動作することを確認してください。実際、Windows ストアにアプリを公開する予定がある場合はこの作業を行わなければなりません。それがストア要件になっているためです。</span><span class="sxs-lookup"><span data-stu-id="4985b-188">Before you publish your app, make sure that it will operate correctly on devices that run Windows 10 S. In fact, if you plan to publish your app to the Windows Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="4985b-189">Windows 10 S を実行するデバイスで正しく動作しないアプリは認定されません。</span><span class="sxs-lookup"><span data-stu-id="4985b-189">Apps that don't operate correctly on devices that run Windows 10 S won't be certified.</span></span> 

<span data-ttu-id="4985b-190">「[Windows アプリの Windows 10 S 対応をテストする](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-190">See [Test your Windows app for Windows 10 S](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-test-windows-s).</span></span>

### <a name="run-another-process-inside-the-full-trust-container"></a><span data-ttu-id="4985b-191">完全な信頼コンテナー内で別のプロセスを実行する</span><span class="sxs-lookup"><span data-stu-id="4985b-191">Run another process inside the full trust container</span></span>

<span data-ttu-id="4985b-192">指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="4985b-192">You can invoke custom processes inside the container of a specified app package.</span></span> <span data-ttu-id="4985b-193">これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。</span><span class="sxs-lookup"><span data-stu-id="4985b-193">This can be useful for testing scenarios (for example, if you have a custom test harness and want to test output of the app).</span></span> <span data-ttu-id="4985b-194">これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレットを使用します。</span><span class="sxs-lookup"><span data-stu-id="4985b-194">To do so, use the ```Invoke-CommandInDesktopPackage``` PowerShell cmdlet:</span></span>

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```

## <a name="next-steps"></a><span data-ttu-id="4985b-195">次のステップ</span><span class="sxs-lookup"><span data-stu-id="4985b-195">Next steps</span></span>

**<span data-ttu-id="4985b-196">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="4985b-196">Find answers to specific questions</span></span>**

<span data-ttu-id="4985b-197">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="4985b-197">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="4985b-198">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="4985b-198">Give feedback about this article</span></span>**

<span data-ttu-id="4985b-199">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="4985b-199">Use the comments section below.</span></span>
