---
description: 延長実行を使用して、アプリが最小化されているときにアプリの実行を保持する方法について説明します。
title: 延長実行を使ってアプリの中断を延期する
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, 延長実行, 最小化, ExtendedExecutionSession, バックグラウンド タスク, アプリケーション ライフサイクル, ロック画面
ms.assetid: e6a6a433-5550-4a19-83be-bbc6168fe03a
ms.localizationpriority: medium
ms.openlocfilehash: 8cc67a7593a340ada8f807fc0fb0c1b846c6f05b
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7836374"
---
# <a name="postpone-app-suspension-with-extended-execution"></a>延長実行を使ってアプリの中断を延期する

この記事では、アプリが最小化されている状態またはロック画面で実行できるように、延長実行を使用してアプリが中断されるタイミングを延期する方法について説明します。

ユーザーがアプリを最小化するか別のアプリなどに切り替えると、アプリは中断状態になります。  アプリのメモリは維持されますが、コードは実行されません。 これは、視覚的なユーザー インターフェイスを備えたすべての OS エディションに当てはまります。 アプリの中断状態について詳しくは、「[アプリケーションのライフサイクル](app-lifecycle.md)」をご覧ください。 

ユーザーがアプリから移動して離れるとき、またはアプリが最小化されているときに、中断するのではなく、実行を維持する必要がある場合があります。 たとえば、ユーザーが他のアプリを使用するために移動しても、ステップ カウント アプリは実行を維持し、ステップを追跡する必要があります。 

アプリが実行し続ける必要がある場合、OS によって実行を維持することも、アプリから実行の継続を要求することもできます。 たとえば、バックグラウンドでオーディオを再生している場合、「[バックグラウンドでのメディアの再生](../audio-video-camera/background-audio.md)」の手順に従うと、OS によってアプリの実行を延長できます。 この手順に従わない場合は、手動で実行延長を要求する必要があります。 バックグラウンド実行にかかる時間は数分である可能性がありますが、いつでも失効されたセッションを処理できるようにしておく必要があります。 このようなアプリケーションのライフ サイクル時間の制約は、アプリの実行時にデバッガーで無効になっています。 このような理由から、デバッガーで、または Visual Studio で利用可能なライフサイクル イベントを使用して、実行されていないときにアプリの中断を延期するための延長実行やその他のツールをテストすることが重要です。 
 
バックグラウンドで操作を完了するまで実行の延長を要求するには、[ExtendedExecutionSession](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionsession.aspx) を作成します。 作成する **ExtendedExecutionSession** の種類は、作成時に提供する [ExtendedExecutionReason](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionreason.aspx) によって決まります。 **ExtendedExecutionReason** 列挙値には、**Unspecified、LocationTracking**、および **SavingData** の 3 種類があります。 常に 1 つの **ExtendedExecutionSession** のみを要求できます。ある承認されたセッション要求が現在アクティブのときに別のセッションを作成しようとすると、**ExtendedExecutionSession** コンストラクターから例外 0x8007139F がスローされ、グループまたはリソースが要求された操作を実行するために適切な状態にないことが示されます。 [ExtendedExecutionForegroundSession](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundsession.aspx) と [ExtendedExecutionForegroundReason](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.extendedexecution.foreground.extendedexecutionforegroundreason.aspx) は、制限された機能が必要で、ストア アプリケーションで利用できないため、使用しないでください。

## <a name="run-while-minimized"></a>最小化状態での実行

延長実行を使用できる 2 つのケースがあります。
- アプリケーションが実行状態にあるとき、通常のフォアグラウンド実行中の任意の時点。
- アプリケーションが中断イベント (OS がアプリを中断状態に移行しようとしている) をアプリケーションの中断イベント ハンドラーで受け取った後。

これら 2 つのケースのコードは同じですが、それぞれのケースでアプリケーションが少し異なる方法で動作します。 最初のケースでは、通常は中断をトリガーするイベントが発生したときでもアプリケーションは実行状態にとどまります (たとえば、ユーザーがアプリケーションから移動するとき)。 延長実行が有効であるときは、アプリケーションが中断イベントを受け取ることはありません。 拡張子が破棄されると、アプリケーションがもう一度中断の対象になります。

2 つ目のケースでは、アプリケーションが中断状態に移行している場合に、実行の期間中、中断状態にとどまります。 実行の有効期限が切れると、アプリケーションは特に通知することなく中断状態になります。

メディア処理、プロジェクトのコンパイル、またはネットワーク接続の維持などのシナリオで、アプリがバックグラウンドに移行する前に追加の時間を要求する **ExtendedExecutionSession** を作成するときには、**ExtendedExecutionReason.Unspecified** を使用します。 Windows 10 のデスクトップ エディション (Home、Pro、Enterprise、および Education) を実行しているデスクトップ デバイスでは、最小化状態のときにアプリの中断を回避するには、この方法を使用します。

実行時間の長い操作を開始するときに延長を要求して、**Suspending** 状態の遷移を遅らせます。要求しない場合、アプリはバックグラウンドになるとこの状態に遷移します。 デスクトップ デバイスでは、**ExtendedExecutionReason.Unspecified** によって作成された延長実行セッションには、バッテリを考えた時間制限があります。 デバイスが電源コンセントにつながれている場合は、延長実行の時間の長さに制限はありません。 デバイスがバッテリで動作している場合は、延長実行はバックグラウンドで最大 10 分実行できます。

タブレットまたはノート PC を使用している場合も、**[アプリによるバッテリーの使用]** 設定の **[アプリにバックグラウンド タスクの実行を許可する]** オプションを選択していると、バッテリーを消費しますが、同じように長時間実行できます。 ノート PC でこのオプションにアクセスするには、**[設定]** > **[システム]** > **[バッテリー]** > **[アプリによるバッテリーの使用]** (バッテリ残量のパーセント値の下にあるリンク) の順に選択し、アプリを選択します。次に、**[Windows で管理]** をオフにし、**[アプリにバックグラウンド タスクの実行を許可する]** を選択します。  

どの OS エディションでも、デバイスがコネクト スタンバイ状態になると、このような延長実行セッションは停止します。 Windows 10 Mobile を実行しているモバイル デバイスでは、画面がオンである間だけ、このような延長実行セッションが実行されます。 画面がオフになると、デバイスは直ちに省電力のコネクト スタンバイ状態になります。 デスクトップ デバイスでは、ロック画面が表示されても、延長実行セッションは続行されます。 画面がオフになった後も、しばらくの間、デバイスはコネクト スタンバイ状態になりません。 Xbox OS エディションでは、ユーザーが既定を変更していない限り、1 時間後にデバイスはコネクト スタンバイ状態になります。

## <a name="track-the-users-location"></a>ユーザーの位置情報の追跡

アプリが定期的に [GeoLocator](https://msdn.microsoft.com/library/windows/apps/windows.devices.geolocation.geolocator.aspx) による位置情報を記録する必要がある場合は、**ExtendedExecutionSession** を作成するときに、**ExtendedExecutionReason.LocationTracking** を指定します。 ユーザーの位置情報を定期的に監視する必要があるフィットネス対応アプリやナビ アプリでは、この ExtendedExecutionReason 設定を使用します。

位置情報追跡のための延長実行セッションは、モバイル デバイスの画面がロックされている間も含め、必要なだけの時間で実行できます。 ただし、このようなセッションは 1 台のデバイスにつき、1 セッションしか保持できません。 位置情報追跡のための延長実行セッションは、フォアグラウンドでしか要求できず、アプリは **Running** 状態である必要があります。 これにより、アプリが位置情報追跡の延長セッションを開始したことをユーザーに認識されるようにしています。 ただし、位置情報追跡のための延長実行セッションを要求せずに、バックグラウンド タスクかアプリ サービスを使用することで、アプリがバックグラウンドにある場合も、GeoLocator を使用できます。

## <a name="save-critical-data-locally"></a>重要なデータのローカルでの保存

アプリが終了される前にデータを保存しておかないと、データが失われ、否定的なユーザー エクスペリエンスにつながる場合は、**ExtendedExecutionSession** を作成するときに **ExtendedExecutionReason.SavingData** を指定して、ユーザー データを保存します。

データのアップロードまたはダウンロードのために、このようなセッションを使用して、アプリの実行時間を延長しないでください。 データのアップロードが必要な場合は、[バックグラウンド転送](https://msdn.microsoft.com/windows/uwp/networking/background-transfers)を要求するか、**MaintenanceTrigger** を登録して、AC 電源を利用できるときに、転送を処理してください。 **ExtendedExecutionReason.SavingData** 延長セッションを要求できるのは、アプリがフォアグラウンドで **Running**状態であるか、バックグラウンドで**Suspending** 状態である場合です。

**Suspending** 状態は、アプリのライフサイクル中で、アプリが終了する前にアプリが作業を実行できる最後のチャンスです。 **ExtendedExecutionReason.SavingData** は、**Suspending** 状態で要求できる、**ExtendedExecutionSession** の唯一の種類です。 アプリが **Suspending** 状態のときに **ExtendedExecutionReason.SavingData** 延長実行セッションを要求すると、注意が必要な問題が発生する可能性があります。 **Suspending** 状態のときに延長実行セッションが要求され、ユーザーがアプリの再起動を要求した場合、起動に時間がかかるように感じられる可能性があります。 これは、延長実行セッションの時間が経過しないと、アプリの以前のインスタンスを終了して、アプリの新しいインスタンスを起動することができないためです。 ユーザー状態が失われることを確実に防ぐため、起動にかかる時間が犠牲になります。

## <a name="request-disposal-and-revocation"></a>要求、破棄、および失効

延長実行セッションには、要求、破棄、および失効の 3 つの基本的な操作があります。  次のコード スニペットは、要求を行う例を示しています。

### <a name="request"></a>要求

```csharp
var newSession = new ExtendedExecutionSession();
newSession.Reason = ExtendedExecutionReason.Unspecified;
newSession.Revoked += SessionRevoked;
ExtendedExecutionResult result = await newSession.RequestExtensionAsync();

switch (result)
{
    case ExtendedExecutionResult.Allowed:
        DoLongRunningWork();
        break;

    default:
    case ExtendedExecutionResult.Denied:
        DoShortRunningWork();
        break;
}
```
[コード サンプルを見る](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario1_UnspecifiedReason.xaml.cs#L81-L110)  

**RequestExtensionAsync** を呼び出すと、ユーザーがアプリのバックグラウンド アクティビティを承認しているかどうかと、バックグラウンドで実行できるだけのリソースがシステムにあるかどうかについて、オペレーティング システムが確認されます。 アプリで常に 1 つのセッションのみが承認されるため、**RequestExtensionAsync** への追加の呼び出しでセッションが拒否されます。

あらかじめ [BackgroundExecutionManager](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) をチェックして、アプリがバックグラウンドで実行できるかどうかを示すユーザー設定である [BackgroundAccessStatus](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundaccessstatus.aspx?f=255&MSPPError=-2147217396) の状態を特定することもできます。 これらのユーザー設定について詳しくは、「[Background Activity and Energy Awareness (バックグラウンド アクティビティと省電力対策)](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#XWK8mEgWD7JHvC10.97)」をご覧ください。

**ExtendedExecutionReason** は、アプリがバックグラウンドで実行する操作を示します。 **Description** の文字列は、アプリがその操作を実行しなければならない理由を説明する、人間が読める文字列です。 この文字列はユーザーに表示されませんが、Windows の将来のリリースで利用可能になる可能性があります。 ユーザーまたはシステムによって、アプリをこれ以上バックグラウンドで実行できないと判断された場合に、延長実行セッションが適切に停止されるように、**Revoked** イベント ハンドラーを指定する必要があります。

### <a name="revoked"></a>失効

アプリにアクティブな延長実行セッションがあり、フォアグラウンド アプリケーションでリソースが必要であるため、システムがバックグラウンド アクティビティを停止する必要がある場合、セッションは失効されます。 最初に **Revoked** イベント ハンドラーが発生しないと、延長実行セッションが途中で終了されることはありません。

**ExtendedExecutionReason.SavingData** 延長実行セッションに対して **Revoked** イベントが発生すると、アプリには実行中の操作を完了し、**Suspending** を終了するために 1 秒間が与えられます。

実行時間の制限に達した、バックグラウンドの割り当て電力の上限に達した、ユーザーがフォアグラウンドで新しいアプリを開けるように、メモリを再利用する必要があるなど、失効が発生する理由はさまざまです。

Revoked イベント ハンドラーの例を次に示します。

```cs
private async void SessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
{
    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        switch (args.Reason)
        {
            case ExtendedExecutionRevokedReason.Resumed:
                rootPage.NotifyUser("Extended execution revoked due to returning to foreground.", NotifyType.StatusMessage);
                break;

            case ExtendedExecutionRevokedReason.SystemPolicy:
                rootPage.NotifyUser("Extended execution revoked due to system policy.", NotifyType.StatusMessage);
                break;
        }

        EndExtendedExecution();
    });
}
```
[コード サンプルを見る](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario1_UnspecifiedReason.xaml.cs#L124-L141)

### <a name="dispose"></a>破棄

最後の手順では、延長実行セッションを破棄します。 延長実行セッションや、その他の大量にメモリを消費するアセットは、破棄することをお勧めします。破棄しないと、セッションの終了を待機している間にアプリが使用する電力が、アプリの割り当て電力に対してカウントされます。 アプリの割り当て電力の消費をできるだけ防ぐには、アプリが速やかに **Suspended** 状態に移行できるよう、セッションの作業が終了したらセッションを破棄することが重要です。

失効イベントの発生を待たず、自分でセッションを破棄することで、アプリの割り当て電力の消費を抑えることができます。 つまり、今後のセッションで、使用できる割り当て電力をより多く確保できているため、アプリをバックグラウンドで実行できる時間が長くなります。 **Dispose** メソッドを呼び出せるように、操作の終了まで、**ExtendedExecutionSession** オブジェクトへの参照は保持しておく必要があります。

延長実行セッションを破棄するスニペット次に示します。

```cs
void ClearExtendedExecution(ExtendedExecutionSession session)
{
    if (session != null)
    {
        session.Revoked -= SessionRevoked;
        session.Dispose();
        session = null;
    }
}
```
[コード サンプルを見る](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario1_UnspecifiedReason.xaml.cs#L49-L63)

アプリのアクティブな **ExtendedExecutionSession** は、一度に 1 つしか保持できません。 多くのアプリでは、ストレージ、ネットワーク、またはネットワーク ベースのサービスなどのリソースにアクセスする必要がある複雑な操作を完了するために、非同期タスクを使用します。 複数の非同期タスクを完了する必要がある操作の場合、各タスクの状態が、**ExtendedExecutionSession** を破棄し、アプリの中断を許可できる状態になっている必要があります。 それには、まだ実行中のタスクの数の参照カウントを行い、その値がゼロになるまでセッションを破棄しないでおく必要があります。

以下に、延長実行セッション中に複数のタスクを管理するコード例を示します。 アプリでこれを使用する方法の詳細については、以下にリンクが示されているコード サンプルを参照してください。

```cs
static class ExtendedExecutionHelper
{
    private static ExtendedExecutionSession session = null;
    private static int taskCount = 0;

    public static bool IsRunning
    {
        get
        {
            if (session != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static async Task<ExtendedExecutionResult> RequestSessionAsync(ExtendedExecutionReason reason, TypedEventHandler<object, ExtendedExecutionRevokedEventArgs> revoked, String description)
    {
        // The previous Extended Execution must be closed before a new one can be requested.       
        ClearSession();

        var newSession = new ExtendedExecutionSession();
        newSession.Reason = reason;
        newSession.Description = description;
        newSession.Revoked += SessionRevoked;

        // Add a revoked handler provided by the app in order to clean up an operation that had to be halted prematurely
        if(revoked != null)
        {
            newSession.Revoked += revoked;
        }

        ExtendedExecutionResult result = await newSession.RequestExtensionAsync();

        switch (result)
        {
            case ExtendedExecutionResult.Allowed:
                session = newSession;
                break;
            default:
            case ExtendedExecutionResult.Denied:
                newSession.Dispose();
                break;
        }
        return result;
    }

    public static void ClearSession()
    {
        if (session != null)
        {
            session.Dispose();
            session = null;
        }

        taskCount = 0;
    }

    public static Deferral GetExecutionDeferral()
    {
        if (session == null)
        {
            throw new InvalidOperationException("No extended execution session is active");
        }

        taskCount++;
        return new Deferral(OnTaskCompleted);
    }

    private static void OnTaskCompleted()
    {
        if (taskCount > 0)
        {
            taskCount--;
        }
        
        //If there are no more running tasks than end the extended lifetime by clearing the session
        if (taskCount == 0 && session != null)
        {
            ClearSession();
        }
    }

    private static void SessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
    {
        //The session has been prematurely revoked due to system constraints, ensure the session is disposed
        if (session != null)
        {
            session.Dispose();
            session = null;
        }
        
        taskCount = 0;
    }
}
```
[コード サンプルを見る](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario4_MultipleTasks.xaml.cs)

## <a name="ensure-that-your-app-uses-resources-well"></a>アプリがリソースを適切に使用するための処理

アプリがバックグラウンドに移行した後も、実行を継続できるためには、アプリのメモリや電力使用を調整することが重要です。 [メモリ管理 API](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx) を使用して、アプリが使用しているメモリ量を確認します。 アプリが使用するメモリ量が多くなるほど、別のアプリがフォアグラウンドのときに、アプリの実行を OS が維持することは難しくなります。 アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。

[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。 バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。

## <a name="see-also"></a>関連項目

[延長実行のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ExtendedExecution)  
[アプリケーションのライフサイクル](https://msdn.microsoft.com/windows/uwp/launch-resume/app-lifecycle)  
[アプリ ライフサイクル - バックグラウンド タスクと延長実行によるアプリ稼働状態の維持](https://msdn.microsoft.com/en-us/magazine/mt590969.aspx)
[バック グラウンド メモリの管理](https://msdn.microsoft.com/windows/uwp/launch-resume/reduce-memory-usage)  
[バックグラウンド転送](https://msdn.microsoft.com/windows/uwp/networking/background-transfers)  
[バッテリー対策とバックグラウンド アクティビティ](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#I2bkQ6861TRpbRjr.97)  
[MemoryManager クラス](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.aspx)  
[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)  