---
author: drewbatgit
ms.assetid: DD8FFA8C-DFF0-41E3-8F7A-345C5A248FC2
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。
title: PlayReady DRM
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 773216dc392f7bb234e232f3dd3e7c2190a22de1
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5836684"
---
# <a name="playready-drm"></a><span data-ttu-id="12dd7-104">PlayReady DRM</span><span class="sxs-lookup"><span data-stu-id="12dd7-104">PlayReady DRM</span></span>



<span data-ttu-id="12dd7-105">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-105">This topic describes how to add PlayReady protected media content to your Universal Windows Platform (UWP) app.</span></span>

<span data-ttu-id="12dd7-106">PlayReady DRM を使うと、開発者はコンテンツ プロバイダーが定義したアクセス ルールを適用しながら、ユーザーに PlayReady コンテンツを提供することができる UWP アプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-106">PlayReady DRM enables developers to create UWP apps capable of providing PlayReady content to the user while enforcing the access rules defined by the content provider.</span></span> <span data-ttu-id="12dd7-107">このセクションでは、以前の Windows8.1 バージョンから windows 10 バージョンに加えられた変更をサポートするために、PlayReady UWP アプリを変更する方法と windows 10 用の Microsoft PlayReady DRM に加えられた変更について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-107">This section describes changes made to Microsoft PlayReady DRM for Windows10 and how to modify your PlayReady UWP app to support the changes made from the previous Windows8.1 version to the Windows10 version.</span></span>
 
| <span data-ttu-id="12dd7-108">トピック</span><span class="sxs-lookup"><span data-stu-id="12dd7-108">Topic</span></span>                                                                     | <span data-ttu-id="12dd7-109">説明</span><span class="sxs-lookup"><span data-stu-id="12dd7-109">Description</span></span>                                                                                                                                                                                                                                                                             |
|---------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [<span data-ttu-id="12dd7-110">ハードウェア DRM</span><span class="sxs-lookup"><span data-stu-id="12dd7-110">Hardware DRM</span></span>](hardware-drm.md)                                           | <span data-ttu-id="12dd7-111">このトピックでは、PlayReady ハードウェア ベースのデジタル著作権管理 (DRM) を UWP アプリに追加する方法の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-111">This topic provides an overview of how to add PlayReady hardware-based digital rights management (DRM) to your UWP app.</span></span>                                                                                                                                                                 |
| [<span data-ttu-id="12dd7-112">PlayReady を使ったアダプティブ ストリーミング</span><span class="sxs-lookup"><span data-stu-id="12dd7-112">Adaptive streaming with PlayReady</span></span>](adaptive-streaming-with-playready.md) | <span data-ttu-id="12dd7-113">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-113">This article describes how to add adaptive streaming of multimedia content with Microsoft PlayReady content protection to a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="12dd7-114">現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-114">This feature currently supports playback of Http Live Streaming (HLS) and Dynamic Streaming over HTTP (DASH) content.</span></span> |

## <a name="whats-new-in-playready-drm"></a><span data-ttu-id="12dd7-115">PlayReady DRM の新機能</span><span class="sxs-lookup"><span data-stu-id="12dd7-115">What's new in PlayReady DRM</span></span>

<span data-ttu-id="12dd7-116">次の一覧では、新しい機能と windows 10 用の PlayReady DRM に加えられた変更について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-116">The following list describes the new features and changes made to PlayReady DRM for Windows10.</span></span>

-   <span data-ttu-id="12dd7-117">追加されたハードウェア デジタル著作権管理 (HWDRM)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-117">Added hardware digital rights management (HWDRM).</span></span>

    <span data-ttu-id="12dd7-118">ハードウェア ベースのコンテンツ保護により、複数のデバイス プラットフォーム上で、高解像度 (HD) と超高解像度 (UHD) のコンテンツを安全に再生できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-118">Hardware-based content protection support enables secure playback of high definition (HD) and ultra-high definition (UHD) content on multiple device platforms.</span></span> <span data-ttu-id="12dd7-119">キー マテリアル (秘密キー、コンテンツ キー、これらのキーを派生またはロック解除するために使われるその他のキー マテリアルを含みます)、および暗号化解除された圧縮および非圧縮ビデオ サンプルは、ハードウェア セキュリティを利用して保護されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-119">Key material (including private keys, content keys, and any other key material used to derive or unlock said keys), and decrypted compressed and uncompressed video samples are protected by leveraging hardware security.</span></span> <span data-ttu-id="12dd7-120">ハードウェア DRM の使用中は、HWDRM パイプラインは使用中の出力を常に判別できるため、不明な有効機能 (不明な再生/低解像度の不明な再生) も意味を持ちません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-120">When Hardware DRM is being used, neither unknown enabler (play to unknown / play to unknown with downres) has meaning as the HWDRM pipeline always knows the output being used.</span></span> <span data-ttu-id="12dd7-121">詳しくは、「[ハードウェア DRM](hardware-drm.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-121">For more information, see [Hardware DRM](hardware-drm.md).</span></span>

-   <span data-ttu-id="12dd7-122">PlayReady は AppX フレームワーク コンポーネントではなく、インボックス オペレーティング システム コンポーネントになりました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-122">PlayReady is no longer an appX framework component, but instead is an in-box operating system component.</span></span> <span data-ttu-id="12dd7-123">名前空間は、**Microsoft.Media.PlayReadyClient** から [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454) に変更されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-123">The namespace was changed from **Microsoft.Media.PlayReadyClient** to [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454).</span></span>
-   <span data-ttu-id="12dd7-124">PlayReady のエラー コードを定義する Windows.Media.Protection.PlayReadyErrors.h と Windows.Media.Protection.PlayReadyResults.h ヘッダーは、Windows ソフトウェア開発キット (Windows SDK) の一部になりました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-124">The following headers defining the PlayReady error codes are now part of the Windows Software Development Kit (SDK): Windows.Media.Protection.PlayReadyErrors.h and Windows.Media.Protection.PlayReadyResults.h.</span></span>
-   <span data-ttu-id="12dd7-125">永続的でないライセンスの事前の取得を提供します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-125">Provides proactive acquisition of non-persistent licenses.</span></span>

    <span data-ttu-id="12dd7-126">以前のバージョンの PlayReady DRM は、永続的でないライセンスの事前取得をサポートしませんでした。</span><span class="sxs-lookup"><span data-stu-id="12dd7-126">Previous versions of PlayReady DRM did not support proactive acquisition of non-persistent licenses.</span></span> <span data-ttu-id="12dd7-127">この機能は、このバージョンに追加されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-127">This capability has been added to this version.</span></span> <span data-ttu-id="12dd7-128">これにより、最初のフレームまでの時間を減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-128">This can decrease the time to first frame.</span></span> <span data-ttu-id="12dd7-129">詳しくは、「[再生する前に永続的でないライセンスを事前に取得する](#proactively-acquire-a-non-persistent-license-before-playback)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-129">For more information, see [Proactively Acquire a Non-Persistent License Before Playback](#proactively-acquire-a-non-persistent-license-before-playback).</span></span>

-   <span data-ttu-id="12dd7-130">1 つのメッセージで複数のライセンスを取得できるようにします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-130">Provides acquisition of multiple licenses in one message.</span></span>

    <span data-ttu-id="12dd7-131">クライアント アプリが、1 つのライセンス取得メッセージで複数の永続的でないライセンスを取得できるようにします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-131">Allows the client app to acquire multiple non-persistent licenses in one license acquisition message.</span></span> <span data-ttu-id="12dd7-132">これにより、ユーザーがコンテンツ ライブラリを閲覧中に、複数のコンテンツのライセンスを取得して、最初のフレームまでの時間を短縮することができます。この結果、ユーザーが再生するコンテンツを選択したときに、ライセンス取得の遅延を回避できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-132">This can decrease the time to first frame by acquiring licenses for multiple pieces of content while the user is still browsing your content library; this prevents a delay for license acquisition when the user selects the content to play.</span></span> <span data-ttu-id="12dd7-133">さらに、複数のキー識別子 (KID) を含むコンテンツ ヘッダーを有効にして、オーディオとビデオのストリームを個別のキーに暗号化できます。これにより、カスタム ロジックと複数のライセンス取得要求を使って同じ結果を得る代わりに、単一ライセンスの取得で、コンテンツ ファイル内のすべてのストリームのすべてのライセンスを取得できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-133">In addition, it allows audio and video streams to be encrypted to separate keys by enabling a content header that includes multiple key identifiers (KIDs); this enables a single license acquisition to acquire all licenses for all streams within a content file instead of having to use custom logic and multiple license acquisition requests to achieve the same result.</span></span>

-   <span data-ttu-id="12dd7-134">リアルタイムの有効期限のサポートや期間限定ライセンス (LDL) が追加されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-134">Added real time expiration support, or limited duration license (LDL).</span></span>

    <span data-ttu-id="12dd7-135">ライセンスにリアルタイムの有効期限を設定し、再生中に、有効期限が切れるライセンスから別の (有効な) ライセンスにスムーズに移行することができます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-135">Provides the ability to set real-time expiration on licenses and smoothly transition from an expiring license to another (valid) license in the middle of playback.</span></span> <span data-ttu-id="12dd7-136">1 つのメッセージで複数のライセンスの取得と組み合わせることにより、アプリは、ユーザーがコンテンツ ライブラリを閲覧中に、いくつかの LDL を非同期的に取得することができ、ユーザーが再生するコンテンツを選ぶと、期間の長いライセンスのみを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-136">When combined with acquisition of multiple licenses in one message, this allows an app to acquire several LDLs asynchronously while the user is still browsing the content library and only acquire a longer duration license once the user has selected content to playback.</span></span> <span data-ttu-id="12dd7-137">次に、再生はより迅速に開始し (ライセンスが既に利用できるため)、LDL の有効期限が切れるまでに、アプリはより長い期間のライセンスを取得するため、中断なく、コンテンツの最後までスムーズに再生を続行します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-137">Playback will then start more quickly (because a license is already available) and, since the app will have acquired a longer duration license by the time the LDL expires, smoothly continue playback to the end of the content without interruption.</span></span>

-   <span data-ttu-id="12dd7-138">永続的でないライセンス チェーンを追加しました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-138">Added non-persistent license chains.</span></span>
-   <span data-ttu-id="12dd7-139">永続的でないライセンスで、時間ベースの制限 (有効期限、最初のプレイ後の有効期限切れ、リアルタイムの有効期限を含む) のサポートを追加しました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-139">Added support for time-based restrictions (including expiration, expire after first play, and real time expiration) on non-persistent licenses.</span></span>
-   <span data-ttu-id="12dd7-140">HDCP Type 1 (Windows 10 ではバージョン 2.2) ポリシーのサポートを追加しました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-140">Added HDCP Type 1 (version 2.2 on Windows 10) policy support.</span></span>

    <span data-ttu-id="12dd7-141">詳しくは、「[考慮事項](#things-to-consider)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-141">See [Things to Consider](#things-to-consider) for more information.</span></span>

-   <span data-ttu-id="12dd7-142">Miracast が暗黙的な出力となりました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-142">Miracast is now implicit as an output.</span></span>
-   <span data-ttu-id="12dd7-143">セキュア ストップが追加されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-143">Added secure stop.</span></span>

    <span data-ttu-id="12dd7-144">セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-144">Secure stop provides the means for a PlayReady device to confidently assert to a media streaming service that media playback has stopped for any given piece of content.</span></span> <span data-ttu-id="12dd7-145">この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-145">This capability ensures your media streaming services provide accurate enforcement and reporting of usage limitations on different devices for a given account.</span></span>

-   <span data-ttu-id="12dd7-146">オーディオとビデオに関するライセンスの分離が追加されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-146">Added audio and video license separation.</span></span>

    <span data-ttu-id="12dd7-147">トラックを分離することによって、ビデオがオーディオにデコードされるのを防ぐことができます。これにより、さらに強力なコンテンツ保護が可能になります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-147">Separate tracks prevent video from being decoded as audio; enabling more robust content protection.</span></span> <span data-ttu-id="12dd7-148">最新の標準では、オーディオ トラックと映像トラックに対して別々のキーが必要になります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-148">Emerging standards are requiring separate keys for audio and visual tracks.</span></span>

-   <span data-ttu-id="12dd7-149">MaxResDecode が追加されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-149">Added MaxResDecode.</span></span>

    <span data-ttu-id="12dd7-150">この機能は、コンテンツの再生を最大解像度に制限するために追加されました (ライセンスではなく、より強力なキーを所有している場合にも制限を受けます)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-150">This feature was added to limit playback of content to a maximum resolution even when in possession of a more capable key (but not a license).</span></span> <span data-ttu-id="12dd7-151">これは、複数のストリーム サイズが 1 つのキーでエンコードされる状況をサポートします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-151">It supports cases where multiple stream sizes are encoded with a single key.</span></span>

<span data-ttu-id="12dd7-152">PlayReady DRM に、次の新しいインターフェイス、クラス、列挙子が追加されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-152">The following new interfaces, classes, and enumerations were added to PlayReady DRM:</span></span>

-   <span data-ttu-id="12dd7-153">[**IPlayReadyLicenseAcquisitionServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986077) インターフェイス</span><span class="sxs-lookup"><span data-stu-id="12dd7-153">[**IPlayReadyLicenseAcquisitionServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986077) interface</span></span>
-   <span data-ttu-id="12dd7-154">[**IPlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986080) インターフェイス</span><span class="sxs-lookup"><span data-stu-id="12dd7-154">[**IPlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986080) interface</span></span>
-   <span data-ttu-id="12dd7-155">[**IPlayReadySecureStopServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986090) インターフェイス</span><span class="sxs-lookup"><span data-stu-id="12dd7-155">[**IPlayReadySecureStopServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986090) interface</span></span>
-   <span data-ttu-id="12dd7-156">[**PlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986309) クラス</span><span class="sxs-lookup"><span data-stu-id="12dd7-156">[**PlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986309) class</span></span>
-   <span data-ttu-id="12dd7-157">[**PlayReadySecureStopIterable**](https://msdn.microsoft.com/library/windows/apps/dn986371) クラス</span><span class="sxs-lookup"><span data-stu-id="12dd7-157">[**PlayReadySecureStopIterable**](https://msdn.microsoft.com/library/windows/apps/dn986371) class</span></span>
-   <span data-ttu-id="12dd7-158">[**PlayReadySecureStopIterator**](https://msdn.microsoft.com/library/windows/apps/dn986375) クラス</span><span class="sxs-lookup"><span data-stu-id="12dd7-158">[**PlayReadySecureStopIterator**](https://msdn.microsoft.com/library/windows/apps/dn986375) class</span></span>
-   <span data-ttu-id="12dd7-159">[**PlayReadyHardwareDRMFeatures**](https://msdn.microsoft.com/library/windows/apps/dn986265) 列挙子</span><span class="sxs-lookup"><span data-stu-id="12dd7-159">[**PlayReadyHardwareDRMFeatures**](https://msdn.microsoft.com/library/windows/apps/dn986265) enumerator</span></span>

<span data-ttu-id="12dd7-160">PlayReady DRM の新機能を利用する方法を示すために、新しいサンプルが作成されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-160">A new sample has been created to demonstrate how to use the new features of PlayReady DRM.</span></span> <span data-ttu-id="12dd7-161">サンプルは、[http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670) からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-161">The sample can be downloaded from [http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670).</span></span>

## <a name="things-to-consider"></a><span data-ttu-id="12dd7-162">考慮事項</span><span class="sxs-lookup"><span data-stu-id="12dd7-162">Things to consider</span></span>

-   <span data-ttu-id="12dd7-163">PlayReady DRM は、HDCP Type 1 (HDCP バージョン 2.1 以降でサポートされます) をサポートするようになりました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-163">PlayReady DRM now supports HDCP Type 1 (supported in HDCP version 2.1 or later).</span></span> <span data-ttu-id="12dd7-164">PlayReady は、デバイスが適用するライセンスで HDCP タイプ制限ポリシーを持っています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-164">PlayReady carries an HDCP Type Restriction policy in the license for the device to enforce.</span></span> <span data-ttu-id="12dd7-165">Windows 10 では、このポリシーにより HDCP 2.2 以降がエンゲージされます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-165">On Windows 10, this policy will enforce that HDCP 2.2 or later is engaged.</span></span> <span data-ttu-id="12dd7-166">この機能は、PlayReady Server v3.0 SDK ライセンスで有効にできます (サーバーは、HDCP タイプ制限 GUID を使って、ライセンスでこのポリシーを管理します)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-166">This feature can be enabled in your PlayReady Server v3.0 SDK license (the server controls this policy in the license using the HDCP Type Restriction GUID).</span></span> <span data-ttu-id="12dd7-167">詳しくは、「[PlayReady の適合性と信頼性規則](http://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-167">For more information, see the [PlayReady Compliance and Robustness Rules](http://www.microsoft.com/playready/licensing/compliance/).</span></span>
-   <span data-ttu-id="12dd7-168">Windows Media Video (VC-1 とも呼ばれます) はハードウェア DRM ではサポートされません (「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-168">Windows Media Video (also known as VC-1) is not supported in hardware DRM (see [Override Hardware DRM](hardware-drm.md#override-hardware-drm)).</span></span>
-   <span data-ttu-id="12dd7-169">PlayReady DRM は、高効率ビデオ コーディング (HEVC/H.265) ビデオ圧縮規格をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-169">PlayReady DRM now supports the High Efficiency Video Coding (HEVC /H.265) video compression standard.</span></span> <span data-ttu-id="12dd7-170">アプリは、HEVC をサポートするには、コンテンツのスライス ヘッダーがクリア テキストのままになる、Common Encryption Scheme (CENC) バージョン 2 のコンテンツを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-170">To support HEVC, your app must use Common Encryption Scheme (CENC) version 2 content which includes leaving the content's slice headers in the clear.</span></span> <span data-ttu-id="12dd7-171">詳しくは、「ISO/IEC 23001-7 情報テクノロジ -- MPEG システム テクノロジ -- パート 7: ISO ベース メディア ファイル形式ファイルの一般的な暗号化」をご覧ください。(仕様バージョン ISO/IEC 23001-7:2015 以降が必要です)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-171">Refer to ISO/IEC 23001-7 Information technology -- MPEG systems technologies -- Part 7: Common encryption in ISO base media file format files (Spec version ISO/IEC 23001-7:2015 or higher is required.) for more information.</span></span> <span data-ttu-id="12dd7-172">また、すべて HWDRM のコンテンツで、CENC バージョン 2 を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-172">Microsoft also recommends using CENC version 2 for all HWDRM content.</span></span> <span data-ttu-id="12dd7-173">さらに、ハードウェア DRM によって、HEVC をサポートするものとそうでないものがあります (「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-173">In addition, some hardware DRM will support HEVC and some will not (see [Override Hardware DRM](hardware-drm.md#override-hardware-drm)).</span></span>
-   <span data-ttu-id="12dd7-174">新しい PlayReady 3.0 機能 (ハードウェア ベースのクライアント用の SL3000、1 つのライセンス取得メッセージでの永続的でない複数のライセンスの取得、永続的でないライセンスでの時間ベースの制限を含みますが、これらに限定されません) を活用するには、PlayReady サーバーが、Microsoft PlayReady サーバー ソフトウェア開発キット v3.0.2769 リリース バージョン以降である必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-174">To take advantage of certain new PlayReady 3.0 features (including, but not limited to, SL3000 for hardware-based clients, acquiring multiple non-persistent licenses in one license acquisition message, and time-based restrictions on non-persistent licenses), the PlayReady server is required to be the Microsoft PlayReady Server Software Development Kit v3.0.2769 Release version or later.</span></span>
-   <span data-ttu-id="12dd7-175">コンテンツ ライセンスで指定された、出力保護ポリシーによっては、接続されている出力がこれらの要件をサポートしていない場合、メディアの再生はエンド ユーザーに対して失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-175">Depending on the Output Protection Policy specified in the content license, media playback may fail for end users if their connected output does not support those requirements.</span></span> <span data-ttu-id="12dd7-176">次の表は、結果として発生する一般的なエラーを示しています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-176">The following table lists the set of common errors that occur as a result.</span></span> <span data-ttu-id="12dd7-177">詳しくは、「[PlayReady の適合性と信頼性規則](http://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-177">For more information, see the [PlayReady Compliance and Robustness Rules](http://www.microsoft.com/playready/licensing/compliance/).</span></span>

| <span data-ttu-id="12dd7-178">エラー</span><span class="sxs-lookup"><span data-stu-id="12dd7-178">Error</span></span>                                                   | <span data-ttu-id="12dd7-179">値</span><span class="sxs-lookup"><span data-stu-id="12dd7-179">Value</span></span>      | <span data-ttu-id="12dd7-180">説明</span><span class="sxs-lookup"><span data-stu-id="12dd7-180">Description</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|---------------------------------------------------------|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="12dd7-181">ERROR\_GRAPHICS\_OPM\_OUTPUT\_DOES\_NOT\_SUPPORT\_HDCP</span><span class="sxs-lookup"><span data-stu-id="12dd7-181">ERROR\_GRAPHICS\_OPM\_OUTPUT\_DOES\_NOT\_SUPPORT\_HDCP</span></span>  | <span data-ttu-id="12dd7-182">0xC0262513</span><span class="sxs-lookup"><span data-stu-id="12dd7-182">0xC0262513</span></span> | <span data-ttu-id="12dd7-183">ライセンスの出力保護ポリシーでは、モニターが HDCP をエンゲージする必要がありますが、HDCP をエンゲージできませんでした。</span><span class="sxs-lookup"><span data-stu-id="12dd7-183">The license's Output Protection Policy requires the monitor to engage HDCP, but HDCP was unable to be engaged.</span></span>                                                                                                                                                                                                                                                                                                                                                                                              |
| <span data-ttu-id="12dd7-184">MF\_E\_POLICY\_UNSUPPORTED</span><span class="sxs-lookup"><span data-stu-id="12dd7-184">MF\_E\_POLICY\_UNSUPPORTED</span></span>                              | <span data-ttu-id="12dd7-185">0xC00D7159</span><span class="sxs-lookup"><span data-stu-id="12dd7-185">0xC00D7159</span></span> | <span data-ttu-id="12dd7-186">ライセンスの出力保護ポリシーでは、モニターが HDCP Type 1 をエンゲージする必要がありますが、HDCP Type 1 をエンゲージできませんでした。</span><span class="sxs-lookup"><span data-stu-id="12dd7-186">The license's Output Protection Policy requires the monitor to engage HDCP Type 1, but HDCP Type 1 was unable to be engaged.</span></span>                                                                                                                                                                                                                                                                                                                                                                                |
| <span data-ttu-id="12dd7-187">DRM\_E\_TEE\_OUTPUT\_PROTECTION\_REQUIREMENTS\_NOT\_MET</span><span class="sxs-lookup"><span data-stu-id="12dd7-187">DRM\_E\_TEE\_OUTPUT\_PROTECTION\_REQUIREMENTS\_NOT\_MET</span></span> | <span data-ttu-id="12dd7-188">0x8004CD22</span><span class="sxs-lookup"><span data-stu-id="12dd7-188">0x8004CD22</span></span> | <span data-ttu-id="12dd7-189">このエラー コードは、ハードウェア DRM で実行されている場合にのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-189">This error code only occurs when running under hardware DRM.</span></span> <span data-ttu-id="12dd7-190">ライセンスの出力保護ポリシーでは、モニターが HDCP をエンゲージするか、コンテンツの実質的な解像度を減らす必要がありますが、ハードウェア DRM はコンテンツの解像度の減少をサポートしていないため、HDCP をエンゲージできず、コンテンツの実質的な解像度を減らすことができませんでした。</span><span class="sxs-lookup"><span data-stu-id="12dd7-190">The license's Output Protection Policy requires the monitor to engage HDCP or to reduce the content's effective resolution, but HDCP was unable to be engaged and the content's effective resolution could not be reduced because hardware DRM does not support reducing the content's resolution.</span></span> <span data-ttu-id="12dd7-191">ソフトウェア DRM で、コンテンツは再生されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-191">Under software DRM, the content plays.</span></span> <span data-ttu-id="12dd7-192">「[ハードウェア DRM を使うための考慮事項](hardware-drm.md#considerations-for-using-hardware-drm)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-192">See [Considerations for Using Hardware DRM](hardware-drm.md#considerations-for-using-hardware-drm).</span></span> |
| <span data-ttu-id="12dd7-193">ERROR\_GRAPHICS\_OPM\_NOT\_SUPPORTED</span><span class="sxs-lookup"><span data-stu-id="12dd7-193">ERROR\_GRAPHICS\_OPM\_NOT\_SUPPORTED</span></span>                    | <span data-ttu-id="12dd7-194">0xc0262500</span><span class="sxs-lookup"><span data-stu-id="12dd7-194">0xc0262500</span></span> | <span data-ttu-id="12dd7-195">グラフィックス ドライバーは、出力保護をサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-195">The graphics driver does not support Output Protection.</span></span> <span data-ttu-id="12dd7-196">たとえば、モニターが VGA 経由で接続されているか、デジタル出力用の適切なグラフィックス ドライバーがインストールされていません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-196">For example, the monitor is connected through VGA or an appropriate graphics driver for the digital output is not installed.</span></span> <span data-ttu-id="12dd7-197">後者の場合、インストールされている一般的なドライバーは Microsoft ベーシック ディスプレイ アダプターであり、適切なグラフィックス ドライバーをインストールすることで、問題が解決されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-197">In the latter case, the typical driver that is installed is the Microsoft Basic Display Adapter and installing an appropriate graphics driver will resolve the issue.</span></span>                                                                                                                                                  |

## <a name="output-protection"></a><span data-ttu-id="12dd7-198">出力保護</span><span class="sxs-lookup"><span data-stu-id="12dd7-198">Output protection</span></span>

<span data-ttu-id="12dd7-199">次のセクションでは、PlayReady ライセンスの出力保護ポリシーを用いて Windows 10 用の PlayReady DRM を使用する場合の動作について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-199">The following section describes the behavior when using PlayReady DRM for Windows 10 with output protection policies in a PlayReady license.</span></span>

<span data-ttu-id="12dd7-200">PlayReady DRM でサポートされる出力保護レベルは、**Microsoft PlayReady の拡張可能なメディア使用権仕様**に記載されています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-200">PlayReady DRM supports output protection levels contained in the **Microsoft PlayReady Extensible Media Rights Specification**.</span></span> <span data-ttu-id="12dd7-201">このドキュメントは、PlayReady ライセンス製品に付属しているドキュメント パッケージに含まれています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-201">This document can be found in the documentation pack that comes with PlayReady licensed products.</span></span>

> [!NOTE]
> <span data-ttu-id="12dd7-202">ライセンス サーバーで設定できる出力保護レベルの許容値は、[PlayReady の適合性規則](https://www.microsoft.com/playready/licensing/compliance/)に準拠します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-202">The allowed values for output protection levels that can be set by a licensing server are governed by the [PlayReady Compliance Rules](https://www.microsoft.com/playready/licensing/compliance/).</span></span>

<span data-ttu-id="12dd7-203">PlayReady DRM では、PlayReady の適合性規則で指定された出力コネクタ上でのみ出力保護ポリシーを使用してコンテンツを再生できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-203">PlayReady DRM allows playback of content with output protection policies only on output connectors as specified in the PlayReady Compliance Rules.</span></span> <span data-ttu-id="12dd7-204">PlayReady の適合性規則で指定された出力コネクタの条件について詳しくは、[PlayReady の適合性と信頼性規則の定義済みの条件](https://www.microsoft.com/playready/licensing/compliance/)をご覧ください</span><span class="sxs-lookup"><span data-stu-id="12dd7-204">For more information about output connector terms specified in the PlayReady Compliance Rules, see [Defined Terms for PlayReady Compliance and Robustness Rules](https://www.microsoft.com/playready/licensing/compliance/).</span></span>

<span data-ttu-id="12dd7-205">このセクションは、主に Windows 10 用の PlayReady DRM と、一部の Windows クライアントでも利用できる Windows 10 用の PlayReady ハードウェア DRM を使用した出力保護シナリオについて扱います。</span><span class="sxs-lookup"><span data-stu-id="12dd7-205">This section focuses on output protection scenarios with PlayReady DRM for Windows 10 and PlayReady Hardware DRM for Windows 10, which is also available on some Windows clients.</span></span> <span data-ttu-id="12dd7-206">PlayReady HWDRM を使用すると、すべての出力保護は Windows TEE 実装内から適用されます ([ハードウェア DRM](hardware-drm.md) をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-206">With PlayReady HWDRM, all output protections are enforced from within the Windows TEE implementation (see [Hardware DRM](hardware-drm.md)).</span></span> <span data-ttu-id="12dd7-207">このため、PlayReady SWDRM (ソフトウェア DRM) を使用する場合とは一部の動作が異なります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-207">As a result, some behaviors differ from when using PlayReady SWDRM (software DRM):</span></span>

* <span data-ttu-id="12dd7-208">未圧縮デジタル ビデオ用の出力保護レベル (OPL) 270 のサポート。Windows 10 用の PlayReady HWDRM では解像度の低下がサポートされず、HDCP (高帯域幅デジタル コンテンツ保護) がエンゲージされます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-208">Support for Output Protection Level (OPL) for Uncompressed Digital Video 270: PlayReady HWDRM for Windows 10 doesn't support down-resolution and will enforce that HDCP (High-bandwidth Digital Content Protection) is engaged.</span></span> <span data-ttu-id="12dd7-209">HWDRM の高解像度コンテンツには、270 を超える OPL をお勧めします (ただし、必須ではありません)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-209">It is recommended that high definition content for HWDRM have an OPL greater than 270 (although it is not required).</span></span> <span data-ttu-id="12dd7-210">さらに、ライセンス (HDCP バージョン 2.2 以降) で HDCP タイプ制限を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-210">Additionally, you should set HDCP type restriction in the license (HDCP version 2.2 or later).</span></span>
* <span data-ttu-id="12dd7-211">SWDRM とは異なり、HWDRM を使用すると、出力の保護は最も能力の低いモニターに基づいてすべてのモニターに適用されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-211">Unlike SWDRM, with HWDRM, output protections are enforced on all monitors based on the least capable monitor.</span></span> <span data-ttu-id="12dd7-212">たとえば、ユーザーが 2 台のモニターを接続していて、1 台が HDCP をサポートし、もう 1 台がサポートしていない場合、HDCP をサポートするモニターでコンテンツがレンダリングされているのみの場合でも、ライセンスに HDCP が必要な場合、再生は失敗します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-212">For example, if the user has two monitors connected where one supports HDCP and the other doesn't, playback will fail if the license requires HDCP even if the content is only being rendered on the monitor that supports HDCP.</span></span> <span data-ttu-id="12dd7-213">SWDRM では、HDCP をサポートされているモニターにレンダリングされているのみの場合、コンテンツは再生されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-213">In SWDRM, content will play back as long as it's only being rendered on the monitor that supports HDCP.</span></span>
* <span data-ttu-id="12dd7-214">コンテンツのキーとライセンスで、次の条件が満たされていない限り、HWDRM はクライアントで使用され、安全であることが保証されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-214">HWDRM is not guaranteed to be used by the client and secure unless the following conditions are met by the content keys and licenses:</span></span>
    * <span data-ttu-id="12dd7-215">ビデオのコンテンツ キーに使われるライセンスには、最低限のセキュリティ レベルとして 3000 が必要です。</span><span class="sxs-lookup"><span data-stu-id="12dd7-215">The license used for the video content key must have a minimum security level of 3000.</span></span>
    * <span data-ttu-id="12dd7-216">オーディオは、ビデオとは異なるコンテンツ キーに暗号化される必要があります。また、オーディオに使われるライセンスには、最低限のセキュリティ レベルとして 2000 が必要です。</span><span class="sxs-lookup"><span data-stu-id="12dd7-216">Audio must be encrypted to a different content key than video, and the license used for audio must have a minimum security level of 2000.</span></span> <span data-ttu-id="12dd7-217">または、オーディオをプレーン テキストのままにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-217">Alternatively, audio could be left in the clear.</span></span>
* <span data-ttu-id="12dd7-218">すべての SWDRM のシナリオでは、オーディオやビデオのコンテンツ キーに使用される PlayReady ライセンスの最低限のセキュリティ レベルが 2000 以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-218">All SWDRM scenarios require that the minimum security level of the PlayReady license used for the audio and/or video content key is lower or equal to 2000.</span></span>

### <a name="output-protection-levels"></a><span data-ttu-id="12dd7-219">出力保護レベル</span><span class="sxs-lookup"><span data-stu-id="12dd7-219">Output protection levels</span></span>

<span data-ttu-id="12dd7-220">次の表では、PlayReady ライセンスのさまざまな OPL 間のマッピングと、Windows 10 用の PlayReady DRM でそれらを適用する方法の概要を示します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-220">The following table outlines the mappings between various OPLs in the PlayReady license and how PlayReady DRM for Windows 10 enforces them.</span></span>

#### <a name="video"></a><span data-ttu-id="12dd7-221">ビデオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-221">Video</span></span>

<table>
    <tr>
        <th rowspan="2"><span data-ttu-id="12dd7-222">OPL</span><span class="sxs-lookup"><span data-stu-id="12dd7-222">OPL</span></span></th>
        <th><span data-ttu-id="12dd7-223">圧縮デジタル ビデオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-223">Compressed digital video</span></span></th>
        <th colspan="2"><span data-ttu-id="12dd7-224">未圧縮デジタル ビデオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-224">Uncompressed digital video</span></span></th>
        <th><span data-ttu-id="12dd7-225">アナログ テレビ</span><span class="sxs-lookup"><span data-stu-id="12dd7-225">Analog TV</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-226">任意</span><span class="sxs-lookup"><span data-stu-id="12dd7-226">Any</span></span></th>
        <th colspan="2"><span data-ttu-id="12dd7-227">HDMI、DVI、DisplayPort、MHL</span><span class="sxs-lookup"><span data-stu-id="12dd7-227">HDMI, DVI, DisplayPort, MHL</span></span></th>
        <th><span data-ttu-id="12dd7-228">コンポジット、コンポーネント</span><span class="sxs-lookup"><span data-stu-id="12dd7-228">Component, Composite</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-229">100</span><span class="sxs-lookup"><span data-stu-id="12dd7-229">100</span></span></th>
        <td rowspan="6"><span data-ttu-id="12dd7-230">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-230">N/A\*</span></span></td>
        <td colspan="2"><span data-ttu-id="12dd7-231">コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-231">Passes content</span></span></td>
        <td><span data-ttu-id="12dd7-232">コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-232">Passes content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-233">150</span><span class="sxs-lookup"><span data-stu-id="12dd7-233">150</span></span></th>
        <td colspan="2" rowspan="2"><span data-ttu-id="12dd7-234">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-234">N/A\*</span></span></td>
        <td><span data-ttu-id="12dd7-235">CGMS-A CopyNever がエンゲージされている場合、または CGMS-A をエンゲージできない場合に、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-235">Passes content when CGMS-A CopyNever is engaged or if CGMS-A can't be engaged</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-236">200</span><span class="sxs-lookup"><span data-stu-id="12dd7-236">200</span></span></th>
        <td><span data-ttu-id="12dd7-237">CGMS-A CopyNever がエンゲージされている場合に、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-237">Passes content when CGMS-A CopyNever is engaged</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-238">250</span><span class="sxs-lookup"><span data-stu-id="12dd7-238">250</span></span></th>
        <td colspan="2"><span data-ttu-id="12dd7-239">HDCP に対するエンゲージを試みますが、結果にかかわらずコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-239">Attempts to engage HDCP, but passes content regardless of result</span></span></td>
        <td rowspan="5"><span data-ttu-id="12dd7-240">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-240">N/A\*</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-241">270</span><span class="sxs-lookup"><span data-stu-id="12dd7-241">270</span></span></th>
        <td><span data-ttu-id="12dd7-242"><b>SWDRM</b>: HDCP のエンゲージを試みます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-242"><b>SWDRM</b>: Attempts to engage HDCP.</span></span> <span data-ttu-id="12dd7-243">HDCP をエンゲージできない場合、PC は 1 フレームあたりの有効な解像度を 520,000 ピクセルに制限し、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-243">If HDCP fails to engage, the PC will constrain the effective resolution to 520,000 pixels per frame and pass the content</span></span></td>
        <td><span data-ttu-id="12dd7-244"><b>HWDRM</b>: HDCP を使用してコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-244"><b>HWDRM</b>: Passes content with HDCP.</span></span> <span data-ttu-id="12dd7-245">HDCP をエンゲージできない場合、HDMI ポートと DVI ポートでの再生はブロックされます</span><span class="sxs-lookup"><span data-stu-id="12dd7-245">If HDCP fails to engage, playback to HDMI/DVI ports is blocked</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-246">300</span><span class="sxs-lookup"><span data-stu-id="12dd7-246">300</span></span></th>
        <td colspan="2">
            <p><span data-ttu-id="12dd7-247">
                \*\*HDCP のタイプ制限が定義されていない場合:\*\* HDCP でコンテンツを渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-247">
                \*\*When HDCP type restriction is NOT defined:\*\* Passes content with HDCP.</span></span> <span data-ttu-id="12dd7-248">HDCP をエンゲージできない場合、HDMI ポートと DVI ポートでの再生はブロックされます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-248">If HDCP fails to engage, playback to HDMI/DVI ports is blocked.</span></span>
            </p>
            <p><span data-ttu-id="12dd7-249">
                \*\*HDCP のタイプ制限が定義されている場合\*\*: HDCP 2.2 でコンテンツが渡され、コンテンツ ストリーム タイプが 1 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-249">
                \*\*When HDCP type restriction IS defined\*\*: Passes content with HDCP 2.2 and content stream type set to 1.</span></span> <span data-ttu-id="12dd7-250">HDCP をエンゲージできない、またはコンテンツ ストリーム タイプを 1 に設定できない場合、HDMI ポートと DVI ポートでの再生はブロックされます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-250">If HDCP fails to engage or content stream type can't be set to 1, playback to HDMI/DVI ports is blocked.</span></span>
            </p>
        </td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-251">400</span><span class="sxs-lookup"><span data-stu-id="12dd7-251">400</span></span></th>
        <td rowspan="2"><span data-ttu-id="12dd7-252">Windows 10 では、後続の OPL 値に関わらず、圧縮デジタル ビデオ コンテンツが出力に渡されることはありません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-252">Windows 10 never passes compressed digital video content to outputs, regardless of the subsequent OPL value.</span></span> <span data-ttu-id="12dd7-253">圧縮デジタル ビデオ コンテンツについて詳しくは、<a href="https://www.microsoft.com/playready/licensing/compliance/">PlayReady 製品の適合規則</a>をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-253">For more information about compressed digital video content, see the <a href="https://www.microsoft.com/playready/licensing/compliance/">Compliance Rules for PlayReady Products</a>.</span></span></td>
        <td colspan="2" rowspan="2"><span data-ttu-id="12dd7-254">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-254">N/A\*</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-255">500</span><span class="sxs-lookup"><span data-stu-id="12dd7-255">500</span></span></th>
    </tr>
</table>
<br/>

<span data-ttu-id="12dd7-256">\* 出力保護レベルの値の中には、ライセンス サーバーによって設定できないものもあります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-256">\* Not all values for output protection levels can be set by a licensing server.</span></span> <span data-ttu-id="12dd7-257">詳しくは、「[PlayReady の適合性規則](https://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-257">For more information, see the [PlayReady Compliance Rules](https://www.microsoft.com/playready/licensing/compliance/).</span></span>

#### <a name="audio"></a><span data-ttu-id="12dd7-258">オーディオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-258">Audio</span></span>

<table>
    <tr>
        <th rowspan="2"><span data-ttu-id="12dd7-259">OPL</span><span class="sxs-lookup"><span data-stu-id="12dd7-259">OPL</span></span></th>
        <th><span data-ttu-id="12dd7-260">圧縮デジタル オーディオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-260">Compressed digital audio</span></span></th>
        <th><span data-ttu-id="12dd7-261">未圧縮デジタル オーディオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-261">Uncompressed digital audio</span></span></th>
        <th><span data-ttu-id="12dd7-262">アナログまたは USB オーディオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-262">Analog or USB audio</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-263">HDMI、DisplayPort、MHL</span><span class="sxs-lookup"><span data-stu-id="12dd7-263">HDMI, DisplayPort, MHL</span></span></th>
        <th><span data-ttu-id="12dd7-264">HDMI、DisplayPort、MHL</span><span class="sxs-lookup"><span data-stu-id="12dd7-264">HDMI, DisplayPort, MHL</span></span></th>
        <th><span data-ttu-id="12dd7-265">任意</span><span class="sxs-lookup"><span data-stu-id="12dd7-265">Any</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-266">100</span><span class="sxs-lookup"><span data-stu-id="12dd7-266">100</span></span></th>
        <td rowspan="3"><span data-ttu-id="12dd7-267">コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-267">Passes content</span></span></td>
        <td><span data-ttu-id="12dd7-268">コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-268">Passes content</span></span></td>
        <td rowspan="5"><span data-ttu-id="12dd7-269">コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-269">Passes content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-270">150</span><span class="sxs-lookup"><span data-stu-id="12dd7-270">150</span></span></th>
        <td rowspan="4"><span data-ttu-id="12dd7-271">コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-271">Does NOT pass content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-272">200</span><span class="sxs-lookup"><span data-stu-id="12dd7-272">200</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-273">250</span><span class="sxs-lookup"><span data-stu-id="12dd7-273">250</span></span></th>
        <td><span data-ttu-id="12dd7-274">HDMI、DisplayPort、または MHL で HDCP がエンゲージされている場合、または SCMS がエンゲージされて CopyNever に設定されている場合、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-274">Passes content when HDCP is engaged on HDMI, DisplayPort, or MHL, or when SCMS is engaged and set to CopyNever</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-275">300</span><span class="sxs-lookup"><span data-stu-id="12dd7-275">300</span></span></th>
        <td><span data-ttu-id="12dd7-276">HDMI、DisplayPort、または MHL で HDCP がエンゲージされている場合にコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-276">Passes content when HDCP is engaged on HDMI, DisplayPort, or MHL</span></span></td>
    </tr>
</table>
<br/>

### <a name="miracast"></a><span data-ttu-id="12dd7-277">Miracast</span><span class="sxs-lookup"><span data-stu-id="12dd7-277">Miracast</span></span>

<span data-ttu-id="12dd7-278">PlayReady DRM では、HDCP 2.0 以降がエンゲージされるとすぐに Miracast 出力を通じてコンテンツを再生できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-278">PlayReady DRM allows you to play content over Miracast output as soon as HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-279">ただし、Windows 10 では Miracast は*デジタル*出力と見なされます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-279">On Windows 10, however, Miracast is considered a *digital* output.</span></span> <span data-ttu-id="12dd7-280">Miracast シナリオについて詳しくは、[PlayReady の適合規則](https://www.microsoft.com/playready/licensing/compliance/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-280">For more information about Miracast scenarios, see the [PlayReady Compliance Rules](https://www.microsoft.com/playready/licensing/compliance/).</span></span> <span data-ttu-id="12dd7-281">次の表に、PlayReady ライセンスのさまざまな OPL 間のマッピングと、PlayReady DRM でそれらを Miracast 出力に適用する方法について、概要を示します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-281">The following table outlines the mappings between various OPLs in the PlayReady license and how PlayReady DRM enforces them on Miracast outputs.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="12dd7-282">OPL</span><span class="sxs-lookup"><span data-stu-id="12dd7-282">OPL</span></span></th>
        <th><span data-ttu-id="12dd7-283">圧縮デジタル オーディオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-283">Compressed digital audio</span></span></th>
        <th><span data-ttu-id="12dd7-284">未圧縮デジタル オーディオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-284">Uncompressed digital audio</span></span></th>
        <th><span data-ttu-id="12dd7-285">圧縮デジタル ビデオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-285">Compressed digital video</span></span></th>
        <th><span data-ttu-id="12dd7-286">未圧縮デジタル ビデオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-286">Uncompressed digital video</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-287">100</span><span class="sxs-lookup"><span data-stu-id="12dd7-287">100</span></span></th>
        <td rowspan="4"><span data-ttu-id="12dd7-288">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-288">Passes content when HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-289">エンゲージできない場合はコンテンツが渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-289">If it fails to engage, it does NOT pass content</span></span></td>
        <td><span data-ttu-id="12dd7-290">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-290">Passes content when HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-291">エンゲージできない場合はコンテンツが渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-291">If it fails to engage, it does NOT pass content</span></span></td>
        <td rowspan="6"><span data-ttu-id="12dd7-292">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-292">N/A\*</span></span></td>
        <td><span data-ttu-id="12dd7-293">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-293">Passes content when HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-294">エンゲージできない場合はコンテンツが渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-294">If it fails to engage, it does NOT pass content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-295">150</span><span class="sxs-lookup"><span data-stu-id="12dd7-295">150</span></span></th>
        <td rowspan="3"><span data-ttu-id="12dd7-296">コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-296">Does NOT pass content</span></span></td>
        <td rowspan="2"><span data-ttu-id="12dd7-297">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-297">N/A\*</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-298">200</span><span class="sxs-lookup"><span data-stu-id="12dd7-298">200</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-299">250</span><span class="sxs-lookup"><span data-stu-id="12dd7-299">250</span></span></th>
        <td rowspan="2"><span data-ttu-id="12dd7-300">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-300">Passes content when HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-301">エンゲージできない場合はコンテンツが渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-301">If it fails to engage, it does NOT pass content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-302">270</span><span class="sxs-lookup"><span data-stu-id="12dd7-302">270</span></span></th>
        <td colspan="2"><span data-ttu-id="12dd7-303">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-303">N/A\*</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-304">300</span><span class="sxs-lookup"><span data-stu-id="12dd7-304">300</span></span></th>
        <td><span data-ttu-id="12dd7-305">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-305">Passes content when HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-306">エンゲージできない場合はコンテンツが渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-306">If it fails to engage, it does NOT pass content</span></span></td>
        <td><span data-ttu-id="12dd7-307">コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-307">Does NOT pass content</span></span></td>
        <td>
            <p><span data-ttu-id="12dd7-308">
                \*\*HDCP のタイプ制限が定義されていない場合:\*\* HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-308">
                \*\*When HDCP type restriction is NOT defined:\*\* Passes content when HDCP 2.0 or later is engaged.</span></span> <span data-ttu-id="12dd7-309">エンゲージできない場合はコンテンツが渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-309">If it fails to engage, it does NOT pass content.</span></span>
            </p>
            <p><span data-ttu-id="12dd7-310">
                \*\*HDCP のタイプ制限が定義されている場合:\*\* HDCP 2.2 でコンテンツが渡され、コンテンツ ストリーム タイプが 1 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-310">
                \*\*When HDCP type restriction IS defined:\*\* Passes content with HDCP 2.2 and content stream type set to 1.</span></span> <span data-ttu-id="12dd7-311">HDCP をエンゲージできない場合、またはコンテンツ ストリーム タイプを 1 に設定できない場合、コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-311">If HDCP fails to engage or content stream type can't be set to 1, it does NOT pass content.</span></span>
            </p>        
        </td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-312">400</span><span class="sxs-lookup"><span data-stu-id="12dd7-312">400</span></span></th>
        <td rowspan="2" colspan="2"><span data-ttu-id="12dd7-313">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-313">N/A\*</span></span></td>
        <td rowspan="2"><span data-ttu-id="12dd7-314">Windows 10 では、後続の OPL 値に関わらず、圧縮デジタル ビデオ コンテンツが出力に渡されることはありません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-314">Windows 10 never passes compressed digital video content to outputs, regardless of the subsequent OPL value.</span></span> <span data-ttu-id="12dd7-315">圧縮デジタル ビデオ コンテンツについて詳しくは、<a href="https://www.microsoft.com/playready/licensing/compliance/">PlayReady 製品の適合規則</a>をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-315">For more information about compressed digital video content, see the <a href="https://www.microsoft.com/playready/licensing/compliance/">Compliance Rules for PlayReady Products</a>.</span></span></td>
        <td rowspan="2"><span data-ttu-id="12dd7-316">該当なし。\*</span><span class="sxs-lookup"><span data-stu-id="12dd7-316">N/A\*</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-317">500</span><span class="sxs-lookup"><span data-stu-id="12dd7-317">500</span></span></th>
    </tr>
</table>
<br/>

<span data-ttu-id="12dd7-318">\* 出力保護レベルの値の中には、ライセンス サーバーによって設定できないものもあります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-318">\* Not all values for output protection levels can be set by a licensing server.</span></span> <span data-ttu-id="12dd7-319">詳しくは、「[PlayReady の適合性規則](https://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-319">For more information, see the [PlayReady Compliance Rules](https://www.microsoft.com/playready/licensing/compliance/).</span></span>

### <a name="additional-explicit-output-restrictions"></a><span data-ttu-id="12dd7-320">その他の明示的な出力制限</span><span class="sxs-lookup"><span data-stu-id="12dd7-320">Additional explicit output restrictions</span></span>

<span data-ttu-id="12dd7-321">次の表では、明示的なデジタル ビデオ出力保護の制限に関する Windows 10 用の PlayReady DRM の実装を説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-321">The following table describes the PlayReady DRM for Windows 10 implementation of explicit digital video output protection restrictions.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="12dd7-322">シナリオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-322">Scenario</span></span></th>
        <th><span data-ttu-id="12dd7-323">GUID</span><span class="sxs-lookup"><span data-stu-id="12dd7-323">GUID</span></span></th>
        <th><span data-ttu-id="12dd7-324">条件</span><span class="sxs-lookup"><span data-stu-id="12dd7-324">If...</span></span></th>
        <th><span data-ttu-id="12dd7-325">結果</span><span class="sxs-lookup"><span data-stu-id="12dd7-325">Then...</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-326">有効な解像度の最大のデコード サイズ</span><span class="sxs-lookup"><span data-stu-id="12dd7-326">Maximum effective resolution decode size</span></span></th>
        <td><span data-ttu-id="12dd7-327">9645E831-E01D-4FFF-8342-0A720E3E028F</span><span class="sxs-lookup"><span data-stu-id="12dd7-327">9645E831-E01D-4FFF-8342-0A720E3E028F</span></span></td>
        <td><span data-ttu-id="12dd7-328">接続された出力: デジタル ビデオ出力、Miracast、HDMI、DVI など</span><span class="sxs-lookup"><span data-stu-id="12dd7-328">Connected output is: digital video output, Miracast, HDMI, DVI, etc.</span></span></td>
        <td>
            <p>
                <span data-ttu-id="12dd7-329">次のいずれかに制限される場合にコンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-329">Passes content when constrained to:</span></span>  
            </p>
            <ul>
                <li><span data-ttu-id="12dd7-330">(a) フレームの幅が最大フレーム幅以下で (ピクセル単位)、フレームの高さが最大フレーム高以下 (ピクセル単位)</span><span class="sxs-lookup"><span data-stu-id="12dd7-330">(a) the width of the frame must be less than or equal to the maximum frame width in pixels and the height of the frame less than or equal to the maximum frame height in pixels, or</span></span></li>
                <li><span data-ttu-id="12dd7-331">(b) フレームの高さが最大フレーム幅以下で (ピクセル単位)、フレームの幅が最大フレーム高以下 (ピクセル単位)</span><span class="sxs-lookup"><span data-stu-id="12dd7-331">(b) the height of the frame must be less than or equal to the maximum frame width in pixels and the width of the frame less than or equal to the maximum frame height in pixels</span></span></li>
            </ul>                   
        </td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-332">HDCP タイプの制限</span><span class="sxs-lookup"><span data-stu-id="12dd7-332">HDCP type restriction</span></span></th>
        <td><span data-ttu-id="12dd7-333">ABB2C6F1-E663-4625-A945-972D17B231E7</span><span class="sxs-lookup"><span data-stu-id="12dd7-333">ABB2C6F1-E663-4625-A945-972D17B231E7</span></span></td>
        <td><span data-ttu-id="12dd7-334">接続された出力: デジタル ビデオ出力、Miracast、HDMI、DVI など</span><span class="sxs-lookup"><span data-stu-id="12dd7-334">Connected output is: digital video output, Miracast, HDMI, DVI, etc.</span></span></td>
        <td><span data-ttu-id="12dd7-335">HDCP 2.2 でコンテンツが渡され、コンテンツ ストリーム タイプが 1 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-335">Passes content with HDCP 2.2 and the content stream type set to 1.</span></span> <span data-ttu-id="12dd7-336">HDCP 2.2 をエンゲージできない場合、またはコンテンツ ストリーム タイプを 1 に設定できない場合、コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-336">If HDCP 2.2 fails to engage or the content stream type can't be set to 1, it does NOT pass content.</span></span> <span data-ttu-id="12dd7-337">未圧縮デジタル ビデオ出力の保護レベルに 271 以上の値が指定されている必要もあります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-337">Uncompressed digital video output protection level of a value greater than or equal to 271 must also be specified</span></span></td>
    </tr>
</table>
<br/>

<span data-ttu-id="12dd7-338">次の表では、明示的なアナログ ビデオ出力保護の制限に関する Windows 10 用の PlayReady DRM の実装を説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-338">The following table describes the PlayReady DRM for Windows 10 implementation of explicit analog video output protection restrictions.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="12dd7-339">シナリオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-339">Scenario</span></span></th>
        <th><span data-ttu-id="12dd7-340">GUID</span><span class="sxs-lookup"><span data-stu-id="12dd7-340">GUID</span></span></th>
        <th><span data-ttu-id="12dd7-341">条件</span><span class="sxs-lookup"><span data-stu-id="12dd7-341">If...</span></span></th>
        <th colspan="2"><span data-ttu-id="12dd7-342">結果</span><span class="sxs-lookup"><span data-stu-id="12dd7-342">Then...</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-343">アナログ コンピューター モニター</span><span class="sxs-lookup"><span data-stu-id="12dd7-343">Analog computer monitor</span></span></th>
        <td><span data-ttu-id="12dd7-344">D783A191-E083-4BAF-B2DA-E69F910B3772</span><span class="sxs-lookup"><span data-stu-id="12dd7-344">D783A191-E083-4BAF-B2DA-E69F910B3772</span></span></td>
        <td><span data-ttu-id="12dd7-345">接続された出力: VGA、DVI&ndash;アナログなど</span><span class="sxs-lookup"><span data-stu-id="12dd7-345">Connected output is: VGA, DVI&ndash;analog, etc.</span></span></td>
        <td><span data-ttu-id="12dd7-346"><b>SWDRM:</b> PC は有効な解像度を 1 フレームあたり 520,000 epx に制限し、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-346"><b>SWDRM:</b> PC will constrain effective resolution to 520,000 epx per frame and pass content</span></span></td>
        <td><span data-ttu-id="12dd7-347"><b>HWDRM:</b> コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-347"><b>HWDRM:</b> Does NOT pass content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-348">アナログ コンポーネント</span><span class="sxs-lookup"><span data-stu-id="12dd7-348">Analog component</span></span></th>
        <td><span data-ttu-id="12dd7-349">811C5110-46C8-4C6E-8163-C0482A15D47E</span><span class="sxs-lookup"><span data-stu-id="12dd7-349">811C5110-46C8-4C6E-8163-C0482A15D47E</span></span></td>
        <td><span data-ttu-id="12dd7-350">接続された出力: コンポーネント</span><span class="sxs-lookup"><span data-stu-id="12dd7-350">Connected output is: component</span></span></td>
        <td><span data-ttu-id="12dd7-351"><b>SWDRM:</b> PC は有効な解像度を 1 フレームあたり 520,000 epx に制限し、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-351"><b>SWDRM:</b> PC will constrain effective resolution to 520,000 epx per frame and pass content</span></span></td>
        <td><span data-ttu-id="12dd7-352"><b>HWDRM:</b> コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-352"><b>HWDRM:</b> Does NOT pass content</span></span></td>
    </tr>
    <tr>
        <th rowspan="2"><span data-ttu-id="12dd7-353">アナログ テレビ出力</span><span class="sxs-lookup"><span data-stu-id="12dd7-353">Analog TV outputs</span></span></th>
        <td><span data-ttu-id="12dd7-354">2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3</span><span class="sxs-lookup"><span data-stu-id="12dd7-354">2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3</span></span></td>
        <td><span data-ttu-id="12dd7-355">アナログ テレビの OPL が 151 未満</span><span class="sxs-lookup"><span data-stu-id="12dd7-355">Analog TV OPL is less than 151</span></span></td>
        <td colspan="2"><span data-ttu-id="12dd7-356">CGMS-A がエンゲージされる必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-356">CGMS-A must be engaged</span></span></td>
    </tr>
    <tr>
        <td><span data-ttu-id="12dd7-357">225CD36F-F132-49EF-BA8C-C91EA28E4369</span><span class="sxs-lookup"><span data-stu-id="12dd7-357">225CD36F-F132-49EF-BA8C-C91EA28E4369</span></span></td>
        <td><span data-ttu-id="12dd7-358">アナログ テレビ OPL は 101 未満で、ライセンスには 2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3 が含まれません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-358">Analog TV OPL is less than 101 and license doesn't contain 2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3</span></span></td>
        <td colspan="2"><span data-ttu-id="12dd7-359">CGMS-A のエンゲージが試行される必要はありますが、結果にかかわらずコンテンツが再生される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-359">CGMS-A engagement must be attempted, but content may play regardless of result</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-360">自動ゲイン制御とカラー ストライプ</span><span class="sxs-lookup"><span data-stu-id="12dd7-360">Automatic gain control and color stripe</span></span></th>
        <td><span data-ttu-id="12dd7-361">C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA</span><span class="sxs-lookup"><span data-stu-id="12dd7-361">C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA</span></span></td>
        <td><span data-ttu-id="12dd7-362">520,000 ピクセル以下の解像度でコンテンツがアナログ TV 出力に渡される場合</span><span class="sxs-lookup"><span data-stu-id="12dd7-362">Passing content with resolution less than or equal to 520,000 px to analog TV output</span></span></td>
        <td colspan="2"><span data-ttu-id="12dd7-363">解像度が 520,000 ピクセル未満のコンポーネント ビデオおよび PAL モードには自動ゲイン制御のみが設定され、解像度が 520,000 ピクセル未満の NTSC には自動ゲイン制御とカラー ストライプ情報が設定されます。これについては、適合規則のテーブル 3.5.7.3 に</span><span class="sxs-lookup"><span data-stu-id="12dd7-363">Sets AGC only for component video and PAL mode when resolution is less than 520,000 px and sets AGC and color stripe information for NTSC when resolution is less than 520,000 px, according to table 3.5.7.3.</span></span> <span data-ttu-id="12dd7-364">記載されています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-364">in Compliance Rules</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-365">デジタルのみの出力</span><span class="sxs-lookup"><span data-stu-id="12dd7-365">Digital-only output</span></span></th>
        <td><span data-ttu-id="12dd7-366">760AE755-682A-41E0-B1B3-DCDF836A7306</span><span class="sxs-lookup"><span data-stu-id="12dd7-366">760AE755-682A-41E0-B1B3-DCDF836A7306</span></span></td>
        <td><span data-ttu-id="12dd7-367">接続されている出力がアナログ</span><span class="sxs-lookup"><span data-stu-id="12dd7-367">Connected output is analog</span></span></td>
        <td colspan="2"><span data-ttu-id="12dd7-368">コンテンツは渡されません</span><span class="sxs-lookup"><span data-stu-id="12dd7-368">Does not pass content</span></span></td>
    </tr>
</table>
<br/>

> [!NOTE]
> <span data-ttu-id="12dd7-369">"Mini DisplayPort to VGA" のようなアダプター ドングルを再生に使用する場合、Windows 10 ではその出力はデジタル ビデオ出力と見なされ、アナログ ビデオ ポリシーが適用されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-369">When using an adapter dongle such as "Mini DisplayPort to VGA" for playback, Windows 10 sees the output as digital video output, and can't enforce analog video policies.</span></span>

<span data-ttu-id="12dd7-370">次の表では、他の状況で再生を可能にする Windows 10 用の PlayReady DRM 実装について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-370">The following table describes the PlayReady DRM for Windows 10 implementation that enables playing in other circumstances.</span></span>

<table>
    <tr>
        <th><span data-ttu-id="12dd7-371">シナリオ</span><span class="sxs-lookup"><span data-stu-id="12dd7-371">Scenario</span></span></th>
        <th><span data-ttu-id="12dd7-372">GUID</span><span class="sxs-lookup"><span data-stu-id="12dd7-372">GUID</span></span></th>
        <th><span data-ttu-id="12dd7-373">条件</span><span class="sxs-lookup"><span data-stu-id="12dd7-373">If...</span></span></th>
        <th colspan="2"><span data-ttu-id="12dd7-374">結果</span><span class="sxs-lookup"><span data-stu-id="12dd7-374">Then...</span></span></th>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-375">不明な出力</span><span class="sxs-lookup"><span data-stu-id="12dd7-375">Unknown output</span></span></th>
        <td><span data-ttu-id="12dd7-376">786627D8-C2A6-44BE-8F88-08AE255B01A7</span><span class="sxs-lookup"><span data-stu-id="12dd7-376">786627D8-C2A6-44BE-8F88-08AE255B01A7</span></span></td>
        <td><span data-ttu-id="12dd7-377">出力を適切に特定できない場合、またはグラフィックス ドライバーで OPM を確立できない場合</span><span class="sxs-lookup"><span data-stu-id="12dd7-377">If output can't reasonably be determined, or OPM can't be established with graphics driver</span></span></td>
        <td><span data-ttu-id="12dd7-378"><b>SWDRM:</b> コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-378"><b>SWDRM:</b> Passes content</span></span></td>
        <td><span data-ttu-id="12dd7-379"><b>HWDRM:</b> コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-379"><b>HWDRM:</b> Does NOT pass content</span></span></td>
    </tr>
    <tr>
        <th><span data-ttu-id="12dd7-380">制限のある不明な出力</span><span class="sxs-lookup"><span data-stu-id="12dd7-380">Unknown output with constriction</span></span></th>
        <td><span data-ttu-id="12dd7-381">B621D91F-EDCC-4035-8D4B-DC71760D43E9</span><span class="sxs-lookup"><span data-stu-id="12dd7-381">B621D91F-EDCC-4035-8D4B-DC71760D43E9</span></span></td>
        <td><span data-ttu-id="12dd7-382">出力を適切に特定できない場合、またはグラフィックス ドライバーで OPM を確立できない場合</span><span class="sxs-lookup"><span data-stu-id="12dd7-382">If output can't reasonably be determined, or OPM can't be established with graphics driver</span></span></td>
        <td><span data-ttu-id="12dd7-383"><b>SWDRM:</b> PC は有効な解像度を 1 フレームあたり 520,000 epx に制限し、コンテンツが渡されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-383"><b>SWDRM:</b> PC will constrain effective resolution to 520,000 epx per frame and pass content</span></span></td>
        <td><span data-ttu-id="12dd7-384"><b>HWDRM:</b> コンテンツは渡されません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-384"><b>HWDRM:</b> Does NOT pass content</span></span></td>
    </tr>
</table>
<br/>

## <a name="prerequisites"></a><span data-ttu-id="12dd7-385">前提条件</span><span class="sxs-lookup"><span data-stu-id="12dd7-385">Prerequisites</span></span>

<span data-ttu-id="12dd7-386">PlayReady で保護された UWP アプリの作成を開始する前に、次のソフトウェアがシステムにインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-386">Before you begin creating your PlayReady-protected UWP app, the following software needs to be installed on your system:</span></span>

-   <span data-ttu-id="12dd7-387">Windows 10。</span><span class="sxs-lookup"><span data-stu-id="12dd7-387">Windows10.</span></span>
-   <span data-ttu-id="12dd7-388">UWP アプリの PlayReady DRM の任意のサンプルをコンパイルするが場合、は、Microsoft Visual Studio2015 を使用する必要がありますか、後で、サンプルをコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-388">If you are compiling any of the samples for PlayReady DRM for UWP apps, you must use Microsoft Visual Studio2015 or later to compile the samples.</span></span> <span data-ttu-id="12dd7-389">任意の Windows8.1 ストア アプリ用の PlayReady DRM のサンプルをコンパイルするのに Microsoft Visual Studio2013 を引き続き使用できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-389">You can still use Microsoft Visual Studio2013 to compile any of the samples from PlayReady DRM for Windows8.1 Store Apps.</span></span>

<!--This is no longer available-->
<!--If you are planning to play back MPEG-2/H.262 content on your app, you must also download and install [Windows 8.1 Media Center Pack](http://go.microsoft.com/fwlink/p/?LinkId=626876).-->

## <a name="playready-uwp-app-migration-guide"></a><span data-ttu-id="12dd7-390">PlayReady UWP アプリの移行ガイド</span><span class="sxs-lookup"><span data-stu-id="12dd7-390">PlayReady UWP app migration guide</span></span>

<span data-ttu-id="12dd7-391">このセクションには、既にある PlayReady Windows 8.x ストア アプリを windows 10 に移行する方法に関する情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-391">This section includes information on how to migrate your existing PlayReady Windows 8.x Store apps to Windows10.</span></span>

<span data-ttu-id="12dd7-392">Windows 10 の PlayReady UWP アプリの名前空間は、 **Microsoft.Media.PlayReadyClient**から[**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454)に変更されました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-392">The namespace for PlayReady UWP apps on Windows10 was changed from **Microsoft.Media.PlayReadyClient** to [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454).</span></span> <span data-ttu-id="12dd7-393">つまり、コード内で以前の名前空間を探し、新しい名前空間に置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-393">This means that you will need to search and replace the old namespace with the new one in your code.</span></span> <span data-ttu-id="12dd7-394">winmd ファイルは、引き続き参照されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-394">You will still be referencing a winmd file.</span></span> <span data-ttu-id="12dd7-395">Windows 10 オペレーティング システムで windows.media.winmd の一部です。</span><span class="sxs-lookup"><span data-stu-id="12dd7-395">It is part of windows.media.winmd on the Windows10 operating system.</span></span> <span data-ttu-id="12dd7-396">TH の Windows SDK の一部として、windows.winmd に含まれています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-396">It is in windows.winmd as part of the TH’s Windows SDK.</span></span> <span data-ttu-id="12dd7-397">winmd ファイルは、UWP では、windows.foundation.univeralappcontract.winmd で参照されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-397">For UWP, it’s referenced in windows.foundation.univeralappcontract.winmd.</span></span>

<span data-ttu-id="12dd7-398">PlayReady で保護された高解像度 (HD) コンテンツ (1080p) および超高解像度 (UHD) コンテンツを再生するには、PlayReady ハードウェア DRM を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-398">To play back PlayReady-protected high definition (HD) content (1080p) and ultra-high definition (UHD) content, you will need to implement PlayReady hardware DRM.</span></span> <span data-ttu-id="12dd7-399">PlayReady ハードウェア DRM を実装する方法について詳しくは、「[ハードウェア DRM](hardware-drm.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-399">For information on how to implement PlayReady hardware DRM, see [Hardware DRM](hardware-drm.md).</span></span>

<span data-ttu-id="12dd7-400">一部のコンテンツは、ハードウェア DRM ではサポートされません。</span><span class="sxs-lookup"><span data-stu-id="12dd7-400">Some content is not supported in hardware DRM.</span></span> <span data-ttu-id="12dd7-401">ハードウェア DRM の無効化とソフトウェア DRM の有効化について詳しくは、「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-401">For information on disabling hardware DRM and enabling software DRM, see [Override Hardware DRM](hardware-drm.md#override-hardware-drm).</span></span>

<span data-ttu-id="12dd7-402">メディア保護マネージャーについては、コードに次の設定を必ず含めてください (まだ含まれていない場合)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-402">Regarding the media protection manager, make sure your code has the following settings if it doesn’t already:</span></span>

```cs
var mediaProtectionManager = new Windows.Media.Protection.MediaProtectionManager();

mediaProtectionManager.Properties["Windows.Media.Protection.MediaProtectionSystemId"] = 
             '{F4637010-03C3-42CD-B932-B48ADF3A6A54}'
var cpsystems = new Windows.Foundation.Collections.PropertySet();
cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = 
                "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput";
mediaProtectionManager.Properties["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;

mediaProtectionManager.Properties["Windows.Media.Protection.MediaProtectionContainerGuid"] = 
                "{9A04F079-9840-4286-AB92-E65BE0885F95}";
```

## <a name="proactively-acquire-a-non-persistent-license-before-playback"></a><span data-ttu-id="12dd7-403">再生する前に永続的でないライセンスを事前に取得する</span><span class="sxs-lookup"><span data-stu-id="12dd7-403">Proactively acquire a non-persistent license before playback</span></span>

<span data-ttu-id="12dd7-404">このセクションでは、再生を開始する前に、永続的でないライセンスを事前に取得する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-404">This section describes how to acquire non-persistent licenses proactively before playback begins.</span></span>

<span data-ttu-id="12dd7-405">以前のバージョンの PlayReady DRM では、永続的でないライセンスは、再生中のみ反応的に取得できました。</span><span class="sxs-lookup"><span data-stu-id="12dd7-405">In previous versions of PlayReady DRM, non-persistent licenses could only be acquired reactively during playback.</span></span> <span data-ttu-id="12dd7-406">このバージョンでは、再生を開始する前に、永続的でないライセンスを事前に取得することができます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-406">In this version, you can acquire non-persistent licenses proactively before playback begins.</span></span>

1.  <span data-ttu-id="12dd7-407">永続的でないライセンスを格納できる再生セッションを事前に作成します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-407">Proactively create a playback session where the non-persistent license can be stored.</span></span> <span data-ttu-id="12dd7-408">例:</span><span class="sxs-lookup"><span data-stu-id="12dd7-408">For example:</span></span>

    ```cs
    var cpsystems = new Windows.Foundation.Collections.PropertySet();       
    cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput"; // PlayReady

    var pmpSystemInfo = new Windows.Foundation.Collections.PropertySet();
    pmpSystemInfo["Windows.Media.Protection.MediaProtectionSystemId"] = "{F4637010-03C3-42CD-B932-B48ADF3A6A54}";
    pmpSystemInfo["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;
    var pmpServer = new Windows.Media.Protection.MediaProtectionPMPServer( pmpSystemInfo );
    ```

2.  <span data-ttu-id="12dd7-409">その再生セッションをライセンス取得クラスに結び付けます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-409">Tie that playback session to the license acquisition class.</span></span> <span data-ttu-id="12dd7-410">例:</span><span class="sxs-lookup"><span data-stu-id="12dd7-410">For example:</span></span>

    ```cs
    var licenseSessionProperties = new Windows.Foundation.Collections.PropertySet();
    licenseSessionProperties["Windows.Media.Protection.MediaProtectionPMPServer"] = pmpServer;
    var licenseSession = new Windows.Media.Protection.PlayReady.PlayReadyLicenseSession( licenseSessionProperties );
    ```

3.  <span data-ttu-id="12dd7-411">ライセンス サービス要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-411">Create a license service request.</span></span> <span data-ttu-id="12dd7-412">例:</span><span class="sxs-lookup"><span data-stu-id="12dd7-412">For example:</span></span>

    ```cs
    var laSR = licenseSession.CreateLAServiceRequest();
    ```

4.  <span data-ttu-id="12dd7-413">手順 3. で作成したサービスの要求を使ってライセンスの取得を実行します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-413">Perform the license acquisition using the service request created from step 3.</span></span> <span data-ttu-id="12dd7-414">ライセンスは、再生セッションに格納されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-414">The license will be stored in the playback session.</span></span>
5.  <span data-ttu-id="12dd7-415">再生のメディア ソースに再生セッションに結び付けます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-415">Tie the playback session to the media source for playback.</span></span> <span data-ttu-id="12dd7-416">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-416">For example:</span></span>

    ```cs
    licenseSession.configureMediaProtectionManager( mediaProtectionManager );
    videoPlayer.msSetMediaProtectionManager( mediaProtectionManager );
    ```
    
## <a name="query-for-protection-capabilities"></a><span data-ttu-id="12dd7-417">保護機能を照会する</span><span class="sxs-lookup"><span data-stu-id="12dd7-417">Query for protection capabilities</span></span>
<span data-ttu-id="12dd7-418">Windows 10 Version 1703 以降では、デコード コーデック、解像度、出力保護 (HDCP) などの HW DRM 機能を照会できます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-418">Starting with Windows 10, version 1703, you can query HW DRM capabilities, such as decode codecs, resolution, and output protections (HDCP).</span></span> <span data-ttu-id="12dd7-419">クエリを実行するには、[**IsTypeSupported**](https://docs.microsoft.com/uwp/api/windows.media.protection.protectioncapabilities.istypesupported) メソッドを使います。このメソッドには、サポート状態を照会する機能を表す文字列と、クエリの適用先のキー システムを指定する文字列を指定します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-419">Queries are performed with the [**IsTypeSupported**](https://docs.microsoft.com/uwp/api/windows.media.protection.protectioncapabilities.istypesupported) method which takes a string representing the capabilities for which support is queried and a string specifying the key system to which the query applies.</span></span> <span data-ttu-id="12dd7-420">サポートされている文字列値の一覧については、API リファレンスの [**IsTypeSupported**](https://docs.microsoft.com/uwp/api/windows.media.protection.protectioncapabilities.istypesupported) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-420">For a list of supported string values, see the API reference page for [**IsTypeSupported**](https://docs.microsoft.com/uwp/api/windows.media.protection.protectioncapabilities.istypesupported).</span></span> <span data-ttu-id="12dd7-421">次のコード例は、このメソッドの使用方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="12dd7-421">The following code example illustrates the usage of this method.</span></span>  

    ```cs
    using namespace Windows::Media::Protection;

    ProtectionCapabilities^ sr = ref new ProtectionCapabilities();

    ProtectionCapabilityResult result = sr->IsTypeSupported(
    L"video/mp4; codecs=\"avc1.640028\"; features=\"decode-bpp=10,decode-fps=29.97,decode-res-x=1920,decode-res-y=1080\"",
    L"com.microsoft.playready");

    switch (result)
    {
        case ProtectionCapabilityResult::Probably:
        // Queue up UHD HW DRM video
        break;

        case ProtectionCapabilityResult::Maybe:
        // Check again after UI or poll for more info.
        break;

        case ProtectionCapabilityResult::NotSupported:
        // Do not queue up UHD HW DRM video.
        break;
    }
    ```
## <a name="add-secure-stop"></a><span data-ttu-id="12dd7-422">セキュア ストップを追加する</span><span class="sxs-lookup"><span data-stu-id="12dd7-422">Add secure stop</span></span>

<span data-ttu-id="12dd7-423">このセクションでは、UWP アプリにセキュア ストップを追加する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-423">This section describes how to add secure stop to your UWP app.</span></span>

<span data-ttu-id="12dd7-424">セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-424">Secure stop provides the means for a PlayReady device to confidently assert to a media streaming service that media playback has stopped for any given piece of content.</span></span> <span data-ttu-id="12dd7-425">この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-425">This capability ensures your media streaming services provide accurate enforcement and reporting of usage limitations on different devices for a given account.</span></span>

<span data-ttu-id="12dd7-426">セキュア ストップのチャレンジを送信する主なシナリオが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-426">There are two primary scenarios for sending a secure stop challenge:</span></span>

-   <span data-ttu-id="12dd7-427">コンテンツの最後に達したか、ユーザーがメディア プレゼンテーションを途中で停止したため、メディア プレゼンテーションが停止した場合。</span><span class="sxs-lookup"><span data-stu-id="12dd7-427">When the media presentation stops because end of content was reached or when the user stopped the media presentation somewhere in the middle.</span></span>
-   <span data-ttu-id="12dd7-428">(システムまたはアプリのクラッシュなどにより) 前回のセッションが予期せずに終了した場合。</span><span class="sxs-lookup"><span data-stu-id="12dd7-428">When the previous session ends unexpectedly (for example, due to a system or app crash).</span></span> <span data-ttu-id="12dd7-429">アプリは、起動時またはシャットダウン時に、未処理のセキュア ストップ セッションについて照会し、その他のメディア再生とは別にチャレンジを送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-429">The app will need to query, either at startup or shutdown, for any outstanding secure stop sessions and send challenge(s) separate from any other media playback.</span></span>

<span data-ttu-id="12dd7-430">セキュア ストップのサンプル実装については、[http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670) にある PlayReady サンプルの securestop.cs ファイルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-430">For a sample implementation of secure stop, see the securestop.cs file in the PlayReady sample located at [http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670).</span></span>

## <a name="use-playready-drm-on-xbox-one"></a><span data-ttu-id="12dd7-431">Xbox One での PlayReady DRM の使用</span><span class="sxs-lookup"><span data-stu-id="12dd7-431">Use PlayReady DRM on Xbox One</span></span>

<span data-ttu-id="12dd7-432">Xbox One において UWP アプリで PlayReady DRM を使用するには、まず、アプリの公開に使用するデベロッパー センター アカウントを登録して、PlayReady の使用許可を得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-432">To use PlayReady DRM in a UWP app on Xbox One, you will first need to register your Dev Center account that you're using to publish the app for authorization to use PlayReady.</span></span> <span data-ttu-id="12dd7-433">これは次の 2 つのいずれかの方法で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-433">You can do this in one of two ways:</span></span>

* <span data-ttu-id="12dd7-434">Microsoft の連絡担当者を通じて許可を申請します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-434">Have your contact at Microsoft request permission.</span></span>
* <span data-ttu-id="12dd7-435">デベロッパー センター アカウントと会社名を [pronxbox@microsoft.com](mailto:pronxbox@microsoft.com) に送信して許可を申請します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-435">Apply for authorization by sending your Dev Center account and company name to [pronxbox@microsoft.com](mailto:pronxbox@microsoft.com).</span></span>

<span data-ttu-id="12dd7-436">許可を受信したら、追加の `<DeviceCapability>` をアプリ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-436">Once you receive authorization, you'll need to add an additional `<DeviceCapability>` to the app manifest.</span></span> <span data-ttu-id="12dd7-437">アプリケーション マニフェスト デザイナーには現在利用できる設定がないため、これは手動で追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-437">You'll have to add this manually because there is currently no setting available in the App Manifest Designer.</span></span> <span data-ttu-id="12dd7-438">構成するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-438">Follow these steps to configure it:</span></span>

1. <span data-ttu-id="12dd7-439">Visual Studio でプロジェクトを開き、**ソリューション エクスプローラー**を開いて **Package.appxmanifest** を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-439">With the project open in Visual Studio, open the **Solution Explorer** and right-click **Package.appxmanifest**.</span></span>
2. <span data-ttu-id="12dd7-440">**[ファイルを開くアプリケーションの選択]** をクリックして **[XML (テキスト) エディター]** を選択し、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="12dd7-440">Select **Open With...**, choose **XML (Text) Editor**, and click **OK**.</span></span>
3. <span data-ttu-id="12dd7-441">`<Capabilities>` タグの間に次の `<DeviceCapability>` を追加します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-441">Between the `<Capabilities>` tags, add the following `<DeviceCapability>`:</span></span>

    ```xml
    <DeviceCapability Name="6a7e5907-885c-4bcb-b40a-073c067bd3d5" />
    ```

4. <span data-ttu-id="12dd7-442">ファイルを保存します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-442">Save the file.</span></span>

<span data-ttu-id="12dd7-443">最後に、Xbox One で PlayReady を使用する場合の最後の考慮事項として、開発キットでは、SL150 のみに使用が制限されています (SL2000 や SL3000 のコンテンツは再生できません)。</span><span class="sxs-lookup"><span data-stu-id="12dd7-443">Finally, there is one last consideration when using PlayReady on Xbox One: on development kits, there is an SL150 limit (that is, they can't play SL2000 or SL3000 content).</span></span> <span data-ttu-id="12dd7-444">製品デバイスではセキュリティ レベルの高いコンテンツを再生できますが、開発キットでアプリをテストするには、SL150 のコンテンツを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12dd7-444">Retail devices are able to play content with higher security levels, but to test your app on a dev kit, you'll need to use SL150 content.</span></span> <span data-ttu-id="12dd7-445">このコンテンツのテストは、次のいずれかの方法で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="12dd7-445">You can test this content in one of the following ways:</span></span>

* <span data-ttu-id="12dd7-446">SL150 ライセンスを必要とするテスト コンテンツを選択して使用します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-446">Use curated test content that requires SL150 licenses.</span></span>
* <span data-ttu-id="12dd7-447">特定の認証されたテスト アカウントのみが、特定のコンテンツについて SL150 ライセンスを取得できるようにロジックを実装します。</span><span class="sxs-lookup"><span data-stu-id="12dd7-447">Implement logic so that only certain authenticated test accounts are able to acquire SL150 licenses for certain content.</span></span>

<span data-ttu-id="12dd7-448">企業と製品に応じて最適なアプローチを使用してください。</span><span class="sxs-lookup"><span data-stu-id="12dd7-448">Use the approach that makes the most sense for your company and your product.</span></span>


## <a name="see-also"></a><span data-ttu-id="12dd7-449">関連項目</span><span class="sxs-lookup"><span data-stu-id="12dd7-449">See also</span></span>
- [<span data-ttu-id="12dd7-450">メディア再生</span><span class="sxs-lookup"><span data-stu-id="12dd7-450">Media playback</span></span>](media-playback.md)




