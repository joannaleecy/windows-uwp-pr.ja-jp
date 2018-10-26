---
title: Windows Hello コンパニオン (IoT) デバイスを使った Windows のロック解除
description: Windows Hello コンパニオン デバイスは、ユーザー認証のエクスペリエンスを強化するために、Windows 10 のデスクトップと組み合わせて使用できるデバイスです。 Windows Hello コンパニオン デバイス フレームワークを使用すると、コンパニオン デバイスは、生体認証を利用できない場合 (たとえば、Windows 10 のデスクトップに顔認証のカメラまたは指紋リーダーのデバイスがない場合など) でも、Windows Hello のための優れたエクスペリエンスを提供できます。
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.assetid: 89f3d331-20cd-457b-83e8-1a22aaab2658
ms.localizationpriority: medium
ms.openlocfilehash: 1bf1ae02a1c1937c02b6c750872dc784d28cd8e0
ms.sourcegitcommit: b7e3d222e229cdbf04e837fcb94fb7d84a93de09
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5597384"
---
# <a name="windows-unlock-with-windows-hello-companion-iot-devices"></a><span data-ttu-id="63f36-105">Windows Hello コンパニオン (IoT) デバイスを使った Windows のロック解除</span><span class="sxs-lookup"><span data-stu-id="63f36-105">Windows Unlock with Windows Hello companion (IoT) devices</span></span>

<span data-ttu-id="63f36-106">Windows Hello コンパニオン デバイスは、ユーザー認証のエクスペリエンスを強化するために、Windows 10 のデスクトップと組み合わせて使用できるデバイスです。</span><span class="sxs-lookup"><span data-stu-id="63f36-106">A Windows Hello companion device is a device that can act in conjunction with your Windows 10 desktop to enhance the user authentication experience.</span></span> <span data-ttu-id="63f36-107">Windows Hello コンパニオン デバイス フレームワークを使用すると、コンパニオン デバイスは、生体認証を利用できない場合 (たとえば、Windows 10 のデスクトップに顔認証のカメラまたは指紋リーダーのデバイスがない場合など) でも、Windows Hello のための優れたエクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-107">Using the Windows Hello companion device framework, a companion device can provide a rich experience for Windows Hello even when biometrics are not available (e.g., if the Windows 10 desktop lacks a camera for face authentication or fingerprint reader device, for example).</span></span>

> <span data-ttu-id="63f36-108">**注:** Windows Hello コンパニオン デバイス フレームワークは特別な機能です。すべてのアプリ開発者が利用できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-108">**Note** The Windows Hello companion device framework is a specialized feature not available to all app developers.</span></span> <span data-ttu-id="63f36-109">このフレームワークを使用するには、アプリが Microsoft によって明確にプロビジョニングされ、制限された *secondaryAuthenticationFactor* 機能がアプリ マニフェストに含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-109">To use this framework, your app must be specifically provisioned by Microsoft and list the restricted *secondaryAuthenticationFactor* capability in its manifest.</span></span> <span data-ttu-id="63f36-110">承認を得るには、[cdfonboard@microsoft.com](mailto:cdfonboard@microsoft.com) にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="63f36-110">To obtain approval, contact [cdfonboard@microsoft.com](mailto:cdfonboard@microsoft.com).</span></span>

## <a name="introduction"></a><span data-ttu-id="63f36-111">はじめに</span><span class="sxs-lookup"><span data-stu-id="63f36-111">Introduction</span></span>

> <span data-ttu-id="63f36-112">概要については、Channel 9 で Build 2016 の「[Windows Unlock with IoT Devices](https://channel9.msdn.com/Events/Build/2016/P491)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63f36-112">For a video overview, see the [Windows Unlock with IoT Devices](https://channel9.msdn.com/Events/Build/2016/P491) session from Build 2016 on Channel 9.</span></span>

> <span data-ttu-id="63f36-113">コード サンプルについては、[Windows Hello コンパニオン デバイス フレームワークの GitHub リポジトリ](https://github.com/Microsoft/companion-device-framework)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63f36-113">For code samples, see the [Windows Hello companion device framework Github repository](https://github.com/Microsoft/companion-device-framework).</span></span>

### <a name="use-cases"></a><span data-ttu-id="63f36-114">使用事例</span><span class="sxs-lookup"><span data-stu-id="63f36-114">Use cases</span></span>

<span data-ttu-id="63f36-115">さまざまな方法で Windows Hello コンパニオン デバイス フレームワークを使用して、コンパニオン デバイスによる優れた Windows のロック解除エクスペリエンスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-115">There are numerous ways one can use the Windows Hello companion device framework to build a great Windows unlock experience with a companion device.</span></span> <span data-ttu-id="63f36-116">たとえば、ユーザーは、次のことを実行できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-116">For example, users could:</span></span>

- <span data-ttu-id="63f36-117">コンパニオン デバイスを USB 経由で PC に接続し、コンパニオン デバイスのボタンにタッチすると、PC のロックが自動的に解除されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-117">Attach their companion device to PC via USB, touch the button on the companion device, and automatically unlock their PC.</span></span>
- <span data-ttu-id="63f36-118">PC と Bluetooth でペアリング済みの電話を携帯します。</span><span class="sxs-lookup"><span data-stu-id="63f36-118">Carry a phone in their pocket that is already paired with PC over Bluetooth.</span></span> <span data-ttu-id="63f36-119">PC の Space キーを押すと、電話が通知を受信します。</span><span class="sxs-lookup"><span data-stu-id="63f36-119">Upon hitting the spacebar on their PC, their phone receives a notification.</span></span> <span data-ttu-id="63f36-120">通知を承認するだけで、PC のロックが解除されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-120">Approve it and the PC simply unlocks.</span></span>
- <span data-ttu-id="63f36-121">NFC リーダーにコンパニオン デバイスをタップすると、PC のロックがすぐに解除されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-121">Tap their companion device to an NFC reader to quickly unlock their PC.</span></span>
- <span data-ttu-id="63f36-122">ユーザーの認証を完了しているフィットネス バンドを装着します。</span><span class="sxs-lookup"><span data-stu-id="63f36-122">Wear a fitness band that has already authenticated the wearer.</span></span> <span data-ttu-id="63f36-123">PC に近づいて特別なジェスチャ (拍手など) を実行すると、PC のロックが解除されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-123">Upon approaching PC, and by performing a special gesture (like clapping), the PC unlocks.</span></span>

### <a name="biometric-enabled-windows-hello-companion-devices"></a><span data-ttu-id="63f36-124">生体認証対応 Windows Hello コンパニオン デバイス</span><span class="sxs-lookup"><span data-stu-id="63f36-124">Biometric enabled Windows Hello companion devices</span></span>

<span data-ttu-id="63f36-125">コンパニオン デバイスが生体認証をサポートしている場合は、Windows Hello コンパニオン デバイス フレームワークよりも [Windows 生体認証フレームワーク](https://msdn.microsoft.com/library/windows/hardware/mt608302(v=vs.85).aspx)の方が効果的なことがあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-125">If the companion device supports biometrics, in some cases the [Windows Biometric framework](https://msdn.microsoft.com/library/windows/hardware/mt608302(v=vs.85).aspx) may be a better solution than the Windows Hello companion device framework.</span></span> <span data-ttu-id="63f36-126">適切なアプローチについては、[cdfonboard@microsoft.com](mailto:cdfonboard@microsoft.com) にお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="63f36-126">Please contact [cdfonboard@microsoft.com](mailto:cdfonboard@microsoft.com) and we'll help you pick the right approach.</span></span>

### <a name="components-of-the-solution"></a><span data-ttu-id="63f36-127">ソリューションのコンポーネント</span><span class="sxs-lookup"><span data-stu-id="63f36-127">Components of the solution</span></span>

<span data-ttu-id="63f36-128">次の図は、ソリューションのコンポーネントと、各コンポーネントの作成元を示しています。</span><span class="sxs-lookup"><span data-stu-id="63f36-128">The diagram below depicts the components of the solution and who is responsible for building them.</span></span>

![フレームワークの概要](images/companion-device-1.png)

<span data-ttu-id="63f36-130">Windows Hello コンパニオン デバイス フレームワークは、Windows で実行されるサービスとして実装されます (この記事では Companion Authentication Service と呼びます)。</span><span class="sxs-lookup"><span data-stu-id="63f36-130">The Windows Hello companion device framework is implemented as a service running on Windows (called the Companion Authentication Service in this article).</span></span> <span data-ttu-id="63f36-131">このサービスは、Windows Hello コンパニオン デバイスに保存される HMAC キーによって保護する必要があるロック解除トークンを生成します。</span><span class="sxs-lookup"><span data-stu-id="63f36-131">This service is responsible for generating an unlock token which needs to be protected by an HMAC key stored on the Windows Hello companion device.</span></span> <span data-ttu-id="63f36-132">これにより、ロック解除トークンにアクセスするには、Windows Hello コンパニオン デバイスが必ず必要になります。</span><span class="sxs-lookup"><span data-stu-id="63f36-132">This guarantees that access to the unlock token requires Windows Hello companion device presence.</span></span> <span data-ttu-id="63f36-133">組 (PC、Windows ユーザー) ごとに、一意のロック解除トークンがあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-133">Per each (PC, Windows user) tuple, there will be a unique unlock token.</span></span>

<span data-ttu-id="63f36-134">Windows Hello コンパニオン デバイス フレームワークとの統合には、以下が必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-134">Integration with the Windows Hello Companion Device Framework requires:</span></span>

- <span data-ttu-id="63f36-135">コンパニオン デバイス用の[ユニバーサル Windows プラットフォーム (UWP)](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide) Windows Hello コンパニオン デバイス アプリ。Windows アプリ ストアからダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="63f36-135">A [Universal Windows Platform (UWP)](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide) Windows Hello companion device app for the companion device, downloaded from the Windows app store.</span></span> 
- <span data-ttu-id="63f36-136">2 つの 256 ビットの HMAC キーを Windows Hello コンパニオン デバイス上に作成し、HMAC を (SHA-256 を使用して) 生成する能力。</span><span class="sxs-lookup"><span data-stu-id="63f36-136">The ability to create two 256 bit HMAC keys on the Windows Hello companion device and generate HMAC with it (using SHA-256).</span></span>
- <span data-ttu-id="63f36-137">適切に構成された Windows 10 デスクトップのセキュリティ設定。</span><span class="sxs-lookup"><span data-stu-id="63f36-137">Security settings on the Windows 10 desktop properly configured.</span></span> <span data-ttu-id="63f36-138">Companion Authentication Service では、Windows Hello コンパニオン デバイスが接続される前に PIN が設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-138">The Companion Authentication Service will require this PIN to be set up before any Windows Hello companion device can be plugged into it.</span></span> <span data-ttu-id="63f36-139">ユーザーは、[設定]、[アカウント]、[サインイン オプション] の順に移動して、PIN を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-139">The users must set up a PIN via Settings > Accounts > Sign-in options.</span></span>

<span data-ttu-id="63f36-140">上記の要件に加え、Windows Hello コンパニオン デバイス アプリは、次のことに対して責任を負います。</span><span class="sxs-lookup"><span data-stu-id="63f36-140">In addition to the above requirements, the Windows Hello companion device app is responsible for:</span></span>

- <span data-ttu-id="63f36-141">初回登録のユーザー エクスペリエンスとブランディング、およびその後の Windows Hello コンパニオン デバイスの登録解除。</span><span class="sxs-lookup"><span data-stu-id="63f36-141">User experience and branding of initial registration and later de-registration of the Windows Hello companion device.</span></span>
- <span data-ttu-id="63f36-142">バック グラウンドで実行、Windows Hello コンパニオン デバイスの検出、Windows Hello コンパニオン デバイスおよび Companion Authentication Service との通信。</span><span class="sxs-lookup"><span data-stu-id="63f36-142">Running in the background, discovering the Windows Hello companion device, communicating to the Windows Hello companion device and also Companion Authentication Service.</span></span>
- <span data-ttu-id="63f36-143">エラー処理</span><span class="sxs-lookup"><span data-stu-id="63f36-143">Error handling</span></span>

<span data-ttu-id="63f36-144">通常、コンパニオン デバイスには、フィットネス バンドの初回の設定などを実行するための初期セットアップ用のアプリが付属します。</span><span class="sxs-lookup"><span data-stu-id="63f36-144">Normally, companion devices ship with an app for initial setup, like setting up a fitness band for the first time.</span></span> <span data-ttu-id="63f36-145">このドキュメントに記載されている機能は、そのアプリの一部にすることができ、別のアプリは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-145">The functionality described in this document can be part of that app and a separate app should not be required.</span></span>  

### <a name="user-signals"></a><span data-ttu-id="63f36-146">ユーザー シグナル</span><span class="sxs-lookup"><span data-stu-id="63f36-146">User signals</span></span>

<span data-ttu-id="63f36-147">各 Windows Hello コンパニオン デバイスは、3 種類のユーザー シグナルをサポートするアプリと組み合わせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-147">Each Windows Hello companion device should be combined with an app that supports three user signals.</span></span> <span data-ttu-id="63f36-148">これらのシグナルは、操作またはジェスチャの形を取ることができます。</span><span class="sxs-lookup"><span data-stu-id="63f36-148">These signals can be in form of an action or gesture.</span></span>

- <span data-ttu-id="63f36-149">**インテント シグナル**: ユーザーがロックを解除する意図があることを提示できるようにします (例: Windows Hello コンパニオン デバイス上のボタンを押す)。</span><span class="sxs-lookup"><span data-stu-id="63f36-149">**Intent signal**: Allows the user to show his intent for unlock by, for example, hitting a button on the Windows Hello companion device.</span></span> <span data-ttu-id="63f36-150">インテント シグナルは、**Windows Hello コンパニオン デバイス**側で収集する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-150">The intent signal must be collected on **Windows Hello companion device** side.</span></span>
- <span data-ttu-id="63f36-151">**ユーザー プレゼンス シグナル**: ユーザーがそばにいることを証明します。</span><span class="sxs-lookup"><span data-stu-id="63f36-151">**User presence signal**: Proves the presence of the user.</span></span> <span data-ttu-id="63f36-152">Windows Hello コンパニオン デバイスを使用して PC のロックを解除するには、その前に PIN (PC の PIN と混同しないでください) が必要になることがあります。または、ボタンの押下が必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-152">The Windows Hello companion device might, for instance, require a PIN before it can be used for unlocking PC (not to be confused with PC PIN), or it might require press of a button.</span></span>
- <span data-ttu-id="63f36-153">**曖昧性解消シグナル**: Windows Hello コンパニオン デバイスで複数のオプションを使用できるときに、ユーザーがどの Windows 10 デスクトップのロックを解除するかを明確にします。</span><span class="sxs-lookup"><span data-stu-id="63f36-153">**Disambiguation signal**: Disambiguates which Windows 10 desktop the user wants to unlock when multiple options are available to the Windows Hello companion device.</span></span>

<span data-ttu-id="63f36-154">任意の数のユーザー シグナルを 1 つに組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="63f36-154">Any number of these user signals can be combined into one.</span></span> <span data-ttu-id="63f36-155">ユーザー プレゼンス シグナルとインテント シグナルは、毎回の使用時に必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-155">User presence and intent signals must be required on each use.</span></span>

### <a name="registration-and-future-communication-between-a-pc-and-windows-hello-companion-devices"></a><span data-ttu-id="63f36-156">登録および登録後の PC と Windows Hello コンパニオン デバイス間の通信</span><span class="sxs-lookup"><span data-stu-id="63f36-156">Registration and future communication between a PC and Windows Hello companion devices</span></span>

<span data-ttu-id="63f36-157">Windows Hello コンパニオン デバイスは、Windows Hello コンパニオン デバイス フレームワークに接続する前に、フレームワークに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-157">Before a Windows Hello companion device can be plugged into the Windows Hello companion device framework, it needs to be registered with the framework.</span></span> <span data-ttu-id="63f36-158">登録エクスペリエンスは、Windows Hello コンパニオン デバイス アプリがすべて管理します。</span><span class="sxs-lookup"><span data-stu-id="63f36-158">The experience for registration is completely owned by the Windows Hello companion device app.</span></span>

<span data-ttu-id="63f36-159">Windows Hello コンパニオン デバイスと Windows 10 デスクトップ デバイスは、1 対多の関係にできます (つまり、1 台のコンパニオン デバイスを、多数の Windows 10 デスクトップ デバイスで使用できます)。</span><span class="sxs-lookup"><span data-stu-id="63f36-159">The relationship between the Windows Hello companion device and the Windows 10 desktop  device can be one to many (i.e., one companion device can be used for many Windows 10 desktop  devices).</span></span> <span data-ttu-id="63f36-160">ただし、各 Windows Hello コンパニオン デバイスは、Windows 10 デスクトップ デバイスごとに 1 人のユーザーのみが使用できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-160">However, each Windows Hello companion device can only be used for one user on each Windows 10 desktop  device.</span></span>   

<span data-ttu-id="63f36-161">Windows Hello コンパニオン デバイスは、PC と通信する前に、使用するトランスポートに関して合意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-161">Before a Windows Hello companion device can communicate with a PC, they need to agree on a transport to use.</span></span> <span data-ttu-id="63f36-162">その選択肢は Windows Hello コンパニオン デバイス アプリに任されています。Windows Hello コンパニオン デバイス フレームワークによって、Windows Hello コンパニオン デバイスと Windows 10 デスクトップ デバイス側の Windows Hello コンパニオン デバイス アプリの間で使用される、トランスポートの種類 (USB、NFC、WiFi、BT、BLE など) またはプロトコルが制限されることはありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-162">Such choice is left to the Windows Hello companion device app; the Windows Hello companion device framework does not impose any limitations on transport type (USB, NFC, WiFi, BT, BLE, etc) or protocol being used between the Windows Hello companion device and the Windows Hello companion device app on the Windows 10 desktop device side.</span></span> <span data-ttu-id="63f36-163">ただし、トランスポート層のセキュリティに関する考慮事項が、このドキュメントの「セキュリティ要件」セクションに示されています。</span><span class="sxs-lookup"><span data-stu-id="63f36-163">It does, however, suggest certain security considerations for the transport layer as outlined in the "Security Requirements" section of this document.</span></span> <span data-ttu-id="63f36-164">これらの要件に対応する責任は、デバイス プロバイダーの側にあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-164">It is the device provider’s responsibility to provide those requirements.</span></span> <span data-ttu-id="63f36-165">フレームワークがこれらに対応することはありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-165">The framework does not provide them for you.</span></span>


## <a name="user-interaction-model"></a><span data-ttu-id="63f36-166">ユーザー インタラクション モデル</span><span class="sxs-lookup"><span data-stu-id="63f36-166">User Interaction Model</span></span>

### <a name="windows-hello-companion-device-app-discovery-installation-and-first-time-registration"></a><span data-ttu-id="63f36-167">Windows Hello コンパニオン デバイス アプリの検出、インストール、および初回登録</span><span class="sxs-lookup"><span data-stu-id="63f36-167">Windows Hello companion device app discovery, installation, and first-time registration</span></span>

<span data-ttu-id="63f36-168">一般的なユーザー ワークフローは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="63f36-168">A typical user workflow is as follows:</span></span>

- <span data-ttu-id="63f36-169">ユーザーは、Windows Hello コンパニオン デバイスを使用してロックを解除する各 Windows 10 デスクトップ デバイスで PIN を設定します。</span><span class="sxs-lookup"><span data-stu-id="63f36-169">The user sets up the PIN on each of target Windows 10 desktop devices she wants to unlock with that Windows Hello companion device.</span></span>
- <span data-ttu-id="63f36-170">ユーザーは、Windows 10 デスクトップ デバイスで Windows Hello コンパニオン デバイス アプリを実行して、自分の Windows Hello コンパニオン デバイスを Windows 10 デスクトップ デバイスに登録します。</span><span class="sxs-lookup"><span data-stu-id="63f36-170">The user runs the Windows Hello companion device app on their Windows 10 desktop device to register her Windows Hello companion device with Windows 10 desktop.</span></span>

<span data-ttu-id="63f36-171">注意事項:</span><span class="sxs-lookup"><span data-stu-id="63f36-171">Notes:</span></span>

- <span data-ttu-id="63f36-172">Windows Hello コンパニオン デバイス アプリの検出、ダウンロード、および起動は効率化し、可能な場合は自動化することをお勧めします (たとえば、Windows Hello コンパニオン デバイスを Windows 10 デスクトップ デバイス側の NFC リーダーでタップしたときに、アプリを自動的にダウンロードできるようにします)。</span><span class="sxs-lookup"><span data-stu-id="63f36-172">We recommend the discovery, download, and launch of the Windows Hello companion device app is streamlined and, if possible, automated (e.g., the app can be downloaded upon tapping the Windows Hello companion device on an NFC reader on Windows 10 desktop device side).</span></span> <span data-ttu-id="63f36-173">ただし、これは、Windows Hello コンパニオン デバイスと Windows Hello コンパニオン デバイス アプリの責任で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-173">This is, however, the responsibility of the Windows Hello companion device and Windows Hello companion device app.</span></span>
- <span data-ttu-id="63f36-174">エンタープライズ環境では、MDM によって Windows Hello コンパニオン デバイス アプリを展開できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-174">In an enterprise environment, the Windows Hello companion device app can be deployed via MDM.</span></span>
- <span data-ttu-id="63f36-175">登録の一部として発生するエラー メッセージの表示は、Windows Hello コンパニオン デバイス アプリが担当します。</span><span class="sxs-lookup"><span data-stu-id="63f36-175">The Windows Hello companion device app is responsible for showing the user any error messages that happen as part of registration.</span></span>

### <a name="registration-and-de-registration-protocol"></a><span data-ttu-id="63f36-176">登録/登録解除プロトコル</span><span class="sxs-lookup"><span data-stu-id="63f36-176">Registration and de-registration protocol</span></span>

<span data-ttu-id="63f36-177">次の図は、登録時の Windows Hello コンパニオン デバイスと Companion Authentication Service の対話方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="63f36-177">The following diagram illustrates how the Windows Hello companion device interacts with Companion Authentication Service during registration.</span></span>  

![登録フロー](images/companion-device-2.png)

<span data-ttu-id="63f36-179">このプロトコルでは、2 つのキーが使用されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-179">There are two keys used in our protocol:</span></span>

- <span data-ttu-id="63f36-180">デバイス キー (**devicekey**): PC が Windows のロックを解除するために必要なロック解除トークンを保護するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-180">Device key (**devicekey**): used to protect unlock tokens that the PC needs to unlock Windows.</span></span>
- <span data-ttu-id="63f36-181">認証キー (**authkey**): Windows Hello コンパニオン デバイスと Companion Authentication Service を相互認証するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-181">The authentication key (**authkey**): used to mutually authenticate the Windows Hello companion device and Companion Authentication Service.</span></span>

<span data-ttu-id="63f36-182">デバイス キーと認証キーは、登録時に Windows Hello コンパニオン デバイス アプリと Windows Hello コンパニオン デバイスの間で交換されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-182">The device key and authentication keys are exchanged at registration time between the Windows Hello companion device app and Windows Hello companion device.</span></span> <span data-ttu-id="63f36-183">このため、Windows Hello コンパニオン デバイス アプリと Windows Hello コンパニオン デバイスは、セキュリティで保護されたトランスポートを使用してキーを保護する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-183">As a result, the Windows Hello companion device app and Windows Hello companion device must use a secure transport to protect keys.</span></span>

<span data-ttu-id="63f36-184">また、上の図では、Windows Hello コンパニオン デバイスで 2 つの HMAC キーが生成されていますが、これらをアプリで生成して Windows Hello コンパニオン デバイスに送信して保存することもできます。</span><span class="sxs-lookup"><span data-stu-id="63f36-184">Also, note that while the diagram above displays two HMAC keys generating on the Windows Hello companion device, it is also possible for the app to generate them and send them to the Windows Hello companion device for storage.</span></span>

### <a name="starting-authentication-flows"></a><span data-ttu-id="63f36-185">認証開始フロー</span><span class="sxs-lookup"><span data-stu-id="63f36-185">Starting authentication flows</span></span>

<span data-ttu-id="63f36-186">ユーザーが Windows Hello コンパニオン デバイス フレームワークを使用して Windows 10 デスクトップへのサインインを開始する (つまりインテント シグナルを提供する) 方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-186">There are two ways for the user to start the signing in flow to Windows 10 desktop using Windows Hello companion device framework (i.e., provide intent signal):</span></span>

- <span data-ttu-id="63f36-187">ノート PC のカバーを開くか、PC で Space キーを押すか画面をスワイプする。</span><span class="sxs-lookup"><span data-stu-id="63f36-187">Open up the lid on laptop, or hit the space bar or swipe up on PC.</span></span>
- <span data-ttu-id="63f36-188">Windows Hello コンパニオン デバイス側でジェスチャまたはアクションを実行する。</span><span class="sxs-lookup"><span data-stu-id="63f36-188">Perform a gesture or an action on the Windows Hello companion device side.</span></span>

<span data-ttu-id="63f36-189">どちらで始めるかは、Windows Hello コンパニオン デバイス側が選択します。</span><span class="sxs-lookup"><span data-stu-id="63f36-189">It is the Windows Hello companion device's choice to select which one is the starting point.</span></span> <span data-ttu-id="63f36-190">Windows Hello コンパニオン デバイス フレームワークは、オプション 1 が発生したら、それをコンパニオン デバイス アプリに通知します。</span><span class="sxs-lookup"><span data-stu-id="63f36-190">The Windows Hello companion device framework will inform companion device app when option one happens.</span></span> <span data-ttu-id="63f36-191">オプション 2 では、Windows Hello コンパニオン デバイス アプリがコンパニオン デバイスにクエリを行って、そのイベントがキャプチャされたかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-191">For option two, the Windows Hello companion device app should query the companion device to see if that event has been captured.</span></span> <span data-ttu-id="63f36-192">これにより、Windows Hello コンパニオン デバイスがインテント シグナルを収集した後、必ずロック解除が成功します。</span><span class="sxs-lookup"><span data-stu-id="63f36-192">This ensures the Windows Hello companion device collects the intent signal before the unlock succeeds.</span></span>

### <a name="windows-hello-companion-device-credential-provider"></a><span data-ttu-id="63f36-193">Windows Hello コンパニオン デバイス資格情報プロバイダー</span><span class="sxs-lookup"><span data-stu-id="63f36-193">Windows Hello companion device credential provider</span></span>

<span data-ttu-id="63f36-194">Windows 10 には、すべての Windows Hello コンパニオン デバイスを処理する新しい資格情報プロバイダーがあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-194">There is a new credential provider in Windows 10 that handles all Windows Hello companion devices.</span></span>

<span data-ttu-id="63f36-195">トリガーのアクティブ化によるコンパニオン デバイスのバックグラウンド タスクの起動は、Windows Hello コンパニオン デバイス資格情報プロバイダーが担当します。</span><span class="sxs-lookup"><span data-stu-id="63f36-195">The Windows Hello companion device credential provider is responsible for launching the companion device background task via activating a trigger.</span></span> <span data-ttu-id="63f36-196">トリガーは、PC が起動され、ロック画面が表示されたときに、1 回目の設定が行われます。</span><span class="sxs-lookup"><span data-stu-id="63f36-196">The trigger is set the first time when the PC awakens and a lock screen is displayed.</span></span> <span data-ttu-id="63f36-197">2 回目は、PC がログオン UI に移行し、Windows Hello コンパニオン デバイス資格情報プロバイダー タイルが選択された時点です。</span><span class="sxs-lookup"><span data-stu-id="63f36-197">The second time is when the PC is entering logon UI and the Windows Hello companion device credential provider is the selected tile.</span></span>

<span data-ttu-id="63f36-198">Windows Hello コンパニオン デバイス アプリのヘルパー ライブラリが、ロック画面の状態の変化をリッスンし、Windows Hello コンパニオン デバイスのバック グラウンド タスクに対応するイベントを送信します。</span><span class="sxs-lookup"><span data-stu-id="63f36-198">The helper library for the Windows Hello companion device app will listen to the lock screen status change and send the event corresponding to the Windows Hello companion device background task.</span></span>

<span data-ttu-id="63f36-199">複数の Windows Hello コンパニオン デバイスのバックグラウンド タスクがある場合は、最初に認証処理を終了したバックンド タスクが PC のロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="63f36-199">If there are multiple Windows Hello companion device background tasks, the first background task that has finished the authentication process will unlock the PC.</span></span> <span data-ttu-id="63f36-200">コンパニオン デバイス認証サービスは、残りの認証呼び出しを無視します。</span><span class="sxs-lookup"><span data-stu-id="63f36-200">The companion device authentication service will ignore any remaining authentication calls.</span></span>

<span data-ttu-id="63f36-201">Windows Hello コンパニオン デバイス側のエクスペリエンスは、Windows Hello コンパニオン デバイス アプリが処理と管理を行います。</span><span class="sxs-lookup"><span data-stu-id="63f36-201">The experience on the Windows Hello companion device side is owned and managed by the Windows Hello companion device app.</span></span> <span data-ttu-id="63f36-202">Windows Hello コンパニオン デバイス フレームワークは、ユーザー エクスペリエンスのこの部分を制御しません。</span><span class="sxs-lookup"><span data-stu-id="63f36-202">The Windows Hello companion device framework has no control over this part of the user experience.</span></span> <span data-ttu-id="63f36-203">具体的には、コンパニオン認証プロバイダーは、ログオン UI の状態の変化 (ロック画面が今表示されたことや、ユーザーが Space キーを押してロック画面を消したばかりであることなど) を Windows Hello コンパニオン デバイス アプリに (そのバックグラウンド アプリ経由で) 通知します。その周辺のエクスペリエンス (ユーザーが Space キーを押したときのロック画面の消去や、USB 上のデバイス検索の開始など) の構築は、Windows Hello コンパニオン デバイス アプリが担当します。</span><span class="sxs-lookup"><span data-stu-id="63f36-203">More specifically, the companion authentication provider informs the Windows Hello companion device app (via its background app) about state changes in logon UI (e.g., lock screen just came down, or the user just dispelled lock screen by hitting spacebar), and it is the responsibility of the Windows Hello companion device app to build an experience around that (e.g., upon user hitting spacebar and dispelling unlock screen, start looking for the device over USB).</span></span>

<span data-ttu-id="63f36-204">Windows Hello コンパニオン デバイス フレームワークには、Windows Hello コンパニオン デバイス アプリが選択できる (ローカライズされた) テキストとエラー メッセージが多数用意されています。</span><span class="sxs-lookup"><span data-stu-id="63f36-204">The Windows Hello companion device Framework will provide a stock of (localized) text and error messages for the Windows Hello companion device app to choose from.</span></span> <span data-ttu-id="63f36-205">これらは、ロック画面の上部 (またはログオン UI) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-205">These will be displayed on top of lock screen (or in logon UI).</span></span> <span data-ttu-id="63f36-206">詳細については、メッセージとエラーの処理に関するセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="63f36-206">See the Dealing with Messages and Errors section for more details.</span></span>

### <a name="authentication-protocol"></a><span data-ttu-id="63f36-207">認証プロトコル</span><span class="sxs-lookup"><span data-stu-id="63f36-207">Authentication protocol</span></span>

<span data-ttu-id="63f36-208">トリガーによって開始された Windows Hello コンパニオン デバイス アプリに関連付けられたバックグラウンド タスクは、Companion Authentication Service によって計算された HMAC 値を検証し、2 つの HMAC 値の計算を支援するように、Windows Hello コンパニオン デバイスに依頼する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-208">Once the background task associated with a Windows Hello companion device app is trigger started, it is responsible for asking the Windows Hello companion device to validate an HMAC value computed by the Companion Authentication Service and help calculate two HMAC values:</span></span>
- <span data-ttu-id="63f36-209">サービス HMAC = HMAC (認証キー, サービス nonce || デバイス nonce || セッション nonce) を検証する。</span><span class="sxs-lookup"><span data-stu-id="63f36-209">Validate Service HMAC = HMAC(authentication key, service nonce || device nonce || session nonce).</span></span>
- <span data-ttu-id="63f36-210">nonce を使用してデバイス キーの HMAC を計算する。</span><span class="sxs-lookup"><span data-stu-id="63f36-210">Calculate the HMAC of the device key with a nonce.</span></span>
- <span data-ttu-id="63f36-211">Companion Authentication Service によって生成された nonce が連結された最初の HMAC 値を持つ認証キーの HMAC を計算する。</span><span class="sxs-lookup"><span data-stu-id="63f36-211">Calculate the HMAC of the authentication key with first HMAC value concatenated with a nonce generated by the Companion Authentication Service.</span></span>

<span data-ttu-id="63f36-212">2 番目の計算値は、サービスがデバイスを認証し、さらにトランスポート チャネルでのリプレイ攻撃を防ぐために使用されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-212">The second computed value is used by the service to authenticate the device and also prevent replay attack in transport channel.</span></span>

![登録フロー](images/companion-device-3.png)

## <a name="lifecycle-management"></a><span data-ttu-id="63f36-214">ライフサイクルの管理</span><span class="sxs-lookup"><span data-stu-id="63f36-214">Lifecycle management</span></span>

### <a name="register-once-use-everywhere"></a><span data-ttu-id="63f36-215">一度登録すればどこでも使える</span><span class="sxs-lookup"><span data-stu-id="63f36-215">Register once, use everywhere</span></span>

<span data-ttu-id="63f36-216">バックエンド サーバーなしで、ユーザーは、自分の Windows Hello コンパニオン デバイスを、各 Windows 10 デスクトップ デバイスに個別に登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-216">Without a backend server, users must register their Windows Hello companion device with each Windows 10 desktop device separately.</span></span>

<span data-ttu-id="63f36-217">コンパニオン デバイス ベンダーや OEM は、ユーザーの Windows 10 デスクトップやモバイル デバイスの登録状態をローミングする Web サービスを実装できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-217">A companion device vendor or OEM can implement a web service to roam the registration state across user Windows 10 desktops or mobile devices.</span></span> <span data-ttu-id="63f36-218">詳細については、ローミング、無効化、およびフィルター サービスに関するセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63f36-218">For more details, see the Roaming, Revocation, and Filter Service section.</span></span>

### <a name="pin-management"></a><span data-ttu-id="63f36-219">PIN 管理</span><span class="sxs-lookup"><span data-stu-id="63f36-219">PIN management</span></span>

<span data-ttu-id="63f36-220">コンパニオン デバイスを使用する前に、Windows 10 デスクトップ デバイスに PIN を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-220">Before a companion device can be used, a PIN needs to be set up on Windows 10 desktop device.</span></span> <span data-ttu-id="63f36-221">これにより、ユーザーの Windows Hello コンパニオン デバイスが動作しない場合のバックアップが保証されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-221">This ensures the user has a backup in case their Windows Hello companion device is not working.</span></span> <span data-ttu-id="63f36-222">PIN は、Windows によって管理されるものであり、アプリがまったく認識しないものです。</span><span class="sxs-lookup"><span data-stu-id="63f36-222">The PIN is something that Windows manages and that apps never see.</span></span> <span data-ttu-id="63f36-223">これを変更するには、ユーザーは、[設定]、[アカウント]、[サインイン オプション] の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="63f36-223">To change it, the user navigates to Settings > Accounts > Sign-in options.</span></span>

### <a name="management-and-policy"></a><span data-ttu-id="63f36-224">管理とポリシー</span><span class="sxs-lookup"><span data-stu-id="63f36-224">Management and policy</span></span>

<span data-ttu-id="63f36-225">ユーザーは、Windows 10 デスクトップ デバイス上の Windows Hello コンパニオン デバイス アプリを実行することで、Windows 10 デスクトップから Windows Hello コンパニオン デバイスを削除できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-225">Users can remove a Windows Hello companion device from a Windows 10 desktops by running the Windows Hello companion device app on that desktop device.</span></span>

<span data-ttu-id="63f36-226">企業では、Windows Hello コンパニオン デバイス フレームワークを制御するためのオプションは 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-226">Enterprises have two options for controlling the Windows Hello companion device framework:</span></span>

- <span data-ttu-id="63f36-227">機能を有効または無効にする</span><span class="sxs-lookup"><span data-stu-id="63f36-227">Turn the feature on or off</span></span>
- <span data-ttu-id="63f36-228">Windows AppLocker を使用して、許可される Windows Hello コンパニオン デバイスのホワイトリストを定義する</span><span class="sxs-lookup"><span data-stu-id="63f36-228">Define the whitelist of Windows Hello companion devices allowed using Windows app locker</span></span>

<span data-ttu-id="63f36-229">Windows Hello コンパニオン デバイス フレームワークでは、使用可能なコンパニオン デバイスのインベントリを保持するための一元管理や、許可される Windows Hello コンパニオン デバイスの種類のフィルター処理 (たとえば、シリアル番号が X ～ Y の範囲にあるデバイスのみを許可する) がサポートされません。</span><span class="sxs-lookup"><span data-stu-id="63f36-229">The Windows Hello companion device framework does not support any centralized way to keep inventory of available companion devices, or a method to further filter which instances of a Windows Hello companion device type is allowed (for example, only a companion device with a serial number between X and Y are allowed).</span></span> <span data-ttu-id="63f36-230">ただし、アプリ開発者は、このような機能を提供するサービスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-230">Apps developers can, however, build a service to provide such functionality.</span></span> <span data-ttu-id="63f36-231">詳細については、ローミング、無効化、およびフィルター サービスに関するセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="63f36-231">For more details, see the Roaming, Revocation, and Filter Service section.</span></span>

### <a name="revocation"></a><span data-ttu-id="63f36-232">無効化</span><span class="sxs-lookup"><span data-stu-id="63f36-232">Revocation</span></span>

<span data-ttu-id="63f36-233">Windows Hello コンパニオン デバイス フレームワークでは、特定の Windows 10 デスクトップ デバイスからリモートでコンパニオン デバイスを削除できません。</span><span class="sxs-lookup"><span data-stu-id="63f36-233">The Windows Hello companion device framework does not support removing a companion device from a specific Windows 10 desktop device remotely.</span></span> <span data-ttu-id="63f36-234">代わりに、ユーザーが、Windows 10 デスクトップで実行されている Windows Hello コンパニオン デバイス アプリを介して、Windows Hello コンパニオン デバイスを削除することができます。</span><span class="sxs-lookup"><span data-stu-id="63f36-234">Instead, users can remove the Windows Hello companion device via the Windows Hello companion device app running on that Windows 10 desktop.</span></span>

<span data-ttu-id="63f36-235">ただし、コンパニオン デバイス ベンダーは、リモート無効化機能を提供するサービスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-235">Companion device vendors, however, can build a service to provide remote revocation functionality.</span></span> <span data-ttu-id="63f36-236">詳細については、ローミング、無効化、およびフィルター サービスに関するセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="63f36-236">For more details, see Roaming, Revocation, and Filter Service section.</span></span>

### <a name="roaming-and-filter-services"></a><span data-ttu-id="63f36-237">ローミングとフィルター サービス</span><span class="sxs-lookup"><span data-stu-id="63f36-237">Roaming and filter services</span></span>

<span data-ttu-id="63f36-238">コンパニオン デバイス ベンダーは、次のシナリオで使用できる Web サービスを実装できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-238">Companion device vendors can implement a web service that can be used for the following scenarios:</span></span>

- <span data-ttu-id="63f36-239">企業向けのフィルター サービス: 企業は、エンタープライズ環境で動作できる一連の Windows Hello コンパニオン デバイスを、特定のベンダーから選ばれた数台に制限することができます。</span><span class="sxs-lookup"><span data-stu-id="63f36-239">A filter service for enterprise: An enterprise can limit the set of Windows Hello companion devices that can work in their environment to a select few from a specific vendor.</span></span> <span data-ttu-id="63f36-240">たとえば、10,000 台のモデル Y コンパニオン デバイスをベンダー X に発注した Contoso 社は、それらのデバイスのみが Contoso ドメインで動作し、ベンダー X の他のデバイス モデルは動作しないことを保証できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-240">For example, the company Contoso could order 10,000 Model Y companion devices from Vendor X and ensure only those devices will work in the Contoso domain (and not any other device model from Vendor X).</span></span>
- <span data-ttu-id="63f36-241">インベントリ: 企業は、エンタープライズ環境で使用される既存のコンパニオン デバイスの一覧を確認できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-241">Inventory:  An enterprise can determine the list of existing companion devices used in an enterprise environment.</span></span>
- <span data-ttu-id="63f36-242">リアルタイムの無効化: 従業員からコンパニオン デバイスの紛失や盗難があったことが報告された場合に、Web サービスを使用してそのデバイスを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="63f36-242">Real time revocation: If an employee reports that his companion device is lost or stolen, the web service can be used to revoke that device.</span></span>
- <span data-ttu-id="63f36-243">ローミング: ユーザーは、自分のコンパニオン デバイスを 1 回登録するだけで、自分のすべての Windows 10 デスクトップとモバイルで機能させることができます。</span><span class="sxs-lookup"><span data-stu-id="63f36-243">Roaming: A user only has to register his companion device once and it works on all of his Windows 10 desktops and Mobile.</span></span>

<span data-ttu-id="63f36-244">これらの機能を実装するには、登録時と使用時に Web サービスを確認する Windows Hello コンパニオン デバイス アプリが必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-244">Implementing these features requires the Windows Hello companion device app to check with the web service at registration and usage time.</span></span> <span data-ttu-id="63f36-245">Windows Hello コンパニオン デバイス アプリは、Web サービスの確認を 1 日に 1 回のみ要求するようなキャッシュされたログオン シナリオ用に最適化できます (無効化時間が最大 1 日遅くなります)。</span><span class="sxs-lookup"><span data-stu-id="63f36-245">The Windows Hello companion device app can optimize for cached logon scenarios like requiring checking with web service only once a day (at the cost of extending the revocation time to up to one day).</span></span>  

## <a name="windows-hello-companion-device-framework-api-model"></a><span data-ttu-id="63f36-246">Windows Hello コンパニオン デバイス フレームワーク API モデル</span><span class="sxs-lookup"><span data-stu-id="63f36-246">Windows Hello companion device framework API model</span></span>

### <a name="overview"></a><span data-ttu-id="63f36-247">概要</span><span class="sxs-lookup"><span data-stu-id="63f36-247">Overview</span></span>

<span data-ttu-id="63f36-248">Windows Hello コンパニオン デバイス アプリには、デバイスの登録と登録解除を行う UI を持つフォアグラウンド アプリと、認証を処理するバックグラウンド タスクという 2 つのコンポーネントを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-248">A Windows Hello companion device app should contain two components: a foregroud app with UI responsible for registering and unregistering the device, and a background task that handles authentication.</span></span>

<span data-ttu-id="63f36-249">全体的な API フローは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="63f36-249">The overall API flow is as follows:</span></span>

1. <span data-ttu-id="63f36-250">Windows Hello コンパニオン デバイスを登録する</span><span class="sxs-lookup"><span data-stu-id="63f36-250">Register the Windows Hello companion device</span></span>
    * <span data-ttu-id="63f36-251">デバイスが近くにあることを確認し、その機能のクエリを実行する (必要な場合)</span><span class="sxs-lookup"><span data-stu-id="63f36-251">Make sure the device is nearby and query its capability (if required)</span></span>
    * <span data-ttu-id="63f36-252">2 つの HMAC キーを生成する (コンパニオン デバイス側またはアプリ側のどちらかで実行)</span><span class="sxs-lookup"><span data-stu-id="63f36-252">Generate two HMAC keys (either on the companion device side or the app side)</span></span>
    * <span data-ttu-id="63f36-253">RequestStartRegisteringDeviceAsync を呼び出す</span><span class="sxs-lookup"><span data-stu-id="63f36-253">Call RequestStartRegisteringDeviceAsync</span></span>
    * <span data-ttu-id="63f36-254">FinishRegisteringDeviceAsync を呼び出す</span><span class="sxs-lookup"><span data-stu-id="63f36-254">Call FinishRegisteringDeviceAsync</span></span>
    * <span data-ttu-id="63f36-255">Windows Hello コンパニオン デバイス アプリに HMAC キーが保存されていること (サポートされている場合)、および Windows Hello コンパニオン デバイス アプリによってそのコピーが破棄されていることを確認する</span><span class="sxs-lookup"><span data-stu-id="63f36-255">Make sure Windows Hello companion device app stores HMAC keys (if supported) and Windows Hello companion device app discards its copies</span></span>
2. <span data-ttu-id="63f36-256">バックグラウンド タスクを登録する</span><span class="sxs-lookup"><span data-stu-id="63f36-256">Register your background task</span></span>
3. <span data-ttu-id="63f36-257">バック グラウンド タスクで適切なイベントが発生するまで待機する</span><span class="sxs-lookup"><span data-stu-id="63f36-257">Wait for the right event in the background task</span></span>
    * <span data-ttu-id="63f36-258">WaitingForUserConfirmation: Windows Hello コンパニオン デバイス側でのユーザーの操作/ジェスチャーによって認証フローを開始する必要がある場合は、このイベントを待つ</span><span class="sxs-lookup"><span data-stu-id="63f36-258">WaitingForUserConfirmation: Wait for this event if the user action/gesture on the Windows Hello companion device side is required to start authentication flow</span></span>
    * <span data-ttu-id="63f36-259">CollectingCredential: Windows Hello コンパニオン デバイスが、PC 側でのユーザーの操作/ジェスチャー (Space キーを押すことなど) に依存して認証フローを開始する場合は、このイベントを待つ</span><span class="sxs-lookup"><span data-stu-id="63f36-259">CollectingCredential: Wait for this event if the Windows Hello companion device relies on user action/gesture on the PC side to start authentication flow (e.g., by hitting spacebar)</span></span>
    * <span data-ttu-id="63f36-260">その他のトリガー (スマートカードなど): 現在の認証状態のクエリを実行して、適切な API を呼び出す。</span><span class="sxs-lookup"><span data-stu-id="63f36-260">Other trigger, like a smartcard: Make sure to query for current authentication state to call the right APIs.</span></span>
4. <span data-ttu-id="63f36-261">エラー メッセージや次に必要な手順について、ShowNotificationMessageAsync を呼び出してユーザーに通知する。</span><span class="sxs-lookup"><span data-stu-id="63f36-261">Keep user informed about error messages or required next steps by calling ShowNotificationMessageAsync.</span></span> <span data-ttu-id="63f36-262">この API は、インテント シグナルが収集された後でのみ呼び出します</span><span class="sxs-lookup"><span data-stu-id="63f36-262">Only call this API once an intent signal is collected</span></span>
5. <span data-ttu-id="63f36-263">ロックを解除する</span><span class="sxs-lookup"><span data-stu-id="63f36-263">Unlock</span></span>
    * <span data-ttu-id="63f36-264">インテント シグナルとユーザー プレゼンス シグナルが収集されたことを確認する</span><span class="sxs-lookup"><span data-stu-id="63f36-264">Make sure intent and user presence signals were collected</span></span>
    * <span data-ttu-id="63f36-265">StartAuthenticationAsync を呼び出す</span><span class="sxs-lookup"><span data-stu-id="63f36-265">Call StartAuthenticationAsync</span></span>
    * <span data-ttu-id="63f36-266">コンパニオン デバイスと通信して、必要な HMAC 操作を実行する</span><span class="sxs-lookup"><span data-stu-id="63f36-266">Communicate with the companion device to perform required HMAC operations</span></span>
    * <span data-ttu-id="63f36-267">FinishAuthenticationAsync を呼び出す</span><span class="sxs-lookup"><span data-stu-id="63f36-267">Call FinishAuthenticationAsync</span></span>
6. <span data-ttu-id="63f36-268">ユーザーの要求に応じて (ユーザーが Windows Hello コンパニオン デバイスを紛失した場合など)、Windows Hello コンパニオン デバイスの登録を解除する</span><span class="sxs-lookup"><span data-stu-id="63f36-268">Un-register a Windows Hello companion device when the user requests it (for example, if they've lost their companion device)</span></span>
    * <span data-ttu-id="63f36-269">FindAllRegisteredDeviceInfoAsync を使用してログインしているユーザーの Windows Hello コンパニオン デバイスを列挙する</span><span class="sxs-lookup"><span data-stu-id="63f36-269">Enumerate the Windows Hello companion device for logged in user via FindAllRegisteredDeviceInfoAsync</span></span>
    * <span data-ttu-id="63f36-270">UnregisterDeviceAsync を使用してデバイスの登録を解除する</span><span class="sxs-lookup"><span data-stu-id="63f36-270">Un-register it using UnregisterDeviceAsync</span></span>

### <a name="registration-and-de-registration"></a><span data-ttu-id="63f36-271">登録と登録解除</span><span class="sxs-lookup"><span data-stu-id="63f36-271">Registration and de-registration</span></span>

<span data-ttu-id="63f36-272">登録には、Companion Authentication Service への 2 つの API 呼び出し (RequestStartRegisteringDeviceAsync と FinishRegisteringDeviceAsync) が必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-272">Registration requires two API calls to the Companion Authentication Service: RequestStartRegisteringDeviceAsync and FinishRegisteringDeviceAsync.</span></span>

<span data-ttu-id="63f36-273">これらの呼び出しを行う前に、Windows Hello コンパニオン デバイス アプリは、Windows Hello コンパニオン デバイスが使用可能であることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-273">Before any of these calls are made, the Windows Hello companion device app must make sure that the Windows Hello companion device is available.</span></span> <span data-ttu-id="63f36-274">Windows Hello コンパニオン デバイスが HMAC キー (認証キーとデバイス キー) の生成を担当する場合、Windows Hello コンパニオン デバイス アプリは、上記の 2 つの呼び出しを行う前に、それを生成するようコンパニオン デバイスに依頼する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-274">If the Windows Hello companion device is responsible for generating HMAC keys (authentication and device keys), then the Windows Hello companion device app should also ask the companion device to generate them before making any of the above two calls.</span></span> <span data-ttu-id="63f36-275">Windows Hello コンパニオン デバイス アプリが HMAC キーの生成を担当する場合は、上記の 2 つの呼び出しを行う前にそれを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-275">If the Windows Hello companion device app is responsible for generating HMAC keys, then it should do so before calling the above two calls.</span></span>

<span data-ttu-id="63f36-276">さらに、Windows Hello コンパニオン デバイス アプリは、最初の API 呼び出し (RequestStartRegisteringDeviceAsync) の一部としてデバイスの機能を決定し、それを API 呼び出しの一部として渡すための準備を行う必要があります (Windows Hello コンパニオン デバイスが HMAC キーのセキュア ストレージをサポートしているかどうかなどを渡します)。</span><span class="sxs-lookup"><span data-stu-id="63f36-276">Additionally, as part of first API call (RequestStartRegisteringDeviceAsync), the Windows Hello companion device app must decide on device capability and be prepared to pass it as part of the API call; for example, whether the Windows Hello companion device supports secure storage for HMAC keys.</span></span> <span data-ttu-id="63f36-277">同じ Windows Hello コンパニオン デバイス アプリを使用して、同じコンパニオン デバイスの複数のバージョンとその機能変更を管理する場合 (また、デバイス クエリで管理の対象を決定する必要がある場合)、最初の API 呼び出しを行う前に、そのクエリを実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="63f36-277">If the same Windows Hello companion device app is used to manage multiple versions of the same companion device and those capabilities change (and requires a device query to decide), we recommend this queries occurs before first API call is made.</span></span>   

<span data-ttu-id="63f36-278">最初の API (RequestStartRegisteringDeviceAsync) は、2 番目の API (FinishRegisteringDeviceAsync) で使用されるハンドルを返します。</span><span class="sxs-lookup"><span data-stu-id="63f36-278">The first API (RequestStartRegisteringDeviceAsync) will return a handle used by the second API (FinishRegisteringDeviceAsync).</span></span> <span data-ttu-id="63f36-279">登録のための最初の呼び出しは、PIN プロンプトを起動して、ユーザーが存在していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="63f36-279">The first call for registration will launch the PIN prompt to make sure user is present.</span></span> <span data-ttu-id="63f36-280">PIN が設定されていない場合、この呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="63f36-280">If no PIN is set up, this call will fail.</span></span> <span data-ttu-id="63f36-281">Windows Hello コンパニオン デバイス アプリは、KeyCredentialManager.IsSupportedAsync 呼び出しにより、PIN が設定されているかどうかのクエリを実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="63f36-281">The Windows Hello companion device app can query whether PIN is set up or not via KeyCredentialManager.IsSupportedAsync call as well.</span></span> <span data-ttu-id="63f36-282">ポリシーによって Windows Hello コンパニオン デバイスの使用が無効になっている場合も、RequestStartRegisteringDeviceAsync 呼び出しが失敗することがあります。</span><span class="sxs-lookup"><span data-stu-id="63f36-282">RequestStartRegisteringDeviceAsync call can also fail if policy has disabled the usage of the Windows Hello companion device.</span></span>

<span data-ttu-id="63f36-283">最初の呼び出しの結果は、SecondaryAuthenticationFactorRegistrationStatus 列挙型で返されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-283">The result of first call is returned via SecondaryAuthenticationFactorRegistrationStatus enum:</span></span>

```C#
{
    Failed = 0,         // Something went wrong in the underlying components
    Started,            // First call succeeded
    CanceledByUser,     // User cancelled PIN prompt
    PinSetupRequired,   // PIN is not set up
    DisabledByPolicy,   // Companion device framework or this app is disabled
}
```

<span data-ttu-id="63f36-284">2 番目の呼び出し (FinishRegisteringDeviceAsync) によって登録が終了します。</span><span class="sxs-lookup"><span data-stu-id="63f36-284">The second call (FinishRegisteringDeviceAsync) finishes the registration.</span></span> <span data-ttu-id="63f36-285">登録プロセスの一部として、Windows Hello コンパニオン デバイス アプリは、Companion Authentication Service を使用してコンパニオン デバイスの構成データを保存できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-285">As part of registration process, the Windows Hello companion device app can store companion device configuration data with Companion Authentication Service.</span></span> <span data-ttu-id="63f36-286">このデータには 4 K というサイズ制限があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-286">There is a 4K size limit for this data.</span></span> <span data-ttu-id="63f36-287">このデータは、Windows Hello コンパニオン デバイス アプリが認証時に使用できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-287">This data will be available to the Windows Hello companion device app at authentication time.</span></span> <span data-ttu-id="63f36-288">このデータは、たとえば、Windows Hello コンパニオン デバイスに接続するときに MAC アドレスのように使用できます。また、Windows Hello コンパニオン デバイスにストレージがないときに、PC をストレージ用として使用することをコンパニオン デバイスが望んだ場合、構成データを使用できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-288">This data can be used, as an example, to connect to the Windows Hello companion device like a MAC address, or if the Windows Hello companion device does not have storage and companion device wants to use PC for storage, then configuration data can be used.</span></span> <span data-ttu-id="63f36-289">データの一部として保存される機密性の高いデータは、Windows Hello コンパニオン デバイスだけが知っているキーを使用して暗号化する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="63f36-289">Note that any sensitive data stored as part of configuration data must be encrypted with a key that only the Windows Hello companion device knows.</span></span> <span data-ttu-id="63f36-290">また、構成データが Windows サービスによって保存されるのであれば、Windows Hello コンパニオン デバイス アプリは、ユーザー プロファイルを通してそれを使用できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-290">Also, given that configuration data is stored by a Windows service, it is available to the Windows Hello companion device app across user profiles.</span></span>

<span data-ttu-id="63f36-291">Windows Hello コンパニオン デバイス アプリは、AbortRegisteringDeviceAsync を呼び出して登録をキャンセルし、エラー コードを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="63f36-291">The Windows Hello companion device app can call AbortRegisteringDeviceAsync to cancel the registration and pass in an error code.</span></span> <span data-ttu-id="63f36-292">Companion Authentication Service は、エラーを利用統計情報で記録します。</span><span class="sxs-lookup"><span data-stu-id="63f36-292">The Companion Authentication Service will log the error in the telemetry data.</span></span> <span data-ttu-id="63f36-293">この呼び出しが適切な例として、Windows Hello コンパニオン デバイスで問題が発生し、登録を終了できなかった場合があります (HMAC キーが保存できなかった、BT 接続が失われた場合など)。</span><span class="sxs-lookup"><span data-stu-id="63f36-293">A good example for this call would be when something went wrong with the Windows Hello companion device and it could not finish registration (e.g., it cannot store HMAC keys or BT connection was lost).</span></span>

<span data-ttu-id="63f36-294">Windows Hello コンパニオン デバイス アプリには、ユーザーが (Windows Hello コンパニオン デバイスを紛失した場合や、新しいバージョンを購入した場合などに) Windows 10 デスクトップから Windows Hello コンパニオン デバイスの登録を解除するためのオプションが必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-294">The Windows Hello companion device app must provide an option for the user to de-register their Windows Hello companion device from their Windows 10 desktop (e.g., if they lost their companion device or bought a newer version).</span></span> <span data-ttu-id="63f36-295">ユーザーがそのオプションを選択したとき、Windows Hello コンパニオン デバイス アプリは、UnregisterDeviceAsync を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-295">When the user selects that option, then the Windows Hello companion device app must call UnregisterDeviceAsync.</span></span> <span data-ttu-id="63f36-296">Windows Hello コンパニオン デバイス アプリからのこの呼び出しによって、コンパニオン デバイス認証サービスは、呼び出し元アプリの特定のデバイス ID とアプリ ID に対応するすべてのデータ (HMAC キーを含む) を PC 側から削除します。</span><span class="sxs-lookup"><span data-stu-id="63f36-296">This call by the Windows Hello companion device app will trigger the companion device authentication service to delete all data (including HMAC keys) corresponding to the specific device Id and AppId of the caller app from PC side.</span></span> <span data-ttu-id="63f36-297">この API 呼び出しは、Windows Hello コンパニオン デバイス アプリまたはコンパニオン デバイス側からは HMAC キーを削除しません。</span><span class="sxs-lookup"><span data-stu-id="63f36-297">This API call does not attempt to delete HMAC keys from either the Windows Hello companion device app or companion device side.</span></span> <span data-ttu-id="63f36-298">その実装は、Windows Hello コンパニオン デバイス アプリに任されています。</span><span class="sxs-lookup"><span data-stu-id="63f36-298">That is left for the Windows Hello companion device app to implement.</span></span>

<span data-ttu-id="63f36-299">登録フェーズと登録解除フェーズ中に発生したエラー メッセージの表示は、Windows Hello コンパニオン デバイス アプリが担当します。</span><span class="sxs-lookup"><span data-stu-id="63f36-299">The Windows Hello companion device app is responsible for showing any error messages that happen in registration and de-registration phase.</span></span>

```C#
using System;
using Windows.Security.Authentication.Identity.Provider;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.UI.Popups;

namespace SecondaryAuthFactorSample
{
    public class DeviceRegistration
    {

        public void async OnRegisterButtonClick()
        {
            //
            // Pseudo function, the deviceId should be retrieved by the application from the device
            //
            string deviceId = await ReadSerialNumberFromDevice();

            IBuffer deviceKey = CryptographicBuffer.GenerateRandom(256/8);
            IBuffer mutualAuthenticationKey = CryptographicBuffer.GenerateRandom(256/8);

            SecondaryAuthenticationFactorRegistration registrationResult =
                await SecondaryAuthenticationFactorRegistration.RequestStartRegisteringDeviceAsync(
                    deviceId,  // deviceId: max 40 wide characters. For example, serial number of the device
                    SecondaryAuthenticationFactorDeviceCapabilities.SecureStorage |
                        SecondaryAuthenticationFactorDeviceCapabilities.HMacSha256 |
                        SecondaryAuthenticationFactorDeviceCapabilities.StoreKeys,
                    "My test device 1", // deviceFriendlyName: max 64 wide characters. For example: John's card
                    "SAMPLE-001", // deviceModelNumber: max 32 wide characters. The app should read the model number from device.
                    deviceKey,
                    mutualAuthenticationKey);

            switch(registerResult.Status)
            {
            case SecondaryAuthenticationFactorRegistrationStatus.Started:
                //
                // Pseudo function:
                // The app needs to retrieve the value from device and set into opaqueBlob
                //
                IBuffer deviceConfigData = ReadConfigurationDataFromDevice();

                if (deviceConfigData != null)
                {
                    await registrationResult.Registration.FinishRegisteringDeviceAsync(deviceConfigData); //config data limited to 4096 bytes
                    MessageDialog dialog = new MessageDialog("The device is registered correctly.");
                    await dialog.ShowAsync();
                }
                else
                {
                    await registrationResult.Registration.AbortRegisteringDeviceAsync("Failed to connect to the device");
                    MessageDialog dialog = new MessageDialog("Failed to connect to the device.");
                    await dialog.ShowAsync();
                }
                break;

            case SecondaryAuthenticationFactorRegistrationStatus.CanceledByUser:
                MessageDialog dialog = new MessageDialog("You didn't enter your PIN.");
                await dialog.ShowAsync();
                break;

            case SecondaryAuthenticationFactorRegistrationStatus.PinSetupRequired:
                MessageDialog dialog = new MessageDialog("Please setup PIN in settings.");
                await dialog.ShowAsync();
                break;

            case SecondaryAuthenticationFactorRegistrationStatus.DisabledByPolicy:
                MessageDialog dialog = new MessageDialog("Your enterprise prevents using this device to sign in.");
                await dialog.ShowAsync();
                break;
            }
        }

        public void async UpdateDeviceList()
        {
            IReadOnlyList<SecondaryAuthenticationFactorInfo> deviceInfoList =
                await SecondaryAuthenticationFactorRegistration.FindAllRegisteredDeviceInfoAsync(
                    SecondaryAuthenticationFactorDeviceFindScope.User);

            if (deviceInfoList.Count > 0)
            {
                foreach (SecondaryAuthenticationFactorInfo deviceInfo in deviceInfoList)
                {
                    //
                    // Add deviceInfo.FriendlyName and deviceInfo.DeviceId into a combo box
                    //
                }
            }
        }

        public void async OnUnregisterButtonClick()
        {
            string deviceId;
            //
            // Read the deviceId from the selected item in the combo box
            //
            await SecondaryAuthenticationFactorRegistration.UnregisterDeviceAsync(deviceId);
        }
    }
}
```

### <a name="authentication"></a><span data-ttu-id="63f36-300">認証</span><span class="sxs-lookup"><span data-stu-id="63f36-300">Authentication</span></span>

<span data-ttu-id="63f36-301">認証には、Companion Authentication Service への 2 つの API 呼び出し (StartAuthenticationAsync と FinishAuthencationAsync) が必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-301">Authentication requires two API calls to the Companion Authentication Service: StartAuthenticationAsync and FinishAuthencationAsync.</span></span>

<span data-ttu-id="63f36-302">最初の開始 API は、2 番目の API で使用されるハンドルを返します。</span><span class="sxs-lookup"><span data-stu-id="63f36-302">The first initiation API will return a handle used by the second API.</span></span>  <span data-ttu-id="63f36-303">最初の呼び出しは、特に nonce を返します。他のデータと連結されるこの nonce は、Windows Hello コンパニオン デバイスに保存されるデバイス キーを HMAC 処理するために必要です。</span><span class="sxs-lookup"><span data-stu-id="63f36-303">The first call returns, among other things, a nonce that – once concatenated with other things - needs to be HMAC'ed with the device key stored on the Windows Hello companion device.</span></span> <span data-ttu-id="63f36-304">2 番目の呼び出しは、デバイス キーの HMAC の結果を返し、認証の成功で終了できます (つまり、ユーザーにデスクトップが表示されます)。</span><span class="sxs-lookup"><span data-stu-id="63f36-304">The second call returns the results of HMAC with device key and can potentially end in successful authentication (i.e., the user will see their desktop).</span></span>

<span data-ttu-id="63f36-305">最初の開始 API (StartAuthenticationAsync) は、初回登録後、ポリシーによってその Windows Hello コンパニオン デバイスが無効になっている場合は失敗します。</span><span class="sxs-lookup"><span data-stu-id="63f36-305">The first initiation API (StartAuthenticationAsync) can fail if policy has disabled that Windows Hello companion device after initial registration.</span></span> <span data-ttu-id="63f36-306">API 呼び出しは、WaitingForUserConfirmation 状態または CollectingCredential 状態以外のときに行われた場合も失敗します (詳しくは、このセクションで後述します)。</span><span class="sxs-lookup"><span data-stu-id="63f36-306">It can also fail if the API call was made outside WaitingForUserConfirmation or CollectingCredential states (more on this later in this section).</span></span> <span data-ttu-id="63f36-307">さらに、未登録のコンパニオン デバイス アプリがそれを呼び出した場合も失敗します。</span><span class="sxs-lookup"><span data-stu-id="63f36-307">It can also fail if an unregistered companion device app calls it.</span></span> <span data-ttu-id="63f36-308">SecondaryAuthenticationFactorAuthenticationStatus 列挙型は、可能な結果を要約します。</span><span class="sxs-lookup"><span data-stu-id="63f36-308">SecondaryAuthenticationFactorAuthenticationStatus Enum summarizes the possible outcomes:</span></span>

```C#
{
    Failed = 0,                     // Something went wrong in the underlying components
    Started,
    UnknownDevice,                  // Companion device app is not registered with framework
    DisabledByPolicy,               // Policy disabled this device after registration
    InvalidAuthenticationStage,     // Companion device framework is not currently accepting
                                    // incoming authentication requests
}
```

<span data-ttu-id="63f36-309">2 番目の API 呼び出し (FinishAuthencationAsync) は、最初の呼び出しで提供された nonce の有効期限 (20 秒) が終了した場合は失敗します。</span><span class="sxs-lookup"><span data-stu-id="63f36-309">The second API call (FinishAuthencationAsync) can fail if the nonce that was provided in the first call is expired (20 seconds).</span></span> <span data-ttu-id="63f36-310">SecondaryAuthenticationFactorFinishAuthenticationStatus 列挙型では、可能な結果をキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="63f36-310">SecondaryAuthenticationFactorFinishAuthenticationStatus enum captures possible outcomes.</span></span>

```C#
{
    Failed = 0,     // Something went wrong in the underlying components
    Completed,      // Success
    NonceExpired,   // Nonce is expired
}
```

<span data-ttu-id="63f36-311">2 つの API 呼び出し (StartAuthenticationAsync と FinishAuthencationAsync) のタイミングは、Windows Hello コンパニオン デバイスがインテント シグナル、ユーザー プレゼンス シグナル、および曖昧性解消シグナル (詳しくは、「ユーザー シグナル」を参照) を収集する方法と合わせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-311">The timing of two API calls (StartAuthenticationAsync and FinishAuthencationAsync) needs to align with how the Windows Hello companion device collects intent, user presence, and disambiguation signals (see User Signals for more details).</span></span> <span data-ttu-id="63f36-312">たとえば、2 番目の呼び出しは、インテント シグナルを入手した後で送信します。</span><span class="sxs-lookup"><span data-stu-id="63f36-312">For example, the second call must not be submitted until intent signal is available.</span></span> <span data-ttu-id="63f36-313">つまり、ユーザーがロック解除の意図を示していない場合、PC のロックは解除すべきではありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-313">In other words, the PC should not unlock if the user has not expressed intent for it.</span></span> <span data-ttu-id="63f36-314">具体的に言えば、Bluetooth の近接性を使用して PC のロックを解除する場合は、明確なインテント シグナルを収集する必要があります。そうしないと、ユーザーがキッチンに行く途中で PC の近くを通ったときに PC のロックが解除されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-314">To make this more clear, assume that Bluetooth proximity is used for PC unlock, then an explicit intent signal must be collected, otherwise, as soon as user walks by his PC on the way to kitchen, the PC will unlock.</span></span> <span data-ttu-id="63f36-315">また、最初の呼び出しから返される nonce には時間制限 (20 秒) があり、一定期間後に有効期限が切れます。</span><span class="sxs-lookup"><span data-stu-id="63f36-315">Also, the nonce returned from the first call is time bound (20 seconds) and will expire after certain period.</span></span> <span data-ttu-id="63f36-316">このため、最初の呼び出しは、Windows Hello コンパニオン デバイスが確実に存在することをコンパニオン デバイス アプリが認識した (たとえば、コンパニオン デバイスが USB ポートに挿入されたり、NFC リーダーにタップされた) ときにのみ実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-316">As a result, the first call only should be made when the Windows Hello companion device app has good indication of companion device presence, e.g., the companion device is inserted into USB port, or tapped on NFC reader.</span></span> <span data-ttu-id="63f36-317">Bluetooth の場合は、PC 側のバッテリーや、Windows Hello コンパニオン デバイスの存在を確認している時点で進行中の他の Bluetooth アクティビティへの影響を回避することを考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-317">With Bluetooth, care must be taken to avoid affecting battery on PC side or affecting other Bluetooth activities going on at that point when checking for Windows Hello companion device presence.</span></span> <span data-ttu-id="63f36-318">さらに、(たとえば PIN の入力による) ユーザー プレゼンス シグナルを提供する必要がある場合は、最初の認証呼び出しは、そのシグナルが収集された後でのみ実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="63f36-318">Also, if a user presence signal needs to be provided (e.g., by typing in PIN), it is recommended that the first authentication call is only made after that signal is collected.</span></span>

<span data-ttu-id="63f36-319">Windows Hello コンパニオン デバイス フレームワークは、ユーザーが認証フローのどこにいるかの全体像を提供することによって、Windows Hello コンパニオン デバイス アプリが十分な情報に基づいて上記 2 つの呼び出しをいつ実行するかを決定できるようにしています。</span><span class="sxs-lookup"><span data-stu-id="63f36-319">The Windows Hello companion device framework helps the Windows Hello companion device app to make informed decision on when to make above two calls by providing a complete picture of where user is in authentication flow.</span></span> <span data-ttu-id="63f36-320">Windows Hello コンパニオン デバイス フレームワークは、ロック状態変化通知をアプリのバックグラウンド タスクに提供することで、この機能を実現しています。</span><span class="sxs-lookup"><span data-stu-id="63f36-320">Windows Hello companion device framework provides this functionality by providing lock state change notification to app background task.</span></span>

![コンパニオン デバイス フロー](images/companion-device-4.png)

<span data-ttu-id="63f36-322">これらの状態の詳細を次に示します。</span><span class="sxs-lookup"><span data-stu-id="63f36-322">Details of each of these states are as follows:</span></span>

| <span data-ttu-id="63f36-323">状態</span><span class="sxs-lookup"><span data-stu-id="63f36-323">State</span></span>                         | <span data-ttu-id="63f36-324">説明</span><span class="sxs-lookup"><span data-stu-id="63f36-324">Description</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|----------------------------   |-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    |
| <span data-ttu-id="63f36-325">WaitingForUserConfirmation</span><span class="sxs-lookup"><span data-stu-id="63f36-325">WaitingForUserConfirmation</span></span>    | <span data-ttu-id="63f36-326">この状態変化通知イベントは、ロック画面から移動した場合に発生します (例: ユーザーが Windows + L キーを押下)。</span><span class="sxs-lookup"><span data-stu-id="63f36-326">This state change notification event is fired when the lock screen comes down (e.g., user pressed Windows + L).</span></span> <span data-ttu-id="63f36-327">この状態のときは、デバイスが見つからないことに関連するすべてのエラー メッセージを要求しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="63f36-327">We recommend not to request any error messages relating to having difficulty finding a device in this state.</span></span> <span data-ttu-id="63f36-328">一般に、メッセージの表示は、インテント シグナルが入手されるときにのみ実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="63f36-328">In general, we recommend to only show messages when intent signal is available.</span></span> <span data-ttu-id="63f36-329">コンパニオン デバイスがインテント シグナル (NFC リーダーのタップ、コンパニオン デバイスのボタンの押下、拍手などの特定のジェスチャなど) を収集する場合、Windows Hello コンパニオン デバイス アプリは、認証するための最初の API 呼び出しを、この状態のときに実行する必要があり、Windows Hello コンパニオン デバイス アプリのバックグラウンド タスクは、インテント シグナルが検出されたことをコンパニオン デバイスから受信します。</span><span class="sxs-lookup"><span data-stu-id="63f36-329">The Windows Hello companion device app should make the first API call for authentication in this state if the companion device collects the intent signal (e.g., tapping on NFC reader, press of a button on the companion device or a specific gesture, like clapping), and the Windows Hello companion device app background task receives indication from the companion device that intent signal was detected.</span></span> <span data-ttu-id="63f36-330">Windows Hello コンパニオン デバイス アプリが PC に依存して認証フローを開始する場合 (ユーザーによるロック画面のスワイプや Space キーの押下)、その Windows Hello コンパニオン デバイス アプリは、次の状態 (CollectingCredential) になるまで待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-330">Otherwise, if the Windows Hello companion device app relies on the PC to start authentication flow (by having user swipe up the unlock screen or hitting space bar), then the Windows Hello companion device app needs to wait for the next state (CollectingCredential).</span></span>     |
| <span data-ttu-id="63f36-331">CollectingCredential</span><span class="sxs-lookup"><span data-stu-id="63f36-331">CollectingCredential</span></span>          | <span data-ttu-id="63f36-332">この状態変化通知イベントは、ユーザーがノート PC のカバーを開いた、キーボードのいずれかのキーを押した、またはスワイプしてロック解除画面に移ったときに発生します。</span><span class="sxs-lookup"><span data-stu-id="63f36-332">This state change notification event is fired when the user either opens their laptop lid, hits any key on their keyboard, or swipes up to the unlock screen.</span></span> <span data-ttu-id="63f36-333">Windows Hello コンパニオン デバイスが上記のアクションに依存してインテント シグナルの収集を開始する場合、Windows Hello コンパニオン デバイス アプリは (ユーザーが PC のロック解除を望んでいるかどうかを確認するコンパニオン デバイス上のポップアップなどで) その収集を開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-333">If the Windows Hello companion device relies on the above actions to start collecting the intent signal, then the Windows Hello companion device app should start collecting it (e.g., via a pop up on the companion device asking whether user wants to unlock the PC).</span></span> <span data-ttu-id="63f36-334">Windows Hello コンパニオン デバイス アプリがコンパニオン デバイスにユーザー プレゼンス シグナルを提供すること (Windows Hello コンパニオン デバイスで PIN を入力するなど) をユーザーに要求する場合は、ここでエラー事例を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="63f36-334">This would be a good time to provide error cases if the Windows Hello companion device app needs the user to provide a user presence signal on the companion device (like typing in PIN on the Windows Hello companion device).</span></span>                                                                                                                                                                                                                                                                                                                                            |
| <span data-ttu-id="63f36-335">SuspendingAuthentication</span><span class="sxs-lookup"><span data-stu-id="63f36-335">SuspendingAuthentication</span></span>      | <span data-ttu-id="63f36-336">Windows Hello コンパニオン デバイス アプリがこの状態を受信した場合は、Companion Authentication Service が認証要求の受け入れを停止したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="63f36-336">When the Windows Hello companion device app receives this state, it means that the Companion Authentication Service has stopped accepting authentication requests.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| <span data-ttu-id="63f36-337">CredentialCollected</span><span class="sxs-lookup"><span data-stu-id="63f36-337">CredentialCollected</span></span>           | <span data-ttu-id="63f36-338">これは、別の Windows Hello コンパニオン デバイス アプリから 2 番目の API の呼び出しがあり、何が送信されたかを Companion Authentication Service が検証していることを意味します。</span><span class="sxs-lookup"><span data-stu-id="63f36-338">This means that another Windows Hello companion device app has called the second API and that the Companion Authentication Service is verifying what was submitted.</span></span> <span data-ttu-id="63f36-339">この時点で、Companion Authentication Service は、現在送信されたものが検証に合格しない限り、他の認証要求を受け入れません。</span><span class="sxs-lookup"><span data-stu-id="63f36-339">At this point, the Companion Authentication Service is not accepting any other authentication requests unless the currently submitted one does not pass verification.</span></span> <span data-ttu-id="63f36-340">Windows Hello コンパニオン デバイス アプリは、次の状態になるまで現在の状態を維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-340">The Windows Hello companion device app should stay tuned until next state is reached.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| <span data-ttu-id="63f36-341">CredentialAuthenticated</span><span class="sxs-lookup"><span data-stu-id="63f36-341">CredentialAuthenticated</span></span>       | <span data-ttu-id="63f36-342">これは、送信された資格情報が機能したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="63f36-342">This means that the submitted credential worked.</span></span> <span data-ttu-id="63f36-343">credentialAuthenticated には、成功した Windows Hello コンパニオン デバイスのデバイス ID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="63f36-343">The credentialAuthenticated has the device ID of the Windows Hello companion device that succeeded.</span></span> <span data-ttu-id="63f36-344">Windows Hello コンパニオン デバイス アプリは、それに関連付けられているデバイスが勝者であるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-344">The Windows Hello companion device app should make sure to check on that to see if its associated device was the winner.</span></span> <span data-ttu-id="63f36-345">そうでない場合、Windows Hello コンパニオン デバイス アプリは、認証後フローの表示 (コンパニオン デバイス上の成功メッセージなど。デバイスのバイブレーションも考えられます) を回避する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-345">If not, then the Windows Hello companion device app should avoid showing any post authentication flows (like success message on the companion device or perhaps a vibration on that device).</span></span> <span data-ttu-id="63f36-346">送信された資格情報が機能しなかった場合、状態は CollectingCredential に変化します。</span><span class="sxs-lookup"><span data-stu-id="63f36-346">Note that if the submitted credential did not work, the state will change to CollectingCredential state.</span></span>                                                                                                                                                                                                                                                                                                                                                                                       |
| <span data-ttu-id="63f36-347">StoppingAuthentication</span><span class="sxs-lookup"><span data-stu-id="63f36-347">StoppingAuthentication</span></span>        | <span data-ttu-id="63f36-348">認証が成功し、ユーザーにデスクトップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-348">Authentication succeeded and user saw the desktop.</span></span> <span data-ttu-id="63f36-349">この時点で、バックグラウンド タスクを終了します。</span><span class="sxs-lookup"><span data-stu-id="63f36-349">Time to kill your background task.</span></span> <span data-ttu-id="63f36-350">バックグラウンド タスクを終了する前に、明示的に StageEvent ハンドラーの登録を解除します。</span><span class="sxs-lookup"><span data-stu-id="63f36-350">Before exiting the backround task, explicitly unregister the StageEvent handler.</span></span> <span data-ttu-id="63f36-351">これは、バックグラウンド タスクをすばやく終了する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="63f36-351">This will help the background task exit quickly.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |



<span data-ttu-id="63f36-352">Windows Hello コンパニオン デバイス アプリは、最初の 2 つの状態のときにのみ、2 つの認証 API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-352">Windows Hello companion device apps should only call the two authentication APIs in the first two states.</span></span> <span data-ttu-id="63f36-353">Windows Hello コンパニオン デバイス アプリがチェックする必要があるのは、このイベントがどのシナリオで発生しているかです。</span><span class="sxs-lookup"><span data-stu-id="63f36-353">Windows Hello companion device apps should check for what scenario this event is being fired.</span></span> <span data-ttu-id="63f36-354">ロック解除とロック解除後という 2 つの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-354">There are two possibilities: unlock or post unlock.</span></span> <span data-ttu-id="63f36-355">現時点では、ロック解除のみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="63f36-355">Currently, only unlock is supported.</span></span> <span data-ttu-id="63f36-356">今後のリリース後で、ロック解除後のシナリオがサポートされる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-356">In upcoming releases, post unlock scenarios may be supported.</span></span> <span data-ttu-id="63f36-357">SecondaryAuthenticationFactorAuthenticationScenario 列挙型は、これら 2 つのオプションをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="63f36-357">The SecondaryAuthenticationFactorAuthenticationScenario enum captures these two options:</span></span>

```C#
{
    SignIn = 0,         // Running under lock screen mode
    CredentialPrompt,   // Running post unlock
}
```

<span data-ttu-id="63f36-358">完全なコード例:</span><span class="sxs-lookup"><span data-stu-id="63f36-358">Complete code sample:</span></span>

```C#
using System;
using Windows.Security.Authentication.Identity.Provider;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using System.Threading;
using Windows.ApplicationModel.Background;

namespace SecondaryAuthFactorSample
{
    public sealed class AuthenticationTask : IBackgroundTask
    {
        private string _deviceId;
        private static AutoResetEvent _exitTaskEvent = new AutoResetEvent(false);
        private static IBackgroundTaskInstance _taskInstance;
        private BackgroundTaskDeferral _deferral;

        private void Authenticate()
        {
            int retryCount = 0;

            while (retryCount < 3)
            {
                //
                // Pseudo code, the svcAuthNonce should be passed to device or generated from device
                //
                IBuffer svcAuthNonce = CryptographicBuffer.GenerateRandom(256/8);

                SecondaryAuthenticationFactorAuthenticationResult authResult = await
                    SecondaryAuthenticationFactorAuthentication.StartAuthenticationAsync(
                        _deviceId,
                        svcAuthNonce);
                if (authResult.Status != SecondaryAuthenticationFactorAuthenticationStatus.Started)
                {
                    SecondaryAuthenticationFactorAuthenticationMessage message;
                    switch (authResult.Status)
                    {
                        case SecondaryAuthenticationFactorAuthenticationStatus.DisabledByPolicy:
                            message = SecondaryAuthenticationFactorAuthenticationMessage.DisabledByPolicy;
                            break;
                        case SecondaryAuthenticationFactorAuthenticationStatus.InvalidAuthenticationStage:
                            // The task might need to wait for a SecondaryAuthenticationFactorAuthenticationStageChangedEvent
                            break;
                        default:
                            return;
                    }

                    // Show error message. Limited to 512 characters wide
                    await SecondaryAuthenticationFactorAuthentication.ShowNotificationMessageAsync(null, message);
                    return;
                }

                //
                // Pseudo function:
                // The device calculates and returns sessionHmac and deviceHmac
                //
                await GetHmacsFromDevice(
                    authResult.Authentication.ServiceAuthenticationHmac,
                    authResult.Authentication.DeviceNonce,
                    authResult.Authentication.SessionNonce,
                    out deviceHmac,
                    out sessionHmac);
                if (sessionHmac == null ||
                    deviceHmac == null)
                {
                    await authResult.Authentication.AbortAuthenticationAsync(
                        "Failed to read data from device");
                    return;
                }

                SecondaryAuthenticationFactorFinishAuthenticationStatus status =
                    await authResult.Authentication.FinishAuthencationAsync(deviceHmac, sessionHmac);
                if (status == SecondaryAuthenticationFactorFinishAuthenticationStatus.NonceExpired)
                {
                    retryCount++;
                    continue;
                }
                else if (status == SecondaryAuthenticationFactorFinishAuthenticationStatus.Completed)
                {
                    // The credential data is collected and ready for unlock
                    return;
                }
            }
        }

        public void OnAuthenticationStageChanged(
            object sender,
            SecondaryAuthenticationFactorAuthenticationStageChangedEventArgs args)
        {
            // The application should check the args.StageInfo.Stage to determine what to do in next. Note that args.StageInfo.Scenario will have the scenario information (SignIn vs CredentialPrompt).

            switch(args.StageInfo.Stage)
            {
            case SecondaryAuthenticationFactorAuthenticationStage.WaitingForUserConfirmation:
                // Show welcome message
                await SecondaryAuthenticationFactorAuthentication.ShowNotificationMessageAsync(
                    null,
                    SecondaryAuthenticationFactorAuthenticationMessage.WelcomeMessageSwipeUp);
                break;

            case SecondaryAuthenticationFactorAuthenticationStage.CollectingCredential:
                // Authenticate device
                Authenticate();
                break;

            case SecondaryAuthenticationFactorAuthenticationStage.CredentialAuthenticated:
                if (args.StageInfo.DeviceId = _deviceId)
                {
                    // Show notification on device about PC unlock
                }
                break;

            case SecondaryAuthenticationFactorAuthenticationStage.StoppingAuthentication:
                // Quit from background task
                _exitTaskEvent.Set();
                break;
            }

            Debug.WriteLine("Authentication Stage = " + args.StageInfo.AuthenticationStage.ToString());
        }

        //
        // The Run method is the entry point of a background task.
        //
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _taskInstance = taskInstance;
            _deferral = taskInstance.GetDeferral();

            // Register canceled event for this task
            taskInstance.Canceled += TaskInstanceCanceled;

            // Find all device registred by this application
            IReadOnlyList<SecondaryAuthenticationFactorInfo> deviceInfoList =
                await SecondaryAuthenticationFactorRegistration.FindAllRegisteredDeviceInfoAsync(
                    SecondaryAuthenticationFactorDeviceFindScope.AllUsers);

            if (deviceInfoList.Count == 0)
            {
                // Quit the task silently
                return;
            }
            _deviceId = deviceInfoList[0].DeviceId;
            Debug.WriteLine("Use first device '" + _deviceId + "' in the list to signin");

            // Register AuthenticationStageChanged event
            SecondaryAuthenticationFactorRegistration.AuthenticationStageChanged += OnAuthenticationStageChanged;

            // Wait the task exit event
            _exitTaskEvent.WaitOne();

            _deferral.Complete();
        }

        void TaskInstanceCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _exitTaskEvent.Set();
        }
    }
}
```

### <a name="register-a-background-task"></a><span data-ttu-id="63f36-359">バックグラウンド タスクの登録</span><span class="sxs-lookup"><span data-stu-id="63f36-359">Register a background task</span></span>

<span data-ttu-id="63f36-360">Windows Hello コンパニオン デバイス アプリは、最初のコンパニオン デバイスを登録するときに、デバイスとコンパニオン デバイス認証サービス間で認証情報を渡すバックグラウンド タスク コンポーネントも同時に登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-360">When the Windows Hello companion device app registers the first companion device, it should also register its background task component which will pass authentication information between device and companion device authentication service.</span></span>

```C#
using System;
using Windows.Security.Authentication.Identity.Provider;
using Windows.Storage.Streams;
using Windows.ApplicationModel.Background;

namespace SecondaryAuthFactorSample
{
    public class BackgroundTaskManager
    {
        // Register background task
        public static async Task<IBackgroundTaskRegistration> GetOrRegisterBackgroundTaskAsync(
            string bgTaskName,
            string taskEntryPoint)
        {
            // Check if there's an existing background task already registered
            var bgTask = (from t in BackgroundTaskRegistration.AllTasks
                          where t.Value.Name.Equals(bgTaskName)
                          select t.Value).SingleOrDefault();
            if (bgTask == null)
            {
                BackgroundAccessStatus status =
                    BackgroundExecutionManager.RequestAccessAsync().AsTask().GetAwaiter().GetResult();

                if (status == BackgroundAccessStatus.Denied)
                {
                    Debug.WriteLine("Background Execution is denied.");
                    return null;
                }

                var taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = bgTaskName;
                taskBuilder.TaskEntryPoint = taskEntryPoint;
                taskBuilder.SetTrigger(new SecondaryAuthenticationFactorAuthenticationTrigger());
                bgTask = taskBuilder.Register();
                // Background task is registered
            }

            bgTask.Completed += BgTask_Completed;
            bgTask.Progress += BgTask_Progress;

            return bgTask;
        }
    }
}
```

### <a name="errors-and-messages"></a><span data-ttu-id="63f36-361">エラーとメッセージ</span><span class="sxs-lookup"><span data-stu-id="63f36-361">Errors and messages</span></span>

<span data-ttu-id="63f36-362">サインインの成功または失敗のユーザーへのフィードバックは、Windows Hello コンパニオン デバイス フレームワークが担当します。</span><span class="sxs-lookup"><span data-stu-id="63f36-362">The Windows Hello companion device framework is responsible for providing feedback to the user about success or failure of signing in.</span></span> <span data-ttu-id="63f36-363">Windows Hello コンパニオン デバイス フレームワークには、Windows Hello コンパニオン デバイス アプリが選択できる (ローカライズされた) テキストとエラー メッセージが多数用意されています。</span><span class="sxs-lookup"><span data-stu-id="63f36-363">The Windows Hello companion device framework will provide a stock of (localized) text and error messages for the Windows Hello companion device app to choose from.</span></span> <span data-ttu-id="63f36-364">これらは、ログオン UI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-364">These will be displayed in the logon UI.</span></span>

![コンパニオン デバイス エラー](images/companion-device-5.png)

<span data-ttu-id="63f36-366">Windows Hello コンパニオン デバイス アプリは、ShowNotificationMessageAsync を使用して、ログオン UI の一部としてユーザーにメッセージを表示できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-366">Windows Hello companion device apps can use ShowNotificationMessageAsync to show messages to user as part of the logon UI.</span></span> <span data-ttu-id="63f36-367">この API は、インテント シグナルを入手できるときに呼び出します。</span><span class="sxs-lookup"><span data-stu-id="63f36-367">Call this API when an intent signal is available.</span></span> <span data-ttu-id="63f36-368">インテント シグナルは常に Windows Hello コンパニオン デバイス側で収集する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="63f36-368">Note that an intent signal must always be collected on the Windows Hello companion device side.</span></span>

<span data-ttu-id="63f36-369">メッセージには、ガイダンスとエラーの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-369">There are two types of messages: guidance and errors.</span></span>

<span data-ttu-id="63f36-370">ガイダンス メッセージは、ロック解除プロセスの開始方法をユーザーに表示することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="63f36-370">Guidance messages are designed to show the user how to start the unlock process.</span></span> <span data-ttu-id="63f36-371">これらのメッセージは、初回のデバイス登録時にユーザーに対して 1 回のみ表示され、その後ロック画面に表示されることはありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-371">These messages are only shown to the user once on the lock screen, upon first device registration, and never shown there again.</span></span> <span data-ttu-id="63f36-372">ロック画面の下には引き続き表示されています。</span><span class="sxs-lookup"><span data-stu-id="63f36-372">These messages will continue to be shown under the lock screen.</span></span>

<span data-ttu-id="63f36-373">エラー メッセージは常に表示されます。また、インテント シグナルが提供された後に表示されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-373">Error messages are always shown and will be shown after an intent signal is provided.</span></span> <span data-ttu-id="63f36-374">ユーザーにメッセージを表示する前にインテント シグナルを収集する必要があるときに、ユーザーがいずれかの Windows Hello コンパニオン デバイスのみを使用して意図を表明するのであれば、複数の Windows Hello コンパニオン デバイスがエラー メッセージを表示するために競争するような状況は発生しません。</span><span class="sxs-lookup"><span data-stu-id="63f36-374">Given that an intent signal must be collected before showing messages to the user, and the user will provide that intent only using one of the Windows Hello companion devices, there must not be a situation where multiple Windows Hello companion devices race for showing error messages.</span></span> <span data-ttu-id="63f36-375">このため、Windows Hello コンパニオン デバイス フレームワークでは、キューの管理は行われません。</span><span class="sxs-lookup"><span data-stu-id="63f36-375">As a result, the Windows Hello companion device framework does not maintain any queue.</span></span> <span data-ttu-id="63f36-376">呼び出し元がエラー メッセージを要求すると、エラー メッセージは 5 秒間表示され、その 5 秒間はエラー メッセージに対するその他のすべての要求は破棄されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-376">When a caller asks for an error message, it will be shown for 5 seconds and all other requests for showing an error message in that 5 seconds are dropped.</span></span> <span data-ttu-id="63f36-377">5 秒経過した後、別の呼び出し元がエラー メッセージを表示する機会が発生します。</span><span class="sxs-lookup"><span data-stu-id="63f36-377">Once 5 seconds has passed, then the opportunity arises for another caller to show an error message.</span></span> <span data-ttu-id="63f36-378">これにより、任意の呼び出し元がエラー チャネルを停滞させることが禁止されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-378">We prohibit any caller from jamming the error channel.</span></span>

<span data-ttu-id="63f36-379">ガイダンス メッセージとエラー メッセージを次に示します。</span><span class="sxs-lookup"><span data-stu-id="63f36-379">Guidance and error messages are as follows.</span></span> <span data-ttu-id="63f36-380">デバイス名は、コンパニオン デバイス アプリによって、ShowNotificationMessageAsync の一部として渡されるパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="63f36-380">Device name is a parameter passed by the companion device app as part of ShowNotificationMessageAsync.</span></span>

**<span data-ttu-id="63f36-381">ガイダンス</span><span class="sxs-lookup"><span data-stu-id="63f36-381">Guidance</span></span>**

- <span data-ttu-id="63f36-382">"Swipe up or press space bar to sign in with *device name*." (デバイス名にサインインするには、上にスワイプするか Space キーを押してください。)</span><span class="sxs-lookup"><span data-stu-id="63f36-382">"Swipe up or press space bar to sign in with *device name*."</span></span>
- <span data-ttu-id="63f36-383">"Setting up your companion device. </span><span class="sxs-lookup"><span data-stu-id="63f36-383">"Setting up your companion device.</span></span> <span data-ttu-id="63f36-384">Please wait or use another sign-in option." (コンパニオン デバイスをセットアップしています。しばらく待機するか、別のサインイン オプションを使用してください。)</span><span class="sxs-lookup"><span data-stu-id="63f36-384">Please wait or use another sign-in option."</span></span>
- <span data-ttu-id="63f36-385">"サインインするには、*デバイス名* を NFC リーダーにタップしてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-385">"Tap *device name* to the NFC reader to sign in."</span></span>
- <span data-ttu-id="63f36-386">"*デバイス名* を探しています..."</span><span class="sxs-lookup"><span data-stu-id="63f36-386">"Looking for *device name* ..."</span></span>
- <span data-ttu-id="63f36-387">"サインインするには、*デバイス名* を USB ポートに差し込んでください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-387">"Plug *device name* into a USB port to sign in."</span></span>

**<span data-ttu-id="63f36-388">エラー</span><span class="sxs-lookup"><span data-stu-id="63f36-388">Errors</span></span>**

- <span data-ttu-id="63f36-389">"*デバイス名* にサインインする方法を確認してください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-389">"See *device name* for sign-in instructions."</span></span>
- <span data-ttu-id="63f36-390">"*デバイス名* を使用してサインインするには、Bluetooth をオンにしてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-390">"Turn on Bluetooth to use *device name* to sign in."</span></span>
- <span data-ttu-id="63f36-391">"*デバイス名* を使用してサインインするには、NFC をオンにしてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-391">"Turn on NFC to use *device name* to sign in."</span></span>
- <span data-ttu-id="63f36-392">"*デバイス名* を使用してサインインするには、Wi-Fi ネットワークに接続してください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-392">"Connect to a Wi-Fi network to use *device name* to sign in."</span></span>
- <span data-ttu-id="63f36-393">"*デバイス名* をもう一度タップしてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-393">"Tap *device name* again."</span></span>
- <span data-ttu-id="63f36-394">"*デバイス名* によるサインインは会社が無効にしています。</span><span class="sxs-lookup"><span data-stu-id="63f36-394">"Your enterprise prevents sign in with *device name*.</span></span> <span data-ttu-id="63f36-395">別のサインイン オプションを使用してください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-395">Use another sign-in option."</span></span>
- <span data-ttu-id="63f36-396">"サインインするには、*デバイス名* をタップしてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-396">"Tap *device name* to sign in."</span></span>
- <span data-ttu-id="63f36-397">"サインインするには、*デバイス名* の上に指を置いてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-397">"Rest your finger on *device name* to sign in."</span></span>
- <span data-ttu-id="63f36-398">"サインインするには、*デバイス名* を指でスワイプしてください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-398">"Swipe your finger on *device name* to sign in."</span></span>
- <span data-ttu-id="63f36-399">"*デバイス名* にサインインできませんでした。</span><span class="sxs-lookup"><span data-stu-id="63f36-399">"Couldn’t sign in with *device name*.</span></span> <span data-ttu-id="63f36-400">別のサインイン オプションを使用してください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-400">Use another sign-in option."</span></span>
- <span data-ttu-id="63f36-401">"Something went wrong. </span><span class="sxs-lookup"><span data-stu-id="63f36-401">"Something went wrong.</span></span> <span data-ttu-id="63f36-402">Use another sign-in option, and then set up *device name* again." (問題が発生しました。別のサインイン オプションを使用し、*デバイス名* をもう一度設定してください。)</span><span class="sxs-lookup"><span data-stu-id="63f36-402">Use another sign-in option, and then set up *device name* again."</span></span>
- <span data-ttu-id="63f36-403">"やり直してください。"</span><span class="sxs-lookup"><span data-stu-id="63f36-403">"Try again."</span></span>
- <span data-ttu-id="63f36-404">"Say your Spoken Passphrase into *device name*." (*デバイス名* に音声パスフレーズを言ってください。)</span><span class="sxs-lookup"><span data-stu-id="63f36-404">"Say your Spoken Passphrase into *device name*."</span></span>
- <span data-ttu-id="63f36-405">"*デバイス名* にサインインする準備ができています。"</span><span class="sxs-lookup"><span data-stu-id="63f36-405">"Ready to sign in with *device name*."</span></span>
- <span data-ttu-id="63f36-406">"最初は別のサインイン オプションを使用してください。その後、*デバイス名*を使用してサインインできます。"</span><span class="sxs-lookup"><span data-stu-id="63f36-406">"Use another sign-in option first, then you can use *device name* to sign in."</span></span>

### <a name="enumerating-registered-devices"></a><span data-ttu-id="63f36-407">登録されているデバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="63f36-407">Enumerating registered devices</span></span>

<span data-ttu-id="63f36-408">Windows Hello コンパニオン デバイス アプリは、登録されているコンパニオン デバイスの一覧を、FindAllRegisteredDeviceInfoAsync 呼び出しで列挙できます。</span><span class="sxs-lookup"><span data-stu-id="63f36-408">The Windows Hello companion device app can enumerate the list of registered companion devices via FindAllRegisteredDeviceInfoAsync call.</span></span> <span data-ttu-id="63f36-409">この API は、SecondaryAuthenticationFactorDeviceFindScope 列挙型で定義される 2 種類のクエリをサポートします。</span><span class="sxs-lookup"><span data-stu-id="63f36-409">This API supports two query types defined via enum SecondaryAuthenticationFactorDeviceFindScope:</span></span>

```C#
{
    User = 0,
    AllUsers,
}
```

<span data-ttu-id="63f36-410">最初のスコープは、ログオン ユーザーのデバイスの一覧を返します。</span><span class="sxs-lookup"><span data-stu-id="63f36-410">The first scope returns the list of devices for the logged on user.</span></span> <span data-ttu-id="63f36-411">2 番目は、その PC 上のすべてのユーザーの一覧を返します。</span><span class="sxs-lookup"><span data-stu-id="63f36-411">The second one returns the list for all users on that PC.</span></span> <span data-ttu-id="63f36-412">最初のスコープは、他のユーザーの Windows Hello コンパニオン デバイスの登録が解除されないように、登録解除時に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-412">The first scope must be used at un-registration time to avoid un-registering another user's Windows Hello companion device.</span></span> <span data-ttu-id="63f36-413">2 番目は、認証時または登録時に使用する必要があります。登録時のこの列挙は、同じ Windows Hello コンパニオン デバイスが 2 回登録されることを防ぎます。</span><span class="sxs-lookup"><span data-stu-id="63f36-413">The second one must be used at authentication or registration time: at registration time, this enumeration can help the app avoid trying to register the same Windows Hello companion device twice.</span></span>

<span data-ttu-id="63f36-414">このチェックは、アプリが実行しなくても、PC により実行されるため、同じ Windows Hello コンパニオン デバイスが 2 回以上登録されることはありません。</span><span class="sxs-lookup"><span data-stu-id="63f36-414">Note that even if the app does not perform this check, the PC does and will reject the same Windows Hello companion device from being registered more than once.</span></span> <span data-ttu-id="63f36-415">認証時の AllUsers スコープの使用は、Windows Hello コンパニオン デバイス アプリがユーザー切り替えフローをサポートするために役立ちます。このフローでは、ユーザー B がログインしているときにユーザー A をログオンします (両方のユーザーが Windows Hello コンパニオン デバイス アプリをインストール済みであり、ユーザー A が自分のコンパニオン デバイスを PC に登録済みであり、PC がロック画面 (またはログオン画面) を表示している必要があります)。</span><span class="sxs-lookup"><span data-stu-id="63f36-415">At authentication time, using the AllUsers scope helps the Windows Hello companion device app support switch user flow: log on user A when user B is logged in (this requires that both users have installed the Windows Hello companion device app and user A has registered their companion devices with the PC and the PC is sitting on lock screen (or logon screen)).</span></span>

## <a name="security-requirements"></a><span data-ttu-id="63f36-416">セキュリティ要件</span><span class="sxs-lookup"><span data-stu-id="63f36-416">Security requirements</span></span>

<span data-ttu-id="63f36-417">Companion Authentication Service は、次のセキュリティ保護を提供します。</span><span class="sxs-lookup"><span data-stu-id="63f36-417">The Companion Authentication Service provides the following security protections.</span></span>

- <span data-ttu-id="63f36-418">中間ユーザーまたはアプリ コンテナーとして実行される Windows 10 デスクトップ デバイス上のマルウェアが、Windows Hello コンパニオン デバイスを使用して、PC 上の (Windows Hello の一部として保存されている) ユーザーの資格情報キーに無許可でアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="63f36-418">Malware on a Windows 10 desktop device running as a medium user or app container cannot use the Windows Hello companion device to access user credential keys (stored as part of Windows Hello) on a PC silently.</span></span>
- <span data-ttu-id="63f36-419">Windows 10 デスクトップ デバイスの悪意のあるユーザーが、その Windows 10 デスクトップ デバイスの別のユーザーに属する Windows Hello コンパニオン デバイスを使用して、(同じ Windows 10 デスクトップ デバイス上の) 別のユーザーの資格情報キーに無許可でアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="63f36-419">A malicious user on a Windows 10 desktop device cannot use the Windows Hello companion device that belongs to another user on that Windows 10 desktop device to get silent access to his user credential keys (on the same Windows 10 desktop device).</span></span>
- <span data-ttu-id="63f36-420">Windows Hello コンパニオン デバイス上のマルウェアが、Windows 10 デスクトップデバイス上のユーザー資格情報キーに無許可でアクセスすることはできません。Windows Hello コンパニオン デバイス フレームワーク専用に開発された機能やコードを利用することもできません。</span><span class="sxs-lookup"><span data-stu-id="63f36-420">Malware on the Windows Hello companion device cannot silently get access to user credential keys on a Windows 10 desktop device, including leveraging functionality or code developed specifically for the Windows Hello companion device framework.</span></span>
- <span data-ttu-id="63f36-421">悪意のあるユーザーが、Windows Hello コンパニオン デバイスと Windows 10 デスクトップ デバイス間のトラフィックをキャプチャし、後で再生リプレイすることで Windows 10 デスクトップ デバイスのロックを解除することはできません。</span><span class="sxs-lookup"><span data-stu-id="63f36-421">A malicious user cannot unlock a Windows 10 desktop device by capturing traffic between the Windows Hello companion device and the Windows 10 desktop device and replaying it later.</span></span> <span data-ttu-id="63f36-422">プロトコルでの nonce、認証キー、および HMAC の使用によって、リプレイ攻撃からの防御が保証されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-422">Usage of nonce, authkey, and HMAC in our protocol guarantees protection against a replay attack.</span></span>
- <span data-ttu-id="63f36-423">ルージュ PC 上のマルウェアまたは悪意のあるユーザーが、Windows Hello コンパニオン デバイスを使用して、正規ユーザーの PC にアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="63f36-423">Malware or a malicious user on a rouge PC cannot use Windows Hello companion device to get access to honest user PC.</span></span> <span data-ttu-id="63f36-424">これは、Companion Authentication Service と Windows Hello コンパニオン デバイスの間のプロトコルで認証キーと HMAC を使用することで、相互認証を通して実現されます。</span><span class="sxs-lookup"><span data-stu-id="63f36-424">This is achieved through mutual authentication between Companion Authentication Service and Windows Hello companion device through usage of authkey and HMAC in our protocol.</span></span>

<span data-ttu-id="63f36-425">上記に列挙したセキュリティ保護を実現するために重要なのは、HMAC キーを不正アクセスから保護するとともに、ユーザー プレゼンスを検証することです。</span><span class="sxs-lookup"><span data-stu-id="63f36-425">The key to achieve the security protections enumerated above is to protect HMAC keys from unauthorized access and also verifying user presence.</span></span> <span data-ttu-id="63f36-426">具体的には、次の要件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="63f36-426">More specifically, it must satisfy these requirements:</span></span>

- <span data-ttu-id="63f36-427">Windows Hello コンパニオン デバイスの複製に対する防御を提供する</span><span class="sxs-lookup"><span data-stu-id="63f36-427">Provide protection against cloning the Windows Hello companion device</span></span>
- <span data-ttu-id="63f36-428">登録時に PC に HMAC キーを送信するときに、傍受に対する防御を提供する</span><span class="sxs-lookup"><span data-stu-id="63f36-428">Provide protection against eavesdropping when sending HMAC keys at registration time to the PC</span></span>
- <span data-ttu-id="63f36-429">ユーザー プレゼンス シグナルを入手できることを確認する</span><span class="sxs-lookup"><span data-stu-id="63f36-429">Make sure that user presence signal is available</span></span>
