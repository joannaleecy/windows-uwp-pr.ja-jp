---
author: TylerMSFT
title: ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する
description: 別のバックグラウンド プロセスで実行されたアプリ サービスのコードを、アプリ サービスのプロバイダーと同じプロセス内で実行されるコードに変換します。
ms.author: twhitney
ms.date: 11/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリ サービス
ms.assetid: 30aef94b-1b83-4897-a2f1-afbb4349696a
ms.localizationpriority: medium
ms.openlocfilehash: a77ea3cefcc423e710ab0afebb3fa064e61507ec
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3957272"
---
# <a name="convert-an-app-service-to-run-in-the-same-process-as-its-host-app"></a><span data-ttu-id="22ce6-104">ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する</span><span class="sxs-lookup"><span data-stu-id="22ce6-104">Convert an app service to run in the same process as its host app</span></span>

<span data-ttu-id="22ce6-105">[AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) を使うと、別のアプリケーションがバック グラウンドでアプリをスリープ解除し、直接通信することができます。</span><span class="sxs-lookup"><span data-stu-id="22ce6-105">An [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) enables another application to wake up your app in the background and start a direct line of communication with it.</span></span>

<span data-ttu-id="22ce6-106">インプロセスのアプリ サービスを導入することで、実行中の 2 つのフォアグラウンド アプリケーションはアプリ サービス接続経由で直接通信することができます。</span><span class="sxs-lookup"><span data-stu-id="22ce6-106">With the introduction of in-process App Services, two running foreground applications can have a direct line of communication via an app service connection.</span></span> <span data-ttu-id="22ce6-107">アプリ サービスをフォアグラウンド アプリケーションとして同じプロセスで実行できるようになったため、アプリ間の通信がかなり簡単になっただけでなく、サービス コードを別個のプロジェクトに分離する必要がなくなりました。</span><span class="sxs-lookup"><span data-stu-id="22ce6-107">App Services can now run in the same process as the foreground application which makes communication between apps much easier and removes the need to separate the service code into a separate project.</span></span>

<span data-ttu-id="22ce6-108">アウトプロセス モデルのアプリ サービスをインプロセス モデルに変換するには、2 つの変更が必要です。</span><span class="sxs-lookup"><span data-stu-id="22ce6-108">Turning an out-of-process model App Service into an in-process model requires two changes.</span></span> <span data-ttu-id="22ce6-109">1 つ目は、マニフェストの変更です。</span><span class="sxs-lookup"><span data-stu-id="22ce6-109">The first is a manifest change.</span></span>

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

<span data-ttu-id="22ce6-110">削除、`EntryPoint`から属性、`<Extension>`要素[OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx)アプリ サービスが呼び出されたときに使用されるエントリ ポイントは、ここであるためです。</span><span class="sxs-lookup"><span data-stu-id="22ce6-110">Remove the `EntryPoint` attribute from the `<Extension>` element because now [OnBackgroundActivated()](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx) is the entry point that will be used when the app service is invoked.</span></span>

<span data-ttu-id="22ce6-111">2 つ目の変更として、サービス ロジックを別個のバックグラウンド タスク プロジェクトから、**OnBackgroundActivated()** によって呼び出すことができるメソッドに移動します。</span><span class="sxs-lookup"><span data-stu-id="22ce6-111">The second change is to move the service logic from its separate background task project into methods that can be called from **OnBackgroundActivated()**.</span></span>

<span data-ttu-id="22ce6-112">これで、アプリケーションがアプリ サービスを直接実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="22ce6-112">Now your application can directly run your App Service.</span></span> <span data-ttu-id="22ce6-113">たとえば、App.xaml.cs: 内</span><span class="sxs-lookup"><span data-stu-id="22ce6-113">For example, in App.xaml.cs:</span></span>

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

<span data-ttu-id="22ce6-114">上記のコードでは、`OnBackgroundActivated` メソッドがアプリ サービスのアクティブ化を処理します。</span><span class="sxs-lookup"><span data-stu-id="22ce6-114">In the code above the `OnBackgroundActivated` method handles the app service activation.</span></span> <span data-ttu-id="22ce6-115">[AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) を通じた通信に必要なすべてのイベントが登録され、タスク保留オブジェクトが格納されて、アプリケーション間の通信が完了したときに完了とマークできるようになります。</span><span class="sxs-lookup"><span data-stu-id="22ce6-115">All of the events required for communication through an [AppServiceConnection](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appservice.appserviceconnection.aspx) are registered, and the task deferral object is stored so that it can be marked as complete when the communication between the applications is done.</span></span>

<span data-ttu-id="22ce6-116">アプリが要求を読み取り、`Key` 文字列と `Value` 文字列が存在するかどうかを確認する [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="22ce6-116">When the app receives a request and reads the [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) provided to see if the `Key` and `Value` strings are present.</span></span> <span data-ttu-id="22ce6-117">存在する場合、アプリ サービスは `Response` 文字列値と `True` 文字列値のペアを、**AppServiceConnection** のもう一方の側にあるアプリに戻します。</span><span class="sxs-lookup"><span data-stu-id="22ce6-117">If they are present then the app service returns a pair of `Response` and `True` string values back to the app on the other side of the **AppServiceConnection**.</span></span>

<span data-ttu-id="22ce6-118">他のアプリとの接続と通信について詳しくは、「[アプリ サービスの作成と利用](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service?f=255&MSPPError=-2147217396)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="22ce6-118">Learn more about connecting and communicating with other apps at [Create and Consume an App Service](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service?f=255&MSPPError=-2147217396).</span></span>
