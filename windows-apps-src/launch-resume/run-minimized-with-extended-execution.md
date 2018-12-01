---
description: 延長実行を使用して、アプリが最小化されているときにアプリの実行を保持する方法について説明します。
title: 延長実行を使ってアプリの中断を延期する
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, 延長実行, 最小化, ExtendedExecutionSession, バックグラウンド タスク, アプリケーション ライフサイクル, ロック画面
ms.assetid: e6a6a433-5550-4a19-83be-bbc6168fe03a
ms.localizationpriority: medium
ms.openlocfilehash: 8cc67a7593a340ada8f807fc0fb0c1b846c6f05b
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8336322"
---
# <a name="postpone-app-suspension-with-extended-execution"></a><span data-ttu-id="3d464-104">延長実行を使ってアプリの中断を延期する</span><span class="sxs-lookup"><span data-stu-id="3d464-104">Postpone app suspension with extended execution</span></span>

<span data-ttu-id="3d464-105">この記事では、アプリが最小化されている状態またはロック画面で実行できるように、延長実行を使用してアプリが中断されるタイミングを延期する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3d464-105">This article shows you how to use extended execution to postpone when your app is suspended so that it can run while minimized or under the lock screen.</span></span>

<span data-ttu-id="3d464-106">ユーザーがアプリを最小化するか別のアプリなどに切り替えると、アプリは中断状態になります。</span><span class="sxs-lookup"><span data-stu-id="3d464-106">When the user minimizes or switches away from an app it is put into a suspended state.</span></span>  <span data-ttu-id="3d464-107">アプリのメモリは維持されますが、コードは実行されません。</span><span class="sxs-lookup"><span data-stu-id="3d464-107">Its memory is maintained, but its code does not run.</span></span> <span data-ttu-id="3d464-108">これは、視覚的なユーザー インターフェイスを備えたすべての OS エディションに当てはまります。</span><span class="sxs-lookup"><span data-stu-id="3d464-108">This is true across all OS Editions with a visual user interface.</span></span> <span data-ttu-id="3d464-109">アプリの中断状態について詳しくは、「[アプリケーションのライフサイクル](app-lifecycle.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d464-109">For more details about when your app is suspended, see [Application Lifecycle](app-lifecycle.md).</span></span> 

<span data-ttu-id="3d464-110">ユーザーがアプリから移動して離れるとき、またはアプリが最小化されているときに、中断するのではなく、実行を維持する必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-110">There are cases where an app may need to keep running, rather than be suspended, when the user navigates away from the app, or while it is minimized.</span></span> <span data-ttu-id="3d464-111">たとえば、ユーザーが他のアプリを使用するために移動しても、ステップ カウント アプリは実行を維持し、ステップを追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-111">For example, a step counting app needs to keep running and tracking steps even when the user navigates away to use other apps.</span></span> 

<span data-ttu-id="3d464-112">アプリが実行し続ける必要がある場合、OS によって実行を維持することも、アプリから実行の継続を要求することもできます。</span><span class="sxs-lookup"><span data-stu-id="3d464-112">If an app needs to keep running, either the OS can keep it running, or it can request to keep running.</span></span> <span data-ttu-id="3d464-113">たとえば、バックグラウンドでオーディオを再生している場合、「[バックグラウンドでのメディアの再生](../audio-video-camera/background-audio.md)」の手順に従うと、OS によってアプリの実行を延長できます。</span><span class="sxs-lookup"><span data-stu-id="3d464-113">For example, when playing audio in the background, the OS can keep an app running longer if you follow these steps for [Background Media Playback](../audio-video-camera/background-audio.md).</span></span> <span data-ttu-id="3d464-114">この手順に従わない場合は、手動で実行延長を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-114">Otherwise, you must manually request more time.</span></span> <span data-ttu-id="3d464-115">バックグラウンド実行にかかる時間は数分である可能性がありますが、いつでも失効されたセッションを処理できるようにしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-115">The amount of time you may get to perform background execution may be several minutes but you must be prepared to handle the session being revoked at any time.</span></span> <span data-ttu-id="3d464-116">このようなアプリケーションのライフ サイクル時間の制約は、アプリの実行時にデバッガーで無効になっています。</span><span class="sxs-lookup"><span data-stu-id="3d464-116">These application lifecycle time constraints are disabled while the app is running under a debugger.</span></span> <span data-ttu-id="3d464-117">このような理由から、デバッガーで、または Visual Studio で利用可能なライフサイクル イベントを使用して、実行されていないときにアプリの中断を延期するための延長実行やその他のツールをテストすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="3d464-117">For this reason it is important to test Extended Execution and other tools for postponing app suspension while not running under a debugger or by using the Lifecycle Events available in Visual Studio.</span></span> 
 
<span data-ttu-id="3d464-118">バックグラウンドで操作を完了するまで実行の延長を要求するには、[ExtendedExecutionSession](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionsession.aspx) を作成します。</span><span class="sxs-lookup"><span data-stu-id="3d464-118">Create an [ExtendedExecutionSession](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionsession.aspx) to request more time to complete an operation in the background.</span></span> <span data-ttu-id="3d464-119">作成する **ExtendedExecutionSession** の種類は、作成時に提供する [ExtendedExecutionReason](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionreason.aspx) によって決まります。</span><span class="sxs-lookup"><span data-stu-id="3d464-119">The kind of **ExtendedExecutionSession** you create is determined by the  [ExtendedExecutionReason](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionreason.aspx) that you provide when you create it.</span></span> <span data-ttu-id="3d464-120">**ExtendedExecutionReason** 列挙値には、**Unspecified、LocationTracking**、および **SavingData** の 3 種類があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-120">There are three **ExtendedExecutionReason** enum values: **Unspecified, LocationTracking** and **SavingData**.</span></span> <span data-ttu-id="3d464-121">常に 1 つの **ExtendedExecutionSession** のみを要求できます。ある承認されたセッション要求が現在アクティブのときに別のセッションを作成しようとすると、**ExtendedExecutionSession** コンストラクターから例外 0x8007139F がスローされ、グループまたはリソースが要求された操作を実行するために適切な状態にないことが示されます。</span><span class="sxs-lookup"><span data-stu-id="3d464-121">Only one **ExtendedExecutionSession** can be requested at any time; attempting to create another session while an approved session request is currently active will cause exception 0x8007139F to be thrown from the **ExtendedExecutionSession** constructor stating that the group or resource is not in the correct state to perform the requested operation.</span></span> <span data-ttu-id="3d464-122">[ExtendedExecutionForegroundSession](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession.aspx) と [ExtendedExecutionForegroundReason](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundreason.aspx) は、制限された機能が必要で、ストア アプリケーションで利用できないため、使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="3d464-122">Do not use [ExtendedExecutionForegroundSession](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession.aspx) and [ExtendedExecutionForegroundReason](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundreason.aspx); they require restricted capabilities and are not available for use in Store applications.</span></span>

## <a name="run-while-minimized"></a><span data-ttu-id="3d464-123">最小化状態での実行</span><span class="sxs-lookup"><span data-stu-id="3d464-123">Run while minimized</span></span>

<span data-ttu-id="3d464-124">延長実行を使用できる 2 つのケースがあります。</span><span class="sxs-lookup"><span data-stu-id="3d464-124">There are two cases where extended execution can be used:</span></span>
- <span data-ttu-id="3d464-125">アプリケーションが実行状態にあるとき、通常のフォアグラウンド実行中の任意の時点。</span><span class="sxs-lookup"><span data-stu-id="3d464-125">At any point during regular foreground execution, while the application is in the running state.</span></span>
- <span data-ttu-id="3d464-126">アプリケーションが中断イベント (OS がアプリを中断状態に移行しようとしている) をアプリケーションの中断イベント ハンドラーで受け取った後。</span><span class="sxs-lookup"><span data-stu-id="3d464-126">After the application has received a suspending event (the OS is about to move the app to the suspended state) in the application’s suspending event handler.</span></span>

<span data-ttu-id="3d464-127">これら 2 つのケースのコードは同じですが、それぞれのケースでアプリケーションが少し異なる方法で動作します。</span><span class="sxs-lookup"><span data-stu-id="3d464-127">The code for these two cases is the same, but the application behaves a little differently in each.</span></span> <span data-ttu-id="3d464-128">最初のケースでは、通常は中断をトリガーするイベントが発生したときでもアプリケーションは実行状態にとどまります (たとえば、ユーザーがアプリケーションから移動するとき)。</span><span class="sxs-lookup"><span data-stu-id="3d464-128">In the first case, the application stays in the running state, even if an event that normally would trigger suspension occurs (for example, the user navigating away from the application).</span></span> <span data-ttu-id="3d464-129">延長実行が有効であるときは、アプリケーションが中断イベントを受け取ることはありません。</span><span class="sxs-lookup"><span data-stu-id="3d464-129">The application will never receive a suspending event while the execution extension is in effect.</span></span> <span data-ttu-id="3d464-130">拡張子が破棄されると、アプリケーションがもう一度中断の対象になります。</span><span class="sxs-lookup"><span data-stu-id="3d464-130">When the extension is disposed, the application becomes eligible for suspension again.</span></span>

<span data-ttu-id="3d464-131">2 つ目のケースでは、アプリケーションが中断状態に移行している場合に、実行の期間中、中断状態にとどまります。</span><span class="sxs-lookup"><span data-stu-id="3d464-131">In the second case, if the application is transitioning to the suspended state, it will stay in a suspending state for the period of the extension.</span></span> <span data-ttu-id="3d464-132">実行の有効期限が切れると、アプリケーションは特に通知することなく中断状態になります。</span><span class="sxs-lookup"><span data-stu-id="3d464-132">Once the extension expires, the application enters the suspended state without further notification.</span></span>

<span data-ttu-id="3d464-133">メディア処理、プロジェクトのコンパイル、またはネットワーク接続の維持などのシナリオで、アプリがバックグラウンドに移行する前に追加の時間を要求する **ExtendedExecutionSession** を作成するときには、**ExtendedExecutionReason.Unspecified** を使用します。</span><span class="sxs-lookup"><span data-stu-id="3d464-133">Use **ExtendedExecutionReason.Unspecified** when you create an **ExtendedExecutionSession** to request additional time before your app moves into the background for scenarios such as media processing, project compilation, or keeping a network connection alive.</span></span> <span data-ttu-id="3d464-134">Windows 10 のデスクトップ エディション (Home、Pro、Enterprise、および Education) を実行しているデスクトップ デバイスでは、最小化状態のときにアプリの中断を回避するには、この方法を使用します。</span><span class="sxs-lookup"><span data-stu-id="3d464-134">On desktop devices running Windows 10 for desktop editions (Home, Pro, Enterprise, and Education), this is the approach to use if an app needs to avoid being suspended while it is minimized.</span></span>

<span data-ttu-id="3d464-135">実行時間の長い操作を開始するときに延長を要求して、**Suspending** 状態の遷移を遅らせます。要求しない場合、アプリはバックグラウンドになるとこの状態に遷移します。</span><span class="sxs-lookup"><span data-stu-id="3d464-135">Request the extension when starting a long running operation in order to defer the **Suspending** state transition that otherwise occurs when the app moves into the background.</span></span> <span data-ttu-id="3d464-136">デスクトップ デバイスでは、**ExtendedExecutionReason.Unspecified** によって作成された延長実行セッションには、バッテリを考えた時間制限があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-136">On desktop devices, extended execution sessions created with **ExtendedExecutionReason.Unspecified** have a battery-aware time limit.</span></span> <span data-ttu-id="3d464-137">デバイスが電源コンセントにつながれている場合は、延長実行の時間の長さに制限はありません。</span><span class="sxs-lookup"><span data-stu-id="3d464-137">If the device is connected to wall power, there is no limit to the length of the extended execution time period.</span></span> <span data-ttu-id="3d464-138">デバイスがバッテリで動作している場合は、延長実行はバックグラウンドで最大 10 分実行できます。</span><span class="sxs-lookup"><span data-stu-id="3d464-138">If the device is on battery power, the extended execution time period can run up to ten minutes in the background.</span></span>

<span data-ttu-id="3d464-139">タブレットまたはノート PC を使用している場合も、**[アプリによるバッテリーの使用]** 設定の **[アプリにバックグラウンド タスクの実行を許可する]** オプションを選択していると、バッテリーを消費しますが、同じように長時間実行できます。</span><span class="sxs-lookup"><span data-stu-id="3d464-139">A tablet or laptop user can get the same long running behavior--at the expense of battery life--when the **Allow the app to run background tasks** option is selected in **Battery usage by app** settings.</span></span> <span data-ttu-id="3d464-140">ノート PC でこのオプションにアクセスするには、**[設定]** > **[システム]** > **[バッテリー]** > **[アプリによるバッテリーの使用]** (バッテリ残量のパーセント値の下にあるリンク) の順に選択し、アプリを選択します。次に、**[Windows で管理]** をオフにし、**[アプリにバックグラウンド タスクの実行を許可する]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="3d464-140">(To find this option on a laptop, go to **Settings** > **System** > **Battery** > **Battery usage by App** (the link under the percent of battery power remaining) > select an app > turn off **Managed By Windows** > select **Allow app to run background tasks**.</span></span>  

<span data-ttu-id="3d464-141">どの OS エディションでも、デバイスがコネクト スタンバイ状態になると、このような延長実行セッションは停止します。</span><span class="sxs-lookup"><span data-stu-id="3d464-141">On all OS editions this kind of extended execution session stops when the device enters Connected Standby.</span></span> <span data-ttu-id="3d464-142">Windows 10 Mobile を実行しているモバイル デバイスでは、画面がオンである間だけ、このような延長実行セッションが実行されます。</span><span class="sxs-lookup"><span data-stu-id="3d464-142">On mobile devices running Windows 10 Mobile, this kind of extended execution session will run as long as the screen is on.</span></span> <span data-ttu-id="3d464-143">画面がオフになると、デバイスは直ちに省電力のコネクト スタンバイ状態になります。</span><span class="sxs-lookup"><span data-stu-id="3d464-143">When the screen turns off, the device immediately attempts to enter the low-power Connected-Standby mode.</span></span> <span data-ttu-id="3d464-144">デスクトップ デバイスでは、ロック画面が表示されても、延長実行セッションは続行されます。</span><span class="sxs-lookup"><span data-stu-id="3d464-144">On desktop devices, the session will continue running if the lock screen appears.</span></span> <span data-ttu-id="3d464-145">画面がオフになった後も、しばらくの間、デバイスはコネクト スタンバイ状態になりません。</span><span class="sxs-lookup"><span data-stu-id="3d464-145">The device does not enter Connected Standby for a period of time after the screen turns off.</span></span> <span data-ttu-id="3d464-146">Xbox OS エディションでは、ユーザーが既定を変更していない限り、1 時間後にデバイスはコネクト スタンバイ状態になります。</span><span class="sxs-lookup"><span data-stu-id="3d464-146">On the Xbox OS Edition, the device enters Connect Standby after one hour unless the user changes the default.</span></span>

## <a name="track-the-users-location"></a><span data-ttu-id="3d464-147">ユーザーの位置情報の追跡</span><span class="sxs-lookup"><span data-stu-id="3d464-147">Track the user's location</span></span>

<span data-ttu-id="3d464-148">アプリが定期的に [GeoLocator](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx) による位置情報を記録する必要がある場合は、**ExtendedExecutionSession** を作成するときに、**ExtendedExecutionReason.LocationTracking** を指定します。</span><span class="sxs-lookup"><span data-stu-id="3d464-148">Specify **ExtendedExecutionReason.LocationTracking** when you create an **ExtendedExecutionSession** if your app needs to regularly log the location from the [GeoLocator](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx).</span></span> <span data-ttu-id="3d464-149">ユーザーの位置情報を定期的に監視する必要があるフィットネス対応アプリやナビ アプリでは、この ExtendedExecutionReason 設定を使用します。</span><span class="sxs-lookup"><span data-stu-id="3d464-149">Apps for fitness tracking and navigation that need to regularly monitor the user's location and should use this reason.</span></span>

<span data-ttu-id="3d464-150">位置情報追跡のための延長実行セッションは、モバイル デバイスの画面がロックされている間も含め、必要なだけの時間で実行できます。</span><span class="sxs-lookup"><span data-stu-id="3d464-150">A location tracking extended execution session can run as long as needed, including while the screen is locked on a mobile device.</span></span> <span data-ttu-id="3d464-151">ただし、このようなセッションは 1 台のデバイスにつき、1 セッションしか保持できません。</span><span class="sxs-lookup"><span data-stu-id="3d464-151">However, there can only be one such session running per device.</span></span> <span data-ttu-id="3d464-152">位置情報追跡のための延長実行セッションは、フォアグラウンドでしか要求できず、アプリは **Running** 状態である必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-152">A location tracking extended execution session can only be requested in the foreground, and the app must be in the **Running** state.</span></span> <span data-ttu-id="3d464-153">これにより、アプリが位置情報追跡の延長セッションを開始したことをユーザーに認識されるようにしています。</span><span class="sxs-lookup"><span data-stu-id="3d464-153">This ensures that the user is aware that the app has initiated an extended location tracking session.</span></span> <span data-ttu-id="3d464-154">ただし、位置情報追跡のための延長実行セッションを要求せずに、バックグラウンド タスクかアプリ サービスを使用することで、アプリがバックグラウンドにある場合も、GeoLocator を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3d464-154">It is still possible to use the GeoLocator while the app is in the background by using a background task, or an app service, without requesting a location tracking extended execution session.</span></span>

## <a name="save-critical-data-locally"></a><span data-ttu-id="3d464-155">重要なデータのローカルでの保存</span><span class="sxs-lookup"><span data-stu-id="3d464-155">Save Critical Data Locally</span></span>

<span data-ttu-id="3d464-156">アプリが終了される前にデータを保存しておかないと、データが失われ、否定的なユーザー エクスペリエンスにつながる場合は、**ExtendedExecutionSession** を作成するときに **ExtendedExecutionReason.SavingData** を指定して、ユーザー データを保存します。</span><span class="sxs-lookup"><span data-stu-id="3d464-156">Specify **ExtendedExecutionReason.SavingData** when you create an **ExtendedExecutionSession** to save user data in the case where not saving the data before the app is terminated will result in data loss and a negative user experience.</span></span>

<span data-ttu-id="3d464-157">データのアップロードまたはダウンロードのために、このようなセッションを使用して、アプリの実行時間を延長しないでください。</span><span class="sxs-lookup"><span data-stu-id="3d464-157">Don't use this kind of session to extend the lifetime of an app to upload or download data.</span></span> <span data-ttu-id="3d464-158">データのアップロードが必要な場合は、[バックグラウンド転送](https://msdn.microsoft.com/windows/uwp/networking/background-transfers)を要求するか、**MaintenanceTrigger** を登録して、AC 電源を利用できるときに、転送を処理してください。</span><span class="sxs-lookup"><span data-stu-id="3d464-158">If you need to upload data, request a [background transfer](https://msdn.microsoft.com/windows/uwp/networking/background-transfers) or register a **MaintenanceTrigger** to handle the transfer when AC power is available.</span></span> <span data-ttu-id="3d464-159">**ExtendedExecutionReason.SavingData** 延長セッションを要求できるのは、アプリがフォアグラウンドで **Running**状態であるか、バックグラウンドで**Suspending** 状態である場合です。</span><span class="sxs-lookup"><span data-stu-id="3d464-159">A **ExtendedExecutionReason.SavingData** extended execution session can be requested either when the app is in the foreground and in the **Running** state, or in the background and in the **Suspending** state.</span></span>

<span data-ttu-id="3d464-160">**Suspending** 状態は、アプリのライフサイクル中で、アプリが終了する前にアプリが作業を実行できる最後のチャンスです。</span><span class="sxs-lookup"><span data-stu-id="3d464-160">The **Suspending** state is the last opportunity during the app lifecycle that an app can do work before the app is terminated.</span></span> <span data-ttu-id="3d464-161">**ExtendedExecutionReason.SavingData** は、**Suspending** 状態で要求できる、**ExtendedExecutionSession** の唯一の種類です。</span><span class="sxs-lookup"><span data-stu-id="3d464-161">**ExtendedExecutionReason.SavingData** is the only type of **ExtendedExecutionSession** that can be requested in the **Suspending** state.</span></span> <span data-ttu-id="3d464-162">アプリが **Suspending** 状態のときに **ExtendedExecutionReason.SavingData** 延長実行セッションを要求すると、注意が必要な問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-162">Requesting a **ExtendedExecutionReason.SavingData** extended execution session while the app is in the **Suspending** state creates a potential issue that you should be aware of.</span></span> <span data-ttu-id="3d464-163">**Suspending** 状態のときに延長実行セッションが要求され、ユーザーがアプリの再起動を要求した場合、起動に時間がかかるように感じられる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-163">If an extended execution session is requested while in the **Suspending** state, and the user requests the app be launched again, it may appear to take a long time to launch.</span></span> <span data-ttu-id="3d464-164">これは、延長実行セッションの時間が経過しないと、アプリの以前のインスタンスを終了して、アプリの新しいインスタンスを起動することができないためです。</span><span class="sxs-lookup"><span data-stu-id="3d464-164">This is because the extended execution session time period must complete before the old instance of the app can be closed and a new instance of the app can be launched.</span></span> <span data-ttu-id="3d464-165">ユーザー状態が失われることを確実に防ぐため、起動にかかる時間が犠牲になります。</span><span class="sxs-lookup"><span data-stu-id="3d464-165">Launch performance time is sacrificed in order to guarantee that user state is not lost.</span></span>

## <a name="request-disposal-and-revocation"></a><span data-ttu-id="3d464-166">要求、破棄、および失効</span><span class="sxs-lookup"><span data-stu-id="3d464-166">Request, disposal, and revocation</span></span>

<span data-ttu-id="3d464-167">延長実行セッションには、要求、破棄、および失効の 3 つの基本的な操作があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-167">There are three fundamental interactions with an extended execution session: the request, disposal, and revocation.</span></span>  <span data-ttu-id="3d464-168">次のコード スニペットは、要求を行う例を示しています。</span><span class="sxs-lookup"><span data-stu-id="3d464-168">Making the request is modeled in the following code snippet.</span></span>

### <a name="request"></a><span data-ttu-id="3d464-169">要求</span><span class="sxs-lookup"><span data-stu-id="3d464-169">Request</span></span>

```csharp
var newSession = new ExtendedExecutionSession();
newSession.Reason = ExtendedExecutionReason.Unspecified;
newSession.Revoked += SessionRevoked;
ExtendedExecutionResult result = await newSession.RequestExtensionAsync();

switch (result)
{
    case ExtendedExecutionResult.Allowed:
        DoLongRunningWork();
        break;

    default:
    case ExtendedExecutionResult.Denied:
        DoShortRunningWork();
        break;
}
```
[<span data-ttu-id="3d464-170">コード サンプルを見る</span><span class="sxs-lookup"><span data-stu-id="3d464-170">See code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario1_UnspecifiedReason.xaml.cs#L81-L110)  

<span data-ttu-id="3d464-171">**RequestExtensionAsync** を呼び出すと、ユーザーがアプリのバックグラウンド アクティビティを承認しているかどうかと、バックグラウンドで実行できるだけのリソースがシステムにあるかどうかについて、オペレーティング システムが確認されます。</span><span class="sxs-lookup"><span data-stu-id="3d464-171">Calling **RequestExtensionAsync** checks with the operating system to see if the user has approved background activity for the app and whether the system has the available resources to enable background execution.</span></span> <span data-ttu-id="3d464-172">アプリで常に 1 つのセッションのみが承認されるため、**RequestExtensionAsync** への追加の呼び出しでセッションが拒否されます。</span><span class="sxs-lookup"><span data-stu-id="3d464-172">Only one session will be approved for an app at any time, causing additional calls to **RequestExtensionAsync** to result in the session being denied.</span></span>

<span data-ttu-id="3d464-173">あらかじめ [BackgroundExecutionManager](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) をチェックして、アプリがバックグラウンドで実行できるかどうかを示すユーザー設定である [BackgroundAccessStatus](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundaccessstatus.aspx?f=255&MSPPError=-2147217396) の状態を特定することもできます。</span><span class="sxs-lookup"><span data-stu-id="3d464-173">You can check the [BackgroundExecutionManager](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) beforehand to determine the [BackgroundAccessStatus](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundaccessstatus.aspx?f=255&MSPPError=-2147217396), which is the user setting that indicates whether your app can run in the background or not.</span></span> <span data-ttu-id="3d464-174">これらのユーザー設定について詳しくは、「[Background Activity and Energy Awareness (バックグラウンド アクティビティと省電力対策)](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#XWK8mEgWD7JHvC10.97)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d464-174">To learn more about these user settings see [Background Activity and Energy Awareness](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#XWK8mEgWD7JHvC10.97).</span></span>

<span data-ttu-id="3d464-175">**ExtendedExecutionReason** は、アプリがバックグラウンドで実行する操作を示します。</span><span class="sxs-lookup"><span data-stu-id="3d464-175">The **ExtendedExecutionReason** indicates the operation your app is performing in the background.</span></span> <span data-ttu-id="3d464-176">**Description** の文字列は、アプリがその操作を実行しなければならない理由を説明する、人間が読める文字列です。</span><span class="sxs-lookup"><span data-stu-id="3d464-176">The **Description** string is a human-readable string that explains why your app needs to perform the operation.</span></span> <span data-ttu-id="3d464-177">この文字列はユーザーに表示されませんが、Windows の将来のリリースで利用可能になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-177">This string is not presented to the user, but may be made available in a future release of Windows.</span></span> <span data-ttu-id="3d464-178">ユーザーまたはシステムによって、アプリをこれ以上バックグラウンドで実行できないと判断された場合に、延長実行セッションが適切に停止されるように、**Revoked** イベント ハンドラーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-178">The **Revoked** event handler is required so that an extended execution session can halt gracefully if the user, or the system, decides that the app can no longer run in the background.</span></span>

### <a name="revoked"></a><span data-ttu-id="3d464-179">失効</span><span class="sxs-lookup"><span data-stu-id="3d464-179">Revoked</span></span>

<span data-ttu-id="3d464-180">アプリにアクティブな延長実行セッションがあり、フォアグラウンド アプリケーションでリソースが必要であるため、システムがバックグラウンド アクティビティを停止する必要がある場合、セッションは失効されます。</span><span class="sxs-lookup"><span data-stu-id="3d464-180">If an app has an active extended execution session and the system requires background activity to halt because a foreground application requires the resources, then the session is revoked.</span></span> <span data-ttu-id="3d464-181">最初に **Revoked** イベント ハンドラーが発生しないと、延長実行セッションが途中で終了されることはありません。</span><span class="sxs-lookup"><span data-stu-id="3d464-181">An extended execution session time period is never terminated without first firing the **Revoked** event handler.</span></span>

<span data-ttu-id="3d464-182">**ExtendedExecutionReason.SavingData** 延長実行セッションに対して **Revoked** イベントが発生すると、アプリには実行中の操作を完了し、**Suspending** を終了するために 1 秒間が与えられます。</span><span class="sxs-lookup"><span data-stu-id="3d464-182">When the **Revoked** event is fired for an **ExtendedExecutionReason.SavingData** extended execution session, the app has one second to complete the operation it was performing and finish **Suspending**.</span></span>

<span data-ttu-id="3d464-183">実行時間の制限に達した、バックグラウンドの割り当て電力の上限に達した、ユーザーがフォアグラウンドで新しいアプリを開けるように、メモリを再利用する必要があるなど、失効が発生する理由はさまざまです。</span><span class="sxs-lookup"><span data-stu-id="3d464-183">Revocation can occur for many reasons: an execution time limit was reached, a background energy quota was reached, or memory needs to be reclaimed in order for the user to open a new app in the foreground.</span></span>

<span data-ttu-id="3d464-184">Revoked イベント ハンドラーの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3d464-184">Here is an example of a Revoked event handler:</span></span>

```cs
private async void SessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
{
    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        switch (args.Reason)
        {
            case ExtendedExecutionRevokedReason.Resumed:
                rootPage.NotifyUser("Extended execution revoked due to returning to foreground.", NotifyType.StatusMessage);
                break;

            case ExtendedExecutionRevokedReason.SystemPolicy:
                rootPage.NotifyUser("Extended execution revoked due to system policy.", NotifyType.StatusMessage);
                break;
        }

        EndExtendedExecution();
    });
}
```
[<span data-ttu-id="3d464-185">コード サンプルを見る</span><span class="sxs-lookup"><span data-stu-id="3d464-185">See code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario1_UnspecifiedReason.xaml.cs#L124-L141)

### <a name="dispose"></a><span data-ttu-id="3d464-186">破棄</span><span class="sxs-lookup"><span data-stu-id="3d464-186">Dispose</span></span>

<span data-ttu-id="3d464-187">最後の手順では、延長実行セッションを破棄します。</span><span class="sxs-lookup"><span data-stu-id="3d464-187">The final step is to dispose of the extended execution session.</span></span> <span data-ttu-id="3d464-188">延長実行セッションや、その他の大量にメモリを消費するアセットは、破棄することをお勧めします。破棄しないと、セッションの終了を待機している間にアプリが使用する電力が、アプリの割り当て電力に対してカウントされます。</span><span class="sxs-lookup"><span data-stu-id="3d464-188">You want to dispose of the session, and any other memory intensive assets, because otherwise the energy used by the app while it is waiting for the session to close will be counted against the app's energy quota.</span></span> <span data-ttu-id="3d464-189">アプリの割り当て電力の消費をできるだけ防ぐには、アプリが速やかに **Suspended** 状態に移行できるよう、セッションの作業が終了したらセッションを破棄することが重要です。</span><span class="sxs-lookup"><span data-stu-id="3d464-189">To preserve as much of the energy quota for the app as possible, it is important to dispose of the session when you are done with your work for the session so that the app can move into the **Suspended** state more quickly.</span></span>

<span data-ttu-id="3d464-190">失効イベントの発生を待たず、自分でセッションを破棄することで、アプリの割り当て電力の消費を抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="3d464-190">Disposing of the session yourself, rather than waiting for the revocation event, reduces your app's energy quota usage.</span></span> <span data-ttu-id="3d464-191">つまり、今後のセッションで、使用できる割り当て電力をより多く確保できているため、アプリをバックグラウンドで実行できる時間が長くなります。</span><span class="sxs-lookup"><span data-stu-id="3d464-191">This means that your app will be permitted to run in the background longer in future sessions because you'll have more energy quota available to do so.</span></span> <span data-ttu-id="3d464-192">**Dispose** メソッドを呼び出せるように、操作の終了まで、**ExtendedExecutionSession** オブジェクトへの参照は保持しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-192">You must maintain a reference to the **ExtendedExecutionSession** object until the end of the operation so that you can call its **Dispose** method.</span></span>

<span data-ttu-id="3d464-193">延長実行セッションを破棄するスニペット次に示します。</span><span class="sxs-lookup"><span data-stu-id="3d464-193">A snippet that disposes an extended execution session follows:</span></span>

```cs
void ClearExtendedExecution(ExtendedExecutionSession session)
{
    if (session != null)
    {
        session.Revoked -= SessionRevoked;
        session.Dispose();
        session = null;
    }
}
```
[<span data-ttu-id="3d464-194">コード サンプルを見る</span><span class="sxs-lookup"><span data-stu-id="3d464-194">See code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario1_UnspecifiedReason.xaml.cs#L49-L63)

<span data-ttu-id="3d464-195">アプリのアクティブな **ExtendedExecutionSession** は、一度に 1 つしか保持できません。</span><span class="sxs-lookup"><span data-stu-id="3d464-195">An app can only have one **ExtendedExecutionSession** active at a time.</span></span> <span data-ttu-id="3d464-196">多くのアプリでは、ストレージ、ネットワーク、またはネットワーク ベースのサービスなどのリソースにアクセスする必要がある複雑な操作を完了するために、非同期タスクを使用します。</span><span class="sxs-lookup"><span data-stu-id="3d464-196">Many apps use asynchronous tasks in order to complete complex operations that require access to resources such as storage, network, or network-based services.</span></span> <span data-ttu-id="3d464-197">複数の非同期タスクを完了する必要がある操作の場合、各タスクの状態が、**ExtendedExecutionSession** を破棄し、アプリの中断を許可できる状態になっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-197">If an operation requires multiple asynchronous tasks to complete, then the state of each of these tasks must be accounted for before disposing the **ExtendedExecutionSession** and allowing the app to be suspended.</span></span> <span data-ttu-id="3d464-198">それには、まだ実行中のタスクの数の参照カウントを行い、その値がゼロになるまでセッションを破棄しないでおく必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d464-198">This requires reference counting the number of tasks that are still running, and not disposing of the session until that value reaches zero.</span></span>

<span data-ttu-id="3d464-199">以下に、延長実行セッション中に複数のタスクを管理するコード例を示します。</span><span class="sxs-lookup"><span data-stu-id="3d464-199">Here is some example code for managing multiple tasks during an extended execution session period.</span></span> <span data-ttu-id="3d464-200">アプリでこれを使用する方法の詳細については、以下にリンクが示されているコード サンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="3d464-200">For more information on how to use this in your app please see the code sample linked below:</span></span>

```cs
static class ExtendedExecutionHelper
{
    private static ExtendedExecutionSession session = null;
    private static int taskCount = 0;

    public static bool IsRunning
    {
        get
        {
            if (session != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static async Task<ExtendedExecutionResult> RequestSessionAsync(ExtendedExecutionReason reason, TypedEventHandler<object, ExtendedExecutionRevokedEventArgs> revoked, String description)
    {
        // The previous Extended Execution must be closed before a new one can be requested.       
        ClearSession();

        var newSession = new ExtendedExecutionSession();
        newSession.Reason = reason;
        newSession.Description = description;
        newSession.Revoked += SessionRevoked;

        // Add a revoked handler provided by the app in order to clean up an operation that had to be halted prematurely
        if(revoked != null)
        {
            newSession.Revoked += revoked;
        }

        ExtendedExecutionResult result = await newSession.RequestExtensionAsync();

        switch (result)
        {
            case ExtendedExecutionResult.Allowed:
                session = newSession;
                break;
            default:
            case ExtendedExecutionResult.Denied:
                newSession.Dispose();
                break;
        }
        return result;
    }

    public static void ClearSession()
    {
        if (session != null)
        {
            session.Dispose();
            session = null;
        }

        taskCount = 0;
    }

    public static Deferral GetExecutionDeferral()
    {
        if (session == null)
        {
            throw new InvalidOperationException("No extended execution session is active");
        }

        taskCount++;
        return new Deferral(OnTaskCompleted);
    }

    private static void OnTaskCompleted()
    {
        if (taskCount > 0)
        {
            taskCount--;
        }
        
        //If there are no more running tasks than end the extended lifetime by clearing the session
        if (taskCount == 0 && session != null)
        {
            ClearSession();
        }
    }

    private static void SessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
    {
        //The session has been prematurely revoked due to system constraints, ensure the session is disposed
        if (session != null)
        {
            session.Dispose();
            session = null;
        }
        
        taskCount = 0;
    }
}
```
[<span data-ttu-id="3d464-201">コード サンプルを見る</span><span class="sxs-lookup"><span data-stu-id="3d464-201">See code sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario4_MultipleTasks.xaml.cs)

## <a name="ensure-that-your-app-uses-resources-well"></a><span data-ttu-id="3d464-202">アプリがリソースを適切に使用するための処理</span><span class="sxs-lookup"><span data-stu-id="3d464-202">Ensure that your app uses resources well</span></span>

<span data-ttu-id="3d464-203">アプリがバックグラウンドに移行した後も、実行を継続できるためには、アプリのメモリや電力使用を調整することが重要です。</span><span class="sxs-lookup"><span data-stu-id="3d464-203">Tuning your app's memory and energy use is key to ensuring that the operating system will allow your app to continue to run when it is no longer the foreground app.</span></span> <span data-ttu-id="3d464-204">[メモリ管理 API](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) を使用して、アプリが使用しているメモリ量を確認します。</span><span class="sxs-lookup"><span data-stu-id="3d464-204">Use the [Memory Management APIs](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) to see how much memory your app is using.</span></span> <span data-ttu-id="3d464-205">アプリが使用するメモリ量が多くなるほど、別のアプリがフォアグラウンドのときに、アプリの実行を OS が維持することは難しくなります。</span><span class="sxs-lookup"><span data-stu-id="3d464-205">The more memory your app uses, the harder it is for the OS to keep your app running when another app is in the foreground.</span></span> <span data-ttu-id="3d464-206">アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="3d464-206">The user is ultimately in control of all background activity that your app can perform and has visibility on the impact your app has on battery use.</span></span>

<span data-ttu-id="3d464-207">[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="3d464-207">Use [BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) to determine if the user has decided that your app’s background activity should be limited.</span></span> <span data-ttu-id="3d464-208">バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="3d464-208">Be aware of your battery usage and only run in the background when it is necessary to complete an action that the user wants.</span></span>

## <a name="see-also"></a><span data-ttu-id="3d464-209">関連項目</span><span class="sxs-lookup"><span data-stu-id="3d464-209">See also</span></span>

[<span data-ttu-id="3d464-210">延長実行のサンプル</span><span class="sxs-lookup"><span data-stu-id="3d464-210">Extended Execution Sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ExtendedExecution)  
[<span data-ttu-id="3d464-211">アプリケーションのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="3d464-211">Application Lifecycle</span></span>](https://msdn.microsoft.com/windows/uwp/launch-resume/app-lifecycle)  
<span data-ttu-id="3d464-212">[アプリ ライフサイクル - バックグラウンド タスクと延長実行によるアプリ稼働状態の維持](https://msdn.microsoft.com/en-us/magazine/mt590969.aspx)
[バック グラウンド メモリの管理](https://msdn.microsoft.com/windows/uwp/launch-resume/reduce-memory-usage)</span><span class="sxs-lookup"><span data-stu-id="3d464-212">[App Lifecycle - Keep Apps Alive with Background Tasks and Extended Execution](https://msdn.microsoft.com/en-us/magazine/mt590969.aspx)
[Background Memory Management](https://msdn.microsoft.com/windows/uwp/launch-resume/reduce-memory-usage)</span></span>  
[<span data-ttu-id="3d464-213">バックグラウンド転送</span><span class="sxs-lookup"><span data-stu-id="3d464-213">Background Transfers</span></span>](https://msdn.microsoft.com/windows/uwp/networking/background-transfers)  
[<span data-ttu-id="3d464-214">バッテリー対策とバックグラウンド アクティビティ</span><span class="sxs-lookup"><span data-stu-id="3d464-214">Battery Awareness and Background Activity</span></span>](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#I2bkQ6861TRpbRjr.97)  
[<span data-ttu-id="3d464-215">MemoryManager クラス</span><span class="sxs-lookup"><span data-stu-id="3d464-215">MemoryManager class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)  
[<span data-ttu-id="3d464-216">バックグラウンドでのメディアの再生</span><span class="sxs-lookup"><span data-stu-id="3d464-216">Play Media in the Background</span></span>](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)  