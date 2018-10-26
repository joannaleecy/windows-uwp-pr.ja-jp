---
author: andrewleader
Description: Learn how to create multi-step interactions in your notifications.
title: 更新の保留アクティブ化機能を備えたトースト
label: Toast with pending update activation
template: detail.hbs
ms.author: mijacobs
ms.date: 12/14/2017
ms.topic: article
keywords: windows 10, uwp, トースト, 更新の保留, pendingupdate, 複数ステップの対話, 複数ステップの対話機能
ms.localizationpriority: medium
ms.openlocfilehash: 4d21c96676eec1b8b1a1f4397880af937dd8f4b6
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5641008"
---
# <a name="toast-with-pending-update-activation"></a><span data-ttu-id="5bcec-103">更新の保留アクティブ化機能を備えたトースト</span><span class="sxs-lookup"><span data-stu-id="5bcec-103">Toast with pending update activation</span></span>

<span data-ttu-id="5bcec-104">**PendingUpdate** を使用すると、トースト通知で複数ステップの対話を作成できます。</span><span class="sxs-lookup"><span data-stu-id="5bcec-104">You can use **PendingUpdate** to create multi-step interactions in your toast notifications.</span></span> <span data-ttu-id="5bcec-105">たとえば、以下に示すように、後続のトーストがそれまでのトーストへの応答に依存する一連のトースト通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="5bcec-105">For example, as seen below, you can create a series of toasts where the subsequent toasts depend on responses from the previous toasts.</span></span>

![更新の保留を使ったトースト](images/toast-pendingupdate.gif)

> [!IMPORTANT]
> <span data-ttu-id="5bcec-107">**デスクトップ版の Fall Creators Update と Notifications ライブラリ 2.0.0 が必要**: 更新の保留が機能するには、デスクトップ版ビルド 16299 以上を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bcec-107">**Requires Desktop Fall Creators Update and 2.0.0 of Notifications library**: You must be running Desktop build 16299 or higher to see pending update work.</span></span> <span data-ttu-id="5bcec-108">ボタンに **PendingUpdate** を割り当てるには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 2.0.0 以上が必要です。</span><span class="sxs-lookup"><span data-stu-id="5bcec-108">You must use version 2.0.0 or higher of the [UWP Community Toolkit Notifications NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to assign **PendingUpdate** on your buttons.</span></span> <span data-ttu-id="5bcec-109">**PendingUpdate** はデスクトップでのみサポートされ、他のデバイスでは無視されます。</span><span class="sxs-lookup"><span data-stu-id="5bcec-109">**PendingUpdate** is only supported on Desktop and will be ignored on other devices.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="5bcec-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="5bcec-110">Prerequisites</span></span>

<span data-ttu-id="5bcec-111">この記事では、読者が以下に関する実用的な知識を持っていることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="5bcec-111">This article assumes a working knowledge of...</span></span>

- [<span data-ttu-id="5bcec-112">トースト コンテンツの作成方法</span><span class="sxs-lookup"><span data-stu-id="5bcec-112">Constructing toast content</span></span>](adaptive-interactive-toasts.md)
- [<span data-ttu-id="5bcec-113">トーストの送信とバックグラウンドのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="5bcec-113">Sending a toast and handling background activation</span></span>](send-local-toast.md)


## <a name="overview"></a><span data-ttu-id="5bcec-114">概要</span><span class="sxs-lookup"><span data-stu-id="5bcec-114">Overview</span></span>

<span data-ttu-id="5bcec-115">アクティブ化後の動作として "更新の保留" を使用するトースト通知を実装するには</span><span class="sxs-lookup"><span data-stu-id="5bcec-115">To implement a toast that uses pending update as its after activation behavior...</span></span>

1. <span data-ttu-id="5bcec-116">トーストのバックグラウンドのアクティブ化ボタンで、**AfterActivationBehavior** に **PendingUpdate** を指定する</span><span class="sxs-lookup"><span data-stu-id="5bcec-116">On your toast background activation buttons, specify an **AfterActivationBehavior** of **PendingUpdate**</span></span>

2. <span data-ttu-id="5bcec-117">トーストの送信時に **Tag** (および必要に応じて、**Group**) を割り当てる</span><span class="sxs-lookup"><span data-stu-id="5bcec-117">Assign a **Tag** (and optionally **Group**) when sending your toast</span></span>

3. <span data-ttu-id="5bcec-118">ユーザーがボタンをクリックすると、アプリのバックグラウンド タスクがアクティブ化され、トーストが更新を保留中の状態で画面に表示されたままになる</span><span class="sxs-lookup"><span data-stu-id="5bcec-118">When the user clicks your button, your background task will be activated, and the toast will be kept on-screen in a pending update state</span></span>

4. <span data-ttu-id="5bcec-119">バックグラウンド タスクで、同じ **Tag** と **Group** を使用して、新しいコンテンツを持つ新しいトーストを送信する</span><span class="sxs-lookup"><span data-stu-id="5bcec-119">In your background task, send a new toast with your new content, using the same **Tag** and **Group**</span></span>


## <a name="assign-pendingupdate"></a><span data-ttu-id="5bcec-120">PendingUpdate を割り当てる</span><span class="sxs-lookup"><span data-stu-id="5bcec-120">Assign PendingUpdate</span></span>

<span data-ttu-id="5bcec-121">バックグラウンドのアクティブ化ボタンで、**AfterActivationBehavior** を **PendingUpdate** に設定します。</span><span class="sxs-lookup"><span data-stu-id="5bcec-121">On your background activation buttons, set the **AfterActivationBehavior** to **PendingUpdate**.</span></span> <span data-ttu-id="5bcec-122">この設定は、**ActivationType** が **Background** のボタンでのみ有効であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="5bcec-122">Note that this only works for buttons that have an **ActivationType** of **Background**.</span></span>

```csharp
new ToastButton("Yes", "action=orderLunch")
{
    ActivationType = ToastActivationType.Background,

    ActivationOptions = new ToastActivationOptions()
    {
        AfterActivationBehavior = ToastAfterActivationBehavior.PendingUpdate
    }
}
```

```xml
<action
    content='Yes'
    arguments='action=orderLunch'
    activationType='background'
    afterActivationBehavior='pendingUpdate' />
```


## <a name="use-a-tag-on-the-notification"></a><span data-ttu-id="5bcec-123">通知で Tag を使用する</span><span class="sxs-lookup"><span data-stu-id="5bcec-123">Use a Tag on the notification</span></span>

<span data-ttu-id="5bcec-124">後で通知を置換するためには、通知に **Tag** (および必要に応じて、**Group**) を割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bcec-124">In order to later replace the notification, we have to assign the **Tag** (and optionally the **Group**) on the notification.</span></span>

```csharp
// Create the notification
var notif = new ToastNotification(content.GetXml())
{
    Tag = "lunch"
};

// And show it
ToastNotificationManager.CreateToastNotifier().Show(notif);
```


## <a name="replace-the-toast-with-new-content"></a><span data-ttu-id="5bcec-125">トーストを新しいコンテンツと置換する</span><span class="sxs-lookup"><span data-stu-id="5bcec-125">Replace the toast with new content</span></span>

<span data-ttu-id="5bcec-126">ユーザーがボタンをクリックすると、それに対してバックグラウンド タスクがトリガーされ、トーストを新しいコンテンツと置換する必要が生じます。</span><span class="sxs-lookup"><span data-stu-id="5bcec-126">In response to the user clicking your button, your background task gets triggered and you need to replace the toast with new content.</span></span> <span data-ttu-id="5bcec-127">トーストの置換は、同じ **Tag** と **Group** を使って新しいトーストを送信するだけで完了します。</span><span class="sxs-lookup"><span data-stu-id="5bcec-127">You replace the toast by simply sending a new toast with the same **Tag** and **Group**.</span></span>

<span data-ttu-id="5bcec-128">ボタンのクリックに対応してトーストを置換する場合、ユーザーは既にトーストと対話しているため、**オーディオをサイレント モードに設定**することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5bcec-128">We strongly recommend **setting the audio to silent** on replacements in response to a button click, since the user is already interacting with your toast.</span></span>

```csharp
// Generate new content
ToastContent content = new ToastContent()
{
    ...

    // We disable audio on all subsequent toasts since they appear right after the user
    // clicked something, so the user's attention is already captured
    Audio = new ToastAudio() { Silent = true }
};

// Create the new notification
var notif = new ToastNotification(content.GetXml())
{
    Tag = "lunch"
};

// And replace the old one with this one
ToastNotificationManager.CreateToastNotifier().Show(notif);
```


## <a name="related-topics"></a><span data-ttu-id="5bcec-129">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5bcec-129">Related topics</span></span>

- [<span data-ttu-id="5bcec-130">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="5bcec-130">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-toast-pending-update)
- [<span data-ttu-id="5bcec-131">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="5bcec-131">Send a local toast and handle activation</span></span>](send-local-toast.md)
- [<span data-ttu-id="5bcec-132">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="5bcec-132">Toast content documentation</span></span>](adaptive-interactive-toasts.md)
- [<span data-ttu-id="5bcec-133">トーストの進行状況バー</span><span class="sxs-lookup"><span data-stu-id="5bcec-133">Toast progress bar</span></span>](toast-progress-bar.md)