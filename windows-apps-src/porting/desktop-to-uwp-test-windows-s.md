---
author: normesta
Description: "Windows 10 S をインストールせずにアプリの Windows 10 S 対応をテストできます。"
Search.Product: eADQiWindows 10XVcnh
title: "Windows アプリの Windows 10 S 対応をテストする"
ms.author: normesta
ms.date: 05/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10 S, UWP
ms.assetid: f45d8b14-02d1-42e1-98df-6c03ce397fd3
ms.openlocfilehash: 52cd0a7cadbedc3a843d6ce21ba5b985cfef4db8
ms.sourcegitcommit: 77bbd060f9253f2b03f0b9d74954c187bceb4a30
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="test-your-windows-app-for-windows-10-s"></a><span data-ttu-id="1ef84-104">Windows アプリの Windows 10 S 対応をテストする</span><span class="sxs-lookup"><span data-stu-id="1ef84-104">Test your Windows app for Windows 10 S</span></span>

<span data-ttu-id="1ef84-105">Windows アプリをテストして、Windows 10 S を実行するデバイスでそのアプリが正しく動作することを確認できます。実際、Windows ストアにアプリを公開する予定がある場合はこの作業を行わなければなりません。それがストア要件になっているためです。</span><span class="sxs-lookup"><span data-stu-id="1ef84-105">You can test your Windows app to ensure that it will operate correctly on devices that run Windows 10 S. In fact, if you plan to publish your app to the Windows Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="1ef84-106">アプリをテストするために、Windows 10 Pro を実行しているデバイスでは Device Guard コードの整合性ポリシーを適用できます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-106">To do test your app, you can apply a Device Guard Code Integrity policy on a device that is running Windows 10 Pro.</span></span> <span data-ttu-id="1ef84-107">このポリシーは、Windows 10 S で実行するために従う必要のある規則がアプリに適用されます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-107">This policy enforces the rules that apps must conform to in order to run on Windows 10 S.</span></span>

> [!IMPORTANT]
><span data-ttu-id="1ef84-108">これらのポリシーを仮想マシンに適用することをお勧めします。ただし、ローカル コンピューターに適用する場合は、ポリシーを適用する前に、このトピックの「次に、ポリシーをインストールしてシステムを再起動する」セクションに記載されているベスト プラクティスのガイダンスを確認してください。</span><span class="sxs-lookup"><span data-stu-id="1ef84-108">We recommend that you apply these policies to a virtual machine, but if you want to apply them to your local machine, make sure to review our best practice guidance in the "Next, install the policy and restart your system" section of this topic before you apply a policy.</span></span>

<span id="choose-policy" />
## <a name="first-download-the-policies-and-then-choose-one"></a><span data-ttu-id="1ef84-109">まず、ポリシーをダウンロードして 1 つを選択する</span><span class="sxs-lookup"><span data-stu-id="1ef84-109">First, download the policies and then choose one</span></span>

<span data-ttu-id="1ef84-110">Device Guard コード整合性ポリシーは、[こちら](https://go.microsoft.com/fwlink/?linkid=849018)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-110">Download the Device Guard Code Integrity policies [here](https://go.microsoft.com/fwlink/?linkid=849018).</span></span>

<span data-ttu-id="1ef84-111">次に、最も希望に合うものを 1 つ選びます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-111">Then, choose the one that makes the most sense to you.</span></span> <span data-ttu-id="1ef84-112">各ポリシーの概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-112">Here's summary of each policy.</span></span>

|<span data-ttu-id="1ef84-113">ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-113">Policy</span></span> |<span data-ttu-id="1ef84-114">適用</span><span class="sxs-lookup"><span data-stu-id="1ef84-114">Enforcement</span></span> |<span data-ttu-id="1ef84-115">署名用の証明書</span><span class="sxs-lookup"><span data-stu-id="1ef84-115">Signing certificate</span></span> |<span data-ttu-id="1ef84-116">ファイル名</span><span class="sxs-lookup"><span data-stu-id="1ef84-116">File name</span></span> |
|--|--|--|--|
|<span data-ttu-id="1ef84-117">監査モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-117">Audit mode policy</span></span> |<span data-ttu-id="1ef84-118">問題をログに記録/ブロックしない</span><span class="sxs-lookup"><span data-stu-id="1ef84-118">Logs issues / does not block</span></span> |<span data-ttu-id="1ef84-119">ストア</span><span class="sxs-lookup"><span data-stu-id="1ef84-119">Store</span></span> |<span data-ttu-id="1ef84-120">SiPolicy_Audit.p7b</span><span class="sxs-lookup"><span data-stu-id="1ef84-120">SiPolicy_Audit.p7b</span></span> |
|<span data-ttu-id="1ef84-121">実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-121">Production mode policy</span></span> |<span data-ttu-id="1ef84-122">〇</span><span class="sxs-lookup"><span data-stu-id="1ef84-122">Yes</span></span> |<span data-ttu-id="1ef84-123">ストア</span><span class="sxs-lookup"><span data-stu-id="1ef84-123">Store</span></span> |<span data-ttu-id="1ef84-124">SiPolicy_Enforced.p7b</span><span class="sxs-lookup"><span data-stu-id="1ef84-124">SiPolicy_Enforced.p7b</span></span> |
|<span data-ttu-id="1ef84-125">自己署名アプリを使用する実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-125">Product mode policy with self-signed apps</span></span> |<span data-ttu-id="1ef84-126">〇</span><span class="sxs-lookup"><span data-stu-id="1ef84-126">Yes</span></span> |<span data-ttu-id="1ef84-127">AppX テスト証明書</span><span class="sxs-lookup"><span data-stu-id="1ef84-127">AppX Test Cert</span></span>  |<span data-ttu-id="1ef84-128">SiPolicy_DevModeEx_Enforced.p7b</span><span class="sxs-lookup"><span data-stu-id="1ef84-128">SiPolicy_DevModeEx_Enforced.p7b</span></span> |

<span data-ttu-id="1ef84-129">監査モード ポリシーから開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1ef84-129">We recommend that you start with audit mode policy.</span></span> <span data-ttu-id="1ef84-130">コードの整合性イベント ログを確認し、その情報を使用してアプリを調整することができます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-130">You can review the Code Integrity Event Logs and use that information to help you make adjustments to your app.</span></span> <span data-ttu-id="1ef84-131">最終的なテストの準備ができたら、実稼働モード ポリシーを適用します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-131">Then, apply the Production mode policy when you're ready for final testing.</span></span>

<span data-ttu-id="1ef84-132">各ポリシーについて、もう少し詳しい情報を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-132">Here’s a bit more information about each policy.</span></span>

### <a name="audit-mode-policy"></a><span data-ttu-id="1ef84-133">監査モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-133">Audit mode policy</span></span>
<span data-ttu-id="1ef84-134">このモードでは、Windows 10 S でサポートされていないタスクがアプリで実行される場合も、そのアプリを実行できます。実稼働でブロックされる実行可能ファイルは、Windows によってコード整合性イベント ログに記録されます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-134">With this mode, your app runs even if it performs tasks that aren’t supported on Windows 10 S. Windows logs any executables that would have been blocked into the Code Integrity Event Logs.</span></span>

<span data-ttu-id="1ef84-135">これらのログを見つけるには、**[イベント ビューアー]** を開き、[アプリケーションとサービス ログ]、[Microsoft]、[Windows]、[CodeIntegrity]、[Operational] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-135">You can find those logs by opening the **Event Viewer**, and then browsing to this location: Application and Services Logs->Microsoft->Windows->CodeIntegrity->Operational.</span></span>

![コードの整合性イベント ログ](images/desktop-to-uwp/code-integrity-logs.png)


#### <a name="optional-find-specific-failure-points-in-the-call-stack"></a><span data-ttu-id="1ef84-137">(省略可能) 呼び出し履歴で特定の障害箇所を見つける</span><span class="sxs-lookup"><span data-stu-id="1ef84-137">(Optional) Find specific failure points in the call stack</span></span>
<span data-ttu-id="1ef84-138">呼び出し履歴でブロックに関する問題が発生している特定のポイントを見つけるには、次のレジストリ キーを追加してから、[カーネル モード デバッグ環境をセットアップ](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging)します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-138">To find specific points in the call stack where blocking issues occur, add this registry key, and then [set up a kernel-mode debugging environment](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging).</span></span>

|<span data-ttu-id="1ef84-139">キー</span><span class="sxs-lookup"><span data-stu-id="1ef84-139">Key</span></span>|<span data-ttu-id="1ef84-140">名前</span><span class="sxs-lookup"><span data-stu-id="1ef84-140">Name</span></span>|<span data-ttu-id="1ef84-141">種類</span><span class="sxs-lookup"><span data-stu-id="1ef84-141">Type</span></span>|<span data-ttu-id="1ef84-142">値</span><span class="sxs-lookup"><span data-stu-id="1ef84-142">Value</span></span>|
|--|---|--|--|
|<span data-ttu-id="1ef84-143">HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI</span><span class="sxs-lookup"><span data-stu-id="1ef84-143">HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI</span></span>| <span data-ttu-id="1ef84-144">DebugFlags</span><span class="sxs-lookup"><span data-stu-id="1ef84-144">DebugFlags</span></span> |<span data-ttu-id="1ef84-145">REG_DWORD</span><span class="sxs-lookup"><span data-stu-id="1ef84-145">REG_DWORD</span></span> | <span data-ttu-id="1ef84-146">1</span><span class="sxs-lookup"><span data-stu-id="1ef84-146">1</span></span> |


![レジストリ設定](images/desktop-to-uwp/ci-debug-setting.png)

### <a name="production-mode-policy"></a><span data-ttu-id="1ef84-148">実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-148">Production mode policy</span></span>
<span data-ttu-id="1ef84-149">このポリシーでは、Windows 10 S に合致するコード整合性規則が適用され、Windows 10 S での実行をシミュレートできます。これは最も厳しいポリシーであり、最終的な実稼働テストに適しています。</span><span class="sxs-lookup"><span data-stu-id="1ef84-149">This policy enforces code integrity rules that match Windows 10 S so that you can simulate running on Windows 10 S. This is the strictest policy, and it is great for final production testing.</span></span> <span data-ttu-id="1ef84-150">このモードでは、アプリへの制限が、ユーザーのデバイスでの制限と同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="1ef84-150">In this mode, your app is subject to the same restrictions as it would be subject to on a user's device.</span></span> <span data-ttu-id="1ef84-151">このモードを使用するには、Windows ストアによるアプリへの署名が必要です。</span><span class="sxs-lookup"><span data-stu-id="1ef84-151">To use this mode, your app must be signed by the Windows Store.</span></span>

### <a name="production-mode-policy-with-self-signed-apps"></a><span data-ttu-id="1ef84-152">自己署名アプリを使用する実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="1ef84-152">Production mode policy with self-signed apps</span></span>
<span data-ttu-id="1ef84-153">このモードは、実稼働モード ポリシーに似ていますが、zip ファイルに含まれているテスト証明書で署名されているアプリを実行できる点が異なります。</span><span class="sxs-lookup"><span data-stu-id="1ef84-153">This mode is similar to the Production mode policy, but it also allows things to run that are signed with the test certificate that is included in the zip file.</span></span> <span data-ttu-id="1ef84-154">この zip ファイル内にある **AppxTestRootAgency** フォルダーに含まれる PFX ファイルをインストールします。</span><span class="sxs-lookup"><span data-stu-id="1ef84-154">Install the PFX file that is included in the **AppxTestRootAgency** folder of this zip file.</span></span> <span data-ttu-id="1ef84-155">次に、それを使用してアプリに署名します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-155">Then, sign your app with it.</span></span> <span data-ttu-id="1ef84-156">この方法では、ストアによる署名を必要としないため、迅速に反復できます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-156">That way, you can quickly iterate without requiring Store signing.</span></span>

<span data-ttu-id="1ef84-157">証明書の発行元名がアプリの発行者名と一致する必要があるため、**Identity** 要素の **Publisher** 属性の値を "CN=Appx Test Root Agency Ex" に一時的に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1ef84-157">Because the publisher name of your certificate must match the publisher name of your app, you'll have to temporarily change the value of the **Identity** element's **Publisher** attribute to "CN=Appx Test Root Agency Ex".</span></span> <span data-ttu-id="1ef84-158">テストの完了後に、この属性を元の値に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-158">You can change that attribute back to it's original value after you've completed your tests.</span></span>

## <a name="next-install-the-policy-and-restart-your-system"></a><span data-ttu-id="1ef84-159">次に、ポリシーをインストールしてシステムを再起動する</span><span class="sxs-lookup"><span data-stu-id="1ef84-159">Next, install the policy and restart your system</span></span>

<span data-ttu-id="1ef84-160">これらのポリシーは起動エラーを招く可能性があるため、仮想マシンに適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1ef84-160">We recommend that you apply these policies to a virtual machine because these policies might lead to boot failures.</span></span> <span data-ttu-id="1ef84-161">エラーが発生するのは、ドライバーを含めて Windows ストアによって署名されていないコードの実行がポリシーによってブロックされるためです。</span><span class="sxs-lookup"><span data-stu-id="1ef84-161">That's because these policies block the execution of code that isn't signed by the Windows Store, including drivers.</span></span>

<span data-ttu-id="1ef84-162">ローカル コンピューターにこれらのポリシーを適用する場合は、監査モード ポリシーから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1ef84-162">If you want to apply these policies to your local machine, it's best to start with the Audit mode policy.</span></span> <span data-ttu-id="1ef84-163">このポリシーでは、適用されたポリシーで重要なコードがブロックされないことをコード整合性イベント ログで確認できます。</span><span class="sxs-lookup"><span data-stu-id="1ef84-163">With this policy, you can review the Code Integrity Event Logs to ensure that nothing critical would be blocked in an enforced policy.</span></span>

<span data-ttu-id="1ef84-164">ポリシーを適用する準備ができたら、選択したポリシーに対応する .P7B ファイルを見つけて、**SIPolicy.P7B** という名前に変更したうえで、このファイルをシステム上の **C:\Windows\System32\CodeIntegrity\** に保存します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-164">When you're ready to apply a policy, find the .P7B file for the policy that you chose, rename it to **SIPolicy.P7B**, and then save that file to this location on your system: **C:\Windows\System32\CodeIntegrity\**.</span></span>

<span data-ttu-id="1ef84-165">システムを再起動します。</span><span class="sxs-lookup"><span data-stu-id="1ef84-165">Then, restart your system.</span></span>

## <a name="next-steps"></a><span data-ttu-id="1ef84-166">次のステップ</span><span class="sxs-lookup"><span data-stu-id="1ef84-166">Next steps</span></span>

**<span data-ttu-id="1ef84-167">App Consult Team が投稿した詳細なブログ記事を確認する</span><span class="sxs-lookup"><span data-stu-id="1ef84-167">Review a detailed blog article that was posted by our App Consult Team</span></span>**

<span data-ttu-id="1ef84-168">[Windows 10 S でのデスクトップ ブリッジを使用した従来のデスクトップ アプリケーションの移植とテストに関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1ef84-168">See [Porting and testing your classic desktop applications on Windows 10 S with the Desktop Bridge](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/).</span></span>

**<span data-ttu-id="1ef84-169">Windows S でのテストを容易にするツールについて理解する</span><span class="sxs-lookup"><span data-stu-id="1ef84-169">Learn about tools that make it easier to test for Windows S</span></span>**

<span data-ttu-id="1ef84-170">[APPX のアンパッケージ、変更、再パッケージ、署名に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1ef84-170">See [Unpackage, modify, repackage, sign an APPX](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/).</span></span>

**<span data-ttu-id="1ef84-171">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="1ef84-171">Find answers to specific questions</span></span>**

<span data-ttu-id="1ef84-172">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="1ef84-172">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="1ef84-173">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="1ef84-173">Give feedback about this article</span></span>**

<span data-ttu-id="1ef84-174">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="1ef84-174">Use the comments section below.</span></span>
