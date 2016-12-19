---
author: mcleanbyron
Description: "Windows デベロッパー センターから送信されるプッシュ通知を受信する UWP アプリを登録する方法について説明します。"
title: "デベロッパー センターのプッシュ通知を受信するようにアプリを設定する"
translationtype: Human Translation
ms.sourcegitcommit: ffda100344b1264c18b93f096d8061570dd8edee
ms.openlocfilehash: d840fbe66e5ccb439148c7849e44b923a5586740

---

# <a name="configure-your-app-to-receive-dev-center-push-notifications"></a>デベロッパー センターのプッシュ通知を受信するようにアプリを設定する

Windows デベロッパー センター ダッシュボードの **[プッシュ通知]** のページを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリがインストールされているデバイスにターゲット プッシュ通知を送信することによって、ユーザーとの直接のエンゲージメントを行えます。 たとえば、ターゲット プッシュ通知を使用して、ユーザーにアプリの評価や新しい機能の試用などの行動を促すことができます。 トースト通知、タイル通知、生の XML 通知など、さまざまな種類のプッシュ通知を送信できます。 また、プッシュ通知の結果としてのアプリの起動率を追跡することもできます。 この機能について詳しくは、「[アプリのユーザーにプッシュ通知を送信する](../publish/send-push-notifications-to-your-apps-customers.md)」をご覧ください。

デベロッパー センターからユーザーにターゲット プッシュ通知を送信する前に、Microsoft Store Services SDK の [StoreServicesEngagementManager](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesengagementmanager.aspx) クラスのメソッドを使用して、通知を受信するアプリを登録する必要があります。 このクラスの追加のメソッドを使用して、ターゲット プッシュ通知の結果としてアプリが起動されたことをデベロッパー センターに通知したり (通知の結果としてのアプリの起動率をトラッキングする場合)、通知の受信を停止したりすることができます。

## <a name="configure-your-project"></a>プロジェクトを構成する

コードを記述する前に、Microsoft Store Services SDK への参照をプロジェクトに追加するには、以下の手順を実行します。

1. Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。 通知を受信するアプリを登録するための API に加えて、この SDK は、アプリで A/B テストを行ったり、広告を表示したりすることなど、その他の機能のための API を提供します。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
4. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

## <a name="register-for-push-notifications"></a>プッシュ通知への登録

ターゲット プッシュ通知を受信するアプリをデベロッパー センターから登録するには

1. プロジェクトで、起動中に実行されるコード セクションを見つけます。このセクションで、アプリケーションを登録してデベロッパー センターの通知を受信できます。
2. コード ファイルの先頭に、次のステートメントを追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#EngagementNamespace)]

3. [StoreServicesEngagementManager](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesengagementmanager.aspx) オブジェクトを取得し、先ほど見つけた起動コードの [RegisterNotificationChannelAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesengagementmanager.registernotificationchannelasync.aspx) オーバーロードの 1 つを呼び出します。 このメソッドは、アプリを起動するたびに呼び出す必要があります。

  * デベロッパー センターで通知の独自のチャネル URI を作成する場合は、[RegisterNotificationChannelAsync()](https://msdn.microsoft.com/library/windows/apps/mt771190.aspx) オーバーロードを呼び出します。

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#RegisterNotificationChannelAsync1)]

    <span/>
    >**重要**&nbsp;&nbsp; アプリが [CreatePushNotificationChannelForApplicationAsync](https://msdn.microsoft.com/library/windows/apps/windows.networking.pushnotifications.pushnotificationchannelmanager.createpushnotificationchannelforapplicationasync.aspx) を呼び出して WNS の通知チャネルを作成する場合、コードで [CreatePushNotificationChannelForApplicationAsync](https://msdn.microsoft.com/library/windows/apps/windows.networking.pushnotifications.pushnotificationchannelmanager.createpushnotificationchannelforapplicationasync.aspx) および [RegisterNotificationChannelAsync()](https://msdn.microsoft.com/library/windows/apps/mt771190.aspx) オーバーロードを同時に呼び出さないようにします。 これらのメソッドの両方を呼び出す必要がある場合は、それらを順番に呼び出すようにして、もう一方のメソッドを呼び出す前に別のメソッドの戻りを待つようにします。

  * デベロッパー センターからターゲット プッシュ通知に使用するチャネル URI を指定する場合、[RegisterNotificationChannelAsync(StoreServicesNotificationChannelParameters)](https://msdn.microsoft.com/library/windows/apps/mt771191.aspx) オーバーロードを呼び出します。 たとえば、アプリが既に Windows プッシュ通知サービス (WNS) を使用していて、同じチャネル URI を使用する場合は、次のようにします。 まず [StoreServicesNotificationChannelParameters](https://msdns.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesnotificationchannelparameters.aspx) オブジェクトを作成し、[CustomNotificationChannelUri](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesnotificationchannelparameters.customnotificationchanneluri.aspx) プロパティをチャネル URI に割り当てる必要があります。

    > [!div class="tabbedCodeSnippets"]
    [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#RegisterNotificationChannelAsync2)]

  >#### <a name="understanding-how-your-app-responds-when-the-user-launches-your-app"></a>ユーザーがアプリを起動したときのアプリの対応を理解する

  >通知を受信するようにアプリを登録し、[デベロッパー センターからアプリのユーザーにプッシュ通知を送信](../publish/send-push-notifications-to-your-apps-customers.md)した後に、ユーザーがプッシュ通知の結果としてアプリを起動すると、アプリの次のエントリ ポイントの 1 つが呼び出されます。 ユーザーがアプリを起動したときに実行するコードがある場合は、アプリのこれらのエントリ ポイントのいずれかにコードを追加できます。

  >* プッシュ通知にフォアグラウンドのアクティブ化の種類がある場合には、プロジェクトの**アプリ**クラスの [OnActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onactivated.aspx) メソッドを上書きして、このメソッドにコードを追加します。

  >* プッシュ通知にバックグラウンドのアクティブ化の種類がある場合には、[バックグラウンド タスク](../launch-resume/support-your-app-with-background-tasks.md)の [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッドにコードを追加します。

  >たとえば、有料のアドオンを購入したアプリのユーザーに、特典として無料のアドオンを提供することができます。 この例では、対象とするユーザーの[ユーザー セグメント](../publish/create-customer-segments.md)にプッシュ通知を送信できます。 次に、無料の[アプリ内購入](in-app-purchases-and-trials.md)を提供するコードを、上記のエントリ ポイントのいずれかに追加できます。

## <a name="notify-dev-center-of-your-app-launch"></a>アプリの起動をデベロッパー センターに通知する

デベロッパー センターのプッシュ通知の **[アプリの起動率の追跡]** オプションを選択した場合、アプリの適切なエントリ ポイントから [ParseArgumentsAndTrackAppLaunch](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesengagementmanager.parseargumentsandtrackapplaunch.aspx) メソッドを呼び出して、プッシュ通知の結果としてアプリが起動されたことをデベロッパー センターに通知します。

このメソッドは、アプリの元の起動引数を返します。 デベロッパー センターのプッシュ通知によるアプリ起動率の追跡を選択すると、起動引数に不透明なトラッキング ID が追加され、デベロッパー センターでのアプリの起動の追跡に役立ちます。 アプリの起動引数 [ParseArgumentsAndTrackAppLaunch](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesengagementmanager.parseargumentsandtrackapplaunch.aspx) メソッドに渡す必要があります。このメソッドは、追跡 ID をデベロッパー センターに送信し、起動引数から追跡 ID を削除して、元の起動引数をコードに返します。

このメソッドを呼び出す方法は、ターゲット プッシュ通知のアクティブ化の種類によって異なります。

* プッシュ通知にフォアグラウンドのアクティブ化の種類がある場合は、このメソッドをアプリの [OnActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onactivated.aspx) メソッド オーバーライドから呼び出し、このメソッドに渡された [ToastNotificationActivatedEventArgs](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.activation.toastnotificationactivatedeventargs.aspx) オブジェクトで使用可能な引数を渡します。 次のコード例では、コード ファイルに **Microsoft.Services.Store.Engagement** 名前空間と **Windows.ApplicationModel.Activation** 名前空間の **using** ステートメントがあることを前提としています。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/App.xaml.cs#OnActivated)]

* プッシュ通知にバックグラウンドのアクティブ化の種類がある場合、[バックグラウンド タスク](../launch-resume/support-your-app-with-background-tasks.md)の [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) メソッドからこのメソッドを呼び出し、このメソッドに渡された [ToastNotificationActionTriggerDetail](https://msdn.microsoft.com/library/windows/apps/windows.ui.notifications.toastnotificationactiontriggerdetail.aspx) オブジェクトで使用可能な引数を渡します。 次のコード例では、コード ファイルに **Microsoft.Services.Store.Engagement**、**Windows.ApplicationModel.Background**、**Windows.UI.Notifications** の名前空間の **using** ステートメントがあることを前提としています。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#Run)]

## <a name="unregister-for-push-notifications"></a>プッシュ通知への登録解除

アプリで Windows デベロッパー センターのターゲット プッシュ通知の受信を停止する場合は、[UnregisterNotificationChannelAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesengagementmanager.unregisternotificationchannelasync) メソッドを呼び出します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#UnregisterNotificationChannelAsync)]

このメソッドは通知に使用されているチャネルを無効にするため、アプリは*いずれの*サービスからもプッシュ通知を受信しなくなることに注意してください。 チャネルが閉じられると、Windows デベロッパー センターのターゲット プッシュ通知や WNS を使用したその他の通知を含め、どのサービスにもチャネルを再度使用することはできません。 このアプリでプッシュ通知の送信を再開するには、アプリは新しいチャネルを要求する必要があります。

## <a name="related-topics"></a>関連トピック

* [アプリのユーザーにプッシュ通知を送信する](../publish/send-push-notifications-to-your-apps-customers.md)
* [Windows プッシュ通知サービス (WNS) の概要](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-windows-push-notification-services--wns--overview)
* [通知チャネルを要求、作成、保存する方法](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868221)
* [Microsoft Store Services SDK](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)



<!--HONumber=Dec16_HO1-->


