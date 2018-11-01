---
title: Windows Hello
description: この記事では、Windows 10 オペレーティング システムの一部としてリリースされる新しい Windows Hello テクノロジについて説明します。また、開発者がこのテクノロジを実装して、ユニバーサル Windows プラットフォーム (UWP) アプリやバックエンド サービスを保護する方法についても説明します。 従来の資格情報を使用する際に生じる脅威を軽減するこれらのテクノロジの特定の機能に着目し、Windows 10 ロールアウトに含まれるこれらのテクノロジの設計と展開について説明します。
ms.assetid: 0B907160-B344-4237-AF82-F9D47BCEE646
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 9b2ee216059163e7232d65eb515645d9e7db56b3
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5873568"
---
# <a name="windows-hello"></a>Windows Hello




この記事では、Windows 10 オペレーティング システムの一部としてリリースされる新しい Windows Hello テクノロジについて説明します。また、開発者がこのテクノロジを実装して、ユニバーサル Windows プラットフォーム (UWP) アプリやバックエンド サービスを保護する方法についても説明します。 従来の資格情報を使用する際に生じる脅威を軽減するこれらのテクノロジの特定の機能に着目し、Windows 10 ロールアウトに含まれるこれらのテクノロジの設計と展開について説明します。

この記事では、アプリの開発に焦点を当てていることに注意してください。 Windows Hello のアーキテクチャおよび実装について詳しくは、「[TechNet の Windows Hello ガイド](https://technet.microsoft.com/library/mt589441.aspx)」をご覧ください。

完全なコード サンプルについては、「[GitHub の Windows Hello コード サンプル](http://go.microsoft.com/fwlink/?LinkID=717812)」をご覧ください。

Windows Hello と背後の認証サービスを使って UWP アプリを作成する具体的な手順については、「[Windows Hello ログイン アプリ](microsoft-passport-login.md)」と「[Windows Hello ログイン サービス](microsoft-passport-login-auth-service.md)」をご覧ください。

## <a name="1-introduction"></a>1 はじめに


情報セキュリティの基本的前提は、システムで使用ユーザーを識別できることです。 ユーザーを識別することにより、システムでは、ユーザーが適切に識別されているかどうかを判断し (認証と呼ばれるプロセス)、適切に認証されたユーザーが実行できる内容を決定できます (承認と呼ばれるプロセス)。 世界中に展開されたコンピューター システムの大部分は、認証と承認の判断を行う際にユーザーの資格情報に依存しています。つまり、これらのシステムにおけるセキュリティの基盤は、ユーザーが作成した再利用可能なパスワードに依存しています。 認証に「記憶によるもの、持ち物によるもの、本人の特長によるもの」を含めることができるということが、ある問題をしっかりと浮き彫りにしているとよく言われます。それは、再利用可能なパスワードは認証要素そのものであるため、パスワードを手に入れたユーザーは、元の所有者を偽装できるという点です。

## <a name="11-problems-with-traditional-credentials"></a>1.1 従来の資格情報の問題


1960 年代中ごろから、Fernando Corbató と Massachusetts Institute of Technology の彼のチームはパスワードの導入を提唱し、ユーザーと管理者はユーザーの認証と承認用のパスワードの使用に対応する必要がありました。 時間の経過と共に、最新のパスワードの保存と使用方法が少しずつ進化してきましたが (安全なハッシュ化とソルトなど)、未だに 2 つの問題に直面しています。 パスワードは簡単に複製でき、簡単に盗むことができます。 さらに、実装を失敗すると、パスワードが危険にさらされてしまう可能性があり、ユーザーは利便性とセキュリティの難しい舵取りを強いられます。

## <a name="111-credential-theft"></a>1.1.1 資格情報の盗難


パスワードの最大のリスクは単純です。攻撃者がパスワードを簡単に盗むことができる点です。 パスワードの入力、処理、または保存を行うすべての場所に脆弱性があります。 たとえば、攻撃者が、アプリケーション サーバーへのネットワーク トラフィックを傍受したり、アプリケーションやデバイスにマルウェアを埋め込んだり、デバイスへのユーザーのキーボード操作をログに記録したり、ユーザーが入力する文字を観察したりして、認証サーバーから一連のパスワードまたはハッシュを盗むことができます。 これらは、最も一般的な攻撃の方法です。

資格情報再生に関連するリスクがもう 1 つあります。この場合、攻撃者がセキュリティで保護されていないネットワークを傍受して有効な資格情報を取得し、後でその資格情報を再生して有効なユーザーを偽装します。 ほとんどの認証プロトコル (Kerberos や OAuth など) は、資格情報交換プロセスにタイム スタンプを追加して再生攻撃を防いでいますが、この方法で保護されるのは、認証システムが発効したトークンだけであり、ユーザーが最初にチケットを取得するために入力したパスワードは保護されません。

## <a name="112-credential-reuse"></a>1.1.2 資格情報の再利用




ユーザー名としてメール アドレスを使う一般的な手法により、問題がさらに悪化します。 侵入したシステムからユーザー名とパスワードのペアをうまく復元した攻撃者は、この同じペアを他のシステムに試してみることができます。 非常に多くの場合、この方法によって、攻撃者は侵入したシステムから別のシステムに入り込むことができます。 ユーザー名にメール アドレスを使用すると、他の問題が発生します。それについては、このガイドの後半で説明します。

## <a name="12-solving-credential-problems"></a>1.2 資格情報の問題解決


パスワードが原因で発生する問題の解決は簡単ではありません。 パスワード ポリシーのみを強化しても役に立ちません。ユーザーは、単にパスワードを再利用、共有、またはメモしてしまう場合があります。 ユーザーの教育は認証セキュリティにとって重要ですが、教育だけでも問題を取り除けません。

Windows Hello では、パスワードに代わって強固な 2 要素認証 (2FA) が利用されます。この認証は、既存の資格情報の確認、およびユーザーのジェスチャ (生体認証または PIN ベース) で保護されるデバイス固有の資格情報の作成によって実現されます。 


## <a name="2-what-is-windows-hello"></a>2 Windows Hello とは


Windows Hello は、Microsoft が Windows 10 に組み込まれた新しい生体認証サインイン システムに付けた名前です。 Windows Hello はオペレーティング システムに直接組み込まれているため、顔または指紋を識別して、ユーザーのデバイスのロックを解除できます。 ユーザーが自分固有の生体認証識別子を入力して、デバイス固有の資格情報にアクセスする場合に認証が行われます。つまり、攻撃者がデバイスを盗んでも、PIN がない限りデバイスにログオンすることはできません。 Windows のセキュリティ保護された資格情報ストアは、デバイス上の生体認証データを保護します。 Windows Hello を使ってデバイスのロックを解除することで、承認済みユーザーは、Windows エクスペリエンス、アプリ、データ、Web サイト、およびサービスのすべてにアクセスできます。

Windows Hello 認証システムは、Hello と呼ばれています。 Hello は、個々のデバイスと特定のユーザーの組み合わせに対して一意です。 これは、デバイス間でローミングされず、サーバーまたは呼び出し元のアプリとは共有されず、デバイスから簡単に抽出することはできません。 複数のユーザーがデバイスを共有している場合、各ユーザーは自分のアカウントを設定する必要があります。 各アカウントには、そのデバイス用の一意の Hello が与えられます。 Hello は、保存されている資格情報のロック解除 (またはリリース) に使用できるトークンのようなものと考えることができます。 Hello 自体は、アプリまたはサービスに対する認証を行わず、認証できる資格情報をリリースします。 つまり、Hello はユーザーの資格情報ではなく、認証プロセス用の 2 番目の要素となります。

## <a name="21-windows-hello-authentication"></a>2.1 Windows Hello 認証


Windows Hello は、個々のユーザーを認識するための堅牢な方法をデバイスに提供します。これにより、ユーザーと要求されたサービス (またはデータ項目) との間のパスの最初の部分が処理されます。 デバイスがユーザーを認識しても、要求されたリソースへのアクセス権を与えるかどうかを決める前に、ユーザーをまだ認証する必要があります。 Windows Hello は強力な 2FA で、Windows に完全に組み込まれています。これにより、再利用可能なパスワードが、特定のデバイスと生体認証ジェスチャや PIN の組み合わせに置き換わります。

Windows Hello は、従来の 2FA システムの単なる代替機能ではありません。 概念的にはスマート カードと似ています。Windows Hello では、文字列比較ではなく、暗号化プリミティブを使って認証が行われます。また、ユーザーのキー マテリアルは、改ざんされにくいハードウェア内でセキュリティ保護されています。 Windows Hello ではスマート カード展開に必要なインフラストラクチャ コンポーネントも追加する必要がありません。 具体的には、現在、公開キー基盤 (PKI) を所持していない場合は、証明書を管理するための PKI は必要ありません。 Windows Hello では、スマート カードの主な利点である、仮想スマート カードの展開の柔軟性と物理スマート カードの堅牢なセキュリティを組み合わせ、それぞれの欠点を排除しています。

## <a name="22-how-windows-hello-works"></a>2.2 Windows Hello のしくみ


ユーザーがコンピューターで Windows Hello をセットアップするとき、デバイスの新しい公開/秘密キーのペアが生成されます。 [トラステッド プラットフォーム モジュール](https://technet.microsoft.com/itpro/windows/keep-secure/trusted-platform-module-overview) (TPM) はこの秘密キーを生成し、保護します。 デバイスに TPM チップが搭載されていない場合、秘密キーはソフトウェアによって暗号化され、保護されます。 また、TPM が有効なデバイスでは、キーが TPM にバインドされていることを証明する際に使われるデータ ブロックが生成されます。 この証明情報をソリューションで利用し、たとえば、さまざまな認証レベルをユーザーに付与するかどうかを決定することができます。

デバイスで Windows Hello を有効にするには、Azure Active Directory アカウントまたは Windows の設定で関連付けられた Microsoft アカウントが必要です。

## <a name="221-how-keys-are-protected"></a>2.2.1 キーを保護する方法


キー マテリアルを生成する場合は、常に攻撃から保護する必要があります。 これを実現する最も堅牢な方法は、ハードウェアをカスタマイズすることです。 セキュリティ クリティカルなアプリケーションのキーの生成、保存、および処理には、これまでずっとハードウェア セキュリティ モジュール (HSM) を使用してきました。 スマート カードは特別な種類の HSM で、Trusted Computing Group TPM 標準に準拠しているデバイスでもあります。 可能であれば、Windows Hello 実装では、オンボード TPM ハードウェアを活用して、キーの生成、保存、および処理を行います。 ただし、Windows Hello と Windows Hello for Work にはオンボード TPM は必要ありません。

可能であれば、TPM ハードウェアを使用することをお勧めします。 TPM は、PIN のブルート フォース攻撃など、さまざまな既知の潜在的な攻撃を防げます。 アカウント ロックアウト後も、TPM はさらなる保護を追加します。 TPM がキー マテリアルをロックしている場合、ユーザーは PIN をリセットする必要があります。 PIN をリセットすると、古いキー マテリアルで暗号化されたすべてのキーと証明書は削除されます。

## <a name="222-authentication"></a>2.2.2 認証


ユーザーが保護されたキー マテリアルにアクセスする場合、認証プロセスでは、最初に "キーのリリース" と呼ばれるプロセスが行われ、ユーザーは PIN または生体認証ジェスチャを入力してデバイスのロックを解除します。

アプリケーションは、別のアプリケーションからのキーを使うことはできません。また、だれも別のユーザーからのキーを使うことはできません。 これらのキーを使って、ID プロバイダー (IDP) に送信される要求に署名し、指定したリソースへのアクセスを要求します。 アプリケーションは特定の API を使って、特定の動作でキー マテリアルを必要とする操作を要求できます。 これらの API 使ってアクセスする場合、ユーザーのジェスチャを利用した明示的な検証が必要になります。キー マテリアルは要求元のアプリケーションに公開されません。 代わりに、アプリケーションはデータへの署名などの特定の操作を要求し、Windows Hello レイヤーは、実際の作業を処理して、結果を返します。

## <a name="23-getting-ready-to-implement-windows-hello"></a>2.3 Windows Hello を実装するための準備


以上で、Windows Hello のしくみの基本について学習しました。次に、Windows Hello をアプリケーションに実装する方法について説明します。

Windows Hello を使った実装については、さまざまなシナリオがあります。 たとえば、デバイスでアプリにログオンする場合が挙げられます。 他の一般的なシナリオとしては、サービスに対して認証を行うシナリオがあります。 ログオン名とパスワードを使う代わりに、Windows Hello を使います。 以降の章では、いくつかの異なるシナリオの実装について説明します。Windows Hello を使いサービスに対して認証する方法や、既にあるユーザー名/パスワード システムから Windows Hello システムへの変換方法などについて説明します。

最後に、Windows Hello API については、アプリを使用するオペレーティング システムと一致する Windows 10 SDK を使用する必要があることに注意してください。 つまり、Windows 10 に展開するアプリには 10.0.10240 Windows SDK を使用する必要があり、Windows 10 バージョン 1511 に展開するアプリには 10.0.10586 を使用する必要があります。

## <a name="3-implementing-windows-hello"></a>3 Windows Hello の実装


この章では、認証システムがない新規のシナリオから始め、Windows Hello を実装する方法について説明します。

次のセクションでは、既存のユーザー名/パスワード システムから移行する方法について説明します。 ただし、次の章の方に興味がある場合でも、この章に目を通して、必要なプロセスとコードの基本を理解することをお勧めします。

## <a name="31-enrolling-new-users"></a>3.1 新しいユーザーの登録


まず、新しいデバイスにサインアップしようとしている新しいユーザーを仮定して、Windows Hello を使用する新しいサービスについて説明します。

最初に、ユーザーが Windows Hello を使用できることを確認します。 アプリは、ユーザー設定とコンピューターの機能を調べ、ユーザー ID キーを作成できることを確認します。 アプリは、ユーザーがまだ Windows Hello を有効にしていないと判断した場合、アプリを使う前に、ユーザーに対して Windows Hello をセットアップするように求めます。

ユーザーが Out of Box Experience (OOBE) で PIN をセットアップしていない場合、Windows Hello を有効にするには、ユーザーは Windows 設定で PIN をセットアップする必要があります。

次のコード行は、ユーザーが Windows Hello をセットアップしたかどうかを調べるための簡単な方法を示しています。

```cs
var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
if (!keyCredentialAvailable)
{
   // User didn't set up PIN yet
   return;
}
```

次の手順では、サービスにサインアップするための情報をユーザーに要求します。 氏名、メール アドレス、および一意のユーザー名などをユーザーに要求できます。 メール アドレスを一意の識別子として使うこともできます。これは任意に指定できます。

このシナリオでは、ユーザーの一意の識別子としてメール アドレスを使用します。 ユーザーがサインアップしたら、アドレスが有効であることを確認するために確認メールを送信することを検討する必要があります。 これにより、必要な場合にアカウントをリセットすることができます。

ユーザーが自分の PIN をセットアップすると、アプリはユーザーの [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成します。 また、アプリは、オプションでキーの構成証明情報も取得して、キーが TPM で生成されたことを示す暗号証明を入手します。 生成された公開キーと、キーの構成証明 (任意に指定) をバックエンド サーバーに送信して、使われているデバイスを登録します。 各デバイスで生成されたすべてのキーのペアは一意になります。

[**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成するコードは、次のようになります。

```cs
var keyCreationResult = await KeyCredentialManager
    .RequestCreateAsync(AccountId, KeyCredentialCreationOption.ReplaceExisting);
```

[**RequestCreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn973048) では、公開キーと秘密キーの作成を行います。 デバイスに適切な TPM チップが搭載されている場合、API は、秘密キーと公開キーの作成およびその結果の保存を TPM チップに要求します。TPM チップが利用できない場合は、OS によって、コードでキーのペアが作成されます。 作成した秘密キーにアプリが直接アクセスする方法はありません。 キーのペアを作成する処理によって、構成証明情報も生成されます。 (構成証明について詳しくは、次のセクションをご覧ください。)

デバイスでキーのペアと構成証明情報が作成されたら、公開キー、オプションの構成証明情報、および一意の識別子 (メール アドレスなど) をバックエンドの登録サービスに送信し、バックエンドに保存する必要があります。

ユーザーが複数のデバイスでアプリにアクセスできるようにする場合、バックエンド サービスでは、同じユーザーに対して複数のキーを保存できるようにする必要があります。 すべてのキーは各デバイスで一意であるため、これらすべてのキーを同じユーザーに関連付けて保存します。 デバイス識別子を使うと、ユーザーを認証するときに、サーバー部分を最適化することができます。 これについては、次の章で詳しく説明します。

バックエンドでこの情報を保存するサンプルのデータベース スキーマは、次のようになります。

![Windows Hello のサンプル データベース スキーマ](images/passport-db.png)

登録のロジックは次のようになります。

![Windows Hello の登録ロジック](images/passport-registration.png)

収集する登録情報はもちろん、この単純なシナリオよりも多くの識別情報を含む場合があります。 たとえば、アプリが、バンキング用などのセキュリティで保護されたサービスにアクセスする場合、サインアップ プロセスの一部として ID やその他の項目の証明を要求する必要があります。 すべての条件が満たされると、ユーザーの公開キーがバックエンドに保存され、次回ユーザーがサービスを利用するときの検証でこの公開キーが使われます。

```cs
using System;
using System.Runtime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Security.Credentials;

static async void RegisterUser(string AccountId)
{
    var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
    if (!keyCredentialAvailable)
    {
        // The user didn't set up a PIN yet
        return;
    }

    var keyCreationResult = await KeyCredentialManager.RequestCreateAsync(AccountId, KeyCredentialCreationOption.ReplaceExisting);
    if (keyCreationResult.Status == KeyCredentialStatus.Success)
    {
        var userKey = keyCreationResult.Credential;
        var publicKey = userKey.RetrievePublicKey();
        var keyAttestationResult = await userKey.GetAttestationAsync();
        IBuffer keyAttestation = null;
        IBuffer certificateChain = null;
        bool keyAttestationIncluded = false;
        bool keyAttestationCanBeRetrievedLater = false;

        keyAttestationResult = await userKey.GetAttestationAsync();
        KeyCredentialAttestationStatus keyAttestationRetryType = 0;

        if (keyAttestationResult.Status == KeyCredentialAttestationStatus.Success)
        {
            keyAttestationIncluded = true;
            keyAttestation = keyAttestationResult.AttestationBuffer;
            certificateChain = keyAttestationResult.CertificateChainBuffer;
        }
        else if (keyAttestationResult.Status == KeyCredentialAttestationStatus.TemporaryFailure)
        {
            keyAttestationRetryType = KeyCredentialAttestationStatus.TemporaryFailure;
            keyAttestationCanBeRetrievedLater = true;
        }
        else if (keyAttestationResult.Status == KeyCredentialAttestationStatus.NotSupported)
        {
            keyAttestationRetryType = KeyCredentialAttestationStatus.NotSupported;
            keyAttestationCanBeRetrievedLater = true;
        }
    }
    else if (keyCreationResult.Status == KeyCredentialStatus.UserCanceled ||
        keyCreationResult.Status == KeyCredentialStatus.UserPrefersPassword)
    {
        // Show error message to the user to get confirmation that user
        // does not want to enroll.
    }
}
```

## <a name="311-attestation"></a>3.1.1 構成証明


キーのペアを作成するときに、TPM チップで生成される構成証明情報を要求することもできます。 このオプションの情報は、サインアップ プロセスの一環としてサーバーに送信できます。 TPM キーの構成証明は、キーが TPM にバインドされていることを暗号で証明するプロトコルです。 この種類の構成証明を使うことで、特定の暗号化操作が特定のコンピューターの TPM で行われたことを保証できます。

生成された RSA キー、構成証明ステートメント、および AIK 証明書をサーバーが受け取った場合、サーバーは次の項目を確認します。

-   AIK 証明書の署名が有効であること。
-   AIK 証明書チェーンをたどって、信頼されたルートに到達できること。
-   AIK 証明書とそのチェーンが、EKU OID "2.23.133.8.3" (フレンドリ名は "認証 ID キーの証明書") に対して有効になっていること。
-   AIK 証明書の期間が有効であること。
-   チェーンに含まれている発行元の CA の証明書がすべて有効期間内にあり、失効していないこと。
-   構成証明ステートメントが正しい形式になっていること。
-   [**KeyAttestation**](https://msdn.microsoft.com/library/windows/apps/dn298288) BLOB の署名は、AIK 公開キーを使います。
-   [**KeyAttestation**](https://msdn.microsoft.com/library/windows/apps/dn298288) BLOB に含まれる公開キーは、クライアントが構成証明ステートメントと共に送信した公開 RSA キーと一致します。

アプリは、これらの条件によって、さまざまな認証レベルをユーザーに割り当てる場合があります。 たとえば、これらの確認項目のいずれかが適切でない場合、ユーザーを登録しない、またはユーザーが実行できる操作を制限することがあります。

## <a name="32-logging-on-with-windows-hello"></a>3.2 Windows Hello でのログオン


ユーザーがシステムに登録されると、そのユーザーはアプリを使うことができます。 シナリオによっては、アプリの使用を開始する前にユーザーに認証を求めたり、バックエンド サービスの使用を開始するときにだけユーザーに認証を求めたりすることができます。

## <a name="33-force-the-user-to-sign-in-again"></a>3.3 もう一度サインインするようにユーザーに強制する


いくつかのシナリオでは、ユーザーが、アプリにアクセスする前、または場合によってはアプリ内の特定の操作を実行する前に、そのユーザーが現在サインインしている人であることの証明を必要とすることがあります。 たとえば、バンキング アプリが送金のコマンドをサーバーに送信する前に、使用者がユーザー本人であり、ログインされたデバイスを見つけて取引を行おうとしている他の人物ではないことを確認する必要があります。 [**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) クラスを使って、アプリにもう一度サインインするようにユーザーに強制することができます。 次のコード行では、資格情報の入力をユーザーに強制します。

次のコード行では、資格情報の入力をユーザーに強制します。

```cs
UserConsentVerificationResult consentResult = await UserConsentVerifier.RequestVerificationAsync("userMessage");
if (consentResult.Equals(UserConsentVerificationResult.Verified))
{
   // continue
}
```

また、サーバーのチャレンジ応答メカニズムを使うこともできます。このメカニズムでは、PIN コードや生体認証の資格情報を入力するようにユーザーに要求します。 シナリオによっては、開発者はこのメカニズムを実装する必要があります。 このメカニズムについては、次のセクションで説明します。

## <a name="34-authentication-at-the-backend"></a>3.4 バックエンドでの認証


保護されているバックエンド サービスにアプリがアクセスしようとするとき、そのサービスはチャレンジをアプリに送信します。 アプリはユーザーの秘密キーを使ってチャレンジに署名し、サーバーに返信します。 サーバーではそのユーザーの公開キーが保存されているため、標準的な暗号 API を使って、メッセージが適切な秘密キーによって実際に署名されていることを確認します。 クライアントでは、署名は Windows Hello の API によって実行され、開発者はどのユーザーの秘密キーにもアクセスできません。

キーを確認するだけでなく、サービスでは、キーの構成証明を確認し、デバイスでのキーの保存方法について適用される制限があるかどうかを判断します。 たとえば、デバイスが TPM を使ってキーを保護する場合は、デバイスが TPM を使わずにキーを保護する場合よりも安全性は高くなります。 また、バックエンド ロジックで、たとえば TPM を使わない場合は、リスクを軽減するためにユーザーに対して一定金額の送金を許可するように指定することができます。

構成証明は、バージョン 2.0 以上の TPM チップを搭載しているデバイスでのみ利用できます。 そのため、この構成証明情報がすべてのデバイスで利用できるわけではないということを考慮する必要があります。

クライアントのワークフローは、次の図のようになります。

![Windows Hello クライアントのワークフロー](images/passport-client-workflow.png)

アプリがバックエンドでサービスを呼び出すと、サーバーはチャレンジを送信します。 チャレンジは、次のコードで署名されます。

```cs
var openKeyResult = await KeyCredentialManager.OpenAsync(AccountId);

if (openKeyResult.Status == KeyCredentialStatus.Success)
{
    var userKey = openKeyResult.Credential;
    var publicKey = userKey.RetrievePublicKey();
    var signResult = await userKey.RequestSignAsync(message);
    
    if (signResult.Status == KeyCredentialStatus.Success)
    {
        return signResult.Result;
    }
    else if (signResult.Status == KeyCredentialStatus.UserPrefersPassword)
    {
        
    }
}
```

最初の行の [**KeyCredentialManager.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn973046) では、キー ハンドルを開くように OS に要求します。 これが正常に実行された場合、[**KeyCredential.RequestSignAsync**](https://msdn.microsoft.com/library/windows/apps/dn973058) メソッドにより、OS が Windows Hello を利用してユーザーの PIN や生体認証の情報を要求するようにトリガーされるため、チャレンジ メッセージに署名することができます。 開発者は、ユーザーの秘密キーにはアクセスすることはできません。 秘密キーに対する処理は、API を使うことにより安全性が保たれます。

この API を使って、OS に対して秘密キーを使ってチャレンジに署名するように要求します。 システムでは、PIN コードや構成済みの生体認証ログオンをユーザーに求めます。 適切な情報が入力されると、システムは、暗号化関数を実行してチャレンジに署名するように TPM に要求します。 (TPM を利用できない場合は、フォールバック ソフトウェア ソリューションを使います)。 クライアントは、署名されたチャレンジをサーバーに返信する必要があります。

チャレンジ – 応答の基本フローを次のシーケンス図に示します。

![Windows Hello のチャレンジ応答](images/passport-challenge-response.png)

次に、サーバーは署名を検証する必要があります。 公開キーを要求し、以降の検証用にサーバーに送ると、そのキーは ASN.1 でエンコードされた publicKeyInfo BLOB に格納されます。[GitHub の Windows Hello コード サンプル](http://go.microsoft.com/fwlink/?LinkID=717812)では、Crypt32 の関数をラップしてヘルパー クラスを作成し、ASN.1 エンコードされた BLOB をよく使われる CNG BLOB に変換するために使っています。 この BLOB には、RSA と RSA 公開キーに関する公開キー アルゴリズムが格納されています。

CNG BLOB を作成したら、署名されたチャレンジをユーザーの公開キーに対して検証する必要があります。 各ユーザーは独自のシステムまたはバックエンド テクノロジを使うので、このロジックを実装する汎用的な方法はありません。 ハッシュ アルゴリズムとして SHA256 が使われ、また SignaturePadding の Pkcs1 も使われているので、クライアントからの署名済み応答を検証するときに何を使うかを確認してください。 また、.NET 4.6 でサーバー側のこのロジックを実装するための方法に関するサンプルが示されていますが、一般的には次のようになります。

```cs
using (RSACng pubKey = new RSACng(publicKey))
{
   retval = pubKey.VerifyData(originalChallenge, responseSignature,  HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1); 
}
```

保存されている公開キー (RSA キー) を読み取ります。 署名されたチャレンジ メッセージを公開キーを使って検証し、これが確認できたら、ユーザーが承認されます。 ユーザーが認証されると、アプリは通常どおりバックエンド サービスを呼び出すことができます。

完全なコードは、次のようになります。

```cs
using System;
using System.Runtime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Security.Credentials;

static async Task<IBuffer> GetAuthenticationMessageAsync(IBuffer message, String AccountId)
{
    var openKeyResult = await KeyCredentialManager.OpenAsync(AccountId);

    if (openKeyResult.Status == KeyCredentialStatus.Success)
    {
        var userKey = openKeyResult.Credential;
        var publicKey = userKey.RetrievePublicKey();
        var signResult = await userKey.RequestSignAsync(message);
        if (signResult.Status == KeyCredentialStatus.Success)
        {
            return signResult.Result;
        }
        else if (signResult.Status == KeyCredentialStatus.UserCanceled)
        {
            // Launch app-specific flow to handle the scenario 
            return null;
        }
    }
    else if (openKeyResult.Status == KeyCredentialStatus.NotFound)
    {
        // PIN reset has occurred somewhere else and key is lost.
        // Repeat key registration
        return null;
    }
    else
    {
        // Show custom UI because unknown error has happened.
        return null;
    }
}
```

適切なチャレンジ – 応答メカニズムの実装は、このドキュメントでは説明しません。ただし、このトピックでは、リプレイ攻撃や man-in-the-middle 攻撃などを回避する安全なメカニズムを作成するために注意が必要です。

## <a name="35-enrolling-another-device"></a>3.5 別のデバイスの登録


今日では、ユーザーが所有している複数のデバイスに同じアプリがインストールされていることが一般的になっています。 複数のデバイスで Windows Hello を使うとどのように機能するのでしょうか。

Windows Hello を使うと、各デバイスで、固有の秘密キーと公開キーのセットが作成されます。 これは、ユーザーが複数のデバイスを使えるようにするには、バックエンドでこのユーザーの複数の公開キーを保存できる必要があることを意味します。 テーブル構造の例としては、セクション 2.1 のデータベースの図をご覧ください。

別のデバイスの登録は、ユーザーを初めて登録する方法とほとんど同じです。 デバイスを登録するユーザーが、登録を求めている本人であるかどうかを確認する必要がまだあります。 この確認は、現在使っている 2 要素認証メカニズムに基づいて行うことができます。 セキュリティで保護された手段を利用してこの確認を行う方法はいくつかありますが、 どの方法を採用するかは、シナリオによって異なります。

たとえば、ログイン名とパスワードによる認証方法を使っている場合は、その方法を利用してユーザーを認証し、SMS やメールなどの検証方法の 1 つを使用するようユーザーに求めることができます。 ログイン名とパスワードを使っていない場合は、既に登録されているいずれかのデバイスを使い、そのデバイス上のアプリに通知を送信することもできます  その一例として MSA 認証アプリがあります。 つまり、一般的な 2FA メカニズムを使って、ユーザーの追加のデバイスを登録する必要があります。

新しいデバイスを登録するコードは、(アプリ内から) ユーザーを初めて登録する場合とまったく同じになります。

```cs
var keyCreationResult = await KeyCredentialManager.RequestCreateAsync(
    AccountId, KeyCredentialCreationOption.ReplaceExisting);
```

登録されているデバイスをユーザーが簡単に認識できるようにするために、登録の一環として、デバイス名や他の識別子を送信することができます。 これは、たとえばサービスをバックエンドに実装する場合、デバイスを紛失したためにユーザーがデバイスの登録を解除するときに役立ちます。

## <a name="36-using-multiple-accounts-in-your-app"></a>3.6 アプリでの複数のアカウントの使用


1 つのアカウントに対して複数のデバイスをサポートすることに加え、1 つのアプリで複数のアカウントをサポートすることも一般的です。 たとえば、1 つのアプリから複数の Twitter アカウントに接続している場合があります。 Windows Hello を利用すれば、キーのペアを複数作成し、アプリ内で複数のアカウントをサポートできます。

そのための方法の 1 つは、前の章で説明したユーザー名や一意の識別子を分離ストレージに保存する方法です。 したがって、新しいアカウントを作成するたびに、アカウント ID を分離ストレージに保存します。

アプリの UI では、ユーザーが、事前に作成済みのアカウントのいずれかを選べるか、または新しいアカウントでサインアップできるようにします。 新しいアカウントを作成するフローは、前に説明したフローと同じになります。 アカウントを選ぶ場合は、保存されているアカウントの一覧を画面に表示する方法が課題となります。 ユーザーがアカウントを選ぶと、そのアカウント ID で、ユーザーはアプリにログオンします。

```cs
var openKeyResult = await KeyCredentialManager.OpenAsync(AccountId);
```

フローの他の部分は、前に説明したフローと同じになります。 もちろん、これらすべてのアカウントは同じ PIN または生体認証ジェスチャによって保護されます。このシナリオでは、これらは、同じ Windows アカウントを用いて 1 つのデバイス上で使われているためです。

## <a name="4-migrating-an-existing-system-to-windows-hello"></a>4 既存のシステムを Windows Hello に移行する


この短いセクションでは、ユニバーサル Windows プラットフォーム アプリが既にあり、ユーザー名とハッシュされたパスワードが保存されているデータベースを使うバックエンド システムがある場合を扱います。 これらのアプリでは、起動時にユーザーから資格情報を収集し、バックエンド システムが認証チャレンジを返すときに、これらの資格情報を使います。

ここでは、Windows Hello が動作するためには、何を変更し、何を置き換える必要があるかを説明します。

ほとんどの手法については、これまでの章で既に説明しました。 既存のシステムに Windows Hello を追加する場合、コード上の登録と認証の部分にいくつかの異なるフローを追加する必要があります。

1 つのアプローチとして、いつアップグレードするかをユーザーが選べるようにする方法があります。 ユーザーがアプリにログオンし、アプリと OS が Windows Hello をサポートできることを検出した後で、この最新かつセキュリティ保護されたシステムを使うために、資格情報をアップグレードするかどうかをユーザーに問い合わせる方法があります。 次のコードを利用して、ユーザーが Windows Hello を使うことができるかどうかを確認できます。

```cs
var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
```

UI は次のようになります。

![Windows Hello の UI](images/passport-ui.png)

ユーザーが Windows Hello を使うことにした場合、前に説明した [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成します。 バックエンドの登録サーバーでは、公開キーとオプションの構成証明ステートメントをデータベースに追加します。 ユーザーはユーザー名とパスワードで既に認証されているため、サーバーではこの新しい資格情報をデータベース内の現在のユーザー情報にリンクできます。 データベース モデルは、前に説明した例と同じである場合があります。

アプリは、ユーザーの [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成できた場合、アプリを再起動したときにユーザーが一覧からアカウントを選ぶことができるように、ユーザー ID を分離ストレージに保存します。 これ以降、フローはこれまでの章で説明した例とまったく同じものとなります。

Windows Hello の完全なシナリオへ移行する最後の手順では、アプリでログオン名とパスワードのオプションを無効にし、保存されているハッシュ済みのパスワードをデータベースから削除します。

## <a name="5-summary"></a>5 まとめ


Windows 10 には、簡単に実現できる、高いレベルのセキュリティが導入されています。 Windows Hello によって、ユーザーを認識する新しい生体認証サインイン システムが提供されます。また、Windows Hello を使うことで、正しい ID を意図的に回避するような操作をアクティブに阻止することができます。 この結果、キーと証明書に関する複数の層を提供できます。これらの層は、トラステッド プラットフォーム モジュールの外部で公開されたり、使われたりすることは決してありません。 また、より詳細なセキュリティ レイヤーを、オプションである構成証明識別キーや証明書の利用時に使うことができます。

これらのテクノロジの設計や展開を行うときに開発者がこのガイダンスを利用すると、セキュリティ保護された認証を Windows 10 のロールアウトに簡単に追加して、アプリやバックエンド サービスを保護することができます。 必要なコードは最小限に抑えられ、簡単に理解することができます。 難しい処理は、Windows 10 が実行します。

柔軟な実装オプションによって、Windows Hello は、既にある認証システムに合わせて、置き換えを行ったり、動作したりすることができます。 展開エクスペリエンスは簡単で経済的に行うことができます。 Windows 10 のセキュリティを展開する際に、追加のインフラストラクチャは必要ありません。 Microsoft Hello はオペレーティング システムに組み込まれており、Windows 10 によって、現代の開発者が直面する認証の問題に対して安全性が最も高いソリューションが提供されます。

任務完了! これでインターネットがより安全な場所になりました!

## <a name="6-resources"></a>6 リソース


### <a name="61-articles-and-sample-code"></a>6.1 記事とサンプル コード

-   [Windows Hello の概要](http://windows.microsoft.com/windows-10/getstarted-what-is-hello)
-   [Windows Hello の実装の詳細](https://msdn.microsoft.com/library/mt589441)
-   [GitHub の Windows Hello コード サンプル](http://go.microsoft.com/fwlink/?LinkID=717812)

### <a name="62-terminology"></a>6.2 用語

|                     |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|---------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AIK                 | 構成証明識別キー (AIK) を使って、暗号証明 (TPM キーの構成証明) などを提供します。そのためには、移行不可能なキーのプロパティに署名し、そのプロパティと署名を検証のために証明書利用者に提供します。 このプロパティへの署名は、"構成証明ステートメント" と呼ばれます。 署名は AIK 秘密キー (このキーを作成した TPM でのみ利用できます) を使って作成されるため、証明書利用者は、証明されたキーが実際に移行不可能であり、TPM の外部で利用できないことを信頼することができます。 |
| AIK 証明書     | AIK 証明書は、TPM 内に AIK が存在すること証明するために使われます。 また、特定の TPM の AIK によって認証された他のキーを証明する場合にも使われます。                                                                                                                                                                                                                                                                                                                                              |
| IDP                 | IDP とは ID プロバイダーを表します。 例として、Microsoft アカウント用に Microsoft が作成した IDP があります。 アプリケーションで MSA を使った認証を行うたびに、MSA IDP を呼び出すことができます。                                                                                                                                                                                                                                                                                                                                        |
| PKI                 | 公開キー基盤 (PKI) は、一般的に、組織によってホストされ、キーの作成やキーの失効などを行う環境を示す際に使われる用語です。                                                                                                                                                                                                                                                                                                                                                           |
| TPM                 | トラステッド プラットフォーム モジュール (TPM) を使って、暗号化された公開/秘密キーのペアを作成できます。作成された秘密キーは、TPM の外部で公開されたり、使われたりすることは決してありません (つまり、キーは移行できません)。                                                                                                                                                                                                                                                                                                               |
| TPM キーの構成証明 | キーが TPM にバインドされていることを暗号で証明するプロトコルです。 この種類の構成証明を使うことで、特定の暗号化操作が特定のコンピューターの TPM で行われたことを保証できます。                                                                                                                                                                                                                                                                                                                       |

 

## <a name="related-topics"></a>関連トピック

* [Windows Hello ログイン アプリ](microsoft-passport-login.md)
* [Windows Hello ログイン サービス](microsoft-passport-login-auth-service.md)