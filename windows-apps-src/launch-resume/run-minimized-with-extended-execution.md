---
author: TylerMSFT
description: "延長実行を使用して、アプリが最小化されているときにアプリの実行を保持する方法について説明します。"
title: "延長実行を使った最小化状態での実行"
translationtype: Human Translation
ms.sourcegitcommit: e9fcb1f0d1248de25d576029d50070792ad72182
ms.openlocfilehash: 40b2a15379129142a84c4a5caf4317dc50041e06

---

# <a name="run-while-minimized-with-extended-execution"></a>延長実行を使った最小化状態での実行

この記事では、アプリが最小化されている状態で実行できるように、延長実行を使用してアプリが中断されるタイミングを延期する方法について説明します。

ユーザーがアプリを最小化するか別のアプリなどに切り替えると、アプリは中断状態になります。  アプリのメモリは維持されますが、コードは実行されません。 これは、視覚的なユーザー インターフェイスを備えたすべての OS エディションに当てはまります。 アプリの中断状態について詳しくは、「[アプリケーションのライフサイクル](app-lifecycle.md)」をご覧ください。

アプリが最小化されているときに、中断するのではなく、実行を維持する必要がある場合があります。 アプリが実行し続ける必要がある場合、OS によって実行を維持することも、アプリから実行の継続を要求することもできます。 たとえば、バックグラウンドでオーディオを再生している場合、「[バックグラウンドでのメディアの再生](../audio-video-camera/background-audio.md)」の手順に従うと、OS によってアプリの実行を延長できます。 この手順に従わない場合は、手動で実行延長を要求する必要があります。

バックグラウンドで操作を完了するまで実行の延長を要求するには、[ExtendedExecutionSession](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionsession.aspx) を作成します。 作成する **ExtendedExecutionSession** の種類は、作成時に提供する [ExtendedExecutionReason](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.extendedexecution.extendedexecutionreason.aspx) によって決まります。 **ExtendedExecutionReason** 列挙値には、**Unspecified、LocationTracking**、および **SavingData** の 3 種類があります。

## <a name="run-while-minimized"></a>最小化状態での実行

メディア処理、プロジェクトのコンパイル、またはネットワーク接続の維持などのシナリオで、アプリがバックグラウンドに移行する前に追加の時間を要求する **ExtendedExecutionSession** を作成するときには、**ExtendedExecutionReason.Unspecified** を指定します。 Windows 10 のデスクトップ エディション (Home、Pro、Enterprise、および Education) を実行しているデスクトップ デバイスでは、最小化状態のときにアプリの中断を回避するには、この方法を使用します。

実行時間の長い操作を開始するときに延長を要求して、**Suspending** 状態の遷移を遅らせます。要求しない場合、アプリはバックグラウンドになるとこの状態に遷移します。 デスクトップ デバイスでは、**ExtendedExecutionReason.Unspecified** によって作成された延長実行セッションには、バッテリを考えた時間制限があります。 デバイスが電源コンセントにつながれている場合は、延長実行の時間の長さに制限はありません。 デバイスがバッテリで動作している場合は、延長実行はバックグラウンドで最大 10 分実行できます。 タブレットまたはノート PC を使用している場合も、**[バッテリー節約機能の設定]** の **[常に許可]** オプションを選択していると、バッテリーを消費しますが、同じように長時間実行できます。

どの OS エディションでも、デバイスがコネクト スタンバイ状態になると、このような延長実行セッションは停止します。 Windows 10 Mobile を実行しているモバイル デバイスでは、画面がオンである間だけ、このような延長実行セッションが実行されます。 画面がオフになると、デバイスは直ちに省電力のコネクト スタンバイ状態になります。 デスクトップ デバイスでは、ロック画面が表示されても、延長実行セッションは続行されます。 画面がオフになった後も、しばらくの間、デバイスはコネクト スタンバイ状態になりません。 Xbox OS エディションでは、ユーザーが既定を変更していない限り、1 時間後にデバイスはコネクト スタンバイ状態になります。

## <a name="track-the-users-location"></a>ユーザーの位置情報の追跡

アプリが定期的に [GeoLocator](https://msdn.microsoft.com/en-us/library/windows/apps/windows.devices.geolocation.geolocator.aspx) による位置情報を記録する必要がある場合は、**ExtendedExecutionSession** を作成するときに、**ExtendedExecutionReason.LocationTracking** を指定します。 ユーザーの位置情報を定期的に監視する必要があるフィットネス対応アプリやナビ アプリでは、この ExtendedExecutionReason 設定を使用します。

位置情報追跡のための延長実行セッションは、必要なだけの時間で実行できます。 ただし、このようなセッションは 1 台のデバイスにつき、1 セッションしか保持できません。 位置情報追跡のための延長実行セッションは、フォアグラウンドでしか要求できず、アプリは **Running** 状態である必要があります。 これにより、アプリが位置情報追跡の延長セッションを開始したことをユーザーに認識されるようにしています。 ただし、位置情報追跡のための延長実行セッションを要求せずに、バックグラウンド タスクかアプリ サービスを使用することで、アプリがバックグラウンドにある場合も、GeoLocator を使用できます。

## <a name="save-critical-data-locally"></a>重要なデータのローカルでの保存

アプリが終了される前にデータを保存しておかないと、データが失われ、否定的なユーザー エクスペリエンスにつながる場合は、**ExtendedExecutionSession** を作成するときに **ExtendedExecutionReason.SavingData** を指定して、ユーザー データを保存します。

データのアップロードまたはダウンロードのために、このようなセッションを使用して、アプリの実行時間を延長しないでください。 データのアップロードが必要な場合は、[バックグラウンド転送](https://msdn.microsoft.com/en-us/windows/uwp/networking/background-transfers)を要求するか、**MaintenanceTrigger** を登録して、AC 電源を利用できるときに、転送を処理してください。 **ExtendedExecutionReason.SavingData** 延長セッションを要求できるのは、アプリがフォアグラウンドで **Running**状態であるか、バックグラウンドで**Suspending** 状態である場合です。

**Suspending** 状態は、アプリのライフサイクル中で、アプリが終了する前にアプリが作業を実行できる最後のチャンスです。 アプリが **Suspending** 状態のときに **ExtendedExecutionReason.SavingData** 延長実行セッションを要求すると、注意が必要な問題が発生する可能性があります。 **Suspending** 状態のときに延長実行セッションが要求され、ユーザーがアプリの再起動を要求した場合、起動に時間がかかるように感じられる可能性があります。 これは、延長実行セッションの時間が経過しないと、アプリの以前のインスタンスを終了して、アプリの新しいインスタンスを起動することができないためです。 ユーザー状態が失われることを確実に防ぐため、起動にかかる時間が犠牲になります。

## <a name="request-disposal-and-revocation"></a>要求、破棄、および失効

延長実行セッションには、要求、破棄、および失効の 3 つの基本的な操作があります。  次のコード スニペットは、要求を行う例を示しています。

### <a name="request"></a>要求

```csharp
var newSession = new ExtendedExecutionSession();
newSession.Reason = ExtendedExecutionReason.Unspecified;
newSession.Description = "Raising periodic toasts";
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

**RequestExtensionAsync** を呼び出すと、ユーザーがアプリのバックグラウンド アクティビティを承認しているかどうかと、バックグラウンドで実行できるだけのリソースがシステムにあるかどうかについて、オペレーティング システムが確認されます。

あらかじめ [BackgroundExecutionManager](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) をチェックして、アプリがバックグラウンドで実行できるかどうかを示すユーザー設定である [BackgroundAccessStatus](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.backgroundaccessstatus.aspx?f=255&MSPPError=-2147217396) の状態を特定することもできます。 これらのユーザー設定について詳しくは、「[Background Activity and Energy Awareness (バックグラウンド アクティビティと省電力対策)](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#XWK8mEgWD7JHvC10.97)」をご覧ください。

**ExtendedExecutionReason** は、アプリがバックグラウンドで実行する操作を示します。 **Description** の文字列は、アプリがその操作を実行しなければならない理由を説明する、人間が読める文字列です。 ユーザーまたはシステムによって、アプリをこれ以上バックグラウンドで実行できないと判断された場合に、延長実行セッションが適切に停止されるように、**Revoked** イベント ハンドラーを指定する必要があります。

### <a name="revoked"></a>失効

アプリにアクティブな延長実行セッションがあり、システムがバックグラウンド アクティビティを停止する必要がある場合、セッションは失効されます。 最初に **Revoked** イベント ハンドラーが発生しないと、延長実行セッションが途中で終了されることはありません。

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

以下に、延長実行セッション中に複数のタスクを管理するコード例を示します。

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

    public static async Task<ExtendedExecutionResult> RequestSessionAsync(ExtendedExecutionReason reason, TypedEventHandler<object, ExtendedExecutionRevokedEventArgs> revoked)
    {
        // The previous Extended Execution must be closed before a new one can be requested.       
        ClearSession();

        var newSession = new ExtendedExecutionSession();
        newSession.Reason = ExtendedExecutionReason.Unspecified;
        newSession.Description = "Running multiple tasks";
        newSession.Revoked += SessionRevoked;

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
        else if (taskCount == 0 && session != null)
        {
            ClearSession();
        }
    }

    private static void SessionRevoked(object sender, ExtendedExecutionRevokedEventArgs args)
    {
        if (session != null)
        {
            session.Dispose();
            session = null;
        }
    }
}
```
[コード サンプルを見る](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/ExtendedExecution/cs/Scenario4_MultipleTasks.xaml.cs)

## <a name="ensure-that-your-app-uses-resources-well"></a>アプリがリソースを適切に使用するための処理

アプリがバックグラウンドに移行した後も、実行を継続できるためには、アプリのメモリや電力使用を調整することが重要です。 [メモリ管理 API](https://msdn.microsoft.com/en-us/library/windows/apps/windows.system.memorymanager.aspx) を使用して、アプリが使用しているメモリ量を確認します。 アプリが使用するメモリ量が多くなるほど、別のアプリがフォアグラウンドのときに、アプリの実行を OS が維持することは難しくなります。 アプリが実行できるすべてのバックグラウンド アクティビティについて、最終的に管理できるのはユーザーです。また、ユーザーは、アプリがどの程度バッテリー消費に影響しているかを確認できます。

[BackgroundExecutionManager.RequestAccessAsync](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.backgroundexecutionmanager.aspx) を使用して、アプリのバックグラウンド アクティビティを制限するようにユーザーが設定しているかどうかを確認します。 バッテリー使用量を注意し、ユーザーが望む操作を完了するために必要な場合にのみ、バックグラウンドで実行するようにしてください。

## <a name="see-also"></a>関連項目

[延長実行のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ExtendedExecution)  
[アプリケーションのライフサイクル](https://msdn.microsoft.com/en-us/windows/uwp/launch-resume/app-lifecycle)  
[バック グラウンド メモリの管理](https://msdn.microsoft.com/en-us/windows/uwp/launch-resume/reduce-memory-usage)  
[バックグラウンド転送](https://msdn.microsoft.com/en-us/windows/uwp/networking/background-transfers)  [Battery Awareness and Background Activity (バッテリー対策とバックグラウンド アクティビティ)](https://blogs.windows.com/buildingapps/2016/08/01/battery-awareness-and-background-activity/#I2bkQ6861TRpbRjr.97)  
[MemoryManager クラス](https://msdn.microsoft.com/en-us/library/windows/apps/windows.system.memorymanager.aspx)  
[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/en-us/windows/uwp/audio-video-camera/background-audio)  



<!--HONumber=Dec16_HO3-->


