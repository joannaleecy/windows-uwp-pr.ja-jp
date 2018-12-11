---
title: Xbox Live の呼び出しのベスト プラクティス
description: Xbox Live API を呼び出すためのベスト プラクティスについて説明します。
ms.assetid: f4c7156b-7736-41e5-9b3d-e87cc8dd2531
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, ベスト プラクティス
ms.localizationpriority: medium
ms.openlocfilehash: 55e05ef7de2e2981f9f5af86623a8d8413ce2c99
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8879396"
---
# <a name="best-practices-for-calling-xbox-live"></a>Xbox Live の呼び出しのベスト プラクティス

Xbox Live サービスは、Xbox Services API (XSAPI) を使用するか、REST エンドポイントを直接呼び出すかの、主に 2 つの方法で呼び出せます。 コードでどのように Xbox Live を呼び出すかにかかわらず、適切な呼び出しパターンと再試行ロジックを備えることが重要です。

適切な再試行ロジックを記述する方法を理解するには、**べき等**と**非べき等**の 2 種類の REST エンドポイントについて知る必要があります。 以下で、それぞれについて説明します。
 
## <a name="non-idempotent-endpoints"></a>非べき等エンドポイント

繰り返し呼び出しを行うと思わぬ結果が生じる HTTP メソッドは、**非べき等**と見なされます。 これは、たとえばクライアントがエンドポイントを呼び出して、ネットワークのタイムアウトが発生した場合に、リソースが更新されたものの、メソッドが成功したことをネットワークが呼び出し元に通知できなかった可能性があるため、メソッドを再試行するのは安全ではないことを意味します。 エラー発生時には、クライアントは再試行するのではなく、まず、呼び出しが成功したかどうかを確認するためのクエリを発行する必要があります。 呼び出しが失敗であった場合にのみ再試行する必要があります。

Xbox Services API に含まれる API の一部は、非べき等エンドポイントの呼び出しとして内部的にマーク付けされています。 これらの API は、非べき等エンドポイントの呼び出し時にエラーが発生した場合、そのエンドポイントの再試行を自動的には行いません。

非べき等エンドポイント API の完全な一覧を以下に示します。

* game\_server\_platform\_service::allocate\_cluster()
<br>
* game\_server\_platform\_service::allocate\_cluster\_inline()
<br>
* game\_server\_platform\_service::allocate\_session\_host()
<br>
* matchmaking\_service::create\_match\_ticket()
<br>
* multiplayer\_service::write\_session()
<br>
* multiplayer\_service::write\_session\_by\_handle()
<br>
* multiplayer\_service::send\_invites()
<br>
* reputation\_service::submit\_batch\_reputation\_feedback()
<br>
* reputation\_service::submit\_reputation\_feedback()
 

## <a name="idempotent-methods"></a>べき等メソッド

一方、**べき等** HTTP メソッドは、思わぬ結果をそのままにしません。 これはつまり、こうしたメソッドを再試行しても安全であることを意味します。 Xbox Services API に含まれるべき等メソッドはすべて、一定の条件下で自動的に再試行されます。

上の一覧に非べき等として示されなかったすべての API が、べき等 API です。


## <a name="retry-logic-best-practices"></a>再試行ロジックのベスト プラクティス

べき等呼び出しの場合、以下の条件については自動的に再試行してください。

* すべてのネットワーク エラー
* 401: Unauthorized
* 408: RequestTimeout
* 429: Too Many Requests
* 500: InternalError
* 502: BadGateway
* 503: ServiceUnavailable
* 504: GatewayTimeout


UWP 上では、401: Unauthorized は固有の処理が行われます。 このエラーは Xbox Live 認証トークンの有効期限が切れたことを示すため、Xbox Services API は、OS を呼び出してトークンを更新してから、1 回の再試行として実行されます。

再試行が実行される場合のベスト プラクティスは、"Retry-After" ヘッダーの時間に到達するまでサービスを呼び出さないことです。 現状では XSAPI にこのベスト プラクティスが実装されています。 いずれかの API でエラーの HTTP ステータス コードや "Retry-After" ヘッダーが返された場合、Retry-After の時間になる前に同じ API を追加呼び出しすると、サービスに到達することなく直ちに元のエラーが返されます。

呼び出しを再試行するときのベスト プラクティスは、ランダムな小さな変動を加えて指数バックオフを実行し、サービスに対する負荷を拡散させることです。 XSAPI は既定で 2 秒の遅延を適用して開始されます。この時間は、xbox\_live\_context\_settings::set\_http\_retry\_delay() を使用して制御されます。 これは、各再試行では既定で 2 秒、4 秒、8 秒などの指数バックオフが実行され、再試行を試みる一連のデバイス間で負荷をさらに分散させるため、今回と次回のバックオフ値から生じる遅延には、応答時間に基づいた変動が生じることを意味します。

呼び出しの再試行に費やす時間はタイトル側で制御する必要があります。 デベロッパーは、XSAPI を利用する場合、xbox\_live\_context\_settings::set\_http\_timeout\_window() 関数を使用してこれを直接制御できます。 既定では、これは 20 秒に設定されます。 これを 0 秒に設定すると、事実上、再試行ロジックがオフになります。 XSAPI では、http\_timeout\_window() での残り時間に基づいて、内部の HTTP タイムアウトも動的に調整されます。 内部の HTTP タイムアウトは、OS が HTTP ネットワーク操作を中止するまでに、その操作に費やす時間を制御します。 呼び出しが完了するのに十分妥当な時間が与えられるように、http\_timeout\_window() に少なくとも 5 秒残されていないと、呼び出しは再試行されません。 このルールは最初の呼び出しには適用されないので、http\_timeout\_window() を 0 に設定することも可能で、その場合は 1 回の呼び出しとなります。 このロジックの影響によって、API 呼び出しがいつ返るかに関して、http\_timeout\_window() は大幅に確定的です。 "Retry-After" ヘッダーが返された場合、"Retry-After" の時間に達するまで再試行は行われません。 "Retry-After" の時間が http\_timeout\_window() の後である場合は、http\_timeout\_window() の終わりに呼び出しが返ります。


## <a name="error-handling"></a>エラー処理

タイトル デベロッパーは、**すべての**サービス呼び出しに対して**常に**適切なエラー処理を行う必要があり、失敗した応答を適切に処理する必要があります。
 
Xbox Live に対する要求がエラー コードを返す結果になることがある次のような状況は、実際に数多くあります。

1.  ネットワークを利用できない。 たとえば、デバイスが 4G や Wi-Fi の接続を失ったり、ネットワークがダウン状態になった場合。
2.  サービスに対する負荷が大きすぎる (503)
3.  サービスでエラーが発生した (500)
4.  サービスに送信された要求が多すぎる (429)
5.  書き込み操作の競合 (412)。 たとえば、マルチプレイヤー セッション内の別のプレイヤーが先に変更を送信した場合。
6.  ユーザーが禁止されている、またはアクセス許可がない
7.  ユーザーがサインアウトした

これらの状況でゲームが正しく機能するようにするためには、適切なエラー処理が非常に重要です。

XSAPI には 2 種類のエラー処理パターンがあります。 1 つは C++/CX、C\#、または JavaScript から WinRT API を使用しているときのパターンで、もう 1 つは新しい C++ API を使用しているときのパターンです。 エラー処理のベスト プラクティスの詳細については、Xbox Live のドキュメント ページ「Error Handling」を参照してください。また、これに関して説明している動画については、[*Xfest 2015 のビデオ*](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2015.aspx)の「*XSAPI: C++, No Exceptions!*」という講演をご覧ください。


## <a name="best-calling-patterns"></a>最適な呼び出しパターン

### <a name="usebatching-requests"></a>Usebatching 要求

一部のエンドポイントは、バッチ処理、つまり一連の要求を 1 つの呼び出しに集約することをサポートしています。 たとえば、Xbox Live プロフィール サービスを使用すると、1 人のユーザーのプロフィールまたはユーザー プロフィールのセットを要求できます。 一連のユーザーのユーザー プロフィールが必要な場合、ユーザー プロフィールごとに 1 回エンドポイントや API を呼び出すのは非常に非効率的です。 それぞれの呼び出しで、多くの認証オーバーヘッドが発生します。 そのため何度も API を呼び出すのではなく、情報が必要なすべてのユーザーを一度に API に渡して、エンドポイントがすべてのユーザー プロフィールを同時に処理し、単一の応答を返すことができるようにします。

### <a name="use-the-real-time-activity-rta-service-instead-of-polling"></a>ポーリングの代わりにリアルタイム アクティビティ (RTA) サービスを使用する

別のベスト プラクティスは、定期的にポーリングする代わりに、リアルタイム アクティビティ (RTA) サービスを使用することです。 このサービスは、サービスで対象リソースに変更があったときに、クライアントに通知を送信する WebSocket を公開します。 RTA サービスは、プレゼンスの変更、統計情報の変更、マルチプレイヤー セッション ドキュメントの変更、およびソーシャル関係の変更についての通知を提供します。 クライアントがどのような情報を必要としているかを認識させるために、クライアントが最初に、WebSocket を介してアイテムにサブスクライブする必要があります。 これにより、アイテムの変更があると適切に通知されるため、変更の検出のためにサービスにポーリングする必要がなくなります。

XSAPI は RTA サービスを、クライアントが使用できるサブスクライブ API のセットとして公開しています。 これらの API それぞれに、アイテムの変更時に呼び出されるコールバック関数を引数に取る、対応する \*\_changed\_handler API があります。

* presence\_service::subscribe\_to\_device\_presence\_change
<br>
* presence\_service::subscribe\_to\_title\_presence\_change
<br>
* user\_statistics\_service::subscribe\_to\_statistic\_change
<br>
* social\_service::subscribe\_to\_social\_relationship\_change<br>
 

## <a name="use-xbox-live-client-side-managers"></a>Xbox Live クライアント側マネージャーを使用する

XSAPI では新たに、キャッシュおよび特定シナリオの手間がかかる処理をすべて実行するステート マシンとして機能するマネージャーのセットが用意されています。


### <a name="social-manager"></a>Social Manager

Social Manager は、フレンド リストとプロフィールに関連する手間がかかる処理をすべて実行します。 RTA サービスを使用して、フレンド リスト、フレンドのプロフィールおよびプレゼンス データを最新の状態に保ちます。 このマネージャーは、ゲーム エンジンから非常に利用しやすい同期 API を公開しています。 マネージャーがサービスから得た最新情報のメモリー内キャッシュを保持しているため、ゲームはこれらの API を頻繁に呼び出せます。 詳細については、Xbox Live ドキュメントのページ「Social Manager の概要」を参照してください。

### <a name="multiplayer-manager"></a>Multiplayer Manager

Multiplayer Manager は、従来のマルチプレイヤー ゲーム用に簡単に使えるソリューションで、マルチプレイヤー セッションを管理できます。 Multiplayer Manager API には、プレイヤーのロスターとセッション管理が含まれていて、ゲームへの招待、途中参加、マッチメイキングの処理、および既存のネットワーク ソリューションへの接続も可能です。 このマネージャーは、従来のマルチプレイヤー フローの実装に関連する手間がかかる処理をすべて実行します。 詳細については、Xbox Live ドキュメントのページ「Introduction to Multiplayer Manager」を参照してください。


## <a name="throttling-fine-grained-rate-limiting"></a>スロットリング (きめ細かなレート制限)

Xbox Live サービスには、単一デバイスがサービスに極端な負荷をかけることがないように、スロットリングが導入されています。 重要なのは、タイトルにいつスロットリングが適用されるかを知ることです。 タイトルにスロットリングが適用されたかどうかは、いくつかの異なる方法で確認できます。


### <a name="monitor-for-http-status-code-429"></a>HTTP ステータス コード 429 を監視する

Fiddler を使用して、HTTP ステータス コード 429 が返されたかどうかを監視できます。 JSON 応答に、エンドポイントがどのようにスロットリングされたかに関する詳細が含められます。 次に、例を示します。

```json
{
  "version":1,
  "currentRequests":13,
  "maxRequests":10,
  "periodInSeconds":120,
  "limitType":"Rate"
}
```

XSAPI を使用している場合、API は http\_status\_429\_too\_many\_requests エラーを返し、API がどのようにスロットリングされたかに関する詳細なエラー メッセージを設定します。

### <a name="debug-asserts"></a>デバッグのアサート

XSAPI の使用時には、デベロッパー サンドボックス内でタイトルのデバッグ ビルドを使用しているときに呼び出しがスロットリングされると、スロットリングが発生したことを直ちにデベロッパーに知らせるため、アサートが発生します。 これは、コードが正しく記述されていないために 429 スロットリング エラーを意図せず見逃すということがないようにするためです。 これらのアサートを無効にして、問題のコードを修正せずに作業を続けたい場合は、次の API を呼び出します。


> xboxLiveContext-&gt;settings()-&gt;disable\_asserts\_for\_xbox\_live\_throttling\_in\_dev\_sandboxes( xbox\_live\_context\_throttle\_setting::this\_code\_needs\_to\_be\_changed\_to\_avoid\_throttling );

ただし、この API によってタイトルのスロットリングが回避されるわけではないことに注意してください。 タイトルは、変わらずスロットリングされます。 この API は、デベロッパー サンドボックス内でデバッグ ビルドを使用するときにアサートを無効にするだけです。 

### <a name="xbox-live-trace-analyzer-tool"></a>Xbox Live Trace Analyzer ツール

Xbox Live 呼び出しのトレースを記録してから、[Xbox Live Trace Analyzer ツール](https://docs.microsoft.com/windows/uwp/xbox-live/tools/analyze-service-calls)を使用して、そのトレースを分析することもできます。

トレースを記録するには、Fiddler を使用して .SAZ ファイルを記録するか、XSAPI の組み込みトレース ログを使用します。 XSAPI でトレースをオンにする方法の詳細については、Xbox Live ドキュメントのページ「Xbox Live サービスへの呼び出しを分析する」を参照してください。 トレースを用意すると、スロットリングされた呼び出しの検出時に Xbox Live Trace Analyzer ツールが警告を発します。

## <a name="is-xbox-live-up"></a>Xbox Live は稼働中か

Xbox Live は、プロフィール、フレンドとプレゼンス、統計情報、ランキング、実績、マルチプレイヤー、マッチメイキングなどの Xbox Live の機能を公開するマイクロサービスの集合体です。 Xbox Live が稼働中かどうかを決める単一のサーバーやエンドポイントは存在しません。 1 台のサーバーがダウンした場合でも、Xbox Live の残りのマイクロサービスは、その大部分が独立していて、動作可能です。

1 つのサービスで一時的な停止が発生している場合、そのサービスの呼び出しがゲームにとってミッション クリティカルであるかどうかを知ることが重要です。 ネットワークやサービスの問題が断続的に発生しているときには、適切なエクスペリエンスを提供するようにしてください。 たとえば、プレゼンス サービスがエラーを返している場合、その呼び出しはおそらくゲームにとってミッション クリティカルではありません。 そのためユーザーには、Xbox Live がダウンしていることを報告するのではなく、最後の既知のプレゼンス情報を報告するだけにします。

Xbox Live は、結果整合性という一貫性モデルにも従っています。 これは、新しい更新が行われない場合、最終的には、そのリソースに対するすべての要求で、最後に更新された値が報告されることを意味します。 これはつまり、データが伝播するまで情報が古いままである、短い期間があることを意味しています。
