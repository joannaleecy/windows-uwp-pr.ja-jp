---
Description: ヘッダーを使用して、アクション センターで、トースト通知を視覚的にグループ化する方法について説明します。
title: トースト ヘッダー
label: Toast headers
template: detail.hbs
ms.date: 12/7/2017
ms.topic: article
keywords: windows 10, uwp, トースト, ヘッダー, トースト ヘッダー, 通知, トーストのグループ化, アクション センター
ms.localizationpriority: medium
ms.openlocfilehash: 361b161b8cf323596a3b07665819300c78f1dcc5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612107"
---
# <a name="toast-headers"></a>トースト ヘッダー

通知に対してトースト ヘッダーを使用して、アクション センター内の互いに関連する複数の通知を視覚的にグループ化することができます。

> [!IMPORTANT]
> **デスクトップ Creators Update と通知ライブラリの 1.4.0 必要**:デスクトップ ビルド 15063 以上トーストを表示するヘッダーを実行する必要があります。 トーストのコンテンツ内にヘッダーを作成するには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 1.4.0 以上を使用する必要があります。 ヘッダーはデスクトップでのみサポートされます。

以下に示すように、このグループの会話は "Camping!!" という 1 つのヘッダーの下にまとめられています。 会話内の個々のメッセージは、同じトースト ヘッダーを共有する別個のトースト通知です。

<img alt="Toasts with header" src="images/toast-headers-action-center.png" width="396"/>

通知は、カテゴリに基づいて視覚的にグループ化することもできます。たとえば、搭乗便のリマインダー、荷物の追跡などのカテゴリーを使用できます。

## <a name="add-a-header-to-a-toast"></a>トーストへのヘッダーの追加

トースト通知にヘッダーを追加する方法は次のとおりです。

> [!NOTE]
> ヘッダーはデスクトップでのみサポートされます。 ヘッダーをサポートしないデバイスでは、ヘッダーが無視されます。

```csharp
ToastContent toastContent = new ToastContent()
{
    Header = new ToastHeader()
    {
        Id = "6289",
        Title = "Camping!!",
        Arguments = "action=openConversation&id=6289",
    },

    Visual = new ToastVisual() { ... }
};
```

```xml
<toast>

    <header
        id="6289"
        title="Camping!!"
        arguments="action=openConversation&amp;id=6289"/>

    <visual>
        ...
    </visual>

</toast>
```

以上をまとめると次のようになります。

1. **Header** を **ToastContent** に追加します。
2. 必要な **Id**、**Title**、**Arguments** プロパティを割り当てます。
3. 通知を送信します ([詳細情報](send-local-toast.md))。
4. 別の通知で同じヘッダー ID (**Id**) を使用して、それらの通知を同じヘッダーの下にまとめます。 **Id** は複数の通知をグループ化するかどうかの判断に使用される唯一のプロパティであり、これが同じであれば、**Title** や **Arguments** が異なっていても同じグループに分類されます。 **Title** と **Arguments** は、グループ内の最新の通知のタイトルと引数が使用されます。 その最新の通知が削除された場合、2 番目に新しい通知が繰り上がって最新となり、その通知の **Title** と **Arguments** が使用されます。


## <a name="handle-activation-from-a-header"></a>ヘッダーからのアクティブ化の処理

ヘッダーはクリック可能です。ユーザーはヘッダーをクリックしてアプリから詳細情報を表示できます。

そのため、アプリではトースト自体の起動引数に似た **Arguments** をヘッダーに設定できます。

アクティブ化は、[通常のトーストのアクティブ化](send-local-toast.md#handling-activation-1)と同じ方法で処理されるため、ユーザーがトースト本体やトーストのボタンをクリックした場合と同様、`App.xaml.cs` の **OnActivated** メソッドでこれらの引数を取得できます。

```csharp
protected override void OnActivated(IActivatedEventArgs e)
{
    // Handle toast activation
    if (e is ToastNotificationActivatedEventArgs)
    {
        // Arguments specified from the header
        string arguments = (e as ToastNotificationActivatedEventArgs).Argument;
    }
}
```


## <a name="additional-info"></a>追加情報

ヘッダーは複数の通知を視覚的に分類し、グループ化します。 アプリが保持できる通知の最大数 (20) や、先入れ先出し法による通知の一覧の処理など、その他のしくみはヘッダーを使用しても変わりません。

ヘッダー内の通知の順序は、次のとおりです.特定のアプリのアプリ (およびすべてのヘッダー グループ ヘッダーの一部の場合) から最新の通知は、先頭に表示されます。

**Id** には、任意の文字列を設定できます。 **ToastHeader** のどのプロパティにも、長さや文字の制限はありません。 唯一の制限は、XML トースト コンテンツ全体の上限が 5 KB ということのみです。

ヘッダーを作成しても、[詳細を表示] ボタンが表示される前に、アクション センター内に表示される通知の数は変わりません (この数は既定で 3 ですが、ユーザーが設定で [システム] を選択して、通知についてアプリごとに構成できます)。

アプリのタイトルをクリックした場合と同様、ヘッダーをクリックしても、このヘッダーに属する通知は消去されません (関連の通知を消去するには、アプリでトースト API を使用する必要があります)。


## <a name="related-topics"></a>関連トピック

- [ローカル ハンドルとトーストのアクティブ化を送信します。](send-local-toast.md)
- [トーストのコンテンツのドキュメント](adaptive-interactive-toasts.md)