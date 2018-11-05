---
author: msatranjr
ms.assetid: 26834A51-512B-485B-84C8-ABF713787588
title: NFC スマート カード アプリの作成
description: Windows Phone 8.1 では、SIM ベースのセキュア エレメントを使用する NFC カード エミュレーション アプリがサポートされていましたが、このモデルでは、安全な支払いアプリと移動体通信事業者 (MNO) 様との密接な連携が必要でした。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bf8d5f1587cc27082944cf0fc63edc274cb2bc7d
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6028761"
---
# <a name="create-an-nfc-smart-card-app"></a>NFC スマート カード アプリの作成


**重要な**このトピックでは windows 10 Mobile にのみ適用されます。

Windows Phone 8.1 では、SIM ベースのセキュア エレメントを使用する NFC カード エミュレーション アプリがサポートされていましたが、このモデルでは、安全な支払いアプリと移動体通信事業者 (MNO) 様との密接な連携が必要でした。 このことにより、MNO 様と連携していないために、他の事業者様や開発者様によるさまざまな支払いソリューションの可能性が制限されていました。 Windows 10 Mobile では、ホスト カード エミュレーション (HCE) と呼ばれる新しいカード エミュレーション テクノロジを導入しましたがあります。 HCE テクノロジを使用すると、アプリが NFC カード リーダーと直接通信することができます。 このトピックでは、windows 10 Mobile のデバイスでのホスト カード エミュレーション (HCE) のしくみし、ユーザーがアクセスできるように、サービスを通じて、物理的なカードではなく自分の電話を MNO と連携せず、HCE アプリを開発する方法を示しています。

## <a name="what-you-need-to-develop-an-hce-app"></a>HCE アプリの開発に必要な要素


Windows 10 mobile では、HCE ベースのカード エミュレーション アプリを開発するには、開発環境のセットアップを取得する必要があります。 Windows 開発者ツールと、windows 10 Mobile エミュレーター NFC エミュレーションがサポートが含まれている Microsoft Visual Studio2015 をインストールすることによって設定を取得することができます。 セットアップの詳細については、「[準備](https://msdn.microsoft.com/library/windows/apps/Dn726766)」を参照してください。

必要に応じて、windows 10 Mobile エミュレーターではなく実際の windows 10 Mobile デバイスを使用してテストする場合は、次の項目も必要があります。

-   NFC HCE がサポートを持つ windows 10 Mobile デバイス。 現時点で、NFC HCE アプリをサポートするハードウェアは Lumia 730、830、640、640 XL に搭載されています。
-   プロトコルとして ISO/IEC 14443-4 および ISO/IEC 7816-4 をサポートするリーダー端末。

Windows 10 Mobile では、次の機能を提供する HCE サービスを実装します。

-   エミュレートするカード用のアプレット識別子 (AID) をアプリで登録できる。
-   外部リーダー カードの選択とユーザー設定に基づいて、アプリケーション プロトコル データ ユニット (APDU) のコマンドと応答のペアをいずれかの登録済みアプリにルーティングし、競合を解決する。
-   ユーザー操作の結果としてイベントとアプリへの通知を処理する。

Windows 10 には、ISO-DEP に基づくスマート カードのエミュレーションがサポートしています (ISO-IEC 14443-4) で定義されている ISO-IEC 7816-4 仕様の Apdu を使用した通信とします。 Windows 10 では、HCE アプリ用 ISO/IEC 14443-4 Type A テクノロジをサポートします。 Type B、Type F、非 ISO-DEP (MIFARE など) のテクノロジは、既定では SIM にルーティングされます。

カード エミュレーション機能では、windows 10 Mobile デバイスのみが有効になります。 SIM ベースおよび HCE ベースのカード エミュレーションは、他のバージョンの windows 10 では使用できません。

HCE および SIM ベースのカード エミュレーションのサポートのアーキテクチャを、次の図に示します。

![HCE および SIM カード エミュレーションのアーキテクチャ](./images/nfc-architecture.png)

## <a name="app-selection-and-aid-routing"></a>アプリの選択と AID ルーティング

HCE アプリを開発するには、windows 10 Mobile デバイス Aid ルーティングされるしくみ、特定のアプリをユーザーが複数のさまざまな HCE アプリをインストールできるためを理解する必要があります。 各アプリは、HCE ベースおよび SIM ベースのカードを複数登録できます。 SIM ベースである従来の Windows Phone 8.1 アプリは引き続き、ユーザーが NFC 設定メニューで、既定の支払い用カードとして「SIM カード」オプションを選んだ場合に限り、windows 10 Mobile で動作します。 これは、初めてデバイスに電源を入れると既定で設定される構成です。

ユーザーが、windows 10 Mobile デバイスを端末にタップと、データは自動的にデバイスにインストールされている適切なアプリにルーティングします。 このルーティングは、5 ～ 16 バイトの識別子であるアプレット ID (AID) に基づいています。 タップが発生すると、外部端末は SELECT コマンドの APDU を送出し、後続のすべての APDU コマンドのルーティング先とする AID を指定します。 後続の SELECT コマンドでは、ルーティング先を再度変更できます。 アプリとユーザー設定によって登録されている AID に基づいて、APDU トラフィックが特定のアプリにルーティングされます。ルーティング先のアプリは、応答の APDU を送信します。 端末側では同じタップで異なる複数のアプリとの通信を必要としている場合もあるので注意してください。 このため、別のアプリのバックグラウンド タスクが APDU に応答する余地ができるように、アプリのバックグラウンド タスクは、非アクティブ化されたらできる限り早く終了する必要があります。 バックグラウンド タスクについては、後で説明します。

HCE アプリは、AID の APDU を受信できるように、対応が可能な特定の AID に自身を登録する必要があります。 アプリは、AID グループを使用して AID を宣言します。 AID グループは、概念的には個々の物理カードに相当します。 たとえば、2 枚のカードの AID が同じであっても、1 枚目のクレジット カードは 1 つ目の AID グループ、別の銀行から発行された 2 枚目のクレジット カードは 2 つ目の AID グループで登録されます。

## <a name="conflict-resolution-for-payment-aid-groups"></a>支払い AID グループの競合の解決

アプリで物理カード (AID グループ) を登録する際には、AID グループのカテゴリを "Payment" または "Other" として宣言します。 同時に複数の支払い AID グループが登録されることはあり得ますが、"タップして支払い" 用に同時に有効にできる支払い AID グループは、ユーザーによって選択された 1 つのグループのみです。 これは、デバイスを端末にタップしたときに意図しないカードで支払われることのないよう、単一の支払い用カード、クレジット カード、またはデビット カードをユーザーが自分の意志で選択できるようにするためです。

ただし、"Other" として登録されている複数の AID グループは、ユーザー操作なしに同時に有効にすることができます。 これは、他の種類のカード (ロイヤルティ、クーポン、交通機関用など) については、電話をタップするだけで特に操作やユーザー入力を必要とせず役割が果たされるようにするためです。

"Payment" として登録された AID グループはすべて、NFC 設定ページのカード一覧に表示されます。この一覧で、ユーザーは既定の支払い用カードを選択できます。 既定の支払い用カードが選択されると、この支払い AID グループを登録したアプリが既定の支払いアプリになります。 既定の支払いアプリは、登録されている任意の AID グループをユーザー操作なしで有効または無効に切り替えることができます。 ユーザーが既定の支払いアプリを確認するメッセージで確認を拒否した場合は、現在の既定の支払いアプリ (ある場合) が引き続き既定として使用されます。 次のスクリーン ショットは、NFC 設定ページを示しています。

![NFC 設定ページのスクリーン ショット](./images/nfc-settings.png)

上のスクリーンショットで説明すると、ユーザーが既定の支払い用カードを変更して、"HCE Application 1" によって登録されていない別のカードに切り替えた場合、システムはユーザーによる同意を求めて確認プロンプトを表示します。 ユーザーが既定の支払い用カードを変更して、"HCE Application 1" によって登録されている別のカードに切り替えた場合、"HCE Application 1" は既に既定の支払いアプリであるため、システムはユーザーに対する確認プロンプトを表示しません。

## <a name="conflict-resolution-for-non-payment-aid-groups"></a>支払い以外の AID グループの競合の解決

支払い用以外として "Other" というカテゴリに設定されているカードは、NFC 設定ページには表示されません。

アプリでは、支払い AID グループと同じ方法で、支払い用以外の AID グループを作成、登録、有効化することができます。 主な違いは、支払い用以外の AID グループについてはエミュレーション カテゴリを "Payment" ではなく "Other" に設定する点です。 AID グループをシステムに登録した後は、AID グループが NFC トラフィックを受信できるようにする必要があります。 支払い用以外の AID グループについてトラフィックの受信を有効化する場合、別のアプリによって既にシステムに登録されている AID との競合がない限り、ユーザーに対する確認プロンプトは表示されません。 競合が存在すると、新しく登録された AID グループの有効化をユーザーが選択した場合に、どのカードと関連するアプリが無効になるかを示す情報と共にユーザーへの確認メッセージが表示されます。

**SIM ベースの NFC アプリケーションとの共存**

Windows 10 Mobile では、システムは、コント ローラー レイヤーでルーティングの決定に使用される NFC コント ローラー ルーティング テーブルを設定します。 このテーブルには、ルーティング情報として次のアイテムが含まれています。

-   個別の AID ルート。
-   プロトコルに基づくルート (ISO DEP)。
-   テクノロジに基づくルーティング (NFC-A/B/F)。

外部リーダーにより "SELECT AID" コマンドが送信されると、NFC コントローラーはまずルーティング テーブルに一致する AID ルートがないか確認します。 一致がない場合、ISO-DEP (14443-4-A) トラフィックに対する既定のルートとしては、プロトコル ベースのルートが使用されます。 その他、非 ISO-DEP のトラフィックについては、テクノロジ ベースのルーティングが使用されます。

Windows 10 Mobile では、引き続きレガシ Windows Phone 8.1 SIM ベース アプリは登録しないで、Aid システムを使用する NFC 設定ページのメニュー オプション「SIM カード」を提供します。 ユーザーが既定の支払い用カードとして "SIM カード" を選択すると、ISO-DEP ルートが UICC に設定されます (ドロップダウン メニュー内の他の選択肢ではすべて、ISO-DEP ルート先はホスト)。

SE 対応の SIM カード、最初に windows 10 Mobile のデバイスが起動したときのデバイスの「SIM カード」に、ISO-DEP ルートが設定されます。 ユーザーが HCE 対応のアプリをインストールし、そのアプリでなんらかの HCE AID グループ登録が有効になった場合は、ISO-DEP ルート先がホストになります。 新しい SIM ベースのアプリケーションでは、特定の AID ルートがコントローラーのルーティング テーブルに設定されるように、AID を SIM に登録する必要があります。

## <a name="creating-an-hce-based-app"></a>HCE ベース アプリの作成

HCE アプリには、2 つの部分があります。

-   メインのフォアグラウンド アプリ (ユーザー操作用)。
-   指定された AID について APDU を処理するためにシステムによってトリガーされるバックグラウンド タスク。

NFC タップへの応答としてバックグラウンド タスクを読み込む際にはきわめて高いパフォーマンスが求められるため、バックグラウンド タスク全体 (必要な依存関係、参照、ライブラリなどをすべて含めて) を C# やマネージ コードではなく、C++/CX のネイティブ コードで実装することをお勧めします。 C# およびマネージ コードは、通常はパフォーマンスに優れていますが、.NET CLR の読み込みなどによるオーバーヘッドが発生します。C++/CX では、これを回避することができます。
## <a name="create-and-register-your-background-task"></a>バックグラウンド タスクの作成と登録

システムによってルーティングされた APDU を処理し、これに応答するために、バックグラウンド タスクを HCE アプリに作成する必要があります。 アプリが初めて起動される際には、次のコードに示すように [**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/BR224803) インターフェイスを実装する HCE バックグラウンド タスクがフォアグラウンドによって登録されます。

```csharp
var taskBuilder = new BackgroundTaskBuilder();
taskBuilder.Name = bgTaskName;
taskBuilder.TaskEntryPoint = taskEntryPoint;
taskBuilder.SetTrigger(new SmartCardTrigger(SmartCardTriggerType.EmulatorHostApplicationActivated));
bgTask = taskBuilder.Register();
```

タスクのトリガーが [**SmartCardTriggerType**](https://msdn.microsoft.com/library/windows/apps/Dn608017). **EmulatorHostApplicationActivated** に設定されていることに注意してください。 これは、OS で受信した SELECT AID コマンドの APDU がアプリに解決されるたびに、バックグラウンド タスクが起動されることを意味します。

## <a name="receive-and-respond-to-apdus"></a>APDU の受信と応答

アプリをターゲットとする APDU があると、システムは、このアプリのバックグラウンド タスクを起動します。 バックグラウンド タスクは、[**SmartCardEmulatorApduReceivedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Dn894640) オブジェクトの [**CommandApdu**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardemulatorapdureceivedeventargs.commandapdu.aspx) プロパティを通じて渡された APDU を受信し、同じオブジェクトの [**TryRespondAsync**](https://msdn.microsoft.com/library/windows/apps/mt634299.aspx) メソッドを使用して APDU に応答します。 パフォーマンスを考慮して、バックグラウンド タスクは軽量な操作に留めるよう検討してください。 たとえば、すべての処理が完了したら、直ちに APDU に応答し、バックグラウンド タスクを終了してください。 NFC トランザクションの性質から、ユーザーがリーダーに対してデバイスをかざす時間はきわめて短時間に限られています。 バックグラウンド タスクは、接続が無効になるまで継続的にリーダーからトラフィックを受信し、接続が無効になると [**SmartCardEmulatorConnectionDeactivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Dn894644) オブジェクトを受信します。 接続は、[**SmartCardEmulatorConnectionDeactivatedEventArgs.Reason**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardemulatorconnectiondeactivatedeventargs.reason) プロパティで示されるように次の理由で無効になります。

-   **ConnectionLost** 値で接続が無効になった場合は、ユーザーがリーダーからデバイスを離したことを意味します。 アプリでユーザーが端末にタップする時間を長くする必要がある場合は、フィードバックと共にプロンプトを表示することを検討してください。 ユーザーが再度タップしたときに、直前のバックグラウンド タスクが終了するまで待機したために遅延が生じることのないよう、バックグラウンド タスクは (保留を終了することで) 直ちに終了する必要があります。
-   **ConnectionRedirected** で接続が無効になった場合は、端末によって新しい SELECT AID コマンドの APDU が送信され、別の AID に転送されたことを意味します。 この場合、別のバックグラウンド タスクが実行できるように、アプリは直ちに (保留を終了することで) バックグラウンド タスクを終了する必要があります。

バックグラウンド タスクは、[**IBackgroundTaskInstance インターフェイス**](https://msdn.microsoft.com/library/windows/apps/BR224797)の [**Canceled イベント**](https://msdn.microsoft.com/library/windows/apps/BR224798)にも登録し、同様に (保留を終了することで) バックグラウンド タスクを直ちに終了する必要があります。このイベントは、バックグラウンド タスクの終了時にシステムによって発生するためです。 次のコードでは、HCE アプリのバックグラウンド タスクのデモを示しています。

```csharp
void BgTask::Run(
    IBackgroundTaskInstance^ taskInstance)
{
    m_triggerDetails = static_cast<SmartCardTriggerDetails^>(taskInstance->TriggerDetails);
    if (m_triggerDetails == nullptr)
    {
        // May be not a smart card event that triggered us
        return;
    }

    m_emulator = m_triggerDetails->Emulator;
    m_taskInstance = taskInstance;

    switch (m_triggerDetails->TriggerType)
    {
    case SmartCardTriggerType::EmulatorHostApplicationActivated:
        HandleHceActivation();
        break;

    case SmartCardTriggerType::EmulatorAppletIdGroupRegistrationChanged:
        HandleRegistrationChange();
        break;

    default:
        break;
    }
}

void BgTask::HandleHceActivation()
{
 try
 {
        auto lock = m_srwLock.LockShared();
        // Take a deferral to keep this background task alive even after this "Run" method returns
        // You must complete this deferal immediately after you have done processing the current transaction
        m_deferral = m_taskInstance->GetDeferral();

        DebugLog(L"*** HCE Activation Background Task Started ***");

        // Set up a handler for if the background task is cancelled, we must immediately complete our deferral
        m_taskInstance->Canceled += ref new Windows::ApplicationModel::Background::BackgroundTaskCanceledEventHandler(
            [this](
            IBackgroundTaskInstance^ sender,
            BackgroundTaskCancellationReason reason)
        {
            DebugLog(L"Cancelled");
            DebugLog(reason.ToString()->Data());
            EndTask();
        });

        if (Windows::Phone::System::SystemProtection::ScreenLocked)
        {
            auto denyIfLocked = Windows::Storage::ApplicationData::Current->RoamingSettings->Values->Lookup("DenyIfPhoneLocked");
            if (denyIfLocked != nullptr && (bool)denyIfLocked == true)
            {
                // The phone is locked, and our current user setting is to deny transactions while locked so let the user know
                // Denied
                DoLaunch(Denied, L"Phone was locked at the time of tap");

                // We still need to respond to APDUs in a timely manner, even though we will just return failure
                m_fDenyTransactions = true;
            }
        }
        else
        {
            m_fDenyTransactions = false;
        }

        m_emulator->ApduReceived += ref new TypedEventHandler<SmartCardEmulator^, SmartCardEmulatorApduReceivedEventArgs^>(
            this, &BgTask::ApduReceived);

        m_emulator->ConnectionDeactivated += ref new TypedEventHandler<SmartCardEmulator^, SmartCardEmulatorConnectionDeactivatedEventArgs^>(
                [this](
                SmartCardEmulator^ emulator,
                SmartCardEmulatorConnectionDeactivatedEventArgs^ eventArgs)
            {
                DebugLog(L"Connection deactivated");
                EndTask();
            });

  m_emulator->Start();
        DebugLog(L"Emulator started");
 }
 catch (Exception^ e)
 {
        DebugLog(("Exception in Run: " + e->ToString())->Data());
        EndTask();
 }
}
```
## <a name="create-and-register-aid-groups"></a>AID グループの作成と登録

カードのプロビジョニング時にアプリケーションを初めて起動すると、AID グループが作成され、システムに登録されます。 システムは、外部リーダーが対話する必要のあるアプリを判断し、登録されている AID とユーザー設定に基づいて APDU をルーティングします。

ほとんどの支払い用カードは、追加の支払い用ネットワーク カード固有の AID と共に同じ AID (PPSE AID) に登録されます。 各 AID グループはカードを表し、ユーザーがそのカードを有効にすると、グループ内のすべての AID が有効になります。 同様に、ユーザーがカードを無効にすると、そのグループ内のすべての AID が無効になります。

AID グループを登録するには、[**SmartCardAppletIdGroup**](https://msdn.microsoft.com/library/windows/apps/Dn910955) オブジェクトを作成し、HCE ベースの支払い用カードであることが反映されるようにプロパティを設定する必要があります。 表示名は、NFC 設定メニューにもユーザー プロンプトにも使用されるため、ユーザーにわかりやすい名前にする必要があります。 HCE 支払い用カードの場合、[**SmartCardEmulationCategory**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationcategory.aspx) プロパティは **Payment** に、[**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationtype) プロパティは **Host** に設定する必要があります。

```csharp
public static byte[] AID_PPSE =
        {
            // File name "2PAY.SYS.DDF01" (14 bytes)
            (byte)'2', (byte)'P', (byte)'A', (byte)'Y',
            (byte)'.', (byte)'S', (byte)'Y', (byte)'S',
            (byte)'.', (byte)'D', (byte)'D', (byte)'F', (byte)'0', (byte)'1'
        };

var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_PPSE.AsBuffer()},
                                SmartCardEmulationCategory.Payment,
                                SmartCardEmulationType.Host);
```

支払い用以外の HCE カードの場合、[**SmartCardEmulationCategory**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationcategory.aspx) プロパティは **Other** に、[**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationtype) プロパティは **Host** に設定する必要があります。

```csharp
public static byte[] AID_OTHER =
        {
            (byte)'1', (byte)'2', (byte)'3', (byte)'4',
            (byte)'5', (byte)'6', (byte)'7', (byte)'8',
            (byte)'O', (byte)'T', (byte)'H', (byte)'E', (byte)'R'
        };

var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_OTHER.AsBuffer()},
                                SmartCardEmulationCategory.Other,
                                SmartCardEmulationType.Host);
```

各 AID グループには、最大 9 個の AID (それぞれの長さは 5 ～ 16 バイト) を含めることができます。

AID グループをシステムに登録するには、[**RegisterAppletIdGroupAsync**](https://msdn.microsoft.com/library/windows/apps/Dn894656) メソッドを使用します。このメソッドからは [**SmartCardAppletIdGroupRegistration**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) オブジェクトが返されます。 既定では、登録オブジェクトの [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) プロパティは **Disabled** に設定されます。 つまり、AID がシステムに登録されていても、この時点では有効になっておらず、トラフィックを受信しません。

```csharp
reg = await SmartCardEmulator.RegisterAppletIdGroupAsync(appletIdGroup);
```

登録済みのカード (AID グループ) は、次に示されているように [**SmartCardAppletIdGroupRegistration**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) クラスの [**RequestActivationPolicyChangeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) メソッドを使用して有効にすることができます。 システムで一度に有効にできる支払い用カードは 1 枚だけであるため、支払い AID グループの [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) を **Enabled** に設定することは、既定の支払い用カードを設定することと同じ意味になります。 既定の支払い用カードが既に選択されているかどうかに関係なく、このカードを既定の支払い用カードとして設定するかどうかをユーザーに確認するメッセージが表示されます。 アプリが既に既定の支払いアプリケーションであり、単に AID グループ間で変更する場合、この記述は該当しません。 アプリごとに最大で 10 の AID グループを登録することができます。

```csharp
reg.RequestActivationPolicyChangeAsync(AppletIdGroupActivationPolicy.Enabled);
```

[**GetAppletIdGroupRegistrationsAsync**](https://msdn.microsoft.com/library/windows/apps/Dn894654) メソッドを使用すると、OS に対してアプリの登録済み AID グループを照会し、アクティブ化ポリシーを確認できます。

支払い用カードのアクティブ化ポリシーを **Disabled** から **Enabled** に変更する場合にユーザーに確認が求められるのは、アプリがまだ既定の支払いアプリになっていない場合のみです。 支払い用以外のカードのアクティブ化ポリシーを **Disabled** から **Enabled** に変更する場合にユーザーに確認が求められるのは、AID の競合が存在する場合のみです。

```csharp
var registrations = await SmartCardEmulator.GetAppletIdGroupRegistrationsAsync();
    foreach (var registration in registrations)
    {
registration.RequestActivationPolicyChangeAsync (AppletIdGroupActivationPolicy.Enabled);
    }
```

**アクティブ化ポリシー変更時のイベント通知**

バックグラウンド タスクでは、アプリの外でいずれかの AID グループ登録のアクティブ化ポリシーが変更された場合に備えてイベントを受信できるように登録できます。 たとえばユーザーは、NFC 設定メニューで既定の支払いアプリを元のカードから、別のアプリでホストされている別のカードに変更することができます。 ライブ タイルの更新など、内部セットアップ用にこの変更をアプリで認識する必要がある場合は、この変更のイベント通知を受信し、その通知に応じてアプリ内で対処することができます。

```csharp
var taskBuilder = new BackgroundTaskBuilder();
taskBuilder.Name = bgTaskName;
taskBuilder.TaskEntryPoint = taskEntryPoint;
taskBuilder.SetTrigger(new SmartCardTrigger(SmartCardTriggerType.EmulatorAppletIdGroupRegistrationChanged));
bgTask = taskBuilder.Register();
```

## <a name="foreground-override-behavior"></a>フォアグラウンドのオーバーライド動作

アプリがフォアグラウンドになっている間は、ユーザーに確認することなく AID グループ登録の [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) を **ForegroundOverride** に変更することができます。 アプリがフォアグラウンドになっている間にユーザーがデバイスで端末をタップすると、ユーザーがいずれの支払い用カードも既定の支払い用カードとして選択していなくても、トラフィックはアプリにルーティングされます。 カードのアクティブ化ポリシーを **ForegroundOverride** に変更した場合、この変更はアプリがフォアグラウンドから移行するまでの一時的なものであり、ユーザーによって設定された現在の既定支払い用カードは変更されません。 支払い用カードまたは支払い用以外のカードの **ActivationPolicy** は、フォアグラウンド アプリから次のように変更できます。 [**RequestActivationPolicyChangeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) メソッドを呼び出すことができるのはフォアグラウンド アプリからのみであり、バックグラウンド タスクから呼び出すことはできない点に注意してください。

```csharp
reg.RequestActivationPolicyChangeAsync(AppletIdGroupActivationPolicy.ForegroundOverride);
```

また、長さ 0 の単一 AID から成る AID グループを登録することもできます。その場合は、SELECT AID コマンドの受信前に送信されたコマンドの APDU もすべて含めて、AID に関係なくすべての APDU がルーティングされます。 ただし、このような AID グループは **ForegroundOverride** にしか設定できず、常に有効にしておくことはできないため、機能するのはアプリがフォアグラウンドになっている間のみです。 また、すべてのトラフィックを HCE バックグラウンド タスクまたは SIM カードにルーティングするために、このメカニズムは [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/Dn894639) 列挙の値が **Host** の場合と **UICC** の場合の両方に使用できます。

```csharp
public static byte[] AID_Foreground =
        {};

var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_Foreground.AsBuffer()},
                                SmartCardEmulationCategory.Other,
                                SmartCardEmulationType.Host);
reg = await SmartCardEmulator.RegisterAppletIdGroupAsync(appletIdGroup);
reg.RequestActivationPolicyChangeAsync(AppletIdGroupActivationPolicy.ForegroundOverride);
```

## <a name="check-for-nfc-and-hce-support"></a>NFC および HCE サポートの確認

アプリでは、デバイスに NFC ハードウェアがあるかどうか、カード エミュレーション機能がサポートされているかどうか、これらの機能をユーザーに提供する前にホスト カード エミュレーションがサポートされるかどうかを確認する必要があります。

NFC スマート カード エミュレーション機能は、windows 10 Mobile では、windows 10 の他のバージョンでスマート カード エミュレーター Api を使用しようとするためにのみ有効には、エラーが発生します。 次のコード スニペットでは、スマート カード API のサポートを確認することができます。

```csharp
Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.SmartCards.SmartCardEmulator");
```

さらに、[**SmartCardEmulator.GetDefaultAsync**](https://msdn.microsoft.com/library/windows/apps/Dn608008) メソッドから null が返されるかどうかを確認することによって、なんらかの形でカード エミュレーションが可能な NFC ハードウェアがデバイスに存在するかどうかを確認することもできます。 null が返される場合、そのデバイスでは NFC カード エミュレーションがサポートされません。

```csharp
var smartcardemulator = await SmartCardEmulator.GetDefaultAsync();<
```

HCE ベースおよび AID ベースの UICC ルーティングは、Lumia 730、830、640、640 XL など最近発売されたデバイスでのみサポートされます。 Windows 10 Mobile を実行している新しい NFC 対応デバイスとした後、HCE をサポートする必要があります。 アプリでは、次のようにして HCE サポートを確認できます。

```csharp
Smartcardemulator.IsHostCardEmulationSupported();
```

## <a name="lock-screen-and-screen-off-behavior"></a>ロック画面と画面オフの動作

Windows 10 Mobile には、デバイス レベルでのカード エミュレーション設定は、携帯電話会社またはデバイスの製造元によって設定できますがあります。 既定では、"タップして支払い" のトグルがオフになっており "デバイス レベルでの有効化ポリシー" が "常時" に設定されています (通信事業者または OEM パートナーによってこれらの値が上書きされていない場合)。

アプリケーションでは、デバイス レベルで [**EnablementPolicy**](https://msdn.microsoft.com/library/windows/apps/Dn608006) の値を照会し、それぞれの状態で望ましいアプリの動作に基づいて、各ケースに対処することができます。

```csharp
SmartCardEmulator emulator = await SmartCardEmulator.GetDefaultAsync();

switch (emulator.EnablementPolicy)
{
case Never:
// you can take the user to the NFC settings to turn "tap and pay" on
await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-nfctransactions:"));
break;

 case Always:
return "Card emulation always on";

 case ScreenOn:
 return "Card emulation on only when screen is on";

 case ScreenUnlocked:
 return "Card emulation on only when screen unlocked";
}
```

電話がロックされている場合または画面がオフの場合、あるいはその両方に該当する場合も、アプリのバックグラウンド タスクが起動されます (そのアプリに解決される AID が外部リーダーによって選択された場合のみ)。 リーダーからのコマンドにはバックグラウンドで応答できますが、ユーザーによる操作が必要である場合や、ユーザーにメッセージを表示する必要がある場合は、いくつかの引数を指定してフォアグラウンド アプリを起動することができます。 バックグラウンド タスクでは、次の動作でフォアグラウンド アプリを起動できます。

-   デバイスのロック画面下で起動 (ユーザーがフォアグラウンド アプリを目にするのはデバイスのロックを解除した後)
-   デバイスのロック画面上で起動 (ユーザーがアプリを終了した後も、デバイスはロックされた状態)

```csharp
        if (Windows::Phone::System::SystemProtection::ScreenLocked)
        {
            // Launch above the lock with some arguments
            var result = await eventDetails.TryLaunchSelfAsync("app-specific arguments", SmartCardLaunchBehavior.AboveLock);
        }
```

## <a name="aid-registration-and-other-updates-for-sim-based-apps"></a>SIM ベース アプリに関する AID 登録およびその他の更新

セキュア エレメントとして SIM を使用するカード エミュレーション アプリは Windows サービスに登録して、SIM でサポートされている AID を宣言できます。 この登録は、HCE ベースのアプリ登録とよく似ています。 唯一の違いは [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/Dn894639) です。SIM ベースのアプリの場合は、これを Uicc に設定する必要があります。 支払い用カードを登録した結果、カードの表示名が NFC 設定メニューに表示されます。

```csharp
var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_PPSE.AsBuffer()},
                                SmartCardEmulationCategory.Payment,
                                SmartCardEmulationType.Uicc);
```

* * 重要な * *新しい windows 10 Mobile SMS を使用できる証明書利用者従来の Windows Phone 8.1 アプリを更新する必要がありますが、Windows Phone 8.1 のレガシ バイナリ SMS インターセプト サポートは廃止され、windows 10 Mobile では新しい広範な SMS サポートに置き換えられますApi です。
