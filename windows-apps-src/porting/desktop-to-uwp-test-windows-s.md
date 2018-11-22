---
author: normesta
Description: Test your app for Windows 10 in S mode.
Search.Product: eADQiWindows 10XVcnh
title: Windows アプリの Windows 10 S 対応のテスト
ms.author: normesta
ms.date: 05/11/2017
ms.topic: article
keywords: windows 10 S, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3307506c5cf62d04cd19fbc302ad14bfcedd0045
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7571729"
---
# <a name="test-your-windows-app-for-windows-10-in-s-mode"></a><span data-ttu-id="24d50-103">Windows アプリの S モードの Windows 10 をテストする</span><span class="sxs-lookup"><span data-stu-id="24d50-103">Test your Windows app for Windows 10 in S mode</span></span>

<span data-ttu-id="24d50-104">Windows アプリをテストして、S モードの Windows10 を実行するデバイスで正しく動作することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="24d50-104">You can test your Windows app to ensure that it will operate correctly on devices that run Windows 10 in S mode.</span></span> <span data-ttu-id="24d50-105">実際には、Microsoft Store にアプリを公開する場合、これはストア要件のため実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24d50-105">In fact, if you plan to publish your app to the Microsoft Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="24d50-106">アプリをテストするために、Windows 10 Pro を実行しているデバイスでは Device Guard コードの整合性ポリシーを適用できます。</span><span class="sxs-lookup"><span data-stu-id="24d50-106">To test your app, you can apply a Device Guard Code Integrity policy on a device that is running Windows 10 Pro.</span></span>

> [!NOTE]
> <span data-ttu-id="24d50-107">Device Guard コードの整合性ポリシーを適用するデバイスでは、Windows 10 Creators Edition (10.0 ビルド 15063) 以降が実行されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="24d50-107">The device on which you apply the Device Guard Code Integrity policy must be running Windows 10 Creators Edition (10.0; Build 15063) or later.</span></span>

<span data-ttu-id="24d50-108">Device Guard コードの整合性ポリシーは、Windows 10 S で実行するために従う必要のある規則がアプリに適用されます。</span><span class="sxs-lookup"><span data-stu-id="24d50-108">The Device Guard Code Integrity policy enforces the rules that apps must conform to in order to run on Windows 10 S.</span></span>

> [!IMPORTANT]
><span data-ttu-id="24d50-109">これらのポリシーを仮想マシンに適用することをお勧めします。ただし、ローカル コンピューターに適用する場合は、ポリシーを適用する前に、このトピックの「次に、ポリシーをインストールしてシステムを再起動する」セクションに記載されているベスト プラクティスのガイダンスを確認してください。</span><span class="sxs-lookup"><span data-stu-id="24d50-109">We recommend that you apply these policies to a virtual machine, but if you want to apply them to your local machine, make sure to review our best practice guidance in the "Next, install the policy and restart your system" section of this topic before you apply a policy.</span></span>

<a id="choose-policy" />

## <a name="first-download-the-policies-and-then-choose-one"></a><span data-ttu-id="24d50-110">まず、ポリシーをダウンロードして 1 つを選択する</span><span class="sxs-lookup"><span data-stu-id="24d50-110">First, download the policies and then choose one</span></span>

<span data-ttu-id="24d50-111">Device Guard コード整合性ポリシーは、[こちら](https://go.microsoft.com/fwlink/?linkid=849018)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="24d50-111">Download the Device Guard Code Integrity policies [here](https://go.microsoft.com/fwlink/?linkid=849018).</span></span>

<span data-ttu-id="24d50-112">次に、最も希望に合うものを 1 つ選びます。</span><span class="sxs-lookup"><span data-stu-id="24d50-112">Then, choose the one that makes the most sense to you.</span></span> <span data-ttu-id="24d50-113">各ポリシーの概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="24d50-113">Here's summary of each policy.</span></span>

|<span data-ttu-id="24d50-114">ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-114">Policy</span></span> |<span data-ttu-id="24d50-115">適用</span><span class="sxs-lookup"><span data-stu-id="24d50-115">Enforcement</span></span> |<span data-ttu-id="24d50-116">署名用の証明書</span><span class="sxs-lookup"><span data-stu-id="24d50-116">Signing certificate</span></span> |<span data-ttu-id="24d50-117">ファイル名</span><span class="sxs-lookup"><span data-stu-id="24d50-117">File name</span></span> |
|--|--|--|--|
|<span data-ttu-id="24d50-118">監査モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-118">Audit mode policy</span></span> |<span data-ttu-id="24d50-119">問題をログに記録/ブロックしない</span><span class="sxs-lookup"><span data-stu-id="24d50-119">Logs issues / does not block</span></span> |<span data-ttu-id="24d50-120">ストア</span><span class="sxs-lookup"><span data-stu-id="24d50-120">Store</span></span> |<span data-ttu-id="24d50-121">SiPolicy_Audit.p7b</span><span class="sxs-lookup"><span data-stu-id="24d50-121">SiPolicy_Audit.p7b</span></span> |
|<span data-ttu-id="24d50-122">実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-122">Production mode policy</span></span> |<span data-ttu-id="24d50-123">はい</span><span class="sxs-lookup"><span data-stu-id="24d50-123">Yes</span></span> |<span data-ttu-id="24d50-124">ストア</span><span class="sxs-lookup"><span data-stu-id="24d50-124">Store</span></span> |<span data-ttu-id="24d50-125">SiPolicy_Enforced.p7b</span><span class="sxs-lookup"><span data-stu-id="24d50-125">SiPolicy_Enforced.p7b</span></span> |
|<span data-ttu-id="24d50-126">自己署名アプリを使用する実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-126">Product mode policy with self-signed apps</span></span> |<span data-ttu-id="24d50-127">はい</span><span class="sxs-lookup"><span data-stu-id="24d50-127">Yes</span></span> |<span data-ttu-id="24d50-128">AppX テスト証明書</span><span class="sxs-lookup"><span data-stu-id="24d50-128">AppX Test Cert</span></span>  |<span data-ttu-id="24d50-129">SiPolicy_DevModeEx_Enforced.p7b</span><span class="sxs-lookup"><span data-stu-id="24d50-129">SiPolicy_DevModeEx_Enforced.p7b</span></span> |

<span data-ttu-id="24d50-130">監査モード ポリシーから開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24d50-130">We recommend that you start with audit mode policy.</span></span> <span data-ttu-id="24d50-131">コードの整合性イベント ログを確認し、その情報を使用してアプリを調整することができます。</span><span class="sxs-lookup"><span data-stu-id="24d50-131">You can review the Code Integrity Event Logs and use that information to help you make adjustments to your app.</span></span> <span data-ttu-id="24d50-132">最終的なテストの準備ができたら、実稼働モード ポリシーを適用します。</span><span class="sxs-lookup"><span data-stu-id="24d50-132">Then, apply the Production mode policy when you're ready for final testing.</span></span>

<span data-ttu-id="24d50-133">各ポリシーについて、もう少し詳しい情報を次に示します。</span><span class="sxs-lookup"><span data-stu-id="24d50-133">Here’s a bit more information about each policy.</span></span>

### <a name="audit-mode-policy"></a><span data-ttu-id="24d50-134">監査モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-134">Audit mode policy</span></span>
<span data-ttu-id="24d50-135">このモードでは、Windows 10 S でサポートされていないタスクがアプリで実行される場合も、そのアプリを実行できます。実稼働でブロックされる実行可能ファイルは、Windows によってコード整合性イベント ログに記録されます。</span><span class="sxs-lookup"><span data-stu-id="24d50-135">With this mode, your app runs even if it performs tasks that aren’t supported on Windows 10 S. Windows logs any executables that would have been blocked into the Code Integrity Event Logs.</span></span>

<span data-ttu-id="24d50-136">これらのログを見つけるには、**[イベント ビューアー]** を開き、[アプリケーションとサービス ログ]、[Microsoft]、[Windows]、[CodeIntegrity]、[Operational] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="24d50-136">You can find those logs by opening the **Event Viewer**, and then browsing to this location: Application and Services Logs->Microsoft->Windows->CodeIntegrity->Operational.</span></span>

![コードの整合性イベント ログ](images/desktop-to-uwp/code-integrity-logs.png)

<span data-ttu-id="24d50-138">このモードは安全であり、システムの起動を妨げません。</span><span class="sxs-lookup"><span data-stu-id="24d50-138">This mode is safe and it won't prevent your system from starting.</span></span>

#### <a name="optional-find-specific-failure-points-in-the-call-stack"></a><span data-ttu-id="24d50-139">(省略可能) 呼び出し履歴で特定の障害箇所を見つける</span><span class="sxs-lookup"><span data-stu-id="24d50-139">(Optional) Find specific failure points in the call stack</span></span>
<span data-ttu-id="24d50-140">呼び出し履歴でブロックに関する問題が発生している特定のポイントを見つけるには、次のレジストリ キーを追加してから、[カーネル モード デバッグ環境をセットアップ](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging)します。</span><span class="sxs-lookup"><span data-stu-id="24d50-140">To find specific points in the call stack where blocking issues occur, add this registry key, and then [set up a kernel-mode debugging environment](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging).</span></span>

|<span data-ttu-id="24d50-141">キー</span><span class="sxs-lookup"><span data-stu-id="24d50-141">Key</span></span>|<span data-ttu-id="24d50-142">名前</span><span class="sxs-lookup"><span data-stu-id="24d50-142">Name</span></span>|<span data-ttu-id="24d50-143">型</span><span class="sxs-lookup"><span data-stu-id="24d50-143">Type</span></span>|<span data-ttu-id="24d50-144">値</span><span class="sxs-lookup"><span data-stu-id="24d50-144">Value</span></span>|
|--|---|--|--|
|<span data-ttu-id="24d50-145">HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI</span><span class="sxs-lookup"><span data-stu-id="24d50-145">HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI</span></span>| <span data-ttu-id="24d50-146">DebugFlags</span><span class="sxs-lookup"><span data-stu-id="24d50-146">DebugFlags</span></span> |<span data-ttu-id="24d50-147">REG_DWORD</span><span class="sxs-lookup"><span data-stu-id="24d50-147">REG_DWORD</span></span> | <span data-ttu-id="24d50-148">1</span><span class="sxs-lookup"><span data-stu-id="24d50-148">1</span></span> |


![レジストリ設定](images/desktop-to-uwp/ci-debug-setting.png)

### <a name="production-mode-policy"></a><span data-ttu-id="24d50-150">実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-150">Production mode policy</span></span>
<span data-ttu-id="24d50-151">このポリシーでは、Windows 10 S に合致するコード整合性規則が適用され、Windows 10 S での実行をシミュレートできます。これは最も厳しいポリシーであり、最終的な実稼働テストに適しています。</span><span class="sxs-lookup"><span data-stu-id="24d50-151">This policy enforces code integrity rules that match Windows 10 S so that you can simulate running on Windows 10 S. This is the strictest policy, and it is great for final production testing.</span></span> <span data-ttu-id="24d50-152">このモードでは、アプリへの制限が、ユーザーのデバイスでの制限と同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="24d50-152">In this mode, your app is subject to the same restrictions as it would be subject to on a user's device.</span></span> <span data-ttu-id="24d50-153">このモードを使用するには、Microsoft Store によるアプリへの署名が必要です。</span><span class="sxs-lookup"><span data-stu-id="24d50-153">To use this mode, your app must be signed by the Microsoft Store.</span></span>

### <a name="production-mode-policy-with-self-signed-apps"></a><span data-ttu-id="24d50-154">自己署名アプリを使用する実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="24d50-154">Production mode policy with self-signed apps</span></span>
<span data-ttu-id="24d50-155">このモードは、実稼働モード ポリシーに似ていますが、zip ファイルに含まれているテスト証明書で署名されているアプリを実行できる点が異なります。</span><span class="sxs-lookup"><span data-stu-id="24d50-155">This mode is similar to the Production mode policy, but it also allows things to run that are signed with the test certificate that is included in the zip file.</span></span> <span data-ttu-id="24d50-156">この zip ファイル内にある **AppxTestRootAgency** フォルダーに含まれる PFX ファイルをインストールします。</span><span class="sxs-lookup"><span data-stu-id="24d50-156">Install the PFX file that is included in the **AppxTestRootAgency** folder of this zip file.</span></span> <span data-ttu-id="24d50-157">次に、それを使用してアプリに署名します。</span><span class="sxs-lookup"><span data-stu-id="24d50-157">Then, sign your app with it.</span></span> <span data-ttu-id="24d50-158">この方法では、ストアによる署名を必要としないため、迅速に反復できます。</span><span class="sxs-lookup"><span data-stu-id="24d50-158">That way, you can quickly iterate without requiring Store signing.</span></span>

<span data-ttu-id="24d50-159">証明書の発行元名がアプリの発行者名と一致する必要があるため、**Identity** 要素の **Publisher** 属性の値を "CN=Appx Test Root Agency Ex" に一時的に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24d50-159">Because the publisher name of your certificate must match the publisher name of your app, you'll have to temporarily change the value of the **Identity** element's **Publisher** attribute to "CN=Appx Test Root Agency Ex".</span></span> <span data-ttu-id="24d50-160">テストの完了後に、この属性を元の値に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="24d50-160">You can change that attribute back to it's original value after you've completed your tests.</span></span>

## <a name="next-install-the-policy-and-restart-your-system"></a><span data-ttu-id="24d50-161">次に、ポリシーをインストールしてシステムを再起動する</span><span class="sxs-lookup"><span data-stu-id="24d50-161">Next, install the policy and restart your system</span></span>

<span data-ttu-id="24d50-162">これらのポリシーは起動エラーを招く可能性があるため、仮想マシンに適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24d50-162">We recommend that you apply these policies to a virtual machine because these policies might lead to boot failures.</span></span> <span data-ttu-id="24d50-163">エラーが発生するのは、ドライバーを含めて Microsoft Store によって署名されていないコードの実行がポリシーによってブロックされるためです。</span><span class="sxs-lookup"><span data-stu-id="24d50-163">That's because these policies block the execution of code that isn't signed by the Microsoft Store, including drivers.</span></span>

<span data-ttu-id="24d50-164">ローカル コンピューターにこれらのポリシーを適用する場合は、監査モード ポリシーから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24d50-164">If you want to apply these policies to your local machine, it's best to start with the Audit mode policy.</span></span> <span data-ttu-id="24d50-165">このポリシーでは、適用されたポリシーで重要なコードがブロックされないことをコード整合性イベント ログで確認できます。</span><span class="sxs-lookup"><span data-stu-id="24d50-165">With this policy, you can review the Code Integrity Event Logs to ensure that nothing critical would be blocked in an enforced policy.</span></span>

<span data-ttu-id="24d50-166">ポリシーを適用する準備ができたら、選択したポリシーに対応する .P7B ファイルを見つけて、**SIPolicy.P7B** という名前に変更したうえで、このファイルをシステム上の **C:\Windows\System32\CodeIntegrity\\** に保存します。</span><span class="sxs-lookup"><span data-stu-id="24d50-166">When you're ready to apply a policy, find the .P7B file for the policy that you chose, rename it to **SIPolicy.P7B**, and then save that file to this location on your system: **C:\Windows\System32\CodeIntegrity\\**.</span></span>

<span data-ttu-id="24d50-167">システムを再起動します。</span><span class="sxs-lookup"><span data-stu-id="24d50-167">Then, restart your system.</span></span>

>[!NOTE]
><span data-ttu-id="24d50-168">システムからポリシーを削除するには、.P7B ファイルを削除してからシステムを再起動します。</span><span class="sxs-lookup"><span data-stu-id="24d50-168">To remove a policy from your system, delete the .P7B file and then restart your system.</span></span>

## <a name="next-steps"></a><span data-ttu-id="24d50-169">次のステップ</span><span class="sxs-lookup"><span data-stu-id="24d50-169">Next steps</span></span>

**<span data-ttu-id="24d50-170">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="24d50-170">Find answers to your questions</span></span>**

<span data-ttu-id="24d50-171">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="24d50-171">Have questions?</span></span> <span data-ttu-id="24d50-172">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="24d50-172">Ask us on Stack Overflow.</span></span> <span data-ttu-id="24d50-173">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="24d50-173">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="24d50-174">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="24d50-174">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="24d50-175">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="24d50-175">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="24d50-176">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24d50-176">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

**<span data-ttu-id="24d50-177">App Consult Team が投稿した詳細なブログ記事を確認する</span><span class="sxs-lookup"><span data-stu-id="24d50-177">Review a detailed blog article that was posted by our App Consult Team</span></span>**

<span data-ttu-id="24d50-178">[Windows 10 S でのデスクトップ ブリッジを使用した従来のデスクトップ アプリケーションの移植とテストに関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24d50-178">See [Porting and testing your classic desktop applications on Windows 10 S with the Desktop Bridge](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/).</span></span>

**<span data-ttu-id="24d50-179">S モードの Windows10 でのテストを容易にするツールについて理解する</span><span class="sxs-lookup"><span data-stu-id="24d50-179">Learn about tools that make it easier to test for Windows in S Mode</span></span>**

<span data-ttu-id="24d50-180">[APPX のアンパッケージ、変更、再パッケージ、署名に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24d50-180">See [Unpackage, modify, repackage, sign an APPX](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/).</span></span>
