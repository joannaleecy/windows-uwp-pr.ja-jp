---
author: TylerMSFT
title: "ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する"
description: "別のバックグラウンド プロセスで実行されたアプリ サービスのコードを、アプリ サービスのプロバイダーと同じプロセス内で実行されるコードに変換します。"
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 30aef94b-1b83-4897-a2f1-afbb4349696a
ms.openlocfilehash: 015a37c8d85174e6494690a67b4dc23b1cce5712
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="convert-an-app-service-to-run-in-the-same-process-as-its-host-app"></a>ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する

[AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) を使うと、別のアプリケーションがバック グラウンドでアプリをスリープ解除し、直接通信することができます。

インプロセスのアプリ サービスを導入することで、実行中の 2 つのフォアグラウンド アプリケーションはアプリ サービス接続経由で直接通信することができます。 アプリ サービスをフォアグラウンド アプリケーションとして同じプロセスで実行できるようになったため、アプリ間の通信がかなり簡単になっただけでなく、サービス コードを別個のプロジェクトに分離する必要がなくなりました。

アウトプロセス モデルのアプリ サービスをインプロセス モデルに変換するには、2 つの変更が必要です。 1 つ目は、マニフェストの変更です。

> ```xml
>  <uap:Extension Category="windows.appService">
>          <uap:AppService Name="InProcessAppService" />
>  </uap:Extension>
> ```

`EntryPoint` 属性を削除します。 これで、アプリ サービスを呼び出したときに、[OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) コールバックがコールバック メソッドとして使用されるようになります。

2 つ目の変更として、サービス ロジックを別個のバックグラウンド タスク プロジェクトから、**OnBackgroundActivated()** によって呼び出すことができるメソッドに移動します。

これで、アプリケーションがアプリ サービスを直接実行できるようになります。  次に例を示します。

> ``` cs
> private AppServiceConnection appServiceconnection;
> private BackgroundTaskDeferral appServiceDeferral;
> protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
> {
>     base.OnBackgroundActivated(args);
>     IBackgroundTaskInstance taskInstance = args.TaskInstance;
>     AppServiceTriggerDetails appService = taskInstance.TriggerDetails as AppServiceTriggerDetails;
>     appServiceDeferral = taskInstance.GetDeferral();
>     taskInstance.Canceled += OnAppServicesCanceled;
>     appServiceConnection = appService.AppServiceConnection;
>     appServiceConnection.RequestReceived += OnAppServiceRequestReceived;
>     appServiceConnection.ServiceClosed += AppServiceConnection_ServiceClosed;
> }
>
> private async void OnAppServiceRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
> {
>     AppServiceDeferral messageDeferral = args.GetDeferral();
>     ValueSet message = args.Request.Message;
>     string text = message["Request"] as string;
>              
>     if ("Value" == text)
>     {
>         ValueSet returnMessage = new ValueSet();
>         returnMessage.Add("Response", "True");
>         await args.Request.SendResponseAsync(returnMessage);
>     }
>     messageDeferral.Complete();
> }
>
> private void OnAppServicesCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
> {
>     appServiceDeferral.Complete();
> }
>
> private void AppServiceConnection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
> {
>     appServiceDeferral.Complete();
> }
> ```

上記のコードでは、`OnBackgroundActivated` メソッドがアプリ サービスのアクティブ化を処理します。 [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) を通じた通信に必要なすべてのイベントが登録され、タスク保留オブジェクトが格納されて、アプリケーション間の通信が完了したときに完了とマークできるようになります。

アプリが要求を読み取り、`Key` 文字列と `Value` 文字列が存在するかどうかを確認する [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を読み取ります。 存在する場合、アプリ サービスは `Response` 文字列値と `True` 文字列値のペアを、**AppServiceConnection** のもう一方の側にあるアプリに戻します。

他のアプリとの接続と通信について詳しくは、「[アプリ サービスの作成と利用](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service?f=255&MSPPError=-2147217396)」をご覧ください。
