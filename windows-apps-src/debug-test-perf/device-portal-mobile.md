---
author: PatrickFarley
ms.assetid: 5c34c78e-9ff7-477b-87f6-a31367cd3f8b
title: モバイル用 Device Portal
description: Windows Device Portal で、モバイル デバイスの構成と管理をリモートから行う方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 0531cbefef509f7bc323829031b366bec3c798d8
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4620147"
---
# <a name="device-portal-for-mobile"></a><span data-ttu-id="73401-104">モバイル用 Device Portal</span><span class="sxs-lookup"><span data-stu-id="73401-104">Device Portal for Mobile</span></span>

<span data-ttu-id="73401-105">Windows 10 Version 1511 以降では、モバイル デバイス ファミリで追加の開発者向け機能が利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="73401-105">Starting in Windows 10, Version 1511, additional developer features are available for the mobile device family.</span></span> <span data-ttu-id="73401-106">これらの機能は、デバイスで開発者モードが有効になっている場合にのみ利用可能です。</span><span class="sxs-lookup"><span data-stu-id="73401-106">These features are available only when Developer mode is enabled on the device.</span></span>

<span data-ttu-id="73401-107">開発者モードを有効にする方法については、「[デバイスを開発用に有効にする](../get-started/enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73401-107">For info about how to enable Developer mode, see [Enable your device for development](../get-started/enable-your-device-for-development.md).</span></span>

![Device Portal の設定](images/device-portal/mob-dev-mode-options.png)

## <a name="set-up-device-portal-on-windows-phone"></a><span data-ttu-id="73401-109">Windows Phone で Device Portal をセットアップする</span><span class="sxs-lookup"><span data-stu-id="73401-109">Set up Device Portal on Windows Phone</span></span>

### <a name="turn-on-device-discovery-and-pairing"></a><span data-ttu-id="73401-110">デバイスの検出とペアリングを有効にする</span><span class="sxs-lookup"><span data-stu-id="73401-110">Turn on device discovery and pairing</span></span>

<span data-ttu-id="73401-111">Device Portal に接続するには、電話の設定でデバイスの検出と Device Portal を有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73401-111">To connect to Device Portal, you must enable Device discovery and Device Portal in your phone's settings.</span></span> <span data-ttu-id="73401-112">これにより、使用している電話と、PC または他の Windows 10 デバイスをペアリングできます。</span><span class="sxs-lookup"><span data-stu-id="73401-112">This lets you pair your phone with a PC or other Windows 10 device.</span></span> <span data-ttu-id="73401-113">デバイスは両方ともワイヤード (有線) またはワイヤレスでネットワークの同じサブネットに接続されているか、または 2 台のデバイスが USB で接続されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="73401-113">Both devices must be connected to the same subnet of the network by a wired or wireless connection, or they must be connected by USB.</span></span>

<span data-ttu-id="73401-114">初めて Device Portal に接続すると、大文字と小文字が区別される 6 文字のセキュリティ コードを入力するように求められます。</span><span class="sxs-lookup"><span data-stu-id="73401-114">The first time you connect to Device Portal, you are asked for a case-sensitive, 6 character security code.</span></span> <span data-ttu-id="73401-115">これにより電話に確実にアクセスでき、攻撃を受ける心配もなくなります。</span><span class="sxs-lookup"><span data-stu-id="73401-115">This ensures that you have access to the phone, and keeps you safe from attackers.</span></span> <span data-ttu-id="73401-116">電話の [ペアリング] ボタンを押してコードを生成および表示し、その 6 文字をブラウザー内のテキスト ボックスに入力します。</span><span class="sxs-lookup"><span data-stu-id="73401-116">Press the Pair button on your phone to generate and display the code, then enter the 6 characters into the text box in the browser.</span></span>

![開発者モードのデバイス検出設定](images/device-portal/mob-dev-mode-pairing.png)

<span data-ttu-id="73401-118">Device Portal に接続するには、USB、ローカル ホスト、ローカル ネットワーク (VPN やテザリングを含む) の 3 つの方法のいずれかを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="73401-118">You can choose from 3 ways to connect to Device Portal: USB, local host, and over the local network (including VPN and tethering).</span></span>

**<span data-ttu-id="73401-119">Device Portal に接続するには</span><span class="sxs-lookup"><span data-stu-id="73401-119">To connect to Device Portal</span></span>**

1. <span data-ttu-id="73401-120">ブラウザーで、使っている接続の種類に応じて次のアドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="73401-120">In your browser, enter the address shown here for the connection type you're using.</span></span>

    - <span data-ttu-id="73401-121">USB: </span><span class="sxs-lookup"><span data-stu-id="73401-121">USB:</span></span> `http://127.0.0.1:10080`

    <span data-ttu-id="73401-122">電話が USB で PC に接続されている場合は、このアドレスを使います。</span><span class="sxs-lookup"><span data-stu-id="73401-122">Use this address when the phone is connected to a PC via a USB connection.</span></span> <span data-ttu-id="73401-123">両方のデバイスに、Windows 10 バージョン 1511 以降が必要です。</span><span class="sxs-lookup"><span data-stu-id="73401-123">Both devices must have Windows 10, Version 1511 or later.</span></span>
    
    - <span data-ttu-id="73401-124">Localhost: </span><span class="sxs-lookup"><span data-stu-id="73401-124">Localhost:</span></span> `http://127.0.0.1`

    <span data-ttu-id="73401-125">このアドレスは、Windows 10 Mobile の Microsoft Edge で電話上の Device Portal をローカルで表示するときに使います。</span><span class="sxs-lookup"><span data-stu-id="73401-125">Use this address to view Device Portal locally on the phone in Microsoft Edge for Windows 10 Mobile.</span></span>
    
    - <span data-ttu-id="73401-126">Local Network: </span><span class="sxs-lookup"><span data-stu-id="73401-126">Local Network:</span></span> `https://<The IP address or hostname of the phone>`

    <span data-ttu-id="73401-127">このアドレスは、ローカル ネットワーク経由で接続するときに使います。</span><span class="sxs-lookup"><span data-stu-id="73401-127">Use this address to connect over a local network.</span></span>

    <span data-ttu-id="73401-128">電話の IP アドレスは、電話の Device Portal の設定に表示されます。</span><span class="sxs-lookup"><span data-stu-id="73401-128">The IP address of the phone is shown in the Device Portal settings on the phone.</span></span> <span data-ttu-id="73401-129">認証とセキュリティで保護された通信には HTTPS が必要です。</span><span class="sxs-lookup"><span data-stu-id="73401-129">HTTPS is required for authentication and secure communication.</span></span> <span data-ttu-id="73401-130">ホスト名 ([設定]、[システム]、[バージョン情報] で編集可能) は、ローカル ネットワーク上の Device Portal (たとえば http://Phone360) にアクセスするためにも使われます。これは、IP アドレスが頻繁に変わる可能性のあるデバイスや、共有する必要のあるデバイスを使っている場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="73401-130">The hostname (editable in Settings > System > About) can also be used to access Device Portal on the local network (e.g. http://Phone360), which is useful for devices that may change networks or IP addresses frequently, or need to be shared.</span></span> 

2. <span data-ttu-id="73401-131">電話の [ペアリング] ボタンを押して、必要なセキュリティ コードを生成して表示します。</span><span class="sxs-lookup"><span data-stu-id="73401-131">Press the Pair button on your phone to generate and display the required security code</span></span>

3. <span data-ttu-id="73401-132">ブラウザーの Device Portal のパスワード ボックスに、6 文字のセキュリティ コードを入力します。</span><span class="sxs-lookup"><span data-stu-id="73401-132">Enter the 6 character security code into the Device Portal password box in your browser.</span></span>

4. <span data-ttu-id="73401-133">(省略可能) ブラウザーで [Remember my computer] (このコンピューターを記憶する) ボックスをオンにして、今後も使用できるようにこのペアリングを記憶します。</span><span class="sxs-lookup"><span data-stu-id="73401-133">(Optional) Check the Remember my computer box in your browser to remember this pairing in the future.</span></span>

<span data-ttu-id="73401-134">Windows Phone の開発者設定ページの [Device Portal] セクションを次に示します。</span><span class="sxs-lookup"><span data-stu-id="73401-134">Here's the Device Portal section of the developer settings page on Windows Phone.</span></span>

![Device Portal の設定](images/device-portal/mob-dev-mode-portal.png)

<span data-ttu-id="73401-136">テスト ラボなど、保護された環境で Device Portal を使っている場合、ローカル ネットワーク上のすべてのユーザーを信頼していて、デバイス上に個人情報が保存されておらず、固有の要件もない場合は、認証を無効にできます。</span><span class="sxs-lookup"><span data-stu-id="73401-136">If you are using Device Portal in a protected environment, like a test lab, where you trust everyone on your local network, have no personal information on the device, and have unique requirements, you can disable authentication.</span></span> <span data-ttu-id="73401-137">これにより、暗号化されていない通信が有効化され、電話の IP アドレスを持つすべてのユーザーが制御できるようになります。</span><span class="sxs-lookup"><span data-stu-id="73401-137">This enables unencrypted communication, and allows anyone with the IP address of your phone to control it.</span></span>

## <a name="tool-notes"></a><span data-ttu-id="73401-138">ツールに関する注意事項</span><span class="sxs-lookup"><span data-stu-id="73401-138">Tool Notes</span></span>

## <a name="device-portal-pages"></a><span data-ttu-id="73401-139">Device Portal のページ</span><span class="sxs-lookup"><span data-stu-id="73401-139">Device Portal pages</span></span>
### <a name="processes"></a><span data-ttu-id="73401-140">プロセス</span><span class="sxs-lookup"><span data-stu-id="73401-140">Processes</span></span>

<span data-ttu-id="73401-141">Windows Mobile Device Portal には、任意のプロセスを強制終了する機能はありません。</span><span class="sxs-lookup"><span data-stu-id="73401-141">The ability to terminate arbitrary processes is not included in the Windows Mobile Device Portal.</span></span> 

<span data-ttu-id="73401-142">モバイル デバイスの Device Portal では、標準のページのセットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="73401-142">Device Portal on mobile devices provides the standard set of pages.</span></span> <span data-ttu-id="73401-143">詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73401-143">For detailed descriptions, see [Windows Device Portal overview](device-portal.md).</span></span>

- <span data-ttu-id="73401-144">アプリ マネージャー</span><span class="sxs-lookup"><span data-stu-id="73401-144">App Manager</span></span>
- <span data-ttu-id="73401-145">アプリのエクスプローラー (分離ストレージ エクスプローラー)</span><span class="sxs-lookup"><span data-stu-id="73401-145">App File Explorer (Isolated Storage Explorer)</span></span>
- <span data-ttu-id="73401-146">プロセス</span><span class="sxs-lookup"><span data-stu-id="73401-146">Processes</span></span>
- <span data-ttu-id="73401-147">パフォーマンスのグラフ</span><span class="sxs-lookup"><span data-stu-id="73401-147">Performance charts</span></span>
- <span data-ttu-id="73401-148">Windows イベント トレーシング (ETW)</span><span class="sxs-lookup"><span data-stu-id="73401-148">Event Tracing for Windows (ETW)</span></span>
- <span data-ttu-id="73401-149">パフォーマンス トレース (WPR)</span><span class="sxs-lookup"><span data-stu-id="73401-149">Performance tracing (WPR)</span></span> 
- <span data-ttu-id="73401-150">デバイス</span><span class="sxs-lookup"><span data-stu-id="73401-150">Devices</span></span>
- <span data-ttu-id="73401-151">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="73401-151">Networking</span></span>

## <a name="see-also"></a><span data-ttu-id="73401-152">関連項目</span><span class="sxs-lookup"><span data-stu-id="73401-152">See also</span></span>

* [<span data-ttu-id="73401-153">Windows Device Portal の概要</span><span class="sxs-lookup"><span data-stu-id="73401-153">Windows Device Portal overview</span></span>](device-portal.md)
* [<span data-ttu-id="73401-154">デバイス ポータル コア API リファレンス</span><span class="sxs-lookup"><span data-stu-id="73401-154">Device Portal core API reference</span></span>](https://docs.microsoft.com/windows/uwp/debug-test-perf/device-portal-api-core)