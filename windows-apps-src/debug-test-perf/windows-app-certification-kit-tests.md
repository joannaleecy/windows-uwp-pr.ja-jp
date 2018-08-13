---
author: PatrickFarley
ms.assetid: 1526FF4B-9E68-458A-B002-0A5F3A9A81FD
title: Windows アプリ認定キットのテスト
description: Windows アプリの認定キットには、アプリが、Microsoft ストアに公開する準備ができていることを確認できるテストの数値が含まれています。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f5c28b17147ac285cefb0b93e36ac6f00b115f3a
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "927757"
---
# <a name="windows-app-certification-kit-tests"></a><span data-ttu-id="547f9-104">Windows アプリ認定キットのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-104">Windows App Certification Kit tests</span></span>


<span data-ttu-id="547f9-105">[Windows アプリ認定キット](windows-app-certification-kit.md)には、アプリは、Microsoft ストアに公開する準備ができていることを確認するためのテストの数値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="547f9-105">The [Windows App Certification Kit](windows-app-certification-kit.md) contains a number of tests that help ensure your app is ready to be published to the Microsoft Store.</span></span> <span data-ttu-id="547f9-106">テストで、抽出条件の詳細については、次にして、アクションが失敗した場合を表示します。</span><span class="sxs-lookup"><span data-stu-id="547f9-106">The tests are listed below with their criteria, details, and suggested actions in the case of failure.</span></span>

## <a name="deployment-and-launch-tests"></a><span data-ttu-id="547f9-107">展開と起動のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-107">Deployment and launch tests</span></span>

<span data-ttu-id="547f9-108">認証テスト中にアプリを監視して、アプリがクラッシュやハングを起こしたタイミングを記録します。</span><span class="sxs-lookup"><span data-stu-id="547f9-108">Monitors the app during certification testing to record when it crashes or hangs.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-109">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-109">Background</span></span>

<span data-ttu-id="547f9-110">応答しなくなったアプリやクラッシュしたアプリは、データが失われたり操作性が低下したりする原因になることがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-110">Apps that stop responding or crash can cause the user to lose data and have a poor experience.</span></span>

<span data-ttu-id="547f9-111">アプリは、Windows の互換モードや AppHelp メッセージ、互換性修正プログラムを使わずにフル機能することが求められています。</span><span class="sxs-lookup"><span data-stu-id="547f9-111">We expect apps to be fully functional without the use of Windows compatibility modes, AppHelp messages, or compatibility fixes.</span></span>

<span data-ttu-id="547f9-112">アプリは、HKEY\-LOCAL\-MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows\\AppInit\-DLLs レジストリ キーに読み込む DLL を一覧する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="547f9-112">Apps must not list DLLs to load in the HKEY\-LOCAL\-MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows\\AppInit\-DLLs registry key.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-113">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-113">Test details</span></span>

<span data-ttu-id="547f9-114">認定テストを通じて、アプリの復元性や安定性をテストします。</span><span class="sxs-lookup"><span data-stu-id="547f9-114">We test the app resilience and stability throughout the certification testing.</span></span>

<span data-ttu-id="547f9-115">Windows アプリ認定キットで [**IApplicationActivationManager::ActivateApplication**](https://msdn.microsoft.com/library/windows/desktop/Hh706903) を呼び出し、アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="547f9-115">The Windows App Certification Kit calls [**IApplicationActivationManager::ActivateApplication**](https://msdn.microsoft.com/library/windows/desktop/Hh706903) to launch apps.</span></span> <span data-ttu-id="547f9-116">**ActivateApplication** でアプリを起動する場合は、ユーザー アカウント制御 (UAC) を有効にし、画面解像度を 1024 x 768 または 768 x 1024 以上にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-116">For **ActivateApplication** to launch an app, User Account Control (UAC) must be enabled and the screen resolution must be at least 1024 x 768 or 768 x 1024.</span></span> <span data-ttu-id="547f9-117">どちらの条件も満たされない場合は、アプリはこのテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-117">If either condition is not met, your app will fail this test.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-118">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-118">Corrective actions</span></span>

<span data-ttu-id="547f9-119">テスト コンピューターで UAC が有効になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-119">Make sure UAC is enabled on the test computer.</span></span>

<span data-ttu-id="547f9-120">十分な大きさの画面を備えたコンピューターでテストを実行していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-120">Make sure you are running the test on a computer with large enough screen.</span></span>

<span data-ttu-id="547f9-121">テスト プラットフォームが [**ActivateApplication**](https://msdn.microsoft.com/library/windows/desktop/Hh706903) の前提条件を満たしているにもかかわらずアプリの起動に失敗する場合は、アクティブ化イベント ログを確認して問題のトラブルシューティングを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="547f9-121">If your app fails to launch and your test platform satisfies the prerequisites of [**ActivateApplication**](https://msdn.microsoft.com/library/windows/desktop/Hh706903), you can troubleshoot the problem by reviewing the activation event log.</span></span> <span data-ttu-id="547f9-122">イベント ログでこのようなエントリを見つけるには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="547f9-122">To find these entries in the event log:</span></span>

1.  <span data-ttu-id="547f9-123">eventvwr.exe を開き、アプリケーションとサービス ログ\\Microsoft\\Windows\\Immersive-Shell フォルダーに移動します。</span><span class="sxs-lookup"><span data-stu-id="547f9-123">Open eventvwr.exe and navigate to the Application and Services Log\\Microsoft\\Windows\\Immersive-Shell folder.</span></span>
2.  <span data-ttu-id="547f9-124">ビューをフィルター処理してイベント ID 5900 ～ 6000 を表示します。</span><span class="sxs-lookup"><span data-stu-id="547f9-124">Filter the view to show Event Ids: 5900-6000.</span></span>
3.  <span data-ttu-id="547f9-125">アプリが起動しなかった理由を説明している可能性のある情報のログ エントリを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-125">Review the log entries for info that might explain why the app didn't launch.</span></span>

<span data-ttu-id="547f9-126">問題のあるファイルをトラブルシューティングして問題を特定し、修正します。</span><span class="sxs-lookup"><span data-stu-id="547f9-126">Troubleshoot the file with the problem, identify and fix the problem.</span></span> <span data-ttu-id="547f9-127">アプリをリビルドして再テストします。</span><span class="sxs-lookup"><span data-stu-id="547f9-127">Rebuild and re-test the app.</span></span> <span data-ttu-id="547f9-128">また、ダンプ ファイルが Windows アプリ認定キットのログ フォルダーに生成されたかどうかを確認します。ダンプ ファイルもアプリのデバッグに使用できます。</span><span class="sxs-lookup"><span data-stu-id="547f9-128">You can also check if a dump file was generated in the Windows App Certification Kit log folder that can be used to debug your app.</span></span>

## <a name="platform-version-launch-test"></a><span data-ttu-id="547f9-129">プラットフォーム バージョン起動テスト</span><span class="sxs-lookup"><span data-stu-id="547f9-129">Platform Version Launch test</span></span>

<span data-ttu-id="547f9-130">Windows アプリを将来のバージョンの OS で実行できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-130">Checks that the Windows app can run on a future version of the OS.</span></span> <span data-ttu-id="547f9-131">これまで、このテストはデスクトップ アプリ ワークフローにのみ適用されてきましたが、ストアおよびユニバーサル Windows プラットフォーム (UWP) のワークフローに有効になりました。</span><span class="sxs-lookup"><span data-stu-id="547f9-131">This test has historically been only applied to the Desktop app workflow, but this is now enabled for the Store and Universal Windows Platform (UWP) workflows.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-132">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-132">Background</span></span>

<span data-ttu-id="547f9-133">オペレーティング システムのバージョン情報] では、Microsoft ストアの使用量を制限されています。</span><span class="sxs-lookup"><span data-stu-id="547f9-133">Operating system version info has restricted usage for the Microsoft Store.</span></span> <span data-ttu-id="547f9-134">これは、アプリが OS のバージョンに固有の機能をユーザーに提供できるように、アプリによって OS バージョンを確認する目的で誤って使用されることがよくありました。</span><span class="sxs-lookup"><span data-stu-id="547f9-134">This has often been incorrectly used by apps to check OS version so that the app can provide users with functionality that is specific to an OS version.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-135">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-135">Test details</span></span>

<span data-ttu-id="547f9-136">Windows アプリ認定キットは、HighVersionLie を使って、アプリが OS のバージョンを確認する方法を検出します。</span><span class="sxs-lookup"><span data-stu-id="547f9-136">The Windows App Certification Kit uses the HighVersionLie to detect how the app checks the OS version.</span></span> <span data-ttu-id="547f9-137">アプリがクラッシュした場合は、このテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-137">If the app crashes, it will fail this test.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-138">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-138">Corrective action</span></span>

<span data-ttu-id="547f9-139">アプリは、バージョン API ヘルパー関数を使ってこれを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-139">Apps should use Version API helper functions to check this.</span></span> <span data-ttu-id="547f9-140">詳しくは、「[オペレーティング システムのバージョン](https://msdn.microsoft.com/library/windows/desktop/ms724832)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-140">See [Operating System Version](https://msdn.microsoft.com/library/windows/desktop/ms724832) for more information.</span></span>

## <a name="background-tasks-cancellation-handler-validation"></a><span data-ttu-id="547f9-141">バックグラウンド タスクの取り消しハンドラーの検証</span><span class="sxs-lookup"><span data-stu-id="547f9-141">Background tasks cancellation handler validation</span></span>

<span data-ttu-id="547f9-142">宣言されているバックグラウンド タスクの取り消しハンドラーがアプリにあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-142">This verifies that the app has a cancellation handler for declared background tasks.</span></span> <span data-ttu-id="547f9-143">タスクが取り消されたときに呼び出される専用の関数が必要です。</span><span class="sxs-lookup"><span data-stu-id="547f9-143">There needs to be a dedicated function that will be called when the task is cancelled.</span></span> <span data-ttu-id="547f9-144">このテストは、展開済みのアプリにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-144">This test is applied only for deployed apps.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-145">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-145">Background</span></span>

<span data-ttu-id="547f9-146">ストア アプリは、バック グラウンドで実行されるプロセスを登録できます。</span><span class="sxs-lookup"><span data-stu-id="547f9-146">Store apps can register a process that runs in the background.</span></span> <span data-ttu-id="547f9-147">たとえば、メール アプリはときどき ping を実行することがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-147">For example, an email app may ping a server from time to time.</span></span> <span data-ttu-id="547f9-148">しかし、OS がこれらのリソースを必要とする場合は、バックグラウンド タスクが取り消され、アプリはこの取り消しを適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-148">However, if the OS needs these resources, it will cancel the background task, and apps should gracefully handle this cancellation.</span></span> <span data-ttu-id="547f9-149">取り消しハンドラーがないアプリはクラッシュする可能性や、ユーザーがアプリを閉じようとしても終了しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-149">Apps that don't have a cancellation handler may crash or not close when the user tries to close the app.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-150">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-150">Test details</span></span>

<span data-ttu-id="547f9-151">アプリが起動して中断され、アプリの非バックグラウンド部分が終了します。</span><span class="sxs-lookup"><span data-stu-id="547f9-151">The app is launched, suspended and the non-background portion of the app is terminated.</span></span> <span data-ttu-id="547f9-152">このアプリに関連付けられたバックグラウンド タスクは取り消されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-152">Then the background tasks associated with this app are cancelled.</span></span> <span data-ttu-id="547f9-153">アプリの状態が確認され、アプリがまだ実行中の場合はこのテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-153">The state of the app is checked, and if the app is still running then it will fail this test.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-154">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-154">Corrective action</span></span>

<span data-ttu-id="547f9-155">アプリに取り消しハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="547f9-155">Add the cancellation handler to your app.</span></span> <span data-ttu-id="547f9-156">詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/library/windows/apps/Mt299103)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-156">For more information see [Support your app with background tasks](https://msdn.microsoft.com/library/windows/apps/Mt299103).</span></span>

## <a name="app-count"></a><span data-ttu-id="547f9-157">アプリ カウント</span><span class="sxs-lookup"><span data-stu-id="547f9-157">App count</span></span>

<span data-ttu-id="547f9-158">アプリ パッケージ (APPX、アプリ バンドル) に 1 つのアプリケーションが含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-158">This verifies that an app package (APPX, app bundle) contains one application.</span></span> <span data-ttu-id="547f9-159">これは、キットでスタンドアロン テストに変更されました。</span><span class="sxs-lookup"><span data-stu-id="547f9-159">This was changed in the kit to be a standalone test.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-160">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-160">Background</span></span>

<span data-ttu-id="547f9-161">このテストは、ストア ポリシーに従って実装されていました。</span><span class="sxs-lookup"><span data-stu-id="547f9-161">This test was implemented as per Store policy.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-162">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-162">Test details</span></span>

<span data-ttu-id="547f9-163">Windows Phone 8.1 アプリの場合は、テストにより、バンドル内の appx パッケージの合計数が 512 個未満であること、バンドル内に含まれるメイン パッケージが 1 個だけであること、そしてバンドル内のメイン パッケージのアーキテクチャが ARM またはニュートラルとしてマークされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-163">For Windows Phone 8.1 apps the test verifies the total number of appx packages in the bundle is &lt; 512, there is only one main package in the bundle, and that the architecture of the main package in the bundle is marked as ARM or neutral.</span></span>

<span data-ttu-id="547f9-164">Windows 10 アプリの場合は、テストでは、バンドルのバージョンのリビジョン番号が 0 に設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-164">For Windows 10 apps the test verifies that the revision number in the version of the bundle is set to 0.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-165">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-165">Corrective action</span></span>

<span data-ttu-id="547f9-166">アプリ パッケージとバンドルが、テストの詳細で上記の要件を満たしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-166">Ensure the app package and bundle meet requirements above in Test details.</span></span>

## <a name="app-manifest-compliance-test"></a><span data-ttu-id="547f9-167">アプリ マニフェストの適合性のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-167">App manifest compliance test</span></span>

<span data-ttu-id="547f9-168">アプリ マニフェストのコンテンツをテストし、コンテンツが正しいかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-168">Test the contents of app manifest to make sure its contents are correct.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-169">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-169">Background</span></span>

<span data-ttu-id="547f9-170">アプリ マニフェストは正しい形式でなければならない</span><span class="sxs-lookup"><span data-stu-id="547f9-170">Apps must have a correctly formatted app manifest.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-171">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-171">Test details</span></span>

<span data-ttu-id="547f9-172">「[アプリ パッケージの要件](https://msdn.microsoft.com/library/windows/apps/Mt148525)」の説明に従って、アプリ マニフェストを調べてコンテンツが正しいかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-172">Examines the app manifest to verify the contents are correct as described in the [App package requirements](https://msdn.microsoft.com/library/windows/apps/Mt148525).</span></span>

-   **<span data-ttu-id="547f9-173">ファイル拡張子とプロトコル</span><span class="sxs-lookup"><span data-stu-id="547f9-173">File extensions and protocols</span></span>**

    <span data-ttu-id="547f9-174">アプリは、関連付ける必要があるファイル拡張子を宣言できます。</span><span class="sxs-lookup"><span data-stu-id="547f9-174">Your app can declare the file extensions that it wants to associate with.</span></span> <span data-ttu-id="547f9-175">ただし不当に使用されると、アプリは大量のファイル拡張子 (しかも大半が使うことのない拡張子) を宣言することがあり、ユーザー エクスペリエンスが低下する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-175">Used improperly, an app can declare a large number of file extensions, most of which it may not even use, resulting in a bad user experience.</span></span> <span data-ttu-id="547f9-176">このテストで追加されるチェックにより、アプリに関連付けることができるファイル拡張子の数を制限できます。</span><span class="sxs-lookup"><span data-stu-id="547f9-176">This test will add a check to limit the number of file extensions that an app can associate with.</span></span>

-   **<span data-ttu-id="547f9-177">フレームワークの依存関係規則</span><span class="sxs-lookup"><span data-stu-id="547f9-177">Framework Dependency rule</span></span>**

    <span data-ttu-id="547f9-178">このテストは、アプリと UWP の依存関係が適切かどうかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-178">This test enforces the requirement that apps take appropriate dependencies on the UWP.</span></span> <span data-ttu-id="547f9-179">不適切な依存関係がある場合は、このテストは失敗します。</span><span class="sxs-lookup"><span data-stu-id="547f9-179">If there is an inappropriate dependency, this test will fail.</span></span>

    <span data-ttu-id="547f9-180">アプリが動作する OS のバージョンと依存関係のあるフレームワークとの間に不整合がある場合は、テストは失敗します。</span><span class="sxs-lookup"><span data-stu-id="547f9-180">If there is a mismatch between the OS version the app applies to and the framework dependencies made, the test will fail.</span></span> <span data-ttu-id="547f9-181">アプリがフレーム ワーク DLL の Preview 版を参照している場合にも、テストは失敗します。</span><span class="sxs-lookup"><span data-stu-id="547f9-181">The test would also fail if the app refers to any preview versions of the framework dlls.</span></span>

-   **<span data-ttu-id="547f9-182">プロセス間通信 (IPC) の確認</span><span class="sxs-lookup"><span data-stu-id="547f9-182">Inter-process Communication (IPC) verification</span></span>**

    <span data-ttu-id="547f9-183">このテストには、デスクトップのコンポーネントにアプリ コンテナーの外部で通信しない UWP アプリの要件が適用されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-183">This test enforces the requirement that UWP apps do not communicate outside of the app container to Desktop components.</span></span> <span data-ttu-id="547f9-184">プロセス間通信は、サイドローディングが行われたアプリのみを対象としています。</span><span class="sxs-lookup"><span data-stu-id="547f9-184">Inter-process communication is intended for side-loaded apps only.</span></span> <span data-ttu-id="547f9-185">DesktopApplicationPath と同じ名前で [**ActivatableClassAttribute**](https://msdn.microsoft.com/library/windows/apps/BR211414) を指定しているアプリは、このテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-185">Apps that specify the [**ActivatableClassAttribute**](https://msdn.microsoft.com/library/windows/apps/BR211414) with name equal to "DesktopApplicationPath" will fail this test.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-186">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-186">Corrective action</span></span>

<span data-ttu-id="547f9-187">「[アプリ パッケージの要件](https://msdn.microsoft.com/library/windows/apps/Mt148525)」で説明されている要件に照らして、アプリのマニフェストを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-187">Review the app's manifest against the requirements described in the [App package requirements](https://msdn.microsoft.com/library/windows/apps/Mt148525).</span></span>

## <a name="windows-security-features-test"></a><span data-ttu-id="547f9-188">Windows のセキュリティ機能のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-188">Windows Security features test</span></span>

### <a name="background"></a><span data-ttu-id="547f9-189">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-189">Background</span></span>

<span data-ttu-id="547f9-190">Windows 既定のセキュリティ保護を変更すると、ユーザーが危険にさらされるリスクが増大します。</span><span class="sxs-lookup"><span data-stu-id="547f9-190">Changing the default Windows security protections can put customers at increased risk.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-191">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-191">Test details</span></span>

<span data-ttu-id="547f9-192">[BinScope Binary Analyzer](#binscope-binary-analyzer-tests) を起動して、アプリのセキュリティをテストします。</span><span class="sxs-lookup"><span data-stu-id="547f9-192">Tests the app's security by running the [BinScope Binary Analyzer](#binscope-binary-analyzer-tests).</span></span>

<span data-ttu-id="547f9-193">BinScope Binary Analyzer テストでは、アプリのバイナリ ファイルを検査して、攻撃や悪用に対してアプリの強度を上げるコーディングとビルドの手法をチェックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-193">The BinScope Binary Analyzer tests examine the app's binary files to check for coding and building practices that make the app less vulnerable to attack or to being used as an attack vector.</span></span>

<span data-ttu-id="547f9-194">BinScope Binary Analyzer テストは、次のセキュリティ関連の機能が適切に使われているかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-194">The BinScope Binary Analyzer tests check for the correct use of the following security-related features.</span></span>

-   <span data-ttu-id="547f9-195">BinScope Binary Analyzer テスト</span><span class="sxs-lookup"><span data-stu-id="547f9-195">BinScope Binary Analyzer tests</span></span>
-   <span data-ttu-id="547f9-196">プライベート コードの署名</span><span class="sxs-lookup"><span data-stu-id="547f9-196">Private Code Signing</span></span>

### <a name="binscope-binary-analyzer-tests"></a><span data-ttu-id="547f9-197">BinScope Binary Analyzer テスト</span><span class="sxs-lookup"><span data-stu-id="547f9-197">BinScope Binary Analyzer tests</span></span>

<span data-ttu-id="547f9-198">
[BinScope Binary Analyzer](https://www.microsoft.com/en-us/download/details.aspx?id=44995) テストは、アプリのバイナリ ファイルを検査して、攻撃や悪用からアプリを守るコーディングとビルドの手法をチェックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-198">The [BinScope Binary Analyzer](https://www.microsoft.com/en-us/download/details.aspx?id=44995) tests examine the app's binary files to check for coding and building practices that make the app less vulnerable to attack or to being used as an attack vector.</span></span>

<span data-ttu-id="547f9-199">BinScope Binary Analyzer テストは、次のセキュリティ関連機能が適切に使われているかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-199">The BinScope Binary Analyzer tests check for the correct use of these security-related features:</span></span>

-   [<span data-ttu-id="547f9-200">AllowPartiallyTrustedCallersAttribute</span><span class="sxs-lookup"><span data-stu-id="547f9-200">AllowPartiallyTrustedCallersAttribute</span></span>](#binscope-1)
-   [<span data-ttu-id="547f9-201">/SafeSEH 例外処理の保護</span><span class="sxs-lookup"><span data-stu-id="547f9-201">/SafeSEH Exception Handling Protection</span></span>](#binscope-2)
-   [<span data-ttu-id="547f9-202">データ実行防止</span><span class="sxs-lookup"><span data-stu-id="547f9-202">Data Execution Prevention</span></span>](#binscope-3)
-   [<span data-ttu-id="547f9-203">アドレス空間レイアウトのランダム化</span><span class="sxs-lookup"><span data-stu-id="547f9-203">Address Space Layout Randomization</span></span>](#binscope-4)
-   [<span data-ttu-id="547f9-204">共有されている PE セクションの読み取り/書き込み</span><span class="sxs-lookup"><span data-stu-id="547f9-204">Read/Write Shared PE Section</span></span>](#binscope-5)
-   [<span data-ttu-id="547f9-205">AppContainerCheck</span><span class="sxs-lookup"><span data-stu-id="547f9-205">AppContainerCheck</span></span>](#appcontainercheck)
-   [<span data-ttu-id="547f9-206">ExecutableImportsCheck</span><span class="sxs-lookup"><span data-stu-id="547f9-206">ExecutableImportsCheck</span></span>](#binscope-7)
-   [<span data-ttu-id="547f9-207">WXCheck</span><span class="sxs-lookup"><span data-stu-id="547f9-207">WXCheck</span></span>](#binscope-8)

### <a name="span-idbinscope-1spanallowpartiallytrustedcallersattribute"></a><span data-ttu-id="547f9-208"><span id="binscope-1"></span>AllowPartiallyTrustedCallersAttribute</span><span class="sxs-lookup"><span data-stu-id="547f9-208"><span id="binscope-1"></span>AllowPartiallyTrustedCallersAttribute</span></span>

<span data-ttu-id="547f9-209">**Windows アプリ認定キットのエラー メッセージ:** APTCACheck Test failed</span><span class="sxs-lookup"><span data-stu-id="547f9-209">**Windows App Certification Kit error message:** APTCACheck Test failed</span></span>

<span data-ttu-id="547f9-210">AllowPartiallyTrustedCallersAttribute (APTCA) 属性を使うと、署名されたアセンブリで、部分的に信頼されたコードから完全に信頼されたコードにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="547f9-210">The AllowPartiallyTrustedCallersAttribute (APTCA) attribute enables access to fully trusted code from partially trusted code in signed assemblies.</span></span> <span data-ttu-id="547f9-211">アセンブリに APTCA 属性を適用すると、アセンブリが有効な間は、部分的に信頼された呼び出し元からそのアセンブリにアクセスできます。これにより、セキュリティが侵害されるおそれがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-211">When you apply the APTCA attribute to an assembly, partially trusted callers can access that assembly for the life of the assembly, which can compromise security.</span></span>

**<span data-ttu-id="547f9-212">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-212">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-213">プロジェクトに必要で、リスクをよく認識している場合を除いて、厳密な名前の付いたアセンブリでは APTCA 属性を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="547f9-213">Don't use the APTCA attribute on strong named assemblies unless your project requires it and the risks are well understood.</span></span> <span data-ttu-id="547f9-214">APTCA 属性を使う必要がある場合は、すべての API が適切なコード アクセス セキュリティ要求によって保護されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-214">In cases where it's required, make sure that all APIs are protected with appropriate code access security demands.</span></span> <span data-ttu-id="547f9-215">アセンブリがユニバーサル Windows プラットフォーム (UWP) アプリの一部となっている場合は、APTCA の影響はありません。</span><span class="sxs-lookup"><span data-stu-id="547f9-215">APTCA has no effect when the assembly is a part of a Universal Windows Platform (UWP) app.</span></span>

**<span data-ttu-id="547f9-216">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-216">Remarks</span></span>**

<span data-ttu-id="547f9-217">このテストは、マネージ コード (C#、.NET など) でのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-217">This test is performed only on managed code (C#, .NET, etc.).</span></span>

### <a name="span-idbinscope-2spansafeseh-exception-handling-protection"></a><span data-ttu-id="547f9-218"><span id="binscope-2"></span>/SafeSEH 例外処理の保護</span><span class="sxs-lookup"><span data-stu-id="547f9-218"><span id="binscope-2"></span>/SafeSEH Exception Handling Protection</span></span>

<span data-ttu-id="547f9-219">**Windows アプリ認定キットのエラー メッセージ:** SafeSEHCheck Test failed</span><span class="sxs-lookup"><span data-stu-id="547f9-219">**Windows App Certification Kit error message:** SafeSEHCheck Test failed</span></span>

<span data-ttu-id="547f9-220">例外ハンドラーは、アプリがゼロ除算エラーなどの例外的な状況に陥った場合に実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-220">An exception handler runs when the app encounters an exceptional condition, such as a divide-by-zero error.</span></span> <span data-ttu-id="547f9-221">関数が呼び出されると例外ハンドラーのアドレスがスタックに格納されるため、悪意のあるソフトウェアがスタックを上書きしようとした場合は、バッファー オーバーフローによる攻撃を受けやすくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-221">Because the address of the exception handler is stored on the stack when a function is called, it could be vulnerable to a buffer overflow attacker if some malicious software were to overwrite the stack.</span></span>

**<span data-ttu-id="547f9-222">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-222">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-223">アプリをビルドするときに、リンカー コマンドの /SAFESEH オプションを有効にします。</span><span class="sxs-lookup"><span data-stu-id="547f9-223">Enable the /SAFESEH option in the linker command when you build your app.</span></span> <span data-ttu-id="547f9-224">Visual Studio のリリース構成では、既定で、このオプションが有効になっています。</span><span class="sxs-lookup"><span data-stu-id="547f9-224">This option is on by default in the Release configurations of Visual Studio.</span></span> <span data-ttu-id="547f9-225">このオプションが、アプリのすべての実行可能モジュールに対するビルド手順で有効になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-225">Verify this option is enabled in the build instructions for all executable modules in your app.</span></span>

**<span data-ttu-id="547f9-226">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-226">Remarks</span></span>**

<span data-ttu-id="547f9-227">このテストは、64 ビット バイナリまたは ARM チップセット バイナリでは実行されません。例外ハンドラーのアドレスがスタックに格納されないためです。</span><span class="sxs-lookup"><span data-stu-id="547f9-227">The test is not performed on 64-bit binaries or ARM chipset binaries because they don't store exception handler addresses on the stack.</span></span>

### <a name="span-idbinscope-3spandata-execution-prevention"></a><span data-ttu-id="547f9-228"><span id="binscope-3"></span>データ実行防止</span><span class="sxs-lookup"><span data-stu-id="547f9-228"><span id="binscope-3"></span>Data Execution Prevention</span></span>

<span data-ttu-id="547f9-229">**Windows アプリ認定キットのエラー メッセージ:** NXCheck Test failed</span><span class="sxs-lookup"><span data-stu-id="547f9-229">**Windows App Certification Kit error message:** NXCheck Test failed</span></span>

<span data-ttu-id="547f9-230">このテストでは、データ セグメントに格納されたコードが、アプリで実行されないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-230">This test verifies that an app doesn't run code that is stored in a data segment.</span></span>

**<span data-ttu-id="547f9-231">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-231">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-232">アプリをビルドするときに、リンカー コマンドの /NXCOMPAT オプションを有効にします。</span><span class="sxs-lookup"><span data-stu-id="547f9-232">Enable the /NXCOMPAT option in the linker command when you build your app.</span></span> <span data-ttu-id="547f9-233">Data Execution Prevention (DEP) をサポートするリンカー バージョンでは、既定で、このオプションが有効になっています。</span><span class="sxs-lookup"><span data-stu-id="547f9-233">This option is on by default in linker versions that support Data Execution Prevention (DEP).</span></span>

**<span data-ttu-id="547f9-234">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-234">Remarks</span></span>**

<span data-ttu-id="547f9-235">DEP 対応の CPU でアプリをテストし、DEP の結果として見つかったエラーをすべて修正することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="547f9-235">We recommend that you test your apps on a DEP-capable CPU and fix any failures you find that result from DEP.</span></span>

### <a name="span-idbinscope-4spanaddress-space-layout-randomization"></a><span data-ttu-id="547f9-236"><span id="binscope-4"></span>アドレス空間レイアウトのランダム化</span><span class="sxs-lookup"><span data-stu-id="547f9-236"><span id="binscope-4"></span>Address Space Layout Randomization</span></span>

<span data-ttu-id="547f9-237">**Windows アプリ認定キットのエラー メッセージ:** DBCheck Test failed</span><span class="sxs-lookup"><span data-stu-id="547f9-237">**Windows App Certification Kit error message:** DBCheck Test failed</span></span>

<span data-ttu-id="547f9-238">アドレス空間レイアウトのランダム化 (ASLR) を使うと、実行可能なイメージがメモリの予測不可能な場所に読み込まれます。これにより、特定の仮想アドレスにプログラムを読み込むことを想定している悪意のあるソフトウェアは、計画どおりに動作しにくくなります。</span><span class="sxs-lookup"><span data-stu-id="547f9-238">Address Space Layout Randomization (ASLR) loads executable images into unpredictable locations in memory, which makes it harder for malicious software that expects a program to be loaded at a certain virtual address to operate predictably.</span></span> <span data-ttu-id="547f9-239">アプリとアプリで使うすべてのコンポーネントは、ASLR をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-239">Your app and all components that your app uses must support ASLR.</span></span>

**<span data-ttu-id="547f9-240">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-240">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-241">アプリをビルドするときに、リンカー コマンドの /DYNAMICBASE オプションを有効にします。</span><span class="sxs-lookup"><span data-stu-id="547f9-241">Enable the /DYNAMICBASE option in the linker command when you build your app.</span></span> <span data-ttu-id="547f9-242">アプリで使うすべてのモジュールでも、このリンカー オプションを使っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-242">Verify that all modules that your app uses also use this linker option.</span></span>

**<span data-ttu-id="547f9-243">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-243">Remarks</span></span>**

<span data-ttu-id="547f9-244">通常、ASLR がパフォーマンスに影響を与えることはありません。</span><span class="sxs-lookup"><span data-stu-id="547f9-244">Normally, ASLR doesn't affect performance.</span></span> <span data-ttu-id="547f9-245">ただし、場合によっては、32 ビット システムでわずかにパフォーマンスが向上することがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-245">But in some scenarios there is a slight performance improvement on 32-bit systems.</span></span> <span data-ttu-id="547f9-246">多くの画像がさまざまなメモリに読み込まれた非常に密集したシステムでは、パフォーマンスが低下する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-246">It is possible that performance could degrade in a highly congested system that have many images loaded in many different memory locations.</span></span>

<span data-ttu-id="547f9-247">このテストは、C や C++ などのアンマネージ言語で記述されたアプリでのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-247">This test is performed only on apps written in unmanaged languages, such as by using C or C++.</span></span>

### <a name="span-idbinscope-5spanreadwrite-shared-pe-section"></a><span data-ttu-id="547f9-248"><span id="binscope-5"></span>共有されている PE セクションの読み取り/書き込み</span><span class="sxs-lookup"><span data-stu-id="547f9-248"><span id="binscope-5"></span>Read/Write Shared PE Section</span></span>

<span data-ttu-id="547f9-249">**Windows アプリ認定キットのエラー メッセージ:** SharedSectionsCheck Test failed.</span><span class="sxs-lookup"><span data-stu-id="547f9-249">**Windows App Certification Kit error message:** SharedSectionsCheck Test failed.</span></span>

<span data-ttu-id="547f9-250">共有されている書き込み可能なセクションがあるバイナリ ファイルは、セキュリティの脅威です。</span><span class="sxs-lookup"><span data-stu-id="547f9-250">Binary files with writable sections that are marked as shared are a security threat.</span></span> <span data-ttu-id="547f9-251">共有する書き込み可能なセクションを含むアプリは、必須の場合を除き、ビルドしないでください。</span><span class="sxs-lookup"><span data-stu-id="547f9-251">Don't build apps with shared writable sections unless necessary.</span></span> <span data-ttu-id="547f9-252">[**CreateFileMapping**](https://msdn.microsoft.com/library/windows/desktop/Aa366537) または [**MapViewOfFile**](https://msdn.microsoft.com/library/windows/desktop/Aa366761) を使って適切に保護された共有メモリ オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="547f9-252">Use [**CreateFileMapping**](https://msdn.microsoft.com/library/windows/desktop/Aa366537) or [**MapViewOfFile**](https://msdn.microsoft.com/library/windows/desktop/Aa366761) to create a properly secured shared memory object.</span></span>

**<span data-ttu-id="547f9-253">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-253">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-254">アプリからすべての共有セクションを削除し、適切なセキュリティ属性を指定した [**CreateFileMapping**](https://msdn.microsoft.com/library/windows/desktop/Aa366537) または [**MapViewOfFile**](https://msdn.microsoft.com/library/windows/desktop/Aa366761) を呼び出して共有メモリ オブジェクトを作成し、アプリをリビルドします。</span><span class="sxs-lookup"><span data-stu-id="547f9-254">Remove any shared sections from the app and create shared memory objects by calling [**CreateFileMapping**](https://msdn.microsoft.com/library/windows/desktop/Aa366537) or [**MapViewOfFile**](https://msdn.microsoft.com/library/windows/desktop/Aa366761) with the proper security attributes and then rebuild your app.</span></span>

**<span data-ttu-id="547f9-255">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-255">Remarks</span></span>**

<span data-ttu-id="547f9-256">このテストは、C や C++ などのアンマネージ言語で記述されたアプリでのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-256">This test is performed only on apps written in unmanaged languages, such as by using C or C++.</span></span>

### <a name="appcontainercheck"></a><span data-ttu-id="547f9-257">AppContainerCheck</span><span class="sxs-lookup"><span data-stu-id="547f9-257">AppContainerCheck</span></span>

<span data-ttu-id="547f9-258">**Windows アプリ認定キットのエラー メッセージ:** AppContainerCheck Test failed.</span><span class="sxs-lookup"><span data-stu-id="547f9-258">**Windows App Certification Kit error message:** AppContainerCheck Test failed.</span></span>

<span data-ttu-id="547f9-259">AppContainerCheck は、実行可能なバイナリの PE (Portable Executable) ヘッダーに **appcontainer** ビットが設定されているかを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-259">The AppContainerCheck verifies that the **appcontainer** bit in the portable executable (PE) header of an executable binary is set.</span></span> <span data-ttu-id="547f9-260">すべての .exe ファイルとすべてのアンマネージ DLL で **appcontainer** ビットが設定されていないと、アプリは正しく動作しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-260">Apps must have the **appcontainer** bit set on all .exe files and all unmanaged DLLs to execute properly.</span></span>

**<span data-ttu-id="547f9-261">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-261">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-262">ネイティブの実行可能ファイルでテストが不合格になった場合は、最新のコンパイラとリンカーを使ってファイルをビルドし、リンカーで */appcontainer* フラグを使います。</span><span class="sxs-lookup"><span data-stu-id="547f9-262">If a native executable file fails the test, make sure that you used the latest compiler and linker to build the file and that you use the */appcontainer* flag on the linker.</span></span>

<span data-ttu-id="547f9-263">マネージ実行可能ファイルには、テストが失敗した場合、最新コンパイラと Microsoft Visual Studio など、リンク ビルダーを使用した UWP アプリを作成することを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-263">If a managed executable fails the test, make sure that you used the latest compiler and linker, such as Microsoft Visual Studio, to build the UWP app.</span></span>

**<span data-ttu-id="547f9-264">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-264">Remarks</span></span>**

<span data-ttu-id="547f9-265">このテストは、すべての .exe ファイル、およびアンマネージ DLL で実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-265">This test is performed on all .exe files and on unmanaged DLLs.</span></span>

### <a name="span-idbinscope-7spanexecutableimportscheck"></a><span data-ttu-id="547f9-266"><span id="binscope-7"></span>ExecutableImportsCheck</span><span class="sxs-lookup"><span data-stu-id="547f9-266"><span id="binscope-7"></span>ExecutableImportsCheck</span></span>

<span data-ttu-id="547f9-267">**Windows アプリ認定キットのエラー メッセージ:** ExecutableImportsCheck Test failed.</span><span class="sxs-lookup"><span data-stu-id="547f9-267">**Windows App Certification Kit error message:** ExecutableImportsCheck Test failed.</span></span>

<span data-ttu-id="547f9-268">移植可能な実行可能ファイル (PE) イメージで、実行可能コード セクションにインポート テーブルが置かれていると、このテストが不合格になります。</span><span class="sxs-lookup"><span data-stu-id="547f9-268">A portable executable (PE) image fails this test if its import table has been placed in an executable code section.</span></span> <span data-ttu-id="547f9-269">これは、Visual C++ リンカーの */merge* フラグを "*/merge:.rdata=.text*" に設定して、PE イメージの .rdata マージを有効にすると生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-269">This can occur if you enabled .rdata merging for the PE image by setting the */merge* flag of the Visual C++ linker as */merge:.rdata=.text*.</span></span>

**<span data-ttu-id="547f9-270">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-270">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-271">インポート テーブルを実行可能コード セクションにマージしないでください。</span><span class="sxs-lookup"><span data-stu-id="547f9-271">Don't merge the import table into an executable code section.</span></span> <span data-ttu-id="547f9-272">Visual C++ リンカーの */merge* フラグをチェックして、.rdata セクションがコード セクションにマージされる設定になっていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-272">Make sure that the */merge* flag of the Visual C++ linker is not set to merge the ".rdata" section into a code section.</span></span>

**<span data-ttu-id="547f9-273">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-273">Remarks</span></span>**

<span data-ttu-id="547f9-274">このテストは、純粋なマネージ アセンブリを除き、すべてのバイナリ コードで実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-274">This test is performed on all binary code except purely managed assemblies.</span></span>

### <a name="span-idbinscope-8spanwxcheck"></a><span data-ttu-id="547f9-275"><span id="binscope-8"></span>WXCheck</span><span class="sxs-lookup"><span data-stu-id="547f9-275"><span id="binscope-8"></span>WXCheck</span></span>

<span data-ttu-id="547f9-276">**Windows アプリ認定キットのエラー メッセージ:** WXCheck Test failed.</span><span class="sxs-lookup"><span data-stu-id="547f9-276">**Windows App Certification Kit error message:** WXCheck Test failed.</span></span>

<span data-ttu-id="547f9-277">このチェックでは、書き込み可能または実行可能としてマップされたページがバイナリに含まれていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-277">The check helps to ensure that a binary does not have any pages that are mapped as writable and executable.</span></span> <span data-ttu-id="547f9-278">これが不合格になるのは、書き込み可能または実行可能なセクションがバイナリに含まれている場合と、バイナリの *SectionAlignment* が *PAGE\-SIZE* よりも小さい場合です。</span><span class="sxs-lookup"><span data-stu-id="547f9-278">This can occur if the binary has a writable and executable section or if the binary’s *SectionAlignment* is less than *PAGE\-SIZE*.</span></span>

**<span data-ttu-id="547f9-279">アプリがこのテストに合格しなかった場合の対処方法</span><span class="sxs-lookup"><span data-stu-id="547f9-279">What to do if your app fails this test</span></span>**

<span data-ttu-id="547f9-280">書き込み可能または実行可能なセクションがバイナリに含まれていないこと、バイナリの *SectionAlignment* の値が *PAGE\-SIZE* の値以上であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-280">Make sure that the binary does not have a writeable or executable section and that the binary's *SectionAlignment* value is at least equal to its *PAGE\-SIZE*.</span></span>

**<span data-ttu-id="547f9-281">注釈</span><span class="sxs-lookup"><span data-stu-id="547f9-281">Remarks</span></span>**

<span data-ttu-id="547f9-282">このテストは、すべての .exe ファイル、およびネイティブのアンマネージ DLL で実行されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-282">This test is performed on all .exe files and on native, unmanaged DLLs.</span></span>

<span data-ttu-id="547f9-283">書き込み可能または実行可能なセクションは、エディット コンティニュ (/ZI) を有効にしてビルドした実行可能ファイルに含まれることがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-283">An executable may have a writable and executable section if it has been built with Edit and Continue enabled (/ZI).</span></span> <span data-ttu-id="547f9-284">エディット コンティニュを無効にすると、無効なセクションは含まれなくなります。</span><span class="sxs-lookup"><span data-stu-id="547f9-284">Disabling Edit and Continue will cause the invalid section to not be present.</span></span>

<span data-ttu-id="547f9-285">*PAGE\-SIZE* は実行可能ファイルの既定の *SectionAlignment* です。</span><span class="sxs-lookup"><span data-stu-id="547f9-285">*PAGE\-SIZE* is the default *SectionAlignment* for executables.</span></span>

### <a name="private-code-signing"></a><span data-ttu-id="547f9-286">プライベート コードの署名</span><span class="sxs-lookup"><span data-stu-id="547f9-286">Private Code Signing</span></span>

<span data-ttu-id="547f9-287">アプリ パッケージ内にプライベート コードの署名バイナリが存在するかテストします。</span><span class="sxs-lookup"><span data-stu-id="547f9-287">Tests for the existence of private code signing binaries within the app package.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-288">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-288">Background</span></span>

<span data-ttu-id="547f9-289">プライベート コードの署名ファイルは、セキュリティが侵害された場合は、悪用される可能性があるため、プライベートにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-289">Private code signing files should be kept private as they may be used for malicious purposes in the event they are compromised.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-290">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-290">Test details</span></span>

<span data-ttu-id="547f9-291">アプリ パッケージ内でプライベート署名キーを含むことを示す .pfx または .snk という拡張子を持つファイルについてテストします。</span><span class="sxs-lookup"><span data-stu-id="547f9-291">Tests for files within the app package that have an extension of .pfx or.snk that would indicate that private signing keys were included.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-292">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-292">Corrective actions</span></span>

<span data-ttu-id="547f9-293">パッケージからプライベート コードの署名キー (.pfx ファイルや .snk ファイルなど) を削除します。</span><span class="sxs-lookup"><span data-stu-id="547f9-293">Remove any private code signing keys (e.g. .pfx and .snk files) from the package.</span></span>

## <a name="supported-api-test"></a><span data-ttu-id="547f9-294">サポートされる API のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-294">Supported API test</span></span>

<span data-ttu-id="547f9-295">アプリで非標準 API が使われていないかどうかをテストします。</span><span class="sxs-lookup"><span data-stu-id="547f9-295">Test the app for the use of any non-compliant APIs.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-296">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-296">Background</span></span>

<span data-ttu-id="547f9-297">アプリでは、UWP アプリ (Windows ランタイムまたはサポートされている Win32 Api) では、Microsoft ストア認定済みの Api を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-297">Apps must use the APIs for UWP apps (Windows Runtime or supported Win32 APIs) to be certified for the Microsoft Store.</span></span> <span data-ttu-id="547f9-298">このテストでは、管理されたバイナリが承認済みのプロファイル外部の機能に依存している状況も特定されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-298">This test also identifies situations where a managed binary takes a dependency on a function outside of the approved profile.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-299">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-299">Test details</span></span>

-   <span data-ttu-id="547f9-300">アプリ パッケージ内には、各バイナリがバイナリのインポート アドレス テーブルをチェックして、UWP アプリ開発のサポートされていない Win32 API の依存関係がないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-300">Verifies that each binary within the app package doesn't have a dependency on a Win32 API that is not supported for UWP app development by checking the import address table of the binary.</span></span>
-   <span data-ttu-id="547f9-301">アプリ パッケージ内の管理された各バイナリが承認済みのプロファイル外部の機能に依存していないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-301">Verifies that each managed binary within the app package doesn't have a dependency on a function outside of the approved profile.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-302">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-302">Corrective actions</span></span>

<span data-ttu-id="547f9-303">アプリが、デバッグ用のビルドではなくリリース用ビルドとしてコンパイルされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-303">Make sure that the app was compiled as a release build and not a debug build.</span></span>

> <span data-ttu-id="547f9-304">**メモ** アプリのデバッグ ビルド アプリのみ[UWP アプリ用の Api](https://msdn.microsoft.com/library/windows/apps/xaml/bg124285.aspx)を使用している場合でも、このテストは失敗します。</span><span class="sxs-lookup"><span data-stu-id="547f9-304">**Note**  The debug build of an app will fail this test even if the app uses only [APIs for UWP apps](https://msdn.microsoft.com/library/windows/apps/xaml/bg124285.aspx).</span></span>

<span data-ttu-id="547f9-305">アプリを使用して[UWP アプリ用の API](https://msdn.microsoft.com/library/windows/apps/xaml/bg124285.aspx)のない API を識別するエラー メッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-305">Review the error messages to identify the API the app uses that is not an [API for UWP apps](https://msdn.microsoft.com/library/windows/apps/xaml/bg124285.aspx).</span></span>

> <span data-ttu-id="547f9-306">**メモ** C++ アプリをデバッグ構成に組み込まれている構成では、UWP アプリの Windows SDK から Api のみが使用している場合でも、このテストは失敗します。</span><span class="sxs-lookup"><span data-stu-id="547f9-306">**Note**  C++ apps that are built in a debug configuration will fail this test even if the configuration only uses APIs from the Windows SDK for UWP apps.</span></span> <span data-ttu-id="547f9-307">さらに詳しい情報の[UWP アプリで Windows api の選択肢](http://go.microsoft.com/fwlink/p/?LinkID=244022)を表示します。</span><span class="sxs-lookup"><span data-stu-id="547f9-307">See, [Alternatives to Windows APIs in UWP apps](http://go.microsoft.com/fwlink/p/?LinkID=244022) for more info.</span></span>

## <a name="performance-tests"></a><span data-ttu-id="547f9-308">パフォーマンスのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-308">Performance tests</span></span>

<span data-ttu-id="547f9-309">軽快かつ柔軟なユーザー エクスペリエンスとなるように、アプリはユーザー操作とシステム コマンドに速やかに応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-309">The app must respond quickly to user interaction and system commands in order to present a fast and fluid user experience.</span></span>

<span data-ttu-id="547f9-310">テストを実行するコンピューターの特性がテスト結果に影響することがあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-310">The characteristics of the computer on which the test is performed can influence the test results.</span></span> <span data-ttu-id="547f9-311">アプリ認定のパフォーマンス テストのしきい値は、ユーザーの高速で滑らかなエクスペリエンスへの期待が低電力コンピューターでも満たされるように設定されています。</span><span class="sxs-lookup"><span data-stu-id="547f9-311">The performance test thresholds for app certification are set such that low-power computers meet the customer’s expectation of a fast and fluid experience.</span></span> <span data-ttu-id="547f9-312">アプリのパフォーマンスを確認するには、アプリを低電力コンピューター (たとえば画面の解像度が 1366 x 768 またはそれ以上で、回転式ハード ドライブを搭載した Intel Atom プロセッサ ベースのコンピューター) 上でテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="547f9-312">To determine your app’s performance, we recommend that you test on a low-power computer, such as an Intel Atom processor-based computer with a screen resolution of 1366x768 (or higher) and a rotational hard drive (as opposed to a solid-state hard drive).</span></span>

### <a name="bytecode-generation"></a><span data-ttu-id="547f9-313">バイトコードの作成</span><span class="sxs-lookup"><span data-stu-id="547f9-313">Bytecode generation</span></span>

<span data-ttu-id="547f9-314">JavaScript の実行時間を短縮するパフォーマンスの最適化として、アプリの展開時、末尾が .js 拡張子の JavaScript ファイルによりバイトコードが生成されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-314">As a performance optimization to accelerate JavaScript execution time, JavaScript files ending in the .js extension generate bytecode when the app is deployed.</span></span> <span data-ttu-id="547f9-315">そのため、JavaScript 操作の開始時間と実行継続時間が大幅に短縮されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-315">This significantly improves startup and ongoing execution times for JavaScript operations.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-316">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-316">Test Details</span></span>

<span data-ttu-id="547f9-317">アプリの展開をチェックして、すべての .js ファイルがバイトコードに変換されたことをチェックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-317">Checks the app deployment to verify that all .js files have been converted to bytecode.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-318">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-318">Corrective Action</span></span>

<span data-ttu-id="547f9-319">このテストに合格しなかった場合は、問題の対処に際して次の点を考慮します。</span><span class="sxs-lookup"><span data-stu-id="547f9-319">If this test fails, consider the following when addressing the issue:</span></span>

-   <span data-ttu-id="547f9-320">イベント ログが有効になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-320">Verify that event logging is enabled.</span></span>
-   <span data-ttu-id="547f9-321">すべての JavaScript ファイルが構文的に正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-321">Verify that all JavaScript files are syntactically valid.</span></span>
-   <span data-ttu-id="547f9-322">以前のバージョンのアプリがすべてアンインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-322">Confirm that all previous versions of the app are uninstalled.</span></span>
-   <span data-ttu-id="547f9-323">識別されたファイルをアプリ パッケージから除外します。</span><span class="sxs-lookup"><span data-stu-id="547f9-323">Exclude identified files from the app package.</span></span>

### <a name="optimized-binding-references"></a><span data-ttu-id="547f9-324">最適化されたバインディング参照</span><span class="sxs-lookup"><span data-stu-id="547f9-324">Optimized binding references</span></span>

<span data-ttu-id="547f9-325">バインディングを使うときは、メモリ使用率を最適化するために WinJS.Binding.optimizeBindingReferences を true に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-325">When using bindings, WinJS.Binding.optimizeBindingReferences should be set to true in order to optimize memory usage.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-326">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-326">Test Details</span></span>

<span data-ttu-id="547f9-327">WinJS.Binding.optimizeBindingReferences の値を確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-327">Verify the value of WinJS.Binding.optimizeBindingReferences.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-328">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-328">Corrective Action</span></span>

<span data-ttu-id="547f9-329">アプリの JavaScript で WinJS.Binding.optimizeBindingReferences を "**true**" に設定します。</span><span class="sxs-lookup"><span data-stu-id="547f9-329">Set WinJS.Binding.optimizeBindingReferences to **true** in the app JavaScript.</span></span>

## <a name="app-manifest-resources-test"></a><span data-ttu-id="547f9-330">アプリ マニフェストのリソースのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-330">App manifest resources test</span></span>

### <a name="app-resources-validation"></a><span data-ttu-id="547f9-331">アプリ リソースの検証</span><span class="sxs-lookup"><span data-stu-id="547f9-331">App resources validation</span></span>

<span data-ttu-id="547f9-332">アプリのマニフェストで宣言されている文字列や画像に誤りがある場合は、そのアプリはインストールされない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-332">The app might not install if the strings or images declared in your app’s manifest are incorrect.</span></span> <span data-ttu-id="547f9-333">これらのエラーがあるアプリをインストールすると、アプリが使用するアプリのロゴなどの画像が適切に表示されません。</span><span class="sxs-lookup"><span data-stu-id="547f9-333">If the app does install with these errors, your app’s logo or other images used by your app might not display correctly.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-334">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-334">Test Details</span></span>

<span data-ttu-id="547f9-335">アプリ マニフェストで定義されているリソースを調べて、それらのリソースが存在し有効であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-335">Inspects the resources defined in the app manifest to make sure they are present and valid.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-336">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-336">Corrective Action</span></span>

<span data-ttu-id="547f9-337">次の表をガイダンスとして使います。</span><span class="sxs-lookup"><span data-stu-id="547f9-337">Use the following table as guidance.</span></span>

<table>
<tr><th><span data-ttu-id="547f9-338">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="547f9-338">Error message</span></span></th><th><span data-ttu-id="547f9-339">コメント</span><span class="sxs-lookup"><span data-stu-id="547f9-339">Comments</span></span></th></tr>
<tr><td>
<p><span data-ttu-id="547f9-340">The image {image name} defines both Scale and TargetSize qualifiers; you can define only one qualifier at a time. (イメージ {image name} には Scale 修飾子と TargetSize 修飾子が定義されていますが、一度に定義可能な修飾子は 1 つだけです。)</span><span class="sxs-lookup"><span data-stu-id="547f9-340">The image {image name} defines both Scale and TargetSize qualifiers; you can define only one qualifier at a time.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-341">さまざまな解像度に合わせて画像をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="547f9-341">You can customize images for different resolutions.</span></span></p>
<p><span data-ttu-id="547f9-342">実際のメッセージでは、{imageName} にエラーの発生した画像の名前が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-342">In the actual message, {image name} contains the name of the image with the error.</span></span></p>
<p> <span data-ttu-id="547f9-343">各画像で Scale と TargetSize のいずれかが修飾子として定義されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-343">Make sure that each image defines either Scale or TargetSize as the qualifier.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-344">The image {image name} failed the size restrictions. (イメージ {image name} がサイズ制限を超えました。)</span><span class="sxs-lookup"><span data-stu-id="547f9-344">The image {image name} failed the size restrictions.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-345">すべてのアプリ画像が適切なサイズ制限に従っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-345">Ensure that all the app images adhere to the proper size restrictions.</span></span></p>
<p><span data-ttu-id="547f9-346">実際のメッセージでは、{imageName} にエラーの発生した画像の名前が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-346">In the actual message, {image name} contains the name of the image with the error.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-347">The image {image name} is missing from the package. (イメージ {image name} がパッケージ内に見つかりません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-347">The image {image name} is missing from the package.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-348">必要な画像がありません。</span><span class="sxs-lookup"><span data-stu-id="547f9-348">A required image is missing.</span></span></p>
<p><span data-ttu-id="547f9-349">実際のメッセージでは、{image name} に見つからない画像の名前が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-349">In the actual message, {image name} contains the name of the image that is missing.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-350">The image {image name} is not a valid image file. (イメージ {image name} は有効なイメージ ファイルではありません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-350">The image {image name} is not a valid image file.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-351">すべてのアプリ画像が適切なファイルの種類の制限に従っていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-351">Ensure that all the app images adhere to the proper file format type restrictions.</span></span></p>
<p><span data-ttu-id="547f9-352">実際のメッセージでは、{image name} に画像の色として無効な値が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-352">In the actual message, {image name} contains the name of the image that is not valid.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-353">The image "BadgeLogo" has an ABGR value {value} at position (x, y) that is not valid. (画像 "BadgeLogo" の位置 (x, y) の ABGR 値 {value} が無効です。)</span><span class="sxs-lookup"><span data-stu-id="547f9-353">The image "BadgeLogo" has an ABGR value {value} at position (x, y) that is not valid.</span></span> <span data-ttu-id="547f9-354">The pixel must be white (##FFFFFF) or transparent (00######) (このピクセルは、白 (##FFFFFF) または透明 (00######) である必要があります。)</span><span class="sxs-lookup"><span data-stu-id="547f9-354">The pixel must be white (##FFFFFF) or transparent (00######)</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-355">バッジ ロゴはロック画面でアプリを識別するためにバッジ通知の横に表示される画像です。</span><span class="sxs-lookup"><span data-stu-id="547f9-355">The badge logo is an image that appears next to the badge notification to identify the app on the lock screen.</span></span> <span data-ttu-id="547f9-356">この画像はモノクロである必要があります (含めることができるのは白または透明のピクセルだけです)。</span><span class="sxs-lookup"><span data-stu-id="547f9-356">This image must be monochromatic (it can contain only white and transparent pixels).</span></span></p>
<p><span data-ttu-id="547f9-357">実際のメッセージでは、{value} に画像の色として無効な値が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-357">In the actual message, {value} contains the color value in the image that is not valid.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-358">The image “BadgeLogo” has an ABGR value {value} at position (x, y) that is not valid for a high-contrast white image. (画像 "BadgeLogo" の位置 (x, y) にハイコントラストの白い画像には無効な ABGR 値 {value} があります。)</span><span class="sxs-lookup"><span data-stu-id="547f9-358">The image "BadgeLogo" has an ABGR value {value} at position (x, y) that is not valid for a high-contrast white image.</span></span> <span data-ttu-id="547f9-359">The pixel must be (##2A2A2A) or darker, or transparent (00######). (ピクセルは (##2A2A2A) か、それより暗いか、透明 (00######) である必要があります。)</span><span class="sxs-lookup"><span data-stu-id="547f9-359">The pixel must be (##2A2A2A) or darker, or transparent (00######).</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-360">バッジ ロゴはロック画面でアプリを識別するためにバッジ通知の横に表示される画像です。</span><span class="sxs-lookup"><span data-stu-id="547f9-360">The badge logo is an image that appears next to the badge notification to identify the app on the lock screen.</span></span>   <span data-ttu-id="547f9-361">"ハイコントラスト 白" ではバッジ ロゴが白い背景に表示されるため、通常のバッジ ロゴの濃いバージョンを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-361">Because the badge logo  appears on a white background when in high-contrast white, it must be a dark version of the normal badge logo.</span></span> <span data-ttu-id="547f9-362">"ハイコントラスト 白" でバッジ ロゴに含めることができるピクセルは、(##2A2A2A) より濃い色か透明のピクセルだけです。</span><span class="sxs-lookup"><span data-stu-id="547f9-362">In high-contrast white, the badge logo can only contain pixels that are darker than (##2A2A2A) or transparent.</span></span></p>
<p><span data-ttu-id="547f9-363">実際のメッセージでは、{value} に画像の色として無効な値が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-363">In the actual message, {value} contains the color value in the image that is not valid.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-364">The image must define at least one variant without a TargetSize qualifier. (画像では、TargetSize 修飾子がないバージョンが少なくとも 1 つ定義されている必要があります。)</span><span class="sxs-lookup"><span data-stu-id="547f9-364">The image must define at least one variant without a TargetSize qualifier.</span></span> <span data-ttu-id="547f9-365">It must define a Scale qualifier or leave Scale and TargetSize unspecified, which defaults to Scale-100. (Scale 修飾子が定義されているか、または Scale と TargetSize が指定されていないままである必要があり、既定では Scale-100 です。)</span><span class="sxs-lookup"><span data-stu-id="547f9-365">It must define a Scale qualifier or leave Scale and TargetSize unspecified, which defaults to Scale-100.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-366">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/dn958435.aspx">UWP アプリ用レスポンシブ デザイン 101</a>」と「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/hh465241.aspx">アプリ リソースのガイドライン</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-366">For more info, see <a href="https://msdn.microsoft.com/library/windows/apps/xaml/dn958435.aspx">Responsive design 101 for UWP apps</a> and <a href="https://msdn.microsoft.com/library/windows/apps/xaml/hh465241.aspx">Guidelines for app resources</a>.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-367">The package is missing a "resources.pri" file. (パッケージに "resources.pri" ファイルがありません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-367">The package is missing a "resources.pri" file.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-368">アプリ マニフェストにローカライズ可能なコンテンツがある場合は、アプリのパッケージに有効な resources.pri ファイルが含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-368">If you have localizable content in your app manifest, make sure that your app's package includes a valid resources.pri file.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-369">The "resources.pri" file must contain a resource map with a name that matches the package name {package full name} ("resources.pri" ファイルには、パッケージ名 {package full name} と名前が一致するリソース マップが含まれている必要があります。)</span><span class="sxs-lookup"><span data-stu-id="547f9-369">The "resources.pri" file must contain a resource map with a name that matches the package name  {package full name}</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-370">このエラーが表示される場合は、マニフェストが変更され、resources.pri 内のリソース マップの名前がマニフェストのパッケージ名と一致しなくなった可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-370">You can get this error if the manifest changed and  the name of the resource map in resources.pri no longer matches the package name in the manifest.</span></span></p>
<p><span data-ttu-id="547f9-371">実際のメッセージでは、{package full name} には resources.pri に含まれている必要があるパッケージ名が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-371">In the actual message, {package full name} contains the package name that resources.pri must contain.</span></span></p>
<p><span data-ttu-id="547f9-372">この問題を解決するには、resources.pri をリビルドする必要があります。その場合は、アプリのパッケージをリビルドするのが最も簡単です。</span><span class="sxs-lookup"><span data-stu-id="547f9-372">To fix this, you need to rebuild resources.pri and the easiest way to do that is  by rebuilding the app's package.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-373">The "resources.pri" file must not have AutoMerge enabled. ("resources.pri" ファイルは AutoMerge を有効にしないでください。)</span><span class="sxs-lookup"><span data-stu-id="547f9-373">The "resources.pri" file must not have AutoMerge enabled.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-374">MakePRI.exe では、<strong>AutoMerge</strong> というオプションがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="547f9-374">MakePRI.exe supports an option called <strong>AutoMerge</strong>.</span></span> <span data-ttu-id="547f9-375"><strong>AutoMerge</strong> の規定値は "<strong>off</strong>" です。</span><span class="sxs-lookup"><span data-stu-id="547f9-375">The default value of <strong>AutoMerge</strong> is <strong>off</strong>.</span></span> <span data-ttu-id="547f9-376">オンにすると、<strong>AutoMerge</strong> が実行時にアプリの言語パックを単一の resources.pri にマージします。</span><span class="sxs-lookup"><span data-stu-id="547f9-376">When enabled, <strong>AutoMerge</strong> merges an app's  language pack resources into a single resources.pri at runtime.</span></span> <span data-ttu-id="547f9-377">これは、Microsoft ストアを配布するアプリをお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="547f9-377">We don't recommend this for apps that you intend to distribute through  the Microsoft Store.</span></span> <span data-ttu-id="547f9-378">Microsoft ストアで配布されるアプリの resources.pri する必要がありますアプリのパッケージのルートで、アプリをサポートしているすべての言語の参照が含まれています。</span><span class="sxs-lookup"><span data-stu-id="547f9-378">The resources.pri of an app that is distributed through the  Microsoft Store must be in  the root of the app's package and contain all the language references that the app supports.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-379">The string {string} failed the max length restriction of {number} characters. (文字列 {string} が {number} 文字の最大文字数の制限を満たしていません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-379">The string {string} failed the max length restriction of {number} characters.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-380">「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt148525.aspx">アプリ パッケージの要件</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-380">Refer to the <a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt148525.aspx">App package requirements</a>.</span></span></p>
<p><span data-ttu-id="547f9-381">実際のメッセージでは、{string} が問題の文字列に置き換わり、{number} に最大文字数が入ります。</span><span class="sxs-lookup"><span data-stu-id="547f9-381">In the actual message, {string} is replaced by the string with the error and {number} contains the maximum length.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-382">The string {string} must not have leading/trailing whitespace. (文字列 {string} の先頭または末尾を空白にすることはできません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-382">The string {string} must not have leading/trailing whitespace.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-383">アプリ マニフェストの要素のスキーマでは、先頭および末尾の空白は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="547f9-383">The schema for the elements in the app manifest don't allow leading or trailing white space characters.</span></span></p>
<p><span data-ttu-id="547f9-384">実際のメッセージでは、{string} が問題の文字列に置き換わります。</span><span class="sxs-lookup"><span data-stu-id="547f9-384">In the actual message, {string} is replaced by the string with the error.</span></span></p>
<p><span data-ttu-id="547f9-385">resources.pri のマニフェスト フィールドのローカライズされた値において、先頭または末尾にスペースが挿入されていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-385">Make sure that none of the localized values of the manifest fields in resources.pri have leading or trailing white space characters.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-386">The string must be non-empty (greater than zero in length) (文字列を空にすることはできません (文字数が 0 より大きい必要があります)。)</span><span class="sxs-lookup"><span data-stu-id="547f9-386">The string must be non-empty (greater than zero in length)</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-387">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt148525.aspx">アプリ パッケージの要件</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-387">For more info, see <a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt148525.aspx">App package requirements</a>.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-388">There is no default resource specified in the "resources.pri" file. ("resources.pri" ファイルで指定された既定のリソースがありません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-388">There is no default resource specified in the "resources.pri" file.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-389">詳しくは、「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/hh465241.aspx">アプリ リソースのガイドライン</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-389">For more info, see <a href="https://msdn.microsoft.com/library/windows/apps/xaml/hh465241.aspx">Guidelines for app resources</a>.</span></span></p>
<p><span data-ttu-id="547f9-390">既定のビルド構成では、Visual Studio はバンドル生成時に 200% スケールの画像リソースのみをアプリ パッケージ内に組み込み、その他のリソースはリソース パッケージ内に配置します。</span><span class="sxs-lookup"><span data-stu-id="547f9-390">In the default build configuration,  Visual Studio only includes scale-200 image resources in the app package when generating bundles, putting other resources in the resource package.</span></span> <span data-ttu-id="547f9-391">200% スケールの画像リソースを組み込むか、または持っているリソースを組み込むようにプロジェクトを構成してください。</span><span class="sxs-lookup"><span data-stu-id="547f9-391">Make sure  you either include scale-200 image resources or configure your project to include the resources you have.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-392">There is no resource value specified in the "resources.pri" file. ("resources.pri" ファイルに指定されたリソース値がありません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-392">There is no resource value specified in the "resources.pri" file.</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-393">resources.pri でアプリ マニフェストの有効なリソースが定義されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-393">Make sure that the app manifest has valid resources defined in resources.pri.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-394">The image file {filename} must be smaller than 204800 bytes.\*\* (イメージ ファイル {filename} は、204,800 バイト未満である必要があります。)</span><span class="sxs-lookup"><span data-stu-id="547f9-394">The image file {filename} must be smaller than 204800 bytes.\*\*</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-395">指定の画像のサイズを小さくします。</span><span class="sxs-lookup"><span data-stu-id="547f9-395">Reduce the size of the indicated images.</span></span></p>
</td></tr>
<tr><td>
<p><span data-ttu-id="547f9-396">The {filename} file must not contain a reverse map section.\*\* ({filename} ファイルには、リバース マップ セクションを含めることはできません。)</span><span class="sxs-lookup"><span data-stu-id="547f9-396">The {filename} file must not contain a reverse map section.\*\*</span></span></p>
</td><td>
<p><span data-ttu-id="547f9-397">逆マップは Visual Studio の F5 デバッグ時に makepri.exe を呼び出すと生成されますが、pri ファイルの生成時に /m パラメーターなしで makepri.exe を実行すると削除することができます。</span><span class="sxs-lookup"><span data-stu-id="547f9-397">While the reverse map is generated during Visual Studio 'F5 debugging' when calling into makepri.exe, it can be removed by running makepri.exe without the /m parameter when generating a pri file.</span></span></p>
</td></tr>
<tr><td colspan="2">
<p><span data-ttu-id="547f9-398">\*\* Windows 8.1 用の Windows アプリ認定キット 3.3 に追加されたテストであり、そのバージョン以降のキットを使う場合にのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-398">\*\* Indicates that a test was added in the Windows App Certification Kit 3.3 for Windows 8.1 and is only applicable when using the that version of the kit or later.</span></span></p>
</td></tr>
</table>



 

### <a name="branding-validation"></a><span data-ttu-id="547f9-399">ブランドの検証</span><span class="sxs-lookup"><span data-stu-id="547f9-399">Branding validation</span></span>

<span data-ttu-id="547f9-400">UWP アプリは、完了と完全に機能する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-400">UWP apps are expected to be complete and fully functional.</span></span> <span data-ttu-id="547f9-401">既定の画像 (テンプレートまたは SDK サンプルの画像) を使ったアプリは、ユーザー エクスペリエンスが貧弱であることを示しているため、ストア カタログであまり識別されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-401">Apps using the default images (from templates or SDK samples) present a poor user experience and cannot be easily identified in the store catalog.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-402">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-402">Test Details</span></span>

<span data-ttu-id="547f9-403">このテストは、アプリで使われている画像が SDK サンプルまたは Visual Studio の既定の画像でないことを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-403">The test will validate if the images used by the app are not default images either from SDK samples or from Visual Studio.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-404">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-404">Corrective actions</span></span>

<span data-ttu-id="547f9-405">既定の画像を、もっとアプリを明確に表すものに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="547f9-405">Replace default images with something more distinct and representative of your app.</span></span>

## <a name="debug-configuration-test"></a><span data-ttu-id="547f9-406">デバッグ構成のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-406">Debug configuration test</span></span>

<span data-ttu-id="547f9-407">アプリをテストして、デバッグ用のビルドでないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-407">Test the app to make sure it is not a debug build.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-408">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-408">Background</span></span>

<span data-ttu-id="547f9-409">Microsoft ストアで認定済み] アプリする必要があるコンパイルされずデバッグ、実行可能ファイルのデバッグ バージョンが参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-409">To be certified for the Microsoft Store, apps must not be compiled for debug and they must not reference debug versions of an executable file.</span></span> <span data-ttu-id="547f9-410">また、アプリがこのテストに合格するよう最適化されたコードをビルドする必要もあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-410">In addition, you must build your code as optimized for your app to pass this test.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-411">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-411">Test details</span></span>

<span data-ttu-id="547f9-412">アプリをテストして、デバッグ用のビルドでないことと、どのデバッグ用のフレームワークにもリンクされていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-412">Test the app to make sure it is not a debug build and is not linked to any debug frameworks.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-413">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-413">Corrective actions</span></span>

-   <span data-ttu-id="547f9-414">Microsoft ストアに送信する前にリリース ビルドとしてアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="547f9-414">Build the app as a release build before you submit it to the Microsoft Store.</span></span>
-   <span data-ttu-id="547f9-415">適切なバージョンの .NET フレームワークがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-415">Make sure that you have the correct version of .NET framework installed.</span></span>
-   <span data-ttu-id="547f9-416">アプリがフレームワークのデバッグ バージョンにリンクされていないことと、リリース バージョンで構築されたことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-416">Make sure the app isn't linking to debug versions of a framework and that it is building with a release version.</span></span> <span data-ttu-id="547f9-417">このアプリに .NET コンポーネントが含まれている場合は、適切なバージョンの .NET Framework がインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-417">If this app contains .NET components, make sure that you have installed the correct version of the .NET framework.</span></span>

## <a name="file-encoding-test"></a><span data-ttu-id="547f9-418">ファイル エンコードのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-418">File encoding test</span></span>

### <a name="utf-8-file-encoding"></a><span data-ttu-id="547f9-419">UTF-8 ファイル エンコード</span><span class="sxs-lookup"><span data-stu-id="547f9-419">UTF-8 file encoding</span></span>

### <a name="background"></a><span data-ttu-id="547f9-420">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-420">Background</span></span>

<span data-ttu-id="547f9-421">バイトコード キャッシュを活用して特定の実行時エラー状態を避けるには、HTML、CSS、JavaScript の各ファイルが、対応するバイト オーダー マーク (BOM) を持つ UTF-8 形式でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-421">HTML, CSS, and JavaScript files must be encoded in UTF-8 form with a corresponding byte-order mark (BOM) to benefit from bytecode caching and avoid certain runtime error conditions.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-422">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-422">Test details</span></span>

<span data-ttu-id="547f9-423">アプリ パッケージのコンテンツをテストし、正しいファイル エンコードが使われていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-423">Test the contents of app packages to make sure that they use the correct file encoding.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-424">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-424">Corrective Action</span></span>

<span data-ttu-id="547f9-425">Visual Studio で、影響を受けるファイルを開き、**[ファイル]** メニューの **[名前を付けて保存]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="547f9-425">Open the affected file and select **Save As** from the **File** menu in Visual Studio.</span></span> <span data-ttu-id="547f9-426">**[保存]** ボタンの横のドロップダウン コントロールを選び、**[エンコード付きで保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-426">Select the drop-down control next to the **Save** button and select **Save with Encoding**.</span></span> <span data-ttu-id="547f9-427">**[保存オプションの詳細設定]** ダイアログ ボックスで、Unicode (シグネチャを含む UTF-8) オプションを選び、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="547f9-427">From the **Advanced** save options dialog, choose the Unicode (UTF-8 with signature) option and click **OK**.</span></span>

## <a name="direct3d-feature-level-test"></a><span data-ttu-id="547f9-428">Direct3D の機能レベルのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-428">Direct3D feature level test</span></span>

### <a name="direct3d-feature-level-support"></a><span data-ttu-id="547f9-429">Direct3D の機能レベルのサポート</span><span class="sxs-lookup"><span data-stu-id="547f9-429">Direct3D feature level support</span></span>

<span data-ttu-id="547f9-430">Microsoft Direct3D アプリをテストして、以前のグラフィックス ハードウェアを搭載したデバイスでクラッシュしないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-430">Tests Microsoft Direct3D apps to ensure that they won't crash on devices with older graphics hardware.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-431">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-431">Background</span></span>

<span data-ttu-id="547f9-432">Microsoft ストアには、適切に表示したり、正常に機能のレベルの 9\ 1 グラフィック カードが失敗する Direct3D を使用してすべてのアプリケーションが必要です。</span><span class="sxs-lookup"><span data-stu-id="547f9-432">Microsoft Store requires all applications using Direct3D to render properly or fail gracefully on feature level 9\-1 graphics cards.</span></span>

<span data-ttu-id="547f9-433">アプリのインストール後にユーザーのデバイスのグラフィックス ハードウェアがユーザーによって変更されることもあるため、最小機能レベルを 9\-1 よりも高くする場合は、現在のハードウェアが最小要件を満たしているかどうかをアプリの起動時に検出するようにしなければなりません。</span><span class="sxs-lookup"><span data-stu-id="547f9-433">Because users can change the graphics hardware in their device after the app is installed, if you choose a minimum feature level higher than 9\-1, your app must detect at launch whether or not the current hardware meets the minimum requirements.</span></span> <span data-ttu-id="547f9-434">最小要件が満たされていない場合は、アプリでは Direct3D の要件に関する詳しいメッセージをユーザーに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-434">If the minimum requirements are not met, the app must display a message to the user detailing the Direct3D requirements.</span></span> <span data-ttu-id="547f9-435">また、アプリが互換性のないデバイスでダウンロードされた場合は、起動時にそれを検出し、要件について説明するメッセージをユーザーに表示する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="547f9-435">Also, if an app is downloaded on a device with which it is not compatible, it should detect that at launch and display a message to the customer detailing the requirements.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-436">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-436">Test Details</span></span>

<span data-ttu-id="547f9-437">このテストは、アプリが機能レベル 9\-1 で正確にレンダリングされるかどうかを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-437">The test will validate if the apps render accurately on feature level 9\-1.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-438">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-438">Corrective Action</span></span>

<span data-ttu-id="547f9-439">高い機能レベルで実行されると予想される場合でも、アプリが Direct3D 機能レベル 9\-1 で正しくレンダリングされることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-439">Ensure that your app renders correctly on Direct3D feature level 9\-1, even if you expect it to run at a higher feature level.</span></span> <span data-ttu-id="547f9-440">詳しくは、「[機能レベルが異なる Direct3D の開発](http://go.microsoft.com/fwlink/p/?LinkID=253575)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="547f9-440">See [Developing for different Direct3D feature levels](http://go.microsoft.com/fwlink/p/?LinkID=253575) for more info.</span></span>

### <a name="direct3d-trim-after-suspend"></a><span data-ttu-id="547f9-441">中断後の Direct3D トリミング</span><span class="sxs-lookup"><span data-stu-id="547f9-441">Direct3D Trim after suspend</span></span>

> <span data-ttu-id="547f9-442">**メモ** このテストは、Windows 8.1、後で開発 UWP アプリにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-442">**Note**  This test only applies to UWP apps developed for Windows 8.1 and later.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-443">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-443">Background</span></span>

<span data-ttu-id="547f9-444">アプリが Direct3D デバイスで [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) を呼び出さない場合は、アプリは前の 3D 作業に割り当てられたメモリを解放しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-444">If the app does not call [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) on its Direct3D device, the app will not release memory allocated for its earlier 3D work.</span></span> <span data-ttu-id="547f9-445">この結果、システムのメモリ不足のためにアプリが終了するリスクが増加します。</span><span class="sxs-lookup"><span data-stu-id="547f9-445">This increases the risk of apps being terminated due to system memory pressure.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-446">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-446">Test Details</span></span>

<span data-ttu-id="547f9-447">アプリが d3d 要件を満たしているかどうか、そして中断コールバック時に新しい [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) API を呼び出すかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-447">Checks apps for compliance with d3d requirements and ensures that apps are calling a new [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) API upon their Suspend callback.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-448">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-448">Corrective Action</span></span>

<span data-ttu-id="547f9-449">アプリは中断されそうになった時は常に [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280345) インターフェイスで [**IDXGIDevice3**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-449">The app should call the [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) API on its [**IDXGIDevice3**](https://msdn.microsoft.com/library/windows/desktop/Dn280345) interface anytime it is about to be suspended.</span></span>

## <a name="app-capabilities-test"></a><span data-ttu-id="547f9-450">アプリ機能のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-450">App Capabilities test</span></span>

### <a name="special-use-capabilities"></a><span data-ttu-id="547f9-451">特殊な用途の機能</span><span class="sxs-lookup"><span data-stu-id="547f9-451">Special use capabilities</span></span>

### <a name="background"></a><span data-ttu-id="547f9-452">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-452">Background</span></span>

<span data-ttu-id="547f9-453">特殊な用途の機能は、特殊なシナリオ向けの機能です。</span><span class="sxs-lookup"><span data-stu-id="547f9-453">Special use capabilities are intended for very specific scenarios.</span></span> <span data-ttu-id="547f9-454">会社アカウントだけがこれらの機能を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="547f9-454">Only company accounts are allowed to use these capabilities.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-455">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-455">Test Details</span></span>

<span data-ttu-id="547f9-456">アプリが次のいずれかの機能を宣言することを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-456">Validate if the app is declaring any of the below capabilities:</span></span>

-   <span data-ttu-id="547f9-457">EnterpriseAuthentication</span><span class="sxs-lookup"><span data-stu-id="547f9-457">EnterpriseAuthentication</span></span>
-   <span data-ttu-id="547f9-458">SharedUserCertificates</span><span class="sxs-lookup"><span data-stu-id="547f9-458">SharedUserCertificates</span></span>
-   <span data-ttu-id="547f9-459">DocumentsLibrary</span><span class="sxs-lookup"><span data-stu-id="547f9-459">DocumentsLibrary</span></span>

<span data-ttu-id="547f9-460">これらの機能のいずれかが宣言される場合は、テストにより警告がユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="547f9-460">If any of these capabilities are declared, the test will display a warning to the user.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-461">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-461">Corrective Actions</span></span>

<span data-ttu-id="547f9-462">アプリが必要としない場合は、特殊な用途の機能を削除することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="547f9-462">Consider removing the special use capability if your app doesn't require it.</span></span> <span data-ttu-id="547f9-463">さらに、これらの機能は、追加の登録ポリシー レビューの対象となります。</span><span class="sxs-lookup"><span data-stu-id="547f9-463">Additionally, use of these capabilities are subject to additional on-boarding policy review.</span></span>

## <a name="windows-runtime-metadata-validation"></a><span data-ttu-id="547f9-464">Windows ランタイム メタデータ検証</span><span class="sxs-lookup"><span data-stu-id="547f9-464">Windows Runtime metadata validation</span></span>

### <a name="background"></a><span data-ttu-id="547f9-465">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-465">Background</span></span>

<span data-ttu-id="547f9-466">アプリに付属するコンポーネントが、UWP 型システムに準拠していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-466">Ensures that the components that ship in an app conform to the UWP type system.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-467">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-467">Test Details</span></span>

<span data-ttu-id="547f9-468">パッケージの **.winmd** ファイルが UWP 規則に準拠していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-468">Verifies that the **.winmd** files in the package conform to UWP rules.</span></span>

### <a name="corrective-actions"></a><span data-ttu-id="547f9-469">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-469">Corrective Actions</span></span>

-   <span data-ttu-id="547f9-470">**ExclusiveTo 属性のテスト:** UWP クラスに別の ExclusiveTo クラスとしてマークされたインターフェイスが実装されていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-470">**ExclusiveTo attribute test:** Ensure that UWP classes don't implement interfaces that are marked as ExclusiveTo another class.</span></span>
-   <span data-ttu-id="547f9-471">**型の場所のテスト:** UWP のすべての型のメタデータが、アプリ パッケージで最も長い名前空間対応の名前を持つ winmd ファイルにあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-471">**Type location test:** Ensure that the metadata for all UWP types is located in the winmd file that has the longest namespace-matching name in the app package.</span></span>
-   <span data-ttu-id="547f9-472">**型名の大文字小文字の区別のテスト:** すべての UWP 型のアプリ パッケージ内に大文字と小文字が区別されない一意の名前が存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-472">**Type name case-sensitivity test:** Ensure that all UWP types have unique, case-insensitive names within your app package.</span></span> <span data-ttu-id="547f9-473">また、UWP 型名が、アプリ パッケージ内で名前空間名として使われていないことも確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-473">Also ensure that no UWP type name is also used as a namespace name within your app package.</span></span>
-   <span data-ttu-id="547f9-474">**型名の正確性のテスト:** グローバル名前空間または Windows の最上位名前空間に UWP 型がないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-474">**Type name correctness test:** Ensure there are no UWP types in the global namespace or in the Windows top-level namespace.</span></span>
-   <span data-ttu-id="547f9-475">**一般的なメタデータの正確性のテスト:** 型の生成に使っているコンパイラが UWP の仕様に従って最新の状態になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-475">**General metadata correctness test:** Ensure that the compiler you are using to generate your types is up to date with the UWP specifications.</span></span>
-   <span data-ttu-id="547f9-476">**プロパティのテスト:** UWP クラスのすべてのプロパティに get メソッドがあることを確認します (set メソッドは省略可能です)。</span><span class="sxs-lookup"><span data-stu-id="547f9-476">**Properties test:** ensure that all properties on a UWP class have a get method (set methods are optional).</span></span> <span data-ttu-id="547f9-477">UWP 型のすべてのプロパティについて、get メソッドの戻り値の型が set メソッドの入力パラメーターの型に一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-477">Ensure that the type of the get method return value matches the type of the set method input parameter, for all properties on UWP types.</span></span>

## <a name="package-sanity-tests"></a><span data-ttu-id="547f9-478">パッケージ サニティ テスト</span><span class="sxs-lookup"><span data-stu-id="547f9-478">Package Sanity tests</span></span>

### <a name="platform-appropriate-files-test"></a><span data-ttu-id="547f9-479">プラットフォーム対応ファイル テスト</span><span class="sxs-lookup"><span data-stu-id="547f9-479">Platform appropriate files test</span></span>

<span data-ttu-id="547f9-480">混在するバイナリをインストールするアプリは、ユーザーのプロセッサ アーキテクチャによってはクラッシュしたり、正しく動作しない場合があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-480">Apps that install mixed binaries may crash or not run correctly depending upon the user’s processor architecture.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-481">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-481">Background</span></span>

<span data-ttu-id="547f9-482">このテストでは、アーキテクチャが競合していないか、アプリ パッケージのバイナリを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-482">This test validates the binaries in an app package for architecture conflicts.</span></span> <span data-ttu-id="547f9-483">アプリ パッケージには、マニフェストに指定されたプロセッサ アーキテクチャで使用できないバイナリを含めることができません。</span><span class="sxs-lookup"><span data-stu-id="547f9-483">An app package should not include binaries that can't be used on the processor architecture specified in the manifest.</span></span> <span data-ttu-id="547f9-484">サポートされていないバイナリが含まれると、アプリがクラッシュしたり、アプリのパッケージ サイズが不必要に大きくなったりする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-484">Including unsupported binaries can lead to your app crashing or an unnecessary increase in the app package size.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-485">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-485">Test Details</span></span>

<span data-ttu-id="547f9-486">アプリ パッケージのプロセッサ アーキテクチャ宣言と相互参照される場合に、各ファイルの PE ヘッダー内のビット "bitness" が適切かどうかを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-486">Validates that each file's "bitness" in the PE header is appropriate when cross-referenced with the app package processor architecture declaration</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-487">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-487">Corrective Action</span></span>

<span data-ttu-id="547f9-488">アプリ マニフェストで指定されたアーキテクチャでサポートされるファイルのみをアプリ パッケージが含むことを確認するために、次のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="547f9-488">Follow these guidelines to ensure that your app package only contains files supported by the architecture specified in the app manifest:</span></span>

-   <span data-ttu-id="547f9-489">アプリのターゲット プロセッサ アーキテクチャがニュートラル プロセッサ タイプの場合、アプリ パッケージは、x86、x64、または ARM のバイナリ タイプまたはイメージ タイプのファイルを含むことはできません。</span><span class="sxs-lookup"><span data-stu-id="547f9-489">If the Target Processor Architecture for your app is Neutral processor Type, the app package cannot contain x86, x64, or ARM binary or image type files.</span></span>

-   <span data-ttu-id="547f9-490">アプリのターゲット プロセッサ アーキテクチャが x86 プロセッサ タイプの場合、アプリ パッケージは、x86 バイナリ タイプまたはイメージ タイプのファイルのみを含む必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-490">If the Target Processor Architecture for your app is x86 processor type, the app package must only contain x86 binary or image type files.</span></span> <span data-ttu-id="547f9-491">パッケージが x64 ないし ARM バイナリ形式またはイメージ形式を含む場合は、アプリはテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-491">If the package contains x64 or ARM binary or image types, it will fail the test.</span></span>

-   <span data-ttu-id="547f9-492">アプリのターゲット プロセッサ アーキテクチャが x64 プロセッサ タイプの場合、アプリ パッケージは、x64 バイナリ タイプまたはイメージ タイプのファイルを含む必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-492">If the Target Processor Architecture for your app is x64 processor type, the app package must contain x64 binary or image type files.</span></span> <span data-ttu-id="547f9-493">この場合は、パッケージに x86 ファイルを含めることもできますが、主なアプリ エクスペリエンスでは x64 バイナリを使ってください。</span><span class="sxs-lookup"><span data-stu-id="547f9-493">Note that in this case the package can also include x86 files, but the primary app experience should utilize the x64 binary.</span></span>

    <span data-ttu-id="547f9-494">ただし、パッケージが ARM バイナリ タイプまたはイメージ タイプのファイルを含む場合、または x86 バイナリ タイプまたはイメージ タイプのファイルのみを含む場合、パッケージはテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-494">However, if the package contains ARM binary or image type files, or only contains x86 binaries or image type files, it will fail the test.</span></span>

-   <span data-ttu-id="547f9-495">アプリのターゲット プロセッサ アーキテクチャが ARM プロセッサ タイプの場合、アプリ パッケージは、ARM バイナリ タイプまたはイメージ タイプのファイルのみを含む必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-495">If the Target Processor Architecture for your app is ARM processor type, the app package must only contain ARM binary or image type files.</span></span> <span data-ttu-id="547f9-496">パッケージが x64 または x86 バイナリ形式またはイメージ形式のファイルを含む場合は、パッケージはテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-496">If the package contains x64 or x86 binary or image type files, it will fail the test.</span></span>

### <a name="supported-directory-structure-test"></a><span data-ttu-id="547f9-497">サポートされるディレクトリ構造のテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-497">Supported Directory Structure test</span></span>

<span data-ttu-id="547f9-498">アプリケーションがインストールの一部として MAX\-PATH より長いサブディレクトリを作成しないことを検証します。</span><span class="sxs-lookup"><span data-stu-id="547f9-498">Validates that applications are not creating subdirectories as part of installation that are longer than MAX\-PATH.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-499">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-499">Background</span></span>

<span data-ttu-id="547f9-500">OS コンポーネント (Trident、WWAHost など) は、ファイル システム パスの MAX\-PATH に内部的に制限され、長いパスでは正しく機能しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-500">OS components (including Trident, WWAHost, etc.) are internally limited to MAX\-PATH for file system paths and will not work correctly for longer paths.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-501">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-501">Test Details</span></span>

<span data-ttu-id="547f9-502">アプリのインストール ディレクトリ内のどのパスも MAX\-PATH を超えていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-502">Verifies that no path within the app install directory exceeds MAX\-PATH.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-503">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-503">Corrective Action</span></span>

<span data-ttu-id="547f9-504">短いディレクトリ構造やファイル名にします。</span><span class="sxs-lookup"><span data-stu-id="547f9-504">Use a shorter directory structure, and or file name.</span></span>

## <a name="resource-usage-test"></a><span data-ttu-id="547f9-505">リソース使用率テスト</span><span class="sxs-lookup"><span data-stu-id="547f9-505">Resource Usage test</span></span>

### <a name="winjs-background-task-test"></a><span data-ttu-id="547f9-506">WinJS バックグラウンド タスクのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-506">WinJS Background Task test</span></span>

<span data-ttu-id="547f9-507">WinJS バックグラウンド タスクのテストは、JavaScript アプリに適切な close ステートメントがあるため、アプリがバッテリを消費しないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="547f9-507">WinJS background task test ensures that JavaScript apps have the proper close statements so apps don’t consume battery.</span></span>

### <a name="background"></a><span data-ttu-id="547f9-508">背景</span><span class="sxs-lookup"><span data-stu-id="547f9-508">Background</span></span>

<span data-ttu-id="547f9-509">JavaScript のバックグラウンド タスクがあるアプリは、バックグラウンド タスクの最後のステートメントとして Close() を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-509">Apps that have JavaScript background tasks need to call Close() as the last statement in their background task.</span></span> <span data-ttu-id="547f9-510">これがないアプリの場合は、システムがコネクト スタンバイ モードに戻らないため、バッテリを消耗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="547f9-510">Apps that do not do this could keep the system from returning to connected standby mode and result in draining the battery.</span></span>

### <a name="test-details"></a><span data-ttu-id="547f9-511">テストの詳細</span><span class="sxs-lookup"><span data-stu-id="547f9-511">Test Details</span></span>

<span data-ttu-id="547f9-512">マニフェストで指定されたバックグラウンド タスク ファイルがアプリにない場合、テストに合格します。</span><span class="sxs-lookup"><span data-stu-id="547f9-512">If the app does not have a background task file specified in the manifest, the test will pass.</span></span> <span data-ttu-id="547f9-513">それ以外の場合は、テストはアプリ パッケージで指定された JavaScript バックグラウンド タスク ファイルを解析し、Close() ステートメントを探します。</span><span class="sxs-lookup"><span data-stu-id="547f9-513">Otherwise the test will parse the JavaScript background task file that is specified in the app package, and look for a Close() statement.</span></span> <span data-ttu-id="547f9-514">見つかった場合はテストに合格します。見つからない場合はテストに合格しません。</span><span class="sxs-lookup"><span data-stu-id="547f9-514">If found, the test will pass; otherwise the test will fail.</span></span>

### <a name="corrective-action"></a><span data-ttu-id="547f9-515">問題への対応</span><span class="sxs-lookup"><span data-stu-id="547f9-515">Corrective Action</span></span>

<span data-ttu-id="547f9-516">バックグラウンドの JavaScript コードを更新して、Close() を正しく呼び出します。</span><span class="sxs-lookup"><span data-stu-id="547f9-516">Update the background JavaScript code to call Close() correctly.</span></span>


## <a name="related-topics"></a><span data-ttu-id="547f9-517">関連トピック</span><span class="sxs-lookup"><span data-stu-id="547f9-517">Related topics</span></span>

* [<span data-ttu-id="547f9-518">Windows デスクトップ ブリッジ アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="547f9-518">Windows Desktop Bridge app tests</span></span>](windows-desktop-bridge-app-tests.md)
* [<span data-ttu-id="547f9-519">Microsoft Store ポリシー</span><span class="sxs-lookup"><span data-stu-id="547f9-519">Microsoft Store Policies</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn764944)
 
