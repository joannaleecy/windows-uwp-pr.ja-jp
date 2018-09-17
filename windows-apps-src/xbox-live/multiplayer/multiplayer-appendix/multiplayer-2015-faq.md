---
title: マルチプレイヤー 2015 の FAQ とトラブルシューティング
author: KevinAsgari
description: Xbox Live マルチプレイヤー 2015 ついてよく寄せられる質問とトラブルシューティングを示します。
ms.assetid: 75823f10-b342-4e20-b885-e5ad4392bc3d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: 2c319db5c93f6bc06f551fbb3b76f975fc3de87a
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3985128"
---
# <a name="multiplayer-2015-faq-and-troubleshooting"></a>マルチプレイヤー 2015 の FAQ とトラブルシューティング

-   新しいタイトルを開発しています。 どのマルチプレイヤー API 要素を使用する必要がありますか。
-   新しいマルチプレイヤー API にサービスからアクセスするにはどうすればよいですか。
-   タイトルで複数のセッションの変更をサブスクライブできますか。
-   ユーザーがネットワーク接続を失ったか、本体の電源をオフにした場合、そのユーザーはすぐに削除されますか。
-   使用する SCID、セッション テンプレート、サンドボックスを調べる方法を教えてください。
-   自分のタイトル用のものと比較できる要求本文の例はありますか。
-   MPSD を呼び出すと HTTP/403 コードを受け取ります。
-   MPSD を呼び出すと HTTP/404 コードを受け取ります。
-   **MultiplayerService.WriteSessionByHandleAsync** または **MultiplayerService.GetCurrentSessionByHandleAsync** を呼び出すと HTTP/404 コードを受け取るのはなぜですか。
-   MPSD を呼び出すと HTTP/412 コードを受け取ります。
-   MPSD を呼び出すと HTTP/400、405、409、503 などのコードを受け取ります。
-   タイトルのセッション テンプレートでは何を変更できますか、または何を変更する必要がありますか。
-   セッションが初期化されていないことを示すエラーが示されます。
-   セッションが作成されず、HTTP/204 コードを受け取ります。
-   どのようなときに MPSD をポーリングする必要がありますか。
-   セッションに予約または招待されたプレイヤーがセッションに参加しないとどうなりますか。
-   作成したセッションがマッチメイキングによって見つからないのはどうしてでしょうか。
-   2015 マルチプレイヤーでのパーティーの適切な使用法と 2014 マルチプレイヤーでの使用法の主な違いは何ですか。
-   ゲーム セッションに空きプレイヤー スロットがあり、ゲーム セッションが途中参加をサポートしている場合、開始したセッションをユーザーが見つけられないのはなぜですか。
-   ゲーム セッションが開いている場合、ゲームに参加したばかりのユーザーは、予約を待つ必要はなく、単にセッションに参加してプレイを開始できますか。
-   タイトルで大規模なゲーム セッションをプレイしているときに、ゲーム招待トーストを受け取らないセッション メンバーがいるのはなぜですか。
-   ゲームの動作に一貫性がなく、ゲーム パーティー機能を参照するプロトコルのアクティベーション情報を受け取りました。
-   V107 セッション テンプレートを構成したのに、v105 セッション ドキュメントの構文がトレースで表示されるのはなぜですか。


### <a name="i-am-developing-a-new-title-which-multiplayer-api-elements-should-i-use"></a>新しいタイトルを開発しています。 どのマルチプレイヤー API 要素を使用する必要がありますか。

2014 マルチプレイヤー機能は、引き続き既存のタイトルに適用されますが、関連する API 要素は非推奨となる可能性が高いです。 2015 年のリリースに向けてクライアントを準備するときは、2015 マルチプレイヤーの使用を強くお勧めします。


### <a name="how-can-i-access-the-new-multiplayer-api-from-a-service"></a>新しいマルチプレイヤー API にサービスからアクセスするにはどうすればよいですか。

「[MPSD の呼び出し](multiplayer-session-directory.md)」を参照してください。


### <a name="can-my-title-subscribe-to-changes-for-more-than-one-session"></a>タイトルで複数のセッションの変更をサブスクライブできますか。

はい、タイトルは 1 接続あたり最大 10 個のセッションに関する変更の受信をサブスクライブできます。


### <a name="will-a-user-be-removed-immediately-if-heshe-loses-a-network-connection-or-turns-off-the-console"></a>ユーザーがネットワーク接続を失ったか、本体の電源をオフにした場合、そのユーザーはすぐに削除されますか。

Web ソケット接続では、MPSD はクライアントの切断を迅速に検出し、そのクライアントを非アクティブに設定することができます。 セッション メンバーは、非アクティブ削除タイムアウトが経過するとすぐに削除されます。 詳細については、「[セッション タイムアウト](mpsd-session-details.md)」を参照してください。


### <a name="how-do-i-find-out-what-scid-session-template-and-sandbox-to-use"></a>使用する SCID、セッション テンプレート、サンドボックスを調べる方法を教えてください。

タイトルの最初の登録にかかわっていなかった場合は、この情報が作成されたときに、この情報にアクセスすることはできません。 この情報を入手するには、担当のデベロッパー アカウント マネージャーにお問い合わせください。


### <a name="is-there-an-example-of-a-request-body-that-i-can-compare-to-the-one-for-my-title"></a>自分のタイトル用のものと比較できる要求本文の例はありますか。

「**MultiplayerSessionRequest (JSON)**」の要求の構造を参照してください。


### <a name="i-am-getting-an-http403-code-when-calling-mpsd"></a>MPSD を呼び出すと HTTP/403 コードを受け取ります。

通常、これはアクセス許可またはスコープの問題です。 Fiddler トレースを収集して情報を取得し、一般的な 403 メッセージの HttpResponse 本文の一部として返されたメッセージを確認します。

-   要求されたサービス構成にアクセスできません。
    1.  サンドボックスにアクセスできるアカウントを使用していることを確認します。
    2.  適切なサンドボックス内にいることを確認します。
     3.  証明書認証を使用していてこのエラーが発生する場合は、担当のデベロッパー アカウント マネージャーに問い合わせてください。   要求されたセッションにアクセスできません。 呼び出し元のユーザーにはマルチプレイヤー権限が必要であり、プライベート セッションはセッション メンバーによってのみ読み取り可能です。

    おそらく可視性がプライベートのセッションにアクセスしようとしているため、セッションを表示できません。 可視性がプライベートに設定されている場合、そのセッションのメンバーだけがセッション ドキュメントを読み取ることができます。

| 注意                                                                                                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 新しいセッションに登録するには、ユーザーにゴールド アカウントが必要です。 プレイ中のユーザーにゴールド アカウント権限がない場合、新しいセッションの登録を要求すると HTTP/403 が返されます。 |

-   認証プリンシパルにサーバーが含まれていない場合、要求本文に既存メンバーの参照を含めることはできません。

    ユーザーの代わりに別のユーザーをセッションに参加させることはできません。 招待のみ可能です。 プレイヤーを招待するには、インデックスを"reserve\_&lt;number&gt;" に設定します。


### <a name="i-am-getting-an-http404-code-when-calling-mpsd"></a>MPSD を呼び出すと HTTP/404 コードを受け取ります。

Fiddler トレースを収集して詳しい情報を入手した後、以下の手順に従います。

1.  一般的な 404 メッセージの HttpResponse 本文の一部として返されたメッセージを確認します。
    -   要求されたサービス構成は無効であるか、またはセッション用に構成されていません。 使用している SCID が正しいことを確認します。
    -   要求されたセッションが見つかりませんでした。 セッションが作成されていること、およびセッションを取得する前にセッション テンプレートが正しいことを確認します。 PUT 呼び出しを使用してセッションを作成できます。

2.  使用している URI を確認します。
3.  本体を再起動するか、新しいユーザーで試します。
4.  ゲーム デベロッパー フォーラムでエラー コードまたは他の解決策を調べます。
5.  セッションが、空になったために削除されたのではないことを確認します。 ユーザーのタイムアウトが理由でセッションが空になることがあります。これが発生するのは、通常、すべてのセッションのメンバーが "準備完了" や "非アクティブ" などのタイムアウトが適用される状態になっているためです。 ユーザーの状態の詳細については、「[セッションのユーザーの状態](mpsd-session-details.md)」を参照してください。


### <a name="why-am-i-getting-an-http404-code-when-calling-multiplayerservicewritesessionbyhandleasync-or-multiplayerservicegetcurrentsessionbyhandleasync"></a>**MultiplayerService.WriteSessionByHandleAsync** または **MultiplayerService.GetCurrentSessionByHandleAsync** を呼び出すと HTTP/404 コードを受け取るのはなぜですか。

タイトルがハンドル ID を含む参加プロトコルのアクティブ化に応答してハンドルによって MPSD セッションにアクセスする場合、プロトコルのアクティブ化のハンドル ID が以下の理由のいずれかのために古くなっている可能性があります。

-   タイトルが参加を開始した Xbox のシェルの UI ビューが古くなっている可能性があります。 ユーザーのプロファイル カードなどの一部の UI ビューは、開かれている間、参加ハンドルを自動的に更新しません。 HTTP/404 コードの受信を避けるには、参加する前に、タイトルでビューを閉じ、再度開いてデータを更新します。
-   タイトルが参加させようとしているユーザーが、タイトルが Xbox シェル UI からの参加操作を選択した後でアクティビティ セッションを切り替えた可能性があります。 これが HTTP/404 コードの原因となるのはまれです。

いずれの場合でも、タイトル コードでは、参加するユーザーに参加が失敗したことを示すエラー メッセージを示す必要があります。


### <a name="i-am-getting-an-http412-code-when-calling-mpsd"></a>MPSD を呼び出すと HTTP/412 コードを受け取ります。

既にセッションが存在する場合、次のような要求は HTTP/412 を返します。

    PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1
    Content-Type: application/json
    If-None-Match: *


セッションの etag が If-Match ヘッダーと一致しない場合、次のような要求は HTTP/412 を返します。

    PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1
    Content-Type: application/json
    If-Match: 9555A7DE-8B91-40E4-8CFB-0629312C9C7D


詳細については、「[セッション更新の同期](multiplayer-session-directory.md)」を参照してください。


### <a name="i-am-getting-an-http400-405-409-503-etc-code-when-calling-mpsd"></a>MPSD を呼び出すと HTTP/400、405、409、503 などのコードを受け取ります。

Fiddler トレースを収集して情報を取得し、HttpResponse 本文の一部として返されたメッセージを確認します。 これにより、エラーを識別して修正するのに十分な情報が得られます。または、開発者フォーラムで解決策を検索できます。

また、XSAPI を使用している場合は、「[Xbox Live サービス API のトラブルシューティング](../../using-xbox-live/troubleshooting/troubleshooting-the-xbox-live-services-api.md)」で説明されているように、応答本文を取得できます。 コードで **XboxLiveContextSettings.EnableServiceCallRoutedEvents** プロパティを使用して出力をタイトル UI に送信することもできます。


### <a name="what-can-or-should-i-change-in-the-session-templates-for-my-title"></a>タイトルのセッション テンプレートでは何を変更できますか、または何を変更する必要がありますか。

セッション テンプレートはセッションのパターンなので、テンプレートで既に設定されている定数を上書きすることはできません。 ただし、新しいプロパティを追加することは可能です。 詳細については、「[MPSD セッション テンプレート](multiplayer-session-directory.md)」を参照してください。


### <a name="im-getting-an-error-that-is-saying-my-session-isnt-initialized"></a>セッションが初期化されていないことを示すエラーが示されます。

応答エラーの例:

400 - \[ResponseBody\]: This session is configured for managed initialization requiring at least 2 members to start. (このセッションは、開始するために少なくとも 2 人のメンバーが必要な管理された初期化用に構成されています)

"initialize" フィールドが true に設定された十分な数のセッション メンバー予約が要求に含まれないため、セッションを作成できません。 コードで **MultiplayerSession.AddMemberReservation** メソッドまたは **MultiplayerSession.Join** メソッドの *initializeRequested* パラメーターを使用してメンバーに対してこのフィールドを設定できます。

初期化がセッション テンプレートで指定されている場合、マッチメイキング QoS に合格するのに十分な数のメンバー予約に対して "initialize":"true" が設定されていることを確認します。 詳細については、「[ターゲット セッションの初期化と QoS](smartmatch-matchmaking.md)」を参照してください。


### <a name="my-session-is-not-being-created-and-im-getting-an-http204-code"></a>セッションが作成されず、HTTP/204 コードを受け取ります。

このステータス コードは、セッションを作成したときにユーザーがセッションに追加されていないことを示します。 セッション作成時にセッションにユーザーが存在せず、空セッション タイムアウトが 0 (既定) の場合、セッションは作成されません。

セッションの作成時に、少なくとも 1 人のプレイヤーを必ず追加します。 専用サーバー シナリオの場合は、マッチを作成しようとしているプレイヤーまたはマッチを作成する必要があるプレイヤーを取得して、そのプレイヤーをそのマッチの初期プレイヤーにします。 または、空セッション タイムアウトを変更または削除してもかまいません。 詳細については、「[セッション タイムアウト](mpsd-session-details.md)」を参照してください。


### <a name="when-should-i-poll-mpsd"></a>どのようなときに MPSD をポーリングする必要がありますか。

タイトルは MPSD のポーリングを避ける必要があります。 タイトルは、MPSD セッションへの変更を検出する必要がある場合は、セッション変更イベントをサブスクライブする必要があります。 詳細については、「[方法: MPSD セッション変更通知のサブスクライブ](multiplayer-how-tos.md)」を参照してください。


### <a name="what-happens-if-a-player-who-was-reserved-or-invited-to-the-session-does-not-join-it"></a>セッションに予約または招待されたプレイヤーがセッションに参加しないとどうなりますか。

ゲーム セッションの準備ができたことがプレイヤーに通知されたときにタイトルが動作しているかどうかによって異なります。 プレイヤーがタイトル内にいて、タイトル UI 内からのゲーム セッション通知を受け入れない場合、**MultiplayerSession.Leave** メソッドによるゲーム セッションからのプレイヤーの削除はタイトルに委ねられます。

タイトルが制限されているか、または実行していない場合は、スロットが使用可能であることをプレイヤーに伝える通知をシェルが提供します。 プレイヤーがシステムからの通知を拒否または無視すると、MPSD はそのプレイヤーをゲーム セッションから削除します。


### <a name="why-would-a-created-session-not-be-found-by-matchmaking"></a>作成したセッションがマッチメイキングによって見つからないのはどうしてでしょうか。

Xbox One では、セッションを作成しただけでは、マッチメイキングは新しいセッションを検索しません。 マッチ チケットを作成して、マッチメイキング サービスへのセッションの公開を開始する必要があります。 「[SmartMatch マッチメイキング](smartmatch-matchmaking.md)」を参照してください。


### <a name="what-is-the-key-difference-between-the-way-parties-are-properly-used-by-2015-multiplayer-and-the-way-they-were-used-in-2014-multiplayer"></a>2015 マルチプレイヤーでのパーティーの適切な使用法と 2014 マルチプレイヤーでの使用法の主な違いは何ですか。

2015 マルチプレイヤーでは、マルチプレイヤー API はシステム レベルのゲーム パーティーを定義せず、チャット パーティーのみを定義します。 ゲーム パーティーを使用するのではなく、タイトルはセッションを使用して参加、招待、および関連する機能を制御します。 2014 マルチプレイヤーでは、Xbox One の マルチプレイヤー API は、ゲーム パーティーの概念 (**Party** クラス) を顕著に使用し、実質的には、ゲームへの招待ではなく、システム レベルの参加ロビーを実装していました。


### <a name="if-a-game-session-has-open-player-slots-and-supports-join-in-progress-why-would-users-not-be-able-to-find-the-session-once-it-has-started"></a>ゲーム セッションに空きプレイヤー スロットがあり、ゲーム セッションが途中参加をサポートしている場合、開始したセッションをユーザーが見つけられないのはなぜですか。

ゲーム セッションは、開始時に、マッチメイキング サービスで公開されなくなりました。 プレイヤー スロットがセッション内で使用可能になり、アービター (ホスト) が新しいプレイヤーを集める場合、アービターは **MatchmakingService.CreateMatchTicketAsync** メソッドを使用して進行中のセッションに対する新しいマッチ チケットを作成する必要があります。 チケットは、セッションを再び公開して、さらにプレイヤーを探します。 「[SmartMatch マッチメイキング](smartmatch-matchmaking.md)」を参照してください。


### <a name="if-a-game-session-is-open-can-a-user-who-has-just-joined-a-game-simply-join-the-session-and-start-playing-without-having-to-wait-for-the-reservation"></a>ゲーム セッションが開いている場合、ゲームに参加したばかりのユーザーは、予約を待つ必要はなく、単にセッションに参加してプレイを開始できますか。

できます。 これは、タイトルで複数のセッションを使用してゲーム セッション内でプレイヤーのサブグループを追跡する場合に特に便利です。 参加ユーザーは自分のグループを表すセッションに参加し、それよりも大きいゲーム セッションに参加する必要がある可能性があります。


### <a name="when-large-game-sessions-are-playing-in-my-title-why-arent-all-session-members-seeing-the-game-invite-toast"></a>タイトルで大規模なゲーム セッションをプレイしているときに、ゲーム招待トーストを受け取らないセッション メンバーがいるのはなぜですか。

参加を通じてタイトルがユーザーをセッションに追加するとき、タイトルは常に **MultiplayerSessionMember.InitializeRequested** プロパティを true に設定します。 これにより、ゲームを初期化ステージから移行する前に残りのセッション メンバーを待つように MPSD に指示します。 そうでない場合は、ユーザーが参加できる時間が非常に短くなり、トーストとセッション変更通知を見逃す可能性があります。


### <a name="i-am-seeing-inconsistent-game-behavior-and-have-received-protocol-activation-information-referencing-game-party-features"></a>ゲームの動作に一貫性がなく、ゲーム パーティー機能を参照するプロトコルのアクティベーション情報を受け取りました。

これは、2014 マルチプレイヤーと 2015 マルチプレイヤーの機能が混在していることを示しています。 2015 マルチプレイヤー用の API は、2014 マルチプレイヤー用に記述されたコードでは決して使わないでください。


### <a name="why-am-i-seeing-the-syntax-for-v105-session-documents-in-my-traces-although-i-have-configured-a-v107-session-template"></a>V107 セッション テンプレートを構成したのに、v105 セッション ドキュメントの構文がトレースで表示されるのはなぜですか。

MPSD は、クライアントの要求に基づいて、セッション ドキュメント バージョン間の自動変換を実行します。 現在、すべての Xbox Service API は、MPSD への要求に v105 を使用します。 このために、v107 セッション テンプレートと v105 トレースとの間で構文が異なる場合がありますが、それ以外の機能的な影響はありません。 セッション テンプレートは、v107 として構成する必要があります。

© 2015 Microsoft Corporation. All rights reserved. 
フィードバックは <https://forums.xboxlive.com/spaces/22/index.html> で送信できます。
バージョン: 2.0.90731.0
