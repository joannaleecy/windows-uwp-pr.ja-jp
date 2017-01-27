---
author: mijacobs
Description: "この記事では、アダプティブ タイル テンプレートを使って、ローカル タイル通知をプライマリ タイルやセカンダリ タイルに送信する方法について説明します "
title: "ローカル タイル通知の送信"
ms.assetid: D34B0514-AEC6-4C41-B318-F0985B51AF8A
label: TBD
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: bbc09a6638fd7c0798e49600bd74388d5bb4629d

---
# <a name="send-a-local-tile-notification"></a>ローカル タイル通知の送信
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

Windows 10 では、アプリのプライマリ タイルはアプリ マニフェストで定義されます。これに対して、セカンダリ タイルはプログラムによって作成され、アプリ コードで定義されます。 この記事では、アダプティブ タイル テンプレートを使って、ローカル タイル通知をプライマリ タイルやセカンダリ タイルに送信する方法について説明します  (ローカル通知とは、Web サーバーからプッシュまたはプルされる通知ではなく、アプリ コードから送信される通知です)。

![既定のタイルと通知を含んだタイル](images/sending-local-tile-01.png)

> [!NOTE] 
>詳しくは「[アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)」と「[アダプティブ タイル テンプレートのスキーマ](tiles-and-notifications-adaptive-tiles-schema.md)」をご覧ください。

 

## <a name="install-the-nuget-package"></a>NuGet パッケージをインストールする


[Notifications ライブラリの NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)をインストールすることをお勧めします。このパッケージを使うと、生の XML ではなくオブジェクトによってタイルのペイロードが生成され、作業が簡素化されます。

この記事のインライン コードの例は、Notifications ライブラリを使った場合の C# に対応しています  (独自の XML を作成する場合は、この記事の最後に示されている、Notifications ライブラリを使わないコード例をご覧ください)。

## <a name="add-namespace-declarations"></a>名前空間宣言を追加する


タイル API にアクセスするには、[**Windows.UI.Notifications**](https://msdn.microsoft.com/library/windows/apps/br208661) 名前空間を追加します。 **NotificationsExtensions.Tiles** 名前空間も追加することをお勧めします。これにより、タイルのヘルパー API を使うことができます (これらの API にアクセスするには、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)の NuGet パッケージをインストールする必要があります)。

```CSharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
```

## <a name="create-the-notification-content"></a>タイル通知のコンテンツを作成する


Windows 10 では、アダプティブ タイル テンプレートを使ってタイルのペイロードが定義されます。これにより、通知に合わせたカスタムの視覚的なレイアウトを作成できます  (アダプティブ タイルを使ってできることについて詳しくは、「[アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)」と「[アダプティブ タイル テンプレート](tiles-and-notifications-adaptive-tiles-schema.md)」の記事をご覧ください)。

次のコード例では、普通サイズのタイルおよびワイド タイル用にアダプティブ タイルのコンテンツを作成します。

```CSharp
// In a real app, these would be initialized with actual data
string from = "Jennifer Parker";
string subject = "Photos from our trip";
string body = "Check out these awesome photos I took while in New Zealand!";
 
 
// Construct the tile content
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = from
                    },

                    new AdaptiveText()
                    {
                        Text = subject,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = body,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
            }
        },

        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = from,
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },

                    new AdaptiveText()
                    {
                        Text = subject,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = body,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
            }
        }
    }
};
```

普通サイズのタイルに表示されると、通知のコンテンツは次のようになります。

![普通サイズのタイルでの通知のコンテンツ](images/sending-local-tile-02.png)

## <a name="create-the-notification"></a>通知を作成する


通知のコンテンツを決定したら、新しい [**TileNotification**](https://msdn.microsoft.com/library/windows/apps/br208616) を作成する必要があります。 **TileNotification** コンストラクターは Windows ランタイムの [**XmlDocument**](https://msdn.microsoft.com/library/windows/apps/br208620) オブジェクトを受け取ります。このオブジェクトは、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使っている場合に、**TileContent.GetXml** メソッドから取得することができます。

次のコード例では、新しいタイルの通知を作成します。

```CSharp
// Create the tile notification
var notification = new TileNotification(content.GetXml());
```

## <a name="set-an-expiration-time-for-the-notification-optional"></a>通知の有効期限を設定する (省略可能)


既定では、ローカル タイル通知とローカル バッジ通知には有効期限がなく、プッシュ通知、定期的な通知、スケジュールされた通知の有効期限は 3 日です。 タイルのコンテンツは必要以上に長く保持しないことが推奨されるため、アプリにとって適切な有効期限を設定することをお勧めします (特に、ローカル タイル通知やローカル バッジ通知の場合)。

次のコード例では、10 分後に有効期限が切れ、タイルから削除される通知を作成します。

```CSharp
tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(10);
```

## <a name="send-the-notification"></a>通知を送信する


タイル通知をローカルで送信する方法は簡単ですが、通知をプライマリ タイルに送信する方法とセカンダリ タイルに送信する方法は少し異なります。

**プライマリ タイル**

通知をプライマリ タイルに送信するには、[**TileUpdateManager**](https://msdn.microsoft.com/library/windows/apps/br208622) を使ってプライマリ タイル用のタイル アップデーターを作成し、"Update" を呼び出して通知を送信します。 表示されるかどうかに関係なく、アプリのプライマリ タイルは常に存在します。そのため、タイルがピン留めされていない場合でも、通知をタイルに送信することができます。 ユーザーが後でプライマリ タイルをピン留めする場合、送信した通知はタイルをピン留めしたときに表示されます。

次のコード例では、通知をプライマリ タイルに送信します。


```CSharp
// Send the notification to the primary tile
TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
```

**セカンダリ タイル**

通知をセカンダリ タイルに送信するには、まず、セカンダリ タイルが存在することを確認します。 存在しないセカンダリ タイル (ユーザーがセカンダリ タイルのピン留めを外した場合など) のタイル アップデーターを作成すると、例外がスローされます。 [**SecondaryTile.Exists**](https://msdn.microsoft.com/library/windows/apps/br242205)(tileId) を使ってセカンダリ タイルがピン留めされていることを確認してから、セカンダリ タイルのタイル アップデーターを作成し、通知を送信することができます。

次のコード例では、通知をセカンダリ タイルに送信します。

```CSharp
// If the secondary tile is pinned
if (SecondaryTile.Exists("MySecondaryTile"))
{
    // Get its updater
    var updater = TileUpdateManager.CreateTileUpdaterForSecondaryTile("MySecondaryTile");
 
    // And send the notification
    updater.Update(notification);
}
```

![既定のタイルと通知を含んだタイル](images/sending-local-tile-01.png)

## <a name="clear-notifications-on-the-tile-optional"></a>タイルの通知を消去する (省略可能)


ほとんどの場合、ユーザーが通知コンテンツを操作した後で、通知を消去する必要があります。 たとえば、ユーザーがアプリを起動したとき、場合によっては、タイルからすべての通知を消去する必要があります。 通知に期限がある場合は、通知を明示的に消去するのではなく、通知に有効期限を設定することをお勧めします。

次のコード例では、プライマリ タイルへのタイル通知を消去します。 セカンダリ タイルのタイル アップデーターを作成することで、セカンダリ タイルに対しても同じ処理を行うことができます。

```CSharp
TileUpdateManager.CreateTileUpdaterForApplication().Clear();
```

タイルの通知キューが有効になっており、キューに通知がある場合は、Clear メソッドを呼び出すことでキューが空になります。 ただし、アプリのサーバーを使って通知を消去することはできません。ローカルのアプリ コードでのみ通知を消去できます。

定期的な通知やプッシュ通知では、新しい通知の追加や既にある通知の置き換えのみを実行できます。 Clear メソッドをローカルで呼び出すと、通知自体がプッシュ通知、定期的な通知、またはローカル通知によって発生したかどうかに関係なくタイルが消去されます。 まだ表示されていないスケジュールされた通知は、このメソッドでは消去されません。

![通知を含んだタイルと消去された後のタイル](images/sending-local-tile-03.png)

## <a name="next-steps"></a>次の手順


**通知キューの使用**

最初のタイルの更新を実行したので、[通知キュー](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234)を有効にしてタイルの機能を拡張できます。

**通知の他の配信方法**

この記事では、タイルの更新を通知として送信する方法について説明します。 通知を配信する他の方法 (スケジュール、定期的、プッシュ) を調べるには、「[通知の配信](tiles-and-notifications-choosing-a-notification-delivery-method.md)」をご覧ください。

**XmlEncode 配信メソッド**

[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使わない場合は、このメソッドを代わりに使って、通信を配信することができます。


```CSharp
public string XmlEncode(string text)
{
    StringBuilder builder = new StringBuilder();
    using (var writer = XmlWriter.Create(builder))
    {
        writer.WriteString(text);
    }

    return builder.ToString();
}
```

## <a name="code-examples-without-notifications-library"></a>Notifications ライブラリを使わない場合のコード例


[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)の NuGet パッケージではなく、生の XML を使う場合は、この記事で照会した最初の 3 つの例で、以下の代替のコード例を利用することができます。 他のコード例は、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)または生の XML のいずれかと共に使うことができます。

名前空間宣言を追加する

```CSharp
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
```

タイル通知のコンテンツを作成する

```CSharp
// In a real app, these would be initialized with actual data
string from = "Jennifer Parker";
string subject = "Photos from our trip";
string body = "Check out these awesome photos I took while in New Zealand!";
 
 
// TODO - all values need to be XML escaped
 
 
// Construct the tile content as a string
string content = $@"
<tile>
    <visual>
 
        <binding template='TileMedium'>
            <text>{from}</text>
            <text hint-style='captionSubtle'>{subject}</text>
            <text hint-style='captionSubtle'>{body}</text>
        </binding>
 
        <binding template='TileWide'>
            <text hint-style='subtitle'>{from}</text>
            <text hint-style='captionSubtle'>{subject}</text>
            <text hint-style='captionSubtle'>{body}</text>
        </binding>
 
    </visual>
</tile>";
```

通知を作成する

```CSharp
// Load the string into an XmlDocument
XmlDocument doc = new XmlDocument();
doc.LoadXml(content);
 
// Then create the tile notification
var notification = new TileNotification(doc);
```

## <a name="related-topics"></a>関連トピック

* [アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)
* [アダプティブ タイル テンプレート: スキーマとドキュメント](tiles-and-notifications-adaptive-tiles-schema.md)
* [Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-sending-local-tile-win10)
* [**Windows.UI.Notifications 名前空間**](https://msdn.microsoft.com/library/windows/apps/br208661)
* [通知キューの使用方法 (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234)
* [通知の配信](tiles-and-notifications-choosing-a-notification-delivery-method.md)
 

 







<!--HONumber=Dec16_HO2-->


