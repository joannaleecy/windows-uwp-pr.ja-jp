---
author: andrewleader
Description: This article describes how to send a local tile notification to a primary tile and a secondary tile using adaptive tile templates.
title: ローカル タイル通知の送信
ms.assetid: D34B0514-AEC6-4C41-B318-F0985B51AF8A
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7e91d4bd481188f4d29af68af2c4572b26d446ae
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4952041"
---
# <a name="send-a-local-tile-notification"></a><span data-ttu-id="287e3-103">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="287e3-103">Send a local tile notification</span></span>
 

<span data-ttu-id="287e3-104">Windows 10 では、アプリのプライマリ タイルはアプリ マニフェストで定義されます。これに対して、セカンダリ タイルはプログラムによって作成され、アプリ コードで定義されます。</span><span class="sxs-lookup"><span data-stu-id="287e3-104">Primary app tiles in Windows 10 are defined in your app manifest, while secondary tiles are programmatically created and defined by your app code.</span></span> <span data-ttu-id="287e3-105">この記事では、アダプティブ タイル テンプレートを使って、ローカル タイル通知をプライマリ タイルやセカンダリ タイルに送信する方法について説明します </span><span class="sxs-lookup"><span data-stu-id="287e3-105">This article describes how to send a local tile notification to a primary tile and a secondary tile using adaptive tile templates.</span></span> <span data-ttu-id="287e3-106">(ローカル通知とは、Web サーバーからプッシュまたはプルされる通知ではなく、アプリ コードから送信される通知です)。</span><span class="sxs-lookup"><span data-stu-id="287e3-106">(A local notification is one that's sent from app code as opposed to one that's pushed or pulled from a web server.)</span></span>

![既定のタイルと通知を含んだタイル](images/sending-local-tile-01.png)

> [!NOTE] 
><span data-ttu-id="287e3-108">詳しくは「[アダプティブ タイルの作成](create-adaptive-tiles.md)」と「[タイルのコンテンツのスキーマ](../tiles-and-notifications/tile-schema.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="287e3-108">Learn about [creating adaptive tiles](create-adaptive-tiles.md) and [tile content schema](../tiles-and-notifications/tile-schema.md).</span></span>

 

## <a name="install-the-nuget-package"></a><span data-ttu-id="287e3-109">NuGet パッケージをインストールする</span><span class="sxs-lookup"><span data-stu-id="287e3-109">Install the NuGet package</span></span>


<span data-ttu-id="287e3-110">[Notifications ライブラリの NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)をインストールすることをお勧めします。このパッケージを使うと、生の XML ではなくオブジェクトによってタイルのペイロードが生成され、作業が簡素化されます。</span><span class="sxs-lookup"><span data-stu-id="287e3-110">We recommend installing the [Notifications library NuGet package](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/), which simplifies things by generating tile payloads with objects instead of raw XML.</span></span>

<span data-ttu-id="287e3-111">この記事のインライン コードの例は、Notifications ライブラリを使った場合の C# に対応しています </span><span class="sxs-lookup"><span data-stu-id="287e3-111">The inline code examples in this article are for C# using the Notifications library.</span></span> <span data-ttu-id="287e3-112">(独自の XML を作成する場合は、この記事の最後に示されている、Notifications ライブラリを使わないコード例をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="287e3-112">(If you'd prefer to create your own XML, you can find code examples without the Notifications library toward the end of the article.)</span></span>

## <a name="add-namespace-declarations"></a><span data-ttu-id="287e3-113">名前空間宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="287e3-113">Add namespace declarations</span></span>


<span data-ttu-id="287e3-114">タイル API にアクセスするには、[**Windows.UI.Notifications**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications) 名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="287e3-114">To access the tile APIs, include the [**Windows.UI.Notifications**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications) namespace.</span></span> <span data-ttu-id="287e3-115">**Microsoft.Toolkit.Uwp.Notifications** 名前空間も追加することをお勧めします。これにより、タイルのヘルパー API を使うことができます (これらの API にアクセスするには、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)の NuGet パッケージをインストールする必要があります)。</span><span class="sxs-lookup"><span data-stu-id="287e3-115">We also recommend including the **Microsoft.Toolkit.Uwp.Notifications** namespace so that you can take advantage of our tile helper APIs (you must install the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) NuGet package to access these APIs).</span></span>

```csharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
```

## <a name="create-the-notification-content"></a><span data-ttu-id="287e3-116">タイル通知のコンテンツを作成する</span><span class="sxs-lookup"><span data-stu-id="287e3-116">Create the notification content</span></span>


<span data-ttu-id="287e3-117">Windows 10 では、アダプティブ タイル テンプレートを使ってタイルのペイロードが定義されます。これにより、通知に合わせたカスタムの視覚的なレイアウトを作成できます </span><span class="sxs-lookup"><span data-stu-id="287e3-117">In Windows 10, tile payloads are defined using adaptive tile templates, which allow you to create custom visual layouts for your notifications.</span></span> <span data-ttu-id="287e3-118">(アダプティブ タイルの活用方法について詳しくは、「[アダプティブ タイルの作成](create-adaptive-tiles.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="287e3-118">(To learn what's possible with adaptive tiles, see [Create adaptive tiles](create-adaptive-tiles.md).)</span></span>

<span data-ttu-id="287e3-119">次のコード例では、普通サイズのタイルおよびワイド タイル用にアダプティブ タイルのコンテンツを作成します。</span><span class="sxs-lookup"><span data-stu-id="287e3-119">This code example creates adaptive tile content for medium and wide tiles.</span></span>

```csharp
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

<span data-ttu-id="287e3-120">普通サイズのタイルに表示されると、通知のコンテンツは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="287e3-120">The notification content looks like the following when displayed on a medium tile:</span></span>

![普通サイズのタイルでの通知のコンテンツ](images/sending-local-tile-02.png)

## <a name="create-the-notification"></a><span data-ttu-id="287e3-122">通知を作成する</span><span class="sxs-lookup"><span data-stu-id="287e3-122">Create the notification</span></span>


<span data-ttu-id="287e3-123">通知のコンテンツを決定したら、新しい [**TileNotification**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileNotification) を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="287e3-123">Once you have your notification content, you'll need to create a new [**TileNotification**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileNotification).</span></span> <span data-ttu-id="287e3-124">**TileNotification** コンストラクターは Windows ランタイムの [**XmlDocument**](https://docs.microsoft.com/uwp/api/windows.data.xml.dom.xmldocument) オブジェクトを受け取ります。このオブジェクトは、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使っている場合に、**TileContent.GetXml** メソッドから取得することができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-124">The **TileNotification** constructor takes a Windows Runtime [**XmlDocument**](https://docs.microsoft.com/uwp/api/windows.data.xml.dom.xmldocument) object, which you can obtain from the **TileContent.GetXml** method if you're using the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/).</span></span>

<span data-ttu-id="287e3-125">次のコード例では、新しいタイルの通知を作成します。</span><span class="sxs-lookup"><span data-stu-id="287e3-125">This code example creates a notification for a new tile.</span></span>

```csharp
// Create the tile notification
var notification = new TileNotification(content.GetXml());
```

## <a name="set-an-expiration-time-for-the-notification-optional"></a><span data-ttu-id="287e3-126">通知の有効期限を設定する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="287e3-126">Set an expiration time for the notification (optional)</span></span>


<span data-ttu-id="287e3-127">既定では、ローカル タイル通知とローカル バッジ通知には有効期限がなく、プッシュ通知、定期的な通知、スケジュールされた通知の有効期限は 3 日です。</span><span class="sxs-lookup"><span data-stu-id="287e3-127">By default, local tile and badge notifications don't expire, while push, periodic, and scheduled notifications expire after three days.</span></span> <span data-ttu-id="287e3-128">タイルのコンテンツは必要以上に長く保持しないことが推奨されるため、アプリにとって適切な有効期限を設定することをお勧めします (特に、ローカル タイル通知やローカル バッジ通知の場合)。</span><span class="sxs-lookup"><span data-stu-id="287e3-128">Because tile content shouldn't persist longer than necessary, it's a best practice to set an expiration time that makes sense for your app, especially on local tile and badge notifications.</span></span>

<span data-ttu-id="287e3-129">次のコード例では、10 分後に有効期限が切れ、タイルから削除される通知を作成します。</span><span class="sxs-lookup"><span data-stu-id="287e3-129">This code example creates a notification that expires and will be removed from the tile after ten minutes.</span></span>

```csharp
tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(10);
```

## <a name="send-the-notification"></a><span data-ttu-id="287e3-130">通知を送信する</span><span class="sxs-lookup"><span data-stu-id="287e3-130">Send the notification</span></span>


<span data-ttu-id="287e3-131">タイル通知をローカルで送信する方法は簡単ですが、通知をプライマリ タイルに送信する方法とセカンダリ タイルに送信する方法は少し異なります。</span><span class="sxs-lookup"><span data-stu-id="287e3-131">Although locally sending a tile notification is simple, sending the notification to a primary or secondary tile is a bit different.</span></span>

**<span data-ttu-id="287e3-132">プライマリ タイル</span><span class="sxs-lookup"><span data-stu-id="287e3-132">Primary tile</span></span>**

<span data-ttu-id="287e3-133">通知をプライマリ タイルに送信するには、[**TileUpdateManager**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdateManager) を使ってプライマリ タイル用のタイル アップデーターを作成し、"Update" を呼び出して通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="287e3-133">To send a notification to a primary tile, use the [**TileUpdateManager**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdateManager) to create a tile updater for the primary tile, and send the notification by calling "Update".</span></span> <span data-ttu-id="287e3-134">表示されるかどうかに関係なく、アプリのプライマリ タイルは常に存在します。そのため、タイルがピン留めされていない場合でも、通知をタイルに送信することができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-134">Regardless of whether it's visible, your app's primary tile always exists, so you can send notifications to it even when it's not pinned.</span></span> <span data-ttu-id="287e3-135">ユーザーが後でプライマリ タイルをピン留めする場合、送信した通知はタイルをピン留めしたときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="287e3-135">If the user pins your primary tile later, the notifications that you sent will appear then.</span></span>

<span data-ttu-id="287e3-136">次のコード例では、通知をプライマリ タイルに送信します。</span><span class="sxs-lookup"><span data-stu-id="287e3-136">This code example sends a notification to a primary tile.</span></span>


```csharp
// Send the notification to the primary tile
TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
```

**<span data-ttu-id="287e3-137">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="287e3-137">Secondary tile</span></span>**

<span data-ttu-id="287e3-138">通知をセカンダリ タイルに送信するには、まず、セカンダリ タイルが存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="287e3-138">To send a notification to a secondary tile, first make sure that the secondary tile exists.</span></span> <span data-ttu-id="287e3-139">存在しないセカンダリ タイル (ユーザーがセカンダリ タイルのピン留めを外した場合など) のタイル アップデーターを作成すると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="287e3-139">If you try to create a tile updater for a secondary tile that doesn't exist (for example, if the user unpinned the secondary tile), an exception will be thrown.</span></span> <span data-ttu-id="287e3-140">[**SecondaryTile.Exists**](https://docs.microsoft.com/uwp/api/Windows.UI.StartScreen.SecondaryTile#Windows_UI_StartScreen_SecondaryTile_Exists_System_String_)(tileId) を使ってセカンダリ タイルがピン留めされていることを確認してから、セカンダリ タイルのタイル アップデーターを作成し、通知を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-140">You can use [**SecondaryTile.Exists**](https://docs.microsoft.com/uwp/api/Windows.UI.StartScreen.SecondaryTile#Windows_UI_StartScreen_SecondaryTile_Exists_System_String_)(tileId) to discover if your secondary tile is pinned, and then create a tile updater for the secondary tile and send the notification.</span></span>

<span data-ttu-id="287e3-141">次のコード例では、通知をセカンダリ タイルに送信します。</span><span class="sxs-lookup"><span data-stu-id="287e3-141">This code example sends a notification to a secondary tile.</span></span>

```csharp
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

## <a name="clear-notifications-on-the-tile-optional"></a><span data-ttu-id="287e3-143">タイルの通知を消去する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="287e3-143">Clear notifications on the tile (optional)</span></span>


<span data-ttu-id="287e3-144">ほとんどの場合、ユーザーが通知コンテンツを操作した後で、通知を消去する必要があります。</span><span class="sxs-lookup"><span data-stu-id="287e3-144">In most cases, you should clear a notification once the user has interacted with that content.</span></span> <span data-ttu-id="287e3-145">たとえば、ユーザーがアプリを起動したとき、場合によっては、タイルからすべての通知を消去する必要があります。</span><span class="sxs-lookup"><span data-stu-id="287e3-145">For example, when the user launches your app, you might want to clear all the notifications from the tile.</span></span> <span data-ttu-id="287e3-146">通知に期限がある場合は、通知を明示的に消去するのではなく、通知に有効期限を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="287e3-146">If your notifications are time-bound, we recommend that you set an expiration time on the notification instead of explicitly clearing the notification.</span></span>

<span data-ttu-id="287e3-147">次のコード例では、プライマリ タイルへのタイル通知を消去します。</span><span class="sxs-lookup"><span data-stu-id="287e3-147">This code example clears the tile notification for the primary tile.</span></span> <span data-ttu-id="287e3-148">セカンダリ タイルのタイル アップデーターを作成することで、セカンダリ タイルに対しても同じ処理を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-148">You can do the same for secondary tiles by creating a tile updater for the secondary tile.</span></span>

```csharp
TileUpdateManager.CreateTileUpdaterForApplication().Clear();
```

<span data-ttu-id="287e3-149">タイルの通知キューが有効になっており、キューに通知がある場合は、Clear メソッドを呼び出すことでキューが空になります。</span><span class="sxs-lookup"><span data-stu-id="287e3-149">For a tile with the notification queue enabled and notifications in the queue, calling the Clear method empties the queue.</span></span> <span data-ttu-id="287e3-150">ただし、アプリのサーバーを使って通知を消去することはできません。ローカルのアプリ コードでのみ通知を消去できます。</span><span class="sxs-lookup"><span data-stu-id="287e3-150">You can't, however, clear a notification via your app's server; only the local app code can clear notifications.</span></span>

<span data-ttu-id="287e3-151">定期的な通知やプッシュ通知では、新しい通知の追加や既にある通知の置き換えのみを実行できます。</span><span class="sxs-lookup"><span data-stu-id="287e3-151">Periodic or push notifications can only add new notifications or replace existing notifications.</span></span> <span data-ttu-id="287e3-152">Clear メソッドをローカルで呼び出すと、通知自体がプッシュ通知、定期的な通知、またはローカル通知によって発生したかどうかに関係なくタイルが消去されます。</span><span class="sxs-lookup"><span data-stu-id="287e3-152">A local call to the Clear method will clear the tile whether or not the notifications themselves came via push, periodic, or local.</span></span> <span data-ttu-id="287e3-153">まだ表示されていないスケジュールされた通知は、このメソッドでは消去されません。</span><span class="sxs-lookup"><span data-stu-id="287e3-153">Scheduled notifications that haven't yet appeared are not cleared by this method.</span></span>

![通知を含んだタイルと消去された後のタイル](images/sending-local-tile-03.png)

## <a name="next-steps"></a><span data-ttu-id="287e3-155">次の手順</span><span class="sxs-lookup"><span data-stu-id="287e3-155">Next steps</span></span>


**<span data-ttu-id="287e3-156">通知キューの使用</span><span class="sxs-lookup"><span data-stu-id="287e3-156">Using the notification queue</span></span>**

<span data-ttu-id="287e3-157">最初のタイルの更新を実行したので、[通知キュー](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234)を有効にしてタイルの機能を拡張できます。</span><span class="sxs-lookup"><span data-stu-id="287e3-157">Now that you have done your first tile update, you can expand the functionality of the tile by enabling a [notification queue](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234).</span></span>

**<span data-ttu-id="287e3-158">通知の他の配信方法</span><span class="sxs-lookup"><span data-stu-id="287e3-158">Other notification delivery methods</span></span>**

<span data-ttu-id="287e3-159">この記事では、タイルの更新を通知として送信する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="287e3-159">This article shows you how to send the tile update as a notification.</span></span> <span data-ttu-id="287e3-160">通知を配信する他の方法 (スケジュール、定期的、プッシュ) を調べるには、「[通知の配信](choosing-a-notification-delivery-method.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="287e3-160">To explore other methods of notification delivery, including scheduled, periodic, and push, see [Delivering notifications](choosing-a-notification-delivery-method.md).</span></span>

**<span data-ttu-id="287e3-161">XmlEncode 配信メソッド</span><span class="sxs-lookup"><span data-stu-id="287e3-161">XmlEncode delivery method</span></span>**

<span data-ttu-id="287e3-162">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使わない場合は、このメソッドを代わりに使って、通信を配信することができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-162">If you're not using the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/), this notification delivery method is another alternative.</span></span>


```csharp
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

## <a name="code-examples-without-notifications-library"></a><span data-ttu-id="287e3-163">Notifications ライブラリを使わない場合のコード例</span><span class="sxs-lookup"><span data-stu-id="287e3-163">Code examples without Notifications library</span></span>


<span data-ttu-id="287e3-164">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)の NuGet パッケージではなく、生の XML を使う場合は、この記事で照会した最初の 3 つの例で、以下の代替のコード例を利用することができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-164">If you prefer to work with raw XML instead of the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) NuGet package, use these alternate code examples to first three examples provided in this article.</span></span> <span data-ttu-id="287e3-165">他のコード例は、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)または生の XML のいずれかと共に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="287e3-165">The rest of the code examples can be used either with the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) or with raw XML.</span></span>

<span data-ttu-id="287e3-166">名前空間宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="287e3-166">Add namespace declarations</span></span>

```csharp
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
```

<span data-ttu-id="287e3-167">タイル通知のコンテンツを作成する</span><span class="sxs-lookup"><span data-stu-id="287e3-167">Create the notification content</span></span>

```csharp
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

<span data-ttu-id="287e3-168">通知を作成する</span><span class="sxs-lookup"><span data-stu-id="287e3-168">Create the notification</span></span>

```csharp
// Load the string into an XmlDocument
XmlDocument doc = new XmlDocument();
doc.LoadXml(content);
 
// Then create the tile notification
var notification = new TileNotification(doc);
```

## <a name="related-topics"></a><span data-ttu-id="287e3-169">関連トピック</span><span class="sxs-lookup"><span data-stu-id="287e3-169">Related topics</span></span>

* [<span data-ttu-id="287e3-170">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="287e3-170">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
* [<span data-ttu-id="287e3-171">タイルのコンテンツのスキーマ</span><span class="sxs-lookup"><span data-stu-id="287e3-171">Tile content schema</span></span>](../tiles-and-notifications/tile-schema.md)
* [<span data-ttu-id="287e3-172">Notifications ライブラリ</span><span class="sxs-lookup"><span data-stu-id="287e3-172">Notifications library</span></span>](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
* [<span data-ttu-id="287e3-173">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="287e3-173">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-sending-local-tile-win10)
* [**<span data-ttu-id="287e3-174">Windows.UI.Notifications 名前空間</span><span class="sxs-lookup"><span data-stu-id="287e3-174">Windows.UI.Notifications namespace</span></span>**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications)
* [<span data-ttu-id="287e3-175">通知キューの使用方法 (XAML)</span><span class="sxs-lookup"><span data-stu-id="287e3-175">How to use the notification queue (XAML)</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh868234)
* [<span data-ttu-id="287e3-176">通知の配信</span><span class="sxs-lookup"><span data-stu-id="287e3-176">Delivering notifications</span></span>](choosing-a-notification-delivery-method.md)
 

 




