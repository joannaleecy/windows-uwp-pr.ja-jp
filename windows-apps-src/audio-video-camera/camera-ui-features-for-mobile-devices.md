---
author: drewbatgit
ms.assetid: c43d4af3-9a1a-4eae-a137-1267c293c1b5
description: この記事では、モバイル デバイス上にのみある特殊カメラの UI 機能を活用する方法を示します。
title: モバイル デバイスのカメラ UI の機能
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 7b9db18d83c9d4811c446f90c40ff3e0044dccf2
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243039"
---
#<a name="camera-ui-features-for-mobile-devices"></a><span data-ttu-id="8833c-104">モバイル デバイスのカメラ UI の機能</span><span class="sxs-lookup"><span data-stu-id="8833c-104">Camera UI features for mobile devices</span></span>

<span data-ttu-id="8833c-105">この記事では、モバイル デバイス上にのみある特殊カメラの UI 機能を活用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="8833c-105">This article show you how to take advantage of special camera UI features that are only present on mobile devices.</span></span> 

## <a name="add-the-mobile-extension-to-your-project"></a><span data-ttu-id="8833c-106">モバイル拡張をプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="8833c-106">Add the mobile extension to your project</span></span> 

<span data-ttu-id="8833c-107">これらの機能を使用するには、ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK への参照をプロジェクトに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8833c-107">To use these features, you must add a reference to the Microsoft Mobile Extension SDK for Universal App Platform to your project.</span></span>

**<span data-ttu-id="8833c-108">ハードウェア カメラ ボタンのサポート用にモバイル拡張 SDK への参照を追加するには</span><span class="sxs-lookup"><span data-stu-id="8833c-108">To add a reference to the mobile extension SDK for hardware camera button support</span></span>**

1.  <span data-ttu-id="8833c-109">**ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="8833c-109">In **Solution Explorer**, right-click **References** and select **Add Reference**.</span></span>

2.  <span data-ttu-id="8833c-110">**[Windows ユニバーサル]** ノードを展開し、**[拡張機能]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="8833c-110">Expand the **Windows Universal** node and select **Extensions**.</span></span>

3.  <span data-ttu-id="8833c-111">**[Microsoft Mobile Extension SDK for Universal App Platform]**(ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK) チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="8833c-111">Select the **Microsoft Mobile Extension SDK for Universal App Platform** check box.</span></span>

## <a name="hide-the-status-bar"></a><span data-ttu-id="8833c-112">ステータス バーを非表示にする</span><span class="sxs-lookup"><span data-stu-id="8833c-112">Hide the status bar</span></span>

<span data-ttu-id="8833c-113">モバイル デバイスには、デバイスに関する状態情報をユーザーに通知する [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="8833c-113">Mobile devices have a [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) control that provides the user with status information about the device.</span></span> <span data-ttu-id="8833c-114">このコントロールが表示される領域は、画面上でメディア キャプチャ UI の表示に干渉する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8833c-114">This control takes up space on the screen that can interfere with the media capture UI.</span></span> <span data-ttu-id="8833c-115">[**HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339) を呼び出すことでステータス バーを非表示にできますが、呼び出しは、この API が利用可能かどうかを [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) メソッドで確認する条件ブロック内で行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="8833c-115">You can hide the status bar by calling [**HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339), but you must make this call from within a conditional block where you use the [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) method to determine if the API is available.</span></span> <span data-ttu-id="8833c-116">このメソッドは、ステータス バーをサポートするモバイル デバイスでのみ true を返します。</span><span class="sxs-lookup"><span data-stu-id="8833c-116">This method will only return true on mobile devices that support the status bar.</span></span> <span data-ttu-id="8833c-117">アプリの起動時や、またはカメラからプレビューを開始するときには、ステータス バーを非表示にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8833c-117">You should hide the status bar when your app launches or when you begin previewing from the camera.</span></span>

[!code-cs[<span data-ttu-id="8833c-118">HideStatusBar</span><span class="sxs-lookup"><span data-stu-id="8833c-118">HideStatusBar</span></span>](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHideStatusBar)]

<span data-ttu-id="8833c-119">アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、コントロールを再び表示できます。</span><span class="sxs-lookup"><span data-stu-id="8833c-119">When your app is shutting down or when the user navigates away from the media capture page of your app, you can make the control visible again.</span></span>

[!code-cs[<span data-ttu-id="8833c-120">ShowStatusBar</span><span class="sxs-lookup"><span data-stu-id="8833c-120">ShowStatusBar</span></span>](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetShowStatusBar)]

## <a name="use-the-hardware-camera-button"></a><span data-ttu-id="8833c-121">ハードウェア カメラ ボタンを使う</span><span class="sxs-lookup"><span data-stu-id="8833c-121">Use the hardware camera button</span></span>

<span data-ttu-id="8833c-122">一部のモバイル デバイスには、専用のハードウェア カメラ ボタンが用意されていることがあります。この仕様は、ユーザーによっては画面上のコントロールより好まれます。</span><span class="sxs-lookup"><span data-stu-id="8833c-122">Some mobile devices have a dedicated hardware camera button that some users prefer over an on-screen control.</span></span> <span data-ttu-id="8833c-123">このハードウェア カメラ ボタンが押されたときに通知を受け取るには、[**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) イベントのハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="8833c-123">To be notified when the hardware camera button is pressed, register a handler for the [**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) event.</span></span> <span data-ttu-id="8833c-124">この API を利用できるのはモバイル デバイスのみであるため、この場合も **IsTypePresent** を使用して、この API が現在のデバイスでサポートされているかどうかをアクセス前に確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8833c-124">Because this API is available on mobile devices only, you must again use the **IsTypePresent** to make sure the API is supported on the current device before attempting to access it.</span></span>

[!code-cs[<span data-ttu-id="8833c-125">PhoneUsing</span><span class="sxs-lookup"><span data-stu-id="8833c-125">PhoneUsing</span></span>](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPhoneUsing)]

[!code-cs[<span data-ttu-id="8833c-126">RegisterCameraButtonHandler</span><span class="sxs-lookup"><span data-stu-id="8833c-126">RegisterCameraButtonHandler</span></span>](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterCameraButtonHandler)]

<span data-ttu-id="8833c-127">**CameraPressed** イベントのハンドラーで、写真のキャプチャを開始できます。</span><span class="sxs-lookup"><span data-stu-id="8833c-127">In the handler for the **CameraPressed** event, you can initiate a photo capture.</span></span>

[!code-cs[<span data-ttu-id="8833c-128">CameraPressed</span><span class="sxs-lookup"><span data-stu-id="8833c-128">CameraPressed</span></span>](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCameraPressed)]

<span data-ttu-id="8833c-129">アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、ハードウェア ボタンのハンドラーを登録解除します。</span><span class="sxs-lookup"><span data-stu-id="8833c-129">When your app is shutting down or the user moves away from the media capture page of your app, unregister the hardware button handler.</span></span>

[!code-cs[<span data-ttu-id="8833c-130">UnregisterCameraButtonHandler</span><span class="sxs-lookup"><span data-stu-id="8833c-130">UnregisterCameraButtonHandler</span></span>](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterCameraButtonHandler)]

> [!NOTE]
> <span data-ttu-id="8833c-131">この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。</span><span class="sxs-lookup"><span data-stu-id="8833c-131">This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="8833c-132">Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブ ドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8833c-132">If you're developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).</span></span>                                                                                   <span data-ttu-id="8833c-133">|</span><span class="sxs-lookup"><span data-stu-id="8833c-133">|</span></span>

## <a name="related-topics"></a><span data-ttu-id="8833c-134">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8833c-134">Related topics</span></span>

* [<span data-ttu-id="8833c-135">カメラ</span><span class="sxs-lookup"><span data-stu-id="8833c-135">Camera</span></span>](camera.md)
* [<span data-ttu-id="8833c-136">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="8833c-136">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)





