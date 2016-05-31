---
author: mijacobs
Description: Visual Studio でウィザードを使うことで、Azure のモバイル サービスで作成されたモバイル サービスからプッシュ通知を生成できます。
title: プッシュ通知ウィザードにより生成されるコード
ms.assetid: 340F55C1-0DDF-4233-A8E4-C15EF9030785
label: TBD
template: detail.hbs
---

# プッシュ通知ウィザードにより生成されるコード




Visual Studio でウィザードを使うことで、Azure のモバイル サービスで作成されたモバイル サービスからプッシュ通知を生成できます。 Visual Studio ウィザードにより、この作業に役立つコードが生成されます。 このトピックでは、ウィザードによるプロジェクトの変更内容、生成されたコードによる実行内容、このコードを使う方法、プッシュ通知を最大限に活用するために次に行うことができる作業について説明します。 「[Windows プッシュ通知サービス (WNS) の概要](tiles-and-notifications-windows-push-notification-services--wns--overview.md)」をご覧ください。

## <span id="How_the_wizard_modifies_your_project"></span><span id="how_the_wizard_modifies_your_project"></span><span id="HOW_THE_WIZARD_MODIFIES_YOUR_PROJECT"></span>ウィザードによるプロジェクトの変更内容


プッシュ通知ウィザードは、次のようにプロジェクトを変更します。

-   モバイル サービスの管理されたクライアントへの参照を追加します (MobileServicesManagedClient.dll)。 JavaScript プロジェクトには当てはまりません。
-   サービスの下にあるサブフォルダーにファイルを追加し、ファイルに push.register.cs、push.register.vb、push.register.cpp、または push.register.js という名前を付けます。
-   モバイル サービスのデータベース サーバーでチャネル テーブルを作成します。 テーブルには、アプリ インスタンスにプッシュ通知を送るために必要な情報が格納されます。
-   4 つの機能 (削除、挿入、読み取り、更新) のスクリプトを作成します。
-   カスタム API を含むスクリプト notifyallusers.js を作成します。この API は、すべてのクライアントにプッシュ通知を送ります。
-   App.xaml.cs、App.xaml.vb、または App.xaml.cpp ファイルに宣言を追加したり、JavaScript プロジェクトの新しいファイルである service.js に宣言を追加したりします。 宣言では、モバイル サービスへの接続に必要な情報を含む MobileServiceClient オブジェクトが宣言されます。 App.*MyServiceName*Client という名前を使って、アプリ内のどのページからでも *MyServiceName*Client という名前のこの MobileServiceClient オブジェクトにアクセスできます。

services.js ファイルには、次のコードが含まれています。

```JavaScript
var <mobile-service-name>Client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
                "https://<mobile-service-name>.azure-mobile.net/",
                "<your client secret>");
```

## <span id="Registration_for_push_notifications"></span><span id="registration_for_push_notifications"></span><span id="REGISTRATION_FOR_PUSH_NOTIFICATIONS"></span>プッシュ通知への登録


push.register.\* 内の UploadChannel メソッドは、プッシュ通知を受信するデバイスを登録します。 ストアは、アプリのインストールされたインスタンスを追跡し、プッシュ通知チャネルを提供します。 「[**PushNotificationChannelManager**](https://msdn.microsoft.com/library/windows/apps/br241284)」をご覧ください。

クライアント コードは、JavaScript のバックエンドと .NET のバックエンドの両方に似ています。 既定では、JavaScript バックエンド サービスのプッシュ通知を追加すると、notifyAllUsers カスタム API のサンプル呼び出しが UploadChannel メソッドに挿入されます。

```CSharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace App2
{
    internal class mymobileservice1234Push
    {
        public async static void UploadChannel()
        {
            var channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            try
            {
                await App.mymobileservice1234Client.GetPush().RegisterNativeAsync(channel.Uri);
                await App.mymobileservice1234Client.InvokeApiAsync("notifyAllUsers");
            }
            catch (Exception exception)
            {
                HandleRegisterException(exception);
            }
        }

        private static void HandleRegisterException(Exception exception)
        {
            
        }
    }
}
```

```VisualBasic
Imports Microsoft.WindowsAzure.MobileServices
Imports Newtonsoft.Json.Linq

Friend Class mymobileservice1234Push
    Public Shared Async Sub UploadChannel()
        Dim channel = Await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync()

        Try
            Await App.mymobileservice1234Client.GetPush().RegisterNativeAsync(channel.Uri)
            Await App.mymobileservice1234Client.GetPush().RegisterNativeAsync(channel.Uri, New String() {"tag1", "tag2"})
            Await App.mymobileservice1234Client.InvokeApiAsync("notifyAllUsers")
        Catch exception As Exception
            HandleRegisterException(exception)
        End Try
    End Sub

    Private Shared Sub HandleRegisterException(exception As Exception)

    End Sub
End Class
```

```ManagedCPlusPlus
#include "pch.h"
#include "services\mobile services\mymobileservice1234\mymobileservice1234Push.h"

using namespace AzureMobileHelper;

using namespace web;
using namespace concurrency;

using namespace Windows::Networking::PushNotifications;

void mymobileservice1234Push::UploadChannel()
{
    create_task(PushNotificationChannelManager::CreatePushNotificationChannelForApplicationAsync()).
    then([] (PushNotificationChannel^ newChannel) 
    {
        return mymobileservice1234MobileService::GetClient().get_push().register_native(newChannel-&amp;gt;Uri-&amp;gt;Data());
    }).then([]()
    {
        return mymobileservice1234MobileService::GetClient().invoke_api(L"notifyAllUsers");
    }).then([](task&amp;lt;json::value&amp;gt; result)
    {
        try
        {
            result.wait();
        }
        catch(...)
        {
            HandleExceptionsComingFromTheServer();
        }
    });
}

void mymobileservice1234Push::HandleExceptionsComingFromTheServer()
{
}
```

```JavaScript
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.addEventListener("activated", function (args) {
        if (args.detail.kind == activation.ActivationKind.launch) {
            Windows.Networking.PushNotifications.PushNotificationChannelManager.createPushNotificationChannelForApplicationAsync()
                .then(function (channel) {
                    mymobileserviceclient1234Client.push.registerNative(channel.Uri, new Array("tag1", "tag2"))
                    return mymobileservice1234Client.push.registerNative(channel.uri);
                })
                .done(function (registration) {
                    return mymobileservice1234Client.invokeApi("notifyAllUsers");
                }, function (error) {
                    // Error

                });
        }
    });
})();
```

プッシュ通知のタグがクライアントのサブセットへの通知を制限する方法を提供します。 registerNative メソッド (または RegisterNativeAsync) メソッドを使って、タグを指定せずにすべてのプッシュ通知に登録するか、2 番目の引数としてタグの配列を指定することによって、タグを指定して登録できます。 1 つまたは複数のタグを登録すると、タグに一致する通知のみを受け取ります。

## <span id="Server-side_scripts__JavaScript_backend_only_"></span><span id="server-side_scripts__javascript_backend_only_"></span><span id="SERVER-SIDE_SCRIPTS__JAVASCRIPT_BACKEND_ONLY_"></span>サーバー側のスクリプト (JavaScript バックエンドのみ)


JavaScript バックエンドを使うモバイル サービスの場合、サーバー側のスクリプトは、削除、挿入、読み取り、または更新操作が行われたときに実行されます。 スクリプトにはこれらの操作が実装されていませんが、クライアントから Windows モバイルの REST API への呼び出しによってこれらのイベントがトリガーされると実行されます。 次に、スクリプトは request.execute または request.respond を呼び出して呼び出し元コンテキストに応答を発行することで、コントロールを操作自体に渡します。 「[Azure のモバイル サービスの REST API リファレンス](http://go.microsoft.com/fwlink/p/?linkid=511139)」をご覧ください。

サーバー側のスクリプトでは、さまざまな関数を使うことができます。 「[Azure のモバイル サービスでのテーブル操作の登録](http://go.microsoft.com/fwlink/p/?linkid=511140)」をご覧ください。 使用できる関数のリファレンスについては、「[Mobile Services サーバーのスクリプトのリファレンス](http://go.microsoft.com/fwlink/p/?linkid=257676)」をご覧ください。

また、Notifyallusers.js に次のカスタム API コードが作成されます。

```JavaScript
exports.post = function(request, response) {
    response.send(statusCodes.OK,{ message : &#39;Hello World!&#39; })
    
    // The following call is for illustration purpose only
    // The call and function body should be moved to a script in your app
    // where you want to send a notification
    sendNotifications(request);
};

// The following code should be moved to appropriate script in your app where notification is sent
function sendNotifications(request) {
    var payload = &#39;<?xml version="1.0" encoding="utf-8"?><toast><visual><binding template="ToastText01">&#39; +
        &#39;<text id="1">Sample Toast</text></binding></visual></toast>&#39;;
    var push = request.service.push; 
    push.wns.send(null,
        payload,
        &#39;wns/toast&#39;, {
            success: function (pushResponse) {
                console.log("Sent push:", pushResponse);
            }
        });
}
```

sendNotifications 関数は、1 つの通知をトースト通知として送信します。 他の種類のプッシュ通知を使うこともできます。

**ヒント**  スクリプトの編集中にヘルプを表示する方法については、[サーバー側の JavaScript で IntelliSense を有効にする方法](http://go.microsoft.com/fwlink/p/?LinkId=309275)に関するページをご覧ください。

 

## <span id="Push_notification_types"></span><span id="push_notification_types"></span><span id="PUSH_NOTIFICATION_TYPES"></span>プッシュ通知の種類


Windows では、プッシュ通知ではない通知がサポートされています。 通知に関する一般情報については、「[スケジュールされた通知、定期的な通知、プッシュ通知の送信](https://msdn.microsoft.com/library/windows/apps/hh761484)」をご覧ください。

トースト通知は使いやすく、自動的に生成されるチャネル テーブルの Insert.js コードで例を確認できます。 タイル通知かバッジ通知を使う予定の場合、タイルとバッジの XML テンプレートを作成し、テンプレートでパッケージ化された情報のエンコードを指定する必要があります。 「[タイル、バッジ、トースト通知の操作](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259)」をご覧ください。

Windows は、プッシュ通知に応答するため、アプリが実行されていないときにこれらの通知のほとんどを処理できます。 たとえば、プッシュ通知は、ローカル メール アプリが実行されていないときでも新しいメール メッセージを受信したことをユーザーに知らせることができます。 Windows は、テキスト メッセージの先頭行のようなメッセージを表示することで、トースト通知を処理します。 Windows は、ライブ タイルを更新して新しいメール メッセージの数を反映することで、タイル通知またはバッジ通知を処理します。 このように、新しい情報をチェックするように促すプロンプトをアプリのユーザーに表示できます。 アプリは、実行中に直接通知を受け取ることができるため、直接通知を使ってアプリにデータを送ることができます。 アプリが実行されていない場合、プッシュ通知を監視するバックグラウンド タスクを設定できます。

プッシュ通知は、ユーザーのリソースを消費し、使いすぎると煩わしくなる場合があるため、ユニバーサル Windows プラットフォーム (UWP) アプリに従って使ってください。 「[プッシュ通知のガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh761462)」をご覧ください。

プッシュ通知でライブ タイルを更新する場合は、「[タイルとバッジのガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh465403)」のガイドラインにも従ってください。

## <span id="Next_steps"></span><span id="next_steps"></span><span id="NEXT_STEPS"></span>次のステップ


### <span id="Using_the_Windows_Push_Notification_Services__WNS_"></span><span id="using_the_windows_push_notification_services__wns_"></span><span id="USING_THE_WINDOWS_PUSH_NOTIFICATION_SERVICES__WNS_"></span>Windows プッシュ通知サービス (WNS) の使用

Window Azure のモバイル サービスの柔軟性が不十分な場合、C# または Visual Basic でサーバー コードを記述する場合、または既にクラウド サービスを持っていてそこからプッシュ通知を送る場合は、Windows プッシュ通知サービス (WNS) を直接呼び出すこともできます。 WNS を直接呼び出すことで、データベースや他の Web サービスからのデータを監視するワーカーの役割など、独自のクラウド サービスからプッシュ通知を送ることができます。 クラウド サービスがプッシュ通知をアプリに送るには、WNS に対して認証する必要があります。 [Windows プッシュ通知サービスに対して認証する方法 (JavaScript)](https://msdn.microsoft.com/library/windows/apps/hh465407) または [(C#/C++/VB)](https://msdn.microsoft.com/library/windows/apps/xaml/hh868206) に関するページをご覧ください。

モバイル サービスでスケジュール済みタスクを実行して、プッシュ通知を送ることもできます。 「[Mobile Services での繰り返し発生するジョブのスケジュール](http://go.microsoft.com/fwlink/p/?linkid=301694)」をご覧ください。

**警告**  プッシュ通知ウィザードは 1 回だけ実行してください。もう一度実行して、別のモバイル サービスの登録コードを追加しないようにしてください。 このウィザードをプロジェクトごとに複数回実行すると、生成されるコードで [**CreatePushNotificationChannelForApplicationAsync**](https://msdn.microsoft.com/library/windows/apps/br241287) メソッドの呼び出しが重複し、ランタイムの例外が発生します。 複数のモバイル サービスのプッシュ通知を登録するには、ウィザードを 1 回だけ実行し、登録コードを上書きして、**CreatePushNotificationChannelForApplicationAsync** の呼び出しが同時に実行されないようにしてください。 そのために、ウィザードによって push.register.\* に生成されたコード (**CreatePushNotificationChannelForApplicationAsync** の呼び出しを含む) を OnLaunched イベント以外の場所に移すという方法もありますが、細かい処理はアプリのアーキテクチャによって異なります。

 

## <span id="related_topics"></span>関連トピック


* [Windows プッシュ通知サービス (WNS) の概要](tiles-and-notifications-windows-push-notification-services--wns--overview.md)
* [直接通知の概要](tiles-and-notifications-raw-notification-overview.md)
* [Window Azure のモバイル サービスへの接続 (JavaScript)](https://msdn.microsoft.com/library/windows/apps/dn263160)
* [Window Azure のモバイル サービスへの接続 (C#/C++/VB)](https://msdn.microsoft.com/library/windows/apps/xaml/dn263175)
* [クイック スタート: モバイル サービスでのプッシュ通知の追加 (JavaScript)](https://msdn.microsoft.com/library/windows/apps/dn263163)
 

 






<!--HONumber=May16_HO2-->


