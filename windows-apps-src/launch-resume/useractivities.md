---
author: TylerMSFT
title: デバイス間でもユーザーのアクティビティを継続する
description: このトピックでは、前回ユーザーがアプリで実行していた状態から再開できるようにする方法 (複数のデバイス間で再開する場合にも対応) について説明します。
keywords: ユーザー アクティビティ、ユーザー アクティビティ、タイムライン、Cortana の前回終了した位置から再開する、Cortana の前回終了した位置から再開する、Project Rome
ms.author: twhitney
ms.date: 04/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 53aac2375d60df3cd9493f315b20431961378fe8
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4389210"
---
# <a name="continue-user-activity-even-across-devices"></a>デバイス間でもユーザーのアクティビティを継続する

このトピックでは、前回ユーザーがアプリで実行していた状態から再開できるようにする方法 (PC およびデバイス間で再開する場合にも対応) について説明します。

## <a name="user-activities-and-timeline"></a>ユーザー アクティビティとタイムライン

私たちの毎日の時間は、複数のデバイス間に広がっています。 私たちは、バスの中でスマートフォンを、日中は PC を、夜は電話やタブレットを使用しています。 Windows 10 ビルド 1803 以降では、[ユーザー アクティビティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) を作成すると、そのアクティビティが Windows タイムラインと Cortana の 前回終了した位置から再開機能に表示されるようになりました。 タイムラインは、ユーザー アクティビティを活用して作業していることを時系列に表示する豊富な機能を備えたタスク ビューです。 また、さまざまなデバイス間で作業していた内容も含めることができます。

![Windows タイムラインのイメージ](images/timeline.png)

同様に、お使いの電話を Windows PC に接続すると、以前に iOS やAndroid デバイスで行っていた作業を続けることができます。

**UserActivity** は、ユーザーがあなたのアプリ内で作業していたことと考えてください。 たとえば、RSSリーダーを使用している場合、**UserActivity** はあなたが読んでいるフィードになります。 ゲームをプレイしている場合、**UserActivity** はあなたがプレイしているレベルになります。 音楽アプリを聴いている場合は、**UserActivity** があなたが聴いているプレイリストになります。 ドキュメントで作業している場合、**UserActivity** は作業を中断した場所になるなどです。  要するに、**UserActivity** は、ユーザーが自分のやっていることを再開できるように、アプリ内の目的地を表すものです。

[UserActivity.CreateSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.createsession) を呼び出して **UserActivity** を使用すると、システムは **UserActivity**の開始時刻と終了時刻を示す履歴レコードを作成します。 時間の経過とともに **UserActivity** を再使用していくと、複数の履歴レコードが記録されます。

## <a name="add-user-activities-to-your-app"></a>アプリにユーザー アクティビティを追加する

[UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) は、Windows でのユーザー エンゲージメントの単位です。 これには、アクティビティが属するアプリをアクティブ化するために使用される URI、ビジュアル、およびアクティビティを記述するメタデータの 3 つの部分があります。

1. [ActivationUri](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activationuri#Windows_ApplicationModel_UserActivities_UserActivity_ActivationUri) は、特定のコンテキストでアプリケーションを再開するために使用します。 通常、このリンクは、スキームのプロトコル ハンドラー (例: “my-app://page2?action=edit”) または AppUriHandler (例: http://constoso.com/page2?action=edit) のフォームをとります。
2. [VisualElements](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.visualelements) は、タイトル、説明、またはアダプティブ カード要素でアクティビティを視覚的に識別できるようにするクラスを公開します。
3. 最後に、[コンテンツ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements.content#Windows_ApplicationModel_UserActivities_UserActivityVisualElements_Content) は、特定のコンテキストでアクティビティをグループ化したり取得したりするために使用できるアクティビティのメタデータを格納できます。 多くの場合、これは [http://schema.org](http://schema.org) データのフォームとなります。

**UserActivity** をアプリに追加するには:

1. アプリケーション内でユーザーのコンテキスト (ページ ナビゲーション、新しいゲームレベルなど) が変更されたときに **UserActivity** オブジェクトを生成する
2. **UserActivity** オブジェクトに必要なフィールドの最小セットを入力します。 [ActivityId](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activityid#Windows_ApplicationModel_UserActivities_UserActivity_ActivityId)、[ActivationUri](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.activationuri)、および [UserActivity.VisualElements.DisplayText](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements.displaytext#Windows_ApplicationModel_UserActivities_UserActivityVisualElements_DisplayText)。
3. **UserActivity** によって再アクティブ化できるように、カスタム スキーム ハンドラーをアプリケーションに追加します。

**UserActivity** はわずか数行のコードでアプリに統合できます。 たとえば、MainPage.xaml.cs の MainPage クラス内でこのコードを想像してみてください (注: `using Windows.ApplicationModel.UserActivities;` を前提としています)。

```csharp
UserActivitySession _currentActivity;
private async Task GenerateActivityAsync()
{
    // Get the default UserActivityChannel and query it for our UserActivity. If the activity doesn't exist, one is created.
    UserActivityChannel channel = UserActivityChannel.GetDefault();
    UserActivity userActivity = await channel.GetOrCreateUserActivityAsync("MainPage");
 
    // Populate required properties
    userActivity.VisualElements.DisplayText = "Hello Activities";
    userActivity.ActivationUri = new Uri("my-app://page2?action=edit");
     
    //Save
    await userActivity.SaveAsync(); //save the new metadata
 
    // Dispose of any current UserActivitySession, and create a new one.
    _currentActivity?.Dispose();
    _currentActivity = userActivity.CreateSession();
}
```

上の `GenerateActivityAsync()` メソッドの最初の行は、ユーザの [UserActivityChannel](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel) を取得します。 これは、このアプリのアクティビティが公開されるフィードです。 次の行は、`MainPage` と呼ばれるアクティビティのチャネルを照会します。

* ユーザーがアプリの特定の場所にいるたびに同じ ID が生成されるように、アクティビティに名前を付ける必要があります。 たとえば、アプリがページ ベースの場合は、ページの識別子を使用します。ドキュメント ベースの場合は、ドキュメントの名前 (または名前のハッシュ) を使用します。
* 同じ ID を持つフィードに既存のアクティビティがある場合、そのアクティビティは `UserActivity.State` が [公開済み](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitystate) に設定されているチャンネルから返されます その名前のアクティビティがない場合、`UserActivity.State` が **New** に設定された状態で新しいアクティビティが返されます。
* アクティビティがアプリに適用されます。 アクティビティ ID が他のアプリの ID と競合するのを心配する必要はありません。

**UserActivity** を取得または作成した後で、他の 2 つの必須フィールド、 `UserActivity.VisualElements.DisplayText` と `UserActivity.ActivationUri` を指定します。

次に、[SaveAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.saveasync) を呼び出して **UserActivity** を保存し、最後に [CreateSession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity.createsession) を保存します。これは [UserActivitySession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitysession) を返します。 **UserActivitySession** は、ユーザーが実際に **UserActivity** を使用しているときに、管理するために使用できるオブジェクトです。 たとえば、**UserActivitySession** 上でユーザーがページを離れるときに `Dispose()` を呼び出す必要があります。 上記の例では、`CreateSession()` を呼び出す前に `_currentActivity` で` `Dispose()` を呼び出しています。 これは、`_currentActivity` をページのメンバー フィールドにして、新しいものを開始する前に既存のアクティビティを停止したいからです (注:`?` は [null 条件演算子](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators) で、メンバー アクセスを実行する前に null をテストします)。

この場合、`ActivationUri` はカスタム スキームであるため、アプリケーション マニフェストにプロトコルを登録する必要もあります。 これは、Package.appmanifest XML ファイルで、またはデザイナーを使用して行います。

デザイナーで変更を加えるには、プロジェクトの Package.appmanifest ファイルをダブルクリックしてデザイナーを起動し、**[宣言]** タブを選択して、**[プロトコル]** 定義を追加します。 記入する必要がある唯一のプロパティは、現在、**名前**です。 上記で指定した URI の `my-app` と一致するはずです。

ここで、プロトコルによって起動されたときに何をすべきかをアプリに伝えるコードを記述する必要があります。 App.xaml.cs の `OnActivated` メソッドを上書きして、メイン ページに URI を渡します。

```csharp
protected override void OnActivated(IActivatedEventArgs e)
{
    if (e.Kind == ActivationKind.Protocol)
    {
        var uriArgs = e as ProtocolActivatedEventArgs;
        if (uriArgs != null)
        {
            if (uriArgs.Uri.Host == "page2")
            {
                // Navigate to the 2nd page of the  app
            }
        }
    }
    Window.Current.Activate();
}
```

このコードは、アプリがプロトコル経由でアクティブ化されたかどうかを検出します。 アクティブ化されていた場合は、アプリがアクティブ化されているタスクを再開するためにアプリが何をすべきかを確認します。 シンプルなアプリであるため、このアプリが再開する唯一のアクティビティは、アプリが起動したときにセカンダリページにユーザーを入れることです。

## <a name="use-adaptive-cards-to-improve-the-timeline-experience"></a>アダプティブ カードを使用して、タイムラインのエクスペリエンスを向上させる

ユーザーのアクティビティは、Cortana とタイムラインに表示されます。 アクティビティがタイムラインに表示されたら、[アダプティブ カード](http://adaptivecards.io/)フレームワークを使用してアクティビティを表示します。 アクティビティごとにアダプティブ カードを用意していない場合、タイムラインはアプリケーション名とアイコン、タイトル フィールド、およびオプションの説明フィールドに基づいて、簡単なアクティビティ カードを自動的に作成します。 以下は、アダプティブ カードのペイロードとそれが生成するカードの例です。

![アダプティブ カード](images/adaptivecard.png)]

アダプティブ カードのペイロード JSON 文字列の例:

```json
{ 
  "$schema": "http://adaptivecards.io/schemas/adaptive-card.json", 
  "type": "AdaptiveCard", 
  "version": "1.0",
  "backgroundImage": "https://winblogs.azureedge.net/win/2017/11/eb5d872c743f8f54b957ff3f5ef3066b.jpg", 
  "body": [ 
    { 
      "type": "Container", 
      "items": [ 
        { 
          "type": "TextBlock", 
          "text": "Windows Blog", 
          "weight": "bolder", 
          "size": "large", 
          "wrap": true, 
          "maxLines": 3 
        }, 
        { 
          "type": "TextBlock", 
          "text": "Training Haiti’s radiologists: St. Louis doctor takes her teaching global", 
          "size": "default", 
          "wrap": true, 
          "maxLines": 3 
        } 
      ] 
    } 
  ]
}
```

以下のように、**UserActivity** に JSON 文字列としてアダプティブ カードのペイロードを追加します。

```csharp
activity.VisualElements.Content = 
Windows.UI.Shell.AdaptiveCardBuilder.CreateAdaptiveCardFromJson(jsonCardText); // where jsonCardText is a JSON string that represents the card
```

## <a name="cross-platform-and-service-to-service-integration"></a>クロス プラットフォームとサービス間の統合

アプリがクロスプラットフォーム (Android や iOS など) で稼働している場合や、クラウドにユーザーの状態を保持している場合は、[Microsoft Graph](https://developer.microsoft.com/graph/) で UserActivities を公開できます。
アプリケーションまたはサービスが Microsoft アカウントで認証されると、上記と同じデータを使用して [アクティビティ](https://developer.microsoft.com/graph/docs/api-reference/beta/api/projectrome_put_activity) オブジェクトと [履歴](https://developer.microsoft.com/graph/docs/api-reference/beta/resources/projectrome_historyitem) オブジェクトを生成するための 2 回の単純な REST 呼び出しが必要です。

## <a name="summary"></a>まとめ

[UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities) API を使用して、アプリをタイムラインと Cortana に表示させることができます。
* 詳しくは、[Windows デベロッパー センター](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities) で **UserActivity** API についてご覧ください。
* 「[sample code](https://github.com/Microsoft/project-rome)」をご覧ください。
* 「[more sophisticated Adaptive Cards](http://adaptivecards.io/)」を参照してください。
* [Microsoft Graph](https://developer.microsoft.com/graph/) を介して、iOS、Android、または Web サービスから **UserActivity** を公開します。
* [Project Rome on GitHub](https://github.com/Microsoft/project-rome) について詳しく知る

## <a name="key-apis"></a>キー API

* [UserActivities 名前空間](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

## <a name="related-topics"></a>関連トピック

* [ユーザー アクティビティ ("rome"プロジェクト ドキュメント)](https://docs.microsoft.com/windows/project-rome/user-activities/)
* [アダプティブ カード](https://docs.microsoft.com/adaptive-cards/)
* [アダプティブ カード ビジュアライザー、サンプル](http://adaptivecards.io/)
* [URI のアクティブ化の処理](https://docs.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)
* [Microsoft Graph、アクティビティ フィード、およびアダプティブ カードを使用して、どのプラットフォームでも顧客の関心を惹きつける](https://channel9.msdn.com/Events/Connect/2017/B111)
* [Microsoft Graph](https://developer.microsoft.com/graph/)