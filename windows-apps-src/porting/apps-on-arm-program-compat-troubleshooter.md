---
title: プログラム互換性のトラブルシューティング ツール (ARM)
author: msatranjr
description: アプリが ARM で正しく動作しない場合に互換性の設定を調整するためのガイダンス
ms.author: misatran
ms.date: 02/15/2018
ms.topic: article
keywords: windows 10 s, 常時接続, 互換性トラブルシューティング ツール, ARM 版 Windows
ms.localizationpriority: medium
ms.openlocfilehash: 4765ad324e90167c7279c9245bccd840bce1163d
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6045036"
---
# <a name="program-compatibility-troubleshooter-on-arm"></a><span data-ttu-id="3e88b-104">プログラム互換性のトラブルシューティング ツール (ARM)</span><span class="sxs-lookup"><span data-stu-id="3e88b-104">Program Compatibility Troubleshooter on ARM</span></span>
<span data-ttu-id="3e88b-105">x86 アプリが ARM64 上の Windows 10 用に作成された新しい機能をサポートするようにエミュレーションします。</span><span class="sxs-lookup"><span data-stu-id="3e88b-105">Emulation to support x86 apps is a new feature created for Windows 10 on ARM64.</span></span> <span data-ttu-id="3e88b-106">エミュレーションは、最適なエクスペリエンスの結果の最適化を実行することがあります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-106">Sometimes the emulation performs optimizations that don't result in the best experience.</span></span> <span data-ttu-id="3e88b-107">プログラム互換性のトラブルシューティング ツールを使って x86 アプリのエミュレーション設定を切り替えることができるため、既定の最適化が減少し、互換性が強化される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-107">You can use the Program Compatibility Troubleshooter to toggle emulation settings for your x86 app, reducing the default optimizations and potentially increasing compatibility.</span></span>

## <a name="start-the-program-compatibility-troubleshooter"></a><span data-ttu-id="3e88b-108">プログラム互換性のトラブルシューティング ツールの起動</span><span class="sxs-lookup"><span data-stu-id="3e88b-108">Start the Program Compatibility Troubleshooter</span></span>
<span data-ttu-id="3e88b-109">[プログラム互換性のトラブルシューティング ツール](https://support.microsoft.com/en-us/help/15078/windows-make-older-programs-compatible)は、どの Windows 10 PC でも同じ方法によって手動で起動できます。実行可能ファイル (.exe) を右クリックし、**[互換性のトラブルシューティング]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-109">You start the [Program Compatibility Troubleshooter](https://support.microsoft.com/en-us/help/15078/windows-make-older-programs-compatible) manually in the same way on any Windows 10 PC: right-click an executable (.exe) file and select **Troubleshoot compatibility**.</span></span> <span data-ttu-id="3e88b-110">この画面が表示されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-110">This screen appears.</span></span>

![トラブルシューティングの互換性オプションのスクリーンショット](images/arm/Capture4.png)

<span data-ttu-id="3e88b-112">**[問題のトラブルシューティング]** をクリックすると、次のオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-112">If you click on **Troubleshoot program** you will be presented with the following options.</span></span>

![トラブルシューティングの互換性オプションのスクリーンショット](images/arm/Capture5.png)

<span data-ttu-id="3e88b-114">すべてのオプションによって、すべての Windows 10 デスクトップ PC に適用可能または適用される設定が有効になります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-114">All options enable the settings that are applicable and applied on all Windows 10 Desktop PCs.</span></span> <span data-ttu-id="3e88b-115">さらに、1 番目、2 番目、4 番目のオプションは、[アプリケーション キャッシュの無効化](#disable-app-cache)および[ハイブリッド実行モードも無効化](#disable-hybrid-exec-mode)エミュレーション設定を適用します。</span><span class="sxs-lookup"><span data-stu-id="3e88b-115">In addition, the first, second, and fourth options apply the [Disable application cache](#disable-app-cache) and [Disable hybrid execution mode](#disable-hybrid-exec-mode) emulation settings.</span></span>

## <a name="toggling-emulation-settings"></a><span data-ttu-id="3e88b-116">エミュレーション設定の切り替え</span><span class="sxs-lookup"><span data-stu-id="3e88b-116">Toggling emulation settings</span></span>
> [!WARNING]
> <span data-ttu-id="3e88b-117">エミュレーション設定を変更すると、アプリケーションが予期せずクラッシュしたり、まったく起動しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-117">Changing emulation settings may result in your application unexpectedly crashing or not launching at all.</span></span>

<span data-ttu-id="3e88b-118">エミュレーション設定は、実行可能ファイルを右クリックして **[プロパティ]** を選ぶことで切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-118">You can toggle emulation settings by right-clicking the executable and selecting **Properties**.</span></span>

<span data-ttu-id="3e88b-119">ARM では、**[Windows 10 on ARM]** (ARM 版 Windows 10) というセクションが **[互換性]** タブに表示されます。**[Change emulation settings]** (エミュレーション設定の変更) をクリックし、ここに示すように 2 番目のウィンドウを開きます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-119">On ARM, a section titled **Windows 10 on ARM** will be available in the **Compatibility** tab. Click **Change emulation settings** to launch a second window as here.</span></span>

![エミュレーション設定の変更のスクリーンショット](images/arm/Capture.png)

<span data-ttu-id="3e88b-121">このウィンドウでは、2 つの方法でエミュレーション設定を変更できます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-121">This window provides two ways to modify emulation settings.</span></span> <span data-ttu-id="3e88b-122">エミュレーション設定の定義済みグループを選ぶか、**[Use advanced settings]** (詳細設定の使用) オプションをクリックして個々の設定の選択を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-122">You may select a pre-defined group of emulation settings, or you may click the **Use advanced settings** option to enable choosing individual settings.</span></span>

<span data-ttu-id="3e88b-123">グループ化されたエミュレーション設定により、品質を優先してパフォーマンスの最適化が低減されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-123">The grouped emulation settings reduce performance optimizations in favor of quality.</span></span> <span data-ttu-id="3e88b-124">選択できるグループ化された設定をいくつか以下に示します。</span><span class="sxs-lookup"><span data-stu-id="3e88b-124">Below are some grouped settings that you can select.</span></span>

![エミュレーション設定の変更のスクリーンショット 2](images/arm/Capture2.png)

<span data-ttu-id="3e88b-126">**[Use advanced settings]** (詳細設定の使用) を選び、この表で説明されているように個々の設定を選びます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-126">Select **Use advanced settings** to choose individual settings as described in this table.</span></span>

| <span data-ttu-id="3e88b-127">エミュレーション設定</span><span class="sxs-lookup"><span data-stu-id="3e88b-127">Emulation setting</span></span> | <span data-ttu-id="3e88b-128">結果</span><span class="sxs-lookup"><span data-stu-id="3e88b-128">Result</span></span> |
| ----------------- | ----------- |
| <p id="disable-app-cache"><span data-ttu-id="3e88b-129">アプリケーション キャッシュの無効化</span><span class="sxs-lookup"><span data-stu-id="3e88b-129">Disable application cache</span></span></p> | <span data-ttu-id="3e88b-130">オペレーティング システムがコードのコンパイルされたブロックをキャッシュし、後続の実行のオーバーヘッドを減らします。</span><span class="sxs-lookup"><span data-stu-id="3e88b-130">The operating system will cache compiled blocks of code to reduce emulation overhead on subsequent executions.</span></span> <span data-ttu-id="3e88b-131">この設定では、エミュレーターが実行時にすべてのアプリ コードを再コンパイルする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-131">This setting requires the emulator to recompile all app code at runtime.</span></span> |
| <p id="disable-hybrid-exec-mode"><span data-ttu-id="3e88b-132">ハイブリッド実行モードの無効化</span><span class="sxs-lookup"><span data-stu-id="3e88b-132">Disable hybrid execution mode</span></span></p> | <span data-ttu-id="3e88b-133">Compiled Hybrid Portable Executable (CHPE) バイナリは、パフォーマンスを高めるためにネイティブ ARM64 コードが含まれる x86 互換バイナリですが、一部のアプリとは互換性がない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-133">Compiled Hybrid Portable Executable (CHPE), binaries are x86 compatible binaries that include native ARM64 code to improve performance, but that may not be compatible with some apps.</span></span> <span data-ttu-id="3e88b-134">この設定では、x86 のみのバイナリの使用が強制されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-134">This setting forces use of x86-only binaries.</span></span> |
| <span data-ttu-id="3e88b-135">厳密な自己修正コードのサポート</span><span class="sxs-lookup"><span data-stu-id="3e88b-135">Strict self-modifying code support</span></span> | <span data-ttu-id="3e88b-136">自己修正コードがエミュレーションで正しくサポートされるようにするには、これを有効にします。</span><span class="sxs-lookup"><span data-stu-id="3e88b-136">Enable this to ensure that any self-modifying code is correctly supported in emulation.</span></span> <span data-ttu-id="3e88b-137">最も一般的な自己修正コード シナリオは、既定のエミュレーター動作でカバーされます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-137">The most common self-modifying code scenarios are covered by the default emulator behavior.</span></span> <span data-ttu-id="3e88b-138">このオプションを有効にすると、実行時に自己修正コードのパフォーマンスが大幅に低下します。</span><span class="sxs-lookup"><span data-stu-id="3e88b-138">Enabling this option significantly reduces performance of self-modifying  code during execution.</span></span> |
| <span data-ttu-id="3e88b-139">RWX ページ パフォーマンスの最適化の無効化</span><span class="sxs-lookup"><span data-stu-id="3e88b-139">Disable RWX page performance optimization</span></span> | <span data-ttu-id="3e88b-140">この最適化によって、読み取り可能、書き込み可能、実行可能な (RWX) ページのコードのパフォーマンスが向上しますが、一部のアプリとの互換性がない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3e88b-140">This optimization improves the performance of code on readable, writable, and executable (RWX) pages, but may be incompatible with some apps.</span></span> |

<span data-ttu-id="3e88b-141">次のように、マルチコア設定を選択することもできます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-141">You can also select multi-core settings, as shown here.</span></span>

![マルチコア設定のスクリーン ショット](images/arm/Capture3.png)

<span data-ttu-id="3e88b-143">これらの設定によって、エミュレーション中にアプリのコア間のメモリー アクセスを同期するために使用されるメモリ バリアの数が変更されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-143">These settings change the number of memory barriers used to synchronize memory accesses between cores in apps during emulation.</span></span> <span data-ttu-id="3e88b-144">**[Fast]** が既定のモードですが、**[strict]** (厳格) オプションと **[very strict]** (非常に厳格) オプションではバリアの数が増加します。</span><span class="sxs-lookup"><span data-stu-id="3e88b-144">**Fast** is the default mode, but the **strict** and **very strict** options will increase the number of barriers.</span></span> <span data-ttu-id="3e88b-145">これによりアプリが遅くなりますが、アプリ エラーのリスクが軽減されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-145">This slows down the app, but reduces the risk of app errors.</span></span> <span data-ttu-id="3e88b-146">**[single-core]** (シングル コア) オプションでは、すべてのバリアがなくなりますが、すべてのアプリ スレッドが強制的にシングル コアで実行されます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-146">The **single-core** option removes all barriers but forces all app threads to run on a single core.</span></span>

<span data-ttu-id="3e88b-147">特定の設定を変更して問題が解決した場合、詳細を記載したメールを *woafeedback@microsoft.com* にお送りいただければフィードバックが組み込まれます。</span><span class="sxs-lookup"><span data-stu-id="3e88b-147">If changing a specific setting resolves your issue, please email *woafeedback@microsoft.com* with details, so that we may incorporate your feedback.</span></span>