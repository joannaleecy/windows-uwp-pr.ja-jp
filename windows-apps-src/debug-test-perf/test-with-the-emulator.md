---
author: PatrickFarley
ms.assetid: 7234DD5F-8E86-424E-99A0-93D01F1311F2
title: "Microsoft Emulator for Windows 10 Mobile を使ったテスト"
description: "Microsoft Emulator for Windows 10 Mobile に用意されているツールを使って、デバイスでの実際の操作をシミュレートし、アプリの機能をテストします。"
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 8eadf3ecc099e1f622ec49db4efa8f4f67c52d13
ms.sourcegitcommit: e8cc657d85566768a6efb7cd972ebf64c25e0628
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/26/2017
---
# <a name="test-with-the-microsoft-emulator-for-windows-10-mobile"></a><span data-ttu-id="dc3e1-104">Microsoft Emulator for Windows 10 Mobile を使ったテスト</span><span class="sxs-lookup"><span data-stu-id="dc3e1-104">Test with the Microsoft Emulator for Windows 10 Mobile</span></span>

<span data-ttu-id="dc3e1-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="dc3e1-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="dc3e1-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="dc3e1-107">Microsoft Emulator for Windows 10 Mobile に用意されているツールを使って、デバイスでの実際の操作をシミュレートし、アプリの機能をテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-107">Simulate real-world interaction with a device and test the features of your app by using the tools included with Microsoft Emulator for Windows 10 Mobile.</span></span> <span data-ttu-id="dc3e1-108">エミュレーターは、Windows 10 を実行するモバイル デバイスをエミュレートするデスクトップ アプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-108">The emulator is a desktop application that emulates a mobile device running Windows 10.</span></span> <span data-ttu-id="dc3e1-109">このアプリケーションを使用すると、仮想化された環境が提供されるため、物理デバイスを使用せずに Windows アプリのデバッグとテストを実行できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-109">It provides a virtualized environment in which you can debug and test Windows apps without a physical device.</span></span> <span data-ttu-id="dc3e1-110">また、アプリケーションのプロトタイプのための隔離環境としても使用できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-110">It also provides an isolated environment for your application prototypes.</span></span>

<span data-ttu-id="dc3e1-111">エミュレーターは実際の機器と同等のパフォーマンスを発揮するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-111">The emulator is designed to provide comparable performance to an actual device.</span></span> <span data-ttu-id="dc3e1-112">ただし、Windows ストアにアプリを公開する前に、物理デバイスでアプリをテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-112">Before you publish your app to the Windows Store, however, we recommend that you test your app on a physical device.</span></span>

<span data-ttu-id="dc3e1-113">さまざまな画面解像度と画面サイズ構成に対応する一意の Windows 10 Mobile エミュレーター イメージを使用して、ユニバーサル アプリをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-113">You can test your universal app using a unique Windows 10 Mobile emulator image for various screen resolution and screen size configurations.</span></span> <span data-ttu-id="dc3e1-114">Microsoft Emulator に用意されているツールを使って、デバイスでの実際の操作をシミュレートし、アプリのさまざまな機能をテストできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-114">You can simulate real-world interaction with a device and test various features of your app by using the tools included in the Microsoft Emulator.</span></span>

## <a name="system-requirements"></a><span data-ttu-id="dc3e1-115">システム要件</span><span class="sxs-lookup"><span data-stu-id="dc3e1-115">System requirements</span></span>

<span data-ttu-id="dc3e1-116">コンピューターは次の要件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-116">Your computer must meet the following requirements:</span></span>

<span data-ttu-id="dc3e1-117">BIOS</span><span class="sxs-lookup"><span data-stu-id="dc3e1-117">BIOS</span></span>

-   <span data-ttu-id="dc3e1-118">ハードウェア支援による仮想化機能。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-118">Hardware-assisted virtualization.</span></span>
-   <span data-ttu-id="dc3e1-119">Second Level Address Translation (SLAT)。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-119">Second Level Address Translation (SLAT).</span></span>
-   <span data-ttu-id="dc3e1-120">ハードウェアベースのデータ実行防止 (DEP)。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-120">Hardware-based Data Execution Prevention (DEP).</span></span>

<span data-ttu-id="dc3e1-121">RAM</span><span class="sxs-lookup"><span data-stu-id="dc3e1-121">RAM</span></span>

-   <span data-ttu-id="dc3e1-122">4 GB 以上。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-122">4 GB or more.</span></span>

<span data-ttu-id="dc3e1-123">オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="dc3e1-123">Operating system</span></span>

-   <span data-ttu-id="dc3e1-124">Windows 8 以上 (Windows 10 を強く推奨)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-124">Windows 8 or higher (Windows 10 strongly recommended)</span></span>
-   <span data-ttu-id="dc3e1-125">64 ビット</span><span class="sxs-lookup"><span data-stu-id="dc3e1-125">64-bit</span></span>
-   <span data-ttu-id="dc3e1-126">Pro エディション以上</span><span class="sxs-lookup"><span data-stu-id="dc3e1-126">Pro edition or higher</span></span>

<span data-ttu-id="dc3e1-127">BIOS 要件を確認するには、「[Windows Phone 8 のエミュレーター用に Hyper-V を有効にする方法](https://msdn.microsoft.com/library/windows/apps/xaml/jj863509.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-127">To check the BIOS requirements, see [How to enable Hyper-V for the emulator for Windows Phone 8](https://msdn.microsoft.com/library/windows/apps/xaml/jj863509.aspx).</span></span>

<span data-ttu-id="dc3e1-128">コントロール パネルで RAM とオペレーティング システムの要件を確認するには、**[システムとセキュリティ]** をクリックし、**[システム]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-128">To check requirements for RAM and operating system, in Control Panel, click **System and Security**, and then click **System**.</span></span>

<span data-ttu-id="dc3e1-129">Microsoft Emulator for Windows 10 Mobile には Visual Studio 2015 が必要です。以前のバージョンの Visual Studio との下位互換性はありません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-129">Microsoft Emulator for Windows 10 Mobile requires Visual Studio 2015; it is not backward compatible with earlier versions of Visual Studio.</span></span>

<span data-ttu-id="dc3e1-130">Microsoft Emulator for Windows 10 Mobile は、Windows Phone OS 7.1 より前の Windows Phone OS バージョンを対象とするアプリを読み込むことはできません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-130">Microsoft Emulator for Windows 10 Mobile cannot load apps that target the Windows Phone OS version earlier than Windows Phone OS 7.1.</span></span>

## <a name="installing-and-uninstalling"></a><span data-ttu-id="dc3e1-131">インストールとアンインストール</span><span class="sxs-lookup"><span data-stu-id="dc3e1-131">Installing and uninstalling</span></span>

-   <span data-ttu-id="dc3e1-132">**インストール**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-132">**Installing**.</span></span>

    <span data-ttu-id="dc3e1-133">Microsoft Emulator for Windows 10 Mobile は、Windows 10 SDK の一部としてリリースされています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-133">Microsoft Emulator for Windows 10 Mobile ships as part of the Windows 10 SDK.</span></span> <span data-ttu-id="dc3e1-134">Windows 10 SDK とエミュレーターは、Visual Studio 2015 の一部としてインストールできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-134">The Windows 10 SDK and emulator can be installed as part of the Visual Studio 2015 install.</span></span> <span data-ttu-id="dc3e1-135">「[Visual Studio 2015 RC 用の Windows 10 開発ツールをインストールする手順](https://go.microsoft.com/fwlink/p/?LinkId=534785)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-135">See the [Visual Studio download page](https://go.microsoft.com/fwlink/p/?LinkId=534785).</span></span>

    <span data-ttu-id="dc3e1-136">Microsoft Emulator for Windows 10 Mobile は、Microsoft Emulator のセットアップを使ってインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-136">You can also install the Microsoft Emulator for Windows 10 Mobile using the Microsoft Emulator setup.</span></span> <span data-ttu-id="dc3e1-137">「[Windows 10 開発者ツール プレビュー](https://go.microsoft.com/fwlink/p/?LinkID=534189)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-137">See the [Windows 10 Tools download page](https://go.microsoft.com/fwlink/p/?LinkID=534189).</span></span>

-   <span data-ttu-id="dc3e1-138">**アンインストール**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-138">**Uninstalling**.</span></span>

    <span data-ttu-id="dc3e1-139">Microsoft Emulator for Windows 10 Mobile は、Visual Studio のセットアップ/修復を使ってアンインストールできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-139">You can uninstall the Microsoft Emulator for Windows 10 Mobile using Visual Studio setup/repair.</span></span> <span data-ttu-id="dc3e1-140">または、**コントロール パネル**の [**プログラムと機能**] を使ってエミュレーターを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-140">Or you can use **Programs and Features** under **Control Panel** to remove the emulator.</span></span>

    <span data-ttu-id="dc3e1-141">Microsoft Emulator for Windows 10 Mobile をアンインストールしても、使うエミュレーター用に作られた Hyper-V 仮想イーサネット アダプターは自動的に削除されません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-141">When you uninstall the Microsoft Emulator for Windows 10 Mobile, the Hyper-V Virtual Ethernet Adapter that was created for the emulator to use is not automatically removed.</span></span> <span data-ttu-id="dc3e1-142">この仮想アダプターは、**コントロール パネル**の [**ネットワーク接続**] から手動で削除できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-142">You can manually remove this virtual adapter from **Network Connections** in **Control Panel**.</span></span>

## <a name="whats-new-in-microsoft-emulator-for-windows-10-mobile"></a><span data-ttu-id="dc3e1-143">Microsoft Emulator for Windows 10 Mobile に関する最新情報</span><span class="sxs-lookup"><span data-stu-id="dc3e1-143">What’s new in Microsoft Emulator for Windows 10 Mobile</span></span>

<span data-ttu-id="dc3e1-144">ユニバーサル Windows プラットフォーム (UWP) をサポートするだけでなく、エミュレーターには次の機能も追加されています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-144">In addition to providing support for Universal Windows Platform (UWP), the emulator has added the following functionality:</span></span>

-   <span data-ttu-id="dc3e1-145">マウスとシングル タッチ入力を区別するマウス入力モードのサポート。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-145">Mouse input mode support to differentiate between mouse and single touch input.</span></span>
-   <span data-ttu-id="dc3e1-146">NFC のサポート。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-146">NFC Support.</span></span> <span data-ttu-id="dc3e1-147">エミュレーターを使うと、NFC をシミュレートし、NFC/近接通信が有効なユニバーサル アプリをテストおよび開発することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-147">The emulator allows you to simulate NFC and make it possible to test and develop NFC/Proximity-enabled universal apps.</span></span>
-   <span data-ttu-id="dc3e1-148">ネイティブのハードウェア アクセラレーションは、ローカル グラフィックス カードを使ってエミュレーターのグラフィックス パフォーマンスを向上させます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-148">Native hardware acceleration improves graphics performance in the emulator by using the local graphics card.</span></span> <span data-ttu-id="dc3e1-149">アクセラレーションを使うには、サポートされているグラフィックス カードを取り付け、エミュレーターの **[その他のツール]** 設定ユーザー インターフェイスの **[センサー]** タブでアクセラレーションを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-149">You must have a supported graphics card installed, and enable acceleration on the **Sensors** tab of the emulator's **Additional Tools** settings user interface in order to use acceleration.</span></span>

## <a name="features-that-you-can-test-in-the-emulator"></a><span data-ttu-id="dc3e1-150">エミュレーター上でテストできる機能</span><span class="sxs-lookup"><span data-stu-id="dc3e1-150">Features that you can test in the emulator</span></span>

<span data-ttu-id="dc3e1-151">前のセクションで説明した新機能に加え、次のよく使われる機能を Microsoft Emulator for Windows 10 Mobile でテストできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-151">In addition to the new features mentioned in the previous section, you can test the following commonly used features in the Microsoft Emulator for Windows 10 Mobile.</span></span>

-   <span data-ttu-id="dc3e1-152">**画面解像度、画面サイズ、メモリ**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-152">**Screen resolution, screen size, and memory**.</span></span> <span data-ttu-id="dc3e1-153">アプリをさまざまなエミュレーター イメージでテストし、さまざまな画面解像度、物理的なサイズ、メモリの制限をシミュレートすることで、幅広い市場にアプリを届けます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-153">Reach a broad market for your app by testing it on various emulator images to simulate various screen resolutions, physical sizes, and memory constraints.</span></span>

    ![解像度、サイズ、メモリに使うことができるエミュレーター](images/em-list.png)

-   <span data-ttu-id="dc3e1-155">**画面構成**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-155">**Screen configuration**.</span></span> <span data-ttu-id="dc3e1-156">エミュレーターを縦モードから横モードに変更します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-156">Change the emulator from portrait to landscape mode.</span></span> <span data-ttu-id="dc3e1-157">デスクトップ画面に合うようにエミュレーターのズーム設定を変更します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-157">Change the zoom setting to fit the emulator to your desktop screen.</span></span>

-   <span data-ttu-id="dc3e1-158">**ネットワーク**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-158">**Networking**.</span></span> <span data-ttu-id="dc3e1-159">ネットワークのサポートは、Windows Phone エミュレーターに統合されています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-159">Networking support is integrated with Windows Phone Emulator.</span></span> <span data-ttu-id="dc3e1-160">ネットワークは、既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-160">Networking is enabled by default.</span></span> <span data-ttu-id="dc3e1-161">ほとんどの環境では、Windows Phone エミュレーターのネットワーク ドライバーをインストールしたり、ネットワーク オプションを手動で構成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-161">You do not have to install network drivers for Windows Phone Emulator or configure networking options manually in most environments.</span></span>

    <span data-ttu-id="dc3e1-162">エミュレーターはホスト コンピューターのネットワーク接続を使います。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-162">The emulator uses the network connection of the host computer.</span></span> <span data-ttu-id="dc3e1-163">ネットワーク上に個別のデバイスとして表示されません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-163">It does not appear as a separate device on the network.</span></span> <span data-ttu-id="dc3e1-164">これにより、Windows Phone SDK 8.0 エミュレーターで発生していた構成に関するいくつかの問題が解決しました。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-164">This eliminates some of the configuration issues that users encountered with the Windows Phone SDK 8.0 emulator.</span></span>

-   <span data-ttu-id="dc3e1-165">**言語と地域の設定**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-165">**Language and region settings**.</span></span> <span data-ttu-id="dc3e1-166">Windows Phone エミュレーターで表示言語と地域の設定を変更し、国際的な市場に向けてアプリを準備します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-166">Prepare your app for an international market by changing the display language and region settings in Windows Phone Emulator.</span></span>

    <span data-ttu-id="dc3e1-167">実行中のエミュレーターで、**[設定]** アプリに進み、**[システム]** 設定をクリックして、**[言語]** または **[地域]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-167">On the running emulator, go to the **Settings** app, then select the **system** settings, then select **language** or **region**.</span></span> <span data-ttu-id="dc3e1-168">テストする設定を変更します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-168">Change the settings that you want to test.</span></span> <span data-ttu-id="dc3e1-169">ダイアログが表示されたら、[**電話を再起動**] をクリックして新しい設定を適用し、エミュレーターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-169">If you're prompted, click **restart phone** to apply the new settings and restart the emulator.</span></span>

-   <span data-ttu-id="dc3e1-170">**アプリケーションのライフサイクルと廃棄**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-170">**Application lifecycle and tombstoning**.</span></span> <span data-ttu-id="dc3e1-171">プロジェクトのプロパティの [**デバッグ**] ページにある [**デバッグ中の非アクティブ化時に廃棄する**] オプションの値を変更することで、アプリが非アクティブ化されたとき、または廃棄されたときの動作をテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-171">Test the behavior or your app when it's deactivated or tombstoned by changing the value of the option **Tombstone upon deactivation while debugging** on the **Debug** page of project properties.</span></span>

-   <span data-ttu-id="dc3e1-172">**ローカル フォルダー ストレージ (以前は分離ストレージと呼ばれていました)**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-172">**Local folder storage (previously known as isolated storage)**.</span></span> <span data-ttu-id="dc3e1-173">分離ストレージのデータはエミュレーターの実行中は維持されますが、エミュレーターが終了すると失われます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-173">Data in isolated storage persists while the emulator is running, but is lost once the emulator closes.</span></span>

-   <span data-ttu-id="dc3e1-174">**マイク**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-174">**Microphone**.</span></span> <span data-ttu-id="dc3e1-175">ホスト コンピューターでマイクを要求して使います。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-175">Requires and uses the microphone on the host computer.</span></span>

-   <span data-ttu-id="dc3e1-176">**Windows Phone キーボード**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-176">**Phone keyboard**.</span></span> <span data-ttu-id="dc3e1-177">エミュレーターでは、開発用コンピューターのハードウェア キーボードを Windows Phone のキーボードにマッピングすることをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-177">The emulator supports mapping of the hardware keyboard on your development computer to the keyboard on a Windows Phone.</span></span> <span data-ttu-id="dc3e1-178">キーの動作は、Windows Phone デバイスでの動作と同じです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-178">The behavior of the keys is the same as on a Windows Phone device</span></span>

-   <span data-ttu-id="dc3e1-179">**ロック画面**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-179">**Lock screen**.</span></span> <span data-ttu-id="dc3e1-180">エミュレーターを開いた状態で、コンピューターのキーボードの F12 キーを 2 回押します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-180">With the emulator open, press F12 on your computer keyboard twice.</span></span> <span data-ttu-id="dc3e1-181">F12 キーは、電話の電源ボタンをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-181">The F12 key emulates the power button on the phone.</span></span> <span data-ttu-id="dc3e1-182">このキーを 1 回押すと、ディスプレイがオフになります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-182">The first key press turns off the display.</span></span> <span data-ttu-id="dc3e1-183">2 回目にキーを押すことで、ロック画面の状態で画面がもう一度オンになります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-183">The second key press turns the display on again with the lock screen engaged.</span></span> <span data-ttu-id="dc3e1-184">マウスを使ってロック画面を上方向へスライドし、画面のロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-184">Unlock the screen by using the mouse to slide the lock screen upward.</span></span>

## <a name="features-that-you-cant-test-in-the-emulator"></a><span data-ttu-id="dc3e1-185">エミュレーターでテストできない機能</span><span class="sxs-lookup"><span data-stu-id="dc3e1-185">Features that you can't test in the emulator</span></span>

<span data-ttu-id="dc3e1-186">次の機能は物理デバイスでのみテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-186">Test the following features only on a physical device.</span></span>

-   <span data-ttu-id="dc3e1-187">コンパス</span><span class="sxs-lookup"><span data-stu-id="dc3e1-187">Compass</span></span>
-   <span data-ttu-id="dc3e1-188">ジャイロスコープ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-188">Gyroscope</span></span>
-   <span data-ttu-id="dc3e1-189">バイブレーション コントローラー</span><span class="sxs-lookup"><span data-stu-id="dc3e1-189">Vibration controller</span></span>
-   <span data-ttu-id="dc3e1-190">明るさ。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-190">Brightness.</span></span> <span data-ttu-id="dc3e1-191">エミュレーターの明るさのレベルは常に高です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-191">The brightness level of the emulator is always High.</span></span>
-   <span data-ttu-id="dc3e1-192">高解像度ビデオ。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-192">High-resolution video.</span></span> <span data-ttu-id="dc3e1-193">VGA 解像度 (640 x 480) より高い解像度のビデオは、特に 512 MB メモリのみを備えるエミュレーター イメージでは、安定して表示できません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-193">Videos with a resolution higher than VGA resolution (640 x 480) cannot be displayed reliably, especially on emulator images with only 512MB of memory.</span></span>

## <a name="mouse-input"></a><span data-ttu-id="dc3e1-194">マウス入力</span><span class="sxs-lookup"><span data-stu-id="dc3e1-194">Mouse input</span></span>

<span data-ttu-id="dc3e1-195">Windows PC の物理的なマウスまたはトラック パッド、およびエミュレーター ツール バーのマウス入力ボタンを使用して入力をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-195">Simulate mouse input using the physical mouse or trackpad on your Windows PC and the mouse input button on the emulator toolbar.</span></span> <span data-ttu-id="dc3e1-196">この機能は、Windows 10 デバイスにペアリングされたマウスを利用して入力を行う機能をアプリがユーザーに提供する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-196">This feature is useful if your app provides the user with an ability to utilize a mouse paired to their Windows 10 device to provide input.</span></span>

<span data-ttu-id="dc3e1-197">エミュレーター ツール バーのマウス入力ボタンをタップしてマウス入力を有効にします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-197">Tap the mouse input button on the emulator toolbar to enable mouse input.</span></span> <span data-ttu-id="dc3e1-198">エミュレーター クロム内でクリック イベントがあると、エミュレーター VM の内部で実行されている Windows 10 Mobile OS にマウス イベントとして送信されるようになります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-198">Any click events within the emulator chrome will now be sent to the Windows 10 Mobile OS running inside the emulator VM as mouse events.</span></span>

![マウス入力が有効になっているエミュレーターの画面](images/emulator-with-mouse-enabled.png)

<span data-ttu-id="dc3e1-200">マウス入力が有効になっているエミュレーターの画面。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-200">The emulator screen with the mouse input enabled.</span></span>

![エミュレーター ツール バーのマウス入力ボタン](images/emulator-showing-mouse-input-button-bar.png)

<span data-ttu-id="dc3e1-202">エミュレーター ツール バーのマウス入力ボタン。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-202">The mouse input button on the emulator toolbar.</span></span>

## <a name="keyboard-input"></a><span data-ttu-id="dc3e1-203">キーボード入力</span><span class="sxs-lookup"><span data-stu-id="dc3e1-203">Keyboard input</span></span>

<span data-ttu-id="dc3e1-204">エミュレーターでは、開発用コンピューターのハードウェア キーボードを Windows Phone のキーボードにマッピングすることをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-204">The emulator supports mapping of the hardware keyboard on your development computer to the keyboard on a Windows Phone.</span></span> <span data-ttu-id="dc3e1-205">キーの動作は、Windows Phone デバイスでの動作と同じです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-205">The behavior of the keys is the same as on a Windows Phone device.</span></span> 

<span data-ttu-id="dc3e1-206">既定では、ハードウェア キーボードは有効になっていません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-206">By default, the hardware keyboard is not enabled.</span></span> <span data-ttu-id="dc3e1-207">この実装は、使用する前に展開する必要があるスライディング キーボードと同じです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-207">This implementation is equivalent to a sliding keyboard that must be deployed before you can use it.</span></span> <span data-ttu-id="dc3e1-208">ハードウェア キーボードを有効にするまで、エミュレーターはコントロール キーからのみキー入力を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-208">Before you enable the hardware keyboard, the emulator accepts key input only from the control keys.</span></span>

<span data-ttu-id="dc3e1-209">エミュレーターでは、ローカライズされたバージョンの Windows 開発用コンピューターのキーボードにある特殊文字はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-209">Special characters on the keyboard of a localized version of a Windows development computer are not supported by the emulator.</span></span> <span data-ttu-id="dc3e1-210">ローカライズされたキーボード上に存在する特殊文字を入力するには、代わりにソフトウェア入力パネル (SIP) を使います。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-210">To enter special characters that are present on a localized keyboard, use the Software Input Panel (SIP) instead.</span></span> 

<span data-ttu-id="dc3e1-211">エミュレーターでコンピューターのキーボードを使うには、F4 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-211">To use your computer’s keyboard in the emulator, press F4.</span></span>

<span data-ttu-id="dc3e1-212">エミュレーターでコンピューターのキーボードの使用を中止するには、F4 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-212">To stop using your computer’s keyboard in the emulator, press F4.</span></span>

<span data-ttu-id="dc3e1-213">次の表に、Windows Phone のボタンとその他のコントロールをエミュレートするために使用できるハードウェア キーボードのキーを示します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-213">The following table lists the keys on a hardware keyboard that you can use to emulate the buttons and other controls on a Windows Phone.</span></span>

<span data-ttu-id="dc3e1-214">エミュレーターのビルド 10.0.14332 では、コンピューターのハードウェア キー マッピングが変更されたことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-214">Note that in Emulator Build 10.0.14332 the computer hardware key mapping was changed.</span></span> <span data-ttu-id="dc3e1-215">次の表の 2 番目の列の値は、これらの新しいキーを表します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-215">Values in the second column of the table below represent these new keys.</span></span> 

<span data-ttu-id="dc3e1-216">コンピューターのハードウェア キー (エミュレーター ビルド 10.0.14295 以前)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-216">Computer hardware keys (Emulator Build 10.0.14295 and earlier)</span></span> | <span data-ttu-id="dc3e1-217">コンピューターのハードウェア キー (エミュレーター ビルド 10.0.14332 以降)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-217">Computer hardware keys (Emulator Build 10.0.14332 and newer)</span></span> | <span data-ttu-id="dc3e1-218">Windows Phone のハードウェア ボタン</span><span class="sxs-lookup"><span data-stu-id="dc3e1-218">Windows Phone hardware button</span></span> | <span data-ttu-id="dc3e1-219">コメント</span><span class="sxs-lookup"><span data-stu-id="dc3e1-219">Notes</span></span>
--------------------- | ------------------------- | ----------------------------- | -----
<span data-ttu-id="dc3e1-220">F1</span><span class="sxs-lookup"><span data-stu-id="dc3e1-220">F1</span></span> | <span data-ttu-id="dc3e1-221">Windows + Esc</span><span class="sxs-lookup"><span data-stu-id="dc3e1-221">WIN + ESC</span></span> | <span data-ttu-id="dc3e1-222">戻る</span><span class="sxs-lookup"><span data-stu-id="dc3e1-222">BACK</span></span> | <span data-ttu-id="dc3e1-223">長押しは期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-223">Long presses work as expected.</span></span>
<span data-ttu-id="dc3e1-224">F2</span><span class="sxs-lookup"><span data-stu-id="dc3e1-224">F2</span></span> | <span data-ttu-id="dc3e1-225">Windows + F2</span><span class="sxs-lookup"><span data-stu-id="dc3e1-225">WIN + F2</span></span> | <span data-ttu-id="dc3e1-226">スタート</span><span class="sxs-lookup"><span data-stu-id="dc3e1-226">START</span></span> | <span data-ttu-id="dc3e1-227">長押しは期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-227">Long presses work as expected.</span></span>
<span data-ttu-id="dc3e1-228">F3</span><span class="sxs-lookup"><span data-stu-id="dc3e1-228">F3</span></span> | <span data-ttu-id="dc3e1-229">Windows + F3</span><span class="sxs-lookup"><span data-stu-id="dc3e1-229">WIN + F3</span></span> | <span data-ttu-id="dc3e1-230">検索</span><span class="sxs-lookup"><span data-stu-id="dc3e1-230">SEARCH</span></span> |  
<span data-ttu-id="dc3e1-231">F4</span><span class="sxs-lookup"><span data-stu-id="dc3e1-231">F4</span></span> | <span data-ttu-id="dc3e1-232">F4 (変更なし)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-232">F4 (no change)</span></span> | <span data-ttu-id="dc3e1-233">ローカル コンピューターのキーボードの使用と不使用を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-233">Toggles between using the local computer’s keyboard and not using the local computer’s keyboard.</span></span> | 
<span data-ttu-id="dc3e1-234">F6</span><span class="sxs-lookup"><span data-stu-id="dc3e1-234">F6</span></span> | <span data-ttu-id="dc3e1-235">Windows + F6</span><span class="sxs-lookup"><span data-stu-id="dc3e1-235">WIN + F6</span></span> | <span data-ttu-id="dc3e1-236">カメラ半押し</span><span class="sxs-lookup"><span data-stu-id="dc3e1-236">CAMERA HALF</span></span> | <span data-ttu-id="dc3e1-237">半押しされた専用カメラ ボタン。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-237">A dedicated camera button that is pressed halfway.</span></span>
<span data-ttu-id="dc3e1-238">F7</span><span class="sxs-lookup"><span data-stu-id="dc3e1-238">F7</span></span> | <span data-ttu-id="dc3e1-239">Windows + F7</span><span class="sxs-lookup"><span data-stu-id="dc3e1-239">WIN + F7</span></span> | <span data-ttu-id="dc3e1-240">カメラ全押し</span><span class="sxs-lookup"><span data-stu-id="dc3e1-240">CAMERA FULL</span></span> | <span data-ttu-id="dc3e1-241">専用カメラ ボタン。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-241">A dedicated camera button.</span></span>
<span data-ttu-id="dc3e1-242">F9</span><span class="sxs-lookup"><span data-stu-id="dc3e1-242">F9</span></span> | <span data-ttu-id="dc3e1-243">Windows + F9</span><span class="sxs-lookup"><span data-stu-id="dc3e1-243">WIN + F9</span></span> | <span data-ttu-id="dc3e1-244">音量増</span><span class="sxs-lookup"><span data-stu-id="dc3e1-244">VOLUME UP</span></span> | 
<span data-ttu-id="dc3e1-245">F10</span><span class="sxs-lookup"><span data-stu-id="dc3e1-245">F10</span></span> | <span data-ttu-id="dc3e1-246">Windows + F10</span><span class="sxs-lookup"><span data-stu-id="dc3e1-246">WIN + F10</span></span> | <span data-ttu-id="dc3e1-247">音量減</span><span class="sxs-lookup"><span data-stu-id="dc3e1-247">VOLUME DOWN</span></span> | 
<span data-ttu-id="dc3e1-248">F12</span><span class="sxs-lookup"><span data-stu-id="dc3e1-248">F12</span></span> | <span data-ttu-id="dc3e1-249">Windows + F12</span><span class="sxs-lookup"><span data-stu-id="dc3e1-249">WIN + F12</span></span> | <span data-ttu-id="dc3e1-250">電源</span><span class="sxs-lookup"><span data-stu-id="dc3e1-250">POWER</span></span> | <span data-ttu-id="dc3e1-251">ロック画面を有効にするには、F12 キーを 2 回押します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-251">Press the F12 key twice to enable the lock screen.</span></span> <span data-ttu-id="dc3e1-252">長押しは期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-252">Long presses work as expected.</span></span>
<span data-ttu-id="dc3e1-253">Esc</span><span class="sxs-lookup"><span data-stu-id="dc3e1-253">ESC</span></span> | <span data-ttu-id="dc3e1-254">Windows + Esc</span><span class="sxs-lookup"><span data-stu-id="dc3e1-254">WIN + ESC</span></span> | <span data-ttu-id="dc3e1-255">戻る</span><span class="sxs-lookup"><span data-stu-id="dc3e1-255">BACK</span></span> | <span data-ttu-id="dc3e1-256">長押しは期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-256">Long presses work as expected.</span></span>
 


## <a name="near-field-communications-nfc"></a><span data-ttu-id="dc3e1-257">近距離無線通信 (NFC)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-257">Near Field Communications (NFC)</span></span>

<span data-ttu-id="dc3e1-258">エミュレーターの **[その他のツール]** メニューの **[NFC]** タブを使って、Windows 10 Mobile で近距離無線通信 (NFC) が有効な機能を使用するアプリをビルドしてテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-258">Build and test apps that use Near Field Communication (NFC) enabled features on Windows 10 Mobile by using the **NFC** tab of the emulator’s **Additional Tools** menu.</span></span> <span data-ttu-id="dc3e1-259">NFC は、近接通信シナリオ (タップして共有など) からカード エミュレーション (タップして支払いなど) まで、多くのシナリオで役立ちます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-259">NFC is useful for a number of scenarios ranging from Proximity scenarios (such as tap to share) to card emulation (such as tap to pay).</span></span>

<span data-ttu-id="dc3e1-260">アプリをテストするには、1 組のエミュレーターを使って互いにタップする 1 組の電話をシミュレートします。または、タグへのタップをシミュレートしてアプリをテストすることもできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-260">You can test your app by simulating a pair of phones tapping together by using a pair of emulators, or you can test your app by simulating a tap to a tag.</span></span> <span data-ttu-id="dc3e1-261">Windows 10 では、モバイル デバイスが HCE (ホスト カード エミュレーション) 機能にも対応しており、電話エミュレーターを使うことで、デバイスを支払い端末にタップして APDU コマンド応答トラフィックを送信する操作をシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-261">Also in Windows 10, mobile devices are enabled with HCE (Host Card Emulation) feature and by using the phone emulator you can simulate tapping your device to a payment terminal for APDU command-response traffic.</span></span>

<span data-ttu-id="dc3e1-262">[NFC] タブは 3 つのモードをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-262">The NFC tab supports three modes:</span></span>

-   <span data-ttu-id="dc3e1-263">近接通信モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-263">Proximity Mode</span></span>
-   <span data-ttu-id="dc3e1-264">HCE (ホスト カード エミュレーション) モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-264">HCE (Host Card Emulation) Mode</span></span>
-   <span data-ttu-id="dc3e1-265">スマート カード リーダー モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-265">Smart Card Reader Mode</span></span>

<span data-ttu-id="dc3e1-266">すべてのモードで、エミュレーター ウィンドウには 3 つの対象エリアがあります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-266">In all modes, the emulator window has three areas of interest.</span></span>

-   <span data-ttu-id="dc3e1-267">左上のセクションは、選択されたモードに固有です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-267">The top left section is specific to the mode selected.</span></span> <span data-ttu-id="dc3e1-268">このセクションの機能はモードによって決まります。詳しくは、以下のモード固有のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-268">The features of this section depend on the mode, and are detailed in the mode-specific sections below.</span></span>
-   <span data-ttu-id="dc3e1-269">右上のセクションには、ログが一覧表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-269">The top right section lists the logs.</span></span> <span data-ttu-id="dc3e1-270">1 組のデバイスを互いにタップする (または POS 端末にタップする) と、タップ イベントが記録され、デバイスがアンタップされるとアンタップ イベントが記録されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-270">When you tap a pair of devices together (or tap to the POS terminal) the tap event is logged and when the devices are untapped the untap event is logged.</span></span> <span data-ttu-id="dc3e1-271">このセクションには、接続が切断される前にアプリが応答したかどうかや、エミュレーター UI で実行した他の操作もタイムスタンプ付きで記録されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-271">This section also records if your app responded before the connection is broken or any other action you have taken in the emulator UI with time stamps.</span></span> <span data-ttu-id="dc3e1-272">モードを切り替えてもログは存続します。ログは、**[ログ]** 画面の **[消去]** ボタンを押すことでいつでも消去できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-272">Logs are persistent between mode switches, and you can clear the logs at any point by hitting the **Clear** button above the **Logs** screen.</span></span>
-   <span data-ttu-id="dc3e1-273">画面の下半分はメッセージ ログになっており、選択されたモードに応じて、現在選択されている接続を経由して送受信されたすべてのメッセージのトランスクリプトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-273">The bottom half of the screen is the message log and shows the transcript of all messages sent or received over the currently selected connection, depending on the mode selected.</span></span>

> <span data-ttu-id="dc3e1-274">**重要**  タップ ツールを初めて起動すると、Windows ファイアウォールのプロンプトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-274">**Important**  When you first launch the tapper tool, you will get a Windows Firewall prompt.</span></span> <span data-ttu-id="dc3e1-275">3 つのチェック ボックスをすべてオンにし、ツールがファイアウォールを通過できるようにする必要があります。そうしないと、ツールが動作せず、通知も表示されません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-275">You MUST select ALL 3 check boxes and allow the tool through the firewall, or the tool will silently fail to work.</span></span>

<span data-ttu-id="dc3e1-276">クイック スタート インストーラーを起動したら、必ず上の手順に従ってファイアウォールのプロンプトで 3 つのチェック ボックスをすべてオンにしてください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-276">After launching the quick start installer, make sure you follow the above instruction to select all 3 check boxes on the firewall prompt.</span></span> <span data-ttu-id="dc3e1-277">さらに、タップ ツールをインストールし、Microsoft Emulator と同じ物理ホスト コンピューターで使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-277">Also, the tapper tool must be installed and used on the same physical host machine as the Microsoft Emulator.</span></span>

### <a name="proximity-mode"></a><span data-ttu-id="dc3e1-278">近接通信モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-278">Proximity mode</span></span>

<span data-ttu-id="dc3e1-279">1 組の電話を互いにタップする操作をシミュレートするには、1 組の Windows Phone 8 エミュレーターを起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-279">To simulate a pair of phones tapping together you'll need to launch a pair of Windows Phone 8 emulators.</span></span> <span data-ttu-id="dc3e1-280">Visual Studio では同一のエミュレーターを 2 つ同時に実行することはできないため、これを回避するため、エミュレーターごとに異なる解像度を選ぶ必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-280">Since Visual Studio doesn't support running two identical emulators at the same time, you'll need to select different resolutions for each of the emulators to work around it.</span></span>

![NFC 近接通信ページ](images/emulator-nfc-proximity.png)

<span data-ttu-id="dc3e1-282">**[ピア デバイスの検出を有効にする]** チェック ボックスをオンにすると、**[ピア デバイス]** ドロップダウン ボックスに Microsoft Emulators (同じ物理ホスト コンピューターまたはローカル ネットワークで実行) とシミュレーター ドライバーを実行している Windows コンピューター (同じコンピューターまたはローカル ネットワークで実行) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-282">When you check the **Enable discovery of peer devices** checkbox, the **Peer device** dropdown box shows Microsoft Emulators (running on the same physical host machine or in the local network) as well as the Windows machines running the simulator driver (running on the same machine or in the local network).</span></span>

<span data-ttu-id="dc3e1-283">両方のエミュレーターが実行されたら、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-283">Once both emulators are running:</span></span>

-   <span data-ttu-id="dc3e1-284">**[ピア デバイス]** ボックスの一覧で、対象とするエミュレーターを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-284">Select the emulator you would like to target in the **Peer device** list.</span></span>
-   <span data-ttu-id="dc3e1-285">**[ピア デバイスに送信]** ラジオ ボタンをオンにします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-285">Select the **Send to peer device** radio button.</span></span>
-   <span data-ttu-id="dc3e1-286">**[タップ]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-286">Click **Tap** button.</span></span> <span data-ttu-id="dc3e1-287">これにより、2 つのデバイスを互いにタップする操作がシミュレートされ、NFC タップ通知音が鳴ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-287">This will simulate the two devices tapping together and you should be hearing the NFC tap notification sound</span></span>
-   <span data-ttu-id="dc3e1-288">2 つのデバイスを切断するには、**[アンタップ]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-288">To disconnect the 2 devices, simply hit the **Untap** button.</span></span>

<span data-ttu-id="dc3e1-289">または、**[この秒数後に自動的にアンタップする]** チェック ボックスをオンにすると、デバイスをタップした状態にする秒数を指定でき、指定した秒数が経過すると自動的にアンタップされます (実際のユーザーに対して何が予想されるかをシミュレートしているため、電話を互いにタップするのは短時間と考えられます)。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-289">Alternatively, you can enable **Automatically untap in (seconds)** check box where you can specify the number of seconds you want the devices to be tapped and they will be automatically untapped after the specified number of seconds (simulating what would be expected of a user in real life, they would only hold their phones together for a short time).</span></span> <span data-ttu-id="dc3e1-290">ただし、現在のところ接続がアンタップされた後はメッセージ ログを使用できない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-290">Note however that currently the message log isn't available after the connection has been untapped.</span></span>

<span data-ttu-id="dc3e1-291">タグからのメッセージを読む操作や他のデバイスからのメッセージを受信する操作をシミュレートするには、次のようにします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-291">To simulate reading messages from a tag or receiving messages from another device:</span></span>

-   <span data-ttu-id="dc3e1-292">**[自分に送信]** ラジオ ボタンをオンにし、NFC 対応デバイスが 1 台だけ必要なシナリオをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-292">Select the **Send to self** radio button to test scenarios that require only one NFC enabled device.</span></span>
-   <span data-ttu-id="dc3e1-293">**[タップ]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-293">Click **Tap** button.</span></span> <span data-ttu-id="dc3e1-294">これにより、デバイスをタグにタップする操作がシミュレートされ、NFC タップ通知音が鳴ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-294">This will simulate the tapping a device to a tag and you should be hearing the NFC tap notification sound</span></span>
-   <span data-ttu-id="dc3e1-295">切断するには、**[アンタップ]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-295">To disconnect, simply hit the **Untap** button.</span></span>

<span data-ttu-id="dc3e1-296">近接通信モードを使うと、タグまたは別のピア デバイスから送信されたかのようにメッセージを挿入できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-296">Using the proximity mode you can inject messages as if they came from a tag or another peer device.</span></span> <span data-ttu-id="dc3e1-297">このツールを使うと、次の種類のメッセージを送信できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-297">The toolallows you to send messages of the following types.</span></span>

-   <span data-ttu-id="dc3e1-298">WindowsURI</span><span class="sxs-lookup"><span data-stu-id="dc3e1-298">WindowsURI</span></span>
-   <span data-ttu-id="dc3e1-299">WindowsMime</span><span class="sxs-lookup"><span data-stu-id="dc3e1-299">WindowsMime</span></span>
-   <span data-ttu-id="dc3e1-300">WritableTag</span><span class="sxs-lookup"><span data-stu-id="dc3e1-300">WritableTag</span></span>
-   <span data-ttu-id="dc3e1-301">Pairing:Bluetooth</span><span class="sxs-lookup"><span data-stu-id="dc3e1-301">Pairing:Bluetooth</span></span>
-   <span data-ttu-id="dc3e1-302">NDEF</span><span class="sxs-lookup"><span data-stu-id="dc3e1-302">NDEF</span></span>
-   <span data-ttu-id="dc3e1-303">NDEF:MIME</span><span class="sxs-lookup"><span data-stu-id="dc3e1-303">NDEF:MIME</span></span>
-   <span data-ttu-id="dc3e1-304">NDEF:URI</span><span class="sxs-lookup"><span data-stu-id="dc3e1-304">NDEF:URI</span></span>
-   <span data-ttu-id="dc3e1-305">NDEF:wkt.U</span><span class="sxs-lookup"><span data-stu-id="dc3e1-305">NDEF:wkt.U</span></span>

<span data-ttu-id="dc3e1-306">これらのメッセージは、**[ペイロード]** ウィンドウで編集するか、ファイルに入力することで作ることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-306">You can either create these messages by editing the **Payload** windows or providing them in a file.</span></span> <span data-ttu-id="dc3e1-307">これらの種類とその使用方法について詳しくは、[**ProximityDevice.PublishBinaryMessage**](https://msdn.microsoft.com/library/windows/apps/Hh701129) のリファレンス ページの「注釈」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-307">For more information about these types and how to use them please refer to the Remarks section of the[**ProximityDevice.PublishBinaryMessage**](https://msdn.microsoft.com/library/windows/apps/Hh701129) reference page.</span></span>

<span data-ttu-id="dc3e1-308">Windows 8 Driver Kit (WDK) には、Windows Phone 8 エミュレーターと同じプロトコルを公開しているドライバー サンプルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-308">The Windows 8 Driver Kit (WDK) includes a driver sample that exposes the same protocol as the Windows Phone 8 emulator.</span></span> <span data-ttu-id="dc3e1-309">DDK をダウンロードしてそのサンプル ドライバーをビルドし、Windows 8 デバイスにインストールした後、Windows 8 デバイスの IP アドレスまたはホスト名をデバイス リストに追加し、別の Windows 8 デバイスまたは Windows Phone 8 エミュレーターを使ってタップします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-309">You'll need to download the DDK, build that sample driver, install it on a Windows 8 device, then add the Windows 8 device's IP address or hostname to the devices list and tap it either with another Windows 8 device or with a Windows Phone 8 emulator.</span></span>

### <a name="host-card-emulation-hce-mode"></a><span data-ttu-id="dc3e1-310">ホスト カード エミュレーション (HCE) モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-310">Host Card Emulation (HCE) Mode</span></span>

<span data-ttu-id="dc3e1-311">ホスト カード エミュレーション (HCE) モードでは、販売時点管理 (POS) 端末などのスマート カード リーダーをシミュレートする独自のカスタム スクリプトを記述して、HCE ベースのカード エミュレーション アプリケーションをテストできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-311">In Host Card Emulation (HCE) mode you can test your HCE-based card emulation application by writing your own custom scripts to simulate a smart card reader terminal, such as a Point of Sale (POS) terminal.</span></span> <span data-ttu-id="dc3e1-312">このツールは、リーダー端末 (POS、バッジ リーダー、輸送カード リーダーなど) とスマート カード (アプリケーションでエミュレートするカード) の間で送信されるコマンド応答ペア (ISO-7816-4 に準拠) に精通していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-312">This tool assumes that you are familiar with the command response pairs (compliant with ISO-7816-4) that are sent between a reader terminal (such as POS, badge reader or transit card reader) and the smart card (that you are emulating in your application).</span></span>

![NFC HCE ページ](images/emulator-nfc-hce.png)

-   <span data-ttu-id="dc3e1-314">スクリプト エディター セクションで **[追加]** ボタンをクリックして、新しいスクリプトを作ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-314">Create a new script by clicking the **Add** button in the script editor section.</span></span> <span data-ttu-id="dc3e1-315">スクリプトの名前を指定できます。編集が完了したら、**[保存]** ボタンを使ってスクリプトを保存できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-315">You can provide a name for your script and after you are done with editing, you can save your script using the **Save** button.</span></span>
-   <span data-ttu-id="dc3e1-316">保存されたスクリプトは、次回エミュレーターを起動したときに使うことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-316">Your saved scripts will be available the next time you launch the emulator.</span></span>
-   <span data-ttu-id="dc3e1-317">スクリプト エディター ウィンドウで **[再生]** ボタンをクリックして、スクリプトを実行します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-317">Run your scripts by hitting the **Play** button in the scripts editor window.</span></span> <span data-ttu-id="dc3e1-318">この操作の結果、電話を端末にタップし、スクリプトに記述されたコマンドが送信される操作がシミュレートされます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-318">This action results in simulating of tapping your phone to the terminal and sending commands written in your script.</span></span> <span data-ttu-id="dc3e1-319">または、**[タップ]** ボタンをクリックして **[再生]** ボタンをクリックします。**[再生]** をクリックするまで、スクリプトは実行されません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-319">Alternatively you can hit the **Tap** button and then the **Play** button, until you hit **Play** the script will not run.</span></span>
-   <span data-ttu-id="dc3e1-320">**[停止]** ボタンをクリックしてコマンドの送信を停止します。これにより、アプリケーションへのコマンドの送信が停止されますが、**[アンタップ]** ボタンをクリックするまでデバイスはタップされたままです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-320">Stop sending commands by hitting the **Stop** button, which stops sending the commands to your application but the devices remain tapped until you hit the **Untap** button.</span></span>
-   <span data-ttu-id="dc3e1-321">ドロップダウン メニューでスクリプトを選んで **[削除]** ボタンをクリックし、スクリプトを削除します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-321">Delete your scripts by selecting the script in the dropdown menu and hitting **Delete** button.</span></span>
-   <span data-ttu-id="dc3e1-322">**[再生]** ボタンを使ってスクリプトを実行するまで、エミュレーター ツールはスクリプトの構文をチェックしません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-322">The emulator tool does not check for the syntax of your scripts until you run the script using the **Play** button.</span></span> <span data-ttu-id="dc3e1-323">スクリプトによって送信されるメッセージは、カード エミュレーション アプリの実装によって異なります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-323">The messages sent by your script are dependent on your implementation of your card emulation app.</span></span>

<span data-ttu-id="dc3e1-324">支払いアプリのテストには、MasterCard の端末シミュレーター ツール ([https://www.terminalsimulator.com/ ](https://www.terminalsimulator.com/ )) を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-324">You can also use the terminal simulator tool from MasterCard ([https://www.terminalsimulator.com/](https://www.terminalsimulator.com/ )) for payments app testing.</span></span>

-   <span data-ttu-id="dc3e1-325">スクリプト エディター ウィンドウの下にある **[MasterCard リスナーを有効にする]** チェック ボックスをオンにし、MasterCard のシミュレーターを起動します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-325">Check the **Enable MasterCard** listener checkbox below the script editor windows and launch the simulator from MasterCard.</span></span>
-   <span data-ttu-id="dc3e1-326">このツールを使うと、NFC ツールを通じてエミュレーターで実行されているアプリケーションに中継されるコマンドを生成することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-326">Using the tool, you can generate commands that are relayed to your application running on the emulator through the NFC tool.</span></span>

<span data-ttu-id="dc3e1-327">HCE のサポートと Windows 10 Mobile で HCE アプリを開発する方法について詳しくは、[Microsoft NFC チームのブログ](http://go.microsoft.com/fwlink/?LinkId=534749)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-327">To learn more about HCE support and how to develop HCE apps in Windows 10 Mobile, please refer to the [Microsoft NFC Team Blog](http://go.microsoft.com/fwlink/?LinkId=534749).</span></span>

### <a name="how-to-create-scripts-for-hce-testing"></a><span data-ttu-id="dc3e1-328">HCE テスト用のスクリプトを作る方法</span><span class="sxs-lookup"><span data-stu-id="dc3e1-328">How to Create Scripts for HCE Testing</span></span>

<span data-ttu-id="dc3e1-329">スクリプトは、C# コードとして記述され、**[再生]** ボタンをクリックするとスクリプトの Run メソッドが呼び出されます。このメソッドは、APDU コマンドの送受信に使われる IScriptProcessor インターフェイスを取得してログ ウィンドウに出力し、電話からの APDU 応答を待機する場合のタイムアウトを制御します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-329">The scripts are written as C# code and your script’s Run method is called when you click the **Play** button, this method takes an IScriptProcessor interface which is used to transceive APDU commands, output to the log window, and control the timeout for waiting on an APDU response from the phone.</span></span>

<span data-ttu-id="dc3e1-330">以下に、使用可能な機能の参考例を示します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-330">Below is a reference on what functionality is available:</span></span>

```csharp     
        public interface IScriptProcessor
        {
            // Sends an APDU command given as a hex-encoded string, and returns the APDU response
            string Send(string s);

            // Sends an APDU command given as a byte array, and returns the APDU response
            byte[] Send(byte[] s);

            // Logs a string to the log window
            void Log(string s);

            // Logs a byte array to the log window
            void Log(byte[] s);

            // Sets the amount of time the Send functions will wait for an APDU response, after which
            // the function will fail
            void SetResponseTimeout(double seconds);
        }
```

### <a name="smart-card-reader-mode"></a><span data-ttu-id="dc3e1-331">スマート カード リーダー モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-331">Smart Card Reader Mode</span></span>

<span data-ttu-id="dc3e1-332">エミュレーターは、ホスト コンピューター上のスマート カード リーダー デバイスに接続できます。そのようにすると、挿入またはタップされたスマート カードが電話アプリケーションに表示され、[**Windows.Devices.SmartCards.SmartCardConnection**](https://msdn.microsoft.com/library/windows/apps/Dn608002) クラスを使って APDU と通信できるようになります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-332">The emulator can be connected to a smart card reader device on your host computer, such that smart cards inserted or tapped will show up to your phone application and can be communicated to with APDUs using the [**Windows.Devices.SmartCards.SmartCardConnection**](https://msdn.microsoft.com/library/windows/apps/Dn608002) class.</span></span> <span data-ttu-id="dc3e1-333">これを実現するには、互換性のあるスマート カード リーダー デバイスをコンピューターに接続する必要があります。USB スマート カード リーダー (NFC/非接触型および挿入/接触型) は、簡単に入手することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-333">For this to work, you will need a compatible smart card reader device attached to your computer, USB smart card readers (both NFC/contactless and insert/contact) are widely available.</span></span> <span data-ttu-id="dc3e1-334">エミュレーターが接続されたスマート カード リーダーとやり取りできるようにするには、まず**カード リーダー** モードを選ぶと、ホスト システムに接続された互換性のあるスマート カード リーダーがすべて一覧表示されたドロップダウン ボックスが表示されます。次に、接続先のスマート カード リーダー デバイスをドロップダウンから選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-334">To enable the emulator to work with an attached smart card reader, first choose the **Card Reader** mode which should show a dropdown box listing all the compatible smart card readers attached to the host system, then choose the smart card reader device you’d like to be connected from the dropdown.</span></span>

<span data-ttu-id="dc3e1-335">NFC 対応スマート カード リーダーの中には、一部の種類の NFC カードがサポートされないものや、標準 PC/SC メモリ カード APDU コマンドがサポートされないものがある点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-335">Note that not all NFC-capable smart card readers support some types of NFC cards, and some do not support the standard PC/SC storage card APDU commands.</span></span>

## <a name="multi-point-input"></a><span data-ttu-id="dc3e1-336">マルチポイント入力</span><span class="sxs-lookup"><span data-stu-id="dc3e1-336">Multi-point input</span></span>

<span data-ttu-id="dc3e1-337">エミュレーター ツール バーの [**マルチタッチ入力**] を使って、オブジェクトのピンチとズーム、回転、パンのマルチタッチ入力をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-337">Simulate multi-touch input for pinching and zooming, rotating, and panning objects by using the **Multi-touch Input** button on the emulator toolbar.</span></span> <span data-ttu-id="dc3e1-338">この機能を使うと、アプリが写真、地図、またはユーザーがピンチとズーム、回転、またはパンできるその他の視覚要素を表示する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-338">This feature is useful if your app displays photos, maps, or other visual elements that users can pinch and zoom, rotate, or pan.</span></span>

1.  <span data-ttu-id="dc3e1-339">エミュレーター ツール バーの [**マルチタッチ入力**] をタップしてマルチポイント入力を有効にします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-339">Tap the **Multi-touch Input** button on the emulator toolbar to enable multi-point input.</span></span> <span data-ttu-id="dc3e1-340">エミュレーター画面の中心点の周囲に 2 つのタッチ ポイントが表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-340">Two touch points appear on the emulator screen around a center point.</span></span>
2.  <span data-ttu-id="dc3e1-341">画面にタッチすることなく配置を変更するには、いずれかのタッチ ポイントを右クリックしてドラッグします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-341">Right-click and drag one of the touch points to position them without touching the screen.</span></span>
3.  <span data-ttu-id="dc3e1-342">ピンチとズーム、回転、またはパンをシミュレートするには、いずれかのタッチ ポイントを左クリックしてドラッグします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-342">Left-click and drag one of the touch points to simulate pinching and zooming, rotating, or panning.</span></span>
4.  <span data-ttu-id="dc3e1-343">エミュレーター ツール バーの [**Single Point Input**] (シングル ポイント入力) をタップして通常の入力に戻します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-343">Tap the **Single Point Input** button on the emulator toolbar to restore normal input.</span></span>

<span data-ttu-id="dc3e1-344">次のスクリーンショットは、マルチタッチ入力を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-344">The following screenshot shows multi-touch input.</span></span>

1.  <span data-ttu-id="dc3e1-345">小さい左の画像は、エミュレーター ツール バーの [**マルチタッチ入力**] を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-345">The small left image shows the **Multi-touch Input** button on the emulator toolbar.</span></span>
2.  <span data-ttu-id="dc3e1-346">真ん中の画像は、[**マルチタッチ入力**] をタップした後の、タッチ ポイントを表示するエミュレーター画面を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-346">The middle image shows the emulator screen after tapping the **Multi-touch Input** button to display the touch points.</span></span>
3.  <span data-ttu-id="dc3e1-347">右の画像は、イメージをズームするためにタッチ ポイントをドラッグした後のエミュレーター画面を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-347">The right image shows the emulator screen after dragging the touch points to zoom the image.</span></span>

![エミュレーター ツール バーのマルチポイント入力オプション](images/em-multipoint.png)

## <a name="accelerometer"></a><span data-ttu-id="dc3e1-349">加速度計</span><span class="sxs-lookup"><span data-stu-id="dc3e1-349">Accelerometer</span></span>

<span data-ttu-id="dc3e1-350">エミュレーターの [**その他のツール**] の [**加速度計**] タブを使って、電話の動きを追跡するアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-350">Test apps that track the movement of the phone by using the **Accelerometer** tab of the emulator's **Additional Tools**.</span></span>

<span data-ttu-id="dc3e1-351">ライブ入力または事前に記録した入力を使って加速度計センサーをテストできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-351">You can test the accelerometer sensor with live input or pre-recorded input.</span></span> <span data-ttu-id="dc3e1-352">使用できる記録済みのデータの種類は、電話をシェイクする動作をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-352">The only type of recorded data that’s available simulates shaking the phone.</span></span> <span data-ttu-id="dc3e1-353">加速度計の独自のシミュレーションを記録または保存することはできません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-353">You can’t record or save your own simulations for the accelerometer.</span></span>

1.  <span data-ttu-id="dc3e1-354">[**向き**] ドロップダウン リストから目的の開始方向をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-354">Select the desired starting orientation in the **Orientation** drop-down list.</span></span>

2.  -   <span data-ttu-id="dc3e1-355">入力の種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-355">Select the type of input.</span></span>

        **<span data-ttu-id="dc3e1-356">ライブ入力を使ってシミュレーションを実行するには</span><span class="sxs-lookup"><span data-stu-id="dc3e1-356">To run the simulation with live input</span></span>**

        <span data-ttu-id="dc3e1-357">加速度計シミュレーターの中央で、色の付いたドットをドラッグして 3D でのデバイスの動きをシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-357">In the middle of the accelerometer simulator, drag the colored dot to simulate movement of the device in a 3D plane.</span></span>

        <span data-ttu-id="dc3e1-358">水平アクセスのドットを動かすと、シミュレーターが左右に回転します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-358">Moving the dot on the horizontal access rotates the simulator from side to side.</span></span> <span data-ttu-id="dc3e1-359">垂直アクセスのドットを動かすと、x 軸を中心としてシミュレーターが前後に回転します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-359">Moving the dot on the vertical access rotates the simulator back and forth, rotating around the x-axis.</span></span> <span data-ttu-id="dc3e1-360">ドットをドラッグすると、X、Y、Z 座標が回転の計算に基づいて更新されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-360">As you drag the dot, the X, Y, and Z coordinates update based on the rotation calculations.</span></span> <span data-ttu-id="dc3e1-361">タッチ パッド領域の境界の円の外側にドットを動かすことはできません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-361">You cannot move the dot outside the bounding circle in the touch pad area.</span></span>

        <span data-ttu-id="dc3e1-362">必要に応じて、[**リセット**] をクリックして開始方向を復元します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-362">Optionally, click **Reset** to restore the starting orientation.</span></span>

    -   **<span data-ttu-id="dc3e1-363">記録された入力を使ってシミュレーションを実行するには</span><span class="sxs-lookup"><span data-stu-id="dc3e1-363">To run the simulation with recorded input</span></span>**

        <span data-ttu-id="dc3e1-364">[**Recorded Data**] (記録されたデータ) セクションで、[**再生**] をクリックしてシミュレートされたデータの再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-364">In the **Recorded Data** section, click the **Play** button to start playback of the simulated data.</span></span> <span data-ttu-id="dc3e1-365">[**Recorded Data**] (記録されたデータ) リストで利用できるオプションはシェイクのみです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-365">The only option available in the **Recorded Data** list is shake.</span></span> <span data-ttu-id="dc3e1-366">シミュレーターはデータの再生時に画面上で動きません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-366">The simulator does not move on the screen when it plays back the data.</span></span>

![エミュレーターのその他のツールの加速度計ページ](images/em-accelerometer.png)

## <a name="location-and-driving"></a><span data-ttu-id="dc3e1-368">位置とドライブ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-368">Location and driving</span></span>

<span data-ttu-id="dc3e1-369">エミュレーターの [**その他のツール**] の [**位置**] タブを使って、ナビゲーションまたはジオフェンスを使うアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-369">Test apps that use navigation or geofencing by using the **Location** tab of the emulator's **Additional Tools**.</span></span> <span data-ttu-id="dc3e1-370">この機能は、現実の世界と同様の条件でドライブ、自転車移動、ウォーキングをシミュレートするために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-370">This feature is useful for simulating driving, biking, or walking in conditions similar to the real world.</span></span>

<span data-ttu-id="dc3e1-371">さまざまな速度や精度プロファイルである場所から別の場所への移動をシミュレートして、アプリをテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-371">You can test your app while you simulate moving from one location to another at different speeds and with different accuracy profiles.</span></span> <span data-ttu-id="dc3e1-372">位置シミュレーターを使うことで、ユーザー エクスペリエンスを向上させるための位置情報 API の利用方法の変更を判別できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-372">The location simulator can help you to identify changes in your usage of the location APIs usage that improve the user experience.</span></span> <span data-ttu-id="dc3e1-373">たとえば、さまざまなシナリオでジオフェンスを正しく検出するために、サイズやドウェル時間などのジオフェンス パラメーターを調整する必要があることを判別することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-373">For example, the tool can help you identify that you have to tune geofence parameters, such as size or dwell time, to detect the geofences successfully in different scenarios.</span></span>

<span data-ttu-id="dc3e1-374">[**位置**] タブは 3 つのモードをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-374">The **Location** tab supports three modes.</span></span> <span data-ttu-id="dc3e1-375">すべてのモードで、エミュレーターが新しい位置を受け取ると、位置認識アプリでその位置を [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/BR225540) イベントのトリガーや、[**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/Hh973536) 呼び出しへの応答に利用することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-375">In all modes, when the emulator receives a new position, that position is available to trigger the [**PositionChanged**](https://msdn.microsoft.com/library/windows/apps/BR225540) event or to respond to a [**GetGeopositionAsync**](https://msdn.microsoft.com/library/windows/apps/Hh973536) call in your location-aware app.</span></span>

-   <span data-ttu-id="dc3e1-376">**[ピン]** モードでは、地図にプッシュピンを配置します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-376">In **Pin** mode, you place pushpins on the map.</span></span> <span data-ttu-id="dc3e1-377">[**Play all points**] (すべてのポイントを再生) をクリックすると、位置シミュレーターが [**Seconds per pin**] (ピンごとの秒数) テキスト ボックスで指定された間隔で各ピンの位置を次々にエミュレーターに送ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-377">When you click **Play all points**, the location simulator sends the location of each pin to the emulator one after another, at the interval specified in the **Seconds per pin** text box.</span></span>

-   <span data-ttu-id="dc3e1-378">[**ライブ**] モードでは、地図にプッシュピンを配置します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-378">In **Live** mode, you place pushpins on the map.</span></span> <span data-ttu-id="dc3e1-379">ピンを地図上に配置するとすぐに、位置シミュレーターが各ピンの位置をエミュレーターに送ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-379">The location simulator sends the location of each pin to the emulator immediately as you place them on the map.</span></span>

-   <span data-ttu-id="dc3e1-380">[**ルート**] モードでは、地図にプッシュピンを配置して中間地点を示すと、位置シミュレーターが自動的にルートを計算します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-380">In **Route** mode, you place pushpins on the map to indicate waypoints, and the location simulator automatically calculates a route.</span></span> <span data-ttu-id="dc3e1-381">ルートには、ルートに沿って 1 秒間隔で表示されないピンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-381">The route includes invisible pins at one-second intervals along the route.</span></span> <span data-ttu-id="dc3e1-382">たとえば、毎時 5 km の速度を想定する [**Walking**] (ウォーキング) 速度プロファイルを選んだ場合、表示されないピンが 1.39 m 間隔で生成されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-382">For example, if you have select the **Walking** speed profile, which assumes a speed of 5 kilometers per hour, then invisible pins are generated at intervals of 1.39 meters.</span></span> <span data-ttu-id="dc3e1-383">[**Play all points**] (すべてのポイントを再生) をクリックすると、位置シミュレーターがドロップダウン リストで選ばれた速度プロファイルによって決定された間隔で各ピンの位置を次々にエミュレーターに送ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-383">When you click **Play all points**, the location simulator sends the location of each pin to the emulator one after another, at the interval determined by the speed profile selected in the drop-down list.</span></span>

<span data-ttu-id="dc3e1-384">位置シミュレーターのすべてのモードで、次のことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-384">In all modes of the location simulator, you can do the following things.</span></span>

-   <span data-ttu-id="dc3e1-385">[**検索**] ボックスを使って位置を検索できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-385">You can search for a location by using the **Search** box.</span></span>

-   <span data-ttu-id="dc3e1-386">地図の **[拡大]** と **[縮小]** ができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-386">You can **Zoom in** and **Zoom out** on the map.</span></span>

-   <span data-ttu-id="dc3e1-387">現在のデータ ポイントのセットを XML ファイルに保存し、後で再読み込みして同じデータ ポイントを再利用することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-387">You can save the current set of data points to an XML file, and reload the file later to reuse the same data points.</span></span>

-   <span data-ttu-id="dc3e1-388">[**Toggle pushpin mode on or off**] (プッシュピン モードのオンとオフの切り替え) と [**Clear all points**] (すべてのポイントのクリア) ができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-388">You can **Toggle pushpin mode on or off** and **Clear all points**.</span></span>

<span data-ttu-id="dc3e1-389">ピン モードとルート モードでは、次のこともできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-389">In Pin and Route mode, you can also do the following things.</span></span>

-   <span data-ttu-id="dc3e1-390">作成したルートを保存して後で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-390">Save a route you created for later use.</span></span>

-   <span data-ttu-id="dc3e1-391">以前に作成したルートを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-391">Load a route previously created.</span></span> <span data-ttu-id="dc3e1-392">以前のバージョンのツールで作成されたルート ファイルを読み込むこともできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-392">You can even load route files created in previous versions of the tool.</span></span>

-   <span data-ttu-id="dc3e1-393">プッシュピン (ピン モード) または中間点 (ルート モード) を削除することでルートを修正できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-393">Modify a route by deleting pushpins (in Pin mode) or waypoints (in Route mode).</span></span>

**<span data-ttu-id="dc3e1-394">精度プロファイル</span><span class="sxs-lookup"><span data-stu-id="dc3e1-394">Accuracy profiles</span></span>**

<span data-ttu-id="dc3e1-395">位置シミュレーターのすべてのモードで、[**Accuracy profile**] (精度プロファイル) ドロップダウン リストから次のいずれかの精度プロファイルを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-395">In all modes of the location simulator, you can select one of the following accuracy profiles in the **Accuracy profile** drop-down list.</span></span>

| <span data-ttu-id="dc3e1-396">プロファイル</span><span class="sxs-lookup"><span data-stu-id="dc3e1-396">Profile</span></span>  | <span data-ttu-id="dc3e1-397">説明</span><span class="sxs-lookup"><span data-stu-id="dc3e1-397">Description</span></span>                                        |
|----------|----------------------------------------------------|
| <span data-ttu-id="dc3e1-398">Pinpoint (ピンポイント)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-398">Pinpoint</span></span> | <span data-ttu-id="dc3e1-399">完全に正確な位置の読み取りを想定します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-399">Assumes perfectly accurate location readings.</span></span> <span data-ttu-id="dc3e1-400">この設定は現実的ではありませんが、アプリのロジックをテストする場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-400">This setting is not realistic, but it's useful for testing the logic of your app.</span></span>  |
| <span data-ttu-id="dc3e1-401">Urban (都市)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-401">Urban</span></span>    | <span data-ttu-id="dc3e1-402">利用できる衛星の数が建物によって制限されるものの、位置決定に使うことができる携帯電話の基地局や Wi-Fi アクセス ポイントが多くの場合高密度で存在すると想定します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-402">Assumes that buildings are restricting the number of satellites in view, but there is often a high density of cell towers and Wi-Fi access points that can be used for positioning.</span></span> |
| <span data-ttu-id="dc3e1-403">郊外 (Suburban)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-403">Suburban</span></span> | <span data-ttu-id="dc3e1-404">衛星による位置決定を比較的良好に行うことができ、携帯電話の基地局の密度も高いものの、Wi-Fi アクセス ポイントの密度は高くないと想定します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-404">Assumes that satellite positioning is relatively good and there is good density of cell towers, but the density of Wi-Fi access points is not high.</span></span>  |
| <span data-ttu-id="dc3e1-405">Rural (地方)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-405">Rural</span></span>    | <span data-ttu-id="dc3e1-406">衛星による位置決定を良好に行うことができるものの、位置決定に使うことができる携帯電話の基地局の密度は低く、Wi-Fi アクセス ポイントはほとんどないと想定します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-406">Assumes that satellite positioning is good, but there is low density of cell towers and almost no Wi-Fi access points that can be used for positioning.</span></span> |

**<span data-ttu-id="dc3e1-407">速度プロファイル</span><span class="sxs-lookup"><span data-stu-id="dc3e1-407">Speed profiles</span></span>**

<span data-ttu-id="dc3e1-408">[**ルート**] モードでは、ドロップダウン リストから次のいずれかの速度プロファイルを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-408">In **Route** mode, you can select one of the following speed profiles in the drop-down list.</span></span>

| <span data-ttu-id="dc3e1-409">プロファイル</span><span class="sxs-lookup"><span data-stu-id="dc3e1-409">Profile</span></span> | <span data-ttu-id="dc3e1-410">時速</span><span class="sxs-lookup"><span data-stu-id="dc3e1-410">Speed per hour</span></span>               | <span data-ttu-id="dc3e1-411">秒速</span><span class="sxs-lookup"><span data-stu-id="dc3e1-411">Speed per second</span></span> | <span data-ttu-id="dc3e1-412">説明</span><span class="sxs-lookup"><span data-stu-id="dc3e1-412">Description</span></span> | 
|---------|------------------------------|------------------|-------------|
| <span data-ttu-id="dc3e1-413">Speed Limit (制限速度)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-413">Speed Limit</span></span> | <span data-ttu-id="dc3e1-414">ルートの速度制限</span><span class="sxs-lookup"><span data-stu-id="dc3e1-414">Speed limit of the route</span></span> | <span data-ttu-id="dc3e1-415">該当なし</span><span class="sxs-lookup"><span data-stu-id="dc3e1-415">Not applicable</span></span>   | <span data-ttu-id="dc3e1-416">ポストされた制限速度でルートをスキャンします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-416">Traverse the route at the posted speed limit.</span></span> |
| <span data-ttu-id="dc3e1-417">Walking (ウォーキング)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-417">Walking</span></span>     | <span data-ttu-id="dc3e1-418">5 km/時</span><span class="sxs-lookup"><span data-stu-id="dc3e1-418">5 km/h</span></span>                   | <span data-ttu-id="dc3e1-419">1.39 m</span><span class="sxs-lookup"><span data-stu-id="dc3e1-419">1.39 m</span></span>           | <span data-ttu-id="dc3e1-420">自然な歩行ペースの 5 km/時でルートをスキャンします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-420">Traverse the route at a natural walking pace of 5 km/h.</span></span> |
| <span data-ttu-id="dc3e1-421">Biking (自転車移動)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-421">Biking</span></span>      | <span data-ttu-id="dc3e1-422">25 km/時</span><span class="sxs-lookup"><span data-stu-id="dc3e1-422">25 km/h</span></span>                  | <span data-ttu-id="dc3e1-423">6.94 m</span><span class="sxs-lookup"><span data-stu-id="dc3e1-423">6.94 m</span></span>           | <span data-ttu-id="dc3e1-424">自然な自転車移動ペースの 25 km/時でルートをスキャンします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-424">Traverse the route at a natural biking pace of 25 km/h.</span></span> |
| <span data-ttu-id="dc3e1-425">Fast (高速)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-425">Fast</span></span>        |                          |                  |<span data-ttu-id="dc3e1-426">ポストされた制限速度よりも高速でルートをスキャンします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-426">Traverse the route faster than the posted speed limit.</span></span> | 

**<span data-ttu-id="dc3e1-427">ルート モード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-427">Route mode</span></span>**

<span data-ttu-id="dc3e1-428">ルート モードには次の機能と制限事項があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-428">Route mode has the following features and limitations.</span></span>

-   <span data-ttu-id="dc3e1-429">ルート モードにはインターネット接続が必要です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-429">Route mode requires an Internet connection.</span></span>

-   <span data-ttu-id="dc3e1-430">都市、郊外、または地方の精度プロファイルが選ばれていると、位置シミュレーターはシミュレートされた衛星ベースの位置、シミュレートされた Wi-Fi 位置、シミュレートされた携帯電話位置を各ピンに計算します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-430">When the Urban, Suburban, or Rural accuracy profile is selected, the location simulator calculates a simulated satellite-based position, a simulated Wi-Fi position, and a simulated cellular position for each pin.</span></span> <span data-ttu-id="dc3e1-431">アプリはこれらの位置のいずれかのみを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-431">Your app receives only one of these positions.</span></span> <span data-ttu-id="dc3e1-432">現在の場所の座標の 3 つのセットが地図と [**現在の場所**] リストに異なる色で表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-432">The three sets of coordinates for the current location are displayed in different colors on the map and in the **Current location** list.</span></span>

-   <span data-ttu-id="dc3e1-433">ルートに沿ったピンの精度は均一ではありません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-433">The accuracy of the pins along route the route is not uniform.</span></span> <span data-ttu-id="dc3e1-434">一部のピンは衛星精度を使い、一部のピンは Wi-Fi 精度を使い、一部のピンは携帯電話精度を使います。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-434">Some of the pins use satellite accuracy, some use Wi-Fi accuracy, and some use cellular accuracy.</span></span>

-   <span data-ttu-id="dc3e1-435">ルートに 20 個を超える中間点を選ぶことはできません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-435">You cannot select more than 20 waypoints for the route.</span></span>

-   <span data-ttu-id="dc3e1-436">地図上の表示されているピンと表示されていないピンの位置は、新しい精度プロファイルを選んだときに一度だけ生成されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-436">Positions for the visible and invisible pins on the map are generated only once when you select a new accuracy profile.</span></span> <span data-ttu-id="dc3e1-437">同じエミュレーター セッションで同じ精度プロファイルを使ってルートを 2 回以上再生すると、前に生成された位置が再利用されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-437">When you play the route more than once with the same accuracy profile during the same emulator session, the previously generated positions are reused.</span></span>

<span data-ttu-id="dc3e1-438">次のスクリーン ショットは、ルート モードを示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-438">The following screenshot shows Route mode.</span></span> <span data-ttu-id="dc3e1-439">オレンジ色の線はルートを示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-439">The orange line indicates the route.</span></span> <span data-ttu-id="dc3e1-440">青いドットは衛星ベースで位置決定された正確な車の場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-440">The blue dot indicates the accurate location of the car determined by satellite-based positioning.</span></span> <span data-ttu-id="dc3e1-441">赤のドットと緑のドットは、Wi-Fi と携帯電話の位置決定と郊外精度プロファイルを使って計算された、精度の劣る位置を示しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-441">The red and green dots indicate less accurate locations calculated by using Wi-Fi and cellular positioning and the Suburban accuracy profile.</span></span> <span data-ttu-id="dc3e1-442">計算された 3 つの位置も [**現在の場所**] リストに表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-442">The three calculated locations are also displayed in the **Current location** list.</span></span>

![エミュレーターのその他のツールの位置ページ](images/em-drive.png)

**<span data-ttu-id="dc3e1-444">位置シミュレーターの詳細</span><span class="sxs-lookup"><span data-stu-id="dc3e1-444">More info about the location simulator</span></span>**

-   <span data-ttu-id="dc3e1-445">精度が既定に設定された位置を要求できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-445">You can request a position with the accuracy set to Default.</span></span> <span data-ttu-id="dc3e1-446">位置シミュレーターの Windows Phone 8 バージョンに存在した、精度が高に設定された位置の要求が必須となる制限が修正されました。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-446">A limitation that existed in the Windows Phone 8 version of the location simulator, and required you to request a position with the accuracy set to High, has been fixed.</span></span>

-   <span data-ttu-id="dc3e1-447">エミュレーターでジオフェンスをテストするときは、ジオフェンス エンジンに「ウォーミングアップ」期間を与えるシミュレーションを作成し、移動パターンを把握して調整します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-447">When you test geofencing in the emulator, create a simulation that gives the geofencing engine a “warm-up” period to learn and adjust to the movement patterns.</span></span>

-   <span data-ttu-id="dc3e1-448">シミュレートされる位置プロパティは、[緯度]、[経度]、[精度]、[PositionSource] (位置ソース) のみです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-448">The only position properties that are simulated are the Latitude, Longitude, Accuracy, and PositionSource.</span></span> <span data-ttu-id="dc3e1-449">位置シミュレーターでは [速度] や [方位] などのその他のプロパティはシミュレートされません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-449">The location simulator does not simulate other properties such as Speed, Heading, and so forth.</span></span>

## <a name="network"></a><span data-ttu-id="dc3e1-450">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="dc3e1-450">Network</span></span>

<span data-ttu-id="dc3e1-451">エミュレーターの [**その他のツール**] の [**ネットワーク**] タブを使って、さまざまなネットワークの速度とシグナルの強さでアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-451">Test your app with different network speeds and different signal strengths by using the **Network** tab of the emulator's **Additional Tools**.</span></span> <span data-ttu-id="dc3e1-452">この機能は、アプリで Web サービスを呼び出す場合や、データを移す場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-452">This feature is useful if your app calls web services or transfers data.</span></span>

<span data-ttu-id="dc3e1-453">ネットワーク シミュレーション機能を使うことで、アプリが現実世界で適切に実行されることを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-453">The network simulation feature helps you to make sure that your app runs well in the real world.</span></span> <span data-ttu-id="dc3e1-454">Windows Phone エミュレーターは、通常は高速 WiFi またはイーサネット接続を備えたコンピューターで実行されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-454">The Windows Phone Emulator runs on a computer that usually has a fast WiFi or Ethernet connection.</span></span> <span data-ttu-id="dc3e1-455">しかし、アプリは通常より低速な携帯電話接続で接続されている電話で実行されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-455">Your app, however, runs on phones that are typically connected over a slower cellular connection.</span></span>

1.  <span data-ttu-id="dc3e1-456">[**ネットワーク シミュレーションを有効にする**] にチェックを入れて、さまざまな速度とシグナルの強さでアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-456">Check **Enable network simulation** to test your app with different network speeds and different signal strengths.</span></span>
2.  <span data-ttu-id="dc3e1-457">[**ネットワークの速度**] ドロップダウン リストで、次のいずれかのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-457">In the **Network speed** dropdown list, select one of the following options:</span></span>
    -   <span data-ttu-id="dc3e1-458">ネットワークなし</span><span class="sxs-lookup"><span data-stu-id="dc3e1-458">No network</span></span>
    -   <span data-ttu-id="dc3e1-459">2G</span><span class="sxs-lookup"><span data-stu-id="dc3e1-459">2G</span></span>
    -   <span data-ttu-id="dc3e1-460">3G</span><span class="sxs-lookup"><span data-stu-id="dc3e1-460">3G</span></span>
    -   <span data-ttu-id="dc3e1-461">4G</span><span class="sxs-lookup"><span data-stu-id="dc3e1-461">4G</span></span>

3.  <span data-ttu-id="dc3e1-462">**[シグナルの強さ]** ドロップダウン リストで、次のいずれかのオプションを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-462">In the **Signal strength** dropdown list, select one of the following options:</span></span>
    -   <span data-ttu-id="dc3e1-463">良い</span><span class="sxs-lookup"><span data-stu-id="dc3e1-463">Good</span></span>
    -   <span data-ttu-id="dc3e1-464">平均</span><span class="sxs-lookup"><span data-stu-id="dc3e1-464">Average</span></span>
    -   <span data-ttu-id="dc3e1-465">悪い</span><span class="sxs-lookup"><span data-stu-id="dc3e1-465">Poor</span></span>

4.  <span data-ttu-id="dc3e1-466">[**ネットワーク シミュレーションを有効にする**] をクリアして、開発用コンピューターのネットワーク設定を使う既定の動作に戻します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-466">Clear **Enable network simulation** to restore the default behavior, which uses the network settings of your development computer.</span></span>

<span data-ttu-id="dc3e1-467">また、[**ネットワーク**] タブで現在のネットワーク設定を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-467">You can also review the current network settings on the **Network** tab.</span></span>

![エミュレーターのその他のツールのネットワーク ページ](images/em-network.png)

## <a name="sd-card"></a><span data-ttu-id="dc3e1-469">SD カード</span><span class="sxs-lookup"><span data-stu-id="dc3e1-469">SD card</span></span>

<span data-ttu-id="dc3e1-470">エミュレーターの [**その他のツール**] の [**SD カード**] タブを使って、シミュレートされたリムーバブル SD カードでアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-470">Test your app with a simulated removable SD card by using the **SD Card** tab of the emulator's **Additional Tools**.</span></span> <span data-ttu-id="dc3e1-471">この機能は、アプリでファイルの読み取りまたは書き込みを行うときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-471">This feature is useful if your app reads or write files.</span></span>

![エミュレーターのその他のツールの SD カード ページ](images/em-sdcard.png)

<span data-ttu-id="dc3e1-473">[**SD カード**] タブは開発用コンピューターのフォルダーを使って電話のリムーバブル SD カードをシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-473">The **SD Card** tab uses a folder on the development computer to simulate a removable SD card in the phone.</span></span>

1.  <span data-ttu-id="dc3e1-474">**フォルダーを選びます**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-474">**Select a folder**.</span></span>

    <span data-ttu-id="dc3e1-475">[**参照**] をクリックして、シミュレートされた SD カードのコンテンツを格納する開発用コンピューターのフォルダーを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-475">Click **Browse** to pick a folder on the development computer to hold the contents of the simulated SD card.</span></span>

2.  <span data-ttu-id="dc3e1-476">**SD カードを挿入します**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-476">**Insert the SD card**.</span></span>

    <span data-ttu-id="dc3e1-477">フォルダーを選んだら、[**Insert SD card**] (SD カードの挿入) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-477">After selecting a folder, click **Insert SD card**.</span></span> <span data-ttu-id="dc3e1-478">SD カードを挿入すると、次のことが行われます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-478">When you insert the SD card, the following things happen:</span></span>

    -   <span data-ttu-id="dc3e1-479">フォルダーを指定しなかった場合、またはフォルダーが有効でない場合は、エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-479">If you didn't specify a folder, or the folder's not valid, an error occurs.</span></span>
    -   <span data-ttu-id="dc3e1-480">開発用コンピューターの指定されたフォルダーが、エミュレーターのシミュレートされた SD カードのルート フォルダーにコピーされます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-480">The files in the specified folder on the development computer are copied to the root folder of the simulated SD card on the emulator.</span></span> <span data-ttu-id="dc3e1-481">進行状況バーにより、同期操作の進行状況が示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-481">A progress bar indicates the progress of the sync operation.</span></span>
    -   <span data-ttu-id="dc3e1-482">[**Insert the SD card**] (SD カードの挿入) が [**Eject SD card**] (SD カードの取り出し) に変わります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-482">The **Insert the SD card** button changes to **Eject SD card**.</span></span>
    -   <span data-ttu-id="dc3e1-483">同期操作の進行中に、[**Eject SD card**] (SD カードの取り出し) をクリックすると、操作が取り消されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-483">If you click **Eject SD card** while the sync operation is in progress, the operation is canceled.</span></span>

3.  <span data-ttu-id="dc3e1-484">必要に応じて、[**Sync updated files back to the local folder when I eject the SD card**] (SD カードの取り出し時に更新されたファイルをローカル フォルダーに同期) をオンまたはオフにします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-484">Optionally, select or clear **Sync updated files back to the local folder when I eject the SD card**.</span></span>

    <span data-ttu-id="dc3e1-485">既定では、このオプションは有効になっています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-485">This option is enabled by default.</span></span> <span data-ttu-id="dc3e1-486">このオプションを有効にすると、SD カードの取り出し時にエミュレーターのファイルが開発用コンピューターのフォルダーに同期されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-486">When this option is enabled, files are synced from the emulator back to the folder on the development computer when you eject the SD card.</span></span>

4.  <span data-ttu-id="dc3e1-487">**SD カードを取り出します**。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-487">**Eject the SD card**.</span></span>

    <span data-ttu-id="dc3e1-488">[**Eject SD card**] (SD カードの取り出し) をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-488">Click **Eject SD card**.</span></span> <span data-ttu-id="dc3e1-489">SD カードを取り出すと、次のことが行われます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-489">When you eject the SD card, the following things happen:</span></span>

    -   <span data-ttu-id="dc3e1-490">[**Sync updated files back to the local folder when I eject the SD card**] (SD カードの取り出し時に更新されたファイルをローカル フォルダーに同期) をオンにしていた場合、次のことが行われます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-490">if you have selected **Sync updated files back to the local folder when I eject the SD card**, the following things happen:</span></span>
        -   <span data-ttu-id="dc3e1-491">エミュレーターのシミュレートされた SD カードのファイルが、開発用コンピューターの指定されたフォルダーにコピーされます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-491">The files on the simulated SD card on the emulator are copied to the specified folder on the development computer.</span></span> <span data-ttu-id="dc3e1-492">進行状況バーにより、同期操作の進行状況が示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-492">A progress bar indicates the progress of the sync operation.</span></span>
        -   <span data-ttu-id="dc3e1-493">[**Eject SD card**] (SD カードの取り出し) が [**同期のキャンセル**] に変わります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-493">The **Eject SD card** button changes to **Cancel sync**.</span></span>
        -   <span data-ttu-id="dc3e1-494">同期操作の進行中に **[同期のキャンセル]** をクリックすると、カードが取り出され、同期操作の結果は不完全になります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-494">If you click **Cancel sync** while the sync operation is in progress, the card is ejected and the results of the sync operation are incomplete.</span></span>
    -   <span data-ttu-id="dc3e1-495">**[SD カードの取り出し]** が再び **[SD カードの挿入]** に変わります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-495">The **Eject SD card** button changes back to **Insert SD card**.</span></span>

> <span data-ttu-id="dc3e1-496">**注**  電話に使われる SD カードは FAT32 ファイル システムでフォーマットされているため、最大サイズは 32 GB です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-496">**Note**  Since an SD card used by the phone is formatted with the FAT32 file system, 32GB is the maximum size.</span></span>

<span data-ttu-id="dc3e1-497">シミュレートされた SD カードとの間の読み込みと書き込みの速度が、実際の速度と似せるために調整されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-497">The speed of reading from and writing to the simulated SD card is throttled to imitate real-world speeds.</span></span> <span data-ttu-id="dc3e1-498">SD カードへのアクセスは、コンピューターのハード ドライブへのアクセスよりも遅くなります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-498">Accessing an SD card is slower than accessing the computer's hard drive.</span></span>

## <a name="notifications"></a><span data-ttu-id="dc3e1-499">通知</span><span class="sxs-lookup"><span data-stu-id="dc3e1-499">Notifications</span></span>

<span data-ttu-id="dc3e1-500">エミュレーターの **[その他のツール]** の **[通知]** タブを使ってアプリにプッシュ通知を送ります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-500">Send push notifications to your app by using the **Notifications** tab of the emulator's **Additional Tools**.</span></span> <span data-ttu-id="dc3e1-501">この機能は、アプリでプッシュ通知を受け取るときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-501">This feature is useful if your app receives push notifications.</span></span>

<span data-ttu-id="dc3e1-502">アプリの公開後に必要となる実際に使えるクラウド サービスを作成することなく、簡単にプッシュ通知をテストできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-502">You can easily test push notifications without creating the working cloud service that's required after you publish your app.</span></span>

1.  **<span data-ttu-id="dc3e1-503">シミュレーションを有効にします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-503">Enable simulation.</span></span>**

    <span data-ttu-id="dc3e1-504">[**有効**] をオンにすると、シミュレーションを無効にするまでエミュレーターに展開されているすべてのアプリが WNS または MPN サービスの代わりにシミュレーション エンジンを使います。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-504">After you select **Enabled**, all apps deployed on the emulator use the simulation engine instead of the WNS or MPN service until you disable simulation.</span></span>

2.  **<span data-ttu-id="dc3e1-505">通知を受け取るアプリを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-505">Select an app to receive notifications.</span></span>**

    <span data-ttu-id="dc3e1-506">[**AppId**] リストには、プッシュ通知を有効にされた、エミュレーターに展開されているすべてのアプリが自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-506">The **AppId** list is automatically populated with all apps deployed to the emulator that are enabled for push notifications.</span></span> <span data-ttu-id="dc3e1-507">ドロップダウン リストからアプリを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-507">Select an app in the drop-down list.</span></span>

    <span data-ttu-id="dc3e1-508">シミュレーションを有効にした後に別のプッシュ対応アプリを展開する場合は、[**更新**] をクリックしてアプリをリストに追加します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-508">If you deploy another push-enabled app after enabling simulation, click **Refresh** to add the app to the list.</span></span>

3.  **<span data-ttu-id="dc3e1-509">通知チャネルを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-509">Select a notification channel.</span></span>**

    <span data-ttu-id="dc3e1-510">[**AppId**] リストでアプリを選ぶと、選択したアプリに登録されたすべての通知チャネルが [**URI**] リストに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-510">After you select an app in the **AppId** list, the **URI** list is automatically populated with all the notification channels registered for the selected app.</span></span> <span data-ttu-id="dc3e1-511">ドロップダウン リストから通知チャネルを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-511">Select a notification channel in the drop-down list.</span></span>

4.  **<span data-ttu-id="dc3e1-512">通知の種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-512">Select a notification type.</span></span>**

    <span data-ttu-id="dc3e1-513">[**URI**] リストから通知チャネルを選ぶと、通知サービスに利用可能なすべての種類が [**通知の種類**] リストに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-513">After you select a notification channel in the **URI** list, the **Notification Type** list is automatically populated with all the types available for the notification service.</span></span> <span data-ttu-id="dc3e1-514">ドロップダウン リストから通知の種類を選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-514">Select a notification type in the drop-down list.</span></span>

    <span data-ttu-id="dc3e1-515">シミュレーターは Uri 形式の通知チャネルを使ってアプリが WNS または MPN プッシュ通知を使っているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-515">The simulator uses the Uri format of the notification channel to determine whether the app is using WNS or MPN push notifications.</span></span>

    <span data-ttu-id="dc3e1-516">シミュレーションはすべての通知の種類をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-516">Simulation supports all notification types.</span></span> <span data-ttu-id="dc3e1-517">既定の通知の種類は [**タイル**] です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-517">The default notification type is **Tile**.</span></span>

    -   <span data-ttu-id="dc3e1-518">次の WNS 通知の種類がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-518">The following WNS notification types are supported.</span></span>

        -   <span data-ttu-id="dc3e1-519">直接</span><span class="sxs-lookup"><span data-stu-id="dc3e1-519">Raw</span></span>
        -   <span data-ttu-id="dc3e1-520">トースト</span><span class="sxs-lookup"><span data-stu-id="dc3e1-520">Toast</span></span>

            <span data-ttu-id="dc3e1-521">アプリが WNS 通知を使っている場合に通知の種類に [**トースト**] を選ぶと、シミュレーション タブに**タグ** フィールドと**グループ** フィールドが表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-521">When your app uses WNS notifications and you select the **Toast** notification type, the simulation tab displays the **Tag** and **Group** fields.</span></span> <span data-ttu-id="dc3e1-522">これらのオプションを選択して [**タグ**] と [**グループ**] の値を入力し、通知センターのトースト通知を管理することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-522">You can select these options and enter **Tag** and **Group** values to manage toast notifications in the Notification Center.</span></span>

        -   <span data-ttu-id="dc3e1-523">タイル</span><span class="sxs-lookup"><span data-stu-id="dc3e1-523">Tile</span></span>
        -   <span data-ttu-id="dc3e1-524">バッジ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-524">Badge</span></span>

    -   <span data-ttu-id="dc3e1-525">次の MPN 通知の種類がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-525">The following MPN notification types are supported.</span></span>

        -   <span data-ttu-id="dc3e1-526">直接</span><span class="sxs-lookup"><span data-stu-id="dc3e1-526">Raw</span></span>
        -   <span data-ttu-id="dc3e1-527">トースト</span><span class="sxs-lookup"><span data-stu-id="dc3e1-527">Toast</span></span>
        -   <span data-ttu-id="dc3e1-528">タイル</span><span class="sxs-lookup"><span data-stu-id="dc3e1-528">Tile</span></span>

5.  **<span data-ttu-id="dc3e1-529">通知テンプレートを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-529">Select a notification template.</span></span>**

    <span data-ttu-id="dc3e1-530">[**通知の種類**] リストから通知の種類を選ぶと、その通知の種類に利用可能なすべてのテンプレートが [**テンプレート**] リストに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-530">After you select a notification type in the **Notification Type** list, the **Templates** list is automatically populated with all the templates available for the notification type.</span></span> <span data-ttu-id="dc3e1-531">ドロップダウン リストでテンプレートを選びます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-531">Select a template in the drop-down list.</span></span>

    <span data-ttu-id="dc3e1-532">シミュレーションはすべてのテンプレートの種類をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-532">Simulation supports all template types.</span></span>

6.  **<span data-ttu-id="dc3e1-533">必要に応じて、通知のペイロードを変更します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-533">Optionally, change the notification payload.</span></span>**

    <span data-ttu-id="dc3e1-534">[**テンプレート**] リストのテンプレートを選ぶと、そのテンプレートのサンプル ペイロードが [**Notification Payload**] (通知のペイロード) テキスト ボックスに自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-534">After you select a template in the **Templates** list, the **Notification Payload** text box is automatically populated with a sample payload for the template.</span></span> <span data-ttu-id="dc3e1-535">[**Notification Payload**] (通知のペイロード) テキスト ボックスのサンプル ペイロードを確認します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-535">Review the sample payload in the **Notification Payload** text box.</span></span>

    -   <span data-ttu-id="dc3e1-536">サンプル ペイロードは変更せずに送信できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-536">You can send the sample payload without changing it.</span></span>

    -   <span data-ttu-id="dc3e1-537">テキスト ボックスでサンプル ペイロードを編集できます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-537">You can edit the sample payload in the text box.</span></span>

    -   <span data-ttu-id="dc3e1-538">[**読み込み**] をクリックしてテキスト ファイルまたは XML ファイルからペイロードを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-538">You can click **Load** to load a payload from a text or XML file.</span></span>

    -   <span data-ttu-id="dc3e1-539">[**保存**] をクリックして、後で再利用するためにペイロードの XML テキストを保存することができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-539">You can click **Save** to save the XML text of the payload to use again later.</span></span>

    <span data-ttu-id="dc3e1-540">シミュレーターはペイロードの XML テキストを検証しません。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-540">The simulator does not validate the XML text of the payload.</span></span>

7.  **<span data-ttu-id="dc3e1-541">プッシュ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-541">Send the push notification.</span></span>**

    <span data-ttu-id="dc3e1-542">[**送信**] をクリックして選択したアプリにプッシュ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-542">Click **Send** to deliver the push notification to the selected app.</span></span>

    <span data-ttu-id="dc3e1-543">画面に成功または失敗を示すメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-543">The screen displays a message to indicate success or failure.</span></span>

![エミュレーターのその他のツールの通知ページ](images/em-notifications.png)

## <a name="sensors"></a><span data-ttu-id="dc3e1-545">センサー</span><span class="sxs-lookup"><span data-stu-id="dc3e1-545">Sensors</span></span>

<span data-ttu-id="dc3e1-546">エミュレーターの [**その他のツール**] の [**センサー**] タブを使って、すべてのオプションのセンサーまたはカメラ機能を備えていない低コストな電話でアプリがどのように動作するかをテストします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-546">Test how your app works on low-cost phones that don't have all the optional sensors or camera features by using the **Sensors** tab of the emulator's **Additional Tools**.</span></span> <span data-ttu-id="dc3e1-547">この機能は、アプリでカメラや一部の電話のセンサーを使い、このアプリを可能な限り幅広い市場に提供する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-547">This feature is useful if your app uses the camera or some of the phone's sensors, and you want your app to reach the largest possible market.</span></span>

-   <span data-ttu-id="dc3e1-548">既定では、すべてのセンサーが [**Optional sensors**] (オプション センサー) リストで有効になっています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-548">By default, all sensors are enabled in the **Optional sensors** list.</span></span> <span data-ttu-id="dc3e1-549">個々のチェック ボックスをオンまたはオフにし、個々のセンサーを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-549">Select or clear individual check boxes to enable or disable individual sensors.</span></span>
-   <span data-ttu-id="dc3e1-550">選択内容を変更したら、[**適用**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-550">After you change your selections, click **Apply**.</span></span> <span data-ttu-id="dc3e1-551">その後、エミュレーターを再起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-551">Then you have to restart the emulator.</span></span>
-   <span data-ttu-id="dc3e1-552">変更を行った後に、[**適用**] をクリックせずにタブを切り替えたり [**その他のツール**] ウィンドウを閉じると、変更内容は破棄されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-552">If you make changes, and then you switch tabs or close the **Additional Tools** window without clicking **Apply**, your changes are discarded.</span></span>
-   <span data-ttu-id="dc3e1-553">設定は、エミュレーター セッションの間、設定を変更するかリセットするまで保持されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-553">Your settings are persisted between for the emulator session until you change them or reset them.</span></span> <span data-ttu-id="dc3e1-554">チェックポイントをキャプチャすると、設定がチェックポイントと共に保存されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-554">If you capture a checkpoint, the settings are saved with the checkpoint.</span></span> <span data-ttu-id="dc3e1-555">設定は使っている特定のエミュレーターでのみ保持されます (**エミュレーター 8.1 WVGA 4" 512 MB** など)。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-555">The settings are persisted only for the specific emulator that you're using - for example, **Emulator 8.1 WVGA 4" 512MB**.</span></span>

![エミュレーターのその他のツールのセンサー ページ](images/em-sensors.png)

**<span data-ttu-id="dc3e1-557">センサーのオプション</span><span class="sxs-lookup"><span data-stu-id="dc3e1-557">Sensor options</span></span>**

<span data-ttu-id="dc3e1-558">次のオプションのハードウェア センサーを有効または無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-558">You can enable or disable the following optional hardware sensors:</span></span>

-   <span data-ttu-id="dc3e1-559">環境光センサー</span><span class="sxs-lookup"><span data-stu-id="dc3e1-559">Ambient light sensor</span></span>
-   <span data-ttu-id="dc3e1-560">正面カメラ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-560">Front-facing camera</span></span>
-   <span data-ttu-id="dc3e1-561">ジャイロスコープ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-561">Gyroscope</span></span>
-   <span data-ttu-id="dc3e1-562">コンパス (磁力計)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-562">Compass (magnetometer)</span></span>
-   <span data-ttu-id="dc3e1-563">NFC</span><span class="sxs-lookup"><span data-stu-id="dc3e1-563">NFC</span></span>
-   <span data-ttu-id="dc3e1-564">ソフトウェア ボタン (一部の高解像度エミュレーター イメージでのみ)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-564">Software buttons (only on some high-resolution emulator images)</span></span>

**<span data-ttu-id="dc3e1-565">カメラのオプション</span><span class="sxs-lookup"><span data-stu-id="dc3e1-565">Camera options</span></span>**

<span data-ttu-id="dc3e1-566">[**Optional sensors**] (オプション センサー) リストのチェック ボックスをオンまたはオフにすることで、オプションの正面カメラを有効または無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-566">You can enable or disable the optional front-facing camera by selecting or clearing the check box in the **Optional sensors** list.</span></span>

<span data-ttu-id="dc3e1-567">[**カメラ**] ドロップダウン リストから次のいずれかのカメラ プロファイルを選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-567">You can also select one of the following camera profiles in the **Camera** dropdown list.</span></span>

-   <span data-ttu-id="dc3e1-568">Windows Phone 8.0 カメラ。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-568">Windows Phone 8.0 camera.</span></span>
-   <span data-ttu-id="dc3e1-569">Windows Phone 8.1 カメラ。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-569">Windows Phone 8.1 camera.</span></span>

<span data-ttu-id="dc3e1-570">各プロファイルによってサポートされているカメラ機能の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-570">Here is the list of camera features supported by each of the profiles.</span></span>

| <span data-ttu-id="dc3e1-571">機能</span><span class="sxs-lookup"><span data-stu-id="dc3e1-571">Feature</span></span>            | <span data-ttu-id="dc3e1-572">Windows Phone 8.0 カメラ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-572">Windows Phone 8.0 camera</span></span> | <span data-ttu-id="dc3e1-573">Windows Phone 8.1 カメラ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-573">Windows Phone 8.1 camera</span></span>  |
|--------------------|--------------------------|---------------------------|
| <span data-ttu-id="dc3e1-574">解像度</span><span class="sxs-lookup"><span data-stu-id="dc3e1-574">Resolution</span></span>         | <span data-ttu-id="dc3e1-575">640 x 480 (VGA)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-575">640 x 480 (VGA)</span></span>          | <span data-ttu-id="dc3e1-576">640 x 480 (VGA) 以上</span><span class="sxs-lookup"><span data-stu-id="dc3e1-576">640 x 480 (VGA) or better</span></span> |
| <span data-ttu-id="dc3e1-577">自動フォーカス</span><span class="sxs-lookup"><span data-stu-id="dc3e1-577">Autofocus</span></span>          | <span data-ttu-id="dc3e1-578">あり</span><span class="sxs-lookup"><span data-stu-id="dc3e1-578">Yes</span></span>                      | <span data-ttu-id="dc3e1-579">あり</span><span class="sxs-lookup"><span data-stu-id="dc3e1-579">Yes</span></span>                       |
| <span data-ttu-id="dc3e1-580">フラッシュ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-580">Flash</span></span>              | <span data-ttu-id="dc3e1-581">なし</span><span class="sxs-lookup"><span data-stu-id="dc3e1-581">No</span></span>                       | <span data-ttu-id="dc3e1-582">あり</span><span class="sxs-lookup"><span data-stu-id="dc3e1-582">Yes</span></span>                       |
| <span data-ttu-id="dc3e1-583">ズーム</span><span class="sxs-lookup"><span data-stu-id="dc3e1-583">Zoom</span></span>               | <span data-ttu-id="dc3e1-584">2x (デジタルまたは光学)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-584">2x (digital or optical)</span></span>  | <span data-ttu-id="dc3e1-585">2x (デジタルまたは光学)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-585">2x (digital or optical)</span></span>   |
| <span data-ttu-id="dc3e1-586">ビデオ解像度</span><span class="sxs-lookup"><span data-stu-id="dc3e1-586">Video resolution</span></span>   | <span data-ttu-id="dc3e1-587">640 x 480 (VGA)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-587">640 x 480 (VGA)</span></span>          | <span data-ttu-id="dc3e1-588">640 x 480 (VGA) 以上</span><span class="sxs-lookup"><span data-stu-id="dc3e1-588">640 x 480 (VGA) or better</span></span> |
| <span data-ttu-id="dc3e1-589">プレビュー解像度</span><span class="sxs-lookup"><span data-stu-id="dc3e1-589">Preview resolution</span></span> | <span data-ttu-id="dc3e1-590">640 x 480 (VGA)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-590">640 x 480 (VGA)</span></span>          | <span data-ttu-id="dc3e1-591">640 x 480 (VGA)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-591">640 x 480 (VGA)</span></span>           |

## <a name="frame-rate-counters"></a><span data-ttu-id="dc3e1-592">フレーム レート カウンター</span><span class="sxs-lookup"><span data-stu-id="dc3e1-592">Frame rate counters</span></span>

<span data-ttu-id="dc3e1-593">Windows Phone エミュレーターのフレーム レート カウンターを使って、実行中のアプリのパフォーマンスを監視します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-593">Use the frame rate counters in Windows Phone emulator to monitor the performance of your running app.</span></span>

![Windows Phone エミュレーターのフレーム レート カウンター](images/em-frameratecounters.PNG)

**<span data-ttu-id="dc3e1-595">フレーム レート カウンターの説明</span><span class="sxs-lookup"><span data-stu-id="dc3e1-595">Descriptions of the frame rate counters</span></span>**

<span data-ttu-id="dc3e1-596">次の表で、各フレーム レート カウンターについて説明します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-596">The following table describes each frame rate counter.</span></span>

| <span data-ttu-id="dc3e1-597">フレーム レート カウンター</span><span class="sxs-lookup"><span data-stu-id="dc3e1-597">Frame rate counter</span></span>                           | <span data-ttu-id="dc3e1-598">説明</span><span class="sxs-lookup"><span data-stu-id="dc3e1-598">Description</span></span>        |
|----------------------------------------------|--------------------|
| <span data-ttu-id="dc3e1-599">コンポジション (レンダリング) スレッド フレーム レート (FPS)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-599">Composition (Render) Thread Frame Rate (FPS)</span></span> | <span data-ttu-id="dc3e1-600">画面が更新される速度です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-600">The rate at which the screen is updated.</span></span>  |
| <span data-ttu-id="dc3e1-601">ユーザー インターフェイス スレッド フレーム レート (FPS)</span><span class="sxs-lookup"><span data-stu-id="dc3e1-601">User Interface Thread Frame Rate (FPS)</span></span>       | <span data-ttu-id="dc3e1-602">UI スレッドの実行速度です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-602">The rate at which the UI thread is running.</span></span>    |
| <span data-ttu-id="dc3e1-603">テクスチャ メモリ使用率</span><span class="sxs-lookup"><span data-stu-id="dc3e1-603">Texture Memory Usage</span></span>                         | <span data-ttu-id="dc3e1-604">アプリで使用されているテクスチャのビデオメモリやシステム メモリのコピーです。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-604">The video memory and system memory copies of textures being used in the app.</span></span>    |
| <span data-ttu-id="dc3e1-605">サーフェス カウンター</span><span class="sxs-lookup"><span data-stu-id="dc3e1-605">Surface Counter</span></span>                              | <span data-ttu-id="dc3e1-606">処理するために GPU に渡された明示的なサーフェイスの数です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-606">The number of explicit surfaces being passed to the GPU for processing.</span></span>     |
| <span data-ttu-id="dc3e1-607">中間サーフェス カウンター</span><span class="sxs-lookup"><span data-stu-id="dc3e1-607">Intermediate Surface Counter</span></span>                 | <span data-ttu-id="dc3e1-608">キャッシュされたサーフェイスの結果として生成された暗黙的なサーフェイスの数です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-608">The number of implicit surfaces generated as a result of cached surfaces.</span></span>    |
| <span data-ttu-id="dc3e1-609">画面フィル レート カウンター</span><span class="sxs-lookup"><span data-stu-id="dc3e1-609">Screen Fill Rate Counter</span></span>                     | <span data-ttu-id="dc3e1-610">画面数に換算したフレームあたりの描画されるピクセルの数です。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-610">The number of pixels being painted per frame in terms of screens.</span></span> <span data-ttu-id="dc3e1-611">値 1 は現在の画面解像度のピクセル数、たとえば 480 x 800 ピクセルを表します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-611">A value of 1 represents the number of pixels in the current screen resolution – for example, 480 x 800 pixels.</span></span> |

**<span data-ttu-id="dc3e1-612">フレーム レート カウンターを有効/無効にする</span><span class="sxs-lookup"><span data-stu-id="dc3e1-612">Enabling and disabling the frame rate counters</span></span>**

<span data-ttu-id="dc3e1-613">コード内でフレーム レート カウンターの表示を有効および無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-613">You can enable or disable the display of the frame rate counters in your code.</span></span> <span data-ttu-id="dc3e1-614">Visual Studio で Windows Phone アプリ プロジェクトを作成すると、フレーム レート カウンターを有効にするための次のコードが既定で App.xaml.cs ファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-614">When you create a Windows Phone app project in Visual Studio, the following code to enable the frame rate counters is added by default in the file App.xaml.cs.</span></span> <span data-ttu-id="dc3e1-615">フレーム レート カウンターを無効にするには、**EnableFrameRateCounter** を **false** に設定するか、コード行をコメント アウトします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-615">To disable the frame rate counters, set **EnableFrameRateCounter** to **false** or comment out the line of code.</span></span>

> [!div class="tabbedCodeSnippets"]
>```csharp
>// Show graphics profiling information while debugging.
>if (System.Diagnostics.Debugger.IsAttached)
>{
>    // Display the current frame rate counters.
>    Application.Current.Host.Settings.EnableFrameRateCounter = true;
>    
>    // other code…
>}
>```
>```vb
>' Show graphics profiling information while debugging.
>If System.Diagnostics.Debugger.IsAttached Then
>
>    ' Display the current frame rate counters.
>    Application.Current.Host.Settings.EnableFrameRateCounter = True
>
>    ' other code...
>End If
>```

## <a name="known-issues"></a><span data-ttu-id="dc3e1-616">既知の問題</span><span class="sxs-lookup"><span data-stu-id="dc3e1-616">Known Issues</span></span>

<span data-ttu-id="dc3e1-617">エミュレーターの既知の問題と、問題が発生した場合の推奨される解決策を次に示します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-617">The following are known issues with the emulator, with suggested ways to work around problems if you encounter them.</span></span>

### <a name="error-message-failed-while-removing-virtual-ethernet-switch"></a><span data-ttu-id="dc3e1-618">エラー メッセージ: "仮想イーサネット スイッチの削除中にエラーが発生しました"</span><span class="sxs-lookup"><span data-stu-id="dc3e1-618">Error message: “Failed while removing virtual Ethernet switch”</span></span>

<span data-ttu-id="dc3e1-619">新しい Windows 10 Insider Preview ビルドへの更新後など、状況によっては、エミュレーターに関連付けられている仮想ネットワーク スイッチが、ユーザー インターフェイスを使って削除できなくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-619">In certain situations, including after you update to a new Windows 10 flight, a virtual network switch associated with the emulator can get into a state where it can't be deleted through the user interface.</span></span>

<span data-ttu-id="dc3e1-620">この状況から回復するには、管理者のコマンド プロンプト `C:\Program Files (x86)\Microsoft XDE\<version>\XdeCleanup.exe` から "netcfg -d" を実行します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-620">To recover from this situation run "netcfg -d" from an administrator command prompt: `C:\Program Files (x86)\Microsoft XDE\<version>\XdeCleanup.exe`.</span></span> <span data-ttu-id="dc3e1-621">コマンドの実行が完了したら、コンピューターを再起動して回復プロセスを実行します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-621">When the command is finished running, reboot your computer to complete the recovery process.</span></span>

<span data-ttu-id="dc3e1-622">**注**  このコマンドにより、エミュレーターに関連付けられているデバイスだけでなく、すべてのネットワーク デバイスが削除されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-622">**Note**  This command will delete all networking devices, not just those associated with the emulator.</span></span> <span data-ttu-id="dc3e1-623">使用しているコンピューターを再度起動すると、すべてのハードウェア ネットワーク デバイスが自動的に検出されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-623">When your computer starts again, all hardware networking devices will be discovered automatically.</span></span>
 
### <a name="unable-to-launch-the-emulators"></a><span data-ttu-id="dc3e1-624">エミュレーターを起動できない</span><span class="sxs-lookup"><span data-stu-id="dc3e1-624">Unable to launch the emulators</span></span>

<span data-ttu-id="dc3e1-625">Microsoft Emulator には、すべての VM、差分ディスク、およびエミュレーター固有のネットワーク スイッチを削除するツールである XDECleanup.exe が含まれており、これはエミュレーター (XDE) バイナリに既に付属しています。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-625">Microsoft Emulator includes XDECleanup.exe, a tool that deletes all VMs, diff disks, and emulator specific network switches, and it ships with the emulator (XDE) binaries already.</span></span> <span data-ttu-id="dc3e1-626">エミュレーター VM が無効な状態になったら、このツールを使用して、その VM をクリーンアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-626">You should use this tool to clean up emulator VMs if they get into a bad state.</span></span> <span data-ttu-id="dc3e1-627">ツールは、管理者のコマンド プロンプトから実行します ()。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-627">Run the tool from an administrator command prompt:</span></span>`C:\Program Files (x86)\Microsoft XDE\<version>\XdeCleanup.exe`

> <span data-ttu-id="dc3e1-628">**注**  XDECleanup.exe により、エミュレーター固有のすべての Hyper-V VM のほか、VM チェックポイントや保存された状態も削除されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-628">**Note**  XDECleanup.exe deletes all emulator specific Hyper-V VMs, and it also deletes any VM checkpoints or saved states.</span></span>

### <a name="uninstall-windows-10-for-mobile-image"></a><span data-ttu-id="dc3e1-629">モバイル向け Windows 10 イメージのアンインストール</span><span class="sxs-lookup"><span data-stu-id="dc3e1-629">Uninstall Windows 10 for Mobile Image</span></span>

<span data-ttu-id="dc3e1-630">エミュレーターをインストールすると、モバイル向け Windows 10 の VHD イメージがインストールされ、独自のエントリがコントロール パネルの **[プログラムと機能]** の一覧に示されます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-630">When you install the emulator, a Windows 10 for Mobile VHD image is installed, which gets its own entry in the **Programs and Features** list in the Control Panel.</span></span> <span data-ttu-id="dc3e1-631">このイメージをアンインストールするには、インストールされているプログラムの一覧で **[Windows 10 for Mobile Image - <version>]** を見つけて右クリックし、**[アンインストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-631">If you wish to uninstall the image, find **Windows 10 for Mobile Image - <version>** in the list of installed programs, right-click on it, and choose **Uninstall**.</span></span>

<span data-ttu-id="dc3e1-632">その後、現在のリリースで、エミュレーターの VHD ファイルを手動で削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-632">In the current release, you must then manually delete the VHD file for the emulator.</span></span> <span data-ttu-id="dc3e1-633">エミュレーターを既定のパスにインストールした場合、VHD ファイルは、C:\\Program Files (x86)\\Windows Kits\\10\\Emulation\\Mobile\\<version>\\flash.vhd。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-633">If you installed the emulator to the default path, the VHD file is at C:\\Program Files (x86)\\Windows Kits\\10\\Emulation\\Mobile\\<version>\\flash.vhd.</span></span>

###<a name="how-to-disable-hardware-accelerated-graphics"></a><span data-ttu-id="dc3e1-634">ハードウェア アクセラレータに対応したグラフィックを無効にする方法</span><span class="sxs-lookup"><span data-stu-id="dc3e1-634">How to disable hardware accelerated graphics</span></span>

<span data-ttu-id="dc3e1-635">既定では、Windows 10 Mobile Emulator は、ハードウェア アクセラレータに対応したグラフィックを使用します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-635">By default, Windows 10 Mobile Emulator uses hardware accelerated graphics.</span></span> <span data-ttu-id="dc3e1-636">ハードウェア アクセラレータが有効になっており、エミュレーターを起動できない場合は、レジストリ値を設定して無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-636">If you are having trouble launching the emulator with hardware acceleration enabled, you can turn it off by setting a registry value.</span></span>

<span data-ttu-id="dc3e1-637">ハードウェア アクセラレータを無効にするには</span><span class="sxs-lookup"><span data-stu-id="dc3e1-637">To disable hardware acceleration:</span></span>

1. <span data-ttu-id="dc3e1-638">レジストリ エディターを開きます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-638">Start Registry Editor.</span></span>
2. <span data-ttu-id="dc3e1-639">存在しない場合は、次のレジストリ サブキーを作成します。HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Xde\10.0。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-639">Create the following registry subkey if it doesn't exist: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Xde\10.0</span></span>
3. <span data-ttu-id="dc3e1-640">[10.0] フォルダーを右クリックし、**[新規]** をポイントして、**[DWORD 値]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-640">Right click the 10.0 folder, point to **New**, and then click **DWORD Value**.</span></span>
4. <span data-ttu-id="dc3e1-641">「**DisableRemoteFx**」と入力し、Enter キーを押します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-641">Type **DisableRemoteFx**, and then press Enter.</span></span>
5. <span data-ttu-id="dc3e1-642">**[DisableRemoteFx]** をダブルクリックして、**[値]** データ ボックスに「1」と入力します。次に、**[10 進数]** オプションを選択して **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-642">Double-click **DisableRemoteFx**, enter 1 in the **Value** data box, select the **Decimal** option, and then click **OK**.</span></span>
6. <span data-ttu-id="dc3e1-643">レジストリ エディターを閉じます。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-643">Close Registry Editor.</span></span>

<span data-ttu-id="dc3e1-644">**注** このレジストリ値を設定した後、Visual Studio で起動した構成について、Hyper-V マネージャーで仮想マシンを削除し、ソフトウェア レンダリングされたグラフィックを使ってエミュレーターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-644">**Note:** After setting this registry value, you must delete the virtual machine in Hyper-V manager for the configuration that you launched in Visual Studio, and then relaunch the emulator with software-rendered graphics.</span></span>

## <a name="support-resources"></a><span data-ttu-id="dc3e1-645">サポート資料</span><span class="sxs-lookup"><span data-stu-id="dc3e1-645">Support Resources</span></span>

<span data-ttu-id="dc3e1-646">Windows 10 ツールを使う際に生じた質問の答えを探したり、問題を解決したりするには、[Windows 10 ツール フォーラム](http://go.microsoft.com/fwlink/?LinkId=534765)にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-646">To find answers and solve problems as you start working with the Windows 10 tools, please visit [Windows 10 Tools forum](http://go.microsoft.com/fwlink/?LinkId=534765).</span></span> <span data-ttu-id="dc3e1-647">Windows 10 開発のすべてのフォーラムを参照するには、[このリンク](http://go.microsoft.com/fwlink/?LinkId=535000)にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="dc3e1-647">To see all the forums for Windows 10 development, visit [this link](http://go.microsoft.com/fwlink/?LinkId=535000).</span></span>

## <a name="related-topics"></a><span data-ttu-id="dc3e1-648">関連トピック</span><span class="sxs-lookup"><span data-stu-id="dc3e1-648">Related topics</span></span>

* [<span data-ttu-id="dc3e1-649">エミュレーターで Windows Phone アプリを実行する</span><span class="sxs-lookup"><span data-stu-id="dc3e1-649">Run Windows Phone apps in the emulator</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/dn632391.aspx)
* [<span data-ttu-id="dc3e1-650">Windows と Windows Phone SDK のアーカイブ</span><span class="sxs-lookup"><span data-stu-id="dc3e1-650">Windows and Windows Phone SDK archive</span></span>](https://dev.windows.com/downloads/sdk-archive)
 

