---
author: andrewleader
Description: Learn how to use notification mirroring on your toast notifications.
title: 通知のミラーリング
label: Notification mirroring
template: detail.hbs
ms.author: mijacobs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, クラウド環境にあるアクション センター, 通知のミラーリング, 通知, クロス デバイス
ms.localizationpriority: medium
ms.openlocfilehash: c36b5ffcbb016e5b89fa1c960a7493767192296c
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6470493"
---
# <a name="notification-mirroring"></a>通知のミラーリング

クラウド環境にあるアクション センターが提供する通知のミラーリング機能を使用すると、電話宛ての通知を PC で表示できます。

> [!IMPORTANT]
> **Anniversary Update が必要**: 通知のミラーリングを使用するには、ビルド 14393 以上を実行する必要があります。 アプリ単位で通知のミラーリングをオプトアウトするには、SDK 14393 をターゲットに設定して、ミラーリング API にアクセスする必要があります。

通知のミラーリングと Cortana を併用すると、ユーザーは電話宛ての通知 (Windows Mobile および Android) を PC で便利に受け取って、対応することができます。 開発者は、通知のミラーリングを有効にするために、特に操作する必要はありません。ミラーリングは自動的に動作します。 ミラー化されたトーストでボタンをクリックすると (メッセージにすばやく応答する場合など)、電話にルーティングされて、バックグラウンド タスクまたはフォアグラウンド アプリが起動します。

<img alt="Notification mirroring diagram" src="images/toast-mirroring.gif" width="350"/>

開発者は、通知のミラーリングから 2 つの主な利点を取得する: ミラー化された通知が発生すると、サービスでは、複数のユーザー エンゲージメントと、ユーザーが、Microsoft Store のデスクトップ アプリを検出も役立ちます。 開発者が Windows 10 デスクトップ向けの優れた UWP アプリを提供していても、それがユーザーに認知されていないことがあります。 ユーザーが自分の電話からミラー化された通知を受信するとき、ユーザーは UWP デスクトップ アプリをインストールする、Microsoft Store にトースト通知をクリックことができます。

ミラーリングは、Windows Phone と Android の両方で動作します。 通知のミラーリングを使用するには、ユーザーが電話とデスクトップの両方で Cortana にログインする必要があります。


## <a name="what-if-the-app-is-installed-on-both-devices"></a>両方のデバイスでアプリがインストールされている場合

ユーザーの PC にアプリが既にインストールされている場合、通知が重複して表示されないように、ミラー化された電話の通知が自動的にミュートされます。 ミラー化された通知は、次の条件に基いて自動的にミュートされます。

1. **同じ表示名または同じ PFN** (パッケージ ファミリ名) のアプリが PC 上に存在する
2. その PC アプリがトースト通知を送信した

PC アプリがトーストをまだ送信していない場合は、ユーザーがまだ PC を起動していない可能性があるため、引き続き電話に通知が表示されます。


## <a name="how-to-opt-out-of-mirroring"></a>ミラーリングをオプトアウトする方法

UWP アプリ開発者、企業、ユーザーは、通知のミラーリングを無効にすることができます。

> [!NOTE]
> ミラーリングを無効にすると、[ユニバーサル無視](universal-dismiss.md)も無効になります。


### <a name="as-a-developer-opt-out-an-individual-notification"></a>開発者として、個別の通知をオプトアウトする

たとえば、デバイス固有の通知を他のデバイスにミラーリングすることはあまり意味がありません。 特定の通知についてミラーリングを無効にするには、トースト通知の **Mirroring**プロパティを設定します。 現時点では、このミラーリング プロパティは、ローカルの通知にのみ設定できます (WNS プッシュ通知の送信時には設定できません)。

**既知の問題**: `ToastNotificationHistory.GetHistory()` API 経由で Mirroring プロパティを取得すると、指定したオプションではなく、常に既定値 (**Allowed**) が返されます。 しかし心配は要りません。誤っているのは取得された値のみで、それ以外はすべて正常に機能しています。

```csharp
var toast = new ToastNotification(xml)
{
    // Disable mirroring of this notification
    Mirroring = NotificationMirroring.Disabled
};
  
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


### <a name="as-a-developer-opt-out-completely"></a>開発者として、すべてをオプトアウトする

開発者によっては、開発するアプリで通知のミラーリングを完全にオプトアウトすることがあります。 ミラーリングの使用はすべてのアプリにとってメリットがありますが、オプトアウトすることも簡単です。次のメソッドを 1 回呼び出すだけで、アプリがオプトアウトされます。この呼び出しは、たとえば、アプリの `App.xaml.cs` 内のコンストラクターに配置できます。

```csharp
public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;
 
    // Disable notification mirroring for entire app
    ToastNotificationManager.ConfigureNotificationMirroring(NotificationMirroring.Disabled);
}
```


### <a name="as-an-enterprise-how-do-i-opt-out"></a>企業としてオプトアウトする

企業は、通知のミラーリングを完全に無効にできます。 これには、単純にグループ ポリシーを編集して、通知のミラーリングをオフにします。


### <a name="as-a-user-how-do-i-opt-out"></a>ユーザーとしてオプトアウトする

ユーザーは個別のアプリでオプトアウトすることも、機能を無効にして完全にオプトアウトすることもできます。 特定のアプリの通知をデスクトップにミラーリングしない場合は、その特定のアプリについてのみ無効にすることができます。 このオプションは、電話と PC の両方の Cortana の設定にあります。