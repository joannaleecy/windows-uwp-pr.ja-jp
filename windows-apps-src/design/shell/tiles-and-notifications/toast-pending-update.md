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
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7441889"
---
# <a name="toast-with-pending-update-activation"></a>更新の保留アクティブ化機能を備えたトースト

**PendingUpdate** を使用すると、トースト通知で複数ステップの対話を作成できます。 たとえば、以下に示すように、後続のトーストがそれまでのトーストへの応答に依存する一連のトースト通知を作成できます。

![更新の保留を使ったトースト](images/toast-pendingupdate.gif)

> [!IMPORTANT]
> **デスクトップ版の Fall Creators Update と Notifications ライブラリ 2.0.0 が必要**: 更新の保留が機能するには、デスクトップ版ビルド 16299 以上を実行している必要があります。 ボタンに **PendingUpdate** を割り当てるには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 2.0.0 以上が必要です。 **PendingUpdate** はデスクトップでのみサポートされ、他のデバイスでは無視されます。


## <a name="prerequisites"></a>前提条件

この記事では、読者が以下に関する実用的な知識を持っていることを想定しています。

- [トースト コンテンツの作成方法](adaptive-interactive-toasts.md)
- [トーストの送信とバックグラウンドのアクティブ化の処理](send-local-toast.md)


## <a name="overview"></a>概要

アクティブ化後の動作として "更新の保留" を使用するトースト通知を実装するには

1. トーストのバックグラウンドのアクティブ化ボタンで、**AfterActivationBehavior** に **PendingUpdate** を指定する

2. トーストの送信時に **Tag** (および必要に応じて、**Group**) を割り当てる

3. ユーザーがボタンをクリックすると、アプリのバックグラウンド タスクがアクティブ化され、トーストが更新を保留中の状態で画面に表示されたままになる

4. バックグラウンド タスクで、同じ **Tag** と **Group** を使用して、新しいコンテンツを持つ新しいトーストを送信する


## <a name="assign-pendingupdate"></a>PendingUpdate を割り当てる

バックグラウンドのアクティブ化ボタンで、**AfterActivationBehavior** を **PendingUpdate** に設定します。 この設定は、**ActivationType** が **Background** のボタンでのみ有効であることに注意してください。

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


## <a name="use-a-tag-on-the-notification"></a>通知で Tag を使用する

後で通知を置換するためには、通知に **Tag** (および必要に応じて、**Group**) を割り当てる必要があります。

```csharp
// Create the notification
var notif = new ToastNotification(content.GetXml())
{
    Tag = "lunch"
};

// And show it
ToastNotificationManager.CreateToastNotifier().Show(notif);
```


## <a name="replace-the-toast-with-new-content"></a>トーストを新しいコンテンツと置換する

ユーザーがボタンをクリックすると、それに対してバックグラウンド タスクがトリガーされ、トーストを新しいコンテンツと置換する必要が生じます。 トーストの置換は、同じ **Tag** と **Group** を使って新しいトーストを送信するだけで完了します。

ボタンのクリックに対応してトーストを置換する場合、ユーザーは既にトーストと対話しているため、**オーディオをサイレント モードに設定**することを強くお勧めします。

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


## <a name="related-topics"></a>関連トピック

- [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-toast-pending-update)
- [ローカル トースト通知の送信](send-local-toast.md)
- [トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)
- [トーストの進行状況バー](toast-progress-bar.md)