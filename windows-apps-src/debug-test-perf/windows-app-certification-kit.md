---
author: PatrickFarley
ms.assetid: 78D833B9-E528-4BCA-9C48-A757F17E6C22
title: Windows アプリ認定キット
description: アプリに、Microsoft Store で公開されているの最適な機会を提供したり、Windows が認定の検証し認定のために提出する前にローカルでテストします。 このトピックでは、Windows アプリ認定キットのインストール方法と実行方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリの認定
ms.localizationpriority: medium
ms.openlocfilehash: b7a72a89704aa3768cc43cdfbb75b620bae303e3
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4573872"
---
# <a name="windows-app-certification-kit"></a><span data-ttu-id="b7336-105">Windows アプリ認定キット</span><span class="sxs-lookup"><span data-stu-id="b7336-105">Windows App Certification Kit</span></span>



<span data-ttu-id="b7336-106">[Windows](https://msdn.microsoft.com/windows/desktop/jj134964.aspx)認定を取得または[Microsoft Store に公開](https://msdn.microsoft.com/library/windows/apps/Hh694062)のための準備、する必要がありますの検証し、テスト ローカルで最初にします。</span><span class="sxs-lookup"><span data-stu-id="b7336-106">To get your app [Windows Certified](https://msdn.microsoft.com/windows/desktop/jj134964.aspx) or prepare it for [publication to the Microsoft Store](https://msdn.microsoft.com/library/windows/apps/Hh694062), you should validate and test it locally first.</span></span> <span data-ttu-id="b7336-107">このトピックでは、インストールして、アプリを安全かつ効率的に[Windows アプリ認定キット](http://go.microsoft.com/fwlink/p/?LinkID=309666)を実行する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="b7336-107">This topic shows you how to install and run the [Windows App Certification Kit](http://go.microsoft.com/fwlink/p/?LinkID=309666) to ensure your app is safe and efficient.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b7336-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="b7336-108">Prerequisites</span></span>

<span data-ttu-id="b7336-109">ユニバーサル Windows アプリのテストの前提条件:</span><span class="sxs-lookup"><span data-stu-id="b7336-109">Prerequisites for testing a Universal Windows app:</span></span>

-   <span data-ttu-id="b7336-110">Windows 10 をインストールして実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7336-110">You must install and run Windows 10.</span></span>
-   <span data-ttu-id="b7336-111">Windows 10 用 Windows ソフトウェア開発キット (Windows SDK) に含まれる [Windows アプリ認定キット 10]( http://go.microsoft.com/fwlink/p/?LinkID=309666) をインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7336-111">You must install [Windows App Certification Kit version 10]( http://go.microsoft.com/fwlink/p/?LinkID=309666), which is included in the Windows Software Development Kit (SDK) for Windows 10.</span></span>
-   <span data-ttu-id="b7336-112">[開発用にデバイスを有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7336-112">You must [enable your device for development](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development).</span></span>
-   <span data-ttu-id="b7336-113">テストする Windows アプリをコンピューターに展開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7336-113">You must deploy the Windows app that you want to test to your computer.</span></span>

**<span data-ttu-id="b7336-114">一括アップグレードに関する注意事項</span><span class="sxs-lookup"><span data-stu-id="b7336-114">A note about in-place upgrades</span></span>**

<span data-ttu-id="b7336-115">最新の [Windows アプリ認定キット]( http://go.microsoft.com/fwlink/p/?LinkID=309666)をインストールすると、コンピューターにインストールされているキットの以前のバージョンが置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="b7336-115">The installation of a more recent [Windows App Certification Kit]( http://go.microsoft.com/fwlink/p/?LinkID=309666) will replace any previous version of the kit that is installed on the machine.</span></span>

## <a name="validate-your-windows-app-using-the-windows-app-certification-kit-interactively"></a><span data-ttu-id="b7336-116">Windows アプリ認定キットを使った Windows アプリをインタラクティブに検証する</span><span class="sxs-lookup"><span data-stu-id="b7336-116">Validate your Windows app using the Windows App Certification Kit interactively</span></span>

1.  <span data-ttu-id="b7336-117">**[スタート]** メニューから、**[アプリ]**、**[Windows キット]** の順に進み、**[Windows アプリ認定キット]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7336-117">From the **Start** menu, search **Apps**, find **Windows Kits**, and click **Windows App Cert Kit**.</span></span>

2.  <span data-ttu-id="b7336-118">[Windows アプリ認定キット] で、実行する検証のカテゴリを選びます。</span><span class="sxs-lookup"><span data-stu-id="b7336-118">From the Windows App Certification Kit, select the category of validation you would like to perform.</span></span> <span data-ttu-id="b7336-119">たとえば、Windows アプリを検証する場合、**[Validate a Windows app]** (Windows アプリの検証) を選択します。</span><span class="sxs-lookup"><span data-stu-id="b7336-119">For example: If you are validating a Windows app, select **Validate a Windows app**.</span></span>

    <span data-ttu-id="b7336-120">テストするアプリを直接参照するか、UI で一覧からアプリを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="b7336-120">You may browse directly to the app you're testing, or choose the app from a list in the UI.</span></span> <span data-ttu-id="b7336-121">Windows アプリ認定キットを初めて実行すると、UI にはコンピューターにインストールされているすべての Windows アプリが一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-121">When the Windows App Certification Kit is run for the first time, the UI lists all the Windows apps that you have installed on your computer.</span></span> <span data-ttu-id="b7336-122">以降の実行では、UI には検証済みの最新の Windows アプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-122">For any subsequent runs, the UI will display the most recent Windows apps that you have validated.</span></span> <span data-ttu-id="b7336-123">テストするアプリが表示されていない場合は、**[自分のアプリが表示されない]** をクリックして、システムにインストールされているすべてのアプリを一覧表示できます。</span><span class="sxs-lookup"><span data-stu-id="b7336-123">If the app that you want to test is not listed, you can click on **My app isn't listed** to get a comprehensive list of all apps installed on your system.</span></span>

3.  <span data-ttu-id="b7336-124">テストするアプリを入力するか選択したら **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7336-124">After you have input or selected the app that you want to test, click **Next**.</span></span>

4.  <span data-ttu-id="b7336-125">次の画面からは、テストするアプリの種類に合ったテスト ワークフローが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-125">From the next screen, you will see the test workflow that aligns to the app type you are testing.</span></span> <span data-ttu-id="b7336-126">一覧でテストが淡色されている場合、お使いの環境にはそのテストが適用されません。</span><span class="sxs-lookup"><span data-stu-id="b7336-126">If a test is grayed out in the list, the test is not applicable to your environment.</span></span> <span data-ttu-id="b7336-127">たとえば、Windows 7 で Windows 10 アプリをテストする場合、静的テストのみがワークフローに適用されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-127">For example, if you are testing a Windows 10 app on Windows 7, only static tests will apply to the workflow.</span></span> <span data-ttu-id="b7336-128">Microsoft Store がこのワークフローからすべてのテストを適用可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b7336-128">Note that the Microsoft Store may apply all tests from this workflow.</span></span> <span data-ttu-id="b7336-129">実行するテストを選んで **[次へ]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b7336-129">Select the tests you want to run and click **Next**.</span></span>

    <span data-ttu-id="b7336-130">Windows アプリ認定キットによってアプリの検証が開始されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-130">The Windows App Certification Kit begins validating the app.</span></span>

5.  <span data-ttu-id="b7336-131">テストが終わった後のプロンプトで、テスト レポートを保存するフォルダーのパスを入力します。</span><span class="sxs-lookup"><span data-stu-id="b7336-131">At the prompt after the test, enter the path to the folder where you want to save the test report.</span></span>

    <span data-ttu-id="b7336-132">Windows アプリ認定キットによって XML 形式のレポートと共に HTML が作成され、このフォルダーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-132">The Windows App Certification Kit creates an HTML along with an XML report and saves it in this folder.</span></span>

6.  <span data-ttu-id="b7336-133">レポート ファイルを開いて、テストの結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="b7336-133">Open the report file and review the results of the test.</span></span>

<span data-ttu-id="b7336-134">**注:** Visual Studio を使っている場合は、アプリ パッケージを作るときに Windows アプリ認定キットを実行できます。</span><span class="sxs-lookup"><span data-stu-id="b7336-134">**Note**  If you're using Visual Studio, you can run the Windows App Certification Kit when you create your app package.</span></span> <span data-ttu-id="b7336-135">方法については、「[UWP アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/Mt627715)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7336-135">See [Packaging UWP apps](https://msdn.microsoft.com/library/windows/apps/Mt627715) to learn how.</span></span>

 

## <a name="validate-your-windows-app-using-the-windows-app-certification-kit-from-a-command-line"></a><span data-ttu-id="b7336-136">コマンド ラインから Windows アプリ認定キットを使った Windows アプリを検証する</span><span class="sxs-lookup"><span data-stu-id="b7336-136">Validate your Windows app using the Windows App Certification Kit from a command line</span></span>

<span data-ttu-id="b7336-137">**重要**  Windows アプリ認定キットは、アクティブなユーザー セッションで実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7336-137">**Important**  The Windows App Certification Kit must be run within the context of an active user session.</span></span>

1.  <span data-ttu-id="b7336-138">コマンド ウィンドウで、Windows アプリ認定キットを含むディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="b7336-138">In the command window, navigate to the directory that contains the Windows App Certification Kit.</span></span>

    <span data-ttu-id="b7336-139">**注:** 既定のパスは C:\\Program Files\\Windows Kits\\10\\App Certification Kit\\ です。</span><span class="sxs-lookup"><span data-stu-id="b7336-139">**Note**   The default path is C:\\Program Files\\Windows Kits\\10\\App Certification Kit\\.</span></span>

2.  <span data-ttu-id="b7336-140">次のコマンドをこの順序で入力し、テスト コンピューターにすでにインストールされているアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="b7336-140">Enter the following commands in this order to test an app that is already installed on your test computer:</span></span>

    `appcert.exe reset`

    `appcert.exe test -packagefullname [package full name] -reportoutputpath [report file name]`

    <span data-ttu-id="b7336-141">または、アプリがインストールされていない場合は次のコマンドを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b7336-141">Or you can use the following commands if the app is not installed.</span></span> <span data-ttu-id="b7336-142">Windows アプリ認定キットにパッケージが開き、適切なテスト ワークフローが適用されます。</span><span class="sxs-lookup"><span data-stu-id="b7336-142">The Windows App Certification Kit will open the package and apply the appropriate test workflow:</span></span>

    `appcert.exe reset`

    `appcert.exe test -appxpackagepath [package path] -reportoutputpath [report file name]`

3.  <span data-ttu-id="b7336-143">テストが完了したら、`[report file name]` という名前のレポート ファイルを開いて、テスト結果を確認します。</span><span class="sxs-lookup"><span data-stu-id="b7336-143">After the test completes, open the report file named `[report file name]` and review the test results.</span></span>

<span data-ttu-id="b7336-144">**注:** Windows アプリ認定キットはサービスから実行できますが、サービスはアクティブなユーザー セッションでキットのプロセスを開始する必要があり、Session0 では実行できません。</span><span class="sxs-lookup"><span data-stu-id="b7336-144">**Note**  The Windows App Certification Kit can be run from a service, but the service must initiate the kit process within an active user session and cannot be run in Session0.</span></span>

<span data-ttu-id="b7336-145">**注:** Windows アプリ認定キットのコマンド ラインについて詳しく知るには、次のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="b7336-145">**Note**   For more info about the Windows App Certification Kit command line, enter the command</span></span> `appcert.exe /?`

## <a name="testing-with-a-low-power-computer"></a><span data-ttu-id="b7336-146">低電力コンピューターでのテスト</span><span class="sxs-lookup"><span data-stu-id="b7336-146">Testing with a low-power computer</span></span>

<span data-ttu-id="b7336-147">Windows アプリ認定キットで使用するパフォーマンス テストのしきい値は、低電力コンピューターのパフォーマンスに基づいて設定します。</span><span class="sxs-lookup"><span data-stu-id="b7336-147">The performance test thresholds of the Windows App Certification Kit are based on the performance of a low-power computer.</span></span>

<span data-ttu-id="b7336-148">テストを実行するコンピューターの特性がテスト結果に影響することがあります。</span><span class="sxs-lookup"><span data-stu-id="b7336-148">The characteristics of the computer on which the test is performed can influence the test results.</span></span> <span data-ttu-id="b7336-149">調べるには、アプリのパフォーマンスが[Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)を満たしているかどうか、お勧めします Intel Atom プロセッサ ベースのコンピューターと 1366 x 768 以上) の画面の解像度、回転式ハードなどの低電力コンピューターでアプリをテストします。(ソリッド ステート ハード ドライブ) ではなくドライブです。</span><span class="sxs-lookup"><span data-stu-id="b7336-149">To determine if your app’s performance meets the [Microsoft Store Policies](https://msdn.microsoft.com/library/windows/apps/Dn764944), we recommend that you test your app on a low-power computer, such as an Intel Atom processor-based computer with a screen resolution of 1366x768 (or higher) and a rotational hard drive (as opposed to a solid-state hard drive).</span></span>

<span data-ttu-id="b7336-150">低電力コンピューターの進化に伴い、パフォーマンスの特性が時間の経過と共に変化する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b7336-150">As low-power computers evolve, their performance characteristics might change over time.</span></span> <span data-ttu-id="b7336-151">最新の[Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)を参照し、アプリが最新のパフォーマンス要件に準拠しているかどうかを確認するには、Windows アプリ認定キットの最新バージョンでアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="b7336-151">Refer to the most current [Microsoft Store Policies](https://msdn.microsoft.com/library/windows/apps/Dn764944) and test your app with the most current version of the Windows App Certification Kit to make sure that your app complies with the latest performance requirements.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b7336-152">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b7336-152">Related topics</span></span>

* [<span data-ttu-id="b7336-153">Windows アプリ認定キットのテスト</span><span class="sxs-lookup"><span data-stu-id="b7336-153">Windows App Certification Kit tests</span></span>](windows-app-certification-kit-tests.md)
* [<span data-ttu-id="b7336-154">Microsoft Store ポリシー</span><span class="sxs-lookup"><span data-stu-id="b7336-154">Microsoft Store Policies</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn764944)
 

 




