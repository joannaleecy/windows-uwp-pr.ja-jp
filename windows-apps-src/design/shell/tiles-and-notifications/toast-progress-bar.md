---
author: andrewleader
Description: Learn how to use a progress bar within your toast notification.
title: トーストの進行状況バーとデータ バインディング
label: Toast progress bar and data binding
template: detail.hbs
ms.author: mijacobs
ms.date: 12/7/2017
ms.topic: article
keywords: windows 10, uwp, トースト, 進行状況バー, トーストの進行状況バー, 通知, トーストのデータ バインディング
ms.localizationpriority: medium
ms.openlocfilehash: 6ca144f92676f87fcdade37b280c39640bc74624
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6979901"
---
# <a name="toast-progress-bar-and-data-binding"></a>トーストの進行状況バーとデータ バインディング

トースト通知内に進行状況バーを使用すると、ダウンロード、ビデオ レンダリング、一連の作業など、長い時間を要する処理の進行状況を表示できます。

> [!IMPORTANT]
> **Creators Update と Notifications ライブラリ 1.4.0 が必要**: トーストで進行状況バーを使用するには、SDK 15063 をターゲットとし、ビルド 15063 以上を実行する必要があります。 トーストのコンテンツ内に進行状況バーを作成するには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 1.4.0 以上を使用する必要があります。

トースト内の進行状況バーには、特定の値が表示されず、単に処理中であることをアニメーションのドットによって示す "不確定型" と、完了した処理の割合 (60% など) をバーの塗りつぶしによって示すを示す ”確定型” があります。

> **重要な API**: [NotificationData クラス](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationdata)、[ToastNotifier.Update メソッド](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotifier.Update)、[ToastNotification クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)

> [!NOTE]
> トースト通知での進行状況バーは、デスクトップでのみサポートされています。 他のデバイスでは、進行状況バーが通知から削除されます。

下の図では、確定型の進行状況バーと、それに対応するすべてのプロパティのラベルを示します。

<img alt="Toast with progress bar properties labeled" src="images/toast-progressbar-annotated.png" width="626"/>

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Title** | string または [BindableString](toast-schema.md#bindablestring) | false | タイトルの文字列 (オプション) を取得または設定します。 データ バインディングをサポートしています。 |
| **Value** | double または [AdaptiveProgressBarValue](toast-schema.md#adaptiveprogressbarvalue) か [BindableProgressBarValue](toast-schema.md#bindableprogressbarvalue) | false | 進行状況バーの値を取得または設定します。 データ バインディングをサポートしています。 既定値は 0 です。 0.0 ～ 1.0 の double 型または `AdaptiveProgressBarValue.Indeterminate` か `new BindableProgressBarValue("myProgressValue")` です。 |
| **ValueStringOverride** | string または [BindableString](toast-schema.md#bindablestring) | false | 割合を示す既定の文字列に代わって表示される文字列 (オプション) を取得または設定します。 これを指定しない場合は、"70%" などの文字が表示されます。 |
| **Status** | string または [BindableString](toast-schema.md#bindablestring) | true | 進行状況バーの下の左側に表示されるステータス文字列 (必須) を取得または設定します。 この文字列は、"ダウンロード中..." や "インストール中..." などのように、操作の状態を反映する必要があります。 |


以下では、上に示した通知を生成する方法を示します。

```csharp
ToastContent content = new ToastContent()
{
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Downloading your weekly playlist..."
                },
 
                new AdaptiveProgressBar()
                {
                    Title = "Weekly playlist",
                    Value = 0.6,
                    ValueStringOverride = "15/26 songs",
                    Status = "Downloading..."
                }
            }
        }
    }
};
```

```xml
<toast>
    <visual>
        <binding template="ToastGeneric">
            <text>Downloading your weekly playlist...</text>
            <progress
                title="Weekly playlist"
                value="0.6"
                valueStringOverride="15/26 songs"
                status="Downloading..."/>
        </binding>
    </visual>
</toast>
```

ただし、進行状況バーが実際にリアルタイムに機能するには、バーの値を動的に更新する必要があります。 これは、データ バインディングを使用してトーストを更新することで実現します。


## <a name="using-data-binding-to-update-a-toast"></a>データ バインディングを使用したトーストの更新

データ バインディングの使用は、以下の手順で行われます。

1. データ バインドしたフィールドを使用してトースト コンテンツを作成する
2. アプリの **ToastNotification** に **Tag** (およびオプションで **Group**) を割り当てる
3. アプリの **ToastNotification** で **Data** の初期値を定義する
4. トースト通知を送信する
5. **Tag** と **Group** を利用して、**Data** の値を新しい値に更新する

以下のコード スニペットでは、これらの手順 1 ～ 4 を示します。 次のスニペットは、トーストの **Data** の値を更新する方法を示しています。

```csharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;
 
public void SendUpdatableToastWithProgress()
{
    // Define a tag (and optionally a group) to uniquely identify the notification, in order update the notification data later;
    string tag = "weekly-playlist";
    string group = "downloads";
 
    // Construct the toast content with data bound fields
    var content = new ToastContent()
    {
        Visual = new ToastVisual()
        {
            BindingGeneric = new ToastBindingGeneric()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Downloading your weekly playlist..."
                    },
    
                    new AdaptiveProgressBar()
                    {
                        Title = "Weekly playlist",
                        Value = new BindableProgressBarValue("progressValue"),
                        ValueStringOverride = new BindableString("progressValueString"),
                        Status = new BindableString("progressStatus")
                    }
                }
            }
        }
    };
 
    // Generate the toast notification
    var toast = new ToastNotification(content.GetXml());
 
    // Assign the tag and group
    toast.Tag = tag;
    toast.Group = group;
 
    // Assign initial NotificationData values
    // Values must be of type string
    toast.Data = new NotificationData();
    toast.Data.Values["progressValue"] = "0.6";
    toast.Data.Values["progressValueString"] = "15/26 songs";
    toast.Data.Values["progressStatus"] = "Downloading...";
 
    // Provide sequence number to prevent out-of-order updates, or assign 0 to indicate "always update"
    toast.Data.SequenceNumber = 1;
 
    // Show the toast notification to the user
    ToastNotificationManager.CreateToastNotifier().Show(toast);
}
```

次に、**Data** の値を変更するときは、[**Update**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotifier.Update) メソッドを使用して、トーストのペイロード全体を再作成することなく、新しいデータを提供します。

```csharp
using Windows.UI.Notifications;
 
public void UpdateProgress()
{
    // Construct a NotificationData object;
    string tag = "weekly-playlist";
    string group = "downloads";
 
    // Create NotificationData and make sure the sequence number is incremented
    // since last update, or assign 0 for updating regardless of order
    var data = new NotificationData
    {
        SequenceNumber = 2
    };

    // Assign new values
    // Note that you only need to assign values that changed. In this example
    // we don't assign progressStatus since we don't need to change it
    data.Values["progressValue"] = "0.7";
    data.Values["progressValueString"] = "18/26 songs";

    // Update the existing notification's data by using tag/group
    ToastNotificationManager.CreateToastNotifier().Update(data, tag, group);
}
```

トースト全体を置き換えるのではなく、**Update** メソッドを使用することで、トースト通知がアクション センターの同じ位置に固定され、上下に移動することがなくなります。 進行状況バーが進む間、アクション センターで数秒ごとにトーストが最上位に移動すると、ユーザーに大きな混乱をもたらします。

**Update** メソッドは、列挙値 [**NotificationUpdateResult**](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationupdateresult) を返します。この列挙値により、更新が正常に完了したかどうかを確認でき、また通知が見つからなかった場合 (おそらく、ユーザーが通知を無視したためであり、その通知に対しては更新の送信を停止する必要があります) を確認できます。 進行状況バーの操作が完了するまで (ダウンロードが完了するなど)、別のトーストを表示しないことをお勧めします。


## <a name="elements-that-support-data-binding"></a>データ バインディングをサポートする要素
トースト通知の中で、データ バインディングをサポートする要素は次のとおりです。

- **AdaptiveProgress** のすべてのプロパティ
- 最上位レベルの **AdaptiveText** 要素の **Text** プロパティ


## <a name="update-or-replace-a-notification"></a>通知の更新と置換

Windows 10 以降では、同じ **Tag** と **Group** を使って新しいトーストを送信することで、いつでも通知を**置き換える**ことができます。 以下では、トーストの**置換**とトーストのデータの**更新**の違いを示します。

| | 置換 | 更新 |
| -- | -- | --
| **アクション センター内での位置** | 通知がアクション センターの一番上に移動します。 | アクション センター内の同じ位置に通知が固定されます。 |
| **コンテンツの変更** | トーストのすべてのコンテンツやレイアウトを完全に変更できます。 | データ バインディングをサポートするプロパティ (進行状況バーと最上位のテキスト) のみ変更できます。 |
| **ポップアップとしての再表示** | **SuppressPopup** を `false` に設定したままの場合は、トースト ポップアップとして再表示できます (true に設定するとサイレント モードでアクション センターに送信されます)。 | ポップアップとしては再表示されません。アクション センター内でトーストのデータがサイレント モードで更新されます。 |
| **ユーザーによる無視** | ユーザーがそれまでの通知を無視しても、置換トーストは常に送信されます。 | ユーザーがトーストを無視すると、トーストの更新は失敗します。 |

一般に、**更新が便利**なのは以下の場合です。

- 短時間で頻繁に変更され、ユーザーに最優先で注目される必要がない情報
- トーストのコンテンツに大きな変更がない場合 (50% ～ 65% 程度の変更率)

多くの場合、更新のシーケンスが完了した後 (ファイルのダウンロード後など) の最終手順では、置換の使用をお勧めします。理由は以下のとおりです。

- 最後の通知は大幅なレイアウト変更を伴う場合が多い (進行状況バーの削除や、新しいボタンの追加など)
- ユーザーにとってダウンロードの進行状況は重要でなく、保留中の進行状況通知を無視することがあるが、操作完了時にはポップアップ トーストによる通知を望んでいるため


## <a name="related-topics"></a>関連トピック

- [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-toast-progress-bar)
- [トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)