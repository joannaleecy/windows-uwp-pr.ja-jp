---
title: ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する
description: 別のバックグラウンド プロセスで実行されたアプリ サービスのコードを、アプリ サービスのプロバイダーと同じプロセス内で実行されるコードに変換します。
ms.date: 11/03/2017
ms.topic: article
keywords: windows 10, uwp, アプリ サービス
ms.assetid: 30aef94b-1b83-4897-a2f1-afbb4349696a
ms.localizationpriority: medium
ms.openlocfilehash: a976ac69d289a5582c2f3546227adba707ac5297
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8749525"
---
# <a name="convert-an-app-service-to-run-in-the-same-process-as-its-host-app"></a>ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する

[AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) を使うと、別のアプリケーションがバック グラウンドでアプリをスリープ解除し、直接通信することができます。

インプロセスのアプリ サービスを導入することで、実行中の 2 つのフォアグラウンド アプリケーションはアプリ サービス接続経由で直接通信することができます。 アプリ サービスをフォアグラウンド アプリケーションとして同じプロセスで実行できるようになったため、アプリ間の通信がかなり簡単になっただけでなく、サービス コードを別個のプロジェクトに分離する必要がなくなりました。

アウトプロセス モデルのアプリ サービスをインプロセス モデルに変換するには、2 つの変更が必要です。 1 つ目は、マニフェストの変更です。

> ```xml
> <Package
>    ...
>   <Applications>
>       <Application Id=...
>           ...
>           EntryPoint="...">
>           <Extensions>
>               <uap:Extension Category="windows.appService">
>                   <uap:AppService Name="InProcessAppService" />
>               </uap:Extension>
>           </Extensions>
>           ...
>       </Application>
>   </Applications>
> ```

削除、`EntryPoint`から属性、`<Extension>`要素[OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx)アプリ サービスが呼び出されたときに使用されるエントリ ポイントは、ここであるためです。

2 つ目の変更として、サービス ロジックを別個のバックグラウンド タスク プロジェクトから、**OnBackgroundActivated()** によって呼び出すことができるメソッドに移動します。

これで、アプリケーションがアプリ サービスを直接実行できるようになります。 たとえば、App.xaml.cs: 内

[!NOTE] 次のコードでは、例 1 (アウト プロセスのサービス) に使用したものよりも異なります。 次のコードは提供のみを目的と、(インプロセス サービス) の例 2 の一部としては使用する必要があります。  記事の切り替えの例を続けるには、例 2 (インプロセス サービス) に 1 (アウト プロセスのサービス) は、次の例のコードではなく 1 の例のコードを使用に進みます。

``` cs
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
...

sealed partial class App : Application
{
  private AppServiceConnection _appServiceConnection;
  private BackgroundTaskDeferral _appServiceDeferral;

  ...

  protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
  {
      base.OnBackgroundActivated(args);
      IBackgroundTaskInstance taskInstance = args.TaskInstance;
      AppServiceTriggerDetails appService = taskInstance.TriggerDetails as AppServiceTriggerDetails;
      _appServiceDeferral = taskInstance.GetDeferral();
      taskInstance.Canceled += OnAppServicesCanceled;
      _appServiceConnection = appService.AppServiceConnection;
      _appServiceConnection.RequestReceived += OnAppServiceRequestReceived;
      _appServiceConnection.ServiceClosed += AppServiceConnection_ServiceClosed;
  }

  private async void OnAppServiceRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
  {
      AppServiceDeferral messageDeferral = args.GetDeferral();
      ValueSet message = args.Request.Message;
      string text = message["Request"] as string;

      if ("Value" == text)
      {
          ValueSet returnMessage = new ValueSet();
          returnMessage.Add("Response", "True");
          await args.Request.SendResponseAsync(returnMessage);
      }
      messageDeferral.Complete();
  }

  private void OnAppServicesCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
  {
      _appServiceDeferral.Complete();
  }

  private void AppServiceConnection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
  {
      _appServiceDeferral.Complete();
  }
}
```

上記のコードでは、`OnBackgroundActivated` メソッドがアプリ サービスのアクティブ化を処理します。 [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) を通じた通信に必要なすべてのイベントが登録され、タスク保留オブジェクトが格納されて、アプリケーション間の通信が完了したときに完了とマークできるようになります。

アプリが要求を読み取り、`Key` 文字列と `Value` 文字列が存在するかどうかを確認する [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を読み取ります。 存在する場合、アプリ サービスは `Response` 文字列値と `True` 文字列値のペアを、**AppServiceConnection** のもう一方の側にあるアプリに戻します。

他のアプリとの接続と通信について詳しくは、「[アプリ サービスの作成と利用](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service?f=255&MSPPError=-2147217396)」をご覧ください。
