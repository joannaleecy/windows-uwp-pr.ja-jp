---
title: マイ連絡先の通知
description: 新しい種類のトーストである、マイ連絡先の通知を作成して使用する方法について説明します。
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: db25954b7fc6541ac5f5900236e61cb8da488be6
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8348470"
---
# <a name="my-people-notifications"></a>マイ連絡先の通知

マイ連絡先の通知は、ユーザーが大切な人たちとつながるための、すばやい表現のジェスチャによる、新しい方法を提供します。 この記事では、アプリケーションでマイ連絡先の通知を設計および実装する方法を示します。 完全な実装については、「[マイ連絡先の通知のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/MyPeopleNotifications)」をご覧ください。

![ハート絵文字通知](images/heart-emoji-notification-small.gif)

## <a name="requirements"></a>要件

+ Windows 10 と Microsoft Visual Studio 2017。 インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。
+ C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。 C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。

## <a name="how-it-works"></a>しくみ

汎用のトースト通知の代わりに、マイ連絡先の機能を使って、通知を送信できます。これによって、さらにパーソナルなエクスペリエンスをユーザーに提供できます。 これは、ユーザーのタスク バーにピン留めされた連絡先からマイ連絡先機能を使用して送信される、新しい種類のトーストです。 通知を受信すると、通知が開始されていることを知らせるため、送信者の連絡先の写真がタスク バー上でアニメーションされ、サウンドが再生されます。 アニメーションまたはペイロードで指定された画像が 5 秒間表示されます (または、ペイロードが 5 秒以下のアニメーションの場合、5 秒までループされます)。

## <a name="supported-image-types"></a>サポートされるイメージの種類

+ GIF
+ 静的な画像 (JPEG、PNG)
+ Spritesheet (垂直方向のみ)

> [!NOTE]
> Spritesheet は、静的な画像 (JPEG または PNG) から派生したアニメーションです。 個々のフレームは、最初のフレームが上になるように、垂直方向に配置されます (ただし、トースト ペイロードで、別の開始フレームを指定することもできます)。 各フレームの高さは同じである必要があります。プログラムはこれをループして、アニメーション シーケンスを (ページが垂直方向に配置されているフリップブックのように) 作成します。 Spritesheet の例を以下に示します。

![レインボー Spritesheet](images/shoulder-tap-rainbow-spritesheet.png)

## <a name="notification-parameters"></a>通知パラメーター
マイ連絡先の通知は、[トースト通知](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)フレームワークを使用しますが、トースト ペイロードには追加のバインド ノードが必要です。 2 つ目のバインドには、次のパラメーターを含める必要があります。

```xml
experienceType=”shoulderTap”
```

これは、トーストをマイ連絡先の通知として扱う必要があることを示します。

バインド内のイメージ ノードには、次のパラメーターを含める必要があります。

+ **src**
    + アセットの URI。 HTTP/HTTPS Web URI、msappx URI、またはローカル ファイルへのパスを指定できます。
+ **spritesheet-src**
    + アセットの URI。 HTTP/HTTPS Web URI、msappx URI、またはローカル ファイルへのパスを指定できます。 Spritesheet アニメーションの場合のみ必要です。
+ **spritesheet-height**
    + フレームの高さ (ピクセル単位)。 Spritesheet アニメーションの場合のみ必要です。
+ **spritesheet-fps**
    + 1 秒あたりのフレーム数 (FPS)。 Spritesheet アニメーションの場合のみ必要です。 1 ～ 120 の値のみがサポートされます。
+ **spritesheet-startingFrame**
    + アニメーションを開始するフレーム番号です。 Spritesheet アニメーションの場合のみ使用されます。指定されていない場合は、既定値は 0 となります。
+ **alt**
    + スクリーン リーダー ナレーションに使用されるテキスト文字列。

> [!NOTE]
> アニメーションの通知を行うときでも、"src" パラメーターで静的な画像を指定する必要があります。 これは、アニメーションの表示に失敗した場合のフォールバックとして使用されます。

さらに、トップ レベルのトースト ノードには、**hint-people** パラメーターを含めて、送信連絡先を指定する必要があります。 このパラメーターは次の値を取ることができます。

+ **メール アドレス** 
    + 例: mailto:johndoe@mydomain.com
+ **電話番号** 
    + 例: tel:888-888-8888
+ **リモート ID** 
    + 例: remoteid:1234

> [!NOTE]
> [ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) を使ったアプリで [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact.RemoteId) プロパティを使い、PC に保存されている連絡先とリモートに保存されている連絡先とを関連付ける場合、RemoteId プロパティの値は不変かつ一意であることが不可欠です。 つまり、リモート ID は、PC にある他の連絡先 (他のアプリが所有する連絡先も含む) のリモート ID と決して競合しないよう、常に同じユーザー アカウントを一意に識別し、固有のタグを保持している必要があります。
> アプリで使われるリモート ID の不変性と一意性に確証がない場合、[RemoteIdHelper クラス](https://msdn.microsoft.com/en-us/library/windows/apps/jj207024(v=vs.105).aspx#BKMK_UsingtheRemoteIdHelperclass)を使うと、システムに追加するすべてのリモート ID にあらかじめ一意のタグを追加することができます。 または、RemoteId プロパティを一切使わない代わりに、カスタムの拡張プロパティを作成し、そこに連絡先のリモート ID を格納する方法もあります。

2 番目のバインドとペイロードだけでなく、フォールバック トーストの最初のバインドに別のペイロードを含める必要があります。 標準のトーストに強制的に戻される場合に、通知でこれが使用されます (詳細については、[この記事の最後](https://review.docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-notifications#falling-back-to-toast)を参照)。

## <a name="creating-the-notification"></a>通知を作成する
[トースト通知](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)と同様に、マイ連絡先通知テンプレートを作成することができます。

静的な画像のペイロードを使用してマイ連絡先の通知を作成する方法の例を次に示します。

```xml
<toast hint-people="mailto:johndoe@mydomain.com">
    <visual lang="en-US">
        <binding template="ToastGeneric">
            <text hint-style="body">Toast fallback</text>
            <text>Add your fallback toast content here</text>
        </binding>
        <binding template="ToastGeneric" experienceType="shoulderTap">
            <image src="https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/images/shoulder-tap-static-payload.png"/>
        </binding>
    </visual>
</toast>
```

通知を開始すると、次のようになります。

![静的な画像通知](images/static-image-notification-small.gif)

アニメーション化された Spritesheet ペイロードを使用して通知を作成する方法の例を次に示します。 この Spritesheet ではフレームの高さが 80 ピクセルです。1 秒あたり 25 フレームでアニメーション化します。 開始フレームを 15 に設定し、静的なフォールバック画像を "src" パラメーターで指定します。 フォールバック画像は、Spritesheet アニメーションの表示に失敗した場合に使用されます。

```xml
<toast hint-people="mailto:johndoe@mydomain.com">
    <visual lang="en-US">
        <binding template="ToastGeneric">
            <text hint-style="body">Toast fallback</text>
            <text>Add your fallback toast content here</text>
        </binding>
        <binding template="ToastGeneric" experienceType="shoulderTap">
            <image src="https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/images/shoulder-tap-pizza-static.png"
                spritesheet-src="https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/images/shoulder-tap-pizza-spritesheet.png"
                spritesheet-height='80' spritesheet-fps='25' spritesheet-startingFrame='15'/>
        </binding>
    </visual>
</toast>
```

通知を開始すると、次のようになります。

![Spritesheet 通知](images/pizza-notification-small.gif)

## <a name="starting-the-notification"></a>通知を開始する
マイ連絡先の通知を開始するには、トースト テンプレートを [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) オブジェクトに変換する必要があります。 トーストを (ここでは "content.xml" という名前の) XML ファイル内で定義すると、次のコードを使用して開始できます。

```CSharp
string xmlText = File.ReadAllText("content.xml");
XmlDocument xmlContent = new XmlDocument();
xmlContent.LoadXml(xmlText);
```

これで次のコードを使ってトーストを作成して送信できます。

```CSharp
ToastNotification notification = new ToastNotification(xmlContent);
ToastNotificationManager.CreateToastNotifier().Show(notification);
```

## <a name="falling-back-to-toast"></a>トーストにフォールバックする
マイ連絡先の通知が標準のトースト通知として表示される場合があります。 次の条件下では、マイ連絡先の通知はトーストにフォールバックします。

+ 通知の表示に失敗した
+ 受信者で、マイ連絡先の通知が有効化されていない
+ 送信者の連絡先が、受信者のタスク バーにピン留めされていない

マイ連絡先の通知がトーストにフォールバックすると、2 番目のマイ連絡先固有のバインドは無視され、1 番目のバインドのみが使用されて、トーストが表示されます。 これは、最初のトースト バインドでフォールバック ペイロードを指定することが重要である理由です。

## <a name="see-also"></a>関連項目
+ [マイ連絡先の通知のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/MyPeopleNotifications)
+ [マイ連絡先のサポートを追加する](my-people-support.md)
+ [アダプティブ トースト通知](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)
+ [ToastNotification クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotification)