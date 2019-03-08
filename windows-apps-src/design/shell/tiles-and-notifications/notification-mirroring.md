---
Description: 通知がトースト通知でミラーリングを使用する方法について説明します。
title: 通知のミラーリング
label: Notification mirroring
template: detail.hbs
ms.date: 12/15/2017
ms.topic: article
keywords: windows 10, uwp, トースト, クラウド環境にあるアクション センター, 通知のミラーリング, 通知, クロス デバイス
ms.localizationpriority: medium
ms.openlocfilehash: dc870601159a80bc6d03a287fd19f082e968e09e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657317"
---
# <a name="notification-mirroring"></a>通知のミラーリング

クラウド環境にあるアクション センターが提供する通知のミラーリング機能を使用すると、電話宛ての通知を PC で表示できます。

> [!IMPORTANT]
> **Anniversary Update が必要です**:ミラーリングの通知が表示するには、14393 以上現在のビルドを実行する必要があります。 アプリ単位で通知のミラーリングをオプトアウトするには、SDK 14393 をターゲットに設定して、ミラーリング API にアクセスする必要があります。

通知のミラーリングと Cortana を併用すると、ユーザーは電話宛ての通知 (Windows Mobile および Android) を PC で便利に受け取って、対応することができます。 開発者は、通知のミラーリングを有効にするために、特に操作する必要はありません。ミラーリングは自動的に動作します。 ミラー化されたトーストでボタンをクリックすると (メッセージにすばやく応答する場合など)、電話にルーティングされて、バックグラウンド タスクまたはフォアグラウンド アプリが起動します。

<img alt="Notification mirroring diagram" src="images/toast-mirroring.gif" width="350"/>

開発者は、通知のミラーリングを 2 つの大きな特典がありますを取得します。ミラー化された通知が発生する、サービスで複数のユーザー エンゲージメントと、ユーザーは、Microsoft Store のデスクトップ アプリの検出にも役立ちます。 開発者が Windows 10 デスクトップ向けの優れた UWP アプリを提供していても、それがユーザーに認知されていないことがあります。 ユーザーが自分のスマート フォンからミラー化された通知を受信すると、ユーザーは、するため、UWP のデスクトップ アプリをインストールできる、Microsoft Store にトースト通知をクリックできます。

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

**既知の問題**:使用してミラーリングのプロパティを取得する、`ToastNotificationHistory.GetHistory()`の API には、既定値は常に返します (**許可**) 指定したオプションではなく。 しかし心配は要りません。誤っているのは取得された値のみで、それ以外はすべて正常に機能しています。

```csharp
var toast = new ToastNotification(xml)
{
    // Disable mirroring of this notification
    Mirroring = NotificationMirroring.Disabled
};
  
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


### <a name="as-a-developer-opt-out-completely"></a>開発者として、すべてをオプトアウトする

開発者によっては、開発するアプリで通知のミラーリングを完全にオプトアウトすることがあります。 ミラーリングからすべてのアプリができればと考えています中に簡単にオプトアウトします。1 回、次のメソッドを呼び出すだけと、アプリをオプトアウトします。たとえば、この呼び出しを配置内で、アプリのコンス トラクターで`App.xaml.cs`.

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