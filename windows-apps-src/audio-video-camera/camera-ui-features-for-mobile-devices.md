---
author: drewbatgit
ms.assetid: c43d4af3-9a1a-4eae-a137-1267c293c1b5
description: この記事では、モバイル デバイス上にのみある特殊カメラの UI 機能を活用する方法を示します。
title: モバイル デバイスのカメラ UI の機能
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 062ca589b2a63db1f56ada4e2df4f99bc7f8b0fb
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5862021"
---
#<a name="camera-ui-features-for-mobile-devices"></a><span data-ttu-id="33f47-104">モバイル デバイスのカメラ UI の機能</span><span class="sxs-lookup"><span data-stu-id="33f47-104">Camera UI features for mobile devices</span></span>

<span data-ttu-id="33f47-105">この記事では、モバイル デバイス上にのみある特殊カメラの UI 機能を活用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="33f47-105">This article show you how to take advantage of special camera UI features that are only present on mobile devices.</span></span> 

## <a name="add-the-mobile-extension-to-your-project"></a><span data-ttu-id="33f47-106">モバイル拡張をプロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="33f47-106">Add the mobile extension to your project</span></span> 

<span data-ttu-id="33f47-107">これらの機能を使用するには、ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK への参照をプロジェクトに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33f47-107">To use these features, you must add a reference to the Microsoft Mobile Extension SDK for Universal App Platform to your project.</span></span>

**<span data-ttu-id="33f47-108">ハードウェア カメラ ボタンのサポート用にモバイル拡張 SDK への参照を追加するには</span><span class="sxs-lookup"><span data-stu-id="33f47-108">To add a reference to the mobile extension SDK for hardware camera button support</span></span>**

1.  <span data-ttu-id="33f47-109">**ソリューション エクスプローラー**で、**[参照設定]** を右クリックし、**[参照の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="33f47-109">In **Solution Explorer**, right-click **References** and select **Add Reference**.</span></span>

2.  <span data-ttu-id="33f47-110">**[Windows ユニバーサル]** ノードを展開し、**[拡張機能]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="33f47-110">Expand the **Windows Universal** node and select **Extensions**.</span></span>

3.  <span data-ttu-id="33f47-111">**[Microsoft Mobile Extension SDK for Universal App Platform]**(ユニバーサル アプリ プラットフォーム用 Microsoft Mobile Extension SDK) チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="33f47-111">Select the **Microsoft Mobile Extension SDK for Universal App Platform** check box.</span></span>

## <a name="hide-the-status-bar"></a><span data-ttu-id="33f47-112">ステータス バーを非表示にする</span><span class="sxs-lookup"><span data-stu-id="33f47-112">Hide the status bar</span></span>

<span data-ttu-id="33f47-113">モバイル デバイスには、デバイスに関する状態情報をユーザーに通知する [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="33f47-113">Mobile devices have a [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) control that provides the user with status information about the device.</span></span> <span data-ttu-id="33f47-114">このコントロールが表示される領域は、画面上でメディア キャプチャ UI の表示に干渉する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33f47-114">This control takes up space on the screen that can interfere with the media capture UI.</span></span> <span data-ttu-id="33f47-115">[**HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339) を呼び出すことでステータス バーを非表示にできますが、呼び出しは、この API が利用可能かどうかを [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) メソッドで確認する条件ブロック内で行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="33f47-115">You can hide the status bar by calling [**HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339), but you must make this call from within a conditional block where you use the [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) method to determine if the API is available.</span></span> <span data-ttu-id="33f47-116">このメソッドは、ステータス バーをサポートするモバイル デバイスでのみ true を返します。</span><span class="sxs-lookup"><span data-stu-id="33f47-116">This method will only return true on mobile devices that support the status bar.</span></span> <span data-ttu-id="33f47-117">アプリの起動時や、またはカメラからプレビューを開始するときには、ステータス バーを非表示にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="33f47-117">You should hide the status bar when your app launches or when you begin previewing from the camera.</span></span>

[!code-cs[HideStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHideStatusBar)]

<span data-ttu-id="33f47-118">アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、コントロールを再び表示できます。</span><span class="sxs-lookup"><span data-stu-id="33f47-118">When your app is shutting down or when the user navigates away from the media capture page of your app, you can make the control visible again.</span></span>

[!code-cs[ShowStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetShowStatusBar)]

## <a name="use-the-hardware-camera-button"></a><span data-ttu-id="33f47-119">ハードウェア カメラ ボタンを使う</span><span class="sxs-lookup"><span data-stu-id="33f47-119">Use the hardware camera button</span></span>

<span data-ttu-id="33f47-120">一部のモバイル デバイスには、専用のハードウェア カメラ ボタンが用意されていることがあります。この仕様は、ユーザーによっては画面上のコントロールより好まれます。</span><span class="sxs-lookup"><span data-stu-id="33f47-120">Some mobile devices have a dedicated hardware camera button that some users prefer over an on-screen control.</span></span> <span data-ttu-id="33f47-121">このハードウェア カメラ ボタンが押されたときに通知を受け取るには、[**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) イベントのハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="33f47-121">To be notified when the hardware camera button is pressed, register a handler for the [**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) event.</span></span> <span data-ttu-id="33f47-122">この API を利用できるのはモバイル デバイスのみであるため、この場合も **IsTypePresent** を使用して、この API が現在のデバイスでサポートされているかどうかをアクセス前に確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33f47-122">Because this API is available on mobile devices only, you must again use the **IsTypePresent** to make sure the API is supported on the current device before attempting to access it.</span></span>

[!code-cs[PhoneUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPhoneUsing)]

[!code-cs[RegisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterCameraButtonHandler)]

<span data-ttu-id="33f47-123">**CameraPressed** イベントのハンドラーで、写真のキャプチャを開始できます。</span><span class="sxs-lookup"><span data-stu-id="33f47-123">In the handler for the **CameraPressed** event, you can initiate a photo capture.</span></span>

[!code-cs[CameraPressed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCameraPressed)]

<span data-ttu-id="33f47-124">アプリをシャットダウンするときや、ユーザーがアプリのメディア キャプチャ ページから移動するときは、ハードウェア ボタンのハンドラーを登録解除します。</span><span class="sxs-lookup"><span data-stu-id="33f47-124">When your app is shutting down or the user moves away from the media capture page of your app, unregister the hardware button handler.</span></span>

[!code-cs[UnregisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterCameraButtonHandler)]

## <a name="related-topics"></a><span data-ttu-id="33f47-125">関連トピック</span><span class="sxs-lookup"><span data-stu-id="33f47-125">Related topics</span></span>

* [<span data-ttu-id="33f47-126">カメラ</span><span class="sxs-lookup"><span data-stu-id="33f47-126">Camera</span></span>](camera.md)
* [<span data-ttu-id="33f47-127">MediaCapture を使った基本的な写真、ビデオ、およびオーディオのキャプチャ</span><span class="sxs-lookup"><span data-stu-id="33f47-127">Basic photo, video, and audio capture with MediaCapture</span></span>](basic-photo-video-and-audio-capture-with-MediaCapture.md)





