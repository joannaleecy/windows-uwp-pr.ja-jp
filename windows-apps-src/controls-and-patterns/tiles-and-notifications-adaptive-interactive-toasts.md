---
author: mijacobs
Description: "アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。"
title: "アダプティブ トースト通知と対話型トースト通知"
ms.assetid: 1FCE66AF-34B4-436A-9FC9-D0CF4BDA5A01
label: Adaptive and interactive toast notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: c8e77773b9118c3177dc958ddc7b51d32a452fa5
ms.sourcegitcommit: 9d1ca16a7edcbbcae03fad50a4a10183a319c63a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/09/2017
---
# <a name="adaptive-and-interactive-toast-notifications"></a>アダプティブ トースト通知と対話型トースト通知

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

アダプティブ トースト通知と対話型トースト通知を使うと、テキスト、画像、ボタンや入力を含む柔軟性のある通知を作成できます。

> **重要な API**: [UWP Community Toolkit Notifications NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)

> [!NOTE]
> Windows 8.1 や Windows Phone 8.1 の従来のテンプレートについては、「[トースト テンプレート カタログ (Windows ランタイム アプリ)](https://msdn.microsoft.com/library/windows/apps/hh761494)」をご覧ください。


## <a name="getting-started"></a>概要

**Notifications ライブラリをインストールします。** XML の代わりに C# を使って通知を生成する場合は、[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) という名前の NuGet パッケージをインストールします (「notifications uwp」を検索してください)。 この記事で示している C# のサンプルでは、NuGet パッケージの Version 1.0.0 を使っています。

**Notifications Visualizer をインストールします。** この無料の UWP アプリは、Visual Studio の XAML エディター/デザイン ビューと同様、トーストの編集時に視覚的なプレビューが即座に表示されるため、対話型トースト通知のデザインに便利です。 詳しくは、[このブログ記事](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/09/22/introducing-notifications-visualizer-for-windows-10.aspx)をご覧ください。Notifications Visualizer は[こちら](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)からダウンロードできます。


## <a name="sending-a-toast-notification"></a>トースト通知の送信

通知を送信する方法については、「[ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)」をご覧ください。 このドキュメントでは、トースト コンテンツの作成についてのみ説明します。


## <a name="toast-notification-structure"></a>トースト通知の構造体

トースト通知は、Tag や Group (通知を識別できます) などのいくつかのデータ プロパティと*トースト コンテンツ*を組み合わせたものです。

トースト通知のコンテンツのコア コンポーネントは次のとおりです。
* **launch**: ユーザーがトーストをクリックしたときにアプリに渡される引数を定義します。これにより、トーストに表示されていた正しいコンテンツにディープ リンクできます。 詳しくは、「[ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)」をご覧ください。
* **visual**: トーストの視覚的な部分 (テキスト、画像、アプリ ロゴを含む汎用バインディングなど) です。
* **actions**: トーストの対話的な部分 (入力やアクションなど) です。
* **audio**: トーストがユーザーに表示されるときに再生されるオーディオを制御します。

トースト コンテンツは生の XML で定義されますが、トースト コンテンツを作成するために、[NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使って C# (または C++) オブジェクト モデルを取得することができます。 この記事では、トースト コンテンツ内に含まれるすべてのものについて説明します。

```csharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric() { ... }
    },
 
    Actions = new ToastActionsCustom() { ... },
 
    Audio = new ToastAudio() { ... }
};
```

```xml
<toast launch="app-defined-string">

  <visual>
    <binding template="ToastGeneric">
      ...
    </binding>
  </visual>

  <actions>
    ...
  </actions>

  <audio src="ms-winsoundevent:Notification.Reminder"/>

</toast>
```

トースト コンテンツの視覚的な表示は、次のようになります。

![トースト通知の構造体](images/adaptivetoasts-structure.jpg)


## <a name="visual"></a>視覚

各トーストでは visual を指定する必要があり、この場所で、テキスト、画像、ロゴなどを含めることができる汎用トースト バインディングを提供する必要があります。 これらの要素は、デスクトップ、電話、タブレット、Xbox など、さまざまな Windows デバイスでレンダリングされます。

visual セクションとその子要素でサポートされているすべての属性については、[スキーマのドキュメント](tiles-and-notifications-toast-schema.md#toastvisual)をご覧ください。

トースト通知ではアプリの識別情報は、アプリ アイコンによって表示されます。 ただし、appLogoOverride を使った場合は、テキスト行の下にアプリ名が表示されます。

| 標準のトースト                                                                              | appLogoOverride を使ったトースト                                                          |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| ![appLogoOverride を使わない通知](images/adaptivetoasts-withoutapplogooverride.jpg) | ![appLogoOverride を使った通知](images/adaptivetoasts-withapplogooverride.jpg) |


## <a name="text-elements"></a>テキスト要素

各トーストには少なくとも 1 つの text 要素が必要で、2 つの text 要素 (すべて [AdaptiveText](tiles-and-notifications-toast-schema.md#adaptivetext) 型) を追加で含めることができます。

![タイトルと説明が含まれたトースト](images/toast-title-and-description.jpg)

Anniversary Update 以降、text で **HintMaxLines** プロパティを使うことによって、表示されるテキストの行数を制御できます。 既定では、タイトルには最大 2 行のテキストが表示され、各説明行には最大 4 行のテキストが表示されます。

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        new AdaptiveText()
        {
            Text = "Adaptive Tiles Meeting",
            HintMaxLines = 1
        },

        new AdaptiveText()
        {
            Text = "Conf Room 2001 / Building 135"
        },

        new AdaptiveText()
        {
            Text = "10:00 AM - 10:30 AM"
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    <text hint-maxLines="1">Adaptive Tiles Meeting</text>
    <text>Conf Room 2001 / Building 135</text>
    <text>10:00 AM - 10:30 AM</text>
</binding>
```


## <a name="app-logo-override"></a>アプリ ロゴの上書き

既定では、トーストにはアプリ ロゴが表示されます。 ただし、このロゴは独自の [ToastGenericAppLogo](tiles-and-notifications-toast-schema.md#toastgenericapplogo) 画像で上書きできます。 たとえば、これがある人からの通知である場合、その人の写真でアプリ ロゴを上書きすることをお勧めします。

![appLogoOverride を使ったトースト](images/toast-applogooverride.jpg)

**HintCrop** プロパティを使って、画像のトリミングを変更できます。 たとえば、*circle* は丸くトリミングされた画像になります。 その他の場合、画像は正方形です。 画像サイズは 100% のスケーリングで 64 x 64 ピクセルです。

```csharp
new ToastBindingGeneric()
{
    ...

    AppLogoOverride = new ToastGenericAppLogo()
    {
        Source = "https://unsplash.it/64?image=883",
        HintCrop = ToastGenericAppLogoCrop.Circle
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image placement="appLogoOverride" hint-crop="circle" src="https://unsplash.it/64?image=883"/>
</binding>
```


## <a name="hero-image"></a>ヒーロー イメージ

**Anniversary Update の新機能**: トーストには、ヒーロー イメージを表示できます。ヒーロー イメージとは、トースト バナー内や、アクション センター内にいるときに、目立つ場所に表示されるおすすめの [ToastGenericHeroImage](tiles-and-notifications-toast-schema.md#toastgenericheroimage) です。 画像サイズは 100% のスケーリングで 360 x 180 ピクセルです。

![ヒーロー イメージが含まれたトースト](images/toast-heroimage.jpg)

```csharp
new ToastBindingGeneric()
{
    ...

    HeroImage = new ToastHeroImage()
    {
        Source = "https://unsplash.it/360/180?image=1043"
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image placement="hero" src="https://unsplash.it/360/180?image=1043"/>
</binding>
```


## <a name="inline-image"></a>インライン画像

トーストを展開したときに表示される全幅のインライン画像を指定できます。

![追加の画像が含まれたトースト](images/toast-additionalimage.jpg)

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        ...

        new AdaptiveImage()
        {
            Source = "https://unsplash.it/360/180?image=1043"
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <image src="https://unsplash.it/360/180?image=1043" />
</binding>
```


## <a name="attribution-text"></a>属性テキスト

**Anniversary Update の新機能**: コンテンツのソースを参照する必要がある場合、属性テキストを使うことができます。 このテキストは常に、アプリの ID または通知のタイムスタンプと共に通知の下部に表示されます。

属性テキストをサポートしていない以前のバージョンの Windows では、テキストは単に別のテキスト要素として表示されます (3 つのテキスト要素を最大限に含めていない場合)。

![属性テキストが含まれたトースト](images/toast-attributiontext.jpg)

```csharp
new ToastBindingGeneric()
{
    ...

    Attribution = new ToastGenericAttributionText()
    {
        Text = "Via SMS"
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <text placement="attribution">Via SMS</text>
</binding>
```


## <a name="custom-timestamp"></a>カスタム タイムスタンプ

**Creators Update の新機能**: システムが提供するタイムスタンプを、メッセージ、情報、コンテンツが生成された時点を正確に表す独自のタイムスタンプで上書きできるようになりました。 このタイムスタンプはアクション センターに表示されます。

![カスタム タイムスタンプが含まれたトースト](images/toast-customtimestamp.jpg)

カスタム タイムスタンプの使用について詳しくは、[このブログ記事](https://blogs.msdn.microsoft.com/tiles_and_toasts/2017/01/09/custom-timestamp-on-toast-notifications-windows-10-creators-update/)をご覧ください。

```csharp
ToastContent toastContent = new ToastContent()
{
    DisplayTimestamp = new DateTime(2017, 04, 15, 19, 45, 00, DateTimeKind.Utc),
    ...
};
```

```xml
<toast displayTimestamp="2017-04-15T19:45:00Z">
  ...
</toast>
```


## <a name="adaptive-content"></a>アダプティブ コンテンツ

**Anniversary Update の新機能**: 上記で指定したコンテンツ以外に、トーストが展開されたときに表示される追加のアダプティブ コンテンツを表示することもできます。

この追加コンテンツは Adaptive を使って指定されます。詳しくは、[アダプティブ タイルのドキュメント](tiles-and-notifications-create-adaptive-tiles.md)をご覧ください。

アダプティブ コンテンツは AdaptiveGroup 内に含める必要があることに注意しください。 それ以外の場合、Adaptive を使ってレンダリングされません。


### <a name="columns-and-text-elements"></a>列とテキスト要素

列といくつかの詳細なアダプティブ テキスト要素が使われている例を次に示します。 テキスト要素は AdaptiveGroup 内にあるので、すべてのリッチ アダプティブ スタイル指定プロパティをサポートします。

![追加のテキストが含まれたトースト](images/toast-additionaltext.jpg)

```csharp
new ToastBindingGeneric()
{
    Children =
    {
        ...

        new AdaptiveGroup()
        {
            Children =
            {
                new AdaptiveSubgroup()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "52 attendees",
                            HintStyle = AdaptiveTextStyle.Base
                        },
                        new AdaptiveText()
                        {
                            Text = "23 minute drive",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle
                        }
                    }
                },
                new AdaptiveSubgroup()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "1 Microsoft Way",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle,
                            HintAlign = AdaptiveTextAlign.Right
                        },
                        new AdaptiveText()
                        {
                            Text = "Bellevue, WA 98008",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle,
                            HintAlign = AdaptiveTextAlign.Right
                        }
                    }
                }
            }
        }
    }
}
```

```xml
<binding template="ToastGeneric">
    ...
    <group>
        <subgroup>
            <text hint-style="base">52 attendees</text>
            <text hint-style="captionSubtle">23 minute drive</text>
        </subgroup>
        <subgroup>
            <text hint-style="captionSubtle" hint-align="right">1 Microsoft Way</text>
            <text hint-style="captionSubtle" hint-align="right">Bellevue, WA 98008</text>
        </subgroup>
    </group>
</binding>
```


## <a name="inputs-and-buttons"></a>入力とボタン

入力とボタンはトーストのトースト領域の Actions 領域内で指定されます。つまり、トーストが展開されたときにのみ表示されます。


### <a name="quick-reply-text-box"></a>クイック返信テキスト ボックス

クイック返信テキスト ボックスを有効にするには、メッセージング シナリオの場合と同様、テキスト入力とボタンを追加し、テキスト入力の ID を参照してボタンが入力の横に表示されるようにします。

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample05.jpg)

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastTextBox("tbReply")
            {
                PlaceholderContent = "Type a reply"
            }
        },

        Buttons =
        {
            new ToastButton("Reply", "action=reply&convId=9318")
            {
                ActivationType = ToastActivationType.Background,

                // To place the button next to the text box,
                // reference the text box's Id and provide an image
                TextBoxId = "tbReply",
                ImageUri = "Assets/Reply.png"
            }
        }
    }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <input id="textBox" type="text" placeholderContent="Type a reply"/>

        <action
            content="Send",
            arguments="action=reply&amp;convId=9318"
            activationType="background"
            hint-inputId="textBox"
            imageUri="Assets/Reply.png"/>

    </actions>

</toast>
```


### <a name="inputs-with-buttons-bar"></a>入力とボタンのバー

1 つ (または複数) の入力と、入力の下に表示する通常のボタンを設定することもできます。

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample04.jpg)

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastTextBox("tbReply")
            {
                PlaceholderContent = "Type a reply"
            }
        },

        Buttons =
        {
            new ToastButton("Reply", "action=reply&threadId=9218")
            {
                ActivationType = ToastActivationType.Background
            },

            new ToastButton("Video call", "action=videocall&threadId=9218")
            {
                ActivationType = ToastActivationType.Foreground
            }
        }
    }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <input id="textBox" type="text" placeholderContent="Type a reply"/>

        <action
            content="Reply",
            arguments="action=reply&amp;threadId=9218"
            activationType="background"/>

        <action
            content="Video call",
            arguments="action=videocall&amp;threadId=9218"
            activationType="foreground"/>

    </actions>

</toast>
```


### <a name="selection-input"></a>選択入力

テキスト ボックスに加えて、選択メニューを使うこともできます。

![選択入力と操作を使った通知](images/adaptivetoasts-xmlsample06.jpg)

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastSelectionBox("time")
            {
                DefaultSelectionBoxItemId = "lunch",
                Items =
                {
                    new ToastSelectionBoxItem("breakfast", "Breakfast"),
                    new ToastSelectionBoxItem("lunch", "Lunch"),
                    new ToastSelectionBoxItem("dinner", "Dinner")
                }
            }
        },

        Buttons = { ... }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <input id="time" type="selection" defaultInput="lunch">
            <selection id="breakfast" content="Breakfast" />
            <selection id="lunch" content="Lunch" />
            <selection id="dinner" content="Dinner" />
        </input>

        ...

    </actions>

</toast>
```


## <a name="buttons"></a>ボタン

Buttons を使うとトーストを対話的にすることができ、ユーザーはトースト通知に対してクイック アクションを実行できます。その際、現在のワークフローは中断されません。 たとえば、ユーザーはトースト内からメッセージに直接返信したり、メール アプリを開かずにメールを削除することができます。

Buttons は次のようなさまざまな操作を実行できます。

-   特定のページやコンテキストへの移動に使うことができる引数を指定して、アプリをフォアグラウンドでアクティブ化します。
-   クイック返信や同様のシナリオで、アプリのバックグラウンド タスクをアクティブ化します。
-   プロトコル起動を利用して別のアプリをアクティブ化します。
-   再通知や通知を閉じるなどのシステム操作を実行します。

設定できるボタン (後ほど説明するコンテキスト メニュー項目を含む) の数は最大 5 つであることに注意してください。

![操作を使った通知の例 1](images/adaptivetoasts-xmlsample02.jpg)

```csharp
ToastContent content = new ToastContent()
{
    ...
 
    Actions = new ToastActionsCustom()
    {
        Buttons =
        {
            new ToastButton("See more details", "action=viewdetails&contentId=351")
            {
                ActivationType = ToastActivationType.Foreground
            },

            new ToastButton("Remind me later", "action=remindlater&contentId=351")
            {
                ActivationType = ToastActivationType.Background
            }
        }
    }
};
```

```xml
<toast launch="app-defined-string">

    ...

    <actions>

        <action
            content="See more details",
            arguments="action=viewdetails&amp;contentId=351"
            activationType="foreground"/>

        <action
            content="Remind me later",
            arguments="action=remindlater&amp;contentId=351"
            activationType="background"/>

    </actions>

</toast>
```


### <a name="snoozedismiss-buttons"></a>再通知ボタンと閉じるボタン

選択メニューと 2 つのボタンを使って、システムの再通知操作と閉じる操作を利用するリマインダー通知を作成できます。 シナリオに Reminder を設定して、通知がリマインダーのように動作するようにしてください。

![リマインダー通知](images/adaptivetoasts-xmlsample07.jpg)

ここでは、トースト ボタンに *SelectionBoxId* プロパティを使って、[Snooze] (再通知) ボタンを選択メニューの入力に関連付けています。

```csharp
ToastContent content = new ToastContent()
{
    Scenario = ToastScenario.Reminder,

    ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastSelectionBox("snoozeTime")
            {
                DefaultSelectionBoxItemId = "15",
                Items =
                {
                    new ToastSelectionBoxItem("5", "5 minutes"),
                    new ToastSelectionBoxItem("15", "15 minutes"),
                    new ToastSelectionBoxItem("60", "1 hour"),
                    new ToastSelectionBoxItem("240", "4 hours"),
                    new ToastSelectionBoxItem("1440", "1 day")
                }
            }
        },

        Buttons =
        {
            new ToastButtonSnooze()
            {
                SelectionBoxId = "snoozeTime"
            },
 
            new ToastButtonDismiss()
        }
    }
};
```

```xml
<toast scenario="reminder" launch="action=viewEvent&amp;eventId=1983">
   
  ...
 
  <actions>
     
    <input id="snoozeTime" type="selection" defaultInput="15">
      <selection id="1" content="1 minute"/>
      <selection id="15" content="15 minutes"/>
      <selection id="60" content="1 hour"/>
      <selection id="240" content="4 hours"/>
      <selection id="1440" content="1 day"/>
    </input>
 
    <action activationType="system" arguments="snooze" hint-inputId="snoozeTime" content="" />
 
    <action activationType="system" arguments="dismiss" content=""/>
     
  </actions>
   
</toast>
```

システムの再通知操作と閉じる操作を使うには、次の操作を行います。

-   ToastButtonSnooze または ToastButtonDismiss を指定する
-   必要に応じてカスタムのコンテンツ文字列を指定する
    -   文字列を指定しない場合、"Snooze" と "Dismiss" のローカライズされた文字列が自動的に使われます。
-   必要に応じて *SelectionBoxId* を指定する
    -   再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。
    -   再通知の間隔に関する選択項目を指定する場合:
        -   再通知操作に *SelectionBoxId* を指定する
        -   input の id に、再通知操作の *SelectionBoxId* と同じ値を指定する
        -   *ToastSelectionBoxItem* の値を、再通知の間隔を分単位で表す nonNegativeInteger になるよう指定する



## <a name="audio"></a>オーディオ

カスタム オーディオは、Mobile では常にサポートされ、Desktop では Version 1511 (ビルド 10586) 以降でサポートされます。 カスタム オーディオは次のパスで参照できます。

-   ms-appx:///
-   ms-appdata:///

または、[ms-winsoundevent の一覧に関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)から選ぶこともできます。これらは、常に両方のプラットフォームでサポートされます。

```csharp
ToastContent content = new ToastContent()
{
    ...

    Audio = new ToastAudio()
    {
        Src = new Uri("ms-appx:///Assets/NewMessage.mp3")
    }
}
```

```xml
<toast launch="app-defined-string">

    ...

    <audio src="ms-appx:///Assets/NewMessage.mp3"/>

</toast>
```

トースト通知でのオーディオについては、[オーディオ スキーマに関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。 カスタム オーディオを使うトーストを送信する方法については、[このブログ記事](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/06/18/quickstart-sending-a-toast-notification-with-custom-audio/)をご覧ください。


## <a name="alarms-reminders-and-incoming-calls"></a>アラーム、リマインダー、着信呼び出し

アラーム、リマインダー、着信呼び出しの通知を作成するには、単にシナリオの値が割り当てられた標準のトースト通知を使います。 シナリオではいくつかの動作を調整し、一貫性のある統一されたユーザー エクスペリエンスを作成します。

* **Reminder**: 通知は、ユーザーが通知を閉じるか、操作を実行するまで画面上に表示されたままになります。 Windows Mobile では、トーストは既に展開された状態で表示されます。 リマインダー音が再生されます。
* **Alarm**: リマインダーの動作に加えて、アラームは既定のアラーム音を使ってオーディオをループします。
* **IncomingCall**: 着信呼び出し通知は、Windows Mobile デバイスでは全画面で表示されます。 その他の点では、着信音オーディオを使う点を除き、アラームと同じ動作です。

```csharp
ToastContent content = new ToastContent()
{
    Scenario = ToastScenario.Reminder,

    ...
}
```

```xml
<toast scenario="reminder" launch="app-defined-string">

    ...

</toast>
```


## <a name="handling-activation"></a>アクティブ化の処理
トーストのアクティブ化を処理する方法 (ユーザーがトーストをクリックするか、トースト上のボタンをクリックする) については、「[ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)」をご覧ください。


 
## <a name="related-topics"></a>関連トピック

* [ローカル トースト通知の送信](tiles-and-notifications-send-local-toast.md)
* [GitHub の Notifications ライブラリ](https://github.com/Microsoft/UWPCommunityToolkit/tree/dev/Notifications)