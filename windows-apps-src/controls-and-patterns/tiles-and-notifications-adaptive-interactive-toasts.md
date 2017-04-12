---
author: mijacobs
Description: "アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。"
title: "アダプティブ トースト通知と対話型トースト通知"
ms.assetid: 1FCE66AF-34B4-436A-9FC9-D0CF4BDA5A01
label: Adaptive and interactive toast notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: d9808feeabfa4ffce19d0e669352331804dfd751
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="adaptive-and-interactive-toast-notifications"></a>アダプティブ トースト通知と対話型トースト通知

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。

アダプティブ トースト通知と対話型トースト通知のモデルでは、従来のトースト テンプレート カタログについて、次の更新が行われています。

-   通知にボタンや入力を追加するためのオプション。
-   メインのトースト通知や各操作用の 3 つの異なるアクティブ化の種類。
-   特定のシナリオ (アラーム、リマインダー、着信呼び出しなど) 向けの通知を作成するためのオプション。

**注**   Windows 8.1 や Windows Phone 8.1 の従来のテンプレートについては、「[トースト テンプレート カタログ (Windows ランタイム アプリ)](https://msdn.microsoft.com/library/windows/apps/hh761494)」をご覧ください。


## <a name="getting-started"></a>概要

**Notifications ライブラリをインストールします。** XML の代わりに C# を使って通知を生成する場合は、[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) という名前の NuGet パッケージをインストールします (「notifications uwp」を検索してください)。 この記事で示している C# のサンプルでは、NuGet パッケージの Version 1.0.0 を使っています。

**Notifications Visualizer をインストールします。** この無料の UWP アプリは、Visual Studio の XAML エディター/デザイン ビューと同様、トーストの編集時に視覚的なプレビューが即座に表示されるため、対話型トースト通知のデザインに便利です。 詳しくは、[このブログ記事](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/09/22/introducing-notifications-visualizer-for-windows-10.aspx)をご覧ください。Notifications Visualizer は[こちら](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)からダウンロードできます。


## <a name="toast-notification-structure"></a>トースト通知の構造体


トースト通知は XML を使って作成され、通常、次の主要な要素を含んでいます。

-   &lt;visual&gt; では、ユーザーが視覚的に確認できるコンテンツ (テキストや画像など) を扱います。
-   &lt;actions&gt; には、開発者が通知内に追加するボタンや入力が含まれます。
-   &lt;audio&gt; では、通知が表示されるときに再生されるサウンドを指定します。

次にコード例を示します。

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Sample</text>
      <text>This is a simple toast notification example</text>
      <image placement="AppLogoOverride" src="oneAlarm.png" />
    </binding>
  </visual>
  <actions>
    <action content="check" arguments="check" imageUri="check.png" />
    <action content="cancel" arguments="cancel" />
  </actions>
  <audio src="ms-winsoundevent:Notification.Reminder"/>
</toast>
```

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Sample"
                },
 
                new AdaptiveText()
                {
                    Text = "This is a simple toast notification example"
                }
            },
 
            AppLogoOverride = new ToastGenericAppLogo()
            {
                Source = "oneAlarm.png"
            }
        }
    },
 
    Actions = new ToastActionsCustom()
    {
        Buttons =
        {
            new ToastButton("check", "check")
            {
                ImageUri = "check.png"
            },
 
            new ToastButton("cancel", "cancel")
            {
                ImageUri = "cancel.png"
            }
        }
    },
 
    Audio = new ToastAudio()
    {
        Src = new Uri("ms-winsoundevent:Notification.Reminder")
    }
};
```

次に、トーストを [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) オブジェクトに変換する必要があります。 トーストを (ここでは content.xml という名前の) XML ファイル内で定義する場合、次のコードを使用します。

```CSharp
string xmlText = File.ReadAllText("content.xml");
XmlDocument xmlContent = new XmlDocument();
xmlContent.LoadXml(xmlText);
```

または、C# でトースト テンプレートを定義する場合、次を使用します。

```CSharp
XmlDocument xmlContent = content.GetXml();
```

その後、XMLDocument の作成方法に関係なく、次のコードを使ってそのトーストを作成および送信できます。

```CSharp
ToastNotification notification = new ToastNotification(xmlContent);
ToastNotificationManager.CreateToastNotifier().Show(notification);
```

トースト通知を表示する完全なアプリの例については、「[Quickstart on Sending a local toast notifications (ローカル トースト通知の送信に関するクイック スタート)](https://github.com/WindowsNotifications/quickstart-sending-local-toast-win10)」をご覧ください。

構造体の視覚的な表示は、次のようになります。

![トースト通知の構造体](images/adaptivetoasts-structure.jpg)

### <a name="visual"></a>視覚

visual 要素内には、トースト通知の視覚的なコンテンツを含んだ binding 要素を 1 つだけ指定する必要があります。

ユニバーサル Windows プラットフォーム (UWP) アプリのタイル通知では、さまざまなタイル サイズに基づく複数のテンプレートをサポートしています。 ただし、トースト通知が保持できるテンプレート名は、1 つだけです (**ToastGeneric**)。 保持できるテンプレート名が 1 つだけということは、次のことを意味しています。

-   トースト通知のコンテンツを変更できます。つまり、新しいテキスト行やインライン画像の追加、アプリ アイコンから他の画像へのサムネイル イメージの変更などを行うことができます。また、これらの操作を行う場合、テンプレート名とコンテンツの不一致が原因となって、テンプレート全体の変更や無効なペイロードの作成が行われることを考慮する必要はありません。
-   さまざまな種類の Microsoft Windows デバイス (電話、タブレット、PC、Xbox One など) への配信を目的とした**トースト通知**用に同一のペイロードを作成するとき、同じコードを使うことができます。 これらの各デバイスでは、通知を受け取ると、その通知を UI ポリシーに基づいてユーザーに表示します。このとき、適切な視覚的アフォーダンスと操作モデルが使われます。

visual セクションとその子要素でサポートされているすべての属性については、後で説明する「スキーマ」セクションをご覧ください。 その他の例については、以下の「XML の例」セクションをご覧ください。

アプリの識別情報はアプリ アイコンによって表示されます。 ただし、appLogoOverride を使用した場合は、テキスト行の下にアプリ名が表示されます。

| 標準のトースト                                                                              | appLogoOverride を使ったトースト                                                          |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| ![appLogoOverride を使わない通知](images/adaptivetoasts-withoutapplogooverride.jpg) | ![appLogoOverride を使った通知](images/adaptivetoasts-withapplogooverride.jpg) |

### <a name="actions"></a>操作

UWP アプリでは、ボタンや他の入力をトースト通知に追加できます。これにより、ユーザーはアプリの外部で、より多くの操作を実行できるようになります。 これらの操作は &lt;actions&gt; 要素の下に指定します。指定できる操作は 2 種類あります。

-   &lt;action&gt; これは、デスクトップ デバイスやモバイル デバイスでボタンとして表示されます。 トースト通知内では、カスタム操作やシステム操作は最大 5 つまで指定できます。
-   &lt;input&gt; これを使うと、ユーザーは入力を提供できます (メッセージにすばやく応答したり、ドロップダウン メニューからオプションを選んだりすることができます)。

&lt;action&gt; と &lt;input&gt; はどちらも、Windows デバイス ファミリ内ではアダプティブです。 たとえば、モバイル デバイスやデスクトップ デバイスでは、ユーザーに対する &lt;action&gt; は、タップまたはクリックされるボタンとして表示されます。 &lt;input&gt; のテキストはボックスとして表示され、ユーザーは物理的なキーボードやスクリーン キーボードを使ってテキストを入力できます。 これらの要素は、将来の操作のシナリオ (音声によって指示される操作やディクテーションに基づくテキスト入力など) にも対応する予定です。

&lt;action&gt; 要素内に [**ActivationType**](https://msdn.microsoft.com/library/windows/desktop/dn408447) 属性を指定することで、ユーザーが操作を実行したとき、次のいずれかを実行できます。

-   特定のページやコンテキストへの移動に使うことができる操作固有の引数を指定して、アプリをフォアグラウンドでアクティブ化します。
-   ユーザーに影響を与えずに、アプリのバックグラウンド タスクをアクティブ化します。
-   プロトコル起動を利用して別のアプリをアクティブ化します。
-   実行するシステム操作を指定します。 現在利用可能なシステム操作は、スケジュールされたアラームやリマインダーを再通知したり、閉じたりする操作です。これらの操作については、後のセクションで説明します。

visual セクションとその子要素でサポートされているすべての属性については、後で説明する「スキーマ」セクションをご覧ください。 その他の例については、以下の「XML の例」セクションをご覧ください。

### <a name="audio"></a>オーディオ

カスタム オーディオは、Mobile では常にサポートされ、Desktop では Version 1511 (ビルド 10586) 以降でサポートされます。 カスタム オーディオは次のパスで参照できます。

-   ms-appx:///
-   ms-appdata:///

または、[ms-winsoundevent の一覧に関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)から選ぶこともできます。これらは、常に両方のプラットフォームでサポートされます。

トースト通知でのオーディオについては、[オーディオ スキーマに関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。 カスタム オーディオを使うトーストを送信する方法については、[このブログ記事](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/06/18/quickstart-sending-a-toast-notification-with-custom-audio/)をご覧ください。

## <a name="alarms-reminders-and-incoming-calls"></a>アラーム、リマインダー、着信呼び出し


アラーム、リマインダー、着信呼び出し用にトースト通知を使うことができます。 これらの特別なトースト通知の外観は標準のトースト通知と同じですが、特別なトースト通知では、シナリオ ベースのカスタムの UI とパターンを利用できます。

-   リマインダーのトースト通知は、ユーザーが通知を閉じるか、操作を実行するまで画面上に表示されたままになります。 Windows Mobile では、リマインダーのトースト通知は既に展開された状態で表示されます。
-   アラーム通知では、上記の動作をリマインダー通知と共有するだけでなく、ループするオーディオを自動的に再生します。
-   着信呼び出し通知は、Windows Mobile デバイスでは全画面で表示されます。 この動作は、トースト通知のルート要素 (&lt;toast&gt;) 内に scenario 属性を指定することによって実行されます。&lt;toast scenario=" { default | alarm | reminder | incomingCall } " &gt;

## <a name="xml-examples"></a>XML の例


**注**  以下の例で示されているトースト通知のスクリーン ショットは、デスクトップ上のアプリから取得したものです。 モバイル デバイスでは、トースト通知は折りたたまれて表示される場合があります。このとき、トースト通知の下部には通知を展開するためのグラバーが表示されます。

 

**リッチ ビジュアル コンテンツを使った通知**

この例では、複数行のテキスト、アプリケーション ロゴを上書きするオプションの画像、オプションのインライン画像のサムネイルを使う方法を示しています。

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Photo Share</text>
      <text>Andrew sent you a picture</text>
      <text>See it in full size!</text>
      <image src="https://unsplash.it/360/180?image=1043" />
      <image placement="appLogoOverride" src="https://unsplash.it/64?image=883" hint-crop="circle" />
    </binding>
  </visual>
</toast>
```

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Photo Share"
                },
 
                new AdaptiveText()
                {
                    Text = "Andrew sent you a picture"
                },
 
                new AdaptiveText()
                {
                    Text = "See it in full size!"
                },
 
                new AdaptiveImage()
                {
                    Source = "https://unsplash.it/360/180?image=1043"
                }
            },
 
            AppLogoOverride = new ToastGenericAppLogo()
            {
                Source = "https://unsplash.it/64?image=883",
                HintCrop = ToastGenericAppLogoCrop.Circle
            }
        }
    }
};
```

![リッチ ビジュアル コンテンツを使った通知](images/adaptivetoasts-xmlsample01.jpg)

 

**操作を使った通知**

この例では、2 つの応答操作が可能な通知を作成します。

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Microsoft Company Store</text>
      <text>New Halo game is back in stock!</text>
    </binding>
  </visual>
  <actions>
    <action activationType="foreground" content="See more details" arguments="details"/>
    <action activationType="background" content="Remind me later" arguments="later"/>
  </actions>
</toast>
```

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Microsoft Company Store"
                },
 
                new AdaptiveText()
                {
                    Text = "New Halo game is back in stock!"
                }
            }
        }
    },
 
    Actions = new ToastActionsCustom()
    {
        Buttons =
        {
            new ToastButton("See more details", "details"),
 
            new ToastButton("Remind me later", "later")
            {
                ActivationType = ToastActivationType.Background
            }
        }
    }
};
```

![操作を使った通知の例 1](images/adaptivetoasts-xmlsample02.jpg)



**テキスト入力と操作を使った通知の例 1**

この例では、2 つの応答操作に加えて、テキスト入力を受け取る通知を作成します。

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Andrew B.</text>
      <text>Shall we meet up at 8?</text>
      <image placement="appLogoOverride" src="https://unsplash.it/64?image=883" hint-crop="circle" />
    </binding>
  </visual>
  <actions>
    <input id="message" type="text" placeHolderContent="Type a reply" />
    <action activationType="background" content="Reply" arguments="reply" />
    <action activationType="foreground" content="Video call" arguments="video" />
  </actions>
</toast>
```

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Andrew B."
                },
 
                new AdaptiveText()
                {
                    Text = "Shall we meet up at 8?"
                }
            },
 
            AppLogoOverride = new ToastGenericAppLogo()
            {
                Source = "https://unsplash.it/64?image=883",
                HintCrop = ToastGenericAppLogoCrop.Circle
            }
        }
    },
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastTextBox("message")
            {
                PlaceholderContent = "Type a reply"
            }
        },
 
        Buttons =
        {
            new ToastButton("Reply", "reply")
            {
                ActivationType = ToastActivationType.Background
            },
 
            new ToastButton("Video call", "video")
            {
                ActivationType = ToastActivationType.Foreground
            }
        }
    }
};
```

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample04.jpg)

 

**テキスト入力と操作を使った通知の例 2**

この例では、テキスト入力と単一の操作を受け取る通知を作成します。

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Andrew B.</text>
      <text>Shall we meet up at 8?</text>
      <image placement="appLogoOverride" src="https://unsplash.it/64?image=883" hint-crop="circle" />
    </binding>
  </visual>
  <actions>
    <input id="message" type="text" placeHolderContent="Type a reply" />
    <action activationType="background" content="Reply" arguments="reply" hint-inputId="message" imageUri="Assets/Icons/send.png"/>
  </actions>
</toast>
```

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Andrew B."
                },
 
                new AdaptiveText()
                {
                    Text = "Shall we meet up at 8?"
                }
            },
 
            AppLogoOverride = new ToastGenericAppLogo()
            {
                Source = "https://unsplash.it/64?image=883",
                HintCrop = ToastGenericAppLogoCrop.Circle
            }
        }
    },
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastTextBox("message")
            {
                PlaceholderContent = "Type a reply"
            }
        },
 
        Buttons =
        {
            new ToastButton("Reply", "reply")
            {
                TextBoxId = "message",
                ImageUri = "Assets/Icons/send.png",
                ActivationType = ToastActivationType.Background
            }
        }
    }
};
```

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample05.jpg)

 

**選択入力と操作を使った通知**

この例では、ドロップダウン選択メニューと、2 つの実行可能な操作を使った通知を作成します。

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Spicy Heaven</text>
      <text>When do you plan to come in tomorrow?</text>
    </binding>
  </visual>
  <actions>
    <input id="time" type="selection" defaultInput="2" >
      <selection id="1" content="Breakfast" />
      <selection id="2" content="Lunch" />
      <selection id="3" content="Dinner" />
    </input>
    <action activationType="background" content="Reserve" arguments="reserve" />
    <action activationType="foreground" content="Call Restaurant" arguments="call" />
  </actions>
</toast>
```

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "app-defined-string",
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Spicy Heaven"
                },
 
                new AdaptiveText()
                {
                    Text = "When do you plan to come in tomorrow?"
                }
            }
        }
    },
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastSelectionBox("time")
            {
                DefaultSelectionBoxItemId = "2",
                Items =
                {
                    new ToastSelectionBoxItem("1", "Breakfast"),
                    new ToastSelectionBoxItem("2", "Lunch"),
                    new ToastSelectionBoxItem("3", "Dinner")
                }
            }
        },
 
        Buttons =
        {
            new ToastButton("Reserve", "reserve")
            {
                ActivationType = ToastActivationType.Background
            },
 
            new ToastButton("Call Restaurant", "call")
            {
                ActivationType = ToastActivationType.Foreground
            }
        }
    }
};
```

![選択入力と操作を使った通知](images/adaptivetoasts-xmlsample06.jpg)

 

**リマインダー通知**

前の例のように選択メニューと 2 つの操作を使用して、リマインダー通知を作成できます。

```XML
<toast scenario="reminder" launch="action=viewEvent&amp;eventId=1983">
   
  <visual>
    <binding template="ToastGeneric">
      <text>Adaptive Tiles Meeting</text>
      <text>Conf Room 2001 / Building 135</text>
      <text>10:00 AM - 10:30 AM</text>
    </binding>
  </visual>
 
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

```CSharp
ToastContent content = new ToastContent()
{
    Launch = "action=viewEvent&eventId=1983",
    Scenario = ToastScenario.Reminder,
 
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Adaptive Tiles Meeting"
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
    },
 
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

![リマインダー通知](images/adaptivetoasts-xmlsample07.jpg)

 

## <a name="handling-activation-foreground-and-background"></a>アクティブ化の処理 (フォアグラウンドとバックグラウンド)

トーストのアクティブ化 (ユーザーによるトーストまたはトースト上のボタンのクリック) を処理する方法については、「[Quicstart: Sending a local toast notification and handling activation (クイックスタート: ローカル トースト通知の送信とアクティブ化の処理)](https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/quickstart-sending-a-local-toast-notification-and-handling-activations-from-it-windows-10/)」をご覧ください。


## <a name="schemas-ltvisualgt-and-ltaudiogt"></a>スキーマ: &lt;visual&gt; と &lt;audio&gt;


次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。

```
<toast launch? duration? activationType? scenario? >
  <visual lang? baseUri? addImageQuery? >
    <binding template? lang? baseUri? addImageQuery? >
      <text lang? hint-maxLines? >content</text>
      <image src placement? alt? addImageQuery? hint-crop? />
      <group>
        <subgroup hint-weight? hint-textStacking? >
          <text />
          <image />
        </subgroup>
      </group>
    </binding>
  </visual>
  <audio src? loop? silent? />
</toast>
```

```
ToastContent content = new ToastContent()
{
    Launch = ?,
    Duration = ?,
    ActivationType = ?,
    Scenario = ?,
 
    Visual = new ToastVisual()
    {
        Language = ?,
        BaseUri = ?,
        AddImageQuery = ?,
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = ?,
                    Language = ?,
                    HintMaxLines = ?
                },
 
                new AdaptiveGroup()
                {
                    Children =
                    {
                        new AdaptiveSubgroup()
                        {
                            HintWeight = ?,
                            HintTextStacking = ?,
                            Children =
                            {
                                new AdaptiveText(),
                                new AdaptiveImage()
                            }
                        }
                    }
                },
 
                new AdaptiveImage()
                {
                    Source = ?,
                    AddImageQuery = ?,
                    AlternateText = ?,
                    HintCrop = ?
                }
            }
        }
    },
 
    Audio = new ToastAudio()
    {
        Src = ?,
        Loop = ?,
        Silent = ?
    }
};
```

**&lt;toast> 内の属性&gt;**

launch?

-   launch?  = 文字列
-   この属性は省略可能です。
-   トースト通知によってアプリケーションがアクティブ化されるときにアプリケーションに渡される文字列です。
-   activationType の値に応じて、この値は、フォアグラウンドのアプリ、バックグラウンド タスクの内部、または元のアプリからプロトコル起動された他のアプリで取得することができます。
-   この文字列の形式とコンテンツは、アプリ独自の使用方法に合わせて、アプリによって定義されます。
-   ユーザーがトースト通知をタップまたはクリックし、関連するアプリを起動すると、そのアプリは既定の方法で起動されるのではなく、起動文字列によって、そのコンテキストがアプリに渡され、トースト通知のコンテンツに関連するビューがユーザーに表示されます。
-   ユーザーがトースト通知の本文ではなく操作をクリックしたことによってアクティブ化が行われた場合、&lt;toast&gt; タグ内に定義済みの "launch" ではなく、&lt;action&gt; タグ内に事前に定義されている "arguments" が取得されます。

duration?

-   duration?  = "short|long"
-   この属性は省略可能です。 既定値は "short" です。
-   これは、特定のシナリオやアプリケーションの互換性のみを目的とした属性です。 アラーム シナリオでは、この属性は必要ありません。
-   このプロパティを使うことはお勧めしません。

activationType?

-   activationType?  = "foreground | background | protocol | system"
-   この属性は省略可能です。
-   既定値は "foreground" です。

scenario?

-   scenario?  = "default | alarm | reminder | incomingCall"
-   この属性は省略可能です。既定値は "default" です。
-   シナリオがアラーム、リマインダー、着信呼び出しの表示以外の場合、この属性は必要ありません。
-   通知を常に画面上に表示することのみを目的とする場合は、この属性を使わないでください。

**&lt;visual> 内の属性&gt;**

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

baseUri?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;binding> 内の属性&gt;**

template?

-   \[重要\] template?  = "ToastGeneric"
-   新しいアダプティブ通知と対話型通知の機能を使う場合は、従来のテンプレートではなく、必ず "ToastGeneric" テンプレートを使って作業を始めてください。
-   新しい操作で従来のテンプレートを使うと、現時点では動作する可能性があります。ただし、この方法は対象となる使用方法ではないため、今後も引き続き動作するかどうかは保証できません。

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

baseUri?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;text> 内の属性&gt;**

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;image> 内の属性&gt;**

src

-   この必須の属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

placement?

-   placement?  = "inline" | "appLogoOverride"
-   この属性は省略可能です。
-   この属性は、画像が表示される場所を指定します。
-   "inline" は、トースト通知本文内のテキストの下に表示されることを意味します。"appLogoOverride" は、アプリケーション アイコン (トースト通知の左上隅に表示される) を置き換えることを意味します。
-   各 placement の値に指定できる画像は 1 つまでです。

alt?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

hint-crop?

-   hint-crop?  = "none" | "circle"
-   この属性は省略可能です。
-   既定値は "none" であり、トリミングされないことを意味します。
-   "circle" を指定すると、画像が円形にトリミングされます。 連絡先のプロフィール画像、人物の画像などにこの属性を使います。

**&lt;audio> 内の属性&gt;**

src?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。

loop?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。

silent?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。

## <a name="schemas-ltactiongt"></a>スキーマ: &lt;action&gt;


次の XML スキーマで、"?" サフィックスは属性が省略可能であることを意味します。

```
<toast>
  <visual>
  </visual>
  <audio />
  <actions>
    <input id type title? placeHolderContent? defaultInput? >
      <selection id content />
    </input>
    <action content arguments activationType? imageUri? hint-inputId />
  </actions>
</toast>
```

```
ToastContent content = new ToastContent()
{
    Visual = ...
 
    Actions = new ToastActionsCustom()
    {
        Inputs =
        {
            new ToastSelectionBox("id")
            {
                Title = ?
                DefaultSelectionBoxItemId = ?,
                Items =
                {
                    new ToastSelectionBoxItem("id", "content")
                }
            },
 
            new ToastTextBox("id")
            {
                Title = ?,
                PlaceholderContent = ?,
                DefaultInput = ?
            }
        },
 
        Buttons =
        {
            new ToastButton("content", "args")
            {
                ActivationType = ?,
                ImageUri = ?,
                TextBoxId = ?
            },
 
            new ToastButtonSnooze("content")
            {
                SelectionBoxId = "snoozeTime"
            },
 
            new ToastButtonDismiss("content")
        }
    }
};
```

**&lt;input> 内の属性&gt;**

id

-   id = 文字列
-   この属性は必須です。
-   id 属性は必須の属性であり、アプリが (フォアグラウンドまたはバックグラウンドで) アクティブ化されたときにユーザー入力を取得するために使われます。

type

-   type = "text | selection"
-   この属性は必須です。
-   この属性を使って、テキスト入力であるか、事前に定義された選択項目の一覧からの入力であるかを指定します。
-   モバイルやデスクトップでは、この属性は、テキスト ボックスによる入力を使うか、リスト ボックスによる入力を使うかを指定します。

title?

-   title?  = 文字列
-   title 属性は省略可能です。開発者は、シェルの入力に対してタイトルを指定し、アフォーダンスがあるときに表示します。
-   モバイルやデスクトップでは、入力の上にこのタイトルが表示されます。

placeHolderContent?

-   placeHolderContent?  = 文字列
-   placeHolderContent 属性は省略可能です。入力の種類が text の場合に、ヒントのテキストを灰色で表示します。 入力の種類が "text" 以外の場合、この属性は無視されます。

defaultInput?

-   defaultInput?  = 文字列
-   defaultInput 属性は省略可能です。既定の入力値を指定するために使われます。
-   入力の種類が "text" である場合、この属性は文字列入力として処理されます。
-   入力の種類が "selection" である場合、この属性は、入力の要素内で利用できるいずれかの選択項目の ID として処理されます。

**&lt;selection> 内の属性&gt;**

id

-   この属性は必須です。 ユーザーの選択項目を特定するために使われます。 id はアプリに返されます。

content

-   この属性は必須です。 この selection 要素に対して表示する文字列を指定します。

**&lt;action> 内の属性&gt;**

content

-   content = 文字列
-   content 属性は必須です。 ボタンに表示されるテキスト文字列を指定します。

arguments

-   arguments = 文字列
-   arguments 属性は必須です。 この属性は、アプリによって定義されたデータを表します。ユーザーがこの action を実行し、アプリがアクティブ化された後で、アプリはこのデータを取得することができます。

activationType?

-   activationType?  = "foreground | background | protocol | system"
-   activationType 属性は省略可能です。既定値は "foreground" です。
-   この属性は、この action によって行われるアクティブ化の種類を表します (フォアグラウンド、バックグラウンド、プロトコル起動による別のアプリの起動、またはシステム操作の呼び出し)。

imageUri?

-   imageUri?  = 文字列
-   imageUri は省略可能です。この action 用の画像アイコンを指定するために使われます。このアイコンは、テキスト コンテンツと共にボタン内に表示されます。

hint-inputId

-   hint-inputId = 文字列
-   hint-inpudId 属性は必須です。 特に、すばやく応答するシナリオで使われます。
-   値は、この属性に関連付ける必要がある入力要素の ID にする必要があります。
-   モバイルやデスクトップでは、この属性によって、入力ボックスのすぐ横にボタンが配置されます。

## <a name="attributes-for-system-handled-actions"></a>システムによって処理される操作の属性


アプリで再通知や通知の再スケジュールをバックグラウンド タスクとして処理しない場合は、システムで、再通知や通知を閉じるための操作を処理できます。 システムによって処理される操作は、組み合わせることができます (または個別に指定することもできます)。ただし、閉じる操作を使わないで再通知の操作を実装することはお勧めしません。

システム コマンドの組み合わせ: SnoozeAndDismiss

```
<toast>
  <visual>
  </visual>
  <actions hint-systemCommands="SnoozeAndDismiss" />
</toast>
```

```
ToastContent content = new ToastContent()
{
    Visual = ...
 
    Actions = new ToastActionsSnoozeAndDismiss()
};
```

システムによって処理される操作を個別に指定

```
<toast>
  <visual>
  </visual>
  <actions>
  <input id="snoozeTime" type="selection" defaultInput="10">
    <selection id="5" content="5 minutes" />
    <selection id="10" content="10 minutes" />
    <selection id="20" content="20 minutes" />
    <selection id="30" content="30 minutes" />
    <selection id="60" content="1 hour" />
  </input>
  <action activationType="system" arguments="snooze" hint-inputId="snoozeTime" content=""/>
  <action activationType="system" arguments="dismiss" content=""/>
  </actions>
</toast>
```

```
ToastContent content = new ToastContent()
{
    Visual = ...
 
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
                    new ToastSelectionBoxItem("10", "10 minutes"),
                    new ToastSelectionBoxItem("20", "20 minutes"),
                    new ToastSelectionBoxItem("30", "30 minutes"),
                    new ToastSelectionBoxItem("60", "1 hour")
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

再通知や閉じる操作を個別に指定するには、次の手順に従います。

-   activationType = "system" を指定します。
-   arguments = "snooze" または arguments = "dismiss" を指定します。
-   content を指定します。
    -   "snooze" や "dismiss" のローカライズされた文字列を操作に対して表示する場合は、content に空の文字列を指定します (&lt;action content = ""/>)。&gt;
    -   カスタマイズした文字列が必要な場合は、その値を指定します (&lt;action content="Remind me later" />)。&gt;
-   input を指定します。
    -   再通知の間隔をユーザーが選ぶのではなく、システム定義の時間間隔 (OS 全体で一貫しています) に応じて 1 回だけ再通知を行う場合は、&lt;input&gt; を指定しないでください。
    -   再通知の間隔に関する選択項目を指定する場合:
        -   再通知の操作内に、hint-inputId を指定します。
        -   input の id に、再通知の操作の hint-inputId と同じ値を指定します (&lt;input id="snoozeTime"&gt;&lt;/input&gt;&lt;action hint-inputId="snoozeTime"/>)。&gt;
        -   selection の id に、再通知の間隔を分単位で表す負以外の整数を指定します。&lt;selection id="240" /&gt; は、再通知の間隔が 4 時間であることを示します。
        -   &lt;input&gt; の defaultInput の値が、&lt;selection&gt; 子要素の id のいずれかと一致することを確認します。
        -   &lt;selection&gt; の値は、最大で 5 つまで指定できます。

 

 
## <a name="related-topics"></a>関連トピック

* [Quickstart: Send a local toast and handle activation (クイックスタート: ローカル トースト通知の送信とアクティブ化の処理)](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/07/08/quickstart-sending-a-local-toast-notification-and-handling-activations-from-it-windows-10.aspx)
* [GitHub の Notifications ライブラリ](https://github.com/Microsoft/UWPCommunityToolkit/tree/dev/Notifications)