---
author: mijacobs
Description: アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。
title: アダプティブ トースト通知と対話型トースト通知
ms.assetid: 1FCE66AF-34B4-436A-9FC9-D0CF4BDA5A01
label: Adaptive and interactive toast notifications
template: detail.hbs
---

# アダプティブ トースト通知と対話型トースト通知





アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。

アダプティブ トースト通知と対話型トースト通知のモデルでは、従来のトースト テンプレート カタログについて、次の更新が行われています。

-   通知にボタンや入力を追加するためのオプション。
-   メインのトースト通知や各操作用の 3 つの異なるアクティブ化の種類。
-   特定のシナリオ (アラーム、リマインダー、着信呼び出しなど) 向けの通知を作成するためのオプション。

**注**   Windows 8.1 や Windows Phone 8.1 の従来のテンプレートについては、「[従来のトースト テンプレート カタログ](https://msdn.microsoft.com/library/windows/apps/hh761494)」をご覧ください。

 

## <span id="toast_structure"></span><span id="TOAST_STRUCTURE"></span>トースト通知の構造体


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

構造体の視覚的な表示は、次のようになります。

![トースト通知の構造体](images/adaptivetoasts-structure.jpg)

### <span id="Visual"></span><span id="visual"></span><span id="VISUAL"></span>視覚

visual 要素内には、トースト通知の視覚的なコンテンツを含んだ binding 要素を 1 つだけ指定する必要があります。

ユニバーサル Windows プラットフォーム (UWP) アプリのタイル通知では、さまざまなタイル サイズに基づく複数のテンプレートをサポートしています。 ただし、トースト通知が保持できるテンプレート名は、1 つだけです (**ToastGeneric**)。 保持できるテンプレート名が 1 つだけということは、次のことを意味しています。

-   トースト通知のコンテンツを変更できます。つまり、新しいテキスト行やインライン画像の追加、アプリ アイコンから他の画像へのサムネイル イメージの変更などを行うことができます。また、これらの操作を行う場合、テンプレート名とコンテンツの不一致が原因となって、テンプレート全体の変更や無効なペイロードの作成が行われることを考慮する必要はありません。
-   さまざまな種類の Microsoft Windows デバイス (電話、タブレット、PC、Xbox One など) への配信を目的とした**トースト通知**用に同一のペイロードを作成するとき、同じコードを使うことができます。 これらの各デバイスでは、通知を受け取ると、その通知を UI ポリシーに基づいてユーザーに表示します。このとき、適切な視覚的アフォーダンスと操作モデルが使われます。

visual セクションとその子要素でサポートされているすべての属性については、後で説明する「スキーマ」セクションをご覧ください。 その他の例については、以下の「XML の例」セクションをご覧ください。

### <span id="Actions"></span><span id="actions"></span><span id="ACTIONS"></span>操作

UWP アプリでは、ボタンや他の入力をトースト通知に追加できます。これにより、ユーザーはアプリの外部で、より多くの操作を実行できるようになります。 これらの操作は &lt;actions&gt; 要素の下に指定します。指定できる操作は 2 種類あります。

-   &lt;action&gt; これは、デスクトップ デバイスやモバイル デバイスでボタンとして表示されます。 トースト通知内では、カスタム操作やシステム操作は最大 5 つまで指定できます。
-   &lt;input&gt; これを使うと、ユーザーは入力を提供できます (メッセージにすばやく応答したり、ドロップダウン メニューからオプションを選んだりすることができます)。

&lt;action&gt; と &lt;input&gt; はどちらも、Windows デバイス ファミリ内ではアダプティブです。 たとえば、モバイル デバイスやデスクトップ デバイスでは、ユーザーに対する &lt;action&gt; は、タップまたはクリックされるボタンとして表示されます。 &lt;input&gt; のテキストはボックスとして表示され、ユーザーは物理的なキーボードやスクリーン キーボードを使ってテキストを入力できます。 これらの要素は、将来の操作のシナリオ (音声によって指示される操作やディクテーションに基づくテキスト入力など) にも対応する予定です。

&lt;action&gt; 要素内に [**ActivationType**](https://msdn.microsoft.com/library/windows/desktop/dn408447) 属性を指定することで、ユーザーが操作を実行したとき、次のいずれかを実行できます。

-   特定のページやコンテキストへの移動に使うことができる操作固有の引数を指定して、アプリをフォアグラウンドでアクティブ化します。
-   ユーザーに影響を与えずに、アプリのバック グラウンド タスクをアクティブ化します。
-   プロトコル起動を利用して別のアプリをアクティブ化します。
-   実行するシステム操作を指定します。 現在利用可能なシステム操作は、スケジュールされたアラームやリマインダーを再通知したり、閉じたりする操作です。これらの操作については、後のセクションで説明します。

visual セクションとその子要素でサポートされているすべての属性については、後で説明する「スキーマ」セクションをご覧ください。 その他の例については、以下の「XML の例」セクションをご覧ください。

### <span id="Audio"></span><span id="audio"></span><span id="AUDIO"></span>オーディオ

デスクトップ プラットフォームを対象とする UWP アプリでは、カスタム サウンドは現在サポートされていません。代わりに、デスクトップ上のアプリ用の ms-winsoundevent の一覧から選ぶことができます。 モバイル プラットフォーム上の UWP アプリでは、ms-winsoundevent と、次の形式のカスタム サウンドの両方をサポートしています。

-   ms-appx:///
-   ms-appdata:///

トースト通知でのオーディオについては、[オーディオ スキーマに関するページ](https://msdn.microsoft.com/library/windows/apps/br230842)をご覧ください。このページには、ms-winsoundevent の完全な一覧も記載されています。

## <span id="Alarms__reminders__and_incoming_calls"></span><span id="alarms__reminders__and_incoming_calls"></span><span id="ALARMS__REMINDERS__AND_INCOMING_CALLS"></span>アラーム、リマインダー、着信呼び出し


アラーム、リマインダー、着信呼び出し用にトースト通知を使うことができます。 これらの特別なトースト通知の外観は標準のトースト通知と同じですが、特別なトースト通知では、シナリオ ベースのカスタムの UI とパターンを利用できます。

-   リマインダーのトースト通知は、ユーザーが通知を閉じるか、操作を実行するまで画面上に表示されたままになります。 Windows Mobile では、リマインダーのトースト通知は既に展開された状態で表示されます。
-   アラーム通知では、上記の動作をリマインダー通知と共有するだけでなく、ループするオーディオを自動的に再生します。
-   着信呼び出し通知は、Windows Mobile デバイスでは全画面で表示されます。 この動作は、トースト通知のルート要素 (&lt;toast&gt;) 内に scenario 属性を指定することによって実行されます。&lt;toast scenario=" { default | alarm | reminder | incomingCall } " &gt;

## <span id="xml_examples"></span><span id="XML_EXAMPLES"></span>XML の例


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
      <image placement="appLogoOverride" src="A.png" />
    <image placement="inline" src="hiking.png" />
    </binding>
  </visual>
</toast>
```

![リッチ ビジュアル コンテンツを使った通知](images/adaptivetoasts-xmlsample01.png)

 

**操作を使った通知の例 1**

この例は、次のようになります。

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Microsoft Company Store</text>
      <text>New Halo game is back in stock!</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <action activationType="foreground" content="see more details" arguments="details" imageUri="check.png"/>
    <action activationType="background" content="remind me later" arguments="later" imageUri="cancel.png"/>
  </actions>
</toast>
```

![操作を使った通知の例 1](images/adaptivetoasts-xmlsample02.png)

 

**操作を使った通知の例 2**

この例は、次のようになります。

```XML
<toast launch="app-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Cortana</text>
      <text>We noticed that you are near Wasaki.</text>
      <text>Thomas left a 5 star rating after his last visit, do you want to try?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <action activationType="foreground" content="reviews" arguments="reviews" />
    <action activationType="protocol" content="show map" arguments="bingmaps:?q=sushi" />
  </actions>
</toast>
```

![操作を使った通知の例 2](images/adaptivetoasts-xmlsample03.png)

 

**テキスト入力と操作を使った通知の例 1**

この例は、次のようになります。

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Andrew B.</text>
      <text>Shall we meet up at 8?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <input id="message" type="text" placeHolderContent="reply here" />
    <action activationType="background" content="reply" arguments="reply" />
    <action activationType="foreground" content="video call" arguments="video" />
  </actions>
</toast>
```

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample04.png)

 

**テキスト入力と操作を使った通知の例 2**

この例は、次のようになります。

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Andrew B.</text>
      <text>Shall we meet up at 8?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <input id="message" type="text" placeHolderContent="reply here" />
    <action activationType="background" content="reply" arguments="reply" imageUri="send.png" hint-inputId="message"/>
  </actions>
</toast>
```

![テキスト入力と操作を使った通知](images/adaptivetoasts-xmlsample05.png)

 

**選択入力と操作を使った通知**

この例は、次のようになります。

```XML
<toast launch="developer-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Spicy Heaven</text>
      <text>When do you plan to come in tomorrow?</text>
      <image placement="appLogoOverride" src="A.png" />
    </binding>
  </visual>
  <actions>
    <input id="time" type="selection" defaultInput="2" >
  <selection id="1" content="Breakfast" />
  <selection id="2" content="Lunch" />
  <selection id="3" content="Dinner" />
    </input>
    <action activationType="background" content="Reserve" arguments="reserve" />
    <action activationType="background" content="Call Restaurant" arguments="call" />
  </actions>
</toast>
```

![選択入力と操作を使った通知](images/adaptivetoasts-xmlsample06.png)

 

**リマインダー通知**

この例は、次のようになります。

```XML
<toast scenario="reminder" launch="developer-pre-defined-string">
  <visual>
    <binding template="ToastGeneric">
      <text>Adam&#39;s Hiking Camp</text>
      <text>You have an upcoming event for this Friday!</text>
      <text>RSVP before it"s too late.</text>
      <image placement="appLogoOverride" src="A.png" />
      <image placement="inline" src="hiking.png" />
    </binding>
  </visual>
  <actions>
    <action activationType="background" content="RSVP" arguments="rsvp" />
    <action activationType="background" content="Reminder me later" arguments="later" />
  </actions>
</toast>
```

![リマインダー通知](images/adaptivetoasts-xmlsample07.png)

 

## <span id="Activation_samples"></span><span id="activation_samples"></span><span id="ACTIVATION_SAMPLES"></span>アクティブ化の例


既に説明したように、トースト通知内の本文と操作では、さまざまな方法でアプリをアクティブ化することができます。 次の例では、トースト通知内の本文や操作でさまざまな種類のアクティブ化を処理する方法を示しています。

**フォアグラウンド**

このシナリオでは、アプリはフォアグラウンドのアクティブ化を使って、操作可能なトースト通知内の操作に応答します。このアクティブ化では、アプリを起動し、適切なコンテンツに移動します。

トースト通知からのアクティブ化では、これまで OnLaunched() が呼び出されていました。 Windows 10 では、トースト通知には独自の種類のアクティブ化があり、OnActivated() を呼び出します。

```
async protected override void OnActivated(IActivatedEventArgs args)
{
        //Initialize your app if it&#39;s not yet initialized;
    //Find out if this is activated from a toast;
    If (args.Kind == ActivationKind.ToastNotification)
    {
                //Get the pre-defined arguments and user inputs from the eventargs;
        var toastArgs = args as ToastNotificationActivatedEventArgs;
        var arguments = toastArgs.Arguments;
        var input = toastArgs.UserInput["1"]; 
}
     
    //...
}
```

**バックグラウンド**

このシナリオでは、アプリはバックグラウンド タスクを使って、対話型トースト通知内の操作を処理します。 次のコードは、アプリ マニフェスト内のトースト通知アクティブ化を処理するためのバックグラウンド タスクを宣言する方法と、ボタンがクリックされたときに操作とユーザー入力から引数を取得する方法を示しています。

```
<!-- Manifest Declaration -->
<!-- A new task type toastNotification is added -->
<Extension Category = "windows.backgroundTasks" 
EntryPoint = "Tasks.BackgroundTaskClass" >
  <BackgroundTasks>
    <Task Type="systemEvent" />
  </BackgroundTasks>
</Extension>
```

```
namespace ToastNotificationTask
{
    public sealed class ToastNotificationBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
        //Inside here developer can retrieve and consume the pre-defined 
        //arguments and user inputs;
        var details = taskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;
        var arguments = details.Arguments;
        var input = details.Input.Lookup("1");

            // ...
        }        
    }
}
```

## <span id="Schemas___visual__and__audio_"></span><span id="schemas___visual__and__audio_"></span><span id="SCHEMAS___VISUAL__AND__AUDIO_"></span>スキーマ: &lt;visual&gt; と &lt;audio&gt;


次のスキーマでは、"?" サフィックスは属性が省略可能であることを意味します。

```
<toast launch? duration? activationType? scenario? >
    <visual version? lang? baseUri? addImageQuery? >
        <binding template? lang? baseUri? addImageQuery? >
            <text lang? >content</text>
            <text />
            <image src placement? alt? addImageQuery? hint-crop? />
        </binding>
    </visual>
    <audio src? loop? silent? />
    <actions>
    </actions>
</toast>
```

**&lt;toast> 内の属性&gt;**

launch?

-   launch? = 文字列
-   この属性は省略可能です。
-   トースト通知によってアプリケーションがアクティブ化されるときにアプリケーションに渡される文字列です。
-   activationType の値に応じて、この値は、フォアグラウンドのアプリ、バックグラウンド タスクの内部、または元のアプリからプロトコル起動された他のアプリで取得することができます。
-   この文字列の形式とコンテンツは、アプリ独自の使用方法に合わせて、アプリによって定義されます。
-   ユーザーがトースト通知をタップまたはクリックし、関連するアプリを起動すると、そのアプリは既定の方法で起動されるのではなく、起動文字列によって、そのコンテキストがアプリに渡され、トースト通知のコンテンツに関連するビューがユーザーに表示されます。
-   ユーザーがトースト通知の本文ではなく操作をクリックしたことによってアクティブ化が行われた場合、&lt;toast&gt; タグ内に定義済みの "launch" ではなく、&lt;action&gt; タグ内に事前に定義されている "arguments" が取得されます。

duration?

-   duration? = "short|long"
-   この属性は省略可能です。 既定値は "short" です。
-   これは、特定のシナリオやアプリケーションの互換性のみを目的とした属性です。 アラーム シナリオでは、この属性は必要ありません。
-   このプロパティを使うことはお勧めしません。

activationType?

-   activationType? = "foreground | background | protocol | system"
-   この属性は省略可能です。
-   既定値は "foreground" です。

scenario?

-   scenario? = "default | alarm | reminder | incomingCall"
-   この属性は省略可能です。既定値は "default" です。
-   シナリオがアラーム、リマインダー、着信呼び出しの表示以外の場合、この属性は必要ありません。
-   通知を常に画面上に表示することのみを目的とする場合は、この属性を使わないでください。

**&lt;visual> 内の属性&gt;**

version?

-   version? = 負以外の整数
-   &lt;visual&gt; ではバージョン管理は廃止される予定であるため、この属性は必要ありません。 必要に応じてより高い階層から指定できる新しいバージョン管理モデルが発表されるまで、しばらくお待ちください。

lang?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

baseUri?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230847)をご覧ください。

**&lt;binding> 内の属性&gt;**

template?

-   \[重要\] template? = "ToastGeneric"
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

-   placement? = "inline" | "appLogoOverride"
-   この属性は省略可能です。
-   この属性は、画像が表示される場所を指定します。
-   "inline" は、トースト通知本文内のテキストの下に表示されることを意味します。"appLogoOverride" は、アプリケーション アイコン (トースト通知の左上隅に表示される) を置き換えることを意味します。
-   各 placement の値に指定できる画像は 1 つまでです。

alt?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

addImageQuery?

-   この省略可能な属性について詳しくは、[要素のスキーマに関するこの記事](https://msdn.microsoft.com/library/windows/apps/br230844)をご覧ください。

hint-crop?

-   hint-crop? = "none" | "circle"
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

## <span id="Schemas___action_"></span><span id="schemas___action_"></span><span id="SCHEMAS___ACTION_"></span>スキーマ: &lt;action&gt;


次のスキーマでは、"?" サフィックスは属性が省略可能であることを意味します。

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

**&lt;input> 内の属性&gt;**

id

-   id= 文字列
-   この属性は必須です。
-   id 属性は必須の属性であり、アプリが (フォアグラウンドまたはバックグラウンドで) アクティブ化されたときにユーザー入力を取得するために使われます。

type

-   type = "text | selection"
-   この属性は必須です。
-   この属性を使って、テキスト入力であるか、事前に定義された選択項目の一覧からの入力であるかを指定します。
-   モバイルやデスクトップでは、この属性は、テキスト ボックスによる入力を使うか、リスト ボックスによる入力を使うかを指定します。

title?

-   title? = 文字列
-   title 属性は省略可能です。開発者は、シェルの入力に対してタイトルを指定し、アフォーダンスがあるときに表示します。
-   モバイルやデスクトップでは、入力の上にこのタイトルが表示されます。

placeHolderContent?

-   placeHolderContent? = 文字列
-   placeHolderContent 属性は省略可能です。入力の種類が text の場合に、ヒントのテキストを灰色で表示します。 入力の種類が "text" 以外の場合、この属性は無視されます。

defaultInput?

-   defaultInput? = 文字列
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

-   content= 文字列
-   content 属性は必須です。 ボタンに表示されるテキスト文字列を指定します。

arguments

-   arguments= 文字列
-   arguments 属性は必須です。 この属性は、アプリによって定義されたデータを表します。ユーザーがこの action を実行し、アプリがアクティブ化された後で、アプリはこのデータを取得することができます。

activationType?

-   activationType? = "foreground | background | protocol | system"
-   activationType 属性は省略可能です。既定値は "foreground" です。
-   この属性は、この action によって行われるアクティブ化の種類を表します (フォアグラウンド、バックグラウンド、プロトコル起動による別のアプリの起動、またはシステム操作の呼び出し)。

imageUri?

-   imageUri? = 文字列
-   imageUri は省略可能です。この action 用の画像アイコンを指定するために使われます。このアイコンは、テキスト コンテンツと共にボタン内に表示されます。

hint-inputId

-   hint-inputId= 文字列
-   hint-inpudId 属性は必須です。 特に、すばやく応答するシナリオで使われます。
-   値は、この属性に関連付ける必要がある入力要素の ID にする必要があります。
-   モバイルやデスクトップでは、この属性によって、入力ボックスのすぐ横にボタンが配置されます。

## <span id="Attributes_for_system-handled_actions"></span><span id="attributes_for_system-handled_actions"></span><span id="ATTRIBUTES_FOR_SYSTEM-HANDLED_ACTIONS"></span>システムによって処理される操作の属性


アプリで再通知や通知の再スケジュールをバックグラウンド タスクとして処理しない場合は、システムで、再通知や通知を閉じるための操作を処理できます。 システムによって処理される操作は、組み合わせることができます (または個別に指定することもできます)。ただし、閉じる操作を使わないで再通知の操作を実装することはお勧めしません。

システム コマンドの組み合わせ: SnoozeAndDismiss

```
<toast>
    <visual>
    </visual>
    <audio />
    <actions hint-systemCommands? = "SnoozeAndDismiss" />
</toast>
```

システムによって処理される操作を個別に指定

```
<toast>
    <visual>
    </visual>
    <audio />
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

 

 






<!--HONumber=May16_HO2-->


