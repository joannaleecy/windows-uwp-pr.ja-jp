---
Description: Windows 10 用のモードでアプリをテストします。
Search.Product: eADQiWindows 10XVcnh
title: Windows アプリの Windows 10 S 対応のテスト
ms.date: 05/11/2017
ms.topic: article
keywords: Windows 10 S, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cf442da9344f37525bf3c17e4a62a319b9c04044
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655947"
---
# <a name="test-your-windows-app-for-windows-10-in-s-mode"></a><span data-ttu-id="2dd78-104">Windows アプリの S モードの Windows 10 をテストする</span><span class="sxs-lookup"><span data-stu-id="2dd78-104">Test your Windows app for Windows 10 in S mode</span></span>

<span data-ttu-id="2dd78-105">Windows アプリをテストして、S モードの Windows 10 を実行するデバイスで正しく動作することを確認できます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-105">You can test your Windows app to ensure that it will operate correctly on devices that run Windows 10 in S mode.</span></span> <span data-ttu-id="2dd78-106">実際には、Microsoft Store にアプリを公開する場合、これはストア要件のため実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dd78-106">In fact, if you plan to publish your app to the Microsoft Store, you must do this because it is a store requirement.</span></span> <span data-ttu-id="2dd78-107">アプリをテストするために、Windows 10 Pro を実行しているデバイスでは Device Guard コードの整合性ポリシーを適用できます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-107">To test your app, you can apply a Device Guard Code Integrity policy on a device that is running Windows 10 Pro.</span></span>

> [!NOTE]
> <span data-ttu-id="2dd78-108">Device Guard コードの整合性ポリシーを適用するデバイスでは、Windows 10 Creators Edition (10.0 ビルド 15063) 以降が実行されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dd78-108">The device on which you apply the Device Guard Code Integrity policy must be running Windows 10 Creators Edition (10.0; Build 15063) or later.</span></span>

<span data-ttu-id="2dd78-109">Device Guard コードの整合性ポリシーは、Windows 10 S で実行するために従う必要のある規則がアプリに適用されます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-109">The Device Guard Code Integrity policy enforces the rules that apps must conform to in order to run on Windows 10 S.</span></span>

> [!IMPORTANT]
><span data-ttu-id="2dd78-110">これらのポリシーを仮想マシンに適用することをお勧めします。ただし、ローカル コンピューターに適用する場合は、ポリシーを適用する前に、このトピックの「次に、ポリシーをインストールしてシステムを再起動する」セクションに記載されているベスト プラクティスのガイダンスを確認してください。</span><span class="sxs-lookup"><span data-stu-id="2dd78-110">We recommend that you apply these policies to a virtual machine, but if you want to apply them to your local machine, make sure to review our best practice guidance in the "Next, install the policy and restart your system" section of this topic before you apply a policy.</span></span>

<a id="choose-policy" />

## <a name="first-download-the-policies-and-then-choose-one"></a><span data-ttu-id="2dd78-111">まず、ポリシーをダウンロードして 1 つを選択する</span><span class="sxs-lookup"><span data-stu-id="2dd78-111">First, download the policies and then choose one</span></span>

<span data-ttu-id="2dd78-112">Device Guard コード整合性ポリシーは、[こちら](https://go.microsoft.com/fwlink/?linkid=849018)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-112">Download the Device Guard Code Integrity policies [here](https://go.microsoft.com/fwlink/?linkid=849018).</span></span>

<span data-ttu-id="2dd78-113">次に、最も希望に合うものを 1 つ選びます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-113">Then, choose the one that makes the most sense to you.</span></span> <span data-ttu-id="2dd78-114">各ポリシーの概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-114">Here's summary of each policy.</span></span>

|<span data-ttu-id="2dd78-115">ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-115">Policy</span></span> |<span data-ttu-id="2dd78-116">強制</span><span class="sxs-lookup"><span data-stu-id="2dd78-116">Enforcement</span></span> |<span data-ttu-id="2dd78-117">署名用の証明書</span><span class="sxs-lookup"><span data-stu-id="2dd78-117">Signing certificate</span></span> |<span data-ttu-id="2dd78-118">ファイル名</span><span class="sxs-lookup"><span data-stu-id="2dd78-118">File name</span></span> |
|--|--|--|--|
|<span data-ttu-id="2dd78-119">監査モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-119">Audit mode policy</span></span> |<span data-ttu-id="2dd78-120">問題をログに記録/ブロックしない</span><span class="sxs-lookup"><span data-stu-id="2dd78-120">Logs issues / does not block</span></span> |<span data-ttu-id="2dd78-121">ストア</span><span class="sxs-lookup"><span data-stu-id="2dd78-121">Store</span></span> |<span data-ttu-id="2dd78-122">SiPolicy_Audit.p7b</span><span class="sxs-lookup"><span data-stu-id="2dd78-122">SiPolicy_Audit.p7b</span></span> |
|<span data-ttu-id="2dd78-123">実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-123">Production mode policy</span></span> |<span data-ttu-id="2dd78-124">〇</span><span class="sxs-lookup"><span data-stu-id="2dd78-124">Yes</span></span> |<span data-ttu-id="2dd78-125">ストア</span><span class="sxs-lookup"><span data-stu-id="2dd78-125">Store</span></span> |<span data-ttu-id="2dd78-126">SiPolicy_Enforced.p7b</span><span class="sxs-lookup"><span data-stu-id="2dd78-126">SiPolicy_Enforced.p7b</span></span> |
|<span data-ttu-id="2dd78-127">自己署名アプリを使用する実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-127">Product mode policy with self-signed apps</span></span> |<span data-ttu-id="2dd78-128">〇</span><span class="sxs-lookup"><span data-stu-id="2dd78-128">Yes</span></span> |<span data-ttu-id="2dd78-129">AppX テスト証明書</span><span class="sxs-lookup"><span data-stu-id="2dd78-129">AppX Test Cert</span></span>  |<span data-ttu-id="2dd78-130">SiPolicy_DevModeEx_Enforced.p7b</span><span class="sxs-lookup"><span data-stu-id="2dd78-130">SiPolicy_DevModeEx_Enforced.p7b</span></span> |

<span data-ttu-id="2dd78-131">監査モード ポリシーから開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2dd78-131">We recommend that you start with audit mode policy.</span></span> <span data-ttu-id="2dd78-132">コードの整合性イベント ログを確認し、その情報を使用してアプリを調整することができます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-132">You can review the Code Integrity Event Logs and use that information to help you make adjustments to your app.</span></span> <span data-ttu-id="2dd78-133">最終的なテストの準備ができたら、実稼働モード ポリシーを適用します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-133">Then, apply the Production mode policy when you're ready for final testing.</span></span>

<span data-ttu-id="2dd78-134">各ポリシーについて、もう少し詳しい情報を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-134">Here’s a bit more information about each policy.</span></span>

### <a name="audit-mode-policy"></a><span data-ttu-id="2dd78-135">監査モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-135">Audit mode policy</span></span>
<span data-ttu-id="2dd78-136">このモードでは、Windows 10 S でサポートされていないタスクがアプリで実行される場合も、そのアプリを実行できます。実稼働でブロックされる実行可能ファイルは、Windows によってコード整合性イベント ログに記録されます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-136">With this mode, your app runs even if it performs tasks that aren’t supported on Windows 10 S. Windows logs any executables that would have been blocked into the Code Integrity Event Logs.</span></span>

<span data-ttu-id="2dd78-137">開いてこれらのログを見つけることができます、**イベント ビューアー**、し、この場所に移動します。アプリケーションとサービス ログは、Microsoft->-> Windows CodeIntegrity->-> 運用します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-137">You can find those logs by opening the **Event Viewer**, and then browsing to this location: Application and Services Logs->Microsoft->Windows->CodeIntegrity->Operational.</span></span>

![コードの整合性イベント ログ](images/desktop-to-uwp/code-integrity-logs.png)

<span data-ttu-id="2dd78-139">このモードは安全であり、システムの起動を妨げません。</span><span class="sxs-lookup"><span data-stu-id="2dd78-139">This mode is safe and it won't prevent your system from starting.</span></span>

#### <a name="optional-find-specific-failure-points-in-the-call-stack"></a><span data-ttu-id="2dd78-140">(省略可能) 呼び出し履歴で特定の障害箇所を見つける</span><span class="sxs-lookup"><span data-stu-id="2dd78-140">(Optional) Find specific failure points in the call stack</span></span>
<span data-ttu-id="2dd78-141">呼び出し履歴でブロックに関する問題が発生している特定のポイントを見つけるには、次のレジストリ キーを追加してから、[カーネル モード デバッグ環境をセットアップ](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging)します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-141">To find specific points in the call stack where blocking issues occur, add this registry key, and then [set up a kernel-mode debugging environment](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging).</span></span>

|<span data-ttu-id="2dd78-142">Key</span><span class="sxs-lookup"><span data-stu-id="2dd78-142">Key</span></span>|<span data-ttu-id="2dd78-143">名前</span><span class="sxs-lookup"><span data-stu-id="2dd78-143">Name</span></span>|<span data-ttu-id="2dd78-144">種類</span><span class="sxs-lookup"><span data-stu-id="2dd78-144">Type</span></span>|<span data-ttu-id="2dd78-145">値</span><span class="sxs-lookup"><span data-stu-id="2dd78-145">Value</span></span>|
|--|---|--|--|
|<span data-ttu-id="2dd78-146">HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI</span><span class="sxs-lookup"><span data-stu-id="2dd78-146">HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI</span></span>| <span data-ttu-id="2dd78-147">DebugFlags</span><span class="sxs-lookup"><span data-stu-id="2dd78-147">DebugFlags</span></span> |<span data-ttu-id="2dd78-148">REG_DWORD</span><span class="sxs-lookup"><span data-stu-id="2dd78-148">REG_DWORD</span></span> | <span data-ttu-id="2dd78-149">1</span><span class="sxs-lookup"><span data-stu-id="2dd78-149">1</span></span> |


![レジストリ設定](images/desktop-to-uwp/ci-debug-setting.png)

### <a name="production-mode-policy"></a><span data-ttu-id="2dd78-151">実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-151">Production mode policy</span></span>
<span data-ttu-id="2dd78-152">このポリシーでは、Windows 10 S に合致する整合性規則が適用され、Windows 10 S での実行をシミュレートできます。これは最も厳しいポリシーであり、最終的な実稼働テストに適しています。</span><span class="sxs-lookup"><span data-stu-id="2dd78-152">This policy enforces code integrity rules that match Windows 10 S so that you can simulate running on Windows 10 S. This is the strictest policy, and it is great for final production testing.</span></span> <span data-ttu-id="2dd78-153">このモードでは、アプリへの制限が、ユーザーのデバイスでの制限と同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dd78-153">In this mode, your app is subject to the same restrictions as it would be subject to on a user's device.</span></span> <span data-ttu-id="2dd78-154">このモードを使用するには、Microsoft Store によるアプリへの署名が必要です。</span><span class="sxs-lookup"><span data-stu-id="2dd78-154">To use this mode, your app must be signed by the Microsoft Store.</span></span>

### <a name="production-mode-policy-with-self-signed-apps"></a><span data-ttu-id="2dd78-155">自己署名アプリを使用する実稼働モード ポリシー</span><span class="sxs-lookup"><span data-stu-id="2dd78-155">Production mode policy with self-signed apps</span></span>
<span data-ttu-id="2dd78-156">このモードは、実稼働モード ポリシーに似ていますが、zip ファイルに含まれているテスト証明書で署名されているアプリを実行できる点が異なります。</span><span class="sxs-lookup"><span data-stu-id="2dd78-156">This mode is similar to the Production mode policy, but it also allows things to run that are signed with the test certificate that is included in the zip file.</span></span> <span data-ttu-id="2dd78-157">この zip ファイル内にある **AppxTestRootAgency** フォルダーに含まれる PFX ファイルをインストールします。</span><span class="sxs-lookup"><span data-stu-id="2dd78-157">Install the PFX file that is included in the **AppxTestRootAgency** folder of this zip file.</span></span> <span data-ttu-id="2dd78-158">次に、それを使用してアプリに署名します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-158">Then, sign your app with it.</span></span> <span data-ttu-id="2dd78-159">この方法では、ストアによる署名を必要としないため、迅速に反復できます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-159">That way, you can quickly iterate without requiring Store signing.</span></span>

<span data-ttu-id="2dd78-160">証明書の発行元名がアプリの発行者名と一致する必要があるため、**Identity** 要素の **Publisher** 属性の値を "CN=Appx Test Root Agency Ex" に一時的に変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2dd78-160">Because the publisher name of your certificate must match the publisher name of your app, you'll have to temporarily change the value of the **Identity** element's **Publisher** attribute to "CN=Appx Test Root Agency Ex".</span></span> <span data-ttu-id="2dd78-161">テストの完了後に、この属性を元の値に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-161">You can change that attribute back to it's original value after you've completed your tests.</span></span>

## <a name="next-install-the-policy-and-restart-your-system"></a><span data-ttu-id="2dd78-162">次に、ポリシーをインストールしてシステムを再起動する</span><span class="sxs-lookup"><span data-stu-id="2dd78-162">Next, install the policy and restart your system</span></span>

<span data-ttu-id="2dd78-163">これらのポリシーは起動エラーを招く可能性があるため、仮想マシンに適用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2dd78-163">We recommend that you apply these policies to a virtual machine because these policies might lead to boot failures.</span></span> <span data-ttu-id="2dd78-164">エラーが発生するのは、ドライバーを含めて Microsoft Store によって署名されていないコードの実行がポリシーによってブロックされるためです。</span><span class="sxs-lookup"><span data-stu-id="2dd78-164">That's because these policies block the execution of code that isn't signed by the Microsoft Store, including drivers.</span></span>

<span data-ttu-id="2dd78-165">ローカル コンピューターにこれらのポリシーを適用する場合は、監査モード ポリシーから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2dd78-165">If you want to apply these policies to your local machine, it's best to start with the Audit mode policy.</span></span> <span data-ttu-id="2dd78-166">このポリシーでは、適用されたポリシーで重要なコードがブロックされないことをコード整合性イベント ログで確認できます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-166">With this policy, you can review the Code Integrity Event Logs to ensure that nothing critical would be blocked in an enforced policy.</span></span>

<span data-ttu-id="2dd78-167">ポリシーを適用する準備ができたらを検索します。選択されているポリシーの P7B ファイルの名前を変更する**SIPolicy.P7B**、システム上には、この場所にそのファイルを保存します。**C:\Windows\System32\CodeIntegrity\\**します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-167">When you're ready to apply a policy, find the .P7B file for the policy that you chose, rename it to **SIPolicy.P7B**, and then save that file to this location on your system: **C:\Windows\System32\CodeIntegrity\\**.</span></span>

<span data-ttu-id="2dd78-168">システムを再起動します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-168">Then, restart your system.</span></span>

>[!NOTE]
><span data-ttu-id="2dd78-169">システムからポリシーを削除するには、.P7B ファイルを削除してからシステムを再起動します。</span><span class="sxs-lookup"><span data-stu-id="2dd78-169">To remove a policy from your system, delete the .P7B file and then restart your system.</span></span>

## <a name="next-steps"></a><span data-ttu-id="2dd78-170">次のステップ</span><span class="sxs-lookup"><span data-stu-id="2dd78-170">Next steps</span></span>

<span data-ttu-id="2dd78-171">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="2dd78-171">**Find answers to your questions**</span></span>

<span data-ttu-id="2dd78-172">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="2dd78-172">Have questions?</span></span> <span data-ttu-id="2dd78-173">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="2dd78-173">Ask us on Stack Overflow.</span></span> <span data-ttu-id="2dd78-174">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="2dd78-174">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="2dd78-175">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="2dd78-175">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="2dd78-176">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="2dd78-176">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="2dd78-177">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2dd78-177">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>

<span data-ttu-id="2dd78-178">**アプリを参照してくださいチームによって送信された詳細なブログ記事を確認してください。**</span><span class="sxs-lookup"><span data-stu-id="2dd78-178">**Review a detailed blog article that was posted by our App Consult Team**</span></span>

<span data-ttu-id="2dd78-179">[Windows 10 S でのデスクトップ ブリッジを使用した従来のデスクトップ アプリケーションの移植とテストに関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2dd78-179">See [Porting and testing your classic desktop applications on Windows 10 S with the Desktop Bridge](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/).</span></span>

<span data-ttu-id="2dd78-180">**S モードで Windows をテストするが簡単にするツールについて説明します**</span><span class="sxs-lookup"><span data-stu-id="2dd78-180">**Learn about tools that make it easier to test for Windows in S Mode**</span></span>

<span data-ttu-id="2dd78-181">[APPX のアンパッケージ、変更、再パッケージ、署名に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2dd78-181">See [Unpackage, modify, repackage, sign an APPX](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/).</span></span>
