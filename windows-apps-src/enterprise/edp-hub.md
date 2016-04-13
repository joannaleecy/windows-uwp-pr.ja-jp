---
Description: 'ここでは、エンタープライズ データ保護 (EDP) とファイル、バッファー、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係について、開発者向けに詳しく説明します。'
MS-HAID: 'dev\_enterprise.edp\_hub'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 'エンタープライズ データ保護 (EDP)'
---

# エンタープライズ データ保護 (EDP)

__注__ Windows 10 バージョン 1511 (ビルド 10586) またはそれ以前のバージョンでは、エンタープライズ データ保護 (EDP) ポリシーを適用できません。

ここでは、エンタープライズ データ保護 (EDP) とファイル、バッファー、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係について、開発者向けに詳しく説明します。

エンド ユーザーと管理者の観点から見た EDP について詳しくは、「[エンタープライズ データ保護 (EDP) の概要](https://technet.microsoft.com/library/dn985838(v=vs.85).aspx)」をご覧ください。

## EDP とは

EDP は、デスクトップ、ノート PC、タブレット、電話に搭載された、モバイル デバイス管理 (MDM) 用の機能のセットです。 EDP を使用すると、企業では、自社が管理するデバイス上で、データ (企業のファイルやデータ BLOB) がどのように扱われるかをより細かく制御できるようになります。

-   エンタープライズ データは暗号化でタグ付けされます。 これを "エンタープライズ保護データ"、または略して "保護データ" と呼びます。
-   管理側のエンタープライズにより、EDP を通じて明示的に許可されたアプリだけが、エンタープライズ保護データ (たとえばファイル内のデータ) にアクセスできます。
-   また、EDP ポリシーを通じて明示的に許可されたアプリだけが、エンタープライズ仮想プライベート ネットワーク (VPN) にアクセスできます。
-   アプリの制限ポリシーにより、許可されたアプリでのデータの扱い方が決まります。
-   ポリシー ベースの制限は、Windows クリップボードや共有コントラクトを通じて交換されるエンタープライズ コンテンツにも適用されます。
-   管理側のエンタープライズでは、必要に応じて、保護されたコンテンツへのデバイスのアクセスを取り消すことができます。この場合、個人用データには影響を与えずに、デバイスからエンタープライズ データがワイプされます。
-   保護データをダウンロードするアプリをチャネル アプリといいます。 たとえば、メール アプリやファイル同期アプリがあります。

EDP は、[暗号化ファイル システム (EFS)](http://technet.microsoft.com/library/cc700811.aspx) と [Windows 選択的ワイプ](https://technet.microsoft.com/library/dn486874.aspx)を拡張して、セキュリティと柔軟性に関するより多くのオプションを提供します。 新しい EDP API では、エンタープライズ コンテンツへのアクセスの保護と取り消しを行うアプリの作成、保護されたファイル プロパティの操作、暗号化されたデータへの未加工の形式でのアクセスを行うことができます。 ファイルとフォルダーを保護する新しい API に加えて、バッファーとストリームを保護するための API も導入されています。 さらに、データ保護ポリシーを適用する必要のあるエンタープライズの識別と指定をアプリで行えるようにする API のセットも追加されています。

アプリの制限ポリシーでは、管理側のエンタープライズが保護データへのアクセスを制御できるように、アプリの一覧と、それぞれのアプリに対する制限を定義します。 既定では、アプリが自律的に保護データにアクセスすることはできません。 アクセスを取得するには、許可一覧と呼ばれる一覧にアプリを追加する必要があります。許可一覧に含まれるアプリは、許可されたアプリと呼ばれます。 管理されたデバイスでは、クリップボードや共有コントラクト経由での保護データへのアクセスを Windows によって制限または監査できます。許可一覧に含まれていないアプリによるアクセスは、監査されるか、ユーザーの同意が求められるか、または完全にブロックされます。

EDP のポリシーは、管理側のエンタープライズによってデバイスに提供されます (これにより、デバイスが "管理されたデバイス" になります)。 ポリシーのプロビジョニングは、モバイル デバイス管理 (MDM) のユーザーによる登録、IT による手動構成、または System Center Configuration Manager (SCCM) のような管理とポリシー配信のメカニズムを通じて行われる可能性があります。

EDP のファイル保護では、Rights Management Service (RMS) キーがプロビジョニングされている場合はそれが利用されます。これらのキーはデバイス間でローミングできるため、保護データもローミングできるようになります。 RMS キーがない場合、これらの API はローカルの選択的ワイプ キーにフォールバックし、ローミング機能が制限されます。 暗号化されてローミングされるデータには、ダウンレベルの Windows と、Microsoft からプラットフォーム固有の RMS アプリが提供されているサード パーティ製デバイスでアクセスできるほか、RMS 対応のサード パーティ アプリを使ってアクセスすることもできます。

簡潔に言うと、EDP API で保護されたデータはエンタープライズで管理でき、そのエンタープライズによるデータの保護と管理を支援するようにアプリを構築できます。 つまり、エンタープライズ対応のアプリを作成できるということです。 このガイドの残りの部分では、そのために役立つ情報を説明します。

## EDP 用にコンピューターをセットアップする


アプリを適切に開発し、エンタープライズ内での動作をテストするには、コンピューターまたはデバイスを適切な条件でセットアップする必要があります。 これには通常、IT 管理者の担当となるタスクがいくつか含まれます。

-   開発コンピューターをモバイル デバイス管理 (MDM) に登録します。
-   [AppLocker 構成サービス プロバイダー](https://msdn.microsoft.com/library/windows/hardware/dn920019) を使って、アプリを許可一覧に追加します。

次のタスクはアプリの作成です。このアプリは、実行元のエンタープライズの管理されている ID と有効な保護ポリシーを認識し、動的に応答できるようにします。 これは、アプリを "対応させる" ことを意味します。 ポリシーへの準拠に対応するアプリは、多くの場合、エンタープライズ データへのアクセスが許可される一覧に含められます。

## エンタープライズ対応アプリ


アプリが許可一覧に追加されたら、そのアプリで保護データを読み取ることができます。 また、既定では、アプリから出力されたデータはすべてシステムによって自動的に保護されます。 このような自動保護機能が用意されているのは、管理側のエンタープライズでは、エンタープライズ データを常に制御下に置いておく必要があるためです。 ただし、アプリにこのような厳しい制約がかかるのは、既定の方法を使った場合だけです。 より良い方法として、アプリがシステムに信頼されるようにすると、十分な機能と柔軟性を得ることができます。 この承認を得るためには、アプリをスマートにする必要があります。 つまり、許可一覧に追加する方法よりも 1 歩進んで、アプリをエンタープライズ対応として作成および宣言します。

以降では、データが使われていなくても、使用中でも、移動中でも、自律的にエンタープライズ データを保護された状態に保つテクニックを説明します。このテクニックを使うと、アプリを対応型にすることができます。 対応アプリは、エンタープライズ データのソースを認識し、アプリで受け取ったときに保護します。 対応するということは、エンタープライズ データがアプリの外部に送られるときに、常に EDP ポリシーを認識して準拠するということでもあります。 これには、エンタープライズ ネットワーク外のエンドポイントにコンテンツが送信されないようにすること、ローミングを許可する前にポータブルな暗号化形式でデータをラップすること、また必要であれば (ポリシーの設定に依存)、許可一覧に含まれていないアプリにエンタープライズ データを貼り付ける前にユーザーに確認を表示することが含まれます。 アプリを対応させたら、制限された **enterpriseDataPolicy** 機能を宣言して、アプリが対応していることをシステムに通知します。 制限された機能の使い方について詳しくは、「[特殊な用途および制限された用途に関する機能](https://msdn.microsoft.com/library/windows/apps/mt270968#special_and_restricted_capabilities)」をご覧ください。

すべてのエンタープライズ データは、使われていないときでも移動中でも保護データとなることが理想的です。 ただし、エンタープライズ データが初めて作成されてから保護されるまでには、必然的に未保護の状態が短時間発生します。 また、場合によっては、エンタープライズ データが暗号化されていない状態でエンタープライズ ネットワークに存在することもあります。 対応アプリでは、このようなデータを自律的に保護することができますが、許可された非対応のアプリでは、システムによる保護が必要です。

これは、非対応アプリは常にエンタープライズ モードで実行されるためです。 これはシステムによって保証されます。 一方、対応アプリでは、操作中のデータの種類に対して適切であれば、いつでもエンタープライズ モードと個人用モードを自由に切り替えることができます。 対応アプリでは、個人用データを尊重し、個人用データをエンタープライズ データとしてタグ付けしないようにすることも重要です。 これらの条件が守られている限り、対応アプリはエンタープライズ データと個人用データの両方を同時に処理できます。 次のセクションでは、コードでモードを切り替える方法を示します。

## ID が管理されていることを確認し、保護ポリシーの強制レベルを特定する

アプリは通常、メールボックスのメール アドレス、管理されているドメイン、URI ホスト名など、外部リソースからエンタープライズ ID を取得します。 [
            **ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync**](https://msdn.microsoft.com/library/windows/apps/dn706027) を呼び出すと、ネットワーク エンドポイント ホスト名に対して管理されている ID があれば取得されます。

次のコード例では、対応動作の一般的な構造を示します。これには、エンタープライズ ID が実際に管理されているかどうかを判別する方法と、現在有効なポリシーを確認する方法が含まれています。

```CSharp
using Windows.Security.EnterpriseData;

...

string identity = "contoso.com";

if (ProtectionPolicyManager.IsIdentityManaged(identity))
{
    EnforcementLevel enforcementLevel = ProtectionPolicyManager.GetEnforcementLevel();

    // During UI activities or network access, call ProtectionPolicyManager APIs
    // (taking the enforcement level into account) to ensure that the system
    // tags data with the identity as appropriate.

    ProtectionPolicyManager.GetForCurrentView().Identity = identity;
    // The app is now in enterprise mode.

    ProtectionPolicyManager.GetForCurrentView().Identity = string.Empty;
    // The app is back in personal mode.
}
else
{
    // No policy enforcement is done on this identity.
}
```

上に示したように、まずエンタープライズの ID に EDP ポリシーが設定されているかどうかを判別します。 "管理されている" という用語は、"EDP ポリシーによって管理されている" ことを意味します。 特定の ID に EDP ポリシーが設定されている場合、[**ProtectionPolicyManager.IsIdentityManaged**](https://msdn.microsoft.com/library/windows/apps/dn705171) はその ID に対して true を返します。 これが、その ID で EDP API を使う根拠になります。 ファイルとバッファーの API は例外的で、管理されていない ID に対しても期待どおりに機能しますが、このような使い方には意味がありません。 デバイスが管理されている場合、それはエンタープライズ ID のために管理されているということです。 ID が管理されていなければ、その ID のデータを保護しても意味はありません。

次の手順では、ポリシーの強制レベルを特定して実装します。 ポリシーの強制レベルを特定するには、[**GetEnforcementLevel**](https://msdn.microsoft.com/library/windows/apps/mt608406) メソッドを呼び出します。 ID にエンタープライズ ポリシーが強制されている場合、対応アプリでは、UI アクティビティやネットワーク アクセスの実行中に [**ProtectionPolicyManager**](https://msdn.microsoft.com/library/windows/apps/dn705170) API を呼び出して、システムがポリシーを適用できるようにする必要があります。これにより、システムは、この ID でのデータ転送を必要に応じて確実にタグ付けできるようになります。 強制レベルを解釈して実際に処理する方法の詳細は、このガイドで説明しています。 コード例には、エンタープライズ モードに移行する方法と、個人用モードに戻す方法についても示されています。これを行うには、[**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) の値をエンタープライズ ID または空の文字列にそれぞれ設定します。 ここでも、エンタープライズ モードの開始と終了は、管理されている ID でのみ意味を持つことに注意してください。

## EDP 機能の概要


**ファイルとバッファーの保護。**

-   エンタープライズ ID に関連付けられているデータを、アプリで保護、コンテナー化、ワイプすることができます。
-   キー管理は Windows によって処理されます。 Windows は、デバイスにエンタープライズの RMS キーがあればそれを使います。キーがない場合は、ローカルの選択的ワイプによる保護にフォールバックします。

**デバイス ポリシーの管理。**

-   アプリでは、デバイスを管理している ID (エンタープライズまたは組織) を照会できます。
-   アプリでは、問題となるデータに ID を関連付けることで、ユーザーの不注意によるデータの漏えいを防止できます。
-   アプリでは、エンタープライズが所有するネットワーク エンドポイント接続 (サーバー、IP 範囲) を調べ、管理されている (MDM に登録されている) ID にデータを関連付けることで、ネットワーク上のエンタープライズ リソースを保護できます。
-   EDP API は、管理されていて、デバイスに EDP ポリシーを定義している ID でのみ機能します。 ID が管理されていない場合は、必要に応じて API からアプリケーションに通知が返されます。

次の一覧は、EDP API と、それぞれの特定の機能領域に固有のシナリオについて詳しく説明するトピックへのリンクを示したものです。

## ファイル

「[EDP によるファイルの保護](../files/protect-your-enterprise-data-with-edp.md)」をご覧ください。

## ストリームとバッファー

「[EDP を使ったストリームとバッファーの保護](../files/use-edp-to-protect-streams-and-buffers.md)」をご覧ください。

## クリップボード、共有、アプリ間でのデータ交換

「[EDP を使ったアプリ間で転送されるエンタープライズ データの保護](../app-to-app/use-edp-to-protect-enterprise-data-transferred-between-apps.md)」をご覧ください。

## ネットワーク

「[EDP ID を使ったネットワーク接続のタグ付け](../networking/tagging_network_connections_with_edp_identity.md)」をご覧ください。

## ロックの背後でのデータ保護 (DPL) とバックグラウンド タスク

組織では、必要に応じて安全な "ロックの背後でのデータ保護" (DPL) ポリシーを管理できます。このポリシーが有効な場合は、デバイスがロックされると、保護されたリソースへのアクセスに必要な暗号化キーが一時的にデバイスのメモリから削除されます。 この状況に対応するようにアプリを準備するには、このトピックの「[デバイスのロック イベントを処理し、保護されていないコンテンツをメモリ内に残さないようにする](#handle_lock_events)」をご覧ください。 また、ファイルを保護する必要のあるバックグラウンド タスクをアプリで実行する場合は、「[新しいファイルで企業データを保護する (バックグラウンド タスクの場合)](../files/protect-your-enterprise-data-with-edp.md#protect_data_new_file_bg)」をご覧ください。

## UI ポリシーの適用


このセクションでは、対応型のメール アプリの例を取り上げます。このアプリは現在、ユーザーが所有するエンタープライズ メールボックスと個人用メールボックスの両方を含むメールボックスのセットの中から、エンタープライズ メールボックスを表示しています。 エンタープライズ メールボックス内のエンタープライズ データからデータが漏えいすることのないように、アプリは [**ProtectionPolicyManager.TryApplyProcessUIPolicy**](https://msdn.microsoft.com/library/windows/apps/dn705791) を呼び出して、アプリの現在のコンテキスト (エンタープライズか個人用か) をオペレーティング システムに通知します。 ID がエンタープライズ ポリシーによって管理されていない場合、API は false を返します。

```CSharp
using Windows.Security.EnterpriseData;

...

public class Mailbox
{
    public bool HasEnterpriseMail { get { /* implementation */ } }
    public string Identity { get { /* implementation */ } }
}

private void SwitchMailbox(Mailbox targetMailbox)
{
    // Code goes here to perform setup for "targetMailbox".

    if (targetMailbox.HasEnterpriseMail)
    {
        bool result = 
            ProtectionPolicyManager.TryApplyProcessUIPolicy(targetMailbox.Identity);

        // Code goes here to process "result", which indicates whether
        // or not policy enforcement is in place for the identity.
    }
    else
    {
        // For personal mailboxes, we clear policy enforcement (in case
        // it is still set from when we processed an enterprise mailbox).
        ProtectionPolicyManager.ClearProcessUIPolicy();
    }
}
```

## デバイスのロック イベントを処理し、保護されていないコンテンツをメモリ内に残さないようにする


このシナリオでは、エンタープライズ メールと個人用メールの両方を処理するように設計された対応型のメール アプリの例を取り上げます。 安全な "ロックの背後でのデータ保護" (DPL) ポリシーを管理している組織内でアプリが実行されている場合、そのアプリでは、デバイスがロックされている間、メモリからすべての機密データを削除する必要があります。 これを実行するには、(DPL が有効な場合に) デバイスがロックされたときとロックが解除されたときに通知を受け取るように、[**ProtectionPolicyManager.ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/dn705787) イベントと [**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/dn705786) イベントに登録します。

[**ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/dn705787) は、デバイスにプロビジョニングされたデータ保護キーが一時的に削除される前に発生します。 デバイスがロックされたときにこれらのキーが削除される理由は、デバイスのロック中、場合によってはデバイスが所有者の手元から離れている間に、暗号化されたデータに対して未承認のアクセスが行われないようにするためです。 [**ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/dn705786) は、デバイスのロックが解除され、キーが再び利用可能になったときに発生します。

アプリでこれらの 2 つのイベントを処理すれば、[**DataProtectionManager**](https://msdn.microsoft.com/library/windows/apps/dn706017) によって、メモリ内の機密性の高いコンテンツをすべて確実に保護できます。 また、システムが機密データをメモリ内にキャッシュしないように、保護されたファイルに対して開かれているファイル ストリームをすべて閉じる必要があります。 これはいくつかの方法で行うことができます。 **StorageFile** の Open メソッドから返されたファイル ストリームを閉じるには、ストリームの **Dispose** メソッドを呼び出します。 ストリームを使用するスコープは、using ステートメント (C\# または VB) で指定できます。 または、ストリームを **DataReader** オブジェクトか **DataWriter** オブジェクトでラップし、そのオブジェクトで **Dispose** メソッドまたは using ステートメントを使う方法もあります。

**注**  
DPL ポリシーが構成されていない環境では、[**ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/dn705786) イベントは発生しますが、[**ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/dn705787) イベントは発生しません。 コードではこの点に注意し、これらのイベントがどのストリームでも常に組になって発生するとは想定しないでください。これらのイベントは、デバイスのロック/ロック解除状態を判別するために使用できるとは限りません。 次のコード例を見ると、現在表示しているメールの保護状態や、データベース ファイル ストリームのオープン状態に関して、何の想定もしないように注意を払っていることがわかります。

また、DPL ポリシーが構成されていないデバイスでロック状態から再開するときは、[**ProtectedAccessResumedEventArgs.Identities**](https://msdn.microsoft.com/library/windows/apps/dn705772) が空のコレクションになることにも注意が必要です。

わかりやすくするために、このコード例は単純化され、エンタープライズ メールの処理に焦点を当てています。 実際のアプリでは、個人用メールは保護されていない別のメール データベース ファイルに書き込まれ、ロック状態で個人用メールを保護する必要もありません。

```CSharp
using Windows.Security.Cryptography;
using Windows.Security.EnterpriseData;
using Windows.Storage;
using Windows.Storage.Streams;

...

public class DisplayedMail
{
    public string Body { get; set; }
    public IBuffer ProtectedBody { get; set; }
    public bool IsProtected { get; set; }
}

private IOutputStream mailDatabaseStream = null;
private string currentlyDisplayedMailIdentity = "contoso.com";
private DisplayedMail currentlyDisplayedMail = new DisplayedMail()
    { Body = "Lorem ipsum dolor...", ProtectedBody = null, IsProtected = false };

// Gets the app's protected mail database file, then opens and stores a stream on it.
private async void OpenMailDatabase()
{
    // Only attempt to open the database file stream if we know it&#39;s closed.
    if (this.mailDatabaseStream == null)
    {
        StorageFolder appDataStorageFolder = ApplicationData.Current.LocalFolder;
        StorageFile storageFile = await appDataStorageFolder.GetFileAsync("maildb.dat");
        using (IRandomAccessStream randomAccessStream =
            await storageFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            this.mailDatabaseStream = randomAccessStream.GetOutputStreamAt(0);
        }
    }
}

// Called once by the app when starting up.
private void AppSetup()
{
    ProtectionPolicyManager.ProtectedAccessSuspending +=
        this.ProtectionPolicyManager_ProtectedAccessSuspending;
    ProtectionPolicyManager.ProtectedAccessResumed +=
        this.ProtectionPolicyManager_ProtectedAccessResumed;
    this.OpenMailDatabase();
}

// Background work called when the app receives an email.
private async void AppMailReceived(string fauxEmail)
{
    // Only attempt to write to the database file stream if we know it&#39;s open.
    if (this.mailDatabaseStream != null)
    {
        IBuffer emailAsBuffer = CryptographicBuffer.ConvertStringToBinary
            (fauxEmail, BinaryStringEncoding.Utf8);
        await this.mailDatabaseStream.WriteAsync(emailAsBuffer);
        await this.mailDatabaseStream.FlushAsync();
    }
    else
    {
        // Code goes here to handle the case where the device is
        // locked and we can't access the protected mail database.
    }
}

// Called by ProtectionPolicyManager when the device is locked if under DPL.
private async void ProtectionPolicyManager_ProtectedAccessSuspending
    (object sender, ProtectedAccessSuspendingEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.currentlyDisplayedMailIdentity))
    {
        // This event is not for our identity. Another will be sent for our identity.
        return;
    }

    // Get suspension deferral.
    Windows.Foundation.Deferral deferral = e.GetDeferral();

    // Protect the displayed mail content.
    if (!this.currentlyDisplayedMail.IsProtected)
    {
        IBuffer mailBodyBuffer = CryptographicBuffer.ConvertStringToBinary
            (this.currentlyDisplayedMail.Body, BinaryStringEncoding.Utf8);
        BufferProtectUnprotectResult result = await DataProtectionManager.ProtectAsync
            (mailBodyBuffer, this.currentlyDisplayedMailIdentity);
        if (result.ProtectionInfo.Status == DataProtectionStatus.Protected)
        {
            // Save the protected version and clear the unprotected version.
            this.currentlyDisplayedMail.ProtectedBody = result.Buffer;
            this.currentlyDisplayedMail.Body = null;
        }
    }

    // Close the mail database file stream to make sure that we have no unprotected
    // content in memory.
    this.mailDatabaseStream.Dispose();
    this.mailDatabaseStream = null;

    // Optionally, code goes here to use e.Deadline to determine whether we have more
    // than 15 seconds left before the suspension deadline. If we do then process any
    // messages queued up for sending while we are still able to access them.

    // All done. Complete deferral.
    deferral.Complete();
}

// Called by ProtectionPolicyManager when the device is unlocked.
private async void ProtectionPolicyManager_ProtectedAccessResumed
    (object sender, ProtectedAccessResumedEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.currentlyDisplayedMailIdentity))
    {
        // This event is not for our identity. Another will be sent for our identity.
        return;
    }

    // Unprotect the displayed mail content.
    if (this.currentlyDisplayedMail.IsProtected)
    {
        BufferProtectUnprotectResult result = await DataProtectionManager.UnprotectAsync
            (this.currentlyDisplayedMail.ProtectedBody);
        if (result.ProtectionInfo.Status == DataProtectionStatus.Unprotected)
        {
            // Restore the unprotected version.
            this.currentlyDisplayedMail.Body = CryptographicBuffer.ConvertBinaryToString
                (BinaryStringEncoding.Utf8, result.Buffer);
            this.currentlyDisplayedMail.ProtectedBody = null;
        }
    }

    // Reopen the closed mail database.
    this.OpenMailDatabase();
}
```

## 保護されたコンテンツが失効したときに通知を受け取るように登録する


このシナリオでは、メール アプリがユーザーのデバイスにエンタープライズ メールボックスをセットアップしたと想定します。 エンタープライズでは、いずれかの時点で、何らかの理由から、そのデバイス上にあるエンタープライズで保護されたメールやその他のリソースへのアクセスを取り消すことがあります。 取り消しが必要となる理由はいくつか考えられます。 特に可能性が高いのは、登録解除に伴って特定のエンタープライズ ポリシーによって取り消された場合です。1 つのシナリオとして、ユーザーがエンタープライズからデバイスの登録を解除した場合 (デバイスを譲渡または販売する場合、別のデバイスを使うことにした場合、転職した場合、退職した場合など) が考えられます。 別のシナリオとしては、IT 管理者により、モバイル デバイス管理 (MDM) を通じてリモートから登録解除の通知が送信された場合があります。これは、デバイスを紛失したという報告を受けて行われることがあります。

詳しい状況はどうあれ、ユーザーのデバイスにメールを保持する必要はなくなったため、エンタープライズはデバイスからすべてのメールをワイプする要求を送信します。 デバイス上のリモート管理クライアントは、エンタープライズのリモート管理サーバーから要求を受け取り、[**ProtectionPolicyManager.RevokeContent**](https://msdn.microsoft.com/library/windows/apps/dn705790) を呼び出して、そのデバイス上にある、そのエンタープライズ ID で保護されたコンテンツにアクセスするためのキーを失効させます。

失効の発生時にアプリで通知を受け取る必要がある場合は、[**ProtectionPolicyManager.ProtectedContentRevoked**](https://msdn.microsoft.com/library/windows/apps/dn705788) イベントに登録することができます。 アプリでイベントを受け取ったら、エンタープライズ メールボックスに関連付けられているメタデータは不要になるため、すべて削除できます。

```CSharp
using Windows.Security.EnterpriseData;

...

private string mailIdentity = "contoso.com";

void MailAppSetup()
{
    ProtectionPolicyManager.ProtectedContentRevoked += ProtectionPolicyManager_ProtectedContentRevoked;
    // Code goes here to set up mailbox for &#39;mailIdentity&#39;.
}

private void ProtectionPolicyManager_ProtectedContentRevoked(object sender, ProtectedContentRevokedEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.mailIdentity))
    {
        // This event is not for our identity.
        return;
    }

    // Code goes here to delete any metadata associated with &#39;mailIdentity&#39;.
}
```

## リモート管理クライアントでエンタープライズ保護データのワイプを開始する


ユーザーの個人用デバイスに、エンタープライズ ID で保護されたエンタープライズ ファイルがいくつか存在するとします。 このデバイスをユーザーが紛失しました。 エンタープライズでは、ユーザーがデバイスを紛失したことに気付いたら、すべての機密データをユーザーのデバイスからワイプする要求を送信して、データの漏えいを防ぎます。 デバイス上のリモート管理クライアントは、エンタープライズのリモート管理サーバーからこの要求を受け取り、[**ProtectionPolicyManager.RevokeContent**](https://msdn.microsoft.com/library/windows/apps/dn705790) を呼び出して、エンタープライズ ID で保護されたコンテンツにアクセスするためのキーを失効させます。

```CSharp
Windows.Security.EnterpriseData.ProtectionPolicyManager.RevokeContent("contoso.com");
```

 

 





<!--HONumber=Mar16_HO5-->


