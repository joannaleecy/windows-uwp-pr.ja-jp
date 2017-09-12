---
title: "マイ連絡先の通知"
description: "新しい種類のトーストである、マイ連絡先の通知を作成して使用する方法について説明します。"
author: mukin
ms.author: mukin
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b1fbba8b8cea3edd51dc9b60cae1ea3853f39dd1
ms.sourcegitcommit: ec18e10f750f3f59fbca2f6a41bf1892072c3692
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2017
---
# <a name="my-people-notifications"></a>マイ連絡先の通知

> [!IMPORTANT]
> **プレリリース | Fall Creators Update が必要**: マイ連絡先 API を使うには、[Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) をターゲットとし、[Insider ビルド 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) 以降を実行している必要があります。

マイ連絡先の通知は、ユーザーやユーザーにとって大切な人たちを重視した、新しい種類のジェスチャです。 ユーザーが大切な人たちとつながるための、すばやく手軽な表現のジェスチャによる、新しい方法を提供します。

![ハート絵文字通知](images/heart-emoji-notification-small.gif)

## <a name="requirements"></a>要件

+ Windows 10 と Microsoft Visual Studio 2017。 インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。
+ C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。 C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。

## <a name="how-it-works"></a>しくみ

アプリケーション開発者は、汎用のトースト通知に代わり、マイ連絡先の機能を使って、通知を送信できます。これによって、さらにパーソナルなエクスペリエンスをユーザーに提供できます。 これは、ユーザーのタスク バーにピン留めされた連絡先から送信される、新しい種類のトーストです。 通知を受信すると、マイ連絡先の通知が開始されていることを知らせるため、送信者の連絡先の写真がタスク バー上でアニメーションされ、サウンドが再生されます。 アニメーションまたはペイロードで指定された画像が 5 秒間表示されます (ペイロードが 5 秒以下のアニメーションの場合、5 秒までループされます)。

## <a name="supported-image-types"></a>サポートされるイメージの種類

+ GIF
+ 静的な画像 (JPEG、PNG)
+ Spritesheet (垂直方向のみ)

> [!NOTE]
> Spritesheet は、静的な画像 (JPEG または PNG) から派生したアニメーションです。 個々のフレームは、最初のフレームが上になるように、垂直方向に配置されます (トースト ペイロードで、別の開始フレームを指定することもできます)。 各フレームの高さは同じである必要があります。プログラムはこれをループして、アニメーション シーケンスを (すべてのページが垂直方向に配置されているフリップブックのように) 作成します。 以下に Spritesheet の例を示します。

![レインボー Spritesheet](images/shoulder-tap-rainbow-spritesheet.png)

## <a name="notification-parameters"></a>通知パラメーター
マイ連絡先の通知は、Windows 10 の[トースト通知](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md)フレームワークを使用します。トースト ペイロードには追加のバインド ノードが必要です。 つまり、マイ連絡先による通知には、1 つではなく 2 つのバインドがある必要があります。 2 つ目のバインドには、次のパラメーターを含める必要があります。

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
    + 1 秒あたりのフレーム数。 Spritesheet アニメーションの場合のみ必要です。
+ **spritesheet-startingFrame**
    + アニメーションを開始するフレーム番号です。 Spritesheet アニメーションの場合のみ使用されます。指定されていない場合は、既定値は 0 となります。
+ **alt**
    + スクリーン リーダー ナレーションに使用されるテキスト文字列。

> [!NOTE]
> Spritesheet を使用している場合でも、アニメーションの表示に失敗した場合のフォールバックとして、静的な画像を "src" パラメーターに指定する必要があります。

さらに、トップ レベルのトースト ノードには、**hint-people** パラメーターを含めて、送信連絡先を指定する必要があります。 このパラメーターは次の値を取ることができます。

+ **メール アドレス** 
    + 例: mailto:johndoe@mydomain.com
+ **電話番号** 
    + 例: tel:888-888-8888
+ **リモート ID** 
    + 例: remoteid:1234

> [!NOTE]
> [ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) を使ったアプリで [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact#Windows_Phone_PersonalInformation_StoredContact_RemoteId) プロパティを使い、PC に保存されている連絡先とリモートに保存されている連絡先とを関連付ける場合、RemoteId プロパティの値は不変かつ一意であることが不可欠です。 つまり、リモート ID は、PC にある他の連絡先 (他のアプリが所有する連絡先も含む) のリモート ID と決して競合しないよう、常に同じユーザー アカウントを一意に識別し、固有のタグを保持している必要があります。
> アプリで使われるリモート ID の不変性と一意性に確証がない場合、このトピックの中で後述する RemoteIdHelper クラスを使うと、システムに追加するすべてのリモート ID にあらかじめ一意のタグを追加することができます。 または、RemoteId プロパティを一切使わない代わりに、カスタムの拡張プロパティを作成し、そこに連絡先のリモート ID を格納する方法もあります。

2 番目のバインドとペイロードだけでなく、最初のバインドにフォールバックのトースト用の別のペイロードを含める必要があります (強制的に標準のトーストに戻された場合にはこれが使用されます)。 これは、最後のセクションで詳しく説明します。

## <a name="creating-the-notification"></a>通知を作成する
[トースト通知](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md)と同様に、マイ連絡先通知テンプレートを作成することができます。

静的な画像を使用して、マイ連絡先の通知を作成する方法の例を次に示します。

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

次にアニメーションの Spritesheet を使用して、通知を作成する方法を説明します。 この Spritesheet ではフレームの高さが 80 ピクセルです。1 秒あたり 25 フレームでアニメーション化します。 開始フレームを 15 に設定し、静的なフォールバック画像を "src" パラメーターで指定します。 フォールバック画像は、Spritesheet アニメーションの表示に失敗した場合に使用されます。

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
マイ連絡先の通知を開始するには、トースト テンプレートを [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) オブジェクトに変換する必要があります。 トーストを (ここでは content.xml という名前の) XML ファイル内で定義する場合、次の C# コードを使用して、開始できます。

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
マイ連絡先の通知としてコーディングされた通知が、標準のトーストとして表示される場合があります。 次の条件下では、マイ連絡先の通知はトーストにフォールバックします。

+ 通知の表示に失敗した
+ 受信者で、マイ連絡先の通知が有効化されていない
+ 送信者の連絡先が、受信者のタスク バーにピン留めされていない

マイ連絡先の通知がトーストにフォールバックすると、2 番目のマイ連絡先固有のバインドは無視され、1 番目のバインドのみが使用されて、トーストが表示されます。 これは、前述のように、最初のトースト バインドでフォールバック ペイロードを指定する必要があることを意味します。

## <a name="see-also"></a>関連項目
+ [マイ連絡先のサポートを追加する](my-people-support.md)
+ [アダプティブ トースト通知](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md)
+ [ToastNotification クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotification)