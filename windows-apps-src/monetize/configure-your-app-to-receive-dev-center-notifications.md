---
author: Xansky
Description: Learn how to register your UWP app to receive push notifications that you send from Partner Center.
title: ターゲット プッシュ通知用のアプリの構成
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, Microsoft Store Services SDK, ターゲット プッシュ通知、パートナー センター
ms.assetid: 30c832b7-5fbe-4852-957f-7941df8eb85a
ms.localizationpriority: medium
ms.openlocfilehash: 1d1281436ce0fe8c7b04429cea897eedc58b15d9
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6976913"
---
# <a name="configure-your-app-for-targeted-push-notifications"></a>ターゲット プッシュ通知用のアプリの構成

パートナー センターで**プッシュ通知**] ページを使用するには、ユニバーサル Windows プラットフォーム (UWP) アプリがインストールされているデバイスにターゲット プッシュ通知を送信することでお客様と直接関わり合うします。 たとえば、ターゲット プッシュ通知を使用して、ユーザーにアプリの評価や新しい機能の試用などの行動を促すことができます。 トースト通知、タイル通知、生の XML 通知など、さまざまな種類のプッシュ通知を送信できます。 また、プッシュ通知の結果としてのアプリの起動率を追跡することもできます。 この機能について詳しくは、「[アプリのユーザーにプッシュ通知を送信する](../publish/send-push-notifications-to-your-apps-customers.md)」をご覧ください。

ターゲット プッシュ通知を顧客に送信するには、パートナー センターから、前に、Microsoft Store Services SDK で通知を受信するアプリを登録する[StoreServicesEngagementManager](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager)クラスのメソッドを使う必要があります。 このクラスの追加のメソッドを使用するには (の通知に起因するアプリの起動率を追跡するには) 場合に、アプリがターゲット プッシュ通知への応答で起動されたことをパートナー センターに通知して、通知の受信を停止します。

## <a name="configure-your-project"></a>プロジェクトを構成する

コードを記述する前に、Microsoft Store Services SDK への参照をプロジェクトに追加するには、以下の手順を実行します。

1. Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。 
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。
4. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
5. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

## <a name="register-for-push-notifications"></a>プッシュ通知への登録

パートナー センターからターゲット プッシュ通知を受信するアプリを登録するには。

1. プロジェクトで、起動中に実行されるコード セクションを見つけます。このセクションで、通知を受信するようにアプリケーションを登録することができます。
2. コード ファイルの先頭に、次のステートメントを追加します。

    [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#EngagementNamespace)]

3. [StoreServicesEngagementManager](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager) オブジェクトを取得し、先ほど見つけた起動コードの [RegisterNotificationChannelAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.registernotificationchannelasync) オーバーロードの 1 つを呼び出します。 このメソッドは、アプリを起動するたびに呼び出す必要があります。

  * パートナー センターで、通知の独自のチャネル URI を作成する場合は、 [RegisterNotificationChannelAsync()](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.registernotificationchannelasync)オーバー ロードを呼び出します。

      [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#RegisterNotificationChannelAsync1)]
      > [!IMPORTANT]
      > アプリが [CreatePushNotificationChannelForApplicationAsync](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanager.createpushnotificationchannelforapplicationasync) も呼び出して WNS の通知チャネルを作成する場合、コードが [CreatePushNotificationChannelForApplicationAsync](https://docs.microsoft.com/uwp/api/windows.networking.pushnotifications.pushnotificationchannelmanager.createpushnotificationchannelforapplicationasync) および [RegisterNotificationChannelAsync()](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.registernotificationchannelasync) オーバーロードを同時に呼び出さないようにしてください・ これらのメソッドの両方を呼び出す必要がある場合は、それらを順番に呼び出すようにして、もう一方のメソッドを呼び出す前に別のメソッドの戻りを待つようにします。

  * パートナー センターからターゲット プッシュ通知を使用するチャネル URI を指定する場合は、 [registernotificationchannelasync (storeservicesnotificationchannelparameters)](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.registernotificationchannelasync)のオーバー ロードを呼び出します。 たとえば、アプリが既に Windows プッシュ通知サービス (WNS) を使用していて、同じチャネル URI を使用する場合は、次のようにします。 まず [StoreServicesNotificationChannelParameters](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesnotificationchannelparameters) オブジェクトを作成し、[CustomNotificationChannelUri](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesnotificationchannelparameters.customnotificationchanneluri) プロパティをチャネル URI に割り当てる必要があります。

      [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#RegisterNotificationChannelAsync2)]

> [!NOTE]
> **RegisterNotificationChannelAsync** メソッドを呼び出すと、MicrosoftStoreEngagementSDKId.txt という名前のファイルが、アプリのローカル アプリ データ ストア ([ApplicationData.LocalFolder](https://docs.microsoft.com/uwp/api/Windows.Storage.ApplicationData.LocalFolder) プロパティによって返されるフォルダー) に作成されます。 このファイルには、ターゲット プッシュ通知インフラストラクチャで使用される ID が含まれています。 アプリがこのファイルを変更または削除しないことを確認してください。 ファイルの変更や削除が行われると、通知の複数のインスタンスを受け取ったり、他の方法で通知が正しく動作しない可能性があります。

<span id="notification-customers" />

### <a name="how-targeted-push-notifications-are-routed-to-customers"></a>ターゲット プッシュ通知をユーザーにルーティングする方法

アプリで **RegisterNotificationChannelAsync** を呼び出すと、このメソッドは、現在デバイスにサインインしているユーザーの Microsoft アカウントを収集します。 後で、このユーザーが含まれているセグメントにターゲット プッシュ通知を送信すると、パートナー センターは、このユーザーの Microsoft アカウントに関連付けられているデバイスに、通知を送信します。

アプリを起動したユーザーが、Microsoft アカウントでデバイスにまだサインインしているときに、そのデバイスを他のユーザーに使用させた場合、他のユーザーが元のユーザーを対象とした通知を見る可能性があります。 これにより予期しない結果が起こる可能性があります (特に、ユーザーによるサインインが必要となるサービスを提供するアプリの場合)。 このシナリオで他のユーザーがターゲット通知を見ることができなくするには、ユーザーがアプリからからサインアウトするときに、[UnregisterNotificationChannelAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.unregisternotificationchannelasync) メソッドを呼び出します。 詳しくは、この記事の後半にある「[プッシュ通知の登録解除](#unregister)」をご覧ください。

### <a name="how-your-app-responds-when-the-user-launches-your-app"></a>ユーザーがアプリを起動したときのアプリの対応方法

通知と[パートナー センターからアプリのユーザーにプッシュ通知の送信](../publish/send-push-notifications-to-your-apps-customers.md)を受信するアプリを登録すると、アプリでは、次のエントリ ポイントのいずれかのときに呼び出される、ユーザーにプッシュへの応答としてアプリを起動します。通知です。 ユーザーがアプリを起動したときに実行するコードがある場合は、アプリのこれらのエントリ ポイントのいずれかにコードを追加できます。

  * プッシュ通知にフォアグラウンドのアクティブ化の種類がある場合には、プロジェクトの**アプリ**クラスの [OnActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onactivated) メソッドを上書きして、このメソッドにコードを追加します。

  * プッシュ通知にバックグラウンドのアクティブ化の種類がある場合には、[バックグラウンド タスク](../launch-resume/support-your-app-with-background-tasks.md)の [Run](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask.run) メソッドにコードを追加します。

たとえば、有料のアドオンを購入したアプリのユーザーに、特典として無料のアドオンを提供することができます。 この例では、対象とするユーザーの[ユーザー セグメント](../publish/create-customer-segments.md)にプッシュ通知を送信できます。 次に、無料の[アプリ内購入](in-app-purchases-and-trials.md)を提供するコードを、上記のエントリ ポイントのいずれかに追加できます。

## <a name="notify-partner-center-of-your-app-launch"></a>アプリの起動のパートナー センターに通知します。

パートナー センターでターゲット プッシュ通知の**アプリの起動率の追跡**オプションを選択した場合は、アプリがパートナー センターに通知するアプリの適切なエントリ ポイントから[ParseArgumentsAndTrackAppLaunch](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.parseargumentsandtrackapplaunch)メソッドを呼び出すプッシュ通知への応答として起動されます。

このメソッドは、アプリの元の起動引数を返します。 プッシュ通知のアプリの起動率の追跡を選択すると、不透明な追跡に ID を追加、アプリを追跡するための起動引数を起動パートナー センターでします。 [ParseArgumentsAndTrackAppLaunch](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.parseargumentsandtrackapplaunch)メソッドには、アプリの起動引数を渡す必要があり、このメソッドは、追跡 ID をパートナー センターに送信し、起動引数から追跡 ID を削除を元の起動引数を返します、。コードです。

このメソッドを呼び出す方法は、プッシュ通知のアクティブ化の種類によって異なります。

* プッシュ通知にフォアグラウンドのアクティブ化の種類がある場合は、このメソッドをアプリの [OnActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.onactivated) メソッド オーバーライドから呼び出し、このメソッドに渡された [ToastNotificationActivatedEventArgs](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ToastNotificationActivatedEventArgs) オブジェクトで使用可能な引数を渡します。 次のコード例では、コード ファイルに **Microsoft.Services.Store.Engagement** 名前空間と **Windows.ApplicationModel.Activation** 名前空間の **using** ステートメントがあることを前提としています。

  [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/App.xaml.cs#OnActivated)]

* プッシュ通知にバックグラウンドのアクティブ化の種類がある場合、[バックグラウンド タスク](../launch-resume/support-your-app-with-background-tasks.md)の [Run](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.ibackgroundtask.run) メソッドからこのメソッドを呼び出し、このメソッドに渡された [ToastNotificationActionTriggerDetail](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationActionTriggerDetail) オブジェクトで使用可能な引数を渡します。 次のコード例では、コード ファイルに **Microsoft.Services.Store.Engagement**、**Windows.ApplicationModel.Background**、**Windows.UI.Notifications** の名前空間の **using** ステートメントがあることを前提としています。

  [!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#Run)]

<span id="unregister" />

## <a name="unregister-for-push-notifications"></a>プッシュ通知の登録解除

パートナー センターからターゲット プッシュ通知の受信を停止するアプリの場合は、 [UnregisterNotificationChannelAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesengagementmanager.unregisternotificationchannelasync)メソッドを呼び出します。

[!code-cs[DevCenterNotifications](./code/StoreSDKSamples/cs/DevCenterNotifications.cs#UnregisterNotificationChannelAsync)]

このメソッドは通知に使用されているチャネルを無効にするため、アプリは*いずれの*サービスからもプッシュ通知を受信しなくなることに注意してください。 閉じられた後、チャネルがパートナー センターからターゲット プッシュ通知や WNS を使って他の通知を含む、すべてのサービスをもう一度使用できません。 このアプリでプッシュ通知の送信を再開するには、アプリは新しいチャネルを要求する必要があります。

## <a name="related-topics"></a>関連トピック

* [アプリのユーザーにプッシュ通知を送信する](../publish/send-push-notifications-to-your-apps-customers.md)
* [Windows プッシュ通知サービス (WNS) の概要](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview)
* [通知チャネルを要求、作成、保存する方法](https://docs.microsoft.com/previous-versions/windows/apps/hh868221(v=win.10))
* [Microsoft Store Services SDK](https://docs.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)
