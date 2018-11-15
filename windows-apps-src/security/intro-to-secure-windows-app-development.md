---
title: 安全な Windows アプリの開発について
description: この概要記事は、アプリの設計者と開発者が適切なセキュリティで保護されたユニバーサル Windows プラットフォーム (UWP) アプリの作成を加速するさまざまな windows 10 プラットフォーム機能を理解します。
ms.assetid: 6AFF9D09-77C2-4811-BB1A-BBF4A6FF511E
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: adc74410a5012dbc59cc995e80ee5fa729f0176f
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6664095"
---
# <a name="intro-to-secure-windows-app-development"></a>安全な Windows アプリの開発について




この概要記事は、アプリの設計者と開発者が適切なセキュリティで保護されたユニバーサル Windows プラットフォーム (UWP) アプリの作成を加速するさまざまな windows 10 プラットフォーム機能を理解します。 ここでは、認証、移動中データ、および保存データの各段階で利用可能な、Windows のセキュリティ機能に使用方法について詳しく説明します。 各章にあるその他のリソースを確認すれば、各トピックについてさらに詳しい情報を得ることができます。

## <a name="1-introduction"></a>1 はじめに


セキュリティで保護されたアプリの開発は、容易な作業ではありません。 モバイル アプリ、ソーシャル アプリ、クラウド アプリ、および複雑なエンタープライズ アプリが急速に進歩する現在では、アプリがこれまでよりも早く利用可能になり、更新されることをユーザーは期待しています。 また、ユーザーはさまざまな種類のデバイスを使用するので、アプリ エクスペリエンスの実現はますます複雑になっています。 Windows 10 ユニバーサル Windows プラットフォーム (UWP) 用にビルドする場合、含めることが可能なデバイス リストには、デスクトップ、ノート、タブレット、モバイル デバイスなどの従来のデバイスの他に、モノのインターネット、Xbox One、Microsoft Surface Hub、HoloLens にわたる新しいデバイスがあり、今後も増加します。 開発者は、関連するすべてのプラットフォームまたはデバイスで、アプリが安全に通信し、データを保存できるようにする必要があります。

Windows 10 のセキュリティ機能を利用する利点を次にいくつか示します。

-   セキュリティのコンポーネントやテクノロジ用の一貫性のある API を使用することにより、Windows 10 をサポートするすべてのデバイスで、標準的なセキュリティを実現できます。
-   これらのセキュリティ シナリオに対応するカスタム コードを実装する場合よりも、作成、テスト、保守の対象となるコードの量は少なくなります。
-   オペレーティング システムを使用して、アプリのリソースと、ローカルまたはリモートのシステム リソースにアプリがアクセスする方法を制御するため、アプリの安定性と安全性が高まります。

認証時に、特定のサービスへのアクセスを要求するユーザーの ID が検証されます。 Windows Hello は、Windows アプリでより安全な認証メカニズムを作成するのに役立つ Windows 10 のコンポーネントです。 これらコンポーネントを利用すると、暗証番号 (PIN)、またはユーザーの指紋、顔、虹彩などの生体認証を使って、アプリ用の多要素認証を実装できます。

移動中データとは、接続とそれを通してやり取りされるメッセージを表します。 これの例は、Web サービスを使用したリモート サーバーからのデータ取得です。 Secure Sockets Layer (SSL) と Secure Hypertext Transfer Protocol (HTTPS) を使うことで、接続の安全性が確保されます。 仲介するものがこれらのメッセージにアクセスするのを防ぎ、または承認されていないアプリが Web サービスと通信するのを防ぐことが、移動中データを保護するうえでの鍵となります。

最後に、保存データとは、メモリや記憶域メディアに存在するデータのことです。 Windows 10 では、アプリ間の承認されていないデータ アクセスを防止するアプリ モデルがあり、デバイス上のデータの安全性をさらに高める暗号化 API が提供されています。 資格情報保管ボックスと呼ばれる機能を使用すると、デバイスにユーザー資格情報を安全に保存することができ、オペレーティング システムが他のアプリからのアクセスを防止します。

## <a name="2-authentication-factors"></a>2 認証要素


データを保護するために、データへのアクセスを要求する人は、特定され、要求するデータ リソースへのアクセスが承認される必要があります。 ユーザーを特定するプロセスは認証と呼ばれ、リソースへのアクセス特権を判別することは承認と呼ばれます。 これらは密接な関係のある操作であり、ユーザーには区別できないかもしれません。 操作には、比較的単純な操作から複雑な操作まであります。これは、さまざまな要因 (データが 1 台のサーバーに存在するか、多数のシステム間で分散しているかなど) によって決まります。 認証サービスおよび承認サービスを提供するサーバーは、ID プロバイダーと呼ばれます。

特定のサービスやアプリを使ってユーザー自身を認証するには、ユーザーは、自分が知っている情報、自分が持っているもの、自分の特徴からなる資格情報を使用します。 これらはそれぞれ認証要素と呼ばれます。

-   **ユーザーが知っている情報**とは、通常パスワードですが、暗証番号 (PIN) や "秘密" の質問と答えのペアの場合もあります。
-   **ユーザーが持っているもの**とは、ほとんどの場合、ハードウェアのメモリ デバイス (ユーザーに固有の認証データを含んでいる USB スティックなど) です。
-   **ユーザーの特徴**とは、多くの場合、指紋を意味しますが、ユーザーの音声、顔、眼球 (目) の特性、または動作パターンなどの要素も一般的になってきています。 これらの測定値は、データとして保存されると生体認証と呼ばれます。

ユーザーが作成したパスワードは認証要素ですが、パスワードだけでは不十分な場合があります。これは、パスワードを知っている人物が、パスワードの所有者であるユーザーになりすますことができるためです。 スマート カードではより高いレベルのセキュリティを実現できますが、盗難、紛失、置き忘れなどの可能性があります。 指紋や眼球のスキャンによってユーザーを認証するシステムでは、最高かつ最も便利なレベルのセキュリティを実現できる可能性があります。ただし、高額で特別なハードウェアが必要になります (たとえば、顔認証用の Intel RealSense カメラなど)。このようなハードウェアは、すべてのユーザーが利用できるわけではありません。

システムで使う認証方法を設計することは、データ セキュリティにおいて複雑かつ重要な要素であるといえます。 一般的に、認証で使う要素の数が多いほど、システムのセキュリティは高くなります。 同時に、認証は使いやすいものであることが必要です。 通常、ユーザーは 1 日に何度もログインするため、このプロセスは迅速に行われる必要があります。 認証の種類を選ぶときは、セキュリティと使いやすさのバランスを取る必要があります。単一要素認証は、セキュリティが最も低いレベルになりますが、最も使いやすい方法です。多要素認証では、認証要素が増えるに従って、セキュリティのレベルは高くなりますが、複雑になっていきます。

## <a name="21-single-factor-authentication"></a>2.1 単一要素認証


この形式の認証は、1 つのユーザーの資格情報に基づいています。 通常、これはパスワードですが、暗証番号 (PIN) の場合もあります。

単一要素認証のプロセスを次に示します。

-   ユーザーは、ユーザー名とパスワードを ID プロバイダーに提供します。 ID プロバイダーとは、ユーザーの身元を確認するサーバー プロセスです。
-   ID プロバイダーでは、ユーザー名とパスワードがシステムに保存されているものと同じであるかどうかを確認します。 ほとんどの場合、パスワードは暗号化され、セキュリティを高めて他の人が読み取れないようにします。
-   ID プロバイダーは、認証が成功したかどうかを示す認証状態を返します。
-   成功した場合、データ交換が開始されます。 失敗した場合、ユーザーは再認証が必要です。

![単一要素認証](images/secure-sfa.png)

今日、この認証方法はさまざまなサービスで最も一般的に使われている方法です。 この認証形式を唯一の認証方法として使った場合、これは最もセキュリティ レベルの低い認証形式になります。 パスワードの複雑さの要件、"秘密の質問"、定期的なパスワードの変更によって、パスワードを使うセキュリティを高めることはできますが、ユーザーの負担が増え、ハッカーに対する効果的な抑止力とはなりません。

パスワードの課題は、複数の要素を備えるシステムよりも容易に推測されてしまうということです。 小さなオンライン ショップから、ユーザー アカウントとハッシュされたパスワードのデータベースを盗めば、使用されているパスワードを他の Web サイトで使えます。 複雑なパスワードは覚えにくいため、ユーザーはアカウントを常に再利用する傾向があります。 IT 部門では、パスワード管理には、リセット メカニズムを提供、パスワードを頻繁に更新することを要求、そして安全な方法でパスワードを保存するという複雑さも伴います。

欠点はありますが、単一要素認証ではユーザーが資格情報を制御できます。 資格情報の作成や変更はユーザーが行い、認証プロセスで必要となるのはキーボードだけです。 これが、多要素認証にはない単一要素認証の主な特徴です。

## <a name="211-web-authentication-broker"></a>2.1.1 Web 認証ブローカー


既に説明したように、IT 部門におけるパスワード認証の課題の 1 つは、ユーザー名/パスワードの基盤やリセット メカニズムなどの管理というオーバーヘッドが加わる点です。一般的になってきているオプションは、認証のオープン スタンダードである OAuth による認証を提供するサード パーティの ID プロバイダーを利用することです。

OAuth を使用すると、IT 部門は、ユーザー名とパスワードのデータベース、パスワードのリセット機能などの維持という複雑さを、Facebook、Twitter、Microsoft などのサード パーティの ID プロバイダーに効果的に "委託" することができます。

ユーザーがこれらのプラットフォームで自身の ID を完全に制御しますが、アプリはプロバイダーにトークンを要求し、ユーザーが認証された後、ユーザーの同意を得て、それを認証されたユーザーの承認に使用することができます。

Windows 10 の Web 認証ブローカーは、アプリが認証プロトコルと承認プロトコル (OAuth や OpenID など) を使うための API のセットとインフラストラクチャを提供します。 アプリでは、[**WebAuthenticationBroker**](https://msdn.microsoft.com/library/windows/apps/br227025) API を使って認証操作を開始できます。その結果として、[**WebAuthenticationResult**](https://msdn.microsoft.com/library/windows/apps/br227038) が返されます。 通信フローの概要を次の図に示します。

![WAB ワークフロー](images/secure-wab.png)

アプリはブローカーとして機能します。アプリでは、[**WebView**](https://msdn.microsoft.com/library/windows/apps/br227702) を利用して ID プロバイダーを使い、認証を開始します。 ID プロバイダーがユーザーを認証すると、トークンがアプリに返されます。このトークンを使って、ID プロバイダーに対してユーザーに関する情報を要求することができます。 セキュリティ対策として、アプリが ID プロバイダーの認証プロセスを仲介する前に、アプリを ID プロバイダーに登録する必要があります。 この登録手順は、プロバイダーごとに異なります。

プロバイダーと通信するための [**WebAuthenticationBroker**](https://msdn.microsoft.com/library/windows/apps/br227025) API の呼び出しに使われる一般的なワークフローを次に示します。

-   ID プロバイダーに送信される要求文字列を作成します。 文字列の数と各文字列に含まれる情報は、Web サービスごとに異なりますが、通常は、URI 文字列が 2 つあり、それぞれに URL が含まれています。1 つは認証要求の送信先となる URL で、もう 1 つは認証の完了後にユーザーがリダイレクトされる URL です。
-   要求文字列を渡して [**WebAuthenticationBroker.AuthenticateAsync**](https://msdn.microsoft.com/library/windows/apps/br212066) を呼び出し、ID プロバイダーからの応答を待ちます。
-   [**WebAuthenticationResult.ResponseStatus**](https://msdn.microsoft.com/library/windows/apps/br227041) を呼び出し、応答を受け取ったときの状態を取得します。
-   通信が成功したら、ID プロバイダーから返された応答文字列を処理します。 通信が失敗した場合は、エラーを処理します。

通信が成功したら、ID プロバイダーから返された応答文字列を処理します。 通信が失敗した場合は、エラーを処理します。

このプロセスに関するサンプルの C# コードを次に示します。 詳しい情報やチュートリアルについては、「[WebAuthenticationBroker](web-authentication-broker.md)」をご覧ください。 完全なコード サンプルについては、「[GitHub の WebAuthenticationBroker サンプル](http://go.microsoft.com/fwlink/p/?LinkId=620622)」をご覧ください。

```cs
string startURL = "https://<providerendpoint>?client_id=<clientid>";
string endURL = "http://<AppEndPoint>";

var startURI = new System.Uri(startURL);
var endURI = new System.Uri(endURL);

try
{
    WebAuthenticationResult webAuthenticationResult = 
        await WebAuthenticationBroker.AuthenticateAsync( 
            WebAuthenticationOptions.None, startURI, endURI);

    switch (webAuthenticationResult.ResponseStatus)
    {
        case WebAuthenticationStatus.Success:
            // Successful authentication. 
            break;
        case WebAuthenticationStatus.ErrorHttp:
            // HTTP error. 
            break;
        default:
            // Other error.
        break;
    }
}
catch (Exception ex)
{
    // Authentication failed. Handle parameter, SSL/TLS, and
    // Network Unavailable errors here. 
}
```

## <a name="22-multi-factor-authentication"></a>2.2 多要素認証


多要素認証では、複数の認証要素を使います。 通常、パスワードなどの "知っている情報" は、携帯電話やスマート カードなどの "持っているもの" に結合されます。 攻撃者がユーザーのパスワードを検出しても、デバイスやカードを使わないと、アカウントにアクセスすることはできません。 また、攻撃者がデバイスやカードだけを手に入れても、パスワードがなければ、攻撃者はこれらを使うことはできません。 したがって、多要素認証は単一要素認証よりもセキュリティが高くなりますが、複雑にもなります。

多要素認証を使うサービスでは、多くの場合、サービスに 2 番目の資格情報を提供する手段をユーザーが選択できます。 この種類の認証の例として、SMS を利用して確認コードをユーザーの携帯電話に送信するという一般的に使われるプロセスを挙げることができます。

-   ユーザーは、ユーザー名とパスワードを ID プロバイダーに提供します。
-   ID プロバイダーでは、ユーザー名とパスワードを単一要素認証の場合と同様に確認し、その後で、システムに保存されているユーザーの携帯電話番号を検索します。
-   サーバーは、生成された確認コードを含んでいる SMS メッセージをユーザーの携帯電話に送信します。
-   ユーザーは、ユーザーに提示された形式で確認コードを ID プロバイダーに提供します。
-   ID プロバイダーは、両方の資格情報の認証が成功したかどうかを示す認証状態を返します。
-   成功した場合、データ交換が開始されます。 失敗した場合、ユーザーは再認証が必要です。

![2 要素認証](images/secure-tfa.png)

以上の説明でわかるように、このプロセスは、2 番目のユーザーの資格情報がユーザーによって作成または提供されるのではなく、ユーザーに送られるという点が、単一要素認証とは異なります。 そのため、ユーザーは、必要な資格情報を完全に制御することはできません。 このことは、スマート カードを 2 番目の資格情報として使う場合にも該当します。2 番目の資格情報の作成とユーザーへの提供は、組織が管理します。

## <a name="221-azure-active-directory"></a>2.2.1 Azure Active Directory


Azure Active Directory (Azure AD) は、クラウド ベースの ID およびアクセスの管理サービスであり、単一要素認証や多要素認証の ID プロバイダーとして使うことができます。 Azure AD 認証は、確認コードの有無にかかわらず使うことができます。

Azure AD では単一要素認証を実装することもできますが、通常、企業では最もセキュリティ レベルの高い多要素認証を必要とします。 多要素認証の構成の場合、Azure AD アカウントを使ったユーザー認証では、確認コードを SMS メッセージとして携帯電話に送信したり、Azure Authenticator モバイル アプリに送信したりすることができます。

さらに、Azure AD は OAuth プロバイダーとして使用でき、さまざまなプラットフォームのアプリに対する認証および承認メカニズムを標準ユーザーに提供できます。 詳しくは、「[Azure Active Directory](https://azure.microsoft.com/services/active-directory/)」および「[Azure の多要素認証](https://azure.microsoft.com/services/multi-factor-authentication/)」をご覧ください。

## <a name="24-windows-hello"></a>2.4 Windows Hello


Windows 10 では、便利な多要素認証メカニズムがオペレーティング システムに組み込まれています。 Windows Hello は、Windows 10 に組み込まれた新しい生体認証サインイン システムです。 Windows Hello はオペレーティング システムに直接組み込まれているため、顔または指紋を識別して、ユーザーのデバイスのロックを解除できます。 Windows のセキュリティ保護された資格情報ストアは、デバイス上の生体認証データを保護します。

Windows Hello は、個々のユーザーを認識するための堅牢な方法をデバイスに提供します。これにより、ユーザーと要求されたサービス (またはデータ項目) との間のパスの最初の部分が処理されます。 デバイスがユーザーを認識しても、要求されたリソースへのアクセス権を与えるかどうかを決める前に、ユーザーをまだ認証する必要があります。 Windows Hello は、Windows に完全に統合された強固な 2 要素認証 (2FA) も行い、再利用可能なパスワードを、特定のデバイスと生体認証ジェスチャまたは PIN の組み合わせに置き換えます。 PIN は、Microsoft アカウントの登録時にユーザーが指定します。

Windows Hello は、従来の 2FA システムの単なる代替機能ではありません。 概念的にはスマート カードと似ています。文字列比較ではなく、暗号化プリミティブを使用して認証が行われます。ユーザーのキー マテリアルは、が改ざんされにくいハードウェア内にセキュリティ保護されています。 Microsoft Hello では、スマート カード展開に必要なインフラストラクチャ コンポーネントも追加する必要はありません。 具体的には、現在、公開キー基盤 (PKI) を所持していない場合は、証明書を管理するための PKI は必要ありません。 Windows Hello では、スマート カードの主な利点である、仮想スマート カードの展開の柔軟性と物理スマート カードの堅牢なセキュリティを組み合わせ、それぞれの欠点を排除しています。

ユーザーがデバイスを使って認証する前に、デバイスを Windows Hello に登録する必要があります。 Windows Hello は非対称 (公開/秘密キー) の暗号化を使用しています。この暗号化では、相手が秘密キーを使って暗号化解除できるデータを、公開キーを使用して暗号化します。 Windows Hello では、公開/秘密キーの組のセットを作成し、デバイスのトラステッド プラットフォーム モジュール (TPM) チップに秘密キーを書き込みます。 デバイスが登録されると、UWP アプリは、システム API を呼び出してユーザーの公開キーを取得することができ、このキーを使ってユーザーをサーバーに登録することができます。

アプリの登録ワークフローは、次のようになります。

![Windows Hello の登録](images/secure-passport.png)

収集する登録情報には、この単純なシナリオよりも多くの識別情報が含まれる場合があります。 たとえば、アプリが、バンキング用などのセキュリティで保護されたサービスにアクセスする場合、サインアップ プロセスの一部として ID やその他の項目の証明を要求する必要があります。 すべての条件が満たされると、ユーザーの公開キーがバックエンドに保存され、次回ユーザーがサービスを利用するときの検証でこの公開キーが使われます。

Windows Hello について詳しくは、「[Windows Hello ガイド](https://msdn.microsoft.com/library/mt589441)」および「[Windows Hello 開発者向けガイド](microsoft-passport.md)」をご覧ください。

## <a name="3-data-in-flight-security-methods"></a>3 移動中データに関するセキュリティ保護の方法


移動中データに関するセキュリティ保護の方法は、ネットワークに接続されているデバイス間でやり取りされるデータに適用されます。 データは、プライベートな社内イントラネットの高度なセキュリティ環境にあるシステムの間で転送される場合と、セキュリティで保護されていない Web 環境にあるクライアントと Web サービスの間で転送される場合があります。 Windows 10 アプリでは、ネットワーキング API を利用して SSL などの標準をサポートしており、Azure API 管理などのテクノロジとも連携します。これにより、開発者はアプリで適切なレベルのセキュリティを確保することができます。

## <a name="31-remote-system-authentication"></a>3.1 リモート システムの認証


リモート コンピューター システムとの通信が発生する一般的なシナリオは、2 つあります。

-   ローカル サーバーで、直接接続を経由してユーザーを認証します。 たとえば、サーバーとクライアントが社内イントラネット上に存在する場合などです。
-   Web サービスとの通信はインターネット経由で行われます。

Web サービス通信では、データはもはやセキュリティで保護されたネットワークだけに含まれるのではなく、悪意のある攻撃者が検索してデータを傍受する可能性も高くなるので、Web サービス通信のセキュリティ要件は、直接接続のシナリオの場合よりも高くなります。 さまざまな種類のデバイスがサービスにアクセスするため、たとえば WCF サービスではなく RESTful サービスとしてデバイスがビルドされる可能性があります。このため、認証およびサービスへの承認からも新しい課題が生まれます。 セキュリティで保護されたリモート システム通信の 2 つの要件について説明します。

第 1 の要件は、メッセージの機密性です。クライアントと Web サービス間で渡される情報 (ユーザーの ID やその他の個人情報など) は、転送中に第三者が読み取ることができない情報であることが必要です。 通常これは、メッセージ送信に使われる接続を暗号化したり、メッセージ自体を暗号化したりすることによって実現されます。 秘密キー/公開キーの暗号化では、公開キーはだれでも利用でき、公開キーを使って、特定の受信者に送信されるメッセージを暗号化します。 秘密キーは受信者のみが保持しており、秘密キーを使って、メッセージの暗号化を解除します。

第 2 の要件は、メッセージの整合性です。クライアントと Web サービスは、受信したメッセージが送信側によって送られたものであること、およびメッセージが転送中に改変されていないことを確認する必要があります。 これは、デジタル署名を使ったメッセージへの署名と、証明書の認証の利用によって実現されます。

## <a name="32-ssl-connections"></a>3.2 SSL 接続


セキュリティで保護された接続を確立し、維持するために、Web サービスでは、Secure Hypertext Transfer Protocol (HTTPS) によってサポートされている Secure Sockets Layer (SSL) を使うことができます。 SSL では、公開キーの暗号化、およびサーバーの証明書をサポートすることによって、メッセージの機密性と整合性が実現されます。 トランスポート層セキュリティ (TLS) は SSL に取って代わるものですが、TLS は非公式に SSL と呼ばれることがよくあります。

クライアントがサーバーにあるリソースへのアクセスを要求すると、SSL はサーバーとのネゴシエーション プロセスを開始します。 これは、SSL ハンドシェイクと呼ばれます。 暗号化レベル、公開暗号化キーと秘密暗号化キーのセット、およびクライアントとサーバーの証明書に含まれている ID 情報が、SSL 接続が行われている間のすべての通信における基盤として認識されます。 このとき、サーバーは、認証されるクライアントを要求する場合があります。 接続が確立されると、接続が閉じられるまで、すべてのメッセージがネゴシエートされた公開キーで暗号化されます。

## <a name="321-ssl-pinning"></a>3.2.1 SSL のピン留め


SSL では、暗号化と証明書を使ってメッセージの機密性を実現できますが、クライアントが通信しているサーバーが正しいサーバーであることを確認するための処理は行いません。 サーバーの動作は、承認されていない第三者によって模倣され、クライアントが転送した重要なデータが傍受される可能性があります。 これを防ぐためには、SSL のピン留めと呼ばれる手法を使って、サーバー上の証明書がクライアントで想定され、信頼されている証明書であることを確認します。

アプリに SSL のピン留めを実装する方法はいくつかあります。それぞれの方法に長所と短所があります。 最も簡単な方法は、アプリのパッケージ マニフェストで証明書の宣言を利用する方法です。 この宣言によって、アプリ パッケージはデジタル証明書をインストールし、それらの証明書に排他的信頼を指定することができます。 その結果、アプリと、対応する証明書が証明書チェーンにあるサーバーとの間だけで SSL 接続が許可されます。 このメカニズムにより、信頼できる公共の証明機関に対するサード パーティの依存関係は不要になるので、セキュリティで保護された自己署名証明書の使用も可能になります。

![SSL マニフェスト](images/secure-ssl-manifest.png)

検証ロジックをより細かく制御したい場合は、API を利用して、HTTPS 要求に応じてサーバーから返される証明書を検証できます。 この方法では、要求の送信と応答の確認が必要になることに注意してください。重要な情報を要求に含めて実際に送信する前に、この方法を検証方法として追加してください。

次の C# コードは、この SSL のピン留め方法を示しています。 **ValidateSSLRoot** メソッドでは、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラスを使って HTTP 要求を実行します。 クライアントが応答を送信した後で、クライアントは [**RequestMessage.TransportInformation.ServerIntermediateCertificates**](https://msdn.microsoft.com/library/windows/apps/dn279681) コレクションを使って、サーバーから返された証明書を調べます。 その後で、クライアントは含まれている拇印を使って、証明書チェーン全体を検証することができます。 この方法では、サーバー証明書の有効期限が切れて新しい証明書に置き換わると、証明書の拇印がアプリで更新される必要があります。

```cs
private async Task ValidateSSLRoot()
{
    // Send a get request to Bing
    var httpClient = new HttpClient();
    var bingUri = new Uri("https://www.bing.com");
    HttpResponseMessage response = 
        await httpClient.GetAsync(bingUri);

    // Get the list of certificates that were used to
    // validate the server's identity
    IReadOnlyList<Certificate> serverCertificates = response.RequestMessage.TransportInformation.ServerIntermediateCertificates;
  
    // Perform validation
    if (!ValidateCertificates(serverCertificates))
    {
        // Close connection as chain is not valid
        return;
    }
    // Validation passed, continue with connection to service
}

private bool ValidateCertificates(IReadOnlyList<Certificate> certs)
{
    // In this example, we iterate through the certificates
    // and check that the chain contains
    // one specific certificate we are expecting
    foreach (var cert in certs)
    {
        byte[] thumbprint = cert.GetHashValue();

        // Check if the thumbprint matches whatever you 
        // are expecting
        var expected = new byte[] { 212, 222, 32, 208, 94, 102, 
            252, 83, 254, 26, 80, 136, 44, 120, 219, 40, 82, 202, 
            228, 116 };

        // ThumbprintMatches does the byte[] comparison 
        if (ThumbprintMatches(thumbprint, expected))
        {
            return true;
        }
    }
    return false;
}
```

## <a name="33-publishing-and-securing-access-to-rest-apis"></a>3.3 REST API の公開と REST API へのアクセスの保護


Web サービスへのアクセスの承認を確実に行うためには、API の呼び出しが行われるたびに認証する必要があります。 Web サービスが Web 経由で公開されている場合、パフォーマンスとスケールを制御できるようにすることも考慮する必要があります。 Azure API Management は、API を Web に公開する場合に役立つサービスであり、3 つのレベルで機能を提供します。

API の**発行者/管理者**は、Azure API Management の発行者ポータルを使って、簡単に API を構成できます。 ここでは、API のセットを作成でき、API へのアクセスを管理して、だれがどの API へアクセスできるかを制御できます。

**開発者**は、これらの API にアクセスする必要がある場合、開発者ポータルを使って要求できます。開発者ポータルは、直ちにアクセスを提供するか、発行者/管理者による承認を要求します。 開発者は、開発者ポータルで API ドキュメントとサンプル コードを参照し、Web サービスで提供されている API を迅速に採用することができます。

これらの開発者が作成した**アプリ**は、Azure API Management に用意されているプロキシを経由して API にアクセスします。 プロキシでは、不明瞭レイヤーによって発行者/管理者のサーバーにある API の実際のエンドポイントが隠蔽され、また API 変換などのロジックを追加して、API の呼び出しが別の API にリダイレクトされる場合に、公開されている API が一貫性を保つようにできます。 また、IP フィルタリングを使って、特定の IP ドメインやドメインのセットで発生した API 呼び出しをブロックすることもできます。 また、Azure App 管理では、各 API 呼び出しの認証と承認のために公開キーのセット (API キーと呼ばれます) を使って、Web サービスのセキュリティ保護を維持します。 認証が失敗した場合、API へのアクセスや API がサポートする機能へのアクセスがブロックされます。

Azure App 管理では、Web サービスのパフォーマンスを最適化するために、サービスでの API 呼び出しの回数を減らすこともできます (この手続きはスロットルと呼ばれます)。 詳しくは、「[Azure API 管理](https://azure.microsoft.com/services/api-management/)」および「[AzureCon 2015 の Azure API 管理](https://channel9.msdn.com/events/Microsoft-Azure/AzureCon-2015/ACON313)」をご覧ください。

## <a name="4-data-at-rest-security-methods"></a>4 保存データに関するセキュリティ保護の方法


データがデバイスに到着すると、そのデータは "保存データ" と呼ばれます。 このデータは、承認されていないユーザーやアプリからのアクセスを防ぐために、セキュリティ保護の方法に従ってデバイスに保存する必要があります。 Windows 10 のアプリ モデルでは、アプリで保存されたデータはそのアプリによってのみアクセスできるようにして、必要な場合はデータを共有するための API を提供するように、さまざまな操作を行います。 また、追加の API を利用して、データを暗号化し、資格情報を安全に保存することができます。

## <a name="41-windows-app-model"></a>4.1 Windows アプリ モデル


従来、Windows はアプリの定義を備えていませんでした。 一般的には、実行可能ファイル (.exe) がアプリの定義として扱われていましたが、インストール、状態の記憶、実行の長さ、バージョン管理、OS の統合、およびアプリ間通信は、定義には含まれていませんでした。 ユニバーサル Windows プラットフォーム モデルでは、インストール、ランタイム環境、リソース管理、更新プログラム、データ モデル、およびアンインストールを含めるように、アプリ モデルを定義します。

Windows 10 アプリは、既定では (追加の特権を要求したり、ユーザーによって付与される) 特権を制限があることを意味します、コンテナー内で実行します。 たとえば、アプリがシステム上のファイルにアクセスする場合、[**Windows.Storage.Pickers**](https://msdn.microsoft.com/library/windows/apps/br207928) 名前空間のファイル ピッカーを使って、ユーザーにファイルを選ばせる必要があります (ファイルに直接アクセスすることはできません)。 別の例としては、アプリがユーザーの位置情報データにアクセスする場合、位置デバイス機能を有効にして、このアプリがユーザーの位置情報へのアクセスを要求することをダウンロード時にユーザーに確認する必要があります。 さらに、アプリが初めてユーザーの位置情報にアクセスするとき、追加の同意のプロンプトがユーザーに示され、データへのアクセスの許可を要求します。

このアプリ モデルは、アプリが外部と通信できない "刑務所" として機能しますが、外部から通信できない "城" ではないことに注意してください (もちろん管理者特権を持つアプリケーションは中に入れます)。 どの (Win32) アプリを実行できるかを組織/IT が指定することを可能にする、Windows 10 の Device Guard は、このアクセスをさらに制限するのに役立ちます。

また、このアプリ モデルはアプリのライフ サイクルを管理します。 これは、既定では、アプリのバックグラウンド実行を制限します。たとえば、アプリがバックグラウンドに移動するとすぐに、プロセスは中断され (コードのアプリ中断処理を行うための少しの時間をアプリに与えた後で)、メモリはフリーズされます。 オペレーティング システムは、アプリが特定のバックグラウンド タスクの実行 (インターネット/Bluetooth 接続、電源の変更などのさまざまなイベントによってトリガーされるスケジュールに従って、また音楽再生、GPS 追跡などの特定のシナリオで) を要求するためのメカニズムを提供します。

デバイスのメモリ リソースが不足している場合は、Windows はアプリを終了することによってメモリ領域を解放します。 このライフ サイクル モデルでは、アプリは中断時に必ずデータを保持します。これは、中断してから終了するまでの間、猶予時間が与えられないためです。

詳しくは、「[ユニバーサル: Windows 10 のアプリケーションのライフ サイクルについて](https://visualstudiomagazine.com/articles/2015/09/01/its-universal.aspx)」をご覧ください。

## <a name="42-stored-credential-protection"></a>4.2 保存された資格情報の保護


多くの場合、認証済みのサービスにアクセスする Windows アプリでは、ユーザーは資格情報をローカル デバイスに保存することができます。 これは、ユーザーによって指定されたユーザー名とパスワードを、アプリが、次回以降の起動時に自動的に使う場合に便利です。 この機能は、保存されているデータへのアクセス許可を攻撃者が手に入れた場合に、セキュリティ上の問題となる可能性があります。このため、Windows 10 では、Windows アプリはユーザーの資格情報を安全な資格情報保管ボックスに保存することができます。 アプリは、アプリのストレージ コンテナーに資格情報を保存するのではなく、資格情報保管ボックス API を呼び出して、保管ボックスに対して資格情報の保存や取得を実行します。 資格情報保管ボックスはオペレーティング システムによって管理されますが、アクセスは資格情報を保存したアプリに制限されます。これにより、資格情報の保存に関して、安全に管理されたソリューションが実現されます。

保存する資格情報をユーザーが指定すると、アプリでは、[**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089) 名前空間の [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトを使って、資格情報保管ボックスへの参照を取得します。 次に、Windows アプリの識別子、およびユーザー名とパスワードが含まれている [**PasswordCredential**](https://msdn.microsoft.com/library/windows/apps/br227061) オブジェクトが作成されます。 これが [**PasswordVault.Add**](https://msdn.microsoft.com/library/windows/apps/hh701231) メソッドに渡され、保管ボックスに資格情報が保存されます。 次の C# コードの例は、これがどのように実行されるかを示しています。

```cs
var vault = new PasswordVault();
vault.Add(new PasswordCredential("My App", username, password));
```

次の C# コードの例では、アプリは [**PasswordVault**](https://msdn.microsoft.com/library/windows/apps/br227081) オブジェクトの [**FindAllByResource**](https://msdn.microsoft.com/library/windows/apps/br227083) メソッドを呼び出して、アプリに対応するすべての資格情報を要求します。 複数の資格情報が返された場合、ユーザーは、ユーザー名の入力を求められます。 保管ボックスに資格情報がない場合、アプリは、ユーザーに対して資格情報を指定するように要求します。 ユーザーは、資格情報を使ってサーバーにログインします。

```cs
private string resourceName = "My App";
private string defaultUserName;

private void Login()
{
    PasswordCredential loginCredential = GetCredentialFromLocker();

    if (loginCredential != null)
    {
        // There is a credential stored in the locker.
        // Populate the Password property of the credential
        // for automatic login.
        loginCredential.RetrievePassword();
    }
    else
    {
        // There is no credential stored in the locker.
        // Display UI to get user credentials.
        loginCredential = GetLoginCredentialUI();
    }
    // Log the user in.
    ServerLogin(loginCredential.UserName, loginCredential.Password);
}

private PasswordCredential GetCredentialFromLocker()
{
    PasswordCredential credential = null;

    var vault = new PasswordVault();
    var credentialList = vault.FindAllByResource(resourceName);

    if (credentialList.Count == 1)
    {
        credential = credentialList[0];
    }
    else if (credentialList.Count > 0)
    {
        // When there are multiple usernames,
        // retrieve the default username. If one doesn't
        // exist, then display UI to have the user select
        // a default username.
        defaultUserName = GetDefaultUserNameUI();

        credential = vault.Retrieve(resourceName, defaultUserName);
    }
    return credential;
}
```

詳しくは、「[資格情報保管ボックス](credential-locker.md)」をご覧ください。

## <a name="43-stored-data-protection"></a>4.3 保存されたデータの保護


保存されたデータ (一般に "保存データ" と呼ばれます) を扱う場合、これを暗号化することによって、承認されていないユーザーは、保存されたデータにアクセスできなくなります。 データを暗号化する一般的なメカニズムには、対称キーを使う方法と非対称キーを使う方法の 2 つがあります。 ただし、データを暗号化しても、データが送信されて保存されるまでの間に、データの変更を防ぐことができるとは限りません。 つまり、データの整合性を保証することはできません。 メッセージ認証コード、ハッシュ、デジタル署名を利用することが、この問題を解決するための一般的な手法です。

## <a name="431-data-encryption"></a>4.3.1 データの暗号化


対称暗号化では、送信者と受信者は同じキーを所持し、そのキーを使ってデータの暗号化と暗号化解除を行います。 この方法で重要となる点は、送信者と受信者の双方が把握しているキーを安全に共有することです。

このデータ保護の方法の 1 つとして、公開/秘密キー ペアを使う非対称暗号化があります。 公開キーは、メッセージを暗号化するすべてのユーザーによって自由に共有されます。 秘密キーは、常に秘密のまま保持され、データの受信者だけがこのキーを使ってデータの暗号化を解除できます。 公開キーを検出できるようにするための一般的な方法は、デジタル証明書 (単に証明書とも呼ばる場合もあります) を使うことです。 証明書には、ユーザーやサーバーに関する情報 (名前、発行者、メール アドレス、国など) に加えて公開キーが含まれています。

Windows アプリの開発者は、[**SymmetricKeyAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241537) クラスと [**AsymmetricKeyAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241478) クラスを使って、UWP アプリに対称暗号化と非対称暗号化を実装することができます。 また、[**CryptographicEngine**](https://msdn.microsoft.com/library/windows/apps/br241490) クラスを使って、データの暗号化と暗号化解除、コンテンツへの署名、デジタル署名の確認を実行することができます。 アプリでは、[**Windows.Security.Cryptography.DataProtection**](https://msdn.microsoft.com/library/windows/apps/br241585) 名前空間の [**DataProtectionProvider**](https://msdn.microsoft.com/library/windows/apps/br241559) クラスを使って、保存されているローカル データの暗号化と暗号化解除を実行することもできます。

## <a name="432-detecting-message-tampering-macs-hashes-and-signatures"></a>4.3.2 メッセージの改ざんの検出 (Mac、ハッシュ、署名)


MAC は、対称キー (秘密鍵と呼ばれます) やメッセージを MAC 暗号化アルゴリズムへの入力として使った結果生成されるコード (またはタグ) です。 秘密鍵とアルゴリズムは、メッセージを転送する前に、送信者と受信者の間で合意されます。

MAC では、次のようにしてメッセージを確認します。

-   送信者は、秘密鍵を MAC アルゴリズムへの入力として使うことで、MAC タグを取得します。
-   送信者は、MAC タグとメッセージを受信者に送信します。
-   受信者は、秘密鍵とメッセージを MAC アルゴリズムへの入力として使うことで、MAC タグを取得します。
-   受信者は、取得した MAC タグと送信者の MAC タグを比較します。 これらが同じである場合、メッセージは改ざんされていないと見なされます。

![MAC による検証](images/secure-macs.png)

Windows アプリでは、[**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) クラスを呼び出して、MAC 暗号化アルゴリズムを実行するためのキーと [**CryptographicEngine**](https://msdn.microsoft.com/library/windows/apps/br241490) クラスを生成することにより、MAC によるメッセージの検証を実装できます。

## <a name="433-using-hashes"></a>4.3.3 ハッシュの使用


ハッシュ関数は、任意の長さのデータ ブロックを受け取り、固定ビット サイズの文字列 (ハッシュ値) を返す暗号アルゴリズムです。 この処理を実行できるハッシュ関数のファミリはすべて用意されています。

上記のメッセージ転送シナリオでは、MAC の代わりにハッシュ値を使うことができます。 送信者はハッシュ値とメッセージを送信し、受信者は、受信者独自のハッシュ値を送信者のハッシュ値とメッセージから取得して、2 つのハッシュ値を比較します。 Windows 10 で実行されているアプリでは、[**HashAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241511) クラスを呼び出して、利用可能なハッシュ アルゴリズムを列挙し、それらのアルゴリズムのいずれかを実行できます。 [**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) クラスは、ハッシュ値を表します。 [**CryptographicHash.GetValueAndReset**](https://msdn.microsoft.com/library/windows/apps/hh701376) メソッドを使うと、メソッドを使用するたびにオブジェクトを作成しなくても、異なるデータを繰り返しハッシュできます。 **CryptographicHash** クラスの Append メソッドは、ハッシュ対象のバッファーに新しいデータを追加します。 この処理全体を次の C# コードの例に示します。

```cs
public void SampleReusableHash()
{
    // Create a string that contains the name of the
    // hashing algorithm to use.
    string strAlgName = HashAlgorithmNames.Sha512;

    // Create a HashAlgorithmProvider object.
    HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);

    // Create a CryptographicHash object. This object can be reused to continually
    // hash new messages.
    CryptographicHash objHash = objAlgProv.CreateHash();

    // Hash message 1.
    string strMsg1 = "This is message 1";
    IBuffer buffMsg1 = CryptographicBuffer.ConvertStringToBinary(strMsg1, BinaryStringEncoding.Utf16BE);
    objHash.Append(buffMsg1);
    IBuffer buffHash1 = objHash.GetValueAndReset();

    // Hash message 2.
    string strMsg2 = "This is message 2";
    IBuffer buffMsg2 = CryptographicBuffer.ConvertStringToBinary(strMsg2, BinaryStringEncoding.Utf16BE);
    objHash.Append(buffMsg2);
    IBuffer buffHash2 = objHash.GetValueAndReset();

    // Convert the hashes to string values (for display);
    string strHash1 = CryptographicBuffer.EncodeToBase64String(buffHash1);
    string strHash2 = CryptographicBuffer.EncodeToBase64String(buffHash2);
}
```

## <a name="434-digital-signatures"></a>4.3.4 デジタル署名


保存されているメッセージがデジタル署名されている場合、そのメッセージに関するデータの整合性は、MAC による認証と同様の方法で検証されます。 デジタル署名のワークフローがどのように実施されるかを次に示します。

-   送信者は、メッセージをハッシュ アルゴリズムへの入力として使って、ハッシュ値 (ダイジェストとも呼ばれます) を取得します。
-   送信者は、秘密キーを使ってダイジェストを暗号化します。
-   送信者は、メッセージ、暗号化されたダイジェスト、使われたハッシュ アルゴリズムの名前を送信します。
-   受信者は、公開キーを使って、受信したダイジェスト (暗号化されたダイジェスト) の暗号化を解除します。 次に、ハッシュ アルゴリズムを使ってメッセージをハッシュし、独自のダイジェストを作成します。 最後に、受信者は 2 つのダイジェストを比較します (受信し暗号化を解除したダイジェストと、作成したダイジェスト)。 2 つのダイジェストが一致した場合にのみ、受信者は、メッセージが秘密キーの所有者から送信されたものであることを確信できます。これにより、メッセージが実際にその送信者からのものであり、メッセージが転送中に変更されていないことが保証されます。

![デジタル署名](images/secure-digital-signatures.png)

ハッシュ アルゴリズムは非常に高速であるため、サイズの大きいメッセージからでも、ハッシュ値をすばやく取得できます。 生成されたハッシュ値は任意の長さになりますが、メッセージ全体よりも短くなります。このため、公開キーと秘密キーを使ってメッセージ全体ではなくダイジェストのみを暗号化および暗号化解除する方法が最適な方法です。

詳しくは、「[デジタル署名](https://msdn.microsoft.com/library/windows/desktop/aa381977)」、「[MAC、ハッシュ、および署名](macs-hashes-and-signatures.md)」、および「[暗号化](cryptography.md)」の記事をご覧ください。

## <a name="5-summary"></a>5 まとめ


Windows 10 のユニバーサル Windows プラットフォームには、オペレーティング システムの機能を活用してより安全なアプリを作成する方法が数多くあります。 単一要素、多要素、または OAuth ID プロバイダーを利用する仲介の認証などさまざまな認証シナリオで、最も一般的な認証問題を軽減する API があります。 Windows Hello によって、ユーザーを認識する新しい生体認証サインイン システムが提供されます。また、Windows Hello を使うことで、正しい ID を意図的に回避するような操作をアクティブに阻止することができます。 さらに、キーと証明書に関する複数の層も提供されます。これらの層は、トラステッド プラットフォーム モジュールの外部で公開されたり、使われたりすることは決してありません。 また、より詳細なセキュリティ レイヤーを、オプションである構成証明識別キーや証明書の利用時に使うことができます。

移動中データの安全性を確保するには、SSL 経由で安全にリモート システムと通信し、SSL のピン留めを使用してサーバーの信頼性を検証することができる API が利用できます。 安全かつ制御された方法で API を発行することに関しては、Azure API 管理が、API のエンドポイントを不明瞭化する機能が加わったプロキシを使用して、Web 経由での API 公開用の強力な構成オプションを提供することにより支援します。 これらの API へのアクセスは API キーを使用することによりセキュリティが確保され、パフォーマンスを制御するために API の呼び出しを抑制することが可能です。

データがデバイスに到着すると、Windows アプリ モデルは、アプリがインストール、更新される方法、およびデバイスのデータにアクセスする方法をより細かく制御し、アプリが他のアプリのデータに承認されていない方法でアクセスするのを防止します。 資格情報保管ボックスを利用することで、ユーザーの資格情報の保存用に、オペレーティング システムによって管理されるセキュリティで保護された記憶域を使用し、ユニバーサル Windows プラットフォームが提供する暗号化およびハッシュ化する API を使うことによって他のデータをデバイス上で保護することができます。

## <a name="6-resources"></a>6 リソース


### <a name="61-how-to-articles"></a>6.1 ハウツー記事

-   [認証とユーザー ID](authentication-and-user-identity.md)
-   [Windows Hello](microsoft-passport.md)
-   [資格情報保管ボックス](credential-locker.md)
-   [Web 認証ブローカー](web-authentication-broker.md)
-   [指紋生体認証](fingerprint-biometrics.md)
-   [スマート カード](smart-cards.md)
-   [共有証明書](share-certificates.md)
-   [暗号化](cryptography.md)
-   [証明書](certificates.md)
-   [暗号化キー](cryptographic-keys.md)
-   [データ保護](data-protection.md)
-   [MAC、ハッシュ、および署名](macs-hashes-and-signatures.md)
-   [暗号化に関する輸出制限の順守](export-restrictions-on-cryptography.md)
-   [一般的な暗号化タスク](common-cryptography-tasks.md)

### <a name="62-code-samples"></a>6.2 コード サンプル

-   [資格情報保管ボックス](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/PasswordVault)
-   [資格情報ピッカー](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/CredentialPicker)
-   [Azure ログインによるデバイスのロックダウン](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/DeviceLockdownAzureLogin)
-   [エンタープライズ データ保護](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/EnterpriseDataProtection)
-   [KeyCredentialManager](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/KeyCredentialManager)
-   [スマート カード](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/SmartCard)
-   [Web アカウント管理](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/WebAccountManagement)
-   [WebAuthenticationBroker](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/WebAuthenticationBroker)

### <a name="63-api-reference"></a>6.3 API リファレンス

-   [**Windows.Security.Authentication.OnlineId**](https://msdn.microsoft.com/library/windows/apps/hh701371)
-   [**Windows.Security.Authentication.Web**](https://msdn.microsoft.com/library/windows/apps/br227044)
-   [**Windows.Security.Authentication.Web.Core**](https://msdn.microsoft.com/library/windows/apps/dn921967)
-   [**Windows.Security.Authentication.Web.Provider**](https://msdn.microsoft.com/library/windows/apps/dn921965)
-   [**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089)
-   [**Windows.Security.Credentials**](https://msdn.microsoft.com/library/windows/apps/br227089)
-   [**Windows.Security.Credentials.UI**](https://msdn.microsoft.com/library/windows/apps/hh701356)
-   [**Windows.Security.Cryptography**](https://msdn.microsoft.com/library/windows/apps/br241404)
-   [**Windows.Security.Cryptography.Certificates**](https://msdn.microsoft.com/library/windows/apps/br241476)
-   [**Windows.Security.Cryptography.Core**](https://msdn.microsoft.com/library/windows/apps/br241547)
-   [**Windows.Security.Cryptography.DataProtection**](https://msdn.microsoft.com/library/windows/apps/br241585)
-   [**Windows.Security.ExchangeActiveSyncProvisioning**](https://msdn.microsoft.com/library/windows/apps/hh701506)
-   [**Windows.Security.EnterpriseData**](https://msdn.microsoft.com/library/windows/apps/dn279153)
