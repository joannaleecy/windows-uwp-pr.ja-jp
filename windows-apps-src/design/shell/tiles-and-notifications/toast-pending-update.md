---
Description: 通知で複数のステップの相互作用を作成する方法について説明します。
title: 更新の保留アクティブ化機能を備えたトースト
label: Toast with pending update activation
template: detail.hbs
ms.date: 12/14/2017
ms.topic: article
keywords: windows 10, uwp, トースト, 更新の保留, pendingupdate, 複数ステップの対話, 複数ステップの対話機能
ms.localizationpriority: medium
ms.openlocfilehash: b1574ee2913bd2889af204aae1089dc170df95b8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57648557"
---
# <a name="toast-with-pending-update-activation"></a><span data-ttu-id="5dced-104">更新の保留アクティブ化機能を備えたトースト</span><span class="sxs-lookup"><span data-stu-id="5dced-104">Toast with pending update activation</span></span>

<span data-ttu-id="5dced-105">**PendingUpdate** を使用すると、トースト通知で複数ステップの対話を作成できます。</span><span class="sxs-lookup"><span data-stu-id="5dced-105">You can use **PendingUpdate** to create multi-step interactions in your toast notifications.</span></span> <span data-ttu-id="5dced-106">たとえば、以下に示すように、後続のトーストがそれまでのトーストへの応答に依存する一連のトースト通知を作成できます。</span><span class="sxs-lookup"><span data-stu-id="5dced-106">For example, as seen below, you can create a series of toasts where the subsequent toasts depend on responses from the previous toasts.</span></span>

![更新の保留を使ったトースト](images/toast-pendingupdate.gif)

> [!IMPORTANT]
> <span data-ttu-id="5dced-108">**デスクトップの Fall Creators Update と 2.0.0 の通知ライブラリが必要です**:16299 以上保留中の更新プログラムの作業を現在のデスクトップ ビルドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5dced-108">**Requires Desktop Fall Creators Update and 2.0.0 of Notifications library**: You must be running Desktop build 16299 or higher to see pending update work.</span></span> <span data-ttu-id="5dced-109">ボタンに **PendingUpdate** を割り当てるには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 2.0.0 以上が必要です。</span><span class="sxs-lookup"><span data-stu-id="5dced-109">You must use version 2.0.0 or higher of the [UWP Community Toolkit Notifications NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to assign **PendingUpdate** on your buttons.</span></span> <span data-ttu-id="5dced-110">**PendingUpdate** はデスクトップでのみサポートされ、他のデバイスでは無視されます。</span><span class="sxs-lookup"><span data-stu-id="5dced-110">**PendingUpdate** is only supported on Desktop and will be ignored on other devices.</span></span>


## <a name="prerequisites"></a><span data-ttu-id="5dced-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="5dced-111">Prerequisites</span></span>

<span data-ttu-id="5dced-112">この記事では、読者が以下に関する実用的な知識を持っていることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="5dced-112">This article assumes a working knowledge of...</span></span>

- [<span data-ttu-id="5dced-113">トーストのコンテンツを構築します。</span><span class="sxs-lookup"><span data-stu-id="5dced-113">Constructing toast content</span></span>](adaptive-interactive-toasts.md)
- [<span data-ttu-id="5dced-114">トーストを送信して、バック グラウンドのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="5dced-114">Sending a toast and handling background activation</span></span>](send-local-toast.md)


## <a name="overview"></a><span data-ttu-id="5dced-115">概要</span><span class="sxs-lookup"><span data-stu-id="5dced-115">Overview</span></span>

<span data-ttu-id="5dced-116">アクティブ化後の動作として "更新の保留" を使用するトースト通知を実装するには</span><span class="sxs-lookup"><span data-stu-id="5dced-116">To implement a toast that uses pending update as its after activation behavior...</span></span>

1. <span data-ttu-id="5dced-117">トーストのバックグラウンドのアクティブ化ボタンで、**AfterActivationBehavior** に **PendingUpdate** を指定する</span><span class="sxs-lookup"><span data-stu-id="5dced-117">On your toast background activation buttons, specify an **AfterActivationBehavior** of **PendingUpdate**</span></span>

2. <span data-ttu-id="5dced-118">トーストの送信時に **Tag** (および必要に応じて、**Group**) を割り当てる</span><span class="sxs-lookup"><span data-stu-id="5dced-118">Assign a **Tag** (and optionally **Group**) when sending your toast</span></span>

3. <span data-ttu-id="5dced-119">ユーザーがボタンをクリックすると、アプリのバックグラウンド タスクがアクティブ化され、トーストが更新を保留中の状態で画面に表示されたままになる</span><span class="sxs-lookup"><span data-stu-id="5dced-119">When the user clicks your button, your background task will be activated, and the toast will be kept on-screen in a pending update state</span></span>

4. <span data-ttu-id="5dced-120">バックグラウンド タスクで、同じ **Tag** と **Group** を使用して、新しいコンテンツを持つ新しいトーストを送信する</span><span class="sxs-lookup"><span data-stu-id="5dced-120">In your background task, send a new toast with your new content, using the same **Tag** and **Group**</span></span>


## <a name="assign-pendingupdate"></a><span data-ttu-id="5dced-121">PendingUpdate を割り当てる</span><span class="sxs-lookup"><span data-stu-id="5dced-121">Assign PendingUpdate</span></span>

<span data-ttu-id="5dced-122">バックグラウンドのアクティブ化ボタンで、**AfterActivationBehavior** を **PendingUpdate** に設定します。</span><span class="sxs-lookup"><span data-stu-id="5dced-122">On your background activation buttons, set the **AfterActivationBehavior** to **PendingUpdate**.</span></span> <span data-ttu-id="5dced-123">この設定は、**ActivationType** が **Background** のボタンでのみ有効であることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="5dced-123">Note that this only works for buttons that have an **ActivationType** of **Background**.</span></span>

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


## <a name="use-a-tag-on-the-notification"></a><span data-ttu-id="5dced-124">通知で Tag を使用する</span><span class="sxs-lookup"><span data-stu-id="5dced-124">Use a Tag on the notification</span></span>

<span data-ttu-id="5dced-125">後で通知を置換するためには、通知に **Tag** (および必要に応じて、**Group**) を割り当てる必要があります。</span><span class="sxs-lookup"><span data-stu-id="5dced-125">In order to later replace the notification, we have to assign the **Tag** (and optionally the **Group**) on the notification.</span></span>

```csharp
// Create the notification
var notif = new ToastNotification(content.GetXml())
{
    Tag = "lunch"
};

// And show it
ToastNotificationManager.CreateToastNotifier().Show(notif);
```


## <a name="replace-the-toast-with-new-content"></a><span data-ttu-id="5dced-126">トーストを新しいコンテンツと置換する</span><span class="sxs-lookup"><span data-stu-id="5dced-126">Replace the toast with new content</span></span>

<span data-ttu-id="5dced-127">ユーザーがボタンをクリックすると、それに対してバックグラウンド タスクがトリガーされ、トーストを新しいコンテンツと置換する必要が生じます。</span><span class="sxs-lookup"><span data-stu-id="5dced-127">In response to the user clicking your button, your background task gets triggered and you need to replace the toast with new content.</span></span> <span data-ttu-id="5dced-128">トーストの置換は、同じ **Tag** と **Group** を使って新しいトーストを送信するだけで完了します。</span><span class="sxs-lookup"><span data-stu-id="5dced-128">You replace the toast by simply sending a new toast with the same **Tag** and **Group**.</span></span>

<span data-ttu-id="5dced-129">ボタンのクリックに対応してトーストを置換する場合、ユーザーは既にトーストと対話しているため、**オーディオをサイレント モードに設定**することを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5dced-129">We strongly recommend **setting the audio to silent** on replacements in response to a button click, since the user is already interacting with your toast.</span></span>

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


## <a name="related-topics"></a><span data-ttu-id="5dced-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5dced-130">Related topics</span></span>

- [<span data-ttu-id="5dced-131">GitHub の完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="5dced-131">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-toast-pending-update)
- [<span data-ttu-id="5dced-132">ローカル ハンドルとトーストのアクティブ化を送信します。</span><span class="sxs-lookup"><span data-stu-id="5dced-132">Send a local toast and handle activation</span></span>](send-local-toast.md)
- [<span data-ttu-id="5dced-133">トーストのコンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="5dced-133">Toast content documentation</span></span>](adaptive-interactive-toasts.md)
- [<span data-ttu-id="5dced-134">トーストの進行状況バー</span><span class="sxs-lookup"><span data-stu-id="5dced-134">Toast progress bar</span></span>](toast-progress-bar.md)